Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient

Public Class frmCelosPorCentros
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Dim PrimerIngreso As Boolean = False

    'contabilizacion
    Private Total_Muertes As Integer = 0
    Private Total_MuertesDet As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "", "CenDesCor", "", "", "", "", "", ""}

    Private CadenaOrden As String = "CenDesCor"

    Private CentroCod As Integer = 0
    Private Sub frmCelosPorCentros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrimerIngreso = True

        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.MinimumSize = Me.Size
        Me.KeyPreview = True

        MSTRUsuarios.DSCboUsuarioCentros_FrmQRY(True, cboCentros)
        cboCentros.Text = UsuarioCentroNomDefault
        CentroCod = UsuarioCentroCodDefault

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim

        PrimerIngreso = False
    End Sub

    Private Sub Celos_Buscar()
        Cursor.Current = Cursors.WaitCursor
        If CadenaOrden = "" Then
            CadenaOrden = "CenDesCor"
            lblOrdena.Text = "Centro"
            lblOrdena.Refresh()
        End If
        ''--------------------------------------------------------------------------------------
        ''DEFINICION DE PARAMETROS
        Dim params_in As New Hashtable
        ''
        params_in.Add("@CentroCod", CentroCod)
        params_in.Add("@FechaDesde", Convert.ToDateTime(dtpFechaDesde.Value))
        params_in.Add("@FechaHasta", Convert.ToDateTime(dtpFechaHasta.Value))
        params_in.Add("@DIIO", txtDIIO.Text.Trim)

        ''--------------------------------------------------------------------------------------
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ConsultaCelos(ByVal cent_ As String, ByVal diio_ As String)
        If PrimerIngreso = True Then Exit Sub

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_ListadoPorCentros", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod) 'cent_
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvCELOS.BeginUpdate()
        lvCELOS.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim totvacas As Integer = 0
        Dim totdlac As Integer = 0
        Dim totings As Integer = 0
        Dim totcelos As Integer = 0

        Dim totpcelos As Double = 0
        Dim totpsincelos As Double = 0
        Dim totpdiaslac As Double = 0

        Dim pje_celos As Double = 0
        Dim pje_sincelos As Double = 0
        Dim pje_diaslac As Double = 0

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
                        'totvacas = rdr("ContVacas")
                        pbProcesa.Maximum = vret
                    End If

                    pje_celos = 0
                    pje_sincelos = 0
                    pje_diaslac = 0

                    MuestraReg = True
                    If chkSoloConStock.Checked = True And rdr("ContVacas") = 0 Then MuestraReg = False

                    If MuestraReg = True Then
                        If rdr("ContVacas") <> 0 Then
                            pje_celos = ((rdr("ContCelos") * 100) / rdr("ContVacas"))
                            pje_sincelos = ((rdr("ContSinCelos") * 100) / rdr("ContVacas"))
                            pje_diaslac = ((rdr("ContDiasLac") * 100) / rdr("ContVacas"))
                        End If

                        Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                        'item.SubItems.Add((i + 1).ToString.Trim)
                        item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                        item.SubItems.Add(rdr("CenCod").ToString.Trim)
                        item.SubItems.Add(rdr("CenDesCor").ToString.Trim)

                        item.SubItems.Add(rdr("ContVacas").ToString.Trim)
                        item.SubItems.Add(rdr("ContIngresos").ToString.Trim)
                        item.SubItems.Add(rdr("ContCelos").ToString.Trim)
                        item.SubItems.Add(Format(pje_celos, "#,##0.00") + " %")
                        item.SubItems.Add(rdr("ContSinCelos").ToString.Trim)
                        item.SubItems.Add(Format(pje_sincelos, "#,##0.00") + " %")
                        item.SubItems.Add(rdr("ContDiasLac").ToString.Trim)
                        item.SubItems.Add(Format(pje_diaslac, "#,##0.00") + " %")

                        lvCELOS.Items.Add(item)

                        'ProcesaTotales(rdr("CeloTotRegs"))
                        totvacas = totvacas + rdr("ContVacas")
                        totings = totings + rdr("ContIngresos")
                        totcelos = totcelos + rdr("ContCelos")
                        totdlac = totdlac + rdr("ContDiasLac")

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
        lvCELOS.EndUpdate()

        'totvacas = TotalVacas()

        lblTotalVacas.Text = totvacas.ToString.Trim
        lblTot42Dias.Text = totdlac.ToString.Trim
        lblTotalIngresos.Text = totings.ToString.Trim
        lblTotalCelos.Text = totcelos.ToString.Trim
        lblTotalSinCelos.Text = (totvacas - totcelos).ToString.Trim

        If totvacas <> 0 Then
            totpcelos = ((totcelos * 100) / totvacas)
            totpsincelos = (((totvacas - totcelos) * 100) / totvacas)
            totpdiaslac = ((totdlac * 100) / totvacas)

            lblPCelos.Text = totpcelos.ToString("#,##0.00") + " %"
            lblPSinCelos.Text = totpsincelos.ToString("#,##0.00") + " %"
            lblP42Dias.Text = totpdiaslac.ToString("#,##0.00") + " %"
        End If

        'Total_General = i
        'MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Public Sub LlenaGrilla()
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim causa_ As String = ""

        'If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
        '    cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        'End If

        If CadenaOrden = "" Then
            CadenaOrden = "CenDesCor"
            lblOrdena.Text = "Centro"
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaCelos(cent_, txtDIIO.Text.Trim)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub DetalleGanado()
        If lvCELOS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvCELOS.SelectedItems.Item(0).SubItems(4).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

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
        If lvCELOS.Items.Count = 0 Then Exit Sub

        Dim mres As MsgBoxResult = MsgBox("PARA EXPORTAR DETALLE (SI), PARA EXPORTAR RESUMEN (NO), PARA SALIR (CANCELAR)", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel, "SGL")

        If mres = MsgBoxResult.Yes Then
            Exportar_A_Excel_Detalle()
        End If

        If mres = MsgBoxResult.No Then
            Exportar_A_Excel(lvCELOS)
        End If
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        frmCELOSINGRESO.Param1_Modo = 1   'nuevo

        frmCELOSINGRESO.MdiParent = frmMAIN
        frmCELOSINGRESO.Show()
        frmCELOSINGRESO.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCELOS.ColumnClick

        OrdenarColumnasLV.OrdenarColumnas(lvCELOS, e)
        'If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        'If CadenaOrden.Trim = "" Then
        '    CadenaOrden = CamposOrden(e.Column)
        '    lblOrdena.Text = lvCELOS.Columns(e.Column).Text
        'Else
        '    CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
        '    lblOrdena.Text = lblOrdena.Text + " -> " + lvCELOS.Columns(e.Column).Text
        'End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCELOS.MouseDoubleClick
        If lvCELOS.Items.Count = 0 Then Exit Sub
        If lvCELOS.SelectedItems.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then

            Cursor.Current = Cursors.WaitCursor


            Dim cent_ As String = lvCELOS.SelectedItems(0).SubItems(3).Text
            Dim fCelos As New frmCelos()

            With fCelos
                .MdiParent = frmMAIN
                .Show()
                .BringToFront()

                .cboCentros.Text = cent_
                .dtpFechaDesde.Value = dtpFechaDesde.Value
                .dtpFechaHasta.Value = dtpFechaHasta.Value

                .LlenaGrilla()
            End With

        End If
    End Sub


    Private Sub btnGanadoSinCelo_Click(sender As System.Object, e As System.EventArgs) Handles btnGanadoSinCelo.Click
        VerDetalleGanado(3)
    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        VerDetalleGanado(4)
    End Sub



    Private Sub VerDetalleGanado(ByVal Modo As Integer)
        'If lvCELOS.Items.Count = 0 Then Exit Sub
        'If lvCELOS.SelectedItems.Count = 0 Then Exit Sub

        'If e.Button = MouseButtons.Left = True Then
        'DetalleGanado()
        Dim centcod_ As String = ""
        Dim centnom_ As String = ""
        Dim fIngresoCelos As New frmCelosIngreso()

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            'centcod_ = lvCELOS.SelectedItems(0).SubItems(2).Text
            'centnom_ = lvCELOS.SelectedItems(0).SubItems(3).Text

            centcod_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
            centnom_ = General.CentrosUsuario.Nombre(cboCentros.SelectedIndex - 1)
        End If

        Cursor.Current = Cursors.WaitCursor

        With fIngresoCelos
            .Param1_Modo = Modo
            .Param2_Empresa = Empresa
            .Param3_CentroCod = centcod_
            .Param3_CentroNom = centnom_
            .Param4_FechaDesde = dtpFechaDesde.Value
            .Param4_FechaHasta = dtpFechaHasta.Value
            .Param5_Observs = ""
            '.Param6_FechaHasta = dtpFechaHasta.Value

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            .cboCentros.Enabled = True
            .txtDIIO.Enabled = False
            .dtpFecha.Enabled = False
            .dtpFechaDesde.Enabled = True
            .dtpFechaHasta.Enabled = True
            .txtObservs.Enabled = False
            .btnEliminar.Visible = False

            .btnExcel.Left = .btnFinalizar.Left
            .btnExcel.Visible = True

            .gboxRangoFecha.Visible = True
            .gboxFecha.Visible = False
            .gboxObservs.Visible = False

            If centcod_ = "" Then
                .cboCentros.SelectedIndex = 0
            Else
                .cboCentros.Text = centnom_
            End If
        End With
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboCentros.SelectedItem, DataRowView)
        If Not selectedRow Is Nothing Then CentroCod = selectedRow("CentroCod")
        LlenaGrilla()
    End Sub


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

            'Libro.Title = "Consulta de Ganado..."
            'Libro.Author = "ndsky"
            'Hoja.Name = "Libro Exportado"


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
            Hoja.Cells(lin, 9) = lblTot42Dias.Text.Trim : Hoja.Cells(lin, 9).font.bold = True : Hoja.Cells(lin, 9).font.size = 12
            Hoja.Cells(lin, 10) = lblP42Dias.Text.Trim : Hoja.Cells(lin, 10).font.bold = True : Hoja.Cells(lin, 10).font.size = 12

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

            'Libro.Title = "Consulta de Ganado..."
            'Libro.Author = "ndsky"
            'Hoja.Name = "Libro Exportado"


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
            Hoja.Cells(lin, 9) = lblTot42Dias.Text.Trim : Hoja.Cells(lin, 9).font.bold = True : Hoja.Cells(lin, 9).font.size = 12
            Hoja.Cells(lin, 10) = lblP42Dias.Text.Trim : Hoja.Cells(lin, 10).font.bold = True : Hoja.Cells(lin, 10).font.size = 12

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
End Class