Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient


Public Class frmComparaBaston

    Public Param1_CentroCod As String
    Public Param2_CentroNom As String
    Public Param3_Fecha As DateTime
    Public Param4_SaldoInicial As Integer
    Public Param5_SaldoFinal As Integer
    Public Param6_Estado As Integer
    Public Param7_Observs As String
    Public Param8_TipoCierre As String


    Private Sub DetalleGanado()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvGanado.SelectedItems.Item(0).SubItems(1).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Function RealizarCierreMensual() As Boolean
        RealizarCierreMensual = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCierres_CrearCierreMensual2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_CentroCod)
        cmd.Parameters.AddWithValue("@Tipo", Param8_TipoCierre)
        cmd.Parameters.AddWithValue("@Fecha", Param3_Fecha)
        cmd.Parameters.AddWithValue("@Observs", Param7_Observs)
        cmd.Parameters.AddWithValue("@SaldoInicial", Param4_SaldoInicial)
        cmd.Parameters.AddWithValue("@SaldoFinal", Param5_SaldoFinal)
        cmd.Parameters.AddWithValue("@Estado", Param6_Estado)                              '0=sin comparacion / 1=baston
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            RealizarCierreMensual = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function


    Public Sub CierreMensual()

        Dim MSG1_ As String = "¿ DESEA CERRAR EL PERIODO SELECCIONADO (" + Param3_Fecha.Month.ToString + "-" + Param3_Fecha.Year.ToString + "), PARA EL CENTRO " + Param2_CentroNom + " ?"
        Dim MSG2_ As String = "NOTA: DEBE ENTREGAR LA DOCUMENTACIÓN A CONTABILIDAD."
        Dim MSG3_ As String = "ADVERTENCIA: UNA VEZ CERRADO EL PERIODO MENSUAL, LA INFORMACIÓN DEL PERIODO CERRADO NO PODRA SER MODIFICADA."

        If MsgBox(MSG1_ + vbCrLf + vbCrLf + MSG2_ + vbCrLf + vbCrLf + MSG3_, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If RealizarCierreMensual() = True Then

                If MsgBox("PERIODO CERRADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                End If
                frmCierresIngreso.ActualizarDatos()

                Me.Close()
            End If
        End If
    End Sub


    Private Sub frmComparaBaston_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(1).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If

            'If e.KeyCode = Keys.V Then
            '    MsgBox("chao")
            'End If

        End If
    End Sub


    Private Sub frmComparaBaston_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        Me.KeyPreview = True

        If Param8_TipoCierre.Contains("MENSUAL") Then
            btnCierreMensual.Text = "Crear Cierre Mensual"
        Else
            btnCierreMensual.Text = "Crear Pre-Cierre"
        End If
    End Sub



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL DE COMPARACIONES: " : tot(0, 1) = Label8.Text.Trim
        tot(1, 0) = "DIFERENCIAS BASTON: " : tot(1, 1) = Label9.Text.Trim
        tot(2, 0) = "DIFERENCIAS CONSULTA: " : tot(2, 1) = Label13.Text.Trim

        ExportToExcelGrilla(lvGanado, tot)
    End Sub


    Private Sub btnCierreMensual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCierreMensual.Click
        CierreMensual()
    End Sub


    Private Sub frmComparaBaston_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmCierresIngreso.Enabled = True
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        CierreMensual()
    End Sub
End Class