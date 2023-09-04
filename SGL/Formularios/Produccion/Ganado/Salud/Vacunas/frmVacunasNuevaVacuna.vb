Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmVacunasNuevaVacuna
    Public codigo As String
    Public nombre As String
    Public UnidadMedida As String
    Private VacListado As frmVacunasListado
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub lista_usuarios_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvArticulos.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvArticulos, e)
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim n As Integer = lvArticulos.Items.Count.ToString
        For i = 0 To n - 1
            If txtCodigo.Text.Trim = lvArticulos.Items(i).SubItems(1).Text.Trim Then
                MsgBox("Vacuna ya existente", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Next
        If NuevaVacuna() = True Then
            lvArticulos.Items.Clear()
            BuscarVacunas()
        End If
    End Sub

    Private Sub frmVacunasNuevaVacuna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        BuscarVacunas()

    End Sub
    Public Sub codnom()
        txtCodigo.Text = codigo
        txtNombre.Text = nombre
    End Sub

    Public Sub BuscarVacunas()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        lvArticulos.Items.Clear()
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            Try
                While rdr.Read()
                    i = i + 1

                    Dim lvitem As New ListViewItem(i)    'primera columna, para ordenar los datos
                    lvitem.SubItems.Add(rdr("codigo").trim.ToString)
                    lvitem.SubItems.Add(rdr("nombre").trim.ToString)
                    lvitem.SubItems.Add(rdr("dosis").trim.ToString)
                    lvitem.SubItems.Add(rdr("medida").trim.ToString)
                    lvArticulos.Items.Add(lvitem)
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Public Function NuevaVacuna() As Boolean
        NuevaVacuna = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_NuevaVacuna", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@VacCodigo", txtCodigo.Text)
        cmd.Parameters.AddWithValue("@VacAlias", txtAlias.Text)
        cmd.Parameters.AddWithValue("@VacNombre", txtNombre.Text)
        cmd.Parameters.AddWithValue("@VacDosis ", txtDosis.Text)
        cmd.Parameters.AddWithValue("@VacUnidadMedida", UnidadMedida)
        cmd.Parameters.AddWithValue("@VacUsuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@VacEquipo", NombrePC)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@Duplicado", SqlDbType.Int) : cmd.Parameters("@Duplicado").Direction = ParameterDirection.Output
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Dim dup As Integer = cmd.Parameters("@Duplicado").Value

            If dup = "1" Then
                MsgBox("Codigo de Vacuna ya ingresado en inventario de vacunas", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                NuevaVacuna = False
                Exit Function
            End If

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
        MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        NuevaVacuna = True
        Cursor.Current = Cursors.Default

    End Function



    Public Function BuscarArticulos() As Boolean
        BuscarArticulos = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spArticulos_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Operacion", "BuscarNombre")
        cmd.Parameters.AddWithValue("@CodVacuna", txtCodigo.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()

                    If rdr("Codigo") <> "" Then
                        txtNombre.Text = rdr("descripcion").ToString
                        UnidadMedida = rdr("medida").ToString
                        BuscarArticulos = True
                    Else
                        BuscarArticulos = False
                    End If

                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Function

    Private Sub txtCodigo_LostFocus(sender As Object, e As EventArgs) Handles txtCodigo.LostFocus
        If txtCodigo.Text = "" Then
            Exit Sub
        End If
        If BuscarArticulos() = True Then
            btnGrabar.Enabled = True
        Else
            If MsgBox("Codigo no encontrado en inventario, ingresar un codigo valido", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                btnGrabar.Enabled = False
            End If
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigo.TextChanged
        If BuscarArticulos() = True Then
            btnGrabar.Enabled = True
        Else
            btnGrabar.Enabled = False
        End If
    End Sub
    Private Function EliminaVacuna()
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        EliminaVacuna = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVacunas_EliminaVacuna", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        Dim vacuna As String = ""

        vacuna = lvArticulos.SelectedItems.Item(0).SubItems(1).Text

        cmd.Parameters.AddWithValue("@Vacuna", vacuna)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            EliminaVacuna = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿ DESEA ELIMINAR LA VACUNA SELECCIONADA?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If EliminaVacuna() = True Then

            BuscarVacunas()
        End If
    End Sub

    Private Sub Consultar_Click_1(sender As Object, e As EventArgs) Handles Consultar.Click
        Cursor.Current = Cursors.WaitCursor
        VacListado = New frmVacunasListado
        VacListado.ShowDialog()
        codnom()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtAlias.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub txtAlias_TextChanged(sender As Object, e As EventArgs) Handles txtAlias.TextChanged

    End Sub

    Private Sub txtAlias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlias.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDosis.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged
        txtDosis.Text = ""
        txtAlias.Text = ""
    End Sub
End Class