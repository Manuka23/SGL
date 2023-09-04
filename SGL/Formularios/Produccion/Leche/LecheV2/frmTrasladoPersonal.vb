Imports System.Threading
Imports System.Data.SqlClient
Public Class frmTrasladoPersonal
    Private orden As Integer = 0
    Private Nombre As String
    Private cent_ As String
    Public Param1_Centro As String
    Public Param2_Fecha As DateTime
    Public Param3_Horario As Integer
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub frmReportesTraslados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8
        dtpFechaDesde.Value = Now
        dtpFechaHasta.Value = Now
        CboLLenaCentros()
        cboCentros.SelectedIndex = 0
    End Sub
    Private Sub lista_usuarios_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvRESUMEN1.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvRESUMEN1, e)
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
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultaTraslados()
    End Sub
    Public Sub ConsultaTraslados()
        Thread.Sleep(20)
        Nombre = txtNombre.Text
        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        Else
            cent_ = ""
        End If
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spTraslados_Reportes", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Nombre", Nombre)
        cmd.Parameters.AddWithValue("@Orden", orden)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        'lvGanado.Items.Clear()
        lvRESUMEN1.BeginUpdate()
        lvRESUMEN1.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("TFuncRut").ToString.Trim)
                    item.SubItems.Add(rdr("Nombre").ToString.Trim)
                    item.SubItems.Add(rdr("centroorigen").ToString.Trim)
                    item.SubItems.Add(rdr("centrodestino").ToString.Trim)
                    item.SubItems.Add(rdr("TFuncFecha").ToString.Trim)
                    item.SubItems.Add(rdr("TFuncUsuario").ToString.Trim)
                    item.SubItems.Add(rdr("TFuncCentroOrigen").ToString.Trim)
                    item.SubItems.Add(rdr("TFuncCentroDestino").ToString.Trim)

                    lvRESUMEN1.Items.Add(item)

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
        lvRESUMEN1.EndUpdate()
        Label10.Text = i.ToString.Trim
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        txtNombre.Text = ""
        cboCentros.SelectedIndex = 0
        dtpFechaHasta.Value = Now
        dtpFechaDesde.Value = Now
        orden = 1
        lvRESUMEN1.Items.Clear()

    End Sub
    Private Sub dtpFechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged
        If dtpFechaHasta.Value < dtpFechaDesde.Value Then
            dtpFechaHasta.Value = dtpFechaDesde.Value
        End If
        If dtpFechaHasta.Value <> dtpFechaDesde.Value Then
            orden = 1

        End If
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged


    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "Nro. Registros" : tot(0, 1) = Label10.Text


        ExportToExcelGrilla(lvRESUMEN1, tot)

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cboCentros.SelectedIndex = -1 Then Exit Sub



        frmFuncionarios.Param1_Centro = Param1_Centro
        frmFuncionarios.Param2_Fecha = Param2_Fecha
        frmFuncionarios.Param3_Horario = Param3_Horario
        frmFuncionarios.MdiParent = frmMAIN
        frmFuncionarios.Show()
        frmFuncionarios.BringToFront()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        Dim Rut As String = ""
        Dim CentroOrigen As String = ""
        Dim CentroDestino As String = ""
        Dim fechaTraslado As DateTime

        For i = 0 To lvRESUMEN1.Items.Count - 1
            If lvRESUMEN1.Items(i).Selected = True Then

                validalista = 1
                Rut = lvRESUMEN1.Items(i).SubItems(1).Text
                CentroOrigen = lvRESUMEN1.Items(i).SubItems(7).Text
                CentroDestino = lvRESUMEN1.Items(i).SubItems(8).Text
                fechaTraslado = lvRESUMEN1.Items(i).SubItems(5).Text
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un registro de la Lista", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If MsgBox("¿ Eliminar el traslado ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        EliminarTraslado(Rut, CentroOrigen, CentroDestino, fechaTraslado)
    End Sub
    Private Sub EliminarTraslado(ByVal Rut As String, ByVal CentroOrigen As String, ByVal CentroDestino As String, ByVal fechaTraslado As DateTime)

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spTraslados_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@Rut", Rut)
        cmd.Parameters.AddWithValue("@CentroOrigen", CentroOrigen)
        cmd.Parameters.AddWithValue("@CentroDestino", CentroDestino)
        cmd.Parameters.AddWithValue("@Fecha", Date.Now)
        cmd.Parameters.AddWithValue("@fechaTraslado", fechaTraslado)
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

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        ConsultaTraslados()
    End Sub
End Class