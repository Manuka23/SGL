

Imports System.Data.SqlClient


Public Class frmPotreros
    Private Potreros As New ListaPotreros


    Public Sub ConsultarPotreros()
        lblProcesa.Text = "Consultando datos, espere un momento por favor..."

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPotreros_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = ""
        Dim tip_ As Integer = 0

        If cboCentros.SelectedIndex <> -1 And cboCentros.Text <> "(TODOS)" Then cent_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        If cboTiposPotreros.SelectedIndex <> -1 And cboTiposPotreros.Text <> "(TODOS)" Then tip_ = General.TipoPotreros.Codigo(cboTiposPotreros.SelectedIndex - 1)

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Tipo", tip_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvGanado.BeginUpdate()
        lvGanado.Items.Clear()


        Label10.Text = "0"

        Dim i As Integer = 0
        Dim vret As Integer = 0


        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()



                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("EmpresaCod").ToString.Trim)
                    item.SubItems.Add(rdr("CenDesCor").ToString.Trim)
                    item.SubItems.Add(rdr("PotreroCod").ToString.Trim)
                    item.SubItems.Add(rdr("PotTipNombre").ToString.Trim)
                    item.SubItems.Add(rdr("PotreroSuperficie").ToString.Trim)
                    item.SubItems.Add(Format(rdr("PotreroFechaReg"), "dd-MM-yyyy HH:mm"))
                    item.SubItems.Add(rdr("PotreroUI").ToString.Trim)
                    item.SubItems.Add(rdr("PotreroObservs").ToString.Trim)
                    item.SubItems.Add(rdr("CentroCod").ToString.Trim)
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

        Label10.Text = i.ToString.Trim


        Cursor.Current = Cursors.Default
    End Sub


    Private Sub EliminarPotrero()
        If lvGanado.SelectedItems.Count = 0 Then Exit Sub

        If MsgBox("¿DESEA ELIMINAR EL POTRERO SELECCIONADO?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            If Eliminar_Potrero() = True Then
                ConsultarPotreros()
            End If
        End If
    End Sub


    Private Function Eliminar_Potrero() As Boolean
        Eliminar_Potrero = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPotreros_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cent_ As String = lvGanado.SelectedItems(0).SubItems(9).Text
        Dim potrero_ As String = lvGanado.SelectedItems(0).SubItems(3).Text
        '
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", cent_)
        cmd.Parameters.AddWithValue("@Potrero", potrero_)
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

            Eliminar_Potrero = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function



    Private Sub SeleccionaArchivo()
        dlgCarpeta.FileName = ""
        dlgCarpeta.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        dlgCarpeta.ShowDialog()

        If dlgCarpeta.FileName.Trim() <> "" Then

            If GrabarYCargarPotreros(dlgCarpeta.FileName.Trim) = True Then
            End If

            ConsultarPotreros()

        End If
    End Sub


    Private Function SuperficieToDecimal2(ByVal val_ As String) As Double
        Try
            SuperficieToDecimal2 = Format(CDbl(val_), "#,#0.00")
        Catch ex As Exception
            SuperficieToDecimal2 = 0
        End Try

    End Function


    Private Function GrabarYCargarPotreros(ByVal archivo_ As String) As Boolean
        Cursor.Current = Cursors.WaitCursor

        GrabarYCargarPotreros = False
        Dim data As System.Data.DataTable
        Dim ExelDir As New Excel
        'Dim Funcionarios As New Direcciones

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'AQUI EXPORTAMOS LA PLANILLA EXCEL A UN DATATABLE
        ExelDir.Archivo = archivo_
        ExelDir.Hoja = "Hoja1"
        data = ExelDir.ImportarPlanilla_A_DataTable()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If data Is Nothing Then Exit Function
        If data.Columns.Count < 2 Then Exit Function
        If data.Rows.Count = 0 Then Exit Function

        Dim error_ As Integer = 0
        Dim cent_, guardacent_, obs_ As String
        Dim tip_ As Integer = 0
        Dim pot_ As String = ""
        Dim sup_ As Double = 0
        Dim params_in As New Hashtable
        Dim params_out As New Hashtable
        ''
        'Validar que el excel contenga datos en todas las celdas
        For i As Integer = 0 To data.Rows.Count - 1
            cent_ = data.Rows(i).Item(0).ToString.Trim 'General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
            pot_ = data.Rows(i).Item(1).ToString.Trim
            sup_ = SuperficieToDecimal2(data.Rows(i).Item(2).ToString.Trim)
            Try
                tip_ = Convert.ToInt64(data.Rows(i).Item(3).ToString.Trim)
            Catch ex As Exception
                MsgBox("Error 100: Valor de la columna Tipo de Potrero, en la línea " & (i + 2).ToString & ", no corresponde a un dato númerico. ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje")
                error_ = 100
                Exit For
            End Try

            If cent_ = "" Then
                MsgBox("Error 200: Valor de la columna Centro, en la línea " & (i + 2).ToString & ", no puede estar en blanco. ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje")
                error_ = 200
                Exit For
            End If
            If pot_ = "" Then
                MsgBox("Error 300: Valor de la columna Potrero, en la línea " & (i + 2).ToString & ", no puede estar en blanco. ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje")
                error_ = 300
                Exit For
            End If
            If sup_ <= 0 Then
                MsgBox("Error 400: Valor de la columna Superficie, en la línea " & (i + 2).ToString & ", no puede ser menor o igual a Cero. ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje")
                error_ = 400
                Exit For
            End If
            If tip_ <= 0 Then
                MsgBox("Error 500: Valor de la columna Tipo de Potrero, en la línea " & (i + 2).ToString & ", no puede ser menor o igual a Cero. ", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Mensaje")
                error_ = 500
                Exit For
            End If
        Next

        If error_ > 0 Then
            Exit Function
        End If

        lvGanado.BeginUpdate()
        guardacent_ = ""
        Try
            'abrimos una conexión e iniciamos nuestra transaccion

            Potreros.TransaccionIniciar(IsolationLevel.ReadUncommitted)

            'la primera linea contiene el titulo, por lo que empezamos de la linea 1
            For i As Integer = 0 To data.Rows.Count - 1
                cent_ = data.Rows(i).Item(0).ToString.Trim 'General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
                pot_ = data.Rows(i).Item(1).ToString.Trim
                sup_ = SuperficieToDecimal2(data.Rows(i).Item(2).ToString.Trim)
                tip_ = data.Rows(i).Item(3).ToString.Trim
                obs_ = ""

                If cent_.Trim = "" Or pot_.ToString.Trim = "" Then Continue For


                ''--------------------------------------------------------------------------------------
                ''antes de grabar los potreros eliminamos todos los potreros de la sala
                'If guardacent_ <> cent_ Then
                '    guardacent_ = cent_

                '    params_in.Clear()
                '    params_in.Add("@Centro", cent_)

                '    Potreros.ParametrosEntrada = params_in
                '    Potreros.ParametrosSalida = Nothing

                '    If Potreros.EliminarTodosCentro() = False Then

                '    End If
                'End If
                ''--------------------------------------------------------------------------------------


                ''creamos parametros para grabar la direccion

                params_in.Clear()

                params_in.Add("@Centro", cent_)
                params_in.Add("@Potrero", pot_)
                params_in.Add("@Tipo", tip_)
                params_in.Add("@Superficie", sup_)
                params_in.Add("@Observs", obs_)
                ''
                ''establecemos parametros
                Potreros.ParametrosEntrada = params_in
                Potreros.ParametrosSalida = Nothing

                If Potreros.Grabar() = False Then
                    Potreros.TransaccionCancelar()
                    Exit Function
                End If
            Next

            lvGanado.EndUpdate()

            If Potreros.TransaccionActualizar() = True Then
                MsgBox("DATOS CARGADOS --- OK ---", MsgBoxStyle.Information, "Mensaje")
                GrabarYCargarPotreros = True
            Else
                Potreros.TransaccionCancelar()
            End If

        Catch ex As Exception
            MsgBox("ERROR AL CARGAR ARCHIVO: " + ex.Message, MsgBoxStyle.Exclamation, "Mensaje")
            Potreros.TransaccionCancelar()
        End Try

        Cursor.Current = Cursors.Default
    End Function


    Private Sub cboCentros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCentros.SelectedIndexChanged


        ConsultarPotreros()
    End Sub


    Private Sub cboTiposPotreros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTiposPotreros.SelectedIndexChanged
        ConsultarPotreros()
    End Sub



    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        frmPotrerosIngreso.MdiParent = frmMAIN
        frmPotrerosIngreso.Show()
        frmPotrerosIngreso.BringToFront()

        frmPotrerosIngreso.cboCentros.Text = cboCentros.Text
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        ConsultarPotreros()
    End Sub


    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        EliminarPotrero()
    End Sub


    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If lvGanado.Items.Count = 0 Then Exit Sub

        Dim tot(3, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "Nro. Potreros" : tot(0, 1) = Label10.Text

        ExportToExcelGrilla(lvGanado, tot)
    End Sub


    Private Sub btnCargarPlanilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargarPlanilla.Click
        If MsgBox("ADVERTENCIA: SI EL POTRERO NO EXISTE SE CREARÁ, SI EXISTE SE MODIFICARÁ" + vbCrLf + "¿DESEA CONTINUAR?" + vbCrLf + vbCrLf + "Formato Excel: CÓD. CENTRO | POTRERO | SUPERFICIE | TIPO POT.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "POTREROS") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        SeleccionaArchivo()
    End Sub



    Private Sub frmPotreros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General.TipoPotreros.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaCentrosUsuario(cboCentros, True)
        CboLLenaTipoPotreros(cboTiposPotreros, True)

        cboCentros.SelectedIndex = 0
        cboTiposPotreros.SelectedIndex = 0

        ConsultarPotreros()
    End Sub
End Class