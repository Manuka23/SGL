Imports System.Data.SqlClient
Public Class FrmMenu_principal
    Private Sub muestra_lista()
        If General.menu_principal.NroRegistros = 0 Then Exit Sub
        lv_lista_menu.Items.Clear()
        For i = 0 To General.menu_principal.NroRegistros - 1

            Dim item As New ListViewItem((i + 1).ToString.Trim)
            '  item.SubItems.Add(General.menu_principal.CodMnu(i).ToString.Trim)
            item.SubItems.Add(General.menu_principal.CodMnu(i).ToString.Trim)
            If General.menu_principal.NodoSecundario(i) <> "0" Then
                item.SubItems.Add(".       " + General.menu_principal.DesMnu(i).ToString.Trim)
                item.SubItems.Add(".       " + General.menu_principal.DesMnuIngles(i).ToString.Trim)
            Else
                item.SubItems.Add(General.menu_principal.DesMnu(i).ToString.Trim)
                item.SubItems.Add(General.menu_principal.DesMnuIngles(i).ToString.Trim)
            End If
            ' item.SubItems.Add(General.menu_principal.DesMnu(i))
            item.SubItems.Add(General.menu_principal.NodoPrimario(i).ToString.Trim)
            item.SubItems.Add(General.menu_principal.NodoSecundario(i).ToString.Trim)
            item.SubItems.Add(General.menu_principal.NodoTercero(i).ToString.Trim)
            lv_lista_menu.Items.Add(item)

            ' i = i + 1
        Next
    End Sub
    Private Function eliminar()
        eliminar = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_Menu", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim opcion As String = "d"
        Dim CodMnu As String = lv_lista_menu.SelectedItems.Item(0).SubItems(1).Text
        Dim DesMnu As String = ""
        Dim DesMnuIngles As String = ""
        Dim NodoPrimario As String = ""
        Dim NodoSecundario As String = ""
        Dim NodoTercero As String = ""
        Dim FecCre As Date = Now()

        Dim rescre As String = General.LoginUsuario
        Dim order As String = ""

        'cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@op", opcion)
        cmd.Parameters.AddWithValue("@CodMnu", CodMnu)
        cmd.Parameters.AddWithValue("@DesMnu", DesMnuIngles)
        cmd.Parameters.AddWithValue("@DesMnuIngles", DesMnu)
        cmd.Parameters.AddWithValue("@NodoPrimario", NodoPrimario)
        cmd.Parameters.AddWithValue("@NodoSecundario", NodoSecundario)
        cmd.Parameters.AddWithValue("@NodoTercero", NodoTercero)
        cmd.Parameters.AddWithValue("@FecCre", FecCre)
        cmd.Parameters.AddWithValue("@ResCre", rescre)
        cmd.Parameters.AddWithValue("@order", order)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()


            eliminar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 0
        General.menu_principal.menu_principal()
        General.menu_principal.Cargar(1)
        muestra_lista()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        frmMenu_pricipal_nuevo.Show()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lv_lista_menu.Items.Count - 1
            If lv_lista_menu.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Menu de la Lista")
            Exit Sub
        End If

        If MsgBox("¿ DESEA ELIMIMAR EL REGISTRO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If eliminar() = True Then
            'If MsgBox("Registro Eliminado --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            ' End If

            General.menu_principal.Cargar(1)
            muestra_lista()

        End If

    End Sub

    Private Sub modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles modificar.Click
        Dim validalista As Integer = 0
        For i = 0 To lv_lista_menu.Items.Count - 1
            If lv_lista_menu.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Menu de la Lista")
            Exit Sub
        End If
        frmMenu_principal_modifica.Show()
    End Sub

    Private Sub lv_lista_menu_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lv_lista_menu.ColumnClick
        ' MsgBox(lv_lista_menu.Columns.Item)
        'MsgBox(lv_lista_menu.Columns(e.Column).Index)

        'General.menu_principal.Cargar(lv_lista_menu.Columns(e.Column).Index)
        'muestra_lista()


    End Sub

    Private Sub lv_lista_menu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv_lista_menu.SelectedIndexChanged

    End Sub
End Class