
Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient



Public Class frmSecadosIngreso


    Public Param0_ModoIngreso As Integer        '1=nuevo  /  2=edicion
    Public Param1_Empresa As Integer
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_Fecha As DateTime
    Public Param5_Observs As String

    Private CentroCod As Integer = 0

    Private Sub frmSecadosIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        MSTRUsuarios.DSCboUsuarioCentros_FrmINS(True, cboCentros)

        If Param0_ModoIngreso = 1 Then
            'secado nuevo

            Me.Text = "Nuevo Ingreso de Secado"
            Label2.Text = "Total a secar"

            cboCentros.Text = UsuarioCentroNomDefault
            CentroCod = UsuarioCentroCodDefault
            lblConErrores.Visible = True
            lblTotErrores.Visible = True

            lvDIIOS.MultiSelect = True
        Else
            'edicion de secado

            Me.Text = "Edición de Secado"
            Label2.Text = "Total de Secados"

            lblEliminados.Visible = True
            lblTotEliminados.Visible = True

            lvDIIOS.MultiSelect = False

            cboCentros.Text = Param3_NombreCentro
            dtpFecha.Value = Param4_Fecha
            txtObservs.Text = Param5_Observs

            cboCentros.Enabled = False
            dtpFecha.Enabled = False
            txtObservs.Enabled = False

            btnFinalizar.Visible = False
            btnAgregar.Visible = False
            btnBastonLee.Visible = False
            btnEliminar.Left = btnAgregar.Left
            btnExcel.Left = btnBastonLee.Left

            BuscarDetalle()
        End If

        btnFinalizar.Enabled = False

    End Sub
    'declaramos formulario baston

    Private Sub LeeBaston()

        frmBastonV2.Param1_CentroCod = CodigoCentroUsuario 'Centro Codigo Default
        frmBastonV2.Param2_CentroNom = NombreCentroUsuario 'Centro Nombre Default
        frmBastonV2.Param3_Formulario = "frmSecadosIngreso"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub


    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        '
        Dim DTDIIOs As System.Data.DataTable = New System.Data.DataTable("DTDIIOs")
        DTDIIOs.Columns.Add("Diio", System.Type.GetType("System.String"))
        '
        Dim inichk_ As Integer = lvDIIOS.Items.Count '- 1
        Dim TotDiios As Integer

        Cursor.Current = Cursors.WaitCursor


        lvDIIOS.Items.Clear()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            Dim diio_ As String = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim

            DTDIIOs.Rows.Add(diio_)
        Next


        TotDiios = BuscarDiiosBaston(inichk_, DTDIIOs)
        ContabilizaYValidaDIIOs()

        Cursor.Current = Cursors.Default
    End Sub


    'devuelve el nro de errores en los diios
    Private Function BuscarDiiosBaston(ByVal inichk_ As Integer, ByVal DTDIIOs As System.Data.DataTable) As Integer
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSecados_BuscarDatosDIIOs_Baston_Excel", con)
        Dim rdr As SqlDataReader

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
        cmd.Parameters.AddWithValue("@CentroCod", CentroCod)
        cmd.Parameters.AddWithValue("@DTDiios", DTDIIOs)
        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)

        lvDIIOS.BeginUpdate()

        Dim i As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Dim est_ As String = ""
            Try
                While rdr.Read()

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoProductivo").ToString.Trim)
                    item.SubItems.Add(rdr("GndEstadoReproductivo").ToString.Trim)
                    item.SubItems.Add(Format(rdr("GndUltFechaPP"), "dd-MM-yyyy"))
                    item.SubItems.Add(Format(rdr("GndUltFechaSecado"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("DiasSec").ToString.Trim)
                    item.SubItems.Add(rdr("DiasLac").ToString.Trim)
                    item.SubItems.Add(rdr("Validacion").ToString.Trim)
                    lvDIIOS.Items.Add(item)
                    i += 1
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

        lvDIIOS.EndUpdate()
    End Function

    Public Sub ContabilizaYValidaDIIOs()
        Dim cnt As Integer = 0
        Dim err_ As Integer = 0


        For i = 0 To lvDIIOS.Items.Count - 1
            Dim estado_secado_ As String = ""
            lvDIIOS.Items(i).Text = (i + 1).ToString.Trim
            estado_secado_ = lvDIIOS.Items(i).SubItems(9).Text.Trim


            If Mid(estado_secado_, 1, 3) = "ERR" Then
                err_ += 1
                lvDIIOS.Items(i).BackColor = Color.Red
            Else
                cnt += 1
                lvDIIOS.Items(i).BackColor = Color.White
            End If
        Next

        lblTotSecados.Text = cnt.ToString.Trim
        lblTotErrores.Text = err_.ToString.Trim

        If err_ = 0 Then
            btnFinalizar.Enabled = True
        Else
            btnFinalizar.Enabled = False
        End If
    End Sub

    Public Sub SumaEliminado()
        lblTotEliminados.Text = Str(Val(lblTotEliminados.Text) + 1).Trim
    End Sub


    Private Function GeneraStringDIIOs() As String
        GeneraStringDIIOs = ""

        Dim i As Integer = 0
        Dim str_ As String = ""
        Dim estado_secado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            estado_secado_ = lvDIIOS.Items(i).SubItems(8).Text.Trim

            If estado_secado_ = "" Or Mid(estado_secado_, 1, 3) = "MSJ" Then
                str_ = str_ + lvDIIOS.Items(i).SubItems(1).Text.ToString.Trim + ","
            End If
        Next

        If str_.Length > 0 Then
            str_ = Mid(str_, 1, str_.Length - 1)
        End If

        GeneraStringDIIOs = str_
    End Function


    Private Function ExistenDIIOsSinGrabar() As Boolean
        ExistenDIIOsSinGrabar = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False
        Dim estado_secado_ As String = ""

        For i = 0 To lvDIIOS.Items.Count - 1
            estado_secado_ = lvDIIOS.Items(i).SubItems(8).Text.Trim

            If estado_secado_ = "" Or Mid(estado_secado_, 1, 3) = "MSJ" Then
                existe_ = True
                Exit For
            End If
        Next

        ExistenDIIOsSinGrabar = existe_
    End Function


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

    Private Sub Exportar_A_Excel()
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Try
            Dim lin, col As Integer

            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Libro = AppExcel.Workbooks.Add
            Hoja = Libro.Worksheets(1)

            Dim i As Integer = 0

            For col = 0 To lvDIIOS.Columns.Count - 1

                Hoja.Cells(1, i + 1) = lvDIIOS.Columns(i).Text
                Hoja.Cells(1, i + 1).font.bold = True
                Hoja.Cells(1, i + 1).font.size = 12
                i = i + 1

            Next

            For lin = 0 To lvDIIOS.Items.Count - 1

                i = 0
                For col = 0 To lvDIIOS.Columns.Count - 1

                    Hoja.Cells(lin + 2, i + 1) = lvDIIOS.Items(lin).SubItems(i).Text.ToString.Trim
                    i = i + 1

                Next

            Next

            lin = lin + 3
            Hoja.Cells(lin, 1) = "TOTAL DE SECADOS: " + lblTotSecados.Text.Trim : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12


            AppExcel.Visible = True
            AppActivate(AppExcel.Caption)

            Hoja = Nothing      'Descargamos los Objetos...
            Libro = Nothing
            AppExcel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False

        If cboCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboCentros.Focus()
            Exit Function
        End If

        If ValidaDiios = True Then
            If lvDIIOS.Items.Count = 0 Then
                If MsgBox("DEBE INGRESAR EL DETALLE DE DIIOS", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If
        End If

        ValidacionesLocales = True
    End Function


    Private Sub BuscarDetalle()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSecados_ListadoDetalle", con)
        Dim FechaStr As String = Format(Param4_Fecha, "yyyy-MM-dd HH:mm:ss.fff")
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Param1_Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Fecha", FechaStr)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvDIIOS.BeginUpdate()
        lvDIIOS.Items.Clear()
        lblTotSecados.Text = "0"
        lblTotEliminados.Text = "0"

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0
        Dim est_ As Integer = 0
        Try
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If IsDBNull(rdr("SDetEstado")) = True Then
                        est_ = 0
                    Else
                        est_ = rdr("SDetEstado")
                    End If

                    If est_ = 0 Then
                        Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                        item.SubItems.Add(rdr("GndCod").ToString.Trim)

                        If IsDBNull(rdr("SDetCategoria")) = False Then
                            item.SubItems.Add(rdr("SDetCategoria").ToString.Trim)
                            item.SubItems.Add(rdr("SDetEstProdAnt").ToString.Trim)
                            item.SubItems.Add("")
                            lvDIIOS.Columns(4).Width = 0
                            item.SubItems.Add(Format(rdr("SDetFProbParto"), "dd-MM-yyyy"))
                            item.SubItems.Add(Format(rdr("SDetFProbSecado"), "dd-MM-yyyy"))
                            item.SubItems.Add(rdr("SDetDiasRealSecado").ToString.Trim)
                            item.SubItems.Add(rdr("SDetDiasLactancia").ToString.Trim)

                            If est_ = 0 Then
                                item.SubItems.Add("Grabado")
                            Else
                                item.SubItems.Add("Eliminado (" + Format(rdr("SDetFechaReg"), "dd-MM-yyyy") + ")")
                                e = e + 1
                            End If
                        Else
                            item.SubItems.Add("")
                            item.SubItems.Add("")
                            item.SubItems.Add("")
                            item.SubItems.Add("")
                            item.SubItems.Add("")
                            item.SubItems.Add("")

                            item.SubItems.Add("Grabado")
                        End If

                        lvDIIOS.Items.Add(item)
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

        lvDIIOS.EndUpdate()
        lblTotSecados.Text = i.ToString.Trim
        lblTotEliminados.Text = e.ToString.Trim
    End Sub


    Private Function GrabarSecado() As Boolean
        GrabarSecado = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSecados_GrabarDT", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim DT As System.Data.DataTable = New System.Data.DataTable
        DT.Columns.Add("Diio", System.Type.GetType("System.String"))

        For Each itm As ListViewItem In lvDIIOS.Items
            DT.Rows.Add(itm.SubItems(1).Text)
        Next

        cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
        cmd.Parameters.AddWithValue("@CentroCod", CentroCod)
        cmd.Parameters.AddWithValue("@SecadoFec", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@SecadoObs", txtObservs.Text.Trim)
        cmd.Parameters.AddWithValue("@DTDiios", DT)
        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)
        '
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            'despues de una grabacion correcta siempre activamos la edicion, ya que el encabezado ya esta creado
            Param0_ModoIngreso = 2

            GrabarSecado = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function EliminarDIIOSecado(ByVal cent_ As String, ByVal fec_ As DateTime, ByVal diio_ As Integer) As Boolean
        EliminarDIIOSecado = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSecados_EliminarDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", fec_)
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

            EliminarDIIOSecado = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub ConfirmarEliminacionDIIOSecado()
        If lvDIIOS.Items.Count = 0 Then Exit Sub
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        'si estamos editando (2), es porque los diios ya estan grabados y debemos eliminarlos de la base datos
        If Param0_ModoIngreso = 2 Then
            If MsgBox("¿DESEA ELIMINAR EL DIIO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

                Dim cent_ As String = CentrosUsuario.Codigo(cboCentros.SelectedIndex)
                Dim fec_ As DateTime = Param4_Fecha
                Dim diio_ As Integer = Val(lvDIIOS.SelectedItems.Item(0).SubItems(1).Text)

                If EliminarDIIOSecado(cent_, fec_, diio_) = True Then

                    lvDIIOS.SelectedItems(0).SubItems(8).Text = "Eliminado (" + Format(Now, "dd-MM-yyyy") + ")"
                    SumaEliminado()

                End If
            End If

            Exit Sub
        Else
            'si no estamos editando, los borramos de la grilla
            If MsgBox("¿DESEA ELIMINAR LOS DIIOS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then


                For Each it As ListViewItem In lvDIIOS.SelectedItems
                    lvDIIOS.Items.Remove(it)
                Next
                ContabilizaYValidaDIIOs()

            End If

            Exit Sub
        End If
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


    Private Sub Cerrar()
        If ExistenDIIOsSinGrabar() = True Then
            If MsgBox("EXISTEN DIIOS SIN GRABAR, ¿DESEA SALIR?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        Me.Close()
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


    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnFinalizar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarSecado() = True Then

            'Cursor.Current = Cursors.WaitCursor

            frmSecados.LlenaGrillaSecados()
            Me.Close()

            'Cursor.Current = Cursors.Default

        End If
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        frmSecadosIngresoDIIO.Param0_ModoIngreso = Param0_ModoIngreso
        frmSecadosIngresoDIIO.Param1_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        frmSecadosIngresoDIIO.Param2_NombreCentro = cboCentros.Text

        frmSecadosIngresoDIIO.MdiParent = frmMAIN
        frmSecadosIngresoDIIO.Show()
        frmSecadosIngresoDIIO.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnBastonLee_Click(sender As System.Object, e As System.EventArgs) Handles btnBastonLee.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        LeeBaston()
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        ConfirmarEliminacionDIIOSecado()
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        If lvDIIOS.Items.Count = 0 Then Exit Sub

        Exportar_A_Excel()
    End Sub


    Private Sub frmSecadosIngreso_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If lvDIIOS.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDIIOS.SelectedItems(0).SubItems(1).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If

        End If
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

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        Dim selectedRow As DataRowView = DirectCast(cboCentros.SelectedItem, DataRowView)
        If selectedRow IsNot Nothing Then CentroCod = selectedRow("CentroCod")
    End Sub
End Class