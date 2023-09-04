

Imports System.IO
Imports System.Diagnostics


Public Class Actualizador

    Private _localdir As String = Directory.GetCurrentDirectory()
    Private _file As String


    Public Property Archivo() As String
        Get
            Return _file
        End Get

        Set(ByVal value As String)
            _file = value
        End Set
    End Property


    Public Function ExisteNuevaVersion() As Boolean
        ExisteNuevaVersion = False

        Try
            Dim _app As String = _localdir + "\" + _file
            Dim _new As String = "\\srvsql2\MNK_PROD\Software\UpdateMy\" + _file
            'Dim _apptmp As String

            Dim dt_new As DateTime = File.GetLastWriteTime(_new)
            Dim dt_app As DateTime = File.GetLastWriteTime(_app)

            If dt_new > dt_app Then
                '_apptmp = _app + ".tmp"
                ExisteNuevaVersion = True
                Exit Function
                'File.Copy(_new, _apptmp, True)
                'File.Copy(_apptmp, _app, True)
                'File.Delete(_apptmp)
            End If


        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
        End Try

    End Function


    Public Sub Actualizar()
        Dim _app As String = _localdir + "\" + _file
        Dim _new As String = "\\srvsql2\MNK_PROD\Software\UpdateMy\" + _file
        Dim _apptmp As String

        _apptmp = _app + ".tmp"

        Try
            File.Copy(_new, _apptmp, True)
            File.Copy(_apptmp, _app, True)
            File.Delete(_apptmp)

        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
        End Try
    End Sub


End Class
