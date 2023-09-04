

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO


Public Class FrmLecheAsistenciaIngreso
    Private TotalLecheDia As Integer = 0
    Private TotalVacasDia As Integer = 0
    Private TotalLechePlanta As Integer = 0
    Private TotalVacasPlanta As Integer = 0
    Private NroOrdenias As Integer = 0

    Private EnEventoLoad As Boolean = True
    Private ExisteIngresoLeche As Boolean = False
    Private ExisteIngresoAsistencia As Boolean = False
    Private ExisteIngresoRetiro As Boolean = False

    Private NroEstanques As Integer

    Private SeleccionaNomenclatura As Boolean
    Private NombreNomenclatura() As String
    Private NombreMotivoHE() As String

    Private SelectRowCellEstado As Integer = -1
    Private SelectColCellEstado As Integer = -1
    Private SelectRowCellMotivoHE As Integer = -1
    Private SelectColCellMotivoHE As Integer = -1

    Dim Cestados As New DataGridViewComboBoxColumn



    Private Sub FrmLecheAsistenciaIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.nomenclaturas.Cargar()
        General.MotivosHorasExtras.Cargar()
        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8

        dtpFecha.Value = Now
        rbtnAM.Checked = True

        CboLLenaCentros()
        LlenaDataTables()
        InicializaEstanques()

        EnEventoLoad = False

        'solamente de jefes de producción hacia arriba
        If PerfilUsuario < 3 Then
            btnVBTarja.Visible = False
        Else
            If PerfilUsuario = 5 Then btnAdminVBTarja.Visible = True
        End If

        If PerfilUsuario = 6 Then
            btnVBTarja.Visible = True
            'btnAdminVBTarja.Top = btnVBTarja.Top
            btnAdminVBTarja.Visible = True
            ''
            GroupBox10.Visible = False
            tabIngresos.TabPages.Remove(TabPage1)
            tabIngresos.TabPages.Remove(TabPage3)
            ''
            'btnGrabar.Visible = False
            'btnEliminar.Visible = False
            btnAgregarMastitis.Visible = False
            btnCojeraMastitis.Visible = False
            btnImprime.Visible = False
        End If


        BuscarDatos()
    End Sub


    Private Sub InicializaEstanques()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCentros_NroEstanquesLeche", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        con.Open()
        rdr = cmd.ExecuteReader()

        'siempre existe un registro, que devuleve los litros totales diarios, la temperatura...
        'y antes del resultado limpiamos todo la pestaña de ingreso de leche
        LimpiaGrillaLecheEnc()

        While rdr.Read()
            NroEstanques = rdr("NroEstanques")
            Exit While
        End While

        rdr.Close()
        cmd.Dispose()
        con.Close()

        TxtTempEst1.Visible = True
        TxtTempEst2.Enabled = False
        Label18.Enabled = False

        If NroEstanques > 1 Then
            TxtTempEst2.Enabled = True
            Label18.Enabled = True
        End If
    End Sub


    Private Sub CalculaNroVacasSecas()

        Dim vacas_ordeñadas As Integer = IIf(LbTotVacas.Text.Replace(".", "") <> "", Int32.Parse(LbTotVacas.Text.Replace(".", "")), 0)
        Dim vacas_stock As Integer = IIf(lvESTADOGANADO.Items(0).SubItems(0).Text <> "", Int32.Parse(lvESTADOGANADO.Items(0).SubItems(0).Text), 0)

        lblNroVacasSecas.Text = (vacas_stock - vacas_ordeñadas).ToString.Trim

        If lblNroVacasSecas.Text = "0" Then
            pnlVacasSecas.Visible = False
        Else
            pnlVacasSecas.Visible = True
        End If

    End Sub


    Public Sub valida_tecla(ByVal tecla As Char)

        If tecla = ChrW(Keys.Enter) Then
            ' tecla.Handled = True
            SendKeys.Send("{TAB}")
        End If

        Dim caracter As Char = tecla

        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            tecla = Chr(0)
        End If

    End Sub

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer
        'Dim posicionselected As Integer
        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            'If General.CentrosUsuario.Codigo(i) = General.CodigoCentroUsuario Then
            ' posicionselected = i
            ' End If
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
        'cboCentros.SelectedIndex = posicionselected

        cboCentros.Text = NombreCentroUsuario
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If cboCentros.SelectedIndex <> -1 Then
            If VerificaAsistencia() = False Then
                'If lblTotHrsExtras.Text = "" Or lblTotHrsExtras.Text = "0" Then
                If MsgBox("DEBE INGRESAR LA ASISTENCIA, PARA PODER CERRAR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
                End If
                Exit Sub
            End If
        End If

        Me.Close()
    End Sub


    Private Sub LlenaDataTables()
        ''cargamos estado de asistencia de funcionarios
        Dim Detalles As New DataTable("NomenclaturasAsistencia")
        Detalles.Columns.Add("codigo")
        Detalles.Columns.Add("descrip")

        For i = 0 To General.nomenclaturas.NroRegistros - 1
            Detalles.Rows.Add(General.nomenclaturas.ID(i), General.nomenclaturas.Nombre(i))
        Next

        '        Dim Cestados As New DataGridViewComboBoxColumn
        Cestados.Width = "150"
        Cestados.DisplayMember = "descrip"
        Cestados.ValueMember = "codigo"
        Cestados.DataSource = Detalles
        Cestados.HeaderText = "Estado "
        Cestados.DisplayIndex = 0

        dgvAsistencia.Columns.Add(Cestados)
        dgvAsistencia.Columns(8).DisplayIndex = 2


        ''cargamos motivo de horas extras
        Dim DTMotivosHE As New DataTable("MotivosHorasExtras")
        DTMotivosHE.Columns.Add("codigo")
        DTMotivosHE.Columns.Add("descrip")

        For i = 0 To General.MotivosHorasExtras.NroRegistros - 1
            DTMotivosHE.Rows.Add(General.MotivosHorasExtras.Codigo(i), General.MotivosHorasExtras.Nombre(i))
        Next

        Dim MotivosHE As New DataGridViewComboBoxColumn
        MotivosHE.Width = "170"
        MotivosHE.DisplayMember = "descrip"
        MotivosHE.ValueMember = "codigo"
        MotivosHE.DataSource = DTMotivosHE
        MotivosHE.HeaderText = "Motivo HHEE"
        MotivosHE.DisplayIndex = 1

        dgvAsistencia.Columns.Add(MotivosHE)
        dgvAsistencia.Columns(9).DisplayIndex = 4
    End Sub


    Private Sub CalculaTotalesLeche(ByVal txt As TextBox)
        If txt.Text = "" Then
            txt.Text = 0
        End If

        lbTotLitros.Text = Int32.Parse(LitrosPlanta.Text) + Int32.Parse(LitrosCalostro.Text) + Int32.Parse(LitrosAntibioticos.Text) + Int32.Parse(LitrosMala.Text) + Int32.Parse(LitrosTerneros.Text)
        LbTotVacas.Text = Int32.Parse(VacasPlanta.Text) + Int32.Parse(VacasAntibioticos.Text) + Int32.Parse(VacasCalostro.Text) + Int32.Parse(VacasMalas.Text) + Int32.Parse(VacasTerneros.Text)

        If Int32.Parse(lbTotLitros.Text) > 0 And Int32.Parse(LbTotVacas.Text.Replace(".", "")) > 0 And Int32.Parse(lbTotLitros.Text) > Int32.Parse(LbTotVacas.Text.Replace(".", "")) Then
            LbTotLtVacas.Text = Math.Round(Int32.Parse(lbTotLitros.Text) / Int32.Parse(LbTotVacas.Text.Replace(".", "")), 1)
        End If

        ''
        CalculaDosisConcentrado()
        CalculaNroVacasSecas()
    End Sub



    Private Sub LitrosPlanta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles LitrosPlanta.LostFocus, LitrosTerneros.LostFocus, LitrosCalostro.LostFocus, LitrosAntibioticos.LostFocus, LitrosMala.LostFocus, _
                    VacasPlanta.LostFocus, VacasTerneros.LostFocus, VacasCalostro.LostFocus, VacasAntibioticos.LostFocus, VacasMalas.LostFocus

        Dim text As TextBox = DirectCast(sender, TextBox)

        ''CALCULAMOS VALORES TOTALES Y DE CONCENTRADO
        CalculaTotalesLeche(text)
    End Sub


    Private Sub LitrosPlanta_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles LitrosPlanta.Click, LitrosTerneros.Click, LitrosCalostro.Click, LitrosAntibioticos.Click, LitrosMala.Click, _
                    VacasPlanta.Click, VacasTerneros.Click, VacasCalostro.Click, VacasAntibioticos.Click, VacasMalas.Click

        Dim text As TextBox = DirectCast(sender, TextBox)

        text.SelectAll()
    End Sub


    Private Sub LitrosPlanta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles LitrosPlanta.KeyPress, LitrosPlanta.KeyPress, LitrosCalostro.KeyPress, LitrosAntibioticos.KeyPress, LitrosMala.KeyPress, _
                    VacasPlanta.KeyPress, VacasTerneros.KeyPress, VacasCalostro.KeyPress, VacasAntibioticos.KeyPress, VacasMalas.KeyPress

        Dim text As TextBox = DirectCast(sender, TextBox)

        valida_tecla(e.KeyChar)
        Dim caracter As Char = e.KeyChar

        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
        'valida_tecla(e.KeyChar)
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If EnEventoLoad Then Exit Sub
        BuscarDatos()   'buscamos datos (cargando nuevamente los funcionarios)
        InicializaEstanques()
    End Sub


    Private Sub FechaOrdena_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        If EnEventoLoad Then Exit Sub
        BuscarDatos()  'buscamos datos (sin cargar los funcionarios, ya que solo cambia la fecha)

        If dtpFecha.Value.Day = 14 Or dtpFecha.Value.Day = 15 Then
            dgvAsistencia.Columns(3).Visible = True
            dgvAsistencia.Columns(4).Visible = True
            dgvAsistencia.Columns(5).Visible = True
            dgvAsistencia.Columns(6).Visible = True
            dgvAsistencia.Columns(7).Visible = True
        Else
            dgvAsistencia.Columns(3).Visible = False
            dgvAsistencia.Columns(4).Visible = False
            dgvAsistencia.Columns(5).Visible = False
            dgvAsistencia.Columns(6).Visible = False
            dgvAsistencia.Columns(7).Visible = True
        End If
    End Sub


    Private Sub BuscarDatos(Optional ByVal LimpiaIngresoLeche As Boolean = True, Optional ByVal LimpiaAsistencia As Boolean = True)
        If cboCentros.SelectedIndex = -1 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim hr As String = IIf(rbtnAM.Checked = True, "AM", "PM")

        ''PRIMERO BUSCAMOS INGRESO DE LECHE (ENC: TEMP°)
        '.....................................................................
        If LimpiaIngresoLeche = True Then
            BuscarIngresoLeche(hr)
            BuscarIngresoLecheDetalle(hr)
            BuscarConcentrado(hr)

            If ExisteIngresoLeche = True Then
                BuscarEstadoGanado(hr)
            Else
                NuevoEstadoGanado()
            End If
        End If
        '.....................................................................
        If LimpiaAsistencia = True Then
            BuscarAsistenciaFuncionarios(hr)
        End If
        '.....................................................................
        BuscarRetiroLeche()
        '.....................................................................

        ValidaBotonGrabar()         'validamos boton grabar, esto seria deshabilitar o no el boton
        Graficos()                  'mostramos graficos
        CalculaNroVacasSecas()      'calculamos nro vacas secas (vacas ordeñadas - vacas est. ganado)

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub FechaOrdena_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.TextChanged
        'If existe_registro() = True Then
        '    MsgBox("Ya Existe un registro.")
        '    Asistencia.Rows.Clear()
        '    DgEntregaLeche.Rows.Clear()
        '    recuperaleche()
        '    recuperaconcentardo()
        '    recuperaentrega()
        '    recuperafunc()
        '    btnGrabar.Enabled = False
        '    btnEliminar.Enabled = True

        'Else
        '    CboLLenaFuncionarios()

        '    btnGrabar.Enabled = True
        '    btnEliminar.Enabled = False
        'End If
    End Sub



    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboCentros.SelectedIndex = -1 Then Exit Sub

        'If DateTime.Parse(Format(dtpFecha.Value, "dd-MM-yyyy")) <= DateTime.Parse("06-03-2013") Then
        '    If MsgBox("NO SE PUEDE INGRESAR INFORMACIÓN CON FECHA MENOR O IGUAL AL 06-03-2013", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
        '    End If
        '    Exit Sub
        'End If

        'todos los perfiles validan ordeña y todo (menos RRHH).....
        If PerfilUsuario <> 6 Then
            ''SI NO HAY UN CIERRE DE TEMPORADA, ENTONCES VALIDAMOS DATOS DE ORDEÑA
            If BuscarCierreTemporada() = False Then
                If ValidaHoraFinalizacionOrdeña() = False Then
                    txtHoraTermino.Focus()
                    Exit Sub
                End If

                If ValidaHoraTomaTemperaturas() = False Then
                    txtTempHora.Focus()
                    Exit Sub
                End If
            End If


            Select Case tabIngresos.SelectedIndex
                Case 0  'INGRESO DE LECHE
                    '........................................................................................................
                    If ValidaLeche() = False Then Exit Sub

                    If MsgBox("¿ DESEA GUARDAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If

                    If GrabarLeche() = True Then
                        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                        End If

                        If rbtnAM.Checked = True Then
                            TotalLecheDia = Int32.Parse(lbTotLitros.Text)
                            TotalVacasDia = Int32.Parse(LbTotVacas.Text)
                            ''
                            TotalLechePlanta = Int32.Parse(LitrosPlanta.Text)
                            TotalVacasPlanta = Int32.Parse(VacasPlanta.Text)
                            ''
                            NroOrdenias = 1
                        Else
                            TotalLecheDia = TotalLecheDia + Int32.Parse(lbTotLitros.Text)
                            TotalVacasDia = TotalVacasDia + Int32.Parse(LbTotVacas.Text)
                            ''
                            TotalLechePlanta = TotalLechePlanta + Int32.Parse(LitrosPlanta.Text)
                            TotalVacasPlanta = TotalVacasPlanta + Int32.Parse(VacasPlanta.Text)
                            ''
                            NroOrdenias = 2
                        End If

                        lblTotLEcheDia.Text = Format(TotalLecheDia, "#,#") '+ " Lts."
                        lblTotLEchePlanta.Text = Format(TotalLechePlanta, "#,#") '+ " Lts."

                        Dim pvacas_dia_ As Double = TotalVacasDia
                        Dim pvacas_planta_ As Double = TotalVacasPlanta

                        If NroOrdenias > 1 Then
                            pvacas_dia_ = (TotalVacasDia / NroOrdenias)
                            pvacas_planta_ = (TotalVacasPlanta / NroOrdenias)
                        End If

                        If pvacas_dia_ > 0 Then lblLtsXVacaDia.Text = Format(Math.Round(TotalLecheDia / pvacas_dia_, 6), "#,#.00")
                        If pvacas_planta_ > 0 Then lblLtsXVacaPlanta.Text = Format(Math.Round(TotalLechePlanta / pvacas_planta_, 6), "#,#.00")

                    End If

                Case 1  'ASISTENCIA
                    '........................................................................................................
                    If ValidaAsistencia() = False Then Exit Sub

                    If MsgBox("¿ DESEA GUARDAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If

                    If GrabarAsistencia() = True Then
                        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                        End If
                    End If

                Case 2  'RETIRO LECHE
                    '........................................................................................................
                    If ValidaRetiro() = False Then Exit Sub

                    If MsgBox("¿ DESEA GUARDAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If

                    If GrabarRetiro() = True Then
                        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                        End If
                    End If
            End Select
        Else
            'SI EL PERFIL ES RRHH
            If ValidaAsistencia() = False Then Exit Sub

            If MsgBox("¿ DESEA GUARDAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            If GrabarAsistencia() = True Then
                If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                End If
            End If
        End If

        'validamos boton grabar para ver si se debe deshabilitar o no
        ValidaBotonGrabar()
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If cboCentros.SelectedIndex = -1 Then Exit Sub

        'If DateTime.Parse(Format(dtpFecha.Value, "dd-MM-yyyy")) <= DateTime.Parse("06-03-2013") Then
        '    If MsgBox("NO SE PUEDE ELIMINAR INFORMACIÓN CON FECHA MENOR O IGUAL AL 06-03-2013", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
        '    End If
        '    Exit Sub
        'End If
        If PerfilUsuario <> 6 Then
            Select Case tabIngresos.SelectedIndex
                Case 0  'INGRESO LECHE
                    '........................................................................................................
                    If MsgBox("¿ DESEA ELIMINAR EL -- INGRESO DE LECHE " + IIf(rbtnAM.Checked = True, "AM", "PM") + " -- ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If

                    If EliminarLeche() = True Then
                        If MsgBox("DATOS ELIMINADOS --- OK ---" + vbCrLf + vbCrLf + "¿ DESEA MANTENER LA INFORMACIÓN EN PANTALLA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            'End If

                            'If MsgBox("DATOS ELIMINADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                            ExisteIngresoLeche = False
                            BuscarDatos(False)  'buscamos datos cargando los funcionarios

                            BuscarIngresoLeche(IIf(rbtnAM.Checked = True, "AM", "PM"))

                            Exit Select
                        End If
                        BuscarDatos()  'buscamos datos sin cargar los funcionarios (ya que estamos en la pestaña de ingreso leche)
                    End If

                Case 1  'ASISTENCIA
                    '........................................................................................................
                    If MsgBox("¿ DESEA ELIMINAR LA -- ASISTENCIA -- ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If

                    If EliminarAsistencia() = True Then
                        If MsgBox("DATOS ELIMINADOS --- OK ---" + vbCrLf + vbCrLf + "¿ DESEA MANTENER LA INFORMACIÓN EN PANTALLA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            ExisteIngresoAsistencia = False

                            BuscarDatos(, False)  'buscamos datos cargando los funcionarios
                            For i As Integer = 0 To dgvAsistencia.Rows.Count - 1 : dgvAsistencia.Rows(i).Cells(2).ReadOnly = False : Next

                            'btnGrabar.Enabled = True
                            'btnEliminar.Enabled = False
                            Exit Select
                        End If
                        BuscarDatos()  'buscamos datos cargando los funcionarios
                    End If

                Case 2  'RETIRO LECHE
                    '........................................................................................................
                    If dgvRetiroLeche.Rows.Count < 2 Then Exit Sub 'sitiene solo una linea salimos
                    If dgvRetiroLeche.CurrentRow.Index = (dgvRetiroLeche.Rows.Count - 1) Then Exit Sub 'si tiene

                    If MsgBox("¿ DESEA ELIMINAR EL -- RETIRO DE LECHE -- ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If

                    If EliminarRetiroLeche() = True Then
                        If MsgBox("DATOS ELIMINADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                        End If
                        BuscarDatos()
                    End If
            End Select

            'validamos boton grabar para ver si se debe deshabilitar o no
            ValidaBotonGrabar()
        Else
            If MsgBox("¿ DESEA ELIMINAR LA -- ASISTENCIA -- ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            If EliminarAsistencia() = True Then
                If MsgBox("DATOS ELIMINADOS --- OK ---" + vbCrLf + vbCrLf + "¿ DESEA MANTENER LA INFORMACIÓN EN PANTALLA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    ExisteIngresoAsistencia = False

                    BuscarDatos(, False)  'buscamos datos cargando los funcionarios
                    For i As Integer = 0 To dgvAsistencia.Rows.Count - 1 : dgvAsistencia.Rows(i).Cells(2).ReadOnly = False : Next

                    'btnGrabar.Enabled = True
                    'btnEliminar.Enabled = False
                    ValidaBotonGrabar()
                    Exit Sub
                End If

                BuscarDatos()  'buscamos datos cargando los funcionarios
            End If
        End If
    End Sub


    Private Function GrabarLeche() As Boolean
        GrabarLeche = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_GrabarIngresoLeche", con)
        'Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE LECHE
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        Dim cent_ As String = ""
        Dim diios_ As String = ""
        Dim i As Integer = 0
        ''
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean
        ''
        Dim litros(4) As Integer
        Dim vacas(4) As Integer

        litros(0) = LitrosPlanta.Text
        litros(1) = LitrosTerneros.Text
        litros(2) = LitrosCalostro.Text
        litros(3) = LitrosAntibioticos.Text
        litros(4) = LitrosMala.Text

        vacas(0) = VacasPlanta.Text
        vacas(1) = VacasTerneros.Text
        vacas(2) = VacasCalostro.Text
        vacas(3) = VacasAntibioticos.Text
        vacas(4) = VacasMalas.Text
        ''
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        For i = 0 To litros.Count - 1
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", cent_)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Horario", IIf(rbtnAM.Checked = True, 1, 2))
            cmd.Parameters.AddWithValue("@HoraTermino", txtHoraTermino.Text)
            cmd.Parameters.AddWithValue("@TempEstanque1", TxtTempEst1.Text)
            cmd.Parameters.AddWithValue("@TempEstanque2", TxtTempEst2.Text)
            cmd.Parameters.AddWithValue("@TempHora", txtTempHora.Text)
            cmd.Parameters.AddWithValue("@Observs", "")
            cmd.Parameters.AddWithValue("@TipoLeche", i + 1)
            cmd.Parameters.AddWithValue("@LitrosLeche", litros(i).ToString("#0"))
            cmd.Parameters.AddWithValue("@NumVacas", vacas(i).ToString("#0"))
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
        If HayError = True Then
            SRVTRANS.Rollback()
            GrabarLeche = False
            Exit Function
        End If

        Dim tdosis As Double = Double.Parse(TxtDosis.Text)
        Dim tconsent As Double = Double.Parse(TxtTotConcentrado.Text)

        If tconsent < tdosis Then
            tdosis = Double.Parse(TxtTotConcentrado.Text)
            tconsent = Double.Parse(TxtDosis.Text)
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'GRABAMOS REGISTRO DE CONCENTRADO, BAJO LA MISMA TRANSACCION
        Dim cmd2 As New SqlCommand("spLeche_GrabarConcentrado", con)
        cmd2.CommandType = Data.CommandType.StoredProcedure
        ''
        cmd2.Parameters.Clear()
        cmd2.Parameters.AddWithValue("@Commit", 0)
        cmd2.Parameters.AddWithValue("@Empresa", Empresa)
        cmd2.Parameters.AddWithValue("@Centro", cent_)
        cmd2.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd2.Parameters.AddWithValue("@Horario", IIf(rbtnAM.Checked = True, 1, 2))
        cmd2.Parameters.AddWithValue("@TotVacas", LbTotVacas.Text)
        cmd2.Parameters.AddWithValue("@CantDosis", tdosis)
        cmd2.Parameters.AddWithValue("@TotDosis", tconsent)
        cmd2.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd2.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd2.Parameters.Add("@RetValor", SqlDbType.Int) : cmd2.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd2.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd2.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            cmd2.Transaction = SRVTRANS
            Result = cmd2.ExecuteNonQuery()

            vret = cmd2.Parameters("@RetValor").Value
            mret = cmd2.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

                HayError = True
                'Exit Try
            End If

            HayError = False
            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            'GrabarGrupoParto = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            HayError = True
        End Try

        'si hay error hasta aqui salimos
        If HayError = True Then
            SRVTRANS.Rollback()
            GrabarLeche = False
            Exit Function
        End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'GRABAMOS REGISTRO DE ESTADO DE GANADO
        Dim cmd3 As New SqlCommand("spGanadoEstado_Grabar", con)
        cmd3.CommandType = Data.CommandType.StoredProcedure
        ''
        For i = 0 To lvESTADOGANADO.Columns.Count - 1
            cmd3.Parameters.Clear()
            cmd3.Parameters.AddWithValue("@Commit", 0)
            cmd3.Parameters.AddWithValue("@Empresa", Empresa)
            cmd3.Parameters.AddWithValue("@Centro", cent_)
            cmd3.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd3.Parameters.AddWithValue("@Horario", IIf(rbtnAM.Checked = True, 1, 2))
            cmd3.Parameters.AddWithValue("@Conforme", IIf(rbtnConforme.Checked = True, 1, 0))
            cmd3.Parameters.AddWithValue("@Observs", txtObservsEstado.Text)
            cmd3.Parameters.AddWithValue("@Categoria", lvESTADOGANADO.Columns(i).Text)
            cmd3.Parameters.AddWithValue("@NumGnd", Int32.Parse(lvESTADOGANADO.Items(0).SubItems(i).Text))
            cmd3.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd3.Parameters.AddWithValue("@Equipo", NombrePC)
            ''
            cmd3.Parameters.Add("@RetValor", SqlDbType.Int) : cmd3.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd3.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd3.Parameters("@RetMensage").Direction = ParameterDirection.Output

            Try
                cmd3.Transaction = SRVTRANS
                Result = cmd3.ExecuteNonQuery()

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

        ''VALIDAMOS SI TODO ESTA OK
        If HayError = False Then
            SRVTRANS.Commit()
            GrabarLeche = True
            ExisteIngresoLeche = True
        Else
            SRVTRANS.Rollback()
            GrabarLeche = False
            ExisteIngresoLeche = False
        End If

        con.Close()
        Cursor.Current = Cursors.Default
    End Function


    Private Function GrabarAsistencia() As Boolean
        GrabarAsistencia = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spAsistencia_Grabar", con)
        'Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE ASISTENCIA
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        Dim cent_ As String = ""
        'Dim diios_ As String = ""
        Dim i As Integer = 0
        ''
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean
        Dim Asiste As Integer
        'Dim hrAM As Integer
        'Dim hrPM As Integer
        Dim MotivoHE As Integer
        'Dim hr1 As DataGridViewCheckBoxCell
        'Dim hr2 As DataGridViewCheckBoxCell

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        For i = 0 To dgvAsistencia.Rows.Count - 1
            Asiste = 0
            'hrPM = 0
            MotivoHE = 0

            If Not dgvAsistencia.Rows(i).Cells(9).Value Is Nothing Then
                If dgvAsistencia.Rows(i).Cells(9).Value.ToString.Trim <> "" Then
                    MotivoHE = Int32.Parse(dgvAsistencia.Rows(i).Cells(9).Value)
                End If
            End If


            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", cent_)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Horario", IIf(rbtnAM.Checked = True, 1, 2))
            cmd.Parameters.AddWithValue("@Rut", dgvAsistencia.Rows(i).Cells(0).Value.ToString.Trim)
            cmd.Parameters.AddWithValue("@Nomenclatura", Int32.Parse(dgvAsistencia.Rows(i).Cells(8).Value))
            cmd.Parameters.AddWithValue("@HHEE", Double.Parse(dgvAsistencia.Rows(i).Cells(2).Value))
            cmd.Parameters.AddWithValue("@MotivoHE", MotivoHE)
            cmd.Parameters.AddWithValue("@BonoLenia", Int32.Parse(dgvAsistencia.Rows(i).Cells(3).Value))
            cmd.Parameters.AddWithValue("@BonoPodal", Int32.Parse(dgvAsistencia.Rows(i).Cells(4).Value))
            cmd.Parameters.AddWithValue("@BonoColacion", Int32.Parse(dgvAsistencia.Rows(i).Cells(5).Value))
            cmd.Parameters.AddWithValue("@BonoResponsab", Int32.Parse(dgvAsistencia.Rows(i).Cells(6).Value))
            cmd.Parameters.AddWithValue("@BonoOtros", Int32.Parse(dgvAsistencia.Rows(i).Cells(7).Value))
            cmd.Parameters.AddWithValue("@Turno", 0)
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
            GrabarAsistencia = True
            ExisteIngresoAsistencia = True
        Else
            SRVTRANS.Rollback()
            GrabarAsistencia = False
            ExisteIngresoAsistencia = False
        End If

        'SumaHHEE()

        con.Close()
        Cursor.Current = Cursors.Default
    End Function


    Private Function GrabarRetiro() As Boolean
        GrabarRetiro = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_GrabarRetiro", con)
        'Dim rdr As SqlDataReader = Nothing
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
        Dim cent_ As String = ""
        Dim trans As String
        Dim guia As Integer
        Dim palcohol As Integer
        Dim verde, amarillo, rojo As Integer

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        For i = 0 To dgvRetiroLeche.Rows.Count - 1
            If dgvRetiroLeche.Rows(i).Cells(3).Value Is Nothing Then Exit For

            trans = ""
            guia = 0
            palcohol = 0
            verde = 0
            amarillo = 0
            rojo = 0

            If Not dgvRetiroLeche.Rows(i).Cells(0).Value Is Nothing Then trans = dgvRetiroLeche.Rows(i).Cells(0).Value
            If Not dgvRetiroLeche.Rows(i).Cells(1).Value Is Nothing Then guia = dgvRetiroLeche.Rows(i).Cells(1).Value

            If Not dgvRetiroLeche.Rows(i).Cells(7).Value Is Nothing Then
                If dgvRetiroLeche.Rows(i).Cells(7).Value.GetType() Is GetType(Boolean) Then palcohol = IIf(dgvRetiroLeche.Rows(i).Cells(7).Value = False, 0, 1)
                If dgvRetiroLeche.Rows(i).Cells(7).Value.GetType() Is GetType(String) Then palcohol = IIf(dgvRetiroLeche.Rows(i).Cells(7).Value = "", 0, 1)
            End If

            If Not dgvRetiroLeche.Rows(i).Cells(8).Value Is Nothing Then
                If dgvRetiroLeche.Rows(i).Cells(8).Value.GetType() Is GetType(Boolean) Then verde = IIf(dgvRetiroLeche.Rows(i).Cells(8).Value = False, 0, 1)
                If dgvRetiroLeche.Rows(i).Cells(8).Value.GetType() Is GetType(String) Then verde = IIf(dgvRetiroLeche.Rows(i).Cells(8).Value = "", 0, 1)
            End If

            If Not dgvRetiroLeche.Rows(i).Cells(9).Value Is Nothing Then
                If dgvRetiroLeche.Rows(i).Cells(9).Value.GetType() Is GetType(Boolean) Then amarillo = IIf(dgvRetiroLeche.Rows(i).Cells(9).Value = False, 0, 1)
                If dgvRetiroLeche.Rows(i).Cells(9).Value.GetType() Is GetType(String) Then amarillo = IIf(dgvRetiroLeche.Rows(i).Cells(9).Value = "", 0, 1)
            End If

            If Not dgvRetiroLeche.Rows(i).Cells(10).Value Is Nothing Then
                If dgvRetiroLeche.Rows(i).Cells(10).Value.GetType() Is GetType(Boolean) Then rojo = IIf(dgvRetiroLeche.Rows(i).Cells(10).Value = False, 0, 1)
                If dgvRetiroLeche.Rows(i).Cells(10).Value.GetType() Is GetType(String) Then rojo = IIf(dgvRetiroLeche.Rows(i).Cells(10).Value = "", 0, 1)
            End If

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", cent_)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Transporte", trans)
            cmd.Parameters.AddWithValue("@NroGuia", guia)
            cmd.Parameters.AddWithValue("@Hora", dgvRetiroLeche.Rows(i).Cells(2).Value)
            cmd.Parameters.AddWithValue("@TransporteNuevo", dgvRetiroLeche.Rows(i).Cells(3).Value)
            cmd.Parameters.AddWithValue("@NroGuiaNuevo", Int32.Parse(dgvRetiroLeche.Rows(i).Cells(4).Value))
            cmd.Parameters.AddWithValue("@Litros", Int32.Parse(dgvRetiroLeche.Rows(i).Cells(5).Value))
            cmd.Parameters.AddWithValue("@Temperatura", Double.Parse(dgvRetiroLeche.Rows(i).Cells(6).Value))
            cmd.Parameters.AddWithValue("@PruebaOX", palcohol)
            cmd.Parameters.AddWithValue("@Verde", verde)
            cmd.Parameters.AddWithValue("@Amarillo", amarillo)
            cmd.Parameters.AddWithValue("@Rojo", rojo)
            cmd.Parameters.AddWithValue("@Observs", dgvRetiroLeche.Rows(i).Cells(11).Value)
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
            GrabarRetiro = True
            ExisteIngresoRetiro = True

            'como se grabo ok, actualizamo los dos primeros campos, de retiro
            For i = 0 To dgvRetiroLeche.Rows.Count - 1
                dgvRetiroLeche.Rows(i).Cells(0).Value = dgvRetiroLeche.Rows(i).Cells(3).Value
                dgvRetiroLeche.Rows(i).Cells(1).Value = dgvRetiroLeche.Rows(i).Cells(4).Value
            Next
        Else
            SRVTRANS.Rollback()
            GrabarRetiro = False
            ExisteIngresoRetiro = False
        End If

        'SumaLitrosRetiro()

        con.Close()
        Cursor.Current = Cursors.Default
    End Function


    Private Function EliminarLeche() As Boolean
        EliminarLeche = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_EliminarIngresoLeche", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(rbtnAM.Checked = True, 1, 2))
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

            EliminarLeche = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function EliminarAsistencia() As Boolean

        EliminarAsistencia = False

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spAsistencia_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(rbtnAM.Checked = True, 1, 2))
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

            EliminarAsistencia = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function TieneValorCelda(ByVal Linea As Integer, ByVal Columna As Integer) As Boolean
        TieneValorCelda = False

        If dgvRetiroLeche.Rows(Linea).Cells(Columna).Value Is Nothing Then Exit Function
        If dgvRetiroLeche.Rows(Linea).Cells(Columna).Value = "" Then Exit Function

        TieneValorCelda = True
    End Function


    Private Function EliminarRetiroLeche() As Boolean
        EliminarRetiroLeche = False
        Dim LineaActual As Integer = dgvRetiroLeche.CurrentRow.Index

        'verificamos si vamos a eliminar un registro recien creado (no grabado todavia)
        If TieneValorCelda(LineaActual, 0) = False Then
            dgvRetiroLeche.Rows.Remove(dgvRetiroLeche.CurrentRow)
        End If

        'si no hay un transporte y una guia salimos
        If TieneValorCelda(LineaActual, 2) = False Or TieneValorCelda(LineaActual, 3) = False Then Exit Function

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_EliminarRetiroLeche", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Transporte", dgvRetiroLeche.Rows(LineaActual).Cells(0).Value)
        cmd.Parameters.AddWithValue("@NroGuia", dgvRetiroLeche.Rows(LineaActual).Cells(1).Value)
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

            EliminarRetiroLeche = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function VerificaAsistencia() As Boolean
        VerificaAsistencia = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spAsistencia_Existe", con)
        'Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE ASISTENCIA
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        ''
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(rbtnAM.Checked = True, 1, 2))
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
                'If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                'End If
                Exit Try
            End If

            VerificaAsistencia = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        con.Close()
        Cursor.Current = Cursors.Default
    End Function


    Private Function ValidaHoraFinalizacionOrdeña() As Boolean
        ValidaHoraFinalizacionOrdeña = False

        'si la sala que estamos ingresando, ES AREA SECA, NO validamos horas de ordeña
        If General.CentrosUsuario.EsAreaSeca(cboCentros.SelectedIndex) = True Then
            ValidaHoraFinalizacionOrdeña = True
            Exit Function
        End If

        If HoraCorrecta(txtHoraTermino.Text) = False Then
            If MsgBox("LA HORA DE TERMINO DE ORDEÑA -- ES INCORRECTA --" + vbCrLf + "EJEMPLO: 07:00", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            Exit Function
        End If

        If rbtnAM.Checked = True And (Int32.Parse(Mid(txtHoraTermino.Text, 1, 2)) < 1 Or Int32.Parse(Mid(txtHoraTermino.Text, 1, 2)) > 12) Then
            If MsgBox("LA HORA DE TERMINO DE ORDEÑA -- ES INCORRECTA --, VERIFIQUE SEGUN LA HORA -- AM --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            Exit Function
        End If

        If rbtnPM.Checked = True And (Int32.Parse(Mid(txtHoraTermino.Text, 1, 2)) < 12 Or Int32.Parse(Mid(txtHoraTermino.Text, 1, 2)) > 24) Then
            If MsgBox("LA HORA DE TERMINO DE ORDEÑA -- ES INCORRECTA --, VERIFIQUE SEGUN LA HORA -- PM --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            Exit Function
        End If

        ValidaHoraFinalizacionOrdeña = True
    End Function


    Private Function ValidaHoraTomaTemperaturas() As Boolean
        ValidaHoraTomaTemperaturas = False

        'si la sala que estamos ingresando, ES AREA SECA, NO validamos horas de ordeña
        If General.CentrosUsuario.EsAreaSeca(cboCentros.SelectedIndex) = True Then
            ValidaHoraTomaTemperaturas = True
            Exit Function
        End If

        If HoraCorrecta(txtTempHora.Text) = False Then
            If MsgBox("LA HORA DE TOMA DE TEMPERATURA -- ES INCORRECTA --" + vbCrLf + "EJEMPLO: 07:00", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            Exit Function
        End If

        If rbtnAM.Checked = True And (Int32.Parse(Mid(txtTempHora.Text, 1, 2)) < 1 Or Int32.Parse(Mid(txtTempHora.Text, 1, 2)) > 12) Then
            If MsgBox("LA HORA DE TOMA DE TEMPERATURA -- ES INCORRECTA --, VERIFIQUE SEGUN LA HORA -- AM --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            Exit Function
        End If

        If rbtnPM.Checked = True And (Int32.Parse(Mid(txtTempHora.Text, 1, 2)) < 12 Or Int32.Parse(Mid(txtTempHora.Text, 1, 2)) > 24) Then
            If MsgBox("LA HORA DE TOMA DE TEMPERATURA -- ES INCORRECTA --, VERIFIQUE SEGUN LA HORA -- PM --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            Exit Function
        End If

        ValidaHoraTomaTemperaturas = True
    End Function


    Private Function ValidaLeche() As Boolean
        ValidaLeche = False

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        If (LitrosPlanta.Text <> "0" And VacasPlanta.Text = "0") Or (LitrosPlanta.Text = "0" And VacasPlanta.Text <> "0") Then
            MsgBox(("El ingreso de -- litros planta -- no es concistente").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            If LitrosPlanta.Text = "0" Then LitrosPlanta.Focus()
            If VacasPlanta.Text = "0" Then VacasPlanta.Focus()
            Exit Function
        End If


        If (LitrosTerneros.Text <> "0" And VacasTerneros.Text = "0") Or (LitrosTerneros.Text = "0" And VacasTerneros.Text <> "0") Then
            MsgBox(("El ingreso de -- litros terneros -- no es concistente").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            If LitrosTerneros.Text = "0" Then LitrosTerneros.Focus()
            If VacasTerneros.Text = "0" Then VacasTerneros.Focus()
            Exit Function
        End If

        If (LitrosCalostro.Text <> "0" And VacasCalostro.Text = "0") Or (LitrosCalostro.Text = "0" And VacasCalostro.Text <> "0") Then
            MsgBox(("El ingreso de -- litros calostro -- no es concistente").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            If LitrosCalostro.Text = "0" Then LitrosCalostro.Focus()
            If VacasCalostro.Text = "0" Then VacasCalostro.Focus()
            Exit Function
        End If

        If (LitrosAntibioticos.Text <> "0" And VacasAntibioticos.Text = "0") Or (LitrosAntibioticos.Text = "0" And VacasAntibioticos.Text <> "0") Then
            MsgBox(("El ingreso de -- litros antibioticos -- no es concistente").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            If LitrosAntibioticos.Text = "0" Then LitrosAntibioticos.Focus()
            If VacasAntibioticos.Text = "0" Then VacasAntibioticos.Focus()
            Exit Function
        End If

        If (LitrosMala.Text <> "0" And VacasMalas.Text = "0") Or (LitrosMala.Text = "0" And VacasMalas.Text <> "0") Then
            MsgBox(("El ingreso de -- litros descarte -- no es concistente").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            If LitrosMala.Text = "0" Then LitrosMala.Focus()
            If VacasMalas.Text = "0" Then VacasMalas.Focus()
            Exit Function
        End If


        'validamos totales de ingreso leche
        If (lbTotLitros.Text = "0" Or LbTotVacas.Text = "0") Then
            MsgBox(("Debe ingresar la información de -- producción diaria --").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Function
        End If


        If Int32.Parse(lbTotLitros.Text.Replace(".", "")) <= Int32.Parse(LbTotVacas.Text.Replace(".", "")) Then
            MsgBox(("Los litros de leche -- no pueden ser menor -- al nro de vacas").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Function
        End If

        If TxtTempEst1.Text = "" Or TxtTempEst1.Text = "0" Then
            MsgBox(("Debe ingresar la -- temperatura -- del estanque nro 1").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            TxtTempEst1.Focus()
            Exit Function
        End If

        If NroEstanques > 1 Then
            If TxtTempEst2.Text = "" Or TxtTempEst2.Text = "0" Then
                MsgBox(("Debe ingresar la -- temperatura -- del estanque nro 2").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                TxtTempEst2.Focus()
                Exit Function
            End If
        Else
            If TxtTempEst2.Text = "" Then
                TxtTempEst2.Text = "0"
                'Exit Function
            End If
        End If
        

        If General.CentrosUsuario.EsSharedMilker(cboCentros.SelectedIndex) = False And cboCentros.Text <> "LAURELES" Then
            If TxtDosis.Text.Trim = "" Or TxtDosis.Text.Trim = "0" Then
                MsgBox(("Debe ingresar una -- dosis de concentrado --").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                TxtDosis.Focus()
                Exit Function
            End If
        End If


        'validamos confirmacion estado ganado
        If rbtnConforme.Checked = False And rbtnNoConforme.Checked = False Then
            MsgBox(("Debe ingresar la -- conformidad -- del estado de ganado").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Function
        End If

        If rbtnNoConforme.Checked = True And txtObservsEstado.Text.Trim = "" Then
            MsgBox(("Debe ingresar una -- observación -- para un estado no conforme").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            txtObservsEstado.Focus()
            Exit Function
        End If


        ValidaLeche = True
    End Function


    Private Function ValidaAsistencia() As Boolean
        ValidaAsistencia = False

        If dgvAsistencia.Rows.Count = 0 Then
            If MsgBox("NO EXISTEN REGISTROS DE ASISTENCIA", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            Exit Function
        End If

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        Dim i As Integer

        For i = 0 To dgvAsistencia.Rows.Count - 1
            If dgvAsistencia.Rows(i).Cells(2).Value = "" Then
                dgvAsistencia.Rows(i).Cells(2).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(3).Value Is DBNull.Value Or dgvAsistencia.Rows(i).Cells(3).Value Is Nothing Then
                dgvAsistencia.Rows(i).Cells(3).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(4).Value Is DBNull.Value Or dgvAsistencia.Rows(i).Cells(4).Value Is Nothing Then
                dgvAsistencia.Rows(i).Cells(4).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(5).Value Is DBNull.Value Or dgvAsistencia.Rows(i).Cells(5).Value Is Nothing Then
                dgvAsistencia.Rows(i).Cells(5).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(6).Value Is DBNull.Value Or dgvAsistencia.Rows(i).Cells(6).Value Is Nothing Then
                dgvAsistencia.Rows(i).Cells(6).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(7).Value Is DBNull.Value Or dgvAsistencia.Rows(i).Cells(7).Value Is Nothing Then
                dgvAsistencia.Rows(i).Cells(7).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(3).Value.ToString = "" Then
                dgvAsistencia.Rows(i).Cells(3).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(4).Value.ToString = "" Then
                dgvAsistencia.Rows(i).Cells(4).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(5).Value.ToString = "" Then
                dgvAsistencia.Rows(i).Cells(5).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(6).Value.ToString = "" Then
                dgvAsistencia.Rows(i).Cells(6).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(7).Value.ToString = "" Then
                dgvAsistencia.Rows(i).Cells(7).Value = "0"
            End If

            If dgvAsistencia.Rows(i).Cells(8).Value.ToString = "" Then
                If MsgBox(("Seleccione Estado en el formulario Registro de asistencia").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

                Exit Function
                'Exit For
            End If


            If (dgvAsistencia.Rows(i).Cells(9).Value Is Nothing) Then
                dgvAsistencia.Rows(i).Cells(9).Value = "0"
            End If


            If (dgvAsistencia.Rows(i).Cells(2).Value.ToString <> "" And dgvAsistencia.Rows(i).Cells(2).Value.ToString <> "0") And _
                            (dgvAsistencia.Rows(i).Cells(9).Value.ToString = "" Or dgvAsistencia.Rows(i).Cells(9).Value.ToString = "0") Then
                If MsgBox(("Debe seleccionar el --- motivo de las horas extras ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

                Exit Function
                'Exit For
            End If


            If (dgvAsistencia.Rows(i).Cells(2).Value.ToString = "" Or dgvAsistencia.Rows(i).Cells(2).Value.ToString = "0") And _
                    (dgvAsistencia.Rows(i).Cells(9).Value.ToString <> "" And dgvAsistencia.Rows(i).Cells(9).Value.ToString <> "0") Then
                If MsgBox(("Si no hay horas extras, debe quitar el --- motivo ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

                Exit Function
                'Exit For
            End If

        Next

        ValidaAsistencia = True
    End Function


    Private Function ValidaRetiro() As Boolean
        ValidaRetiro = False

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If


        Dim listareal As Integer = 1
        Dim i As Integer
        Dim HayError As Boolean = False
        Dim hora As String
        Dim patente As String
        Dim guia As Integer
        Dim litros As Integer
        Dim temp As Double


        If dgvRetiroLeche.Rows.Count > 1 Then listareal = 2

        For i = 0 To dgvRetiroLeche.Rows.Count - listareal

            hora = ""
            patente = ""
            guia = 0
            litros = 0
            temp = 0


            If Not dgvRetiroLeche.Rows(i).Cells(2).Value Is Nothing Then hora = dgvRetiroLeche.Rows(i).Cells(2).Value.ToString.Trim
            If Not dgvRetiroLeche.Rows(i).Cells(3).Value Is Nothing Then patente = dgvRetiroLeche.Rows(i).Cells(3).Value.ToString.Trim
            If Not dgvRetiroLeche.Rows(i).Cells(4).Value Is Nothing Then If dgvRetiroLeche.Rows(i).Cells(4).Value.ToString.Trim <> "" Then guia = Int32.Parse(dgvRetiroLeche.Rows(i).Cells(4).Value)
            If Not dgvRetiroLeche.Rows(i).Cells(5).Value Is Nothing Then If dgvRetiroLeche.Rows(i).Cells(5).Value.ToString.Trim <> "" Then litros = Int32.Parse(dgvRetiroLeche.Rows(i).Cells(5).Value)
            If Not dgvRetiroLeche.Rows(i).Cells(6).Value Is Nothing Then If dgvRetiroLeche.Rows(i).Cells(6).Value.ToString.Trim <> "" Then temp = Double.Parse(dgvRetiroLeche.Rows(i).Cells(6).Value)

            If hora = "" Or ValidaHora(dgvRetiroLeche.Rows(i).Cells(2).Value, i) = False Then

                dgvRetiroLeche.Rows(i).Cells(2).Style.BackColor = Color.LightGreen
                If MsgBox(("Formato de Hora incorrecto").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If patente = "" Then

                dgvRetiroLeche.Rows(i).Cells(3).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe Ingresar la --- Patente ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If guia = 0 Then

                dgvRetiroLeche.Rows(i).Cells(4).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe ingresar el --- nro° de guía ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If litros = 0 Then

                dgvRetiroLeche.Rows(i).Cells(5).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe ingresar los --- Litros ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If temp = 0 Then

                dgvRetiroLeche.Rows(i).Cells(6).Style.BackColor = Color.LightGreen
                If MsgBox("Debe Ingresar la --- Temperatura ---", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

        Next

        If HayError Then
            tmrColores.Enabled = True
            Exit Function
        End If

        ValidaRetiro = True
    End Function


    Private Sub validar_Keypress_entrega(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna   
        Dim columna As Integer = dgvRetiroLeche.CurrentCell.ColumnIndex
        ' MsgBox(columna)
        ' comprobar si la celda en edición corresponde a la columna 1 o 2   
        If columna = 1 Or columna = 2 Or columna = 3 Or columna = 4 Then

            ' Obtener caracter   
            Dim caracter As Char = e.KeyChar
            ' comprobar si el caracter es un número o el retroceso   
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar   
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub



    Private Sub TxtDosis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDosis.Click
        TxtDosis.SelectAll()
    End Sub


    Private Sub TxtDosis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDosis.KeyPress
        'valida_tecla(e.KeyChar)
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGrabar.Focus()
            Exit Sub
        End If

        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If

    End Sub


    Private Sub TxtDosis_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDosis.LostFocus
        CalculaDosisConcentrado()
    End Sub


    Private Sub CalculaDosisConcentrado()
        If TxtDosis.Text = "" Or TxtDosis.Text = "0" Then
            TxtDosis.Text = "0"
            TxtTotConcentrado.Text = "0"
        Else
            If Double.Parse(TxtDosis.Text) <= 10 Then
                Dim totcon As Double = Double.Parse(TxtDosis.Text) * Int32.Parse(LbTotVacas.Text.Replace(".", ""))

                TxtTotConcentrado.Text = Format(totcon, "#,##0.00")
                LbTotal.Text = "Tot.Concentrado"
                'TxtTotConcentrado.Visible = True
                LbTotal.Visible = True
            End If

            If Double.Parse(TxtDosis.Text) > 10 And Double.Parse(TxtDosis.Text) < 25 Then
                MsgBox("El valor ingresado no es valido")
                TxtDosis.Text = ""
                TxtDosis.Focus()
                Exit Sub
            End If

            If Double.Parse(TxtDosis.Text) >= 25 Then
                If Int32.Parse(LbTotVacas.Text.Replace(".", "")) <= 0 Then
                    MsgBox("El total de Vacas no debe ser Cero")
                    TxtDosis.Text = ""
                    TxtDosis.Focus()
                Else
                    Dim totcon As Double = Double.Parse(TxtDosis.Text) / Int32.Parse(LbTotVacas.Text.Replace(".", ""))
                    'TxtTotConcentrado.Text = TxtDosis.Text / LbTotVacas.Text
                    TxtTotConcentrado.Text = Format(totcon, "#,##0.00")
                    LbTotal.Text = "Kg x Vaca"
                    'TxtTotConcentrado.Visible = True
                    LbTotal.Visible = True
                End If
            End If
        End If
    End Sub


    Private Sub InicializaVariablesCombos()
        SelectRowCellEstado = -1
        SelectColCellEstado = -1
        SelectRowCellMotivoHE = -1
        SelectColCellMotivoHE = -1
    End Sub

    Private Sub Asistencia_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsistencia.CellClick
        Dim columna As Integer = dgvAsistencia.CurrentCell.ColumnIndex
        Dim linea As Integer = dgvAsistencia.CurrentCell.RowIndex
        'MsgBox(columna)


        ''CON ESTO HACEMOS QUE AL HACER UN CLICK EN EL COMBO BOX, MOSTRAMOS LA LISTA
        If columna = 8 Then
            If linea <> SelectRowCellEstado Or columna <> SelectColCellEstado Then
                dgvAsistencia.BeginEdit(True)
                SendKeys.Send("{F4}")
                SelectRowCellEstado = linea
                SelectColCellEstado = columna
            End If
        End If

        If columna = 9 Then
            If linea <> SelectRowCellMotivoHE Or columna <> SelectColCellMotivoHE Then
                dgvAsistencia.BeginEdit(True)
                SendKeys.Send("{F4}")
                SelectRowCellMotivoHE = linea
                SelectColCellMotivoHE = columna
            End If
        End If
    End Sub


    Private Sub Asistencia_EditingControlShowing(ByVal sender As Object, ByVal ea As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvAsistencia.EditingControlShowing
        ''referencia a la celda   
        Dim col As Integer = dgvAsistencia.CurrentCell.ColumnIndex

        '' MsgBox("")

        'valida keypress horas extras
        If col = 2 Or col = 3 Or col = 4 Or col = 5 Or col = 6 Or col = 7 Then
            Dim validarn As TextBox = CType(ea.Control, TextBox)
            AddHandler validarn.KeyPress, AddressOf validar_text
        End If

        'valida selectindex combobox nomenclaturas
        If col = 8 Then
            Dim editingComboBox As ComboBox = ea.Control
            AddHandler editingComboBox.SelectedIndexChanged, AddressOf CambiaOpcionComboAsistencia
        End If
    End Sub



    Private Sub validar_text(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvAsistencia.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna 1 o 2   
        If columna = 2 Or columna = 3 Or columna = 4 Or columna = 5 Or columna = 6 Or columna = 7 Then

            ' Obtener caracter   
            Dim caracter As Char = e.KeyChar

            If columna = 2 Then
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
                    e.KeyChar = Chr(0)

                End If
            Else
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    e.KeyChar = Chr(0)

                End If
            End If
        End If
    End Sub


    Private Sub CambiaOpcionComboAsistencia(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim col As Integer = dgvAsistencia.CurrentCell.ColumnIndex

        If col <> 8 Then Exit Sub

        Dim cbCell As ComboBox = CType(sender, ComboBox)

        Dim txtCell As DataGridViewTextBoxCell = Me.dgvAsistencia.CurrentRow.Cells(2)

        If Not cbCell.Text.Contains("Trabajado") Then

            txtCell.Value = "0"
            txtCell.ReadOnly = True
        Else

            txtCell.ReadOnly = False
        End If

    End Sub


    Private Sub btnTraslados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraslados.Click
        If cboCentros.SelectedIndex = -1 Then Exit Sub

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        frmFuncionarios.Param1_Centro = cent_
        frmFuncionarios.Param2_Fecha = dtpFecha.Value
        frmFuncionarios.Param3_Horario = IIf(rbtnAM.Checked = True, 1, 2)
        frmFuncionarios.MdiParent = frmMAIN
        frmFuncionarios.Show()
        frmFuncionarios.BringToFront()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Cursor.Current = Cursors.WaitCursor
        'Turnos.Show()

        If Not File.Exists("\\srvweb\Control de Documentos\Registros\Administracion\RRHH\turnos_nuevos.pdf") Then
            If MsgBox("EL ARCHIVO DE TURNOS (turnos_nuevos.pdf) NO EXISTE", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE RED") <> MsgBoxResult.Ok Then
            End If
            Exit Sub
        End If

        Try
            Process.Start("\\srvweb\Control de Documentos\Registros\Administracion\RRHH\turnos_nuevos.pdf")
        Catch ex As Exception
            If MsgBox("ERROR AL ABRIR ARCHIVO PDF, VERIFIQUE QUE EXISTA EL PROGRAMA --- ACROBAT READER ---", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE RED") <> MsgBoxResult.Ok Then
            End If
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub DgEntregaLeche_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs)
        ' MsgBox("")
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress   
        AddHandler validar.KeyPress, AddressOf validar_Keypress_entrega
    End Sub


    Private Sub DgEntregaLeche_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If dgvRetiroLeche.Rows.Count >= 3 Then
            dgvRetiroLeche.AllowUserToAddRows = False
        End If
    End Sub


    Private Sub BuscarIngresoLeche(ByVal Horario As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_BuscarIngresoLeche", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(Horario = "AM", 1, 2))

        con.Open()
        rdr = cmd.ExecuteReader()

        'siempre existe un registro, que devuleve los litros totales diarios, la temperatura...
        'y antes del resultado limpiamos todo la pestaña de ingreso de leche
        LimpiaGrillaLecheEnc()

        While rdr.Read()
            TotalLecheDia = rdr("TotalLitrosLeche").ToString.Trim
            TotalVacasDia = rdr("TotalVacas").ToString.Trim
            TotalLechePlanta = rdr("TotalLitrosPlanta").ToString.Trim
            TotalVacasPlanta = rdr("TotalVacasPlanta").ToString.Trim
            NroOrdenias = rdr("ContOrdenias").ToString.Trim
            Exit While
        End While

        If TotalLecheDia > 0 Then lblTotLEcheDia.Text = Format(TotalLecheDia, "#,#") '+ " Lts."
        If TotalLechePlanta > 0 Then lblTotLEchePlanta.Text = Format(TotalLechePlanta, "#,#") '+ " Lts."

        Dim pvacas_dia_ As Double = TotalVacasDia
        Dim pvacas_planta_ As Double = TotalVacasPlanta

        If NroOrdenias > 1 Then
            pvacas_dia_ = (TotalVacasDia / NroOrdenias)
            pvacas_planta_ = (TotalVacasPlanta / NroOrdenias)
        End If

        If pvacas_dia_ > 0 Then lblLtsXVacaDia.Text = Format(Math.Round(TotalLecheDia / pvacas_dia_, 6), "#,#.00")
        If pvacas_planta_ > 0 Then lblLtsXVacaPlanta.Text = Format(Math.Round(TotalLechePlanta / pvacas_planta_, 6), "#,#.00")

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub


    Private Sub BuscarIngresoLecheDetalle(ByVal Horario As String)
        ExisteIngresoLeche = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_BuscarIngresoLecheDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(Me.cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(Horario = "AM", 1, 2))

        ''ORDEN DESDE LA BB (haci garantizamos que primero venga los tipos de AM y despues los tipos de PM)
        ''order by IdTipoLeche

        con.Open()
        rdr = cmd.ExecuteReader()

        'antes del resultado limpiamos
        LimpiaGrillaLeche()

        If rdr.HasRows = False Then
            rdr.Close()
            cmd.Dispose()
            con.Close()
            Exit Sub
        End If

        Dim i As Integer = 0
        Dim litros As String()
        Dim vacas As String()
        Dim totlitros, totvacas As Integer
        ReDim Preserve litros(i)
        ReDim Preserve vacas(i)
        Dim Temperatura As Integer
        Dim Temperatura2 As Integer
        Dim UsuarioReg As String = ""
        Dim FechaReg As String = ""
        Dim h1 As String = ""
        Dim h2 As String = ""

        While rdr.Read()
            Temperatura = rdr("Temperatura").ToString.Trim
            Temperatura2 = rdr("Temperatura2").ToString.Trim
            h1 = rdr("HoraTermino").ToString.Trim
            h2 = rdr("HoraTemperatura").ToString.Trim
            ''
            UsuarioReg = rdr("LDetUsuario").ToString.Trim
            FechaReg = Format(rdr("LDetFechaReg"), "dd-MM-yyyy  HH:mm")

            ReDim Preserve litros(i)
            ReDim Preserve vacas(i)

            litros(i) = rdr("LDetLitrosLeche").ToString.Trim
            vacas(i) = rdr("LDetNumVacas").ToString.Trim

            totlitros = totlitros + litros(i)
            totvacas = totvacas + vacas(i)

            i += 1
        End While

        If litros.Count > 2 Then
            LitrosPlanta.Text = litros(0)
            VacasPlanta.Text = vacas(0)
            LitrosTerneros.Text = litros(1)
            VacasTerneros.Text = vacas(1)
            LitrosCalostro.Text = litros(2)
            VacasCalostro.Text = vacas(2)
            LitrosAntibioticos.Text = litros(3)
            VacasAntibioticos.Text = vacas(3)
            LitrosMala.Text = litros(4)
            VacasMalas.Text = vacas(4)
        End If

        lblUsuarioReg.Text = UsuarioReg
        lblFechaReg.Text = FechaReg

        txtHoraTermino.Text = h1
        TxtTempEst1.Text = Temperatura
        TxtTempEst2.Text = Temperatura2
        txtTempHora.Text = h2
        lbTotLitros.Text = FormatNumber(totlitros, 0)
        LbTotVacas.Text = FormatNumber(totvacas, 0)
        LbTotLtVacas.Text = Math.Round(Int32.Parse(totlitros) / Int32.Parse(totvacas), 1)

        ExisteIngresoLeche = True

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub


    Private Function BuscarConcentrado(ByVal Horario As String)
        BuscarConcentrado = False
        'ExisteIngresoLeche = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_BuscarConcentrado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(Me.cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(Horario = "AM", 1, 2))

        ''ORDEN DESDE LA BB (haci garantizamos que primero venga los tipos de AM y despues los tipos de PM)
        ''order by IdTipoLeche

        con.Open()
        rdr = cmd.ExecuteReader()

        'antes del resultado limpiamos y calculamos (para reiniciar totales)
        LimpiaConcentrado()
        CalculaDosisConcentrado()

        If rdr.HasRows = False Then
            rdr.Close()
            cmd.Dispose()
            con.Close()
            Exit Function
        End If

        rdr.Read()
        TxtDosis.Text = rdr("LConCantDosis").ToString.Trim

        CalculaDosisConcentrado()

        BuscarConcentrado = True

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Function


    Private Sub NuevoEstadoGanado()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanadoEstado_BuscarActual", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(Me.cboCentros.SelectedIndex))

        con.Open()
        rdr = cmd.ExecuteReader()

        Dim i As Integer
        Dim cat As String
        Dim tot As Integer

        For i = 0 To lvESTADOGANADO.Columns.Count - 2
            lvESTADOGANADO.Items(0).SubItems(i).Text = "0"
        Next

        rbtnConforme.Checked = False
        rbtnNoConforme.Checked = False
        txtObservsEstado.Text = ""

        While rdr.Read()
            cat = rdr("CategoNom").ToString

            For i = 0 To lvESTADOGANADO.Columns.Count - 2
                If lvESTADOGANADO.Columns(i).Text.ToUpper = cat Then

                    lvESTADOGANADO.Items(0).SubItems(i).Text = rdr("Cont").ToString

                End If
            Next
        End While

        For i = 0 To lvESTADOGANADO.Columns.Count - 2
            tot = tot + Int32.Parse(lvESTADOGANADO.Items(0).SubItems(i).Text)
        Next

        lvESTADOGANADO.Items(0).SubItems((lvESTADOGANADO.Columns.Count - 1)).Text = tot.ToString.Trim

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub


    Private Sub BuscarEstadoGanado(ByVal Horario As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanadoEstado_Buscar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(Me.cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(Horario = "AM", 1, 2))

        con.Open()
        rdr = cmd.ExecuteReader()

        Dim i As Integer
        Dim cat As String
        Dim tot As Integer

        For i = 0 To lvESTADOGANADO.Columns.Count - 2
            lvESTADOGANADO.Items(0).SubItems(i).Text = "0"
        Next

        rbtnConforme.Checked = False
        rbtnNoConforme.Checked = False
        txtObservsEstado.Text = ""

        While rdr.Read()
            cat = rdr("CategoNom").ToString

            If rdr("EGndConforme") = 1 Then
                rbtnConforme.Checked = True
            Else
                rbtnNoConforme.Checked = True
            End If

            txtObservsEstado.Text = rdr("EGndObservs").ToString

            For i = 0 To lvESTADOGANADO.Columns.Count - 2
                If lvESTADOGANADO.Columns(i).Text.ToUpper = cat Then

                    lvESTADOGANADO.Items(0).SubItems(i).Text = rdr("EGDetTotalNum").ToString

                End If
            Next
        End While

        For i = 0 To lvESTADOGANADO.Columns.Count - 2
            tot = tot + Int32.Parse(lvESTADOGANADO.Items(0).SubItems(i).Text)
        Next

        lvESTADOGANADO.Items(0).SubItems((lvESTADOGANADO.Columns.Count - 1)).Text = tot.ToString.Trim

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub


    Public Sub BuscarAsistenciaFuncionarios(ByVal Horario As String)
        ExisteIngresoAsistencia = False

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spAsistencia_BuscarFuncionarios", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(Me.cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(Horario = "AM", 1, 2))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        con.Open()
        rdr = cmd.ExecuteReader()

        Dim tasis As String
        Dim motivo As String
        Dim i As Integer = 0
        Dim hrs As Double = 0
        Dim tothrs As Double = 0

        dgvAsistencia.Rows.Clear()
        lblNroFuncs.Text = "0"
        lblTotHrsExtras.Text = "0"

        SeleccionaNomenclatura = False

        While rdr.Read()
            ReDim Preserve NombreNomenclatura(i)
            ReDim Preserve NombreMotivoHE(i)
            tasis = ""
            motivo = ""
            hrs = 0

            If Not IsDBNull(rdr("ANomNombre")) Then tasis = rdr("ANomNombre")
            If Not IsDBNull(rdr("MHExNombre")) Then motivo = rdr("MHExNombre")

            If Not IsDBNull(rdr("AsisHHEE")) Then hrs = rdr("AsisHHEE")


            NombreNomenclatura(i) = tasis
            NombreMotivoHE(i) = motivo

            dgvAsistencia.Rows.Add(rdr("Rut"), rdr("Nombre"), hrs.ToString.Trim, rdr("AsisBonoLenia"), rdr("AsisBonoPodal"), rdr("AsisBonoColacion"), rdr("AsisBonoResponsabilidad"), rdr("AsisBonoOtros"))

            If ExisteIngresoAsistencia = False And Not IsDBNull(rdr("ANomNombre")) Then
                ExisteIngresoAsistencia = True
            End If

            If ExisteIngresoAsistencia = False Then
                dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(8).Value = "1"
                dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(9).Value = "0"
                dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(2).ReadOnly = False
            Else
                dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(8).Value = rdr("AsisNomenclatura").ToString.Trim
                dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(9).Value = rdr("AsisMotivoHE").ToString.Trim
                dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(2).ReadOnly = True
            End If

            tothrs = tothrs + hrs
            i = i + 1
        End While

        SeleccionaNomenclatura = ExisteIngresoAsistencia 'True

        lblNroFuncs.Text = i.ToString.Trim
        lblTotHrsExtras.Text = tothrs.ToString.Trim

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub


    Private Sub BuscarRetiroLeche()
        ExisteIngresoRetiro = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_BuscarRetiros", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(Me.cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        con.Open()
        rdr = cmd.ExecuteReader()

        Dim i As Integer
        Dim totlitrosdia, totlitrosmes As Double
        Dim palcohol As Integer
        Dim verde, amarillo, rojo As Integer

        dgvRetiroLeche.Rows.Clear()

        While rdr.Read()
            palcohol = 0
            verde = 0
            amarillo = 0
            rojo = 0

            If Not IsDBNull(rdr("LRetPruebaOX")) Then palcohol = IIf(rdr("LRetPruebaOX") = 0, 0, 1)
            If Not IsDBNull(rdr("LRetVerde")) Then verde = IIf(rdr("LRetVerde") = 0, 0, 1)
            If Not IsDBNull(rdr("LRetAmarillo")) Then amarillo = IIf(rdr("LRetAmarillo") = 0, 0, 1)
            If Not IsDBNull(rdr("LRetRojo")) Then rojo = IIf(rdr("LRetRojo") = 0, 0, 1)

            dgvRetiroLeche.Rows.Add(rdr("LRetTransporte"), _
                                   rdr("LRetNroGuia"), _
                                   rdr("LRetHora"), _
                                   rdr("LRetTransporte"), _
                                   rdr("LRetNroGuia"), _
                                   rdr("LRetLitros"), _
                                   rdr("LRetTemperatura"), _
                                   palcohol, _
                                   verde, _
                                   amarillo, _
                                   rojo, _
                                   rdr("LRetObservs"))

            dgvRetiroLeche.Rows(dgvRetiroLeche.Rows.Count - 2).Cells(7).Value = IIf(palcohol = 1, True, False)
            dgvRetiroLeche.Rows(dgvRetiroLeche.Rows.Count - 2).Cells(8).Value = IIf(verde = 1, True, False)
            dgvRetiroLeche.Rows(dgvRetiroLeche.Rows.Count - 2).Cells(9).Value = IIf(amarillo = 1, True, False)
            dgvRetiroLeche.Rows(dgvRetiroLeche.Rows.Count - 2).Cells(10).Value = IIf(rojo = 1, True, False)

            ExisteIngresoRetiro = True
            totlitrosdia = totlitrosdia + rdr("LRetLitros")
            totlitrosmes = rdr("TotLitrosRetMes")

            i = i + 1
        End While

        lblNroRetiros.Text = i.ToString.Trim
        lblTotLtsRetiradosDia.Text = Format(totlitrosdia, "#,#0")
        lblTotLtsRetiradosMes.Text = Format(totlitrosmes, "#,#0")

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub


    Private Function BuscarCierreTemporada() As Boolean
        BuscarCierreTemporada = False

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spLeche_BuscarCierreTemporada", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
            cmd.Parameters.AddWithValue("@Fecha", Now)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            ''si entra al ciclo es porque existe un registro de cierre de temporada
            While rdr.Read()
                BuscarCierreTemporada = True
                Exit While
            End While

            rdr.Close()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function




    Private Sub Txttemp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTempEst1.KeyPress, TxtTempEst2.KeyPress
        'valida_tecla(e.KeyChar)
        Dim text As TextBox = DirectCast(sender, TextBox)

        If e.KeyChar = ChrW(Keys.Enter) Then
            If text.Name.Contains("TxtTempEst1") Then
                TxtTempEst2.Focus()
                Exit Sub
            Else
                txtTempHora.Focus()
                'TxtDosis.Focus()
                Exit Sub
            End If
        End If

        Dim caracter As Char = e.KeyChar

        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub


    'COMIENZO PROGRAMACION GRAFICOS
    Private centroCod As String = ""


    Private Sub Graficos()
        Cursor.Current = Cursors.WaitCursor

        CentroCodigo()

        'leyendas de los grafico leche
        ChartLeche.Series("Series1").LegendText = "PLANTA"
        ChartLeche.Series("Series2").LegendText = "PROYECTADO"

        'leyendas grafico concentrado
        ChartConcentrado.Series("Series1").LegendText = "REAL (LECHE)"


        'grafico leche
        ConsultaGraficoLeche(centroCod, "VTA_PPTO_MENSUAL", "VTA")
        ConsultaGraficoLeche(centroCod, "VTA_PPTO_MENSUAL", "PPTO")

        'grafico concentrado
        ConsultaGraficoConcentrado(centroCod)

        'grafico horas extras
        ConsultaGraficoHorasExtras(centroCod, dtpFecha.Value.Year, 1)
        ConsultaGraficoHorasExtras(centroCod, dtpFecha.Value.Year - 1, 2)

        Cursor.Current = Cursors.Default
    End Sub


    'GRAFICO LECHE PLANTA DIARIA VS PROYECTADO
    Private Sub ConsultaGraficoLeche(ByVal centro_ As String, ByVal TipoGrafico As String, ByVal Serie As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_Graficos", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", DateTime.Parse(Format(dtpFecha.Value, "dd-MM-yyyy")))
        cmd.Parameters.AddWithValue("@TipoGrafico", TipoGrafico)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()

            If Serie = "VTA" Then
                ChartLeche.Series("Series1").Points.DataBindXY(rdrGraphic, "MesNom", rdrGraphic, "Venta")
            End If

            If Serie = "PPTO" Then
                ChartLeche.Series("Series2").Points.DataBindXY(rdrGraphic, "MesNom", rdrGraphic, "Ppto")

            End If

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    'GRAFICO CONSUMO CONCENTRADO
    Private Sub ConsultaGraficoConcentrado(ByVal centro_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_GraficosConcentrado", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Fecha", DateTime.Parse(Format(dtpFecha.Value, "dd-MM-yyyy")))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()

            ChartConcentrado.Series("Series1").Points.DataBindXY(rdrGraphic, "MesNom", rdrGraphic, "TotalDosis")

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    'GRAFICO HORAS EXTRAS
    Private Sub ConsultaGraficoHorasExtras(ByVal centro_ As String, ByVal Anio As Integer, ByVal serie As Integer)
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spAsistencia_GraficoHHEE", con)
        Dim rdrGraphic As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Anio", Anio)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()

            chartHorasExtras.Series("Series" + serie.ToString).Points.DataBindXY(rdrGraphic, "MesNom", rdrGraphic, "SumaHHEE")

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub CentroCodigo()
        Dim pos_ As Integer = 0
        'Obtener el Codigo del Centro
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            For i = 0 To General.CentrosUsuario.NroRegistros - 1
                If General.CentrosUsuario.Nombre(i) = cboCentros.Text Then
                    pos_ = i
                End If
            Next
            centroCod = General.CentrosUsuario.Codigo(pos_)
        End If
    End Sub


    Private Sub btnAgregarMastitis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarMastitis.Click
        FrmMastitisIngreso.MdiParent = frmMAIN
        FrmMastitisIngreso.Show()
        FrmMastitisIngreso.BringToFront()

        FrmMastitisIngreso.cboCentros.Text = cboCentros.Text
    End Sub


    Private Sub btnCojeraMastitis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCojeraMastitis.Click
        FrmCojerasIngreso.MdiParent = frmMAIN
        FrmCojerasIngreso.Show()
        FrmCojerasIngreso.BringToFront()

        FrmCojerasIngreso.cboCentros.Text = cboCentros.Text
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim variable As String = "http://intranet/rrhh/rpt_asistencia.asp?cencod=" + General.Centros.Codigo(Me.cboCentros.SelectedIndex)
        Process.Start("iexplore", variable)
    End Sub


    Private Sub rbtnAM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAM.CheckedChanged
        If EnEventoLoad Then Exit Sub

        Dim fAM As Font = New Font(rbtnAM.Font, FontStyle.Bold)
        Dim fPM As Font = New Font(rbtnAM.Font, FontStyle.Regular)


        Cursor.Current = Cursors.WaitCursor

        lblUsuarioReg.Text = ""
        lblFechaReg.Text = ""

        BuscarIngresoLecheDetalle("AM")
        BuscarConcentrado("AM")

        If ExisteIngresoLeche = True Then
            BuscarEstadoGanado("AM")
        Else
            NuevoEstadoGanado()
        End If

        BuscarAsistenciaFuncionarios("AM")

        Cursor.Current = Cursors.Default

        ValidaBotonGrabar()

        rbtnAM.Font = fAM
        rbtnPM.Font = fPM
    End Sub


    Private Sub rbtnPM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnPM.CheckedChanged
        If EnEventoLoad Then Exit Sub

        Dim fPM As Font = New Font(rbtnAM.Font, FontStyle.Bold)
        Dim fAM As Font = New Font(rbtnAM.Font, FontStyle.Regular)


        Cursor.Current = Cursors.WaitCursor

        lblUsuarioReg.Text = ""
        lblFechaReg.Text = ""

        BuscarIngresoLecheDetalle("PM")
        BuscarConcentrado("PM")

        If ExisteIngresoLeche = True Then
            BuscarEstadoGanado("PM")
        Else
            NuevoEstadoGanado()
        End If

        BuscarAsistenciaFuncionarios("PM")

        Cursor.Current = Cursors.Default

        ValidaBotonGrabar()

        rbtnAM.Font = fAM
        rbtnPM.Font = fPM
    End Sub


    Private Sub LimpiaConcentrado()
        TxtDosis.Text = "0"
    End Sub


    Private Sub LimpiaGrillaLecheEnc()
        lblTotLEcheDia.Text = "0"
        lblTotLEchePlanta.Text = "0"
        lblLtsXVacaDia.Text = "0"
        lblLtsXVacaPlanta.Text = "0"

        lblUsuarioReg.Text = ""
        lblFechaReg.Text = ""
    End Sub


    Private Sub LimpiaGrillaLeche()
        txtHoraTermino.Text = ""
        TxtTempEst1.Text = "0"
        TxtTempEst2.Text = "0"
        txtTempHora.Text = ""

        LitrosPlanta.Text = "0"
        LitrosTerneros.Text = "0"
        LitrosCalostro.Text = "0"
        LitrosAntibioticos.Text = "0"
        LitrosMala.Text = "0"

        VacasPlanta.Text = "0"
        VacasTerneros.Text = "0"
        VacasCalostro.Text = "0"
        VacasAntibioticos.Text = "0"
        VacasMalas.Text = "0"

        lbTotLitros.Text = "0"
        LbTotVacas.Text = "0"
        LbTotLtVacas.Text = "0"
    End Sub


    Private Sub tabIngresos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabIngresos.SelectedIndexChanged
        ValidaBotonGrabar()
    End Sub


    Private Sub ValidaBotonGrabar()
        If PerfilUsuario <> 6 Then
            Select Case tabIngresos.SelectedIndex
                Case 0
                    lblJornadaDia.Visible = False
                    rbtnAM.Visible = True
                    rbtnPM.Visible = True

                    If ExisteIngresoLeche Then
                        btnGrabar.Enabled = False
                        btnEliminar.Enabled = True
                    Else
                        btnGrabar.Enabled = True
                        btnEliminar.Enabled = False
                    End If

                Case 1
                    rbtnAM.Checked = True
                    lblJornadaDia.Text = "DIA"
                    lblJornadaDia.Visible = True
                    rbtnAM.Visible = False
                    rbtnPM.Visible = False

                    If ExisteIngresoAsistencia Then
                        btnGrabar.Enabled = False
                        btnEliminar.Enabled = True
                    Else
                        btnGrabar.Enabled = True
                        btnEliminar.Enabled = False
                    End If

                Case 2
                    rbtnAM.Checked = True
                    lblJornadaDia.Text = "DIA"
                    lblJornadaDia.Visible = True
                    rbtnAM.Visible = False
                    rbtnPM.Visible = False
                    btnGrabar.Enabled = True
                    btnEliminar.Enabled = True


            End Select
        Else
            If ExisteIngresoAsistencia Then
                btnGrabar.Enabled = False
                btnEliminar.Enabled = True
            Else
                btnGrabar.Enabled = True
                btnEliminar.Enabled = False
            End If
        End If
    End Sub


    Private Sub dgvRetiroLeche_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRetiroLeche.EditingControlShowing
        ''referencia a la celda   
        Dim col As Integer = dgvRetiroLeche.CurrentCell.ColumnIndex

        If col = 2 Or col = 3 Or col = 4 Or col = 5 Or col = 6 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtRetiro
        End If

    End Sub



    Private Sub ValidaTxtRetiro(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvRetiroLeche.CurrentCell.ColumnIndex

        If columna = 3 Then Exit Sub

        If columna = 2 Then
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ":") Then
                e.KeyChar = Chr(0)
            End If
        End If

        If columna = 4 Or columna = 5 Then
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            End If
        End If

        If columna = 6 Then
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub


    Private Function ValidaHora(ByVal text As String, ByVal i As Integer) As Boolean
        ValidaHora = False
        If text Is Nothing Then dgvRetiroLeche.Rows(i).Cells(2).Value = ""

        If text <> "" Then
            Try
                Dim hr As DateTime = DateTime.Parse(Format(Now, "dd-MM-yyyy") + " " + text)
                If text.Length = 5 Then ValidaHora = True
            Catch ex As Exception
            End Try
        End If
    End Function


    Private Sub tmrColores_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrColores.Tick
        tmrColores.Enabled = False

        Dim i, o As Integer

        For i = 0 To dgvRetiroLeche.Rows.Count - 1
            For o = 0 To dgvRetiroLeche.Columns.Count - 1
                dgvRetiroLeche.Rows(i).Cells(o).Style.BackColor = Color.White
            Next
        Next
    End Sub


    Private Sub dgvAsistencia_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsistencia.CellEnter

        Dim tothh As Double

        For i As Integer = 0 To dgvAsistencia.Rows.Count - 1
            If Not dgvAsistencia.Rows(i).Cells(2).Value Is Nothing Then
                If dgvAsistencia.Rows(i).Cells(2).Value <> "" Then
                    tothh = tothh + Double.Parse(dgvAsistencia.Rows(i).Cells(2).Value)
                End If
            End If
        Next

        lblTotHrsExtras.Text = tothh

        InicializaVariablesCombos()
    End Sub


    Private Sub dgvRetiroLeche_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiroLeche.CellEnter

        Dim totlts As Integer

        For i As Integer = 0 To dgvRetiroLeche.Rows.Count - 1
            If Not dgvRetiroLeche.Rows(i).Cells(5).Value Is Nothing Then
                If dgvRetiroLeche.Rows(i).Cells(5).Value.ToString <> "" Then
                    totlts = totlts + Int32.Parse(dgvRetiroLeche.Rows(i).Cells(5).Value)
                End If
            End If
        Next

        lblTotLtsRetiradosDia.Text = totlts

    End Sub


    Private Sub dgvRetiroLeche_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiroLeche.RowEnter
        lblNroRetiros.Text = (dgvRetiroLeche.Rows.Count - 1).ToString
    End Sub


    Private Sub btnVBTarja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVBTarja.Click

        With frmVBTarja

            .Param1_Centro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

            .ShowDialog()

        End With
    End Sub


    Private Sub dgvAsistencia_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsistencia.RowEnter
        InicializaVariablesCombos()
    End Sub


    Private Sub btnImprime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprime.Click
        Cursor.Current = Cursors.WaitCursor

        frptLechePlantaMes.Show()
        frptLechePlantaMes.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntarja.Click
        Cursor.Current = Cursors.WaitCursor

        Try
            frptTarjaElectronica.CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
            frptTarjaElectronica.FecHasta = Format(dtpFecha.Value, "dd-MM-yyyy")
            frptTarjaElectronica.Show()
            frptTarjaElectronica.BringToFront()
        Catch ex As Exception
            If MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR") <> MsgBoxResult.Ok Then
            End If
        End Try

        Cursor.Current = Cursors.Default
    End Sub





    Private Sub txtTempHora_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTempHora.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            TxtDosis.Focus()
            Exit Sub
        End If
    End Sub


    Private Sub txtHoraTermino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraTermino.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LitrosPlanta.Focus()
            Exit Sub
        End If
    End Sub



    Private Sub btnAdminVBTarja_Click(sender As System.Object, e As System.EventArgs) Handles btnAdminVBTarja.Click
        With frmAdminCierresTarja
            .Show()
            .cboCentros.Text = cboCentros.Text
        End With
    End Sub
End Class