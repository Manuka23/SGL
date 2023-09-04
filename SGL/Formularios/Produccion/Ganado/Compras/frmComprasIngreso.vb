

Imports System.Data.SqlClient



Public Class frmComprasIngreso




    Public Param0_ModoIngreso As Integer        '1=nuevo  /  2=edicion
    'Public Param1_Empresa As Integer
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_Fecha As DateTime
    Public Param5_Observs As String
    Public Param7_NroGuia As Integer
    Public Param8_RUP As String
    Public Param9_Estado As String
    Public Param10_TipoDocumento As String
    Public Param11_FMA As String
    Public Param12_NroDocumento As String
    Public Param13_Proveedor As String
    Public Param14_CodigoEstado As String


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaProveedores()
        If General.Proveedores.NroRegistros = 0 Then Exit Sub
        cboProveedores.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Proveedores.NroRegistros - 1
            cboProveedores.Items.Add(General.Proveedores.NombreRut(i))
        Next
    End Sub


    Private Sub CboLLenaTiposDocumentosCompras()
        If General.TipoDocumentos.NroRegistros = 0 Then Exit Sub
        cboTiposDocumentos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoDocumentos.NroRegistros - 1
            If General.TipoDocumentos.Tipo(i) = "C" Then
                cboTiposDocumentos.Items.Add(General.TipoDocumentos.Nombre(i))
            End If
        Next
    End Sub


    Private Function BuscaNombreRutProveedor(ByVal prov_nom As String) As String
        BuscaNombreRutProveedor = 0

        Dim i As Integer
        Dim cod As String = ""

        For i = 0 To General.Proveedores.Nombre.Length - 1

            If General.Proveedores.Nombre(i).Trim = prov_nom Then
                cod = General.Proveedores.NombreRut(i)
                Exit For
            End If

        Next

        BuscaNombreRutProveedor = cod
    End Function


    'Private Sub CboLLenaProveedores()
    '    If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
    '    cboCentros.Items.Clear()

    '    Dim i As Integer

    '    For i = 0 To General.CentrosUsuario.NroRegistros - 1
    '        cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
    '    Next
    'End Sub


    Public Sub SumaVenta()
        lblTotalCompras.Text = Str(Val(lblTotalCompras.Text) + 1).Trim
    End Sub


    Public Sub RestaVenta()
        lblTotalCompras.Text = Str(Val(lblTotalCompras.Text) - 1).Trim
    End Sub


   

    Public Sub LimpiaPantalla()
        lblNroGuia.Enabled = False
        txtNroFMA.Enabled = False

        btnFinalizar.Enabled = False
    End Sub


    Private Function GeneraStringDIIOs() As String
        GeneraStringDIIOs = ""

        Dim i As Integer = 0
        Dim str_ As String = ""
        Dim estado_ As String = ""

        For i = 0 To lvCOMPRAS.Items.Count - 1
            estado_ = lvCOMPRAS.Items(i).SubItems(6).Text.Trim

            If estado_ = "" Then 'Or Mid(estado_, 1, 3) = "MSJ" Then
                str_ = str_ + lvCOMPRAS.Items(i).SubItems(2).Text.ToString.Trim + ","
            End If
        Next

        If str_.Length > 0 Then
            str_ = Mid(str_, 1, str_.Length - 1)
        End If

        GeneraStringDIIOs = str_
    End Function


    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If txtNroFMA.Text.Trim = "" Or txtNroFMA.Text.Trim = "0" Then
            If MsgBox("DEBE INGRESAR EL NERO DE FMA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroFMA.Focus()
            Exit Function
        End If

        If txtNroGuia.Text.Trim = "" Or txtNroGuia.Text.Trim = "0" Then
            If MsgBox("DEBE INGRESAR EL NERO DE GUIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroGuia.Focus()
            Exit Function
        End If

        If txtRUP.Text.Replace("-", "").Trim = "" Or txtRUP.Text.Replace("-", "").Trim = "0" Then
            If MsgBox("DEBE INGRESAR EL RUP", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtRUP.Focus()
            Exit Function
        End If

        If txtRUP.Text.Replace("-", "").Trim.Length < 9 Then
            If MsgBox("RUP INCORRECTO, DEBE TENER 9 DIGITOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtRUP.Focus()
            Exit Function
        End If


        ValidacionesLocales = True
    End Function


    Private Function ValidacionesLocalesParaFacturacion(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocalesParaFacturacion = False

        If ValidacionesLocales() = False Then Exit Function

        If Param14_CodigoEstado < 2 Then
            ValidacionesLocalesParaFacturacion = True
            Exit Function
        End If


        If cboTiposDocumentos.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE DOCUMENTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTiposDocumentos.Focus()
            Exit Function
        End If

        If cboProveedores.SelectedIndex = -1 Or cboProveedores.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UN PROVEEDOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboProveedores.Focus()
            Exit Function
        End If

        If txtNroDoc.Text.Trim = "" Or txtNroDoc.Text.Trim = "0" Then
            If MsgBox("DEBE INGRESAR EL NRO DEL DOCUMENTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroDoc.Focus()
            Exit Function
        End If

        ValidacionesLocalesParaFacturacion = True
    End Function


    Public Sub BuscarDetalle()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCompras_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param2_CodigoCentro)
        cmd.Parameters.AddWithValue("@Fecha", Param4_Fecha)
        cmd.Parameters.AddWithValue("@NroFMA", Param11_FMA)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvCOMPRAS.BeginUpdate()
        lvCOMPRAS.Items.Clear()
        lblTotalCompras.Text = "0"

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim fn, f1, f2, f3, f4 As String
        Dim peso, npart As String

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    fn = ""
                    f1 = ""
                    f2 = ""
                    f3 = ""
                    f4 = ""
                    peso = ""
                    npart = ""

                    If FechaCorrecta(rdr("CDetFechaNac").ToString.Trim) Then fn = Format(rdr("CDetFechaNac"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("CDetFec1erParto").ToString.Trim) Then f1 = Format(rdr("CDetFec1erParto"), "dd-MM-yyyy")

                    If FechaCorrecta(rdr("CDetFecUltParto").ToString.Trim) Then f2 = Format(rdr("CDetFecUltParto"), "dd-MM-yyyy") 'CompraFechaUPP
                    If FechaCorrecta(rdr("CDetFecUltCbta").ToString.Trim) Then f3 = Format(rdr("CDetFecUltCbta"), "dd-MM-yyyy") 'CompraUltCubierta
                    If FechaCorrecta(rdr("CDetFecProbParto").ToString.Trim) Then f4 = Format(rdr("CDetFecProbParto"), "dd-MM-yyyy") 'ComprasUltFechaPP

                    If Not IsDBNull(rdr("CDetPeso")) Then
                        If rdr("CDetPeso") > 0 Then peso = rdr("CDetPeso").ToString.Trim
                    End If

                    If Not IsDBNull(rdr("CDetNroPartos")) Then
                        If rdr("CDetNroPartos") > 0 Then npart = rdr("CDetNroPartos").ToString.Trim
                    End If


                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("CDetEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("CDetDiio").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)

                    item.SubItems.Add(rdr("CDetEstReproductivo").ToString.Trim)
                    item.SubItems.Add(rdr("CDetEstProductivo").ToString.Trim)

                    item.SubItems.Add(rdr("NomRaza").ToString.Trim)
                    item.SubItems.Add(fn)
                    item.SubItems.Add(peso)
                    item.SubItems.Add(npart)

                    item.SubItems.Add(f1)
                    item.SubItems.Add(f2)
                    item.SubItems.Add(f3)

                    item.SubItems.Add(rdr("CDetToroUltCbta").ToString.Trim)

                    item.SubItems.Add(f4)

                    item.SubItems.Add(rdr("CDetPadre").ToString.Trim)
                    item.SubItems.Add(rdr("CDetMadre").ToString.Trim)
                    item.SubItems.Add("")

                    lvCOMPRAS.Items.Add(item)

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

        lvCOMPRAS.EndUpdate()
        lblTotalCompras.Text = i.ToString.Trim
    End Sub



    Private Function FinalizarCompra() As Boolean
        FinalizarCompra = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCompras_Finalizar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        Dim prov_ As Integer = 0
        Dim tdoc_ As Integer = 0

        If cboProveedores.SelectedIndex <> -1 Then prov_ = General.Proveedores.Codigo(cboProveedores.SelectedIndex)
        If cboTiposDocumentos.SelectedIndex <> -1 Then tdoc_ = BuscaCodigoTipoDocumento(cboTiposDocumentos.Text)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@FMA", txtNroFMA.Text)
        cmd.Parameters.AddWithValue("@Proveedor", prov_)
        cmd.Parameters.AddWithValue("@TipoDoc", tdoc_)
        cmd.Parameters.AddWithValue("@NumeroDoc", txtNroDoc.Text.Trim)
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
            If vret = -1 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            ''si todo sale ok
            FinalizarCompra = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function VerificaExisteCompra() As Boolean
        VerificaExisteCompra = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCompras_VerificaExiste", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        'Dim prov_ As Integer = General.Proveedores.Codigo(cboProveedores.SelectedIndex)
        'Dim tdoc_ As Integer = BuscaCodigoTipoDocumento(cboTiposDocumentos.Text)

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
                VerificaExisteCompra = True
                Exit Function
            End If

            ''si todo sale ok
            'VerificaExisteCompra = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    'Private Function EliminarDIIOSecado(ByVal diio_ As Integer) As Boolean
    '    EliminarDIIOSecado = False

    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spSecados_EliminarDetalle", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    'cmd.Parameters.AddWithValue("@CodSecado", CodigoSecado)
    '    cmd.Parameters.AddWithValue("@DIIO", diio_)
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

    '        If vret > 0 Then
    '            If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
    '            End If
    '            Exit Function
    '        End If

    '        EliminarDIIOSecado = True

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
    '    End Try
    'End Function


    'Private Sub ConfirmarEliminacionDIIOVentas()
    '    If lvCOMPRAS.Items.Count = 0 Then Exit Sub
    '    If lvCOMPRAS.SelectedItems.Count = 0 Then Exit Sub

    '    'Dim estado_secado_ As String = ""

    '    'estado_secado_ = lvDIIOS.SelectedItems(0).SubItems(7).Text.Trim

    '    'si estamos editando (2), es porque los diios ya estan grabados y debemos eliminarlos de la base datos
    '    If Param0_ModoIngreso = 2 Then
    '        If MsgBox("¿DESEA ELIMINAR EL DIIO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

    '            Dim cent_ As String = CentrosUsuario.Codigo(cboCentros.SelectedIndex)
    '            'Dim fec_ As DateTime = Param4_Fecha  'dtpFecha.Value
    '            Dim diio_ As Integer = Val(lvCOMPRAS.SelectedItems.Item(0).SubItems(1).Text)
    '            'If cod_ = 0 Then Exit Sub

    '            'If EliminarDIIOSecado(cent_, fec_, diio_) = True Then
    '            '    If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
    '            '    End If

    '            '    'lvDIIOS.SelectedItems.Item(0).Remove()
    '            '    lvDIIOS.SelectedItems(0).SubItems(8).Text = "Eliminado (" + Format(Now, "dd-MM-yyyy") + ")"
    '            '    'SumaEliminado()
    '            '    'RestaSecado()

    '            '    'If ExistenDIIOsSinGrabar() = False Then
    '            '    '    btnGrabar.Enabled = False
    '            '    'End If

    '            '    'frmSecados.LlenaGrillaSecados()
    '            'End If
    '        End If

    '        Exit Sub
    '    Else
    '        'si no estamos editando, los borramos de la grilla
    '        If MsgBox("¿DESEA ELIMINAR LOS DIIOS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

    '            'Dim i As Integer = 0
    '            'Dim ErrDiios = 0

    '            For Each it As ListViewItem In lvCOMPRAS.SelectedItems
    '                lvCOMPRAS.Items.Remove(it)
    '                'RestaSecado()
    '            Next

    '            'For i = 0 To lvDIIOS.SelectedItems.Count - 1
    '            '    lvDIIOS.SelectedItems.Item(i).Remove()
    '            '    RestaSecado()

    '            'Next

    '            ContabilizaYValidaDIIOs()

    '            'If ExistenDIIOsSinGrabar() = False Then
    '            '    btnFinalizar.Enabled = False
    '            'End If
    '        End If

    '        Exit Sub
    '    End If
    'End Sub


    Private Sub DetalleGanado()
        If lvCOMPRAS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(2).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub DetalleCompraDIIO()
        If lvCOMPRAS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim emp_ As Integer = lvCOMPRAS.SelectedItems.Item(0).SubItems(1).Text              'empresa
        Dim diio_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(2).Text              'DIIO
        Dim cat_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(3).Text               'categoria
        Dim eprod_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(4).Text             'e.prod
        Dim ereprod_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(5).Text           'e.reprod
        Dim raza_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(6).Text              'raza
        Dim fnac_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(7).Text              'fecha.nac
        Dim peso_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(8).Text              'peso
        Dim nropart_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(9).Text           'nro partos
        ''
        Dim f1part_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(10).Text           'fecha 1er parto
        Dim fupart_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(11).Text           'fecha ult parto
        Dim fucbta_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(12).Text           'fecha ult cubirta
        Dim trcbta_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(13).Text           'toro ult cubierta
        Dim fpp_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(14).Text              'fecha prob.parto
        Dim padre_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(15).Text            'padre
        Dim madre_ As String = lvCOMPRAS.SelectedItems.Item(0).SubItems(16).Text            'madre


        With frmComprasIngresoDIIO
            '.Param0_ModoIngreso = Param0_ModoIngreso
            .PForm = Me
            .Param1_ModoIngreso = 2    'muestra info y edita (segun estado, solo estado 1 y 2 modifica)
            .Param2_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
            .Param3_NombreCentro = cboCentros.Text
            .Param4_Fecha = dtpFecha.Value
            .Param6_NroFMA = txtNroFMA.Text
            .Param7_Estado = Param14_CodigoEstado              'en ingreso
            .Param8_NroGuia = txtNroGuia.Text
            .Param9_NroRUP = txtRUP.Text.Replace("-", "")
            .Param13_Observs = txtObservs.Text
            .ActualizaDIIO = 1

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            .txtDIIO.Text = diio_
            .cboCategorias.Text = cat_
            .cboEstProductivos.Text = eprod_
            .cboEstReproductivos.Text = ereprod_
            .cboRazas.Text = raza_
            If fnac_.Trim <> "" Then .dtpFechaNac.Value = fnac_
            .txtPeso.Text = peso_
            .txtNroPartos.Text = nropart_
            ''
            If f1part_.Trim <> "" Then .dtpFec1erParto.Value = f1part_
            If fupart_.Trim <> "" Then .dtpFecUltParto.Value = fupart_
            If fucbta_.Trim <> "" Then .dtpFecUltCbta.Value = fucbta_
            .txtToroUltParto.Text = trcbta_
            If fpp_.Trim <> "" Then .dtpFecProbParto.Value = fpp_
            .txtPadre.Text = padre_
            .txtMadre.Text = madre_
        End With

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub Valida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroFMA.KeyPress, txtNroGuia.KeyPress, txtNroDoc.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub lvDIIOS_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCOMPRAS.MouseDoubleClick
        If lvCOMPRAS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleCompraDIIO()
        End If
    End Sub


    Private Sub Cerrar()
        'If ExistenDIIOsSinGrabar() = True Then
        '    If MsgBox("EXISTEN DIIOS SIN GRABAR, ¿DESEA SALIR?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        '        Exit Sub
        '    End If
        'End If

        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub


    Private Sub mnuCopiarDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvCOMPRAS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvCOMPRAS.SelectedItems(0).SubItems(2).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        'MsgBox(txtRUP.Text.Replace("-", ""))

        If lvCOMPRAS.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL GANADO " : tot(0, 1) = lblTotalCompras.Text.Trim
        'tot(1, 0) = "TOTAL COMPRA GANADO " : tot(1, 1) = Label5.Text.Trim

        ExportToExcelGrilla(lvCOMPRAS, tot)
    End Sub



    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        If Param0_ModoIngreso = 0 Then
            If VerificaExisteCompra() = True Then Exit Sub
        End If

        Cursor.Current = Cursors.WaitCursor

        With frmComprasIngresoDIIO
            '.Param0_ModoIngreso = Param0_ModoIngreso
            .PForm = Me
            .Param1_ModoIngreso = 1    'nuevo ingreso
            .Param2_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
            .Param3_NombreCentro = cboCentros.Text
            .Param4_Fecha = dtpFecha.Value
            .Param6_NroFMA = txtNroFMA.Text
            .Param7_Estado = 1                                 'en ingreso
            .Param8_NroGuia = txtNroGuia.Text
            .Param9_NroRUP = txtRUP.Text.Replace("-", "")
            .Param13_Observs = txtObservs.Text
            .ActualizaDIIO = 0

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If ValidacionesLocalesParaFacturacion() = False Then Exit Sub

        'CONFIRMAR
        If Param14_CodigoEstado = 1 Then
            If MsgBox("¿ DESEA -- RECEPCIONAR -- LA COMPRA ACTUAL ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        If Param14_CodigoEstado = 2 Then
            If MsgBox("¿ DESEA -- FACTURAR -- LA COMPRA ACTUAL ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        If FinalizarCompra() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            Cursor.Current = Cursors.WaitCursor

            If frmCompras.Visible = True Then frmCompras.LlenaGrillaCompras()
            Me.Close()

            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'ConfirmarEliminacionDIIOVentas()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub frmSecadosIngreso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If lvCOMPRAS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvCOMPRAS.SelectedItems(0).SubItems(2).Text

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


    Private Sub FrmVentaIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 10
        Me.KeyPreview = True

        'LimpiaPantalla()
        CboLLenaCentros()
        CboLLenaProveedores()
        CboLLenaTiposDocumentosCompras()

        'ocultamos campo estado de la grilla
        lvCOMPRAS.Columns(16).Width = 0

        If Param0_ModoIngreso = 1 Then
            'secado nuevo
            Me.Text = "INGRESO DE COMPRAS"
            Label12.Text = "TOTAL A COMPRAR"

            lblConErrores.Visible = True
            lblTotErrores.Visible = True

            lvCOMPRAS.MultiSelect = True

            cboTiposDocumentos.Enabled = False
            cboProveedores.Enabled = False
            txtNroDoc.Enabled = False
        Else
            'edicion de secado
            Me.Text = "DETALLE DE COMPRAS"
            Label12.Text = "TOTAL COMPRAS"

            lvCOMPRAS.MultiSelect = False

            cboCentros.Text = Param3_NombreCentro
            dtpFecha.Value = Param4_Fecha
            txtNroFMA.Text = Param11_FMA
            txtNroGuia.Text = Param7_NroGuia
            txtObservs.Text = Param5_Observs

            cboTiposDocumentos.Text = Param10_TipoDocumento
            cboProveedores.Text = BuscaNombreRutProveedor(Param13_Proveedor)
            txtRUP.Text = Param8_RUP
            txtNroDoc.Text = Param12_NroDocumento
            txtEstado.Text = Param9_Estado

            cboCentros.Enabled = False
            dtpFecha.Enabled = False
            txtNroFMA.Enabled = False

            Select Case Param14_CodigoEstado
                Case 1  'EN INGRESO
                    txtNroGuia.Enabled = True
                    txtRUP.Enabled = True
                    txtObservs.Enabled = True
                    ''
                    cboTiposDocumentos.Enabled = False
                    cboProveedores.Enabled = False
                    txtNroDoc.Enabled = False

                Case 2  'RECEPCIONADA
                    txtNroGuia.Enabled = False
                    txtRUP.Enabled = False
                    txtObservs.Enabled = False
                    ''
                    cboTiposDocumentos.Enabled = True
                    cboProveedores.Enabled = True
                    txtNroDoc.Enabled = True
                    ''
                    'btnFinalizar.Text = "Proceso OC"
                    btnAgregar.Visible = False
                    btnImportar.Visible = False
                    btnEliminar.Visible = False
                    btnFinalizar.Left = btnAgregar.Left
                    btnExcel.Left = btnImportar.Left

                Case 3  'EN PROCESO OC
                    txtNroGuia.Enabled = False
                    txtRUP.Enabled = False
                    txtObservs.Enabled = False
                    ''
                    cboTiposDocumentos.Enabled = False
                    cboProveedores.Enabled = False
                    txtNroDoc.Enabled = False
                    ''
                    btnAgregar.Visible = False
                    btnImportar.Visible = False
                    btnEliminar.Visible = False
                    btnFinalizar.Visible = False
                    btnExcel.Left = btnAgregar.Left
            End Select

            BuscarDetalle()
        End If
    End Sub


    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        If Param0_ModoIngreso = 0 Then
            If VerificaExisteCompra() = True Then Exit Sub
        End If

        'frmComprasImportar.ShowDialog()

        Cursor.Current = Cursors.WaitCursor

        With frmComprasImportar
            '.Param0_ModoIngreso = Param0_ModoIngreso
            '.PForm = Me
            .Param1_ModoIngreso = 1    'nuevo ingreso
            .Param2_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
            .Param3_NombreCentro = cboCentros.Text
            .Param4_Fecha = dtpFecha.Value
            .Param6_NroFMA = txtNroFMA.Text
            .Param7_Estado = 1                                 'en ingreso
            .Param8_NroGuia = txtNroGuia.Text
            .Param9_NroRUP = txtRUP.Text.Replace("-", "")
            .Param13_Observs = txtObservs.Text
            .ActualizaDIIO = 0

            '.MdiParent = frmMAIN
            .ShowDialog()
            '.BringToFront()
        End With

        Cursor.Current = Cursors.Default
    End Sub

End Class