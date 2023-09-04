Imports System.Data.SqlClient
Public Class frmVeterinarios
    Private fbast As frmVeterinariosCreacion
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub frmVeterinarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 0

        muestraVeterinarios()
    End Sub
    Private Sub lista_usuarios_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lista_usuarios.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lista_usuarios, e)
    End Sub
    Private Sub muestraVeterinarios()
        'lista_usuarios.Clear()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVeterinarios_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
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
                    item.SubItems.Add(rdr("VetCod").ToString.Trim)
                    item.SubItems.Add(rdr("VetNom").ToString.Trim)
                    item.SubItems.Add(rdr("VetVigente").ToString.Trim)
                    item.SubItems.Add(rdr("VetAcreditado").ToString.Trim)
                    item.SubItems.Add(rdr("VetRutSD").ToString.Trim)
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lista_usuarios.Items.Count - 1
            If lista_usuarios.Items(i).Selected = True Then
                If lista_usuarios.Items(i).SubItems(3).Text = "NO" Then
                    MsgBox("Veterinario ya se encuentra Desactivado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Veterinario de la Lista")
            Exit Sub
        End If

        If MsgBox("¿ DESEA DESACTIVAR Al VETERINARIO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If eliminausuario() = True Then


            muestraVeterinarios()
        End If
    End Sub
    Private Function eliminausuario()
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        eliminausuario = False
        Dim codusuario As String = ""
        Dim Operacion As String = "Desactivar"
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVeterinarios_CambiaEstado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        codusuario = lista_usuarios.SelectedItems.Item(0).SubItems(1).Text

        ''
        cmd.Parameters.AddWithValue("@Operacion", Operacion)
        cmd.Parameters.AddWithValue("@codusuario", codusuario)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            eliminausuario = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim validalista As Integer = 0
        For i = 0 To lista_usuarios.Items.Count - 1
            If lista_usuarios.Items(i).Selected = True Then
                If lista_usuarios.Items(i).SubItems(3).Text = "SI" Then
                    MsgBox("Veterinario ya se encuentra Activado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Veterinario de la Lista", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If MsgBox("¿ DESEA ACTIVAR EL VETERINARIO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If ActivarUsuario() = True Then


            muestraVeterinarios()
        End If
    End Sub
    Private Function ActivarUsuario()
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        ActivarUsuario = False
        Dim codusuario As String = ""
        Dim Operacion As String = "Activar"
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVeterinarios_CambiaEstado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        codusuario = lista_usuarios.SelectedItems.Item(0).SubItems(1).Text

        ''
        cmd.Parameters.AddWithValue("@Operacion", Operacion)
        cmd.Parameters.AddWithValue("@codusuario", codusuario)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            ActivarUsuario = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        fbast = New frmVeterinariosCreacion
        fbast.ShowDialog()
        muestraVeterinarios()

    End Sub

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        fbast = New frmVeterinariosCreacion
        Dim validalista As Integer = 0
        For i = 0 To lista_usuarios.Items.Count - 1
            If lista_usuarios.Items(i).Selected = True Then
                validalista = 1
                fbast.User = lista_usuarios.Items(i).SubItems(1).Text
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Usuario de la Lista")
            Exit Sub
        End If


        fbast.ShowDialog()
        muestraVeterinarios()
    End Sub

    Private Sub lista_usuarios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lista_usuarios.SelectedIndexChanged

    End Sub
End Class