


Public Class FrmCubiertasToros
    Public Param1_Centro As String
    Public Procesa As Boolean = False

    Private Sub CboLLenaInseminadores()
        General.Inseminadores.Cargar()
        If General.Inseminadores.NroRegistros = 0 Then Exit Sub

        cboInseminadores.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Inseminadores.NroRegistros - 1
            cboInseminadores.Items.Add(General.Inseminadores.Nombre(i))
        Next
    End Sub


    Private Sub CboLLenaToros(ByVal CodigoCentro As String)
        General.TorosInseminaciones.Cargar(CodigoCentro)
        cboToros.Items.Clear()

        If General.TorosInseminaciones.NroRegistros = 0 Then Exit Sub

        Dim i As Integer

        For i = 0 To General.TorosInseminaciones.NroRegistros - 1
            cboToros.Items.Add(General.TorosInseminaciones.Nombre(i))
        Next

        cboToros.SelectedIndex = -1
    End Sub


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If cboInseminadores.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN INSEMINADOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboInseminadores.Focus()
            Exit Sub
        End If

        If cboToros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TORO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboToros.Focus()
            Exit Sub
        End If

        If Not IsNumeric(txtNroDosis.Text) Then
            If MsgBox("DEBE INGRESAR UN NUMERO CORRECTO PARA LAS DOSIS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNroDosis.Focus()
            Exit Sub
        End If

        Procesa = True
        Me.Close()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub FrmCubiertasToros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height + 50) / 2)
        Me.Left = Me.Left + (frmMAIN.pnlMenu.Width / 2)

        CboLLenaInseminadores()
        CboLLenaToros(Param1_Centro)
    End Sub



    Private Sub cboToros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboToros.SelectedIndexChanged
        'MsgBox(General.TorosInseminaciones.Nombre(cboToros.SelectedIndex))
    End Sub



End Class