Imports System.Data.SqlClient
Imports System.Threading
Imports Microsoft.Reporting.WinForms
Public Class frmMuestraLecheResumen
    Private VacSesiones As frmVacunasSesiones
    Private orden As Integer = 1
    Private fnVacunados As New fnVacunados
    Public centroResumen As String = ""
    Public fechaResumen As String = ""
    Private vacuna As String
    Private Proveedor As String = ""
    Private ConsultaDiio As String
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvRESUMEN1.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvRESUMEN1, e)
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvRESUMEN1.Items.Clear()

        ConsultaMuestraLeche()
    End Sub
    Public Sub ConsultaMuestraLeche()
        Dim Proveedor As String

        Dim Estado As String = cboEstado.Text.Replace(" ", "")

        lvRESUMEN1.Items.Clear()
        Thread.Sleep(20)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_ResumenListado", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Lote", txtLote.Text)
        If cboProveedores.Text = "(TODOS)" Then
            Proveedor = ""
        Else
            Proveedor = General.Proveedores.Codigo(5017)
        End If
        cmd.Parameters.AddWithValue("@Proveedor", Proveedor)
        cmd.Parameters.AddWithValue("@Estado", Estado)
        cmd.Parameters.AddWithValue("@Orden", orden)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value) ' Mid(dtpFechaDesde.Value.ToString, 1, 24))
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value) 'Mid(dtpFechaHasta.Value.ToString, 1, 24))

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        'lvGanado.Items.Clear()
        lvRESUMEN1.BeginUpdate()
        lvRESUMEN1.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i))    'primera columna, para ordenar los datos

                    If rdr("ProvNom") = "NO USAR" Then
                        item.SubItems.Add("Interno")
                    Else
                        item.SubItems.Add(rdr("ProvNom"))
                    End If
                    item.SubItems.Add(rdr("Lote"))
                    item.SubItems.Add(rdr("Muestras"))
                    item.SubItems.Add(rdr("Estado").Replace("Pnd", "Pnd "))
                    item.SubItems.Add(rdr("Horario"))
                    item.SubItems.Add(rdr("Usuario").trim.ToString)
                    item.SubItems.Add(Format(rdr("FechaMuestra"), "dd/MM/yyyy"))
                    item.SubItems.Add(Format(rdr("FechaEnvio"), "dd/MM/yyyy"))
                    item.SubItems.Add(Format(rdr("FechaResult"), "dd/MM/yyyy"))


                    lvRESUMEN1.Items.Add(item)
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
        lvRESUMEN1.EndUpdate()
        Label10.Text = i.ToString.Trim
    End Sub

    Private Sub frmMuestraLecheResumen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        dtpFechaHasta.Value = Date.Now
        General.Proveedores.Cargar()
        cbollenaProveedores()
        cbollenaEstados()
        cboEstado.SelectedIndex = 0
        cboProveedores.SelectedIndex = 0
        dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
        ConsultaMuestraLeche()
    End Sub
    Private Sub cbollenaEstados()

        cboEstado.Items.Clear()
        cboEstado.Items.Add("(TODOS)")
        cboEstado.Items.Add("Pnd Envio")
        cboEstado.Items.Add("Pnd Resultado")
        cboEstado.Items.Add("Finalizado")

    End Sub
    Private Sub cbollenaProveedores()
        If General.Proveedores.NroRegistros = 0 Then Exit Sub

        cboProveedores.Items.Clear()
        cboProveedores.Items.Add("(TODOS)")
        Dim i As Integer

        For i = 0 To General.Proveedores.NroRegistros - 1
            If General.Proveedores.Codigo(i) = "823926006" Then
                cboProveedores.Items.Add(General.Proveedores.Nombre(i))
            End If


        Next
        cboProveedores.Text = -1
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtLote_TextChanged(sender As Object, e As EventArgs) Handles txtLote.TextChanged
        If txtLote.Text = "" Then
            orden = 1
        Else
            orden = 0
        End If

    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        orden = 0
        If cboEstado.SelectedIndex = -1 Or cboEstado.Text = "(TODOS)" Then
            orden = 1
        End If
    End Sub

    Private Sub cboProveedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProveedores.SelectedIndexChanged
        orden = 0
        If cboProveedores.SelectedIndex = -1 Or cboProveedores.Text = "(TODOS)" Then
            orden = 1
        End If
        If cboProveedores.SelectedIndex = 1 Then
            Proveedor = "5017"
        Else
            Proveedor = ""
        End If
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        txtLote.Text = ""
        cboEstado.SelectedIndex = 0
        cboProveedores.SelectedIndex = 0
        dtpFechaHasta.Value = Date.Now
        dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
        orden = 1
        lvRESUMEN1.Items.Clear()
    End Sub

    Private Sub dtpFechaDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged
        orden = 1
    End Sub

    Private Sub dtpFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaHasta.ValueChanged
        orden = 1
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmMuestraLeche.MdiParent = frmMAIN
        frmMuestraLeche.Show()
        frmMuestraLeche.BringToFront()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEnvio.Click
        frmMuestraLecheEnvio.MdiParent = frmMAIN
        frmMuestraLecheEnvio.Show()
        frmMuestraLecheEnvio.BringToFront()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmMuestraLecheResultado.MdiParent = frmMAIN
        frmMuestraLecheResultado.Show()
        frmMuestraLecheResultado.BringToFront()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}
        ExportToExcelGrilla(lvRESUMEN1, tot)
    End Sub
    Private Sub lvRESUMEN1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvRESUMEN1.MouseDoubleClick
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub
    Private Sub DetalleGanado()
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor

        Dim Lote As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(2).Text
        Dim Estado As String = lvRESUMEN1.SelectedItems.Item(0).SubItems(4).Text
        Dim Muestra As New frmMuestraLecheResumenDetalle

        If Lote = "" Then Exit Sub

        Muestra.MdiParent = frmMAIN
        Muestra.lblLote.Text = Lote
        Muestra.lblEstado.Text = Estado.Replace("Pnd ", "Pendiente ")
        Muestra.DetalleMuestra(Lote)

        Muestra.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim validalista As Integer = 0
        For i = 0 To lvRESUMEN1.Items.Count - 1
            If lvRESUMEN1.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe Seleccionar un Registro de la Lista")
            Exit Sub
        End If
        If MsgBox("¿ DESEA ELIMINAR EL REGISTRO DE MUESTRA DE LECHE ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminaMuestraLeche() = True Then
            ConsultaMuestraLeche()
        End If
    End Sub
    Private Function EliminaMuestraLeche() As Boolean
        'If lista_usuarios.Items.Count = 0 Then Exit Function
        EliminaMuestraLeche = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_EliminarMuestra", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim lote As String = ""

        lote = lvRESUMEN1.SelectedItems.Item(0).SubItems(2).Text

        cmd.Parameters.AddWithValue("@Lote", lote)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            EliminaMuestraLeche = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        frmMuestraLecheIngresoManual.MdiParent = frmMAIN
        frmMuestraLecheIngresoManual.Show()
        frmMuestraLecheIngresoManual.BringToFront()
    End Sub

    Private Sub btnExcelCooprinsem_Click(sender As Object, e As EventArgs) Handles btnExcelCooprinsem.Click
        frmMuestraLecheExcel.MdiParent = frmMAIN
        frmMuestraLecheExcel.Show()
        frmMuestraLecheExcel.BringToFront()
    End Sub
End Class