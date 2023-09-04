
Imports Microsoft.Office.Interop.Excel

Imports System.Data.SqlClient
Public Class frmEstanques
    Private Estanque As New frmEstanquesIngreso

    Private Sub frmEstanques_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 0
        Estanques()
    End Sub
    Private Sub Estanques()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spEstanques_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim i As Integer = 0
        cmd.CommandType = Data.CommandType.StoredProcedure

        LvlEstanque.BeginUpdate()
        LvlEstanque.Items.Clear()

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()

                    Dim item As New ListViewItem((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("Centro").ToString.Trim)
                    item.SubItems.Add(rdr("EstanqueCod").ToString.Trim)
                    item.SubItems.Add(rdr("EstanqueCodVerificador").ToString.Trim)
                    item.SubItems.Add(rdr("EstanqueNom").ToString.Trim)
                    item.SubItems.Add(rdr("EstanqueVig").ToString.Trim)
                    item.SubItems.Add(rdr("EstanqueCapacidad").ToString.Trim)
                    item.SubItems.Add(rdr("EstanqueMarca").ToString.Trim)
                    LvlEstanque.Items.Add(item)
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
        LvlEstanque.EndUpdate()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim validalista As Integer = 0
        For i = 0 To LvlEstanque.Items.Count - 1
            If LvlEstanque.Items(i).Selected = True Then
                If LvlEstanque.Items(i).SubItems(5).Text = "SI" Then
                    MsgBox("Estanque ya se encuentra Activado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Estanque de la Lista", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If MsgBox("¿ Cambiar el estado a Vigente del estanque ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If ActivarEstanque() = True Then
            Estanques()
        End If
    End Sub
    Private Function ActivarEstanque() As Boolean
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        ActivarEstanque = False
        Dim Operacion As String = "Activar"
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spEstanques_ActivarDesactivar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Operacion", Operacion)
        cmd.Parameters.AddWithValue("@CodEstanque", LvlEstanque.SelectedItems.Item(0).SubItems(2).Text)
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            ActivarEstanque = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To LvlEstanque.Items.Count - 1
            If LvlEstanque.Items(i).Selected = True Then
                If LvlEstanque.Items(i).SubItems(5).Text = "NO" Then
                    MsgBox("Estanque ya se encuentra Desactivado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Estanque de la Lista")
            Exit Sub
        End If
        If MsgBox("¿ Cambiar el estado a NO Vigente del estanque?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If DesactivarEstanque() = True Then
            Estanques()
        End If
    End Sub
    Private Function DesactivarEstanque() As Boolean
        DesactivarEstanque = False
        Dim Operacion As String = "Desactivar"
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spEstanques_ActivarDesactivar", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Operacion", Operacion)
        cmd.Parameters.AddWithValue("@CodEstanque", LvlEstanque.SelectedItems.Item(0).SubItems(2).Text)
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
            DesactivarEstanque = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Estanque = New frmEstanquesIngreso
        Estanque.modificador = 0
        Estanque.ShowDialog()
        Estanques()
    End Sub

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        Estanque = New frmEstanquesIngreso

        Dim validalista As Integer = 0
        For i = 0 To LvlEstanque.Items.Count - 1
            If LvlEstanque.Items(i).Selected = True Then
                validalista = 1
                Estanque.modificador = 1
                Estanque.CodigoEstanque = LvlEstanque.Items(i).SubItems(2).Text
                Estanque.txtNum.Text = LvlEstanque.Items(i).SubItems(3).Text
                Estanque.txtNom.Text = LvlEstanque.Items(i).SubItems(4).Text
                Estanque.txtCapacidad.Text = LvlEstanque.Items(i).SubItems(6).Text
                Estanque.txtMarca.Text = LvlEstanque.Items(i).SubItems(7).Text
                Estanque.cboVigente.Text = LvlEstanque.Items(i).SubItems(5).Text
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Estanque de la Lista", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR")
            Exit Sub
        End If


        Estanque.ShowDialog()
        Estanques()
    End Sub
End Class