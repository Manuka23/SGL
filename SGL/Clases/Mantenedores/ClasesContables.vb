Imports System.Data.SqlClient

Public Class ClasesContables
    Public ClaseCod As String()
    Public ClaseNom As String()
    Public ClaseCuenta As String()
    Private nregs As Integer

    Private Sub listado_registros(ByVal TipoBusqueda As Integer)
        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPFinanciero_Listado_Clases", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
        cmd.Parameters.AddWithValue("@TipoBusqueda", TipoBusqueda)

        i = 0

        ReDim Preserve ClaseCod(i)
        ReDim Preserve ClaseNom(i)
        ReDim Preserve ClaseCuenta(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    ReDim Preserve ClaseCod(i)
                    ReDim Preserve ClaseNom(i)
                    ReDim Preserve ClaseCuenta(i)

                    ClaseCod(i) = rdr("ClaseCod").ToString.Trim
                    ClaseNom(i) = rdr("ClaseNom").ToString.Trim
                    ClaseCuenta(i) = rdr("ClaseCuenta").ToString.Trim
                    i += 1
                End While
                rdr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("ERROR: " + ex.Message)
            End Try
        Finally
            con.Close()
        End Try
        nregs = i
    End Sub


    Public Sub Cargar(ByVal TipoBusqueda As Integer)
        listado_registros(TipoBusqueda)
    End Sub

    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class