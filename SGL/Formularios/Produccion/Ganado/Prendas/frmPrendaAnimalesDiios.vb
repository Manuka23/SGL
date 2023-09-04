Imports System.Data.SqlClient


Public Class frmPrendaAnimalesDiios

    Private cat As Integer
    Private totalG As Integer
    Private Prendados As Integer
    Private DiiosSelect As Integer
    Private variable As Integer
    Private categoria As String
    Private ConsultaDiio As String


    Private Sub frmPrendaAnimalesDiios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLLenaCentros()
        CboLLenaBancos()
        cboBancos.SelectedIndex = 0
        chklvCategorias.SetItemCheckState(0, CheckState.Checked)
        chklvCategorias.SelectedIndex = 0

    End Sub
    Private Function GrabarPrendas() As Boolean
        GrabarPrendas = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPrendaAnimales_GrabarPrendasDiios", con)
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

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@PrnEmpresa", Empresa)
        cmd.Parameters.AddWithValue("@PrnUsuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@PrnCodBanco", bancoCod)
        cmd.Parameters.AddWithValue("@PrnNomBanco", bancoNom)
        cmd.Parameters.AddWithValue("@PrnCentro", General.Centros.Codigo(chklvCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@PrnNumeroDiios", DiiosSelect)
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
            End If

            HayError = False
            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            'GrabarGrupoParto = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            HayError = True

        End Try

        con.Close()

        GrabarPrendas = True

        Cursor.Current = Cursors.Default
    End Function
    Private Function GrabarPrendasDetalle() As Boolean
        GrabarPrendasDetalle = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPrendaAnimales_GrabarPrendasDiiosDet", con)
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
                cmd.Parameters.AddWithValue("@Diios", dgvCentros.Rows(i).Cells(4).Value.ToString.Trim) '''''
                cmd.Parameters.AddWithValue("@PrnCentro", General.Centros.Codigo(chklvCentros.SelectedIndex))
                cmd.Parameters.AddWithValue("@PrnNumeroDiios", DiiosSelect)
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
        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
        End If
        GrabarPrendasDetalle = True

        Cursor.Current = Cursors.Default
    End Function
    Private Sub LlenarGrilla()
        Dim idx As Integer
        Cursor.Current = Cursors.WaitCursor
        Dim centros As String = ""
        idx = chklvCentros.SelectedIndex
        If idx <> -1 Then
            centros = General.Centros.Codigo(idx)
        End If


        cat = chklvCategorias.SelectedIndex
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spPrendaAnimales_LlenadoDiiosPrenda", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centros", centros)
            cmd.Parameters.AddWithValue("@Prendados", Prendados)
            cmd.Parameters.AddWithValue("@Categorias", chklvCategorias.Items(cat).ToString.Trim)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim i As Integer = 1

            'dgvCentros.Rows.Clear()

            While rdr.Read()
                dgvCentros.Rows.Add("false", i, rdr("CentroCod"), rdr("CentroNom"), rdr("GndCod"), rdr("GndProNom"))
                totalG = totalG + 1
                i = i + 1

            End While
            total.Text = totalG
            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub CboLLenaCentros()
        If General.Centros.NroRegistros = 0 Then Exit Sub

        Me.SuspendLayout()
        chklvCentros.SuspendLayout()
        chklvCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Centros.NroRegistros - 1
            chklvCentros.Items.Add(General.Centros.Nombre(i))
        Next

        chklvCentros.ResumeLayout()
        Me.ResumeLayout()
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



    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        For i = 0 To dgvCentros.Rows.Count - 1
            If dgvCentros.Rows(i).Cells(0).Value = True Then
                DiiosSelect = DiiosSelect + 1
            End If
        Next
        If GrabarPrendas() = True Then
            Dim bancoNom As String = General.Bancos.Nombre(cboBancos.SelectedIndex)
        End If
        If GrabarPrendasDetalle() = True Then
            Dim bancoNom As String = General.Bancos.Nombre(cboBancos.SelectedIndex)
        End If
        Me.Close()
    End Sub



    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If CheckBox1.Checked = True Then
            Prendados = 1
        Else
            Prendados = 0
        End If
        dgvCentros.Rows.Clear()
        totalG = 0
        LlenarGrilla()
        btnGrabar.Enabled = True
    End Sub



    Private Sub chklvCategorias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklvCategorias.SelectedIndexChanged
        If chklvCategorias.SelectedIndex = 0 Then
            dgvCentros.Rows.Clear()
            chklvCategorias.SetItemCheckState(0, CheckState.Checked)
            chklvCategorias.SelectedIndex = 0
        Else

            chklvCategorias.SetItemCheckState(0, CheckState.Unchecked)
        End If

    End Sub

    Private Sub SelectT_CheckedChanged(sender As Object, e As EventArgs) Handles SelectT.CheckedChanged
        For i = 0 To dgvCentros.RowCount - 1
            dgvCentros.Rows(i).Cells(0).Value = True
        Next

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        CheckBox1.Checked = False
        totalG = 0
        total.Text = totalG
        cboBancos.Text = ""
        SelectT.CheckState = False

        dgvCentros.Rows.Clear()

        For i = 0 To chklvCentros.Items.Count - 1
            chklvCentros.SetItemCheckState(i, CheckState.Unchecked)
        Next
        chklvCentros.ClearSelected()
        For i = 0 To chklvCategorias.Items.Count - 1
            chklvCategorias.SetItemCheckState(i, CheckState.Unchecked)
        Next

        chklvCategorias.ClearSelected()
        chklvCategorias.SetItemCheckState(0, CheckState.Checked)
        chklvCategorias.SelectedIndex = 0
    End Sub

    Private Sub DetalleGanado(ByVal cons As Integer)
        If dgvCentros.Rows.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = dgvCentros.Rows(cons).Cells(4).Value.ToString.Trim
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub dgvCentros_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgvCentros.MouseDoubleClick
        If dgvCentros.Rows.Count = 0 Then Exit Sub
        ' lvCambioCategorias.SelectedItems.Item(0).SubItems(2).Text()
        If e.Button = MouseButtons.Left = True Then
            ConsultaDiio = dgvCentros.CurrentRow.ToString
            ConsultaDiio = Replace(ConsultaDiio, "DataGridViewRow { Index=", "")
            ConsultaDiio = Replace(ConsultaDiio, "}", "")
            ConsultaDiio = Convert.ToInt32(ConsultaDiio.ToString.Trim)
            DetalleGanado(ConsultaDiio)
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class