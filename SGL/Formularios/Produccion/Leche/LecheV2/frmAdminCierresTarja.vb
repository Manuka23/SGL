
Imports System.Data.SqlClient



Public Class frmAdminCierresTarja

    'Private Param1_CodigoEntrega As String

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


    Public Sub ConsultaCierresTarja()
        Dim cent_ As String = ""

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then
            cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spTarjas_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@FechaDesde", Mid(dtpFechaDesde.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@FechaHasta", Mid(dtpFechaHasta.Value.ToString, 1, 10))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("VBTarCentro").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(Format(rdr("VBTarFechaDesde"), "dd-MM-yyyy")) '+ " " + rdr("PalHora").ToString.Trim)
                    item.SubItems.Add(Format(rdr("VBTarFechaHasta"), "dd-MM-yyyy")) '+ " " + rdr("PalHora").ToString.Trim)
                    item.SubItems.Add(rdr("UsuNom").ToString.Trim)
                    item.SubItems.Add(Format(rdr("VBTarFechaReg"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("VBTarLibro").ToString.Trim)

                    lvGanado.Items.Add(item)
                    i = i + 1
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
    End Sub


    Private Function EliminarCierreTarja() As Boolean
        EliminarCierreTarja = False

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spTarjas_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        'Dim guia_ As String = lvGanado.SelectedItems.Item(0).SubItems(11).Text           'guia
        Dim cent_ As String = lvGanado.SelectedItems(0).SubItems(1).Text            'key
        Dim fec_ As DateTime = lvGanado.SelectedItems(0).SubItems(3).Text            'key

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Fecha", fec_)
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

            EliminarCierreTarja = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA ELIMINAR EL CIERRE DE TARJA SELECCIONADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarCierreTarja() = True Then

            ConsultaCierresTarja()

        End If
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor

        Me.Close()

        frmAdminDiios.Enabled = True
        frmAdminDiios.LlenaGrilla()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub frmAdminCierresTarja_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()


        dtpFechaDesde.Value = "01-01-" + Year(Now).ToString.Trim
        dtpFechaHasta.Value = Now
        cboCentros.SelectedIndex = 0

        ConsultaCierresTarja()
    End Sub


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        ConsultaCierresTarja()
    End Sub


    Private Sub cboCentros_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCentros.SelectedIndexChanged
        ConsultaCierresTarja()
    End Sub


    Private Sub GrabarLibro(ByVal centro As String, ByVal fechad As String, ByVal fechah As String, ByVal usur As String)

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spTarjas_Libro", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Fechad", fechad)
        cmd.Parameters.AddWithValue("@Fechah", fechah)
        cmd.Parameters.AddWithValue("@Usuario", usur)
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
        ConsultaCierresTarja()
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim validalista As Integer = 0
        Dim cent As String = ""
        Dim fechad As String = ""
        Dim fechah As String = ""
        Dim usuario As String = ""

        For i = 0 To lvGanado.Items.Count - 1
            If lvGanado.Items(i).Selected = True Then
                If lvGanado.Items(i).SubItems(7).Text = "Recibido" Then
                    MsgBox("libro ya se encuentra Recibido", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If

                validalista = 1
                cent = lvGanado.Items(i).SubItems(1).Text
                fechad = lvGanado.Items(i).SubItems(3).Text
                fechah = lvGanado.Items(i).SubItems(4).Text
                usuario = lvGanado.Items(i).SubItems(5).Text
                Exit For
            End If
        Next

        If validalista = 0 Then
            MsgBox("Debe Seleccionar un registro de la Lista", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If MsgBox("¿ DESEA MARCAR LIBRO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        GrabarLibro(cent, fechad, fechah, usuario)
    End Sub
End Class