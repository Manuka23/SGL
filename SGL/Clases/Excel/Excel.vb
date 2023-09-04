


Imports Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
'Imports System.Web


Public Class Excel
    Private file_ As String
    Private hoja_ As String



    Public Property Archivo As String
        Get
            Archivo = file_
        End Get
        Set(ByVal value As String)
            file_ = value
        End Set
    End Property


    Public Property Hoja As String
        Get
            Hoja = hoja_
        End Get
        Set(ByVal value As String)
            hoja_ = value
        End Set
    End Property



    Public Property ArchivoAImportar As String
        Get
            ArchivoAImportar = file_
        End Get
        Set(ByVal value As String)
            file_ = value
        End Set
    End Property


    Public Function ImportarADataTable() As System.Data.DataTable
        'OledbConnection and connectionstring to connect to the Excel Sheet
        ImportarADataTable = Nothing

        Try
            Dim oconn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file_ + ";Extended Properties=Excel 8.0")


            Dim MyCommand = New OleDbDataAdapter("select * from [compras$]", oconn)
            Dim ds = New System.Data.DataSet
            MyCommand.Fill(ds)
            'End Using


            'Dim ocmd As OleDbCommand = New OleDbCommand("select * from [Sheet1]", oconn)
            'Dim odr As OleDbDataReader = ocmd.ExecuteReader()

            'Dim da As New OleDbDataAdapter(ocmd)
            'Dim ds As New DataSet
            'da.Fill(ds)

            If ds.Tables.Count > 0 Then
                '_nroregs = ds.Tables(0).Rows.Count
                Return ds.Tables(0)
            Else
                '_nroregs = 0
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Function


    Public Sub ExportaGrilla(ByVal ListViewAExportar As ListView)
        Dim dt As System.Data.DataTable = ExportarGrillaADataTable(ListViewAExportar)


        'Do While dt.Read
        '    'make an array the length of the available fields
        '    Dim values(myReader.FieldCount - 1) As Object
        '    'get all the field values
        '    myReader.GetValues(values)

        '    'write the text version of each value to a comma seperated string
        '    Dim line As String = String.Join(",", values)
        '    'write the csv line to the file
        '    outputStream.WriteLine(line)
        'Loop





        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine("")
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try
    End Sub



    Private Function ExportarGrillaADataTable(ByVal ListViewAExportar As ListView) As System.Data.DataTable
        'LS_VIEW.Items.Clear()
        Dim DT_TAB As New System.Data.DataTable



        If ListViewAExportar.Items.Count < 1 Then
            Return DT_TAB
        Else
            For i As Integer = 0 To ListViewAExportar.Items(0).SubItems.Count - 1
                Dim DCOL As New DataColumn(ListViewAExportar.Columns(i).Text)
                DT_TAB.Columns.Add(DCOL)
            Next
        End If

        For i As Integer = 0 To ListViewAExportar.Items.Count - 1
            Dim DROW As DataRow = DT_TAB.NewRow
            For j As Integer = 0 To ListViewAExportar.Items(i).SubItems.Count - 1
                DROW(ListViewAExportar.Columns(j).Text) = ListViewAExportar.Items(i).SubItems(j).Text
            Next
            DT_TAB.Rows.Add(DROW)
        Next

        Return DT_TAB
    End Function



    Public Function ImportarPlanilla_A_DataTable() As System.Data.DataTable
        'OledbConnection and connectionstring to connect to the Excel Sheet
        ImportarPlanilla_A_DataTable = Nothing

        Try
            Dim oconn As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.Ace.OLEDB.12.0;Data Source=" + file_ + ";Persist Security Info=False;Extended Properties=Excel 12.0")

            Dim MyCommand = New OleDbDataAdapter("select * from [" + hoja_ + "$]", oconn)
            Dim ds = New System.Data.DataSet
            MyCommand.Fill(ds)

            If ds.Tables.Count > 0 Then
                Return ds.Tables(0)
            Else
                '_nroregs = 0
                Return Nothing
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Function

End Class
