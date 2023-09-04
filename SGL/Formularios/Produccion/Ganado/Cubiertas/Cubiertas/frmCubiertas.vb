


Imports Microsoft.Office.Interop.Excel
'Imports Microsoft.Reporting.WinForms
'Imports Micr .Office.Interop
Imports System.Data.SqlClient


Public Class frmCubiertas


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub




    Private Sub frmCubiertas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        General.Toros.Cargar()
        General.Inseminadores.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        frmCubiertasIngreso.MdiParent = frmMAIN
        frmCubiertasIngreso.Show()
        frmCubiertasIngreso.BringToFront()
    End Sub
End Class