Imports System.Data.SqlClient
Public Class frmUsuarios
    Dim buscarUsu As Integer = 0
    Private fbast As frmUsuarios_Nuevo
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 0
        Muestra_usuarios()

    End Sub
    Private Sub Muestra_usuarios()
        'lista_usuarios.Clear()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuarios_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@UserName", "")
        cmd.Parameters.AddWithValue("@CodPerfil", "")
        cmd.Parameters.AddWithValue("@Estado", "")
        '   cmd.Parameters.AddWithValue("@ResCre", "")

        lista_usuarios.BeginUpdate()
        lista_usuarios.Items.Clear()

        Dim i As Integer = 0
        Dim ea As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If buscarUsu = 1 Then
                        If rdr("UsrNombre").ToString.Trim.Contains(txtUsuario.Text) Then
                            Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, codigo del mensaje
                            item.SubItems.Add(rdr("UserName").ToString.Trim)
                            item.SubItems.Add(rdr("UsrNombre").ToString.Trim)
                            item.SubItems.Add(rdr("CodPerfil").ToString.Trim)
                            item.SubItems.Add(rdr("NomPerf").ToString.Trim)
                            item.SubItems.Add(rdr("Estado").ToString.Trim)
                            item.SubItems.Add(rdr("UsrCierraXLS").ToString.Trim)
                            item.SubItems.Add(rdr("UsrEliminaCierre").ToString.Trim)
                            item.SubItems.Add(rdr("UsrModDiasBaston").ToString.Trim)
                            item.SubItems.Add(rdr("UsrConfirmaAjuste").ToString.Trim)
                            item.SubItems.Add(rdr("UsrAdminConcent").ToString.Trim)
                            item.SubItems.Add(rdr("EliminaParto").ToString.Trim)
                            item.SubItems.Add(rdr("PermIngPartoAtrasado").ToString.Trim)
                            item.SubItems.Add(rdr("UsrGrabaLeche").ToString.Trim)
                            lista_usuarios.Items.Add(item)
                            i = i + 1
                        End If
                    Else
                        Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, codigo del mensaje
                        item.SubItems.Add(rdr("UserName").ToString.Trim)
                        item.SubItems.Add(rdr("UsrNombre").ToString.Trim)
                        item.SubItems.Add(rdr("CodPerfil").ToString.Trim)
                        item.SubItems.Add(rdr("NomPerf").ToString.Trim)
                        item.SubItems.Add(rdr("Estado").ToString.Trim)
                        item.SubItems.Add(rdr("UsrCierraXLS").ToString.Trim)
                        item.SubItems.Add(rdr("UsrEliminaCierre").ToString.Trim)
                        item.SubItems.Add(rdr("UsrModDiasBaston").ToString.Trim)
                        item.SubItems.Add(rdr("UsrConfirmaAjuste").ToString.Trim)
                        item.SubItems.Add(rdr("UsrAdminConcent").ToString.Trim)
                        item.SubItems.Add(rdr("EliminaParto").ToString.Trim)
                        item.SubItems.Add(rdr("PermIngPartoAtrasado").ToString.Trim)
                        item.SubItems.Add(rdr("UsrGrabaLeche").ToString.Trim)
                        lista_usuarios.Items.Add(item)
                        i = i + 1
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

        lista_usuarios.EndUpdate()
    End Sub

    Private Function eliminausuario()

        eliminausuario = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuario_ActivarDesactivar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim operacion As String = "Desactivar"
        Dim codusuario As String = ""

        codusuario = lista_usuarios.SelectedItems.Item(0).SubItems(1).Text

        ''
        cmd.Parameters.AddWithValue("@Operacion", operacion)
        cmd.Parameters.AddWithValue("@UserName", codusuario)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            eliminausuario = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        frmUsuarios_Nuevo.Show()

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lista_usuarios.Items.Count - 1
            If lista_usuarios.Items(i).Selected = True Then
                If lista_usuarios.Items(i).SubItems(5).Text = "0" Then
                    MsgBox("Usuario ya se encuentra Desactivado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Usuario de la Lista")
            Exit Sub
        End If

        If MsgBox("¿ DESEA DESACTIVAR EL USUARIO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If eliminausuario() = True Then
            Muestra_usuarios()
        End If
    End Sub

    Private Sub modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles modificar.Click
        fbast = New frmUsuarios_Nuevo



        Dim validalista As Integer = 0
        For i = 0 To lista_usuarios.Items.Count - 1
            If lista_usuarios.Items(i).Selected = True Then
                validalista = 1
                fbast.User = lista_usuarios.Items(i).SubItems(1).Text
                fbast.parto = lista_usuarios.Items(i).SubItems(11).Text
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Usuario de la Lista")
            Exit Sub
        End If


        fbast.ShowDialog()
        Muestra_usuarios()
    End Sub


    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim validalista As Integer = 0
        For i = 0 To lista_usuarios.Items.Count - 1
            If lista_usuarios.Items(i).Selected = True Then
                If lista_usuarios.Items(i).SubItems(5).Text = "1" Then
                    MsgBox("Usuario ya se encuentra Activado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Usuario de la Lista", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If MsgBox("¿ DESEA ACTIVAR EL USUARIO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If ActivarUsuario() = True Then


            Muestra_usuarios()
        End If
    End Sub
    Private Function ActivarUsuario()
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        ActivarUsuario = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuario_ActivarDesactivar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim operacion As String = "Activar"
        Dim codusuario As String = ""

        codusuario = lista_usuarios.SelectedItems.Item(0).SubItems(1).Text

        ''
        cmd.Parameters.AddWithValue("@Operacion", operacion)
        cmd.Parameters.AddWithValue("@UserName", codusuario)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            ActivarUsuario = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub lista_usuarios_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lista_usuarios.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lista_usuarios, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmAsignacionCentrosUsuarios.Show()
        frmAsignacionCentrosUsuarios.BringToFront()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmBodegas_AsignarUsuarios.Show()
        frmBodegas_AsignarUsuarios.BringToFront()
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        txtUsuario.Text = ""
        buscarUsu = 0
        Muestra_usuarios()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscarUsu = 1
        lista_usuarios.Items.Clear()
        BuscarUsuario()
    End Sub
    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            buscarUsu = 1
            lista_usuarios.Items.Clear()
            BuscarUsuario()
        End If
    End Sub
    Private Sub BuscarUsuario()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spUsuarios_ListadoBuscar", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@UserName", txtUsuario.Text)
        cmd.Parameters.AddWithValue("@CodPerfil", "")
        cmd.Parameters.AddWithValue("@Estado", "")
        lista_usuarios.BeginUpdate()
        lista_usuarios.Items.Clear()
        Dim i As Integer = 0
        Dim ea As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, codigo del mensaje
                    item.SubItems.Add(rdr("UserName").ToString.Trim)
                    item.SubItems.Add(rdr("UsrNombre").ToString.Trim)
                    item.SubItems.Add(rdr("CodPerfil").ToString.Trim)
                    item.SubItems.Add(rdr("NomPerf").ToString.Trim)
                    item.SubItems.Add(rdr("Estado").ToString.Trim)
                    item.SubItems.Add(rdr("UsrCierraXLS").ToString.Trim)
                    item.SubItems.Add(rdr("UsrEliminaCierre").ToString.Trim)
                    item.SubItems.Add(rdr("UsrModDiasBaston").ToString.Trim)
                    item.SubItems.Add(rdr("UsrConfirmaAjuste").ToString.Trim)
                    item.SubItems.Add(rdr("UsrAdminConcent").ToString.Trim)
                    item.SubItems.Add(rdr("EliminaParto").ToString.Trim)
                    item.SubItems.Add(rdr("PermIngPartoAtrasado").ToString.Trim)
                    item.SubItems.Add(rdr("UsrGrabaLeche").ToString.Trim)
                    lista_usuarios.Items.Add(item)
                    i = i + 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        lista_usuarios.EndUpdate()
    End Sub
End Class

