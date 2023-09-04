Imports System.Data.SqlClient



Public Class CentrosPayroll
    ' Public id As String()
    Public Codigo As String()
    Public Nombre As String()

    Private nregs As Integer


    Private Sub listado_registros()
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("SP_consulta_centros", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        Dim cencod As Integer

        'cencod = General.CodigoCentroUsuario
        cencod = General.Centros.Codigo(frmIngresoDiario.cboCentros.SelectedIndex)

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@cod_centro", cencod)
        ' cmd.Parameters.AddWithValue("@Usuario", "")
        ' cmd.Parameters.AddWithValue("@Equipo", "")

        i = 0
        ' ReDim Preserve id(i)
        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    'ReDim Preserve id(i)
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ' id(i) = rdr("IdNomenclatura").ToString.Trim
                    Codigo(i) = rdr("Codigo").ToString.Trim
                    Nombre(i) = rdr("Descrip").ToString.Trim

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




