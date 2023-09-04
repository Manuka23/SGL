


Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel



Public Class frmComprasIngresoDIIO

    'Public Param0_ModoIngreso As Integer        '

    Public PForm As frmComprasIngreso

    Public Param1_ModoIngreso As Integer         '1=nuevo - 2=modifica - 3=muestra
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_Fecha As DateTime
    'Public Param5_CodigoCompra As Integer
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
        'cboCategorias.SelectedIndex = -1
        'cboEstProductivos.SelectedIndex = -1
        'cboEstReproductivos.SelectedIndex = -1
        'cboRazas.SelectedIndex = -1
        'txtPeso.Text = ""

        txtNroPartos.Text = ""
        'dtpFechaNac.Value = "01-01-1753"
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


    Private Function GrabarDIIOCompra() As Boolean
        GrabarDIIOCompra = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCompras_GrabarDIIO", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        'Dim cent_ As String = ""
        'Dim tdoc_ As Integer = 0
        'Dim ndoc_ As Integer = 0
        'Dim prov_ As Integer = 0
        Dim cat_ As String = ""
        Dim eprod_ As String = ""
        Dim ereprod_ As String = ""
        Dim raza_ As Integer = 0
        Dim peso_ As Integer = 0
        Dim npart_ As Integer = 0

        'cent_ = General.CentrosUsuario.Codigo(PForm.cboCentros.SelectedIndex)
        'If PForm.txtNroDoc.Text.Trim <> "" Then ndoc_ = Val(PForm.txtNroDoc.Text.Trim)
        'If PForm.cboTiposDocumentos.SelectedIndex <> -1 Then tdoc_ = General.TipoDocumentos.Codigo(PForm.cboTiposDocumentos.SelectedIndex)
        'If PForm.cboProveedores.SelectedIndex <> -1 Then prov_ = General.Proveedores.Codigo(PForm.cboProveedores.SelectedIndex)
        '
        cat_ = General.Categorias.Codigo(cboCategorias.SelectedIndex)
        eprod_ = cboEstProductivos.Text ' General.EstProductivos.Codigo(cboEstProductivos.SelectedIndex)
        ereprod_ = cboEstReproductivos.Text ' General.EstReproductivos.Codigo(cboEstReproductivos.SelectedIndex)
        raza_ = General.Razas.Codigo(cboRazas.SelectedIndex)
        If txtPeso.Text.Trim <> "" Then peso_ = Val(txtPeso.Text.Trim)
        If txtNroPartos.Text.Trim <> "" Then npart_ = Val(txtNroPartos.Text.Trim)

        'diios_ = GeneraStringDIIOs()
        'causas_ = GeneraStringCausas()

        cmd.Parameters.AddWithValue("@Commit", 1)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param2_CodigoCentro)
        cmd.Parameters.AddWithValue("@Fecha", Param4_Fecha)
        cmd.Parameters.AddWithValue("@FMA", Param6_NroFMA)
        cmd.Parameters.AddWithValue("@Guia", Param8_NroGuia)
        cmd.Parameters.AddWithValue("@Observs", Param13_Observs)
        cmd.Parameters.AddWithValue("@TipoDoc", Param10_TipoDoc)
        cmd.Parameters.AddWithValue("@Proveedor", Param12_Proveedor)
        cmd.Parameters.AddWithValue("@RUP", Param9_NroRUP)
        cmd.Parameters.AddWithValue("@NumeroDoc", Param11_NroDoc)
        cmd.Parameters.AddWithValue("@Transporte", 0)
        cmd.Parameters.AddWithValue("@Chofer", 0)
        cmd.Parameters.AddWithValue("@Patente", "")
        ''
        cmd.Parameters.AddWithValue("@NroAnimal", Val(txtDIIO.Text))
        cmd.Parameters.AddWithValue("@Categoria", cat_)
        cmd.Parameters.AddWithValue("@EstProductivo", eprod_)
        cmd.Parameters.AddWithValue("@EstReproductivo", ereprod_)
        cmd.Parameters.AddWithValue("@Raza", raza_)
        cmd.Parameters.AddWithValue("@FechaNacimiento", dtpFechaNac.Value)
        cmd.Parameters.AddWithValue("@Peso", peso_)
        cmd.Parameters.AddWithValue("@NroPartos", npart_)
        cmd.Parameters.AddWithValue("@Fecha1erParto", dtpFec1erParto.Value)
        cmd.Parameters.AddWithValue("@FechaUltParto", dtpFecUltParto.Value)
        cmd.Parameters.AddWithValue("@FechaProbParto", dtpFecProbParto.Value)
        cmd.Parameters.AddWithValue("@FechaUltCbta", dtpFecUltCbta.Value)
        cmd.Parameters.AddWithValue("@ToroUltCbta", txtToroUltParto.Text)
        cmd.Parameters.AddWithValue("@Padre", txtPadre.Text)
        cmd.Parameters.AddWithValue("@Madre", txtMadre.Text)
        ''
        'cmd.Parameters.AddWithValue("@CodigoSis", Param5_CodigoCompra)
        cmd.Parameters.AddWithValue("@Actualiza", ActualizaDIIO)
        ''
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        ''
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        'cmd.Parameters.Add("@RetCodCompra", SqlDbType.Int) : cmd.Parameters("@RetCodCompra").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            'Dim cod As Integer = cmd.Parameters("@RetCodCompra").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de secado

            'CodigoSecado = vret

            'despues de una grabacion correcta siempre activamos la edicion, ya que el encabezado ya esta creado
            'Param0_ModoIngreso = 2
            'Param5_CodigoCompra = cod
            GrabarDIIOCompra = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub Valida_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress, txtNroPartos.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales() = False Then Exit Sub

        If GrabarDIIOCompra() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If
            PForm.cboCentros.Enabled = False
            PForm.dtpFecha.Enabled = False
            PForm.txtNroFMA.Enabled = False

            'PForm.Param1_Empresa

            PForm.Param2_CodigoCentro = General.CentrosUsuario.Codigo(PForm.cboCentros.SelectedIndex)
            PForm.Param3_NombreCentro = General.CentrosUsuario.Nombre(PForm.cboCentros.SelectedIndex)
            PForm.Param4_Fecha = Param4_Fecha
            PForm.Param11_FMA = Param6_NroFMA
            PForm.BuscarDetalle()

            LimpiaDatos(True)
            txtDIIO.Focus()

            If Param1_ModoIngreso = 2 Then
                Cerrar()
            End If
        End If
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
        Cerrar()
    End Sub


    Private Sub frmComprasIngresoDIIO_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        'txtDIIO.Focus()
    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub frmSecadoIngresoDIIO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        Label1.Text = Param3_NombreCentro

        CboLLenaCategorias()
        CboLLenaEstadosProductivos()
        CboLLenaEstadosReproductivos()
        CboLLenaRazas()

        LimpiaDatos()

        Select Case Param1_ModoIngreso
            Case 1  'nuevo
                HabilitaCampos(False)

            Case 2  'edita
                'ActualizaDIIO = 1

                Select Case Param7_Estado
                    Case 1  'EN INGRESO
                        txtDIIO.Enabled = False
                        HabilitaCampos(True)

                    Case 2  'RECEPCIONADA
                        txtDIIO.Enabled = False
                        HabilitaCampos(True)

                    Case 3  'EN PROCESO OC
                        txtDIIO.Enabled = False
                        HabilitaCampos(False)
                        btnAgregar.Visible = False
                End Select
                btnAgregar.Enabled = False
        End Select
    End Sub



    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim lin As Integer = 0

    '    Try
    '        Dim Procesa As Boolean
    '        Dim AppExcel As New Application
    '        Dim Libro As Workbook
    '        Dim Hoja As Worksheet

    '        Libro = AppExcel.Workbooks.Open("C:\Compra.xlsx")
    '        Hoja = Libro.Worksheets(1)
    '        lin = 1
    '        Procesa = True

    '        Do While Procesa
    '            If Trim(Hoja.Cells(lin, 1).value) = "" Then
    '                Exit Do
    '            End If


    '            Dim item As New ListViewItem(lin)    'primera columna, para ordenar datos

    '            txtDIIO.Text = Hoja.Cells(lin, 1).value

    '            txtDIIO.Text = txtDIIO.Text.Trim
    '            ConsultaDIIO(txtDIIO.Text)

    '            'MsgBox(Hoja.Cells(lin, 4).value.ToString.Trim)

    '            cboCategorias.Text = Hoja.Cells(lin, 2).value
    '            cboEstProductivos.Text = Hoja.Cells(lin, 5).value
    '            cboEstReproductivos.Text = Hoja.Cells(lin, 6).value
    '            cboRazas.Text = Hoja.Cells(lin, 4).value.ToString.Trim
    '            dtpFechaNac.Value = Hoja.Cells(lin, 3).value
    '            txtPeso.Text = Hoja.Cells(lin, 7).value
    '            txtNroPartos.Text = Hoja.Cells(lin, 8).value

    '            dtpFec1erParto.Value = Hoja.Cells(lin, 9).value
    '            dtpFecUltParto.Value = Hoja.Cells(lin, 10).value
    '            dtpFecProbParto.Value = Now
    '            dtpFecUltCbta.Value = Now

    '            txtToroUltParto.Text = ""
    '            txtPadre.Text = ""
    '            txtMadre.Text = ""

    '            btnAgregar.PerformClick()

    '            lin = lin + 1

    '            'If lin > 1 Then
    '            '    Exit Do
    '            'End If
    '        Loop

    '        Hoja = Nothing      'Descargamos los Objetos...
    '        Libro.Close()
    '        AppExcel.Quit()
    '    Catch ex As Exception
    '        MsgBox("Error: " + ex.Message.ToString)
    '    End Try


    'End Sub

End Class