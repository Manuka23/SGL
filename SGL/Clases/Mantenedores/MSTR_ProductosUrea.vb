Imports System.Data.SqlClient
Public Class MSTR_ProductosUrea
    Inherits SQLData

    Private datos_ As DataTable = Nothing
    ''
    Private params_in_ As Hashtable = Nothing
    Private params_out_ As Hashtable = Nothing
    Private orden_ As String = ""

    Public ReadOnly Property CampoCod As String
        Get
            Return "ProductoUreaCod"
        End Get
    End Property
    Public ReadOnly Property CampoNom As String
        Get
            Return "ProductoUreaNom"
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
    Private Sub Praderas_FertSuelo_Productos_QRY_Cargar()
        datos_ = Nothing
        If Conectar(ServidorConexion.Manuka_PROD) Then
            datos_ = SQLStoredProcedure_QRY("spPraderas_FertilidadSuelos_ProductosPorCentro", params_in_)

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
    Public Sub DSCboTipoUsoSuelo_FrmQRY(ByVal CentroCod As Integer, ByVal UsoTipo As Integer, ByVal CboBox As ComboBox)
        ''--------------------------------------------------------------------------------------
        ''DEFINICION DE PARAMETROS
        Dim params_in As New Hashtable From {
            {"@CentroCod", CentroCod},
            {"@TipoUso", UsoTipo} 'TRUE: Ganado y Praderas 'FALSE: Ingreso Diario
            }
        ''--------------------------------------------------------------------------------------
        ParametrosEntrada = params_in
        ParametrosSalida = Nothing
        Praderas_FertSuelo_Productos_QRY_Cargar()

        CboBox.DataSource = GETData()
        CboBox.DisplayMember = CampoNom

    End Sub
End Class
