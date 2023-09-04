Imports System.Data.SqlClient
Public Class MSTR_Patologias
    Inherits SQLData
    Private datos_ As DataTable = Nothing
    ''
    Private params_in_ As Hashtable = Nothing
    Private params_out_ As Hashtable = Nothing
    Private orden_ As String = ""

    Public ReadOnly Property CampoCod As String
        Get
            Return "CodPatologia"
        End Get
    End Property
    Public ReadOnly Property CampoNom As String
        Get
            Return "NomPatologia"
        End Get
    End Property
    Public ReadOnly Property Preventivo As String
        Get
            Return "EsPreventivo"
        End Get
    End Property
    Public ReadOnly Property FarmCod As String
        Get
            Return "MedCodigo"
        End Get
    End Property
    Public ReadOnly Property FarmNom As String
        Get
            Return "MedNombre"
        End Get
    End Property
    Public ReadOnly Property FarmTrat As String
        Get
            Return "TratDiasDuracion"
        End Get
    End Property
    Public ReadOnly Property FarmRes As String
        Get
            Return "TratResguardoLeche"
        End Get
    End Property
    Public ReadOnly Property FarmGlo As String
        Get
            Return "TratDuracionTrat"
        End Get
    End Property
    Public ReadOnly Property FarmCarne As String
        Get
            Return "TratResguardoCarne"
        End Get
    End Property
    Public ReadOnly Property FarmDosis As String
        Get
            Return "TratDosis"
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
    Private Sub Patologias_QRY_Cargar()
        datos_ = Nothing
        If Conectar(ServidorConexion.Manuka_PROD) Then
            datos_ = SQLStoredProcedure_QRY2("spPabco_Patologias", params_in_)

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
    Public Sub DSCboPatologias_FrmQRY(ByVal CboBox As ComboBox)

        ParametrosEntrada = Nothing
        ParametrosSalida = Nothing
        Patologias_QRY_Cargar()

        CboBox.DataSource = GETData()
        CboBox.DisplayMember = CampoNom

    End Sub
    Private Sub Medicamentos_QRY_Cargar()
        datos_ = Nothing
        If Conectar(ServidorConexion.Manuka_PROD) Then
            datos_ = SQLStoredProcedure_QRY2("spPabco_Medicamentos", params_in_)

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
    Public Sub DSCboMedicamentos_FrmQRY(ByVal CboMedicamentos As ComboBox, ByVal codpatologias As Integer)

        Dim params_in As New Hashtable From {
            {"@Patologia", codpatologias}
        }

        ParametrosEntrada = params_in
        ParametrosSalida = Nothing
        Medicamentos_QRY_Cargar()

        CboMedicamentos.DataSource = GETData()
        CboMedicamentos.DisplayMember = FarmNom

    End Sub
End Class
