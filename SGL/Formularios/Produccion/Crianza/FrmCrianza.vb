


Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting


Public Class FrmCrianza




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


    Private Sub ConsultaPesajeCrianza(ByVal centro As String)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCrianza_ListadoPesaje", con)
        Dim rdr As SqlDataReader = Nothing

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        ' InicializaTotales()
        ' MuestraTotales()

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Diio", txtDIIO.Text)
        cmd.Parameters.AddWithValue("@Orden", "")
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvPESAJE.BeginUpdate()
        lvPESAJE.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("Empresa").ToString.Trim)
                    item.SubItems.Add(rdr("Centro").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(Format(rdr("pesofecha"), "dd-MM-yyyy")) '+ " " + rdr("PalHora").ToString.Trim)
                    item.SubItems.Add(rdr("NumPesos").ToString.Trim)
                    item.SubItems.Add(rdr("PesoObserv").ToString.Trim)
                    lvPESAJE.Items.Add(item)

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
        lvPESAJE.EndUpdate()
        'Total_General = i
        'MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Private Sub ConsultaGrficoPesaje(ByVal centro_ As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCrianza_ListadoGrafico", con)
        Dim rdrGraphic As SqlDataReader = Nothing
        Dim CntTexto = ""

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()

            ChartPesaje.Series(0).Points.Clear()
            'Dim i As Integer = 0

            Try
                While rdrGraphic.Read()

                    With ChartPesaje.Series(0)
                        .Points.AddXY(rdrGraphic("NumeroMes"), rdrGraphic("PesoPeso"))
                        .Points(.Points.Count - 1).AxisLabel = rdrGraphic("NombreMes").ToString.ToUpper
                        .Points(.Points.Count - 1).Label = "" 'rdrGraphic("NombreMes").ToString.ToUpper
                        '.Points(.Points.Count - 1).LabelToolTip = "aer1"
                        '.Points(.Points.Count - 1).LegendToolTip = "aer2"
                        .Points(.Points.Count - 1).ToolTip = rdrGraphic("PesoPeso").ToString
                    End With

                    'ChartPesaje.Series(0).Points.Add(i).XValue = rdrGraphic("NumeroMes")
                    'ChartPesaje.Series(0).Points.Add(i).YValues = Convert.ToDouble(rdrGraphic("PesoPeso"))

                    'i += 1

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub lvlPesajeCab_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvPESAJE.MouseDoubleClick
        If lvPESAJE.Items.Count = 0 Then Exit Sub
        If lvPESAJE.SelectedItems.Count = 0 Then Exit Sub
        If e.Button = MouseButtons.Left = True Then

            With frmCrianzaImportacion
                .PARAM_CENTRO = lvPESAJE.SelectedItems.Item(0).SubItems(2).Text
                .PARAM_CENTRONOM = lvPESAJE.SelectedItems.Item(0).SubItems(3).Text
                .PARAM_FECHA = CDate(lvPESAJE.SelectedItems.Item(0).SubItems(4).Text)
                .PARAM_OBSERVACIONES = lvPESAJE.SelectedItems.Item(0).SubItems(6).Text
            End With



            frmCrianzaImportacion.MdiParent = frmMAIN
            frmCrianzaImportacion.Show()
            frmCrianzaImportacion.BringToFront()


        End If

    End Sub


    Private Sub ConsultaPesajes()

        Dim cent_ As String = ""
        Dim vet_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If


        ConsultaPesajeCrianza(cent_)
        ConsultaGrficoPesaje(cent_)

    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvPESAJE.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "NRO. DE PESAJES " : tot(0, 1) = Label85.Text.Trim

        ExportToExcelGrilla(lvPESAJE, tot)
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ConsultaPesajes()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmCrianzaImportacion.MdiParent = frmMAIN
        frmCrianzaImportacion.Show()
        frmCrianzaImportacion.BringToFront()

        frmCrianzaImportacion.TabControl2.TabPages.Remove(TabPage1)
    End Sub


    Private Sub FrmCrianza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString

        ChartPesaje.Series(0).MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
        ChartPesaje.Series(0).MarkerSize = 5


        CboLLenaCentros()
        ConsultaPesajes()

    End Sub
    Private Function EliminaPesaje() As Boolean
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        EliminaPesaje = False
        Dim Lote As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCrianza_EliminarPesaje", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        Dim Cod As String = ""

        Dim fecha As Date = lvPESAJE.SelectedItems.Item(0).SubItems(4).Text

        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Centro", lvPESAJE.SelectedItems.Item(0).SubItems(2).Text)
        cmd.Parameters.AddWithValue("@NAnimales", lvPESAJE.SelectedItems.Item(0).SubItems(5).Text)
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
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If lvPESAJE.Items.Count > 0 Then


            If MsgBox("¿ DESEA ELIMINAR El PESAJE SELECCIONADO?, SE ELIMINARAN TODOS LOS PESAJES DEL DIA SELECCIONADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            If EliminaPesaje() = True Then

                lvPESAJE.Items.Clear()

                ConsultaPesajes()
            End If
        End If
    End Sub
End Class