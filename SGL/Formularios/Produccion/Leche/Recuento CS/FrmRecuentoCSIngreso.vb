Imports System.Data.SqlClient

Public Class frmRCSIngreso

    Private Sub frmRCSIngreso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub



    'Private Sub txtCantRCS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCantRCS.LostFocus
    '    If IsNumeric(txtCantRCS.Text.Trim) = False Then
    '        MsgBox("GGGG")
    '    End If
    'End Sub

    Private Sub frmRCSIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CboLlenaEstanques()
        contadorListView = 0
        txtCantRCS.Enabled = False
        btnGrabar.Enabled = False
        txtCantRCS.Text = ""


    End Sub

    Private Sub CboLlenaEstanques(Optional ByVal centroNomCbo As Boolean = False)
        If General.CentrosUsuarioEstanque.NroRegistros = 0 Then Exit Sub

        cboEstanques.Items.Clear()
        'cboEstanques.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuarioEstanque.NroRegistros - 1
            If General.CentrosUsuarioEstanque.CentroTipo(i) = "SALA" And General.CentrosUsuarioEstanque.CentroVig(i) = "SI" And General.CentrosUsuarioEstanque.EstanqueCOD(i) <> "" Then
                cboEstanques.Items.Add(General.CentrosUsuarioEstanque.EstanqueNOM(i))
            End If
        Next
        cboEstanques.SelectedIndex = 0
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        GrabarDatosListView()
    End Sub

    Private Sub btnGrabar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles btnGrabar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            GrabarDatosListView()
        End If
    End Sub

    Public Sub GrabarDatosListView()
        If GabraRCS_ListView() = True Then
            btnFinalizar.Enabled = True
        End If
    End Sub

    Public contadorListView As Integer = 0


    Private Sub EnviaEmail()
        ''SP ENVIA EMAIL''
        Dim estanque_Cod As String = ""
        Dim estanque_Nom As String = ""
        Dim cant_ As String = "0"
        Dim fecha_ As String = ""
        cant_ = txtCantRCS.Text.ToString.Trim
        estanque_Nom = cboEstanques.Text.ToString.Trim
        estanque_Cod = General.CentrosUsuarioEstanque.EstanqueCOD(cboEstanques.SelectedIndex)
        fecha_ = Format(dtpFecha.Value, "dd-MM-yyyy")

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_Mail", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@CentroRSC", estanque_Cod)
        cmd.Parameters.AddWithValue("@CentroRSCCod", estanque_Nom)
        cmd.Parameters.AddWithValue("@Fecha", fecha_)
        cmd.Parameters.AddWithValue("@Cantidad", cant_)
        cmd.Parameters.AddWithValue("@User", LoginUsuario)
        cmd.Parameters.AddWithValue("@UserPC", NombrePC)

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR ENVIA EMAIL")
        Finally
            con.Close()
        End Try
    End Sub
    Public Function GabraRCS_ListView() As Boolean
        GabraRCS_ListView = False
        'Recupera el indice del Combo Box
        Dim IndiceCbo As Integer = cboEstanques.SelectedIndex

        Dim estanque_Cod As String = ""
        Dim estanque_Nom As String = ""
        Dim cant_ As String = "0"
        Dim fecha_ As String = ""

        estanque_Nom = cboEstanques.Text.ToString.Trim
        estanque_Cod = General.CentrosUsuarioEstanque.EstanqueCOD(cboEstanques.SelectedIndex)
        cant_ = txtCantRCS.Text.ToString.Trim
        If cant_ = "" Then
            cant_ = "0"
        End If
        fecha_ = Format(dtpFecha.Value, "dd-MM-yyyy")

        If VerificaDatoEnListView(estanque_Cod) = True Then
            MsgBox("Los datos a ingresar ya se encuentran grabados. Seleccione otro Estanque.", MsgBoxStyle.Exclamation, "ERROR")
            Exit Function
        End If


        Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

        item.SubItems.Add(("").ToString.Trim) 'Columna Empresa
        item.SubItems.Add(Str(contadorListView + 1)) 'Columna Linea
        item.SubItems.Add(estanque_Cod) 'Columna EstanqueCod
        item.SubItems.Add(estanque_Nom) 'Columna EstanqueNom
        item.SubItems.Add(fecha_) 'Fecha 
        item.SubItems.Add(cant_) 'Cantidad
        If cant_ >= 300 Then
            EnviaEmail()
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CentroRSC", estanque_Cod)
        cmd.Parameters.AddWithValue("@Fecha", fecha_)
        cmd.Parameters.AddWithValue("@Cantidad", cant_)
        cmd.Parameters.AddWithValue("@TipoInput", "MANUAL")
        cmd.Parameters.AddWithValue("@User", LoginUsuario)
        cmd.Parameters.AddWithValue("@UserPC", NombrePC)
        cmd.Parameters.AddWithValue("@UserFechaReg", Now())
        '
        cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RespValor").Value
            Dim mret As String = cmd.Parameters("@RespMsg").Value

            item.SubItems.Add(mret) 'Columna Estado

            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            con.Close()
        End Try

        lvRCSInput.Items.Add(item) 'Agrega los Items
        If IndiceCbo < cboEstanques.Items.Count - 1 Then
            cboEstanques.SelectedIndex = IndiceCbo + 1
        End If
        contadorListView = contadorListView + 1
        txtCantRCS.Text = ""
        txtCantRCS.Focus()
        GabraRCS_ListView = True

    End Function

    Private Function VerificaDatoEnListView(ByVal Cod_ As String) As Boolean
        'VerificaDatoEnListView = False
        Dim _existe As Boolean = False
        Dim ValorCelda As String = ""
        For lin = 0 To lvRCSInput.Items.Count - 1 And _existe = False
            ValorCelda = lvRCSInput.Items(lin).SubItems(3).Text.ToString.Trim
            If ValorCelda = Cod_ Then
                lvRCSInput.Items(lin).BackColor = System.Drawing.Color.Goldenrod
                _existe = True
            End If
        Next
        VerificaDatoEnListView = _existe
    End Function


    Private Sub cboEstanques_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstanques.SelectedIndexChanged
        'If cboEstanques.SelectedIndex = -1 Then Exit Sub

        If cboEstanques.Text.Trim <> "" Then
            txtCantRCS.Enabled = True
            txtCantRCS.Text = ""
            txtCantRCS.Focus()
            btnGrabar.Enabled = True
        Else
            txtCantRCS.Enabled = False
            btnGrabar.Enabled = False
        End If

    End Sub

    Private Sub txtCantRCS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantRCS.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnGrabar_Click(sender, e)
            'btnGrabar.Focus()
        Else
            If InStr(1, "0123456789,-" & Chr(8), e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub

    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        Limpiar()
        'CONFIRMAR
        'If MsgBox("¿ Dese Finalizar la Transaccion ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        '    Exit Sub
        'End If
        'If GrabarRCS_BD() = True Then
        '    If MsgBox("Datos Grabados con Exito.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
        '    End If

        'End If

    End Sub

    Private Function GrabarRCS_BD() As Boolean
        GrabarRCS_BD = False


        GrabarRCS_BD = True

    End Function

    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub frmRCSIngreso_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        dtpFecha.Focus()
    End Sub

    Private Sub dtpFecha_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.TextChanged
        Limpiar()
        '1.-Verificar si existen datos en esa fecha
        Dim fechaSeleccionada = Format(dtpFecha.Value, "dd-MM-yyyy 00:00:00")
        If ConsultaDatosFechaSel(fechaSeleccionada) = False Then
            'No Existe datos para la fecha Seleccionada
        End If
        txtCantRCS.Enabled = True
        txtCantRCS.Focus()
    End Sub

    Private Sub Limpiar()
        contadorListView = 0
        dtpFecha.Focus()
        cboEstanques.SelectedIndex = 0
        'cboEstanques.Focus()
        txtCantRCS.Text = ""
        'txtCantRCS.Focus()
        txtCantRCS.Enabled = False
        lvRCSInput.Items.Clear()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lvRCSInput.Items.Count = 0 Then Exit Sub
        If lvRCSInput.SelectedItems.Count = 0 Then Exit Sub

        Dim Cod_Estanque_ As String = lvRCSInput.SelectedItems.Item(0).SubItems(3).Text()
        Dim Fecha_Reg_ As String = lvRCSInput.SelectedItems.Item(0).SubItems(5).Text()

        If MsgBox("¿Desea Eliminar el Dato?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarRCS(Cod_Estanque_, Fecha_Reg_) = True Then
            If MsgBox("Eliminacion realizada con exito.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
        End If
    End Sub

    Private Function EliminarRCS(ByVal Codigo_ As String, ByVal fecha_ As String) As Boolean
        EliminarRCS = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CentroRSC", Codigo_)
        cmd.Parameters.AddWithValue("@Fecha", fecha_)

        cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RespValor").Value
            Dim mret As String = cmd.Parameters("@RespMsg").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If
            'Elimina la fila seleccionada
            lvRCSInput.Items.Remove(lvRCSInput.SelectedItems(0))
            EliminarRCS = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Function ConsultaDatosFechaSel(ByVal FecSel_ As String) As Boolean
        Dim ExistenDatos As Boolean = True
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_ConsultaDatos_FechaSel", con)
        Dim rdr As SqlDataReader = Nothing
        Dim ValMsg As Integer
        Dim TxtMsg As String
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@FechaRCS", FecSel_)

        cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                ValMsg = cmd.Parameters("@RespValor").Value
                TxtMsg = cmd.Parameters("@RespMsg").Value
                If ValMsg = 1 Then
                    'NO Hay informacion
                    ConsultaDatosFechaSel = False
                    Exit Function
                End If

                While rdr.Read()

                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos
                    contadorListView = contadorListView + 1
                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim) 'Columna Empresa
                    item.SubItems.Add(Str(contadorListView)) 'Columna Linea
                    item.SubItems.Add(rdr("EstanqueCod").ToString.Trim) 'Columna Estanque Cod
                    item.SubItems.Add(rdr("EstanqueNom").ToString.Trim) 'Columna Estanque Nom
                    item.SubItems.Add(rdr("RCSFecha").ToString.Trim) 'Columna Fecha RCS
                    item.SubItems.Add(rdr("RCSCantidad").ToString.Trim) 'Columna Cantidad
                    item.SubItems.Add(TxtMsg) 'Columna Estado --> Consulta.

                    lvRCSInput.Items.Add(item) 'Agrega los Items

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
        ConsultaDatosFechaSel = ExistenDatos
    End Function
End Class