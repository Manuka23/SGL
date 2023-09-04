


Imports System.Data.SqlClient



Public Class frmAdminDiiosIngreso

    Public Param0_ModoIngreso As Integer        '
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_CodigoVeterinario As Integer
    Public Param4_NombreVeterinario As String



    Private Sub LimpiaDatos()
        cboProveedores.SelectedIndex = -1
        cboTiposDocs.SelectedIndex = -1
        '
        txtNroDoc.Text = ""
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


    Private Sub CboLLenaProveedores()
        If General.Proveedores.NroRegistros = 0 Then Exit Sub
        cboProveedores.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Proveedores.NroRegistros - 1
            cboProveedores.Items.Add(General.Proveedores.Nombre(i) + " (" + General.Proveedores.NombreRut(i).Trim + ")")
        Next
    End Sub


    Private Sub CboLLenaTipoDocumentos()
        If General.TipoDocumentos.NroRegistros = 0 Then Exit Sub
        cboTiposDocs.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoDocumentos.NroRegistros - 1
            cboTiposDocs.Items.Add(General.TipoDocumentos.Nombre(i))
        Next
    End Sub


    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If cboProveedores.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN PROVEEDOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboProveedores.Focus()
            Exit Function
        End If

        If cboTiposDocs.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DOCUMENTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTiposDocs.Focus()
            Exit Function
        End If

        'If IsNumeric(txtNroDoc.Text) = False Then
        '    If MsgBox("DEBE INGRESAR UN NRO DE DOCUMENTO CORRECTAMENTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtDiioFin.Focus()
        '    Exit Function
        'End If

        If Val(txtNroDoc.Text) <= 0 Then
            If MsgBox("DEBE INGRESAR UN NRO DE DOCUMENTO CORRECTAMENTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtDiioFin.Focus()
            Exit Function
        End If


        If dtpFechaDoc.Value > Now() Then
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

        ValidacionesLocales = True
    End Function


    Private Function GrabarIngresoDiio() As Boolean
        GrabarIngresoDiio = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDiios_GrabarIngreso", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim prov_ As Integer = 0
        Dim tdoc_ As Integer = 0
        '
        prov_ = General.Proveedores.Codigo(cboProveedores.SelectedIndex)
        tdoc_ = General.TipoDocumentos.Codigo(cboTiposDocs.SelectedIndex)
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ADProveedor", prov_)
        cmd.Parameters.AddWithValue("@ADTipoDoc", tdoc_)
        cmd.Parameters.AddWithValue("@ADNroDoc", txtNroDoc.Text)
        cmd.Parameters.AddWithValue("@ADFechaDoc", dtpFechaDoc.Value)
        cmd.Parameters.AddWithValue("@ADFechaRecep", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@ADNumInicial", Val(txtDiioIni.Text))
        cmd.Parameters.AddWithValue("@ADNumFinal", Val(txtDiioFin.Text))
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

            GrabarIngresoDiio = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor

        Me.Close()

        frmAdminDiios.Enabled = True
        frmAdminDiios.LlenaGrilla()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub txtNroDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDoc.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiioIni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiioIni.KeyPress
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtDiioFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiioFin.KeyPress
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

        If GrabarIngresoDiio() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            Cerrar()
            'LimpiaDatos()
            'cboProveedores.Focus()
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


    Private Sub frmPalpacionesIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaProveedores()
        CboLLenaTipoDocumentos()

        dtpFechaDoc.Value = Now()
        dtpFecha.Value = Now()
    End Sub


End Class