Imports System.Data.SqlClient
Public Class fnBalanceIngresoDiario
    Private vret As Integer = 0
    Private mret As String = ""
    Public ReadOnly Property RetVal As Integer
        Get
            Return vret
        End Get
    End Property
    Public ReadOnly Property RetMsg As String
        Get
            Return mret
        End Get
    End Property

    Public Sub Balance(ByVal lvganado As DataTable, ByVal SubCategoria As String)
        Dim DetalleBalance As DataTable = DataDetalleBalance(lvganado)
        Dim IDGP As String = GrabarBalance(DetalleBalance, SubCategoria)

    End Sub

    Private Function GrabarBalance(ByVal lvganado As DataTable, ByVal SubCategoria As String) As Boolean
        Dim i As Integer = 0
        GrabarBalance = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBalanceForrajero_GrabarIngresoDiario2", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Orden", SubCategoria)
        cmd.Parameters.AddWithValue("@TablaDetalle", lvganado)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                Cursor.Current = Cursors.Default
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

            Else
                MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        'Cursor.Current = Cursors.Default
    End Function

    Public Function DataDetalleBalance(ByVal lvganado As DataTable) As DataTable
        DataDetalleBalance = Nothing
        Dim table As DataTable = New DataTable("FeedDiario1")
        table.Columns.Add("Fecha", System.Type.GetType("System.String"))
        table.Columns.Add("Valor", System.Type.GetType("System.Decimal"))
        table.Columns.Add("Centro", System.Type.GetType("System.String"))

        'table.Columns.Add("Jul1", System.Type.GetType("System.Decimal"))


        Dim n As Integer
        n = lvganado.Rows.Count
        For i = 0 To n - 1
            If lvganado.Rows(i).Item(2).ToString <> "" And lvganado.Rows(i).Item(0).ToString <> "" Then


                table.Rows.Add(Format(CDate(lvganado.Rows(i).Item(0).ToString), "MM-dd-yyyy"), lvganado.Rows(i).Item(1).ToString, lvganado.Rows(i).Item(2).ToString)
            End If

        Next
        DataDetalleBalance = table
    End Function


End Class