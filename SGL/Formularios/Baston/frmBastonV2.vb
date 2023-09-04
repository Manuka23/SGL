Imports System.IO.Ports
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Imports System.Management
Imports System.Data.SqlClient

Public Class frmBastonV2
    Public conexion As String
    Private fnConteoGallagher As New fnConteoGallagher
    Public MyReader As NDAgroComm.IEIDReaders
    Private Lectura As String = "Electronico"
    Private contBarra As Integer
    Private numcondicion2 As Integer = 0
    Private numcondicion1 As Integer = 0
    Private cont As Integer = 0
    Private ConteoFL As String
    Public TBaston As String 'para capturar el tipo de baston y asi usarlo en el form comparaciones
    Public estado As String = ""
    Public NumeroSesiones As String
    Public contadorFechas As Integer = 0
    Public contador As Integer = 0
    Public contadorSesion As Integer = 0
    Public contIndexSesion As Integer = 0
    Public NumeroDiios As String
    Public FechaSesionxrs2 As String
    Public ContDIIOsXRS2 As Integer
    Public lvBASTON As ListView
    Public SerialBaston As String

    Public Param1_CentroCod As String = ""
    Public Param2_CentroNom As String = ""
    Public Param3_Formulario As String = ""

    Private AuditId As Integer = 0
    Dim fnDatosAuditoria As New fnAuditoriaLectorDatos
    Dim fnAuditoria As New fnAuditoriaLector

    Public ValidaTipoCentro As Integer = 0          '0=centro normal / 1=area seca / 2=ternereras
    Public ValidaParaCierre As Boolean = False      'indica si la llamada a esta pantalla es para el cieere, con esto podremos validar la fecha de las sesiones

    Public QuitarOrigenExcel As Boolean = False     'para los cierres mensuales

    Public Procesa As Boolean = False
    Public ArchivoImportacion As String
    Public NombreArchivo As String

    Private LeyendoBaston As Boolean = False
    Private TotalDiios As Integer
    Private GuardaTotDiios As Integer
    Dim ContDIIOsRepAllflex As Integer
    ''
    Private CadenaXRS As New StringBuilder
    Private SesionesXRS As New StringBuilder
    Private SaveIndXRS As Integer = 0
    Private IndXRS As Integer = 0

    Private NroTotalDiiosXRS As Integer = 0     'total de diios en el baston
    Private NroDiiosXRS As Integer = 0          'total de diios por sesion en el baston
    Private OperacionXRS As String              'indica la operación que está procesando el bastón: "NRO", "SESIONES", "DIIOS"
    Private ComandoXRS As String                'indica el comando que está procesando el bastón: "DN", "DS", "DL"
    Private PasoUltimoDatoXRS As Boolean
    Private NombreSesion As String
    Private IndexDeSesion As String

    ''
    Dim DIIOTempXRS As String                   'guarda un DIIO para ser usado en operaciones temporales (busca diio repetido)
    Dim ItemsXRS As New List(Of ListViewItem)   'contendra el listado de diios de las sesiones seleccionadas
    Dim ContDIIOsXRS As Integer                 'contador de diios para las sesiones seleccionados 
    Dim ContDIIOsRepXRS As Integer              'contador de diios repetidos para las sesiones seleccionadas
    ''
    Private ArregloDiiosXRS() As String
    Private ArregloFechasXRS() As String
    Private ArregloSesionesXRS() As String
    Public ArraySesionesXRS2() As String
    Public ArraySesionesFL(500) As String
    ''
    Private OrigenBaston As Integer     '0=allflex / 1=xrs / 2=planilla_excel
    Private ValidaAllflex As Boolean = False
    ''
    Private m_SortingColumn As ColumnHeader
    ''
    Private Delegate Sub UpdateFormDelegate(ByVal Buffer As String)


    'cantidad de diios a devolver en un comando DL
    Dim num As Integer

    Private Sub CboLlenaPuertos()
        cboPuertos.Items.Clear()
        Dim portname As String

        For Each portname In SerialPort.GetPortNames()
            cboPuertos.Items.Add(portname)
        Next

        cboPuertos.SelectedIndex = -1
    End Sub

    Private Sub AbrePuertoBaston()
        Try
            If COMPort.IsOpen = False Then COMPort.Open()
            COMPort.ReceivedBytesThreshold = 1

        Catch ex As Exception
            MsgBox(ex.Message.Trim)
        End Try
    End Sub


    Private Sub CierraPuertoBaston()
        Try
            If COMPort.IsOpen = True Then COMPort.Close()
        Catch ex As Exception
            MsgBox(ex.Message.Trim)
        End Try
    End Sub


    Private Sub EnviaComandoXRS(ByVal cmd_ As String)
        Try
            'Debug.Print(cmd_)
            COMPort.Write("{" + cmd_ + "}")

        Catch ex As Exception
            LeyendoBaston = False
        End Try
    End Sub


    Private Sub InicilizaBarraEstado(ByVal NroMax As Integer)
        lvXRS_SESIONES.Enabled = False
        pbProcesa.Value = 0
        pbProcesa.Maximum = NroMax
        lblProcesaMax.Text = NroMax.ToString
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()
    End Sub

    Public Sub FinalizaBarraEstado()
        lvXRS_SESIONES.Enabled = True
        lblProcesaFin.Text = pbProcesa.Maximum.ToString
        pnlProcesa.Visible = False
        pnlProcesa.Refresh()

        'If OperacionXRS <> "SESIONES" Then
        '    ' EnviaEmail()
        '    Digitados()
        'End If
    End Sub
    Private Sub Digitados(ByVal Centro As String)
        ''SP ENVIA EMAIL''
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAuditoriaLector_EnviaMailDigitados", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR ENVIA EMAIL")
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub EnviaEmail(ByVal Centro As String)
        ''SP ENVIA EMAIL''
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAuditoriaLector_EnviaEmail", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Centro", Centro)

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR ENVIA EMAIL")
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub FinalizaBarraEstadoSesiones()
        lvXRS_SESIONES.Enabled = True
        lblProcesaFin.Text = pbProcesa.Maximum.ToString
        pnlProcesa.Visible = False
        pnlProcesa.Refresh()
    End Sub

    Public Sub ActualizaBarraEstado(ByVal val_ As Integer)
        pbProcesa.Value = val_
        lblProcesaVal.Text = val_.ToString
    End Sub


    Private Function EsFinalRespuestaXRS(ByVal dato_ As String) As Boolean
        EsFinalRespuestaXRS = False
        If dato_.Contains("]") Then EsFinalRespuestaXRS = True
    End Function


    Private Function EsFinalLecturaXRS(ByVal dato_ As String) As Boolean
        EsFinalLecturaXRS = False
        If dato_.Contains("[]") Then EsFinalLecturaXRS = True
    End Function


    Private Function ObtieneNroDiiosXRS(ByVal dato_ As String) As Integer
        ObtieneNroDiiosXRS = Convert.ToInt32(Mid(dato_, 2, dato_.Length - 2))
    End Function


    Private Function ObtieneNroDiiosSesionXRS(ByVal dato_ As String) As Integer
        ObtieneNroDiiosSesionXRS = 0 'Convert.ToInt32(Mid(dato_, 2, dato_.Length - 2))

        Dim idx_ini As Integer = 0
        Dim idx_fin As Integer = 0

        idx_ini = InStrRev(dato_, "[", , CompareMethod.Text)

        If idx_ini > 0 Then
            idx_fin = InStr(idx_ini, dato_, ",", CompareMethod.Text)

            If idx_fin > 0 Then
                ObtieneNroDiiosSesionXRS = Convert.ToInt32(Mid(dato_, idx_ini + 1, (idx_fin - idx_ini) - 1))
            End If
        End If
    End Function


    Private Sub LeeTotalDiiosXRS()
        NroTotalDiiosXRS = ObtieneNroDiiosXRS(CadenaXRS.ToString) 'Convert.ToInt32(Mid(CadenaXRS.ToString, 2, CadenaXRS.Length - 2))
        If NroTotalDiiosXRS = 0 Then Exit Sub 'si no hay diios salimos

        OperacionXRS = "SESIONES"
        ComandoXRS = "DS"
        CadenaXRS.Clear()

        InicilizaBarraEstado(NroTotalDiiosXRS)
        EnviaComandoXRS("DS" + IndXRS.ToString.Trim)
    End Sub


    Private Sub LeeSesionesXRS()
        If ComandoXRS = "DS" Then
            NroDiiosXRS = ObtieneNroDiiosSesionXRS(CadenaXRS.ToString)
            EnviaComandoXRS("DL" + IndXRS.ToString.Trim)
            ComandoXRS = "DL"
        Else
            IndXRS = NroDiiosXRS + 1 'IndXRS + NroDiiosXRS + 1
            EnviaComandoXRS("DS" + IndXRS.ToString.Trim)
            ComandoXRS = "DS"
            ActualizaBarraEstado(IndXRS)
        End If
    End Sub


    Private Sub COMPort_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles COMPort.DataReceived
        Try
            If OrigenBaston = 0 Then 'ALLFLEX
                Me.BeginInvoke(New UpdateFormDelegate(AddressOf UpdateDisplay), COMPort.ReadLine)
            End If
            If OrigenBaston = 1 Then 'XRS
                Me.BeginInvoke(New UpdateFormDelegate(AddressOf UpdateDisplay), COMPort.ReadExisting)
            End If
            If OrigenBaston = 2 Then 'XRS2
                Me.BeginInvoke(New UpdateFormDelegate(AddressOf UpdateDisplay), COMPort.ReadExisting)
            End If
        Catch ex As Exception
            ''en caso de error no hacemos nada
            MsgBox(ex.Message)
        End Try
    End Sub

    Dim FechaAllflex As String = Today.ToString("dd-MM-yyyy")
    Private Sub UpdateDisplay(ByVal Buffer As String)
        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex
        Dim data_ As String = ""
        Dim RepAllflex As String = ""

        Cursor.Current = Cursors.WaitCursor

        If tbast_ = 0 Then      'BASTON ALLFLEX (ANTIGUO)
            'AGREGAMOS LOS DIIOS AL LISTVIEW
            If Len(Buffer) >= 16 And Mid(Buffer, 1, 4) = "#152" Then    'Buffer.Contains("Allflex")  
                data_ = Mid(Buffer, 2, 16)
                data_ = Convert.ToDecimal(Mid(data_, 4).Trim)           'se quitan los primeros 4 digitos y se convierte a numerico. Se esta ocupando todos los digitos, para futuros Diios con mas de 8 dig.
                TotalDiios = TotalDiios + 1
                RepAllflex = ""
                If VerificaDatoEnListView(data_, lvALLFLEX_XLS) = True Then
                    ContDIIOsRepAllflex += 1
                    RepAllflex = "SI"
                    lblRepetidos.Text = ((Val(lblRepetidos.Text) + 1).ToString.Trim)
                End If

                Dim item As New ListViewItem(TotalDiios.ToString.Trim)    'primera columna, para ordenar los datos
                item.SubItems.Add(data_)
                item.SubItems.Add(FechaAllflex)
                item.SubItems.Add("Sesion Allflex")
                item.SubItems.Add(RepAllflex)
                If RepAllflex = "SI" Then
                    item.BackColor = Color.Red
                End If
                lvALLFLEX_XLS.Items.Add(item)

                lblTotDiios.Text = (Val(lblTotDiios.Text) + 1).ToString.Trim
            End If
        End If
        If tbast_ = 1 Then  'BASTON XRS

            'AQUI LO PRIMERO ES RESCATAR LA CANTIDAD DE DIIOS QUE EXISTEN EN EL BASTON (COMANDO: {DN})
            '...UNA VEZ TOMADO EL NRO DE DIIOS, SI ESTE ES MAYOR A 0 NOS VAMOS AL PROC QUE RESCATA LAS SESIONES
            If Buffer.Length >= 1 Then

                'acumulamos datos entrantes
                CadenaXRS.Append(Buffer)
                'verificamos el final de una respuesta desde el baston
                If EsFinalRespuestaXRS(Buffer) Then
                    If ComandoXRS = "Seriales" Then
                        SerialBaston = CadenaXRS.ToString.Trim
                        SerialBaston = Replace(SerialBaston, "[", "")
                        SerialBaston = Replace(SerialBaston, "]", "")
                        CadenaXRS.Clear()
                        ComandoXRS = ""
                        'COMPort.Close()
                    End If
                    'verificamos la operacion que se realiza sobre el baston
                    Select Case OperacionXRS

                        Case "NRO"
                            LeeTotalDiiosXRS()

                        Case "SESIONES"
                            'si es el final de la lectura, entonces...
                            If EsFinalLecturaXRS(CadenaXRS.ToString) Then
                                If Not PasoUltimoDatoXRS Then
                                    LeeSesionesXRS()
                                    PasoUltimoDatoXRS = True
                                    Exit Sub
                                End If

                                FinalizaLecturaXRS()
                                Exit Sub
                            End If

                            LeeSesionesXRS()

                        Case "DIIOS"
                            num = 5
                            If (((IndXRS - SaveIndXRS) + num) > NroDiiosXRS) Then num = NroDiiosXRS - (IndXRS - SaveIndXRS)

                            If ((IndXRS - SaveIndXRS) + num) >= NroDiiosXRS Then
                                If Not PasoUltimoDatoXRS Then
                                    EnviaComandoXRS(String.Concat("DL", IndXRS, ",", num))
                                    PasoUltimoDatoXRS = True
                                    Exit Sub
                                End If

                                FinalizaLecturaXRS()
                                Exit Sub
                            End If

                            EnviaComandoXRS(String.Concat("DL", IndXRS, ",", num))
                            IndXRS += num

                            ActualizaBarraEstado(IndXRS - SaveIndXRS)
                    End Select

                End If
            End If
        End If
        If tbast_ = 2 Then

            If Buffer.Length >= 1 Then

                'acumulamos datos entrantes
                CadenaXRS.Append(Buffer)
                'verificamos el final de una respuesta desde el baston
                If EsFinalRespuestaXRS(Buffer) Then
                    If ComandoXRS = "Seriales" Then
                        SerialBaston = CadenaXRS.ToString.Trim
                        SerialBaston = Replace(SerialBaston, "[", "")
                        SerialBaston = Replace(SerialBaston, "]", "")
                        CadenaXRS.Clear()
                        ComandoXRS = "fl"
                    End If

                    If ComandoXRS = "fl" Then 'ArraySesionesFL
                        EnviaComandoXRS("FL")
                        ConteoFL = CadenaXRS.ToString.Trim
                        CadenaXRS.Clear()
                        If ConteoFL = "[]" Then
                            numcondicion1 = 1
                            numcondicion2 = numcondicion2 + 1
                        End If
                        If ConteoFL <> "" Then
                            If numcondicion1 = 1 Then
                                If numcondicion2 = 1 Then
                                    If ConteoFL <> "[]" Then
                                        ArraySesionesFL(cont) = ConteoFL
                                        cont = cont + 1
                                    End If

                                Else
                                    'COMPort.Close()
                                    ComandoXRS = ""
                                End If
                            End If
                        End If
                    End If

                    If ComandoXRS = "sesiones" Then                              'Para ver el numero de Sesiones en el baston
                        NumeroSesiones = CadenaXRS.ToString.Trim
                        NumeroSesiones = Replace(NumeroSesiones, "[", "")
                        NumeroSesiones = Replace(NumeroSesiones, "]", "")
                        NumeroSesiones = Convert.ToInt32(NumeroSesiones)
                        Dim LargoArray As Integer = NumeroSesiones + 1
                        ComandoXRS = "FechasDeSesiones"
                        CadenaXRS.Clear()
                        contBarra = NumeroSesiones
                        InicilizaBarraEstado(NumeroSesiones)
                        ReDim ArraySesionesXRS2(LargoArray)
                    End If
                    If ComandoXRS = "FechasDeSesiones" Then                         'Para ver las fechas de las sesiones
                        FechaSesionxrs2 = CadenaXRS.ToString.Trim
                        Dim contfl As String
                        contfl = ArraySesionesFL(contadorFechas) ''''
                        contfl = Replace(contfl, "[", "")
                        contfl = Replace(contfl, "]", "")
                        contfl = Convert.ToInt32(contfl)
                        EnviaComandoXRS("FPDA" + contfl.ToString.Trim)
                        FechaSesionxrs2 = Replace(FechaSesionxrs2, "[", "")
                        FechaSesionxrs2 = Replace(FechaSesionxrs2, "]", "")
                        ArraySesionesXRS2(contadorFechas) = FechaSesionxrs2
                        contadorFechas = contadorFechas + 1
                        CadenaXRS.Clear()
                        If contadorFechas > NumeroSesiones Then                        'si es verdadero es por q ya lleno el arreglo
                            ComandoXRS = "CantidadDiiosSession"
                            CadenaXRS.Clear()
                        End If

                    End If

                    If ComandoXRS = "CantidadDiiosSession" Then                      'Para saber la cantidad de diios en cada sesion
                        If CadenaXRS.ToString.Trim.Contains("/") = False Then
                            Dim contfl As String
                            contfl = ArraySesionesFL(contador)
                            contfl = Replace(contfl, "[", "")
                            contfl = Replace(contfl, "]", "")
                            contfl = Convert.ToInt32(contfl)

                            Dim dias_val As Integer = DiasHabiles(Param1_CentroCod, "CIERRE")
                            'Dim dias_val As Integer = 4
                            'If ValidaTipoCentro > 0 Then dias_val = 35 ' reversar a 30 dias

                            EnviaComandoXRS("FPNR" + contfl.ToString.Trim)
                            NumeroDiios = CadenaXRS.ToString.Trim
                            NumeroDiios = Replace(NumeroDiios, "(F9)", "")
                            NumeroDiios = Replace(NumeroDiios, "[", "")
                            NumeroDiios = Replace(NumeroDiios, "]", "")
                            contador = contador + 1
                            CadenaXRS.Clear()
                            ' contadorSesion = NumeroSesiones + 1
                            contIndexSesion = contador - 1

                            If NumeroDiios <> "" Then                                      'Rellena la grilla de sesiones 
                                Dim lvitem As New ListViewItem("")
                                lvitem.Checked = False
                                lvitem.SubItems.Add("Sesion" + contIndexSesion.ToString.Trim)     '
                                lvitem.SubItems.Add(ArraySesionesXRS2(contIndexSesion))                           'fecha sesion
                                lvitem.SubItems.Add(NumeroDiios)                  'nro diios sesion
                                lvitem.SubItems.Add("0")                                        'en cache? 0=NO / 1=SI
                                lvitem.SubItems.Add(contIndexSesion - 1)                'posicion para rescatar los diios
                                lvXRS_SESIONES.Items.Add(lvitem)

                                ActualizaBarraEstado(contBarra - 1)
                                contBarra = contBarra - 1
                                If contBarra = 0 Then
                                    FinalizaLecturaXRS2()
                                End If

                                'If ValidaParaCierre Then
                                '    Dim fec_ As DateTime = DateTime.Parse(ArraySesionesXRS2(contIndexSesion))
                                '    Dim dias As Integer = DateDiff(DateInterval.Day, fec_, Now)

                                '    If dias > dias_val Then
                                '        lvitem.UseItemStyleForSubItems = False

                                '        For x As Integer = 0 To lvXRS_SESIONES.Columns.Count - 1
                                '            lvitem.SubItems(x).BackColor = Color.LightGray
                                '        Next
                                '    End If
                                'End If
                                If NumeroSesiones = contIndexSesion Then
                                    ComandoXRS = ""
                                End If
                            End If
                        Else
                            CadenaXRS.Clear()
                        End If

                    End If

                    If ComandoXRS = "ListaDiios" Then                        'Rellena la grilla de Detalle Diios 
                        Dim itm As ListViewItem
                        Dim str_rep As String
                        Dim DIIOSXR2 As String
                        DIIOSXR2 = CadenaXRS.ToString.Trim              'resive en formato de 152 0000xxx, 11-11-2017
                        If DIIOSXR2 <> "[]" Then
                            EnviaComandoXRS("FN")

                            CadenaXRS.Clear()
                            DIIOSXR2 = Replace(DIIOSXR2, "^", "")

                            If DIIOSXR2 <> "[F1AEID]" And DIIOSXR2 <> "[F0AVID]" And DIIOSXR2 <> "[RDDDate]" And DIIOSXR2 <> "[RTATime]" Then

                                ContDIIOsXRS2 = ContDIIOsXRS2 + 1

                                Dim diioSplit As String
                                Dim diio As Integer
                                Dim fechadio As String
                                Dim fechaHora As String

                                Lectura = "Electronico"
                                DIIOSXR2 = Replace(DIIOSXR2, "[", "")
                                DIIOSXR2 = Replace(DIIOSXR2, "]", "")
                                DIIOSXR2 = Replace(DIIOSXR2, "152 ", "")

                                '[152 00001234567, 7766554,30-033-2023,1211]

                                'ArrCadena(1) = "1234567" - EID
                                'ArrCadena(2) = "7766554" - VID
                                'ArrCadena(3) = ""30 - 33 - 2023
                                'ArrCadena(4) = 12 : 11

                                Dim ArrCadena As String() = DIIOSXR2.Split(",")
                                diioSplit = ArrCadena(1)

                                If diioSplit = "" Then
                                    diioSplit = ArrCadena(2)
                                    Lectura = "Digitado"
                                End If

                                diioSplit = Strings.Right(diioSplit, 9)
                                diio = Convert.ToInt32(diioSplit)
                                fechadio = ArrCadena(3)
                                Dim fecha As String() = fechadio.Split("/")
                                fechadio = fecha(2) + "-" + fecha(1) + "-" + fecha(0)
                                fechaHora = fechadio + " " + ArrCadena(4)
                                '--------------------



                                '-------------------------------------------------------------------------------------
                                DIIOTempXRS = diio
                                '-------------------------------------------------------------------------------------
                                Dim di As Integer = 0
                                Try
                                    di = Convert.ToInt32(DIIOTempXRS)
                                Catch ex As Exception
                                End Try
                                '-------------------------------------------------------------------------------------
                                DIIOTempXRS = di.ToString.Trim
                                '-------------------------------------------------------------------------------------
                                itm = ItemsXRS.Find(AddressOf BuscaItemXRS)       'busca DIIO en la lista de items
                                str_rep = ""

                                If itm IsNot Nothing Then
                                    ContDIIOsRepXRS += 1
                                    str_rep = "SI"
                                End If
                                '-------------------------------------------------------------------------------------
                                Dim item2 As New ListViewItem(ContDIIOsXRS2)
                                item2.SubItems.Add(diio)
                                item2.SubItems.Add(fechadio)
                                item2.SubItems.Add(NombreSesion)
                                item2.SubItems.Add(str_rep)
                                item2.SubItems.Add(Lectura)
                                item2.SubItems.Add(fechaHora)
                                ItemsXRS.Add(item2)
                                '-------------------------------------------------------------------------------------
                                lvXRS_DETALLE.BeginUpdate()
                                lvXRS_DETALLE.Items.Clear()
                                lvXRS_DETALLE.Items.AddRange(ItemsXRS.ToArray())
                                lvXRS_DETALLE.EndUpdate()

                                ActualizaBarraEstado(contBarra - 1)
                                contBarra = contBarra - 1
                                If contBarra = 0 Then
                                    FinalizaLecturaXRS2()
                                    'fnAuditoria.InsertDetalle(AuditId, Param1_CentroCod, lvALLFLEX_XLS, "Baston XRS2", SerialBaston, NombreSesion)
                                End If
                                'fnDatosAuditoria.DIIO = diio
                                'fnDatosAuditoria.Serial = SerialBaston
                                'fnDatosAuditoria.FechaLectura = fechaHora

                                lblRepetidos.Text = ContDIIOsRepXRS.ToString.Trim
                                lblTotDiios.Text = ContDIIOsXRS2
                                If ContDIIOsRepXRS > 0 Then PintarRepetidos(lvXRS_DETALLE, 4)

                                If lblTotDiios.Text <> "0" Then
                                    btnProcesar.Enabled = True
                                    If lblRepetidos.Text <> "0" Then btnEliminaRepetidos.Enabled = True
                                End If

                            End If
                        End If
                    End If

                End If
            End If

        End If

    End Sub

    Private Function VerificaDatoEnListView(ByVal Cod_ As String, ByVal lv As ListView) As Boolean
        'VerificaDatoEnListView = False
        Dim _existe As Boolean = False
        Dim ValorCelda As String = ""
        For lin = 0 To lv.Items.Count - 1 And _existe = False
            ValorCelda = lv.Items(lin).SubItems(1).Text.ToString.Trim
            If ValorCelda.Trim = Cod_.Trim Then
                'lv.Items(lin).BackColor = System.Drawing.Color.Red
                _existe = True
            End If
        Next
        VerificaDatoEnListView = _existe
    End Function

    Private Sub tmrLEE_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLEE.Tick
        Try
            If GuardaTotDiios = lvALLFLEX_XLS.Items.Count Then
                tmrLEE.Enabled = False
                FinalizaLecturaAllFlex()
            End If

        Catch ex As Exception
            ''no mostramos ningun error en la lectura del ALLFLEX
        End Try

        GuardaTotDiios = lvALLFLEX_XLS.Items.Count
    End Sub


    Private Sub tmrLIMPIA_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLIMPIA.Tick
        lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
        pnlMSG.BackColor = Color.ForestGreen

        cboTipoBaston.Enabled = True
        cboPuertos.Enabled = True
        btnBastonLee.Enabled = True
        btnBastonLimpia.Enabled = True
        'btnProcesar.Enabled = True

        tmrLIMPIA.Enabled = False
        LeyendoBaston = False

        CierraPuertoBaston()           'If COMPort.IsOpen Then COMPort.Close()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub FinalizaLecturaAllFlex()
        lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
        pnlMSG.BackColor = Color.ForestGreen

        cboTipoBaston.Enabled = True
        btnBastonLee.Enabled = True
        btnBastonLimpia.Enabled = True
        cboPuertos.Enabled = True
        LeyendoBaston = False

        If lvALLFLEX_XLS.Items.Count > 0 Then
            btnProcesar.Enabled = True
            If lblRepetidos.Text <> "0" Then btnEliminaRepetidos.Enabled = True
        End If

        'CierraPuertoBaston()       'If COMPort.IsOpen Then COMPort.Close()

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub FinalizaLecturaXRS2()
        lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
        pnlMSG.BackColor = Color.ForestGreen
        LeyendoBaston = False
        cboTipoBaston.Enabled = True
        btnBastonLee.Enabled = True
        btnBastonLimpia.Enabled = True
        cboPuertos.Enabled = True
        FinalizaBarraEstadoSesiones()

        'fnDatosAuditoria.Tipocarga = "Baston XRS2"
        'fnDatosAuditoria.CentroCod = Param1_CentroCod
        'fnAuditoria.InsertSesion(fnDatosAuditoria, "frmCierresIngreso")
        'fnAuditoria.InsertDetalle(AuditId, Param1_CentroCod, lvXRS_DETALLE, "Baston XRS2", SerialBaston, NombreSesion)
    End Sub
    Private Sub FinalizaLecturaXRS()
        lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
        pnlMSG.BackColor = Color.ForestGreen

        cboTipoBaston.Enabled = True
        btnBastonLee.Enabled = True
        btnBastonLimpia.Enabled = True
        cboPuertos.Enabled = True

        'MsgBox((Now.TimeOfDay - hr1).ToString.Trim)

        'CierraPuertoBaston()       'If COMPort.IsOpen Then COMPort.Close()

        If CadenaXRS.ToString.Trim.Length > 20 Then
            If OperacionXRS = "SESIONES" Then
                ActualizaBarraEstado(NroTotalDiiosXRS)
                ConseguirListadoSesionesXRS()
            Else
                ActualizaBarraEstado(NroDiiosXRS)
                ConseguirListadoDIIOsXRS()
            End If
        End If

        LeyendoBaston = False
        ''
        FinalizaBarraEstado()

        OperacionXRS = ""
        ComandoXRS = ""
        IndXRS = 0
        SaveIndXRS = 0
        NroDiiosXRS = 0
        NroTotalDiiosXRS = 0

        Cursor.Current = Cursors.Default

        'MsgBox(CadenaXRS.Length.ToString)
    End Sub


    Private Sub ConseguirListadoSesionesXRS()
        'generamos arreglo con todas las respuestas del baston
        'en este caso tenemos un comando de sesion y 
        ''
        Dim Sesiones() As String = Regex.Split(CadenaXRS.ToString, "(?<=[]])") 'CadenaXRS.ToString.Split({"["}, StringSplitOptions.None)
        Dim DetalleDIIO() As String
        ''
        Dim nro_sesiones As Integer = 0
        Dim nro_diios As Integer = 0
        Dim pos_diios As Integer = 0
        Dim pos_diios_save As Integer = 0
        'Dim dias_val As Integer = 6
        'Dim ultima_ses As Boolean = False
        Dim dias_val As Integer = DiasHabiles(Param1_CentroCod, "CIERRE")
        'si el centro es area seca (1) o ternerera (2), tenemos 15 dias para leer sesiones de baston
        'If ValidaTipoCentro > 0 Then dias_val = 35 'se cambia de 16 a 30. Autorizado por Chris White.


        For Each item As String In Sesiones

            'If ultima_ses Then Exit Sub
            'If item.Trim = "[]" Then ultima_ses = True 'Exit Sub

            '-------------------------------------------------------------------------------------
            'si el item es una sesion (tamaño cadena menor a 40 caracteres)
            If item.Length > 10 And item.Length < 40 Then
                pos_diios = ObtieneNroDiiosSesionXRS(item)
            End If

            If item.Length > 40 Then
                'si el item es el primer diio de una sesion, entonces tomamos los datos de la sesion
                'If item.Length > 40 Then
                nro_sesiones = nro_sesiones + 1
                nro_diios = pos_diios - pos_diios_save      'restamos la posicion actual con la de la sesion anterior (resultado = nro_diios_de_la_sesion)

                If nro_diios <= 0 Then
                    nro_diios = NroTotalDiiosXRS - pos_diios_save
                End If


                DetalleDIIO = item.Split({","}, StringSplitOptions.None)

                Dim lvitem As New ListViewItem("")
                lvitem.Checked = False
                lvitem.SubItems.Add("Sesión " + nro_sesiones.ToString.Trim)     '
                lvitem.SubItems.Add(DetalleDIIO(3))                             'fecha sesion
                lvitem.SubItems.Add((nro_diios).ToString.Trim)                  'nro diios sesion
                lvitem.SubItems.Add("0")                                        'en cache? 0=NO / 1=SI
                lvitem.SubItems.Add(DetalleDIIO(0).Substring(1))                'posicion para rescatar los diios

                lvXRS_SESIONES.Items.Add(lvitem)

                If ValidaParaCierre Then
                    Dim fec_ As DateTime = DateTime.Parse(DetalleDIIO(3))
                    Dim dias As Integer = DateDiff(DateInterval.Day, fec_, Now)

                    If dias > dias_val Then
                        lvitem.UseItemStyleForSubItems = False

                        For x As Integer = 0 To lvXRS_SESIONES.Columns.Count - 1
                            lvitem.SubItems(x).BackColor = Color.LightGray
                        Next
                    End If
                End If

                pos_diios_save = pos_diios + 1
            End If
            '-------------------------------------------------------------------------------------

        Next

        'MsgBox(Sesiones.ToString)
    End Sub


    Private Sub ConseguirListadoDIIOsXRS()
        'generamos arreglo con todas las respuestas del baston
        'en este caso tenemos un comando de sesion y 
        ''
        CadenaXRS.Replace(";", "]")

        Dim DIIOs() As String = Regex.Split(CadenaXRS.ToString, "(?<=[]])") 'CadenaXRS.ToString.Split({"["}, StringSplitOptions.None)
        Dim DetalleDIIO() As String
        ''
        Dim itm As ListViewItem
        Dim i1, i2 As Integer
        Dim str_rep As String

        For Each item As String In DIIOs
            If item.Trim = "[]" Or item.Trim = "" Then
                Exit For
            End If
            '-------------------------------------------------------------------------------------
            'dividimos una linea de DIIO (obtenida con comando DL) en un arreglo
            DetalleDIIO = item.Split({","}, StringSplitOptions.None)
            i1 = 0
            i2 = 2
            ContDIIOsXRS += 1

            If DetalleDIIO.Length = 6 Then
                i1 = 1
                i2 = 3
            End If
            '-------------------------------------------------------------------------------------
            DIIOTempXRS = DetalleDIIO(i1).Substring(DetalleDIIO(i1).Length - 8)
            '-------------------------------------------------------------------------------------
            Dim di As Integer = 0
            Try
                di = Convert.ToInt32(DIIOTempXRS)
            Catch ex As Exception
            End Try
            '-------------------------------------------------------------------------------------
            DIIOTempXRS = di.ToString.Trim
            '-------------------------------------------------------------------------------------
            itm = ItemsXRS.Find(AddressOf BuscaItemXRS)       'busca DIIO en la lista de items
            str_rep = ""

            If itm IsNot Nothing Then
                ContDIIOsRepXRS += 1
                str_rep = "SI"
            End If
            '-------------------------------------------------------------------------------------
            Dim item2 As New ListViewItem(ContDIIOsXRS)
            item2.SubItems.Add(DIIOTempXRS)
                item2.SubItems.Add(DetalleDIIO(i2))
                item2.SubItems.Add(NombreSesion)
                item2.SubItems.Add(str_rep)
                item2.SubItems.Add("Electronico")
            ItemsXRS.Add(item2)
            '
            'fnDatosAuditoria.DIIO = DIIOTempXRS
            'fnDatosAuditoria.Serial = SerialBaston
            'fnDatosAuditoria.FechaLectura = validatetime(DetalleDIIO(i2))

            '-------------------------------------------------------------------------------------
        Next

        lvXRS_DETALLE.BeginUpdate()
        lvXRS_DETALLE.Items.Clear()
        lvXRS_DETALLE.Items.AddRange(ItemsXRS.ToArray())
        lvXRS_DETALLE.EndUpdate()

        lblTotDiios.Text = (ContDIIOsXRS).ToString().Trim
        lblRepetidos.Text = ContDIIOsRepXRS.ToString.Trim

        If ContDIIOsRepXRS > 0 Then PintarRepetidos(lvXRS_DETALLE, 4)

        If lblTotDiios.Text <> "0" Then
            btnProcesar.Enabled = True
            If lblRepetidos.Text <> "0" Then btnEliminaRepetidos.Enabled = True
        End If
        'nAuditoria.InsertDetalle(AuditId, Param1_CentroCod, lvXRS_DETALLE, "Baston XRS", SerialBaston)
    End Sub
    Private Function validatetime(ByVal fec As DateTime) As Date

        Dim fechaMinima As New DateTime(1900, 1, 1)
        Dim fechaMaxima As DateTime = DateTime.Now

        Try
            Dim fecha As DateTime = CDate(fec)

            If (fecha < fechaMinima) Or (fecha > fechaMaxima) Then
                validatetime = fechaMaxima
            Else
                validatetime = fecha
            End If

        Catch ex As Exception
            If MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error") = MsgBoxResult.Ok Then
            End If
        End Try
        Return validatetime
    End Function

    Private Sub PintarRepetidos(ByVal lv As ListView, ByVal ColRepetido As Integer)
        For Each itm As ListViewItem In lv.Items

            If itm.SubItems(ColRepetido).Text = "SI" Then
                itm.UseItemStyleForSubItems = False

                'For x As Integer = 0 To lv.Columns.Count - 1
                '    itm.SubItems(x).BackColor = Color.Red '.FromArgb(255, 255, 192)
                'Next
            End If

        Next
    End Sub


    Private Sub MostrarYValidarDatosAImportar()
        Cursor.Current = Cursors.WaitCursor

        lvALLFLEX_XLS.Items.Clear()
        lblTotDiios.Text = "0"
        lblRepetidos.Text = "0"

        Try
            Dim AppExcel As New Application
            Dim Libro As Workbook = AppExcel.Workbooks.Open(ArchivoImportacion)
            Dim Hoja As Worksheet = Libro.Worksheets(1)
            ''
            Dim UltimaLinea As Long = Hoja.Range("A65536").End(XlDirection.xlUp).Row
            If UltimaLinea = 0 Then Exit Sub

            Dim Procesa As Boolean
            Dim items As New List(Of ListViewItem)
            Dim itm As ListViewItem
            Dim cont_rep As Integer
            Dim str_rep As String
            Dim lin As Integer
            Dim DIIOFechaXls As String = ""

            Procesa = True
            lin = 1

            pbProcesa.Maximum = UltimaLinea + 1
            pnlProcesa.Visible = True
            pnlProcesa.Refresh()

            Do While Procesa
                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    Exit Do
                End If
                DIIOTempXRS = Hoja.Cells(lin, 1).value.ToString
                If Hoja.Cells(lin, 2).value = Nothing Then
                    Dim hora As String = Now.ToString("yyyyMMdd")
                    DIIOFechaXls = hora
                Else
                    DIIOFechaXls = Hoja.Cells(lin, 2).value.ToString
                End If
                itm = items.Find(AddressOf BuscaItemXRS)       'busca DIIO en la lista de items
                str_rep = ""

                If itm IsNot Nothing Then
                    cont_rep += 1
                    str_rep = "SI"
                End If

                Dim item As New ListViewItem(lin)
                item.SubItems.Add(DIIOTempXRS)
                item.SubItems.Add(DIIOFechaXls)
                item.SubItems.Add("Excel")
                item.SubItems.Add(str_rep)
                items.Add(item)

                'fnDatosAuditoria.DIIO = DIIOTempXRS
                'fnDatosAuditoria.Serial = "Excel"
                'fnDatosAuditoria.FechaLectura = DIIOFechaXls

                lin = lin + 1
                pbProcesa.Value = lin
            Loop

            pbProcesa.Value = pbProcesa.Maximum
            Hoja = Nothing      'Descargamos los Objetos...

            Libro.Close()
            AppExcel.Quit()
            '   EnviaEmail()

            lvALLFLEX_XLS.BeginUpdate()
            lvALLFLEX_XLS.Items.Clear()
            lvALLFLEX_XLS.Items.AddRange(items.ToArray())
            lvALLFLEX_XLS.EndUpdate()

            lblTotDiios.Text = (lin - 1).ToString().Trim
            lblRepetidos.Text = cont_rep.ToString.Trim
            pnlProcesa.Visible = False

            If cont_rep > 0 Then PintarRepetidos(lvALLFLEX_XLS, 2)

        Catch ex As Exception
            If MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR") = MsgBoxResult.Ok Then
            End If
        End Try

        If lblTotDiios.Text <> "0" Then
            'BuscaDiiosRepetidos("AllFlex_Excel")
            btnProcesar.Enabled = True
            If lblRepetidos.Text <> "0" Then btnEliminaRepetidos.Enabled = True
        End If

        Cursor.Current = Cursors.Default
    End Sub


    Private Function BuscaItemXRS(ByVal itm As ListViewItem) As Boolean
        If itm.SubItems(1).Text.ToString = DIIOTempXRS Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Sub InicializaLecturaXRS()
        CadenaXRS.Clear()
        IndXRS = 0
        SaveIndXRS = 0
        NroDiiosXRS = 0
        NroTotalDiiosXRS = 0
        OperacionXRS = "NRO"   'indicamos comando a procesar -- DN -- (consigue nro total de diios del bastón)
        ComandoXRS = ""
        PasoUltimoDatoXRS = False
    End Sub

    'Private Sub EnviaEmail()
    '    ''SP ENVIA EMAIL''
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spAuditoriaLector_EnviaEmail", con)
    '    Dim rdr As SqlDataReader = Nothing
    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    Try
    '        con.Open()
    '        Dim Result As Integer = cmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR ENVIA EMAIL")
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub

    Private Sub btnBastonLee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBastonLee.Click

        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex

        Dim estado As String = ""
        If tbast_ = 0 Then
            estado = "Baston ALLFLEX"
        End If
        If tbast_ = 1 Then
            estado = "Baston XRS"
        End If
        If tbast_ = 2 Then
            estado = "Baston XRS2"
        End If
        If tbast_ = 3 Then
            estado = "Gallagher HR4-5"
        End If
        If tbast_ = 4 Then
            estado = "Agrident"
        End If
        Cursor.Current = Cursors.WaitCursor

        Try
            cboTipoBaston.Enabled = False
            cboPuertos.Enabled = False
            btnBastonLee.Enabled = False
            btnBastonLimpia.Enabled = False
            btnEliminaRepetidos.Enabled = False
            btnProcesar.Enabled = False

            lblTotDiios.Text = "0"
            lblRepetidos.Text = "0"

            TotalDiios = 0
            GuardaTotDiios = 0
            LeyendoBaston = True

            lblMSG.Text = "LEYENDO BASTON"
            pnlMSG.BackColor = Color.DarkOrange

            TipoBaston = cboTipoBaston.Text
            COMBaston = cboPuertos.Text 'guardamos puerta com

            'AbrePuertoBaston()

            If tbast_ = 0 Then
                'BASTON ALLFLEX (ANTIGUO)
                lvALLFLEX_XLS.Items.Clear()
                ''
                'COMPort.Write("#P")
                'ValidaAllflex = False
                COMPort.Write("#G")

                tmrLEE.Enabled = True

            End If
            If tbast_ = 1 Then
                'BASTON XRS
                lvXRS_SESIONES.Items.Clear()
                lvXRS_DETALLE.Items.Clear()

                InicializaLecturaXRS()
                ''''''''''''''''''''''''''''''''''''''
                Thread.Sleep(200)
                ''''''''''''''''''''''''''''''''''''''
                'pedimos nro total de diios
                EnviaComandoXRS("DN")
            End If
            If tbast_ = 2 Then
                'BASTON XRS (NUEVO)
                lvXRS_SESIONES.Items.Clear()
                lvXRS_DETALLE.Items.Clear()

                InicializaLecturaXRS()
                ''''''''''''''''''''''''''''''''''''''
                Thread.Sleep(200)
                ''''''''''''''''''''''''''''''''''''''
                'comando para devolver la cantidad de sesiones en el baston
                ComandoXRS = "sesiones"
                EnviaComandoXRS("FLN")
            End If
            If tbast_ = 3 Then
                'Gallagher
                Dim puerto As String = cboPuertos.Text
                Dim STR As String = puerto
                Dim Delimitador_A As String = "("
                Dim Delimitador_B As String = ")"

                STR = Split(STR, Delimitador_A, , CompareMethod.Text)(1) '  Aquí tomo todo lo que hay a la derecha del primer delimitador
                STR = Split(STR, Delimitador_B, , CompareMethod.Text)(0) '

                Dim com As String = STR
                fnConteoGallagher.ConexionGallagherSesiones(com)
                lvXRS_SESIONES.Items.Clear()
                lvXRS_DETALLE.Items.Clear()
                ''''''''''''''''''''''''''''''''''''''
                fnConteoGallagher.ProcesarSesionesGallagher("Conteo")
                lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
                pnlMSG.BackColor = Color.ForestGreen
                fnConteoGallagher.CerrarCom()

                Dim dias_val As Integer = 59

                Dim n As Integer
                n = lvXRS_SESIONES.Items.Count.ToString
                For i = 0 To n - 1
                    Dim fecha As Date = lvXRS_SESIONES.Items(i).SubItems(2).Text 'Format(DIIOFechaXls, "yyyy-MM-dd")
                    Dim dias As Integer = DateDiff(DateInterval.Day, fecha, Now)
                    If dias > dias_val Then
                        lvXRS_SESIONES.Items(i).BackColor = Color.LightGray
                    End If
                Next
            End If
            If tbast_ = 4 Then
                'Agrident
                Dim puerto As String = cboPuertos.Text
                Dim STR As String = puerto
                Dim Delimitador_A As String = "("
                Dim Delimitador_B As String = ")"

                STR = Split(STR, Delimitador_A, , CompareMethod.Text)(1) '  Aquí tomo todo lo que hay a la derecha del primer delimitador
                STR = Split(STR, Delimitador_B, , CompareMethod.Text)(0) '

                Dim com As String = STR
                fnConteoGallagher.ConexionAgridentSesiones(com)
                lvXRS_SESIONES.Items.Clear()
                lvXRS_DETALLE.Items.Clear()
                ''''''''''''''''''''''''''''''''''''''
                fnConteoGallagher.ProcesarSesionesAgrident("Conteo", com)
                lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
                pnlMSG.BackColor = Color.ForestGreen
                fnConteoGallagher.CerrarCom()

                Dim dias_val As Integer = DiasHabiles(Param1_CentroCod, "CIERRE")

                Dim n As Integer
                n = lvXRS_SESIONES.Items.Count.ToString
                For i = 0 To n - 1
                    Dim fecha As Date = lvXRS_SESIONES.Items(i).SubItems(2).Text 'Format(DIIOFechaXls, "yyyy-MM-dd")
                    Dim dias As Integer = DateDiff(DateInterval.Day, fecha, Now)
                    If dias > dias_val Then
                        lvXRS_SESIONES.Items(i).BackColor = Color.LightGray
                    End If
                Next
            End If
        Catch ex As Exception
            If MsgBox("ERROR EN LA LECTURA DEL BASTON:" + vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR") = MsgBoxResult.Ok Then
            End If
        End Try
    End Sub

    Private Sub btnBastonLimpia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBastonLimpia.Click
        If MsgBox("¿ DESEA BORRAR LA MEMORIA DEL BASTÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACIÓN") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex

        Try
            'Cursor.Current = Cursors.WaitCursor

            cboPuertos.Enabled = False
            btnBastonLee.Enabled = False
            btnBastonLimpia.Enabled = False
            btnEliminaRepetidos.Enabled = False
            btnProcesar.Enabled = False

            lvALLFLEX_XLS.Items.Clear()
            lblTotDiios.Text = "0"
            lblRepetidos.Text = "0"

            TotalDiios = 0
            GuardaTotDiios = 0
            LeyendoBaston = True

            lblMSG.Text = "BORRANDO MEMORIA BASTÓN"
            pnlMSG.BackColor = Color.DarkOrange

            TipoBaston = cboTipoBaston.Text
            COMBaston = cboPuertos.Text 'guardamos puerta com

            'AbrePuertoBaston()
            'If COMPort.IsOpen Then COMPort.Close()
            'COMPort.Open()

            If tbast_ = 0 Then
                'BASTON ALLFLEX (ANTIGUO)
                COMPort.Write("#P")
                COMPort.Write("#C" + Chr(13))     'limpia diios baston

            End If
            If tbast_ = 1 Then
                'BASTON XRS
                EnviaComandoXRS("CL")
            End If
            If tbast_ = 2 Then
                'BASTON XRS2 (NUEVO)
                EnviaComandoXRS("CL")
            End If

            tmrLIMPIA.Enabled = True
        Catch ex As Exception
            If MsgBox("ERROR EN LA LECTURA DEL BASTON:" + vbCrLf + ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR") = MsgBoxResult.Ok Then
            End If
        End Try
    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click

        fnDatosAuditoria.Tipocarga = "Baston XRS2"
        fnDatosAuditoria.CentroCod = Param1_CentroCod
        fnAuditoria.InsertSesion(fnDatosAuditoria, "frmCierresIngreso")
        fnAuditoria.InsertDetalle(AuditId, Param1_CentroCod, lvXRS_DETALLE, "Baston XRS2", SerialBaston, NombreSesion)

        If lblRepetidos.Text <> "0" Then
            MsgBox("Debe Eliminar los repetidos antes de Procesar.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If
        If Param3_Formulario = "frmCierresIngreso" Then
            EnviaEmail(Param1_CentroCod)
            Digitados(Param1_CentroCod)
        End If
        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex
        TBaston = tbast_
        If tbast_ = 1 Or tbast_ = 2 Or tbast_ = 3 Or tbast_ = 4 Then
            lvBASTON = lvXRS_DETALLE
        Else
            lvBASTON = lvALLFLEX_XLS
        End If

        Procesa = True

        Cerrar()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If LeyendoBaston = True Then
            If COMPort.IsOpen Then COMPort.Close()
            LeyendoBaston = False
        End If
        COMPort.Close()
        Cerrar()
    End Sub

    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        COMPort.Dispose()
        'Me.Dispose()
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lvDIIOS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvALLFLEX_XLS.KeyDown, lvXRS_DETALLE.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MsgBox("¿DESEA --NO PROCESAR-- LOS DIIOS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
                Dim tbast_ As Integer = cboTipoBaston.SelectedIndex

                If tbast_ = 1 Or tbast_ = 2 Or tbast_ = 3 Or tbast_ = 4 Then
                    For Each it As ListViewItem In lvXRS_DETALLE.SelectedItems
                        lvXRS_DETALLE.Items.Remove(it)
                    Next

                    lblTotDiios.Text = lvXRS_DETALLE.Items.Count.ToString.Trim
                Else
                    For Each it As ListViewItem In lvALLFLEX_XLS.SelectedItems
                        lvALLFLEX_XLS.Items.Remove(it)
                    Next

                    lblTotDiios.Text = lvALLFLEX_XLS.Items.Count.ToString.Trim
                End If
            End If
        End If
    End Sub

    Private Sub cboTipoBaston_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoBaston.SelectedIndexChanged
        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex

        OrigenBaston = tbast_
        cboPuertos.Enabled = True


        If tbast_ = 0 Or tbast_ = 1 Or tbast_ = 2 Or tbast_ = 3 Or tbast_ = 4 Then
            'PARA LOS 3 BASTONES
            lblMSG.Text = "SELECCIONE EL PUERTO PARA LECTURA"
            pnlMSG.BackColor = Color.SteelBlue
            Label2.Text = "PUERTO"
            cboPuertos.Visible = True
            txtArchivo.Visible = False
            btnArchivo.Visible = False
            If tbast_ = 4 Then
                If cboPuertos.SelectedIndex = -1 Then
                    cboPuertos.SelectedIndex = 0
                End If
                'BASTON Agrident
                COMPort.Close()
                lvALLFLEX_XLS.Visible = False
                lvXRS_SESIONES.Visible = True
                lvXRS_DETALLE.Visible = True



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
                btnBastonLee.Enabled = True
                cboPuertos.Enabled = False
                fnConteoGallagher.CerrarCom()
            End If
            If tbast_ = 3 Then
                If cboPuertos.SelectedIndex = -1 Then
                    cboPuertos.SelectedIndex = 0
                End If
                'BASTON gallagher (NUEVO)
                COMPort.Close()
                lvALLFLEX_XLS.Visible = False
                lvXRS_SESIONES.Visible = True
                lvXRS_DETALLE.Visible = True



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
                btnBastonLee.Enabled = True
                cboPuertos.Enabled = False
                fnConteoGallagher.CerrarCom()
            End If
            If tbast_ = 0 Then
                CboLlenaPuertos()
                'BASTON ALLFLEX (ANTIGUO)
                lvALLFLEX_XLS.Columns(1).Width = 190

                lvALLFLEX_XLS.Visible = True
                lvXRS_SESIONES.Visible = False
                lvXRS_DETALLE.Visible = False
            End If
            If tbast_ = 1 Then
                CboLlenaPuertos()
                'BASTON XRS
                lvALLFLEX_XLS.Visible = False
                lvXRS_SESIONES.Visible = True
                lvXRS_DETALLE.Visible = True
            End If
            If tbast_ = 2 Then
                CboLlenaPuertos()
                'BASTON XRS2 (NUEVO)
                lvALLFLEX_XLS.Visible = False
                lvXRS_SESIONES.Visible = True
                lvXRS_DETALLE.Visible = True
            End If

            'cboPuertos.SelectedIndex = -1
            'If cboPuertos.Items.Count = 1 Then cboPuertos.SelectedIndex = 0
        Else
            'PLANILLA EXCEL
            lblMSG.Text = "SELECCIONE ARCHIVO EXCEL"
            pnlMSG.BackColor = Color.ForestGreen
            Label2.Text = "ARCHIVO"
            cboPuertos.Visible = False
            txtArchivo.Visible = True
            btnArchivo.Visible = True
            txtArchivo.Text = ""
            ArchivoImportacion = ""
            NombreArchivo = ""

            lvALLFLEX_XLS.Visible = True
            lvXRS_SESIONES.Visible = False
            lvXRS_DETALLE.Visible = False

            'las columnas quedan sin sesion
            lvALLFLEX_XLS.Columns(1).Width = 190
            'lvALLFLEX.Columns(2).Width = 0
        End If
    End Sub



    Private Sub btnEliminaRepetidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminaRepetidos.Click
        If lblRepetidos.Text = "0" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex
        If tbast_ = 3 Then
            Dim num As Integer = 0
            For Each it As ListViewItem In lvXRS_DETALLE.Items
                If lvXRS_DETALLE.Items(num).BackColor = Color.Red Then
                    lvXRS_DETALLE.Items.Remove(it)
                    lblTotDiios.Text = lblTotDiios.Text - 1
                    lblRepetidos.Text = lblRepetidos.Text - 1
                    num = num - 1
                    fnConteoGallagher.contI = fnConteoGallagher.contI - 1
                End If
                num = num + 1
            Next
            lblRepetidos.Text = 0
        End If
        If tbast_ = 4 Then
            Dim num As Integer = 0
            For Each it As ListViewItem In lvXRS_DETALLE.Items
                If lvXRS_DETALLE.Items(num).BackColor = Color.Red Then
                    lvXRS_DETALLE.Items.Remove(it)
                    lblTotDiios.Text = lblTotDiios.Text - 1
                    lblRepetidos.Text = lblRepetidos.Text - 1
                    num = num - 1
                    fnConteoGallagher.contI = fnConteoGallagher.contI - 1
                End If
                num = num + 1
            Next
            lblRepetidos.Text = 0
        End If
        If tbast_ = 2 Then
            Dim i As Integer = 0

            Try
                For i = ItemsXRS.Count - 1 To 0 Step -1
                    If ItemsXRS.Item(i).SubItems(4).Text <> "" Then
                        ItemsXRS.RemoveAt(i)
                        ContDIIOsXRS2 -= 1
                        'resta total diios (segun sesiones seleccionadas)
                    End If
                Next
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try

            lvXRS_DETALLE.BeginUpdate()
            lvXRS_DETALLE.Items.Clear()
            lvXRS_DETALLE.Items.AddRange(ItemsXRS.ToArray())
            lvXRS_DETALLE.EndUpdate()

            ContDIIOsRepXRS = 0

            lblTotDiios.Text = ContDIIOsXRS2
            lblRepetidos.Text = (ContDIIOsRepXRS).ToString().Trim
        End If
        If tbast_ = 1 Then
            Dim i As Integer = 0

            Try
                For i = ItemsXRS.Count - 1 To 0 Step -1
                    If ItemsXRS.Item(i).SubItems(4).Text <> "" Then
                        ItemsXRS.RemoveAt(i)
                        ContDIIOsXRS -= 1       'resta total diios (segun sesiones seleccionadas)
                    End If
                Next
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try

            lvXRS_DETALLE.BeginUpdate()
            lvXRS_DETALLE.Items.Clear()
            lvXRS_DETALLE.Items.AddRange(ItemsXRS.ToArray())
            lvXRS_DETALLE.EndUpdate()

            ContDIIOsRepXRS = 0

            lblTotDiios.Text = (ContDIIOsXRS).ToString().Trim
            lblRepetidos.Text = (ContDIIOsRepXRS).ToString().Trim
        End If

        If tbast_ = 0 Then
            'Dim lv As ListView = lvALLFLEX

            For Each it As ListViewItem In lvALLFLEX_XLS.Items
                If it.SubItems(4).Text <> "" Then
                    lvALLFLEX_XLS.Items.Remove(it)
                End If
            Next

            lblTotDiios.Text = lvALLFLEX_XLS.Items.Count.ToString.Trim
            lblRepetidos.Text = "0"
        End If
        lblRepetidos.Text = 0
        btnEliminaRepetidos.Enabled = False

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cboPuertos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPuertos.SelectedIndexChanged
        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex
        If tbast_ = 3 Then
            Exit Sub
        End If
        If tbast_ = 4 Then
            Exit Sub
        End If
        If cboPuertos.SelectedIndex = -1 Then Exit Sub
        btnBastonLee.Enabled = False
        Try
            'Si el puerto esta abierto, se cierra
            If COMPort.IsOpen Then COMPort.Close()
            'Se le asgina el Puerto seleccionado en el ComboBox
            COMPort.PortName = cboPuertos.Text.Trim
            'Si el puerto NO esta abierto, se abre
            If Not COMPort.IsOpen Then COMPort.Open()

            COMPort.ReceivedBytesThreshold = 1
        Catch ex As Exception
            MsgBox("Error al abrir el puerto." & ex.Message, MsgBoxStyle.Critical, "Error COM PORT")
        End Try

        lblMSG.Text = "AHORA PUEDE LEER EL BASTON"
        pnlMSG.BackColor = Color.ForestGreen
        btnProcesar.Enabled = False
        btnBastonLee.Enabled = True
        btnBastonLimpia.Enabled = True
        'AbrePuertoBaston()

        If tbast_ = 1 Or tbast_ = 2 Then
            Try
                ComandoXRS = "Seriales"
                EnviaComandoXRS("VS")
            Catch ex As Exception
                MsgBox("Error al obtener Serial Number." & ex.Message, MsgBoxStyle.Critical, "Error COM PORT")
            End Try

        End If
        btnBastonLee.Enabled = True


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

    Private Sub btnArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivo.Click
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

        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex

        Dim estado As String = "Planilla Excel"


        Cursor.Current = Cursors.WaitCursor

        'mostramos diios de la planilla
        MostrarYValidarDatosAImportar()
        lblMSG.Text = "SELECCIONE ARCHIVO EXCEL"
        pnlMSG.BackColor = Color.ForestGreen

        'If Param3_Formulario <> "frmMuestreosIngreso" Then
        '    If lvALLFLEX_XLS.Items(0).SubItems(2).Text.Contains("-") Or lvALLFLEX_XLS.Items(0).SubItems(2).Text.Contains("/") Then
        '        fnAuditoria.InsertDetalle(AuditId, Param1_CentroCod, lvALLFLEX_XLS, "Excel", "Excel")
        '    End If
        'End If
    End Sub


    Private Sub lvXRS_SESIONES_ItemCheck(sender As Object, e As System.Windows.Forms.ItemCheckEventArgs) Handles lvXRS_SESIONES.ItemCheck

        Dim color_fondo As Color = lvXRS_SESIONES.Items(e.Index).BackColor
        Dim color_fondo_ As Color = lvXRS_SESIONES.Items(e.Index).SubItems(1).BackColor

        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex
        If tbast_ = 3 Then
            If color_fondo = Color.LightGray Then
                e.NewValue = CheckState.Unchecked
                MsgBox("Sesión -- deshabilitada -- para cierre de Estado de Ganado", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        If tbast_ = 4 Then
            If color_fondo = Color.LightGray Then
                e.NewValue = CheckState.Unchecked
                MsgBox("Sesión -- deshabilitada -- para cierre de Estado de Ganado", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If

        If LeyendoBaston = True Then Exit Sub

        'validamos color de fondo de la sesion, si es color es PLOMO, entonces cancelamos carga de DIIOs
        'esto son las nuevas validaciones para la carga de sesiones para el cierre, solo hasta 2 dias para salas normales y 15 dias para areas seca y pooles

        If color_fondo_ = Color.LightGray Then
            e.NewValue = CheckState.Unchecked
            MsgBox("Sesión -- deshabilitada -- para cierre de Estado de Ganado", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub


    Private Sub lvXRS_SESIONES_ItemChecked(sender As System.Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvXRS_SESIONES.ItemChecked
        Dim tbast_ As Integer = cboTipoBaston.SelectedIndex
        If tbast_ = 4 Then
            Dim totaldios As Integer = lblTotDiios.Text
            Dim diosrepetidos As Integer = lblRepetidos.Text
            NombreSesion = e.Item.SubItems(1).Text
            If e.Item.Checked = True Then
                NombreSesion = e.Item.SubItems(1).Text
                IndexDeSesion = e.Item.SubItems(5).Text
                NumeroDiios = e.Item.SubItems(3).Text
                contBarra = NumeroDiios
                Dim num As String = e.Item.SubItems(5).Text
                InicilizaBarraEstado(NumeroDiios)
                Dim puerto As String = cboPuertos.Text
                Dim STR As String = puerto
                Dim Delimitador_A As String = "("
                Dim Delimitador_B As String = ")"
                STR = Split(STR, Delimitador_A, , CompareMethod.Text)(1) '  Aquí tomo todo lo que hay a la derecha del primer delimitador
                STR = Split(STR, Delimitador_B, , CompareMethod.Text)(0) '
                Dim com As String = STR
                fnConteoGallagher.ConexionAgridentSesiones(com)
                fnConteoGallagher.ProcesarDiiosAgrident(num, cboPuertos.Text, "Conteo")
                lblTotDiios.Text = NumeroDiios + totaldios
            Else
                Dim i As Integer
                Dim cont As Integer
                Dim contrep As Integer
                Try
                    Dim num As Integer
                    num = lvXRS_DETALLE.Items.Count.ToString
                    For i = num - 1 To 0 Step -1
                        If lvXRS_DETALLE.Items(i).SubItems(3).Text = NombreSesion Then
                            If lvXRS_DETALLE.Items(i).BackColor = Color.Red Then
                                contrep += 1
                            End If
                            lvXRS_DETALLE.Items.RemoveAt(i)
                            fnConteoGallagher.contI = fnConteoGallagher.contI - 1
                            cont += 1
                        End If
                    Next
                Catch ex As Exception
                End Try
                lblRepetidos.Text = diosrepetidos - contrep
                lblTotDiios.Text = totaldios - cont
            End If
            Dim SiRepetido As Integer = 0
            Dim rep As Integer
            rep = lvXRS_DETALLE.Items.Count.ToString
            For i = rep - 1 To 0 Step -1
                If lvXRS_DETALLE.Items(i).BackColor = Color.Red Then
                    SiRepetido = 1
                End If
            Next
            If SiRepetido = 0 Then
                btnEliminaRepetidos.Enabled = False
            Else
                btnEliminaRepetidos.Enabled = True
            End If
            If lblTotDiios.Text <> "0" Then
                btnProcesar.Enabled = True
                If lblRepetidos.Text <> "0" Then btnEliminaRepetidos.Enabled = True
            Else
                btnProcesar.Enabled = False
            End If
            fnConteoGallagher.CerrarCom()
        End If
        If tbast_ = 3 Then
            Dim totaldios As Integer = lblTotDiios.Text
            Dim diosrepetidos As Integer = lblRepetidos.Text
            NombreSesion = e.Item.SubItems(1).Text
            If e.Item.Checked = True Then
                NombreSesion = e.Item.SubItems(1).Text
                IndexDeSesion = e.Item.SubItems(5).Text
                NumeroDiios = e.Item.SubItems(3).Text
                contBarra = NumeroDiios
                Dim num As String = e.Item.SubItems(5).Text
                InicilizaBarraEstado(NumeroDiios)
                Dim puerto As String = cboPuertos.Text
                Dim STR As String = puerto
                Dim Delimitador_A As String = "("
                Dim Delimitador_B As String = ")"
                STR = Split(STR, Delimitador_A, , CompareMethod.Text)(1) '  Aquí tomo todo lo que hay a la derecha del primer delimitador
                STR = Split(STR, Delimitador_B, , CompareMethod.Text)(0) '
                Dim com As String = STR
                fnConteoGallagher.ConexionGallagherSesiones(com)
                fnConteoGallagher.ProcesarDiiosGallagher(num, cboPuertos.Text, "Conteo")
                lblTotDiios.Text = NumeroDiios + totaldios
            Else
                Dim i As Integer
                Dim cont As Integer
                Dim contrep As Integer
                Try
                    Dim num As Integer
                    num = lvXRS_DETALLE.Items.Count.ToString
                    For i = num - 1 To 0 Step -1
                        If lvXRS_DETALLE.Items(i).SubItems(3).Text = NombreSesion Then
                            If lvXRS_DETALLE.Items(i).BackColor = Color.Red Then
                                contrep += 1
                            End If
                            lvXRS_DETALLE.Items.RemoveAt(i)
                            cont += 1
                        End If
                    Next
                Catch ex As Exception
                End Try
                lblRepetidos.Text = diosrepetidos - contrep
                lblTotDiios.Text = totaldios - cont
            End If
            Dim SiRepetido As Integer = 0
            Dim rep As Integer
            rep = lvXRS_DETALLE.Items.Count.ToString
            For i = rep - 1 To 0 Step -1
                If lvXRS_DETALLE.Items(i).BackColor = Color.Red Then
                    SiRepetido = 1
                End If
            Next
            If SiRepetido = 0 Then
                btnEliminaRepetidos.Enabled = False
            Else
                btnEliminaRepetidos.Enabled = True
            End If
            If lblTotDiios.Text <> "0" Then
                btnProcesar.Enabled = True
                If lblRepetidos.Text <> "0" Then btnEliminaRepetidos.Enabled = True
            Else
                btnProcesar.Enabled = False
            End If
            fnConteoGallagher.CerrarCom()
        End If
        If tbast_ = 2 Then
            NombreSesion = e.Item.SubItems(1).Text
            If e.Item.Checked = True Then

                NombreSesion = e.Item.SubItems(1).Text
                IndexDeSesion = e.Item.SubItems(5).Text
                NumeroDiios = e.Item.SubItems(3).Text
                contBarra = NumeroDiios
                Dim contfl As String
                contfl = ArraySesionesFL(IndexDeSesion)
                contfl = Replace(contfl, "[", "")
                contfl = Replace(contfl, "]", "")
                contfl = Convert.ToInt32(contfl)
                EnviaComandoXRS("FF" + contfl.ToString.Trim)       'elegimos la sesion
                Thread.Sleep(200)
                EnviaComandoXRS("FH")                                       'le damos el formato a la sesion
                'CadenaXRS.Clear()
                Thread.Sleep(200)
                ComandoXRS = "ListaDiios"
                EnviaComandoXRS("FD")                                     'preparamos la descarga de los diios          
                Thread.Sleep(200)
                CadenaXRS.Clear()
                InicilizaBarraEstado(NumeroDiios)
            Else
                Dim i As Integer

                Try
                    For i = ItemsXRS.Count - 1 To 0 Step -1
                        If ItemsXRS.Item(i).SubItems(3).Text = NombreSesion Then
                            If ItemsXRS.Item(i).SubItems(4).Text <> "" Then
                                ContDIIOsRepXRS -= 1 'resta diios repetidos, si hay

                            End If
                            ItemsXRS.RemoveAt(i)
                            ContDIIOsXRS2 -= 1       'resta total diios (segun sesiones seleccionadas)
                        End If
                    Next
                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try
                lvXRS_DETALLE.BeginUpdate()
                lvXRS_DETALLE.Items.Clear()
                lvXRS_DETALLE.Items.AddRange(ItemsXRS.ToArray())
                lvXRS_DETALLE.EndUpdate()

                lblRepetidos.Text = ContDIIOsRepXRS.ToString.Trim
                lblTotDiios.Text = ContDIIOsXRS2
                If ContDIIOsRepXRS > 0 Then PintarRepetidos(lvXRS_DETALLE, 4)

                If lblTotDiios.Text <> "0" Then
                    btnProcesar.Enabled = True
                    If lblRepetidos.Text <> "0" Then btnEliminaRepetidos.Enabled = True
                End If
            End If
        End If
        If tbast_ = 1 Then
            If LeyendoBaston = True Then Exit Sub

            'tomamos el nombre de la sesion, segun el indice del item en donde hizo un click
            NombreSesion = e.Item.SubItems(1).Text

            'si esta seleccionando la sesion, entonces leemos diios del baston
            If e.Item.Checked = True Then
                'AbrePuertoBaston()

                LeyendoBaston = True

                CadenaXRS.Clear()
                NroDiiosXRS = 0
                OperacionXRS = "DIIOS"   'indicamos comando a procesar -- DL -- (consigue diios del bastón)
                ComandoXRS = ""

                IndXRS = Convert.ToInt32(e.Item.SubItems(5).Text)
                NroDiiosXRS = Convert.ToInt32(e.Item.SubItems(3).Text)
                SaveIndXRS = IndXRS
                PasoUltimoDatoXRS = False
                Thread.Sleep(200)
                InicilizaBarraEstado(NroDiiosXRS + 1)

                Dim num As Integer = 5
                If (((IndXRS - SaveIndXRS) + num) > NroDiiosXRS) Then num = NroDiiosXRS - (IndXRS - SaveIndXRS)

                EnviaComandoXRS("DL" + IndXRS.ToString.Trim + "," + num.ToString.Trim)
                IndXRS += num

                ActualizaBarraEstado((IndXRS - SaveIndXRS))
            Else
                Dim i As Integer

                Try
                    For i = ItemsXRS.Count - 1 To 0 Step -1 'ItemsXRS.Count - 1    ' Each itm As ListViewItem In ItemsXRS
                        If ItemsXRS.Item(i).SubItems(3).Text = NombreSesion Then
                            If ItemsXRS.Item(i).SubItems(4).Text <> "" Then
                                ContDIIOsRepXRS -= 1 'resta diios repetidos, si hay
                            End If

                            ItemsXRS.RemoveAt(i)
                            ContDIIOsXRS -= 1       'resta total diios (segun sesiones seleccionadas)
                        End If
                    Next
                Catch ex As Exception
                    'MsgBox(ex.Message)
                End Try

                lvXRS_DETALLE.BeginUpdate()
                lvXRS_DETALLE.Items.Clear()
                lvXRS_DETALLE.Items.AddRange(ItemsXRS.ToArray())
                lvXRS_DETALLE.EndUpdate()

                lblTotDiios.Text = (ContDIIOsXRS).ToString().Trim
                lblRepetidos.Text = (ContDIIOsRepXRS).ToString().Trim
                'pnlProcesa.Visible = False

                If ContDIIOsRepXRS > 0 Then PintarRepetidos(lvXRS_DETALLE, 4)

                If lblTotDiios.Text = "0" Then
                    btnProcesar.Enabled = False
                    btnEliminaRepetidos.Enabled = False
                Else
                    If lblRepetidos.Text = "0" Then btnEliminaRepetidos.Enabled = False
                End If

                NombreSesion = ""
            End If
        End If
    End Sub


    Private Sub OrdenaDatosGrilla(ByVal cl As Integer)
        Dim new_sorting_column As ColumnHeader = lvALLFLEX_XLS.Columns(cl)

        Cursor.Current = Cursors.WaitCursor

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        lvALLFLEX_XLS.ListViewItemSorter = New ListViewComparer(cl, sort_order)

        ' Sort.
        lvALLFLEX_XLS.Sort()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvALLFLEX_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvALLFLEX_XLS.ColumnClick
        OrdenaDatosGrilla(e.Column)
    End Sub


    Private Sub lvXRS_DETALLE_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvXRS_DETALLE.ColumnClick
        Cursor.Current = Cursors.WaitCursor


        Dim new_sorting_column As ColumnHeader = lvXRS_DETALLE.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        lvXRS_DETALLE.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        ' Sort.
        lvXRS_DETALLE.Sort()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvXRS_SESIONES_ColumnWidthChanging(sender As System.Object, e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lvXRS_SESIONES.ColumnWidthChanging
        'evitamos cambiar el tamaño de las columnas que tienen ancho 0
        If lvXRS_SESIONES.Columns(e.ColumnIndex).Width = 0 Then
            e.Cancel = True
            e.NewWidth = lvXRS_SESIONES.Columns(e.ColumnIndex).Width
        End If
    End Sub


    Private Sub frmBaston_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lblCentro.Text = Param2_CentroNom.Trim & " " & "(" & Param1_CentroCod & ")"
        'Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8

        cboTipoBaston.SelectedIndex = 0

        CboLlenaPuertos()

        If COMBaston <> "" Then
            cboTipoBaston.Text = TipoBaston
            cboPuertos.Text = COMBaston
        End If

        If QuitarOrigenExcel Then
            cboTipoBaston.Items.Remove("PLANILLA EXCEL")
        End If

        CheckForIllegalCrossThreadCalls = False
        lblProcesaFin.Text = ""
        lblProcesaFin.Visible = False
    End Sub

    Private Sub lvXRS_SESIONES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvXRS_SESIONES.SelectedIndexChanged

    End Sub
End Class