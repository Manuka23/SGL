

Imports System.Data.SqlClient


Public Class TipoUrea
    '
    Public Codigo As String()
    Public Nombre As String()
    Public Stock As Integer()
    'Public CodigoPorDefecto As String
    'Public NombrePorDefecto As String

    Private nregs As Integer


    Private Sub listado_registros(ByVal Centro As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_ProductoUreaPorCentro", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve Stock(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve Stock(i)

                    Codigo(i) = rdr("ItemCod").ToString.Trim
                    Nombre(i) = rdr("ProdUreaNom").ToString.Trim
                    Stock(i) = rdr("StkVal").ToString.Trim
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


    Public Sub Cargar(ByVal Centro As String)
        listado_registros(Centro)
    End Sub


    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class

