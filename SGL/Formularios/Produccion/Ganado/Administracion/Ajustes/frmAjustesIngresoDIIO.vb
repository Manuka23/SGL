


Imports System.Data.SqlClient



Public Class frmAjustesIngresoDIIO

    Public Param0_ModoIngreso As Integer        '
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_Movimiento As Integer

    Private EstadoSecado As String = ""

    Public DatosAnimal(13) As String    'contendra los datos del animal, para un ajuste de entrada de inventario
    Public CancelaIngresoInventario As Boolean = False


    Private Sub CboLLenaTiposAjuste()
        Dim i As Integer

        If Param3_Movimiento = 1 Then
            If General.TiposAjusteSalida.NroRegistros = 0 Then Exit Sub
            cboTiposAjustes.Items.Clear()

            For i = 0 To General.TiposAjusteSalida.NroRegistros - 1
                cboTiposAjustes.Items.Add(General.TiposAjusteSalida.Nombre(i))
            Next
        Else
            If General.TiposAjusteEntrada.NroRegistros = 0 Then Exit Sub
            cboTiposAjustes.Items.Clear()

            For i = 0 To General.TiposAjusteEntrada.NroRegistros - 1
                cboTiposAjustes.Items.Add(General.TiposAjusteEntrada.Nombre(i))
            Next
        End If

        'cboCausasMuertes.SelectedIndex = 0
    End Sub


    Private Function BuscaCodigoAjuste(ByVal perf_text As String) As Integer
        BuscaCodigoAjuste = 0

        Dim i As Integer
        Dim cod As Integer

        If Param3_Movimiento = 1 Then
            For i = 0 To General.TiposAjusteSalida.Nombre.Length - 1
                If General.TiposAjusteSalida.Nombre(i).Trim = perf_text Then
                    cod = General.TiposAjusteSalida.Codigo(i)
                    Exit For
                End If
            Next
        Else
            For i = 0 To General.TiposAjusteEntrada.Nombre.Length - 1
                If General.TiposAjusteEntrada.Nombre(i).Trim = perf_text Then
                    cod = General.TiposAjusteEntrada.Codigo(i)
                    Exit For
                End If
            Next
        End If


        BuscaCodigoAjuste = cod
    End Function


    Private Sub LimpiaDatos(Optional ByVal LimpiaDIIO As Boolean = False)
        If LimpiaDIIO = True Then
            txtDIIO.Text = ""
        End If
        '
        lblCentro.Text = "---"
        lblCategoria.Text = "---"
        lblEstado.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        '
        lblFecProbParto.Text = "---"
        lblFecProbSecado.Text = "---"
        lblDiasSecado.Text = "---"
        lblDiasLactancia.Text = "---"

        'cboTiposAjustes.SelectedIndex = -1
        'txtObservs.Text = ""
    End Sub


    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If EsEntradaInventario() = False Then
            If txtDIIO.Text.Trim = "" Then
                If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                txtDIIO.Focus()
                Exit Function
            End If

            If lblCentro.Text = "---" Then
                If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                txtDIIO.Focus()
                Exit Function
            End If
        End If

        If cboTiposAjustes.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE AJUSTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTiposAjustes.Focus()
            Exit Function
        End If

        If VerificaDIIOEnGrilla(txtDIIO.Text.Trim) = True Then
            If MsgBox("EL DIIO YA ESTA CARGADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            LimpiaDatos()
            txtDIIO.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function


    Private Function VerificaDIIOEnGrilla(ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To frmAjustesIngreso.lvDIIOS.Items.Count - 1

            If frmAjustesIngreso.lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
                existe_ = True
                Exit For
            End If

        Next

        VerificaDIIOEnGrilla = existe_
    End Function


    Private Function ConsultaDIIOAjuste(ByVal CodigoDIIO As String) As Boolean
        ConsultaDIIOAjuste = False
        If CodigoDIIO.Trim = "" Then Exit Function

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_VerificaEnAjuste", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim ExisteEnAjuste As Boolean = False
        Dim fup_, fpp_, fsec_ As String
        'Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@DIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fup_ = ""
        fpp_ = ""
        fsec_ = ""
        EstadoSecado = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    Existe = True

                    Exit While
                End While


                If Existe = True Then
                    ConsultaDIIOAjuste = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Function


    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim ExisteEnAjuste As Boolean = False
        Dim fup_, fpp_, fsec_ As String
        'Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fup_ = ""
        fpp_ = ""
        fsec_ = ""
        EstadoSecado = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    Existe = True

                    If rdr("ExisteEnAjuste") = 1 Then
                        ExisteEnAjuste = True
                        Exit While
                    End If

                    If Not EsEntradaInventario() Then
                        If cboTiposAjustes.Text = "APARECIDO" Then
                            If rdr("GndIsDesaparecido").ToString.Trim <> "SI" Then
                                Dim est_ As String = ""

                                If rdr("GndIsVendido").ToString.Trim = "SI" Then est_ = "VENDIDO"
                                If rdr("GndIsMuerto").ToString.Trim = "SI" Then est_ = "MUERTO"
                                If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then est_ = "DESAPARECIDO"

                                If MsgBox("EL ESTADO DEL DIIO NO ES DESAPARECIDO (" + est_ + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                                End If

                                txtDIIO.Text = ""
                                txtDIIO.Focus()
                                Exit Try
                            End If

                            If rdr("CenDesCor").ToString.Trim <> Label1.Text Then
                                If MsgBox("EL DIIO ESTA DESAPARECIDO EN OTRO CENTRO (" + rdr("CenDesCor").ToString.Trim + "), ¿ DESEA APARECERLO EN EL CENTRO ACTUAL (" + Label1.Text + ")?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") <> vbOK Then
                                    txtDIIO.Text = ""
                                    txtDIIO.Focus()
                                    Exit Try
                                End If
                            End If
                        Else
                            If rdr("GndIsVendido").ToString.Trim = "SI" Or rdr("GndIsMuerto").ToString.Trim = "SI" Or rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                                Dim est_ As String = ""

                                If rdr("GndIsVendido").ToString.Trim = "SI" Then est_ = "VENDIDO"
                                If rdr("GndIsMuerto").ToString.Trim = "SI" Then est_ = "MUERTO"
                                If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then est_ = "DESAPARECIDO"

                                If MsgBox("EL ESTADO DEL DIIO NO ES DE STOCK (" + est_ + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                                End If

                                txtDIIO.Text = ""
                                txtDIIO.Focus()
                                Exit Try
                            End If

                            If rdr("CenDesCor").ToString.Trim <> Label1.Text Then
                                If MsgBox("EL DIIO NO PERTENECE AL CENTRO SELECCIONADO (" + rdr("CenDesCor").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                                End If

                                'EstadoSecado = "ERR / CENTRO"
                                txtDIIO.Text = ""
                                txtDIIO.Focus()
                                Exit Try
                            End If
                        End If


                        If IsDate(rdr("GndUltFechaParto")) Then
                            fup_ = Format(rdr("GndUltFechaParto"), "dd-MM-yyyy")
                            If fup_ = "01-01-1753" Then fup_ = ""
                            If fup_ = "01-01-1900" Then fup_ = ""
                        End If

                        If IsDate(rdr("GndUltFechaPP")) Then
                            fpp_ = Format(rdr("GndUltFechaPP"), "dd-MM-yyyy")
                            If fpp_ = "01-01-1753" Then fpp_ = ""
                            If fpp_ = "01-01-1900" Then fpp_ = ""
                        End If

                        If IsDate(rdr("GndUltFechaSecado")) Then
                            fsec_ = Format(rdr("GndUltFechaSecado"), "dd-MM-yyyy")
                            If fsec_ = "01-01-1753" Then fsec_ = ""
                            If fsec_ = "01-01-1900" Then fsec_ = ""
                        End If

                        Label12.Text = fup_

                        Dim diff1 As Integer = 0
                        Dim diff2 As Integer = 0

                        If IsDate(fpp_) Then diff1 = DateDiff(DateInterval.Day, Now, CDate(fpp_))
                        If IsDate(fup_) Then diff2 = DateDiff(DateInterval.Day, CDate(fup_), Now)

                        lblCentro.Text = rdr("CenDesCor").ToString.Trim
                        lblCategoria.Text = rdr("GndProNom").ToString.Trim
                        lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                        lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim

                        lblFecProbParto.Text = fpp_
                        lblFecProbSecado.Text = fsec_
                        lblDiasSecado.Text = diff1
                        lblDiasLactancia.Text = diff2
                        lblFecNac.Text = Format(rdr("GndFecNac"), "dd-MM-yyyy")

                        If rdr("GndIsVendido").ToString.Trim = "SI" Then
                            lblEstado.Text = "VENDIDO"
                        ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                            lblEstado.Text = "MUERTO"
                        ElseIf rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                            lblEstado.Text = "DESAPARECIDO"
                        Else
                            lblEstado.Text = "STOCK"
                        End If
                    End If

                    Exit While
                End While

                If Not EsEntradaInventario() Then
                    If Existe = False Then
                        MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                        Exit Try
                    Else
                        If ExisteEnAjuste = True Then
                            MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") EXISTE EN UN AJUSTE NO CERRADO")
                            txtDIIO.Text = ""
                            txtDIIO.Focus()
                            Exit Try
                        Else
                            txtObservs.Focus()
                        End If
                    End If
                Else
                    If Existe = True Then
                        MsgBox("EL DIIO INGRESADO YA EXISTE")
                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                    Else
                        If ConsultaDIIOAjuste(CodigoDIIO) = True Then
                            MsgBox("EL DIIO INGRESADO EXISTE EN UN AJUSTE NO CONFIRMADO")
                            txtDIIO.Text = ""
                            txtDIIO.Focus()
                        Else
                            txtObservs.Focus()
                        End If
                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub txtDiasGest_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Function EsEntradaInventario() As Boolean
        EsEntradaInventario = False

        If cboTiposAjustes.Text.Contains("AJUSTE ENTRADA INVENTARIO") Then
            EsEntradaInventario = True
        End If
    End Function


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        'MsgBox(BuscaCodigoAjuste(cboTiposAjustes.Text))
        'Exit Sub



        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        'If MsgBox("¿ CONFIRMA TRASLADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        '    LimpiaDatos(True)
        '    txtDIIO.Focus()
        '    Exit Sub
        'End If

        'If Param0_ModoIngreso = 1 Then

        ReDim DatosAnimal(17)

        'DatosAnimal = {""}

        If EsEntradaInventario() = True Then
            Me.btnSalir.Enabled = False

            CancelaIngresoInventario = False
            'frmAjustesIngresoInventarioDIIO.MdiParent = frmMAIN
            frmAjustesIngresoInventarioDIIO.txtDIIO.Text = txtDIIO.Text
            frmAjustesIngresoInventarioDIIO.txtDIIO.Enabled = False
            frmAjustesIngresoInventarioDIIO.ShowDialog()
            'frmAjustesIngresoInventarioDIIO.BringToFront()

            If CancelaIngresoInventario = True Then Exit Sub
        End If


        Dim nro As Integer = frmAjustesIngreso.lvDIIOS.Items.Count

        Dim item As New ListViewItem((nro + 1).ToString)    'nro

        item.SubItems.Add(txtDIIO.Text.Trim)

        If EsEntradaInventario() = False Then
            item.SubItems.Add(lblCategoria.Text)
            item.SubItems.Add(lblEstProductivo.Text)
            item.SubItems.Add(lblEstReproductivo.Text)
        Else
            item.SubItems.Add(DatosAnimal(0))
            item.SubItems.Add(DatosAnimal(1))
            item.SubItems.Add(DatosAnimal(2))
        End If

        item.SubItems.Add(cboTiposAjustes.Text)
        item.SubItems.Add("")               'estado
        item.SubItems.Add(BuscaCodigoAjuste(cboTiposAjustes.Text))       'codigo ajuste
        item.SubItems.Add(txtObservs.Text)  'observacion
        ''
        item.SubItems.Add(DatosAnimal(0))   'categoria
        item.SubItems.Add(DatosAnimal(1))   'est prod
        item.SubItems.Add(DatosAnimal(2))   'est reprod
        item.SubItems.Add(DatosAnimal(3))   'raza
        item.SubItems.Add(DatosAnimal(4))   'fec nac
        item.SubItems.Add(DatosAnimal(5))   'peso
        item.SubItems.Add(DatosAnimal(6))   'nro partos
        item.SubItems.Add(DatosAnimal(7))   'fec 1er parto
        item.SubItems.Add(DatosAnimal(8))   'fec ult parto
        item.SubItems.Add(DatosAnimal(9))   'fec prob parto
        item.SubItems.Add(DatosAnimal(10))  'fec ult cbta
        item.SubItems.Add(DatosAnimal(11))  'toro ult parto
        item.SubItems.Add(DatosAnimal(12))  'padre
        item.SubItems.Add(DatosAnimal(13))  'madre
        item.SubItems.Add(DatosAnimal(14))  'codigo categoria
        item.SubItems.Add(DatosAnimal(15))  'codigo est productivo
        item.SubItems.Add(DatosAnimal(16))  'codigo est reproductivo
        item.SubItems.Add(DatosAnimal(17))  'codigo raza

        'item.SubItems.Add(BuscaCodigoAjuste(cboTiposAjustes.Text))


        frmAjustesIngreso.lvDIIOS.Items.Add(item)

        frmAjustesIngreso.cboMovimientos.Enabled = False
        'frmAjustesIngreso.txtGuia.Enabled = False
        frmAjustesIngreso.cboCentros.Enabled = False
        'frmAjustesIngreso.cboDestinos.Enabled = False
        frmAjustesIngreso.dtpFecha.Enabled = False

        frmAjustesIngreso.SumaAjuste()
        frmAjustesIngreso.btnFinalizar.Enabled = True

        LimpiaDatos(True)
        txtDIIO.Focus()
        'Else
        'If GrabarPalpacion() = True Then
        '    If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
        '    End If

        '    LimpiaDatos(True)
        '    txtDIIO.Focus()
        'End If
        'End If
    End Sub


    Private Sub txtDIIO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
        End If
    End Sub


    Private Sub txtDIIO_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDIIO.TextChanged
        If lblCentro.Text <> "---" Then
            LimpiaDatos()
        End If
    End Sub


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub frmAjustesIngresoDIIO_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        cboTiposAjustes.Focus()
    End Sub


    Private Sub frmSecadoIngresoDIIO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        Label1.Text = Param2_NombreCentro

        CboLLenaTiposAjuste()

        txtDIIO.Enabled = False
        btnBuscar.Enabled = False
        txtObservs.Enabled = False

        'DESDE GERENCIA TECNICA PARA ARRIBA, VEN LAS OPCIONES DE INVENTARIO EN LOS TIPOS DE AJUSTES

        If PerfilUsuario < 4 Then
            For i As Integer = cboTiposAjustes.Items.Count - 1 To 0 Step -1
                If cboTiposAjustes.Items(i).ToString.Contains("INVENTARIO") Then
                    cboTiposAjustes.Items.RemoveAt(i)
                End If
            Next
        End If

    End Sub


    Private Sub cboTiposAjustes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTiposAjustes.SelectedIndexChanged
        If cboTiposAjustes.SelectedIndex = -1 Or cboTiposAjustes.Text.Trim = "" Then
            txtDIIO.Enabled = False
            btnBuscar.Enabled = False
            txtObservs.Enabled = False
        Else
            txtDIIO.Enabled = True
            btnBuscar.Enabled = True
            txtObservs.Enabled = True
        End If

        If cboTiposAjustes.Text.Contains("AJUSTE ENTRADA INVENTARIO") Then
            btnAgregar.Text = "Animal"
        Else
            btnAgregar.Text = "Grabar"
        End If

        txtDIIO.Focus()
    End Sub
End Class