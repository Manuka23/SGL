

Imports System.Data.SqlClient


Public Class FrmMastitisDetalle

    Public P1_CodigoCentro As Integer
    Public P2_NombreCentro As String
    Public P3_FechaDesde As DateTime
    Public P4_FechaHasta As DateTime
    Public P5_NroCasos As String
    Public P6_NroTratamientos As String
    Public P7_NroResguardos As String

    'nombre de los campos en la base de datos, para realizar los ordenamientos desde esta pantalla
    Private CamposOrden As String() = {"", "MastEmpresa", "MastDIIO", "MastFecha", "MastFecInicioTrat", "MastFecTerminoTrat", _
                                       "MastFecLiberacion", "FarmNombre", "MastAD", "MastAI", "MastPD", "MastPI", "MastObservacion"}

    Private CadenaOrden As String = "MastDIIO, MastFecha"
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


    Public Sub ConsultaMastitis()
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMastitis_ListadoDetalle", con)
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
        Label10.Text = "0"
        Label12.Text = "0"
        Diios = {}

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Dim ad_, ai_, pd_, pi_ As String
        Dim DiioMastitis As String = ""
        Dim Solo3 As Boolean = chkConTres.Checked

        'MsgBox(Diios.Count.ToString)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ad_ = rdr("MastAD").ToString.Trim
                    ai_ = rdr("MastAI").ToString.Trim
                    pd_ = rdr("MastPD").ToString.Trim
                    pi_ = rdr("MastPI").ToString.Trim
                    DiioMastitis = rdr("MastDIIO").ToString.Trim

                    If ad_ = "1" Then ad_ = "X" Else ad_ = ""
                    If ai_ = "1" Then ai_ = "X" Else ai_ = ""
                    If pd_ = "1" Then pd_ = "X" Else pd_ = ""
                    If pi_ = "1" Then pi_ = "X" Else pi_ = ""

                    If (Solo3 = True And rdr("NumeroMastitis") >= 4) Or (Solo3 = False) Then

                        AgregaDiioSiNoExiste(DiioMastitis)

                        Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                        'format(rdr("TrasFechaHora"), "dd-MM-yyyy HH:mm"))

                        item.SubItems.Add(rdr("MastEmpresa").ToString.Trim)
                        item.SubItems.Add(DiioMastitis)
                        item.SubItems.Add(Format(rdr("MastFecha"), "dd-MM-yyyy"))
                        item.SubItems.Add(Format(rdr("MastFecInicioTrat"), "dd-MM-yyyy"))
                        item.SubItems.Add(Format(rdr("MastFecTerminoTrat"), "dd-MM-yyyy"))
                        item.SubItems.Add(Format(rdr("MastFecLiberacion"), "dd-MM-yyyy"))
                        item.SubItems.Add(rdr("FarmNombre").ToString.Trim)
                        item.SubItems.Add(ai_)
                        item.SubItems.Add(ad_)
                        item.SubItems.Add(pi_)
                        item.SubItems.Add(pd_)

                        item.SubItems.Add(rdr("MastObservacion").ToString.Trim)

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
        Label10.Text = i.ToString.Trim
        Label12.Text = Diios.Count.ToString.Trim

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub AgregaDiioSiNoExiste(ByVal diio As String)
        Dim i As Integer
        Dim Existe As Boolean = False

        For i = 0 To Diios.Count - 1
            If Diios(i) = diio Then
                Existe = True
            End If
        Next

        If Not Existe Then
            ReDim Preserve Diios(i)
            Diios(i) = diio
        End If
    End Sub


    Private Sub BuscarDatos()
        If CadenaOrden = "" Then
            CadenaOrden = "MastDIIO, MastFecha"
            lblOrden.Text = "DIIO -> Fecha"
            lblOrden.Refresh()
        End If

        ConsultaMastitis()
    End Sub


    Private Sub mnuCopiarDiio_Click(sender As System.Object, e As System.EventArgs) Handles mnuCopiarDiio.Click
        CopiarDiio()
    End Sub


    Private Sub mnuVerDetalle_Click(sender As System.Object, e As System.EventArgs) Handles mnuVerDetalle.Click
        DetalleGanado()
    End Sub


    Private Sub lvGanado_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        FrmMastitisIngreso.MdiParent = frmMAIN
        FrmMastitisIngreso.Show()
        FrmMastitisIngreso.BringToFront()

        FrmMastitisIngreso.cboCentros.Text = cboCentros.Text
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        BuscarDatos()
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


    Private Sub FrmMastitisDetalle_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.C Then
                CopiarDiio()
            End If
        End If
    End Sub


    Private Sub FrmMastitisDetalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentros()

        cboCentros.Text = P2_NombreCentro
        dtpFechaDesde.Value = P3_FechaDesde
        dtpFechaHasta.Value = P4_FechaHasta

        Label10.Text = P5_NroCasos.ToString.Trim
        Label6.Text = P6_NroTratamientos.ToString.Trim
        Label8.Text = P7_NroResguardos.ToString.Trim

        ConsultaMastitis()
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        EliminarMastitis()
    End Sub


    Private Sub EliminarMastitis()
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR LA MASTITIS SELECCIONADA?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then

            If EliminarDIIOMastitis() = True Then
                ConsultaMastitis()
            End If
        End If
    End Sub


    Private Function EliminarDIIOMastitis() As Boolean
        EliminarDIIOMastitis = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMastitis_EliminarDetalle", con)
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

            EliminarDIIOMastitis = True

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
End Class