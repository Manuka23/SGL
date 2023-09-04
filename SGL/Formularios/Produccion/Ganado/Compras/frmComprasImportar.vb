

Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices



Public Class frmComprasImportar

    Public Param1_ModoIngreso As Integer         '1=nuevo - 2=modifica - 3=muestra
    Public Param2_CodigoCentro As String
    Public Param3_NombreCentro As String
    Public Param4_Fecha As DateTime
    'Public Param5_CodigoCompra As Integer
    Public Param6_NroFMA As Integer
    Public Param7_Estado As String
    Public Param8_NroGuia As Integer
    Public Param9_NroRUP As String
    Public Param10_TipoDoc As Integer
    Public Param11_NroDoc As Integer
    Public Param12_Proveedor As Integer
    Public Param13_Observs As String

    Public ActualizaDIIO As Integer




    Private Function GrabarDIIOCompra() As Boolean
        GrabarDIIOCompra = False
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCompras_GrabarDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing

        'cmd.CommandType = Data.CommandType.StoredProcedure

        Dim cat_ As String = ""
        Dim eprod_ As String = ""
        Dim ereprod_ As String = ""
        Dim raza_ As Integer = 0
        Dim peso_ As Integer = 0
        Dim npart_ As Integer = 0
        Dim Result As Integer
        Dim HayError As Boolean = False


        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION
        Try
            con.Open()
            cmd.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try


        For Each itm As ListViewItem In lvCOMPRAS.Items
            cmd.Parameters.Clear()

            cmd.Parameters.AddWithValue("@Commit", 0)
            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", Param2_CodigoCentro)
            cmd.Parameters.AddWithValue("@Fecha", Param4_Fecha)
            cmd.Parameters.AddWithValue("@FMA", Param6_NroFMA)
            cmd.Parameters.AddWithValue("@Guia", Param8_NroGuia)
            cmd.Parameters.AddWithValue("@Observs", Param13_Observs)
            cmd.Parameters.AddWithValue("@TipoDoc", Param10_TipoDoc)
            cmd.Parameters.AddWithValue("@Proveedor", Param12_Proveedor)
            cmd.Parameters.AddWithValue("@RUP", Param9_NroRUP)
            cmd.Parameters.AddWithValue("@NumeroDoc", Param11_NroDoc)
            cmd.Parameters.AddWithValue("@Transporte", 0)
            cmd.Parameters.AddWithValue("@Chofer", 0)
            cmd.Parameters.AddWithValue("@Patente", "")
            ''
            cmd.Parameters.AddWithValue("@NroAnimal", itm.SubItems(2).Text)
            cmd.Parameters.AddWithValue("@Categoria", itm.SubItems(18).Text)
            cmd.Parameters.AddWithValue("@EstProductivo", itm.SubItems(4).Text)
            cmd.Parameters.AddWithValue("@EstReproductivo", itm.SubItems(5).Text)
            cmd.Parameters.AddWithValue("@Raza", itm.SubItems(21).Text)
            cmd.Parameters.AddWithValue("@FechaNacimiento", itm.SubItems(7).Text)
            cmd.Parameters.AddWithValue("@Peso", itm.SubItems(8).Text)
            cmd.Parameters.AddWithValue("@NroPartos", itm.SubItems(9).Text)
            cmd.Parameters.AddWithValue("@Fecha1erParto", itm.SubItems(10).Text)
            cmd.Parameters.AddWithValue("@FechaUltParto", itm.SubItems(11).Text)
            cmd.Parameters.AddWithValue("@FechaProbParto", itm.SubItems(14).Text)
            cmd.Parameters.AddWithValue("@FechaUltCbta", itm.SubItems(12).Text)
            cmd.Parameters.AddWithValue("@ToroUltCbta", itm.SubItems(13).Text)
            cmd.Parameters.AddWithValue("@Padre", itm.SubItems(15).Text)
            cmd.Parameters.AddWithValue("@Madre", itm.SubItems(16).Text)
            ''
            'cmd.Parameters.AddWithValue("@CodigoSis", Param5_CodigoCompra)
            cmd.Parameters.AddWithValue("@Actualiza", ActualizaDIIO)
            ''
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            ''
            cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
            'cmd.Parameters.Add("@RetCodCompra", SqlDbType.Int) : cmd.Parameters("@RetCodCompra").Direction = ParameterDirection.Output

            Try
                'con.Open()
                cmd.Transaction = SRVTRANS
                Result = cmd.ExecuteNonQuery()
                'Dim Result As Integer = cmd.ExecuteNonQuery()

                Dim vret As Integer = cmd.Parameters("@RetValor").Value
                Dim mret As String = cmd.Parameters("@RetMensage").Value
                'Dim cod As Integer = cmd.Parameters("@RetCodCompra").Value

                ''verificamos error con un valor igual a -1
                If vret <> 0 Then
                    'If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    'End If
                    'Exit Function
                    itm.SubItems(17).Text = mret   'estado
                    HayError = True
                End If

                ''si todo sale ok guardamos el nuevo codigo del grupo de secado

                'CodigoSecado = vret

                'despues de una grabacion correcta siempre activamos la edicion, ya que el encabezado ya esta creado
                'Param0_ModoIngreso = 2
                'Param5_CodigoCompra = cod
                GrabarDIIOCompra = True
                'Dim perfil As String = cmd.Parameters("@RetPerfilNom").Value

                'MsgBox(mret)


                'ValidarUsuario = True
            Catch ex As Exception
                'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                itm.SubItems(17).Text = ex.Message   'estado
                HayError = True
            End Try
        Next

        If HayError = False Then
            SRVTRANS.Commit()
            GrabarDIIOCompra = True
        Else
            SRVTRANS.Rollback()
            GrabarDIIOCompra = False
        End If

        con.Close()
        Cursor.Current = Cursors.Default
    End Function



    Private Sub CargarArchivoExcel(ByVal ArchivoExcel As String)
        Cursor.Current = Cursors.WaitCursor

        lblProcesa.Text = "Cargando datos desde planilla excel..."
        pbProcesa.Value = 0
        pbProcesa.Maximum = 0
        pnlProcesa.Visible = True
        pnlProcesa.Refresh()

        Dim data As System.Data.DataTable
        Dim ExelDir As New Excel
        'Dim Funcionarios As New Direcciones

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'AQUI EXPORTAMOS LA PLANILLA EXCEL A UN DATATABLE
        ExelDir.Archivo = ArchivoExcel
        ExelDir.Hoja = "Hoja1"
        data = ExelDir.ImportarPlanilla_A_DataTable()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If data Is Nothing Then Exit Sub
        If data.Columns.Count < 2 Then Exit Sub
        If data.Rows.Count = 0 Then Exit Sub

        lblProcesa.Text = "validando datos, espere un momento por favor..."
        pbProcesa.Maximum = data.Rows.Count
        pnlProcesa.Refresh()

        Try
            Dim lin As Integer
            Dim Procesa As Boolean
            Dim AppExcel As New Application

            Dim MsgErrorEnLinea As String
            Dim col1, col2, col3, col4, col5, col6, col7, col8, col9, col10, col11, col12, col13, col14, col15 As String
            Dim cod1 As String
            Dim cod2, cod3, cod4 As Integer
            Dim ContErrores As Integer
            Dim items As New List(Of ListViewItem)

            lvCOMPRAS.BeginUpdate()
            lvCOMPRAS.SuspendLayout()
            lvCOMPRAS.Items.Clear()
            'Libro = AppExcel.Workbooks.Open(ArchivoExcel)
            'Hoja = Libro.Worksheets(1)
            'lin = 2
            'idx = 0
            ContErrores = False
            Procesa = True

            'Do While Procesa
            For lin = 0 To data.Rows.Count - 1
                MsgErrorEnLinea = ""

                col1 = "" : If Not data.Rows(lin).Item(0).ToString.Trim Is Nothing Then col1 = data.Rows(lin).Item(0).ToString.Trim()
                col2 = "" : If Not data.Rows(lin).Item(1).ToString.Trim Is Nothing Then col2 = data.Rows(lin).Item(1).ToString.Trim()
                col3 = "" : If Not data.Rows(lin).Item(2).ToString.Trim Is Nothing Then col3 = data.Rows(lin).Item(2).ToString.Trim()
                col4 = "" : If Not data.Rows(lin).Item(3).ToString.Trim Is Nothing Then col4 = data.Rows(lin).Item(3).ToString.Trim()
                col5 = "" : If Not data.Rows(lin).Item(4).ToString.Trim Is Nothing Then col5 = data.Rows(lin).Item(4).ToString.Trim()
                col6 = "" : If Not data.Rows(lin).Item(5).ToString.Trim Is Nothing Then col6 = data.Rows(lin).Item(5).ToString.Trim()
                col7 = "" : If Not data.Rows(lin).Item(6).ToString.Trim Is Nothing Then col7 = data.Rows(lin).Item(6).ToString.Trim()
                col8 = "" : If Not data.Rows(lin).Item(7).ToString.Trim Is Nothing Then col8 = data.Rows(lin).Item(7).ToString.Trim()
                col9 = "" : If Not data.Rows(lin).Item(8).ToString.Trim Is Nothing Then col9 = data.Rows(lin).Item(8).ToString.Trim()
                col10 = "" : If Not data.Rows(lin).Item(9).ToString.Trim Is Nothing Then col10 = data.Rows(lin).Item(9).ToString.Trim()
                col11 = "" : If Not data.Rows(lin).Item(10).ToString.Trim Is Nothing Then col11 = data.Rows(lin).Item(10).ToString.Trim()
                col12 = "" : If Not data.Rows(lin).Item(11).ToString.Trim Is Nothing Then col12 = data.Rows(lin).Item(11).ToString.Trim()
                col13 = "" : If Not data.Rows(lin).Item(12).ToString.Trim Is Nothing Then col13 = data.Rows(lin).Item(12).ToString.Trim()
                col14 = "" : If Not data.Rows(lin).Item(13).ToString.Trim Is Nothing Then col14 = data.Rows(lin).Item(13).ToString.Trim()
                col15 = "" : If Not data.Rows(lin).Item(14).ToString.Trim Is Nothing Then col15 = data.Rows(lin).Item(14).ToString.Trim()

                cod1 = BuscaCodigoCategoria(col2)
                cod2 = BuscaCodigoEstadoProductivo(col3)
                cod3 = BuscaCodigoEstadoReproductivo(col4)
                cod4 = BuscaCodigoRaza(col5)

                'si no hay registros, salimos
                If col1 = "" Then Exit For

                'la primera validación es verificar que el diio no exista
                If BuscarDiio(col1) Then MsgErrorEnLinea = "DIIO YA EXISTE"

                'validamos codigos
                If MsgErrorEnLinea = "" And cod1 = "" Then MsgErrorEnLinea = "CATEGORÍA INCORRECTA"
                If MsgErrorEnLinea = "" And col2 = "TERNERAS" And (col3 <> "NO APLICA" Or col4 <> "NO APLICA") Then MsgErrorEnLinea = "ESTADOS PROD/REPROD INCORRECTOS"
                If MsgErrorEnLinea = "" And cod2 = 0 Then MsgErrorEnLinea = "ESTADO PRODUCTIVO INCORRECTO"
                If MsgErrorEnLinea = "" And cod3 = 0 Then MsgErrorEnLinea = "ESTADO REPRODUCTIVO INCORRECTO"
                If MsgErrorEnLinea = "" And cod4 = 0 Then MsgErrorEnLinea = "RAZA INCORRECTA"

                'validamos demas datos
                If MsgErrorEnLinea = "" And IsDate(col6) = False Then MsgErrorEnLinea = "FECHA NACIMIENTO INCORRECTA"
                If MsgErrorEnLinea = "" And IsNumeric(col7) = False Then MsgErrorEnLinea = "PESO INCORRECTO"

                'desde aqui, validamos solo si la celda tiene datos
                If MsgErrorEnLinea = "" And col8 <> "" And IsNumeric(col8) = False Then MsgErrorEnLinea = "N° PARTOS INCORRECTO"
                If MsgErrorEnLinea = "" And col9 <> "" And IsDate(col9) = False Then MsgErrorEnLinea = "FECHA 1ER PARTO INCORRECTA"
                If MsgErrorEnLinea = "" And col10 <> "" And IsDate(col10) = False Then MsgErrorEnLinea = "FECHA ÚLTIMO PARTO INCORRECTA"
                If MsgErrorEnLinea = "" And col11 <> "" And IsDate(col11) = False Then MsgErrorEnLinea = "FECHA ÚLTIMA CUBIERTA INCORRECTA"
                If MsgErrorEnLinea = "" And col13 <> "" And IsDate(col13) = False Then MsgErrorEnLinea = "FECHA PROBABLE PARTO INCORRECTA"

                'If MsgErrorEnLinea = "" And col12 <> "" And IsDate(col9) = False Then MsgErrorEnLinea = "FECHA 1ER PARTO INCORRECTA"

                Dim item As New ListViewItem((lin + 1).ToString)                        'nro
                item.SubItems.Add(Empresa.ToString)                      'empresa
                item.SubItems.Add(col1)     'diio
                item.SubItems.Add(col2)     'categoria
                item.SubItems.Add(col3)     'estado productivo
                If col4.Contains("PRE") Then
                    item.SubItems.Add("PREÑADA")     'estado reproductivo
                Else
                    item.SubItems.Add(col4)     'estado reproductivo
                End If

                item.SubItems.Add(col5)     'raza
                item.SubItems.Add(Format(CDate(col6), "dd-MM-yyyy"))     'fecha nac.
                item.SubItems.Add(col7)     'peso
                item.SubItems.Add(col8)     'nro partos
                item.SubItems.Add(col9)     'fec. 1er parto
                item.SubItems.Add(col10)    'fec. ult parto
                item.SubItems.Add(col11)    'fec. ult. cbta.
                item.SubItems.Add(col12)    'toro ult. cbta.
                item.SubItems.Add(col13)    'fec prob. parto
                item.SubItems.Add(col14)    'padre 
                item.SubItems.Add(col15)    'madre
                item.SubItems.Add("")       'estado

                item.SubItems.Add(cod1)             'cod.categoria
                item.SubItems.Add(cod2.ToString)    'cod.est.prod
                item.SubItems.Add(cod3.ToString)    'cod.est.reprod
                item.SubItems.Add(cod4.ToString)    'cod.raza
                'lvCOMPRAS.Items.Add(item)

                If MsgErrorEnLinea <> "" Then
                    item.SubItems(17).Text = MsgErrorEnLinea
                    item.UseItemStyleForSubItems = False

                    For x As Integer = 0 To lvCOMPRAS.Columns.Count - 1
                        item.SubItems(x).BackColor = Color.Red '.FromArgb(255, 255, 192)
                    Next

                    ContErrores += 1
                End If

                items.Add(item)
                pbProcesa.Value = lin
            Next

            lblProcesa.Text = "Cargando datos a la grilla, espere un momento por favor..."
            pnlProcesa.Refresh()

            lvCOMPRAS.Items.AddRange(items.ToArray())
            lvCOMPRAS.ResumeLayout()
            lvCOMPRAS.EndUpdate()

            lblTotalCompras.Text = lin.ToString.Trim
            lblTotalErrores.Text = ContErrores.ToString.Trim

            If ContErrores > 0 Then
                btnFinalizar.Enabled = False
            Else
                btnFinalizar.Enabled = True
            End If

            pnlProcesa.Visible = False

            'nos aseguramos de descargar todas las referenicas de los Objetos...
            'Hoja = Nothing
            'AppExcel.Quit()
            'Marshal.ReleaseComObject(Libro)
            'Marshal.ReleaseComObject(AppExcel)
            'AppExcel = Nothing

            Cursor.Current = Cursors.Default

        Catch ex As Exception
            MsgBox("Error: " + ex.Message.ToString)
        End Try
    End Sub



    Private Function ValidacionesLocales(Optional ByVal ValidaDiios As Boolean = True) As Boolean
        ValidacionesLocales = False

        'If cboCentros.SelectedIndex = -1 Then
        '    If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    cboCentros.Focus()
        '    Exit Function
        'End If

        ValidacionesLocales = True
    End Function


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Me.Dispose()
        Cursor.Current = Cursors.Default
    End Sub



    'Private Sub frmSecadosIngreso_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
    '    If lvCOMPRAS.SelectedItems.Count = 0 Then Exit Sub

    '    Dim diio_ As String = lvCOMPRAS.SelectedItems(0).SubItems(2).Text

    '    If Control.ModifierKeys = Keys.Control Then

    '        If e.KeyCode = Keys.C Then
    '            Clipboard.Clear()
    '            Clipboard.SetText(diio_)
    '        End If

    '        'If e.KeyCode = Keys.V Then
    '        '    MsgBox("chao")
    '        'End If

    '    End If
    'End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub btnArchivo_Click(sender As System.Object, e As System.EventArgs) Handles btnArchivo.Click
        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()

        If OpenFDlg.FileName.Trim() = "" Then Exit Sub

        txtArchivo.Text = OpenFDlg.FileName.Trim
        CargarArchivoExcel(txtArchivo.Text)
    End Sub


    Private Sub frmComprasImportar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Private Sub btnFinalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnFinalizar.Click
        If lvCOMPRAS.Items.Count = 0 Then Exit Sub

        If GrabarDIIOCompra() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
        Else
            If MsgBox("DATOS NO GRABADOS --- VER ERRORES EN COLUMNA ESTADO ---", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
            End If
        End If
    End Sub
End Class