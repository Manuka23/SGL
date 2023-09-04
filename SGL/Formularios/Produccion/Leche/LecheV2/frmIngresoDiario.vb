

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Threading


Public Class frmIngresoDiario
    Dim Bolo As String

    'Private fnGrabarIngresoDiario As New fnGrabarIngresoDiario
    Private GrabarOK As Integer = 0
    Private StockVacas As Integer = 0
    Private TotalLecheDia As Integer = 0
    Private TotalVacasDia As Integer = 0
    Private TotalLechePlanta As Integer = 0
    Private TotalVacasPlanta As Integer = 0
    Private NroOrdenias As Integer = 0

    Private EnEventoLoad As Boolean = True
    Private ExisteIngresoLeche As Boolean = False
    Private ExisteIngresoConcentrado As Boolean = False
    Private ExisteIngresoAsistencia As Boolean = False
    Private ExisteIngresoRetiro As Boolean = False
    Private ExisteIngresoRiego As Boolean = False

    Private NroEstanques As Integer
    Private GuardaUltHorarioQueryLeche As Integer

    Private SeleccionaNomenclatura As Boolean
    Private NombreNomenclatura() As String
    Private NombreMotivoHE() As String

    Private SelectRowCellEstado As Integer = -1
    Private SelectColCellEstado As Integer = -1
    Private SelectRowCellMotivoHE As Integer = -1
    Private SelectColCellMotivoHE As Integer = -1

    Private SelectRowCellCliente As Integer = -1
    Private SelectColCellCliente As Integer = -1
    Private GrillaConcentrado As DataGridView = dgvConcentrado

    Dim Cestados As New DataGridViewComboBoxColumn
    Dim dgCboClientes As New DataGridViewComboBoxColumn
    ''
    ''
    Private Const CONS_COL_CONCENTRADO = 0      'COLUMNAS GRILLA CONCENTRADO
    Private Const CONS_COL_STOCKACTUAL = 1
    Private Const CONS_COL_CANTIDAD = 2
    Private Const CONS_COL_NROVACAS = 3
    Private Const CONS_COL_CANTPORVACA = 4
    Private Const CONS_COL_PRODUCTO = 5
    ''
    Private Const ASIS_COL_RUT = 0              'COLUMNAS GRILLA ASISTENCIA
    Private Const ASIS_COL_NOMBRE = 1
    Private Const ASIS_COL_HHEE = 2
    Private Const ASIS_COL_BLEÑA = 3
    Private Const ASIS_COL_BPODAL = 4
    Private Const ASIS_COL_BCOLACION = 5
    Private Const ASIS_COL_BRESPONS = 6
    Private Const ASIS_COL_BOTROS = 7
    Private Const ASIS_COL_NOMENCLATURA = 8
    Private Const ASIS_COL_MOTIVOHHEE = 9
    ''
    Private Const RET_COL_PATENTE_KEY = 0       'COLUMNAS GRILLA RETIRO LECHE
    Private Const RET_COL_GUIA_KEY = 1
    Private Const RET_COL_HORA = 2
    Private Const RET_COL_PATENTE = 3
    Private Const RET_COL_GUIA = 4
    Private Const RET_COL_CLIENTENOM = 5
    Private Const RET_COL_LITROS = 6
    Private Const RET_COL_TEMP = 7
    Private Const RET_COL_PALCOHOL = 8
    Private Const RET_COL_VERDE = 9
    Private Const RET_COL_AMARILLO = 10
    Private Const RET_COL_ROJO = 11
    Private Const RET_COL_AZUL = 12
    Private Const RET_COL_OBSERVS = 13
    Private Const RET_COL_CHOFER = 14
    Private Const RET_COL_CLIENTECOD = 15
    ''
    Private Const RIEGO_COL_LINEA = 0
    Private Const RIEGO_COL_FECHA = 1
    Private Const RIEGO_COL_TIPORESPONSABLE = 2
    Private Const RIEGO_COL_NOMRESPONSABLE = 3
    Private Const RIEGO_COL_TIPORIEGO = 4
    Private Const RIEGO_COL_CANTIDAD = 5
    Private Const RIEGO_COL_NROPOTREROS = 6
    Private Const RIEGO_COL_SUPERFICIE = 7
    Private Const RIEGO_COL_RUT = 8
    Private Const RIEGO_COL_NOM = 9

    Private RetIDGP As String = ""

    Private CentroCod As Integer = 0
    Private CentroTipo As String = ""
    Private AfectoAsistencia As String = ""

#Region "Load"
    Private Sub FrmIngresoDiario_Load(sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.nomenclaturas.Cargar()
        General.MotivosHorasExtras.Cargar()
        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8

        dtpFecha.Value = Now
        rbtnAM.Checked = True
        NroEstanques = 0
        lblPendienteRecepcion.Text = ""

        GrillaConcentrado = dgvConcentrado

        RecepcionMaterialesPendientes(1)

        MSTRUsuarios.DSCboUsuarioCentros_FrmINS(False, cboCentros)
            cboCentros.Text = UsuarioCentroNomDefault
            CentroCod = UsuarioCentroCodDefault

            LlenaDataTablesAsistencia()
            ClienteDGVRetiroLeche()

            EnEventoLoad = False

            'por ultimo buscamos los datos de la pantalla
            TabuladorFormulario(EnEventoLoad)
            ToolTipText()

    End Sub

    Private opc As Integer = -1
    Private Sub TabuladorFormulario(ByVal frmLoad As Boolean)
        If frmLoad Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Dim tabIdx As Integer = tabFormulario.SelectedIndex
        opc = 0
        If tabFormulario.TabPages(tabIdx).Name.Contains("1") Then opc = 0
        If tabFormulario.TabPages(tabIdx).Name.Contains("2") Then opc = 1
        If tabFormulario.TabPages(tabIdx).Name.Contains("3") Then opc = 2
        If tabFormulario.TabPages(tabIdx).Name.Contains("4") Then opc = 3
        '
        Dim hr As String = IIf(rbtnAM.Checked = True, "AM", "PM")
        '
        InterfaceUser(opc)
        '
        Select Case opc
            Case 0 'Leche
                InicializaEstanques()
                BuscarIngresoLeche(hr) 'buscamos leche
                BuscarIngresoLecheDetalle(hr)
                BuscarConcentrado(hr) 'buscamos concentrado
                GraficosLeche()
                CalculaNroVacasSecas() 'calculamos nro vacas secas (vacas ordeñadas - vacas est. ganado)
                If ExisteIngresoConcentrado = False Then
                    ConsultaProductosConcentrado()     'buscamos productos
                End If
                If ExisteIngresoLeche Then 'And ExisteIngresoConcentrado Then  'Se omite esto ya que ahora pueden ingresar sin concentrado
                    btnGrabar.Enabled = False
                    btnEliminar.Enabled = True
                Else
                    If ExisteIngresoLeche = False And ExisteIngresoConcentrado = False Then
                        btnGrabar.Enabled = True
                        btnEliminar.Enabled = False
                    Else
                        btnGrabar.Enabled = True

                        If (PerfilUsuario = 5 Or PerfilUsuario = 11) And ExisteIngresoConcentrado Then
                            btnEliminar.Enabled = True
                        Else
                            btnEliminar.Enabled = False
                        End If
                    End If
                End If

                If ExisteIngresoConcentrado Then
                    For i As Integer = 0 To dgvConcentrado.Rows.Count - 1
                        dgvConcentrado.Rows(i).Cells(2).ReadOnly = True : dgvConcentrado.Columns(2).DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224)
                        dgvConcentrado.Rows(i).Cells(3).ReadOnly = True : dgvConcentrado.Columns(3).DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224)
                    Next
                    For i As Integer = 0 To dgvConcentrado2.Rows.Count - 1
                        dgvConcentrado2.Rows(i).Cells(2).ReadOnly = True : dgvConcentrado.Columns(2).DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224)
                        dgvConcentrado2.Rows(i).Cells(3).ReadOnly = True : dgvConcentrado.Columns(3).DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224)
                    Next
                Else
                    For i As Integer = 0 To dgvConcentrado.Rows.Count - 1
                        dgvConcentrado.Rows(i).Cells(2).ReadOnly = False : dgvConcentrado.Columns(2).DefaultCellStyle.BackColor = Color.White
                        dgvConcentrado.Rows(i).Cells(3).ReadOnly = False : dgvConcentrado.Columns(3).DefaultCellStyle.BackColor = Color.White
                    Next
                    For i As Integer = 0 To dgvConcentrado2.Rows.Count - 1
                        dgvConcentrado2.Rows(i).Cells(2).ReadOnly = False : dgvConcentrado.Columns(2).DefaultCellStyle.BackColor = Color.White
                        dgvConcentrado2.Rows(i).Cells(3).ReadOnly = False : dgvConcentrado.Columns(3).DefaultCellStyle.BackColor = Color.White
                    Next
                End If
            Case 1 'Asistencia
                BuscarAsistenciaFuncionarios(hr)
                GraficosAsistencia()

                If ExisteIngresoAsistencia Then
                    btnGrabar.Enabled = False
                    btnEliminar.Enabled = True
                Else
                    btnGrabar.Enabled = True
                    btnEliminar.Enabled = False
                End If
                If dtpFecha.Value.Day = 14 Or dtpFecha.Value.Day = 15 Then
                    dgvAsistencia.Columns(ASIS_COL_BLEÑA).Visible = True
                    dgvAsistencia.Columns(ASIS_COL_BPODAL).Visible = True
                    dgvAsistencia.Columns(ASIS_COL_BCOLACION).Visible = True
                    dgvAsistencia.Columns(ASIS_COL_BRESPONS).Visible = True
                    dgvAsistencia.Columns(ASIS_COL_BOTROS).Visible = True
                Else
                    dgvAsistencia.Columns(ASIS_COL_BLEÑA).Visible = False
                    dgvAsistencia.Columns(ASIS_COL_BPODAL).Visible = False
                    dgvAsistencia.Columns(ASIS_COL_BCOLACION).Visible = False
                    dgvAsistencia.Columns(ASIS_COL_BRESPONS).Visible = False
                    dgvAsistencia.Columns(ASIS_COL_BOTROS).Visible = False
                End If
            Case 2 'Retiro de Leche
                If CentroTipo = "SALA" Then
                    chkSinRetiroLeche.Enabled = True
                    BuscarRetiroLeche()
                    btnGrabar.Enabled = True
                    btnEliminar.Enabled = True
                End If
            Case 3 'Riego Purines
                BuscarRiegoPurines()
                btnAgregarRiego.Visible = True
                btnGrabar.Enabled = True
                btnEliminar.Enabled = True
        End Select
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub InterfaceUser(ByVal TabOpc As Integer)
        If Me.tabFormulario.TabPages.IndexOf(Me.TabPage1) = -1 Then
            Me.tabFormulario.TabPages.Insert(0, Me.TabPage1)
        End If
        If Me.tabFormulario.TabPages.IndexOf(Me.TabPage2) = -1 Then
            Me.tabFormulario.TabPages.Insert(1, Me.TabPage2)
        End If
        If Me.tabFormulario.TabPages.IndexOf(Me.TabPage3) = -1 Then
            Me.tabFormulario.TabPages.Insert(2, Me.TabPage3)
        End If
        If Me.tabFormulario.TabPages.IndexOf(Me.TabPage4) = -1 Then
            Me.tabFormulario.TabPages.Insert(3, Me.TabPage4)
        End If
        If PerfilUsuario = 6 Then 'PERFIL RRHH
            Me.tabFormulario.TabPages.Remove(Me.TabPage1) 'Leche
            Me.tabFormulario.TabPages.Remove(Me.TabPage3) 'Retiro de Leche
            Me.tabFormulario.TabPages.Remove(Me.TabPage4) 'Riego Purines
            TabOpc = 1
        End If

        If CentroTipo <> "SALA" Then
            Me.tabFormulario.TabPages.Remove(Me.TabPage1) 'Leche
            Me.tabFormulario.TabPages.Remove(Me.TabPage3) 'Retiro de Leche
            TabOpc = 1
        End If
        If CentroTipo.Contains("ADM") Or CentroTipo.Contains("GEN") Or CentroTipo = "" Then
            Me.tabFormulario.TabPages.Remove(Me.TabPage1) 'Leche
            Me.tabFormulario.TabPages.Remove(Me.TabPage3) 'Retiro de Leche
            Me.tabFormulario.TabPages.Remove(Me.TabPage4) 'Riego Purines
            pnlVacasSecas.Visible = False
            TabOpc = 1
        End If
        If AfectoAsistencia = "NO" Then
            Me.tabFormulario.TabPages.Remove(Me.TabPage2) 'Asistencia
        End If

        If Me.tabFormulario.TabPages.IndexOf(Me.TabPage1) = -1 _
            And Me.tabFormulario.TabPages.IndexOf(Me.TabPage2) = -1 _
            And Me.tabFormulario.TabPages.IndexOf(Me.TabPage3) = -1 _
            And Me.tabFormulario.TabPages.IndexOf(Me.TabPage4) = -1 Then
            MsgBox("ERROR: CENTRO NO CUMPLE CON LOS REQUISITOS PARA USAR ESTA PANTALLA", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR CENTRO")
            Exit Sub
        End If
        rbtnAM.Visible = False
        rbtnPM.Visible = False
        grpHoraTermino.Visible = False
        grpTotalLeche.Visible = False
        grpTotalLechePlanta.Visible = False
        pnlVacasSecas.Visible = False

        lblJornadaDia.Text = "DIA"
        lblJornadaDia.Visible = False
        btnVBTarja.Visible = False
        btnAdminVBTarja.Visible = False


        btnAgregarRiego.Visible = False

        btnGrabar.Enabled = False
        btnEliminar.Enabled = False

        Select Case TabOpc
            Case 0
                rbtnAM.Visible = True
                rbtnPM.Visible = True
                grpHoraTermino.Visible = True
                grpTotalLeche.Visible = True
                grpTotalLechePlanta.Visible = True
                pnlVacasSecas.Visible = True
                grpLeche.Visible = True

                grpConcentrado.Top = 202
                grpConcentrado.Height = 197 '163
                dgvConcentrado.Height = 169 '129
                dgvConcentrado.Columns(CONS_COL_NROVACAS).ReadOnly = False
                dgvConcentrado.Columns(CONS_COL_NROVACAS).DefaultCellStyle.BackColor = Color.White 'System.Drawing.Color.FromArgb(224, 224, 224)

                If BuscarCierreTemporada() = True Then
                    HabilitaLeche(False)
                Else
                    HabilitaLeche(True)
                End If
            Case 1
                lblJornadaDia.Visible = True
                rbtnAM.Visible = False
                rbtnPM.Visible = False

                If PerfilUsuario > 2 Then 'Cualquier perfil diferente a Administrador de Centro y a Visitante
                    btnVBTarja.Visible = True
                    If PerfilUsuario = 6 Then 'PERFIL RRHH
                        btnAdminVBTarja.Visible = True
                    End If
                End If
            Case 2

            Case 3
        End Select

        btnAgregarMastitis.Visible = True
        btnCojeraMastitis.Visible = True
        btnImprime.Visible = True
        btnAgregarRiego.Left = btnImprime.Left + btnImprime.Width + 6


    End Sub

    Private Sub ConsultaProductosConcentrado()

        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPProductos_ListadoBodegaConcentrado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        dgvConcentrado.SuspendLayout()
        dgvConcentrado2.SuspendLayout()
        dgvConcentrado.Rows.Clear()
        dgvConcentrado2.Rows.Clear()

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    dgvConcentrado.Rows.Add(rdr("IteNom").ToString.Trim, Format(rdr("BodStoAct"), "#,##0.00"), "", "", "", rdr("ProdCodigo").ToString.Trim, rdr("ProdCuenta").ToString.Trim, rdr("ProdItemGasto").ToString.Trim, rdr("UM").ToString.Trim)
                    dgvConcentrado2.Rows.Add(rdr("IteNom").ToString.Trim, Format(rdr("BodStoAct"), "#,##0.0"), "", "", "", rdr("ProdCodigo").ToString.Trim, rdr("ProdCuenta").ToString.Trim, rdr("ProdItemGasto").ToString.Trim, rdr("UM").ToString.Trim)
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        dgvConcentrado.ResumeLayout()
        dgvConcentrado2.ResumeLayout()

SalirProc:
    End Sub
    Private Sub InicializaEstanques()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCentros_NroEstanquesLeche", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
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
        lblEstq2.Enabled = False

        If NroEstanques > 1 Then
            TxtTempEst2.Enabled = True
            lblEstq2.Enabled = True
        End If
    End Sub
    Private Sub LlenaDataTablesAsistencia()
        ''cargamos estado de asistencia de funcionarios
        Dim Detalles As New DataTable("NomenclaturasAsistencia")
        Detalles.Columns.Add("codigo")
        Detalles.Columns.Add("descrip")

        For i = 0 To General.nomenclaturas.NroRegistros - 1
            Detalles.Rows.Add(General.nomenclaturas.ID(i), General.nomenclaturas.Nombre(i))
        Next

        ''Dim Cestados As New DataGridViewComboBoxColumn
        Cestados.Width = "150"
        Cestados.DisplayMember = "descrip"
        Cestados.ValueMember = "codigo"
        Cestados.DataSource = Detalles
        Cestados.HeaderText = "Estado "
        Cestados.DisplayIndex = 0

        dgvAsistencia.Columns.Add(Cestados)
        dgvAsistencia.Columns(ASIS_COL_NOMENCLATURA).DisplayIndex = 2    'INDEX=8

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
        dgvAsistencia.Columns(ASIS_COL_MOTIVOHHEE).DisplayIndex = 4     'INDEX=9
    End Sub
    Private Sub ClienteDGVRetiroLeche()


        dgCboClientes.DisplayMember = "CliNom"
        dgCboClientes.ValueMember = "CliCod"
        dgCboClientes.DataSource = ClientPlanta.ObtenerClientesPlanta()
        dgCboClientes.Width = "210"
        dgCboClientes.HeaderText = "Cliente (Planta)"
        dgCboClientes.DisplayIndex = -1

        dgvRetiroLeche.Columns.Add(dgCboClientes)
        dgvRetiroLeche.Columns(RET_COL_CLIENTECOD).DisplayIndex = 5
    End Sub

#End Region

#Region "Cbo Centros"

    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged

        Dim selectedRow As DataRowView = DirectCast(cboCentros.SelectedItem, DataRowView)
            If selectedRow IsNot Nothing Then CentroCod = selectedRow("CentroCod")
            If selectedRow IsNot Nothing Then CentroTipo = selectedRow("CentroTipo")
            If selectedRow IsNot Nothing Then AfectoAsistencia = selectedRow("AfectoAsistencia")

            NroEstanques = 0
        RecepcionMaterialesPendientes(1)
        TabuladorFormulario(EnEventoLoad)
    End Sub



#End Region

#Region "DatePart Fecha"

    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        TabuladorFormulario(EnEventoLoad)
    End Sub

    Private Function BuscarCierreTemporada() As Boolean
        BuscarCierreTemporada = False

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spLeche_BuscarCierreTemporada", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value) 'Now)
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

    Private Sub HabilitaLeche(ByVal des As Boolean)
        txtHoraTermino.Enabled = des

        LitrosPlanta.Enabled = des
        LitrosCalostro.Enabled = des
        LitrosAntibioticos.Enabled = des
        LitrosMala.Enabled = des

        VacasPlanta.Enabled = des
        VacasCalostro.Enabled = des
        VacasAntibioticos.Enabled = des
        VacasMalas.Enabled = des

        TxtTempEst1.Enabled = des
        TxtTempEst2.Enabled = des

        txtTempHora.Enabled = des
    End Sub

#End Region

#Region "Leche - Concentrado"

    Private Sub LitrosPlanta_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles LitrosPlanta.LostFocus, LitrosTerneros.LostFocus, LitrosCalostro.LostFocus, LitrosAntibioticos.LostFocus, LitrosMala.LostFocus, LitrosCojas.LostFocus,
                    VacasPlanta.LostFocus, VacasTerneros.LostFocus, VacasCalostro.LostFocus, VacasAntibioticos.LostFocus, VacasMalas.LostFocus, VacasCojas.LostFocus

        Dim text As TextBox = DirectCast(sender, TextBox)

        ''CALCULAMOS VALORES TOTALES Y DE CONCENTRADO
        CalculaTotalesLeche(text)

        'If CType(sender, TextBox).Name.Contains("Vacas") Then
        '    If dgvConcentrado.Rows.Count > 0 Then
        '        For i As Integer = 0 To dgvConcentrado.Rows.Count - 1
        '            CalculoConcentradoPorAnimal(i)
        '        Next
        '    End If
        'End If
    End Sub

    Private Sub LitrosPlanta_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
           Handles LitrosPlanta.Click, LitrosTerneros.Click, LitrosCalostro.Click, LitrosAntibioticos.Click, LitrosMala.Click, LitrosCojas.Click,
                   VacasPlanta.Click, VacasTerneros.Click, VacasCalostro.Click, VacasAntibioticos.Click, VacasMalas.Click, VacasCojas.Click

        Dim text As TextBox = DirectCast(sender, TextBox)

        text.SelectAll()
    End Sub

    Private Sub LitrosPlanta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles LitrosPlanta.KeyPress, LitrosTerneros.KeyPress, LitrosCalostro.KeyPress, LitrosAntibioticos.KeyPress, LitrosMala.KeyPress, LitrosCojas.KeyPress,
                    VacasPlanta.KeyPress, VacasTerneros.KeyPress, VacasCalostro.KeyPress, VacasAntibioticos.KeyPress, VacasMalas.KeyPress, VacasCojas.KeyPress

        Dim text As TextBox = DirectCast(sender, TextBox)

        valida_tecla(e.KeyChar)
        Dim caracter As Char = e.KeyChar

        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub CalculaTotalesLeche(ByVal txt As TextBox)
        If txt.Text = "" Then
            txt.Text = 0
        End If

        lbTotLitros.Text = Int32.Parse(LitrosPlanta.Text) + Int32.Parse(LitrosCalostro.Text) + Int32.Parse(LitrosAntibioticos.Text) + Int32.Parse(LitrosMala.Text) + Int32.Parse(LitrosTerneros.Text) + Int32.Parse(LitrosCojas.Text)
        LbTotVacas.Text = Int32.Parse(VacasPlanta.Text) + Int32.Parse(VacasAntibioticos.Text) + Int32.Parse(VacasCalostro.Text) + Int32.Parse(VacasMalas.Text) + Int32.Parse(VacasTerneros.Text) + Int32.Parse(VacasCojas.Text)

        If Int32.Parse(lbTotLitros.Text) > 0 And Int32.Parse(LbTotVacas.Text.Replace(".", "")) > 0 And Int32.Parse(lbTotLitros.Text) > Int32.Parse(LbTotVacas.Text.Replace(".", "")) Then
            LbTotLtVacas.Text = Math.Round(Int32.Parse(lbTotLitros.Text) / Int32.Parse(LbTotVacas.Text.Replace(".", "")), 1)
        End If

        CalculaNroVacasSecas()
    End Sub

    Private Sub CalculaNroVacasSecas()
        Dim vacas_ordeñadas As Integer = IIf(LbTotVacas.Text.Replace(".", "") <> "", Int32.Parse(LbTotVacas.Text.Replace(".", "")), 0)
        Dim vacas_stock As Integer = StockVacas ''IIf(lvESTADOGANADO.Items(0).SubItems(0).Text <> "", Int32.Parse(lvESTADOGANADO.Items(0).SubItems(0).Text), 0)

        lblNroVacasSecas.Text = (vacas_stock - vacas_ordeñadas).ToString.Trim

        If lblNroVacasSecas.Text = "0" Then
            pnlVacasSecas.Visible = False
        Else
            pnlVacasSecas.Visible = True
        End If
    End Sub

    Public Sub valida_tecla(ByVal tecla As Char)
        If tecla = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If

        Dim caracter As Char = tecla

        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            tecla = Chr(0)
        End If
    End Sub

    Private Function GrabarLeche() As Boolean
        GrabarLeche = False

        Cursor.Current = Cursors.WaitCursor
        Dim i As Integer = 0

        Dim DetalleLeche As DataTable = New DataTable("DTLecheDetalle")
        DetalleLeche.Columns.Add("TipoLecheId", System.Type.GetType("System.Decimal"))
        DetalleLeche.Columns.Add("TipoLecheDsc", System.Type.GetType("System.String"))
        DetalleLeche.Columns.Add("TipoLecheLts", System.Type.GetType("System.Decimal"))
        DetalleLeche.Columns.Add("TipoLecheVc", System.Type.GetType("System.Decimal"))

        DetalleLeche.Rows.Add(1, "Leche a Planta", LitrosPlanta.Text, VacasPlanta.Text)
        DetalleLeche.Rows.Add(2, "Leche Terneros", LitrosTerneros.Text, VacasTerneros.Text)
        DetalleLeche.Rows.Add(3, "Leche Calostro", LitrosCalostro.Text, VacasCalostro.Text)
        DetalleLeche.Rows.Add(4, "Leche Antibioticos", LitrosAntibioticos.Text, VacasAntibioticos.Text)
        DetalleLeche.Rows.Add(5, "Leche Descarte", LitrosMala.Text, VacasMalas.Text)
        DetalleLeche.Rows.Add(6, "Leche Cojas", LitrosCojas.Text, VacasCojas.Text)


        Dim DetalleConcentrado As DataTable = New DataTable("DTLecheItemsBodega")
        DetalleConcentrado.Columns.Add("TipoConsumo", System.Type.GetType("System.Decimal"))
        DetalleConcentrado.Columns.Add("ItemCod", System.Type.GetType("System.String"))
        DetalleConcentrado.Columns.Add("ItemNom", System.Type.GetType("System.String"))
        DetalleConcentrado.Columns.Add("ItemCnt", System.Type.GetType("System.Decimal"))
        DetalleConcentrado.Columns.Add("ItemNroVc", System.Type.GetType("System.Decimal"))
        DetalleConcentrado.Columns.Add("ItemKgVc", System.Type.GetType("System.Decimal"))
        DetalleConcentrado.Columns.Add("ItemStkActual", System.Type.GetType("System.Decimal"))
        Dim hayconcetrado As Boolean = False
        For i = 0 To dgvConcentrado.Rows.Count - 1
            If dgvConcentrado.Rows(i).Cells(3).Value <> "" Then
                If dgvConcentrado.Rows(i).Cells(3).Value > 0 Then
                    DetalleConcentrado.Rows.Add(1, dgvConcentrado.Rows(i).Cells(5).Value, dgvConcentrado.Rows(i).Cells(0).Value, dgvConcentrado.Rows(i).Cells(2).Value,
                                                     dgvConcentrado.Rows(i).Cells(3).Value, dgvConcentrado.Rows(i).Cells(4).Value, dgvConcentrado.Rows(i).Cells(1).Value)
                    hayconcetrado = True

                End If
            End If
        Next
        For i = 0 To dgvConcentrado2.Rows.Count - 1
            If dgvConcentrado2.Rows(i).Cells(3).Value <> "" Then
                If dgvConcentrado2.Rows(i).Cells(3).Value > 0 Then
                    DetalleConcentrado.Rows.Add(2, dgvConcentrado2.Rows(i).Cells(5).Value, dgvConcentrado2.Rows(i).Cells(0).Value, dgvConcentrado2.Rows(i).Cells(2).Value,
                                                     dgvConcentrado2.Rows(i).Cells(3).Value, dgvConcentrado2.Rows(i).Cells(4).Value, dgvConcentrado2.Rows(i).Cells(1).Value)
                    hayconcetrado = True
                End If
            End If
        Next


        'GRABAMOS REGISTRO DE LECHE
        If BuscarCierreTemporada() = False Or hayconcetrado = True Then
            Dim obs As String = "SGL Ordeña"
            If txtObservsGuia.Text <> "" Then
                obs = txtObservsGuia.Text
            End If
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spLeche_GrabarRegistroDiario", con)
            Dim rdr As SqlDataReader = Nothing
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.CommandTimeout = 300 ' 5 minutos
            cmd.Parameters.Clear()
            Dim bodega As String = CentroCod.ToString.Substring(0, 5)
            Dim TotCojOrd As Integer = Convert.ToDecimal(txtTotCojasOrd.Text.Trim)
            cmd.Parameters.Clear()
            Dim FechaLeche As String = Format(dtpFecha.Value, "yyyyMMdd")
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", FechaLeche)
            cmd.Parameters.AddWithValue("@Horario", IIf(rbtnAM.Checked = True, 1, 2))
            cmd.Parameters.AddWithValue("@HoraTermino", txtHoraTermino.Text)
            cmd.Parameters.AddWithValue("@TempEstanque1", TxtTempEst1.Text)
            cmd.Parameters.AddWithValue("@TempEstanque2", TxtTempEst2.Text)
            cmd.Parameters.AddWithValue("@TempHora", txtTempHora.Text)
            cmd.Parameters.AddWithValue("@Observs", obs)
            cmd.Parameters.AddWithValue("@DTLecheDetalle", DetalleLeche)
            cmd.Parameters.AddWithValue("@DTLecheItemsBodega", DetalleConcentrado)
            cmd.Parameters.AddWithValue("@BodegaCodO", bodega)
            cmd.Parameters.AddWithValue("@TotCojOrd", TotCojOrd)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            cmd.Parameters.AddWithValue("@UsuarioApp", "DSKTP")

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
                        GrabarLeche = False
                        ExisteIngresoLeche = False
                        btnGrabar.Enabled = True
                    End If
                Else
                    GrabarLeche = True
                    ExisteIngresoLeche = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                GrabarLeche = False
                ExisteIngresoLeche = False
                btnGrabar.Enabled = True
            Finally
                con.Close()

            End Try

        End If
        Dim fret As String = ""
        Dim cant_ As Integer = 0
        Dim cant2_ As Integer = 0
        Dim vacas_ As Integer = 0
        Dim vacas2_ As Integer = 0

ExitProc:

        Cursor.Current = Cursors.Default
    End Function

    Private Sub rbtnAM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnAM.Click, rbtnPM.Click
        Dim fAM As Font
        Dim fPM As Font

        If CType(sender, RadioButton).Name.Contains("AM") Then
            fAM = New Font(rbtnAM.Font, FontStyle.Bold)
            fPM = New Font(rbtnAM.Font, FontStyle.Regular)

        Else
            fAM = New Font(rbtnAM.Font, FontStyle.Regular)
            fPM = New Font(rbtnAM.Font, FontStyle.Bold)
        End If

        Cursor.Current = Cursors.WaitCursor

        lblUsuarioReg.Text = ""
        lblFechaReg.Text = ""

        If NroEstanques > 1 Then
            TxtTempEst2.Enabled = True
            lblEstq2.Enabled = True
        End If
        TabuladorFormulario(EnEventoLoad)

        Cursor.Current = Cursors.Default

        rbtnAM.Font = fAM
        rbtnPM.Font = fPM
    End Sub

    Private Function EliminarLeche() As Boolean
        EliminarLeche = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim SRVTRANS As SqlTransaction = Nothing

        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE LECHE
        Try
            con.Open()
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 120)")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'ELIMINAMOS LECHE EN SGL
        Dim cmd2 As New SqlCommand("spLeche_EliminarIngresoLeche", con)
        cmd2.CommandType = Data.CommandType.StoredProcedure

        cmd2.Parameters.AddWithValue("@Empresa", Empresa)
        cmd2.Parameters.AddWithValue("@Centro", CentroCod)
        cmd2.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd2.Parameters.AddWithValue("@Horario", IIf(rbtnAM.Checked = True, 1, 2))
        cmd2.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd2.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd2.Parameters.AddWithValue("@PerfilUsuario", PerfilUsuario)
        ''
        cmd2.Parameters.Add("@RetValor", SqlDbType.Int) : cmd2.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd2.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd2.Parameters("@RetMensage").Direction = ParameterDirection.Output
        ''
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
                Exit Try
            End If

            HayError = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 125)")
            HayError = True
        End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'finalizamos transacciones
        Try
            If HayError = True Then
                SRVTRANS.Rollback()
                EliminarLeche = False
                GoTo ExitProc
            End If
            SRVTRANS.Commit()
            EliminarLeche = True
        Catch ex As Exception
            EliminarLeche = False
        End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

ExitProc:
        con.Close()
        Cursor.Current = Cursors.Default
    End Function

    Private Function EliminarConcentrado() As Boolean
        EliminarConcentrado = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim SRVTRANS As SqlTransaction = Nothing

        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE LECHE
        Try
            con.Open()
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 130)")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        Dim HayError As Boolean
        ''
        If PerfilUsuario = 5 Then
            'obtenemos data_table con el detalle de los productos a consumir
            Dim DetalleConsumos As DataTable = LVToDataTableConsumosConcentrado()

            If GrabarConsumos(DetalleConsumos, 4, True) = True Then

            Else
                'error al grabar consumo
                SRVTRANS.Rollback()
                EliminarConcentrado = False
                ExisteIngresoConcentrado = False
                GoTo ExitProc 'Exit Function
            End If
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'finalizamos transacciones
        Try
            If HayError = True Then
                SRVTRANS.Rollback()
                EliminarConcentrado = False
                GoTo ExitProc
            End If

            SRVTRANS.Commit()
            EliminarConcentrado = True

        Catch ex As Exception
            EliminarConcentrado = False
        End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

ExitProc:
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


    Private InformaConc As Boolean = True
    Private Function ValidaLeche() As Boolean
        ValidaLeche = False
        InformaConc = True
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'VALIDA LECHE
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If General.CentrosUsuario.EsAreaSeca(cboCentros.SelectedIndex) <> True And BuscarCierreTemporada() = False Then
                If CDate(Format(dtpFecha.Value, "dd-MM-yyyy")) > CDate(Format(Now(), "dd-MM-yyyy")) Then
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

                If (LitrosCojas.Text <> "0" And VacasCojas.Text = "0") Or (LitrosCojas.Text = "0" And VacasCojas.Text <> "0") Then
                    MsgBox(("El ingreso de -- litros descarte -- no es concistente").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                    If LitrosCojas.Text = "0" Then LitrosCojas.Focus()
                    If VacasCojas.Text = "0" Then VacasCojas.Focus()
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
                    End If
                End If

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'VALIDAMOS CONCENTRADO
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim cant_ As Double = 0
            Dim cant_OtroPrePartoo As Double = 0
            Dim vacas_ As Double = 0
            Dim suma_vacas As Double = 0
            Dim suma_cons As Double = 0
            Dim suma_consPreParto As Double = 0
            Dim cant_x_vacas As Double = 0
            Dim suma_cant As Double = 0
            Dim StrCant As String = ""
            Dim InformaConcentrado As Boolean = True
            ''si no existen filas de concentrado, entonces no tiene cargado o no esta utilizando. Dificil saber cual opcion es, pero se asumira que no esta consumiendo
            If dgvConcentrado.Rows.Count = 0 Then
                InformaConc = False
                GoTo FinValidacionLeche
            End If
            For i As Integer = 0 To dgvConcentrado2.Rows.Count - 1
                cant_OtroPrePartoo = dgvConcentrado2.ToDouble(i, 2)
                suma_consPreParto += cant_OtroPrePartoo
            Next
            For i As Integer = 0 To dgvConcentrado.Rows.Count - 1
                InformaConcentrado = True

                StrCant = dgvConcentrado.ToString2(i, CONS_COL_CANTIDAD)
                cant_ = dgvConcentrado.ToDouble(i, CONS_COL_CANTIDAD)
                vacas_ = dgvConcentrado.ToDouble(i, CONS_COL_NROVACAS)
                cant_x_vacas = dgvConcentrado.ToDouble(i, CONS_COL_CANTPORVACA)

                If StrCant = "" Then
                    MsgBox(("Debe informar el consumo de Alimentos." + vbCrLf + "** Si usted no esta entregando Alimentos, debe informar la cantidad con valor CERO (0) para cada producto que tenga en Stock."), MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                    Exit Function
                End If
                If StrCant = "0" Then 'Se asume que no informará concentrado en la linea
                    InformaConcentrado = False
                End If
                'If General.CentrosUsuario.EsAreaSeca(cboCentros.SelectedIndex) = True Then
                If cant_ <> 0 And vacas_ = 0 Then
                    MsgBox(("Debe ingresar el -- n° de animales --").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                    Exit Function
                End If

                If cant_ = 0 And vacas_ <> 0 Then
                    MsgBox(("Debe ingresar la -- cantidad de Alimentos --").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                    Exit Function
                End If
                '   End If

                suma_cons += cant_ 'dgvConcentrado.ToDouble(i, CONS_COL_CANTIDAD)
                suma_cant += cant_x_vacas

                If vacas_ > suma_vacas Then suma_vacas = vacas_
            Next
            If suma_cons = 0 And suma_consPreParto = 0 Then
                InformaConc = False
                GoTo FinValidacionLeche
            End If
            If InformaConc = True Then
                'If suma_cons = 0 Then
                '    MsgBox(("Debe ingresar una -- dosis de concentrado --").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                '    Exit Function
                'End If

                'si el concentrado por vaca a repartir es menor a 1 kilo, hay error
                If suma_cant < 0.1 And suma_cant <> 0 Then
                    MsgBox(("La cantidad total -- no puede ser menor a un kilo --").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                    Exit Function
                End If
            Else
                InformaConc = False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'VALIDAMOS CONCENTRADO2
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            cant_ = 0
            vacas_ = 0
            suma_vacas = 0
            suma_cons = 0
            cant_x_vacas = 0
            suma_cant = 0
            ''
            For i As Integer = 0 To dgvConcentrado2.Rows.Count - 1
                cant_ = dgvConcentrado2.ToDouble(i, CONS_COL_CANTIDAD)
                vacas_ = dgvConcentrado2.ToDouble(i, CONS_COL_NROVACAS)
                cant_x_vacas = dgvConcentrado2.ToDouble(i, CONS_COL_CANTPORVACA)

                If General.CentrosUsuario.EsAreaSeca(cboCentros.SelectedIndex) = True Then
                    If cant_ <> 0 And vacas_ = 0 Then
                        MsgBox(("Debe ingresar el -- n° de animales --").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                        Exit Function
                    End If

                    If cant_ = 0 And vacas_ <> 0 Then
                        MsgBox(("Debe ingresar la -- cantidad de Alimentos --").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                        Exit Function
                    End If
                End If

                suma_cons += cant_
                suma_cant += cant_x_vacas

                If vacas_ > suma_vacas Then suma_vacas = vacas_
            Next
FinValidacionLeche:
            ValidaLeche = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 100)")
            Cursor.Current = Cursors.Default
        End Try
    End Function

#End Region

#Region "Asistencia"

    Public Sub BuscarAsistenciaFuncionarios(ByVal Horario As String)
        ExisteIngresoAsistencia = False

        Try

            Dim con As New SqlConnection(GetConnectionStringRRHH())
            Dim cmd As New SqlCommand("spAsistencia_BuscarFuncionarios", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Horario", 1) 'IIf(Horario = "AM", 1, 2)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim tasis As String
            Dim motivo As String

            Dim i As Integer = 0
            Dim hrs As Double = 0
            Dim tothrs As Double = 0

            dgvAsistencia.SuspendLayout()
            dgvAsistencia.Rows.Clear()
            lblNroFuncs.Text = "0"
            lblTotHrsExtras.Text = "0"
            ''
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

                If ExisteIngresoAsistencia = False And Not IsDBNull(rdr("ANomNombre")) Then
                    ExisteIngresoAsistencia = True
                End If

                If ExisteIngresoAsistencia = True Then
                    dgvAsistencia.Rows.Add(rdr("Rut"), rdr("Nombre"), hrs.ToString.Trim, rdr("AsisBonoLenia"), rdr("AsisBonoPodal"), rdr("AsisBonoColacion"), rdr("AsisBonoResponsabilidad"), rdr("AsisBonoOtros"))
                Else
                    dgvAsistencia.Rows.Add(rdr("Rut"), rdr("Nombre"), "", rdr("AsisBonoLenia"), rdr("AsisBonoPodal"), rdr("AsisBonoColacion"), rdr("AsisBonoResponsabilidad"), rdr("AsisBonoOtros"))
                End If



                If ExisteIngresoAsistencia = False Then
                    dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(ASIS_COL_NOMENCLATURA).Value = "1"
                    dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(ASIS_COL_MOTIVOHHEE).Value = "0"
                    dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(ASIS_COL_HHEE).ReadOnly = False
                Else
                    dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(ASIS_COL_NOMENCLATURA).Value = rdr("AsisNomenclatura").ToString.Trim
                    dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(ASIS_COL_MOTIVOHHEE).Value = rdr("AsisMotivoHE").ToString.Trim
                    dgvAsistencia.Rows(dgvAsistencia.Rows.Count - 1).Cells(ASIS_COL_HHEE).ReadOnly = True
                End If

                tothrs = tothrs + hrs
                i = i + 1
            End While

            dgvAsistencia.ResumeLayout()
            SeleccionaNomenclatura = ExisteIngresoAsistencia 'True

            lblNroFuncs.Text = i.ToString.Trim
            lblTotHrsExtras.Text = tothrs.ToString.Trim

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Function GrabarAsistencia() As Boolean
        GrabarAsistencia = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spAsistencia_Grabar", con)
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE ASISTENCIA
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 130)")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        ''
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean
        Dim rut, nombre As String
        Dim nomenclatura, motivohe, blenia, bpodal, bcolacion, brespons, botros As Integer
        Dim hhee As Double

        For i = 0 To dgvAsistencia.Rows.Count - 1
            rut = dgvAsistencia.ToString2(i, ASIS_COL_RUT).Trim
            nombre = dgvAsistencia.ToString2(i, ASIS_COL_NOMBRE)
            hhee = dgvAsistencia.ToDouble(i, ASIS_COL_HHEE)
            ''
            blenia = dgvAsistencia.ToInteger(i, ASIS_COL_BLEÑA)
            bpodal = dgvAsistencia.ToInteger(i, ASIS_COL_BPODAL)
            bcolacion = dgvAsistencia.ToInteger(i, ASIS_COL_BCOLACION)
            brespons = dgvAsistencia.ToInteger(i, ASIS_COL_BRESPONS)
            botros = dgvAsistencia.ToInteger(i, ASIS_COL_BOTROS)
            ''
            nomenclatura = dgvAsistencia.ToInteger(i, ASIS_COL_NOMENCLATURA)
            motivohe = dgvAsistencia.ToInteger(i, ASIS_COL_MOTIVOHHEE)

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Horario", 1) 'IIf(rbtnAM.Checked = True, 1, 2)
            cmd.Parameters.AddWithValue("@Rut", rut)
            cmd.Parameters.AddWithValue("@Nomenclatura", nomenclatura)      'Int32.Parse(dgvAsistencia.Rows(i).Cells(8).Value))
            cmd.Parameters.AddWithValue("@HHEE", hhee)                      'Double.Parse(dgvAsistencia.Rows(i).Cells(2).Value))
            cmd.Parameters.AddWithValue("@MotivoHE", motivohe)
            cmd.Parameters.AddWithValue("@BonoLenia", blenia)               'Int32.Parse(dgvAsistencia.Rows(i).Cells(3).Value))
            cmd.Parameters.AddWithValue("@BonoPodal", bpodal)               'Int32.Parse(dgvAsistencia.Rows(i).Cells(4).Value))
            cmd.Parameters.AddWithValue("@BonoColacion", bcolacion)         'Int32.Parse(dgvAsistencia.Rows(i).Cells(5).Value))
            cmd.Parameters.AddWithValue("@BonoResponsab", brespons)         'Int32.Parse(dgvAsistencia.Rows(i).Cells(6).Value))
            cmd.Parameters.AddWithValue("@BonoOtros", botros)               'Int32.Parse(dgvAsistencia.Rows(i).Cells(7).Value))
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

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 135)")
                HayError = True
                Exit For
            End Try
        Next

        'si hay error hasta aqui salimos
        If HayError = False Then
            SRVTRANS.Commit()
            GrabarAsistencia = True
            ExisteIngresoAsistencia = True
            btnGrabar.Enabled = False
            btnEliminar.Enabled = True
        Else
            SRVTRANS.Rollback()
            GrabarAsistencia = False
            ExisteIngresoAsistencia = False
        End If

        con.Close()
        Cursor.Current = Cursors.Default
    End Function

    Private Function EliminarAsistencia() As Boolean
        EliminarAsistencia = False

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spAsistencia_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", 1) 'IIf(rbtnAM.Checked = True, 1, 2)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 140)")
        End Try
    End Function

#End Region

#Region "Retiro Leche"
    Private Sub BuscarRetiroLeche()
        ExisteIngresoRetiro = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_BuscarRetiros", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        con.Open()
        rdr = cmd.ExecuteReader()

        Dim i As Integer
        Dim totlitrosdia, totlitrosmes As Double
        Dim palcohol, verde, amarillo, rojo, azul As Boolean
        Dim ClientCodigo As String = ""

        dgvRetiroLeche.SuspendLayout()
        dgvRetiroLeche.Rows.Clear()


        Panel12.Visible = False

        While rdr.Read()
            If rdr("LRetLitros") = 0 Then
                totlitrosmes = rdr("TotLitrosRetMes")
                Panel12.Visible = True
                chkSinRetiroLeche.Checked = True
                chkSinRetiroLeche.Enabled = False
                GrabarOK = 1
                Exit While
            End If




            palcohol = False
            verde = False
            amarillo = False
            rojo = False
            azul = False
            If Not IsDBNull(rdr("LRetClienteCod")) Then ExisteIngresoRetiro = True
            If Not IsDBNull(rdr("LRetPruebaOX")) Then palcohol = IIf(rdr("LRetPruebaOX") = 0, False, True)
            If Not IsDBNull(rdr("LRetVerde")) Then verde = IIf(rdr("LRetVerde") = 0, False, True)
            If Not IsDBNull(rdr("LRetAmarillo")) Then amarillo = IIf(rdr("LRetAmarillo") = 0, False, True)
            If Not IsDBNull(rdr("LRetRojo")) Then rojo = IIf(rdr("LRetRojo") = 0, False, True)
            If Not IsDBNull(rdr("LRetAzul")) Then azul = IIf(rdr("LRetAzul") = 0, False, True)
            ClientCodigo = rdr("LRetClienteCod").ToString.Trim

            dgvRetiroLeche.Rows.Add(rdr("LRetTransporte"),
                                   rdr("LRetNroGuia"),
                                   rdr("LRetHora"),
                                   rdr("LRetTransporte"),
                                   rdr("LRetNroGuia"),
                                   rdr("LRetClienteNom"),
                                   rdr("LRetLitros"),
                                   rdr("LRetTemperatura"),
                                   palcohol,
                                   verde,
                                   amarillo,
                                   rojo,
                                   azul,
                                   rdr("LRetObservs"),
                                   rdr("LRetChofer"))
            If ExisteIngresoRetiro Then
                dgvRetiroLeche.Rows(dgvRetiroLeche.Rows.Count - 2).Cells(RET_COL_CLIENTECOD).Value = ClientCodigo
                chkSinRetiroLeche.Enabled = False
            Else
                chkSinRetiroLeche.Enabled = True
            End If

            totlitrosdia = totlitrosdia + rdr("LRetLitros")
            totlitrosmes = rdr("TotLitrosRetMes")

            i = i + 1
        End While

        dgvRetiroLeche.ResumeLayout()
        lblNroRetiros.Text = i.ToString.Trim
        lblTotLtsRetiradosDia.Text = Format(totlitrosdia, "#,#0")
        lblTotLtsRetiradosMes.Text = Format(totlitrosmes, "#,#0")

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub
    Private Function GrabarRetiro() As Boolean
        GrabarRetiro = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_GrabarRetiros", con)
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE RETIRO
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 145)")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try


        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean
        Dim hora, patente, patente_nueva, chofer, observs, ClienteCod, ClienteNom As String
        Dim guia, guia_nueva, litros, temp, palcohol, verde, amarillo, rojo, azul As Integer


        For i = 0 To dgvRetiroLeche.Rows.Count - 1
            If dgvRetiroLeche.Rows(i).Cells(RET_COL_PATENTE).Value Is Nothing Then Exit For

            patente = dgvRetiroLeche.ToString2(i, RET_COL_PATENTE_KEY)
            guia = dgvRetiroLeche.ToInteger(i, RET_COL_GUIA_KEY)
            ''
            hora = dgvRetiroLeche.ToString2(i, RET_COL_HORA)
            patente_nueva = dgvRetiroLeche.ToString2(i, RET_COL_PATENTE)
            guia_nueva = dgvRetiroLeche.ToInteger(i, RET_COL_GUIA)
            ClienteCod = dgvRetiroLeche.ToString2(i, RET_COL_CLIENTECOD)
            ClienteNom = ""
            ''
            litros = dgvRetiroLeche.ToInteger(i, RET_COL_LITROS)
            temp = dgvRetiroLeche.ToDouble(i, RET_COL_TEMP)
            ''
            palcohol = dgvRetiroLeche.ToIntegerFromCheckBox(i, RET_COL_PALCOHOL)
            verde = dgvRetiroLeche.ToIntegerFromCheckBox(i, RET_COL_VERDE)
            amarillo = dgvRetiroLeche.ToIntegerFromCheckBox(i, RET_COL_AMARILLO)
            rojo = dgvRetiroLeche.ToIntegerFromCheckBox(i, RET_COL_ROJO)
            azul = dgvRetiroLeche.ToIntegerFromCheckBox(i, RET_COL_AZUL)
            ''
            observs = dgvRetiroLeche.ToString2(i, RET_COL_OBSERVS)
            chofer = dgvRetiroLeche.ToString2(i, RET_COL_CHOFER)

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Transporte", patente)
            cmd.Parameters.AddWithValue("@NroGuia", guia)
            cmd.Parameters.AddWithValue("@Chofer", chofer)
            cmd.Parameters.AddWithValue("@Clientecod", ClienteCod.Trim)
            cmd.Parameters.AddWithValue("@ClienteNom", ClienteNom.Trim)
            cmd.Parameters.AddWithValue("@Hora", hora)
            cmd.Parameters.AddWithValue("@TransporteNuevo", patente_nueva)
            cmd.Parameters.AddWithValue("@NroGuiaNuevo", guia_nueva)
            cmd.Parameters.AddWithValue("@Litros", litros)
            cmd.Parameters.AddWithValue("@Temperatura", temp)
            cmd.Parameters.AddWithValue("@PruebaOX", palcohol)
            cmd.Parameters.AddWithValue("@Verde", verde)
            cmd.Parameters.AddWithValue("@Amarillo", amarillo)
            cmd.Parameters.AddWithValue("@Rojo", rojo)
            cmd.Parameters.AddWithValue("@Azul", azul)
            cmd.Parameters.AddWithValue("@Observs", observs)
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
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 150)")
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
                dgvRetiroLeche.Rows(i).Cells(RET_COL_PATENTE_KEY).Value = dgvRetiroLeche.Rows(i).Cells(RET_COL_PATENTE).Value
                dgvRetiroLeche.Rows(i).Cells(RET_COL_GUIA_KEY).Value = dgvRetiroLeche.Rows(i).Cells(RET_COL_GUIA).Value
            Next
        Else
            SRVTRANS.Rollback()
            GrabarRetiro = False
            ExisteIngresoRetiro = False
        End If
        con.Close()
        Cursor.Current = Cursors.Default
    End Function
    Private Function EliminarRetiroLeche() As Boolean
        EliminarRetiroLeche = False
        Dim LineaActual As Integer = dgvRetiroLeche.CurrentRow.Index

        'verificamos si vamos a eliminar un registro recien creado (no grabado todavia)
        If TieneValorCelda(LineaActual, 0) = False Then
            dgvRetiroLeche.Rows.Remove(dgvRetiroLeche.CurrentRow)
            EliminarRetiroLeche = True
            Exit Function
        End If

        'si no hay un transporte y una guia salimos
        If TieneValorCelda(LineaActual, 2) = False Or TieneValorCelda(LineaActual, 3) = False Then Exit Function

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_EliminarRetiroLeche", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Transporte", dgvRetiroLeche.Rows(LineaActual).Cells(RET_COL_PATENTE_KEY).Value)
        cmd.Parameters.AddWithValue("@NroGuia", dgvRetiroLeche.Rows(LineaActual).Cells(RET_COL_GUIA_KEY).Value)
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
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 155)")
        End Try
    End Function
    Private Function EliminarRetiroLecheSinRetiro() As Boolean
        EliminarRetiroLecheSinRetiro = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_EliminarRetiroLeche", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@SinRetiro", "Si")
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
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

            EliminarRetiroLecheSinRetiro = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 155)")
        End Try
    End Function
    Private Sub dgvRetiroLeche_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvRetiroLeche.DataError
        MessageBox.Show("Error happened " _
        & e.Context.ToString())

        If (e.Context = DataGridViewDataErrorContexts.Commit) _
            Then
            MessageBox.Show("Commit error")
        End If
        If (e.Context = DataGridViewDataErrorContexts _
            .CurrentCellChange) Then
            MessageBox.Show("Cell change")
        End If
        If (e.Context = DataGridViewDataErrorContexts.Parsing) _
            Then
            MessageBox.Show("parsing error")
        End If
        If (e.Context =
            DataGridViewDataErrorContexts.LeaveControl) Then
            MessageBox.Show("leave control error")
        End If

        If (TypeOf (e.Exception) Is ConstraintException) Then
            Dim view As DataGridView = CType(sender, DataGridView)
            view.Rows(e.RowIndex).ErrorText = "an error"
            view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
                .ErrorText = "an error"

            e.ThrowException = False
        End If
    End Sub
    Private Function TieneValorCelda(ByVal Linea As Integer, ByVal Columna As Integer) As Boolean
        TieneValorCelda = False

        If dgvRetiroLeche.Rows(Linea).Cells(Columna).Value Is Nothing Then Exit Function
        If dgvRetiroLeche.Rows(Linea).Cells(Columna).Value = "" Then Exit Function

        TieneValorCelda = True
    End Function
    Private Sub dgvRetiroLeche_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiroLeche.CellEnter
        'If e.ColumnIndex = 5 Then
        Dim totlts As Integer

        For i As Integer = 0 To dgvRetiroLeche.Rows.Count - 1
            If Not dgvRetiroLeche.Rows(i).Cells(RET_COL_LITROS).Value Is Nothing Then
                If dgvRetiroLeche.Rows(i).Cells(RET_COL_LITROS).Value.ToString <> "" Then
                    totlts = totlts + Int32.Parse(dgvRetiroLeche.Rows(i).Cells(RET_COL_LITROS).Value)
                End If
            End If
        Next

        lblTotLtsRetiradosDia.Text = totlts
        InicializaVariablesCombosRetLeche()
    End Sub
    Private Sub RetiroLeche_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiroLeche.CellClick
        Dim columna As Integer = dgvRetiroLeche.CurrentCell.ColumnIndex
        Dim linea As Integer = dgvRetiroLeche.CurrentCell.RowIndex

        ''CON ESTO HACEMOS QUE AL HACER UN CLICK EN EL COMBO BOX, MOSTRAMOS LA LISTA
        If columna = RET_COL_CLIENTECOD Then
            If linea <> SelectRowCellCliente Or columna <> SelectColCellCliente Then
                dgvRetiroLeche.BeginEdit(True)
                SendKeys.Send("{F4}")
                SelectRowCellCliente = linea
                SelectColCellCliente = columna
            End If
        End If
    End Sub
    Private Sub dgvRetiroLeche_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRetiroLeche.RowEnter
        lblNroRetiros.Text = (dgvRetiroLeche.Rows.Count - 1).ToString
        InicializaVariablesCombosRetLeche()
    End Sub
    Private Sub dgvRetiroLeche_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRetiroLeche.EditingControlShowing
        ''referencia a la celda   
        Dim col As Integer = dgvRetiroLeche.CurrentCell.ColumnIndex

        'valida keypress 'Or col = RET_COL_CLIENTENOM
        If col = RET_COL_HORA Or col = RET_COL_PATENTE Or col = RET_COL_GUIA Or col = RET_COL_CHOFER Or col = RET_COL_LITROS Or col = RET_COL_TEMP Then
            'Dim validarn As TextBox = CType(e.Control, TextBox)
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtRetiro
        End If

    End Sub
    Private Sub ValidaTxtRetiro(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvRetiroLeche.CurrentCell.ColumnIndex
        'Or columna = RET_COL_CLIENTENOM
        If columna = RET_COL_PATENTE Or columna = RET_COL_CHOFER Then Exit Sub '3

        If columna = RET_COL_HORA Then      '2
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ":") Then
                e.KeyChar = Chr(0)
            End If
        End If

        If columna = RET_COL_LITROS Or columna = RET_COL_TEMP Then          '4 y 5
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            End If
        End If

        If columna = RET_COL_TEMP Then ' 6 
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub
    Private Sub tmrColores_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrColores.Tick
        tmrColores.Enabled = False

        Dim i, o As Integer

        For i = 0 To dgvRetiroLeche.Rows.Count - 1
            For o = 0 To dgvRetiroLeche.Columns.Count - 1
                dgvRetiroLeche.Rows(i).Cells(o).Style.BackColor = Color.White
            Next
        Next
    End Sub
#End Region

#Region "Riego Purines"

    Private Sub BuscarRiegoPurines()
        ExisteIngresoRiego = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_BuscarRiegoPurines", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        con.Open()
        rdr = cmd.ExecuteReader()

        Dim i As Integer

        dgvRiegoPurines.SuspendLayout()
        dgvRiegoPurines.Rows.Clear()

        While rdr.Read()

            Dim fecha As String = Format(rdr("RiegoFecha"), "dd-MM-yyyy")
            dgvRiegoPurines.Rows.Add("",
                                   Format(rdr("RiegoFecha"), "dd-MM-yyyy"),
                                   rdr("RiegoTipoResp"),
                                   rdr("RiegoNomResp"),
                                   rdr("RiegoTipo"),
                                   rdr("RiegoCantidad"),
                                   rdr("PotreroCod"),
                                   rdr("RiegoSuperficie"),
                                   rdr("RiegoRutResp"),
                                   rdr("RiegoNomResp"))

            ExisteIngresoRiego = True

            i = i + 1
        End While

        dgvRiegoPurines.ResumeLayout()

        Label37.Text = i.ToString.Trim

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub

    Private Function GrabarRiegoPurines() As Boolean
        GrabarRiegoPurines = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_GrabarRiegoPurines", con)
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE RETIRO
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 160)")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try


        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        ''
        Dim HayError As Boolean
        Dim fecha As Date
        Dim tiporesp, nomresp, rutresp, tiporiego, nropot As String
        Dim cant As Double

        HayError = False

        For i = 0 To dgvRiegoPurines.Rows.Count - 1
            If dgvRiegoPurines.Rows(i).Cells(RIEGO_COL_FECHA).Value Is Nothing Then Exit For

            fecha = dgvRiegoPurines.ToDate(i, RIEGO_COL_FECHA)
            nropot = dgvRiegoPurines.ToString2(i, RIEGO_COL_NROPOTREROS)
            ''
            tiporesp = dgvRiegoPurines.ToString2(i, RIEGO_COL_TIPORESPONSABLE)
            nomresp = dgvRiegoPurines.ToString2(i, RIEGO_COL_NOMRESPONSABLE)
            rutresp = dgvRiegoPurines.ToString2(i, RIEGO_COL_RUT)
            tiporiego = dgvRiegoPurines.ToString2(i, RIEGO_COL_TIPORIEGO)
            cant = dgvRiegoPurines.ToDouble(i, RIEGO_COL_CANTIDAD)

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", fecha)
            cmd.Parameters.AddWithValue("@Potrero", nropot) 'pot.Trim)
            ''
            cmd.Parameters.AddWithValue("@TipoResponsable", tiporesp)
            cmd.Parameters.AddWithValue("@NomResponsable", nomresp)
            cmd.Parameters.AddWithValue("@RutResponsable", rutresp)
            cmd.Parameters.AddWithValue("@TipoRiego", tiporiego)
            cmd.Parameters.AddWithValue("@Cantidad", cant)
            ''
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            ''
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
                    GoTo saleproc 'Exit For
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 165)")
                HayError = True
                GoTo saleproc 'Exit For
            End Try
        Next

saleproc:
        'si hay error hasta aqui salimos
        If HayError = False Then
            SRVTRANS.Commit()
            GrabarRiegoPurines = True
            ExisteIngresoRiego = True

        Else
            SRVTRANS.Rollback()
            GrabarRiegoPurines = False
            ExisteIngresoRiego = False
        End If

        con.Close()
        Cursor.Current = Cursors.Default
    End Function

    Private Function EliminarRiegoPurines() As Boolean
        EliminarRiegoPurines = False
        Dim LineaActual As Integer = dgvRiegoPurines.CurrentRow.Index

        'verificamos si vamos a eliminar un registro recien creado (no grabado todavia)
        If TieneValorCeldaRiego(LineaActual, 0) = False Then
            dgvRiegoPurines.Rows.Remove(dgvRiegoPurines.CurrentRow)
            EliminarRiegoPurines = True
            Exit Function
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_EliminarRiegoPurines", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim fecha As Date
        Dim nropot As String

        fecha = dgvRiegoPurines.ToDate(LineaActual, RIEGO_COL_FECHA)
        nropot = dgvRiegoPurines.ToString2(LineaActual, RIEGO_COL_NROPOTREROS)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Potrero", nropot)

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

            EliminarRiegoPurines = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 170)")
        End Try
    End Function

    Private Function TieneValorCeldaRiego(ByVal Linea As Integer, ByVal Columna As Integer) As Boolean
        TieneValorCeldaRiego = False

        If dgvRiegoPurines.Rows(Linea).Cells(Columna).Value Is Nothing Then Exit Function
        If dgvRiegoPurines.Rows(Linea).Cells(Columna).Value.ToString = "" Then Exit Function

        TieneValorCeldaRiego = True
    End Function

#End Region

#Region "Mi Bodega"

    Private Function GrabarConsumos(ByVal DetalleConsumos As DataTable, ByVal TipoConsumo As Integer, Optional ByVal Eliminar As Boolean = False) As Boolean
        GrabarConsumos = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand(IIf(Eliminar = True, "spGPConsumos_GrabarElimina", "spGPConsumos_Grabar"), con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim cau_ As Integer = 0
        Dim fec_, hr_ As String
        Dim fh_ As DateTime
        Dim bodORI_ As String = ""

        fec_ = Format(dtpFecha.Value, "dd-MM-yyyy")
        hr_ = Format(Now, "HH:mm:ss")
        fh_ = Convert.ToDateTime(fec_ + " " + hr_)


        'antes
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", bodORI_)
        cmd.Parameters.AddWithValue("@Fecha", fh_)
        ''
        cmd.Parameters.AddWithValue("@TablaDetalle", DetalleConsumos)
        ''
        cmd.Parameters.AddWithValue("@TipoConsumo", TipoConsumo)
        ''
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetIDGP", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetIDGP").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            RetIDGP = cmd.Parameters("@RetIDGP").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            GrabarConsumos = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 175)")
        End Try

        Cursor.Current = Cursors.Default
    End Function

    'Fin Region MI BODEGA
#End Region



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

    Private Function VerificaAsistencia() As Boolean
        VerificaAsistencia = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spAsistencia_Existe", con)
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE ASISTENCIA
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 185)")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try
        ''
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
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
                Exit Try
            End If

            VerificaAsistencia = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 190)")
        End Try

        con.Close()
        Cursor.Current = Cursors.Default
    End Function
    Private Function LecheAnterior() As Boolean
        LecheAnterior = False
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_consultaUltRegistro", con)
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE ASISTENCIA
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 185)")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        ''
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Litros", lbTotLitros.Text)
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

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    LecheAnterior = False
                    con.Close()
                    Exit Function
                Else
                    LecheAnterior = True
                End If

                Exit Try

            End If
            LecheAnterior = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 190)")
        End Try

        con.Close()
        Cursor.Current = Cursors.Default
    End Function

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboCentros.SelectedIndex = -1 Then Exit Sub

        '---------------------------------------------------------------------------------------------------------------------------------------------------------
        'buscamos la pestaña seleccionada
        Dim opc As Integer = -1
        If tabFormulario.TabPages(tabFormulario.SelectedIndex).Name.Contains("1") Then opc = 0
        If tabFormulario.TabPages(tabFormulario.SelectedIndex).Name.Contains("2") Then opc = 1
        If tabFormulario.TabPages(tabFormulario.SelectedIndex).Name.Contains("3") Then opc = 2
        If tabFormulario.TabPages(tabFormulario.SelectedIndex).Name.Contains("4") Then opc = 3

        If opc = -1 Then
            If MsgBox("ERROR AL SELECCIONAR LA PAGINA DE GRABACIÓN", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") <> MsgBoxResult.Yes Then
            End If
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------


        Select Case opc
            Case 0  'INGRESO DE LECHE
                'SI NO HAY UN CIERRE DE TEMPORADA, ENTONCES VALIDAMOS DATOS DE ORDEÑA (SOLO PARA LA PESTAÑA 1)
                If BuscarCierreTemporada() = False And opc = 0 Then
                    If ValidaHoraFinalizacionOrdeña() = False Then
                        txtHoraTermino.Focus()
                        Exit Sub
                    End If

                    If ValidaHoraTomaTemperaturas() = False Then
                        txtTempHora.Focus()
                        Exit Sub
                    End If
                End If
                '........................................................................................................
                If ValidaLeche() = False Then Exit Sub
                If RecepcionMaterialesPendientes(0) = True Then Exit Sub
                btnGrabar.Enabled = False
                If MsgBox("¿ DESEA GUARDAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
                If LecheAnterior() = False Then
                    btnGrabar.Enabled = True
                    Exit Sub
                End If

                If ConsultaStockConcentrado(dgvConcentrado) = True Then

                    If GrabarLeche() = True Then
                        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                        End If

                        If rbtnAM.Checked = True Then
                            TotalLecheDia = Int32.Parse(lbTotLitros.Text.Replace(".", ""))
                            TotalVacasDia = Int32.Parse(LbTotVacas.Text.Replace(".", ""))
                            ''
                            TotalLechePlanta = Int32.Parse(LitrosPlanta.Text.Replace(".", ""))
                            TotalVacasPlanta = Int32.Parse(VacasPlanta.Text.Replace(".", ""))
                            ''
                            NroOrdenias = 1
                        Else
                            TotalLecheDia = TotalLecheDia + Int32.Parse(lbTotLitros.Text.Replace(".", ""))
                            TotalVacasDia = TotalVacasDia + Int32.Parse(LbTotVacas.Text.Replace(".", ""))
                            ''
                            TotalLechePlanta = TotalLechePlanta + Int32.Parse(LitrosPlanta.Text.Replace(".", ""))
                            TotalVacasPlanta = TotalVacasPlanta + Int32.Parse(VacasPlanta.Text.Replace(".", ""))
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
                End If
            Case 1  'ASISTENCIA
                '........................................................................................................
                If ValidaAsistencia() = False Then Exit Sub
                If RecepcionMaterialesPendientes(0) = True Then Exit Sub
                If MsgBox("¿ DESEA GUARDAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If

                If GrabarAsistencia() = True Then
                    If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    End If
                End If

            Case 2  'RETIRO LECHE
                '........................................................................................................
                If chkSinRetiroLeche.Checked = False Then
                    If ValidaRetiro() = False Then Exit Sub
                End If


                If MsgBox("¿ DESEA GUARDAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If

                If chkSinRetiroLeche.Checked = True Then
                    If GrabarSinRetiro() = True Then
                        GrabarOK = 1
                        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                        End If
                    End If
                Else
                    If GrabarRetiro() = True Then

                        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                        End If
                    End If
                End If

            Case 3  'RIEGO PURINES
                '........................................................................................................
                If ValidaRiegoPurines() = False Then Exit Sub

                If MsgBox("¿ DESEA GUARDAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If

                If GrabarRiegoPurines() = True Then
                    If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    End If
                    BuscarRiegoPurines()
                End If

        End Select

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If cboCentros.SelectedIndex = -1 Then Exit Sub
        '---------------------------------------------------------------------------------------------------------------------------------------------------------
        Dim opc As Integer = -1
        If tabFormulario.TabPages(tabFormulario.SelectedIndex).Name.Contains("1") Then opc = 0
        If tabFormulario.TabPages(tabFormulario.SelectedIndex).Name.Contains("2") Then opc = 1
        If tabFormulario.TabPages(tabFormulario.SelectedIndex).Name.Contains("3") Then opc = 2
        If tabFormulario.TabPages(tabFormulario.SelectedIndex).Name.Contains("4") Then opc = 3

        If opc = -1 Then
            If MsgBox("ERROR AL SELECCIONAR LA PAGINA DE GRABACIÓN", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") <> MsgBoxResult.Yes Then
            End If
            Exit Sub
        End If
        '---------------------------------------------------------------------------------------------------------------------------------------------------------

        Select Case opc
            Case 0  'INGRESO LECHE
                'perfil de administrador de sistema (5) y Control de Gestion (11) elimina leche y concentrado
                If PerfilUsuario = 5 Or PerfilUsuario = 11 Then
                    If MsgBox("¿ DESEA ELIMINAR EL INGRESO DE LECHE " + IIf(rbtnAM.Checked = True, "(AM)", "(PM)") + " Y EL ALiMENTO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                Else
                    If MsgBox("¿ DESEA ELIMINAR EL INGRESO DE LECHE " + IIf(rbtnAM.Checked = True, "(AM)", "(PM)") + " ?" + vbCrLf + vbCrLf +
                              "-- NO -- SE ELIMINARÁ EL CONSUMO DE ALIMENTOS, PARA SU MODIFICACIÓN FAVOR CONTACTAR A CONTABILIDAD", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If


                If EliminarLeche() = True Then
                    If MsgBox("DATOS ELIMINADOS --- OK ---" + vbCrLf + vbCrLf + "¿ DESEA MANTENER LA INFORMACIÓN EN PANTALLA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'End If

                        'If MsgBox("DATOS ELIMINADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                        ExisteIngresoLeche = False
                        BuscarIngresoLeche(IIf(rbtnAM.Checked = True, "AM", "PM"))

                        Exit Select
                    End If
                End If
                btnGrabar.Enabled = True
                btnEliminar.Enabled = False
            Case 1  'ASISTENCIA
                '........................................................................................................
                If MsgBox("¿ DESEA ELIMINAR LA -- ASISTENCIA -- ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If

                If EliminarAsistencia() = True Then
                    If MsgBox("DATOS ELIMINADOS --- OK ---" + vbCrLf + vbCrLf + "¿ DESEA MANTENER LA INFORMACIÓN EN PANTALLA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        ExisteIngresoAsistencia = False

                        btnGrabar.Enabled = True
                        btnEliminar.Enabled = False

                        For i As Integer = 0 To dgvAsistencia.Rows.Count - 1 : dgvAsistencia.Rows(i).Cells(ASIS_COL_HHEE).ReadOnly = False : Next       'habilitamos ingreso de hhee
                        Exit Select
                    End If
                End If

            Case 2  'RETIRO LECHE
                '........................................................................................................
                If chkSinRetiroLeche.Checked = False And GrabarOK = 0 Then
                    If dgvRetiroLeche.Rows.Count < 2 Then Exit Sub 'sitiene solo una linea salimos
                    If dgvRetiroLeche.CurrentRow.Index = (dgvRetiroLeche.Rows.Count - 1) Then Exit Sub 'si tiene
                End If


                If MsgBox("¿ DESEA ELIMINAR EL -- RETIRO DE LECHE -- ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
                If chkSinRetiroLeche.Checked = True And GrabarOK = 1 Then
                    If EliminarRetiroLecheSinRetiro() = True Then
                        If MsgBox("DATOS ELIMINADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                        End If
                    End If
                Else
                    If EliminarRetiroLeche() = True Then
                        If MsgBox("DATOS ELIMINADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                        End If
                    End If
                End If
                btnGrabar.Enabled = True
                btnEliminar.Enabled = True
            Case 3  'RIEGO DE PURINES
                '........................................................................................................
                If dgvRiegoPurines.Rows.Count < 1 Then Exit Sub 'sitiene solo una linea salimos


                If MsgBox("¿ DESEA ELIMINAR EL REGISTRO DE -- RIEGO -- ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If

                If EliminarRiegoPurines() = True Then
                    If MsgBox("DATOS ELIMINADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    End If
                End If
                btnGrabar.Enabled = True
                btnEliminar.Enabled = True
        End Select

    End Sub

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



            If dgvAsistencia.Rows(i).Cells(2).Value.ToString = "" Then
                If MsgBox(("Debe ingresar horas extras, en caso de no tener rellene con 0").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
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


            If (dgvAsistencia.Rows(i).Cells(2).Value.ToString <> "" And dgvAsistencia.Rows(i).Cells(2).Value.ToString <> "0") And
                            (dgvAsistencia.Rows(i).Cells(9).Value.ToString = "" Or dgvAsistencia.Rows(i).Cells(9).Value.ToString = "0") Then
                If MsgBox(("Debe seleccionar el --- motivo de las horas extras ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

                Exit Function
                'Exit For
            End If


            If (dgvAsistencia.Rows(i).Cells(2).Value.ToString = "" Or dgvAsistencia.Rows(i).Cells(2).Value.ToString = "0") And
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

        Dim listareal As Integer = 1
        Dim i As Integer
        Dim HayError As Boolean = False
        Dim hora, patente, chofer, cliente As String
        Dim guia As Integer
        Dim litros As Integer
        Dim temp As Double

        If dgvRetiroLeche.Rows.Count > 1 Then listareal = 2

        For i = 0 To dgvRetiroLeche.Rows.Count - listareal

            hora = dgvRetiroLeche.ToString2(i, RET_COL_HORA) 'dgvRetiroLeche.Rows(i).Cells(3).Value.ToString.Trim
            patente = dgvRetiroLeche.ToString2(i, RET_COL_PATENTE)
            guia = dgvRetiroLeche.ToInteger(i, RET_COL_GUIA)
            cliente = dgvRetiroLeche.ToString2(i, RET_COL_CLIENTECOD).Trim
            chofer = dgvRetiroLeche.ToString2(i, RET_COL_CHOFER)
            litros = dgvRetiroLeche.ToInteger(i, RET_COL_LITROS)
            temp = dgvRetiroLeche.ToDouble(i, RET_COL_TEMP)

            If ValidaHora(hora) = False Then
                dgvRetiroLeche.Rows(i).Cells(RET_COL_HORA).Style.BackColor = Color.LightGreen
                If MsgBox(("Formato de Hora incorrecto").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If patente = "" Then
                dgvRetiroLeche.Rows(i).Cells(RET_COL_PATENTE).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe Ingresar la --- Patente ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If guia = 0 Then
                dgvRetiroLeche.Rows(i).Cells(RET_COL_GUIA).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe ingresar el --- nro° de guía ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If cliente = "" Then
                dgvRetiroLeche.Rows(i).Cells(RET_COL_CLIENTECOD).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe Ingresar el --- Cliente ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If litros = 0 Then
                dgvRetiroLeche.Rows(i).Cells(RET_COL_LITROS).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe ingresar los --- Litros ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If temp = 0 Then
                dgvRetiroLeche.Rows(i).Cells(RET_COL_TEMP).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe Ingresar la --- Temperatura ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
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

    Private Function ValidaRiegoPurines() As Boolean
        ValidaRiegoPurines = False

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        Dim listareal As Integer = 1
        Dim i As Integer
        Dim HayError As Boolean = False
        Dim fec As Date
        Dim strfec, trespnom, respnom, tipnom, pots As String
        Dim cant, hects As Double


        If dgvRiegoPurines.Rows.Count > 1 Then listareal = 2

        For i = 0 To dgvRiegoPurines.Rows.Count - listareal
            strfec = dgvRiegoPurines.ToString2(i, RIEGO_COL_FECHA).Trim
            fec = dgvRiegoPurines.ToDate(i, RIEGO_COL_FECHA)
            'tresp = dgvRiegoPurines.ToString2(i, RET_COL_PATENTE)
            trespnom = dgvRiegoPurines.ToString2(i, RIEGO_COL_TIPORESPONSABLE).Trim
            respnom = dgvRiegoPurines.ToString2(i, RIEGO_COL_NOMRESPONSABLE).Trim
            'tip = dgvRiegoPurines.ToInteger(i, RET_COL_LITROS)
            tipnom = dgvRiegoPurines.ToString2(i, RIEGO_COL_TIPORIEGO).Trim
            cant = dgvRiegoPurines.ToDouble(i, RIEGO_COL_CANTIDAD)
            pots = dgvRiegoPurines.ToString2(i, RIEGO_COL_NROPOTREROS).Trim
            hects = dgvRiegoPurines.ToDouble(i, RIEGO_COL_SUPERFICIE)

            If strfec = "" Then
                'dgvRiegoPurines.Rows(i).Cells(RET_COL_HORA).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe ingresar la --- fecha ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If fec > Now() Then
                'dgvRiegoPurines.Rows(i).Cells(RET_COL_HORA).Style.BackColor = Color.LightGreen
                If MsgBox(("La fecha no puede ser --- mayor a la actual ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If


            If trespnom = "" Then
                'dgvRiegoPurines.Rows(i).Cells(RIEGO_COL_TIPORESPONSABLE).Style.BackColor = Color.LightGreen
                If MsgBox(("Debe seleccionar un --- TIPO DE RESPONSABLE ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                HayError = True
                Exit For
            End If

            If trespnom <> "SIN RIEGO" Then
                If respnom = "" Then
                    'dgvRiegoPurines.Rows(i).Cells(RET_COL_GUIA).Style.BackColor = Color.LightGreen
                    If MsgBox(("Debe ingresar el --- NOMBRE DEL RESPONSABLE ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    HayError = True
                    Exit For
                End If

                If tipnom = "" Then
                    'dgvRiegoPurines.Rows(i).Cells(RET_COL_CHOFER).Style.BackColor = Color.LightGreen
                    If MsgBox(("Debe seleccionar el --- tipo de riego ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    HayError = True
                    Exit For
                End If

                If cant = 0 Then
                    'dgvRiegoPurines.Rows(i).Cells(RET_COL_LITROS).Style.BackColor = Color.LightGreen
                    If MsgBox(("Debe ingresar la --- cantidad ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    HayError = True
                    Exit For
                End If

                If tipnom.Contains("ASPERCI") And cant > 24 Then
                    'dgvRiegoPurines.Rows(i).Cells(RET_COL_LITROS).Style.BackColor = Color.LightGreen
                    If MsgBox(("La cantidad no puede ser --- mayor a 24 hrs ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    HayError = True
                    Exit For
                End If

                If tipnom.Contains("CARRO") And cant < 1000 Then
                    'dgvRiegoPurines.Rows(i).Cells(RET_COL_LITROS).Style.BackColor = Color.LightGreen
                    If MsgBox(("La cantidad no puede ser --- menor 1.000 lts ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    HayError = True
                    Exit For
                End If

                If pots = "" Then
                    'dgvRiegoPurines.Rows(i).Cells(RET_COL_LITROS).Style.BackColor = Color.LightGreen
                    If MsgBox(("Debe seleccionar los --- potreros ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    HayError = True
                    Exit For
                End If

                If hects = 0 Then
                    'dgvRiegoPurines.Rows(i).Cells(RET_COL_TEMP).Style.BackColor = Color.LightGreen
                    If MsgBox(("Las hectareas deben tener un --- valor mayor a cero ---").ToUpper, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    HayError = True
                    Exit For
                End If
            End If
        Next

        If HayError Then
            'tmrColores.Enabled = True
            Exit Function
        End If

        ValidaRiegoPurines = True
    End Function


    Private Sub TxtDosis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDosis.Click
        TxtDosis.SelectAll()
    End Sub

    Private Sub TxtDosis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDosis.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnGrabar.Focus()
            Exit Sub
        End If

        Dim caracter As Char = e.KeyChar
        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub InicializaVariablesCombosAsistencia()
        SelectRowCellEstado = -1
        SelectColCellEstado = -1
        SelectRowCellMotivoHE = -1
        SelectColCellMotivoHE = -1
    End Sub

    Private Sub InicializaVariablesCombosRetLeche()
        SelectRowCellCliente = -1
        SelectColCellCliente = -1
    End Sub

    Private Sub Asistencia_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsistencia.CellClick
        If dgvAsistencia.RowCount = 0 Then Exit Sub

        Dim columna As Integer = dgvAsistencia.CurrentCell.ColumnIndex
        Dim linea As Integer = dgvAsistencia.CurrentCell.RowIndex

        ''CON ESTO HACEMOS QUE AL HACER UN CLICK EN EL COMBO BOX, MOSTRAMOS LA LISTA
        If columna = ASIS_COL_NOMENCLATURA Then
            If linea <> SelectRowCellEstado Or columna <> SelectColCellEstado Then
                dgvAsistencia.BeginEdit(True)
                SendKeys.Send("{F4}")
                SelectRowCellEstado = linea
                SelectColCellEstado = columna
            End If
        End If

        If columna = ASIS_COL_MOTIVOHHEE Then
            If linea <> SelectRowCellMotivoHE Or columna <> SelectColCellMotivoHE Then
                'dgvAsistencia.CurrentCell.Selected = True '.BeginEdit(True)
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
        'If col = 2 Or col = 3 Or col = 4 Or col = 5 Or col = 6 Or col = 7 Then
        If col = ASIS_COL_HHEE Or col = ASIS_COL_BLEÑA Or col = ASIS_COL_BPODAL Or col = ASIS_COL_BCOLACION Or col = ASIS_COL_BRESPONS Or col = ASIS_COL_BOTROS Then
            Dim validarn As TextBox = CType(ea.Control, TextBox)
            AddHandler validarn.KeyPress, AddressOf validar_text
        End If

        'valida selectindex combobox nomenclaturas
        If col = ASIS_COL_NOMENCLATURA Then
            Dim editingComboBox As ComboBox = ea.Control
            AddHandler editingComboBox.SelectedIndexChanged, AddressOf CambiaOpcionComboAsistencia
        End If
    End Sub

    Private Sub validar_text(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim col As Integer = dgvAsistencia.CurrentCell.ColumnIndex

        ' comprobar si la celda en edición corresponde a la columna 1 o 2   
        'If columna = 2 Or columna = 3 Or columna = 4 Or columna = 5 Or columna = 6 Or columna = 7 Then
        If col = ASIS_COL_HHEE Or col = ASIS_COL_BLEÑA Or col = ASIS_COL_BPODAL Or col = ASIS_COL_BCOLACION Or col = ASIS_COL_BRESPONS Or col = ASIS_COL_BOTROS Then
            ' Obtener caracter   
            Dim caracter As Char = e.KeyChar

            If col = ASIS_COL_HHEE Then
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
                    e.KeyChar = Chr(0)
                    'Else
                    'SumaHHEE()
                End If
            Else
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    e.KeyChar = Chr(0)
                    'Else
                    'SumaHHEE()
                End If
            End If
        End If
    End Sub

    Private Sub CambiaOpcionComboAsistencia(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim col As Integer = dgvAsistencia.CurrentCell.ColumnIndex
        If col <> ASIS_COL_NOMENCLATURA Then Exit Sub

        Dim cbCell As ComboBox = CType(sender, ComboBox)
        Dim txtCell As DataGridViewTextBoxCell = Me.dgvAsistencia.CurrentRow.Cells(ASIS_COL_HHEE)

        If Not cbCell.Text.Contains("Trabajado") Then
            txtCell.Value = "0"
            txtCell.ReadOnly = True
        Else
            txtCell.ReadOnly = False
        End If
    End Sub

    Private Sub btnTraslados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrasladosFuncionarios.Click
        If cboCentros.SelectedIndex = -1 Then Exit Sub


        frmTrasladoPersonal.Param1_Centro = CentroCod
        frmTrasladoPersonal.Param2_Fecha = dtpFecha.Text
        frmTrasladoPersonal.Param3_Horario = IIf(rbtnAM.Checked = True, 1, 2)
        frmTrasladoPersonal.MdiParent = frmMAIN
        frmTrasladoPersonal.Show()
        frmTrasladoPersonal.BringToFront()
    End Sub

    Private Sub btnHorarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHorarios.Click
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


    Private Sub BuscarIngresoLeche(ByVal Horario As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_BuscarIngresoLeche", con) With {
            .CommandType = Data.CommandType.StoredProcedure
        }

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(Horario = "AM", 1, 2))

        con.Open()
        Dim rdr As SqlDataReader = cmd.ExecuteReader()

        'siempre existe un registro, que devuleve los litros totales diarios, la temperatura...
        'y antes del resultado limpiamos todo la pestaña de ingreso de leche
        LimpiaGrillaLecheEnc()

        While rdr.Read()
            StockVacas = rdr("StockVacas").ToString.Trim
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
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
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
        Dim Temperatura As Integer = 0
        Dim Temperatura2 As Integer = 0
        Dim UsuarioReg As String = ""
        Dim FechaReg As String = ""
        Dim h1 As String = ""
        Dim h2 As String = ""
        Dim TotCojOrd As String = ""

        While rdr.Read()
            Temperatura = rdr("Temperatura").ToString.Trim
            Temperatura2 = rdr("Temperatura2").ToString.Trim
            h1 = rdr("HoraTermino").ToString.Trim
            h2 = rdr("HoraTemperatura").ToString.Trim
            TotCojOrd = rdr("TotalCojasOrd").ToString.Trim
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
        txtTotCojasOrd.Text = TotCojOrd

        ExisteIngresoLeche = True

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub BuscarConcentrado(ByVal Horario As String)
        ExisteIngresoConcentrado = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConcentrado_BuscarGP", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Horario", IIf(Horario = "AM", 1, 2))

        dgvConcentrado.SuspendLayout()
        dgvConcentrado2.SuspendLayout()
        dgvConcentrado.Rows.Clear()
        dgvConcentrado2.Rows.Clear()

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If rdr("ConTipocod").ToString.Trim = "1" Then
                        dgvConcentrado.Rows.Add(rdr("IteNom").ToString.Trim, Format(rdr("ConStockAct"), "#,#0"), Format(rdr("ConTotCantidad"), "#,#0.00"), Format(rdr("ConTotVacas"), "#,#0"), Format(rdr("totalporvaca"), "#,#0.00"), rdr("ProdCodigo").ToString.Trim, rdr("ProdCuenta").ToString.Trim, rdr("ProdItemGasto").ToString.Trim, rdr("UM").ToString.Trim)
                    Else
                        dgvConcentrado2.Rows.Add(rdr("IteNom").ToString.Trim, Format(rdr("ConStockAct"), "#,#0"), Format(rdr("ConTotCantidad"), "#,#0.00"), Format(rdr("ConTotVacas"), "#,#0"), Format(rdr("totalporvaca"), "#,#0.00"), rdr("ProdCodigo").ToString.Trim, rdr("ProdCuenta").ToString.Trim, rdr("ProdItemGasto").ToString.Trim, rdr("UM").ToString.Trim)
                    End If

                    ExisteIngresoConcentrado = True
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        dgvConcentrado.ResumeLayout()
        dgvConcentrado2.ResumeLayout()

SalirProc:
    End Sub

    Private Sub Txttemp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTempEst1.KeyPress, TxtTempEst2.KeyPress
        Dim text As TextBox = DirectCast(sender, TextBox)

        If e.KeyChar = ChrW(Keys.Enter) Or e.KeyChar = ChrW(Keys.Tab) Then
            If text.Name.Contains("TxtTempEst1") Then
                If TxtTempEst2.Enabled = True Then
                    TxtTempEst2.Focus()
                Else
                    txtTempHora.Focus()
                End If

                Exit Sub
            Else
                txtTempHora.Focus()
                Exit Sub
            End If
        End If

        Dim caracter As Char = e.KeyChar

        If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub


    'COMIENZO PROGRAMACION GRAFICOS
    Private Sub GraficosLeche()
        'leyendas de los grafico leche
        ChartLeche.Series("Series1").LegendText = "PLANTA"
        ChartLeche.Series("Series2").LegendText = "PROYECTADO"
    End Sub
    Private Sub GraficosAsistencia()
        'grafico horas extras
        ConsultaGraficoHorasExtras(CentroCod, dtpFecha.Value.Year, 1)
        ConsultaGraficoHorasExtras(CentroCod, dtpFecha.Value.Year - 1, 2)
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

        txtTotCojasOrd.Text = "0"

        LitrosPlanta.Text = "0"
        LitrosTerneros.Text = "0"
        LitrosCalostro.Text = "0"
        LitrosAntibioticos.Text = "0"
        LitrosMala.Text = "0"
        LitrosCojas.Text = "0"

        VacasPlanta.Text = "0"
        VacasTerneros.Text = "0"
        VacasCalostro.Text = "0"
        VacasAntibioticos.Text = "0"
        VacasMalas.Text = "0"
        VacasCojas.Text = "0"

        lbTotLitros.Text = "0"
        LbTotVacas.Text = "0"
        LbTotLtVacas.Text = "0"

    End Sub

    Private Sub tabIngresos_Deselected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tabFormulario.Deselected
        If e.TabPageIndex = 0 Then GuardaUltHorarioQueryLeche = IIf(rbtnAM.Checked = True, 1, 2)
    End Sub


    Private Sub tabIngresos_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles tabFormulario.Selected
        If e.TabPageIndex = 0 Then
            If GuardaUltHorarioQueryLeche = 1 Then
                rbtnAM.Checked = True
                rbtnPM.Checked = False
            Else
                rbtnAM.Checked = False
                rbtnPM.Checked = True
            End If
        End If
    End Sub


    Private Sub tabIngresos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabFormulario.SelectedIndexChanged

        If tabFormulario.SelectedTab Is Nothing Then Exit Sub

        TabuladorFormulario(EnEventoLoad)
    End Sub




    Private Function ValidaHora(ByVal text As String) As Boolean
        ValidaHora = False

        If text <> "" Then
            Try
                Dim hr As DateTime = DateTime.Parse(Format(Now, "dd-MM-yyyy") + " " + text)

                If Not IsDate(hr) Then Exit Function
                If text.Length = 5 Then ValidaHora = True

            Catch ex As Exception

            End Try
        End If
    End Function

    Private Sub dgvAsistencia_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsistencia.CellEnter
        'If e.ColumnIndex = 2 Then
        Dim tothh As Double

        For i As Integer = 0 To dgvAsistencia.Rows.Count - 1
            If Not dgvAsistencia.Rows(i).Cells(ASIS_COL_HHEE).Value Is Nothing Then
                If dgvAsistencia.Rows(i).Cells(ASIS_COL_HHEE).Value <> "" Then
                    tothh = tothh + Double.Parse(dgvAsistencia.Rows(i).Cells(ASIS_COL_HHEE).Value)
                End If
            End If
        Next

        lblTotHrsExtras.Text = tothh
        InicializaVariablesCombosAsistencia()
    End Sub

    Private Sub dgvAsistencia_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAsistencia.RowEnter
        InicializaVariablesCombosAsistencia()
    End Sub

    Private Sub btnVBTarja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVBTarja.Click
        With frmVBTarja

            .Param1_Centro = CentroCod

            .ShowDialog()

        End With
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
            frptTarjaElectronica.CentroCod = CentroCod
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
            txtTotCojasOrd.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtTotCojasOrd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotCojasOrd.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            dgvConcentrado.Focus()
            dgvConcentrado.Rows(0).Cells(2).Selected = True
            Exit Sub
        End If
    End Sub

    Private Sub txtHoraTermino_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHoraTermino.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            LitrosPlanta.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub btnAdminVBTarja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminVBTarja.Click
        With frmAdminCierresTarja
            .Show()
            .cboCentros.Text = cboCentros.Text
        End With
    End Sub
    Private Sub BuscarBolo(ByVal nombre As String)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spConcentrado_Factorizacion", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@CodConcentrado", nombre)

            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                Bolo = rdr("Kilos").ToString.Trim
            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub CalculoConcentradoPorAnimal(ByVal rr As Integer)
        Dim vacas As Double = 0
        Dim cant As Double = 0
        Dim cant_x_vaca As Double = 0
        Dim ConcentradoKilos As Double = 0

        Try 'Concentrado
            vacas = GrillaConcentrado.ToDouble(rr, CONS_COL_NROVACAS)
            cant = GrillaConcentrado.ToDouble(rr, CONS_COL_CANTIDAD)

            BuscarBolo(GrillaConcentrado.Item(5, GrillaConcentrado.CurrentRow.Index).Value)
            If Bolo > 0 And vacas <> 0 Then
                cant_x_vaca = (cant * Bolo) / vacas
            Else
                cant_x_vaca = IIf(vacas = 0, 0, cant / vacas)
            End If
            'Select Case GrillaConcentrado.Rows(rr).Cells(5).Value
            '    Case "210060001"
            '        cant = cant * 10000
            '    Case "210060003"
            '        cant = cant * 21000
            '    Case "210060004"
            '        cant = cant * 12000
            '    Case "210060005"
            '        cant = cant * 10000
            'End Select

            'cant_x_vaca = IIf(IsNumeric(cant / (IIf(vacas = 0, 1, vacas))) = True, (cant / IIf(vacas = 0, 1, vacas)), 0)

        Catch ex As Exception
            vacas = 0
            cant = 0
            cant_x_vaca = 0
        End Try
        ' IIf(IsNumeric(cant_x_vaca) = True, cant_x_vaca, 0)

        If cant_x_vaca > 0 Then
            GrillaConcentrado.Rows(rr).Cells(CONS_COL_CANTPORVACA).Value = Format(cant_x_vaca, "#,#0.00")
        Else
            GrillaConcentrado.Rows(rr).Cells(CONS_COL_CANTPORVACA).Value = ""
        End If

    End Sub

    Private Sub dgvConcentrado_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvConcentrado.EditingControlShowing, dgvConcentrado2.EditingControlShowing
        Dim col As Integer = sender.CurrentCell.ColumnIndex

        GrillaConcentrado = sender

        'valida keypress
        If col = 2 Or col = 3 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtConcentrado
        End If
    End Sub

    Private Sub ValidaTxtConcentrado(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = GrillaConcentrado.CurrentCell.ColumnIndex

        If columna = 2 Or columna = 3 Then
            If Not Char.IsNumber(e.KeyChar) And e.KeyChar <> "," And (e.KeyChar = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub

    Private Sub dgvConcentrado_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConcentrado.CellEndEdit, dgvConcentrado2.CellEndEdit
        If sender.CurrentCell.ColumnIndex = 2 Or sender.CurrentCell.ColumnIndex = 3 Then
            CalculoConcentradoPorAnimal(sender.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub dgvRiegoPurines_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvRiegoPurines.RowPrePaint
        If e.RowIndex >= 0 Then
            dgvRiegoPurines.Rows(e.RowIndex).Cells(RIEGO_COL_LINEA).Value = e.RowIndex + 1
        End If
    End Sub

    Private Sub dgvRiegoPurines_EditingControlShowing(ByVal sender As Object, ByVal ea As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRiegoPurines.EditingControlShowing
        ''referencia a la celda   
        Dim col As Integer = dgvRiegoPurines.CurrentCell.ColumnIndex

        If col = RIEGO_COL_CANTIDAD Then
            AddHandler CType(ea.Control, TextBox).KeyPress, AddressOf ValidaCantRiego
        End If
    End Sub

    Private Sub ValidaCantRiego(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvRiegoPurines.CurrentCell.ColumnIndex

        If columna = RIEGO_COL_CANTIDAD Then ' 6 
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub

    Private Sub mnuSelPotreros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSelPotreros.Click
        With frmPurinesSeleccionPotreros
            .Param1_CentroCodigo = CentroCod
            .Param2_CentroNombre = cboCentros.Text

            .ShowDialog()
        End With
    End Sub

    Private Sub btnAgregarRiego_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarRiego.Click
        With frmPurinesSeleccionPotreros
            .Param1_CentroCodigo = CentroCod
            .Param2_CentroNombre = cboCentros.Text
            .Param3_CentroIsShareMilker = General.CentrosUsuario.EsSharedMilker(cboCentros.SelectedIndex)

            .ShowDialog()
        End With

    End Sub



    Public Function LVToDataTableConsumosConcentrado() As DataTable
        LVToDataTableConsumosConcentrado = Nothing
        Dim table As DataTable = New DataTable("TablaDetalle")

        table.Columns.Add("CodProducto", System.Type.GetType("System.String"))
        table.Columns.Add("NomProducto", System.Type.GetType("System.String"))
        table.Columns.Add("Cantidad", System.Type.GetType("System.Double"))
        table.Columns.Add("Cuenta", System.Type.GetType("System.String"))
        table.Columns.Add("ItemGasto", System.Type.GetType("System.String"))        'GetType(Integer)
        table.Columns.Add("Patente", System.Type.GetType("System.String"))
        table.Columns.Add("Observs", System.Type.GetType("System.String"))

        Dim itm_c1, itm_c2 As DataGridViewRow
        Dim cant1, NroVacas1, cant2, NroVacas2 As Double
        Dim prod2 As String
        Dim ExisteEnGrilla2 As Boolean


        'recorremos la primera grilla, concentrado vacas en ordeña
        For i As Integer = 0 To dgvConcentrado.Rows.Count - 1
            itm_c1 = dgvConcentrado.Rows(i)
            cant1 = IIf(itm_c1.Cells(2).Value.ToString.Trim <> "", itm_c1.Cells(2).Value, 0)
            NroVacas1 = IIf(itm_c1.Cells(3).Value.ToString.Trim <> "", itm_c1.Cells(3).Value, 0)

            If cant1 > 0 And NroVacas1 > 0 Then
                table.Rows.Add(itm_c1.Cells(5).Value, itm_c1.Cells(0).Value,
                               (cant1), itm_c1.Cells(6).Value,
                               itm_c1.Cells(7).Value, "", "")

            End If
        Next


        'recorremos la segunda grilla, concentrado vacas pre-parto
        For i As Integer = 0 To dgvConcentrado2.Rows.Count - 1
            itm_c2 = dgvConcentrado2.Rows(i)
            prod2 = itm_c2.Cells(5).Value
            cant2 = IIf(itm_c2.Cells(2).Value.ToString.Trim <> "", itm_c2.Cells(2).Value, 0)
            NroVacas2 = IIf(itm_c2.Cells(3).Value.ToString.Trim <> "", itm_c2.Cells(3).Value, 0)
            ExisteEnGrilla2 = False

            If cant2 > 0 And NroVacas2 > 0 Then
                For Each row As DataRow In table.Rows

                    If row("CodProducto") = prod2 Then
                        row("Cantidad") = row("Cantidad") + cant2
                        ExisteEnGrilla2 = True
                        Exit For
                    End If

                Next



                If ExisteEnGrilla2 = False Then
                    table.Rows.Add(itm_c2.Cells(5).Value, itm_c2.Cells(0).Value,
                                   (cant2), itm_c2.Cells(6).Value,
                                   itm_c2.Cells(7).Value, "", "")
                End If
            End If
        Next


        LVToDataTableConsumosConcentrado = table
    End Function

    Public Function ListViewToDataTable(ByVal DGV As ListView) As System.Data.DataTable
        ListViewToDataTable = Nothing

        Dim table As System.Data.DataTable = New System.Data.DataTable("TablaDetalle")

        table.Columns.Add("VDetDiio", System.Type.GetType("System.Decimal"))
        table.Columns.Add("VDetCategoria", System.Type.GetType("System.String"))
        table.Columns.Add("VDetEstProductivo", System.Type.GetType("System.String"))
        table.Columns.Add("VDetEstReproductivo", System.Type.GetType("System.String"))
        table.Columns.Add("VDetTipoVenta", System.Type.GetType("System.Decimal"))        'GetType(Integer)
        table.Columns.Add("VDetCausal", System.Type.GetType("System.Decimal"))
        table.Columns.Add("VDetVeterinario", System.Type.GetType("System.Decimal"))
        table.Columns.Add("VDetNroCertific", System.Type.GetType("System.Decimal"))

        For Each itm As ListViewItem In DGV.Items

            table.Rows.Add(itm.SubItems(0).Text, itm.SubItems(3).Text,
                           "", "",
                           0, 0,
                           0, 0)

        Next

        ListViewToDataTable = table

    End Function
    Private Function ActualizarRemples() As Boolean
        ActualizarRemples = False

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spBUK_FuncionariosActivos_Pagination", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        cmd.CommandTimeout = 30000
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            Else
                pbProcesa.Value = 50
                If PeriodosPagination() = True Then
                    ActualizarRemples = True
                    pbProcesa.Value = 75
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 140)")
        End Try
    End Function
    Private Function PeriodosPagination() As Boolean
        PeriodosPagination = False

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spBUK_FuncionariosActivos_Pagination", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        cmd.CommandTimeout = 30000
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            PeriodosPagination = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 140)")
        End Try
    End Function
    Private Sub btnReproce_Click(sender As Object, e As EventArgs) Handles btnReproce.Click
        Cursor.Current = Cursors.WaitCursor

        lblProcesa.Text = "SINCRONIZACION CON BUK, ESPERE UN MOMENTO POR FAVOR..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 100
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()
        pbProcesa.Value = 25
        If ActualizarRemples() = True Then
            If ActualizarDesdeBuk() = True Then
                pbProcesa.Value = 100
                If MsgBox("SINCRONIZACION CON BUK, REALIZADO CORRECTAMENTE.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                End If
            End If
        End If
        pnlProcesa.Visible = False
        Cursor.Current = Cursors.Default
    End Sub
    Private Function ActualizarDesdeBuk() As Boolean
        ActualizarDesdeBuk = False

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spFuncionarios_ActualizacionDesdeBUK", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        cmd.CommandTimeout = 30000
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            ActualizarDesdeBuk = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 140)")
        End Try
    End Function
    Private Sub ToolTipText()
        Dim Textreprocesa As String
        Textreprocesa = "Actualiza los funcionarios del SGL con los datos que se encuentran en BUK. (Agrega nuevos funcionarios, Actualiza Fecha de Ingreso, Fecha de Retiro y Emails)”
        ToolTip1.SetToolTip(btnReproce, Textreprocesa)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSinRetiroLeche.CheckedChanged
        If chkSinRetiroLeche.Checked = True Then
            dgvRetiroLeche.Rows.Clear()
            lblNroRetiros.Text = 0
            lblTotLtsRetiradosDia.Text = 0
            lblTotLtsRetiradosMes.Text = 0
            dgvRetiroLeche.Enabled = False
        Else
            dgvRetiroLeche.Enabled = True
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles tabFormulario.SelectedIndexChanged

        If tabFormulario.SelectedIndex <> 2 Then
            If chkSinRetiroLeche.Checked = True And GrabarOK = 0 Then
                MsgBox("PARA REGISTRAR EL NO RETIRO DE LECHE, ANTES GRABAR ")

            End If
        End If

        'If CheckBox1.Checked = True Then
        '    dgvRetiroLeche.Enabled = False
        'End If

    End Sub
    Private Function GrabarSinRetiro() As Boolean
        GrabarSinRetiro = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spLeche_GrabarRetiros", con)
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE RETIRO
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 145)")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean

        Dim hora, patente, patente_nueva, chofer, observs, ClienteCod, ClienteNom As String
        Dim guia, guia_nueva, litros, temp, palcohol, verde, amarillo, rojo, azul As Integer

        patente = 0
        guia = 0
        ''
        hora = 0
        patente_nueva = 0
        guia_nueva = 0
        ClienteCod = 0
        ClienteNom = ""
        ''
        litros = 0
        temp = 0
        ''
        palcohol = 0
        verde = 0
        amarillo = 0
        rojo = 0
        azul = 0
        ''
        observs = "Sin Retiro de Leche para el día seleccionado"
        chofer = 0

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Commit", 0)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Transporte", patente)
        cmd.Parameters.AddWithValue("@NroGuia", guia)
        cmd.Parameters.AddWithValue("@Chofer", chofer)
        cmd.Parameters.AddWithValue("@Clientecod", ClienteCod.Trim)
        cmd.Parameters.AddWithValue("@ClienteNom", ClienteNom.Trim)
        cmd.Parameters.AddWithValue("@Hora", Now.TimeOfDay)
        cmd.Parameters.AddWithValue("@TransporteNuevo", patente_nueva)
        cmd.Parameters.AddWithValue("@NroGuiaNuevo", guia_nueva)
        cmd.Parameters.AddWithValue("@Litros", litros)
        cmd.Parameters.AddWithValue("@Temperatura", temp)
        cmd.Parameters.AddWithValue("@PruebaOX", palcohol)
        cmd.Parameters.AddWithValue("@Verde", verde)
        cmd.Parameters.AddWithValue("@Amarillo", amarillo)
        cmd.Parameters.AddWithValue("@Rojo", rojo)
        cmd.Parameters.AddWithValue("@Azul", azul)
        cmd.Parameters.AddWithValue("@Observs", observs)
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

            End If

            HayError = False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 150)")
            HayError = True

        End Try


        'si hay error hasta aqui salimos
        If HayError = False Then
            SRVTRANS.Commit()
            GrabarSinRetiro = True
            ExisteIngresoRetiro = True
        Else
            SRVTRANS.Rollback()
            GrabarSinRetiro = False
            ExisteIngresoRetiro = False
        End If
        con.Close()
        Cursor.Current = Cursors.Default
    End Function

    Public Function ConsultaStockConcentrado(ByVal dgvConcentrado As DataGridView) As String
        ConsultaStockConcentrado = False

        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConsultarStock_Concentrado", con)
        Dim ContenidoConcentrado As DataTable = DataGVConcentrado(dgvConcentrado)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@DTConcentrado", ContenidoConcentrado)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            cmd.ExecuteNonQuery()
            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value
            con.Close()

            If ResultCod <> 0 Then
                Select Case MsgBox(ResultMsg + ". DESEA CONTINUAR?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "ADVERTENCIA")
                    Case MsgBoxResult.Ok
                        ConsultaStockConcentrado = True
                    Case MsgBoxResult.Cancel
                        btnGrabar.Enabled = True
                        Exit Function
                End Select
            End If
            ConsultaStockConcentrado = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA.")
            btnGrabar.Enabled = True
        End Try
    End Function

    Public Function DataGVConcentrado(ByVal dgvConcentrado As DataGridView) As DataTable

        Dim dt As New DataTable
        Dim columna As DataRow

        dt.Columns.Add("ConcentradoKlXVaca", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("ConcentradoCodigo", System.Type.GetType("System.String"))

        For i = 0 To dgvConcentrado.Rows.Count - 1
            Dim KxV As String = dgvConcentrado.Rows(i).Cells(4).Value
            columna = dt.NewRow

            If KxV = "" Then
                KxV = 0
            End If
            columna("ConcentradoKlXVaca") = KxV
            columna("ConcentradoCodigo") = dgvConcentrado.Rows(i).Cells(5).Value
            dt.Rows.Add(columna)
        Next

        DataGVConcentrado = dt

    End Function
    Private Function RecepcionMaterialesPendientes(ByVal evento As String) As Boolean
        RecepcionMaterialesPendientes = False
        Dim ResultCod As Integer
        Dim ResultMsg As String

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConsultaRecepcionPendiente", con)
        Dim ContenidoConcentrado As DataTable = DataGVConcentrado(dgvConcentrado)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Evento", evento)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            cmd.ExecuteNonQuery()
            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value
            con.Close()

            If ResultCod <> 0 Then
                If evento = 1 Then
                    MsgBox(ResultMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ADVERTENCIA")
                Else
                    MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA")
                End If
                lblPendienteRecepcion.Text = ResultMsg
                RecepcionMaterialesPendientes = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA.")
        End Try
        Return RecepcionMaterialesPendientes
    End Function
End Class