

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmCompras
    Private TipoReporte As Integer = 0

    'contabilizacion por condicion
    Private Total_General As Integer = 0
    Private Total_Detalle As Integer = 0


    Private ColumnSort As Integer = 0

    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "CmpEmpresa", "CenDesCor", "CmpFecha", "CmpNroFMA", "CmpNroGuia", _
                                        "PrvRazSoc", "TipDocNom", "CmpNroDoc", "CmpNumRegs", "", "", "", "", "", ""}

    Private CadenaOrden As String = "CenDesCor, CmpFecha"


    Private Sub InicializaTotales()
        Total_General = 0
        Total_Detalle = 0
    End Sub


    'Private Sub ProcesaTotales(ByVal cond_ As String)
    '    Select Case cond_
    '        Case "PRENADA" : TotER_Preniada = TotER_Preniada + 1
    '        Case "PREÑADA" : TotER_Preniada = TotER_Preniada + 1
    '        Case "SECA PRN" : TotER_SecaPrn = TotER_SecaPrn + 1
    '        Case "DUDOSA" : TotER_Dudosa = TotER_Dudosa + 1
    '        Case "ANESTRO" : TotER_Anestro = TotER_Anestro + 1
    '        Case Else : TotER_Otros = TotER_Otros + 1
    '    End Select
    'End Sub


    Private Sub MuestraTotales()
        Label85.Text = Total_General.ToString.Trim
        Label5.Text = Total_Detalle.ToString.Trim

        pnlEstReprod.Refresh()
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub



    Public Sub ConsultaCompras(ByVal cent_ As String, ByVal diio_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCompras_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        InicializaTotales()
        MuestraTotales()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)             'primera columna, correlativo

                    item.SubItems.Add(rdr("CmpEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(Format(rdr("CmpFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("CmpNroFMA").ToString.Trim)               'FMA
                    item.SubItems.Add(rdr("CmpNroGuia").ToString.Trim)              'guia
                    item.SubItems.Add(rdr("PrvRazSoc").ToString.Trim)               'proveedor
                    item.SubItems.Add(rdr("TipDocNom").ToString.Trim)               'tipo documento
                    item.SubItems.Add(rdr("CmpNroDoc").ToString.Trim)               'nro documento
                    item.SubItems.Add(rdr("CmpNumRegs").ToString.Trim)              'cantidad
                    item.SubItems.Add(rdr("CEstNombre").ToString.Trim)              'estado
                    item.SubItems.Add(rdr("CmpObservacion").ToString.Trim)          'observs
                    item.SubItems.Add(rdr("CmpCentro").ToString.Trim)               'codigo centro
                    item.SubItems.Add(rdr("CmpEstado").ToString.Trim)               'codigo estado
                    item.SubItems.Add("0") 'rdr("CmpVtaCod").ToString.Trim)          'codigo compra
                    item.SubItems.Add(rdr("CmpRUP").ToString.Trim)                  'rup
                    item.SubItems.Add(rdr("CmpFecha").ToString.Trim)                'fecha completa (fecha-hora)

                    lvGanado.Items.Add(item)

                    Total_General = Total_General + 1
                    Total_Detalle = Total_Detalle + rdr("CmpNumRegs")

                    i = i + 1
                    pbProcesa.Value = Total_General
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
        lvGanado.EndUpdate()
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Private Sub DetalleCompra()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim emp_ As Integer = lvGanado.SelectedItems.Item(0).SubItems(1).Text           'empresa
        Dim nomcent_ As String = lvGanado.SelectedItems.Item(0).SubItems(2).Text        'nombre centro
        Dim fec_ As String = lvGanado.SelectedItems.Item(0).SubItems(16).Text           'fecha-hora
        Dim fma_ As String = lvGanado.SelectedItems.Item(0).SubItems(4).Text            'fma
        Dim guia_ As String = lvGanado.SelectedItems.Item(0).SubItems(5).Text           'guia
        Dim prov_ As String = lvGanado.SelectedItems.Item(0).SubItems(6).Text           'proveedor
        Dim tdocnom_ As String = lvGanado.SelectedItems.Item(0).SubItems(7).Text        'nombre tipo doc
        Dim nrodoc_ As String = lvGanado.SelectedItems.Item(0).SubItems(8).Text         'nro doc

        Dim est_ As String = lvGanado.SelectedItems.Item(0).SubItems(10).Text           'nombre estado
        Dim obs_ As String = lvGanado.SelectedItems.Item(0).SubItems(11).Text           'observacion secado
        Dim cent_ As String = lvGanado.SelectedItems.Item(0).SubItems(12).Text          'codigo centro

        Dim estcod_ As String = lvGanado.SelectedItems.Item(0).SubItems(13).Text        'codigo estado
        Dim rup_ As String = lvGanado.SelectedItems.Item(0).SubItems(15).Text           'rup


        If cent_.Trim = "" Then Exit Sub

        With frmComprasIngreso
            '.CodigoSecado = codsec_
            .Param0_ModoIngreso = 2        '1=nuevo  /  2=edicion
            '.Param1_Empresa = emp_
            .Param2_CodigoCentro = cent_
            .Param3_NombreCentro = nomcent_
            .Param4_Fecha = fec_
            .Param5_Observs = obs_
            .Param7_NroGuia = guia_
            .Param8_RUP = rup_
            .Param9_Estado = est_
            .Param10_TipoDocumento = tdocnom_
            .Param11_FMA = fma_
            .Param12_NroDocumento = nrodoc_
            .Param13_Proveedor = prov_
            .Param14_CodigoEstado = estcod_

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub LlenaGrillaCompras()
        'Dim OtrosCent As Integer = 0
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        'If cboVeterinarios.SelectedIndex <> -1 And cboVeterinarios.Text <> "(TODOS)" Then
        '    vet_ = General.Veterinarios.Codigo(cboVeterinarios.SelectedIndex - 1)
        'End If

        If CadenaOrden = "" Then
            CadenaOrden = "CenDesCor, CmpFecha"
            lblOrden.Text = "Centro -> Fecha"
            lblOrden.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaCompras(cent_, txtDIIO.Text.Trim)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrillaCompras()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL COMPRAS " : tot(0, 1) = Label85.Text.Trim
        tot(1, 0) = "TOTAL COMPRA GANADO " : tot(1, 1) = Label5.Text.Trim

        ExportToExcelGrilla(lvGanado, tot)
    End Sub



    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        With frmComprasIngreso
            .Param0_ModoIngreso = 1        '1=nuevo  /  2=edicion
            .Param14_CodigoEstado = 1

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            If cboCentros.SelectedIndex > 0 Then .cboCentros.Text = cboCentros.Text
        End With

        Cursor.Current = Cursors.Default
    End Sub



    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click

    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Private Sub dtpFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
    End Sub



    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvGanado.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrden.Text = lvGanado.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrden.Text = lblOrden.Text + " -> " + lvGanado.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleCompra()
        End If
    End Sub


    Private Sub frmCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Proveedores.Cargar()
        General.TipoDocumentos.Cargar()
        General.EstReproductivos.Cargar()
        General.EstProductivos.Cargar()
        General.Razas.Cargar()
        General.Categorias.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()

        dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now

        cboCentros.SelectedIndex = 0
    End Sub



    Private Sub btnImportar_Click(sender As System.Object, e As System.EventArgs) Handles btnImportar.Click
        Cursor.Current = Cursors.WaitCursor

        'OpenFDlg.FileName = ""
        'OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        'OpenFDlg.ShowDialog()

        'If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        'frmComprasImportacion.ArchivoImportacion = OpenFDlg.FileName.Trim()
        'frmComprasImportacion.MdiParent = frmMAIN
        'frmComprasImportacion.Show()

        'Dim imp As New frmComprasImportacion(OpenFDlg.FileName.Trim)

        'imp.MdiParent = frmMAIN
        'imp.Show()

        Cursor.Current = Cursors.Default
    End Sub



End Class