Imports System.Data.SqlClient
Public Class fnCambioCategorias
    Public Function Grabar(ByVal TableGanado As ListView, ByVal CategoriaOri As String, ByVal CategoriaDes As String, ByVal fecha As DateTime, ByVal Obs As String) As Boolean
        Dim lvGanado As DataTable = ToDataTableGrabar(TableGanado)
        If GrabarCambioCategoria(lvGanado, CategoriaOri, CategoriaDes, fecha, Obs) Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function GrabarCambioCategoria(ByVal lvGanado As DataTable, ByVal CategoriaOri As String, ByVal CategoriaDes As String, ByVal fecha As DateTime, ByVal Obs As String) As Boolean
        Cursor.Current = Cursors.WaitCursor
        GrabarCambioCategoria = True
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCambioDeCategorias_GrabarMasivo", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CategoCodAnt", CategoriaOri)

        cmd.Parameters.AddWithValue("@Observacion", Obs)
        cmd.Parameters.AddWithValue("@CategoCodNueva", CategoriaDes)
        cmd.Parameters.AddWithValue("@FechaCambio", fecha)
        cmd.Parameters.AddWithValue("@TablaCategoria", lvGanado)
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
            If vret = 0 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error DE VALIDACION") = vbOK Then
                End If
                GrabarCambioCategoria = False
            Else
                If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
            GrabarCambioCategoria = False
        Finally
            con.Close()
        End Try

        Return GrabarCambioCategoria
    End Function

    Public Function ToDataTableGrabar(ByVal listview As ListView) As DataTable
        ToDataTableGrabar = Nothing
        Dim table As DataTable = New DataTable("CambioCategoriaDiios")
        table.Columns.Add("diio", System.Type.GetType("System.String"))
        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(listview.Items(i).SubItems(1).Text)
        Next
        ToDataTableGrabar = table

    End Function

End Class
