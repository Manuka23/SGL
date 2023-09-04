Imports System.IO

Public Class eSuite

    Public Sub MostrarPDFeSuite2(ByVal NomFile As String)
        Dim AcrobateInstance() As Process = Process.GetProcessesByName("Acrobat")
        Dim Base64Str As String = "", byteData() As Byte
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Se obtienen datos desde el parametro de entrada "NomFile"
        Dim RutEmis As String, NumDoc As String, TipDoc As String, pos As Integer = 0
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        pos = InStr(1, NomFile, "E")
        RutEmis = Convert.ToString(Convert.ToDecimal(NomFile.Substring(pos, 9)))

        pos = InStr(1, NomFile, "T")
        TipDoc = Convert.ToString(Convert.ToDecimal(NomFile.Substring(pos, 3)))

        pos = InStr(1, NomFile, "F")
        NumDoc = Convert.ToString(Convert.ToDecimal(NomFile.Substring(pos, 10)))
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Se obtiene y se guarda cadena de caracteres en formato BASE64 (Tipo compresion en que esta el archivo PDF)
        If LOGIN_CONEXION = "TEST" Then
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim getBase64TEST As New wsTESTgetPDF64.getPDF64SoapClient() 'TEST
            Dim arrayOfStringTEST As New wsTESTgetPDF64.ArrayOfString 'TEST
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            arrayOfStringTEST = getBase64TEST.get_pdf(RutEmis, NumDoc, TipDoc, "", "", "", True)
            Base64Str = arrayOfStringTEST(1).Trim() 'Se almacena areglo en una variable String, segun la conexion que selecciono en el LOGIN
        End If
        If LOGIN_CONEXION = "MANUKA" Then
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim getBase64PROD As New wsPRODgetPDF64.getPDF64SoapClient() 'PROD
            Dim arrayOfStrigPROD As New wsPRODgetPDF64.ArrayOfString 'PROD
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            arrayOfStrigPROD = getBase64PROD.get_pdf(RutEmis, NumDoc, TipDoc, "", "", "", True)
            Base64Str = arrayOfStrigPROD(1).Trim() 'Se almacena areglo en una variable String, segun la conexion que selecciono en el LOGIN
        End If
        'Se convierte cadena (Arreglo) en Bytes
        byteData = Convert.FromBase64String(Base64Str)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim strStreamW As FileStream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim PathArchivo As String = "C:\APPS\PDFsuite\" & NomFile.Trim & ".txt"

        Try
            If File.Exists(PathArchivo) = True Then
                If AcrobateInstance.Length > 0 Then
                    AcrobateInstance(1).Kill()
                End If
                File.Delete(PathArchivo)
            End If
            If Directory.Exists("C:\APPS\PDFsuite") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory("C:\APPS\PDFsuite")
            End If

            strStreamW = New FileStream(PathArchivo, FileMode.Append)
            strStreamW.Write(byteData, 0, byteData.Length)
            strStreamW.Close()
        Catch ex As Exception
            MsgBox("Error al Guardar la informacion en el archivo (" & NomFile & ".txt). " & ex.ToString, MsgBoxStyle.Critical, System.Windows.Forms.Application.ProductName)
            strStreamW.Close()
        End Try

        Try
            'Process.Start("AcroRD32.exe", PathArchivo)
            Dim Proceso As New Process
            Proceso.StartInfo.FileName = PathArchivo
            Proceso.Start()
        Catch exAcroRD As Exception
            MsgBox("Error al abrir el archivo PDF (" & NomFile & "). Verifique que tiene instalado 'Adobe Reader' en su PC. " & exAcroRD.ToString, MsgBoxStyle.Critical, System.Windows.Forms.Application.ProductName)
        End Try
    End Sub
    Public Sub MostrarPDFeSuite(ByVal NomFile As String)
        Dim Base64Str As String = "", byteData() As Byte
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Se obtienen datos desde el parametro de entrada "NomFile"
        Dim RutEmis As String, NumDoc As String, TipDoc As String, pos As Integer = 0
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        pos = InStr(1, NomFile, "E")
        RutEmis = Convert.ToString(Convert.ToDecimal(NomFile.Substring(pos, 9)))

        pos = InStr(1, NomFile, "T")
        TipDoc = Convert.ToString(Convert.ToDecimal(NomFile.Substring(pos, 3)))

        pos = InStr(1, NomFile, "F")
        NumDoc = Convert.ToString(Convert.ToDecimal(NomFile.Substring(pos, 10)))
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            'Se obtiene y se guarda cadena de caracteres en formato BASE64 (Tipo compresion en que esta el archivo PDF)
            If LOGIN_CONEXION = "TEST" Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim getBase64TEST As New wsTESTgetPDF64.getPDF64SoapClient() 'TEST
                Dim arrayOfStringTEST As New wsTESTgetPDF64.ArrayOfString 'TEST
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                arrayOfStringTEST = getBase64TEST.get_pdf(RutEmis, NumDoc, TipDoc, "", "", "", True)
                Base64Str = arrayOfStringTEST(1).Trim() 'Se almacena areglo en una variable String, segun la conexion que selecciono en el LOGIN
            End If
            If LOGIN_CONEXION = "MANUKA" Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim getBase64PROD As New wsPRODgetPDF64.getPDF64SoapClient() 'PROD
                Dim arrayOfStringPROD As New wsPRODgetPDF64.ArrayOfString 'PROD
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'CommandTimeout = 300
                arrayOfStringPROD = getBase64PROD.get_pdf(RutEmis, NumDoc, TipDoc, "", "", "", True)
                Base64Str = arrayOfStringPROD(1).Trim() 'Se almacena arreglo en una variable String, segun la conexion que selecciono en el LOGIN
            End If

        Catch ex As Exception
            MsgBox("Error al consumir Web Services. Descripcion Error:" & ex.ToString, MsgBoxStyle.Critical, System.Windows.Forms.Application.ProductName)
        End Try
        'Se convierte cadena (Arreglo) en Bytes
        byteData = Convert.FromBase64String(Base64Str)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim strStreamW As FileStream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Dim NomArchivo As String = NomFile.Trim & ".pdf"
        Dim PathArchivo As String = "C:\APPS\PDFsuite\" & NomArchivo
        Dim PathArchivoRed01 As String = "\\DTEFILESERVER\Arch\" & NomArchivo
        Dim PathArchivoRed02 As String = "\\WEBAPP\DTE_Archivos\" & NomArchivo

        Dim AcrobateInstance() As Process = Process.GetProcessesByName("Acrobat")

        'Dim PathArchivoRed01 As String = "\\192.168.0.212\DTE_Archivos\" & NomArchivo
        'Dim PathArchivoRed02 As String = "\\192.168.0.212\Arch\" & NomArchivo


        Try
            If File.Exists(PathArchivo) = True Then
                If AcrobateInstance.Length > 0 Then
                    AcrobateInstance(1).Kill()
                End If
                File.Delete(PathArchivo)
            End If
            If Directory.Exists("C:\APPS\PDFsuite\") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory("C:\APPS\PDFsuite\")
            End If

            strStreamW = New FileStream(PathArchivo, FileMode.Append)
            strStreamW.Write(byteData, 0, byteData.Length)
            strStreamW.Close()
        Catch ex As Exception
            MsgBox("Error al Guardar la informacion en el archivo (" & NomArchivo & "). " & ex.ToString, MsgBoxStyle.Critical, System.Windows.Forms.Application.ProductName)
            strStreamW.Close()
        End Try

        Try
            'Process.Start("AcroRD32.exe", PathArchivo)
            Dim Proceso As New Process
            Proceso.StartInfo.FileName = PathArchivo
            Proceso.Start()
        Catch exAcroRD As Exception
            MsgBox("Error al abrir el archivo PDF (" & NomArchivo & "). Verifique que tiene instalado 'Adobe Reader' en su PC. " & exAcroRD.ToString, MsgBoxStyle.Critical, System.Windows.Forms.Application.ProductName)
        End Try

        Try
            If IsFileOpen(PathArchivoRed01) Then
                GoTo Fin
            End If
            My.Computer.FileSystem.CopyFile(PathArchivo, PathArchivoRed01, overwrite:=True)
            My.Computer.FileSystem.CopyFile(PathArchivo, PathArchivoRed02, overwrite:=True)
        Catch ex As Exception
            MsgBox("(1) Error al copiar archivo (" & NomArchivo & ") a la carpeta de RED. Cominiquese con IT. " & ex.ToString, MsgBoxStyle.Critical, System.Windows.Forms.Application.ProductName)
        End Try

Fin:
    End Sub
    Private Function IsFileOpen(filePath As String) As Boolean
        Dim rtnvalue As Boolean = False
        Try
            Dim fs As System.IO.FileStream = System.IO.File.OpenWrite(filePath)
            fs.Close()
        Catch ex As System.IO.IOException
            rtnvalue = True
        End Try
        Return rtnvalue
    End Function

    Public Function GeneraNombreArchivo(ByVal TipoDoc As Integer, ByVal NroDoc As Integer, ByVal EmpresaDoc As Integer) As String
        Return "E0" + EmpresaDoc.ToString + "T0" + TipoDoc.ToString.Trim + "F" + NroDoc.ToString.PadLeft(10, "0")
    End Function

    Public Function GeneraNombreArchivoBodega(ByVal Empr As Integer, ByVal TipoDoc As Integer, ByVal NroDoc As Integer) As String
        Return "E0" + Empr.ToString + "T0" + TipoDoc.ToString.Trim + "F" + NroDoc.ToString.PadLeft(10, "0")
    End Function
End Class
