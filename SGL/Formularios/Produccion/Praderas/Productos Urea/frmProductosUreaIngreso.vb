
Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Imports System.Data.SqlClient
Imports DevExpress.Data.Filtering.Helpers
Imports NetOffice.OfficeApi

Public Class frmProductosUreaIngreso
    Dim BuscarConcentrado As Integer = 0
    'Private Sub LimpiaDatos()
    '    txtCodProducto.Text = ""
    '    txtNomProducto.Text = ""
    '    txtCodCuenta.Text = ""
    '    txtNomCuenta.Text = ""
    '    txtCodPresupuesto.Text = ""
    '    tipCentro.SelectedIndex = 0
    'End Sub


    Public Sub ConsultaProductos()
        Dim cent_ As String = ""

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spProductos_ConsultarUrea", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Producto", txtProd.Text)
        cmd.Parameters.AddWithValue("@TipoCentro", tipCentro.Text)

        lvInsumos.BeginUpdate()
        lvInsumos.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                    item.SubItems.Add(rdr("ProdUreaCod").ToString.Trim)
                    item.SubItems.Add(rdr("ProdUreaTipoCentro").ToString.Trim)
                    item.SubItems.Add(rdr("FertSueloTipUsoNom").ToString.Trim)
                    item.SubItems.Add(rdr("ProdUreaNom").ToString.Trim)
                    item.SubItems.Add(rdr("ProdUreaCuentaCod").ToString)
                    item.SubItems.Add(rdr("ProdUreaCuentaNom").ToString.Trim)
                    item.SubItems.Add(rdr("ProdUreaItemGastoCod").ToString)
                    item.SubItems.Add(rdr("ProdUreaItemGastoNom").ToString.Trim)
                    item.SubItems.Add(rdr("Nitrogeno").ToString.Trim)
                    item.SubItems.Add(rdr("Azufre").ToString.Trim)
                    item.SubItems.Add(rdr("Potasio").ToString.Trim)
                    item.SubItems.Add(rdr("Fosforo").ToString.Trim)
                    item.SubItems.Add(rdr("FertSueloTipUsoCod").ToString.Trim)

                    lvInsumos.Items.Add(item)
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
        BuscarConcentrado = 0
SalirProc:
        lvInsumos.EndUpdate()
    End Sub

    Private Function EliminarProducto() As Boolean
        EliminarProducto = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spProductos_EliminarFert", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim prod_ As String = lvInsumos.SelectedItems(0).SubItems(2).Text            'producto

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Producto", prod_)
        cmd.Parameters.AddWithValue("@Cuenta", lvInsumos.SelectedItems(0).SubItems(6).Text)
        cmd.Parameters.AddWithValue("@ItemPpto", lvInsumos.SelectedItems(0).SubItems(8).Text)
        cmd.Parameters.AddWithValue("@TipoCentro", lvInsumos.SelectedItems(0).SubItems(3).Text)
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

            EliminarProducto = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvInsumos.SelectedItems.Count = 0 Then Exit Sub

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




    Private Sub btnConfirmar_Click(sender As System.Object, e As System.EventArgs) Handles btnConfirmar.Click
        frmProductosUreaIngresoDetalle.Show()

        ConsultaProductos()
        'If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        'If MsgBox("¿ DESEA AGREGAR EL PRODUCTO UREA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        '    Exit Sub
        'End If

        'Dim variable As Boolean
        'Dim n As Integer
        'variable = True
        'n = lvGanado.Items.Count.ToString
        'For i = 0 To n - 1
        '    If lvGanado.Items(i).SubItems(2).Text.Trim = txtCodProducto.Text And lvGanado.Items(i).SubItems(4).Text.Trim = txtCodCuenta.Text And lvGanado.Items(i).SubItems(6).Text.Trim = txtCodPresupuesto.Text And lvGanado.Items(i).SubItems(8).Text.Trim = tipCentro.Text Then
        '        variable = False
        '        If MsgBox("PRODUCTO CON LAS MISMAS CARACTERISTICAS YA INGRESADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '            Exit Sub
        '        End If
        '    End If
        'Next
        'If variable = True Then
        '    If GrabarProducto() = True Then
        '        LimpiaDatos()

        '    End If
        'End If


    End Sub



    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvInsumos.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}


        ExportToExcelGrilla(lvInsumos, tot)
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lvInsumos.SelectedItems.Count = 0 Then Exit Sub

        Dim UreaDetalle As New frmProductosUreaIngresoDetalle

        UreaDetalle.Actualizar = 1
        UreaDetalle.txtCodProducto.Text = lvInsumos.SelectedItems(0).SubItems(2).Text
        UreaDetalle.txtCodProducto.Enabled = False
        UreaDetalle.tipCentro.Text = lvInsumos.SelectedItems(0).SubItems(3).Text
        UreaDetalle.tipCentro.Enabled = Enabled
        UreaDetalle.txtCodCuenta.Text = lvInsumos.SelectedItems(0).SubItems(6).Text
        UreaDetalle.txtCodPresupuesto.Text = lvInsumos.SelectedItems(0).SubItems(8).Text
        UreaDetalle.txtNitro.Text = lvInsumos.SelectedItems(0).SubItems(10).Text
        UreaDetalle.Label10.Text = "ACTUALIZACION PRODUCTO"
        UreaDetalle.btnFinalizar.Text = "ACTUALIZAR"
        UreaDetalle.Cuenta = lvInsumos.SelectedItems(0).SubItems(6).Text
        UreaDetalle.ItemGasto = lvInsumos.SelectedItems(0).SubItems(8).Text
        UreaDetalle.TipoCentro = lvInsumos.SelectedItems(0).SubItems(3).Text
        UreaDetalle.Nitrogeno = lvInsumos.SelectedItems(0).SubItems(10).Text
        UreaDetalle.Azufre = lvInsumos.SelectedItems(0).SubItems(11).Text
        UreaDetalle.Potasio = lvInsumos.SelectedItems(0).SubItems(12).Text
        UreaDetalle.Fosforo = lvInsumos.SelectedItems(0).SubItems(13).Text
        UreaDetalle.FertUsoCod = lvInsumos.SelectedItems(0).SubItems(14).Text
        UreaDetalle.Show()
        ConsultaProductos()


    End Sub


    Private Sub txtProd_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProd.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnBuscar_Click(sender, e)
        End If
    End Sub
End Class