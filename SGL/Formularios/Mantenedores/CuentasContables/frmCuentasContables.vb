
Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient

Public Class frmCuentasContables


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ConsultaCuentas()
    End Sub

    Public Sub ConsultaCuentas()
        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPFinanciero_Consulta_Cuentas_ItemsGasto", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
        cmd.Parameters.AddWithValue("@ClaseCod", General.ClasesContables.ClaseCod(cboClases.SelectedIndex))
        cmd.Parameters.AddWithValue("@CuentaCod", General.CuentasContablesMan.CuentaCod(cboCuentas.SelectedIndex))
        cmd.Parameters.AddWithValue("@ItemGastoCod", General.ItemsGastoContables.ItemGastoCod(cboItemGasto.SelectedIndex))

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((i + 1).ToString.Trim)             'primera columna, correlativo
                    item.SubItems.Add(rdr("aaAcctClassID").ToString.Trim)
                    item.SubItems.Add(rdr("aaAccountClass").ToString.Trim)
                    item.SubItems.Add(rdr("CuentaCod").ToString.Trim)
                    item.SubItems.Add(rdr("CuentaNom").ToString.Trim)
                    item.SubItems.Add(rdr("ItemGastoCod").ToString.Trim)
                    item.SubItems.Add(rdr("ItemGastoNom").ToString.Trim)
                    item.SubItems.Add(rdr("Vigente").ToString.Trim)
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

    Private Sub frmCuentasContables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        cargar()

    End Sub
    Public Sub cargar()
        General.ClasesContables.Cargar(0)
        LlenaComboClases()
        cboItemGasto.SelectedIndex = 0
        ConsultaCuentas()

    End Sub

    Private Sub LlenaComboClases()
        cboClases.Items.Clear()

        For i = 0 To General.ClasesContables.NroRegistros - 1
            cboClases.Items.Add(General.ClasesContables.ClaseNom(i))
        Next
        cboClases.SelectedIndex = 0
    End Sub

    Private Sub cboClases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClases.SelectedIndexChanged
        General.CuentasContablesMan.Cargar(General.ClasesContables.ClaseCod(cboClases.SelectedIndex), 0)
        LlenaComboCuentas()
    End Sub
    Private Sub LlenaComboCuentas()
        cboCuentas.Items.Clear()

        For i = 0 To General.CuentasContablesMan.NroRegistros - 1
            cboCuentas.Items.Add(General.CuentasContablesMan.CuentaNom(i))
        Next
        cboCuentas.SelectedIndex = 0
    End Sub

    Private Sub cboItemGasto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemGasto.SelectedIndexChanged

    End Sub

    Private Sub cboCuentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCuentas.SelectedIndexChanged
        General.ItemsGastoContables.Cargar(General.CuentasContablesMan.CuentaCod(cboCuentas.SelectedIndex), 0)
        LlenaComboitems()
        If cboCuentas.SelectedIndex = 0 Then
            cboItemGasto.Enabled = False
            cboItemGasto.SelectedIndex = 0
        Else
            cboItemGasto.Enabled = True
        End If
    End Sub
    Private Sub LlenaComboitems()
        cboItemGasto.Items.Clear()

        For i = 0 To General.ItemsGastoContables.NroRegistros - 1
            cboItemGasto.Items.Add(General.ItemsGastoContables.ItemGastoNom(i))
        Next
        cboItemGasto.SelectedIndex = 0
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}


        ExportToExcelGrilla(lvGanado, tot)
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lvGanado.Items.Count - 1
            If lvGanado.Items(i).Selected = True Then
                If lvGanado.Items(i).SubItems(7).Text = "NO" Then
                    MsgBox("El registro ya se encuentra desactivado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe seleccionar una cuenta")
            Exit Sub
        End If

        If MsgBox("¿ DESEA DESACTIVAR EL REGISTRO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If Desactivar() = True Then
            ConsultaCuentas()
        End If
    End Sub
    Private Function Desactivar()
        Desactivar = False
        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPFinanciero_Desactivar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim operacion As String = "Desactivar"

        cmd.Parameters.AddWithValue("@Operacion", "Desactivar")
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Cuenta", lvGanado.SelectedItems.Item(0).SubItems(3).Text)
        cmd.Parameters.AddWithValue("@ItemGasto", lvGanado.SelectedItems.Item(0).SubItems(5).Text)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            Desactivar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        Dim validalista As Integer = 0
        For i = 0 To lvGanado.Items.Count - 1
            If lvGanado.Items(i).Selected = True Then
                If lvGanado.Items(i).SubItems(7).Text = "SI" Then
                    MsgBox("El registro ya se encuentra activado", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe seleccionar una cuenta")
            Exit Sub
        End If

        If MsgBox("¿ DESEA ACTIVAR EL REGISTRO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If Activar() = True Then
            ConsultaCuentas()
        End If
    End Sub
    Private Function Activar()
        Activar = False
        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPFinanciero_Desactivar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim operacion As String = "Activar"

        cmd.Parameters.AddWithValue("@Operacion", "Activar")
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Cuenta", lvGanado.SelectedItems.Item(0).SubItems(3).Text)
        cmd.Parameters.AddWithValue("@ItemGasto", lvGanado.SelectedItems.Item(0).SubItems(5).Text)

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            Activar = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmCuentasContablesAgregar.MdiParent = frmMAIN
        frmCuentasContablesAgregar.Show()
        frmCuentasContablesAgregar.BringToFront()
        Dim validalista As Integer = 0
    End Sub
End Class