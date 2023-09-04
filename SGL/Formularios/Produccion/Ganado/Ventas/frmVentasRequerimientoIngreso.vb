Imports System.Data.SqlClient
Public Class frmVentasRequerimientoIngreso

    Dim Prioridad As String
    Dim Errores As Integer = 0
    Dim TotalDiios As Integer = 0

    Private Sub frmVentasRequerimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.MdiParent = frmMAIN

        CboLLenaCentros()
        ERPClientes()
        Firmantes()
        rbNormal.Checked = True
    End Sub
    Private Sub CboLLenaCentros()

        cboCentros.Items.Clear()
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub

    Private Sub ERPClientes()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSAMM_Clientes", con)
        Dim rdr As SqlDataReader = Nothing

        Dim dt As New DataTable
        cmd.CommandType = CommandType.Text
        Dim da As New SqlDataAdapter

        da.SelectCommand = cmd
        da.Fill(dt)

        cboClientes.ValueMember = "ClienteCod"
        cboClientes.DisplayMember = "ClienteRazSoc"
        cboClientes.DataSource = dt

    End Sub
    Private Sub LeeBaston()
        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmMuertes"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub
    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim numErrores As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        Dim inichk_ As Integer = lvVentaDiio.Items.Count '- 1

        Cursor.Current = Cursors.WaitCursor

        lvVentaDiio.Items.Clear()
        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If
        ConsultaDiioVenta(strdiios_)
        Cursor.Current = Cursors.Default
    End Sub
    Private Function ConsultaDiioVenta(ByVal diio As String) As Boolean
        Cursor.Current = Cursors.WaitCursor
        Dim cent_ As String = ""
        Dim cau_ As Integer = 0
        Dim i As Integer = 0
        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_RequerimientoVentas", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Centro As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@ArrayDIIOS", diio)
        '
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        lvVentaDiio.Items.Clear()
        lvVentaDiio.BeginUpdate()

        Try

            con.Open()
            rdr = cmd.ExecuteReader()

            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value

            Try
                While rdr.Read()

                    Dim item As New ListViewItem((TotalDiios + 1).ToString.Trim)

                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(rdr("GndProCod").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add(rdr("VtaProdPrecioU").ToString.Trim)
                    item.SubItems.Add(rdr("VtaProdPrecioU").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                    item.SubItems.Add(Format(rdr("GndUltFechaPP"), "dd-MM-yyyy"))

                    Dim DiasPosibleParto As Integer = rdr("DiasPosibleParto")
                    If DiasPosibleParto >= 0 Then
                        item.SubItems.Add(rdr("DiasPosibleParto").ToString.Trim)
                        If DiasPosibleParto <= 36 Then
                            item.SubItems(i).BackColor = Color.Red
                            Errores = Errores + 1
                        End If
                    Else
                        item.SubItems.Add("")
                    End If

                    Dim DiasParto As Integer = rdr("DiasParto")
                    If DiasParto >= 0 Then
                        item.SubItems.Add(rdr("DiasParto").ToString.Trim)
                        If DiasParto <= 7 Then
                            item.SubItems(i).BackColor = Color.Red
                            Errores = Errores + 1
                        End If
                    Else
                        item.SubItems.Add("")
                    End If

                    item.SubItems.Add(rdr("GndEstadoSalud").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("EstadoGnd").ToString.Trim)
                    'item.SubItems(i).BackColor = Color.White

                    If rdr("EstadoGnd").ToString.Trim <> "" Then
                        item.SubItems.Add(rdr("EstadoGnd").ToString.Trim)
                        item.SubItems(i).BackColor = Color.Red
                        Errores = Errores + 1
                    End If
                    TotalDiios = TotalDiios + 1
                    lvVentaDiio.Items.Add(item)
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        lblTotDiios.Text = TotalDiios
        lblErrores.Text = Errores
        lvVentaDiio.EndUpdate()
    End Function
    Private Sub btnLeeBaston_Click(sender As Object, e As EventArgs) Handles btnLeeBaston.Click
        lblErrores.Text = 0
        lblTotDiios.Text = 0
        LeeBaston()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lvVentaDiio.SelectedItems.Count = 0 Then
            MsgBox("PRIMERO DEBE SELECCIONAR DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        frmVentasTipoCausa.Show()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        If lvVentaDiio.Items.Count = 0 Then
            MsgBox("DEBE INGRESAR DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If

        If txtObservacion.TextLength < 10 Then
            MsgBox("DEBE INGRESAR COMO MINIMO 10 CARACTERES EN LA OBSERVACION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        If lblErrores.Text > 0 Then
            MsgBox("DEBE ELIMINAR TODOS LOS ERRORES", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If

        Dim i As Integer

        For i = 0 To lvVentaDiio.Items.Count - 1
            If lvVentaDiio.Items(i).SubItems(14).Text = "" Or lvVentaDiio.Items(i).SubItems(15).Text = "" Then
                If MsgBox("TODOS LOS DIIOS DEBEN TENER ASIGNADO TIPO SALIDA Y TIPO CAUSA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If
            If lvVentaDiio.Items(i).SubItems(4).Text = "" Then
                If MsgBox("HAY CATEGORIAS QUE NO TIENEN ASIGNADO PRECIO DE VENTA, CONTACTAR A TRAZABILIDAD", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If
        Next



        ReqVentaGrabar(lvVentaDiio)
        Me.Close()
    End Sub
    Public Function TablaReqVenta(ByVal lvVentaDiio As ListView) As DataTable
        TablaReqVenta = Nothing

        Dim table As DataTable = New DataTable("VentasRequerimiento")

        table.Columns.Add("Diio", System.Type.GetType("System.Int32"))
        table.Columns.Add("CategoCod", System.Type.GetType("System.String"))
        table.Columns.Add("CategoNom", System.Type.GetType("System.String"))
        table.Columns.Add("PreUnitario", System.Type.GetType("System.Decimal"))
        table.Columns.Add("PreTotal", System.Type.GetType("System.Decimal"))
        table.Columns.Add("EstProductivo", System.Type.GetType("System.String"))
        table.Columns.Add("EstReproductivo", System.Type.GetType("System.String"))
        table.Columns.Add("FechaPP", System.Type.GetType("System.DateTime"))
        table.Columns.Add("EstSalud", System.Type.GetType("System.String"))
        table.Columns.Add("CausaCod", System.Type.GetType("System.String"))
        table.Columns.Add("SalidaCod", System.Type.GetType("System.String"))


        Dim n As Integer
        n = lvVentaDiio.Items.Count
        For i = 0 To n - 1
            Dim FPP As DateTime
            FPP = lvVentaDiio.Items(i).SubItems(8).Text
            table.Rows.Add(lvVentaDiio.Items(i).SubItems(1).Text,
                           lvVentaDiio.Items(i).SubItems(2).Text,
                           lvVentaDiio.Items(i).SubItems(3).Text,
                           lvVentaDiio.Items(i).SubItems(4).Text,
                           lvVentaDiio.Items(i).SubItems(5).Text,
                           lvVentaDiio.Items(i).SubItems(6).Text,
                           lvVentaDiio.Items(i).SubItems(7).Text,
                           FPP,
                           lvVentaDiio.Items(i).SubItems(11).Text,
                           lvVentaDiio.Items(i).SubItems(14).Text,
                           lvVentaDiio.Items(i).SubItems(15).Text)
        Next
        TablaReqVenta = table

    End Function
    Private Sub Firmantes()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_RequerimientosVentasAprovadores", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        Dim Centro As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Centro", Centro)
        '
        'cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        'cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        lvAprobadores.Items.Clear()
        lvAprobadores.BeginUpdate()

        Try

            con.Open()
            rdr = cmd.ExecuteReader()

            'Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            'Dim mret As String = cmd.Parameters("@ResultMsg").Value

            Try
                While rdr.Read()
                    Dim item As New ListViewItem(rdr("JefeRut").ToString.Trim)
                    item.SubItems.Add(rdr("JefeNom").ToString.Trim)
                    lvAprobadores.Items.Add(item)
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
        lvAprobadores.EndUpdate()

    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        Firmantes()
    End Sub
    Private Sub ReqVentaGrabar(ByVal lvVentaDiio As ListView)
        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRequerimientosVenta_GrabarINS", con)
        Dim table As DataTable = TablaReqVenta(lvVentaDiio)
        Dim Centro As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        Dim ClienteCod As String = cboClientes.SelectedValue
        Dim Obs As String = txtObservacion.Text
        Dim FechaVenta As DateTime = dtpFecha.Value
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@Prioridad", Prioridad)
        cmd.Parameters.AddWithValue("@ClienteCod", ClienteCod)
        cmd.Parameters.AddWithValue("@Obs", Obs)
        cmd.Parameters.AddWithValue("@FechaVenta", FechaVenta)
        cmd.Parameters.AddWithValue("@DTGanado_ReqVenta", table)
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        MsgBox("REGISTRO EXITOSO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "VALIDACION")
        'Return ResultMsg
    End Sub

    Private Sub rbNormal_CheckedChanged(sender As Object, e As EventArgs) Handles rbNormal.CheckedChanged
        If rbNormal.Checked Then
            Prioridad = "Normal"
        Else
            Prioridad = "Alta"
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim item As ListViewItem = New ListViewItem()
        For Each item In lvVentaDiio.SelectedItems
            Errores = Errores - 1
            TotalDiios = TotalDiios - 1
            lblTotDiios.Text = TotalDiios
            lblErrores.Text = Errores
            item.Remove()
        Next
    End Sub
End Class