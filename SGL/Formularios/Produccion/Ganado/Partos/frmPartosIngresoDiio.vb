



Imports System.Data.SqlClient


Public Class frmPartosIngresoDiios

    Dim UsuarioParto As Integer

    Public Param0_ModoIngreso As Integer           '1 = nuevo  /  2 = edicion
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_Fecha As Date
    Public Param4_DIIO_Madre As Integer
    Private Induccion As String





    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        'cboCentros.SelectedIndex = 0
    End Sub


    Private Sub CboLLenaEstProductivos()
        If General.EstProductivos.NroRegistros = 0 Then Exit Sub

        cboEstProductivos.Items.Clear()
        'cboEstProductivos.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To 2 'General.EstProductivos.NroRegistros - 1
            cboEstProductivos.Items.Add(General.EstProductivos.Nombre(i))
        Next

        cboEstProductivos.SelectedIndex = 0
        'cboEstProductivos.Text = "EN PRODUCCION"
    End Sub


    Private Sub CboLLenaRazas()
        If General.Razas.NroRegistros = 0 Then Exit Sub

        cboRazas.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Razas.NroRegistros - 1
            cboRazas.Items.Add(General.Razas.Nombre(i))
        Next

    End Sub


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
        'lblFecProbParto.Text = "---"
        'lblFecProbSecado.Text = "---"
        'lblDiasSecado.Text = "---"
        'lblDiasLactancia.Text = "---"
    End Sub


    Private Sub DetalleGanado()
        If lvCRIAS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvCRIAS.SelectedItems.Item(0).SubItems(1).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CopiarDiio()
        If lvCRIAS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvCRIAS.SelectedItems(0).SubItems(1).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

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

        If VerificaDIIOEnGrilla(txtDIIO.Text.Trim) = True Then
            If MsgBox("EL DIIO YA ESTA CARGADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            LimpiaDatos()
            txtDIIO.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function


    Private Function ValidacionesLocales2() As Boolean
        ValidacionesLocales2 = False

        If (cboTipoParto.Text = "NORMAL" Or cboTipoParto.Text = "ASISTIDO VIVO") Then
            If (cboSexo.Text = "HEMBRA") Or (cboSexo.Text = "MACHO" And txtDIIOCria.Text.Trim <> "") Then
                If ValidaDIIOCria() = False Then
                    txtDIIOCria.Text = ""
                    txtDIIOCria.Focus()
                    Exit Function
                End If
            End If
        End If
        If Induccion = "No" Then
            If cboTipoParto.Text = "INDUCIDO" Then
                If MsgBox("NO PUEDE INGRESAR PARTO INDUCIDO YA QUE ANIMAL NO ESTA MARCADA PARA INDUCIR.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                cboTipoParto.Focus()
                Exit Function
            End If

        End If
        If cboCentros.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If cboTipoParto.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE PARTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTipoParto.Focus()
            Exit Function
        End If

        If cboEstProductivos.Text.Trim = "" Then
            If MsgBox("DEBE SELECCIONAR UN ESTADO PRODUCTIVO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTipoParto.Focus()
            Exit Function
        End If

        If cboTipoParto.Text = "NORMAL" Or cboTipoParto.Text = "ASISTIDO VIVO" Then
            If cboRazas.Text.Trim = "" Then
                If MsgBox("DEBE SELECCIONAR UNA RAZA PARA LA CRIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                cboRazas.Focus()
                Exit Function
            End If
        End If

        If cboTipoParto.Text = "NORMAL" Or cboTipoParto.Text = "ASISTIDO VIVO" Or cboTipoParto.Text = "T. MUERTO" Or cboTipoParto.Text = "ASISTIDO MUERTO" Then
            If cboSexo.Text.Trim = "" Then
                If MsgBox("DEBE SELECCIONAR UN SEXO PARA LA CRIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                cboSexo.Focus()
                Exit Function
            End If
        End If

        If cboTipoParto.Text = "NORMAL" Or cboTipoParto.Text = "ASISTIDO VIVO" Then
            If txtDIIOCria.Text.Trim = "" Then              'If cboSexo.Text <> "MACHO" And txtDIIOCria.Text.Trim = "" Then
                If MsgBox("DEBE INGRESAR EL DIIO DE LA CRIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                txtDIIOCria.Focus()
                Exit Function
            End If
        End If

        If txtPeso.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR EL PESO DE LA CRIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtPeso.Focus()
            Exit Function
        End If

        If txtDIIOCria.Text.Trim <> "" Then
            If VerificaDIIOEnGrilla(txtDIIOCria.Text.Trim) = True Then
                If MsgBox("EL DIIO YA SE ENCUENTRA REGISTRADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                txtPeso.Focus()
                Exit Function
            End If
        End If


        ValidacionesLocales2 = True
    End Function


    Private Function VerificaDIIOEnGrilla(ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvCRIAS.Items.Count - 1

            If lvCRIAS.Items(i).SubItems(1).Text.Trim = diio_ Then
                existe_ = True
                Exit For
            End If

        Next

        VerificaDIIOEnGrilla = existe_
    End Function


    Private Sub BuscarDetalleCria()
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPartos_ListadoDetalleCrias", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_CodigoCentro) 'Param1_CodigoCentro)
        cmd.Parameters.AddWithValue("@Fecha", Param3_Fecha)
        cmd.Parameters.AddWithValue("@DIIOMadre", Param4_DIIO_Madre)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvCRIAS.BeginUpdate()
        lvCRIAS.Items.Clear()

        Dim i As Integer = 0
        Dim crias As Integer = 0
        Dim hembras As Integer = 0
        Dim sexadas As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'primera columna, para ordenar los datos
                    crias = 0
                    hembras = 0
                    sexadas = 0

                    txtDIIO.Text = rdr("GndCod").ToString.Trim
                    cboTipoParto.Text = rdr("PartoTipo").ToString.Trim

                    If (rdr("PartoCria1").ToString.Trim <> "" And rdr("PartoCria1").ToString.Trim <> "0") Or (rdr("PartoTipo").ToString.Trim <> "") Then
                        Dim item As New ListViewItem("1")
                        item.SubItems.Add(rdr("PartoCria1").ToString.Trim)
                        item.SubItems.Add(rdr("PartoTipo").ToString.Trim)
                        item.SubItems.Add(rdr("PartoRazaCria1").ToString.Trim)
                        item.SubItems.Add(rdr("PartoSexoCria1").ToString.Trim)
                        item.SubItems.Add(rdr("PartoPesoCria1").ToString.Trim)

                        lvCRIAS.Items.Add(item)
                    End If


                    If (rdr("PartoCria2").ToString.Trim <> "" And rdr("PartoCria2").ToString.Trim <> "0") Or (rdr("PartoFiebreLeche").ToString.Trim <> "") Then
                        Dim item As New ListViewItem("2")
                        item.SubItems.Add(rdr("PartoCria2").ToString.Trim)

                        If rdr("PartoFiebreLeche").ToString.Trim = "NO" Then
                            item.SubItems.Add("NORMAL")
                        ElseIf rdr("PartoFiebreLeche").ToString.Trim = "AB" Then
                            item.SubItems.Add("ABORTO")
                        ElseIf rdr("PartoFiebreLeche").ToString.Trim = "T." Then
                            item.SubItems.Add("T. MUERTO")
                        ElseIf rdr("PartoFiebreLeche").ToString.Trim = "AS" Then
                            item.SubItems.Add("ASISTIDO VIVO")
                        ElseIf rdr("PartoFiebreLeche").ToString.Trim = "ASM" Then
                            item.SubItems.Add("ASISTIDO MUERTO")
                        ElseIf rdr("PartoFiebreLeche").ToString.Trim = "IN" Then
                            item.SubItems.Add("INDUCIDO")
                        Else
                            item.SubItems.Add(rdr("PartoTipo").ToString.Trim)
                        End If

                        item.SubItems.Add(rdr("PartoRazaCria2").ToString.Trim)
                        item.SubItems.Add(rdr("PartoSexoCria2").ToString.Trim)
                        item.SubItems.Add(rdr("PartoPesoCria2").ToString.Trim)

                        lvCRIAS.Items.Add(item)
                    End If

                    Exit While
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        lvCRIAS.EndUpdate()

        Cursor.Current = Cursors.Default
    End Sub


    Private Function GrabarParto() As Boolean
        GrabarParto = False

        If lvCRIAS.Items.Count = 0 Then Exit Function

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPartos_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        Dim dc1, dc2, dc3 As Integer
        Dim tp1, tp2, tp3 As String
        Dim sx1, sx2, sx3 As String
        Dim ps1, ps2, ps3 As Integer
        Dim rz1, rz2, rz3 As String


        dc1 = 0 : dc2 = 0 : dc3 = 0
        tp1 = "" : tp2 = "" : tp3 = ""
        sx1 = "" : sx2 = "" : sx3 = ""
        ps1 = 0 : ps2 = 0 : ps3 = 0
        rz1 = "" : rz2 = "" : rz3 = ""

        If lvCRIAS.Items.Count >= 1 Then
            dc1 = Int32.Parse(IIf(lvCRIAS.Items(0).SubItems(1).Text.Trim <> "", lvCRIAS.Items(0).SubItems(1).Text.Trim, "0"))
            tp1 = lvCRIAS.Items(0).SubItems(2).Text
            sx1 = lvCRIAS.Items(0).SubItems(4).Text
            ps1 = Int32.Parse(lvCRIAS.Items(0).SubItems(5).Text)
            rz1 = lvCRIAS.Items(0).SubItems(3).Text
        End If

        If lvCRIAS.Items.Count >= 2 Then
            dc2 = Int32.Parse(IIf(lvCRIAS.Items(1).SubItems(1).Text.Trim <> "", lvCRIAS.Items(1).SubItems(1).Text.Trim, "0"))
            tp2 = lvCRIAS.Items(1).SubItems(2).Text
            sx2 = lvCRIAS.Items(1).SubItems(4).Text
            ps2 = Int32.Parse(lvCRIAS.Items(1).SubItems(5).Text)
            rz2 = lvCRIAS.Items(1).SubItems(3).Text
        End If

        If lvCRIAS.Items.Count >= 3 Then
            dc3 = Int32.Parse(IIf(lvCRIAS.Items(2).SubItems(1).Text.Trim <> "", lvCRIAS.Items(2).SubItems(1).Text.Trim, "0"))
            tp3 = lvCRIAS.Items(2).SubItems(2).Text
            sx3 = lvCRIAS.Items(2).SubItems(4).Text
            ps3 = Int32.Parse(lvCRIAS.Items(2).SubItems(5).Text)
            rz3 = lvCRIAS.Items(2).SubItems(3).Text
        End If

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentrosUsuario.Codigo(cboCentros.SelectedIndex)) 'Param1_CodigoCentro)
        cmd.Parameters.AddWithValue("@CentroNom", cboCentros.Text) ' Param2_NombreCentro)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@DIIOMadre", txtDIIO.Text.Trim)
        cmd.Parameters.AddWithValue("@TipoParto", tp1)
        cmd.Parameters.AddWithValue("@TipoParto2", tp2)
        cmd.Parameters.AddWithValue("@EstProductivo", cboEstProductivos.Text)
        cmd.Parameters.AddWithValue("@Observs", txtobservacion.Text)

        cmd.Parameters.AddWithValue("@DIIOCria1", dc1)
        cmd.Parameters.AddWithValue("@SexoCria1", sx1)
        cmd.Parameters.AddWithValue("@PesoCria1", ps1)
        cmd.Parameters.AddWithValue("@RazaCria1", rz1)

        cmd.Parameters.AddWithValue("@DIIOCria2", dc2)
        cmd.Parameters.AddWithValue("@SexoCria2", sx2)
        cmd.Parameters.AddWithValue("@PesoCria2", ps2)
        cmd.Parameters.AddWithValue("@RazaCria2", rz2)

        cmd.Parameters.AddWithValue("@DIIOCria3", dc2)
        cmd.Parameters.AddWithValue("@SexoCria3", sx2)
        cmd.Parameters.AddWithValue("@PesoCria3", ps2)
        cmd.Parameters.AddWithValue("@RazaCria3", rz2)

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If


            GrabarParto = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function


    Private Function ValidaEstadoAnimal(ByVal evend As String, ByVal emue As String, ByVal edesap As String) As Boolean
        ValidaEstadoAnimal = False

        Dim est_ As String = ""

        If evend = "SI" Or emue = "SI" Or edesap = "SI" Then
            If evend = "SI" Then est_ = "VENDIDO"
            If emue = "SI" Then est_ = "MUERTO"
            If edesap = "SI" Then est_ = "DESAPARECIDO"

            If MsgBox("EL ESTADO DEL DIIO NO ES DE STOCK (" + est_ + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
            End If

            Exit Function
        End If

        ValidaEstadoAnimal = True
    End Function


    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If cboCentros.SelectedIndex = -1 Or cboCentros.Text.Trim = "" Then ' Label15.Text Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
            End If
            txtDIIO.Text = ""
            cboCentros.Focus()
            Exit Sub
        End If

        Label17.Visible = False
        Label18.Visible = False
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim fup_, fpp_, fsec_ As String

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@FechaConsulta", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fup_ = ""
        fpp_ = ""
        fsec_ = ""

        Dim evend As String = ""
        Dim emue As String = ""
        Dim edesap As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    Existe = True

                    evend = rdr("GndIsVendido").ToString.Trim
                    emue = rdr("GndIsMuerto").ToString.Trim
                    edesap = rdr("GndIsDesaparecido").ToString.Trim

                    If ValidaEstadoAnimal(evend, emue, edesap) = False Then
                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                        Exit Try
                    End If

                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then ' Label15.Text Then
                        If MsgBox("EL DIIO NO PERTENECE AL CENTRO SELECCIONADO (" + rdr("CenDesCor").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                        End If

                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                        Exit Try
                    End If

                    If rdr("GndEstadoReproductivo").ToString.ToUpper.Trim <> "PREÑADA" Then
                        If MsgBox("EL ESTADO REPRODUCTIVO NO ES PREÑADA (" + rdr("GndEstadoReproductivo").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                        End If

                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                        Exit Try
                    End If

                    lblCentro.Text = rdr("CenDesCor").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
                    'LblRazaMadre.Text = rdr("RazaCod")

                    If lblCategoria.Text.ToUpper = "VAQUILLA" Then
                        Label17.Visible = True
                        Label18.Visible = True
                    End If

                    ' cboRazas.Text = rdr("RazaCod")

                    lblNroPartos.Text = rdr("GndActPartosNum").ToString.Trim
                    LblFecPriParto.Text = rdr("GndUltFechaPriPartos").ToString.Trim
                    lblFecUltParto.Text = rdr("GndUltFechaParto").ToString.Trim

                    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                        lblEstado.Text = "VENDIDO"
                    ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        lblEstado.Text = "MUERTO"
                    ElseIf rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        lblEstado.Text = "DESAPARECIDO"
                    Else
                        lblEstado.Text = "STOCK"
                    End If

                    Exit While
                End While
                Induccion = rdr("Induccion").ToString.Trim
                If Existe = False Then
                    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                Else
                    If Param0_ModoIngreso = 1 Then
                        HabilitarControles1(True)
                        cboTipoParto.SelectedIndex = 0

                        cboTipoParto.Focus()
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


    Public Sub ConsultaDIIO2(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
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

        'EstadoSecado = ""

        Dim evend As String = ""
        Dim emue As String = ""
        Dim edesap As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    Existe = True

                    lblCentro.Text = rdr("CenDesCor").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim

                    lblNroPartos.Text = rdr("GndActPartosNum").ToString.Trim
                    LblFecPriParto.Text = rdr("GndUltFechaPriPartos").ToString.Trim
                    lblFecUltParto.Text = rdr("GndUltFechaParto").ToString.Trim


                    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                        lblEstado.Text = "VENDIDO"
                    ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        lblEstado.Text = "MUERTO"
                    ElseIf rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        lblEstado.Text = "DESAPARECIDO"
                    Else
                        lblEstado.Text = "STOCK"
                    End If

                    Exit While
                End While

                If Existe = False Then
                    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
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

    Private Function ValidaDIIOCria() As Boolean
        ValidaDIIOCria = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPartos_VerificaDiioCria", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentrosUsuario.Codigo(cboCentros.SelectedIndex)) 'Param1_CodigoCentro)
        cmd.Parameters.AddWithValue("@DIIO", txtDIIOCria.Text.Trim)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
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

            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            ValidaDIIOCria = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub HabilitarControles1(Optional ByVal ena_ As Boolean = False)
        cboTipoParto.Enabled = ena_
        cboEstProductivos.Enabled = ena_
        cboRazas.Enabled = ena_
        cboSexo.Enabled = ena_
        txtDIIOCria.Enabled = ena_
        txtPeso.Enabled = ena_
        btnAgregar.Enabled = ena_
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales2() = False Then
            Exit Sub
        End If

        If cboTipoParto.Text = "NORMAL" Or cboTipoParto.Text = "ASISTIDO VIVO" Then
        ElseIf cboTipoParto.Text = "T. MUERTO" Or cboTipoParto.Text = "ASISTIDO MUERTO" Then
            cboRazas.Enabled = False
            txtPeso.Enabled = False
            txtDIIOCria.Enabled = False
        Else
            btnAgregar.Enabled = False
            cboSexo.Enabled = False
            cboRazas.Enabled = False
            txtPeso.Enabled = False
            txtDIIOCria.Enabled = False
        End If

        Dim i As Integer = lvCRIAS.Items.Count + 1

        Dim item As New ListViewItem(i.ToString.Trim)                   'primera columna, contador

        item.SubItems.Add(txtDIIOCria.Text.Trim)
        item.SubItems.Add(cboTipoParto.Text.Trim)
        item.SubItems.Add(cboRazas.Text.Trim)
        item.SubItems.Add(cboSexo.Text.Trim)
        item.SubItems.Add(txtPeso.Text.Trim)

        lvCRIAS.Items.Add(item)

        cboSexo.SelectedIndex = -1
        txtDIIOCria.Text = ""
        cboCentros.Enabled = False
        dtpFecha.Enabled = False
        btnBuscar.Enabled = False
        cboTipoParto.Enabled = False
        txtDIIO.Enabled = False
        btnFinalizar.Enabled = True
        btnEliminar.Enabled = True

        If lvCRIAS.Items.Count >= 2 Then
            btnAgregar.Enabled = False
        End If

        btnFinalizar.Focus()
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub txtDIIO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
            e.Handled = True
        End If
    End Sub


    Private Sub txtPeso_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPeso.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIOCria.Focus()
            e.Handled = True
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
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



    Private Sub btnFinalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnFinalizar.Click

        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarParto() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            Cursor.Current = Cursors.WaitCursor
            'frmTraslados.LlenaGrillaTraslados()
            'Me.Close()

            LimpiaDatos(True)

            'txtDIIO.Text = ""
            'txtDIIOCria.Text = ""
            'txtPeso.Text = ""
            cboCentros.Enabled = True
            dtpFecha.Enabled = True
            txtDIIO.Enabled = True
            btnBuscar.Enabled = True

            lvCRIAS.Items.Clear()

            Label17.Visible = False
            Label18.Visible = False

            cboTipoParto.Enabled = False
            cboSexo.Enabled = False
            cboRazas.Enabled = False
            txtPeso.Enabled = False
            txtDIIOCria.Enabled = False
            btnAgregar.Enabled = False
            cboEstProductivos.Text = "EN PRODUCCION"
            cboEstProductivos.Enabled = False

            btnFinalizar.Enabled = False
            btnEliminar.Enabled = False

            txtDIIO.Focus()

            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        'si no es un nuevo ingreso (1), salimos
        If Param0_ModoIngreso <> 1 Then Exit Sub
        'If lvCRIAS.Items.Count = 0 Then Exit Sub
        If lvCRIAS.SelectedItems.Count = 0 Then Exit Sub

        'Dim cod_ As Integer = lvGanado.SelectedItems.Item(0).SubItems(1).Text
        'If cod_ = 0 Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA ELIMINAR LA CRIA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        lvCRIAS.SelectedItems(0).Remove()

        If lvCRIAS.Items.Count = 0 Then
            cboCentros.Enabled = True
            dtpFecha.Enabled = True
            txtDIIO.Enabled = True
            btnBuscar.Enabled = True

            btnFinalizar.Enabled = False
            btnEliminar.Enabled = False

            txtDIIO.Enabled = True
        End If

        cboTipoParto.Focus()
        'SendKeys.Send("{F4}")

        btnAgregar.Enabled = True
    End Sub


    Private Sub ProcesaSeleccionTipoParto()
        If Param0_ModoIngreso = 1 Then
            If cboTipoParto.Text = "NORMAL" Or cboTipoParto.Text = "ASISTIDO VIVO" Then
                cboSexo.Enabled = True
                cboRazas.Enabled = True
                txtPeso.Enabled = True
                txtDIIOCria.Enabled = True
                cboRazas.Text = LblRazaMadre.Text
                cboSexo.Focus()
                'SendKeys.Send("{F4}")
            Else
                If cboTipoParto.Text = "T. MUERTO" Or cboTipoParto.Text = "ASISTIDO MUERTO" Then
                    cboSexo.Enabled = True
                    cboRazas.Enabled = False
                    txtPeso.Enabled = False
                    txtDIIOCria.Enabled = False
                    cboRazas.SelectedIndex = -1
                    txtPeso.Text = "0"
                    cboSexo.Focus()
                    'SendKeys.Send("{F4}")
                Else
                    cboSexo.Enabled = False
                    cboRazas.Enabled = False
                    txtPeso.Enabled = False
                    txtDIIOCria.Enabled = False
                    cboSexo.SelectedIndex = -1
                    cboRazas.SelectedIndex = -1
                    txtPeso.Text = "0"
                    btnAgregar.Focus()
                End If
            End If

            'cboSexo.SelectedIndex = -1
            'cboRazas.Text = LblRazaMadre.Text
            'txtPeso.Text = "0"
            txtDIIOCria.Text = ""
        End If
    End Sub


    Private Sub ProcesaSeleccionRaza()
        If cboRazas.SelectedIndex <> -1 Then
            txtPeso.Text = General.Razas.Peso(cboRazas.SelectedIndex)
        End If
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If cboCentros.SelectedIndex <> -1 Then
            dtpFecha.Enabled = True
            txtDIIO.Enabled = True
            btnBuscar.Enabled = True

            txtDIIO.Focus()
        End If
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFecha.ValueChanged
        txtDIIO.Focus()
    End Sub


    Private Sub frmPartosIngresoDiios_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.C Then
                CopiarDiio()
            End If
        End If
    End Sub


    Private Sub frmPartosIngresoDiios_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtDIIO.Focus()
    End Sub


    Private Sub frmPartosIngresoDiios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()
        CboLLenaEstProductivos()
        CboLLenaRazas()

        'Label15.Text = Param2_NombreCentro
        dtpFecha.Enabled = False
        txtDIIO.Enabled = False
        btnBuscar.Enabled = False

        'If Param1_CodigoCentro > 0 Then
        '    cboCentros.Text = Param2_NombreCentro
        'Else
        '    cboCentros.SelectedIndex = -1
        'End If

        If Param2_NombreCentro <> "" Then
            cboCentros.Text = Param2_NombreCentro
        End If

        If Param0_ModoIngreso = 1 Then
            'nuevo parto

        Else
            'muestra y edita parto
            cboCentros.Enabled = False
            dtpFecha.Enabled = False
            txtDIIO.Enabled = False
            btnBuscar.Enabled = False

            BuscarDetalleCria()
            ConsultaDIIO2(txtDIIO.Text)
        End If
    End Sub


    Private Sub cboTipoParto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTipoParto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            'ProcesaSeleccionTipoParto()
            '    cboSexo.Focus()
            '    SendKeys.Send("{F4}")
            '    cboSexo.Focus()
        End If
    End Sub


    Private Sub cboSexo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboSexo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            '    cboRazas.Focus()
            '    SendKeys.Send("{F4}")
            '    cboRazas.Focus()

        End If
    End Sub


    Private Sub cboRazas_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboRazas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            '    txtPeso.Focus()
        End If
    End Sub


    Private Sub txtDIIOCria_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIOCria.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnAgregar_Click(sender, e)
        End If
    End Sub


    Private Sub cboTipoParto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoParto.SelectedIndexChanged
        'ProcesaSeleccionTipoParto()
    End Sub

    Private Sub cboRazas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboRazas.SelectedIndexChanged
        'ProcesaSeleccionRaza()
    End Sub


    Private Sub cboTipoParto_LostFocus(sender As System.Object, e As System.EventArgs) Handles cboTipoParto.LostFocus
        ProcesaSeleccionTipoParto()
    End Sub

    Private Sub cboRazas_LostFocus(sender As System.Object, e As System.EventArgs) Handles cboRazas.LostFocus
        ProcesaSeleccionRaza()
    End Sub
End Class