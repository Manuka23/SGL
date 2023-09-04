Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient


Public Class frmCubiertasPorCentros
    '    Private TipoReporte As Integer = 0

    Dim PrimerIngreso As Boolean = False

    'contabilizacion
    Private Total_Muertes As Integer = 0
    Private Total_MuertesDet As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "", "CenDesCor", "", "", "", "", "", ""}

    Private CadenaOrden As String = "CenDesCor"


    Public Sub Exportar_A_Excel(ByVal grilla As ListView)
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim lin, col, col2 As Integer

            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Libro = AppExcel.Workbooks.Add
            Hoja = Libro.Worksheets(1)
            col2 = 1


            For col = 0 To grilla.Columns.Count - 1
                If grilla.Columns(col).Width > 0 Then
                    Hoja.Cells(1, col2) = grilla.Columns(col).Text
                    Hoja.Cells(1, col2).font.bold = True
                    Hoja.Cells(1, col2).font.size = 12

                    col2 = col2 + 1
                End If
            Next

            For lin = 0 To grilla.Items.Count - 1
                col2 = 1

                For col = 0 To grilla.Columns.Count - 1
                    If grilla.Columns(col).Width > 0 Then
                        Hoja.Cells(lin + 2, col2) = grilla.Items(lin).SubItems(col).Text.ToString.Trim
                        col2 = col2 + 1
                    End If
                Next
            Next

            lin = lin + 3
            Hoja.Cells(lin, 1) = "TOTALES:"
            Hoja.Cells(lin, 3) = lblTotalVacas.Text.Trim : Hoja.Cells(lin, 3).font.bold = True : Hoja.Cells(lin, 3).font.size = 12
            Hoja.Cells(lin, 4) = lblTotalIngresos.Text.Trim : Hoja.Cells(lin, 4).font.bold = True : Hoja.Cells(lin, 4).font.size = 12
            Hoja.Cells(lin, 5) = lblTotalCelos.Text.Trim : Hoja.Cells(lin, 5).font.bold = True : Hoja.Cells(lin, 5).font.size = 12
            Hoja.Cells(lin, 6) = lblPCelos.Text.Trim : Hoja.Cells(lin, 6).font.bold = True : Hoja.Cells(lin, 6).font.size = 12
            Hoja.Cells(lin, 7) = lblTotalSinCelos.Text.Trim : Hoja.Cells(lin, 7).font.bold = True : Hoja.Cells(lin, 7).font.size = 12
            Hoja.Cells(lin, 8) = lblPSinCelos.Text.Trim : Hoja.Cells(lin, 8).font.bold = True : Hoja.Cells(lin, 8).font.size = 12
            Hoja.Cells(lin, 9) = lblTotCIDR.Text.Trim : Hoja.Cells(lin, 9).font.bold = True : Hoja.Cells(lin, 9).font.size = 12
            Hoja.Cells(lin, 10) = lblPCIDR.Text.Trim : Hoja.Cells(lin, 10).font.bold = True : Hoja.Cells(lin, 10).font.size = 12

            AppExcel.Visible = True
            AppActivate(AppExcel.Caption)

            Hoja = Nothing      'Descargamos los Objetos...
            Libro = Nothing
            AppExcel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub Exportar_A_Excel_Detalle()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_ListadoDetallePorFecha", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1))
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            If rdr.HasRows = False Then Exit Try

            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Dim ncel_, fec_ As String
            Dim lin, col, col2 As Integer
            Libro = AppExcel.Workbooks.Add
            Hoja = Libro.Worksheets(1)
            lin = 2
            col2 = 1

            ''agregamos los nombres de columnas
            For col = 0 To frmCelosIngreso.lvDIIOS.Columns.Count - 1
                If frmCelosIngreso.lvDIIOS.Columns(col).Width > 0 Then
                    Hoja.Cells(1, col2) = frmCelosIngreso.lvDIIOS.Columns(col).Text
                    Hoja.Cells(1, col2).font.bold = True
                    Hoja.Cells(1, col2).font.size = 12

                    col2 = col2 + 1
                End If
            Next

            Try
                While rdr.Read()
                    ncel_ = ""
                    fec_ = Format(rdr("FechaUltCelo"), "dd-MM-yyyy")

                    If IsDBNull(fec_) = True Or fec_ = "01-01-1753" Or fec_ = "01-01-1900" Then
                        fec_ = ""
                    End If

                    If rdr("NumeroCelos") > 0 Then ncel_ = rdr("NumeroCelos").ToString.Trim

                    Hoja.Cells(lin, 1) = (lin - 1).ToString.Trim
                    Hoja.Cells(lin, 2) = rdr("diio").ToString.Trim
                    Hoja.Cells(lin, 3) = rdr("GndProNom").ToString.Trim
                    Hoja.Cells(lin, 4) = fec_
                    Hoja.Cells(lin, 5) = ncel_
                    Hoja.Cells(lin, 6) = rdr("DiasLactancia").ToString.Trim
                    Hoja.Cells(lin, 7) = rdr("GndActPartosNum").ToString.Trim
                    Hoja.Cells(lin, 8) = rdr("GndEstadoProductivo").ToString.Trim
                    Hoja.Cells(lin, 9) = rdr("GndEstadoReproductivo").ToString.Trim

                    lin = lin + 1
                End While

                AppExcel.Visible = True
                AppActivate(AppExcel.Caption)

                Hoja = Nothing      'Descargamos los Objetos...
                Libro = Nothing
                AppExcel = Nothing

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
    End Sub


    Public Sub Exportar_A_Excel_Detalle2(ByVal grilla As ListView)
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim lin, col, col2 As Integer

            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Libro = AppExcel.Workbooks.Add
            Hoja = Libro.Worksheets(1)
            col2 = 1

            For col = 0 To grilla.Columns.Count - 1
                If grilla.Columns(col).Width > 0 Then
                    Hoja.Cells(1, col2) = grilla.Columns(col).Text
                    Hoja.Cells(1, col2).font.bold = True
                    Hoja.Cells(1, col2).font.size = 12

                    col2 = col2 + 1
                End If
            Next

            For lin = 0 To grilla.Items.Count - 1
                col2 = 1

                For col = 0 To grilla.Columns.Count - 1
                    If grilla.Columns(col).Width > 0 Then
                        Hoja.Cells(lin + 2, col2) = grilla.Items(lin).SubItems(col).Text.ToString.Trim
                        col2 = col2 + 1
                    End If
                Next
            Next

            lin = lin + 3
            Hoja.Cells(lin, 1) = "TOTALES:"
            Hoja.Cells(lin, 3) = lblTotalVacas.Text.Trim : Hoja.Cells(lin, 3).font.bold = True : Hoja.Cells(lin, 3).font.size = 12
            Hoja.Cells(lin, 4) = lblTotalIngresos.Text.Trim : Hoja.Cells(lin, 4).font.bold = True : Hoja.Cells(lin, 4).font.size = 12
            Hoja.Cells(lin, 5) = lblTotalCelos.Text.Trim : Hoja.Cells(lin, 5).font.bold = True : Hoja.Cells(lin, 5).font.size = 12
            Hoja.Cells(lin, 6) = lblPCelos.Text.Trim : Hoja.Cells(lin, 6).font.bold = True : Hoja.Cells(lin, 6).font.size = 12
            Hoja.Cells(lin, 7) = lblTotalSinCelos.Text.Trim : Hoja.Cells(lin, 7).font.bold = True : Hoja.Cells(lin, 7).font.size = 12
            Hoja.Cells(lin, 8) = lblPSinCelos.Text.Trim : Hoja.Cells(lin, 8).font.bold = True : Hoja.Cells(lin, 8).font.size = 12
            Hoja.Cells(lin, 9) = lblTotCIDR.Text.Trim : Hoja.Cells(lin, 9).font.bold = True : Hoja.Cells(lin, 9).font.size = 12
            Hoja.Cells(lin, 10) = lblPCIDR.Text.Trim : Hoja.Cells(lin, 10).font.bold = True : Hoja.Cells(lin, 10).font.size = 12

            AppExcel.Visible = True
            AppActivate(AppExcel.Caption)

            Hoja = Nothing      'Descargamos los Objetos...
            Libro = Nothing
            AppExcel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub



    Public Sub ConsultaCubiertas(ByVal cent_ As String, ByVal diio_ As String)
        If PrimerIngreso = True Then Exit Sub

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCubiertas_ListadoPorCentros", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        lvCUBIERTAS.BeginUpdate()
        lvCUBIERTAS.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim totvacas As Integer = 0
        Dim totings As Integer = 0
        Dim totcelos As Integer = 0
        Dim totcidr As Integer = 0

        Dim totpcelos As Double = 0
        Dim totpsincelos As Double = 0
        Dim totpcidr As Double = 0

        Dim pje_celos As Double = 0
        Dim pje_sincelos As Double = 0
        Dim pje_cidr As Double = 0
        Dim cnt_sincbtas As Integer = 0

        Dim MuestraReg As Boolean = False

        lblTotalVacas.Text = "0"
        lblTotalIngresos.Text = "0"
        lblTotalCelos.Text = "0"
        lblPCelos.Text = "0 %"
        lblTotalSinCelos.Text = "0"
        lblPSinCelos.Text = "0 %"

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try


                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    pje_celos = 0
                    pje_sincelos = 0
                    pje_cidr = 0
                    cnt_sincbtas = 0

                    MuestraReg = True
                    If chkSoloConStock.Checked = True And rdr("Disponibles") = 0 Then MuestraReg = False

                    If MuestraReg = True Then
                        cnt_sincbtas = (rdr("Disponibles") - rdr("ContCubiertas"))

                        If rdr("Disponibles") <> 0 Then
                            pje_celos = ((rdr("ContCubiertas") * 100) / rdr("Disponibles"))
                            pje_sincelos = ((cnt_sincbtas * 100) / rdr("Disponibles"))
                            pje_cidr = ((rdr("ContCIDR") * 100) / rdr("Disponibles"))
                        End If



                        Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                        item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                        item.SubItems.Add(rdr("CenCod").ToString.Trim)
                        item.SubItems.Add(rdr("CenDesCor").ToString.Trim)

                        item.SubItems.Add(rdr("ContVacas").ToString.Trim)
                        item.SubItems.Add(rdr("Disponibles").ToString.Trim)
                        item.SubItems.Add(rdr("ContCubiertas").ToString.Trim)
                        item.SubItems.Add(Format(pje_celos, "#,##0.00") + " %")
                        ''
                        item.SubItems.Add(rdr("ContIngresos").ToString.Trim)
                        item.SubItems.Add(rdr("ContCubiertasIngresos").ToString.Trim)
                        ''
                        item.SubItems.Add(cnt_sincbtas)
                        item.SubItems.Add(Format(pje_sincelos, "#,##0.00") + " %")
                        item.SubItems.Add("") 'rdr("ContDiasLac").ToString.Trim)
                        item.SubItems.Add("") 'Format(pje_diaslac, "#,##0.00") + " %")
                        item.SubItems.Add(rdr("ContCIDR").ToString.Trim)
                        item.SubItems.Add(Format(pje_cidr, "#,##0.00") + " %")
                        lvCUBIERTAS.Items.Add(item)
                        totvacas = totvacas + rdr("Disponibles")
                        totings = totings + rdr("ContIngresos")
                        totcelos = totcelos + rdr("ContCubiertas")
                        totcidr = totcidr + rdr("ContCIDR")

                        i = i + 1
                    End If

                    pbProcesa.Value = i
                End While

                pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvCUBIERTAS.EndUpdate()

        lblTotalVacas.Text = totvacas.ToString.Trim
        lblTotCIDR.Text = totcidr.ToString.Trim
        lblTotalIngresos.Text = totings.ToString.Trim
        lblTotalCelos.Text = totcelos.ToString.Trim
        lblTotalSinCelos.Text = (totvacas - totcelos).ToString.Trim

        If totvacas <> 0 Then
            totpcelos = ((totcelos * 100) / totvacas)
            totpsincelos = (((totvacas - totcelos) * 100) / totvacas)
            totpcidr = ((totcidr * 100) / totvacas)

            lblPCelos.Text = totpcelos.ToString("#,##0.00") + " %"
            lblPSinCelos.Text = totpsincelos.ToString("#,##0.00") + " %"
            lblPCIDR.Text = totpcidr.ToString("#,##0.00") + " %"
        End If

        pnlProcesa.Visible = False
    End Sub


    Public Sub LlenaGrilla()
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim causa_ As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "CenDesCor"
            lblOrdena.Text = "Centro"
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaCubiertas(cent_, txtDIIO.Text.Trim)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrilla()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvCUBIERTAS.Items.Count = 0 Then Exit Sub
        Exportar_A_Excel(lvCUBIERTAS)
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor
        frmCubiertasIngreso.Param1_Modo = 1   'nuevo
        frmCubiertasIngreso.MdiParent = frmMAIN
        frmCubiertasIngreso.Show()
        frmCubiertasIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCUBIERTAS.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvCUBIERTAS.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvCUBIERTAS.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCUBIERTAS.MouseDoubleClick
        If lvCUBIERTAS.Items.Count = 0 Then Exit Sub
        If lvCUBIERTAS.SelectedItems.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            Cursor.Current = Cursors.WaitCursor

            Dim cent_ As String = lvCUBIERTAS.SelectedItems(0).SubItems(2).Text
            Dim centnom_ As String = lvCUBIERTAS.SelectedItems(0).SubItems(3).Text
            Dim fCubIngreso As New frmCubiertasIngreso()

            With fCubIngreso
                fCubIngreso.Param2_Empresa = Empresa
                fCubIngreso.Param3_CentroCod = cent_
                fCubIngreso.Param3_CentroNom = centnom_
                fCubIngreso.Param4_Fecha = dtpFechaDesde.Value
                fCubIngreso.Param4_FechaDesde = dtpFechaHasta.Value

                .MdiParent = frmMAIN
                .Show()
                .BringToFront()
            End With

        End If
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        LlenaGrilla()
    End Sub

    Private Sub frmCubiertasPorCentros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrimerIngreso = True
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True
        CboLLenaCentros()
        dtpFechaDesde.Value = "01/" + Month(Now).ToString.Trim + "/" + Year(Now).ToString.Trim

        PrimerIngreso = False
    End Sub

    Private Sub lvCUBIERTAS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvCUBIERTAS.SelectedIndexChanged

    End Sub
End Class