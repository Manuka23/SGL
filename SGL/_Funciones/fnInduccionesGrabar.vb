Imports System.Data.SqlClient
Public Class fnInduccionesGrabar
    Public Function Grabar(ByVal lvganado As ListView, ByVal centro As String, ByVal fecha As DateTime) As Boolean
        Dim DetalleInducciones As DataTable = ToDataTableGrabar(lvganado)
        If GrabarInducciones(DetalleInducciones, centro, fecha) Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function GrabarInducciones(ByVal DetalleInducciones As DataTable, ByVal centro As String, ByVal fecha As DateTime)
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spInduccion_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@TablaInducciones", DetalleInducciones)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret = 1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error DE VALIDACION") = vbOK Then
                End If
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
            Return False
        Finally
            con.Close()
        End Try
        Return True
    End Function

    Public Function ToDataTableGrabar(ByVal listview As ListView) As DataTable
        ToDataTableGrabar = Nothing
        Dim table As DataTable = New DataTable("VacunasListadoExcel")
        table.Columns.Add("diio", System.Type.GetType("System.String"))
        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(listview.Items(i).SubItems(2).Text)
        Next
        ToDataTableGrabar = table

    End Function

End Class
