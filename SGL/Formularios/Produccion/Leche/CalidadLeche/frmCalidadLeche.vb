Imports System.Data.SqlClient
Imports System.Threading
Public Class frmCalidadLeche

    Private orden As Integer = 1
    Private cent_ As String
    Private planta As String
    Private radi As String
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvRESUMEN1.Items.Clear()

        ConsultaCalidad()
    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvRESUMEN1.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvRESUMEN1, e)
    End Sub

    Public Sub ConsultaCalidad()
        Thread.Sleep(20)
        If cboPlantas.SelectedIndex <> -1 And cboPlantas.Text <> "(TODOS)" Then
            planta = General.Plantas.Codigo(cboPlantas.SelectedIndex - 1)
        Else
            planta = ""
        End If
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            cent_ = ""
        End If
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCalidadLeche_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Planta", planta)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@TipoIngresoSolido", radi)
        cmd.Parameters.AddWithValue("@Orden", orden)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 24))
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

                    item.SubItems.Add(rdr("NombrePlanta").ToString.Trim)
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(rdr("NombreSolido").ToString.Trim)
                    item.SubItems.Add(rdr("CantidadSolido").ToString.Trim)
                    item.SubItems.Add(rdr("TipoIngresoSolido").ToString.Trim)
                    item.SubItems.Add(Format(rdr("FechaIngresoSolido"), "dd-MM-yyyy HH:mm"))
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

    Private Sub ReporteCalidadLeche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaDesde.Value = Now
        dtpFechaHasta.Value = Now
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.Plantas.Cargar()
        General.Solidos.Cargar()
        General.Proveedores.Cargar()
        CboLLenaCentros()
        CboLLenaPlantas()
        'cboPlantas.SelectedIndex = 0
        'cboCentros.SelectedIndex = 0


    End Sub
    Private Sub CboLLenaPlantas()
        If General.Plantas.NroRegistros = 0 Then Exit Sub

        cboPlantas.Items.Clear()
        cboPlantas.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Plantas.NroRegistros - 1

            cboPlantas.Items.Add(General.Plantas.Nombre(i))
        Next
        cboPlantas.SelectedIndex = 0
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next


        cboCentros.SelectedIndex = 0
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        CalidadLecheIngreso3.MdiParent = frmMAIN
        CalidadLecheIngreso3.Show()
        CalidadLecheIngreso3.BringToFront()

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

    Private Sub dtpFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaHasta.ValueChanged

    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        orden = 0

        If cboCentros.SelectedIndex = -1 Or cboCentros.Text = "(TODOS)" Then
            orden = 1
        End If
    End Sub

    Private Sub cboPlantas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPlantas.SelectedIndexChanged
        planta = General.Plantas.Codigo(cboPlantas.SelectedIndex)

        orden = 0

        If cboPlantas.SelectedIndex = -1 Or cboPlantas.Text = "(TODOS)" Then
            orden = 1
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            radi = RadioButton1.Text

        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            radi = RadioButton2.Text

        End If

    End Sub

    Private Sub dtpFechaDesde_ValueChanged_1(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
        If dtpFechaHasta.Value <> dtpFechaDesde.Value Then

        End If
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        RadioButton2.Checked = False
        RadioButton1.Checked = False
        cboCentros.SelectedIndex = 0
        cboPlantas.SelectedIndex = 0
        dtpFechaHasta.Value = Now
        dtpFechaDesde.Value = Now
        orden = 1
        lvRESUMEN1.Items.Clear()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 

    End Sub
End Class