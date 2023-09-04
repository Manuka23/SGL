Imports System.Data.SqlClient
Imports System.Threading
Imports Microsoft.Reporting.WinForms
Imports System.IO
Public Class frmListadoTratamientos
    Public cent_ As String = ""

    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmListadoTratamientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.Patologias.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        'dtpFechaHasta.Value = Date.Now
        CboLLenaPatologias()
        cboPatologias.SelectedIndex = 0
        ' dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
        btnBuscar.PerformClick()
    End Sub
    Private Sub CboLLenaPatologias()
        If General.Patologias.NroRegistros = 0 Then Exit Sub

        cboPatologias.Items.Clear()
        cboPatologias.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Patologias.NroRegistros - 1
            cboPatologias.Items.Add(General.Patologias.Nombre(i))
        Next


        'cboCentros.SelectedIndex = -1
    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvFARMACOS.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvFARMACOS, e)
    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvFARMACOS.Items.Clear()

        ConsultaGndVacunado()
    End Sub

    Public Sub ConsultaGndVacunado()
        lvFARMACOS.Items.Clear()
        Thread.Sleep(20)


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)

        If cboPatologias.SelectedIndex = 0 Then
            cmd.Parameters.AddWithValue("@Patologia", "")
        Else
            cmd.Parameters.AddWithValue("@Patologia", General.Patologias.Codigo(cboPatologias.SelectedIndex - 1))
        End If

        cmd.Parameters.AddWithValue("@Centro", cent_)

        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value) ' Mid(dtpFechaDesde.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value) 'Mid(dtpFechaHasta.Value.ToString, 1, 24))

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        'lvGanado.Items.Clear()
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

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos

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
                    item.SubItems.Add(rdr("DiasLeche"))
                    item.SubItems.Add(rdr("DiasCarne"))

                    If rdr("DiasLeche") = 0 Then
                        item.SubItems.Add("")
                    Else

                        item.SubItems.Add(Format(rdr("FechaLeche"), "dd/MM/yyyy"))
                    End If
                    If rdr("DiasCarne") = 0 Then
                        item.SubItems.Add("")
                    Else

                        item.SubItems.Add(Format(rdr("FechaCarne"), "dd/MM/yyyy"))
                    End If

                    item.SubItems.Add(rdr("Num"))
                    item.SubItems.Add(rdr("Diios"))
                    item.SubItems.Add(rdr("CentroNom"))
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

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuGanado_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuGanado.Opening

    End Sub
    Private Sub mnuVerDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVerDetalle.Click
        MsgBox("sad")
    End Sub
    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvFARMACOS.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}


        ExportToExcelGrilla(lvFARMACOS, tot)
    End Sub

    Private Sub lvFARMACOS_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvFARMACOS.MouseDoubleClick
        If lvFARMACOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleTratamiento()
        End If
    End Sub

    Private Sub DetalleTratamiento()

        If lvFARMACOS.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim Cod As String = lvFARMACOS.SelectedItems.Item(0).SubItems(22).Text           'empresa

        With frmIngresoOrdenaTratamiento

            .CodTratamiento = Cod



            If lvFARMACOS.SelectedItems.Item(0).SubItems(2).Text.Contains("Lote") = True Then
                .Lote = Cod
            Else
                .Lote = ""
            End If

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()
        End With

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If lvFARMACOS.Items.Count > 0 Then


            If MsgBox("¿ DESEA ELIMINAR El SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
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
        If lvFARMACOS.SelectedItems.Item(0).SubItems(2).Text.Contains("Lote") = True Then
            Lote = "SI"
        End If
        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Lote", Lote)
        cmd.Parameters.AddWithValue("@Centro", lvFARMACOS.SelectedItems.Item(0).SubItems(24).Text)
        cmd.Parameters.AddWithValue("@Diio", lvFARMACOS.SelectedItems.Item(0).SubItems(2).Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
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
            EliminaTratamiento = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        If lvFARMACOS.SelectedItems.Item(0).SubItems(2).Text.Contains("Lote") = True Then
            Dim frmTratamientosLote As New frmTratamientosLote

            frmTratamientosLote.MdiParent = frmMAIN
            frmTratamientosLote.Lote = lvFARMACOS.SelectedItems.Item(0).SubItems(22).Text
            frmTratamientosLote.Show()
        End If
    End Sub
End Class