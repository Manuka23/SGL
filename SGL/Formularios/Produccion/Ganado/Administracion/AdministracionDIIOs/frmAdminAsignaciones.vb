
Imports System.Data.SqlClient



Public Class frmAdminAsignaciones

    Private Param1_CodigoEntrega As String


    Public Sub ConsultaAsignaciones(ByVal cod_ As Integer)

        Param1_CodigoEntrega = cod_
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDiios_ListadoAsignaciones", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoEnt", cod_)
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

                    item.SubItems.Add(rdr("ADAsgnCodigo").ToString.Trim)
                    item.SubItems.Add(Format(rdr("ADAsgnFecha"), "dd-MM-yyyy")) '+ " " + rdr("PalHora").ToString.Trim)
                    item.SubItems.Add(rdr("ADAsgnTipNombre").ToString.Trim)
                    item.SubItems.Add(rdr("ADAsgnDiioNuevo").ToString.Trim)
                    item.SubItems.Add(rdr("ADAsgnFallaNombre").ToString.Trim)
                    item.SubItems.Add(IIf(rdr("ADAsgnDiioAntiguo") <> 0, rdr("ADAsgnDiioAntiguo").ToString.Trim, ""))
                    item.SubItems.Add(rdr("UsuNom").ToString.Trim)

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
    Public Sub ConsultaLibres(ByVal cod_ As Integer, ByVal cent_ As String, ByVal fecha As DateTime)
        Param1_CodigoEntrega = cod_
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDiios_ListadoLibres", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoEnt", cod_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        LvLibres.BeginUpdate()
        LvLibres.Items.Clear()
        Dim i As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(cent_)
                    item.SubItems.Add(rdr("Diio").ToString.Trim)
                    item.SubItems.Add(fecha)
                    LvLibres.Items.Add(item)
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
        LvLibres.EndUpdate()
    End Sub

    Private Function EliminarAsignacion(ByVal cod_ As Integer) As Boolean
        EliminarAsignacion = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spAdminDiios_EliminarAsignacion", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@ADAsgnCodigo", cod_)
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

            EliminarAsignacion = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim cod_ As Integer = lvGanado.SelectedItems.Item(0).SubItems(1).Text
        If cod_ = 0 Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA ELIMINAR LA ASIGNACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarAsignacion(cod_) = True Then
            ConsultaAsignaciones(Param1_CodigoEntrega)
        End If
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Me.Close()

        frmAdminDiios.Enabled = True
        frmAdminDiios.LlenaGrilla()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub frmAdminAsignaciones_(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If LvLibres.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "Nro. Registros" : tot(0, 1) = Label10.Text


        ExportToExcelGrilla(LvLibres, tot)
    End Sub
End Class