Imports System.Data.SqlClient
Public Class frmDiasBastoneo
    Private Sub frmDiasBastoneo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Left = 50
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8

        General.TipoCentros.Cargar()
        CboLLenaTipoCentro()
        tipCentro.SelectedIndex = 0
        tipConteo.SelectedIndex = 0
        ConsultaTiposCentros()

    End Sub
    Private Sub CboLLenaTipoCentro()
        If General.TipoCentros.NroRegistros = 0 Then Exit Sub
        tipCentro.Items.Clear()
        tipCentro.Items.Add("--Seleccione--")
        Dim i As Integer
        For i = 0 To General.TipoCentros.NroRegistros - 1
            tipCentro.Items.Add(General.TipoCentros.Nombre(i))
        Next

        tipConteo.Items.Clear()
        tipConteo.Items.Add("--Seleccione--")
        tipConteo.Items.Add("CIERRE")
        tipConteo.Items.Add("CONTEO")


    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Public Sub ConsultaTiposCentros()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteos_DiasHabiles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

        lista_usuarios.BeginUpdate()
        lista_usuarios.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    Dim item2 As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos
                    item2.SubItems.Add(rdr("CentroTipo").ToString.Trim)
                    item2.SubItems.Add(rdr("TipoConteo").ToString.Trim)
                    item2.SubItems.Add(rdr("DiasHabiles").ToString.Trim)
                    lista_usuarios.Items.Add(item2)
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
SalirProc:
        lista_usuarios.EndUpdate()
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If diastxt.Text > 60 Then
            MsgBox("Numero maximo de dias habiles es 60", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia")
        Else
            Grabar()
            ConsultaTiposCentros()
        End If

    End Sub
    Private Sub Grabar()


        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("SpConteos_CambiarDiasHabiles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@CentroTipo", General.TipoCentros.Nombre(tipCentro.SelectedIndex - 1))
        cmd.Parameters.AddWithValue("@TipoConteo", tipConteo.Text)
        cmd.Parameters.AddWithValue("@Dias", diastxt.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)


        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
        MsgBox("Datos Actualizados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub diastxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles diastxt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then

        Else
            If InStr(1, "0123456789" & Chr(8), e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub ValidaCampos()
        If tipCentro.Text = "--Seleccione--" Or tipConteo.Text = "--Seleccione--" Or diastxt.Text = "" Then
            btnFinalizar.Enabled = False
        Else
            btnFinalizar.Enabled = True
        End If




    End Sub

    Private Sub tipCentro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tipCentro.SelectedIndexChanged
        ValidaCampos()
    End Sub

    Private Sub tipConteo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tipConteo.SelectedIndexChanged
        ValidaCampos()
    End Sub

    Private Sub diastxt_TextChanged(sender As Object, e As EventArgs) Handles diastxt.TextChanged
        ValidaCampos()
    End Sub
End Class