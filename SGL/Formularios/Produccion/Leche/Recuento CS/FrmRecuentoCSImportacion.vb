
Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient


Public Class FrmRecuentoCSImportacion

    Public ArchivoImportacion As String


    Public Total_General As Integer
    Public Total_Preniadas As Integer
    Public Total_Secas As Integer
    Public Total_Errores As Integer

    Private Sub MuestraTotales()
        Label85.Text = Total_General.ToString.Trim
        Label48.Text = Total_Preniadas.ToString.Trim()
        Label34.Text = Total_Secas.ToString.Trim()
        Label1.Text = Total_Errores.ToString.Trim()

        pnlEstReprod.Refresh()
    End Sub


    Private Sub InicializaTotales()
        Total_General = 0
        Total_Preniadas = 0
        Total_Secas = 0
        Total_Errores = 0
    End Sub


    Public Function ConsultaPalpaciones(ByVal emp_ As String, ByVal cent_ As String, ByVal fec_ As String, ByVal vet_ As String,
                                   ByVal diio_ As String, ByVal cond_ As String, ByVal res_ As String, ByVal cat_ As String,
                                   ByRef RetMensaje As String, ByRef RetCodEmpresa As Integer, ByRef RetCodCentro As String,
                                   ByRef RetCodVeterinario As Integer, ByRef RetCodCondicion As Integer) As Boolean
        ConsultaPalpaciones = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPalpaciones_Validar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", fec_)
        cmd.Parameters.AddWithValue("@Veterinario", vet_)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        cmd.Parameters.AddWithValue("@Condicion", cond_)
        cmd.Parameters.AddWithValue("@Resultado", res_)
        cmd.Parameters.AddWithValue("@Categoria", cat_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    RetMensaje = rdr("RetMensaje").ToString.Trim
                    RetCodEmpresa = rdr("Empresa").ToString.Trim
                    RetCodCentro = rdr("Centro").ToString.Trim
                    RetCodVeterinario = rdr("Veterinario").ToString.Trim
                    RetCodCondicion = rdr("Condicion").ToString.Trim

                    If rdr("RetValor") = 0 Then ConsultaPalpaciones = True
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Function



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click

        Me.Close()

    End Sub

    Private Sub btnArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivo.Click
        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()

        If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        ArchivoImportacion = OpenFDlg.FileName.Trim()
        txtArchivo.Text = ArchivoImportacion
        btnProcesar.Enabled = False

        MostrarYValidarDatosAImportar()

        If Total_Errores = 0 Then btnProcesar.Enabled = True
    End Sub
    Private Sub MostrarYValidarDatosAImportar()
        'If lvGanado.Items.Count = 0 Then Exit Sub
        cboMesAñoExcel.SelectedIndex = 0
        Cursor.Current = Cursors.WaitCursor

        lblProcesa.Text = "Validando Información, espere un momento por favor ..."
        pbProcesa.Value = 0
        'pbProcesa.Maximum = Val(Label8.Text)
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        lvRCS_Excel.BeginUpdate()
        lvRCS_Excel.Items.Clear()

        Try
            Dim lin As Integer
            Dim Procesa As Boolean

            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Dim ResultadoValidacion As Boolean
            Dim NroLineas As Integer
            Dim CodEmpresa, CodVeterinario, CodCondicion As Integer
            Dim CodCentro, RetMensaje As String

            Libro = AppExcel.Workbooks.Open(ArchivoImportacion)
            Hoja = Libro.Worksheets(cboMesAñoExcel.SelectedText)
            lin = 2
            Procesa = False
            RetMensaje = ""
            CodCentro = ""

            NroLineas = Hoja.Range("a1").CurrentRegion.Rows.Count

            If NroLineas > 1 Then
                Total_General = NroLineas - 1
                Procesa = True
                pbProcesa.Maximum = Total_General
                Label85.Text = Total_General.ToString.Trim
            End If

            Do While Procesa

                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    Exit Do
                End If

                ResultadoValidacion = ConsultaPalpaciones(Hoja.Cells(lin, 2).value, Hoja.Cells(lin, 3).value, Hoja.Cells(lin, 4).value,
                                             Hoja.Cells(lin, 5).value, Hoja.Cells(lin, 6).value, Hoja.Cells(lin, 7).value,
                                             Hoja.Cells(lin, 8).value, Hoja.Cells(lin, 9).value, RetMensaje, CodEmpresa,
                                             CodCentro, CodVeterinario, CodCondicion)

                Dim item As New ListViewItem("")    'primera columna, para ordenar datos

                item.SubItems.Add((lin - 1).ToString.Trim)      'nro filas
                item.SubItems.Add(CodEmpresa)                   'codigo empresa
                item.SubItems.Add(Hoja.Cells(lin, 2).value)     'nombre empresa
                item.SubItems.Add(CodCentro)                    'codigo centro
                item.SubItems.Add(Hoja.Cells(lin, 3).value)     'nombre centro
                item.SubItems.Add(Hoja.Cells(lin, 4).value)     'fecha palpacion
                item.SubItems.Add(CodVeterinario)               'codigo veterinario
                item.SubItems.Add(Hoja.Cells(lin, 5).value)     'nombre veterinario
                item.SubItems.Add(Hoja.Cells(lin, 6).value)     'diio
                item.SubItems.Add(CodCondicion)                 'codigo condicion
                item.SubItems.Add(Hoja.Cells(lin, 7).value)     'nombre condicion
                item.SubItems.Add(Hoja.Cells(lin, 8).value)     'resultado
                item.SubItems.Add(Hoja.Cells(lin, 9).value)     'categoria
                item.SubItems.Add(RetMensaje)                   '
                item.SubItems.Add("")                           'resultado al grabar la linea

                lvRCS_Excel.Items.Add(item)

                If ResultadoValidacion = True Then
                    If CodCondicion = 1 Then Total_Preniadas = Total_Preniadas + 1
                    If CodCondicion = 2 Then Total_Secas = Total_Secas + 1
                Else
                    Total_Errores = Total_Errores + 1
                End If

                lin = lin + 1
                pbProcesa.Value = lin - 2
            Loop

            pbProcesa.Value = pbProcesa.Maximum

            Libro.Close()
            AppExcel.Quit()

            Hoja = Nothing      'Descargamos los Objetos...
            Libro = Nothing
            AppExcel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        lvRCS_Excel.EndUpdate()
        MuestraTotales()
        pnlProcesa.Visible = False

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub FrmRecuentoCSImportacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class