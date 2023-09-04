﻿Public Class ListViewOrdenarColumnas
    ''' ORDEN DE COLUMNAS EN DIFERENTES LIST VIEW DE ESTE FORMULARIO
    Private m_SortingColumn As ColumnHeader
    Public Sub OrdenarColumnas(ByVal ListView As ListView, ByVal e As System.Windows.Forms.ColumnClickEventArgs)
        Cursor.Current = Cursors.WaitCursor

        Dim new_sorting_column As ColumnHeader = ListView.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        ListView.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView.Sort()

        Cursor.Current = Cursors.Default
    End Sub

End Class
