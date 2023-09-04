Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports CustomExtensions

Public Class frmGenetica
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmGenetica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        dtpFechaDesde.Value = (DateTime.Now - TimeSpan.FromDays(60))

        GeneticaBuscar()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim FechaUltReg As String

        If lvGenetica.Items.Count = 0 Then
            FechaUltReg = "01-01-1999"
        Else
            FechaUltReg = lvGenetica.Items(0).SubItems(7).Text
        End If

        frmGeneticaIngreso.UltimoReg = FechaUltReg
        frmGeneticaIngreso.MdiParent = frmMAIN
        frmGeneticaIngreso.Show()
        frmGeneticaIngreso.BringToFront()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        GeneticaBuscar()
    End Sub
    Public Sub GeneticaBuscar()
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spToros_GeneticaBuscarListado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)

        lvGenetica.BeginUpdate()
        lvGenetica.Items.Clear()

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, correlativo

                    item.SubItems.Add(rdr("ABCode").ToString.Trim)
                    item.SubItems.Add(rdr("ABName").ToString.Trim)
                    item.SubItems.Add(rdr("BreedCat").ToString.Trim)
                    item.SubItems.Add(rdr("BW").ToString.Trim)
                    item.SubItems.Add(rdr("Usuario").ToString.Trim)
                    item.SubItems.Add(Format(rdr("Fecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(Format(rdr("FechaUltReg"), "dd-MM-yyyy"))
                    lvGenetica.Items.Add(item)
                    i = i + 1

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        lvGenetica.EndUpdate()
        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ExportToExcelGrilla(lvGenetica)
    End Sub
    Public Sub ExportToExcelGrilla(ByVal Genetica As ListView)
        Dim lin, col As Integer
        Dim columns As String = ""
        'Dim linedat As String = ""
        Dim linedat As New StringBuilder

        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'volcamos titulos del listview
        For col = 1 To Genetica.Columns.Count - 1
            'If grilla.Columns(col).Width > 0 Then
            columns = columns + Genetica.Columns(col).Text + vbTab
            'End If
        Next
        '..........................................................................

        linedat.Append(columns + vbCrLf) '+ linedat + vbCrLf

        '..........................................................................
        'volcamos detalle del listview
        For lin = 0 To Genetica.Items.Count - 1
            For col = 1 To Genetica.Columns.Count - 1
                linedat.Append(Genetica.Items(lin).SubItems(col).Text.ToString.Trim.Replace(vbCrLf, " ") + vbTab)
            Next

            linedat.Append(vbCrLf) '= linedat + vbCrLf
        Next
        '..........................................................................

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnPorcentajes_Click(sender As Object, e As EventArgs) Handles btnPorcentajes.Click
        frmGeneticaPorcentajes.MdiParent = frmMAIN
        frmGeneticaPorcentajes.Show()
        frmGeneticaPorcentajes.BringToFront()
    End Sub

    public Sub lvGenetica_DoubleClick(sender As Object, e As EventArgs) Handles lvGenetica.DoubleClick
        frmGeneticaIngresoManual.CodigoAB = lvGenetica.SelectedItems.Item(0).SubItems(1).Text
        frmGeneticaIngresoManual.NombreToro = lvGenetica.SelectedItems.Item(0).SubItems(2).Text
        frmGeneticaIngresoManual.Raza = lvGenetica.SelectedItems.Item(0).SubItems(3).Text
        frmGeneticaIngresoManual.Valor = lvGenetica.SelectedItems.Item(0).SubItems(4).Text
        frmGeneticaIngresoManual.Actualizar = 1
        frmGeneticaIngresoManual.MdiParent = frmMAIN
        frmGeneticaIngresoManual.Show()
        frmGeneticaIngresoManual.BringToFront()
    End Sub
End Class