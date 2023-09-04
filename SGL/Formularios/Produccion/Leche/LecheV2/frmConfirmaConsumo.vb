




Public Class frmConfirmaConsumo
    Public TipoConfirmacionConsumo As Integer       '1=consumo de productos / 2=traslado de productos
    Public CentroDestino As String



    Private Sub CboLLenaCentrosDestinos()
        If General.Centros.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Centros.NroRegistros - 1
            cboCentros.Items.Add(General.Centros.Nombre(i))
        Next
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        TipoConfirmacionConsumo = 0
        Me.Close()
    End Sub


    Private Sub frmConfirmaConsumo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CboLLenaCentrosDestinos()
        cboCentros.SelectedIndex = -1


    End Sub


    Private Sub btnConsumo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsumo.Click
        If MsgBox("¿ DESEA GRABAR EL CONSUMO DE PRODUCTOS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        TipoConfirmacionConsumo = 1
        Me.Close()

    End Sub


    Private Sub btnTraslado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraslado.Click
        If cboCentros.SelectedIndex = -1 Then Exit Sub

        If MsgBox("¿ DESEA GRABAR EL TRASLADO DE PRODUCTOS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        TipoConfirmacionConsumo = 2
        CentroDestino = General.Centros.Codigo(cboCentros.SelectedIndex)
        Me.Close()
    End Sub
End Class