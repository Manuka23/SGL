Imports System.Data.SqlClient
Public Class frmMenu_perfiles_nuevo
    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False
        If cboPerfiles.SelectedIndex = 0 Then
            If MsgBox("DEBE SELECCIONAR UN PERFIL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cboPerfiles.Focus()
            Exit Function
        End If

        If CboMenu.SelectedIndex = 0 Then
            If MsgBox("DEBE SELECCIONAR UN MENU", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            CboMenu.Focus()
            Exit Function
        End If
        ValidacionesLocales = True
    End Function
    Private Function guardar()
        guardar = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_MenuPerfiles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim opcion As String = "i"
        Dim CodPerf As Integer
        Dim NomPerf As String = ""
        Dim DesMnu As String = ""
        Dim CodMnu As Integer
        Dim Graba As String = "1"
        Dim Modifica As String = "1"
        Dim Elimina As String = "1"
        Dim FecCre As Date = Now()
        Dim ResCre As String = General.LoginUsuario
        Dim order As String = ""


        'codusuario = cboUsuariosIvs.SelectedItem
        CodPerf = General.Perfiles.Codigo(cboPerfiles.SelectedIndex - 1)
        CodMnu = General.menu_principal.CodMnu(CboMenu.SelectedIndex)

        ''
        cmd.Parameters.AddWithValue("@op", opcion)
        cmd.Parameters.AddWithValue("@CodPerf", CodPerf)
        cmd.Parameters.AddWithValue("@NomPerf", NomPerf)
        cmd.Parameters.AddWithValue("@CodMnu", CodMnu)
        cmd.Parameters.AddWithValue("@DesMnu", DesMnu)
        cmd.Parameters.AddWithValue("@Graba", Graba)
        cmd.Parameters.AddWithValue("@Modifica", Modifica)
        cmd.Parameters.AddWithValue("@Elimina", Elimina)
        cmd.Parameters.AddWithValue("@FecCre", FecCre)
        cmd.Parameters.AddWithValue("@ResCre", rescre)
        ' cmd.Parameters.AddWithValue("@GrabaDetalle", grabdet_)
        cmd.Parameters.AddWithValue("order", order)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()



            guardar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
    Private Sub cbollenaPerfiles()
        General.Perfiles.Cargar()
        ' MsgBox(General.Usuarios_ivs.NroRegistros)
        If General.Perfiles.NroRegistros = 0 Then Exit Sub

        cboPerfiles.Items.Clear()
        cboPerfiles.Items.Add("-Seleccione-")

        Dim i As Integer

        For i = 0 To General.Perfiles.NroRegistros - 1
            cboPerfiles.Items.Add(General.Perfiles.Nombre(i))
        Next
    End Sub

    Private Sub cbollenamenus()
        General.menu_principal.carga_combo_segundario()
        ' MsgBox(General.Usuarios_ivs.NroRegistros)
        If General.menu_principal.NroRegistros = 0 Then Exit Sub

        CboMenu.Items.Clear()
        ' CboMenu.Items.Add("-Seleccione-")

        Dim i As Integer

        For i = 0 To General.menu_principal.NroRegistros - 1
            CboMenu.Items.Add(General.menu_principal.DesMnu(i))
        Next
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 140
        Me.Left = 20
        frmMenu_perfiles.Enabled = False
        cbollenaPerfiles()
        cbollenamenus()
        cboPerfiles.SelectedIndex = 0
        CboMenu.SelectedIndex = 0

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmMenu_perfiles.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(False) = False Then Exit Sub


        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If guardar() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                frmMenu_perfiles.Close()
                frmMenu_perfiles.Show()
                Me.Close()
            End If

        End If
    End Sub
End Class