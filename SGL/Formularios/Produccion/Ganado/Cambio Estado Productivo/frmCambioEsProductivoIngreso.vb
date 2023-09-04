
Imports Microsoft.Office.Interop.Excel

Imports System.Data.SqlClient



Public Class frmCambioEsProductivoIngreso

    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Public Param0_ModoIngreso As Integer        '
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_CodigoVeterinario As Integer
    Public Param4_NombreVeterinario As String
    Public ArchivoImportacion As String
    Public NombreArchivo As String
    Public TRegistro As Integer = 0
    Public EstReproActual As String
    Public Diioexcel As String
    Public Prductexcel As String
    Public CausaDesechoexcel As String

    Private Sub LimpiaDatos(Optional ByVal LimpiaDIIO As Boolean = False)
        If LimpiaDIIO = True Then
            txtDIIO.Text = ""
        End If
        lblCentro.Text = "---"
        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        lblFecUltParto.Text = "---"
        lblFecProbParto.Text = "---"
        lblNroCubiertas.Text = "---"
        cboEstProductivos.SelectedIndex = -1
        cboTipoDesechos.SelectedIndex = -1
        cboEstProductivos.Enabled = False
        cboTipoDesechos.Enabled = False
    End Sub

    Private Sub lvGanado_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvGanado.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvGanado, e)
    End Sub


    Private Sub CboLLenaEstadosProductivos()
        If General.EstProductivos.NroRegistros = 0 Then Exit Sub
        cboEstProductivos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.EstProductivos.NroRegistros - 1
            If General.EstProductivos.Nombre(i) <> "NO APLICA" Then
                cboEstProductivos.Items.Add(General.EstProductivos.Nombre(i))
            End If

        Next
    End Sub
    Private Sub CboLLenaTipoDesechos()
        If General.TipoDesechos.NroRegistros = 0 Then Exit Sub
        cboTipoDesechos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoDesechos.NroRegistros - 1
            cboTipoDesechos.Items.Add(General.TipoDesechos.Nombre(i))
        Next
    End Sub
    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim fpart_, fcub_, fpp_ As String
        Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fpart_ = ""
        fcub_ = ""
        fpp_ = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            LimpiaDatos()
            Try
                While rdr.Read()
                    If IsDate(rdr("GndUltFechaParto")) Then
                        fpart_ = Format(rdr("GndUltFechaParto"), "dd-MM-yyyy")
                        If fpart_ = "01-01-1753" Then fpart_ = ""
                    End If

                    fc_ = rdr("GndUltCubierta")
                    If IsDate(rdr("GndUltCubierta")) Then fcub_ = Format(rdr("GndUltCubierta"), "dd-MM-yyyy")


                    If IsDate(rdr("GndUltFechaPP")) Then
                        fpp_ = Format(rdr("GndUltFechaPP"), "dd-MM-yyyy")
                        If fpp_ = "31-12-3000" Then fpp_ = ""
                    End If
                    lblCentro.Text = rdr("CenDesCor").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim

                    EstReproActual = rdr("CodEstProd").ToString.Trim

                    lblFecUltParto.Text = fpart_
                    lblFecProbParto.Text = fpp_
                    lblNroCubiertas.Text = rdr("GndUltCubiertaNum").ToString.Trim
                    'lblFecUltCubierta.Text = "---"

                    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                        lblEstado.Text = "VENDIDO"
                    ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        lblEstado.Text = "MUERTO"
                    ElseIf rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        lblEstado.Text = "DESAPARECIDO"
                    Else
                        lblEstado.Text = "STOCK"
                    End If
                    Existe = True
                End While
                If Existe = True Then
                    Dim diff As Integer = 0
                    cboEstProductivos.Text = lblEstProductivo.Text
                    cboEstProductivos.Enabled = True
                Else
                    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub cboEstProductivos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEstProductivos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If cboTipoDesechos.Enabled = True Then
                cboTipoDesechos.Focus()
            End If
        End If
    End Sub

    Private Sub cboEstProductivos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstProductivos.SelectedIndexChanged
        If cboEstProductivos.SelectedIndex = -1 Then Exit Sub
        Dim vercausas_ As String
        vercausas_ = General.EstProductivos.Causa(Array.IndexOf(General.EstProductivos.Nombre, cboEstProductivos.Text))
        If vercausas_ = "S" Then
            cboTipoDesechos.Enabled = True
            btnGrabar.Enabled = False
        Else
            cboTipoDesechos.SelectedIndex = -1
            cboTipoDesechos.Enabled = False
            btnGrabar.Enabled = True
        End If

    End Sub
    'ELIMINADA DE LECHE
    'DESECHO
    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cerrar()
    End Sub

    Private Sub txtDIIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
        End If
    End Sub

    Private Sub frmCambioEsProductivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.TipoDesechos.Cargar()
        General.EstProductivos.Cargar()
        Fecha.Value = DateTime.Now

        CboLLenaEstadosProductivos()
        CboLLenaTipoDesechos()
        BuscaEstados()
        BuscaCausas()

    End Sub
    Public Sub BuscaEstados()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spEstProductivos_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim itm As New ListViewItem()
                    itm.SubItems.Add(rdr("CodEstProd").ToString.Trim)
                    itm.SubItems.Add(rdr("DesEstProd").ToString.Trim)
                    lvEstado.Items.Add(itm)
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub
    Public Sub BuscaCausas()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTipoDesechos_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim itm As New ListViewItem()
                    itm.SubItems.Add(rdr("coddesch").ToString.Trim)
                    itm.SubItems.Add(rdr("Nomdesch").ToString.Trim)
                    lvCausas.Items.Add(itm)
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim variable As Boolean
        Dim n As Integer
        variable = True
        n = lvGanado.Items.Count.ToString
        For i = 0 To n - 1
            If txtDIIO.Text.Trim = lvGanado.Items(i).SubItems(1).Text.Trim Then
                variable = False
                If MsgBox("Diio ya ingresado", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    Exit Sub
                End If
            End If
        Next
        If cboEstProductivos.Text = lblEstProductivo.Text Then
            variable = False
            If MsgBox("Seleccionar un estado productivo diferente", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                Exit Sub
            End If
        End If
        If lblEstado.Text <> "STOCK" Then
            variable = False
            If MsgBox("Animal no se encuentra en stock", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                Exit Sub
            End If
        End If
        If variable = True Then
            AgregarCampo()
            btnFinalizar.Enabled = True
        End If
    End Sub
    Private Sub AgregarCampo()

        Dim itm As New ListViewItem((lvGanado.Items.Count + 1).ToString)
        itm.SubItems.Add(txtDIIO.Text.Trim)
        itm.SubItems.Add(lblCentro.Text.Trim)
        itm.SubItems.Add(lblEstProductivo.Text.Trim)
        itm.SubItems.Add(General.EstProductivos.Nombre(cboEstProductivos.SelectedIndex))

        If cboTipoDesechos.SelectedIndex = -1 Then
            itm.SubItems.Add("")
        Else
            itm.SubItems.Add(General.TipoDesechos.Nombre(cboTipoDesechos.SelectedIndex))
        End If
        itm.SubItems.Add(lblCategoria.Text.Trim)

        itm.SubItems.Add(lblEstado.Text)
        itm.SubItems.Add(Fecha.Text)

        itm.SubItems.Add(General.EstProductivos.Codigo(cboEstProductivos.SelectedIndex))
        If cboTipoDesechos.SelectedIndex = -1 Then
            itm.SubItems.Add("0")
        Else
            itm.SubItems.Add(General.TipoDesechos.Codigo(cboTipoDesechos.SelectedIndex))
        End If

        lvGanado.Items.Add(itm)
    End Sub

    Private Sub btnBuscar_Click_1(sender As Object, e As EventArgs) Handles btnBuscar.Click
        TRegistro = 0

        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
        If lblCategoria.Text.Contains("VACAS") Then
            btnGrabar.Enabled = True
            cboEstProductivos.Enabled = True

            If cboEstProductivos.Text = "ELIMINADA DE LECHE" Or cboEstProductivos.Text = "DESECHO" Then
                btnGrabar.Enabled = False
            Else
                btnGrabar.Enabled = True
            End If
        Else
            If MsgBox("DIIO ingresado no valido", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            btnGrabar.Enabled = False
            cboEstProductivos.Enabled = False
            cboTipoDesechos.Enabled = False
        End If
    End Sub

    Private Sub cboTipoDesechos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDesechos.SelectedIndexChanged
        btnGrabar.Enabled = True
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        For Each it As ListViewItem In lvGanado.SelectedItems
            lvGanado.Items.Remove(it)
        Next
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = 0 To num - 1
            If lvGanado.Items(i).BackColor = Color.Red Then
                If MsgBox("PARA GRABAR DATOS, ELIMINAR ERRORES", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
        Next
        If MsgBox("¿ DESEA GRABAR EL CAMBIO DE ESTADO PRODUCTIVO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        GrabarEstados()


        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            Me.Close()
            frmCambioEsProductivo.btnBuscar.PerformClick()
        End If
    End Sub

    Private Sub GrabarEstados()
        Dim i As Integer = 0
        Dim n As Integer = 0
        n = lvGanado.Items.Count.ToString
        For i = 0 To n - 1
            Cursor.Current = Cursors.WaitCursor

            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spCambiosEstProductivo_Grabar", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Diio", lvGanado.Items(i).SubItems(1).Text.Trim)
            cmd.Parameters.AddWithValue("@EstReprodNuevoCod", lvGanado.Items(i).SubItems(9).Text.Trim)
            cmd.Parameters.AddWithValue("@CausaDesecho", lvGanado.Items(i).SubItems(10).Text.Trim)
            cmd.Parameters.AddWithValue("@Fecha", Fecha.Value)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            '
            cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

            Try
                con.Open()

                Dim Result As Integer = cmd.ExecuteNonQuery()

                Dim vret As Integer = cmd.Parameters("@RetValor").Value
                Dim mret As String = cmd.Parameters("@RetMensage").Value

                ''verificamos error con un valor igual a -1
                If vret = -1 Then
                    Cursor.Current = Cursors.Default

                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                Exit For
            Finally
                con.Close()
            End Try

            ''End If
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click
        TRegistro = 1
        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()
        If OpenFDlg.FileName.Trim() <> "" Then
            ArchivoImportacion = OpenFDlg.FileName.Trim
            NombreArchivo = OpenFDlg.SafeFileName.Trim
            txtArchivo.Text = NombreArchivo

        End If
        btnFinalizar.Enabled = True
        btnBuscar.Enabled = False
        btnGrabar.Enabled = False
        Datosexcel()
    End Sub
    Private Sub Datosexcel()
        Dim lin As Integer

        Cursor.Current = Cursors.WaitCursor

        Try
            Dim Procesa As Boolean
            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet
            Dim n As Integer
            Libro = AppExcel.Workbooks.Open(ArchivoImportacion)
            Hoja = Libro.Worksheets(1)
            lin = 1
            Procesa = True

            Do While Procesa
                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    Exit Do
                End If

                Diioexcel = Hoja.Cells(lin, 1).value
                Prductexcel = Hoja.Cells(lin, 2).value
                CausaDesechoexcel = Hoja.Cells(lin, 3).value

                n = lvGanado.Items.Count.ToString
                For i = 0 To n - 1
                    If Diioexcel = lvGanado.Items(i).SubItems(1).Text.Trim Then
                        lvGanado.Items(i).BackColor = Color.Red
                        lvGanado.Items(i).SubItems(7).Text = "Diio Repetido"
                    End If
                Next
                ConsultaDIIOPorExel(Diioexcel, Prductexcel, CausaDesechoexcel)

                'GrabarEstadosExcel()
                lin = lin + 1
            Loop
            Hoja = Nothing      'Descargamos los Objetos...
            Libro.Close()
            AppExcel.Quit()

            Dim num As Integer
            num = lvGanado.Items.Count.ToString
            For i = 0 To num - 1
                Dim cat As String = lvGanado.Items(i).SubItems(6).Text.Trim
                If cat = "VACAS TRASPASO" Then
                    cat = "VACAS"
                End If
                If lvGanado.Items(i).SubItems(4).Text.Trim = "Falta est. Productivo" Or lvGanado.Items(i).SubItems(4).Text.Trim = "Falta Tipo Desecho" Or lvGanado.Items(i).SubItems(2).Text.Trim = "Sin Sala" Or cat <> "VACAS" Or lvGanado.Items(i).SubItems(7).Text.Trim <> "Vivo" Or lvGanado.Items(i).SubItems(1).Text.Trim = "DIIO No Existe" Or lvGanado.Items(i).SubItems(3).Text.Trim = lvGanado.Items(i).SubItems(4).Text.Trim Then
                    lvGanado.Items(i).BackColor = Color.Red
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor.Current = Cursors.Default
    End Sub
    Public Sub ConsultaDIIOPorExel(ByVal Diioexcel As Integer, ByVal Prductexcel As String, ByVal CausaDesechoexcel As String)
        Dim Centro As String = ""
        Dim Estado As String = ""
        Dim Categoria As String = ""
        Dim Diio As String = Diioexcel
        Dim EstProducActual As String = ""
        Dim EstProducnueva As String = ""
        Dim Causa As String = ""
        Dim num As Integer
        num = lvEstado.Items.Count.ToString
        For i = 0 To num - 1
            If lvEstado.Items(i).SubItems(1).Text.Trim = Prductexcel Then
                EstProducnueva = lvEstado.Items(i).SubItems(2).Text.Trim
            End If
        Next
        Dim numc As Integer
        numc = lvCausas.Items.Count.ToString
        For i = 0 To num - 1
            If lvCausas.Items(i).SubItems(1).Text.Trim = CausaDesechoexcel Then
                Causa = lvCausas.Items(i).SubItems(2).Text.Trim
            End If
        Next
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", Diioexcel)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            LimpiaDatos()
            Try
                While rdr.Read()
                    If rdr("CenDesCor").ToString.Trim = "" Then
                        Centro = "Sin Sala"
                    Else
                        Centro = rdr("CenDesCor").ToString.Trim
                    End If
                    Categoria = rdr("GndProNom").ToString.Trim
                    EstProducActual = rdr("GndEstadoProductivo").ToString.Trim
                    If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        Estado = "Desaparecido"
                    ElseIf rdr("GndIsVendido").ToString.Trim = "SI" Then
                        Estado = "Vendido"
                    ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        Estado = "Mmuerto"
                    Else
                        Estado = "Vivo"
                    End If
                    Existe = True
                End While
                If Existe = True Then
                Else
                    Diio = "DIIO No Existe"
                End If

                Dim itm As New ListViewItem((lvGanado.Items.Count + 1).ToString)
                itm.SubItems.Add(Diio)
                itm.SubItems.Add(Centro)
                itm.SubItems.Add(EstProducActual)
                If Prductexcel = "" Or 0 Then
                    itm.SubItems.Add("Falta est. Productivo")
                Else
                    itm.SubItems.Add(EstProducnueva)
                End If

                If Prductexcel = "3" Or Prductexcel = "4" Then
                    If CausaDesechoexcel = "" Or "0" Then
                        itm.SubItems.Add("Falta Tipo Desecho")
                    Else
                        itm.SubItems.Add(Causa)
                    End If
                Else
                    itm.SubItems.Add("")
                End If

                itm.SubItems.Add(Categoria)
                itm.SubItems.Add(Estado)
                itm.SubItems.Add(Fecha.Text)
                itm.SubItems.Add(Prductexcel)
                itm.SubItems.Add(CausaDesechoexcel)
                lvGanado.Items.Add(itm)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class