Imports System.Data.SqlClient

Public Class FrmDecomisosIngreso

    Private Sub txtDIIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If cboCauDecomisos.SelectedIndex = -1 Then
                MsgBox("Debe Seleccionar una CAUSA.", MsgBoxStyle.Exclamation, "STOP")
                Exit Sub
            End If
            Call btnGrabar_Click(sender, e)
        End If
    End Sub

    Private decomiso_Cod As Integer
    Private decomiso_Nom As String = ""
    Private decomiso_Tip As String = ""
    Private Sub cboCauDecomisos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCauDecomisos.SelectedIndexChanged
        decomiso_Cod = General.CausasDecomisos.DecomisoCod(cboCauDecomisos.SelectedIndex)
        decomiso_Nom = cboCauDecomisos.Text.ToString.Trim
        decomiso_Tip = General.CausasDecomisos.DecomisoCateg(cboCauDecomisos.SelectedIndex)
        txtDIIO.Focus()
    End Sub

    Private Sub FrmDecomisosIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenaCausasDecomisosCbo()
        btnAsociarRespaldo.Enabled = False
        lblArchivosAsociados.Text = ""
    End Sub
    Private Sub LlenaCausasDecomisosCbo()
        If General.CausasDecomisos.NroRegistros = 0 Then Exit Sub

        cboCauDecomisos.Items.Clear()
        'cboEstanques.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CausasDecomisos.NroRegistros - 1
            cboCauDecomisos.Items.Add(General.CausasDecomisos.DecomisoNom(i))
        Next
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        GrabarDatosListView()
    End Sub

    Private Sub GrabarDatosListView()
        If GrabaDecomiso_BD_ListView() = True Then

        End If
    End Sub

    Private contadorListView As Integer = 0
    Private contadorListViewFiles As Integer = 0

    Private Function GrabaDecomiso_BD_ListView() As Boolean
        GrabaDecomiso_BD_ListView = False
        'Recupera el indice del Combo Box
        Dim IndiceCbo As Integer = cboCauDecomisos.SelectedIndex

        Dim Diio_ As String = ""
        Dim fecha_ As String = ""

        Diio_ = txtDIIO.Text.ToString.Trim
        fecha_ = Format(dtpFecha.Value, "dd-MM-yyyy")

        'Verifica si el Diio esta Vendido
        If BuscaInfoArete(Diio_) = False Then
            MsgBox("No hay informacion asociada al Numero Digitado. Favor, revise el Numero del Arete.", MsgBoxStyle.Exclamation, "ERROR")
            Exit Function
        End If

        'Verificar si el Diio esta en el ListView
        If VerificaDatoEnListView(Diio_) = True Then
            MsgBox("Los datos a ingresar ya se encuentran grabados. Seleccione otro Diio.", MsgBoxStyle.Exclamation, "ERROR")
            Exit Function
        End If


        '######### AQUI COMIENZA GRABADO EN BASE DE DATOS ######## 
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_Grabar", con)
        Dim rdr As SqlDataReader = Nothing
        Dim ValorRsp As Integer
        Dim TextMsg As String = ""
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Fecha", fecha_)
        cmd.Parameters.AddWithValue("@Diio", Diio_)
        cmd.Parameters.AddWithValue("@CategCod", CategoriaCod)
        cmd.Parameters.AddWithValue("@DecomisoCod", decomiso_Cod)
        cmd.Parameters.AddWithValue("@VentaFecha", FechaVta)
        cmd.Parameters.AddWithValue("@CenCod", CenCod)
        cmd.Parameters.AddWithValue("@User", LoginUsuario)
        cmd.Parameters.AddWithValue("@UserPC", NombrePC)
        cmd.Parameters.AddWithValue("@UserFechaReg", Now())
        '
        cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            ValorRsp = cmd.Parameters("@RespValor").Value
            TextMsg = cmd.Parameters("@RespMsg").Value
            If ValorRsp > 0 Then
                MsgBox(TextMsg, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                con.Close()
                Exit Function
            End If


            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            con.Close()
        End Try
        '######### AQUI COMIENZA GRABADO EN LIST VIEW ######## 
        Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

        item.SubItems.Add(Empresa) 'Columna Empresa
        item.SubItems.Add(Str(contadorListView + 1)) 'Columna Linea
        item.SubItems.Add(Diio_) 'Columna Diio
        item.SubItems.Add(fecha_) 'Fecha del Registro
        item.SubItems.Add(CenCod) 'CenCod
        item.SubItems.Add(CenNom) 'CenNom
        item.SubItems.Add(CategoriaCod) 'Categoria Cod
        item.SubItems.Add(CategoriaNom) 'Categoria Nom
        item.SubItems.Add(FechaVta) 'Fecha de Venta
        item.SubItems.Add(decomiso_Cod) 'Decomiso Cod
        item.SubItems.Add(decomiso_Nom) 'Decomiso Nom
        item.SubItems.Add(decomiso_Tip) 'Decomiso Tipo
        item.SubItems.Add(TextMsg) 'Columna Estado

        lvDecomisos.Items.Add(item) 'Agrega los Items 
        contadorListView = contadorListView + 1
        txtDIIO.Text = ""
        txtDIIO.Focus()
        btnAsociarRespaldo.Enabled = True
        GrabaDecomiso_BD_ListView = True
    End Function

    Private Function VerificaDatoEnListView(ByVal Arete_ As String) As Boolean
        'VerificaDatoEnListView = False
        Dim _existe As Boolean = False
        Dim ValorCelda As String = ""
        For lin = 0 To lvDecomisos.Items.Count - 1 And _existe = False
            ValorCelda = lvDecomisos.Items(lin).SubItems(3).Text.ToString.Trim
            If ValorCelda = Arete_ Then
                lvDecomisos.Items(lin).BackColor = System.Drawing.Color.Goldenrod
                _existe = True
            End If
        Next
        VerificaDatoEnListView = _existe
    End Function


    Private FechaVta As String = ""
    Private CenCod As String = ""
    Private CenNom As String = ""
    Private CategoriaCod As String = ""
    Private CategoriaNom As String = ""


    Private Function BuscaInfoArete(ByVal Arete_ As String) As Boolean
        'VerificaDiioEnVentas = True
        Dim _existe As Boolean = False
        Dim ValMsg As Integer
        Dim TxtMsg As String = ""
        FechaVta = ""
        CenCod = ""
        CenNom = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBuscaInfoAnimal", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", Arete_)

        cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                ValMsg = cmd.Parameters("@RespValor").Value
                TxtMsg = cmd.Parameters("@RespMsg").Value
                If ValMsg = 0 Then
                    _existe = True 'Hay informacion
                End If
                While rdr.Read()
                    CenCod = rdr("CenCod").ToString.Trim
                    CenNom = rdr("CenNom").ToString.Trim
                    CategoriaCod = rdr("CategoCod").ToString.Trim
                    CategoriaNom = rdr("CategoNom").ToString.Trim
                    FechaVta = rdr("FechaVTA").ToString.Trim
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try


        BuscaInfoArete = _existe
    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lvDecomisos.Items.Count = 0 Then Exit Sub
        If lvDecomisos.SelectedItems.Count = 0 Then Exit Sub

        Dim Diio_ As String = lvDecomisos.SelectedItems.Item(0).SubItems(3).Text()

        If MsgBox("¿Desea Eliminar el REGISTRO.?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarDecomiso(Diio_) = True Then
            If MsgBox("Eliminación realizada con exito.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
        End If
    End Sub

    Private Function EliminarDecomiso(ByVal Arete_ As String) As Boolean
        EliminarDecomiso = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", Arete_)


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
            lvDecomisos.Items.Remove(lvDecomisos.SelectedItems(0))
            EliminarDecomiso = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub pbReLoadCausas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbReLoadCausas.Click
        General.CausasDecomisos.Cargar()
        LlenaCausasDecomisosCbo()
    End Sub



    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        lvDecomisos.Items.Clear()
        lvArchivosAsoc.Items.Clear()
        contadorListView = 0
        contadorListViewFiles = 0
        '1.-Verificar si existen datos en esa fecha
        Dim fechaSeleccionada = Format(dtpFecha.Value, "dd-MM-yyyy 00:00:00")
        If ConsultaDatosFechaSel(fechaSeleccionada) = True Then
            btnAsociarRespaldo.Enabled = True
        End If
        ConsultaDatosFechaSelArchivos()
        txtDIIO.Focus()
    End Sub

    Private Function ConsultaDatosFechaSel(ByVal fecha_ As String) As Boolean
        Dim _existe As Boolean = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_ConsultaDatos_FechaSel", con)
        Dim rdr As SqlDataReader = Nothing
        Dim ValMsg As Integer
        Dim TxtMsg As String
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@FechaDec", fecha_)

        cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                ValMsg = cmd.Parameters("@RespValor").Value
                TxtMsg = cmd.Parameters("@RespMsg").Value
                If ValMsg = 0 Then
                    _existe = True 'Hay informacion
                End If
                While rdr.Read()

                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos
                    contadorListView = contadorListView + 1
                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim) 'Columna Empresa
                    item.SubItems.Add(Str(contadorListView)) 'Columna Linea
                    item.SubItems.Add(rdr("Diio").ToString.Trim) 'Columna Diio
                    item.SubItems.Add(rdr("DecomisoFecha").ToString.Trim) 'Fecha del Registro
                    item.SubItems.Add(rdr("VDetCentro").ToString.Trim) 'CenCod
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim) 'CenNom
                    item.SubItems.Add(rdr("CategoCod").ToString.Trim) 'Categoria Cod
                    item.SubItems.Add(rdr("Categoria").ToString.Trim) 'Categoria Nom
                    item.SubItems.Add(rdr("VtaFecha").ToString.Trim) 'Fecha de Venta
                    item.SubItems.Add(rdr("CausaCodDec").ToString.Trim) 'Decomiso Cod
                    item.SubItems.Add(rdr("CauNombre").ToString.Trim) 'Decomiso Nom
                    item.SubItems.Add(rdr("CategoriaDecomiso").ToString.Trim) 'Decomiso Tipo
                    item.SubItems.Add(TxtMsg) 'Columna Estado

                    lvDecomisos.Items.Add(item) 'Agrega los Items

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
        ConsultaDatosFechaSel = _existe
    End Function

    Private Sub ConsultaDatosFechaSelArchivos()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_ConsultaDatos_FechaSel_Files", con)
        Dim rdr As SqlDataReader = Nothing
        Dim ValMsg As Integer
        Dim TxtMsg As String
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@FechaDec", Format(dtpFecha.Value, "dd-MM-yyyy 00:00:00"))

        cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                ValMsg = cmd.Parameters("@RespValor").Value
                TxtMsg = cmd.Parameters("@RespMsg").Value
                If ValMsg > 0 Then
                    'NO HAY INFORMACION ASOCIADA
                    lblArchivosAsociados.Text = TxtMsg
                    Exit Sub
                End If
                lblArchivosAsociados.Text = ""
                While rdr.Read()

                    '######### AQUI COMIENZA GRABADO EN LIST VIEW DE LOS ARCHIVOS ASOCIADOS ######## 
                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos
                    contadorListViewFiles = contadorListViewFiles + 1
                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim) 'Columna Empresa
                    item.SubItems.Add(Str(contadorListViewFiles)) 'Columna Linea
                    item.SubItems.Add(rdr("CodFile").ToString.Trim) 'Columna Linea
                    item.SubItems.Add(rdr("NomFile").ToString.Trim) 'Columna Nombre del Archivo

                    lvArchivosAsoc.Items.Add(item) 'Agrega los Items 

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
    End Sub

    'Boton que asocia el Respado al dia Seleccionado. Guarda en la Red, creando una carpeta con el Año Mes
    Private Sub btnAsociarRespaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsociarRespaldo.Click
        Dim MesAño_ As String = Format(dtpFecha.Value, "MM-yyyy")
        Dim RutaDestino As String = "\\fileserver\Cert_Decomisos"
        Dim openFileDialog_ As New OpenFileDialog
        Dim fileName_ As String
        Dim strArchivo As String
        Dim CarpetaDestino As String = MesAño_ 'debe ser mes y año
        Dim RutaCompletaGrabaArchivo As String = RutaDestino + "\" + CarpetaDestino
        Dim Ruta_Archivo_Grabado As String = ""
        Dim newCodFileBD As Integer
        If Not IO.Directory.Exists(RutaCompletaGrabaArchivo) Then
            'Dim carpeta As String = My.Computer.FileSystem.SpecialDirectories.ProgramFiles + "\"
            My.Computer.FileSystem.CreateDirectory(RutaCompletaGrabaArchivo)
        End If


        openFileDialog_.Filter = "Archivos PDF (*.pdf)|*.pdf"
        openFileDialog_.RestoreDirectory = True
        If openFileDialog_.ShowDialog() = Windows.Forms.DialogResult.OK Then
            fileName_ = openFileDialog_.FileName
            Dim i As Integer ' índice de la última aparición de
            i = openFileDialog_.FileName.LastIndexOf("\")
            strArchivo = openFileDialog_.FileName.Substring(i + 1)
            Try
                My.Computer.FileSystem.CopyFile(fileName_, RutaCompletaGrabaArchivo + "\" + strArchivo, FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
                Ruta_Archivo_Grabado = RutaCompletaGrabaArchivo + "\" + strArchivo
                '######### AQUI COMIENZA GRABADO EN BASE DE DATOS DE LOS ARCHIVOS ASOCIADOS ######## 
                Dim con As New SqlConnection(GetConnectionString())
                Dim cmd As New SqlCommand("spDecomisos_GrabarNomFile", con)
                Dim rdr As SqlDataReader = Nothing
                Dim ValorRsp As Integer
                Dim TextMsg As String = ""
                cmd.CommandType = Data.CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@Empresa", Empresa)
                cmd.Parameters.AddWithValue("@Fecha", Format(dtpFecha.Value, "dd-MM-yyyy"))
                cmd.Parameters.AddWithValue("@NombreArchivo", Ruta_Archivo_Grabado)
                cmd.Parameters.AddWithValue("@User", LoginUsuario)
                cmd.Parameters.AddWithValue("@UserPC", NombrePC)
                cmd.Parameters.AddWithValue("@UserFechaReg", Now())
                cmd.Parameters.Add("@newCod", SqlDbType.Int) : cmd.Parameters("@newCod").Direction = ParameterDirection.Output
                cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
                cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

                Try
                    con.Open()

                    Dim Result As Integer = cmd.ExecuteNonQuery()

                    ValorRsp = cmd.Parameters("@RespValor").Value
                    TextMsg = cmd.Parameters("@RespMsg").Value
                    newCodFileBD = cmd.Parameters("@newCod").Value
                    If ValorRsp > 0 Then
                        MsgBox(TextMsg, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                        con.Close()
                        Exit Sub
                    End If
                    con.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                    con.Close()
                End Try
                '######### AQUI COMIENZA GRABADO EN LIST VIEW DE LOS ARCHIVOS ASOCIADOS ######## 
                Dim item As New ListViewItem("")    'primera columna, para ordenar los datos
                contadorListViewFiles = contadorListViewFiles + 1
                item.SubItems.Add(Empresa) 'Columna Empresa
                item.SubItems.Add(Str(contadorListViewFiles)) 'Columna Linea
                item.SubItems.Add(Str(newCodFileBD)) 'Columna Linea
                item.SubItems.Add(Ruta_Archivo_Grabado) 'Columna Nombre del Archivo

                lvArchivosAsoc.Items.Add(item) 'Agrega los Items 


                MsgBox("Archivo Grabado con Exito.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SAVED FILE")
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub

    Private Sub lvArchivosAsoc_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvArchivosAsoc.MouseDoubleClick
        If lvArchivosAsoc.Items.Count = 0 Then Exit Sub
        If e.Button = MouseButtons.Left = True Then
            OpenNomFile = lvArchivosAsoc.SelectedItems.Item(0).SubItems(4).Text
            Process.Start(OpenNomFile)
        End If
    End Sub


    Private OpenNomFile As String

End Class