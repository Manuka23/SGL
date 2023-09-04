

Imports System.Data.SqlClient



Public Class FarmacosPatologia


    Public Codigo As Integer()
    Public Nombre As String()
    Public DiasTratamiento As Integer()
    Public DiasResguardo As Integer()
    Public Glosa As String()


    Private nregs As Integer


    Private Sub listado_registros(ByVal Patologia As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spFarmacos_ListadoPatologia", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Patologia", Patologia)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve DiasTratamiento(i)
        ReDim Preserve DiasResguardo(i)
        ReDim Preserve Glosa(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve DiasTratamiento(i)
                    ReDim Preserve DiasResguardo(i)
                    ReDim Preserve Glosa(i)

                    Codigo(i) = rdr("FarmCodigo")
                    Nombre(i) = rdr("FarmNombre").ToString.Trim
                    DiasTratamiento(i) = rdr("FarmDiasTratamiento")
                    DiasResguardo(i) = rdr("FarmDiasResguardo")
                    Glosa(i) = rdr("FarmGlosaTratamiento").ToString.Trim

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


    Public Sub Cargar(ByVal Patologia As Integer)
        listado_registros(Patologia)
    End Sub


    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class
