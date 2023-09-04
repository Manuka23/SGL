Imports System.Data.SqlClient

Public Class RCS_ListadoAños

    Public AñosRCS As String()
    Public AñoActualRCS As String

    Private nregs As Integer

    Private Sub Listado_Años()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_ListadoAños", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure

        i = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve AñosRCS(i)
                    
                    AñosRCS(i) = rdr("Años").ToString.Trim
                    
                    If i = 0 Then
                        AñoActualRCS = AñosRCS(i)
                    End If

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
        Listado_Años()
    End Sub

    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property
End Class
