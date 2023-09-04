

Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms


Public Class frmRptTraslado
    'Public Param1_GuiaPara = 1              '1=traslado / 2=venta
    Public Centro As String = ""
    Public TipoGuia As Integer = 0
    Public NroGuia As Integer = 0

    Private CodigoTraslado As Integer = 0
    Private paramslist = New List(Of ReportParameter)



    Private Sub BuscarTrasladoPorGuia()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_BuscarPorGuia", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CentroOrigen", Centro)
        cmd.Parameters.AddWithValue("@Guia", NroGuia)
        cmd.Parameters.AddWithValue("@TipoGuia", TipoGuia)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Dim existe As Boolean = False
        Dim i As Integer = 0
        Dim rut As String

        CodigoTraslado = 0
        'Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    existe = True
                    CodigoTraslado = rdr("TrasCodigo")
                    rut = rdr("Rut").ToString.Trim 'FormateaRUT(rdr("FunCod").ToString.Trim, rdr("FunDV").ToString.Trim)


                    paramslist.Add(New ReportParameter("NroGuia", rdr("TrasNroInterno").ToString.Trim))
                    'paramslist.Add(New ReportParameter("Nombre", rdr("EmpRazSoc").ToString.Trim))
                    'paramslist.Add(New ReportParameter("Direccion", rdr("EmpDir").ToString.Trim))
                    'paramslist.Add(New ReportParameter("Giro", "PRODUCCIÓN LECHERA AGRICOLA Y GANADERA"))
                    'paramslist.Add(New ReportParameter("Comuna", rdr("EmpLocCod").ToString.Trim))
                    'paramslist.Add(New ReportParameter("Rut", FormateaRUT(rdr("EmpRut"), rdr("EmpDV"))))
                    paramslist.Add(New ReportParameter("Fecha", Format(rdr("TrasFecha"), "dd-MM-yyyy")))
                    paramslist.Add(New ReportParameter("NombreUsuario", rdr("UsuNom").ToString.Trim))
                    paramslist.Add(New ReportParameter("RutUsuario", rut))
                    paramslist.Add(New ReportParameter("Movimiento", "TRASLADO"))
                    paramslist.Add(New ReportParameter("CodigoOrigen", "0"))
                    paramslist.Add(New ReportParameter("NombreOrigen", rdr("CentroOrigen").ToString.Trim))
                    paramslist.Add(New ReportParameter("CodigoDestino", "0"))
                    paramslist.Add(New ReportParameter("NombreDestino", rdr("CentroDestino").ToString.Trim))
                    'paramslist.Add(New ReportParameter("ListadoDIIOs", "LISTADO DE DIIOS"))
                    paramslist.Add(New ReportParameter("Observacion", rdr("TrasObservs").ToString.Trim))
                    'paramslist.Add(New ReportParameter("Total", "-1"))
                    paramslist.Add(New ReportParameter("Valor", "0.-"))

                    'rvTraslados.LocalReport.SetParameters(paramslist)

                    Exit While
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


    'Private Sub BuscarVentaPorGuia()
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spVentas_BuscarPorGuia", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@Empresa", Empresa)
    '    cmd.Parameters.AddWithValue("@Guia", NroGuia)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    Dim existe As Boolean = False
    '    Dim i As Integer = 0
    '    CodigoTraslado = 0
    '    'Dim vret As Integer = 0

    '    Try
    '        con.Open()
    '        rdr = cmd.ExecuteReader()

    '        Try
    '            While rdr.Read()
    '                existe = True
    '                CodigoTraslado = rdr("TrasCodigo")

    '                paramslist.Add(New ReportParameter("NroGuia", rdr("TrasGuia").ToString.Trim))
    '                paramslist.Add(New ReportParameter("Nombre", rdr("EmpRazSoc").ToString.Trim))
    '                paramslist.Add(New ReportParameter("Direccion", rdr("EmpDir").ToString.Trim))
    '                paramslist.Add(New ReportParameter("Giro", "PRODUCCIÓN LECHERA AGRICOLA Y GANADERA"))
    '                paramslist.Add(New ReportParameter("Comuna", rdr("EmpLocCod").ToString.Trim))
    '                paramslist.Add(New ReportParameter("Rut", FormateaRUT(rdr("EmpRut"), rdr("EmpDV"))))
    '                paramslist.Add(New ReportParameter("Fecha", Format(rdr("TrasFecha"), "dd-MM-yyyy")))
    '                paramslist.Add(New ReportParameter("NombreUsuario", LoginUsuario))
    '                paramslist.Add(New ReportParameter("RutUsuario", ""))
    '                paramslist.Add(New ReportParameter("Movimiento", "TRASLADO"))
    '                paramslist.Add(New ReportParameter("CodigoOrigen", "0"))
    '                paramslist.Add(New ReportParameter("NombreOrigen", rdr("CentroOrigen").ToString.Trim))
    '                paramslist.Add(New ReportParameter("CodigoDestino", "0"))
    '                paramslist.Add(New ReportParameter("NombreDestino", rdr("CentroDestino").ToString.Trim))
    '                'paramslist.Add(New ReportParameter("ListadoDIIOs", "-1"))
    '                paramslist.Add(New ReportParameter("Observacion", rdr("TrasObservs").ToString.Trim))
    '                'paramslist.Add(New ReportParameter("Total", "-1"))
    '                paramslist.Add(New ReportParameter("Valor", "200.000.-"))

    '                'rvTraslados.LocalReport.SetParameters(paramslist)

    '                Exit While
    '            End While



    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub


    Private Sub BuscarDetalleTraslado()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTraslados_ListadoDetalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodTraslado", CodigoTraslado)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Dim existe As Boolean = False
        Dim i As Integer = 0
        Dim diios As String = ""

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    existe = True
                    diios = diios + rdr("TDetDIIO").ToString.Trim + vbTab + " " + vbTab + " "
                    i += 1
                End While

                If existe = True Then
                    paramslist.Add(New ReportParameter("ListadoDIIOs", diios))
                    paramslist.Add(New ReportParameter("Total", i.ToString.Trim))
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    'Private Sub BuscarDetalleVenta()
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spVentas_ListadoDetalle", con)
    '    Dim rdr As SqlDataReader = Nothing

    '    cmd.CommandType = Data.CommandType.StoredProcedure

    '    cmd.Parameters.AddWithValue("@codigo", CodigoTraslado)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    Dim existe As Boolean = False
    '    Dim i As Integer = 0
    '    Dim diios As String = ""

    '    Try
    '        con.Open()
    '        rdr = cmd.ExecuteReader()

    '        Try
    '            While rdr.Read()
    '                existe = True
    '                diios = diios + rdr("TDetDIIO").ToString.Trim + vbTab + " " + vbTab + " "
    '                i += 1
    '            End While

    '            If existe = True Then
    '                paramslist.Add(New ReportParameter("ListadoDIIOs", diios))
    '                paramslist.Add(New ReportParameter("Total", i.ToString.Trim))
    '            End If

    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        con.Close()
    '    End Try
    'End Sub



    Private Sub frmRptTraslado_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        'If Param1_GuiaPara = 1 Then
        BuscarTrasladoPorGuia()             ''buscamos guia
        BuscarDetalleTraslado()             ''buscamos detalle (diios, total animales)
        'Else
        '    BuscarVentaPorGuia()                ''buscamos guia
        '    BuscarDetalleVenta()                ''buscamos detalle (diios, total animales)
        'End If

        'parametros del listado
        rvTraslados.LocalReport.SetParameters(paramslist)

        'reporte
        Me.rvTraslados.RefreshReport()

        Cursor.Current = Cursors.Default
    End Sub
End Class