Imports System.Data.SqlClient

Public Class ClientesPlanta
    Inherits Conexion

    Private datos_ As DataTable = Nothing
    Private ValCodigo As String = "", ValNombre As String = ""
    Private params_in_ As Hashtable = Nothing
    Private params_out_ As Hashtable = Nothing
    Public Function ObtenerClientesPlanta() As DataTable
        ValCodigo = "CliCod"
        ValNombre = "CliNom"

        Me.ParametrosEntrada = Nothing
        Me.ParametrosSalida = Nothing
        ''
        Me.spGPClientes_ListadoSGL()
        ''
        Return datos_
    End Function

    Private Sub spGPClientes_ListadoSGL()
        If ConectorBase(ServidorConexion.Manuka_FIN) Then
            datos_ = SQLConsultarProcAlm("spGPClientes_ListadoSGL", params_in_, params_out_)
        End If
    End Sub
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

    Public ReadOnly Property CampoCodigo As String
        Get
            Return ValCodigo
        End Get
    End Property

    Public ReadOnly Property CampoNombre As String
        Get
            Return ValNombre
        End Get
    End Property
End Class
