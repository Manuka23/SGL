


Imports System.IO
Imports System.IO.Ports
Imports Microsoft.Office.Interop.Excel

'Imports System.Management


Public Class frmBaston


    Public Procesa As Boolean = False
    Public ArchivoImportacion As String
    Public NombreArchivo As String

    'Dim InfBASTON As New Baston
    Private LeyendoBaston As Boolean = False
    Private TotalDiios As Integer
    Private GuardaTotDiios As Integer
    ''
    Private Delegate Sub UpdateFormDelegate(ByVal Buffer As String)



    Private Sub CboLlenaPuertos()
        Dim portname As String

        For Each portname In SerialPort.GetPortNames()
            'MsgBox(portname)
            cboPuertos.Items.Add(portname)

        Next

        cboPuertos.SelectedIndex = -1
    End Sub



    Private Sub COMPort_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles COMPort.DataReceived
        Try

            Me.BeginInvoke(New UpdateFormDelegate(AddressOf UpdateDisplay), COMPort.ReadLine)

        Catch ex As Exception

            ''en caso de error no hacemos nada

        End Try
    End Sub


    Private Sub UpdateDisplay(ByVal Buffer As String)
        Dim data_ As String = ""

        If Len(Buffer) >= 16 And Mid(Buffer, 1, 1) = "#" Then
            data_ = Mid(Buffer, 2, 16)
            data_ = Mid(data_, 9)
            TotalDiios = TotalDiios + 1

            Dim item As New ListViewItem(TotalDiios.ToString.Trim)    'primera columna, para ordenar los datos
            item.SubItems.Add(data_)
            lvALLFLEX.Items.Add(item)
            lblTotDiios.Text = (Val(lblTotDiios.Text) + 1).ToString.Trim
        End If
    End Sub


    Private Sub tmrLEE_Tick(sender As System.Object, e As System.EventArgs) Handles tmrLEE.Tick
        If GuardaTotDiios = lvALLFLEX.Items.Count Then
            lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
            pnlMSG.BackColor = Color.ForestGreen

            tmrLEE.Enabled = False
            btnBastonLee.Enabled = True
            cboPuertos.Enabled = True
            If lvALLFLEX.Items.Count > 0 Then btnProcesar.Enabled = True

            LeyendoBaston = False

            If COMPort.IsOpen Then COMPort.Close()

            'Cursor.Current = Cursors.Default
        End If

        GuardaTotDiios = lvALLFLEX.Items.Count
    End Sub


    Private Sub MostrarYValidarDatosAImportar()
        'If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        'lblProcesa.Text = "Validando palpaciones, espere un momento por favor ..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = Val(Label8.Text)
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        lvALLFLEX.BeginUpdate()
        lvALLFLEX.Items.Clear()

        Dim lin As Integer
        lblTotDiios.Text = "0"

        Try

            Dim Procesa As Boolean
            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            'Dim ResultadoValidacion As Boolean
            'Dim NroLineas As Integer
            'Dim CodEmpresa, CodVeterinario, CodCondicion As Integer
            'Dim CodCentro, RetMensaje As String

            Libro = AppExcel.Workbooks.Open(ArchivoImportacion)
            Hoja = Libro.Worksheets(1)
            lin = 1
            Procesa = True
            'RetMensaje = ""
            'CodCentro = ""

            'NroLineas = Hoja.Range("a1").CurrentRegion.Rows.Count

            'If NroLineas > 1 Then
            '    Total_General = NroLineas - 1
            '    Procesa = True
            '    pbProcesa.Maximum = Total_General
            '    Label85.Text = Total_General.ToString.Trim
            'End If

            Do While Procesa

                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    Exit Do
                End If

                'ResultadoValidacion = ConsultaPalpaciones(Hoja.Cells(lin, 2).value, Hoja.Cells(lin, 3).value, Hoja.Cells(lin, 4).value,
                '                             Hoja.Cells(lin, 5).value, Hoja.Cells(lin, 6).value, Hoja.Cells(lin, 7).value,
                '                             Hoja.Cells(lin, 8).value, Hoja.Cells(lin, 9).value, RetMensaje, CodEmpresa,
                '                             CodCentro, CodVeterinario, CodCondicion)

                Dim item As New ListViewItem(lin)    'primera columna, para ordenar datos
                item.SubItems.Add(Hoja.Cells(lin, 1).value)
                lvALLFLEX.Items.Add(item)

                'If ResultadoValidacion = True Then
                '    If CodCondicion = 1 Then Total_Preniadas = Total_Preniadas + 1
                '    If CodCondicion = 2 Then Total_Secas = Total_Secas + 1
                'Else
                '    Total_Errores = Total_Errores + 1
                'End If

                lin = lin + 1
                'pbProcesa.Value = lin - 2
            Loop

            'pbProcesa.Value = pbProcesa.Maximum
            Hoja = Nothing      'Descargamos los Objetos...

            Libro.Close()
            AppExcel.Quit()


            'Libro = Nothing
            'AppExcel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        lvALLFLEX.EndUpdate()
        lblTotDiios.Text = (lin - 1).ToString().Trim
        'MuestraTotales()
        'pnlProcesa.Visible = False

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub cboPuertos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPuertos.SelectedIndexChanged
        If cboPuertos.SelectedIndex = -1 Then Exit Sub

        COMPort.PortName = cboPuertos.Text.Trim
        btnProcesar.Enabled = False
        lvALLFLEX.Items.Clear()

        lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
        pnlMSG.BackColor = Color.ForestGreen

        btnBastonLee.Enabled = True
    End Sub


    Private Sub btnBastonLee_Click(sender As System.Object, e As System.EventArgs) Handles btnBastonLee.Click
        Try
            'Cursor.Current = Cursors.WaitCursor

            cboPuertos.Enabled = False
            btnBastonLee.Enabled = False
            btnProcesar.Enabled = False

            lvALLFLEX.Items.Clear()
            lblTotDiios.Text = "0"

            TotalDiios = 0
            GuardaTotDiios = 0
            LeyendoBaston = True

            lblMSG.Text = "LEYENDO BASTON"
            pnlMSG.BackColor = Color.DarkOrange

            COMBaston = cboPuertos.Text 'guardamos puerta com

            If COMPort.IsOpen Then COMPort.Close()

            COMPort.Open()

            COMPort.Write("#P")
            COMPort.Write("#G")

            tmrLEE.Enabled = True
            'Cursor.Current = Cursors.WaitCursor

        Catch ex As Exception
            If MsgBox("ERROR EN LA LECTURA DEL BASTON:" + vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR") = MsgBoxResult.Ok Then
            End If
        End Try
    End Sub


    Private Sub btnProcesar_Click(sender As System.Object, e As System.EventArgs) Handles btnProcesar.Click
        'FormLlama.ProcesaBaston()
        Procesa = True
        Cerrar()
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        If LeyendoBaston = True Then
            If COMPort.IsOpen Then COMPort.Close()
            LeyendoBaston = False
        End If

        Cerrar()
    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmBaston_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.Panel1.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height + 50) / 2)

        Me.Left = Me.Left + (frmMAIN.pnlMenu.Width / 2)

        cboTipoBaston.SelectedIndex = 0

        CboLlenaPuertos()

        If COMBaston <> "" Then
            cboPuertos.Text = COMBaston
        End If

    End Sub

    Private Sub lvDIIOS_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lvALLFLEX.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("¿DESEA --NO PROCESAR-- LOS DIIOS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
                For Each it As ListViewItem In lvALLFLEX.SelectedItems
                    lvALLFLEX.Items.Remove(it)
                Next

                lblTotDiios.Text = lvALLFLEX.Items.Count.ToString.Trim
            End If
        End If
    End Sub


    Private Sub cboTipoBaston_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoBaston.SelectedIndexChanged
        If cboTipoBaston.SelectedIndex = 2 Then
            lblMSG.Text = "SELECCIONE ARCHIVO EXCEL"
            pnlMSG.BackColor = Color.ForestGreen
            Label2.Text = "ARCHIVO"
            cboPuertos.Visible = False
            txtArchivo.Visible = True
            btnArchivo.Visible = True
            txtArchivo.Text = ""
            ArchivoImportacion = ""
            NombreArchivo = ""
        Else
            lblMSG.Text = "SELECCIONE EL PUERTO PARA LECTURA"
            pnlMSG.BackColor = Color.SteelBlue
            Label2.Text = "PUERTO"
            cboPuertos.Visible = True
            txtArchivo.Visible = False
            btnArchivo.Visible = False
        End If
    End Sub


    Private Sub btnArchivo_Click(sender As System.Object, e As System.EventArgs) Handles btnArchivo.Click
        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()

        If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        ArchivoImportacion = OpenFDlg.FileName.Trim
        NombreArchivo = OpenFDlg.SafeFileName.Trim
        txtArchivo.Text = NombreArchivo
        btnProcesar.Enabled = False
        lblMSG.Text = "LEYENDO DATOS"
        pnlMSG.BackColor = Color.DarkOrange

        MostrarYValidarDatosAImportar()

        lblMSG.Text = "SELECCIONE ARCHIVO EXCEL"
        pnlMSG.BackColor = Color.ForestGreen

        If lvALLFLEX.Items.Count > 0 Then btnProcesar.Enabled = True

        'If Total_Errores = 0 Then btnProcesar.Enabled = True
    End Sub
End Class