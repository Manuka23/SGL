Imports System.Data.SqlClient
Public Class frmSilosModificar
    Private Const CantidadHa = 4
    Private Const ValoxBolo = 7
    Private Sub frmSilosModificar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLLenaCentros()
        cboCentros.Text = CentroPorDefecto()
        General.Potreros.Cargar(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        CboLLenaBolos()
        General.TipoBolo.Cargar(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        CboLLenaBolos()
        dtpFechaDesde.Value = Now
    End Sub
    Private Sub Valor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Valor.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Valor.Text = Valor.Text.Trim
            e.Handled = True
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub dgvPOTREROS_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvPOTREROS.EditingControlShowing

        Dim col As Integer = dgvPOTREROS.CurrentCell.ColumnIndex

        If col = CantidadHa Or col = ValoxBolo Then

            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtRetiro
        End If

    End Sub

    Private Sub ValidaTxtRetiro(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvPOTREROS.CurrentCell.ColumnIndex

        If columna = ValoxBolo Then ' 6 
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            End If
        End If

        If columna = CantidadHa Then ' 6 
            If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False Then
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        'cboCentros.SelectedIndex = 0
    End Sub
    Private Sub CboLLenaBolos()
        If General.TipoBolo.NroRegistros = 0 Then Exit Sub

        cboBolo.Items.Clear()

        Dim i As Integer

        For i = 0 To General.TipoBolo.NroRegistros - 1
            cboBolo.Items.Add(General.TipoBolo.Nombre(i))
        Next

        cboBolo.SelectedIndex = 0
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ' BuscarEsilaje()
    End Sub
    Public Function BuscarEsilaje(ByVal Fecha As Date, ByVal centro As String, ByVal TipoEnsilaje As String) As Boolean
        BuscarEsilaje = False

        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spPraderas_ListadoModificacionEnsilaje", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Item", TipoEnsilaje)
            cmd.Parameters.AddWithValue("@Centro", centro)
            cmd.Parameters.AddWithValue("@Fecha", Fecha)
            'cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            'cmd.Parameters.AddWithValue("@Item", General.TipoBolo.Codigo(cboBolo.SelectedIndex))
            'cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
            'cmd.Parameters.AddWithValue("@Fecha", dtpFechaDesde.Value)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            Dim i As Integer = 0


            dgvPOTREROS.Rows.Clear()

            While rdr.Read()
                BuscarEsilaje = True
                Dim valor As Integer = rdr("EnsilajeValUnit")
                Dim total As Integer = rdr("EnsilajeValTot")
                If total <> 0 Then
                    total = Format(total, "#,#")
                End If
                dgvPOTREROS.Rows.Add(rdr("EnsilajePotrero"), rdr("CentroNom"), rdr("EnsilajeNomItm"), rdr("EnsilajeItmUM"), Format(rdr("EnsilajeCantidad"), "#,#"), Format(rdr("EnsilajeHaUtil"), "##,##0.00"), Format(rdr("EnsilajeRend"), "##,##0.00"), Format(valor, "#,#"), total, rdr("EnsilajeCentro").ToString.Trim, rdr("EnsilajeCodItm").ToString.Trim, rdr("EnsilajeFecha"))


                i = i + 1
            End While

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Function
    Private Sub dgvCalidadLeche_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPOTREROS.CellValueChanged
        Dim n As Integer = dgvPOTREROS.RowCount
        For i = 0 To dgvPOTREROS.Rows.Count - 1
            For x = 0 To n - 1
                '  If dgvPOTREROS.Rows(i).Cells(4).Value <> 0 And dgvPOTREROS.Rows(i).Cells(5).Value <> 0 Then
                'If dgvPOTREROS.Rows(i).Cells(4).Value = "" Then
                '    dgvPOTREROS.Rows(i).Cells(4).Value = 0
                'End If
                Dim canti As String = dgvPOTREROS.Rows(i).Cells(4).Value
                If canti = "" Then
                    dgvPOTREROS.Rows(i).Cells(4).Value = 0
                End If
                Dim val As String = dgvPOTREROS.Rows(i).Cells(7).Value
                If val = "" Then
                    dgvPOTREROS.Rows(i).Cells(7).Value = 0
                End If
                Dim cant As Double = dgvPOTREROS.Rows(i).Cells(4).Value
                    Dim ha As Double = dgvPOTREROS.Rows(i).Cells(5).Value
                    Dim Rendimiento As Double = cant / ha

                ' End If
                ' If dgvPOTREROS.Rows(i).Cells(4).Value <> 0 And dgvPOTREROS.Rows(i).Cells(7).Value <> 0 Then
                'Dim cant As Double = dgvPOTREROS.Rows(i).Cells(4).Value
                Dim valor As Double = dgvPOTREROS.Rows(i).Cells(7).Value
                Dim total As Double = cant * valor
                If total = 0 Then
                    dgvPOTREROS.Rows(i).Cells(8).Value = total
                Else
                    dgvPOTREROS.Rows(i).Cells(8).Value = Format(total, "#,#")
                End If
                If Rendimiento = 0 Then
                    dgvPOTREROS.Rows(i).Cells(6).Value = Rendimiento
                Else
                    dgvPOTREROS.Rows(i).Cells(6).Value = Format(Rendimiento, "##,##0.00")
                End If

                ' End If
            Next
        Next
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Fech.Click

    End Sub
    Private Sub EnviaEmail()
        ''SP ENVIA EMAIL''
        Dim Cent As String = ""
        Dim Item As String = ""
        Dim fecha_ As String = ""
        Cent = dgvPOTREROS.Rows(0).Cells(9).Value.ToString.Trim
        Item = dgvPOTREROS.Rows(0).Cells(10).Value.ToString.Trim
        fecha_ = dgvPOTREROS.Rows(0).Cells(11).Value.ToString.Trim

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_EnvioMailEnsilajeModificados", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Centro", Cent)
        cmd.Parameters.AddWithValue("@Item", Item)
        cmd.Parameters.AddWithValue("@Fecha", fecha_)


        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR ENVIA EMAIL")
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click

        Dim n As Integer = dgvPOTREROS.RowCount
        For i = 0 To dgvPOTREROS.Rows.Count - 1
            For x = 0 To n - 1
                Dim cell4 As String = dgvPOTREROS.Rows(i).Cells(4).Value
                Dim cell7 As String = dgvPOTREROS.Rows(i).Cells(7).Value
                If cell4 = "" Or cell7 = "" Then
                    If MsgBox("No Puede dejar celdas en blanco", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        Exit Sub
                    End If
                End If


            Next
        Next
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        GrabarSilos()
        Me.Close()
        frmSilos.btnBuscar.PerformClick()
    End Sub

    Private Function GrabarSilos() As Boolean
        GrabarSilos = False
        Cursor.Current = Cursors.WaitCursor
        Dim EnviaMail As Integer = 0
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_ModificarValorBolos", con)
        Dim SRVTRANS As SqlTransaction = Nothing
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try

        Dim i As Integer = 0
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean

        For i = 0 To dgvPOTREROS.Rows.Count - 1
            Dim rend As Double = dgvPOTREROS.Rows(i).Cells(6).Value
            Dim can As Integer = dgvPOTREROS.Rows(i).Cells(4).Value
            Dim valuni As Integer = dgvPOTREROS.Rows(i).Cells(7).Value
            Dim tol As Integer = dgvPOTREROS.Rows(i).Cells(8).Value


            'If cob > 0 Then ' mi > 0 And mf > 0 And clicks > 0 Then
            cmd.Parameters.Clear()
            'cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", dgvPOTREROS.Rows(i).Cells(9).Value.ToString.Trim)
            cmd.Parameters.AddWithValue("@Fecha", dgvPOTREROS.Rows(i).Cells(11).Value.ToString.Trim)
            cmd.Parameters.AddWithValue("@Item", dgvPOTREROS.Rows(i).Cells(10).Value.ToString.Trim)
            cmd.Parameters.AddWithValue("@Potrero", dgvPOTREROS.Rows(i).Cells(0).Value.ToString.Trim)
            cmd.Parameters.AddWithValue("@EnsilajeCantidad", can)
            cmd.Parameters.AddWithValue("@EnsilajeRend", rend)
            cmd.Parameters.AddWithValue("@EnsilajeValUnit", valuni)
            cmd.Parameters.AddWithValue("@EnsilajeValTot", tol)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            '
            cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

            Try
                cmd.Transaction = SRVTRANS
                Result = cmd.ExecuteNonQuery()

                vret = cmd.Parameters("@RetValor").Value
                mret = cmd.Parameters("@RetMensage").Value

                ''verificamos error con un valor igual a -1
                If vret = -1 Then
                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If

                    HayError = True
                    Exit For
                End If
                If vret = 3 Then
                    EnviaMail = 1
                End If
                HayError = False
                ''si todo sale ok guardamos el nuevo codigo del grupo de celos
                'GrabarGrupoParto = True

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                HayError = True
                Exit For
            End Try
            ''End If
        Next

        'si hay error hasta aqui salimos
        If HayError = False Then
            SRVTRANS.Commit()
            GrabarSilos = True
        Else
            SRVTRANS.Rollback()
            GrabarSilos = False

        End If
        If EnviaMail = 1 Then
            EnviaEmail()
        End If
        con.Close()
        Cursor.Current = Cursors.Default
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Valor.Text > "" Then

            For i = 0 To dgvPOTREROS.Rows.Count - 1
                Dim val As Integer = Valor.Text
                dgvPOTREROS.Rows(i).Cells(7).Value = Format(val, "#,#")
            Next

        End If
    End Sub
End Class