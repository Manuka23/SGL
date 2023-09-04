Imports System.Data.SqlClient
Imports System.Threading

Public Class frmVentas2Ingreso


    Public Param0_ModoIngreso As Integer        '1=nuevo  /  2=edicion
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_Fecha As DateTime
    Public Param5_Observs As String
    Public Param6_NumeroVenta As Integer
    Public Param7_NroGuia As Integer
    Public Param8_TipoDoc As String
    Public Param9_Estado As String
    Public Param11_FMA As String
    Public Param13_Cliente As String
    Public Param14_CodigoEstado As Integer
    ''
    Public Param30_RutChofer As String
    Public Param31_NomChofer As String
    Public Param32_NomTransporte As String
    Public Param33_Patente1 As String
    Public Param34_Patente2 As String
    Public UsuarioVenta As String
    Public VentaDirecta As Integer
    Public UsuarioCreacion As String
    Public UsuarioActualizacion As String
    Public FechaCreacion As String
    Public FechaActualizacion As String

    Private fdats As frmVentasCausa
    Private ErrorCodGrl As Integer = 0
    Private ErrorDesGrl As String = ""

    Dim FechaVentaIni As String
    Dim CantidadDiios As Integer


#Region "LOAD"
    Private Sub FrmVentaIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 10
        Me.KeyPreview = True

        CboLLenaCentros()
        CboLLenaClientes()
        CboLLenaTiposDocumentosVentas()
        VentaBuscarPersonal()

        TipoSalida()
        TipoCausa()

        lblMsgGuia.Visible = False
        cboTiposDoc.Text = "GUIA MANUAL"

        If VentaDirecta = 0 Then
            lblTipoVenta.Text = "SIN requerimiento de venta asociado. Ingreso directo en SGL"
        Else
            lblTipoVenta.Text = "N° Requerimiento de Venta: " + VentaDirecta.ToString()
        End If

        If Param0_ModoIngreso = 1 Then
            'NUEVO
            Me.Text = "INGRESO DE VENTAS"
            Label12.Text = "TOTAL A VENDER"

            lblConErrores.Visible = True
            lblTotErrores.Visible = True
            lblUsuario.Visible = False

            lblVenta.MultiSelect = True
            btnFinalizar.Enabled = False
            btnEliminar.Enabled = False

        Else
            'Visualizacion
            Me.Text = "DETALLE DE VENTAS"
            Label12.Text = "TOTAL VENTAS"

            lblUsuario.Text = "CREADOR: " + UsuarioCreacion + " " + FechaCreacion

            If UsuarioActualizacion <> "" Then
                lblUsuario.Text = lblUsuario.Text + "             MODIFICADO POR: " + UsuarioActualizacion + " " + FechaActualizacion
            End If

            lblVenta.MultiSelect = False

            cboCentros.Text = Param3_NombreCentro
            dtpFecha.Value = Param4_Fecha
            txtNroFMA.Text = IIf(Param11_FMA > 0, Param11_FMA, "")
            txtNroDoc.Text = IIf(Param7_NroGuia > 0, Param7_NroGuia, "")
            cboTiposDoc.Text = Param8_TipoDoc
            txtObservs.Text = Param5_Observs

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

            cboClientes.Text = BuscaNombreRutCliente(Param13_Cliente)
            txtEstado.Text = Param9_Estado
            txtNroFMA.Enabled = False
            cboCentros.Enabled = False
            cboTiposDoc.Enabled = False
            txtNroDoc.Enabled = False
            cboClientes.Enabled = False
            txtObservs.Enabled = False

            btnAgregar.Visible = False
            btnBastonLee.Visible = False
            btnAsignar.Visible = False

            If UsuarioVenta = 1 Then
                btnEliminar.Visible = True
                btnEliminar.Enabled = True
                dtpFecha.Enabled = True
                btnActulizar.Visible = True
                GroupBox2.Enabled = True
            Else
                btnEliminar.Visible = False
                btnEliminar.Enabled = False
                dtpFecha.Enabled = False
                btnActulizar.Visible = False
                GroupBox2.Enabled = False
            End If
            btnFinalizar.Visible = False

            Select Case Param14_CodigoEstado
                Case 1  'EN INGRESO
                    ''
                    btnBastonLee.Visible = False
                    ''
                    btnImprimir.Left = btnExcel.Left
                    btnExcel.Left = btnFinalizar.Left
                    btnFinalizar.Left = btnEliminar.Left
                    btnEliminar.Left = btnAsignar.Left
                    btnAsignar.Left = btnBastonLee.Left

                Case 2  'POR FINALIZAR (REQ.VTA.)

                    txtNroFMA.Enabled = True
                    txtRutChofer.Enabled = True
                    txtNomChofer.Enabled = True
                    txtEmpTransporte.Enabled = True
                    txtPatente1.Enabled = True
                    txtPatente2.Enabled = True
                    txtObservs.Enabled = True
                    btnFinalizar.Visible = True
                    If PerfilUsuario = 4 Then 'GERENCIA TECNICA
                        dtpFecha.Enabled = True
                        cboClientes.Enabled = True
                        btnEliminar.Visible = True
                        btnEliminar.Enabled = True
                    End If
                    If PerfilUsuario = 3 Or PerfilUsuario = 2 Then 'SUPERVISOR, ADM. CENTRO 
                        btnEliminar.Visible = True
                        btnEliminar.Enabled = True
                    End If
                    ''
                    btnImprimir.Left = btnEliminar.Left
                    btnExcel.Left = btnAsignar.Left
                    btnFinalizar.Left = btnBastonLee.Left

                Case 3  'FINALIZADA - SOLO VISUALIZA
                    btnImprimir.Left = btnBastonLee.Left
                    btnExcel.Left = btnAgregar.Left
                    btnEliminar.Visible = False
                    btnActulizar.Visible = False
                    txtDiioAgregar.Enabled = False
                    cboTipoCausa.Enabled = False
                    cboTipoVenta.Enabled = False
            End Select

            BuscarDetalle()
        End If
    End Sub

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub

    Private Sub CboLLenaClientes()
        If General.Clientes.NroRegistros = 0 Then Exit Sub
        cboClientes.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Clientes.NroRegistros - 1
            cboClientes.Items.Add(General.Clientes.NombreRut(i))
        Next
    End Sub

    Private Sub CboLLenaTiposDocumentosVentas()
        If General.TipoDocumentosVentas.NroRegistros = 0 Then Exit Sub
        cboTiposDoc.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoDocumentosVentas.NroRegistros - 1

            cboTiposDoc.Items.Add(General.TipoDocumentosVentas.Nombre(i))
        Next
    End Sub

    Private Sub BuscarDetalle()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVentas_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param2_CodigoCentro)
        cmd.Parameters.AddWithValue("@NroVta", Param6_NumeroVenta)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lblVenta.BeginUpdate()
        lblVenta.Items.Clear()
        lblTotalVentas.Text = "0"
        Label3.Text = "0"

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()


                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("VDetDIIO").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("VDetCategoria").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(rdr("VDetEstProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("VDetEstReproductivo").ToString.Trim)
                    item.SubItems.Add(rdr("VDetTipoVenta").ToString.Trim)
                    item.SubItems.Add(rdr("TVtaNombre").ToString.Trim)
                    item.SubItems.Add(rdr("VDetCausal").ToString.Trim)
                    item.SubItems.Add(rdr("CauNombre").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("VDetVeterinario").ToString.Trim)
                    item.SubItems.Add(rdr("VDetNroCertific").ToString.Trim)


                    lblVenta.Items.Add(item)

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

        lblVenta.EndUpdate()
        lblTotalVentas.Text = i.ToString.Trim
        Label3.Text = e.ToString.Trim
    End Sub

    Private Function BuscaNombreRutCliente(ByVal clte_nom As String) As String
        'Se utiliza para cuando se ingresa a la pantalla en modo de VISUALIZACION.
        BuscaNombreRutCliente = 0

        Dim i As Integer
        Dim cod As String = ""

        For i = 0 To General.Clientes.Nombre.Length - 1

            If General.Clientes.Nombre(i).Trim = clte_nom Then
                cod = General.Clientes.NombreRut(i)
                Exit For
            End If

        Next

        BuscaNombreRutCliente = cod
    End Function
#End Region

#Region "Boton AGREGAR"

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        If Param0_ModoIngreso = 0 Then
            If VerificaExisteVenta() = True Then Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor

        With frmVentas2IngresoDIIO
            .PForm = Me
            .Param1_ModoIngreso = 1    'nuevo ingreso
            .Param2_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
            .Param3_NombreCentro = cboCentros.Text
            .Param4_Fecha = dtpFecha.Value
            .Param5_CodigoVenta = Param6_NumeroVenta
            .Param6_NroFMA = IIf(txtNroFMA.Text.Trim = "", 0, Val(txtNroFMA.Text.Trim))
            .Param7_Estado = 1                                 'en ingreso
            .Param8_NroGuia = IIf(txtNroDoc.Text.Trim = "", 0, Val(txtNroDoc.Text.Trim))
            .Param13_Observs = txtObservs.Text
            .ActualizaDIIO = 0

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With

        Cursor.Current = Cursors.Default
    End Sub

    Private Function VerificaExisteVenta() As Boolean
        VerificaExisteVenta = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVentas_VerificaExiste", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@FMA", txtNroFMA.Text)
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
            If vret = 1 Then
                If MsgBox("YA EXISTE UNA COMPRA CON EL CENTRO-FECHA-FMA ESPECIFICADOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                VerificaExisteVenta = True
                Exit Function
            End If

            ''si todo sale ok
            'VerificaExisteCompra = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
#End Region

#Region "Boton BASTON"

    Private Sub btnBastonLee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales(False) = False Then Exit Sub
        LeeBaston()
    End Sub

    Private Sub LeeBaston()


        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmVentas2Ingreso"
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
        'Dim inichk_ As Integer = lvDIIOS.Items.Count '- 1
        Dim TotDiios As Integer

        Cursor.Current = Cursors.WaitCursor

        lblVenta.Items.Clear()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","

            Dim item As New ListViewItem((i + 1).ToString)    'nro

            item.SubItems.Add(diio_)
            item.SubItems.Add("") 'Fec. Nac.
            item.SubItems.Add("") 'Categ. Cod.
            item.SubItems.Add("") 'Categ. Nom
            item.SubItems.Add("") 'Est. Prod.
            item.SubItems.Add("") 'Est. Reprod.
            item.SubItems.Add("0") 'Tipo Vta. Cod.
            item.SubItems.Add("") 'Tipo Vta. Nom.
            item.SubItems.Add("0") 'Causa Cod.
            item.SubItems.Add("") 'Causa Nom.
            item.SubItems.Add("") 'Estado
            item.SubItems.Add("0") 'Veterinario
            item.SubItems.Add("0") 'Nro. Certificado

            lblVenta.Items.Add(item)
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
            Exit Sub
        Else
            ErrorCodGrl = 0
            ErrorDesGrl = ""
        End If
        cboCentros.Enabled = False
        dtpFecha.Enabled = False
        btnEliminar.Enabled = True

        Cursor.Current = Cursors.Default
    End Sub

    'devuelve el nro de errores en los diios
    Private Function BuscarDiiosBaston(ByVal diios_ As String) As Integer
        BuscarDiiosBaston = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVentas_ListadoBaston", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lblVenta.BeginUpdate()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim diio_ As String = ""
        Dim est_ As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    diio_ = rdr("GndCod").ToString.Trim

                    For i = 0 To lblVenta.Items.Count - 1
                        If lblVenta.Items(i).SubItems(1).Text.Trim = diio_ Then
                            lblVenta.Items(i).SubItems(2).Text = rdr("GndFecNac").ToString.Trim
                            lblVenta.Items(i).SubItems(3).Text = rdr("GndProCod").ToString.Trim
                            lblVenta.Items(i).SubItems(4).Text = rdr("GndProNom").ToString.Trim

                            lblVenta.Items(i).SubItems(5).Text = rdr("GndEstadoProductivo").ToString.Trim
                            lblVenta.Items(i).SubItems(6).Text = rdr("GndEstadoReproductivo").ToString.Trim

                            If VerificaDIIOEnGrilla(i, diio_) = True Then
                                lblVenta.Items(i).SubItems(11).Text = "ERR / REPETIDO"
                            Else
                                est_ = ""

                                If Not rdr("GndEstadoReproductivo").ToString.Trim.Contains("DESECHO") And Not rdr("GndEstadoProductivo").ToString.Trim.Contains("DESECHO") Then
                                    If est_.Trim = "" Then : est_ = "ERR / SIN CAUSA" : Else : est_ = est_ + " / SIN CAUSA" : End If
                                End If

                                If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                                    est_ = "ERR / CENTRO (" + rdr("CenDesCor").ToString.Trim + ")"
                                End If

                                If rdr("GndIsVendido").ToString.Trim = "SI" Then
                                    If est_.Trim = "" Then : est_ = "ERR / VENDIDO" : Else : est_ = est_ + " / VENDIDO" : End If
                                End If

                                If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                                    If est_.Trim = "" Then : est_ = "ERR / DESPARECIDO" : Else : est_ = est_ + " / DESPARECIDO" : End If
                                End If

                                If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                                    If est_.Trim = "" Then : est_ = "ERR / MUERTO" : Else : est_ = est_ + " / MUERTO" : End If
                                End If

                                lblVenta.Items(i).SubItems(11).Text = est_
                            End If

                        End If
                    Next

                End While

                For i = 0 To lblVenta.Items.Count - 1

                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        BuscarDiiosBaston = i

        lblVenta.EndUpdate()
    End Function

    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lblVenta.Items.Count - 1
            If i <> pos_ Then
                If lblVenta.Items(i).SubItems(2).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function
#End Region

#Region "Boton ASIGNAR"
    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        ModificaDatos()
    End Sub

    Private Sub ModificaDatos()
        If lblVenta.SelectedItems.Count = 0 Then Exit Sub

        fdats = New frmVentasCausa

        fdats.ShowDialog()

        If fdats.Procesa = True Then
            Dim tvta_cod As Integer = fdats.cboTiposVentas.SelectedValue
            Dim tvta_nom As String = fdats.cboTiposVentas.Text
            Dim causa_cod As Integer = 0 'General.CausasVentas.Codigo(fdats.cboCausas.SelectedIndex)
            Dim causa_nom As String = "" 'fdats.cboCausas.Text
            Dim vet_cod As Integer = 0 'General.Veterinarios.Codigo(fdats.cboVeterinarios.SelectedIndex)
            Dim vet_nom As String = "" 'fdats.cboVeterinarios.Text

            If fdats.cboCausas.SelectedIndex <> -1 And fdats.cboCausas.Text <> "" Then
                causa_nom = fdats.cboCausas.Text
                causa_cod = fdats.cboCausas.SelectedValue
            End If

            If fdats.cboVeterinarios.SelectedIndex <> -1 And fdats.cboVeterinarios.Text <> "" Then
                vet_nom = fdats.cboVeterinarios.Text
                vet_cod = General.Veterinarios.Codigo(fdats.cboVeterinarios.SelectedIndex - 1)
            End If

            ProcesaModificacionDatos(tvta_cod, tvta_nom, causa_cod, causa_nom, vet_cod, vet_nom, Int32.Parse(fdats.txtNroCert.Text))
            ContabilizaYValidaDIIOs()
        End If

        fdats.Dispose()
        fdats = Nothing
    End Sub

    Private Sub ProcesaModificacionDatos(ByVal tvtacod As Integer, ByVal tvtanom As String, ByVal ccod As Integer, ByVal cnom As String, ByVal vcod As Integer, ByVal vnom As String, ByVal ncert As Integer)
        For Each it As ListViewItem In lblVenta.SelectedItems
            it.SubItems(9).Text = ccod      'codigo causa
            it.SubItems(10).Text = cnom      'nombre causa

            it.SubItems(12).Text = vcod     'codigo veterinario
            it.SubItems(13).Text = ncert

            it.SubItems(7).Text = tvtacod
            it.SubItems(8).Text = tvtanom


            If cnom.Trim <> "" And it.SubItems(11).Text.Trim = "ERR / SIN CAUSA" Then
                it.SubItems(11).Text = ""      'si hay una causa de venta, quitamos error de causa (limpiamos estado)
            End If

            If (tvtanom.Contains("DONACI") Or tvtanom.Contains("DIRECTA") Or tvtanom.Contains("FAENA MAC")) And it.SubItems(8).Text.Trim = "ERR / SIN CAUSA" Then
                it.SubItems(11).Text = ""      'si hay una causa de venta, quitamos error de causa (limpiamos estado)
            End If
        Next
    End Sub
#End Region

#Region "Boton ELIMINAR"
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If UsuarioVenta = 1 Then
            If lblVenta.SelectedItems.Count > 0 Then
                Dim item As ListViewItem = lblVenta.SelectedItems(0)
                Dim Diio As String = item.SubItems(1).Text
                Dim Centro As String = cboCentros.Text
                Dim FechaVenta As DateTime = dtpFecha.Value
                Dim Obs As String
                Dim Estado As String
                Dim NroVenta As Integer = Param6_NumeroVenta

                If item.BackColor = Color.LightGreen Then
                    For Each item In lblVenta.SelectedItems
                        item.Remove()
                        Exit Sub
                    Next
                End If

                frmVentasObservacion.ShowDialog()

                If frmVentasObservacion.Cancelar = True Then
                    Exit Sub
                End If

                Obs = frmVentasObservacion.txtObservacion.Text
                Estado = frmVentasObservacion.Estado

                VentaEliminarDiio(Diio, Centro, FechaVenta, Estado, Obs, NroVenta)
                frmVentasObservacion.txtObservacion.Clear()
                BuscarDetalle()
            Else
                MsgBox("DEBE SELECCIONAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            End If
        Else
            ConfirmarEliminacionDIIOVentas()
        End If
    End Sub

    Private Sub ConfirmarEliminacionDIIOVentas()
        If lblVenta.Items.Count = 0 Then Exit Sub
        If lblVenta.SelectedItems.Count = 0 Then Exit Sub

        'si estamos editando (2), es porque los diios ya estan grabados y debemos eliminarlos de la base datos
        If Param0_ModoIngreso > 1 Then
            If MsgBox("¿DESEA ELIMINAR EL DIIO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

                Dim cent_ As String = CentrosUsuario.Codigo(cboCentros.SelectedIndex)
                Dim diio_ As Integer = Val(lblVenta.SelectedItems.Item(0).SubItems(2).Text)
            End If
        Else
            'si no estamos editando, los borramos de la grilla
            If MsgBox("¿DESEA ELIMINAR LOS DIIOS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

                For Each it As ListViewItem In lblVenta.SelectedItems
                    lblVenta.Items.Remove(it)
                Next
                ContabilizaYValidaDIIOs()
            End If
        End If

        If lblVenta.Items.Count = 0 Then
            cboCentros.Enabled = True
            dtpFecha.Enabled = True
            btnEliminar.Enabled = False
            btnFinalizar.Enabled = False
        End If
    End Sub
#End Region

#Region "Boton FINALIZAR"

    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If ValidacionesLocales() = False Then Exit Sub
        If ErrorCodGrl > 0 Then
            MsgBox(ErrorDesGrl, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Mensaje - Error")
            Exit Sub
        End If

        If MsgBox("¿ DESEA GRABAR Y PROCESAR LA VENTA ACTUAL (REBAJARÁ STOCK DE ANIMALES) ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        Dim NroGuia As Integer

        'buscamos codigo de documento de traslado
        Dim cent_ As String = "", clteCod_ As String = 0, tdocCod_ As Integer = 0, diios_ As String = "", i As Integer = 0

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        If cboClientes.SelectedIndex <> -1 Then clteCod_ = General.Clientes.Codigo(cboClientes.SelectedIndex)
        If cboTiposDoc.SelectedIndex <> -1 Then tdocCod_ = General.TipoDocumentosVentas.Codigo(cboTiposDoc.SelectedIndex)
        Dim NroDocManual As Integer = 0
        If txtNroDoc.Text.Trim <> "" Then NroDocManual = txtNroDoc.Text.Trim
        If Param0_ModoIngreso = 1 Then
            NroGuia = MovGnd.GeneraMovGanado("Venta", 0, NroDocManual, txtNroFMA.Text.Trim, clteCod_, dtpFecha.Value, cent_, "", txtObservs.Text.Trim,
                                                           0, diios_, tdocCod_, 0, lblVenta, txtRutChofer.Text.Trim, txtNomChofer.Text.Trim,
                                                           "", txtEmpTransporte.Text.Trim, txtPatente1.Text.Trim, txtPatente2.Text.Trim) 'FinalizarVenta2()
        Else 'el btn Finalizar solo se habilita cuando se debe finalizar el registro por Requerimiento de Venta
            NroGuia = MovGnd.FinalizarReqVenta(Param6_NumeroVenta, NroDocManual, txtNroFMA.Text.Trim, clteCod_, dtpFecha.Value, cent_, txtObservs.Text.Trim,
                                                           diios_, tdocCod_, lblVenta, txtRutChofer.Text.Trim, txtNomChofer.Text.Trim,
                                                           "", txtEmpTransporte.Text.Trim, txtPatente1.Text.Trim, txtPatente2.Text.Trim)
        End If
        'grabamos venta de animales



        If NroGuia > 0 Then
            Dim msg As String = cboTiposDoc.Text + " NRO: " + NroGuia.ToString + " GENERADA --- OK ---" + vbCrLf + vbCrLf + "DEBE IMPRIMIR EL SIGUIENTE DOCUMENTO DE TRASLADO"
            If tdocCod_ <> 52 Then msg = cboTiposDoc.Text + " NRO: " + NroGuia.ToString + " GENERADA --- OK ---"

            If MsgBox(msg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If

            'imprimimos
            If tdocCod_ = 52 And Empresa = 76011573 Then
                lblMsgGuia.Visible = True
                Cursor.Current = Cursors.WaitCursor
                Try
                    Dim PdfNomSuite As String = SuiteElectronica.GeneraNombreArchivo(52, NroGuia, Empresa)
                    SuiteElectronica.MostrarPDFeSuite(PdfNomSuite)
                Catch ex As Exception
                    MsgBox("Error al mostrar la Guia en pantalla. " & ex.ToString, MsgBoxStyle.Critical, System.Windows.Forms.Application.ProductName)
                    Me.Close()
                    frmVentas2.LlenaGrillaVentas()
                End Try
                Cursor.Current = Cursors.Default

            End If
            lblMsgGuia.Visible = False
            'actualizamos y cerramos
            If frmVentas2.Visible = True Then frmVentas2.LlenaGrillaVentas()
            Me.Close()
        End If
    End Sub
#End Region

#Region "Boton EXCEL"
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lblVenta.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL GANADO " : tot(0, 1) = lblTotalVentas.Text.Trim

        ExportToExcelGrilla(lblVenta, tot)
    End Sub
#End Region

#Region "Boton CERRAR"

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub

    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub
#End Region

#Region "Context Menu Options"
    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        InfoDIIO()
    End Sub

    Private Sub InfoDIIO()
        If lblVenta.Items.Count = 0 Then Exit Sub
        If lblVenta.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lblVenta.SelectedItems.Item(0).SubItems(1).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuCopiarDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lblVenta.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lblVenta.SelectedItems(0).SubItems(2).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub
#End Region

#Region "Eventos del FRAME"
    'Copia el DIIO al portapapeles de Windows al presionar las teclas "CTRL + C"
    Private Sub frmVentas2Ingreso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If lblVenta.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lblVenta.SelectedItems(0).SubItems(2).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If
        End If
    End Sub

    Private Sub Valida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroFMA.KeyPress, txtNroDoc.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub lvDIIOS_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblVenta.MouseDoubleClick
        If lblVenta.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            InfoDIIO()
        End If
    End Sub

    Private Sub cboTiposDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTiposDoc.SelectedIndexChanged
        If Param0_ModoIngreso = 1 Then
            If cboTiposDoc.Text.Contains("ELECTR") Then
                txtNroDoc.Text = ""
                txtNroDoc.Enabled = False
            Else
                txtNroDoc.Enabled = True
            End If

            If cboTiposDoc.Text.Contains("BOLETA") Then
                cboClientes.Text = "19 - CLIENTES BOLETAS" '"999 - CLIENTE TRANSITORIO"
                cboClientes.Enabled = False
            Else
                cboClientes.Enabled = True
                cboClientes.SelectedIndex = -1
            End If
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
#End Region

    'Debe ser public porque tambien es llamado del Frame "frmVentas2IngresoDIIO"
    Public Sub ContabilizaYValidaDIIOs()
        Dim i As Integer = 0
        Dim err_ As Integer = 0
        Dim estado_venta_ As String = ""

        For i = 0 To lblVenta.Items.Count - 1
            lblVenta.Items(i).Text = (i + 1).ToString.Trim
            estado_venta_ = lblVenta.Items(i).SubItems(11).Text.Trim

            If estado_venta_.Contains("ERR") Then
                err_ += 1
            End If
        Next

        lblTotalVentas.Text = i.ToString.Trim

        If err_ = 0 Then
            btnFinalizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
        End If

        btnEliminar.Enabled = True
    End Sub

    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False

        For Each item As ListViewItem In lblVenta.Items
            If item.BackColor = Color.LightGreen Then
                MsgBox("ANTES DE FINALIZAR, DEBE ACTUALIZAR VENTA PARA CARGAR LOS DIIOS NUEVOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                Exit Function
            End If
        Next

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        'If dtpFecha.Value > Date.Now Then
        '    If MsgBox("LA FECHA DEBE SER MENOR A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    dtpFecha.Focus()
        '    Exit Function
        'End If

        If cboTiposDoc.Text.Contains("GUIA MANUAL") And Not IsNumeric(txtNroDoc.Text.Trim) Then
            If MsgBox("DEBE INGRESAR UNA GUIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroDoc.Focus()
            Exit Function
        End If

        If cboClientes.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CLIENTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboClientes.Focus()
            Exit Function
        End If

        If txtNroFMA.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR EL FMA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroFMA.Focus()
            Exit Function
        End If

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

        ValidacionesLocales = True
    End Function

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Cursor.Current = Cursors.WaitCursor

        frptOrdenVenta.Param1_NumeroVenta = Param6_NumeroVenta 'Int32.Parse(lvGanado.SelectedItems(0).SubItems(12).Text)
        frptOrdenVenta.MdiParent = frmMAIN
        frptOrdenVenta.Show()
        frptOrdenVenta.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub VentaBuscarPersonal()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVentas_UsuarioVentas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    UsuarioVenta = rdr("PermIngVentaGanado").ToString.Trim
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub VentaEliminarDiio(ByVal Diio As String, ByVal Centro As String, ByVal FechaVenta As DateTime, ByVal Estado As String, ByVal Obs As String, ByVal NroVenta As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVentas_EliminarDiio", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Diio", Diio)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@FechaVenta", FechaVenta)
        cmd.Parameters.AddWithValue("@Estado", Estado)
        cmd.Parameters.AddWithValue("@Obs", Obs)
        cmd.Parameters.AddWithValue("@NroVenta", NroVenta)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output



        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            Try
                If vret <> 0 Then
                    Cursor.Current = Cursors.Default
                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    Exit Try
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MsgBox("DIIO FUE ELIMINADO EXITOSAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ELIMINAR")
            con.Close()
        End Try
    End Sub

    Private Sub btnAgregarDiio_Click(sender As Object, e As EventArgs) Handles btnAgregarDiio.Click
        If txtDiioAgregar.Text = "" Then
            MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "DATOS INCOMPLETOS")
            Exit Sub
        End If

        For i = 0 To lblVenta.Items.Count - 1
            If txtDiioAgregar.Text.Trim = lblVenta.Items(i).SubItems(1).Text Then
                MsgBox("EL DIIO YA SE ENCUENTRA EN LA LISTA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "DATO DUPLICADO ")
                Exit Sub
            End If
        Next

        VentaIngresoDiioManual()
    End Sub
    Private Function VentaIngresoDiioManual()
        Cursor.Current = Cursors.WaitCursor
        'Dim cent_ As String = cboCentros.Text
        Dim Diio As Integer = txtDiioAgregar.Text
        Dim i As Integer = lblVenta.Items.Count
        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVenta_AgregarDiioManual", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Centro As Integer = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@Diio", Diio)
        '
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        lblVenta.BeginUpdate()

        Try

            con.Open()
            rdr = cmd.ExecuteReader()

            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value

            Try
                While rdr.Read()

                    Dim item As New ListViewItem((i + 1).ToString.Trim)

                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    If IsDBNull(rdr("GndFecNac")) Then
                        item.SubItems.Add("")
                    Else
                        item.SubItems.Add(Format(rdr("GndFecNac"), "dd-MM-yyyy"))
                    End If
                    item.SubItems.Add(rdr("GndProCod").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                    item.SubItems.Add(cboTipoVenta.SelectedValue)
                    item.SubItems.Add(cboTipoVenta.Text)
                    item.SubItems.Add(cboTipoCausa.SelectedValue)
                    item.SubItems.Add(cboTipoCausa.Text)
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add(0)
                    item.BackColor = Color.LightGreen
                    lblVenta.Items.Add(item)
                    i = i + i
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        lblVenta.EndUpdate()
        Cursor.Current = Cursors.Default
    End Function
    Private Sub TipoSalida()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spReqVta_ListadoTipoSalida", con)
        Dim rdr As SqlDataReader = Nothing

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        da.SelectCommand = cmd
        da.Fill(dt)

        cboTipoVenta.ValueMember = "TipSalVtaCod"
        cboTipoVenta.DisplayMember = "TipSalVtaNom"
        cboTipoVenta.DataSource = dt

    End Sub
    Private Sub TipoCausa()
        Dim TSalida As Integer
        TSalida = cboTipoVenta.SelectedValue

        cboTipoCausa.Enabled = True
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spReqVta_ListadoTipoCausa", con)

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        cmd.Parameters.AddWithValue("@TipoSalida", TSalida)

        da.SelectCommand = cmd
        da.Fill(dt)

        cboTipoCausa.ValueMember = "TipCauVtaCod"
        cboTipoCausa.DisplayMember = "TipCauVtaNom"
        cboTipoCausa.DataSource = dt
    End Sub

    Private Sub cboTipoVenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoVenta.SelectedIndexChanged
        TipoCausa()
    End Sub

    Private Sub btnActulizar_Click(sender As Object, e As EventArgs) Handles btnActulizar.Click
        VentaActualizar()
    End Sub
    Public Function TablaActDiios(ByVal lvVentaDiio As ListView) As DataTable
        TablaActDiios = Nothing

        Dim table As DataTable = New DataTable("VentasRequerimiento")

        table.Columns.Add("Diio", System.Type.GetType("System.String"))
        table.Columns.Add("CodVenta", System.Type.GetType("System.Int32"))
        table.Columns.Add("CodCausa", System.Type.GetType("System.Int32"))

        Dim n As Integer
        n = lvVentaDiio.Items.Count
        For i = 0 To n - 1
            If lblVenta.Items(i).BackColor = Color.LightGreen Then
                table.Rows.Add(lvVentaDiio.Items(i).SubItems(1).Text,
                                lvVentaDiio.Items(i).SubItems(7).Text,
                                lvVentaDiio.Items(i).SubItems(9).Text)
            End If
        Next

        CantidadDiios = table.Rows.Count
        TablaActDiios = table

    End Function
    Private Sub VentaActualizar()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVenta_ActualizarDiio", con)
        Dim Centro As Integer = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        Dim ResultCod As Integer = -1
        Dim ResultMsg As String = ""
        Dim table As DataTable = TablaActDiios(lblVenta)

        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter
        Dim rdr As SqlDataReader = Nothing

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@NroVenta", Param6_NumeroVenta)
        cmd.Parameters.AddWithValue("@FechaVenta", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@DTVentaActualizarDiio", table)
        cmd.Parameters.AddWithValue("@NroDiios", CantidadDiios)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)



        If CantidadDiios = 0 And Param4_Fecha = dtpFecha.Value Then
            MsgBox("DEBE INGRESAR UN DIIO O MODIFICAR FECHA DE VENTA PARA ACTULIZAR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE ACTULIZACION")
            Exit Sub
        End If

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value

            If ResultCod <> 0 Then
                Cursor.Current = Cursors.Default
                If MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Exit Sub
        End Try
        MsgBox("ACTUALIZACION EXITOSA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ACTUALIZADO")
        BuscarDetalle()
    End Sub
End Class