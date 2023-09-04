Imports System.Data.SqlClient
Public Class frmControlLecheroDetalle
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmControlLecheroDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
    End Sub
    Public Sub ControlLecheroDetalle(ByVal CentroCod As Integer, ByVal FechaControl As String, ByVal Lote As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spControlLechero_Detalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CentroCod", CentroCod)
        cmd.Parameters.AddWithValue("@FechaControl", FechaControl)
        cmd.Parameters.AddWithValue("@Lote", Lote)


        lvControlLecheroDetalle.BeginUpdate()
        lvControlLecheroDetalle.Items.Clear()

        Dim i As Integer = 0
        'Dim ea As Integer = 0
        'Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem(rdr("Correlativo").ToString.Trim)    'primera columna, codigo del mensajeCorrelativo
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(Format(rdr("CoLeFechaControl"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("CoLeDiio").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add(rdr("CoLeRCS").ToString.Trim)
                    item.SubItems.Add(rdr("CoLeGrasa").ToString.Trim)
                    item.SubItems.Add(rdr("CoLeProteina").ToString.Trim)
                    item.SubItems.Add(Format(rdr("GndUltFechaPP"), "dd-MM-yyyy"))
                    item.SubItems.Add(Format(rdr("GndFecNac"), "dd-MM-yyyy"))
                    lvControlLecheroDetalle.Items.Add(item)
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
End Class