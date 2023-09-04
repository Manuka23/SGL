


Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient



Public Class FrmCojeras

    Private NroRegistros As Integer = 0
    Private Total_Casos As Integer = 0
    Private Total_Tratamientos As Integer = 0
    Private Total_Resguardos As Integer = 0
    Private Total_Preventivos As Integer = 0


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


    Private Sub InicializaTotales()
        NroRegistros = 0
        Total_Casos = 0
        Total_Tratamientos = 0
        Total_Resguardos = 0
        Total_Preventivos = 0
    End Sub


    Private Sub MuestraTotales()
        lblTotalCasos.Text = Total_Casos.ToString.Trim
        lblEnTratamiento.Text = Total_Tratamientos.ToString.Trim
        lblResguardo.Text = Total_Resguardos.ToString.Trim
        lblPreventivos.Text = Total_Preventivos.ToString.Trim
    End Sub


    Public Sub ConsultaCojeras(ByVal cent_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCojeras_ListadoPorCentros", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        InicializaTotales()
        MuestraTotales()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(rdr("SumaCojas").ToString.Trim)                                'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("SumaTratamiento").ToString.Trim)                                'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("SumaResguardo").ToString.Trim)
                    item.SubItems.Add(rdr("SumaTratPreventivos").ToString.Trim)
                    item.SubItems.Add("")
                    lvGanado.Items.Add(item)

                    NroRegistros = NroRegistros + 1
                    Total_Casos = Total_Casos + rdr("SumaCojas")
                    Total_Tratamientos = Total_Tratamientos + rdr("SumaTratamiento")
                    Total_Resguardos = Total_Resguardos + rdr("SumaResguardo")
                    Total_Preventivos = Total_Preventivos + rdr("SumaTratPreventivos")

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
        lvGanado.EndUpdate()
        MuestraTotales()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub DetalleCojeras()
        Dim cent_ As String = lvGanado.SelectedItems(0).SubItems(2).Text            'codigo centro
        Dim nomcent_ As String = lvGanado.SelectedItems(0).SubItems(3).Text         'nombre centro
        Dim casos_ As String = lvGanado.SelectedItems(0).SubItems(4).Text           '
        Dim tratamientos_ As String = lvGanado.SelectedItems(0).SubItems(5).Text    '
        Dim resguardos_ As String = lvGanado.SelectedItems(0).SubItems(6).Text      '

        FrmCojerasDetalle.P1_CodigoCentro = cent_
        FrmCojerasDetalle.P2_NombreCentro = nomcent_
        FrmCojerasDetalle.P3_FechaDesde = dtpFechaDesde.Value
        FrmCojerasDetalle.P4_FechaHasta = dtpFechaHasta.Value
        FrmCojerasDetalle.P5_NroCasos = Int32.Parse(casos_)
        FrmCojerasDetalle.P6_NroTratamientos = Int32.Parse(tratamientos_)
        FrmCojerasDetalle.P7_NroResguardos = Int32.Parse(resguardos_)

        FrmCojerasDetalle.MdiParent = frmMAIN
        FrmCojerasDetalle.Show()
    End Sub


    Private Sub Exportar_A_Excel()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        lblProcesa.Text = "Exportando a excel, espere un momento por favor ..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = lvGanado.Items.Count
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Try
            Dim lin, col As Integer

            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Libro = AppExcel.Workbooks.Add
            Hoja = Libro.Worksheets(1)

            'Libro.Title = "Consulta de Ganado..."
            'Libro.Author = "ndsky"
            'Hoja.Name = "Libro Exportado"

            For col = 1 To lvGanado.Columns.Count - 1

                Hoja.Cells(1, col) = lvGanado.Columns(col).Text
                Hoja.Cells(1, col).font.bold = True
                Hoja.Cells(1, col).font.size = 12

            Next

            For lin = 0 To lvGanado.Items.Count - 1

                For col = 1 To lvGanado.Columns.Count - 1

                    Hoja.Cells(lin + 2, col) = lvGanado.Items(lin).SubItems(col).Text.ToString.Trim

                Next

                pbProcesa.Value = lin + 1

            Next

            lin = lin + 3
            Hoja.Cells(lin, 1) = "TOTAL CASOS: " + Total_Casos.ToString.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12
            Hoja.Cells(lin + 1, 1) = "TOTAL EN TRATAMIENTO: " + Total_Tratamientos.ToString.Trim : Hoja.Cells(lin + 1, 1).font.bold = True : Hoja.Cells(lin + 1, 1).font.size = 12
            Hoja.Cells(lin + 2, 1) = "TOTAL EN RESGUARDO: " + Total_Resguardos.ToString.Trim : Hoja.Cells(lin + 2, 1).font.bold = True : Hoja.Cells(lin + 2, 1).font.size = 12
            Hoja.Cells(lin + 3, 1) = "TOTAL PREVENTIVOS: " + Total_Preventivos.ToString.Trim : Hoja.Cells(lin + 2, 1).font.bold = True : Hoja.Cells(lin + 2, 1).font.size = 12

            pbProcesa.Value = pbProcesa.Maximum

            AppExcel.Visible = True
            AppActivate(AppExcel.Caption)

            Hoja = Nothing      'Descargamos los Objetos...
            Libro = Nothing
            AppExcel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        pnlProcesa.Visible = False
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        Cursor.Current = Cursors.WaitCursor

        ConsultaCojeras(cent_)
        'Para Graficos
        Consulta_Graficos(cent_, "ANUAL", "COJERAS")
        Consulta_Graficos(cent_, "ANUAL", "PREVENTIVOS")
        Consulta_Graficos(cent_, "CASOS", "")
        Consulta_Graficos(cent_, "COJAS_MENSUAL", "")
        Consulta_Graficos(cent_, "COJAS_POR_CENTRO", "")
        Consulta_Graficos(cent_, "COJAS_POR_TIPO", "")

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleCojeras()
        End If
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL CASOS" : tot(0, 1) = Total_Casos.ToString.Trim
        tot(1, 0) = "TOTAL EN TRATAMIENTO" : tot(1, 1) = Total_Tratamientos.ToString.Trim
        tot(2, 0) = "TOTAL EN RESGUARDO" : tot(2, 1) = Total_Resguardos.ToString.Trim
        tot(3, 0) = "TOTAL PREVENTIVOS" : tot(3, 1) = Total_Preventivos.ToString.Trim

        ExportToExcelGrilla(lvGanado, tot)
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        FrmCojerasIngreso.MdiParent = frmMAIN
        FrmCojerasIngreso.Show()
    End Sub


    Private Sub FrmCojeras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now

        CboLLenaCentros()

    End Sub

    Public Sub Consulta_Graficos(ByVal centro_ As String, ByVal TipoGrafico As String, ByVal Dato As String) 'Para Grafico
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCojeras_Graficos", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@FechaIni", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaFin", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            'CASOS_MENSUAL
            If TipoGrafico = "ANUAL" And Dato = "COJERAS" Then
                ChartCasosMensual.Series("SerieCojas").Points.DataBindXY(rdrGraphic, "AñoMes", rdrGraphic, "TotalCojas")
            End If
            'CASOS_MENSUAL
            If TipoGrafico = "ANUAL" And Dato = "PREVENTIVOS" Then
                ChartCasosMensual.Series("SeriePreventivos").Points.DataBindXY(rdrGraphic, "AñoMes", rdrGraphic, "TotalPreventivos")
            End If
            'CASOS_MAS_DE_3
            If TipoGrafico = "CASOS" Then
                ChartCasosMasDe3.Series("SerieCasos").Points.DataBindXY(rdrGraphic, "Casos", rdrGraphic, "CantAnimales")
            End If
            If TipoGrafico = "COJAS_MENSUAL" Then
                ChartCojasMensual.Series("SerieCojasMes").Points.DataBindXY(rdrGraphic, "Ames", rdrGraphic, "CantAnimales")
            End If
            If TipoGrafico = "COJAS_POR_CENTRO" Then
                ChartCojasCentro.Series("SerieCojasPorCentro").Points.DataBindXY(rdrGraphic, "CentroNom", rdrGraphic, "CantAnimales")
            End If
            If TipoGrafico = "COJAS_POR_TIPO" Then
                ChartCojasPorTipo.Series("SerieCojasPorTipo").Points.DataBindXY(rdrGraphic, "TipoCojeraNom", rdrGraphic, "CantAnimales")
            End If

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        btnBuscar_Click(sender, e)
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click

    End Sub
End Class