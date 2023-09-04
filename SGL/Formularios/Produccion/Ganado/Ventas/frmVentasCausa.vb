


Imports System.Data.SqlClient

Public Class frmVentasCausa

    Public Procesa As Boolean = False



    Private Sub CboLLenaCausas()
        If General.CausasVentas.NroRegistros = 0 Then Exit Sub

        Dim TSalida As Integer
        TSalida = cboTiposVentas.SelectedValue

        cboCausas.Enabled = True
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spReqVta_ListadoTipoCausa", con)

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        cmd.Parameters.AddWithValue("@TipoSalida", TSalida)

        da.SelectCommand = cmd
        da.Fill(dt)

        cboCausas.ValueMember = "TipCauVtaCod"
        cboCausas.DisplayMember = "TipCauVtaNom"
        cboCausas.DataSource = dt
    End Sub


    Private Sub CboLLenaVeterinarios()
        If General.Veterinarios.NroRegistros = 0 Then Exit Sub

        cboVeterinarios.Items.Clear()
        cboVeterinarios.Items.Add("")

        Dim i As Integer

        For i = 0 To General.Veterinarios.NroRegistros - 1
            cboVeterinarios.Items.Add(General.Veterinarios.Nombre(i))
        Next

        cboVeterinarios.SelectedIndex = 0
    End Sub



    Private Sub CboLLenaTiposVentas()
        If General.TiposVentas.NroRegistros = 0 Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spReqVta_ListadoTipoSalida", con)
        Dim rdr As SqlDataReader = Nothing

        Dim dt As New DataTable
        cmd.CommandType = CommandType.StoredProcedure
        Dim da As New SqlDataAdapter

        da.SelectCommand = cmd
        da.Fill(dt)

        cboTiposVentas.ValueMember = "TipSalVtaCod"
        cboTiposVentas.DisplayMember = "TipSalVtaNom"
        cboTiposVentas.DataSource = dt
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboTiposVentas.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE VENTA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTiposVentas.Focus()
            Exit Sub
        End If

        If (Not cboTiposVentas.Text.Contains("DONACI")) And (Not cboTiposVentas.Text.Contains("DIRECTA")) And (Not cboTiposVentas.Text.Contains("FAENA MAC")) Then
            If cboCausas.SelectedIndex = -1 Then
                If MsgBox("DEBE SELECCIONAR UNA CAUSA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                cboCausas.Focus()
                Exit Sub
            End If

            If cboVeterinarios.SelectedIndex = -1 Then
                If MsgBox("DEBE SELECCIONAR UN VETERINARIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                cboCausas.Focus()
                Exit Sub
            End If
        End If

        If cboTiposVentas.Text.ToUpper.Contains("EMERGENCIA") And (txtNroCert.Text = "" Or txtNroCert.Text = "0") Then
            If MsgBox("PARA VENTA DE EMERGENCIA DEBE INGRESAR UN NRO. DE CERTIFICADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCausas.Focus()
            Exit Sub
        End If

        Procesa = True
        Me.Close()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub frmVentasCausa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height + 50) / 2)
        Me.Left = Me.Left + (frmMAIN.pnlMenu.Width / 2)

        CboLLenaVeterinarios()
        CboLLenaTiposVentas()
        CboLLenaCausas()
    End Sub

    Private Sub cboTiposVentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTiposVentas.SelectedIndexChanged
        CboLLenaCausas()
    End Sub
End Class