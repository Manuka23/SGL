Imports System.Data.SqlClient



Public Class StockBodega


    Public Codigo As String()
    Public Nombre As String()
    Public Stock As String()
    Public Medida As String()
    Public Clase As String()
    Public CostoActual As String()
    Private nregs As Integer


    Private Sub listado_registros(ByVal Bodega As String, ByVal Traslados As String)
        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPInventario_ArticulosPorBodegaSGLListado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@BodCod", Bodega)
        cmd.Parameters.AddWithValue("@SoloConStock", 1)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve Stock(i)
        ReDim Preserve Medida(i)
        ReDim Preserve Clase(i)
        ReDim Preserve CostoActual(i)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    If Traslados = 0 Then
                        If rdr("StockActual") > 0 Then
                            ReDim Preserve Codigo(i)
                            ReDim Preserve Nombre(i)
                            ReDim Preserve Stock(i)
                            ReDim Preserve Medida(i)
                            ReDim Preserve Clase(i)
                            ReDim Preserve CostoActual(i)
                            Codigo(i) = rdr("ITEMNMBR")
                            Nombre(i) = rdr("ITEMDESC").ToString.Trim
                            Stock(i) = Format(rdr("StockActual"), "#,##0.00")
                            Medida(i) = rdr("UOFM").ToString.Trim 'ITMCLSCD
                            Clase(i) = rdr("ITMCLSCD").ToString.Trim
                            CostoActual(i) = rdr("CostoActual")
                            i += 1
                        End If
                    Else

                        ReDim Preserve Codigo(i)
                        ReDim Preserve Nombre(i)
                        ReDim Preserve Stock(i)
                        ReDim Preserve Medida(i)
                        ReDim Preserve Clase(i)
                        ReDim Preserve CostoActual(i)
                        CostoActual(i) = rdr("CostoActual")
                        Codigo(i) = rdr("ITEMNMBR")
                        Nombre(i) = rdr("ITEMDESC").ToString.Trim
                        Stock(i) = Format(rdr("StockActual"), "#,##0.00")
                        Medida(i) = rdr("UOFM").ToString.Trim 'ITMCLSCD
                        Clase(i) = rdr("ITMCLSCD").ToString.Trim
                        i += 1

                    End If


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

    Public Sub Cargar(ByVal Bodega As String, ByVal Traslados As String)
        listado_registros(Bodega, Traslados)
    End Sub

    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class
