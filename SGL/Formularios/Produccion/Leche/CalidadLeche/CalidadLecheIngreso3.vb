Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Public Class CalidadLecheIngreso3
    Private TipoControl As String
    Private TipoPeriodo As String
    Private Quincena As String
    Private CodigoDIIO As String
    Private ArchivoImportacion As String
    Private NombreArchivo As String
    Private Diioexcel As String
    Private Rcsexcel As Integer = 0
    Private Grasaexcel As Double = 0
    Private Proteinaexcel As Double = 0
    Private Ureaexcel As Integer = 0
    Private Densidadexcel As Integer = 0
    Private Crioscopiaexcel As Integer = 0
    Private Ufcexcel As Integer = 0

    Private Sub CalidadLecheIngreso3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLLenaPlantas()
        cbollenaProveedores()
        dtpFecha.Value = DateTime.Now
    End Sub
    Private Sub CboLLenaPlantas()
        If General.Plantas.NroRegistros = 0 Then Exit Sub

        cboPlantas.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Plantas.NroRegistros - 1

            cboPlantas.Items.Add(General.Plantas.Nombre(i))
        Next
        cboPlantas.Text = -1
    End Sub
    Private Sub cbollenaProveedores()
        If General.Proveedores.NroRegistros = 0 Then Exit Sub

        cboProveedores.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Proveedores.NroRegistros - 1

            cboProveedores.Items.Add(General.Proveedores.Nombre(i))
        Next
        cboProveedores.Text = -1
    End Sub
    Public Sub BuscarSalas()
        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spSalas_Listado", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            Dim hrs As Double = 0
            Dim tothrs As Double = 0

            dgvCalidadLeche.SuspendLayout()
            dgvCalidadLeche.Rows.Clear()


            While rdr.Read()

                dgvCalidadLeche.Rows.Add(rdr("CentroNom"), rdr("CentroCod"), "", "", "", "", "", "", "", "")
            End While
            dgvCalidadLeche.ResumeLayout()

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
    Private Sub dgvCalidadLeche_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCalidadLeche.CellValueChanged
        Dim n As Integer = dgvCalidadLeche.RowCount
        For i = 0 To dgvCalidadLeche.Rows.Count - 1
            For x = 0 To n - 1
                If dgvCalidadLeche.Rows(i).Cells(4).Value <> "" And dgvCalidadLeche.Rows(i).Cells(5).Value <> "" Then
                    Dim Grasa As Double = dgvCalidadLeche.Rows(i).Cells(4).Value
                    Dim Proteina As Double = dgvCalidadLeche.Rows(i).Cells(5).Value
                    Dim Msolida As Double = Grasa + Proteina
                    dgvCalidadLeche.Rows(i).Cells(10).Value = Msolida
                End If
            Next
        Next
    End Sub
    Public Sub ConsultaCalidad()
        Thread.Sleep(20)
        Dim n As Integer = dgvCalidadLeche.RowCount
        For i = 0 To n - 1

            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spCalidadLeche_LitrosRetirados", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Centro", dgvCalidadLeche.Rows(i).Cells(1).Value)
            cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
            Dim vret As Integer = 0
            Try
                con.Open()
                rdr = cmd.ExecuteReader()
                Try
                    While rdr.Read()

                        dgvCalidadLeche.Rows(i).Cells(2).Value = rdr("Litros")
                    End While
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
        Next
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If cboPlantas.SelectedIndex <> -1 And TipoPeriodo <> "" And TipoControl <> "" Then
            dgvCalidadLeche.Enabled = True
            BuscarSalas()
            ConsultaCalidad()
            ConsultaIngreso()
        Else
            MsgBox("Ingresar Todos los datos antes de cargar centros", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        End If

    End Sub
    Public Sub ConsultaIngreso()
        Thread.Sleep(20)
        Dim Q As Integer = dtpFecha.Value.Day
        If Q >= 16 Then
            Quincena = "Q2"
        Else
            Quincena = "Q1"
        End If
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCalidadLeche_BuscarIngreso", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CLFechaIngreso", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@CLTipoControl", TipoControl)
        cmd.Parameters.AddWithValue("@CLTipoPeriodo", TipoPeriodo)
        cmd.Parameters.AddWithValue("@CLQuincena", Quincena)
        cmd.Parameters.AddWithValue("@CLPlantaProveedor", General.Plantas.Codigo(cboPlantas.SelectedIndex))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)


        'lvGanado.Items.Clear()


        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    For i = 0 To dgvCalidadLeche.Rows.Count - 1
                        If dgvCalidadLeche.Rows(i).Cells(1).Value = rdr("CLCentro") Then
                            dgvCalidadLeche.Rows(i).Cells(2).Value = rdr("CLLitrosLeche").ToString.Trim
                            dgvCalidadLeche.Rows(i).Cells(3).Value = rdr("CLrcs").ToString.Trim
                            dgvCalidadLeche.Rows(i).Cells(4).Value = rdr("CLGrasa").ToString.Trim
                            dgvCalidadLeche.Rows(i).Cells(5).Value = rdr("CLProteina").ToString.Trim
                            dgvCalidadLeche.Rows(i).Cells(6).Value = rdr("CLUrea").ToString.Trim
                            dgvCalidadLeche.Rows(i).Cells(7).Value = rdr("CLDensidad").ToString.Trim
                            dgvCalidadLeche.Rows(i).Cells(8).Value = rdr("CLCrioscopia").ToString.Trim
                            dgvCalidadLeche.Rows(i).Cells(9).Value = rdr("CLufc").ToString.Trim
                        End If
                    Next
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        GrabarIngresoSolidos()
    End Sub
    Private Sub GrabarIngresoSolidos()
        Dim i As Integer = 0
        Dim Q As Integer = dtpFecha.Value.Day
        If Q >= 16 Then
            Quincena = "Q2"
        Else
            Quincena = "Q1"
        End If
        Dim n As Integer = dgvCalidadLeche.RowCount
        For i = 0 To n - 1
            Cursor.Current = Cursors.WaitCursor

            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spCalidadLeche_GrabarSolidos", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@CLFechaIngreso", dtpFecha.Value)
            cmd.Parameters.AddWithValue("@CLTipoControl", TipoControl)
            cmd.Parameters.AddWithValue("@CLTipoPeriodo", TipoPeriodo)
            cmd.Parameters.AddWithValue("@CLQuincena", Quincena)
            cmd.Parameters.AddWithValue("@CLPlantaProveedor", General.Plantas.Codigo(cboPlantas.SelectedIndex))
            cmd.Parameters.AddWithValue("@CLCentro", dgvCalidadLeche.Rows(i).Cells(1).Value)
            cmd.Parameters.AddWithValue("@CLLitrosLeche", dgvCalidadLeche.Rows(i).Cells(2).Value)
            cmd.Parameters.AddWithValue("@CLrcs", dgvCalidadLeche.Rows(i).Cells(3).Value)
            cmd.Parameters.AddWithValue("@CLGrasa", dgvCalidadLeche.Rows(i).Cells(4).Value)
            cmd.Parameters.AddWithValue("@CLProteina", dgvCalidadLeche.Rows(i).Cells(5).Value)
            cmd.Parameters.AddWithValue("@CLUrea", dgvCalidadLeche.Rows(i).Cells(6).Value)
            cmd.Parameters.AddWithValue("@CLDensidad", dgvCalidadLeche.Rows(i).Cells(7).Value)
            cmd.Parameters.AddWithValue("@CLCrioscopia", dgvCalidadLeche.Rows(i).Cells(8).Value)
            cmd.Parameters.AddWithValue("@CLufc", dgvCalidadLeche.Rows(i).Cells(9).Value)
            cmd.Parameters.AddWithValue("@CLMateriaSolida", dgvCalidadLeche.Rows(i).Cells(10).Value)

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

                ''verificamos error con un valor igual a -1
                If vret = 2 Then
                    Cursor.Current = Cursors.Default

                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    Exit Sub
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                Exit For
            Finally
                con.Close()
            End Try

            ''End If
        Next
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Planta_CheckedChanged(sender As Object, e As EventArgs) Handles Planta.CheckedChanged
        If Planta.Checked = True Then
            TipoControl = Planta.Text
            cboPlantas.Enabled = True
            cboProveedores.Enabled = False
        End If

    End Sub

    Private Sub Interna_CheckedChanged(sender As Object, e As EventArgs) Handles Interna.CheckedChanged
        If Interna.Checked = True Then
            TipoControl = Interna.Text
            cboPlantas.Enabled = False
            cboProveedores.Enabled = True
        End If
    End Sub

    Private Sub Control_CheckedChanged(sender As Object, e As EventArgs) Handles Control.CheckedChanged
        If Control.Checked = True Then
            TipoControl = Control.Text
            cboPlantas.Enabled = False
            cboProveedores.Enabled = True
        End If
    End Sub

    Private Sub preliminar_CheckedChanged(sender As Object, e As EventArgs) Handles preliminar.CheckedChanged
        If preliminar.Checked = True Then
            TipoPeriodo = preliminar.Text
        End If

    End Sub

    Private Sub quincenal_CheckedChanged(sender As Object, e As EventArgs) Handles quincenal.CheckedChanged
        If quincenal.Checked = True Then
            TipoPeriodo = quincenal.Text
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click
        OpenFDlg.FileName = ""
        OpenFDlg.Filter = "Archivos de excel (*.xlsx)|*.xlsx|Archivos de excel 2003 (*.xls)|*.xls"
        OpenFDlg.ShowDialog()
        If OpenFDlg.FileName.Trim() <> "" Then
            ArchivoImportacion = OpenFDlg.FileName.Trim
            NombreArchivo = OpenFDlg.SafeFileName.Trim
            txtArchivo.Text = NombreArchivo
        End If
        Datosexcel()
    End Sub
    Private Sub Datosexcel()
        Dim lin As Integer
        Cursor.Current = Cursors.WaitCursor
        Try
            Dim Procesa As Boolean
            Dim AppExcel As New Application
            Dim Libro As Workbook
            Dim Hoja As Worksheet

            Libro = AppExcel.Workbooks.Open(ArchivoImportacion)
            Hoja = Libro.Worksheets(1)
            lin = 2
            Procesa = True
            Do While Procesa
                If Trim(Hoja.Cells(lin, 1).value) = "" Then
                    Exit Do
                End If
                Diioexcel = Hoja.Cells(lin, 5).value
                Rcsexcel = Hoja.Cells(lin, 6).value
                Grasaexcel = Hoja.Cells(lin, 7).value
                Proteinaexcel = Hoja.Cells(lin, 8).value
                Ureaexcel = Hoja.Cells(lin, 9).value
                Densidadexcel = Hoja.Cells(lin, 10).value
                Crioscopiaexcel = Hoja.Cells(lin, 11).value
                Ufcexcel = Hoja.Cells(lin, 12).value
                ConsultaDIIOPorExel(Diioexcel, Rcsexcel, Grasaexcel, Proteinaexcel, Ureaexcel, Densidadexcel, Crioscopiaexcel, Ufcexcel)
                lin = lin + 1
            Loop
            Hoja = Nothing      'Descargamos los Objetos...
            Libro.Close()
            AppExcel.Quit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor.Current = Cursors.Default
    End Sub
    Public Sub ConsultaDIIOPorExel(ByVal Diioexcel As Integer, ByVal Rcsexcel As Integer, ByVal Grasaexcel As Double, ByVal Proteinaexcel As Double,
                                     ByVal Ureaexcel As Integer, ByVal Densidadexcel As Integer, ByVal Crioscopiaexcel As Integer, ByVal Ufcexcel As Integer)

        For i = 0 To dgvCalidadLeche.Rows.Count - 1
            If dgvCalidadLeche.Rows(i).Cells(1).Value = Diioexcel Then
                dgvCalidadLeche.Rows(i).Cells(3).Value = Rcsexcel.ToString
                dgvCalidadLeche.Rows(i).Cells(4).Value = Grasaexcel.ToString
                dgvCalidadLeche.Rows(i).Cells(5).Value = Proteinaexcel.ToString
                dgvCalidadLeche.Rows(i).Cells(6).Value = Ureaexcel.ToString
                dgvCalidadLeche.Rows(i).Cells(7).Value = Densidadexcel.ToString
                dgvCalidadLeche.Rows(i).Cells(8).Value = Crioscopiaexcel.ToString
                dgvCalidadLeche.Rows(i).Cells(9).Value = Ufcexcel.ToString
            End If
        Next
    End Sub

End Class