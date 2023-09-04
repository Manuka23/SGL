Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmGanadoInmunidadIngreso
    Private Sub frmGanadoInmunidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.MdiParent = frmMAIN

    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        For Each r As DataGridViewRow In dgvExcel.SelectedRows
            dgvExcel.Rows.Remove(r)
        Next
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        If (dgvExcel.Rows.Count = 0) Then
            MsgBox("Debe cargar el excel", vbExclamation, "Carga Excel")
            Exit Sub
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanadoInmunidad_Grabar", con)
        Dim rdr As SqlDataReader = Nothing
        Dim ContenidoExcel As DataTable = DataGridATabla(dgvExcel)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@DTGanadoInmunidad", ContenidoExcel)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        MsgBox("CARGA EXITOS", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GRABACION")
        Me.Close()
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ImportarExcel(dgvExcel)
    End Sub
    Sub ImportarExcel(ByVal tabla As DataGridView)

        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""

        With myFileDialog
            .Filter = "Excel Files |*.xlsx;"
            .Title = "Open File"
            .ShowDialog()
        End With
        If myFileDialog.FileName.ToString <> "" Then
            Dim ExcelFile As String = myFileDialog.FileName.ToString
            txtNombreArchivo.Text = ExcelFile
            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection

            xSheet = "Hoja1"
            conn = New OleDbConnection(
                       "Provider=Microsoft.ACE.OLEDB.12.0;" &
                       "data source=" & ExcelFile & "; " &
                       "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            Try
                da = New OleDbDataAdapter("SELECT * FROM  [" & xSheet & "$]", conn)

                conn.Open()
                da.Fill(ds, "DatosExcel")
                dt = ds.Tables("DatosExcel")
                tabla.DataSource = ds
                tabla.DataMember = "DatosExcel"

            Catch ex As Exception
                MsgBox("La Hoja a ingresar debe tener el nombre por defecto (Hoja1)", MsgBoxStyle.Information, "Informacion")

            Finally
                conn.Close()
            End Try
        End If
    End Sub
    Public Function DataGridATabla(ByVal dgvcargarexcel As DataGridView)

        Dim dt As New DataTable
        Dim columna As DataRow

        dt.Columns.Add("Centro", System.Type.GetType("System.Int32"))
        dt.Columns.Add("Diio", System.Type.GetType("System.Int32"))
        dt.Columns.Add("FechaInmunidad", System.Type.GetType("System.DateTime"))
        dt.Columns.Add("Inmunidad", System.Type.GetType("System.Int32"))

        For i = 0 To dgvcargarexcel.Rows.Count - 1

            columna = dt.NewRow
            columna("Centro") = dgvcargarexcel.Rows(i).Cells(0).Value
            columna("Diio") = dgvcargarexcel.Rows(i).Cells(1).Value
            columna("FechaInmunidad") = dgvcargarexcel.Rows(i).Cells(2).Value
            columna("Inmunidad") = dgvcargarexcel.Rows(i).Cells(3).Value
            dt.Rows.Add(columna)
        Next

        DataGridATabla = dt

    End Function
End Class