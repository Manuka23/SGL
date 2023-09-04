

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmFarmacos
    '    Private TipoReporte As Integer = 0

    'contabilizacion
    Private Total_Insem As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "FarmCodigo", "FarmNombre", "NomPatologia", "FarmDiasTratamiento", "FarmDiasResguardo", "FarmVigente", "FarmGlosaTratamiento"}
    Private CadenaOrden As String = "FarmCodigo"



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


    Public Sub ConsultaFarmacos(ByVal patologia_ As Integer, ByVal vigente_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spFarmacos_Listado2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodPatologia", patologia_)
        cmd.Parameters.AddWithValue("@FarmVigente", vigente_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvFARMACOS.BeginUpdate()
        lvFARMACOS.Items.Clear()

        Dim i As Integer = 0
        Dim ivig_ As String
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

                    ivig_ = ""
                    If rdr("FarmVigente") = 1 Then ivig_ = "SI"

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("EmpCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("FarmCodigo").ToString.Trim)                  'codigo farmaco
                    item.SubItems.Add(rdr("FarmNombre").ToString.Trim)
                    item.SubItems.Add(rdr("NomPatologia").ToString.Trim)                  'patologia
                    item.SubItems.Add(rdr("FarmDiasTratamiento").ToString.Trim)
                    item.SubItems.Add(rdr("FarmDiasResguardo").ToString.Trim)
                    item.SubItems.Add(ivig_)
                    item.SubItems.Add(rdr("FarmGlosaTratamiento").ToString.Trim)
                    item.SubItems.Add(rdr("CodPatologia").ToString.Trim)
                    ''
                    lvFARMACOS.Items.Add(item)

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
        lvFARMACOS.EndUpdate()
        'Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Public Sub LlenaGrilla()
        Dim pat_ As Integer = 0
        Dim vig_ As Integer = -1

        If cboPatologias.SelectedIndex <> -1 And cboPatologias.Text <> "(TODOS)" Then
            pat_ = General.Patologias.Codigo(cboPatologias.SelectedIndex)
        End If

        If cboVigente.SelectedIndex <> -1 And cboVigente.Text <> "(TODOS)" Then
            vig_ = IIf(cboVigente.Text = "SI", 1, 0)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "FarmCodigo"
            lblOrdena.Text = "Código Farmaco"
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaFarmacos(pat_, vig_)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Function EliminarFarmaco() As Boolean
        EliminarFarmaco = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spFarmacos_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim farm_ As Integer = lvFARMACOS.SelectedItems(0).SubItems(2).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@FarmCodigo", farm_)
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

            EliminarFarmaco = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function FarmacoVigente(ByVal vig_ As Integer) As Boolean
        FarmacoVigente = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spFarmacos_Vigente", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim farm_ As Integer = lvFARMACOS.SelectedItems(0).SubItems(2).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@FarmCodigo", farm_)
        cmd.Parameters.AddWithValue("@FarmVigente", vig_)
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

            FarmacoVigente = True

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
        If lvFARMACOS.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL FARMACOS " : tot(0, 1) = Label48.Text.Trim

        ExportToExcelGrilla(lvFARMACOS, tot)
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        'frmFarmacosIngreso.Param1_Modo = 1   'nueva muerte

        frmFarmacosIngreso.MdiParent = frmMAIN
        frmFarmacosIngreso.Show()
        frmFarmacosIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvFARMACOS.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvFARMACOS.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvFARMACOS.Columns(e.Column).Text
        End If
    End Sub


    Private Sub frmFarmacos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Patologias.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLlenaVS()
        CboLLenaPatologias(cboPatologias, True)

        cboPatologias.SelectedIndex = 0
        cboVigente.SelectedIndex = 0
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvFARMACOS.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR EL REGISTRO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarFarmaco() = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuToroVigente_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsemVigente.Click
        If lvFARMACOS.SelectedItems.Count = 0 Then Exit Sub

        If FarmacoVigente(1) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuToroQuitarVigente_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsemQuitarVigente.Click
        If lvFARMACOS.SelectedItems.Count = 0 Then Exit Sub

        If FarmacoVigente(0) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub cboPatologias_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPatologias.SelectedIndexChanged, cboVigente.SelectedIndexChanged
        btnBuscar.PerformClick()
    End Sub
End Class