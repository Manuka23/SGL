

Imports System.Data
Imports System.Data.SqlClient


Public Class Conexion
    Private _mensaje As String
    Private _sentenciaSQL As String
    Private conn As SqlConnection
    Private _nroregs As Integer
    Private miTran As SqlTransaction


    Public Enum ServidorConexion
        Manuka_PROD = 1
        Manuka_RRHH = 2
        Manuka_FIN = 3
    End Enum


    Public Enum Transaccion
        ReadCommited = IsolationLevel.ReadCommitted
        ReadUncommitted = IsolationLevel.ReadUncommitted
    End Enum


    Sub New()
        'conn = New SqlConnection()
        ''Ademas de conexión con el servidor SQL
        'Dim cadenaconexion As String = "Data Source=SED-A0B12B77C33\SQLEXPRESS;Initial Catalog= Directorio; Integrated Security=True"
        'conn = New SqlConnection(cadenaconexion)
    End Sub



    Public Function TransaccionIniciar(ByVal TipoTransaccion As System.Data.IsolationLevel) As Boolean
        TransaccionIniciar = False

        Try
            'conectamos e iniciamos una transaccion asociada a la conexión
            Conectar(ServidorConexion.Manuka_PROD)
            miTran = conn.BeginTransaction(IsolationLevel.ReadUncommitted)
            Return True

        Catch ex As Exception
            Mensaje = "Error de transacción: " + ex.Message.ToString
        End Try
    End Function


    Public Function TransaccionActualizar() As Boolean
        TransaccionActualizar = False

        Try
            miTran.Commit()
            conn.Close()

            miTran = Nothing
            Return True

        Catch ex As Exception
            Mensaje = "Error de transacción: " + ex.Message.ToString
        End Try
    End Function


    Public Function TransaccionCancelar() As Boolean
        TransaccionCancelar = False

        Try
            miTran.Rollback()
            conn.Close()

            miTran = Nothing
            Return True

        Catch ex As Exception
            Mensaje = "Error de transacción: " + ex.Message.ToString
        End Try
    End Function


    Public ReadOnly Property TransaccionActiva As Boolean
        Get
            If miTran Is Nothing Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property


    Public Function Conectar(ByVal cn As ServidorConexion) As Boolean
        Conectar = False

        Dim strcon_ As String = GetConnectionString()

        'Select Case cn
        '    Case ServidorConexion.Manuka_FIN
        '        strcon_ = GetConnectionStringFIN()

        '        'Case ConexionBD.Manuka_PROD
        '        'strcon_ = GetConnectionStringPROD()

        '    Case ServidorConexion.Manuka_RRHH
        '        strcon_ = GetConnectionStringRRHH()
        'End Select

        Try
            conn = New SqlConnection(strcon_)
            conn.Open()
            Conectar = True

        Catch ex As Exception
            Mensaje = "Error de conexión: " + ex.Message.ToString
        End Try
    End Function

    Public Function ConectorBase(ByVal cn As ServidorConexion) As Boolean
        ConectorBase = False

        Dim strcon_ As String = ""

        Select Case cn
            Case ServidorConexion.Manuka_FIN
                strcon_ = GetConnectionStringFIN()
        End Select

        Try
            conn = New SqlConnection(strcon_)
            If (conn.State = ConnectionState.Closed) Then conn.Open()

            ConectorBase = True

        Catch ex As Exception
            Mensaje = "Error de conexión: " + ex.Message.ToString
        End Try
    End Function


    Public Function SQLConsultarProcAlm(ByVal ProcAlmacenado As String, Optional ByVal ParamsIN As Hashtable = Nothing, Optional ByVal ParamsOUT As Hashtable = Nothing) As DataTable
        SQLConsultarProcAlm = Nothing

        Try
            'conn.Open()

            Dim cmd As New SqlCommand(ProcAlmacenado, conn)
            Dim rdr As SqlDataReader = Nothing
            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            If Not ParamsIN Is Nothing Then
                For Each pname As String In ParamsIN.Keys
                    cmd.Parameters.AddWithValue(pname, ParamsIN(pname))
                Next
            End If

            If Not ParamsOUT Is Nothing Then
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


    Public Function SQLEjecutarProcAlm(ByVal ProcAlmacenado As String, Optional ByVal ParamsIN As Hashtable = Nothing, Optional ByRef ParamsOUT As Hashtable = Nothing) As Integer
        SQLEjecutarProcAlm = -100

        Try
            'conn.Open()

            Dim cmd As New SqlCommand(ProcAlmacenado, conn)
            Dim rdr As SqlDataReader = Nothing
            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            ''
            cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

            If Not ParamsIN Is Nothing Then
                For Each pname As String In ParamsIN.Keys
                    cmd.Parameters.AddWithValue(pname, ParamsIN(pname))
                Next
            End If

            If Not ParamsOUT Is Nothing Then
                For Each pname As String In ParamsOUT.Keys
                    cmd.Parameters.AddWithValue(pname, ParamsOUT(pname))
                    cmd.Parameters(pname).Direction = ParameterDirection.Output
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

            Mensaje = cmd.Parameters("@RetMensage").Value
            Return cmd.Parameters("@RetValor").Value

        Catch ex As Exception
            Mensaje = "Error al ejcutar PA: " + ex.Message.ToString
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


    'Public Function ConsultarSQL(ByVal ProcedimientoAlmacenado As String) As DataSet
    '    Try
    '        conn.Open()
    '        Dim objRes As SqlDataAdapter
    '        objRes = New SqlDataAdapter(_sentenciaSQL, conn)
    '        Dim datos As DataSet = New DataSet()
    '        objRes.Fill(datos, "TablaConsultada")
    '        Mensaje = "La consulta de datos fue Exitosa"
    '        Return datos
    '    Catch MiExc As Exception
    '        Dim datos2 As DataSet = New DataSet()
    '        Mensaje = "Se presento el Siguiente Error: " + MiExc.Message
    '        Return datos2
    '    Finally
    '        conn.Close()
    '    End Try
    'End Function


    'Private Sub SetSentencia(ByVal sentencia As String)
    '    _sentenciaSQL = sentencia
    'End Sub


    'Private Function EjecutarSQL() As Boolean
    '    Try
    '        'Creación de un Objeto de tipo comando
    '        Dim miComando As SqlCommand = New SqlCommand()
    '        miComando.Connection = conn
    '        conn.Open()
    '        'Usando Objeto de tipo transacción se inicia la ejecucion SQL

    '        miComando.Connection = conn
    '        miComando.Transaction = miTran
    '        miComando.CommandText = _sentenciaSQL
    '        miComando.ExecuteNonQuery()
    '        ' Se Confirma la Transacción
    '        miTran.Commit()
    '        Mensaje = "Proceso Ejecutado con Exito"
    '        Return True
    '    Catch exec As Exception
    '        miTran.Rollback()
    '        Mensaje = "Se presento el siguiente error " + exec.Message
    '        Return False
    '    Finally
    '        conn.Close()
    '    End Try
    'End Function


    'Public Function GetConnectionString() As String
    '    Dim bd As String = "MANUKA_PROD"
    '    Dim usr As String = "mnk_prod"
    '    Dim pwd As String = "mnkmnk"

    '    Return "Data Source=" + SRV_Servidor + ",1433" + _
    '                                ";Persist Security Info=True;" + _
    '                                "Initial Catalog=" + bd + _
    '                                ";User ID=" + usr + _
    '                                ";Password=" + pwd
    'End Function


    'Public Function GetConnectionStringRRHH() As String
    '    Dim bd As String = "MANUKA_RRHH"
    '    Dim usr As String = "manuka_rrhh"
    '    Dim pwd As String = "manuka"

    '    Return "Data Source=" + SRV_Servidor + ",1433" + _
    '                                ";Persist Security Info=True;" + _
    '                                "Initial Catalog=" + bd + _
    '                                ";User ID=" + usr + _
    '                                ";Password=" + pwd
    'End Function


    'Private Function GetConnectionStringFIN() As String
    '    Dim bd As String = "MANUKA_FIN"
    '    Dim usr As String = "mnk_prod"
    '    Dim pwd As String = "mnkmnk"

    '    Return "Data Source=" + SRV_Servidor + ",1433" + _
    '                                ";Persist Security Info=True;" + _
    '                                "Initial Catalog=" + bd + _
    '                                ";User ID=" + usr + _
    '                                ";Password=" + pwd
    'End Function




End Class
