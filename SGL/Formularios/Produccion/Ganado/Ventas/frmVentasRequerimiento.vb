Imports System.Data.SqlClient
Public Class frmVentasRequerimiento
    Private Sub btnVenta_Click(sender As Object, e As EventArgs) Handles btnVenta.Click
        frmVentasRequerimientoIngreso.Show()
    End Sub
    Private Sub CboLLenaCentros()

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub
    Private Sub frmVentasRealizadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultaReqVentaGanado()
    End Sub
    Public Sub ConsultaReqVentaGanado()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ReqVentaDetalle", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Centro As String

        cmd.CommandType = Data.CommandType.StoredProcedure

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            Centro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            Centro = 0
        End If

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)

        lvReqVentaGanado.BeginUpdate()
        lvReqVentaGanado.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1
                    Dim item As New ListViewItem((i).ToString.Trim)

                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(rdr("ReqVDiio").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(Format(rdr("ReqVFechaVenta"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("TipSalVtaNom").ToString.Trim)
                    item.SubItems.Add(rdr("TipCauVtaNom").ToString.Trim)
                    item.SubItems.Add(rdr("ReqVPrecioUni").ToString.Trim)
                    item.SubItems.Add(rdr("ReqVObs").ToString.Trim)
                    item.SubItems.Add(rdr("ReqVUsuario").ToString.Trim)
                    lvReqVentaGanado.Items.Add(item)

                End While


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        lvReqVentaGanado.EndUpdate()

    End Sub
End Class