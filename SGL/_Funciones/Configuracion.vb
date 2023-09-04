







Public Class Configuracion


    Private Declare Ansi Function GetPrivateProfileString Lib "kernel32.dll" Alias "GetPrivateProfileStringA" _
        (ByVal lpApplicationName As String, _
         ByVal lpKeyName As String, _
         ByVal lpDefault As String, _
         ByVal lpReturnedString As System.Text.StringBuilder, _
         ByVal nSize As Integer, _
         ByVal lpFileName As String) _
     As Integer

    Private Declare Ansi Function WritePrivateProfileString Lib "kernel32.dll" Alias "WritePrivateProfileStringA" _
        (ByVal lpApplicationName As String, _
         ByVal lpKeyName As String, _
         ByVal lpString As String, _
         ByVal lpFileName As String) _
    As Integer


    Public Property Path As String


    ''' <summary>
    ''' Constructor de la Configuracion
    ''' </summary>
    ''' <param name="ConfigPath">La ruta del arcchivo de Configuración.</param>
    Public Sub New(ByVal ConfigPath As String)
        _Path = ConfigPath
    End Sub


    ''' <summary>
    ''' Leer un valor desde la configuración de tipo string
    ''' </summary>
    ''' <param name="section">La sección dentro del archivo de configuración</param>
    ''' <param name="key">La clave en la sección del archivo de configuración</param>
    Public Function ReadValue(ByVal section As String, ByVal key As String) As String

        Dim sb As New System.Text.StringBuilder(255)
        Dim i = GetPrivateProfileString(section, key, "", sb, 255, Path)
        Dim valor_ As String = sb.ToString.Trim

        ReadValue = valor_
    End Function


    ''' <summary>
    ''' Leer un valor desde la configuración
    ''' </summary>
    ''' <param name="section">La sección dentro del archivo de configuración</param>
    ''' <param name="key">La clave en la sección del archivo de configuración</param>
    Public Function ReadValue(ByVal section As String, ByVal key As String, ByVal valdef As Integer) As Integer

        Dim sb As New System.Text.StringBuilder(255)
        Dim i = GetPrivateProfileString(section, key, "", sb, 255, Path)
        Dim valor_ As Integer = 0

        Try
            valor_ = Int32.Parse(sb.ToString.Trim)
        Catch ex As Exception
            valor_ = valdef
        End Try

        ReadValue = valor_
    End Function


    ''' <summary>
    ''' Grabar un valor en la configuración
    ''' </summary>
    ''' <param name="section">La sección dentro del archivo de configuración</param>
    ''' <param name="key">LA clave en la sección del archivo de configuración</param>
    ''' <param name="value">El valor a grabar en la clave de la sección</param>
    Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal value As String)
        WritePrivateProfileString(section, key, value, Path)
    End Sub



    Private Sub CargarConfiguracion()
    End Sub


End Class
