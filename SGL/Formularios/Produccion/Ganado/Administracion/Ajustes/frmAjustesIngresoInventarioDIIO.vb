


Imports System.Data.SqlClient



Public Class frmAjustesIngresoInventarioDIIO

    'Public Param0_ModoIngreso As Integer        '

    Public PForm As frmComprasIngreso

    Public Param1_ModoIngreso As Integer         '1=nuevo - 2=modifica - 3=muestra
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_Fecha As DateTime
    Public Param5_CodigoCompra As Integer
    Public Param6_NroFMA As Integer
    Public Param7_Estado As String
    Public Param8_NroGuia As Integer
    Public Param9_NroRUP As String
    Public Param10_TipoDoc As Integer
    Public Param11_NroDoc As Integer
    Public Param12_Proveedor As Integer
    Public Param13_Observs As String
    'Public CodigoCompra As Integer

    Public ActualizaDIIO As Integer


    Private Sub CboLLenaCategorias()
        If General.Categorias.NroRegistros = 0 Then Exit Sub
        cboCategorias.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Categorias.NroRegistros - 1
            cboCategorias.Items.Add(General.Categorias.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaEstadosProductivos()
        If General.EstProductivos.NroRegistros = 0 Then Exit Sub
        cboEstProductivos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.EstProductivos.NroRegistros - 1
            cboEstProductivos.Items.Add(General.EstProductivos.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaEstadosReproductivos()
        If General.EstReproductivos.NroRegistros = 0 Then Exit Sub
        cboEstReproductivos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.EstReproductivos.NroRegistros - 1
            cboEstReproductivos.Items.Add(General.EstReproductivos.Nombre(i))
        Next
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
        'If LimpiaDIIO = True Then
        '    txtDIIO.Text = ""
        'End If

        txtDIIO.Text = ""
        ''
        cboCategorias.SelectedIndex = -1
        cboEstProductivos.SelectedIndex = -1
        cboEstReproductivos.SelectedIndex = -1
        cboRazas.SelectedIndex = -1
        txtPeso.Text = ""

        txtNroPartos.Text = ""
        dtpFechaNac.Value = "01-01-1753"
        dtpFec1erParto.Value = "01-01-1753"
        dtpFecUltParto.Value = "01-01-1753"
        dtpFecProbParto.Value = "01-01-1753"
        dtpFecUltCbta.Value = "01-01-1753"
        txtToroUltParto.Text = ""

        txtPadre.Text = ""
        txtMadre.Text = ""
    End Sub


    Private Sub HabilitaCampos(ByVal hab_ As Boolean)
        cboCategorias.Enabled = hab_
        cboEstProductivos.Enabled = hab_
        cboEstReproductivos.Enabled = hab_
        cboRazas.Enabled = hab_
        dtpFechaNac.Enabled = hab_
        txtPeso.Enabled = hab_

        txtNroPartos.Enabled = hab_
        dtpFec1erParto.Enabled = hab_
        dtpFecUltParto.Enabled = hab_
        dtpFecProbParto.Enabled = hab_
        dtpFecUltCbta.Enabled = hab_
        txtToroUltParto.Enabled = hab_

        txtPadre.Enabled = hab_
        txtMadre.Enabled = hab_
    End Sub



    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If txtDIIO.Text.Trim = "" Or txtDIIO.Text.Trim = "0" Then
            If MsgBox("DEBE INGRESAR UN DIIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If

        If cboCategorias.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UNA CATEGORIA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCategorias.Focus()
            Exit Function
        End If

        If cboEstProductivos.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN ESTADO PRODUCTIVO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboEstProductivos.Focus()
            Exit Function
        End If

        If cboEstReproductivos.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN ESTADO REPRODUCTIVO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboEstReproductivos.Focus()
            Exit Function
        End If

        If cboRazas.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UNA RAZA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboRazas.Focus()
            Exit Function
        End If

        If Format(dtpFechaNac.Value, "dd-MM-yyyy") = "01-01-1753" Or Format(dtpFechaNac.Value, "dd-MM-yyyy") = "01-01-900" Then
            If MsgBox("DEBE INGRESAR LA FECHA DE NACIMIENTO DEL ANIMAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFechaNac.Focus()
            Exit Function
        End If

        If txtPeso.Text.Trim = "" Or txtPeso.Text.Trim = "0" Then
            If MsgBox("DEBE INGRESAR EL PESO DEL ANIMAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDIIO.Focus()
            Exit Function
        End If




        'If VerificaDIIOEnGrilla(txtDIIO.Text.Trim) = True Then
        '    If MsgBox("EL DIIO YA ESTA CARGADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    LimpiaDatos()
        '    txtDIIO.Focus()
        '    Exit Function
        'End If

        ValidacionesLocales = True
    End Function


    Private Function VerificaDIIOEnGrilla(ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To frmComprasIngreso.lvCOMPRAS.Items.Count - 1

            If frmComprasIngreso.lvCOMPRAS.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
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

            'LimpiaDatos()

            Try
                While rdr.Read()
                    Existe = True
                    Exit While
                End While

                If Existe = True Then
                    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") YA EXISTE")
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                Else
                    HabilitaCampos(True)
                    cboCategorias.Focus()
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


    Private Sub Valida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress, txtNroPartos.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales() = False Then Exit Sub

        Dim cat_ As String = ""
        Dim eprod_ As String = ""
        Dim ereprod_ As String = ""
        Dim raza_ As Integer = 0
        Dim peso_ As Integer = 0
        Dim npart_ As Integer = 0

        cat_ = General.Categorias.Codigo(cboCategorias.SelectedIndex)
        eprod_ = cboEstProductivos.Text ' General.EstProductivos.Codigo(cboEstProductivos.SelectedIndex)
        ereprod_ = cboEstReproductivos.Text ' General.EstReproductivos.Codigo(cboEstReproductivos.SelectedIndex)
        raza_ = General.Razas.Codigo(cboRazas.SelectedIndex)

        If txtPeso.Text.Trim <> "" Then peso_ = Val(txtPeso.Text.Trim)
        If txtNroPartos.Text.Trim <> "" Then npart_ = Val(txtNroPartos.Text.Trim)

        With frmAjustesIngresoDIIO

            .DatosAnimal(0) = cboCategorias.Text
            .DatosAnimal(1) = cboEstProductivos.Text
            .DatosAnimal(2) = cboEstReproductivos.Text
            .DatosAnimal(3) = cboRazas.Text
            .DatosAnimal(4) = Format(dtpFechaNac.Value, "yyyy-MM-dd")
            .DatosAnimal(5) = peso_.ToString.Trim
            .DatosAnimal(6) = npart_.ToString.Trim
            .DatosAnimal(7) = Format(dtpFec1erParto.Value, "yyyy-MM-dd")
            .DatosAnimal(8) = Format(dtpFecUltParto.Value, "yyyy-MM-dd")
            .DatosAnimal(9) = Format(dtpFecProbParto.Value, "yyyy-MM-dd")
            .DatosAnimal(10) = Format(dtpFecUltCbta.Value, "yyyy-MM-dd")
            .DatosAnimal(11) = txtToroUltParto.Text
            .DatosAnimal(12) = txtPadre.Text
            .DatosAnimal(13) = txtMadre.Text
            'codigos
            .DatosAnimal(14) = cat_
            .DatosAnimal(15) = eprod_
            .DatosAnimal(16) = ereprod_
            .DatosAnimal(17) = raza_
        End With

        Cerrar()
    End Sub


    Private Sub txtDIIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
        End If
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        frmAjustesIngresoDIIO.CancelaIngresoInventario = True
        Cerrar()
    End Sub


    Private Sub frmAjustesIngresoInventarioDIIO_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        'txtDIIO.Focus()
    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        frmAjustesIngresoDIIO.btnSalir.Enabled = True
        Me.Close()
        'Me.Dispose()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub frmSecadoIngresoDIIO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        Label1.Text = Param3_NombreCentro
        'txtDIIO.Focus()

        CboLLenaCategorias()
        CboLLenaEstadosProductivos()
        CboLLenaEstadosReproductivos()
        CboLLenaRazas()

        dtpFechaNac.Value = "01-01-1900"
        dtpFec1erParto.Value = "01-01-1900"
        dtpFecUltParto.Value = "01-01-1900"
        dtpFecProbParto.Value = "01-01-1900"
        dtpFecUltCbta.Value = "01-01-1900"

        'LimpiaDatos()

        'Select Case Param1_ModoIngreso
        '    Case 1  'nuevo
        '        HabilitaCampos(False)
        '        'ActualizaDIIO = 0

        '    Case 2  'edita
        '        'ActualizaDIIO = 1

        '        Select Case Param7_Estado
        '            Case 1  'EN INGRESO
        '                txtDIIO.Enabled = False
        '                HabilitaCampos(True)

        '            Case 2  'RECEPCIONADA
        '                txtDIIO.Enabled = False
        '                HabilitaCampos(True)

        '            Case 3  'EN PROCESO OC
        '                txtDIIO.Enabled = False
        '                HabilitaCampos(False)
        '                btnAgregar.Visible = False
        '        End Select
        'End Select
    End Sub


End Class