Imports System.Data.SqlClient
Public Class SQLData
    Private _mensaje As String
    Private _sentenciaSQL As String
    Private conn As SqlConnection
    Private _nroregs As Integer
    Private miTran As SqlTransaction


    Public Enum ServidorConexion
        Manuka_PROD = 1
        Manuka_RRHH = 2
    End Enum


    Public Enum Transaccion
        ReadCommited = IsolationLevel.ReadCommitted
        ReadUncommitted = IsolationLevel.ReadUncommitted
    End Enum


    Public ReadOnly Property TransaccionActiva As Boolean
        Get
            If miTran Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property


    Public Function Conectar(ByVal cn As ServidorConexion, Optional ByVal bd As String = "") As Boolean
        Conectar = False

        Dim strcon_ As String = GetConnectionStringPROD()

        Select Case cn
            Case ServidorConexion.Manuka_PROD
                strcon_ = GetConnectionStringPROD()

            Case ServidorConexion.Manuka_RRHH
                strcon_ = GetConnectionStringRRHH()

        End Select

        Try
            conn = New SqlConnection(strcon_)
            conn.Open()
            Conectar = True

        Catch ex As Exception
            Mensaje = "Error de conexión: " + ex.Message.ToString
        End Try
    End Function


    Public Function SQLStoredProcedure_QRY(ByVal ProcAlmacenado As String, Optional ByVal ParamsIN As Hashtable = Nothing, Optional ByVal ParamsOUT As Hashtable = Nothing) As DataTable
        SQLStoredProcedure_QRY = Nothing

        Try
            'conn.Open()

            Dim cmd As New SqlCommand(ProcAlmacenado, conn)
            Dim rdr As SqlDataReader = Nothing
            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
            cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
            cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

            If ParamsIN IsNot Nothing Then
                For Each pname As String In ParamsIN.Keys
                    cmd.Parameters.AddWithValue(pname, ParamsIN(pname))
                Next
            End If

            If ParamsOUT IsNot Nothing Then
                For Each pname As String In ParamsOUT.Keys
                    cmd.Parameters.AddWithValue(pname, ParamsOUT(pname))
                    cmd.Parameters(pname).Direction = ParameterDirection.Output
                Next
            End If

            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)

            Mensaje = "La consulta de datos fue Exitosa"

            If ds.Tables.Count > 0 Then
                _nroregs = ds.Tables(0).Rows.Count
                Return ds.Tables(0)
            Else
                _nroregs = 0
                Return Nothing
            End If

        Catch ex As Exception
            _nroregs = -1
            Mensaje = "Error al consultatar datos: " + ex.Message.ToString
        Finally
            conn.Close()
        End Try
    End Function

    Public Function SQLStoredProcedure_QRY2(ByVal ProcAlmacenado As String, Optional ByVal ParamsIN As Hashtable = Nothing, Optional ByVal ParamsOUT As Hashtable = Nothing) As DataTable
        SQLStoredProcedure_QRY2 = Nothing

        Try
            'conn.Open()

            Dim cmd As New SqlCommand(ProcAlmacenado, conn)
            Dim rdr As SqlDataReader = Nothing
            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.Clear()

            If ParamsIN IsNot Nothing Then
                For Each pname As String In ParamsIN.Keys
                    cmd.Parameters.AddWithValue(pname, ParamsIN(pname))
                Next
            End If

            If ParamsOUT IsNot Nothing Then
                For Each pname As String In ParamsOUT.Keys
                    cmd.Parameters.AddWithValue(pname, ParamsIN(pname))
                    cmd.Parameters(pname).Direction = ParameterDirection.Output
                Next
            End If

            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet
            da.Fill(ds)

            Mensaje = "La consulta de datos fue Exitosa"

            If ds.Tables.Count > 0 Then
                _nroregs = ds.Tables(0).Rows.Count
                Return ds.Tables(0)
            Else
                _nroregs = 0
                Return Nothing
            End If

        Catch ex As Exception
            _nroregs = -1
            Mensaje = "Error al consultatar datos: " + ex.Message.ToString
        Finally
            conn.Close()
        End Try
    End Function
    Public Function SQLStoredProcedure_TRN(ByVal ProcAlmacenado As String, Optional ByVal ParamsIN As Hashtable = Nothing, Optional ByRef ParamsOUT As Hashtable = Nothing) As Integer
        SQLStoredProcedure_TRN = -100

        Try

            Dim cmd As New SqlCommand(ProcAlmacenado, conn)
            Dim rdr As SqlDataReader = Nothing
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.CommandTimeout = 300
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
            cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
            cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)
            ''
            cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

            If Not ParamsIN Is Nothing Then
                For Each pname As String In ParamsIN.Keys
                    cmd.Parameters.AddWithValue(pname, ParamsIN(pname))
                Next
            End If

            If Not ParamsOUT Is Nothing Then
                For Each pname As DictionaryEntry In ParamsOUT '.Keys
                    'cmd.Parameters.AddWithValue(pname, ParamsOUT(pname))

                    If pname.Value.GetType.FullName.Contains("Double") Then cmd.Parameters.Add(pname.Key, SqlDbType.Float)
                    If pname.Value.GetType.FullName.Contains("Integer") Then cmd.Parameters.Add(pname.Key, SqlDbType.Int)
                    If pname.Value.GetType.FullName.Contains("Int32") Then cmd.Parameters.Add(pname.Key, SqlDbType.Int)
                    If pname.Value.GetType.FullName.Contains("DateTime") Then cmd.Parameters.Add(pname.Key, SqlDbType.DateTime)
                    If pname.Value.GetType.FullName.Contains("String") Then cmd.Parameters.Add(pname.Key, SqlDbType.VarChar).Size = 500

                    cmd.Parameters(pname.Key).Direction = ParameterDirection.Output
                Next
            End If

            'solo si hay una transaccion (de la aplicacion) activa, la asociamos al comando
            If TransaccionActiva Then cmd.Transaction = miTran

            'ejecutamos consulta
            cmd.ExecuteNonQuery()

            If Not ParamsOUT Is Nothing Then
                Dim tmpHash As New Hashtable
                Dim HashKeys As IDictionaryEnumerator = ParamsOUT.GetEnumerator

                Do Until HashKeys.MoveNext = False
                    tmpHash.Add(HashKeys.Key, cmd.Parameters(HashKeys.Key).Value) '"newValue")
                Loop

                ParamsOUT = tmpHash.Clone()
            End If

            Mensaje = cmd.Parameters("@ResultMsg").Value
            Return cmd.Parameters("@ResultCod").Value

        Catch ex As Exception
            Mensaje = "Error ejecutar procedimiento almacenado " & ProcAlmacenado & "." & vbCrLf & "Error: " + ex.Message.ToString
            Return -1
        Finally
            If Not TransaccionActiva Then conn.Close()
        End Try
    End Function


    Public Property Mensaje As String
        Get
            Return _mensaje
        End Get
        Set(ByVal value As String)
            _mensaje = value
        End Set
    End Property


    Public ReadOnly Property NroRegistros As Integer
        Get
            Return _nroregs
        End Get
    End Property

    Private Function GetConnectionStringPROD() As String
        Dim bd As String = "MANUKA_PROD"
        Dim usr As String = "mnk_prod"
        Dim pwd As String = "mnkmnk"

        Return "Data Source=" + SRV_Servidor + ",1433" +
                                    ";Persist Security Info=True;" +
                                    "Initial Catalog=" + bd +
                                    ";User ID=" + usr +
                                    ";Password=" + pwd
    End Function


    Private Function GetConnectionStringRRHH() As String
        Dim bd As String = "MANUKA_rrhh"
        Dim usr As String = "manuka_rrhh"
        Dim pwd As String = "rrhh"

        Return "Data Source=" + SRV_Servidor + ",1433" +
                                    ";Persist Security Info=True;" +
                                    "Initial Catalog=" + bd +
                                    ";User ID=" + usr +
                                    ";Password=" + pwd
    End Function


    'Public Function TransaccionIniciar(ByVal TipoTransaccion As System.Data.IsolationLevel) As Boolean
    '    TransaccionIniciar = False

    '    Try
    '        conectamos e iniciamos una transaccion asociada a la conexión
    '        Conectar(ServidorConexion.Manuka_FIN)
    '        miTran = conn.BeginTransaction(IsolationLevel.ReadUncommitted)
    '        Return True

    '    Catch ex As Exception
    '        Mensaje = "Error de transacción: " + ex.Message.ToString
    '    End Try
    'End Function


    'Public Function TransaccionActualizar() As Boolean
    '    TransaccionActualizar = False

    '    Try
    '        miTran.Commit()
    '        conn.Close()

    '        miTran = Nothing
    '        Return True

    '    Catch ex As Exception
    '        Mensaje = "Error de transacción: " + ex.Message.ToString
    '    End Try
    'End Function


    'Public Function TransaccionCancelar() As Boolean
    '    TransaccionCancelar = False

    '    Try
    '        miTran.Rollback()
    '        conn.Close()

    '        miTran = Nothing
    '        Return True

    '    Catch ex As Exception
    '        Mensaje = "Error de transacción: " + ex.Message.ToString
    '    End Try
    'End Function
End Class
