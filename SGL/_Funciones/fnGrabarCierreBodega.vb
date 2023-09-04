Imports System.Data.SqlClient
Public Class fnGrabarCierreBodega


    Public Function GrabarCierreBodega(ByVal lvdetalle As ListView, ByVal centro As String, ByVal anio As Integer, ByVal Fecha As DateTime, ByVal mes As Integer, ByVal Bodega As String) As Boolean
        Dim DetalleCierre As DataTable = DataTableCierre(lvdetalle)
        GrabarCierreBodega = False
        If CrearCierre(DetalleCierre, centro, anio, Fecha, mes, Bodega) = True Then
            GrabarCierreBodega = True
        End If

    End Function

    Private Function CrearCierre(ByVal DetalleCierre As DataTable, ByVal centro As String, ByVal anio As Integer, ByVal Fecha As DateTime, ByVal mes As Integer, ByVal Bodega As String) As Boolean
        CrearCierre = False
        Dim i As Integer = 0
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_GrabarCierre", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Año", anio)
        cmd.Parameters.AddWithValue("@Fecha", Fecha)
        cmd.Parameters.AddWithValue("@Mes", mes)
        cmd.Parameters.AddWithValue("@Bodega", Bodega)
        cmd.Parameters.AddWithValue("@Tabla", DetalleCierre)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If
            MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        CrearCierre = True
        Cursor.Current = Cursors.Default
    End Function
    Public Function DataTableCierre(ByVal lvdetalle As ListView) As DataTable
        DataTableCierre = Nothing
        Dim table As DataTable = New DataTable("CierreBodega")

        table.Columns.Add("CieBodegaItemCod", System.Type.GetType("System.String"))
        table.Columns.Add("CieBodegaItemDescripcion", System.Type.GetType("System.String"))
        table.Columns.Add("CieBodegaClaseItem", System.Type.GetType("System.String"))
        table.Columns.Add("CieBodegaMedida", System.Type.GetType("System.String"))
        table.Columns.Add("CieBodegaStock", System.Type.GetType("System.String"))
        table.Columns.Add("CieBodegaConStock", System.Type.GetType("System.String"))

        Dim n As Integer
        n = lvdetalle.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(lvdetalle.Items(i).SubItems(6).Text, lvdetalle.Items(i).SubItems(1).Text, lvdetalle.Items(i).SubItems(2).Text, lvdetalle.Items(i).SubItems(3).Text,
                           lvdetalle.Items(i).SubItems(4).Text, lvdetalle.Items(i).SubItems(5).Text)
        Next
        DataTableCierre = table
    End Function
End Class
