


Imports System.Data.SqlClient



Public Class Centros
    '
    Public _Codigo1 As Integer
    Public _Nombre1 As String

    Public Codigo As String()
    Public Nombre As String()
    Public EsSharedMilker As Boolean()
    Public EsAreaSeca As Boolean()
    Public EsInterno As Boolean()
    Public EsTernerera As Boolean()
    Public TipoCentro As String()

    'Public CodigoPorDefecto As String
    'Public NombrePorDefecto As String

    Private nregs As Integer


    Private Sub listado_registros()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCentros_ListadoPorUsuario", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        CodigoCentroUsuario = "0"
        NombreCentroUsuario = "[NO ASIGNADO]"

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve EsSharedMilker(i)
        ReDim Preserve EsAreaSeca(i)
        ReDim Preserve EsInterno(i)
        ReDim Preserve EsTernerera(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve EsSharedMilker(i)
                    ReDim Preserve EsAreaSeca(i)
                    ReDim Preserve EsInterno(i)
                    ReDim Preserve EsTernerera(i)
                    ReDim Preserve TipoCentro(i)

                    Codigo(i) = rdr("CenCod").ToString.Trim
                    Nombre(i) = rdr("CenDesCor").ToString.Trim
                    EsSharedMilker(i) = IIf(rdr("CenCodIsShared").ToString.Trim = "SM", True, False)
                    EsAreaSeca(i) = IIf(rdr("CenIsAreaSeca").ToString.Trim = "SI", True, False)
                    EsInterno(i) = IIf(rdr("CenIsHC").ToString.Trim = "SI", True, False)
                    EsTernerera(i) = IIf(rdr("CenTipo").ToString.Trim = "POOL", True, False)
                    Nombre(i) = rdr("CenDesCor").ToString.Trim
                    TipoCentro(i) = rdr("CentroTipo").ToString.Trim

                    If UCase(rdr("CentroDefault")) = "S" Then
                        CodigoCentroUsuario = Codigo(i)
                        NombreCentroUsuario = Nombre(i)
                    End If

                    i += 1
                End While

                'dispose data readers and commands
                rdr.Close()
                cmd.Dispose()
            Catch ex As Exception
                'capturamos, error y formateamos mensaje
                MsgBox("ERROR: " + ex.Message)
            End Try
        Finally
            'cerramos coneccion, al finalizar
            con.Close()
        End Try

        nregs = i
    End Sub


    Public Sub Cargar()
        listado_registros()
    End Sub


    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property
    Public Property Codigo1() As Integer
        Get
            Return _Codigo1

        End Get
        Set(ByVal val As Integer)
            _Codigo1 = val
        End Set
    End Property
    Public Property Nombre1() As String
        Get
            Return _Nombre1
        End Get
        Set(ByVal val As String)
            _Nombre1 = val
        End Set
    End Property


End Class
