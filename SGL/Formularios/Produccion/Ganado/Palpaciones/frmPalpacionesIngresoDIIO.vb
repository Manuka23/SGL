


Imports System.Data.SqlClient



Public Class frmPalpacionesIngresoDIIO

    Public Param0_ModoIngreso As Integer        '
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_CodigoVeterinario As Integer
    Public Param4_NombreVeterinario As String



    Private Sub LimpiaDatos(Optional ByVal LimpiaDIIO As Boolean = False)
        If LimpiaDIIO = True Then
            txtDIIO.Text = ""
        End If
        '
        lblCentro.Text = "---"
        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        '
        lblFecUltParto.Text = "---"
        lblFecProbParto.Text = "---"
        lblNroCubiertas.Text = "---"
        '
        txtDiasGest.Text = ""
        '
        cboFechasCub.SelectedIndex = -1
        cboCondiciones.SelectedIndex = -1
        cboToros.SelectedIndex = -1
        cboEstProductivos.SelectedIndex = -1
        cboTipoDesechos.SelectedIndex = -1
        '
        txtDiasGest.Enabled = False
        'dtpFecha.Enabled = False
        cboFechasCub.Enabled = False
        cboCondiciones.Enabled = False
        cboToros.Enabled = False
        cboEstProductivos.Enabled = False
        cboTipoDesechos.Enabled = False
    End Sub


    Private Sub CboLLenaFechasCubiertas()
        Dim cod_diio As String = txtDIIO.Text.Trim
        Dim fcubs As New FechasCubiertas
        Dim i As Integer

        cboFechasCub.Items.Clear()

        fcubs.Cargar(cod_diio)

        cboFechasCub.Items.Add("MONTA")

        If fcubs.NroRegistros = 0 Then Exit Sub

        For i = 0 To fcubs.NroRegistros - 1
            cboFechasCub.Items.Add(fcubs.Fecha(i))
        Next
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaVeterinarios()
        If General.Veterinarios.NroRegistros = 0 Then Exit Sub
        cboVeterinarios.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Veterinarios.NroRegistros - 1
            cboVeterinarios.Items.Add(General.Veterinarios.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaCondiciones()
        If General.Condiciones.NroRegistros = 0 Then Exit Sub
        cboCondiciones.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Condiciones.NroRegistros - 1
            cboCondiciones.Items.Add(General.Condiciones.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaToros()
        If General.Toros.NroRegistros = 0 Then Exit Sub
        cboToros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Toros.NroRegistros - 1
            cboToros.Items.Add(General.Toros.Nombre(i))
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

        If cboCentros.SelectedIndex = -1 Then Exit Function
        If cboVeterinarios.SelectedIndex = -1 Then Exit Function

        If cboCondiciones.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UNA CONDICION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCondiciones.Focus()
            Exit Function
        End If

        If cboFechasCub.Text = "MONTA" And Val(txtDiasGest.Text) = 0 Then
            If MsgBox("DEBE INGRESAR LOS DIAS DE GESTACION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDiasGest.Focus()
            Exit Function
        End If

        'If cboCondiciones.Text = "PREÑADA" And Val(txtDiasGest.Text) > 282 Then
        '    If MsgBox("CUANDO LA VACA ESTÁ PREÑADA NO PUEDE TENER MÁS DE 282 DÍAS DE GESTACIÓN", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtDiasGest.Focus()
        '    Exit Function
        'End If

        ValidacionesLocales = True
    End Function


    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim fpart_, fpp_, fupantrt_ As String
        Dim fcub_ As Date
        Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fpart_ = ""
        fupantrt_ = ""
        fpp_ = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    If IsDate(rdr("GndUltFechaParto")) Then
                        fpart_ = Format(rdr("GndUltFechaParto"), "dd-MM-yyyy")
                        If fpart_ = "01-01-1753" Then fpart_ = ""
                    End If
                    If IsDate(rdr("GndUltFechaAntParto")) Then
                        fupantrt_ = Format(rdr("GndUltFechaAntParto"), "dd-MM-yyyy")
                        If fupantrt_ = "01-01-1753" Then fupantrt_ = ""
                    End If

                    fc_ = rdr("GndUltCubierta")
                    If IsDate(rdr("GndUltCubierta")) Then fcub_ = rdr("GndUltCubierta")


                    If IsDate(rdr("GndUltFechaPP")) Then
                        fpp_ = Format(rdr("GndUltFechaPP"), "dd-MM-yyyy")
                        If fpp_ = "31-12-3000" Then fpp_ = ""
                    End If


                    lblCentro.Text = rdr("CenDesCor").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim

                    lblFecUltParto.Text = fpart_
                    lblFecProbPartoANterior.Text = fupantrt_
                    lblFecProbParto.Text = fpp_
                    lblNroCubiertas.Text = rdr("GndUltCubiertaNum").ToString.Trim
                    'lblFecUltCubierta.Text = "---"

                    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                        lblEstado.Text = "VENDIDO"
                    ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        lblEstado.Text = "MUERTO"
                    ElseIf rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        lblEstado.Text = "DESAPARECIDO"
                    Else
                        lblEstado.Text = "STOCK"
                    End If

                    cboCentros.Enabled = False
                    cboVeterinarios.Enabled = False
                    dtpFecha.Enabled = False

                    Existe = True
                End While

                If Existe = True Then
                    CboLLenaFechasCubiertas()

                    Dim diff As Integer = 0

                    'llenamos combo con fechas de cubierta y seleccionamos la ultima fecha de cubierta realizada
                    If Val(lblNroCubiertas.Text) > 0 Then
                        cboFechasCub.Text = fcub_ ' Format(fcub_, "dd-MM-yyyy")

                        If cboFechasCub.SelectedIndex = -1 Then cboFechasCub.Text = "MONTA"

                        If Year(fc_) > 2000 And Year(fc_) <= Year(dtpFecha.Value) Then
                            'diff = DateDiff(DateInterval.Day, fc_, Now)
                            diff = DateDiff(DateInterval.Day, fc_, dtpFecha.Value)
                            'lblFecProbParto.Text = Format(Now.AddDays(282 - diff), "dd-MM-yyyy")
                            lblFecProbParto.Text = Format(dtpFecha.Value.AddDays(282 - diff), "dd-MM-yyyy")
                        End If
                    End If

                    txtDiasGest.Text = diff.ToString.Trim

                    cboEstProductivos.Text = lblEstProductivo.Text

                    'If DIIO.Condicion <> 0 Then
                    '    cboCondiciones.Text = General.Condiciones.Nombre(Array.IndexOf(General.Condiciones.Codigo, DIIO.Condicion))
                    'End If

                    'If DIIO.Desecho <> 0 Then
                    '    cboDesechos.Text = General.Desechos.Nombre(Array.IndexOf(General.Desechos.Codigo, DIIO.Desecho))
                    '    cboDesechos.Enabled = True
                    'End If

                    'If DIIO.Toro <> "0" Then
                    '    cboToros.Text = General.Toros.Nombre(Array.IndexOf(General.Toros.Codigo, DIIO.Toro))
                    '    cboToros.Enabled = True
                    'End If

                    If cboCentros.Text.Trim <> lblCentro.Text.Trim Then
                        lblCentro.ForeColor = Color.Red
                    Else
                        lblCentro.ForeColor = SystemColors.ControlText
                    End If

                    cboFechasCub.Enabled = True
                    txtDiasGest.Enabled = True
                    'dtpFecha.Enabled = True
                    cboCondiciones.Enabled = True
                    'cboToros.Enabled = True
                    cboEstProductivos.Enabled = True
                    'cboTipoDesechos.Enabled = True

                    'cboCondiciones.Focus()
                    btnGrabar.Enabled = True

                    cboCondiciones.Focus()
                Else
                    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
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


    Public Sub ConsultaPalpaciones(ByVal cent_ As String)
        'lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = 0
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        ''lvGanado.Items.Clear()

        'InicializaTotales()
        'MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPalpaciones_ListadoManualesSinProcesar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    pbProcesa.Maximum = vret
                    'End If


                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

                    item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add("")                                   'empresa
                    item.SubItems.Add(rdr("PalSala").ToString.Trim)              'centro
                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add(rdr("PalFecha").ToString.Trim)
                    item.SubItems.Add(rdr("PalHora").ToString.Trim)
                    'item.SubItems.Add(Format(rdr("PlpFec"), "dd-MM-yyyy hh:mm")) '+ " " + rdr("PalHora").ToString.Trim)
                    'item.SubItems.Add(rdr("VetNom").ToString.Trim)
                    item.SubItems.Add("")                                               'veterinario
                    item.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                    item.SubItems.Add(rdr("Nomconp").ToString.Trim)

                    lvGanado.Items.Add(item)

                    'ProcesaTotales(rdr("PlpExmOvarico").ToString.Trim)

                    i = i + 1
                    'pbProcesa.Value = i
                End While

                'pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvGanado.EndUpdate()

        If i = 0 Then
            btnEliminar.Enabled = False
            btnFinalizar.Enabled = False
        Else
            btnEliminar.Enabled = True
            btnFinalizar.Enabled = True
        End If

        'Total_General = i
        'MuestraTotales()
        'pnlProcesa.Visible = False
    End Sub


    Private Function GrabarPalpacion() As Boolean
        GrabarPalpacion = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPalpaciones_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim cond_ As Integer = 0
        Dim desec_ As Integer = 0                                                        'desecho
        Dim dgest_ As Integer = 0                                                        'dias gestacion
        Dim fech As String = Format(dtpFecha.Value, "dd-MM-yyyy")
        Dim estprod_ As String = ""
        Dim toro_ As String = ""
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        vet_ = General.Veterinarios.Codigo(cboVeterinarios.SelectedIndex)
        cond_ = General.Condiciones.Codigo(cboCondiciones.SelectedIndex)
        If cboToros.SelectedIndex <> -1 Then toro_ = General.Toros.Codigo(cboToros.SelectedIndex)
        If cboEstProductivos.SelectedIndex <> -1 Then estprod_ = cboEstProductivos.Text
        If cboTipoDesechos.SelectedIndex <> -1 Then desec_ = General.TipoDesechos.Codigo(cboTipoDesechos.SelectedIndex)
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@PALFECHA", fech)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@PALSALA", cent_)
        cmd.Parameters.AddWithValue("@PALDIIO", txtDIIO.Text.Trim)
        cmd.Parameters.AddWithValue("@PALVETERINARIO", vet_)
        cmd.Parameters.AddWithValue("@PALCONDICION", cond_)
        cmd.Parameters.AddWithValue("@PALDESECHO", desec_)
        cmd.Parameters.AddWithValue("@PALDIASGEST", txtDiasGest.Text.Trim)
        cmd.Parameters.AddWithValue("@PALESTADOPROD", estprod_)
        cmd.Parameters.AddWithValue("@PALTORO", toro_)
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

            GrabarPalpacion = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function EliminarPalpacionPDA(ByVal fecha_ As String, ByVal hora_ As String, ByVal sala_ As String, ByVal diio_ As String) As Boolean
        EliminarPalpacionPDA = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPalpaciones_Eliminar1", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@PalFecha", fecha_)
        cmd.Parameters.AddWithValue("@PalHora", hora_)
        cmd.Parameters.AddWithValue("@PalSala", sala_)
        cmd.Parameters.AddWithValue("@PalDiio", diio_)
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

            EliminarPalpacionPDA = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function FinalizarPalpacion() As Boolean
        FinalizarPalpacion = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPalpaciones_FinalizarManuales", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300        'un minuto y 30 segundos

        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim cond_ As Integer = 0
        Dim desec_ As Integer = 0                                                        'desecho
        Dim dgest_ As Integer = 0                                                        'dias gestacion
        Dim estprod_ As String = ""
        Dim toro_ As String = ""

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        '
        cmd.Parameters.AddWithValue("@Centro", cent_)
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

            FinalizarPalpacion = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub ConsultaPalpacionesSinProcesar()
        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        If cboCentros.Text.Trim <> "" Then
            Cursor.Current = Cursors.WaitCursor
            ConsultaPalpaciones(cent_)
            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub txtDiasGest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiasGest.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If cboToros.Enabled = True Then
                cboToros.Focus()
            Else
                cboEstProductivos.Focus()
            End If
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If cboCentros.Text.Trim <> "" And cboVeterinarios.Text.Trim <> "" Then
            txtDIIO.Enabled = True
            btnBuscar.Enabled = True
        Else
            txtDIIO.Enabled = False
            btnBuscar.Enabled = False
        End If

        ConsultaPalpacionesSinProcesar()
    End Sub


    Private Sub cboVeterinarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVeterinarios.SelectedIndexChanged
        If cboCentros.Text.Trim <> "" And cboVeterinarios.Text.Trim <> "" Then
            txtDIIO.Enabled = True
            btnBuscar.Enabled = True
        Else
            txtDIIO.Enabled = False
            btnBuscar.Enabled = False
        End If
    End Sub

    Private Sub cboCondiciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCondiciones.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDiasGest.Focus()
        End If
    End Sub


    Private Sub cboCondiciones_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCondiciones.SelectedIndexChanged
        If cboCondiciones.SelectedIndex = -1 Then Exit Sub

        If cboCondiciones.Text = "PREÑADA" Then
            cboToros.SelectedIndex = 0
            cboToros.Enabled = True
        Else
            cboToros.SelectedIndex = 0
            cboToros.Enabled = False
        End If
    End Sub

    Private Sub cboEstProductivos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboEstProductivos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If cboTipoDesechos.Enabled = True Then
                cboTipoDesechos.Focus()
            End If
        End If
    End Sub


    Private Sub cboEstProductivos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstProductivos.SelectedIndexChanged
        If cboEstProductivos.SelectedIndex = -1 Then Exit Sub

        Dim vercausas_ As String

        'estprod_ = cboEstadosProductivos.Text
        vercausas_ = General.EstProductivos.Causa(Array.IndexOf(General.EstProductivos.Nombre, cboEstProductivos.Text))

        If vercausas_ = "S" Then
            cboTipoDesechos.Enabled = True
        Else
            cboTipoDesechos.SelectedIndex = -1
            cboTipoDesechos.Enabled = False
        End If
    End Sub


    Private Sub cboFechasCub_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFechasCub.SelectedIndexChanged
        If cboFechasCub.SelectedIndex = -1 Then Exit Sub

        If cboFechasCub.Text = "MONTA" Then
            txtDiasGest.ReadOnly = False
            txtDiasGest.Text = ""
            lblFecProbParto.Text = "---"
            txtDiasGest.Focus()
            Exit Sub
        End If

        txtDiasGest.ReadOnly = True

        Dim fcub_ As Date
        Dim diff As Integer = 0

        fcub_ = cboFechasCub.Text
        'diff = DateDiff(DateInterval.Day, fcub_, Now)
        diff = DateDiff(DateInterval.Day, fcub_, dtpFecha.Value)

        txtDiasGest.Text = diff.ToString.Trim

        'lblFecProbParto.Text = Format(Now.AddDays(282 - diff), "dd-MM-yyyy")
        lblFecProbParto.Text = Format(dtpFecha.Value.AddDays(282 - diff), "dd-MM-yyyy")
    End Sub


    Private Sub txtDiasGest_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiasGest.TextChanged
        Dim dgest As Integer = 0

        dgest = Val(txtDiasGest.Text)

        If dgest = 0 Then
            lblFecProbParto.Text = "---"
            Exit Sub
        End If

        'lblFecProbParto.Text = Format(Now.AddDays(282 - dgest), "dd-MM-yyyy")
        lblFecProbParto.Text = Format(dtpFecha.Value.AddDays(282 - dgest), "dd-MM-yyyy")
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarPalpacion() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            LimpiaDatos(True)
            txtDIIO.Focus()

            ConsultaPalpacionesSinProcesar()
        End If
    End Sub


    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If cboCentros.SelectedIndex = -1 Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA PROCESAR LAS PALPACIONES ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If FinalizarPalpacion() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            LimpiaDatos(True)
            txtDIIO.Focus()

            Cerrar()
        End If
    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub txtDIIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
        End If
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)


    End Sub


    Private Sub frmPalpacionesIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaVeterinarios()
        CboLLenaCondiciones()
        CboLLenaToros()
        CboLLenaEstadosProductivos()
        CboLLenaTipoDesechos()

        cboCentros.Text = CentroPorDefecto()
        dtpFecha.Value = Now()
    End Sub

    Private Sub cboToros_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboToros.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cboEstProductivos.Focus()
        End If
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'If ValidacionesLocales() = False Then Exit Sub
        If lvGanado.Items.Count = 0 Then Exit Sub
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim fecha_ As String = lvGanado.SelectedItems.Item(0).SubItems(6).Text
        Dim hora_ As String = lvGanado.SelectedItems.Item(0).SubItems(7).Text
        Dim sala_ As String = lvGanado.SelectedItems.Item(0).SubItems(3).Text
        Dim diio_ As String = lvGanado.SelectedItems.Item(0).SubItems(4).Text

        'MsgBox(fecha_)
        'MsgBox(hora_)
        'MsgBox(sala_)
        'MsgBox(diio_)

        'Exit Sub

        'If diio_ = 0 Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA ELIMINAR LA PALPACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarPalpacionPDA(fecha_, hora_, sala_, diio_) = True Then
            'If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            ConsultaPalpacionesSinProcesar()
        End If
    End Sub

    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub
End Class