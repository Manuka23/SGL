Imports System.Data.SqlClient
Public Class frmPabcoLotes
    Private Sub frmPabcoLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        PabcoBuscarLotes()
    End Sub
    Public Sub PabcoBuscarLotes()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPabco_Lotes", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Centro As Integer = cboCentros.SelectedValue

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)

        'lvGanado.Items.Clear()
        lvLoteo.BeginUpdate()
        lvLoteo.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("CentroCod"))
                    item.SubItems.Add(rdr("CentroNom"))
                    item.SubItems.Add(rdr("Lote_Diio"))
                    item.SubItems.Add(Format(rdr("FechaTratamiento"), "dd/MM/yyyy"))
                    item.SubItems.Add(rdr("PatologiaCod"))
                    item.SubItems.Add(rdr("PatologiaNom"))
                    item.SubItems.Add(rdr("MedicamentoCod"))
                    item.SubItems.Add(rdr("MedicamentoNom"))
                    item.SubItems.Add(rdr("Cantidad"))
                    item.SubItems.Add(rdr("Estado"))
                    item.SubItems.Add(Format(rdr("ResguardoLeche"), "dd/MM/yyyy"))
                    item.SubItems.Add(Format(rdr("ResguadoCarne"), "dd/MM/yyyy"))

                    lvLoteo.Items.Add(item)
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        lvLoteo.EndUpdate()
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cboCentros.Items.Clear()

        Dim CodigoCentro As List(Of Centros) = New List(Of Centros)
        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            CodigoCentro.Add(New Centros With {
                             .Codigo1 = General.CentrosUsuario.Codigo(i),
                             .Nombre1 = General.CentrosUsuario.Nombre(i)})
        Next
        cboCentros.DataSource = CodigoCentro
        cboCentros.ValueMember = "Codigo1"
        cboCentros.DisplayMember = "Nombre1"
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub lvLoteo_DoubleClick(sender As Object, e As EventArgs) Handles lvLoteo.DoubleClick
        If lvLoteo.SelectedItems.Count > 0 Then
            Dim frmTratamientosLote As New frmTratamientosLote

            frmTratamientosLote.MdiParent = frmMAIN
            frmTratamientosLote.Lote = lvLoteo.SelectedItems.Item(0).SubItems(3).Text
            frmTratamientosLote.CodPatologia = lvLoteo.SelectedItems.Item(0).SubItems(5).Text
            frmTratamientosLote.CodMedicamento = lvLoteo.SelectedItems.Item(0).SubItems(7).Text
            frmTratamientosLote.CentroCod = lvLoteo.SelectedItems.Item(0).SubItems(1).Text
            frmTratamientosLote.CentroNom = lvLoteo.SelectedItems.Item(0).SubItems(2).Text
            frmTratamientosLote.Show()
        End If
    End Sub

    Private Sub btnCierreLote_Click(sender As Object, e As EventArgs) Handles btnCierreLote.Click
        If lvLoteo.SelectedItems.Count = 0 Then
            MsgBox("DEBE SELECCIONAR UN LOTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ADVERTENCIA")
            Exit Sub
        End If

        If MsgBox("ESTA A PUNTO DE GENERAR UN CIERRE AL LOTE SELECCIONADO, UNA VEZ HECHO NO SE PODRA REALIZAR NINGUN TIPO DE MODIFICACION, ¿DESEA CONTINUAR?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        PabcoLoteCierre()
    End Sub
    Public Sub PabcoLoteCierre()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPabcoLotes_Cierre", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", lvLoteo.SelectedItems.Item(0).SubItems(1).Text)
        cmd.Parameters.AddWithValue("@Lote", lvLoteo.SelectedItems.Item(0).SubItems(3).Text)
        cmd.Parameters.AddWithValue("@CodPatologia", lvLoteo.SelectedItems.Item(0).SubItems(5).Text)
        cmd.Parameters.AddWithValue("@CodMedicamento", lvLoteo.SelectedItems.Item(0).SubItems(7).Text)
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

    Public Sub btnLiberarLote_Click(sender As Object, e As EventArgs) Handles btnLiberarLote.Click
        If lvLoteo.SelectedItems.Count = 0 Then
            MsgBox("DEBE SELECCIONAR UN LOTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ACTUALIZACION")
            Exit Sub
        End If

        Dim Liberacion As Integer = 0

        With frmPabcoLiberarLeche

            .MdiParent = frmMAIN
            .Show()
            .BringToFront()

            .lblCentro.Text = lvLoteo.SelectedItems.Item(0).SubItems(2).Text
            .lblDiioLote.Text = lvLoteo.SelectedItems.Item(0).SubItems(3).Text
            .lblCodPat.Text = lvLoteo.SelectedItems.Item(0).SubItems(5).Text
            .lblNomPatologia.Text = lvLoteo.SelectedItems.Item(0).SubItems(6).Text
            .lblCodMed.Text = lvLoteo.SelectedItems.Item(0).SubItems(7).Text
            .lblNomMedicamento.Text = lvLoteo.SelectedItems.Item(0).SubItems(8).Text
            .lblFecLeche.Text = lvLoteo.SelectedItems.Item(0).SubItems(11).Text
            .lblFecCarne.Text = lvLoteo.SelectedItems.Item(0).SubItems(12).Text
            .TipoLiberacion = Liberacion
            .lblDiio.Visible = False

        End With
    End Sub
End Class