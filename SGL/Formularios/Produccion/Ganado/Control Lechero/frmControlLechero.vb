Imports System.Data.SqlClient
Imports System.Threading
Public Class frmControlLechero
    Private orden As Integer = 0
    Private cent_ As String
    Private Tipo As String
    Private diio As String
    Private ConsultaDiio As String
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvRESUMEN1.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvRESUMEN1, e)
    End Sub
    Private Sub btnAgregar_Click_1(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmControlLecheroIngreso.MdiParent = frmMAIN
        frmControlLecheroIngreso.Show()
        frmControlLecheroIngreso.BringToFront()
    End Sub
    Public Sub ConsultaControlLechero()
        diio = txtDIIO.Text
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            cent_ = ""
        End If
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spControlLechero_LLenadoReportes", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", diio)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Orden", orden)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        'lvGanado.Items.Clear()
        lvRESUMEN1.BeginUpdate()
        lvRESUMEN1.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1
                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("CoLeCentro").ToString.Trim)
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(rdr("recuento").ToString.Trim)
                    item.SubItems.Add(Format(rdr("CoLeFechaControl"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("CoLeUsuarioReg").ToString.Trim)
                    item.SubItems.Add(rdr("CoLeFechaReg").ToString.Trim)
                    item.SubItems.Add(rdr("CoLeLote").ToString.Trim)
                    lvRESUMEN1.Items.Add(item)

                End While


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvRESUMEN1.EndUpdate()
        Label10.Text = i.ToString.Trim
    End Sub
    Private Sub frmControlLecheroReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.TiposControlLechero.Cargar()
        dtpFechaDesde.Value = Now
        dtpFechaHasta.Value = Now
        CboLLenaCentros()
        cboCentros.SelectedIndex = 0
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")
        Dim i As Integer
        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub
    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        'cent_ = cboCentros.SelectedIndex
        orden = 0
    End Sub
    Private Sub dtpFechaDesde_ValueChanged_1(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
        If dtpFechaHasta.Value <> dtpFechaDesde.Value Then
            orden = 1
        End If
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        txtDIIO.Text = ""
        cboCentros.SelectedIndex = 0
        dtpFechaHasta.Value = Now
        dtpFechaDesde.Value = Now
        orden = 0
        lvRESUMEN1.Items.Clear()
    End Sub

    Private Sub lvRESUMEN1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvRESUMEN1.MouseDoubleClick
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub
    Private Sub DetalleGanado()
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim CentroCod As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(1).Text
        Dim FechaControl As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(4).Text
        Dim Lote As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(7).Text
        Dim ConsultaControlLechero As New frmControlLecheroDetalle

        ConsultaControlLechero.MdiParent = frmMAIN
        'ConsultaControlLechero.lblDIIO.Text = diio
        ConsultaControlLechero.ControlLecheroDetalle(CentroCod, FechaControl, Lote)

        ConsultaControlLechero.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvRESUMEN1.Items.Clear()

        ConsultaControlLechero()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "Nro. Registros" : tot(0, 1) = Label10.Text


        ExportToExcelGrilla(lvRESUMEN1, tot)
    End Sub

    Private Sub lvRESUMEN1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvRESUMEN1.SelectedIndexChanged

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btncargarexcel_Click(sender As Object, e As EventArgs) Handles btncargarexcel.Click
        frmControlLecheExcel.Show()
    End Sub
End Class