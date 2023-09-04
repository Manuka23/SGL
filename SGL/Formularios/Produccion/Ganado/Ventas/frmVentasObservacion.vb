Public Class frmVentasObservacion
    Public Shared Estado As String
    Public Shared Cancelar As Boolean
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtObservacion.TextLength < 10 Then
            MsgBox("DEBE INGRESAR COMO MINIMO 10 CARACTERES EN LA OBSERVACION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar = True
        Me.Close()
    End Sub

    Private Sub rdbVivo_CheckedChanged(sender As Object, e As EventArgs) Handles rdbVivo.CheckedChanged
        If rdbVivo.Checked = True Then
            Estado = "VIVO"
        End If
    End Sub
    Private Sub rdbMuerto_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMuerto.CheckedChanged
        If rdbMuerto.Checked = True Then
            Estado = "MUERTO"
        End If
    End Sub
    Private Sub rdbDesaparecido_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDesaparecido.CheckedChanged
        If rdbDesaparecido.Checked = True Then
            Estado = "DESAPARECIDO"
        End If
    End Sub

    Private Sub frmVentasObservacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Cancelar = False

        rdbVivo.Checked = True
    End Sub
End Class