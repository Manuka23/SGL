Imports System.Data.SqlClient

Public Class frmParametros

    Private Sub frmParametros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 15
        Buscar()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        Dim validalista As Integer = 0
        For i = 0 To lvParametros.Items.Count - 1
            If lvParametros.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe seleccionar un parametro de la Lista")
            Exit Sub
        End If
        frmParametros_Editar.Show()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub Buscar()
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spLuz_ParametrosListado]", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        lvParametros.BeginUpdate()
        lvParametros.Items.Clear()
        Dim i As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem(rdr("ParCod").ToString.Trim)    'primera columna, codigo del mensaje
                    item.SubItems.Add(rdr("ParItem").ToString.Trim)
                    item.SubItems.Add(rdr("ParValor").ToString.Trim)
                    lvParametros.Items.Add(item)
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
        lvParametros.EndUpdate()
    End Sub

    Private Function Eliminar()
        Eliminar = False
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spLuz_ClasificacionEliminar", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ClasificacionCod", lvParametros.SelectedItems.Item(0).SubItems(0).Text)
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


End Class