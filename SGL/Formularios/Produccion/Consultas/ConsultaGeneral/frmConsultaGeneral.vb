Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Reporting.WinForms
'Imports Micr .Office.Interop
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmConsultaGeneral


    Private Const VISTA_NORMAL As Integer = 0
    Private Const VISTA_AVANZADA As Integer = 1
    ''
    Private TipoReporte As Integer = 0
    Private TituloReporte As String = "INFORME DE GANADO"

    Private Total_General As Integer = 0

    'contabilizaciones por categoria
    Private TotCat_Terneras As Integer = 0
    Private TotCat_Terneros As Integer = 0
    Private TotCat_Toretes As Integer = 0
    Private TotCat_Toros As Integer = 0
    Private TotCat_Vacas As Integer = 0
    Private TotCat_Vaquillas As Integer = 0

    'contabilizaciones por estados productivos
    Private TotEP_Descarte As Integer = 0
    Private TotEP_Desecho As Integer = 0
    Private TotEP_EliminadaLeche As Integer = 0
    Private TotEP_Produccion As Integer = 0
    Private TotEP_NoAplica As Integer = 0
    Private TotEP_SecaLeche As Integer = 0

    'contabilizaciones por estados reproductivos
    Private TotER_Anestro As Integer = 0
    Private TotER_Cubierta As Integer = 0
    Private TotER_DesechoReprod As Integer = 0
    Private TotER_Dudosa As Integer = 0
    Private TotER_NoAplica As Integer = 0
    Private TotER_Preniada As Integer = 0
    Private TotER_SecaPrn As Integer = 0

    'nombre de los campos en la base de datos, para realizar los ordenamientos desde esta pantalla
    Private CamposOrden As String() = {"", "EmpRut", "CenDesCor", "GndCod", "GndProNom", "GndFecNac", "NomRaza",
                                       "GndEstado", "", "GndEstadoProductivo", "GndEstadoReproductivo", "GndEstadoSalud",
                                       "DiasLactancia", "GndUltFechaRealSecado", "GndUltFechaSecado", "GrpProduccionCod",
                                       "GndUltFechaPriPartos", "GndUltFechaParto", "GndUltFechaPP", "GndUltFechaPrenez",
                                       "GndActPartosNum", "GndUltCubierta", "GndUltCubiertaNum", "ToroNombre", "GndPadre",
                                       "GndMadre", "GndAbuelo", "DiasCelo", "FechaUltCelo",
                                       "NumeroCelos", "TieneIATF", "GndLoteNom", "GndUltFechaPalpacionPP", "GndCondicionPalpacion",
                                       "NacidoEn", "FechaCompra", "GndIsMuestreo", "NroMuestreos", "MuestraTUB", "MuestraLEU", "MuestraBRU",
                                       "GndIsCoja", "NroCojeras", "GndCojerasFecUlt", "GndIsMastitis", "NroMastitis", "GndMastitisFecUlt",
                                       "GndIsOtrosTratamientos", "NroOtrosTratamientos", "GndOtrosTratamientosFecUlt",
                                       "GndIsRevisionPP", "NroRevisionesPP", "UltFecRevPP", "UltCondRevPP", "GndCenSalFec", "CentroSalida",
                                       "", "", ""}

    Private CamposOrdenEstadoFecha As String() = {"GndIsMuertoFecha", "GndIsVendidoFecha", "GndIsDesaparecidoFecha", ""}
    Private CamposOrdenEstadoSalud As String() = {"GndIsSana", "GndIsCoja", "GndIsMastitis", "GndIsOtrosTratamientos", "GndIsMuestreo", "GndIsRevisionPP"}

    Private CadenaOrden As String = "CenDesCor, GndCod"
    Private IdxFechaEstado As Integer = 20


    Private abast As frmAlarmas

    Private ComparaDIIOConsultaGeneral As String() = {}

    Public PColNombres As String() = {}
    Public PColAnchos As Integer() = {}
    Private PColNombresSelec As String() = {}
    Private PColAnchosSelec As Integer() = {}

    Private DatosGrilla As String


    Private Sub InicializaTotales()
        Total_General = 0

        TotCat_Terneras = 0
        TotCat_Terneros = 0
        TotCat_Toretes = 0
        TotCat_Toros = 0
        TotCat_Vacas = 0
        TotCat_Vaquillas = 0

        TotEP_Descarte = 0
        TotEP_Desecho = 0
        TotEP_EliminadaLeche = 0
        TotEP_Produccion = 0
        TotEP_NoAplica = 0
        TotEP_SecaLeche = 0

        TotER_Anestro = 0
        TotER_Cubierta = 0
        TotER_DesechoReprod = 0
        TotER_Dudosa = 0
        TotER_NoAplica = 0
        TotER_Preniada = 0
        TotER_SecaPrn = 0
    End Sub


    Private Sub ProcesaTotales(ByVal cat_ As String, ByVal eprod_ As String, ByVal erep_ As String)
        Select Case cat_
            Case "TERNERAS" : TotCat_Terneras = TotCat_Terneras + 1
            Case "TERNERA EN LECHE" : TotCat_Terneras = TotCat_Terneras + 1
            Case "TERNERA DESTETADA" : TotCat_Terneras = TotCat_Terneras + 1
            Case "TERNERAS OTOÑO" : TotCat_Terneras = TotCat_Terneras + 1
            Case "TERNEROS" : TotCat_Terneros = TotCat_Terneros + 1
            Case "TERNERO EN LECHE" : TotCat_Terneros = TotCat_Terneros + 1
            Case "TERNERO DESTETADA" : TotCat_Terneros = TotCat_Terneros + 1
            Case "TORETES" : TotCat_Toretes = TotCat_Toretes + 1
            Case "TOROS" : TotCat_Toros = TotCat_Toros + 1
            Case "VACAS" : TotCat_Vacas = TotCat_Vacas + 1
            Case "VACAS TRASPASO" : TotCat_Vacas = TotCat_Vacas + 1
            Case "VAQUILLAS" : TotCat_Vaquillas = TotCat_Vaquillas + 1
            Case "VAQUILLAS TRASPASO" : TotCat_Vaquillas = TotCat_Vaquillas + 1
            Case "VAQUILLAS OTOÑO" : TotCat_Vaquillas = TotCat_Vaquillas + 1
        End Select

        Select Case eprod_
            Case "DESCARTE" : TotEP_Descarte = TotEP_Descarte + 1
            Case "DESECHO" : TotEP_Desecho = TotEP_Desecho + 1
            Case "ELIMINADA EN LECHE" : TotEP_EliminadaLeche = TotEP_EliminadaLeche + 1
            Case "EN PRODUCCION" : TotEP_Produccion = TotEP_Produccion + 1
            Case "NO APLICA" : TotEP_NoAplica = TotEP_NoAplica + 1
            Case "SECA DE LECHE" : TotEP_SecaLeche = TotEP_SecaLeche + 1
        End Select

        Select Case erep_
            Case "ANESTRO" : TotER_Anestro = TotER_Anestro + 1
            Case "CUBIERTA" : TotER_Cubierta = TotER_Cubierta + 1
            Case "DESECHO REPRODUCTIVO" : TotER_DesechoReprod = TotER_DesechoReprod + 1
            Case "DUDOSA" : TotER_Dudosa = TotER_Dudosa + 1
            Case "NO APLICA" : TotER_NoAplica = TotER_NoAplica + 1
            Case "PREÑADA" : TotER_Preniada = TotER_Preniada + 1
            Case "SECA PRN" : TotER_SecaPrn = TotER_SecaPrn + 1
        End Select
    End Sub


    Private Sub MuestraTotales()
        Label8.Text = Total_General.ToString.Trim
        Label125.Text = Total_General.ToString.Trim
        Label85.Text = Total_General.ToString.Trim

        Label9.Text = TotCat_Terneras.ToString.Trim
        Label11.Text = TotCat_Terneros.ToString.Trim()
        Label13.Text = TotCat_Toretes.ToString.Trim()
        Label15.Text = TotCat_Toros.ToString.Trim()
        Label17.Text = TotCat_Vacas.ToString.Trim()
        Label19.Text = TotCat_Vaquillas.ToString.Trim()

        Label111.Text = TotEP_Descarte.ToString.Trim()
        Label109.Text = TotEP_Desecho.ToString.Trim()
        Label107.Text = TotEP_EliminadaLeche.ToString.Trim()
        Label105.Text = TotEP_Produccion.ToString.Trim()
        Label103.Text = TotEP_NoAplica.ToString.Trim()
        Label101.Text = TotEP_SecaLeche.ToString.Trim()

        Label59.Text = TotER_Anestro.ToString.Trim()
        Label33.Text = TotER_Cubierta.ToString.Trim()
        Label56.Text = TotER_DesechoReprod.ToString.Trim()
        Label54.Text = TotER_Dudosa.ToString.Trim()
        Label52.Text = TotER_NoAplica.ToString.Trim()
        Label48.Text = TotER_Preniada.ToString.Trim()
        Label34.Text = TotER_SecaPrn.ToString.Trim()

        pnlTotCategoria.Refresh()
        pnlEstProd.Refresh()
        pnlEstReprod.Refresh()
    End Sub


    Private Sub LimpiarFiltros(Optional ByVal LimpiaTipoReporte As Boolean = True, Optional ByVal idx As Integer = 0,
                               Optional ByVal LimpiaEstado As Boolean = True, Optional ByVal idx2 As Integer = 0)
        Dim i As Integer

        If LimpiaTipoReporte = True Then
            TipoReporte = 0
            TituloReporte = "INFORME DE GANADO"

            For i = 0 To chklvTiposReporte.Items.Count - 1
                chklvTiposReporte.SetItemCheckState(i, CheckState.Unchecked)
            Next

            pnltipoReporte.BackColor = Color.SteelBlue

        End If

        If LimpiaEstado = True Then
            For i = 0 To chklvEstados.Items.Count - 1
                chklvEstados.SetItemCheckState(i, CheckState.Unchecked)
            Next

            pnlEstado.BackColor = Color.SteelBlue
        Else
            For i = 0 To chklvEstados.Items.Count - 1
                If i <> idx2 Then
                    chklvEstados.SetItemCheckState(i, CheckState.Unchecked)
                End If
            Next
        End If

        For i = 0 To chklvCentros.Items.Count - 1
            chklvCentros.SetItemCheckState(i, CheckState.Unchecked)
        Next


        For i = 0 To chklvCategorias.Items.Count - 1
            chklvCategorias.SetItemCheckState(i, CheckState.Unchecked)
        Next

        For i = 0 To chklvEstadosProd.Items.Count - 1
            chklvEstadosProd.SetItemCheckState(i, CheckState.Unchecked)
        Next

        For i = 0 To chklvEstadosReprod.Items.Count - 1
            chklvEstadosReprod.SetItemCheckState(i, CheckState.Unchecked)
        Next

        For i = 0 To chklvEstadosSalud.Items.Count - 1
            chklvEstadosSalud.SetItemCheckState(i, CheckState.Unchecked)
        Next

        For i = 0 To chklvOrigen.Items.Count - 1
            chklvOrigen.SetItemCheckState(i, CheckState.Unchecked)
        Next

        pnlCentros.BackColor = Color.SteelBlue
        pnlCategoria.BackColor = Color.SteelBlue
        pnlEstadoProductivo.BackColor = Color.SteelBlue
        pnlEstadoReproductivo.BackColor = Color.SteelBlue
        pnlEstadoSalud.BackColor = Color.SteelBlue
        pnlOrigen.BackColor = Color.SteelBlue
    End Sub


    Private Sub CambiaEstadoFiltro(ByVal chklb As CheckedListBox, ByVal pnl As Panel)
        Dim i As Integer
        Dim HaySeleccionados As Boolean = False

        For i = 0 To chklb.Items.Count - 1
            If chklb.GetItemCheckState(i) = CheckState.Checked Then
                HaySeleccionados = True
                Exit For
            End If
        Next

        If HaySeleccionados Then
            pnl.BackColor = Color.LimeGreen
        Else
            pnl.BackColor = Color.SteelBlue
        End If
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario2.NroRegistros = 0 Then Exit Sub

        Me.SuspendLayout()
        chklvCentros.SuspendLayout()
        chklvCentros.Items.Clear()

        chklvCentros.Items.Add("(OTROS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario2.NroRegistros - 1
            chklvCentros.Items.Add(General.CentrosUsuario2.Nombre(i))
        Next

        chklvCentros.ResumeLayout()
        Me.ResumeLayout()

    End Sub
    Private Sub CboLLenaCategorias()
        If General.Categorias.NroRegistros = 0 Then Exit Sub

        Me.SuspendLayout()
        chklvCategorias.SuspendLayout()
        chklvCategorias.Items.Clear()

        chklvCategorias.Items.Add("(OTROS)")

        Dim i As Integer

        For i = 0 To General.Categorias.NroRegistros - 1
            chklvCategorias.Items.Add(General.Categorias.Nombre(i))
        Next

        chklvCategorias.ResumeLayout()
        Me.ResumeLayout()
    End Sub
    Public Sub CargaCentros2()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCentros_ListadoPorUsuario", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                Me.SuspendLayout()
                chklvCentros.SuspendLayout()
                chklvCentros.Items.Clear()

                chklvCentros.Items.Add("(OTROS)")

                While rdr.Read()
                    chklvCentros.Items.Add(rdr("CenDesCor"))
                End While

                chklvCentros.ResumeLayout()
                Me.ResumeLayout()


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub


    Public Sub ConsultaGeneral(ByVal OtrosCent As Integer, ByVal cent_ As String,
                               ByVal est_ As String,
                               ByVal OtrosCat As Integer, ByVal cat_ As String,
                               ByVal OtrosEProd As Integer, ByVal eprod_ As String,
                               ByVal OtrosEReprod As Integer, ByVal erep_ As String,
                               ByVal estsalud_ As String, ByVal SoloHacienda As Integer)

        Dim hr1 As TimeSpan = Now.TimeOfDay

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim fDesde As DateTime = dtpFechaDesde.Value
        Dim fHasta As DateTime = dtpFechaHasta.Value

        If TipoReporte = 4 Then
            fDesde = fDesde.AddDays(-(Int32.Parse(txtDias2.Text)))
            fHasta = fHasta.AddDays(Int32.Parse(txtDias.Text) * -1)
            'Dias = txtDias2.Text spGanado_ConsultaGeneral_RevPP
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand(IIf(TipoReporte <> 8, (IIf(TipoReporte <> 3, "spGanado_ConsultaGeneral", "spGanado_ConsultaGeneral_RevPP")), "spGanado_ConsultaGeneralPARTOS"), con)

        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 800

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@TipoReporte", TipoReporte)

        cmd.Parameters.AddWithValue("@OtrosCent", OtrosCent)
        cmd.Parameters.AddWithValue("@Centros", cent_)

        cmd.Parameters.AddWithValue("@Estados", est_)

        cmd.Parameters.AddWithValue("@OtrosCat", OtrosCat)
        cmd.Parameters.AddWithValue("@Categorias", cat_)

        cmd.Parameters.AddWithValue("@OtrosEProd", OtrosEProd)
        cmd.Parameters.AddWithValue("@EstsProds", eprod_)

        cmd.Parameters.AddWithValue("@OtrosEReprod", OtrosEReprod)
        cmd.Parameters.AddWithValue("@EstsReprods", erep_)

        cmd.Parameters.AddWithValue("@EstsSalud", estsalud_)

        cmd.Parameters.AddWithValue("@DIIO", txtDIIO.Text)
        cmd.Parameters.AddWithValue("@Dias", txtDias.Text)
        cmd.Parameters.AddWithValue("@Dias2", txtDias2.Text)

        cmd.Parameters.AddWithValue("@FechaDesde", Mid(fDesde, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(fHasta, 1, 10))

        cmd.Parameters.AddWithValue("@PesoDesde", 0)
        cmd.Parameters.AddWithValue("@PesoHasta", 0)

        cmd.Parameters.AddWithValue("@Origen", SoloHacienda)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        DatosGrilla = ""

        Dim vret As Integer = 0
        Dim i As Integer = 0
        Dim diio_, madre_, estado_, fnac_, fest_, cubnum_, numpart_, dlac_, fultrev_, dcel_, fcel_, ncel_, iatf_, prem_, fcomp_, Escompra_, CentronomCompra, CentrocodCompra, peso, pesoUltFec, inmunidad As String
        Dim emprut_, nomcent_, nomcat_, raza_, nomeprod_, ereprod_, esalud, prodcod_, fultcbta, toro_, padre_, abuelo_, ultcondrevpp_, CenCodNac, CenNomNac As String
        Dim muestreo_, cojera_, ultcojera_, mastitis_, ultmastitis_, otrat_, ultotrat_, revisionpp, razaSIPEC_, sexo_ As String
        Dim cupalp_, fulttras_, culttras_, desechoTipo As String
        Dim Tultparto As String
        Dim fpre_, fpp_, fsec_, fupalp_, fultsec_, fultparto, fpriparto_, iatfFecha As Date
        Dim mu_tub, mu_leu, mu_bru As String        'muestreos
        Dim nro_coj, nro_mast, nro_otrat, nro_muest, nro_revpp, cod_centro, PesoxDia, BWPadre, BWAbuelo, BWBisabuelo, BWTotal As String
        Dim color_ As Color
        Dim items As New List(Of ListViewItem)


        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    ReDim Preserve ComparaDIIOConsultaGeneral(i)
                    Escompra_ = rdr("Escompra").ToString.Trim
                    CentronomCompra = rdr("CentronomCompra").ToString.Trim
                    CentrocodCompra = rdr("CentrocodCompra").ToString.Trim
                    emprut_ = rdr("EmpRut").ToString.Trim
                    nomcent_ = rdr("CenDesCor").ToString.Trim
                    nomcat_ = rdr("GndProNom").ToString.Trim 
                    nomeprod_ = rdr("GndEstadoProductivo").ToString.Trim
                    ereprod_ = rdr("GndEstadoReproductivo").ToString.Trim
                    esalud = rdr("GndEstadoSalud").ToString.Trim
                    prodcod_ = rdr("GrpProduccionCod").ToString.Trim
                    fpriparto_ = rdr("GndUltFechaPriPartos2")
                    fultparto = rdr("GndUltFechaParto2")
                    fultcbta = rdr("GndUltCubierta2").ToString.Trim
                    toro_ = rdr("ToroNombre").ToString.Trim
                    padre_ = rdr("GndPadre").ToString.Trim
                    abuelo_ = rdr("GndAbuelo").ToString.Trim
                    ultcondrevpp_ = rdr("UltCondRevPP").ToString.Trim
                    cupalp_ = rdr("GndCondicionPalpacion").ToString.Trim
                    madre_ = rdr("GndMadre").ToString.Trim
                    estado_ = rdr("GndEstado").ToString.Trim
                    raza_ = rdr("NomRaza").ToString.Trim

                    pesoUltFec = ""
                    peso = rdr("GndPesoAct").ToString.Trim
                    pesoUltFec = Format(rdr("GndPesoUltFecha"), "dd-MM-yyyy")
                    pesoUltFec = IIf(pesoUltFec = "01-01-1900", "", pesoUltFec)

                    Tultparto = rdr("TipoUltimoParto").ToString.Trim
                    muestreo_ = rdr("GndIsMuestreo").ToString.Trim
                    cojera_ = rdr("GndIsCoja").ToString.Trim
                    mastitis_ = rdr("GndIsMastitis").ToString.Trim
                    otrat_ = rdr("GndIsOtrosTratamiemtos").ToString.Trim
                    revisionpp = rdr("GndIsRevisionPP").ToString.Trim

                    mu_tub = rdr("MuestraTUB").ToString.Trim
                    mu_leu = rdr("MuestraLEU").ToString.Trim
                    mu_bru = rdr("MuestraBRU").ToString.Trim
                    desechoTipo = rdr("desechoTipo").ToString.Trim
                    cod_centro = rdr("CentroCod").ToString.Trim
                    inmunidad = rdr("InmunidadTipNom").ToString.Trim
                    BWPadre = rdr("GndBWPadrePercent").ToString.Trim
                    BWAbuelo = rdr("GndBWAbueloPercent").ToString.Trim()
                    BWBisabuelo = rdr("GndBWBisAbueloPercent").ToString.Trim
                    BWTotal = rdr("GndBWTotal").ToString.Trim()

                    fpre_ = "01-01-1900"
                    fpp_ = "01-01-1900"
                    fsec_ = "01-01-1900"
                    fpp_ = "01-01-1900"
                    fupalp_ = "01-01-1900"
                    fultsec_ = "01-01-1900"
                    iatfFecha = "01-01-1900"

                    fest_ = ""
                    cubnum_ = ""
                    numpart_ = ""
                    dlac_ = ""
                    fultrev_ = ""
                    dcel_ = ""
                    ncel_ = ""
                    iatf_ = ""
                    prem_ = ""

                    CenCodNac = ""
                    CenNomNac = ""
                    ultcojera_ = ""
                    ultmastitis_ = ""
                    ultotrat_ = ""
                    nro_coj = ""
                    nro_mast = ""
                    nro_otrat = ""
                    nro_muest = ""
                    nro_revpp = ""
                    fulttras_ = ""
                    culttras_ = ""
                    fcomp_ = ""
                    razaSIPEC_ = ""
                    sexo_ = ""

                    diio_ = rdr("GndCod").ToString.Trim
                    ComparaDIIOConsultaGeneral(i) = diio_

                    If madre_.Trim = "0" Then madre_ = ""
                    fpre_ = rdr("GndUltFechaPrenez2")
                    fpp_ = rdr("FechaProbPart")
                    fsec_ = rdr("FechaSecado")
                    fnac_ = rdr("GndFecNac2")
                    fupalp_ = rdr("GndUltFechaPalpacionPP2")
                    fultsec_ = rdr("GndUltFechaRealSecado")
                    fcel_ = Format(rdr("FechaUltCelo"), "dd-MM-yyyy")


                    If muestreo_ = "NO" Then muestreo_ = ""
                    If cojera_ = "NO" Then cojera_ = ""
                    If mastitis_ = "NO" Then mastitis_ = ""
                    If otrat_ = "NO" Then otrat_ = ""
                    If revisionpp = "NO" Then revisionpp = ""
                    If Not IsDBNull(rdr("GndCojerasFecUlt")) Then ultcojera_ = Format(rdr("GndCojerasFecUlt"), "dd-MM-yyyy")
                    If Not IsDBNull(rdr("GndMastitisFecUlt")) Then ultmastitis_ = Format(rdr("GndMastitisFecUlt"), "dd-MM-yyyy")
                    If Not IsDBNull(rdr("GndOtrosTratamientosFecUlt")) Then ultotrat_ = Format(rdr("GndOtrosTratamientosFecUlt"), "dd-MM-yyyy")
                    If Not IsDBNull(rdr("GndOtrosTratamientosFecUlt")) Then ultotrat_ = Format(rdr("GndOtrosTratamientosFecUlt"), "dd-MM-yyyy")
                    If Not IsDBNull(rdr("FechaCompra")) Then fcomp_ = Format(rdr("FechaCompra"), "dd-MM-yyyy")


                    If Not IsDBNull(rdr("GndCenSalFec")) Then fulttras_ = Format(rdr("GndCenSalFec"), "dd-MM-yyyy")
                    If Not IsDBNull(rdr("CentroSalida")) Then culttras_ = rdr("CentroSalida").ToString.Trim()

                    If Not IsDBNull(rdr("AbreviaRaza")) Then razaSIPEC_ = rdr("AbreviaRaza").ToString.Trim()
                    If Not IsDBNull(rdr("GndSexo")) Then sexo_ = rdr("GndSexo").ToString.Trim()



                    If IsDBNull(fcomp_) = True Or fcomp_ = "01-01-1753" Or fcomp_ = "01-01-1900" Then fcomp_ = ""
                    If IsDBNull(fcel_) = True Or fcel_ = "01-01-1753" Or fcel_ = "01-01-1900" Then fcel_ = ""
                    If IsDBNull(ultcojera_) = True Or ultcojera_ = "01-01-1753" Or ultcojera_ = "01-01-1900" Then ultcojera_ = ""
                    If IsDBNull(ultmastitis_) = True Or ultmastitis_ = "01-01-1753" Or ultmastitis_ = "01-01-1900" Then ultmastitis_ = ""
                    If IsDBNull(ultotrat_) = True Or ultotrat_ = "01-01-1753" Or ultotrat_ = "01-01-1900" Then ultotrat_ = ""
                    If IsDate(rdr("UltFecRevPP")) Then fultrev_ = rdr("UltFecRevPP")

                    If Not IsDBNull(rdr("GndUltCubiertaNum")) Then If rdr("GndUltCubiertaNum") <> 0 Then cubnum_ = rdr("GndUltCubiertaNum").ToString.Trim()
                    CenCodNac = rdr("GndNacimientoCenCod").ToString.Trim()
                    CenNomNac = rdr("GndNacimientoCenNom").ToString.Trim()
                    If Not IsDBNull(rdr("GndActPartosNum")) Then If rdr("GndActPartosNum") <> 0 Then numpart_ = rdr("GndActPartosNum").ToString.Trim()

                    If rdr("DiasCelo") > 0 Then dcel_ = rdr("DiasCelo").ToString.Trim
                    If rdr("NumeroCelos") > 0 Then ncel_ = rdr("NumeroCelos").ToString.Trim
                    If rdr("TieneIATF") > 0 Then iatf_ = "SI"
                    'iatfFecha = rdr("IATFFecha")
                    If IsDate(rdr("IATFFecha")) Then iatfFecha = Format(rdr("IATFFecha"), "dd-MM-yyyy")

                    If rdr("GndLoteNom").ToString.Contains("PREMIUM") Then prem_ = "SI"

                    Select Case estado_
                        Case "MUERTO"
                            If IsDate(rdr("GndIsMuertoFecha")) Then fest_ = Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy")
                        Case "VENDIDO"
                            If IsDate(rdr("GndIsVendidoFecha")) Then fest_ = Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy")
                        Case "DESAPARECIDO"
                            If IsDate(rdr("GndIsDesaparecidoFecha")) Then fest_ = Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy")
                    End Select

                    If TipoReporte = 5 Then 'vacas a cubrir
                        If Not IsDBNull(rdr("DiasLactanciaCalc")) Then
                            If rdr("DiasLactanciaCalc") <> 0 Then dlac_ = rdr("DiasLactanciaCalc").ToString.Trim()
                        End If
                    Else
                        If Not IsDBNull(rdr("DiasLactancia")) Then
                            If rdr("DiasLactancia") <> 0 Then dlac_ = rdr("DiasLactancia").ToString.Trim()
                        End If
                    End If


                    If rdr("NroCojeras") <> 0 Then nro_coj = rdr("NroCojeras").ToString.Trim()
                    If rdr("NroMastitis") <> 0 Then nro_mast = rdr("NroMastitis").ToString.Trim()
                    If rdr("NroOtrosTratamientos") <> 0 Then nro_otrat = rdr("NroOtrosTratamientos").ToString.Trim()
                    If rdr("NroMuestreos") <> 0 Then nro_muest = rdr("NroMuestreos").ToString.Trim()
                    If rdr("NroRevisionesPP") <> 0 Then nro_revpp = rdr("NroRevisionesPP").ToString.Trim()
                    PesoXDia = rdr("GndPesoXDia")
                    If rdr("valor") = 1 Then
                        Dim item As New ListViewItem((i + 1).ToString.Trim)



                        item.SubItems.Add(emprut_)
                        item.SubItems.Add(nomcent_)
                        item.SubItems.Add(diio_)
                        item.SubItems.Add(nomcat_)
                        item.SubItems.Add(fnac_)
                        item.SubItems.Add(raza_)
                        item.SubItems.Add(estado_)
                        item.SubItems.Add(fest_)
                        item.SubItems.Add(nomeprod_)
                        item.SubItems.Add(ereprod_)
                        item.SubItems.Add(esalud)
                        item.SubItems.Add(dlac_)
                        item.SubItems.Add(fultsec_)
                        item.SubItems.Add(fsec_)
                        item.SubItems.Add(prodcod_)
                        item.SubItems.Add(fpriparto_)
                        item.SubItems.Add(fultparto)
                        item.SubItems.Add(Tultparto) ''TipoUltimoParto
                        item.SubItems.Add(fpp_) ''Convert.ToDateTime())
                        item.SubItems.Add(fpre_)
                        item.SubItems.Add(numpart_)
                        item.SubItems.Add(fultcbta)
                        item.SubItems.Add(cubnum_)
                        item.SubItems.Add(toro_)
                        item.SubItems.Add(padre_)
                        item.SubItems.Add(madre_)
                        item.SubItems.Add(abuelo_)
                        item.SubItems.Add(dcel_)
                        item.SubItems.Add(fcel_)
                        item.SubItems.Add(ncel_)
                        item.SubItems.Add(iatf_)
                        If iatfFecha = "01-01-1900" Then
                            item.SubItems.Add("")
                        Else
                            item.SubItems.Add(iatfFecha)
                        End If
                        item.SubItems.Add(prem_)
                        item.SubItems.Add(fupalp_)
                        item.SubItems.Add(cupalp_)
                        item.SubItems.Add(CenCodNac)
                        item.SubItems.Add(CenNomNac)
                        item.SubItems.Add(fcomp_)
                        ''
                        item.SubItems.Add(muestreo_)
                        item.SubItems.Add(nro_muest)
                        item.SubItems.Add(mu_tub)
                        item.SubItems.Add(mu_leu)
                        item.SubItems.Add(mu_bru)
                        ''
                        item.SubItems.Add(cojera_)
                        item.SubItems.Add(nro_coj)
                        item.SubItems.Add(ultcojera_)
                        ''
                        item.SubItems.Add(mastitis_)
                        item.SubItems.Add(nro_mast)
                        item.SubItems.Add(ultmastitis_)
                        ''
                        item.SubItems.Add(otrat_)
                        item.SubItems.Add(nro_otrat)
                        item.SubItems.Add(ultotrat_)
                        ''
                        item.SubItems.Add(revisionpp)
                        item.SubItems.Add(nro_revpp)
                        item.SubItems.Add(fultrev_)
                        item.SubItems.Add(ultcondrevpp_)
                        ''
                        item.SubItems.Add(fulttras_)
                        item.SubItems.Add(culttras_)
                        ''
                        item.SubItems.Add(razaSIPEC_)
                        item.SubItems.Add(sexo_)
                        ''
                        item.SubItems.Add(cod_centro)

                        item.SubItems.Add(Escompra_)
                        item.SubItems.Add(CentrocodCompra)
                        item.SubItems.Add(CentronomCompra)
                        item.SubItems.Add(desechoTipo)
                        item.SubItems.Add(peso)
                        item.SubItems.Add(pesoUltFec)
                        item.SubItems.Add(inmunidad)
                        item.SubItems.Add(PesoxDia)
                        item.SubItems.Add(BWPadre)
                        item.SubItems.Add(BWAbuelo)
                        item.SubItems.Add(BWBisabuelo)
                        item.SubItems.Add(BWTotal)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''

                        items.Add(item)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''
                        ProcesaTotales(nomcat_, nomeprod_, ereprod_)

                        color_ = SystemColors.WindowText
                        If esalud = "ENFERMA" Then color_ = Color.Red
                        If esalud = "SANA" And prem_ = "SI" Then color_ = Color.Green

                        'si esta enferma
                        If color_ <> SystemColors.WindowText Then
                            item.UseItemStyleForSubItems = True

                            For x As Integer = 0 To item.SubItems.Count - 1
                                item.SubItems(x).ForeColor = color_
                            Next
                        End If

                        i = i + 1
                        pbProcesa.Value = i
                    End If
                End While

                lblProcesa.Text = "Cargando datos a la grilla, espere un momento por favor..."
                pnlProcesa.Refresh()
                lvGanado.Items.AddRange(items.ToArray())

                If vret = 0 Then
                    'vret = 0
                    btnBaston.Enabled = False
                    btnAlarmas.Enabled = False
                    btnArchivoSIPEC.Enabled = False
                Else
                    btnBaston.Enabled = True
                    btnAlarmas.Enabled = True
                    btnArchivoSIPEC.Enabled = True
                End If

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
        Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False

        Dim hr2 As TimeSpan = Now.TimeOfDay
        Label65.Text = (hr2 - hr1).ToString
    End Sub


    Private Function GeneraCadenaConsulta(ByVal chklv As CheckedListBox, Optional ByRef MuestraOtros As Integer = 0) As String
        Dim i, io, idx, idx2 As Integer
        Dim ret As String = ""

        GeneraCadenaConsulta = ""
        ret = ""
        MuestraOtros = 0

        For i = 0 To chklv.Items.Count - 1
            idx = Val(chklv.GetItemText(i))

            If chklv.GetItemCheckState(i) = CheckState.Checked And chklv.Items(idx).ToString = "(OTROS)" Then
                For io = 1 To chklv.Items.Count - 1
                    idx2 = Val(chklv.GetItemText(io))
                    ret = ret + IIf(ret = "", "", ",") + chklv.Items(idx2).ToString.Trim
                Next

                MuestraOtros = 1
                Exit For
            End If

            If chklv.GetItemCheckState(i) = CheckState.Checked Then
                ret = ret + IIf(ret = "", "", ",") + chklv.Items(idx).ToString.Trim
            End If
        Next

        GeneraCadenaConsulta = ret
    End Function


    Private Function GeneraCadenaConsultaEstadoSalud(ByVal chklv As CheckedListBox, Optional ByRef MuestraOtros As Integer = 0) As String
        Dim i, idx As Integer
        Dim ret As String = ""

        GeneraCadenaConsultaEstadoSalud = ""
        ret = ""
        MuestraOtros = 0

        For i = 0 To chklv.Items.Count - 1
            idx = Val(chklv.GetItemText(i))
            If chklv.GetItemCheckState(i) = CheckState.Checked Then
                ret = ret + IIf(ret = "", "", ",") + CamposOrdenEstadoSalud(idx)
            End If
        Next

        GeneraCadenaConsultaEstadoSalud = ret
    End Function

    Private Sub DetalleGanado()
        If lvGanado.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvGanado.SelectedItems.Item(0).SubItems(3).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnLimpiarFiltros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFiltros.Click
        LimpiarFiltros()
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim OtrosCent As Integer = 0
        Dim Centros As String = ""
        Dim Estados As String = ""
        Dim OtrosCat As Integer = 0
        Dim Categorias As String = ""
        Dim OtrosEProd As Integer = 0
        Dim EstadosProductivos As String = ""
        Dim OtrosEReprod As Integer = 0
        Dim EstadosReproductivos As String = ""
        Dim EstadosSalud As String = ""
        Dim SoloHacienda As Integer = 0

        Centros = GeneraCadenaConsulta(chklvCentros, OtrosCent)
        Estados = GeneraCadenaConsulta(chklvEstados)
        Categorias = GeneraCadenaConsulta(chklvCategorias, OtrosCat)
        EstadosProductivos = GeneraCadenaConsulta(chklvEstadosProd, OtrosEProd)
        EstadosReproductivos = GeneraCadenaConsulta(chklvEstadosReprod, OtrosEReprod)
        EstadosSalud = GeneraCadenaConsultaEstadoSalud(chklvEstadosSalud)

        If chklvOrigen.GetItemCheckState(0) = CheckState.Checked Then SoloHacienda = 1


        If CadenaOrden = "" Then
            CadenaOrden = "CenDesCor, GndCod"
            lblOrden.Text = "Centro -> DIIO"
            lblOrden.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos, EstadosSalud, SoloHacienda)
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(26, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL POR CATEGORIA" : tot(0, 1) = ""
        tot(1, 0) = "TERNERAS" : tot(1, 1) = TotCat_Terneras
        tot(2, 0) = "TERNEROS" : tot(2, 1) = TotCat_Terneros
        tot(3, 0) = "TORETES" : tot(3, 1) = TotCat_Toretes
        tot(4, 0) = "TOROS" : tot(4, 1) = TotCat_Toros
        tot(5, 0) = "VACAS" : tot(5, 1) = TotCat_Vacas
        tot(6, 0) = "VAQUILLAS" : tot(6, 1) = TotCat_Vaquillas
        tot(7, 0) = "OTROS" : tot(7, 1) = Val(Label8.Text) - (TotCat_Terneras + TotCat_Terneros + TotCat_Toretes + TotCat_Toros + TotCat_Vacas + TotCat_Vaquillas)
        tot(8, 0) = "" : tot(8, 1) = ""

        tot(9, 0) = "TOTAL POR ESTADO PRODUCTIVO" : tot(9, 1) = ""
        tot(10, 0) = "DESCARTE" : tot(10, 1) = TotEP_Descarte
        tot(11, 0) = "DESECHO" : tot(11, 1) = TotEP_Desecho
        tot(12, 0) = "ELIMINADA EN LECHE" : tot(12, 1) = TotEP_EliminadaLeche
        tot(13, 0) = "EN PRODUCCION" : tot(13, 1) = TotEP_Produccion
        tot(14, 0) = "NO APLICA" : tot(14, 1) = TotEP_NoAplica
        tot(15, 0) = "SECA DE LECHE" : tot(15, 1) = TotEP_SecaLeche
        tot(16, 0) = "OTROS" : tot(16, 1) = Val(Label8.Text) - (TotEP_Descarte + TotEP_Desecho + TotEP_EliminadaLeche + TotEP_Produccion + TotEP_NoAplica + TotEP_SecaLeche)
        tot(17, 0) = "" : tot(17, 1) = ""

        tot(18, 0) = "TOTAL POR ESTADO REPRODUCTIVO" : tot(18, 1) = ""
        tot(19, 0) = "ANESTRO" : tot(19, 1) = TotER_Anestro
        tot(20, 0) = "CUBIERTA" : tot(20, 1) = TotER_Cubierta
        tot(21, 0) = "DESECHO REPRODUCTIVO" : tot(21, 1) = TotER_DesechoReprod
        tot(22, 0) = "DUDOSA" : tot(22, 1) = TotER_Dudosa
        tot(23, 0) = "NO APLICA" : tot(23, 1) = TotER_NoAplica
        tot(24, 0) = "PREÑADA" : tot(24, 1) = TotER_Preniada
        tot(25, 0) = "SECA PRN" : tot(25, 1) = TotER_SecaPrn
        tot(26, 0) = "OTROS" : tot(26, 1) = Val(Label8.Text) - (TotER_Anestro + TotER_Cubierta + TotER_DesechoReprod + TotER_Dudosa + TotER_NoAplica + TotER_Preniada + TotER_SecaPrn)

        ExportToExcelGrillaConsultaGeneral(lvGanado, tot)
    End Sub



    Private Sub btnGrafico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrafico.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim Graficos As New frmConsultaGraficos()

        Graficos.Cat_Terneras = TotCat_Terneras
        Graficos.Cat_Terneros = TotCat_Terneros
        Graficos.Cat_Toretes = TotCat_Toretes
        Graficos.Cat_Toros = TotCat_Toros
        Graficos.Cat_Vacas = TotCat_Vacas
        Graficos.Cat_Vaquillas = TotCat_Vaquillas
        Graficos.Cat_Otros = Val(Label8.Text) - TotCat_Terneras - TotCat_Terneros - TotCat_Toretes - TotCat_Toros - TotCat_Vacas - TotCat_Terneros
        Graficos.MdiParent = frmMAIN
        Graficos.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub chklvTiposReporte_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklvTiposReporte.SelectedIndexChanged
        Dim idx As Integer
        Dim opc As String

        idx = chklvTiposReporte.SelectedIndex
        opc = chklvTiposReporte.Items(idx).ToString.Trim

        LimpiarFiltros(False, idx)

        txtDias.Text = ""
        TipoReporte = 0
        TituloReporte = "INFORME DE GANADO"

        dtpFechaDesde.Enabled = False
        dtpFechaHasta.Enabled = False
        dtpFechaHasta.Visible = True
        dtpFechaDesde.Value = DateTime.Now
        Label2.Visible = True
        txtDias.Enabled = False
        txtDias2.Enabled = False
        txtDias2.Visible = False
        gboxFechas.Text = "Rango de fechas"
        grpDias.Visible = False
        grpDias.Width = 71
        grpDias.Text = "Dias"

        chklvEstados.SetItemCheckState(3, CheckState.Checked) 'stock
        pnlEstado.BackColor = Color.LimeGreen
        btnArchivoSIPEC.Visible = False

        If chklvTiposReporte.SelectedIndex = -1 Then Exit Sub

        Select Case opc
            Case "PARTOS PROBABLES"
                If chklvTiposReporte.GetItemCheckState(chklvTiposReporte.SelectedIndex) = CheckState.Checked Then
                    grpDias.Visible = False

                    TipoReporte = 1
                    TituloReporte = "INFORME DE PARTOS PROBABLES"
                    dtpFechaDesde.Enabled = True    'rango de fechas inicio partos
                    dtpFechaHasta.Enabled = True    'rango de fecha termino de partos
                    dtpFechaHasta.Visible = True
                    Label2.Visible = True
                    txtDias.Enabled = True

                    chklvEstados.SetItemCheckState(3, CheckState.Checked) 'stock
                    pnlEstado.BackColor = Color.LimeGreen

                    chklvEstadosReprod.SetItemCheckState(6, CheckState.Checked) 'preñada
                    pnlEstadoReproductivo.BackColor = Color.LimeGreen
                End If

            Case "SECADO x PARTOS"
                If chklvTiposReporte.GetItemCheckState(chklvTiposReporte.SelectedIndex) = CheckState.Checked Then
                    grpDias.Visible = False

                    TipoReporte = 2
                    TituloReporte = "INFORME DE SECADO x PARTOS"
                    dtpFechaDesde.Enabled = True
                    dtpFechaHasta.Enabled = True
                    dtpFechaHasta.Visible = True
                    Label2.Visible = True

                    chklvEstados.SetItemCheckState(3, CheckState.Checked) 'stock
                    pnlEstado.BackColor = Color.LimeGreen

                    chklvEstadosProd.SetItemCheckState(4, CheckState.Checked) 'en produccion
                    pnlEstadoProductivo.BackColor = Color.LimeGreen
                End If

            Case "A REV PP POR FECHA"
                If chklvTiposReporte.GetItemCheckState(chklvTiposReporte.SelectedIndex) = CheckState.Checked Then
                    grpDias.Visible = True
                    txtDias.Text = 21
                    txtDias.Enabled = True

                    TipoReporte = 3
                    TituloReporte = "INFORME DE REVISION POST PARTOS"
                    dtpFechaDesde.Enabled = True
                    Label2.Visible = False
                    dtpFechaHasta.Visible = False
                    dtpFechaDesde.Value = Now
                    'dtpFechaHasta.Enabled = True

                    chklvEstados.SetItemCheckState(3, CheckState.Checked) 'stock
                    pnlEstado.BackColor = Color.LimeGreen


                    chklvEstadosProd.SetItemCheckState(4, CheckState.Checked) 'en produccion
                    pnlEstadoProductivo.BackColor = Color.LimeGreen

                    chklvEstadosReprod.SetItemCheckState(1, CheckState.Checked) 'anestro
                    pnlEstadoReproductivo.BackColor = Color.LimeGreen
                End If

            Case "BUSQUEDA CELOS"
                If chklvTiposReporte.GetItemCheckState(chklvTiposReporte.SelectedIndex) = CheckState.Checked Then

                    TipoReporte = 4
                    TituloReporte = "INFORME BUSQUEDA DE CELOS"
                    dtpFechaDesde.Enabled = True
                    dtpFechaHasta.Enabled = False
                    dtpFechaHasta.Visible = False
                    Label2.Visible = False
                    txtDias.Enabled = True
                    txtDias2.Enabled = True
                    txtDias2.Visible = True
                    grpDias.Visible = True
                    grpDias.Width = 136
                    grpDias.Text = "Dias Entre"

                    txtDias.Text = "18"
                    txtDias2.Text = "21"

                    chklvEstados.SetItemCheckState(3, CheckState.Checked) 'stock
                    pnlEstado.BackColor = Color.LimeGreen

                    chklvCategorias.SetItemCheckState(6, CheckState.Checked) 'vacas
                    chklvCategorias.SetItemCheckState(7, CheckState.Checked) 'vaquillas
                    pnlCategoria.BackColor = Color.LimeGreen

                End If

            Case "VACAS A CUBRIR"
                If chklvTiposReporte.GetItemCheckState(chklvTiposReporte.SelectedIndex) = CheckState.Checked Then

                    TipoReporte = 5
                    TituloReporte = "INFORME VACAS A CUBRIR"
                    dtpFechaDesde.Enabled = True
                    dtpFechaHasta.Enabled = False
                    dtpFechaHasta.Visible = False
                    Label2.Visible = False
                    txtDias.Enabled = True
                    txtDias2.Enabled = False
                    txtDias2.Visible = False
                    gboxFechas.Text = "Rango de fechas al"
                    grpDias.Visible = True
                    grpDias.Width = 136
                    grpDias.Text = "Dias lactancia > a:"

                    txtDias.Text = "40"
                    txtDias2.Text = ""

                    chklvEstados.SetItemCheckState(3, CheckState.Checked) 'stock
                    pnlEstado.BackColor = Color.LimeGreen

                    chklvCategorias.SetItemCheckState(6, CheckState.Checked) 'vacas
                    chklvCategorias.SetItemCheckState(7, CheckState.Checked) 'vaquillas
                    pnlCategoria.BackColor = Color.LimeGreen

                    chklvEstadosReprod.SetItemCheckState(1, CheckState.Checked) 'anestro
                    pnlEstadoReproductivo.BackColor = Color.LimeGreen

                    chklvEstadosSalud.SetItemCheckState(0, CheckState.Checked) 'anestro
                    pnlEstadoSalud.BackColor = Color.LimeGreen
                End If

            Case "VACAS A PALPAR"
                If chklvTiposReporte.GetItemCheckState(chklvTiposReporte.SelectedIndex) = CheckState.Checked Then

                    TipoReporte = 6
                    TituloReporte = "INFORME VACAS A PALPAR"
                    dtpFechaDesde.Enabled = True
                    dtpFechaHasta.Enabled = False
                    dtpFechaHasta.Visible = False
                    Label2.Visible = False
                    txtDias.Enabled = True
                    txtDias2.Enabled = False
                    txtDias2.Visible = False
                    gboxFechas.Text = "Fecha"
                    grpDias.Visible = True
                    grpDias.Width = 136
                    grpDias.Text = "Dias Ult. Cub. >= a:"

                    txtDias.Text = "35"
                    txtDias2.Text = ""

                    chklvEstados.SetItemCheckState(3, CheckState.Checked) 'stock
                    pnlEstado.BackColor = Color.LimeGreen

                    chklvCategorias.SetItemCheckState(6, CheckState.Checked) 'vacas
                    chklvCategorias.SetItemCheckState(7, CheckState.Checked) 'vaquillas
                    pnlCategoria.BackColor = Color.LimeGreen

                    chklvEstadosReprod.SetItemCheckState(2, CheckState.Checked) 'cubiertas
                    pnlEstadoReproductivo.BackColor = Color.LimeGreen

                End If

            Case "NACIMIENTOS"
                If chklvTiposReporte.GetItemCheckState(chklvTiposReporte.SelectedIndex) = CheckState.Checked Then
                    grpDias.Visible = False

                    TipoReporte = 7
                    TituloReporte = "INFORME DE NACIMIENTOS"
                    dtpFechaDesde.Enabled = True
                    dtpFechaHasta.Enabled = True
                    dtpFechaHasta.Visible = True
                    Label2.Visible = True

                    chklvEstados.SetItemCheckState(3, CheckState.Checked) 'stock
                    pnlEstado.BackColor = Color.LimeGreen
                    btnArchivoSIPEC.Visible = True

                End If

            Case "PARTOS"
                If chklvTiposReporte.GetItemCheckState(chklvTiposReporte.SelectedIndex) = CheckState.Checked Then
                    grpDias.Visible = False

                    TipoReporte = 8
                    TituloReporte = "INFORME DE PARTOS"
                    dtpFechaDesde.Enabled = True
                    dtpFechaHasta.Enabled = True
                    dtpFechaHasta.Visible = True
                    Label2.Visible = True

                    pnlEstado.BackColor = Color.LimeGreen
                    btnArchivoSIPEC.Visible = True

                End If

        End Select

        CambiaEstadoFiltro(chklvTiposReporte, pnltipoReporte)
    End Sub

    Private Sub chklvCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklvCentros.SelectedIndexChanged
        CambiaEstadoFiltro(chklvCentros, pnlCentros)
    End Sub


    Private Sub chklvEstados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklvEstados.SelectedIndexChanged
        CambiaEstadoFiltro(chklvEstados, pnlEstado)
    End Sub


    Private Sub chklvCategorias_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklvCategorias.SelectedIndexChanged
        CambiaEstadoFiltro(chklvCategorias, pnlCategoria)
    End Sub


    Private Sub chklvEstadosProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklvEstadosProd.SelectedIndexChanged
        CambiaEstadoFiltro(chklvEstadosProd, pnlEstadoProductivo)
    End Sub


    Private Sub chklvEstadosReprod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklvEstadosReprod.SelectedIndexChanged
        CambiaEstadoFiltro(chklvEstadosReprod, pnlEstadoReproductivo)
    End Sub

    Private Sub chklvEstadoSalud_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles chklvEstadosSalud.SelectedIndexChanged
        Dim idx As Integer = 0
        Dim opc As String = ""

        Select Case opc
            Case "SANA"
                If chklvEstados.GetItemCheckState(chklvEstados.SelectedIndex) = CheckState.Checked Then
                    For i As Integer = 1 To chklvEstados.Items.Count - 1
                        chklvEstados.SetItemCheckState(i, CheckState.Unchecked)
                    Next
                Else
                    For i As Integer = 1 To chklvEstados.Items.Count - 1
                        chklvEstados.SetItemCheckState(i, CheckState.Checked)
                    Next
                End If
        End Select

        CambiaEstadoFiltro(chklvEstadosSalud, pnlEstadoSalud)
    End Sub

    Private Sub chklvOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles chklvOrigen.SelectedIndexChanged
        Dim idx As Integer
        Dim opc As String

        If chklvOrigen.SelectedIndex = -1 Then Exit Sub

        idx = chklvOrigen.SelectedIndex
        opc = chklvOrigen.Items(idx).ToString.Trim

        gboxFechas.Text = "Rango de Fecha"
        dtpFechaDesde.Enabled = False
        dtpFechaHasta.Enabled = False

        Select Case opc
            Case "HACIENDA"
                If chklvOrigen.GetItemCheckState(chklvOrigen.SelectedIndex) = CheckState.Checked Then
                    gboxFechas.Text = "Excluir Compras"
                    dtpFechaDesde.Enabled = True
                    dtpFechaHasta.Enabled = True
                End If
        End Select

        CambiaEstadoFiltro(chklvOrigen, pnlOrigen)
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
            DetalleGanado()
        End If
    End Sub


    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub


    Private Sub mnuCopiarDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(3).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub



    Private Sub btnImprime_Click(sender As System.Object, e As System.EventArgs) Handles btnImprime.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim OtrosCent As Integer = 0
        Dim Centros As String = ""
        Dim Estados As String = ""
        Dim OtrosCat As Integer = 0
        Dim Categorias As String = ""
        Dim OtrosEProd As Integer = 0
        Dim EstadosProductivos As String = ""
        Dim OtrosEReprod As Integer = 0
        Dim EstadosReproductivos As String = ""
        Dim SoloHacienda As Integer = 0
        Dim fDesde As DateTime = dtpFechaDesde.Value
        Dim fHasta As DateTime = dtpFechaHasta.Value

        Centros = GeneraCadenaConsulta(chklvCentros, OtrosCent)
        Estados = GeneraCadenaConsulta(chklvEstados)
        Categorias = GeneraCadenaConsulta(chklvCategorias, OtrosCat)
        EstadosProductivos = GeneraCadenaConsulta(chklvEstadosProd, OtrosEProd)
        EstadosReproductivos = GeneraCadenaConsulta(chklvEstadosReprod, OtrosEReprod)

        If TipoReporte = 4 Then
            fDesde = fDesde.AddDays(-(Int32.Parse(txtDias2.Text)))
            fHasta = fHasta.AddDays(Int32.Parse(txtDias.Text) * -1)
        End If

        If chklvOrigen.GetItemCheckState(0) = CheckState.Checked Then SoloHacienda = 1

        If TipoReporte <> 4 Then

            With frmRptConsultaGeneral

                .Empresa = Empresa
                .TipoReporte = TipoReporte
                .OtrosCent = OtrosCent
                .Centros = Centros
                .Estados = Estados
                .OtrosCat = OtrosCat
                .Categorias = Categorias
                .OtrosEProd = OtrosEProd
                .EstsProds = EstadosProductivos
                .OtrosEReprod = OtrosEReprod
                .EstsReprods = EstadosReproductivos
                .DIIO = txtDIIO.Text
                .Dias = IIf(IsNumeric(txtDias.Text), Val(txtDias.Text), 0)
                .FechaDesde = Mid(fDesde, 1, 10)
                .FechaHasta = Mid(fHasta, 1, 10)
                .PesoDesde = 0
                .PesoHasta = 0
                .Origen = SoloHacienda
                .Orden = CadenaOrden

                Dim p1 As New ReportParameter("Param1_Titulo1", TituloReporte)
                Dim p2 As New ReportParameter("Param2_Titulo2", GeneraTitulo2Informe())
                Dim p3 As New ReportParameter("Param3_Usuario", LoginUsuario)

                .ReportViewer1.LocalReport.SetParameters(New ReportParameter() {p1, p2, p3})

                .MdiParent = frmMAIN
                .Show()
                .BringToFront()

            End With

        Else

            With frmRptConsultaCelos

                .Empresa = Empresa
                .TipoReporte = TipoReporte
                .OtrosCent = OtrosCent
                .Centros = Centros
                .Estados = Estados
                .OtrosCat = OtrosCat
                .Categorias = Categorias
                .OtrosEProd = OtrosEProd
                .EstsProds = EstadosProductivos
                .OtrosEReprod = OtrosEReprod
                .EstsReprods = EstadosReproductivos
                .DIIO = txtDIIO.Text
                .Dias = IIf(IsNumeric(txtDias.Text), Val(txtDias.Text), 0)
                .FechaDesde = Mid(fDesde, 1, 10)
                .FechaHasta = Mid(fHasta, 1, 10)
                .PesoDesde = 0
                .PesoHasta = 0
                .Origen = SoloHacienda
                .Orden = CadenaOrden

                Dim p1 As New ReportParameter("Param1_Titulo1", TituloReporte)
                Dim p2 As New ReportParameter("Param2_Titulo2", GeneraTitulo2Informe())
                Dim p3 As New ReportParameter("Param3_Usuario", LoginUsuario)

                .ReportViewer1.LocalReport.SetParameters(New ReportParameter() {p1, p2, p3})

                .MdiParent = frmMAIN
                .Show()
                .BringToFront()

            End With

        End If

        Cursor.Current = Cursors.Default
    End Sub


    Private Function GeneraTitulo2Informe() As String

        GeneraTitulo2Informe = "DESDE EL   " + Format(dtpFechaDesde.Value, "dd-MM-yyyy") + "   AL   " + Format(dtpFechaHasta.Value, "dd-MM-yyyy")

        Select Case TipoReporte
            Case 0
                GeneraTitulo2Informe = ""

            Case 4
                GeneraTitulo2Informe = "FECHA  " + Format(dtpFechaDesde.Value, "dd-MM-yyyy") + "     DIAS ENTRE   " + txtDias.Text + " y " + txtDias2.Text
        End Select
    End Function


    Private Sub PalpacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPalpacion.Click

    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarOrden.Click

        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Public Sub CboLLenaPerfiles()

        cboPerfilesColumnas.Items.Clear()
        cboPerfilesColumnas.Items.Add("(SGL)")

        Dim i As Integer

        For i = 0 To General.CGPerfiles.NroRegistros - 1
            cboPerfilesColumnas.Items.Add(General.CGPerfiles.Nombre(i))
        Next

        cboPerfilesColumnas.SelectedIndex = 0
    End Sub


    Private Sub btnBaston_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaston.Click
        LeeBaston()
    End Sub


    Private Sub btnAlarmas_Click(sender As System.Object, e As System.EventArgs) Handles btnAlarmas.Click
        ExportarAlarmasBaston()
    End Sub


    Private Sub LeeBaston()

        frmBastonV2.Param1_CentroCod = CodigoCentroUsuario
        frmBastonV2.Param2_CentroNom = NombreCentroUsuario
        frmBastonV2.Param3_Formulario = "frmConsultaGeneral"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub


    Private Sub ExportarAlarmasBaston()
        If lvGanado.Items.Count = 0 Then Exit Sub
        ExportToExcelGrillaAlarmas(lvGanado, 3)
    End Sub





    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim pos_ini As Integer = 0
        Dim diio_ As String = ""
        Dim diio_paso As String = ""
        Dim strdiios1_ As String = ""
        Dim strdiios2_ As String = ""
        ' Dim inichk_ As Integer = lvDIIOS.Items.Count '- 1
        Dim ExisteDIIO As Boolean = False


        Dim ComparaDIIOBaston As String() = {}
        'Dim item As ListViewItem = Nothing
        Dim x, y As Integer

        Dim cont_compara As Integer = 0
        Dim cont_comperr1 As Integer = 0
        Dim cont_comperr2 As Integer = 0

        y = 0

        Cursor.Current = Cursors.WaitCursor

        'mostramos formulario de comparacion de diios
        frmConsultaGeneralCompara.MdiParent = frmMAIN
        frmConsultaGeneralCompara.Show()
        frmConsultaGeneralCompara.pnlTotal.Refresh()
        frmConsultaGeneralCompara.lblProcesa.Text = "Verificando DIIOs del baston..."

        frmConsultaGeneralCompara.pbProcesa.Value = 0
        frmConsultaGeneralCompara.pbProcesa.Maximum = (frmBastonV2.lvBASTON.Items.Count) + (ComparaDIIOConsultaGeneral.Count)
        frmConsultaGeneralCompara.pnlProcesa.Visible = True
        frmConsultaGeneralCompara.pnlProcesa.Refresh()

        frmConsultaGeneralCompara.lvGanado.BeginUpdate()
        frmConsultaGeneralCompara.lvGanado.Items.Clear()

        'creamos arreglo con los diios del baston y aprovechamos de compararlos con los diios de la consulta general
        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            ReDim Preserve ComparaDIIOBaston(i)

            ComparaDIIOBaston(i) = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim
            ExisteDIIO = False

            For x = 0 To ComparaDIIOConsultaGeneral.Count - 1
                If ComparaDIIOBaston(i) = ComparaDIIOConsultaGeneral(x) Then
                    ExisteDIIO = True
                End If
            Next


            If Not ExisteDIIO Then
                Dim item = New ListViewItem((y + 1).ToString.Trim)
                item.SubItems.Add(ComparaDIIOBaston(i))
                item.SubItems.Add("EL DIIO existe en el bastón y no existe en la consulta")
                frmConsultaGeneralCompara.lvGanado.Items.Add(item)
                frmConsultaGeneralCompara.lvGanado.Items(y).ForeColor = Color.Red
                y = y + 1
                cont_comperr1 = cont_comperr1 + 1
            End If

            frmConsultaGeneralCompara.pbProcesa.Value = i
            cont_compara = cont_compara + 1
        Next

        'ahora recorremos los diios de la consulta general para compararlos con los diios del baston
        frmConsultaGeneralCompara.lblProcesa.Text = "Verificando DIIOs de la consulta general..."
        frmConsultaGeneralCompara.pnlProcesa.Refresh()

        For z = 0 To ComparaDIIOConsultaGeneral.Count - 1
            ExisteDIIO = False

            For x = 0 To ComparaDIIOBaston.Count - 1
                If ComparaDIIOConsultaGeneral(z) = ComparaDIIOBaston(x) Then
                    ExisteDIIO = True
                End If
            Next


            If Not ExisteDIIO Then
                Dim item = New ListViewItem((y + 1).ToString.Trim)
                item.SubItems.Add(ComparaDIIOConsultaGeneral(z))
                item.SubItems.Add("EL DIIO existe en la consulta y no existe en el baston")
                frmConsultaGeneralCompara.lvGanado.Items.Add(item)

                y = y + 1
                cont_comperr2 = cont_comperr2 + 1
            End If

            frmConsultaGeneralCompara.pbProcesa.Value = i
            i = i + 1
            cont_compara = cont_compara + 1
        Next

        frmConsultaGeneralCompara.lvGanado.EndUpdate()

        frmConsultaGeneralCompara.pbProcesa.Maximum = (frmBastonV2.lvBASTON.Items.Count) + (ComparaDIIOConsultaGeneral.Count)
        frmConsultaGeneralCompara.pnlProcesa.Visible = False

        frmConsultaGeneralCompara.Label8.Text = cont_compara.ToString.Trim
        frmConsultaGeneralCompara.Label9.Text = cont_comperr1.ToString.Trim
        frmConsultaGeneralCompara.Label13.Text = cont_comperr2.ToString.Trim

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnCampos_Click(sender As System.Object, e As System.EventArgs) Handles btnCampos.Click

        Me.Enabled = False

        frmConsultaGeneralCampos.MdiParent = frmMAIN
        frmConsultaGeneralCampos.Show()
        frmConsultaGeneralCampos.BringToFront()

    End Sub

    Private Sub frmConsultaGeneral_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(3).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If

        End If
    End Sub


    Private Sub frmConsultaGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.CGPerfiles.Cargar()
        General.Categorias.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.MinimumSize = Me.Size
        Me.KeyPreview = True

        cboOrdenarPor.SelectedIndex = 0         'ordenar por centro
        cboTipoOrden.SelectedIndex = 0          'ascendente

        GuardarColumnas()
        CboLLenaCategorias()
        CboLLenaCentros()
        CboLLenaPerfiles()

        chklvEstados.SetItemCheckState(3, CheckState.Checked)   'preñada
        pnlEstado.BackColor = Color.LimeGreen
    End Sub


    Private Sub GuardarColumnas()
        Dim i As Integer


        For i = 0 To lvGanado.Columns.Count - 1

            ReDim Preserve PColNombres(i)
            ReDim Preserve PColAnchos(i)

            PColNombres(i) = lvGanado.Columns(i).Text
            PColAnchos(i) = lvGanado.Columns(i).Width

        Next
    End Sub

    Private Sub cboPerfilesColumnas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPerfilesColumnas.SelectedIndexChanged
        If cboPerfilesColumnas.Text = "" Then Exit Sub
        Dim i As Integer

        lvGanado.BeginUpdate()

        If cboPerfilesColumnas.Text = "(SGL)" Then

            For i = 0 To lvGanado.Columns.Count - 1
                lvGanado.Columns(i).Width = PColAnchos(i)
            Next

        Else
            Dim codperfil As Integer = General.CGPerfiles.Codigo(cboPerfilesColumnas.SelectedIndex - 1)
            Dim x As Integer

            ObtieneColumnasPerfil(codperfil)

            For i = 0 To lvGanado.Columns.Count - 1

                lvGanado.Columns(i).Width = 0
                For x = 0 To UBound(PColNombresSelec)

                    If lvGanado.Columns(i).Text = PColNombresSelec(x) Then
                        lvGanado.Columns(i).Width = PColAnchosSelec(x)
                        Exit For
                    End If
                Next
            Next
        End If
        lvGanado.EndUpdate()
    End Sub


    Private Sub ObtieneColumnasPerfil(ByVal perfil As Integer)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCGPerfiles_BuscarColumnas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Codigo", perfil)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                Dim i As Integer = 0

                While rdr.Read()
                    ReDim Preserve PColNombresSelec(i)
                    ReDim Preserve PColAnchosSelec(i)

                    PColNombresSelec(i) = rdr("PColNombreColumna").ToString.Trim
                    PColAnchosSelec(i) = rdr("PColAncho").ToString.Trim

                    i = i + 1
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


    Private Sub mnuAgregarPremium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAgregarPremium.Click
        If lvGanado.SelectedItems.Count < 1 Then Exit Sub

        If MsgBox("¿DESEA MARCAR COMO --- PREMIUM --- LOS ANIMALES SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMAR") = vbYes Then
            For Each itm As ListViewItem In lvGanado.SelectedItems
                If AgregarAnimalPremium(itm.SubItems(3).Text) = True Then
                    itm.SubItems(31).Text = "SI"

                    For x As Integer = 0 To lvGanado.Columns.Count - 1
                        itm.SubItems(x).ForeColor = Color.Green
                    Next
                End If
            Next

        End If
    End Sub


    Private Sub mnuQuitarPremium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuitarPremium.Click
        If lvGanado.SelectedItems.Count < 1 Then Exit Sub

        If MsgBox("¿DESEA QUITAR LA MARCA --- PREMIUM --- DE LOS ANIMALES SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMAR") = vbYes Then
            For Each itm As ListViewItem In lvGanado.SelectedItems
                If QuitarAnimalPremium(itm.SubItems(3).Text) = True Then
                    itm.SubItems(31).Text = ""

                    For x As Integer = 0 To lvGanado.Columns.Count - 1
                        itm.SubItems(x).ForeColor = SystemColors.WindowText
                    Next
                End If
            Next
        End If
    End Sub


    Private Sub mnuLiberarCojera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLiberarCojera.Click
        If lvGanado.SelectedItems.Count < 1 Then Exit Sub

        If MsgBox("¿DESEA LIBERAR DE --- COJERA --- A LOS ANIMALES SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMAR") = vbYes Then
            For Each itm As ListViewItem In lvGanado.SelectedItems
                'dentro del grupo seleccionado, solo se procesaran las que esten con cojera
                If itm.SubItems(43).Text = "SI" Then
                    If LiberarCojera(itm.SubItems(3).Text) = True Then
                        itm.SubItems(43).Text = ""
                    End If
                End If
            Next
        End If
    End Sub


    Private Function AgregarAnimalPremium(ByVal diio As String) As Boolean
        AgregarAnimalPremium = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_AgregarPremium", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        ''
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", diio)
        ''
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            AgregarAnimalPremium = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function QuitarAnimalPremium(ByVal diio As String) As Boolean
        QuitarAnimalPremium = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_QuitarPremium", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        ''
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", diio)
        ''
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            QuitarAnimalPremium = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function LiberarCojera(ByVal diio As String) As Boolean
        LiberarCojera = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_LiberarCojera", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        ''
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Diio", diio)
        ''
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            LiberarCojera = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function



    Private Sub frmConsultaGeneral_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Dim aux_, width_ As Integer

        'If Me.Width < 1152 Then
        '    Me.Width = 1152
        '    Exit Sub
        'End If

        'If Me.Height < 652 Then
        '    Me.Height = 652
        '    Exit Sub
        'End If

        aux_ = 7
        width_ = Me.Width - (lvGanado.Left * 4)
        ''
        pnlOrden.Width = width_
        ''
        lvGanado.Width = width_
        lvGanado.Height = Me.Height - lvGanado.Top - 155
        ''
        Panel4.Top = lvGanado.Top + lvGanado.Height + aux_
        Panel2.Top = lvGanado.Top + lvGanado.Height + aux_ + Panel4.Height
        Panel3.Top = lvGanado.Top + lvGanado.Height + aux_ + Panel4.Height + Panel2.Height
        ''
        pnlTotCategoria.Width = width_ - Panel4.Width - 1
        pnlEstProd.Width = width_ - Panel2.Width - 1
        pnlEstReprod.Width = width_ - Panel3.Width - 1
        ''
        pnlTotCategoria.Top = Panel4.Top
        pnlEstProd.Top = Panel2.Top
        pnlEstReprod.Top = Panel3.Top
        ''
        btnBuscar.Left = lvGanado.Left + lvGanado.Width - btnSalir.Width
        btnLimpiarFiltros.Left = btnBuscar.Left - btnLimpiarFiltros.Width - 4
        btnLimpiarOrden.Left = btnLimpiarFiltros.Left - btnLimpiarOrden.Width - 4
        ''
        btnExcel.Top = pnlEstReprod.Top + pnlEstReprod.Height + aux_
        btnImprime.Top = pnlEstReprod.Top + pnlEstReprod.Height + aux_
        btnBaston.Top = pnlEstReprod.Top + pnlEstReprod.Height + aux_
        btnAlarmas.Top = pnlEstReprod.Top + pnlEstReprod.Height + aux_
        btnArchivoSIPEC.Top = pnlEstReprod.Top + pnlEstReprod.Height + aux_
        btnSalir.Top = pnlEstReprod.Top + pnlEstReprod.Height + aux_

        btnSalir.Left = lvGanado.Left + lvGanado.Width - btnSalir.Width
    End Sub


    Private Sub lvGanado_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseClick
        'si los usuarios no son administradores de sala y de sistema, quitamos premium y liberacion de cojeras
        If PerfilUsuario <> 2 And PerfilUsuario <> 5 Then
            mnuSep3.Visible = False
            mnuAgregarPremium.Visible = False
            mnuQuitarPremium.Visible = False
            mnuSep4.Visible = False
            mnuLiberarCojera.Visible = False
        End If
    End Sub


    Private Sub btnArchivoSIPEC_Click(sender As System.Object, e As System.EventArgs) Handles btnArchivoSIPEC.Click
        If lvGanado.Items.Count = 0 Then Exit Sub
        ExportToExcelGrillaSIPEC(lvGanado)
    End Sub

    Private Sub MenuGanado_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuGanado.Opening

    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lvGanado.Items.Count = 0 Then Exit Sub
        ExportToExcelGrillaEmpresas(lvGanado)
    End Sub
End Class
