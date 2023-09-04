


Imports System.Data.SqlClient



Public Class frmTrasladosIngresoDIIO

    Public Param0_ModoIngreso As Integer        '
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_SalidaTerneros As Boolean
    Public Param4_CodigoDestino As String
    Public Param5_NombreDestino As String
    Public Param6_DestinoEsAreaSeca As Boolean
    ''
    ''
    Private EstadoSecado As String = ""



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
        lblSexo.Text = "---"
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

        'If Param5_NombreDestino.Contains("COIHUECO 1") And Not lblSexo.Text.Contains("MACHO") Then
        '    If MsgBox("PARA EL DESTINO SELECCIONADO, EL SEXO DEL ANIMAL DEBE SER MACHO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtDIIO.Focus()
        '    Exit Function
        'End If

        'If Param5_NombreDestino.Contains("COIHUECO 2") And Not lblSexo.Text.Contains("HEMBRA") Then
        '    If MsgBox("PARA EL DESTINO SELECCIONADO, EL SEXO DEL ANIMAL DEBE SER HEMBRA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtDIIO.Focus()
        '    Exit Function
        'End If

        'If Param6_DestinoEsAreaSeca = True And Not lblEstProductivo.Text.Contains("SECA") And Not lblEstProductivo.Text.Contains("DESECHO") Then
        '    If MsgBox("EL ESTADO PRODUCTIVO DEL ANIMAL NO CORRESPONDE PARA UN DESTINO DE AREA SECA. DEBE REALIZAR UN SECADO DEL ANIMAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtDIIO.Focus()
        '    Exit Function
        'End If

        If Param3_SalidaTerneros = True And Not lblCategoria.Text.Contains("TERNER") Then
            If MsgBox("LA CATEGORIA DEL ANIMAL DEBE SER TERNEROS/AS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
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


    Private Function VerificaDIIOEnGrilla(ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To frmTrasladosIngreso.lvDIIOS.Items.Count - 1

            If frmTrasladosIngreso.lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
                existe_ = True
                Exit For
            End If

        Next

        VerificaDIIOEnGrilla = existe_
    End Function


    Private Function BuscaCodigoCentro(ByVal _text As String) As String
        BuscaCodigoCentro = ""

        Dim i As Integer
        Dim cod As String = ""

        For i = 0 To General.TrlsGnd_ListadoCentros.Nombre.Length - 1
            If General.TrlsGnd_ListadoCentros.Nombre(i).Trim = _text Then
                cod = General.TrlsGnd_ListadoCentros.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoCentro = cod
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
        EstadoSecado = ""

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

                    If rdr("CenDesCor").ToString.Trim.ToUpper <> Label1.Text Then
                        If MsgBox("EL DIIO NO PERTENECE AL CENTRO SELECCIONADO (" + rdr("CenDesCor").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA") = vbOK Then
                        End If

                        'EstadoSecado = "ERR / CENTRO"
                        txtDIIO.Text = ""
                        txtDIIO.Focus()
                        Exit Try
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
                    lblCategoriaCod.Text = rdr("GndProCod").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim

                    lblFecProbParto.Text = fpp_
                    lblFecProbSecado.Text = fsec_
                    lblDiasSecado.Text = diff1
                    lblDiasLactancia.Text = diff2
                    lblFecNac.Text = Format(rdr("GndFecNac"), "dd-MM-yyyy")
                    lblSexo.Text = rdr("GndSexo").ToString.Trim

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
                Else
                    btnAgregar.Focus()
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


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        'If MsgBox("¿ CONFIRMA TRASLADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        '    LimpiaDatos(True)
        '    txtDIIO.Focus()
        '    Exit Sub
        'End If

        'If Param0_ModoIngreso = 1 Then
        Dim item As New ListViewItem("")    'nro

        item.SubItems.Add(txtDIIO.Text.Trim)
        item.SubItems.Add(lblFecNac.Text)
        item.SubItems.Add(lblCategoriaCod.Text)
        item.SubItems.Add(lblCategoria.Text)
        item.SubItems.Add(lblEstProductivo.Text)
        item.SubItems.Add(lblEstReproductivo.Text)
        item.SubItems.Add(EstadoSecado)

        frmTrasladosIngreso.lvDIIOS.Items.Add(item)

        frmTrasladosIngreso.cboMovimientos.Enabled = False
        'frmTrasladosIngreso.txtGuia.Enabled = False
        frmTrasladosIngreso.cboCentros.Enabled = False
        'frmTrasladosIngreso.cboDestinos.Enabled = False
        frmTrasladosIngreso.dtpFecha.Enabled = False

        frmTrasladosIngreso.SumaTraslado()
        frmTrasladosIngreso.btnFinalizar.Enabled = True

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


    Private Sub frmTrasladosIngresoDIIO_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        txtDIIO.Focus()
    End Sub


    Private Sub frmSecadoIngresoDIIO_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        Label1.Text = Param2_NombreCentro
        'txtDIIO.Focus()
    End Sub


End Class