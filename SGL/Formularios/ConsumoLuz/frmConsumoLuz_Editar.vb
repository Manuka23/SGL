Imports System.Data.SqlClient

Public Class frmConsumoLuz_Editar

    Private Function Guardar()
        Guardar = False
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spLuz_ConsumoEditar]", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Consumo", tbxNombre.Text)
        cmd.Parameters.AddWithValue("@Cod", frmConsumoLuzReporte.lvReporte.SelectedItems.Item(0).SubItems(5).Text)
        cmd.Parameters.AddWithValue("@CodCentro", frmConsumoLuzReporte.lvReporte.SelectedItems.Item(0).SubItems(0).Text)
        cmd.Parameters.AddWithValue("@CodCasa", frmConsumoLuzReporte.lvReporte.SelectedItems.Item(0).SubItems(2).Text)
        cmd.Parameters.AddWithValue("@Month", frmConsumoLuzReporte.cbxMes.SelectedIndex + 1)
        cmd.Parameters.AddWithValue("@Year", frmConsumoLuzReporte.cbxYear.SelectedItem)
        cmd.Parameters.Add("@Text", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@Text").Direction = ParameterDirection.Output
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
            Guardar = True
            MsgBox(cmd.Parameters("@Text").Value, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If String.IsNullOrWhiteSpace(tbxNombre.Text) Then
            MsgBox("DEBE SEÑALAR UN CONSUMO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            tbxNombre.Focus()
        Else
            If Guardar() Then
                Me.Close()
                frmConsumoLuzReporte.Close()
                frmConsumoLuzReporte.Show()
            End If
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        frmConsumoLuzReporte.Enabled = True
    End Sub

    Private Sub ConsumoLuz_Modificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 70
        Me.Left = 30
        frmConsumoLuzReporte.Enabled = False
        tbxNombre.Text = frmConsumoLuzReporte.lvReporte.SelectedItems.Item(0).SubItems(3).Text
    End Sub
End Class