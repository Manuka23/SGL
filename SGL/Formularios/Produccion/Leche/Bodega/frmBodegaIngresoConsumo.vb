Imports System.Data.SqlClient
Public Class frmBodegaIngresoConsumo

    Public Param4_Producto As String

    Private INV_GrabarMovimientoBodega As New INV_GrabarMovimientoBodega
    Public EmpresaCod As Integer
    Public BodegaCod As String
    Public BodegaNom As String


    Private CuentaCod As String = ""
    Private ItemGastoCod As String = ""
    Private ITEMNMBR As String = ""
    Private ITEMDESC As String = ""
    Private ITEMSTK As String = ""
    Private UOFM As String = ""
    Private Sub FrmBodegaIngresoConsumo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        lblTitulo.Text = "INGRESO DE CONSUMO BODEGA: " & BodegaNom
        lblCostoActual.Visible = False

        MSTRCuentasContables.DSCboCuentasContables_Frm_QRY(cboCuentas)

        MSTRInvProductos.DSCboProductosConsumo_FrmQRY(EmpresaCod, BodegaCod, cboItemsStk)

        dtpFecha.Value = Now()
        cboItemsStk.Text = Param4_Producto
    End Sub
    Private Sub CboCuentas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuentas.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboCuentas.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            CuentaCod = selectedRow("CuentaCod")
        End If

        MSTRCuentasContables.DSCboItemsGasto_Frm_QRY(CuentaCod, cboItemsGasto)
    End Sub
    Private Sub CboItemsGasto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemsGasto.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboItemsGasto.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            ItemGastoCod = selectedRow("ItemGastoCod")
        End If
    End Sub
    Private Sub CboItemsStk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemsStk.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboItemsStk.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            txtStock.Text = selectedRow("ITEMSTK")
            lblUnidMed.Text = selectedRow("UOFM")
            ITEMNMBR = selectedRow("ITEMNMBR")
            ITEMDESC = selectedRow("ITEMDESC")
            ITEMSTK = selectedRow("ITEMSTK")
            UOFM = selectedRow("UOFM")
        End If
    End Sub
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If IsNumeric(txtCantidad.Text) = False Then
            MsgBox("ERROR. Ingresar datos validos", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        If ValidaDatos() = False Then Exit Sub

        Dim n As Integer
        n = lvItemsConsumo.Items.Count.ToString
        For i = 0 To n - 1

            Dim codlb As String = lvItemsConsumo.Items(i).SubItems(3).Text.Trim
            If ITEMNMBR.Trim = codlb.Trim Then
                If MsgBox("Producto ya ingresado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
        Next
        Try
            Dim item As New ListViewItem((lvItemsConsumo.Items.Count + 1).ToString)    'primera columna, para ordenar los datos
            item.SubItems.Add(cboItemsStk.Text)
            item.SubItems.Add(txtCantidad.Text)
            item.SubItems.Add(ITEMNMBR)
            item.SubItems.Add(CuentaCod) 'cboCuentas.SelectedValue)
            item.SubItems.Add(ItemGastoCod)
            item.SubItems.Add("0")                      'consumo no grabado
            item.SubItems.Add(cboCuentas.Text)
            item.SubItems.Add(cboItemsGasto.Text)
            item.SubItems.Add(lblUnidMed.Text)
            item.SubItems.Add(txtStock.Text)
            item.SubItems.Add(1)
            lvItemsConsumo.Items.Add(item)

            validafinalizar()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "SGL")
        End Try
    End Sub

    Public Sub validafinalizar()
        If lvItemsConsumo.Items.Count <> 0 Then
            btnFinalizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
        End If
    End Sub

    Private Sub BtnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If lvItemsConsumo.Items.Count = 0 Then
            MsgBox("Debe agregar por lo menos un registro para finalizar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        If dtpFecha.Value > Date.Now Then
            MsgBox("ERROR. Esta Ingresando Consumos con una fecha mayor a la fecha actual", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        If MsgBox("¿ DESEA GRABAR EL CONSUMO INGRESADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        'obtenemos data_table con el detalle de los productos a consumir}
        Dim DetalleLV As DataTable = LVToDataTable()
        Dim resultado As String = INV_GrabarMovimientoBodega.GrabarInventario(EmpresaCod, 0, DetalleLV, dtpFecha.Value, 1, "", BodegaCod, "")
        MsgBox(resultado, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FINALIZADO")

        lvItemsConsumo.Items.Clear()
        Me.Dispose()
        Me.Close()

        frmBodega.btnBuscar.PerformClick()

    End Sub

    Public Function LVToDataTable() As DataTable
        LVToDataTable = Nothing

        Dim table As DataTable = New DataTable("TablaDetalle")

        table.Columns.Add("ItemCod", System.Type.GetType("System.String"))
        table.Columns.Add("ItemNom", System.Type.GetType("System.String"))
        table.Columns.Add("ItemCnt", System.Type.GetType("System.Double"))
        table.Columns.Add("ItemUM", System.Type.GetType("System.String"))
        table.Columns.Add("ContraCtaCod", System.Type.GetType("System.String"))
        table.Columns.Add("ItemGastoCod", System.Type.GetType("System.String"))        'GetType(Integer)
        table.Columns.Add("ItemStkActual", System.Type.GetType("System.Double"))
        table.Columns.Add("TipoMov", System.Type.GetType("System.Double"))

        For Each itm As ListViewItem In lvItemsConsumo.Items
            table.Rows.Add(itm.SubItems(3).Text, itm.SubItems(1).Text,
                           itm.SubItems(2).Text, itm.SubItems(9).Text,
                           itm.SubItems(4).Text, itm.SubItems(5).Text,
                           itm.SubItems(10).Text, 1)

        Next

        LVToDataTable = table

    End Function

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿DESEA ELIMINAR LOS REGISTROS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        For Each it As ListViewItem In lvItemsConsumo.SelectedItems
            lvItemsConsumo.Items.Remove(it)
            validafinalizar()
        Next

    End Sub

    Private Function ValidaDatos() As Boolean
        ValidaDatos = False
        If cboItemsStk.SelectedIndex = -1 Or cboItemsStk.Text = "" Then
            If MsgBox("DEBE SELECCIONAR -- UN PRODUCTO --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If

            cboItemsGasto.Focus()
            Exit Function
        End If
        If cboCuentas.SelectedIndex = -1 Or cboCuentas.Text = "" Then
            If MsgBox("DEBE SELECCIONAR -- UNA CUENTA --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If

            cboItemsGasto.Focus()
            Exit Function
        End If
        If cboItemsGasto.SelectedIndex = -1 Or cboItemsGasto.Text = "" Then
            If MsgBox("DEBE SELECCIONAR -- UN ITEM DE GASTO --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            cboItemsGasto.Focus()
            Exit Function
        End If

        Dim can, stok As Integer
        can = txtCantidad.Text
        stok = txtStock.Text

        If can > stok Then
            If MsgBox("LA CANTIDAD NO PUEDE SUPERAR AL STOCK DEL PRODUCTO --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            cboItemsGasto.Focus()
            Exit Function
        End If

        If txtCantidad.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR -- LA CANTIDAD --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            txtCantidad.Focus()
            Exit Function
        End If

        If Convert.ToDouble(txtCantidad.Text.Trim) <= 0 Then
            If MsgBox("DEBE INGRESAR -- LA CANTIDAD --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            txtCantidad.Focus()
            Exit Function
        End If
        ValidaDatos = True
    End Function

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Dispose()
        Me.Close()
    End Sub
    Private Sub txtCantidad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Or e.KeyChar = "," Then
                If Me.txtCantidad.Text.Contains(",") Then
                    If Me.txtCantidad.Text.Split(",")(1).Length < 2 Then
                        If Char.IsDigit(e.KeyChar) = False Then
                            e.Handled = True
                        End If
                    Else
                        e.Handled = True
                    End If
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub
End Class