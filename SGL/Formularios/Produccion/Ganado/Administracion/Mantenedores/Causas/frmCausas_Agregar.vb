Imports System.Data.SqlClient
Public Class frmCausas_Agregar
    Dim muerte As Integer = 0
    Dim venta As Integer = 0
    Dim muertecat As String
    Dim ventacat As String
    Public nombreCausa As String = ""
    Public modificarCausa As Integer = 0
    Private Sub frmCausas_Agregar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLlena()
        If nombreCausa <> "" Then
            Causa.Text = nombreCausa
            Causa.Enabled = False
            CausasModificar()
        End If
    End Sub
    Private Sub CboLlena()
        cbomuerte.Items.Clear()
        cbomuerte.Items.Add("-Seleccione-")
        cbomuerte.Items.Add("NO")
        cbomuerte.Items.Add("SI")
        cbomuerte.SelectedIndex = 0

        cboventa.Items.Clear()
        cboventa.Items.Add("-Seleccione-")
        cboventa.Items.Add("NO")
        cboventa.Items.Add("SI")
        cboventa.SelectedIndex = 0

        cbocatm.Items.Clear()
        cbocatm.Items.Add("-Seleccione-")
        cbocatm.Items.Add("DIGESTIVE")
        cbocatm.Items.Add("INFECTIOUS")
        cbocatm.Items.Add("METABOLIC")
        cbocatm.Items.Add("OTHERS")
        cbocatm.Items.Add("TRAUMA")
        cbocatm.SelectedIndex = 0

        cbocatv.Items.Clear()
        cbocatv.Items.Add("-Seleccione-")
        cbocatv.Items.Add("EMERGENCY SALES")
        cbocatv.Items.Add("FAT COWS")
        cbocatv.Items.Add("OTHERS")
        cbocatv.SelectedIndex = 0
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Grabar()
        Me.Close()
    End Sub
    Private Sub Grabar()
        Dim i As Integer = 0


        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCausas_Crear", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        If nombreCausa <> "" Then
            cmd.Parameters.AddWithValue("@Mod", 1)
        Else
            cmd.Parameters.AddWithValue("@Mod", 0)
        End If
        cmd.Parameters.AddWithValue("@NombreCausa", Causa.Text)
        cmd.Parameters.AddWithValue("@CauMuerte", muerte)
        cmd.Parameters.AddWithValue("@CauVenta", venta)
        cmd.Parameters.AddWithValue("@CategoriaMuerte", muertecat)
        cmd.Parameters.AddWithValue("@CategoriaVenta", ventacat)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@Duplicado", SqlDbType.Int) : cmd.Parameters("@Duplicado").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Dim dup As Integer = cmd.Parameters("@Duplicado").Value

            If dup = "1" Then
                MsgBox("Causa ya existe", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

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
        MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cbomuerte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbomuerte.SelectedIndexChanged
        If cbomuerte.Text = "SI" Then
            cbocatm.Enabled = True
            muerte = 1
        Else
            cbocatm.Text = "-Seleccione-"
            cbocatm.Enabled = False
            muerte = 0
        End If
    End Sub

    Private Sub cboventa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboventa.SelectedIndexChanged
        If cboventa.Text = "SI" Then
            cbocatv.Enabled = True
            venta = 1
        Else
            cbocatv.Text = "-Seleccione-"
            cbocatv.Enabled = False
            venta = 0
        End If
    End Sub

    Private Sub cbocatm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocatm.SelectedIndexChanged
        If cbocatm.Text = "-Seleccione-" Then
            muertecat = "ND"
        Else
            muertecat = cbocatm.Text
        End If
    End Sub

    Private Sub cbocatv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbocatv.SelectedIndexChanged
        If cbocatv.Text = "-Seleccione-" Then
            ventacat = "ND"
        Else
            ventacat = cbocatv.Text
        End If
    End Sub
    Private Sub CausasModificar()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCausas_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@NombreCausa", nombreCausa)
        cmd.Parameters.AddWithValue("@Modif", modificarCausa)
        Dim i As Integer = 0


        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    cbocatm.Text = rdr("CategoriaMuerte").ToString.Trim()
                    cbocatv.Text = rdr("CategoriaVenta").ToString.Trim()
                    If rdr("CauMuerte").ToString.Trim() = 1 Then
                        cbomuerte.Text = "SI"
                    Else
                        cbomuerte.Text = "NO"
                    End If
                    If rdr("CauVenta").ToString.Trim() = 1 Then
                        cboventa.Text = "SI"
                    Else
                        cboventa.Text = "NO"
                    End If

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

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class