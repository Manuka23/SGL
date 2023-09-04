Imports Microsoft.Reporting.WinForms
Public Class frptPartosAnalisisDiios
    Public FecIni As String
    Public FecFin As String
    Public CenCod As String
    Public EmpCod As Integer
    Private Sub frptPartos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load
        showReport()
    End Sub
    Public Sub showReport()
        Dim paramReport(3) As ReportParameter

        Dim prmEmpCod As New ReportParameter("EmpCod", EmpCod)
        Dim prmCenCod As New ReportParameter("CenCod", CenCod)
        Dim prmini As New ReportParameter("FecIni", FecIni)
        Dim prmfin As New ReportParameter("FecFin", FecFin)


        paramReport(0) = prmEmpCod
        paramReport(1) = prmCenCod
        paramReport(2) = prmini
        paramReport(3) = prmfin

        Me.ReportViewer1.ServerReport.SetParameters(paramReport)
        'Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.ReportViewer1.ShowParameterPrompts() = True
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class