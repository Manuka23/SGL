


Imports System.Data.SqlClient



Public Class FrmMastitisIngreso


    Public Param1_Llamada As Integer = 0    '0=llamada desde menu / 1=llamada desde ingreso leche


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaFarmacos()
        If General.Farmacos.NroRegistros = 0 Then Exit Sub

        cboFarmacos.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Farmacos.NroRegistros - 1
            cboFarmacos.Items.Add(General.Farmacos.Nombre(i) & " ( " & General.Farmacos.Glosa(i) & " ) ")
        Next
    End Sub


    Private Sub LimpiarControles()
        txtDIIO.Text = ""

        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        lblNroMastitis.Text = "---"
        lblUltimaMastitis.Text = "---"
        lblEstado.Text = "---"
        txtObservs.Text = ""

        'dtpFecha.Value = Now
        'lblFechaLiberacion.Text = "---"
        cboFarmacos.SelectedIndex = -1

        chkAD.Checked = False
        chkAI.Checked = False
        chkPD.Checked = False
        chkPI.Checked = False
    End Sub


    Private Sub LimpiarControles2()
        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        lblNroMastitis.Text = "---"
        lblUltimaMastitis.Text = "---"
        lblEstado.Text = "---"
        'txtObservs.Text = ""

        'dtpFecha.Value = Now
        'lblFechaLiberacion.Text = "---"
        'cboFarmacos.SelectedIndex = -1

        'chkAD.Checked = False
        'chkAI.Checked = False
        'chkPD.Checked = False
        'chkPI.Checked = False
    End Sub


    Private Sub HabilitarControles1(ByVal hab_ As Boolean)
        txtDIIO.Enabled = hab_
        btnBuscar.Enabled = hab_
    End Sub


    Private Sub HabilitarControles2(ByVal hab_ As Boolean)
        'txtDIIO.Enabled = hab_
        'btnBuscar.Enabled = hab_
        dtpFechaInicio.Enabled = hab_
        cboFarmacos.Enabled = hab_

        chkAD.Enabled = hab_
        chkAI.Enabled = hab_
        chkPD.Enabled = hab_
        chkPI.Enabled = hab_

        btnGrabar.Enabled = hab_
    End Sub


    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text.Trim = "" Then ' Label15.Text Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
            End If
            txtDIIO.Text = ""
            cboCentros.Focus()
            Exit Sub
        End If

        'Label17.Visible = False
        'Label18.Visible = False

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
                    fult_ = Format(rdr("GndMastitisFecUlt"), "dd-MM-yyyy")

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
                    lblNroMastitis.Text = rdr("GndMastitisNum").ToString.Trim

                    If fult_ <> "01-01-1753" Then
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
                    HabilitarControles2(True)
                    dtpFechaInicio.Focus()
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


    Private Function GrabarMastitis() As Boolean
        GrabarMastitis = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMastitis_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@MastEmpresa", Empresa)
        cmd.Parameters.AddWithValue("@MastCentro", CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@MastFecha", CDate(Format(dtpFecha.Value, "dd-MM-yyyy")))
        cmd.Parameters.AddWithValue("@MastDiio", txtDIIO.Text)
        cmd.Parameters.AddWithValue("@MastFecInicioTrat", dtpFechaInicio.Value)
        cmd.Parameters.AddWithValue("@MastFecTerminoTrat", CDate(lblFechaTermino.Text))
        cmd.Parameters.AddWithValue("@MastFecLiberacion", CDate(lblFechaLiberacion.Text))
        cmd.Parameters.AddWithValue("@MastCodTratamiento", General.Farmacos.Codigo(cboFarmacos.SelectedIndex))
        cmd.Parameters.AddWithValue("@MastAD", chkAD.Checked)
        cmd.Parameters.AddWithValue("@MastAI", chkAI.Checked)
        cmd.Parameters.AddWithValue("@MastPD", chkPD.Checked)
        cmd.Parameters.AddWithValue("@MastPI", chkPI.Checked)
        cmd.Parameters.AddWithValue("@MastObservs", txtObservs.Text)
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

            ''si todo sale ok, retornamos ok
            GrabarMastitis = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function


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

        If cboFarmacos.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UN FARMACO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If


        If chkAD.Checked = False And chkAI.Checked = False And chkPD.Checked = False And chkPI.Checked = False Then
            If MsgBox("DEBE SELECCIONAR AL MENOS UN CUARTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
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
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarMastitis() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            'Cursor.Current = Cursors.WaitCursor

            LimpiarControles()
            HabilitarControles2(False)


            txtDIIO.Focus()

            'GraboDatos = True
            'Cursor.Current = Cursors.Default
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


    Private Sub txtDIIO_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDIIO.TextChanged
        LimpiarControles2()
    End Sub


    Private Sub cboFarmacos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFarmacos.SelectedIndexChanged
        CalcularDias()
    End Sub


    Private Sub FrmMastitisIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.Farmacos.Cargar()
        CboLLenaCentros()
        CboLLenaFarmacos()

        dtpFecha.Value = Now
        dtpFechaInicio.Value = Now

        lblFechaLiberacion.Text = Format(DateAdd(DateInterval.Day, 7, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")

        HabilitarControles1(False)
        HabilitarControles2(False)
    End Sub


    Private Sub dtpFechaInicio_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaInicio.ValueChanged
        CalcularDias()
    End Sub


    Private Sub CalcularDias()
        Dim diastrat_ As Integer = 0
        Dim diasres_ As Integer = 0

        If cboFarmacos.SelectedIndex <> -1 And cboFarmacos.Text <> "" Then
            diastrat_ = General.Farmacos.DiasTratamiento(cboFarmacos.SelectedIndex)
            diasres_ = General.Farmacos.DiasResguardo(cboFarmacos.SelectedIndex)

            lblFechaTermino.Text = Format(DateAdd(DateInterval.Day, diastrat_, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")
            lblFechaLiberacion.Text = Format(DateAdd(DateInterval.Day, diastrat_ + diasres_ + 1, dtpFechaInicio.Value), "dd-MM-yyyy")   'Format(fec_, "dd-MM-yyyy")
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub
End Class