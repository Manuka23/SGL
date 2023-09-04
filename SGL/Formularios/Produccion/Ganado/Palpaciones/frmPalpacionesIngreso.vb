

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmPalpacionesIngreso
    Private TipoReporte As Integer = 0

    'contabilizacion por condicion
    Private Total_General As Integer = 0
    Private Total_Repetidos As Integer = 0
    Private TotER_Preniada As Integer = 0
    Private TotER_SecaPrn As Integer = 0
    Private TotER_Dudosa As Integer = 0
    Private TotER_Anestro As Integer = 0
    Private TotER_Otros As Integer = 0

    Private ColumnSort As Integer = 0

    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "EmpRut", "CenDesCor", "GndCod", "GndProNom", "plpfec", _
                                        "VetNom", "GndEstadoProductivo", "GndEstadoReproductivo", "PlpExmOvarico", _
                                       "PlpDias", "ToroNombre"}

    Private CadenaOrden As String = "CenDesCor, GndCod"

    Private Diios As String()


    Private Sub InicializaTotales()
        Total_General = 0
        Total_Repetidos = 0
        TotER_Preniada = 0
        TotER_SecaPrn = 0
        TotER_Dudosa = 0
        TotER_Anestro = 0
        TotER_Otros = 0
    End Sub


    Private Sub ProcesaTotales(ByVal cond_ As String)
        Select Case cond_
            Case "PRENADA" : TotER_Preniada = TotER_Preniada + 1
            Case "PREÑADA" : TotER_Preniada = TotER_Preniada + 1
            Case "SECA PRN" : TotER_SecaPrn = TotER_SecaPrn + 1
            Case "DUDOSA" : TotER_Dudosa = TotER_Dudosa + 1
            Case "ANESTRO" : TotER_Anestro = TotER_Anestro + 1
            Case Else : TotER_Otros = TotER_Otros + 1
        End Select
    End Sub


    Private Sub MuestraTotales()
        Dim ct As Integer

        If Diios.Count = Nothing Then ct = 0
        If Diios.Count > 0 Then ct = Diios.Count '- 1

        Label85.Text = Total_General.ToString.Trim
        lblRepetidos.Text = (Total_General - ct).ToString.Trim 'Total_Repetidos.ToString.Trim

        lblPreñadas.Text = TotER_Preniada.ToString.Trim()
        lblSecaPrn.Text = TotER_SecaPrn.ToString.Trim()
        lblDudosa.Text = TotER_Dudosa.ToString.Trim()
        lblAnestro.Text = TotER_Anestro.ToString.Trim()
        Label52.Text = TotER_Otros.ToString.Trim()

        pnlEstReprod.Refresh()
    End Sub


    Private Sub LimpiarFiltros(Optional ByVal LimpiaTipoReporte As Boolean = True, Optional ByVal idx As Integer = 0)
        cboCentros.SelectedIndex = 0
        cboVeterinarios.SelectedIndex = 0
        cboCondiciones.SelectedIndex = 0
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


    Private Sub CboLLenaVeterinarios()
        If General.Veterinarios.NroRegistros = 0 Then Exit Sub

        cboVeterinarios.Items.Clear()
        cboVeterinarios.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Veterinarios.NroRegistros - 1
            cboVeterinarios.Items.Add(General.Veterinarios.Nombre(i))
        Next
    End Sub


    'Public Sub FechasTemporada()
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spTemporada_PeriodoActual", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
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


    Private Sub VerificaYMarcaPalpacionesRepetidas(ByVal diio1 As String, ByVal fecha As String)
        Dim l1 As Integer = 0
        Dim l2 As Integer = 0
        'Dim diio1 As String = ""
        Dim diio2 As String = ""
        Dim fec As DateTime
        Dim f2 As String = ""

        For l1 = 0 To lvPALPACIONES.Items.Count - 2

            diio2 = lvPALPACIONES.Items(l1).SubItems(4).Text
            fec = lvPALPACIONES.Items(l1).SubItems(6).Text
            f2 = Format(fec, "dd-MM-yyyy")

            If diio1 = diio2 And fecha = f2 Then

                'MsgBox(diio1)

                lvPALPACIONES.Items(l1).BackColor = Color.Yellow
                Total_Repetidos = Total_Repetidos + 1

            End If
        Next
    End Sub


    Private Sub AgregaDiioSiNoExiste(ByVal diio As String)
        Dim i As Integer
        Dim Existe As Boolean = False

        For i = 0 To Diios.Count - 1
            If Diios(i) = diio Then
                Existe = True
            End If
        Next

        If Not Existe Then
            ReDim Preserve Diios(i)
            Diios(i) = diio
        End If
    End Sub

    Public Sub ConsultaPalpaciones(ByVal cent_ As String, ByVal vet_ As Integer, ByVal Condicion As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        'lvGanado.Items.Clear()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPalpaciones_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Veterinario", vet_)
        cmd.Parameters.AddWithValue("@Condicion", Condicion)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvPALPACIONES.BeginUpdate()
        lvPALPACIONES.Items.Clear()
        Diios = {}

        InicializaTotales()
        MuestraTotales()

        Dim i, i2 As Integer
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0
        Dim vetnom_ As String = ""
        Dim DiioPalpacion As String = ""
        Dim SinRepetidos As Boolean = False 'chkConTres.Checked

        i = 0
        i2 = 0
        If cboVeterinarios.SelectedIndex > 0 Then vetnom_ = cboVeterinarios.Text


        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    DiioPalpacion = rdr("GndCod").ToString.Trim


                    If (vetnom_ = "") Or (vetnom_ <> "" And vetnom_ = rdr("VetNom").ToString.Trim) Then

                        AgregaDiioSiNoExiste(DiioPalpacion)

                        Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

                        item.SubItems.Add((i + 1).ToString.Trim)
                        item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                        item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                        item.SubItems.Add(rdr("GndCod").ToString.Trim)
                        item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                        item.SubItems.Add(Format(rdr("fecha_hora"), "dd-MM-yyyy HH:mm"))
                        item.SubItems.Add(rdr("VetNom").ToString.Trim)
                        item.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)
                        item.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                        item.SubItems.Add(rdr("PlpExmOvarico").ToString.Trim)
                        item.SubItems.Add(rdr("PlpDias").ToString.Trim)
                        item.SubItems.Add(rdr("ToroNombre").ToString.Trim)

                        lvPALPACIONES.Items.Add(item)
                        ProcesaTotales(rdr("PlpExmOvarico").ToString.Trim)

                        i2 = i2 + 1
                    End If

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
        lvPALPACIONES.EndUpdate()
        Total_General = i2
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Private Sub DetalleGanado()
        If lvPALPACIONES.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvPALPACIONES.SelectedItems.Item(0).SubItems(4).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFiltros.Click
        LimpiarFiltros()
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'Dim OtrosCent As Integer = 0
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If cboVeterinarios.SelectedIndex <> -1 And cboVeterinarios.Text <> "(TODOS)" Then
            vet_ = General.Veterinarios.Codigo(cboVeterinarios.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "CenDesCor, GndCod"
            lblOrden.Text = "Centro -> DIIO"
            lblOrden.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaPalpaciones(cent_, vet_, cboCondiciones.Text)
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
        If lvPALPACIONES.Items.Count = 0 Then Exit Sub

        Dim tot(7, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL PALPACIONES " : tot(0, 1) = Label85.Text.Trim
        tot(1, 0) = "REPETIDOS" : tot(1, 1) = lblRepetidos.Text
        tot(2, 0) = "PREÑADAS" : tot(2, 1) = lblPreñadas.Text
        tot(3, 0) = "SECAS PRN" : tot(3, 1) = lblSecaPrn.Text
        tot(4, 0) = "DUDOSA" : tot(4, 1) = lblDudosa.Text
        tot(5, 0) = "ANESTRO" : tot(5, 1) = lblAnestro.Text
        tot(6, 0) = "OTRAS" : tot(6, 1) = Label52.Text

        ExportToExcelGrilla(lvPALPACIONES, tot)
    End Sub



    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        frmPalpacionesIngresoDIIO.MdiParent = frmMAIN
        frmPalpacionesIngresoDIIO.Show()
        frmPalpacionesIngresoDIIO.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Private Sub dtpFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
    End Sub


    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Cursor.Current = Cursors.WaitCursor

        'OpenFDlg.FileName = ""
        'OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        'OpenFDlg.ShowDialog()

        'If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        'frmPalpacionesImportacion.ArchivoImportacion = OpenFDlg.FileName.Trim()
        frmPalpacionesImportacion.MdiParent = frmMAIN
        frmPalpacionesImportacion.Show()

        'Dim imp As New frmPalpacionesImportacion(OpenFDlg.FileName.Trim)

        'imp.MdiParent = frmMAIN
        'imp.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvGanado_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPALPACIONES.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrden.Text = lvPALPACIONES.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrden.Text = lblOrden.Text + " -> " + lvPALPACIONES.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvPALPACIONES.MouseDoubleClick
        If lvPALPACIONES.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub


    Private Sub frmPalpaciones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If lvPALPACIONES.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvPALPACIONES.SelectedItems(0).SubItems(4).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If

            'If e.KeyCode = Keys.V Then
            '    MsgBox("chao")
            'End If

        End If
    End Sub

    Private Sub CboLLenaCondiciones()
        If General.Condiciones.NroRegistros = 0 Then Exit Sub
        cboCondiciones.Items.Clear()
        cboCondiciones.Items.Add("(TODOS)")
        Dim i As Integer

        For i = 0 To General.Condiciones.NroRegistros - 1
            cboCondiciones.Items.Add(General.Condiciones.Nombre(i))
        Next
    End Sub
    Private Sub frmPalpaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True
        CboLLenaCondiciones()
        CboLLenaCentros()
        CboLLenaVeterinarios()

        cboCentros.Text = CentroPorDefecto()
        dtpFechaDesde.Value = Now
        dtpFechaHasta.Value = Now

        cboCondiciones.SelectedIndex = 0
        cboVeterinarios.SelectedIndex = 0
    End Sub


    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub

    Private Sub mnuCopiarDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvPALPACIONES.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvPALPACIONES.SelectedItems(0).SubItems(4).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub

    Private Sub txtDIIO_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class