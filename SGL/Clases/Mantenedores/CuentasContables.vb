Imports System.Data.SqlClient

Public Class CuentasContables
    Public CuentaCod As String()
    Public CuentaNom As String()
    Public contracuenta As String()


    Private nregs As Integer


    Private Sub listado_registros(ByVal Clase As String, ByVal TipoBusqueda As Integer)
        Dim con As New SqlConnection(GetConnectionStringFIN())
        Dim cmd As New SqlCommand("spGPFinanciero_Listado_Cuentas", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
        cmd.Parameters.AddWithValue("@ClaseCod", Clase)
        cmd.Parameters.AddWithValue("@TipoBusqueda", TipoBusqueda)

        i = 0

        ReDim Preserve CuentaCod(i)
        ReDim Preserve CuentaNom(i)
        ReDim Preserve contracuenta(i)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()
                    ReDim Preserve CuentaCod(i)
                    ReDim Preserve CuentaNom(i)
                    ReDim Preserve contracuenta(i)
                    CuentaCod(i) = rdr("CuentaCod").ToString.Trim
                    CuentaNom(i) = rdr("CuentaNom").ToString.Trim
                    'contracuenta(i) = rdr("ACTINDX").ToString.Trim
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


    Public Sub Cargar(ByVal Clase As String, ByVal TipoBusqueda As Integer)
        listado_registros(Clase, TipoBusqueda)
    End Sub

    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class