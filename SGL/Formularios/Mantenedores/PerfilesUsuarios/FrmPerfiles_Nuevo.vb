Imports System.Data.SqlClient
Public Class frmPerfiles_Nuevo


    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False
        If txtcodperfil.Text = "" Then
            If MsgBox("DEBE DIGITAR UN CODIGO DE PERFIL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtcodperfil.Focus()
            Exit Function
        End If

        If txtnomperfil.Text = "" Then
            If MsgBox("DEBE DIGITAR UN NOMBRE DE PERFIL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtnomperfil.Focus()
            Exit Function
        End If
        If Not IsNumeric(txtcodperfil.Text) Then
            If MsgBox("INGRESE SOLO VALORES NUMERICOS PARA CODIGO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtcodperfil.Focus()
            Exit Function
        End If
        ValidacionesLocales = True
    End Function

    Private Function guardarperil()
        guardarperil = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_Perfiles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim opcion As String = "i"
        Dim codperfil As Integer
        Dim nomperfil As String = ""
        Dim FiltraCentros As Integer = 0
        Dim order As String = ""

        'codusuario = cboUsuariosIvs.SelectedItem
        codperfil = txtcodperfil.Text
        nomperfil = txtnomperfil.Text

        ''
        cmd.Parameters.AddWithValue("@op", opcion)
        cmd.Parameters.AddWithValue("@CodPerf", codperfil)
        cmd.Parameters.AddWithValue("@NomPerf", nomperfil)
        cmd.Parameters.AddWithValue("@FiltraCentros", FiltraCentros)
        cmd.Parameters.AddWithValue("order", order)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

           

            guardarperil = True
            
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
    Private Sub frmPerfiles_Nuevo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 115
        Me.Left = 10
        FrmPerfiles.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FrmPerfiles.Enabled = True
        Me.Close()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(False) = False Then Exit Sub


        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If guardarperil() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                FrmPerfiles.Close()
                FrmPerfiles.Show()
                Me.Close()
            End If

        End If
    End Sub

End Class