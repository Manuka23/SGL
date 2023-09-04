Imports Microsoft.Reporting.WinForms

Public Class frptCierreMensualGanado


    Public CentroCod As String
    Public Mes As Integer
    Public Ano As Integer


    Private Sub frptCierreMensualGanado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        showReport()
    End Sub

    Public Sub showReport()
        Dim paramReport(4) As ReportParameter

        Dim prmEmpCod As New ReportParameter("Empresa", Empresa)
        Dim prmCenCod As New ReportParameter("Centro", CentroCod)
        Dim prmMes As New ReportParameter("Mes", Mes)
        Dim prmAno As New ReportParameter("Anio", Ano)
        Dim prmUser As New ReportParameter("Usuario", LoginUsuario)

        paramReport(0) = prmEmpCod
        paramReport(1) = prmCenCod
        paramReport(2) = prmMes
        paramReport(3) = prmAno
        paramReport(4) = prmUser

        Me.rptCierreGanado.ServerReport.SetParameters(paramReport)
        'Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rptCierreGanado.ShowParameterPrompts() = False
        Me.rptCierreGanado.RefreshReport()
    End Sub


End Class