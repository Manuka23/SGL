Imports System.Data.SqlClient



Public Class CaseDatatable

    Public Function LVToDataTableConteo1(ByVal Emp As String, ByVal Param1_CentroCod As String, ByVal listview As ListView, ByVal Ultima As String, ByVal LoginUsuario As String, ByVal NombrePC As String) As DataTable
        LVToDataTableConteo1 = Nothing

        Dim table As DataTable = New DataTable("TablaConteoGrabarLecturasDetalles")

        Dim Empresa As String = Emp
        Dim Centro As String = Param1_CentroCod
        Dim ContFechaHora As String = Ultima
        Dim Diio As String = ""
        Dim FechaLectura As DateTime = Now
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
                           ConvertToDateTime(listview.Items(i).SubItems(2).Text),
                           Usuario, Equipo)
        Next
        LVToDataTableConteo1 = table

    End Function
    Public Function ConvertToDateTime(value As String) As Date
        Dim convertedDate As DateTime
        convertedDate = Convert.ToDateTime(value)
        Return convertedDate
    End Function
    Public Function LVToDataTableConteo2(ByVal Emp As String, ByVal Param1_CentroCod As String, ByVal listview As ListView, ByVal Ultima As String, ByVal LoginUsuario As String, ByVal NombrePC As String) As DataTable
        LVToDataTableConteo2 = Nothing

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
        LVToDataTableConteo2 = table

    End Function
    Public Function LVToDataTableConteoDiff(ByVal Emp As String, ByVal Param1_CentroCod As String, ByVal Ultima As String, ByVal listview As ListView, ByVal Reprocesa As String, ByVal LoginUsuario As String, ByVal NombrePC As String) As DataTable
        LVToDataTableConteoDiff = Nothing

        Dim table As DataTable = New DataTable("TablaConteoGrabarLecturasDiferencias")

        Dim Empresa As String = Emp
        Dim Centro As String = Param1_CentroCod
        Dim ContFechaHora As String = Ultima
        Dim Repro As String = Reprocesa
        Dim Usuario As String = LoginUsuario
        Dim Equipo As String = NombrePC
        'Dim prueba As String = listview.Items(1).SubItems(1).Text

        table.Columns.Add("Empresa", System.Type.GetType("System.String"))
        table.Columns.Add("Centro", System.Type.GetType("System.String"))

        table.Columns.Add("ContFechaHora", System.Type.GetType("System.String"))
        table.Columns.Add("Diio", System.Type.GetType("System.String"))
        table.Columns.Add("ObservDiio", System.Type.GetType("System.String"))
        table.Columns.Add("reprocesa", System.Type.GetType("System.String"))
        table.Columns.Add("Usuario", System.Type.GetType("System.String"))
        table.Columns.Add("Equipo", System.Type.GetType("System.String"))
        Dim n As Integer
        n = listview.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(Empresa, Centro, ContFechaHora, listview.Items(i).SubItems(1).Text,
                          listview.Items(i).SubItems(2).Text, Repro,
                           Usuario, Equipo)
        Next
        LVToDataTableConteoDiff = table

    End Function
End Class