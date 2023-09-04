

Imports System.Runtime.InteropServices


Public Class frmExtSolicitudes
    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_MAXIMIZE As Integer = &HF030



    <DllImport("user32")>
    Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function




    Private Sub Solicitudes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WebBrowser1.Dock = DockStyle.Fill
    
        WebBrowser1.Navigate("http://SRVMNKDEV/SAMMTST/index.aspx")


        'Dim proc As Process
        'proc = Process.Start("chrome.exe", """http://SRVMNKDEV/SAMMTST/index.aspx""")
        'proc.WaitForInputIdle()

        'SetParent(proc.MainWindowHandle, Me.Handle)
        ''SetParent(Me.FindWindow(vbNullString, "SomeApp"), MyFrm2.Handle.ToInt32)


        ''SendMessage(proc.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)

        ''Me.BringToFront()



    End Sub
End Class