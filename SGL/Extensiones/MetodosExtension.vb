Imports System.Runtime.CompilerServices

Public Module MetodosExtension



    '''' <summary>
    '''' Devuelve la suma de los valores de una columna de un objeto DataTable.
    '''' </summary>
    '''' <param name="dt">Objeto DataTable.</param>
    '''' <param name="columnName">El nombre de la columna cuyos valores se desean sumar.</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    '<Extension()> _
    'Public Function SumColumn(ByVal dt As DataTable, _
    '                          ByVal columnName As String) As Decimal

    '    Return dt.SumColumn(columnName, Nothing)

    'End Function

    '''' <summary>
    '''' Devuelve la suma de los valores de una columna de un objeto DataTable.
    '''' </summary>
    '''' <param name="dt">Objeto DataTable.</param>
    '''' <param name="columnName">El nombre de la columna cuyos valores se desean sumar.</param>
    '''' <param name="filter">Filtro que limitará las filas que se sumarán.</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    '<Extension()> _
    'Public Function SumColumn(ByVal dt As DataTable, _
    '                          ByVal columnName As String, _
    '                          ByVal filter As String) As Decimal

    '    If ((dt Is Nothing) OrElse (String.IsNullOrEmpty(columnName))) Then _
    '        Return 0D

    '    Try
    '        Dim expression As String = String.Format("Sum({0})", columnName)

    '        Dim value As Object = Nothing

    '        If (String.IsNullOrEmpty(filter)) Then
    '            ' Sumamos todas las filas.
    '            '
    '            value = dt.Compute(expression, Nothing)

    '        Else
    '            ' Sumamos las filas que coincidan con el criterio especificado.
    '            '
    '            value = dt.Compute(expression, filter)

    '        End If

    '        If (value Is DBNull.Value) Then
    '            Return 0D

    '        Else
    '            Return Convert.ToDecimal(value)

    '        End If

    '    Catch ex As Exception
    '        Return 0D

    '    End Try

    'End Function

    '''' <summary>
    '''' Devuelve la suma de los valores de una columna del control DataGridView.
    '''' </summary>
    '''' <param name="dgv">Control DataGridView.</param>
    '''' <param name="columnName">El nombre de la columna cuyos valores se desean sumar.</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    '<Extension()> _
    'Public Function SumColumn(ByVal dgv As DataGridView, _
    '                          ByVal columnName As String) As Decimal

    '    Return dgv.SumColumn(columnName, Nothing)

    'End Function

    '''' <summary>
    '''' Devuelve la suma de los valores de una columna del control DataGridView.
    '''' </summary>
    '''' <param name="dgv">Control DataGridView.</param>
    '''' <param name="columnName">El nombre de la columna cuyos valores se desean sumar.</param>
    '''' <param name="selectedRows">Colección de filas que se sumarán.</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    '<Extension()> _
    'Public Function SumColumn( _
    '    ByVal dgv As DataGridView, _
    '    ByVal columnName As String, _
    '    ByVal selectedRows As DataGridViewSelectedRowCollection) As Decimal

    '    If ((dgv Is Nothing) OrElse (String.IsNullOrEmpty(columnName))) Then _
    '        Return 0D

    '    Try
    '        ' Si no hay filas seleccionadas, indicamos la intención de
    '        ' sumar todas las filas del control DataGridView.
    '        '
    '        If ((selectedRows IsNot Nothing) AndAlso _
    '            (selectedRows.Count = 0)) Then _
    '            selectedRows = Nothing

    '        Dim query As IEnumerable(Of Object) = Nothing

    '        If (selectedRows Is Nothing) Then
    '            ' Se desea sumar todas las filas.
    '            '
    '            query = From row As DataGridViewRow In dgv.Rows.Cast(Of DataGridViewRow)() _
    '                    Where ( _
    '                            (row.Cells(columnName).Value IsNot Nothing) AndAlso _
    '                            (row.Cells(columnName).Value IsNot DBNull.Value) _
    '                    ) Select row.Cells(columnName).Value

    '        Else
    '            ' Se desea sumar las filas seleccionadas.
    '            '
    '            query = From row As DataGridViewRow In dgv.Rows.Cast(Of DataGridViewRow)() _
    '                    Where ( _
    '                            (row.Selected) AndAlso _
    '                            (row.Cells(columnName).Value IsNot Nothing) AndAlso _
    '                            (row.Cells(columnName).Value IsNot DBNull.Value) _
    '                    ) Select row.Cells(columnName).Value
    '        End If

    '        ' Devolvemos la suma.
    '        '
    '        Return query.Sum(Function(row) Convert.ToDecimal(row))

    '    Catch ex As Exception
    '        Return 0D

    '    End Try

    'End Function

    <Extension()>
    Public Function ToString2(ByVal dgv As DataGridView, ByVal row As Integer, ByVal col As Integer) As String
        ToString2 = ""

        Try
            ToString2 = dgv.Rows(row).Cells(col).Value.ToString
        Catch ex As Exception
        End Try
    End Function


    <Extension()>
    Public Function ToInteger(ByVal dgv As DataGridView, ByVal row As Integer, ByVal col As Integer) As Integer
        ToInteger = 0

        Try
            ToInteger = Convert.ToInt32(dgv.Rows(row).Cells(col).Value.ToString.Replace(".", ""))
        Catch ex As Exception
        End Try
    End Function


    <Extension()>
    Public Function ToDouble(ByVal dgv As DataGridView, ByVal row As Integer, ByVal col As Integer) As Double
        ToDouble = 0

        Try
            ToDouble = Convert.ToDouble(dgv.Rows(row).Cells(col).Value.ToString.Replace(".", ""))
        Catch ex As Exception
        End Try
    End Function


    <Extension()>
    Public Function ToDate(ByVal dgv As DataGridView, ByVal row As Integer, ByVal col As Integer) As Date
        ToDate = Nothing

        Try
            ToDate = CDate(dgv.Rows(row).Cells(col).Value).Date
        Catch ex As Exception
        End Try
    End Function


    <Extension()>
    Public Function ToIntegerFromCheckBox(ByVal dgv As DataGridView, ByVal row As Integer, ByVal col As Integer) As Integer
        ToIntegerFromCheckBox = 0

        Try
            If dgv.Rows(row).Cells(col).Value.GetType() Is GetType(Boolean) Then ToIntegerFromCheckBox = IIf(dgv.Rows(row).Cells(col).Value.Value = False, 0, 1)
            If dgv.Rows(row).Cells(col).Value.GetType() Is GetType(String) Then ToIntegerFromCheckBox = IIf(dgv.Rows(row).Cells(col).Value = "", 0, 1)
        Catch ex As Exception
        End Try
    End Function
End Module