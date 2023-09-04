

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmTraslados
    Private TipoReporte As Integer = 0


    Private Total_Salidas As Integer = 0
    Private Total_Entradas As Integer = 0
    Private Total_SalGanado As Integer = 0
    Private Total_EntGanado As Integer = 0

    'nombre de los campos en la base de datos, para el orden de los registros en la grilla
    Private CamposOrden As String() = {"", "", "TMovNombre", "TrasFecha", "", "CentroOrigen", "", "CentroDestino", _
                                       "", "TrasNumRegs", "TestNombre", "TrasTipoGuia", "TrasGuia", "", "", "TrasPabco", _
                                       "", "TrasNroInterno"}
    Private CadenaOrden As String = "TrasGuia, TrasFecha"
    Private OrdenPorDefecto As String = "TrasGuia, TrasFecha"



    Private Sub InicializaTotales()
        Total_Salidas = 0
        Total_Entradas = 0
        Total_SalGanado = 0
        Total_EntGanado = 0
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
        Label85.Text = Total_Salidas.ToString.Trim
        Label5.Text = Total_Entradas.ToString.Trim
        Label7.Text = Total_SalGanado.ToString.Trim
        Label9.Text = Total_EntGanado.ToString.Trim

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

        cboCentros.SelectedIndex = 0
    End Sub


    Private Sub CboLLenaTiposMovimientos()
        If General.TipoMovimientos.NroRegistros = 0 Then Exit Sub

        cboTiposMovimientos.Items.Clear()
        cboTiposMovimientos.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.TipoMovimientos.NroRegistros - 1
            cboTiposMovimientos.Items.Add(General.TipoMovimientos.Nombre(i))
        Next

        cboTiposMovimientos.SelectedIndex = 0
    End Sub


    Private Sub CboLLenaEstados()
        If General.EstTraslados.NroRegistros = 0 Then Exit Sub

        cboEstados.Items.Clear()
        cboEstados.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.EstTraslados.NroRegistros - 1
            cboEstados.Items.Add(General.EstTraslados.Nombre(i))
        Next

        cboEstados.SelectedIndex = 0
    End Sub


    Public Sub ConsultaTraslados(ByVal cent_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim mov_ As Integer = cboTiposMovimientos.SelectedIndex
        Dim est_ As Integer = cboEstados.SelectedIndex

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        'cmd.Parameters.AddWithValue("@Modulo", "")
        cmd.Parameters.AddWithValue("@Tipo", 0)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@Movimiento", mov_)
        cmd.Parameters.AddWithValue("@Estado", est_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvTRASLADOS.BeginUpdate()
        lvTRASLADOS.Items.Clear()

        InicializaTotales()
        MuestraTotales()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim org_ As String = ""
        Dim sum_entrans As Integer = 0
        Dim color_ As Color


        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    org_ = rdr("CentroOrigen").ToString.Trim
                    'If rdr("TMovNombre").ToString.Trim.ToUpper = "ENTRADA" Then org_ = ""

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos 0

                    item.SubItems.Add(rdr("TrasEmpresa").ToString.Trim) '1
                    item.SubItems.Add(rdr("TMovNombre").ToString.Trim) '2
                    item.SubItems.Add(Format(rdr("TrasFecha"), "dd-MM-yyyy HH:mm")) '3
                    item.SubItems.Add(rdr("TrasCentro").ToString.Trim) '4
                    item.SubItems.Add(org_) '5
                    item.SubItems.Add(rdr("TrasEmpresaDestino").ToString.Trim) 'nuevo 6
                    item.SubItems.Add(rdr("TrasDestino").ToString.Trim) '7
                    item.SubItems.Add(rdr("CentroDestino").ToString.Trim) '8
                    item.SubItems.Add(rdr("TrasObservs").ToString.Trim) '9
                    item.SubItems.Add(rdr("TrasNumRegs").ToString.Trim) '10
                    item.SubItems.Add(rdr("TEstNombre").ToString.Trim) '11
                    item.SubItems.Add(rdr("TGuiaNombre").ToString.Trim) '12
                    item.SubItems.Add(rdr("TrasGuia").ToString.Trim) '13
                    item.SubItems.Add(rdr("TrasCodigo").ToString.Trim) '14
                    item.SubItems.Add(rdr("TTipNombre").ToString.Trim)
                    item.SubItems.Add(rdr("TrasPabco").ToString.Trim)
                    item.SubItems.Add(rdr("TTipNombre").ToString.Trim)
                    item.SubItems.Add(rdr("TrasNroInterno").ToString.Trim)
                    ''
                    item.SubItems.Add(rdr("TrasTransChoferRut").ToString.Trim)
                    item.SubItems.Add(rdr("TrasTransChoferNom").ToString.Trim)
                    item.SubItems.Add(rdr("TrasTransEmpresa").ToString.Trim)
                    item.SubItems.Add(rdr("TrasTransPatente1").ToString.Trim)
                    item.SubItems.Add(rdr("TrasTransPatente2").ToString.Trim)
                    item.SubItems.Add(rdr("TrasUsuario").ToString.Trim)
                    item.SubItems.Add(rdr("TrasAnulUsuCod").ToString.Trim)
                    item.SubItems.Add(rdr("TrasTipoGuia").ToString.Trim)

                    ''
                    lvTRASLADOS.Items.Add(item)

                    'If rdr("TrasTipo") = 1 Then
                    If rdr("TMovNombre").ToString.Trim.ToUpper.Contains("SALIDA") = True Then
                        Total_Salidas = Total_Salidas + 1
                        Total_SalGanado = Total_SalGanado + Val(rdr("TrasNumRegs").ToString.Trim)
                    Else
                        Total_Entradas = Total_Entradas + 1
                        Total_EntGanado = Total_EntGanado + Val(rdr("TrasNumRegs").ToString.Trim)
                    End If

                    If rdr("TEstNombre").ToString.Trim.ToUpper.Contains("TRANSITO") = True Then sum_entrans += 1


                    'COLEREAMOS SEGUN ESTADO
                    color_ = SystemColors.Window
                    If rdr("TEstNombre").ToString.Trim = "ANULADO" Then color_ = Color.LightGray
                    If rdr("TEstNombre").ToString.Trim = "EN TRANSITO" Then color_ = Color.Yellow

                    item.UseItemStyleForSubItems = True

                    For x As Integer = 0 To item.SubItems.Count - 1
                        item.SubItems(x).BackColor = color_
                    Next


                    'Total_Ganado = Total_Ganado + Val(rdr("TrasNumRegs").ToString.Trim)
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
        lvTRASLADOS.EndUpdate()
        'Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False
        If sum_entrans > 0 Then btnRecepcionMasiva.Enabled = True
    End Sub


    Private Function EliminarTraslado(ByVal codsec_ As Integer) As Boolean
        EliminarTraslado = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodTraslado", codsec_)
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

            EliminarTraslado = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function EliminaTraslado() As Boolean
        EliminaTraslado = False

        'Dim EmpRut As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(1).Text 'Codigo Empresa
        'Dim CodCentroSal As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(4).Text 'Codigo Centro Salida
        'Dim CodCentroEnt As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(6).Text 'Codigo Centro Entrada
        'Dim NroGuia As Integer = Convert.ToInt32(lvTRASLADOS.SelectedItems.Item(0).SubItems(13).Text) 'Nro Guia
        'Dim NroPabco As Integer = Convert.ToInt32(lvTRASLADOS.SelectedItems.Item(0).SubItems(15).Text) 'Nro PABCO
        'Dim Fec As DateTime = Convert.ToDateTime(lvTRASLADOS.SelectedItems.Item(0).SubItems(3).Text) 'Fecha Traslado
        'Dim TipoMov As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(2).Text 'Tipo Movimiento (Entrada / Salida)
        Dim TrasCodigo As Integer = Convert.ToInt32(lvTRASLADOS.SelectedItems.Item(0).SubItems(14).Text) 'TrasCodigo

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@TrasCodigo", TrasCodigo)
        'cmd.Parameters.AddWithValue("@CentroSalida", CodCentroSal)
        'cmd.Parameters.AddWithValue("@CentroEntrada", CodCentroEnt)
        'cmd.Parameters.AddWithValue("@Guia", NroGuia)
        'cmd.Parameters.AddWithValue("@Pabco", NroPabco)
        'cmd.Parameters.AddWithValue("@Fecha", Fec)
        'cmd.Parameters.AddWithValue("@TipoMov", TipoMov)
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

            EliminaTraslado = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub DetalleTraslado()
        If lvTRASLADOS.Items.Count = 0 Then Exit Sub
        If lvTRASLADOS.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim emp_ As Integer = lvTRASLADOS.SelectedItems.Item(0).SubItems(1).Text            'empresa
        Dim mov_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(2).Text             'movimiento
        Dim fec_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(3).Text             'fecha cecado
        Dim cent_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(4).Text            'centro
        Dim nomcent_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(5).Text         'nombre centro
        Dim dest_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(7).Text            'codigo destino
        Dim nomdest_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(8).Text         'nombre destino
        Dim obssec_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(9).Text          'observacion Traslado
        Dim tguianom_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(12).Text       'tipo guia
        Dim guia_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(13).Text           'guia
        Dim TrasCod As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(14).Text         'correlativo traslado
        Dim tip_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(17).Text            'tipo traslado (talaje, definitivo)
        Dim pabco_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(16).Text          'pabco

        ''
        Dim rutchofe_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(19).Text       'rut chofe
        Dim nomchofe_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(20).Text       'nom chofe
        Dim nomtrans_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(21).Text       'nom trans
        Dim pat1_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(22).Text           'pat1
        Dim pat2_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(23).Text           'pat2



        If cent_ = 0 Then Exit Sub

        With frmTrasladosIngreso
            '.CodigoTraslado = codsec_
            .Param0_ModoIngreso = 2        '1=nuevo  /  2=edicion
            .Param1_Empresa = emp_
            .Param2_CodigoCentro = cent_
            .Param3_NombreCentro = nomcent_
            .Param4_Fecha = fec_
            .Param5_Observs = obssec_
            .Param6_Guia = guia_
            .Param7_CodigoDestino = dest_
            .Param8_NombreDestino = nomdest_
            .Param9_TipoMov = mov_
            .Param10_CodigoTraslado = TrasCod
            .Param11_TipoTraslado = tip_
            .Param12_Pabco = pabco_
            .Param13_TipoGuia = tguianom_
            ''
            .Param20_EsRecepcion = False
            ''
            .Param30_RutChofer = rutchofe_
            .Param31_NomChofer = nomchofe_
            .Param32_NomTransporte = nomtrans_
            .Param33_Patente1 = pat1_
            .Param34_Patente2 = pat2_

            .lblTitulo.Text = "CONSULTA DE TRASLADO"
            .lblTrasCod.Text = "Código auditoria interno: " & TrasCod.Trim
            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With


        Cursor.Current = Cursors.Default
    End Sub


    Private Function BuscaNombreCentro(ByVal _text As String) As String
        BuscaNombreCentro = ""

        Dim i As Integer
        Dim nom As String = ""

        For i = 0 To General.TrlsGnd_ListadoCentros.Codigo.Length - 1
            If General.TrlsGnd_ListadoCentros.Codigo(i).Trim = _text Then
                nom = General.TrlsGnd_ListadoCentros.Nombre(i)
                Exit For
            End If
        Next


        BuscaNombreCentro = nom
    End Function


    Private Sub RecepcionarSalida()
        If lvTRASLADOS.Items.Count = 0 Then Exit Sub
        If lvTRASLADOS.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor
        Dim EmpCod_ As Integer = Val(lvTRASLADOS.SelectedItems.Item(0).SubItems(1).Text)
        Dim fec_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(3).Text             'fecha 
        Dim CenCodOri_ As Integer = Val(lvTRASLADOS.SelectedItems.Item(0).SubItems(4).Text) 'codigo centro origen
        Dim CenNomOri_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(5).Text       'nombre centro origen
        Dim TipDoc_ As Integer = Val(lvTRASLADOS.SelectedItems.Item(0).SubItems(26).Text)   'tipo de guia
        Dim NroDoc_ As Integer = Val(lvTRASLADOS.SelectedItems.Item(0).SubItems(13).Text)   'guia


        Dim rutchofe_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(19).Text       'rut chofe
        Dim nomchofe_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(20).Text       'nom chofe
        Dim nomtrans_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(21).Text       'nom trans
        Dim pat1_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(22).Text           'pat1
        Dim pat2_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(23).Text           'pat2

        Dim TrasCod As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(14).Text

        With frmTrasladosIngreso
            .EnEventoLoad = True
            '.CodigoSecado = 0
            .Param0_ModoIngreso = 1        '1=nuevo  /  2=edicion
            .Param20_EsRecepcion = True

            .lblTitulo.Text = "RECEPCIONAR TRASLADO"
            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            .cboMovimientos.Text = "ENTRADA"
            .cboTiposGuia.Text = TipDoc_.ToString
            .txtNroDoc.Text = NroDoc_.ToString
            .dtpFecha.Value = fec_ 'Format(Now, "dd-MM-yyyy HH:mm") 'fec_
            .cboCentros.Text = CenNomOri_ 'BuscaNombreCentro(cent_)

            .lblTrasCod.Text = "Código auditoria interno: " & TrasCod.Trim

            .Param18_FechaSalida = fec_

            .txtRutChofer.Text = rutchofe_
            .txtNomChofer.Text = nomchofe_
            .txtEmpTransporte.Text = nomtrans_
            .txtPatente1.Text = pat1_
            .txtPatente2.Text = pat2_
            .txtRutChofer.Enabled = False
            .txtNomChofer.Enabled = False
            .txtEmpTransporte.Enabled = False
            .txtPatente1.Enabled = False
            .txtPatente2.Enabled = False
            .cboTiposGuia.Enabled = False
            .txtNroDoc.Enabled = False
            .btnEliminar.Enabled = False
            .BuscaSalidaParaRecepcion(Empresa, CenCodOri_, TipDoc_, NroDoc_)
            .EnEventoLoad = False
        End With
        Cursor.Current = Cursors.Default
    End Sub


    Public Sub LlenaGrillaTraslados()
        'Dim OtrosCent As Integer = 0
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = OrdenPorDefecto
            lblOrden.Text = "Centro -> Fecha"
            lblOrden.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaTraslados(cent_)

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleTraslado()
    End Sub


    Private Sub mnuRecepcion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRecepcion.Click
        RecepcionarSalida()
    End Sub


    Private Sub btnPrevisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevisualizar.Click
        If lvTRASLADOS.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim EmpresaGuia As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(1).Text
        Dim guia_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(13).Text           'guia
        Dim tipoguia_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(12).Text
        Dim cent_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(4).Text


        If tipoguia_.Contains("ELECT") Then

            Dim PdfNomSuite As String = SuiteElectronica.GeneraNombreArchivo(52, guia_, EmpresaGuia)
            SuiteElectronica.MostrarPDFeSuite(PdfNomSuite)


        End If

        If tipoguia_.Contains("GUIA TT") Then
            Dim rt As New frmRptTraslado()

            rt.Centro = cent_
            rt.TipoGuia = 500
            rt.NroGuia = guia_

            rt.Show()
            rt.BringToFront()
        End If
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If lvTRASLADOS.SelectedItems.Count = 0 Then Exit Sub


        Dim msg As String = ""

        If lvTRASLADOS.SelectedItems(0).SubItems(11).Text.Contains("GUIA TT") Then
            msg = "¿ DESEA ANULAR EL TRASLADO SELECCIONADO ? " + vbCrLf + vbCrLf + "EL TRASLADO NO SERÁ ELIMINADO, SOLO ANULADO."
        Else
            msg = "¿ DESEA ANULAR EL TRASLADO SELECCIONADO ? " + vbCrLf + vbCrLf + "EL TRASLADO NO SERÁ ELIMINADO, SOLO ANULADO." + vbCrLf + vbCrLf + "SI ANULA EL TRASLADO EL CORRELATIVO DE LA GUIA (" + lvTRASLADOS.SelectedItems(0).SubItems(12).Text + ") NO PODRÁ SER UTILIZADO NUEVAMENTE."
        End If


        If MsgBox(msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminaTraslado() = True Then
            MsgBox("Eliminacion finalizada correctamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmacion")
            btnBuscar_Click(sender, e)
        End If

    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrillaTraslados()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()

        'SaveSN.SelectedNode.ForeColor = Color.AntiqueWhite

        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvTRASLADOS.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL TRASLADOS " : tot(0, 1) = +(Val(Label85.Text) + Val(Label5.Text)).ToString.Trim

        ExportToExcelGrilla(lvTRASLADOS, tot)
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        With frmTrasladosIngreso
            '.CodigoSecado = 0
            .Param0_ModoIngreso = 1        '1=nuevo  /  2=edicion
            .Param20_EsRecepcion = False

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With

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

        'btnRecepcionMasiva.Enabled = False
    End Sub



    Private Sub lvTRASLADOS_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvTRASLADOS.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrden.Text = lvTRASLADOS.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrden.Text = lblOrden.Text + " -> " + lvTRASLADOS.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvTRASLADOS_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvTRASLADOS.MouseClick
        If lvTRASLADOS.SelectedItems.Count = 0 Then Exit Sub

        Dim tguia_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(12).Text           'tipo de guia

        If tguia_.Contains("ELECT") Or tguia_.Contains("GUIA TT") Then
            btnPrevisualizar.Enabled = True
        Else
            btnPrevisualizar.Enabled = False
        End If

        If e.Button = MouseButtons.Right = True Then
            Dim mov_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(2).Text
            Dim dest_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(7).Text
            Dim destnom_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(8).Text
            Dim est_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(11).Text


            Dim existe_dest_ As Boolean = False

            mnuImprimirGuiaTT.Visible = False

            If tguia_.Contains("GUIA TT") Then
                mnuImprimirGuiaTT.Visible = True
            End If

            'si es salida y esta en trasito
            If mov_.Contains("SAL") And est_.Contains("TRANS") Then
                'verificamos que el centro de destino exista en los centros del usuario
                For i As Integer = 0 To General.CentrosUsuario.Codigo.Count - 1
                    If General.CentrosUsuario.Codigo(i).Contains(dest_) Then
                        existe_dest_ = True
                        Exit For
                    End If
                Next
            End If

            mnuRecepcion.Enabled = existe_dest_
        End If
    End Sub


    Private Sub lvTRASLADOS_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvTRASLADOS.MouseDoubleClick
        If lvTRASLADOS.SelectedItems.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleTraslado()
        End If
    End Sub


    Private Sub frmTraslados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.TipoGuiasTraslados.Cargar()
        General.EstTraslados.Cargar()
        General.TipoTraslados.Cargar()
        General.TipoMovimientos.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
        CboLLenaTiposMovimientos()
        CboLLenaEstados()

        cboCentros.Text = CentroPorDefecto()
        dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now

        LlenaGrillaTraslados()

        btnPrevisualizar.Enabled = False
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        'btnRecepcionMasiva.Enabled = False
        LlenaGrillaTraslados()
    End Sub


    Private Sub btnRecepcionMasiva_Click(sender As System.Object, e As System.EventArgs) Handles btnRecepcionMasiva.Click
        frmTrasladosRecepcionMasiva.MdiParent = frmMAIN
        frmTrasladosRecepcionMasiva.Show()
        frmTrasladosRecepcionMasiva.BringToFront()
    End Sub


    Private Sub cboTiposMovimientos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTiposMovimientos.SelectedIndexChanged, cboEstados.SelectedIndexChanged, dtpFechaHasta.ValueChanged
        'btnRecepcionMasiva.Enabled = False
    End Sub


    'Private Sub dtpFechaHasta_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaHasta.ValueChanged
    '    btnRecepcionMasiva.Enabled = False
    'End Sub


    'Private Sub cboEstados_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstados.SelectedIndexChanged
    '    btnRecepcionMasiva.Enabled = False
    'End Sub

    Private Sub mnuImprimirGuiaTT_Click(sender As System.Object, e As System.EventArgs) Handles mnuImprimirGuiaTT.Click
        Dim cent_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(4).Text
        Dim tipguia_ As Integer = 500 'General.TipoGuiasTraslados.Codigo(cboTiposGuia.SelectedIndex)
        Dim nroguia_ As String = lvTRASLADOS.SelectedItems.Item(0).SubItems(13).Text

        Cursor.Current = Cursors.WaitCursor

        Dim rt As New frmRptTraslado()

        'rt.Param1_GuiaPara = 1
        rt.Centro = cent_
        rt.TipoGuia = tipguia_
        rt.NroGuia = nroguia_

        rt.Show()
        rt.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub lvTRASLADOS_ItemSelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvTRASLADOS.ItemSelectionChanged
        If lvTRASLADOS.SelectedItems.Count = 0 Then Exit Sub

        If lvTRASLADOS.SelectedItems(0).SubItems(2).Text.Contains("SALIDA") Then
            btnPrevisualizar.Enabled = True
        Else
            btnPrevisualizar.Enabled = False
        End If
    End Sub


End Class