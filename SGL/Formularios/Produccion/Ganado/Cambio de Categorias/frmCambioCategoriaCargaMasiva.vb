Imports System.Data.SqlClient
Public Class frmCambioCategoriaCargaMasiva
    Private fnCambioCategorias As New fnCambioCategorias
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Public PDFManual As String
    Public TipoCambio As String
    Public Param1_Modo As Integer       '1=ingreso celo / 2=muestra celo / 3=muestra sin celo / 4 = muestra celos anormales
    Public Param2_Empresa As Integer
    Public Param3_CentroCod As String
    Public Param3_CentroNom As String
    Public Param4_FechaDesde As Date
    Public Param4_FechaHasta As Date
    Public Param5_Observs As String

    Private Sub frmCambioCategoriaCargaMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.Categorias.Cargar()
        General.CategoriasFecha.Cargar()
        General.CategoriasVacas.Cargar()
        CboLLenaCentros()
        ' CboLLenaCategorias()
        cboCategoriaDes.Items.Add("--Seleccionar--")
        cboCategoriaDes.SelectedIndex = 0

        If TipoCambio = "Vacas" Then
            Label1.Text = "Cambio masivo de categoria para ganado adulto"
            GroupBox5.Text = "F. Parto Inicio"
            GroupBox1.Text = "F. Parto Fin"
            CboLLenaCategoriasVacas()
            FechaNacPar.Text = "Fecha Parto"
        Else
            CboLLenaCategorias()
        End If
        ToolTipText()
    End Sub
    Private Sub ToolTipText()
        Dim Textreprocesa As String
        Textreprocesa = "Manual de uso para Cambio de categorias - Cambio por fecha de nacimiento”

        ToolTip1.SetToolTip(Ayuda, Textreprocesa)

    End Sub
    Private Sub lvRESUMEN1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub
    Private Sub DetalleGanado()
        If lvGanado.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvGanado.SelectedItems.Item(0).SubItems(1).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvGanado.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvGanado, e)
    End Sub

    Private Sub CboLLenaCategoriasVacas()
        If General.CategoriasVacas.NroRegistros = 0 Then Exit Sub

        cboCategoriaOri.Items.Clear()
        cboCategoriaOri.Items.Add("--Seleccionar--")
        Dim i As Integer

        For i = 0 To General.CategoriasVacas.NroRegistros - 1
            cboCategoriaOri.Items.Add(General.CategoriasVacas.Nombre(i))
        Next
        cboCategoriaOri.SelectedIndex = 0
    End Sub

    Private Sub CboLLenaCategorias()
        If General.CategoriasFecha.NroRegistros = 0 Then Exit Sub

        cboCategoriaOri.Items.Clear()
        cboCategoriaOri.Items.Add("--Seleccionar--")
        Dim i As Integer

        For i = 0 To General.CategoriasFecha.NroRegistros - 1
            cboCategoriaOri.Items.Add(General.CategoriasFecha.Nombre(i))
        Next
        cboCategoriaOri.SelectedIndex = 0
    End Sub
    Public Sub BuscarCategorias()
        Dim con As New SqlConnection(GetConnectionString())

        Dim cmd As New SqlCommand("spCategorias_ListadoGndCambio", con)
        Dim cat As String = General.CategoriasFecha.Codigo(cboCategoriaOri.SelectedIndex - 1)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        If cboCentros.Text = "--Todos--" Then
            cmd.Parameters.AddWithValue("@Centro", "--Todos--")
        Else
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1))
        End If

        cmd.Parameters.AddWithValue("@Categoria", cat)
        cmd.Parameters.AddWithValue("@FechaIni", Fechaini.Value)
        cmd.Parameters.AddWithValue("@Fecha", FechaGrabar.Value)
        cmd.Parameters.AddWithValue("@FechaFin", Fechafin.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.CommandTimeout = 300 ' 5 minutos
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            lvGanado.Items.Clear()
            Try
                While rdr.Read()
                    i = i + 1
                    Dim lvitem As New ListViewItem(i)    'primera columna, para ordenar los datos
                    lvitem.SubItems.Add(rdr("GndCod").trim.ToString)
                    lvitem.SubItems.Add(rdr("GndProNom").trim.ToString)
                    lvitem.SubItems.Add(rdr("Centro").trim.ToString)
                    lvitem.SubItems.Add(rdr("GndFecNac"))
                    lvitem.SubItems.Add(rdr("Observacion").ToString)
                    lvGanado.Items.Add(lvitem)
                End While
                lblTotDiios.Text = i
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Sub BuscarVacas()
        Dim con As New SqlConnection(GetConnectionString())

        Dim cmd As New SqlCommand("spCategorias_ListadoGndCambioPorFechaParto", con)
        Dim cat As String = General.CategoriasVacas.Codigo(cboCategoriaOri.SelectedIndex - 1)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        If cboCentros.Text = "--Todos--" Then
            cmd.Parameters.AddWithValue("@Centro", "--Todos--")
        Else
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1))
        End If

        cmd.Parameters.AddWithValue("@Categoria", cat)
        cmd.Parameters.AddWithValue("@FechaIni", Fechaini.Value)
        cmd.Parameters.AddWithValue("@Fecha", FechaGrabar.Value)
        cmd.Parameters.AddWithValue("@FechaFin", Fechafin.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.CommandTimeout = 300 ' 5 minutos
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            lvGanado.Items.Clear()
            Try
                While rdr.Read()
                    i = i + 1
                    Dim lvitem As New ListViewItem(i)    'primera columna, para ordenar los datos
                    lvitem.SubItems.Add(rdr("GndCod").trim.ToString)
                    lvitem.SubItems.Add(rdr("GndProNom").trim.ToString)
                    lvitem.SubItems.Add(rdr("Centro").trim.ToString)
                    lvitem.SubItems.Add(rdr("GndUltFechaParto"))
                    lvitem.SubItems.Add(rdr("Observacion").ToString)
                    lvGanado.Items.Add(lvitem)
                End While
                lblTotDiios.Text = i
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If cboCategoriaOri.SelectedIndex = 0 Or cboCategoriaDes.SelectedIndex = 0 Then
            If MsgBox("Para buscar ganado primero seleccionar las categorias", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        If TipoCambio = "Vacas" Then
            BuscarVacas()
        Else
            BuscarCategorias()
        End If

        Dim numErrores As Integer
        For i = 0 To lvGanado.Items.Count - 1
            If lvGanado.Items(i).SubItems(5).Text.Trim <> "" Then
                lvGanado.Items(i).BackColor = Color.Red
                numErrores = numErrores + 1
            End If
        Next
        lblErrores.Text = numErrores
    End Sub

    Private Sub cboCategoriaOri_MouseClick(sender As Object, e As MouseEventArgs) Handles cboCategoriaOri.MouseClick

    End Sub
    Private Sub cboCategoriaOri_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategoriaOri.SelectedIndexChanged
        If TipoCambio = "Vacas" Then
            If cboCategoriaOri.SelectedIndex <> 0 Then
                General.Categorias.CargarCambios(General.CategoriasVacas.Codigo(cboCategoriaOri.SelectedIndex - 1))
                CboLLenaCategoriasDestino()
            End If
        Else
            If cboCategoriaOri.SelectedIndex <> 0 Then
                General.Categorias.CargarCambios(General.CategoriasFecha.Codigo(cboCategoriaOri.SelectedIndex - 1))
                CboLLenaCategoriasDestino()
            End If
        End If



    End Sub
    Private Sub CboLLenaCategoriasDestino()
        '  If General.Categorias.NroRegistros = 0 Then Exit Sub

        cboCategoriaDes.Items.Clear()
        cboCategoriaDes.Items.Add("--Seleccionar--")
        Dim i As Integer

        For i = 0 To General.Categorias.NroRegistros - 1
            cboCategoriaDes.Items.Add(General.Categorias.NombreCambio(i))
        Next
        cboCategoriaDes.SelectedIndex = 0
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("¿ DESEA ELIMINAR TODOS LOS ERRORES? ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If


        Dim numErrores As Integer = lblErrores.Text
        Dim totaldiios As Integer = lblTotDiios.Text
        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = num - 1 To 0 Step -1
            If lvGanado.Items(i).BackColor = Color.Red Then
                lvGanado.Items.RemoveAt(i)
                numErrores = numErrores - 1
                totaldiios = totaldiios - 1
            End If
        Next
        lblTotDiios.Text = totaldiios
        lblErrores.Text = numErrores



        If lblTotDiios.Text = 0 And lblErrores.Text Then
            cboCategoriaDes.Enabled = True
            cboCategoriaOri.Enabled = True
            cboCentros.Enabled = True
            Fechafin.Enabled = True
            Fechaini.Enabled = True
            btnBuscar.Enabled = True
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}


        ExportToExcelGrilla(lvGanado, tot)
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If lblErrores.Text <> 0 Then
            If MsgBox("PARA GRABAR DATOS, ELIMINAR ERRORES", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        If MsgBox("¿ DESEA GRABAR EL CAMBIO DE CATEGORIAS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If GrabarCambioCategoria() Then
            Me.Close()
        End If

    End Sub
    Private Function GrabarCambioCategoria() As Boolean
        Dim CategoriaOri As String = General.CategoriasFecha.Codigo(cboCategoriaOri.SelectedIndex - 1)
        Dim CategoriaDes As String = General.Categorias.CodigoCambio(cboCategoriaDes.SelectedIndex - 1)
        If TipoCambio = "Vacas" Then
            If fnCambioCategorias.Grabar(lvGanado, CategoriaOri, CategoriaDes, FechaGrabar.Value, "Cambio Masivo de ganado adulto""Cambio Masivo por fecha nacimiento") Then
                Return True
            Else
                Return False
            End If
        Else
            If fnCambioCategorias.Grabar(lvGanado, CategoriaOri, CategoriaDes, FechaGrabar.Value, "Cambio Masivo por fecha nacimiento") Then
                Return True
            Else
                Return False
            End If
        End If

    End Function
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("--Todos--")
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False
        If cboCategoriaDes.Text = "--Seleccionar--" Then
            If MsgBox("DEBE SELECCIONAR UNA CATEGORIA DE DESTNO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCategoriaDes.Focus()
            Exit Function
        End If
        If cboCategoriaOri.Text = "--Seleccionar--" Then
            If MsgBox("DEBE SELECCIONAR UNA CATEGORIA DE ORIGEN", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCategoriaOri.Focus()
            Exit Function
        End If
        'If cboCentros.SelectedIndex = -1 Then
        '    If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboCentros.Focus()
        '    Exit Function
        'End If

        If FechaGrabar.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            FechaGrabar.Focus()
            Exit Function
        End If


        ValidacionesLocales = True
    End Function
    Private Sub LeeBaston()

        If Param1_Modo = 3 Or Param1_Modo = 4 Then
            If cboCentros.SelectedIndex = 0 Then
                frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
            Else
                frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
            End If

        Else
            If cboCentros.SelectedIndex = 0 Then
                frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
            Else
                frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
            End If
        End If

        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmCambioDeCategoriasIngreso"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub
    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        Dim TotDiios As Integer
        Cursor.Current = Cursors.WaitCursor
        lvGanado.Items.Clear()



        pnlProcesa.Visible = True
        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","

            Dim item As New ListViewItem((i + 1).ToString)    'nro

            item.SubItems.Add(diio_)
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")

            If VerificaDIIOEnGrilla(-1, diio_) = True Then
                item.SubItems.Add("ERR / REPETIDO")
            Else
                item.SubItems.Add("ERR / NO EXISTE EN BD")
            End If

            lvGanado.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If


        TotDiios = BuscarDiiosBaston(strdiios_)


        ContabilizaYValidaDIIOs()
        pnlProcesa.Visible = False

        cboCategoriaDes.Enabled = False
        cboCategoriaOri.Enabled = False
        cboCentros.Enabled = False
        Fechafin.Enabled = False
        Fechaini.Enabled = False
        btnBuscar.Enabled = False

        Cursor.Current = Cursors.Default
    End Sub
    Public Sub ContabilizaYValidaDIIOs()
        Dim i As Integer = 0
        'Dim totsec_ As Integer = 0
        Dim err_ As Integer = 0
        Dim estado_ As String = ""

        For i = 0 To lvGanado.Items.Count - 1
            lvGanado.Items(i).Text = (i + 1).ToString.Trim
            estado_ = lvGanado.Items(i).SubItems(5).Text.Trim

            If Mid(estado_, 1, 3) = "ERR" Then
                err_ += 1
            End If
        Next


        lblErrores.Text = err_.ToString.Trim

        If lvGanado.Items.Count = 0 Then Exit Sub

        If err_ = 0 Then
            btnFinalizar.Enabled = True
            Button2.Enabled = True
            'btnPrevisualizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
            Button2.Enabled = True
            'btnPrevisualizar.Enabled = False
        End If
    End Sub
    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvGanado.Items.Count - 1
            If i <> pos_ Then
                If lvGanado.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function

    Private Function BuscarDiiosBaston(ByVal diios_ As String) As Integer
        BuscarDiiosBaston = 0
        Dim numDiios As Integer = 0
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ListadoBaston", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        'Dim diios_ As String = ""
        'diios_ = GeneraStringDIIOs()
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvGanado.BeginUpdate()
        'lvDIIOS.Items.Clear()
        'Label85.Text = "0"

        Dim i As Integer = 0
        Dim x As Integer = 0
        Dim vret As Integer = 0
        Dim diio_ As String = ""
        Dim est_ As String
        'Dim existe_ As Boolean
        pbProcesa.Maximum = lvGanado.Items.Count

        pnlProcesa.Refresh()

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()





                    diio_ = rdr("GndCod").ToString.Trim

                    For i = 0 To lvGanado.Items.Count - 1
                        If lvGanado.Items(i).SubItems(1).Text.Trim = diio_ Then
                            lvGanado.Items(i).SubItems(2).Text = rdr("GndProNom").ToString.Trim
                            lvGanado.Items(i).SubItems(3).Text = rdr("CenDesCor").ToString.Trim
                            If TipoCambio = "Vacas" Then
                                lvGanado.Items(i).SubItems(4).Text = rdr("GndUltFechaParto").ToString.Trim
                            Else
                                lvGanado.Items(i).SubItems(4).Text = rdr("GndFecNac").ToString.Trim
                            End If


                            If VerificaDIIOEnGrilla(i, diio_) = True Then
                                lvGanado.Items(i).SubItems(5).Text = "ERR / REPETIDO"
                                lblErrores.Text = Int32.Parse(lblErrores.Text) + 1
                            Else
                                est_ = ""

                                If cboCentros.Text = "--Todos--" Then

                                Else
                                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                                        est_ = "ERR / CENTRO (" + rdr("CenDesCor").ToString.Trim + ")"
                                    End If
                                End If



                                If rdr("GndIsVendido").ToString.Trim = "SI" Then
                                    est_ = "ERR / VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy")
                                End If

                                If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                                    est_ = "ERR / MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy")
                                End If

                                If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                                    est_ = "ERR / DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy")
                                End If
                                If TipoCambio = "Vacas" Then
                                    If rdr("GndProCod").ToString.Trim <> General.CategoriasVacas.Codigo(cboCategoriaOri.SelectedIndex - 1) Then
                                        est_ = "ERR / CATEGORIA (" + rdr("GndProNom").ToString.Trim + ")"
                                    End If
                                Else

                                    Dim cat As String = rdr("GndProCod").ToString
                                    Dim cat1 As String = General.CategoriasFecha.Codigo(cboCategoriaOri.SelectedIndex - 1)

                                    If rdr("GndProCod").ToString.Trim <> General.CategoriasFecha.Codigo(cboCategoriaOri.SelectedIndex - 1) Then
                                        est_ = "ERR / CATEGORIA (" + rdr("GndProNom").ToString.Trim + ")"
                                    End If
                                End If




                                If est_ <> "" Then lblErrores.Text = Int32.Parse(lblErrores.Text) + 1

                                lvGanado.Items(i).SubItems(5).Text = est_
                            End If

                            If lvGanado.Items(i).SubItems(5).Text.Contains("ERR") Then
                                lvGanado.Items(i).BackColor = Color.Red
                            End If
                            numDiios = numDiios + 1
                            pbProcesa.Value = x
                            x = x + 1
                        End If

                    Next

                    'i = i + 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        BuscarDiiosBaston = i

        lblTotDiios.Text = numDiios
        lvGanado.EndUpdate()
    End Function
    Private Sub btnBastonLee_Click(sender As Object, e As EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales() = False Then Exit Sub

        LeeBaston()

        If lvGanado.Items.Count > 0 Then cboCentros.Enabled = False


        btnFinalizar.Enabled = Enabled
    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub Ayuda_Click(sender As Object, e As EventArgs) Handles Ayuda.Click
        With Manuales
            .PDFManual = PDFManual
            .ShowDialog()
        End With
    End Sub
End Class