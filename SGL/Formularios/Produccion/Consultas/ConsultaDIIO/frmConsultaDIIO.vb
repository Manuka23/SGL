

Imports System.Data.SqlClient


Public Class infodiios
    Dim EsCompra As Integer = 0

    Private Sub LimpiaDatos()
        'txtDIIO.Text = ""
        lblSala.Text = ""
        lblCategoria.Text = ""
        '
        lblEstado.Text = ""
        lblSexo.Text = ""
        lblRaza.Text = ""
        lblLote.Text = ""
        lblFecNacimiento.Text = ""
        lblEstProductivo.Text = ""
        lblEstReproductivo.Text = ""
        lblEstSalud.Text = ""
        lblMadre.Text = ""
        lblPadre.Text = ""
        lblAbuelo.Text = ""
        lblCenSalida.Text = ""
        lblCenEntrada.Text = ""
        lblEstLactancia.Text = ""
        lblCodLactancia.Text = ""
        lblCodProduccion.Text = ""
        '
        lblCojera.Text = ""
        lblPesoActual.Text = ""
        lblPatologia.Text = ""
        lblNroCojeras.Text = ""
        lblNroMastitis.Text = ""
        lblFecUltMastitis.Text = ""
        lblFecAltaUltMastitis.Text = ""
        lblNroOtrosTrat.Text = ""
        lblFecUltCojera.Text = ""
        lblFecAltaUltCojera.Text = ""
        '
        lblOtrosTrat.Text = ""
        lblNroOtrosTrat.Text = ""
        lblFecUltOtrosTrat.Text = ""
        lblFecAltaUltOtrosTrat.Text = ""
        '
        lblPremium.Text = ""
        lblAretePremiun.Text = ""
        lblAreteMetalico.Text = ""
        '
        lblFechaSalida.Text = ""
        lblGuiaSalida.Text = ""
    End Sub


    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    If rdr("CenDesCor").ToString.Trim = "" Then
                        lblSala.Text = "--- SIN SALA ----"
                        lblSala.ForeColor = Color.Red
                    Else
                        lblSala.Text = rdr("CenDesCor").ToString.Trim
                        lblSala.ForeColor = SystemColors.ControlText
                    End If
                    lblEmpresa.Text = rdr("EmpresaNom").ToString.Trim
                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    '
                    lblSexo.Text = rdr("GndSexo").ToString.Trim
                    lblRaza.Text = rdr("RazaNom").ToString.Trim
                    lblLote.Text = rdr("GndLoteCod").ToString.Trim
                    '
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
                    lblEstSalud.Text = rdr("GndEstadoSalud").ToString.Trim
                    lblMadre.Text = rdr("GndMadre").ToString.Trim
                    lblPadre.Text = rdr("GndPadre").ToString.Trim
                    lblAbuelo.Text = rdr("GndAbuelo").ToString.Trim
                    lblCenSalida.Text = rdr("CentroSalida").ToString.Trim
                    lblCenEntrada.Text = rdr("CentroEntrada").ToString.Trim
                    lblEstLactancia.Text = rdr("GndEstadoLactancia").ToString.Trim
                    lblCodLactancia.Text = rdr("GrpLactanciaCod").ToString.Trim
                    lblCodProduccion.Text = rdr("GrpProduccionCod").ToString.Trim
                    '
                    Lblpesoactual.Text = rdr("GndPesoAct").ToString.Trim
                    lblPatologia.Text = rdr("GndPatologia").ToString.Trim
                    lblVPadre.Text = rdr("GndBWPadrePercent").ToString.Trim
                    lblVAbuelo.Text = rdr("GndBWAbueloPercent").ToString.Trim
                    lblBisabuelo.Text = rdr("GndBisAbuelo").ToString.Trim
                    lblVBisabuelo.Text = rdr("GndBWBisAbueloPercent").ToString.Trim
                    lblVTotal.Text = rdr("GndBWTotal").ToString.Trim

                    ''COJERA
                    lblCojera.Text = rdr("GndIsCoja").ToString.Trim
                    If rdr("NroCojeras") > 0 Then lblNroCojeras.Text = rdr("NroCojeras").ToString.Trim
                    If FechaCorrecta(rdr("GndCojerasFecUlt").ToString) = True Then lblFecUltCojera.Text = Format(rdr("GndCojerasFecUlt"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("GndCojerasFecUltAlta").ToString) = True Then lblFecAltaUltCojera.Text = Format(rdr("GndCojerasFecUltAlta"), "dd-MM-yyyy")
                    ''--------------
                    lblCojera.ForeColor = IIf(lblCojera.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblNroCojeras.ForeColor = IIf(lblCojera.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblFecUltCojera.ForeColor = IIf(lblCojera.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblFecAltaUltCojera.ForeColor = IIf(lblCojera.Text = "SI", Color.Red, SystemColors.ControlText)

                    ''MASTITIS
                    lblMastitis.Text = rdr("GndIsMastitis").ToString.Trim
                    If rdr("NroMastitis") > 0 Then lblNroMastitis.Text = rdr("NroMastitis").ToString.Trim
                    If FechaCorrecta(rdr("GndMastitisFecUlt").ToString) = True Then lblFecUltMastitis.Text = Format(rdr("GndMastitisFecUlt"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("GndMastitisFecUltAlta").ToString) = True Then lblFecAltaUltMastitis.Text = Format(rdr("GndMastitisFecUltAlta"), "dd-MM-yyyy")
                    ''--------------
                    lblMastitis.ForeColor = IIf(lblMastitis.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblNroMastitis.ForeColor = IIf(lblMastitis.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblFecUltMastitis.ForeColor = IIf(lblMastitis.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblFecAltaUltMastitis.ForeColor = IIf(lblMastitis.Text = "SI", Color.Red, SystemColors.ControlText)

                    ''OTROS TRATAMIENTOS
                    lblOtrosTrat.Text = rdr("GndIsOtrosTratamiemtos").ToString.Trim
                    If rdr("NroOtrosTratamientos") > 0 Then lblNroOtrosTrat.Text = rdr("NroOtrosTratamientos").ToString.Trim
                    If FechaCorrecta(rdr("GndOtrosTratamientosFecUlt").ToString) = True Then lblFecUltOtrosTrat.Text = Format(rdr("GndOtrosTratamientosFecUlt"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("GndOtrosTratamientosFecUltAlta").ToString) = True Then lblFecAltaUltOtrosTrat.Text = Format(rdr("GndOtrosTratamientosFecUltAlta"), "dd-MM-yyyy")
                    ''--------------
                    lblOtrosTrat.ForeColor = IIf(lblOtrosTrat.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblNroOtrosTrat.ForeColor = IIf(lblOtrosTrat.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblFecUltOtrosTrat.ForeColor = IIf(lblOtrosTrat.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblFecAltaUltOtrosTrat.ForeColor = IIf(lblOtrosTrat.Text = "SI", Color.Red, SystemColors.ControlText)

                    ''MUESTREOS
                    lblMuestreo.Text = rdr("GndIsMuestreo").ToString.Trim
                    If rdr("NroMuestreos") > 0 Then lblNroMuestreos.Text = rdr("NroMuestreos").ToString.Trim
                    'If rdr("GndMuestreosNum") > 0 Then lblNroMuestreos.Text = rdr("GndMuestreosNum").ToString.Trim
                    If FechaCorrecta(rdr("GndMuestreosFecUlt").ToString) = True Then lblFecUltMuestreo.Text = Format(rdr("GndMuestreosFecUlt"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("GndMuestreosFecUltAlta").ToString) = True Then lblFecAltaUltMuestreo.Text = Format(rdr("GndMuestreosFecUltAlta"), "dd-MM-yyyy")
                    ''--------------
                    lblMuestreo.ForeColor = IIf(lblMuestreo.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblNroMuestreos.ForeColor = IIf(lblMuestreo.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblFecUltMuestreo.ForeColor = IIf(lblMuestreo.Text = "SI", Color.Red, SystemColors.ControlText)
                    lblFecAltaUltMuestreo.ForeColor = IIf(lblMuestreo.Text = "SI", Color.Red, SystemColors.ControlText)

                    lblDiasLactancia.Text = rdr("DiasLac").ToString.Trim

                    lblGuiaSalida.Text = rdr("GndCenSalGuia").ToString.Trim

                    If FechaCorrecta(rdr("GndFecNac").ToString) = True Then lblFecNacimiento.Text = Format(rdr("GndFecNac"), "dd-MM-yyyy")
                    '
                    '**** NUEVOS
                    'Datos Partos
                    If FechaCorrecta(rdr("GndUltFechaParto").ToString) = True Then LblUltFechaParto.Text = Format(rdr("GndUltFechaParto"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("GndUltFechaPriPartos").ToString) = True Then LblFecPrimerParto.Text = Format(rdr("GndUltFechaPriPartos"), "dd-MM-yyyy")
                    LblActPartosNum.Text = rdr("GndActPartosNum").ToString.Trim
                    'Datos Ultima Cubierta
                    If FechaCorrecta(rdr("GndUltCubierta").ToString) = True Then lblUltFecCubierta.Text = Format(rdr("GndUltCubierta"), "dd-MM-yyyy")
                    lblUltCubiertaToro.Text = rdr("ToroNomUltCub").ToString.Trim
                    lblCubiertaNum.Text = rdr("GndUltCubiertaNum").ToString.Trim
                    'Datos Ultima Palpacion
                    If FechaCorrecta(rdr("GndUltFechaPalpacionPP").ToString) = True Then lblFecUltPlp.Text = Format(rdr("GndUltFechaPalpacionPP"), "dd-MM-yyyy")
                    lblUltCondPlp.Text = rdr("GndCondicionPalpacion")
                    If FechaCorrecta(rdr("GndUltFechaPP").ToString) = True Then LblUltFechaPP.Text = Format(rdr("GndUltFechaPP"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("GndUltFechaPrenez").ToString) = True Then lblFechaPreñez.Text = Format(rdr("GndUltFechaPrenez"), "dd-MM-yyyy")
                    lblToroPreñez.Text = rdr("ToroNomPrn").ToString.Trim
                    '
                    If FechaCorrecta(rdr("GndUltFechaSecado").ToString) = True Then LblUltFechaSecado.Text = Format(rdr("GndUltFechaSecado"), "dd-MM-yyyy")
                    '
                    If FechaCorrecta(rdr("GndCenSalFec").ToString) = True Then lblFechaSalida.Text = Format(rdr("GndCenSalFec"), "dd-MM-yyyy")

                    '
                    If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        lblEstado.Text = "DESAPARECIDO"
                        lblEstado.ForeColor = Color.Red
                    ElseIf rdr("GndIsVendido").ToString.Trim = "SI" Then
                        lblEstado.Text = "VENDIDO"
                        lblEstado.ForeColor = Color.Red
                    ElseIf rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        lblEstado.Text = "MUERTO"
                        lblEstado.ForeColor = Color.Red
                    Else
                        lblEstado.Text = "STOCK"
                        lblEstado.ForeColor = Color.DarkBlue
                    End If

                    Select Case lblEstado.Text
                        Case "MUERTO"
                            If IsDate(rdr("GndIsMuertoFecha")) Then lblFechaEstado.Text = Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy")
                            lblFechaEstado.ForeColor = Color.Red
                        Case "VENDIDO"
                            If IsDate(rdr("GndIsVendidoFecha")) Then lblFechaEstado.Text = Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy")
                            lblFechaEstado.ForeColor = Color.Red
                        Case "DESAPARECIDO"
                            If IsDate(rdr("GndIsDesaparecidoFecha")) Then lblFechaEstado.Text = Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy")
                            lblFechaEstado.ForeColor = Color.Red
                        Case Else
                            lblFechaEstado.Text = ""
                            lblFechaEstado.ForeColor = SystemColors.ControlText
                    End Select

                    lblAreteMetalico.Text = IIf(rdr("GndMetalico").ToString.Trim = 0, "", rdr("GndMetalico").ToString.Trim)

                    If rdr("GndPremiun").ToString.Trim <> "" Then
                        lblAretePremiun.Text = rdr("GndPremiun").ToString.Trim
                        lblPremium.Text = "SI"
                        lblAretePremiun.ForeColor = Color.Green
                        lblPremium.ForeColor = Color.Green
                    Else
                        lblPremium.Text = "NO"
                    End If

                    Existe = True
                End While

                If Existe = True Then
                    'lblSala.ForeColor = SystemColors.ControlText

                    lblMadre.Cursor = Cursors.Default
                    'lblPadre.Cursor = Cursors.Default
                    'lblAbuelo.Cursor = Cursors.Default

                    If lblMadre.Text <> "" Then lblMadre.Cursor = Cursors.Hand
                    'If lblPadre.Text <> "" Then lblPadre.Cursor = Cursors.Hand
                    'If lblAbuelo.Text <> "" Then lblAbuelo.Cursor = Cursors.Hand
                Else
                    lblSala.Text = "---- REGISTRO NO EXISTE ----"
                    lblSala.ForeColor = Color.Red
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try


        'una vez consultado el diio, vamos a buscar sus informacion reproductiva
        'BuscarInfSanitariaMastitis(CodigoDIIO)
        BuscarInfSanitaria(CodigoDIIO)
        'BuscarInfVacunas(CodigoDIIO)
        BuscarInfReproductiva(CodigoDIIO)
        'BuscarInfReproductivaParto(CodigoDIIO)
        BuscarTrazabilidad(CodigoDIIO)

        BuscarCambiosDiios(CodigoDIIO)
        BuscarCompra(CodigoDIIO)
        BuscarPabco(CodigoDIIO)
    End Sub
    Private Sub BuscarCompra(ByVal ddio_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDiios_ConsultaCompra", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@DIIO", ddio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)



        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()

                    Proveedorlbl.Text = rdr("CmpProveedor").ToString.Trim
                    Ruplbl.Text = rdr("CmpRUP").ToString.Trim
                    FMAlbl.Text = rdr("CmpNroFMA").ToString.Trim
                    NGuialbl.Text = rdr("CmpNroGuia").ToString.Trim
                    CentroDestinolbl.Text = rdr("CentroNom").ToString.Trim
                    Registradolbl.Text = rdr("CmpUsuario").ToString.Trim

                    Equipolbl.Text = rdr("CmpEquipo").ToString.Trim
                    NumeroPartoslbl.Text = rdr("GndActPartosNumInicial").ToString.Trim
                    Partosiniciallb2.Text = rdr("GndActPartosNumInicial").ToString.Trim
                    Productivolbl.Text = rdr("CDetEstProductivo").ToString.Trim
                    Reproductivolbl.Text = rdr("CDetEstReproductivo").ToString.Trim

                    If rdr("NoExiste").ToString = "Si" Then

                        Compradolbl.Text = "SI"
                        FechaCompralbl.Text = Format(rdr("CmpFecha"), "dd-MM-yyyy")
                        FechaIngresoLBL.Text = Format(rdr("CmpFechaReg"), "dd-MM-yyyy")
                        lblDIIO.BackColor = Color.LimeGreen
                        EsCompra = 1
                    Else
                        Compradolbl.Text = "NO"
                        Compradolbl.BackColor = Color.Transparent
                        Comprado.BackColor = Color.Transparent
                        FechaCompralbl.Text = ""
                        FechaIngresoLBL.Text = ""
                        EsCompra = 0
                    End If

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
    Private Sub BuscarInfVacunas(ByVal ddio_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_Vacunas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@DIIO", ddio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvSanitaria.BeginUpdate()
        lvSanitaria.Items.Clear()

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    lvSanitaria.Items.Add(Format(rdr("fecha"), "dd-MM-yyyy"))    'primera columna
                    lvSanitaria.Items.Add(Format(rdr("centro").ToString.Trim))
                    lvSanitaria.Items.Add("Vacunacion")
                    lvSanitaria.Items.Add(rdr("nombre").ToString.Trim)
                    lvSanitaria.Items.Add("")

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

        lvSanitaria.EndUpdate()
    End Sub
    Private Sub BuscarInfSanitaria(ByVal ddio_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_InfSanitaria", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@DIIO", ddio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvSanitaria.BeginUpdate()
        lvSanitaria.Items.Clear()

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem(Format(rdr("ISanFecha"), "dd-MM-yyyy"))    'primera columna

                    item.SubItems.Add(Format(rdr("ISanCentro").ToString.Trim))
                    item.SubItems.Add(rdr("ISanTipoEvento").ToString.Trim)
                    item.SubItems.Add(rdr("ISanObservs").ToString.Trim)
                    item.SubItems.Add(rdr("ISanEstado").ToString.Trim)
                    'item.SubItems.Add()

                    lvSanitaria.Items.Add(item)

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

        lvSanitaria.EndUpdate()
    End Sub
    Private Sub BuscarInfReproductiva(ByVal ddio_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_InfReproductiva", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@DIIO", ddio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvReprod.BeginUpdate()
        lvReprod.Items.Clear()

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)    'primera columna

                    item.SubItems.Add(Format(rdr("IRepFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("IRepCentro").ToString.Trim)
                    item.SubItems.Add(rdr("IRepTipoEvento").ToString.Trim)
                    item.SubItems.Add(rdr("IRepObservs").ToString.Trim)

                    lvReprod.Items.Add(item)

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

        lvReprod.EndUpdate()
    End Sub
    Private Sub BuscarTrazabilidad(ByVal ddio_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_ListadoPorDiio", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@DIIO", ddio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvTrazabilidad.BeginUpdate()
        lvTrazabilidad.Items.Clear()

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)    'primera columna

                    item.SubItems.Add(Format(rdr("FechaHora"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("Movimiento").ToString.Trim)
                    item.SubItems.Add(rdr("CentOrigen").ToString.Trim)
                    item.SubItems.Add(rdr("CentDestino").ToString.Trim)
                    item.SubItems.Add(rdr("Guia").ToString.Trim)

                    lvTrazabilidad.Items.Add(item)

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

        lvTrazabilidad.EndUpdate()
    End Sub

    Private Sub BuscarCambiosDiios(ByVal ddio_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spDiios_ListadoHistorial", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@DIIO", ddio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvHistorialDiios.BeginUpdate()
        lvHistorialDiios.Items.Clear()

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)    'primera columna

                    item.SubItems.Add(Format(rdr("CambioDiioFecha"), "dd-MM-yyyy"))
                    '   fecha = rdr("CambioDiioFecha")
                    item.SubItems.Add(rdr("DiioAnterior").ToString.Trim)
                    ' ant = rdr("DiioAnterior")
                    lvHistorialDiios.Items.Add(item)

                    BuscarCambiosDiios(rdr("DiioAnterior").ToString.Trim)

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

        lvHistorialDiios.EndUpdate()
    End Sub

    Private Sub lblMadre_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblMadre.MouseClick
        If lblMadre.Text.Trim = "" Then Exit Sub

        If e.Button = MouseButtons.Left Then
            Dim ConsultaDIIO As New infodiios

            ConsultaDIIO.MdiParent = frmMAIN
            ConsultaDIIO.lblDIIO.Text = lblMadre.Text.Trim
            ConsultaDIIO.ConsultaDIIO(lblMadre.Text.Trim)

            Cursor.Current = Cursors.WaitCursor

            ConsultaDIIO.Show()

            Cursor.Current = Cursors.Default
        End If
    End Sub

    'Private Sub BuscarInfReproductiva2(ByVal ddio_ As String)
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spPalpaciones_ListadoPorDiio", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@DIIO", ddio_)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    lvReprod.BeginUpdate()
    '    lvReprod.Items.Clear()

    '    Dim i As Integer = 0
    '    Dim e As Integer = 0
    '    Dim vret As Integer = 0

    '    Try
    '        con.Open()
    '        rdr = cmd.ExecuteReader()

    '        Try
    '            While rdr.Read()
    '                Dim item As New ListViewItem((i + 1).ToString)    'primera columna

    '                item.SubItems.Add(Format(rdr("PlpFec"), "dd-MM-yyyy"))
    '                item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
    '                item.SubItems.Add(rdr("TipoEvento").ToString.Trim)
    '                item.SubItems.Add(rdr("Observs").ToString.Trim)

    '                lvReprod.Items.Add(item)

    '                i = i + 1
    '            End While

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try

    '    lvReprod.EndUpdate()
    'End Sub
    Private Sub btnBuscaDIIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaDIIO(lblDIIO.Text)
    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        MsgBox(lblNroMastitis.Text)
    End Sub

    Private Sub frmConsultaDIIO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub


    Private Sub frmConsultaDIIO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.Clear()
                Clipboard.SetText(lblDIIO.Text)
            End If
        End If
    End Sub

    Private Sub frmConsultaDIIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True
        TabControl1.TabPages.Clear()
        TabControl1.TabPages.Add(TabPage1)
        TabControl1.TabPages.Add(TabPage2)
        TabControl1.TabPages.Add(TabPage3)
        TabControl1.TabPages.Add(TabPage4)
        If EsCompra = 1 Then
            TabControl1.TabPages.Add(TabPage5)
        End If
        TabControl1.TabPages.Add(TabPage6)
    End Sub

    Private Sub BuscarPabco(ByVal ddio_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPabco_Ficha", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@DIIO", ddio_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvPabco.BeginUpdate()
        lvPabco.Items.Clear()

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((rdr("CentroNomCorto").ToString.Trim))
                    item.SubItems.Add(rdr("NomPatologia").ToString.Trim)
                    item.SubItems.Add(rdr("MedNombre").ToString.Trim)
                    item.SubItems.Add(Format(rdr("TratFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(Format(rdr("TratResguardoLeche"), "dd-MM-yyyy"))
                    item.SubItems.Add(Format(rdr("TratResguardoCarne"), "dd-MM-yyyy"))
                    item.SubItems.Add(Format(rdr("TratFinTratamiento"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("TratDosis").ToString.Trim)
                    lvPabco.Items.Add(item)

                    If i = 0 Then
                        If rdr("TratFinTratamiento") = "1900-01-01" Then
                            lblLeche.Text = "EN TRATAMIENTO"
                            lblLeche.ForeColor = Color.Red
                            lblFecTermino.Text = "--/--/----"
                            lblEstLote.ForeColor = Color.Red
                        Else
                            lblLeche.Text = "LEBERADA"
                            lblLeche.ForeColor = Color.Green
                            lblFecTermino.Text = rdr("TratFinTratamiento")
                            lblEstLote.ForeColor = Color.Green
                        End If
                        If rdr("TratAD") = "SI" Then
                            chkAD.Checked = True
                        End If
                        If rdr("TratAI") = "SI" Then
                            chkAI.Checked = True
                        End If
                        If rdr("TratPD") = "SI" Then
                            chkPD.Checked = True
                        End If
                        If rdr("TratPI") = "SI" Then
                            chkPI.Checked = True
                        End If
                        lblEstLote.Text = rdr("TratEstado")

                        If IsDBNull(rdr("Dexabiopen")) Then
                            lblFecTermino.Text = "--/--/----"
                        Else
                            lblDexabiopen.Text = rdr("Dexabiopen")
                        End If
                    End If

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
        lvPabco.EndUpdate()
        TabControl1.SelectedIndex = 5
    End Sub
End Class