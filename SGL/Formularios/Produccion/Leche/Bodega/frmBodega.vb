Imports System.Data.SqlClient

Public Class frmBodega
    Private RetIDGP As String = ""
    Private EmpresaCod As Integer = Empresa 'Default
    Private EmpresaNom As String = ""
    Private Bodegacod As String = ""
    Private BodegaNom As String = ""
    Private MovTipCod As Integer = 0
    Private MovTipNom As String = ""
    Private FirstTime As Boolean = True

    Private Sub frmBodega_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8
        dtpFechaDesde.Value = Now.AddDays(-15)
        dtpFechaHasta.Value = Now
        FirstTime = True
        '/**/
        Dim dtTipMov As DataTable = New DataTable("DTTipoMovimiento")
        dtTipMov.Columns.Add("MovTipCod", System.Type.GetType("System.Decimal"))
        dtTipMov.Columns.Add("MovTipNom", System.Type.GetType("System.String"))
        dtTipMov.Rows.Add(0, "Todos")
        dtTipMov.Rows.Add(1, "Consumos")
        dtTipMov.Rows.Add(2, "Variación")
        dtTipMov.Rows.Add(3, "Transferencias")
        'dtTipMov.Rows.Add(100, "Entradas")

        cboTipoMov.DataSource = dtTipMov
        cboTipoMov.DisplayMember = "MovTipNom"
        '/**/
        Dim dtEmpresas As DataTable = New DataTable("DTEmpresas")
        dtEmpresas.Columns.Add("EmpresaCod", System.Type.GetType("System.Decimal"))
        dtEmpresas.Columns.Add("EmpresaNom", System.Type.GetType("System.String"))
        Select Case Empresa
            Case 76011573
                dtEmpresas.Rows.Add(76011573, "TOROMIRO")
                EmpresaNom = "TOROMIRO"
            Case 76294870
                dtEmpresas.Rows.Add(76011573, "TOROMIRO")
                dtEmpresas.Rows.Add(76294870, "RIMU")
                EmpresaNom = "RIMU"
            Case 77299208
                dtEmpresas.Rows.Add(77299208, "TOTARA")
                EmpresaNom = "TOTARA"
            Case Else
                dtEmpresas.Rows.Add(Empresa, "OTRA")
        End Select

        cboEmpresa.DataSource = dtEmpresas
        cboEmpresa.DisplayMember = "EmpresaNom"

        '/**/
        MSTRUsuariosBodegas.DSCboUsuarioBodegas_FrmQRY(cboBodegas)
        '/**/
        dtpFechaDesde.Enabled = False
        dtpFechaHasta.Enabled = False
        cboTipoMov.Enabled = False
        chkClaseTrl.Enabled = True
        FirstTime = False

        Select Case Empresa
            Case 76011573
                EmpresaNom = "TOROMIRO"
            Case 76294870
                EmpresaNom = "RIMU"
        End Select
        EmpresaCod = Empresa 'Default
        cboEmpresa.Text = EmpresaNom
    End Sub
    Private Sub CboEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmpresa.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboEmpresa.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            EmpresaCod = selectedRow("EmpresaCod")
            EmpresaNom = selectedRow("EmpresaNom")
        End If
    End Sub

    Private Sub CboBodegas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBodegas.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboBodegas.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            Bodegacod = selectedRow("Bodegacod")
            BodegaNom = selectedRow("BodegaNom")
            BuscarProductosBodega()
            BuscarHistorialMovimientos()
        End If
    End Sub
    Private Sub CboTipoMov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoMov.SelectedIndexChanged

        Dim selectedRow As DataRowView = DirectCast(cboBodegas.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            MovTipCod = selectedRow("MovTipCod")
            MovTipNom = selectedRow("MovTipNom")
            BuscarHistorialMovimientos()
        End If
    End Sub

    Private Sub BuscarProductosBodega()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_ArticulosListado", con)
        Dim ClaseTrl As Boolean = False
        cmd.CommandTimeout = 500
        If chkClaseTrl.Checked = True Then
            ClaseTrl = True
        End If
        Dim i As Integer = 0
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@EmpresaCod", EmpresaCod)
        cmd.Parameters.AddWithValue("@BodegaCod", Bodegacod)
        cmd.Parameters.AddWithValue("@ItemNom", txtItemNom.Text.Trim)
        cmd.Parameters.AddWithValue("@ClaseTrl", ClaseTrl)
        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

        lvItemsMiBodega.BeginUpdate()
        lvItemsMiBodega.Items.Clear()

        Try
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader()

            Try
                lvItemsMiBodega.Items.Clear()

                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)
                    item.SubItems.Add(rdr("ITEMDESC").ToString.Trim)
                    item.SubItems.Add(Format(rdr("ITEMSTK"), "#,##0.0"))
                    item.SubItems.Add(rdr("ITEMNMBR").ToString.Trim)
                    item.SubItems.Add(rdr("IVIVOFIX").ToString.Trim)
                    item.SubItems.Add(rdr("UOFM").ToString.Trim)
                    item.SubItems.Add(rdr("DECPLQTY").ToString.Trim)
                    item.SubItems.Add(rdr("ITMCLSCD").ToString.Trim)
                    item.SubItems.Add(rdr("CURRCOST").ToString.Trim)
                    item.SubItems.Add(rdr("CONSUMO").ToString.Trim)
                    lvItemsMiBodega.Items.Add(item)
                    i += 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvItemsMiBodega.EndUpdate()
    End Sub

    Private Sub TabFormulario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabFormulario.SelectedIndexChanged
        btnConsumo.Enabled = False
        btnTraslado.Enabled = False
        btnGuiaTraslado.Enabled = False
        If tabFormulario.SelectedTab Is Nothing Then Exit Sub
        Dim tabIdx As Integer = tabFormulario.SelectedIndex

        If tabFormulario.TabPages(tabIdx).Name.Contains("0") Then
            dtpFechaDesde.Enabled = False
            dtpFechaHasta.Enabled = False
            cboTipoMov.Enabled = False
            chkClaseTrl.Enabled = True
            btnConsumo.Enabled = True
            btnTraslado.Enabled = True
        End If
        If tabFormulario.TabPages(tabIdx).Name.Contains("1") Then
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
            cboTipoMov.Enabled = True
            chkClaseTrl.Enabled = False

        End If
        If tabFormulario.TabPages(tabIdx).Name.Contains("2") Then
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
            cboTipoMov.Enabled = True
            chkClaseTrl.Enabled = False
        End If
        If tabFormulario.TabPages(tabIdx).Name.Contains("3") Then
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
            cboTipoMov.Enabled = False
            chkClaseTrl.Enabled = False
        End If
        txtItemNom.Text = ""
        btnBuscar.PerformClick()


    End Sub

    Private Sub lvBODEGA_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvItemsMiBodega.KeyPress
        If Asc(Char.ToUpper(e.KeyChar)) >= Asc(ChrW(Keys.A)) And Asc(Char.ToUpper(e.KeyChar)) <= Asc(ChrW(Keys.Z)) Then
            Dim itm As ListViewItem = lvItemsMiBodega.FindItemWithText(e.KeyChar)

            If Not itm Is Nothing Then
                itm.Selected = True
                itm.EnsureVisible()
                lvItemsMiBodega.Focus()
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        BuscarProductosBodega()
    End Sub

    Private Sub BuscarHistorialMovimientos()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_ListadoMov", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@EmpresaCod", EmpresaCod)
        cmd.Parameters.AddWithValue("@BodegaCod", Bodegacod)
        cmd.Parameters.AddWithValue("@InvMovTipo", "")
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@ItemNombre", txtItemNom.Text.Trim)
        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

        lvBODHISTORIAL.BeginUpdate()
        lvBODHISTORIAL.Items.Clear()
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)    'primera columna, para ordenar los datos
                    item.SubItems.Add(Format(rdr("InvMovFecha"), "dd/MM/yyyy"))
                    item.SubItems.Add(Format(rdr("InvFechaReg"), "HH:mm"))
                    item.SubItems.Add(rdr("InvMovTipoNom").ToString.Trim)
                    item.SubItems.Add(rdr("EmpresaCodO").ToString.Trim)
                    item.SubItems.Add(rdr("EmpresaNomO").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaCodO").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaNomO").ToString.Trim)
                    item.SubItems.Add(rdr("EmpresaCodD").ToString.Trim)
                    item.SubItems.Add(rdr("EmpresaNomD").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaCodD").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaNomD").ToString.Trim)
                    item.SubItems.Add(rdr("ITEMNMBR").ToString.Trim)
                    item.SubItems.Add(rdr("ITEMDESC").ToString.Trim)
                    item.SubItems.Add(Format(rdr("Cantidad"), "#,##0.0"))
                    item.SubItems.Add(rdr("NroGuia").ToString.Trim)
                    item.SubItems.Add(rdr("DOCNMBR").ToString.Trim)

                    lvBODHISTORIAL.Items.Add(item)
                    i += 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
SalirProc:
        lvBODHISTORIAL.EndUpdate()
    End Sub
    Private Sub BuscarPendientesRecepcion()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_ListadoMovPendRecepcion", con)
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@EmpresaCod", EmpresaCod)
        cmd.Parameters.AddWithValue("@BodegaCod", Bodegacod)
        cmd.Parameters.AddWithValue("@FechaMovI", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaMovF", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

        lvPendRecepcion.BeginUpdate()
        lvPendRecepcion.Items.Clear()
        Try
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)    'primera columna, para ordenar los datos
                    item.SubItems.Add(Format(rdr("InvMovFecha"), "dd/MM/yyyy"))
                    item.SubItems.Add(Format(rdr("InvMovHora"), "HH:mm"))
                    item.SubItems.Add(rdr("BodegaCodO").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaNomO").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaCodD").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaNomD").ToString.Trim)
                    item.SubItems.Add(Format(rdr("CantItems"), "#,##0.0"))
                    item.SubItems.Add(rdr("InvDTEFolioGuia").ToString.Trim)
                    item.SubItems.Add(rdr("InvId").ToString.Trim)
                    item.SubItems.Add(rdr("InvUsuarioCod").ToString.Trim)
                    item.SubItems.Add(rdr("InvMovObs").ToString.Trim)
                    item.SubItems.Add(rdr("InvDTEPDFNomSuite").ToString.Trim)
                    item.SubItems.Add(rdr("UsuRealizaResol").ToString.Trim)
                    item.SubItems.Add(rdr("InvMovSistInt").ToString.Trim)
                    lvPendRecepcion.Items.Add(item)
                    i += 1
                End While

                If i = 0 Then
                    MsgBox("NO HAY DATOS PARA LOS FILTROS SELECCIONADOS. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACION")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        lvPendRecepcion.EndUpdate()
    End Sub
    Private Sub BuscarRechazados()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_ListadoMovRechazados", con)
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@EmpresaCod", EmpresaCod)
        cmd.Parameters.AddWithValue("@BodegaCod", Bodegacod)
        cmd.Parameters.AddWithValue("@FechaMovI", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaMovF", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@ItemNombre", txtItemNom.Text.Trim)
        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

        lvRechazados.BeginUpdate()
        lvRechazados.Items.Clear()
        Try
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)    'primera columna, para ordenar los datos
                    item.SubItems.Add(Format(rdr("InvMovFecha"), "dd/MM/yyyy"))
                    item.SubItems.Add(Format(rdr("InvRecepcionUsuFec"), "dd/MM/yyyy HH:mm"))
                    item.SubItems.Add(rdr("BodegaCodO").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaNomO").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaCodD").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaNomD").ToString.Trim)
                    item.SubItems.Add(Format(rdr("CantItems"), "#,##0.0"))
                    item.SubItems.Add(rdr("InvDTEFolioGuia").ToString.Trim)
                    item.SubItems.Add(rdr("InvId").ToString.Trim)
                    item.SubItems.Add(rdr("InvUsuarioCod").ToString.Trim)
                    item.SubItems.Add(rdr("InvMovObs").ToString.Trim)
                    item.SubItems.Add(rdr("InvDTEPDFNomSuite").ToString.Trim)
                    item.SubItems.Add(rdr("InvRecepcionUsuObs").ToString.Trim)
                    item.SubItems.Add(rdr("InvRecepcionUsuNom").ToString.Trim)
                    item.SubItems.Add(rdr("EmpresaCodO").ToString.Trim)
                    lvRechazados.Items.Add(item)
                    i += 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        lvRechazados.EndUpdate()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim tabIdx As Integer = tabFormulario.SelectedIndex

        If tabFormulario.TabPages(tabIdx).Name.Contains("0") Then
            dtpFechaDesde.Enabled = False
            dtpFechaHasta.Enabled = False
            cboTipoMov.Enabled = False
            chkClaseTrl.Enabled = True
            BuscarProductosBodega()
        End If
        If tabFormulario.TabPages(tabIdx).Name.Contains("1") Then
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
            cboTipoMov.Enabled = True
            chkClaseTrl.Enabled = False
            BuscarHistorialMovimientos()
        End If
        If tabFormulario.TabPages(tabIdx).Name.Contains("2") Then
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
            cboTipoMov.Enabled = False
            chkClaseTrl.Enabled = False
            BuscarPendientesRecepcion()
        End If
        If tabFormulario.TabPages(tabIdx).Name.Contains("3") Then
            dtpFechaDesde.Enabled = True
            dtpFechaHasta.Enabled = True
            cboTipoMov.Enabled = False
            chkClaseTrl.Enabled = False
            BuscarRechazados()
        End If
    End Sub


    Private Sub LvBODHISTORIAL_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvBODHISTORIAL.MouseClick
        btnGuiaTraslado.Enabled = False
        If lvBODHISTORIAL.SelectedItems.Count = 0 Then Exit Sub

        Dim NroDocu As Decimal = lvBODHISTORIAL.SelectedItems.Item(0).SubItems(15).Text

        If NroDocu > 0 Then
            btnGuiaTraslado.Enabled = True
        End If
    End Sub
    Private Sub lvRechazados_MouseClick(sender As Object, e As MouseEventArgs) Handles lvRechazados.MouseClick
        btnGuiaTraslado.Enabled = False
        If lvRechazados.SelectedItems.Count = 0 Then Exit Sub
        btnGuiaTraslado.Enabled = True
    End Sub

    Private Sub btnGuiaTraslado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuiaTraslado.Click
        Cursor.Current = Cursors.WaitCursor

        Dim tabIdx As Integer = tabFormulario.SelectedIndex
        Dim guia_ As String = ""
        Dim Empr As Integer = 0
        If tabFormulario.TabPages(tabIdx).Name.Contains("1") Then
            If lvBODHISTORIAL.SelectedItems.Count = 0 Then Exit Sub

            guia_ = lvBODHISTORIAL.SelectedItems.Item(0).SubItems(15).Text
            Empr = lvBODHISTORIAL.SelectedItems.Item(0).SubItems(4).Text
        End If

        If tabFormulario.TabPages(tabIdx).Name.Contains("3") Then
            If lvRechazados.SelectedItems.Count = 0 Then Exit Sub

            guia_ = lvRechazados.SelectedItems.Item(0).SubItems(8).Text
            Empr = lvRechazados.SelectedItems.Item(0).SubItems(15).Text
        End If



        If guia_ <> "" Then
            'Dim Empr As Integer = IIf(Empresa = 76294870, 76011573, Empresa)

            Dim PdfNomSuite As String = SuiteElectronica.GeneraNombreArchivoBodega(Empr, 52, guia_)
            SuiteElectronica.MostrarPDFeSuite(PdfNomSuite)
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lvItemsConsumo_TabIndexChanged(sender As Object, e As EventArgs)
        BuscarHistorialMovimientos()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkClaseTrl.CheckedChanged
        BuscarProductosBodega()
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        Select Case tabFormulario.SelectedIndex
            Case 0  'consumo
                If lvItemsMiBodega.Items.Count = 0 Then Exit Sub

                Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}
                ExportToExcelGrilla(lvItemsMiBodega, tot)
            Case 1  'TRASLADO
                If lvBODHISTORIAL.Items.Count = 0 Then Exit Sub

                Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}
                ExportToExcelGrilla(lvBODHISTORIAL, tot)
        End Select

    End Sub
    Private Sub BtnConsumo_Click(sender As Object, e As EventArgs) Handles btnConsumo.Click
        'ingresamos consumo
        With frmBodegaIngresoConsumo
            .EmpresaCod = EmpresaCod
            .BodegaCod = Bodegacod
            .BodegaNom = BodegaNom

            Dim validalista As Integer = 0
            For i = 0 To lvItemsMiBodega.Items.Count - 1
                If lvItemsMiBodega.Items(i).Selected = True Then
                    validalista = 1
                    Exit For
                End If
            Next

            If validalista = 0 Then

            Else
                .Param4_Producto = lvItemsMiBodega.SelectedItems.Item(0).SubItems(1).Text
            End If

            .ShowDialog()
        End With
    End Sub

    Private Sub BtnTraslado_Click(sender As Object, e As EventArgs) Handles btnTraslado.Click
        With frmBodegaIngresoTraslado
            .EmpresaCod = EmpresaCod
            .BodegaCod = Bodegacod
            .BodegaNom = BodegaNom

            If chkClaseTrl.Checked = True Then
                .Param_ClaseTrl = True
            Else
                .Param_ClaseTrl = False
            End If


            Dim validalista As Integer = 0
            For i = 0 To lvItemsMiBodega.Items.Count - 1
                If lvItemsMiBodega.Items(i).Selected = True Then
                    validalista = 1
                    Exit For
                End If
            Next

            If validalista = 0 Then

            Else
                .Param4_Producto = lvItemsMiBodega.SelectedItems.Item(0).SubItems(1).Text
            End If
            .ShowDialog()
        End With
    End Sub
    Private Sub lvPendRecepcion_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvPendRecepcion.MouseDoubleClick
        If lvPendRecepcion.Items.Count = 0 Then Exit Sub

        With frmBodegaTrasladoResolucion
            .paramInvId = lvPendRecepcion.SelectedItems.Item(0).SubItems(9).Text
            .paramPermResol = lvPendRecepcion.SelectedItems.Item(0).SubItems(13).Text
            .ShowDialog()
        End With
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click

        With frmBodegaCrearCierre
            .MdiParent = frmMAIN
            frmBodegaCrearCierre.Show()
            frmBodegaCrearCierre.BringToFront()

        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmBodegaCierreItems.MdiParent = frmMAIN
        frmBodegaCierreItems.Show()
        frmBodegaCierreItems.BringToFront()
    End Sub

    Private Sub lvItemsMiBodega_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvItemsMiBodega.SelectedIndexChanged
        Dim i As Int32
        For Each i In lvItemsMiBodega.SelectedIndices
            If lvItemsMiBodega.Items(i).SubItems(7).Text = "TRASLADOS" Or lvItemsMiBodega.Items(i).SubItems(9).Text = "NO" Then
                btnConsumo.Enabled = False
            Else
                btnConsumo.Enabled = True
            End If
        Next i
    End Sub


End Class