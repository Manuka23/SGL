


Imports System.Data.SqlClient



Public Class frmAdminDosisIngreso

    Public Param0_ModoIngreso As Integer        '
    Public Param1_Empresa As Integer
    Public Param2_Codigo As Integer

    Public Param3_ProveedorCod As Integer
    Public Param3_ProveedorNom As String
    Public Param4_NroDoc As String
    Public Param5_TipoDoc As String
    Public Param6_FechaRecep As DateTime
    Public Param7_FechaDoc As DateTime
    Public Param8_Observs As String
    Public Param9_RutNomProd As String

    Public CodigoIngresoSemen As Integer



    Private Sub CboLLenaProveedores()
        If General.Proveedores.NroRegistros = 0 Then Exit Sub
        cboProveedores.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Proveedores.NroRegistros - 1
            cboProveedores.Items.Add(General.Proveedores.NombreRut(i))
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


    Private Sub CboLLenaRazas()
        If General.Razas.NroRegistros = 0 Then Exit Sub
        cboRazas.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Razas.NroRegistros - 1
            cboRazas.Items.Add(General.Razas.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaToros()
        If General.Toros.NroRegistros = 0 Then Exit Sub
        cboToros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Toros.NroRegistros - 1
            cboToros.Items.Add(General.Toros.Nombre(i))
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
            'txtDiioFin.Focus()
            Exit Function
        End If


        If dtpFechaDoc.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            'txtDiioFin.Focus()
            Exit Function
        End If


        If cboRazas.SelectedIndex = -1 Then
            If MsgBox("EL TORO DEBE TENER ASIGNADA UNA RAZA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboToros.Focus()
            Exit Function
        End If

        Dim nro As Integer = 0

        If txtDetNroDosis.Text <> "" Then nro = Convert.ToInt32(txtDetNroDosis.Text)

        If (lvDETALLE.Items.Count = 0 Or lblNroDosis.Text = "0") And nro = 0 Then
            If MsgBox("DEBE INGRESAR DOSIS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            'txtDiioFin.Focus()
            Exit Function
        End If


        ValidacionesLocales = True
    End Function


    Private Function GrabarDosisSemen() As Boolean
        GrabarDosisSemen = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDosis_GrabarIngreso", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim prov_ As Integer = 0
        Dim tdoc_ As Integer = 0
        Dim raza_ As Integer = 0
        Dim toro_ As String = ""
        '
        prov_ = General.Proveedores.Codigo(cboProveedores.SelectedIndex)
        tdoc_ = General.TipoDocumentos.Codigo(cboTiposDocs.SelectedIndex)
        raza_ = General.Razas.Codigo(cboRazas.SelectedIndex)
        toro_ = General.Toros.Codigo(cboToros.SelectedIndex)
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Codigo", CodigoIngresoSemen)
        cmd.Parameters.AddWithValue("@Proveedor", prov_)
        cmd.Parameters.AddWithValue("@TipoDoc", tdoc_)
        cmd.Parameters.AddWithValue("@NroDoc", txtNroDoc.Text)
        cmd.Parameters.AddWithValue("@FechaDoc", dtpFechaDoc.Value)
        cmd.Parameters.AddWithValue("@FechaRecep", dtpFechaRecep.Value)
        cmd.Parameters.AddWithValue("@Observs", txtObservs.Text.Trim)
        '
        cmd.Parameters.AddWithValue("@DetCodigoToro", toro_)
        'cmd.Parameters.AddWithValue("@DetNombreToro", cboToros.Text)
        'cmd.Parameters.AddWithValue("@DetRaza", raza_)
        cmd.Parameters.AddWithValue("@DetMKBW", "")
        cmd.Parameters.AddWithValue("@DetNroDosis", txtDetNroDosis.Text)
        '
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetCodigo", SqlDbType.Int) : cmd.Parameters("@RetCodigo").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Dim codret As Integer = cmd.Parameters("@RetCodigo").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            Param2_Codigo = codret
            CodigoIngresoSemen = codret
            GrabarDosisSemen = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Public Sub ConsultaDetalleDosis()
        'lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = 0
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDosis_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Codigo", Param2_Codigo)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvDETALLE.BeginUpdate()
        lvDETALLE.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0
        Dim tot As Integer = 0

        lblNroToros.Text = "0"
        lblNroDosis.Text = "0"

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    pbProcesa.Maximum = vret
                    'End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                    ''
                    item.SubItems.Add(rdr("ToroCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("ToroNombre").ToString.Trim)
                    item.SubItems.Add(rdr("NomRaza").ToString.Trim)
                    item.SubItems.Add(IIf(rdr("ToroSexado") = 1, "SI", "NO"))
                    item.SubItems.Add(rdr("DSemDosisToroComp").ToString.Trim)
                    item.SubItems.Add(rdr("DSemDosisToroEnt").ToString.Trim)
                    item.SubItems.Add(rdr("DSemCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("DSemMKBW").ToString.Trim)
                    ''
                    lvDETALLE.Items.Add(item)

                    'ProcesaTotales(rdr("PrvRazSoc").ToString.Trim, rdr("DSemTotalComprados"), rdr("DSemTotalEntregados"), rdr("DSemTotalLibres"), rdr("DSemTotalUsados"))
                    tot = tot + rdr("DSemDosisToroComp")
                    i = i + 1
                    'pbProcesa.Value = i
                End While

                'pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvDETALLE.EndUpdate()

        lblNroToros.Text = i.ToString.Trim
        lblNroDosis.Text = tot.ToString.Trim
    End Sub


    Private Function EliminarDosisToro(ByVal toro_ As String) As Boolean
        EliminarDosisToro = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDosis_EliminarDosisToro", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Codigo", Param2_Codigo)                   'codigo compra
        cmd.Parameters.AddWithValue("@CodigoToro", toro_)            'codigo toro
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

            EliminarDosisToro = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function



    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor

        Me.Close()

        frmAdminDosis.Enabled = True
        'frmAdminDosis.LlenaGrilla()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        'If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        '    Exit Sub
        'End If

        If GrabarDosisSemen() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            DeshabilitarEncabezado()
            LimpiaDetalle()

            ConsultaDetalleDosis()
            'frmAdminDosis.LlenaGrilla()

            cboToros.Focus()
        End If
    End Sub


    Private Sub DeshabilitarEncabezado()
        cboProveedores.Enabled = False
        txtNroDoc.Enabled = False
        cboTiposDocs.Enabled = False
        dtpFechaRecep.Enabled = False
        dtpFechaDoc.Enabled = False
        txtObservs.Enabled = False
    End Sub


    Private Sub LimpiaDetalle()
        txtDetNroDosis.Text = ""
        cboRazas.SelectedIndex = -1
        cboToros.SelectedIndex = -1
        chkSexado.Checked = False
    End Sub


    Private Sub cboProveedores_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboProveedores.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.Handled = False
        End If
    End Sub


    Private Sub txtNroDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub cboTiposDocs_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboTiposDocs.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.Handled = False
        End If
    End Sub


    Private Sub dtpFecha_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaRecep.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.Handled = False
        End If
    End Sub


    Private Sub dtpFechaDoc_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaDoc.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.Handled = False
        End If
    End Sub


    Private Sub txtObservs_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservs.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtDetCodigo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.Handled = False
        End If

        'If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
        '    e.Handled = True
        'End If
    End Sub


    Private Sub txtDetToro_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.Handled = False
        End If
    End Sub


    Private Sub cboRazas_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboRazas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
            e.Handled = False
        End If
    End Sub


    Private Sub txtDetMKBW_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtDetNroDosis_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDetNroDosis.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnGrabar_Click(sender, e)
            Exit Sub
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
        frmAdminDosis.LlenaGrilla()
    End Sub


    Private Sub frmAdminDosisIngreso_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        cboProveedores.Focus()
    End Sub


    Private Sub frmPalpacionesIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        General.Toros.Cargar()

        CboLLenaProveedores()
        CboLLenaTipoDocumentos()
        CboLLenaToros()
        CboLLenaRazas()

        cboTiposDocs.Text = "FACTURA COMPRA"
        'cboTiposDocs.Enabled = False

        If Param0_ModoIngreso = 1 Then
            dtpFechaDoc.Value = Now()
            dtpFechaRecep.Value = Now()
        Else
            cboProveedores.Text = Param9_RutNomProd
            txtNroDoc.Text = Param4_NroDoc
            cboTiposDocs.Text = Param5_TipoDoc
            dtpFechaRecep.Value = Param6_FechaRecep
            dtpFechaDoc.Value = Param7_FechaDoc
            txtObservs.Text = Param8_Observs

            CodigoIngresoSemen = Param2_Codigo
            'lvDETALLE.Top = 144
            'lvDETALLE.Height = 341

            DeshabilitarEncabezado()
            ConsultaDetalleDosis()
        End If
    End Sub


    Private Sub cboToros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboToros.SelectedIndexChanged
        If cboToros.SelectedIndex = -1 Then Exit Sub

        cboRazas.Text = General.Toros.NomRaza(cboToros.SelectedIndex).Trim
        chkSexado.Checked = General.Toros.Sexado(cboToros.SelectedIndex)
        txtDetNroDosis.Focus()
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        With frmTorosIngreso
            .Param1_Modo = 2
            .ShowDialog()

            If .Out1_ValRet = 1 Then
                General.Toros.Cargar()
                CboLLenaToros()
            End If
        End With
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvDETALLE.SelectedItems.Count = 0 Then Exit Sub

        Dim cod_ As String = lvDETALLE.SelectedItems.Item(0).SubItems(1).Text
        'If cod_ = 0 Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA ELIMINAR EL REGISTRO DE DOSIS SELECCIONADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarDosisToro(cod_) = True Then
            'If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            'LimpiaDatos()
            'cboCentros.Focus()

            'frmAdminDiios.LlenaGrilla()
            ConsultaDetalleDosis()

            If lvDETALLE.Items.Count = 0 Then
                Cerrar()
                frmAdminDosis.LlenaGrilla()
            End If

        End If
    End Sub
End Class

