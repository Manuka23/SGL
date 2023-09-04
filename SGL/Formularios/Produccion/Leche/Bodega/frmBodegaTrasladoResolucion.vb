Imports System.Data.SqlClient
Public Class frmBodegaTrasladoResolucion
    Public paramInvId As Integer = 0
    Public paramPermResol As Boolean = False
    Private Sub frmBodegaTrasladoConfirmacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnConfirma.Enabled = False
        btnRechazar.Enabled = False
        txtObs.Enabled = False
        If paramPermResol = True Then
            btnConfirma.Enabled = True
            btnRechazar.Enabled = True
            txtObs.Enabled = True
        End If
        BuscarMovDetalle()
        lblInvId.Text = paramInvId.ToString
    End Sub
    Private Sub BuscarMovDetalle()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_ListadoMovPendRecepcionDetalle", con)
        Dim i As Integer = 0

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@InvId", paramInvId)

        lvItemsTraslado.BeginUpdate()
        lvItemsTraslado.Items.Clear()
        Try
            con.Open()
            Dim rdr As SqlDataReader = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("ItemNumber").ToString.Trim)
                    item.SubItems.Add(rdr("InvMovItmNom").ToString.Trim)
                    item.SubItems.Add(Format(rdr("InvMovItmCnt"), "#,##0.0"))
                    item.SubItems.Add(rdr("InvMovItmUM").ToString.Trim)
                    item.SubItems.Add(rdr("InvMovItmClase").ToString.Trim)
                    item.SubItems.Add(Format(rdr("InvMovItmCstUnit"), "#,##0.0"))
                    item.SubItems.Add(Format(rdr("InvMovItmCstTot"), "#,##0.0"))
                    item.SubItems.Add(Format(rdr("InvMovItmReqNro"), "#,##0.0"))
                    If rdr("InvMovItmReqNro") = 0 Then
                        Me.ItemNumReq.Width = 0
                    End If
                    lvItemsTraslado.Items.Add(item)
                    i += 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        lvItemsTraslado.EndUpdate()
    End Sub

    Private Sub BtnConfirma_Click(sender As Object, e As EventArgs) Handles btnConfirma.Click
        If MsgBox("¿DESEA ACEPTAR ESTE MOVIMIENTO?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "CONFIRMAR") = vbCancel Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_Resolucion_Acepta", con)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@InvId", paramInvId)
        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)
        cmd.Parameters.AddWithValue("@UsuarioObs", txtObs.Text.Trim)
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim ResultCod As Integer = cmd.Parameters("@ResultCod").Value
            Dim ResultMsg As String = cmd.Parameters("@ResultMsg").Value
            If ResultCod > 0 Then
                If MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Sub
            End If
            MsgBox(ResultMsg, MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FINALIZADO")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Cursor.Current = Cursors.Default
        lvItemsTraslado.Items.Clear()
        Me.Dispose()
        Me.Close()

        frmBodega.btnBuscar.PerformClick()
    End Sub

    Private Sub BtnRechazar_Click(sender As Object, e As EventArgs) Handles btnRechazar.Click
        If MsgBox("¿DESEA RECHAZAR ESTE MOVIMIENTO?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "CONFIRMAR") = vbCancel Then Exit Sub
        If txtObs.Text = "" Then
            If MsgBox("DEBE INDICAR UNA OBSERVACIÓN AL RECHAZAR.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtObs.Focus()
            Exit Sub
        End If
        If txtObs.Text.Length < 10 Then
            If MsgBox("LA OBSERVACIÓN DEBE TENER AL MENOS 10 CARACTERES.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtObs.Focus()
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBodegas_Resolucion_Rechaza", con)

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@InvId", paramInvId)
        cmd.Parameters.AddWithValue("@UsuarioCod", LoginUsuario)
        cmd.Parameters.AddWithValue("@UsuarioPC", NombrePC)
        cmd.Parameters.AddWithValue("@UsuarioObs", txtObs.Text.Trim)
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim ResultCod As Integer = cmd.Parameters("@ResultCod").Value
            Dim ResultMsg As String = cmd.Parameters("@ResultMsg").Value
            If ResultCod > 0 Then
                If MsgBox(ResultMsg, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Sub
            End If
            MsgBox("RECHAZADO CORRECTAMENTE. SE HA ENVIADO UNA NOTIFICACIÓN AL USUARIO REMITENTE.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "FINALIZADO")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Cursor.Current = Cursors.Default
        lvItemsTraslado.Items.Clear()
        Me.Dispose()
        Me.Close()

        frmBodega.btnBuscar.PerformClick()
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
        Me.Close()
    End Sub
End Class