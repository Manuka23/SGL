Imports System.Data.SqlClient
Public Class frmCausas
    Private fbast As frmCausas_Agregar
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub frmCausas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 0

        CausasListado()
    End Sub
    Private Sub lista_usuarios_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lista_usuarios.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lista_usuarios, e)
    End Sub
    Private Sub CausasListado()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCausas_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        'cmd.Parameters.AddWithValue("@op", )
        lista_usuarios.BeginUpdate()
        lista_usuarios.Items.Clear()

        Dim i As Integer = 0
        Dim muerte As String = ""
        Dim venta As String = ""
        Dim catm As String = ""
        Dim catv As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Select Case rdr("CauMuerte").ToString.Trim
                        Case 1
                            muerte = "Si"
                        Case 0
                            muerte = ""
                    End Select

                    Select Case rdr("CauVenta").ToString.Trim
                        Case 1
                            venta = "Si"
                        Case 0
                            venta = ""
                    End Select

                    Select Case rdr("CategoriaMuerte").ToString.Trim
                        Case "ND"
                            catm = ""
                        Case Else
                            catm = rdr("CategoriaMuerte").ToString.Trim
                    End Select

                    Select Case rdr("CategoriaVenta").ToString.Trim
                        Case "ND"
                            catv = ""
                        Case Else
                            catv = rdr("CategoriaVenta").ToString.Trim
                    End Select


                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, codigo del mensaje
                    item.SubItems.Add(rdr("CauNombre").ToString.Trim)
                    item.SubItems.Add(muerte)
                    item.SubItems.Add(catm)
                    item.SubItems.Add(venta)
                    item.SubItems.Add(catv)
                    item.SubItems.Add(rdr("CauCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("CausaVigente"))
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

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        fbast = New frmCausas_Agregar
        fbast.ShowDialog()
        CausasListado()

    End Sub

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        Dim validalista As Integer = 0
        fbast = New frmCausas_Agregar
        For i = 0 To lista_usuarios.Items.Count - 1
            If lista_usuarios.Items(i).Selected = True Then
                validalista = 1
                fbast.modificarCausa = 1
                fbast.nombreCausa = lista_usuarios.Items(i).SubItems(1).Text
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar una Causa de la Lista")
            Exit Sub
        End If
        fbast.ShowDialog()
        CausasListado()
    End Sub
    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lista_usuarios.Items.Count - 1
            If lista_usuarios.Items(i).Selected = True Then
                If lista_usuarios.Items(i).SubItems(7).Text = "NO" Then
                    MsgBox("Causa ya se encuentra Desactivada", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe Seleccionar una Causa de la Lista")
            Exit Sub
        End If
        If MsgBox("¿ DESEA DESACTIVAR LA CAUSA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If CausaActivarDesactivar("Desactivar") = True Then
            CausasListado()
        End If
    End Sub
    Private Function CausaActivarDesactivar(ByVal operacion As String)
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        CausaActivarDesactivar = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCausas_ActivarDesactivar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        Dim CausaCod As String = ""

        CausaCod = lista_usuarios.SelectedItems.Item(0).SubItems(6).Text

        ''
        cmd.Parameters.AddWithValue("@Operacion", operacion)
        cmd.Parameters.AddWithValue("@CodCausa", CausaCod)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            CausaActivarDesactivar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim validalista As Integer = 0
        For i = 0 To lista_usuarios.Items.Count - 1
            If lista_usuarios.Items(i).Selected = True Then
                If lista_usuarios.Items(i).SubItems(7).Text = "SI" Then
                    MsgBox("Causa ya se encuentra Activada", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe Seleccionar una Causa de la Lista")
            Exit Sub
        End If
        If MsgBox("¿ DESEA ACTIVAR LA CAUSA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If CausaActivarDesactivar("Activar") = True Then
            CausasListado()
        End If
    End Sub
End Class