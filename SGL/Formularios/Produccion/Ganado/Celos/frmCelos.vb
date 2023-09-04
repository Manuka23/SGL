Imports System.Data.SqlClient

Public Class frmCelos

    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "CentroNomCorto", "CeloFecha", "CeloTotRegs", "CeloObserbs"}

    Private CadenaOrden As String = "CentroNomCorto, CeloFecha"
    Private CentroCod As Integer = 0

    Private Sub frmCelos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        MSTRUsuarios.DSCboUsuarioCentros_FrmQRY(True, cboCentros)
        cboCentros.Text = UsuarioCentroNomDefault
        CentroCod = UsuarioCentroCodDefault

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
    End Sub

    Private Function TotalVacas() As Integer
        TotalVacas = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_TotalVacas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""

        'If cboCentros.SelectedIndex > 0 And cboCentros.Text <> "(TODOS)" Then 'comentado el 04-05-2021
        ' cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        'End If

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@RetTotVacas", SqlDbType.Int) : cmd.Parameters("@RetTotVacas").Direction = ParameterDirection.Output
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            Dim vret As Integer = cmd.Parameters("@RetTotVacas").Value

            TotalVacas = vret

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
    Public Sub ConsultaCelos(ByVal cent_ As String, ByVal diio_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_Listado", con)
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
        '
        lvCELOS.BeginUpdate()
        lvCELOS.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim totvacas As Integer = 0
        Dim totcelos As Integer = 0

        Label48.Text = "0"
        Label4.Text = "0"
        Label6.Text = "0"

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

                    item.SubItems.Add(rdr("CeloEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("CentroNomCorto").ToString.Trim)                  'centro
                    item.SubItems.Add(Format(rdr("CeloFecha"), "dd-MM-yyyy HH:mm:ss"))    '+ " " + rdr("PalHora").ToString.Trim)
                    item.SubItems.Add(rdr("CeloTotRegs").ToString.Trim)
                    item.SubItems.Add(rdr("CeloObserbs").ToString.Trim)
                    item.SubItems.Add(rdr("CeloCentro").ToString.Trim)

                    lvCELOS.Items.Add(item)

                    totcelos = totcelos + rdr("CeloTotRegs")

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
        lvCELOS.EndUpdate()

        totvacas = TotalVacas()

        Label48.Text = totvacas.ToString.Trim
        Label4.Text = totcelos.ToString.Trim
        Label6.Text = (totvacas - totcelos).ToString.Trim

        pnlProcesa.Visible = False
    End Sub
    Public Sub LlenaGrilla()
        'Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim causa_ As String = ""

        'If cboCentros.SelectedIndex > 0 And cboCentros.Text <> "(TODOS)" Then 'comentado el 04-05-2021
        '    cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        'End If

        If CadenaOrden = "" Then
            CadenaOrden = "CentroNomCorto, CeloFecha"
            lblOrdena.Text = "Centro -> Fecha Celo"
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaCelos(CentroCod, txtDIIO.Text.Trim)
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

        Dim tot(1, 2) As String
        tot(0, 0) = "TOTAL REGISTROS:" : tot(0, 1) = Label48.Text.Trim

        ExportToExcelGrilla(lvCELOS, tot)
    End Sub
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        frmCelosIngreso.Param1_Modo = 1   'nuevo

        frmCelosIngreso.MdiParent = frmMAIN
        frmCelosIngreso.Show()
        frmCelosIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub
    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCELOS.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvCELOS.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvCELOS.Columns(e.Column).Text
        End If
    End Sub
    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCELOS.MouseDoubleClick
        If lvCELOS.Items.Count = 0 Then Exit Sub
        If lvCELOS.SelectedItems.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then

            With frmCelosIngreso
                .Param1_Modo = 2   'edita (elimina)
                .Param2_Empresa = Empresa
                .Param3_CentroCod = lvCELOS.SelectedItems.Item(0).SubItems(6).Text
                .Param3_CentroNom = lvCELOS.SelectedItems.Item(0).SubItems(2).Text
                .Param4_FechaDesde = dtpFechaDesde.Value 'lvCELOS.SelectedItems.Item(0).SubItems(3).Text
                .Param4_FechaHasta = dtpFechaHasta.Value
                .Param5_Observs = lvCELOS.SelectedItems.Item(0).SubItems(5).Text
            End With


            Cursor.Current = Cursors.WaitCursor

            frmCelosIngreso.MdiParent = frmMAIN
            frmCelosIngreso.Show()
            frmCelosIngreso.BringToFront()

            frmCelosIngreso.cboCentros.Enabled = False
            frmCelosIngreso.txtDIIO.Enabled = False
            frmCelosIngreso.dtpFecha.Enabled = False
            frmCelosIngreso.txtObservs.Enabled = False
        End If
    End Sub
    Private Sub btnGanadoSinCelo_Click(sender As System.Object, e As System.EventArgs) Handles btnGanadoSinCelo.Click
        VerDetalleGanado(3)
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnCelosAnormales.Click
        VerDetalleGanado(4)
    End Sub
    Private Sub VerDetalleGanado(ByVal Modo As Integer)

        Dim centcod_ As String = ""
        Dim centnom_ As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            centcod_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
            centnom_ = General.CentrosUsuario.Nombre(cboCentros.SelectedIndex - 1)
        End If


        Cursor.Current = Cursors.WaitCursor

        With frmCelosIngreso
            .Param1_Modo = Modo
            .Param2_Empresa = Empresa
            .Param3_CentroCod = centcod_
            .Param3_CentroNom = centnom_
            .Param4_FechaDesde = dtpFechaDesde.Value
            .Param4_FechaHasta = dtpFechaHasta.Value
            .Param5_Observs = ""

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            .cboCentros.Enabled = False
            .txtDIIO.Enabled = False
            .dtpFecha.Enabled = False
            .dtpFechaDesde.Enabled = False
            .dtpFechaHasta.Enabled = False
            .txtObservs.Enabled = False
            .btnEliminar.Visible = False

            .btnExcel.Left = .btnFinalizar.Left
            .btnExcel.Visible = True

            .gboxRangoFecha.Visible = True
            .gboxFecha.Visible = False
            .gboxObservs.Visible = False
        End With
    End Sub
    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboCentros.SelectedItem, DataRowView)
        If Not selectedRow Is Nothing Then CentroCod = selectedRow("CentroCod")

        LlenaGrilla()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim centro As String = lvCELOS.SelectedItems.Item(0).SubItems(6).Text
        Dim fecha As DateTime = lvCELOS.SelectedItems.Item(0).SubItems(3).Text
        EliminarCelo(centro, fecha)
    End Sub
    Private Sub EliminarCelo(ByVal centro As String, ByVal fecha As DateTime)
        If lvCELOS.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR LA SESION DE CELO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If EliminarSesionCelo(centro, fecha) = True Then
                If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    LlenaGrilla()
                End If


            End If
        End If
    End Sub
    Private Function EliminarSesionCelo(ByVal centro As String, ByVal fecha As DateTime) As Boolean
        EliminarSesionCelo = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_EliminarSesion", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            EliminarSesionCelo = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
End Class