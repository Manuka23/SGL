Imports System.Data.SqlClient

Public Class FrmDecomisos

    Private Sub dtpFechaDesde_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
    End Sub
    Private Sub FrmDecomisos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub FrmDecomisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.CausasDecomisos.Cargar()
        Dim fechaIni As String = Format(Now, "dd-mm-yyyy")
        fechaIni = "01-01-" + fechaIni.Substring(6, 4)
        dtpFechaDesde.Value = fechaIni
        dtpFechaHasta.Value = Now
        LlenaCentrosCbo()
        'Deja el Centro por defecto en Combo Box
        Dim CentroDefault As String = NombreCentroUsuario
        For regCbo = 0 To cboCentros.Items.Count - 1
            If cboCentros.Items(regCbo) = CentroDefault Then
                cboCentros.SelectedIndex = regCbo
            End If
        Next
        cboAño.SelectedIndex = 0
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
        ConsultaDecomisos(centroCod_, añoDecomiso_) ' List View Arriba
        ConsultaVtas(centroCod_, añoDecomiso_) ' Agrega Datos al List View de Arriba
        ConsultaDecomisosPorCategoria(centroCod_, añoDecomiso_) ' List View Abajo
        Cursor.Current = Cursors.Default
    End Sub

    Private ultPosLV As Integer = 0
    Private EneAcum As Integer = 0
    Private FebAcum As Integer = 0
    Private MarAcum As Integer = 0
    Private AbrAcum As Integer = 0
    Private MayAcum As Integer = 0
    Private JunAcum As Integer = 0
    Private JulAcum As Integer = 0
    Private AgoAcum As Integer = 0
    Private SepAcum As Integer = 0
    Private OctAcum As Integer = 0
    Private NovAcum As Integer = 0
    Private DicAcum As Integer = 0
    Private TotAcumDec As Integer = 0
    Public Sub ConsultaDecomisos(ByVal centro_ As String, ByVal año_ As String)
        lblTotReg.Text = "0"
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()



        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_ConsultaGeneral", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Año", año_)
        'cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        'cmd.Parameters.Add("@CountReg", SqlDbType.Int) : cmd.Parameters("@CountReg").Direction = ParameterDirection.Output

        lvDecomisos.BeginUpdate()
        lvDecomisos.Items.Clear()

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
                    CountRegListView = lvDecomisos.Items.Count


                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

                    item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)
                    item.SubItems.Add(rdr("CenNom").ToString.Trim)
                    'item.SubItems.Add(rdr("RCSCentroCod").ToString.Trim)
                    'item.SubItems.Add(rdr("RCSCentroNom").ToString.Trim)
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
                    lvDecomisos.Items.Add(item)

                    pbProcesa.Value = i
                    i = i + 1

                End While
                'Totales Por Mes - Se agrega una Fila con Los TOTALES
                Dim item2 As New ListViewItem("")

                'item2.UseItemStyleForSubItems = False
                'item2.Font = New Font(lvDecomisos.Font, FontStyle.Bold)
                item2.SubItems.Add("***")
                item2.SubItems.Add("")
                item2.SubItems.Add("TOTAL MENSUAL DECOMISADO")
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
                TotAcumDec = EneAcum + FebAcum + MarAcum + AbrAcum + MayAcum + JunAcum + JulAcum + AgoAcum + SepAcum + OctAcum + NovAcum + DicAcum + DicAcum
                item2.SubItems.Add(TotAcumDec)
                'item2.SubItems(i).Font = New Font(lvDecomisos.Font, FontStyle.Bold)
                lvDecomisos.Items.Add(item2) '.Text = Font.Bold
                lvDecomisos.Items(i).BackColor = System.Drawing.Color.Goldenrod
                lvDecomisos.Items(i).Text = Font.Bold
                pbProcesa.Value = pbProcesa.Maximum
                ultPosLV = i
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
SalirProc:
        lvDecomisos.EndUpdate()
        pnlProcesa.Visible = False
        TotalReg()
    End Sub

    Private EneTotVtas As Integer = 0
    Private FebTotVtas As Integer = 0
    Private MarTotVtas As Integer = 0
    Private AbrTotVtas As Integer = 0
    Private MayTotVtas As Integer = 0
    Private JunTotVtas As Integer = 0
    Private JulTotVtas As Integer = 0
    Private AgoTotVtas As Integer = 0
    Private SepTotVtas As Integer = 0
    Private OctTotVtas As Integer = 0
    Private NovTotVtas As Integer = 0
    Private DicTotVtas As Integer = 0
    Public Sub ConsultaVtas(ByVal centro_ As String, ByVal año_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDecomisos_ConsultaVentas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Año", año_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        lvDecomisos.BeginUpdate()
        'lvDecomisos.Items.Clear()

        Dim i As Integer = 0
        Dim TotRegs As Integer = 0
        Dim CountRegListView As Integer = 0

        Dim TotalAñoVtas As Integer
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()

                    '1.- Revisar si el Centro ya esta en el List View
                    'CountRegListView = lvDecomisos.Items.Count


                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

                    item.SubItems.Add("Vtas")
                    item.SubItems.Add("")
                    item.SubItems.Add("TOTAL VENTAS")
                    '###### ENERO ######
                    Dim EneVal As String = rdr("ENE").ToString.Trim
                    EneTotVtas = CInt(rdr("ENE").ToString.Trim)
                    If EneVal = "0" Then EneVal = "-"
                    item.SubItems.Add(EneVal)
                    '###### FEBRERO ######
                    Dim FebVal As String = rdr("FEB").ToString.Trim
                    FebTotVtas = CInt(rdr("FEB").ToString.Trim)
                    If FebVal = "0" Then FebVal = "-"
                    item.SubItems.Add(FebVal)
                    '###### MARZO ######
                    Dim MarVal As String = rdr("MAR").ToString.Trim
                    MarTotVtas = CInt(rdr("MAR").ToString.Trim)
                    If MarVal = "0" Then MarVal = "-"
                    item.SubItems.Add(MarVal)
                    '###### ABRIL ######
                    Dim AbrVal As String = rdr("ABR").ToString.Trim
                    AbrTotVtas = CInt(rdr("ABR").ToString.Trim)
                    If AbrVal = "0" Then AbrVal = "-"
                    item.SubItems.Add(AbrVal)
                    '###### MAYO ######
                    Dim MayVal As String = rdr("MAY").ToString.Trim
                    MayTotVtas = CInt(rdr("MAY").ToString.Trim)
                    If MayVal = "0" Then MayVal = "-"
                    item.SubItems.Add(MayVal)
                    '###### JUNIO ######
                    Dim JunVal As String = rdr("JUN").ToString.Trim
                    JunTotVtas = CInt(rdr("JUN").ToString.Trim)
                    If JunVal = "0" Then JunVal = "-"
                    item.SubItems.Add(JunVal)
                    '###### JULIO ######
                    Dim JulVal As String = rdr("JUL").ToString.Trim
                    JulTotVtas = CInt(rdr("JUL").ToString.Trim)
                    If JulVal = "0" Then JulVal = "-"
                    item.SubItems.Add(JulVal)
                    '###### AGOSTO ######
                    Dim AgoVal As String = rdr("AGO").ToString.Trim
                    AgoTotVtas = CInt(rdr("AGO").ToString.Trim)
                    If AgoVal = "0" Then AgoVal = "-"
                    item.SubItems.Add(AgoVal)
                    '###### SEPTIEMBRE ######
                    Dim SepVal As String = rdr("SEP").ToString.Trim
                    SepTotVtas = CInt(rdr("SEP").ToString.Trim)
                    If SepVal = "0" Then SepVal = "-"
                    item.SubItems.Add(SepVal)
                    '###### OCTUBRE ######
                    Dim OctVal As String = rdr("OCT").ToString.Trim
                    OctTotVtas = CInt(rdr("OCT").ToString.Trim)
                    If OctVal = "0" Then OctVal = "-"
                    item.SubItems.Add(OctVal)
                    '###### NOVIEMBRE ######
                    Dim NovVal As String = rdr("NOV").ToString.Trim
                    NovTotVtas = CInt(rdr("NOV").ToString.Trim)
                    If NovVal = "0" Then NovVal = "-"
                    item.SubItems.Add(NovVal)
                    '###### DICIEMBRE ######
                    Dim DicVal As String = rdr("DIC").ToString.Trim
                    DicTotVtas = CInt(rdr("DIC").ToString.Trim)
                    If DicVal = "0" Then DicVal = "-"
                    item.SubItems.Add(DicVal)

                    TotalAñoVtas = (EneTotVtas + FebTotVtas + MarTotVtas + AbrTotVtas + MayTotVtas + JunTotVtas + _
                                    JulTotVtas + AgoTotVtas + SepTotVtas + OctTotVtas + NovTotVtas + DicTotVtas)
                    item.SubItems.Add(TotalAñoVtas)
                    lvDecomisos.Items.Add(item)

                End While

                lvDecomisos.Items(ultPosLV + 1).BackColor = System.Drawing.Color.LightGreen
                lvDecomisos.Items(ultPosLV + 1).Text = Font.Bold

                'Dim percent As New Porcentaje
                Dim item2 As New ListViewItem("")    'primera columna, para ordenar los datos
                item2.SubItems.Add("%")
                item2.SubItems.Add("")
                item2.SubItems.Add("% DECOMISADO")
                item2.SubItems.Add(CalcPorcentaje(EneAcum, EneTotVtas))
                item2.SubItems.Add(CalcPorcentaje(FebAcum, FebTotVtas))
                item2.SubItems.Add(CalcPorcentaje(MarAcum, MarTotVtas))
                item2.SubItems.Add(CalcPorcentaje(AbrAcum, AbrTotVtas))
                item2.SubItems.Add(CalcPorcentaje(MayAcum, MayTotVtas))
                item2.SubItems.Add(CalcPorcentaje(JunAcum, JunTotVtas))
                item2.SubItems.Add(CalcPorcentaje(JulAcum, JulTotVtas))
                item2.SubItems.Add(CalcPorcentaje(AgoAcum, AgoTotVtas))
                item2.SubItems.Add(CalcPorcentaje(SepAcum, SepTotVtas))
                item2.SubItems.Add(CalcPorcentaje(OctAcum, OctTotVtas))
                item2.SubItems.Add(CalcPorcentaje(NovAcum, NovTotVtas))
                item2.SubItems.Add(CalcPorcentaje(DicAcum, DicTotVtas))
                item2.SubItems.Add(CalcPorcentaje(TotAcumDec, TotalAñoVtas))
                lvDecomisos.Items.Add(item2)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
SalirProc:
        lvDecomisos.EndUpdate()
    End Sub




    Public Sub ConsultaDecomisosPorCategoria(ByVal centro_ As String, ByVal año_ As String)
        lblTotReg.Text = "0"
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
        Dim cmd As New SqlCommand("spDecomisos_ConsultaGeneralCategorias", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@Año", año_)
        'cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        'cmd.Parameters.Add("@CountReg", SqlDbType.Int) : cmd.Parameters("@CountReg").Direction = ParameterDirection.Output

        lvDecomisosCateg.BeginUpdate()
        lvDecomisosCateg.Items.Clear()

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
                    CountRegListView = lvDecomisosCateg.Items.Count


                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

                    item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("CategoCod").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    'item.SubItems.Add(rdr("RCSCentroCod").ToString.Trim)
                    'item.SubItems.Add(rdr("RCSCentroNom").ToString.Trim)
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
                    lvDecomisosCateg.Items.Add(item)

                    pbProcesa.Value = i
                    i = i + 1

                End While
                'TotalesPorMes()
                Dim item2 As New ListViewItem("")

                'item2.UseItemStyleForSubItems = False
                'item2.Font = New Font(lvDecomisos.Font, FontStyle.Bold)
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
                'item2.SubItems(i).Font = New Font(lvDecomisos.Font, FontStyle.Bold)
                lvDecomisosCateg.Items.Add(item2) '.Text = Font.Bold
                lvDecomisosCateg.Items(i).BackColor = System.Drawing.Color.Goldenrod
                lvDecomisosCateg.Items(i).Text = Font.Bold
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
        lvDecomisosCateg.EndUpdate()
        pnlProcesa.Visible = False
        'TotalReg()
    End Sub

    Public Sub TotalReg()
        lblTotReg.Text = lvDecomisos.Items.Count
    End Sub



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        FrmDecomisosIngreso.MdiParent = frmMAIN
        FrmDecomisosIngreso.Show()
        FrmDecomisosIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerDetalle.Click
        Cursor.Current = Cursors.WaitCursor

        FrmDecomisosDetalle.MdiParent = frmMAIN
        FrmDecomisosDetalle.Show()
        FrmDecomisosDetalle.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub
End Class