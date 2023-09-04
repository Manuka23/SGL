Imports System.Data.SqlClient
Public Class fnVacunados
    Public DetallesExcel As New DataTable("DetalleVaunados")
    Public EliminarDetallesExcel As New DataTable("EliminarDetalleVaunados")
    Public EliminarDetallesExcelGP As New DataTable("EliminarDetalleVaunadosGP")
    Public Sub DtExcel(ByVal Diio As String)
        DetallesExcel.Rows.Add(Diio)
    End Sub
    'Public Function DtExcelEliminar(ByVal Diio As String, ByVal Vacuna As String, ByVal Fecha As DateTime)
    '    EliminarDetallesExcel.Rows.Add(Diio, Vacuna, Fecha)
    'End Function
    Public Sub DtExcelEliminarGP(ByVal Cod As String, ByVal Nombre As String, ByVal Cant As Double, ByVal CuentasContables As String, ByVal ItemActivation As String, ByVal Patente As String, ByVal Obs As String)
        EliminarDetallesExcelGP.Rows.Add(Cod, Nombre, Cant, CuentasContables, ItemActivation, Patente, Obs)
    End Sub
    Public Sub DtExcelCrearElimina()
        EliminarDetallesExcel.Columns.Add("Diio")
        EliminarDetallesExcel.Columns.Add("Vacuna")
        EliminarDetallesExcel.Columns.Add("Fecha")
    End Sub
    Public Sub DtExcelCrearEliminaGP()
        EliminarDetallesExcelGP.Columns.Add("CodProducto")
        EliminarDetallesExcelGP.Columns.Add("NomProducto")
        EliminarDetallesExcelGP.Columns.Add("Cantidad")
        EliminarDetallesExcelGP.Columns.Add("Cuenta")
        EliminarDetallesExcelGP.Columns.Add("ItemGasto")
        EliminarDetallesExcelGP.Columns.Add("Patente")
        EliminarDetallesExcelGP.Columns.Add("Observs")

    End Sub
    Public Sub DtExcelCrear()

        DetallesExcel.Columns.Add("Diio")

    End Sub
    Public Sub VaciaDatatable()

        DetallesExcel.Reset()
        EliminarDetallesExcel.Reset()
    End Sub
    Public Sub VaciaDatatableGP()
        EliminarDetallesExcelGP.Reset()
    End Sub
    Public Function Grabar(ByVal listview As ListView, ByVal fecha As DateTime, ByVal Vacuna As String) As Boolean
        Grabar = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_ConsultaVacunados", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos


        Dim DetalleItems As DataTable = ToDataTableGrabar(listview)
        cmd.Parameters.AddWithValue("@VacGndFecha", DateTime.Parse(fecha))
        cmd.Parameters.AddWithValue("@VacCodigo", Vacuna)
        cmd.Parameters.AddWithValue("@TablaVacunacion", DetalleItems)
        cmd.Parameters.AddWithValue("@VacGndEquipo", NombrePC)
        cmd.Parameters.AddWithValue("@VacGndUsuario", LoginUsuario)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Try
                frmVacunasIngresoVacunacion.lvGanado.Items.Clear()
                frmVacunasIngresoVacunacion.lvGanado.BeginUpdate()
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("centro").trim.ToString.Trim)
                    item.SubItems.Add(rdr("diio").trim.ToString.Trim)
                    item.SubItems.Add(rdr("categoria").trim.ToString.Trim)
                    item.SubItems.Add(rdr("estproductivo").trim.ToString.Trim)
                    item.SubItems.Add(rdr("estreproductivo").trim.ToString.Trim)
                    item.SubItems.Add(rdr("estado").trim.ToString.Trim)
                    item.SubItems.Add(rdr("observacion").trim.ToString.Trim)
                    item.SubItems.Add(frmVacunasIngresoVacunacion.Fecha.Text)
                    item.SubItems.Add(rdr("codcentro").trim.ToString.Trim)
                    item.SubItems.Add(rdr("codcategoria").trim.ToString.Trim)
                    frmVacunasIngresoVacunacion.lvGanado.Items.Add(item)
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Grabar = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
        frmVacunasIngresoVacunacion.lvGanado.EndUpdate()
    End Function

    Public Function ToDataTableGrabar(ByVal listview As ListView) As DataTable
        ToDataTableGrabar = Nothing
        Dim table As DataTable = New DataTable("TablaVacunacion")
        table.Columns.Add("centro", System.Type.GetType("System.String"))
        table.Columns.Add("diio", System.Type.GetType("System.String"))
        table.Columns.Add("categoria", System.Type.GetType("System.String"))
        table.Columns.Add("estproductivo", System.Type.GetType("System.String"))
        table.Columns.Add("estreproductivo", System.Type.GetType("System.String"))
        table.Columns.Add("estado", System.Type.GetType("System.String"))
        table.Columns.Add("observacion", System.Type.GetType("System.String"))
        table.Columns.Add("codcentro", System.Type.GetType("System.String"))
        table.Columns.Add("codcategoria", System.Type.GetType("System.String"))
        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(listview.Items(i).SubItems(1).Text, listview.Items(i).SubItems(2).Text, listview.Items(i).SubItems(3).Text,
                           listview.Items(i).SubItems(4).Text, listview.Items(i).SubItems(5).Text, listview.Items(i).SubItems(6).Text,
                            listview.Items(i).SubItems(7).Text, listview.Items(i).SubItems(9).Text, listview.Items(i).SubItems(10).Text)
        Next
        ToDataTableGrabar = table

    End Function

End Class
