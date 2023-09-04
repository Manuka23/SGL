
Imports System.Data.SqlClient


Public Class TiposSolidos

    Public Codigo As String()
    Public Nombre As String()
    Public Cantidad As Integer()
    Private nregs As Integer

    Private Sub listado_registros()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSolidos_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve Cantidad(i)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve Cantidad(i)

                    Codigo(i) = rdr("CodigoSolido").ToString.Trim
                    Nombre(i) = rdr("NombreSolido").ToString.Trim
                    Cantidad(i) = rdr("CantMaxSolido").ToString.Trim
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
