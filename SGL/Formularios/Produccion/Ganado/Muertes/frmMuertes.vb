

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmMuertes
    '    Private TipoReporte As Integer = 0
    Private fdats As frmCausaMuerte
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    'contabilizacion
    Private Total_Muertes As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "CenDesCor", "GndMuerteFec", "GndCod", "GndProNom", "VetNom", "GndMuerteCer", _
                                        "GndMuerteCod", "GndMuerteObsDet"}

    Private CadenaOrden As String = "GndMuerteFec"



    Private Sub InicializaTotales()
        Total_Muertes = 0
    End Sub
    Private Sub lvPARTOS_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvMUERTES.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvMUERTES, e)
    End Sub

    Private Sub ProcesaTotales(ByVal mue_ As Integer)
        If mue_ <> 0 Then
            Total_Muertes = Total_Muertes + mue_
        End If
    End Sub


    Private Sub MuestraTotales()
        'Label85.Text = Total_General.ToString.Trim

        Label48.Text = Total_Muertes.ToString.Trim()

        pnlEstReprod.Refresh()
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



    Private Sub CboLLenaVeterinarios()
        If General.Veterinarios.NroRegistros = 0 Then Exit Sub

        cboVeterinarios.Items.Clear()
        cboVeterinarios.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Veterinarios.NroRegistros - 1
            cboVeterinarios.Items.Add(General.Veterinarios.Nombre(i))
        Next

        cboVeterinarios.SelectedIndex = 0
    End Sub



    Private Sub CboLLenaCausas()
        If General.Veterinarios.NroRegistros = 0 Then Exit Sub

        cboCausasMuertes.Items.Clear()
        cboCausasMuertes.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CausasMuertes.NroRegistros - 1
            cboCausasMuertes.Items.Add(General.CausasMuertes.Nombre(i))
        Next

        cboCausasMuertes.SelectedIndex = 0
    End Sub


    Public Sub ConsultaMuertes(ByVal cent_ As String, ByVal vet_ As Integer, ByVal causa_ As String, ByVal diio_ As String, ByVal Estado As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuertes_Listado2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Veterinario", vet_)
        cmd.Parameters.AddWithValue("@Causa", causa_)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        cmd.Parameters.AddWithValue("@Estado", Estado)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        Dim itm As Integer = 0

        If lvMUERTES.SelectedItems.Count > 0 Then
            itm = lvMUERTES.SelectedIndices(0)
        End If

        'lvGanado.Items.Clear()
        lvMUERTES.BeginUpdate()
        lvMUERTES.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("MDetEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(Format(rdr("MDetFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add(rdr("VetNom").ToString.Trim)
                    item.SubItems.Add(rdr("MDetNroCertific").ToString.Trim)
                    item.SubItems.Add(rdr("CauNombre").ToString.Trim)
                    item.SubItems.Add(rdr("MDetObservacion").ToString.Trim)
                    If IsDBNull(rdr("MDetEstado")) Then
                        item.SubItems.Add("FINALIZADO")
                    Else
                        item.SubItems.Add(rdr("MDetEstado").ToString.Trim)
                    End If
                    item.SubItems.Add(rdr("GrpCrianza").ToString.Trim)
                    item.SubItems.Add(rdr("GrpProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("GndFecNac").ToString.Trim)
                    item.SubItems.Add(rdr("GndUltFechaPriPartos").ToString.Trim)
                    item.SubItems.Add(rdr("CenCod").ToString.Trim)



                    lvMUERTES.Items.Add(item)

                    ProcesaTotales(1)

                    i = i + 1
                    pbProcesa.Value = i
                End While

                pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvMUERTES.EndUpdate()
        'Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False

        If itm > 0 Then
            lvMUERTES.Items(itm).Selected = True
            lvMUERTES.Items(itm).EnsureVisible()
        End If
    End Sub


    Public Sub LlenaGrilla()
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim causa_ As String = ""
        Dim Estado As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If cboVeterinarios.SelectedIndex <> -1 And cboVeterinarios.Text <> "(TODOS)" Then
            vet_ = General.Veterinarios.Codigo(cboVeterinarios.SelectedIndex - 1)
        End If

        If cboCausasMuertes.SelectedIndex <> -1 And cboCausasMuertes.Text <> "(TODOS)" Then
            causa_ = cboCausasMuertes.Text 'General.CausasMuertes.Codigo(cboCausasMuertes.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "GndMuerteFec"
            lblOrdena.Text = "Fecha Muerte"
            lblOrdena.Refresh()
        End If

        If chbxPendiente.Checked And chbxFinalizado.Checked Then
            Estado = ""
        ElseIf chbxPendiente.Checked Then
            Estado = "PENDIENTE"
        Else
            Estado = "FINALIZADO"
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaMuertes(cent_, vet_, causa_, txtDIIO.Text.Trim, Estado)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub DetalleGanado()
        If lvMUERTES.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvMUERTES.SelectedItems.Item(0).SubItems(4).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrilla()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvMUERTES.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL MUERTES " : tot(0, 1) = Label48.Text.Trim

        ExportToExcelGrilla(lvMUERTES, tot)
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        frmMuertesIngreso.Param1_Modo = 1   'nuevo
        frmMuertesIngreso.MdiParent = frmMAIN
        frmMuertesIngreso.Show()
        frmMuertesIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvMUERTES.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvMUERTES.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvMUERTES.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvMUERTES.MouseDoubleClick
        If lvMUERTES.Items.Count = 0 Then Exit Sub
        If lvMUERTES.SelectedItems.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            'DetalleGanado()

            'frmMuertesIngreso.Param1_Modo = 2   'elimina muerte

            Cursor.Current = Cursors.WaitCursor

            frmMuertesModificacionEliminacion.btnGrabar.Visible = False
            frmMuertesModificacionEliminacion.btnEliminar.Left = frmMuertesModificacionEliminacion.btnGrabar.Left
            frmMuertesModificacionEliminacion.btnEliminar.Visible = True

            frmMuertesModificacionEliminacion.Param1_Modo = 1           'edita
            frmMuertesModificacionEliminacion.MdiParent = frmMAIN
            frmMuertesModificacionEliminacion.Show()
            frmMuertesModificacionEliminacion.BringToFront()

            frmMuertesModificacionEliminacion.cboCentros.Text = lvMUERTES.SelectedItems.Item(0).SubItems(2).Text
            frmMuertesModificacionEliminacion.txtDIIO.Text = lvMUERTES.SelectedItems.Item(0).SubItems(4).Text
            frmMuertesModificacionEliminacion.dtpFecha.Value = lvMUERTES.SelectedItems.Item(0).SubItems(3).Text
            frmMuertesModificacionEliminacion.cboVeterinarios.Text = lvMUERTES.SelectedItems.Item(0).SubItems(6).Text
            frmMuertesModificacionEliminacion.txtNroCert.Text = lvMUERTES.SelectedItems.Item(0).SubItems(7).Text
            frmMuertesModificacionEliminacion.cboCausasMuertes.Text = lvMUERTES.SelectedItems.Item(0).SubItems(8).Text
            frmMuertesModificacionEliminacion.txtObservs.Text = lvMUERTES.SelectedItems.Item(0).SubItems(9).Text

            frmMuertesModificacionEliminacion.cboCentros.Enabled = False
            frmMuertesModificacionEliminacion.txtDIIO.Enabled = False
            frmMuertesModificacionEliminacion.dtpFecha.Enabled = False
            frmMuertesModificacionEliminacion.cboVeterinarios.Enabled = False
            frmMuertesModificacionEliminacion.txtNroCert.Enabled = False
            frmMuertesModificacionEliminacion.cboCausasMuertes.Enabled = True
            frmMuertesModificacionEliminacion.txtObservs.Enabled = True

            'frmMuertesIngreso.btnGrabar.Enabled = True

            frmMuertesModificacionEliminacion.ConsultaDIIOSinValidaciones(frmMuertesModificacionEliminacion.txtDIIO.Text)

            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub frmMuertes_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If lvMUERTES.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvMUERTES.SelectedItems(0).SubItems(4).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If
        End If
    End Sub


    Private Sub frmMuertes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Veterinarios.Cargar()
        General.CausasMuertes.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        If PerfilUsuario = 9 Or PerfilUsuario = 5 Then
            btnAsignar.Enabled = True
            btnLeerBaston.Enabled = True
        Else
            btnAsignar.Enabled = False
            btnLeerBaston.Enabled = False
        End If

        CboLLenaCentros()
        CboLLenaVeterinarios()
        CboLLenaCausas()

        cboCentros.Text = CentroPorDefecto()
        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
    End Sub


    Private Sub mnuVerDetalle_Click(sender As System.Object, e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub

    Private Sub mnuCopiarDiio_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvMUERTES.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvMUERTES.SelectedItems(0).SubItems(4).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Sub mnuModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModificar.Click
        Cursor.Current = Cursors.WaitCursor



        frmMuertesModificacionEliminacion.Param1_Modo = 2           'modifica
        frmMuertesModificacionEliminacion.MdiParent = frmMAIN
        frmMuertesModificacionEliminacion.Show()
        frmMuertesModificacionEliminacion.BringToFront()

        frmMuertesModificacionEliminacion.cboCentros.Text = lvMUERTES.SelectedItems.Item(0).SubItems(2).Text
        frmMuertesModificacionEliminacion.txtDIIO.Text = lvMUERTES.SelectedItems.Item(0).SubItems(4).Text
        frmMuertesModificacionEliminacion.dtpFecha.Value = lvMUERTES.SelectedItems.Item(0).SubItems(3).Text
        frmMuertesModificacionEliminacion.cboVeterinarios.Text = lvMUERTES.SelectedItems.Item(0).SubItems(6).Text
        frmMuertesModificacionEliminacion.txtNroCert.Text = lvMUERTES.SelectedItems.Item(0).SubItems(7).Text
        frmMuertesModificacionEliminacion.cboCausasMuertes.Text = lvMUERTES.SelectedItems.Item(0).SubItems(8).Text
        frmMuertesModificacionEliminacion.txtObservs.Text = lvMUERTES.SelectedItems.Item(0).SubItems(9).Text

        frmMuertesModificacionEliminacion.cboCentros.Enabled = False
        frmMuertesModificacionEliminacion.txtDIIO.Enabled = False
        frmMuertesModificacionEliminacion.dtpFecha.Enabled = False
        'frmMuertesIngreso.cboVeterinarios.Enabled = False
        frmMuertesModificacionEliminacion.txtNroCert.Enabled = False
        'frmMuertesIngreso.cboCausasMuertes.Enabled = False
        frmMuertesModificacionEliminacion.txtObservs.Enabled = False

        frmMuertesModificacionEliminacion.ConsultaDIIOSinValidaciones(frmMuertesModificacionEliminacion.txtDIIO.Text)


        'frmMuertesIngreso.btnGrabar.Visible = False
        frmMuertesModificacionEliminacion.btnGrabar.Enabled = True
        'frmMuertesIngreso.btnEliminar.Left = frmMuertesIngreso.btnGrabar.Left
        'frmMuertesIngreso.btnEliminar.Visible = True
    End Sub


    Private Sub lvMUERTES_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvMUERTES.MouseClick
        If lvMUERTES.SelectedItems.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Right = True Then
            Dim MuestraModificar As Boolean = False

            If PerfilUsuario = 5 Then
                MuestraModificar = True
            End If

            If LoginUsuario = "MJIMENEZ" Then
                MuestraModificar = True
            End If

            If MuestraModificar = False Then
                mnuSep2.Visible = False
                mnuModificar.Visible = False
            End If
        End If
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        If lvMUERTES.Items.Count = 0 Then
            MsgBox("PRIMERO DEBE CARGAR INFORMACION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If

        ModificaDatos()
    End Sub
    Private Sub ModificaDatos()

        fdats = New frmCausaMuerte
        fdats.ShowDialog()

        If fdats.Procesa = True Then
            Dim VetObs As String = fdats.txtObservacion.Text
            Dim VetConf As String = "CONFIRMADO"

            ProcesaCambiosCubiertas(VetObs, VetConf)
        End If

        fdats.Dispose()
        fdats = Nothing
    End Sub
    Private Sub ProcesaCambiosCubiertas(ByVal Obs As String, ByVal Conf As String)
        For Each it As ListViewItem In lvMUERTES.SelectedItems
            it.SubItems(9).Text = Obs
            it.SubItems(10).Text = Conf
        Next
    End Sub

    Private Sub btnLeerBaston_Click(sender As Object, e As EventArgs) Handles btnLeerBaston.Click
        LeeBaston()
    End Sub
    Private Sub LeeBaston()
        frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmConfirmarMuerte"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing

    End Sub
    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        Dim TotDiios As Integer

        Cursor.Current = Cursors.WaitCursor

        lvMUERTES.Items.Clear()
        lvMUERTES.BeginUpdate()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","
            Dim item As New ListViewItem((i + 1).ToString)    'nro
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add(diio_)
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            If VerificaDIIOEnGrilla(-1, diio_) = True Then
                item.SubItems.Add("ERR / REPETIDO")
            Else
                item.SubItems.Add("SIN REGISTRO")
            End If
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            lvMUERTES.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If
        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        TotDiios = BuscarDiiosBaston(strdiios_, cent_)
        lvMUERTES.EndUpdate()
        Cursor.Current = Cursors.Default
    End Sub
    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvMUERTES.Items.Count - 1
            If i <> pos_ Then
                If lvMUERTES.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function
    Private Function BuscarDiiosBaston(ByVal diios_ As String, ByVal Centro As String) As Integer
        BuscarDiiosBaston = 0

        Dim ResultCod As Integer = 0
        Dim ResultMsg As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuertes_ConfirmarListado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        lvMUERTES.BeginUpdate()

        Dim i As Integer = 0
        Dim diio_ As String = ""
        Dim est_ As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            ResultCod = cmd.Parameters("@RetValor").Value
            ResultMsg = cmd.Parameters("@RetMensage").Value

            If ResultCod <> 0 Then
                MsgBox(ResultMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR")
                lvMUERTES.EndUpdate()
                lvMUERTES.Items.Clear()
                con.Close()
                Exit Function
            End If

            Try
                While rdr.Read()
                    diio_ = rdr("MDetDiio").ToString.Trim
                    For i = 0 To lvMUERTES.Items.Count - 1
                        If lvMUERTES.Items(i).SubItems(4).Text.Trim = diio_ Then


                            lvMUERTES.Items(i).SubItems(1).Text = rdr("MDetEmpresa").ToString.Trim
                            lvMUERTES.Items(i).SubItems(2).Text = rdr("CentroNom").ToString.Trim
                            lvMUERTES.Items(i).SubItems(3).Text = Format(rdr("MDetFecha"), "yyyy-MM-dd")
                            lvMUERTES.Items(i).SubItems(5).Text = rdr("GndProNom").ToString.Trim
                            lvMUERTES.Items(i).SubItems(6).Text = rdr("VetNom").ToString.Trim
                            lvMUERTES.Items(i).SubItems(7).Text = rdr("MDetNroCertific").ToString.Trim
                            lvMUERTES.Items(i).SubItems(8).Text = rdr("CauNombre").ToString.Trim
                            lvMUERTES.Items(i).SubItems(9).Text = rdr("MDetObservacion").ToString.Trim
                            lvMUERTES.Items(i).SubItems(15).Text = rdr("MDetCentro").ToString.Trim

                            If IsDBNull(rdr("MDetEstado")) Then
                                lvMUERTES.Items(i).SubItems(10).Text = "FINALIZADO"
                            Else
                                lvMUERTES.Items(i).SubItems(10).Text = rdr("MDetEstado")
                            End If
                            'If rdr("MDetObservacion") = "" Then
                            '    lvConfirmarMuerte.Items(i).SubItems(8).Text = "SIN OBSERVACION"
                            'Else
                            'lvMUERTES.Items(i).SubItems(7).Text = " "
                            'lvMUERTES.Items(i).SubItems(8).Text = " "
                            'End If
                        End If
                    Next

                    'i = i + 1
                End While



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        BuscarDiiosBaston = i

        'lblTotSecados.Text = i.ToString.Trim
        lvMUERTES.EndUpdate()
    End Function
End Class