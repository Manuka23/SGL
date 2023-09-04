Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports CustomExtensions

Public Class frmTratamientosEnCurso

    Dim Todos As String
    Private Sub frmTratamientosEnCurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Centro As Integer = cboCentros.SelectedValue

        TratamientosEnCurso(Centro)
    End Sub

    Public Sub TratamientosEnCurso(ByVal Centro As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_EstadoTratamientos", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Pendientes", Todos)

        lvTratEnCurso.BeginUpdate()
        lvTratEnCurso.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("TratCentro").ToString.Trim)
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(rdr("TratCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("TratDiio").ToString.Trim)
                    item.SubItems.Add(rdr("CodPatologia").ToString.Trim)
                    item.SubItems.Add(rdr("NomPatologia").ToString.Trim)
                    item.SubItems.Add(rdr("MedCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("MedNombre").ToString.Trim)
                    item.SubItems.Add(rdr("TratDetEstado").ToString.Trim)
                    item.SubItems.Add(Format(rdr("TratDetFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("TratDetHorario").ToString.Trim)
                    lvTratEnCurso.Items.Add(item)

                    i = i + 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If lvTratEnCurso.Items.Count = 0 Then
                MsgBox("No se encontraron datos", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        lvTratEnCurso.EndUpdate()
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        'cboCentros.Items.Add("(Seleccionar)")
        Dim CodigoCentro As List(Of Centros) = New List(Of Centros)
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            'cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
            CodigoCentro.Add(New Centros With {
                             .Codigo1 = General.CentrosUsuario.Codigo(i),
                             .Nombre1 = General.CentrosUsuario.Nombre(i)})
        Next
        cboCentros.DataSource = CodigoCentro
        cboCentros.ValueMember = "Codigo1"
        cboCentros.DisplayMember = "Nombre1"
    End Sub

    Private Sub cbxTodos_CheckedChanged(sender As Object, e As EventArgs) Handles cbxTodos.CheckedChanged
        If cbxTodos.Checked Then
            Todos = "SI"
        Else
            Todos = ""
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvTratEnCurso.Items.Count = 0 Then Exit Sub

        ExportToExcelGrilla(lvTratEnCurso)
    End Sub

    Public Sub ExportToExcelGrilla(ByVal grilla As ListView)
        Dim lin, col As Integer
        Dim columns As String = ""
        'Dim linedat As String = ""
        Dim linedat As New StringBuilder

        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'volcamos titulos del listview
        For col = 1 To grilla.Columns.Count - 1
            'If grilla.Columns(col).Width > 0 Then
            columns = columns + grilla.Columns(col).Text + vbTab
            'End If
        Next
        '..........................................................................

        linedat.Append(columns + vbCrLf) '+ linedat + vbCrLf

        '..........................................................................
        'volcamos detalle del listview
        For lin = 0 To grilla.Items.Count - 1
            For col = 1 To grilla.Columns.Count - 1
                linedat.Append(grilla.Items(lin).SubItems(col).Text.ToString.Trim.Replace(vbCrLf, " ") + vbTab)
            Next

            linedat.Append(vbCrLf) '= linedat + vbCrLf
        Next
        '..........................................................................
        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
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

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim DTTratamientosEnCurso As DataTable = TratamientosCurso(lvTratEnCurso)
        TratamientoEnCursoFinalizar(DTTratamientosEnCurso)
    End Sub
    Public Function TratamientosCurso(ByVal lvTratamientosEnCurso As ListView) As DataTable
        TratamientosCurso = Nothing

        Dim table As DataTable = New DataTable("TratamientosEnCurso")

        table.Columns.Add("CentroCod", System.Type.GetType("System.Int32"))
        table.Columns.Add("CodigoDiio", System.Type.GetType("System.Int32"))
        table.Columns.Add("Diio", System.Type.GetType("System.Int32"))
        table.Columns.Add("CodPatologia", System.Type.GetType("System.Int32"))
        table.Columns.Add("CodMedicamento", System.Type.GetType("System.Int32"))
        table.Columns.Add("FechaTratamiento", System.Type.GetType("System.String"))
        table.Columns.Add("Horario", System.Type.GetType("System.String"))


        Dim n As Integer
        n = lvTratEnCurso.Items.Count

        For i = 0 To n - 1
            If lvTratEnCurso.Items(i).Selected Then
                table.Rows.Add(lvTratEnCurso.Items(i).SubItems(1).Text,
                           lvTratEnCurso.Items(i).SubItems(3).Text,
                           lvTratEnCurso.Items(i).SubItems(4).Text,
                           lvTratEnCurso.Items(i).SubItems(5).Text,
                           lvTratEnCurso.Items(i).SubItems(7).Text,
                           lvTratEnCurso.Items(i).SubItems(10).Text,
                           lvTratEnCurso.Items(i).SubItems(11).Text)
            End If
        Next
        TratamientosCurso = table
    End Function
    Private Sub TratamientoEnCursoFinalizar(ByVal DTTratamientosEnCurso As DataTable)
        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientosEnCurso_Actualizar", con)
        Dim Centro As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@TratamientosEnCurso_Actualizar", DTTratamientosEnCurso)


        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        MsgBox("REGISTRO EXITOSO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "VALIDACION")
        TratamientosEnCurso(Centro)
    End Sub
End Class