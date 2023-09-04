
'Imports System.IO.Ports

Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports System.Threading



Public Class frmTrasladosIngreso

    Public EnEventoLoad As Boolean = True

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
    ''
    Public Param20_EsRecepcion As Boolean
    ''
    Public Param30_RutChofer As String
    Public Param31_NomChofer As String
    Public Param32_NomTransporte As String
    Public Param33_Patente1 As String
    Public Param34_Patente2 As String
    ''
    Public Param18_FechaSalida As DateTime
    'declaramos formulario baston

    Private ErrorCodGrl As Integer = 0
    Private ErrorDesGrl As String = ""

    Private Sub frmTrasladosIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaTipoMovimientos()
        CboLLenaCentrosDestinos()
        CboLLenaTipoTraslados()
        CboLLenaTipoGuiasTraslados()

        lblMsgGuia.Visible = False
        If Param0_ModoIngreso = 1 Then
            'Traslado nuevo
            CboLLenaCentros()

            If Param20_EsRecepcion = True Then
                cboMovimientos.Enabled = False
                cboCentros.Enabled = False
            End If

            Me.Text = "Nuevo Ingreso de Traslado"
            Label2.Text = "Total a Trasladar"
            dtpFecha.Value = Now
            lvDIIOS.MultiSelect = True
            btnExcel.Visible = False
            btnVerGrupoDiio.Visible = False
            cboCentros.Text = CentroPorDefecto()
            cboTiposGuia.SelectedIndex = 1
        Else
            btnEliminar.Enabled = False     'DESHABILITAMOS MOMENTANEAMENTE

            CboLLenaCentrosOrigenParaRecepcion()

            'edicion de Traslado
            Me.Text = "Edición de Traslado"
            Label2.Text = "Total de Traslados"
            lvDIIOS.MultiSelect = False

            cboMovimientos.Text = Param9_TipoMov

            cboTiposGuia.Visible = False
            cboTiposGuia.Enabled = False

            txtTipoGuia.Visible = True
            txtTipoGuia.Text = Param13_TipoGuia
            txtNroDoc.Text = Param6_Guia
            txtNroDoc.Enabled = False

            cboTipos.Text = Param11_TipoTraslado

            cboCentros.Text = BuscaNombreCentro(Param2_CodigoCentro)

            dtpFecha.Value = Param4_Fecha
            txtObservs.Text = Param5_Observs

            cboDestinos.Text = BuscaNombreCentro(Param7_CodigoDestino) 'Param8_NombreDestino
            txtNroFMA.Text = Param12_Pabco
            cboTiposGuia.Text = Param13_TipoGuia

            txtRutChofer.Text = Param30_RutChofer
            txtNomChofer.Text = Param31_NomChofer
            txtEmpTransporte.Text = Param32_NomTransporte
            txtPatente1.Text = Param33_Patente1
            txtPatente2.Text = Param34_Patente2

            txtRutChofer.Enabled = False
            txtNomChofer.Enabled = False
            txtEmpTransporte.Enabled = False
            txtPatente1.Enabled = False
            txtPatente2.Enabled = False

            cboMovimientos.Enabled = False
            cboCentros.Enabled = False
            cboDestinos.Enabled = False
            dtpFecha.Enabled = False
            txtObservs.Enabled = False
            cboTipos.Enabled = False
            txtNroFMA.Enabled = False

            btnFinalizar.Visible = False
            btnAgregar.Visible = False
            btnBastonLee.Visible = False
            btnEliminar.Visible = False
            btnExcel.Left = btnAgregar.Left
            btnVerGrupoDiio.Left = btnExcel.Left + btnExcel.Width + 2

            BuscarDetalleTraslado()
        End If

        EnEventoLoad = False
        btnFinalizar.Enabled = False
    End Sub
    Private Sub LeeBaston()

        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmTrasladosIngreso"
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

        lvDIIOS.Items.Clear()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","

            Dim item As New ListViewItem((i + 1).ToString)    'nro

            item.SubItems.Add(diio_)
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

            item.SubItems.Add("")
            item.SubItems.Add("")

            lvDIIOS.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If

        TotDiios = BuscarDiiosBaston(strdiios_)
        ContabilizaYValidaDIIOs()

        If TotDiios > 150 Then
            ErrorCodGrl = 999
            ErrorDesGrl = "No se puede realizar un traslado con mas de 150 animales. (Máx. permitido: 150)"
            MsgBox(ErrorDesGrl, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Mensaje - Error")
        Else
            ErrorCodGrl = 0
            ErrorDesGrl = ""
        End If
        Cursor.Current = Cursors.Default

    End Sub


    'devuelve el nro de errores en los diios
    Private Function BuscarDiiosBaston(ByVal diios_ As String) As Integer
        BuscarDiiosBaston = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_ListadoBaston", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)

        lvDIIOS.BeginUpdate()

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

                            lvDIIOS.Items(i).SubItems(2).Text = fec_
                            lvDIIOS.Items(i).SubItems(3).Text = rdr("GndProCod").ToString.Trim
                            lvDIIOS.Items(i).SubItems(4).Text = rdr("GndProNom").ToString.Trim
                            lvDIIOS.Items(i).SubItems(5).Text = rdr("GndEstadoProductivo").ToString.Trim
                            lvDIIOS.Items(i).SubItems(6).Text = rdr("GndEstadoReproductivo").ToString.Trim

                            If VerificaDIIOEnGrilla(i, diio_) = True Then
                                lvDIIOS.Items(i).SubItems(7).Text = "ERR / REPETIDO"
                            Else
                                est_ = ""

                                If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                                    est_ = "ERR / CENTRO"
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



                                If cboMovimientos.Text.Contains("TERNER") And Not rdr("GndProNom").ToString.Trim.Contains("TERNER") Then
                                    est_ = "ERR / CATEGORIA DEBE SER TERNEROS/AS"
                                End If

                                lvDIIOS.Items(i).SubItems(7).Text = est_
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

        lvDIIOS.EndUpdate()
    End Function

    Public Sub ContabilizaYValidaDIIOs()
        Dim i As Integer = 0
        Dim err_ As Integer = 0
        Dim estado_ As String = ""

        btnFinalizar.Enabled = False
        btnPrevisualizar.Enabled = False
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        For i = 0 To lvDIIOS.Items.Count - 1
            lvDIIOS.Items(i).Text = (i + 1).ToString.Trim
            estado_ = lvDIIOS.Items(i).SubItems(7).Text.Trim

            If Mid(estado_, 1, 3) = "ERR" Then
                err_ += 1
            End If
        Next

        lblTotTraslados.Text = i.ToString.Trim
        lblTotErrores.Text = err_.ToString.Trim
        If err_ > 0 Then
            lblTotErrores.ForeColor = Color.Red
        Else
            lblTotErrores.ForeColor = Color.Black
        End If

        If i > 150 Then
            ErrorCodGrl = 999
            ErrorDesGrl = "No se puede realizar un traslado con mas de 150 animales. (Máx. permitido: 150)"
            MsgBox(ErrorDesGrl, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Mensaje - Error")
        Else
            ErrorCodGrl = 0
            ErrorDesGrl = ""
        End If

        If err_ = 0 Then
            btnFinalizar.Enabled = True
            btnPrevisualizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
            btnPrevisualizar.Enabled = False
        End If
    End Sub


    Public Sub SumaTraslado()
        lblTotTraslados.Text = Str(Val(lblTotTraslados.Text) + 1).Trim
    End Sub

    Public Sub RestaTraslado()
        lblTotTraslados.Text = Str(Val(lblTotTraslados.Text) - 1).Trim
    End Sub

    Public Sub SumaEliminado()
        lblTotErrores.Text = Str(Val(lblTotErrores.Text) + 1).Trim
    End Sub

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub

    Private Sub CboLLenaCentrosOrigenParaRecepcion()
        If General.TrlsGnd_ListadoCentrosRecepcion.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TrlsGnd_ListadoCentrosRecepcion.NroRegistros - 1
            cboCentros.Items.Add(General.TrlsGnd_ListadoCentrosRecepcion.Nombre(i))
        Next
    End Sub

    Private Sub CboLLenaCentrosDestinos()
        If General.TrlsGnd_ListadoCentros.NroRegistros = 0 Then Exit Sub

        cboDestinos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TrlsGnd_ListadoCentros.NroRegistros - 1
            cboDestinos.Items.Add(General.TrlsGnd_ListadoCentros.Nombre(i))
        Next
    End Sub

    Private Sub CboLLenaTipoMovimientos()
        If General.TipoMovimientos.NroRegistros = 0 Then Exit Sub
        cboMovimientos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoMovimientos.NroRegistros - 1
            cboMovimientos.Items.Add(General.TipoMovimientos.Nombre(i))
        Next
    End Sub

    Private Sub CboLLenaTipoTraslados()
        If General.TipoTraslados.NroRegistros = 0 Then Exit Sub
        cboTipos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoTraslados.NroRegistros - 1
            cboTipos.Items.Add(General.TipoTraslados.Nombre(i))
        Next
    End Sub

    Private Sub CboLLenaTipoGuiasTraslados()
        If General.TipoGuiasTraslados.NroRegistros = 0 Then Exit Sub
        cboTiposGuia.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoGuiasTraslados.NroRegistros - 1
            cboTiposGuia.Items.Add(General.TipoGuiasTraslados.Nombre(i))
        Next

        cboTiposGuia.SelectedIndex = 0       'seleccionamos guia de despacho como documento por defecto
    End Sub

    Private Function BuscaNombreCentro(ByVal _text As String) As String
        BuscaNombreCentro = ""

        Dim i As Integer
        Dim nom As String = ""

        For i = 0 To General.TrlsGnd_ListadoCentros.Codigo.Length - 1
            If General.TrlsGnd_ListadoCentros.Codigo(i).Trim = _text Then
                nom = General.TrlsGnd_ListadoCentros.Nombre(i)
                Exit For
            End If
        Next

        BuscaNombreCentro = nom
    End Function

    Private Function GeneraStringDIIOs() As String
        GeneraStringDIIOs = ""

        Dim i As Integer = 0
        Dim str_ As String = ""
        Dim estado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            estado_ = lvDIIOS.Items(i).SubItems(7).Text.Trim

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
            estado_ = lvDIIOS.Items(i).SubItems(7).Text.Trim

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


        If cboMovimientos.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE MOVIMIENTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboMovimientos.Focus()
            Exit Function
        End If

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If cboDestinos.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN DESTINO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboDestinos.Focus()
            Exit Function
        End If

        If cboTiposGuia.Text.Contains("GUIA MANUAL") And Not IsNumeric(txtNroDoc.Text.Trim) Then
            If MsgBox("DEBE INGRESAR UNA GUIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroDoc.Focus()
            Exit Function
        End If

        If cboMovimientos.Text = "SALIDA" Then
            If cboDestinos.SelectedIndex = -1 Then
                If MsgBox("DEBE SELECCIONAR UN CENTRO DE DESTINO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                cboDestinos.Focus()
                Exit Function
            End If
        End If

        If cboMovimientos.Text.ToUpper = "SALIDA" And cboCentros.Text = cboDestinos.Text Then
            If MsgBox("NO SE PUEDE REALIZAR UN SALIDA CON EL MISMO DESTINO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboDestinos.Focus()
            Exit Function
        End If

        If cboTipos.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE TRASLADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTipos.Focus()
            Exit Function
        End If


        If Not cboMovimientos.Text.Contains("TERNER") And txtNroFMA.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UNA EL FMA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroFMA.Focus()
            Exit Function
        End If


        If cboMovimientos.Text = "ENTRADA" Then
            If dtpFecha.Value < Param18_FechaSalida Then
                If MsgBox("LA FECHA DE ENTRADA DEBE SER MAYOR O IGUAL A LA FECHA DE SALIDA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                dtpFecha.Focus()
                Exit Function
            End If
        End If

        If cboMovimientos.Text = "SALIDA" Then
            If txtRutChofer.Text = "" Then
                If MsgBox("DEBE INGRESAR EL RUT DEL CHOFER", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                txtRutChofer.Focus()
                Exit Function
            End If

            If Not txtRutChofer.Text.Contains(".") And Not txtRutChofer.Text.Contains("-") Then
                If MsgBox("RUT INCORRECTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                txtRutChofer.Focus()
                Exit Function
            End If

            If txtNomChofer.Text = "" Then
                If MsgBox("DEBE INGRESAR EL NOMBRE DEL CHOFER", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                txtNomChofer.Focus()
                Exit Function
            End If

        End If

        If ValidaDiios = True Then
            If lvDIIOS.Items.Count = 0 Then
                If MsgBox("DEBE INGRESAR EL DETALLE DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If
        End If

        ValidacionesLocales = True
    End Function

    Private Sub BuscarDetalleTraslado()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodTraslado", Param10_CodigoTraslado)

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvDIIOS.BeginUpdate()
        lvDIIOS.Items.Clear()
        lblTotTraslados.Text = "0"
        lblTotErrores.Text = "0"

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0
        Dim fec_ As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    fec_ = ""

                    If Not IsDBNull(rdr("GndFecNac")) Then
                        fec_ = Format(rdr("GndFecNac"), "dd-MM-yyyy")
                    End If
                    '
                    item.SubItems.Add(rdr("TDetDIIO").ToString.Trim)
                    item.SubItems.Add(fec_)
                    item.SubItems.Add(rdr("TDetCategoria").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(rdr("TDetEstProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("TDetEstReproductivo").ToString.Trim)
                    item.SubItems.Add("Grabado")

                    item.SubItems.Add(rdr("AbreviaRaza").ToString.Trim)
                    item.SubItems.Add(rdr("CategoSexo").ToString.Trim)

                    lvDIIOS.Items.Add(item)

                    i = i + 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        lvDIIOS.EndUpdate()
        lblTotTraslados.Text = i.ToString.Trim
        lblTotErrores.Text = e.ToString.Trim
    End Sub

    Public Sub BuscaSalidaParaRecepcion(ByVal EmpresaCod As Integer, ByVal CentroCod As Integer, ByVal TipoDoc As Integer, ByVal NroDoc As Integer)
        If cboMovimientos.Text <> "ENTRADA" Then Exit Sub

        If Not IsNumeric(NroDoc) Then Exit Sub
        txtNroDoc.Text = NroDoc.ToString

        BuscarTrasladoPorGuia(EmpresaCod, CentroCod, TipoDoc, NroDoc)
    End Sub
    Private Sub BuscarTrasladoPorGuia(ByVal EmpresaCod As Integer, ByVal CentroCod As Integer, ByVal TipoDoc As Integer, ByVal NroDoc As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_BuscarPorGuia", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", EmpresaCod)
        cmd.Parameters.AddWithValue("@CentroOrigen", CentroCod)
        cmd.Parameters.AddWithValue("@Guia", NroDoc)
        cmd.Parameters.AddWithValue("@TipoGuia", TipoDoc)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvDIIOS.BeginUpdate()
        lvDIIOS.Items.Clear()
        lblTotTraslados.Text = "0"
        lblTotErrores.Text = "0"

        Dim existe As Boolean = False
        Dim i As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If rdr("TrasEstado") = 2 Then
                        If MsgBox("LA SALIDA YA SE ENCUENTRA RECEPCIONADA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    'asignamos valores solo una vez
                    If existe = False Then
                        cboTiposGuia.Text = rdr("TGuiaNombre").ToString.Trim
                        cboCentros.Text = rdr("CentroOrigen").ToString.Trim 'BuscaNombreCentro(rdr("CentroOrigenCodigo").ToString.Trim) '
                        cboDestinos.Text = rdr("CentroDestino").ToString.Trim 'BuscaNombreCentro(rdr("CentroDestinoCodigo").ToString.Trim)
                        cboTipos.Text = rdr("TTipNombre").ToString.Trim
                        txtNroFMA.Text = rdr("TrasPabco").ToString.Trim
                        txtObservs.Text = rdr("TrasObservs").ToString.Trim
                    End If

                    existe = True

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("TDetDIIO").ToString.Trim)
                    item.SubItems.Add(Format(rdr("GndFecNac"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("GndProCod").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(rdr("TDetEstProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("TDetEstReproductivo").ToString.Trim)
                    item.SubItems.Add("")   'estado

                    item.SubItems.Add("")   'raza
                    item.SubItems.Add("")   'sexo

                    lvDIIOS.Items.Add(item)

                    Param18_FechaSalida = Format(rdr("TrasFecha"), "dd-MM-yyyy HH:mm") 'rdr("TrasFecha")

                    i = i + 1
                End While

                If existe = False Then
                    If MsgBox("LA SALIDA CON EL ORIGEN Y NRO DE GUIA ESPECIFICADO NO EXISTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    Exit Try
                Else
                    btnFinalizar.Enabled = True
                    btnPrevisualizar.Enabled = True
                    txtObservs.Focus()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        lvDIIOS.EndUpdate()
        lblTotTraslados.Text = i.ToString.Trim

    End Sub


    Private Function EliminarDIIOTraslado(ByVal diio_ As Integer) As Boolean
        EliminarDIIOTraslado = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_EliminarDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoTras", Param10_CodigoTraslado)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
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

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            EliminarDIIOTraslado = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub ConfirmarEliminacionDIIOTraslado()
        If lvDIIOS.Items.Count = 0 Then Exit Sub
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim estado_ As String = ""

        estado_ = lvDIIOS.SelectedItems(0).SubItems(7).Text.Trim

        If estado_ = "Grabado" Then
            If MsgBox("¿DESEA ELIMINAR EL DIIO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

                Dim diio_ As Integer = Val(lvDIIOS.SelectedItems.Item(0).SubItems(1).Text)

                If EliminarDIIOTraslado(diio_) = True Then
                    lvDIIOS.SelectedItems(0).SubItems(6).Text = "Eliminado (" + Format(Now, "dd-MM-yyyy") + ")"
                    SumaEliminado()
                End If
            End If
        Else
            If MsgBox("EL DIIO AUN NO SE HA GRABADO, ¿DESEA ELIMINARLO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
                lvDIIOS.SelectedItems.Item(0).Remove()
                RestaTraslado()

                If ExistenDIIOsSinGrabar() = False Then
                    btnFinalizar.Enabled = False
                    btnPrevisualizar.Enabled = False

                    cboMovimientos.Enabled = True
                    cboCentros.Enabled = True
                    dtpFecha.Enabled = True
                End If
            End If
        End If

        ContabilizaYValidaDIIOs()
    End Sub

    Private Sub Cerrar()
        If ExistenDIIOsSinGrabar() = True Then
            If MsgBox("EXISTEN DIIOS SIN GRABAR, ¿DESEA SALIR?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub



    Private Sub cboMovimientos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMovimientos.SelectedIndexChanged
        If EnEventoLoad Then Exit Sub

        txtNroFMA.Enabled = True

        If cboMovimientos.Text = "ENTRADA" Then
            CboLLenaCentrosOrigenParaRecepcion()
            'CboLLenaCentros()
            cboCentros.SelectedIndex = -1
            cboCentros.Enabled = True
            cboDestinos.Enabled = False
            cboTipos.Enabled = False
            txtNroFMA.Enabled = False
            cboDestinos.SelectedIndex = -1

            cboTipos.SelectedIndex = -1
            txtNroFMA.Text = ""
            txtObservs.Text = ""
            lvDIIOS.Items.Clear()

            btnAgregar.Enabled = False
            btnBastonLee.Enabled = False

        Else
            CboLLenaCentros()
            btnAgregar.Enabled = True
            btnBastonLee.Enabled = True

            cboCentros.Enabled = True
            cboDestinos.Enabled = True
            cboTipos.Enabled = True
            txtNroFMA.Enabled = True

            cboCentros.Text = CentroPorDefecto()
            cboDestinos.SelectedIndex = -1
            cboTipos.SelectedIndex = -1
            txtNroFMA.Text = ""
            txtObservs.Text = ""
            lvDIIOS.Items.Clear()


        End If

        If Param20_EsRecepcion Then cboCentros.Enabled = False

        btnFinalizar.Enabled = False
    End Sub

    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        InfoDIIO()
    End Sub

    Private Sub InfoDIIO()
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

    Private Sub mnuCopiarDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub

    Public Function BuscaCodigoTipoDocumentoTraslado(ByVal text As String) As Integer
        BuscaCodigoTipoDocumentoTraslado = 0

        Dim i As Integer
        Dim cod As Integer

        For i = 0 To General.TipoGuiasTraslados.Nombre.Length - 1
            If General.TipoGuiasTraslados.Nombre(i).Trim = text Then
                cod = General.TipoGuiasTraslados.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoTipoDocumentoTraslado = cod
    End Function

    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If ValidacionesLocales() = False Then Exit Sub
        If ErrorCodGrl > 0 Then
            MsgBox(ErrorDesGrl, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Mensaje - Error")
            Exit Sub
        End If
        Dim msg As String = ""
        msg = "¿ DESEA GRABAR LA INFORMACIÓN ? " + vbCrLf + vbCrLf + "UNA VEZ GRABADO EL DOCUMENTO NO PODRÁ SER ELEMINADO, SOLO ANULADO." + vbCrLf + vbCrLf + "SI ANULA LA GUIA (" + txtNroDoc.Text + ") EL CORRELATIVO NO PODRÁ SER UTILIZADO NUEVAMENTE." + vbCrLf + vbCrLf + "VERIFIQUE LA INFORMACIÓN ANTES DE GRABAR"


        'CONFIRMAR
        If MsgBox(msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then Exit Sub

        'buscamos codigo de documento de traslado
        Dim TipoDoc As Integer = BuscaCodigoTipoDocumentoTraslado(cboTiposGuia.Text)
        Dim mov_ As Integer = 0 : Dim cent_ As String = "" : Dim dest_ As String = "" : Dim tip_ As Integer = 0 : Dim tipguia_ As Integer = 0
        Dim diios_ As String = "" : Dim grabdet_ As Integer = 0 : Dim es_interno_ As Integer = 0

        mov_ = General.TipoMovimientos.Codigo(cboMovimientos.SelectedIndex)
        If mov_ = 3 Then mov_ = 1 'una salida de terneros (tipo 3) es iguaal a una salida normal (tipo 1)

        If cboMovimientos.Text = "ENTRADA" Then
            cent_ = General.TrlsGnd_ListadoCentrosRecepcion.Codigo(cboCentros.SelectedIndex)
        Else
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        End If

        If cboDestinos.SelectedIndex <> -1 Then dest_ = General.TrlsGnd_ListadoCentros.Codigo(cboDestinos.SelectedIndex)

        tip_ = General.TipoTraslados.Codigo(cboTipos.SelectedIndex)
        diios_ = GeneraStringDIIOs()
        tipguia_ = BuscaCodigoTipoGuiaTraslado(cboTiposGuia.Text)

        If cboMovimientos.Text.Contains("TERNER") Then es_interno_ = 1

        Dim NroDocManual As Integer = 0
        If txtNroDoc.Text.Trim <> "" Then NroDocManual = txtNroDoc.Text.Trim
        'grabamos traslado
        Dim NroGuia As Integer = MovGnd.GeneraMovGanado("Traslado", mov_, NroDocManual, txtNroFMA.Text.Trim, "", dtpFecha.Value, cent_, dest_, txtObservs.Text.Trim,
                                                           tip_, diios_, tipguia_, es_interno_, lvDIIOS, txtRutChofer.Text.Trim, txtNomChofer.Text.Trim,
                                                           "", txtEmpTransporte.Text.Trim, txtPatente1.Text.Trim, txtPatente2.Text.Trim) 'GrabarTraslado()

        If NroGuia > 0 And Empresa <> 76132957 Then
            If cboMovimientos.Text.ToUpper.Contains("SALIDA") Then
                msg = cboTiposGuia.Text + " NRO: " + NroGuia.ToString + " GENERADA --- OK ---" + vbCrLf + vbCrLf + "DEBE IMPRIMIR EL SIGUIENTE DOCUMENTO DE TRASLADO"

                If TipoDoc <> 52 Then msg = cboTiposGuia.Text + " NRO: " + NroGuia.ToString + " GENERADA --- OK ---"

                MsgBox(msg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Else
                MsgBox("RECEPCIÓN --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If

            'solo si la guia es lectrónica mostramos pdf de guia
            If cboMovimientos.Text.Contains("SALIDA") And TipoDoc = 52 Then
                lblMsgGuia.Visible = True
                Cursor.Current = Cursors.WaitCursor

                Try
                    Dim PdfNomSuite As String = SuiteElectronica.GeneraNombreArchivo(52, NroGuia, Empresa)
                    SuiteElectronica.MostrarPDFeSuite(PdfNomSuite)
                Catch ex As Exception
                    MsgBox("Error al mostrar la Guia en pantalla. " & ex.ToString, MsgBoxStyle.Critical, System.Windows.Forms.Application.ProductName)
                    Me.Close()
                    frmTraslados.LlenaGrillaTraslados()
                End Try

                Cursor.Current = Cursors.Default

            End If
            'despues de una grabacion correcta siempre activamos la edicion, ya que el encabezado ya esta creado
            Param0_ModoIngreso = 2

            'actualizamos grilla de traslados y cerramos ventana de ingreso
            If frmTraslados.Visible = True Then frmTraslados.LlenaGrillaTraslados()
            Me.Close()
            lblMsgGuia.Visible = False
        End If
    End Sub

    Private Sub lvDIIOS_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvDIIOS.MouseDoubleClick
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            InfoDIIO()
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        frmTrasladosIngresoDIIO.Param0_ModoIngreso = Param0_ModoIngreso
        frmTrasladosIngresoDIIO.Param2_NombreCentro = cboCentros.Text
        frmTrasladosIngresoDIIO.Param3_SalidaTerneros = False

        If cboMovimientos.Text = "ENTRADA" Then
            frmTrasladosIngresoDIIO.Param1_CodigoCentro = General.TrlsGnd_ListadoCentrosRecepcion.Codigo(cboCentros.SelectedIndex)
        Else
            frmTrasladosIngresoDIIO.Param1_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

            If cboMovimientos.Text.Contains("TERNER") Then
                frmTrasladosIngresoDIIO.Param3_SalidaTerneros = True    'indicamos que es una salida de terneros, para que se pueda validar la categoria
            End If
        End If

        frmTrasladosIngresoDIIO.Param4_CodigoDestino = General.TrlsGnd_ListadoCentros.Codigo(cboDestinos.SelectedIndex)
        frmTrasladosIngresoDIIO.Param5_NombreDestino = cboDestinos.Text
        frmTrasladosIngresoDIIO.Param6_DestinoEsAreaSeca = General.TrlsGnd_ListadoCentros.EsAreaSeca(cboDestinos.SelectedIndex)

        frmTrasladosIngresoDIIO.MdiParent = frmMAIN
        frmTrasladosIngresoDIIO.Show()
        frmTrasladosIngresoDIIO.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnPrevisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevisualizar.Click
        Cursor.Current = Cursors.WaitCursor

        Dim rt As New frmRptTraslado
        rt.NroGuia = Param6_Guia
        rt.Show()
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL TRASLADOS " : tot(0, 1) = lblTotTraslados.Text

        ExportToExcelGrilla(lvDIIOS, tot)
    End Sub

    Private Sub btnBastonLee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        LeeBaston()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        ConfirmarEliminacionDIIOTraslado()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub

    Private Sub frmTrasladosIngreso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text

        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If
        End If
    End Sub



    Private Sub lvDIIOS_ColumnWidthChanging(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lvDIIOS.ColumnWidthChanging
        If e.ColumnIndex = 7 Or e.ColumnIndex = 8 Then
            e.Cancel = True
            e.NewWidth = lvDIIOS.Columns(e.ColumnIndex).Width
        End If
    End Sub

    Private Sub cboTiposGuia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTiposGuia.SelectedIndexChanged

        If cboTiposGuia.Text.Contains("GUIA ELEC") Then
            'txtNroDoc.Text = ""
            txtNroDoc.Enabled = False
        Else
            txtNroDoc.Enabled = True
        End If
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If EnEventoLoad Then Exit Sub

        If Not cboMovimientos.Text.Contains("SALIDA TERNE") Then Exit Sub

        If cboCentros.SelectedIndex <> -1 Then
            Dim int_orig_ As Boolean = False
            int_orig_ = General.CentrosUsuario.EsInterno(cboCentros.SelectedIndex)

            If int_orig_ = False Then
                If MsgBox("SOLO LOS CAMPOS HC PUEDEN REALIZAR TRALADOS INTERNOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                If int_orig_ = False Then cboCentros.SelectedIndex = -1
            End If
        End If


    End Sub

    Private Sub cboDestinos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDestinos.SelectedIndexChanged
        If EnEventoLoad Then Exit Sub

        If Not cboMovimientos.Text.Contains("SALIDA TERNE") Then Exit Sub

        If cboDestinos.SelectedIndex <> -1 Then
            Dim int_dest_ As String = False
            int_dest_ = General.TrlsGnd_ListadoCentros.EsInterno(cboDestinos.SelectedIndex)

            If int_dest_ = False Then
                If MsgBox("SOLO LOS CAMPOS HC PUEDEN REALIZAR TRALADOS INTERNOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                If int_dest_ = False Then cboDestinos.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub btnVerGrupoDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerGrupoDiio.Click
        Dim diios As String = ""

        For Each lv As ListViewItem In lvDIIOS.Items
            diios = diios + lv.SubItems(1).Text + ","
        Next

        If diios.EndsWith(",") Then
            diios = diios.Substring(0, diios.Length - 1)
        End If

        Dim cd As New frmConsultaGeneralDIIOs

        cd.txtDIIOs.Text = diios
        cd.MdiParent = frmMAIN
        cd.Show()
        cd.BringToFront()

        cd.BuscarDatos()
    End Sub

    Private Sub checkNumeric_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDoc.KeyPress, txtNroFMA.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtRutChofer_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRutChofer.LostFocus
        txtRutChofer.Text = FormateaRUTGP(txtRutChofer.Text)
    End Sub

    Private Sub txtRutChofer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRutChofer.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) And (UCase(e.KeyChar) <> "K") Then
            e.Handled = True
        End If
    End Sub

    Private Sub cboTipos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipos.SelectedIndexChanged
        txtNroFMA.Focus()
    End Sub

    Private Sub lblMsgGuia_Click(sender As Object, e As EventArgs) Handles lblMsgGuia.Click

    End Sub
End Class