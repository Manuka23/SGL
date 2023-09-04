Imports System.Data.SqlClient

Module TipoBudget
    Public Cod As Integer()
    Public Desc As String()
    Public NroRegistros As Integer



    Public Sub Listado(ByVal usuario As String)
        Dim con As New SqlConnection(GetConnectionStringBI())
        Dim cmd As New SqlCommand("sp_tipo_budget_listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@userName", LoginUsuario)
        'ReDim Preserve Cod(i)
        'ReDim Preserve Desc(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    ReDim Preserve Cod(i)
                    ReDim Preserve Desc(i)
                    Cod(i) = rdr("cod").ToString.Trim
                    Desc(i) = rdr("descripcion").ToString.Trim
                    i += 1
                End While
                rdr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("ERROR: " + ex.Message)
            End Try

        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message)
        Finally
            con.Close()

        End Try
        NroRegistros = i
    End Sub

    Public Sub ListadoTipo()
        Dim con As New SqlConnection(GetConnectionStringBI())
        Dim cmd As New SqlCommand("sp_tipo_carga_listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        'ReDim Preserve Cod(i)
        'ReDim Preserve Desc(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    ReDim Preserve Cod(i)
                    ReDim Preserve Desc(i)
                    Cod(i) = rdr("cod").ToString.Trim
                    Desc(i) = rdr("descripcion").ToString.Trim
                    i += 1
                End While
                rdr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("ERROR: " + ex.Message)
            End Try

        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message)
        Finally
            con.Close()

        End Try
        NroRegistros = i
    End Sub

End Module
