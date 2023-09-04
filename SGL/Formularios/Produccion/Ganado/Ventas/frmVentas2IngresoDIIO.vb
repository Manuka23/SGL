


Imports System.Data.SqlClient



Public Class frmVentas2IngresoDIIO

    Public PForm As frmVentas2Ingreso
    Dim tratamiento As String
    Public Param1_ModoIngreso As Integer         '1=nuevo - 2=modifica - 3=muestra
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_Fecha As DateTime
    Public Param5_CodigoVenta As Integer
    Public Param6_NroFMA As Integer
    Public Param7_Estado As String
    Public Param8_NroGuia As Integer
    Public Param13_Observs As String

    Public ActualizaDIIO As Integer

    Private Sub frmSecadoIngresoDIIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        Label1.Text = Param3_NombreCentro

        CboLLenaCausas()
        CboLLenaVeterinarios()
        CboLLenaTiposVentas()
    End Sub

    Private Sub CboLLenaCausas()
        If General.CausasVentas.NroRegistros = 0 Then Exit Sub

        cboCausas.Items.Clear()
        cboCausas.Items.Add("")

        Dim i As Integer

        For i = 0 To General.CausasVentas.NroRegistros - 1
            cboCausas.Items.Add(General.CausasVentas.Nombre(i))
        Next

        'cboCausasMuertes.SelectedIndex = 0
    End Sub

    Private Sub CboLLenaVeterinarios()
        If General.Veterinarios.NroRegistros = 0 Then Exit Sub

        cboVeterinarios.Items.Clear()
        cboVeterinarios.Items.Add("")

        Dim i As Integer

        For i = 0 To General.Veterinarios.NroRegistros - 1
            cboVeterinarios.Items.Add(General.Veterinarios.Nombre(i))
        Next

        'cboVeterinarios.SelectedIndex = 0
    End Sub

    Private Sub CboLLenaTiposVentas()
        If General.TiposVentas.NroRegistros = 0 Then Exit Sub

        cboTiposVentas.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TiposVentas.NroRegistros - 1
            cboTiposVentas.Items.Add(General.TiposVentas.Nombre(i))
        Next

        'cboVeterinarios.SelectedIndex = 0
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
        lblFecProbParto.Text = "---"
        lblFecProbSecado.Text = "---"
        lblDiasSecado.Text = "---"
        lblDiasLactancia.Text = "---"

        cboCausas.SelectedIndex = -1
    End Sub

    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If lblCentro.Text = "---" Then
            If MsgBox("NO EXISTE UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If
        If tratamiento = "En Tratamiento" Then
            If MsgBox("ANIMAL EN TRATAMIENTO, NO ES POSIBLE SU VENTA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If txtDIIO.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If cboTiposVentas.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE VENTA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTiposVentas.Focus()
            Exit Function
        End If

        'si el tipo de venta no es dacion, validamos causa
        If (Not cboTiposVentas.Text.Contains("DONACI")) And (Not cboTiposVentas.Text.Contains("DIRECTA")) And (Not cboTiposVentas.Text.Contains("FAENA MAC")) Then
            If cboCausas.SelectedIndex = -1 Then
                If MsgBox("DEBE SELECCIONAR UNA CAUSA DE VENTA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                cboCausas.Focus()
                Exit Function
            End If
        End If

        If cboTiposVentas.Text.ToUpper.Contains("EMERGENCIA") And (txtNroCert.Text = "" Or txtNroCert.Text = "0") Then
            If MsgBox("PARA VENTA DE EMERGENCIA DEBE INGRESAR UN NRO. DE CERTIFICADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCausas.Focus()
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

        For i = 0 To frmVentas2Ingreso.lblVenta.Items.Count - 1

            If frmVentas2Ingreso.lblVenta.Items(i).SubItems(2).Text.ToString.Trim = diio_ Then
                existe_ = True
                Exit For
            End If

        Next

        VerificaDIIOEnGrilla = existe_
    End Function

    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
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
        'EstadoVenta = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    Existe = True

                    If rdr("GndIsVendido").ToString.Trim = "SI" Or rdr("GndIsMuerto").ToString.Trim = "SI" Or _
                            rdr("GndIsDesaparecido").ToString.Trim = "SI" Then

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

                    If rdr("CenDesCor").ToString.Trim <> Label1.Text.Trim Then
                        If MsgBox("EL DIIO NO PERTENECE AL CENTRO SELECCIONADO (" + rdr("CenDesCor").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                        End If

                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                        Exit Try
                    End If

                    lblFecNac.Text = Format(rdr("GndFecNac"), "dd-MM-yyyy")
                    lblCentro.Text = rdr("CenDesCor").ToString.Trim
                    lblCategoriaCod.Text = rdr("GndProCod").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
                    tratamiento = rdr("EnTratamiento").ToString.Trim

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

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales() = False Then Exit Sub

        Dim causa_cod_ As Integer = 0
        Dim causa_nom_ As String = ""
        Dim vet_ As String = ""

        If cboCausas.SelectedIndex <> -1 And cboCausas.Text <> "" Then
            causa_nom_ = cboCausas.Text
            causa_cod_ = General.CausasVentas.Codigo(cboCausas.SelectedIndex - 1)
        End If

        If cboVeterinarios.SelectedIndex <> -1 And cboVeterinarios.Text <> "" Then
            vet_ = General.Veterinarios.Codigo(cboVeterinarios.SelectedIndex - 1)
        End If

        Dim item As New ListViewItem("")    'nro

        item.SubItems.Add(txtDIIO.Text.Trim)
        item.SubItems.Add(lblFecNac.Text)
        item.SubItems.Add(lblCategoriaCod.Text)
        item.SubItems.Add(lblCategoria.Text)
        item.SubItems.Add(lblEstProductivo.Text)
        item.SubItems.Add(lblEstReproductivo.Text)
        item.SubItems.Add(General.TiposVentas.Codigo(cboTiposVentas.SelectedIndex))
        item.SubItems.Add(cboTiposVentas.Text)
        item.SubItems.Add(causa_cod_)
        item.SubItems.Add(causa_nom_)
        item.SubItems.Add("")
        item.SubItems.Add(vet_)
        item.SubItems.Add(txtNroCert.Text)

        frmVentas2Ingreso.lblVenta.Items.Add(item)

        frmVentas2Ingreso.cboCentros.Enabled = False
        frmVentas2Ingreso.dtpFecha.Enabled = False
        frmVentas2Ingreso.btnEliminar.Enabled = True
        frmVentas2Ingreso.btnFinalizar.Enabled = True

        frmVentas2Ingreso.ContabilizaYValidaDIIOs()

        LimpiaDatos(True)
        txtDIIO.Focus()
    End Sub

    Private Sub txtDIIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
        End If
    End Sub

    Private Sub txtDIIO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDIIO.TextChanged
        If lblCentro.Text <> "---" Then
            LimpiaDatos()
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmVentas2IngresoDIIO_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        txtDIIO.Focus()
    End Sub

    Private Sub txtNroCert_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroCert.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub
End Class