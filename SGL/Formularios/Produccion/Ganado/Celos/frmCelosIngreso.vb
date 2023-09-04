﻿

Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient


Public Class frmCelosIngreso

    Public Param1_Modo As Integer       '1=ingreso celo / 2=muestra celo / 3=muestra sin celo / 4 = muestra celos anormales
    Public Param2_Empresa As Integer
    Public Param3_CentroCod As String
    Public Param3_CentroNom As String
    Public Param4_FechaDesde As Date
    Public Param4_FechaHasta As Date
    Public Param5_Observs As String
    ''
    'Public Param6_FechaHasta As String


    'declaramos formulario baston


    Property Param4_Fecha As Date



    Private Sub LeeBaston()

        If Param1_Modo = 3 Or Param1_Modo = 4 Then
            frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            frmBastonV2.Param1_CentroCod = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        End If

        frmBastonV2.Param2_CentroNom = cboCentros.Text
        frmBastonV2.Param3_Formulario = "frmCelosIngreso"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub



    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        'Dim inichk_ As Integer = lvDIIOS.Items.Count '- 1
        Dim TotDiios As Integer

        Cursor.Current = Cursors.WaitCursor

        lvDIIOS.Items.Clear()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","

            Dim item As New ListViewItem((i + 1).ToString)    'nro

            item.SubItems.Add(diio_)
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            'item.SubItems.Add("")
            'item.SubItems.Add("")

            If VerificaDIIOEnGrilla(-1, diio_) = True Then
                item.SubItems.Add("ERR / REPETIDO")
            Else
                item.SubItems.Add("ERR / NO EXISTE EN BD")
            End If

            lvDIIOS.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If

        TotDiios = BuscarDiiosBaston(strdiios_)
        ContabilizaYValidaDIIOs()

        Cursor.Current = Cursors.Default

        'If strdiios_.Length > 0 Then
        '    strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        'End If

        'BuscarDiiosBaston(inichk_, strdiios_)

        'btnFinalizar.Enabled = True
        'btnEliminar.Enabled = True
        'btnPrevisualizar.Enabled = True
    End Sub


    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvDIIOS.Items.Count - 1
            If i <> pos_ Then
                If lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function


    Public Sub ContabilizaYValidaDIIOs()
        Dim i As Integer = 0
        'Dim totsec_ As Integer = 0
        Dim err_ As Integer = 0
        Dim estado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            lvDIIOS.Items(i).Text = (i + 1).ToString.Trim
            estado_ = lvDIIOS.Items(i).SubItems(9).Text.Trim

            If Mid(estado_, 1, 3) = "ERR" Then
                err_ += 1
            End If
        Next

        lblTotCelos.Text = i.ToString.Trim
        lblTotErrores.Text = err_.ToString.Trim

        If lvDIIOS.Items.Count = 0 Then Exit Sub

        If err_ = 0 Then
            btnFinalizar.Enabled = True
            btnEliminar.Enabled = True
            'btnPrevisualizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
            btnEliminar.Enabled = True
            'btnPrevisualizar.Enabled = False
        End If
    End Sub


    Private Function GeneraStringDIIOs() As String
        GeneraStringDIIOs = ""

        Dim i As Integer = 0
        Dim str_ As String = ""
        Dim estado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            estado_ = lvDIIOS.Items(i).SubItems(9).Text.Trim

            If estado_ = "" Or Mid(estado_, 1, 3) = "MSJ" Then
                str_ = str_ + lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim + ","
            End If
        Next

        If str_.Length > 0 Then
            str_ = Mid(str_, 1, str_.Length - 1)
        End If

        GeneraStringDIIOs = str_
    End Function


    Private Sub LimpiaDatos()
        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        'dtpFecha.Value = Now()
    End Sub

    Private Sub LimpiaDatos2()
        lblCategoria.Text = "---"
        lblEstProductivo.Text = "---"
        lblEstReproductivo.Text = "---"
        'dtpFecha.Value = Now()
        txtDIIO.Text = ""
        txtObservs.Text = ""
    End Sub



    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        If Param1_Modo = 3 Or Param1_Modo = 4 Then
            cboCentros.Items.Add("(TODOS)")
        End If

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        'cboCentros.SelectedIndex = 0
    End Sub


    'devuelve el nro de errores en los diios
    Private Function BuscarDiiosBaston(ByVal diios_ As String) As Integer
        BuscarDiiosBaston = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ListadoBaston", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        'Dim diios_ As String = ""
        'diios_ = GeneraStringDIIOs()
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvDIIOS.BeginUpdate()
        'lvDIIOS.Items.Clear()
        'Label85.Text = "0"

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim diio_ As String = ""
        Dim est_, fec_, ncel_ As String
        'Dim existe_ As Boolean

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    diio_ = rdr("GndCod").ToString.Trim

                    For i = 0 To lvDIIOS.Items.Count - 1
                        If lvDIIOS.Items(i).SubItems(1).Text.Trim = diio_ Then


                            ncel_ = ""
                            fec_ = Format(rdr("FechaUltCelo"), "dd-MM-yyyy")

                            If IsDBNull(fec_) = True Or fec_ = "01-01-1753" Or fec_ = "01-01-1900" Then
                                fec_ = ""
                            End If

                            If rdr("NumeroCelos") > 0 Then ncel_ = rdr("NumeroCelos").ToString.Trim

                            lvDIIOS.Items(i).SubItems(2).Text = rdr("GndProNom").ToString.Trim

                            lvDIIOS.Items(i).SubItems(3).Text = fec_
                            lvDIIOS.Items(i).SubItems(4).Text = ncel_

                            lvDIIOS.Items(i).SubItems(5).Text = rdr("DiasLactancia").ToString.Trim
                            lvDIIOS.Items(i).SubItems(6).Text = rdr("GndActPartosNum").ToString.Trim

                            lvDIIOS.Items(i).SubItems(7).Text = rdr("GndEstadoProductivo").ToString.Trim
                            lvDIIOS.Items(i).SubItems(8).Text = rdr("GndEstadoReproductivo").ToString.Trim

                            If VerificaDIIOEnGrilla(i, diio_) = True Then
                                lvDIIOS.Items(i).SubItems(9).Text = "ERR / REPETIDO"
                                lblTotErrores.Text = Int32.Parse(lblTotErrores.Text) + 1
                            Else
                                est_ = ""

                                If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                                    est_ = "ERR / CENTRO (" + rdr("CenDesCor").ToString.Trim + ")"
                                End If

                                If rdr("GndIsVendido").ToString.Trim = "SI" Then
                                    est_ = "ERR / VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy")
                                End If

                                If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                                    est_ = "ERR / MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy")
                                End If

                                If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                                    est_ = "ERR / DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy")
                                End If

                                If rdr("GndProNom").ToString.Trim <> "VAQUILLAS" And rdr("GndProNom").ToString.Trim <> "VACAS" And rdr("GndProNom").ToString.Trim <> "VACAS TRASPASO" And rdr("GndProNom").ToString.Trim <> "VAQUILLAS TRASPASO" And rdr("GndProNom").ToString.Trim <> "VAQUILLAS OTOÑO" Then
                                    est_ = "ERR / CATEGORIA (" + rdr("GndProNom").ToString.Trim + ")"
                                End If

                                If est_ <> "" Then lblTotErrores.Text = Int32.Parse(lblTotErrores.Text) + 1

                                lvDIIOS.Items(i).SubItems(9).Text = est_
                            End If

                        End If
                    Next

                    'i = i + 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        BuscarDiiosBaston = i

        'lblTotSecados.Text = i.ToString.Trim
        lvDIIOS.EndUpdate()
    End Function


    Public Sub ConsultaDetalleCelos(ByVal cent_ As String, ByVal fecha_desde_ As Date, ByVal fecha_Hasta_ As Date)
        'lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = 0
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", fecha_desde_)
        cmd.Parameters.AddWithValue("@FechaHasta", fecha_Hasta_)
        'cmd.Parameters.AddWithValue("@DIIO", diio_)
        'cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        lblTotCelos.Text = "0"

        'lvGanado.Items.Clear()
        lvDIIOS.BeginUpdate()
        lvDIIOS.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0
        Dim fec_, ncel_ As String

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    'pbProcesa.Maximum = vret
                    'End If

                    ncel_ = ""
                    fec_ = Format(rdr("FechaUltCelo"), "dd-MM-yyyy")

                    If IsDBNull(fec_) = True Or fec_ = "01-01-1753" Or fec_ = "01-01-1900" Then
                        fec_ = ""
                    End If

                    If rdr("NumeroCelos") > 0 Then ncel_ = rdr("NumeroCelos").ToString.Trim

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("CDetDiio").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(fec_)
                    item.SubItems.Add(ncel_)
                    item.SubItems.Add(rdr("DiasLactancia").ToString.Trim)
                    item.SubItems.Add(rdr("GndActPartosNum").ToString.Trim)
                    item.SubItems.Add(rdr("CDetEstProductivo").ToString.Trim)                  'centro
                    item.SubItems.Add(rdr("CDetEstReproductivo").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add("")

                    lvDIIOS.Items.Add(item)

                    'ProcesaTotales(1)

                    i = i + 1
                    'pbProcesa.Value = i
                End While

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
        lvDIIOS.EndUpdate()
        lblTotCelos.Text = i.ToString.Trim
        'Total_General = i
        'MuestraTotales()
        'pnlProcesa.Visible = False
    End Sub



    Public Sub ConsultaDetalleSinCelos(ByVal cent_ As String)
        'lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = 0
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_ListadoDetalleSinCelos", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Dias", txtDias.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        lblTotCelos.Text = "0"

        'lvGanado.Items.Clear()
        lvDIIOS.BeginUpdate()
        lvDIIOS.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    'pbProcesa.Maximum = vret
                    'End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("DiasLactancia").ToString.Trim)
                    item.SubItems.Add(rdr("GndActPartosNum").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)                  'centro
                    item.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("EstadoSalud").ToString.Trim)

                    lvDIIOS.Items.Add(item)

                    'ProcesaTotales(1)

                    i = i + 1
                    'pbProcesa.Value = i
                End While

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
        lvDIIOS.EndUpdate()
        lblTotCelos.Text = i.ToString.Trim
        'Total_General = i
        'MuestraTotales()
        'pnlProcesa.Visible = False
    End Sub



    Public Sub ConsultaDetalleCelosAnormales(ByVal cent_ As String)
        'lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        'pbProcesa.Value = 0
        'pbProcesa.Maximum = 0
        'pnlProcesa.Visible = True
        'pnlProcesa.Refresh()

        'InicializaTotales()
        'MuestraTotales()


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_ListadoDetalleCelosAnormales", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        lblTotCelos.Text = "0"

        'lvGanado.Items.Clear()
        lvDIIOS2.BeginUpdate()
        lvDIIOS2.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    'If vret = 0 Then
                    '    vret = rdr("ContRegs")
                    '    'pbProcesa.Maximum = vret
                    'End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)

                    item.SubItems.Add(Format(rdr("Celo1"), "dd-MM-yyyy"))
                    item.SubItems.Add(Format(rdr("Celo2"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("DiasDiff").ToString.Trim)

                    item.SubItems.Add(rdr("NumeroCelos").ToString.Trim)

                    item.SubItems.Add(rdr("DiasLactancia").ToString.Trim)
                    item.SubItems.Add(rdr("GndActPartosNum").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)                  'centro
                    item.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)

                    'item.SubItems.Add("")

                    lvDIIOS2.Items.Add(item)

                    'ProcesaTotales(1)

                    i = i + 1
                    'pbProcesa.Value = i
                End While

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
        lvDIIOS2.EndUpdate()
        lblTotCelos.Text = i.ToString.Trim
        'Total_General = i
        'MuestraTotales()
        'pnlProcesa.Visible = False
    End Sub




    Public Sub ConsultaDIIO(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        Dim fpart_, fcub_, fpp_, fcel_, ncel_ As String
        'Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        fpart_ = ""
        fcub_ = ""
        fpp_ = ""
        fcel_ = ""
        ncel_ = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            LimpiaDatos()

            Try
                While rdr.Read()
                    If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                        If MsgBox("EL CENTRO DEL ANIMAL (" + rdr("CenDesCor").ToString.Trim + ") NO CORRESPONDE CON EL SELECCIONADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndIsVendido").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                        If MsgBox("EL ANIMAL SE ENCUENTRA DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("GndProNom").ToString.Trim <> "VAQUILLAS" And rdr("GndProNom").ToString.Trim <> "VACAS" And rdr("GndProNom").ToString.Trim <> "VACAS TRASPASO" And rdr("GndProNom").ToString.Trim <> "VAQUILLAS OTOÑO" And rdr("GndProNom").ToString.Trim <> "VAQUILLAS TRASPASO" Then
                        If MsgBox("LA CATEGORIA DEL ANIMAL NO CORRESPONDE A VACAS NI VAQUILLAS (" + rdr("GndProNom").ToString.Trim + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    fcel_ = Format(rdr("FechaUltCelo"), "dd-MM-yyyy")
                    If IsDBNull(fcel_) = True Or fcel_ = "01-01-1753" Or fcel_ = "01-01-1900" Then
                        fcel_ = ""
                    End If

                    If fcel_ = Format(dtpFecha.Value, "dd-MM-yyyy") Then
                        If MsgBox("EL ANIMAL YA TIENE INGRESADO UN CELO EL DIA DE HOY (" + fcel_ + ")", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        End If
                        Exit Try
                    End If

                    If rdr("NumeroCelos") > 0 Then ncel_ = rdr("NumeroCelos").ToString.Trim

                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
                    lblDiasLac.Text = rdr("DiasLac").ToString.Trim
                    lblNroPartos.Text = rdr("GndActPartosNum").ToString.Trim
                    lblFechaUltCelo.Text = fcel_
                    lblNroCelos.Text = ncel_

                    Existe = True
                End While

                If Existe = True Then
                    AgregaDiio()

                    btnFinalizar.Enabled = True
                    btnEliminar.Enabled = True
                    cboCentros.Enabled = False

                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                Else
                    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub



    Public Sub ConsultaDIIOSinValidaciones(ByVal CodigoDIIO As String)
        If CodigoDIIO.Trim = "" Then Exit Sub

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        'Dim Existe As Boolean = False
        'Dim fpart_, fcub_, fpp_ As String
        'Dim fc_ As DateTime

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'fpart_ = ""
        'fcub_ = ""
        'fpp_ = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            'LimpiaDatos()

            Try
                While rdr.Read()
                    'If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
                    '    If MsgBox("EL CENTRO DEL ANIMAL (" + rdr("CenDesCor").ToString.Trim + ") NO CORRESPONDE CON EL SELECCIONADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    '    End If
                    '    Exit Try
                    'End If

                    'If rdr("GndIsVendido").ToString.Trim = "SI" Then
                    '    If MsgBox("EL ANIMAL SE ENCUENTRA VENDIDO EL " + Format(rdr("GndIsVendidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    '    End If
                    '    Exit Try
                    'End If

                    'If rdr("GndIsMuerto").ToString.Trim = "SI" Then
                    '    If MsgBox("EL ANIMAL SE ENCUENTRA MUERTO EL " + Format(rdr("GndIsMuertoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    '    End If
                    '    Exit Try
                    'End If

                    'If rdr("GndIsDesaparecido").ToString.Trim = "SI" Then
                    '    If MsgBox("EL ANIMAL SE ENCUENTRA DESAPARECIDO EL " + Format(rdr("GndIsDesaparecidoFecha"), "dd-MM-yyyy"), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    '    End If
                    '    Exit Try
                    'End If

                    lblCategoria.Text = rdr("GndProNom").ToString.Trim
                    lblEstProductivo.Text = rdr("GndEstadoProductivo").ToString.Trim
                    lblEstReproductivo.Text = rdr("GndEstadoReproductivo").ToString.Trim
                    lblDiasLac.Text = rdr("DiasLac").ToString.Trim
                    lblNroPartos.Text = rdr("GndActPartosNum").ToString.Trim
                    'cboCentros.Enabled = False

                    'Existe = True
                End While

                'If Existe = True Then
                '    btnGrabar.Enabled = True
                '    dtpFecha.Focus()
                'Else
                '    MsgBox("EL DIIO INGRESADO (" + CodigoDIIO + ") NO EXISTE")
                '    txtDIIO.Text = ""
                '    txtDIIO.Focus()
                'End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Function GrabarGrupoCelo() As Boolean
        GrabarGrupoCelo = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_GrabarGrupo", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim diios_ As String = ""

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        diios_ = GeneraStringDIIOs()
        ''
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Observs", txtObservs.Text.Trim)
        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
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

            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            GrabarGrupoCelo = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function



    Private Sub GrabarCelo()

    End Sub


    Private Function EliminarDIIOCelo() As Boolean
        EliminarDIIOCelo = False

        If Param1_Modo = 1 Then
            For Each it As ListViewItem In lvDIIOS.SelectedItems
                lvDIIOS.Items.Remove(it)
            Next

            EliminarDIIOCelo = True
            Exit Function
        End If

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCelos_EliminarDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text
        'Dim fec_ As String = IIf(Param1_Modo = 1, dtpFecha)
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param3_CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", Param4_Fecha)
        cmd.Parameters.AddWithValue("@DIIO", diio_)
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

            EliminarDIIOCelo = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub EliminarCelo()
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR EL CELO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If EliminarDIIOCelo() = True Then
                'If MsgBox("DATO ELIMINADO --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                'End If

                'Cerrar()

                If Param1_Modo = 2 Then
                    frmCelos.LlenaGrilla()
                    ConsultaDetalleCelos(Param3_CentroCod, Param4_FechaDesde, Param4_FechaHasta)

                    If lvDIIOS.Items.Count = 0 Then
                        Cerrar()
                    End If
                Else
                    ContabilizaYValidaDIIOs()

                    If lvDIIOS.Items.Count = 0 Then
                        cboCentros.Enabled = True
                        btnFinalizar.Enabled = False
                        btnEliminar.Enabled = False
                    End If
                End If
            End If
        End If
    End Sub


    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If dtpFecha.Value > Now() Then
            If MsgBox("LA FECHA DEL DOCUMENTO DEBE SER MENOR O IGUAL A LA FECHA ACTUAL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            dtpFecha.Focus()
            Exit Function
        End If


        ValidacionesLocales = True
    End Function


    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If Param1_Modo = 1 Then
            lvDIIOS.Items.Clear()
            lblTotCelos.Text = "0"
            lblTotErrores.Text = "0"
            btnFinalizar.Enabled = False
            btnEliminar.Enabled = False
        Else
            LlenaGrilla()
        End If

        'If cboCentros.Text.Trim <> "" Then
        '    txtDIIO.Enabled = True
        '    btnBuscar.Enabled = True
        '    dtpFecha.Enabled = True
        '    txtObservs.Enabled = True
        'Else
        '    txtDIIO.Enabled = False
        '    btnBuscar.Enabled = False
        '    dtpFecha.Enabled = False
        '    txtObservs.Enabled = False
        'End If
    End Sub


    Private Sub cboCentros_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboCentros.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            dtpFecha.Focus()
        End If
    End Sub


    Private Sub dtpFecha_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Focus()
        End If
    End Sub


    Private Sub txtDIIO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO(txtDIIO.Text)
            e.Handled = True
        End If
    End Sub


    Private Sub txtDIIO_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDIIO.TextChanged
        If cboCentros.Text <> "" Then
            LimpiaDatos()
        End If

        If txtDIIO.Text.Trim = "" And lvDIIOS.Items.Count = 0 Then
            cboCentros.Enabled = True
        End If
    End Sub


    Private Sub txtObservs_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call btnGrabar_Click(sender, e)
        End If
    End Sub


    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        AgregaDiio()
    End Sub


    Private Sub AgregaDiio()
        If VerificaDIIOEnGrilla(-1, txtDIIO.Text.Trim) = True Then
            If MsgBox("EL DIIO YA EXISTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Ok Then
            End If
            Exit Sub
        End If

        Dim item As New ListViewItem((lvDIIOS.Items.Count + 1).ToString)

        item.SubItems.Add(txtDIIO.Text.Trim)
        item.SubItems.Add(lblCategoria.Text)
        item.SubItems.Add(lblFechaUltCelo.Text)                  'centro
        item.SubItems.Add(lblNroCelos.Text)
        item.SubItems.Add(lblDiasLac.Text)
        item.SubItems.Add(lblNroPartos.Text)
        item.SubItems.Add(lblEstProductivo.Text)                  'centro
        item.SubItems.Add(lblEstReproductivo.Text)

        item.SubItems.Add("")

        lvDIIOS.Items.Add(item)

        lvDIIOS.Items(lvDIIOS.Items.Count - 1).Selected = True
        lvDIIOS.EnsureVisible(lvDIIOS.Items.Count - 1)
    End Sub


    Private Sub LlenaGrilla()
        Cursor.Current = Cursors.WaitCursor

        Dim cent_ As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.SelectedIndex <> 0 Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If Param1_Modo = 3 Then
            ConsultaDetalleSinCelos(cent_)
        ElseIf Param1_Modo = 4 Then
            ConsultaDetalleCelosAnormales(cent_)
        End If

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        EliminarCelo()
    End Sub


    Private Sub btnBastonLee_Click(sender As System.Object, e As System.EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales() = False Then Exit Sub

        LeeBaston()

        If lvDIIOS.Items.Count > 0 Then cboCentros.Enabled = False
    End Sub



    Private Sub btnFinalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnFinalizar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        'If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        ' Exit Sub
        'End If

        If GrabarGrupoCelo() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            Cursor.Current = Cursors.WaitCursor
            frmCelos.LlenaGrilla()
            Me.Close()
            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarDIIO.Click
        txtDIIO.Text = txtDIIO.Text.Trim
        ConsultaDIIO(txtDIIO.Text)
    End Sub


    Private Sub mnuVerDetalle_Click(sender As System.Object, e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub


    Private Sub mnuCopiarDiio_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Sub DetalleGanado()
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvDIIOS.SelectedItems.Item(0).SubItems(1).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CopiarDiio()
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}
        tot(0, 0) = "" : tot(0, 1) = ""

        If Param1_Modo = 1 Or Param1_Modo = 2 Or Param1_Modo = 3 Then
            If lvDIIOS.Items.Count = 0 Then Exit Sub
            ExportToExcelGrilla(lvDIIOS, tot)
        Else
            If lvDIIOS2.Items.Count = 0 Then Exit Sub
            ExportToExcelGrilla(lvDIIOS2, tot)
        End If
    End Sub


    Private Sub btnBuscar_Click_1(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrilla()
    End Sub


    Private Sub lvDIIOS_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvDIIOS.MouseDoubleClick
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub


    Private Sub frmCelosIngreso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.C Then
                CopiarDiio()
            End If
        End If
    End Sub


    Private Sub frmCelosIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()

        If Param1_Modo = 1 Then
            btnFinalizar.Enabled = False
            btnEliminar.Enabled = False
            dtpFecha.Value = Now()

            lvDIIOS.Top = 221
            lvDIIOS.Height = 233

            If frmCelos.lvCELOS.SelectedItems.Count > 0 Then

                Dim item As ListViewItem = frmCelos.lvCELOS.SelectedItems(0)

                Dim CentroSeleccionado As String = item.SubItems(1).Text
                cboCentros.Text = CentroSeleccionado
            End If


        Else
            btnExcel.Left = btnEliminar.Left
            btnEliminar.Left = btnFinalizar.Left
            btnFinalizar.Visible = False
            btnBastonLee.Visible = False

            cboCentros.Text = Param3_CentroNom
            dtpFecha.Value = Param4_FechaDesde
            dtpFechaDesde.Value = Param4_FechaDesde
            dtpFechaHasta.Value = Param4_FechaHasta
            txtObservs.Text = Param5_Observs

            cboCentros.Enabled = False
            txtDIIO.Enabled = False
            btnBuscarDIIO.Enabled = True
            dtpFecha.Enabled = False
            txtObservs.Enabled = False
            btnFinalizar.Enabled = False
            btnEliminar.Enabled = True

            Label6.Visible = False
            lblTotErrores.Visible = False

            lvDIIOS.Columns(9).Width = 0        'ocultamos columna de resultados

            If Param1_Modo = 2 Then
                'para mostrar detalle de celos
                lvDIIOS.Top = 153
                lvDIIOS.Height = 301

                Me.Text = "Detalle Celos"

                ConsultaDetalleCelos(Param3_CentroCod, Param4_FechaDesde, Param4_FechaHasta)
            Else
                'para mostrar detalle sin celo y detalle celos anormales
                btnBuscar.Visible = True

                lvDIIOS.Top = 75
                lvDIIOS.Height = 379

                dtpFechaDesde.Value = Param4_FechaDesde
                dtpFechaHasta.Value = Param4_FechaHasta

                If Param1_Modo = 3 Then
                    grpDias.Visible = True
                    lvDIIOS.Columns(3).Width = 0            'ocultamos columna de fecha ultimo celo
                    lvDIIOS.Columns(4).Width = 0            'ocultamos columna de numero de celos
                    lvDIIOS.Columns(10).Width = 120

                    Me.Text = "Detalle Ganado Sin Celo"

                    ConsultaDetalleSinCelos(Param3_CentroCod)
                Else
                    lblDias.Visible = True
                    lvDIIOS.Visible = False
                    lvDIIOS2.Visible = True
                    lvDIIOS2.Top = 75
                    lvDIIOS2.Height = 379
                    Me.Text = "Detalle Ganado Con Celos Anormales"

                    ConsultaDetalleCelosAnormales(Param3_CentroCod)
                End If
            End If
        End If

        Cursor.Current = Cursors.Default
    End Sub


End Class