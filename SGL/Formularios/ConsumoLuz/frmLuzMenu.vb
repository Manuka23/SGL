Imports System.Data.SqlClient

Public Class frmLuzMenu

    Private Sub frmLuzMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        LLenarCbxCentros()
        LLenarCbxMeses()

        For y = 2017 To DateTime.Now.Year
            cbxYear.Items.Add(y)
        Next

        cbxYear.SelectedItem = DateTime.Now.Year
        If cbxCentros.Items.Count > 0 Then
            cbxCentros.SelectedIndex = 0
        End If
        cbxMes.SelectedIndex = DateTime.Now.Month - 1
        'Me.MdiParent = frmMAIN
        'Me.Top = 30
        'Me.Left = 15
        If cbxYear.SelectedIndex >= 0 And cbxMes.SelectedIndex >= 0 And cbxCentros.SelectedIndex >= 0 Then
            Dim Cent As String = String.Empty
            If cbxCentros.SelectedItem.Equals("(TODOS)") Then
                Cent = ""
            Else
                Cent = General.CentrosUsuario.Codigo(cbxCentros.SelectedIndex - 1).ToString()
            End If
            BuscarDatos(cbxYear.SelectedItem, cbxMes.SelectedIndex + 1, Cent)
        End If
        'If General.PerfilUsuario = 6 Then
        '    gbxMantenedores.Visible = True
        'Else
        '    gbxMantenedores.Visible = False
        'End If

    End Sub

    Private Sub LLenarCbxCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cbxCentros.Items.Clear()
        cbxCentros.Items.Add("(TODOS)")
        Dim i As Integer
        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cbxCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub

    Private Sub BuscarDatos(ByVal Year As Integer, ByVal Month As Integer, ByVal Centro As String)
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spLuz_ConsumoReporteCentro", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@year", Year)
        cmd.Parameters.AddWithValue("@month", Month)

        cmd.Parameters.AddWithValue("@centro", Centro)
        lvReporte.BeginUpdate()
        lvReporte.Items.Clear()
        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem(Format(rdr("CodCentro").ToString.Trim))  'primera columna
                    'item.SubItems.Add())
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(rdr("CodCasa").ToString.Trim)
                    item.SubItems.Add(rdr("ConsumoActual").ToString.Trim)
                    item.SubItems.Add(rdr("Consumo").ToString.Trim)
                    lvReporte.Items.Add(item)
                    i = i + 1
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        lvReporte.EndUpdate()
    End Sub

    Private Sub LLenarCbxMeses()
        cbxMes.Items.Add("Enero")
        cbxMes.Items.Add("Febrero")
        cbxMes.Items.Add("Marzo")
        cbxMes.Items.Add("Abril")
        cbxMes.Items.Add("Mayo")
        cbxMes.Items.Add("Junio")
        cbxMes.Items.Add("Julio")
        cbxMes.Items.Add("Agosto")
        cbxMes.Items.Add("Septiembre")
        cbxMes.Items.Add("Octubre")
        cbxMes.Items.Add("Noviembre")
        cbxMes.Items.Add("Diciembre")
    End Sub

    'Private Function TodosCentros() As String
    '    TodosCentros = String.Empty
    '    For index = 0 To cbxCentros.Items.Count - 2
    '        TodosCentros += General.CentrosUsuario.Codigo(index).ToString() + ","
    '    Next
    '    TodosCentros = TodosCentros.TrimEnd(",")
    'End Function

    Private Sub cbxYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxYear.SelectedIndexChanged
        If cbxYear.SelectedIndex >= 0 And cbxMes.SelectedIndex >= 0 And cbxCentros.SelectedIndex >= 0 Then
            Dim Cent As String = String.Empty
            If cbxCentros.SelectedItem.Equals("(TODOS)") Then
                Cent = ""
            Else
                Cent = General.CentrosUsuario.Codigo(cbxCentros.SelectedIndex - 1).ToString()
            End If
            BuscarDatos(cbxYear.SelectedItem, cbxMes.SelectedIndex + 1, Cent)
        End If
    End Sub

    Private Sub cbxMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMes.SelectedIndexChanged
        If cbxYear.SelectedIndex >= 0 And cbxMes.SelectedIndex >= 0 And cbxCentros.SelectedIndex >= 0 Then
            Dim Cent As String = String.Empty
            If cbxCentros.SelectedItem.Equals("(TODOS)") Then
                Cent = ""
            Else
                Cent = General.CentrosUsuario.Codigo(cbxCentros.SelectedIndex - 1).ToString()
            End If
            BuscarDatos(cbxYear.SelectedItem, cbxMes.SelectedIndex + 1, Cent)
        End If
    End Sub

    Private Sub cbxCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCentros.SelectedIndexChanged
        If cbxYear.SelectedIndex >= 0 And cbxMes.SelectedIndex >= 0 And cbxCentros.SelectedIndex >= 0 Then
            Dim Cent As String = String.Empty
            If cbxCentros.SelectedItem.Equals("(TODOS)") Then
                Cent = ""
            Else
                Cent = General.CentrosUsuario.Codigo(cbxCentros.SelectedIndex - 1).ToString()
            End If
            BuscarDatos(cbxYear.SelectedItem, cbxMes.SelectedIndex + 1, Cent)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmConsumoLuz_Ingreso.MdiParent = frmMAIN
        frmConsumoLuz_Ingreso.Show()
        frmConsumoLuz_Ingreso.BringToFront()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmRelacion.MdiParent = frmMAIN
        frmRelacion.Show()
        frmRelacion.BringToFront()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmClasificacionSitio.MdiParent = frmMAIN
        frmClasificacionSitio.Show()
        frmClasificacionSitio.BringToFront()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmPoblacion.MdiParent = frmMAIN
        frmPoblacion.Show()
        frmPoblacion.BringToFront()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        frmConsumoLuzReporte.MdiParent = frmMAIN
        frmConsumoLuzReporte.Show()
        frmConsumoLuzReporte.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmParametros.MdiParent = frmMAIN
        frmParametros.Show()
        frmParametros.BringToFront()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        frmCasa.MdiParent = frmMAIN
        frmCasa.Show()
        frmCasa.BringToFront()
    End Sub
End Class