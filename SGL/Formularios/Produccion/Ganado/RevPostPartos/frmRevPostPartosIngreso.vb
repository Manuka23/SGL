
'Imports System.IO.Ports
Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient



Public Class frmRevPostPartosIngreso

    'Public CodigoSecado As Integer = 0

    Public Param0_ModoIngreso As Integer        '1=nuevo  /  2=edicion
    Public Param1_Empresa As Integer
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_FechaDesde As DateTime
    Public Param4_FechaHasta As DateTime
    Public Param5_Observs As String


    'Private DB_PA_ListadoRegistros As String = "spSecados_ListadoServidor"
    'Private DB_PA_EliminaRegistro As String = "spSecados_Eliminar"
    'Private DB_CMP_BuscaDiio As String() = {"EmpRut", "CenCod", "CenDesCor", "ScdFec", "ScdNumReg", "ScdDes"}
    'Private DB_CMP_Consulta As String() = {"EmpRut", "CenCod", "CenDesCor", "ScdFec", "ScdNumReg", "ScdDes"}


    'declaramos formulario baston
    'Private fbast As frmBaston



    'Private Sub LeeBaston()
    '    fbast = New frmBaston

    '    fbast.ShowDialog()

    '    If fbast.Procesa = True Then
    '        ProcesaBaston()
    '    End If

    '    fbast.Dispose()
    '    fbast = Nothing
    'End Sub


    'Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
    '    Dim i As Integer = 0
    '    Dim diio_ As String = ""
    '    Dim strdiios_ As String = ""
    '    Dim inichk_ As Integer = lvDIIOS.Items.Count '- 1
    '    Dim TotDiios As Integer

    '    Cursor.Current = Cursors.WaitCursor

    '    lvDIIOS.Items.Clear()

    '    For i = 0 To fbast.lvBASTON.Items.Count - 1
    '        diio_ = fbast.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
    '        strdiios_ = strdiios_ + diio_ + ","

    '        Dim item As New ListViewItem((i + 1).ToString)    'nro

    '        item.SubItems.Add(diio_)
    '        item.SubItems.Add("")
    '        item.SubItems.Add("")
    '        item.SubItems.Add("")
    '        item.SubItems.Add("")
    '        item.SubItems.Add("")
    '        item.SubItems.Add("")

    '        If VerificaDIIOEnGrilla(-1, diio_) = True Then
    '            item.SubItems.Add("ERR / REPETIDO")
    '        Else
    '            item.SubItems.Add("ERR / NO EXISTE EN BD")
    '        End If

    '        lvDIIOS.Items.Add(item)
    '    Next

    '    If strdiios_.Length > 0 Then
    '        strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
    '    End If

    '    TotDiios = BuscarDiiosBaston(inichk_, strdiios_)
    '    ContabilizaYValidaDIIOs()

    '    Cursor.Current = Cursors.Default
    'End Sub


    'devuelve el nro de errores en los diios
    'Private Function BuscarDiiosBaston(ByVal inichk_ As Integer, ByVal diios_ As String) As Integer
    '    BuscarDiiosBaston = 0

    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spSecados_ListadoBaston", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    'Dim diios_ As String = ""
    '    'diios_ = GeneraStringDIIOs()

    '    cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    lvDIIOS.BeginUpdate()
    '    'lvDIIOS.Items.Clear()
    '    'Label85.Text = "0"

    '    Dim i As Integer = 0
    '    Dim vret As Integer = 0
    '    Dim diio_ As String = ""
    '    Dim est_ As String = ""

    '    Try
    '        con.Open()
    '        rdr = cmd.ExecuteReader()

    '        Try
    '            While rdr.Read()
    '                diio_ = rdr("GndCod").ToString.Trim

    '                For i = 0 To lvDIIOS.Items.Count - 1
    '                    If lvDIIOS.Items(i).SubItems(1).Text.Trim = diio_ Then
    '                        lvDIIOS.Items(i).SubItems(2).Text = rdr("GndProNom").ToString.Trim
    '                        lvDIIOS.Items(i).SubItems(3).Text = rdr("GndEstadoProductivo").ToString.Trim
    '                        lvDIIOS.Items(i).SubItems(4).Text = Format(rdr("GndUltFechaPP"), "dd-MM-yyyy")
    '                        lvDIIOS.Items(i).SubItems(5).Text = Format(rdr("GndUltFechaSecado"), "dd-MM-yyyy")
    '                        lvDIIOS.Items(i).SubItems(6).Text = rdr("DiasSec").ToString.Trim
    '                        lvDIIOS.Items(i).SubItems(7).Text = rdr("DiasLac").ToString.Trim

    '                        If VerificaDIIOEnGrilla(i, diio_) = True Then
    '                            lvDIIOS.Items(i).SubItems(8).Text = "ERR / REPETIDO"
    '                        Else
    '                            est_ = ""

    '                            If rdr("CenDesCor").ToString.Trim <> cboCentros.Text Then
    '                                est_ = "ERR / CENTRO"
    '                            End If

    '                            If rdr("GndProNom").ToString.Trim <> "VACAS" Then
    '                                If est_.Trim = "" Then : est_ = "ERR / CATEG" : Else : est_ = est_ + " / CATEG" : End If
    '                            End If

    '                            If rdr("GndEstadoProductivo").ToString.Trim <> "EN PRODUCCION" And rdr("GndEstadoProductivo").ToString.Trim <> "SECA DE LECHE" Then
    '                                If est_.Trim = "" Then : est_ = "ERR / E.PROD" : Else : est_ = est_ + " / E.PROD" : End If
    '                            End If

    '                            lvDIIOS.Items(i).SubItems(8).Text = est_
    '                        End If

    '                    End If
    '                Next

    '                'i = i + 1
    '            End While

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try

    '    BuscarDiiosBaston = i

    '    'lblTotSecados.Text = i.ToString.Trim
    '    lvDIIOS.EndUpdate()
    'End Function


    'Public Sub ContabilizaYValidaDIIOs()
    '    Dim i As Integer = 0
    '    'Dim totsec_ As Integer = 0
    '    Dim err_ As Integer = 0
    '    Dim estado_secado_ As String = ""

    '    For i = 0 To lvDIIOS.Items.Count - 1
    '        lvDIIOS.Items(i).Text = (i + 1).ToString.Trim
    '        estado_secado_ = lvDIIOS.Items(i).SubItems(8).Text.Trim

    '        If Mid(estado_secado_, 1, 3) = "ERR" Then
    '            err_ += 1
    '        End If
    '    Next

    '    lblTotSecados.Text = i.ToString.Trim
    '    lblTotErrores.Text = err_.ToString.Trim

    '    'If err_ = 0 Then
    '    '    btnFinalizar.Enabled = True
    '    'Else
    '    '    btnFinalizar.Enabled = False
    '    'End If
    'End Sub

    'Public Sub SumaSecado()
    '    lblTotSecados.Text = Str(Val(lblTotSecados.Text) + 1).Trim
    'End Sub


    'Public Sub RestaSecado()
    '    lblTotSecados.Text = Str(Val(lblTotSecados.Text) - 1).Trim
    'End Sub


    'Public Sub SumaEliminado()
    '    lblTotEliminados.Text = Str(Val(lblTotEliminados.Text) + 1).Trim
    'End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    'Private Function GeneraStringDIIOs() As String
    '    GeneraStringDIIOs = ""

    '    Dim i As Integer = 0
    '    Dim str_ As String = ""
    '    Dim estado_secado_ As String = ""

    '    For i = 0 To lvDIIOS.Items.Count - 1
    '        estado_secado_ = lvDIIOS.Items(i).SubItems(8).Text.Trim

    '        If estado_secado_ = "" Or Mid(estado_secado_, 1, 3) = "MSJ" Then
    '            str_ = str_ + lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim + ","
    '        End If
    '    Next

    '    If str_.Length > 0 Then
    '        str_ = Mid(str_, 1, str_.Length - 1)
    '    End If

    '    GeneraStringDIIOs = str_
    'End Function



    'Private Function ExistenDIIOsSinGrabar() As Boolean
    '    ExistenDIIOsSinGrabar = False

    '    Dim i As Integer = 0
    '    Dim existe_ As Boolean = False
    '    Dim estado_secado_ As String = ""

    '    For i = 0 To lvDIIOS.Items.Count - 1
    '        estado_secado_ = lvDIIOS.Items(i).SubItems(8).Text.Trim

    '        If estado_secado_ = "" Or Mid(estado_secado_, 1, 3) = "MSJ" Then
    '            existe_ = True
    '            Exit For
    '        End If
    '    Next

    '    ExistenDIIOsSinGrabar = existe_
    'End Function


    'Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
    '    VerificaDIIOEnGrilla = False

    '    Dim i As Integer = 0
    '    Dim existe_ As Boolean = False

    '    For i = 0 To lvDIIOS.Items.Count - 1
    '        If i <> pos_ Then
    '            If lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
    '                existe_ = True
    '                Exit For
    '            End If

    '        End If
    '    Next

    '    VerificaDIIOEnGrilla = existe_
    'End Function


    'Private Sub Exportar_A_Excel()
    '    If lvDIIOS.Items.Count = 0 Then Exit Sub

    '    Cursor.Current = Cursors.WaitCursor

    '    'lblProcesa.Text = "Exportando a excel, espere un momento por favor ..."
    '    'pbProcesa.Value = 0
    '    'pbProcesa.Maximum = Val(Label85.Text)
    '    'pnlProcesa.Visible = True
    '    'pnlProcesa.Refresh()

    '    Try
    '        Dim lin, col As Integer

    '        Dim AppExcel As New Application
    '        Dim Libro As Workbook
    '        Dim Hoja As Worksheet

    '        Libro = AppExcel.Workbooks.Add
    '        Hoja = Libro.Worksheets(1)

    '        'Libro.Title = "Consulta de Ganado..."
    '        'Libro.Author = "ndsky"
    '        'Hoja.Name = "Libro Exportado"
    '        Dim i As Integer = 0

    '        For col = 0 To lvDIIOS.Columns.Count - 1

    '            'If col <> 2 Then
    '            Hoja.Cells(1, i + 1) = lvDIIOS.Columns(i).Text
    '            Hoja.Cells(1, i + 1).font.bold = True
    '            Hoja.Cells(1, i + 1).font.size = 12
    '            i = i + 1
    '            'End If

    '        Next

    '        For lin = 0 To lvDIIOS.Items.Count - 1

    '            i = 0
    '            For col = 0 To lvDIIOS.Columns.Count - 1

    '                'If col <> 2 Then
    '                Hoja.Cells(lin + 2, i + 1) = lvDIIOS.Items(lin).SubItems(i).Text.ToString.Trim
    '                i = i + 1
    '                'End If


    '            Next

    '            'pbProcesa.Value = lin + 1

    '        Next

    '        lin = lin + 3
    '        Hoja.Cells(lin, 1) = "TOTAL DE REVISIONES PP: " + lblTotSecados.Text.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12

    '        Hoja.Cells(lin, 5) = "E1: " + lblTotE1.Text.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12
    '        Hoja.Cells(lin + 1, 5) = "E2: " + lblTotE2.Text.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12
    '        Hoja.Cells(lin + 2, 5) = "E3: " + lblTotE3.Text.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12
    '        Hoja.Cells(lin + 3, 5) = "LOQUIO: " + lblTotLOQ.Text.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12
    '        Hoja.Cells(lin + 4, 5) = "METRITIS: " + lblTotMET.Text.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12
    '        Hoja.Cells(lin + 5, 5) = "SANA: " + lblTotSANA.Text.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12


    '        'pbProcesa.Value = pbProcesa.Maximum

    '        AppExcel.Visible = True
    '        AppActivate(AppExcel.Caption)

    '        Hoja = Nothing      'Descargamos los Objetos...
    '        Libro = Nothing
    '        AppExcel = Nothing

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    'pnlProcesa.Visible = False
    '    Cursor.Current = Cursors.Default
    'End Sub


    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        'If ExistenDIIOsSinGrabar() = False Then
        '    If MsgBox("NO EXISTEN SECADOS PENDIENTES", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboCentros.Focus()
        '    Exit Function
        'End If

        If ValidaDiios = True Then
            If lvDIIOS.Items.Count = 0 Then
                If MsgBox("DEBE INGRESAR EL DETALLE DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                'cboCondiciones.Focus()
                Exit Function
            End If
        End If

        ValidacionesLocales = True
    End Function


    Private Sub BuscarDetalle()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRevisionesPP_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Param1_Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param2_CodigoCentro)
        cmd.Parameters.AddWithValue("@FechaDesde", Format(Param4_FechaDesde, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@FechaHasta", Format(Param4_FechaHasta, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvDIIOS.BeginUpdate()
        lvDIIOS.Items.Clear()

        lblTotSecados.Text = "0"
        lblTotE1.Text = "0"
        lblTotE2.Text = "0"
        lblTotE3.Text = "0"
        lblTotLOQ.Text = "0"
        lblTotMET.Text = "0"
        lblTotSANA.Text = "0"

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0
        Dim est_ As Integer = 0
        Dim fec_ As String = ""
        Dim e1, e2, e3, loq, met, sana As Integer
        Dim cond_ As String

        e1 = e2 = e3 = loq = met = sana = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    fec_ = rdr("RPPDetFecha").ToString.Trim
                    cond_ = rdr("RevPPCondicion").ToString.Trim

                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(fec_)
                    item.SubItems.Add(cond_)
                    item.SubItems.Add(rdr("RPPDetEstProd").ToString.Trim)
                    item.SubItems.Add(rdr("RPPDetDesecho").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(rdr("RPPDetEstProdOld").ToString.Trim)
                    item.SubItems.Add(rdr("RPPDetEstReprodOld").ToString.Trim)
                    item.SubItems.Add(rdr("RPPDetEstSaludOld").ToString.Trim)

                    lvDIIOS.Items.Add(item)

                    Select Case cond_.Trim.ToUpper
                        Case "E1"
                            lblTotE1.Text = Int32.Parse(lblTotE1.Text) + 1
                        Case "E2"
                            lblTotE2.Text = Int32.Parse(lblTotE2.Text) + 1
                        Case "E3"
                            lblTotE3.Text = Int32.Parse(lblTotE3.Text) + 1
                        Case "LOQUIO"
                            lblTotLOQ.Text = Int32.Parse(lblTotLOQ.Text) + 1
                        Case "METRITIS"
                            lblTotMET.Text = Int32.Parse(lblTotMET.Text) + 1
                        Case "SANA"
                            lblTotSANA.Text = Int32.Parse(lblTotSANA.Text) + 1
                    End Select

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

        lvDIIOS.EndUpdate()

        lblTotSecados.Text = i.ToString.Trim
        'lblTotE1.Text = e.ToString.Trim
    End Sub



    'Private Function EliminarDIIOSecado(ByVal cent_ As String, ByVal fec_ As DateTime, ByVal diio_ As Integer) As Boolean
    '    EliminarDIIOSecado = False

    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spSecados_EliminarDetalle", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@Centro", cent_)
    '    cmd.Parameters.AddWithValue("@Fecha", fec_)
    '    cmd.Parameters.AddWithValue("@DIIO", diio_)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)
    '    '
    '    cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
    '    cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

    '    Try
    '        con.Open()

    '        Dim Result As Integer = cmd.ExecuteNonQuery()

    '        Dim vret As Integer = cmd.Parameters("@RetValor").Value
    '        Dim mret As String = cmd.Parameters("@RetMensage").Value

    '        If vret > 0 Then
    '            If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
    '            End If
    '            Exit Function
    '        End If

    '        EliminarDIIOSecado = True

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
    '    End Try
    'End Function


   Private Function EliminarRevPP() As Boolean
        EliminarRevPP = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRevisionesPP_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param2_CodigoCentro)
        cmd.Parameters.AddWithValue("@FechaRevPP", Convert.ToDateTime(lvDIIOS.SelectedItems(0).SubItems(2).Text))
        cmd.Parameters.AddWithValue("@Diio", lvDIIOS.SelectedItems(0).SubItems(1).Text)
        '
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

            EliminarRevPP = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function



    'Private Sub txtDiasGest_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
    '    If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
    '        e.Handled = True
    '    End If
    'End Sub


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


    Private Sub Cerrar()
        'If ExistenDIIOsSinGrabar() = True Then
        '    If MsgBox("EXISTEN DIIOS SIN GRABAR, ¿DESEA SALIR?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        '        Exit Sub
        '    End If
        'End If

        Cursor.Current = Cursors.WaitCursor

        'frmSecados.LlenaGrillaSecados()
        Me.Close()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub ProcesarGrabadoOK()
        Dim i As Integer = 0

        For i = 0 To lvDIIOS.Items.Count - 1
            lvDIIOS.Items(i).SubItems(8).Text = "Grabado"
        Next

        frmSecados.LlenaGrillaSecados()
    End Sub


    Private Sub lvDIIOS_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvDIIOS.MouseDoubleClick
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        frmRevPostPartosIngresoDIIO.Param0_ModoIngreso = 0
        frmRevPostPartosIngresoDIIO.Param1_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmRevPostPartosIngresoDIIO.Param2_NombreCentro = cboCentros.Text

        frmRevPostPartosIngresoDIIO.MdiParent = frmMAIN
        frmRevPostPartosIngresoDIIO.Show()
        frmRevPostPartosIngresoDIIO.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    'Private Sub btnBastonLee_Click(sender As System.Object, e As System.EventArgs) Handles btnBastonLee.Click
    '    If ValidacionesLocales(False) = False Then Exit Sub

    '    LeeBaston()
    'End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim Arete As String = ""

        Arete = lvDIIOS.SelectedItems(0).SubItems(2).Text

        If Arete = "" Then
            MsgBox("Debe seleccionar una Diio a Eliminar. ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Seleccionar Revision Post Parto")
            Exit Sub
        End If
        If MsgBox("¿Confirma eliminación de la Rev.PP seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarRevPP() = True Then
            MsgBox("Eliminacion finalizada correctamente. ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Confirmacion")
            BuscarDetalle()
        End If

    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        Dim tot(6, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL DE REVISIONES PP:  " : tot(0, 1) = lblTotSecados.Text.Trim
        tot(1, 0) = "E1: " : tot(1, 1) = lblTotE1.Text.Trim
        tot(2, 0) = "E2: " : tot(2, 1) = lblTotE2.Text.Trim
        tot(3, 0) = "E3: " : tot(2, 1) = lblTotE3.Text.Trim
        tot(4, 0) = "LOQUIO: " : tot(2, 1) = lblTotLOQ.Text.Trim
        tot(5, 0) = "METRITIS: " : tot(2, 1) = lblTotMET.Text.Trim
        tot(6, 0) = "SANA: " : tot(2, 1) = lblTotSANA.Text.Trim

        ExportToExcelGrilla(lvDIIOS, tot)
    End Sub


    Private Sub frmRevPospartosIngreso_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If

            'If e.KeyCode = Keys.V Then
            '    MsgBox("chao")
            'End If

        End If
    End Sub



    Private Sub frmRevPospartosIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()

        'If Param0_ModoIngreso = 1 Then
        '    'secado nuevo

        '    Me.Text = "Nuevo Ingreso de Secado"
        '    Label2.Text = "Total a secar"

        '    cboCentros.Text = CentroPorDefecto()
        '    lblConErrores.Visible = True
        '    lblTotErrores.Visible = True

        '    lvDIIOS.MultiSelect = True
        'Else
        '    'edicion de secado

        '    Me.Text = "Edición de Secado"
        '    Label2.Text = "Total de Secados"

        '    lblEliminados.Visible = True
        '    lblTotEliminados.Visible = True

        '    lvDIIOS.MultiSelect = False

        '    cboCentros.Text = Param3_NombreCentro
        '    dtpFecha.Value = Param4_Fecha
        '    txtObservs.Text = Param5_Observs

        '    cboCentros.Enabled = False
        '    dtpFecha.Enabled = False
        '    txtObservs.Enabled = False

        '    btnFinalizar.Visible = False
        '    btnAgregar.Visible = False
        '    btnBastonLee.Visible = False
        '    'btnExcel.Visible = False
        '    btnEliminar.Left = btnAgregar.Left
        '    btnExcel.Left = btnBastonLee.Left

        cboCentros.Text = Param3_NombreCentro
        dtpFechaDesde.Value = Param4_FechaDesde
        dtpFechaHasta.Value = Param4_FechaHasta

        BuscarDetalle()
        'End If

        'btnFinalizar.Enabled = False



        'MsgBox(Param4_Fecha.ToString)
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


    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class