Imports System.Data.SqlClient
Public Class fnValidaCIDR
    Public Function ValidaCIRD(ByVal lvganado As ListView, ByVal Centro As String, ByVal Fecha As DateTime) As Boolean

        ValidaCIRD = False
        Dim DetalleCIDR As DataTable = DataTableCIDR(lvganado)
        If ConsultaDiios(DetalleCIDR, Centro, Fecha) = False Then Exit Function

        ValidaCIRD = True
    End Function
    Private Function ConsultaDiios(ByVal lvganado As DataTable, ByVal Centro As String, ByVal Fecha As DateTime) As Boolean
        ConsultaDiios = False
        Dim falso As Integer = 0
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spIATF_ValidaTabla", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@Fecha", Fecha)
        cmd.Parameters.AddWithValue("@TablaDetalle", lvganado)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        frmIATFIngreso.lvDIIOS.BeginUpdate()
        frmIATFIngreso.lvDIIOS.Items.Clear()

        Dim i As Integer = 0
        Dim err As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("Diio").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)                  'centro
                    item.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                    If rdr("cubierta").ToString.Trim <> "" Then
                        item.SubItems.Add(rdr("cubierta").ToString.Trim)
                        err = err + 1
                        falso = 1
                    Else
                        item.SubItems.Add("")
                    End If

                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")

                    frmIATFIngreso.lvDIIOS.Items.Add(item)

                    i = i + 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        frmIATFIngreso.lvDIIOS.EndUpdate()
        If falso = 1 Then
            ConsultaDiios = False
            frmIATFIngreso.ContabilizaYValidaDIIOs()
        Else
            ConsultaDiios = True

        End If
SalirProc:
    End Function



    Public Function DataTableCIDR(ByVal lvganado As ListView) As DataTable
        DataTableCIDR = Nothing
        Dim table As DataTable = New DataTable("ValidaIATF")

        table.Columns.Add("Diio", System.Type.GetType("System.String"))
        Dim n As Integer
        n = lvganado.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(lvganado.Items(i).SubItems(1).Text)
        Next
        DataTableCIDR = table
    End Function

End Class
