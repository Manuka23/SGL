﻿

Imports System.Data.SqlClient


Public Class frmInseminadoresIngreso

    Public Param1_Modo As Integer   '1=llamado desde inseminadores / 2=llamado desde ingreso de dosis
    Public Out1_ValRet As Int16     '1=cierra con "grabar" (Param1_Modo=2) / 2=cierra con boton "cerrar"


    Private Sub CboLlenaVS()
        cboVigente.Items.Clear()
        cboVigente.Items.Add("SI")
        cboVigente.Items.Add("NO")
        ''
        cboExterno.Items.Clear()
        cboExterno.Items.Add("SI")
        cboExterno.Items.Add("NO")
    End Sub



    Private Function GrabarInseminador() As Boolean
        GrabarInseminador = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spInseminadores_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@InsemCod", txtCodigo.Text.Trim)
        cmd.Parameters.AddWithValue("@InsemNom", txtNombre.Text.Trim)
        cmd.Parameters.AddWithValue("@InsemVigente", IIf(cboVigente.Text = "SI", 1, 0))
        cmd.Parameters.AddWithValue("@InsemExterno", IIf(cboExterno.Text = "SI", 1, 0))
        cmd.Parameters.AddWithValue("@InsemObservs", txtObservs.Text.Trim)
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

            GrabarInseminador = True
            'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

            'MsgBox(mret)


            'ValidarUsuario = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function





    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If txtCodigo.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN CODIGO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtCodigo.Focus()
            Exit Function
        End If

        If txtNombre.Text.Trim = "" Then
            If MsgBox("DEBE INGRESAR UN NOMBRE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtNombre.Focus()
            Exit Function
        End If

        If cboVigente.SelectedIndex = -1 Then
            If MsgBox("DEBE INDICAR SI EL INSEMINADOR ESTÁ VIGENTE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboVigente.Focus()
            Exit Function
        End If

        If cboExterno.SelectedIndex = -1 Then
            If MsgBox("DEBE INDICAR SI EL INSEMINADOR ES EXTERNO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboExterno.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function




    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
        If ValidacionesLocales() = False Then Exit Sub

        'CONFIRMAR
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If GrabarInseminador() = True Then
            'If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            'End If

            txtCodigo.Text = ""
            txtNombre.Text = ""
            cboVigente.SelectedIndex = -1
            cboExterno.SelectedIndex = -1

            txtCodigo.Focus()

            'si es llamado desde el ingreso de dosis de semen, entonces salimos
            If Param1_Modo = 2 Then
                Out1_ValRet = 1
                Cerrar()
            End If
        End If
    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Out1_ValRet = 2
        Cerrar()
    End Sub


    Private Sub frmInseminadoresIngreso_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        txtCodigo.Focus()
    End Sub


    Private Sub frmInseminadoresIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLlenaVS()
    End Sub

End Class