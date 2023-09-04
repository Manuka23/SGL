Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Imports System.Data.SqlClient
Public Class frmConteoAnimales
    Private param As Integer = 0
    Private orden As Integer = 1
    Private cent_ As String
    Private estProd As String
    Private diio As String
    Private ConsultaDiio As String
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub lvDetalle_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvDetalle.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvDetalle, e)
    End Sub
    Private Sub LvHistorial_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles LvHistorial.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(LvHistorial, e)
    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvRESUMEN1.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvRESUMEN1, e)
    End Sub
    Private Sub DetalleGanado()
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvDetalle.SelectedItems.Item(0).SubItems(1).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvRESUMEN1.Items.Clear()

        ConsultaSesiones()
        lvRESUMEN1.Enabled = True
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
    Public Sub ConsultaSesiones()
        diio = txtDIIO.Text
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            cent_ = ""
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteo_ReportesConteo", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@Diio", diio)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Orden", orden)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)



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
                    Dim stock As Integer = rdr("ContCantStock")
                    Dim cantok As Integer = rdr("ContCantOK")
                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("CentroNomCorto").ToString.Trim)
                    item.SubItems.Add(Format(rdr("ContFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("ContCantOK").ToString.Trim)
                    item.SubItems.Add(stock - cantok)
                    item.SubItems.Add(rdr("ContCantStock").ToString.Trim)
                    item.SubItems.Add(rdr("ContObservs").ToString.Trim)
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)
                    item.SubItems.Add(rdr("ContUsuario").ToString.Trim)



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

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        txtDIIO.Text = ""
        cboCentros.SelectedIndex = 0
        dtpFechaHasta.Value = Now
        dtpFechaDesde.Value = Now
        orden = 1
        lvRESUMEN1.Items.Clear()
        lvDetalle.Items.Clear()
        LvHistorial.Items.Clear()

        lvRESUMEN1.Enabled = False
    End Sub

    Private Sub frmConteoReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.CentrosUsuario.Cargar()
        dtpFechaDesde.Value = Now

        dtpFechaHasta.Value = DateTime.Now
        CboLLenaCentros()
        cboCentros.SelectedIndex = 0
        If ModificarDiasBaston = 1 Then
            Button1.Visible = True
        End If
    End Sub
    Private Sub dtpFechaDesde_ValueChanged_1(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub lvRESUMEN1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvRESUMEN1.MouseDoubleClick
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleConteo()
        End If
    End Sub
    Private Sub DetalleConteo()
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Dim i As Integer
        For i = 0 To lvRESUMEN1.Items.Count - 1
            If lvRESUMEN1.Items(i).Selected = True Then
                Dim centro As String = lvRESUMEN1.Items(i).SubItems(7).Text
                Dim fecha As Date = lvRESUMEN1.Items(i).SubItems(2).Text
                Dim ConsultaConteo As New frmDetalleConteo

                If centro = "" Then Exit Sub

                ConsultaConteo.MdiParent = frmMAIN
                ConsultaConteo.ConsultaSesiones(fecha, centro)

                ConsultaConteo.Show()

                Exit For
            End If

        Next

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}
        Dim linedate As String = ""
        tot(0, 0) = "Nro. Registros" : tot(0, 1) = Label10.Text


        ExportToExcelGrilla(lvRESUMEN1, tot)

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        'frmBastonV2Conteo.MdiParent = Me
        frmBastonV2Conteo.Show()
        frmBastonV2Conteo.BringToFront()
    End Sub


    Private Sub lvRESUMEN1_MouseClick(sender As Object, e As MouseEventArgs) Handles lvRESUMEN1.MouseClick
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        For i = 0 To lvRESUMEN1.Items.Count - 1
            If lvRESUMEN1.Items(i).Selected = True Then
                Dim centro As String = lvRESUMEN1.Items(i).SubItems(7).Text
                Dim fecha As Date = lvRESUMEN1.Items(i).SubItems(2).Text

                If centro = "" Then Exit Sub
                If e.Button = MouseButtons.Left = True Then
                    ConsultaDiff(lvRESUMEN1.Items(i).SubItems(2).Text, centro)
                    ConsultaHistorial(lvRESUMEN1.Items(i).SubItems(2).Text, centro)
                    Exit For
                End If
            End If

        Next
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ConsultaDiff(ByVal fech As Date, ByVal centro As String)


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteo_ReporteDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        param = 2
        cmd.Parameters.AddWithValue("@fech", fech)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@param", param)

        lvDetalle.BeginUpdate()
        lvDetalle.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    '        'Tab Diferencias
                    Dim item2 As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos
                    item2.SubItems.Add(rdr("ContDiiodif").ToString.Trim)
                    item2.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)
                    item2.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                    item2.SubItems.Add(rdr("ContObservDiio").ToString.Trim)
                    lvDetalle.Items.Add(item2)
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
        lvDetalle.EndUpdate()
        Label4.Text = i
    End Sub


    Public Sub ConsultaHistorial(ByVal fech As Date, ByVal centro As String)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteo_DiiosHistorial", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Fecha", fech)


        'lvGanado.Items.Clear()
        LvHistorial.BeginUpdate()
        LvHistorial.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("ContDiio").ToString.Trim)
                    item.SubItems.Add(rdr("Fecha1").ToString)
                    item.SubItems.Add(rdr("Fecha2").ToString)
                    item.SubItems.Add(rdr("Fecha3").ToString)
                    item.SubItems.Add(rdr("Fecha4").ToString)


                    LvHistorial.Items.Add(item)

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
        LvHistorial.EndUpdate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmDiasBastoneo.Show()
        frmDiasBastoneo.BringToFront()
    End Sub

    Private Sub txtDIIO_TextChanged(sender As Object, e As EventArgs) Handles txtDIIO.TextChanged
        orden = 0
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        orden = 0
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text = "(TODOS)" Then
            orden = 1
        End If
    End Sub

    Private Sub lvDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvDetalle.SelectedIndexChanged

    End Sub

    Private Sub lvDetalle_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvDetalle.MouseDoubleClick
        If lvDetalle.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmAlarmas.Show()
        frmAlarmas.BringToFront()
    End Sub
End Class