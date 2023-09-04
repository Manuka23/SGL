Imports System.Data.SqlClient
Imports System.IO

Public Class frmConsumoLuz_Ingreso
    Private NombreArchivo As String
    Private RutaFinal As String
    Private RutaFinalCompleta As String
    Private RutaLocal As String

    Private Sub frmConsumoIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLLenaCentros()
        Dim Dia As Integer = Integer.Parse(BuscarParametros(3))
        Dim Fecha As Date = New DateTime(DateTime.Now.Year, DateTime.Now.Month, Dia)
        lblPeriodo.Text = String.Format("{0}/{1}/{2} - {3}/{4}/{5}", Fecha.AddMonths(-1).AddDays(1).Day, Fecha.AddMonths(-1).Month.ToString().PadLeft(2, "0"), Fecha.AddMonths(-1).Year, Fecha.Day, Fecha.Month.ToString().PadLeft(2, "0"), Fecha.Year)
        ChartConsumo.Visible = False
        ChartConsumo.ChartAreas(0).AxisX.LabelStyle.Angle = -90
    End Sub

    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        cbxCentros.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")
        Dim i As Integer
        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cbxCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        RutaFinal = "" + System.IO.Path.GetFileNameWithoutExtension(NombreArchivo) + " - " + String.Format("{0:yyyy/MM/dd hh:mm:ss.fff}", DateTime.Now).Replace("/", "").Replace(":", "").Replace(".", "").Replace(" ", "").Replace("-", "") + System.IO.Path.GetExtension(NombreArchivo)
        RutaFinalCompleta = BuscarParametros(2).TrimEnd("/").TrimEnd("\") + "\" + RutaFinal

        Cursor.Current = Cursors.WaitCursor
        If ValidacionesLocales() Then
            If GuardarArchivo() Then
                If Guardar(General.CentrosUsuario.Codigo(cbxCentros.SelectedIndex), Casa.Cod(cbxCasa.SelectedIndex), RutaFinal, numKw.Value) Then
                    Graficar(General.CentrosUsuario.Codigo(cbxCentros.SelectedIndex), Casa.Cod(cbxCasa.SelectedIndex))
                End If
            End If
        End If
        Cursor.Current = Cursors.Default
    End Sub

    Private Function Guardar(ByVal _CodCentro As String, ByVal _CodCasa As String, ByVal _Path As String, ByVal _Consumo As String)
        Guardar = False
        Dim FechaHoy = DateTime.Now
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spLuz_ConsumoAgregar", con)

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@CenCod", _CodCentro)
        cmd.Parameters.AddWithValue("@CodCasa", _CodCasa)
        cmd.Parameters.AddWithValue("@Consumo", _Consumo)
        cmd.Parameters.AddWithValue("@PathArchivo", _Path)
        cmd.Parameters.AddWithValue("@Periodo", String.Format("{0}/{1}/{2}", 15, FechaHoy.Month.ToString().PadLeft(2, "0"), FechaHoy.Year))
        cmd.Parameters.Add("@Text", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@Text").Direction = ParameterDirection.Output

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Guardar = True
            Dim test As String = cmd.Parameters("@Text").Value
            Dim ce As String = cmd.Parameters("@CenCod").Value
            MsgBox(test, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
    End Function

    Private Function GuardarArchivo()
        GuardarArchivo = False
        Dim RutaCarpeta As String = BuscarParametros(2).TrimEnd("/").TrimEnd("\")
        Try
            If Directory.Exists(RutaCarpeta) Then

                My.Computer.FileSystem.CopyFile(RutaLocal, RutaFinalCompleta)

                    Else
                Directory.CreateDirectory(RutaCarpeta)
                My.Computer.FileSystem.CopyFile(RutaLocal, RutaFinalCompleta)
            End If
            GuardarArchivo = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
        End Try
    End Function

    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False

        If cbxCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cbxCentros.Focus()
            Exit Function
        End If
        If cbxCasa.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CASA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cbxCasa.Focus()
            Exit Function
        End If

        If String.IsNullOrWhiteSpace(RutaLocal) Then
            If MsgBox("DEBE SELECCIONAR UNA IMAGEN", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            Exit Function
        End If

        Dim Dia As Integer = Integer.Parse(BuscarParametros(3))
        Dim Fecha As Date = New DateTime(DateTime.Now.Year, DateTime.Now.Month, Dia)
        Dim Hoy As Date = Date.Now
        Dim a = Fecha.AddDays(-1)
        Dim b = Fecha.AddDays(1)
        'If Date.Compare(Hoy, Fecha.AddDays(-1)) < 0 Or Date.Compare(Hoy, Fecha.AddDays(2)) > 0 Then
        '    If MsgBox(String.Format("SOLO SE PUEDE INGRESAR EL CONSUMO EL DIA {0} AL {1}", Fecha.AddDays(-1).ToShortDateString(), Fecha.AddDays(1).ToShortDateString()), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
        '    End If
        '    Exit Function
        'End If
        ValidacionesLocales = True
    End Function

    Private Sub BuscarCasas()
        Dim i As Integer
        Dim a As String
        cbxCasa.Items.Clear()

        a = General.CentrosUsuario.Codigo(cbxCentros.SelectedIndex)
        Casa.Listado(a)
        For i = 0 To Casa.NroRegistros - 1
            cbxCasa.Items.Add(Casa.Cod(i))
        Next

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub

    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCentros.SelectedIndexChanged
        BuscarCasas()
        If cbxCentros.SelectedIndex >= 0 And cbxCasa.SelectedIndex >= 0 Then
            Graficar(General.CentrosUsuario.Codigo(cbxCentros.SelectedIndex), Casa.Cod(cbxCasa.SelectedIndex))
            ChartConsumo.Visible = True
        Else
            ChartConsumo.Visible = False
        End If

    End Sub

    Private Sub cbxCasa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCasa.SelectedIndexChanged
        If cbxCentros.SelectedIndex >= 0 And cbxCasa.SelectedIndex >= 0 Then
            Graficar(General.CentrosUsuario.Codigo(cbxCentros.SelectedIndex), Casa.Cod(cbxCasa.SelectedIndex))
            ChartConsumo.Visible = True

        Else
            ChartConsumo.Visible = False

        End If
    End Sub

    Private Sub btnArchivo_Click(sender As Object, e As EventArgs) Handles btnArchivo.Click
        Dim openFD As New OpenFileDialog()
        With openFD
            .Title = "Seleccionar archivo"
            .Filter = "Imagen (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim Path As String = .FileName
                RutaLocal = Path
                pbImagen.ImageLocation = Path
                NombreArchivo = System.IO.Path.GetFileName(Path)

                '--------------------------------
                'Dim base64String As String = Convert.ToBase64String(File.ReadAllBytes(Path))
                'Dim imageBytes() As Byte = Convert.FromBase64String(base64String)
                'Dim ms As MemoryStream = New MemoryStream(imageBytes, 0, imageBytes.Length)

                'MS.Write(imageBytes, 0, imageBytes.Length)
                'Dim image As Image = Image.FromStream(ms, True)
                'pbImagen.Image = image
                '---------------------------------*/
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom
            End If
        End With
    End Sub

    Public Function BuscarParametros(ByVal Codigo As Integer) As String

        Dim Valor As String = String.Empty

        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spBuscarParametro]", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@ParCod", Codigo)

        cmd.Parameters.Add("@ParItem", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ParItem").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ParValor", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ParValor").Direction = ParameterDirection.Output

        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Valor = cmd.Parameters("@ParValor").Value

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
        Return Valor
    End Function

    Private Sub Graficar(ByVal CodCentro As String, ByVal CodCasa As String)
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spLuz_ConsumoGrafico", con)
        Dim rdrGraphic As SqlDataReader = Nothing
        Dim CntTexto = ""
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@CodCentro", CodCentro)
        cmd.Parameters.AddWithValue("@CodCasa", CodCasa)
        Try
            con.Open()
            rdrGraphic = cmd.ExecuteReader()
            ChartConsumo.Series("Series1").Points.DataBindXY(rdrGraphic, "Periodo", rdrGraphic, "Consumo")
            ChartConsumo.Series("Series1").IsVisibleInLegend = False
            ChartConsumo.Titles("Title1").Text = "EVOLUCION CONSUMO"
            rdrGraphic.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


End Class