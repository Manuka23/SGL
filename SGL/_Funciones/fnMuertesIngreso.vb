Imports System.Data.SqlClient
Public Class fnMuertesIngreso
    Public Function GrabarMuertes(ByVal lvganado As ListView, ByVal Centro As String, ByVal Fecha As DateTime) As Boolean
        Dim DetalleMuertes As DataTable = DataTableMuertes(lvganado)
        If GrabarMuerte(DetalleMuertes, Centro, Fecha) Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function GrabarMuerte(ByVal lvganado As DataTable, ByVal Centro As String, ByVal Fecha As DateTime) As Boolean
        GrabarMuerte = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuertes_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim vet_ As String = ""
        Dim cau_ As Integer = 0
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@Fecha", Fecha)
        cmd.Parameters.AddWithValue("@TablaDetalle", lvganado)
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

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            GrabarMuerte = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function



    Public Function DataTableMuertes(ByVal lvganado As ListView) As DataTable
        DataTableMuertes = Nothing
        Dim table As DataTable = New DataTable("TablaMuertes")

        table.Columns.Add("diio", System.Type.GetType("System.String"))
        table.Columns.Add("Causa", System.Type.GetType("System.Decimal"))
        table.Columns.Add("Veterinario", System.Type.GetType("System.String"))
        table.Columns.Add("NCertificado", System.Type.GetType("System.Decimal"))
        table.Columns.Add("obs", System.Type.GetType("System.String"))
        Dim n As Integer
        n = lvganado.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(lvganado.Items(i).SubItems(1).Text, 
                           lvganado.Items(i).SubItems(8).Text, 
                           lvganado.Items(i).SubItems(9).Text, 
                           lvganado.Items(i).SubItems(10).Text, 
                           lvganado.Items(i).SubItems(6).Text)
        Next
        DataTableMuertes = table
    End Function

End Class
