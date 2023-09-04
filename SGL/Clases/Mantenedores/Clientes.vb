

Imports System.Data.SqlClient



Public Class Clientes

    Public Codigo As String()
    Public Nombre As String()
    Public NombreRut As String()

    Private nregs As Integer



    Private Sub listado_registros()
        Dim con As New SqlConnection(GetConnectionStringFIN()) 'IIf(SRV_Servidor <> "SRVMNK", GetConnectionStringFIN(), GetConnectionString()))
        Dim cmd As New SqlCommand("spGPClientes_Listado", con) 'IIf(SRV_Servidor <> "SRVMNK", "spGPClientes_Listado", "spClientes_Listado"), con)
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
        ''
        Dim rut, dv As String

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve NombreRut(i)

                    Codigo(i) = rdr("CliCod")
                    Nombre(i) = rdr("CliRazSoc").ToString.Trim
                    ''
                    rut = IIf(IsDBNull(rdr("CliCod")), "", rdr("CliCod"))
                    dv = IIf(IsDBNull(rdr("CliDV")), "", rdr("CliDV"))

                    If rut.Length >= 8 Then

                    End If


                    'If SRV_Servidor <> "SRVMNK" Then
                    'clientes dynamics
                    NombreRut(i) = FormateaRUTGP(rut) + " - " + rdr("CliRazSoc").ToString.Trim
                    'Else
                    'clientes ivs
                    'NombreRut(i) = FormateaRUT(rut, dv) + " - " + rdr("CliRazSoc").ToString.Trim
                    'End If


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
