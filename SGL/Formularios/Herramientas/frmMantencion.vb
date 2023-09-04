Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.ComponentModel
Public Class frmMantencion
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        If ReducirLog() = True Then
            If MsgBox("PROCESO REALIZADO CON EXITO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
        End If
    End Sub
    Private Function ReducirLog() As Boolean
        Cursor.Current = Cursors.WaitCursor
        ReducirLog = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spReducirLog", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.Clear()
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
                    ReducirLog = False

                End If
            Else
                ReducirLog = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            ReducirLog = False
        Finally
            con.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ReorganizarIndices() = True Then
            If MsgBox("PROCESO REALIZADO CON EXITO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
        End If
    End Sub
    Private Function ReorganizarIndices() As Boolean
        Cursor.Current = Cursors.WaitCursor
        ReorganizarIndices = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_ReorganizarIndices", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.Clear()
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
                    ReorganizarIndices = False

                End If
            Else
                ReorganizarIndices = True

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            ReorganizarIndices = False
        Finally
            con.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub frmMantencion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class