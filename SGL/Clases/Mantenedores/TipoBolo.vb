Imports System.Data.SqlClient

Public Class TipoBolo

    Public Codigo As Integer()
    Public Nombre As String()
    Public UniMedida As String()
    Private nregs As Integer


    Private Sub listado_registros(ByVal centro As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_TipoBolos", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve UniMedida(i)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve UniMedida(i)

                    Codigo(i) = rdr("ItemCodigo")
                    Nombre(i) = rdr("ItemNombre")
                    UniMedida(i) = rdr("ItemUniMed")
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


    Public Sub Cargar(ByVal centro As String)
        listado_registros(centro)
    End Sub


    'Public Sub BuscarCentroPorCodigo(ByVal CodigoCentro As String)
    '    'buscar_centros_por_codigo(CodigoCentro)
    'End Sub


    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class
