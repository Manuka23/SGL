
Imports System.Data.SqlClient

Public Class frmBodegaIngresoTraslado

    Public Param4_Producto As String
    Public Param_ClaseTrl As Boolean
    Private ReadOnly RetIDGP As String = ""

    Private INV_GrabarMovimientoBodega As New INV_GrabarMovimientoBodega
    Public EmpresaCod As Integer
    Public BodegaCod As String
    Public BodegaNom As String
    Private BodegaCodD As String
    Private BodegaNomD As String
    Private EmpresaIntCod As Integer
    Private EmpresaIntNom As String
    Private ITEMNMBR As String = ""
    Private ITEMDESC As String = ""
    Private ITEMSTK As String = ""
    Private UOFM As String = ""
    Private ITMCLSCD As String = ""
    Private CURRCOST As Decimal = 0
    Private PermisoTrlInterComp As String = ""
    Private Sub FrmBodegaIngresoTraslado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim PermisoColumna As String = "UsrTrasInterComp" 'nombre de la columna donde queremos buscar el permiso
        cboEmpresaInCompania.Enabled = False
        chbInterCompania.Enabled = False
        lblTitulo.Text = "INGRESO DE TRASLADO DESDE BODEGA: " & BodegaNom
        Label5.Text = "Destino"

        EmpresaIntCod = EmpresaCod

        MSTRInvProductos.DSCboProductosTraslado_FrmQRY(EmpresaCod, BodegaCod, Param_ClaseTrl, False, cboItems)
        Usuario_Permisos.DSUsuarioPermisos_FrmQRY(PermisoColumna)

        DTUsuarioPermisosFrmQRY = Usuario_Permisos.GETData
        For i As Integer = 0 To DTUsuarioPermisosFrmQRY.Rows.Count - 1
            PermisoTrlInterComp = DTUsuarioPermisosFrmQRY.Rows(i).Item("Permiso").ToString.Trim
            Exit For
        Next

        If PermisoTrlInterComp = 1 Then
            'cboEmpresaInCompania.Enabled = True
            chbInterCompania.Enabled = True
        End If

        MSTRInvBodegas.DSCboBodegasDestino_FrmQRY(BodegaCod, cboBodegaDestino, EmpresaIntCod)
        dtpFecha.Value = Now()

        cboItems.Text = Param4_Producto
    End Sub
    Private Sub cboBodegaDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBodegaDestino.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboBodegaDestino.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            BodegaCodD = selectedRow("LOCNCODE")
            BodegaNomD = selectedRow("LOCNDSCR")
        End If
    End Sub
    Private Sub CboItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItems.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboItems.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            txtStock.Text = selectedRow("ITEMSTK")
            lblUnidMed.Text = selectedRow("UOFM")
            ITEMNMBR = selectedRow("ITEMNMBR")
            ITEMDESC = selectedRow("ITEMDESC")
            ITEMSTK = selectedRow("ITEMSTK")
            UOFM = selectedRow("UOFM")
            ITMCLSCD = selectedRow("ITMCLSCD")
            CURRCOST = selectedRow("CURRCOST")
        End If
    End Sub
    Private Function ValidaDatos() As Boolean
        ValidaDatos = False
        If cboItems.SelectedIndex = -1 Or cboItems.Text = "" Then

            If MsgBox("DEBE SELECCIONAR -- UN PRODUCTO --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If

            Exit Function
        End If
        Dim traslado As String = ITMCLSCD
        If cboBodegaDestino.SelectedIndex = -1 Or cboBodegaDestino.Text = "(Seleccione)" Then

            If MsgBox("DEBE SELECCIONAR -- UN DESTINO --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If

            Exit Function

        End If
        Dim cantidad As Decimal = txtCantidad.Text

        If cantidad > ITEMSTK And Not traslado.Contains("TRASLADOS") Then
            If MsgBox("LA CANTIDAD NO PUEDE SUPERAR AL STOCK DEL PRODUCTO --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If

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
        Return True
    End Function
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If IsNumeric(txtCantidad.Text) = False Then
            MsgBox("ERROR. Ingresar datos validos", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        If ValidaDatos() = False Then Exit Sub
        cboBodegaDestino.Enabled = False


        Dim n As Integer
        n = lvItemsTraslado.Items.Count.ToString
        For i = 0 To n - 1
            Dim ItemCod As String = lvItemsTraslado.Items(i).SubItems(1).Text.Trim
            Dim ItemClase As String = lvItemsTraslado.Items(i).SubItems(9).Text.Trim
            If ITEMNMBR.Trim = ItemCod.Trim Then
                If MsgBox("Producto ya ingresado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
            If ITMCLSCD = "TRASLADOS" And ItemClase <> "TRASLADOS" Then
                If MsgBox("NO puede agregar un producto de tipo Traslado a los actuales ítems. No puede mezclar.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
            If ITMCLSCD <> "TRASLADOS" And ItemClase = "TRASLADOS" Then
                If MsgBox("NO puede agregar este producto pues hay productos de tipo traslado agregados. No puede mezclar.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
        Next
        Try

            Dim item As New ListViewItem((lvItemsTraslado.Items.Count + 1).ToString)    'primera columna, para ordenar los datos
            item.SubItems.Add(ITEMNMBR)
            item.SubItems.Add(cboItems.Text) '' nombre producto
            item.SubItems.Add(txtCantidad.Text)
            item.SubItems.Add(lblUnidMed.Text.Trim)
            item.SubItems.Add("0")                      'consumo no grabado
            item.SubItems.Add(txtStock.Text)
            item.SubItems.Add(BodegaCodD) 'codigo bodega
            item.SubItems.Add(BodegaNomD) 'nombre bodega
            item.SubItems.Add(ITMCLSCD)
            item.SubItems.Add(CURRCOST)
            item.SubItems.Add(Math.Round(txtCantidad.Text * CURRCOST))

            lvItemsTraslado.Items.Add(item)

            validafinalizar()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "SGL")
        End Try
        cboEmpresaInCompania.Enabled = False
        chbInterCompania.Enabled = False
    End Sub
    Public Sub validafinalizar()
        If lvItemsTraslado.Items.Count <> 0 Then
            btnFinalizar.Enabled = True
            btnEliminar.Enabled = True
        Else
            btnFinalizar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub
    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If lvItemsTraslado.Items.Count = 0 Then
            MsgBox("Debe agregar por lo menos un registro para finalizar", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        If dtpFecha.Value > Date.Now Then
            MsgBox("ERROR. Esta Ingresando Consumos con una fecha mayor a la fecha actual", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        If BodegaCod = "" Then
            MsgBox("Error al recuperar codigo de la bodega del Origen. Contacte a IT.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If
        If MsgBox("¿ DESEA GRABAR EL TRASLADO INGRESADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        GrabaTraslado()
        Me.Close()
        frmBodega.btnBuscar.PerformClick()
    End Sub
    Private Sub GrabaTraslado()
        Dim ObsGuia As String = ""
        With frmIngresoObservacion
            .ShowDialog()

            If .Cancelar = True Then
                Exit Sub
            End If

            ObsGuia = .ObservGuia
        End With

        If ObsGuia <> "" Then
            If MsgBox("¿ DESEA GRABAR EL TRASLADO INGRESADO ?" + vbCrLf + vbCrLf + "RECUERDE QUE SE GENERARA UNA GUIA DE DESPACHO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If
        Dim TipoMovimiento As Integer = 3

        If chbInterCompania.Checked Then
            TipoMovimiento = 2
        End If
        Dim n As Integer
        n = lvItemsTraslado.Items.Count.ToString
        For i = 0 To n - 1
            Dim ItemClase As String = lvItemsTraslado.Items(i).SubItems(9).Text.Trim
            If ItemClase = "TRASLADOS" Then
                TipoMovimiento = 99 'Si algunos de los items es de Clase Traslado, entonces el tipo Mov = 99
                Exit For
            End If
        Next
        Dim guia_ret As Integer = 0
        Dim DetalleLV As DataTable = LVToDataTableTrl()

        Dim resultado As String = INV_GrabarMovimientoBodega.GrabarInventario(EmpresaCod, EmpresaIntCod, DetalleLV, dtpFecha.Value, TipoMovimiento, ObsGuia, BodegaCod, BodegaCodD)

        Dim msg As String = "GUIA ELECTRÓNICA NRO: " + INV_GrabarMovimientoBodega.guia.ToString + " GENERADA --- OK ---" + vbCrLf + vbCrLf + "DEBE IMPRIMIR EL SIGUIENTE DOCUMENTO DE TRASLADO"

        Cursor.Current = Cursors.WaitCursor

        If MsgBox(msg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
        End If

        'Dim Empr As Integer = EmpresaCod 'IIf(Empresa = 76294870, 76011573, Empresa)

        Dim PdfNomSuite As String = SuiteElectronica.GeneraNombreArchivoBodega(EmpresaCod, 52, INV_GrabarMovimientoBodega.guia)

        SuiteElectronica.MostrarPDFeSuite(PdfNomSuite)

        lvItemsTraslado.Items.Clear()

        btnFinalizar.Enabled = False
        btnEliminar.Enabled = False
        Cursor.Current = Cursors.Default
    End Sub
    Private Function LVToDataTableTrl() As DataTable
        LVToDataTableTrl = Nothing

        Dim table As DataTable = New DataTable("TablaDetalle")

        table.Columns.Add("ItemCod", System.Type.GetType("System.String"))
        table.Columns.Add("ItemNom", System.Type.GetType("System.String"))
        table.Columns.Add("ItemCnt", System.Type.GetType("System.Decimal"))
        table.Columns.Add("ItemUM", System.Type.GetType("System.String"))
        table.Columns.Add("ContraCtaCod", System.Type.GetType("System.String"))
        table.Columns.Add("ItemGastoCod", System.Type.GetType("System.String"))
        table.Columns.Add("ItemStkActual", System.Type.GetType("System.Decimal"))
        table.Columns.Add("TipoMov", System.Type.GetType("System.Decimal"))

        For Each itm As ListViewItem In lvItemsTraslado.Items
            table.Rows.Add(itm.SubItems(1).Text, itm.SubItems(2).Text, itm.SubItems(3).Text,
                           itm.SubItems(4).Text, "110701", "",
                           itm.SubItems(6).Text, 3)
        Next

        LVToDataTableTrl = table
    End Function
    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿DESEA ELIMINAR TODOS LOS REGISTROS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        For Each it As ListViewItem In lvItemsTraslado.SelectedItems
            lvItemsTraslado.Items.Remove(it)
            validafinalizar()
        Next
    End Sub

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

    Public Sub chbInterCompania_CheckedChanged(sender As Object, e As EventArgs) Handles chbInterCompania.CheckedChanged
        If chbInterCompania.Checked Then
            cboEmpresaInCompania.Enabled = True
            TRL_EmpresasIntComp.DSCboEmpresaIntComp_FrmQRY(EmpresaCod, cboEmpresaInCompania)
            MSTRInvBodegas.DSCboBodegasDestino_FrmQRY(BodegaCod, cboBodegaDestino, EmpresaIntCod)
            MSTRInvProductos.DSCboProductosTraslado_FrmQRY(EmpresaCod, BodegaCod, Param_ClaseTrl, True, cboItems)
        Else
            cboEmpresaInCompania.Enabled = False
            cboEmpresaInCompania.SelectedIndex = -1
            EmpresaIntCod = EmpresaCod
            MSTRInvBodegas.DSCboBodegasDestino_FrmQRY(BodegaCod, cboBodegaDestino, EmpresaIntCod)
            MSTRInvProductos.DSCboProductosTraslado_FrmQRY(EmpresaCod, BodegaCod, Param_ClaseTrl, False, cboItems)
        End If
    End Sub

    Private Sub cboEmpresaInCompania_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmpresaInCompania.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboEmpresaInCompania.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            EmpresaIntCod = selectedRow("EmpresaCod")
            EmpresaIntNom = selectedRow("EmpresaNom")
        End If
    End Sub

End Class