Imports Microsoft.Reporting.WinForms

Public Class frptCierredBodega

    Public bodega As String
    Public anio As Integer
    Public mes As Integer

    Private Sub frptTarjaElectronica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showReport()
    End Sub

    Public Sub showReport()
        Dim paramReport(2) As ReportParameter


        Dim prmCenCodIVS As New ReportParameter("bodega", bodega)
        Dim prmanio As New ReportParameter("Anio", anio)
        Dim prmmes As New ReportParameter("Mes", mes)

        paramReport(0) = prmCenCodIVS
        paramReport(1) = prmanio
        paramReport(2) = prmmes

        Me.rptTarja.ServerReport.SetParameters(paramReport)

        Me.rptTarja.RefreshReport()
    End Sub

    Private Sub rptTarja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rptTarja.Load

    End Sub
End Class