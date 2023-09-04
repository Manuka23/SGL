Imports System.Data.SqlClient

Public Class frmCambioDeDiiosIngreso


    Private Sub frmCambioDeDiiosIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CboLLenaCentros()
    End Sub

    Private Sub txtDiioAnt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiioAnt.LostFocus
        If txtDiioAnt.Text = "" Then
            Exit Sub
        End If

        If ValidacionesDiioOld() = True Then
            txtDiioNuevo.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub txtDiioNuevo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiioNuevo.KeyPress, txtDiioAnt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If txtDiioNuevo.Text = "" Then
                MsgBox("NO puede dejar en blanco el campo 'Diio Nuevo'.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia - Diio en Blanco.")
            Else
                If ValidacionesDiioNew() = True Then
                    AgregaDatosListView(txtDiioAnt.Text.Trim, txtDiioNuevo.Text.Trim)
                End If
            End If
        End If

    End Sub

    Private Function ValidacionesDiioOld() As Boolean
        If txtDiioAnt.Text = "" Then
            ValidacionesDiioOld = False
            Exit Function
        End If

        ValidacionesDiioOld = False
        If dtpFecha.Value > Now() Then
            MsgBox("NO pude seleccionar una fecha mayor a la actual.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia - Fecha.")
            dtpFecha.Value = Now()
            Exit Function
        End If
        If ValidaDiioAnt(txtDiioAnt.Text) = True Then
            If BuscaDiioEnListView(txtDiioAnt.Text) = False Then
                ValidacionesDiioOld = True
            Else
                MsgBox("El Diio que intenta Ingresar, ya se encuentra en los registros a procesar.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Advertencia - Duplicidad de Datos.")
            End If
        End If
    End Function

    Private Function ValidacionesDiioNew() As Boolean
        ValidacionesDiioNew = False
        If dtpFecha.Value > Now() Then
            MsgBox("NO pude seleccionar una fecha mayor a la actual.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia - Fecha.")
            dtpFecha.Value = Now()
            Exit Function
        End If
        If ValidaDiioNuevo(txtDiioNuevo.Text) = False Then 'No debe Existir en la BD. Debe ser FALSO
            If BuscaDiioEnListView(txtDiioNuevo.Text) = False Then
                ValidacionesDiioNew = True
            Else
                MsgBox("El Diio que intenta Ingresar, ya se encuentra en los registrosa a procesar.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Advertencia - Duplicidad de Datos.")
            End If
        End If
    End Function

    'Validacion del Diio Antiguo vs Informacion de la Base de Datos.
    Private Function ValidaDiioAnt(ByVal diio_ As String) As Boolean
        ValidaDiioAnt = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", diio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()

                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                        If MsgBox("EL CENTRO DEL ANIMAL (" + rdr("CenDesCor").ToString.Trim + ") NO CORRESPONDE CON EL SELECCIONADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    ValidaDiioAnt = True
                    Existe = True
                End While

                If Existe = False Then
                    ValidaDiioAnt = False
                    MsgBox("EL DIIO INGRESADO (" + diio_ + ") NO EXISTE")
                    Exit Function
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Function

    'Validacion del Diio Nuevo vs Informacion de la Base de Datos.
    Private Function ValidaDiioNuevo(ByVal diio_ As String) As Boolean
        ValidaDiioNuevo = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", diio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                If rdr.HasRows = True Then
                    While rdr.Read()
                        If rdr("GndCod").ToString.Trim <> "" Then
                            If MsgBox("EL ANIMAL YA EXISTE EN LA BASE DE DATOS. VERIFIQUE LA NUMERACION.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR") = vbOK Then
                            End If
                            Exit Try
                        End If
                        ValidaDiioNuevo = True
                        Existe = True
                    End While
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Function

    Private Function BuscaDiioEnListView(ByVal diio_ As String) As Boolean
        BuscaDiioEnListView = False
        Dim ValorDiioAnt As String = ""
        Dim ValorDiioNuevo As String = ""
        For lin = 0 To lvCambioDiios.Items.Count - 1
            ValorDiioAnt = lvCambioDiios.Items(lin).SubItems(3).Text.ToString.Trim
            ValorDiioNuevo = lvCambioDiios.Items(lin).SubItems(4).Text.ToString.Trim
            If ValorDiioAnt = diio_ Or ValorDiioNuevo = diio_ Then
                lvCambioDiios.Items(lin).BackColor = System.Drawing.Color.Yellow
                BuscaDiioEnListView = True
            End If
        Next
    End Function


    Public cenCod_ As String = ""
    Public fecha_ As String = ""
    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If dtpFecha.Value > Now() Then
            MsgBox("NO pude seleccionar una fecha mayor a la actual.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia - Fecha.")
            dtpFecha.Value = Now()
            Exit Sub
        End If
        If ValidacionesDiioOld() = True Then
            txtDiioNuevo.Focus()
        Else
            'txtDiioAnt.Text = ""
            txtDiioAnt.Focus()
            Exit Sub
        End If
        If txtDiioNuevo.Text = "" Then
            MsgBox("NO puede dejar en blanco el campo 'Diio Nuevo'.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia - Diio en Blanco.")
            Exit Sub
        Else
            If ValidacionesDiioNew() = True Then
                AgregaDatosListView(txtDiioAnt.Text.TrimStart("0"), txtDiioNuevo.Text.TrimStart("0"))
            End If
        End If


    End Sub

    Public contadorListView As Integer = 0
    Private Sub AgregaDatosListView(ByVal diioAnt_ As String, ByVal diioNuevo As String)
        Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

        item.SubItems.Add(("").ToString.Trim) 'Columna Empresa
        item.SubItems.Add(Str(lvCambioDiios.Items.Count + 1)) 'Columna Linea
        item.SubItems.Add(diioAnt_) 'Columna Diio Anterior
        item.SubItems.Add(diioNuevo) 'Columna Diio Nuevo
        item.SubItems.Add(txtObs.Text) 'Columna Observacion
        item.SubItems.Add("") 'estado
        lvCambioDiios.Items.Add(item) 'Agrega los Items
        txtDiioAnt.Text = ""
        txtDiioNuevo.Text = ""
        txtDiioAnt.Focus()
        'Variables Publicas - Fecha y Centro para usar en cualquier momento.
        fecha_ = Format(dtpFecha.Value, "dd-MM-yyyy 00:00:00.00")
        cenCod_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        'Deshabilitar la fecha y el Centro para que solo sea cambiado cuando finalicen 
        dtpFecha.Enabled = False
        cboCentros.Enabled = False
        btnFinalizar.Enabled = True
        btnEliminar.Enabled = True
    End Sub

    'Boton Finalizar - Graba todos los datos en la BD
    Private Sub btnFinalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If lvCambioDiios.Items.Count = 0 Then
            MsgBox("No existen datos para Grabar.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Advertencia")
            Exit Sub
        End If

        Dim validaGrabacion As Integer = 1
        Cursor.Current = Cursors.WaitCursor
        For lin = 0 To lvCambioDiios.Items.Count - 1 'And validaGrabacion = 0
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spCambioDeDiios_Grabar", con)
            Dim rdr As SqlDataReader = Nothing
            cmd.CommandTimeout = 500
            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@CentroCod", cenCod_)
            cmd.Parameters.AddWithValue("@FechaCambio", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@Arete_Anterior", lvCambioDiios.Items(lin).SubItems(3).Text.ToString.Trim)
            cmd.Parameters.AddWithValue("@Arete_Nuevo", lvCambioDiios.Items(lin).SubItems(4).Text.ToString.Trim)
            cmd.Parameters.AddWithValue("@Observacion", lvCambioDiios.Items(lin).SubItems(5).Text.ToString.Trim)
            cmd.Parameters.AddWithValue("@User", LoginUsuario)
            cmd.Parameters.AddWithValue("@UserPC", NombrePC)
            'cmd.Parameters.AddWithValue("@UserFechaReg", Now())
            '
            cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

            'Dim item As New ListViewItem("")

            Try
                con.Open()

                Dim Result As Integer = cmd.ExecuteNonQuery()

                Dim vret As Integer = cmd.Parameters("@RetValor").Value
                Dim mret As String = cmd.Parameters("@RetMensage").Value

                If vret = 0 Then
                    'MsgBox(mret, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR AL GRABAR DATOS")
                    'validaGrabacion = 1 'No sigue grabando
                    lvCambioDiios.Items(lin).BackColor = System.Drawing.Color.Red
                    lvCambioDiios.Items(lin).ForeColor = Color.White
                    lvCambioDiios.Items(lin).SubItems(6).Text = mret

                    'Dim StringSize As New SizeF
                    'StringSize = TextRenderer.MeasureText(mret, lvCambioDiios.Font)
                    'lvCambioDiios.Columns(6).Width = StringSize.Width

                    validaGrabacion = 0
                End If
                'item.SubItems.Add(Empresa)
                'item.SubItems.Add(lin)
                'item.SubItems.Add(lvCambioDiios.Items(lin).SubItems(3).Text.ToString.Trim)
                'item.SubItems.Add(lvCambioDiios.Items(lin).SubItems(3).Text.ToString.Trim)
                'item.SubItems.Add(txtObs.Text)
                'item.SubItems.Add(mret) 'Columna Estado
                'lvCambioDiios.Items(lin).SubItems(6).Text = mret 'Columna Estado

                'lvCambioDiios.Items.Add(item)
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                con.Close()
            End Try
        Next
        If validaGrabacion = 1 Then
            MsgBox("El proceso a finalizado Satisfactoriamente.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FINALIZAR - OK")
            Me.Close()
        Else
            MsgBox("El proceso a terminado con Errores. Revisar el error en la columna ESTADO.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FINALIZAR - CON ERRORES")
        End If
        btnFinalizar.Enabled = False
        btnEliminar.Enabled = False
        dtpFecha.Enabled = True
        cboCentros.Enabled = True
        frmCambioDeDiios.MostrarDatosLV()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lvCambioDiios.Items.Count = 0 Then Exit Sub
        If lvCambioDiios.SelectedItems.Count = 0 Then Exit Sub

        Dim DiioOld_ As String = lvCambioDiios.SelectedItems.Item(0).SubItems(3).Text()
        Dim DiioNew_ As String = lvCambioDiios.SelectedItems.Item(0).SubItems(4).Text()

        If MsgBox("¿Desea Eliminar el Cambio de Diio Seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarCambioDiioListView(DiioOld_, DiioNew_) = True Then
            If MsgBox("Eliminacion realizada con exito.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
        End If
    End Sub

    Private Function EliminarCambioDiioListView(ByVal DiioAnt_ As String, ByVal DiioNew_ As String) As Boolean
        EliminarCambioDiioListView = False
        
        'Elimina la fila seleccionada
        lvCambioDiios.Items.Remove(lvCambioDiios.SelectedItems(0))
        EliminarCambioDiioListView = True

    End Function




End Class