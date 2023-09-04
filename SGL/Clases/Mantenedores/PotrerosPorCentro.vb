
Imports System.Data.SqlClient
Public Class PotrerosPorCentro

    '
    Public Codigo As String()
    Public Nombre As String()
    Public Superficie As Double()

    'Public CodigoPorDefecto As String
    'Public NombrePorDefecto As String

    Private nregs As Integer


    Private Sub listado_registros(ByVal centro As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPotreros_ListadoPorCentro", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve Superficie(i)

                    Codigo(i) = rdr("PotreroCod").ToString.Trim
                    Nombre(i) = rdr("Nombre").ToString.Trim
                    Superficie(i) = rdr("Superficie").ToString.Trim
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


    Public Sub Cargar(ByVal centro As Integer)
        listado_registros(centro)
    End Sub


    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class
