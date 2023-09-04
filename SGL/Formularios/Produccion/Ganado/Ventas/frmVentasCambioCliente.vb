Imports System.Data.SqlClient

Public Class frmVentasCambioCliente
    Dim CentroCod As Integer
    Private Sub frmVentasCambioCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        Dim item As ListViewItem = frmVentas2.lvGanado.SelectedItems(0)
        Dim NroVenta As String = item.SubItems(13).Text
        Dim NomCliente As String = item.SubItems(7).Text
        CentroCod = item.SubItems(11).Text

        txtClienteNom.Text = NomCliente
        txtNroVenta.Text = NroVenta

        ERPClientes()
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

        cboCambioCliente.ValueMember = "ClienteCod"
        cboCambioCliente.DisplayMember = "ClienteRazSoc"
        cboCambioCliente.DataSource = dt

    End Sub

    Private Sub bnCerrar_Click(sender As Object, e As EventArgs) Handles bnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnCambiarCliente_Click(sender As Object, e As EventArgs) Handles btnCambiarCliente.Click
        If cboCambioCliente.SelectedValue = "" Then
            MsgBox("DEBE SELECCIONAR UN CLIENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "VALIDACION")
            Exit Sub
        End If
        CambioCliente()
    End Sub
    Private Sub CambioCliente()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVenta_CambioCliente", con)
        Dim NroVenta As String = txtNroVenta.Text
        Dim ClienteCod As String = cboCambioCliente.SelectedValue
        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""

        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter
        Dim rdr As SqlDataReader = Nothing

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@NroVenta", NroVenta)
        cmd.Parameters.AddWithValue("@Cliente", ClienteCod)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value

            If ResultCod <> 0 Then
                Cursor.Current = Cursors.Default
                If MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Try
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        MsgBox("GRABACION EXITOSA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GRABACION CLIENTE")
        Me.Close()
        frmVentas2.LlenaGrillaVentas()
    End Sub
End Class