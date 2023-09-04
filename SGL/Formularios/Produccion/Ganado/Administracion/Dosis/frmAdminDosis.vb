

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmAdminDosis
    '    Private TipoReporte As Integer = 0

    'contabilizacion por condicion
    Private Total_Comprados As Integer = 0
    Private Total_Entregados As Integer = 0
    Private Total_Libres As Integer = 0
    Private Total_Usados As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "DSemProveedor", "DSemCentro", "DSemFechaRecep", "DSemTotalComprados", _
                                       "DSemTotalEntregados", "DSemTotalLibres", "DSemTotalUsados", "DSemObservs"}

    Private CadenaOrden As String = "DSemFechaRecep"


    Private Sub InicializaTotales()
        Total_Comprados = 0
        Total_Entregados = 0
        Total_Libres = 0
        Total_Usados = 0
    End Sub


    Private Sub ProcesaTotales(ByVal prov_ As String, ByVal comp_ As Integer, ByVal ent_ As Integer, ByVal lib_ As Integer, ByVal usad_ As Integer)
        If prov_ <> "" And prov_.Trim <> "NO USAR" Then
            Total_Comprados = Total_Comprados + comp_
            Total_Entregados = Total_Entregados + ent_
            Total_Libres = Total_Libres + lib_
            Total_Usados = Total_Usados + usad_
        End If
    End Sub


    Private Sub MuestraTotales()
        'Label85.Text = Total_General.ToString.Trim

        Label48.Text = Total_Comprados.ToString.Trim()
        Label34.Text = Total_Entregados.ToString.Trim()
        Label6.Text = Total_Libres.ToString.Trim()
        Label4.Text = Total_Usados.ToString.Trim()

        pnlEstReprod.Refresh()
    End Sub


    Private Sub CboLLenaProveedores()
        If General.Proveedores.NroRegistros = 0 Then Exit Sub

        cboProveedores.Items.Clear()
        cboProveedores.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Proveedores.NroRegistros - 1
            cboProveedores.Items.Add(General.Proveedores.NombreRut(i))
        Next
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaToros()
        If General.Toros.NroRegistros = 0 Then Exit Sub
        cboToros.Items.Clear()

        cboToros.Items.Clear()
        cboToros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Toros.NroRegistros - 1
            cboToros.Items.Add(General.Toros.Nombre(i))
        Next
    End Sub


    Public Sub ConsultaDosisSemen(ByVal pprov_ As String, ByVal ptoro_ As String, pcent_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDosis_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Proveedor", pprov_)
        cmd.Parameters.AddWithValue("@Toro", ptoro_)
        cmd.Parameters.AddWithValue("@Centro", pcent_)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i, vret, pos_, col_ As Integer
        Dim toro_ As String = "", toro_ant_ As String = ""
        Dim color_ As Color

        vret = 0
        toro_ = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    If rdr("ToroNombre").ToString.Trim = toro_ant_ Then
                        toro_ = "" 'rdr("ToroNombre").ToString.Trim
                        'toro_ant_ = rdr("ToroNombre").ToString.Trim
                    Else
                        toro_ = rdr("ToroNombre").ToString.Trim
                        toro_ant_ = toro_ 'rdr("ToroNombre").ToString.Trim
                    End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("DSemEmpresa").ToString.Trim)
                    item.SubItems.Add(Format(rdr("DSemFechaRecep"), "dd-MM-yyyy"))    '+ " " + rdr("PalHora").ToString.Trim)
                    item.SubItems.Add(rdr("PrvRazSoc").ToString.Trim)               'proveedor
                    item.SubItems.Add(toro_)               'Toro
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)               'Centro
                    item.SubItems.Add(rdr("DSemTotalComprados").ToString.Trim)
                    item.SubItems.Add(rdr("DSemTotalEntregados").ToString.Trim)
                    item.SubItems.Add(rdr("DSemTotalLibres").ToString.Trim)
                    item.SubItems.Add(rdr("DSemTotalUsados").ToString.Trim)

                    item.SubItems.Add(rdr("DSemObservs").ToString.Trim)

                    item.SubItems.Add(rdr("DSemCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("DSemProveedor").ToString.Trim)
                    'item.SubItems.Add(rdr("TipDocNom").ToString.Trim)
                    item.SubItems.Add(rdr("TipDocNom").ToString.Trim)
                    item.SubItems.Add(FormateaRUT(IIf(IsDBNull(rdr("PrvCod")), 0, rdr("PrvCod")), IIf(IsDBNull(rdr("PrvDV")), "", rdr("PrvDV"))) + " - " + rdr("PrvRazSoc").ToString.Trim)
                    item.SubItems.Add(rdr("ToroCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("CenCod").ToString.Trim)
                    item.SubItems.Add(rdr("DSemNroDoc").ToString.Trim)
                    item.SubItems.Add(Format(rdr("DSemFechaDoc"), "dd-MM-yyyy"))

                    lvGanado.Items.Add(item)

                    ProcesaTotales(rdr("PrvRazSoc").ToString.Trim, rdr("DSemTotalComprados"), rdr("DSemTotalEntregados"), rdr("DSemTotalLibres"), rdr("DSemTotalUsados"))

                    pos_ = lvGanado.Items.Count - 1
                    lvGanado.Items(pos_).UseItemStyleForSubItems = False

                    If rdr("PrvRazSoc").ToString.Trim <> "" Then
                        col_ = 0
                        color_ = Color.LightSeaGreen
                    End If

                    If rdr("ToroNombre").ToString.Trim <> "" Then
                        col_ = 4
                        color_ = Color.LightBlue
                    End If

                    If rdr("CentroNom").ToString.Trim <> "" Then
                        col_ = 5
                        color_ = Color.LightGreen
                    End If

                    For e = col_ To lvGanado.Columns.Count - 1
                        lvGanado.Items(pos_).SubItems(e).BackColor = color_
                    Next

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
        'Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Private Sub DetalleCompraDosis()
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Me.Enabled = False

        frmAdminDosisIngreso.Param0_ModoIngreso = 2     'mostrar ingreso dosis

        frmAdminDosisIngreso.Param1_Empresa = lvGanado.SelectedItems(0).SubItems(1).Text
        frmAdminDosisIngreso.Param2_Codigo = lvGanado.SelectedItems(0).SubItems(11).Text
        frmAdminDosisIngreso.Param3_ProveedorCod = lvGanado.SelectedItems(0).SubItems(12).Text
        frmAdminDosisIngreso.Param3_ProveedorNom = lvGanado.SelectedItems(0).SubItems(3).Text
        frmAdminDosisIngreso.Param4_NroDoc = lvGanado.SelectedItems(0).SubItems(17).Text
        frmAdminDosisIngreso.Param5_TipoDoc = lvGanado.SelectedItems(0).SubItems(13).Text           'nombre tipo documento
        frmAdminDosisIngreso.Param6_FechaRecep = lvGanado.SelectedItems(0).SubItems(2).Text
        frmAdminDosisIngreso.Param7_FechaDoc = lvGanado.SelectedItems(0).SubItems(18).Text
        frmAdminDosisIngreso.Param8_Observs = lvGanado.SelectedItems(0).SubItems(10).Text
        frmAdminDosisIngreso.Param9_RutNomProd = lvGanado.SelectedItems(0).SubItems(14).Text

        frmAdminDosisIngreso.MdiParent = frmMAIN
        frmAdminDosisIngreso.Show()
        frmAdminDosisIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub LlenaGrilla()
        Dim prov_ As Integer = 0
        Dim toro_ As String = "", cent_ As String = ""

        If cboProveedores.SelectedIndex <> -1 And cboProveedores.Text <> "(TODOS)" Then
            prov_ = General.Proveedores.Codigo(cboProveedores.SelectedIndex - 1)
        End If

        If cboToros.SelectedIndex <> -1 And cboToros.Text <> "(TODOS)" Then
            toro_ = General.Toros.Codigo(cboToros.SelectedIndex - 1)
        End If

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "DSemFechaRecep"
            lblOrdena.Text = "Fecha Recep."
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaDosisSemen(prov_, toro_, cent_)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrilla()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvGanado.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvGanado.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvGanado.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub
        If lvGanado.SelectedItems(0).SubItems(3).Text.Trim = "" Then Exit Sub 'si no hay proveedor no es el encabezado de la compra

        If e.Button = MouseButtons.Left = True Then
            DetalleCompraDosis()
        End If
    End Sub


    Private Sub frmAdminDosis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Toros.Cargar()
        General.TipoDocumentos.Cargar()
        General.Proveedores.Cargar()
        General.Recepcionadores.Cargar()
        General.Razas.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        General.Toros.Cargar()

        CboLLenaProveedores()
        CboLLenaToros()
        CboLLenaCentros()

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
        cboProveedores.SelectedIndex = 0
        cboToros.SelectedIndex = 0
        cboCentros.SelectedIndex = 0

        LlenaGrilla()
    End Sub


    Private Sub btnComprar_Click(sender As System.Object, e As System.EventArgs) Handles btnComprar.Click
        Me.Enabled = False

        frmAdminDosisIngreso.Param0_ModoIngreso = 1     'nuevo ingreso dosis

        frmAdminDosisIngreso.MdiParent = frmMAIN
        frmAdminDosisIngreso.Show()
        frmAdminDosisIngreso.BringToFront()
    End Sub


    Private Sub btnEntregar_Click(sender As System.Object, e As System.EventArgs) Handles btnEntregar.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub
        If lvGanado.SelectedItems(0).SubItems(4).Text.Trim = "" Then Exit Sub 'tiene que existir un toro
        Me.Enabled = False

        Dim comp_, cod_, nom_, lib_ As String

        comp_ = lvGanado.SelectedItems(0).SubItems(11).Text     'codigo compra
        cod_ = lvGanado.SelectedItems(0).SubItems(15).Text      'codigo toro
        nom_ = lvGanado.SelectedItems(0).SubItems(4).Text       'nombre toro
        lib_ = lvGanado.SelectedItems(0).SubItems(8).Text      'dosis libres

        With frmAdminDosisEntrega
            .Param0_CodigoCompra = comp_
            .Param1_CodigoToro = cod_
            .Param2_NombreToro = nom_
            .Param4_DosisLibres = lib_

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With
    End Sub


    Private Sub btnAsignar_Click(sender As System.Object, e As System.EventArgs)
        Me.Enabled = False

        'frmAdminDosisAsignacion.MdiParent = frmMAIN
        'frmAdminDosisAsignacion.Show()
        'frmAdminDosisAsignacion.BringToFront()
    End Sub


    Private Sub btnReasignar_Click(sender As System.Object, e As System.EventArgs) Handles btnReasignar.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub
        If lvGanado.SelectedItems(0).SubItems(15).Text.Trim = "" Then Exit Sub 'tiene que existir un codigo de toro
        If lvGanado.SelectedItems(0).SubItems(5).Text.Trim = "" Then Exit Sub 'tiene que existir una entrega (sala)

        Me.Enabled = False

        Dim comp_, cod_, nom_, cent_, codcent_, lib_ As String

        comp_ = lvGanado.SelectedItems(0).SubItems(11).Text     'codigo compra
        cod_ = lvGanado.SelectedItems(0).SubItems(15).Text      'codigo toro
        nom_ = lvGanado.SelectedItems(0).SubItems(4).Text       'nombre toro
        cent_ = lvGanado.SelectedItems(0).SubItems(5).Text      'nombre centro
        codcent_ = lvGanado.SelectedItems(0).SubItems(16).Text  'codigo centro
        lib_ = lvGanado.SelectedItems(0).SubItems(8).Text       'dosis libres

        With frmAdminDosisDevolucion
            .Param0_CodigoCompra = comp_
            .Param1_CodigoToro = cod_
            .Param2_NombreToro = nom_
            .Param3_CodigoCentro = codcent_
            .Param4_NombreCentro = cent_
            .Param5_DosisLibres = lib_

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With
    End Sub


    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        'tot(0, 0) = "CENTRO: " : tot(0, 1) = cboCentros.Text
        'tot(1, 0) = "CUBIERTAS DESDE: " : tot(1, 1) = Format(dtpFechaDesde.Value, "dd-MM-yyyy") + " AL " + Format(dtpFechaHasta.Value, "dd-MM-yyyy")
        'tot(2, 0) = "TOTAL CUBIERTAS: " : tot(2, 1) = lvDIIOS.Items.Count.ToString

        ExportToExcelGrillaCamposVisible(lvGanado, tot)
    End Sub
End Class