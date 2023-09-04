Imports System.Data.SqlClient
Public Class frInducciones
    Public DetallesExcel As New DataTable("DetalleInducciones")
    Public EliminarDetallesExcel As New DataTable("EliminarDetalleInducciones")
    Public Sub DtExcel(ByVal Diio As String)
        DetallesExcel.Rows.Add(Diio)
    End Sub
    Public Sub DtExcelEliminar(ByVal Diio As String, ByVal Vacuna As String, ByVal Fecha As Date)
        EliminarDetallesExcel.Rows.Add(Diio, Vacuna, Fecha)
    End Sub
    Public sub DtExcelCrearElimina()
        EliminarDetallesExcel.Columns.Add("Diio")
        EliminarDetallesExcel.Columns.Add("Centro")
        EliminarDetallesExcel.Columns.Add("Fecha")
    End Sub
    Public Sub DtExcelCrear()
        DetallesExcel.Columns.Add("Diio")
    End Sub
    Public Sub VaciaDatatable()

        DetallesExcel.Reset()
        EliminarDetallesExcel.Reset()
    End Sub


End Class
