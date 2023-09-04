
'Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Imports System.Data.SqlClient
'Imports Microsoft.Office.Interop.Excel

Public Class frmProductosUreaIngresoDetalle
    Public Actualizar As Integer = 0
    Public Cuenta As Integer = 0
    Public ItemGasto As String = 0
    Public FertUsoCod As Integer = 0
    Public TipoCentro As String = ""
    Public Nitrogeno As Decimal = 0
    Public Azufre As Integer = 0
    Public Potasio As Decimal = 0
    Public Fosforo As Decimal = 0

    Private Function Actualizacion() As Boolean
        Actualizacion = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spProductos_ActualizarProductoUrea", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Producto", txtCodProducto.Text)
        cmd.Parameters.AddWithValue("@Cuenta", txtCodCuenta.Text)
        cmd.Parameters.AddWithValue("@ItemPpto", txtCodPresupuesto.Text)
        cmd.Parameters.AddWithValue("@Cuenta2", txtCodCuenta2.Text)
        cmd.Parameters.AddWithValue("@ItemPpto2", txtCodPresupuesto2.Text)
        cmd.Parameters.AddWithValue("@LimiteConsumo", txtLimiteConsumo.Text)
        cmd.Parameters.AddWithValue("@Nitro", txtNitro.Text.Replace(",", "."))

        cmd.Parameters.AddWithValue("@CuentaAnt", Cuenta)
        cmd.Parameters.AddWithValue("@ItemPptoAnt", ItemGasto)
        cmd.Parameters.AddWithValue("@FertUsoCod", cboTipoUso.SelectedValue)
        cmd.Parameters.AddWithValue("@TipoCentro", tipCentro.Text)
        cmd.Parameters.AddWithValue("@Azufre", txtAzufre.Text)
        cmd.Parameters.AddWithValue("@Potasio", txtPotasio.Text.Replace(",", "."))
        cmd.Parameters.AddWithValue("@Fosforo", txtFosforo.Text.Replace(",", "."))
        '
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
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
                End If
                Exit Function
            End If

            ''si todo sale ok, retornamos ok
            Actualizacion = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function
    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If ValidacionesLocales() = False Then Exit Sub
        If Actualizar = 1 Then
            'CONFIRMAR
            If MsgBox("¿ DESEA ACTUALIZAR EL PRODUCTO UREA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            If Actualizacion() = True Then
                Me.Close()
                frmProductosUreaIngreso.ConsultaProductos()
            End If


        Else
            'CONFIRMAR
            If MsgBox("¿ DESEA AGREGAR EL PRODUCTO UREA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If


            If GrabarProducto() = True Then
                Me.Close()
                frmProductosUreaIngreso.ConsultaProductos()
            End If
        End If


    End Sub
    Private Function GrabarProducto() As Boolean
        GrabarProducto = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spProductos_GrabarProductoUrea", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Producto", txtCodProducto.Text)
        cmd.Parameters.AddWithValue("@Cuenta", txtCodCuenta.Text)
        cmd.Parameters.AddWithValue("@ItemPpto", txtCodPresupuesto.Text)
        cmd.Parameters.AddWithValue("@Cuenta2", txtCodCuenta2.Text)
        cmd.Parameters.AddWithValue("@ItemPpto2", txtCodPresupuesto2.Text)
        cmd.Parameters.AddWithValue("@LimiteConsumo", txtLimiteConsumo.Text)
        cmd.Parameters.AddWithValue("@TipoCentro", tipCentro.Text)
        cmd.Parameters.AddWithValue("@Nitro", txtNitro.Text.Replace(",", "."))
        cmd.Parameters.AddWithValue("@FertUsoCod", cboTipoUso.SelectedValue)
        cmd.Parameters.AddWithValue("@Azufre", txtAzufre.Text.Replace(",", "."))
        cmd.Parameters.AddWithValue("@Potasio", txtPotasio.Text.Replace(",", "."))
        cmd.Parameters.AddWithValue("@Fosforo", txtFosforo.Text.Replace(",", "."))
        '
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
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
                End If
                Exit Function
            End If

            ''si todo sale ok, retornamos ok
            GrabarProducto = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function
    Private Sub frmProductosUreaIngresoDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Dim Cuenta As Integer = 0
        Dim ItemGasto As Integer = 0

        TipoUso()
        General.TipoCentros.Cargar()
        CboLLenaTipoCentro()

        If Actualizar = 1 Then
            BuscarCuenta(Cuenta)
            BuscarItemGasto(ItemGasto)
            BuscarProducto()
            tipCentro.SelectedIndex = tipCentro.FindStringExact(TipoCentro)
            cboTipoUso.SelectedValue = FertUsoCod
            txtNitro.Text = Nitrogeno
            txtAzufre.Text = Azufre
            txtPotasio.Text = Potasio
            txtFosforo.Text = Fosforo
        End If


    End Sub
    Private Sub CboLLenaTipoCentro()
        If General.TipoCentros.NroRegistros = 0 Then Exit Sub
        tipCentro.Items.Clear()
        tipCentro.Items.Add("(Todos)")
        Dim i As Integer
        For i = 0 To General.TipoCentros.NroRegistros - 1
            tipCentro.Items.Add(General.TipoCentros.Nombre(i))
        Next
        tipCentro.SelectedIndex = 0
    End Sub
    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False
        Dim nitro As Decimal = txtNitro.Text

        If cboTipoUso.SelectedValue = 1 Then
            If txtNitro.Text = "" Or txtAzufre.Text = "" Then
                If MsgBox("DEBE RELLENAR LOS CAMPOS DE % DE NITROGENO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    Exit Function
                End If
            End If
        End If

        If nitro > 99 Then
            If MsgBox("EL % DE NITROGENO NO PUEDE SER SUPERIOR AL 99%", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNitro.Focus()
            Exit Function
        End If


        If txtCodProducto.Text.Trim = "" Or txtNomProducto.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN PRODUCTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtCodProducto.Focus()
            Exit Function
        End If

        If txtCodCuenta.Text.Trim = "" Or txtNomCuenta.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UNA CUENTA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtCodCuenta.Focus()
            Exit Function
        End If

        'If txtCodPresupuesto.Text.Trim = "" Then
        '    If MsgBox("DEBE INGRESAR UN ITEM DE GASTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    txtCodPresupuesto.Focus()
        '    Exit Function
        'End If

        If tipCentro.Text = "(Todos)" Then
            If MsgBox("DEBE INGRESAR UN TIPO DE CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            Exit Function
        End If

        ValidacionesLocales = True
    End Function

    Private Sub txtCodProducto_Lostfocus(sender As Object, e As EventArgs) Handles txtCodProducto.LostFocus
        txtNomProducto.Text = ""
        If BuscarProducto() Then txtCodCuenta.Focus()

    End Sub

    Private Sub txtCodCuenta_Lostfocus(sender As Object, e As EventArgs) Handles txtCodCuenta.LostFocus
        Dim Cuenta As Integer = 1
        txtNomCuenta.Text = ""
        If BuscarCuenta(Cuenta) = True Then txtCodPresupuesto.Focus()

    End Sub

    Private Sub txtCodPresupuesto__KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodPresupuesto.KeyPress
        txtItemGasto.Text = ""
        Dim ItemGasto As Integer = 1
        If e.KeyChar = ChrW(Keys.Enter) Then
            BuscarItemGasto(ItemGasto)
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodPresupuesto_LostFocus(sender As Object, e As EventArgs) Handles txtCodPresupuesto.LostFocus
        txtItemGasto.Text = ""
        Dim ItemGasto As Integer = 1
        BuscarItemGasto(ItemGasto)
    End Sub
    Private Sub txtCodProducto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodProducto.KeyPress
        txtNomProducto.Text = ""

        If e.KeyChar = ChrW(Keys.Enter) Then
            If BuscarProducto() Then txtCodCuenta.Focus()
            e.Handled = True
        End If
    End Sub


    Private Sub txtCodCuenta_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodCuenta.KeyPress
        txtNomCuenta.Text = ""
        Dim Cuenta As Integer = 1
        If e.KeyChar = ChrW(Keys.Enter) Then
            If BuscarCuenta(Cuenta) Then txtCodPresupuesto.Focus()
            e.Handled = True
        End If

    End Sub

    Private Function BuscarProducto() As Boolean
        BuscarProducto = False
        If txtCodProducto.Text.Trim = "" Then Exit Function

        Dim con As New SqlConnection(GetConnectionStringFIN()) 'IIf(SRV_Servidor <> "SRVMNK", GetConnectionStringFIN(), GetConnectionString()))
        Dim cmd As New SqlCommand("spGPProductos_BuscarProducto", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Producto", txtCodProducto.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    txtNomProducto.Text = rdr("IteNom").ToString.Trim
                    Existe = True
                End While

                If Existe = False Then
                    MsgBox("---- PRODUCTO NO EXISTE ----")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        BuscarProducto = Existe
    End Function
    Private Function BuscarItemGasto(ByVal ItemGasto As Integer) As Boolean
        BuscarItemGasto = False
        If txtCodPresupuesto.Text.Trim = "" And txtCodPresupuesto2.Text.Trim = "" Then Exit Function

        Dim con As New SqlConnection(GetConnectionStringFIN()) 'IIf(SRV_Servidor <> "SRVMNK", GetConnectionStringFIN(), GetConnectionString()))
        Dim cmd As New SqlCommand("spGPProductos_BuscarItemGasto", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        If ItemGasto = 1 Then
            cmd.Parameters.AddWithValue("@Item", txtCodPresupuesto.Text)
        ElseIf ItemGasto = 2 Then
            cmd.Parameters.AddWithValue("@Item", txtCodPresupuesto2.Text)
        End If

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If ItemGasto = 1 Then
                        txtItemGasto.Text = rdr("IteNom").ToString.Trim
                    Else
                        lblItemGasto2.Text = rdr("IteNom").ToString.Trim
                    End If

                    Existe = True
                End While

                If Existe = False Then
                    MsgBox("---- Item NO EXISTE ----")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        BuscarItemGasto = Existe
    End Function

    Private Function BuscarCuenta(ByVal Cuenta As Integer) As Boolean
        BuscarCuenta = False
        If txtCodCuenta.Text.Trim = "" And txtCodCuenta2.Text.Trim = "" Then Exit Function

        Dim con As New SqlConnection(GetConnectionStringFIN())  'IIf(SRV_Servidor <> "SRVMNK", GetConnectionStringFIN(), GetConnectionString()))
        Dim cmd As New SqlCommand("spGPProductos_BuscarCuenta", con) 'IIf(SRV_Servidor <> "SRVMNK", "spGPProductos_BuscarCuenta", "spProductos_BuscarCuenta"), con)            'PARA PRUEBAS DE DBNET Y DINAMYCS
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)

        If Cuenta = 1 Then
            cmd.Parameters.AddWithValue("@Cuenta", txtCodCuenta.Text)
        ElseIf Cuenta = 2 Then
            cmd.Parameters.AddWithValue("@Cuenta", txtCodCuenta2.Text)
        End If

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If Cuenta = 1 Then
                        txtNomCuenta.Text = rdr("CtaNom").ToString.Trim
                    Else
                        txtNomCuenta2.Text = rdr("CtaNom").ToString.Trim
                    End If

                    Existe = True
                End While

                If Existe = False Then
                    MsgBox("---- CUENTA NO EXISTE ----")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        BuscarCuenta = Existe
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub TipoUso()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSuelo_TipoUso", con)
        Dim rdr As SqlDataReader = Nothing

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        da.SelectCommand = cmd
        da.Fill(dt)

        cboTipoUso.ValueMember = "FertCodigo"
        cboTipoUso.DisplayMember = "FertNombre"
        cboTipoUso.DataSource = dt

        If cboTipoUso.SelectedValue = 1 Then
            txtNitro.Enabled = True
            txtAzufre.Enabled = True
        Else
            txtNitro.Enabled = False
            txtAzufre.Enabled = False
        End If

    End Sub
    Private Sub txtGranulada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAzufre.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "," Then
            e.Handled = True
        End If

        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "." OrElse e.KeyChar = "," Then
            ' Reemplaza las comas por puntos para asegurar el formato decimal válido
            Dim normalizedChar As Char = If(e.KeyChar = ",", ".", e.KeyChar)

            Dim inputValueStr As String = txtAzufre.Text.Insert(txtAzufre.SelectionStart, normalizedChar)
            If Double.TryParse(inputValueStr, Nothing) Then
                Dim inputValue As Double = Double.Parse(inputValueStr)
                If inputValue > 100.0 Then
                    e.Handled = True
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtNitro_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtNitro.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "," Then
            e.Handled = True
        End If

        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "." OrElse e.KeyChar = "," Then
            ' Reemplaza las comas por puntos para asegurar el formato decimal válido
            Dim normalizedChar As Char = If(e.KeyChar = ",", ".", e.KeyChar)

            Dim inputValueStr As String = txtNitro.Text.Insert(txtNitro.SelectionStart, normalizedChar)
            If Double.TryParse(inputValueStr, Nothing) Then
                Dim inputValue As Double = Double.Parse(inputValueStr)
                If inputValue > 100.0 Then
                    e.Handled = True
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFosforo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFosforo.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "," Then
            e.Handled = True
        End If

        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "." OrElse e.KeyChar = "," Then
            ' Reemplaza las comas por puntos para asegurar el formato decimal válido
            Dim normalizedChar As Char = If(e.KeyChar = ",", ".", e.KeyChar)

            Dim inputValueStr As String = txtFosforo.Text.Insert(txtFosforo.SelectionStart, normalizedChar)
            If Double.TryParse(inputValueStr, Nothing) Then
                Dim inputValue As Double = Double.Parse(inputValueStr)
                If inputValue > 100.0 Then
                    e.Handled = True
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtPotasio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPotasio.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "," Then
            e.Handled = True
        End If

        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "." OrElse e.KeyChar = "," Then
            ' Reemplaza las comas por puntos para asegurar el formato decimal válido
            Dim normalizedChar As Char = If(e.KeyChar = ",", ".", e.KeyChar)

            Dim inputValueStr As String = txtPotasio.Text.Insert(txtPotasio.SelectionStart, normalizedChar)
            If Double.TryParse(inputValueStr, Nothing) Then
                Dim inputValue As Double = Double.Parse(inputValueStr)
                If inputValue > 100.0 Then
                    e.Handled = True
                End If
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cboTipoUso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoUso.SelectedIndexChanged
        If cboTipoUso.Text = "OTROS FERTILIZANTES" Then
            txtCodCuenta2.Enabled = True
            txtCodPresupuesto2.Enabled = True
            txtLimiteConsumo.Enabled = True
        Else
            txtCodCuenta2.Enabled = False
            txtCodPresupuesto2.Enabled = False
            txtLimiteConsumo.Enabled = False
        End If
    End Sub

    Private Sub txtCodCuenta2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodCuenta2.KeyPress
        txtNomCuenta2.Text = ""
        Dim cuenta As Integer = 2
        If e.KeyChar = ChrW(Keys.Enter) Then
            If BuscarCuenta(cuenta) Then txtCodPresupuesto2.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub txtCodCuenta2_Leave(sender As Object, e As EventArgs) Handles txtCodCuenta2.Leave
        Dim Cuenta As Integer = 2
        txtNomCuenta2.Text = ""
        If BuscarCuenta(Cuenta) = True Then txtCodPresupuesto2.Focus()
    End Sub

    Private Sub txtCodPresupuesto2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodPresupuesto2.KeyPress
        If String.IsNullOrWhiteSpace(txtCodPresupuesto2.Text) Then
            Return
        End If

        lblItemGasto2.Text = ""
        Dim ItemGasto As Integer = 2
        If e.KeyChar = ChrW(Keys.Enter) Then
            BuscarItemGasto(ItemGasto)
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodPresupuesto2_Leave(sender As Object, e As EventArgs) Handles txtCodPresupuesto2.Leave
        If String.IsNullOrWhiteSpace(txtCodPresupuesto2.Text) Then
            Return
        End If

        lblItemGasto2.Text = ""
        Dim ItemGasto As Integer = 2
        BuscarItemGasto(ItemGasto)
    End Sub

    Private Sub txtLimiteConsumo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLimiteConsumo.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub
End Class