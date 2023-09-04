Imports System.Data.SqlClient

Public Class frmGeneticaPorcentajes
    Private Sub frmGeneticaPorcentajes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.MdiParent = frmMAIN

        PorcentajesBuscar()
    End Sub
    Public Sub PorcentajesBuscar()
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spToros_PorcentajeBuscar", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try

                While rdr.Read()
                    lblPorPa.Text = rdr("BWPadre").ToString.Trim
                    lblPorAb.Text = rdr("BWAbuelo").ToString.Trim
                    lblPorBis.Text = rdr("BWBisabuelo").ToString.Trim
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PorcentajeGrabar()
    End Sub
    Private Sub PorcentajeGrabar()
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spToros_GrabarPorcentaje", con)

        Dim ResultCod As Integer
        Dim ResultMsg As String
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Padre", txtPorcentPadre.Text)
        cmd.Parameters.AddWithValue("@Abuelo", txtPorcentAbuelo.Text)
        cmd.Parameters.AddWithValue("@Bisabuelo", txtPercentBisabuelo.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        Try
            con.Open()
            cmd.ExecuteNonQuery()

            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        MsgBox("REGISTRO EXITOSO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "VALIDACION")

        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class