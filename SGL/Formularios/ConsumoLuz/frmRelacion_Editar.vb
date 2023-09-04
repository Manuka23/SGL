Imports System.Data.SqlClient

Public Class frmRelacion_Editar
    Private Sub frmRelacion_Edtar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 125
        Me.Left = 30
        frmPoblacion.Enabled = False
        tbxNombre.Text = frmRelacion.lvRelacion.SelectedItems.Item(0).SubItems(1).Text

    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If String.IsNullOrWhiteSpace(tbxNombre.Text) Then
            MsgBox("DEBE SEÑALAR UN NOMBRE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            tbxNombre.Focus()
        Else
            If Guardar() Then
                frmRelacion.Close()
                frmRelacion.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        frmRelacion.Enabled = True
    End Sub

    Private Function Guardar()
        Guardar = False
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spLuz_RelacionEditar]", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@RelacionNom", tbxNombre.Text)
        cmd.Parameters.AddWithValue("@RelacionCod", frmRelacion.lvRelacion.SelectedItems.Item(0).SubItems(0).Text)
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
End Class