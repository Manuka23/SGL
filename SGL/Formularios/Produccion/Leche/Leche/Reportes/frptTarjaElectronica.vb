Imports Microsoft.Reporting.WinForms

Public Class frptTarjaElectronica

    Public CentroCod As String
    Public FecHasta As String

    Private Sub frptTarjaElectronica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showReport()
    End Sub

    Public Sub showReport()
        Dim paramReport(2) As ReportParameter
        Dim FecDesde As String
        Dim Mes As Integer
        Dim Ano As Integer
        Mes = Month(FecHasta) - 1
        Ano = Year(FecHasta)
        If Mes = 0 Then
            Mes = 12
            If Mes = 12 Then
                Ano = Ano - 1
            End If
        End If
        FecDesde = "16-" + Mes.ToString.PadLeft(2, "0") + "-" + Ano.ToString
        'Dim prmEmpCod As New ReportParameter("Empresa", Empresa)

        Dim prmCenCodIVS As New ReportParameter("CodigoCen", CentroCod)
        Dim prmFecIni As New ReportParameter("Fecha_Desde", FecDesde)
        Dim prmFecFin As New ReportParameter("Fecha_Hasta", FecHasta)
        'Dim prmCenCod As New ReportParameter("CenCod", CentroCod)
        'Dim prmMes As New ReportParameter("Mes", Mes)
        'Dim prmAno As New ReportParameter("Anio", Ano)
        'Dim prmUser As New ReportParameter("Usuario", LoginUsuario)

        paramReport(0) = prmCenCodIVS
        paramReport(1) = prmFecIni
        paramReport(2) = prmFecFin
        'paramReport(3) = prmCenCod

        'paramReport(3) = prmAno
        'paramReport(4) = prmUser

        Me.rptTarja.ServerReport.SetParameters(paramReport)
        'Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        'Me.rptTarja.ShowParameterPrompts() = False
        Me.rptTarja.RefreshReport()
    End Sub

    Private Sub rptTarja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rptTarja.Load

    End Sub
End Class