Imports System.Data.OleDb
Public Class frmMuestraLecheExcel

    Dim Proveedor As String
    Dim CodProvee As String = "823926006"


    Private Sub frmMuestraLecheExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8

        txtArchivoNombre.Text = ""

    End Sub
    Private Sub dgvcargaexcel_SelectionChanged(sender As Object, e As EventArgs) Handles dgvcargaexcel.SelectionChanged
        If dgvcargaexcel.Rows.Count = 0 Then
            MsgBox("DEBE INGRESAR ALGUN DATO EN LA TABLA ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
    End Sub
    Private Sub rbcalidad_CheckedChanged(sender As Object, e As EventArgs) Handles rbcalidad.CheckedChanged
        If rbcalidad.Checked Then
            Proveedor = "C. CALIDAD"
        End If
    End Sub
    Private Sub rbsala_CheckedChanged(sender As Object, e As EventArgs) Handles rbsala.CheckedChanged
        If rbsala.Checked Then
            Proveedor = "SALA"
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        ImportarExcel(dgvcargaexcel)
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If (dgvcargaexcel.Rows.Count = 0) Then
            MsgBox("Debe cargar el excel", vbExclamation, "Carga Excel")
            Exit Sub
        End If
        If String.IsNullOrEmpty(Proveedor) Then
            MsgBox("Debe seleccionar Proveedor", vbExclamation, "Seleccion")
            Exit Sub
        End If

        Dim fn As fnMuestraLecheCargaExcel = New fnMuestraLecheCargaExcel
        Dim ResultMsg As String = fn.CargarExcel(dgvcargaexcel, CodProvee, Proveedor)
        If ResultMsg = "" Then
            MsgBox("Carga realizada exitosamente")
            Me.Close()
        Else
            MsgBox(ResultMsg)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Sub ImportarExcel(ByVal tabla As DataGridView)
        btnFinalizar.Enabled = False
        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""

        With myFileDialog
            .Filter = "Excel Files |*.xls;.xlsx;.csv"
            .Title = "Open File"
            .ShowDialog()
        End With
        If myFileDialog.FileName.ToString <> "" Then
            Dim ExcelFile As String = myFileDialog.FileName.ToString
            txtArchivoNombre.Text = ExcelFile
            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection

            xSheet = "Hoja1"
            conn = New OleDbConnection(
                       "Provider=Microsoft.ACE.OLEDB.12.0;" &
                       "data source=" & ExcelFile & "; " &
                       "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            Try
                da = New OleDbDataAdapter("SELECT correlativ, folio, codigo, ext, rp, rcs, grasa, protein, urea, densidad, ufc,
                                           crioscop, solidos, centro, (grasa + protein) as solida, fecha FROM  [" & xSheet & "$]", conn)

                conn.Open()
                da.Fill(ds, "DatosExcel")
                dt = ds.Tables("DatosExcel")
                tabla.DataSource = ds
                tabla.DataMember = "DatosExcel"
                btnFinalizar.Enabled = True
            Catch ex As Exception
                MsgBox("La Hoja a ingresar debe tener el nombre por defecto (Hoja1)", MsgBoxStyle.Information, "Informacion")

            Finally
                conn.Close()
            End Try
        End If
    End Sub
End Class