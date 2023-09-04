Imports System.IO

'Imports PDFView


Public Class frmRptDocumentoDBNET
    'Public TipoDoc As Integer
    'Public NroGuia As Integer



    Private Function GeneraNombreArchivo(ByVal TipoDoc As Integer, ByVal NroDoc As Integer) As String
        Return "E076011573" + "T0" + TipoDoc.ToString.Trim + "F" + NroDoc.ToString.PadLeft(10, "0") + "_me.pdf"
    End Function


    Public Sub BuscarArchivoMapa(ByVal TipoDoc As Integer, ByVal NroDoc As Integer)
        'If CargarMapa = False Then
        '    If CargaMapaOK = 0 Then Exit Sub
        '    'Else
        'End If


        Cursor.Current = Cursors.WaitCursor

        Try
            Dim path_ As String = IIf(SRV_Servidor <> "SRVMNK", "\\srvmnkdev\pdf", "\\srverpsql\pdf")
            Dim files1_ As List(Of String) = IO.Directory.GetFiles(path_).ToList        'Method1
            Dim filetofind_ As String = GeneraNombreArchivo(TipoDoc, NroDoc)
            Dim file_ As String = ""

            For Each itm In files1_
                If itm.ToUpper.Contains(filetofind_.ToUpper) Then
                    file_ = itm
                    Exit For
                End If
            Next

            If IO.File.Exists(file_) Then
                'Dim ftemp As String = Directory.GetCurrentDirectory + "\" + Path.GetFileName(file_) + ".tmp"
                'Dim stream As New MemoryStream(File.ReadAllBytes(file_))
                'Dim fstream As New FileStream(ftemp, FileMode.Create)

                'stream.WriteTo(fstream)

                'fstream.Close()
                'stream.Close()


                WebBrowser.Visible = True
                'WebBrowser.DocumentStream = stream
                WebBrowser.Navigate(file_)

                'PDFView.FileName = file_
                'axPDF.Visible = True
                'axPDF.src = file_
                'axPDF.Enabled = True
                'axPDF.LoadFile(file_)
                'axPDF.Show()
            Else
                WebBrowser.Visible = False
                'axPDF.Visible = False

                lblError2.Text = "DOCUMENTO ELECTRÓNICO N° " + NroDoc.ToString.Trim + " (" + filetofind_ + ")"
                lblError1.Visible = True
                lblError2.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub


    Private Sub frmRptGuiaDespachoDBNET_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        WebBrowser.Dock = DockStyle.Fill
        'WebBrowser.Visible = False

        'axPDF.Dock = DockStyle.Fill

        'axPDF.setPageMode("none")
        'axPDF.setShowToolbar(True)
        'axPDF.setShowScrollbars(True)
        'axPDF.setZoom(100)

        'axPDF.src = "\\srverpsql\pdf\E076011573T052F0000000097_me.pdf"
    End Sub


    Private Sub frmRptDocumentoDBNET_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        'axPDF.LoadFile("")
        'axPDF.Dispose()
        'axPDF = Nothing
    End Sub

    Private Sub axPDF_OnError(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class