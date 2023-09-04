
Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient

Public Class frmCuentasContablesAgregar
    Private Sub frmCuentasContablesAgregar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.ClasesContables.Cargar(2)
        LlenaComboClases()
        cboItemGasto.SelectedIndex = 0
    End Sub
    Private Sub LlenaComboClases()
        cboClases.Items.Clear()

        For i = 0 To General.ClasesContables.NroRegistros - 1
            cboClases.Items.Add(General.ClasesContables.ClaseNom(i))
        Next
        cboClases.SelectedIndex = 0
    End Sub

    Private Sub cboClases_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClases.SelectedIndexChanged
        General.CuentasContablesMan.Cargar(General.ClasesContables.ClaseCod(cboClases.SelectedIndex), 2)
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
        General.ItemsGastoContables.Cargar(General.CuentasContablesMan.CuentaCod(cboCuentas.SelectedIndex), 2)
        LlenaComboitems()
    End Sub
    Private Sub LlenaComboitems()
        cboItemGasto.Items.Clear()

        For i = 0 To General.ItemsGastoContables.NroRegistros - 1
            cboItemGasto.Items.Add(General.ItemsGastoContables.ItemGastoNom(i))
        Next
        cboItemGasto.SelectedIndex = 0
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        CrearCuenta()
    End Sub
    Private Sub CrearCuenta()
        Dim i As Integer = 0
        Dim algo As String = General.ItemsGastoContables.ItemGastoCod(cboItemGasto.SelectedIndex)
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPFinancieroCrearCuenta", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Cuenta", General.CuentasContablesMan.CuentaCod(cboCuentas.SelectedIndex))
        cmd.Parameters.AddWithValue("@ItemGasto", General.ItemsGastoContables.ItemGastoCod(cboItemGasto.SelectedIndex))
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@Duplicado", SqlDbType.Int) : cmd.Parameters("@Duplicado").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Dim dup As Integer = cmd.Parameters("@Duplicado").Value

            If dup = "1" Then
                MsgBox("CUENTA CONTABLE YA EXISTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If

            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
        MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Me.Dispose()
        Me.Close()
        frmCuentasContables.cargar()
        Cursor.Current = Cursors.Default
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Dispose()
        Me.Close()
        frmCuentasContables.cargar()
    End Sub
End Class