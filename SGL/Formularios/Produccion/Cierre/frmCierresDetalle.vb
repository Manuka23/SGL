

Imports System.Data.SqlClient



Public Class frmCierresDetalle

    Public Param1_Centro As String
    Public Param2_Anio As Integer
    Public Param3_Mes As Integer
    Public Param4_Fecha As Date



    Public Sub ConsultaDetalleCierre()
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCierres_ListadoDetalle2", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_Centro)
        cmd.Parameters.AddWithValue("@Fecha", Param4_Fecha)
        cmd.Parameters.AddWithValue("@Anio", Param2_Anio)
        cmd.Parameters.AddWithValue("@Mes", Param3_Mes)
        cmd.Parameters.AddWithValue("@DIIO", txtDIIO.Text)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        lvDETALLE.BeginUpdate()
        lvDETALLE.Items.Clear()
        Label29.Text = "0"

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0
        Dim totvacas As Integer = 0
        Dim totcelos As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos

                'item.SubItems.Add((i + 1).ToString.Trim)
                item.SubItems.Add(rdr("CiDetEmpresa").ToString.Trim)
                item.SubItems.Add(rdr("CiDetDiio").ToString.Trim)
                item.SubItems.Add(rdr("CategoNom").ToString.Trim)
                item.SubItems.Add(rdr("CiDetEstProductivo").ToString.Trim)
                item.SubItems.Add(rdr("CiDetEstReproductivo").ToString.Trim)

                lvDETALLE.Items.Add(item)

                i = i + 1
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        Label29.Text = i.ToString
        lvDETALLE.EndUpdate()
        Cursor.Current = Cursors.Default
    End Sub



    Private Sub frmCierresDetalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)


    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub txtDIIO_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDIIO.TextChanged
        ConsultaDetalleCierre()
    End Sub


    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        If lvDETALLE.Items.Count = 0 Then Exit Sub

        Dim tot(1, 2) As String '= {{"", ""}, {"", ""}}

        tot(0, 0) = "N° DE ANIMALES EN CIERRE " : tot(0, 1) = Label29.ToString.Trim

        ExportToExcelGrilla(lvDETALLE, tot)
    End Sub
End Class