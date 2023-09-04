Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Public Class frmMuestraLecheResultado
    Private fnResultados As New fnMuestraLecheEnvioResultado
    Private CodArchivo As String
    Private ArchivoImportacion As String
    Private NombreArchivo As String
    Private EstanqueMuestra As String
    Private Rcsexcel As Double = 0
    Private Correlativo As Integer = 0
    Private SolidExcel As Double = 0
    Private Grasaexcel As Double = 0
    Private Proteinaexcel As Double = 0
    Private Ureaexcel As Double = 0
    Private Densidadexcel As Double = 0
    Private Crioscopiaexcel As Double = 0
    Private Ufcexcel As Double = 0
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvGanado.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvGanado, e)
    End Sub
    Private Sub frmMuestraLecheResultado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

    End Sub
    Public Function ConsultaLoteEnvio() As Boolean
        ConsultaLoteEnvio = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_ConsultaPndResultado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@LectorCod", CodArchivo)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            lvGanado.BeginUpdate()
            Try
                While rdr.Read()
                    lblEstado.Text = rdr("EstadoEnvio").ToString.Trim()
                    lblFecha.Text = rdr("FechaEnvioReal").ToString.Trim()
                    lblLote.Text = rdr("LoteEnvio").ToString.Trim()
                    lblMuestras.Text = rdr("NroMuestras").ToString.Trim()
                End While
                lvGanado.EndUpdate()
                If vret = 1 Then
                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    ConsultaLoteEnvio = False
                    Exit Function
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        ConsultaLoteEnvio = True
    End Function
    Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click
        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()
        If OpenFDlg.FileName.Trim() <> "" Then
            ArchivoImportacion = OpenFDlg.FileName.Trim
            NombreArchivo = OpenFDlg.SafeFileName.Trim
            CodArchivo = Replace(NombreArchivo, ".xlsx", "")
            CodArchivo = Replace(CodArchivo, ".xls", "")
            CodArchivo = Replace(CodArchivo, "x", "")
            txtArchivo.Text = NombreArchivo
        End If
        If ConsultaLoteEnvio() = True Then
            Datosexcel()
            For i = 0 To lvGanado.Items.Count - 1
                If lvGanado.Items(i).SubItems(11).Text.Trim = "En Excel y no en Pnd Resultado" Then
                    lvGanado.Items(i).BackColor = Color.Red
                End If
            Next
        Else
            Exit Sub
        End If

        If lvGanado.Items.Count > 0 Then
            btnGrabar.Enabled = True
        End If

    End Sub
    Private Sub Datosexcel()
        Dim lin As Integer
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim Procesa As Boolean
            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Libro = AppExcel.Workbooks.Open(ArchivoImportacion)
            Hoja = Libro.Worksheets(1)
            lin = 2
            Procesa = True
            fnResultados.DtExcelCrear()
            Do While Procesa
                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    ConsultaListadoExcel()
                    Exit Do
                End If
                Correlativo = Hoja.Cells(lin, 1).value
                EstanqueMuestra = Hoja.Cells(lin, 5).value
                Rcsexcel = Hoja.Cells(lin, 6).value
                Grasaexcel = Hoja.Cells(lin, 7).value
                Proteinaexcel = Hoja.Cells(lin, 8).value
                Ureaexcel = Hoja.Cells(lin, 9).value
                Densidadexcel = Hoja.Cells(lin, 10).value
                Crioscopiaexcel = Hoja.Cells(lin, 11).value
                Ufcexcel = Hoja.Cells(lin, 12).value
                SolidExcel = Grasaexcel + Proteinaexcel
                fnResultados.DtExcel(Correlativo, EstanqueMuestra, Rcsexcel, Grasaexcel, Proteinaexcel, Ureaexcel, Densidadexcel, Crioscopiaexcel, Ufcexcel, SolidExcel)
                lin = lin + 1
            Loop
            fnResultados.VaciaDatatable()
            Hoja = Nothing      'Descargamos los Objetos...
            Libro.Close()
            AppExcel.Quit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ConsultaListadoExcel()
        Dim Correlativo As Integer = 0
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_ListadoExcel", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@LectorCod", CodArchivo)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@TablaDetalle", fnResultados.DetallesExcel)
        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    If rdr("CorrEnvio") = "0" Then
                        Correlativo = Correlativo + 1
                    Else
                        Correlativo = rdr("CorrEnvio")
                    End If
                    Dim item As New ListViewItem(Correlativo)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("CentroNomCorto").ToString)
                    item.SubItems.Add(rdr("CodBarraMuestra").ToString)
                    item.SubItems.Add(rdr("ResultRCS").ToString)
                    item.SubItems.Add(rdr("ResultGrasa").ToString)
                    item.SubItems.Add(rdr("ResultProteina").ToString)
                    item.SubItems.Add(rdr("ResultSolido").ToString)
                    item.SubItems.Add(rdr("ResultUrea").ToString)
                    item.SubItems.Add(rdr("ResultDensidad").ToString)
                    item.SubItems.Add(rdr("ResultCriscopia").ToString)
                    item.SubItems.Add(rdr("ResultUFC").ToString)
                    item.SubItems.Add(rdr("Observacion").ToString)
                    lvGanado.Items.Add(item)
                End While


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
        lvGanado.EndUpdate()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub GrabarMuestraLeche()
        Dim lote As String = lblLote.Text
        fnResultados.Grabar(lvGanado, lote)

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If lvGanado.Items.Count <> lblMuestras.Text Then
            btnGrabar.Enabled = True
            If MsgBox("NUMERO DE RESULTADOS DIFERENTE AL NUMERO DE MUESTRAS CORRESPONDIENTES AL CODIGO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        For i = 0 To lvGanado.Items.Count - 1
            If lvGanado.Items(i).BackColor = Color.Red Then
                If MsgBox("PARA FINAlIZAR, ELIMINAR ERRORES", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
        Next
        GrabarMuestraLeche()
        frmMuestraLecheResumen.ConsultaMuestraLeche()
        Me.Close()
    End Sub

    'Private Sub btnEliminar_Click(sender As Object, e As EventArgs)
    '    For Each it As ListViewItem In lvGanado.SelectedItems
    '        lvGanado.Items.Remove(it)
    '    Next
    '    If lvGanado.Items.Count > 0 Then
    '        btnGrabar.Enabled = True
    '    Else
    '        btnGrabar.Enabled = False
    '    End If
    'End Sub

    Private Sub lvGanado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvGanado.SelectedIndexChanged

    End Sub
End Class