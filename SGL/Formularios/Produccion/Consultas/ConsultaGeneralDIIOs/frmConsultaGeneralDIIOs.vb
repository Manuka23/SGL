

Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient


Public Class frmConsultaGeneralDIIOs

    Private TipoReporte As Integer = 0
    Private TituloReporte As String = "INFORME DE GANADO"

    Private Total_General As Integer = 0

    'contabilizaciones por categoria
    Private TotCat_Terneras As Integer = 0
    Private TotCat_Terneros As Integer = 0
    Private TotCat_Toretes As Integer = 0
    Private TotCat_Toros As Integer = 0
    Private TotCat_Vacas As Integer = 0
    Private TotCat_Vaquillas As Integer = 0

    'contabilizaciones por estados productivos
    Private TotEP_Descarte As Integer = 0
    Private TotEP_Desecho As Integer = 0
    Private TotEP_EliminadaLeche As Integer = 0
    Private TotEP_Produccion As Integer = 0
    Private TotEP_NoAplica As Integer = 0
    Private TotEP_SecaLeche As Integer = 0

    'contabilizaciones por estados reproductivos
    Private TotER_Anestro As Integer = 0
    Private TotER_Cubierta As Integer = 0
    Private TotER_DesechoReprod As Integer = 0
    Private TotER_Dudosa As Integer = 0
    Private TotER_NoAplica As Integer = 0
    Private TotER_Preniada As Integer = 0
    Private TotER_SecaPrn As Integer = 0

    'nombre de los campos en la base de datos, para realizar los ordenamientos desde esta pantalla
    Private CamposOrden As String() = {"", "EmpRut", "CenDesCor", "GndCod", "GndProNom", "GndFecNac", "NomRaza", "GndEstado", _
                                       "GndPadre", "GndMadre", "GndAbuelo", "GndEstadoProductivo", "MuestraTUB", "MuestraLEU", "MuestraBRU","GndEstadoReproductivo", _
                                       "GndEstadoSalud", "GndUltFechaPP", "GndUltFechaSecado", "GrpProduccionCod", "GndUltFechaPriPartos", _
                                       "GndUltFechaParto", "GndActPartosNum", "GndUltCubierta", "GndUltCubiertaNum", _
                                       "ToroNombre", "", "DiasLactancia", "NacidoEn", "FechaCompra", "GndCenSalFec", "CentroSalida"}

    Private CamposOrdenEstadoFecha As String() = {"GndIsMuertoFecha", "GndIsVendidoFecha", "GndIsDesaparecidoFecha", ""}

    Private CadenaOrden As String = "Lectura" '"CenDesCor, GndCod"
    Private IdxFechaEstado As Integer = 20


    Private Sub InicializaTotales()
        Total_General = 0

        TotCat_Terneras = 0
        TotCat_Terneros = 0
        TotCat_Toretes = 0
        TotCat_Toros = 0
        TotCat_Vacas = 0
        TotCat_Vaquillas = 0

        TotEP_Descarte = 0
        TotEP_Desecho = 0
        TotEP_EliminadaLeche = 0
        TotEP_Produccion = 0
        TotEP_NoAplica = 0
        TotEP_SecaLeche = 0

        TotER_Anestro = 0
        TotER_Cubierta = 0
        TotER_DesechoReprod = 0
        TotER_Dudosa = 0
        TotER_NoAplica = 0
        TotER_Preniada = 0
        TotER_SecaPrn = 0
    End Sub


    Private Sub ProcesaTotales(ByVal cat_ As String, ByVal eprod_ As String, ByVal erep_ As String)
        Select Case cat_
            Case "TERNERAS" : TotCat_Terneras = TotCat_Terneras + 1
            Case "TERNEROS" : TotCat_Terneros = TotCat_Terneros + 1
            Case "TORETES" : TotCat_Toretes = TotCat_Toretes + 1
            Case "TOROS" : TotCat_Toros = TotCat_Toros + 1
            Case "VACAS" : TotCat_Vacas = TotCat_Vacas + 1
            Case "VAQUILLAS" : TotCat_Vaquillas = TotCat_Vaquillas + 1
        End Select

        Select Case eprod_
            Case "DESCARTE" : TotEP_Descarte = TotEP_Descarte + 1
            Case "DESECHO" : TotEP_Desecho = TotEP_Desecho + 1
            Case "ELIMINADA EN LECHE" : TotEP_EliminadaLeche = TotEP_EliminadaLeche + 1
            Case "EN PRODUCCION" : TotEP_Produccion = TotEP_Produccion + 1
            Case "NO APLICA" : TotEP_NoAplica = TotEP_NoAplica + 1
            Case "SECA DE LECHE" : TotEP_SecaLeche = TotEP_SecaLeche + 1
        End Select

        Select Case erep_
            Case "ANESTRO" : TotER_Anestro = TotER_Anestro + 1
            Case "CUBIERTA" : TotER_Cubierta = TotER_Cubierta + 1
            Case "DESECHO REPRODUCTIVO" : TotER_DesechoReprod = TotER_DesechoReprod + 1
            Case "DUDOSA" : TotER_Dudosa = TotER_Dudosa + 1
            Case "NO APLICA" : TotER_NoAplica = TotER_NoAplica + 1
            Case "PREÑADA" : TotER_Preniada = TotER_Preniada + 1
            Case "SECA PRN" : TotER_SecaPrn = TotER_SecaPrn + 1
        End Select
    End Sub


    Private Sub MuestraTotales()
        Label8.Text = Total_General.ToString.Trim
        Label125.Text = Total_General.ToString.Trim
        Label85.Text = Total_General.ToString.Trim

        Label9.Text = TotCat_Terneras.ToString.Trim
        Label11.Text = TotCat_Terneros.ToString.Trim()
        Label13.Text = TotCat_Toretes.ToString.Trim()
        Label15.Text = TotCat_Toros.ToString.Trim()
        Label17.Text = TotCat_Vacas.ToString.Trim()
        Label19.Text = TotCat_Vaquillas.ToString.Trim()

        Label111.Text = TotEP_Descarte.ToString.Trim()
        Label109.Text = TotEP_Desecho.ToString.Trim()
        Label107.Text = TotEP_EliminadaLeche.ToString.Trim()
        Label105.Text = TotEP_Produccion.ToString.Trim()
        Label103.Text = TotEP_NoAplica.ToString.Trim()
        Label101.Text = TotEP_SecaLeche.ToString.Trim()

        Label59.Text = TotER_Anestro.ToString.Trim()
        Label33.Text = TotER_Cubierta.ToString.Trim()
        Label56.Text = TotER_DesechoReprod.ToString.Trim()
        Label54.Text = TotER_Dudosa.ToString.Trim()
        Label52.Text = TotER_NoAplica.ToString.Trim()
        Label48.Text = TotER_Preniada.ToString.Trim()
        Label34.Text = TotER_SecaPrn.ToString.Trim()

        pnlTotCategoria.Refresh()
        pnlEstProd.Refresh()
        pnlEstReprod.Refresh()
    End Sub


    Public Sub ConsultaGeneral(ByVal diios_ As String)

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaGeneralDIIOs", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)

        cmd.Parameters.AddWithValue("@DIIOs", diios_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i As Integer = 0
        Dim madre_, estado_, fpp_, fsec_, fnac_, fest_, cubnum_, numpart_, dlac_, nace_, fcomp_, fulttras_, culttras_, raza_ As String
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

                    madre_ = rdr("GndMadre").ToString.Trim
                    estado_ = rdr("GndEstado").ToString.Trim
                    fpp_ = ""
                    fsec_ = ""
                    fest_ = ""
                    cubnum_ = ""
                    numpart_ = ""
                    dlac_ = ""
                    nace_ = ""
                    fcomp_ = ""
                    fulttras_ = ""
                    culttras_ = ""

                    raza_ = rdr("NomRaza").ToString.Trim
                    If madre_.Trim = "0" Then madre_ = ""
                    fpp_ = rdr("FechaProbPart").ToString.Trim
                    fsec_ = rdr("FechaSecado").ToString.Trim
                    fnac_ = rdr("GndFecNac2").ToString.Trim
                    fcomp_ = rdr("FechaCompra").ToString.Trim

                    If Not IsDBNull(rdr("GndCenSalFec")) Then fulttras_ = Format(rdr("GndCenSalFec"), "dd-MM-yyyy")
                    If Not IsDBNull(rdr("CentroSalida")) Then culttras_ = rdr("CentroSalida").ToString.Trim()

                    If Not IsDBNull(rdr("GndUltCubiertaNum")) Then
                        If rdr("GndUltCubiertaNum") <> 0 Then cubnum_ = rdr("GndUltCubiertaNum").ToString.Trim()
                    End If

                    Select Case estado_
                        Case "MUERTO"
                            If IsDate(rdr("GndIsMuertoFecha")) Then fest_ = Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy")
                        Case "VENDIDO"
                            If IsDate(rdr("GndIsVendidoFecha")) Then fest_ = Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy")
                        Case "DESAPARECIDO"
                            If IsDate(rdr("GndIsDesaparecidoFecha")) Then fest_ = Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy")
                    End Select

                    If Not IsDBNull(rdr("GndActPartosNum")) Then
                        If rdr("GndActPartosNum") <> 0 Then numpart_ = rdr("GndActPartosNum").ToString.Trim()
                    End If

                    If Not IsDBNull(rdr("DiasLactancia")) Then
                        If rdr("DiasLactancia") <> 0 Then dlac_ = rdr("DiasLactancia").ToString.Trim()
                    End If

                    If Not IsDBNull(rdr("NacidoEn")) Then
                        If rdr("NacidoEn") <> "" Then nace_ = rdr("NacidoEn").ToString.Trim()
                    End If
                    Dim diio As String
                    diio = rdr("codigo_diio").ToString.Trim().PadLeft(12, "0")

                    diio = "152 " & diio

                    Dim item As New ListViewItem((i + 1).ToString.Trim)

                    item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(rdr("codigo_diio").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add(fnac_)
                    item.SubItems.Add(raza_)
                    item.SubItems.Add(estado_)
                    item.SubItems.Add(rdr("GndPadre").ToString.Trim)
                    item.SubItems.Add(madre_)
                    item.SubItems.Add(rdr("GndAbuelo").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoSalud").ToString.Trim)
                    item.SubItems.Add(fpp_)
                    item.SubItems.Add(fsec_)
                    item.SubItems.Add(rdr("GrpProduccionCod").ToString.Trim)
                    item.SubItems.Add(rdr("GndUltFechaPriPartos2").ToString.Trim)
                    item.SubItems.Add(rdr("GndUltFechaParto2").ToString.Trim)
                    item.SubItems.Add(numpart_)
                    item.SubItems.Add(rdr("GndUltPartoFormaParto").ToString.Trim)
                    item.SubItems.Add(rdr("GndUltFechaCelo").ToString.Trim)
                    item.SubItems.Add(rdr("GndUltCubierta2").ToString.Trim)
                    item.SubItems.Add(cubnum_)
                    item.SubItems.Add(rdr("ToroNombre").ToString.Trim)
                    item.SubItems.Add(fest_)
                    item.SubItems.Add(dlac_)
                    item.SubItems.Add(nace_)
                    item.SubItems.Add(fcomp_)
                    ''
                    item.SubItems.Add(fulttras_)
                    item.SubItems.Add(culttras_)
                    ''
                    item.SubItems.Add(rdr("MuestraTUB").ToString.Trim)
                    item.SubItems.Add(rdr("MuestraLEU").ToString.Trim)
                    item.SubItems.Add(rdr("MuestraBRU").ToString.Trim)
                    item.SubItems.Add(rdr("CIDR").ToString.Trim)

                    If IsDBNull(rdr("CIDRFecha")) Then
                        item.SubItems.Add("")
                    Else
                        item.SubItems.Add(Format(rdr("CIDRFecha"), "dd-MM-yyyy"))
                    End If

                    If IsDBNull(rdr("GndUlFechaRevPP")) Then
                        item.SubItems.Add("")
                    Else
                        item.SubItems.Add(Format(rdr("GndUlFechaRevPP"), "dd-MM-yyyy"))
                    End If

                    item.SubItems.Add(rdr("GndUltRevPPCondicion").ToString.Trim)
                    item.SubItems.Add(rdr("GndPesoxDia").ToString.Trim)
                    item.SubItems.Add(rdr("GndBWPadrePercent").ToString.Trim)
                    item.SubItems.Add(rdr("GndBWAbueloPercent").ToString.Trim)
                    item.SubItems.Add(rdr("GndBWBisAbueloPercent").ToString.Trim)
                    item.SubItems.Add(rdr("GndBWTotal").ToString.Trim)
                    item.SubItems.Add(diio)
                    lvGanado.Items.Add(item)

                    ProcesaTotales(rdr("GndProNom").ToString.Trim, rdr("GndEstadoProductivo").ToString.Trim, rdr("GndEstadoReproductivo").ToString.Trim)

                    i = i + 1
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
        lvGanado.EndUpdate()
        Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Private Function GeneraCadenaConsulta(ByVal chklv As CheckedListBox, Optional ByRef MuestraOtros As Integer = 0) As String
        Dim i, io, idx, idx2 As Integer
        Dim ret As String = ""

        GeneraCadenaConsulta = ""
        ret = ""
        MuestraOtros = 0

        For i = 0 To chklv.Items.Count - 1
            idx = Val(chklv.GetItemText(i))

            If chklv.GetItemCheckState(i) = CheckState.Checked And chklv.Items(idx).ToString = "(OTROS)" Then
                For io = 1 To chklv.Items.Count - 1
                    idx2 = Val(chklv.GetItemText(io))
                    ret = ret + IIf(ret = "", "", ",") + chklv.Items(idx2).ToString.Trim
                Next

                MuestraOtros = 1
                Exit For
            End If

            If chklv.GetItemCheckState(i) = CheckState.Checked Then
                ret = ret + IIf(ret = "", "", ",") + chklv.Items(idx).ToString.Trim
            End If
        Next

        GeneraCadenaConsulta = ret
    End Function


    Private Sub DetalleGanado()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvGanado.SelectedItems.Item(0).SubItems(3).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    'Private Sub PalpacionGanado()
    '    If lvGanado.Items.Count = 0 Then Exit Sub

    '    Cursor.Current = Cursors.WaitCursor

    '    Dim diio As String = lvGanado.SelectedItems.Item(0).SubItems(3).Text
    '    Dim cent As String = lvGanado.SelectedItems.Item(0).SubItems(2).Text
    '    Dim ConsPalp As New frmPalpacionesIngreso

    '    If diio = "" Then Exit Sub

    '    ConsPalp.MdiParent = frmMAIN
    '    ConsPalp.txtDIIO.Text = diio
    '    ConsPalp.ConsultaPalpaciones("", 0, diio)
    '    ConsPalp.Show()


    '    Cursor.Current = Cursors.Default
    'End Sub



    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarDatos()
    End Sub


    Public Sub BuscarDatos()
        If CadenaOrden = "" Then
            CadenaOrden = "Lectura"
            lblOrden.Text = "Lectura"
            lblOrden.Refresh()
        End If
        'CadenaOrden = "CenDesCor, GndCod"
        'lblOrden.Text = "Centro -> DIIO"
        'lblOrden.Refresh()
        Cursor.Current = Cursors.WaitCursor
        ConsultaGeneral(txtDIIOs.Text.Trim)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(26, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL POR CATEGORIA" : tot(0, 1) = ""
        tot(1, 0) = "TERNERAS" : tot(1, 1) = TotCat_Terneras
        tot(2, 0) = "TERNEROS" : tot(2, 1) = TotCat_Terneros
        tot(3, 0) = "TORETES" : tot(3, 1) = TotCat_Toretes
        tot(4, 0) = "TOROS" : tot(4, 1) = TotCat_Toros
        tot(5, 0) = "VACAS" : tot(5, 1) = TotCat_Vacas
        tot(6, 0) = "VAQUILLAS" : tot(6, 1) = TotCat_Vaquillas
        tot(7, 0) = "OTROS" : tot(7, 1) = Val(Label8.Text) - (TotCat_Terneras + TotCat_Terneros + TotCat_Toretes + TotCat_Toros + TotCat_Vacas + TotCat_Vaquillas)
        tot(8, 0) = "" : tot(8, 1) = ""

        tot(9, 0) = "TOTAL POR ESTADO PRODUCTIVO" : tot(9, 1) = ""
        tot(10, 0) = "DESCARTE" : tot(10, 1) = TotEP_Descarte
        tot(11, 0) = "DESECHO" : tot(11, 1) = TotEP_Desecho
        tot(12, 0) = "ELIMINADA EN LECHE" : tot(12, 1) = TotEP_EliminadaLeche
        tot(13, 0) = "EN PRODUCCION" : tot(13, 1) = TotEP_Produccion
        tot(14, 0) = "NO APLICA" : tot(14, 1) = TotEP_NoAplica
        tot(15, 0) = "SECA DE LECHE" : tot(15, 1) = TotEP_SecaLeche
        tot(16, 0) = "OTROS" : tot(16, 1) = Val(Label8.Text) - (TotEP_Descarte + TotEP_Desecho + TotEP_EliminadaLeche + TotEP_Produccion + TotEP_NoAplica + TotEP_SecaLeche)
        tot(17, 0) = "" : tot(17, 1) = ""

        tot(18, 0) = "TOTAL POR ESTADO REPRODUCTIVO" : tot(18, 1) = ""
        tot(19, 0) = "ANESTRO" : tot(19, 1) = TotER_Anestro
        tot(20, 0) = "CUBIERTA" : tot(20, 1) = TotER_Cubierta
        tot(21, 0) = "DESECHO REPRODUCTIVO" : tot(21, 1) = TotER_DesechoReprod
        tot(22, 0) = "DUDOSA" : tot(22, 1) = TotER_Dudosa
        tot(23, 0) = "NO APLICA" : tot(23, 1) = TotER_NoAplica
        tot(24, 0) = "PREÑADA" : tot(24, 1) = TotER_Preniada
        tot(25, 0) = "SECA PRN" : tot(25, 1) = TotER_SecaPrn
        tot(26, 0) = "OTROS" : tot(26, 1) = Val(Label8.Text) - (TotER_Anestro + TotER_Cubierta + TotER_DesechoReprod + TotER_Dudosa + TotER_NoAplica + TotER_Preniada + TotER_SecaPrn)

        ExportToExcelGrilla(lvGanado, tot)

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
            DetalleGanado()
        End If
    End Sub


    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub



    Private Function GeneraTitulo2Informe() As String
        GeneraTitulo2Informe = ""
    End Function


    Private Sub PalpacionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PalpacionToolStripMenuItem.Click
        '  PalpacionGanado()
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click

        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Private Sub mnuCopiarDiio_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(3).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Sub frmConsultaGeneralDIIOs_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(3).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If
        End If
    End Sub


    Private Sub frmConsultaGeneralDIIOs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        cboOrdenarPor.SelectedIndex = 0         'ordenar por centro
        cboTipoOrden.SelectedIndex = 0          'ascendente
        btnAlarmas.Enabled = False
    End Sub


    Private Sub txtAlarmaLector_TextChanged(sender As Object, e As EventArgs) Handles txtAlarmaLector.TextChanged
        btnAlarmas.Enabled = True
    End Sub

    Private Sub btnAlarmas_Click(sender As Object, e As EventArgs) Handles btnAlarmas.Click
        If lvGanado.Items.Count = 0 Then Exit Sub
        ExportToExcelGrillaDiio(lvGanado, txtAlarmaLector.Text.Trim)
    End Sub

    Private Sub txtAlarmaLector_MouseClick(sender As Object, e As MouseEventArgs) Handles txtAlarmaLector.MouseClick
        If txtAlarmaLector.Text = "(Texto para Alarma)" Then txtAlarmaLector.Text = ""
    End Sub
End Class
