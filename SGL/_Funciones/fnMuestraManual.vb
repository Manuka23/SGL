Imports System.Data.SqlClient
Public Class fnMuestraManual
    Public DetallesExcel As New DataTable("DetalleVaunados")


    Public Sub DtExcel(ByVal Correlativo As Double, ByVal EstanqueCod As String, ByVal Estanque As String, ByVal RCS As Integer, ByVal Grasa As Double, ByVal Proteina As Double, ByVal Urea As Double, ByVal Densidad As Double,
                            ByVal Crioscopia As Double, ByVal UFS As Double, ByVal MSolida As Double)
        DetallesExcel.Rows.Add(Correlativo, EstanqueCod, Estanque, RCS, Grasa, Proteina, Urea, Densidad, Crioscopia, UFS, MSolida)
    End Sub

    Public Function GrabarMuestraManual(ByVal dgvCalidadLeche As DataGridView, ByVal NomProvee As String, ByVal CodProvee As String, ByVal Horario As String, ByVal Fecha As Date, ByVal FechaRes As Date, ByVal Muestreo As String) As Boolean
        GrabarMuestraManual = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_GrabarIngresoManual", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos

        Dim DetalleItems As DataTable = ToDataTableGrabarPndEnvio(dgvCalidadLeche)

        cmd.Parameters.AddWithValue("@TablaMuestras", DetalleItems)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@MuesFecha", Fecha)
        cmd.Parameters.AddWithValue("@MuesFechaREsultado", FechaRes)
        cmd.Parameters.AddWithValue("@MuesCodProveedores", CodProvee)
        cmd.Parameters.AddWithValue("@MuesNomProveedores", NomProvee)
        cmd.Parameters.AddWithValue("@MuesHorario", Horario)
        cmd.Parameters.AddWithValue("@Muestreo", Muestreo)
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
            If vret = 0 Then
            End If
            GrabarMuestraManual = True
            MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
            DetalleItems.Clear()
        End Try
    End Function
    Public Function ToDataTableGrabarPndEnvio(ByVal dgvCalidadLeche As DataGridView) As DataTable
        ToDataTableGrabarPndEnvio = Nothing

        Dim table As DataTable = New DataTable("MuestraLecheIngresoManual")

        table.Columns.Add("Correlativo", System.Type.GetType("System.Decimal"))
        table.Columns.Add("EstanqueCod", System.Type.GetType("System.String"))
        table.Columns.Add("Estanque", System.Type.GetType("System.String"))
        table.Columns.Add("RCS", System.Type.GetType("System.Decimal"))
        table.Columns.Add("Grasa", System.Type.GetType("System.Double"))
        table.Columns.Add("Proteina", System.Type.GetType("System.Double"))
        table.Columns.Add("Urea", System.Type.GetType("System.Double"))
        table.Columns.Add("Densidad", System.Type.GetType("System.Double"))
        table.Columns.Add("Crioscopia", System.Type.GetType("System.Double"))
        table.Columns.Add("UFS", System.Type.GetType("System.Double"))
        table.Columns.Add("MSolida", System.Type.GetType("System.Double"))
        '    Dim RCS As Integer = dgvCalidadLeche.Rows(i).Cells(2).Value
        '    Dim Grasa As Double = dgvCalidadLeche.Rows(i).Cells(3).Value
        '    Dim Proteina As Double = dgvCalidadLeche.Rows(i).Cells(4).Value
        '    Dim Urea As Double = dgvCalidadLeche.Rows(i).Cells(5).Value
        '    Dim Densidad As Double = dgvCalidadLeche.Rows(i).Cells(6).Value
        '    Dim Crioscopia As Double = dgvCalidadLeche.Rows(i).Cells(7).Value
        '    Dim UFS As Double = dgvCalidadLeche.Rows(i).Cells(8).Value
        '    Dim MSolida As Double = dgvCalidadLeche.Rows(i).Cells(9).Value

        Dim n As Integer = dgvCalidadLeche.RowCount
        For i = 0 To n - 1
            table.Rows.Add(1, dgvCalidadLeche.Rows(i).Cells(1).Value, dgvCalidadLeche.Rows(i).Cells(0).Value, dgvCalidadLeche.Rows(i).Cells(2).Value, dgvCalidadLeche.Rows(i).Cells(3).Value, dgvCalidadLeche.Rows(i).Cells(4).Value, dgvCalidadLeche.Rows(i).Cells(5).Value, dgvCalidadLeche.Rows(i).Cells(6).Value, dgvCalidadLeche.Rows(i).Cells(7).Value, dgvCalidadLeche.Rows(i).Cells(8).Value, dgvCalidadLeche.Rows(i).Cells(9).Value)
        Next
        ToDataTableGrabarPndEnvio = table

    End Function

    'Public Function ToDataTableGrabar(ByVal lvganado As ListView) As DataTable
    '    ToDataTableGrabar = Nothing

    '    Dim table As DataTable = New DataTable("MuestraLecheEnvioResultados")

    '    table.Columns.Add("CorrEnvio", System.Type.GetType("System.Decimal"))
    '    table.Columns.Add("CodBarraMuestra", System.Type.GetType("System.String"))
    '    table.Columns.Add("CLrcs", System.Type.GetType("System.Double"))
    '    table.Columns.Add("CLGrasa", System.Type.GetType("System.Double"))
    '    table.Columns.Add("CLProteina", System.Type.GetType("System.Double"))
    '    table.Columns.Add("CLUrea", System.Type.GetType("System.Double"))
    '    table.Columns.Add("CLDensidad", System.Type.GetType("System.Double"))
    '    table.Columns.Add("CLCrioscopia", System.Type.GetType("System.Double"))
    '    table.Columns.Add("CLufc", System.Type.GetType("System.Double"))
    '    table.Columns.Add("CLMateriaSolida", System.Type.GetType("System.Double"))


    '    Dim n As Integer
    '    n = lvganado.Items.Count
    '    For i = 0 To n - 1
    '        table.Rows.Add(lvganado.Items(i).SubItems(0).Text, lvganado.Items(i).SubItems(2).Text, lvganado.Items(i).SubItems(3).Text,
    '                       lvganado.Items(i).SubItems(4).Text, lvganado.Items(i).SubItems(5).Text, lvganado.Items(i).SubItems(6).Text,
    '                       lvganado.Items(i).SubItems(7).Text, lvganado.Items(i).SubItems(8).Text, lvganado.Items(i).SubItems(9).Text,
    '                       lvganado.Items(i).SubItems(10).Text)
    '    Next
    '    ToDataTableGrabar = table

    'End Function
End Class
