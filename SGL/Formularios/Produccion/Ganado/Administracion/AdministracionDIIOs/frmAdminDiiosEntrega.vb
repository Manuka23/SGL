


Imports System.Data.SqlClient




Public Class frmAdminDiiosEntrega

    Public Param0_ModoIngreso As Integer        '
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_CodigoVeterinario As Integer
    Public Param4_NombreVeterinario As String



    Private Sub LimpiaDatos()
        cboCentros.SelectedIndex = -1
        cboRecepcionadores.SelectedIndex = -1
        '
        txtDiioIni.Text = ""
        txtDiioFin.Text = ""
        txtObservs.Text = ""

        lblTotalDiios.Text = "0"
    End Sub


    Private Sub CalcularDiios()
        Dim tot_ As Integer

        lblTotalDiios.Text = "0"
        tot_ = Val(txtDiioFin.Text) - Val(txtDiioIni.Text) + 1
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
            txtDiioFin.Focus()
            Exit Function
        End If

        If Val(txtDiioIni.Text) <= 0 Or Val(txtDiioFin.Text) <= 0 Then
            If MsgBox("ERROR EN EL RANGO DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDiioIni.Focus()
            Exit Function
        End If

        If Val(txtDiioFin.Text) < Val(txtDiioIni.Text) Then
            If MsgBox("ERROR EN EL RANGO DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDiioFin.Focus()
            Exit Function
        End If

        If cboRecepcionadores.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN RECEPCIONADOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboRecepcionadores.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function


    Private Function GrabarEntregaDiio() As Boolean
        GrabarEntregaDiio = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDiios_GrabarEntrega", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim recep_ As String = ""
        '
        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        recep_ = General.Recepcionadores.Codigo(cboRecepcionadores.SelectedIndex)
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ADCentro", cent_)
        cmd.Parameters.AddWithValue("@ADFechaRecep", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@ADNumInicial", Val(txtDiioIni.Text))
        cmd.Parameters.AddWithValue("@ADNumFinal", Val(txtDiioFin.Text))
        cmd.Parameters.AddWithValue("@ADRecepcionador", recep_)
        cmd.Parameters.AddWithValue("@ADObservs", txtObservs.Text.Trim)
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


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()

        frmAdminDiios.Enabled = True
        frmAdminDiios.LlenaGrilla()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub txtDiioIni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiioIni.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDiioFin.Focus()
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtDiioFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiioFin.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtObservs.Focus()
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarEntregaDiio() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---" + vbCrLf + "¿DESEA IMPRIMIR VALE DE ENTREGA?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                btnGrabar.Visible = False
                btnSalir.Visible = False
                Me.BackColor = Color.White
                lblFirma.Visible = True
                lblFecha.Text = Format(Now(), "dd-MMM-yyyy HH:mm")
                lblFecha.Visible = True
                lblTitulo.Visible = True

                Me.Refresh()

                'Dim pf As New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
                ''pf.Form = Me
                'pf.PrintAction = Drawing.Printing.PrintAction.PrintToPreview
                'pf.PrinterSettings.DefaultPageSettings.Landscape = True
                'pf.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)

                Me.BackColor = SystemColors.Control
                btnGrabar.Visible = True
                btnSalir.Visible = True
                lblFirma.Visible = False
                lblFecha.Visible = False
                lblTitulo.Visible = False
            End If

            Cerrar()
        End If
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub txtDiioFin_LostFocus(sender As Object, e As System.EventArgs) Handles txtDiioFin.LostFocus
        CalcularDiios()
    End Sub


    Private Sub txtDiioIni_LostFocus(sender As Object, e As System.EventArgs) Handles txtDiioIni.LostFocus
        CalcularDiios()
    End Sub


    Private Sub frmAdministracionDiiosAsignacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaRecepcionadores()

        dtpFecha.Value = Now()
        'cboRecepcionadores.Text = LoginUsuario
    End Sub


    Private Sub txtObservs_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservs.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnGrabar_Click(sender, e)
        End If
    End Sub


    Private Sub cboRecepcionadores_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cboRecepcionadores.SelectionChangeCommitted
        txtDiioIni.Focus()
    End Sub
End Class