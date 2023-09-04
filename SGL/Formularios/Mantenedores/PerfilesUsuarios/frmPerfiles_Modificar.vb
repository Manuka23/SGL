
Imports System.Data.SqlClient
Public Class frmPerfiles_modificar

    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False


        If txtnomperfil.Text = "" Then
            If MsgBox("DEBE DIGITAR UN NOMBRE DE PERFIL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtnomperfil.Focus()
            Exit Function
        End If
        ValidacionesLocales = True
    End Function
    Private Function modificarperfil()
        modificarperfil = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_Perfiles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim opcion As String = "u"
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



            modificarperfil = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        FrmPerfiles.Enabled = True
        Me.Close()
    End Sub

    Private Sub frmPerfiles_modificar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 115
        Me.Left = 15
        FrmPerfiles.Enabled = False
        txtcodperfil.Text = FrmPerfiles.lv_lista_perfiles.SelectedItems.Item(0).SubItems(1).Text

        General.Perfiles.Cargar()
        'CboLLenaPerfiles()
        ' CboPerfil.SelectedItem = -1
        ' Cbo.SelectedIndex = 0
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnomperfil.TextChanged

    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If ValidacionesLocales(False) = False Then Exit Sub


        If MsgBox("¿ DESEA MODIFICAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If modificarperfil() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                FrmPerfiles.Close()
                FrmPerfiles.Show()
                Me.Close()
            End If

        End If
    End Sub
End Class