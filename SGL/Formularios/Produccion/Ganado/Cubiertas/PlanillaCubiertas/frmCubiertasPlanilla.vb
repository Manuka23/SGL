


Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Imports System.IO



Public Class frmCubiertasPlanilla


    'nombre de los campos en la base de datos, para realizar los ordenamientos desde esta pantalla
    Private CamposOrden As String() = {"", "EmpRut", "CenCod", "CenDesCor", "GndCod", "CategoNom", "GndUltFechaParto", _
                                       "DiasLac", "GndUlFechaRevPP", "CondRevPP", "Celo1", "Celo2", "Celo3", _
                                       "Cubierta1", "", "CIDR1", "Cubierta2", "", "CIDR2", "Cubierta3", "", "CIDR3", _
                                       "Cubierta4", "", "CIDR4", "GndUltCubiertaNum"}

    Private CadenaOrden As String = "GndCod"


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub


    'Private Sub CboLLenaTemporadas()
    '    If General.Temporadas.NroRegistros = 0 Then Exit Sub

    '    cboTemporadas.Items.Clear()
    '    'cboCentros.Items.Add("(TODOS)")

    '    Dim i As Integer

    '    For i = 0 To General.Temporadas.NroRegistros - 1
    '        cboTemporadas.Items.Add(General.Temporadas.Nombre(i))
    '    Next

    '    cboTemporadas.Text = "TEMPORADA " + TemporadaVigente.ToString.Trim
    'End Sub



    Public Sub ConsultaPlanilla(ByVal cent_ As String, ByVal diio_ As String)
        'If PrimerIngreso = True Then Exit Sub

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCubiertas_Planilla2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 '5 min
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        'cmd.Parameters.AddWithValue("@Temporada", temp_)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        'cmd.Parameters.Add("@RetTotVacas", SqlDbType.Int) : cmd.Parameters("@RetTotVacas").Direction = ParameterDirection.Output

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvCUBIERTAS.BeginUpdate()
        lvCUBIERTAS.Items.Clear()

        Dim vret As Integer = 0
        Dim i As Integer = 0
        Dim cont_celos As Integer = 0
        Dim cont_cbtas As Integer = 0
        Dim MuestraReg As Boolean = True
        Dim fup_, fur_ As String
        Dim fact_ As Date
        Dim fcel1_, fcel2_, fcel3_ As Date
        Dim diacub1, diacub2, diacub3, diacub4 As String
        Dim tot1cub_, tot2cub_, tot3cub_, tot4cub_ As Integer

        Dim total_1_cub, total_2_cub, total_3_cub, total_4_cub As Integer

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            'Dim items As New List(Of ListViewItem)

            'Try

            ''08-NOV-2012
            ''CAMBIAMOS LOS CALCULOS DE LOS DIAS DE DIFERENCIAS EN LAS FECHAS DE CUBIERTAS, ANTES ERA CONTRA LA FECHA ACTUAL
            ''Y AHORA ES: LA PRIMERA FECHA CUBIERTA CONTRA LA ULTIMA FECHA DE CELOS MENOR A LA FECHA DE LA PRIMERA CUBIERTA,
            ''Y LOS DEMAS DIAS DE DIFERENCIA CONTRA LA CUBIERTA ANTERIOR

            While rdr.Read()
                If vret = 0 Then
                    vret = rdr("ContRegs")
                    'totvacas = rdr("ContVacas")
                    pbProcesa.Maximum = vret
                End If

                'MuestraReg = True

                If MuestraReg = True Then
                    fup_ = ""
                    fur_ = ""
                    fact_ = rdr("FechaActual").ToString.Trim    '
                    diacub1 = ""
                    diacub2 = ""
                    diacub3 = ""
                    diacub4 = ""
                    fcel1_ = Nothing
                    fcel2_ = Nothing
                    fcel3_ = Nothing

                    'If FechaCorrecta(rdr("GndUltFechaParto").ToString.Trim) Then fup_ = Format(rdr("GndUltFechaParto"), "dd-MM-yyyy")
                    'If FechaCorrecta(rdr("GndUlFechaRevPP").ToString.Trim) Then fur_ = Format(rdr("GndUlFechaRevPP"), "dd-MM-yyyy")
                    If IsDate(rdr("GndUltFechaParto")) Then fup_ = Format(rdr("GndUltFechaParto"), "dd-MM-yyyy")
                    If IsDate(rdr("GndUlFechaRevPP")) Then fur_ = Format(rdr("GndUlFechaRevPP"), "dd-MM-yyyy")
                    ''
                    'If IsDate(rdr("Celo1")) Then fcel1_ = rdr("Celo1")
                    If fup_ = "01-01-1900" Or fup_ = "01-01-1753" Then fup_ = ""
                    If fur_ = "01-01-1900" Or fur_ = "01-01-1753" Then fur_ = ""

                    If IsDate(rdr("Celo1")) Then fcel1_ = Date.Parse(rdr("Celo1"))
                    If IsDate(rdr("Celo2")) Then fcel2_ = Date.Parse(rdr("Celo2"))
                    If IsDate(rdr("Celo3")) Then fcel3_ = Date.Parse(rdr("Celo3"))

                    'If FechaCorrecta(rdr("Celo1").ToString.Trim) Then fcel1_ = Date.Parse(rdr("Celo1"))
                    'If FechaCorrecta(rdr("Celo2").ToString.Trim) Then fcel2_ = Date.Parse(rdr("Celo2"))
                    'If FechaCorrecta(rdr("Celo3").ToString.Trim) Then fcel3_ = Date.Parse(rdr("Celo3"))

                    If rdr("Celo1").ToString.Trim <> "" Then
                        cont_celos = cont_celos + 1
                    End If

                    If rdr("Cubierta1").ToString.Trim <> "" Then
                        cont_cbtas = cont_cbtas + 1

                        If fcel3_ <> Nothing And fcel3_ < Date.Parse(rdr("Cubierta1")) Then
                            diacub1 = DateDiff(DateInterval.Day, fcel3_, rdr("Cubierta1")).ToString.Trim
                        ElseIf fcel2_ <> Nothing And fcel2_ < Date.Parse(rdr("Cubierta1")) Then
                            diacub1 = DateDiff(DateInterval.Day, fcel2_, rdr("Cubierta1")).ToString.Trim
                        ElseIf fcel1_ <> Nothing And fcel1_ < Date.Parse(rdr("Cubierta1")) Then
                            diacub1 = DateDiff(DateInterval.Day, fcel1_, rdr("Cubierta1")).ToString.Trim
                        End If

                        tot1cub_ = tot1cub_ + 1

                        If rdr("Cubierta2").ToString.Trim = "" And
                            rdr("Cubierta3").ToString.Trim = "" And rdr("Cubierta4").ToString.Trim = "" Then
                            total_1_cub = total_1_cub + 1
                        End If

                        If rdr("Cubierta2").ToString.Trim <> "" And
                            rdr("Cubierta3").ToString.Trim = "" And rdr("Cubierta4").ToString.Trim = "" Then
                            total_2_cub = total_2_cub + 1
                        End If

                        If rdr("Cubierta2").ToString.Trim <> "" And
                           rdr("Cubierta3").ToString.Trim <> "" And rdr("Cubierta4").ToString.Trim = "" Then
                            total_3_cub = total_3_cub + 1
                        End If

                        If rdr("Cubierta2").ToString.Trim <> "" And
                           rdr("Cubierta3").ToString.Trim <> "" And rdr("Cubierta4").ToString.Trim <> "" Then
                            total_4_cub = total_4_cub + 1
                        End If

                    End If

                    If rdr("Cubierta2").ToString.Trim <> "" Then
                        diacub2 = DateDiff(DateInterval.Day, rdr("Cubierta1"), rdr("Cubierta2")).ToString.Trim
                        tot2cub_ = tot2cub_ + 1
                    End If

                    If rdr("Cubierta3").ToString.Trim <> "" Then
                        tot3cub_ = tot3cub_ + 1
                        diacub3 = DateDiff(DateInterval.Day, rdr("Cubierta2"), rdr("Cubierta3")).ToString.Trim
                    End If

                    If rdr("Cubierta4").ToString.Trim <> "" Then
                        tot4cub_ = tot4cub_ + 1
                        diacub4 = DateDiff(DateInterval.Day, rdr("Cubierta3"), rdr("Cubierta4")).ToString.Trim
                    End If


                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                    item.SubItems.Add(rdr("CenCod").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    ''
                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(fup_)
                    item.SubItems.Add(rdr("DiasLac").ToString.Trim)
                    item.SubItems.Add(fur_)
                    item.SubItems.Add(rdr("CondRevPP").ToString.Trim)
                    ''
                    item.SubItems.Add(rdr("Celo1").ToString.Trim)
                    item.SubItems.Add(rdr("Celo2").ToString.Trim)
                    item.SubItems.Add(rdr("Celo3").ToString.Trim)
                    ''
                    item.SubItems.Add(rdr("Cubierta1").ToString.Trim)
                    item.SubItems.Add(diacub1)
                    item.SubItems.Add(rdr("CIDR1").ToString.Trim)
                    '
                    item.SubItems.Add(rdr("Cubierta2").ToString.Trim)
                    item.SubItems.Add(diacub2)
                    item.SubItems.Add(rdr("CIDR2").ToString.Trim)
                    '
                    item.SubItems.Add(rdr("Cubierta3").ToString.Trim)
                    item.SubItems.Add(diacub3)
                    item.SubItems.Add(rdr("CIDR3").ToString.Trim)
                    '
                    item.SubItems.Add(rdr("Cubierta4").ToString.Trim)
                    item.SubItems.Add(diacub4)
                    item.SubItems.Add(rdr("CIDR4").ToString.Trim)

                    If IsDBNull(rdr("GndUltCubiertaNum")) Then
                        item.SubItems.Add("")
                    Else
                        If rdr("GndUltCubiertaNum") = 0 Then
                            item.SubItems.Add("")
                        Else
                            item.SubItems.Add(rdr("GndUltCubiertaNum").ToString.Trim)
                        End If
                    End If

                    lvCUBIERTAS.Items.Add(item)
                    'items.Add(item)

                    i = i + 1
                End If

                pbProcesa.Value = i
            End While

            pbProcesa.Value = pbProcesa.Maximum

            'lvCUBIERTAS.Items.AddRange(items.ToArray())

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvCUBIERTAS.EndUpdate()

        Label85.Text = i.ToString.Trim
        Label9.Text = cont_celos.ToString.Trim
        Label11.Text = (tot1cub_ + tot2cub_ + tot3cub_ + tot4cub_).ToString.Trim

        lblTotal1Cub.Text = total_1_cub.ToString.Trim

        Label13.Text = total_1_cub.ToString.Trim 'tot1cub_.ToString.Trim
        Label15.Text = total_2_cub.ToString.Trim 'tot2cub_.ToString.Trim
        Label17.Text = total_3_cub.ToString.Trim 'tot3cub_.ToString.Trim
        Label18.Text = total_4_cub.ToString.Trim 'tot4cub_.ToString.Trim

        lbltotalInsem.Text = (total_1_cub + total_2_cub + total_3_cub + total_4_cub).ToString

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
        Dim cent_ As String = ""
        Dim temp_ As Integer = 0

        '  If cboCentros.SelectedIndex = -1 Or cboTemporadas.SelectedIndex = -1 Then Exit Sub
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        ' temp_ = General.Temporadas.Codigo(cboTemporadas.SelectedIndex)

        If CadenaOrden = "" Then
            CadenaOrden = "GndCod"
            lblOrden.Text = "DIIO"
            lblOrden.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaPlanilla(cent_, txtDIIO.Text.Trim)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvCubiertas_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCUBIERTAS.MouseDoubleClick
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


    'Private Sub cboTemporadas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTemporadas.SelectedIndexChanged
    '    LlenaGrilla()
    'End Sub


    Private Sub lvCUBIERTAS_ColumnWidthChanging(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lvCUBIERTAS.ColumnWidthChanging
        'e.Cancel = False

    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvCUBIERTAS.Items.Count = 0 Then Exit Sub

        Dim tot(7, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL ANIMALES:" : tot(0, 1) = Label85.Text
        tot(1, 0) = "TOTAL CELOS:" : tot(1, 1) = Label9.Text
        tot(2, 0) = "TOTAL DOSIS:" : tot(2, 1) = Label11.Text
        tot(3, 0) = "TOTAL 1 CUB:" : tot(3, 1) = Label13.Text
        tot(4, 0) = "TOTAL 2 CUB:" : tot(4, 1) = Label15.Text
        tot(5, 0) = "TOTAL 3 CUB:" : tot(5, 1) = Label17.Text
        tot(6, 0) = "TOTAL 3 CUB:" : tot(6, 1) = Label18.Text

        ExportToExcelGrilla(lvCUBIERTAS, tot)
    End Sub



    Private Sub btnGrafico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TabControl1.Visible = True Then
            TabControl1.Visible = False
        Else
            TabControl1.Visible = True
        End If

    End Sub


    Private Sub frmCubiertasPlanilla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Temporadas.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True
        dtpFechaDesde.Value = Date.Now
        dtpFechaHasta.Value = Date.Now
        CboLLenaCentros()
        'CboLLenaTemporadas()

    End Sub




    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If lvCUBIERTAS.Items.Count = 0 Then Exit Sub
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text = "" Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim cent_ As String = ""
        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        With frmRptPlanillaCubiertas

            .Empresa = Empresa
            .Centro = cent_

            Dim p1 As New ReportParameter("Param1_Titulo1", "INFORME PLANILLA CUBIERTAS")
            Dim p2 As New ReportParameter("Param2_Titulo2", cboCentros.Text + " - TEMPORADA 2013")
            Dim p3 As New ReportParameter("Param3_Usuario", LoginUsuario)

            Dim p4 As New ReportParameter("TotalAnimales", "TOTAL ANIMALES: " + Label85.Text)
            Dim p5 As New ReportParameter("TotalCelos", "T.CELOS: " + Label9.Text)
            Dim p6 As New ReportParameter("Total1Cbta", "T.1a Cbta: " + Label13.Text)
            Dim p7 As New ReportParameter("Total2Cbta", "T.2a Cbta: " + Label15.Text)
            Dim p8 As New ReportParameter("Total3Cbta", "T.3a Cbta: " + Label17.Text)
            Dim p9 As New ReportParameter("Total4Cbta", "T.4a Cbta: " + Label18.Text)

            .ReportViewer1.LocalReport.SetParameters(New ReportParameter() {p1, p2, p3, p4, p5, p6, p7, p8, p9})

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

        End With


        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvCUBIERTAS_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCUBIERTAS.ColumnClick
        'If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        'If CadenaOrden.Trim = "" Then
        '    CadenaOrden = CamposOrden(e.Column)
        '    lblOrden.Text = lvCUBIERTAS.Columns(e.Column).Text
        'Else
        '    CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
        '    lblOrden.Text = lblOrden.Text + " -> " + lvCUBIERTAS.Columns(e.Column).Text
        'End If
    End Sub


End Class