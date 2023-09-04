Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmCambioRazasCodigos
    Private Sub frmCambioRazasCodigos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        BuscaRazas()
    End Sub
    Public Sub BuscaRazas()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRazas_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure


        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim itm As New ListViewItem()
                    itm.SubItems.Add(rdr("CodRaza").ToString.Trim)
                    itm.SubItems.Add(rdr("NomRaza").ToString.Trim)
                    lvGanado.Items.Add(itm)
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class