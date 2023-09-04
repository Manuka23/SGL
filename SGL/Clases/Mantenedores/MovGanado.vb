Imports System.Data.SqlClient

Public Class MovGanado

    Private TipoMovGnd As String = ""
    Public Function GeneraMovGanado(ByVal TipMovGanado As String,
                                     ByVal MovTrl As Integer, ByVal NroDoc As Integer, ByVal NroFMA As Integer, ByVal ClienteCod As String,
                                     ByVal FechaMov As Date, ByVal CenOrigen As String, ByVal CenDestino As String, ByVal Obs As String,
                                     ByVal TipoMov As Integer, ByVal ArrayDIIOs As String, ByVal TipoDoc As Integer, ByVal TrlTerneros As Integer,
                                     ByVal LV As ListView,
                                     ByVal ChoferRut As String, ByVal ChoferNom As String, ByVal EmpRutTransporte As String, ByVal EmpNomTransporte As String,
                                     ByVal Patente1 As String, ByVal Patente2 As String) As Integer
        'TipMovGanado: Traslado / Venta 
        'MovTrl: 1=Salida / 2=Entrada
        GeneraMovGanado = 0 'Esta variable sera la que retorne el Nro de Guia

        TipoMovGnd = TipMovGanado
        Dim spString As String = ""
        If TipoMovGnd = "Traslado" Then spString = "spTraslados_Grabar"
        If TipoMovGnd = "Venta" Then spString = "spVentas_Grabar"

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand(spString, con)

        cmd.CommandType = Data.CommandType.StoredProcedure
        ''
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@TipoDoc", TipoDoc)
        cmd.Parameters.AddWithValue("@NroDoc", NroDoc)
        cmd.Parameters.AddWithValue("@NroFMA", NroFMA)
        cmd.Parameters.AddWithValue("@Fecha", FechaMov)
        cmd.Parameters.AddWithValue("@CenOrigen", CenOrigen)
        If TipoMovGnd = "Traslado" Then
            cmd.Parameters.AddWithValue("@Movimiento", MovTrl)
            cmd.Parameters.AddWithValue("@CenDestino", CenDestino)
            cmd.Parameters.AddWithValue("@Tipo", TipoMov)
            cmd.Parameters.AddWithValue("@ArrayDIIOs", ArrayDIIOs)
            cmd.Parameters.AddWithValue("@TrasTernero", TrlTerneros)
        End If
        If TipoMovGnd = "Venta" Then
            cmd.Parameters.AddWithValue("@Cliente", ClienteCod) 'Sacar
        End If
        cmd.Parameters.AddWithValue("@Observs", Obs)

        Dim TablaDetalle As System.Data.DataTable = ListViewToDataTable(LV)
        cmd.Parameters.AddWithValue("@TablaDetalle", TablaDetalle)

        cmd.Parameters.AddWithValue("@TransChoferRut", ChoferRut)
        cmd.Parameters.AddWithValue("@TransChoferNom", ChoferNom)
        cmd.Parameters.AddWithValue("@TransEmpresaRut", EmpRutTransporte)
        cmd.Parameters.AddWithValue("@TransEmpresaNom", EmpNomTransporte)
        cmd.Parameters.AddWithValue("@TransPatente1", Patente1)
        cmd.Parameters.AddWithValue("@TransPatente2", Patente2)

        cmd.Parameters.AddWithValue("@Version", VERSION_SGL_APP)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMsg").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetGuia", SqlDbType.Int) : cmd.Parameters("@RetGuia").Direction = ParameterDirection.Output

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMsg").Value
            Dim guia As Integer = cmd.Parameters("@RetGuia").Value

            If vret <> 0 Then
                Cursor.Current = Cursors.Default
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Try
            End If

            GeneraMovGanado = guia
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Public Function FinalizarReqVenta(
                                     ByVal VtaNumero As Integer, ByVal NroDoc As Integer, ByVal NroFMA As Integer, ByVal ClienteCod As String,
                                     ByVal FechaMov As Date, ByVal CenOrigen As String, ByVal Obs As String,
                                     ByVal ArrayDIIOs As String, ByVal TipoDoc As Integer,
                                     ByVal LV As ListView,
                                     ByVal ChoferRut As String, ByVal ChoferNom As String, ByVal EmpRutTransporte As String, ByVal EmpNomTransporte As String,
                                     ByVal Patente1 As String, ByVal Patente2 As String) As Integer
        'TipMovGanado: Venta 

        FinalizarReqVenta = 0 'Esta variable sera la que retorne el Nro de Guia

        Dim spString As String = "spVentas_FinalizarReqVta"

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand(spString, con)

        cmd.CommandType = Data.CommandType.StoredProcedure
        ''
        cmd.Parameters.AddWithValue("@VtaNumero", VtaNumero)
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@TipoDoc", TipoDoc)
        cmd.Parameters.AddWithValue("@NroDoc", NroDoc)
        cmd.Parameters.AddWithValue("@NroFMA", NroFMA)
        cmd.Parameters.AddWithValue("@Fecha", FechaMov)
        cmd.Parameters.AddWithValue("@CenOrigen", CenOrigen)

        cmd.Parameters.AddWithValue("@Cliente", ClienteCod) 'Sacar

        cmd.Parameters.AddWithValue("@Observs", Obs)

        Dim TablaDetalle As System.Data.DataTable = ListViewToDataTable(LV)
        cmd.Parameters.AddWithValue("@TablaDetalle", TablaDetalle)

        cmd.Parameters.AddWithValue("@TransChoferRut", ChoferRut)
        cmd.Parameters.AddWithValue("@TransChoferNom", ChoferNom)
        cmd.Parameters.AddWithValue("@TransEmpresaRut", EmpRutTransporte)
        cmd.Parameters.AddWithValue("@TransEmpresaNom", EmpNomTransporte)
        cmd.Parameters.AddWithValue("@TransPatente1", Patente1)
        cmd.Parameters.AddWithValue("@TransPatente2", Patente2)

        cmd.Parameters.AddWithValue("@Version", VERSION_SGL_APP)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMsg", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMsg").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetGuia", SqlDbType.Int) : cmd.Parameters("@RetGuia").Direction = ParameterDirection.Output

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMsg").Value
            Dim guia As Integer = cmd.Parameters("@RetGuia").Value

            If vret <> 0 Then
                Cursor.Current = Cursors.Default
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Try
            End If

            FinalizarReqVenta = guia
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function

    Private Function ListViewToDataTable(ByVal LV As ListView) As System.Data.DataTable
        ListViewToDataTable = Nothing

        Dim TipVtaCod As Integer = 0 : Dim CausaCod As Integer = 0 : Dim VeterCod As String = "" : Dim NroCertif As Integer = 0

        Dim table As System.Data.DataTable = New System.Data.DataTable("TablaDetalle")

        table.Columns.Add("Diio", System.Type.GetType("System.Decimal"))
        table.Columns.Add("CategCod", System.Type.GetType("System.String"))
        table.Columns.Add("CategNom", System.Type.GetType("System.String"))
        table.Columns.Add("EstProd", System.Type.GetType("System.String"))
        table.Columns.Add("EstReprod", System.Type.GetType("System.String"))
        table.Columns.Add("TipoVenta", System.Type.GetType("System.Decimal"))
        table.Columns.Add("Causal", System.Type.GetType("System.Decimal"))
        table.Columns.Add("Veterinario", System.Type.GetType("System.String"))
        table.Columns.Add("NroCertific", System.Type.GetType("System.Decimal"))

        For Each itm As ListViewItem In LV.Items
            If TipoMovGnd = "Venta" Then TipVtaCod = itm.SubItems(7).Text
            If TipoMovGnd = "Venta" Then CausaCod = itm.SubItems(9).Text
            If TipoMovGnd = "Venta" Then VeterCod = itm.SubItems(12).Text
            If TipoMovGnd = "Venta" Then NroCertif = itm.SubItems(13).Text

            table.Rows.Add(itm.SubItems(1).Text, itm.SubItems(3).Text, itm.SubItems(4).Text, itm.SubItems(5).Text, itm.SubItems(6).Text,
                           TipVtaCod, CausaCod, VeterCod, NroCertif)
        Next
        ListViewToDataTable = table

    End Function

End Class
