




Imports System.Data.SqlClient


Public Class frmVBTarja

    Public Param1_Centro As String
    Public Param2_TieneTarja As Boolean
    Public Param3_FUltTarja As DateTime



    Private Sub ConsultaUltimaTarja()
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spTarjas_ConsultaUltima", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_Centro)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Param2_TieneTarja = False

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If Not IsDBNull(rdr("FechaUltCierreTarja")) Then
                        Param2_TieneTarja = True
                        Param3_FUltTarja = rdr("FechaUltCierreTarja")
                    End If
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Function ConfirmaCierreTarja() As Boolean
        ConfirmaCierreTarja = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spTarjas_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        ''
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_Centro)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        ''
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

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            ConfirmaCierreTarja = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.Default
    End Function



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnConfirmar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmar.Click
        If (dtpFechaHasta.Value <= dtpFechaDesde.Value) Or (dtpFechaDesde.Value.Month = dtpFechaHasta.Value.Month) Then
            If MsgBox("FECHAS INCORRECTAS", MsgBoxStyle.Question + MsgBoxStyle.OkOnly, "CONFIRMACION") <> MsgBoxResult.Yes Then
            End If
            Exit Sub
        End If

        If MsgBox("¿ DESEA CONFIRMAR EL CIERRE -- DE LA TARJA -- EN EL PERIODO ESPECIFICADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If ConfirmaCierreTarja() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If

            Cursor.Current = Cursors.WaitCursor
            Me.Close()
            Cursor.Current = Cursors.Default
        End If
    End Sub


    Private Sub frmVBTarja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = frmMAIN
        'Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        'Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8
        ConsultaUltimaTarja()

        If Not Param2_TieneTarja Then
            dtpFechaDesde.Value = "16-" + IIf(Now.Month = 1, "12", (Now.Month - 1).ToString.PadLeft(2, "0")) + "-" + IIf(Now.Month = 1, (Now.Year - 1).ToString, Now.Year.ToString)
            dtpFechaHasta.Value = "15-" + (Now.Month).ToString.PadLeft(2, "0") + "-" + Now.Year.ToString
        Else
            dtpFechaDesde.Value = Param3_FUltTarja.AddDays(1)
            dtpFechaHasta.Value = "15-" + IIf(dtpFechaDesde.Value.Month = 12, "01", (Param3_FUltTarja.Month + 1).ToString.PadLeft(2, "0")) + "-" + IIf(dtpFechaDesde.Value.Month = 12, (dtpFechaDesde.Value.Year + 1).ToString, dtpFechaDesde.Value.Year.ToString)
            'dtpFechaHasta.Value = "15-" + IIf(Now.Month = 12, "01", (Param3_FUltTarja.Month + 1).ToString.PadLeft(2, "0")) + "-" + IIf(Now.Month = 12, (Now.Year + 1).ToString, Now.Year.ToString)
        End If

    End Sub
End Class