Imports System.Data.SqlClient
Imports System.IO
Public Class frmLogin

    Private Function ValidarUsuario(ByVal EmpresaCod As Integer, ByVal UsuarioCod As String, ByVal Clave As String) As Boolean
        ValidarUsuario = False

        If UsuarioCod.Trim = "" Then
            If MsgBox("Debe ingresar el nombre de usuario", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "MANUKA SGL") = vbOK Then
            End If
            txtUsuario.Focus()
            Exit Function
        End If

        If Clave.Trim = "" Then
            If MsgBox("Debe ingresar la clave usuario", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "MANUKA SGL") = vbOK Then
            End If
            txtClave.Focus()
            Exit Function
        End If


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuario_Login", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        '
        cmd.Parameters.AddWithValue("@EmpresaCod", EmpresaCod)
        cmd.Parameters.AddWithValue("@UsuarioCod", UsuarioCod)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Clave", Clave)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage2", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage2").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetPerfil", SqlDbType.Int) : cmd.Parameters("@RetPerfil").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetPerfilNom", SqlDbType.VarChar).Size = 50 : cmd.Parameters("@RetPerfilNom").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetCierraXLS", SqlDbType.Int) : cmd.Parameters("@RetCierraXLS").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetEliminaCierre", SqlDbType.Int) : cmd.Parameters("@RetEliminaCierre").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetConfirmaAjuste", SqlDbType.Int) : cmd.Parameters("@RetConfirmaAjuste").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetDia", SqlDbType.Int) : cmd.Parameters("@RetDia").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetAdminConcent", SqlDbType.Int) : cmd.Parameters("@RetAdminConcent").Direction = ParameterDirection.Output
        ' cmd.Parameters.Add("@RetEliminaInduccion", SqlDbType.VarChar).Size = 50 : cmd.Parameters("@RetEliminaInduccion").Direction = ParameterDirection.Output

        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage2").Value
            Dim perf As Integer = cmd.Parameters("@RetPerfil").Value
            Dim pnom As String = cmd.Parameters("@RetPerfilNom").Value
            Dim ucxls As String = cmd.Parameters("@RetCierraXLS").Value
            Dim uec As String = cmd.Parameters("@RetEliminaCierre").Value
            Dim uca As String = cmd.Parameters("@RetConfirmaAjuste").Value
            Dim adco As Integer = cmd.Parameters("@RetAdminConcent").Value
            Dim dias As Integer = cmd.Parameters("@RetDia").Value
            ' Dim Induc As String = cmd.Parameters("@RetEliminaInduccion").Value
            'Dim ElimDiio As Integer = cmd.Parameters("@UsrElimDiioBaston").Value
            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "MANUKA SGL") = vbOK Then
                End If
                Exit Function
            End If

            LoginUsuario = UsuarioCod
            PerfilUsuario = perf
            NombrePerfilUsuario = pnom
            UsuarioCierraXLS = ucxls
            UsuarioEliminaCierre = uec
            UsuarioConfirmaAjuste = uca
            UsuarioAdminConcentrado = adco
            ModificarDiasBaston = dias
            ' EliminaParto = Induc

            ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL")
        End Try
    End Function

    Private Sub IniciarSesionUsuario()

        WriteFileUser(MyFileConfig, "USUARIO", "UserEmp", CboEmpresa.Text.Trim)
        WriteFileUser(MyFileConfig, "USUARIO", "UserCod", txtUsuario.Text.Trim)

        lblCargando.Text = "Temporadas..." : lblCargando.Refresh() : General.Temporadas.Cargar()
        lblCargando.Text = "Centros..." : lblCargando.Refresh() : General.Centros.Cargar()
        lblCargando.Text = "Centros Traslado..." : lblCargando.Refresh() : General.TrlsGnd_ListadoCentros.Cargar()
        lblCargando.Text = "Centros Traslado RC..." : lblCargando.Refresh() : General.TrlsGnd_ListadoCentrosRecepcion.Cargar()
        lblCargando.Text = "Centros de Usuario..." : lblCargando.Refresh() : General.CentrosUsuario.Cargar()
        lblCargando.Text = "Centros de Usuario..." : lblCargando.Refresh() : General.CentrosUsuario2.Cargar()

        ''PARA PANTALLAS DE CONSULTAS - TODOS LOS CENTROS, INCLUIDOS LOS CENTROS DE TIPO ADMINISTRATIVOS
        MSTRUsuarios.Usuario_Centros_Frm_QRY(txtUsuario.Text.Trim, False)
        DTUsuarioCentrosFrmQRY = MSTRUsuarios.GETData

        ''GUARDA EL CENTRO DEFAULT EN 2 VARIABLES PUBLICAS
        For i As Integer = 0 To DTUsuarioCentrosFrmQRY.Rows.Count - 1
            If DTUsuarioCentrosFrmQRY.Rows(i).Item("CenDefault").ToString.Trim = "S" Then
                UsuarioCentroCodDefault = DTUsuarioCentrosFrmQRY.Rows(i).Item("CentroCod").ToString.Trim
                UsuarioCentroNomDefault = DTUsuarioCentrosFrmQRY.Rows(i).Item("CentroNom").ToString.Trim
                Exit For
            End If
        Next
        If UsuarioCentroCodDefault = 0 Then
            If MsgBox("SU USUARIO NO CUENTA CON UN CENTRO DEFAULT. CONTACTE A IT.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "MANUKA SGL") = vbOK Then
            End If
        End If
        ''      File.Copy("\\srvsql2\MNK_PROD\Software\Manuka SGL\NDAgroComm.dll", Directory.GetCurrentDirectory() + "\NDAgroComm.dll", True)

        With frmMAIN
            .SuspendLayout()

            .Text = "MANUKA SGL - Sistema Gestion de Ganado & Lechería - [" + CboEmpresa.Text + " // " + NombrePerfilUsuario + " // " + LoginUsuario + " // " + cboConeccion.Text + "]"


            '.pnlBarra.Visible = True

            '.pnlMenu.Visible = True
            .pnlMenu.Visible = True

            .btnCerrarSesion.Visible = True
            .btnPanelConsulta.Visible = True
            .btnHerramientas.Visible = False

            .btnCerrarSesion.Left = .Width - .btnCerrarSesion.Width - 20
            .btnPanelConsulta.Left = .Width - .btnCerrarSesion.Width - .btnPanelConsulta.Width - 20
            .btnHerramientas.Left = .Width - .btnCerrarSesion.Width - .btnPanelConsulta.Width - .btnHerramientas.Width - 20

            .lblTitCentro.Visible = True
            .lblCentro.Visible = True
            .lblTitDIIO.Visible = True
            .txtDIIO.Visible = True
            .btnBuscaDIIO.Visible = True
            .btnActualizaciones.Visible = True
            .btnPanelConsulta.Visible = True
            .btnCerrarSesion.Visible = True
            .btnTablero.Visible = True

            .lblCentro.Text = UsuarioCentroNomDefault ' NombreCentroUsuario

            .CargaMenuPrincipal(LoginUsuario, IdiomaSistema)

            .ResumeLayout()
        End With
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Application.Exit()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Cursor.Current = Cursors.WaitCursor
        Dim ret As String
        ret = ""
        Select Case cboConeccion.Text
            Case "MANUKA"
                LOGIN_CONEXION = "MANUKA"
                SRV_Servidor = "SRVMNK"

            Case "LOCAL"
                LOGIN_CONEXION = "LOCAL"
                SRV_Servidor = "127.0.0.1"
            Case "TEST"
                LOGIN_CONEXION = "TEST"
                SRV_Servidor = "MNK-OSO-QA"
        End Select

        Dim EmpresaCod As Integer = General.Empresas.EmpresaCod(CboEmpresa.SelectedIndex)

        If ValidarUsuario(EmpresaCod, txtUsuario.Text, Encripta(txtClave.Text, "E", ret)) = True Then
            lblCargando.Visible = True
            lblCargando.Refresh()

            IniciarSesionUsuario()

            txtUsuario.Text = ""
            txtClave.Text = ""
            lblCargando.Text = ""

            Cursor.Current = Cursors.WaitCursor

            Me.Close()

            'cualquier perfil menos el admin rrhh y torre control, puede ver mensajes
            If PerfilUsuario <> 6 And PerfilUsuario <> 8 Then
                'frmMensajesOLD.MdiParent = frmMAIN
                'frmMensajesOLD.Show()
                'frmMensajesOLD.BringToFront()

            Else
                frmMAIN.lblHideShowMenu.Enabled = False
            End If


            With frmMAIN
                .btnBuscaDIIO.Visible = True
                .txtDIIO.Visible = True
                .lblTitDIIO.Visible = True

                .btnTablero.Visible = True
                .btnPanelConsulta.Visible = True

                .Panel2.Visible = True
                .pnlBuscarGrupo.Visible = True
            End With


            Select Case PerfilUsuario
                Case 2  'si es una administrador de sala, entonces mostramos ingreso leche al inicio
                    frmIngresoDiario.MdiParent = frmMAIN
                    frmIngresoDiario.Show()
                    frmIngresoDiario.BringToFront()

                Case 6, 8 'si es administrador RRHH o torre control
                    With frmMAIN
                        .btnBuscaDIIO.Visible = False
                        .txtDIIO.Visible = False
                        .lblTitDIIO.Visible = False

                        .btnTablero.Visible = False
                        .btnPanelConsulta.Visible = False

                        .Panel2.Visible = False
                        .pnlBuscarGrupo.Visible = False
                    End With

                    frmIngresoDiario.MdiParent = frmMAIN
                    frmIngresoDiario.Show()
                    frmIngresoDiario.BringToFront()
            End Select

        End If
        frmMAIN.version.Enabled = True
        Cursor.Current = Cursors.Default
        Dim test As String = Empresa
    End Sub


    Private Sub BuscaDatosUltimoUsuario()
        CboEmpresa.Text = Trim(ReadFileUser(MyFileConfig, "USUARIO", "UserEmp"))
        txtUsuario.Text = Trim(ReadFileUser(MyFileConfig, "USUARIO", "UserCod"))
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboConeccion.SelectedIndex = 0

        Dim ret As String
        ret = ""
        Select Case cboConeccion.Text
            Case "MANUKA"
                LOGIN_CONEXION = "MANUKA"
                SRV_Servidor = "SRVMNK"
            Case "LOCAL"
                LOGIN_CONEXION = "LOCAL"
                SRV_Servidor = "127.0.0.1"
            Case "TEST"
                LOGIN_CONEXION = "TEST"
                SRV_Servidor = "MNK-OSO-QA"
        End Select
        General.Empresas.Cargar()
        LlenaEmpresas()

        BuscaDatosUltimoUsuario()
        If txtUsuario.Text <> "" Then
            txtClave.Focus()
        Else
            CboEmpresa.Text = "TOROMIRO"
            txtUsuario.Focus()
        End If


        'CboEmpresa.SelectedIndex = 0
    End Sub
    Private Sub LlenaEmpresas()
        If General.Empresas.NroRegistros = 0 Then Exit Sub

        CboEmpresa.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Empresas.NroRegistros - 1
            CboEmpresa.Items.Add(General.Empresas.EmpresaNom(i))
        Next
    End Sub

    Private Sub frmLogin_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If txtUsuario.Text <> "" Then
            txtClave.Focus()
        Else
            txtUsuario.Focus()
        End If
    End Sub

    Private Sub txtClave_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClave.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnAceptar_Click(sender, e)
        End If
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtClave.Focus()
        End If
    End Sub

    Private Sub cboConeccion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConeccion.SelectedIndexChanged
        txtUsuario.Focus()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Select Case cboConeccion.Text
            Case "MANUKA"
                LOGIN_CONEXION = "MANUKA"
                SRV_Servidor = "SRVMNK"
            Case "LOCAL"
                LOGIN_CONEXION = "LOCAL"
                SRV_Servidor = "127.0.0.1"
            Case "TEST"
                LOGIN_CONEXION = "TEST"
                SRV_Servidor = "MNK-OSO-QA"
        End Select


        ' frmUsuario_RecuperarPass.MdiParent = frmMAIN
        frmUsuario_RecuperarPass.ShowDialog()
        frmUsuario_RecuperarPass.BringToFront()
    End Sub

    Private Sub CboEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboEmpresa.SelectedIndexChanged

        Empresa = General.Empresas.EmpresaCod(CboEmpresa.SelectedIndex)

    End Sub
End Class
