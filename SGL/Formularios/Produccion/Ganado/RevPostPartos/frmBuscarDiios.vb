Imports System.Data.SqlClient
Public Class frmBuscarDiios
    Private Sub frmBuscarDiios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub LeeBaston()
        frmBastonV2.Param3_Formulario = "frmConsultaDiio"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing

    End Sub
    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim diio_ As String = ""
        Dim strdiios_ As String = ""
        Dim TotDiios As Integer

        Cursor.Current = Cursors.WaitCursor

        lvBuscarDiios.Items.Clear()
        lvBuscarDiios.BeginUpdate()

        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            strdiios_ = strdiios_ + diio_ + ","
            Dim item As New ListViewItem
            item.SubItems.Add(diio_)
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            item.SubItems.Add("")
            If VerificaDIIOEnGrilla(-1, diio_) = True Then
                item.SubItems.Add("ERR / REPETIDO")
            Else
                item.SubItems.Add("OK")
            End If

            lvBuscarDiios.Items.Add(item)
        Next

        If strdiios_.Length > 0 Then
            strdiios_ = Mid(strdiios_, 1, strdiios_.Length - 1)
        End If

        TotDiios = BuscarDiiosBaston(strdiios_)
        lvBuscarDiios.EndUpdate()
        Cursor.Current = Cursors.Default
    End Sub
    Private Function VerificaDIIOEnGrilla(ByVal pos_ As Integer, ByVal diio_ As String) As Boolean
        VerificaDIIOEnGrilla = False

        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvBuscarDiios.Items.Count - 1
            If i <> pos_ Then
                If lvBuscarDiios.Items(i).SubItems(1).Text.ToString.Trim = diio_ Then
                    existe_ = True
                    Exit For
                End If

            End If
        Next

        VerificaDIIOEnGrilla = existe_
    End Function
    Private Function BuscarDiiosBaston(ByVal diios_ As String) As Integer
        BuscarDiiosBaston = 0

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spConsultaDiio", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@ArrayDIIOs", diios_)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvBuscarDiios.BeginUpdate()

        Dim i As Integer = 0
        Dim diio_ As String = ""
        Dim est_ As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    diio_ = rdr("GndCod").ToString.Trim
                    For i = 0 To lvBuscarDiios.Items.Count - 1
                        If lvBuscarDiios.Items(i).SubItems(1).Text.Trim = diio_ Then

                            lvBuscarDiios.Items(i).SubItems(20).Text = rdr("GndCenCod").ToString.Trim
                            lvBuscarDiios.Items(i).SubItems(0).Text = rdr("CentroNom").ToString.Trim
                            lvBuscarDiios.Items(i).SubItems(2).Text = rdr("GndProNom").ToString.Trim
                            lvBuscarDiios.Items(i).SubItems(3).Text = Format(rdr("GndFecNac"), "yyyy-MM-dd")
                            lvBuscarDiios.Items(i).SubItems(4).Text = rdr("NomRaza").ToString.Trim
                            lvBuscarDiios.Items(i).SubItems(5).Text = rdr("GndEstado").ToString.Trim
                            lvBuscarDiios.Items(i).SubItems(6).Text = rdr("GndEstadoProductivo").ToString.Trim
                            lvBuscarDiios.Items(i).SubItems(7).Text = rdr("GndEstadoReproductivo").ToString.Trim
                            lvBuscarDiios.Items(i).SubItems(8).Text = rdr("DiasLactancia").ToString.Trim

                            If IsDBNull(rdr("GndUltFechaPriPartos")) Then
                                lvBuscarDiios.Items(i).SubItems(9).Text = ""
                            Else
                                lvBuscarDiios.Items(i).SubItems(9).Text = Format(rdr("GndUltFechaPriPartos"), "yyyy-MM-dd")
                            End If

                            If IsDBNull(rdr("GndUltFechaParto")) Then
                                lvBuscarDiios.Items(i).SubItems(9).Text = ""
                            Else
                                lvBuscarDiios.Items(i).SubItems(10).Text = Format(rdr("GndUltFechaParto"), "yyyy-MM-dd")
                            End If

                            lvBuscarDiios.Items(i).SubItems(11).Text = rdr("GndUltPartoFormaParto").ToString.Trim
                            lvBuscarDiios.Items(i).SubItems(12).Text = rdr("GndActPartosNum").ToString.Trim

                            If IsDBNull(rdr("GndUltCubierta")) Then
                                lvBuscarDiios.Items(i).SubItems(9).Text = ""
                            Else
                                lvBuscarDiios.Items(i).SubItems(13).Text = Format(rdr("GndUltCubierta"), "yyyy-MM-dd")
                            End If

                            lvBuscarDiios.Items(i).SubItems(14).Text = rdr("GndUltCubiertaNum").ToString.Trim

                            If IsDBNull(rdr("GndUltFechaCelo")) Then
                                lvBuscarDiios.Items(i).SubItems(9).Text = ""
                            Else
                                lvBuscarDiios.Items(i).SubItems(15).Text = Format(rdr("GndUltFechaCelo"), "yyyy-MM-dd")
                            End If

                            lvBuscarDiios.Items(i).SubItems(16).Text = rdr("CIDR").ToString.Trim

                            If IsDBNull(rdr("CIDRFecha")) Then
                                lvBuscarDiios.Items(i).SubItems(9).Text = ""
                            Else
                                lvBuscarDiios.Items(i).SubItems(17).Text = Format(rdr("CIDRFecha"), "yyyy-MM-dd")
                            End If
                            If IsDBNull(rdr("GndUlFechaRevPP")) Then
                                lvBuscarDiios.Items(i).SubItems(9).Text = ""
                            Else
                                lvBuscarDiios.Items(i).SubItems(18).Text = Format(rdr("GndUlFechaRevPP"), "yyyy-MM-dd")
                            End If

                            lvBuscarDiios.Items(i).SubItems(19).Text = rdr("GndUltRevPPCondicion").ToString.Trim
                            'If IsDBNull(rdr("MDetEstado")) Then
                            '    lvConsultaDiio.Items(i).SubItems(5).Text = "FINALIZADO"
                            'Else
                            '    lvConsultaDiio.Items(i).SubItems(5).Text = rdr("MDetEstado")
                            'End If

                            'If VerificaDIIOEnGrilla(i, diio_) = True Then
                            '    lvConsultaDiio.Items(i).SubItems(6).Text = "ERR / REPETIDO"
                            'End If

                        End If
                    Next

                    'i = i + 1
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        BuscarDiiosBaston = i

        'lblTotSecados.Text = i.ToString.Trim
        lvBuscarDiios.EndUpdate()
    End Function

    Private Sub btnLeerBaston_Click(sender As Object, e As EventArgs) Handles btnLeerBaston.Click
        LeeBaston()
    End Sub
End Class