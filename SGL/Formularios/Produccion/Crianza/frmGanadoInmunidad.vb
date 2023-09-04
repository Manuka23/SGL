Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Public Class frmGanadoInmunidad
    Dim TipoInmunidad As String
    Private Sub frmGanadoInmunidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        CboLLenaCentros()
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        cboCentros.SelectedIndex = 0
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        frmGanadoInmunidadIngreso.Show()
        frmGanadoInmunidadIngreso.BringToFront()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanadoInmunidad_Detalle", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Cen_ As String = ""

        If cboCentros.SelectedIndex = 0 Then
            Cen_ = 0
        Else
            Cen_ = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        End If

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Cen_)
        cmd.Parameters.AddWithValue("@Inmunidad", TipoInmunidad)
        cmd.Parameters.AddWithValue("@FechaDesde", dtpFechaDesde.Value)
        cmd.Parameters.AddWithValue("@FechaHasta", dtpFechaHasta.Value)
        cmd.Parameters.AddWithValue("@Diio", txtDiio.Text)

        lvInmunidadBuscar.BeginUpdate()
        lvInmunidadBuscar.Items.Clear()

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem((lvInmunidadBuscar.Items.Count + 1).ToString)
                    item.SubItems.Add(rdr("CentroNom")).ToString.Trim()
                    item.SubItems.Add(rdr("InDiio")).ToString.Trim()
                    item.SubItems.Add(rdr("InmunidadTipNom")).ToString.Trim()
                    item.SubItems.Add(rdr("CategoNom")).ToString.Trim()
                    item.SubItems.Add(rdr("InEstProductivo")).ToString.Trim()
                    item.SubItems.Add(rdr("InEstReproductivo")).ToString.Trim()
                    item.SubItems.Add(Format(rdr("InFechaInmunidad"), "dd-MM-yyyy"))
                    item.SubItems.Add(rdr("InUsuarioReg")).ToString.Trim()
                    lvInmunidadBuscar.Items.Add(item)
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        TipoInmunidad = ""
        rbInsuficiente.Checked = False
        rbNormal.Checked = False
        rbSusceptible.Checked = False
        lvInmunidadBuscar.EndUpdate()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub rbNormal_CheckedChanged(sender As Object, e As EventArgs) Handles rbNormal.CheckedChanged
        If rbNormal.Checked Then
            TipoInmunidad = 1
        End If
    End Sub

    Private Sub rbSusceptible_CheckedChanged(sender As Object, e As EventArgs) Handles rbSusceptible.CheckedChanged
        If rbSusceptible.Checked Then
            TipoInmunidad = 2
        End If
    End Sub

    Private Sub rbInsuficiente_CheckedChanged(sender As Object, e As EventArgs) Handles rbInsuficiente.CheckedChanged
        If rbInsuficiente.Checked Then
            TipoInmunidad = 3
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim objExcel As New Microsoft.Office.Interop.Excel.Application
            Dim bkWorkBook As Workbook
            Dim shWorkSheet As Worksheet
            Dim i As Integer
            Dim j As Integer

            objExcel = New Microsoft.Office.Interop.Excel.Application
            bkWorkBook = objExcel.Workbooks.Add
            shWorkSheet = CType(bkWorkBook.ActiveSheet, Worksheet)
            For i = 0 To Me.lvInmunidadBuscar.Columns.Count - 1
                shWorkSheet.Cells(1, i + 1) = Me.lvInmunidadBuscar.Columns(i).Text
            Next
            For i = 0 To Me.lvInmunidadBuscar.Items.Count - 1
                For j = 0 To Me.lvInmunidadBuscar.Items(i).SubItems.Count - 1
                    shWorkSheet.Cells(i + 2, j + 1) = Me.lvInmunidadBuscar.Items(i).SubItems(j).Text
                Next
            Next

            objExcel.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor.Current = Cursors.Default
    End Sub
End Class