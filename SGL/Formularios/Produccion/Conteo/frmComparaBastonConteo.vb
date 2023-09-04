


Imports Microsoft.Reporting.WinForms
Imports System.Data.SqlClient
Imports System.Threading

Public Class frmComparaBastonConteo
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas
    Public Reprocesa As Integer = 0
    Private fnConteoLVtoDatatable As New fnConteoLVtoDatatable
    Dim r As String
    Private Ultima As DateTime = Date.Now
    Public Param1_CentroCod As String
    Public ContDiioVal As Integer
    Public Param2_CentroNom As String
    Private Observaciones As String = ""
    Private TBaston As String = frmBastonV2Conteo.TBaston
    Private ComparaDIIOStockSala As String() = {}
    Private diiostock As Integer

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub

    Private Sub DetalleGanado()
        If lvGanado.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim diio As String = lvGanado.SelectedItems.Item(0).SubItems(1).Text
        Dim ConsultaDIIO As New infodiios

        If diio = "" Then Exit Sub

        ConsultaDIIO.MdiParent = frmMAIN
        ConsultaDIIO.lblDIIO.Text = diio
        ConsultaDIIO.ConsultaDIIO(diio)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default
    End Sub

    Private Function RealizarConteo() As Boolean
        RealizarConteo = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteos_GrabarConteo", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandTimeout = 300
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.CommandType = Data.CommandType.StoredProcedure
        Dim si As String = "SI"
        Dim no As String = "NO"
        Dim estadoB As String = "NO"
        Dim estadoExel As String = "NO"

        If TipoBaston.Contains("BASTON") Then
            estadoB = si
            estadoExel = no
        Else
            estadoExel = si
            estadoB = no
        End If

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_CentroCod)
        cmd.Parameters.AddWithValue("@CantStock", lblStock.Text)
        cmd.Parameters.AddWithValue("@CantBaston", lblDiiosBaston.Text)
        cmd.Parameters.AddWithValue("@CantDif", lblNroDif.Text)
        cmd.Parameters.AddWithValue("@diiostock", diiostock.ToString)
        cmd.Parameters.AddWithValue("@ContObservs", Observaciones)
        cmd.Parameters.AddWithValue("@ContConBaston", estadoB)
        cmd.Parameters.AddWithValue("@ContConExcel", estadoExel)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@reprocesa", Reprocesa)
        cmd.Parameters.AddWithValue("@ContFechaHora", Ultima)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetFecHora", SqlDbType.DateTime).Size = 255 : cmd.Parameters("@RetFecHora").Direction = ParameterDirection.Output
        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Ultima = cmd.Parameters("@RetFecHora").Value
            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION - Realizar Conteo - Cod. 100") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If


            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            RealizarConteo = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA - Realizar Conteo - Cod. 105")
        End Try

        Cursor.Current = Cursors.Default
    End Function

    Private Function RealizarConteoResumen() As Boolean
        RealizarConteoResumen = False

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteos_GrabarResumen", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandTimeout = 300
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CentroCod", Param1_CentroCod)
        cmd.Parameters.AddWithValue("@ContFecha", Ultima)
        cmd.Parameters.AddWithValue("@Reprocesa", Reprocesa)

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            RealizarConteoResumen = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA - Realizar Conteo Resumen - Cod. 200")
        Finally
            con.Close()
        End Try

        Cursor.Current = Cursors.Default
    End Function

    Private Function GrabarConteo() As Boolean
        GrabarConteo = False

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteos_GrabarConteoDetalles", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandTimeout = 300
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.Clear()
        Dim DetalleItems1 As DataTable = fnConteoLVtoDatatable.LVToDataTableConteoDiff(frmBastonV2Conteo.lvBASTON)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_CentroCod)
        cmd.Parameters.AddWithValue("@Reprocesa", Reprocesa)
        cmd.Parameters.AddWithValue("@FechaConteo", Ultima)
        cmd.Parameters.AddWithValue("@TablaDetalle", DetalleItems1)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        Try
            If con.State <> ConnectionState.Open Then con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA - Realizar Conteo Dif. - Cod. 300") = vbOK Then
                End If
                Cursor.Current = Cursors.Default
                Exit Function
            End If

            ''si todo sale ok guardamos el nuevo codigo del grupo de celos
            GrabarConteo = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA - Realizar Conteo Dif. - Cod. 315")
        End Try

        Cursor.Current = Cursors.Default
    End Function

    Private Sub frmComparaBastonConteo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        Dim diio_ As String = lvGanado.SelectedItems(0).SubItems(1).Text

        If Control.ModifierKeys = Keys.Control Then

            If e.KeyCode = Keys.C Then
                Clipboard.Clear()
                Clipboard.SetText(diio_)
            End If

        End If
    End Sub
    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(ListView1, e)
    End Sub
    Private Sub lvGanado_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvGanado.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvGanado, e)
    End Sub

    Private Sub frmComparaBastonConteo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 5
        Param1_CentroCod = frmBastonV2Conteo.Param1_CentroCod
        Param2_CentroNom = frmBastonV2Conteo.Param2_CentroNom
        cboCentros.Visible = False
        Dim cent_ As String = frmBastonV2Conteo.Param1_CentroCod
        If cent_ = "" Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        btnGrabarConteo.Enabled = False
        btnGrabarConteo.Visible = False
        btnExcel.Enabled = True
        Label11.Text = frmBastonV2Conteo.Param2_CentroNom


        If cboCentros.Items.Count = 1 Then
            cboCentros.SelectedIndex = 0
        Else
            cboCentros.SelectedIndex = -1
            btnGrabarConteo.Enabled = False
            lblFinalizado.Text = "Conteo Procesado y guardado exitosamente "
        End If

        lblDiiosBaston.Text = frmBastonV2Conteo.lvBASTON.Items.Count.ToString
        lblStock.Text = ListadoStock()
        CboLLenaCentros()
        VerificaExisteConteo()
        If RealizarConteo() = True Then
            GrabarConteo()
            RealizarConteoResumen()
            ConteoFaltantes()
            ConteoDiferencias()
        End If

    End Sub
    Public Function ListadoStock() As String
        Cursor.Current = Cursors.WaitCursor
        ListadoStock = "0"
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ListadoStock", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_CentroCod)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()

                    ListadoStock = rdr("stock").ToString.Trim
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Function
    Public Sub VerificaExisteConteo()

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteo_VerificaExisteConteo", con)
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE ASISTENCIA
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 185)")
            Cursor.Current = Cursors.Default
            Exit Sub
        End Try


        Dim Result As Integer
        Dim vret As Integer
        Dim fret As Date
        Dim mret As String

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Centro", Param1_CentroCod)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetFecha", SqlDbType.Date) : cmd.Parameters("@RetFecha").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            cmd.Transaction = SRVTRANS
            Result = cmd.ExecuteNonQuery()

            vret = cmd.Parameters("@RetValor").Value
            mret = cmd.Parameters("@RetMensage").Value
            fret = cmd.Parameters("@RetFecha").Value
            ''verificamos error con un valor igual a -1
            If vret <> 0 Then
                If MsgBox("¿Quiere Complementar Conteo anterior? (" & fret & ")", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
                    Reprocesa = 1
                    Ultima = fret
                End If

                Exit Try
            End If
            If vret = 0 Then
                Ultima = Date.Now
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA. (Cód. 190)")
        End Try

        con.Close()
        Cursor.Current = Cursors.Default

    End Sub
    Public Sub ConteoDiferencias()
        Thread.Sleep(20)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteo_ListaDiferencias", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Fecha", Ultima)
        cmd.Parameters.AddWithValue("@Centro", Param1_CentroCod)
        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("Diio").ToString.Trim)
                    item.SubItems.Add(rdr("Estado").ToString.Trim)
                    lvGanado.Items.Add(item)

                End While
                lblNroDif.Text = i
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
    Public Sub ConteoFaltantes()
        Thread.Sleep(20)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConteo_DiiosFaltantes", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Fecha", Ultima)
        cmd.Parameters.AddWithValue("@Centro", Param1_CentroCod)
        ListView1.BeginUpdate()
        ListView1.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos

                    item.SubItems.Add(rdr("GndCod").ToString.Trim)
                    item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                    ListView1.Items.Add(item)

                End While

                Label12.Text = i
                Label19.Text = i
                Label20.Text = lblStock.Text
                Dim stock As Integer = Label20.Text
                Label17.Text = stock - i
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

SalirProc:
        ListView1.EndUpdate()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Cursor.Current = Cursors.WaitCursor
        Reprocesa = 0
        Me.Close()

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub lvGanado_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvGanado.MouseDoubleClick
        If lvGanado.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            DetalleGanado()
        End If
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "TOTAL DE COMPARACIONES: " : tot(0, 1) = Label8.Text.Trim
        tot(1, 0) = "DIFERENCIAS BASTON: " : tot(1, 1) = Label9.Text.Trim
        tot(2, 0) = "DIFERENCIAS CONSULTA: " : tot(2, 1) = lblNroDif.Text.Trim

        ExportToExcelGrilla(lvGanado, tot)
    End Sub

    Private Sub frmComparaBastonConteo_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmCierresIngreso.Enabled = True
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Label4.Text = frmBastonV2Conteo.Param2_CentroNom
    End Sub
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter
        Label11.Text = frmBastonV2Conteo.Param2_CentroNom
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs)
        Label11.Text = frmBastonV2Conteo.Param2_CentroNom
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Observaciones = txtObs.Text
        If Observaciones <> "" Then
            If RealizarConteo() = True Then
                MsgBox("Observaciones grabadas con exito")
            End If
        Else

        End If

    End Sub
End Class