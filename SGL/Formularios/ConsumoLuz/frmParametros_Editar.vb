Imports System.Data.SqlClient

Public Class frmParametros_Editar
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If String.IsNullOrWhiteSpace(tbxValor.Text) Then
            MsgBox("DEBE SEÑALAR UN VALOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
        Else
            If String.IsNullOrWhiteSpace(tbxNombre.Text) Then
                MsgBox("DEBE SEÑALAR UNA DESCRIPCION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                tbxNombre.Focus()
            Else
                If Guardar() Then
                    frmParametros.Close()
                    frmParametros.Show()
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        frmParametros.Enabled = True
        Me.Close()
    End Sub
    Private Function Guardar()
        Guardar = False
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spLuz_ParametrosEditar]", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ParItem", tbxNombre.Text)
        cmd.Parameters.AddWithValue("@ParValor", tbxValor.Text)
        cmd.Parameters.AddWithValue("@ParCod", frmParametros.lvParametros.SelectedItems.Item(0).SubItems(0).Text)
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

    Private Sub frmParametros_Editar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 125
        Me.Left = 35
        frmParametros.Enabled = False
        tbxNombre.Text = frmParametros.lvParametros.SelectedItems.Item(0).SubItems(1).Text
        tbxValor.Text = frmParametros.lvParametros.SelectedItems.Item(0).SubItems(2).Text

    End Sub
End Class