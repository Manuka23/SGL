


Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Reporting.WinForms
'Imports Micr .Office.Interop
Imports System.Data.SqlClient



Public Class frmTNR

    Private EnEventoLoad As Boolean = False
    Private CadenaOrden As String = ""


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


    Private Sub CboLLenaTemporadas()
        If General.Temporadas.NroRegistros = 0 Then Exit Sub

        cboTemporadas.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Temporadas.NroRegistros - 1
            cboTemporadas.Items.Add(General.Temporadas.Nombre(i))
        Next

        cboTemporadas.Text = "TEMPORADA " + TemporadaVigente.ToString.Trim
    End Sub



    Public Sub Exportar_A_Excel(ByVal grilla As ListView)
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim lin, col, col2 As Integer

            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Libro = AppExcel.Workbooks.Add
            Hoja = Libro.Worksheets(1)
            col2 = 1

            'Libro.Title = "Consulta de Ganado..."
            'Libro.Author = "ndsky"
            'Hoja.Name = "Libro Exportado"


            For col = 1 To grilla.Columns.Count - 1
                If grilla.Columns(col).Width > 0 Then
                    Hoja.Cells(1, col2) = grilla.Columns(col).Text
                    Hoja.Cells(1, col2).font.bold = True
                    Hoja.Cells(1, col2).font.size = 12

                    col2 = col2 + 1
                End If
            Next

            For lin = 0 To grilla.Items.Count - 1
                col2 = 1

                For col = 1 To grilla.Columns.Count - 1
                    If grilla.Columns(col).Width > 0 Then

                        If lvCUBIERTAS.Items(lin).SubItems(col).Text.ToString.Trim.Contains("-") = True Or lvCUBIERTAS.Items(lin).SubItems(col).Text.ToString.Trim.Contains("/") = True Then 'si es fecha y no es el campo "production cod"
                            Hoja.Cells(lin + 2, col2).numberformat = "@"
                            Hoja.Cells(lin + 2, col2) = grilla.Items(lin).SubItems(col).Text.ToString.Trim
                        Else
                            Hoja.Cells(lin + 2, col2) = grilla.Items(lin).SubItems(col).Text.ToString.Trim
                        End If

                        col2 = col2 + 1
                    End If
                Next
            Next

            'lin = lin + 3
            'Hoja.Cells(lin, 1) = "TOTAL ANIMALES: " + Label85.Text.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12
            ''Hoja.Cells(lin, 3) = Label85.Text.Trim : Hoja.Cells(lin, 3).font.bold = True : Hoja.Cells(lin, 3).font.size = 12
            'Hoja.Cells(lin, 4) = "TOTAL CELOS:" + Label9.Text.Trim : Hoja.Cells(lin, 4).font.bold = True : Hoja.Cells(lin, 4).font.size = 12
            'Hoja.Cells(lin, 7) = "TOTAL CUBIERTAS:" + Label11.Text.Trim : Hoja.Cells(lin, 7).font.bold = True : Hoja.Cells(lin, 7).font.size = 12

            AppExcel.Visible = True
            AppActivate(AppExcel.Caption)

            Hoja = Nothing      'Descargamos los Objetos...
            Libro = Nothing
            AppExcel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor.Current = Cursors.Default
    End Sub



    Public Sub ConsultaPlanilla(ByVal cent_ As String)
        'If PrimerIngreso = True Then Exit Sub

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_TNR", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Temporada", General.Temporadas.Codigo(cboTemporadas.SelectedIndex))
        cmd.Parameters.AddWithValue("@FechaTope", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        'cmd.Parameters.Add("@RetTotVacas", SqlDbType.Int) : cmd.Parameters("@RetTotVacas").Direction = ParameterDirection.Output

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvCUBIERTAS.BeginUpdate()
        lvCUBIERTAS.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Dim totvacas As Integer = 0
        Dim totcbtas As Integer = 0
        Dim tot21dias As Integer = 0
        Dim tot8y12dias As Integer = 0
        Dim totAnomalos As Integer = 0
        Dim tot_tnr1 As Integer = 0
        Dim tot_tnr2 As Integer = 0
        Dim TotalTNR As Integer = 0
        Dim tot18y24dias As Integer = 0

        'Dim tot18y24dias_dif As Integer = 0

        'Dim sum_tot_tnr As Integer = 0
        'Dim sum_tot_18y24 As Integer = 0

        Dim totp21dias As Double = 0
        Dim totptotaltnr As Double = 0
        Dim totp8y12dias As Double = 0
        Dim totp18y24dias As Double = 0
        Dim totpanomalos As Double = 0

        Dim pje_21dias As Double = 0
        Dim pje_totaltnr As Double = 0
        Dim pje_18y24dias As Double = 0
        Dim pje_8y12dias As Double = 0
        Dim pje_anomalos As Double = 0

        'Dim TotalTNR_M1C As Integer = 0
        Dim MuestraReg As Boolean = False

        lblTotalVacas.Text = "0"
        lblTotalCbtas.Text = "0"
        lblTotal21Dias.Text = "0"
        lblTotal18y24Dias.Text = "0"
        lblTotal8y12Dias.Text = "0"
        lblTotalAnomalos.Text = "0"
        lblTotalTNR.Text = "0"
        ''
        lblP21Dias.Text = "0 %"
        lblP18y24Dias.Text = "0 %"
        lblP8y12Dias.Text = "0 %"
        lblPAnomalos.Text = "0 %"

        Dim tnr1, tnr1m1c, tnr2, tnr3 As Integer
        'Dim tnr1m1c, tnr2m1c As Integer     'contadores con mas de una cubierta

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        'totvacas = rdr("ContVacas")
                        pbProcesa.Maximum = vret
                    End If

                    pje_21dias = 0
                    pje_8y12dias = 0
                    pje_18y24dias = 0
                    pje_anomalos = 0
                    pje_totaltnr = 0
                    tnr1 = 0
                    tnr1m1c = 0
                    tnr2 = 0
                    tnr3 = 0
                    'tnr2m1c = 0

                    MuestraReg = True
                    If chkSoloConStock.Checked = True And rdr("ContVacas") = 0 Then MuestraReg = False

                    'If MuestraReg = True Then
                    'cnt_sincbtas = (rdr("ContVacas") - rdr("ContCubiertas"))

                    If rdr("ContCubiertas") <> 0 Then
                        tnr1 = rdr("ContTNR18y24Dias")
                        tnr1m1c = rdr("ContTNR18y24DiasM1C")
                        tnr2 = (tnr1 - (tnr1m1c - rdr("ContTNR18y24DiasOK"))) - rdr("ContTNR18y24DiasOK")
                        tnr3 = rdr("ContTNR8y12Dias")

                        pje_21dias = ((rdr("ContSR21Dias") * 100) / rdr("ContCubiertas"))

                        If tnr1 <> 0 Then pje_totaltnr = (((tnr1 - tnr1m1c) * 100) / tnr1)
                        If tnr1 <> 0 Then pje_18y24dias = ((tnr2 * 100) / (tnr1 - (tnr1m1c - rdr("ContTNR18y24DiasOK"))))
                    End If

                    If tnr1 <> 0 Then
                        pje_8y12dias = ((tnr3 * 100) / tnr1)
                        pje_anomalos = ((rdr("ContAnomalos2y7_13y17Dias") * 100) / tnr1)
                    End If


                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                    item.SubItems.Add(rdr("CenCod").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    ''
                    item.SubItems.Add(rdr("ContVacas").ToString.Trim)
                    item.SubItems.Add(rdr("ContCubiertas").ToString.Trim)
                    ''
                    item.SubItems.Add(rdr("ContSR21Dias").ToString.Trim)                'SR 21 Dias
                    item.SubItems.Add(Format(pje_21dias, "#,##") + " %")
                    ''
                    item.SubItems.Add((tnr1 - tnr1m1c).ToString.Trim)                   'TOTAL TNR
                    item.SubItems.Add(Format(pje_totaltnr, "#,##") + " %")
                    ''
                    item.SubItems.Add((tnr2).ToString.Trim)                   'TNR 18-24
                    item.SubItems.Add(Format(pje_18y24dias, "#,##") + " %")
                    ''
                    item.SubItems.Add(tnr3.ToString.Trim)                               'RET 8-12
                    item.SubItems.Add(Format(pje_8y12dias, "#,##") + " %")
                    ''
                    item.SubItems.Add(rdr("ContAnomalos2y7_13y17Dias").ToString.Trim)   'ANOMALOS
                    item.SubItems.Add(Format(pje_anomalos, "#,##") + " %")
                    ''

                    lvCUBIERTAS.Items.Add(item)

                    totvacas = totvacas + rdr("ContVacas")
                    totcbtas = totcbtas + rdr("ContCubiertas")
                    tot21dias = tot21dias + rdr("ContSR21Dias")

                    TotalTNR = TotalTNR + (tnr1 - tnr1m1c)          'TOTAL TNR
                    tot_tnr1 = tot_tnr1 + tnr1                      'TOTAL TNR PARA CALCULAR %

                    tot18y24dias = tot18y24dias + tnr2                                      'TOTAL TNR 18-24
                    tot_tnr2 = tot_tnr2 + (tnr1 - (tnr1m1c - rdr("ContTNR18y24DiasOK")))    'TOTAL TNR 18-24 PARA CALCULAR %

                    tot8y12dias = tot8y12dias + tnr3
                    totAnomalos = totAnomalos + rdr("ContAnomalos2y7_13y17Dias")

                    i = i + 1
                    'End If

                    pbProcesa.Value = i
                End While

                pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvCUBIERTAS.EndUpdate()

        lblTotalVacas.Text = totvacas.ToString.Trim
        lblTotalCbtas.Text = totcbtas.ToString.Trim
        lblTotal21Dias.Text = tot21dias.ToString.Trim

        lblTotalTNR.Text = TotalTNR.ToString.Trim
        lblTotal18y24Dias.Text = tot18y24dias.ToString.Trim

        lblTotal8y12Dias.Text = tot8y12dias.ToString.Trim
        lblTotalAnomalos.Text = totAnomalos.ToString.Trim


        If totvacas <> 0 Then
            totp21dias = ((tot21dias * 100) / totcbtas)

            totptotaltnr = ((TotalTNR * 100) / tot_tnr1)
            totp18y24dias = ((tot18y24dias * 100) / tot_tnr2)

            totp8y12dias = ((tot8y12dias * 100) / tot_tnr1)
            totpanomalos = ((totAnomalos * 100) / tot_tnr1)

            lblP21Dias.Text = totp21dias.ToString("#,##") + " %"
            lblPTotalTNR.Text = totptotaltnr.ToString("#,##") + " %"
            lblP18y24Dias.Text = totp18y24dias.ToString("#,##") + " %"
            lblP8y12Dias.Text = totp8y12dias.ToString("#,##") + " %"
            lblPAnomalos.Text = totpanomalos.ToString("#,##") + " %"
        End If

        pnlProcesa.Visible = False
    End Sub



    Private Sub DetalleGanado()
        If lvCUBIERTAS.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvCUBIERTAS.SelectedItems.Item(0).SubItems(4).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub LlenaGrilla()
        If EnEventoLoad Then Exit Sub

        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim causa_ As String = ""

        If cboCentros.SelectedIndex = -1 Then Exit Sub
        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)

        If CadenaOrden = "" Then
            CadenaOrden = "CenDesCor"
            'lblOrdena.Text = "Centro"
            'lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaPlanilla(cent_)
        'ConsultaPlanilla2(cent_)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvCubiertas_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        DetalleGanado()
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrilla()
    End Sub



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        LlenaGrilla()
    End Sub


    Private Sub lvCUBIERTAS_ColumnWidthChanging(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs)
        'e.Cancel = False

    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Exportar_A_Excel(lvCUBIERTAS)
    End Sub


    Private Sub btnGrafico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If TabControl1.Visible = True Then
        '    TabControl1.Visible = False
        'Else
        '    TabControl1.Visible = True
        'End If

    End Sub



    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If lvCUBIERTAS.Items.Count = 0 Then Exit Sub
        If cboCentros.SelectedIndex = -1 Then Exit Sub
        If cboTemporadas.SelectedIndex = -1 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim cent_ As String = ""
        Dim temp_ As Integer = 0

        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        temp_ = General.Temporadas.Codigo(cboTemporadas.SelectedIndex)

        With frmRptTNR

            .Empresa = Empresa
            .Centro = cent_
            .Temporada = temp_
            .FechaTope = dtpFecha.Value

            Dim p1 As New ReportParameter("Param1_Titulo1", "INFORME TASA NO RETORNO")
            Dim p2 As New ReportParameter("Param2_Titulo2", cboTemporadas.Text + " / HASTA: " + Format(dtpFecha.Value, "dd-MM-yyyy"))
            Dim p3 As New ReportParameter("Param3_Usuario", LoginUsuario)

            .ReportViewer1.LocalReport.SetParameters(New ReportParameter() {p1, p2, p3})

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

        End With


        Cursor.Current = Cursors.Default
    End Sub


    Private Sub frmTNR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Panel1.Refresh()
        'Me.Refresh()

        'LlenaGrilla()
    End Sub


    Private Sub frmTNR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Temporadas.Cargar()
        EnEventoLoad = True

        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        dtpFecha.Value = Date.Now

        CboLLenaCentros()
        CboLLenaTemporadas()

        EnEventoLoad = False
    End Sub




End Class