Imports System.Data.SqlClient
Imports System.Threading
Public Class frmReportesCambioRazas

    Private orden As Integer = 1
    Private cent_ As String
    Private diio As String
    Private ConsultaDiio As String
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub frmReporteCambioRazas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        dtpFechaDesde.Value = Date.Now
        dtpFechaHasta.Value = Date.Now
        CboLLenaCentros()
        cboCentros.SelectedIndex = 0

        ConsultaCambioRazas()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmCambioRazasIngresar.MdiParent = frmMAIN
        frmCambioRazasIngresar.Show()
        frmCambioRazasIngresar.BringToFront()

    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvRESUMEN1.Items.Clear()

        ConsultaCambioRazas()
    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvRESUMEN1.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvRESUMEN1, e)
    End Sub
    Public Sub ConsultaCambioRazas()
        lvRESUMEN1.Items.Clear()
        Thread.Sleep(20)
        diio = txtDIIO.Text
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            cent_ = ""
        End If
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCambioRazas_LlenadoReportes", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", diio)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Orden", orden)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value) ' Mid(dtpFechaDesde.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value) 'Mid(dtpFechaHasta.Value.ToString, 1, 24))
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

                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(rdr("CRFecha").ToString.Trim)
                    item.SubItems.Add(rdr("CRDiio").ToString.Trim)
                    item.SubItems.Add(rdr("CRRazaNomAnt").ToString.Trim)
                    item.SubItems.Add(rdr("CRRazaNomNuevo").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(rdr("Usuario").ToString.Trim)
                    item.SubItems.Add(rdr("Equipo").ToString.Trim)

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



    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")
        Dim i As Integer
        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
        'cboCentros.SelectedIndex = -1
    End Sub



    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "Nro. Registros" : tot(0, 1) = Label10.Text


        ExportToExcelGrilla(lvRESUMEN1, tot)
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        orden = 0
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text = "(TODOS)" Then
            orden = 1
        End If
    End Sub



    Private Sub dtpFechaDesde_ValueChanged_1(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged
        'If dtpFechaHasta.Value < dtpFechaDesde.Value Then
        '    dtpFechaHasta.Value = dtpFechaDesde.Value
        'End If

    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        txtDIIO.Text = ""
        cboCentros.SelectedIndex = 0
        dtpFechaHasta.Value = Date.Now
        dtpFechaDesde.Value = Date.Now
        orden = 1
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

        Dim diio As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(3).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub txtDIIO_TextChanged(sender As Object, e As EventArgs) Handles txtDIIO.TextChanged
        orden = 0
    End Sub

    Private Sub lvRESUMEN1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvRESUMEN1.SelectedIndexChanged

    End Sub
End Class