Imports System.Data.SqlClient
Imports System.Threading
Imports Microsoft.Reporting.WinForms
Imports System.IO

Public Class frmVacunas
    Private VacSesiones As frmVacunasSesiones
    Private orden As Integer = 1
    Private cent_ As String
    Private fnVacunados As New fnVacunados
    Public centroResumen As String = ""
    Public fechaResumen As String = ""
    Private vacuna As String


    Dim Diio As String
    Dim Vac As String
    Dim FechaElim As DateTime

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
        frmVacunasIngresoVacunacion.MdiParent = frmMAIN
        frmVacunasIngresoVacunacion.Show()
        frmVacunasIngresoVacunacion.BringToFront()
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
        Dim cmd As New SqlCommand("spVacunas_ListadoVacunacion", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", vacuna)
        cmd.Parameters.AddWithValue("@Vacuna", txtVac.Text)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Orden", orden)
        If centroResumen <> "" Then
            cmd.Parameters.AddWithValue("@FechaDesde", fechaResumen) ' Mid(dtpFechaDesde.Value.ToString, 1, 24))
            cmd.Parameters.AddWithValue("@FechaHasta", fechaResumen) 'Mid(dtpFechaHasta.Value.ToString, 1, 24))
        Else
            cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value) ' Mid(dtpFechaDesde.Value.ToString, 1, 24))
            cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value) 'Mid(dtpFechaHasta.Value.ToString, 1, 24))
        End If
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

                    item.SubItems.Add(rdr("CentroVacunacion").trim.ToString)
                    item.SubItems.Add(rdr("diio").trim.ToString.Trim)
                    item.SubItems.Add(rdr("NombreVacuna").trim.ToString)
                    item.SubItems.Add(Format(rdr("FechaVacunacion"), "dd/MM/yyyy"))
                    item.SubItems.Add(rdr("Usuario").trim.ToString)
                    item.SubItems.Add(rdr("Equipo").trim.ToString)
                    item.SubItems.Add(rdr("cod").trim.ToString)
                    item.SubItems.Add(rdr("ProductoCuenta"))
                    item.SubItems.Add(rdr("ItemGasto"))
                    item.SubItems.Add(rdr("CentroCod"))
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
        txtVac.Text = ""
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

    Private Sub txtVac_TextChanged(sender As Object, e As EventArgs) Handles txtVac.TextChanged

    End Sub

    Private Sub txtVac_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVac.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            lvRESUMEN1.Items.Clear()

            ConsultaGndVacunado()
            e.Handled = True
        End If
    End Sub

    Private Sub txtVacuna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVacuna.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            lvRESUMEN1.Items.Clear()

            ConsultaGndVacunado()
            e.Handled = True
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿ DESEA ELIMINAR LAS VACUNACIONES REALIZADAS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If Elimina() = True Then
            EliminarVacunacion()
            fnVacunados.VaciaDatatable()
            lvRESUMEN1.Items.Clear()

            ConsultaGndVacunado()
        End If
    End Sub
    Private Function Elimina()
        Dim linea As Integer

        For Each it As ListViewItem In lvRESUMEN1.SelectedItems
            linea = lvRESUMEN1.Items.IndexOf(it)
            Elimina = False

            Diio = lvRESUMEN1.Items(linea).SubItems(2).Text
            Vac = lvRESUMEN1.Items(linea).SubItems(7).Text
            FechaElim = lvRESUMEN1.Items(linea).SubItems(4).Text
            Dim Nombre As String = lvRESUMEN1.Items(linea).SubItems(3).Text
            Dim CuentasContables As String = lvRESUMEN1.Items(linea).SubItems(8).Text
            Dim ItemActivation As String = lvRESUMEN1.Items(linea).SubItems(9).Text
            Dim centro As String = lvRESUMEN1.Items(linea).SubItems(10).Text
            Dim Fecha As DateTime = lvRESUMEN1.Items(linea).SubItems(4).Text

            fnVacunados.DtExcelCrearEliminaGP()
            fnVacunados.DtExcelEliminarGP(Vac, Nombre, 1, CuentasContables, ItemActivation, "", "")
            EliminarVacunacionGP(fnVacunados.EliminarDetallesExcelGP, 1, Centro, Fecha)
            fnVacunados.VaciaDatatableGP()
        Next
        Elimina = True
    End Function
    Private Sub EliminarVacunacionGP(ByVal DetalleConsumos As DataTable, ByVal TipoConsumo As Integer, ByVal centro As String, ByVal fecha As Date)
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPConsumos_GrabarElimina", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim cau_ As Integer = 0
        Dim fec_, hr_ As String
        Dim fh_ As DateTime
        Dim bodORI_ As String = "01"

        fec_ = Format(fecha, "dd-MM-yyyy")
        hr_ = Format(Now, "HH:mm:ss")
        fh_ = Convert.ToDateTime(fec_ + " " + hr_)


        If cboCentros.SelectedIndex <> -1 Then
            bodORI_ = centro.Substring(0, 5)
        Else
            MsgBox("Error al recuperar codigo de la bodega del Origen. Contacte a IT.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", bodORI_)
        cmd.Parameters.AddWithValue("@Fecha", fh_)
        ''
        cmd.Parameters.AddWithValue("@TablaDetalle", DetalleConsumos)
        ''
        cmd.Parameters.AddWithValue("@TipoConsumo", TipoConsumo)

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetIDGP", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetIDGP").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Dim id As String = cmd.Parameters("@RetIDGP").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Sub
    Public Sub EliminarVacunacion()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_EliminaVacunacion", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.AddWithValue("@Diio", Diio)
        cmd.Parameters.AddWithValue("@Vacuna", Vac)
        cmd.Parameters.AddWithValue("@Fecha", FechaElim)

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
    Private Sub lvRESUMEN1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvRESUMEN1.SelectedIndexChanged

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

    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub

    Private Sub mnuCopiarDiio_Click(sender As Object, e As EventArgs) Handles mnuCopiarDiio.Click
        If lvRESUMEN1.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvRESUMEN1.SelectedItems(0).SubItems(2).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub

    Private Sub btnBastonLimpia_Click(sender As Object, e As EventArgs) Handles btnBastonLimpia.Click
        VacSesiones = New frmVacunasSesiones
        VacSesiones.vacuna = txtVac.Text
        VacSesiones.FechaDesde = dtpFechaDesde.Value
        VacSesiones.FechaHasta = dtpFechaHasta.Value
        VacSesiones.indexCbo = cboCentros.SelectedIndex
        VacSesiones.ShowDialog()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class