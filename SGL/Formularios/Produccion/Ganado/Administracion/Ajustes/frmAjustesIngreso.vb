
'Imports System.IO.Ports

Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel



Public Class frmAjustesIngreso

    'Public CodigoTraslado As Integer = 0

    Public Param0_ModoIngreso As Integer        '1=nuevo  /  2=edicion  / 3=nuevo (menu recepcion)
    Public Param1_Empresa As Integer
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_Fecha As String
    Public Param5_Observs As String
    Public Param9_Movimiento As Integer
    Public Param10_MovimientoNom As String
    Public Param11_Estado As Integer
    '
    Private fdats As frmAjustesIngresoTipoAjuste

    Private FechaSalida As DateTime



    Private Sub LeeBaston()

        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmAjustesIngreso"
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

            If VerificaDIIOEnGrilla(-1, diio_) = True Then
                item.SubItems.Add("ERR / REPETIDO")
            Else
                item.SubItems.Add("ERR / NO EXISTE EN BD")
            End If

            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")

            lvDIIOS.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If

        TotDiios = BuscarDiiosBaston(strdiios_)

        ContabilizaYValidaDIIOs()

        Cursor.Current = Cursors.Default

    End Sub


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

        lvDIIOS.BeginUpdate()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim diio_ As String = ""
        Dim est_ As String = ""
        'Dim fec_ As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    diio_ = rdr("GndCod").ToString.Trim

                    For i = 0 To lvDIIOS.Items.Count - 1
                        If lvDIIOS.Items(i).SubItems(1).Text.Trim = diio_ Then
                            'fec_ = ""

                            'If Not IsDBNull(rdr("GndFecNac")) Then
                            '    fec_ = Format(rdr("GndFecNac"), "dd-MM-yyyy")
                            'End If

                            'lvDIIOS.Items(i).SubItems(2).Text = fec_
                            lvDIIOS.Items(i).SubItems(2).Text = rdr("GndProNom").ToString.Trim
                            lvDIIOS.Items(i).SubItems(3).Text = rdr("GndEstadoProductivo").ToString.Trim
                            lvDIIOS.Items(i).SubItems(4).Text = rdr("GndEstadoReproductivo").ToString.Trim
                            lvDIIOS.Items(i).SubItems(5).Text = ""

                            If VerificaDIIOEnGrilla(i, diio_) = True Then
                                lvDIIOS.Items(i).SubItems(6).Text = "ERR / REPETIDO"
                            Else
                                est_ = "ERR / SIN TIPO AJUSTE"

                                If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                                    est_ = "ERR / CENTRO + (" + rdr("CenDesCor").ToString.Trim + ")"
                                End If

                                If rdr("GndIsVendido").ToString.Trim = "SI" Then
                                    est_ = "ERR / VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy")
                                End If

                                If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                                    est_ = "ERR / MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy")
                                End If

                                If rdr("GndIsDesaparecido").ToString.Trim = "SI" And cboMovimientos.Text <> "ENTRADA" Then
                                    est_ = "ERR / DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy")
                                End If

                                'If rdr("GndProNom").ToString.Trim <> "VACAS" Then
                                '    If est_.Trim = "" Then : est_ = "ERR / CATEG" : Else : est_ = est_ + " / CATEG" : End If
                                'End If

                                'If rdr("GndEstadoProductivo").ToString.Trim <> "EN PRODUCCION" And rdr("GndEstadoProductivo").ToString.Trim <> "SECA DE LECHE" Then
                                '    If est_.Trim = "" Then : est_ = "ERR / E.PROD" : Else : est_ = est_ + " / E.PROD" : End If
                                'End If

                                lvDIIOS.Items(i).SubItems(6).Text = est_
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
            estado_ = lvDIIOS.Items(i).SubItems(6).Text.Trim

            If Mid(estado_, 1, 3) = "ERR" Then
                err_ += 1
            End If
        Next

        lblTotAjustes.Text = i.ToString.Trim
        lblTotErrores.Text = err_.ToString.Trim

        If err_ = 0 Then
            btnFinalizar.Enabled = True
            'btnPrevisualizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
            'btnPrevisualizar.Enabled = False
        End If
    End Sub



    Public Sub SumaAjuste()
        lblTotAjustes.Text = Str(Val(lblTotAjustes.Text) + 1).Trim
    End Sub


    Public Sub RestaTraslado()
        lblTotAjustes.Text = Str(Val(lblTotAjustes.Text) - 1).Trim
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
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub



    Private Sub CboLLenaTipoMovimientos()
        If General.TipoMovsAjuste.NroRegistros = 0 Then Exit Sub
        cboMovimientos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoMovsAjuste.NroRegistros - 1
            cboMovimientos.Items.Add(General.TipoMovsAjuste.Nombre(i))
        Next
    End Sub


    Private Function GeneraStringDIIOs() As String
        GeneraStringDIIOs = ""

        Dim i As Integer = 0
        Dim str_ As String = ""
        Dim estado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            estado_ = lvDIIOS.Items(i).SubItems(6).Text.Trim

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

        'Dim i As Integer = 0
        'Dim existe_ As Boolean = False
        'Dim estado_ As String = ""

        'For i = 0 To lvDIIOS.Items.Count - 1
        '    estado_ = lvDIIOS.Items(i).SubItems(6).Text.Trim

        '    If estado_ = "" Or Mid(estado_, 1, 3) = "MSJ" Then
        '        existe_ = True
        '        Exit For
        '    End If
        'Next

        If Param0_ModoIngreso = 1 And lvDIIOS.Items.Count > 0 Then
            ExistenDIIOsSinGrabar = True
        End If

        'ExistenDIIOsSinGrabar = existe_
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


        'If cboMovimientos.Text = "SALIDA" Then
        '    If cboDestinos.SelectedIndex = -1 Then
        '        If MsgBox("DEBE SELECCIONAR UN CENTRO DE DESTINO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '        End If
        '        cboDestinos.Focus()
        '        Exit Function
        '    End If
        'End If


        If cboMovimientos.Text = "ENTRADA" Then
            If dtpFecha.Value < FechaSalida Then
                If MsgBox("LA FECHA DE ENTRADA DEBE SER MAYOR O IGUAL A LA FECHA DE SALIDA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                dtpFecha.Focus()
                Exit Function
            End If
        End If

        'If ExistenDIIOsSinGrabar() = False Then
        '    If MsgBox("NO EXISTEN SECADOS PENDIENTES", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboCentros.Focus()
        '    Exit Function
        'End If

        If ValidaDiios = True Then
            If lvDIIOS.Items.Count = 0 Then
                If MsgBox("DEBE INGRESAR EL DETALLE DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                'cboCondiciones.Focus()
                Exit Function
            End If
        End If

        ValidacionesLocales = True
    End Function


    Private Sub BuscarDetalleAjuste()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAjustes_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        'Dim mov_ As String = General.Cen.Codigo(cboCentros.SelectedIndex)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Movimiento", Param9_Movimiento)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvDIIOS.BeginUpdate()
        lvDIIOS.Items.Clear()
        lblTotAjustes.Text = "0"
        lblTotErrores.Text = "0"

        Dim existe As Boolean = False
        Dim i As Integer = 0
        'Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'asignamos valores solo una vez

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("ADetDIIO").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(rdr("ADetEstProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("ADetEstReproductivo").ToString.Trim)
                    item.SubItems.Add(rdr("ATipNombre").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("ADetTipo").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add("")

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
        lblTotAjustes.Text = i.ToString.Trim
        'Label3.Text = e.ToString.Trim
    End Sub


    Private Function GrabarAjuste() As Boolean
        GrabarAjuste = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAjustes_GrabarDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        Dim cent_ As String = ""
        Dim clte_ As Integer = 0
        Dim diios_ As String = ""
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

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        

        For i = 0 To lvDIIOS.Items.Count - 1

            cmd.Parameters.Clear()
            'cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", cent_)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            ''
            cmd.Parameters.AddWithValue("@Movimiento", cboMovimientos.SelectedIndex + 1)                        'nro venta SGL
            cmd.Parameters.AddWithValue("@Observs", txtObservs.Text)
            cmd.Parameters.AddWithValue("@Estado", 1)
            ''
            cmd.Parameters.AddWithValue("@DIIO", lvDIIOS.Items(i).SubItems(1).Text)
            cmd.Parameters.AddWithValue("@TipoAjusteDIIO", lvDIIOS.Items(i).SubItems(7).Text)
            cmd.Parameters.AddWithValue("@ObservsDIIO", lvDIIOS.Items(i).SubItems(8).Text)
            ''
            cmd.Parameters.AddWithValue("@ADetAEntCategoria", lvDIIOS.Items(i).SubItems(23).Text)
            cmd.Parameters.AddWithValue("@ADetAEntEstProd", lvDIIOS.Items(i).SubItems(24).Text)
            cmd.Parameters.AddWithValue("@ADetAEntEstReprod", lvDIIOS.Items(i).SubItems(25).Text)
            cmd.Parameters.AddWithValue("@ADetAEntRaza", lvDIIOS.Items(i).SubItems(26).Text)
            cmd.Parameters.AddWithValue("@ADetAEntFecNac", lvDIIOS.Items(i).SubItems(13).Text)
            cmd.Parameters.AddWithValue("@ADetAEntPeso", lvDIIOS.Items(i).SubItems(14).Text)
            cmd.Parameters.AddWithValue("@ADetAEntNroPartos", lvDIIOS.Items(i).SubItems(15).Text)
            cmd.Parameters.AddWithValue("@ADetAEntF1erPArto", lvDIIOS.Items(i).SubItems(16).Text)
            cmd.Parameters.AddWithValue("@ADetAEntFUltPArto", lvDIIOS.Items(i).SubItems(17).Text)
            cmd.Parameters.AddWithValue("@ADetAEntFProbParto", lvDIIOS.Items(i).SubItems(18).Text)
            cmd.Parameters.AddWithValue("@ADetAEntFUltCbta", lvDIIOS.Items(i).SubItems(19).Text)
            cmd.Parameters.AddWithValue("@ADetAEntToroUCbta", lvDIIOS.Items(i).SubItems(20).Text)
            cmd.Parameters.AddWithValue("@ADetAEntPadre", lvDIIOS.Items(i).SubItems(21).Text)
            cmd.Parameters.AddWithValue("@ADetAEntMadre", lvDIIOS.Items(i).SubItems(22).Text)
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
                    'If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    'End If
                    lvDIIOS.Items(i).SubItems(6).Text = mret   'estado
                    HayError = True
                    'Exit For
                End If

                'HayError = False
                ''si todo sale ok guardamos el nuevo codigo del grupo de celos
                'GrabarGrupoParto = True

            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                lvDIIOS.Items(i).SubItems(6).Text = ex.Message     'estado
                HayError = True
                'Exit For
            End Try

        Next

        If HayError = False Then
            SRVTRANS.Commit()
            GrabarAjuste = True
        Else
            SRVTRANS.Rollback()
            GrabarAjuste = False

            If MsgBox("HA OCURRIDO UN ERROR AL GRABAR EL AJUSTE, VERIFIQUE LA COLUMNA ESTADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
        End If

        con.Close()
        Cursor.Current = Cursors.Default
    End Function


    Private Function ConfirmaAjuste() As Boolean
        ConfirmaAjuste = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAjustes_Confirmar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Movimiento", cboMovimientos.SelectedIndex + 1)                        'nro venta SGL
        ''
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
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            ConfirmaAjuste = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function




    Private Function ConfirmarAjuste2() As Boolean
        ConfirmarAjuste2 = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAjustes_Confirmar", con)
        Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        Dim cent_ As String = ""
        Dim clte_ As Integer = 0
        Dim diios_ As String = ""
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

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)


        For i = 0 To lvDIIOS.Items.Count - 1

            cmd.Parameters.Clear()
            'cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", cent_)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Movimiento", cboMovimientos.SelectedIndex + 1)                        'nro venta SGL
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
                    'If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    'End If
                    lvDIIOS.Items(i).SubItems(6).Text = mret   'estado
                    HayError = True
                    'Exit For
                End If

                'HayError = False
                ''si todo sale ok guardamos el nuevo codigo del grupo de celos
                'GrabarGrupoParto = True

            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                lvDIIOS.Items(i).SubItems(6).Text = ex.Message     'estado
                HayError = True
                'Exit For
            End Try

        Next

        If HayError = False Then
            SRVTRANS.Commit()
            ConfirmarAjuste2 = True
        Else
            SRVTRANS.Rollback()
            ConfirmarAjuste2 = False

            If MsgBox("HA OCURRIDO UN ERROR AL GRABAR EL AJUSTE, VERIFIQUE LA COLUMNA ESTADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
        End If

        con.Close()
        Cursor.Current = Cursors.Default
    End Function


    Private Function EliminarDIIOTraslado(ByVal diio_ As Integer) As Boolean
        EliminarDIIOTraslado = False

        'Dim con As New SqlConnection(GetConnectionString())
        'Dim cmd As New SqlCommand("spTraslados_EliminarDetalle", con)
        'Dim rdr As SqlDataReader = Nothing

        'cmd.CommandType = Data.CommandType.StoredProcedure

        'cmd.Parameters.AddWithValue("@Empresa", Empresa)
        'cmd.Parameters.AddWithValue("@CodigoTras", Param10_CodigoTraslado)
        'cmd.Parameters.AddWithValue("@DIIO", diio_)
        'cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        'cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        ''
        'cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        'cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        'Try
        '    con.Open()

        '    Dim Result As Integer = cmd.ExecuteNonQuery()

        '    Dim vret As Integer = cmd.Parameters("@RetValor").Value
        '    Dim mret As String = cmd.Parameters("@RetMensage").Value

        '    If vret > 0 Then
        '        If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '        End If
        '        Exit Function
        '    End If

        '    EliminarDIIOTraslado = True

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        'End Try
    End Function




    Private Sub ConfirmarEliminacionDIIO()
        If lvDIIOS.Items.Count = 0 Then Exit Sub
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim estado_ As String = ""

        estado_ = lvDIIOS.SelectedItems(0).SubItems(6).Text.Trim

        If Param0_ModoIngreso <> 1 Then 'estado_ = "Grabado" Then
            'If MsgBox("¿DESEA ELIMINAR EL DIIO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            '    Dim diio_ As Integer = Val(lvDIIOS.SelectedItems.Item(0).SubItems(1).Text)
            '    'If cod_ = 0 Then Exit Sub

            '    If EliminarDIIOTraslado(diio_) = True Then
            '        'If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            '        'End If

            '        'lvDIIOS.SelectedItems.Item(0).Remove()
            '        lvDIIOS.SelectedItems(0).SubItems(6).Text = "Eliminado (" + Format(Now, "dd-MM-yyyy") + ")"
            '        SumaEliminado()
            '        'RestaSecado()

            '        'If ExistenDIIOsSinGrabar() = False Then
            '        '    btnGrabar.Enabled = False
            '        'End If

            '        'frmSecados.LlenaGrillaSecados()
            '    End If
            'End If

            'Exit Sub
        Else
            If MsgBox("EL DIIO AUN NO SE HA GRABADO, ¿DESEA ELIMINARLO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

                For Each itm As ListViewItem In lvDIIOS.SelectedItems
                    itm.Remove()
                    RestaTraslado()
                Next

                'For i = 0 To lvDIIOS.SelectedItems.Count - 1
                '    lvDIIOS.SelectedItems.Item(i).Remove()
                '    RestaTraslado()
                'Next

                ContabilizaYValidaDIIOs()

                'lvDIIOS.SelectedItems.Item(0).Remove()
                'RestaTraslado()

                'If ExistenDIIOsSinGrabar() = False Then
                '    btnFinalizar.Enabled = False
                '    btnPrevisualizar.Enabled = False

                '    cboMovimientos.Enabled = True
                '    'txtGuia.Enabled = True
                '    cboCentros.Enabled = True
                '    'cboDestinos.Enabled = True
                '    dtpFecha.Enabled = True
                'End If
            End If

            Exit Sub
        End If
    End Sub


    'Private Sub txtDiasGest_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
    '    If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
    '        e.Handled = True
    '    End If
    'End Sub


    Private Sub Cerrar()
        If ExistenDIIOsSinGrabar() = True Then
            If MsgBox("EXISTEN DIIOS SIN GRABAR, ¿DESEA SALIR?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub ProcesarGrabadoOK()
        Dim i As Integer = 0

        For i = 0 To lvDIIOS.Items.Count - 1
            lvDIIOS.Items(i).SubItems(6).Text = "Grabado"
        Next

        frmAjustes.LlenaGrillaAjustes()
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




    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub


    Private Sub mnuCopiarDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR

        If Param0_ModoIngreso = 1 Then
            If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            If GrabarAjuste() = True Then
                If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                End If

                Cursor.Current = Cursors.WaitCursor
                frmAjustes.LlenaGrillaAjustes()
                Me.Close()
                Cursor.Current = Cursors.Default
            End If
        Else
            If MsgBox("¿ DESEA CONFIRMAR EL AJUSTE (SE REFLEJARA EN EL STOCK) ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            If ConfirmaAjuste() = True Then
                If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                End If

                Cursor.Current = Cursors.WaitCursor
                frmAjustes.LlenaGrillaAjustes()
                Me.Close()
                Cursor.Current = Cursors.Default
            End If
        End If

    End Sub



    Private Sub lvDIIOS_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvDIIOS.MouseDoubleClick
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        frmAjustesIngresoDIIO.Param0_ModoIngreso = Param0_ModoIngreso
        frmAjustesIngresoDIIO.Param1_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmAjustesIngresoDIIO.Param2_NombreCentro = cboCentros.Text
        frmAjustesIngresoDIIO.Param3_Movimiento = General.TipoMovimientos.Codigo(cboMovimientos.SelectedIndex)

        frmAjustesIngresoDIIO.MdiParent = frmMAIN
        frmAjustesIngresoDIIO.Show()
        frmAjustesIngresoDIIO.BringToFront()



        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        Dim tot(0, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL AJUSTES " : tot(0, 1) = lblTotAjustes.Text.Trim
        'tot(1, 0) = "TOTAL ENTRADAS " : tot(1, 1) = Label5.Text.Trim
        'tot(2, 0) = "TOTAL SALIDA GANADO " : tot(0, 1) = Label7.Text.Trim
        'tot(3, 0) = "TOTAL ENTRADA GANADO " : tot(1, 1) = Label9.Text.Trim

        ExportToExcelGrilla(lvDIIOS, tot)
    End Sub


    Private Sub btnBastonLee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        LeeBaston()
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        ConfirmarEliminacionDIIO()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub frmAjustesIngreso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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


    Private Sub frmAjustesIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()
        CboLLenaTipoMovimientos()

        If Param0_ModoIngreso = 1 Then
            'Traslado nuevo
            Me.Text = "Nuevo Ingreso de Ajuste"
            Label2.Text = "Total a Ajustar"
            lvDIIOS.MultiSelect = True
            btnCambiar.Left = btnExcel.Left
            btnExcel.Visible = False
            'cboCentros.Text = CentroPorDefecto()
            cboCentros.Text = Param3_NombreCentro

            txtEstado.Text = "EN INGRESO"
        Else
            btnEliminar.Enabled = False     'DESHABILITAMOS MOMENTANEAMENTE

            'edicion de Traslado
            Me.Text = "Edición de Ajuste"
            Label2.Text = "Total de Ajustes"
            lvDIIOS.MultiSelect = False

            cboMovimientos.Text = Param10_MovimientoNom
            cboCentros.Text = Param3_NombreCentro
            dtpFecha.Value = Param4_Fecha
            txtObservs.Text = Param5_Observs

            cboMovimientos.Enabled = False
            cboCentros.Enabled = False
            dtpFecha.Enabled = False

            Select Case Param11_Estado
                Case 1  'CREADA
                    lvDIIOS.Columns(5).Width = lvDIIOS.Columns(5).Width + lvDIIOS.Columns(6).Width
                    lvDIIOS.Columns(6).Width = 0
                    ''
                    'btnFinalizar.Visible = False
                    btnAgregar.Visible = False
                    btnBastonLee.Visible = False
                    btnCambiar.Visible = False
                    ''
                    'If PerfilUsuario >= 3 Then
                    If UsuarioConfirmaAjuste = 1 Then
                        btnFinalizar.Left = btnAgregar.Left
                        btnExcel.Left = btnEliminar.Left
                        btnEliminar.Left = btnBastonLee.Left
                    Else
                        btnFinalizar.Visible = False
                        btnExcel.Left = btnAgregar.Left
                        btnEliminar.Left = btnBastonLee.Left
                    End If

                    txtEstado.Text = "CREADA"
                Case 2  'CONFIRMADA (no se puede hacer nada)
                    txtObservs.Enabled = False
                    ''
                    lvDIIOS.Columns(5).Width = lvDIIOS.Columns(5).Width + lvDIIOS.Columns(6).Width
                    lvDIIOS.Columns(6).Width = 0
                    ''
                    btnFinalizar.Visible = False
                    btnAgregar.Visible = False
                    btnBastonLee.Visible = False
                    btnEliminar.Visible = False
                    btnCambiar.Visible = False
                    ''
                    btnExcel.Left = btnAgregar.Left
                    ''
                    txtEstado.Text = "CONFIRMADA"
            End Select

            BuscarDetalleAjuste()
        End If

        'btnFinalizar.Enabled = False
    End Sub




    Private Sub btnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
        ModificaDatos()
    End Sub


    Private Sub ModificaDatos()
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        fdats = New frmAjustesIngresoTipoAjuste
        Dim TMovimiento As Integer = General.TipoMovimientos.Codigo(cboMovimientos.SelectedIndex)
        fdats.TipoMov = TMovimiento
        fdats.ShowDialog()

        If fdats.Procesa = True Then
            Dim TipoAju_Cod As Integer
            Dim TipoAju_Nom As String = ""

            If TMovimiento = 1 Then
                TipoAju_Cod = General.TiposAjusteSalida.Codigo(fdats.cboTiposAjustes.SelectedIndex)
                TipoAju_Nom = fdats.cboTiposAjustes.Text
            End If

            If TMovimiento = 2 Then
                TipoAju_Cod = General.TiposAjusteEntrada.Codigo(fdats.cboTiposAjustes.SelectedIndex)
                TipoAju_Nom = fdats.cboTiposAjustes.Text
            End If

            ProcesaCambiosAjustes(TipoAju_Cod, TipoAju_Nom)
            ContabilizaYValidaDIIOs()
        End If

        fdats.Dispose()
        fdats = Nothing
    End Sub


    Private Sub ProcesaCambiosAjustes(ByVal TipAjuCod As Integer, ByVal TipAjuNom As String)
        For Each it As ListViewItem In lvDIIOS.SelectedItems
            it.SubItems(7).Text = TipAjuCod
            'it.SubItems(6).Text = ""
            it.SubItems(5).Text = TipAjuNom

            If TipAjuNom.Trim <> "" And it.SubItems(6).Text.Trim = "ERR / SIN TIPO AJUSTE" Then
                it.SubItems(6).Text = ""      'si hay una tipo de ajuste, quitamos error de sin tipo ajuste (limpiamos estado)
            End If
        Next
    End Sub

End Class