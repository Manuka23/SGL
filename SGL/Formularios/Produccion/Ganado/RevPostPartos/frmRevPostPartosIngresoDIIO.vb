


Imports System.Data.SqlClient



Public Class frmRevPostPartosIngresoDIIO

    Public Param0_ModoIngreso As Integer        '
    Public Param1_CodigoCentro As String
    Public Shared Param2_NombreCentro As String

    Private GraboRevPP As Boolean = False



    Private Sub LimpiaDatos(Optional ByVal LimpiaDIIO As Boolean = False)
        If LimpiaDIIO = True Then
            txtDIIO.Text = ""
        End If
        '
        lblCentro.Text = "---"
        lblCategoria.Text = "---"
        lblEstadoSalud.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        '
        lblFecUltParto.Text = "---"
        lblTipoParto.Text = "---"
        'lblDiasSecado.Text = "---"
        lblDiasLactancia.Text = "---"

        lblFecUltRevPP.Text = "---"
        lblUltCondicion.Text = "---"

        cboCondiciones.SelectedIndex = -1
        cboEstProductivos.SelectedIndex = -1
        cboTipoDesechos.SelectedIndex = -1

        txtObservs.Text = ""

        'If GraboRevPP = False Then
        '    cboCentros.Enabled = False
        '    dtpFecha.Enabled = False
        '    txtObservsEnc.Enabled = False
        'End If

        'HabilitaControles2(False)
    End Sub


    Private Sub HabilitaControles(ByVal enab_ As Boolean)
        txtDIIO.Enabled = enab_
        btnBuscar.Enabled = enab_
        'cboCondiciones.Enabled = enab_
        'cboEstProductivos.Enabled = enab_
        'cboTipoDesechos.Enabled = enab_
        'txtObservs.Enabled = enab_
    End Sub


    Private Sub HabilitaControles1(ByVal enab_ As Boolean)
        cboCentros.Enabled = enab_
        dtpFecha.Enabled = enab_
        txtObservsEnc.Enabled = enab_
    End Sub


    Private Sub HabilitaControles2(ByVal enab_ As Boolean)
        'txtDIIO.Enabled = enab_
        'btnBuscar.Enabled = enab_
        cboCondiciones.Enabled = enab_
        cboRazas.Enabled = enab_
        cboEstProductivos.Enabled = enab_
        'cboTipoDesechos.Enabled = enab_
        txtObservs.Enabled = enab_
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaCondiciones()
        If General.CondicionesRevPP.NroRegistros = 0 Then Exit Sub
        cboCondiciones.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CondicionesRevPP.NroRegistros - 1
            cboCondiciones.Items.Add(General.CondicionesRevPP.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaRazas()
        If General.Razas.NroRegistros = 0 Then Exit Sub
        cboRazas.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Razas.NroRegistros - 1
            cboRazas.Items.Add(General.Razas.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaEstadosProductivos()
        If General.EstProductivos.NroRegistros = 0 Then Exit Sub
        cboEstProductivos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.EstProductivos.NroRegistros - 1
            cboEstProductivos.Items.Add(General.EstProductivos.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaTipoDesechos()
        If General.TipoDesechos.NroRegistros = 0 Then Exit Sub
        cboTipoDesechos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoDesechos.NroRegistros - 1
            cboTipoDesechos.Items.Add(General.TipoDesechos.Nombre(i))
        Next
    End Sub


    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If txtDIIO.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If lblCentro.Text = "---" Then
            If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If cboCondiciones.Text = "" Then
            If MsgBox("DEBE SELECCIONAR UNA CONDICION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCondiciones.Focus()
            Exit Function
        End If

        'If cboRazas.Text = "" Or cboRazas.SelectedIndex = -1 Then
        '    If MsgBox("DEBE ESPECIFICAR UNA RAZA PARA EL ANIMAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtDIIO.Focus()
        '    Exit Function
        'End If

        'If VerificaDIIOEnGrilla(txtDIIO.Text.Trim) = True Then
        '    If MsgBox("EL DIIO YA ESTA CARGADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    LimpiaDatos()
        '    txtDIIO.Focus()
        '    Exit Function
        'End If

        ValidacionesLocales = True
    End Function


    'Private Function VerificaDIIOEnGrilla(ByVal diio_ As String) As Boolean
    '    VerificaDIIOEnGrilla = False

    '    Dim i As Integer = 0
    '    Dim existe_ As Boolean = False

    '    For i = 0 To frmSecadosIngreso.lvDIIOS.Items.Count - 1

    '        If frmSecadosIngreso.lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
    '            existe_ = True
    '            Exit For
    '        End If

    '    Next

    '    VerificaDIIOEnGrilla = existe_
    'End Function


    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Dim Existe As Boolean = False
        Dim dtfup_, dtfurpp_ As DateTime
        Dim fup_, furpp_ As String
        'Dim fc_ As DateTime

        fup_ = ""
        furpp_ = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    Existe = True
                    dtfup_ = IIf(IsDBNull(rdr("GndUltFechaParto")) = False, rdr("GndUltFechaParto"), DateTime.Parse("01-01-1753"))
                    dtfurpp_ = IIf(IsDBNull(rdr("GndUlFechaRevPP")) = False, rdr("GndUlFechaRevPP"), DateTime.Parse("01-01-1753"))

                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                        If MsgBox("EL DIIO NO PERTENECE AL CENTRO SELECCIONADO (" + rdr("CenDesCor").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                        End If

                        'EstadoSecado = "ERR / CENTRO"
                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                        Exit Sub
                    End If

                    If rdr("GndEstadoReproductivo").ToString.Trim <> "ANESTRO" Then
                        If MsgBox("EL ESTADO REPRODUCTIVO DEL ANIMAL NO ES --- ANESTRO --- (" + rdr("GndEstadoReproductivo").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                        End If

                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                        Exit Sub
                        'If EstadoSecado.Trim = "" Then : EstadoSecado = "ERR / E.PR" : Else : EstadoSecado = EstadoSecado + " / E.PR" : End If
                    End If

                    If rdr("GndEstadoSalud").ToString.Trim = "SANA" And Year(dtfurpp_) = Year(DateTime.Now) Then
                        If MsgBox("ADVERTENCIA: " + Chr(13) + Chr(10) + "EL ESTADO DE SALUD ES --- SANA ---" + Chr(13) + Chr(10) + "FECHA ULTIMA REVISION PP: " + Format(dtfurpp_, "dd-MM-yyyy"), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMCIÓN") = vbOK Then
                        End If

                        'txtDIIO.Text = ""
                        'txtDIIO.Focus()
                        'Exit Sub
                        'If EstadoSecado.Trim = "" Then : EstadoSecado = "ERR / E.PR" : Else : EstadoSecado = EstadoSecado + " / E.PR" : End If
                    End If



                    If IsDate(dtfup_) Then
                        fup_ = Format(dtfup_, "dd-MM-yyyy")
                        If fup_ = "01-01-1753" Then fup_ = ""
                        If fup_ = "01-01-1900" Then fup_ = ""
                    End If

                    If IsDate(dtfurpp_) Then
                        furpp_ = Format(dtfurpp_, "dd-MM-yyyy")
                        If furpp_ = "01-01-1753" Then furpp_ = ""
                        If furpp_ = "01-01-1900" Then furpp_ = ""
                    End If

                    'Label12.Text = fup_

                    'Dim diff1 As Integer = 0
                    'Dim diff2 As Integer = 0

                    'If IsDate(fpp_) Then diff1 = DateDiff(DateInterval.Day, Now, CDate(fpp_))
                    'If IsDate(fup_) Then diff2 = DateDiff(DateInterval.Day, CDate(fup_), Now)
                    cboRazas.Text = rdr("RazaCod").ToString.Trim

                    lblCentro.Text = rdr("CenDesCor").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstadoSalud.Text = rdr("GndEstadoSalud").ToString.Trim
                    ''''
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
                    ''''
                    lblFecUltParto.Text = fup_
                    lblTipoParto.Text = rdr("GndUltPartoFormaParto").ToString.Trim
                    lblDiasLactancia.Text = rdr("DiasLac").ToString.Trim
                    ''''
                    lblFecUltRevPP.Text = furpp_
                    lblUltCondicion.Text = rdr("GndUltRevPPCondicion").ToString.Trim


                    If rdr("GndEstadoReproductivo").ToString.Trim = "ANESTRO" And rdr("GndUltRevPPCondicion").ToString.Trim = "" Then
                        lblUltCondicion.Text = "A REVISAR"
                    End If

                    lblCodRaza.Text = rdr("Razacod").ToString.Trim

                    Exit While
                End While

                If Existe = False Then
                    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                Else
                    HabilitaControles1(False)
                    HabilitaControles2(True)

                    cboEstProductivos.Text = "EN PRODUCCION"
                    cboCondiciones.Focus()
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


    Private Function GrabarRevisionPostParto() As Boolean
        GrabarRevisionPostParto = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRevisionesPP_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim diios_ As String = ""
        Dim ReemplazaDetSGL As Integer = 0
        Dim raza_ As String = "" 'lblCodRaza.Text
        'Dim grabdet_ As Integer = 0

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        If cboRazas.Text <> "" Then raza_ = General.Razas.Codigo(cboRazas.SelectedIndex)
        
ReemplazaDet:

        ''
        cmd.Parameters.AddWithValue("@Commit", 1)           'realiza commit desde SGL - NO realiza commit desde PocketSGL
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Observs", txtObservsEnc.Text.Trim)
        cmd.Parameters.AddWithValue("@Diio", txtDIIO.Text.Trim)
        cmd.Parameters.AddWithValue("@Condicion", cboCondiciones.Text.Trim)
        cmd.Parameters.AddWithValue("@Raza", raza_)
        cmd.Parameters.AddWithValue("@EstProductivo", cboEstProductivos.Text.Trim)
        cmd.Parameters.AddWithValue("@Desecho", cboTipoDesechos.Text.Trim)
        cmd.Parameters.AddWithValue("@ObservsDiio", txtObservs.Text.Trim)
        cmd.Parameters.AddWithValue("@ReemplazaDet", ReemplazaDetSGL)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            If con.State <> ConnectionState.Open Then
                con.Open()
            End If

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If vret <> 99 Then
                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    Exit Function
                Else
                    If MsgBox(mret, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = vbYes Then
                    End If

                    ReemplazaDetSGL = 1
                    cmd.Parameters.Clear()
                    GoTo ReemplazaDet
                End If
            End If

                ''si todo sale ok guardamos el nuevo codigo del grupo de secado

                'CodigoSecado = vret

                'despues de una grabacion correcta siempre activamos la edicion, ya que el encabezado ya esta creado
                Param0_ModoIngreso = 2

                GrabarRevisionPostParto = True
                'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

                'MsgBox(mret)


                'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub txtDiasGest_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ CONFIRMA REVISIÓN POST PARTO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            LimpiaDatos(True)
            HabilitaControles2(True)
            txtDIIO.Focus()
            Exit Sub
        End If

        If GrabarRevisionPostParto() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            LimpiaDatos(True)
            HabilitaControles1(False)
            HabilitaControles2(False)
            txtDIIO.Focus()

            GraboRevPP = True
        End If
    End Sub


    Private Sub txtDIIO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
        End If
    End Sub


    Private Sub txtDIIO_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDIIO.TextChanged
        If lblCentro.Text <> "---" Then
            LimpiaDatos()
            If GraboRevPP = False Then HabilitaControles1(True)
            HabilitaControles2(False)
        End If
    End Sub


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub frmRevPostPartosIngresoDIIO_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        cboCentros.Focus()
    End Sub


    Private Sub frmRevPospartosIngresoDIIO_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtDIIO.Focus()
    End Sub


    Private Sub frmRevPostPartosIngresoDIIO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaCondiciones()
        CboLLenaRazas()
        CboLLenaEstadosProductivos()
        CboLLenaTipoDesechos()

        If Param2_NombreCentro.Trim = "" Then
            HabilitaControles(False)
        Else
            cboCentros.Text = Param2_NombreCentro
            HabilitaControles(True)
        End If
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If cboCentros.Text.Trim <> "" Then
            HabilitaControles(True)
        End If
    End Sub

  
    Private Sub cboEstProductivos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'cboTipoDesechos.SelectedIndex = -1

        'If cboEstProductivos.SelectedIndex = -1 Then Exit Sub

        'If General.EstProductivos.Causa(cboEstProductivos.SelectedIndex) = "S" Then
        '    'cboTipoDesechos.SelectedIndex = -1
        '    cboTipoDesechos.Enabled = True
        'Else
        '    'cboTipoDesechos.SelectedIndex = -1
        '    cboTipoDesechos.Enabled = False
        'End If
    End Sub



    Private Sub cboCentros_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCentros.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub dtpFecha_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtObservsEnc_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservsEnc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'SendKeys.Send("{TAB}")
            txtDIIO.Focus()
        End If
    End Sub


    Private Sub cboCondiciones_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCondiciones.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub cboRazas_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboRazas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub cboEstProductivos_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboEstProductivos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub cboEstProductivos_LostFocus(sender As System.Object, e As System.EventArgs) Handles cboEstProductivos.LostFocus
        ProcesaSeleccionEstProductivo()
    End Sub


    Private Sub cboTipoDesechos_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoDesechos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub



    Private Sub txtObservs_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservs.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            'SendKeys.Send("{TAB}")

            Call btnGrabar_Click(sender, e)

        End If
    End Sub


    Private Sub ProcesaSeleccionEstProductivo()
        cboTipoDesechos.SelectedIndex = -1

        If cboEstProductivos.SelectedIndex = -1 Then Exit Sub

        If General.EstProductivos.Causa(cboEstProductivos.SelectedIndex) = "S" Then
            'cboTipoDesechos.SelectedIndex = -1
            cboTipoDesechos.Enabled = True
        Else
            'cboTipoDesechos.SelectedIndex = -1
            cboTipoDesechos.Enabled = False
        End If
    End Sub



End Class