Imports System.Data.SqlClient
Public Class frmMenu_principal_modifica
    Public combotercero As String()
    Public combonomtercero As String()
    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False
        If txtcodigo.Text = "" Then
            If MsgBox("DEBE DIGITAR UN CODIGO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtcodigo.Focus()
            Exit Function
        End If
        If txtnombre.Text = "" Then
            If MsgBox("DEBE DIGITAR UN NOMBRE", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            txtnombre.Focus()
            Exit Function
        End If

        ValidacionesLocales = True
    End Function
    Private Function modificar()
        modificar = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_Menu", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim opcion As String = "u"
        Dim CodMnu As String = txtcodigo.Text
        Dim DesMnu As String = txtnombre.Text
        Dim DesMnuIngles As String = txtnombreIngles.Text
        Dim NodoPrimario As String = txtcodigo.Text
        Dim NodoSecundario As String = General.menu_principal.NodoPrimario(cboNodoSec.SelectedIndex)
        Dim NodoTercero As String = combotercero(CboNodoTer.SelectedIndex)
        Dim FecCre As Date = Now()

        Dim rescre As String = General.LoginUsuario
        Dim order As String = ""

        'cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@op", opcion)
        cmd.Parameters.AddWithValue("@CodMnu", CodMnu)
        cmd.Parameters.AddWithValue("@DesMnu", DesMnu)
        cmd.Parameters.AddWithValue("@DesMnuIngles", DesMnuIngles)
        cmd.Parameters.AddWithValue("@NodoPrimario", NodoPrimario)
        cmd.Parameters.AddWithValue("@NodoSecundario", NodoSecundario)
        cmd.Parameters.AddWithValue("@NodoTercero", NodoTercero)
        cmd.Parameters.AddWithValue("@FecCre", FecCre)
        cmd.Parameters.AddWithValue("@ResCre", rescre)
        cmd.Parameters.AddWithValue("@order", order)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()


            modificar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function
    Private Sub carga_combo_secundario()
        General.menu_principal.carga_combo_segundario()
        If General.menu_principal.NroRegistros = 0 Then Exit Sub

        cboNodoSec.Items.Clear()

        Dim i As Integer

        For i = 0 To General.menu_principal.NroRegistros - 1
            cboNodoSec.Items.Add(General.menu_principal.DesMnu(i))

        Next
        cboNodoSec.SelectedIndex = 0
    End Sub
    Public Sub carga_combo_tercero()

        CboNodoTer.Items.Clear()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_Menu", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        Dim opcion As String = "st"
        Dim cbosec As Integer

        cbosec = General.menu_principal.NodoPrimario(cboNodoSec.SelectedIndex)


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@op", opcion)
        cmd.Parameters.AddWithValue("@CodMnu", "")
        cmd.Parameters.AddWithValue("@DesMnu", "")
        cmd.Parameters.AddWithValue("@DesMnuIngles", "")
        cmd.Parameters.AddWithValue("@NodoPrimario", "")
        cmd.Parameters.AddWithValue("@NodoSecundario", cbosec)
        cmd.Parameters.AddWithValue("@NodoTercero", "")
        cmd.Parameters.AddWithValue("@FecCre", "")
        cmd.Parameters.AddWithValue("@ResCre", "")
        cmd.Parameters.AddWithValue("@order", "")

        i = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                ReDim Preserve combotercero(i)
                ReDim Preserve combonomtercero(i)
                combotercero(i) = 0
                combonomtercero(i) = "-Ninguno-"
                CboNodoTer.Items.Add(combonomtercero(i))
                i += 1
                While rdr.Read()
                    ReDim Preserve combotercero(i)
                    ReDim Preserve combonomtercero(i)


                    combotercero(i) = rdr("CodMnu").ToString.Trim
                    combonomtercero(i) = rdr("DesMnu").ToString.Trim
                    CboNodoTer.Items.Add(combonomtercero(i))
                    i += 1
                End While


                rdr.Close()
                cmd.Dispose()
            Catch ex As Exception

                MsgBox("ERROR: " + ex.Message)
            End Try
        Finally
            'cerramos coneccion, al finalizar
            con.Close()
        End Try
        CboNodoTer.SelectedIndex = 0
    End Sub

    Private Sub frmMenu_principal_modifica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 115
        Me.Left = 15
        FrmMenu_principal.Enabled = False
        txtcodigo.Text = FrmMenu_principal.lv_lista_menu.SelectedItems.Item(0).SubItems(1).Text
        txtcodigo.Enabled = False
        txtnombre.Text = FrmMenu_principal.lv_lista_menu.SelectedItems.Item(0).SubItems(2).Text
        carga_combo_secundario()
        cboNodoSec.SelectedIndex = 0
        CboNodoTer.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FrmMenu_principal.Enabled = True
        Me.Close()
    End Sub

    Private Sub cboNodoSec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNodoSec.SelectedIndexChanged
        CboNodoTer.Enabled = True
        carga_combo_tercero()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidacionesLocales(False) = False Then Exit Sub

        If MsgBox("¿ DESEA MODIFICAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If modificar() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                FrmMenu_principal.Close()
                FrmMenu_principal.Show()
                Me.Close()
            End If

        End If

    End Sub
End Class