

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmRevPostPartos
    Private TipoReporte As Integer = 0

    'contabilizacion por condicion
    Private Total_General As Integer = 0

    'nombre de los campos en la base de datos, para el orden de los registros en la grilla
    Private CamposOrden As String() = {"", "", "CenCod", "CenDesCor", "RevPPFec", "RevPPNumReg", ""}
    Private CadenaOrden As String = "CenDesCor, RevPPFec"
    Private OrdenPorDefecto As String = "CenDesCor, RevPPFec"
    'Private CamposOrden2 As String() = {"", "", "EmpRut", "CenDesCor", "SecFecha", "SecTotSecados", "SecObservacion"}
    'Private CadenaOrden2 As String = "CenDesCor, SecFecha"
    'Private OrdenPorDefecto2 As String = "CenDesCor, ScSecFechadFec"




    Private Sub InicializaTotales()
        Total_General = 0
        'TotER_Preniada = 0
        'TotER_SecaPrn = 0
        'TotER_Dudosa = 0
        'TotER_Anestro = 0
        'TotER_Otros = 0
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

        'Label48.Text = TotER_Preniada.ToString.Trim()
        'Label34.Text = TotER_SecaPrn.ToString.Trim()
        'Label54.Text = TotER_Dudosa.ToString.Trim()
        'Label59.Text = TotER_Anestro.ToString.Trim()
        'Label52.Text = TotER_Otros.ToString.Trim()

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


    'Private Sub CboLLenaVeterinarios()
    '    If General.Veterinarios.NroRegistros = 0 Then Exit Sub

    '    cboVeterinarios.Items.Clear()
    '    cboVeterinarios.Items.Add("(TODOS)")

    '    Dim i As Integer

    '    For i = 0 To General.Veterinarios.NroRegistros - 1
    '        cboVeterinarios.Items.Add(General.Veterinarios.Nombre(i))
    '    Next
    'End Sub


    'Public Sub FechasTemporada()
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spTemporada_PeriodoActual", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    Try
    '        con.Open()
    '        rdr = cmd.ExecuteReader()

    '        Try
    '            While rdr.Read()
    '                dtpFechaDesde.Value = rdr("TempFechaIni")
    '                dtpFechaHasta.Value = rdr("TempFechaFin")
    '            End While

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub

    Public Sub ConsultaSecados(ByVal cent_ As String, ByVal diio_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        'lvGanado.Items.Clear()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRevisionesPP_Listado", con)
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
        lvSECADOS.BeginUpdate()
        lvSECADOS.Items.Clear()

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

                    item.SubItems.Add(rdr("EmpRut").ToString.Trim)
                    item.SubItems.Add(rdr("CenCod").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(Format(rdr("RevPPFec"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("RevPPNumReg").ToString.Trim)
                    item.SubItems.Add(rdr("RevPPObs").ToString.Trim)

                    lvSECADOS.Items.Add(item)

                    'ProcesaTotales(rdr("PlpExmOvarico").ToString.Trim)
                    Total_General = Total_General + Val(rdr("RevPPNumReg").ToString.Trim)
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
        lvSECADOS.EndUpdate()
        'Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Private Function EliminarSecado(ByVal emp_ As Integer, ByVal cent_ As String, ByVal fec_ As DateTime) As Boolean
        EliminarSecado = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSecados_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", emp_)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", fec_)
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

            EliminarSecado = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub DetalleRevPP()
        If lvSECADOS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim emp_ As Integer = lvSECADOS.SelectedItems.Item(0).SubItems(1).Text          'empresa
        Dim cent_ As String = lvSECADOS.SelectedItems.Item(0).SubItems(2).Text          'centro
        Dim nomcent_ As String = lvSECADOS.SelectedItems.Item(0).SubItems(3).Text       'nombre centro
        Dim fecsec_ As String = lvSECADOS.SelectedItems.Item(0).SubItems(4).Text        'fecha rev
        'Dim obssec_ As String = lvSECADOS.SelectedItems.Item(0).SubItems(6).Text        'observacion secado

        'Dim ConsultaDIIO As New frmConsultaDIIO

        If cent_.Trim = "" Then Exit Sub

        With frmRevPostPartosIngreso
            '.CodigoSecado = codsec_
            .Param0_ModoIngreso = 2        '1=nuevo  /  2=edicion
            .Param1_Empresa = emp_
            .Param2_CodigoCentro = cent_
            .Param3_NombreCentro = nomcent_
            .Param4_FechaDesde = fecsec_ 'dtpFechaDesde.Value
            .Param4_FechaHasta = fecsec_ 'dtpFechaHasta.Value
            '.Param5_Observs = obssec_

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With


        Cursor.Current = Cursors.Default
    End Sub


    Public Sub LlenaGrillaSecados()
        'Dim OtrosCent As Integer = 0
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = OrdenPorDefecto
            lblOrden.Text = "Centro -> Fecha Secado"
            lblOrden.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaSecados(cent_, txtDIIO.Text.Trim)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnImportar_Click(sender As System.Object, e As System.EventArgs) Handles btnImportar.Click
        Cursor.Current = Cursors.WaitCursor

        'OpenFDlg.FileName = ""
        'OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        'OpenFDlg.ShowDialog()

        'If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        'frmPalpacionesImportacion.ArchivoImportacion = OpenFDlg.FileName.Trim()


        'frmPalpacionesImportacion.MdiParent = frmMAIN
        'frmPalpacionesImportacion.Show()

        'Dim imp As New frmPalpacionesImportacion(OpenFDlg.FileName.Trim)

        'imp.MdiParent = frmMAIN
        'imp.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvSECADOS.Items.Count = 0 Then Exit Sub
        If lvSECADOS.SelectedItems.Count = 0 Then Exit Sub

        Dim emp_ As Integer = Val(lvSECADOS.SelectedItems.Item(0).SubItems(1).Text)
        Dim cent_ As String = lvSECADOS.SelectedItems.Item(0).SubItems(2).Text
        Dim fec_ As DateTime = lvSECADOS.SelectedItems.Item(0).SubItems(4).Text

        If emp_ = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR EL GRUPO DE SECADO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If MsgBox("SE ELIMINARA PERMANENTEMENTE TODO EL GRUPO DE SECADOS" + vbCrLf + vbCrLf + _
                    "¿ESTA SEGURO DE LA ELIMINACION?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            If EliminarSecado(emp_, cent_, fec_) = True Then
                'If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                'End If

                lvSECADOS.SelectedItems.Item(0).Remove()
                RestaSecado()

                LlenaGrillaSecados()
            End If
        End If

        Exit Sub
    End Sub


    Public Sub RestaSecado()
        Label85.Text = Str(Val(Label85.Text) - 1).Trim
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrillaSecados()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()

        'SaveSN.SelectedNode.ForeColor = Color.AntiqueWhite

        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvSECADOS.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL REV PP:  " : tot(0, 1) = Label85.Text.Trim
        'tot(1, 0) = "DIFERENCIAS BASTON: " : tot(1, 1) = Label9.Text.Trim
        'tot(2, 0) = "DIFERENCIAS CONSULTA: " : tot(2, 1) = Label13.Text.Trim

        ExportToExcelGrilla(lvSECADOS, tot)
    End Sub



    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        'frmRevPostPartosIngresoDIIO.Param0_ModoIngreso = 0
        'frmRevPostPartosIngresoDIIO.Param1_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        If cboCentros.Text = "(TODOS)" Then
            frmRevPostPartosIngresoDIIO.Param2_NombreCentro = ""
        Else
            frmRevPostPartosIngresoDIIO.Param2_NombreCentro = cboCentros.Text.Trim
        End If

        'frmRevPostPartosIngresoDIIO.cboCentros.Text = cboCentros.Text

        frmRevPostPartosIngresoDIIO.MdiParent = frmMAIN
        frmRevPostPartosIngresoDIIO.Show()
        frmRevPostPartosIngresoDIIO.BringToFront()


        'With frmRevPostPartosIngreso
        '    '.CodigoSecado = 0
        '    .Param0_ModoIngreso = 1        '1=nuevo  /  2=edicion

        '    .MdiParent = frmMAIN
        '    .Show()
        '    .BringToFront()
        'End With

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Private Sub dtpFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
    End Sub



    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvSECADOS.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrden.Text = lvSECADOS.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrden.Text = lblOrden.Text + " -> " + lvSECADOS.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvSECADOS.MouseDoubleClick
        If lvSECADOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleRevPP()
        End If
    End Sub


    Private Sub frmPalpaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Razas.Cargar()
        General.CondicionesRevPP.Cargar()
        General.TipoDesechos.Cargar()
        General.EstProductivos.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        dtpFechaDesde.Value = Now
        dtpFechaHasta.Value = Now

        cboCentros.SelectedIndex = 0
    End Sub
End Class