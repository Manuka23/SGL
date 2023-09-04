Imports System.Runtime.CompilerServices
Module ModuloCelos_LV_Ext
    <Extension()>
    Public Sub Celos_ResumenxCentro(ByVal ListView As ListView, ByVal Data As DataTable)
        If Data Is Nothing Then Exit Sub
        If Data.Columns.Count = 0 Then Exit Sub
        If Data.Rows.Count = 0 Then Exit Sub

        ListView.BeginUpdate()
        For i As Integer = 0 To Data.Rows.Count - 1


            Dim item As New ListViewItem((i + 1).ToString.Trim)
            item.SubItems.Add(Data.Rows(i).Item("EmpRut").ToString.Trim)
            item.SubItems.Add(Data.Rows(i).Item("CenCod").ToString.Trim)
            item.SubItems.Add(Data.Rows(i).Item("CenDesCor").ToString.Trim)
            item.SubItems.Add(Data.Rows(i).Item("ContVacas").ToString.Trim)
            item.SubItems.Add(Data.Rows(i).Item("ContIngresos").ToString.Trim)
            item.SubItems.Add(Data.Rows(i).Item("ContCelos").ToString.Trim)
            item.SubItems.Add(Format(Data.Rows(i).Item("pje_celos"), "#,##0.00") + " %")
            item.SubItems.Add(Data.Rows(i).Item("ContSinCelos").ToString.Trim)
            item.SubItems.Add(Format(Data.Rows(i).Item("pje_sincelos"), "#,##0.00") + " %")
            item.SubItems.Add(Data.Rows(i).Item("ContDiasLac").ToString.Trim)
            item.SubItems.Add(Format(Data.Rows(i).Item("pje_diaslac"), "#,##0.00") + " %")

            ListView.Items.Add(item)
        Next

        ListView.EndUpdate()
    End Sub
End Module
