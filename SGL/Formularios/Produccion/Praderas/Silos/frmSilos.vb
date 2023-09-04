Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Imports System.Data.SqlClient
Imports CustomExtensions

Public Class frmSilos

    Private Sub frmSilos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btnCancelar.Enabled = False

        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLLenaCentros()
        cboCentros.Text = CentroPorDefecto()

        General.TipoBolo.Cargar(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1))
        CboLLenaBolos()
        dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim

        dtpFechaHasta.Value = Now
        cboEstados.SelectedIndex = 0



        If PerfilUsuario = 11 Then
            'cboEmpresaInCompania.Enabled = True
            btnCancelar.Enabled = True
        End If

        If PerfilUsuario = 7 Or PerfilUsuario = 11 Or PerfilUsuario = 5 Then
        Else

            ValBolo.Width = 0
            TotBolos.Width = 0
        End If
    End Sub
    Private Sub lvRESUMEN1_MouseClick(sender As Object, e As MouseEventArgs) Handles lvRESUMEN1.MouseClick
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        For i = 0 To lvRESUMEN1.Items.Count - 1
            If lvRESUMEN1.Items(i).Selected = True Then
                Dim centro As String = lvRESUMEN1.Items(i).SubItems(3).Text
                Dim fecha As Date = lvRESUMEN1.Items(i).SubItems(1).Text
                Dim Item As String = lvRESUMEN1.Items(i).SubItems(12).Text

                If centro = "" Then Exit Sub

                If Item = "" Then Exit Sub
                If e.Button = MouseButtons.Left = True Then

                    ConsultaSilosDetalles(fecha, centro, Item)

                    If lvRESUMEN1.Items(i).SubItems(15).Text = "CONFIRMADO" Then
                        btnEliminar.Enabled = False
                        BtnAnular.Enabled = True
                    ElseIf lvRESUMEN1.Items(i).SubItems(15).Text = "PND. CONFIRMACION" Then
                        btnEliminar.Enabled = True
                        BtnAnular.Enabled = False
                    Else
                        btnEliminar.Enabled = False
                        BtnAnular.Enabled = False
                    End If


                    Exit For
                End If


            End If

        Next
        Cursor.Current = Cursors.Default
    End Sub
    Public Sub ConsultaSilosDetalles(ByVal fech As Date, ByVal centro As String, ByVal item As String)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_ListadoEnsilajeDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Fecha", fech)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@item", item)

        lvBolos.BeginUpdate()
        lvBolos.Items.Clear()

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1
                    Dim item2 As New ListViewItem((i).ToString.Trim)    'cent.CentroNom, EnsilajeCentro,EnsilajeNomItm,EnsilajeItmUM,EnsilajeCodItm,EnsilajePotrero,EnsilajePotHa,EnsilajeCantidad,EnsilajeHaUtil,EnsilajeRend,EnsilajeValUnit,EnsilajeValTot
                    item2.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item2.SubItems.Add(rdr("EnsilajeCentro").ToString.Trim)
                    item2.SubItems.Add(rdr("EnsilajeNomItm").ToString.Trim)
                    item2.SubItems.Add(rdr("EnsilajeItmUM").ToString.Trim)
                    item2.SubItems.Add(rdr("EnsilajePotrero").ToString.Trim)
                    item2.SubItems.Add(Format(rdr("EnsilajePotHa"), "##,##0.00"))
                    If rdr("EnsilajeCantidad") = 0 Then
                        item2.SubItems.Add(rdr("EnsilajeCantidad"))
                    Else
                        item2.SubItems.Add(Format(rdr("EnsilajeCantidad"), "#,#"))
                    End If

                    item2.SubItems.Add(Format(rdr("EnsilajeHaUtil"), "##,##0.00"))
                    item2.SubItems.Add(Format(rdr("EnsilajeRend"), "##,##0.00"))
                    If rdr("EnsilajeValUnit") = 0 Then
                        item2.SubItems.Add(rdr("EnsilajeValUnit"))
                    Else
                        item2.SubItems.Add(Format(rdr("EnsilajeValUnit"), "#,#"))
                    End If
                    If rdr("EnsilajeValTot") = 0 Then
                        item2.SubItems.Add(rdr("EnsilajeValTot"))
                    Else
                        item2.SubItems.Add(Format(rdr("EnsilajeValTot"), "#,#"))
                    End If

                    item2.SubItems.Add(rdr("EnsilajeCodItm").ToString.Trim)
                    item2.SubItems.Add(rdr("EnsilajeFecha").ToString.Trim)
                    item2.SubItems.Add(rdr("EnsilajeIVDOCNMBR").ToString.Trim)
                    lvBolos.Items.Add(item2)
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
        lvBolos.EndUpdate()

    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        'cboCentros.SelectedIndex = 0
    End Sub
    Private Sub CboLLenaBolos()
        cboBolo.Items.Clear()
        cboBolo.Items.Add("(TODOS)")
        cboBolo.SelectedIndex = 0
        If General.TipoBolo.NroRegistros = 0 Then Exit Sub

        Dim i As Integer

        For i = 0 To General.TipoBolo.NroRegistros - 1
            cboBolo.Items.Add(General.TipoBolo.Nombre(i))
        Next


    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        lvRESUMEN1.Items.Clear()

        ConsultaSilos()
        lvBolos.Items.Clear()
        lvRESUMEN1.Enabled = True
    End Sub
    Public Sub ConsultaSilos()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_ListadoEnsilaje", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        If cboCentros.Text = "(TODOS)" Then
            cmd.Parameters.AddWithValue("@Centro", "")
        Else
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1))
        End If

        If cboBolo.Text = "(TODOS)" Then
            cmd.Parameters.AddWithValue("@Item", "")
        Else
            cmd.Parameters.AddWithValue("@Item", General.TipoBolo.Codigo(cboBolo.SelectedIndex - 1))
        End If
        cmd.Parameters.AddWithValue("@Estado", cboEstados.Text)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

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
                    Dim item As New ListViewItem((i).ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(Format(rdr("EnsilajeFecha"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(rdr("EnsilajeCentro").ToString.Trim)
                    item.SubItems.Add(rdr("EnsilajeNomItm").ToString.Trim)
                    item.SubItems.Add(rdr("EnsilajeItmUM").ToString.Trim)
                    item.SubItems.Add(Format(rdr("NumeroEnsilajes"), "#,#"))
                    item.SubItems.Add(Format(rdr("CantidadBolos"), "#,#"))
                    item.SubItems.Add(Format(rdr("HectareasUtilizadas"), "##,##0.00"))
                    item.SubItems.Add(Format(rdr("Rendimiento"), "##,##0.00"))
                    item.SubItems.Add(rdr("EnsilajeUsuario").ToString.Trim)
                    item.SubItems.Add(rdr("EnsilajePC").ToString.Trim)
                    item.SubItems.Add(rdr("EnsilajeCodItm").ToString.Trim)
                    item.SubItems.Add(rdr("ValorBolo").ToString.Trim)
                    item.SubItems.Add(rdr("ValorTotal").ToString.Trim)
                    item.SubItems.Add(rdr("Ensilajeestado").ToString.Trim)
                    item.SubItems.Add("")
                    item.SubItems.Add(rdr("EnsilajeUsuario").ToString.Trim)
                    item.SubItems.Add(rdr("hora"))
                    lvRESUMEN1.Items.Add(item)
                    If rdr("Ensilajeestado").ToString.Trim = "ANULADO" Then
                        lvRESUMEN1.Items(i - 1).ForeColor = Color.Red
                    End If
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
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmSilosConfeccionInterna.MdiParent = frmMAIN
        frmSilosConfeccionInterna.Show()

    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}
        Dim linedate As String = ""


        ExportToExcelGrilla(lvRESUMEN1, tot)

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿ Desea Eliminar TODA la información para el Día / Centro seleccionado? ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        Dim ObsGuia As String
        With frmSilosObs
            .ShowDialog()

            If .Cancelar = True Then
                Exit Sub
            End If

            ObsGuia = .ObservGuia
        End With

        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        For i = 0 To lvRESUMEN1.Items.Count - 1
            If lvRESUMEN1.Items(i).Selected = True Then
                Dim centro As String = lvRESUMEN1.Items(i).SubItems(3).Text
                Dim fecha As String = lvRESUMEN1.Items(i).SubItems(1).Text
                Dim Item As String = lvRESUMEN1.Items(i).SubItems(12).Text
                Dim Cant As String = lvRESUMEN1.Items(i).SubItems(7).Text
                Dim He As String = lvRESUMEN1.Items(i).SubItems(8).Text
                If centro = "" Then Exit Sub
                If fecha = "" Then Exit Sub
                If Item = "" Then Exit Sub
                'If PerfilUsuario <> 7 Or PerfilUsuario <> 11 Then
                '    dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
                'End If

                If EliminarEnsilaje(centro, fecha, Item, Cant, He, ObsGuia) = True Then
                    MsgBox("Datos Eliminados ---- ok -----", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    lvRESUMEN1.Items.Clear()
                    lvBolos.Items.Clear()
                    ConsultaSilos()
                    btnEliminar.Enabled = False
                    BtnAnular.Enabled = False
                    Exit For
                    Exit Sub
                End If
            End If

        Next
        Cursor.Current = Cursors.Default
    End Sub
    Private Function EliminarEnsilaje(ByVal centro As String, ByVal fecha As Date, ByVal Item As String, ByVal Cant As String, ByVal He As String, ByRef ObsGuia As String) As Boolean
        EliminarEnsilaje = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_EliminarEnsilaje", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@ObsGuia", ObsGuia)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Item", Item)
        cmd.Parameters.AddWithValue("@Cant", Cant)
        cmd.Parameters.AddWithValue("@Eliminar7Dias", "NO")
        cmd.Parameters.AddWithValue("@He", He)
        cmd.Parameters.AddWithValue("@Potrero", "Todos")
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
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
            EliminarEnsilaje = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        lvBolos.Items.Clear()
        lvRESUMEN1.Items.Clear()
        dtpFechaDesde.Value = Now

        dtpFechaHasta.Value = Now
        cboBolo.SelectedIndex = 0
        cboCentros.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        frmSilosModificar.MdiParent = frmMAIN
        frmSilosModificar.Show()

    End Sub

    Private Sub lvRESUMEN1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvRESUMEN1.MouseDoubleClick
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub

        If e.Button = MouseButtons.Left = True Then
            If PerfilUsuario = 7 Or PerfilUsuario = 11 Or PerfilUsuario = 5 Then
                DetalleEnsilaje()
            Else
            End If

        End If
    End Sub
    Private Sub DetalleEnsilaje()
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        Dim i As Integer
        For i = 0 To lvRESUMEN1.Items.Count - 1
            If lvRESUMEN1.Items(i).Selected = True Then
                Dim centro As String = lvRESUMEN1.Items(i).SubItems(3).Text
                Dim fecha As Date = lvRESUMEN1.Items(i).SubItems(1).Text
                Dim TipEnsilaje As String = lvRESUMEN1.Items(i).SubItems(12).Text
                Dim SilosModificar As New frmSilosModificar

                If centro = "" Then Exit Sub
                If TipEnsilaje = "" Then Exit Sub

                SilosModificar.MdiParent = frmMAIN
                SilosModificar.BuscarEsilaje(fecha, centro, TipEnsilaje)
                SilosModificar.Fech.Text = fecha
                SilosModificar.Cemtro.Text = lvRESUMEN1.Items(i).SubItems(2).Text
                SilosModificar.Item.Text = lvRESUMEN1.Items(i).SubItems(4).Text
                SilosModificar.Show()

                Exit For
            End If

        Next

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub mnuEliminar_Click(sender As Object, e As EventArgs) Handles mnuEliminar.Click
        If MsgBox("¿ Desea Eliminar El Registro Seleccionado? ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        If lvBolos.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        For i = 0 To lvBolos.Items.Count - 1
            If lvBolos.Items(i).Selected = True Then
                Dim centro As String = lvBolos.Items(i).SubItems(2).Text
                Dim fecha As Date = lvBolos.Items(i).SubItems(13).Text
                Dim Item As String = lvBolos.Items(i).SubItems(12).Text
                Dim Potrero As String = lvBolos.Items(i).SubItems(5).Text
                Dim Cant As String = lvRESUMEN1.Items(i).SubItems(7).Text
                Dim He As String = lvRESUMEN1.Items(i).SubItems(8).Text

                If EliminarDetalleEnsilaje(centro, fecha, Item, Potrero, Cant, He) = True Then
                    MsgBox("Datos Eliminados ---- ok -----", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    lvBolos.Items.Clear()
                    ConsultaSilosDetalles(fecha, centro, Item)
                    Exit For
                    Exit Sub
                End If
            End If

        Next
        Cursor.Current = Cursors.Default
    End Sub
    Private Function EliminarDetalleEnsilaje(ByVal centro As String, ByVal fecha As Date, ByVal Item As String, ByVal Potrero As String, ByVal Cant As String, ByVal He As String) As Boolean
        EliminarDetalleEnsilaje = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_EliminarDetalleEnsilaje", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Item", Item)
        cmd.Parameters.AddWithValue("@Cant", Cant)
        cmd.Parameters.AddWithValue("@He", He)
        If PerfilUsuario = 7 Or PerfilUsuario = 11 Or PerfilUsuario = 5 Then
            cmd.Parameters.AddWithValue("@Eliminar7Dias", "SI")
        Else
            cmd.Parameters.AddWithValue("@Eliminar7Dias", "NO")
        End If
        cmd.Parameters.AddWithValue("@Potrero", Potrero)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
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
            EliminarDetalleEnsilaje = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Sub lvRESUMEN1_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvRESUMEN1.ItemSelectionChanged
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        For i = 0 To lvRESUMEN1.Items.Count - 1
            If lvRESUMEN1.Items(i).Selected = True Then
                Dim centro As String = lvRESUMEN1.Items(i).SubItems(3).Text
                Dim fecha As String = lvRESUMEN1.Items(i).SubItems(1).Text
                Dim Item As String = lvRESUMEN1.Items(i).SubItems(12).Text
                If centro = "" Then Exit Sub
                If fecha = "" Then Exit Sub
                If Item = "" Then Exit Sub

                ConsultaSilosDetalles(fecha, centro, Item)
                Exit For

            End If

        Next
        Cursor.Current = Cursors.Default

    End Sub

    Private Sub lvRESUMEN1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lvRESUMEN1.KeyPress
        If lvRESUMEN1.Items.Count = 0 Then Exit Sub


        DetalleEnsilaje()

    End Sub

    Private Sub cboBolo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBolo.SelectedIndexChanged

    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged

        If cboCentros.Text = "(TODOS)" Then
            General.TipoBolo.Cargar("")
            CboLLenaBolos()
        Else
            General.TipoBolo.Cargar(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1))
            CboLLenaBolos()
        End If

    End Sub

    Private Sub lvRESUMEN1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvRESUMEN1.SelectedIndexChanged

    End Sub

    Private Sub BtnAnular_Click(sender As Object, e As EventArgs) Handles BtnAnular.Click
        If MsgBox("¿ Desea Anular TODA la información para el Día / Centro seleccionado? ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        Dim ObsGuia As String
        With frmSilosObs
            .ShowDialog()

            If .Cancelar = True Then
                Exit Sub
            End If

            ObsGuia = .ObservGuia
        End With


        If lvRESUMEN1.Items.Count = 0 Then Exit Sub
        Cursor.Current = Cursors.WaitCursor
        For i = 0 To lvRESUMEN1.Items.Count - 1
            If lvRESUMEN1.Items(i).Selected = True Then
                Dim centro As String = lvRESUMEN1.Items(i).SubItems(3).Text
                Dim fecha As String = lvRESUMEN1.Items(i).SubItems(1).Text
                Dim Item As String = lvRESUMEN1.Items(i).SubItems(12).Text
                Dim Cant As String = lvRESUMEN1.Items(i).SubItems(7).Text
                Dim He As String = lvRESUMEN1.Items(i).SubItems(8).Text
                If centro = "" Then Exit Sub
                If fecha = "" Then Exit Sub
                If Item = "" Then Exit Sub
                'If PerfilUsuario <> 7 Or PerfilUsuario <> 11 Then
                '    dtpFechaDesde.Value = "01-" + Month(Now).ToString.Trim + "-" + Year(Now).ToString.Trim
                'End If

                If AnularEnsilaje(centro, fecha, Item, Cant, He, ObsGuia) = True Then
                    MsgBox("Datos Anulados ---- ok -----", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    lvRESUMEN1.Items.Clear()
                    lvBolos.Items.Clear()
                    ConsultaSilos()
                    btnEliminar.Enabled = False
                    BtnAnular.Enabled = False
                    Exit For
                    Exit Sub
                End If
            End If

        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private Function AnularEnsilaje(ByVal centro As String, ByVal fecha As Date, ByVal Item As String, ByVal Cant As String, ByVal He As String, ByVal ObsGuia As String) As Boolean
        AnularEnsilaje = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_AnularEnsilaje", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ObsGuia", ObsGuia)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@Fecha", fecha)
        cmd.Parameters.AddWithValue("@Item", Item)
        cmd.Parameters.AddWithValue("@Cant", Cant)
        cmd.Parameters.AddWithValue("@Eliminar7Dias", "NO")
        cmd.Parameters.AddWithValue("@He", He)
        cmd.Parameters.AddWithValue("@Potrero", "Todos")
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
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
            AnularEnsilaje = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Sub btnReajuste_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If lvBolos.Items.Count = 0 Then
            MsgBox("DEBES SELECCIONAR UN REGISTRO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "SGL")
            Exit Sub
        End If
        If MsgBox("SI CANCELAS, DEBES INFORMARLO A CONTABILIDAD O NO SE APLICARA LA MODIFICACION, ¿DESEAS CONTINUAR? ", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "SGL") = vbNo Then
            Exit Sub
        End If
        ReajusteEnsilaje()
    End Sub
    Public Sub ReajusteEnsilaje()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_ReajustarEnsilaje", con)
        Dim rdr As SqlDataReader = Nothing

        Dim Fecha As String = lvRESUMEN1.Items(0).SubItems(1).Text
        Dim Centro As Integer = lvRESUMEN1.Items(0).SubItems(3).Text
        Dim CantBolos As Integer = lvRESUMEN1.Items(0).SubItems(7).Text
        Dim HA As Decimal = lvRESUMEN1.Items(0).SubItems(8).Text
        Dim Rendimiento As Decimal = lvRESUMEN1.Items(0).SubItems(9).Text


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Fecha", Fecha)
        cmd.Parameters.AddWithValue("@Centro", Centro)
        cmd.Parameters.AddWithValue("@CantBolos", CantBolos)
        cmd.Parameters.AddWithValue("@HA", HA)
        cmd.Parameters.AddWithValue("@Rendimiento", Rendimiento)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
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
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Sub
End Class