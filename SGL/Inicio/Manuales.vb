Public Class Manuales

    Public PDFManual As String
    Private Sub Manuales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarArchivoMapa(True)
    End Sub

    Private Sub BuscarArchivoMapa(Optional ByVal CargarMapa As Boolean = False)
        If CargarMapa = False Then Exit Sub

        If General.Manuales(PDFManual, WebBrowser) = False Then
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class