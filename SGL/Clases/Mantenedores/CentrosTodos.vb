Imports System.Data.SqlClient

Public Class CentrosTodos
    '
    Public Codigo As String()
    Public Nombre As String()
    Public EsSharedMilker As Boolean()
    Public EsAreaSeca As Boolean()
    Public EsInterno As Boolean()

    Private nregs As Integer


    Private Sub listado_registros()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCentros_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve EsSharedMilker(i)
        ReDim Preserve EsAreaSeca(i)
        ReDim Preserve EsInterno(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve EsSharedMilker(i)
                    ReDim Preserve EsAreaSeca(i)
                    ReDim Preserve EsInterno(i)
                    Dim SharedMilker As String
                    Dim AreaSeca As String

                    Codigo(i) = rdr("CenCod").ToString.Trim
                    Nombre(i) = rdr("CenDesCor").ToString.Trim
                    SharedMilker = rdr("CenCodIsShared").ToString.Trim
                    If SharedMilker = 2 Then
                        EsSharedMilker(i) = True
                    Else
                        EsSharedMilker(i) = False
                    End If
                    'EsSharedMilker(i) = IIf(rdr("CenCodIsShared").ToString.Trim = "2", True, False)

                    AreaSeca = rdr("CenIsAreaSeca").ToString.Trim
                    If AreaSeca = "AREA SECA" Or AreaSeca = "POOL" Then
                        EsAreaSeca(i) = True
                    Else
                        EsAreaSeca(i) = False
                    End If
                    'EsAreaSeca(i) = IIf(rdr("CenIsAreaSeca").ToString.Trim = "POOL" Or "AREA SECA", True, False)
                    EsInterno(i) = IIf(rdr("CenIsHC").ToString.Trim = "SI", True, False)

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
