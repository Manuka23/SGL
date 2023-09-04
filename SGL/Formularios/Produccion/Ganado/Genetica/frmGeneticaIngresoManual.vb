Imports DevExpress.XtraPrinting.Native
Imports System.Data.SqlClient

Public Class frmGeneticaIngresoManual

    Public CodigoAB As Integer
    Public NombreToro As String
    Public Raza As String
    Public Valor As Double
    Public Actualizar As Integer = 0

    Private Sub frmGeneticaIngresoManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        If Actualizar = 1 Then
            txtCodigo.Text = CodigoAB
            txtCodigo.Enabled = False
            txtNombre.Text = NombreToro
            txtRaza.Text = Raza
            txtValorGenetico.Text = Valor
        End If

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        IngresoManual()
    End Sub
    Private Sub IngresoManual()
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spToros_GeneticaActualizar", con)

        Dim ResultCod As Integer
        Dim ResultMsg As String
        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@CodigoAB", CodigoAB)
        cmd.Parameters.AddWithValue("@NombreToro", txtNombre.Text)
        cmd.Parameters.AddWithValue("@Raza", txtRaza.Text)
        cmd.Parameters.AddWithValue("@Valor", txtValorGenetico.Text)
        cmd.Parameters.AddWithValue("@Actualizar", Actualizar)
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
        Me.Close()
    End Sub
End Class