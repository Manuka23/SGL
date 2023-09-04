Imports System.Data.SqlClient
Public Class frmUsuariosCambioContrasena

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmUsuariosCambioContrasena_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
    End Sub
    Private Function ValidacionesMod() As Boolean
        ValidacionesMod = False
        If txtConActual.Text <> "" And txtConNueva.Text <> "" And txtContNueva2.Text <> "" And txtConNueva.Text = txtContNueva2.Text Then
            ValidacionesMod = True

        Else
            ValidacionesMod = False
        End If
    End Function
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If ValidacionesMod() = True Then
            MdodificarUsuario()
        Else
            MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If
        'If txtConNueva.Text.Length > 8 Then
        '    MsgBox("Debe tene al menos 6 caracteres de largo.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
        '    Exit Sub
        'End If

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
    Private Sub MdodificarUsuario()
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim modif As Integer = 0
        Dim ret As String
        ret = ""
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuario_CambiarContrasena", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@OldPass", Encripta(txtConActual.Text, "E", ret))
        cmd.Parameters.AddWithValue("@UsrPass", Encripta(txtConNueva.Text, "E", ret))

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
            Else
                MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try


        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs) Handles GroupBox5.Enter

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class