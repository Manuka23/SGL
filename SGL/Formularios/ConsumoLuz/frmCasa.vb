Imports System.Data.SqlClient

Public Class frmCasa
    Private Sub frmCasa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 15
        Buscar()
    End Sub
    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        frmCasa_Editar.Show()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Buscar()
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spLuz_CasaListado", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        lvCasas.BeginUpdate()
        lvCasas.Items.Clear()
        Dim i As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem(rdr("CasCod").ToString.Trim)
                    item.SubItems.Add(rdr("CasSitio").ToString.Trim)
                    item.SubItems.Add(rdr("CasCodMedidor").ToString.Trim)
                    item.SubItems.Add(rdr("CasCodCentro").ToString.Trim)
                    item.SubItems.Add(rdr("Centro").ToString.Trim)
                    item.SubItems.Add(rdr("CasCodResponsable").ToString.Trim)
                    item.SubItems.Add(rdr("Responsable").ToString.Trim)
                    item.SubItems.Add(rdr("ClasificacionNom").ToString.Trim)
                    item.SubItems.Add(rdr("PoblacionNom").ToString.Trim)
                    item.SubItems.Add(rdr("RelacionNom").ToString.Trim)

                    item.SubItems.Add(rdr("ClasificacionCod").ToString.Trim)
                    item.SubItems.Add(rdr("PoblacionCod").ToString.Trim)
                    item.SubItems.Add(rdr("RelacionCod").ToString.Trim)

                    lvCasas.Items.Add(item)
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
        lvCasas.EndUpdate()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmCasa_Nuevo.Show()
    End Sub

    Private Function Eliminar()
        Eliminar = False
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spLuz_CasaEliminar]", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@CasaCod", lvCasas.SelectedItems.Item(0).SubItems(0).Text)
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

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lvCasas.Items.Count - 1
            If lvCasas.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe Seleccionar una casa de la Lista")
            Exit Sub
        End If
        If MsgBox("¿ DESEA ELIMIMAR EL REGISTRO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If Eliminar() = True Then
            Buscar()
        End If
    End Sub
End Class