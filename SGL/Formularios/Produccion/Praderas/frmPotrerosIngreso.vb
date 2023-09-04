


Imports System.Data.SqlClient



Public Class frmPotrerosIngreso

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





    'Private Sub LimpiarControles()
    '    txtDIIO.Text = ""

    '    lblCategoria.Text = "---"
    '    lblEstProductivo.Text = "---"
    '    lblEstReproductivo.Text = "---"
    '    lblNroOtrosTrat.Text = "---"
    '    lblUltimaOtrosTrat.Text = "---"
    '    lblEstado.Text = "---"
    '    txtObservs.Text = ""

    '    'dtpFecha.Value = Now
    '    'lblFechaLiberacion.Text = "---"
    '    cboFarmacos.SelectedIndex = -1
    'End Sub


    'Private Sub LimpiarControles2()
    '    cboPatologias.SelectedIndex = -1
    '    cboFarmacos.SelectedIndex = -1

    '    txtDiasTrat.Text = "---"
    '    lblFechaTermino.Text = "---"
    '    lblDiasResg.Text = "---"
    '    lblFechaLiberacion.Text = "---"
    'End Sub


    'Private Sub HabilitarControles1(ByVal hab_ As Boolean)
    '    txtDIIO.Enabled = hab_
    '    btnBuscar.Enabled = hab_
    'End Sub


    'Private Sub HabilitarControles2(ByVal hab_ As Boolean)
    '    'txtDIIO.Enabled = hab_
    '    'btnBuscar.Enabled = hab_
    '    dtpFechaInicio.Enabled = hab_
    '    cboPatologias.Enabled = hab_
    '    cboFarmacos.Enabled = hab_

    '    btnGrabar.Enabled = hab_
    'End Sub


    'Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
    '    If cboCentros.SelectedIndex = -1 Or cboCentros.Text.Trim = "" Then ' Label15.Text Then
    '        If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
    '        End If
    '        txtDIIO.Text = ""
    '        cboCentros.Focus()
    '        Exit Sub
    '    End If

    '    'Label17.Visible = False
    '    'Label18.Visible = False

    '    If CodigoDIIO.Trim = "" Then Exit Sub

    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
    '    Dim rdr As SqlDataReader = Nothing
    '    Dim Existe As Boolean = False
    '    Dim fup_, fpp_, fsec_ As String
    '    'Dim fc_ As DateTime

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    fup_ = ""
    '    fpp_ = ""
    '    fsec_ = ""

    '    'EstadoSecado = ""

    '    Dim evend As String = ""
    '    Dim emue As String = ""
    '    Dim edesap As String = ""
    '    Dim fult_ As String = ""

    '    Try
    '        con.Open()
    '        rdr = cmd.ExecuteReader()

    '        'LimpiaDatos()

    '        Try
    '            While rdr.Read()
    '                Existe = True

    '                evend = rdr("GndIsVendido").ToString.Trim
    '                emue = rdr("GndIsMuerto").ToString.Trim
    '                edesap = rdr("GndIsDesaparecido").ToString.Trim
    '                fult_ = Format(rdr("GndOtrostratamientosFecUlt"), "dd-MM-yyyy")

    '                If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then ' Label15.Text Then
    '                    If MsgBox("EL DIIO NO PERTENECE AL CENTRO SELECCIONADO (" + rdr("CenDesCor").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
    '                    End If

    '                    txtDIIO.Text = ""
    '                    txtDIIO.Focus()
    '                    Exit Try
    '                End If

    '                lblCategoria.Text = rdr("GndProNom").ToString.Trim
    '                lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
    '                lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
    '                lblNroOtrosTrat.Text = rdr("GndOtrosTratamientosNum").ToString.Trim

    '                If fult_ <> "01-01-1753" Then
    '                    lblUltimaOtrosTrat.Text = Format(rdr("GndOtrostratamientosFecUlt"), "dd-MM-yyyy")
    '                Else
    '                    lblUltimaOtrosTrat.Text = ""
    '                End If

    '                If evend = "SI" Then
    '                    lblEstado.Text = "VENDIDO"
    '                ElseIf emue = "SI" Then
    '                    lblEstado.Text = "MUERTO"
    '                ElseIf edesap = "SI" Then
    '                    lblEstado.Text = "DESAPARECIDO"
    '                Else
    '                    lblEstado.Text = "STOCK"
    '                End If

    '                Exit While
    '            End While

    '            If Existe = False Then
    '                MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
    '                txtDIIO.Text = ""
    '                txtDIIO.Focus()
    '            Else
    '                HabilitarControles2(True)
    '                dtpFechaInicio.Focus()
    '            End If

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try

    'End Sub


    Private Function GrabarPotrero() As Boolean
        GrabarPotrero = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPotreros_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        Dim sup_ As Double = 0
        If txtSuperficie.Text.Trim <> "" And txtSuperficie.Text <> "0" Then sup_ = Convert.ToDouble(txtSuperficie.Text)


        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Potrero", txtNroPotrero.Text)
        cmd.Parameters.AddWithValue("@Tipo", General.TipoPotreros.Codigo(cboTipoPotreros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Superficie", sup_)
        cmd.Parameters.AddWithValue("@Observs", txtObservs.Text)
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
            If vret <> 0 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            ''si todo sale ok, retornamos ok
            GrabarPotrero = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function


    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If txtNroPotrero.Text.Trim = "" Or txtNroPotrero.Text.Trim = "0" Then
            If MsgBox("DEBE INGRESAR UN NÚMERO DE POTRERO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroPotrero.Focus()
            Exit Function
        End If

        If cboTipoPotreros.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE POTRERO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTipoPotreros.Focus()
            Exit Function
        End If

        If txtSuperficie.Text.Trim = "" Or txtSuperficie.Text.Trim = "0" Then
            If MsgBox("DEBE INGRESAR LA SUPERFICIE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtSuperficie.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function


    'Private Sub txtDIIO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        txtDIIO.Text = txtDIIO.Text.Trim
    '        ConsultaDIIO(txtDIIO.Text)
    '    End If
    'End Sub


    'Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txtDIIO.Text = txtDIIO.Text.Trim
    '    ConsultaDIIO(txtDIIO.Text)
    'End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR EL POTRERO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarPotrero() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            'LimpiarControles()
            'LimpiarControles2()
            'HabilitarControles2(False)

            'txtDIIO.Focus()

            Me.Close()

            frmPotreros.ConsultarPotreros()
        End If
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    'Private Sub dtpFechaInicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If dtpFechaInicio.Value > Now Then
    '        If MsgBox("Fecha Inicio NO Debe ser Mayor a la fecha Actual", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error de Validación") = vbOK Then
    '        End If
    '        dtpFechaInicio.Value = Now
    '        'Exit Sub
    '    End If
    'End Sub


    'Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
    '    HabilitarControles1(True)
    '    LimpiarControles()

    '    txtDIIO.Focus()
    'End Sub


    'Private Sub txtDIIO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    LimpiarControles2()
    'End Sub


    'Private Sub cboFarmacos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cboFarmacos.SelectedIndex = -1 Or cboFarmacos.Text = "" Then Exit Sub

    '    DiasTratamiento = General.FarmacosPatologia.DiasTratamiento(cboFarmacos.SelectedIndex)
    '    txtDiasTrat.Text = DiasTratamiento.ToString
    '    lblDiasResg.Text = General.FarmacosPatologia.DiasResguardo(cboFarmacos.SelectedIndex)

    '    CalcularDias()
    'End Sub


    'Private Sub dtpFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CalcularDias()
    'End Sub


    'Private Sub CalcularDias()
    '    If cboFarmacos.SelectedIndex = -1 And cboFarmacos.Text = "" Then Exit Sub
    '    If Not IsNumeric(txtDiasTrat.Text) Then Exit Sub

    '    Dim diastrat_ As Integer = 0
    '    Dim diasres_ As Integer = 0

    '    diastrat_ = Convert.ToInt32(txtDiasTrat.Text) 'General.FarmacosPatologia.DiasTratamiento(cboFarmacos.SelectedIndex)
    '    diasres_ = General.FarmacosPatologia.DiasResguardo(cboFarmacos.SelectedIndex)

    '    lblFechaTermino.Text = Format(DateAdd(DateInterval.Day, diastrat_, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")
    '    lblFechaLiberacion.Text = Format(DateAdd(DateInterval.Day, diastrat_ + diasres_ + 1, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")
    'End Sub


    'Private Sub cboPatologias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPatologias.SelectedIndexChanged
    '    If cboPatologias.SelectedIndex = -1 Then Exit Sub

    '    General.FarmacosPatologia.Cargar(General.Patologias.Codigo(cboPatologias.SelectedIndex))
    '    CboLLenaFarmacosPatologia(cboFarmacos, False)
    'End Sub


    Private Sub txtNroPotrero_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroPotrero.KeyPress
        'If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
        '    e.Handled = True
        'End If
    End Sub


    'Private Sub txtDiasTrat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiasTrat.TextChanged
    '    CalcularDias()
    'End Sub


    ''Private Sub txtDiasTrat_LostFocus(sender As System.Object, e As System.EventArgs) Handles txtDiasTrat.LostFocus
    ''End Sub


    Private Sub frmPotrerosIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaTipoPotreros(cboTipoPotreros, False)
        'CboLLenaFarmacos()

        'dtpFecha.Value = Now
        'dtpFechaInicio.Value = Now

        'lblFechaLiberacion.Text = Format(DateAdd(DateInterval.Day, 7, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")

        'HabilitarControles1(False)
        'HabilitarControles2(False)
    End Sub



End Class