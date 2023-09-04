

Imports System.Data.SqlClient


Public Class frmTorosIngreso

    Public Param1_Modo As Integer   '1=llamado desde toros / 2=llamado desde ingreso de dosis
    Public Out1_ValRet As Int16     '1=cierra con "grabar" (Param1_Modo=2) / 2=cierra con boton "cerrar"

    Public Raza As String = ""
    Public Vigente As String = ""
    Public Sexado As String = ""
    Public Update As Integer = 0

    Private Sub CboLlenaVS()
        cboVigente.Items.Clear()
        cboVigente.Items.Add("SI")
        cboVigente.Items.Add("NO")
        ''
        cboSexado.Items.Clear()
        cboSexado.Items.Add("SI")
        cboSexado.Items.Add("NO")
    End Sub



    Private Function GrabarToro() As Boolean
        GrabarToro = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spToros_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ToroCod", txtCodigo.Text.Trim)
        cmd.Parameters.AddWithValue("@ToroNom", txtNombre.Text.Trim)
        cmd.Parameters.AddWithValue("@Raza", General.Razas.Codigo(cboRazas.SelectedIndex))
        cmd.Parameters.AddWithValue("@ToroVigente", IIf(cboVigente.Text = "SI", 1, 0))
        cmd.Parameters.AddWithValue("@ToroSexado", IIf(cboSexado.Text = "SI", 1, 0))
        cmd.Parameters.AddWithValue("@ToroObservs", txtObservs.Text.Trim)
        cmd.Parameters.AddWithValue("@ABCode", txtABCode.Text)
        cmd.Parameters.AddWithValue("@Update", Update)
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

            GrabarToro = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        If Update = 1 Then
            Me.Close()
        End If
    End Function


    


    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If txtCodigo.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN CODIGO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtCodigo.Focus()
            Exit Function
        End If

        If txtNombre.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN NOMBRE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNombre.Focus()
            Exit Function
        End If

        If cboRazas.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UNA RAZA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboRazas.Focus()
            Exit Function
        End If

        If cboVigente.SelectedIndex = -1 Then
            If MsgBox("DEBE INDICAR SI EL TORO ESTÁ VIGENTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboVigente.Focus()
            Exit Function
        End If

        If cboSexado.SelectedIndex = -1 Then
            If MsgBox("DEBE INDICAR SI EL TORO ES SEXADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboSexado.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function




    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarToro() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            txtCodigo.Text = ""
            txtNombre.Text = ""
            cboRazas.SelectedIndex = -1
            cboVigente.SelectedIndex = -1
            cboSexado.SelectedIndex = -1

            txtCodigo.Focus()

            'si es llamado desde el ingreso de dosis de semen, entonces salimos
            If Param1_Modo = 2 Then
                Out1_ValRet = 1
                Cerrar()
            End If
        End If
    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Out1_ValRet = 2
        Cerrar()
    End Sub


    Private Sub frmTorosIngreso_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtCodigo.Focus()
    End Sub


    Private Sub frmTorosIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaRazas(cboRazas)
        CboLlenaVS()

        If Update = 1 Then
            cboRazas.SelectedItem = Raza
            cboVigente.SelectedItem = Vigente
            cboSexado.SelectedItem = Sexado
            cboRazas.Enabled = False
            txtCodigo.Enabled = False
            txtNombre.Enabled = False
        End If
    End Sub
    'Private Function BuscarProductoCod() As Boolean
    '    BuscarProductoCod = False
    '    If txtABCode.Text.Trim = "" Then Exit Function

    '    Dim con As New SqlConnection(GetConnectionStringFIN()) 'IIf(SRV_Servidor <> "SRVMNK", GetConnectionStringFIN(), GetConnectionString()))
    '    Dim cmd As New SqlCommand("spGPProductos_BuscarProductoCod", con)
    '    Dim rdr As SqlDataReader = Nothing
    '    Dim Existe As Boolean = False

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@ProductoCod", txtABCode.Text)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    Try
    '        con.Open()
    '        rdr = cmd.ExecuteReader()

    '        Try
    '            While rdr.Read()
    '                If rdr("IteNom").ToString.Trim = "NO EXISTE EN LA EMPRESA GP" Then
    '                    lblItem.Text = rdr("IteNom").ToString.Trim
    '                    txtABCode.Text = ""
    '                    btnGrabar.Enabled = False
    '                Else
    '                    lblItem.Text = rdr("IteNom").ToString.Trim
    '                    'lblItem.Text = "---"
    '                    btnGrabar.Enabled = True
    '                End If

    '                Existe = True

    '            End While

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    '    BuscarProductoCod = Existe
    'End Function

    'Private Sub txtABCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtABCode.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        BuscarProductoCod()
    '        e.Handled = True
    '    End If
    'End Sub

    'Private Sub txtABCode_Leave(sender As Object, e As EventArgs) Handles txtABCode.Leave
    '    BuscarProductoCod()
    'End Sub
End Class