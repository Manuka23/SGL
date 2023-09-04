Imports System.Data.SqlClient
Public Class fnTrasladosCargaMasiva
    Public DetallesExcel As New DataTable("DetalleTraslados")

    Public Sub DtExcel(ByVal Diio As String)
        DetallesExcel.Rows.Add(Diio)
    End Sub

    Public Sub DtExcelCrear()
        DetallesExcel.Columns.Add("Diio")
    End Sub
    Public Sub VaciaDatatable()
        DetallesExcel.Reset()
    End Sub

    Public Function Consulta(ByVal fecha As Date, ByVal Centro As String) As Boolean
        Consulta = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_ConsultaRecepcionMasiva", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Destino", Centro)
        cmd.Parameters.AddWithValue("@TablaDetalle", DetallesExcel)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            Dim errores As Integer = 0
            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Try
                frmTrasladosRecepcionMasiva.lvDIIOS.Items.Clear()
                frmTrasladosRecepcionMasiva.lvDIIOS.BeginUpdate()
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("Diio").ToString.Trim)
                    item.SubItems.Add(rdr("CentroOrigen").ToString.Trim)
                    item.SubItems.Add(rdr("Codigo"))
                    If rdr("Estado") <> "OK" Then
                        errores = errores + 1
                    End If
                    item.SubItems.Add(rdr("Estado").ToString.Trim)
                    frmTrasladosRecepcionMasiva.lvDIIOS.Items.Add(item)
                End While
                frmTrasladosRecepcionMasiva.lblTotTraslados.Text = i
                frmTrasladosRecepcionMasiva.lblTotErrores.Text = errores
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Consulta = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try

        frmTrasladosRecepcionMasiva.lvDIIOS.EndUpdate()
    End Function


End Class
