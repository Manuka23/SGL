Imports System.Data.SqlClient
Public Class frmResumenes
    Private Sub frmResumenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True
        'ProduccionLeche()
    End Sub

    'Private Sub ProduccionLeche()
    '    Cursor.Current = Cursors.WaitCursor
    '    Try
    '        Dim con As New SqlConnection(GetConnectionString())
    '        Dim cmd As New SqlCommand("spLeche_ProduccionResumen", con)
    '        Dim rdr As SqlDataReader = Nothing

    '        cmd.CommandType = Data.CommandType.StoredProcedure

    '        cmd.Parameters.AddWithValue("@CentroDefault", CodigoCentroUsuario)
    '        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '        con.Open()
    '        rdr = cmd.ExecuteReader()

    '        ChartCobMes.Series("Series1").Points.Clear()
    '        ChartCobMes.Series("Series1").Points.DataBindXY(rdr, "Dia", rdr, "LecheEstanque")

    '        rdr.Close()
    '        cmd.Dispose()
    '        con.Close()
    '        '
    '        con.Open()
    '        rdr = cmd.ExecuteReader()
    '        rdr.Read()
    '        If rdr.Read() = True Then
    '            ChartCobMes.Titles(0).Text = "Pruduccion de leche entre " & ("01" & "/" & IIf(Month(Now) < 10, "0", "") & Month(Now) & "/" & Year(Now)) & " y el " & Date.Now.Date
    '        End If
    '        rdr.Close()
    '        cmd.Dispose()
    '        con.Close()

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
    '    End Try

    '    Cursor.Current = Cursors.WaitCursor
    'End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Chart2_Click(sender As Object, e As EventArgs)

    End Sub
End Class