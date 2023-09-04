

Imports System.Data.SqlClient



Public Class Proveedores

    Public Codigo As String()
    Public Nombre As String()
    Public NombreRut As String()
    Public EsContratista As String()
    Public Categoria As String()

    Private nregs As Integer



    Private Sub listado_registros()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDiios_ListadoProveedores", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve NombreRut(i)
        ReDim Preserve EsContratista(i)
        ReDim Preserve Categoria(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve NombreRut(i)
                    ReDim Preserve EsContratista(i)
                    ReDim Preserve Categoria(i)

                    Codigo(i) = rdr("PrvCod").ToString.Trim
                    Nombre(i) = rdr("PrvRazSoc").ToString.Trim
                    NombreRut(i) = rdr("PrvRazSoc") 'FormateaRUT(IIf(IsDBNull(rdr("PrvCod")), 0, rdr("PrvCod")), IIf(IsDBNull(rdr("PrvDV")), "", rdr("PrvDV"))) + " - " + rdr("PrvRazSoc").ToString.Trim
                    EsContratista(i) = rdr("PrvIsCnt").ToString.Trim
                    Categoria(i) = rdr("TipPrvCod").ToString.Trim

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
