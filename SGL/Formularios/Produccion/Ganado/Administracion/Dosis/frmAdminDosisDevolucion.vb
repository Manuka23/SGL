


Imports System.Data.SqlClient




Public Class frmAdminDosisDevolucion

    'Public Param0_ModoIngreso As Integer        '
    'Public Param1_CodigoCentro As String
    'Public Param2_NombreCentro As String
    Public Param0_CodigoCompra As Integer
    Public Param1_CodigoToro As String
    Public Param2_NombreToro As String
    Public Param3_CodigoCentro As String
    Public Param4_NombreCentro As String
    Public Param5_DosisLibres As Integer


    Private Sub LimpiaDatos()
        cboCentros.SelectedIndex = -1
        cboRecepcionadores.SelectedIndex = -1
        '
        txtNombreToro.Text = ""
        txtNroDosis.Text = ""
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
        cboRecepcionadores.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Recepcionadores.NroRegistros - 1
            cboRecepcionadores.Items.Add(General.Recepcionadores.Nombre(i))
        Next
    End Sub


    Private Function BuscaNombreToro(ByVal cod_toro As String) As String
        BuscaNombreToro = ""

        Dim i As Integer
        Dim nom As String = ""

        For i = 0 To General.Toros.Codigo.Length - 1
            'If Not General.Razas.Codigo(i) Is Nothing Then
            If General.Toros.Codigo(i) = cod_toro Then
                nom = General.Toros.Nombre(i)
                Exit For
            End If
            'End If
        Next

        BuscaNombreToro = nom
    End Function


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
            txtNroDosis.Focus()
            Exit Function
        End If

        If cboRecepcionadores.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN RECEPCIONADOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboRecepcionadores.Focus()
            Exit Function
        End If

        If Val(txtNroDosis.Text) <= 0 Then
            If MsgBox("DEBE INGRESAR DOSIS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNombreToro.Focus()
            Exit Function
        End If


        ValidacionesLocales = True
    End Function


    Private Function GrabarDevolucionDosis() As Boolean
        GrabarDevolucionDosis = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDosis_GrabarDevolucion", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim recep_ As String = ""
        '

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        recep_ = General.Recepcionadores.Codigo(cboRecepcionadores.SelectedIndex)
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Codigo", Param0_CodigoCompra)
        cmd.Parameters.AddWithValue("@FechaDevolucion", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Toro", Param1_CodigoToro)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Recepcionador", recep_)
        cmd.Parameters.AddWithValue("@NroDosis", Val(txtNroDosis.Text))
        'cmd.Parameters.AddWithValue("@Observs", txtObservs.Text.Trim)
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

            GrabarDevolucionDosis = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()

        frmAdminDosis.Enabled = True
        'frmAdminDiios.LlenaGrilla()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub txtNrodosis_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDosis.KeyPress
        'If e.KeyChar = ChrW(Keys.Enter) Then
        '    txtNroDosis.Focus()
        'End If

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

        If GrabarDevolucionDosis() = True Then

            Cerrar()
            frmAdminDosis.LlenaGrilla()

        End If
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub frmAdministracionDiiosAsignacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaRecepcionadores()

        dtpFecha.Value = Now()

        cboCentros.Text = Param4_NombreCentro
        txtNombreToro.Text = BuscaNombreToro(Param1_CodigoToro)
        txtNroLibres.Text = Param5_DosisLibres.ToString
        'cboRecepcionadores.Text = LoginUsuario
    End Sub


    Private Sub txtObservs_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservs.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnGrabar_Click(sender, e)
        End If
    End Sub


    Private Sub cboRecepcionadores_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles cboRecepcionadores.SelectionChangeCommitted
        txtNombreToro.Focus()
    End Sub
End Class