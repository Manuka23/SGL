Imports System.Data.SqlClient
Public Class frmPabcoLiberarLeche

    Public TipoLiberacion As Integer
    Private Sub frmPabcoLiberarLeche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
    End Sub

    Public Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        LiberarLecheLote()
    End Sub
    Public Sub LiberarLecheLote()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPabcoLote_LiberarLeche", con)
        Dim rdr As SqlDataReader = Nothing
        Dim CodPatologia As Integer = frmPabcoLotes.lvLoteo.SelectedItems.Item(0).SubItems(5).Text
        Dim CodMedicamento As Integer = frmPabcoLotes.lvLoteo.SelectedItems.Item(0).SubItems(7).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@TipoLiberacion", TipoLiberacion) '0 =  lote, 1 = Diio
        cmd.Parameters.AddWithValue("@Diio_Lote", lblDiioLote.Text)
        cmd.Parameters.AddWithValue("@FechaCierre", dtpFechaCierre.Value)
        cmd.Parameters.AddWithValue("@CodPatologia", CodPatologia)
        cmd.Parameters.AddWithValue("@CodMedicamento", CodMedicamento)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            If vret = -1 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        MsgBox("DATOS GUARDADOS CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ACTUALIZACION")
    End Sub

    Public Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class