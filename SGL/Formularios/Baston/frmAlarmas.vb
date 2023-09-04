
Imports System.IO.Ports
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop.Excel
Imports System.Management
Imports System.Threading
Imports System.Data.SqlClient
Public Class frmAlarmas
    Private fnConteoGallagher As New fnConteoGallagher
    Public QuitarOrigenExcel As Boolean = False     'para los cierres mensuales
    Public Procesa As Boolean = False
    Public ArchivoImportacion As String
    Public NombreArchivo As String

    Public Sub frmAlarmas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8
        cboTipoBaston.SelectedIndex = 0
        CboLlenaPuertos()
    End Sub

    Private Sub CboLlenaPuertos()
        cboPuertos.Items.Clear()
        Dim portname As String

        For Each portname In SerialPort.GetPortNames()
            cboPuertos.Items.Add(portname)
        Next

        cboPuertos.SelectedIndex = -1
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click
        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()

        If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        ArchivoImportacion = OpenFDlg.FileName.Trim
        NombreArchivo = OpenFDlg.SafeFileName.Trim
        txtArchivo.Text = NombreArchivo
        btnProcesar.Enabled = False
        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex
        Dim estado As String = "Planilla Excel"
        Cursor.Current = Cursors.WaitCursor
        MostrarYValidarDatosAImportar()
    End Sub
    Private Sub MostrarYValidarDatosAImportar()
        Cursor.Current = Cursors.WaitCursor

        lvALARMAS.Items.Clear()
        lblTotDiios.Text = "0"

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
            pbProcesa.Maximum = UltimaLinea + 1
            pnlProcesa.Visible = True
            pnlProcesa.Refresh()
            lblProcesaMax.Text = UltimaLinea
            Do While Procesa
                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    Exit Do
                End If


                Dim item As New ListViewItem(lin)
                item.SubItems.Add(Hoja.Cells(lin, 1).value.ToString)
                item.SubItems.Add(Hoja.Cells(lin, 2).value)
                items.Add(item)
                lin = lin + 1
                pbProcesa.Value = lin
                lblProcesaVal.Text = lin
            Loop

            pbProcesa.Value = pbProcesa.Maximum

            Hoja = Nothing      'Descargamos los Objetos...

            Libro.Close()
            AppExcel.Quit()
            '   EnviaEmail()

            lvALARMAS.BeginUpdate()
            lvALARMAS.Items.Clear()
            lvALARMAS.Items.AddRange(items.ToArray())
            lvALARMAS.EndUpdate()

            lblTotDiios.Text = (lin - 1).ToString().Trim
            pnlProcesa.Visible = False


        Catch ex As Exception
            If MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR") = MsgBoxResult.Ok Then
            End If
        End Try

        If lblTotDiios.Text <> "0" Then
            'BuscaDiiosRepetidos("AllFlex_Excel")
            btnProcesar.Enabled = True
        End If

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex
        Dim puerto As String = cboPuertos.Text
        Dim STR As String = puerto
        Dim Delimitador_A As String = "("
        Dim Delimitador_B As String = ")"

        STR = Split(STR, Delimitador_A, , CompareMethod.Text)(1) '  Aquí tomo todo lo que hay a la derecha del primer delimitador
        STR = Split(STR, Delimitador_B, , CompareMethod.Text)(0) '

        Dim com As String = STR

        If tbast_ = 0 Then
            fnConteoGallagher.ConexionGallagherSesionesAlarma(com)
            fnConteoGallagher.SubirAlarmas(lvALARMAS)
            fnConteoGallagher.CerrarCom()
        End If
        If tbast_ = 1 Then
            fnConteoGallagher.ConexionAgridentSesiones(com)
            fnConteoGallagher.SubirAlarmas(lvALARMAS)
            fnConteoGallagher.CerrarCom()
        End If

        Me.Close()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cboPuertos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPuertos.SelectedIndexChanged

    End Sub

    Private Sub cboTipoBaston_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoBaston.SelectedIndexChanged

        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex
        cboPuertos.Enabled = True

        If tbast_ = 1 Then

            'BASTON Agrident
            COMPort.Close()

            llenaPuertosAgrident()
            Dim puerto As String = cboPuertos.Text
            Dim STR As String = puerto
            If puerto = "" Then
                Exit Sub
            End If
            Dim Delimitador_A As String = "("
            Dim Delimitador_B As String = ")"

            STR = Split(STR, Delimitador_A, , CompareMethod.Text)(1) '  Aquí tomo todo lo que hay a la derecha del primer delimitador
            STR = Split(STR, Delimitador_B, , CompareMethod.Text)(0) '

            Dim com As String = STR
            fnConteoGallagher.ConexionAgridentSesiones(com)
            lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
            cboPuertos.Enabled = False
            fnConteoGallagher.CerrarCom()
        End If
        If tbast_ = 0 Then
            'If cboPuertos.SelectedIndex = -1 Then
            '    cboPuertos.SelectedIndex = 0
            'End If
            'BASTON gallagher (NUEVO)
            COMPort.Close()

            llenaPuertosGallagher()
            Dim puerto As String = cboPuertos.Text
            Dim STR As String = puerto
            If puerto = "" Then
                Exit Sub
            End If
            Dim Delimitador_A As String = "("
            Dim Delimitador_B As String = ")"

            STR = Split(STR, Delimitador_A, , CompareMethod.Text)(1) '  Aquí tomo todo lo que hay a la derecha del primer delimitador
            STR = Split(STR, Delimitador_B, , CompareMethod.Text)(0) '

            Dim com As String = STR
            fnConteoGallagher.ConexionGallagherSesiones(com)
            lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
            cboPuertos.Enabled = False
            fnConteoGallagher.CerrarCom()
        End If
    End Sub
    Private Sub llenaPuertosAgrident()
        cboPuertos.Items.Clear()
        Dim searcher2 = New ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'")

        searcher2.Options.Rewindable = False
        searcher2.Options.ReturnImmediately = True
        Dim n As Integer = 0
        For Each mo2 In searcher2.Get()
            Dim Name As String = mo2("Name").ToString()
            cboPuertos.Items.Add(Name)

            If Name.Contains("Agrident") = True Then
                cboPuertos.SelectedIndex = n
                Exit Sub
            End If
            n = n + 1
        Next
    End Sub
    Private Sub llenaPuertosGallagher()
        cboPuertos.Items.Clear()
        Dim searcher2 = New ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'")

        searcher2.Options.Rewindable = False
        searcher2.Options.ReturnImmediately = True
        Dim n As Integer = 0
        For Each mo2 In searcher2.Get()
            Dim Name As String = mo2("Name").ToString()
            cboPuertos.Items.Add(Name)

            If Name.Contains("Gallagher") = True Then
                cboPuertos.SelectedIndex = n
                Exit Sub
            End If
            n = n + 1
        Next
    End Sub
End Class