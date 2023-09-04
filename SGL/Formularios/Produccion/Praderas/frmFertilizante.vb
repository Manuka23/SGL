Imports System.Data.SqlClient

Public Class frmFertilizante
    Private Sub frmFertilizante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8
        dtpFechaDesde.Value = DateTime.Now.AddMonths(-1)
        'btnPurin se deja oculto ya que no se usara, la informacion se obtendra del ingreso diario (ingreso purines)
        CboLLenaCentros()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmIngresoFertilizante.Show()
        frmIngresoFertilizante.BringToFront()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        BuscarFertilizados()
    End Sub
    Private Sub BuscarFertilizados()
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spFertilizante_Buscar", con)
        Dim rdr As SqlDataReader = Nothing

        Dim i As Integer = 0
        Dim Centro As Integer = 0

        If cboCentros.Text = "(TODOS)" Then
            Centro = 0
        Else
            Centro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        cmd.CommandType = Data.CommandType.StoredProcedure

        Try

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", Centro)
            cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
            cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)

            con.Open()
            rdr = cmd.ExecuteReader()

            lvFertilizado.BeginUpdate()
            lvFertilizado.Items.Clear()

            Try

                While rdr.Read()

                    Dim item As New ListViewItem((i + 1).ToString.Trim) 'N°

                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)
                    item.SubItems.Add(rdr("Centro").ToString.Trim)
                    item.SubItems.Add(Format(rdr("Fecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("TotalPotrero").ToString.Trim)
                    item.SubItems.Add(rdr("PotAplicado").ToString.Trim)
                    item.SubItems.Add(Convert.ToDouble(rdr("Hectareas")).ToString("N1").Trim())
                    item.SubItems.Add(rdr("HaAplicado").ToString.Trim)
                    item.SubItems.Add(rdr("FertNitrogenado").ToString.Trim)
                    item.SubItems.Add(rdr("FertilizanteCod").ToString.Trim)
                    item.SubItems.Add(rdr("Fertilizante").ToString.Trim)
                    item.SubItems.Add(rdr("TotalFerAplicado").ToString.Trim)
                    item.SubItems.Add(rdr("CodGP").ToString.Trim)
                    item.SubItems.Add(rdr("FechaReg").ToString.Trim)
                    item.SubItems.Add(rdr("UsuarioCreacion").ToString.Trim)


                    lvFertilizado.Items.Add(item)

                    i = i + 1
                End While

                If i = 0 Then
                    MsgBox("NO SE ENCONTRARON DATOS", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "INFORMACIÓN")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            rdr.Close()
            cmd.Dispose()
            con.Close()
        End Try

        lvFertilizado.EndUpdate()
        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()

        Dim i As Integer

        cboCentros.Items.Add("(TODOS)")

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 1
    End Sub

    Private Sub lvFertilizado_DoubleClick(sender As Object, e As EventArgs) Handles lvFertilizado.DoubleClick

        frmIngresoFertilizante.CentroEnc = lvFertilizado.SelectedItems.Item(0).SubItems(2).Text
        frmIngresoFertilizante.CentroEncNom = lvFertilizado.SelectedItems.Item(0).SubItems(3).Text
        frmIngresoFertilizante.FechaEnc = lvFertilizado.SelectedItems.Item(0).SubItems(4).Text
        frmIngresoFertilizante.FertilizanteCod = lvFertilizado.SelectedItems.Item(0).SubItems(10).Text
        frmIngresoFertilizante.Show()
    End Sub
End Class