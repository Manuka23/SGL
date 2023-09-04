

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmAjustes
    Private TipoReporte As Integer = 0


    Private Total_Salidas As Integer = 0
    Private Total_Entradas As Integer = 0
    Private Total_SalGanado As Integer = 0
    Private Total_EntGanado As Integer = 0

    'nombre de los campos en la base de datos, para el orden de los registros en la grilla
    Private CamposOrden As String() = {"", "", "CenDesCor", "AjuFecha", "AMovNombre", "AjuObservs", "AjuNumRegs", "AEstNombre"}
    Private CadenaOrden As String = "CenDesCor, AjuFecha"
    Private OrdenPorDefecto As String = "CenDesCor, AjuFecha"



    Private Sub InicializaTotales()
        Total_Salidas = 0
        Total_Entradas = 0
        Total_SalGanado = 0
        Total_EntGanado = 0
    End Sub


    'Private Sub ProcesaTotales(ByVal cond_ As String)
    '    Select Case cond_
    '        Case "PRENADA" : TotER_Preniada = TotER_Preniada + 1
    '        Case "PREÑADA" : TotER_Preniada = TotER_Preniada + 1
    '        Case "SECA PRN" : TotER_SecaPrn = TotER_SecaPrn + 1
    '        Case "DUDOSA" : TotER_Dudosa = TotER_Dudosa + 1
    '        Case "ANESTRO" : TotER_Anestro = TotER_Anestro + 1
    '        Case Else : TotER_Otros = TotER_Otros + 1
    '    End Select
    'End Sub


    Private Sub MuestraTotales()
        Label85.Text = Total_Salidas.ToString.Trim
        Label5.Text = Total_Entradas.ToString.Trim
        Label7.Text = Total_SalGanado.ToString.Trim
        Label9.Text = Total_EntGanado.ToString.Trim

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


    Private Sub CboLLenaTipoMovimientos()
        If General.TipoMovsAjuste.NroRegistros = 0 Then Exit Sub

        cboMovimientos.Items.Clear()
        cboMovimientos.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.TipoMovsAjuste.NroRegistros - 1
            cboMovimientos.Items.Add(General.TipoMovsAjuste.Nombre(i))
        Next

        cboMovimientos.SelectedIndex = 0
    End Sub


    Private Sub CboLLenaEstadosAjustes()
        If General.EstadosAjuste.NroRegistros = 0 Then Exit Sub

        cboEstados.Items.Clear()
        cboEstados.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.EstadosAjuste.NroRegistros - 1
            cboEstados.Items.Add(General.EstadosAjuste.Nombre(i))
        Next

        cboEstados.SelectedIndex = 0
    End Sub


    Public Sub ConsultaAjustes(ByVal cent_ As String, ByVal mov_ As Integer, ByVal est_ As Integer)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAjustes_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@Movimiento", mov_)
        cmd.Parameters.AddWithValue("@Estado", est_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvAJUSTES.BeginUpdate()
        lvAJUSTES.Items.Clear()

        InicializaTotales()
        MuestraTotales()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim org_ As String = ""

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

                    item.SubItems.Add(rdr("AjuEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(Format(rdr("AjuFecha"), "dd-MM-yyyy HH:mm:ss.mmm"))
                    item.SubItems.Add(rdr("AMovNombre").ToString.Trim)
                    item.SubItems.Add(rdr("AjuObservs").ToString.Trim)
                    item.SubItems.Add(rdr("AjuNumRegs").ToString.Trim)
                    item.SubItems.Add(rdr("AEstNombre").ToString.Trim)
                    item.SubItems.Add(rdr("AjuCentro").ToString.Trim)
                    item.SubItems.Add(rdr("AjuMovimiento").ToString.Trim)
                    item.SubItems.Add(rdr("AjuEstado").ToString.Trim)

                    If Int32.Parse(rdr("AjuEstado").ToString.Trim) < 2 Then
                        item.UseItemStyleForSubItems = False

                        For IO As Integer = 0 To lvAJUSTES.Columns.Count - 1
                            item.SubItems(IO).BackColor = Color.FromArgb(255, 255, 192)
                        Next
                    End If

                    lvAJUSTES.Items.Add(item)

                    If rdr("AMovNombre").ToString.Trim.ToUpper.Contains("SALIDA") = True Then
                        Total_Salidas = Total_Salidas + 1
                        Total_SalGanado = Total_SalGanado + Val(rdr("AjuNumRegs").ToString.Trim)
                    Else
                        Total_Entradas = Total_Entradas + 1
                        Total_EntGanado = Total_EntGanado + Val(rdr("AjuNumRegs").ToString.Trim)
                    End If

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
        lvAJUSTES.EndUpdate()
        'Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Private Function EliminarTraslado(ByVal codsec_ As Integer) As Boolean
        EliminarTraslado = False

        'Dim con As New SqlConnection(GetConnectionString())
        'Dim cmd As New SqlCommand("spAjustes_Eliminar", con)
        'Dim rdr As SqlDataReader = Nothing

        'cmd.CommandType = Data.CommandType.StoredProcedure

        'cmd.Parameters.AddWithValue("@Empresa", Empresa)
        'cmd.Parameters.AddWithValue("@CodTraslado", codsec_)
        'cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        'cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        ''
        'cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        'cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        'Try
        '    con.Open()

        '    Dim Result As Integer = cmd.ExecuteNonQuery()

        '    Dim vret As Integer = cmd.Parameters("@RetValor").Value
        '    Dim mret As String = cmd.Parameters("@RetMensage").Value

        '    If vret > 0 Then
        '        If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '        End If
        '        Exit Function
        '    End If

        '    EliminarTraslado = True

        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        'End Try
    End Function


    Private Sub DetalleTraslado()
        If lvAJUSTES.Items.Count = 0 Then Exit Sub
        If lvAJUSTES.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim emp_ As Integer = lvAJUSTES.SelectedItems.Item(0).SubItems(1).Text          'empresa
        Dim cent_ As String = lvAJUSTES.SelectedItems.Item(0).SubItems(8).Text          'centro
        Dim fec_ As String = lvAJUSTES.SelectedItems.Item(0).SubItems(3).Text           'fecha
        Dim mov_ As Integer = lvAJUSTES.SelectedItems.Item(0).SubItems(9).Text          'movimiento
        Dim est_ As Integer = lvAJUSTES.SelectedItems.Item(0).SubItems(10).Text         'estado

        Dim nomcent_ As String = lvAJUSTES.SelectedItems.Item(0).SubItems(2).Text       'nombre centro
        Dim obs_ As String = lvAJUSTES.SelectedItems.Item(0).SubItems(5).Text           'observacion
        Dim cant_ As Integer = lvAJUSTES.SelectedItems.Item(0).SubItems(6).Text         'cantidad
        Dim nomest_ As String = lvAJUSTES.SelectedItems.Item(0).SubItems(7).Text        'nombre estado
        Dim nommov_ As String = lvAJUSTES.SelectedItems.Item(0).SubItems(4).Text        'nombre movimiento

        'Dim ConsultaDIIO As New frmConsultaDIIO

        If cent_ = 0 Then Exit Sub

        With frmAjustesIngreso
            '.CodigoTraslado = codsec_
            .Param0_ModoIngreso = 2        '1=nuevo  /  2=edicion
            .Param1_Empresa = emp_
            .Param2_CodigoCentro = cent_
            .Param3_NombreCentro = nomcent_
            .Param4_Fecha = fec_
            .Param5_Observs = obs_
            .Param9_Movimiento = mov_
            .Param10_MovimientoNom = nommov_
            .Param11_Estado = est_
            '
            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With


        Cursor.Current = Cursors.Default
    End Sub




    Public Sub LlenaGrillaAjustes()
        'Dim OtrosCent As Integer = 0
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim mov_ As Integer = 0
        Dim est_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If cboMovimientos.SelectedIndex <> -1 And cboMovimientos.Text <> "(TODOS)" Then
            mov_ = General.TipoMovimientos.Codigo(cboMovimientos.SelectedIndex - 1)
        End If

        If cboEstados.SelectedIndex <> -1 And cboEstados.Text <> "(TODOS)" Then
            est_ = General.EstadosAjuste.Codigo(cboEstados.SelectedIndex - 1)
        End If


        If CadenaOrden = "" Then
            CadenaOrden = OrdenPorDefecto
            lblOrden.Text = "Centro -> Fecha"
            lblOrden.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaAjustes(cent_, mov_, est_)

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleTraslado()
    End Sub



    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        'If lvSECADOS.Items.Count = 0 Then Exit Sub

        'Dim codsec_ As Integer = Val(lvSECADOS.SelectedItems.Item(0).SubItems(2).Text)
        'If codsec_ = 0 Then Exit Sub

        'If MsgBox("¿DESEA ELIMINAR EL GRUPO DE SECADO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

        '    If MsgBox("¿ESTA SEGURO DE LA ELIMINACION?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        '        Exit Sub
        '    End If

        '    If EliminarSecado(codsec_) = True Then
        '        If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
        '        End If

        '        'lvDIIOS.SelectedItems.Item(0).Remove()
        '        'RestaSecado()

        '        LlenaGrillaSecados()
        '    End If
        'End If

        'Exit Sub
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrillaAjustes()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()

        'SaveSN.SelectedNode.ForeColor = Color.AntiqueWhite

        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvAJUSTES.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL SALIDAS " : tot(0, 1) = Label85.Text.Trim
        tot(1, 0) = "TOTAL ENTRADAS " : tot(1, 1) = Label5.Text.Trim
        tot(2, 0) = "TOTAL SALIDA GANADO " : tot(0, 1) = Label7.Text.Trim
        tot(3, 0) = "TOTAL ENTRADA GANADO " : tot(1, 1) = Label9.Text.Trim

        ExportToExcelGrilla(lvAJUSTES, tot)
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        With frmAjustesIngreso
            '.CodigoSecado = 0
            .Param0_ModoIngreso = 1        '1=nuevo  /  2=edicion
            .Param3_NombreCentro = cboCentros.Text

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Private Sub dtpFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
    End Sub



    Private Sub lvTRASLADOS_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvAJUSTES.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrden.Text = lvAJUSTES.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrden.Text = lblOrden.Text + " -> " + lvAJUSTES.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvTRASLADOS_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvAJUSTES.MouseClick
        If lvAJUSTES.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Right = True Then
            Dim mov_ As String = lvAJUSTES.SelectedItems.Item(0).SubItems(2).Text
            Dim dest_ As String = lvAJUSTES.SelectedItems.Item(0).SubItems(7).Text
            Dim est_ As String = lvAJUSTES.SelectedItems.Item(0).SubItems(10).Text
            Dim existe_dest_ As Boolean = False

            'mnuRecepcion.Enabled = False

            'si es salida y esta en trasito
            If mov_.Contains("SAL") And est_.Contains("TRANS") Then
                'verificamos que el centro de destino exista en los centros del usuario
                For i As Integer = 0 To General.CentrosUsuario.Codigo.Count - 1
                    If General.CentrosUsuario.Nombre(i).Contains(dest_) Then
                        existe_dest_ = True
                        Exit For
                    End If
                Next
            End If

            mnuConfirmarVB.Enabled = existe_dest_
        End If
    End Sub


    Private Sub lvTRASLADOS_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvAJUSTES.MouseDoubleClick
        If lvAJUSTES.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleTraslado()
        End If
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        LlenaGrillaAjustes()
    End Sub



    Private Sub mnuConfirmarVB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfirmarVB.Click
        ''menu confirma ajuste (rebaja o aumenta stock)

    End Sub


    Private Sub frmAjustes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If PerfilUsuario = 3 Or PerfilUsuario = 16 Or PerfilUsuario = 4 Or PerfilUsuario = 11 Then
            btnAgregar.Enabled = True
        Else
            btnAgregar.Enabled = False
        End If

        General.TiposAjusteEntrada.Cargar()
        General.TiposAjusteSalida.Cargar()
        General.EstadosAjuste.Cargar()
        General.EstReproductivos.Cargar()
        General.EstProductivos.Cargar()
        General.TipoMovsAjuste.Cargar()
        General.TipoMovimientos.Cargar()
        General.Razas.Cargar()
        General.Categorias.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaTipoMovimientos()
        CboLLenaEstadosAjustes()

        cboCentros.Text = CentroPorDefecto()
        dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now
    End Sub




End Class