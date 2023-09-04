Imports System.Data.SqlClient
Public Class frmActualizaciones
    Dim Actualizar As Integer = 0
    Private Sub frmActualizaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Left = 50
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8
        BuscarActualizaciones()
        Dim item As New ListViewItem(1)    'primera columna, para ordenar los datos
        BuscarActualizaciones()
    End Sub
    Public Sub BuscarActualizaciones()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spActualizacionesSGL", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            lvMENSAJES.Items.Clear()
            Try
                While rdr.Read()
                    i = i + 1
                    Dim lvitem As New ListViewItem(i)    'primera columna, para ordenar los datos
                    lvitem.SubItems.Add(rdr("ActFecha"))
                    lvitem.SubItems.Add(rdr("ActNombre").ToString)
                    lvitem.SubItems.Add(rdr("ActDescripcion").ToString)
                    lvMENSAJES.Items.Add(lvitem)
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

    Private Sub btnOcultar_Click(sender As Object, e As EventArgs) Handles btnOcultar.Click
        If Actualizar = 0 Then
            Me.Close()
            frmMAIN.version.Enabled = True
        Else
            frmMAIN.cierreforzado = 1
            Application.Exit()
        End If
    End Sub

    Public Sub CerradoAutomatico()
        Actualizar = 1
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub tmrOcultar_Tick(sender As Object, e As EventArgs) Handles tmrOcultar.Tick

    End Sub
End Class