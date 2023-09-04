

Imports System.Data.SqlClient


Public Class CausasDecomisos

    Public DecomisoCod As Integer()
    Public DecomisoNom As String()
    Public DecomisoCateg As String()
    Public DecomisoNomENG As String()

    Private nregs As Integer

    Public Sub Cargar()
        Listado_Decomisos()
    End Sub

    Private Sub Listado_Decomisos()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_ListadoCausas", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@UserName", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        ReDim Preserve DecomisoCod(i)
        ReDim Preserve DecomisoNom(i)
        ReDim Preserve DecomisoCateg(i)
        ReDim Preserve DecomisoNomENG(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve DecomisoCod(i)
                    ReDim Preserve DecomisoNom(i)
                    ReDim Preserve DecomisoCateg(i)
                    ReDim Preserve DecomisoNomENG(i)

                    DecomisoCod(i) = rdr("CauCodigo")
                    DecomisoNom(i) = rdr("CauNombre").ToString.Trim
                    DecomisoCateg(i) = rdr("CategoriaDecomiso").ToString.Trim
                    DecomisoNomENG(i) = rdr("CauNombreENG").ToString.Trim

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

    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property
End Class
