Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmVacunasListado
    Dim Operacion As String = "Listar"
    Private indx As Integer
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub Consultar_Click(sender As Object, e As EventArgs) Handles Buscar.Click
        lvArticulos.Items.Clear()
        Operacion = "BuscarDatos"
        BuscarArticulos()
    End Sub

    Private Sub lista_usuarios_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvArticulos.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvArticulos, e)
    End Sub

    Private Sub frmVacunasListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Dim Operacion As String = "Listar"
        BuscarArticulos()
    End Sub
    Public Sub BuscarArticulos()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spArticulos_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Operacion", Operacion)
        cmd.Parameters.AddWithValue("@NomVacuna", txtNomVacuna.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            Try
                While rdr.Read()
                    i = i + 1

                    Dim lvitem As New ListViewItem("")    'primera columna, para ordenar los datos
                    lvitem.Checked = False
                    lvitem.SubItems.Add(rdr("Codigo").trim.ToString)
                    lvitem.SubItems.Add(rdr("descripcion").trim.ToString)
                    lvitem.SubItems.Add(rdr("medida").trim.ToString)
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub lvArticulos_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lvArticulos.ItemCheck
        frmVacunasNuevaVacuna.codigo = lvArticulos.Items(e.Index).SubItems(1).Text
        frmVacunasNuevaVacuna.nombre = lvArticulos.Items(e.Index).SubItems(2).Text
        frmVacunasNuevaVacuna.UnidadMedida = lvArticulos.Items(e.Index).SubItems(3).Text
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub txtNomVacuna_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNomVacuna.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            lvArticulos.Items.Clear()
            Operacion = "BuscarDatos"
            BuscarArticulos()
            e.Handled = True
        End If
    End Sub
End Class