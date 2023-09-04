Imports System.Threading
Imports System.Data.SqlClient
Public Class frmDetalleConteo
    Private param As Integer = 0
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub frmDetalleConteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub lvDetalle_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvDetalle.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvDetalle, e)
    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvRESUMEN1.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvRESUMEN1, e)
    End Sub
    Public Sub ConsultaSesiones(ByVal fech As Date, ByVal centro As String)
        Thread.Sleep(20)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteo_Detalles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@fech", fech)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@param", param)

        If param = 0 Then
            lvRESUMEN1.BeginUpdate()
            lvRESUMEN1.Items.Clear()
        Else
            lvDetalle.BeginUpdate()
            lvDetalle.Items.Clear()
        End If


        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    If param = 0 Then
                        'Tab Faltantes
                        Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos
                        item.SubItems.Add(rdr("CentroNomCorto").ToString.Trim)
                        item.SubItems.Add(rdr("GndCod").ToString.Trim)
                        item.SubItems.Add(fech)
                        item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                        lvRESUMEN1.Items.Add(item)

                    Else

                        '        'Tab Diferencias
                        Dim item2 As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos
                        item2.SubItems.Add(rdr("ContDiiodif").ToString.Trim)
                        item2.SubItems.Add(rdr("ContObservDiio").ToString.Trim)
                        lvDetalle.Items.Add(item2)

                    End If

                End While


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:

        If param = 0 Then
            lvRESUMEN1.EndUpdate()
            param = 1
            Label10.Text = i
            ConsultaSesiones(fech, centro)
        Else
            lvDetalle.EndUpdate()
            Label1.Text = i
        End If



    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvRESUMEN1.Items.Count <= 1 Then Exit Sub

        Dim tot(1, 15) As String '= {{"", ""}, {"", ""}}
        Dim linedate As String = ""


        tot(0, 0) = "Nro. Registros" : tot(0, 1) = Label10.Text
        ExportToExcelGrillaCierre(lvRESUMEN1, tot, linedate, 1)

        'If lvDetalle.Items.Count = 0 Then Exit Sub

        tot(0, 0) = "Nro. Registros" : tot(0, 1) = Label10.Text
        ExportToExcelGrillaCierre(lvDetalle, tot, linedate, 2)
    End Sub
End Class