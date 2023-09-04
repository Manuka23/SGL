



Imports System.Data.SqlClient



Public Class frmOtrosTratamientosIngreso

    Public Param1_Llamada As Integer = 0    '0=llamada desde menu / 1=llamada desde ingreso leche
    ''
    Private DiasTratamiento As Integer = 0




    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub

    Private Sub LimpiarControles()
        txtDIIO.Text = ""

        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        lblNroOtrosTrat.Text = "---"
        lblUltimaOtrosTrat.Text = "---"
        lblEstado.Text = "---"
        txtObservs.Text = ""

    End Sub


    Private Sub LimpiarControles2()
        cboPatologias.SelectedIndex = -1
        cboFarmacos.SelectedIndex = -1

        txtDiasTrat.Text = "---"
        lblFechaTermino.Text = "---"
        lblDiasResg.Text = "---"
        lblFechaLiberacion.Text = "---"
    End Sub


    Private Sub HabilitarControles1(ByVal hab_ As Boolean)
        txtDIIO.Enabled = hab_
        btnBuscar.Enabled = hab_
    End Sub


    Private Sub HabilitarControles2(ByVal hab_ As Boolean)
        dtpFechaInicio.Enabled = hab_
        cboPatologias.Enabled = hab_
        cboFarmacos.Enabled = hab_
    End Sub


    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text.Trim = "" Then ' Label15.Text Then
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
        Dim fup_, fpp_, fsec_ As String
        'Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fup_ = ""
        fpp_ = ""
        fsec_ = ""

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

                    evend = rdr("GndIsVendido").ToString.Trim
                    emue = rdr("GndIsMuerto").ToString.Trim
                    edesap = rdr("GndIsDesaparecido").ToString.Trim
                    fult_ = Format(rdr("GndOtrostratamientosFecUlt"), "yyyy-mm-dd")
                    If fult_.Contains("1900") Then fult_ = ""

                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then ' Label15.Text Then
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

                    If fult_ <> "01-01-1753" Then
                        lblUltimaOtrosTrat.Text = Format(rdr("GndOtrostratamientosFecUlt"), "yyyy-mm-dd")
                    Else
                        lblUltimaOtrosTrat.Text = ""
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
                    HabilitarControles2(True)
                    dtpFechaInicio.Focus()
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

    End Sub


    Private Function GrabarOtrosTratamientos() As Boolean
        GrabarOtrosTratamientos = False
        Dim i As Integer = 0
        Dim n As Integer = 0
        n = lvDetalle.Items.Count.ToString
        For i = 0 To n - 1
            Cursor.Current = Cursors.WaitCursor

            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spOtrosTratamientos_Grabar", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            'lvBASTON.Items(i).SubItems(1).Text.Trim
            Dim tratInicio As Date = lvDetalle.Items(i).SubItems(9).Text.Trim
            Dim tratTermino As Date = lvDetalle.Items(i).SubItems(10).Text.Trim
            Dim tratLiberacion As Date = lvDetalle.Items(i).SubItems(11).Text.Trim


            cmd.Parameters.AddWithValue("@OTratEmpresa", Empresa)
            cmd.Parameters.AddWithValue("@OTratCentro", lvDetalle.Items(i).SubItems(2).Text.Trim)
            cmd.Parameters.AddWithValue("@OTratDiio", lvDetalle.Items(i).SubItems(1).Text.Trim)
            cmd.Parameters.AddWithValue("@OTratPatologia", lvDetalle.Items(i).SubItems(3).Text.Trim)
            cmd.Parameters.AddWithValue("@OTratFarmaco", lvDetalle.Items(i).SubItems(5).Text.Trim)
            ''
            cmd.Parameters.AddWithValue("@OTratDiasTratamiento", lvDetalle.Items(i).SubItems(7).Text.Trim)
            cmd.Parameters.AddWithValue("@OTratDiasResguardo", lvDetalle.Items(i).SubItems(8).Text.Trim)
            ''
            cmd.Parameters.AddWithValue("@OTratFecInicioTrat", tratInicio)
            cmd.Parameters.AddWithValue("@OTratFecTerminoTrat", tratTermino)
            cmd.Parameters.AddWithValue("@OTratFecLiberacion", tratLiberacion)
            cmd.Parameters.AddWithValue("@OTratObservs", lvDetalle.Items(i).SubItems(12).Text.Trim)
            '
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            '
            cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

            Try
                con.Open()

                Dim Result As Integer = cmd.ExecuteNonQuery()

                Dim vret As Integer = cmd.Parameters("@RetValor").Value
                Dim mret As String = cmd.Parameters("@RetMensage").Value

                ''verificamos error con un valor igual a -1
                If vret = -1 Then
                    Cursor.Current = Cursors.Default

                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    Exit Function
                End If



            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                Exit For
            Finally
                con.Close()
            End Try

            ''End If
        Next


        ''si todo sale ok, retornamos ok
        GrabarOtrosTratamientos = True
        Cursor.Current = Cursors.Default
    End Function
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales() = False Then Exit Sub

        ''Tab 1 general
        Dim itm As New ListViewItem((lvTRATAMIENTOS.Items.Count + 1).ToString)
        itm.SubItems.Add(cboPatologias.Text)
        itm.SubItems.Add(cboFarmacos.Text)
        itm.SubItems.Add(General.Patologias.Codigo(cboPatologias.SelectedIndex))
        itm.SubItems.Add(General.FarmacosPatologia.Codigo(cboFarmacos.SelectedIndex))
        lvTRATAMIENTOS.Items.Add(itm)

        'Tab 2 detalles
        Dim itms As New ListViewItem((lvDetalle.Items.Count + 1).ToString)
        itms.SubItems.Add(txtDIIO.Text)
        itms.SubItems.Add(CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        itms.SubItems.Add(General.Patologias.Codigo(cboPatologias.SelectedIndex))
        itms.SubItems.Add(General.Patologias.Nombre(cboPatologias.SelectedIndex))
        itms.SubItems.Add(General.FarmacosPatologia.Codigo(cboFarmacos.SelectedIndex))
        itms.SubItems.Add(General.FarmacosPatologia.Nombre(cboFarmacos.SelectedIndex))
        itms.SubItems.Add(txtDiasTrat.Text)
        itms.SubItems.Add(lblDiasResg.Text)
        itms.SubItems.Add(dtpFechaInicio.Value)
        itms.SubItems.Add(lblFechaTermino.Text)
        itms.SubItems.Add(lblFechaLiberacion.Text)
        itms.SubItems.Add(txtObservs.Text)
        lvDetalle.Items.Add(itms)
        btnGrabar.Enabled = True
        LimpiarControles()
        'LimpiarControles2()
    End Sub

    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If txtDIIO.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If lblCategoria.Text.Trim = "---" Then
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

        If cboFarmacos.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UN TRATAMIENTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If Val(txtDiasTrat.Text) < DiasTratamiento Then
            If MsgBox("LOS DIAS DE TRATAMIENTOS NO PUEDE SER MENOR AL ESPECIFICADO POR EL FARMACO (" + DiasTratamiento.ToString + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDiasTrat.Text = DiasTratamiento.ToString
            txtDiasTrat.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function


    Private Sub txtDIIO_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
        End If
    End Sub


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
    End Sub


    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarOtrosTratamientos() = True Then



            HabilitarControles2(False)

            txtDIIO.Focus()
            Me.Close()
        End If
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub dtpFechaInicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFechaInicio.LostFocus
        If dtpFechaInicio.Value > Now Then
            If MsgBox("Fecha Inicio NO Debe ser Mayor a la fecha Actual", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error de Validación") = vbOK Then
            End If
            dtpFechaInicio.Value = Now
            'Exit Sub
        End If
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        HabilitarControles1(True)
        LimpiarControles()

        txtDIIO.Focus()
    End Sub

    Private Sub cboFarmacos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFarmacos.SelectedIndexChanged
        If cboFarmacos.SelectedIndex = -1 Or cboFarmacos.Text = "" Then Exit Sub
        DiasTratamiento = General.FarmacosPatologia.DiasTratamiento(cboFarmacos.SelectedIndex)
        txtDiasTrat.Text = DiasTratamiento.ToString
        lblDiasResg.Text = General.FarmacosPatologia.DiasResguardo(cboFarmacos.SelectedIndex)

        CalcularDias()
    End Sub


    Private Sub dtpFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaInicio.ValueChanged
        CalcularDias()
    End Sub


    Private Sub CalcularDias()
        If cboFarmacos.SelectedIndex = -1 And cboFarmacos.Text = "" Then Exit Sub
        If Not IsNumeric(txtDiasTrat.Text) Then Exit Sub

        Dim diastrat_ As Integer = 0
        Dim diasres_ As Integer = 0

        diastrat_ = Convert.ToInt32(txtDiasTrat.Text) 'General.FarmacosPatologia.DiasTratamiento(cboFarmacos.SelectedIndex)
        diasres_ = General.FarmacosPatologia.DiasResguardo(cboFarmacos.SelectedIndex)

        lblFechaTermino.Text = Format(DateAdd(DateInterval.Day, diastrat_, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")
        lblFechaLiberacion.Text = Format(DateAdd(DateInterval.Day, diastrat_ + diasres_ + 1, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")
    End Sub


    Private Sub cboPatologias_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPatologias.SelectedIndexChanged
        'General.FarmacosPatologia.Cargar(General.Patologias.Codigo(cboPatologias.SelectedIndex))
        'CboLLenaFarmacosPatologia(cboFarmacos, False)
    End Sub


    Private Sub txtDiasTrat_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasTrat.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtDiasTrat_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiasTrat.TextChanged
        CalcularDias()
    End Sub



    Private Sub frmOtrosTratamientosIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaPatologias(cboPatologias, False)

        General.FarmacosPatologia.Cargar(0)
        CboLLenaFarmacosPatologia(cboFarmacos, False)

        dtpFecha.Value = Now
        dtpFechaInicio.Value = Now

        HabilitarControles1(False)
        HabilitarControles2(False)
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub
End Class