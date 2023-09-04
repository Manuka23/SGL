Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Imports System.Data.SqlClient
Public Class frmProductosConcentradoDetalle
    Public Actualizar As Integer = 0
    Public Cuenta As Integer = 0
    Public ItemGasto As Integer = 0
    Public CbBi As Integer
    Public Estado As String


    Private Function Actualizacion() As Boolean
        Actualizacion = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spProductos_ActualizarProducto", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Kilos As Double = Convert.ToDecimal(txtKilos.Text)

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Producto", txtCodProducto.Text)
        cmd.Parameters.AddWithValue("@Cuenta", txtCodCuenta.Text)
        cmd.Parameters.AddWithValue("@ItemPpto", txtCodPresupuesto.Text)
        cmd.Parameters.AddWithValue("@UsaBI", CboBi.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@CuentaAnt", Cuenta)
        cmd.Parameters.AddWithValue("@ItemPptoAnt", ItemGasto)
        cmd.Parameters.AddWithValue("@Kilo", Kilos)
        'cmd.Parameters.AddWithValue("@Estado", Estado)

        cmd.Parameters.AddWithValue("@TipoCentro", tipCentro.Text)
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
            If MsgBox("¿ DESEA ACTUALIZAR EL PRODUCTO  ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            If CboBi.SelectedIndex = 0 Then
                MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End If
            If Actualizacion() = True Then
                Me.Close()
                frmProductosConcentrado.ConsultaProductos()
            End If


        Else
            'CONFIRMAR
            If MsgBox("¿ DESEA AGREGAR EL PRODUCTO  ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            If CboBi.SelectedIndex = 0 Then
                MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
                Exit Sub
            End If

            If GrabarProducto() = True Then
                Me.Close()
                frmProductosConcentrado.ConsultaProductos()
            End If
        End If

    End Sub
    Private Sub LimpiaDatos()
        txtCodProducto.Text = ""
        txtNomProducto.Text = ""
        txtCodCuenta.Text = ""
        txtNomCuenta.Text = ""
        txtCodPresupuesto.Text = ""
        tipCentro.SelectedIndex = 0
    End Sub
    Private Function GrabarProducto() As Boolean
        GrabarProducto = False
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spProductos_Grabar", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Kilos As Double = Convert.ToDecimal(txtKilos.Text)

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Producto", txtCodProducto.Text)
        cmd.Parameters.AddWithValue("@Cuenta", txtCodCuenta.Text)
        cmd.Parameters.AddWithValue("@ItemPpto", txtCodPresupuesto.Text)
        cmd.Parameters.AddWithValue("@TipoCentro", tipCentro.Text)
        cmd.Parameters.AddWithValue("@UsaBI", CboBi.SelectedIndex - 1)
        cmd.Parameters.AddWithValue("@Kilos", Kilos)
        'cmd.Parameters.AddWithValue("@Estado", Estado)

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

        CboBi.Items.Clear()
        CboBi.Items.Add("-Seleccione-")
        CboBi.Items.Add("NO")
        CboBi.Items.Add("SI")
        CboBi.SelectedIndex = 0

        cboEstado.Items.Clear()
        cboEstado.Items.Add("Desactivado")
        cboEstado.Items.Add("Activado")
        cboEstado.SelectedIndex = 1

        If Actualizar = 1 Then
            BuscarCuenta()
            BuscarItemGasto()
            BuscarProducto()
            CboBi.SelectedIndex = CbBi + 1
            If cboEstado.Text = "Activado" Then
                cboEstado.SelectedIndex = 1
            Else
                cboEstado.SelectedIndex = 0
            End If
        Else
            General.TipoCentros.Cargar()
            CboLLenaTipoCentro()
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

        If txtKilos.Text = "" Then
            If MsgBox("DEBE INGRESAR LOS KILOS DE CONVERSION, SI NO TIENE, COLOCAR 0", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtKilos.Focus()
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

        If txtCodPresupuesto.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN ITEM DE GASTO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtCodPresupuesto.Focus()
            Exit Function
        End If

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
        txtNomCuenta.Text = ""
        If BuscarCuenta() = True Then txtCodPresupuesto.Focus()

    End Sub

    Private Sub txtCodPresupuesto__KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodPresupuesto.KeyPress
        txtItemGasto.Text = ""
        If e.KeyChar = ChrW(Keys.Enter) Then
            BuscarItemGasto()
            e.Handled = True
        End If
    End Sub

    Private Sub txtCodPresupuesto_LostFocus(sender As Object, e As EventArgs) Handles txtCodPresupuesto.LostFocus
        txtItemGasto.Text = ""
        BuscarItemGasto()
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

        If e.KeyChar = ChrW(Keys.Enter) Then
            If BuscarCuenta() Then txtCodPresupuesto.Focus()
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
    Private Function BuscarItemGasto() As Boolean
        BuscarItemGasto = False
        If txtCodPresupuesto.Text.Trim = "" Then Exit Function

        Dim con As New SqlConnection(GetConnectionStringFIN()) 'IIf(SRV_Servidor <> "SRVMNK", GetConnectionStringFIN(), GetConnectionString()))
        Dim cmd As New SqlCommand("spGPProductos_BuscarItemGasto", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Item", txtCodPresupuesto.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    txtItemGasto.Text = rdr("IteNom").ToString.Trim
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

    Private Function BuscarCuenta() As Boolean
        BuscarCuenta = False
        If txtCodCuenta.Text.Trim = "" Then Exit Function

        Dim con As New SqlConnection(GetConnectionStringFIN())  'IIf(SRV_Servidor <> "SRVMNK", GetConnectionStringFIN(), GetConnectionString()))
        Dim cmd As New SqlCommand("spGPProductos_BuscarCuenta", con) 'IIf(SRV_Servidor <> "SRVMNK", "spGPProductos_BuscarCuenta", "spProductos_BuscarCuenta"), con)            'PARA PRUEBAS DE DBNET Y DINAMYCS
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Cuenta", txtCodCuenta.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    txtNomCuenta.Text = rdr("CtaNom").ToString.Trim
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

    Private Sub tipCentro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tipCentro.SelectedIndexChanged

    End Sub
End Class