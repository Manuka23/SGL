Imports System.Data.SqlClient
Public Class MSTR_CuentasContables
    Inherits SQLData

    Private datos_ As DataTable = Nothing
    ''
    Private params_in_ As Hashtable = Nothing
    Private params_out_ As Hashtable = Nothing
    Private orden_ As String = ""

    Public ReadOnly Property CampoCod As String
        Get
            Return "CuentaCod"
        End Get
    End Property

    Public ReadOnly Property CampoNom As String
        Get
            Return "CuentaNom"
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
    Public Function GETData() As DataTable
        Return datos_
    End Function
    Private Sub CuentasContables_QRY_Cargar()
        datos_ = Nothing
        If Conectar(ServidorConexion.Manuka_PROD) Then
            datos_ = SQLStoredProcedure_QRY("spBodegas_CuentasContables_Listado", params_in_)

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
    Public Sub DSCboCuentasContables_Frm_QRY(ByVal CboBox As ComboBox)
        ''--------------------------------------------------------------------------------------
        ''DEFINICION DE PARAMETROS
        'Dim params_in As New Hashtable
        'params_in.Add("@EmpresaCod", Empresa)
        ''--------------------------------------------------------------------------------------
        ParametrosEntrada = Nothing
        ParametrosSalida = Nothing
        CuentasContables_QRY_Cargar()

        CboBox.DataSource = GETData()
        CboBox.DisplayMember = "CuentaNom"
    End Sub
    Private Sub ItemsGasto_QRY_Cargar()
        datos_ = Nothing
        If Conectar(ServidorConexion.Manuka_PROD) Then
            datos_ = SQLStoredProcedure_QRY("spBodegas_CuentasContables_ItemsGasto_Listado", params_in_)

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

    Public Sub DSCboItemsGasto_Frm_QRY(ByVal CuentaCod As String, ByVal CboBox As ComboBox)
        ''--------------------------------------------------------------------------------------
        ''DEFINICION DE PARAMETROS
        Dim params_in As New Hashtable
        params_in.Add("@CuentaCod", CuentaCod)
        ''--------------------------------------------------------------------------------------
        ParametrosEntrada = params_in
        ParametrosSalida = Nothing
        ItemsGasto_QRY_Cargar()

        CboBox.DataSource = GETData()
        CboBox.DisplayMember = "ItemGastoNom"
    End Sub

End Class
