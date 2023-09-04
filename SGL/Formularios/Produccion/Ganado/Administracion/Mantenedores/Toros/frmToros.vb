

Imports Microsoft.Office.Interop.Excel
'Imports Micr .Office.Interop
Imports System.Data.SqlClient
Imports System.Xml

Public Class frmToros
    '    Private TipoReporte As Integer = 0

    'contabilizacion
    Private Total_Toros As Integer = 0


    'nombre de los campos en la base de datos, para realizar los filtros desde esta pantalla
    Private CamposOrden As String() = {"", "", "ToroCodigo", "ToroNombre", "NomRaza", "ToroVigente", "ToroSexado", "ToroObservs"}
    Private CadenaOrden As String = "ToroNombre"



    Private Sub InicializaTotales()
        Total_Toros = 0
    End Sub


    'Private Sub ProcesaTotales(ByVal mue_ As Integer)
    '    If mue_ <> 0 Then
    '        Total_Toros = Total_Toros + mue_
    '    End If
    'End Sub


    Private Sub MuestraTotales()
        'Label85.Text = Total_General.ToString.Trim

        Label48.Text = Total_Toros.ToString.Trim()

        pnlTotales.Refresh()
    End Sub


    Private Sub CboLlenaVS()
        cboVigente.Items.Add("(TODOS)")
        cboVigente.Items.Add("SI")
        cboVigente.Items.Add("NO")
        ''
        cboSexado.Items.Add("(TODOS)")
        cboSexado.Items.Add("SI")
        cboSexado.Items.Add("NO")
    End Sub


    Public Sub ConsultaToros(ByVal raza_ As String, ByVal vigente_ As String, ByVal sexado_ As String)
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        InicializaTotales()
        MuestraTotales()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spToros_Listado2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", General.Empresa)
        cmd.Parameters.AddWithValue("@Raza", raza_)
        cmd.Parameters.AddWithValue("@Vigente", vigente_)
        cmd.Parameters.AddWithValue("@Sexado", sexado_)
        cmd.Parameters.AddWithValue("@Orden", CadenaOrden)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        'cmd.Parameters.Add("@ContRegs", SqlDbType.Int) : cmd.Parameters("@ContRegs").Direction = ParameterDirection.Output

        'lvGanado.Items.Clear()
        lvTOROS.BeginUpdate()
        lvTOROS.Items.Clear()

        Dim i As Integer = 0
        Dim tvig_, tsex_ As String
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

                    tvig_ = ""
                    tsex_ = ""

                    If rdr("ToroVigente") = 1 Then tvig_ = "SI"
                    If rdr("ToroSexado") = 1 Then tsex_ = "SI"

                    'item.SubItems.Add((i + 1).ToString.Trim)
                    item.SubItems.Add(rdr("EmpCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("ToroCodigo").ToString.Trim)
                    item.SubItems.Add(rdr("ABCode").ToString.Trim)
                    item.SubItems.Add(rdr("ToroNombre").ToString.Trim)
                    item.SubItems.Add(rdr("NomRaza").ToString.Trim)
                    item.SubItems.Add(tvig_)
                    item.SubItems.Add(tsex_)
                    item.SubItems.Add(rdr("ToroObservs").ToString.Trim)
                    ''
                    lvTOROS.Items.Add(item)

                    Total_Toros = Total_Toros + 1

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
        lvTOROS.EndUpdate()
        'Total_General = i
        MuestraTotales()
        pnlProcesa.Visible = False
    End Sub


    Public Sub LlenaGrilla()
        Dim raza_ As Integer = 0
        Dim vig_ As Integer = -1
        Dim sex_ As Integer = -1

        If cboRazas.SelectedIndex <> -1 And cboRazas.Text <> "(TODOS)" Then
            raza_ = General.Razas.Codigo(cboRazas.SelectedIndex - 1)
        End If

        If cboVigente.SelectedIndex <> -1 And cboVigente.Text <> "(TODOS)" Then
            vig_ = IIf(cboVigente.Text = "SI", 1, 0)
        End If

        If cboSexado.SelectedIndex <> -1 And cboSexado.Text <> "(TODOS)" Then
            sex_ = IIf(cboSexado.Text = "SI", 1, 0)
        End If

        If CadenaOrden = "" Then
            CadenaOrden = "ToroNombre"
            lblOrdena.Text = "Nombre"
            lblOrdena.Refresh()
        End If

        Cursor.Current = Cursors.WaitCursor
        ConsultaToros(raza_, vig_, sex_)
        'ConsultaGeneral(OtrosCent, Centros, Estados, OtrosCat, Categorias, OtrosEProd, EstadosProductivos, OtrosEReprod, EstadosReproductivos)
        Cursor.Current = Cursors.Default
    End Sub


    Private Function EliminarToro() As Boolean
        EliminarToro = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spToros_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim toro_ As String = lvTOROS.SelectedItems(0).SubItems(2).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", General.Empresa)
        cmd.Parameters.AddWithValue("@Codigo", toro_)
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

            EliminarToro = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function ToroVigente(ByVal vig_ As Integer) As Boolean
        ToroVigente = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spToros_Vigente", con)
        Dim rdr As SqlDataReader = Nothing
        ''
        Dim toro_ As String = lvTOROS.SelectedItems(0).SubItems(2).Text

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", General.Empresa)
        cmd.Parameters.AddWithValue("@ToroCod", toro_)
        cmd.Parameters.AddWithValue("@ToroVig", vig_)
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

            ToroVigente = True

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
        If lvTOROS.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL TOROS " : tot(0, 1) = Label48.Text.Trim

        ExportToExcelGrilla(lvTOROS, tot)
    End Sub


    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor

        'frmTorosIngreso.Param1_Modo = 1   'nueva muerte

        frmTorosIngreso.MdiParent = frmMAIN
        frmTorosIngreso.Show()
        frmTorosIngreso.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnLimpiarFiltro_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiarFiltro.Click
        CadenaOrden = ""
        lblOrdena.Text = ""
    End Sub


    Private Sub lvGanado_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvTOROS.ColumnClick
        If InStr(CadenaOrden, CamposOrden(e.Column)) > 0 Then Exit Sub

        If CadenaOrden.Trim = "" Then
            CadenaOrden = CamposOrden(e.Column)
            lblOrdena.Text = lvTOROS.Columns(e.Column).Text
        Else
            CadenaOrden = CadenaOrden + ", " + CamposOrden(e.Column)
            lblOrdena.Text = lblOrdena.Text + " -> " + lvTOROS.Columns(e.Column).Text
        End If
    End Sub


    Private Sub frmToros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.Razas.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaRazas(cboRazas, True)
        CboLlenaVS()

        cboRazas.SelectedIndex = 0
        cboVigente.SelectedIndex = 0
        cboSexado.SelectedIndex = 0
    End Sub


    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        If lvTOROS.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR EL TORO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmacion") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarToro() = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuToroVigente_Click(sender As System.Object, e As System.EventArgs) Handles mnuToroVigente.Click
        If lvTOROS.SelectedItems.Count = 0 Then Exit Sub

        If ToroVigente(1) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub mnuToroQuitarVigente_Click(sender As System.Object, e As System.EventArgs) Handles mnuToroQuitarVigente.Click
        If lvTOROS.SelectedItems.Count = 0 Then Exit Sub

        If ToroVigente(0) = True Then
            LlenaGrilla()
        End If
    End Sub


    Private Sub cboRazas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboRazas.SelectedIndexChanged, cboVigente.SelectedIndexChanged, cboSexado.SelectedIndexChanged
        btnBuscar.PerformClick()
    End Sub

    Public Sub ToroActualizar()

    End Sub

    Private Sub lvTOROS_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvTOROS.MouseDoubleClick
        Dim Codigo As String = lvTOROS.SelectedItems.Item(0).SubItems(2).Text
        Dim ABCode As String = lvTOROS.SelectedItems.Item(0).SubItems(3).Text
        Dim Nombre As String = lvTOROS.SelectedItems.Item(0).SubItems(4).Text
        Dim Raza As String = lvTOROS.SelectedItems.Item(0).SubItems(5).Text
        Dim Vigenete As String = lvTOROS.SelectedItems.Item(0).SubItems(6).Text
        Dim Sexado As String = lvTOROS.SelectedItems.Item(0).SubItems(7).Text
        Dim Obs As String = lvTOROS.SelectedItems.Item(0).SubItems(8).Text

        frmTorosIngreso.txtCodigo.Text = Codigo
        frmTorosIngreso.txtABCode.Text = ABCode
        frmTorosIngreso.txtNombre.Text = Nombre
        frmTorosIngreso.Raza = Raza
        frmTorosIngreso.Vigente = Vigenete
        frmTorosIngreso.Sexado = Sexado
        frmTorosIngreso.txtObservs.Text = Obs
        frmTorosIngreso.Update = 1
        frmTorosIngreso.ShowDialog()
    End Sub
End Class