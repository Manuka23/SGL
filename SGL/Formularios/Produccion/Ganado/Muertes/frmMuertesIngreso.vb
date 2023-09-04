

Imports System.Data.SqlClient


Public Class frmMuertesIngreso
    Private fnMuertesIngreso As New fnMuertesIngreso
    Public Param1_Modo As Integer           '1=nuevo / 2=edita
    Private diio As String = ""

    Private Sub LimpiaDatos()
        'txtDIIO.Text = ""

        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"

        'dtpFecha.Value = Now()

        'txtNroCert.Text = "0"
        'cboVeterinarios.SelectedIndex = -1
        'cboCausasMuertes.SelectedIndex = -1

        'txtObservs.Text = ""
    End Sub

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

    Private Sub CboLLenaVeterinarios()
        If General.Veterinarios.NroRegistros = 0 Then Exit Sub

        cboVeterinarios.Items.Clear()
        'cboVeterinarios.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Veterinarios.NroRegistros - 1
            cboVeterinarios.Items.Add(General.Veterinarios.Nombre(i))
        Next

        'cboVeterinarios.SelectedIndex = 0
    End Sub

    Private Sub CboLLenaCausas()
        If General.Veterinarios.NroRegistros = 0 Then Exit Sub

        cboCausasMuertes.Items.Clear()
        'cboCausasMuertes.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CausasMuertes.NroRegistros - 1
            cboCausasMuertes.Items.Add(General.CausasMuertes.Nombre(i))
        Next

        'cboCausasMuertes.SelectedIndex = 0
    End Sub


    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim fpart_, fcub_, fpp_ As String
        'Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fpart_ = ""
        fcub_ = ""
        fpp_ = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                        If MsgBox("EL CENTRO DEL ANIMAL (" + rdr("CenDesCor").ToString.Trim + ") NO CORRESPONDE CON EL SELECCIONADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
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

                    'solo perfiles gerencia tecnica hacia arriba, pueden matar un animal ya vendido
                    'If PerfilUsuario >= 3 Then
                    '    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                    '        If MsgBox("EL ANIMAL SE ENCUENTRA VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy") + vbNewLine + vbNewLine + "¿DESEA MATAR EL ANIMAL DE TODAS FORMAS?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                    '            Exit Try
                    '        End If
                    '    End If
                    'Else
                    'por debajo de gerencia tecnica, no pueden matar un animal ya vendido
                    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If
                    'End If



                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim

                    cboCentros.Enabled = False

                    Existe = True
                End While

                If Existe = True Then
                    dtpFecha.Focus()
                Else
                    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                    diio = ""
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









    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If cboVeterinarios.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN VETERINARIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboVeterinarios.Focus()
            Exit Function
        End If

        If cboCausasMuertes.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UNA CAUSA DE MUERTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCausasMuertes.Focus()
            Exit Function
        End If

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        If txtDIIO.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If Val(txtNroCert.Text.Trim) <= 0 Then
            If MsgBox("DEBE INGRESAR UN NÚMERO DE CERTIFICADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroCert.Focus()
            Exit Function
        End If

        If (cboCausasMuertes.Text.Contains("INDUCCION") Or cboCausasMuertes.Text.Contains("INDUCCIÓN")) And lblCategoria.Text <> "TERNERAS" Then
            If MsgBox("EL TIPO DE MUERTE DE INDUCCIÓN ES SOLO PARA LAS TERNERAS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCausasMuertes.Focus()
            Exit Function
        End If

        If (cboCausasMuertes.Text.Contains("INDUCCION") Or cboCausasMuertes.Text.Contains("INDUCCIÓN")) And lblCategoria.Text = "TERNERAS" And LoginUsuario <> "GGARCIA" Then
            If MsgBox("LA MUERTE DE UNA TERNERA POR INDUCCIÓN SOLO LA PUEDE REALIZAR GONZALO GARCIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCausasMuertes.Focus()
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

        If cboVeterinarios.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN VETERINARIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboVeterinarios.Focus()
            Exit Function
        End If

        If cboCausasMuertes.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UNA CAUSA DE MUERTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCausasMuertes.Focus()
            Exit Function
        End If

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If

        If Val(txtNroCert.Text.Trim) <= 0 Then
            If MsgBox("DEBE INGRESAR UN NÚMERO DE CERTIFICADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroCert.Focus()
            Exit Function
        End If

        ValidacionesLocales2 = True
    End Function

    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If cboCentros.Text.Trim <> "" Then
            txtDIIO.Enabled = True
            btnBuscar.Enabled = True
            dtpFecha.Enabled = True
            cboVeterinarios.Enabled = True
            txtNroCert.Enabled = True
            cboCausasMuertes.Enabled = True
            txtObservs.Enabled = True
        Else
            txtDIIO.Enabled = False
            btnBuscar.Enabled = False
            dtpFecha.Enabled = False
            cboVeterinarios.Enabled = False
            txtNroCert.Enabled = False
            cboCausasMuertes.Enabled = False
            txtObservs.Enabled = False
        End If
    End Sub


    Private Sub txtDIIO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)

        End If
    End Sub


    Private Sub txtDIIO_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDIIO.TextChanged
        'If cboCentros.Text <> "" Then
        '    LimpiaDatos()
        'End If

        If txtDIIO.Text.Trim = "" Then
            cboCentros.Enabled = True
        End If
    End Sub


    'Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs)

    '    'CONFIRMAR
    '    If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
    '        Exit Sub
    '    End If

    '    If Param1_Modo = 1 Then
    '        If GrabarMuerte() = True Then
    '            txtDIIO.Text = ""
    '            LimpiaDatos()
    '            txtDIIO.Focus()
    '        End If
    '    End If
    'End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub frmMuertesIngreso_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtDIIO.Focus()
    End Sub


    Private Sub frmMuertesIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaVeterinarios()
        CboLLenaCausas()

        cboCentros.Text = CentroPorDefecto()
        dtpFecha.Value = Now()

        txtDIIO.Focus()
    End Sub

    Private Sub cboCentros_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCentros.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Focus()
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cboVeterinarios.Focus()
        End If
    End Sub

    Private Sub cboVeterinarios_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboVeterinarios.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtNroCert.Focus()
        End If
    End Sub

    Private Sub txtNroCert_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCert.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            cboCausasMuertes.Focus()
        End If
    End Sub

    Private Sub cboCausasMuertes_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCausasMuertes.KeyPress
        txtObservs.Focus()
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ValidacionesLocales() = False Then Exit Sub
        diio = txtDIIO.Text.Trim
        ConsultaDIIO(diio)
        If diio = "" Then
            If MsgBox("AL INGRESAR UN DIIO DEBE PRESIONAR ENTER PARA VERIFICAR QUE EL DIIO ES VALIDO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                Exit Sub
            End If
        End If
        Dim variable As Boolean
        Dim n As Integer
        variable = True
        n = lvGanado.Items.Count.ToString
        For i = 0 To n - 1
            If txtDIIO.Text.Trim = lvGanado.Items(i).SubItems(1).Text.Trim Then
                variable = False
                If MsgBox("Diio ya ingresado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    LimpiaDatos()
                    Exit Sub
                End If
            End If
        Next
        If variable = True Then
            ConsultaDiioMuerte(diio)
            '' llenadoLv()
        End If
        Dim numErrores As Integer = 0

        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = 0 To num - 1
            If lvGanado.Items(i).SubItems(7).Text.Contains("ERR") Or lvGanado.Items(i).SubItems(5).Text <> "STOCK" Then
                lvGanado.Items(i).BackColor = Color.Red
                numErrores = numErrores + 1
            End If
        Next
        lblErrores.Text = numErrores
        txtDIIO.Text = ""
        cboCentros.Enabled = False
        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        diio = ""
        txtDIIO.Focus()
        If numErrores = 0 Then
            btnFinalizar.Enabled = True
            dtpFecha.Enabled = False
        Else
            btnFinalizar.Enabled = False
        End If
    End Sub
    Private Sub llenadoLv()
        Dim totaldiios As Integer = lblTotDiios.Text
        Dim itm As New ListViewItem((lvGanado.Items.Count + 1).ToString)
        itm.SubItems.Add(txtDIIO.Text.Trim)
        itm.SubItems.Add(lblCategoria.Text.Trim)
        itm.SubItems.Add(lblEstProductivo.Text.Trim)
        itm.SubItems.Add(lblEstReproductivo.Text.Trim)
        itm.SubItems.Add("Stock")
        itm.SubItems.Add(txtObservs.Text)
        lvGanado.Items.Add(itm)
        lblTotDiios.Text = totaldiios + 1
    End Sub
    Private Sub btnBastonLee_Click(sender As Object, e As EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales2() = False Then Exit Sub
        If cboCentros.Text = "--Elegir Centro--" Then
            If MsgBox("Debe seleccionar un centro", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If
        LeeBaston()
        Dim numErrores As Integer = 0

        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = 0 To num - 1
            If lvGanado.Items(i).SubItems(7).Text.Contains("ERR") Or lvGanado.Items(i).SubItems(5).Text <> "STOCK" Then
                lvGanado.Items(i).BackColor = Color.Red
                numErrores = numErrores + 1
            End If
        Next
        lblErrores.Text = numErrores
        If numErrores = 0 Then
            btnFinalizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
        End If
    End Sub


    Private Sub LeeBaston()


        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmMuertes"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub
    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim numErrores As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        Dim inichk_ As Integer = lvGanado.Items.Count '- 1

        Cursor.Current = Cursors.WaitCursor

        lvGanado.Items.Clear()
        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","
            ConsultaDiioMuerte(diio_)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If
        cboVeterinarios.Enabled = False
        cboCausasMuertes.Enabled = False
        txtNroCert.Enabled = False
        cboCentros.Enabled = False
        dtpFecha.Enabled = False
        Button1.Enabled = False
        lblErrores.Text = numErrores
        Cursor.Current = Cursors.Default
    End Sub
    Public Sub ConsultaDIIOSinValidaciones(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
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
    Private Function ConsultaDiioMuerte(ByVal diio As String) As Boolean
        ConsultaDiioMuerte = False
        Cursor.Current = Cursors.WaitCursor
        Dim cent_ As String = ""
        Dim vet_ As String = ""
        Dim cau_ As Integer = 0
        Dim totaldiios As Integer = lblTotDiios.Text
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        vet_ = General.Veterinarios.Codigo(cboVeterinarios.SelectedIndex)
        cau_ = General.CausasMuertes.Codigo(cboCausasMuertes.SelectedIndex)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuertes_Validaciones", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Causa", cau_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@DIIO", diio)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            Try
                While rdr.Read()


                    Dim itm As New ListViewItem((lvGanado.Items.Count + 1).ToString)
                itm.SubItems.Add(diio)
                itm.SubItems.Add(rdr("GndProNom").ToString.Trim)
                itm.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)
                itm.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                    If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        itm.SubItems.Add("DESAPARECIDO")
                    ElseIf rdr("GndIsVendido").ToString.Trim = "SI" Then
                        itm.SubItems.Add("VENDIDO")
                    ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        itm.SubItems.Add("MUERTO")
                    Else
                        itm.SubItems.Add("STOCK")
                    End If
                    itm.SubItems.Add(txtObservs.Text)
                    If rdr("observacion") <> "OK" Then
                        itm.SubItems.Add(rdr("observacion").ToString.Trim)

                    ElseIf rdr("GndCenCod").ToString.Trim <> cent_ Then
                        itm.SubItems.Add("ERR/ No Corresponde al centro seleccionado")
                    ElseIf rdr("GndCenCod").ToString.Trim <> cent_ Then

                    Else
                        itm.SubItems.Add("")
                    End If
                    itm.SubItems.Add(General.CausasMuertes.Codigo(cboCausasMuertes.SelectedIndex))
                    itm.SubItems.Add(General.Veterinarios.Codigo(cboVeterinarios.SelectedIndex))
                    itm.SubItems.Add(txtNroCert.Text)
                    lvGanado.Items.Add(itm)
                lblTotDiios.Text = totaldiios + 1

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Catch ex As Exception
        MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        ConsultaDiioMuerte = True
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿ DESEA ELIMINAR EL REGISTRO SELECCIONADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        Dim totaldiios As Integer = lblTotDiios.Text
        For Each it As ListViewItem In lvGanado.SelectedItems
            lvGanado.Items.Remove(it)
            totaldiios = totaldiios - 1
        Next
        lblTotDiios.Text = totaldiios
        Dim numErrores As Integer = 0
        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = 0 To num - 1
            If lvGanado.Items(i).BackColor = Color.Red Then
                numErrores = numErrores + 1
            End If
        Next
        lblErrores.Text = numErrores
        If lvGanado.Items.Count.ToString = 0 Then
            cboCentros.Enabled = True
        End If
        If numErrores = 0 Then
            btnFinalizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
        End If
        If lvGanado.Items.Count = 0 Then
            dtpFecha.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MsgBox("¿ DESEA ELIMINAR TODOS LOS ERRORES? ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If


        Dim numErrores As Integer = lblErrores.Text
        Dim totaldiios As Integer = lblTotDiios.Text
        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = num - 1 To 0 Step -1
            If lvGanado.Items(i).BackColor = Color.Red Then
                lvGanado.Items.RemoveAt(i)
                numErrores = numErrores - 1
                totaldiios = totaldiios - 1
            End If
        Next
        lblTotDiios.Text = totaldiios
        lblErrores.Text = numErrores
        If lvGanado.Items.Count.ToString = 0 Then
            cboCentros.Enabled = True
        End If
        If numErrores = 0 Then
            btnFinalizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
        End If
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        'CONFIRMAR
        If lvGanado.Items.Count.ToString = 0 Then
            If MsgBox("DEBE INGRESAR AL MENOS 1 DIIO Y PRESIONAR EL BOTON AGREGAR PARA QUE SE AGREGE A LA LISTA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                Exit Sub
            End If
        End If
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If lblErrores.Text <> "0" Then
            If MsgBox("DEBE ELIMINAR LOS ERROR PARA CONRINUAR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                Exit Sub
            End If
        End If


        If Param1_Modo = 1 Then
            If GrabarMuerte() = True Then
                txtDIIO.Text = ""
                LimpiaDatos()
                txtDIIO.Focus()
                Cerrar()
            End If
        End If
    End Sub
    Private Function GrabarMuerte() As Boolean
        GrabarMuerte = False
        Dim cent_ As String = ""
        Dim vet_ As String = ""
        Dim cau_ As Integer = 0

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        If fnMuertesIngreso.GrabarMuertes(lvGanado, cent_, dtpFecha.Value) Then
            GrabarMuerte = True
        End If
        Return GrabarMuerte
    End Function
End Class