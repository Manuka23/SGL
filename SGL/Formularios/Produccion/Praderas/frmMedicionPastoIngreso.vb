Imports System.Data.SqlClient

Public Class frmMedicionPastoIngreso

    Public Param1_Llamada As Integer = 0    '0=llamada desde menu / 1=llamada desde ingreso leche
    ''
    Private DiasTratamiento As Integer = 0
    Private CoberturaAnterior As Integer
    ''
    Private NroPotreros As Integer
    Private NroPotrerosAnt As Integer
    Private PotreroInicial As String
    Private PotreroFinal As String
    ''
    Private EnEventoLoad As Boolean = True
    Private ExistenRegistros As Boolean = False
    Private SinMedicion As Integer = 0
    Private Const COL_POTREROCOD As Integer = 0
    Private Const COL_HECTAREAS As Integer = 1
    Private Const COL_COBERTURA As Integer = 7
    Private Const COL_FECANTERIOR As Integer = 8
    Private Const COL_COBANTERIOR As Integer = 9
    Private Const COL_HECTANTERIOR As Integer = 10
    Private Const COL_CRECIDIARIO As Integer = 11
    Private Const COL_CRECIDIARIO_HA As Integer = 12



    'creamos variable de tipo PrintDocument para imprimir los dos graficos en una sola hoja
    Friend WithEvents PrintDoc As New Printing.PrintDocument

    Private GuardaCobertura As String = ""
    Private GuardaLinbea As Integer

    Private CentroCod As Integer = 0

    Private Sub frmMedicionPastoIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 5
        WebBrowser.Dock = DockStyle.Fill

        dtpFecha.Value = Now

        MSTRUsuarios.DSCboUsuarioCentros_FrmINS(True, cboCentros)
        cboCentros.Text = UsuarioCentroNomDefault
        CentroCod = UsuarioCentroCodDefault

        chkIngresoCalculado.Checked = True

        btnMin1.Visible = False
        btnMin2.Visible = False

        EnEventoLoad = False


    End Sub
    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboCentros.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then CentroCod = selectedRow("CentroCod")

        If EnEventoLoad Then Exit Sub

        BuscarMediciones()
        For i = 0 To dgvMP_POTREROS.Rows.Count - 1
            For x = 0 To 13 - 1
                If dgvMP_POTREROS.Rows(i).Cells(13).Value = 2 Then
                    dgvMP_POTREROS.Rows(i).Cells(x).Style.BackColor = Color.Orange
                    dgvMP_POTREROS.Rows(i).Cells(x).ReadOnly = True
                End If
            Next
        Next
    End Sub
    Private Sub tabPASTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabPASTO.SelectedIndexChanged
        'Si cambia a la pestaña del Mapa, ahi se carga el MAPA.
        If tabPASTO.TabPages(tabPASTO.SelectedIndex).Name.Contains("2") Then BuscarArchivoMapa(True)
    End Sub

    Private Function CalculoCobertura(ByVal mi As String, ByVal mf As String, ByVal cl As String, ByVal p1 As String, ByVal p2 As String) As Integer
        CalculoCobertura = 0
        Try
            CalculoCobertura = Math.Round(((((mf - mi) / cl) * txtPEstacional.Text) + txtPFijo.Text), 0)
        Catch ex As Exception
        End Try
    End Function
    Private Sub BuscarMedicionesAnteriores(Optional ByVal ValidaCrecimientoHa As Boolean = True)
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spPraderas_BuscarMedicionesAnteriores", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim i As Integer = 0
            Dim cob, cobant, suma_cob, suma_cobant, ha, haant, suma_ha, suma_haant, resta, creci, creci_ha, suma_creci, suma_hacreci As Double
            Dim cob_dia, cobant_dia, diff_dias, creci_dia As Integer
            Dim feccob, feccobant As Date
            Dim PotreroCod As String = ""
            NroPotreros = 0
            NroPotrerosAnt = 0
            ''
            suma_cob = 0
            suma_cobant = 0
            suma_ha = 0
            suma_haant = 0
            suma_creci = 0
            ''

            ''
            cob_dia = 0
            cobant_dia = 0
            ExistenRegistros = False

            While rdr.Read()
                PotreroCod = rdr("Potrero")
                Dim lin As Integer = -1
                For j = 0 To dgvMP_POTREROS.Rows.Count - 1
                    If PotreroCod.Trim = dgvMP_POTREROS.Rows(j).Cells(COL_POTREROCOD).Value Then
                        lin = j
                        Exit For
                    End If
                Next

                If lin <> -1 Then
                    ha = rdr("Ha")
                    haant = rdr("HaAnterior")
                    cob = rdr("Cobertura")
                    cobant = rdr("CobAnterior")
                    feccobant = rdr("FecCobAnterior")
                    feccob = rdr("FecCob")

                    suma_cob += (cob * ha)
                    suma_cobant += (cobant * haant)

                    If cob > 0 Then suma_ha += ha
                    If cobant > 0 Then suma_haant += haant
                    If cob > 0 Then NroPotreros += 1
                    If feccobant <> Nothing Then
                        ''calculo para crecimiento
                        resta = cob - cobant

                        If resta > 0 And cobant > 0 Then

                            diff_dias = DateDiff(DateInterval.Day, feccobant, feccob)

                            If diff_dias > 0 Then
                                creci = (resta / diff_dias) * ha
                                creci_ha = creci / ha
                                suma_creci += creci
                                suma_hacreci += ha

                                If ValidaCrecimientoHa = False Then
                                    dgvMP_POTREROS.Rows(lin).Cells(COL_CRECIDIARIO).Value = Math.Round(creci, 0).ToString.Trim
                                    dgvMP_POTREROS.Rows(lin).Cells(COL_CRECIDIARIO_HA).Value = Math.Round(creci_ha, 0).ToString.Trim
                                Else
                                    If creci_ha <= 150 Then
                                        dgvMP_POTREROS.Rows(lin).Cells(COL_CRECIDIARIO).Value = Math.Round(creci, 0).ToString.Trim
                                        dgvMP_POTREROS.Rows(lin).Cells(COL_CRECIDIARIO_HA).Value = Math.Round(creci_ha, 0).ToString.Trim
                                    Else
                                        If lin = GuardaLinbea Then
                                            MsgBox("EL CRECIMIENTO POR HECTAREA NO PUEDE SER MAYOR A 150", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                                            dgvMP_POTREROS.Rows(lin).Cells(COL_COBERTURA).Value = GuardaCobertura
                                            Exit Sub
                                        End If

                                    End If
                                End If
                            End If
                        Else
                            dgvMP_POTREROS.Rows(lin).Cells(COL_CRECIDIARIO).Value = 0
                            dgvMP_POTREROS.Rows(lin).Cells(COL_CRECIDIARIO_HA).Value = 0
                        End If

                    End If
                End If
                i = i + 1

            End While

            rdr.Close()
            cmd.Dispose()
            con.Close()
            Try

                cob_dia = Math.Round(suma_cob / suma_ha, 0)
                cobant_dia = Math.Round(suma_cobant / suma_haant, 0)
                creci_dia = Math.Round(suma_creci / suma_hacreci, 0)
            Catch ex As Exception
            End Try

            If cob_dia < 0 Then cob_dia = 0
            If cobant_dia < 0 Then cobant_dia = 0
            If creci_dia < 0 Then creci_dia = 0

            'mostramos totales
            lblNroPotreros.Text = i.ToString + "  (" + NroPotreros.ToString + ")"
            lblTotalCobertura.Text = cob_dia.ToString
            lblTotalAnterior.Text = cobant_dia.ToString
            txtCreciDiario.Text = creci_dia.ToString.Trim

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        btnGrabar.Enabled = True
        btnEliminar.Enabled = True

        Cursor.Current = Cursors.WaitCursor

    End Sub

    Private Sub CalculoTotales(Optional ByVal ValidaCrecimientoHa As Boolean = True)
        Dim i As Integer
        Dim cob, cobant, suma_cob, suma_cobant, ha, haant, suma_ha, suma_haant, resta, creci, creci_ha, suma_creci, suma_hacreci As Double
        Dim cob_dia, cobant_dia, diff_dias, creci_dia As Integer
        Dim feccob, feccobant As Date

        NroPotreros = 0
        NroPotrerosAnt = 0
        ''
        suma_cob = 0
        suma_cobant = 0
        suma_ha = 0
        suma_haant = 0
        suma_creci = 0
        ''
        feccob = dtpFecha.Value.Date
        ''
        cob_dia = 0
        cobant_dia = 0

        For i = 0 To dgvMP_POTREROS.Rows.Count - 1
            ha = dgvMP_POTREROS.ToDouble(i, COL_HECTAREAS)
            haant = dgvMP_POTREROS.ToDouble(i, COL_HECTANTERIOR)
            cob = dgvMP_POTREROS.ToDouble(i, COL_COBERTURA)
            cobant = dgvMP_POTREROS.ToDouble(i, COL_COBANTERIOR)
            feccobant = dgvMP_POTREROS.ToDate(i, COL_FECANTERIOR)

            suma_cob += (cob * ha)
            suma_cobant += (cobant * haant)

            If cob > 0 Then suma_ha += ha
            If cobant > 0 Then suma_haant += haant
            If cob > 0 Then NroPotreros += 1

            If feccobant = Nothing Then Continue For
            ''calculo para crecimiento
            resta = cob - cobant

            If resta > 0 And cobant > 0 Then
                'feccobant = dgvPOTREROS.Rows(i).Cells(COL_FECANTERIOR).Value     'fecha cobertura anterior
                diff_dias = DateDiff(DateInterval.Day, feccobant, feccob)

                If diff_dias > 0 Then
                    creci = (resta / diff_dias) * ha     'Math.Round((resta / diff_dias), 0) * ha
                    creci_ha = creci / ha
                    suma_creci += creci
                    suma_hacreci += ha

                    If ValidaCrecimientoHa = False Then
                        dgvMP_POTREROS.Rows(i).Cells(COL_CRECIDIARIO).Value = Math.Round(creci, 0).ToString.Trim
                        dgvMP_POTREROS.Rows(i).Cells(COL_CRECIDIARIO_HA).Value = Math.Round(creci_ha, 0).ToString.Trim
                    Else
                        If creci_ha <= 150 Then
                            dgvMP_POTREROS.Rows(i).Cells(COL_CRECIDIARIO).Value = Math.Round(creci, 0).ToString.Trim
                            dgvMP_POTREROS.Rows(i).Cells(COL_CRECIDIARIO_HA).Value = Math.Round(creci_ha, 0).ToString.Trim
                        Else
                            If i = GuardaLinbea Then
                                MsgBox("EL CRECIMIENTO POR HECTAREA NO PUEDE SER MAYOR A 150", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                                dgvMP_POTREROS.Rows(i).Cells(COL_COBERTURA).Value = GuardaCobertura
                                Exit Sub
                            End If

                        End If
                    End If
                End If
            Else
                dgvMP_POTREROS.Rows(i).Cells(COL_CRECIDIARIO).Value = 0
                dgvMP_POTREROS.Rows(i).Cells(COL_CRECIDIARIO_HA).Value = 0
            End If
        Next

        'calculamos coberturas dentro de un try por si hay errores (divicion por cero)
        Try

            cob_dia = Math.Round(suma_cob / suma_ha, 0)
            cobant_dia = Math.Round(suma_cobant / suma_haant, 0)
            creci_dia = Math.Round(suma_creci / suma_hacreci, 0)
        Catch ex As Exception
        End Try

        If cob_dia < 0 Then cob_dia = 0
        If cobant_dia < 0 Then cobant_dia = 0
        If creci_dia < 0 Then creci_dia = 0

        'mostramos totales
        lblNroPotreros.Text = i.ToString + "  (" + NroPotreros.ToString + ")"
        lblTotalCobertura.Text = cob_dia.ToString
        lblTotalAnterior.Text = cobant_dia.ToString
        txtCreciDiario.Text = creci_dia.ToString.Trim

    End Sub

    Private Sub TrazaLineaTarjet()
        'ChartCobDia.Series(1).Points.Clear()
        chartUltMedPasto.Series(1).Points.Clear()

        Try
            Dim pre As Double = Convert.ToInt32(txtPreGrazing.Text)
            Dim post As Double = Convert.ToInt32(txtPostGrazing.Text)
            ''
            Dim rest As Double = pre - post
            Dim num As Double = rest / NroPotreros

            For i = 0 To NroPotreros - 1
                'ChartCobDia.Series(1).Points.AddY(pre)
                chartUltMedPasto.Series(1).Points.AddY(pre)
                pre = pre - num
            Next

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BuscarMediciones()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spPraderas_BuscarMediciones", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim i As Integer = 0
            Dim mi, mf, cl, p1, p2, cob_, cobant_, fecant, haant As String
            Dim tarjet_pre, tarjet_post, tarjet_preant, tarjet_postant As Integer

            dgvMP_POTREROS.Rows.Clear()
            ExistenRegistros = False

            While rdr.Read()
                If rdr("MPastUsuario").ToString <> "" Then ExistenRegistros = True
                Dim po As String = rdr("PotreroCod")
                mf = IIf(rdr("MPastFinal") = "0", "", rdr("MPastFinal"))
                mi = IIf(rdr("MPastInicial") = "0", "", rdr("MPastInicial"))
                cl = IIf(rdr("MPastClicks") = "0", "", rdr("MPastClicks"))
                p1 = IIf(rdr("MPastParam1") = "0", "", rdr("MPastParam1"))
                p2 = IIf(rdr("MPastParam2") = "0", "", rdr("MPastParam2"))
                cob_ = IIf(rdr("MPastCobertura") = "0", "", rdr("MPastCobertura"))
                cobant_ = IIf(rdr("MPastCobAnterior") = "0", "", rdr("MPastCobAnterior"))
                fecant = IIf(FechaCorrecta(rdr("MPastFecCobAnterior")) = False, "", rdr("MPastFecCobAnterior"))
                haant = IIf(rdr("MPastHaAnterior") = "0", "", rdr("MPastHaAnterior"))
                CoberturaAnterior = rdr("MPastCobAnterior")

                If Not IsDBNull(rdr("MPastTarjetPre")) Then
                    If rdr("MPastTarjetPre") > 0 Then
                        tarjet_pre = rdr("MPastTarjetPre")
                    End If
                End If

                If Not IsDBNull(rdr("MPastTarjetPost")) Then
                    If rdr("MPastTarjetPost") > 0 Then
                        tarjet_post = rdr("MPastTarjetPost")
                    End If
                End If

                If Not IsDBNull(rdr("MPastTarjetPreAnterior")) Then
                    If rdr("MPastTarjetPreAnterior") > 0 Then
                        tarjet_preant = rdr("MPastTarjetPreAnterior")
                    End If
                End If

                If Not IsDBNull(rdr("MPastTarjetPostAnterior")) Then
                    If rdr("MPastTarjetPostAnterior") > 0 Then
                        tarjet_postant = rdr("MPastTarjetPostAnterior")
                    End If
                End If
                SinMedicion = rdr("SinMedicion")

                dgvMP_POTREROS.Rows.Add(rdr("PotreroCod"), rdr("PotreroSuperficie"), mi, mf, cl, p1, p2, cob_, fecant, cobant_, haant, "0", "0", rdr("PotreroTipo"))

                i = i + 1
            End While

            rdr.Close()
            cmd.Dispose()
            con.Close()

            txtPreGrazing.Text = IIf(tarjet_pre = 0, tarjet_preant, tarjet_pre)
            txtPostGrazing.Text = IIf(tarjet_post = 0, tarjet_postant, tarjet_post)

            If txtPreGrazing.Text = 0 Then 'En caso de que el valor desde la base de datos sigue siendo cero definimos los valores estandar
                txtPreGrazing.Text = 3000
            End If

            If txtPostGrazing.Text = 0 Then
                txtPostGrazing.Text = 1800
            End If

            'realizamos calculos en primer lugar, ya que ocupamos la cobertura actual en el titulo del grafico diario
            CalculoTotales(False)
            If SinMedicion = 1 Then
                BuscarMedicionesAnteriores(False)
            End If

            BuscarCoberturasDia()
            BuscarCoberturasUlt12Meses()
            BuscarCrecimientosDiarioUlt12Meses()

            TrazaLineaTarjet()


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        btnGrabar.Enabled = True
        btnEliminar.Enabled = True

        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub BuscarArchivoMapa(Optional ByVal CargarMapa As Boolean = False)
        If CargarMapa = False Then Exit Sub

        lblErrNomArchivo.Visible = False
        lblErrNomArchivo.Text = "No se encuentra el mapa para el predio seleccionado (" + cboCentros.Text + ")"


        If General.MapFile(CentroCod, WebBrowser) = False Then
            lblErrNomArchivo.Visible = True
        End If

    End Sub

    Private Sub BuscarCoberturasDia()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spPraderas_ListadoMedicionesDia_Pastoreo", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            chartUltMedPasto.Series("Series1").Points.Clear()
            chartUltMedPasto.Series("Series1").Points.DataBindXY(rdr, "PotreroCod", rdr, "MPastCobertura")

            rdr.Close()
            cmd.Dispose()
            con.Close()
            '
            con.Open()
            rdr = cmd.ExecuteReader()
            rdr.Read()
            If rdr.Read() = True Then

                If rdr("Existe") = 1 Then
                    chartUltMedPasto.Titles(0).Text = "Cobertura de Pasto a la Fecha " + Format(rdr("Mpastfecha"), "dd-MM-yyyy") + " " + cboCentros.Text + vbNewLine + " (COBERTURA: " + lblTotalCobertura.Text + " - CRECIMIENTO: " + txtCreciDiario.Text + ")" ' + " (" + lblTotalCobertura.Text + ")"

                Else
                    chartUltMedPasto.Titles(0).Text = "Última Cobertura de Pasto " + cboCentros.Text + " " + Format(rdr("Mpastfecha"), "dd-MM-yyyy") + vbNewLine + " (COBERTURA: " + lblTotalCobertura.Text + " - CRECIMIENTO: " + txtCreciDiario.Text + ")" ' + " (" + lblTotalCobertura.Text + ")"

                End If
            End If
            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub BuscarCoberturasUlt12Meses()
        Cursor.Current = Cursors.WaitCursor
        chartMedPasto12Meses.Titles(0).Text = "Cobertura de Pasto " + cboCentros.Text + " 12 Meses" + vbNewLine + " (COBERTURA ACTUAL: " + lblTotalCobertura.Text + " - CRECIMIENTO: " + txtCreciDiario.Text + ")"

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spPraderas_ListadoCoberturasUlt12Meses", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            chartMedPasto12Meses.Series("Series1").Points.Clear()
            chartMedPasto12Meses.Series("Series1").Points.DataBindXY(rdr, "MPastFecha", rdr, "MPastTotalCobertura")

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub BuscarCrecimientosDiarioUlt12Meses()
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Try

            Dim cmd As New SqlCommand("spPraderas_ListadoCrecimientosUlt12Meses", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            chartMedPasto12Meses.Series("Series2").Points.Clear()

            ' While rdr.Read()
            'ChartCobMes.Series("Series2").Points.AddXY(rdr("MPastFecha"), rdr("TotCrecimientoDiario"))
            chartMedPasto12Meses.Series("Series2").Points.DataBindXY(rdr, "MPastFecha", rdr, "TotCrecimientoDiario")
            'End While

            rdr.Close()
            'cmd.Dispose()
            'con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub


    Private Function GrabarMediciones() As Boolean
        GrabarMediciones = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_GrabarMedicion", con)
        'Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE RETIRO
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        Dim i As Integer = 0
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean
        Dim mi, mf, clicks As Integer
        Dim cob As Double

        For i = 0 To dgvMP_POTREROS.Rows.Count - 1
            'verificamos que se ingrese un valor de cobertura
            mi = 0
            mf = 0
            clicks = 0
            cob = 0


            If Not dgvMP_POTREROS.Rows(i).Cells(2).Value Is Nothing Then If dgvMP_POTREROS.Rows(i).Cells(2).Value.ToString.Trim <> "" Then mi = Int32.Parse(dgvMP_POTREROS.Rows(i).Cells(2).Value)
            If Not dgvMP_POTREROS.Rows(i).Cells(3).Value Is Nothing Then If dgvMP_POTREROS.Rows(i).Cells(3).Value.ToString.Trim <> "" Then mf = Int32.Parse(dgvMP_POTREROS.Rows(i).Cells(3).Value)
            If Not dgvMP_POTREROS.Rows(i).Cells(4).Value Is Nothing Then If dgvMP_POTREROS.Rows(i).Cells(4).Value.ToString.Trim <> "" Then clicks = Int32.Parse(dgvMP_POTREROS.Rows(i).Cells(4).Value)
            If Not dgvMP_POTREROS.Rows(i).Cells(COL_COBERTURA).Value Is Nothing Then If dgvMP_POTREROS.Rows(i).Cells(COL_COBERTURA).Value.ToString.Trim <> "" Then cob = Double.Parse(dgvMP_POTREROS.Rows(i).Cells(COL_COBERTURA).Value)


            'If cob > 0 Then ' mi > 0 And mf > 0 And clicks > 0 Then
            cmd.Parameters.Clear()
            'cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Potrero", dgvMP_POTREROS.Rows(i).Cells(0).Value)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@MI", mi)
            cmd.Parameters.AddWithValue("@MF", mf)
            cmd.Parameters.AddWithValue("@Clicks", clicks)
            cmd.Parameters.AddWithValue("@Param1", Int32.Parse(txtPEstacional.Text))
            cmd.Parameters.AddWithValue("@Param2", Int32.Parse(txtPFijo.Text))
            cmd.Parameters.AddWithValue("@Cobertura", cob)
            cmd.Parameters.AddWithValue("@NroPotreros", NroPotreros)
            cmd.Parameters.AddWithValue("@TarjetPre", txtPreGrazing.Text)
            cmd.Parameters.AddWithValue("@TarjetPost", txtPostGrazing.Text)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            '
            cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

            Try
                cmd.Transaction = SRVTRANS
                Result = cmd.ExecuteNonQuery()

                vret = cmd.Parameters("@RetValor").Value
                mret = cmd.Parameters("@RetMensage").Value

                ''verificamos error con un valor igual a -1
                If vret <> 0 Then
                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If

                    HayError = True
                    Exit For
                End If

                HayError = False
                ''si todo sale ok guardamos el nuevo codigo del grupo de celos
                'GrabarGrupoParto = True

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                HayError = True
                Exit For
            End Try
            ''End If
        Next

        'si hay error hasta aqui salimos
        If HayError = False Then
            SRVTRANS.Commit()
            GrabarMediciones = True
            'ExisteIngresoRetiro = True

            'como se grabo ok, actualizamo los dos primeros campos, de retiro
            'For i = 0 To dgvRetiroLeche.Rows.Count - 1
            '    dgvRetiroLeche.Rows(i).Cells(0).Value = dgvRetiroLeche.Rows(i).Cells(3).Value
            '    dgvRetiroLeche.Rows(i).Cells(1).Value = dgvRetiroLeche.Rows(i).Cells(4).Value
            'Next
        Else
            SRVTRANS.Rollback()
            GrabarMediciones = False
            'ExisteIngresoRetiro = False
        End If

        'SumaLitrosRetiro()

        con.Close()
        Cursor.Current = Cursors.Default
    End Function


    Private Function EliminarMediciones() As Boolean
        EliminarMediciones = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_EliminarMediciones", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
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

            EliminarMediciones = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub dgvPOTREROS_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvMP_POTREROS.CellBeginEdit

        GuardaCobertura = dgvMP_POTREROS.Rows(e.RowIndex).Cells(COL_COBERTURA).Value
        GuardaLinbea = e.RowIndex

    End Sub



    Private Sub dgvPOTREROS_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMP_POTREROS.CellEndEdit
        Dim mi, mf, cl, scob_ As String

        If Not chkIngresoCalculado.Checked Then
            Try
                mi = dgvMP_POTREROS.Rows(e.RowIndex).Cells(2).Value.ToString
                mf = dgvMP_POTREROS.Rows(e.RowIndex).Cells(3).Value.ToString
                cl = dgvMP_POTREROS.Rows(e.RowIndex).Cells(4).Value.ToString

                Dim cob_ As Double = CalculoCobertura(mi, mf, cl, "", "")
                scob_ = cob_ 'Math.Round(cob_, 0)
                dgvMP_POTREROS.Rows(e.RowIndex).Cells(COL_COBERTURA).Value = scob_
            Catch ex As Exception
                'si hay error dejamos campo cobertura en blanco
            End Try
        End If


        CalculoTotales(True)
        If PastoreoConsumo() = False Then
            dgvMP_POTREROS.CurrentCell.Value = ""
        End If
    End Sub

    '*******************************************************************************************************************************************************************************************************
    '*******************************************************************************************************************************************************************************************************
    Private Sub dgvPOTREROS_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvMP_POTREROS.EditingControlShowing

        Dim col As Integer = dgvMP_POTREROS.CurrentCell.ColumnIndex

        'valida keypress (medida ini, final, clicks y cobertura)
        If col = 2 Or col = 3 Or col = 4 Or col = 7 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtRetiro
        End If
    End Sub

    Private Sub ValidaTxtRetiro(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvMP_POTREROS.CurrentCell.ColumnIndex

        'valida keypress (medida ini, final, clicks y cobertura)
        If columna = 2 Or columna = 3 Or columna = 4 Or columna = 7 Then
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub
    '*******************************************************************************************************************************************************************************************************
    '*******************************************************************************************************************************************************************************************************



    Private Function ValidacionLocal() As Boolean
        ValidacionLocal = False

        Dim i As Integer
        Dim con_datos As Boolean = False

        For i = 0 To dgvMP_POTREROS.Rows.Count - 1
            If dgvMP_POTREROS.ToDouble(i, COL_COBERTURA) > 0 Then
                con_datos = True
                Exit For
            End If
        Next

        ValidacionLocal = con_datos
    End Function



    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click


        If ValidacionLocal() = False Then
            If MsgBox("DEBE INGRESAR DATOS", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACIÓN") <> MsgBoxResult.Ok Then
            End If
            Exit Sub
        End If

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LOS DATOS DE MEDICIONES ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarMediciones() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If

            'realizamos calculos en primer lugar, ya que ocupamos la cobertura actual en el titulo del grafico diario
            CalculoTotales(False)
            BuscarCoberturasDia()
            BuscarCoberturasUlt12Meses()
            BuscarCrecimientosDiarioUlt12Meses()

            TrazaLineaTarjet()
        End If
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        If EnEventoLoad Then Exit Sub
        BuscarMediciones()
        For i = 0 To dgvMP_POTREROS.Rows.Count - 1
            For x = 0 To 13 - 1
                If dgvMP_POTREROS.Rows(i).Cells(13).Value = 2 Then
                    dgvMP_POTREROS.Rows(i).Cells(x).Style.BackColor = Color.Orange
                    dgvMP_POTREROS.Rows(i).Cells(x).ReadOnly = True

                End If

            Next
        Next
    End Sub

    Private Sub txtNroPotrero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnImprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprime.Click
        If gboxIngMediciones.Visible = True Then
            PrintPreviewDialog.Document = PrintDoc
            PrintPreviewDialog.Document.DefaultPageSettings.Landscape = True
            PrintPreviewDialog.ShowDialog()
        Else
            If chartUltMedPasto.Visible = True Then
                chartUltMedPasto.Printing.PrintDocument.DefaultPageSettings.Landscape = True
                chartUltMedPasto.Printing.PrintPreview()   ' .Print(True)
            Else
                chartMedPasto12Meses.Printing.PrintDocument.DefaultPageSettings.Landscape = True
                chartMedPasto12Meses.Printing.PrintPreview()   ' .Print(True)
            End If
        End If
    End Sub


    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage

        Dim g As Graphics
        g = e.Graphics

        'archivos temporales que contendran las imagenes en formato .png
        Dim f1, f2 As String
        f1 = IO.Path.GetTempFileName() : chartUltMedPasto.SaveImage(f1, Imaging.ImageFormat.Bmp)
        f2 = IO.Path.GetTempFileName() : chartMedPasto12Meses.SaveImage(f2, Imaging.ImageFormat.Bmp)

        'cargamos imagenes desde los archivos temporales
        Dim newImage1 As Image = Image.FromFile(f1)
        Dim newImage2 As Image = Image.FromFile(f2)

        'dibujamos las imagenes en la hoja de impresion (PrintDocument)
        g.DrawImage(newImage1, 50, 100)
        g.DrawImage(newImage2, 50, newImage1.Height + 150)

        g.Dispose()
        e.HasMorePages = False
    End Sub

    Private Sub chkIngresoCalculado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIngresoCalculado.CheckedChanged
        If chkIngresoCalculado.Checked Then
            dgvMP_POTREROS.Columns(2).Visible = False
            dgvMP_POTREROS.Columns(3).Visible = False
            dgvMP_POTREROS.Columns(4).Visible = False
            dgvMP_POTREROS.Columns(COL_COBERTURA).ReadOnly = False
            dgvMP_POTREROS.Columns(COL_COBERTURA).DefaultCellStyle.BackColor = Color.White
        Else
            dgvMP_POTREROS.Columns(2).Visible = True
            dgvMP_POTREROS.Columns(3).Visible = True
            dgvMP_POTREROS.Columns(4).Visible = True
            dgvMP_POTREROS.Columns(COL_COBERTURA).ReadOnly = True
            dgvMP_POTREROS.Columns(COL_COBERTURA).DefaultCellStyle.BackColor = Color.FromArgb(234, 234, 234)
        End If
    End Sub

    Private Sub ValidaSizeChartDia()

        If gboxIngMediciones.Visible = True Then
            gboxIngMediciones.Visible = False
            chartMedPasto12Meses.Visible = False
            btnMax1.Visible = False
            btnMin1.Visible = True
            btnMax2.Visible = False

            tabPASTO.Left = gboxIngMediciones.Left
            tabPASTO.Width = pnlEstReprod.Width
            chartUltMedPasto.Dock = DockStyle.Fill

            btnMin1.Left = 671 + 405

        Else
            gboxIngMediciones.Visible = True
            chartMedPasto12Meses.Visible = True
            btnMax1.Visible = True
            btnMin1.Visible = False
            btnMax2.Visible = True

            tabPASTO.Left = 413
            tabPASTO.Width = 730
            chartUltMedPasto.Dock = DockStyle.None

            chartUltMedPasto.Left = 3
            chartUltMedPasto.Top = 2
            chartUltMedPasto.Width = 717
            chartUltMedPasto.Height = 232
        End If

        lblErrNomArchivo.Width = TabPage1.Width
    End Sub


    Private Sub ValidaSizeChartMes()
        If gboxIngMediciones.Visible = True Then
            gboxIngMediciones.Visible = False
            chartUltMedPasto.Visible = False
            btnMax2.Visible = False
            btnMin2.Visible = True
            btnMax1.Visible = False
            btnMin2.Top = btnMin1.Top

            tabPASTO.Left = gboxIngMediciones.Left
            tabPASTO.Width = pnlEstReprod.Width
            chartMedPasto12Meses.Dock = DockStyle.Fill

            btnMin2.Left = 671 + 405

            chartMedPasto12Meses.Series(0).Label = "#VAL{N0}"
            chartMedPasto12Meses.Series(1).Label = "#VAL{N0}"
        Else
            gboxIngMediciones.Visible = True
            chartUltMedPasto.Visible = True
            btnMax2.Visible = True
            btnMin2.Visible = False
            btnMax1.Visible = True

            tabPASTO.Left = 413
            tabPASTO.Width = 730
            chartMedPasto12Meses.Dock = DockStyle.None

            chartMedPasto12Meses.Left = 3
            chartMedPasto12Meses.Top = 237
            chartMedPasto12Meses.Width = 717
            chartMedPasto12Meses.Height = 232

            chartMedPasto12Meses.Series(0).Label = ""
            chartMedPasto12Meses.Series(1).Label = ""
        End If

        lblErrNomArchivo.Width = TabPage1.Width
    End Sub

    Private Sub ChartCobMes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chartMedPasto12Meses.DoubleClick
        ValidaSizeChartMes()
    End Sub

    Private Sub txtPreGrazing_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPreGrazing.KeyPress, txtPostGrazing.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            TrazaLineaTarjet()
        End If
    End Sub

    Private Sub chart1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chartUltMedPasto.DoubleClick
        ValidaSizeChartDia()
    End Sub


    Private Sub btnMax1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax1.Click, btnMin1.Click
        ValidaSizeChartDia()
    End Sub

    Private Sub btnMax2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax2.Click, btnMin2.Click
        ValidaSizeChartMes()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        EliminarMedicionesDia()
    End Sub


    Private Sub EliminarMedicionesDia()
        If ExistenRegistros = False Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR LAS MEDICIONES DEL DIA SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            If EliminarMediciones() = True Then
                BuscarMediciones()
            End If
        End If
    End Sub


    Private Sub mnuLimpiarLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLimpiarLinea.Click
        If dgvMP_POTREROS.SelectedCells.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA LIMPIAR LA LINEA DE MEDICIÓN DE PASTO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            For i As Integer = 2 To dgvMP_POTREROS.Columns.Count - 1
                dgvMP_POTREROS.SelectedRows(0).Cells(i).Value = ""
            Next

            CalculoTotales(False)

        End If
    End Sub


    Private Sub dgvPOTREROS_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvMP_POTREROS.CellMouseDown
        'si se presiono el boton derecho del mouse, seleccionamos linea
        If e.Button = Windows.Forms.MouseButtons.Right Then

            dgvMP_POTREROS.CurrentCell = dgvMP_POTREROS.Rows(e.RowIndex).Cells(e.ColumnIndex)
            dgvMP_POTREROS.Rows(dgvMP_POTREROS.CurrentCell.RowIndex).Selected = True
            dgvMP_POTREROS.Focus()
        End If
    End Sub

    Private Function PastoreoConsumo() As Boolean

        PastoreoConsumo = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_ConfirmarCrecimiento", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Consumo As String = ""
        Dim Potrero As String = ""
        Dim Fecha As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure
        '
        If dgvMP_POTREROS.SelectedCells.Count <> 0 Then
            Consumo = dgvMP_POTREROS.CurrentCell.Value.ToString()
            Potrero = dgvMP_POTREROS.CurrentRow.Cells(0).Value.ToString()
            Fecha = dtpFecha.Value
        End If

        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Consumo", Consumo)
        cmd.Parameters.AddWithValue("@Potrero", Potrero)
        cmd.Parameters.AddWithValue("@FechaHasta", Fecha)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "ERROR DE VALIDACION") = vbYes Then
                Else
                    PastoreoConsumo = False
                    Exit Function
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        PastoreoConsumo = True
    End Function
End Class

