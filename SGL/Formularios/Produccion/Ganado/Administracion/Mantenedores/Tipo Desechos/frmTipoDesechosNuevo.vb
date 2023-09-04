Imports System.Data.SqlClient
Public Class frmTipoDesechosNuevo
    Public modif As Integer
    Private Sub frmTipoDesechosNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        If modif = 1 Then
            btnFinalizar.Text = "Modificar"
            Label10.Text = "Modificar Tipo Desecho"
            CodDesecho.Enabled = False

        End If
    End Sub
    Private Sub CodDesecho_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CodDesecho.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If modif = 1 Then
            Modificar()
        Else

            Grabar()
        End If

        Me.Close()
    End Sub
    Private Sub Grabar()
        Dim i As Integer = 0
        Dim modo As Integer = 0

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTipoDesecho_Crear", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@NombreDese", Desecho.Text)
        cmd.Parameters.AddWithValue("@CodDese", CodDesecho.Text)
        cmd.Parameters.AddWithValue("@mod", modo)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
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
                MsgBox("Nombre o codigos ya ingresados ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
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
    Private Sub Modificar()
        Dim i As Integer = 0
        Dim modo As Integer = 1

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTipoDesecho_Crear", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@NombreDese", Desecho.Text)
        cmd.Parameters.AddWithValue("@CodDese", CodDesecho.Text)
        cmd.Parameters.AddWithValue("@mod", modo)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
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
                MsgBox("Nombre o codigos ya ingresados ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
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
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class