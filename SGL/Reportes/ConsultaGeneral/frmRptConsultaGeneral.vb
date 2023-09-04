

Public Class frmRptConsultaGeneral

    'Empresa        int = 0,
    'TipoReporte    int = 0,
    'OtrosCent      int = 0,
    'Centros        varchar(500) = '',
    'Estados        varchar(500) = '',
    'OtrosCat       int = 0,
    'Categorias     varchar(500) = '',
    'OtrosEProd     int = 0,
    'EstsProds      varchar(500) = '',
    'OtrosEReprod   int = 0,
    'EstsReprods    varchar(500) = '',
    'DIIO           varchar(20) = '',
    'Dias           int = 0,
    'FechaDesde     varchar(10) = '',
    'FechaHasta     varchar(10) = '',
    'PesoDesde      numeric(10, 2) = 0,
    'PesoHasta      numeric(10, 2) = 0,
    'OrdenarPor     int = 0,
    'Orden          varchar(200) = '',
    'Usuario        varchar(20) = '',
    'Equipo         varchar(100) = ''

    Public Empresa As Integer = 0
    Public TipoReporte As Integer = 0
    Public OtrosCent As Integer = 0
    Public Centros As String = ""
    Public Estados As String = ""
    Public OtrosCat As Integer = 0
    Public Categorias As String = ""
    Public OtrosEProd As Integer = 0
    Public EstsProds As String = ""
    Public OtrosEReprod As Integer = 0
    Public EstsReprods As String = ""
    Public DIIO As String = ""
    Public Dias As Integer = 0
    Public FechaDesde As String = ""
    Public FechaHasta As String = ""
    Public PesoDesde As Double = 0
    Public PesoHasta As Double = 0
    Public Origen As Integer = 0
    Public Orden As String = ""
    'Public Usuario As 



    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'MANUKA_PROD_DataSet.spGanado_ConsultaGeneral2' Puede moverla o quitarla según sea necesario.
        'Me.spGanado_ConsultaGeneral2TableAdapter.Fill(Me.MANUKA_PROD_DataSet.spGanado_ConsultaGeneral2, _
        '                                                Empresa, 0, 0, "", "", 0, "", 0, "", 0, "", "", 0, "", "", 0, 0, 0, 0, LoginUsuario, NombrePC)
        Me.Height = 660
        Me.Width = 1130
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 10) / 2)
        'Me.Top = 10
        'Me.Left = 50


        Me.spGanado_ConsultaGeneral2TableAdapter.Connection.ConnectionString = GetConnectionString()

        Me.spGanado_ConsultaGeneral2TableAdapter.Fill(Me.MANUKA_PROD_DataSet.spGanado_ConsultaGeneral2, _
                                                        Empresa, TipoReporte, OtrosCent, Centros, Estados, OtrosCat, Categorias, _
                                                        OtrosEProd, EstsProds, OtrosEReprod, EstsReprods, DIIO, Dias, FechaDesde, FechaHasta, _
                                                        PesoDesde, PesoHasta, Origen, Orden, LoginUsuario, NombrePC)

        Me.ReportViewer1.RefreshReport()






        'Dim myfec As Date

        'myfec = Now()

    End Sub
End Class
