﻿Imports System.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Text

Public Class frmIngresoFertilizante

    Private existe As Integer = 0
    Private INVGrabarMovimientoBodega As New INV_GrabarMovimientoBodega
    Private ExistenRegistros As Boolean = False

    Friend WithEvents PrintDoc As New Printing.PrintDocument

    Private CentroCod As Integer = 0
    Private ProductoUreaCod As String = ""
    Private ProductoUreaNom As String = ""
    Private ProductoUreaStk As String = ""
    Private ProdUreaCuentaCod As String = ""
    Private ProdUreaItemGastoCod As String = ""
    Private UsoTipo As Integer = 0

    Public FertilizanteCod As String = ""
    Public CentroEnc As Integer = 0 'Centro codigo encabezado 
    Public CentroEncNom As String = "" 'Centro nombre encabezado 
    Public FechaEnc As String = "" 'Fecha Encabezado

    Private frmLoad As Boolean = True
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmIngresoUrea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        WebBrowser.Dock = DockStyle.Fill
        dtpFecha.Value = Now
        lblUrea.Hide()
        btnEliminar.Enabled = False

        If txtSaldoUrea.Text = "0" Then
            btnGrabar.Enabled = False
        End If

        MSTRUsuarios.DSCboUsuarioCentros_FrmINS(True, cboCentros)
        cboCentros.Text = UsuarioCentroNomDefault
        CentroCod = UsuarioCentroCodDefault

        TipoUso()
        UsoTipo = cboTipoUso.SelectedValue

        'MSTRProductosUrea.DSCboTipoUsoSuelo_FrmQRY(CentroCod, UsoTipo, cboProductos)

        If CentroEncNom <> "" Then
            cboCentros.Text = CentroEncNom
            CentroCod = UsuarioCentroCodDefault
            dtpFecha.Value = FechaEnc
            BuscarDatosFert()
            btnGrabar.Enabled = False
            cboCentros.Enabled = False
            cboProductos.Enabled = False
            cboTipoUso.Enabled = False
            txtDosisxHa.Enabled = False
            dtpFecha.Enabled = False
            dgvAU_POTREROS.Enabled = True
            dgvAU_POTREROS.ReadOnly = True
            btnEliminar.Enabled = True
            'cboProductos.Visible = False
            'lblUrea.Visible = True
        End If

        btnMin1.Visible = False
        btnMin2.Visible = False
        frmLoad = False
        'CentroEnc = 0
    End Sub


    Private Sub cboCentros_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCentros.SelectionChangeCommitted
        UsoTipo = cboTipoUso.SelectedValue
        Dim selectedRow As DataRowView = DirectCast(cboCentros.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then CentroCod = selectedRow("CentroCod")
        txtSaldoUrea.Text = "0"
        CentroEnc = 0
        MSTRProductosUrea.DSCboTipoUsoSuelo_FrmQRY(CentroCod, UsoTipo, cboProductos)

        txtUreaAplicada.Text = 0
        lblNroPotrerosAplicados.Text = 0
        lblTotalHectareasAplicadas.Text = 0
        Label1.Text = 0
        'Label11.Text = 0

        BuscarDatosFert()

        If txtSaldoUrea.Text = "0" Then
            btnGrabar.Enabled = False
        End If
        'btnGrabarConsumoDiario.Enabled = False
    End Sub

    Private Sub cboUrea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProductos.SelectedIndexChanged
        ProductoUreaCod = String.Empty : ProductoUreaNom = String.Empty : ProductoUreaStk = String.Empty : ProdUreaCuentaCod = String.Empty : ProdUreaItemGastoCod = String.Empty

        Dim selectedRow As DataRowView = DirectCast(cboProductos.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then ProductoUreaCod = selectedRow("ProductoUreaCod")
        If selectedRow IsNot Nothing Then ProductoUreaNom = selectedRow("ProductoUreaNom")
        If selectedRow IsNot Nothing Then ProductoUreaStk = selectedRow("ProductoUreaStk")
        If selectedRow IsNot Nothing Then ProdUreaCuentaCod = selectedRow("ProdUreaCuentaCod")
        If selectedRow IsNot Nothing Then ProdUreaItemGastoCod = selectedRow("ProdUreaItemGastoCod")

        GraficoUreaAcumuladaMes()
        GraficoUreaAcumuladaPeriodoAnual()
        txtSaldoUrea.Text = ProductoUreaStk
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        If frmLoad Then Exit Sub
        BuscarDatosFert()

        If ExistenRegistros = True Then
            btnGrabar.Enabled = False
        Else
            btnGrabar.Enabled = True
        End If
    End Sub

    Private Sub BuscarDatosFert()
        txtUreaAsignada.Enabled = False
        cboProductos.Enabled = True
        btnGrabar.Enabled = True

        'If CentroEnc <> 0 Then
        'BuscaUrea()
        'Else
        If BuscaUrea() = False Then
            BuscaPotreros(True)
            txtUreaAsignada.Enabled = True
            existe = 0
            lblNroConsumo.Text = ""
            cboProductos.Show()
            lblUrea.Hide()
            cboTipoUso.Enabled = True
            txtDosisxHa.Enabled = True
        Else
            cboCentros.Text = IIf(CentroEncNom = "", cboCentros.SelectedText, CentroEncNom)
            CentroEncNom = ""
            'CentroCod = UsuarioCentroCodDefault
            'dtpFecha.Value = FechaEnc
            'BuscarDatosFert()
            btnGrabar.Enabled = False
            'cboCentros.Enabled = False
            cboProductos.Enabled = False
            cboTipoUso.Enabled = False
            txtDosisxHa.Enabled = False
            'dtpFecha.Enabled = False
            'lblUrea.Visible = True
        End If
        'End If

        'If BuscaUrea() = False Then
        '    BuscaPotreros(True)
        '    txtUreaAsignada.Enabled = True
        '    existe = 0
        '    lblNroConsumo.Text = ""
        '    cboProductos.Show()
        '    lblUrea.Hide()
        'Else
        '    cboProductos.Hide()
        '    lblUrea.Show()
        '    btnGrabar.Enabled = False
        '    If lblNroConsumo.Text.Contains("0") = True Then
        '        btnGrabar.Enabled = False
        '        txtSaldoUrea.Text = "---"
        '    Else
        '        btnGrabar.Enabled = True
        '    End If
        '    existe = 1
        'End If

        GraficoUreaAcumuladaMes()
        GraficoUreaAcumuladaPeriodoAnual()
        'btnEliminar.Enabled = False

        'For i = 0 To dgvAU_POTREROS.Rows.Count - 1
        '    If dgvAU_POTREROS.Rows(i).Cells(0).Value = True Then
        '        btnEliminar.Enabled = True
        '    End If
        'Next

    End Sub
    Private Function BuscaUrea() As Boolean
        BuscaUrea = False
        ExistenRegistros = False

        txtDosisxHa.Text = ""
        'txtUreaAsignada.Text = ""
        txtUreaAplicada.Text = "0"

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_BuscarFertSuelo", con)
        Dim rdr As SqlDataReader = Nothing

        Try
            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            'cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            'cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            'cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            If CentroEnc = 0 Then
                cmd.Parameters.AddWithValue("@Centro", CentroCod)
            Else
                cmd.Parameters.AddWithValue("@Centro", CentroEnc)
            End If


            con.Open()
            rdr = cmd.ExecuteReader()

            Dim rowIdx As Integer = 0
            Dim nro_sel As Integer = 0
            Dim ha As Double = 0
            Dim ha_Sel As Double = 0
            Dim sel As String = ""


            lblNroPotreros.Text = "0"
            lblTotalHectareas.Text = "0"

            dgvAU_POTREROS.Rows.Clear()

            While rdr.Read()
                BuscaUrea = True
                ExistenRegistros = True
                sel = "False"
                '
                Dim PotreroTipo As Integer = rdr("FDetSueloPotreroTipo")
                Dim TienePurin As String = rdr("Purin")
                Dim TipoUso As String = rdr("FertSueloTipUsoNom")
                txtDosisxHa.Text = rdr("PromedioFDetSueloCantidad")

                txtUreaAsignada.Text = "0" 'rdr("UreaRetirada")
                txtUreaAplicada.Text = rdr("FertSueloTotalAplicado")

                If IsDBNull(rdr("FertSueloAplicadaNom")) Then
                    lblUrea.Text = ""
                Else
                    cboProductos.Text = rdr("FertSueloAplicadaNom")
                    cboTipoUso.Text = TipoUso
                End If


                If rdr("FertSueloConsumoGP").ToString.Trim <> "" Then
                    lblNroConsumo.Text = Convert.ToInt32(rdr("FertSueloConsumoGP")).ToString
                End If

                If rdr("FDetSueloCantidad").ToString <> "0" Then
                    sel = "True"
                    nro_sel = nro_sel + 1
                    ha_Sel = ha_Sel + Convert.ToDouble(rdr("FDetSueloHa"))
                End If

                dgvAU_POTREROS.Rows.Add(sel, rdr("FDetSueloPotreroCod"), rdr("FDetSueloHa"), rdr("FertMensual"), rdr("FertTemporada"), rdr("FDetSueloCantidadXHa"), rdr("FDetSueloCantidad"), PotreroTipo)

                If dgvAU_POTREROS.Rows(dgvAU_POTREROS.Rows.Count - 1).Cells(0).EditedFormattedValue.ToString = "True" Then
                    dgvAU_POTREROS.Rows(dgvAU_POTREROS.Rows.Count - 1).Cells(0).Style.BackColor = Color.SteelBlue
                End If

                If PotreroTipo = 2 Then
                    dgvAU_POTREROS.Rows(rowIdx).ReadOnly = True
                    dgvAU_POTREROS.Rows(rowIdx).DefaultCellStyle.BackColor = Color.Orange
                End If
                If TienePurin <> "" Then
                    dgvAU_POTREROS.Rows(rowIdx).Cells(1).Style.BackColor = Color.LightBlue
                End If

                ha += Convert.ToDouble(rdr("FDetSueloHa"))
                rowIdx += 1
            End While

            lblNroPotreros.Text = rowIdx.ToString
            lblTotalHectareas.Text = ha
            lblNroPotrerosAplicados.Text = nro_sel.ToString
            lblTotalHectareasAplicadas.Text = ha_Sel

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            rdr.Close()
            cmd.Dispose()
            con.Close()
        End Try
        Cursor.Current = Cursors.WaitCursor
    End Function
    Private Sub BuscaPotreros(Optional ByVal CargarMapa As Boolean = False)
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spFertilizante_BuscaPotreros", con)
        Dim rdr As SqlDataReader = Nothing
        Try
            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            'cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            If CentroEnc = 0 Then
                cmd.Parameters.AddWithValue("@Centro", CentroCod)
            Else
                cmd.Parameters.AddWithValue("@Centro", CentroEnc)
            End If

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim rowIdx As Integer = 0
            Dim ha As Double = 0
            Dim TotalAcc As Integer = 0

            lblNroPotreros.Text = "0"
            lblTotalHectareas.Text = "0"

            dgvAU_POTREROS.Rows.Clear()

            While rdr.Read()
                Dim UreaPotreroTipo As Integer = rdr("Potrerotipo")
                Dim TienePurin As String = rdr("Purin")

                dgvAU_POTREROS.Rows.Add("false", rdr("PotreroCod"), rdr("PotreroHa"), rdr("FertAcum"), rdr("FertAcumPeriodo"), rdr("FertCantidadHa"), rdr("FertCantidad"), rdr("Potrerotipo"), rdr("Ultimoingreso"))

                If UreaPotreroTipo = 2 Then
                    dgvAU_POTREROS.Rows(rowIdx).ReadOnly = True
                    dgvAU_POTREROS.Rows(rowIdx).DefaultCellStyle.BackColor = Color.Orange
                End If
                If TienePurin <> "" Then
                    dgvAU_POTREROS.Rows(rowIdx).Cells(1).Style.BackColor = Color.LightBlue
                End If
                ha += Convert.ToDouble(rdr("PotreroHa"))
                rowIdx += 1
                dgvAU_POTREROS.PerformLayout()
            End While
            lblNroPotreros.Text = rowIdx.ToString
            lblTotalHectareas.Text = ha

            If TotalAcc > 0 Then
                btnGrabar.Enabled = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            rdr.Close()
            cmd.Dispose()
            con.Close()
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub GraficoUreaAcumuladaMes()
        Cursor.Current = Cursors.WaitCursor

        Dim connectionString As String = GetConnectionString()
        Dim sql As String = "spPraderas_FertilidadSuelo_GraficoMes"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(sql, con)
                Dim rdr As SqlDataReader = Nothing

                Try
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Empresa", Empresa)
                    cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)

                    If CentroEnc = 0 Then
                        cmd.Parameters.AddWithValue("@Centro", CentroCod)
                        cmd.Parameters.AddWithValue("@FertilizanteCod", ProductoUreaCod)
                    Else
                        cmd.Parameters.AddWithValue("@Centro", CentroEnc)
                        cmd.Parameters.AddWithValue("@FertilizanteCod", FertilizanteCod)
                    End If

                    con.Open()
                    rdr = cmd.ExecuteReader()
                    chartUreaAcumuladaMes.Series("Series1").Points.Clear()
                    chartUreaAcumuladaMes.Titles(0).Text = "Acumulada Mes"

                    If rdr.Read() Then
                        Dim titleText As String = $"{Trim(ProductoUreaNom)} Acumulada Mes {MonthName(dtpFecha.Value.Month).ToUpper} Del {dtpFecha.Value.Year}"
                        chartUreaAcumuladaMes.Titles(0).Text = titleText
                        chartUreaAcumuladaMes.Series("Series1").Points.DataBindXY(rdr, "FDetSueloPotreroCod", rdr, "Cantidad")
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                Finally
                    rdr.Close()
                End Try
            End Using
        End Using

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub GraficoUreaAcumuladaPeriodoAnual()
        Cursor.Current = Cursors.WaitCursor

        Dim connectionString As String = GetConnectionString()
        Dim sql As String = "spPradera_FetilidadSuelo_GraficoTemporada"

        Using con As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(sql, con)
                Dim rdr As SqlDataReader = Nothing
                Dim ureatotal As Integer = 0
                Dim ureaprom As Integer = 0



                Try
                    cmd.CommandType = Data.CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@Empresa", Empresa)

                    If CentroEnc = 0 Then
                        cmd.Parameters.AddWithValue("@Centro", CentroCod)
                        cmd.Parameters.AddWithValue("@FertilizanteCod", ProductoUreaCod)
                    Else
                        cmd.Parameters.AddWithValue("@Centro", CentroEnc)
                        cmd.Parameters.AddWithValue("@FertilizanteCod", FertilizanteCod)
                    End If

                    con.Open()
                    rdr = cmd.ExecuteReader()
                    chartUreaAcumuladaTemporada.Series("Series1").Points.Clear()
                    chartUreaAcumuladaTemporada.Titles(0).Text = "Acumulada Temporada"
                    If rdr.Read() Then
                        ureaprom = rdr("FertPromedioAplicado")
                        ureatotal = rdr("TotalFertilizante")

                        Dim titleText As New StringBuilder()
                        titleText.Append($"{ProductoUreaNom} Temporada Desde el ")
                        titleText.Append($"{TemporadaFechaIni.ToString("dd-MM-yyyy")} Hasta el ")
                        titleText.Append($"{TemporadaFechaFin.ToString("dd-MM-yyyy")} Total Utilizada: ")
                        titleText.Append($"{ureatotal.ToString("##,##")} Promedio x Hectarea: ")
                        titleText.Append($"{ureaprom.ToString("##,##")}")

                        chartUreaAcumuladaTemporada.Titles(0).Text = titleText.ToString()
                        chartUreaAcumuladaTemporada.Series("Series1").Points.DataBindXY(rdr, "FDetSueloPotreroCod", rdr, "Cantidad")
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                Finally
                    rdr.Close()
                End Try
            End Using
        End Using

        Cursor.Current = Cursors.Default
    End Sub
    Private Function GrabarFertilizado() As Boolean
        GrabarFertilizado = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_FertilidadSuelos_Grabar", con)

        Dim Observacion As String = "Consumo desde aplicacion de Fertilidad de Suelos"
        Dim BodegaOrigen As String = CentroCod.ToString.Substring(0, 5)
        Dim Bodegadestino As String = ""
        Dim TipoMovimiento As Integer = 4 ' Movimiento GP 4 = Movimiento interno

        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE RETIRO
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim ha, acum, acumper, cant, cant_ha As Double

        Dim DTPotreros As DataTable = New DataTable

        DTPotreros.Columns.Add("PotreroCod", System.Type.GetType("System.String"))
        DTPotreros.Columns.Add("PotreroHa", System.Type.GetType("System.Decimal"))
        DTPotreros.Columns.Add("Acumulado", System.Type.GetType("System.Decimal"))
        DTPotreros.Columns.Add("AcumuladoPer", System.Type.GetType("System.Decimal"))
        DTPotreros.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
        DTPotreros.Columns.Add("CantidadHa", System.Type.GetType("System.Decimal"))
        DTPotreros.Columns.Add("ProdFertCod", System.Type.GetType("System.String"))
        DTPotreros.Columns.Add("ProdFertNom", System.Type.GetType("System.String"))
        DTPotreros.Columns.Add("ProdFertHaTot", System.Type.GetType("System.Decimal"))
        DTPotreros.Columns.Add("ProdFertxHa", System.Type.GetType("System.Decimal"))
        DTPotreros.Columns.Add("ProdFertCantTot", System.Type.GetType("System.Decimal"))

        'Dim i As Integer
        For i = 0 To dgvAU_POTREROS.Rows.Count - 1


            ha = 0
            acum = 0
            acumper = 0
            cant = 0
            cant_ha = 0

            If dgvAU_POTREROS.Rows(i).Cells(2).Value IsNot Nothing Then If dgvAU_POTREROS.Rows(i).Cells(2).Value.ToString.Trim <> "" Then ha = Double.Parse(dgvAU_POTREROS.Rows(i).Cells(2).Value)
            If dgvAU_POTREROS.Rows(i).Cells(3).Value IsNot Nothing Then If dgvAU_POTREROS.Rows(i).Cells(3).Value.ToString.Trim <> "" Then acum = Double.Parse(dgvAU_POTREROS.Rows(i).Cells(3).Value)
            If dgvAU_POTREROS.Rows(i).Cells(4).Value IsNot Nothing Then If dgvAU_POTREROS.Rows(i).Cells(4).Value.ToString.Trim <> "" Then acumper = Double.Parse(dgvAU_POTREROS.Rows(i).Cells(4).Value)
            If dgvAU_POTREROS.Rows(i).Cells(5).Value IsNot Nothing Then If dgvAU_POTREROS.Rows(i).Cells(5).Value.ToString.Trim <> "" Then cant_ha = Double.Parse(dgvAU_POTREROS.Rows(i).Cells(5).Value)
            If dgvAU_POTREROS.Rows(i).Cells(6).Value IsNot Nothing Then If dgvAU_POTREROS.Rows(i).Cells(6).Value.ToString.Trim <> "" Then cant = Double.Parse(dgvAU_POTREROS.Rows(i).Cells(6).Value)

            DTPotreros.Rows.Add(dgvAU_POTREROS.Rows(i).Cells(1).Value, ha, acum, acumper, cant, cant_ha, ProductoUreaCod, ProductoUreaNom, ha, cant_ha, cant)

        Next

        cmd.Parameters.Clear()
        'cmd.Parameters.AddWithValue("@Commit", 0)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)

        cmd.Parameters.AddWithValue("@MovObs", Observacion)
        cmd.Parameters.AddWithValue("@TipoMov", TipoMovimiento)
        cmd.Parameters.AddWithValue("@BodegaCodO", BodegaOrigen)
        cmd.Parameters.AddWithValue("@BodegaCodD", Bodegadestino)
        cmd.Parameters.AddWithValue("@DTFertilidadSuelo_Potreros", DTPotreros)
        ''
        cmd.Parameters.AddWithValue("@Dosis", CDbl(txtDosisxHa.Text))
        cmd.Parameters.AddWithValue("@FertAplicada", CDbl(txtUreaAplicada.Text))
        cmd.Parameters.AddWithValue("@ProductoFertCod", ProductoUreaCod)
        cmd.Parameters.AddWithValue("@ProductoFertNom", ProductoUreaNom)
        cmd.Parameters.AddWithValue("@TipoUso", cboTipoUso.SelectedValue)
        ''
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try

            Result = cmd.ExecuteNonQuery()

            vret = cmd.Parameters("@ResultCod").Value
            mret = cmd.Parameters("@ResultMsg").Value
            GrabarFertilizado = True
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    GrabarFertilizado = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            GrabarFertilizado = False
        End Try
        con.Close()
        Cursor.Current = Cursors.Default
    End Function
    'Private Function ActualizaIDGPUrea(ByVal IDGP As String) As Boolean
    '    ActualizaIDGPUrea = False

    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spPraderas_ActualizaUreaIDGP", con)

    '    cmd.CommandType = Data.CommandType.StoredProcedure
    '    '
    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@Centro", CentroCod)
    '    cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
    '    cmd.Parameters.AddWithValue("@IDGP", IDGP)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)
    '    '
    '    cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
    '    cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

    '    Try
    '        con.Open()

    '        Dim Result As Integer = cmd.ExecuteNonQuery()

    '        Dim vret As Integer = cmd.Parameters("@RetValor").Value
    '        Dim mret As String = cmd.Parameters("@RetMensage").Value

    '        If vret > 0 Then
    '            If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
    '            End If
    '            Exit Function
    '        End If

    '        ActualizaIDGPUrea = True

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
    '    Finally
    '        cmd.Dispose()
    '        con.Close()
    '    End Try
    'End Function
    Private Function EliminarFert() As Boolean
        EliminarFert = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_FertilidadSuelos_Eliminar", con)

        cmd.CommandType = Data.CommandType.StoredProcedure
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@ProdFertilizanteCod", ProductoUreaCod.Trim)
        cmd.Parameters.AddWithValue("@Obs", "TEST")
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            EliminarFert = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            cmd.Dispose()
            con.Close()
        End Try
    End Function
    Private Sub dgvPOTREROS_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAU_POTREROS.CellContentClick

        If e.ColumnIndex = 0 Then
            If dgvAU_POTREROS.Columns(e.ColumnIndex).Name = "Bool" Then
                dgvAU_POTREROS.CommitEdit(Nothing)
            End If
            If dgvAU_POTREROS.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor <> Color.Gray And dgvAU_POTREROS.Rows(e.RowIndex).Cells(7).Value = 1 Then

                Dim Dosis As Double = 0
                If txtDosisxHa.Text.Trim <> "" Then Dosis = CDbl(txtDosisxHa.Text)

                Dim Hectareas As Double = IIf(dgvAU_POTREROS.Rows(e.RowIndex).Cells(2).EditedFormattedValue.ToString.Trim = "", 0, CDbl(dgvAU_POTREROS.Rows(e.RowIndex).Cells(2).EditedFormattedValue.ToString.Trim))
                Dim Apli As Double = IIf(txtUreaAplicada.Text.Trim = "", 0, CDbl(txtUreaAplicada.Text))

                If dgvAU_POTREROS.Rows(e.RowIndex).Cells(0).EditedFormattedValue.ToString = "True" Then
                    Dim cant As Double = Dosis * Hectareas
                    Dim cant_ha As Double = cant / Hectareas

                    dgvAU_POTREROS.Rows(e.RowIndex).Cells(0).Style.BackColor = Color.SteelBlue
                    dgvAU_POTREROS.Rows(e.RowIndex).Cells(5).Value = Format(cant_ha, "#,#0")
                    dgvAU_POTREROS.Rows(e.RowIndex).Cells(6).Value = Format(cant, "#,#0")
                    Apli += cant

                    lblNroPotrerosAplicados.Text = Convert.ToInt32(lblNroPotrerosAplicados.Text) + 1
                    lblTotalHectareasAplicadas.Text = Convert.ToDouble(lblTotalHectareasAplicadas.Text) + Hectareas

                    txtUreaAsignada.Enabled = False
                Else
                    Apli -= CDbl(dgvAU_POTREROS.Rows(e.RowIndex).Cells(6).Value)

                    dgvAU_POTREROS.Rows(e.RowIndex).Cells(0).Style.BackColor = Color.White

                    dgvAU_POTREROS.Rows(e.RowIndex).Cells(5).Value = "0"
                    dgvAU_POTREROS.Rows(e.RowIndex).Cells(6).Value = "0"

                    lblNroPotrerosAplicados.Text = Convert.ToInt32(lblNroPotrerosAplicados.Text) - 1
                    lblTotalHectareasAplicadas.Text = Convert.ToDouble(lblTotalHectareasAplicadas.Text) - Hectareas

                End If

                txtUreaAplicada.Text = Format(Apli, "#,#0")
            End If
        End If
    End Sub
    Private Sub dgvPOTREROS_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAU_POTREROS.CellContentDoubleClick
        Call dgvPOTREROS_CellContentClick(sender, e)
    End Sub
    Private Function ValidacionLocal() As Boolean
        ValidacionLocal = False

        Dim i As Integer
        Dim con_datos As Boolean = False

        For i = 0 To dgvAU_POTREROS.Rows.Count - 1
            If dgvAU_POTREROS.Rows(i).Cells(0).EditedFormattedValue.ToString = "True" Then
                con_datos = True
                Exit For
            End If
        Next

        ValidacionLocal = con_datos
    End Function

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim TipoUso As String = cboTipoUso.Text
        Dim TipoFert As String = cboProductos.Text

        If Val(Replace(txtUreaAplicada.Text, ".", "")) > Val(txtSaldoUrea.Text) Then
            MsgBox("EL ITEM UTILIZADO SUPERA EL STOCK ACTUAL: " + txtSaldoUrea.Text, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ADVENTENCIA")
            Exit Sub
        End If

        If txtDosisxHa.Text = "" Then
            If MsgBox("DEBE INGRESAR LAS DOSIS POR HECTAREA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
            txtDosisxHa.Focus()
            Exit Sub
        End If

        If ValidacionLocal() = False Then
            If MsgBox("DEBE SELECCIONAR POTREROS", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACIÓN") <> MsgBoxResult.Ok Then
            End If
            Exit Sub
        End If
        'CONFIRMAR
        If MsgBox("¿CONFIRMAR LOS DATOS INGRESADO? " + "(Tipo Uso: " + TipoUso + " Tipo Fertilizante: " + TipoFert + ")", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        'GrabarConsumoDiario()
        If GrabarFertilizado() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                btnGrabar.Enabled = False
            End If
            cboProductos.Enabled = False

            BuscarDatosFert()
        End If
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        EliminarFertilizado()
    End Sub

    Private Sub EliminarFertilizado()
        If ExistenRegistros = False Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR LAS UREAS DEL DIA SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            'If Not lblNroConsumo.Text.Contains("0") Then

            If ProductoUreaCod IsNot "" And (ProdUreaCuentaCod Is "" Or ProdUreaItemGastoCod Is "") Then
                    If MsgBox("NO SE ENCUENTRA LA ESPECIFICACIÓN DEL PRODUCTO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
                    End If
                    Exit Sub
                End If

            If EliminarFert() = True Then
                MsgBox("DATOS ELIMINADOS CORRECTAMENTE ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ELIMINADO")
                Me.Close()
            End If
            ' End If
        End If
    End Sub

    Private Sub ValidaSizeChart1()
        If gboxIngMediciones.Visible = True Then
            gboxIngMediciones.Visible = False
            chartUreaAcumuladaTemporada.Visible = False
            btnMax1.Visible = False
            btnMin1.Visible = True
            btnMax2.Visible = False

            tabPASTO.Left = gboxIngMediciones.Left
            tabPASTO.Width = pnlEstReprod.Width
            chartUreaAcumuladaMes.Dock = DockStyle.Fill

            btnMin1.Left = 671 + 395

        Else
            gboxIngMediciones.Visible = True
            chartUreaAcumuladaTemporada.Visible = True
            btnMax1.Visible = True
            btnMin1.Visible = False
            btnMax2.Visible = True

            tabPASTO.Left = 390
            tabPASTO.Width = 740
            chartUreaAcumuladaMes.Dock = DockStyle.None

            chartUreaAcumuladaMes.Left = 3
            chartUreaAcumuladaMes.Top = 2
            chartUreaAcumuladaMes.Width = 728
            chartUreaAcumuladaMes.Height = 232
        End If

        lblErrNomArchivo.Width = TabPage1.Width
    End Sub


    Private Sub ValidaSizeChart2()
        If gboxIngMediciones.Visible = True Then
            gboxIngMediciones.Visible = False
            chartUreaAcumuladaMes.Visible = False
            btnMax2.Visible = False
            btnMin2.Visible = True
            btnMax1.Visible = False
            btnMin2.Top = btnMin1.Top

            tabPASTO.Left = gboxIngMediciones.Left
            tabPASTO.Width = pnlEstReprod.Width
            chartUreaAcumuladaTemporada.Dock = DockStyle.Fill

            btnMin2.Left = 671 + 395

            chartUreaAcumuladaTemporada.Series(0).Label = "#VAL{N0}"
        Else
            gboxIngMediciones.Visible = True
            chartUreaAcumuladaMes.Visible = True
            btnMax2.Visible = True
            btnMin2.Visible = False
            btnMax1.Visible = True

            tabPASTO.Left = 390
            tabPASTO.Width = 740
            chartUreaAcumuladaTemporada.Dock = DockStyle.None

            chartUreaAcumuladaTemporada.Left = 3
            chartUreaAcumuladaTemporada.Top = 237
            chartUreaAcumuladaTemporada.Width = 728
            chartUreaAcumuladaTemporada.Height = 232

            chartUreaAcumuladaTemporada.Series(0).Label = ""
        End If

        lblErrNomArchivo.Width = TabPage1.Width
    End Sub


    Private Sub btnMax1_Click(sender As Object, e As EventArgs) Handles btnMax1.Click
        ValidaSizeChart1()
    End Sub

    Private Sub btnMin1_Click(sender As Object, e As EventArgs) Handles btnMin1.Click
        ValidaSizeChart1()
    End Sub

    Private Sub btnMax2_Click(sender As Object, e As EventArgs) Handles btnMax2.Click
        ValidaSizeChart2()
    End Sub

    Private Sub btnMin2_Click(sender As Object, e As EventArgs) Handles btnMin2.Click
        ValidaSizeChart2()
    End Sub

    Private Sub btnImprime_Click(sender As Object, e As EventArgs) Handles btnImprime.Click
        If gboxIngMediciones.Visible = True Then
            PrintPreviewDialog.Document = PrintDoc
            PrintPreviewDialog.Document.DefaultPageSettings.Landscape = True
            PrintPreviewDialog.ShowDialog()
        Else
            If chartUreaAcumuladaMes.Visible = True Then
                chartUreaAcumuladaMes.Printing.PrintDocument.DefaultPageSettings.Landscape = True
                chartUreaAcumuladaMes.Printing.PrintPreview()   ' .Print(True)
            Else
                chartUreaAcumuladaTemporada.Printing.PrintDocument.DefaultPageSettings.Landscape = True
                chartUreaAcumuladaTemporada.Printing.PrintPreview()   ' .Print(True)
            End If
        End If
    End Sub

    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

        Dim g As Graphics
        g = e.Graphics

        'archivos temporales que contendran las imagenes en formato .png
        Dim f1, f2 As String
        f1 = IO.Path.GetTempFileName() : chartUreaAcumuladaMes.SaveImage(f1, Imaging.ImageFormat.Bmp)
        f2 = IO.Path.GetTempFileName() : chartUreaAcumuladaTemporada.SaveImage(f2, Imaging.ImageFormat.Bmp)

        'cargamos imagenes desde los archivos temporales
        Dim newImage1 As Image = Image.FromFile(f1)
        Dim newImage2 As Image = Image.FromFile(f2)

        'dibujamos las imagenes en la hoja de impresion (PrintDocument)
        g.DrawImage(newImage1, 50, 100)
        g.DrawImage(newImage2, 50, newImage1.Height + 150)

        g.Dispose()
        e.HasMorePages = False
    End Sub


    'Private Sub btnGrabarConsumoDiario_Click(sender As Object, e As EventArgs) Handles btnGrabarConsumoDiario.Click
    'Private Sub GrabarConsumoDiario()
    '    If txtUreaAplicada.Text = "0" Then
    '        If MsgBox("DEBE REALIZAR UN REGITRO DE UREA PRIMERO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
    '        End If
    '        Exit Sub
    '    End If

    '    If lblNroConsumo.Text = "0" Or lblNroConsumo.Text <> "" Then
    '        If MsgBox("YA SE REALIZO CONSUMO DE UREA PARA ESTE DIA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
    '        End If
    '        Exit Sub
    '    End If

    '    If ProductoUreaCod IsNot "" And (ProdUreaCuentaCod Is "" Or ProdUreaItemGastoCod Is "") Then
    '        If MsgBox("NO SE ENCUENTRA LA ESPECIFICACIÓN DEL PRODUCTO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
    '        End If
    '        Exit Sub
    '    End If

    '    If MsgBox("¿ DESEA GRABAR EL CONSUMO INGRESADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
    '        Exit Sub
    '    End If

    '    'obtenemos data_table con el detalle de los productos a consumir
    '    Dim DTItems As DataTable = DataTableConsumoUrea(ProductoUreaCod, ProductoUreaNom, ProdUreaCuentaCod, ProdUreaItemGastoCod)
    '    '
    '    Dim BodegaCod As String = CentroCod.ToString.Substring(0, 5)
    '    Dim resultado As String = INVGrabarMovimientoBodega.GrabarInventario(Empresa, DTItems, dtpFecha.Value, 4, "Consumo desde aplicacion de Urea", BodegaCod, "")
    '    MsgBox(resultado, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FINALIZADO")
    '    Dim IDGP As String = INVGrabarMovimientoBodega.IVDOCNMBR

    '    If IDGP <> "" Then

    '        ActualizaIDGPUrea(IDGP)
    '        lblNroConsumo.Text = Convert.ToInt32(IDGP).ToString

    '        BuscarDatosFert()
    '        btnGrabar.Enabled = False
    '    End If
    'End Sub


    Public Function DataTableConsumoUrea(ByVal Producto As String, ByVal NomProducto As String, ByVal Cuentas As String, ByVal ItemGasto As String) As DataTable
        DataTableConsumoUrea = Nothing
        Dim table As DataTable = New DataTable("TablaDetalle")

        Dim stock As Integer = txtSaldoUrea.Text
        Dim cant As Double = Convert.ToDouble(txtUreaAplicada.Text)
        table.Columns.Add("ItemCod", System.Type.GetType("System.String"))
        table.Columns.Add("ItemNom", System.Type.GetType("System.String"))
        table.Columns.Add("ItemCnt", System.Type.GetType("System.Decimal"))
        table.Columns.Add("ItemUM", System.Type.GetType("System.String"))
        table.Columns.Add("ContraCtaCod", System.Type.GetType("System.String"))        'GetType(Integer)
        table.Columns.Add("ItemGastoCod", System.Type.GetType("System.String"))
        table.Columns.Add("ItemStkActual", System.Type.GetType("System.Decimal"))
        table.Columns.Add("TipoMov", System.Type.GetType("System.Decimal"))

        table.Rows.Add(Producto, NomProducto, cant, "KG", Cuentas, ItemGasto, stock, 1)

        DataTableConsumoUrea = table
    End Function


    Private Sub txtDosisxHa_TextChanged(sender As Object, e As EventArgs) Handles txtDosisxHa.TextChanged
        If IsNumeric(txtDosisxHa.Text) Then
            If Convert.ToDouble(txtDosisxHa.Text) > 0 Then
                dgvAU_POTREROS.Enabled = True
            Else
                dgvAU_POTREROS.Enabled = False
            End If
        Else
            dgvAU_POTREROS.Enabled = False
        End If
    End Sub

    Private Sub tabPASTO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabPASTO.SelectedIndexChanged
        If tabPASTO.TabPages(tabPASTO.SelectedIndex).Name.Contains("2") Then BuscarArchivoMapa(True)
    End Sub


    Private Sub BuscarArchivoMapa(Optional ByVal CargarMapa As Boolean = False)
        If CargarMapa = False Then Exit Sub

        lblErrNomArchivo.Visible = False
        lblErrNomArchivo.Text = "No se encuentra el mapa para el predio seleccionado (" + cboCentros.Text + ")"

        If General.MapFile(CentroCod, WebBrowser) = False Then
            lblErrNomArchivo.Visible = True
        End If

    End Sub
    Private Sub TipoUso()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSuelo_TipoUso", con)
        'Dim rdr As SqlDataReader = Nothing

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        da.SelectCommand = cmd
        da.Fill(dt)

        cboTipoUso.ValueMember = "FertCodigo"
        cboTipoUso.DisplayMember = "FertNombre"
        cboTipoUso.DataSource = dt

    End Sub

    Private Sub cboTipoUso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoUso.SelectedIndexChanged
        UsoTipo = cboTipoUso.SelectedValue
        MSTRProductosUrea.DSCboTipoUsoSuelo_FrmQRY(CentroCod, UsoTipo, cboProductos)

        If cboProductos.Text = "" Then
            txtSaldoUrea.Text = 0
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    'Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
    '    GraficoUreaAcumuladaMes()
    '    GraficoUreaAcumuladaPeriodoAnual()
    'End Sub
End Class