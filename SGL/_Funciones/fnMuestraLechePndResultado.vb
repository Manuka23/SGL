Imports System.Data.SqlClient
Public Class fnMuestraLechePndResultado

    Public Function Grabar(ByVal lvganado As ListView) As Boolean
        Grabar = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_GrabarPndResultado", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos


        Dim DetalleItems As DataTable = ToDataTableGrabar(lvganado)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@TablaMuestras", DetalleItems)

        cmd.Parameters.AddWithValue("@VacGndEquipo", NombrePC)
        cmd.Parameters.AddWithValue("@VacGndUsuario", LoginUsuario)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@CodEnvio", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@CodEnvio").Direction = ParameterDirection.Output

        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            Dim CodigoEnvio = cmd.Parameters("@CodEnvio").Value
            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                Cursor.Current = Cursors.Default
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error DE VALIDACION") = vbOK Then
                End If
                Exit Function

            End If
            If vret = 0 Then
                If MsgBox(mret, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Validacion") = vbOK Then
                    frmMuestraLecheEnvio.CodEnvio = CodigoEnvio
                    MsgBox("DATOS GRABADOS OK", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    frmMuestraLecheEnvio.btnFinalizar.Enabled = False
                    frmMuestraLecheEnvio.BtnTxt.Enabled = True
                    frmMuestraLecheEnvio.btnImprime.Enabled = True
                End If
            End If
            Grabar = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
    End Function

    Public Function ToDataTableGrabar(ByVal lvganado As ListView) As DataTable
        ToDataTableGrabar = Nothing

        Dim table As DataTable = New DataTable("MuestraLecheEnvio")

        table.Columns.Add("MuesEstanque", System.Type.GetType("System.String"))
        table.Columns.Add("MuesCodLector", System.Type.GetType("System.String"))
        table.Columns.Add("MuesFecha", System.Type.GetType("System.String"))
        table.Columns.Add("MuesHorario", System.Type.GetType("System.String"))
        table.Columns.Add("MuesTipoMu", System.Type.GetType("System.String"))


        Dim n As Integer
        n = lvganado.Items.Count
        For i = 0 To n - 1
            table.Rows.Add(lvganado.Items(i).SubItems(8).Text, lvganado.Items(i).SubItems(7).Text,
                           lvganado.Items(i).SubItems(3).Text,
                           lvganado.Items(i).SubItems(6).Text,
                           lvganado.Items(i).SubItems(9).Text)
        Next
        ToDataTableGrabar = table

    End Function
    Public Function GrabarPndEnvio(ByVal dgvRetiroLeche As DataGridView, ByVal NomProvee As String, ByVal CodProvee As String, ByVal Horario As String, ByVal Fecha As Date, ByVal Muestreo As String, ByVal TipoMuestra As String) As Boolean
        GrabarPndEnvio = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_GrabarPndEnvio", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos


        Dim DetalleItems As DataTable = ToDataTableGrabarPndEnvio(dgvRetiroLeche)

        cmd.Parameters.AddWithValue("@TablaMuestras", DetalleItems)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@MuesFecha", Fecha)
        cmd.Parameters.AddWithValue("@MuesCodProveedores", CodProvee)
        cmd.Parameters.AddWithValue("@MuesNomProveedores", NomProvee)
        cmd.Parameters.AddWithValue("@MuesHorario", Horario)
        cmd.Parameters.AddWithValue("@Muestreo", Muestreo)
        cmd.Parameters.AddWithValue("@TipoMuestra", TipoMuestra)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                Cursor.Current = Cursors.Default
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error DE VALIDACION") = vbOK Then
                End If
                Exit Function

            End If
            If vret = 0 Then
            End If
            GrabarPndEnvio = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
    End Function
    Public Function ToDataTableGrabarPndEnvio(ByVal dgvRetiroLeche As DataGridView) As DataTable
        ToDataTableGrabarPndEnvio = Nothing

        Dim table As DataTable = New DataTable("MuestraLechePndEnvio")

        table.Columns.Add("MuesEstanque", System.Type.GetType("System.String"))
        table.Columns.Add("MuesCentro", System.Type.GetType("System.String"))
        table.Columns.Add("MuesCodLector", System.Type.GetType("System.String"))


        Dim n As Integer = dgvRetiroLeche.RowCount
        For i = 0 To n - 1
            table.Rows.Add(dgvRetiroLeche.Rows(i).Cells(2).Value, dgvRetiroLeche.Rows(i).Cells(1).Value, dgvRetiroLeche.Rows(i).Cells(0).Value)
        Next
        ToDataTableGrabarPndEnvio = table

    End Function
End Class
