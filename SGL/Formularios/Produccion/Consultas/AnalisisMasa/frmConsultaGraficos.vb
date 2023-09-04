

Imports System.Windows.Forms.DataVisualization.Charting



Public Class frmConsultaGraficos

    Public Cat_Terneras As Integer
    Public Cat_Terneros As Integer
    Public Cat_Toretes As Integer
    Public Cat_Toros As Integer
    Public Cat_Vacas As Integer
    Public Cat_Vaquillas As Integer
    Public Cat_Otros As Integer


    'Public Sub New(ByVal tot As Integer, ByVal cp1 As Integer, ByVal cp2 As Integer, ByVal cp3 As Integer, ByVal cp4 As Integer, ByVal cp5 As Integer, ByVal cp6 As Integer)


    '    var_ = var_ + 1

    '    'Label1.Text = var_.ToString.Trim

    '    Cat_Terneras = cp1
    '    Cat_Terneros = cp2
    '    Cat_Toretes = cp3
    '    Cat_Toros = cp4
    '    Cat_Vacas = cp5
    '    Cat_Vaquillas = cp6
    '    Cat_Otros = tot - cp1 - cp2 - cp3 - cp4 - cp5 - cp6


    '    ' Llamada necesaria para el diseñador.
    '    InitializeComponent()

    '    ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    'End Sub

    Private Function ConsigueMayorValorCategoria() As Integer
        Dim valor_ As Integer

        If Cat_Terneras > Cat_Terneros Then : valor_ = Cat_Terneras : Else : valor_ = Cat_Terneros : End If
        If Cat_Toretes > valor_ Then valor_ = Cat_Toretes
        If Cat_Toros > valor_ Then valor_ = Cat_Toros
        If Cat_Vacas > valor_ Then valor_ = Cat_Vacas
        If Cat_Vaquillas > valor_ Then valor_ = Cat_Vaquillas

        ConsigueMayorValorCategoria = valor_
    End Function


    Private Sub frmConsultaGraficos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim VMayorCat As Integer = ConsigueMayorValorCategoria()

        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        ' Populate series data
        Dim yValues As Double() = {(Cat_Terneras * 100) / VMayorCat, _
                                   (Cat_Terneros * 100) / VMayorCat, _
                                   (Cat_Toretes * 100) / VMayorCat, _
                                   (Cat_Toros * 100) / VMayorCat, _
                                   (Cat_Vacas * 100) / VMayorCat, _
                                   (Cat_Vaquillas * 100) / VMayorCat, _
                                   (Cat_Otros * 100) / VMayorCat}

        'Dim yValues As Double() = {65.62, 75.54, 60.45, 34.73, 85.42, 30.5, 15}
        Dim xValues As String() = {Cat_Terneras.ToString.Trim, _
                                   Cat_Terneros.ToString.Trim, _
                                   Cat_Toretes.ToString.Trim, _
                                   Cat_Toros.ToString.Trim, _
                                   Cat_Vacas.ToString.Trim, _
                                   Cat_Vaquillas.ToString.Trim, _
                                   Cat_Otros.ToString.Trim}

        Chart5.Series("Series1").Points.DataBindXY(xValues, yValues)
        Chart5.Series("Series1").ChartType = SeriesChartType.Pie     ' Set Doughnut chart type
        Chart5.Series("Series1")("PieLabelStyle") = "Inside"   ' Set labels style
        Chart5.Series("Series1")("DoughnutRadius") = "60"     ' Set Doughnut radius percentage
        Chart5.Series("Series1").Points(4)("Exploded") = "false"   ' Explode data point with label "Italy"
        Chart5.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True     ' Enable 3D
        Chart5.Series("Series1")("PieDrawingStyle") = "SoftEdge"    ' Set drawing style



        ' Populate series data
        'Dim yValues2 As Double() = {65.62, 75.54, 60.45, 34.73, 85.42, 30.5}
        'Dim xValues2 As String() = {"DESCARTE", "DESECHO", "ELIM. LECHE", "EN PRODUCCION", "NO APLICA", "ECA DE LECHE"}
        'Chart3.Series("Series1").Points.DataBindXY(xValues2, yValues2)

        'Chart3.Series("Series1").ChartType = SeriesChartType.Pie     ' Set Doughnut chart type
        'Chart3.Series("Series1")("PieLabelStyle") = "Inside"   ' Set labels style
        'Chart3.Series("Series1")("DoughnutRadius") = "60"     ' Set Doughnut radius percentage
        'Chart3.Series("Series1").Points(4)("Exploded") = "false"   ' Explode data point with label "Italy"
        'Chart3.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True     ' Enable 3D
        'Chart3.Series("Series1")("PieDrawingStyle") = "SoftEdge"    ' Set drawing style


        '' Populate series data
        'Dim yValues3 As Double() = {65.62, 75.54, 60.45, 34.73, 85.42, 30.5, 25.55}
        'Dim xValues3 As String() = {"ANESTRO", "CUBIERTA", "DES. REP.", "DUDOSA", "NO APLICA", "PREÑADA", "SECA PRN"}
        'Chart4.Series("Series1").Points.DataBindXY(xValues3, yValues3)

        'Chart4.Series("Series1").ChartType = SeriesChartType.Pie     ' Set Doughnut chart type
        'Chart4.Series("Series1")("PieLabelStyle") = "Inside"   ' Set labels style
        'Chart4.Series("Series1")("DoughnutRadius") = "60"     ' Set Doughnut radius percentage
        'Chart4.Series("Series1").Points(4)("Exploded") = "false"   ' Explode data point with label "Italy"
        'Chart4.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True     ' Enable 3D
        'Chart4.Series("Series1")("PieDrawingStyle") = "SoftEdge"    ' Set drawing style


        'Dim random As New Random()
        'Dim pointIndex As Integer

        'For pointIndex = 0 To 20
        '    Chart1.Series("Series1").Points.AddY(random.Next(45, 95))
        'Next pointIndex


        'Chart1.Series("Series1").ChartType = SeriesChartType.StackedArea100       ' Set chart type
        'Chart1.Series("Series1").IsValueShownAsLabel = True           ' Show point labels
        'Chart1.ChartAreas("ChartArea1").AxisX.IsMarginVisible = False          ' Disable X axis margin
        'Chart1.Series("Series1")("StackedGroupName") = "Group1"       ' Set the first two series to be grouped into Group1
        ''Chart1.Series("Gold")("StackedGroupName") = "Group1"


        ''Chart1.Series("Red")("StackedGroupName") = "Group2"         ' Set the last two series to be grouped into Group2
        ''Chart1.Series("DarkBlue")("StackedGroupName") = "Group2"


        'Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True            ' Show the chart in 3D







        ' Populate series data
        Dim random As New Random()
        Dim pointIndex As Integer

        For pointIndex = 0 To 9
            Chart3.Series("Series1").Points.AddY(random.Next(45, 95))
        Next pointIndex

        ' Set chart type
        Chart3.Series("Series1").ChartType = SeriesChartType.StackedArea100

        ' Show point labels
        Chart3.Series("Series1").IsValueShownAsLabel = True

        ' Disable X axis margin
        Chart3.ChartAreas("Default").AxisX.IsMarginVisible = False

        ' Set the first two series to be grouped into Group1
        Chart3.Series("Series1")("StackedGroupName") = "Group1"
        'Chart3.Series("Gold")("StackedGroupName") = "Group1"

        ' Set the last two series to be grouped into Group2
        'Chart3.Series("Red")("StackedGroupName") = "Group2"
        ' Chart3.Series("DarkBlue")("StackedGroupName") = "Group2"

        ' Show the chart in 3D
        'Chart3.ChartAreas("Default").Area3DStyle.Enable3D = True

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


End Class