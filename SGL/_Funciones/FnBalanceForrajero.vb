Imports System.Data.SqlClient

Public Class FnBalanceForrajero
    Public DetallesExcel As New DataTable("DetallePesoCrianza1")
    Public DetallesExcelConsumo As New DataTable("DetalleConsumoSemanal")
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
    Public Sub DtExcelCrear()
        '23
        DetallesExcel.Columns.Add("orden")
        DetallesExcel.Columns.Add("Categoria")
        DetallesExcel.Columns.Add("SubCategoria")
        DetallesExcel.Columns.Add("UnidadMedida")
        DetallesExcel.Columns.Add("Parametro")
        DetallesExcel.Columns.Add("Periodo1")
        DetallesExcel.Columns.Add("Periodo2")
        DetallesExcel.Columns.Add("Jul1")
        DetallesExcel.Columns.Add("Ago1")
        DetallesExcel.Columns.Add("Sep1")
        DetallesExcel.Columns.Add("Oct1")
        DetallesExcel.Columns.Add("Nov1")
        DetallesExcel.Columns.Add("Dic1")
        DetallesExcel.Columns.Add("Ene1")
        DetallesExcel.Columns.Add("Feb1")
        DetallesExcel.Columns.Add("Mar1")
        DetallesExcel.Columns.Add("Abr1")
        DetallesExcel.Columns.Add("May1")
        DetallesExcel.Columns.Add("Jun1")
        DetallesExcel.Columns.Add("Jul2")
        DetallesExcel.Columns.Add("Ago2")
        DetallesExcel.Columns.Add("Sep2")
        DetallesExcel.Columns.Add("TotalPediodo1")
        DetallesExcel.Columns.Add("TotalPeriodo1y2")

    End Sub


    Public Sub VaciaDatatable()

        DetallesExcel.Rows.Clear()

    End Sub
    Public Sub DtExcel(ByVal Orden As Integer, ByVal Categoria As String, ByVal SubCategoria As String, ByVal UnidadMedida As String, ByVal Parametro As Double, ByVal Periodo1 As Integer, ByVal Periodo2 As Integer, ByVal Jul1 As Double, ByVal Ago1 As Double, ByVal Sep1 As Double, ByVal Oct1 As Double, ByVal Nov1 As Double, ByVal Dic1 As Double, ByVal Ene1 As Double, ByVal Feb1 As Double, ByVal Mar1 As Double, ByVal Abr1 As Double, ByVal May1 As Double, ByVal Jun1 As Double, ByVal Jul2 As Double, ByVal Ago2 As Double, ByVal Sep2 As Double, ByVal TotalPediodo1 As Double, ByVal TotalPeriodo1y2 As Double)


        DetallesExcel.Rows.Add(Orden, Categoria, SubCategoria, UnidadMedida, Parametro, Periodo1, Periodo2, Jul1, Ago1, Sep1, Oct1, Nov1, Dic1, Ene1, Feb1, Mar1,
                               Abr1, May1, Jun1, Jul2, Ago2, Sep2, TotalPediodo1, TotalPeriodo1y2)
    End Sub


    Public Sub BalanceSemanal(ByVal lvconsumo As ListView, ByVal Centro As String, ByVal ExisteBalance As Integer)
        Dim DetalleBalance As DataTable = DataDetalleBalanceSemanal(lvconsumo)
        Dim IDGP As String = GrabarBalanceSemanal(DetalleBalance, Centro, ExisteBalance)

    End Sub
    Private Function GrabarBalanceSemanal(ByVal lvconsumo As DataTable, ByVal Centro As String, ByVal ExisteBalance As Integer) As Boolean
        Dim i As Integer = 0
        GrabarBalanceSemanal = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBalanceForrajero_GrabarSemanal", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@ExisteBalance", ExisteBalance)
        cmd.Parameters.AddWithValue("@TablaDetalle", lvconsumo)
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

            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        'Cursor.Current = Cursors.Default
    End Function



    Public Function DataDetalleBalanceSemanal(ByVal lvConsumo As ListView) As DataTable
        DataDetalleBalanceSemanal = Nothing
        Dim table As DataTable = New DataTable("BalanceForrajeSemanal")
        table.Columns.Add("orden", System.Type.GetType("System.Decimal"))
        table.Columns.Add("categoria", System.Type.GetType("System.String"))
        table.Columns.Add("item", System.Type.GetType("System.String"))
        table.Columns.Add("mes1", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes2", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes3", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes4", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes5", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes6", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes7", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes8", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes9", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes10", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes11", System.Type.GetType("System.Decimal"))
        table.Columns.Add("mes12", System.Type.GetType("System.Decimal"))

        Dim n As Integer
        n = lvConsumo.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(i, lvConsumo.Items(i).SubItems(2).Text, lvConsumo.Items(i).SubItems(3).Text, lvConsumo.Items(i).SubItems(4).Text,
                           lvConsumo.Items(i).SubItems(5).Text, lvConsumo.Items(i).SubItems(6).Text, lvConsumo.Items(i).SubItems(7).Text, lvConsumo.Items(i).SubItems(8).Text,
                           lvConsumo.Items(i).SubItems(9).Text, lvConsumo.Items(i).SubItems(10).Text, lvConsumo.Items(i).SubItems(11).Text, lvConsumo.Items(i).SubItems(12).Text,
                           lvConsumo.Items(i).SubItems(13).Text, lvConsumo.Items(i).SubItems(14).Text, lvConsumo.Items(i).SubItems(14).Text)
        Next
        DataDetalleBalanceSemanal = table
    End Function



End Class