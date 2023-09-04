Imports System.Data.SqlClient

Public Class frmCambioDeCategoriasIngreso
    Public Param1_Modo As Integer       '1=ingreso celo / 2=muestra celo / 3=muestra sin celo / 4 = muestra celos anormales
    Public Param2_Empresa As Integer
    Public Param3_CentroCod As String
    Public Param3_CentroNom As String
    Public Param4_FechaDesde As Date
    Public Param4_FechaHasta As Date
    Public Param5_Observs As String
    Private Sub frmCambioDeCategoriasIngreso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CboLLenaCentros()

        btnAgregar.Enabled = False
        btnFinalizar.Enabled = False
        btnEliminar.Enabled = False
        dtpFecha.Enabled = True
        cboCentros.Enabled = True
    End Sub

    Private Sub txtDiio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If ValidacionesDiio(txtDiio.Text.Trim) = True Then
                btnAgregar.Enabled = True
                'e.Handled = True
            End If
            Exit Sub
        End If
    End Sub


    Dim CategoriaCodActual As String
    Dim CategoriaNomActual As String
    Dim CategoriaCodNuevo As String
    Dim CategoriaNomNuevo As String
    'Validacion del Diio vs Informacion de la Base de Datos.
    Private Function ValidacionesDiio(ByVal diio_ As String) As Boolean
        ValidacionesDiio = False
        '
        If dtpFecha.Value > Now() Then
            MsgBox("NO pude seleccionar una fecha mayor a la actual.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia - Fecha.")
            dtpFecha.Value = Now()
            Exit Function
        End If

        If BuscaDiioEnListView(txtDiio.Text) = True Then
            MsgBox("El Diio que intenta Ingresar, ya se encuentra en los registrosa a procesar.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Advertencia - Duplicidad de Datos.")
            Exit Function
        End If

        '
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", diio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
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
                    CategoriaCodActual = rdr("GndProCod").ToString.Trim
                    CategoriaNomActual = rdr("GndProNom").ToString.Trim

                    If rdr("GndProCod").ToString.Trim.IndexOf("H003") Then
                        If rdr("GndProCod").ToString.Trim.IndexOf("MTRN") Then
                            MsgBox("SOLO PUEDE PUEDE CAMBIAR TERNEROS Y TERNERAS.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia")
                            Exit Function
                        End If
                    End If

                    If CategoriaCodActual = "H003" Then
                        CategoriaCodNuevo = "MTRN"
                        CategoriaNomNuevo = "TERNEROS"

                    ElseIf CategoriaCodActual = "MTRN" Then
                        CategoriaCodNuevo = "H003"
                        CategoriaNomNuevo = "TERNERAS"
                    End If

                    If CategoriaCodActual = "H003-01" Then
                        CategoriaCodNuevo = "MTRN-01"
                        CategoriaNomNuevo = "TERNERO EN LECHE"

                    ElseIf CategoriaCodActual = "MTRN-01" Then
                        CategoriaCodNuevo = "H003-01"
                        CategoriaNomNuevo = "TERNERA EN LECHE"
                    End If
                    CatNuevatxt.Text = CategoriaNomNuevo

                    Existe = True
                End While

                If Existe = False Then
                    ValidacionesDiio = False
                    MsgBox("EL DIIO INGRESADO (" + diio_ + ") NO EXISTE")
                End If
                If CategoriaCodActual <> "" Then
                    ValidacionesDiio = True
                    txtCategoriaActual.Text = CategoriaNomActual
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        BtnAgregarEvento()
    End Sub

    Private Sub btnAgregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnAgregar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            BtnAgregarEvento()
        End If
    End Sub

    Private Sub BtnAgregarEvento()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Validaciones
        If dtpFecha.Value > Now() Then
            MsgBox("NO pude seleccionar una fecha mayor a la actual.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia - Fecha.")
            dtpFecha.Value = Now()
            Exit Sub
        End If



        Dim n As Integer
        n = lvCambioCategorias.Items.Count.ToString
        For i = 0 To n - 1
            If txtDiio.Text.Trim = lvCambioCategorias.Items(i).SubItems(2).Text.Trim Then
                MsgBox("Diio ya ingresado en la tabla.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia - Diio repetido")
                Exit Sub
            End If
        Next
        If ConsultaDIIO(txtDiio.Text) = True Then
            MsgBox("Diio ya tiene un cambio de categoria el dia de hoy.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia - Diio ya ingresado ")
            Exit Sub
        End If
        'Fin Validaciones
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        AgregaDatosListView(txtDiio.Text.Trim, CategoriaCodActual, CategoriaNomActual)
        '
        btnAgregar.Enabled = False
        txtDiio.Text = ""
        CatNuevatxt.Text = ""
        txtCategoriaActual.Text = ""
        txtDiio.Focus()
    End Sub

    Dim fechaReg_ As String
    Dim CentroReg_ As String
    'Public contadorListView As Integer = 0

    Public Function ConsultaDIIO(ByVal diio_ As String) As Boolean
        fechaReg_ = dtpFecha.Value

        ConsultaDIIO = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCambioDeCategorias_ConsultaDiio", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@FechaCambio", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@CodigoDIIO", diio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If rdr("Diio").ToString.Trim <> "" Then
                        ConsultaDIIO = True
                    Else
                        ConsultaDIIO = False
                        Exit Function
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
    End Function
    Private Sub AgregaDatosListView(ByVal diio_ As String, ByVal CategoCodActual As String, ByVal CategoNomActual As String)
        'Solo la primera vez
        If lvCambioCategorias.Items.Count = 0 Then
            'Variables Publicas - Fecha y Centro para usar en cualquier momento.
            fechaReg_ = dtpFecha.Value
            CentroReg_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
            'Deshabilitar la fecha y el Centro para que solo sea cambiado cuando finalicen 
            dtpFecha.Enabled = False
            cboCentros.Enabled = False
            btnFinalizar.Enabled = True
            btnEliminar.Enabled = True
        End If
        '
        Dim ObsAutomatica As String = " ** Cambio de Sexo. **"

        '
        Dim item As New ListViewItem(Str(lvCambioCategorias.Items.Count + 1))    'primera columna, para ordenar los datos

        item.SubItems.Add(Empresa) 'Columna Empresa
        item.SubItems.Add(diio_) 'Columna Diio Anterior
        item.SubItems.Add(CategoCodActual) 'Columna Codigo Categoria Actual
        item.SubItems.Add(CategoNomActual) 'Columna Nombre Categoria Actual
        item.SubItems.Add(CategoriaCodNuevo) 'Columna Codigo Categoria Destino
        item.SubItems.Add(CategoriaNomNuevo) 'Columna Nombre Categoria Destino
        item.SubItems.Add(txtObs.Text & ObsAutomatica) 'Columna Observacion

        lvCambioCategorias.Items.Add(item) 'Agrega los Items

    End Sub

    'Boton Finalizar - Graba todos los datos en la BD
    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click

        Dim num As Integer

        num = lvCambioCategorias.Items.Count.ToString
        For i = 0 To num - 1
            If lvCambioCategorias.Items(i).BackColor = Color.Red Then
                If MsgBox("PARA GRABAR DATOS, ELIMINAR ERRORES", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
        Next



        If lvCambioCategorias.Items.Count = 0 Then
            MsgBox("No existen datos para Grabar.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia")
            Exit Sub
        End If
        If MsgBox("¿Desea Procesar los Diios de la Lista?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        '
        Dim validaGrabacion As Integer = 1
        Dim Err As String = ""
        Cursor.Current = Cursors.WaitCursor
        For lin = 0 To lvCambioCategorias.Items.Count - 1 'And validaGrabacion = 0
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spCambioDeCategorias_Grabar", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@CentroCod", CentroReg_)
            cmd.Parameters.AddWithValue("@FechaCambio", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Arete", lvCambioCategorias.Items(lin).SubItems(2).Text.ToString.Trim)
            cmd.Parameters.AddWithValue("@CategoCodAnt", lvCambioCategorias.Items(lin).SubItems(3).Text.ToString.Trim)
            cmd.Parameters.AddWithValue("@CategoCodNueva", lvCambioCategorias.Items(lin).SubItems(5).Text.ToString.Trim)
            cmd.Parameters.AddWithValue("@Observacion", lvCambioCategorias.Items(lin).SubItems(7).Text.ToString.Trim)
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
                Err = mret
                If vret = 0 Then
                    lvCambioCategorias.Items(lin).BackColor = System.Drawing.Color.Red
                    lvCambioCategorias.Items(lin).ForeColor = Color.White
                    validaGrabacion = 0
                End If

                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                validaGrabacion = 0
                con.Close()
            End Try
        Next
        If validaGrabacion = 1 Then
            MsgBox("El proceso a finalizado Satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FINALIZAR - OK")
            Me.Close()
            frmCambioDeCategoriaCargaMasiva.MostrarDatosLV()
        Else
            MsgBox(Err, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "FINALIZAR - CON ERRORES")
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lvCambioCategorias.Items.Count = 0 Then Exit Sub
        If lvCambioCategorias.SelectedItems.Count = 0 Then Exit Sub


        If MsgBox("¿Desea Eliminar el Cambio Seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarCambioCategoriaListView() = True Then

        End If
    End Sub

    Private Function EliminarCambioCategoriaListView() As Boolean
        EliminarCambioCategoriaListView = False

        'Elimina la fila seleccionada
        lvCambioCategorias.Items.Remove(lvCambioCategorias.SelectedItems(0))
        EliminarCambioCategoriaListView = True

    End Function

    Private Function BuscaDiioEnListView(ByVal diio_ As String) As Boolean
        BuscaDiioEnListView = False
        Dim ValorDiio As String = ""
        For lin = 0 To lvCambioCategorias.Items.Count - 1
            ValorDiio = lvCambioCategorias.Items(lin).SubItems(2).Text.ToString.Trim
            If ValorDiio = diio_ Then
                lvCambioCategorias.Items(lin).BackColor = System.Drawing.Color.Yellow
                BuscaDiioEnListView = True
            End If
        Next
    End Function

    Private Sub txtDiio_TextChanged(sender As Object, e As EventArgs) Handles txtDiio.TextChanged

    End Sub
    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False




        'If cboCentros.SelectedIndex = -1 Then
        '    If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboCentros.Focus()
        '    Exit Function
        'End If

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If


        ValidacionesLocales = True
    End Function
    Private Sub btnBastonLee_Click(sender As Object, e As EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales() = False Then Exit Sub

        LeeBaston()

        If lvCambioCategorias.Items.Count > 0 Then cboCentros.Enabled = False
        txtDiio.Enabled = False
        btnFinalizar.Enabled = Enabled
    End Sub

    Private Sub LeeBaston()

        If Param1_Modo = 3 Or Param1_Modo = 4 Then
            frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        End If

        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmCambioDeCategoriasIngreso"
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
        lvCambioCategorias.Items.Clear()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","

            Dim item As New ListViewItem((i + 1).ToString)    'nro

            item.SubItems.Add("")
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

            lvCambioCategorias.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If
        TotDiios = BuscarDiiosBaston(strdiios_)
        ContabilizaYValidaDIIOs()

        Cursor.Current = Cursors.Default
    End Sub
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
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvCambioCategorias.BeginUpdate()
        'lvDIIOS.Items.Clear()
        'Label85.Text = "0"

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim diio_ As String = ""
        Dim est_ As String = ""
        'Dim existe_ As Boolean

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    diio_ = rdr("GndCod").ToString.Trim

                    For i = 0 To lvCambioCategorias.Items.Count - 1
                        If lvCambioCategorias.Items(i).SubItems(2).Text.Trim = diio_ Then
                            lvCambioCategorias.Items(i).SubItems(1).Text = rdr("EmpRut").ToString.Trim
                            lvCambioCategorias.Items(i).SubItems(3).Text = rdr("GndProCod").ToString.Trim
                            lvCambioCategorias.Items(i).SubItems(4).Text = rdr("GndProNom").ToString.Trim

                            If rdr("GndProCod").ToString.Trim = "H003" Then
                                lvCambioCategorias.Items(i).SubItems(5).Text = "MTRN"
                                lvCambioCategorias.Items(i).SubItems(6).Text = "TERNEROS"
                            Else
                                lvCambioCategorias.Items(i).SubItems(5).Text = "H003"
                                lvCambioCategorias.Items(i).SubItems(6).Text = "TERNERAS"
                            End If




                            If VerificaDIIOEnGrilla(i, diio_) = True Then
                                lvCambioCategorias.Items(i).SubItems(7).Text = "ERR / REPETIDO"
                                lblTotErrores.Text = Int32.Parse(lblTotErrores.Text) + 1
                            Else
                                est_ = ""

                                If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                                    est_ = "ERR / CENTRO (" + rdr("CenDesCor").ToString.Trim + ")"
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

                                If rdr("GndProNom").ToString.Trim <> "TERNERAS" And rdr("GndProNom").ToString.Trim <> "TERNEROS" Then
                                    est_ = "ERR / CATEGORIA (" + rdr("GndProNom").ToString.Trim + ")"
                                End If

                                If est_ <> "" Then lblTotErrores.Text = Int32.Parse(lblTotErrores.Text) + 1

                                lvCambioCategorias.Items(i).SubItems(7).Text = est_
                            End If
                            If est_ = "" Then
                                lvCambioCategorias.Items(i).SubItems(7).Text = txtObs.Text
                            End If

                            If lvCambioCategorias.Items(i).SubItems(7).Text.Contains("ERR") Then
                                lvCambioCategorias.Items(i).BackColor = Color.Red
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
        lvCambioCategorias.EndUpdate()
    End Function

    Public Sub ContabilizaYValidaDIIOs()
        Dim i As Integer = 0
        'Dim totsec_ As Integer = 0
        Dim err_ As Integer = 0
        Dim estado_ As String = ""

        For i = 0 To lvCambioCategorias.Items.Count - 1
            lvCambioCategorias.Items(i).Text = (i + 1).ToString.Trim
            estado_ = lvCambioCategorias.Items(i).SubItems(7).Text.Trim

            If Mid(estado_, 1, 3) = "ERR" Then
                err_ += 1
            End If
        Next


        lblTotErrores.Text = err_.ToString.Trim

        If lvCambioCategorias.Items.Count = 0 Then Exit Sub

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
    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvCambioCategorias.Items.Count - 1
            If i <> pos_ Then
                If lvCambioCategorias.Items(i).SubItems(2).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("¿ DESEA ELIMINAR TODOS LOS ERRORES? ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        Dim numErrores As Integer = lblTotErrores.Text
        Dim num As Integer
        num = lvCambioCategorias.Items.Count.ToString
        For i = num - 1 To 0 Step -1
            If lvCambioCategorias.Items(i).BackColor = Color.Red Then
                lvCambioCategorias.Items.RemoveAt(i)
                numErrores = numErrores - 1
            End If
        Next
        lblTotErrores.Text = numErrores

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Ayuda_Click(sender As Object, e As EventArgs) Handles Ayuda.Click
        With Manuales
            .PDFManual = "Manual cambio de categorías por sexo"
            .ShowDialog()
        End With
    End Sub
End Class