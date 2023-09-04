Imports System.IO.Ports
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Imports System.Management
Imports System.Data.SqlClient
Public Class frmBalanceIngreso
    Private fnbalance As New fnbalance
    Public Procesa As Boolean = False
    Private fnBalanceIngresoDiario As New fnBalanceIngresoDiario
    Public ArchivoImportacion As String
    Public NombreArchivo As String
    Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click

        Dim codig As String = General.CategoriasBalance.Codigo(CboSubcategoria.SelectedIndex)
        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()

        If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        ArchivoImportacion = OpenFDlg.FileName.Trim
        NombreArchivo = OpenFDlg.SafeFileName.Trim
        txtArchivo.Text = NombreArchivo

        Cargandotxt.Visible = True

        Cursor.Current = Cursors.WaitCursor

        MostrarYValidarDatosAImportar()

    End Sub
    Private Sub MostrarYValidarDatosAImportar()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim AppExcel As New Application
            Dim Libro As Workbook = AppExcel.Workbooks.Open(ArchivoImportacion)
            Dim Hoja As Worksheet = Libro.Worksheets(1)
            ''
            Dim UltimaLinea As Long = Hoja.Range("A65536").End(XlDirection.xlUp).Row
            If UltimaLinea = 0 Then Exit Sub

            Dim Procesa As Boolean
            Dim items As New List(Of ListViewItem)

            Dim lin As Integer
            Dim DIIOFechaXls As String = ""

            Procesa = True
            lin = 1
            fnbalance.DtExcelCrear()
            Dim vriable As Integer = 2
            Do While Procesa
                If Trim(Hoja.Cells(lin, vriable - 1).value) = "" Then
                    vriable = vriable + 1
                    lin = 1
                    If Trim(Hoja.Cells(lin, vriable - 1).value) = "" Then
                        Exit Do
                    End If
                End If


                fnbalance.DtExcel(Hoja.Cells(lin + 1, 1).text, Hoja.Cells(lin + 1, vriable).value, Hoja.Cells(1, vriable).value)
                lin = lin + 1

            Loop
            Hoja = Nothing      'Descargamos los Objetos...
            ' fnbalance.VaciaDatatable()
            Libro.Close()
            AppExcel.Quit()
            '   EnviaEmail()
            Cargandotxt.Visible = False

        Catch ex As Exception
            If MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR") = MsgBoxResult.Ok Then
            End If
        End Try

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub frmBalanceIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.CentrosUsuarioSalas.Cargar()
        General.CategoriasBalance.Cargar()
        CboLLenaCategorias()
        CboSubcategoria.SelectedIndex = 0
    End Sub

    Private Sub CboLLenaCategorias()
        If General.CategoriasBalance.NroRegistros = 0 Then Exit Sub
        CboSubcategoria.Items.Clear()
        Dim i As Integer

        For i = 0 To General.CategoriasBalance.NroRegistros - 1
            CboSubcategoria.Items.Add(General.CategoriasBalance.Nombre(i))
        Next
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        GrabarIngresoDiario()
    End Sub
    Public Function GrabarIngresoDiario() As Boolean
        GrabarIngresoDiario = False
        fnBalanceIngresoDiario.Balance(fnbalance.DetallesExcel, General.CategoriasBalance.Codigo(CboSubcategoria.SelectedIndex))
        Me.Close()
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class