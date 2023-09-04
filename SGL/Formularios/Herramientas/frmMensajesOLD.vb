

Imports System.Data.SqlClient


Public Class frmMensajesOLD


    Private FormOculto As Boolean = False


    Private Function ContabilizaMensajes() As Integer
        ContabilizaMensajes = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMensajes_TotalMensajes", con)
        'Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            Dim TotMsjsActivos As Integer = CType(cmd.ExecuteScalar, Integer)

            'Me.Text = "Mensajes Pendientes (" + TotMsjsActivos.ToString.Trim + ")"
            Label3.Text = "MENSAJES PENDIENTES (" + TotMsjsActivos.ToString.Trim + ")"
            btnMensajes.Text = "MENSAJES PENDIENTES (" + TotMsjsActivos.ToString.Trim + ")"

            If TotMsjsActivos = 0 Then
                btnMensajes.BackColor = Color.Green
                'btnMensajes.ForeColor = Color.White
                Panel1.BackColor = Color.Green
            Else
                btnMensajes.BackColor = Color.Red
                'btnMensajes.ForeColor = Color.DimGray
                Panel1.BackColor = Color.Red
            End If

            ContabilizaMensajes = TotMsjsActivos

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Function


    Private Sub BuscarMensajes()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMensajes_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvMENSAJES.BeginUpdate()
        lvMENSAJES.Items.Clear()

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem("")    'primera columna, codigo del mensaje

                    item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("MsgEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(rdr("MsgModulo").ToString.Trim)
                    item.SubItems.Add(rdr("MTipNombre").ToString.Trim)
                    item.SubItems.Add(Format(rdr("MsgFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("MsgTexto").ToString.Trim)
                    item.SubItems.Add(rdr("MsgValor").ToString.Trim)
                    item.SubItems.Add(rdr("MEstNombre").ToString.Trim)
                    item.SubItems.Add(rdr("MsgEquipo").ToString.Trim)
                    item.SubItems.Add(rdr("MsgUsuario").ToString.Trim)
                    item.SubItems.Add(rdr("MsgFechaReg").ToString.Trim)
                    item.SubItems.Add(rdr("MsgCodigo").ToString.Trim)

                    lvMENSAJES.Items.Add(item)

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

        lvMENSAJES.EndUpdate()
    End Sub


    Private Function MercarComoLeidos() As Boolean
        MercarComoLeidos = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMensajes_MarcarLeidos", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cods_ As String = ""

        cods_ = GeneraStringCods()
        ''
        cmd.Parameters.AddWithValue("@ArrayCods", cods_)
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
            If vret = -1 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            MercarComoLeidos = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function GeneraStringCods() As String
        GeneraStringCods = ""

        Dim i As Integer = 0
        Dim str_ As String = ""
        Dim chk_ As Boolean = False

        For i = 0 To lvMENSAJES.Items.Count - 1
            chk_ = lvMENSAJES.Items(i).Checked

            If chk_ = True Then
                str_ = str_ + lvMENSAJES.Items(i).SubItems(13).Text.ToString.Trim + ","
            End If
        Next

        If str_.Length > 0 Then
            str_ = Mid(str_, 1, str_.Length - 1)
        End If

        GeneraStringCods = str_
    End Function


    Private Sub ProcesarOcultar()
        If FormOculto = False Then

            If (Me.Top + Me.Height) > 24 Then
                Me.Top = Me.Top - 100
            Else
                tmrOcultar.Enabled = False
                Me.Top = 0 - Me.Height + 50
            End If

            FormOculto = True
        Else

            If (Me.Top + Me.Height) > 24 Then
                Me.Top = Me.Top - 100
            Else
                tmrOcultar.Enabled = False
            End If

            FormOculto = False
        End If
    End Sub


    Private Sub tmrOcultar_Tick(sender As System.Object, e As System.EventArgs) Handles tmrOcultar.Tick
        'ProcesarOcultar()
        ProcesaConsultaMensajes()
        'If ValidaUltimaVersion() = False Then

        '    If VerificaAviso() = False Then
        '        Dim msg As String
        '        msg = "Su versión de SGL no esta actualizada." & vbCrLf & "Favor, reingrese al sistema."
        '        MsgBox(msg, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Verificador Versión SGL")
        '    End If

        'End If
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub chkTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTodos.CheckedChanged
        If lvMENSAJES.Items.Count = 0 Then Exit Sub

        Dim i As Integer

        lvMENSAJES.BeginUpdate()

        For i = 0 To lvMENSAJES.Items.Count - 1
            lvMENSAJES.Items(i).Checked = chkTodos.Checked
        Next

        lvMENSAJES.EndUpdate()
    End Sub


    Private Sub lvMENSAJES_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvMENSAJES.ItemChecked
        If lvMENSAJES.Items.Count = 0 Then Exit Sub
        VerificaCheck()
    End Sub


    Private Sub VerificaCheck()
        Dim i As Integer
        Dim Marcados As Boolean = False

        For i = 0 To lvMENSAJES.Items.Count - 1
            If lvMENSAJES.Items(i).Checked = True Then
                Marcados = True
                Exit For
            End If
        Next

        If Marcados Then
            btnMarcar.Enabled = True
        Else
            btnMarcar.Enabled = False
        End If
    End Sub

    Private Sub btnMarcar_Click(sender As System.Object, e As System.EventArgs) Handles btnMarcar.Click
        If MsgBox("¿ DESEA MARCAR COMO LEÍDOS LOS MENSAJES SELECCIONADOS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SGL") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If MercarComoLeidos() = True Then
            ProcesaConsultaMensajes()
        End If
    End Sub


    Private Sub btnOcultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOcultar.Click
        MinimizarMensajes()
    End Sub


    Private Sub btnMensajes_Click(sender As System.Object, e As System.EventArgs) Handles btnMensajes.Click
        MaximizarMensajes()
        BuscarMensajes()
    End Sub


    Private Sub frmMensajes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        MinimizarMensajes()

        ProcesaConsultaMensajes()

        tmrOcultar.Enabled = True

        'solo el "ADMINISTRADOR DE SALA" puede limpiar mensajes
        If NombrePerfilUsuario.Contains("ADMINISTRADOR DE SALA") Or NombrePerfilUsuario.Contains("JEFE DE PRODUCCIÓN") Then
            btnMarcar.Visible = True
        Else
            btnMarcar.Visible = False
            lvMENSAJES.CheckBoxes = False
            chkTodos.Visible = False
            lvMENSAJES.Columns(0).Width = 0
        End If


    End Sub


    Private Sub ProcesaConsultaMensajes()
        If ContabilizaMensajes() <= 0 Then
            lvMENSAJES.Items.Clear()
        End If

        chkTodos.Checked = False
    End Sub


    Private Sub MinimizarMensajes()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.Top = 1
        Me.Left = 1
        Me.Width = btnMensajes.Width
        Me.Height = btnMensajes.Height

        btnMensajes.Visible = True
        GroupBox1.Visible = False

        Me.SendToBack()
    End Sub


    Private Sub MaximizarMensajes()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Height = 430
        Me.Width = 931

        btnMensajes.Visible = False
        GroupBox1.Visible = True

        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.BringToFront()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class