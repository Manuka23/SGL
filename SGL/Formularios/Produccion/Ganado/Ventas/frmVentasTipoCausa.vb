Imports System.Data.SqlClient
Public Class frmVentasTipoCausa
    Private fdats As frmVentasRequerimientoIngreso
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmVentasTipoCausa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height + 50) / 2)
        Me.Left = Me.Left + (frmMAIN.pnlMenu.Width / 2)
        Me.MdiParent = frmMAIN
        TipoSalida()
        TipoCausa()
    End Sub
    Private Sub TipoSalida()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spReqVta_ListadoTipoSalida", con)
        Dim rdr As SqlDataReader = Nothing

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        da.SelectCommand = cmd
        da.Fill(dt)

        cboSalida.ValueMember = "TipSalVtaCod"
        cboSalida.DisplayMember = "TipSalVtaNom"
        cboSalida.DataSource = dt

    End Sub
    Private Sub TipoCausa()
        Dim TSalida As Integer
        TSalida = cboSalida.SelectedValue

        cboCausa.Enabled = True
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spReqVta_ListadoTipoCausa", con)

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        cmd.Parameters.AddWithValue("@TipoSalida", TSalida)

        da.SelectCommand = cmd
        da.Fill(dt)

        cboCausa.ValueMember = "TipCauVtaCod"
        cboCausa.DisplayMember = "TipCauVtaNom"
        cboCausa.DataSource = dt
    End Sub
    Private Sub cboSalida_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSalida.SelectedValueChanged
        TipoCausa()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        TipoCausaAplicar()
    End Sub
    Private Sub TipoCausaAplicar()

        Dim Salida As String = cboSalida.Text
        Dim Causa As String = cboCausa.Text
        Dim SalidaCod As String = cboSalida.SelectedValue
        Dim CausaCod As String = cboCausa.SelectedValue

        ProcesaCambiosTipoCausa(Salida, Causa, SalidaCod, CausaCod)

    End Sub
    Private Sub ProcesaCambiosTipoCausa(ByVal Sal As String, ByVal Cau As String, ByVal SalCod As String, ByVal CauCod As String)
        For Each it As ListViewItem In frmVentasRequerimientoIngreso.lvVentaDiio.SelectedItems
            it.SubItems(12).Text = Sal
            it.SubItems(13).Text = Cau
            it.SubItems(14).Text = CauCod
            it.SubItems(15).Text = SalCod
        Next
        Me.Close()
    End Sub
End Class