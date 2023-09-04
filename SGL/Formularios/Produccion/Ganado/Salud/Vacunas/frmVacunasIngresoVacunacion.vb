Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmVacunasIngresoVacunacion
    Private categoriadiio As String
    Private EstadoDiio As String
    Private Vacuna As String
    Private ArchivoImportacion As String
    Private fnVacunados As New fnVacunados
    Dim fnvacuna As New fnVacuna
    Private NombreArchivo As String
    Private Diioexcel As String
    Private Razaexcel As String
    Private centrodiio As String
    Private CodigoDIIO As String

    Private Sub frmVacunasIngresoVacunacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()

    End Sub

    Public Sub BuscarVacunas()
        Dim cent As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            lvArticulos.Items.Clear()
            Try
                Dim stock As Integer


                While rdr.Read()
                    i = i + 1
                    stock = rdr("Stock") - rdr("loc")
                    Dim lvitem As New ListViewItem("")    'primera columna, para ordenar los datos
                    lvitem.Checked = False
                    lvitem.SubItems.Add(rdr("codigo").ToString)
                    lvitem.SubItems.Add(rdr("nombre").trim.ToString)
                    lvitem.SubItems.Add(stock)
                    lvitem.SubItems.Add(rdr("LOCNCODE").trim.ToString)
                    lvitem.SubItems.Add(rdr("ItemGasto").ToString)
                    lvitem.SubItems.Add(rdr("ProductoCuenta").ToString)
                    lvArticulos.Items.Add(lvitem)
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
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("--Elegir Centro--")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next


        cboCentros.SelectedIndex = 0
    End Sub
    Private Function ConsultadiioVacuna(ByVal vac As String, ByVal diio As String) As Boolean
        ConsultadiioVacuna = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_ConsultaDiio", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", diio)
        cmd.Parameters.AddWithValue("@Feca", Fecha.Value)
        cmd.Parameters.AddWithValue("@Vac", vac)
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

            If vret <> 0 Then
                Cursor.Current = Cursors.Default
                Dim num As Integer
                num = lvGanado.Items.Count.ToString
                For i = 0 To num - 1
                    If lvGanado.Items(i).SubItems(2).Text.Trim = diio Then
                        lvGanado.Items(i).BackColor = Color.Red
                        lvGanado.Items(i).SubItems(7).Text = mret
                    End If
                Next
            End If
            ConsultadiioVacuna = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        Cursor.Current = Cursors.Default
    End Function
    Public Sub ConsultaDIIO()
        If CodigoDIIO.Trim = "" Then Exit Sub
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then ' Label15.Text Then
                        If MsgBox("EL DIIO NO PERTENECE AL CENTRO SELECCIONADO (" + rdr("CenDesCor").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("CenDesCor").ToString.Trim = "" Then
                        lblSala.Text = "--- SIN SALA ----"
                        lblSala.ForeColor = Color.Red
                    Else
                        lblSala.Text = rdr("CenDesCor").ToString.Trim
                        lblSala.ForeColor = SystemColors.ControlText
                    End If
                    categoriadiio = rdr("GndProCod").ToString.Trim
                    centrodiio = rdr("GndCenCod").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    '
                    lblSexo.Text = rdr("GndSexo").ToString.Trim
                    lblRaza.Text = rdr("RazaNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim       '
                    If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        lblEstado.Text = "DESAPARECIDO"
                        lblEstado.ForeColor = Color.Red
                    ElseIf rdr("GndIsVendido").ToString.Trim = "SI" Then
                        lblEstado.Text = "VENDIDO"
                        lblEstado.ForeColor = Color.Red
                    ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        lblEstado.Text = "MUERTO"
                        lblEstado.ForeColor = Color.Red
                    Else
                        lblEstado.Text = "STOCK"
                        lblEstado.ForeColor = Color.DarkBlue
                    End If
                    Existe = True
                    EstadoDiio = lblEstado.Text
                End While
                If Existe = True Then
                    lblSala.Cursor = Cursors.Default
                    If lblSala.Text <> "" Then lblSala.Cursor = Cursors.Hand
                Else
                    lblSala.Text = "---- REGISTRO NO EXISTE ----"
                    lblSala.ForeColor = Color.Red
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
    Private Sub LimpiaDatos()
        txtDIIO.Text = ""
        lblSala.Text = ""
        lblCategoria.Text = ""
        lblEstado.Text = ""
        lblSexo.Text = ""
        lblRaza.Text = ""
        lblFecNacimiento.Text = ""
        lblEstProductivo.Text = ""
        lblEstReproductivo.Text = ""
        lblSala.Text = ""
        lblCategoria.Text = ""
        lblEstado.Text = ""
        txtDIIO.Focus()
    End Sub

    Private Sub Consultar_Click(sender As Object, e As EventArgs) Handles Consultar.Click
        CodigoDIIO = txtDIIO.Text

        ConsultaDIIO()


        If lblSala.Text <> "---- REGISTRO NO EXISTE ----" And lblSala.Text <> "" Then
            btnGrabar.Enabled = True
        Else
            btnGrabar.Enabled = False
        End If
    End Sub
    Private Function ValidaChekVacuna() As Boolean
        ValidaChekVacuna = False
        Dim n As Integer
        n = lvArticulos.Items.Count.ToString
        Dim var As Boolean = False
        For i = 0 To n - 1
            If lvArticulos.Items(i).Checked = True Then
                var = True
            End If
        Next
        If var = False Then
            If MsgBox("Debe seleccionar al menos 1 vacuna", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                ValidaChekVacuna = False
                Exit Function
            End If
        End If
        ValidaChekVacuna = True
    End Function
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If ValidaChekVacuna() = False Then
            Exit Sub
        End If
        If lblEstado.Text <> "STOCK" Then
            If MsgBox("Diio no esta en Stock ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        If cboCentros.Text = "--Elegir Centro--" Then
            If MsgBox("Debe seleccionar un centro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        Dim variable As Boolean
        Dim n As Integer
        variable = True
        n = lvGanado.Items.Count.ToString
        For i = 0 To n - 1
            If txtDIIO.Text.Trim = lvGanado.Items(i).SubItems(2).Text.Trim Then
                variable = False
                If MsgBox("Diio ya ingresado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    LimpiaDatos()
                    Exit Sub
                End If
            End If
        Next
        If variable = True Then
            llenadoLv()
        End If
        Dim VacConsulta As String
        n = lvArticulos.Items.Count.ToString
        For i = 0 To n - 1
            If lvArticulos.Items(i).Checked = True Then
                VacConsulta = lvArticulos.Items(i).SubItems(1).Text.Trim()
                ConsultadiioVacuna(VacConsulta, txtDIIO.Text)
            End If
        Next
        BloqueoArticulos()
        LimpiaDatos()
    End Sub

    Private Sub llenadoLv()
        Dim totaldiios As Integer = lblTotDiios.Text
        Dim itm As New ListViewItem((lvGanado.Items.Count + 1).ToString)
        itm.SubItems.Add(lblSala.Text.Trim)
        itm.SubItems.Add(txtDIIO.Text.Trim)
        itm.SubItems.Add(lblCategoria.Text.Trim)
        itm.SubItems.Add(lblEstProductivo.Text.Trim)
        itm.SubItems.Add(lblEstReproductivo.Text.Trim)
        itm.SubItems.Add(EstadoDiio)
        itm.SubItems.Add("")
        itm.SubItems.Add(Fecha.Text)
        itm.SubItems.Add(centrodiio)
        itm.SubItems.Add(categoriadiio)
        lvGanado.Items.Add(itm)
        lblTotDiios.Text = totaldiios + 1
    End Sub

    Public Sub BloqueoArticulos()
        If lvGanado.Items.Count <> 0 Then
            lvArticulos.Enabled = False
            cboCentros.Enabled = False
            Fecha.Enabled = False
        Else
            lvArticulos.Enabled = True
            Fecha.Enabled = True
            cboCentros.Enabled = True
        End If
    End Sub

    Public Sub ConsultaListadoExcel()
        Dim Centro As String
        Dim numDiios As Integer = 0
        Dim Categoria As String
        Dim Estado As String
        Dim diio As String
        Dim EstProductivo As String
        Dim EstReProductivo As String
        Dim CodCentro As String
        Dim CodCategoria As String
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_ListadoExcel", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.AddWithValue("@TablaDetalle", fnVacunados.DetallesExcel)
        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()

                    diio = rdr("diio").ToString.Trim

                    If rdr("centro").ToString.Trim = "" Then
                        Centro = "Sin Sala"
                    Else
                        Centro = rdr("centro").ToString.Trim
                    End If

                    Categoria = rdr("categoria").ToString.Trim

                    EstProductivo = rdr("productivo").ToString.Trim
                    EstReProductivo = rdr("reproductivo").ToString.Trim

                    CodCentro = rdr("GndCenCod").ToString.Trim
                    CodCategoria = rdr("GndProCod").ToString.Trim

                    If rdr("desaparecido").ToString.Trim = "SI" Then
                        Estado = "Desaparecido"
                    ElseIf rdr("vendido").ToString.Trim = "SI" Then
                        Estado = "Vendido"
                    ElseIf rdr("muerto").ToString.Trim = "SI" Then
                        Estado = "Mmuerto"
                    Else
                        Estado = "Vivo"
                    End If

                    Dim itm As New ListViewItem((lvGanado.Items.Count + 1).ToString)

                    itm.SubItems.Add(Centro)
                    itm.SubItems.Add(diio)
                    itm.SubItems.Add(Categoria)
                    itm.SubItems.Add(EstProductivo)
                    itm.SubItems.Add(EstReProductivo)
                    itm.SubItems.Add(Estado)
                    If Centro <> cboCentros.Text Then
                        itm.SubItems.Add("No Pertenece, centro diio:" + Centro)
                    Else
                        itm.SubItems.Add("")
                    End If
                    itm.SubItems.Add(Fecha.Value)
                    itm.SubItems.Add(CodCentro)
                    itm.SubItems.Add(CodCategoria)
                    lvGanado.Items.Add(itm)
                    numDiios = numDiios + 1
                End While


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
        lvGanado.EndUpdate()
        lblTotDiios.Text = numDiios
    End Sub
    Private Function ConsultadiioVacunaTable(ByVal vac As String, ByVal lvGanado As ListView) As Boolean
        Dim fech As DateTime = Fecha.Value
        If fnVacunados.Grabar(lvGanado, fech, vac) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿ DESEA ELIMINAR TODOS LOS ERRORES SELECCIONADOS? ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        Dim totaldiios As Integer = lblTotDiios.Text
        For Each it As ListViewItem In lvGanado.SelectedItems
            lvGanado.Items.Remove(it)
            totaldiios = totaldiios - 1
        Next
        lblTotDiios.Text = totaldiios
        Dim numErrores As Integer = 0
        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = 0 To num - 1
            If lvGanado.Items(i).BackColor = Color.Red Then
                numErrores = numErrores + 1
            End If
        Next
        lblErrores.Text = numErrores

        BloqueoArticulos()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click

        If ValidaChekVacuna() = False Then
            Exit Sub
        End If
        Dim n As Integer
        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = 0 To num - 1
            If lvGanado.Items(i).BackColor = Color.Red Then
                If MsgBox("PARA GRABAR DATOS, ELIMINAR ERRORES", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
        Next
        If MsgBox("¿ DESEA GRABAR LA VACUNACION REALIZADA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        n = 0
        n = lvArticulos.Items.Count.ToString
        For i = 0 To n - 1
            If lvArticulos.Items(i).Checked = True Then
                Dim bodega = "", CodProd = "", NomProd = "", Cuenta = "", Stock = "", Medida = "", ItemGasto As String = ""
                CodProd = lvArticulos.Items(i).SubItems(1).Text.Trim()
                NomProd = lvArticulos.Items(i).SubItems(2).Text.Trim()
                Cuenta = lvArticulos.Items(i).SubItems(6).Text.Trim()
                ItemGasto = lvArticulos.Items(i).SubItems(5).Text.Trim()
                Vacuna = lvArticulos.Items(i).SubItems(1).Text.Trim()
                Stock = lvArticulos.Items(i).SubItems(3).Text.Trim()
                Medida = "UNIDAD"
                Vacunacion(0)
                '''''''''''''''''''''''''''''Bloqueado para no grabar en GP todavia '''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Next
        If lvGanado.Items.Count = 0 Then
            If MsgBox("NESESITA INGRESAR DATOS EN LA TABLA PARA PODER FINALIZAR", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            Me.Close()
            frmVacunas.btnBuscar.PerformClick()
        End If
    End Sub
    Public Sub Vacunacion(ByVal IdConsumoGp As String)
        Dim centro As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Dim fech As DateTime = Fecha.Value
        fnvacuna.Grabar(fech, centro, lvGanado, Vacuna, IdConsumoGp)
    End Sub

    Private Sub btnBastonLee_Click(sender As Object, e As EventArgs) Handles btnBastonLee.Click
        Dim n As Integer
        n = lvArticulos.Items.Count.ToString
        Dim var As Boolean = False
        For i = 0 To n - 1
            If lvArticulos.Items(i).Checked = True Then
                var = True
            End If
        Next
        If var = False Then
            If MsgBox("Debe seleccionar al menos 1 vacuna", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        If cboCentros.Text = "--Elegir Centro--" Then
            If MsgBox("Debe seleccionar un centro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        LeeBaston()
        BloqueoArticulos()
    End Sub
    Private Sub LeeBaston()

        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmVacunas"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub
    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim numErrores As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        Dim inichk_ As Integer = lvGanado.Items.Count '- 1

        Cursor.Current = Cursors.WaitCursor

        lvGanado.Items.Clear()
        fnVacunados.DtExcelCrear()
        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","
            fnVacunados.DtExcel(diio_)
        Next
        ConsultaListadoExcel()
        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If
        Dim VacConsulta As String
        Dim n As Integer
        n = lvArticulos.Items.Count.ToString
        For x = 0 To n - 1
            If lvArticulos.Items(x).Checked = True Then
                VacConsulta = lvArticulos.Items(x).SubItems(1).Text.Trim()
                ConsultadiioVacunaTable(VacConsulta, lvGanado)
            End If
        Next
        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = 0 To num - 1
            If lvGanado.Items(i).SubItems(1).Text.Contains("Pertenece") Or lvGanado.Items(i).SubItems(1).Text.Trim = "Sin Sala" Or lvGanado.Items(i).SubItems(6).Text.Trim <> "Vivo" Or lvGanado.Items(i).SubItems(7).Text.Trim <> "" Or lvGanado.Items(i).SubItems(2).Text.Trim = "DIIO No Existe" Then
                lvGanado.Items(i).BackColor = Color.Red
                numErrores = numErrores + 1
            End If
        Next
        lblErrores.Text = numErrores
        fnVacunados.VaciaDatatable()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        If lvGanado.Items.Count <> 0 Then
            If MsgBox("Se grabara la informacion solo con el ultimo centro ingresado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
        End If
        If cboCentros.SelectedIndex <> 0 Then
            BuscarVacunas()
        End If
    End Sub
    Private Sub txtDIIO_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            CodigoDIIO = txtDIIO.Text
            ConsultaDIIO()
            If lblSala.Text <> "---- REGISTRO NO EXISTE ----" And lblSala.Text <> "" Then
                btnGrabar.Enabled = True
            Else
                btnGrabar.Enabled = False
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub Fecha_ValueChanged(sender As Object, e As EventArgs) Handles Fecha.ValueChanged
        If lvGanado.Items.Count <> 0 Then
            If MsgBox("PARA CAMBIAR DE FECHA ANTES BORRAR DATOS YA INGRESADOS", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
    End Sub
    Private Sub lvGanado_KeyDown(sender As Object, e As KeyEventArgs) Handles lvGanado.KeyDown
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub
        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(2).Text
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If

        End If
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
    End Sub

    Private Sub lvGanado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvGanado.SelectedIndexChanged

    End Sub
End Class