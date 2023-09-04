Imports System.Data.SqlClient
Imports System.Threading
Imports Microsoft.Reporting.WinForms
Public Class frmMuestraLecheResumenDetalle

    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub frmMuestraLecheResumenDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvGanado.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvGanado, e)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub
        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}
        ExportToExcelGrilla(lvGanado, tot)
    End Sub
    Public Sub DetalleMuestra(ByVal Lote As String)
        'lista_usuarios.Clear()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_DetalleMuestra", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Lote", Lote)


        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i As Integer = 0
        Dim ea As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem(rdr("Correlativo").ToString.Trim)    'primera columna, codigo del mensajeCorrelativo
                    item.SubItems.Add(rdr("Centro").ToString.Trim)
                    item.SubItems.Add(rdr("Estanque").ToString.Trim)
                    item.SubItems.Add(rdr("ResultRCS").ToString.Trim)
                    item.SubItems.Add(rdr("ResultGrasa").ToString.Trim)
                    item.SubItems.Add(rdr("ResultProteina").ToString.Trim)
                    item.SubItems.Add(rdr("ResultSolido").ToString.Trim)
                    item.SubItems.Add(rdr("ResultUrea").ToString.Trim)
                    item.SubItems.Add(rdr("ResultDensidad").ToString.Trim)
                    item.SubItems.Add(rdr("ResultCriscopia").ToString.Trim)
                    item.SubItems.Add(rdr("ResultUFC").ToString.Trim)
                    lvGanado.Items.Add(item)
                    i = i + 1

                End While
                Label10.Text = i
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        lvGanado.EndUpdate()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lvGanado.Items.Count - 1
            If lvGanado.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Registro de la Lista")
            Exit Sub
        End If
        If MsgBox("¿ DESEA ELIMINAR EL REGISTRO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminaMuestraLeche() = True Then
            For Each it As ListViewItem In lvGanado.SelectedItems
                lvGanado.Items.Remove(it)
            Next
        End If
    End Sub
    Private Function EliminaMuestraLeche() As Boolean
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        EliminaMuestraLeche = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_EliminarDetalleMuestra", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim Corr As String = ""

        Corr = lvGanado.SelectedItems.Item(0).SubItems(0).Text

        cmd.Parameters.AddWithValue("@Lote", lblLote.Text)
        cmd.Parameters.AddWithValue("@Corr", Corr)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            EliminaMuestraLeche = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
End Class