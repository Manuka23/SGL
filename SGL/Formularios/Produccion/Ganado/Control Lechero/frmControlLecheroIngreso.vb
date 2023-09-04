Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmControlLecheroIngreso
    Private ArchivoImportacion As String
    Private NombreArchivo As String
    Private TRegistro As Integer = 0
    Private Diioexcel As String
    Private ValorRCS As Integer
    Private ValorProd As Integer
    Private cent_cod As String
    Private cent_nom As String
    Private Valor As String
    Private CantRcs As String
    Private CantProd As String
    Private TipoCon As String
    Dim fnControlLech As New fnControlLechero
    Private centro As String
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Dim Tipo As Integer


    Private Sub lvGanado_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvGanado.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvGanado, e)
    End Sub
    Private Sub Datosexcel()
        Dim lin As Integer
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim Procesa As Boolean
            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet
            cent_cod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
            cent_nom = General.CentrosUsuario.Nombre(cboCentros.SelectedIndex - 1)
            TipoCon = General.TiposControlLechero.Codigo(cboExcel.SelectedIndex - 1)

            Libro = AppExcel.Workbooks.Open(ArchivoImportacion)
            Hoja = Libro.Worksheets(1)
            lin = 1
            Procesa = True

            Do While Procesa
                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    Exit Do
                End If
                Diioexcel = Hoja.Cells(lin, 1).value
                Valor = Hoja.Cells(lin, 2).value
                lin = lin + 1
                llenadoLvExcel()
            Loop
            fnControlLech.Validar(cent_cod, TipoCon, lvDetalle)
            Hoja = Nothing      'Descargamos los Objetos...
            Libro.Close()
            AppExcel.Quit()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub llenadoLvExcel()

        Dim itm As New ListViewItem((lvDetalle.Items.Count + 1).ToString)
        itm.SubItems.Add(Diioexcel.Trim)
        itm.SubItems.Add(Valor.Trim)

        lvDetalle.Items.Add(itm)

    End Sub
    Private Sub frmControlLechero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaTiposCTL()
        CboLLenaTiposCTL2()
        CboLLenaCentros()
        cboCentros.SelectedIndex = 0
        cboTipos.SelectedIndex = 0
        cboExcel.SelectedIndex = 0
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()
        cboCentros.Items.Add("--Todos--")
        Dim i As Integer
        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub
    Private Sub CboLLenaTiposCTL()
        If General.TiposControlLechero.NroRegistros = 0 Then Exit Sub

        cboTipos.Items.Clear()
        cboTipos.Items.Add("--Todos--")

        Dim i As Integer

        For i = 0 To General.TiposControlLechero.NroRegistros - 1
            cboTipos.Items.Add(General.TiposControlLechero.Nombre(i))
        Next
        'cboCentros.SelectedIndex = -1
    End Sub
    Private Sub CboLLenaTiposCTL2()
        If General.TiposControlLechero.NroRegistros = 0 Then Exit Sub

        cboExcel.Items.Clear()
        cboExcel.Items.Add("--Todos--")

        Dim i As Integer

        For i = 0 To General.TiposControlLechero.NroRegistros - 1
            cboExcel.Items.Add(General.TiposControlLechero.Nombre(i))
        Next
        'cboCentros.SelectedIndex = -1
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        TRegistro = 0

        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
        If lblCategoria.Text = "VACAS" Then
            cboTipos.Enabled = True
            CantRcs = ""
            CantProd = ""
            cboExcel.Enabled = False
            btnArchivo.Enabled = False
        Else
            MsgBox("DIIO ingresado no valido", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACIÓN")
            cboTipos.Enabled = False
            Cantidades.Enabled = False
            btnGrabar.Enabled = False
        End If
    End Sub
    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
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

            LimpiaDatos()

            Try
                While rdr.Read()

                    centro = rdr("GndCenCod").ToString.Trim
                    lblCentro.Text = rdr("CenDesCor").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim


                    If rdr("UltimaFechaRCS").ToString.Trim <> "" Then
                        lblFechaUltimocontrol.Text = rdr("UltimaFechaRCS").ToString.Trim
                    Else
                        lblFechaUltimocontrol.Text = "---"
                    End If
                    If rdr("UltimaProduc").ToString.Trim <> "" Then
                        lblProd.Text = rdr("UltimaProduc").ToString.Trim
                    Else
                        lblProd.Text = "---"
                    End If
                    If rdr("UltimaRCS").ToString.Trim <> "" Then
                        lblRCS.Text = rdr("UltimaRCS").ToString.Trim
                    Else
                        lblRCS.Text = "---"
                    End If




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


                Else
                    If MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    End If
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
    Private Sub LimpiaDatos(Optional ByVal LimpiaDIIO As Boolean = False)
        If LimpiaDIIO = True Then
            txtDIIO.Text = ""
        End If
        '
        lblCentro.Text = "---"
        lblCategoria.Text = "---"
        '
        lblRCS.Text = "---"
        lblProd.Text = "---"
    End Sub
    Private Sub AgregarCampo()
        Dim itm As New ListViewItem((lvGanado.Items.Count + 1).ToString)
        itm.SubItems.Add(txtDIIO.Text.Trim)
        itm.SubItems.Add(lblCentro.Text.Trim)
        itm.SubItems.Add(General.TiposControlLechero.Nombre(cboTipos.SelectedIndex - 1))
        itm.SubItems.Add(Cantidades.Text)
        itm.SubItems.Add("")
        itm.SubItems.Add(centro)
        itm.SubItems.Add(General.TiposControlLechero.Codigo(cboTipos.SelectedIndex - 1))
        lvGanado.Items.Add(itm)



    End Sub
    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim variable As Boolean


        Dim n As Integer
        variable = True
        n = lvGanado.Items.Count.ToString
        For i = 0 To n - 1
            If txtDIIO.Text.Trim = lvGanado.Items(i).SubItems(1).Text.Trim Then


                Dim itm As New ListViewItem
                lvGanado.BeginUpdate()
                If lvGanado.Items(i).SubItems(7).Text = General.TiposControlLechero.Codigo(cboTipos.SelectedIndex - 1) Then
                    variable = False
                    lvGanado.Items(i).SubItems(4).Text = Cantidades.Text
                    MsgBox("Registro actualiazado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACIÓN")
                End If
                lvGanado.EndUpdate()

            End If
        Next

        If variable = True Then

            AgregarCampo()
            btnFinalizar.Enabled = True
        End If


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipos.SelectedIndexChanged
        If cboTipos.Text = "--Todos--" Then
            Cantidades.Enabled = False
            btnGrabar.Enabled = False
        Else
            Cantidades.Enabled = True
            btnGrabar.Enabled = True
        End If
        If cboTipos.Text = "Celulas Somaticas" Then
            lblr.Text = "Cantidad RCS"
        ElseIf cboTipos.Text = "Litros de Leche"
            lblr.Text = "Cantidad Prod."
        End If

    End Sub


    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        For Each it As ListViewItem In lvGanado.SelectedItems
            lvGanado.Items.Remove(it)
        Next
    End Sub

    Private Sub btnFinalizar_Click_1(sender As Object, e As EventArgs) Handles btnFinalizar.Click

        ''advertencias
        If lvGanado.Items.Count.ToString = 0 And TRegistro = 0 Then
            MsgBox("Sin Registros", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACIÓN")
            Exit Sub
        End If
        Dim Advertencia As Integer = 0
        Dim n As Integer
        n = lvGanado.Items.Count.ToString
        For i = 0 To n - 1
            If lvGanado.Items(i).BackColor = Color.Red Then
                If MsgBox(" EXISTEN REGISTROS CON ADVERTENCIAS, ¿ DESEA CONTINUAR?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
                Exit For
            End If
        Next



        If MsgBox("¿ DESEA GRABAR EL INGRESO DE CONTROL LECHERO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        fnControlLech.Grabar(lvGanado)

        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            Me.Close()
        End If
    End Sub

    Private Sub btnArchivo_Click_1(sender As Object, e As EventArgs) Handles btnArchivo.Click
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

    Private Sub cboExcel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboExcel.SelectedIndexChanged
        If cboExcel.Text = "--Todos--" Then
            btnArchivo.Enabled = False
        Else
            btnArchivo.Enabled = True

        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtDIIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

        Else
            If InStr(1, "0123456789,-" & Chr(8), e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
    End Sub
    Private Sub Cantidades_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cantidades.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

        Else
            If InStr(1, "0123456789,-" & Chr(8), e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
    End Sub


    Private Sub cboCentros_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        cboExcel.Enabled = True
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text = "--Todos--" Then
            cboExcel.Enabled = False
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        ExportToExcelGrilla(lvGanado, tot)
    End Sub


    Private Sub lvGanado_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvGanado.MouseDoubleClick
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

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub
End Class