Imports System.Data.SqlClient

Public Class frmCausaMuerte
    Public Procesa As Boolean = False

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If txtObservacion.Text = "" Then
            If MsgBox("DEBE INGRESAR UNA OBSERVACION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtObservacion.Focus()
            Exit Sub
        End If
        GrabarConfirmarMuerte(dgvConfirmarMuerte)
        Procesa = True
        Me.Close()
    End Sub
    Public Function DataGridATabla(ByVal dgvConfirmarMuerte As DataGridView)

        Dim dt As New DataTable
        Dim columna As DataRow

        dt.Columns.Add("MueDiio", System.Type.GetType("System.Int32"))
        dt.Columns.Add("MueFechaMuerte", System.Type.GetType("System.String"))
        dt.Columns.Add("MueVeterinario", System.Type.GetType("System.String"))
        dt.Columns.Add("MueCentro", System.Type.GetType("System.String"))



        For i = 0 To dgvConfirmarMuerte.Rows.Count - 1

            columna = dt.NewRow
            columna("MueDiio") = dgvConfirmarMuerte.Rows(i).Cells(0).Value
            columna("MueFechaMuerte") = dgvConfirmarMuerte.Rows(i).Cells(1).Value
            columna("MueVeterinario") = dgvConfirmarMuerte.Rows(i).Cells(2).Value
            columna("MueCentro") = dgvConfirmarMuerte.Rows(i).Cells(3).Value
            dt.Rows.Add(columna)
        Next

        DataGridATabla = dt

    End Function
    Public Function GrabarConfirmarMuerte(ByVal dgvConfirmarMuerte As DataGridView) As String

        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuertes_GrabarConfirmacion", con)
        Dim MuertesConfirmar As DataTable = DataGridATabla(dgvConfirmarMuerte)
        Dim Causa As String = cbxCausaMuerte.SelectedValue
        Dim Obs As String = txtObservacion.Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Obs", Obs)
        cmd.Parameters.AddWithValue("@Causa", Causa)
        cmd.Parameters.AddWithValue("@DTMuertesConfirmar", MuertesConfirmar)
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            ResultCod = cmd.Parameters("@RetValor").Value
            ResultMsg = cmd.Parameters("@RetMensage").Value
            con.Close()

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                Exit Function
            End If
            MsgBox("Grabación exitosa", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GRABACION")
            Me.Close()
            'If ResultCod = 10 Then
            '    MsgBox(ResultMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR ENCONTRADO")
            '    dgvControlLechero.Columns.Clear()
            '    Exit Function
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub frmCausaMuerte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height + 50) / 2)
        Me.Left = Me.Left + (frmMAIN.pnlMenu.Width / 2)

        LlenarCausaMuerte()
        LlenardgvConfirmarMuerte()
    End Sub
    Private Sub LlenarCausaMuerte()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCausas_ListadoMuertes", con)
        Dim rdr As SqlDataReader = Nothing

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        da.Fill(dt)
        cbxCausaMuerte.DataSource = dt
        cbxCausaMuerte.DisplayMember = "CauNombre"
        cbxCausaMuerte.ValueMember = "CauCodigo"

    End Sub
    Public Sub LlenardgvConfirmarMuerte()
        dgvConfirmarMuerte.Columns.Clear()
        dgvConfirmarMuerte.Columns.Add(1, "Diio")
        dgvConfirmarMuerte.Columns.Add(2, "Fecha Muerte")
        dgvConfirmarMuerte.Columns.Add(3, "Veterinario")
        dgvConfirmarMuerte.Columns.Add(4, "Centro")
        For Each it As ListViewItem In frmMuertes.lvMUERTES.SelectedItems
            dgvConfirmarMuerte.Rows.Add(it.SubItems(4).Text, it.SubItems(3).Text, it.SubItems(6).Text, it.SubItems(15).Text)
        Next
    End Sub
End Class