Imports System.Data.SqlClient
Public Class fnPabcoDetalle

    Public DetallesExcel As New DataTable("DetalleVaunados")
    Public EliminarDetallesExcel As New DataTable("EliminarDetalleVaunados")
    Public Sub DtExcel(ByVal Diio As String)
        DetallesExcel.Rows.Add(Diio)
    End Sub
    Public Sub DtExcelEliminar(ByVal Diio As String, ByVal Vacuna As String, ByVal Fecha As DateTime)
        EliminarDetallesExcel.Rows.Add(Diio, Vacuna, Fecha)
    End Sub

    'Public Function DtExcelCrearElimina()
    '    EliminarDetallesExcel.Columns.Add("Diio")
    '    EliminarDetallesExcel.Columns.Add("Vacuna")
    '    EliminarDetallesExcel.Columns.Add("Fecha")
    'End Function

    Public Sub DtExcelCrear()
        DetallesExcel.Columns.Add("Diio")
    End Sub
    Public Sub VaciaDatatable()

        DetallesExcel.Reset()
        EliminarDetallesExcel.Reset()
    End Sub
    Public Function GrabarPabco(ByVal lvdetalle As ListView, ByVal centro As String, ByVal fecha As DateTime, ByVal Horario As Integer, ByVal Lotes As String, ByVal Actualizar As String, ByVal TratCodigo As Integer, ByVal TipoCarga As String, ByVal Preventivo As Integer) As Boolean
        Dim DetalleConsumos As DataTable = DataTableConsumoVacunas(lvdetalle)
        GrabarPabco = False
        If GrabarTratamientos(DetalleConsumos, centro, fecha, Horario, Lotes, Actualizar, TratCodigo, TipoCarga, Preventivo) = True Then
            GrabarPabco = True
        End If

    End Function

    Private Function GrabarTratamientos(ByVal DetalleConsumos As DataTable, ByVal centro As String, ByVal fecha As DateTime, ByVal Horario As Integer, ByVal Lotes As String, ByVal Actualizar As String, ByVal TratCodigo As Integer, ByVal TipoCarga As String, ByVal Preventivo As Integer) As Boolean
        GrabarTratamientos = False
        Dim i As Integer = 0
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_ingresoPabco", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@TratFecha", fecha)
        cmd.Parameters.AddWithValue("@TratHorario", Horario)
        'cmd.Parameters.AddWithValue("@TratLotes", Lotes)
        cmd.Parameters.AddWithValue("@Actualizar", Actualizar)   ' "" = Insert, SI = Update
        cmd.Parameters.AddWithValue("@TratCodigo", TratCodigo)
        cmd.Parameters.AddWithValue("@TratTabla", DetalleConsumos)
        cmd.Parameters.AddWithValue("@TipoCarga", TipoCarga)
        cmd.Parameters.AddWithValue("@TratEquipo", NombrePC)
        cmd.Parameters.AddWithValue("@TratUsuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Preventivo", Preventivo)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            If vret <> 0 Then
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

        GrabarTratamientos = True
        Cursor.Current = Cursors.Default
    End Function
    Public Function DataTableConsumoVacunas(ByVal lvdetalle As ListView) As DataTable
        DataTableConsumoVacunas = Nothing
        Dim table As DataTable = New DataTable("PabcoDetallesGrabar")

        table.Columns.Add("CodPatologia", System.Type.GetType("System.String"))
        table.Columns.Add("MedCodigo", System.Type.GetType("System.String"))
        table.Columns.Add("TratDiio", System.Type.GetType("System.String"))
        table.Columns.Add("TratAD", System.Type.GetType("System.String"))
        table.Columns.Add("TratAI", System.Type.GetType("System.String"))
        table.Columns.Add("TratPD", System.Type.GetType("System.String"))
        table.Columns.Add("TratPI", System.Type.GetType("System.String"))
        table.Columns.Add("TratDias", System.Type.GetType("System.Decimal"))
        table.Columns.Add("TratHoras", System.Type.GetType("System.Int32"))
        table.Columns.Add("TratCantVeces", System.Type.GetType("System.Int32"))
        table.Columns.Add("TratInicioTratamiento", System.Type.GetType("System.String"))
        table.Columns.Add("TratFinTratamiento", System.Type.GetType("System.String"))
        table.Columns.Add("TratObservacion", System.Type.GetType("System.String"))
        table.Columns.Add("TratDosis", System.Type.GetType("System.String"))
        table.Columns.Add("TratUMedida", System.Type.GetType("System.String"))
        table.Columns.Add("TratCoja", System.Type.GetType("System.String"))
        table.Columns.Add("MedCodGP", System.Type.GetType("System.Int32"))
        table.Columns.Add("DiasLeche", System.Type.GetType("System.Int32"))
        table.Columns.Add("DiasCarne", System.Type.GetType("System.Int32"))

        Dim n As Integer
        n = lvdetalle.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(lvdetalle.Items(i).SubItems(10).Text,
                           lvdetalle.Items(i).SubItems(12).Text,
                           lvdetalle.Items(i).SubItems(2).Text,
                           lvdetalle.Items(i).SubItems(18).Text,
                           lvdetalle.Items(i).SubItems(17).Text,
                           lvdetalle.Items(i).SubItems(20).Text,
                           lvdetalle.Items(i).SubItems(19).Text,
                           lvdetalle.Items(i).SubItems(14).Text,
                           lvdetalle.Items(i).SubItems(31).Text,
                           lvdetalle.Items(i).SubItems(32).Text,
                           lvdetalle.Items(i).SubItems(15).Text,
                           lvdetalle.Items(i).SubItems(16).Text,
                           lvdetalle.Items(i).SubItems(25).Text,
                           lvdetalle.Items(i).SubItems(26).Text,
                           lvdetalle.Items(i).SubItems(27).Text,
                           lvdetalle.Items(i).SubItems(28).Text,
                           lvdetalle.Items(i).SubItems(29).Text,
                           lvdetalle.Items(i).SubItems(23).Text,
                           lvdetalle.Items(i).SubItems(24).Text)

        Next
        DataTableConsumoVacunas = table
    End Function
End Class
