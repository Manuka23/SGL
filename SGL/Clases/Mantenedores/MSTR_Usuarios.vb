Imports System.Data.SqlClient
Public Class MSTR_Usuarios
    Inherits SQLData

    Private datos_ As DataTable = Nothing
    ''
    Private params_in_ As Hashtable = Nothing
    Private params_out_ As Hashtable = Nothing
    Private orden_ As String = ""

    Public ReadOnly Property CampoCod As String
        Get
            Return "CentroCod"
        End Get
    End Property

    Public ReadOnly Property CampoNom As String
        Get
            Return "CentroNom"
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

    Private Sub Usuario_Centros_QRY_Cargar()
        datos_ = Nothing
        If Conectar(ServidorConexion.Manuka_PROD) Then
            datos_ = SQLStoredProcedure_QRY("spUsuarios_ListadoCentrosQRY", params_in_)

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
    Private Sub Usuario_Centros_INS_Cargar()
        datos_ = Nothing
        If Conectar(ServidorConexion.Manuka_PROD) Then
            datos_ = SQLStoredProcedure_QRY("spUsuarios_ListadoCentrosINS", params_in_)

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

    Public Sub Usuario_Centros_Frm_QRY(ByVal UsuarioCod As String, ByVal SoloGndLec As Boolean)
        ''--------------------------------------------------------------------------------------
        ''DEFINICION DE PARAMETROS
        Dim params_in As New Hashtable
        params_in.Add("@SoloGndLec", SoloGndLec)
        ''--------------------------------------------------------------------------------------
        LoginUsuario = UsuarioCod
        ParametrosEntrada = params_in
        ParametrosSalida = Nothing
        Usuario_Centros_QRY_Cargar()
    End Sub

    Public Sub DSCboUsuarioCentros_FrmINS(ByVal SoloGndLec As Boolean, ByVal CboBox As ComboBox)
        ''--------------------------------------------------------------------------------------
        ''DEFINICION DE PARAMETROS
        Dim params_in As New Hashtable
        params_in.Add("@SoloGndLec", SoloGndLec) 'TRUE: Ganado y Praderas 'FALSE: Ingreso Diario
        ''--------------------------------------------------------------------------------------
        ParametrosEntrada = params_in
        ParametrosSalida = Nothing
        Usuario_Centros_INS_Cargar()

        CboBox.DataSource = GETData()
        CboBox.DisplayMember = CampoNom
    End Sub
    Public Sub DSCboUsuarioCentros_FrmQRY(ByVal SoloGndLec As Boolean, ByVal CboBox As ComboBox)
        ''--------------------------------------------------------------------------------------
        ''DEFINICION DE PARAMETROS
        Dim params_in As New Hashtable
        params_in.Add("@SoloGndLec", SoloGndLec) 'TRUE: Ganado y Praderas 'FALSE: Ingreso Diario
        ''--------------------------------------------------------------------------------------
        ParametrosEntrada = params_in
        ParametrosSalida = Nothing
        Usuario_Centros_INS_Cargar()

        CboBox.DataSource = GETData()
        CboBox.DisplayMember = CampoNom

    End Sub
End Class
