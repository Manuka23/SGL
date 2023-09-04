Imports System.Data.SqlClient

Public Class fnGrabarSilos
    Public Function GrabaSilos(ByVal lvbolos As ListView, ByVal Fecha As DateTime)
        Dim DetalleSilos As DataTable = datatableDetalleSilos(lvbolos)
        If GrabarSilos(DetalleSilos, Fecha) Then
            Return True
        Else
            Return False
        End If

    End Function
    Private Function GrabarSilos(ByVal lvbolos As DataTable, ByVal Fecha As DateTime) As Boolean
        GrabarSilos = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_ConfeccionEnsilaje", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Fecha", Fecha)
        cmd.Parameters.AddWithValue("@TablaDetalle", lvbolos)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

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
            MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

            frmSilos.btnBuscar.PerformClick()
            GrabarSilos = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function



    Public Function datatableDetalleSilos(ByVal lvbolos As ListView) As DataTable
        datatableDetalleSilos = Nothing
        Dim table As DataTable = New DataTable("Ensilaje")

        table.Columns.Add("CentroCod", System.Type.GetType("System.String"))
        table.Columns.Add("PotreroCod", System.Type.GetType("System.String"))
        table.Columns.Add("ProductoCod", System.Type.GetType("System.String"))
        table.Columns.Add("Cantidad", System.Type.GetType("System.Double"))
        table.Columns.Add("Hectareas", System.Type.GetType("System.Double"))
        table.Columns.Add("Rendimiento", System.Type.GetType("System.Double"))
        table.Columns.Add("ValorBolo", System.Type.GetType("System.Double"))
        table.Columns.Add("Total", System.Type.GetType("System.Double"))
        table.Columns.Add("NombreProducto", System.Type.GetType("System.String"))
        table.Columns.Add("UnidadMedida", System.Type.GetType("System.String"))
        table.Columns.Add("HectareasPotrero", System.Type.GetType("System.Double"))


        Dim n As Integer
        n = lvbolos.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(lvbolos.Items(i).SubItems(2).Text, lvbolos.Items(i).SubItems(3).Text, lvbolos.Items(i).SubItems(9).Text, lvbolos.Items(i).SubItems(4).Text,
                           lvbolos.Items(i).SubItems(5).Text, lvbolos.Items(i).SubItems(6).Text, lvbolos.Items(i).SubItems(7).Text, lvbolos.Items(i).SubItems(8).Text,
                           lvbolos.Items(i).SubItems(10).Text, lvbolos.Items(i).SubItems(11).Text, lvbolos.Items(i).SubItems(12).Text)
        Next
        datatableDetalleSilos = table
    End Function

End Class
