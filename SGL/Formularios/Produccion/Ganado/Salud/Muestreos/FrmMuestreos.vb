


Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient



Public Class FrmMuestreos
    Private Total_Muestreos As Integer = 0
    Private Total_Muestras As Integer = 0
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "", "CentroNomCorto", "FecMuestreo", "NroMuestreos", "MuestreoTBC", "MuestreoLEU",
                                        "MuestreoBRU", "FecResultado", "ObsMuestreo"}

    Private CadenaOrden As String = "CentroNomCorto, FecMuestreo"



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
    Private Sub lista_usuarios_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvGanado.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvGanado, e)
    End Sub
    Private Sub InicializaTotales()
        Total_Muestreos = 0
        Total_Muestras = 0
    End Sub


    Private Sub MuestraTotales()
        Label85.Text = Total_Muestreos.ToString.Trim
        Label6.Text = Total_Muestras.ToString.Trim
        'pnlEstReprod.Refresh()
    End Sub


    Private Sub Exportar_A_Excel()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        lblProcesa.Text = "Exportando a excel, espere un momento por favor ..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = lvGanado.Items.Count
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Try
            Dim lin, col As Integer

            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Libro = AppExcel.Workbooks.Add
            Hoja = Libro.Worksheets(1)

            'Libro.Title = "Consulta de Ganado..."
            'Libro.Author = "ndsky"
            'Hoja.Name = "Libro Exportado"

            For col = 0 To lvGanado.Columns.Count - 1

                Hoja.Cells(1, col + 1) = lvGanado.Columns(col).Text
                Hoja.Cells(1, col + 1).font.bold = True
                Hoja.Cells(1, col + 1).font.size = 12

            Next

            For lin = 0 To lvGanado.Items.Count - 1

                For col = 0 To lvGanado.Columns.Count - 1
                    'Hoja.Cells.NumberFormat = "General"
                    'If col = 6 Then Hoja.Cells.NumberFormat = "dd/mm/yyyy;@"

                    Hoja.Cells(lin + 2, col + 1) = lvGanado.Items(lin).SubItems(col).Text.ToString.Trim
                Next

                pbProcesa.Value = lin + 1

            Next

            lin = lin + 2
            'Hoja.Cells(lin, 1) = "RESUMEN :" : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12

            'lin = lin + 3
            Hoja.Cells(lin + 1, 1) = "NRO MUESTREOS: " : Hoja.Cells(lin + 1, 2) = Label85.Text.Trim
            Hoja.Cells(lin + 1, 1).font.bold = True : Hoja.Cells(lin + 1, 1).font.size = 12
            Hoja.Cells(lin + 1, 2).font.bold = True : Hoja.Cells(lin + 1, 2).font.size = 12

            'Hoja.Cells(lin + 2, 1).font.bold = True : Hoja.Cells(lin + 2, 1).font.size = 12 : Hoja.Cells(lin + 2, 2).font.bold = True : Hoja.Cells(lin + 2, 2).font.size = 12
            'Hoja.Cells(lin + 3, 1).font.bold = True : Hoja.Cells(lin + 3, 1).font.size = 12 : Hoja.Cells(lin + 3, 2).font.bold = True : Hoja.Cells(lin + 3, 2).font.size = 12
            'Hoja.Cells(lin + 4, 1).font.bold = True : Hoja.Cells(lin + 4, 1).font.size = 12 : Hoja.Cells(lin + 4, 2).font.bold = True : Hoja.Cells(lin + 4, 2).font.size = 12 : Hoja.Cells(lin + 4, 3).font.bold = True : Hoja.Cells(lin + 4, 3).font.size = 12

            pbProcesa.Value = pbProcesa.Maximum

            AppExcel.Visible = True
            AppActivate(AppExcel.Caption)

            Hoja = Nothing      'Descargamos los Objetos...
            Libro = Nothing
            AppExcel = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        pnlProcesa.Visible = False
        Cursor.Current = Cursors.Default
    End Sub


    Public Sub ConsultaMuestreos(ByVal cent_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestreos_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim tbc_, leu_, bru_ As Integer

        tbc_ = IIf(chkTBC.Checked = True, 1, 0)
        leu_ = IIf(chkLEU.Checked = True, 1, 0)
        bru_ = IIf(chkBRU.Checked = True, 1, 0)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@CheckTBC", tbc_)
        cmd.Parameters.AddWithValue("@CheckLEU", leu_)
        cmd.Parameters.AddWithValue("@CheckBRU", bru_)
        cmd.Parameters.AddWithValue("@DIIO", txtDIIO.Text)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        InicializaTotales()
        MuestraTotales()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Dim f1, f2, f3 As String

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    f1 = ""
                    f2 = ""
                    f3 = ""

                    If FechaCorrecta(rdr("FecResultadoTBC").ToString) = True Then f1 = Format(rdr("FecResultadoTBC"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("FecResultadoLEU").ToString) = True Then f2 = Format(rdr("FecResultadoLEU"), "dd-MM-yyyy")
                    If FechaCorrecta(rdr("FecResultadoBRU").ToString) = True Then f3 = Format(rdr("FecResultadoBRU"), "dd-MM-yyyy")

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("Empresa").ToString.Trim)
                    item.SubItems.Add(rdr("Centro").ToString.Trim)
                    item.SubItems.Add(rdr("CentroNomCorto").ToString.Trim)
                    item.SubItems.Add(Format(rdr("FecMuestreo")))                                'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("NroMuestreos").ToString.Trim)
                    item.SubItems.Add(rdr("MuestreoTBC").ToString.Trim)
                    item.SubItems.Add(f1)
                    item.SubItems.Add(rdr("MuestreoLEU").ToString.Trim)
                    item.SubItems.Add(f2)
                    item.SubItems.Add(rdr("MuestreoBRU").ToString.Trim)
                    item.SubItems.Add(f3)
                    item.SubItems.Add(rdr("ObsMuestreo").ToString.Trim)
                    item.SubItems.Add(rdr("TipoMuestreo").ToString.Trim)

                    lvGanado.Items.Add(item)

                    'If rdr("TrasTipo") = 1 Then
                    'If rdr("TMovNombre").ToString.Trim.ToUpper.Contains("SALIDA") = True Then
                    'Total_Muestreos = Total_Muestreos + Val(rdr("SumaMuestreos").ToString.Trim)
                    Total_Muestras = Total_Muestras + Val(rdr("NroMuestreos").ToString.Trim)
                    'Else
                    'Total_Hembras = Total_Hembras + Val(rdr("SumaHembras").ToString.Trim)
                    'End If

                    'Total_Ganado = Total_Ganado + Val(rdr("TrasNumRegs").ToString.Trim)
                    i = i + 1
                    pbProcesa.Value = i
                End While

                'pbProcesa.Value = pbProcesa.Maximum
                'If Total_Crias > 0 Then
                ' Por_Hembras = (Total_Hembras / Total_Crias) * 100
                'Else
                'Por_Hembras = 0
                'End If


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        Finally
            con.Close()
        End Try

SalirProc:
        lvGanado.EndUpdate()
        Total_Muestreos = i
        MuestraTotales()
        pnlProcesa.Visible = False

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub LlenaMuestreos()
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "CentroNomCorto, FecMuestreo"
            lblOrden.Text = "Centro, FecMuestreo"
            lblOrden.Refresh()
        End If

        ConsultaMuestreos(cent_)
    End Sub



    Private Sub lvGanado_ColumnClick(sender As System.Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvGanado.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub
        If CamposOrden(e.Column).Trim = "" Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrden.Text = lvGanado.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrden.Text = lblOrden.Text + " -> " + lvGanado.Columns(e.Column).Text
        End If
    End Sub


    Private Sub lvGanado_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleMuestreos(2)
        End If
    End Sub


    Private Sub DetalleMuestreos(ByVal modo_ As Integer)
        Dim cent_ As String = lvGanado.SelectedItems(0).SubItems(2).Text            'codigo centro
        Dim nomcent_ As String = lvGanado.SelectedItems(0).SubItems(3).Text         'nombre centro
        Dim fec_ As String = lvGanado.SelectedItems(0).SubItems(4).Text             'fecha
        Dim tmuest_ As String = lvGanado.SelectedItems(0).SubItems(13).Text         'tipo muestra
        Dim obs_ As String = lvGanado.SelectedItems(0).SubItems(12).Text            'observacion
        Dim fecres_ As String = lvGanado.SelectedItems(0).SubItems(9).Text          'fecha resultado

        FrmMuestreosIngreso.Param0_ModoIngreso = modo_     '1=nuevo ingreso muestreos / 2=ver detalle de muestreos
        FrmMuestreosIngreso.Param1_CodigoCentro = cent_
        FrmMuestreosIngreso.Param2_NombreCentro = nomcent_
        FrmMuestreosIngreso.Param3_FechaMuestreo = fec_
        FrmMuestreosIngreso.Param4_TipoMuestreo = tmuest_
        FrmMuestreosIngreso.Param5_Observacion = obs_

        If fecres_ <> "" Then
            FrmMuestreosIngreso.Param6_TieneResultado = True
            FrmMuestreosIngreso.Param7_FechaResultado = fecres_
        Else
            FrmMuestreosIngreso.Param6_TieneResultado = False
            FrmMuestreosIngreso.Param7_FechaResultado = Now
        End If

        FrmMuestreosIngreso.MdiParent = frmMAIN
        FrmMuestreosIngreso.Show()
    End Sub


    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Exportar_A_Excel()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        FrmMuestreosIngreso.Param0_ModoIngreso = 1      'nuevo ingreso de muestreo
        'FrmMuestreosIngreso.Param1_CodigoCentro = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)
        'FrmMuestreosIngreso.Param2_NombreCentro = cboCentros.Text

        FrmMuestreosIngreso.MdiParent = frmMAIN
        FrmMuestreosIngreso.Show()
        FrmMuestreosIngreso.BringToFront()

        Cursor.Current = Cursors.Default

        'FrmMuestreosIngreso.Show()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaMuestreos()
    End Sub


    Private Sub FrmMuestreos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now


    End Sub



    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        Dim fecha As DateTime
        Dim centro As String = ""
        For i = 0 To lvGanado.Items.Count - 1
            If lvGanado.Items(i).Selected = True Then
                validalista = 1
                fecha = lvGanado.Items(i).SubItems(4).Text
                centro = lvGanado.Items(i).SubItems(2).Text
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Registro de la Lista")
            Exit Sub
        End If

        EliminarMuestreo(fecha, centro)
    End Sub

    Public Sub EliminarMuestreo(ByVal fecha As DateTime, ByVal centro As String)

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestreos_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

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
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    Exit Sub
                End If
            Else
                MsgBox("Datos Eliminados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Exit Sub
        Finally
            con.Close()
            LlenaMuestreos()




        End Try

        Cursor.Current = Cursors.Default
    End Sub
End Class