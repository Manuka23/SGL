Imports System.Data.SqlClient
Imports System.Threading
Public Class frmMedicamentos
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Private Sub frmMedicamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.Patologias.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLlena()
        CboLLenaPatologias()
        cboPatologias.SelectedIndex = 0
        cboVigente.SelectedIndex = 0
        lvFARMACOS.Items.Clear()

        ConsultaMedicamentos()
    End Sub
    Private Sub CboLlena()

        cboVigente.Items.Clear()
        cboVigente.Items.Add("--Todos--")
        cboVigente.Items.Add("SI")
        cboVigente.Items.Add("NO")

        cboVigente.SelectedIndex = 0
    End Sub
    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvFARMACOS.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvFARMACOS, e)
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
    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvFARMACOS.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}


        ExportToExcelGrilla(lvFARMACOS, tot)
    End Sub
    Private Sub lvFARMACOS_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvFARMACOS.MouseDoubleClick
        If lvFARMACOS.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            ModificarMedicamento()
        End If
    End Sub
    Private Sub ModificarMedicamento()
        If lvFARMACOS.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim RegSag As String = lvFARMACOS.SelectedItems.Item(0).SubItems(2).Text
        Dim Nombre As String = lvFARMACOS.SelectedItems.Item(0).SubItems(1).Text
        Dim ResLeche As String = lvFARMACOS.SelectedItems.Item(0).SubItems(4).Text
        Dim ResCarne As String = lvFARMACOS.SelectedItems.Item(0).SubItems(5).Text
        Dim Observacion As String = lvFARMACOS.SelectedItems.Item(0).SubItems(9).Text
        Dim Duracion As String = lvFARMACOS.SelectedItems.Item(0).SubItems(8).Text
        Dim DiasDuracion As String = lvFARMACOS.SelectedItems.Item(0).SubItems(3).Text
        Dim Dosis As String = lvFARMACOS.SelectedItems.Item(0).SubItems(7).Text
        Dim Lactancia As String = lvFARMACOS.SelectedItems.Item(0).SubItems(6).Text
        Dim Vigente As String = lvFARMACOS.SelectedItems.Item(0).SubItems(10).Text
        Dim Preventivo As String = lvFARMACOS.SelectedItems.Item(0).SubItems(12).Text
        Dim CodGP As String = lvFARMACOS.SelectedItems.Item(0).SubItems(13).Text

        Dim med As New frmMedicamentosIngreso


        med.MdiParent = frmMAIN
        med.Label11.Text = "Modificar Medicamento"
        med.txtsag.Text = RegSag
        If Vigente = "Si" Then
            med.vigente = 1
        Else
            med.vigente = 2
        End If
        If Lactancia = "Si" Then
            med.lactancia = 1
        Else
            med.lactancia = 2
        End If
        If Preventivo = "Si" Then
            med.Preventivo = 1
        Else
            med.Preventivo = 2
        End If
        med.txtnombre.Text = Nombre
        med.txtdosis.Text = Dosis
        med.txtduracion.Text = Duracion
        med.txtleche.Text = ResLeche
        med.txtcarne.Text = ResCarne
        med.txtObservs.Text = Observacion
        med.txtDiasduracion.Text = DiasDuracion
        med.txtItemCodigo.Text = CodGP


        med.txtItemCodigo.Enabled = False
        med.txtsag.Enabled = False

        med.Show()

        Cursor.Current = Cursors.Default
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmMedicamentosIngreso.MdiParent = frmMAIN
        frmMedicamentosIngreso.Show()
        frmMedicamentosIngreso.BringToFront()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvFARMACOS.Items.Clear()

        ConsultaMedicamentos()
    End Sub
    Public Sub ConsultaMedicamentos()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_ListaMedicamentos", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        If cboPatologias.SelectedIndex = 0 Then
            cmd.Parameters.AddWithValue("@Patologia", "")
        Else
            cmd.Parameters.AddWithValue("@Patologia", General.Patologias.Codigo(cboPatologias.SelectedIndex - 1))
        End If


        cmd.Parameters.AddWithValue("@Vigente", cboVigente.SelectedIndex)
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
                    item.SubItems.Add(rdr("MedNombre").ToString)
                    item.SubItems.Add(rdr("MedRegSag").ToString)
                    item.SubItems.Add(rdr("TratDiasDuracion").ToString)
                    item.SubItems.Add(rdr("TratResguardoLeche").ToString)
                    item.SubItems.Add(rdr("TratResguardoCarne").ToString)
                    If rdr("MedVacasLactancia") = 1 Then
                        item.SubItems.Add("Si")
                    Else
                        item.SubItems.Add("No")
                    End If

                    item.SubItems.Add(rdr("TratDosis").ToString)
                    item.SubItems.Add(rdr("TratDuracionTrat").ToString)
                    item.SubItems.Add(rdr("TratObservacion").ToString)
                    If rdr("MedVigente") = 1 Then
                        item.SubItems.Add("Si")
                    Else
                        item.SubItems.Add("No")
                    End If
                    item.SubItems.Add(rdr("MedCodigo").ToString)
                    item.SubItems.Add(rdr("preventivo").ToString)
                    item.SubItems.Add(rdr("MedCodGP").ToString)
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
        Label48.Text = i.ToString.Trim
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If lvFARMACOS.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR EL MEDICAMENTO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarFarmaco() = True Then
            lvFARMACOS.Items.Clear()

            ConsultaMedicamentos()
        End If
    End Sub
    Private Function EliminarFarmaco() As Boolean
        EliminarFarmaco = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_EliminarMedicamento", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim med As String = lvFARMACOS.SelectedItems(0).SubItems(11).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@MedCodigo", med)
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

            EliminarFarmaco = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function



    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarFiltro_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltro.Click
        lvFARMACOS.Items.Clear()
        cboPatologias.SelectedIndex = 0
        cboVigente.SelectedIndex = 0
    End Sub
End Class