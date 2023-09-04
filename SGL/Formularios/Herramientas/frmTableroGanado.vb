
Imports System.Data.SqlClient



Public Class frmTableroGanado

    Private centroCod As String = ""
    Private MesNom As String = MonthName(Now.Month, True)
    Private PrimerInicio As Boolean = False


    Private Sub frmTableroGanado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        PrimerInicio = True

        CboLLenaCentros()

        mostrarTiempo()
        Consultas()
        PrimerInicio = False

    End Sub

    Private Sub Consultas()
        Cursor.Current = Cursors.WaitCursor

        pnlProcesaGeneral.Visible = True
        pnlProcesaGeneral.Refresh()


        CentroCodigo() : lblCentroLeche.Text = cboCentros.Text.Trim

        pbProcesaGeneral.Value = 5

        'TAB GENERAL
        lblProcesa.Text = "Consultando categorias, espere un momento por favor..." : lblProcesa.Refresh()
        ConsultaCategorias(centroCod, "POR CATEGORIA")
        pbProcesaGeneral.Value = 10

        lblProcesa.Text = "Consultando estados productivos, espere un momento por favor..." : lblProcesa.Refresh()
        ConsultaEstProdVC(centroCod, "POR EST.PROD")
        pbProcesaGeneral.Value = 20

        lblProcesa.Text = "Consultando preñadas, espere un momento por favor..." : lblProcesa.Refresh()
        ConsultaPreñadas(centroCod, "PREÑADAS")
        pbProcesaGeneral.Value = 30

        lblProcesa.Text = "Consultando partos, espere un momento por favor..." : lblProcesa.Refresh()
        ConsultaPartos(centroCod, "PARTOS", "Series1")
        pbProcesaGeneral.Value = 40

        ConsultaPartos(centroCod, "PARTOS", "Series2")
        pbProcesaGeneral.Value = 50

        'TAB PARTOS
        lblProcesa.Text = "Consultando partos mensuales, espere un momento por favor..." : lblProcesa.Refresh()
        ConsultaPartos_Mes(centroCod, "PARTOS_MENSUAL", "Series1")
        ConsultaPartos_Mes(centroCod, "PARTOS_MENSUAL", "Series2")


        'TAB PLANTEL
        lblProcesa.Text = "Consultando crianza, espere un momento por favor..." : lblProcesa.Refresh()
        ConsultaGruposPlantel(centroCod, "CRIANZA")
        pbProcesaGeneral.Value = 60 ': pbProcesaPlantel.Value = 60 : pbProcesaPartos.Value = 60 : pbProcesaLeche.Value = 60 : pbProcesaMovimientos.Value = 60

        lblProcesa.Text = "Consultando lactancia, espere un momento por favor..." : lblProcesa.Refresh()
        ConsultaGruposPlantel(centroCod, "LACTANCIA")
        pbProcesaGeneral.Value = 70 ': pbProcesaPlantel.Value = 70 : pbProcesaPartos.Value = 70 : pbProcesaLeche.Value = 70 : pbProcesaMovimientos.Value = 70


        'TAB LECHE
        lblProcesa.Text = "Consultando datos productivos, espere un momento por favor..." : lblProcesa.Refresh()
        ConsultaLecheMeta(centroCod, "VTA_PPTO_MES")
        pbProcesaGeneral.Value = 80 ': pbProcesaPlantel.Value = 80 : pbProcesaPartos.Value = 80 : pbProcesaLeche.Value = 80 : pbProcesaMovimientos.Value = 80

        'lblProcesa.Text = "Consultando datos productivos, espere un momento por favor..."
        ConsultaLecheVtaPpto_Diaria(centroCod, "VTA_PPTO_DIARIO", "VTA")
        pbProcesaGeneral.Value = 90 ': pbProcesaPlantel.Value = 90 : pbProcesaPartos.Value = 90 : pbProcesaLeche.Value = 90 : pbProcesaMovimientos.Value = 90

        'lblProcesa.Text = "Consultando datos productivos diario, espere un momento por favor..."
        ConsultaLecheVtaPpto_Diaria(centroCod, "VTA_PPTO_DIARIO", "PPTO")
        pbProcesaGeneral.Value = 92 ': pbProcesaPlantel.Value = 92 : pbProcesaPartos.Value = 92 : pbProcesaLeche.Value = 92 : pbProcesaMovimientos.Value = 92

        'lblProcesa.Text = "Consultando datos productivos mes, espere un momento por favor..."
        ConsultaLecheTotal(centroCod, "LECHE_TOTAL")
        pbProcesaGeneral.Value = 94 ': pbProcesaPlantel.Value = 94 : pbProcesaPartos.Value = 94 : pbProcesaLeche.Value = 94 : pbProcesaMovimientos.Value = 94

        'TAB MOVIMIENTOS
        lblProcesa.Text = "Consultando movimientos de ganado, espere un momento por favor..." : lblProcesa.Refresh()
        ConsultaVtasMuertes(centroCod, "VTAS_MRTS_ANUAL", "VTAS", "")
        ConsultaVtasMuertes(centroCod, "VTAS_MRTS_ANUAL", "MUERTES", "")
        pbProcesaGeneral.Value = 96 ': pbProcesaPlantel.Value = 96 : pbProcesaPartos.Value = 96 : pbProcesaLeche.Value = 96 : pbProcesaMovimientos.Value = 96

        ConsultaVtasMuertes(centroCod, "VTAS_MRTS_PREÑADAS", "VTAS", "PREÑADAS")
        ConsultaVtasMuertes(centroCod, "VTAS_MRTS_PREÑADAS", "MUERTES", "PREÑADAS")
        pbProcesaGeneral.Value = 98 '
        ConsultaPreMating()


        pbProcesaGeneral.Value = 100 ': pbProcesaPlantel.Value = 100 : pbProcesaPartos.Value = 100 : pbProcesaLeche.Value = 100 : pbProcesaMovimientos.Value = 100

        pnlProcesaGeneral.Visible = False
        Cursor.Current = Cursors.Default

        centroCod = ""
    End Sub


    Public Sub ConsultaPreMating()
        lblProcesa.Text = "Consultando Pre-Mating, espere un momento por favor..."

        Dim cent_ As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_PreMating", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvPreMATING.BeginUpdate()
        lvPreMATING.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Dim totvacas As Integer = 0
        Dim totdlac As Integer = 0
        Dim totings As Integer = 0
        Dim totcelos As Integer = 0


        Dim pje_vacas1parto As Double = 0
        Dim pje_inducs As Double = 0
        Dim pje_celantcub As Double = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()

                    If rdr("ContVacas") <> 0 Then
                        pje_vacas1parto = ((rdr("ContVacasUnParto") * 100) / rdr("ContVacas"))
                        pje_inducs = ((rdr("ContPartosInducidos") * 100) / rdr("ContVacas"))
                        pje_celantcub = ((rdr("ContCelosAntesCub") * 100) / rdr("ContVacas"))
                    End If


                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)

                    item.SubItems.Add(rdr("ContVacas").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    ''
                    item.SubItems.Add(rdr("ContCelosAntesCub").ToString.Trim)
                    item.SubItems.Add(Format(pje_celantcub, "#,##0.00"))
                    ''
                    item.SubItems.Add(rdr("ContPartosInducidos").ToString.Trim)
                    item.SubItems.Add(Format(pje_inducs, "#,##0.00"))
                    ''
                    item.SubItems.Add(rdr("ContVacasUnParto").ToString.Trim)
                    item.SubItems.Add(Format(pje_vacas1parto, "#,##0.00"))


                    lvPreMATING.Items.Add(item)

                    i = i + 1

                End While


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvPreMATING.EndUpdate()

    End Sub


    Public Sub ConsultaCategorias(ByVal centro_ As String, ByVal TipoGrafico As String) 'Para Grafico
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            'ChartPartos.Titles("Title1").Text = "PLANTEL - CATEGORIAS"
            ChartCategorias.Series("Series1").Points.DataBindXY(rdrGraphic, "Categoria", rdrGraphic, "Cant")
            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaEstProdVC(ByVal centro_ As String, ByVal TipoGrafico As String) 'Para Grafico
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            ChartEstProd.Series("Series1").Points.DataBindXY(rdrGraphic, "EstProd", rdrGraphic, "Cant")
            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaPreñadas(ByVal centro_ As String, ByVal TipoGrafico As String) 'Para Grafico
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            ChartPreñados.Series("Series1").Points.DataBindXY(rdrGraphic, "Categoria", rdrGraphic, "Cant")
            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaPartos(ByVal centro_ As String, ByVal TipoGrafico As String, ByVal Serie As String) 'Para Grafico
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrGraphic As SqlDataReader = Nothing
        Dim CntTexto = ""

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            If Serie = "Series1" Then
                ChartPartos.Series(Serie).Points.DataBindXY(rdrGraphic, "Dia", rdrGraphic, "CantFUP")
                ChartPartos.Series("Series1").LegendText = "REAL"
            Else
                ChartPartos.Series(Serie).Points.DataBindXY(rdrGraphic, "Dia", rdrGraphic, "CantFPP")
                ChartPartos.Series("Series2").LegendText = "PROYECTADOS"
            End If
            ChartPartos.Titles("Title1").Text = "COMPARACIÓN DE PARTOS '" + MesNom.Trim.ToUpper + "' (REAL VS PROYECTADOS)"

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaPartos_Mes(ByVal centro_ As String, ByVal TipoGrafico As String, ByVal Serie As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrGraphic As SqlDataReader = Nothing
        Dim CntTexto = ""

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            If Serie = "Series1" Then
                ChartPartoReal_Proy.Series(Serie).Points.DataBindXY(rdrGraphic, "AñoMes", rdrGraphic, "CantFUP")
                ChartPartoReal_Proy.Series("Series1").LegendText = "REAL"
            Else
                ChartPartoReal_Proy.Series(Serie).Points.DataBindXY(rdrGraphic, "AñoMes", rdrGraphic, "CantFPP")
                ChartPartoReal_Proy.Series("Series2").LegendText = "PROYECTADOS"
            End If
            'ChartPartos.Titles("Title1").Text = "COMPARACIÓN DE PARTOS " + MesNom.Trim.ToUpper + " (REAL VS PROYECTADOS)"

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaGruposPlantel(ByVal centro_ As String, ByVal TipoGrafico As String) 'Para Grafico
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            If TipoGrafico = "CRIANZA" Then
                ChartGrupoCrianza.Series("Series1").Points.DataBindXY(rdrGraphic, "GrupoCrianza", rdrGraphic, "Cant")
            End If
            If TipoGrafico = "LACTANCIA" Then
                ChartGrupoLactancia.Series("Series1").Points.DataBindXY(rdrGraphic, "GrupoProd", rdrGraphic, "Cant")
            End If

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaLecheVtaPpto_Diaria(ByVal centro_ As String, ByVal TipoGrafico As String, ByVal Serie As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            'ChartPartos.Titles("Title1").Text = "PLANTEL - CATEGORIAS"
            If Serie = "VTA" Then
                ChartLecheVtaPpto.Series("Series1").Points.DataBindXY(rdrGraphic, "dia", rdrGraphic, "Venta")
                ChartLecheVtaPpto.Series("Series1").LegendText = "PLANTA"
            End If
            If Serie = "PPTO" Then
                ChartLecheVtaPpto.Series("Series2").Points.DataBindXY(rdrGraphic, "dia", rdrGraphic, "Ppto")
                ChartLecheVtaPpto.Series("Series2").LegendText = "PROYECTADO"
            End If
            ChartLecheVtaPpto.Titles("Title1").Text = "COMPARACIÓN LECHE ACUMULADA " + MesNom.Trim.ToUpper + " - PLANTA VS PROYECTADO"
            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaLecheMeta(ByVal centro_ As String, ByVal TipoGrafico As String) 'VTA_PPTO_MES
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrConsulta As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrConsulta = cmd.ExecuteReader()
            Try
                While rdrConsulta.Read()
                    lblMeta.Text = rdrConsulta("PPTO").ToString.Trim
                    lblCumplimientoLts.Text = rdrConsulta("VTA_PLANTA").ToString.Trim
                    lblCumplimientoPercent.Text = rdrConsulta("CUMPLIMIENTO").ToString.Trim
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            rdrConsulta.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaLecheTotal(ByVal centro_ As String, ByVal TipoGrafico As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            'ChartPartos.Titles("Title1").Text = "PLANTEL - CATEGORIAS"

            ChartLecheTotal.Series("Series1").Points.DataBindXY(rdrGraphic, "TipoLeche", rdrGraphic, "Cantidad")

            For Each point In ChartLecheTotal.Series("Series1").Points
                point("Exploded") = "false"
                If point.AxisLabel = "PLANTA" Then
                    point("Exploded") = "true"
                End If
            Next
            ChartLecheTotal.Titles("Title1").Text = "LECHE TOTAL ACUMULADA '" + MesNom.Trim.ToUpper + "'"

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ConsultaVtasMuertes(ByVal centro_ As String, ByVal TipoGrafico As String, ByVal Serie As String, ByVal TipoDato As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGraficos_Ganado", con)
        Dim rdrGraphic As SqlDataReader = Nothing
        Dim CntTexto = ""

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", Now())
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()

            If Serie = "VTAS" Then
                If TipoDato = "PREÑADAS" Then
                    ChartVtasMuertes_Preñadas.Series("Series1").Points.DataBindXY(rdrGraphic, "MES", rdrGraphic, "CantVTAS")
                    ChartVtasMuertes_Preñadas.Series("Series1").LegendText = "VENTAS PREÑADAS"
                Else
                    ChartVta_Muertes.Series("Series1").Points.DataBindXY(rdrGraphic, "MES", rdrGraphic, "CantVTAS")
                    ChartVta_Muertes.Series("Series1").LegendText = "VENTAS"
                End If

            Else
                If TipoDato = "PREÑADAS" Then
                    ChartVtasMuertes_Preñadas.Series("Series2").Points.DataBindXY(rdrGraphic, "MES", rdrGraphic, "CantMUERTES")
                    ChartVtasMuertes_Preñadas.Series("Series2").LegendText = "MUERTES PREÑADAS"
                Else
                    ChartVta_Muertes.Series("Series2").Points.DataBindXY(rdrGraphic, "MES", rdrGraphic, "CantMUERTES")
                    ChartVta_Muertes.Series("Series2").LegendText = "MUERTES"
                End If

            End If
            'ChartPartos.Titles("Title1").Text = "COMPARACIÓN DE PARTOS " + MesNom.Trim.ToUpper + " (REAL VS PROYECTADOS)"

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub



    Private Sub CentroCodigo()
        Dim pos_ As Integer = 0
        'Obtener el Codigo del Centro
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            For i = 0 To General.CentrosUsuario.NroRegistros - 1
                If General.CentrosUsuario.Nombre(i) = cboCentros.Text Then
                    pos_ = i
                End If
            Next
            centroCod = General.CentrosUsuario.Codigo(pos_)
            'ChartCategorias.Series("Series1")("PieLabelStyle") = "Inside"
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        If General.CentrosUsuario.NroRegistros > 0 Then
            cboCentros.Items.Add("(TODOS)")
        End If
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
        cboCentros.SelectedIndex = -1
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        milisegundo += 1
        If milisegundo = 9 Then
            milisegundo = 0
            segundo += 1
            If segundo = 59 Then
                segundo = 0
                minuto += 1
                If minuto = 59 Then
                    minuto = 0
                    hora += 1
                End If
            End If
        End If
        mostrarTiempo()
    End Sub

    Sub mostrarTiempo()
        lblCronometro.Text = hora.ToString.PadLeft(2, "0") & ":"
        lblCronometro.Text &= minuto.ToString.PadLeft(2, "0") & ":"
        lblCronometro.Text &= segundo.ToString.PadLeft(2, "0") & ":"
        lblCronometro.Text &= milisegundo.ToString.PadLeft(1, "0")

        lblCronometro.Refresh()
    End Sub

    Private Sub Finalizar_Timer()
        Timer1.Enabled = False
        hora = 0
        minuto = 0
        segundo = 0
        milisegundo = 0

        mostrarTiempo()
    End Sub

    Private hora As Integer = 0
    Private minuto As Integer = 0
    Private segundo As Integer = 0
    Private milisegundo As Integer = 0


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged

        If PrimerInicio Then Exit Sub
        Consultas()

    End Sub

    Private Sub TabGraficos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabGraficos.SelectedIndexChanged
        If TabGraficos.SelectedIndex = 5 Then
            btnExcel.Visible = True
        Else
            btnExcel.Visible = False
        End If
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvPreMATING.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL REGISTROS " : tot(0, 1) = lvPreMATING.Items.Count.ToString.Trim

        ExportToExcelGrilla(lvPreMATING, tot)
    End Sub

    Private Sub ChartLecheTotal_Click(sender As Object, e As EventArgs)

    End Sub
End Class