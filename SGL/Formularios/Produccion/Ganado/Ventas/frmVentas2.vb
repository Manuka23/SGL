Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel

Public Class frmVentas2
    Private TipoReporte As Integer = 0

    'contabilizacion por condicion
    Private Total_General As Integer = 0
    Private Total_Detalle As Integer = 0
    Public UsuarioVenta As String

    Private ColumnSort As Integer = 0

    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "VtaEmpresa", "CenDesCor", "VtaFecha", "VtaNroFMA", "VDocNombre", "VtaNroDoc", _
                                        "CliRazSoc", "VtaNumRegs", "VEstNombre", "", "", "", "", ""}

    Private CadenaOrden As String = "CenDesCor, VtaFecha"


    Private Sub InicializaTotales()
        Total_General = 0
        Total_Detalle = 0
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
        Label85.Text = Total_General.ToString.Trim
        Label5.Text = Total_Detalle.ToString.Trim

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
    End Sub


    Public Sub ConsultaVentas(ByVal cent_ As String, ByVal diio_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVentas_Listado2", con) 'IIf(SRV_Servidor <> "SRVMNK", "spVentas_Listado2", "spVentas_Listado"), con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        InicializaTotales()
        MuestraTotales()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim est_ As String = 0
        Dim estcod_ As Integer = 0
        Dim NVentaSAMM As Integer = 0
        Dim SW As Integer = 0
        Dim nrovta_ As String = "", estnom_ As String = "", fma_ As String = "", guia_ As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    nrovta_ = "0"

                    If rdr("VtaNumero").ToString.Trim <> "" Then
                        nrovta_ = rdr("VtaNumero").ToString.Trim
                    Else
                        nrovta_ = 0
                    End If
                    If rdr("VtaNroFMA") > 0 Then
                        fma_ = rdr("VtaNroFMA").ToString.Trim
                    Else
                        fma_ = 0
                    End If
                    If rdr("VtaNroDoc") > 0 Then
                        guia_ = rdr("VtaNroDoc").ToString.Trim
                    Else
                        guia_ = 0
                    End If
                    If rdr("VtaCodigoSis").ToString.Trim() > 0 Then
                        NVentaSAMM = rdr("VtaCodigoSis").ToString.Trim()
                    Else
                        NVentaSAMM = 0
                    End If
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, correlativo

                    item.SubItems.Add(rdr("VtaEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(NVentaSAMM)                           'codigo venta SAMM
                    item.SubItems.Add(Format(rdr("VtaFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(fma_)                                 'FMA
                    item.SubItems.Add(rdr("VDocNombre").ToString.Trim)      'tipo documento
                    item.SubItems.Add(guia_)                                'nro documento
                    item.SubItems.Add(rdr("CliRazSoc").ToString.Trim)       'cliente
                    'item.SubItems.Add(rdr("TipDocNom").ToString.Trim)      'tipo documento
                    'item.SubItems.Add(rdr("DcCod").ToString.Trim)          'nro documento
                    item.SubItems.Add(rdr("VtaNumRegs").ToString.Trim)      'cantidad
                    item.SubItems.Add(rdr("VEstNombre").ToString.Trim)      'estado
                    item.SubItems.Add(rdr("VtaObservacion").ToString.Trim)  'observs
                    item.SubItems.Add(rdr("VtaCentro").ToString.Trim)       'codigo centro
                    item.SubItems.Add(rdr("VtaEstado").ToString.Trim)       'codigo estado (12)
                    item.SubItems.Add(nrovta_)                              'nro venta sgl

                    ''
                    item.SubItems.Add(rdr("VtaTransChoferRut").ToString.Trim)
                    item.SubItems.Add(rdr("VtaTransChoferNom").ToString.Trim)
                    item.SubItems.Add(rdr("VtaTransEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("VtaTransPatente1").ToString.Trim)
                    item.SubItems.Add(rdr("VtaTransPatente2").ToString.Trim)

                    item.SubItems.Add(rdr("VtaUsuario").ToString.Trim)
                    item.SubItems.Add(rdr("VtaFechaReg").ToString.Trim)
                    item.SubItems.Add(rdr("VtaUsuCodUpd").ToString.Trim)
                    item.SubItems.Add(rdr("VtaUsuFecUpd").ToString.Trim)

                    If rdr("VtaEstado") < 3 Then
                        item.UseItemStyleForSubItems = False

                        For IO As Integer = 0 To lvGanado.Columns.Count - 1
                            item.SubItems(IO).BackColor = Color.FromArgb(255, 255, 192)
                        Next
                    End If


                    lvGanado.Items.Add(item)

                    'ProcesaTotales(rdr("PlpExmOvarico").ToString.Trim)
                    Total_General = Total_General + 1
                    Total_Detalle = Total_Detalle + rdr("VtaNumRegs")

                    i = i + 1
                    pbProcesa.Value = Total_General
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
        lvGanado.EndUpdate()
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Private Sub DetalleVenta()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim emp_ As Integer = lvGanado.SelectedItems.Item(0).SubItems(1).Text           'empresa
        Dim nomcent_ As String = lvGanado.SelectedItems.Item(0).SubItems(2).Text        'nombre centro
        Dim VentaDirecta As Integer = lvGanado.SelectedItems.Item(0).SubItems(3).Text   'N° req Samm, si es 0 es venta directa
        Dim fec_ As String = lvGanado.SelectedItems.Item(0).SubItems(4).Text            'fecha cecado
        Dim fma_ As String = lvGanado.SelectedItems.Item(0).SubItems(5).Text            'fma
        Dim tdoc As String = lvGanado.SelectedItems.Item(0).SubItems(6).Text            'tdoc
        Dim guia_ As String = lvGanado.SelectedItems.Item(0).SubItems(7).Text           'guia
        Dim clte_ As String = lvGanado.SelectedItems.Item(0).SubItems(8).Text           'cliente
        'Dim tdocnom_ As String = lvGanado.SelectedItems.Item(0).SubItems(7).Text        'nombre tipo doc
        'Dim nrodoc_ As String = lvGanado.SelectedItems.Item(0).SubItems(8).Text         'nro doc

        Dim est_ As String = lvGanado.SelectedItems.Item(0).SubItems(10).Text           'nombre estado 10
        Dim obs_ As String = lvGanado.SelectedItems.Item(0).SubItems(11).Text           'observacion secado 11
        Dim cent_ As String = lvGanado.SelectedItems.Item(0).SubItems(12).Text          'codigo centro 12

        Dim estcod_ As Integer = lvGanado.SelectedItems.Item(0).SubItems(13).Text        'codigo estado 13
        Dim nrovet_ As Integer = lvGanado.SelectedItems.Item(0).SubItems(14).Text        'nro venta SGL 14
        'Dim codsis_ As Integer = lvGanado.SelectedItems.Item(0).SubItems(13).Text        'codigo venta IVS
        ''
        Dim rutchofe_ As String = lvGanado.SelectedItems.Item(0).SubItems(15).Text       'rut chofe
        Dim nomchofe_ As String = lvGanado.SelectedItems.Item(0).SubItems(16).Text       'nom chofe
        Dim nomtrans_ As String = lvGanado.SelectedItems.Item(0).SubItems(17).Text       'nom trans
        Dim pat1_ As String = lvGanado.SelectedItems.Item(0).SubItems(18).Text           'pat1
        Dim pat2_ As String = lvGanado.SelectedItems.Item(0).SubItems(19).Text           'pat2


        If cent_.Trim = "" Then Exit Sub

        If fma_.Trim = "" Then fma_ = "0"
        If guia_.Trim = "" Then guia_ = "0"

        With frmVentas2Ingreso
            '.CodigoSecado = codsec_
            .Param0_ModoIngreso = 2        '1=nuevo  /  2=edicion
            '.Param1_Empresa = emp_
            .VentaDirecta = VentaDirecta
            .Param2_CodigoCentro = cent_
            .Param3_NombreCentro = nomcent_
            .Param4_Fecha = fec_
            .Param5_Observs = obs_
            .Param6_NumeroVenta = nrovet_
            .Param7_NroGuia = guia_
            .Param8_TipoDoc = tdoc
            '.Param8_RUP = rup_
            .Param9_Estado = est_
            '.Param10_TipoDocumento = tdocnom_
            .Param11_FMA = fma_
            '.Param12_NroDocumento = nrodoc_
            .Param13_Cliente = clte_
            .Param14_CodigoEstado = estcod_
            ''
            .Param30_RutChofer = rutchofe_
            .Param31_NomChofer = nomchofe_
            .Param32_NomTransporte = nomtrans_
            .Param33_Patente1 = pat1_
            .Param34_Patente2 = pat2_
            .UsuarioCreacion = lvGanado.SelectedItems.Item(0).SubItems(20).Text
            .FechaCreacion = lvGanado.SelectedItems.Item(0).SubItems(21).Text
            .UsuarioActualizacion = lvGanado.SelectedItems.Item(0).SubItems(22).Text
            .FechaActualizacion = lvGanado.SelectedItems.Item(0).SubItems(23).Text

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub LlenaGrillaVentas()
        'Dim OtrosCent As Integer = 0
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        'If cboVeterinarios.SelectedIndex <> -1 And cboVeterinarios.Text <> "(TODOS)" Then
        '    vet_ = General.Veterinarios.Codigo(cboVeterinarios.SelectedIndex - 1)
        'End If

        If CadenaOrden = "" Then
            CadenaOrden = "CenDesCor, VtaFecha"
            lblOrden.Text = "Centro -> Fecha"
            lblOrden.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaVentas(cent_, txtDIIO.Text.Trim)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrillaVentas()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()

        'SaveSN.SelectedNode.ForeColor = Color.AntiqueWhite

        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL VENTAS " : tot(0, 1) = Label85.Text.Trim
        tot(1, 0) = "TOTAL VENTA GANADO " : tot(1, 1) = Label5.Text.Trim

        ExportToExcelGrilla(lvGanado, tot)
    End Sub



    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        With frmVentas2Ingreso
            '.CodigoSecado = 0
            .Param0_ModoIngreso = 1         '1=nuevo  /  2=edicion
            .Param6_NumeroVenta = 0         'nro venta SGL
            .Param14_CodigoEstado = 1       'para un nuevo ingreso de ventas el estado por defecto es "EN INGRESO"

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            If cboCentros.SelectedIndex > 0 Then .cboCentros.Text = cboCentros.Text
        End With

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿Confirma eliminación de Venta seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarVenta() = True Then
            MsgBox("Eliminacion finalizada correctamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmacion")
            btnBuscar_Click(sender, e)
        End If
    End Sub


    Private Function EliminarVenta() As Boolean
        EliminarVenta = False

        Dim EmpRut As String = lvGanado.SelectedItems.Item(0).SubItems(1).Text 'Codigo Empresa
        Dim CodCentro As String = lvGanado.SelectedItems.Item(0).SubItems(12).Text 'Codigo Centro
        Dim Fec As DateTime = Convert.ToDateTime(lvGanado.SelectedItems.Item(0).SubItems(4).Text) 'Fecha Venta
        Dim NroVta As Integer = Convert.ToInt32(lvGanado.SelectedItems.Item(0).SubItems(14).Text) 'Nro Venta

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVentas_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CodCentro)
        cmd.Parameters.AddWithValue("@Fecha", Fec)
        cmd.Parameters.AddWithValue("@NroVenta", NroVta)
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

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error de Validaciones") = vbOK Then
                End If
                Exit Function
            End If

            EliminarVenta = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

    End Function


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Private Sub dtpFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
    End Sub



    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvGanado.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrden.Text = lvGanado.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrden.Text = lblOrden.Text + " -> " + lvGanado.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleVenta()
        End If
    End Sub


    Private Sub frmVentas2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Veterinarios.Cargar()
        General.Clientes.Cargar()
        General.TiposVentas.Cargar()
        General.CausasVentas.Cargar()
        General.TipoDocumentosVentas.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        VentaBuscarPersonal()
        CboLLenaCentros()
        lvGanado.Columns(7).Width = lvGanado.Columns(7).Width - 50
        lvGanado.Columns(13).Width = 70
        lvGanado.Columns(13).DisplayIndex = 3

        If UsuarioVenta = 1 Then
            btnAgregar.Visible = True
            btnAgregar.Enabled = True
            btnCambioCliente.Visible = True
            btnEliminar.Visible = True
        Else
            btnAgregar.Visible = False
            btnAgregar.Enabled = False
            btnCambioCliente.Visible = False
            btnEliminar.Visible = False
        End If

        dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now

        btnImportar.Enabled = False
        cboCentros.SelectedIndex = 0
    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor
        Dim Empdoc_ As String = lvGanado.SelectedItems.Item(0).SubItems(1).Text
        Dim tdoc_ As String = lvGanado.SelectedItems.Item(0).SubItems(6).Text           'tipo doc
        Dim guia_ As String = lvGanado.SelectedItems.Item(0).SubItems(7).Text           'nro doc (guia)

        Dim PdfNomSuite As String = SuiteElectronica.GeneraNombreArchivo(52, guia_, Empdoc_)
        SuiteElectronica.MostrarPDFeSuite(PdfNomSuite)

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvGanado_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseClick
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim tdoc_ As String = lvGanado.SelectedItems.Item(0).SubItems(6).Text

        If tdoc_.Contains("ELECT") Then
            btnImprimir.Enabled = True
        Else
            btnImprimir.Enabled = False
        End If

    End Sub
    Private Sub VentaBuscarPersonal()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVentas_UsuarioVentas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    UsuarioVenta = rdr("PermIngVentaGanado").ToString.Trim
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

    Private Sub btnCambioCliente_Click(sender As Object, e As EventArgs) Handles btnCambioCliente.Click
        If lvGanado.SelectedItems.Count > 0 Then
            frmVentasCambioCliente.Show()
        Else
            MsgBox("DEBE SELECCIONAR UNA VENTA", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SELECCIONAR VENTA")
        End If
    End Sub
End Class