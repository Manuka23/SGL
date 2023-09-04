


Imports Microsoft.Reporting.WinForms



Public Class frptOrdenVenta

    Public Param1_NumeroVenta As Integer


    Private Sub frptOrdenVenta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim myParam As New ReportParameter("Numero", Param1_NumeroVenta)
        ReportViewer1.ServerReport.SetParameters(myParam)
        ReportViewer1.ShowParameterPrompts() = False

        'ReportViewer1.ServerReport.ReportServerUrl = ReportViewer1.ServerReport.ReportServerUrl + "&rc:Parameters=false "

        ReportViewer1.ServerReport.ReportPath = "/Administracion y Finanzas/Ventas/Orden de Venta" '+ "&rc:Parameters=false"

        ReportViewer1.Refresh()
        ReportViewer1.RefreshReport()
    End Sub
End Class