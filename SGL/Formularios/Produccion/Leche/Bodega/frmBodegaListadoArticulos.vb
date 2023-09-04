Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel

Public Class frmBodegaListadoArticulos
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
    Private Sub txtNom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNom.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            lvArticulos.Items.Clear()
            Operacion = "BuscarDatos"
            BuscarArticulos()
        End If
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
        cmd.Parameters.AddWithValue("@NomVacuna", txtNom.Text)
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
        If validaitem(e.Index) = True Then
        Else
            e.NewValue = CheckState.Unchecked
        End If
        Cursor.Current = Cursors.Default
    End Sub
    Public Function validaitem(ByVal i As Integer) As Boolean
        validaitem = False


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_ValidaItemCierre", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Item", lvArticulos.Items(i).SubItems(1).Text)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value


            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                validaitem = False
            Else
                validaitem = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        Cursor.Current = Cursors.Default

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If NuevoArticulo() = True Then
            MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            frmBodegaCierreItems.BuscarArticulos()
            Me.Close()
        End If

    End Sub
    Public Function NuevoArticulo() As Boolean
        NuevoArticulo = False
        Dim n As Integer = lvArticulos.Items.Count.ToString
        For i = 0 To n - 1
            If lvArticulos.Items(i).Checked = True Then
                Dim con As New SqlConnection(GetConnectionString())
                Dim cmd As New SqlCommand("spBodegas_GrabarItemsParaCierre", con)
                Dim rdr As SqlDataReader = Nothing
                Dim Existe As Boolean = False
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Item", lvArticulos.Items(i).SubItems(1).Text)
                cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
                cmd.Parameters.AddWithValue("@Equipo", NombrePC)

                cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
                cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
                Try
                    con.Open()

                    Dim Result As Integer = cmd.ExecuteNonQuery()

                    Dim vret As Integer = cmd.Parameters("@RetValor").Value
                    Dim mret As String = cmd.Parameters("@RetMensage").Value


                    ''verificamos error con un valor igual a -1
                    If vret = -1 Then
                        Cursor.Current = Cursors.Default

                        If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If

                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                Finally
                    con.Close()
                End Try

                NuevoArticulo = True
                Cursor.Current = Cursors.Default
            End If
        Next
    End Function

    Private Sub lvArticulos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvArticulos.SelectedIndexChanged

    End Sub
End Class