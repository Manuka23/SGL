

'Imports Microsoft.Office.Interop.Excel
Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Metadata.W3cXsd2001
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class frmCubiertasIngreso

    Public Param1_Modo As Integer       '1=ingreso cubta / 2=muestra cubtas        --- / 3=muestra sin celo / 4 = muestra celos anormales
    Public Param2_Empresa As Integer
    Public Param3_CentroCod As String
    Public Param3_CentroNom As String
    Public Param4_Fecha As Date
    Public Param4_FechaDesde As Date

    Public ToroCod As String
    Public ToroNom As String
    Public ToroStock As Integer

    'Public Param5_Observs As String
    ''
    'Public Param6_FechaHasta As String

    'declaramos formulario baston
    Private fdats As FrmCubiertasToros


    Private Sub LeeBaston()


        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmCubiertasIngreso"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub


    Private Sub ModificaDatos()
        If cboCentros.SelectedIndex < 0 Then Exit Sub

        Dim cent_ As String = ""
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        fdats = New FrmCubiertasToros
        fdats.Param1_Centro = cent_
        fdats.ShowDialog()

        If fdats.Procesa = True Then
            Dim insem_cod As Integer = General.Inseminadores.Codigo(fdats.cboInseminadores.SelectedIndex)
            Dim insem_nom As String = fdats.cboInseminadores.Text
            Dim toro_nom As String = fdats.cboToros.Text
            Dim toro_cod As String = General.TorosInseminaciones.Codigo(fdats.cboToros.SelectedIndex)
            Dim ndosis As Integer = fdats.txtNroDosis.Text
            Dim iatf As String = ""
            If fdats.chkIATF.Checked = True Then iatf = "SI"

            ProcesaCambiosCubiertas(insem_cod, insem_nom, toro_cod, toro_nom, ndosis, iatf)
        End If

        fdats.Dispose()
        fdats = Nothing
    End Sub


    Private Sub ProcesaCambiosCubiertas(ByVal icod As Integer, ByVal inom As String, ByVal tcod As String, ByVal tnom As String, ByVal ndosis As Integer, ByVal iatf As String)
        For Each it As ListViewItem In lvDIIOS.SelectedItems
            it.SubItems(10).Text = inom
            it.SubItems(3).Text = tnom
            it.SubItems(4).Text = ndosis
            'it.SubItems(5).Text = iatf
            it.SubItems(12).Text = icod
            it.SubItems(14).Text = tcod
        Next
    End Sub


    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i, i2 As Integer
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        Dim TotDiios As Integer
        ''
        Dim step_ As Integer = 1
        Dim insem_cod_ As String = "", insem_nom_ As String = ""
        Dim toro_cod_ As String = "", toro_nom_ As String = ""


        If CheckBox1.Checked = True Then step_ = 2

        If cboInseminadores.SelectedIndex <> -1 Then insem_cod_ = General.Inseminadores.Codigo(cboInseminadores.SelectedIndex)
        If cboInseminadores.SelectedIndex <> -1 Then insem_nom_ = General.Inseminadores.Nombre(cboInseminadores.SelectedIndex)
        If cboToros.SelectedIndex <> -1 Then toro_cod_ = General.TorosInseminaciones.Codigo(cboToros.SelectedIndex)
        If cboToros.SelectedIndex <> -1 Then toro_nom_ = General.TorosInseminaciones.Nombre(cboToros.SelectedIndex)

        Cursor.Current = Cursors.WaitCursor

        lvDIIOS.Items.Clear()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1 Step step_
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","

            Dim item As New ListViewItem((i + 1).ToString)    'nro

            item.SubItems.Add("")
            item.SubItems.Add(diio_)
            item.SubItems.Add(toro_nom_)
            item.SubItems.Add("1")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add(insem_nom_)

            If VerificaDIIOEnGrilla(-1, diio_) = True Then
                item.SubItems.Add("ERR / REPETIDO")
            Else
                item.SubItems.Add("ERR / NO EXISTE EN BD")
            End If

            item.SubItems.Add(insem_cod_)
            item.SubItems.Add("")
            item.SubItems.Add(toro_cod_)

            lvDIIOS.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If

        TotDiios = BuscarDiiosBaston(strdiios_)
        'ContabilizaYValidaDIIOs()

        'si selecciono el CHECK de intercalar inseminador, debemos buscar el inseminador 
        'segun el codigo registrado en el baston (o planilla)
        If CheckBox1.Checked = True Then
            i2 = 0

            For i = 1 To frmBastonV2.lvBASTON.Items.Count - 1 Step step_
                insem_cod_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
                insem_nom_ = BuscaNombreInseminador(insem_cod_)

                If insem_nom_ <> "" Then
                    lvDIIOS.Items(i2).SubItems(10).Text = insem_nom_    'inseminador (puede venir con valor)
                    lvDIIOS.Items(i2).SubItems(12).Text = insem_cod_    'codigo inseminador (puede venir con valor)
                Else
                    lvDIIOS.Items(i2).SubItems(11).Text = "ERR / INSEMINADOR NO EXISTE (" + insem_cod_ + ")"
                End If

                i2 += 1
            Next
        End If

        ''validamos si hay errores para habilitar/deshabilitar boton de finalizacion
        ContabilizaYValidaDIIOs()

        Cursor.Current = Cursors.Default
    End Sub


    Private Function BuscaNombreInseminador(ByVal cod_insem As Integer) As String
        BuscaNombreInseminador = ""

        Dim i As Integer
        Dim nom As String = ""

        For i = 0 To General.Inseminadores.Codigo.Length - 1
            'If Not General.Razas.Codigo(i) Is Nothing Then
            If General.Inseminadores.Codigo(i) = cod_insem Then
                nom = General.Inseminadores.Nombre(i)
                Exit For
            End If
            'End If
        Next

        BuscaNombreInseminador = nom
    End Function


    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvDIIOS.Items.Count - 1
            If i <> pos_ Then
                If lvDIIOS.Items(i).SubItems(2).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function



    Public Sub ContabilizaYValidaDIIOs()
        Dim i As Integer = 0
        'Dim totsec_ As Integer = 0
        Dim err_ As Integer = 0
        Dim estado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            lvDIIOS.Items(i).Text = (i + 1).ToString.Trim
            estado_ = lvDIIOS.Items(i).SubItems(11).Text.Trim

            If Mid(estado_, 1, 3) = "ERR" Then
                err_ += 1
            End If
        Next

        'lblTotCelos.Text = i.ToString.Trim
        'lblTotErrores.Text = err_.ToString.Trim

        If lvDIIOS.Items.Count = 0 Then Exit Sub

        If err_ = 0 Then
            btnFinalizar.Enabled = True
            btnEliminar.Enabled = True
            'btnPrevisualizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
            btnEliminar.Enabled = True
            'btnPrevisualizar.Enabled = False
        End If
    End Sub



    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim CodigoCentro As List(Of Centros) = New List(Of Centros)
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            'cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
            CodigoCentro.Add(New Centros With {
                             .Codigo1 = General.CentrosUsuario.Codigo(i),
                             .Nombre1 = General.CentrosUsuario.Nombre(i)})
        Next
        cboCentros.DataSource = CodigoCentro
        cboCentros.ValueMember = "Codigo1"
        cboCentros.DisplayMember = "Nombre1"
        'cboCentros.SelectedIndex = 0
    End Sub


    Private Sub CboLLenaInseminadores()
        General.Inseminadores.Cargar()
        If General.Inseminadores.NroRegistros = 0 Then Exit Sub

        cboInseminadores.Items.Clear()
        'cboInseminadores.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Inseminadores.NroRegistros - 1
            cboInseminadores.Items.Add(General.Inseminadores.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaToros(ByVal CodigoCentro As String)
        General.TorosInseminaciones.Cargar(CodigoCentro)
        cboToros.Items.Clear()

        If General.TorosInseminaciones.NroRegistros = 0 Then Exit Sub

        Dim i As Integer

        For i = 0 To General.TorosInseminaciones.NroRegistros - 1
            cboToros.Items.Add(General.TorosInseminaciones.Nombre(i))
        Next

        cboToros.SelectedIndex = -1
    End Sub


    Private Sub LimpiaDatos()
        lblCategoria.Text = "---"
        lblEstado.Text = "---"
        lblCentro.Text = "---"
        ''
        lblFecUltCubierta.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        ''
        lblNroCubiertas.Text = "---"
        lblNroPartos.Text = "---"
        lblFecUltParto.Text = "---"

        lblIATF.Text = "---"
    End Sub


    Private Sub AgregaDiio()
        If VerificaDIIOEnGrilla(-1, txtDIIO.Text.Trim) = True Then
            If MsgBox("EL DIIO YA EXISTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            Exit Sub
        End If

        Dim iatf_ As String = ""
        If chkIATF.Checked = True Then iatf_ = "SI"

        Dim item As New ListViewItem((lvDIIOS.Items.Count + 1).ToString)

        item.SubItems.Add("")
        item.SubItems.Add(txtDIIO.Text.Trim)
        item.SubItems.Add(cboToros.Text.Trim)
        item.SubItems.Add(txtNroDosis.Text)
        item.SubItems.Add(iatf_)
        item.SubItems.Add(lblNroCubiertas.Text)
        item.SubItems.Add(lblCategoria.Text)
        item.SubItems.Add(lblEstProductivo.Text)                  'centro
        item.SubItems.Add(lblEstReproductivo.Text)
        item.SubItems.Add(cboInseminadores.Text.Trim)
        item.SubItems.Add("")
        item.SubItems.Add(General.Inseminadores.Codigo(cboInseminadores.SelectedIndex))
        item.SubItems.Add(lblCategoriaCod.Text)
        item.SubItems.Add(General.TorosInseminaciones.Codigo(cboToros.SelectedIndex))

        lvDIIOS.Items.Add(item)

        lvDIIOS.Items(lvDIIOS.Items.Count - 1).Selected = True
        lvDIIOS.EnsureVisible(lvDIIOS.Items.Count - 1)

        LimpiaDatos()

        cboCentros.Enabled = False
        dtpFecha.Enabled = False

        btnFinalizar.Enabled = True
        btnEliminar.Enabled = True

        txtDIIO.Text = ""
        txtDIIO.Focus()
    End Sub


    'devuelve el nro de errores en los diios
    Private Function BuscarDiiosBaston(ByVal diios_ As String) As Integer
        BuscarDiiosBaston = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ListadoBaston", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        'Dim diios_ As String = ""
        'diios_ = GeneraStringDIIOs()
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@FechaConsulta", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvDIIOS.BeginUpdate()
        'lvDIIOS.Items.Clear()
        'Label85.Text = "0"

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim diio_ As String = ""
        Dim est_ As String
        'Dim existe_ As Boolean

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    diio_ = rdr("GndCod").ToString.Trim

                    For i = 0 To lvDIIOS.Items.Count - 1
                        If lvDIIOS.Items(i).SubItems(2).Text.Trim = diio_ Then

                            'lvDIIOS.Items(i).SubItems(3).Text = ""     'nombre toro (puede venir con valor)
                            'lvDIIOS.Items(i).SubItems(4).Text = "1"    'nro de dosis (siempre es 1a dosis)
                            lvDIIOS.Items(i).SubItems(5).Text = ""
                            If rdr("TieneIATF") > 0 Then lvDIIOS.Items(i).SubItems(5).Text = "SI"
                            lvDIIOS.Items(i).SubItems(6).Text = rdr("GndUltCubiertaNum").ToString.Trim

                            lvDIIOS.Items(i).SubItems(7).Text = rdr("GndProNom").ToString.Trim
                            lvDIIOS.Items(i).SubItems(8).Text = rdr("GndEstadoProductivo").ToString.Trim
                            lvDIIOS.Items(i).SubItems(9).Text = rdr("GndEstadoReproductivo").ToString.Trim

                            'lvDIIOS.Items(i).SubItems(10).Text = ""    'inseminador (puede venir con valor)
                            lvDIIOS.Items(i).SubItems(11).Text = ""    'estado
                                'lvDIIOS.Items(i).SubItems(12).Text = ""    'codigo inseminador (puede venir con valor)
                                lvDIIOS.Items(i).SubItems(13).Text = rdr("GndProCod").ToString.Trim
                                'lvDIIOS.Items(i).SubItems(14).Text = ""    'codigo toro (puede venir con valor)

                                If VerificaDIIOEnGrilla(i, diio_) = True Then
                                    lvDIIOS.Items(i).SubItems(11).Text = "ERR / REPETIDO"
                                    'lblTotErrores.Text = Int32.Parse(lblTotErrores.Text) + 1
                                Else
                                    est_ = ""

                                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                                    est_ = "ERR / CENTRO (" + rdr("CenDesCor").ToString.Trim + ")"
                                    lvDIIOS.Items(i).BackColor = Color.FromArgb(241, 148, 138)
                                End If

                                    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                                    est_ = "ERR / VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy")
                                    lvDIIOS.Items(i).BackColor = Color.FromArgb(241, 148, 138)
                                End If

                                    If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                                    est_ = "ERR / MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy")
                                    lvDIIOS.Items(i).BackColor = Color.FromArgb(241, 148, 138)
                                End If

                                    If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                                    est_ = "ERR / DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy")
                                    lvDIIOS.Items(i).BackColor = Color.FromArgb(241, 148, 138)
                                End If

                                    If rdr("GndProNom").ToString.Trim <> "VAQUILLAS" And rdr("GndProNom").ToString.Trim <> "VACAS TRASPASO" And rdr("GndProNom").ToString.Trim <> "VAQUILLAS OTOÑO" And rdr("GndProNom").ToString.Trim <> "VAQUILLAS TRASPASO" And rdr("GndProNom").ToString.Trim <> "VACAS" Then
                                    est_ = "ERR / CATEGORIA (" + rdr("GndProNom").ToString.Trim + ")"
                                    lvDIIOS.Items(i).BackColor = Color.FromArgb(241, 148, 138)
                                End If

                                    'If rdr("GndEstadoSalud").ToString.Trim <> "SANA" Then
                                    '    est_ = "ADVERTENCIA / EST. SALUD (" + rdr("GndEstadoSalud").ToString.Trim + ")"
                                    'End If

                                    'If rdr("GndEstadoReproductivo").ToString.Trim <> "ANESTRO" And rdr("GndEstadoReproductivo").ToString.Trim <> "SECA PRN" Then
                                    '    est_ = "ERR / EST. REPRODUCTIVO (" + rdr("GndEstadoReproductivo").ToString.Trim + ")"
                                    'End If

                                    'validacion de est. reproductivo para vaquillas
                                    If rdr("GndProNom").ToString.Trim = "VAQUILLAS" And (rdr("GndEstadoReproductivo").ToString.Trim = "PREÑADA" Or rdr("GndEstadoReproductivo").ToString.Trim = "CUBIERTA") Then
                                        If rdr("GndEstadoReproductivo").ToString.Trim = "CUBIERTA" Then
                                            est_ = "ADVERTENCIA / EST. REPROD. VAQUILLAS (" + rdr("GndEstadoReproductivo").ToString.Trim + ")"
                                        Else
                                        est_ = "ERR / EST. REPROD. VAQUILLAS (" + rdr("GndEstadoReproductivo").ToString.Trim + ")"
                                        lvDIIOS.Items(i).BackColor = Color.FromArgb(241, 148, 138)
                                    End If
                                    End If

                                    'validacion de est. reproductivo para vacas
                                    If rdr("GndProNom").ToString.Trim = "VACAS" And (rdr("GndEstadoReproductivo").ToString.Trim <> "ANESTRO" And rdr("GndEstadoReproductivo").ToString.Trim <> "SECA PRN") Then
                                        If rdr("GndEstadoReproductivo").ToString.Trim = "PREÑADA" Then
                                        est_ = "ERR / EST. REPROD. VACAS (" + rdr("GndEstadoReproductivo").ToString.Trim + ")"
                                        lvDIIOS.Items(i).BackColor = Color.FromArgb(241, 148, 138)
                                    Else
                                            est_ = "ADVERTENCIA / EST. REPROD. VACAS (" + rdr("GndEstadoReproductivo").ToString.Trim + ")"
                                        End If
                                    End If

                                    If FechaCorrecta(rdr("GndUltCubierta").ToString) = True Then
                                        If Date.Parse(dtpFecha.Value) < rdr("GndUltCubierta") Then
                                        est_ = "ERR / TIENE CUBIERTA CON FECHA MAYOR (" + rdr("GndUltCubierta").ToString.Trim + ")"
                                        lvDIIOS.Items(i).BackColor = Color.FromArgb(241, 148, 138)
                                    End If
                                    End If

                                    'If rdr("GndUltCubierta") > Date.Parse("01-01-2000") Then
                                    '    If Date.Parse(dtpFecha.Value) < rdr("GndUltCubierta") Then
                                    '        est_ = "ERR / TIENE CUBIERTA CON FECHA MAYOR (" + rdr("GndUltCubierta").ToString.Trim + ")"
                                    '    End If
                                    'End If


                                    'If rdr("TieneIATF") > 0 Then
                                    '    est_ = "ERR / TIENE IATF"
                                    'End If

                                    'If est_ <> "" Then lblTotErrores.Text = Int32.Parse(lblTotErrores.Text) + 1

                                    lvDIIOS.Items(i).SubItems(11).Text = est_
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


    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim fpart_, fcub_, fpp_, fcel_, ncel_ As String
        'Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@FechaConsulta", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fpart_ = ""
        fcub_ = ""
        fpp_ = ""
        fcel_ = ""
        ncel_ = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    fcel_ = ""
                    If FechaCorrecta(rdr("GndUltCubierta").ToString) Then fcel_ = Format(rdr("GndUltCubierta"), "dd-MM-yyyy")

                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                        If MsgBox("EL CENTRO DEL ANIMAL (" + rdr("CenDesCor").ToString.Trim + ") NO CORRESPONDE CON EL SELECCIONADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndProNom").ToString.Trim <> "VAQUILLAS" And rdr("GndProNom").ToString.Trim <> "VACAS" And rdr("GndProNom").ToString.Trim <> "VACAS TRASPASO" And rdr("GndProNom").ToString.Trim <> "VAQUILLAS TRASPASO" And rdr("GndProNom").ToString.Trim <> "VAQUILLAS OTOÑO" Then
                        If MsgBox("LA CATEGORIA DEL ANIMAL NO CORRESPONDE A VACAS NI VAQUILLAS (" + rdr("GndProNom").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") <> vbYes Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndEstadoSalud").ToString.Trim <> "SANA" Then
                        If MsgBox("EL ESTADO DE SALUD DEL ANIMAL NO ES SANA (" + rdr("GndEstadoSalud").ToString.Trim + ")" + vbCrLf + "¿DESEA INGRESAR LA CUBIERTA DE TODAS FORMAS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACIÓN") <> vbYes Then
                            Exit Try
                        End If
                    End If

                    'validacion de est. reproductivo para vaquillas
                    If rdr("GndProNom").ToString.Trim = "VAQUILLAS" And (rdr("GndEstadoReproductivo").ToString.Trim = "PREÑADA" Or rdr("GndEstadoReproductivo").ToString.Trim = "CUBIERTA") Then
                        If rdr("GndEstadoReproductivo").ToString.Trim = "CUBIERTA" Then
                            If MsgBox("EL ESTADO REPRODUCTIVO DEL ANIMAL (" + rdr("GndEstadoReproductivo").ToString.Trim + ")" + " NO ES CORRECTO PARA VAQUIILAS (FECHA ULT. CUBIERTA " + fcel_ + ")" + vbCrLf + "¿DESEA INGRESAR LA CUBIERTA DE TODAS FORMAS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACIÓN") <> vbYes Then
                                Exit Try
                            End If
                        Else
                            If MsgBox("EL ESTADO REPRODUCTIVO DEL ANIMAL (" + rdr("GndEstadoReproductivo").ToString.Trim + ")" + " NO ES CORRECTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") <> vbYes Then
                            End If
                            Exit Try
                        End If
                    End If

                    'validacion de est. reproductivo para vacas
                    If rdr("GndProNom").ToString.Trim = "VACAS" And (rdr("GndEstadoReproductivo").ToString.Trim <> "ANESTRO" And rdr("GndEstadoReproductivo").ToString.Trim <> "SECA PRN") Then
                        If rdr("GndEstadoReproductivo").ToString.Trim = "CUBIERTA" Then
                            If MsgBox("EL ESTADO REPRODUCTIVO DEL ANIMAL (" + rdr("GndEstadoReproductivo").ToString.Trim + ")" + " NO ES CORRECTO PARA VACAS (FECHA ULT. CUBIERTA " + fcel_ + ")" + vbCrLf + "¿DESEA INGRESAR LA CUBIERTA DE TODAS FORMAS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACIÓN") <> vbYes Then
                                Exit Try
                            End If
                        ElseIf rdr("GndEstadoReproductivo").ToString.Trim = "PREÑADA" Then
                            If MsgBox("EL ESTADO REPRODUCTIVO DEL ANIMAL (" + rdr("GndEstadoReproductivo").ToString.Trim + ")" + " NO ES CORRECTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") <> vbYes Then
                            End If
                            Exit Try
                        Else
                            If MsgBox("EL ESTADO REPRODUCTIVO DEL ANIMAL (" + rdr("GndEstadoReproductivo").ToString.Trim + ")" + " NO ES CORRECTO PARA VACAS " + vbCrLf + "¿DESEA INGRESAR LA CUBIERTA DE TODAS FORMAS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACIÓN") <> vbYes Then
                                Exit Try
                            End If
                        End If
                    End If

                    'validacion ult cubierta
                    If fcel_ = Format(dtpFecha.Value, "dd-MM-yyyy") Then
                        If MsgBox("EL ANIMAL YA TIENE INGRESADA UNA CUBIERTA LA FECHA ESPECIFICADA (" + fcel_ + ")" + vbCrLf + "¿DESEA INGRESAR LA CUBIERTA DE TODAS FORMAS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACIÓN") <> vbYes Then
                            Exit Try
                        End If
                    End If


                    If FechaCorrecta(rdr("GndUltCubierta").ToString) = True Then
                        If Date.Parse(dtpFecha.Value) < rdr("GndUltCubierta") Then
                            If MsgBox("NO PUEDE INGRESAR UNA CUBIERTA CON LA FECHA MENOR A SU ULTIMA CUBIERTA INGRESADA (" + Format(rdr("GndUltCubierta"), "dd-MM-yyyy") + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                            End If
                            txtDIIO.Focus()
                            Exit Sub
                        End If
                    End If

                    ''
                    If rdr("NumeroCelos") > 0 Then ncel_ = rdr("NumeroCelos").ToString.Trim
                    ''
                    lblCentro.Text = cboCentros.Text
                    lblCategoriaCod.Text = rdr("GndProCod").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
                    lblNroPartos.Text = rdr("GndActPartosNum").ToString.Trim
                    If FechaCorrecta(rdr("GndUltCubierta").ToString) = True Then lblFecUltCubierta.Text = Format(rdr("GndUltCubierta"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("GndUltFechaParto").ToString) = True Then lblFecUltParto.Text = Format(rdr("GndUltFechaParto"), "dd-MM-yyyy")
                    lblNroCubiertas.Text = rdr("GndUltCubiertaNum").ToString.Trim
                    lblNroPartos.Text = rdr("GndActPartosNum").ToString.Trim
                    lblEstado.Text = rdr("GndEstadoSalud").ToString.Trim
                    ''
                    lblIATF.Text = TieneIATF(rdr("TieneIATF"))
                    chkIATF.Checked = False
                    If rdr("TieneIATF") > 0 Then chkIATF.Checked = True
                    ''
                    cboToros.Focus()
                    Existe = True
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


    Private Function TieneIATF(ByVal val_ As Integer) As String
        TieneIATF = "NO"
        If val_ > 0 Then TieneIATF = "SI"
    End Function



    Private Function GrabarGrupoCubiertas() As Boolean
        GrabarGrupoCubiertas = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCubiertas_GrabarGrupo", con)
        Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        Dim cent_ As String = ""
        Dim diios_ As String = ""
        Dim i As Integer = 0
        ''
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        'Dim HayError As Boolean
        Dim ContError As Integer
        Dim ContErrorGrave As Integer


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
        ''

        For i = 0 To lvDIIOS.Items.Count - 1

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", cent_)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            ''
            cmd.Parameters.AddWithValue("@Tipo", 1)         'desde esta pantalla los ingresos de cubiertas siempres son internas
            ''
            cmd.Parameters.AddWithValue("@Inseminador", lvDIIOS.Items(i).SubItems(12).Text.Trim)
            cmd.Parameters.AddWithValue("@DIIO", lvDIIOS.Items(i).SubItems(2).Text.Trim)
            cmd.Parameters.AddWithValue("@Toro", lvDIIOS.Items(i).SubItems(14).Text.Trim)
            cmd.Parameters.AddWithValue("@NroDosis", lvDIIOS.Items(i).SubItems(4).Text.Trim)

            If lvDIIOS.Items(i).SubItems(5).Text = "SI" Then
                cmd.Parameters.AddWithValue("@ConDispositivo", 1)
            Else
                cmd.Parameters.AddWithValue("@ConDispositivo", 0)
            End If

            cmd.Parameters.AddWithValue("@Observs", txtObservs.Text)
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
                    lvDIIOS.Items(i).UseItemStyleForSubItems = False
                    lvDIIOS.Items(i).SubItems(11).ForeColor = Color.Red
                    lvDIIOS.Items(i).SubItems(11).Text = mret   'estado

                    ' HayError = True
                    ContError += 1
                    'Exit For
                End If

                'HayError = False
                ''si todo sale ok guardamos el nuevo codigo del grupo de celos
                'GrabarGrupoParto = True

            Catch ex As Exception
                lvDIIOS.Items(i).UseItemStyleForSubItems = False
                lvDIIOS.Items(i).SubItems(11).ForeColor = Color.Red
                lvDIIOS.Items(i).SubItems(11).Text = "ERROR, " + ex.Message     'estado
                'HayError = True
                ContErrorGrave += 1
                'Exit For
            End Try

        Next


        If ContErrorGrave = 0 Then
            SRVTRANS.Commit()
        Else
            SRVTRANS.Rollback()
            GrabarGrupoCubiertas = False

            If MsgBox("GRUPO DE CUBIERTAS NO GRABADO POR ERRORES GRAVES (REVISAR COLUMNA ESTADO)", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA") = vbOK Then
            End If

            Exit Function
        End If

        'If ContError = 0 Then
        'SRVTRANS.Commit()
        'GrabarGrupoCubiertas = True
        'Else
        'SRVTRANS.Rollback()
        'GrabarGrupoCubiertas = False
        'End If

        If ContError > 0 Then
            GrabarGrupoCubiertas = False
            If ContError = lvDIIOS.Items.Count Then
                If MsgBox("GRUPO DE CUBIERTAS NO GRABADO, POR ERRORES EN LAS INSEMINACIONES (REVISAR COLUMNA ESTADO)", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA") = vbOK Then
                End If
            Else
                If MsgBox("GRUPO DE CUBIERTAS GRABADO, PERO CON ERRORES EN ALGUNAS INSEMINACIONES (REVISAR COLUMNA ESTADO)", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA") = vbOK Then
                End If
            End If
        Else
            GrabarGrupoCubiertas = True
            If MsgBox("GRUPO DE CUBIERTAS GRABADO OK", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Datos Grabado OK") = vbOK Then
            End If
        End If


        con.Close()
        Cursor.Current = Cursors.Default
    End Function


    Public Sub BuscarIngresos()
        'lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = 0
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCubiertas_ListadoIngresos", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Param2_Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param3_CentroCod)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lblTotCelos.Text = "0"

        'lvGanado.Items.Clear()
        lvINGRESOS.BeginUpdate()
        lvINGRESOS.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    'pbProcesa.Maximum = vret
                    'End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(Format(rdr("CubFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("CubTipNombre").ToString.Trim)
                    item.SubItems.Add(rdr("CubTotRegs").ToString.Trim)
                    item.SubItems.Add(rdr("TotalConCIDR").ToString.Trim)
                    item.SubItems.Add(rdr("CubObservs").ToString.Trim)

                    lvINGRESOS.Items.Add(item)

                    'ProcesaTotales(1)

                    i = i + 1
                    'pbProcesa.Value = i
                End While

                'pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvINGRESOS.EndUpdate()

        Cursor.Current = Cursors.Default
        'lblTotCelos.Text = i.ToString.Trim
        'Total_General = i
        'MuestraTotales()
        'pnlProcesa.Visible = False
    End Sub


    Public Sub BuscarDetalleIngresos(ByVal TipoConsulta As Integer)
        'lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = 0
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        Cursor.Current = Cursors.WaitCursor

        Dim fd, fh As Date
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCubiertas_ListadoDetalleIngresos", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        If TipoConsulta = 0 Then
            fd = Param4_Fecha
            fh = Param4_FechaDesde
        Else
            fd = Date.Parse(lvINGRESOS.SelectedItems(0).SubItems(1).Text)
            fh = Date.Parse(lvINGRESOS.SelectedItems(0).SubItems(1).Text)
        End If

        cmd.Parameters.AddWithValue("@Empresa", Param2_Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param3_CentroCod)
        cmd.Parameters.AddWithValue("@FechaDesde", fd)
        cmd.Parameters.AddWithValue("@FechaHasta", fh)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lblTotCelos.Text = "0"

        'lvGanado.Items.Clear()
        lvDIIOS.BeginUpdate()
        lvDIIOS.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0
        Dim iatf_ As String
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    'pbProcesa.Maximum = vret
                    'End If

                    iatf_ = ""
                    If rdr("CuDetIATF").ToString.Trim = "1" Then iatf_ = "SI"


                    Dim item As New ListViewItem((i + 1).ToString.Trim)

                    item.SubItems.Add(Format(rdr("CuDetFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("CuDetDiio").ToString.Trim)
                    item.SubItems.Add(rdr("ToroNombre").ToString.Trim)
                    item.SubItems.Add(rdr("CuDetNroDosis").ToString.Trim)
                    item.SubItems.Add(iatf_)
                    item.SubItems.Add(rdr("GndUltCubiertaNum").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(rdr("CuDetEstProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("CuDetEstReproduct").ToString.Trim)
                    item.SubItems.Add(rdr("InsemNombre").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("CuDetInseminador").ToString.Trim)
                    item.SubItems.Add(rdr("CuDetCategoria").ToString.Trim)
                    item.SubItems.Add(rdr("CuDetToro").ToString.Trim)

                    lvDIIOS.Items.Add(item)

                    'ProcesaTotales(1)

                    i = i + 1
                    'pbProcesa.Value = i
                End While

                'pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvDIIOS.EndUpdate()
        lblTotCub.Text = "Total Cubiertas: " + i.ToString.Trim

        Cursor.Current = Cursors.Default
        'Total_General = i
        'MuestraTotales()
        'pnlProcesa.Visible = False
    End Sub


    Private Function EliminarDIIOCubierta() As Boolean
        EliminarDIIOCubierta = False

        If Param1_Modo = 1 Then
            For Each it As ListViewItem In lvDIIOS.SelectedItems
                lvDIIOS.Items.Remove(it)
            Next

            EliminarDIIOCubierta = True
            Exit Function
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCubiertas_EliminarDetalle", con)
        Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        Dim Result, vret As Integer
        Dim mret As String
        Dim i As Integer = 0
        Dim HayError As Boolean = False
        Dim diio_ As String
        Dim fec_ As Date


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


        'ELIMINAMOS DIIOS SELECCIONADOS
        For Each it As ListViewItem In lvDIIOS.SelectedItems

            diio_ = it.SubItems(2).Text
            fec_ = Date.Parse(it.SubItems(1).Text)

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", Param3_CentroCod)
            cmd.Parameters.AddWithValue("@Fecha", fec_)
            cmd.Parameters.AddWithValue("@DIIO", diio_)
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

                ''verificamos si hay error
                If vret <> 0 Then
                    'If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    'End If
                    it.SubItems(11).Text = mret   'estado
                    HayError = True
                    'Exit For
                Else
                    lvDIIOS.Items.Remove(it)
                End If

                'HayError = False
                ''si todo sale ok guardamos el nuevo codigo del grupo de celos
                'GrabarGrupoParto = True

            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                it.SubItems(11).Text = ex.Message     'estado
                HayError = True
                'Exit For
            End Try

            i = i + 1
        Next


        'If HayError = False Then
        SRVTRANS.Commit()
        EliminarDIIOCubierta = True

        Exit Function


        'Else
        'SRVTRANS.Rollback()
        'EliminarDIIOCubierta = False
        'End If


        'Try
        'con.Open()
        'cmd.CommandType = Data.CommandType.StoredProcedure
        'SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        'cmd.Parameters.AddWithValue("@Empresa", Empresa)
        'cmd.Parameters.AddWithValue("@Centro", Param3_CentroCod)
        'cmd.Parameters.AddWithValue("@Fecha", fec_)
        'cmd.Parameters.AddWithValue("@DIIO", diio_)
        'cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        'cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        ''
        'cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        'cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output



        'Dim Result As Integer = cmd.ExecuteNonQuery()

        'Dim vret As Integer = cmd.Parameters("@RetValor").Value
        'Dim mret As String = cmd.Parameters("@RetMensage").Value

        'If vret > 0 Then
        '    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    Exit Function
        'End If

        'EliminarDIIOCubierta = True

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        'End Try
    End Function


    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        'If txtDIIO.Text = "" Then
        '    If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboCentros.Focus()
        '    Exit Function
        'End If

        If lblEstProductivo.Text = "---" Then
            If MsgBox("DEBE INGRESAR EL DIIO CORRECTAMENTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If cboInseminadores.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN INSEMINADOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboInseminadores.Focus()
            Exit Function
        End If

        If cboToros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TORO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboToros.Focus()
            Exit Function
        End If

        If Not IsNumeric(txtNroDosis.Text) Then
            If MsgBox("DEBE INGRESAR UN NUMERO CORRECTO PARA LAS DOSIS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroDosis.Focus()
            Exit Function
        End If

        'la monta natural va sin inseminador
        If cboToros.Text.Contains("MONTA NATURAL") And Not cboInseminadores.Text.Contains("(SIN INSEMINADOR)") Then
            If MsgBox("UNA CUBIERTA MONTA NATURAL DEBE SER SIN INSEMINADOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboInseminadores.Text = "(SIN INSEMINADOR)"
            Exit Function
        End If

        'la monta natural va sin inseminador
        If cboInseminadores.Text.Contains("(SIN INSEMINADOR)") And Not cboToros.Text.Contains("MONTA NATURAL") Then
            If MsgBox("UNA CUBIERTA SIN INSEMINADOR DEBE SER MONTA NATURAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboToros.Text = "MONTA NATURAL"
            Exit Function
        End If

        ValidacionesLocales = True
    End Function


    Private Function ValidacionesLocales2() As Boolean
        ValidacionesLocales2 = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If


        If lvDIIOS.Items.Count = 0 Then
            If MsgBox("DEBE INGRESAR EL DETALLE DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            'cboCondiciones.Focus()
            Exit Function
        End If


        Dim i As Integer

        For i = 0 To lvDIIOS.Items.Count - 1
            If lvDIIOS.Items(i).SubItems(3).Text = "" Or lvDIIOS.Items(i).SubItems(4).Text = "" Or
                        lvDIIOS.Items(i).SubItems(10).Text = "" Then 'Or lvDIIOS.Items(i).SubItems(5).Text = "" Then
                If MsgBox("FALTA INFORMACION POR COMPLETAR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If
        Next

        ValidacionesLocales2 = True
    End Function


    Private Function ValidacionesLocales3() As Boolean
        ValidacionesLocales3 = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        ValidacionesLocales3 = True
    End Function


    Private Sub EliminarCubierta()
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR LAS CUBIERTAS SELECCIONADAS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If EliminarDIIOCubierta() = True Then
                'If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                'End If

                'Cerrar()

                If Param1_Modo = 1 Then
                    ContabilizaYValidaDIIOs()

                    If lvDIIOS.Items.Count = 0 Then
                        cboCentros.Enabled = True
                        btnFinalizar.Enabled = False
                        btnEliminar.Enabled = False
                    End If
                Else

                    'frmCubiertasPorCentros.LlenaGrilla()
                    'Dim idx As Integer = lvINGRESOS.SelectedItems(0).Index
                    BuscarIngresos()
                    'lvINGRESOS.Items(idx).Selected = True


                    'If chkFiltrarCubiertas.Checked = True Then
                    '    BuscarDetalleIngresos(1)
                    'Else
                    '    BuscarDetalleIngresos(0)
                    'End If

                    'If lvDIIOS.Items.Count = 0 Then
                    '    Cerrar()
                    'End If
                End If
            End If
        End If
    End Sub


    Private Sub DetalleGanado()
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvDIIOS.SelectedItems.Item(0).SubItems(2).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CopiarDiio()
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(2).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Sub btnAsignaDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmCubiertasToros.MdiParent = frmMAIN
        FrmCubiertasToros.Show()
        FrmCubiertasToros.BringToFront()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub Cerrar()
        Me.Close()
    End Sub

    Private Sub btnBastonLee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales3() = False Then Exit Sub

        LeeBaston()

        If lvDIIOS.Items.Count > 0 Then cboCentros.Enabled = False
    End Sub


    Private Sub txtDIIO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
            e.Handled = True
        End If
    End Sub


    Private Sub txtDIIO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDIIO.TextChanged
        If cboCentros.Text <> "" Then
            LimpiaDatos()
        End If

        If txtDIIO.Text.Trim = "" And lvDIIOS.Items.Count = 0 Then
            cboCentros.Enabled = True
        End If
    End Sub


    Private Sub btnBuscarDIIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDIIO.Click
        'txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        'If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        'Exit Sub
        'End If

        AgregaDiio()
    End Sub


    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        'CONFIRMAR

        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If ValidacionesLocales2() = False Then Exit Sub

        'If GrabarGrupoCubiertas() = True Then
        If CubiertasGrabar(lvDIIOS) = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If

            Cursor.Current = Cursors.WaitCursor
            frmCubiertasPorCentros.LlenaGrilla()
            Me.Close()
            Cursor.Current = Cursors.Default
        Else
            lvDIIOS.Columns(11).Width = lvDIIOS.Columns(11).Width + 300
            btnFinalizar.Enabled = False
        End If

    End Sub


    Private Sub cboInseminadores_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboInseminadores.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub cboToros_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboToros.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtNroDosis_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDosis.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub chkIATF_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chkIATF.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnAgregar_Click(sender, e)
        End If
    End Sub


    Private Sub frmCubiertasIngreso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.C Then
                CopiarDiio()
            End If
        End If
    End Sub


    Private Sub chkFiltrarCubiertas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltrarCubiertas.CheckedChanged
        If chkFiltrarCubiertas.Checked = True Then
            lblTotCub.Text = "Total Cubiertas: 0"
            lvDIIOS.Items.Clear()
        Else
            BuscarDetalleIngresos(0)
        End If
    End Sub


    Private Sub cboToros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboToros.SelectedIndexChanged
        'If cboToros.Text.Contains("MONTA NATURAL") Then
        '    cboInseminadores.Text = "(SIN INSEMINADOR)"
        'Else
        '    If cboInseminadores.Text.Contains("SIN INSEMINADOR") Then
        '        cboInseminadores.SelectedIndex = -1
        '    End If
        'End If
        NDosis.Text = General.TorosInseminaciones.Stock(cboToros.SelectedIndex) & " " & General.TorosInseminaciones.UM(cboToros.SelectedIndex)

        'MsgBox(General.TorosInseminaciones.Nombre(cboToros.SelectedIndex))
    End Sub


    Private Sub cboInseminadores_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInseminadores.SelectedIndexChanged
        If cboInseminadores.Text.Contains("SIN INSEMINADOR") Then
            cboToros.Text = "MONTA NATURAL"
        Else
            If cboToros.Text.Contains("MONTA NATURAL") Then
                cboToros.SelectedIndex = -1
            End If
        End If
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        Dim cent_ As String = ""
        If cboCentros.SelectedIndex > -1 Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        'MSTRToros.cboToros_FrmQRY(cent_, cboToros)

        CboLLenaToros(cent_)
    End Sub


    Private Sub btnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
        ModificaDatos()
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "CENTRO: " : tot(0, 1) = cboCentros.Text
        tot(1, 0) = "CUBIERTAS DESDE: " : tot(1, 1) = Format(dtpFechaDesde.Value, "dd-MM-yyyy") + " AL " + Format(dtpFechaHasta.Value, "dd-MM-yyyy")
        tot(2, 0) = "TOTAL CUBIERTAS: " : tot(2, 1) = lvDIIOS.Items.Count.ToString

        ExportToExcelGrilla(lvDIIOS, tot)
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        EliminarCubierta()
    End Sub




    Private Sub lvDIIOS_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvDIIOS.MouseDoubleClick
        DetalleGanado()
    End Sub


    Private Sub FrmCubiertasIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True


        CboLLenaCentros()
        CboLLenaInseminadores()
        'CboLLenaToros()

        'Dim Centro As Integer = cboCentros.SelectedValue

        'MSTRToros.cboToros_FrmQRY(Centro,cboToros)

        chkFiltrarCubiertas.Checked = True

        If Param1_Modo = 1 Then
            btnFinalizar.Enabled = False
            btnEliminar.Enabled = False
            lvDIIOS.ContextMenuStrip = mnuCIDR

            lvDIIOS.Columns(1).Width = 0
            lvDIIOS.Columns(11).Width = 300

            cboCentros.Text = CentroPorDefecto()
        Else
            btnExcel.Left = btnEliminar.Left
            btnEliminar.Left = btnFinalizar.Left
            btnEliminar.Enabled = True
            'btnExcel.Visible = True

            btnFinalizar.Visible = False
            btnBastonLee.Visible = False
            btnCambiar.Visible = False

            cboCentros.Enabled = False
            dtpFecha.Enabled = False
            txtObservs.Enabled = False
            dtpFechaDesde.Enabled = False
            dtpFechaHasta.Enabled = False

            gboxRangoFecha.Visible = True
            grpObserv.Visible = False
            lvINGRESOS.Visible = True
            Label18.Visible = False
            NDosis.Visible = False
            lvDIIOS.Visible = True

            'lvDIIOS.Top = 67
            'lvDIIOS.Height = 414
            lvDIIOS.Columns(1).Width = 70
            lvDIIOS.Columns(2).Width = lvDIIOS.Columns(2).Width + 30
            lvDIIOS.Columns(9).Width = lvDIIOS.Columns(9).Width + 10
            lvDIIOS.Columns(10).Width = 220
            lvDIIOS.Columns(11).Width = 400

            cboCentros.Text = Param3_CentroNom
            dtpFechaDesde.Value = Param4_Fecha
            dtpFechaHasta.Value = Param4_FechaDesde

            BuscarIngresos()
            'BuscarDetalleIngresos(0)
        End If
    End Sub



    Private Sub mnuAgregarCIDR_Click(sender As System.Object, e As System.EventArgs) Handles mnuAgregarCIDR.Click
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        For Each itm As ListViewItem In lvDIIOS.SelectedItems
            itm.SubItems(5).Text = "SI"
        Next
    End Sub


    Private Sub mnuQuitarCIDR_Click(sender As System.Object, e As System.EventArgs) Handles mnuQuitarCIDR.Click
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        For Each itm As ListViewItem In lvDIIOS.SelectedItems
            itm.SubItems(5).Text = ""
        Next
    End Sub

    Private Sub lvINGRESOS_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvINGRESOS.MouseClick
        BuscarDetalleIngresos(1)
    End Sub
    Private Function CubiertasGrabar(ByVal lvDIIOS As ListView) As Boolean
        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCubiertas_Grabar", con)
        Dim table As DataTable = DTCubiertas(lvDIIOS)
        Dim Centro As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
        cmd.Parameters.AddWithValue("@CentroCod", Centro)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@DTCubiertaDetalle", table)
        cmd.Parameters.AddWithValue("@Observs", txtObservs.Text)
        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        Try
            con.Open()
            cmd.ExecuteNonQuery()
            ResultCod = cmd.Parameters("@ResultCod").Value
            ResultMsg = cmd.Parameters("@ResultMsg").Value

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR")
                Return False
                Exit Function
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
            Exit Function
        End Try
        MsgBox("REGISTRO EXITOSO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "VALIDACION")
        Return True
    End Function
    Public Function DTCubiertas(ByVal DIIOS As ListView) As DataTable
        DTCubiertas = Nothing

        Dim table As DataTable = New DataTable("VentasRequerimiento")

        table.Columns.Add("Diio", System.Type.GetType("System.String"))
        table.Columns.Add("ToroCodigo", System.Type.GetType("System.String"))
        table.Columns.Add("ToroNombre", System.Type.GetType("System.String"))
        table.Columns.Add("ToroDosis", System.Type.GetType("System.String"))
        table.Columns.Add("CIDR", System.Type.GetType("System.String"))
        table.Columns.Add("InseminadorCod", System.Type.GetType("System.String"))

        Dim n As Integer
        n = lvDIIOS.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(lvDIIOS.Items(i).SubItems(2).Text,
                            lvDIIOS.Items(i).SubItems(14).Text,
                            lvDIIOS.Items(i).SubItems(3).Text,
                            lvDIIOS.Items(i).SubItems(4).Text,
                            lvDIIOS.Items(i).SubItems(5).Text,
                            lvDIIOS.Items(i).SubItems(12).Text)
        Next
        DTCubiertas = table
    End Function
End Class