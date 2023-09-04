Imports System.Data.SqlClient

Public Class FrmDecomisosDetalle

    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "Diio", "CategCod", "CategNom", "VtaFecha", "CauCodigo", "CauNombre"}

    Private CadenaOrden As String = "VtaFecha, Diio"

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmDecomisosDetalle_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmDecomisosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvDecomisosDIIOs.Enabled = False
        LlenaCentrosCbo()
        'Deja el Centro por defecto en Combo Box
        Dim CentroDefault As String = NombreCentroUsuario
        For regCbo = 0 To cboCentros.Items.Count - 1
            If cboCentros.Items(regCbo) = CentroDefault Then
                cboCentros.SelectedIndex = regCbo
            End If
        Next
        cboAño.SelectedIndex = 0
        lblCausaNom.Text = ""
        lblOrden2.Text = ""
    End Sub


    Public Sub LlenaCentrosCbo()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim centroCod_ As String = "" 'CODIGO DEL CENTRO
        Dim pos_ As Integer = 0
        'Obtener el Codigo del Centro
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            For i = 0 To General.CentrosUsuario.NroRegistros - 1
                If General.CentrosUsuario.Nombre(i) = cboCentros.Text Then
                    pos_ = i
                End If
            Next
            centroCod_ = General.CentrosUsuario.Codigo(pos_)
        End If

        Dim añoDecomiso_ As Integer = CInt(cboAño.Text.Trim)

        Cursor.Current = Cursors.WaitCursor
        'Busca los datos con lo seleccionado en los ComboBox
        ConsultaDecomisos(centroCod_, añoDecomiso_)
        ConsultaDecomisosRanking(añoDecomiso_)
        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ConsultaDecomisos(ByVal centro_ As String, ByVal año_ As String)
        lblTotRegCausas.Text = "0"
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Dim EneAcum As Integer = 0
        Dim FebAcum As Integer = 0
        Dim MarAcum As Integer = 0
        Dim AbrAcum As Integer = 0
        Dim MayAcum As Integer = 0
        Dim JunAcum As Integer = 0
        Dim JulAcum As Integer = 0
        Dim AgoAcum As Integer = 0
        Dim SepAcum As Integer = 0
        Dim OctAcum As Integer = 0
        Dim NovAcum As Integer = 0
        Dim DicAcum As Integer = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_DetalleCausas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Año", año_)
        'cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        'cmd.Parameters.Add("@CountReg", SqlDbType.Int) : cmd.Parameters("@CountReg").Direction = ParameterDirection.Output

        lvDecomisosCausas.BeginUpdate()
        lvDecomisosCausas.Items.Clear()

        Dim i As Integer = 0
        Dim TotRegs As Integer = 0
        Dim CountRegListView As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If TotRegs = 0 Then
                        TotRegs = rdr("CountRegs")
                        pbProcesa.Maximum = TotRegs
                    End If

                    '1.- Revisar si el Centro ya esta en el List View
                    CountRegListView = lvDecomisosCausas.Items.Count


                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

                    item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("CauCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("CauNombre").ToString.Trim)
                    '###### ENERO ######
                    Dim EneVal As String = rdr("ENE").ToString.Trim
                    EneAcum = EneAcum + CInt(rdr("ENE").ToString.Trim)
                    If EneVal = "0" Then EneVal = "-"
                    item.SubItems.Add(EneVal)
                    '###### FEBRERO ######
                    Dim FebVal As String = rdr("FEB").ToString.Trim
                    FebAcum = FebAcum + CInt(rdr("FEB").ToString.Trim)
                    If FebVal = "0" Then FebVal = "-"
                    item.SubItems.Add(FebVal)
                    '###### MARZO ######
                    Dim MarVal As String = rdr("MAR").ToString.Trim
                    MarAcum = MarAcum + CInt(rdr("MAR").ToString.Trim)
                    If MarVal = "0" Then MarVal = "-"
                    item.SubItems.Add(MarVal)
                    '###### ABRIL ######
                    Dim AbrVal As String = rdr("ABR").ToString.Trim
                    AbrAcum = AbrAcum + CInt(rdr("ABR").ToString.Trim)
                    If AbrVal = "0" Then AbrVal = "-"
                    item.SubItems.Add(AbrVal)
                    '###### MAYO ######
                    Dim MayVal As String = rdr("MAY").ToString.Trim
                    MayAcum = MayAcum + CInt(rdr("MAY").ToString.Trim)
                    If MayVal = "0" Then MayVal = "-"
                    item.SubItems.Add(MayVal)
                    '###### JUNIO ######
                    Dim JunVal As String = rdr("JUN").ToString.Trim
                    JunAcum = JunAcum + CInt(rdr("JUN").ToString.Trim)
                    If JunVal = "0" Then JunVal = "-"
                    item.SubItems.Add(JunVal)
                    '###### JULIO ######
                    Dim JulVal As String = rdr("JUL").ToString.Trim
                    JulAcum = JulAcum + CInt(rdr("JUL").ToString.Trim)
                    If JulVal = "0" Then JulVal = "-"
                    item.SubItems.Add(JulVal)
                    '###### AGOSTO ######
                    Dim AgoVal As String = rdr("AGO").ToString.Trim
                    AgoAcum = AgoAcum + CInt(rdr("AGO").ToString.Trim)
                    If AgoVal = "0" Then AgoVal = "-"
                    item.SubItems.Add(AgoVal)
                    '###### SEPTIEMBRE ######
                    Dim SepVal As String = rdr("SEP").ToString.Trim
                    SepAcum = SepAcum + CInt(rdr("SEP").ToString.Trim)
                    If SepVal = "0" Then SepVal = "-"
                    item.SubItems.Add(SepVal)
                    '###### OCTUBRE ######
                    Dim OctVal As String = rdr("OCT").ToString.Trim
                    OctAcum = OctAcum + CInt(rdr("OCT").ToString.Trim)
                    If OctVal = "0" Then OctVal = "-"
                    item.SubItems.Add(OctVal)
                    '###### NOVIEMBRE ######
                    Dim NovVal As String = rdr("NOV").ToString.Trim
                    NovAcum = NovAcum + CInt(rdr("NOV").ToString.Trim)
                    If NovVal = "0" Then NovVal = "-"
                    item.SubItems.Add(NovVal)
                    '###### DICIEMBRE ######
                    Dim DicVal As String = rdr("DIC").ToString.Trim
                    DicAcum = DicAcum + CInt(rdr("DIC").ToString.Trim)
                    If DicVal = "0" Then DicVal = "-"
                    item.SubItems.Add(DicVal)

                    Dim TotalAño As Integer = (CInt(rdr("ENE").ToString.Trim) + CInt(rdr("FEB").ToString.Trim) + CInt(rdr("MAR").ToString.Trim) + _
                                                CInt(rdr("ABR").ToString.Trim) + CInt(rdr("MAY").ToString.Trim) + CInt(rdr("JUN").ToString.Trim) + _
                                                CInt(rdr("JUL").ToString.Trim) + CInt(rdr("AGO").ToString.Trim) + CInt(rdr("SEP").ToString.Trim) + _
                                                CInt(rdr("OCT").ToString.Trim) + CInt(rdr("NOV").ToString.Trim) + CInt(rdr("DIC").ToString.Trim))
                    item.SubItems.Add(TotalAño)
                    lvDecomisosCausas.Items.Add(item)

                    pbProcesa.Value = i
                    i = i + 1

                End While
                'TotalesPorMes()
                lblTotRegCausas.Text = lvDecomisosCausas.Items.Count
                Dim item2 As New ListViewItem("")

                'item2.UseItemStyleForSubItems = False
                'item2.Font = New Font(lvDecomisosCausas.Font, FontStyle.Bold)
                item2.SubItems.Add("***")
                item2.SubItems.Add("")
                item2.SubItems.Add("TOTAL MENSUAL")
                item2.SubItems.Add(EneAcum)
                item2.SubItems.Add(FebAcum)
                item2.SubItems.Add(MarAcum)
                item2.SubItems.Add(AbrAcum)
                item2.SubItems.Add(MayAcum)
                item2.SubItems.Add(JunAcum)
                item2.SubItems.Add(JulAcum)
                item2.SubItems.Add(AgoAcum)
                item2.SubItems.Add(SepAcum)
                item2.SubItems.Add(OctAcum)
                item2.SubItems.Add(NovAcum)
                item2.SubItems.Add(DicAcum)
                item2.SubItems.Add(EneAcum + FebAcum + MarAcum + AbrAcum + MayAcum + JunAcum + JulAcum + AgoAcum + SepAcum + OctAcum + NovAcum + DicAcum + DicAcum)
                'item2.SubItems(i).Font = New Font(lvDecomisosCausas.Font, FontStyle.Bold)
                lvDecomisosCausas.Items.Add(item2) '.Text = Font.Bold
                lvDecomisosCausas.Items(i).BackColor = System.Drawing.Color.Goldenrod
                lvDecomisosCausas.Items(i).Text = Font.Bold
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
        lvDecomisosCausas.EndUpdate()
        pnlProcesa.Visible = False
        'TotalReg()
    End Sub

    Public Sub ConsultaDecomisosRanking(ByVal Año_ As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_DetalleCausasRanking", con)
        Dim rdr As SqlDataReader = Nothing

        lblAñoRanking.Text = CStr(Año_)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Año", Año_)
        'cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        lvCausasRanking.BeginUpdate()
        lvCausasRanking.Items.Clear()

        Dim i As Integer = 0
        Dim TotRegs As Integer = 0
        Dim CountRegListView As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If TotRegs = 0 Then
                    '    TotRegs = rdr("CountRegs")
                    '    pbProcesa.Maximum = TotRegs
                    'End If

                    '1.- Revisar si el Centro ya esta en el List View
                    CountRegListView = lvDecomisosCausas.Items.Count

                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

                    item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("CauCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("CauNombre").ToString.Trim)
                    item.SubItems.Add(rdr("CntDecomisados").ToString.Trim) '

                    lvCausasRanking.Items.Add(item)

                    'pbProcesa.Value = i
                    i = i + 1

                End While
                lvCausasRanking.Items(0).BackColor = System.Drawing.Color.Yellow
                lvCausasRanking.Items(0).ForeColor = System.Drawing.Color.Red
                'pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
SalirProc:
        lvCausasRanking.EndUpdate()
    End Sub

    Private Sub lvDecomisosCausas_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvDecomisosCausas.MouseClick
        If lvDecomisosCausas.Items.Count = 0 Then Exit Sub

        lvDecomisosDIIOs.Enabled = True
        Dim CodCausa As String = lvDecomisosCausas.SelectedItems.Item(0).SubItems(2).Text
        Dim NomCausa As String = lvDecomisosCausas.SelectedItems.Item(0).SubItems(3).Text
        Dim añoDecomiso_ As Integer = CInt(cboAño.Text.Trim)
        If CadenaOrden = "" Then
            CadenaOrden = "VtaFecha, Diio"
            lblOrden2.Text = "Fecha Vta. -> DIIO"
            lblOrden2.Refresh()
        End If

        'Controla que si elige el Total, no haga NADA 
        If CodCausa = "" Then
            lblCausaNom.Text = ""
            lvDecomisosDIIOs.Items.Clear()
            lvDecomisosDIIOs.Enabled = False
            Exit Sub
        End If


        lblCausaNom.Text = NomCausa
        DetalleDecomisosDIIOs(CInt(CodCausa), añoDecomiso_)
    End Sub

    Private Sub DetalleDecomisosDIIOs(ByVal CodigoCausas_ As Integer, ByVal Año_ As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_DetalleCausasDIIOs", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodCausa", CodigoCausas_)
        cmd.Parameters.AddWithValue("@Año", Año_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        'cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        'cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar) : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output
        lvDecomisosDIIOs.BeginUpdate()
        lvDecomisosDIIOs.Items.Clear()

        Dim i As Integer = 0
        Dim TotRegs As Integer = 0
        Dim CountRegListView As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If TotRegs = 0 Then
                    '    TotRegs = rdr("CountRegs")
                    '    pbProcesa.Maximum = TotRegs
                    'End If

                    '1.- Revisar si el Centro ya esta en el List View
                    CountRegListView = lvDecomisosDIIOs.Items.Count
                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

                    item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("Diio").ToString.Trim)
                    item.SubItems.Add(rdr("CategoCod").ToString.Trim)
                    item.SubItems.Add(rdr("Categoria").ToString.Trim)
                    item.SubItems.Add(rdr("VtaFecha").ToString.Trim)
                    item.SubItems.Add(rdr("CausaCodVta").ToString.Trim)
                    item.SubItems.Add(rdr("CausaNomVta").ToString.Trim)


                    lvDecomisosDIIOs.Items.Add(item)

                    'pbProcesa.Value = i
                    i = i + 1

                End While
                lblTotRegDetDiios.Text = lvDecomisosDIIOs.Items.Count
                'pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
SalirProc:
        lvDecomisosDIIOs.EndUpdate()

    End Sub

    Private Sub lvDecomisosDIIOs_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDecomisosDIIOs.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrden2.Text = lvDecomisosDIIOs.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrden2.Text = lblOrden2.Text + " -> " + lvDecomisosDIIOs.Columns(e.Column).Text
        End If
    End Sub


End Class