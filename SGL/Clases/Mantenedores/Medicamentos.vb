
Imports System.Data.SqlClient


Public Class Medicamentos

    '
    Public Codigo As String()
    Public Nombre As String()
    Public Observacion As String()
    Public Duracion As String()
    Public DiasDuracion As Integer()
    Public Dosis As String()
    Public ResguardoLeche As Integer()
    Public ResguardoCarne As Integer()


    Private nregs As Integer


    Private Sub listado_registros(Optional ByVal Patologia As Integer = 0)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_Medicamentos", con)
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
        ReDim Preserve Observacion(i)
        ReDim Preserve Duracion(i)
        ReDim Preserve DiasDuracion(i)
        ReDim Preserve Dosis(i)
        ReDim Preserve ResguardoLeche(i)
        ReDim Preserve ResguardoCarne(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve Observacion(i)
                    ReDim Preserve Duracion(i)
                    ReDim Preserve DiasDuracion(i)
                    ReDim Preserve Dosis(i)
                    ReDim Preserve ResguardoLeche(i)
                    ReDim Preserve ResguardoCarne(i)

                    Codigo(i) = rdr("MedCodigo").ToString.Trim
                    Nombre(i) = rdr("MedNombre").ToString.Trim
                    Observacion(i) = rdr("TratObservacion").ToString.Trim
                    Duracion(i) = rdr("TratDuracionTrat").ToString.Trim
                    DiasDuracion(i) = rdr("TratDiasDuracion")
                    Dosis(i) = rdr("TratDosis").ToString.Trim
                    ResguardoLeche(i) = rdr("TratResguardoLeche")
                    ResguardoCarne(i) = rdr("TratResguardoCarne")


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


End Class
