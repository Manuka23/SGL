Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmBodegaCierreItems
    Private BodegaArticulos As frmBodegaListadoArticulos

    Private Sub frmBodegaCierreItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        BuscarArticulos()
    End Sub
    Public Sub BuscarArticulos()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_ListadoItemsCierre", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        lvArticulos.Items.Clear()
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            Try
                While rdr.Read()
                    i = i + 1

                    Dim lvitem As New ListViewItem(i)    'primera columna, para ordenar los datos
                    lvitem.SubItems.Add(rdr("ItemBodegaCod"))
                    lvitem.SubItems.Add(rdr("ItemBodegaNombre"))
                    lvitem.SubItems.Add(rdr("ItemBodegaDescripcion"))
                    lvitem.SubItems.Add(rdr("ItemBodegaMedida"))
                    lvArticulos.Items.Add(lvitem)
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
    Private Function EliminaArticulo() As Boolean
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        EliminaArticulo = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_EliminarItemCierre", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        Dim articulo As String = ""

        articulo = lvArticulos.SelectedItems.Item(0).SubItems(1).Text

        cmd.Parameters.AddWithValue("@Articulo", articulo)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            EliminaArticulo = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿ DESEA ELIMINAR El SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If EliminaArticulo() = True Then

            BuscarArticulos()
        End If
    End Sub

    Private Sub Consultar_Click(sender As Object, e As EventArgs) Handles Consultar.Click
        Cursor.Current = Cursors.WaitCursor
        BodegaArticulos = New frmBodegaListadoArticulos
        BodegaArticulos.ShowDialog()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvArticulos.Items.Count = 0 Then Exit Sub
        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}
        ExportToExcelGrilla(lvArticulos, tot)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class