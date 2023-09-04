

Imports System.Data.SqlClient


Public Class frmIATF
    '    Private TipoReporte As Integer = 0

    'contabilizacion
    Private Total_Muertes As Integer = 0
    Private Total_MuertesDet As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "CentroNomCorto", "IATFFecha", "IATFTotRegs", "IATFObserbs"}
    Private CadenaOrden As String = "CentroNomCorto, IATFFecha"


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



    Public Sub ConsultaIATFs(ByVal cent_ As String, ByVal diio_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spIATF_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        'cmd.Parameters.Add("@RetTotVacas", SqlDbType.Int) : cmd.Parameters("@RetTotVacas").Direction = ParameterDirection.Output

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvINGRESOS.BeginUpdate()
        lvINGRESOS.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0
        Dim totvacas As Integer = 0
        Dim totcelos As Integer = 0

        'Label48.Text = "0"
        Label4.Text = "0"
        'Label6.Text = "0"

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            'totvacas = cmd.Parameters("@RetTotVacas").Value
            'totvacas = cmd.Parameters("@RetTotVacas").Value

            Try


                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        'totvacas = rdr("ContVacas")
                        pbProcesa.Maximum = vret
                    End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("IATFEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("CentroNomCorto").ToString.Trim)                  'centro
                    item.SubItems.Add(Format(rdr("IATFFecha"), "dd-MM-yyyy HH:mm:ss"))    '+ " " + rdr("PalHora").ToString.Trim)
                    item.SubItems.Add(rdr("IATFTotRegs").ToString.Trim)
                    item.SubItems.Add(rdr("IATFObserbs").ToString.Trim)
                    item.SubItems.Add(rdr("IATFCentro").ToString.Trim)

                    lvINGRESOS.Items.Add(item)

                    'ProcesaTotales(rdr("CeloTotRegs"))
                    totcelos = totcelos + rdr("IATFTotRegs")

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
        lvINGRESOS.EndUpdate()

        'totvacas = TotalVacas()

        'Label48.Text = totvacas.ToString.Trim
        Label4.Text = totcelos.ToString.Trim
        'Label6.Text = (totvacas - totcelos).ToString.Trim

        'Total_General = i
        'MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Public Sub LlenaGrilla()
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim causa_ As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "CentroNomCorto, IATFFecha"
            lblOrdena.Text = "Centro -> Fecha CIDR"
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaIATFs(cent_, txtDIIO.Text.Trim)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub DetalleGanado()
        If lvINGRESOS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvINGRESOS.SelectedItems.Item(0).SubItems(4).Text
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
        If lvINGRESOS.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}
        tot(0, 0) = "TOTAL REGISTROS: " : tot(0, 1) = Label4.Text.Trim

        ExportToExcelGrilla(lvINGRESOS, tot)
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        frmIATFIngreso.Param1_Modo = 1   'nuevo

        frmIATFIngreso.MdiParent = frmMAIN
        frmIATFIngreso.Show()
        frmIATFIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvINGRESOS.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvINGRESOS.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvINGRESOS.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvINGRESOS.MouseDoubleClick
        If lvINGRESOS.Items.Count = 0 Then Exit Sub
        If lvINGRESOS.SelectedItems.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            'DetalleGanado()

            With frmIATFIngreso
                .Param1_Modo = 2   'edita (elimina)
                .Param2_Empresa = Empresa
                .Param3_CentroCod = lvINGRESOS.SelectedItems.Item(0).SubItems(6).Text
                .Param3_CentroNom = lvINGRESOS.SelectedItems.Item(0).SubItems(2).Text
                .Param4_Fecha = lvINGRESOS.SelectedItems.Item(0).SubItems(3).Text
                .Param5_Observs = lvINGRESOS.SelectedItems.Item(0).SubItems(5).Text
            End With


            'frmIATFIngreso.Param1_Modo = 2   'edita (elimina)


            Cursor.Current = Cursors.WaitCursor

            'frmIATFIngreso.btnGrabar.Visible = False
            'frmIATFIngreso.btnEliminar.Left = frmIATFIngreso.btnGrabar.Left
            'frmIATFIngreso.btnEliminar.Visible = True

            frmIATFIngreso.MdiParent = frmMAIN
            frmIATFIngreso.Show()
            frmIATFIngreso.BringToFront()

            'frmIATFIngreso.cboCentros.Text = lvCELOS.SelectedItems.Item(0).SubItems(2).Text
            'frmIATFINGRESO.txtDIIO.Text = lvCELOS.SelectedItems.Item(0).SubItems(4).Text
            'frmIATFIngreso.dtpFecha.Value = lvCELOS.SelectedItems.Item(0).SubItems(3).Text
            'frmIATFIngreso.txtObservs.Text = lvCELOS.SelectedItems.Item(0).SubItems(5).Text

            frmIATFIngreso.cboCentros.Enabled = False
            frmIATFIngreso.txtDIIO.Enabled = False
            frmIATFIngreso.dtpFecha.Enabled = False
            frmIATFIngreso.txtObservs.Enabled = False

            'frmIATFINGRESO.ConsultaDIIOSinValidaciones(frmIATFINGRESO.txtDIIO.Text)

            'Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub frmIATF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()
        'CboLLenaVeterinarios()
        'CboLLenaCausas()

        cboCentros.Text = CentroPorDefecto()
        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        LlenaGrilla()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        EliminarIATF()
    End Sub

    Private Sub EliminarIATF()
        If lvINGRESOS.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR EL LOS REGISTROS DEL DIA SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            If EliminarDiaIATF() = True Then

            End If
        End If
    End Sub
    Private Function EliminarDiaIATF() As Boolean
        EliminarDiaIATF = False


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spIATF_EliminarDia", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim diio_ As String = lvINGRESOS.SelectedItems(0).SubItems(1).Text
        Dim centro As String = lvINGRESOS.SelectedItems(0).SubItems(6).Text
        Dim fecha As String = lvINGRESOS.SelectedItems(0).SubItems(3).Text

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Fecha", DateTime.Parse(fecha))
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
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            EliminarDiaIATF = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
End Class