Imports System.Data.SqlClient

Public Class frmCierresIngreso

    Private ComparaDIIOStockSala As String() = {}
    Private EnEventoLoad As Boolean = True
    Private procesa As Integer = 0

    Private Sub LeeBaston()

        Dim tip_ As Integer = 0

        If General.CentrosUsuario.EsAreaSeca(cboCentros.SelectedIndex - 1) = True Then
            tip_ = 1
        End If

        If General.CentrosUsuario.EsTernerera(cboCentros.SelectedIndex - 1) = True Then
            tip_ = 2
        End If

        frmBastonV2.ValidaTipoCentro = tip_
        frmBastonV2.ValidaParaCierre = True
        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmCierresIngreso"


        frmBastonV2.QuitarOrigenExcel = IIf(UsuarioCierraXLS = 1, False, True)
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub


    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim pos_ini As Integer = 0
        Dim diio_ As String = ""
        Dim diio_paso As String = ""
        Dim strdiios1_ As String = ""
        Dim strdiios2_ As String = ""
        Dim ExisteDIIO As Boolean = False


        Dim ComparaDIIOBaston As String() = {}
        Dim x, y As Integer

        Dim cont_compara As Integer = 0
        Dim cont_comperr1 As Integer = 0
        Dim cont_comperr2 As Integer = 0

        y = 0

        Cursor.Current = Cursors.WaitCursor


        'llenamos arreglo con los diios en stock de la sala, para la comparacion de baston
        If LlenaArregloConStockActualSala() = False Then
            Exit Sub
        End If


        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec_ As String = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString

        Me.Enabled = False

        frmComparaBaston.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        frmComparaBaston.Param2_CentroNom = cboCentros.Text
        frmComparaBaston.Param3_Fecha = DateTime.Parse(fec_)
        frmComparaBaston.Param4_SaldoInicial = IIf(Label48.Text = "", 0, Label48.Text)
        frmComparaBaston.Param5_SaldoFinal = IIf(lblStockActual.Text = "", 0, lblStockActual.Text)
        frmComparaBaston.Param6_Estado = 0
        frmComparaBaston.Param7_Observs = txtObservs.Text
        frmComparaBaston.Param8_TipoCierre = cboTiposCierre.Text

        'mostramos formulario de comparacion de diios
        frmComparaBaston.MdiParent = frmMAIN
        frmComparaBaston.Show()
        frmComparaBaston.pnlTotal.Refresh()
        frmComparaBaston.lblProcesa.Text = "Verificando DIIOs del baston..."

        frmComparaBaston.pbProcesa.Value = 0
        frmComparaBaston.pbProcesa.Maximum = (frmBastonV2.lvBASTON.Items.Count) + (ComparaDIIOStockSala.Count)
        frmComparaBaston.pnlProcesa.Visible = True
        frmComparaBaston.pnlProcesa.Refresh()

        frmComparaBaston.lvGanado.BeginUpdate()
        frmComparaBaston.lvGanado.Items.Clear()

        'creamos arreglo con los diios del baston y aprovechamos de compararlos con los diios de la consulta general
        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            ReDim Preserve ComparaDIIOBaston(i)

            ComparaDIIOBaston(i) = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim
            ExisteDIIO = False

            For x = 0 To ComparaDIIOStockSala.Count - 1
                If ComparaDIIOBaston(i) = ComparaDIIOStockSala(x) Then
                    ExisteDIIO = True
                End If
            Next


            If Not ExisteDIIO Then
                Dim item = New ListViewItem((y + 1).ToString.Trim)
                item.SubItems.Add(ComparaDIIOBaston(i))
                item.SubItems.Add("EL DIIO existe en el bastón y no existe en el stock")
                frmComparaBaston.lvGanado.Items.Add(item)
                frmComparaBaston.lvGanado.Items(y).ForeColor = Color.Red
                y = y + 1
                cont_comperr1 = cont_comperr1 + 1
            End If

            frmComparaBaston.pbProcesa.Value = i
            cont_compara = cont_compara + 1
        Next

        'ahora recorremos los diios de la consulta general para compararlos con los diios del baston
        frmComparaBaston.lblProcesa.Text = "Verificando DIIOs de la consulta general..."
        frmComparaBaston.pnlProcesa.Refresh()

        For z = 0 To ComparaDIIOStockSala.Count - 1
            ExisteDIIO = False

            For x = 0 To ComparaDIIOBaston.Count - 1
                If ComparaDIIOStockSala(z) = ComparaDIIOBaston(x) Then
                    ExisteDIIO = True
                End If
            Next


            If Not ExisteDIIO Then
                Dim item = New ListViewItem((y + 1).ToString.Trim)
                item.SubItems.Add(ComparaDIIOStockSala(z))
                item.SubItems.Add("EL DIIO existe en el stock y no existe en el baston")
                frmComparaBaston.lvGanado.Items.Add(item)

                y = y + 1
                cont_comperr2 = cont_comperr2 + 1
            End If

            frmComparaBaston.pbProcesa.Value = i
            i = i + 1
        Next

        frmComparaBaston.lvGanado.EndUpdate()

        frmComparaBaston.pbProcesa.Maximum = (frmBastonV2.lvBASTON.Items.Count) + (ComparaDIIOStockSala.Count)
        frmComparaBaston.pnlProcesa.Visible = False

        frmComparaBaston.Label8.Text = cont_compara.ToString.Trim
        frmComparaBaston.Label9.Text = cont_comperr1.ToString.Trim
        frmComparaBaston.Label13.Text = cont_comperr2.ToString.Trim


        If (cont_comperr1 + cont_comperr2) > 0 Then
            frmComparaBaston.btnCierreMensual.Enabled = False
        Else
            frmComparaBaston.btnCierreMensual.Enabled = True
        End If

        Cursor.Current = Cursors.Default
    End Sub

    Public Function LlenaArregloConStockActualSala() As Boolean
        LlenaArregloConStockActualSala = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCierres_ListadoStock2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim gndcod_ As String = ""
        Dim i As Integer = 0

        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@MesProcesar", txtMes.Text)
        cmd.Parameters.AddWithValue("@AñoProcesar", txtAnio.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error de Validaciones") = vbOK Then
                End If
                Exit Function
            End If

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    pbProcesa.Maximum = vret
                    'End If

                    ReDim Preserve ComparaDIIOStockSala(i)
                    ComparaDIIOStockSala(i) = rdr("GndCod").ToString.Trim

                    i = i + 1
                    'pbProcesa.Value = Total_General
                End While
                LlenaArregloConStockActualSala = True
                'pbProcesa.Value = pbProcesa.Maximum
                'Dim x As Integer = 0

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        'Cursor.Current = Cursors.Default
    End Function



    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")
        Dim i As Integer
        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Public Sub ConsultaResumenCierrePorCentros()
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCierres_ResumenPeriodoPorCentros2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300

        Dim cent_ As String = ""

        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Mes", txtMes.Value)
        cmd.Parameters.AddWithValue("@Anio", txtAnio.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim est_ As String = 0
        Dim estcod_ As Integer = 0
        Dim estnom_ As String = ""
        Dim dcierre, tipocierre_ As Integer
        Dim sini_, nac_, comp_, ajusal_, trasal_, catsal_, mue_, vent_, ajuent_, traent_, catent_, sfin_, sstk_ As Integer
        Dim tcierre_, tdocto_, tsini_, tnac_, tcomp_, tajusal_, ttrasal_, tcatsal_, tmue_, tvent_, tajuent_, ttraent_, tcatent_, tsfin_, tsstk_ As Integer
        Dim scierre As String

        tcierre_ = 0
        tdocto_ = 0
        tsini_ = 0
        tnac_ = 0
        tcomp_ = 0
        tajuent_ = 0
        ttraent_ = 0
        tcatent_ = 0
        tmue_ = 0
        tvent_ = 0
        tajusal_ = 0
        ttrasal_ = 0
        tcatsal_ = 0
        tsfin_ = 0
        tsstk_ = 0
        scierre = ""
        dcierre = 0
        tipocierre_ = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    pbProcesa.Maximum = vret
                    'End If

                    tipocierre_ = rdr("CTipoCodigo")
                    dcierre = rdr("DiaCierre")
                    sini_ = rdr("SaldoInicial")
                    nac_ = rdr("Nacimientos1") + rdr("Nacimientos2")
                    comp_ = rdr("Compras")
                    ajuent_ = rdr("EntradasAjustes")
                    traent_ = rdr("EntradasTraslados")
                    catent_ = rdr("EntradasCambioCat")
                    mue_ = rdr("Muertes")
                    vent_ = rdr("Ventas")
                    ajusal_ = rdr("SalidasAjustes")
                    trasal_ = rdr("SalidasTraslados")
                    catsal_ = rdr("SalidasCambioCat")
                    sfin_ = ((sini_ + nac_ + comp_ + ajuent_ + traent_ + catent_) - (mue_ + vent_ + ajusal_ + trasal_ + catsal_))
                    sstk_ = rdr("SaldoFinal")
                    scierre = ""

                    If dcierre = 0 Or dcierre = 99 Then
                        scierre = "..."
                    Else
                        If tipocierre_ = 1 Then
                            'pre-cierre
                            scierre = dcierre.ToString.Trim
                        Else
                            'cierre mensual
                            scierre = "MES"
                        End If

                        'If dcierre >= 28 And dcierre <= 31 Then
                        '    scierre = "MES"
                        'Else
                        '    scierre = dcierre.ToString.Trim
                        'End If
                    End If

                    Dim item As New ListViewItem(rdr("CenDesCor").ToString.Trim)

                    item.SubItems.Add(scierre)
                    item.SubItems.Add(rdr("Cierre").ToString.Trim)
                    item.SubItems.Add(rdr("Docs").ToString.Trim)
                    item.SubItems.Add(IIf(sini_ <> 0, Format(sini_, "#,#0"), ""))
                    item.SubItems.Add(IIf(nac_ <> 0, Format(nac_, "#,#0"), ""))
                    item.SubItems.Add(IIf(comp_ <> 0, Format(comp_, "#,#0"), ""))
                    item.SubItems.Add(IIf(ajuent_ <> 0, Format(ajuent_, "#,#0"), ""))
                    item.SubItems.Add(IIf(traent_ <> 0, Format(traent_, "#,#0"), ""))
                    item.SubItems.Add(IIf(catent_ <> 0, Format(catent_, "#,#0"), ""))
                    item.SubItems.Add(IIf(mue_ <> 0, Format(mue_, "#,#0"), ""))
                    item.SubItems.Add(IIf(vent_ <> 0, Format(vent_, "#,#0"), ""))
                    item.SubItems.Add(IIf(ajusal_ <> 0, Format(ajusal_, "#,#0"), ""))
                    item.SubItems.Add(IIf(trasal_ <> 0, Format(trasal_, "#,#0"), ""))
                    item.SubItems.Add(IIf(catsal_ <> 0, Format(catsal_, "#,#0"), ""))
                    item.SubItems.Add(IIf(sfin_ <> 0, Format(sfin_, "#,#0"), ""))
                    item.SubItems.Add(IIf(sstk_ <> 0, Format(sstk_, "#,#0"), ""))
                    item.SubItems.Add(rdr("CenCod").ToString.Trim)
                    item.SubItems.Add(rdr("CieFecha").ToString.Trim)

                    item.UseItemStyleForSubItems = False
                    'item.SubItems(0).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(4).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(10).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(11).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(12).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(13).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(14).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(15).BackColor = Color.FromArgb(220, 220, 220)

                    lvRESUMEN1.Items.Add(item)

                    'solo sumamos los datos del cierre de fin de mes
                    If tipocierre_ = 2 Then ' dcierre = 0 Or dcierre >= 28 Then
                        If rdr("Cierre").ToString.Trim = "SI" Then tcierre_ = tcierre_ + 1
                        If rdr("Docs").ToString.Trim = "SI" Then tdocto_ = tdocto_ + 1

                        tsini_ = tsini_ + sini_
                        tnac_ = tnac_ + nac_
                        tcomp_ = tcomp_ + comp_
                        tajuent_ = tajuent_ + ajuent_
                        ttraent_ = ttraent_ + traent_
                        tcatent_ = tcatent_ + catent_
                        tmue_ = tmue_ + mue_
                        tvent_ = tvent_ + vent_
                        tajusal_ = tajusal_ + ajusal_
                        ttrasal_ = ttrasal_ + trasal_
                        tcatsal_ = tcatsal_ + catsal_

                        tsfin_ = tsfin_ + sfin_
                        tsstk_ = tsstk_ + sstk_
                    End If

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


        Label29.Text = IIf(tcierre_ > 0, Format(tcierre_, "#,#0"), "")
        Label30.Text = IIf(tdocto_ > 0, Format(tdocto_, "#,#0"), "")
        Label48.Text = IIf(tsini_ > 0, Format(tsini_, "#,#0"), "")
        Label1.Text = IIf(tnac_ > 0, Format(tnac_, "#,#0"), "")
        Label2.Text = IIf(tcomp_ > 0, Format(tcomp_, "#,#0"), "")
        Label4.Text = IIf(tajuent_ > 0, Format(tajuent_, "#,#0"), "")
        Label5.Text = IIf(ttraent_ > 0, Format(ttraent_, "#,#0"), "")
        Label6.Text = IIf(tcatent_ > 0, Format(tcatent_, "#,#0"), "")
        Label7.Text = IIf(tmue_ > 0, Format(tmue_, "#,#0"), "")
        Label9.Text = IIf(tvent_ > 0, Format(tvent_, "#,#0"), "")
        Label10.Text = IIf(tajusal_ > 0, Format(tajusal_, "#,#0"), "")
        Label11.Text = IIf(ttrasal_ > 0, Format(ttrasal_, "#,#0"), "")
        Label12.Text = IIf(tcatsal_ > 0, Format(tcatsal_, "#,#0"), "")
        lblSaldoFinal.Text = IIf(tsfin_ > 0, Format(tsfin_, "#,#0"), "")
        lblStockActual.Text = IIf(tsstk_ > 0, Format(tsstk_, "#,#0"), "")

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub ConsultaResumenCierrePorCategorias()
        'lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = 0
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCierres_ResumenPeriodoPorCategorias", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300

        Dim cent_ As String = ""
        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Mes", txtMes.Value)
        cmd.Parameters.AddWithValue("@Anio", txtAnio.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim est_ As String = 0
        Dim estcod_ As Integer = 0
        Dim estnom_ As String = ""
        Dim sini_, nac_, comp_, ajusal_, trasal_, catsal_, mue_, vent_, ajuent_, traent_, catent_, sfin_, sstk_ As Integer
        Dim tsini_, tnac_, tcomp_, tajusal_, ttrasal_, tcatsal_, tmue_, tvent_, tajuent_, ttraent_, tcatent_, tsfin_, tsstk_ As Integer

        tsini_ = 0
        tnac_ = 0
        tcomp_ = 0
        tajuent_ = 0
        ttraent_ = 0
        tcatent_ = 0
        tmue_ = 0
        tvent_ = 0
        tajusal_ = 0
        ttrasal_ = 0
        tcatsal_ = 0
        tsfin_ = 0
        tsstk_ = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    pbProcesa.Maximum = vret
                    'End If

                    sini_ = rdr("SaldoInicial")
                    nac_ = rdr("Nacimientos1") + rdr("Nacimientos2")
                    comp_ = rdr("Compras")
                    ajuent_ = rdr("EntradasAjustes")
                    traent_ = rdr("EntradasTraslados")
                    catent_ = rdr("EntradasCambioCat")
                    mue_ = rdr("Muertes")
                    vent_ = rdr("Ventas")
                    ajusal_ = rdr("SalidasAjustes")
                    trasal_ = rdr("SalidasTraslados")
                    catsal_ = rdr("SalidasCambioCat")
                    sfin_ = ((sini_ + nac_ + comp_ + ajuent_ + traent_ + catent_) - (mue_ + vent_ + ajusal_ + trasal_ + catsal_))
                    sstk_ = rdr("SaldoFinal")

                    Dim item As New ListViewItem(rdr("CategoNom").ToString.Trim)

                    item.SubItems.Add(IIf(sini_ <> 0, Format(sini_, "#,#0"), ""))
                    item.SubItems.Add(IIf(nac_ <> 0, Format(nac_, "#,#0"), ""))
                    item.SubItems.Add(IIf(comp_ <> 0, Format(comp_, "#,#0"), ""))
                    item.SubItems.Add(IIf(ajuent_ <> 0, Format(ajuent_, "#,#0"), ""))
                    item.SubItems.Add(IIf(traent_ <> 0, Format(traent_, "#,#0"), ""))
                    item.SubItems.Add(IIf(catent_ <> 0, Format(catent_, "#,#0"), ""))
                    item.SubItems.Add(IIf(mue_ <> 0, Format(mue_, "#,#0"), ""))
                    item.SubItems.Add(IIf(vent_ <> 0, Format(vent_, "#,#0"), ""))
                    item.SubItems.Add(IIf(ajusal_ <> 0, Format(ajusal_, "#,#0"), ""))
                    item.SubItems.Add(IIf(trasal_ <> 0, Format(trasal_, "#,#0"), ""))
                    item.SubItems.Add(IIf(catsal_ <> 0, Format(catsal_, "#,#0"), ""))
                    item.SubItems.Add(IIf(sfin_ <> 0, Format(sfin_, "#,#0"), ""))
                    item.SubItems.Add(IIf(sstk_ <> 0, Format(sstk_, "#,#0"), ""))
                    item.SubItems.Add(rdr("CategoCod").ToString.Trim)

                    item.UseItemStyleForSubItems = False
                    item.SubItems(1).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(7).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(8).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(9).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(10).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(11).BackColor = Color.FromArgb(220, 220, 220)
                    item.SubItems(13).BackColor = Color.FromArgb(220, 220, 220)

                    lvRESUMEN2.Items.Add(item)

                    tsini_ = tsini_ + sini_
                    tnac_ = tnac_ + nac_
                    tcomp_ = tcomp_ + comp_
                    tajuent_ = tajuent_ + ajuent_
                    ttraent_ = ttraent_ + traent_
                    tcatent_ = tcatent_ + catent_
                    tmue_ = tmue_ + mue_
                    tvent_ = tvent_ + vent_
                    tajusal_ = tajusal_ + ajusal_
                    ttrasal_ = ttrasal_ + trasal_
                    tcatsal_ = tcatsal_ + catsal_
                    tsfin_ = tsfin_ + sfin_
                    tsstk_ = tsstk_ + sstk_

                    i = i + 1
                    'pbProcesa.Value = Total_General
                End While

                'pbProcesa.Value = pbProcesa.Maximum
                'Dim x As Integer = 0

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        'lvRESUMEN2.EndUpdate()

        Label25.Text = IIf(tsini_ > 0, Format(tsini_, "#,#0"), "")
        Label24.Text = IIf(tnac_ > 0, Format(tnac_, "#,#0"), "")
        Label23.Text = IIf(tcomp_ > 0, Format(tcomp_, "#,#0"), "")
        Label22.Text = IIf(tajuent_ > 0, Format(tajuent_, "#,#0"), "")
        Label21.Text = IIf(ttraent_ > 0, Format(ttraent_, "#,#0"), "")
        Label20.Text = IIf(tcatent_ > 0, Format(tcatent_, "#,#0"), "")
        Label19.Text = IIf(tmue_ > 0, Format(tmue_, "#,#0"), "")
        Label18.Text = IIf(tvent_ > 0, Format(tvent_, "#,#0"), "")
        Label17.Text = IIf(tajusal_ > 0, Format(tajusal_, "#,#0"), "")
        Label16.Text = IIf(ttrasal_ > 0, Format(ttrasal_, "#,#0"), "")
        Label15.Text = IIf(tcatsal_ > 0, Format(tcatsal_, "#,#0"), "")
        Label14.Text = IIf(tsfin_ > 0, Format(tsfin_, "#,#0"), "")
        Label28.Text = IIf(tsstk_ > 0, Format(tsstk_, "#,#0"), "")

        Cursor.Current = Cursors.Default
    End Sub



    Private Function RealizarCierreMensual() As Boolean
        RealizarCierreMensual = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCierres_CrearCierreMensual2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim sini_, sfin_ As Integer
        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec_ As String = ""

        'If cboTiposCierre.Text.Contains("MES") Then
        fec_ = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString
        'End If

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        sini_ = 0
        sfin_ = 0
        ''
        If Label48.Text.Trim <> "" Then sini_ = Val(Label48.Text)
        If lblStockActual.Text.Trim <> "" Then sfin_ = Val(lblStockActual.Text)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Tipo", cboTiposCierre.Text)
        cmd.Parameters.AddWithValue("@Fecha", DateTime.Parse(fec_))
        cmd.Parameters.AddWithValue("@Observs", txtObservs.Text)
        cmd.Parameters.AddWithValue("@SaldoInicial", sini_) 'Param4_SaldoInicial)
        cmd.Parameters.AddWithValue("@SaldoFinal", sfin_) ' Param5_SaldoFinal)
        cmd.Parameters.AddWithValue("@Estado", 0)                              '0=sin comparacion / 1=baston
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

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            RealizarCierreMensual = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function


    Public Sub CierreMensual()
        'If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim MSG1_ As String = "¿ DESEA CERRAR EL PERIODO SELECCIONADO (" + txtMes.Value.ToString.PadLeft(2, "0") + "-" + txtAnio.Value.ToString + "), PARA EL CENTRO " + cboCentros.Text + " ?"
        Dim MSG2_ As String = "NOTA: DEBE ENTREGAR LA DOCUMENTACIÓN A CONTABILIDAD."
        Dim MSG3_ As String = "ADVERTENCIA: UNA VEZ CERRADO EL PERIODO MENSUAL, LA INFORMACIÓN DEL PERIODO CERRADO NO PODRA SER MODIFICADA."

        If MsgBox(MSG1_ + vbCrLf + vbCrLf + MSG2_ + vbCrLf + vbCrLf + MSG3_, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If RealizarCierreMensual() = True Then

                If MsgBox("PERIODO CERRADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                End If

                'lvRESUMEN1.Items(0).SubItems(1).Text = "SI"
                'btnCierreMensual.Enabled = False

                'frmCierresIngreso.Enabled = True
                ActualizarDatos()

                'Me.Close()
            End If
        End If
    End Sub


    Private Function BuscaCierreMes() As Boolean
        BuscaCierreMes = False

        For Each itm As ListViewItem In lvRESUMEN1.Items
            If itm.SubItems(1).Text = "MES" Then
                BuscaCierreMes = True
                Exit Function
            End If
        Next
    End Function


    Private Sub ValidaBotonCierre()
        btnCierreMensual.Enabled = False
        btnDocumentacion.Enabled = False
        'btnImprime.Enabled = False
        btnEliminar.Enabled = False



        If cboCentros.SelectedIndex > 0 Then
            'si no existe un CIERRE MENSUAL en la grilla1, habilitamos botón de cierre y deshabilitamos botón de entrega de documentación
            If BuscaCierreMes() = False Then
                If cboTiposCierre.SelectedIndex > 0 Then
                    btnCierreMensual.Enabled = True
                End If

                btnDocumentacion.Enabled = False
            End If


            If lvRESUMEN1.SelectedItems.Count = 0 Then Exit Sub

            Dim cerrado_ As String = ""
            Dim docs_ As String = ""

            'If lvRESUMEN1.Items.Count > 0 Then cerrado_ = lvRESUMEN1.SelectedItems(0).SubItems(2).Text.Trim() 
            'If lvRESUMEN1.Items.Count > 0 Then docs_ = lvRESUMEN1.SelectedItems(0).SubItems(3).Text.Trim()
            cerrado_ = lvRESUMEN1.SelectedItems(0).SubItems(2).Text.Trim()
            docs_ = lvRESUMEN1.SelectedItems(0).SubItems(3).Text.Trim()

            'btnImprime.Enabled = True
            'btnExcel.Enabled = True

            'If cerrado_ <> "MES" Then
            '    If cboTiposCierre.SelectedIndex > 0 Then
            '        btnCierreMensual.Enabled = True
            '    End If

            '    btnDocumentacion.Enabled = False
            'End If

            If cerrado_ = "SI" And (docs_ = "" Or docs_ = "SI") Then
                btnDocumentacion.Enabled = True
                btnEliminar.Enabled = True
            End If


        End If
    End Sub


    Public Sub ActualizarDatos()
        lvRESUMEN1.Items.Clear() : lvRESUMEN1.Refresh()
        lvRESUMEN2.Items.Clear() : lvRESUMEN2.Refresh()

        lvRESUMEN1.BeginUpdate() ': lvRESUMEN1.SuspendLayout()
        lvRESUMEN2.BeginUpdate() ': lvRESUMEN2.SuspendLayout()

        ConsultaResumenCierrePorCentros()
        ConsultaResumenCierrePorCategorias()

        lvRESUMEN1.EndUpdate() ': lvRESUMEN1.ResumeLayout()
        lvRESUMEN2.EndUpdate() ': lvRESUMEN2.ResumeLayout()

        ValidaBotonCierre()

        'btnExcel.Enabled = True
    End Sub



    Private Function RealizarEntregaDocumentos() As Boolean
        RealizarEntregaDocumentos = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCierres_AsignarDocumentos2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim fec_ As Date

        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        fec_ = Convert.ToDateTime(lvRESUMEN1.SelectedItems(0).SubItems(18).Text)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", fec_)
        cmd.Parameters.AddWithValue("@Mes", txtMes.Value)
        cmd.Parameters.AddWithValue("@Anio", txtAnio.Value)
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

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            RealizarEntregaDocumentos = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function


    Private Function QuitarEntregaDocumentos() As Boolean
        QuitarEntregaDocumentos = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCierres_QuitarDocumentos2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim fec_ As Date

        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        fec_ = Convert.ToDateTime(lvRESUMEN1.SelectedItems(0).SubItems(18).Text)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", fec_)
        cmd.Parameters.AddWithValue("@Mes", txtMes.Value)
        cmd.Parameters.AddWithValue("@Anio", txtAnio.Value)
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

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            QuitarEntregaDocumentos = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function


    Private Function EliminarCierreMensual() As Boolean
        EliminarCierreMensual = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCierres_Eliminar2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300

        Dim cent_ As String = ""
        Dim fec_ As Date

        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        fec_ = Convert.ToDateTime(lvRESUMEN1.SelectedItems(0).SubItems(18).Text)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", fec_)
        cmd.Parameters.AddWithValue("@Mes", txtMes.Text)
        cmd.Parameters.AddWithValue("@Anio", txtAnio.Text)
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

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            EliminarCierreMensual = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function


    Private Function ValidaMovimientosPendientes() As Boolean
        ValidaMovimientosPendientes = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spValidaciones_ValidaAntesCierre", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        If cboCentros.SelectedIndex > 0 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Mes", txtMes.Value)
        cmd.Parameters.AddWithValue("@Anio", txtAnio.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ContVtasPendientes", SqlDbType.Int) : cmd.Parameters("@ContVtasPendientes").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ContAjtesPendientes", SqlDbType.Int) : cmd.Parameters("@ContAjtesPendientes").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ContTraspPendientes", SqlDbType.Int) : cmd.Parameters("@ContTraspPendientes").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Dim vta_pend As String = cmd.Parameters("@ContVtasPendientes").Value
            Dim aju_pend As String = cmd.Parameters("@ContAjtesPendientes").Value
            Dim tra_pend As String = cmd.Parameters("@ContTraspPendientes").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If vret = 100 Then
                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                Else
                    Dim msg As String = "EL PERIODO NO SE PUEDE CERRAR DEVIDO A QUE " + vbCrLf + "--- EXISTEN MOVIMIENTOS PENDIENTES ---" + vbCrLf + vbCrLf +
                        IIf(vta_pend > 0, "       - " + vta_pend.ToString.Trim + " VENTAS POR FINALIZAR" + vbCrLf, "") +
                        IIf(aju_pend > 0, "       - " + aju_pend.ToString.Trim + " AJUSTES POR CONFIRMAR" + vbCrLf, "") +
                        IIf(tra_pend > 0, "       - " + tra_pend.ToString.Trim + " TRASLADOS POR RECEPCIONAR", "")

                    If MsgBox(msg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                End If

                Cursor.Current = Cursors.Default
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            ValidaMovimientosPendientes = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function


    Public Sub EntregaDocumentos()
        If lvRESUMEN1.SelectedItems.Count = 0 Then Exit Sub

        Dim MSG_ As String = ""
        Dim con_docs_ As String = ""

        If lvRESUMEN1.Items.Count > 0 Then con_docs_ = lvRESUMEN1.SelectedItems(0).SubItems(3).Text.Trim()

        If con_docs_.Contains("SI") Then
            MSG_ = "¿ DESEA QUITAR LA ENTREGA DE DOCUMENTOS ?"
        Else
            MSG_ = "¿ DESEA CONFIRMAR LA ENTREGA DE DOCUMENTOS ?"
        End If


        If MsgBox(MSG_, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If con_docs_.Contains("SI") Then
                If QuitarEntregaDocumentos() = True Then
                    If MsgBox("GRABACION --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    End If
                End If
            Else
                If RealizarEntregaDocumentos() = True Then
                    If MsgBox("GRABACION --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    End If
                End If
            End If

            ActualizarDatos()
        End If
    End Sub


    Public Sub EliminarCierre()
        If lvRESUMEN1.SelectedItems.Count = 0 Then Exit Sub

        If BuscaCierreMes() = True And lvRESUMEN1.SelectedItems(0).SubItems(1).Text.Trim() <> "MES" Then
            MsgBox("NO SE PUEDE ELIMINAR PRE-CIERRE PORQUE -- EXISTE CIERRE MENSUAL --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim MSG_ As String = ""
        Dim con_docs_ As String = ""

        If lvRESUMEN1.Items.Count > 0 Then con_docs_ = lvRESUMEN1.SelectedItems(0).SubItems(3).Text.Trim()

        If con_docs_.Contains("SI") Then
            MSG_ = "¿ DESEA ELIMINAR EL CIERRE SELECCIONADO (RECUERDE QUE TIENE DOCUMENTACIÓN ENTREGADA) ?"
        Else
            MSG_ = "¿ DESEA ELIMINAR EL CIERRE SELECCIONADO ?"
        End If

        If MsgBox(MSG_, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            If EliminarCierreMensual() = True Then
                If MsgBox("CIERRE ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                End If
                ActualizarDatos()
            End If
        End If
    End Sub


    Private Sub mnuSalMuertes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalMuertes.Click
        frmMuertes.MdiParent = frmMAIN
        frmMuertes.Show()
        frmMuertes.BringToFront()

        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec1_ As String = "01/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString
        Dim fec2_ As String = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString

        frmMuertes.cboCentros.Text = cboCentros.Text
        frmMuertes.dtpFechaDesde.Value = DateTime.Parse(fec1_)
        frmMuertes.dtpFechaHasta.Value = DateTime.Parse(fec2_)

        frmMuertes.btnBuscar.PerformClick()
    End Sub


    Private Sub mnuSalVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalVentas.Click
        frmVentas2.MdiParent = frmMAIN
        frmVentas2.Show()
        frmVentas2.BringToFront()

        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec1_ As String = "01/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString
        Dim fec2_ As String = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString

        frmVentas2.cboCentros.Text = cboCentros.Text
        frmVentas2.dtpFechaDesde.Value = DateTime.Parse(fec1_)
        frmVentas2.dtpFechaHasta.Value = DateTime.Parse(fec2_)

        frmVentas2.btnBuscar.PerformClick()
    End Sub


    Private Sub mnuSalAjustes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalAjustes.Click
        frmAjustes.MdiParent = frmMAIN
        frmAjustes.Show()
        frmAjustes.BringToFront()

        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec1_ As String = "01/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString
        Dim fec2_ As String = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString

        frmAjustes.cboCentros.Text = cboCentros.Text
        frmAjustes.dtpFechaDesde.Value = DateTime.Parse(fec1_)
        frmAjustes.dtpFechaHasta.Value = DateTime.Parse(fec2_)
        frmAjustes.cboMovimientos.SelectedIndex = 1
        frmAjustes.cboEstados.SelectedIndex = 2

        frmAjustes.btnBuscar.PerformClick()
    End Sub


    Private Sub mnuSalTraslados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalTraslados.Click
        frmTraslados.MdiParent = frmMAIN
        frmTraslados.Show()
        frmTraslados.BringToFront()

        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec1_ As String = "01/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString
        Dim fec2_ As String = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString

        frmTraslados.cboCentros.Text = cboCentros.Text
        frmTraslados.dtpFechaDesde.Value = DateTime.Parse(fec1_)
        frmTraslados.dtpFechaHasta.Value = DateTime.Parse(fec2_)
        frmTraslados.cboTiposMovimientos.SelectedIndex = 1
        frmTraslados.cboEstados.SelectedIndex = 2

        frmTraslados.btnBuscar.PerformClick()
    End Sub


    Private Sub mnuEntTraslados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEntTraslados.Click
        frmTraslados.MdiParent = frmMAIN
        frmTraslados.Show()
        frmTraslados.BringToFront()

        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec1_ As String = "01/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString
        Dim fec2_ As String = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString

        frmTraslados.cboCentros.Text = cboCentros.Text
        frmTraslados.dtpFechaDesde.Value = DateTime.Parse(fec1_)
        frmTraslados.dtpFechaHasta.Value = DateTime.Parse(fec2_)
        frmTraslados.cboTiposMovimientos.SelectedIndex = 2
        frmTraslados.cboEstados.SelectedIndex = 2

        frmTraslados.btnBuscar.PerformClick()
    End Sub


    Private Sub mnuEntAjustes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEntAjustes.Click
        frmAjustes.MdiParent = frmMAIN
        frmAjustes.Show()
        frmAjustes.BringToFront()

        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec1_ As String = "01/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString
        Dim fec2_ As String = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString

        frmAjustes.cboCentros.Text = cboCentros.Text
        frmAjustes.dtpFechaDesde.Value = DateTime.Parse(fec1_)
        frmAjustes.dtpFechaHasta.Value = DateTime.Parse(fec2_)
        frmAjustes.cboMovimientos.SelectedIndex = 2
        frmAjustes.cboEstados.SelectedIndex = 2

        frmAjustes.btnBuscar.PerformClick()
    End Sub


    Private Sub mnuEntCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEntCompras.Click
        frmCompras.MdiParent = frmMAIN
        frmCompras.Show()
        frmCompras.BringToFront()

        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec1_ As String = "01/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString
        Dim fec2_ As String = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString

        frmCompras.cboCentros.Text = cboCentros.Text
        frmCompras.dtpFechaDesde.Value = DateTime.Parse(fec1_)
        frmCompras.dtpFechaHasta.Value = DateTime.Parse(fec2_)

        frmCompras.btnBuscar.PerformClick()
    End Sub


    Private Sub mnuEntNacimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEntNacimientos.Click
        frmPartos.MdiParent = frmMAIN
        frmPartos.Show()
        frmPartos.BringToFront()

        Dim days As Integer = System.DateTime.DaysInMonth(txtAnio.Value, txtMes.Value)
        Dim fec1_ As String = "01/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString
        Dim fec2_ As String = days.ToString.PadLeft(2, "0") + "/" + txtMes.Value.ToString.PadLeft(2, "0") + "/" + txtAnio.Value.ToString

        frmPartos.cboCentros.Text = cboCentros.Text
        frmPartos.dtpFechaDesde.Value = DateTime.Parse(fec1_)
        frmPartos.dtpFechaHasta.Value = DateTime.Parse(fec2_)

        frmPartos.btnBuscar.PerformClick()
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If procesa = 1 Then
            ActualizarDatos()
        End If

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ActualizarDatos()
    End Sub

    Private Sub btnCierreMensual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCierreMensual.Click

        If cboCentros.SelectedIndex <= 0 Then Exit Sub

        'cualquier sala que no sea area seca o ternerera debe realizar un pre-cierre antes del cierre mensual
        'If General.CentrosUsuario.EsSharedMilker(cboCentros.SelectedIndex - 1) = False And General.CentrosUsuario.EsTernerera(cboCentros.SelectedIndex - 1) = False Then


        '    If cboTiposCierre.Text.Contains("MENSUAL") And BuscaCierreMes() = True Then ' lvRESUMEN1.Items.Count = 2 Then
        '        MsgBox("CIERRE MENSUAL -- YA REALIZADO --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        '        Exit Sub
        '    End If
        'End If

        'If cboTiposCierre.Text.Contains("PRE-CIERRE") And lvRESUMEN1.Items.Count > 1 Then
        '    MsgBox("PRE-CIERRE -- YA REALIZADO --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
        '    Exit Sub
        'End If

        'If ValidaMovimientosPendientes() = False Then
        '    Exit Sub
        'End If

        If lblSaldoFinal.Text.Trim <> "" And lblStockActual.Text.Trim <> "" Then
            LeeBaston()
        Else
            CierreMensual()
        End If


    End Sub


    Private Sub btnImprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprime.Click
        Cursor.Current = Cursors.WaitCursor
        'If cboCentros.SelectedIndex = 0 Then
        '    frptCierreMensualGanado.CentroCod = lvRESUMEN1.SelectedItems(0).SubItems(17).Text
        'Else
        '    frptCierreMensualGanado.CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        'End If
        Try

            frptCierreMensualGanado.CentroCod = lvRESUMEN1.SelectedItems(0).SubItems(17).Text
        Catch ex As Exception

            If cboCentros.SelectedIndex = 0 Then
                Exit Sub
            Else

                frptCierreMensualGanado.CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
            End If

        End Try
        'General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        frptCierreMensualGanado.Mes = txtMes.Value
        frptCierreMensualGanado.Ano = txtAnio.Value
        frptCierreMensualGanado.Show()
        frptCierreMensualGanado.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnDocumentacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocumentacion.Click
        EntregaDocumentos()
    End Sub



    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvRESUMEN2.Items.Count <= 1 Then Exit Sub

        Dim tot(1, 15) As String '= {{"", ""}, {"", ""}}
        Dim linedate As String = ""


        tot(0, 0) = "TOTAL CIERRES " : tot(0, 1) = Label29.Text.Trim : tot(0, 2) = Label30.Text.Trim : tot(0, 3) = Label48.Text.Trim : tot(0, 4) = Label1.Text.Trim : tot(0, 5) = Label2.Text.Trim : tot(0, 6) = Label4.Text.Trim : tot(0, 7) = Label5.Text.Trim : tot(0, 8) = Label6.Text.Trim : tot(0, 9) = Label7.Text.Trim : tot(0, 10) = Label9.Text.Trim : tot(0, 11) = Label10.Text.Trim : tot(0, 12) = Label11.Text.Trim : tot(0, 13) = Label12.Text.Trim : tot(0, 14) = lblSaldoFinal.Text.Trim : tot(0, 15) = lblStockActual.Text.Trim

        ExportToExcelGrillaCierre(lvRESUMEN1, tot, linedate, 1)

        If lvRESUMEN2.Items.Count = 0 Then Exit Sub

        tot(0, 0) = "TOTAL MOVIMIENTOS DE CIERRE POR CATEGORIA " : tot(0, 3) = Label25.Text.Trim : tot(0, 4) = Label24.Text.Trim : tot(0, 5) = Label23.Text.Trim : tot(0, 6) = Label22.Text.Trim : tot(0, 7) = Label21.Text.Trim : tot(0, 8) = Label20.Text.Trim : tot(0, 9) = Label19.Text.Trim : tot(0, 10) = Label18.Text.Trim : tot(0, 11) = Label17.Text.Trim : tot(0, 12) = Label16.Text.Trim : tot(0, 13) = Label15.Text.Trim : tot(0, 14) = Label14.Text.Trim : tot(0, 15) = Label28.Text.Trim

        ExportToExcelGrillaCierre(lvRESUMEN2, tot, linedate, 2)
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub frmCierresIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        'Me.KeyPreview = True

        CboLLenaCentros()
        txtMes.Value = Now.Month
        txtAnio.Value = Now.Year

        cboTiposCierre.SelectedIndex = 2
        cboTiposCierre.Enabled = False

        'solo si es jefe produccion (3) o administrador sistema (5)
        If UsuarioEliminaCierre = 1 Then
            btnEliminar.Visible = True
        End If

        'si el perfil es mayor o igual a gerencia tecnica (4), habilitamos boton de documentacion
        If PerfilUsuario >= 4 Then
            btnDocumentacion.Visible = True

            If btnEliminar.Visible = False Then
                btnExcel.Left = btnImprime.Left + btnImprime.Width + 6
            End If
        Else
            btnDocumentacion.Visible = False
            btnImprime.Left = btnDocumentacion.Left

            If btnEliminar.Visible = True Then
                btnEliminar.Left = btnImprime.Left + btnImprime.Width + 6
                btnExcel.Left = btnEliminar.Left + btnEliminar.Width + 6
            Else
                btnExcel.Left = btnImprime.Left + btnImprime.Width + 6
            End If
        End If

        cboCentros.SelectedIndex = 0
        EnEventoLoad = False
        ActualizarDatos()
        procesa = 1
    End Sub



    Private Sub btnEliminar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        EliminarCierre()
    End Sub



    'Private Sub txtAnio_LostFocus(sender As Object, e As System.EventArgs) Handles txtMes.ValueChanged, txtAnio.LostFocus
    '    If EnEventoLoad = True Then Exit Sub
    '    ActualizarDatos()
    'End Sub



    Private Sub txtMes_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtMes.ValueChanged, txtAnio.ValueChanged
        If procesa = 1 Then

            ActualizarDatos()
        End If

        btnCierreMensual.Enabled = False
        btnDocumentacion.Enabled = False
        'btnImprime.Enabled = False
        btnEliminar.Enabled = False

        'btnExcel.Enabled = False

    End Sub


    Private Sub mnuDetalleCierre_Click(sender As System.Object, e As System.EventArgs) Handles mnuVerDetalle.Click
        If lvRESUMEN1.SelectedItems.Count = 0 Then Exit Sub

        If mnuVerDetalle.Text.Contains("Cierre") Then
            ''consultamos detalle cierre
            Dim cent_ As String = lvRESUMEN1.SelectedItems(0).SubItems(17).Text
            Dim fec_ As String = lvRESUMEN1.SelectedItems(0).SubItems(18).Text
            Dim fcdet As New frmCierresDetalle

            Cursor.Current = Cursors.WaitCursor

            With fcdet
                .Param1_Centro = cent_
                .Param2_Anio = txtAnio.Value
                .Param3_Mes = txtMes.Value
                .Param4_Fecha = Convert.ToDateTime(fec_)

                .txtCentro.Text = lvRESUMEN1.SelectedItems(0).SubItems(0).Text
                .txtAnio.Value = txtAnio.Value
                .txtMes.Value = txtMes.Value

                .ConsultaDetalleCierre()

                .MdiParent = frmMAIN
                .Show()
                .BringToFront()
            End With
        Else
            ''consultamos stock de ganado
            With frmConsultaGeneral



                '.chklvCentros.selec

                .MdiParent = frmMAIN
                .Show()
                .BringToFront()


                For i As Integer = 0 To .chklvCentros.Items.Count - 1
                    If .chklvCentros.Items(i).ToString = lvRESUMEN1.SelectedItems(0).SubItems(0).Text Then
                        .chklvCentros.SetItemCheckState(i, CheckState.Checked)
                    End If
                Next

                .btnBuscar.PerformClick()
            End With
        End If
    End Sub



    Private Sub lvRESUMEN1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvRESUMEN1.MouseClick
        If e.Button = MouseButtons.Right = True Then
            If lvRESUMEN1.SelectedItems(0).SubItems(2).Text = "SI" Then
                mnuVerDetalle.Text = "        Ver Detalle Cierre"
            Else
                mnuVerDetalle.Text = "        Ver Detalle Stock"
            End If
        End If
    End Sub

    Private Sub lvRESUMEN1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvRESUMEN1.SelectedIndexChanged
        ValidaBotonCierre()
    End Sub

    Private Sub cboTiposCierre_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTiposCierre.SelectedIndexChanged
        ValidaBotonCierre()
    End Sub
End Class