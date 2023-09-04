

'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmPagoCubiertas
    Private TipoReporte As Integer = 0

    'contabilizacion por condicion
    Private Total_General As Integer = 0
    Private Total_Suma As Integer = 0
    'Private TotER_Preniada As Integer = 0
    'Private TotER_SecaPrn As Integer = 0
    'Private TotER_Dudosa As Integer = 0
    'Private TotER_Anestro As Integer = 0
    'Private TotER_Otros As Integer = 0

    Private ColumnSort As Integer = 0

    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "InsemNombre", "CenDesCor", "CuDetFecha", "CuDetDiio", "ToroNombre", ""}
    Private CamposOrdenResumen As String() = {"", "InsemNombre", "CenDesCor", "", "", "", ""}

    Private CadenaOrden As String = "InsemNombre, CenDesCor, CuDetFecha, CuDetDiio"


    Private Sub InicializaTotales()
        Total_General = 0
        Total_Suma = 0
        'TotER_Preniada = 0
        'TotER_SecaPrn = 0
        'TotER_Dudosa = 0
        'TotER_Anestro = 0
        'TotER_Otros = 0
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
        Label59.Text = Total_Suma.ToString.Trim()

        'Label48.Text = TotER_Preniada.ToString.Trim()
        'Label34.Text = TotER_SecaPrn.ToString.Trim()
        'Label54.Text = TotER_Dudosa.ToString.Trim()
        'Label59.Text = TotER_Anestro.ToString.Trim()
        'Label52.Text = TotER_Otros.ToString.Trim()

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


    Private Sub CboLLenaInseminadores()
        If General.Inseminadores.NroRegistros = 0 Then Exit Sub

        cboInseminadores.Items.Clear()
        cboInseminadores.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Inseminadores.NroRegistros - 1
            cboInseminadores.Items.Add(General.Inseminadores.Nombre(i))
        Next
    End Sub

    Private Sub CboLLenaToros()
        If General.Toros.NroRegistros = 0 Then Exit Sub

        cboToros.Items.Clear()
        cboToros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Toros.NroRegistros - 1
            cboToros.Items.Add(General.Toros.Nombre(i))
        Next
    End Sub


    'Public Sub FechasTemporada()
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spTemporada_PeriodoActual", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", "76011573")
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    Try
    '        con.Open()
    '        rdr = cmd.ExecuteReader()

    '        Try
    '            While rdr.Read()
    '                dtpFechaDesde.Value = rdr("TempFechaIni")
    '                dtpFechaHasta.Value = rdr("TempFechaFin")
    '            End While

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub


    Public Sub ConsultaPalpaciones(ByVal insem_ As Integer, ByVal cent_ As String, ByVal toro_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCubiertas_ListadoPagoInseminaciones", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim vresum_ As Integer = 0
        Dim vblanc_ As Integer = 0

        If chkVerResumen.Checked = True Then vresum_ = 1
        If chkVerBlancos.Checked = True Then vblanc_ = 1

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@VerResumen", vresum_)
        cmd.Parameters.AddWithValue("@VerBlancos", vblanc_)
        cmd.Parameters.AddWithValue("@Inseminador", insem_)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Toro", toro_)
        cmd.Parameters.AddWithValue("@FechaDesde", Format(dtpFechaDesde.Value, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@FechaHasta", Format(dtpFechaHasta.Value, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i As Integer = 0
        Dim sum_ As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        'If vresum_ = 0 Then
                        vret = rdr("ContRegs") + 1
                        'Else
                        '    vret = rdr("Cont")
                        'End If

                        pbProcesa.Maximum = vret
                    End If


                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("InsemNombre").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)

                    If vresum_ = 0 Then
                        item.SubItems.Add(Format(rdr("CuDetFecha"), "dd-MM-yyyy")) '+ " " + rdr("PalHora").ToString.Trim)
                        item.SubItems.Add(rdr("CuDetDiio").ToString.Trim)
                        item.SubItems.Add(rdr("ToroNombre").ToString.Trim)   'GndToroPrenez
                        item.SubItems.Add("")
                        item.SubItems.Add(rdr("GndEstado").ToString.Trim)
                        sum_ = sum_ + 1
                    Else
                        item.SubItems.Add("")
                        item.SubItems.Add("")
                        item.SubItems.Add("")
                        item.SubItems.Add(rdr("Cont").ToString.Trim)
                        item.SubItems.Add("")

                        sum_ = sum_ + rdr("Cont")
                    End If

                    lvGanado.Items.Add(item)

                    'ProcesaTotales(rdr("PlpExmOvarico").ToString.Trim)

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
        Total_Suma = sum_
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Private Sub DetalleGanado()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvGanado.SelectedItems.Item(0).SubItems(4).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'Dim OtrosCent As Integer = 0
        Dim insem_ As Integer = 0
        Dim cent_ As String = ""
        Dim toro_ As String = ""

        If cboInseminadores.SelectedIndex <> -1 And cboInseminadores.Text <> "(TODOS)" Then
            insem_ = General.Inseminadores.Codigo(cboInseminadores.SelectedIndex - 1)
        End If

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If cboToros.SelectedIndex <> -1 And cboToros.Text <> "(TODOS)" Then
            toro_ = General.Toros.Codigo(cboToros.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            If chkVerResumen.Checked Then
                CadenaOrden = "InsemNombre, CenDesCor"
                lblOrden.Text = "Inseminador -> Centro"
            Else
                CadenaOrden = "InsemNombre, CenDesCor, CuDetFecha, CuDetDiio"
                lblOrden.Text = "Inseminador -> Centro -> Fecha Ins. -> DIIO"
            End If

            lblOrden.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        'ConsultaPalpaciones(cent_, vet_, txtDIIO.Text.Trim)
        ConsultaPalpaciones(insem_, cent_, toro_)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()

        'SaveSN.SelectedNode.ForeColor = Color.AntiqueWhite

        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(2, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "CANTIDAD REGISTROS: " : tot(0, 1) = Label85.Text.Trim
        tot(1, 0) = "TOTAL INSEMINACIONES: " : tot(1, 1) = Label59.Text.Trim

        ExportToExcelGrilla(lvGanado, tot)
    End Sub



    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvGanado.ColumnClick
        If chkVerResumen.Checked Then

            If InStr(CadenaOrden, CamposOrdenResumen(e.Column)) > 0 Then Exit Sub
            If CamposOrdenResumen(e.Column) = "" Then Exit Sub

            If CadenaOrden.Trim = "" Then
                CadenaOrden = CamposOrdenResumen(e.Column)

                lblOrden.Text = lvGanado.Columns(e.Column).Text
            Else
                CadenaOrden = CadenaOrden + ", " + CamposOrdenResumen(e.Column)
                lblOrden.Text = lblOrden.Text + " -> " + lvGanado.Columns(e.Column).Text
            End If

        Else

            If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub
            If CamposOrden(e.Column) = "" Then Exit Sub

            If CadenaOrden.Trim = "" Then
                CadenaOrden = CamposOrden(e.Column)
                lblOrden.Text = lvGanado.Columns(e.Column).Text
            Else
                CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
                lblOrden.Text = lblOrden.Text + " -> " + lvGanado.Columns(e.Column).Text
            End If

        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        'If lvGanado.Items.Count = 0 Then Exit Sub

        'If e.Button = MouseButtons.Left = True Then
        '    DetalleGanado()
        'End If
    End Sub


    Private Sub chkVerResumen_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkVerResumen.CheckedChanged
        If chkVerResumen.Checked Then
            lblOrden.Text = "Inseminador -> Centro"
            CadenaOrden = "InsemNombre, CenDesCor"
        End If
    End Sub


    Private Sub frmPalpaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Inseminadores.Cargar()
        General.Toros.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        General.Inseminadores.Cargar()
        General.Toros.Cargar()

        CboLLenaCentros()
        CboLLenaInseminadores()
        CboLLenaToros()

        cboCentros.SelectedIndex = 0
        cboInseminadores.SelectedIndex = 0
        cboToros.SelectedIndex = 0

        dtpFechaDesde.Value = TemporadaFechaIni
        dtpFechaHasta.Value = TemporadaFechaFin
    End Sub



End Class