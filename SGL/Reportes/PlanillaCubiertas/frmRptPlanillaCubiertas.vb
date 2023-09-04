

Public Class frmRptPlanillaCubiertas

    Public Empresa As Integer = 0
    Public Centro As String = ""


    Private Sub frmRptPlanillaCubiertas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Height = 660
        Me.Width = 1130
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 10) / 2)
        'Me.Top = 10
        'Me.Left = 50


        Me.spCubiertas_PlanillaTableAdapter.Connection.ConnectionString = GetConnectionString()

        Me.spCubiertas_PlanillaTableAdapter.Fill(Me.MNKPROD_DS_PlanillaCubiertas.spCubiertas_Planilla, Empresa, Centro, Now, Now, LoginUsuario, NombrePC)

        'Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class