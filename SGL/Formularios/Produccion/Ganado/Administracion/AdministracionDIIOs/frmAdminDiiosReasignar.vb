

Imports System.Data.SqlClient


Public Class frmAdminDiiosReasignar
    'Public Correlativos As Correlativos
    ''
    Public Param0_CodigoCorr As Integer        'codigo correlativo
    Public Param1_CodigoCentro As String
    Public Param1_NombreCentro As String
    Public Param2_Recepcionador As String
    'Public Param2_NombreTipoDoc As String
    Public Param3_Desde As Integer
    Public Param4_Hasta As String
    Public Param5_Fecha As DateTime



    Private Sub LimpiaDatos()
        cboCentros.SelectedIndex = -1
        'cboTiposDocs.SelectedIndex = -1
        cboRecepcionadores.SelectedIndex = -1
        '
        'txtNroDoc.Text = ""
        txtDesde.Text = ""
        txtHasta.Text = ""
        txtObservs.Text = ""

        lblTotalDiios.Text = "0"
    End Sub


    Private Sub CalcularDiios()
        Dim tot_ As Integer

        lblTotalDiios.Text = "0"
        tot_ = Val(txtHasta.Text) - Val(txtDesde.Text) + 1
        If tot_ > 0 Then lblTotalDiios.Text = tot_.ToString.Trim
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaRecepcionadores()
        If General.Recepcionadores.NroRegistros = 0 Then Exit Sub
        cboRecepcionadores.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Recepcionadores.NroRegistros - 1
            cboRecepcionadores.Items.Add(General.Recepcionadores.Nombre(i))
        Next
    End Sub

    Private Sub InicializaPantalla()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - 40) / 2)
        Me.KeyPreview = True

        ''-------------------------------------------------------------------------------

        CboLLenaCentros()
        CboLLenaRecepcionadores()

        ''-------------------------------------------------------------------------------


        txtCentroAnt.Text = Param1_NombreCentro
        txtRecepcionadorAnt.Text = Param2_Recepcionador
        txtFechaAnt.Text = Format(Param5_Fecha, "dd-MM-yyyy")
        txtDesdeAnt.Text = Param3_Desde.ToString
        txtHastaAnt.Text = Param4_Hasta.ToString

        dtpFecha.Value = Now ' Convert.ToDateTime("01-" + Month(Now).ToString + "-" + Year(Now).ToString)
        'dtpFechaHasta.Value = Now

        LimpiaDatos()
    End Sub


    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO DE GESTIÓN", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If cboCentros.Text = txtCentroAnt.Text Then
            If MsgBox("LA REASIGNACIÓN DEBE SER PARA UN CENTRO DIFERENTE AL CENTRO: " + txtCentroAnt.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        'If cboTiposDocs.SelectedIndex = -1 Then
        '    If MsgBox("DEBE SELECCIONAR UN TIPO DE DOCUMENTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboTiposDocs.Focus()
        '    Exit Function
        'End If

        If cboRecepcionadores.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR EL USUARIO QUE RECEPCIONA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboRecepcionadores.Focus()
            Exit Function
        End If

        'If IsNumeric(txtNroDoc.Text) = False Then
        '    If MsgBox("DEBE INGRESAR UN NRO DE DOCUMENTO CORRECTAMENTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtDiioFin.Focus()
        '    Exit Function
        'End If

        'If Val(txtNroDoc.Text) <= 0 Then
        '    If MsgBox("DEBE INGRESAR UN NRO DE DOCUMENTO CORRECTAMENTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtHasta.Focus()
        '    Exit Function
        'End If


        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtHasta.Focus()
            Exit Function
        End If

        If Val(txtDesde.Text) <= 0 Or Val(txtHasta.Text) <= 0 Then
            If MsgBox("ERROR EN EL RANGO DE CORRELATIVOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDesde.Focus()
            Exit Function
        End If

        If (Val(txtHasta.Text) < Val(txtDesde.Text)) Or ((Val(txtHasta.Text) - Val(txtDesde.Text)) < 0) Then
            If MsgBox("ERROR EN EL RANGO DE CORRELATIVOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtHasta.Focus()
            Exit Function
        End If


        If (Val(txtDesde.Text) < Val(txtDesdeAnt.Text) Or Val(txtDesde.Text) > Val(txtHastaAnt.Text)) Or _
                                        (Val(txtHasta.Text) < Val(txtDesdeAnt.Text) Or Val(txtHasta.Text) > Val(txtHastaAnt.Text)) Then
            If MsgBox("EL RANGO A REASIGNAR SE ENCUENTRA FUERA DEL RANGO A MODIFICAR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDesde.Focus()
            Exit Function
        End If


        ValidacionesLocales = True
    End Function


    Private Function GrabarReasignacion() As Boolean
        GrabarReasignacion = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDiios_ReasignarEntrega", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim resp_ As String = ""
        Dim t1_ As Integer = 0
        Dim t2_ As Integer = 0
        '
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        resp_ = General.Recepcionadores.Codigo(cboRecepcionadores.SelectedIndex)
        't1_ = General.TipoAsignDiios.Codigo(cboTiposAsign.SelectedIndex)
        'If cboTiposFallas.SelectedIndex <> -1 Then t2_ = General.TipoFallasDiios.Codigo(cboTiposFallas.SelectedIndex)

        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoCorr", Param0_CodigoCorr)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@DesdeNuevo", Val(txtDesde.Text))
        cmd.Parameters.AddWithValue("@HastaNuevo", Val(txtHasta.Text))
        cmd.Parameters.AddWithValue("@UsrEntrega", resp_)
        cmd.Parameters.AddWithValue("@Observs", txtObservs.Text.Trim)
        'cmd.Parameters.AddWithValue("@Commit", 1)
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

            GrabarReasignacion = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()

        frmAdminDiios.Enabled = True
        frmAdminDiios.LlenaGrilla()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub txtDesde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesde.KeyPress, txtHasta.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub

    'Private Sub txtDiioIni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiioIni.KeyPress
    '    If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
    '        e.Handled = True
    '    End If
    'End Sub


    'Private Sub txtDiioFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiioFin.KeyPress
    '    If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
    '        e.Handled = True
    '    End If
    'End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub


        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarReasignacion() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            Cerrar()
            'LimpiaDatos()
            'cboProveedores.Focus()
        End If
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub txtDiioFin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHasta.LostFocus, txtDesde.LostFocus, txtHasta.LostFocus
        CalcularDiios()
    End Sub


    'Private Sub txtDiioIni_LostFocus(sender As Object, e As System.EventArgs) Handles txtDiioIni.LostFocus
    '    CalcularDiios()
    'End Sub


    Private Sub frmPalpacionesIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InicializaPantalla()
        'ConsultarCorrelativos()

        Cursor.Current = Cursors.Default
    End Sub


End Class