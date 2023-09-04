Imports System.Data.SqlClient
Public Class fnVacuna

    Public Function Grabar(ByVal fecha As DateTime, ByVal centro As String, ByVal listview As ListView, ByVal Vacuna As String, ByVal IdConsumoGp As String) As Boolean
        Grabar = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_GrabarVacunacion", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos


        Dim DetalleItems As DataTable = ToDataTableGrabar(listview)
        cmd.Parameters.AddWithValue("@VacGndCentroVacunacion", centro)
        cmd.Parameters.AddWithValue("@VacGndFecha", DateTime.Parse(fecha))
        cmd.Parameters.AddWithValue("@VacCodigo", Vacuna)
        cmd.Parameters.AddWithValue("@IdConsumoGp", IdConsumoGp)
        cmd.Parameters.AddWithValue("@TablaVacunacion", DetalleItems)
        cmd.Parameters.AddWithValue("@VacGndEquipo", NombrePC)
        cmd.Parameters.AddWithValue("@VacGndUsuario", LoginUsuario)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If
            Grabar = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
    End Function

    Public Function ToDataTableGrabar(ByVal listview As ListView) As DataTable
        ToDataTableGrabar = Nothing

        Dim table As DataTable = New DataTable("TablaVacunacion")


        table.Columns.Add("diio", System.Type.GetType("System.String"))
        table.Columns.Add("centrodiio", System.Type.GetType("System.String"))
        table.Columns.Add("categoria", System.Type.GetType("System.String"))

        table.Columns.Add("estproductivo", System.Type.GetType("System.String"))
        table.Columns.Add("estreproductivo", System.Type.GetType("System.String"))
        table.Columns.Add("estado", System.Type.GetType("System.String"))


        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(listview.Items(i).SubItems(2).Text, listview.Items(i).SubItems(8).Text,
                           listview.Items(i).SubItems(9).Text, listview.Items(i).SubItems(4).Text,
                           listview.Items(i).SubItems(5).Text, listview.Items(i).SubItems(6).Text)
        Next
        ToDataTableGrabar = table

    End Function

End Class
