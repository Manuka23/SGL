Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class frmCarga
    Dim Path = ""
    Dim Tipo = ""
    Dim SinProblema = True

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor.Current = Cursors.WaitCursor
        If ValidacionesLocales() Then
            Try


                Dim openFD As New OpenFileDialog()
                With openFD

                    .Title = "Seleccionar archivo"
                    .Filter = "Excel | *.xls; *.xlsx;"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        Me.cbxTipo.Enabled = False
                        Me.Button1.Enabled = False
                        Me.Button2.Enabled = False
                        Me.ProgressBar1.Visible = True
                        Tipo = cbxTipo.SelectedIndex
                        Path = .FileName
                        Me.BackgroundWorker1.RunWorkerAsync()
                        MsgBox("DATOS GUARDADOS", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show("" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False
        If cbxTipo.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN TIPO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cbxTipo.Focus()
            Exit Function
        End If
        ValidacionesLocales = True
    End Function

    Private Function Guardar(id As String, centro As String, fecha As DateTime, valor As Double) As Double

        Dim ConnectionString As String = GetConnectionStringBI()

        Dim query As String = "insert_budget"
        Using Connection As System.Data.SqlClient.SqlConnection = New System.Data.SqlClient.SqlConnection(ConnectionString)
            Try
                Connection.Open()
                Using cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand(query, Connection)
                    cmd.Parameters.AddWithValue("CentroCod", centro)
                    cmd.Parameters.AddWithValue("Fecha", fecha)
                    cmd.Parameters.AddWithValue("Actual", valor)
                    cmd.CommandType = CommandType.StoredProcedure
                    If centro.Equals("0") Then 'si el centro es 0 cambier el id
                        id = 24
                        cmd.Parameters.AddWithValue("tipo", id)

                        If valor <> 0 Then 'si el valor es distinto de 0 guardar
                            cmd.ExecuteNonQuery()
                        End If
                    Else
                        cmd.Parameters.AddWithValue("tipo", id)

                        cmd.ExecuteNonQuery()
                    End If
                    Guardar = True
                End Using
            Catch ex As Exception
                Dim a As Integer = 0

                SinProblema = False
                Guardar = False
                'MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
            Finally
                Connection.Close()
            End Try
        End Using

    End Function

    Public Function ObternerDatosExcel(ByVal RutaArchivo As String, ByVal NombreHoja As String) As DataTable
        Dim ConnectionTipoString As String
        Dim Extension As String = System.IO.Path.GetExtension(RutaArchivo).ToLower()
        If (Extension.Equals(".xlsx")) Then
            ConnectionTipoString = "Provider=Microsoft.ACE.OLEDB.12.0; Extended Properties='Excel 12.0 Xml; HDR=NO';"
        Else
            ConnectionTipoString = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Excel 8.0;HDR=NO';"
        End If
        Dim ConnectionString As String = ConnectionTipoString & " Data Source=" & RutaArchivo

        Try
            Using Conn As New OleDbConnection(ConnectionString)
                Conn.Open()
                Dim dtHojaExcel As DataTable = Conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                Dim NombreHojaExcel As String = Convert.ToString(dtHojaExcel.Rows(0)("TABLE_NAME"))
                Dim Query As String = String.Format("SELECT * FROM [{0}] WHERE [F2] IS NOT NULL", NombreHojaExcel)
                Dim da As New OleDbDataAdapter(Query, Conn)
                Dim dt As New DataTable()
                da.Fill(dt)
                Conn.Close()
                Return dt
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Function

    Private Sub Buscar()
        TipoBudget.Listado(LoginUsuario)

        For index = 0 To TipoBudget.NroRegistros - 1
            cbxTipo.Items.Add(TipoBudget.Desc(index))
        Next
    End Sub

    Private Sub frmCarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ProgressBar1.Visible = False
        Me.Label1.Text = ""
        Buscar()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Try

        BackgroundWorker1.ReportProgress(0, "Procesando...")
        Dim dt As DataTable = ObternerDatosExcel(Path, "")

        'Dim ListaCentros() As String = {"1012000", "120100"}
        Dim ListaCentros = BuscarCentrosTodos()

#Region "Validar centros"
        'Dim MensajeValidacion As String = String.Empty
        'Dim tF As Integer = 0
        'Dim tC As Integer = 0
        'Do While (tC < dt.Columns.Count)
        '    Dim tE As Boolean = False

        '    Dim tCentro As String = dt.Rows(0)(tC).ToString
        '    If Not String.IsNullOrWhiteSpace(tCentro) Then

        '        Do While (tF < ListaCentros.Count)
        '            If (tCentro.Trim().Equals(ListaCentros(tF).Trim())) Then
        '                tE = True
        '            End If
        '            tF = tF + 1
        '        Loop

        '    End If
        '    If (tE = False) Then
        '        MensajeValidacion += tCentro + ", "
        '    End If
        '    tC = tC + 1
        'Loop
        'If (String.IsNullOrWhiteSpace(MensajeValidacion)) Then
        'Else
        '    Throw New ArgumentException("Los centros (" + MensajeValidacion.Trim(",") + ") no existe, favor revisar. Datos no cargados")
        'End If

        Dim MensajeValidacion As String = String.Empty
        Dim largoE As Integer = 0
        'Do While (tC < dt.Columns.Count)
        Do While (largoE < dt.Columns.Count)
            Dim tE As Boolean = False
            Dim largoO As Integer = 0
            Dim centroO As String = dt.Rows(0)(largoE).ToString().Trim()
            If Not String.IsNullOrWhiteSpace(centroO) Then

                Do While (largoO < ListaCentros.Count)
                    If (centroO.Trim().Equals(ListaCentros(largoO).Trim())) Then
                        tE = True
                    End If
                    largoO = largoO + 1
                Loop
                If (tE = False) Then
                    MensajeValidacion += centroO + ", "
                End If
            End If

            largoE = largoE + 1

        Loop



        'Dim tE As Boolean = False

        'Dim tCentro As String = dt.Rows(tF)(0).ToString
        'If Not String.IsNullOrWhiteSpace(tCentro) Then

        '    Do While (tF < ListaCentros.Count)
        '        If (tCentro.Trim().Equals(ListaCentros(tF).Trim())) Then
        '            tE = True
        '        End If
        '        tF = tF + 1
        '    Loop

        'End If
        'If (tE = False) Then
        '    MensajeValidacion += tCentro + ", "
        'End If
        'tC = tC + 1

        If Not (String.IsNullOrWhiteSpace(MensajeValidacion)) Then
            Throw New ArgumentException("Los centros (" + MensajeValidacion.Trim().Trim(",") + ") no existe, favor revisar. Datos no cargados")
        End If
#End Region

        Dim c As Integer = 1
        Do While (c < dt.Columns.Count) ''columnas --> centros
            Dim centro As String = dt.Rows(0)(c).ToString
            Dim f As Integer = 1
            Do While (f < (dt.Rows.Count))

                Dim fechan As String = dt.Rows(f)(0).ToString
                Dim temp As Double
                Dim fecha As DateTime
                If Double.TryParse(fechan, temp) Then
                    fecha = (New DateTime(1900, 1, 1).AddDays(IIf(String.IsNullOrWhiteSpace(fechan), 0, (Double.Parse(fechan) - 2))))
                Else
                    fecha = fechan
                End If

                Dim valor As Double = IIf(String.IsNullOrWhiteSpace(dt.Rows(f)(c).ToString), 0, Double.Parse(dt.Rows(f)(c).ToString))
                If Not String.IsNullOrWhiteSpace(centro) Then
                    If Guardar(TipoBudget.Cod(Tipo), centro, fecha, valor) = False Then
                        Throw New InvalidOperationException("Lo sentimos a ocurrido un error en la carga de datos (db)")
                        'e.Result = "Lo sentimos a ocurrido un error en la carga de datos (db)"
                        'MessageBox.Show("Lo sentimos a ocurrido un error en la carga de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
                f = (f + 1)
            Loop
            c = (c + 1)
            BackgroundWorker1.ReportProgress(100 * (c - 1) / (dt.Columns.Count - 1), "Cargando " & c - 1 & " centros  de " & dt.Columns.Count - 1 & ".")
        Loop
        'BackgroundWorker1.ReportProgress(100, "Completado!")
        e.Result = "DATOS CARGADOS"

        'Catch ex As Exception

        '    SinProblema = False

        '    e.Result = ex.Message

        'End Try
    End Sub

    Private Function BuscarCentrosTodos() As List(Of String)
        Dim Lista As List(Of String) = New List(Of String)

        'Dim Lista() As String
        Dim con As New SqlConnection(GetConnectionStringBI())
        '        Dim cmd As New SqlCommand("SELECT [CentroCod],[CentroNom]FROM [MANUKA_BI].[dbo].[MBI_CentroGestion]
        'WHERE CentroTipo='SALA'", con)
        Dim cmd As New SqlCommand("SELECT  [CentroCod] FROM [MANUKA_BI].[dbo].[listado_centros_carga]", con)
        Dim rdr = Nothing
        'cmd.CommandType = Data.CommandType.StoredProcedure
        'cmd.Parameters.AddWithValue("@CodCentro", Centro)
        'cmd.Parameters.AddWithValue("@CodCasa", CodCasa)
        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            Dim Data As SqlDataReader = cmd.ExecuteReader()
            While Data.Read
                If Data.HasRows = True Then
                    Lista.Add(Data(0).ToString())
                End If
            End While

            'rdr = cmd.ExecuteScalar()
            '    If rdr IsNot Nothing Then
            '        'Return rdr.ToString()
            '    Else
            '        'Return "0"
            '    End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return Lista

    End Function


    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            Me.cbxTipo.Enabled = True
            Me.Button1.Enabled = True
            Me.Button2.Enabled = True
            Me.ProgressBar1.Visible = False
            Me.Label1.Text = ""


            If (e.Error IsNot Nothing) Then
                If (TypeOf e.Error Is ArgumentException) Then
                    MessageBox.Show(e.Error.Message, "Centros invalidos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


            ElseIf e.Cancelled Then
                MessageBox.Show("Cancelado", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show(e.Result.ToString(), "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


            'If SinProblema Then
            '    MessageBox.Show("DATOS CARGADOS", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Else
            '    MessageBox.Show("Lo sentimos a ocurrido un error en la carga de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'End If
        Catch ex As Exception
            Me.cbxTipo.Enabled = True
            Me.Button1.Enabled = True
            Me.Button2.Enabled = True
            Me.ProgressBar1.Visible = False
            Me.Label1.Text = ""
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try
            ProgressBar1.Value = e.ProgressPercentage
            Label1.Text = e.UserState
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class