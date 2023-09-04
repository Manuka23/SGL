
Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Imports System.Data.SqlClient
Public Class frmProductosConcentrado
    Dim BuscarConcentrado As Integer = 0
    Private Sub LimpiaDatos()
        tipCentro.SelectedIndex = 0
    End Sub



    Public Sub ConsultaProductos()
        Dim cent_ As String = ""

        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPProductos_ListadoBodegaConcentradoCFG", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@TipoCentro", tipCentro.Text)

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    If BuscarConcentrado = 1 Then
                        If rdr("IteNom").ToString.Trim.Contains(txtProd.Text) Then
                            Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                            item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                            item.SubItems.Add(rdr("ProdCodigo").ToString.Trim)
                            item.SubItems.Add(rdr("IteNom").ToString.Trim)
                            item.SubItems.Add(rdr("ProdConversion").ToString.Trim)
                            item.SubItems.Add(rdr("ProdCuentaCod").ToString) 'rdr(IIf(SRV_Servidor <> "SRVMNK", "ProdCuentaCod", "ProdCuenta")).ToString.Trim)
                            item.SubItems.Add(rdr("CtaNom").ToString.Trim)
                            item.SubItems.Add(rdr("ProdItemGastoCod").ToString) 'IIf(SRV_Servidor <> "SRVMNK", "ProdItemGastoCod", "ProdItemGasto")).ToString.Trim)
                            item.SubItems.Add(rdr("ProdIGastoNom").ToString.Trim)
                            item.SubItems.Add(rdr("ProdTipoCentro").ToString.Trim)
                            item.SubItems.Add(rdr("BI").ToString.Trim)
                            item.SubItems.Add(rdr("ProdUsaBI").ToString.Trim)
                            lvGanado.Items.Add(item)
                            i = i + 1
                        End If
                    Else
                        Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                        item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                        item.SubItems.Add(rdr("ProdCodigo").ToString.Trim)
                        item.SubItems.Add(rdr("IteNom").ToString.Trim)
                        item.SubItems.Add(rdr("ProdConversion").ToString.Trim)
                        item.SubItems.Add(rdr("ProdCuentaCod").ToString) 'rdr(IIf(SRV_Servidor <> "SRVMNK", "ProdCuentaCod", "ProdCuenta")).ToString.Trim)
                        item.SubItems.Add(rdr("CtaNom").ToString.Trim)
                        item.SubItems.Add(rdr("ProdItemGastoCod").ToString) 'IIf(SRV_Servidor <> "SRVMNK", "ProdItemGastoCod", "ProdItemGasto")).ToString.Trim)
                        item.SubItems.Add(rdr("ProdIGastoNom").ToString.Trim)
                        item.SubItems.Add(rdr("ProdTipoCentro").ToString.Trim)
                        item.SubItems.Add(rdr("BI").ToString.Trim)
                        item.SubItems.Add(rdr("ProdUsaBI").ToString.Trim)
                        item.SubItems.Add(rdr("Vigente").ToString.Trim)
                        lvGanado.Items.Add(item)
                        i = i + 1
                    End If

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        BuscarConcentrado = 0
SalirProc:
        lvGanado.EndUpdate()
    End Sub

    Private Function EliminarProducto() As Boolean
        EliminarProducto = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spProductos_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim prod_ As String = lvGanado.SelectedItems(0).SubItems(2).Text            'producto

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Producto", prod_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Cuenta", lvGanado.SelectedItems(0).SubItems(5).Text)
        cmd.Parameters.AddWithValue("@ItemPpto", lvGanado.SelectedItems(0).SubItems(7).Text)
        cmd.Parameters.AddWithValue("@TipoCentro", lvGanado.SelectedItems(0).SubItems(9).Text)
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

            EliminarProducto = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function




    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA ELIMINAR EL PRODUCTO SELECCIONADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarProducto() = True Then

            ConsultaProductos()

        End If
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Me.Dispose()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmProductosConcentrado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        General.TipoCentros.Cargar()
        CboLLenaTipoCentro()
        ConsultaProductos()
    End Sub
    Private Sub CboLLenaTipoCentro()
        If General.TipoCentros.NroRegistros = 0 Then Exit Sub
        tipCentro.Items.Clear()
        tipCentro.Items.Add("(Todos)")
        Dim i As Integer
        For i = 0 To General.TipoCentros.NroRegistros - 1
            tipCentro.Items.Add(General.TipoCentros.Nombre(i))
        Next
        tipCentro.SelectedIndex = 0
    End Sub



    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        LimpiaDatos()
    End Sub




    Private Sub btnConfirmar_Click(sender As System.Object, e As System.EventArgs) Handles btnConfirmar.Click
        frmProductosConcentradoDetalle.Show()

        ConsultaProductos()


    End Sub



    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}


        ExportToExcelGrilla(lvGanado, tot)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscarConcentrado = 1
        ConsultaProductos()
    End Sub

    Private Sub btnBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            BuscarConcentrado = 1
            ConsultaProductos()
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        'CONFIRMAR
        Dim ProductoConcentrado As New frmProductosConcentradoDetalle

        ProductoConcentrado.Actualizar = 1
        ProductoConcentrado.txtCodProducto.Text = lvGanado.SelectedItems(0).SubItems(2).Text
        ProductoConcentrado.txtCodProducto.Enabled = False
        ProductoConcentrado.tipCentro.Text = lvGanado.SelectedItems(0).SubItems(9).Text
        ProductoConcentrado.tipCentro.Enabled = False
        ProductoConcentrado.txtCodCuenta.Text = lvGanado.SelectedItems(0).SubItems(5).Text
        ProductoConcentrado.txtCodPresupuesto.Text = lvGanado.SelectedItems(0).SubItems(7).Text
        ProductoConcentrado.CbBi = lvGanado.SelectedItems(0).SubItems(11).Text
        ProductoConcentrado.Label10.Text = "ACTUALIZACION PRODUCTO"
        ProductoConcentrado.btnFinalizar.Text = "ACTUALIZAR"
        ProductoConcentrado.Cuenta = lvGanado.SelectedItems(0).SubItems(4).Text
        ProductoConcentrado.ItemGasto = lvGanado.SelectedItems(0).SubItems(7).Text
        ProductoConcentrado.txtKilos.Text = lvGanado.SelectedItems(0).SubItems(4).Text
        ProductoConcentrado.Estado = lvGanado.SelectedItems(0).SubItems(12).Text
        ProductoConcentrado.Show()
        ConsultaProductos()

        ConsultaProductos()
    End Sub
    Private Sub txtProd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProd.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnBuscar_Click(sender, e)
        End If
    End Sub

End Class