




Public Class frmAlarmasMensaje

    Public lvDatos As ListView


    Private Sub ProcesarTodos()
        With frmAlarmas
            For Each itm As ListViewItem In lvDatos.Items
                itm.SubItems(2).Text = txtMensaje.Text
            Next
        End With
    End Sub


    Private Sub ProcesarSeleccionados()
        With frmAlarmas
            For Each itm As ListViewItem In lvDatos.SelectedItems
                itm.SubItems(2).Text = txtMensaje.Text
            Next
        End With
    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub btnProcesar_Click(sender As System.Object, e As System.EventArgs) Handles btnProcesar.Click
        If rbtnTodo.Checked Then
            ProcesarTodos()
        Else
            ProcesarSeleccionados()
        End If

        Cerrar()
    End Sub


    Private Sub txtMensaje_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtMensaje.TextChanged
        'btnProcesar.Enabled = txtMensaje.Text.Length
    End Sub


    Private Sub frmAlarmasMensaje_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        txtMensaje.Focus()
    End Sub


    Private Sub frmAlarmasMensaje_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtMensaje.Text = ""
    End Sub


    Private Sub txtMensaje_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtMensaje.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnProcesar.PerformClick()
        End If
    End Sub
End Class