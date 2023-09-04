
Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient

Public Class frmRazas
    Private razaingreso As New frmRazasIngreso
    Private Sub frmRazas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 0
        MuestraRazas()
    End Sub
    Private Sub MuestraRazas()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRazas_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim i As Integer = 0
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Operacion", "Mantenedor")
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        LvlRazas.BeginUpdate()
        LvlRazas.Items.Clear()

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()

                    Dim item As New ListViewItem((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("CodRaza").ToString.Trim)
                    item.SubItems.Add(rdr("NomRaza").ToString.Trim)
                    If rdr("EstRaza") = 1 Then
                        item.SubItems.Add("SI")
                    Else
                        item.SubItems.Add("NO")
                    End If
                    item.SubItems.Add(rdr("PesoCria").ToString.Trim)
                    item.SubItems.Add(rdr("AbreviaRaza").ToString.Trim)
                    LvlRazas.Items.Add(item)
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
        LvlRazas.EndUpdate()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        razaingreso = New frmRazasIngreso
        razaingreso.ShowDialog()
        MuestraRazas()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To LvlRazas.Items.Count - 1
            If LvlRazas.Items(i).Selected = True Then
                If LvlRazas.Items(i).SubItems(3).Text = "NO" Then
                    MsgBox("Raza ya se encuentra Desactivada", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar una Raza de la Lista")
            Exit Sub
        End If

        If MsgBox("¿ DESEA DESACTIVAR LA RAZA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarRaza() = True Then


            MuestraRazas()
        End If
    End Sub
    Private Function EliminarRaza() As Boolean
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        EliminarRaza = False
        Dim Operacion As String = "Desactivar"
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRazas_ActivarDesactivar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        ''
        cmd.Parameters.AddWithValue("@Operacion", Operacion)
        cmd.Parameters.AddWithValue("@CodRaza", LvlRazas.SelectedItems.Item(0).SubItems(1).Text)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            EliminarRaza = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim validalista As Integer = 0
        For i = 0 To LvlRazas.Items.Count - 1
            If LvlRazas.Items(i).Selected = True Then
                If LvlRazas.Items(i).SubItems(3).Text = "SI" Then
                    MsgBox("Raza ya se encuentra Activada", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar una Raza de la Lista", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If MsgBox("¿ DESEA ACTIVAR LA RAZA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If ActivarRaza() = True Then


            MuestraRazas()
        End If
    End Sub
    Private Function ActivarRaza() As Boolean
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        ActivarRaza = False
        Dim Operacion As String = "Activar"
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRazas_ActivarDesactivar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        ''
        cmd.Parameters.AddWithValue("@Operacion", Operacion)
        cmd.Parameters.AddWithValue("@CodRaza", LvlRazas.SelectedItems.Item(0).SubItems(1).Text)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            ActivarRaza = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        razaingreso = New frmRazasIngreso

        Dim validalista As Integer = 0
        For i = 0 To LvlRazas.Items.Count - 1
            If LvlRazas.Items(i).Selected = True Then
                validalista = 1
                razaingreso.CodRaza = LvlRazas.Items(i).SubItems(1).Text
                razaingreso.txtAbrev.Text = LvlRazas.Items(i).SubItems(5).Text
                razaingreso.txtNom.Text = LvlRazas.Items(i).SubItems(2).Text
                razaingreso.txtPeso.Text = LvlRazas.Items(i).SubItems(4).Text
                razaingreso.cboVigente.Text = LvlRazas.Items(i).SubItems(3).Text
                Exit For
            End If
            razaingreso.Text = "Modificar Raza"
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar una Raza de la Lista")
            Exit Sub
        End If


        razaingreso.ShowDialog()
        MuestraRazas()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class