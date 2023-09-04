
Public Class frmIngresoObservacion
    Public Cancelar As Boolean = False
    Public ObservGuia As String

    Private Sub frmIngresoObservacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ObservGuia = ""
        txtObservsGuia.Text = ""
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If txtObservsGuia.Text.Trim = "" Then
            If MsgBox("¿ DESEA GRABAR EL TRASLADO SIN OBSERVACIÓN ?" + vbCrLf + vbCrLf + "RECUERDE QUE SE GENERARA UNA GUIA DE DESPACHO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        Cancelar = False
        ObservGuia = txtObservsGuia.Text.Trim

        Me.Dispose()
        Me.Close()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cancelar = True

        Me.Dispose()
        Me.Close()
    End Sub


End Class