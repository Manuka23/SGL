Imports System.Data.SqlClient
Imports System.Threading
Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class frmInducciones
    Private Resumen As frmPartosInduccionesResumen
    Private orden As Integer = 1
    Private cent_ As String
    Public centroResumen As String = ""
    Public fechaResumen As String = ""
    Private frInducciones As New frInducciones
    Private fnInduccionesGrabar As New fnInduccionesGrabar
    Private vacuna As String
    Private ConsultaDiio As String
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub frmVacunas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        dtpFechaHasta.Value = Date.Now
        CboLLenaCentros()
        cboCentros.SelectedIndex = 0
        dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
        ConsultaGndVacunado()
    End Sub



    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmPartosInducciones.MdiParent = frmMAIN
        frmPartosInducciones.Show()
        frmPartosInducciones.BringToFront()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvRESUMEN1.Items.Clear()

        ConsultaGndVacunado()
    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvRESUMEN1.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvRESUMEN1, e)
    End Sub
    Public Sub ConsultaGndVacunado()
        lvRESUMEN1.Items.Clear()
        Thread.Sleep(20)
        vacuna = txtVacuna.Text
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            cent_ = ""
        End If
        If centroResumen <> "" Then
            cent_ = centroResumen
        End If
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spInduccion_Listar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", vacuna)
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

                    item.SubItems.Add(rdr("Centro").trim.ToString)
                    item.SubItems.Add(rdr("diio").trim.ToString.Trim)
                    item.SubItems.Add(rdr("Categoria").trim.ToString)
                    item.SubItems.Add(rdr("InducEstProd").trim.ToString)
                    item.SubItems.Add(rdr("InducEstReprod").trim.ToString)
                    item.SubItems.Add(Format(rdr("FechaInduccion"), "dd/MM/yyyy"))
                    item.SubItems.Add(Format(rdr("FPParto"), "dd/MM/yyyy"))
                    item.SubItems.Add(rdr("cod").trim.ToString)

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
        centroResumen = ""
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


        ExportToExcelGrilla(lvRESUMEN1, tot)
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        'cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        orden = 0
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text = "(TODOS)" Then
            orden = 1
        End If
    End Sub



    Private Sub dtpFechaDesde_ValueChanged_1(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged
        'If dtpFechaHasta.Value < dtpFechaDesde.Value Then
        '    dtpFechaHasta.Value = dtpFechaDesde.Value
        'End If
        orden = 1
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        txtVacuna.Text = ""
        cboCentros.SelectedIndex = 0
        dtpFechaHasta.Value = Date.Now
        dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
        orden = 1
        lvRESUMEN1.Items.Clear()


    End Sub

    Private Sub txtDIIO_TextChanged(sender As Object, e As EventArgs) Handles txtVacuna.TextChanged
        orden = 0
    End Sub

    Private Sub txtVacuna_LostFocus(sender As Object, e As EventArgs) Handles txtVacuna.LostFocus
        If txtVacuna.Text = "" Then
            orden = 1
        Else

            orden = 0
        End If

    End Sub


    Private Sub txtVacuna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVacuna.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            lvRESUMEN1.Items.Clear()

            ConsultaGndVacunado()
            e.Handled = True
        End If
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

        Dim diio As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(2).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿ DESEA ELIMINAR LAS INDUCCIONES SELECCIONADAS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If Elimina() = True Then
            EliminarVacunacion()
            frInducciones.VaciaDatatable()
            lvRESUMEN1.Items.Clear()

            ConsultaGndVacunado()
        End If
    End Sub
    Private Function Elimina()
        Dim linea As Integer
        frInducciones.DtExcelCrearElimina()
        For Each it As ListViewItem In lvRESUMEN1.SelectedItems
            linea = lvRESUMEN1.Items.IndexOf(it)
            Elimina = False

            Dim Diio As String = lvRESUMEN1.Items(linea).SubItems(2).Text
            Dim Centro As String = lvRESUMEN1.Items(linea).SubItems(8).Text
            Dim Fecha As String = lvRESUMEN1.Items(linea).SubItems(6).Text
            frInducciones.DtExcelEliminar(Diio, Centro, Fecha)

        Next
        Elimina = True
    End Function
    Public Sub EliminarVacunacion()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spInduccion_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.AddWithValue("@TablaDetalle", frInducciones.EliminarDetallesExcel)

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
            rdr = cmd.ExecuteReader()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnBastonLimpia_Click(sender As Object, e As EventArgs) Handles btnBastonLimpia.Click

        Resumen = New frmPartosInduccionesResumen
        Resumen.Diio = txtVacuna.Text
        Resumen.FechaDesde = dtpFechaDesde.Value
        Resumen.FechaHasta = dtpFechaHasta.Value
        Resumen.indexCbo = cboCentros.SelectedIndex
        Resumen.ShowDialog()
    End Sub
End Class