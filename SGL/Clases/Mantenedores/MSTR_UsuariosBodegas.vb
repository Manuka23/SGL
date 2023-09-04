Imports System.Data.SqlClient
Public Class MSTR_UsuariosBodegas
    Inherits SQLData

    Private datos_ As DataTable = Nothing
    Private params_in_ As Hashtable = Nothing
    Private params_out_ As Hashtable = Nothing
    Private orden_ As String = ""

    Public ReadOnly Property CampoCod As String
        Get
            Return "BodegaCod"
        End Get
    End Property

    Public ReadOnly Property CampoNom As String
        Get
            Return "BodegaNom"
        End Get
    End Property

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

    Public Property ParametrosOrdenDatos As String
        Get
            Return orden_
        End Get

        Set(ByVal value As String)
            orden_ = value
        End Set
    End Property

    Public Function GETData() As DataTable
        Return datos_
    End Function

    Private Sub Usuario_Bodegas_QRY_Cargar()
        datos_ = Nothing
        If Conectar(ServidorConexion.Manuka_PROD) Then
            datos_ = SQLStoredProcedure_QRY("spBodegas_ListadoPorUsuario", params_in_)

            If NroRegistros = -1 Then
                If datos_ Is Nothing Then
                    MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If
            End If

        Else
            MsgBox(Mensaje, MsgBoxStyle.Critical, "Error")
        End If
    End Sub
    Public Sub DSCboUsuarioBodegas_FrmQRY(ByVal CboBox As ComboBox)

        ''--------------------------------------------------------------------------------------
        ParametrosEntrada = Nothing
        ParametrosSalida = Nothing
        Usuario_Bodegas_QRY_Cargar()

        CboBox.DataSource = GETData()
        CboBox.DisplayMember = CampoNom
    End Sub
End Class
