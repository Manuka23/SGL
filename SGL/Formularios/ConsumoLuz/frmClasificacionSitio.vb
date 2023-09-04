Imports System.Data.SqlClient
Public Class frmClasificacionSitio
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 15
        BuscarSitios()
    End Sub
    Private Sub BuscarSitios()
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spLuz_CasificacionSitiosListado]", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        lvSitios.BeginUpdate()
        lvSitios.Items.Clear()
        Dim i As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem(rdr("ClasificacionCod").ToString.Trim)    'primera columna, codigo del mensaje
                    item.SubItems.Add(rdr("ClasificacionNom").ToString.Trim)
                    lvSitios.Items.Add(item)
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
        lvSitios.EndUpdate()
    End Sub

    Private Function Eliminar()
        Eliminar = False
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spLuz_ClasificacionEliminar", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ClasificacionCod", lvSitios.SelectedItems.Item(0).SubItems(0).Text)
        cmd.Parameters.Add("@Text", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@Text").Direction = ParameterDirection.Output
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
            Eliminar = True
            MsgBox(cmd.Parameters("@Text").Value, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        frmClasificacionSitio_Nuevo.Show()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lvSitios.Items.Count - 1
            If lvSitios.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe Seleccionar una clasificacion de la Lista")
            Exit Sub
        End If
        If MsgBox("¿ DESEA ELIMIMAR EL REGISTRO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If Eliminar() = True Then
            BuscarSitios()
        End If
    End Sub

    Private Sub modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles modificar.Click
        Dim validalista As Integer = 0
        For i = 0 To lvSitios.Items.Count - 1
            If lvSitios.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe Seleccionar una casificacion de la Lista")
            Exit Sub
        End If
        frmClasificacionSitio_Editar.Show()
    End Sub

    Private Sub lista_usuarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSitios.SelectedIndexChanged

    End Sub
End Class