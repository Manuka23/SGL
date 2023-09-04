

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient



Public Class frmPartos
    Private Total_General As Integer = 0
    Private Total_Repetidos As Integer = 0
    Private TotER_Preniada As Integer = 0
    Private TotER_SecaPrn As Integer = 0
    Private TotER_Dudosa As Integer = 0
    Private TotER_Anestro As Integer = 0
    Private TotER_Otros As Integer = 0

    Private Total_Partos As Integer = 0
    Private Total_Crias As Integer = 0
    Private Total_Hembras As Integer = 0
    Private Por_Hembras As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "", "CenDesCor", "", "SumaPartos", "SumaNacs", "SumaHembras", _
                                        "", "SumaInducs", ""}

    Private CadenaOrden As String = "CenDesCor"



    Private Sub InicializaTotales()
        Total_Partos = 0
        Total_Crias = 0
        Total_Hembras = 0
    End Sub


    Private Sub MuestraTotales()
        Label85.Text = Total_Partos.ToString.Trim
        Label6.Text = Total_Crias.ToString.Trim
        Label8.Text = Total_Hembras.ToString.Trim
        Label10.Text = Por_Hembras.ToString.Trim

        'pnlEstReprod.Refresh()
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub




    Public Sub ConsultaPartos(ByVal cent_ As String)

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPartos_ListadoPorCentros", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        InicializaTotales()
        MuestraTotales()

        lvPARTOS.BeginUpdate()
        lvPARTOS.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    pbProcesa.Maximum = vret + 1
                    'End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                    item.SubItems.Add(rdr("CenCod").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add("")                                'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("SumaPartos").ToString.Trim)
                    item.SubItems.Add(rdr("SumaNacs").ToString.Trim)
                    item.SubItems.Add(rdr("SumaHembras").ToString.Trim)
                    item.SubItems.Add(rdr("SumaMachos").ToString.Trim)
                    item.SubItems.Add(rdr("H_Sexado").ToString.Trim)
                    item.SubItems.Add(rdr("M_Sexado").ToString.Trim)
                    item.SubItems.Add(rdr("SumaInducs").ToString.Trim)
                    item.SubItems.Add("")

                    lvPARTOS.Items.Add(item)

                    Total_Partos = Total_Partos + Val(rdr("SumaPartos").ToString.Trim)
                    Total_Crias = Total_Crias + Val(rdr("SumaNacs").ToString.Trim)

                    Total_Hembras = Total_Hembras + Val(rdr("SumaHembras").ToString.Trim)


                    lvPARTOS.Items(lvPARTOS.Items.Count - 1).UseItemStyleForSubItems = False
                    lvPARTOS.Items(lvPARTOS.Items.Count - 1).SubItems(6).BackColor = Color.LightGray


                    i = i + 1
                    'pbProcesa.Value = i
                End While

                'pbProcesa.Value = pbProcesa.Maximum

                If Total_Crias > 0 Then
                    Por_Hembras = (Total_Hembras / Total_Crias) * 100
                Else
                    Por_Hembras = 0
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvPARTOS.EndUpdate()
        'Total_General = i
        MuestraTotales()
        'pnlProcesa.Visible = False

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub frmPartos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        General.EstProductivos.Cargar()
        General.Razas.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        ChartSexado.Titles("Title1").Text = "SEXADOS"
        ChartCrias.Titles("Title1").Text = "CRIAS"
        ChartTipoParto.Titles("Title1").Text = "TIPOS DE PARTOS"

        CboLLenaCentros()

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now


    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "CenDesCor"
            lblOrdena.Text = "Centro"
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor

        ConsultaPartos(cent_)

        'Para Graficos
        ConsultaPartosCrias(cent_, "POR CRIAS")
        ConsultaPartosTipo(cent_, "POR TIPO")
        '  ConsultaPartosSexado(cent_, "POR SEXADO")

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ConsultaPartosCrias(ByVal centro_ As String, ByVal TipoGrafico As String) 'Para Grafico
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPartos_ConsultaGeneral_Graphic", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()

            ChartCrias.Series("Series1").Points.DataBindXY(rdrGraphic, "SexoCria", rdrGraphic, "CantCrias")

            'ChartCrias.Series("Series1").LegendText = "HEMBRAS "
            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    'Private Sub ConsultaPartosSexado(ByVal centro_ As String, ByVal TipoGrafico As String) 'Para Grafico
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spPartos_ConsultaGeneral_Graphic", con)
    '    Dim rdrGraphic As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@Centro", centro_)
    '    cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
    '    cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
    '    cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    Try
    '        con.Open()
    '        rdrGraphic = cmd.ExecuteReader()

    '        ChartSexado.Series("Series1").Points.DataBindXY(rdrGraphic, "SexoCria", rdrGraphic, "CantCrias")
    '        rdrGraphic.Close()

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub


    Private Sub ConsultaPartosTipo(ByVal centro_ As String, ByVal TipoGrafico As String) 'Para Grafico
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPartos_ConsultaGeneral_Graphic", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()

            ChartTipoParto.Series("Series1").Points.DataBindXY(rdrGraphic, "PartoTipo", rdrGraphic, "CntTipoParto")

            ' ChartCrias.Series("Series1").LegendText = "HEMBRAS "
            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            frmPartosIngresoDiios.Param2_NombreCentro = cboCentros.Text
        End If

        frmPartosIngresoDiios.Param0_ModoIngreso = 1

        frmPartosIngresoDiios.MdiParent = frmMAIN
        frmPartosIngresoDiios.Show()
    End Sub


    Private Sub lvPARTOS_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvPARTOS.MouseDoubleClick
        If lvPARTOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetallePartos()
        End If
    End Sub


    Private Sub DetallePartos()
        Dim cent_ As String = lvPARTOS.SelectedItems(0).SubItems(2).Text            'codigo centro
        Dim nomcent_ As String = lvPARTOS.SelectedItems(0).SubItems(3).Text         'nombre centro

        frmPartosIngreso.Param0_ModoIngreso = 2     'consulta de partos
        frmPartosIngreso.Param1_CodigoCentro = cent_
        frmPartosIngreso.Param2_NombreCentro = nomcent_
        frmPartosIngreso.Param3_FechaDesde = dtpFechaDesde.Value
        frmPartosIngreso.Param4_FechaHasta = dtpFechaHasta.Value

        frmPartosIngreso.MdiParent = frmMAIN
        frmPartosIngreso.Show()
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvPARTOS.Items.Count = 0 Then Exit Sub

        Dim tot(4, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL PARTOS " : tot(0, 1) = Label85.Text.Trim
        tot(1, 0) = "TOTAL CRIAS " : tot(1, 1) = Total_Crias.ToString.Trim
        tot(2, 0) = "TOTAL HEMBRAS " : tot(2, 1) = Total_Hembras.ToString.Trim
        tot(3, 0) = "PORC. HEMBRAS " : tot(3, 1) = Por_Hembras.ToString.Trim + "  %"
        ExportToExcelGrilla(lvPARTOS, tot)
    End Sub


    Private Sub lvPARTOS_ColumnClick(sender As System.Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPARTOS.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub
        If CamposOrden(e.Column).Trim = "" Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvPARTOS.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvPARTOS.Columns(e.Column).Text
        End If
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub



End Class