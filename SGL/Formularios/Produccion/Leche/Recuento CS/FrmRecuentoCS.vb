Imports System.Data.SqlClient
Imports System.Threading
Imports Excel = Microsoft.Office.Interop.Excel

Public Class FrmRecuentoCS

    Public Cod_Estanque As String
    Public Nom_Estanque As String
    Public px As Integer
    Public py As Integer
    Private TitleGraphic As String = "Comparación Mensual Recuento de Célula Somática "



    Private Sub FrmRecuentoCS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.CentrosUsuarioEstanque.Cargar()
        General.RCSListadoAños.Cargar()

        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8

        Chart2.Series("Series1").LegendText = ""
        Chart2.Series("Series2").LegendText = ""
        Chart2.Titles("Title1").Text = TitleGraphic
        cboEstanques.Enabled = False

        CboLLenaCentros()
        CboLlenaAños()

        cboAñoRCS.SelectedIndex = 0
        cboCentros.Text = NombreCentroUsuario

        If PerfilUsuario = 4 Then
            btnAgregar.Enabled = True
        Else
            btnAgregar.Enabled = False
        End If

        'lblMenosDe300.BackColor = System.Drawing.Color.Yellow 'Color.Yellow
        'lblSobre300.BackColor = System.Drawing.Color.Tomato 'Color.Yellow

    End Sub

    Private Sub lvRCS_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRCS.MouseDown
        'PRIMERO DESENCADENA EL MOUSE DOWN Y DESPUES EL MOUSE CLICK
        If lvRCS.Items.Count = 0 Then Exit Sub

        Dim p As Point = lvRCS.PointToClient(New Point(Cursor.Position.X, Cursor.Position.Y))
        px = p.X
        py = p.Y
    End Sub

    Private Sub lvRCS_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRCS.MouseDoubleClick
        Dim AñoCbo As String = cboAñoRCS.Text.Trim
        If e.Button = MouseButtons.Left = True Then
            Cod_Estanque = lvRCS.SelectedItems.Item(0).SubItems(1).Text
            Nom_Estanque = lvRCS.SelectedItems.Item(0).SubItems(4).Text
            DetalleRCS(Cod_Estanque, Nom_Estanque, AñoCbo, px, py)
        End If
    End Sub

    Private Sub lvRCS_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvRCS.MouseClick
        Dim AñoCbo As String = cboAñoRCS.Text.Trim
        If e.Button = MouseButtons.Left = True Then
            Cod_Estanque = lvRCS.SelectedItems.Item(0).SubItems(1).Text
            Nom_Estanque = lvRCS.SelectedItems.Item(0).SubItems(4).Text
            Dim S1 As String = "Series1"
            Dim S2 As String = "Series2"
            'Año Actual
            Dim Cod_Centro As String
            Cod_Centro = lvRCS.SelectedItems.Item(0).SubItems(17).Text
            ConsultaRCS_Graphic(Cod_Centro, Cod_Estanque, AñoCbo, S1)
            'Año Anterior
            ConsultaRCS_Graphic(Cod_Centro, Cod_Estanque, CStr(CInt(AñoCbo) - 1), S2)
        End If
    End Sub

    Public Sub DetalleRCS(ByVal Codigo_ As String, ByVal Nombre_ As String, ByVal Año_ As String, ByVal posX_ As Integer, ByVal posY_ As Integer)
        If posX_ < 338 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Dim MesNomCorto As String = ""
        'Recuperar posicion del Mouse Clic... 64
        If posX_ > 338 And posX_ < 402 Then MesNomCorto = "ENE"
        If posX_ > 403 And posX_ < 467 Then MesNomCorto = "FEB"
        If posX_ > 468 And posX_ < 532 Then MesNomCorto = "MAR"
        If posX_ > 533 And posX_ < 597 Then MesNomCorto = "ABR"
        If posX_ > 598 And posX_ < 662 Then MesNomCorto = "MAY"
        If posX_ > 663 And posX_ < 727 Then MesNomCorto = "JUN"
        If posX_ > 728 And posX_ < 792 Then MesNomCorto = "JUL"
        If posX_ > 793 And posX_ < 857 Then MesNomCorto = "AGO"
        If posX_ > 858 And posX_ < 922 Then MesNomCorto = "SEP"
        If posX_ > 923 And posX_ < 987 Then MesNomCorto = "OCT"
        If posX_ > 988 And posX_ < 1052 Then MesNomCorto = "NOV"
        If posX_ > 1053 And posX_ < 1117 Then MesNomCorto = "DIC"

        lblMes.Text = MesNomCorto
        lblPosX.Text = posX_
        lblPosY.Text = posY_

        Dim DetalleEstanque As New FrmRecuentoCSDetalle

        Dim indexes As ListView.SelectedIndexCollection = lvRCS.SelectedIndices
        DetalleEstanque.MdiParent = frmMAIN
        DetalleEstanque.lblCodEstanque.Text = Cod_Estanque
        DetalleEstanque.lblNomEstanque.Text = Nom_Estanque
        DetalleEstanque.lblMesNom.Text = MesNomCorto
        DetalleEstanque.lblAño.Text = Año_

        DetalleEstanque.ConsultaEstanque(Cod_Estanque, MesNomCorto, Año_)

        DetalleEstanque.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub LimpiarFiltros(Optional ByVal LimpiaTipoReporte As Boolean = True, Optional ByVal idx As Integer = 0)
        cboCentros.SelectedIndex = 0
        cboEstanques.SelectedIndex = 0
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    'Private Sub CboLLenaCentros()
    '    If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

    '    cboCentros.Items.Clear()

    '    Dim i As Integer
    '    'Dim posicionselected As Integer
    '    For i = 0 To General.CentrosUsuario.NroRegistros - 1
    '        'If General.CentrosUsuario.Codigo(i) = General.CodigoCentroUsuario Then
    '        ' posicionselected = i
    '        ' End If
    '        cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
    '    Next
    '    'cboCentros.SelectedIndex = posicionselected

    '    cboCentros.Text = NombreCentroUsuario
    'End Sub


    Private Sub CboLlenaAños()
        If General.RCSListadoAños.NroRegistros = 0 Then Exit Sub

        cboAñoRCS.Items.Clear()

        Dim i As Integer

        For i = 0 To General.RCSListadoAños.NroRegistros - 1
            cboAñoRCS.Items.Add(General.RCSListadoAños.AñosRCS(i).Trim)
        Next
    End Sub

    Private Function CenExisteEnCbo(ByVal cen_ As String) As Boolean
        'USAR ESTA FUNCION PARA NO REPETIR LOS CENTROS EN EL COMBO BOX, CUANDO TIENE MAS DE 2 ESTANQUES
        CenExisteEnCbo = False
        Dim ExisteCbo As Boolean = False
        For i As Integer = 0 To cboCentros.Items.Count - 1
            Dim CentroEnCbo As String = cboCentros.Items(i).ToString.Trim
            If cen_ = CentroEnCbo Then
                ExisteCbo = True
            End If
        Next
        CenExisteEnCbo = ExisteCbo
    End Function


    Private Sub CboLlenaEstanques(ByVal centroNomCbo As String)
        If General.CentrosUsuarioEstanque.NroRegistros = 0 Then Exit Sub

        cboEstanques.Items.Clear()
        cboEstanques.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuarioEstanque.NroRegistros - 1
            If General.CentrosUsuarioEstanque.CentroTipo(i) = "SALA" And General.CentrosUsuarioEstanque.CentroVig(i) = "SI" And General.CentrosUsuarioEstanque.EstanqueCOD(i) <> "" _
                And General.CentrosUsuarioEstanque.Nombre(i).ToUpper = centroNomCbo Then

                cboEstanques.Items.Add(General.CentrosUsuarioEstanque.EstanqueNOM(i))

            End If
        Next
    End Sub


    Private Sub ConsultaDatos()
        Dim centroRCS_ As String = ""
        Dim pos_ As Integer = 0
        Dim cent_ As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        'Obetener el Codigo del Estanque
        If cboEstanques.SelectedIndex <> -1 And cboEstanques.Text <> "(TODOS)" Then
            For i = 0 To General.CentrosUsuarioEstanque.NroRegistros - 1
                If General.CentrosUsuarioEstanque.CentroTipo(i) = "SALA" And General.CentrosUsuarioEstanque.CentroVig(i) = "SI" And General.CentrosUsuarioEstanque.EstanqueCOD(i) <> "" _
                                    And General.CentrosUsuarioEstanque.Nombre(i).ToUpper = cboCentros.Text.Trim And General.CentrosUsuarioEstanque.EstanqueNOM(i).ToUpper = cboEstanques.Text.Trim Then
                    pos_ = i
                    Exit For
                End If
            Next

            centroRCS_ = General.CentrosUsuarioEstanque.EstanqueCOD(pos_)
        End If

        Dim añoRCS_ As Integer = CInt(cboAñoRCS.Text.Trim)

        Cursor.Current = Cursors.WaitCursor
        ConsultaRCS(cent_, centroRCS_, añoRCS_)                                     'Busca los datos con lo seleccionado en los ComboBox
        ConsultaRCS_Graphic(cent_, centroRCS_, CStr(añoRCS_), "Series1")            'Año Actual
        ConsultaRCS_Graphic(cent_, centroRCS_, CStr(añoRCS_ - 1), "Series2")        'Año Anterior
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If cboCentros.SelectedIndex = -1 Then Exit Sub

        cboEstanques.Enabled = False

        If cboCentros.Text <> "(TODOS)" Then
            cboEstanques.Enabled = True
            CboLlenaEstanques(cboCentros.Text)
            cboEstanques.SelectedIndex = 0
        Else
            'DEBE LISTAR TODOS LOS ESTANQUES Y NO DEJAR HABILITADO EL COMBO BOX DE ESTANQUES
            ConsultaDatos()
        End If
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ConsultaDatos()
    End Sub


    Private Sub ConsultaRCS(ByVal centro_ As String, ByVal centroRCS_ As String, ByVal año_ As Integer)
        lblTotReg.Text = "0"
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_ConsultaGeneral", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@CentroRSC", centroRCS_)
        cmd.Parameters.AddWithValue("@Año", año_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvRCS.BeginUpdate()
        lvRCS.Items.Clear()

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
                    CountRegListView = lvRCS.Items.Count


                    Dim item As New ListViewItem("")    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("EstanqueCod").ToString.Trim)
                    item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("CenNom").ToString.Trim)
                    item.SubItems.Add(rdr("EstanqueNom").ToString.Trim)
                    '###### ENERO ######
                    Dim EneVal As String = rdr("ENE").ToString.Trim
                    If EneVal = "0,00" Then EneVal = "-"
                    item.SubItems.Add(EneVal)
                    '###### FEBRERO ######
                    Dim FebVal As String = rdr("FEB").ToString.Trim
                    If FebVal = "0,00" Then FebVal = "-"
                    item.SubItems.Add(FebVal)
                    '###### MARZO ######
                    Dim MarVal As String = rdr("MAR").ToString.Trim
                    If MarVal = "0,00" Then MarVal = "-"
                    item.SubItems.Add(MarVal)
                    '###### ABRIL ######
                    Dim AbrVal As String = rdr("ABR").ToString.Trim
                    If AbrVal = "0,00" Then AbrVal = "-"
                    item.SubItems.Add(AbrVal)
                    '###### MAYO ######
                    Dim MayVal As String = rdr("MAY").ToString.Trim
                    If MayVal = "0,00" Then MayVal = "-"
                    item.SubItems.Add(MayVal)
                    '###### JUNIO ######
                    Dim JunVal As String = rdr("JUN").ToString.Trim
                    If JunVal = "0,00" Then JunVal = "-"
                    item.SubItems.Add(JunVal)
                    '###### JULIO ######
                    Dim JulVal As String = rdr("JUL").ToString.Trim
                    If JulVal = "0,00" Then JulVal = "-"
                    item.SubItems.Add(JulVal)
                    '###### AGOSTO ######
                    Dim AgoVal As String = rdr("AGO").ToString.Trim
                    If AgoVal = "0,00" Then AgoVal = "-"
                    item.SubItems.Add(AgoVal)
                    '###### SEPTIEMBRE ######
                    Dim SepVal As String = rdr("SEP").ToString.Trim
                    If SepVal = "0,00" Then SepVal = "-"
                    item.SubItems.Add(SepVal)
                    '###### OCTUBRE ######
                    Dim OctVal As String = rdr("OCT").ToString.Trim
                    If OctVal = "0,00" Then OctVal = "-"
                    item.SubItems.Add(OctVal)
                    '###### NOVIEMBRE ######
                    Dim NovVal As String = rdr("NOV").ToString.Trim
                    If NovVal = "0,00" Then NovVal = "-"
                    item.SubItems.Add(NovVal)
                    '###### DICIEMBRE ######
                    Dim DicVal As String = rdr("DIC").ToString.Trim
                    If DicVal = "0,00" Then DicVal = "-"
                    item.SubItems.Add(DicVal)
                    'CenCod
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)

                    lvRCS.Items.Add(item)

                    pbProcesa.Value = i
                    i = i + 1

                End While
                colorearListView()
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
        lvRCS.EndUpdate()
        pnlProcesa.Visible = False
        TotalReg()
    End Sub

    Private Sub ConsultaRCS_Graphic(ByVal centro_ As String, ByVal estanqueCod_ As String, ByVal añoRCS_ As String, ByVal NomSerieGraphic As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRCS_ConsultaPorEstanqueAnual", con)
        Dim rdrGraphicAnual As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@CentroRSC", estanqueCod_)
        cmd.Parameters.AddWithValue("@Año", añoRCS_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        If centro_ = "" Then
            Nom_Estanque = "(TODOS)"
        End If

        Try
            con.Open()
            'CONSULTA PARA GRAFICO ANUAL
            rdrGraphicAnual = cmd.ExecuteReader()
            Chart2.Titles("Title1").Text = TitleGraphic + Nom_Estanque
            Chart2.Series(NomSerieGraphic).Points.DataBindXY(rdrGraphicAnual, "MesRCS", rdrGraphicAnual, "CantRCSProm")
            Chart2.Series(NomSerieGraphic).LegendText = "AÑO " + añoRCS_
            rdrGraphicAnual.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub colorearListView()
        Dim ValorCelda As String = ""
        For lin = 0 To lvRCS.Items.Count - 1
            For col = 5 To lvRCS.Columns.Count - 1
                lvRCS.Items(lin).UseItemStyleForSubItems = False
                ValorCelda = lvRCS.Items(lin).SubItems(col).Text.ToString.Trim
                If ValorCelda <> "" And ValorCelda <> "-" Then
                    If CInt(ValorCelda) >= 250 And CInt(ValorCelda) < 299 Then
                        '_lvRCS.Items(i).BackColor = Color.Yellow
                        lvRCS.Items(lin).SubItems(col).BackColor = System.Drawing.Color.Yellow 'Color.Yellow
                    End If
                    If CInt(ValorCelda) >= 300 Then
                        '_lvRCS.Items(i).BackColor = Color.Yellow
                        lvRCS.Items(lin).SubItems(col).BackColor = System.Drawing.Color.Tomato 'Color.Yellow
                    End If
                End If
            Next
        Next
        'For Each _item As ListViewItem In lvRCS.Items
        '    For i As Integer = 5 To lvRCS.Columns.Count - 1
        '        lvRCS.Items(i).UseItemStyleForSubItems = False
        '        ValorCelda = _item.SubItems(i).Text
        '        'lvRCS.Items(i).ToString.Trim

        '        If ValorCelda <> "" Then
        '            If CInt(ValorCelda) >= 250 And CInt(ValorCelda) < 299 Then
        '                '_lvRCS.Items(i).BackColor = Color.Yellow
        '                _item.SubItems(i).BackColor = System.Drawing.Color.Red 'Color.Yellow
        '            End If
        '        End If
        '    Next
        'Next
    End Sub

    Public Sub TotalReg()
        lblTotReg.Text = lvRCS.Items.Count
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor
        frmRCSIngreso.MdiParent = frmMAIN
        frmRCSIngreso.Show()
        frmRCSIngreso.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Cursor.Current = Cursors.WaitCursor
        FrmRecuentoCSImportacion.MdiParent = frmMAIN
        FrmRecuentoCSImportacion.Show()
        Cursor.Current = Cursors.Default
    End Sub



    Private Sub FrmRecuentoCS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvRCS.Items.Count = 0 Then Exit Sub

        Exportar_A_Excel()
    End Sub
    Private Sub Exportar_A_Excel()
        If lvRCS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        lblProcesa.Text = "Exportando a excel, espere un momento por favor ..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = Val(lblTotReg.Text)
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Try
            Dim lin, col As Integer

            Dim AppExcel As New Microsoft.Office.Interop.Excel.Application
            Dim Libro As Microsoft.Office.Interop.Excel.Workbook
            Dim Hoja As Microsoft.Office.Interop.Excel.Worksheet

            Libro = AppExcel.Workbooks.Add
            Hoja = Libro.Worksheets(1)

            Dim ValorCelda As String
            Dim AñoCbo As String = cboAñoRCS.Text.Trim
            For col = 0 To lvRCS.Columns.Count - 1
                Hoja.Cells(1, col + 1).NumberFormat = "@"
                ValorCelda = lvRCS.Columns(col).Text
                Hoja.Cells(1, col + 1) = ValorCelda
                If col >= 5 Then
                    ValorCelda = ValorCelda + "-" + AñoCbo
                    Hoja.Cells(1, col + 1) = ValorCelda
                End If
                Hoja.Cells(1, col + 1).font.bold = True
                Hoja.Cells(1, col + 1).font.size = 12

            Next
            Dim formatoCelda = "##0.00"
            Dim filaExcel As Integer
            Dim columExcel As Integer
            For lin = 0 To lvRCS.Items.Count - 1

                For col = 0 To lvRCS.Columns.Count - 1
                    filaExcel = lin + 2
                    columExcel = col + 1
                    ValorCelda = lvRCS.Items(lin).SubItems(col).Text.ToString.Trim
                    If col >= 5 Then
                        Hoja.Cells(filaExcel, columExcel).NumberFormat = formatoCelda
                        If ValorCelda = "-" Then
                            ValorCelda = "0"
                        End If
                        'ValorCelda = CStr(CDec(ValorCelda) * 1000)
                        Hoja.Cells(filaExcel, columExcel) = ValorCelda.Trim

                    Else
                        'Hoja.Cells(filaExcel, columExcel).NumberFormat = "General"
                        Hoja.Cells(filaExcel, columExcel) = ValorCelda.Trim
                    End If


                Next

                pbProcesa.Value = lin + 1

            Next

            lin = lin + 3
            Hoja.Cells(lin, 1) = "TOTAL REG: " : Hoja.Cells(lin, 2) = lblTotReg.Text.Trim
            Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12
            Hoja.Cells(lin, 2).font.bold = True : Hoja.Cells(lin, 2).font.size = 12

            'lin = lin + 2
            'Hoja.Cells(lin, 1) = "RESUMEN :" : Hoja.Cells(lin, 1).font.bold = True : Hoja.Cells(lin, 1).font.size = 12
            'Hoja.Cells(lin + 1, 1) = "TOTAL CRIAS" : Hoja.Cells(lin + 1, 2) = "22"
            'Hoja.Cells(lin + 2, 1) = "TOTAL HEMBRAS" : Hoja.Cells(lin + 2, 2) = "23"
            'Hoja.Cells(lin + 3, 1) = "PORC. HEMBRAS" : Hoja.Cells(lin + 3, 2) = "24" : Hoja.Cells(lin + 3, 3) = "%"

            Hoja.Cells(lin + 1, 1).font.bold = True : Hoja.Cells(lin + 1, 1).font.size = 12 : Hoja.Cells(lin + 1, 2).font.bold = True : Hoja.Cells(lin + 1, 2).font.size = 12
            Hoja.Cells(lin + 2, 1).font.bold = True : Hoja.Cells(lin + 2, 1).font.size = 12 : Hoja.Cells(lin + 2, 2).font.bold = True : Hoja.Cells(lin + 2, 2).font.size = 12
            Hoja.Cells(lin + 3, 1).font.bold = True : Hoja.Cells(lin + 3, 1).font.size = 12 : Hoja.Cells(lin + 3, 2).font.bold = True : Hoja.Cells(lin + 3, 2).font.size = 12 : Hoja.Cells(lin + 3, 4).font.bold = True : Hoja.Cells(lin + 3, 3).font.size = 12

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


    Private Sub cboEstanques_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEstanques.SelectedIndexChanged
        ConsultaDatos()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class