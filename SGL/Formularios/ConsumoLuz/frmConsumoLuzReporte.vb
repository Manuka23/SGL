Imports System.Data.SqlClient

Public Class frmConsumoLuzReporte

    Private Sub BuscarDatos(ByVal Year As Integer, ByVal Month As Integer)
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spLuz_ConsumoReporte", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@year", Year)
        cmd.Parameters.AddWithValue("@month", Month)
        lvReporte.BeginUpdate()
        lvReporte.Items.Clear()
        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    Dim item As New ListViewItem(Format(rdr("CodCentro").ToString.Trim))  'primera columna
                    'item.SubItems.Add())
                    item.SubItems.Add(rdr("CentroNom").ToString.Trim)
                    item.SubItems.Add(rdr("CodCasa").ToString.Trim)
                    item.SubItems.Add(rdr("ConsumoActual").ToString.Trim)
                    item.SubItems.Add(rdr("Consumo").ToString.Trim)
                    item.SubItems.Add(rdr("Cod").ToString.Trim)
                    lvReporte.Items.Add(item)
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
        lvReporte.EndUpdate()
    End Sub

    Private Function BuscarPahtArchivo(ByVal Cod As String) As String
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spLuz_PathArchivo", con)
        Dim rdr = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Cod", Cod)

        Dim i As Integer = 0
        Dim e As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteScalar()
            If rdr IsNot Nothing Then
                Return rdr.ToString()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        Return String.Empty
    End Function

    Private Sub frmConsumoLuzReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For y = 2017 To DateTime.Now.Year
            cbxYear.Items.Add(y)
        Next
        cbxYear.SelectedItem = DateTime.Now.Year
        BuscarDatos(cbxYear.SelectedItem, cbxMes.SelectedIndex + 1)
        LLenarCbxMeses()
        cbxMes.SelectedIndex = DateTime.Now.Month - 1
        Me.MdiParent = frmMAIN
        Me.Top = 30
        Me.Left = 15
        BuscarDatos(cbxYear.SelectedItem, cbxMes.SelectedIndex + 1)
    End Sub

    Private Sub cbxYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxYear.SelectedIndexChanged
        BuscarDatos(cbxYear.SelectedItem, cbxMes.SelectedIndex + 1)
    End Sub

    Private Sub LLenarCbxMeses()
        cbxMes.Items.Add("Enero")
        cbxMes.Items.Add("Febrero")
        cbxMes.Items.Add("Marzo")
        cbxMes.Items.Add("Abril")
        cbxMes.Items.Add("Mayo")
        cbxMes.Items.Add("Junio")
        cbxMes.Items.Add("Julio")
        cbxMes.Items.Add("Agosto")
        cbxMes.Items.Add("Septiembre")
        cbxMes.Items.Add("Octubre")
        cbxMes.Items.Add("Noviembre")
        cbxMes.Items.Add("Diciembre")
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub modificar_Click(sender As Object, e As EventArgs) Handles modificar.Click
        Dim validalista As Integer = 0
        For i = 0 To lvReporte.Items.Count - 1
            If lvReporte.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe seleccionar un consumo de la Lista")
            Exit Sub
        End If
        frmConsumoLuz_Editar.Show()
    End Sub

    Private Sub cbxMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMes.SelectedIndexChanged
        BuscarDatos(cbxYear.SelectedItem, cbxMes.SelectedIndex + 1)
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

    Private Sub lvReporte_Click(sender As Object, e As EventArgs) Handles lvReporte.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim validalista As Integer = 0
        For i = 0 To lvReporte.Items.Count - 1
            If lvReporte.Items(i).Selected = True Then
                validalista = 1
                Exit For
            End If
        Next
        If validalista = 0 Then
            MsgBox("Debe Seleccionar un item de la Lista")
            Exit Sub
        End If
        Descargar()
    End Sub
    Private Sub Descargar()
        Dim NombreArchivo = BuscarPahtArchivo(lvReporte.SelectedItems.Item(0).SubItems(5).Text)
        NombreArchivo = NombreArchivo.Replace("\\srvmnkqa\img\", "")
        Dim PathEscritorio As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\"
        Dim PathRemoto As String = BuscarParametros(2).TrimEnd("/").TrimEnd("\") + "\"

        If System.IO.File.Exists(PathEscritorio + NombreArchivo) Then
            MsgBox(String.Format("El archivo ya existe en Escritorio ({0})", NombreArchivo), MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Archivo")
        Else
            System.IO.File.Copy(PathRemoto + NombreArchivo, PathEscritorio + NombreArchivo)
            MsgBox(String.Format("Archivo guardado en Escritorio ({0})", NombreArchivo), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Archivo")
        End If
    End Sub
End Class