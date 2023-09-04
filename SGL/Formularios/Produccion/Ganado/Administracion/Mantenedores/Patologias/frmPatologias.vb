

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmPatologias
    '    Private TipoReporte As Integer = 0

    'contabilizacion
    Private Total_Insem As Integer = 0
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "CodPatologia", "NomPatologia", "EstPatologia", "ObsPatologia"}
    Private CadenaOrden As String = "CodPatologia"

    Private Sub llvPATOLOGIAS_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvPATOLOGIAS.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvPATOLOGIAS, e)
    End Sub

    Private Sub InicializaTotales()
        Total_Insem = 0
    End Sub


    'Private Sub ProcesaTotales(ByVal mue_ As Integer)
    '    If mue_ <> 0 Then
    '        Total_Insem = Total_Insem + mue_
    '    End If
    'End Sub


    Private Sub MuestraTotales()
        'Label85.Text = Total_General.ToString.Trim

        Label48.Text = Total_Insem.ToString.Trim()

        pnlTotales.Refresh()
    End Sub


    Private Sub CboLlenaVS()
        cboVigente.Items.Add("(TODOS)")
        cboVigente.Items.Add("SI")
        cboVigente.Items.Add("NO")
    End Sub


    Public Sub ConsultaPatologias(ByVal vigente_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPatologias_Listado2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Vigente", vigente_)
        'cmd.Parameters.AddWithValue("@Externo", externo_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvPATOLOGIAS.BeginUpdate()
        lvPATOLOGIAS.Items.Clear()

        Dim i As Integer = 0
        Dim vig_ As String
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

                    vig_ = ""
                    If rdr("EstPatologia") = 1 Then vig_ = "SI"

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("EmpCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("CodPatologia").ToString.Trim)                  'centro
                    item.SubItems.Add(rdr("NomPatologia").ToString.Trim)
                    item.SubItems.Add(vig_)
                    item.SubItems.Add(rdr("ObsPatologia").ToString.Trim)
                    item.SubItems.Add(rdr("EsPreventivo").ToString.Trim)
                    item.SubItems.Add(rdr("ReqCuartos").ToString.Trim)
                    ''
                    lvPATOLOGIAS.Items.Add(item)

                    Total_Insem = Total_Insem + 1

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
        lvPATOLOGIAS.EndUpdate()
        'Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Public Sub LlenaGrilla()
        Dim vig_ As Integer = -1

        If cboVigente.SelectedIndex <> -1 And cboVigente.Text <> "(TODOS)" Then
            vig_ = IIf(cboVigente.Text = "SI", 1, 0)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "CodPatologia"
            lblOrdena.Text = "Código"
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaPatologias(vig_)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Function EliminarPatologia() As Boolean
        EliminarPatologia = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPatologias_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim insem_ As String = lvPATOLOGIAS.SelectedItems(0).SubItems(2).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodPatologia", insem_)
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

            EliminarPatologia = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function PatologiaVigente(ByVal vig_ As Integer) As Boolean
        PatologiaVigente = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPatologias_Vigente", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim cod_ As String = lvPATOLOGIAS.SelectedItems(0).SubItems(2).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodPatologia", cod_)
        cmd.Parameters.AddWithValue("@EstPatologia", vig_)
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

            PatologiaVigente = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


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
        If lvPATOLOGIAS.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL PATOLOGIAS " : tot(0, 1) = Label48.Text.Trim

        ExportToExcelGrilla(lvPATOLOGIAS, tot)
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        'frmPatologiasIngreso.Param1_Modo = 1   'nueva muerte

        frmPatologiasIngreso.MdiParent = frmMAIN
        frmPatologiasIngreso.lblTipoCarga.Text = 0
        frmPatologiasIngreso.Show()
        frmPatologiasIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPATOLOGIAS.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvPATOLOGIAS.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvPATOLOGIAS.Columns(e.Column).Text
        End If
    End Sub


    Private Sub frmPatologias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLlenaVS()

        cboVigente.SelectedIndex = 0
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvPATOLOGIAS.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR EL REGISTRO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarPatologia() = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuToroVigente_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsemVigente.Click
        If lvPATOLOGIAS.SelectedItems.Count = 0 Then Exit Sub

        If PatologiaVigente(1) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuToroQuitarVigente_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsemQuitarVigente.Click
        If lvPATOLOGIAS.SelectedItems.Count = 0 Then Exit Sub

        If PatologiaVigente(0) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub cboVigente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboVigente.SelectedIndexChanged
        btnBuscar.PerformClick()
    End Sub

    Private Sub lvPATOLOGIAS_DoubleClick(sender As Object, e As EventArgs) Handles lvPATOLOGIAS.DoubleClick
        If lvPATOLOGIAS.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim Patologia As New frmPatologiasIngreso
        Dim CodPatologia As String = lvPATOLOGIAS.SelectedItems.Item(0).SubItems(2).Text
        Dim Nombre As String = lvPATOLOGIAS.SelectedItems.Item(0).SubItems(3).Text
        Dim Vigente As String = lvPATOLOGIAS.SelectedItems.Item(0).SubItems(4).Text
        Dim Obs As String = lvPATOLOGIAS.SelectedItems.Item(0).SubItems(5).Text
        Dim Prev As String = lvPATOLOGIAS.SelectedItems.Item(0).SubItems(6).Text
        Dim Cuartos As String = lvPATOLOGIAS.SelectedItems.Item(0).SubItems(7).Text

        Patologia.MdiParent = frmMAIN

        Patologia.txtNombre.Text = Nombre
        Patologia.txtObservs.Text = Obs
        Patologia.lblCodPatologia.text = CodPatologia
        'If Vigente = "SI" Then
        '    Patologia.cboVigente.SelectedIndex = 0
        'Else
        '    Patologia.cboVigente.SelectedIndex = 1
        'End If
        If Prev = 1 Then
            Patologia.checkpreventivo.Checked = True
        End If
        If Cuartos = "SI" Then
            Patologia.cbCoja.Checked = True
        End If

        Patologia.lblTipoCarga.Text = 1
        Patologia.Show()

        Cursor.Current = Cursors.Default
    End Sub
End Class