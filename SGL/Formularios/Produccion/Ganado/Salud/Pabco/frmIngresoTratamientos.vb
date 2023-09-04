Imports System.Data.SqlClient

Public Class frmIngresoTratamientos

    Private fnPabcoDetalle As New fnPabcoDetalle
    Private Horario As Integer = 1
    Dim Lotes As String = ""
    Dim Patologias As String = ""
    Dim CodPatologia As Integer = 0
    Dim Preventivo As Integer = 0
    Dim Medicamento As String = ""
    Dim CodMedGP As Integer = 0
    Dim CodMedicamento As Integer = 0
    Dim DiasTratamiento As Integer = 0
    Dim DiasResguardo As Integer = 0
    Dim GlosaTratamiento As String = ""
    Dim DiasCarne As Integer = 0
    Dim ReqCuartos As String = ""
    Dim TipoCarga As String = ""
    Dim DiasTrat As Integer
    Dim TratDosis As String = ""
    Public Actualizar As String = ""

    Private Sub frmIngresoTratamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        General.Patologias.Cargar()
        CboLLenaCentros()
        CboLLenaMedicmentos()
        UnidadMedida()
        CantidadMedida()
        CantidadVeces()
        Horas()
        'CboLLenaPatologias(cboPatologias, False)
        btnActualizar.Visible = False
        MSTRPatologias.DSCboPatologias_FrmQRY(cboPatologias)
        MSTRPatologias.DSCboMedicamentos_FrmQRY(Medicamentos, CodPatologia)

        dtpFechaInicio.Value = Now
        dtpFecha.Value = Now
        rbtnAM.Checked = True
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        'cboCentros.Items.Add("(Seleccionar)")
        Dim CodigoCentro As List(Of Centros) = New List(Of Centros)
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            'cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
            CodigoCentro.Add(New Centros With {
                             .Codigo1 = General.CentrosUsuario.Codigo(i),
                             .Nombre1 = General.CentrosUsuario.Nombre(i)})
        Next
        cboCentros.DataSource = CodigoCentro
        cboCentros.ValueMember = "Codigo1"
        cboCentros.DisplayMember = "Nombre1"
        'cboCentros.SelectedIndex = 0
    End Sub

    Private Function ValidacionesLocales(ByVal baston As Integer) As Boolean
        ValidacionesLocales = False

        If txtDIIO.Text.Trim = "" And baston <> 1 Then
            If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If gbCuartos.Enabled = True Then
            If Not (chkAD.Checked) And Not (chkAI.Checked) And Not (chkPD.Checked) And Not (chkPI.Checked) Then
                MsgBox("DEBE SELECCIONAR CUARTOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                Exit Function
            End If
        End If

        If lblCategoria.Text.Trim = "---" And baston <> 1 Then
            If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If cboCentros.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If cboPatologias.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UNA PATOLOGÍA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If Medicamentos.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UN MEDICAMENTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If txtDiasTrat.Text = "" Then
            If MsgBox("DEBE INGRESAR UN NUMERO DE DIAS DE TRATAMIENTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDiasTrat.Focus()
            Exit Function
        End If
        'If Val(txtDiasTrat.Text) < General.Medicamentos.DiasDuracion(Medicamentos.SelectedIndex) Then
        '    If MsgBox("LOS DIAS DE TRATAMIENTOS NO PUEDE SER MENOR AL ESPECIFICADO POR EL MEDICAMENTO (" + General.Medicamentos.DiasDuracion(Medicamentos.SelectedIndex).ToString + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtDiasTrat.Text = General.Medicamentos.DiasDuracion(Medicamentos.SelectedIndex)
        '    txtDiasTrat.Focus()
        '    Exit Function
        'End If

        ValidacionesLocales = True
    End Function
    Private Sub CboLLenaMedicmentos()
        If General.Medicamentos.NroRegistros = 0 Then Exit Sub

        Medicamentos.Items.Clear()


        Dim i As Integer

        For i = 0 To General.Medicamentos.NroRegistros - 1
            Medicamentos.Items.Add(General.Medicamentos.Nombre(i))
        Next
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
    End Sub
    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text.Trim = "(Selecconar)" Then ' Label15.Text Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
            End If
            txtDIIO.Text = ""
            cboCentros.Focus()
            Exit Sub
        End If


        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim fup_, fpp_, fsec_, fultmas_ As String
        'Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fup_ = ""
        fpp_ = ""
        fsec_ = ""
        fultmas_ = ""
        'EstadoSecado = ""

        Dim evend As String = ""
        Dim emue As String = ""
        Dim edesap As String = ""
        Dim fult_ As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            'LimpiaDatos()

            Try
                While rdr.Read()
                    Existe = True
                    fultmas_ = Format(rdr("GndMastitisFecUlt"), "dd-MM-yyyy")
                    evend = rdr("GndIsVendido").ToString.Trim
                    emue = rdr("GndIsMuerto").ToString.Trim
                    edesap = rdr("GndIsDesaparecido").ToString.Trim
                    fult_ = Format(rdr("GndOtrostratamientosFecUlt"), "dd-MM-yyyy")
                    If fult_.Contains("1900") Then fult_ = ""


                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text And Actualizar <> "SI" Then ' Label15.Text Then
                        If MsgBox("EL DIIO NO PERTENECE AL CENTRO SELECCIONADO (" + rdr("CenDesCor").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                        End If

                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                        Exit Try
                    End If

                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
                    lblNroOtrosTrat.Text = rdr("GndOtrosTratamientosNum").ToString.Trim
                    lblNroMastitis.Text = rdr("GndMastitisNum").ToString.Trim
                    If fult_ <> "01-01-1753" Then
                        lblUltimaOtrosTrat.Text = Format(rdr("GndOtrostratamientosFecUlt"), "dd-MM-yyyy")
                    Else
                        lblUltimaOtrosTrat.Text = ""
                    End If

                    If fultmas_ <> "01-01-1753" Then
                        lblUltimaMastitis.Text = Format(rdr("GndMastitisFecUlt"), "dd-MM-yyyy")
                    Else
                        lblUltimaMastitis.Text = ""
                    End If

                    If evend = "SI" Then
                        lblEstado.Text = "VENDIDO"
                    ElseIf emue = "SI" Then
                        lblEstado.Text = "MUERTO"
                    ElseIf edesap = "SI" Then
                        lblEstado.Text = "DESAPARECIDO"
                    Else
                        lblEstado.Text = "STOCK"
                    End If

                    Exit While
                End While


                If Existe = False Then
                    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                Else

                    btnAgregar.Enabled = True
                End If

                If lblEstado.Text <> "STOCK" Then
                    MsgBox("ESTE ANIMAL ESTA " + lblEstado.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA")
                    btnAgregar.Enabled = False
                Else
                    btnAgregar.Enabled = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        TipoCarga = "MANUAL"
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtDiasTrat_TextChanged(sender As Object, e As EventArgs) Handles txtDiasTrat.TextChanged, Medicamentos.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(Medicamentos.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            CodMedGP = selectedRow("MedCodGP")
            CodMedicamento = selectedRow("MedCodigo")
            Medicamento = selectedRow("MedNombre")
            DiasResguardo = selectedRow("TratResguardoLeche")
            DiasCarne = selectedRow("TratResguardoCarne")
            TratDosis = selectedRow("TratDosis")
        End If
        CalcularDias()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaInicio.ValueChanged
        CalcularDias()

    End Sub
    Private Sub CalcularDias()
        If Medicamentos.SelectedIndex = -1 And Medicamentos.Text = "" Then Exit Sub
        If Not IsNumeric(txtDiasTrat.Text) Then Exit Sub

        Dim diastrat_ As Integer = 0
        Dim diasres_ As Integer = 0
        Dim diasresCarne_ As Integer = 0

        diastrat_ = txtDiasTrat.Text
        diasres_ = DiasResguardo
        diasresCarne_ = DiasCarne

        lblDiasResg.Text = DiasResguardo
        lblDiasResgCarne.Text = DiasCarne
        lblDosisSugerida.Text = TratDosis

        lblFechaTermino.Text = Format(DateAdd(DateInterval.Day, diastrat_, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")

        If DiasResguardo = 0 Then
            lblFechaLiberacion.Text = dtpFechaInicio.Value
        Else
            lblFechaLiberacion.Text = Format(DateAdd(DateInterval.Day, diastrat_ + diasres_, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")
        End If

        If DiasCarne = 0 Then
            lblFechaLiberacionCarne.Text = dtpFechaInicio.Value
        Else
            lblFechaLiberacionCarne.Text = Format(DateAdd(DateInterval.Day, diastrat_ + diasresCarne_, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")
        End If
    End Sub

    Private Sub Medicamentos_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(0) = False Then Exit Sub
        Dim n As Integer
        Dim Diio As Integer = txtDIIO.Text
        Dim FechaInicio As DateTime = dtpFechaInicio.Value
        n = lvDetalle.Items.Count.ToString
        For i = 0 To n - 1
            If txtDIIO.Text.Trim = lvDetalle.Items(i).SubItems(2).Text.Trim And General.Patologias.Codigo(cboPatologias.SelectedIndex) = lvDetalle.Items(i).SubItems(10).Text.Trim And CodMedicamento = lvDetalle.Items(i).SubItems(12).Text.Trim Then
                If MsgBox("Diio ya ingresado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    LimpiarControles()
                    Exit Sub
                End If
            End If
        Next

        Dim itm As New ListViewItem((lvDetalle.Items.Count + 1).ToString)
        Dim numDiios As Integer = lblTotDiios.Text
        itm.SubItems.Add(cboCentros.Text)
        itm.SubItems.Add(txtDIIO.Text)
        itm.SubItems.Add(lblCategoria.Text)
        itm.SubItems.Add(lblEstProductivo.Text)
        itm.SubItems.Add(lblEstReproductivo.Text)
        itm.SubItems.Add(lblEstado.Text)
        itm.SubItems.Add(CDate(dtpFecha.Text))
        itm.SubItems.Add(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        itm.SubItems.Add("")
        itm.SubItems.Add(General.Patologias.Codigo(cboPatologias.SelectedIndex))
        itm.SubItems.Add(cboPatologias.Text)
        itm.SubItems.Add(CodMedicamento)
        itm.SubItems.Add(Medicamentos.Text)
        itm.SubItems.Add(txtDiasTrat.Text)
        itm.SubItems.Add(CDate(dtpFechaInicio.Text)) ''itms.SubItems.Add(dtpFechaInicio.Value)
        itm.SubItems.Add(CDate(lblFechaTermino.Text))
        If chkAI.Checked = True Then
            itm.SubItems.Add("SI")
        Else
            itm.SubItems.Add("NO")
        End If
        If chkAD.Checked = True Then
            itm.SubItems.Add("SI")
        Else
            itm.SubItems.Add("NO")
        End If
        If chkPI.Checked = True Then
            itm.SubItems.Add("SI")
        Else
            itm.SubItems.Add("NO")
        End If
        If chkPD.Checked = True Then
            itm.SubItems.Add("SI")
        Else
            itm.SubItems.Add("NO")
        End If
        itm.SubItems.Add(CDate(lblFechaLiberacion.Text))
        itm.SubItems.Add(CDate(lblFechaLiberacionCarne.Text))
        itm.SubItems.Add(lblDiasResg.Text)
        itm.SubItems.Add(lblDiasResgCarne.Text)
        itm.SubItems.Add(TextBox1.Text)
        itm.SubItems.Add(cboCantidades.Text)
        itm.SubItems.Add(cboUniMedida.Text)
        If chbcojera.Checked = True Then
            itm.SubItems.Add("SI")
        Else
            itm.SubItems.Add("NO")
        End If
        itm.SubItems.Add(CodMedGP)
        If ConsultaTratamientoDiio(Diio, FechaInicio) = True Then
            itm.BackColor = Color.Yellow
            itm.SubItems.Add("Diio esta con tratamiento")
        Else
            itm.SubItems.Add("")
        End If
        itm.SubItems.Add(cboHra.Text)
        itm.SubItems.Add(cboCantidadVeces.Text)
        lvDetalle.Items.Add(itm)
        numDiios = numDiios + 1
        btnGrabar.Enabled = True
        lblTotDiios.Text = numDiios

        Dim num As Integer
        num = lvDetalle.Items.Count.ToString
        Dim numErrores As Integer = lblTotErrores.Text
        For i = 0 To num - 1
            If lvDetalle.Items(i).SubItems(1).Text.Contains("Pertenece") Or lvDetalle.Items(i).SubItems(1).Text.Trim = "Sin Sala" Or lvDetalle.Items(i).SubItems(6).Text.Trim <> "STOCK" Or lvDetalle.Items(i).SubItems(2).Text.Trim = "DIIO No Existe" Then
                lvDetalle.Items(i).BackColor = Color.Red
                numErrores = numErrores + 1
            End If
        Next
        lblErrores.Text = numErrores
        btnBastonLee.Enabled = False
        btnActualizar.Enabled = True
        LimpiarControles()
    End Sub
    Private Sub LimpiarControlesElim()

        If Actualizar = "SI" Then
            btnActualizar.Enabled = False
            Exit Sub
        End If

        If lvDetalle.Items.Count > 0 Then
            cboCentros.Enabled = False
            dtpFecha.Enabled = False
        Else
            cboCentros.Enabled = True
            dtpFecha.Enabled = True
        End If
        txtDIIO.Text = ""
        lblNroMastitis.Text = "---"
        lblUltimaMastitis.Text = "---"
        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        lblNroOtrosTrat.Text = "---"
        lblUltimaOtrosTrat.Text = "---"
        lblEstado.Text = "---"
    End Sub
    Private Sub LimpiarControles()
        If Actualizar = "SI" Then
            Exit Sub
        End If

        If lvDetalle.Items.Count > 0 Then
            cboCentros.Enabled = False
            dtpFecha.Enabled = False
        Else
            cboCentros.Enabled = True
            dtpFecha.Enabled = True
        End If
        chkAD.Checked = False
        chkAI.Checked = False
        chkPD.Checked = False
        chkPI.Checked = False
        txtDIIO.Text = ""
        lblNroMastitis.Text = "---"
        lblUltimaMastitis.Text = "---"
        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        lblNroOtrosTrat.Text = "---"
        lblUltimaOtrosTrat.Text = "---"
        lblEstado.Text = "---"
        TextBox1.Text = ""
        'txtDiasTrat.Text = ""
        'lblFechaLiberacion.Text = ""
        'lblFechaLiberacionCarne.Text = ""
        'lblDiasResg.Text = ""
        'lblDiasResgCarne.Text = ""
        'lblFechaTermino.Text = ""
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿ DESEA ELIMINAR TODOS LOS ERRORES SELECCIONADOS? ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        Dim totaldiios As Integer = lblTotDiios.Text
        For Each it As ListViewItem In lvDetalle.SelectedItems
            lvDetalle.Items.Remove(it)
            totaldiios = totaldiios - 1
        Next
        lblTotDiios.Text = totaldiios
        Dim numErrores As Integer = 0
        Dim num As Integer
        num = lvDetalle.Items.Count.ToString
        For i = 0 To num - 1
            If lvDetalle.Items(i).BackColor = Color.Red Then
                numErrores = numErrores + 1
            End If
        Next
        lblErrores.Text = numErrores

        LimpiarControlesElim()

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim num As Integer
        num = lvDetalle.Items.Count.ToString
        For i = 0 To num - 1
            If lvDetalle.Items(i).BackColor = Color.Red Then
                If MsgBox("PARA GRABAR DATOS, ELIMINAR ERRORES", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
        Next
        If lvDetalle.Items.Count = 0 Then
            If MsgBox("Debe ingresar al menos 1 registro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarPabco() = True Then
            Me.Dispose()
            Me.Close()
            frmListadoTratamientos.btnBuscar.PerformClick()

        End If
    End Sub


    Private Sub txtDiasTrat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasTrat.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDiasTrat.Text = txtDiasTrat.Text.Trim
            e.Handled = True
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cboPatologias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPatologias.SelectedIndexChanged
        'General.Medicamentos.Cargar()
        'Medicamentos.Items.Clear()
        'CboLLenaMedicmentos()
        'ConsultaPatologia(cboPatologias.Text)
        'Cuartos()

        Dim selectedRow As DataRowView = DirectCast(cboPatologias.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then
            CodPatologia = selectedRow("CodPatologia")
            Patologias = selectedRow("NomPatologia")
            ReqCuartos = selectedRow("ReqCuartos")
            Preventivo = selectedRow("EsPreventivo")

            If Preventivo = 1 Then
                lblPreventivo.Visible = True
            Else
                lblPreventivo.Visible = False
            End If

            If ReqCuartos = "SI" Then
                gbCuartos.Enabled = True
            Else
                gbCuartos.Enabled = False
                chkAD.Checked = False
                chkAI.Checked = False
                chkPD.Checked = False
                chkPI.Checked = False
            End If
            cboMedicamentos(CodPatologia)
        End If

    End Sub

    Public Function ConsultaPatologia(ByVal Patologia As String) As Boolean
        ConsultaPatologia = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_ConsultaCojera", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Patologia", Patologia)
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret = 0 Then
                chbcojera.Checked = False
            Else
                chbcojera.Checked = True
            End If

            ConsultaPatologia = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
    Private Sub btnBastonLee_Click(sender As Object, e As EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales(1) = False Then Exit Sub
        LeeBaston()
        btnGrabar.Enabled = True
    End Sub
    Private Sub LeeBaston()
        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmPabco"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            If frmBastonV2.cboTipoBaston.SelectedText.Contains("EXCEL") Then
                TipoCarga = "EXCEL"
            Else
                TipoCarga = "BASTON"
            End If
            ProcesaBaston()
            Lotes = "SI"
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub
    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim numErrores As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        Dim inichk_ As Integer = lvDetalle.Items.Count '- 1

        Cursor.Current = Cursors.WaitCursor

        lvDetalle.Items.Clear()
        fnPabcoDetalle.DtExcelCrear()
        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","
            fnPabcoDetalle.DtExcel(diio_)

        Next
        ConsultaListadoExcel()
        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If
        Dim num As Integer
        num = lvDetalle.Items.Count.ToString
        For i = 0 To num - 1
            If lvDetalle.Items(i).SubItems(1).Text.Contains("Pertenece") Or lvDetalle.Items(i).SubItems(1).Text.Trim = "Sin Sala" Or lvDetalle.Items(i).SubItems(6).Text.Trim <> "STOCK" Or lvDetalle.Items(i).SubItems(2).Text.Trim = "DIIO No Existe" Then
                lvDetalle.Items(i).BackColor = Color.Red
                numErrores = numErrores + 1
            End If
        Next
        btnBuscar.Enabled = False
        lblErrores.Text = numErrores
        fnPabcoDetalle.VaciaDatatable()
        btnAgregar.Enabled = False
        Cursor.Current = Cursors.Default
    End Sub
    Public Sub ConsultaListadoExcel()
        Dim Centro As String
        Dim numDiios As Integer = 0
        Dim Categoria As String
        Dim Estado As String
        Dim diio As String
        Dim EstProductivo As String
        Dim EstReProductivo As String
        Dim CodCentro As String
        Dim CodCategoria As String
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_ListadoExcel", con)
        Dim rdr As SqlDataReader = Nothing
        Dim FechaTrat As String
        Dim DiasTrat As Integer
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.AddWithValue("@TablaDetalle", fnPabcoDetalle.DetallesExcel)
        lvDetalle.BeginUpdate()
        lvDetalle.Items.Clear()
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()

                    diio = rdr("diio").ToString.Trim
                    FechaTrat = rdr("TratInicioTratamiento").ToString.Trim
                    DiasTrat = rdr("TratDiasTratamiento")
                    If rdr("centro").ToString.Trim = "" Then
                        Centro = "Sin Sala"
                    Else
                        Centro = rdr("centro").ToString.Trim
                    End If

                    Categoria = rdr("categoria").ToString.Trim

                    EstProductivo = rdr("productivo").ToString.Trim
                    EstReProductivo = rdr("reproductivo").ToString.Trim

                    CodCentro = rdr("GndCenCod").ToString.Trim
                    CodCategoria = rdr("GndProCod").ToString.Trim

                    If rdr("desaparecido").ToString.Trim = "SI" Then
                        Estado = "Desaparecido"
                    ElseIf rdr("vendido").ToString.Trim = "SI" Then
                        Estado = "Vendido"
                    ElseIf rdr("muerto").ToString.Trim = "SI" Then
                        Estado = "Muerto"
                    Else
                        Estado = "STOCK"
                    End If

                    Dim itm As New ListViewItem((lvDetalle.Items.Count + 1).ToString)

                    If Centro <> cboCentros.Text Then
                        itm.SubItems.Add("No Pertenece, centro diio:" + Centro)
                    Else
                        itm.SubItems.Add(Centro)
                    End If
                    itm.SubItems.Add(diio)
                    itm.SubItems.Add(Categoria)
                    itm.SubItems.Add(EstProductivo)
                    itm.SubItems.Add(EstReProductivo)
                    itm.SubItems.Add(Estado)
                    itm.SubItems.Add(CDate(dtpFecha.Text))
                    itm.SubItems.Add(CodCentro)
                    itm.SubItems.Add(CodCategoria)
                    itm.SubItems.Add(General.Patologias.Codigo(cboPatologias.SelectedIndex))
                    itm.SubItems.Add(cboPatologias.Text)
                    itm.SubItems.Add(CodMedicamento)
                    itm.SubItems.Add(Medicamentos.Text)
                    itm.SubItems.Add(txtDiasTrat.Text)
                    itm.SubItems.Add(CDate(dtpFechaInicio.Text)) ''itms.SubItems.Add(dtpFechaInicio.Value)
                    itm.SubItems.Add(CDate(lblFechaTermino.Text))
                    If chkAI.Checked = True Then
                        itm.SubItems.Add("SI")
                    Else
                        itm.SubItems.Add("NO")
                    End If
                    If chkAD.Checked = True Then
                        itm.SubItems.Add("SI")
                    Else
                        itm.SubItems.Add("NO")
                    End If
                    If chkPI.Checked = True Then
                        itm.SubItems.Add("SI")
                    Else
                        itm.SubItems.Add("NO")
                    End If
                    If chkPD.Checked = True Then
                        itm.SubItems.Add("SI")
                    Else
                        itm.SubItems.Add("NO")
                    End If
                    itm.SubItems.Add(CDate(lblFechaLiberacion.Text))
                    itm.SubItems.Add(CDate(lblFechaLiberacionCarne.Text))
                    itm.SubItems.Add(lblDiasResg.Text)
                    itm.SubItems.Add(lblDiasResgCarne.Text)
                    itm.SubItems.Add(TextBox1.Text)
                    itm.SubItems.Add(cboCantidades.Text)
                    itm.SubItems.Add(cboUniMedida.Text)

                    If chbcojera.Checked = True Then
                        itm.SubItems.Add("SI")
                    Else
                        itm.SubItems.Add("NO")
                    End If
                    itm.SubItems.Add(CodMedGP)
                    If DateAdd("d", DiasTrat, CDate(FechaTrat)) >= Today() Then
                        itm.BackColor = Color.Yellow
                        itm.SubItems.Add("Diio esta con tratamiento")
                    Else
                        itm.SubItems.Add("")
                    End If
                    If EstProductivo = "EN PRODUCCION" Then
                        If CodMedicamento = 22 Or CodMedicamento = 19 Or CodMedicamento = 123 Then
                            itm.BackColor = Color.Red
                        End If
                    End If
                    itm.SubItems.Add(cboHra.Text)
                    itm.SubItems.Add(cboCantidadVeces.Text)
                    If rdr("FechaEntradaCentro") > dtpFechaInicio.Value And rdr("FechaEntradaCentro").ToString.Trim <> "" Then
                        itm.BackColor = Color.Red
                        itm.SubItems.Add("Fecha seleccionada, el Diio se econtraba en otro centro")
                    Else
                        itm.SubItems.Add("")
                    End If
                    lvDetalle.Items.Add(itm)
                    numDiios = numDiios + 1
                End While


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
        lvDetalle.EndUpdate()
        lblTotDiios.Text = numDiios
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("¿ DESEA ELIMINAR TODOS LOS ERRORES? ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If


        Dim numErrores As Integer = lblErrores.Text
        Dim totaldiios As Integer = lblTotDiios.Text
        Dim num As Integer
        num = lvDetalle.Items.Count.ToString
        For i = num - 1 To 0 Step -1
            If lvDetalle.Items(i).BackColor = Color.Red Then
                lvDetalle.Items.RemoveAt(i)
                numErrores = numErrores - 1
                totaldiios = totaldiios - 1
            End If
        Next
        lblTotDiios.Text = totaldiios
        lblErrores.Text = numErrores
        LimpiarControlesElim()
    End Sub
    Private Function GrabarPabco() As Boolean
        Dim centro As String = cboCentros.SelectedValue
        Dim TratCodigo As Integer = 0

        If Actualizar = "SI" Then
            TratCodigo = lblTratCodigo.Text
        End If

        GrabarPabco = False
        If fnPabcoDetalle.GrabarPabco(lvDetalle, centro, dtpFecha.Value, Horario, Lotes, Actualizar, TratCodigo, TipoCarga, Preventivo) = True Then
            GrabarPabco = True
        End If

    End Function

    Private Sub lvDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvDetalle.SelectedIndexChanged

    End Sub

    Private Sub rbtnAM_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnAM.CheckedChanged
        If rbtnAM.Checked = True Then
            Horario = 1
            rbtnPM.Checked = False
        End If
    End Sub

    Private Sub rbtnPM_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnPM.CheckedChanged
        If rbtnPM.Checked = True Then
            Horario = 2
            rbtnAM.Checked = False
        End If

    End Sub

    Private Sub txtDIIO_TextChanged(sender As Object, e As EventArgs) Handles txtDIIO.TextChanged

    End Sub

    Private Sub txtDIIO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
            e.Handled = True
        End If
    End Sub

    Private Function Cuartos() As Boolean
        Cuartos = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientoPabco_Cuartos", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@PatologiaCod", cboPatologias.SelectedValue)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error de Validaciones") = vbOK Then
                End If
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cuartos = True
    End Function
    Private Sub cboMedicamentos(ByVal patologia As Integer)
        'Medicamentos.Items.Clear()
        MSTRPatologias.DSCboMedicamentos_FrmQRY(Medicamentos, CodPatologia)
    End Sub

    Private Sub txtDiasTrat_Leave(sender As Object, e As EventArgs) Handles txtDiasTrat.Leave
        CalcularDias()
    End Sub

    Public Sub lvDetalle_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvDetalle.MouseDoubleClick
        If lvDetalle.Items.Count = 0 Then Exit Sub
        Dim Diio As String = lvDetalle.SelectedItems.Item(0).SubItems(2).Text
        Dim UMedida As String = lvDetalle.SelectedItems.Item(0).SubItems(27).Text

        frmPabcoDetalleTratamiento.DIIO = Diio
        frmPabcoDetalleTratamiento.lblUMedida.Text = UMedida
        frmPabcoDetalleTratamiento.ShowDialog()
        'frmPabcoDetalleTratamiento.ConsultaTratamiento(Diio)

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If gbCuartos.Enabled = True Then
            If Not (chkAD.Checked) And Not (chkAI.Checked) And Not (chkPD.Checked) And Not (chkPI.Checked) Then
                MsgBox("DEBE SELECCIONAR CUARTOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                Exit Sub
            End If
        End If

        If MsgBox("¿ DESEA GRABAR LOS CAMBIOS REALIZADOS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarPabco() = True Then
            Me.Dispose()
            Me.Close()
            frmListadoTratamientos.btnBuscar.PerformClick()

        End If
    End Sub
    Private Sub UnidadMedida()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPabco_UnidadMedida", con)
        Dim rdr As SqlDataReader = Nothing

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        da.SelectCommand = cmd
        da.Fill(dt)

        cboUniMedida.ValueMember = "UMCod"
        cboUniMedida.DisplayMember = "UMNom"
        cboUniMedida.DataSource = dt
    End Sub
    Private Sub CantidadMedida()

        Dim dt As DataTable = New DataTable("Tabla")

        dt.Columns.Add("Codigo")
        dt.Columns.Add("Cantidad")

        Dim dr As DataRow
        Dim count As Integer = 0

        dr = dt.NewRow()
        dr("Codigo") = "0"
        dr("Cantidad") = 0.1
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "1"
        dr("Cantidad") = 0.5
        dt.Rows.Add(dr)

        For i = 1 To 10
            count = count + 1
            dr = dt.NewRow()
            dr("Codigo") = count
            dr("Cantidad") = i
            dt.Rows.Add(dr)
        Next

        For i = 15 To 50 Step 5
            count = count + 1
            dr = dt.NewRow()
            dr("Codigo") = count
            dr("Cantidad") = i
            dt.Rows.Add(dr)
        Next

        dr = dt.NewRow()
        dr("Codigo") = count + 1
        dr("Cantidad") = 100
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = count + 2
        dr("Cantidad") = 250
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = count + 3
        dr("Cantidad") = 500
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = count + 4
        dr("Cantidad") = "40-30-30" ' valor solo para Dexabiopen 
        dt.Rows.Add(dr)

        cboCantidades.DataSource = dt
        cboCantidades.ValueMember = "Codigo"
        cboCantidades.DisplayMember = "Cantidad"

    End Sub

    Private Sub CantidadVeces()

        Dim dt As DataTable = New DataTable("Tabla")

        dt.Columns.Add("Codigo")
        dt.Columns.Add("Cantidad")

        Dim dr As DataRow
        Dim count As Integer = 0

        For i = 1 To 10
            dr = dt.NewRow()
            dr("Codigo") = count
            dr("Cantidad") = i
            dt.Rows.Add(dr)
            count = count + 1
        Next

        cboCantidadVeces.DataSource = dt
        cboCantidadVeces.ValueMember = "Codigo"
        cboCantidadVeces.DisplayMember = "Cantidad"
    End Sub
    Private Sub Horas()

        Dim dt As DataTable = New DataTable("Tabla")

        dt.Columns.Add("Codigo")
        dt.Columns.Add("Hora")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr("Codigo") = "0"
        dr("Hora") = 12
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "1"
        dr("Hora") = 24
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "2"
        dr("Hora") = 48
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("Codigo") = "3"
        dr("Hora") = 72
        dt.Rows.Add(dr)

        cboHra.DataSource = dt
        cboHra.ValueMember = "Codigo"
        cboHra.DisplayMember = "Hora"
        cboHra.SelectedIndex = 1
    End Sub

    Private Sub cboHra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboHra.SelectedIndexChanged
        CalculoDiasDuracion()
        CalcularDias()
    End Sub
    Public Sub CalculoDiasDuracion()

        Dim horas As String = cboHra.Text
        Dim veces As String = cboCantidadVeces.Text
        Dim hr As Integer
        Dim vcs As Integer

        If IsNumeric(horas) Then
            hr = Convert.ToInt32(horas)
            vcs = Convert.ToInt32(veces)
        Else
            hr = 0
            vcs = 0
        End If

        txtDiasTrat.Text = Math.Ceiling(hr * vcs / 24)
    End Sub

    Private Sub cboCantidadVeces_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCantidadVeces.SelectedIndexChanged
        CalculoDiasDuracion()
        CalcularDias()
    End Sub

    Public Function ConsultaTratamientoDiio(ByVal Diio As Integer, ByVal FechaInicio As DateTime) As Boolean
        ConsultaTratamientoDiio = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_ConsultaDiio", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Diio", Diio)
        cmd.Parameters.AddWithValue("@Fecha", FechaInicio)
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value

            If vret = 0 Then
                ConsultaTratamientoDiio = False
            Else
                ConsultaTratamientoDiio = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
End Class