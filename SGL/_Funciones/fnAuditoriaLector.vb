
Imports System.Data.SqlClient

Public Class fnAuditoriaLector

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

    Public Function InsertDetalle(ByVal AuditId As Integer, ByVal AuditCenCod As Integer, ByVal LV As ListView, ByVal TipoLectura As String, ByVal Serial As String, ByVal NombreSesion As String) As Boolean
        InsertDetalle = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAuditoriaLector_DIIO", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        '

        If TipoLectura = "Baston XRS" Or TipoLectura = "Baston XRS2" Then
            Dim DetalleItems As DataTable = LVToDataTable(AuditId, AuditCenCod, LV, Serial, NombreSesion)
            cmd.Parameters.AddWithValue("@TablaDetalle", DetalleItems)
        Else
            Dim DetalleItems As DataTable = LVToDataTableExcel(AuditId, AuditCenCod, LV)
            cmd.Parameters.AddWithValue("@TablaDetalle", DetalleItems)
        End If

        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            InsertDetalle = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
    End Function

    Public Function LVToDataTable(ByVal AuditId As Integer, ByVal AuditCenCod As Integer, ByVal LV As ListView, ByVal SerialLector As String, ByVal NombreSesion As String) As DataTable
        LVToDataTable = Nothing

        Dim table As DataTable = New DataTable("TablaAuditoriaLectorDet")

        table.Columns.Add("GndCod", System.Type.GetType("System.String"))
        table.Columns.Add("FechaBastoneo", System.Type.GetType("System.String"))
        table.Columns.Add("SerialBaston", System.Type.GetType("System.String"))
        table.Columns.Add("AuditCenCod", System.Type.GetType("System.String"))        'GetType(Integer)
        table.Columns.Add("AuditID", System.Type.GetType("System.String"))
        table.Columns.Add("Lectura", System.Type.GetType("System.String"))
        Dim n As Integer
        n = LV.Items.Count
        For i = 0 To n - 1
            If NombreSesion = LV.Items(i).SubItems(3).Text Then
                table.Rows.Add(LV.Items(i).SubItems(1).Text,
               LV.Items(i).SubItems(2).Text, SerialLector, AuditCenCod, AuditId, LV.Items(i).SubItems(5).Text)
            End If
            Console.WriteLine(LV.Items(i).SubItems(1).Text)
        Next
        LVToDataTable = table

    End Function

    Public Function LVToDataTableExcel(ByVal audit As String, ByVal centrot As String, ByVal listview As ListView) As DataTable
        LVToDataTableExcel = Nothing

        Dim table As DataTable = New DataTable("TablaAuditoriaLectorDet")

        Dim diio As String = ""
        Dim Lectura As String = "Excel"
        Dim fecha As String = ""
        Dim tipo As String = ""
        Dim usuario As String = LoginUsuario
        Dim centro As String = centrot
        Dim audi As String = audit

        table.Columns.Add("GndCod", System.Type.GetType("System.String"))
        table.Columns.Add("FechaBastoneo", System.Type.GetType("System.String"))
        table.Columns.Add("SerialBaston", System.Type.GetType("System.String"))
        table.Columns.Add("AuditCenCod", System.Type.GetType("System.String"))        'GetType(Integer)
        table.Columns.Add("AuditID", System.Type.GetType("System.String"))
        table.Columns.Add("Lectura", System.Type.GetType("System.String"))
        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1
            Dim DIIOXls As String = listview.Items(i).SubItems(1).Text
            'Dim FechaXls As DateTime = listview.Items(i).SubItems(2).Text
            Dim StrFechaXls As String = listview.Items(i).SubItems(2).Text
            table.Rows.Add(DIIOXls,
                           StrFechaXls,
                           listview.Items(i).SubItems(3).Text,
             centro, audi, Lectura)
        Next
        LVToDataTableExcel = table

    End Function


    Public Function InsertSesion(ByVal dat As fnAuditoriaLectorDatos, ByVal Formulario As String) As Integer
        InsertSesion = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAuditoriaLector_Sesion", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@centroCod", dat.CentroCod)
        cmd.Parameters.AddWithValue("@TipoCarga", dat.Tipocarga)
        cmd.Parameters.AddWithValue("@Formulario", Formulario)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@NombrePC", NombrePC)

        cmd.Parameters.Add("@RetVal", SqlDbType.Int) : cmd.Parameters("@RetVal").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@RetMsg").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetAuditID", SqlDbType.Int) : cmd.Parameters("@RetAuditID").Direction = ParameterDirection.Output

        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            vret = cmd.Parameters("@RetVal").Value
            mret = cmd.Parameters("@RetMsg").Value

            InsertSesion = cmd.Parameters("@RetAuditID").Value

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
    End Function

End Class