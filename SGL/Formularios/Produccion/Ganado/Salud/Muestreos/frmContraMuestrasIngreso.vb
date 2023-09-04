

Imports System.Data.SqlClient



Public Class frmContraMuestrasIngreso

    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_FechaMuestreo As DateTime
    Public Param4_TipoMuestreo As Integer
    Public Param5_DIIO As Integer


    Private Function CodigoTipoMuestreo(ByVal TipoMuestreo As String) As Integer
        Select Case TipoMuestreo
            Case "TUBERCULOSIS"
                Return 1
            Case "LEUCOSIS"
                Return 2
            Case "BRUCELOSIS"
                Return 3
            Case Else
                Return 0
        End Select
    End Function


    Private Function GrabarResultadoContraMuestra() As Boolean
        GrabarResultadoContraMuestra = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestreos_GrabarResultadoContraMuestra", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_CodigoCentro)
        cmd.Parameters.AddWithValue("@Fecha", Param3_FechaMuestreo)
        cmd.Parameters.AddWithValue("@TipoMuestreo", Param4_TipoMuestreo)
        cmd.Parameters.AddWithValue("@DIIO", Param5_DIIO)
        cmd.Parameters.AddWithValue("@FechaContraMuestra", dtpFechaResult.Value)
        cmd.Parameters.AddWithValue("@ContraMuestra", CodigoTipoMuestreo(cboTiposMuestras.Text))
        cmd.Parameters.AddWithValue("@ResContraMuestra", cboResultadoMuestra.SelectedIndex + 1)
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

            GrabarResultadoContraMuestra = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function



    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If cboTiposMuestras.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO DE MUESTRA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboTiposMuestras.Focus()
            Exit Function
        End If

        If cboResultadoMuestra.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN RESULTADO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboResultadoMuestra.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub frmContraMuestrasIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height + 50) / 2)
        Me.Left = Me.Left + (frmMAIN.pnlMenu.Width / 2)

        dtpFechaResult.Value = Now
        cboResultadoMuestra.SelectedIndex = -1
    End Sub



    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarResultadoContraMuestra() = True Then
            frmContraMuestras.BuscarDetalle()
            FrmMuestreosIngreso.BuscarDetalle()
            Me.Close()
        End If
    End Sub
End Class