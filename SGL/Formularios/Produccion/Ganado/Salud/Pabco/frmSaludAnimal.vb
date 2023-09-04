
Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient

Public Class frmSaludAnimal
    Private NroRegistros As Integer = 0



    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(4, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL CASOS" : tot(0, 1) = lblTotalCasos.Text
        tot(1, 0) = "TOTAL EN TRATAMIENTO" : tot(1, 1) = lblEnTratamiento.Text
        tot(2, 0) = "TOTAL EN RESGUARDO LECHE" : tot(2, 1) = lblResguardo.Text
        tot(3, 0) = "TOTAL EN RESGUARDO CARNE" : tot(3, 1) = LblCarne.Text
        tot(4, 0) = "TOTAL PREVENTIVOS" : tot(4, 1) = lblPreventivos.Text

        ExportToExcelGrilla(lvGanado, tot)
    End Sub
    Private Sub lvFARMACOS_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor


        Dim cent_ As String = lvGanado.SelectedItems.Item(0).SubItems(2).Text          'centro
        Dim nomcent_ As String = lvGanado.SelectedItems.Item(0).SubItems(3).Text       'nombre centro

        If cent_.Trim = "" Then Exit Sub

        With frmPabcoLotes

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            .cboCentros.Text = nomcent_
            .dtpFechaDesde.Value = dtpFechaDesde.Value
            .dtpFechaHasta.Value = dtpFechaHasta.Value

            .btnBuscar.PerformClick()
        End With


        Cursor.Current = Cursors.Default

        'frmPabcoLotes.ShowDialog()
        'If e.Button = MouseButtons.Left = True Then
        '    DetalleTratamiento()
        'End If

    End Sub

    Private Sub DetalleTratamiento()

        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim Cent As String = lvGanado.SelectedItems.Item(0).SubItems(2).Text           'empresa

        With frmListadoTratamientos

            .cent_ = Cent
            .dtpFechaDesde.Value = dtpFechaDesde.Value
            .dtpFechaHasta.Value = dtpFechaHasta.Value
            .Label3.Text = "Tratamientos Sala " + lvGanado.SelectedItems.Item(0).SubItems(3).Text
            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub frmSaludAnimal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now

        CboLLenaCentros()
        btnBuscar.PerformClick()
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        Cursor.Current = Cursors.WaitCursor

        ConsultaSaludAnimal(cent_)

    End Sub
    Public Sub ConsultaSaludAnimal(ByVal cent_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        Dim SumaTrat As Integer
        Dim SumaEnTrat As Integer
        Dim SumaLeche As Integer
        Dim SumaCarne As Integer
        Dim SumaPreven As Integer
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(rdr("SumaTrat").ToString.Trim)                                'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("SumaTratamiento").ToString.Trim)                                'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("SumaResguardoLeche").ToString.Trim)
                    item.SubItems.Add(rdr("SumaResguardoCarne").ToString.Trim)
                    item.SubItems.Add(rdr("SumaTratPreventivos").ToString.Trim)
                    item.SubItems.Add("")
                    lvGanado.Items.Add(item)

                    SumaTrat = SumaTrat + rdr("SumaTrat")
                    SumaEnTrat = SumaEnTrat + rdr("SumaTratamiento")
                    SumaLeche = SumaLeche + rdr("SumaResguardoLeche")
                    SumaCarne = SumaCarne + rdr("SumaResguardoCarne")
                    SumaPreven = SumaPreven + rdr("SumaTratPreventivos")


                    i = i + 1
                End While

                lblTotalCasos.Text = SumaTrat
                lblEnTratamiento.Text = SumaEnTrat
                lblResguardo.Text = SumaLeche
                LblCarne.Text = SumaCarne
                lblPreventivos.Text = SumaPreven

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvGanado.EndUpdate()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmIngresoTratamientos.MdiParent = frmMAIN
        frmIngresoTratamientos.Show()
        frmIngresoTratamientos.BringToFront()
    End Sub

    Private Sub btnTratamientosEnCurso_Click(sender As Object, e As EventArgs) Handles btnTratamientosEnCurso.Click
        frmTratamientosEnCurso.MdiParent = frmMAIN
        frmTratamientosEnCurso.Show()
        frmTratamientosEnCurso.BringToFront()
    End Sub
End Class