


Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient



Public Class FrmMastitis


    Private NroRegistros As Integer = 0
    Private Total_Casos As Integer = 0
    Private Total_Tratamientos As Integer = 0
    Private Total_Resguardos As Integer = 0




    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
        'cboCentros.Text = NombreCentroUsuario
    End Sub



    Private Sub InicializaTotales()
        NroRegistros = 0
        Total_Casos = 0
        Total_Tratamientos = 0
        Total_Resguardos = 0
    End Sub


    Private Sub MuestraTotales()
        Label85.Text = Total_Casos.ToString.Trim
        Label6.Text = Total_Tratamientos.ToString.Trim
        Label8.Text = Total_Resguardos.ToString.Trim
    End Sub



    Public Sub ConsultaMastitis(ByVal cent_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMastitis_ListadoPorCentros", con)
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

                    item.SubItems.Add(rdr("MastEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("MastCentro").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(rdr("SumaMastitis").ToString.Trim)                                'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("SumaTratamiento").ToString.Trim)                                'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("SumaResguardo").ToString.Trim)

                    lvGanado.Items.Add(item)

                    NroRegistros = NroRegistros + 1
                    Total_Casos = Total_Casos + rdr("SumaMastitis")
                    Total_Tratamientos = Total_Tratamientos + rdr("SumaTratamiento")
                    Total_Resguardos = Total_Resguardos + rdr("SumaResguardo")

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


    Private Sub DetalleMastitis()
        Dim cent_ As String = lvGanado.SelectedItems(0).SubItems(2).Text            'codigo centro
        Dim nomcent_ As String = lvGanado.SelectedItems(0).SubItems(3).Text         'nombre centro
        Dim casos_ As String = lvGanado.SelectedItems(0).SubItems(4).Text           '
        Dim tratamientos_ As String = lvGanado.SelectedItems(0).SubItems(5).Text    '
        Dim resguardos_ As String = lvGanado.SelectedItems(0).SubItems(6).Text      '

        FrmMastitisDetalle.P1_CodigoCentro = cent_
        FrmMastitisDetalle.P2_NombreCentro = nomcent_
        FrmMastitisDetalle.P3_FechaDesde = dtpFechaDesde.Value
        FrmMastitisDetalle.P4_FechaHasta = dtpFechaHasta.Value
        FrmMastitisDetalle.P5_NroCasos = Int32.Parse(casos_)
        FrmMastitisDetalle.P6_NroTratamientos = Int32.Parse(tratamientos_)
        FrmMastitisDetalle.P7_NroResguardos = Int32.Parse(resguardos_)

        FrmMastitisDetalle.MdiParent = frmMAIN
        FrmMastitisDetalle.Show()
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL CASOS" : tot(0, 1) = Total_Casos.ToString.Trim
        tot(1, 0) = "TOTAL EN TRATAMIENTO" : tot(1, 1) = Total_Tratamientos.ToString.Trim
        tot(2, 0) = "TOTAL EN RESGUARDO" : tot(2, 1) = Total_Resguardos.ToString.Trim

        ExportToExcelGrilla(lvGanado, tot)
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        ConsultaMastitis(cent_)
        'Para Graficos
        ConsultaGraficoAño(cent_, "ANUAL", "MASTITIS")
        ConsultaGraficoAño(cent_, "CASOS", "")
    End Sub



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        FrmMastitisIngreso.MdiParent = frmMAIN
        FrmMastitisIngreso.Show()
        FrmMastitisIngreso.BringToFront()
    End Sub


    Private Sub lvGanado_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleMastitis()
        End If
    End Sub


    Private Sub FrmMastitis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now
    End Sub

    Public Sub ConsultaGraficoAño(ByVal centro_ As String, ByVal TipoGrafico As String, ByVal Dato As String) 'Para Grafico
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMastitis_Graficos", con)
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
            If TipoGrafico = "ANUAL" And Dato = "MASTITIS" Then
                ChartMastitisAnual.Series("SerieMastitis").Points.DataBindXY(rdrGraphic, "AMes", rdrGraphic, "TotalMast")
            End If
            If TipoGrafico = "CASOS" Then
                ChartCasos.Series("SerieCasos").Points.DataBindXY(rdrGraphic, "Casos", rdrGraphic, "CantAnimales")
            End If
            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub




    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        btnBuscar.PerformClick()
    End Sub
End Class