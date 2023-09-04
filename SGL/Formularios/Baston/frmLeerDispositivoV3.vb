



Public Class frmLeerDispositivoV3



    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'COMPort.Dispose()
        'Me.Dispose()
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub




    Private Sub frmLeerDispositivoV3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.Panel1.Width) / 2)
        'Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height + 50) / 2)
        'Me.Left = Me.Left + (frmMAIN.pnlMenu.Width / 2)


        'If QuitarOrigenExcel Then
        '    cboTipoBaston.Items.Remove("PLANILLA EXCEL")
        'End If


    End Sub



    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub



    Private Sub btnGallaguerHR4_Click(sender As System.Object, e As System.EventArgs) Handles btnGallaguerHR4.Click

    End Sub



End Class