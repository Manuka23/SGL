

Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient



Public Class frmPartosIngreso

    Public Param0_ModoIngreso As Integer           '1 = nuevo  /  2 = consulta partos
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_FechaDesde As Date
    Public Param4_FechaHasta As Date
    Private Listado As Integer = 0
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas



    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        'cboCentros.SelectedIndex = 0
    End Sub

    Private Sub lvPARTOS_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvPARTOS.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvPARTOS, e)
    End Sub
    Private Sub DetalleCrias()
        Dim diio_ As String = lvPARTOS.SelectedItems(0).SubItems(3).Text            'diio madre
        Dim fec_ As Date = Date.Parse(lvPARTOS.SelectedItems(0).SubItems(6).Text)             'fecha parto
        Dim centro As String = lvPARTOS.SelectedItems(0).SubItems(15).Text
        frmPartosIngresoDiios.Param0_ModoIngreso = 2     'consulta detalle parto (crias)
        frmPartosIngresoDiios.Param1_CodigoCentro = centro
        frmPartosIngresoDiios.Param2_NombreCentro = cboCentros.Text
        'frmPartosIngresoDiios.cboCentros.Text = cboCentros.Text
        frmPartosIngresoDiios.Param3_Fecha = fec_
        frmPartosIngresoDiios.Param4_DIIO_Madre = diio_

        frmPartosIngresoDiios.MdiParent = frmMAIN
        frmPartosIngresoDiios.Show()
        frmPartosIngresoDiios.BringToFront()
    End Sub


    Private Sub DetalleGanado()
        If lvPARTOS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvPARTOS.SelectedItems.Item(0).SubItems(3).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CopiarDiio()
        If lvPARTOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvPARTOS.SelectedItems(0).SubItems(3).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Sub BuscarDetalle()

        ' Dim centro As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPartos_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@Empresa", Empresa)


        If cboCentros.Text <> "(TODOS)" Then
            If Param0_ModoIngreso = 1 Then
                Param1_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
            End If
            cmd.Parameters.AddWithValue("@Centro", Param1_CodigoCentro)
        Else
            cmd.Parameters.AddWithValue("@Centro", "(TODOS)")
        End If

        cmd.Parameters.AddWithValue("@FechaDesde", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@PartoTipo", cboTipoParto.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvPARTOS.BeginUpdate()
        lvPARTOS.Items.Clear()

        lblTotPartos.Text = "0"
        lblTotCrias.Text = "0"
        lblTotHembras.Text = "0"
        lblTotSexadas.Text = "0"

        Dim i As Integer = 0
        Dim crias As Integer = 0
        Dim hembras As Integer = 0
        Dim machos As Integer = 0
        Dim sexadas As Integer = 0
        Dim tot_crias As Integer = 0
        Dim tot_hembras As Integer = 0
        Dim tot_machos As Integer = 0
        Dim tot_sexadas As Integer = 0
        Dim tot_muertos As Integer = 0
        Dim tot_abortos As Integer = 0
        'Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                    '
                    crias = 0
                    hembras = 0
                    machos = 0
                    sexadas = 0
                    '
                    If (rdr("PartoSexoCria1").ToString.Trim <> "ND") And (rdr("PartoTipo").ToString.Trim <> "T. MUERTO") And (rdr("PartoTipo").ToString.Trim <> "ABORTO") Then crias = crias + 1
                    If (rdr("PartoSexoCria2").ToString.Trim <> "ND") And (rdr("PartoTipo").ToString.Trim <> "T. MUERTO") And (rdr("PartoTipo").ToString.Trim <> "ABORTO") Then crias = crias + 1
                    '
                    If rdr("PartoSexoCria1").ToString.Trim = "HEMBRA" And (rdr("PartoTipo").ToString.Trim <> "T. MUERTO") And (rdr("PartoTipo").ToString.Trim <> "ABORTO") Then hembras = hembras + 1
                    If rdr("PartoSexoCria2").ToString.Trim = "HEMBRA" And (rdr("PartoTipo").ToString.Trim <> "T. MUERTO") And (rdr("PartoTipo").ToString.Trim <> "ABORTO") Then hembras = hembras + 1
                    '
                    If (rdr("PartoSexoCria1").ToString.Trim = "MACHO") And (rdr("PartoTipo").ToString.Trim <> "T. MUERTO") And (rdr("PartoTipo").ToString.Trim <> "ABORTO") Then machos = machos + 1
                    If (rdr("PartoSexoCria2").ToString.Trim = "MACHO") And (rdr("PartoTipo").ToString.Trim <> "T. MUERTO") And (rdr("PartoTipo").ToString.Trim <> "ABORTO") Then machos = machos + 1
                    '
                    If rdr("PartoTipo").ToString.Trim = "ABORTO" Then tot_abortos = tot_abortos + 1
                    If rdr("PartoTipo").ToString.Trim = "T. MUERTO" Then tot_muertos = tot_muertos + 1
                    If rdr("PartoTipo").ToString.Trim = "ASISTIDO MUERTO" Then tot_muertos = tot_muertos + 1
                    '
                    item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                    item.SubItems.Add(rdr("centronombre").ToString.Trim)
                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(rdr("PartoEstadoProductivo").ToString.Trim)
                    item.SubItems.Add(Format(rdr("PartoFec"), "dd-MM-yyyy"))
                    item.SubItems.Add(crias.ToString.Trim)
                    item.SubItems.Add(hembras.ToString.Trim)
                    item.SubItems.Add(sexadas.ToString.Trim)
                    item.SubItems.Add(rdr("PartoTipo").ToString.Trim)

                    item.SubItems.Add(rdr("PartoCria1").ToString.Trim)
                    item.SubItems.Add(IIf(rdr("PartoSexoCria1").ToString.Trim = "ND", "", rdr("PartoSexoCria1").ToString.Trim))
                    item.SubItems.Add(rdr("PartoCria2").ToString.Trim)
                    item.SubItems.Add(IIf(rdr("PartoSexoCria2").ToString.Trim = "ND", "", rdr("PartoSexoCria2").ToString.Trim))
                    item.SubItems.Add(rdr("centro").ToString.Trim)
                    item.SubItems.Add(rdr("traslado"))
                    item.SubItems.Add(rdr("PartoUsuarioReg"))
                    item.SubItems.Add(rdr("PartoFechaReg"))
                    lvPARTOS.Items.Add(item)

                    tot_crias = tot_crias + crias
                    tot_hembras = tot_hembras + hembras
                    tot_machos = tot_machos + machos
                    tot_sexadas = tot_sexadas + sexadas

                    i = i + 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        lvPARTOS.EndUpdate()

        lblTotPartos.Text = i.ToString.Trim
        lblTotCrias.Text = tot_crias.ToString.Trim
        lblTotHembras.Text = tot_hembras.ToString.Trim
        lblTotMachos.Text = tot_machos.ToString.Trim
        lblTotSexadas.Text = tot_sexadas.ToString.Trim

        lblMuertos.Text = tot_muertos.ToString.Trim
        lblAbortos.Text = tot_abortos.ToString.Trim

        Cursor.Current = Cursors.Default
    End Sub


    Private Function EliminarParto() As Boolean
        EliminarParto = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPartos_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", lvPARTOS.SelectedItems(0).SubItems(15).Text)
        cmd.Parameters.AddWithValue("@Diio", lvPARTOS.SelectedItems(0).SubItems(3).Text)
        cmd.Parameters.AddWithValue("@FechaParto", Convert.ToDateTime(lvPARTOS.SelectedItems(0).SubItems(6).Text))
        '
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

            EliminarParto = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub mnuDetalleParto_Click(sender As System.Object, e As System.EventArgs) Handles mnuDetalleParto.Click
        DetalleCrias()
    End Sub


    Private Sub mnuCopiarDiio_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopiarDiio.Click
        CopiarDiio()
    End Sub


    Private Sub mnuVerDetalle_Click(sender As System.Object, e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
            End If
            Exit Sub
        End If

        frmPartosIngresoDiios.Param0_ModoIngreso = 1
        frmPartosIngresoDiios.Param2_NombreCentro = cboCentros.Text

        frmPartosIngresoDiios.MdiParent = frmMAIN
        frmPartosIngresoDiios.Show()
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub lvPARTOS_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvPARTOS.MouseDoubleClick
        If lvPARTOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then

            DetalleCrias()
        End If
    End Sub


    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        If lvPARTOS.Items.Count = 0 Then Exit Sub

        Dim tot(7, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL PARTOS " : tot(0, 1) = lblTotPartos.Text.Trim
        tot(1, 0) = "TOTAL CRIAS " : tot(1, 1) = lblTotCrias.Text.Trim

        tot(2, 0) = "HEMBRAS " : tot(2, 1) = lblTotHembras.Text.Trim
        tot(3, 0) = "MACHOS " : tot(3, 1) = lblTotMachos.Text.Trim
        tot(4, 0) = "T. MUERTOS " : tot(4, 1) = lblMuertos.Text.Trim
        tot(5, 0) = "ABORTOS " : tot(5, 1) = lblAbortos.Text.Trim

        tot(6, 0) = "TOTAL SEXADAS " : tot(6, 1) = lblTotSexadas.Text.Trim

        ExportToExcelGrilla(lvPARTOS, tot)
    End Sub


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click

        BuscarDetalle()
    End Sub
    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        '  Param1_CodigoCentro = CentrosUsuario.Codigo(cboCentros.SelectedIndex )
        Param2_NombreCentro = cboCentros.Text

    End Sub
    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged
        If Param0_ModoIngreso = 1 Then
            Param3_FechaDesde = dtpFecha.Value
            Param4_FechaHasta = dtpFechaHasta.Value
        End If

    End Sub
    Private Sub frmPartosIngreso_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.C Then
                CopiarDiio()
            End If
        End If
    End Sub
    Private Sub frmPartosIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()


        If Param0_ModoIngreso = 1 Then                  'si es un nuevo parto
            dtpFecha.Value = Now
            Label8.Visible = False
            dtpFechaHasta.Visible = False

            Param3_FechaDesde = dtpFecha.Value
            Param4_FechaHasta = dtpFechaHasta.Value
            dtpFecha.Value = Param3_FechaDesde
            dtpFechaHasta.Value = Param4_FechaHasta
        Else                                            'si consultamos partos
            cboCentros.Text = Param2_NombreCentro
            dtpFecha.Value = Param3_FechaDesde
            dtpFechaHasta.Value = Param4_FechaHasta
            cboTipoParto.SelectedIndex = 0

            BuscarDetalle()
            Param0_ModoIngreso = 1
            cboCentros.SelectedIndex = 0
        End If

    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click

        If lvPARTOS.SelectedItems.Count = 0 Then Exit Sub
        btnEliminar.Enabled = False
        'If EliminaParto <> "SI" Then
        '    MsgBox("Usuario sin privilegios para eliminar partos ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Eliminar Parto")
        '    btnEliminar.Enabled = False
        '    Exit Sub
        'End If
        Dim Arete As String = "" : Dim Cen As String = "" : Dim FechaParto As String = ""

        Arete = lvPARTOS.SelectedItems(0).SubItems(3).Text
        Cen = Param1_CodigoCentro
        FechaParto = lvPARTOS.SelectedItems(0).SubItems(6).Text

        If Arete = "" Then
            MsgBox("Debe seleccionar un parto. ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Seleccionar Parto")
            Exit Sub
        End If
        If MsgBox("¿Confirma eliminación del Parto seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If EliminarParto() = True Then
            MsgBox("Eliminacion finalizada correctamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmacion")
            btnBuscar_Click(sender, e)
        End If
        btnEliminar.Enabled = True
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class