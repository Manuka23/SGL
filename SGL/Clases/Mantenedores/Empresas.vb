

Imports System.Data.SqlClient

Public Class Empresas
    Public EmpresaCod As String()
    Public EmpresaNom As String()
    Public EmpresaRut As String()


    Private nregs As Integer



    Private Sub listado_registros()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spEmpresas_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        ReDim Preserve EmpresaCod(i)
        ReDim Preserve EmpresaNom(i)
        ReDim Preserve EmpresaRut(i)


        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    ReDim Preserve EmpresaCod(i)
                    ReDim Preserve EmpresaNom(i)
                    ReDim Preserve EmpresaRut(i)


                    EmpresaCod(i) = rdr("EmpresaCod")
                    EmpresaNom(i) = rdr("EmpresaNom")
                    EmpresaRut(i) = rdr("EmpresaRut")

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