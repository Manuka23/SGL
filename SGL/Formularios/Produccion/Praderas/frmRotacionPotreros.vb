Imports System.Data.SqlClient

Public Class frmRotacionPotreros

    Private ExistenRegistros As Boolean = False
    Private EnEventoLoad As Boolean = True
    Private NroPotConDatos As Integer = 0
    Private NroPotEfectivos As Integer = 0
    '****** declaracion necesaria para la funcion de imprimir documento
    Friend WithEvents PrintDoc As New Printing.PrintDocument

    Private CentroCod As Integer = 0

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmRotacionPotreros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 5
        WebBrowser.Dock = DockStyle.Fill

        dtpFecha.Value = Now

        MSTRUsuarios.DSCboUsuarioCentros_FrmINS(True, cboCentros)
        cboCentros.Text = UsuarioCentroNomDefault
        CentroCod = UsuarioCentroCodDefault

        btnMin1.Visible = False
        btnMin2.Visible = False
        EnEventoLoad = False
        ToolTipText()
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim selectedRow As DataRowView = DirectCast(cboCentros.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then CentroCod = selectedRow("CentroCod")

        If EnEventoLoad Then Exit Sub

        BuscarPastoreos()
    End Sub

    Private Sub ToolTipText()
        Dim TextConsOpt As String, TextConsAct As String, TextRotAct As String, TextTotHasAcum As String, TextTotHasDia As String
        TextConsOpt = "Formula Consumo Diario Óptimo = Total Has. Efec. / Rotación." & vbCrLf & "(Default: 75 días)"
        TextConsAct = "Formula Consumo Diario Actual = Total Has. Efec. / Total Has Acumuladas." & vbCrLf & "(Acumuladas en base al parametro 'Días Acum.'. Default: 7 días acum.)"
        TextRotAct = "Formula Rotación Actual = Total Has. Efec. / (Total Has Acumuladas / Días Acumulados)."
        TextTotHasAcum = "Total Has. Efec. Acumuladas: es la sumatoria de los días acumulados desde la fecha seleccionada hasta X días hacia atrás (X = Parámetro 'Días Acum.')"
        TextTotHasDia = "Total Has. Efec. consumidas del día seleccionado."
        ToolTip1.SetToolTip(grpConsumoOptimo, TextConsOpt)
        ToolTip1.SetToolTip(lblConsumoOptimo, TextConsOpt)
        ToolTip1.SetToolTip(grpConsumoActual, TextConsAct)
        ToolTip1.SetToolTip(lblConsumoActual, TextConsAct)
        ToolTip1.SetToolTip(grpRotacionActual, TextRotAct)
        ToolTip1.SetToolTip(lblRotacionActual, TextRotAct)
        ToolTip1.SetToolTip(grpTotHasAcum, TextTotHasAcum)
        ToolTip1.SetToolTip(lblTotHasAcum, TextTotHasAcum)
        ToolTip1.SetToolTip(grpTotHasDia, TextTotHasDia)
        ToolTip1.SetToolTip(lblTotHasDia, TextTotHasDia)
    End Sub

    Private Sub BuscarPastoreos()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spPraderas_BuscarPastoreos", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@DiasAcum", txtDiasAcum.Text.Trim)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim idx As Integer = 0

            Dim tarjet_pre, tarjet_post As Integer
            Dim suma_hEfect, suma_acum, suma_totha, suma_tothapas As Double

            NroPotConDatos = 0
            NroPotEfectivos = 0

            dgvRP_Potreros.Rows.Clear()

            ExistenRegistros = False
            While rdr.Read()
                Dim PotreroSuperficie As Double = rdr("PotreroSuperficie")
                Dim Potrerotipo As Integer = rdr("Potrerotipo")
                Dim MPastoreo As Double = rdr("MPastoreo")
                Dim Pastoreo As String = IIf(rdr("MPastoreo") = "0", "", rdr("MPastoreo"))
                Dim PastoreoAcum As Double = rdr("PastoreoAcum")

                Dim dias_disp, Ensilaje As String
                dias_disp = IIf(rdr("DiasLibres") = "0", "", rdr("DiasLibres"))

                Ensilaje = IIf(rdr("MEnsilaje") = "0", "", rdr("MEnsilaje"))

                dgvRP_Potreros.Rows.Add(rdr("PotreroCod"), PotreroSuperficie, rdr("MpastCobertura"), dias_disp, Pastoreo, Ensilaje, PastoreoAcum, Potrerotipo, rdr("UltimoPastoreo"))

                If tarjet_pre = 0 Then tarjet_pre = 3000
                If tarjet_post = 0 Then tarjet_post = 1500
                If MPastoreo <> 0 Then
                    ExistenRegistros = True
                    NroPotConDatos += 1
                End If
                If Potrerotipo = 1 Then
                    suma_hEfect += PotreroSuperficie
                    NroPotEfectivos += 1
                End If

                If Potrerotipo = 2 Then
                    dgvRP_Potreros.Rows(idx).ReadOnly = True
                    dgvRP_Potreros.Rows(idx).DefaultCellStyle.BackColor = Color.Orange
                End If

                suma_totha += PotreroSuperficie
                suma_tothapas += MPastoreo
                suma_acum += PastoreoAcum

                idx += 1
            End While

            btnEliminar.Enabled = False
            If ExistenRegistros Then
                btnGrabar.Enabled = False
                btnEliminar.Enabled = True
            Else
                btnGrabar.Enabled = True
                btnEliminar.Enabled = False
            End If

            rdr.Close()
            cmd.Dispose()
            con.Close()

            'mostramos totales
            lblNroPotreros.Text = idx.ToString + "  (" + NroPotConDatos.ToString + ")" 'Tot. pot
            lblTotHasEfect.Text = suma_hEfect                                     'Tot Has Efec
            lblTotHasCen.Text = suma_totha                                         'Tot Has
            lblTotHasDia.Text = suma_tothapas                                      'Tot has Dias
            lblTotHasAcum.Text = Format(suma_acum, "#,#0.00")                       'Tot has Dias acum
            Dim RotDias As Double = IIf(txtRotacion.Text = "", 0, CDbl(txtRotacion.Text))
            CalculoPastoreo(suma_totha, RotDias, suma_acum)

            'CalculoTotales()

            GraficoBuscarCoberturasDia()
            GraficoBuscarDiasLibresPotreros()

            TrazaLineaTarjet()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA - BUSCAR DATOS")
        Finally

        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub


    Private Sub CalculoPastoreo(ByVal TotHa As Double, ByVal Rotacion As Double, ByVal TotHaAcum As Double)
        If Rotacion > 0 Then
            lblConsumoOptimo.Text = Format(TotHa / Rotacion, "#,#0.00") & " Ha"  'Total Consumo diario
        Else
            lblConsumoOptimo.Text = "0" & " Ha"
        End If
        If TotHaAcum > 0 Then
            lblConsumoActual.Text = Format(TotHa / TotHaAcum, "#,#0.00") & " Ha" 'Calculo Consumo Actual
            lblRotacionActual.Text = Format((TotHa / (TotHaAcum / txtDiasAcum.Text)), "#,#0") & " Días" 'Calculo Rotacion Actual
        Else
            lblConsumoActual.Text = "0" & " Ha"    'Cons Diario Act
            lblRotacionActual.Text = "0" & " Días"  'Rotacion actual
        End If

    End Sub

    Private Sub TrazaLineaTarjet()

        chartRP_UltCobertura.Series(1).Points.Clear()

        Try
            Dim pre As Double = Convert.ToInt32(txtPreGrazing.Text)
            Dim post As Double = Convert.ToInt32(txtPostGrazing.Text)
            ''
            Dim rest As Double = pre - post
            Dim num As Double = rest / NroPotEfectivos

            For i = 0 To NroPotEfectivos - 1
                chartRP_UltCobertura.Series(1).Points.AddY(pre)
                pre -= num
            Next

        Catch ex As Exception
        End Try
    End Sub
    Private Sub GraficoBuscarCoberturasDia()
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

            chartRP_UltCobertura.Series("Series1").Points.Clear()
            chartRP_UltCobertura.Series("Series1").Points.DataBindXY(rdr, "PotreroCod", rdr, "MPastCobertura")

            rdr.Close()
            cmd.Dispose()
            con.Close()

            con.Open()
            rdr = cmd.ExecuteReader()
            rdr.Read()
            If rdr.Read() = True Then
                chartRP_UltCobertura.Titles(0).Text = "Última Cobertura de Pasto " + cboCentros.Text + " del " + Format(rdr("Mpastfecha"), "dd-MM-yyyy")
            End If
            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub GraficoBuscarDiasLibresPotreros()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spPraderas_ListadoDiasLibresPotreros", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()


            chartDiasLibrexPotrero.Titles(0).Text = "Dias Libres por Potrero " + cboCentros.Text + " al " + Format(dtpFecha.Value, "dd-MM-yyyy")
            chartDiasLibrexPotrero.Series("Series1").Points.Clear()
            chartDiasLibrexPotrero.Series("Series1").Points.DataBindXY(rdr, "PotreroCod", rdr, "DiasLibres")

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

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

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Dim selectedRow As DataRowView = DirectCast(cboCentros.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then CentroCod = selectedRow("CentroCod")
        If EnEventoLoad Then Exit Sub
        ExistenRegistros = False
        BuscarPastoreos()
    End Sub

    Private Sub btnMax1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ValidaSizeChartDia()
    End Sub

    Private Sub btnMax2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ValidaSizeChartMes()
    End Sub
    Private Sub btnMin2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ValidaSizeChartMes()
    End Sub

    Private Sub btnMin1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ValidaSizeChartDia()
    End Sub

    Private Sub ValidaSizeChartDia()
        If gboxIngMediciones.Visible = True Then
            gboxIngMediciones.Visible = False
            chartDiasLibrexPotrero.Visible = False
            btnMax1.Visible = False
            btnMin1.Visible = True
            btnMax2.Visible = False

            tabPASTO.Left = gboxIngMediciones.Left
            tabPASTO.Width = pnlEstReprod.Width
            chartRP_UltCobertura.Dock = DockStyle.Fill

            btnMin1.Left = 671 + 405

        Else
            gboxIngMediciones.Visible = True
            chartDiasLibrexPotrero.Visible = True
            btnMax1.Visible = True
            btnMin1.Visible = False
            btnMax2.Visible = True

            tabPASTO.Left = 490
            tabPASTO.Width = 730
            chartRP_UltCobertura.Dock = DockStyle.None

            chartRP_UltCobertura.Left = 3
            chartRP_UltCobertura.Top = 2
            chartRP_UltCobertura.Width = 717
            chartRP_UltCobertura.Height = 232
        End If

        lblErrNomArchivo.Width = TabPage1.Width
    End Sub
    Private Sub ValidaSizeChartMes()
        If gboxIngMediciones.Visible = True Then
            gboxIngMediciones.Visible = False
            chartRP_UltCobertura.Visible = False
            btnMax2.Visible = False
            btnMin2.Visible = True
            btnMax1.Visible = False
            btnMin2.Top = btnMin1.Top


            tabPASTO.Left = gboxIngMediciones.Left
            tabPASTO.Width = pnlEstReprod.Width
            chartDiasLibrexPotrero.Dock = DockStyle.Fill

            btnMin2.Left = 671 + 405
        Else
            gboxIngMediciones.Visible = True
            chartRP_UltCobertura.Visible = True
            btnMax2.Visible = True
            btnMin2.Visible = False
            btnMax1.Visible = True

            tabPASTO.Left = 490
            tabPASTO.Width = 730
            chartDiasLibrexPotrero.Dock = DockStyle.None

            chartDiasLibrexPotrero.Left = 3
            chartDiasLibrexPotrero.Top = 237
            chartDiasLibrexPotrero.Width = 717
            chartDiasLibrexPotrero.Height = 232
        End If

        lblErrNomArchivo.Width = TabPage1.Width
    End Sub

    Private Sub btnMax1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax1.Click
        ValidaSizeChartDia()
    End Sub

    Private Sub btnMin1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin1.Click
        ValidaSizeChartDia()
    End Sub

    Private Sub btnMax2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax2.Click
        ValidaSizeChartMes()
    End Sub

    Private Sub btnMin2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMin2.Click
        ValidaSizeChartMes()
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ Desea Grabar Los Datos de Pastoreo ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarPastoreo() = True Then
            If MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
            BuscarPastoreos()
        End If

    End Sub
    Private Function GrabarPastoreo() As Boolean
        GrabarPastoreo = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_GrabarPastoreo", con)
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

        Dim linOk As Integer
        Dim consumo, ensilaje, conschk As Double

        linOk = 0
        'Verificar que al menos 1 tenga un dato
        For j = 0 To dgvRP_Potreros.Rows.Count - 1
            conschk = 0
            If Not dgvRP_Potreros.Rows(j).Cells(4).Value Is Nothing And dgvRP_Potreros.Rows(j).Cells(4).Value <> "" Then conschk = Convert.ToDouble(dgvRP_Potreros.Rows(j).Cells(4).Value)
            If Not dgvRP_Potreros.Rows(j).Cells(5).Value Is Nothing And dgvRP_Potreros.Rows(j).Cells(5).Value <> "" Then conschk = Convert.ToDouble(dgvRP_Potreros.Rows(j).Cells(5).Value)
            If conschk > 0 Then
                linOk += 1
            End If
            If linOk > 0 Then
                Exit For
            End If
        Next

        If linOk = 0 Then
            MsgBox("No ha ingresado datos. Debe ingresar información de al menos 1 potrero.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            Exit Function
        End If
        For i = 0 To dgvRP_Potreros.Rows.Count - 1

            consumo = 0
            ensilaje = 0
            If Not dgvRP_Potreros.Rows(i).Cells(4).Value Is Nothing And dgvRP_Potreros.Rows(i).Cells(4).Value <> "" Then consumo = Convert.ToDouble(dgvRP_Potreros.Rows(i).Cells(4).Value)
            If Not dgvRP_Potreros.Rows(i).Cells(5).Value Is Nothing And dgvRP_Potreros.Rows(i).Cells(5).Value <> "" Then ensilaje = Convert.ToDouble(dgvRP_Potreros.Rows(i).Cells(5).Value)
            cmd.Parameters.Clear()

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Potrero", dgvRP_Potreros.Rows(i).Cells(0).Value)
            cmd.Parameters.AddWithValue("@HA", dgvRP_Potreros.Rows(i).Cells(1).Value)
            cmd.Parameters.AddWithValue("@UltCobertura", dgvRP_Potreros.Rows(i).Cells(2).Value)
            cmd.Parameters.AddWithValue("@DiasLibres", dgvRP_Potreros.Rows(i).Cells(3).Value)
            cmd.Parameters.AddWithValue("@Pastoreo", consumo)
            cmd.Parameters.AddWithValue("@Ensilaje", ensilaje)
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
        Next

        'si hay error hasta aqui salimos
        If HayError = False Then
            SRVTRANS.Commit()
            GrabarPastoreo = True

        Else
            SRVTRANS.Rollback()
            GrabarPastoreo = False
        End If

        con.Close()
        Cursor.Current = Cursors.Default
    End Function
    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If CDate(Format(dtpFecha.Value, "dd-MM-yyyy")) > CDate(Format(Now(), "dd-MM-yyyy")) Then
            If MsgBox("Fecha Seleccionada NO puede ser mayor a hoy (" & Format(Today(), "dd-MM-yyyy") & ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If MsgBox("¿DESEA ELIMINAR LAS MEDICIONES DEL DIA SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            If EliminarPastoreo() = True Then
                BuscarPastoreos()
            End If
        End If
    End Sub

    Private Function EliminarPastoreo() As Boolean
        EliminarPastoreo = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_EliminarPastoreo", con)
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

            EliminarPastoreo = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnImprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprime.Click
        If gboxIngMediciones.Visible = True Then
            PrintPreviewDialog.Document = PrintDoc
            PrintPreviewDialog.Document.DefaultPageSettings.Landscape = True
            PrintPreviewDialog.ShowDialog()
        Else
            If chartRP_UltCobertura.Visible = True Then
                chartRP_UltCobertura.Printing.PrintDocument.DefaultPageSettings.Landscape = True
                chartRP_UltCobertura.Printing.PrintPreview()   ' .Print(True)
            Else
                chartDiasLibrexPotrero.Printing.PrintDocument.DefaultPageSettings.Landscape = True
                chartDiasLibrexPotrero.Printing.PrintPreview()   ' .Print(True)
            End If
        End If
    End Sub
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        'e.PageSettings.Landscape = True        'hoja en vertical

        Dim g As Graphics
        g = e.Graphics

        'archivos temporales que contendran las imagenes en formato .png
        Dim f1, f2 As String
        f1 = IO.Path.GetTempFileName() : chartRP_UltCobertura.SaveImage(f1, Imaging.ImageFormat.Bmp)
        f2 = IO.Path.GetTempFileName() : chartDiasLibrexPotrero.SaveImage(f2, Imaging.ImageFormat.Bmp)

        'cargamos imagenes desde los archivos temporales
        Dim newImage1 As Image = Image.FromFile(f1)
        Dim newImage2 As Image = Image.FromFile(f2)

        'dibujamos las imagenes en la hoja de impresion (PrintDocument)
        g.DrawImage(newImage1, 50, 100)
        g.DrawImage(newImage2, 50, newImage1.Height + 150)

        g.Dispose()
        e.HasMorePages = False
    End Sub

    Private Sub txtPreGrazing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPreGrazing.TextChanged
        TrazaLineaTarjet()
    End Sub

    Private Sub txtPostGrazing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPostGrazing.TextChanged
        TrazaLineaTarjet()
    End Sub

    Private Sub tabPASTO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabPASTO.SelectedIndexChanged
        'Si cambia a la pestaña del Mapa, ahi se carga el MAPA.
        If tabPASTO.TabPages(tabPASTO.SelectedIndex).Name.Contains("2") Then BuscarArchivoMapa(True)
    End Sub

    Private Sub txtDiasAcum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasAcum.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            BuscarPastoreos()
        End If
    End Sub

    Private Sub txtDiasAcum_LostFocus(sender As Object, e As EventArgs) Handles txtDiasAcum.LostFocus
        BuscarPastoreos()
    End Sub
    Private Sub txtRotacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRotacion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            'CalculoPastoreo(lblTotHasEfect.Text.Trim, txtRotacion.Text.Trim, suma_acum)
            BuscarPastoreos()
        End If
    End Sub
    Private Sub txtRotacion_LostFocus(sender As Object, e As EventArgs) Handles txtRotacion.LostFocus
        'CalculoPastoreo(lblTotHasEfect.Text.Trim, txtRotacion.Text.Trim, suma_acum)
        BuscarPastoreos()
    End Sub


End Class