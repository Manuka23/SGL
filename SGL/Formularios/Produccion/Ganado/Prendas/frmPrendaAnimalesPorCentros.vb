Imports System.Data.SqlClient
Public Class frmPrendaAnimalesPorCentros
    Private Sub frmPrendaAnimales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        dtpFecha.Value = Now
        CboLLenaBancos()
        BuscarCentros()

    End Sub

    Private Sub BuscarCentros()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spLlenadoCentros", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            con.Open()
            rdr = cmd.ExecuteReader()

            Dim i As Integer = 1

            dgvCentros.Rows.Clear()

            While rdr.Read()
                dgvCentros.Rows.Add("false", i, rdr("GndCenCod"), rdr("CentroNom"), rdr("diios"), rdr("vacas"), rdr("vaquillas"), rdr("terneras"), rdr("toros"), rdr("toretes"), rdr("terneros"), rdr("GndCenCod"))

                i = i + 1
            End While

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub CboLLenaBancos()
        If General.Bancos.NroRegistros = 0 Then Exit Sub

        cboBancos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Bancos.NroRegistros - 1
            cboBancos.Items.Add(General.Bancos.Nombre(i))
        Next
    End Sub

    Private Sub cboBancos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBancos.SelectedIndexChanged
        Dim cent_ As String = General.Bancos.Codigo(cboBancos.SelectedIndex)
        dgvCentros.Enabled = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Function GrabarPrendas() As Boolean
        GrabarPrendas = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPrendaAnimales_GrabarPrendadosPorCentros", con)
        Dim rdr As SqlDataReader = Nothing
        con.Open()
        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim i As Integer = 0
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean
        Dim bancoNom As String = cboBancos.Text
        Dim bancoCod As String = General.Bancos.Codigo(cboBancos.SelectedIndex)

        For i = 0 To dgvCentros.Rows.Count - 1



            If dgvCentros.Rows(i).Cells(0).Value = False Then
            Else
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@PrnEmpresa", Empresa)
                cmd.Parameters.AddWithValue("@PrnUsuario", LoginUsuario)
                cmd.Parameters.AddWithValue("@PrnCodBanco", bancoCod)
                cmd.Parameters.AddWithValue("@PrnNomBanco", bancoNom)
                cmd.Parameters.AddWithValue("@PrnCentro", dgvCentros.Rows(i).Cells(2).Value.ToString.Trim)
                cmd.Parameters.AddWithValue("@PrnNumeroDiios", dgvCentros.Rows(i).Cells(4).Value.ToString.Trim)
                cmd.Parameters.AddWithValue("@PrnEquipo", NombrePC)
                '
                cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
                cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

                Try
                    Result = cmd.ExecuteNonQuery()

                    vret = cmd.Parameters("@RetValor").Value
                    mret = cmd.Parameters("@RetMensage").Value

                    ''verificamos error con un valor igual a -1
                    If vret <> 0 Then
                        If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If

                        HayError = True
                        Exit For
                    End If

                    HayError = False
                    ''si todo sale ok guardamos el nuevo codigo del grupo de celos
                    'GrabarGrupoParto = True

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                    HayError = True
                    Exit For
                End Try
            End If


        Next
        con.Close()

        GrabarPrendas = True
        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            Me.Close()
        End If
        Cursor.Current = Cursors.Default
    End Function
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If GrabarPrendas() = True Then
            Dim bancoNom As String = General.Bancos.Nombre(cboBancos.SelectedIndex)
            Me.Close()
        End If

    End Sub


End Class