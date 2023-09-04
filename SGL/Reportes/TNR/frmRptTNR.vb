


Public Class frmRptTNR

    Public Empresa As Integer = 0
    Public Centro As String = ""
    Public Temporada As Integer = 0
    Public FechaTope As Date


    Private Sub frmRptTNR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MNKPROD_DS_TNR.spGanado_TNR' Puede moverla o quitarla según sea necesario.
        'Me.spGanado_TNRTableAdapter.Fill(Me.MNKPROD_DS_TNR.spGanado_TNR)

        'Me.ReportViewer1.RefreshReport()

        Me.Height = 660
        Me.Width = 1130
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 10) / 2)
        'Me.Top = 10
        'Me.Left = 50


        Me.spGanado_TNRTableAdapter.Connection.ConnectionString = GetConnectionString()

        Me.spGanado_TNRTableAdapter.Fill(Me.MNKPROD_DS_TNR.spGanado_TNR, _
                                                        Empresa, Centro, Temporada, FechaTope, LoginUsuario, NombrePC)

        Me.ReportViewer1.RefreshReport()

    End Sub
End Class