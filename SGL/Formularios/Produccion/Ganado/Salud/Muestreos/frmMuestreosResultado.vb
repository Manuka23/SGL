


Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient



Public Class frmMuestreosResultado

    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_FechaMuestreo As DateTime
    Public Param4_TipoMuestreo As String
    ''
    Private ResultadoDiios As String()
    Private ResultadoValor As Integer()



    Private Function LeerResultadoDesdeExcel(ByVal file_ As String) As Boolean
        LeerResultadoDesdeExcel = False
        If FrmMuestreosIngreso.lvGanado.Items.Count = 0 Then Exit Function

        Cursor.Current = Cursors.WaitCursor

        'lblProcesa.Text = "Exportando a excel, espere un momento por favor ..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = Val(Label85.Text)
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        'Try
        '
        Dim AppExcel As New Application
        Dim Libro As Workbook
        Dim Hoja As Worksheet
        ''
        Dim NomTipoMuestreo As String = ""
        Dim CodTipoMuestreo As Integer = 0
        ''
        Dim diio1_ As String = ""
        Dim diio1OK As Boolean = False
        Dim result1_ As String = ""
        ''
        Dim i, lin As Integer
        Dim cent_ As String = ""
        Dim tbc_, leu_, bru_ As Integer
        Dim ExisteResultado As Boolean = False

        cent_ = General.CentrosUsuario.Codigo(FrmMuestreosIngreso.cboCentros.SelectedIndex)
        tbc_ = IIf(FrmMuestreosIngreso.chkTBC.Checked = True, 1, 0)
        leu_ = IIf(FrmMuestreosIngreso.chkLEU.Checked = True, 1, 0)
        bru_ = IIf(FrmMuestreosIngreso.chkBRU.Checked = True, 1, 0)
        i = 0

        Libro = AppExcel.Workbooks.Open(file_) 'AppExcel.Workbooks.Add
        Hoja = Libro.Worksheets(1)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'LO PRIMERO ES VERIFICAR EL TIPO DE MESTREO
        NomTipoMuestreo = cboTiposMuestras.Text
        'If IsNothing(Hoja.Cells(22, 4).Value) = False Then NomTipoMuestreo = Hoja.Cells(22, 4).Value.ToString.Trim.ToUpper

        Select Case NomTipoMuestreo
            Case ""
                If MsgBox("NO SE RECONOCE EL TIPO DE MUESTREO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Hoja = Nothing      'Descargamos los Objetos...
                Libro.Close()
                AppExcel.Quit()
                Exit Function

            Case "TUBERCULOSIS"
                CodTipoMuestreo = 1

            Case "LEUCOSIS"
                CodTipoMuestreo = 2

            Case "BRUCELOSIS"
                CodTipoMuestreo = 3
        End Select

        If (CodTipoMuestreo = 1 And FrmMuestreosIngreso.chkTBC.Checked = False) Or (CodTipoMuestreo = 2 And FrmMuestreosIngreso.chkLEU.Checked = False) Or _
                (CodTipoMuestreo = 3 And FrmMuestreosIngreso.chkBRU.Checked = False) Then
            If MsgBox("EL TIPO DE MUESTREO DEL ARCHIVO DE RESULTADO NO CONCUERDA CON EL DEL MUESTREO (" + NomTipoMuestreo + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            Hoja = Nothing      'Descargamos los Objetos...
            Libro.Close()
            AppExcel.Quit()
            Exit Function
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'OBTENEMOS LOS DIIOS Y SUS RESULTADOS DE LA PLANILLA DE RESULTADO Y LOS DEJAMOS EN UN ARREGLO
        For lin = 1 To 5000
            If Trim(Hoja.Cells(lin, 1).value) = "" Then
                Exit For
            End If

            diio1_ = ""
            result1_ = "0"
            If IsNothing(Hoja.Cells(lin, 1).Value) = False Then diio1_ = Hoja.Cells(lin, 1).Value.ToString.Trim
            If IsNothing(Hoja.Cells(lin, 2).Value) = False Then result1_ = Hoja.Cells(lin, 2).Value.ToString.Trim
            diio1OK = True

            'si encontramos el final, salimos
            'If diio1_.ToUpper.Contains("FIN") = True Then
            '    Exit For
            'End If

            'si el diio no contiene solamente numeros, salimos
            If diio1_ = "" Then diio1OK = False
            If diio1OK = True And Not IsNumeric(diio1_) Then diio1OK = False

            'si el digito del primer diio es numerico, lo agregamos al arreglo
            If diio1OK = True Then
                ReDim Preserve ResultadoDiios(i)
                ReDim Preserve ResultadoValor(i)

                'tomamos el diio, al cual le grabaremos su resultado
                ResultadoDiios(i) = diio1_
                ResultadoValor(i) = 0

                If result1_.ToUpper.Contains("POS") Then ResultadoValor(i) = 1
                If result1_.ToUpper.Contains("NEG") Then ResultadoValor(i) = 2

                i = i + 1
            End If
        Next
        ''
        Hoja = Nothing      'Descargamos los Objetos...
        Libro.Close()
        AppExcel.Quit()


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestreos_GrabarResultado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing

        Dim HayError As Boolean = False
        Dim ErrorDiio As Integer    '0=no se encuentra el diio en la planilla de resultado, 1=ok, 3=error de proc. alm.
        Dim ResultPA As Integer
        Dim posresult As Integer
        Dim vret As Integer
        Dim mret As String

        con.Open()

        cmd.CommandType = Data.CommandType.StoredProcedure
        SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        For lin = 0 To FrmMuestreosIngreso.lvGanado.Items.Count - 1

            ErrorDiio = 0
            mret = ""
            posresult = 0

            For i = 0 To UBound(ResultadoDiios)

                If ResultadoDiios(i) = FrmMuestreosIngreso.lvGanado.Items(lin).SubItems(3).Text Then

                    'EncuentroDiio = True
                    '*********************************************************************************************************
                    'VAMOS A GRABAR EL RESULTADO DE MUESTREO DEL DIIO
                    ''
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@Empresa", Empresa)
                    cmd.Parameters.AddWithValue("@Centro", Param1_CodigoCentro)
                    cmd.Parameters.AddWithValue("@Fecha", Param3_FechaMuestreo)
                    cmd.Parameters.AddWithValue("@TipoMuestreo", Param4_TipoMuestreo)
                    cmd.Parameters.AddWithValue("@DIIO", ResultadoDiios(i))
                    cmd.Parameters.AddWithValue("@Muestreo", CodTipoMuestreo)
                    cmd.Parameters.AddWithValue("@FechaResultado", dtpFechaResult.Value)
                    cmd.Parameters.AddWithValue("@Resultado", ResultadoValor(i))
                    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
                    cmd.Parameters.AddWithValue("@Equipo", NombrePC)
                    '
                    cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
                    cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

                    Try
                        'con.Open()
                        cmd.Transaction = SRVTRANS
                        ResultPA = cmd.ExecuteNonQuery()
                        '''''''''''
                        vret = cmd.Parameters("@RetValor").Value
                        mret = cmd.Parameters("@RetMensage").Value

                        ''verificamos error con un valor igual a -1
                        If vret <> 0 Then
                            'If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                            'End If
                            HayError = True
                            ErrorDiio = 3
                            Exit For
                        End If

                        'si todo sale ok guardamos el nuevo codigo del grupo de secado
                        ErrorDiio = 1

                        If CodTipoMuestreo = 1 Then posresult = 4
                        If CodTipoMuestreo = 2 Then posresult = 5
                        If CodTipoMuestreo = 3 Then posresult = 6

                        If ResultadoValor(i) = 1 Then
                            FrmMuestreosIngreso.lvGanado.Items(lin).UseItemStyleForSubItems = False
                            FrmMuestreosIngreso.lvGanado.Items(lin).SubItems(posresult).ForeColor = Color.Red
                            FrmMuestreosIngreso.lvGanado.Items(lin).SubItems(posresult).Text = "POSITIVO"
                        ElseIf ResultadoValor(i) = 2 Then
                            FrmMuestreosIngreso.lvGanado.Items(lin).SubItems(posresult).Text = "NEGATIVO"
                        End If

                        'If ResultadoValor(i) = 2 Then lvGanado.Items(lin).SubItems(posresult).Text = "NEGATIVO"

                    Catch ex As Exception
                        'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                    End Try
                    '*********************************************************************************************************

                End If

            Next

            If ErrorDiio = 1 Then
                FrmMuestreosIngreso.lvGanado.Items(lin).SubItems(11).Text = "OK"
            ElseIf ErrorDiio = 0 Then
                FrmMuestreosIngreso.lvGanado.Items(lin).SubItems(11).Text = "No se encuentra resultado"
            Else
                FrmMuestreosIngreso.lvGanado.Items(lin).SubItems(11).Text = mret
            End If
        Next


        ''MsgBox(ct_.ToString)

        If HayError = True Then
            SRVTRANS.Rollback()
            LeerResultadoDesdeExcel = False
        Else
            SRVTRANS.Commit()
            LeerResultadoDesdeExcel = True
        End If

        'rdr.Close()
        'cmd.Dispose()
        con.Close()

        'pbProcesa.Value = pbProcesa.Maximum

        'Catch ex As Exception
        ' MsgBox(ex.Message)
        ' End Try

        'pnlProcesa.Visible = False
        Cursor.Current = Cursors.Default
    End Function


    Private Sub btnResultado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResultado.Click
        If FrmMuestreosIngreso.lvGanado.Items.Count = 0 Then Exit Sub
        If cboTiposMuestras.SelectedIndex = -1 Then Exit Sub

        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()

        If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        If LeerResultadoDesdeExcel(OpenFDlg.FileName.Trim) = True Then
            FrmMuestreosIngreso.BuscarDetalle()
            FrmMuestreos.LlenaMuestreos()
            Me.Close()
        End If
    End Sub


    Private Sub frmMuestreosResultado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFechaResult.Value = Now
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class