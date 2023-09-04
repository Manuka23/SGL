
Imports System.Data.SqlClient

Public Class frmMuertesModificacionEliminacion
    Public Param1_Modo As Integer           '1=nuevo / 2=edita


    Private Sub LimpiaDatos()
        'txtDIIO.Text = ""

        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"

        'dtpFecha.Value = Now()

        txtNroCert.Text = "0"
        cboVeterinarios.SelectedIndex = -1
        cboCausasMuertes.SelectedIndex = -1

        txtObservs.Text = ""
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
                    btnGrabar.Enabled = True
                    dtpFecha.Focus()
                Else
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



    Public Sub ConsultaDIIOSinValidaciones(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        'Dim Existe As Boolean = False
        'Dim fpart_, fcub_, fpp_ As String
        'Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'fpart_ = ""
        'fcub_ = ""
        'fpp_ = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            'LimpiaDatos()

            Try
                While rdr.Read()
                    'If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                    '    If MsgBox("EL CENTRO DEL ANIMAL (" + rdr("CenDesCor").ToString.Trim + ") NO CORRESPONDE CON EL SELECCIONADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    '    End If
                    '    Exit Try
                    'End If

                    'If rdr("GndIsVendido").ToString.Trim = "SI" Then
                    '    If MsgBox("EL ANIMAL SE ENCUENTRA VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    '    End If
                    '    Exit Try
                    'End If

                    'If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                    '    If MsgBox("EL ANIMAL SE ENCUENTRA MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    '    End If
                    '    Exit Try
                    'End If

                    'If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                    '    If MsgBox("EL ANIMAL SE ENCUENTRA DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    '    End If
                    '    Exit Try
                    'End If

                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim

                    'cboCentros.Enabled = False

                    'Existe = True
                End While

                'If Existe = True Then
                '    btnGrabar.Enabled = True
                '    dtpFecha.Focus()
                'Else
                '    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                '    txtDIIO.Text = ""
                '    txtDIIO.Focus()
                'End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub






    Private Function ModificarMuerte() As Boolean
        ModificarMuerte = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuertes_Modificar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim cau_ As Integer = 0
        'Dim desec_ As Integer = 0                                                        'desecho
        'Dim dgest_ As Integer = 0                                                        'dias gestacion
        'Dim estprod_ As String = ""
        'Dim toro_ As String = ""

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        vet_ = General.Veterinarios.Codigo(cboVeterinarios.SelectedIndex)
        cau_ = General.CausasMuertes.Codigo(cboCausasMuertes.SelectedIndex)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@DIIO", txtDIIO.Text.Trim)
        cmd.Parameters.AddWithValue("@Causa", cau_)
        cmd.Parameters.AddWithValue("@Veterinario", vet_)
        cmd.Parameters.AddWithValue("@NroCertificado", txtNroCert.Text.Trim)
        cmd.Parameters.AddWithValue("@Observs", txtObservs.Text.Trim)
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

            ModificarMuerte = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function EliminarDIIOMuerto() As Boolean
        EliminarDIIOMuerto = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuertes_EliminarDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@DIIO", txtDIIO.Text.Trim)
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

            EliminarDIIOMuerto = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub EliminarMuerte()

        If MsgBox("¿DESEA ELIMINAR LA MUERTE SELECCIONADA?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If EliminarDIIOMuerto() = True Then
                'If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                'End If

                Cerrar()

                frmMuertes.LlenaGrilla()
            End If
        End If
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
            txtObservs.Enabled = True
        End If
    End Sub


    Private Sub txtDIIO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
        End If
    End Sub


    Private Sub txtDIIO_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDIIO.TextChanged
        If cboCentros.Text <> "" Then
            LimpiaDatos()
            btnGrabar.Enabled = False
        End If

        If txtDIIO.Text.Trim = "" Then
            cboCentros.Enabled = True
        End If
    End Sub


    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If Param1_Modo = 1 Then
        Else
            If ModificarMuerte() = True Then
                If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                End If

                Cerrar()
            End If
        End If
    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        EliminarMuerte()
    End Sub


    Private Sub frmMuertesIngreso_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtDIIO.Focus()
    End Sub


    Private Sub frmMuertesIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)


        If PerfilUsuario = 9 Or PerfilUsuario = 5 Then
            btnConfirmar.Enabled = True
            cboCausasMuertes.Enabled = True
        Else
            btnConfirmar.Enabled = False
        End If
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

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        GrabarConfirmacionMuerte()
    End Sub
    Private Function GrabarConfirmacionMuerte()
        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""
        Dim cent_ As Integer

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuertes_GrabarConfirmacionUnica", con)

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Diio", txtDIIO.Text)
        cmd.Parameters.AddWithValue("@Vete", cboVeterinarios.Text)
        cmd.Parameters.AddWithValue("@FechaMuerte", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Obs", txtObservs.Text)
        cmd.Parameters.AddWithValue("@CausaMue", cboCausasMuertes.Text)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            ResultCod = cmd.Parameters("@RetValor").Value
            ResultMsg = cmd.Parameters("@RetMensage").Value
            con.Close()

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                Exit Function
            End If
            MsgBox("Datos Actualizados", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "GRABACION")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

    End Function
End Class