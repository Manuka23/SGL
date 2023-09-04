

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmAdminDiios
    '    Private TipoReporte As Integer = 0

    'contabilizacion por condicion
    Private Total_Comprados As Integer = 0
    Private Total_Entregados As Integer = 0
    Private Total_Libres As Integer = 0
    Private Total_Usados As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "ADProveedor", "ADCentro", "ADFechaRecep", "ADNumInicial", "ADNumFinal", _
                                        "ADTotalComprados", "ADTotalEntregados", "ADTotalLibres", "ADTotalUsados", "ADTotalFallas"}

    Private CadenaOrden As String = "ADFechaRecep"


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


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
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


    Public Sub ConsultaIngresoDiios(ByVal cent_ As String, ByVal prov_ As Integer, ByVal diio_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDiios_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Proveedor", prov_)
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

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
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


                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                    item.SubItems.Add(rdr("PrvRazSoc").ToString.Trim)               'proveedor
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)                  'centro
                    item.SubItems.Add(Format(rdr("ADFechaRecep"), "dd-MM-yyyy"))    '+ " " + rdr("PalHora").ToString.Trim)
                    item.SubItems.Add(rdr("ADNumInicial").ToString.Trim)
                    item.SubItems.Add(rdr("ADNumFinal").ToString.Trim)
                    item.SubItems.Add(rdr("ADTotalComprados").ToString.Trim)
                    item.SubItems.Add(rdr("ADTotalEntregados").ToString.Trim)
                    item.SubItems.Add(rdr("ADTotalLibres").ToString.Trim)
                    item.SubItems.Add(rdr("ADTotalUsados").ToString.Trim)
                    item.SubItems.Add(rdr("ADTotalFallas").ToString.Trim)
                    item.SubItems.Add(rdr("ADObservs").ToString.Trim)
                    item.SubItems.Add(rdr("ADCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("ADCentro").ToString.Trim)
                    item.SubItems.Add(rdr("UsrNombre").ToString.Trim)

                    lvGanado.Items.Add(item)

                    ProcesaTotales(rdr("PrvRazSoc").ToString.Trim, rdr("ADTotalComprados"), rdr("ADTotalEntregados"), rdr("ADTotalLibres"), rdr("ADTotalUsados"))

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


    Private Sub DetalleAsignaciones()
        If lvGanado.Items.Count = 0 Then Exit Sub
        Dim usad_ As Integer = lvGanado.SelectedItems.Item(0).SubItems(10).Text
        If usad_ = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim cod_ As Integer = lvGanado.SelectedItems.Item(0).SubItems(13).Text
        Dim cent_ As String = lvGanado.SelectedItems.Item(0).SubItems(3).Text
        Dim fecha As DateTime = DateTime.Parse(lvGanado.SelectedItems.Item(0).SubItems(4).Text)
        Dim ConsultaAsign = New frmAdminAsignaciones

        'If diio = "" Then Exit Sub

        Me.Enabled = False

        ConsultaAsign.MdiParent = frmMAIN
        ConsultaAsign.lblCentro.Text = cent_
        ConsultaAsign.ConsultaAsignaciones(cod_)
        ConsultaAsign.ConsultaLibres(cod_, cent_, fecha)

        ConsultaAsign.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Public Sub LlenaGrilla()
        Dim prov_ As Integer = 0
        Dim cent_ As String = ""

        If cboProveedores.SelectedIndex <> -1 And cboProveedores.Text <> "(TODOS)" Then
            prov_ = General.Proveedores.Codigo(cboProveedores.SelectedIndex - 1)
        End If

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "ADFechaRecep"
            lblOrdena.Text = "Fecha Recep."
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaIngresoDiios(cent_, prov_, txtDIIO.Text.Trim)
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
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleAsignaciones()
        End If
    End Sub


    Private Sub frmAdminDiios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.TipoFallasDiios.Cargar()
        General.TipoDocumentos.Cargar()
        General.Proveedores.Cargar()
        General.Recepcionadores.Cargar()
        General.TipoAsignDiios.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaProveedores()

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
        cboProveedores.SelectedIndex = 0
        cboCentros.SelectedIndex = 0
    End Sub


    Private Sub btnComprar_Click(sender As System.Object, e As System.EventArgs) Handles btnComprar.Click
        Me.Enabled = False

        frmAdminDiiosIngreso.MdiParent = frmMAIN
        frmAdminDiiosIngreso.Show()
        frmAdminDiiosIngreso.BringToFront()
    End Sub


    Private Sub btnEntregar_Click(sender As System.Object, e As System.EventArgs) Handles btnEntregar.Click
        Me.Enabled = False

        frmAdminDiiosEntrega.MdiParent = frmMAIN
        frmAdminDiiosEntrega.Show()
        frmAdminDiiosEntrega.BringToFront()
    End Sub


    Private Sub btnAsignar_Click(sender As System.Object, e As System.EventArgs) Handles btnAsignar.Click
        Me.Enabled = False

        frmAdminDiiosAsignacion.MdiParent = frmMAIN
        frmAdminDiiosAsignacion.Show()
        frmAdminDiiosAsignacion.BringToFront()
    End Sub


    Private Sub btnReasignar_Click(sender As System.Object, e As System.EventArgs) Handles btnReasignar.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub
        If lvGanado.SelectedItems(0).SubItems(2).Text <> "0" Then Exit Sub 'si tiene proveedor es una compra de diios

        Me.Enabled = False

        Dim cod_corr As String = lvGanado.SelectedItems(0).SubItems(13).Text           'codigo cliente
        Dim cod_cent_ As String = lvGanado.SelectedItems(0).SubItems(14).Text          '
        Dim nom_cent_ As String = lvGanado.SelectedItems(0).SubItems(3).Text               '
        Dim recep_ As String = lvGanado.SelectedItems(0).SubItems(15).Text            '
        'Dim nom_tdoc_ As String = lvGanado.SelectedItems(0).SubItems(3).Text            '
        Dim desde_ As String = lvGanado.SelectedItems(0).SubItems(5).Text            '
        Dim hasta_ As String = lvGanado.SelectedItems(0).SubItems(6).Text            '
        Dim fecha_ As String = lvGanado.SelectedItems(0).SubItems(4).Text            '

        With frmAdminDiiosReasignar
            '.Correlativos = Correlativos
            .Param0_CodigoCorr = Convert.ToInt32(cod_corr)
            .Param1_CodigoCentro = cod_cent_
            .Param1_NombreCentro = nom_cent_
            .Param2_Recepcionador = recep_
            '.Param2_NombreTipoDoc = nom_tdoc_
            .Param3_Desde = Convert.ToInt32(desde_)
            .Param4_Hasta = Convert.ToInt32(hasta_)
            .Param5_Fecha = Convert.ToDateTime(fecha_)

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

    End Sub
End Class