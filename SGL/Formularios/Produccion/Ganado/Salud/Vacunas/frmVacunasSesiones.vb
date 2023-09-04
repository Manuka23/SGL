Imports System.Data.SqlClient
Imports System.Threading
Imports Microsoft.Reporting.WinForms
Public Class frmVacunasSesiones
    Private orden As Integer = 1
    Private cent_ As String
    Public vacuna As String
    Public FechaDesde As DateTime
    Public FechaHasta As DateTime
    Public indexCbo As Integer
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvRESUMEN1.Items.Clear()

        ConsultaGndVacunado()
    End Sub

    Private Sub frmVacunasSesiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        dtpFechaHasta.Value = Date.Now
        CboLLenaCentros()
        txtVac.Text = vacuna
        cboCentros.SelectedIndex = indexCbo
        dtpFechaDesde.Text = FechaDesde
        dtpFechaHasta.Text = FechaHasta
        ConsultaGndVacunado()
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
    Public Sub ConsultaGndVacunado()
        lvRESUMEN1.Items.Clear()
        Thread.Sleep(20)
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            cent_ = ""
        End If
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_ResumenVacunas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Vacuna", txtVac.Text)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Orden", orden)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value) ' Mid(dtpFechaDesde.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value) 'Mid(dtpFechaHasta.Value.ToString, 1, 24))

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
                    item.SubItems.Add(rdr("nombrecentro").trim.ToString)
                    item.SubItems.Add(rdr("vacuna").trim.ToString)
                    item.SubItems.Add(rdr("Cantidad"))
                    item.SubItems.Add(Format(rdr("Fecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("equipo").trim.ToString)
                    item.SubItems.Add(rdr("usuario").trim.ToString)
                    item.SubItems.Add(rdr("centrocod").trim.ToString)

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

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}
        ExportToExcelGrilla(lvRESUMEN1, tot)
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        txtVac.Text = ""
        cboCentros.SelectedIndex = 0
        dtpFechaHasta.Value = Date.Now
        dtpFechaDesde.Value = Date.Now
        orden = 1
        lvRESUMEN1.Items.Clear()

    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        orden = 0
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text = "(TODOS)" Then
            orden = 1
        End If
    End Sub

    Private Sub dtpFechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged
        orden = 1
    End Sub

    Private Sub lvRESUMEN1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvRESUMEN1.SelectedIndexChanged

    End Sub

    Private Sub lvRESUMEN1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvRESUMEN1.MouseDoubleClick
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
            Me.Close()
        End If
    End Sub
    Private Sub DetalleGanado()
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim vacuna As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(2).Text
        Dim centro As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(7).Text
        Dim fecha As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(4).Text
        Dim ConsultaVac As New frmVacunas

        If vacuna = "" Then Exit Sub
        frmVacunas.Close()
        ConsultaVac.MdiParent = frmMAIN
        ConsultaVac.txtVac.Text = vacuna
        ConsultaVac.centroResumen = centro
        ConsultaVac.fechaResumen = fecha
        ConsultaVac.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class