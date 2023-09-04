Imports System.Data.SqlClient
Public Class frmUsuario_RecuperarPass
    Dim rut As String
    Dim pass As String
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        RecuperarPass()
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles txtRut.LostFocus
        If txtRut.Text = "" Then
            Exit Sub
        End If
        txtRut.Text = FormateaRUTGPGuion(txtRut.Text)
        If txtRut.Text <> "" And txtRut.Text.Length > 8 Then
            If ValidarRut(txtRut.Text) = True Then
            End If
        Else
            MsgBox("Ingrese un RUT correcto", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If

    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRut.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) And (UCase(e.KeyChar) <> "K") Then
            e.Handled = True
        End If
    End Sub
    Public Function ValidarRut(ByVal Rut As String) As Boolean
        ValidarRut = False
        Dim Digito As Integer
        Dim Contador As Integer
        Dim Multiplo As Integer
        Dim Acumulador As Integer
        Dim str_AuxDig As String = Nothing
        Dim str_Digito As String = Mid(Rut.ToUpper(), Rut.Length(), 1)
        Dim str_Rut As String = Mid(Rut, 1, Rut.Length() - 2)
        Contador = 2
        Acumulador = 0
        While str_Rut <> 0
            Multiplo = (str_Rut Mod 10) * Contador
            Acumulador = Acumulador + Multiplo
            str_Rut = str_Rut \ 10
            Contador = Contador + 1
            If Contador = 8 Then
                Contador = 2
            End If
        End While
        Digito = 11 - (Acumulador Mod 11)
        str_AuxDig = CStr(Digito)
        Select Case Digito
            Case Is = 10 : str_AuxDig = "K"
            Case Is = 11 : str_AuxDig = "0"
            Case Else : str_AuxDig = str_AuxDig
        End Select
        If str_Digito = str_AuxDig Then
            ValidarRut = True
        Else
            MsgBox("Ingrese un RUT correcto", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If
    End Function
    Private Sub RecuperarPass()
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim modif As Integer = 0
        Dim ret As String
        ret = ""
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuario_RecuperarContrasena", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Rut", txtRut.Text)

        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()

                rut = rdr("UsrRut").ToString.Trim
                pass = rdr("UsrPass").ToString.Trim
                pass = Encripta(pass, "i", ret)

            End While
            con.Close()
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value


            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
            Else
                MsgBox("Se enviara un correo electronico con el nombre de usuario y la contraseña a su correo.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                EnviaEmail()
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try


        Cursor.Current = Cursors.Default
    End Sub
    Private Sub EnviaEmail()
        ''SP ENVIA EMAIL''


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuarios_MailRecuperaPass", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Rut", rut)
        cmd.Parameters.AddWithValue("@Pass", pass)

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR ENVIA EMAIL")
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmUsuario_RecuperarPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
    End Sub
End Class