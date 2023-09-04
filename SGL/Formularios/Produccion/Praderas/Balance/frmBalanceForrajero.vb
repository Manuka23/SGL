Imports System.Data.SqlClient
Public Class frmBalanceForrajero
    Dim actualiza As Integer = -1
    Dim ExisteBalance As Integer = -1
    Private GuardaCobertura As String = ""
    Private GuardaLinbea As Integer
    Dim Fnbalance As New FnBalanceForrajero

    Private FnBalanceForrajero As New FnBalanceForrajero
    Dim HectareasCentro As Double
    Dim Cobertura As Double = -1
    Dim activar As String = -1
    Dim cen As Integer
    Dim existe As Integer = -1
    Dim a As Integer = 1
    Dim b As Integer = -1
    Dim uno, dos, tres, cuatro, cinco, seis, siete, ocho, nueve, dies, once, doce, trece, catorc, quin As Integer


    Private Sub BuscarExistente()
        Cursor.Current = Cursors.WaitCursor
        'ChartCobDia.Titles(0).Text = "Cobertura de Pasto " + Format(dtpFecha.Value, "dd-MM-yyyy")
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_BuscarExistente", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                If rdr("orden") <> 0 Then
                    ExisteBalance = 1

                End If
                lblFecha.Text = Format(rdr("FechaIngreso"), "dd-MM-yyyy")
            End While

            rdr.Close()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        Cursor.Current = Cursors.WaitCursor
    End Sub




    Private Sub CboLLenaCentros()
        If General.CentrosUsuarioSalas.NroRegistros = -1 Then Exit Sub

        cboCentros.Items.Clear()
        Dim i As Integer

        For i = 0 To General.CentrosUsuarioSalas.NroRegistros - 1

            cboCentros.Items.Add(General.CentrosUsuarioSalas.Nombre(i))


        Next

    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        grabar()
        '  reset()

    End Sub

    Private Sub GrabarSemanas(ByVal Orden As String, ByVal Valor As Decimal, ByVal Semana As Integer)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBalanceForrajero_NewGrabarSemana", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Orden", Orden)
        cmd.Parameters.AddWithValue("@Valor", Valor)
        cmd.Parameters.AddWithValue("@Semana", Semana)
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

            'If vret > -1 Then
            '    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            '    End If
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Sub

    Private Sub GrabarMensual(ByVal Orden As String, ByVal Valor As Decimal, ByVal año As Integer, ByVal mes As Integer)

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBalanceForrajero_NewGrabarMensual", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Orden", Orden)
        cmd.Parameters.AddWithValue("@Valor", Valor)
        cmd.Parameters.AddWithValue("@Ano", año)
        cmd.Parameters.AddWithValue("@Mes", mes)
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

            'If vret > -1 Then
            '    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            '    End If
            'End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Sub




    Private Sub frmBalanceForrajero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        General.CentrosUsuarioSalas.Cargar()
        CboLLenaCentros()
        cboCentros.SelectedIndex = 0
        activar = 1
        rbmensual.Checked = True

        llenado()
        unCheck()
        ' BuscarExistente()
    End Sub

    Private Sub Check()

        Cursor.Current = Cursors.WaitCursor
        pbProcesa.Maximum = 25
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        pbProcesa.Value = 1
        dgvAreaSecaSemanal.Visible = True
        pbProcesa.Value = 2
        dgvMasaSemanal.Visible = True
        pbProcesa.Value = 3
        dgvPraderaSemanal.Visible = True
        pbProcesa.Value = 4
        dgvProduccionSemanal.Visible = True
        pbProcesa.Value = 5
        dgvRequerimientosSemanal.Visible = True
        pbProcesa.Value = 6
        dgbcoberturaSemanal.Visible = True
        pbProcesa.Value = 7
        BuscarSemana(1)
        pbProcesa.Value = 8
        BuscarSemana(2)
        pbProcesa.Value = 9
        BuscarSemana(5)
        pbProcesa.Value = 10
        BuscarSemana(6)
        pbProcesa.Value = 11
        BuscarSemana(7)
        pbProcesa.Value = 12
        BuscarSemana(8)
        pbProcesa.Value = 13
        BuscarSemana(9)
        pbProcesa.Value = 14
        BuscarSemana(11)
        pbProcesa.Value = 15
        BuscarSemana(20)
        pbProcesa.Value = 16
        BuscarSemana(21)
        pbProcesa.Value = 17
        BuscarSemana(22)
        pbProcesa.Value = 18
        BuscarSemana(23)
        pbProcesa.Value = 19
        BuscarSemana(24)
        pbProcesa.Value = 20
        BuscarSemana(25)
        pbProcesa.Value = 21
        BuscarSemana(26)
        pbProcesa.Value = 22
        BuscarSemana(27)
        pbProcesa.Value = 23
        BuscarSemana(37)
        BuscarSemana(38)
        pbProcesa.Value = 24
        dgvConsumoPromedio.Rows.Clear()
        dgvCoberturaPromedio.Rows.Clear()
        BuscarSemanalMensual(51)
        BuscarSemanalMensual(39)
        BuscarSemanalMensual(40)
        BuscarSemanalMensual(41)
        BuscarSemanalMensual(42)
        BuscarSemanalMensual(43)
        BuscarSemanalMensual(44)
        BuscarSemanalMensual(45)
        BuscarSemanalMensual(46)
        BuscarSemanalMensual(47)
        BuscarSemanalMensual(48)
        BuscarSemanalMensual(49)
        BuscarSemanalMensual(50)


        BuscarFEchas()


        pbProcesa.Value = 25
        pnlProcesa.Visible = False
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BuscarSemana(ByVal Orden As String)
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_newBuscarDatosSemanales", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
            cmd.Parameters.AddWithValue("@Orden", Orden)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                Select Case Orden

                    Case 1
                        dgvPraderaSemanal.Rows.Add(Orden, "Superficie Total", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 2
                        dgvPraderaSemanal.Rows.Add(Orden, "Tasa Crecimiento", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 5
                        dgvMasaSemanal.Rows.Add(Orden, "Vacas en Produccion", Format(rdr("-4"), “##,##0"), Format(rdr("-3"), “##,##0"), Format(rdr("-2"), “##,##0"), Format(rdr("-1"), “##,##0"), Format(rdr("0"), “##,##0"), Format(rdr("1"), “##,##0"), Format(rdr("2"), “##,##0"), Format(rdr("3"), “##,##0"), Format(rdr("4"), “##,##0"), Format(rdr("5"), “##,##0"), Format(rdr("6"), “##,##0"), Format(rdr("7"), “##,##0"))
                    Case 6
                        dgvMasaSemanal.Rows.Add(Orden, "Toros", Format(rdr("-4"), “##,##0"), Format(rdr("-3"), “##,##0"), Format(rdr("-2"), “##,##0"), Format(rdr("-1"), “##,##0"), Format(rdr("0"), “##,##0"), Format(rdr("1"), “##,##0"), Format(rdr("2"), “##,##0"), Format(rdr("3"), “##,##0"), Format(rdr("4"), “##,##0"), Format(rdr("5"), “##,##0"), Format(rdr("6"), “##,##0"), Format(rdr("7"), “##,##0"))
                    Case 7
                        dgvMasaSemanal.Rows.Add(Orden, "Vacas Secas", Format(rdr("-4"), “##,##0"), Format(rdr("-3"), “##,##0"), Format(rdr("-2"), “##,##0"), Format(rdr("-1"), “##,##0"), Format(rdr("0"), “##,##0"), Format(rdr("1"), “##,##0"), Format(rdr("2"), “##,##0"), Format(rdr("3"), “##,##0"), Format(rdr("4"), “##,##0"), Format(rdr("5"), “##,##0"), Format(rdr("6"), “##,##0"), Format(rdr("7"), “##,##0"))
                    Case 8
                        dgvMasaSemanal.Rows.Add(Orden, "Saldo Total", Format(rdr("-4"), “##,##0"), Format(rdr("-3"), “##,##0"), Format(rdr("-2"), “##,##0"), Format(rdr("-1"), “##,##0"), Format(rdr("0"), “##,##0"), Format(rdr("1"), “##,##0"), Format(rdr("2"), “##,##0"), Format(rdr("3"), “##,##0"), Format(rdr("4"), “##,##0"), Format(rdr("5"), “##,##0"), Format(rdr("6"), “##,##0"), Format(rdr("7"), “##,##0"))
                    Case 9
                        dgvRequerimientosSemanal.Rows.Add(Orden, "Req. Vacas Produccion", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 11
                        dgvRequerimientosSemanal.Rows.Add(Orden, "Req. Vacas Secas", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 20
                        dgvProduccionSemanal.Rows.Add(Orden, "Concentrado", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 21
                        dgvProduccionSemanal.Rows.Add(Orden, "Silo", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 22
                        dgvProduccionSemanal.Rows.Add(Orden, "Otros Suplementos", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 23
                        dgvProduccionSemanal.Rows.Add(Orden, "Cultivos", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 24
                        dgvAreaSecaSemanal.Rows.Add(Orden, "Concentrado", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 25
                        dgvAreaSecaSemanal.Rows.Add(Orden, "Silo", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 26
                        dgvAreaSecaSemanal.Rows.Add(Orden, "Otros Suplementos", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 27
                        dgvAreaSecaSemanal.Rows.Add(Orden, "Cultivos", rdr("-4"), rdr("-3"), rdr("-2"), rdr("-1"), rdr("0"), rdr("1"), rdr("2"), rdr("3"), rdr("4"), rdr("5"), rdr("6"), rdr("7"))
                    Case 37
                        dgbcoberturaSemanal.Rows.Add(Orden, "Cob.", Format(rdr("-4"), “##,##0"), Format(rdr("-3"), “##,##0"), Format(rdr("-2"), “##,##0"), Format(rdr("-1"), “##,##0"), Format(rdr("0"), “##,##0"), Format(rdr("1"), “##,##0"), Format(rdr("2"), “##,##0"), Format(rdr("3"), “##,##0"), Format(rdr("4"), “##,##0"), Format(rdr("5"), “##,##0"), Format(rdr("6"), “##,##0"), Format(rdr("7"), “##,##0"))
                    Case 38
                        dgbcoberturaSemanal.Rows.Add(Orden, "Silos.", Format(rdr("-4"), “##,##0"), Format(rdr("-3"), “##,##0"), Format(rdr("-2"), “##,##0"), Format(rdr("-1"), “##,##0"), Format(rdr("0"), “##,##0"), Format(rdr("1"), “##,##0"), Format(rdr("2"), “##,##0"), Format(rdr("3"), “##,##0"), Format(rdr("4"), “##,##0"), Format(rdr("5"), “##,##0"), Format(rdr("6"), “##,##0"), Format(rdr("7"), “##,##0"))

                End Select

            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub BuscarFEchas()
        Cursor.Current = Cursors.WaitCursor
        Dim cober As String
        Dim i As Integer = 2

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_newBuscarFechas", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
            cmd.CommandTimeout = 30000
            con.Open()
            rdr = cmd.ExecuteReader()
            cober = 0

            While rdr.Read()
                dgvConsumoPromedio.Columns(i).HeaderText = rdr("Fecha")
                dgvCoberturaPromedio.Columns(i).HeaderText = rdr("Fecha")
                dgvPraderaSemanal.Columns(i).HeaderText = rdr("Fecha")
                dgvMasaSemanal.Columns(i).HeaderText = rdr("Fecha")
                dgvRequerimientosSemanal.Columns(i).HeaderText = rdr("Fecha")
                dgvProduccionSemanal.Columns(i).HeaderText = rdr("Fecha")
                dgvAreaSecaSemanal.Columns(i).HeaderText = rdr("Fecha")
                dgbcoberturaSemanal.Columns(i).HeaderText = rdr("Fecha")
                i = i + 1
            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Sub unCheck()

        dgvAreaSecaSemanal.Rows.Clear()
        dgvMasaSemanal.Rows.Clear()
        dgvPraderaSemanal.Rows.Clear()
        dgvProduccionSemanal.Rows.Clear()
        dgvRequerimientosSemanal.Rows.Clear()
        dgbcoberturaSemanal.Rows.Clear()

        'dgvConsumoPromedio.Rows.Clear()
        'dgvCoberturaPromedio.Rows.Clear()


        dgbcoberturaSemanal.Visible = False
        dgvAreaSecaSemanal.Visible = False
        dgvMasaSemanal.Visible = False
        dgvPraderaSemanal.Visible = False
        dgvProduccionSemanal.Visible = False
        dgvRequerimientosSemanal.Visible = False
    End Sub

    Private Sub dgvPOTREROS_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvPraderas.CellBeginEdit
        '    If actualiza = 1 Then
        GuardaCobertura = dgvPraderas.Rows(e.RowIndex).Cells(1).Value
        GuardaLinbea = e.RowIndex
        '   End If
    End Sub


    Private Sub dgvAreaSecaSemanal_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvAreaSecaSemanal.EditingControlShowing
        Dim col As Integer = dgvAreaSecaSemanal.CurrentCell.ColumnIndex
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidadgvAreaSecaSemanal
    End Sub

    Private Sub ValidadgvAreaSecaSemanal(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvAreaSecaSemanal.CurrentCell.ColumnIndex
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
    End Sub


    Private Sub dgvMasaSemanal_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvMasaSemanal.EditingControlShowing
        Dim col As Integer = dgvMasaSemanal.CurrentCell.ColumnIndex
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidadgvMasaSemanal
    End Sub

    Private Sub ValidadgvMasaSemanal(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvMasaSemanal.CurrentCell.ColumnIndex
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
    End Sub



    Private Sub dgvProduccionSemanal_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvProduccionSemanal.EditingControlShowing
        Dim col As Integer = dgvProduccionSemanal.CurrentCell.ColumnIndex
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidadgvProduccionSemanal
    End Sub

    Private Sub ValidadgvProduccionSemanal(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvProduccionSemanal.CurrentCell.ColumnIndex
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
    End Sub


    Private Sub dgvRequerimientosSemanal_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRequerimientosSemanal.EditingControlShowing
        Dim col As Integer = dgvRequerimientosSemanal.CurrentCell.ColumnIndex
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidadgvRequerimientosSemanal
    End Sub

    Private Sub ValidadgvRequerimientosSemanal(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvRequerimientosSemanal.CurrentCell.ColumnIndex
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
    End Sub


    Private Sub dgbcoberturaSemanal_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgbcoberturaSemanal.EditingControlShowing
        Dim col As Integer = dgbcoberturaSemanal.CurrentCell.ColumnIndex
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidadgbcoberturaSemanal
    End Sub

    Private Sub ValidadgbcoberturaSemanal(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgbcoberturaSemanal.CurrentCell.ColumnIndex
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
    End Sub
    Private Sub dgvPraderaSemanal_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvPraderaSemanal.EditingControlShowing
        Dim col As Integer = dgvPraderaSemanal.CurrentCell.ColumnIndex
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidadgvPraderaSemanal
    End Sub

    Private Sub ValidadgvPraderaSemanal(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvPraderaSemanal.CurrentCell.ColumnIndex
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
    End Sub









    Private Sub dgvPOTREROS_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvPraderas.EditingControlShowing
        Dim col As Integer = dgvPraderas.CurrentCell.ColumnIndex
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtRetiro
    End Sub

    Private Sub ValidaTxtRetiro(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvPraderas.CurrentCell.ColumnIndex
        'If columna = 2 Or columna = 3 Or columna = 4 Or columna = 7 Then
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
        ' End If
    End Sub
    Private Sub BuscarMensual(ByVal Orden As Integer)
        Cursor.Current = Cursors.WaitCursor

        'ChartCobDia.Titles(0).Text = "Cobertura de Pasto " + Format(dtpFecha.Value, "dd-MM-yyyy")
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_newBuscarDatosMes", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
            cmd.Parameters.AddWithValue("@Orden", Orden)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                Select Case Orden

                    Case 1
                        dgvPraderas.Rows.Add(rdr("orden"), "Superficie Total", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 2
                        dgvPraderas.Rows.Add(rdr("orden"), "Tasa Crecimiento", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 5
                        dgvDesarrollo.Rows.Add(rdr("orden"), "Vacas en Produccion", Format(rdr("20197"), “##,##0"), Format(rdr("20198"), “##,##0"), Format(rdr("20199"), “##,##0"), Format(rdr("201910"), “##,##0"), Format(rdr("201911"), “##,##0"), Format(rdr("201912"), “##,##0"), Format(rdr("20201"), “##,##0"), Format(rdr("20202"), “##,##0"), Format(rdr("20203"), “##,##0"), Format(rdr("20204"), “##,##0"), Format(rdr("20205"), “##,##0"), Format(rdr("20206"), “##,##0"), Format(rdr("20207"), “##,##0"), Format(rdr("20208"), “##,##0"), Format(rdr("20209"), “##,##0"))
                    Case 6
                        dgvDesarrollo.Rows.Add(rdr("orden"), "Toros", Format(rdr("20197"), “##,##0"), Format(rdr("20198"), “##,##0"), Format(rdr("20199"), “##,##0"), Format(rdr("201910"), “##,##0"), Format(rdr("201911"), “##,##0"), Format(rdr("201912"), “##,##0"), Format(rdr("20201"), “##,##0"), Format(rdr("20202"), “##,##0"), Format(rdr("20203"), “##,##0"), Format(rdr("20204"), “##,##0"), Format(rdr("20205"), “##,##0"), Format(rdr("20206"), “##,##0"), Format(rdr("20207"), “##,##0"), Format(rdr("20208"), “##,##0"), Format(rdr("20209"), “##,##0"))
                    Case 7
                        dgvDesarrollo.Rows.Add(rdr("orden"), "Vacas Secas", Format(rdr("20197"), “##,##0"), Format(rdr("20198"), “##,##0"), Format(rdr("20199"), “##,##0"), Format(rdr("201910"), “##,##0"), Format(rdr("201911"), “##,##0"), Format(rdr("201912"), “##,##0"), Format(rdr("20201"), “##,##0"), Format(rdr("20202"), “##,##0"), Format(rdr("20203"), “##,##0"), Format(rdr("20204"), “##,##0"), Format(rdr("20205"), “##,##0"), Format(rdr("20206"), “##,##0"), Format(rdr("20207"), “##,##0"), Format(rdr("20208"), “##,##0"), Format(rdr("20209"), “##,##0"))
                    Case 8
                        dgvDesarrollo.Rows.Add(rdr("orden"), "Saldo Total", Format(rdr("20197"), “##,##0"), Format(rdr("20198"), “##,##0"), Format(rdr("20199"), “##,##0"), Format(rdr("201910"), “##,##0"), Format(rdr("201911"), “##,##0"), Format(rdr("201912"), “##,##0"), Format(rdr("20201"), “##,##0"), Format(rdr("20202"), “##,##0"), Format(rdr("20203"), “##,##0"), Format(rdr("20204"), “##,##0"), Format(rdr("20205"), “##,##0"), Format(rdr("20206"), “##,##0"), Format(rdr("20207"), “##,##0"), Format(rdr("20208"), “##,##0"), Format(rdr("20209"), “##,##0"))
                    Case 9
                        dgvRequerimientos.Rows.Add(rdr("orden"), "Req. Vacas Produccion", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 11
                        dgvRequerimientos.Rows.Add(rdr("orden"), "Req. Vacas Secas", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 20
                        DgvAlimentos.Rows.Add(rdr("orden"), "Concentrado", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 21
                        DgvAlimentos.Rows.Add(rdr("orden"), "Silo", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 22
                        DgvAlimentos.Rows.Add(rdr("orden"), "Otros Suplementos", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 23
                        DgvAlimentos.Rows.Add(rdr("orden"), "Cultivos", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 24
                        DgvAlimentosSecas.Rows.Add(rdr("orden"), "Concentrado", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 25
                        DgvAlimentosSecas.Rows.Add(rdr("orden"), "Silo", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 26
                        DgvAlimentosSecas.Rows.Add(rdr("orden"), "Otros Suplementos", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 27
                        DgvAlimentosSecas.Rows.Add(rdr("orden"), "Cultivos", rdr("20197"), rdr("20198"), rdr("20199"), rdr("201910"), rdr("201911"), rdr("201912"), rdr("20201"), rdr("20202"), rdr("20203"), rdr("20204"), rdr("20205"), rdr("20206"), rdr("20207"), rdr("20208"), rdr("20209"))
                    Case 37
                        DgvCobertura.Rows.Add(rdr("orden"), "Cob.", Format(rdr("20197"), “##,##0"), Format(rdr("20198"), “##,##0"), Format(rdr("20199"), “##,##0"), Format(rdr("201910"), “##,##0"), Format(rdr("201911"), “##,##0"), Format(rdr("201912"), “##,##0"), Format(rdr("20201"), “##,##0"), Format(rdr("20202"), “##,##0"), Format(rdr("20203"), “##,##0"), Format(rdr("20204"), “##,##0"), Format(rdr("20205"), “##,##0"), Format(rdr("20206"), “##,##0"), Format(rdr("20207"), “##,##0"), Format(rdr("20208"), “##,##0"), Format(rdr("20209"), “##,##0"))
                    Case 38
                        DgvCobertura.Rows.Add(rdr("orden"), "Silos.", Format(rdr("20197"), “##,##0"), Format(rdr("20198"), “##,##0"), Format(rdr("20199"), “##,##0"), Format(rdr("201910"), “##,##0"), Format(rdr("201911"), “##,##0"), Format(rdr("201912"), “##,##0"), Format(rdr("20201"), “##,##0"), Format(rdr("20202"), “##,##0"), Format(rdr("20203"), “##,##0"), Format(rdr("20204"), “##,##0"), Format(rdr("20205"), “##,##0"), Format(rdr("20206"), “##,##0"), Format(rdr("20207"), “##,##0"), Format(rdr("20208"), “##,##0"), Format(rdr("20209"), “##,##0"))

                End Select

            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        Cursor.Current = Cursors.WaitCursor
    End Sub
    Public Sub llenado()

        BuscarMensual(1)
        BuscarMensual(2)
        BuscarMensual(5)
        BuscarMensual(6)
        BuscarMensual(7)
        BuscarMensual(8)
        BuscarMensual(9)
        BuscarMensual(11)
        BuscarMensual(20)
        BuscarMensual(21)
        BuscarMensual(22)
        BuscarMensual(23)
        BuscarMensual(24)
        BuscarMensual(25)
        BuscarMensual(26)
        BuscarMensual(27)
        BuscarMensual(37)
        BuscarMensual(38)
        BuscarSemanalMensual(51)
        BuscarSemanalMensual(39)
        BuscarSemanalMensual(40)
        BuscarSemanalMensual(41)
        BuscarSemanalMensual(42)
        BuscarSemanalMensual(43)
        BuscarSemanalMensual(44)
        BuscarSemanalMensual(45)
        BuscarSemanalMensual(46)
        BuscarSemanalMensual(47)
        BuscarSemanalMensual(48)
        BuscarSemanalMensual(49)
        BuscarSemanalMensual(50)


        BuscarConsumoDiario("39", "Series1")
        BuscarConsumoDiario("40", "Series2")
        BuscarConsumoDiario("41", "Series3")
        BuscarConsumoDiario("43", "Series4")
        BuscarConsumoDiario("42", "Series5")
        BuscarConsumoDiario("45", "Series6")
        BuscarConsumoDiario("51", "Series7")

        BuscarConsumoMensual("39", "Series1")
        BuscarConsumoMensual("40", "Series2")
        BuscarConsumoMensual("41", "Series3")
        BuscarConsumoMensual("43", "Series4")
        BuscarConsumoMensual("42", "Series5")
        BuscarConsumoMensual("45", "Series6")
        BuscarConsumoMensual("51", "Series7")

        BuscarCoberturaPromedio("47", "Series1")
        BuscarCoberturaPromedio("48", "Series2")
        BuscarCoberturaPromedio("49", "Series3")
        BuscarCoberturaPromedio("50", "Series4")


        BuscarConberMensual("47", "Series1")
        BuscarConberMensual("48", "Series2")
        BuscarConberMensual("49", "Series3")
        BuscarConberMensual("50", "Series4")
        BuscarFEchas()
    End Sub

    Private Sub BuscarConberMensual(ByVal Orden As String, ByVal Grafico As String)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_newBuscarDatosMensuales", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Orden", Orden)
            cmd.Parameters.AddWithValue("@centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))

            con.Open()
            rdr = cmd.ExecuteReader()

            ChartCoberturaMensual.Series(Grafico).Points.Clear()
            ChartCoberturaMensual.Series(Grafico).Points.DataBindXY(rdr, "Fecha", rdr, "Valor")

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub


    Private Sub BuscarConsumoMensual(ByVal Orden As String, ByVal Grafico As String)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_newBuscarDatosMensuales", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Orden", Orden)
            cmd.Parameters.AddWithValue("@centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))

            con.Open()
            rdr = cmd.ExecuteReader()

            ChartConsumoMensual.Series(Grafico).Points.Clear()
            ChartConsumoMensual.Series(Grafico).Points.DataBindXY(rdr, "Fecha", rdr, "Valor")

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub



    Private Sub BuscarSemanalMensual(ByVal Orden As String)
        Cursor.Current = Cursors.WaitCursor

        'ChartCobDia.Titles(0).Text = "Cobertura de Pasto " + Format(dtpFecha.Value, "dd-MM-yyyy")
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_newBuscarDatosSemanales", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
            cmd.Parameters.AddWithValue("@Orden", Orden)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                Select Case Orden
                    Case 51
                        dgvConsumoPromedio.Rows.Add(Orden, "Deficit", Format(rdr("-4"), "##,##0.0"), Format(rdr("-3"), "##,##0.0"), Format(rdr("-2"), "##,##0.0"), Format(rdr("-1"), "##,##0.0"), Format(rdr("0"), "##,##0.0"), Format(rdr("1"), "##,##0.0"), Format(rdr("2"), "##,##0.0"), Format(rdr("3"), "##,##0.0"), Format(rdr("4"), "##,##0.0"), Format(rdr("5"), "##,##0.0"), Format(rdr("6"), "##,##0.0"), Format(rdr("7"), "##,##0.0"))
                    Case 39
                        dgvConsumoPromedio.Rows.Add(Orden, "Pradera", Format(rdr("-4"), "##,##0.0"), Format(rdr("-3"), "##,##0.0"), Format(rdr("-2"), "##,##0.0"), Format(rdr("-1"), "##,##0.0"), Format(rdr("0"), "##,##0.0"), Format(rdr("1"), "##,##0.0"), Format(rdr("2"), "##,##0.0"), Format(rdr("3"), "##,##0.0"), Format(rdr("4"), "##,##0.0"), Format(rdr("5"), "##,##0.0"), Format(rdr("6"), "##,##0.0"), Format(rdr("7"), "##,##0.0"))
                    Case 40
                        dgvConsumoPromedio.Rows.Add(Orden, "Concentrado", Format(rdr("-4"), "##,##0.0"), Format(rdr("-3"), "##,##0.0"), Format(rdr("-2"), "##,##0.0"), Format(rdr("-1"), "##,##0.0"), Format(rdr("0"), "##,##0.0"), Format(rdr("1"), "##,##0.0"), Format(rdr("2"), "##,##0.0"), Format(rdr("3"), "##,##0.0"), Format(rdr("4"), "##,##0.0"), Format(rdr("5"), "##,##0.0"), Format(rdr("6"), "##,##0.0"), Format(rdr("7"), "##,##0.0"))
                    Case 41
                        dgvConsumoPromedio.Rows.Add(Orden, "Silo", Format(rdr("-4"), "##,##0.0"), Format(rdr("-3"), "##,##0.0"), Format(rdr("-2"), "##,##0.0"), Format(rdr("-1"), "##,##0.0"), Format(rdr("0"), "##,##0.0"), Format(rdr("1"), "##,##0.0"), Format(rdr("2"), "##,##0.0"), Format(rdr("3"), "##,##0.0"), Format(rdr("4"), "##,##0.0"), Format(rdr("5"), "##,##0.0"), Format(rdr("6"), "##,##0.0"), Format(rdr("7"), "##,##0.0"))
                    Case 42
                        dgvConsumoPromedio.Rows.Add(Orden, "Otros Sup", Format(rdr("-4"), "##,##0.0"), Format(rdr("-3"), "##,##0.0"), Format(rdr("-2"), "##,##0.0"), Format(rdr("-1"), "##,##0.0"), Format(rdr("0"), "##,##0.0"), Format(rdr("1"), "##,##0.0"), Format(rdr("2"), "##,##0.0"), Format(rdr("3"), "##,##0.0"), Format(rdr("4"), "##,##0.0"), Format(rdr("5"), "##,##0.0"), Format(rdr("6"), "##,##0.0"), Format(rdr("7"), "##,##0.0"))
                    Case 43
                        dgvConsumoPromedio.Rows.Add(Orden, "Cultivo", Format(rdr("-4"), "##,##0.0"), Format(rdr("-3"), "##,##0.0"), Format(rdr("-2"), "##,##0.0"), Format(rdr("-1"), "##,##0.0"), Format(rdr("0"), "##,##0.0"), Format(rdr("1"), "##,##0.0"), Format(rdr("2"), "##,##0.0"), Format(rdr("3"), "##,##0.0"), Format(rdr("4"), "##,##0.0"), Format(rdr("5"), "##,##0.0"), Format(rdr("6"), "##,##0.0"), Format(rdr("7"), "##,##0.0"))
                    Case 44
                        dgvConsumoPromedio.Rows.Add(Orden, "Total Oferta", Format(rdr("-4"), "##,##0.0"), Format(rdr("-3"), "##,##0.0"), Format(rdr("-2"), "##,##0.0"), Format(rdr("-1"), "##,##0.0"), Format(rdr("0"), "##,##0.0"), Format(rdr("1"), "##,##0.0"), Format(rdr("2"), "##,##0.0"), Format(rdr("3"), "##,##0.0"), Format(rdr("4"), "##,##0.0"), Format(rdr("5"), "##,##0.0"), Format(rdr("6"), "##,##0.0"), Format(rdr("7"), "##,##0.0"))
                    Case 45
                        dgvConsumoPromedio.Rows.Add(Orden, "Req. Total", Format(rdr("-4"), "##,##0.0"), Format(rdr("-3"), "##,##0.0"), Format(rdr("-2"), "##,##0.0"), Format(rdr("-1"), "##,##0.0"), Format(rdr("0"), "##,##0.0"), Format(rdr("1"), "##,##0.0"), Format(rdr("2"), "##,##0.0"), Format(rdr("3"), "##,##0.0"), Format(rdr("4"), "##,##0.0"), Format(rdr("5"), "##,##0.0"), Format(rdr("6"), "##,##0.0"), Format(rdr("7"), "##,##0.0"))
                    Case 46
                        dgvConsumoPromedio.Rows.Add(Orden, "Saldo", Format(rdr("-4"), "##,##0.0"), Format(rdr("-3"), "##,##0.0"), Format(rdr("-2"), "##,##0.0"), Format(rdr("-1"), "##,##0.0"), Format(rdr("0"), "##,##0.0"), Format(rdr("1"), "##,##0.0"), Format(rdr("2"), "##,##0.0"), Format(rdr("3"), "##,##0.0"), Format(rdr("4"), "##,##0.0"), Format(rdr("5"), "##,##0.0"), Format(rdr("6"), "##,##0.0"), Format(rdr("7"), "##,##0.0"))
                    Case 47
                        dgvCoberturaPromedio.Rows.Add(Orden, "Cobertura Objetivo", Format(rdr("-4"), "##,##0"), Format(rdr("-3"), "##,##0"), Format(rdr("-2"), "##,##0"), Format(rdr("-1"), "##,##0"), Format(rdr("0"), "##,##0"), Format(rdr("1"), "##,##0"), Format(rdr("2"), "##,##0"), Format(rdr("3"), "##,##0"), Format(rdr("4"), "##,##0"), Format(rdr("5"), "##,##0"), Format(rdr("6"), "##,##0"), Format(rdr("7"), "##,##0"))
                    Case 48
                        dgvCoberturaPromedio.Rows.Add(Orden, "Cobertura Real", Format(rdr("-4"), "##,##0"), Format(rdr("-3"), "##,##0"), Format(rdr("-2"), "##,##0"), Format(rdr("-1"), "##,##0"), Format(rdr("0"), "##,##0"), Format(rdr("1"), "##,##0"), Format(rdr("2"), "##,##0"), Format(rdr("3"), "##,##0"), Format(rdr("4"), "##,##0"), Format(rdr("5"), "##,##0"), Format(rdr("6"), "##,##0"), Format(rdr("7"), "##,##0"))
                    Case 49
                        dgvCoberturaPromedio.Rows.Add(Orden, "Crecimiento Objetivo", Format(rdr("-4"), "##,##0"), Format(rdr("-3"), "##,##0"), Format(rdr("-2"), "##,##0"), Format(rdr("-1"), "##,##0"), Format(rdr("0"), "##,##0"), Format(rdr("1"), "##,##0"), Format(rdr("2"), "##,##0"), Format(rdr("3"), "##,##0"), Format(rdr("4"), "##,##0"), Format(rdr("5"), "##,##0"), Format(rdr("6"), "##,##0"), Format(rdr("7"), "##,##0"))
                    Case 50
                        dgvCoberturaPromedio.Rows.Add(Orden, "Crecimiento Real", Format(rdr("-4"), "##,##0"), Format(rdr("-3"), "##,##0"), Format(rdr("-2"), "##,##0"), Format(rdr("-1"), "##,##0"), Format(rdr("0"), "##,##0"), Format(rdr("1"), "##,##0"), Format(rdr("2"), "##,##0"), Format(rdr("3"), "##,##0"), Format(rdr("4"), "##,##0"), Format(rdr("5"), "##,##0"), Format(rdr("6"), "##,##0"), Format(rdr("7"), "##,##0"))

                End Select

            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub





    Private Function GrabarBalance() As String
        Cursor.Current = Cursors.WaitCursor
        Dim cober As Decimal

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_newGrabarBalance", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()
            cober = 0
            While rdr.Read()
                cober = rdr("Valor")

            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        GrabarBalance = 0

        Cursor.Current = Cursors.WaitCursor
    End Function
    Public Sub grabar()
        Cursor.Current = Cursors.WaitCursor
        pbProcesa.Maximum = 14
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()
        pbProcesa.Value = 1
        pbProcesa.Value = 2
        pbProcesa.Value = 3
        pbProcesa.Value = 4

        GrabarBalanceCalculos()
        '  GrabarSemanal(51)
        pbProcesa.Value = 5


        If activar = 1 Then
            'If rbSemanal.Checked = True Then
            '    Check()
            'Else
            '    unCheck()
            '    reset()
            'End If

            If rbSemanal.Checked = True Then
                unCheck()
                dgvConsumoPromedio.Rows.Clear()
                dgvCoberturaPromedio.Rows.Clear()
                Check()

                ChartConsumo.Series("Series1").Points.Clear()
                ChartConsumo.Series("Series2").Points.Clear()
                ChartConsumo.Series("Series3").Points.Clear()
                ChartConsumo.Series("Series4").Points.Clear()
                ChartConsumo.Series("Series5").Points.Clear()
                ChartConsumo.Series("Series6").Points.Clear()

                ChartConsumoMensual.Series("Series1").Points.Clear()
                ChartConsumoMensual.Series("Series2").Points.Clear()
                ChartConsumoMensual.Series("Series3").Points.Clear()
                ChartConsumoMensual.Series("Series4").Points.Clear()
                ChartConsumoMensual.Series("Series5").Points.Clear()
                ChartConsumoMensual.Series("Series6").Points.Clear()

                ChartCobMes.Series("Series1").Points.Clear()
                ChartCobMes.Series("Series2").Points.Clear()
                ChartCobMes.Series("Series3").Points.Clear()
                ChartCobMes.Series("Series4").Points.Clear()

                ChartCoberturaMensual.Series("Series1").Points.Clear()
                ChartCoberturaMensual.Series("Series2").Points.Clear()
                ChartCoberturaMensual.Series("Series3").Points.Clear()
                ChartCoberturaMensual.Series("Series4").Points.Clear()

                BuscarConsumoDiario("39", "Series1")
                BuscarConsumoDiario("40", "Series2")
                BuscarConsumoDiario("41", "Series3")
                BuscarConsumoDiario("43", "Series4")
                BuscarConsumoDiario("42", "Series5")
                BuscarConsumoDiario("45", "Series6")
                BuscarConsumoDiario("51", "Series7")

                BuscarConsumoMensual("39", "Series1")
                BuscarConsumoMensual("40", "Series2")
                BuscarConsumoMensual("41", "Series3")
                BuscarConsumoMensual("43", "Series4")
                BuscarConsumoMensual("42", "Series5")
                BuscarConsumoMensual("45", "Series6")
                BuscarConsumoMensual("51", "Series7")

                BuscarCoberturaPromedio("47", "Series1")
                BuscarCoberturaPromedio("48", "Series2")
                BuscarCoberturaPromedio("49", "Series3")
                BuscarCoberturaPromedio("50", "Series4")


                BuscarConberMensual("47", "Series1")
                BuscarConberMensual("48", "Series2")
                BuscarConberMensual("49", "Series3")
                BuscarConberMensual("50", "Series4")



            Else
                unCheck()
                reset()
            End If


            ' reset()
        End If
        pbProcesa.Value = 14
        pnlProcesa.Visible = False
        Cursor.Current = Cursors.Default
    End Sub
    Private Function GrabarBalanceCalculos() As Boolean
        GrabarBalanceCalculos = False
        Dim i As Integer = 0
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBalanceForrajero_newProcesarDatos", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.CommandTimeout = 30000
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        GrabarBalanceCalculos = True
        Cursor.Current = Cursors.Default
    End Function
    Private Sub BuscarConsumoDiario(ByVal Orden As String, ByVal Grafico As String)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_NewBuscarConsumoPromedio", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Orden", Orden)
            cmd.Parameters.AddWithValue("@centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))

            con.Open()
            rdr = cmd.ExecuteReader()

            ChartConsumo.Series(Grafico).Points.Clear()
            ChartConsumo.Series(Grafico).Points.DataBindXY(rdr, "Fecha", rdr, "Valor")

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub
    Private Sub BuscarCoberturaPromedio(ByVal Orden As String, ByVal Grafico As String)
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_NewBuscarConsumoPromedio", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Orden", Orden)
            cmd.Parameters.AddWithValue("@centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))

            con.Open()
            rdr = cmd.ExecuteReader()

            ChartCobMes.Series(Grafico).Points.Clear()
            ChartCobMes.Series(Grafico).Points.DataBindXY(rdr, "Fecha", rdr, "Valor")

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub

    Private Function GrabarSemanal(ByVal Orden As String)
        GrabarSemanal = False
        Dim i As Integer = 0
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBalanceForrajero_newCrearDatosSemanales", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Orden", Orden)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.CommandTimeout = 30000
        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        GrabarSemanal = True
        Cursor.Current = Cursors.Default
    End Function
    Private Function BuscarSemanal(ByVal Orden As String, ByVal Semana As Integer) As String
        Cursor.Current = Cursors.WaitCursor
        Dim cober As Decimal
        'ChartCobDia.Titles(0).Text = "Cobertura de Pasto " + Format(dtpFecha.Value, "dd-MM-yyyy")
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_newBuscarDatosSemanales", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
            cmd.Parameters.AddWithValue("@Semana", Semana)
            cmd.Parameters.AddWithValue("@Orden", Orden)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()
            cober = 0
            While rdr.Read()
                cober = rdr("Valor")

            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        If Format(cober, “##,##0.0") = 0.0 Then
            BuscarSemanal = 0
        Else
            BuscarSemanal = Format(cober, “##,##0.0")
        End If

        Cursor.Current = Cursors.WaitCursor
    End Function


    Private Function Buscar(ByVal Orden As String, ByVal fecha As String) As String
        Cursor.Current = Cursors.WaitCursor
        Dim cober As Decimal
        'ChartCobDia.Titles(0).Text = "Cobertura de Pasto " + Format(dtpFecha.Value, "dd-MM-yyyy")
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spBalanceForrajero_newBuscarDatosMes", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
            cmd.Parameters.AddWithValue("@Fecha", fecha)
            cmd.Parameters.AddWithValue("@Orden", Orden)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()
            cober = 0
            While rdr.Read()
                cober = Format(rdr("Valor"), “##,##0.0")
            End While
            rdr.Close()
            cmd.Dispose()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
        If Orden = 5 Or Orden = 6 Or Orden = 7 Or Orden = 8 Then
            If Format(cober, “##,##0") = 0 Then
                Buscar = 0
            Else
                Buscar = Format(cober, “##,##0")
            End If
        Else
            If Format(cober, “##,##0.0") < 0.0 Then
                Buscar = 0
            Else
                Buscar = Format(cober, “##,##0.0")
            End If
        End If
        Cursor.Current = Cursors.WaitCursor
    End Function




    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub dgvDesarrolloBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvDesarrollo.CellBeginEdit
        If actualiza = 1 Then
            GuardaCobertura = dgvDesarrollo.Rows(e.RowIndex).Cells(1).Value
            GuardaLinbea = e.RowIndex
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        frmBalanceIngreso.MdiParent = frmMAIN
        frmBalanceIngreso.Show()
        frmBalanceIngreso.BringToFront()

    End Sub
    Public Sub reset()

        dgvPraderaSemanal.Rows.Clear()
        dgvRequerimientosSemanal.Rows.Clear()
        dgvProduccionSemanal.Rows.Clear()
        dgvAreaSecaSemanal.Rows.Clear()
        dgvMasaSemanal.Rows.Clear()
        dgvPraderas.Rows.Clear()
        dgvRequerimientos.Rows.Clear()
        dgvDesarrollo.Rows.Clear()
        DgvAlimentos.Rows.Clear()
        DgvAlimentosSecas.Rows.Clear()
        dgvConsumoPromedio.Rows.Clear()
        DgvCobertura.Rows.Clear()
        dgvCoberturaPromedio.Rows.Clear()
        ChartConsumo.Series("Series1").Points.Clear()
        ChartConsumo.Series("Series2").Points.Clear()
        ChartConsumo.Series("Series3").Points.Clear()
        ChartConsumo.Series("Series4").Points.Clear()
        ChartConsumo.Series("Series5").Points.Clear()
        ChartConsumo.Series("Series6").Points.Clear()

        ChartConsumoMensual.Series("Series1").Points.Clear()
        ChartConsumoMensual.Series("Series2").Points.Clear()
        ChartConsumoMensual.Series("Series3").Points.Clear()
        ChartConsumoMensual.Series("Series4").Points.Clear()
        ChartConsumoMensual.Series("Series5").Points.Clear()
        ChartConsumoMensual.Series("Series6").Points.Clear()

        ChartCobMes.Series("Series1").Points.Clear()
        ChartCobMes.Series("Series2").Points.Clear()
        ChartCobMes.Series("Series3").Points.Clear()
        ChartCobMes.Series("Series4").Points.Clear()

        ChartCoberturaMensual.Series("Series1").Points.Clear()
        ChartCoberturaMensual.Series("Series2").Points.Clear()
        ChartCoberturaMensual.Series("Series3").Points.Clear()
        ChartCoberturaMensual.Series("Series4").Points.Clear()

        llenado()
    End Sub



    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged
        If activar = 1 Then

            If rbSemanal.Checked = True Then
                reset()
                Check()
            Else
                reset()
                unCheck()
            End If
        End If
    End Sub

    Private Sub ChartConsumo_Click(sender As Object, e As EventArgs) Handles ChartConsumo.Click

    End Sub

    Private Sub rbmensual_CheckedChanged(sender As Object, e As EventArgs) Handles rbmensual.CheckedChanged
        'unCheck()
    End Sub

    Private Sub rbSemanal_CheckedChanged(sender As Object, e As EventArgs) Handles rbSemanal.CheckedChanged
        If rbSemanal.Checked = True Then
            Check()
        Else
            Cursor.Current = Cursors.WaitCursor
            pbProcesa.Maximum = 4
            pnlProcesa.Visible = True
            pnlProcesa.Refresh()
            pbProcesa.Value = 1
            pbProcesa.Value = 2
            unCheck()
            pbProcesa.Value = 3
            reset()
            pbProcesa.Value = 4
            pnlProcesa.Visible = False
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub dgvPraderaSemanal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPraderaSemanal.CellContentClick

    End Sub

    Private Sub btnEliminar_Click_1(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Cursor.Current = Cursors.WaitCursor
        pbProcesa.Maximum = 4
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()
        pbProcesa.Value = 1
        pbProcesa.Value = 2
        EliminarBalance()
        pbProcesa.Value = 3

        If rbSemanal.Checked = True Then
            unCheck()
            dgvConsumoPromedio.Rows.Clear()
            dgvCoberturaPromedio.Rows.Clear()
            Check()

            ChartConsumo.Series("Series1").Points.Clear()
            ChartConsumo.Series("Series2").Points.Clear()
            ChartConsumo.Series("Series3").Points.Clear()
            ChartConsumo.Series("Series4").Points.Clear()
            ChartConsumo.Series("Series5").Points.Clear()
            ChartConsumo.Series("Series6").Points.Clear()

            ChartConsumoMensual.Series("Series1").Points.Clear()
            ChartConsumoMensual.Series("Series2").Points.Clear()
            ChartConsumoMensual.Series("Series3").Points.Clear()
            ChartConsumoMensual.Series("Series4").Points.Clear()
            ChartConsumoMensual.Series("Series5").Points.Clear()
            ChartConsumoMensual.Series("Series6").Points.Clear()

            ChartCobMes.Series("Series1").Points.Clear()
            ChartCobMes.Series("Series2").Points.Clear()
            ChartCobMes.Series("Series3").Points.Clear()
            ChartCobMes.Series("Series4").Points.Clear()

            ChartCoberturaMensual.Series("Series1").Points.Clear()
            ChartCoberturaMensual.Series("Series2").Points.Clear()
            ChartCoberturaMensual.Series("Series3").Points.Clear()
            ChartCoberturaMensual.Series("Series4").Points.Clear()

            BuscarConsumoDiario("39", "Series1")
            BuscarConsumoDiario("40", "Series2")
            BuscarConsumoDiario("41", "Series3")
            BuscarConsumoDiario("43", "Series4")
            BuscarConsumoDiario("42", "Series5")
            BuscarConsumoDiario("45", "Series6")
            BuscarConsumoDiario("51", "Series7")

            BuscarConsumoMensual("39", "Series1")
            BuscarConsumoMensual("40", "Series2")
            BuscarConsumoMensual("41", "Series3")
            BuscarConsumoMensual("43", "Series4")
            BuscarConsumoMensual("42", "Series5")
            BuscarConsumoMensual("45", "Series6")
            BuscarConsumoMensual("51", "Series7")

            BuscarCoberturaPromedio("47", "Series1")
            BuscarCoberturaPromedio("48", "Series2")
            BuscarCoberturaPromedio("49", "Series3")
            BuscarCoberturaPromedio("50", "Series4")


            BuscarConberMensual("47", "Series1")
            BuscarConberMensual("48", "Series2")
            BuscarConberMensual("49", "Series3")
            BuscarConberMensual("50", "Series4")
        Else
            unCheck()
            reset()
        End If
        pbProcesa.Value = 4
        pnlProcesa.Visible = False
        Cursor.Current = Cursors.Default
    End Sub




    Private Sub EliminarBalance()

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBalanceForrajero_EliminarBalance", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex)

        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuarioSalas.Codigo(cboCentros.SelectedIndex))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.CommandTimeout = 30000
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret > -1 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvPraderas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPraderas.CellContentClick

    End Sub



    Private Sub dgvDesarrolloControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDesarrollo.EditingControlShowing
        Dim col As Integer = dgvDesarrollo.CurrentCell.ColumnIndex
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtRetiroDesarrollo
    End Sub

    Private Sub ValidaTxtRetiroDesarrollo(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvDesarrollo.CurrentCell.ColumnIndex
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub dgvRequerimientosCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvRequerimientos.CellBeginEdit
        If actualiza = 1 Then
            GuardaCobertura = dgvRequerimientos.Rows(e.RowIndex).Cells(1).Value
            GuardaLinbea = e.RowIndex
        End If
    End Sub
    Private Sub dgvRequerimientosEditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRequerimientos.EditingControlShowing
        Dim col As Integer = dgvRequerimientos.CurrentCell.ColumnIndex

        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtRetiroRequerimientos

    End Sub

    Private Sub ValidaTxtRetiroRequerimientos(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvRequerimientos.CurrentCell.ColumnIndex
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub lblProcesaMax_Click(sender As Object, e As EventArgs) Handles lblProcesaMax.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        'If rbSemanal.Checked = True Then
        '    unCheck()
        '    Check()
        'Else
        '    Cursor.Current = Cursors.WaitCursor
        '    pbProcesa.Maximum = 4
        '    pnlProcesa.Visible = True
        '    pnlProcesa.Refresh()
        '    pbProcesa.Value = 1
        '    pbProcesa.Value = 2
        '    unCheck()
        '    pbProcesa.Value = 3
        '    reset()
        '    pbProcesa.Value = 4
        '    pnlProcesa.Visible = False
        '    Cursor.Current = Cursors.Default
        'End If
    End Sub
    '''''''''''''''''''''
    Private Sub DgvAlimentosCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DgvAlimentos.CellBeginEdit
        If actualiza = 1 Then
            GuardaCobertura = DgvAlimentos.Rows(e.RowIndex).Cells(1).Value
            GuardaLinbea = e.RowIndex
        End If
    End Sub
    Private Sub DgvAlimentosEditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DgvAlimentos.EditingControlShowing
        Dim col As Integer = DgvAlimentos.CurrentCell.ColumnIndex
        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtRetiroAlimentos
    End Sub

    Private Sub ValidaTxtRetiroAlimentos(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = DgvAlimentos.CurrentCell.ColumnIndex
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
    End Sub

    Private Sub cboCentros_MouseClick(sender As Object, e As MouseEventArgs) Handles cboCentros.MouseClick
        cen = cboCentros.SelectedIndex
    End Sub


    Private Sub dgvPraderaSemanal_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPraderaSemanal.CellEndEdit
        GrabarSemanas(dgvPraderaSemanal.Rows(e.RowIndex).Cells(0).Value, dgvPraderaSemanal.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, e.ColumnIndex - 6)
    End Sub

    Private Sub dgvMasaSemanal_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMasaSemanal.CellEndEdit
        GrabarSemanas(dgvMasaSemanal.Rows(e.RowIndex).Cells(0).Value, dgvMasaSemanal.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, e.ColumnIndex - 6)
    End Sub

    Private Sub dgvRequerimientosSemanal_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRequerimientosSemanal.CellEndEdit
        GrabarSemanas(dgvRequerimientosSemanal.Rows(e.RowIndex).Cells(0).Value, dgvRequerimientosSemanal.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, e.ColumnIndex - 6)
    End Sub

    Private Sub dgvAreaSecaSemanal_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAreaSecaSemanal.CellEndEdit
        GrabarSemanas(dgvAreaSecaSemanal.Rows(e.RowIndex).Cells(0).Value, dgvAreaSecaSemanal.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, e.ColumnIndex - 6)
    End Sub

    Private Sub dgvProduccionSemanal_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProduccionSemanal.CellEndEdit
        GrabarSemanas(dgvProduccionSemanal.Rows(e.RowIndex).Cells(0).Value, dgvProduccionSemanal.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, e.ColumnIndex - 6)
    End Sub

    'If x <= 7 Then
    '                    GrabarMensual(dgvPraderas.Rows(i).Cells(0).Value, dgvPraderas.Rows(i).Cells(x).Value, 2019, x + 5)
    '                End If
    'If x >= 8 Then
    '                    GrabarMensual(dgvPraderas.Rows(i).Cells(0).Value, dgvPraderas.Rows(i).Cells(x).Value, 2020, x - 7)
    '                End If
    Private Sub dgvPraderas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPraderas.CellEndEdit
        If e.ColumnIndex <= 7 Then
            GrabarMensual(dgvPraderas.Rows(e.RowIndex).Cells(0).Value, dgvPraderas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2019, e.ColumnIndex + 5)
        End If
        If e.ColumnIndex >= 8 Then
            GrabarMensual(dgvPraderas.Rows(e.RowIndex).Cells(0).Value, dgvPraderas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2020, e.ColumnIndex - 7)
        End If
    End Sub

    Private Sub dgvDesarrollo_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDesarrollo.CellEndEdit
        If e.ColumnIndex <= 7 Then
            GrabarMensual(dgvDesarrollo.Rows(e.RowIndex).Cells(0).Value, dgvDesarrollo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2019, e.ColumnIndex + 5)
        End If
        If e.ColumnIndex >= 8 Then
            GrabarMensual(dgvDesarrollo.Rows(e.RowIndex).Cells(0).Value, dgvDesarrollo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2020, e.ColumnIndex - 7)
        End If
    End Sub

    Private Sub dgvRequerimientos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRequerimientos.CellEndEdit
        If e.ColumnIndex <= 7 Then
            GrabarMensual(dgvRequerimientos.Rows(e.RowIndex).Cells(0).Value, dgvRequerimientos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2019, e.ColumnIndex + 5)
        End If
        If e.ColumnIndex >= 8 Then
            GrabarMensual(dgvRequerimientos.Rows(e.RowIndex).Cells(0).Value, dgvRequerimientos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2020, e.ColumnIndex - 7)
        End If
    End Sub

    Private Sub DgvAlimentos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAlimentos.CellEndEdit
        If e.ColumnIndex <= 7 Then
            GrabarMensual(DgvAlimentos.Rows(e.RowIndex).Cells(0).Value, DgvAlimentos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2019, e.ColumnIndex + 5)
        End If
        If e.ColumnIndex >= 8 Then
            GrabarMensual(DgvAlimentos.Rows(e.RowIndex).Cells(0).Value, DgvAlimentos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2020, e.ColumnIndex - 7)
        End If
    End Sub

    Private Sub DgvAlimentosSecas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DgvAlimentosSecas.CellEndEdit
        If e.ColumnIndex <= 7 Then
            GrabarMensual(DgvAlimentosSecas.Rows(e.RowIndex).Cells(0).Value, DgvAlimentosSecas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2019, e.ColumnIndex + 5)
        End If
        If e.ColumnIndex >= 8 Then
            GrabarMensual(DgvAlimentosSecas.Rows(e.RowIndex).Cells(0).Value, DgvAlimentosSecas.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 2020, e.ColumnIndex - 7)
        End If
    End Sub
End Class