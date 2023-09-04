Imports System.Data.SqlClient

Module Casa
    Public Cod As String()
    Public Sitio As String()
    Public CodMedidor As String()
    Public CodResponsable As String()
    Public CodCentro As String()
    Public NroRegistros As Integer

    Public Sub Listado(ByVal _CodCentro As String)
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spLuz_CasasListado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        i = 0

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@CenCod", _CodCentro)

        ReDim Preserve Cod(i)
        ReDim Preserve Sitio(i)
        ReDim Preserve CodMedidor(i)
        ReDim Preserve CodResponsable(i)
        ReDim Preserve CodCentro(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Cod(i)
                    ReDim Preserve Sitio(i)
                    ReDim Preserve CodMedidor(i)
                    ReDim Preserve CodResponsable(i)
                    ReDim Preserve CodCentro(i)

                    Cod(i) = rdr("CasCod").ToString.Trim
                    Sitio(i) = rdr("CasSitio").ToString.Trim
                    CodMedidor(i) = rdr("CasCodMedidor").ToString.Trim
                    CodResponsable(i) = rdr("CasCodResponsable").ToString.Trim
                    CodCentro(i) = rdr("CasCodCentro").ToString.Trim

                    i += 1
                End While
                rdr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("ERROR: " + ex.Message)
            End Try
            NroRegistros = i
        Finally
            con.Close()
        End Try
    End Sub
End Module
