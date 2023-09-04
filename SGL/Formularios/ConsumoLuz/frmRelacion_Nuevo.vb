Imports System.Data.SqlClient

Public Class frmRelacion_Nuevo
    Private Sub frmRelacion_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 125
        Me.Left = 30
        frmRelacion.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        frmRelacion.Enabled = True
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
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
    Private Function Guardar()
        Guardar = False
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spLuz_RelalacionAgregar]", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@RelacionNom", tbxNombre.Text)
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