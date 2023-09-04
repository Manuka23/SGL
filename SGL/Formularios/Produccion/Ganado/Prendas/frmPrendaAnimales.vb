Imports System.Data.SqlClient
Public Class frmPrendaAnimales

    Private orden As Integer = 0
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub CboLLenaBancos()
        If General.Bancos.NroRegistros = 0 Then Exit Sub

        cboBancos.Items.Clear()
        cboBancos.Items.Add("(TODOS)")
        Dim i As Integer

        For i = 0 To General.Bancos.NroRegistros - 1
            cboBancos.Items.Add(General.Bancos.Nombre(i))
        Next
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvPrendados.Items.Clear()
        LlenaGrillaBancoss()

    End Sub
    Private Sub lvPrendados_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvPrendados.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvPrendados, e)
    End Sub
    Public Sub LlenaGrillaBancoss()
        Dim cent_ As String

        If cboBancos.SelectedIndex <> -1 And cboBancos.Text <> "(TODOS)" Then
            cent_ = General.Bancos.Codigo(cboBancos.SelectedIndex - 1)
        Else
            cent_ = ""
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaSecados(cent_, txtDIIO.Text.Trim)
        Cursor.Current = Cursors.Default
    End Sub


    Public Sub ConsultaSecados(ByVal cent_ As String, ByVal diio_ As String)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPrendaAnimales_LlenadoPrendas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Banco", cent_)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        cmd.Parameters.AddWithValue("@Orden", orden)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        'lvGanado.Items.Clear()
        lvPrendados.BeginUpdate()
        lvPrendados.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos
                    item.Checked = False
                    item.SubItems.Add(rdr("PrnEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("PrnCentro").ToString.Trim)
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(Format(rdr("PrnFecha"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("PrnNumeroDiios").ToString.Trim)
                    item.SubItems.Add(rdr("PrnNomBanco").ToString.Trim)
                    item.SubItems.Add(rdr("PrnCodBanco").ToString.Trim)

                    lvPrendados.Items.Add(item)

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
        lvPrendados.EndUpdate()
        Label10.Text = i.ToString.Trim
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBancos.SelectedIndexChanged
        'Dim cent_ As String = General.Bancos.Codigo(cboBancos.SelectedIndex )
        btnBuscar.Enabled = True

        If cboBancos.SelectedIndex = -1 Or cboBancos.Text = "(TODOS)" Then
            btnBuscar.Enabled = False
        End If
    End Sub
    Private Sub dtpFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
        If dtpFechaHasta.Value <> dtpFechaDesde.Value Then
            orden = 1
            btnBuscar.Enabled = True

        End If

    End Sub
    Private Sub frmInicioPrendaAnimales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        dtpFechaDesde.Value = Now
        dtpFechaHasta.Value = Now
        CboLLenaBancos()
        '  cboBancos.SelectedIndex = 0
        ' dtpFechaHasta.Value = Now
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmPrendaAnimalesPorCentros.MdiParent = frmMAIN
        frmPrendaAnimalesPorCentros.Show()
        frmPrendaAnimalesPorCentros.BringToFront()

    End Sub

    Private Sub txtDIIO_TextChanged(sender As Object, e As EventArgs) Handles txtDIIO.TextChanged
        If txtDIIO.Text = "" Then
            btnBuscar.Enabled = False
        Else
            btnBuscar.Enabled = True
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvPrendados.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "Nro. Potreros" : tot(0, 1) = Label10.Text
        'tot(1, 0) = "CASOS EN TRATAMIENTO" : tot(1, 1) = Label6.Text
        'tot(2, 0) = "CASOS EN RESGUARDO" : tot(2, 1) = Label8.Text

        ExportToExcelGrilla(lvPrendados, tot)
    End Sub

    Private Sub dtpFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaHasta.ValueChanged
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmPrendaAnimalesDiios.MdiParent = frmMAIN
        frmPrendaAnimalesDiios.Show()
        frmPrendaAnimalesDiios.BringToFront()

    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        cboBancos.SelectedIndex = 0
        txtDIIO.Text = ""
        dtpFechaHasta.Value = Now
        dtpFechaDesde.Value = Now
        orden = 0
        lvPrendados.Items.Clear()
        btnBuscar.Enabled = False
    End Sub
End Class