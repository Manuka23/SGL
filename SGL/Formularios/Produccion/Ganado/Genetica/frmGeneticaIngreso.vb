Imports DevExpress.Data.Browsing.Design
Imports Microsoft.Office.Interop.Excel
Imports System.Collections.ObjectModel
Imports System.Data.SqlClient

Public Class frmGeneticaIngreso
    Public ArchivoImportacion As String
    Public Total_General As Integer
    Public UltimoReg As String
    Private Sub btnBuscarExcel_Click(sender As Object, e As EventArgs) Handles btnBuscarExcel.Click
        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()

        If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        ArchivoImportacion = OpenFDlg.FileName.Trim()
        txtRutaExcel.Text = ArchivoImportacion
        LeerExcel()

    End Sub

    Private Sub frmGeneticaIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
    End Sub

    Private Sub LeerExcel()
        Cursor.Current = Cursors.WaitCursor

        lvlCargaGenetica.BeginUpdate()
        lvlCargaGenetica.Items.Clear()

        Try
            Dim lin As Integer
            Dim Procesa As Boolean

            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Dim NroLineas As Integer

            Libro = AppExcel.Workbooks.Open(ArchivoImportacion)
            Hoja = Libro.Worksheets(1)
            lin = 1
            Procesa = False

            NroLineas = Hoja.Range("A1").CurrentRegion.Rows.Count

            If NroLineas > 0 Then
                Procesa = True
            End If

            Do While Procesa

                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    Exit Do
                End If

                Dim item As New ListViewItem(lin)
                item.SubItems.Add(Hoja.Cells(lin, 1).value)
                item.SubItems.Add(Hoja.Cells(lin, 2).value)
                item.SubItems.Add(Hoja.Cells(lin, 3).value)
                item.SubItems.Add(Hoja.Cells(lin, 4).value)
                lvlCargaGenetica.Items.Add(item)

                lin = lin + 1

            Loop

            Libro.Close()
            AppExcel.Quit()

            Hoja = Nothing
            Libro = Nothing
            AppExcel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        lvlCargaGenetica.EndUpdate()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        If lvlCargaGenetica.Items.Count = 0 Then
            Exit Sub
        End If

        If UltimoReg = dtpFecha.Text Then
            If MsgBox("YA SE ENCUENTRAN REGISTROS PARA ESTA FECHA, DESEA SOBRESCRIBIR LA INFORMACION ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "SGL") = vbYes Then
                GeneticaCargar(lvlCargaGenetica)
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            GeneticaCargar(lvlCargaGenetica)
            Me.Close()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub GeneticaCargar(ByVal lvlCargaGenetica As ListView)
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spToros_GrabarValoracion", con)

        Dim ResultCod As Integer
        Dim ResultMsg As String
        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim Fecha As DateTime = dtpFecha.Value
        Dim TablaGenDetalle As System.Data.DataTable = TablaGenetica(lvlCargaGenetica)

        cmd.Parameters.AddWithValue("@Fecha", Fecha)
        cmd.Parameters.AddWithValue("@DTGeneticaGanado", TablaGenDetalle)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        Try
            con.Open()
            cmd.ExecuteNonQuery()

            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        MsgBox("REGISTRO EXITOSO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "VALIDACION")

        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Function TablaGenetica(ByVal lvlCargaGenetica As ListView) As System.Data.DataTable
        TablaGenetica = Nothing

        Dim table As System.Data.DataTable = New System.Data.DataTable("TablaGeneticaDetalle")

        table.Columns.Add("ABCode", System.Type.GetType("System.Int32"))
        table.Columns.Add("ABName", System.Type.GetType("System.String"))
        table.Columns.Add("BreedCat", System.Type.GetType("System.String"))
        table.Columns.Add("BreedingWorth", System.Type.GetType("System.Decimal"))

        For Each item As ListViewItem In lvlCargaGenetica.Items

            table.Rows.Add(item.SubItems(1).Text,
                            item.SubItems(2).Text,
                            item.SubItems(3).Text,
                            item.SubItems(4).Text)
        Next

        TablaGenetica = table
    End Function

    Private Sub btnIngresoManual_Click(sender As Object, e As EventArgs) Handles btnIngresoManual.Click
        frmGeneticaIngresoManual.MdiParent = frmMAIN
        frmGeneticaIngresoManual.Show()
        frmGeneticaIngresoManual.BringToFront()
    End Sub
End Class