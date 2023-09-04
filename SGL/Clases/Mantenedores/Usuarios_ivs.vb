Imports System.Data.SqlClient



Public Class Usuarios_ivs

    Public Codigo As String()
    Public Nombre As String()

    Private nregs As Integer


    Private Sub listado_registros()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuarios_ListadoUsuarios_IVS", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", "")
        cmd.Parameters.AddWithValue("@Usuario", "")
        cmd.Parameters.AddWithValue("@Equipo", "")

        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)

                    Codigo(i) = rdr("UsuCod").ToString.Trim
                    Nombre(i) = rdr("UsuNom").ToString.Trim

                    'MsgBox(Nombre(i))

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


    'Public Sub BuscarVeterinarioPorCodigo(ByVal CodigoCentro As String)
    '    'buscar_centros_por_codigo(CodigoCentro)
    'End Sub


    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property




End Class

