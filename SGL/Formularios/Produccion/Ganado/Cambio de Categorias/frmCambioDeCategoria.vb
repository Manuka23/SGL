Imports System.Data.SqlClient

Public Class frmCambioDeCategoriaCargaMasiva

    Private Sub frmCambioDeCategorias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Categorias.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        Dim FechaIniMes As String = "01-" + Format(dtpFechaDesde.Value, "dd-MM-yyyy").Substring(3)
        dtpFechaDesde.Value = FechaIniMes

        CboLLenaCentros()
        CboLlenaCategorias()

        ToolTipText()
    End Sub
    Private Sub ToolTipText()
        Dim Textreprocesa As String
        Textreprocesa = "Cambio por Sexo (De Ternera a Ternero y Viceversa) ”

        ToolTip1.SetToolTip(btnAgregar, Textreprocesa)
        ToolTip1.SetToolTip(Button1, "Cambio por Fecha de Nacimiento (Terneras – Vaquillas – Terneros – Toretes)")
        ToolTip1.SetToolTip(Button2, "Cambio para Ganado Adulto, Vacas a Vacas Otoño o Vacas Traspaso (Viceversa)")
    End Sub

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub

    Private Sub CboLlenaCategorias()
        If General.Categorias.NroRegistros = 0 Then Exit Sub

        cboCatInicial.Items.Clear()
        cboCatInicial.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Categorias.NroRegistros - 1
            cboCatInicial.Items.Add(General.Categorias.Nombre(i))
        Next
        cboCatInicial.SelectedIndex = 0
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        MostrarDatosLV()
    End Sub

    Public Sub MostrarDatosLV()
        Dim cent_ As String = ""
        Dim categ_ As String = ""
        Dim vet_ As Integer = 0
        Dim causa_ As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If
        If cboCatInicial.SelectedIndex <> -1 And cboCatInicial.Text <> "(TODOS)" Then
            categ_ = General.Categorias.Codigo(cboCatInicial.SelectedIndex - 1)
        End If

        'If CadenaOrden = "" Then
        '    CadenaOrden = "CenDesCor"
        '    lblOrdena.Text = "Centro"
        '    lblOrdena.Refresh()
        'End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaCambiosCategorias(cent_, categ_, txtDIIO.Text.Trim)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ConsultaCambiosCategorias(ByVal centro_ As String, ByVal categoria_ As String, Optional ByVal diio_ As String = "")

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCambioDeCategorias_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing
        Dim NroRegs As Integer = 0
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@FechaDesde", Format(dtpFechaDesde.Value, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@FechaHasta", Format(dtpFechaHasta.Value, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        cmd.Parameters.AddWithValue("@Categoria", categoria_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvCambioCategorias.BeginUpdate()
        lvCambioCategorias.Items.Clear()

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    If NroRegs = 0 Then
                        NroRegs = rdr("CountRegs")
                        pbProcesa.Maximum = NroRegs
                    End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)
                    item.SubItems.Add(rdr("Centro").ToString.Trim)
                    item.SubItems.Add(Format(rdr("FechaCambio"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("CategoCodOri").ToString.Trim)
                    item.SubItems.Add(rdr("CategOrigen").ToString.Trim)
                    item.SubItems.Add(rdr("CategoCodDes").ToString.Trim)
                    item.SubItems.Add(rdr("CategDestino").ToString.Trim)
                    item.SubItems.Add(rdr("Diio").ToString.Trim)
                    item.SubItems.Add(rdr("Obs").ToString.Trim)

                    lvCambioCategorias.Items.Add(item)

                    i = i + 1

                    'pbProcesa.Value = i
                End While

                'pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As SqlException
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvCambioCategorias.EndUpdate()

        pnlProcesa.Visible = False
        lblContReg.Text = i.ToString
        'Si ingreso un Diio a Buscar, los busca dentro de los datos consultados.
        'BuscaDiioEnListView(diio_)
    End Sub

    Private Sub BuscaDiioEnListView(ByVal diio_ As String)
        Dim ValorDiioAnt As String = ""
        Dim ValorDiioNuevo As String = ""
        For lin = 0 To lvCambioCategorias.Items.Count - 1
            ValorDiioAnt = lvCambioCategorias.Items(lin).SubItems(5).Text.ToString.Trim
            ValorDiioNuevo = lvCambioCategorias.Items(lin).SubItems(6).Text.ToString.Trim
            If ValorDiioAnt = diio_ Or ValorDiioNuevo = diio_ Then
                lvCambioCategorias.Items(lin).Selected = True
                'lvCambioDiios.Items(lin).BackColor = System.Drawing.Color.Yellow
                lvCambioCategorias.SelectedItems(0).EnsureVisible()
                lvCambioCategorias.Focus()
            End If

        Next
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor
        frmCambioDeCategoriasIngreso.MdiParent = frmMAIN
        frmCambioDeCategoriasIngreso.Show()
        frmCambioDeCategoriasIngreso.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub txtDIIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            MostrarDatosLV()
        Else
            If InStr(1, "0123456789,-%" & Chr(8), e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub lvCambioDiios_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCambioCategorias.MouseClick
        If lvCambioCategorias.Items.Count = 0 Then Exit Sub

        'If e.Button = MouseButtons.Right = True Then
        'End If
    End Sub

    'Variables utilizadas para eliminar un cambio de arete
    Private CenCod_ As String = ""
    Private FechaCambio_ As String = ""
    Private DiioOld_ As String = ""
    Private DiioNew_ As String = ""
    Private Sub mnuEliminarCambio_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If lvCambioCategorias.Items.Count = 0 Then Exit Sub
        If lvCambioCategorias.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿Desea Eliminar el Cambio de Diio Seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarCambioDiioBD() = True Then
            If MsgBox("Eliminacion realizada con exito.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                MostrarDatosLV()
            End If
        End If
    End Sub

    Private Function EliminarCambioDiioBD() As Boolean
        EliminarCambioDiioBD = False
        Cursor.Current = Cursors.WaitCursor

        CenCod_ = lvCambioCategorias.SelectedItems.Item(0).SubItems(2).Text()
        FechaCambio_ = lvCambioCategorias.SelectedItems.Item(0).SubItems(4).Text()
        DiioOld_ = lvCambioCategorias.SelectedItems.Item(0).SubItems(5).Text()
        DiioNew_ = lvCambioCategorias.SelectedItems.Item(0).SubItems(6).Text()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCambioDeDiios_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CentroCod", CenCod_)
        cmd.Parameters.AddWithValue("@FechaCambio", FechaCambio_)
        cmd.Parameters.AddWithValue("@Arete_Anterior", DiioOld_)
        cmd.Parameters.AddWithValue("@Arete_Nuevo", DiioNew_)

        cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RespValor").Value
            Dim mret As String = cmd.Parameters("@RespMsg").Value

            If vret = 0 Or vret = 2 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR AL ELIMINAR REGISTRO DE LA BASE DE DATOS.") = vbOK Then
                End If
                Exit Function
            End If
            'Elimina la fila seleccionada
            lvCambioCategorias.Items.Remove(lvCambioCategorias.SelectedItems(0))
            EliminarCambioDiioBD = True
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If cboCentros.SelectedIndex = -1 Then Exit Sub
        MostrarDatosLV()
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvCambioCategorias.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL REGS." : tot(0, 1) = lblContReg.Text

        ExportToExcelGrilla(lvCambioCategorias, tot)
    End Sub

    Private Sub mnuVerDetDiio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuVerDetDiio.Click
        DetalleGanado()
    End Sub
    Private Sub DetalleGanado()
        If lvCambioCategorias.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvCambioCategorias.SelectedItems.Item(0).SubItems(9).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lvCambioCategorias.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿Desea Eliminar los cambios de categoria Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            If Eliminar() = True Then
                MsgBox("Eliminacion terminada correctamente.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                btnBuscar.PerformClick()
            End If
        End If
    End Sub

    Private Function Eliminar() As Boolean
        Eliminar = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCambioDeCategorias_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        ''
        Dim DetalleItems As DataTable = LVToDataTable()
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@TablaDetalle", DetalleItems)
        ''
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
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
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            Eliminar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function

    Public Function LVToDataTable() As DataTable
        LVToDataTable = Nothing

        Dim table As DataTable = New DataTable("TablaDetalle")

        Dim Fecha As Date

        Dim CCode2 As String = ""
        Dim CCode3 As String = ""
        Dim CCode4 As String = ""
        Dim CGlosa As String = ""

        table.Columns.Add("EmpCod", System.Type.GetType("System.Decimal"))
        table.Columns.Add("CenCod", System.Type.GetType("System.String"))
        table.Columns.Add("CamCatFec", System.Type.GetType("System.String"))
        table.Columns.Add("CatCodDes", System.Type.GetType("System.String"))
        table.Columns.Add("CatCodOri", System.Type.GetType("System.String"))
        table.Columns.Add("Diio", System.Type.GetType("System.String"))        'GetType(Integer)
        

        For Each itm As ListViewItem In lvCambioCategorias.SelectedItems
            Fecha = itm.SubItems(4).Text

            CGlosa = itm.SubItems(9).Text
            If CGlosa.Trim.Length > 31 Then
                CGlosa = CGlosa.Trim.Substring(0, 30)
            End If

            table.Rows.Add(76011573, itm.SubItems(2).Text,
                           Fecha, itm.SubItems(7).Text,
                           itm.SubItems(5).Text, itm.SubItems(9).Text)

        Next

        LVToDataTable = table

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With frmCambioCategoriaCargaMasiva
            .TipoCambio = "Fecha"
            .PDFManual = "Manual cambio de categorías por fecha de nacimiento"
            .ShowDialog()
        End With


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With frmCambioCategoriaCargaMasiva
            .TipoCambio = "Vacas"
            .PDFManual = "Manual cambio de categorías para ganado adulto"
            .ShowDialog()
        End With

    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub
End Class