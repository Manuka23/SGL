Imports System.Data.SqlClient

Public Class frmCambioDeDiios

    Private Sub frmCambioDeDiios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        Dim FechaIniMes As String = "01-" + Format(dtpFechaDesde.Value, "dd-MM-yyyy").Substring(3)
        dtpFechaDesde.Value = FechaIniMes

        CboLLenaCentros()
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

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        MostrarDatosLV()
    End Sub

    Public Sub MostrarDatosLV()
        Dim cent_ As String = ""
        Dim vet_ As Integer = 0
        Dim causa_ As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        'If CadenaOrden = "" Then
        '    CadenaOrden = "CenDesCor"
        '    lblOrdena.Text = "Centro"
        '    lblOrdena.Refresh()
        'End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaCambiosDeDiios(cent_, txtDIIO.Text.Trim)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ConsultaCambiosDeDiios(ByVal centro_ As String, Optional ByVal diio_ As String = "")

        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCambioDeDiios_ConsultaGeneral", con)
        Dim rdr As SqlDataReader = Nothing
        Dim NroRegs As Integer = 0
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", centro_)
        cmd.Parameters.AddWithValue("@FechaDesde", Format(dtpFechaDesde.Value, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@FechaHasta", Format(dtpFechaHasta.Value, "dd-MM-yyyy"))
        cmd.Parameters.AddWithValue("@DIIO", diio_)
        'cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvCambioDiios.BeginUpdate()
        lvCambioDiios.Items.Clear()

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    If NroRegs = 0 Then
                        NroRegs = rdr("CountRegs")
                        pbProcesa.Maximum = NroRegs
                    End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)
                    item.SubItems.Add(rdr("CentroNomCorto").ToString.Trim)
                    item.SubItems.Add(Format(rdr("FechaCambio"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("DiioAnterior").ToString.Trim)
                    item.SubItems.Add(rdr("DiioNuevo").ToString.Trim)
                    item.SubItems.Add(rdr("GndProCod").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    item.SubItems.Add(rdr("Obs").ToString.Trim)
                    item.SubItems.Add(rdr("Usuario").ToString.Trim)
                    lvCambioDiios.Items.Add(item)

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
        lvCambioDiios.EndUpdate()

        pnlProcesa.Visible = False
        lblContReg.Text = i.ToString
        'Si ingreso un Diio a Buscar, los busca dentro de los datos consultados.
        'BuscaDiioEnListView(diio_)
    End Sub

    Private Sub BuscaDiioEnListView(ByVal diio_ As String)
        Dim ValorDiioAnt As String = ""
        Dim ValorDiioNuevo As String = ""
        For lin = 0 To lvCambioDiios.Items.Count - 1
            ValorDiioAnt = lvCambioDiios.Items(lin).SubItems(5).Text.ToString.Trim
            ValorDiioNuevo = lvCambioDiios.Items(lin).SubItems(6).Text.ToString.Trim
            If ValorDiioAnt = diio_ Or ValorDiioNuevo = diio_ Then
                lvCambioDiios.Items(lin).Selected = True
                'lvCambioDiios.Items(lin).BackColor = System.Drawing.Color.Yellow
                lvCambioDiios.SelectedItems(0).EnsureVisible()
                lvCambioDiios.Focus()
            End If

        Next
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor
        frmCambioDeDiiosIngreso.MdiParent = frmMAIN
        frmCambioDeDiiosIngreso.Show()
        frmCambioDeDiiosIngreso.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub txtDIIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            MostrarDatosLV()
        Else
            If InStr(1, "0123456789,-%" & Chr(8), e.KeyChar) = 0 Then
                e.KeyChar = ""
            End If
        End If
    End Sub

    Private Sub lvCambioDiios_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvCambioDiios.MouseClick
        If lvCambioDiios.Items.Count = 0 Then Exit Sub

        'If e.Button = MouseButtons.Right = True Then
        'End If
    End Sub

    'Variables utilizadas para eliminar un cambio de arete
    Private CenCod_ As String = ""
    Private FechaCambio_ As DateTime
    Private DiioOld_ As String = ""
    Private DiioNew_ As String = ""
    Private Sub mnuEliminarCambio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEliminarCambio.Click
        If lvCambioDiios.Items.Count = 0 Then Exit Sub
        If lvCambioDiios.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿Desea Eliminar el Cambio de Diio Seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarCambioDiioBD() = True Then
            If MsgBox("Eliminacion realizada con exito.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                MostrarDatosLV()
            End If
        End If
    End Sub

    Private Function EliminarCambioDiioBD() As Boolean
        EliminarCambioDiioBD = False
        Cursor.Current = Cursors.WaitCursor

        CenCod_ = lvCambioDiios.SelectedItems.Item(0).SubItems(2).Text()
        FechaCambio_ = lvCambioDiios.SelectedItems.Item(0).SubItems(4).Text()
        DiioOld_ = lvCambioDiios.SelectedItems.Item(0).SubItems(5).Text()
        DiioNew_ = lvCambioDiios.SelectedItems.Item(0).SubItems(6).Text()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCambioDeDiios_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CentroCod", CenCod_)
        cmd.Parameters.AddWithValue("@FechaCambio", FechaCambio_)
        cmd.Parameters.AddWithValue("@Arete_Anterior", DiioOld_)
        cmd.Parameters.AddWithValue("@Arete_Nuevo", DiioNew_)
        cmd.Parameters.AddWithValue("@User", LoginUsuario)
        cmd.Parameters.AddWithValue("@UserPC", NombrePC)

        cmd.Parameters.Add("@RespValor", SqlDbType.Int) : cmd.Parameters("@RespValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RespMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RespMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RespValor").Value
            Dim mret As String = cmd.Parameters("@RespMsg").Value

            If vret = 0 Or vret = 2 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR AL ELIMINAR REGISTRO DE LA BASE DE DATOS.") = vbOK Then
                End If
                Exit Function
            End If
            'Elimina la fila seleccionada
            lvCambioDiios.Items.Remove(lvCambioDiios.SelectedItems(0))
            EliminarCambioDiioBD = True
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        If cboCentros.SelectedIndex = -1 Then Exit Sub
        MostrarDatosLV()
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvCambioDiios.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL REGS." : tot(0, 1) = lblContReg.Text

        ExportToExcelGrilla(lvCambioDiios, tot)
    End Sub

    Private Sub mnuVerDetDiio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuVerDetDiio.Click
        DetalleGanado()
    End Sub
    Private Sub DetalleGanado()
        If lvCambioDiios.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvCambioDiios.SelectedItems.Item(0).SubItems(6).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub
End Class