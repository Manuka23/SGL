
'Imports System.IO.Ports

Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel



Public Class frmTrasladosRecepcionMasiva

    'Public CodigoTraslado As Integer = 0
    Private fntraslados As New fnTrasladosCargaMasiva
    Public Param0_ModoIngreso As Integer        '1=nuevo  /  2=edicion  / 3=nuevo (menu recepcion)
    Public Param1_Empresa As Integer
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_Fecha As String
    Public Param5_Observs As String
    Public Param6_Guia As String
    Public Param7_CodigoDestino As String
    Public Param8_NombreDestino As String
    Public Param9_TipoMov As String
    Public Param10_CodigoTraslado As Integer
    Public Param11_TipoTraslado As String
    Public Param12_Pabco As String
    Public Param13_TipoGuia As String              '21=guia despacho / 400=guia interna
    '
    'Public Param13_EmpRut As String
    'Public Param14_GDPCod As String
    'Public Param15_TipGDPCod As String
    'Public Param16_AuxOCod As String
    'Public Param17_AuxOSucCod As String
    '
    Public Param18_FechaSalida As DateTime


    'declaramos formulario baston


    'Public FechaSalida As DateTime



    Private Sub LeeBaston()


        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboDestinos.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboDestinos.Text
        frmBastonV2.Param3_Formulario = "frmTrasladosRecepcionMasiva"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing

        ContabilizaYValidaDIIOs()
    End Sub



    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        'Dim inichk_ As Integer = lvDIIOS.Items.Count '- 1
        Dim TotDiios As Integer

        Cursor.Current = Cursors.WaitCursor

        lvDIIOS.Items.Clear()
        fntraslados.DtExcelCrear()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","
            fntraslados.DtExcel(diio_)
            Dim item As New ListViewItem((i + 1).ToString)    'nro
            item.SubItems.Add(diio_)
            item.SubItems.Add("")
            item.SubItems.Add("")
            If VerificaDIIOEnGrilla(-1, diio_) = True Then
                item.SubItems.Add("ERR / REPETIDO")
            Else
                item.SubItems.Add("OK")
            End If

            lvDIIOS.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If
        Dim cent_ As String = General.CentrosUsuario.Codigo(cboDestinos.SelectedIndex)
        TotDiios = BuscarDiiosBaston(strdiios_, cent_)
        'ContabilizaYValidaDIIOs()
        fntraslados.Consulta(dtpFecha.Value, cent_)
        Cursor.Current = Cursors.Default
        fntraslados.VaciaDatatable()
    End Sub


    'devuelve el nro de errores en los diios
    Private Function BuscarDiiosBaston(ByVal diios_ As String, ByVal Centro As String) As Integer
        BuscarDiiosBaston = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_ListadoBastonRecepMasiva", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        'Dim diios_ As String = ""
        'diios_ = GeneraStringDIIOs()
        cmd.Parameters.AddWithValue("@Destino", Centro)
        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvDIIOS.BeginUpdate()
        'lvDIIOS.Items.Clear()
        'Label85.Text = "0"

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim diio_ As String = ""
        Dim est_ As String = ""
        Dim fec_ As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    diio_ = rdr("GndCod").ToString.Trim

                    For i = 0 To lvDIIOS.Items.Count - 1
                        If lvDIIOS.Items(i).SubItems(1).Text.Trim = diio_ Then
                            fec_ = ""

                            If Not IsDBNull(rdr("GndFecNac")) Then
                                fec_ = Format(rdr("GndFecNac"), "dd-MM-yyyy")
                            End If

                            lvDIIOS.Items(i).SubItems(2).Text = rdr("CenDesCor").ToString.Trim
                            lvDIIOS.Items(i).SubItems(3).Text = rdr("TrasGuia").ToString.Trim

                            If VerificaDIIOEnGrilla(i, diio_) = True Then
                                lvDIIOS.Items(i).SubItems(4).Text = "ERR / REPETIDO"
                            Else
                                est_ = ""

                                If rdr("GndCenCod").ToString.Trim = General.CentrosUsuario.Codigo(cboDestinos.SelectedIndex) Then
                                    est_ = "ERR / ANIMAL YA EXISTE EN EL DESTINO (" + rdr("CentroDestino").ToString.Trim + ")"
                                End If

                                If rdr("TrasDestino").ToString.Trim = "" Then
                                    est_ = "ERR / ANIMAL NO EXISTE EN UN TRASLADO -- EN TRASNSITO --"
                                Else
                                    If rdr("TrasDestino").ToString.Trim <> General.CentrosUsuario.Codigo(cboDestinos.SelectedIndex) Then
                                        est_ = "ERR / DESTINO NO CONCUERDA (" + rdr("CentroDestino").ToString.Trim + ")"
                                    End If
                                End If

                                If rdr("GndIsVendido").ToString.Trim = "SI" Then
                                    est_ = "ERR / VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy")
                                End If

                                If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                                    est_ = "ERR / MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy")
                                End If

                                If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                                    est_ = "ERR / DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy")
                                End If


                                lvDIIOS.Items(i).SubItems(4).Text = est_
                            End If

                        End If
                    Next

                    'i = i + 1
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

        'lblTotSecados.Text = i.ToString.Trim
        lvDIIOS.EndUpdate()
    End Function




    Public Sub ContabilizaYValidaDIIOs()
        Dim i As Integer = 0
        'Dim totsec_ As Integer = 0
        Dim err_ As Integer = 0
        Dim estado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            lvDIIOS.Items(i).Text = (i + 1).ToString.Trim
            estado_ = lvDIIOS.Items(i).SubItems(4).Text.Trim

            If estado_ <> "OK" Then
                err_ += 1
            End If
        Next

        lblTotTraslados.Text = i.ToString.Trim
        lblTotErrores.Text = err_.ToString.Trim

        If lvDIIOS.Items.Count = 0 Then
            btnFinalizar.Enabled = False
            Exit Sub
        End If


        If err_ = 0 Then
            btnFinalizar.Enabled = True
            'btnPrevisualizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
            'btnPrevisualizar.Enabled = False
        End If
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboDestinos.Items.Clear()
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboDestinos.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Private Function GeneraStringDIIOs() As String
        GeneraStringDIIOs = ""

        Dim i As Integer = 0
        Dim str_ As String = ""
        Dim estado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            estado_ = lvDIIOS.Items(i).SubItems(4).Text.Trim

            If estado_ = "" Or Mid(estado_, 1, 3) = "MSJ" Then
                str_ = str_ + lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim + ","
            End If
        Next

        If str_.Length > 0 Then
            str_ = Mid(str_, 1, str_.Length - 1)
        End If

        GeneraStringDIIOs = str_
    End Function


    Private Function ExistenDIIOsSinGrabar() As Boolean
        ExistenDIIOsSinGrabar = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False
        Dim estado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            estado_ = lvDIIOS.Items(i).SubItems(4).Text.Trim

            If estado_ = "" Or Mid(estado_, 1, 3) = "MSJ" Then
                existe_ = True
                Exit For
            End If
        Next

        ExistenDIIOsSinGrabar = existe_
    End Function


    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvDIIOS.Items.Count - 1
            If i <> pos_ Then
                If lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function




    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False

        Dim num As Integer
        num = lvDIIOS.Items.Count.ToString
        For i = 0 To num - 1
            If lvDIIOS.Items(i).SubItems(4).Text.Trim <> "OK" Then
                If MsgBox("DEBE ELIMINAR LOS ERRORES PARA CONTINUAR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    Exit Function
                End If
            End If
        Next

        If cboDestinos.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboDestinos.Focus()
            Exit Function
        End If

        'If txtGuia.Text.Trim = "" Then
        '    If MsgBox("DEBE INGRESAR UNA GUIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtGuia.Focus()
        '    Exit Function
        'End If

        'If cboMovimientos.Text = "SALIDA" Then
        '    If cboDestinos.SelectedIndex = -1 Then
        '        If MsgBox("DEBE SELECCIONAR UN CENTRO DE DESTINO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '        End If
        '        cboDestinos.Focus()
        '        Exit Function
        '    End If
        'End If

        'If cboMovimientos.Text.ToUpper = "SALIDA" And cboCentros.Text = cboDestinos.Text Then
        '    If MsgBox("NO SE PUEDE REALIZAR UN SALIDA CON EL MISMO DESTINO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboDestinos.Focus()
        '    Exit Function
        'End If

        'If cboTipos.SelectedIndex = -1 Then
        '    If MsgBox("DEBE SELECCIONAR UN TIPO DE TRASLADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboTipos.Focus()
        '    Exit Function
        'End If

        'If txtPabco.Text.Trim = "" Then
        '    If MsgBox("DEBE INGRESAR UNA NRO DE PABCO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtPabco.Focus()
        '    Exit Function
        'End If


        'If cboMovimientos.Text = "ENTRADA" Then
        '    If dtpFecha.Value < Param18_FechaSalida Then
        '        If MsgBox("LA FECHA DE ENTRADA DEBE SER MAYOR O IGUAL A LA FECHA DE SALIDA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '        End If
        '        dtpFecha.Focus()
        '        Exit Function
        '    End If
        'End If

        'If ExistenDIIOsSinGrabar() = False Then
        '    If MsgBox("NO EXISTEN SECADOS PENDIENTES", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboCentros.Focus()
        '    Exit Function
        'End If

        'If ValidaDiios = True Then
        If lvDIIOS.Items.Count = 0 Then
            If MsgBox("DEBE INGRESAR EL DETALLE DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            'cboCondiciones.Focus()
            Exit Function
        End If
        'End If

        ValidacionesLocales = True
    End Function


   


    'Private Function GrabarRecepcionMasiva() As Boolean
    '    GrabarRecepcionMasiva = False

    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spTraslados_GrabarRecepcionMasiva", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    Dim mov_ As Integer = 2
    '    Dim cent_ As String = General.Centros.Codigo(cboDestinos.SelectedIndex)
    '    Dim dest_ As String = ""
    '    Dim tip_ As Integer = 21
    '    Dim tipguia_ As Integer = 21
    '    Dim diio_ As String = ""
    '    Dim grabdet_ As Integer = 0


    '    'If cboDestinos.SelectedIndex <> -1 Then dest_ = General.Centros.Codigo(cboDestinos.SelectedIndex)
    '    'tip_ = General.TipoTraslados.Codigo(cboTipos.SelectedIndex)
    '    'diios_ = GeneraStringDIIOs()
    '    'tipguia_ = General.TipoGuiasTraslados.Codigo(cboTiposGuia.SelectedIndex)
    '    'grabdet_ = IIf(ExistenDIIOsSinGrabar() = True, 1, 0)

    '    ''
    '    'cmd.Parameters.AddWithValue("@ModoIngreso", Param0_ModoIngreso)
    '    'cmd.Parameters.AddWithValue("@SERVIDOR", TipoSERVIDOR)
    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@Movimiento", mov_)
    '    cmd.Parameters.AddWithValue("@Destino", dest_)
    '    cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
    '    'cmd.Parameters.AddWithValue("@Observs", txtObservs.Text.Trim)
    '    ''
    '    cmd.Parameters.AddWithValue("@DIIO", diio_)
    '    ''
    '    cmd.Parameters.AddWithValue("@TipoGuia", tipguia_)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)
    '    '
    '    cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
    '    cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

    '    Try
    '        con.Open()

    '        Dim Result As Integer = cmd.ExecuteNonQuery()

    '        Dim vret As Integer = cmd.Parameters("@RetValor").Value
    '        Dim mret As String = cmd.Parameters("@RetMensage").Value

    '        ''verificamos error con un valor igual a -1
    '        If vret <> 0 Then
    '            If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
    '            End If
    '            Exit Function
    '        End If

    '        ''si todo sale ok guardamos el nuevo codigo del grupo de Traslado

    '        'CodigoTraslado = vret

    '        'despues de una grabacion correcta siempre activamos la edicion, ya que el encabezado ya esta creado
    '        Param0_ModoIngreso = 2

    '        GrabarRecepcionMasiva = True
    '        'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

    '        'MsgBox(mret)


    '        'ValidarUsuario = True
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
    '    End Try
    'End Function



    Private Function FinalizarRecepcionMasiva() As Boolean
        FinalizarRecepcionMasiva = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_GrabarRecepcionMasiva", con)
        Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        Dim cent_ As String = ""
        Dim diio_ As String = ""
        Dim i As Integer = 0
        ''
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean = False

        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        cent_ = General.CentrosUsuario.Codigo(cboDestinos.SelectedIndex)

        For i = 0 To lvDIIOS.Items.Count - 1

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Movimiento", 2)
            cmd.Parameters.AddWithValue("@Destino", cent_)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)

            cmd.Parameters.AddWithValue("@DIIO", lvDIIOS.Items(i).SubItems(1).Text)
            ''
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            '
            cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

            Try
                cmd.Transaction = SRVTRANS
                Result = cmd.ExecuteNonQuery()

                vret = cmd.Parameters("@RetValor").Value
                mret = cmd.Parameters("@RetMensage").Value

                ''verificamos error con un valor igual a -1
                If vret <> 0 Then

                    lvDIIOS.Items(i).SubItems(4).Text = mret   'estado
                    HayError = True

                Else
                    lvDIIOS.Items(i).SubItems(4).Text = "OK"
                End If


            Catch ex As Exception
                lvDIIOS.Items(i).SubItems(4).Text = ex.Message     'estado

            End Try

        Next

        If HayError = False Then
            SRVTRANS.Commit()
            FinalizarRecepcionMasiva = True
        Else
            SRVTRANS.Rollback()
            FinalizarRecepcionMasiva = False

            If MsgBox("RECEPCIÓN CON ERRORES, VERIFIQUE LA COLUMNA ESTADO" + vbCrLf + vbCrLf + "RECEPCION -- NO REALIZADA --", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
        End If

        con.Close()
        Cursor.Current = Cursors.Default
    End Function




    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub




    Private Sub DetalleGanado()
        If lvDIIOS.Items.Count = 0 Then Exit Sub
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvDIIOS.SelectedItems.Item(0).SubItems(1).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub



    Private Sub mnuVerDetalle_Click(sender As System.Object, e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub


    Private Sub mnuCopiarDiio_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub





    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnFinalizar.Click
        If ValidacionesLocales() = False Then Exit Sub
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If FinalizarRecepcionMasiva() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If

            Cursor.Current = Cursors.WaitCursor
            frmTraslados.LlenaGrillaTraslados()
            Me.Close()
            Cursor.Current = Cursors.Default
        End If
    End Sub



    Private Sub lvDIIOS_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvDIIOS.MouseDoubleClick
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub



    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL TRASLADOS " : tot(0, 1) = lblTotTraslados.Text

        ExportToExcelGrilla(lvDIIOS, tot)
    End Sub


    Private Sub btnBastonLee_Click(sender As System.Object, e As System.EventArgs) Handles btnBastonLee.Click
        LeeBaston()
    End Sub



    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub



    Private Sub frmTrasladosRecepcionMasiva_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If

            'If e.KeyCode = Keys.V Then
            '    MsgBox("chao")
            'End If

        End If
    End Sub


    Private Sub frmTrasladosRecepcionMasiva_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        btnFinalizar.Enabled = False
        CboLLenaCentros()

        cboDestinos.Text = CentroPorDefecto()
        dtpFecha.Value = Now
    End Sub


    

    Private Sub cboDestinos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDestinos.SelectedIndexChanged
        lvDIIOS.Items.Clear()
    End Sub


    Private Sub QuitarDiiosSeleccionados()
        If MsgBox("¿DESEA -- QUITAR -- LOS DIIOS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            For Each it As ListViewItem In lvDIIOS.SelectedItems
                lvDIIOS.Items.Remove(it)
            Next

            ContabilizaYValidaDIIOs()
        End If
    End Sub


    Private Sub QuitarDiiosConErrores()
        If MsgBox("¿DESEA -- QUITAR -- LOS DIIOS CON ERRORES?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            For Each it As ListViewItem In lvDIIOS.Items
                If it.SubItems(4).Text <> "OK" Then
                    lvDIIOS.Items.Remove(it)
                End If
            Next

            ContabilizaYValidaDIIOs()
        End If
    End Sub


    Private Sub lvDIIOS_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles lvDIIOS.KeyDown
        'If e.KeyCode = Keys.Delete Then
        'QuitarDiiosSeleccionados()
        'End If
    End Sub


    Private Sub btnEliminarSel_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarSel.Click
        QuitarDiiosSeleccionados()
    End Sub


    Private Sub btnEliminarErr_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarErr.Click
        QuitarDiiosConErrores()
    End Sub
End Class