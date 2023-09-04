
Imports System.Data.SqlClient


Public Class frmAdminDiiosAsignacion


    Private Sub LimpiaDatos()
        'cboCentros.SelectedIndex = -1
        'cboTiposAsign.SelectedIndex = -1
        'cboTiposFallas.SelectedIndex = -1
        'cboResponsables.SelectedIndex = -1
        '
        txtDiioAntiguo.Text = ""
        txtDiioNuevo.Text = ""
        txtObservs.Text = ""


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
        cboResponsables.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Recepcionadores.NroRegistros - 1
            cboResponsables.Items.Add(General.Recepcionadores.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaTiposAsignacionesDiios()
        If General.TipoAsignDiios.NroRegistros = 0 Then Exit Sub
        cboTiposAsign.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoAsignDiios.NroRegistros - 1
            cboTiposAsign.Items.Add(General.TipoAsignDiios.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaTiposFallasDiios()
        If General.TipoFallasDiios.NroRegistros = 0 Then Exit Sub
        cboTiposFallas.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoFallasDiios.NroRegistros - 1
            cboTiposFallas.Items.Add(General.TipoFallasDiios.Nombre(i))
        Next
    End Sub


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
            txtDiioNuevo.Focus()
            Exit Function
        End If

        If cboTiposAsign.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE ASIGNACIÓN", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTiposAsign.Focus()
            Exit Function
        End If

        If cboTiposAsign.Text = "FALLA" And cboTiposFallas.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE FALLA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTiposFallas.Focus()
            Exit Function
        End If

        If Val(txtDiioNuevo.Text) <= 0 Then
            If MsgBox("DEBE INGRESAR EL DIIO NUEVO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDiioNuevo.Focus()
            Exit Function
        End If

        'If (cboTiposAsign.Text = "COMPRA" Or cboTiposAsign.Text = "FALLA") And Val(txtDiioNuevo.Text) <= 0 Then
        '    If MsgBox("DEBE INGRESAR EL DIIO NUEVO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboTiposFallas.Focus()
        '    Exit Function
        'End If

        If (cboTiposAsign.Text = "COMPRA" Or cboTiposAsign.Text = "FALLA") And Val(txtDiioAntiguo.Text) <= 0 Then
            If MsgBox("DEBE INGRESAR EL DIIO ANTIGUO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDiioAntiguo.Focus()
            Exit Function
        End If

        If cboResponsables.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN RECEPCIONADOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboResponsables.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function


    Private Function GrabarEntregaDiio() As Boolean
        GrabarEntregaDiio = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDiios_GrabarAsignacion", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim resp_ As String = ""
        Dim t1_ As Integer = 0
        Dim t2_ As Integer = 0
        '
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        resp_ = General.Recepcionadores.Codigo(cboResponsables.SelectedIndex)
        t1_ = General.TipoAsignDiios.Codigo(cboTiposAsign.SelectedIndex)
        If cboTiposFallas.SelectedIndex <> -1 Then t2_ = General.TipoFallasDiios.Codigo(cboTiposFallas.SelectedIndex)

        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ADAsgnCentro", cent_)
        cmd.Parameters.AddWithValue("@ADAsgnFecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@ADAsgnTipo", t1_)
        cmd.Parameters.AddWithValue("@ADAsgnTipoFalla", t2_)
        cmd.Parameters.AddWithValue("@ADAsgnDiioAntiguo", Val(txtDiioAntiguo.Text))
        cmd.Parameters.AddWithValue("@ADAsgnDiioNuevo", Val(txtDiioNuevo.Text))
        cmd.Parameters.AddWithValue("@ADAsgnResponsable", resp_)
        cmd.Parameters.AddWithValue("@ADAsgnObservs", txtObservs.Text.Trim)
        cmd.Parameters.AddWithValue("@Commit", 1)
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

            GrabarEntregaDiio = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarEntregaDiio() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            LimpiaDatos()
            txtDiioNuevo.Focus()
            'cboCentros.Focus()

            'frmAdminDiios.LlenaGrilla()
        End If
    End Sub


    Private Sub txtDiioIni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiioAntiguo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservs.Focus()
        End If


        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtDiioFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiioNuevo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDiioAntiguo.Focus()
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor

        Me.Close()

        frmAdminDiios.Enabled = True
        frmAdminDiios.LlenaGrilla()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub cboTiposAsign_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTiposAsign.SelectedIndexChanged
        Label4.Visible = False
        cboTiposFallas.Visible = False
        Label11.Visible = False
        txtDiioAntiguo.Visible = False

        cboTiposFallas.SelectedIndex = -1
        txtDiioAntiguo.Text = ""

        If cboTiposAsign.Text = "FALLA" Then
            Label4.Visible = True
            cboTiposFallas.Visible = True
            Label11.Visible = True
            txtDiioAntiguo.Visible = True
        End If

        If cboTiposAsign.Text = "COMPRA" Then
            'Label4.Visible = False
            'cboTiposFallas.Visible = False
            Label11.Visible = True
            txtDiioAntiguo.Visible = True
        End If

    End Sub


    Private Sub frmAdminDiiosAsignacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaRecepcionadores()
        CboLLenaTiposAsignacionesDiios()
        CboLLenaTiposFallasDiios()

        dtpFecha.Value = Now()
        'cboResponsables.Text = LoginUsuario
    End Sub



    Private Sub txtObservs_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservs.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnGrabar_Click(sender, e)
        End If

    End Sub

    Private Sub cboTiposAsign_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cboTiposAsign.SelectionChangeCommitted
        txtDiioNuevo.Focus()
    End Sub


    Private Sub cboTiposFallas_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cboTiposFallas.SelectionChangeCommitted
        txtDiioNuevo.Focus()
    End Sub

End Class