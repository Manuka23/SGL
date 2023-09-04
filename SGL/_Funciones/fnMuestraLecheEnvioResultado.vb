Imports System.Data.SqlClient
Public Class fnMuestraLecheEnvioResultado
    Public DetallesExcel As New DataTable("MuestraLecheListadoExcel")
    Public Sub DtExcel(ByVal CorrEnvio As String, ByVal CodBarraMuestra As String, ByVal ResultRCS As String, ByVal ResultGrasa As String,
                            ByVal ResultProteina As String, ByVal ResultUrea As String, ByVal ResultDensidad As String,
                            ByVal ResultCriscopia As String, ByVal ResultUFC As String, ByVal ResultSolido As String)
        DetallesExcel.Rows.Add(CorrEnvio, CodBarraMuestra, ResultRCS, ResultGrasa, ResultProteina,
                               ResultUrea, ResultDensidad, ResultCriscopia, ResultUFC, ResultSolido)
    End Sub
    Public Sub DtExcelCrear()
        DetallesExcel.Columns.Add("CorrEnvio")
        DetallesExcel.Columns.Add("CodBarraMuestra")
        DetallesExcel.Columns.Add("ResultRCS")
        DetallesExcel.Columns.Add("ResultGrasa")
        DetallesExcel.Columns.Add("ResultProteina")
        DetallesExcel.Columns.Add("ResultSolido")
        DetallesExcel.Columns.Add("ResultUrea")
        DetallesExcel.Columns.Add("ResultDensidad")
        DetallesExcel.Columns.Add("ResultCriscopia")
        DetallesExcel.Columns.Add("ResultUFC")
    End Sub
    Public Sub VaciaDatatable()
        DetallesExcel.Reset()
    End Sub
    Public Function Grabar(ByVal lvganado As ListView, ByVal lote As String) As Boolean
        Grabar = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_GrabarResultado", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos


        Dim DetalleItems As DataTable = ToDataTableGrabar(lvganado)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)

        cmd.Parameters.AddWithValue("@LoteEnvio", lote)
        cmd.Parameters.AddWithValue("@TablaMuestras", DetalleItems)

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
                MsgBox("DATOS GRABADOS OK", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                frmMuestraLecheResultado.btnGrabar.Enabled = False
            End If
            Grabar = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
    End Function

    Public Function ToDataTableGrabar(ByVal lvganado As ListView) As DataTable
        ToDataTableGrabar = Nothing

        Dim table As DataTable = New DataTable("MuestraLecheEnvioResultados")

        table.Columns.Add("CorrEnvio", System.Type.GetType("System.Decimal"))
        table.Columns.Add("CodBarraMuestra", System.Type.GetType("System.String"))
        table.Columns.Add("CLrcs", System.Type.GetType("System.Double"))
        table.Columns.Add("CLGrasa", System.Type.GetType("System.Double"))
        table.Columns.Add("CLProteina", System.Type.GetType("System.Double"))
        table.Columns.Add("CLMateriaSolida", System.Type.GetType("System.Double"))
        table.Columns.Add("CLUrea", System.Type.GetType("System.Double"))
        table.Columns.Add("CLDensidad", System.Type.GetType("System.Double"))
        table.Columns.Add("CLCrioscopia", System.Type.GetType("System.Double"))
        table.Columns.Add("CLufc", System.Type.GetType("System.Double"))



        Dim n As Integer
        n = lvganado.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(lvganado.Items(i).SubItems(0).Text, lvganado.Items(i).SubItems(2).Text, lvganado.Items(i).SubItems(3).Text,
                           lvganado.Items(i).SubItems(4).Text, lvganado.Items(i).SubItems(5).Text, lvganado.Items(i).SubItems(10).Text,
                           lvganado.Items(i).SubItems(6).Text, lvganado.Items(i).SubItems(7).Text, lvganado.Items(i).SubItems(8).Text,
                           lvganado.Items(i).SubItems(9).Text)
        Next
        ToDataTableGrabar = table

    End Function

End Class
