Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmDesechosIngreso
    Private CodigoDIIO As String
    Private ArchivoImportacion As String
    Private NombreArchivo As String
    Private Diioexcel As String
    Private Razaexcel As String
    Private Sub CambioRazasIngresar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.TipoDesechos.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLLenaDesecho()
        BuscaDesecho()
        Fecha.Value = DateTime.Now
    End Sub
    Public Sub BuscaDesecho()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTipoDesechos_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim itm As New ListViewItem()
                    itm.SubItems.Add(rdr("coddesch").ToString.Trim)
                    itm.SubItems.Add(rdr("Nomdesch").ToString.Trim)
                    ListView1.Items.Add(itm)
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

    Private Sub CboLLenaDesecho()
        If General.TipoDesechos.NroRegistros = 0 Then Exit Sub
        cboTipoDesechos.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoDesechos.NroRegistros - 1
            cboTipoDesechos.Items.Add(General.TipoDesechos.Nombre(i))
        Next
    End Sub
    Private Sub LimpiaDatos()
        'txtDIIO.Text = ""
        lblSala.Text = ""
        lblCategoria.Text = ""
        lblEstado.Text = ""
        lblSexo.Text = ""
        lblRaza.Text = ""
        lblFecNacimiento.Text = ""
        lblSala.Text = ""
        lblCategoria.Text = ""
        lblEstado.Text = ""


    End Sub


    Public Sub ConsultaDIIO()
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    If rdr("CenDesCor").ToString.Trim = "" Then
                        lblSala.Text = "--- SIN SALA ----"
                        lblSala.ForeColor = Color.Red
                    Else
                        lblSala.Text = rdr("CenDesCor").ToString.Trim
                        lblSala.ForeColor = SystemColors.ControlText
                    End If

                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    '
                    lblSexo.Text = rdr("GndSexo").ToString.Trim
                    lblRaza.Text = rdr("RazaNom").ToString.Trim
                    If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        lblEstado.Text = "DESAPARECIDO"
                        lblEstado.ForeColor = Color.Red
                    ElseIf rdr("GndIsVendido").ToString.Trim = "SI" Then
                        lblEstado.Text = "VENDIDO"
                        lblEstado.ForeColor = Color.Red
                    ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        lblEstado.Text = "MUERTO"
                        lblEstado.ForeColor = Color.Red
                    Else
                        lblEstado.Text = "STOCK"
                        lblEstado.ForeColor = Color.DarkBlue
                    End If
                    Existe = True
                End While

                If Existe = True Then
                    'lblSala.ForeColor = SystemColors.ControlText

                    lblSala.Cursor = Cursors.Default
                    'lblPadre.Cursor = Cursors.Default
                    'lblAbuelo.Cursor = Cursors.Default

                    If lblSala.Text <> "" Then lblSala.Cursor = Cursors.Hand
                    'If lblPadre.Text <> "" Then lblPadre.Cursor = Cursors.Hand
                    'If lblAbuelo.Text <> "" Then lblAbuelo.Cursor = Cursors.Hand
                Else
                    lblSala.Text = "---- REGISTRO NO EXISTE ----"
                    lblSala.ForeColor = Color.Red
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Consultar.Click

        CodigoDIIO = txtDIIO.Text
        ConsultaDIIO()
        If lblSala.Text <> "---- REGISTRO NO EXISTE ----" Then
            cboTipoDesechos.Enabled = True
        End If
    End Sub

    Private Sub CambioRazas()
        Dim diio As String
        diio = txtDIIO.Text
        Dim n As Integer = 0
        Dim i As Integer = 0
        n = lvGanado.Items.Count.ToString
        For i = 0 To n - 1
            Cursor.Current = Cursors.WaitCursor

            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spCambioRazas_Grabar", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Diio", lvGanado.Items(i).SubItems(2).Text.Trim)
            cmd.Parameters.AddWithValue("@Raza", lvGanado.Items(i).SubItems(10).Text.Trim)
            cmd.Parameters.AddWithValue("@Fecha", Fecha.Value)

            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

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
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")

            Finally
                con.Close()
            End Try

        Next
        Cursor.Current = Cursors.Default
    End Sub
    'Public Function ConsultaDIIOPorExel(ByVal Diioexcel As Integer, ByVal Razaexcel As Integer)
    '    Dim Centro As String = ""
    '    Dim Estado As String = ""
    '    Dim Categoria As String = ""
    '    Dim Diio As String = Diioexcel
    '    Dim RazaActual As String = ""
    '    Dim Razanueva As String = ""
    '    Dim num As Integer
    '    num = ListView1.Items.Count.ToString
    '    For i = 0 To num - 1
    '        If ListView1.Items(i).SubItems(1).Text.Trim = Razaexcel Then
    '            Razanueva = ListView1.Items(i).SubItems(2).Text.Trim
    '        End If
    '    Next
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
    '    Dim rdr As SqlDataReader = Nothing
    '    Dim Existe As Boolean = False

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@CodigoDIIO", Diioexcel)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)
    '    Try
    '        con.Open()
    '        rdr = cmd.ExecuteReader()
    '        LimpiaDatos()
    '        Try
    '            While rdr.Read()
    '                If rdr("CenDesCor").ToString.Trim = "" Then
    '                    Centro = "Sin Sala"
    '                Else
    '                    Centro = rdr("CenDesCor").ToString.Trim
    '                End If
    '                Categoria = rdr("GndProNom").ToString.Trim
    '                RazaActual = rdr("RazaNom").ToString.Trim
    '                If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
    '                    Estado = "Desaparecido"
    '                ElseIf rdr("GndIsVendido").ToString.Trim = "SI" Then
    '                    Estado = "Vendido"
    '                ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
    '                    Estado = "Mmuerto"
    '                Else
    '                    Estado = "Vivo"
    '                End If
    '                Existe = True
    '            End While
    '            If Existe = True Then
    '            Else
    '                Diio = "DIIO No Existe"
    '            End If

    '            Dim itm As New ListViewItem((lvGanado.Items.Count + 1).ToString)
    '            itm.SubItems.Add(Centro)
    '            itm.SubItems.Add(Diio)
    '            itm.SubItems.Add(RazaActual)
    '            itm.SubItems.Add(Razanueva)
    '            itm.SubItems.Add(LoginUsuario)
    '            itm.SubItems.Add("")
    '            itm.SubItems.Add(Categoria)
    '            itm.SubItems.Add(Estado)
    '            itm.SubItems.Add(DateTime.Now)
    '            itm.SubItems.Add(Razaexcel)
    '            lvGanado.Items.Add(itm)

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Function

    Private Sub txtDIIO_TextChanged(sender As Object, e As EventArgs) Handles txtDIIO.TextChanged
        Consultar.Enabled = True
    End Sub

    Private Sub cboRazas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoDesechos.SelectedIndexChanged
        btnGrabar.Enabled = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        Dim variable As Boolean
        Dim n As Integer
        variable = True
        n = lvGanado.Items.Count.ToString
        For i = 0 To n - 1
            If txtDIIO.Text.Trim = lvGanado.Items(i).SubItems(2).Text.Trim Then
                variable = False
                MsgBox("Diio ya ingresado")
            End If
        Next
        If cboTipoDesechos.Text.Trim = lblRaza.Text.Trim Then
            variable = False
            MsgBox("Seleccionar una raza diferente")
        End If

        If variable = True Then
            llenadoLv()

        End If


    End Sub
    Private Sub llenadoLv()
        Dim itm As New ListViewItem((lvGanado.Items.Count + 1).ToString)
        itm.SubItems.Add(lblSala.Text.Trim)
        itm.SubItems.Add(txtDIIO.Text.Trim)
        itm.SubItems.Add(lblRaza.Text.Trim)
        itm.SubItems.Add(General.Razas.Nombre(cboTipoDesechos.SelectedIndex))
        itm.SubItems.Add(LoginUsuario)
        itm.SubItems.Add("")
        itm.SubItems.Add(lblCategoria.Text.Trim)
        itm.SubItems.Add(lblEstado.Text.Trim)
        itm.SubItems.Add(DateTime.Now)
        itm.SubItems.Add(General.Razas.Codigo(cboTipoDesechos.SelectedIndex))
        lvGanado.Items.Add(itm)

    End Sub
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim num As Integer
        num = lvGanado.Items.Count.ToString
        For i = 0 To num - 1
            If lvGanado.Items(i).BackColor = Color.Red Then
                If MsgBox("PARA GRABAR DATOS, ELIMINAR ERRORES", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    Exit Sub
                End If
            End If
        Next

        If MsgBox("¿ DESEA GRABAR EL INGRESO DE DESECHOS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        CambioRazas()

        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

            Me.Close()

            frmReportesCambioRazas.btnBuscar.PerformClick()
        End If

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        For Each it As ListViewItem In lvGanado.SelectedItems
            lvGanado.Items.Remove(it)
        Next


    End Sub

    Private Sub txtDIIO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call Button1_Click(sender, e)
        End If
    End Sub

    Private Sub btnBastonLimpia_Click(sender As Object, e As EventArgs)
        frmCambioRazasCodigos.MdiParent = frmMAIN
        frmCambioRazasCodigos.Show()
        frmCambioRazasCodigos.BringToFront()
    End Sub

End Class