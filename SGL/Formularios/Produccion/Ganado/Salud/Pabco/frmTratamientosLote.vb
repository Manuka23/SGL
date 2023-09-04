Imports System.Data.SqlClient
Imports System.Threading
Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms.ListViewItem

Public Class frmTratamientosLote
    Public Lote As String
    Public CodPatologia As Integer
    Public CodMedicamento As Integer
    Public CentroCod As String
    Public CentroNom As String
    Public CargaLV As Boolean = False

    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If lvFARMACOS.Items.Count > 0 Then


            If MsgBox("¿ DESEA ELIMINAR El DIIO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            If EliminaTratamiento() = True Then

                lvFARMACOS.Items.Clear()

                ConsultaGndVacunado()
            End If
        End If
    End Sub
    Private Function EliminaTratamiento() As Boolean
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        EliminaTratamiento = False
        Dim Lote As String = ""
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_EliminarTratamiento", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        Dim Cod As String = ""

        Cod = lvFARMACOS.SelectedItems.Item(0).SubItems(22).Text
        Dim fecha As Date = lvFARMACOS.SelectedItems.Item(0).SubItems(1).Text

        cmd.Parameters.AddWithValue("@Cod", Cod)
        cmd.Parameters.AddWithValue("@Lote", Lote)
        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Centro", lvFARMACOS.SelectedItems.Item(0).SubItems(23).Text)
        cmd.Parameters.AddWithValue("@Diio", lvFARMACOS.SelectedItems.Item(0).SubItems(2).Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            EliminaTratamiento = True
            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvFARMACOS.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvFARMACOS, e)
    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvFARMACOS.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}


        ExportToExcelGrilla(lvFARMACOS, tot)
    End Sub

    Private Sub lvFARMACOS_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvFARMACOS.MouseDoubleClick
        If lvFARMACOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub

    Private Sub DetalleGanado()
        If lvFARMACOS.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvFARMACOS.SelectedItems.Item(0).SubItems(2).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)
        ConsultaDIIO.TabControl1.SelectedIndex = 5
        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub frmTratamientosLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        lbCentroNom.Text = CentroNom
        lbCentroCod.Text = CentroCod

        If PerfilUsuario = 13 Then
            btnEliminar.Enabled = True
        Else
            btnEliminar.Enabled = False
        End If
        lblNLote.Text = Lote
        buscar()
    End Sub

    Private Sub buscar()
        lvFARMACOS.Items.Clear()

        ConsultaGndVacunado()
    End Sub
    Public Sub ConsultaGndVacunado()
        lvFARMACOS.Items.Clear()
        Thread.Sleep(20)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_ListadoLote", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Lote", Lote)
        cmd.Parameters.AddWithValue("@CodPatologia", CodPatologia)
        cmd.Parameters.AddWithValue("@CodMedicamento", CodMedicamento)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvFARMACOS.BeginUpdate()
        lvFARMACOS.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)

                    item.SubItems.Add(Format(rdr("TratFecha"), "dd/MM/yyyy"))
                    item.SubItems.Add(rdr("TratDiio"))
                    item.SubItems.Add(rdr("CategoNom"))
                    item.SubItems.Add(rdr("TratEstProductivo"))
                    item.SubItems.Add(rdr("TratEstReproductivo"))
                    item.SubItems.Add(rdr("NomPatologia"))
                    item.SubItems.Add(rdr("AD"))
                    item.SubItems.Add(rdr("AI"))
                    item.SubItems.Add(rdr("PD"))
                    item.SubItems.Add(rdr("TratPI"))
                    item.SubItems.Add(rdr("MedNombre"))
                    item.SubItems.Add(rdr("TratDosis"))
                    item.SubItems.Add(rdr("AM"))
                    item.SubItems.Add(rdr("PM"))
                    item.SubItems.Add(rdr("TratDuracionTrat"))

                    If rdr("DiasLeche") = "0" Then
                        item.SubItems.Add("")
                    Else
                        item.SubItems.Add(Format(rdr("TratInicioTratamiento"), "dd/MM/yyyy"))
                    End If
                    item.SubItems.Add(rdr("TratFinTratamiento"))
                    item.SubItems.Add(rdr("TratDiasTratamiento"))
                    item.SubItems.Add(rdr("DiasLeche"))
                    item.SubItems.Add(rdr("DiasCarne"))

                    If rdr("DiasLeche") = 0 Then
                        item.SubItems.Add("")
                    Else
                        item.SubItems.Add(Format(rdr("FechaLeche"), "dd/MM/yyyy"))
                        If rdr("FechaLeche") < Date.Now Then
                            item.BackColor = Color.LightGreen
                        End If
                    End If
                    If rdr("DiasCarne") = 0 Then
                        item.SubItems.Add("")
                    Else
                        item.SubItems.Add(Format(rdr("FechaCarne"), "dd/MM/yyyy"))
                    End If

                    item.SubItems.Add(rdr("Num"))
                    item.SubItems.Add(rdr("CentroNomCorto"))
                    If rdr("TratEstado") = "FINALIZADO" Then
                        item.Checked = True
                        If item.BackColor <> Color.LightGreen Then
                            item.BackColor = Color.LightGray
                        End If
                    End If
                    item.SubItems.Add(rdr("CodPatologia"))
                    item.SubItems.Add(rdr("MedCodigo"))
                    item.SubItems.Add(rdr("TratEstado"))
                    lvFARMACOS.Items.Add(item)
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
        lvFARMACOS.EndUpdate()
        Label10.Text = i.ToString.Trim
        CargaLV = True
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If lvFARMACOS.SelectedItems.Count = 0 Then
            MsgBox("DEBE SELECCIONAR UN DIIO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ADVERTENCIA")
            Exit Sub
        End If

        With frmIngresoTratamientos

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            .txtDIIO.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(2).Text
            .cboCentros.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(24).Text
            .dtpFechaInicio.Value = lvFARMACOS.SelectedItems.Item(0).SubItems(1).Text
            .cboPatologias.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(6).Text
            .Medicamentos.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(11).Text
            '.DosisTxt.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(12).Text
            If lvFARMACOS.SelectedItems.Item(0).SubItems(13).Text = "X" Then
                .rbtnAM.Checked = True
            Else
                .rbtnPM.Checked = True
            End If
            .txtDiasTrat.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(18).Text
            .lblTratCodigo.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(23).Text
            .Actualizar = "SI"
            .btnBuscar.PerformClick()
            .cboCentros.Enabled = False
            .txtDIIO.Enabled = False
            .btnGrabar.Visible = False
            .btnBastonLee.Visible = False
            .btnActualizar.Visible = True
            .btnActualizar.Enabled = False
            .Button2.Enabled = False
            .dtpFechaInicio.Enabled = False
        End With

    End Sub
    Private Sub btnLiberarLeche_Click(sender As Object, e As EventArgs) Handles btnLiberarLeche.Click
        If lvFARMACOS.SelectedItems.Count = 0 Then
            MsgBox("DEBE SELECCIONAR UN DIIO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ACTUALIZACION")
            Exit Sub
        End If

        Dim Liberacion As Integer = 1
        Dim FecLeche As DateTime

        If lvFARMACOS.SelectedItems.Item(0).SubItems(21).Text = "" Then
            FecLeche = Format(CDate("1900-01-01 00:00:00.000"), "dd-MM-yyyy")
        Else
            FecLeche = Format(CDate(lvFARMACOS.SelectedItems.Item(0).SubItems(21).Text), "dd-MM-yyyy")
        End If



        With frmPabcoLiberarLeche

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            .lblCentro.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(24).Text
            .lblDiioLote.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(2).Text
            .lblCodPat.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(25).Text
            .lblNomPatologia.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(6).Text
            .lblCodMed.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(26).Text
            .lblNomMedicamento.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(11).Text
            .lblFecLeche.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(21).Text
            .lblFecCarne.Text = lvFARMACOS.SelectedItems.Item(0).SubItems(22).Text
            If FecLeche = "1900-01-01 00:00:00.000" Or FecLeche > Date.Now Then
                .btnGrabar.Enabled = False
            End If
            .TipoLiberacion = Liberacion
            .lblLote.Visible = False

        End With
    End Sub

    Private Sub btnCierreLote_Click(sender As Object, e As EventArgs) Handles btnCierreLote.Click
        PabcoLoteCierre(lvFARMACOS)
    End Sub
    Public Sub PabcoLoteCierre(ByVal lvFARMACOS As ListView)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPabcoLotes_Cierre", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Diios As DataTable = TablaDiios(lvFARMACOS)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", CentroCod)
        cmd.Parameters.AddWithValue("@Lote", Lote)
        cmd.Parameters.AddWithValue("@TablaDiios", Diios)
        cmd.Parameters.AddWithValue("@CodPatologia", CodPatologia)
        cmd.Parameters.AddWithValue("@CodMedicamento", CodMedicamento)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            Dim vret As Integer = cmd.Parameters("@ResultCod").Value
            Dim mret As String = cmd.Parameters("@ResultMsg").Value

            If vret = -1 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        MsgBox("DATOS GUARDADOS CORRECTAMENTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ACTUALIZACION")
    End Sub
    Public Function TablaDiios(ByVal lvFARMACOS As ListView) As DataTable
        TablaDiios = Nothing
        Dim table As DataTable = New DataTable("DTDiios")

        table.Columns.Add("Diio", System.Type.GetType("System.String"))

        For i = 0 To lvFARMACOS.Items.Count - 1
            If lvFARMACOS.Items(i).Checked Then
                table.Rows.Add(lvFARMACOS.Items(i).SubItems(2).Text)
            End If
        Next
        TablaDiios = table
    End Function
    Private Sub lvFARMACOS_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lvFARMACOS.ItemCheck
        If CargaLV = False Then ' al momento de cargar el load daba error ya que los valores que venian chequeados desde la BD lo evaluava mientras cargaba
            Return              ' esto permite que mientras no se cargue todo el load no se evaluaran los checkbox
        End If

        If e.Index >= 0 Then    ' cuando seleccionabamos el check sin seleccionar la fila daba error ya que el SelectedItems llegaba nulo 
            lvFARMACOS.Items(e.Index).Selected = True ' con este codigo cuando se chequea el checkbox indicamos que se esta seleccionando la fila
        End If

        If lvFARMACOS.SelectedItems.Item(0).SubItems(27).Text = "FINALIZADO" Then ' debemos bloquear el cambio de estado para los que vienen finalizados desde la BD
            e.NewValue = e.CurrentValue ' esto evita que los valores chequeados desde la BD los puedan desmarcar, ya que una vez finalizado el tratamiento no se puede modificar
            lvFARMACOS.Items(e.Index).Selected = False ' quitamos la seleccion de la fila para los FINALIZADOS ya que generaba un error para seguir seleccionando
        End If
    End Sub
End Class