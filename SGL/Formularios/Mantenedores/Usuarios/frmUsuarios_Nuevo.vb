Imports System.Data.SqlClient
Public Class frmUsuarios_Nuevo
    Private pass As String
    Private vret As Integer = 0
    Private mret As String = ""
    Public User As String = ""
    Public parto As String = ""
    Private Sub frmUsuarios_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.Perfiles.Cargar()
        CboLLenaPerfiles()
        CboPerfil.SelectedIndex = 0
        CboLlena()
        If User <> "" Then
            TextBox3.Text = User
            EliminaInduccion.Text = parto
            Buscardatos()
            Label10.Text = "Formulario de modificación de Usuarios"
        End If


    End Sub
    Private Sub CboLLenaPerfiles()

        If General.Perfiles.NroRegistros = 0 Then Exit Sub
        CboPerfil.Items.Clear()
        CboPerfil.Items.Add("-Seleccione-")

        Dim i As Integer
        For i = 0 To General.Perfiles.NroRegistros - 1
            CboPerfil.Items.Add(General.Perfiles.Nombre(i))
        Next
    End Sub
    Private Sub CboLlena()
        leche.Items.Clear()
        leche.Items.Add("-Seleccione-")
        leche.Items.Add("NO")
        leche.Items.Add("SI")
        leche.SelectedIndex = 0

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

        EliminaInduccion.Items.Clear()
        EliminaInduccion.Items.Add("-Seleccione-")
        EliminaInduccion.Items.Add("NO")
        EliminaInduccion.Items.Add("SI")
        EliminaInduccion.SelectedIndex = 0

        eliminacierre.Items.Clear()
        eliminacierre.Items.Add("-Seleccione-")
        eliminacierre.Items.Add("NO")
        eliminacierre.Items.Add("SI")
        eliminacierre.SelectedIndex = 0

        ajustes.Items.Clear()
        ajustes.Items.Add("-Seleccione-")
        ajustes.Items.Add("NO")
        ajustes.Items.Add("SI")
        ajustes.SelectedIndex = 0

        concentrado.Items.Clear()
        concentrado.Items.Add("-Seleccione-")
        concentrado.Items.Add("NO")
        concentrado.Items.Add("SI")
        concentrado.SelectedIndex = 0

        dias.Items.Clear()
        dias.Items.Add("-Seleccione-")
        dias.Items.Add("NO")
        dias.Items.Add("SI")
        dias.SelectedIndex = 0

        CboParAtrasa.Items.Clear()
        CboParAtrasa.Items.Add("-Seleccione-")
        CboParAtrasa.Items.Add("NO")
        CboParAtrasa.Items.Add("SI")
        CboParAtrasa.SelectedIndex = 0

        cboVenta.Items.Clear()
        cboVenta.Items.Add("-Seleccione-")
        cboVenta.Items.Add("NO")
        cboVenta.Items.Add("SI")
        cboVenta.SelectedIndex = 0

        cboIntCompania.Items.Clear()
        cboIntCompania.Items.Add("-Seleccione-")
        cboIntCompania.Items.Add("NO")
        cboIntCompania.Items.Add("SI")
        cboIntCompania.SelectedIndex = 0

        cboElimCieBodega.Items.Clear()
        cboElimCieBodega.Items.Add("-Seleccione-")
        cboElimCieBodega.Items.Add("NO")
        cboElimCieBodega.Items.Add("SI")
        cboElimCieBodega.SelectedIndex = 0

    End Sub
    Private Sub Limpiar()
        leche.SelectedIndex = 0
        CboPerfil.SelectedIndex = 0
        estado.SelectedIndex = 0
        cierre.SelectedIndex = 0
        eliminacierre.SelectedIndex = 0
        EliminaInduccion.SelectedIndex = 0
        ajustes.SelectedIndex = 0
        concentrado.SelectedIndex = 0
        dias.SelectedIndex = 0
        CboParAtrasa.SelectedIndex = 0
        cboVenta.SelectedIndex = 0
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""

    End Sub
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click

        If User <> "" Then

            If MsgBox("¿ DESEA MODIFICAR DATOS DE USUARIO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            Dim ret As String
            ret = ""
            If ValidacionesMod(Encripta(TextBox5.Text, "E", ret)) = True Then
                If TextBox2.Text <> "" And TextBox2.Text.Length > 8 Then
                    If ValidarRut(TextBox2.Text) = True Then
                        BuscarNombre()
                        MdodificarUsuario()
                        Me.Close()
                        Exit Sub
                    Else

                        Exit Sub
                    End If

                Else
                    MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
                End If
            End If
        End If
        If Not TextBox2.Text.Contains("-") Then

            If MsgBox("RUT INCORRECTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then

            End If
        End If
        If TextBox2.Text <> "" And TextBox2.Text.Length > 8 Then
            If ValidarRut(TextBox2.Text) = True Then
                If MsgBox("¿ DESEA GRABAR DATOS DE USUARIO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
                Dim ret As String
                ret = ""
                If Validaciones(Encripta(TextBox5.Text, "E", ret)) = True Then

                    CrearUsuario()
                    Limpiar()
                Else
                    MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
                End If

            End If
        End If


    End Sub
    Private Function Validaciones(ByVal Clave As String) As Boolean
        Validaciones = False
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And
            TextBox5.Text <> "" And TextBox6.Text <> "" And CboPerfil.SelectedIndex <> 0 And
            estado.SelectedIndex <> 0 And cierre.SelectedIndex <> 0 And dias.SelectedIndex <> 0 And
             EliminaInduccion.SelectedIndex <> 0 And eliminacierre.SelectedIndex <> 0 And ajustes.SelectedIndex <> 0 And concentrado.SelectedIndex <> 0 And CboParAtrasa.SelectedIndex <> 0 And leche.SelectedIndex <> 0 And cboVenta.SelectedIndex <> 0 Then
            Validaciones = True
            pass = Clave
        Else
            Validaciones = False
        End If
    End Function
    Private Function ValidacionesMod(ByVal Clave As String) As Boolean
        ValidacionesMod = False
        If CboPerfil.SelectedIndex <> 0 And
            estado.SelectedIndex <> 0 And cierre.SelectedIndex <> 0 And dias.SelectedIndex <> 0 And
           EliminaInduccion.SelectedIndex <> 0 And eliminacierre.SelectedIndex <> 0 And ajustes.SelectedIndex <> 0 And concentrado.SelectedIndex <> 0 And CboParAtrasa.SelectedIndex <> 0 And leche.SelectedIndex <> 0 And cboVenta.SelectedIndex <> 0 Then
            ValidacionesMod = True
            pass = Clave
        Else
            ValidacionesMod = False
        End If
    End Function

    Private Sub MdodificarUsuario()
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim modif As Integer = 0
        If User <> "" Then
            modif = 1
        End If
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuario_Modificar", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@ResCre", LoginUsuario)
        cmd.Parameters.AddWithValue("@UserName", TextBox3.Text)
        cmd.Parameters.AddWithValue("@UsrNombre", TextBox1.Text)
        cmd.Parameters.AddWithValue("@UsrRut", TextBox2.Text)
        cmd.Parameters.AddWithValue("@UsrPass", pass)
        cmd.Parameters.AddWithValue("@UsrAD", TextBox6.Text)
        cmd.Parameters.AddWithValue("@CodPerfil", CboPerfil.SelectedIndex)
        cmd.Parameters.AddWithValue("@UsrInduccion", EliminaInduccion.Text)
        cmd.Parameters.AddWithValue("@Estado", estado.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrCierraXLS", cierre.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrModDiasBaston ", dias.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrEliminaCierre", eliminacierre.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrConfirmaAjuste", ajustes.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrAdminConcent", concentrado.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@PermIngPartoAtrasado", CboParAtrasa.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@GrabaLeche", leche.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@PermIngVentaGanado", cboVenta.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@PermTRLIntCompania", cboIntCompania.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@ElimCieBodega", cboElimCieBodega.SelectedIndex - 1)
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

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
        MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub CrearUsuario()
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim modif As Integer = 0
        If User <> "" Then
            modif = 1
        End If
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuario_Crear", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@ResCre", LoginUsuario)
        cmd.Parameters.AddWithValue("@UserName", TextBox3.Text)
        cmd.Parameters.AddWithValue("@UsrNombre", TextBox1.Text)
        cmd.Parameters.AddWithValue("@UsrRut", TextBox2.Text)
        cmd.Parameters.AddWithValue("@UsrPass", pass)
        cmd.Parameters.AddWithValue("@UsrAD", TextBox6.Text)
        cmd.Parameters.AddWithValue("@CodPerfil", CboPerfil.SelectedIndex)
        cmd.Parameters.AddWithValue("@UsrInduccion", EliminaInduccion.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@Estado", estado.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrCierraXLS", cierre.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrModDiasBaston ", dias.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrEliminaCierre", eliminacierre.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrConfirmaAjuste", ajustes.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@UsrAdminConcent", concentrado.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@PermIngPartoAtrasado", CboParAtrasa.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@GrabaLeche", leche.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@PermIngVentaGanado", cboVenta.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@PermTRLIntCompania", cboIntCompania.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@ElimCieBodega", cboElimCieBodega.SelectedIndex - 1)
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

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
        MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Cursor.Current = Cursors.Default
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

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
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
    Private Sub BuscarNombre()
        Cursor.Current = Cursors.WaitCursor
        Dim MiTextoSinEspacios As String
        Dim modif As Integer = 0
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spUsuarios_BuscarNombre", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@modif", modif)
            cmd.Parameters.AddWithValue("@Rut", TextBox2.Text)
            cmd.Parameters.AddWithValue("@User", " ")
            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                MiTextoSinEspacios = System.Text.RegularExpressions.Regex.Replace(rdr("Nombre").ToString.Trim, " {2,}", " ")
                TextBox1.Text = MiTextoSinEspacios
            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub Buscardatos()
        Cursor.Current = Cursors.WaitCursor
        Dim modif As Integer = 0
        If User <> "" Then
            modif = 1
        End If

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spUsuarios_BuscarNombre", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@modif", modif)
            cmd.Parameters.AddWithValue("@Rut", TextBox2.Text)
            cmd.Parameters.AddWithValue("@User", User)

            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                TextBox1.Text = rdr("UsrNombre").ToString.Trim
                TextBox2.Text = rdr("UsrRut").ToString.Trim
                TextBox6.Text = rdr("UsrAD").ToString.Trim
                CboPerfil.SelectedIndex = rdr("CodPerfil").ToString.Trim
                estado.SelectedIndex = (rdr("Estado") + 1)
                cierre.SelectedIndex = (rdr("UsrCierraXLS") + 1)
                eliminacierre.SelectedIndex = (rdr("UsrEliminaCierre") + 1)
                ajustes.SelectedIndex = (rdr("UsrConfirmaAjuste") + 1)
                concentrado.SelectedIndex = (rdr("UsrAdminConcent") + 1)
                dias.SelectedIndex = (rdr("UsrModDiasBaston") + 1)
                CboParAtrasa.SelectedIndex = (rdr("PermIngPartoAtrasado") + 1)
                EliminaInduccion.SelectedIndex = (rdr("UsrEliminaInduccion") + 1)
                leche.SelectedIndex = (rdr("UsrGrabaLeche") + 1)
                cboVenta.SelectedIndex = (rdr("PermIngVentaGanado") + 1)
                cboIntCompania.SelectedIndex = (rdr("UsrTrasInterComp") + 1)
                cboElimCieBodega.SelectedIndex = (rdr("UsrElimCieBodega") + 1)

            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class