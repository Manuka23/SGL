

Imports System.IO
Imports System.IO.Ports
Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient


Public Class frmCrianzaImportacion

    Public Procesa As Boolean = False
    Public ArchivoImportacion As String
    Public NombreArchivo As String
    Public ListaDiios As String
    Public BuscarDiiosBaston As String

    '***PARAMETROS DE LLAMADA 
    Public PARAM_CENTRO As String
    Public PARAM_CENTRONOM As String
    Public PARAM_FECHA As Date
    Public PARAM_OBSERVACIONES As String

    Private LeyendoBaston As Boolean = False
    Private TotalDiios As Integer
    Private GuardaTotDiios As Integer

    ''
    Dim fnvacunados As New fnVacunados
    Dim FnCrianzaPesos As New fnCrianzaPeso

    Private Function BuscaNombreRaza(ByVal cod_raza As Integer) As String
        BuscaNombreRaza = ""

        Dim i As Integer
        Dim nom As String = ""

        For i = 0 To General.Razas.Codigo.Length - 1
            'If Not General.Razas.Codigo(i) Is Nothing Then
            If General.Razas.Codigo(i) = cod_raza Then
                nom = General.Razas.Nombre(i)
                Exit For
            End If
            'End If
        Next

        BuscaNombreRaza = nom
    End Function


    Private Sub btnArchivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivo.Click
        If cboCentros.Text <> "" Then
            OpenFDlg.FileName = ""
            OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
            OpenFDlg.ShowDialog()
            If OpenFDlg.FileName.Trim() <> "" Then
                ArchivoImportacion = OpenFDlg.FileName.Trim
                NombreArchivo = OpenFDlg.SafeFileName.Trim
                txtArchivo.Text = NombreArchivo
                MostrarYValidarDatosAImportar()
                ContabilizaYValidaDIIOs()

                cboCentros.Enabled = False
                btnArchivo.Enabled = False
                dtpFechaDesde.Enabled = False
                TxtObservaciones.Enabled = False
                TxtObservaciones.Enabled = False
                btnSalir.Text = "Volver"

                If LblTotErrores.Text = 0 Then
                    btnProcesar.Enabled = True
                End If
            End If
        Else
            MsgBox("Debe Seleccionar un Centro" + vbCrLf, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error de Validación")
        End If
    End Sub
    Private Sub MostrarYValidarDatosAImportar()
        Dim lin As Integer

        Cursor.Current = Cursors.WaitCursor

        Lbltotdiios.Text = "0"

        Try
            Dim Procesa As Boolean
            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Libro = AppExcel.Workbooks.Open(ArchivoImportacion)
            Hoja = Libro.Worksheets(1)
            lin = 1
            Procesa = True
            FnCrianzaPesos.DtExcelCrear()

            Do While Procesa
                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    ConsultaCrianzaDiios()
                    Exit Do
                End If
                Dim DiioCol As String = Hoja.Cells(lin, 1).value
                Dim PesoCol As String = Hoja.Cells(lin, 2).value
                Dim RazaCol As String = Hoja.Cells(lin, 3).value
                FnCrianzaPesos.DtExcel(DiioCol, PesoCol, RazaCol)
                lin = lin + 1
            Loop
            Hoja = Nothing      'Descargamos los Objetos...
            Libro.Close()
            AppExcel.Quit()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Lbltotdiios.Text = (lin - 1).ToString().Trim
        Cursor.Current = Cursors.Default
    End Sub
    Public Sub ConsultaCrianzaDiios()
        Dim est_ As String
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCrianza_ListadoExcel", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 300 ' 5 minutos
        cmd.Parameters.AddWithValue("@Fecha", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@TablaDetalle", FnCrianzaPesos.DetallesExcel)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        lvDETALLE.BeginUpdate()
        lvDETALLE.Items.Clear()
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()

                    Dim item As New ListViewItem((lvDETALLE.Items.Count + 1).ToString)   'primera columna, para ordenar datos
                    est_ = ""
                    item.SubItems.Add(rdr("Diio").ToString.Trim) 'Diio
                    For i = 0 To lvDETALLE.Items.Count - 1
                        If lvDETALLE.Items(i).SubItems(1).Text.Trim = rdr("Diio").ToString.Trim Then
                            est_ = "ERR / DIIO REPETIDO "
                        End If
                    Next
                    item.SubItems.Add(rdr("Peso").ToString.Trim) ' Peso -Pesa
                    'If IsNumeric(rdr("Peso").ToString.Trim) Then
                    '    If rdr("Peso").ToString.Trim >= 200 Then
                    '        item.SubItems.Add("VAQUILLAS")
                    '    Else
                    '        item.SubItems.Add("TERNERAS")
                    '    End If
                    'Else
                    '    item.SubItems.Add("")
                    'End If                                        'CategoriaPEso
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)
                    item.SubItems.Add(rdr("RazaEnPeso").ToString.Trim)   'Razaen pesaje
                    item.SubItems.Add(rdr("GndProNom").ToString.Trim)  'Categoria actual en pesaje
                    If rdr("RazaNueva").ToString.Trim = "" Then
                        est_ = "ERR / RAZA INGRESADA NO VALIDA "
                    End If
                    item.SubItems.Add(rdr("RazaNueva").ToString.Trim)     'RazaActual en pesaje nueva

                    If IsNumeric(rdr("Peso")) = False Then
                        est_ = "PESO INCORRECTO"
                    End If
                    If rdr("GndCenCod").ToString.Trim <> General.CentrosUsuario.Codigo(cboCentros.SelectedIndex) Then
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
                    If est_ <> "" Then LblTotErrores.Text = Int32.Parse(LblTotErrores.Text) + 1
                    If rdr("Observacion").ToString.Trim = "Null" Then
                        est_ = "ERR / ANIMAL NO ESTA EN STOCK "
                    End If
                    If rdr("DiioDia").ToString.Trim <> "" Then
                        est_ = "ERR / YA EXISTE UN PESAJE PARA ESTE DIIO CON ESTA FECHA Y CENTRO ESPECIFICADO"
                    End If
                    item.SubItems.Add(est_)


                    item.SubItems.Add(rdr("CodRazaActual").ToString.Trim) 'RazaActual en pesaje
                    'If IsNumeric(rdr("Peso")) Then
                    '    If rdr("Peso") > 200 Then
                    '        item.SubItems.Add("H002")
                    '    Else
                    '        item.SubItems.Add("H003")
                    '    End If
                    'Else
                    '    item.SubItems.Add("")
                    'End If
                    item.SubItems.Add(rdr("GndProCod").ToString.Trim)
                    item.SubItems.Add(rdr("CodRazaAnterior").ToString.Trim)     'RazaActual en pesaje nueva GndProCod
                    item.SubItems.Add(rdr("GndProCod").ToString.Trim)
                    lvDETALLE.Items.Add(item)
                End While


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
        lvDETALLE.EndUpdate()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If btnSalir.Text = "Volver" Then
            cboCentros.Enabled = True
            btnArchivo.Enabled = True
            btnProcesar.Enabled = False
            dtpFechaDesde.Enabled = True
            TxtObservaciones.Enabled = True
            btnSalir.Text = "Salir"
            Lbltotdiios.Text = "0"
            LblTotErrores.Text = "0"
            lvDETALLE.Items.Clear()
            FnCrianzaPesos.VaciaDatatable()

        Else
            FrmCrianza.btnBuscar.PerformClick()
            Me.Close()
            ' 
        End If
    End Sub


    Private Sub Label86_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label86.Click

    End Sub


    Private Sub FrmCrianzaImportacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Razas.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        ChartPesaje.Series(0).MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
        ChartPesaje.Series(0).MarkerSize = 5

        CboLLenaCentros()

        If PARAM_CENTRO <> "" Then
            cboCentros.Text = PARAM_CENTRONOM
            dtpFechaDesde.Value = PARAM_FECHA
            TxtObservaciones.Text = PARAM_OBSERVACIONES

            GroupBox3.Visible = False
            btnExcel.Left = btnProcesar.Left
            btnArchivo.Visible = False
            btnBorrarErrores.Visible = False
            btnEliminar.Visible = True

            cboCentros.Enabled = False
            dtpFechaDesde.Enabled = False
            TxtObservaciones.Enabled = False
            btnProcesar.Enabled = False

            lvDETALLE.Columns(6).Width = lvDETALLE.Columns(6).Width + 40
            lvDETALLE.Columns(7).Width = 0        'ocultamos columna de resultados
            lvDETALLE.Columns(8).Width = 0        '
            lvDETALLE.Columns(9).Width = 0        '

            Me.Text = "Detalle Pesaje Crianza"

            ConsultaDetallePesajeCrianza()
        End If
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

    End Sub


    Private Sub ConsultaDetallePesajeCrianza()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCrianza_ListadoPesajeDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", PARAM_CENTRO)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvDETALLE.BeginUpdate()
        lvDETALLE.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            ChartPesaje.Series(0).Points.Clear()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If
                    i = i + 1
                    Dim item As New ListViewItem(i.ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("PesoDiio").ToString.Trim)
                    item.SubItems.Add(rdr("PesoPeso").ToString.Trim)
                    item.SubItems.Add(rdr("NomCategoriaPeso").ToString.Trim)
                    item.SubItems.Add(rdr("NomRazaPeso").ToString.Trim)
                    item.SubItems.Add(rdr("NomCategoriaAnt").ToString.Trim)
                    item.SubItems.Add(rdr("RazaActual").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("PesoRaza").ToString.Trim)
                    item.SubItems.Add(rdr("PesoCategoria").ToString.Trim)
                    item.SubItems.Add(rdr("PesoRaza").ToString.Trim)
                    item.SubItems.Add(rdr("PesoCategoria").ToString.Trim)
                    lvDETALLE.Items.Add(item)

                    With ChartPesaje.Series(0)
                        .Points.AddXY(Month(rdr("PesoFecha")), rdr("PesoPeso"))
                        .Points(.Points.Count - 1).AxisLabel = Format(rdr("PesoFecha"), "dd-MM-yyyy")
                        .Points(.Points.Count - 1).Label = ""
                        .Points(.Points.Count - 1).ToolTip = rdr("PesoPeso").ToString
                    End With


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
        lvDETALLE.EndUpdate()
        Lbltotdiios.Text = i.ToString.Trim
        pnlProcesa.Visible = False
    End Sub



    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvDETALLE.Items.Count - 1
            If i <> pos_ Then
                If lvDETALLE.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function
    Private Sub VerificaDIIOEnGrillaEliminacion(ByVal posini As Integer)

        Dim i As Integer = 0
        Dim existe_ As Integer = 0

        For i = 0 To lvDETALLE.Items.Count - 1
            If i <> posini Then
                If lvDETALLE.Items(i).SubItems(1).Text.ToString.Trim = lvDETALLE.Items(posini).SubItems(1).Text.ToString.Trim Then
                    lvDETALLE.Items(i).SubItems(7).Text = "ERR / REPETIDO"
                Else
                    lvDETALLE.Items(i).SubItems(7).Text = ""
                End If
            End If
        Next

    End Sub
    Public Sub ContabilizaYValidaDIIOs()
        Dim i As Integer = 0
        Dim err_ As Integer = 0
        Dim estado_ As String = ""


        For i = 0 To lvDETALLE.Items.Count - 1
            lvDETALLE.Items(i).Text = (i + 1).ToString.Trim
            estado_ = lvDETALLE.Items(i).SubItems(7).Text.Trim

            If estado_.Contains("ERR") Then
                err_ += 1
            End If
        Next

        LblTotErrores.Text = err_.ToString.Trim

        If LblTotErrores.Text = 0 Then
            btnProcesar.Enabled = True
        Else
            btnProcesar.Enabled = False
        End If

        If lvDETALLE.Items.Count = 0 Then Exit Sub

    End Sub

    Private Sub LvlPesaje_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDETALLE.KeyDown

        If e.KeyCode = Keys.Delete Then
            If MsgBox("DESEA ELIMINAR LOS DIIOS SELECCIONADOS?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
                Dim i As Integer = 0
                Cursor.Current = Cursors.WaitCursor
                For Each it As ListViewItem In lvDETALLE.SelectedItems
                    lvDETALLE.Items.Remove(it)
                Next
                For i = 0 To lvDETALLE.Items.Count - 1
                    VerificaDIIOEnGrillaEliminacion(i)
                Next
                Lbltotdiios.Text = lvDETALLE.Items.Count.ToString.Trim
                ContabilizaYValidaDIIOs()
                If LblTotErrores.Text = 0 Then
                    btnSalir.Text = "Volver"
                    btnProcesar.Enabled = True
                    cboCentros.Enabled = False
                    btnArchivo.Enabled = False
                    dtpFechaDesde.Enabled = False
                    TxtObservaciones.Enabled = False
                End If
            End If
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub LvlPesaje_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvDETALLE.SelectedIndexChanged

    End Sub

    Private Sub btnProcesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
        If MsgBox("¿ DESEA GRABAR INFORMACION DE PESAJE PARA ESTE CENTRO Y FECHA  ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            If GrabarPesajeCrianza() = True Then
                FnCrianzaPesos.VaciaDatatable()
                btnSalir.PerformClick()
            Else
                MsgBox("PROCESO CANCELADO, ERRORES EN LA GRILLA", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "INFORMACION")
                btnProcesar.Enabled = False
            End If

        End If

    End Sub


    Private Function GrabarPesajeCrianza() As Boolean
        GrabarPesajeCrianza = False


        Dim cent_ As String = ""
        Dim diios_ As String = ""
        Dim i As Integer = 0

        cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        FnCrianzaPesos.GrabarPesajeCrianza(Empresa, cent_, dtpFechaDesde.Value, lvDETALLE, TxtObservaciones.Text, LoginUsuario, NombrePC)
        GrabarPesajeCrianza = True

    End Function



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarErrores.Click
        If MsgBox("¿ DESEA ELIMINAR LOS ERRORES ENCONTRADOS ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If lvDETALLE.Items.Count = 0 Then Exit Sub

        Dim i, x, ct As Integer
        Dim pos() As Integer
        ReDim pos(0)

        x = 0
        ct = lvDETALLE.Items.Count - 1

DeNuevo:
        For i = 0 To lvDETALLE.Items.Count - 1
            If lvDETALLE.Items(i).SubItems(7).Text.Trim.Contains("ERR") Then

                lvDETALLE.Items.Remove(lvDETALLE.Items(i))
                GoTo DeNuevo
            End If
        Next

        ContabilizaYValidaDIIOs()
        Lbltotdiios.Text = (lvDETALLE.Items.Count).ToString.Trim
    End Sub


    Private Sub LvlPesaje_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvDETALLE.MouseDoubleClick
        If lvDETALLE.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub

    Private Sub DetalleGanado()
        If lvDETALLE.Items.Count = 0 Then Exit Sub
        If lvDETALLE.SelectedItems.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvDETALLE.SelectedItems.Item(0).SubItems(1).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub

    Private Sub mnuCopiarDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarDiio.Click
        If lvDETALLE.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvDETALLE.SelectedItems(0).SubItems(1).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvDETALLE.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "NRO. ANIMALES " : tot(0, 1) = Lbltotdiios.Text.Trim

        ExportToExcelGrilla(lvDETALLE, tot)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If lvDETALLE.Items.Count > 0 Then


            If MsgBox("¿ DESEA ELIMINAR El PESAJE SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            If EliminaPesaje() = True Then

                lvDETALLE.Items.Clear()

                ConsultaDetallePesajeCrianza()
            End If
        End If
    End Sub
    Private Function EliminaPesaje() As Boolean
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        EliminaPesaje = False
        Dim Lote As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCrianza_EliminarPesajedetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        Dim Cod As String = ""

        cmd.Parameters.AddWithValue("@Fecha", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Diio", lvDETALLE.SelectedItems.Item(0).SubItems(1).Text)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
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
            EliminaPesaje = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
End Class