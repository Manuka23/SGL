Imports System.Data.SqlClient
Public Class FrmPerfiles

    Private Sub modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles modificar.Click
        Dim validalista As Integer = 0
        For i = 0 To lv_lista_perfiles.Items.Count - 1
            If lv_lista_perfiles.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Usuario de la Lista")
            Exit Sub
        End If
        frmPerfiles_modificar.Show()
    End Sub

    Private Sub muestra_perfiles()
        General.Perfiles.Cargar()
        'lista_usuarios.Clear()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_Perfiles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@op", "se")
        cmd.Parameters.AddWithValue("@CodPerf", "")
        cmd.Parameters.AddWithValue("@NomPerf", "")
        cmd.Parameters.AddWithValue("@FiltraCentros", "")
        cmd.Parameters.AddWithValue("@order", "")

        lv_lista_perfiles.BeginUpdate()
        lv_lista_perfiles.Items.Clear()

        Dim i As Integer = 0
        Dim ea As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem(rdr("NomPerf").ToString.Trim)    'primera columna, codigo del mensaje

                    '  item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("CodPerf").ToString.Trim)
                    item.SubItems.Add(rdr("NomPerf").ToString.Trim)
                    'item.SubItems.Add(rdr("NomPerf").ToString.Trim)
                    ' item.SubItems.Add(rdr("Estado").ToString.Trim)


                    lv_lista_perfiles.Items.Add(item)

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

        lv_lista_perfiles.EndUpdate()
    End Sub

    Private Function eliminaperfil()
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        eliminaperfil = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_Perfiles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim opcion As String = "d"
        Dim codperfil As Integer
        Dim nomperfil As String = ""
        Dim FiltraCentros As Integer = 0
        Dim order As String = ""

        codperfil = lv_lista_perfiles.SelectedItems.Item(0).SubItems(1).Text
       
        cmd.Parameters.AddWithValue("@op", opcion)
        cmd.Parameters.AddWithValue("@CodPerf", codperfil)
        cmd.Parameters.AddWithValue("@NomPerf", nomperfil)
        cmd.Parameters.AddWithValue("@FiltraCentros", FiltraCentros)
        cmd.Parameters.AddWithValue("order", order)
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()





            eliminaperfil = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 0

        muestra_perfiles()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        frmPerfiles_Nuevo.Show()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lv_lista_perfiles.Items.Count - 1
            If lv_lista_perfiles.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Perfil de la Lista")
            Exit Sub
        End If

        If MsgBox("¿ DESEA ELIMIMAR EL REGISTRO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If eliminaperfil() = True Then
            'If MsgBox("Registro Eliminado --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            ' End If

            muestra_perfiles()
        End If
    End Sub
End Class