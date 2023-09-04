Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class frmControlLecheExcel
    Private Sub frmControlLecheExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8

        txtArchivoNombre.Text = ""
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        CargarExcel(dgvControlLechero)
    End Sub
    Sub CargarExcel(ByVal tabla As DataGridView)

        btnFinalizar.Enabled = False
        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""


        With myFileDialog
            .Filter = "Excel Files |*.xlsx|*.xls|*.csv"
            .Title = "Open File"
            .ShowDialog()
        End With



        If myFileDialog.FileName.ToString <> "" Then

            Dim ExcelFile As String = myFileDialog.FileName.ToString
            txtArchivoNombre.Text = ExcelFile
            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection


            xSheet = "Hoja1"
            conn = New OleDbConnection(
                       "Provider=Microsoft.ACE.OLEDB.12.0;" &
                       "data source=" & ExcelFile & "; " &
                       "Extended Properties='Excel 12.0 Xml;HDR=Yes'") 'HDR indica si la primera fila viene con el titulo (YES = tiene titulo cada columna, NO = sin titulo)

            Try
                Me.Cursor = Cursors.WaitCursor

                da = New OleDbDataAdapter("SELECT * FROM  [" & xSheet & "$]", conn)

                conn.Open()
                da.Fill(ds, "DatosExcel")
                dt = ds.Tables("DatosExcel")
                tabla.DataSource = ds
                tabla.DataMember = "DatosExcel"
                btnFinalizar.Enabled = True

            Catch ex As Exception
                MsgBox("La Hoja a ingresar debe tener el nombre por defecto (Hoja1)", MsgBoxStyle.Information, "Informacion")
            Finally
                conn.Close()
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        ProcesarExcel(dgvControlLechero)
    End Sub
    Public Function DataGridATabla(ByVal dvgControlLechero As DataGridView)

        Dim dt As New DataTable
        Dim columna As DataRow

        dt.Columns.Add("CoLeCentro", System.Type.GetType("System.Int32"))
        dt.Columns.Add("CoLeIndice", System.Type.GetType("System.Int32"))
        dt.Columns.Add("CoLeDiio", System.Type.GetType("System.Int32"))
        dt.Columns.Add("CoLeFechaControl", System.Type.GetType("System.String"))
        dt.Columns.Add("CoLeBasTon", System.Type.GetType("System.Int32"))
        dt.Columns.Add("CoLePM", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("CoLeAM", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("CoLeTotal", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("CoLeGrasa", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("CoLeProteina", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("CoLeRCS", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("CoLeObs", System.Type.GetType("System.String"))


        For i = 0 To dgvControlLechero.Rows.Count - 1

            columna = dt.NewRow
            columna("CoLeCentro") = dgvControlLechero.Rows(i).Cells(0).Value
            columna("CoLeIndice") = dgvControlLechero.Rows(i).Cells(1).Value
            columna("CoLeDiio") = dgvControlLechero.Rows(i).Cells(2).Value
            columna("CoLeFechaControl") = dgvControlLechero.Rows(i).Cells(3).Value
            columna("CoLeBasTon") = dgvControlLechero.Rows(i).Cells(4).Value
            columna("CoLePM") = dgvControlLechero.Rows(i).Cells(5).Value
            columna("CoLeAM") = dgvControlLechero.Rows(i).Cells(6).Value
            columna("CoLeTotal") = dgvControlLechero.Rows(i).Cells(7).Value
            columna("CoLeGrasa") = dgvControlLechero.Rows(i).Cells(8).Value
            columna("CoLeProteina") = dgvControlLechero.Rows(i).Cells(9).Value
            columna("CoLeRCS") = dgvControlLechero.Rows(i).Cells(10).Value
            If IsDBNull(dgvControlLechero.Rows(i).Cells(11).Value) Then
                columna("CoLeObs") = ""
            Else
                columna("CoLeObs") = dgvControlLechero.Rows(i).Cells(11).Value
            End If
            dt.Rows.Add(columna)
        Next

        DataGridATabla = dt

    End Function
    Private Function ProcesarExcel(ByVal dgvControlLechero As DataGridView) As String
        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spControlLechero_GrabarIngresoExcel", con)
        Dim ContenidoExcel As DataTable = DataGridATabla(dgvControlLechero)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@DTControlLecheroCargaExcel", ContenidoExcel)
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value
            con.Close()

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                Exit Function
            End If
            MsgBox("Grabación exitosa", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GRABACION")
            dgvControlLechero.Columns.Clear()
            Me.Close()
            'If ResultCod = 10 Then
            '    MsgBox(ResultMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR ENCONTRADO")
            '    dgvControlLechero.Columns.Clear()
            '    Exit Function
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        'Return ResultMsg
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class