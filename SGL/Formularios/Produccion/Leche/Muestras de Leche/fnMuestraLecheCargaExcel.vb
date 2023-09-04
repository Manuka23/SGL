Imports System.Data.SqlClient
Public Class fnMuestraLecheCargaExcel
    Public Function CargarExcel(ByVal dgvcargarexcel As DataGridView, ByVal CodProvee As String, ByVal Proveedor As String) As String
        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_GrabarIngresoExcel", con)
        Dim ContenidoExcel As DataTable = DataGridATabla(dgvcargarexcel)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@CodProveedor", CodProvee)
        cmd.Parameters.AddWithValue("@Proveedor", Proveedor)
        cmd.Parameters.AddWithValue("@DTMuestraLecheResult", ContenidoExcel)
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value
            con.Close()
        Catch ex As Exception

        End Try

        Return ResultMsg
    End Function
    Public Function DataGridATabla(ByVal dgvcargarexcel As DataGridView)

        Dim dt As New DataTable
        Dim columna As DataRow

        dt.Columns.Add("correlativ", System.Type.GetType("System.Int32"))
        dt.Columns.Add("folio", System.Type.GetType("System.Int32"))
        dt.Columns.Add("codigo", System.Type.GetType("System.Int32"))
        dt.Columns.Add("ext", System.Type.GetType("System.Int32"))
        dt.Columns.Add("rp", System.Type.GetType("System.String"))
        dt.Columns.Add("rcs", System.Type.GetType("System.Int32"))
        dt.Columns.Add("grasa", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("proteina", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("urea", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("densidad", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("ufc", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("crioscop", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("solidos", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("centro", System.Type.GetType("System.Int32"))
        dt.Columns.Add("solida", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("fecha", System.Type.GetType("System.DateTime"))

        For i = 0 To dgvcargarexcel.Rows.Count - 1

            columna = dt.NewRow
            columna("correlativ") = dgvcargarexcel.Rows(i).Cells(0).Value ' dgvcargarexcel.Item(0, i).Value.ToString
            columna("folio") = dgvcargarexcel.Rows(i).Cells(1).Value 'dgvcargarexcel.Item(1, i).Value.ToString
            columna("codigo") = dgvcargarexcel.Rows(i).Cells(2).Value 'dgvcargarexcel.Item(2, i).Value.ToString
            columna("ext") = dgvcargarexcel.Rows(i).Cells(3).Value 'dgvcargarexcel.Item(3, i).Value.ToString
            columna("rp") = dgvcargarexcel.Rows(i).Cells(4).Value 'dgvcargarexcel.Item(4, i).Value.ToString
            columna("rcs") = dgvcargarexcel.Rows(i).Cells(5).Value 'dgvcargarexcel.Item(5, i).Value.ToString
            columna("grasa") = dgvcargarexcel.Rows(i).Cells(6).Value 'dgvcargarexcel.Item(6, i).Value.ToString
            columna("proteina") = dgvcargarexcel.Rows(i).Cells(7).Value 'dgvcargarexcel.Item(7, i).Value.ToString
            columna("urea") = dgvcargarexcel.Rows(i).Cells(8).Value 'dgvcargarexcel.Item(8, i).Value.ToString
            columna("densidad") = dgvcargarexcel.Rows(i).Cells(9).Value 'dgvcargarexcel.Item(9, i).Value.ToString
            columna("ufc") = dgvcargarexcel.Rows(i).Cells(10).Value 'dgvcargarexcel.Item(10, i).Value.ToString
            columna("crioscop") = dgvcargarexcel.Rows(i).Cells(11).Value 'dgvcargarexcel.Item(11, i).Value.ToString
            columna("solidos") = dgvcargarexcel.Rows(i).Cells(12).Value 'dgvcargarexcel.Item(12, i).Value.ToString
            columna("centro") = dgvcargarexcel.Rows(i).Cells(13).Value 'dgvcargarexcel.Item(13, i).Value.ToString
            columna("solida") = dgvcargarexcel.Rows(i).Cells(14).Value 'dgvcargarexcel.Item(14, i).Value.ToString
            columna("fecha") = dgvcargarexcel.Rows(i).Cells(15).Value 'dgvcargarexcel.Item(15, i).Value.ToString
            dt.Rows.Add(columna)
        Next

        DataGridATabla = dt

    End Function
End Class
