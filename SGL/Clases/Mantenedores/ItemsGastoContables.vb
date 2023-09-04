Imports System.Data.SqlClient

Public Class ItemsGastoContables
    Public ItemGastoCod As String()
    Public ItemGastoNom As String()

    Private nregs As Integer

    Private Sub listado_registros(ByVal Cuenta As String, ByVal TipoBusqueda As Integer)
        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPFinanciero_Listado_ItemsGasto", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
        cmd.Parameters.AddWithValue("@TipoBusqueda", TipoBusqueda)
        cmd.Parameters.AddWithValue("@CuentaCod", Cuenta)
        cmd.Parameters.AddWithValue("@ClaseCod", 0)
        i = 0

        ReDim Preserve ItemGastoCod(i)
        ReDim Preserve ItemGastoNom(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    ReDim Preserve ItemGastoCod(i)
                    ReDim Preserve ItemGastoNom(i)

                    ItemGastoCod(i) = rdr("ItemGastoCod").ToString.Trim
                    ItemGastoNom(i) = rdr("ItemGastoNom").ToString.Trim

                    i += 1
                End While
                rdr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox("ERROR: " + ex.Message)
            End Try
        Finally
            con.Close()
        End Try
        nregs = i
    End Sub


    Public Sub Cargar(ByVal Cuenta As String, ByVal TipoBusqueda As Integer)
        listado_registros(Cuenta, TipoBusqueda)
    End Sub

    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class