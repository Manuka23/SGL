Imports System.Data.SqlClient
Public Class frmMenu_perfiles
    Private Sub muestra_lista()
        'MsgBox(General.menu_perfiles.NroRegistros)
        If General.menu_perfiles.NroRegistros = 0 Then Exit Sub
        lv_lista_menu.Items.Clear()
        For i = 0 To General.menu_perfiles.NroRegistros - 1

            Dim item As New ListViewItem((i + 1).ToString.Trim)
            '  item.SubItems.Add(General.menu_principal.CodMnu(i).ToString.Trim)
            item.SubItems.Add(General.menu_perfiles.CodPerf(i).ToString.Trim)
            item.SubItems.Add(General.menu_perfiles.NomPerf(i).ToString.Trim)
            item.SubItems.Add(General.menu_perfiles.CodMnu(i).ToString.Trim)
            item.SubItems.Add(General.menu_perfiles.DesMnu(i).ToString.Trim)
            'item.SubItems.Add(General.menu_perfiles.Graba(i).ToString.Trim)
            lv_lista_menu.Items.Add(item)

            'i = i + 1
        Next

    End Sub
    Private Function eliminar()
        eliminar = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_MenuPerfiles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim opcion As String = "d"
        Dim CodPerf As Integer = lv_lista_menu.SelectedItems.Item(0).SubItems(1).Text
        Dim DesMnu As String = ""
        Dim NomPerf As String = ""
        Dim CodMnu As Integer = lv_lista_menu.SelectedItems.Item(0).SubItems(3).Text
        Dim Graba As String = "1"
        Dim Modifica As String = "1"
        Dim Elimina As String = "1"
        Dim FecCre As Date = Now()
        Dim ResCre As String = General.LoginUsuario
        Dim order As String = ""


        'codusuario = cboUsuariosIvs.SelectedItem
        'CodPerf = General.Perfiles.Codigo(cboPerfiles.SelectedIndex - 1)
        ' CodMnu = General.menu_principal.CodMnu(CboMenu.SelectedIndex)

        ''
        cmd.Parameters.AddWithValue("@op", opcion)
        cmd.Parameters.AddWithValue("@CodPerf", CodPerf)
        cmd.Parameters.AddWithValue("@NomPerf", NomPerf)
        cmd.Parameters.AddWithValue("@CodMnu", CodMnu)
        cmd.Parameters.AddWithValue("@DesMnu", DesMnu)
        cmd.Parameters.AddWithValue("@Graba", Graba)
        cmd.Parameters.AddWithValue("@Modifica", Modifica)
        cmd.Parameters.AddWithValue("@Elimina", Elimina)
        cmd.Parameters.AddWithValue("@FecCre", FecCre)
        cmd.Parameters.AddWithValue("@ResCre", ResCre)
        cmd.Parameters.AddWithValue("@order", order)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()


            eliminar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        frmMenu_perfiles_nuevo.Show()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmMenu_perfiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 0
        General.menu_perfiles.Menu_perfiles()
        General.menu_perfiles.Cargar(1)
        muestra_lista()
    End Sub

    Private Sub lv_lista_menu_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lv_lista_menu.ColumnClick
        General.menu_perfiles.Cargar(lv_lista_menu.Columns(e.Column).Index)
        muestra_lista()
    End Sub

    Private Sub lv_lista_menu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv_lista_menu.SelectedIndexChanged

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
            'End If

            General.menu_perfiles.Cargar(1)
            muestra_lista()

        End If
    End Sub
End Class