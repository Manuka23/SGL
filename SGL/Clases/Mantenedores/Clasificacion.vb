Imports System.Data.SqlClient

Module Clasificacion



    Public Cod As String()
    Public Nombre As String()
    Public NroRegistros As Integer
    Public Sub Listado()
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spLuz_CasificacionSitiosListado]", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        i = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        ReDim Preserve Cod(i)
        ReDim Preserve Nombre(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Cod(i)
                    ReDim Preserve Nombre(i)

                    Cod(i) = Integer.Parse(rdr("ClasificacionCod").ToString.Trim)
                    Nombre(i) = rdr("ClasificacionNom").ToString.Trim

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
