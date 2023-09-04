Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FrmRecuentoCSDetalle


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRecuentoCSDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmRecuentoCSDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

    End Sub
    Public Sub ConsultaEstanque(ByVal estanqueCod_ As String, ByVal mesRCS_ As String, ByVal añoRCS_ As String)
        ConsultaEstanqueListViewDiario(estanqueCod_, mesRCS_, añoRCS_)
        ConsultaEstanqueGraficoDiario(estanqueCod_, mesRCS_, añoRCS_)
        Dim S1 As String = "Series1"
        Dim S2 As String = "Series2"
        ConsultaEstanqueGraficoAnual(estanqueCod_, añoRCS_, S1)
        Dim AñoAnt As Integer = CInt(añoRCS_) - 1
        ConsultaEstanqueGraficoAnual(estanqueCod_, CStr(AñoAnt), S2)
    End Sub

    Private Sub ConsultaEstanqueListViewDiario(ByVal estanqueCod_ As String, ByVal mesRCS_ As String, ByVal añoRCS_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_ConsultaPorEstanque", con)
        Dim rdr As SqlDataReader = Nothing
        Dim rdr2 As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)

        cmd.Parameters.AddWithValue("@CentroRSC", estanqueCod_)
        cmd.Parameters.AddWithValue("@Mes", mesRCS_)
        cmd.Parameters.AddWithValue("@Año", añoRCS_)

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvRCS.BeginUpdate()
        lvRCS.Items.Clear()
        Dim fila_ As Integer = 0
        Dim columna_ As Integer = 0
        Dim i As Integer = 0
        Dim TotRegs As Integer = 0
        Dim CountRegListView As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos
                    item.SubItems.Add(("").ToString.Trim) 'empres
                    item.SubItems.Add(rdr("DiaRCS").ToString.Trim) 'dia
                    item.SubItems.Add(rdr("CantRCS").ToString.Trim) 'dia
                    lvRCS.Items.Add(item)
                    i = i + 1
                End While
                colorearListView()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvRCS.EndUpdate()
    End Sub

    Private Sub ConsultaEstanqueGraficoDiario(ByVal estanqueCod_ As String, ByVal mesRCS_ As String, ByVal añoRCS_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_ConsultaPorEstanque", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CentroRSC", estanqueCod_)
        cmd.Parameters.AddWithValue("@Mes", mesRCS_)
        cmd.Parameters.AddWithValue("@Año", añoRCS_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            'CONSULTA PARA GRAFICO DIARIO
            rdrGraphic = cmd.ExecuteReader()
            Chart1.Series("Series1").Points.DataBindXY(rdrGraphic, "DiaRCS", rdrGraphic, "CantRCS")
            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaEstanqueGraficoAnual(ByVal estanqueCod_ As String, ByVal añoRCS_ As String, ByVal NomSerieGraphic As String)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_ConsultaPorEstanqueAnual", con)
        Dim rdrGraphicAnual As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CentroRSC", estanqueCod_)
        cmd.Parameters.AddWithValue("@Centro", "")
        cmd.Parameters.AddWithValue("@Año", añoRCS_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            'CONSULTA PARA GRAFICO ANUAL
            rdrGraphicAnual = cmd.ExecuteReader()
            Chart2.Series(NomSerieGraphic).Points.DataBindXY(rdrGraphicAnual, "MesRCS", rdrGraphicAnual, "CantRCSProm")
            Chart2.Series(NomSerieGraphic).LegendText = "AÑO " + añoRCS_
            rdrGraphicAnual.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub colorearListView()
        'SOLO HAY 1 SOLA COLUMNA QUE RECORRER, POR LO QUE SE ELIMINA EL FOR PARA RECORRER COLUMNAS
        Dim ValorCelda As String = ""
        Dim col As Integer = 3
        For lin = 0 To lvRCS.Items.Count - 1

            lvRCS.Items(lin).UseItemStyleForSubItems = False
            ValorCelda = lvRCS.Items(lin).SubItems(3).Text.ToString.Trim
            If ValorCelda <> "" And ValorCelda <> "-" Then
                If CInt(ValorCelda) >= 250 And CInt(ValorCelda) < 299 Then
                    '_lvRCS.Items(i).BackColor = Color.Yellow
                    lvRCS.Items(lin).SubItems(3).BackColor = System.Drawing.Color.Yellow 'Color.Yellow
                End If
                If CInt(ValorCelda) >= 300 Then
                    '_lvRCS.Items(i).BackColor = Color.Yellow
                    lvRCS.Items(lin).SubItems(3).BackColor = System.Drawing.Color.Tomato 'Color.Yellow
                End If
            End If

        Next
       
    End Sub

    'EJEMPLO
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

        Dim random As New Random()
        Dim pointIndex As Integer
        For pointIndex = 0 To 9
            Chart1.Series("Series1").Points.AddY(random.Next(45, 95))
            Chart1.Series("Series2").Points.AddY(random.Next(5, 75))
        Next pointIndex

        ' Set series chart type
        Chart1.Series("Series1").ChartType = SeriesChartType.Line
        Chart1.Series("Series2").ChartType = SeriesChartType.Spline

        ' Set point labels
        Chart1.Series("Series1").IsValueShownAsLabel = True
        Chart1.Series("Series2").IsValueShownAsLabel = True

        ' Enable X axis margin
        Chart1.ChartAreas("Default").AxisX.IsMarginVisible = True

        ' Show as 3D
        'Chart1.ChartAreas("Default").Area3DStyle.Enable3D = True


        ConsultaEstanque(lblCodEstanque.Text.Trim, lblMesNom.Text.Trim, lblAño.Text.Trim)
    End Sub
End Class