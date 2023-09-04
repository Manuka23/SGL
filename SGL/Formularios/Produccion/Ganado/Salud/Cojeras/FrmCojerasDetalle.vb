

Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient


Public Class FrmCojerasDetalle

    Public P1_CodigoCentro As Integer
    Public P2_NombreCentro As String
    Public P3_FechaDesde As DateTime
    Public P4_FechaHasta As DateTime
    Public P5_NroCasos As String
    Public P6_NroTratamientos As String
    Public P7_NroResguardos As String


    'nombre de los campos en la base de datos, para realizar los ordenamientos desde esta pantalla
    Private CamposOrden As String() = {"", "EmpresaCod", "DIIO", "FechaCojera", "FecInicioTrat", "FecTerminoTrat", _
                                       "FecLiberacion", "TipoCojeraNom", "FarmNombre", "CojaAD", "CojaAI", "CojaPD", "CojaPI", "CojaObservacion"}

    Private CadenaOrden As String = " DIIO, FechaCojera"
    Private Diios As String()


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Private Sub DetalleGanado()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvGanado.SelectedItems.Item(0).SubItems(2).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CopiarDiio()
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(2).Text

        Clipboard.Clear()
        Clipboard.SetText(diio_)
    End Sub


    Public Sub ConsultaCojeras()
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCojeras_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", P1_CodigoCentro)
        cmd.Parameters.AddWithValue("@FechaDesde", Format(P3_FechaDesde, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@FechaHasta", Format(P4_FechaHasta, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@DIIO", txtDIIO.Text)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        'InicializaTotales()
        'MuestraTotales()
        lblNroCasos.Text = "0"
        lblNroCojas.Text = "0"
        Diios = {}

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim ad_, ai_, pd_, pi_ As String
        Dim DiioCojas As String = ""
        Dim ConsideraCoja As Integer
        Dim Solo3 As Boolean = chkConTres.Checked
        Dim StockActual As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ad_ = rdr("CojaAD").ToString.Trim
                    ai_ = rdr("CojaAI").ToString.Trim
                    pd_ = rdr("CojaPD").ToString.Trim
                    pi_ = rdr("CojaPI").ToString.Trim
                    DiioCojas = rdr("Diio").ToString.Trim
                    ConsideraCoja = rdr("ConsideraCojera")
                    If i = 0 Then
                        StockActual = rdr("StockActual")
                    End If
                    If ad_ = "1" Then ad_ = "X" Else ad_ = ""
                    If ai_ = "1" Then ai_ = "X" Else ai_ = ""
                    If pd_ = "1" Then pd_ = "X" Else pd_ = ""
                    If pi_ = "1" Then pi_ = "X" Else pi_ = ""

                    If (Solo3 = True And rdr("NumeroCojeras") >= 4) Or (Solo3 = False) Then

                        AgregaDiioSiNoExiste(DiioCojas, ConsideraCoja)

                        Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                        'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))

                        item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                        item.SubItems.Add(rdr("Diio").ToString.Trim)
                        item.SubItems.Add(Format(rdr("FechaCojera"), "dd-MM-yyyy"))
                        item.SubItems.Add(Format(rdr("FecInicioTrat"), "dd-MM-yyyy"))
                        item.SubItems.Add(Format(rdr("FecTerminoTrat"), "dd-MM-yyyy"))
                        item.SubItems.Add(Format(rdr("FecLiberacion"), "dd-MM-yyyy"))
                        item.SubItems.Add(rdr("TipoCojeraNom").ToString.Trim)
                        item.SubItems.Add(rdr("FarmNombre").ToString.Trim)
                        item.SubItems.Add(ad_)
                        item.SubItems.Add(ai_)
                        item.SubItems.Add(pd_)
                        item.SubItems.Add(pi_)
                        item.SubItems.Add(rdr("CojaObservacion").ToString.Trim)

                        lvGanado.Items.Add(item)

                        'Total_Mastitis = Total_Mastitis + Val(rdr("SumaMastitis").ToString.Trim)
                        'Total_Tratamientos = Total_Tratamientos + Val(rdr("SumaTratamientos").ToString.Trim)
                        i = i + 1

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

SalirProc:
        lvGanado.EndUpdate()
        'MuestraTotales()
        lblNroCasos.Text = i.ToString.Trim
        lblNroCojas.Text = Diios.Count.ToString.Trim
        lblStockActual.Text = StockActual.ToString.Trim
        lblPercent.Text = CalcPorcentaje(Diios.Count, StockActual)

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub AgregaDiioSiNoExiste(ByVal diio As String, ByVal considera As Integer)
        Dim i As Integer
        Dim Existe As Boolean = False

        For i = 0 To Diios.Count - 1
            If Diios(i) = diio Then
                Existe = True
            End If
        Next

        If Not Existe And considera = 1 Then
            ReDim Preserve Diios(i)
            Diios(i) = diio
        End If
    End Sub


    Private Sub BuscarDatos()
        If CadenaOrden = "" Then
            CadenaOrden = " Diio, FechaCojera"
            lblOrden.Text = "DIIO -> Fecha"
            lblOrden.Refresh()
        End If

        ConsultaCojeras()
    End Sub


    Private Sub mnuCopiarDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCopiarDiio.Click
        CopiarDiio()
    End Sub


    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub


    Private Sub lvGanado_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        FrmCojerasIngreso.MdiParent = frmMAIN
        FrmCojerasIngreso.Show()
        FrmCojerasIngreso.BringToFront()

        FrmCojerasIngreso.cboCentros.Text = cboCentros.Text
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarDatos()
    End Sub


    Private Sub FrmMastitisDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.C Then
                CopiarDiio()
            End If
        End If
    End Sub



    Private Sub lvGanado_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvGanado.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrden.Text = lvGanado.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrden.Text = lblOrden.Text + " -> " + lvGanado.Columns(e.Column).Text
        End If
    End Sub


    Private Sub btnLimpiarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrden.Text = ""
    End Sub


    Private Sub FrmCojerasDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()

        cboCentros.Text = P2_NombreCentro
        dtpFechaDesde.Value = P3_FechaDesde
        dtpFechaHasta.Value = P4_FechaHasta

        lblNroCasos.Text = P5_NroCasos.ToString.Trim
        Label6.Text = P6_NroTratamientos.ToString.Trim
        Label8.Text = P7_NroResguardos.ToString.Trim

        ConsultaCojeras()
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        EliminarCojera()
    End Sub


    Private Sub EliminarCojera()
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR LA COJERA SELECCIONADA?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If EliminarDIIOCojera() = True Then
                ConsultaCojeras()
            End If
        End If
    End Sub


    Private Function EliminarDIIOCojera() As Boolean
        EliminarDIIOCojera = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCojeras_EliminarDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(2).Text
        Dim fec_ As Date = Date.Parse(lvGanado.SelectedItems(0).SubItems(3).Text)
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
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

            EliminarDIIOCojera = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "NRO CASOS" : tot(0, 1) = P5_NroCasos.ToString.Trim
        tot(1, 0) = "CASOS EN TRATAMIENTO" : tot(1, 1) = P6_NroTratamientos.ToString.Trim
        tot(2, 0) = "CASOS EN RESGUARDO" : tot(2, 1) = P7_NroResguardos.ToString.Trim

        ExportToExcelGrilla(lvGanado, tot)
    End Sub

    Private Sub lvGanado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvGanado.SelectedIndexChanged

    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

    End Sub
End Class