
Imports System.Data.SqlClient
Public Class fnControlLechero
    Public Function Validar(ByVal centro As Integer, ByVal tipo As Integer, ByVal listview As ListView) As Boolean
        Validar = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spControlLechero_Validar", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos


        Dim DetalleItems As DataTable = ToDataTableexel(centro, tipo, listview)
        cmd.Parameters.AddWithValue("@TablaControlLech", DetalleItems)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

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
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim i As Integer
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("ClRDiio").ToString.Trim)
                    item.SubItems.Add(rdr("CentroNomCorto").ToString.Trim)
                    item.SubItems.Add(rdr("TiposNombre").ToString.Trim)
                    item.SubItems.Add(rdr("ClRValor").ToString.Trim)
                    item.SubItems.Add(rdr("estado").ToString.Trim)
                    item.SubItems.Add(rdr("ClRCentro").ToString.Trim)
                    item.SubItems.Add(rdr("ClRTipo").ToString.Trim)
                    If rdr("estado") <> "Ok" Then
                        item.BackColor = Color.Red
                    End If
                    frmControlLecheroIngreso.lvGanado.Items.Add(item)

                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Validar = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
    End Function
    Public Function Grabar(ByVal listview As ListView) As Boolean
        Grabar = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spControlLechero_Grabar", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos


        Dim DetalleItems As DataTable = ToDataTableGrabar(listview)
        cmd.Parameters.AddWithValue("@TablaControlLe", DetalleItems)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

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

        Dim table As DataTable = New DataTable("TablaControlLechero_Detalle")


        table.Columns.Add("fecha", System.Type.GetType("System.String"))
        table.Columns.Add("diio", System.Type.GetType("System.String"))
        table.Columns.Add("centro", System.Type.GetType("System.String"))

        table.Columns.Add("tipo", System.Type.GetType("System.String"))
        table.Columns.Add("valor", System.Type.GetType("System.String"))

        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss.fff"), listview.Items(i).SubItems(1).Text, listview.Items(i).SubItems(6).Text,
                           listview.Items(i).SubItems(7).Text, listview.Items(i).SubItems(4).Text)
        Next
        ToDataTableGrabar = table

    End Function
    Public Function ToDataTableexel(ByVal centro As Integer, ByVal tipo As Integer, ByVal listview As ListView) As DataTable
        ToDataTableexel = Nothing

        Dim table As DataTable = New DataTable("TablaControlLechero")

        Dim dtdiio As String = ""
        Dim dtcentro As String = centro
        Dim dttipo As String = tipo
        Dim dtvalor As String = ""


        table.Columns.Add("diio", System.Type.GetType("System.String"))
        table.Columns.Add("centro", System.Type.GetType("System.String"))

        table.Columns.Add("tipo", System.Type.GetType("System.String"))
        table.Columns.Add("valor", System.Type.GetType("System.String"))

        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(listview.Items(i).SubItems(1).Text, dtcentro, dttipo,
                           listview.Items(i).SubItems(2).Text)
        Next
        ToDataTableexel = table

    End Function
End Class
