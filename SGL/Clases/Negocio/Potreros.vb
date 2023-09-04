




Imports System.Data.SqlClient



Public Class ListaPotreros
    Inherits Conexion


    Private datos_ As DataTable = Nothing
    Private busca_ As DataTable = Nothing
    ''
    Private params_in_ As Hashtable = Nothing
    Private params_out_ As Hashtable = Nothing
    ''
    Private agregartodos_ As Boolean = False
    ''
    ''definicion de campos
    Private rut_ As String
    Private nom_ As String
    Private tip_ As String
    Private emp_ As String
    Private area_ As String



    Public Function ObtenerDatos() As DataTable
        Return datos_
    End Function


    'Public Function ObtenerDatosCliente() As DataTable
    '    Return busca_
    'End Function


    'Public Property AgregarOpcionTodos As Boolean
    '    Get
    '        Return agregartodos_
    '    End Get

    '    Set(ByVal value As Boolean)
    '        If value = False Then
    '            params_in_ = Nothing
    '        Else
    '            Dim pm As New Hashtable
    '            pm.Add("@Todos", Convert.ToInt32(1))
    '            params_in_ = pm
    '        End If

    '        agregartodos_ = value
    '    End Set
    'End Property


    'Public ReadOnly Property CampoCodigo As String
    '    Get
    '        Return "CliCod"
    '    End Get
    'End Property


    'Public ReadOnly Property CampoNombre As String
    '    Get
    '        Return "CliRazSoc"
    '    End Get
    'End Property


    Public Property ParametrosEntrada As Hashtable
        Get
            Return params_in_
        End Get

        Set(ByVal value As Hashtable)
            params_in_ = value
        End Set
    End Property


    Public Property ParametrosSalida As Hashtable
        Get
            Return params_out_
        End Get

        Set(ByVal value As Hashtable)
            params_out_ = value
        End Set
    End Property


    Public Sub Cargar() 'As DataSet
        'Cargar = Nothing

        If Conectar(GetConnectionString()) Then
            datos_ = SQLConsultarProcAlm("spPotreros_Listado", params_in_)

            If datos_ Is Nothing Then
                MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
        End If
    End Sub


    'Public Function Buscar() As Boolean 'As DataSet
    '    'Cargar = Nothing
    '    Buscar = False

    '    If Conectar(ServidorConexion.Manuka_RRHH) Then
    '        busca_ = SQLConsultarProcAlm("spPotreros_Buscar", params_in_)

    '        rut_ = ""
    '        nom_ = ""
    '        tip_ = ""
    '        area_ = ""

    '        If busca_ Is Nothing Then
    '            MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
    '        Else
    '            If busca_.Rows.Count > 0 Then
    '                Buscar = True
    '                rut_ = busca_.Rows(0).Item("Rut").ToString.Trim
    '                nom_ = busca_.Rows(0).Item("Nombre").ToString.Trim
    '                emp_ = busca_.Rows(0).Item("Empresa").ToString.Trim
    '                area_ = busca_.Rows(0).Item("Centro").ToString.Trim
    '            End If
    '        End If
    '    Else
    '        MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
    '    End If
    'End Function


    Public Function EliminarTodosCentro() As Boolean
        EliminarTodosCentro = False

        ''si no hay una transaccion activa, realizamos la conección a la base de datos
        If Not TransaccionActiva Then
            Dim cn As Boolean = Conectar(ServidorConexion.Manuka_RRHH)

            If cn = False Then
                MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
                Exit Function
            End If
        End If

        Dim cod_ As Integer = SQLEjecutarProcAlm("spPotreros_EliminarTodosCentro", params_in_, params_out_)

        If cod_ <> 0 Then
            'If datos_ Is Nothing Then
            MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
            Return False
        End If

        Return True
    End Function


    Public Function Grabar() As Boolean
        Grabar = False

        ''si no hay una transaccion activa, realizamos la conección a la base de datos
        If Not TransaccionActiva Then
            Dim cn As Boolean = Conectar(ServidorConexion.Manuka_PROD)

            If cn = False Then
                MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
                Exit Function
            End If
        End If

        Dim cod_ As Integer = SQLEjecutarProcAlm("spPotreros_GrabarPlanilla", params_in_, params_out_)

        If cod_ <> 0 Then
            'If datos_ Is Nothing Then
            MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
            Return False
        End If

        Return True
    End Function


    'Public ReadOnly Property Rut As String
    '    Get
    '        Return rut_
    '    End Get
    'End Property


    'Public ReadOnly Property Nombre As String
    '    Get
    '        Return nom_
    '    End Get
    'End Property


    'Public ReadOnly Property Tipo As String
    '    Get
    '        Return tip_
    '    End Get
    'End Property


    'Public ReadOnly Property Empresa As String
    '    Get
    '        Return emp_
    '    End Get
    'End Property


    'Public ReadOnly Property Area As String
    '    Get
    '        Return area_
    '    End Get
    'End Property
End Class
