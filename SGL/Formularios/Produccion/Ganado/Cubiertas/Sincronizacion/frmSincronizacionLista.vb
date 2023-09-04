Imports System.Data.SqlClient
Imports System.Threading
Public Class frmSincronizacionLista
    Private cent_ As String
    Private diio As String
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub frmSincronizacionLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        dtpFechaDesde.Value = Date.Now

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
        'cboCentros.SelectedIndex = -1
    End Sub
    Private Sub btnAlarmas_Click(sender As Object, e As EventArgs) Handles btnAlarmas.Click
        ExportarAlarmasBaston()
    End Sub

    Private Sub ExportarAlarmasBaston()
        If lvDiios.Items.Count = 0 Then Exit Sub
        ExportToExcelGrillaAlarmas(lvDiios, 3)
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvDiios.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}


        ExportToExcelGrilla(lvDiios, tot)
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultaSincronizacion()
    End Sub
    Public Sub ConsultaSincronizacion()
        lvDiios.Items.Clear()
        Thread.Sleep(20)
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            cent_ = ""
        End If
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spIATF_PlanillaSinc", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Lactancia", txtLactancia.Text)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value) ' Mid(dtpFechaDesde.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        'lvGanado.Items.Clear()
        lvDiios.BeginUpdate()
        lvDiios.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("Centro").ToString.Trim)
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)
                    item.SubItems.Add(rdr("Diio").ToString.Trim)
                    item.SubItems.Add(rdr("Categoria").ToString.Trim)
                    item.SubItems.Add(rdr("UltimoParto"))
                    If rdr("UltimaCubierta") < "01-01-1999" Then
                        item.SubItems.Add("")
                    Else
                        item.SubItems.Add(rdr("UltimaCubierta"))
                    End If
                    If rdr("UltCubiertaExitosa") < "01-01-1999" Then
                        item.SubItems.Add("")
                    Else
                        item.SubItems.Add(rdr("UltCubiertaExitosa"))
                    End If
                    item.SubItems.Add(rdr("EstProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("EstReproductivo").ToString.Trim)
                    '                item.SubItems.Add(rdr("CIDR"))

                    lvDiios.Items.Add(item)
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
        Label10.Text = i
        lvDiios.EndUpdate()

    End Sub

    Private Sub btnLimpiarFiltro_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltro.Click

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub lvRESUMEN1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvDiios.MouseDoubleClick
        If lvDiios.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvDiios.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvDiios, e)
    End Sub
    Private Sub DetalleGanado()
        If lvDiios.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvDiios.SelectedItems.Item(0).SubItems(3).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


End Class