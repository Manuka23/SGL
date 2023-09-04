
Imports System.Data.SqlClient
Public Class fnCrianzaPeso
    Public DetallesExcel As New DataTable("DetallePesoCrianza1")
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
        DetallesExcel.Columns.Add("Diio")
        DetallesExcel.Columns.Add("Peso")
        DetallesExcel.Columns.Add("Raza")
    End Sub
    Public Sub VaciaDatatable()

        DetallesExcel.Reset()

    End Sub
    Public Sub DtExcel(ByVal Diio As String, ByVal Peso As String, ByVal Raza As String)
        DetallesExcel.Rows.Add(Diio, Peso, Raza)
    End Sub

    Public Function GrabarPesajeCrianza(ByVal Empresa As Integer, ByVal Centro As Integer, ByVal Fecha As DateTime, ByVal lvdetalle As ListView, ByVal observ As String, ByVal login As String, ByVal nombrepc As String) As Boolean
        Dim i As Integer = 0
        GrabarPesajeCrianza = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCrianza_GrabaPesoCrianza", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        Dim DetalleItems As DataTable = LVToDataTable(lvdetalle)
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@Fecha", Fecha)
        cmd.Parameters.AddWithValue("@TablaDetalle", DetalleItems)
        cmd.Parameters.AddWithValue("@Observs", observ)
        cmd.Parameters.AddWithValue("@Usuario", login)
        cmd.Parameters.AddWithValue("@Equipo", nombrepc)

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

        Cursor.Current = Cursors.Default
    End Function
    Public Function LVToDataTable(ByVal lvdetalle As ListView) As DataTable
        LVToDataTable = Nothing

        Dim table As DataTable = New DataTable("TablaAuditoriaLectorDet")
        table.Columns.Add("Diio", System.Type.GetType("System.String"))
        table.Columns.Add("PesoPesaje", System.Type.GetType("System.String"))
        table.Columns.Add("CodCatPesaje", System.Type.GetType("System.String"))
        table.Columns.Add("CodRazaPesaje", System.Type.GetType("System.String"))
        table.Columns.Add("CodCatNuevo", System.Type.GetType("System.String"))
        table.Columns.Add("CodRazaNueva", System.Type.GetType("System.String"))

        For Each itm As ListViewItem In lvdetalle.Items
            table.Rows.Add(itm.SubItems(1).Text, itm.SubItems(2).Text, itm.SubItems(11).Text,
                           itm.SubItems(10).Text, itm.SubItems(9).Text, itm.SubItems(8).Text)
        Next
        LVToDataTable = table

    End Function

End Class