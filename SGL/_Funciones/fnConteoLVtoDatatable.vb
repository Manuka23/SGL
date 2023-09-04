Imports System.Data.SqlClient



Public Class fnConteoLVtoDatatable

    Public Function LVToDataTableConteo(ByVal Emp As String, ByVal Param1_CentroCod As String, ByVal listview As ListView, ByVal Ultima As String, ByVal LoginUsuario As String, ByVal NombrePC As String) As DataTable
        LVToDataTableConteo = Nothing

        Dim table As DataTable = New DataTable("TablaConteoGrabarLecturas")

        Dim Empresa As String = Emp
        Dim Centro As String = Param1_CentroCod
        Dim ContFechaHora As String = Ultima
        Dim Diio As String = ""
        Dim FechaLectura As String = ""
        Dim Usuario As String = LoginUsuario
        Dim Equipo As String = NombrePC

        table.Columns.Add("Empresa", System.Type.GetType("System.String"))
        table.Columns.Add("Centro", System.Type.GetType("System.String"))

        table.Columns.Add("ContFechaHora", System.Type.GetType("System.String"))
        table.Columns.Add("Diio", System.Type.GetType("System.String"))
        table.Columns.Add("FechaLectura", System.Type.GetType("System.String"))        'GetType(Integer)
        table.Columns.Add("Usuario", System.Type.GetType("System.String"))
        table.Columns.Add("Equipo", System.Type.GetType("System.String"))
        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(Empresa, Centro, ContFechaHora, listview.Items(i).SubItems(1).Text,
                            Convert.ToDateTime(listview.Items(i).SubItems(2).Text),
                           Usuario, Equipo)
        Next
        LVToDataTableConteo = table

    End Function
    Public Function LVToDataTableConteoDiff(ByVal listview As ListView) As DataTable
        LVToDataTableConteoDiff = Nothing

        Dim table As DataTable = New DataTable("TablaConteoGrabar")



        table.Columns.Add("Diio", System.Type.GetType("System.String"))
        table.Columns.Add("FechaLectura", System.Type.GetType("System.String"))

        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1

            table.Rows.Add(listview.Items(i).SubItems(1).Text,
                         listview.Items(i).SubItems(2).Text)
        Next
        LVToDataTableConteoDiff = table

    End Function
End Class