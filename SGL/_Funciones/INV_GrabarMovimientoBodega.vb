Imports System.Data.SqlClient
Public Class INV_GrabarMovimientoBodega
    Public guia As String = ""
    Public IVDOCNMBR As String = ""


    Public Function GrabarInventario(ByVal EmpresaCod As Integer, ByVal EmpresaDestino As Integer, ByVal DetalleConsumos As DataTable, ByVal Fecha As DateTime, ByVal TipoMovimiento As Integer, ByVal Observacion As String, ByVal BodegaOrigen As String, ByVal BodegaDestino As String) As String
        GrabarInventario = ""
        Cursor.Current = Cursors.WaitCursor

        Dim ConfirmarRecepcion As Boolean = False
        If TipoMovimiento = 3 Or TipoMovimiento = 2 Then
            ConfirmarRecepcion = True
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_GrabarINV", con)

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.Clear()

        cmd.Parameters.AddWithValue("@EmpresaCodO", EmpresaCod)
        cmd.Parameters.AddWithValue("@EmpresaCodD", EmpresaDestino)
        cmd.Parameters.AddWithValue("@MovFecha", Fecha)
        cmd.Parameters.AddWithValue("@MovObs", Observacion)
        cmd.Parameters.AddWithValue("@TipoMov", TipoMovimiento)
        cmd.Parameters.AddWithValue("@BodCodO", BodegaOrigen)
        cmd.Parameters.AddWithValue("@BodCodD", BodegaDestino)
        cmd.Parameters.AddWithValue("@DTBodega_DetalleItems", DetalleConsumos)
        cmd.Parameters.AddWithValue("@ConfirmarRecepcion", ConfirmarRecepcion)
        cmd.Parameters.AddWithValue("@UsuarioCodigo", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultDTETipoDoc", SqlDbType.Int) : cmd.Parameters("@ResultDTETipoDoc").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultDTEFoliDoc", SqlDbType.Int) : cmd.Parameters("@ResultDTEFoliDoc").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultDTEUrl", SqlDbType.VarChar).Size = 1000 : cmd.Parameters("@ResultDTEUrl").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultINVDOCNMBR", SqlDbType.VarChar).Size = 17 : cmd.Parameters("@ResultINVDOCNMBR").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If
            guia = cmd.Parameters("@ResultDTEFoliDoc").Value.ToString
            IVDOCNMBR = cmd.Parameters("@ResultINVDOCNMBR").Value.ToString
            GrabarInventario = mret
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function

End Class
