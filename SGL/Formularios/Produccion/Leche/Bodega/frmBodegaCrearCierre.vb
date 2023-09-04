Imports System.Data.SqlClient
Imports System.Net.WebRequestMethods
Imports System.Runtime.ConstrainedExecution
Imports System.Security.Policy

Public Class frmBodegaCrearCierre
    Private fnGrabarCierreBodega As New fnGrabarCierreBodega

    Private EmpresaCod As Integer = frmBodega.cboEmpresa.SelectedIndex
    Private EmpresaNom As String
    Private Bodegacod As String = ""
    Private BodegaNom As String = ""
    Private BusquedaRealizada As Boolean = False
    Private PermisoTrlInterComp As String = ""
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvItemsMiBodega.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}
        ExportToExcelGrilla(lvItemsMiBodega, tot)
    End Sub

    Private Sub frmBodegaCrearCierre_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8

        Dim PermisoColumna As String = "UsrElimCieBodega" 'nombre de la columna donde queremos buscar el permiso

        Usuario_Permisos.DSUsuarioPermisos_FrmQRY(PermisoColumna)

        DTUsuarioPermisosFrmQRY = Usuario_Permisos.GETData
        For i As Integer = 0 To DTUsuarioPermisosFrmQRY.Rows.Count - 1
            PermisoTrlInterComp = DTUsuarioPermisosFrmQRY.Rows(i).Item("Permiso").ToString.Trim
            Exit For
        Next

        txtMes.Value = Now.Month
        txtAnio.Value = Now.Year

        btnCrearCierre.Enabled = False

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
            Case Else
                dtEmpresas.Rows.Add(Empresa, "OTRA")
        End Select

        btnEliminar.Enabled = False

            cboEmpresa.DataSource = dtEmpresas
        cboEmpresa.DisplayMember = "EmpresaNom"

        MSTRUsuariosBodegas.DSCboUsuarioBodegas_FrmQRY(cboBodegas)

        EmpresaCod = Empresa 'Default
        cboEmpresa.Text = EmpresaNom
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCrearCierre.Click
        If txtMes.Text = "" Or txtAnio.Text = "" Then
            MsgBox("CAMPO MES O AÑO EN BLANCO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE CAMPO")
            Exit Sub
        End If

        If BusquedaRealizada = False Then
            MsgBox("DEBES BUSCAR DATOS ANTES DE GRABAR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE CAMPO")
            Exit Sub
        End If


        Dim bodega As String = Bodegacod
        Dim mes As Integer = txtMes.Value
        Dim anio As Integer = txtAnio.Value
        Dim BodegaDetalle As DataTable = DataTableCierreBodega(lvItemsMiBodega)

        GrabarCierre(bodega, mes, anio, BodegaDetalle)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BuscarProductosBodega(ByVal Bodega As String, ByVal mes As Integer, ByVal anio As Integer)

        Dim con As New SqlConnection(IIf(EmpresaNom = "TOROMIRO", GetConnectionStringTOROM(), IIf(EmpresaNom = "RIMU", GetConnectionStringRIMU(), "")))
        Dim cmd As New SqlCommand("spSSRS_Inventario_ConsultaStockMensualConsolidadaGP_SAMM_SGL", con)
        Dim ClaseTrl As Boolean = False
        'Dim Stock As Integer
        Dim i As Integer = 0
        cmd.CommandType = Data.CommandType.StoredProcedure

        ClaseTrl = False

        cmd.Parameters.AddWithValue("@YEAR", anio)
        cmd.Parameters.AddWithValue("@MONTH", mes)
        cmd.Parameters.AddWithValue("@LOCNCODE", Bodega)
        cmd.Parameters.AddWithValue("@ITEMNMBR", "")
        cmd.Parameters.AddWithValue("@ITEMDESC", "")
        cmd.Parameters.AddWithValue("@ITMCLSCD", "")
        cmd.Parameters.AddWithValue("@SOLOSTCK", 1)

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
                    item.SubItems.Add(rdr("ITEMNMBR").ToString.Trim)
                    item.SubItems.Add(rdr("UOFM").ToString.Trim)
                    item.SubItems.Add(rdr("SALDO_INI_SGL").ToString.Trim)
                    item.SubItems.Add(rdr("TRX_NOCONTABIN").ToString.Trim)  'transaccion no contabilizada intrada
                    item.SubItems.Add(rdr("TRX_NOCONTABOUT").ToString.Trim) 'transaccion no contabilizada salida
                    item.SubItems.Add(rdr("TRX_CONTABIN").ToString.Trim)    'transaccion contabilizada intrada
                    item.SubItems.Add(rdr("TRX_CONTABOUT").ToString.Trim)   'transaccion contabilizada salida
                    item.SubItems.Add(rdr("CURRCOST").ToString.Trim)
                    item.SubItems.Add(rdr("SALDOFIN").ToString.Trim)
                    item.SubItems.Add(rdr("TRX_CONTAB").ToString.Trim)
                    item.SubItems.Add(rdr("TRX_NOCONTAB").ToString.Trim)
                    item.SubItems.Add(Format(rdr("CantPnd2"), "#,##0.0"))
                    item.SubItems.Add(Format(rdr("CantPnd2"), "#,##0.0"))
                    item.SubItems.Add(Format(rdr("CantPnd3"), "#,##0.0"))
                    item.SubItems.Add(Format(rdr("Disponible"), "#,##0.0"))
                    item.SubItems.Add(rdr("ITMCLSCD").ToString.Trim)
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtMes.Text = "" Or txtAnio.Text = "" Then
            MsgBox("DEBE SELECCIONAR MES Y AÑO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE CAMPO")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim mes As Integer = txtMes.Value
        Dim anio As Integer = txtAnio.Value
        Dim bodega As String = Bodegacod
        Dim tabIdx As Integer = TabBodega.SelectedIndex

        If TabBodega.TabPages(tabIdx).Name.Contains("0") Then
            Bodegas_Estado(bodega, mes, anio)
        End If
        If TabBodega.TabPages(tabIdx).Name.Contains("1") Then
            Bodegas_ListadoMovPendientes(bodega)
        End If

        If PermisoTrlInterComp = 1 Then
            btnEliminar.Enabled = True
        End If

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub CboBodegas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBodegas.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboBodegas.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            Bodegacod = selectedRow("Bodegacod")
            BodegaNom = selectedRow("BodegaNom")
        End If
        btnCrearCierre.Enabled = False
        lvItemsMiBodega.Items.Clear()
    End Sub

    Private Sub GrabarCierre(ByVal bodega As String, ByVal mes As Integer, ByVal anio As Integer, ByVal BodegaDetalle As DataTable)

        If MsgBox("DESEA GUARDAR LA INFORMACION ""CIERRE MENSUAL DE BODEGA""", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegaCierre_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Bodega", bodega)
        cmd.Parameters.AddWithValue("@Mes", mes)
        cmd.Parameters.AddWithValue("@Anio", anio)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@DTBodegaCierreDetalle", BodegaDetalle)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            If vret <> 0 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret + ", NO SE HAN PODIDO GUARDAR LOS DATOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        MsgBox("DATOS GRABADOS CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        BusquedaRealizada = False
        btnCrearCierre.Enabled = False
    End Sub
    Public Function DataTableCierreBodega(ByVal lvdetalle As ListView) As DataTable
        DataTableCierreBodega = Nothing
        Dim table As DataTable = New DataTable("DTBodegaCierreDetalle")

        table.Columns.Add("ItemCod", System.Type.GetType("System.String"))
        table.Columns.Add("ItemNom", System.Type.GetType("System.String"))
        table.Columns.Add("Stock", System.Type.GetType("System.Single"))
        table.Columns.Add("UnidadMedida", System.Type.GetType("System.String"))
        table.Columns.Add("ItemClase", System.Type.GetType("System.String"))
        table.Columns.Add("IngresoNoContab", System.Type.GetType("System.Single"))
        table.Columns.Add("SalidaNoContab", System.Type.GetType("System.Single"))
        table.Columns.Add("IngresoContab", System.Type.GetType("System.Single"))
        table.Columns.Add("SalidaContab", System.Type.GetType("System.Single"))
        table.Columns.Add("Contabilizado", System.Type.GetType("System.Single"))
        table.Columns.Add("NoContabilizado", System.Type.GetType("System.Single"))
        table.Columns.Add("SaldoInicial", System.Type.GetType("System.Single"))

        Dim n As Integer
        n = lvdetalle.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(lvdetalle.Items(i).SubItems(2).Text,
                           lvdetalle.Items(i).SubItems(1).Text,
                           lvdetalle.Items(i).SubItems(16).Text,
                           lvdetalle.Items(i).SubItems(3).Text,
                           lvdetalle.Items(i).SubItems(17).Text,
                           lvdetalle.Items(i).SubItems(5).Text,
                           lvdetalle.Items(i).SubItems(6).Text,
                           lvdetalle.Items(i).SubItems(7).Text,
                           lvdetalle.Items(i).SubItems(8).Text,
                           lvdetalle.Items(i).SubItems(11).Text,
                           lvdetalle.Items(i).SubItems(12).Text,
                           lvdetalle.Items(i).SubItems(4).Text)

        Next
        DataTableCierreBodega = table
    End Function
    Private Sub Bodegas_ListadoMovPendientes(ByVal bodega As String)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_ListadoMovPendientes", con)
        Dim ClaseTrl As Boolean = False

        Dim i As Integer = 0
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@BodegaCod", bodega)


        lvlMovimientos.BeginUpdate()
        lvlMovimientos.Items.Clear()

        Try
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader()

            Try
                lvItemsMiBodega.Items.Clear()

                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)
                    item.SubItems.Add(rdr("ItemNumber").ToString.Trim)
                    item.SubItems.Add(rdr("InvMovItmNom").ToString.Trim)
                    item.SubItems.Add(Format(rdr("InvMovItmCnt"), "#,##0.0"))
                    item.SubItems.Add(rdr("InvDTEFolioGuia").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaCodO").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaNomO").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaCodD").ToString.Trim)
                    item.SubItems.Add(rdr("BodegaNomD").ToString.Trim)
                    item.SubItems.Add(Format(rdr("InvMovFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("InvMovItmClase").ToString.Trim)
                    lvlMovimientos.Items.Add(item)
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
        lvlMovimientos.EndUpdate()
    End Sub
    Private Sub Bodegas_Estado(ByVal bodega As String, ByVal mes As Integer, ByVal anio As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_Estado", con)
        Dim ClaseTrl As Boolean = False

        Dim i As Integer = 0
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@BodegaCod", bodega)
        cmd.Parameters.AddWithValue("@Mes", mes)
        cmd.Parameters.AddWithValue("@Anio", anio)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret = -1 Then
                lblEstado.Text = mret
                lblEstado.Visible = True
                If mret = "CERRADO" Then
                    lblEstado.ForeColor = Color.Green
                    BuscarBodegaCierre(bodega, mes, anio)
                    btnCrearCierre.Enabled = False
                Else
                    lblEstado.ForeColor = Color.Red
                    BuscarProductosBodega(bodega, mes, anio)
                    btnCrearCierre.Enabled = True
                    If lvItemsMiBodega.Items.Count >= 0 Then
                        BusquedaRealizada = True
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub BuscarBodegaCierre(ByVal Bodega As String, ByVal Mes As Integer, ByVal Anio As Integer)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegaCierre_Buscar", con)
        Dim ClaseTrl As Boolean = False

        Dim i As Integer = 0
        cmd.CommandType = Data.CommandType.StoredProcedure

        ClaseTrl = False

        cmd.Parameters.AddWithValue("@BodegaCod", Bodega)
        cmd.Parameters.AddWithValue("@Mes", Mes)
        cmd.Parameters.AddWithValue("@Anio", Anio)

        lvItemsMiBodega.BeginUpdate()
        lvItemsMiBodega.Items.Clear()

        Try
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader()

            Try
                lvItemsMiBodega.Items.Clear()

                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)
                    item.SubItems.Add(rdr("BodNomItemDet").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("BodUMedidaDet").ToString.Trim)
                    item.SubItems.Add(rdr("BodSaldoInicial").ToString.Trim)
                    item.SubItems.Add(rdr("BodInNoContab").ToString.Trim)
                    item.SubItems.Add(rdr("BodSalNoContab").ToString.Trim)
                    item.SubItems.Add(rdr("BodInContab").ToString.Trim)
                    item.SubItems.Add(rdr("BodSalContab").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("BodItemStkDet").ToString.Trim)
                    item.SubItems.Add(rdr("BodContab").ToString.Trim)
                    item.SubItems.Add(rdr("BodNoContab").ToString.Trim)
                    item.SubItems.Add(0)
                    item.SubItems.Add(0)
                    item.SubItems.Add(0)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("BodClaseDet").ToString.Trim)
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

    Private Sub btnGuiaTraslado_Click(sender As Object, e As EventArgs) Handles btnImprimirCierre.Click

        Dim url As String = "http://srvreports/ReportServer/Pages/ReportViewer.aspx?%2fAdministraci%C3%B3n+y+Finanzas%2fInventario%2fInventario+-+Cierre+Mensual+Por+Bodega&Empresa=" & Empresa & "&Bodega=" & Bodegacod.Trim() & "&Anio=" & txtAnio.Text & "&Mes=" & txtMes.Text.Trim() & "&rs:Command=Render"

        With frptBodegaCierreMes

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            .wbSSRSBodegaCierreMes.Navigate(url)

        End With

    End Sub

    Private Sub txtMes_Leave(sender As Object, e As EventArgs) Handles txtMes.Leave
        lvItemsMiBodega.Items.Clear()
        btnCrearCierre.Enabled = False
    End Sub

    Private Sub txtAnio_Leave(sender As Object, e As EventArgs) Handles txtAnio.Leave
        lvItemsMiBodega.Items.Clear()
        btnCrearCierre.Enabled = False
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("ESTA SEGURO(A) QUE DECEA CONTINUAR", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, "CONFIRMACION") = vbCancel Then
            Exit Sub
        End If

        EliminarCierreBodega()
    End Sub
    Private Sub EliminarCierreBodega()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegaCierre_EliminarCierre", con)
        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim Mes As Integer = txtMes.Value
        Dim Anio As Integer = txtAnio.Value

        cmd.Parameters.AddWithValue("@Empresa", EmpresaCod)
        cmd.Parameters.AddWithValue("@BodegaCod", Bodegacod)
        cmd.Parameters.AddWithValue("@Mes", Mes)
        cmd.Parameters.AddWithValue("@Anio", Anio)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()
            cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
    End Sub
End Class