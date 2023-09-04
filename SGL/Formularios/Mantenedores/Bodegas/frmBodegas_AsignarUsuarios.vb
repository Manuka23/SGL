Imports System.Data.SqlClient
Public Class frmBodegas_AsignarUsuarios
    Public usuario As String
    Dim contdefault As Integer = 0
    Dim buscarUsu As Integer = 0
    Dim buscarCen As Integer = 0
    Private indx As Integer
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub frmBodegas_AsignarUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 0
        BuscarBodegas()
        BuscarUsuarios()
    End Sub
    'Private Sub TxtCentros_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCentros.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        Call Button1_Click(sender, e)
    '    End If
    'End Sub
    'Private Sub txtUsuario_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        Call btnBuscar_Click(sender, e)
    '    End If
    'End Sub
    Private Sub BuscarBodegas()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBodegas_Listado", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim i As Integer = 1

            While rdr.Read()

                If buscarCen = 1 Then

                    If rdr("LOCNDSCR").ToString.Trim.Contains(TxtCentros.Text) Then
                        Dim item As New ListViewItem()    'primera columna, para ordenar los datos
                        item.SubItems.Add((i).ToString.Trim)
                        item.Checked = False
                        item.SubItems.Add(rdr("LOCNCODE").ToString.Trim)
                        item.SubItems.Add(rdr("LOCNDSCR").ToString.Trim)
                        item.SubItems.Add("-")
                        lvCentros.Items.Add(item)
                        i = i + 1
                    End If
                Else
                    Dim item As New ListViewItem()    'primera columna, para ordenar los datos
                    item.SubItems.Add((i).ToString.Trim)
                    item.Checked = False
                    item.SubItems.Add(rdr("LOCNCODE").ToString.Trim)
                    item.SubItems.Add(rdr("LOCNDSCR").ToString.Trim)
                    item.SubItems.Add("-")
                    lvCentros.Items.Add(item)
                    i = i + 1
                End If
            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub BuscarUsuarios()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spUsuarios_ListadoBuscar", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@UserName", txtUsuario.Text)
            cmd.Parameters.AddWithValue("@CodPerfil", "")
            cmd.Parameters.AddWithValue("@Estado", "")

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim i As Integer = 1
            While rdr.Read()
                'If buscarUsu = 1 Then
                '    If rdr("UsrNombre").ToString.Trim.Contains(txtUsuario.Text) Then

                Dim item As New ListViewItem()    'primera columna, para ordenar los datos
                item.SubItems.Add((i).ToString.Trim)
                item.Checked = False
                item.SubItems.Add(rdr("UserName").ToString.Trim)
                item.SubItems.Add(rdr("UsrNombre").ToString.Trim)

                LvUsuarios.Items.Add(item)
                i = i + 1
                'End If
                'Else
                '    Dim item As New ListViewItem()    'primera columna, para ordenar los datos
                '    item.SubItems.Add((i).ToString.Trim)
                '    item.Checked = False
                '    item.SubItems.Add(rdr("UserName").ToString.Trim)
                '    item.SubItems.Add(rdr("UsrNombre").ToString.Trim)

                '    LvUsuarios.Items.Add(item)
                '    i = i + 1
                'End If




            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        buscarUsu = 1
        LvUsuarios.Items.Clear()
        BuscarUsuarios()

    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        buscarUsu = 0
        buscarCen = 0
        limpia()
    End Sub
    Private Sub limpia()
        txtUsuario.Text = ""
        TxtCentros.Text = ""
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        SelectT.Checked = False
        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        SelectT.Enabled = False
        btnGrabar.Enabled = False
        btnEliminar.Enabled = False
        btnDefault.Enabled = False
        lvCentros.Enabled = False
        lvCentros.Items.Clear()
        LvUsuarios.Items.Clear()
        BuscarBodegas()
        BuscarUsuarios()
        contdefault = 0
    End Sub
    Private Sub BuscarBodegasUsuario(ByVal indx As Integer)
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBodegas_LlenadoBodegas", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Usuario", LvUsuarios.Items(indx).SubItems(2).Text)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            con.Open()
            rdr = cmd.ExecuteReader()


            While rdr.Read()
                For i = 0 To lvCentros.Items.Count - 1
                    If lvCentros.Items(i).SubItems(2).Text = rdr("SitioCodigo").ToString.Trim() Then
                        lvCentros.Items(i).BackColor = Color.LightGray
                        Dim num As Integer = rdr("SitioDefault") '.ToString.Trim()
                        If num = -1 Then
                            lvCentros.Items(i).SubItems(4).Text = "S"
                        End If

                    End If
                Next
            End While

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub LvUsuarios_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles LvUsuarios.ItemCheck
        indx = e.Index
        BuscarBodegasUsuario(indx)
        lvCentros.Enabled = True
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        SelectT.Enabled = True
    End Sub

    Private Sub LvUsuarios_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LvUsuarios.ItemChecked
        If e.Item.Checked = True Then

            'MsgBox(e.Item.SubItems(1).Text)

            For i = LvUsuarios.Items.Count - 1 To 0 Step -1
                If LvUsuarios.Items(i).Checked = False Then
                    LvUsuarios.Items.RemoveAt(i)
                End If


            Next
        End If

    End Sub


    Private Sub lvCentros_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lvCentros.ItemCheck
        Dim color_fondo_ As Color = lvCentros.Items(e.Index).SubItems(0).BackColor
        If color_fondo_ = Color.LightGray And CheckBox2.Checked = False Then
            e.NewValue = CheckState.Unchecked
            MsgBox("Centro ya asignado para este usuario", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If color_fondo_ = Color.LightGray And CheckBox2.Checked = True And lvCentros.Items(e.Index).SubItems(4).Text = "S" Then
            e.NewValue = CheckState.Unchecked
            MsgBox("Centro por defecto ya asignado para este usuario", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If lvCentros.Items(e.Index).Checked = False Then
            If lvCentros.Items(e.Index).Checked = False And CheckBox2.Checked = False Then
                btnGrabar.Enabled = True
            Else
                btnGrabar.Enabled = False
            End If

            If lvCentros.Items(e.Index).Checked = False And CheckBox2.Checked = True Then
                btnDefault.Enabled = True
            Else
                btnDefault.Enabled = False
            End If


        Else

        End If

    End Sub

    Private Sub SelectT_CheckedChanged(sender As Object, e As EventArgs) Handles SelectT.CheckedChanged
        If SelectT.Checked = True Then
            For i = 0 To lvCentros.Items.Count - 1
                Dim color_fondo_ As Color = lvCentros.Items(i).BackColor
                If color_fondo_ = Color.LightGray Then
                    lvCentros.Items(i).Checked = False
                Else
                    lvCentros.Items(i).Checked = True
                End If

            Next
        Else
            For i = 0 To lvCentros.Items.Count - 1
                lvCentros.Items(i).Checked = False
            Next
        End If


    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            For i = lvCentros.Items.Count - 1 To 0 Step -1
                Dim color_fondo_ As Color = lvCentros.Items(i).BackColor
                If color_fondo_ = Color.LightGray Then
                    lvCentros.Items.RemoveAt(i)
                End If
            Next
        End If

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        For i = 0 To LvUsuarios.Items.Count - 1
            If LvUsuarios.Items(i).Checked = True Then
                usuario = LvUsuarios.Items(i).SubItems(2).Text.Trim
            End If
        Next
        If MsgBox("¿ DESEA GRABAR ASIGNACION DE CENTRO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        Grabar()

    End Sub
    Private Sub Grabar()
        Dim i As Integer = 0
        Dim n As Integer = 0
        n = lvCentros.Items.Count.ToString
        For i = 0 To n - 1

            Cursor.Current = Cursors.WaitCursor
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBodegas_AsignacionUsuarios", con)
            Dim rdr As SqlDataReader = Nothing

            If lvCentros.Items(i).Checked = True Then
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Usuario", usuario)
                cmd.Parameters.AddWithValue("@Default", contdefault)
                cmd.Parameters.AddWithValue("@Bodega", lvCentros.Items(i).SubItems(2).Text.Trim)
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
                    Exit For
                Finally
                    con.Close()
                End Try

            End If
        Next
        If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

            limpia()
        End If

        ''si todo sale ok, retornamos ok

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lvCentros.Items.Clear()
        buscarCen = 1
        BuscarBodegas()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub



    Private Sub lvCentros_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvCentros.ColumnClick

        OrdenarColumnasLV.OrdenarColumnas(lvCentros, e)

    End Sub



    Private Sub LvUsuarios_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles LvUsuarios.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(LvUsuarios, e)
    End Sub


    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            buscarUsu = 1
            LvUsuarios.Items.Clear()
            BuscarUsuarios()
        End If
    End Sub


    Private Sub TxtCentros_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCentros.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            lvCentros.Items.Clear()
            buscarCen = 1
            BuscarBodegas()
        End If
    End Sub


    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            For i = lvCentros.Items.Count - 1 To 0 Step -1
                Dim color_fondo_ As Color = lvCentros.Items(i).BackColor
                If color_fondo_ <> Color.LightGray Then
                    lvCentros.Items.RemoveAt(i)
                End If
            Next
            btnEliminar.Enabled = True
        Else
            btnEliminar.Enabled = False
            lvCentros.Items.Clear()
            BuscarBodegas()
            BuscarBodegasUsuario(indx)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        For i = 0 To LvUsuarios.Items.Count - 1
            If LvUsuarios.Items(i).Checked = True Then
                usuario = LvUsuarios.Items(i).SubItems(2).Text.Trim
            End If
        Next
        If MsgBox("¿ DESEA REMOVER CENTROS SELECCIONADOS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        RemoverBodega()
        limpia()
    End Sub
    Private Sub RemoverBodega()
        Dim i As Integer = 0
        Dim n As Integer = 0
        n = lvCentros.Items.Count.ToString
        For i = 0 To n - 1

            Cursor.Current = Cursors.WaitCursor
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBodegas_EliminarAsignacion", con)
            Dim rdr As SqlDataReader = Nothing

            If lvCentros.Items(i).Checked = True Then
                cmd.CommandType = Data.CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@Usuario", usuario)
                cmd.Parameters.AddWithValue("@Bodega", lvCentros.Items(i).SubItems(2).Text.Trim)
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
                    Exit For
                Finally
                    con.Close()
                End Try

            End If
        Next
        MsgBox("Datos grabados con exito")

        ''si todo sale ok, retornamos ok

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub defa_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
        contdefault = 0

        For i = 0 To LvUsuarios.Items.Count - 1
            If LvUsuarios.Items(i).Checked = True Then
                usuario = LvUsuarios.Items(i).SubItems(2).Text.Trim
            End If

        Next

        For i = 0 To lvCentros.Items.Count - 1
            If lvCentros.Items(i).Checked = True Then
                contdefault = contdefault + 1
            End If
        Next

        If contdefault <> 1 Then
            Exit Sub
        End If
        If MsgBox("¿ DESEA GRABAR ASIGNACION DE CENTRO POR DEFAULT ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        Grabar()
        limpia()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtUsuario_TextChanged(sender As Object, e As EventArgs) Handles txtUsuario.TextChanged
        
    End Sub
End Class