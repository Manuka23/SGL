Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmTipoDesechos
    Private fbast As frmTipoDesechosNuevo
    Private Sub frmTipoDesechos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.TipoDesechos.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        BuscaDesecho()

    End Sub
    Public Sub BuscaDesecho()
        Dim i As Integer = 1
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTipoDesechos_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure
        lista_Desechos.Items.Clear()
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()

                    Dim itm As New ListViewItem(i)
                    itm.SubItems.Add(rdr("Nomdesch").ToString.Trim)
                    itm.SubItems.Add(rdr("coddesch").ToString.Trim)
                    lista_Desechos.Items.Add(itm)
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

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        fbast = New frmTipoDesechosNuevo
        fbast.ShowDialog()
        BuscaDesecho()
    End Sub

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        Dim validalista As Integer = 0
        fbast = New frmTipoDesechosNuevo
        For i = 0 To lista_Desechos.Items.Count - 1
            If lista_Desechos.Items(i).Selected = True Then
                validalista = 1
                fbast.Desecho.Text = lista_Desechos.Items(i).SubItems(1).Text
                fbast.CodDesecho.Text = lista_Desechos.Items(i).SubItems(2).Text
                fbast.modif = 1
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un tipo de desecho de la Lista")
            Exit Sub
        End If
        fbast.ShowDialog()
        BuscaDesecho()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class