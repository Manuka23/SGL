Imports System.Data.SqlClient
Public Class frmVeterinariosCreacion
    Private vret As Integer = 0
    Private mret As String = ""
    Public User As String = ""
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) And (UCase(e.KeyChar) <> "K") Then
            e.Handled = True
        End If

    End Sub
    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        TextBox2.Text = FormateaRUTGPGuion(TextBox2.Text)
        If TextBox2.Text <> "" And TextBox2.Text.Length > 8 Then
            If ValidarRut(TextBox2.Text) = True Then
                BuscarNombre()
            End If
        Else
            MsgBox("Ingrese un RUT correcto", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If


    End Sub
    Private Sub CboLlena()

        estado.Items.Clear()
        estado.Items.Add("-Seleccione-")
        estado.Items.Add("NO")
        estado.Items.Add("SI")
        estado.SelectedIndex = 0

        cierre.Items.Clear()
        cierre.Items.Add("-Seleccione-")
        cierre.Items.Add("NO")
        cierre.Items.Add("SI")
        cierre.SelectedIndex = 0


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
    Private Sub BuscarNombre()
        Cursor.Current = Cursors.WaitCursor
        Dim MiTextoSinEspacios As String
        Dim modi As Integer = 0
        If User <> "" Then
            modi = 1
        End If
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spVeterinarios_BuscaNombre", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Rut", TextBox2.Text)
            cmd.Parameters.AddWithValue("@mod", modi)
            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()


                If User <> "" Then

                    MiTextoSinEspacios = System.Text.RegularExpressions.Regex.Replace(rdr("VetNom").ToString.Trim, " {2,}", " ")
                    TextBox1.Text = MiTextoSinEspacios

                    If rdr("VetVigente") = "SI" Then
                        estado.SelectedIndex = 2
                    Else
                        estado.SelectedIndex = 1
                    End If
                    If rdr("VetAcreditado") = "SI" Then
                        cierre.SelectedIndex = 2
                    Else
                        cierre.SelectedIndex = 1
                    End If
                Else
                    MiTextoSinEspacios = System.Text.RegularExpressions.Regex.Replace(rdr("Nombre").ToString.Trim, " {2,}", " ")
                    TextBox1.Text = MiTextoSinEspacios
                End If



            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click

        If User <> "" Then

            If MsgBox("¿ DESEA MODIFICAR LOS DATOS DE USUARIO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            Dim ret As String
            ret = ""
            If ValidacionesMod() = True Then

                Grabar()
                Me.Close()
                Exit Sub
            Else
                MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
            End If

        End If
        If Not TextBox2.Text.Contains("-") Then

            If MsgBox("RUT INCORRECTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then

            End If
        End If
        If TextBox2.Text <> "" And TextBox2.Text.Length > 8 Then
            If ValidarRut(TextBox2.Text) = True Then
                If MsgBox("¿ CONFIRMA DATOS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
                Dim ret As String
                ret = ""
                If Validaciones() = True Then

                    Grabar()
                    Limpiar()

                    Me.Close()
                Else
                    MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
                End If

            End If
        End If

    End Sub
    Private Function ValidacionesMod() As Boolean
        ValidacionesMod = False
        If estado.SelectedIndex <> 0 And cierre.SelectedIndex <> 0 Then
            ValidacionesMod = True
        Else
            ValidacionesMod = False
        End If
    End Function
    Private Function Validaciones() As Boolean
        Validaciones = False
        If TextBox1.Text <> "" And TextBox2.Text <> "" And
            estado.SelectedIndex <> 0 And cierre.SelectedIndex <> 0 Then

            Validaciones = True
        Else
            Validaciones = False
        End If
    End Function
    Private Sub Limpiar()
        estado.SelectedIndex = 0
        cierre.SelectedIndex = 0
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Grabar()
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim modif As Integer = 0
        If User <> "" Then
            modif = 1
        End If
        Dim rut As String = TextBox2.Text
        Dim rutsplit As String
        Dim ArrCadena As String() = rut.Split("-")
        rutsplit = ArrCadena(0)

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVeterinarios_Grabar", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@mod", modif)
        cmd.Parameters.AddWithValue("@ResCre", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsrNombre", TextBox1.Text)
        cmd.Parameters.AddWithValue("@UsrRut", TextBox2.Text)
        cmd.Parameters.AddWithValue("@Estado", estado.Text)
        cmd.Parameters.AddWithValue("@Acreditado", cierre.Text)
        cmd.Parameters.AddWithValue("@rutsplit", rutsplit)

        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@Duplicado", SqlDbType.Int) : cmd.Parameters("@Duplicado").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Dim dup As Integer = cmd.Parameters("@Duplicado").Value

            If dup = "1" Then
                MsgBox("Usuario ya existe", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
            Else
                MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try


        Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmVeterinariosCreacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLlena()
        If User <> "" Then
            TextBox2.Text = User
            BuscarNombre()
            TextBox2.Enabled = False
            TextBox1.Enabled = False
            Label10.Text = "Formulario de modificación de Usuarios"
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class