Imports System.Data.SqlClient
Public Class frmMedicamentosIngreso
    Public vigente As Integer
    Public lactancia As Integer
    Public Preventivo As Integer
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If MsgBox("¿ DESEA GRABAR DATOS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If Validaciones() = True Then
            If Label11.Text = "Modificar Medicamento" Then
                ModificarrMedicamento()
            Else
                CrearMedicamento()
            End If
        Else
            MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
        End If

    End Sub
    Private Function Validaciones() As Boolean
        Validaciones = False


        If txtduracion.Text <> "" And txtDiasduracion.Text <> "" And txtsag.Text <> "" And
            txtnombre.Text <> "" And txtdosis.Text <> "" And estado.SelectedIndex <> 0 And txtcarne.Text <> "" And txtleche.Text <> "" And ComboBox1.SelectedIndex <> 0 And ComboBox2.SelectedIndex <> 0 Then
            Validaciones = True
        Else
            Validaciones = False
        End If
    End Function

    Private Sub frmMedicamentosIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLlena()
        CboLlenaVacaLactancia()
        CboLlenaPreventivo()
        UnidadMedida()
        If Label11.Text = "Modificar Medicamento" Then
            estado.SelectedIndex = vigente
            ComboBox1.SelectedIndex = lactancia
            ComboBox2.SelectedIndex = Preventivo
        End If
    End Sub
    Private Sub CboLlenaPreventivo()

        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("-Seleccione-")
        ComboBox2.Items.Add("SI")
        ComboBox2.Items.Add("NO")

        ComboBox2.SelectedIndex = 0
    End Sub
    Private Sub ModificarrMedicamento()
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim modif As Integer = 0

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_ModificarMedicamento", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@MedEquipo", NombrePC)
        cmd.Parameters.AddWithValue("@MedUsuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@MedNombre", txtnombre.Text)
        cmd.Parameters.AddWithValue("@MedRegSag", txtsag.Text)
        cmd.Parameters.AddWithValue("@TratDosis", txtdosis.Text)
        cmd.Parameters.AddWithValue("@TratDuracionTrat", txtduracion.Text)
        cmd.Parameters.AddWithValue("@TratDiasDuracion", txtDiasduracion.Text)
        cmd.Parameters.AddWithValue("@TratObservacion", txtObservs.Text)
        cmd.Parameters.AddWithValue("@TratResguardoLeche", txtleche.Text)
        cmd.Parameters.AddWithValue("@TratResguardoCarne", txtcarne.Text)
        cmd.Parameters.AddWithValue("@MedVacasLactancia", ComboBox1.SelectedIndex)
        cmd.Parameters.AddWithValue("@MedPreventivo", ComboBox2.SelectedIndex)
        cmd.Parameters.AddWithValue("@TratCodGP", txtItemCodigo.Text)
        cmd.Parameters.AddWithValue("@UMedida", cboUMedida.Text)
        cmd.Parameters.AddWithValue("@MedVigente", estado.SelectedIndex)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value


            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
        MsgBox("Datos Modificados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub CrearMedicamento()
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim modif As Integer = 0

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_CrearMedicamento", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@MedEquipo", NombrePC)
        cmd.Parameters.AddWithValue("@MedUsuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@MedNombre", txtnombre.Text)
        cmd.Parameters.AddWithValue("@MedRegSag", txtsag.Text)
        cmd.Parameters.AddWithValue("@TratDosis", txtdosis.Text)
        cmd.Parameters.AddWithValue("@TratDuracionTrat", txtduracion.Text)
        cmd.Parameters.AddWithValue("@TratDiasDuracion", txtDiasduracion.Text)
        cmd.Parameters.AddWithValue("@TratObservacion", txtObservs.Text)
        cmd.Parameters.AddWithValue("@TratResguardoLeche", txtleche.Text)
        cmd.Parameters.AddWithValue("@TratResguardoCarne", txtcarne.Text)
        cmd.Parameters.AddWithValue("@TratCodGP", txtItemCodigo.Text)
        cmd.Parameters.AddWithValue("@MedVacasLactancia", ComboBox1.SelectedIndex)
        cmd.Parameters.AddWithValue("@MedPreventivo", ComboBox2.SelectedIndex)
        cmd.Parameters.AddWithValue("@UMedida", cboUMedida.DisplayMember)
        cmd.Parameters.AddWithValue("@MedVigente", estado.SelectedIndex)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value


            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    Exit Sub
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
        MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub CboLlenaVacaLactancia()

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("-Seleccione-")
        ComboBox1.Items.Add("SI")
        ComboBox1.Items.Add("NO")

        ComboBox1.SelectedIndex = 0
    End Sub
    Private Sub CboLlena()

        estado.Items.Clear()
        estado.Items.Add("-Seleccione-")
        estado.Items.Add("SI")
        estado.Items.Add("NO")

        estado.SelectedIndex = 0
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub



    Private Sub txtDiasduracion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiasduracion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDiasduracion.Text = txtDiasduracion.Text.Trim
            e.Handled = True
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub



    Private Sub txtleche_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtleche.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtleche.Text = txtleche.Text.Trim
            e.Handled = True
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub



    Private Sub txtcarne_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcarne.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtcarne.Text = txtcarne.Text.Trim
            e.Handled = True
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItemCodigo.KeyPress
        'txtItemCodigo.Text = ""
        If e.KeyChar = ChrW(Keys.Enter) Then
            BuscarProductoCod()
            e.Handled = True
        End If
    End Sub
    Private Function BuscarProductoCod() As Boolean
        BuscarProductoCod = False
        If txtItemCodigo.Text.Trim = "" Then Exit Function

        Dim con As New SqlConnection(GetConnectionStringFIN()) 'IIf(SRV_Servidor <> "SRVMNK", GetConnectionStringFIN(), GetConnectionString()))
        Dim cmd As New SqlCommand("spGPProductos_BuscarProductoCod", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ProductoCod", txtItemCodigo.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If rdr("IteNom").ToString.Trim = "NO EXISTE EN LA EMPRESA GP" Then
                        lblItemCodigo.Text = rdr("IteNom").ToString.Trim
                        txtnombre.Text = ""
                        btnGrabar.Enabled = False
                    Else
                        txtnombre.Text = rdr("IteNom").ToString.Trim
                        lblItemCodigo.Text = "---"
                        btnGrabar.Enabled = True
                    End If

                    Existe = True

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        BuscarProductoCod = Existe
    End Function
    Private Sub txtItemCodigo_Leave(sender As Object, e As EventArgs) Handles txtItemCodigo.Leave
        BuscarProductoCod()
    End Sub
    Private Sub UnidadMedida()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUnidadMedida", con)
        Dim rdr As SqlDataReader = Nothing

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        da.SelectCommand = cmd
        da.Fill(dt)

        cboUMedida.ValueMember = "UMCod"
        cboUMedida.DisplayMember = "UMNom"
        cboUMedida.DataSource = dt
    End Sub
End Class