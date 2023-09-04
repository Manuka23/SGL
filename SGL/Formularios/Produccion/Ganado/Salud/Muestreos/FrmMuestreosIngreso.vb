



Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient



Public Class FrmMuestreosIngreso

    Public Param0_ModoIngreso As Integer           '1 = nuevo  /  2 = consulta partos
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_FechaMuestreo As DateTime
    Public Param4_TipoMuestreo As String
    Public Param5_Observacion As String
    Public Param6_TieneResultado As Boolean
    Public Param7_FechaResultado As Date
    Dim frmBastonV2 As New frmBastonV2


    Private ResultadoDiios As String()
    Private ResultadoValor As Integer()


    Private fec_estado_ As Date

    Private Sub LeeBaston()
        frmBastonV2 = New frmBastonV2

        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmMuestreosIngreso"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub



    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""

        Dim TotDiios As Integer

        Cursor.Current = Cursors.WaitCursor

        lvGanado.Items.Clear()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","

            Dim item As New ListViewItem((i + 1).ToString)    'nro

            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add(diio_)
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")

            If VerificaDIIOEnGrilla(-1, diio_) = True Then
                item.SubItems.Add("ERR / REPETIDO")
            Else
                item.SubItems.Add("ERR / NO EXISTE EN BD")
            End If

            lvGanado.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If

        TotDiios = BuscarDiiosBaston(strdiios_)

        Cursor.Current = Cursors.Default

        btnGrabar.Enabled = True

    End Sub


    Private Function GeneraStringDIIOs() As String
        GeneraStringDIIOs = ""

        Dim i As Integer = 0
        Dim str_ As String = ""
        Dim estado_ As String = ""

        For i = 0 To lvGanado.Items.Count - 1
            estado_ = lvGanado.Items(i).SubItems(11).Text.Trim

            If estado_ = "" Or Mid(estado_, 1, 3) = "MSJ" Then
                str_ = str_ + lvGanado.Items(i).SubItems(3).Text.ToString.Trim + ","
            End If
        Next

        If str_.Length > 0 Then
            str_ = Mid(str_, 1, str_.Length - 1)
        End If

        GeneraStringDIIOs = str_
    End Function



    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvGanado.Items.Count - 1
            If i <> pos_ Then
                If lvGanado.Items(i).SubItems(3).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function



    Private Function EstaEnStock(ByVal isvend_ As String, ByVal venfec_ As Date, ByVal isdesap_ As String, ByVal desfec_ As Date, ByVal ismue_ As String, ByVal muefec_ As Date) As String
        EstaEnStock = ""

        If isvend_ = "SI" Then
            EstaEnStock = "VENDIDO"
            fec_estado_ = venfec_
        End If

        If isdesap_ = "SI" Then
            EstaEnStock = "DESAPARECIDO"
            fec_estado_ = desfec_
        End If

        If ismue_ = "SI" Then
            EstaEnStock = "MUERTO"
            fec_estado_ = muefec_
        End If
    End Function


    'devuelve el nro de errores en los diios
    Private Function BuscarDiiosBaston(ByVal diios_ As String) As Integer
        BuscarDiiosBaston = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ListadoBaston", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvGanado.BeginUpdate()

        Label10.Text = "0"

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim diio_ As String = ""
        Dim est_ As String = ""
        Dim gndest_ As String = ""
        Dim tot_err As Integer = 0

        Dim f1, f2, f3 As Date

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    diio_ = rdr("GndCod").ToString.Trim

                    For i = 0 To lvGanado.Items.Count - 1
                        If lvGanado.Items(i).SubItems(3).Text.Trim = diio_ Then
                            lvGanado.Items(i).SubItems(7).Text = rdr("GndProNom").ToString.Trim
                            lvGanado.Items(i).SubItems(8).Text = rdr("GndEstadoProductivo").ToString.Trim
                            lvGanado.Items(i).SubItems(9).Text = rdr("GndEstadoReproductivo").ToString.Trim

                            f1 = Now
                            f2 = Now
                            f3 = Now
                            If Not IsDBNull(rdr("GndIsVendidoFecha")) Then f1 = rdr("GndIsVendidoFecha")
                            If Not IsDBNull(rdr("GndIsDesaparecidoFecha")) Then f1 = rdr("GndIsDesaparecidoFecha")
                            If Not IsDBNull(rdr("GndIsMuertoFecha")) Then f1 = rdr("GndIsMuertoFecha")

                            gndest_ = EstaEnStock(rdr("GndIsVendido").ToString.Trim, f1, _
                                                  rdr("GndIsDesaparecido").ToString.Trim, f2,
                                                  rdr("GndIsMuerto").ToString.Trim, f3)

                            est_ = lvGanado.Items(i).SubItems(11).Text

                            If VerificaDIIOEnGrilla(i, diio_) = True Then
                                est_ = "ERR / REPETIDO"
                            End If


                            If est_.Trim <> "" Then tot_err = tot_err + 1


                            lvGanado.Items(i).SubItems(11).Text = est_


                        End If
                    Next


                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        BuscarDiiosBaston = i

        Label10.Text = tot_err.ToString.Trim
        'lblTotSecados.Text = i.ToString.Trim
        lvGanado.EndUpdate()
    End Function




    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Private Sub ProcesaTipoMuestreoEncabezado(ByVal tmuest_ As String)
        If tmuest_.Contains("1") Then
            chkTBC.Checked = True
        End If

        If tmuest_.Contains("2") Then
            chkLEU.Checked = True
        End If

        If tmuest_.Contains("3") Then
            chkBRU.Checked = True
        End If
    End Sub


    Private Function VerificaResultadoMuestreo(ByVal cod_ As String, ByVal muestreo_ As String, ByVal result_ As Integer) As String
        VerificaResultadoMuestreo = ""

        If muestreo_.Contains(cod_) Then

            If result_ = 1 Then
                VerificaResultadoMuestreo = "POSITIVO"
            End If

            If result_ = 2 Then
                VerificaResultadoMuestreo = "NEGATIVO"
            End If

        End If
    End Function


    Private Function VerificaResultadoContraMuestra(ByVal result_ As Integer) As String
        VerificaResultadoContraMuestra = ""

        If result_ = 1 Then
            VerificaResultadoContraMuestra = "POSITIVO"
        End If

        If result_ = 2 Then
            VerificaResultadoContraMuestra = "NEGATIVO"
        End If

    End Function


    Public Sub BuscarDetalle()
        If cboCentros.Text.Trim = "" Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestreos_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_CodigoCentro)
        cmd.Parameters.AddWithValue("@Fecha", Param3_FechaMuestreo)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Label85.Text = "0"
        Label5.Text = "0"
        Label7.Text = "0"
        Label9.Text = "0"

        Dim i As Integer = 0
        Dim crias As Integer = 0
        Dim hembras As Integer = 0
        Dim sexadas As Integer = 0
        Dim tot_crias As Integer = 0
        Dim tot_hembras As Integer = 0
        Dim tot_sexadas As Integer = 0
        Dim tot_err As Integer = 0
        Dim save_diio As String = ""

        Dim cm_ As String
        Dim pos_ As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()

                    cm_ = ""

                    If Not IsDBNull(rdr("ResContraMuestra")) Then cm_ = VerificaResultadoContraMuestra(rdr("ResContraMuestra"))

                    If rdr("Diio").ToString.Trim <> save_diio Then
                        Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                        ''
                        item.SubItems.Add(rdr("Empresa").ToString.Trim)
                        item.SubItems.Add(rdr("Centro").ToString.Trim)
                        item.SubItems.Add(rdr("Diio").ToString.Trim)
                        ''
                        item.SubItems.Add(VerificaResultadoMuestreo("1", rdr("Muestreo").ToString.Trim, rdr("ResultadoMuestra").ToString.Trim))
                        item.SubItems.Add(VerificaResultadoMuestreo("2", rdr("Muestreo").ToString.Trim, rdr("ResultadoMuestra").ToString.Trim))
                        item.SubItems.Add(VerificaResultadoMuestreo("3", rdr("Muestreo").ToString.Trim, rdr("ResultadoMuestra").ToString.Trim))
                        ''
                        item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                        item.SubItems.Add(rdr("EstadoProductivo").ToString.Trim)
                        item.SubItems.Add(rdr("EstadoReproductivo").ToString.Trim)
                        ''
                        item.SubItems.Add(IIf(rdr("ContContraMuestra").ToString.Trim = "0", "", rdr("ContContraMuestra").ToString.Trim))
                        item.SubItems.Add(cm_)
                        ''
                        item.SubItems.Add("")       'estado
                        ''
                        lvGanado.Items.Add(item)

                        save_diio = rdr("Diio").ToString.Trim
                        i = i + 1
                    Else
                        If lvGanado.Items(i - 1).SubItems(4).Text.Trim = "" Then
                            lvGanado.Items(i - 1).SubItems(4).Text = VerificaResultadoMuestreo("1", rdr("Muestreo").ToString.Trim, rdr("ResultadoMuestra").ToString.Trim)
                        End If

                        If lvGanado.Items(i - 1).SubItems(5).Text.Trim = "" Then
                            lvGanado.Items(i - 1).SubItems(5).Text = VerificaResultadoMuestreo("2", rdr("Muestreo").ToString.Trim, rdr("ResultadoMuestra").ToString.Trim)
                        End If

                        If lvGanado.Items(i - 1).SubItems(6).Text.Trim = "" Then
                            lvGanado.Items(i - 1).SubItems(6).Text = VerificaResultadoMuestreo("3", rdr("Muestreo").ToString.Trim, rdr("ResultadoMuestra").ToString.Trim)
                        End If
                    End If

                    pos_ = lvGanado.Items.Count - 1
                    lvGanado.Items(pos_).UseItemStyleForSubItems = False

                    If lvGanado.Items(pos_).SubItems(4).Text.Contains("POSITIVO") Then
                        lvGanado.Items(pos_).SubItems(4).ForeColor = Color.Red
                    End If


                    If lvGanado.Items(pos_).SubItems(5).Text.Contains("POSITIVO") Then
                        lvGanado.Items(pos_).SubItems(5).ForeColor = Color.Red
                    End If

                    '
                    If lvGanado.Items(pos_).SubItems(6).Text.Contains("POSITIVO") Then
                        lvGanado.Items(pos_).SubItems(6).ForeColor = Color.Red
                    End If

                    If lvGanado.Items(pos_).SubItems(11).Text.Contains("POSITIVO") Then     'CONTRAMUESTRA
                        lvGanado.Items(pos_).SubItems(11).ForeColor = Color.Red
                    End If

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        lvGanado.EndUpdate()

        RecorreGrillaParaTotalesPositivos()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub RecorreGrillaParaTotalesPositivos()
        Dim i As Integer
        Dim tbc_positivo As Integer = 0
        Dim leu_positivo As Integer = 0
        Dim bru_positivo As Integer = 0

        For i = 0 To lvGanado.Items.Count - 1

            If lvGanado.Items(i).SubItems(4).Text.Contains("POSITIVO") Then tbc_positivo = tbc_positivo + 1
            If lvGanado.Items(i).SubItems(5).Text.Contains("POSITIVO") Then leu_positivo = leu_positivo + 1
            If lvGanado.Items(i).SubItems(6).Text.Contains("POSITIVO") Then bru_positivo = bru_positivo + 1

        Next


        Label85.Text = i.ToString.Trim
        Label5.Text = tbc_positivo.ToString.Trim
        Label7.Text = leu_positivo.ToString.Trim
        Label9.Text = bru_positivo.ToString.Trim
    End Sub


    Private Function GrabarMuestreo() As Boolean
        GrabarMuestreo = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestreos_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim diios_ As String = ""
        Dim tbc_, leu_, bru_ As Integer

        tbc_ = IIf(chkTBC.Checked = True, 1, 0)
        leu_ = IIf(chkLEU.Checked = True, 1, 0)
        bru_ = IIf(chkBRU.Checked = True, 1, 0)
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        diios_ = GeneraStringDIIOs()

        ''
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Observs", txtObservs.Text.Trim)
        cmd.Parameters.AddWithValue("@CheckTBC", tbc_)
        cmd.Parameters.AddWithValue("@CheckLEU", leu_)
        cmd.Parameters.AddWithValue("@CheckBRU", bru_)
        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@Protocolo", "")
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de secado


            GrabarMuestreo = True

        Catch ex As Exception
            If ex.Message.Contains("PRIMARY KEY") Then
                MsgBox("NO SE PUEDE GARABAR YA QUE EXISTEN DIIOS REPETIDOS, VERIFIQUE LA INFORMACION", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            End If

        End Try
    End Function


    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If dtpFecha.Value > Now Then
            If MsgBox("LA FECHA DE MUESTREO NO PUEDE SER MAYOR A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If


        If ValidaDiios = True Then
            If lvGanado.Items.Count = 0 Then
                If MsgBox("DEBE INGRESAR EL DETALLE DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

                Exit Function
            End If
        End If

        ValidacionesLocales = True
    End Function


    Private Function ValidacionesLocalesResultado(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocalesResultado = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If dtpFecha.Value > Now Then
            If MsgBox("LA FECHA DE MUESTREO NO PUEDE SER MAYOR A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        Dim f1 As DateTime = DateTime.Parse(Format(dtpFecha.Value, "dd-MM-yyyy"))
        Dim f2 As DateTime = DateTime.Parse(Format(dtpFechaResult.Value, "dd-MM-yyyy"))

        If f2 < f1 Then
            If MsgBox("LA FECHA DE RESULTADO NO PUEDE SER MAYOR A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        If ValidaDiios = True Then
            If lvGanado.Items.Count = 0 Then
                If MsgBox("DEBE INGRESAR EL DETALLE DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

                Exit Function
            End If
        End If

        ValidacionesLocalesResultado = True
    End Function


    Private Sub DetalleGanado()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvGanado.SelectedItems.Item(0).SubItems(3).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub ContraMuestra()
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim rtbc_ As String = lvGanado.SelectedItems(0).SubItems(4).Text
        Dim rleu_ As String = lvGanado.SelectedItems(0).SubItems(5).Text
        Dim rbru_ As String = lvGanado.SelectedItems(0).SubItems(6).Text

        With frmContraMuestras
            .Param1_CodigoCentro = Param1_CodigoCentro
            .Param2_NombreCentro = Param2_NombreCentro
            .Param3_FechaMuestreo = Param3_FechaMuestreo
            .Param4_TipoMuestreo = Param4_TipoMuestreo
            .Param5_DIIO = lvGanado.SelectedItems(0).SubItems(3).Text

            .Param6_TBC = False
            .Param7_LEU = False
            .Param8_BRU = False

            If rtbc_.Contains("POS") Then .Param6_TBC = True
            If rleu_.Contains("POS") Then .Param7_LEU = True
            If rbru_.Contains("POS") Then .Param8_BRU = True
            .ShowDialog()
        End With
    End Sub


    



    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If cboCentros.Text.Trim <> "" Then btnBaston.Enabled = True
        If lvGanado.Items.Count <= 0 Then Exit Sub

        lvGanado.Items.Clear()

        Label85.Text = "0"
        Label5.Text = "0"
        Label7.Text = "0"
        Label9.Text = "0"

        btnGrabar.Enabled = False
    End Sub


    Private Sub btnResultado_Click(sender As System.Object, e As System.EventArgs) Handles btnResultado.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        With frmMuestreosResultado
            .Param1_CodigoCentro = Param1_CodigoCentro
            .Param2_NombreCentro = Param2_NombreCentro
            .Param3_FechaMuestreo = Param3_FechaMuestreo
            .Param4_TipoMuestreo = Param4_TipoMuestreo
            ''
            .ShowDialog()
        End With

    End Sub



    Private Sub LeerResultadoDesdeExcel(ByVal file_ As String)
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

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

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        tbc_ = IIf(chkTBC.Checked = True, 1, 0)
        leu_ = IIf(chkLEU.Checked = True, 1, 0)
        bru_ = IIf(chkBRU.Checked = True, 1, 0)
        i = 0

        Libro = AppExcel.Workbooks.Open(file_) 'AppExcel.Workbooks.Add
        Hoja = Libro.Worksheets(1)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'LO PRIMERO ES VERIFICAR EL TIPO DE MESTREO
        NomTipoMuestreo = ""
        If IsNothing(Hoja.Cells(22, 4).Value) = False Then NomTipoMuestreo = Hoja.Cells(22, 4).Value.ToString.Trim.ToUpper

        Select Case NomTipoMuestreo
            Case ""
                If MsgBox("NO SE RECONOCE EL TIPO DE MUESTREO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Hoja = Nothing      'Descargamos los Objetos...
                Libro.Close()
                AppExcel.Quit()
                Exit Sub

            Case "TUBERCULOSIS"
                CodTipoMuestreo = 1

            Case "LEUCOSIS"
                CodTipoMuestreo = 2

            Case "BRUCELOSIS"
                CodTipoMuestreo = 3
        End Select

        If (CodTipoMuestreo = 1 And chkTBC.Checked = False) Or (CodTipoMuestreo = 2 And chkLEU.Checked = False) Or _
                (CodTipoMuestreo = 3 And chkBRU.Checked = False) Then
            If MsgBox("EL TIPO DE MUESTREO DEL ARCHIVO DE RESULTADO NO CONCUERDA CON EL DEL MUESTREO (" + NomTipoMuestreo + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            Hoja = Nothing      'Descargamos los Objetos...
            Libro.Close()
            AppExcel.Quit()
            Exit Sub
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'OBTENEMOS LOS DIIOS Y SUS RESULTADOS DE LA PLANILLA DE RESULTADO Y LOS DEJAMOS EN UN ARREGLO
        For lin = 1 To 5000
            diio1_ = ""

            result1_ = "0"

            If IsNothing(Hoja.Cells(lin, 1).Value) = False Then diio1_ = Hoja.Cells(lin, 2).Value.ToString.Trim
            If IsNothing(Hoja.Cells(lin, 2).Value) = False Then result1_ = Hoja.Cells(lin, 4).Value.ToString.Trim
            diio1OK = True


            'si encontramos el final, salimos
            If diio1_.ToUpper.Contains("FIN") = True Then
                Exit For
            End If

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

        Dim ErrorDiio As Integer    '0=no se encuentra el diio en la planilla de resultado, 1=ok, 3=error de proc. alm.
        Dim ResultPA As Integer
        Dim posresult As Integer
        Dim vret As Integer
        Dim mret As String

        con.Open()

        cmd.CommandType = Data.CommandType.StoredProcedure
        SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)


        For lin = 0 To lvGanado.Items.Count - 1

            ErrorDiio = 0
            mret = ""
            posresult = 0

            For i = 0 To UBound(ResultadoDiios)

                If ResultadoDiios(i) = lvGanado.Items(lin).SubItems(3).Text Then

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

                            ErrorDiio = 3
                            Exit For
                        End If

                        'si todo sale ok guardamos el nuevo codigo del grupo de secado
                        ErrorDiio = 1

                        If CodTipoMuestreo = 1 Then posresult = 4
                        If CodTipoMuestreo = 2 Then posresult = 5
                        If CodTipoMuestreo = 3 Then posresult = 6

                        If ResultadoValor(i) = 1 Then
                            lvGanado.Items(lin).UseItemStyleForSubItems = False
                            lvGanado.Items(lin).SubItems(posresult).ForeColor = Color.Red
                            lvGanado.Items(lin).SubItems(posresult).Text = "POSITIVO"
                        ElseIf ResultadoValor(i) = 2 Then
                            lvGanado.Items(lin).SubItems(posresult).Text = "NEGATIVO"
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                    End Try
                    '*********************************************************************************************************

                End If

            Next

            If ErrorDiio = 1 Then
                lvGanado.Items(lin).SubItems(11).Text = "OK"
            ElseIf ErrorDiio = 0 Then
                lvGanado.Items(lin).SubItems(11).Text = "No se encuentra resultado"
            Else
                lvGanado.Items(lin).SubItems(11).Text = mret
            End If
        Next


        SRVTRANS.Commit()


        con.Close()


        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContraMuestra.Click
        ContraMuestra()
    End Sub


    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub

    Private Sub mnuCopiarDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(3).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Sub mnuContraMuestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContraMuestra.Click
        ContraMuestra()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnBaston_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaston.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        LeeBaston()
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarMuestreo() = True Then


            Cursor.Current = Cursors.WaitCursor

            FrmMuestreos.LlenaMuestreos()



            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub FrmMuestreosIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()

        If Param0_ModoIngreso = 1 Then                  'si es un nuevo ingreso
            dtpFecha.Value = Now
            btnBaston.Enabled = False
            btnResultado.Visible = False
            btnContraMuestra.Visible = False
            btnExcel.Visible = False

        Else                                            'si consultamos
            cboCentros.Text = Param2_NombreCentro
            dtpFecha.Value = Param3_FechaMuestreo
            txtObservs.Text = Param5_Observacion
            dtpFechaResult.Value = Param7_FechaResultado

            ProcesaTipoMuestreoEncabezado(Param4_TipoMuestreo)

            cboCentros.Enabled = False
            chkTBC.Enabled = False
            chkLEU.Enabled = False
            chkBRU.Enabled = False
            dtpFecha.Enabled = False
            txtObservs.Enabled = False

            btnGrabar.Visible = False
            btnBaston.Visible = False

            btnResultado.Enabled = True
            btnContraMuestra.Visible = True

            btnResultado.Left = btnGrabar.Left
            btnContraMuestra.Left = btnBaston.Left + 5
            btnExcel.Left = btnContraMuestra.Left + btnContraMuestra.Width + 5


            BuscarDetalle()
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub


    Private Sub lvGanado_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tbc_ As String = lvGanado.SelectedItems.Item(0).SubItems(4).Text
        Dim leu_ As String = lvGanado.SelectedItems.Item(0).SubItems(5).Text
        Dim bru_ As String = lvGanado.SelectedItems.Item(0).SubItems(6).Text

        If Not tbc_.Contains("POSITIVO") And Not leu_.Contains("POSITIVO") And Not bru_.Contains("POSITIVO") Then
            btnContraMuestra.Enabled = False
            mnuContraMuestra.Enabled = False
        Else
            btnContraMuestra.Enabled = True
            mnuContraMuestra.Enabled = True
        End If
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(4, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL MUESTRAS" : tot(0, 1) = Label85.Text
        tot(1, 0) = "TOTAL TBC" : tot(1, 1) = Label5.Text
        tot(2, 0) = "TOTAL LEU" : tot(2, 1) = Label7.Text
        tot(3, 0) = "TOTAL BRU" : tot(3, 1) = Label9.Text

        ExportToExcelGrilla(lvGanado, tot)
    End Sub
End Class