

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient






Public Class frmInseminadores
    '    Private TipoReporte As Integer = 0

    'contabilizacion
    Private Total_Insem As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "InsemCodigo", "InsemNombre", "InsemVigente", "InsemExterno", "InsemObservs"}
    Private CadenaOrden As String = "InsemNombre"



    Private Sub InicializaTotales()
        Total_Insem = 0
    End Sub


    'Private Sub ProcesaTotales(ByVal mue_ As Integer)
    '    If mue_ <> 0 Then
    '        Total_Insem = Total_Insem + mue_
    '    End If
    'End Sub


    Private Sub MuestraTotales()
        'Label85.Text = Total_General.ToString.Trim

        Label48.Text = Total_Insem.ToString.Trim()

        pnlTotales.Refresh()
    End Sub


    Private Sub CboLlenaVS()
        cboVigente.Items.Add("(TODOS)")
        cboVigente.Items.Add("SI")
        cboVigente.Items.Add("NO")
        ''
        cboExterno.Items.Add("(TODOS)")
        cboExterno.Items.Add("SI")
        cboExterno.Items.Add("NO")
    End Sub


    Public Sub ConsultaInseminadores(ByVal vigente_ As String, ByVal externo_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spInseminadores_Listado2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Vigente", vigente_)
        cmd.Parameters.AddWithValue("@Externo", externo_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvINSEMINADORES.BeginUpdate()
        lvINSEMINADORES.Items.Clear()

        Dim i As Integer = 0
        Dim ivig_, iext_ As String
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    If vret = 0 Then
                        vret = rdr("ContRegs")
                        pbProcesa.Maximum = vret
                    End If

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                    ivig_ = ""
                    iext_ = ""

                    If rdr("InsemVigente") = 1 Then ivig_ = "SI"
                    If rdr("InsemExterno") = 1 Then iext_ = "SI"

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("EmpCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("InsemCodigo").ToString.Trim)                  'centro
                    item.SubItems.Add(rdr("InsemNombre").ToString.Trim)
                    item.SubItems.Add(ivig_)
                    item.SubItems.Add(iext_)
                    item.SubItems.Add(rdr("InsemObservs").ToString.Trim)
                    ''
                    lvINSEMINADORES.Items.Add(item)

                    Total_Insem = Total_Insem + 1

                    i = i + 1
                    pbProcesa.Value = i
                End While

                pbProcesa.Value = pbProcesa.Maximum

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        lvINSEMINADORES.EndUpdate()
        'Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Public Sub LlenaGrilla()
        Dim raza_ As Integer = 0
        Dim vig_ As Integer = -1
        Dim sex_ As Integer = -1

        If cboVigente.SelectedIndex <> -1 And cboVigente.Text <> "(TODOS)" Then
            vig_ = IIf(cboVigente.Text = "SI", 1, 0)
        End If

        If cboExterno.SelectedIndex <> -1 And cboExterno.Text <> "(TODOS)" Then
            sex_ = IIf(cboExterno.Text = "SI", 1, 0)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "InsemNombre"
            lblOrdena.Text = "Nombre"
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaInseminadores(vig_, sex_)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Function EliminarInseminador() As Boolean
        EliminarInseminador = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spInseminadores_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim insem_ As String = lvINSEMINADORES.SelectedItems(0).SubItems(2).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Codigo", insem_)
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

            EliminarInseminador = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function InseminadorVigente(ByVal vig_ As Integer) As Boolean
        InseminadorVigente = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spInseminadores_Vigente", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim insem_ As String = lvINSEMINADORES.SelectedItems(0).SubItems(2).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@InsemCod", insem_)
        cmd.Parameters.AddWithValue("@InsemVig", vig_)
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

            InseminadorVigente = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function InseminadorExterno(ByVal ext_ As Integer) As Boolean
        InseminadorExterno = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spInseminadores_Externo", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim insem_ As String = lvINSEMINADORES.SelectedItems(0).SubItems(2).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@InsemCod", insem_)
        cmd.Parameters.AddWithValue("@InsemExt", ext_)
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

            InseminadorExterno = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        LlenaGrilla()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvINSEMINADORES.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL INSEMINADORES " : tot(0, 1) = Label48.Text.Trim

        ExportToExcelGrilla(lvINSEMINADORES, tot)
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        'frmInseminadoresIngreso.Param1_Modo = 1   'nueva muerte

        frmInseminadoresIngreso.MdiParent = frmMAIN
        frmInseminadoresIngreso.Show()
        frmInseminadoresIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvINSEMINADORES.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvINSEMINADORES.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvINSEMINADORES.Columns(e.Column).Text
        End If
    End Sub


    Private Sub frmInseminadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLlenaVS()

        cboVigente.SelectedIndex = 0
        cboExterno.SelectedIndex = 0
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvINSEMINADORES.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR EL INSEMINADOR SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarInseminador() = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuToroVigente_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsemVigente.Click
        If lvINSEMINADORES.SelectedItems.Count = 0 Then Exit Sub

        If InseminadorVigente(1) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuToroQuitarVigente_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsemQuitarVigente.Click
        If lvINSEMINADORES.SelectedItems.Count = 0 Then Exit Sub

        If InseminadorVigente(0) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuInsemExterno_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsemExterno.Click
        If lvINSEMINADORES.SelectedItems.Count = 0 Then Exit Sub

        If InseminadorExterno(1) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuInsemQuitarExterno_Click(sender As System.Object, e As System.EventArgs) Handles mnuInsemQuitarExterno.Click
        If lvINSEMINADORES.SelectedItems.Count = 0 Then Exit Sub

        If InseminadorExterno(0) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub cboVigente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboVigente.SelectedIndexChanged, cboVigente.SelectedIndexChanged
        btnBuscar.PerformClick()
    End Sub
End Class