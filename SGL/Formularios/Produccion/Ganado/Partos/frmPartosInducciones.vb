Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmPartosInducciones
    Private categoriadiio As String
    Private EstadoDiio As String
    Private Vacuna As String
    Private ArchivoImportacion As String
    Private frInducciones As New frInducciones
    Private fnInduccionesGrabar As New fnInduccionesGrabar
    Private NombreArchivo As String
    Private Diioexcel As String
    Private Razaexcel As String
    Private centrodiio As String
    Private CodigoDIIO As String

    Private Sub frmPartosInducciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
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

    Private Sub Consultar_Click(sender As Object, e As EventArgs) Handles Consultar.Click
        CodigoDIIO = txtDIIO.Text

        ConsultaDIIO()


        If lblSala.Text <> "---- REGISTRO NO EXISTE ----" And lblSala.Text <> "" Then
            btnGrabar.Enabled = True
        Else
            btnGrabar.Enabled = False
        End If
    End Sub
    Private Sub Fecha_ValueChanged(sender As Object, e As EventArgs) Handles Fecha.ValueChanged
        If lvGanado.Items.Count <> 0 Then
            If MsgBox("PARA CAMBIAR DE FECHA ANTES BORRAR DATOS YA INGRESADOS", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If lblEstReproductivo.Text <> "PREÑADA" Then
            If MsgBox("Diio con estado productivo diferente a 'PREÑADA' ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
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
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        If cboCentros.SelectedIndex <> 0 Then
            btnGrabar.Enabled = True
        Else
            btnGrabar.Enabled = False
        End If
    End Sub

    'Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click
    '    Dim n As Integer
    '    Dim var As Boolean = False
    '    If cboCentros.Text = "--Elegir Centro--" Then
    '        If MsgBox("Debe seleccionar un centro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
    '            Exit Sub
    '        End If
    '    End If
    '    OpenFDlg.FileName = ""
    '    OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
    '    OpenFDlg.ShowDialog()
    '    If OpenFDlg.FileName.Trim() <> "" Then
    '        ArchivoImportacion = OpenFDlg.FileName.Trim
    '        NombreArchivo = OpenFDlg.SafeFileName.Trim
    '        txtArchivo.Text = NombreArchivo

    '    End If
    '    Datosexcel()
    '    n = lvGanado.Items.Count.ToString
    '    For i = 0 To n - 1
    '        If lvGanado.Items(i).SubItems(1).Text.Trim = "No Pertenece al centro indicado" Then
    '            lvGanado.Items(i).BackColor = Color.Red
    '        End If
    '    Next
    'End Sub
    'Private Sub Datosexcel()
    '    Dim lin As Integer
    '    Cursor.Current = Cursors.WaitCursor
    '    Try
    '        Dim Procesa As Boolean
    '        Dim AppExcel As New Application
    '        Dim Libro As Workbook
    '        Dim Hoja As Worksheet
    '        Dim n As Integer
    '        Libro = AppExcel.Workbooks.Open(ArchivoImportacion)
    '        Hoja = Libro.Worksheets(1)
    '        lin = 1
    '        Procesa = True
    '        frInducciones.DtExcelCrear()
    '        Do While Procesa
    '            If Trim(Hoja.Cells(lin, 1).value) = "" Then
    '                ConsultaListadoExcel()
    '                Exit Do
    '            End If
    '            Diioexcel = Hoja.Cells(lin, 1).value
    '            frInducciones.DtExcel(Diioexcel)
    '            lin = lin + 1
    '        Loop
    '        Hoja = Nothing      'Descargamos los Objetos...
    '        Libro.Close()
    '        AppExcel.Quit()
    '        frInducciones.VaciaDatatable()
    '        Dim num As Integer
    '        num = lvGanado.Items.Count.ToString
    '        For i = 0 To num - 1
    '            If lvGanado.Items(i).SubItems(5).Text.Trim <> "PREÑADA" Or lvGanado.Items(i).SubItems(1).Text.Contains("Pertenece") Or lvGanado.Items(i).SubItems(1).Text.Trim = "Sin Sala" Or lvGanado.Items(i).SubItems(6).Text.Trim <> "Vivo" Or lvGanado.Items(i).SubItems(7).Text.Trim <> "" Or lvGanado.Items(i).SubItems(2).Text.Trim = "DIIO No Existe" Then
    '                lvGanado.Items(i).BackColor = Color.Red
    '            End If
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    '    Cursor.Current = Cursors.Default
    'End Sub
    Public Sub ConsultaListadoExcel()
        Dim numDiios As Integer = 0
        Dim Centro As String
        Dim Categoria As String
        Dim Estado As String
        Dim diio As String
        Dim EstProductivo As String
        Dim EstReProductivo As String
        Dim CodCentro As String
        Dim CodCategoria As String
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPartos_ListadoExcel", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.AddWithValue("@TablaDetalle", frInducciones.DetallesExcel)
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
                    ElseIf rdr("reproductivo").ToString.Trim <> "PREÑADA" Then
                        itm.SubItems.Add("Estado reproductivo diferente a 'PREÑADA'")
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnBastonLee_Click(sender As Object, e As EventArgs) Handles btnBastonLee.Click

        If cboCentros.Text = "--Elegir Centro--" Then
            If MsgBox("Debe seleccionar un centro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        LeeBaston()

    End Sub
    Private Sub LeeBaston()

        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmPartosInducciones"
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
        frInducciones.DtExcelCrear()
        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","
            frInducciones.DtExcel(diio_)
        Next
        ConsultaListadoExcel()
        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If

        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = 0 To num - 1
            If lvGanado.Items(i).SubItems(5).Text.Trim <> "PREÑADA" Or lvGanado.Items(i).SubItems(1).Text.Contains("Pertenece") Or lvGanado.Items(i).SubItems(1).Text.Trim = "Sin Sala" Or lvGanado.Items(i).SubItems(6).Text.Trim <> "Vivo" Or lvGanado.Items(i).SubItems(7).Text.Trim <> "" Or lvGanado.Items(i).SubItems(2).Text.Trim = "DIIO No Existe" Then
                lvGanado.Items(i).BackColor = Color.Red
                numErrores = numErrores + 1
            End If
        Next
        lblErrores.Text = numErrores
        frInducciones.VaciaDatatable()
        Cursor.Current = Cursors.Default
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
        If MsgBox("¿ DESEA GRABAR LAS INDUCCIONES ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If lvGanado.Items.Count = 0 Then
            If MsgBox("NESESITA INGRESAR DATOS EN LA TABLA PARA PODER FINALIZAR", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        If GrabarInducciones() Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                Me.Close()
                frmInducciones.btnBuscar.PerformClick()
            End If
        End If
    End Sub
    Private Function GrabarInducciones() As Boolean
        Dim centro As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Dim numeroVacunas As Integer = lvGanado.Items.Count
        If fnInduccionesGrabar.Grabar(lvGanado, centro, Fecha.Value) Then
            Return True
        Else
            Return False
        End If
    End Function

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
End Class