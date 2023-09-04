


Imports System.Data.SqlClient



Public Class CentrosEstanques
    '
    Public Codigo As String()
    Public Nombre As String()
    Public CentroNomDefault As String
    Public NombreCompleto As String()
    Public CentroTipo As String()
    Public CentroVig As String()
    Public CentroCod As String()
    Public CentroNom As String()
    Public EstanqueCOD As String()
    Public EstanqueNOM As String()

    Private nregs As Integer


    Private Sub listado_centros()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCentros_ListadoPorUsuario_Estanques", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@UserName", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        'CodigoCentroUsuario = "0"
        'NombreCentroUsuario = "[NO ASIGNADO]"
        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve NombreCompleto(i)
        ReDim Preserve CentroTipo(i)
        ReDim Preserve CentroVig(i)
        ReDim Preserve EstanqueCOD(i)
        ReDim Preserve EstanqueNOM(i)


        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve NombreCompleto(i)
                    ReDim Preserve CentroTipo(i)
                    ReDim Preserve CentroVig(i)
                    ReDim Preserve EstanqueCOD(i)
                    ReDim Preserve EstanqueNOM(i)

                    Codigo(i) = rdr("Centro").ToString.Trim
                    Nombre(i) = rdr("CenNomCorto").ToString.Trim
                    NombreCompleto(i) = rdr("CentroNom").ToString.Trim
                    CentroTipo(i) = rdr("CentroTipo").ToString.Trim
                    CentroVig(i) = rdr("CentroVig").ToString.Trim
                    EstanqueCOD(i) = rdr("EstanqueCod").ToString.Trim
                    EstanqueNOM(i) = rdr("EstanqueNom").ToString.Trim

                    If UCase(rdr("CentroDefault")) = "S" Then
                        'CodigoCentroUsuario = Codigo(i)
                        'NombreCentroUsuario = Nombre(i)
                        CentroNomDefault = Nombre(i)
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
        listado_centros()
    End Sub


    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class
