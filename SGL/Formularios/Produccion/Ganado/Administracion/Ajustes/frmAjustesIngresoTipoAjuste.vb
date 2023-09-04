
Public Class frmAjustesIngresoTipoAjuste

    Public TipoMov As Integer = 0
    Public Procesa As Boolean = False

    Private Sub frmAjustesIngresoTipoAjuste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If TipoMov = 1 Then
            CboLLenaTiposAjustesSalida()
        End If

        If TipoMov = 2 Then
            CboLLenaTiposAjustesEntrada()
        End If
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboTiposAjustes.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE AJUSTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTiposAjustes.Focus()
            Exit Sub
        End If


        Procesa = True
        Me.Close()
    End Sub

    Private Sub CboLLenaTiposAjustesEntrada()
        If General.TiposAjusteEntrada.NroRegistros = 0 Then Exit Sub

        cboTiposAjustes.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TiposAjusteEntrada.NroRegistros - 1
            cboTiposAjustes.Items.Add(General.TiposAjusteEntrada.Nombre(i))
        Next
    End Sub

    Private Sub CboLLenaTiposAjustesSalida()
        If General.TiposAjusteSalida.NroRegistros = 0 Then Exit Sub

        cboTiposAjustes.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TiposAjusteSalida.NroRegistros - 1
            cboTiposAjustes.Items.Add(General.TiposAjusteSalida.Nombre(i))
        Next
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class