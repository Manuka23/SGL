﻿

Imports System.Data.SqlClient



Public Class TorosInseminaciones
    Public Codigo As String()
    Public Nombre As String()
    Public CodGP As String()
    Public Stock As String()
    Public UM As String()
    'Public CodRaza As Integer()
    'Public NomRaza As String()
    'Public Sexado As Boolean()
    'Public NumDosis As Integer()
    ''
    'Public DosisLibres As Integer()
    ''
    Private nregs As Integer


    Private Sub listado_registros(ByVal CodigoCentro As String)
        Dim con As New SqlConnection(GetConnectionString())
        'Dim cmd As New SqlCommand("spToros_ListadoParaInseminaciones", con)
        Dim cmd As New SqlCommand("spCubiertas_ListadoToros", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EmpresaCod", Empresa)
        cmd.Parameters.AddWithValue("@CentroCod", CodigoCentro)
        'cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        'cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.Add("@ResultCod", SqlDbType.Int) : cmd.Parameters("@ResultCod").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@ResultMsg", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@ResultMsg").Direction = ParameterDirection.Output
        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)
        ReDim Preserve CodGP(i)
        ReDim Preserve Stock(i)
        ReDim Preserve UM(i)
        'ReDim Preserve CodRaza(i)
        'ReDim Preserve NomRaza(i)
        'ReDim Preserve Sexado(i)
        'ReDim Preserve NumDosis(i)
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve CodGP(i)
                    ReDim Preserve Stock(i)
                    ReDim Preserve UM(i)
                    'ReDim Preserve CodRaza(i)
                    'ReDim Preserve NomRaza(i)
                    'ReDim Preserve Sexado(i)
                    'ReDim Preserve NumDosis(i)

                    Codigo(i) = rdr("ToroCodigo").ToString.Trim
                    'Nombre(i) = rdr("ToroNombre").ToString.Trim
                    'CodRaza(i) = rdr("CodRaza")
                    'NomRaza(i) = rdr("NomRaza").ToString.Trim
                    Nombre(i) = rdr("ITEMDESC").ToString.Trim
                    CodGP(i) = rdr("ITEMNMBR")
                    Stock(i) = rdr("ITEMSTK").ToString.Trim
                    UM(i) = rdr("UOFM").ToString.Trim
                    'Sexado(i) = IIf(rdr("ToroSexado") = 1, True, False)
                    'NumDosis(i) = rdr("DSemDosisToroLibres").ToString.Trim
                    i += 1
                End While

                'dispose data readers and commands
                rdr.Close()
                cmd.Dispose()
            Catch ex As Exception
                'capturamos, error y formateamos mensaje
                MsgBox("ERROR: " + ex.Message)
            End Try
        Finally
            'cerramos coneccion, al finalizar
            con.Close()
        End Try

        nregs = i
    End Sub


    'Private Sub buscar_centros_por_codigo(ByVal CodigoCentro As String)
    '    Dim con As New SqlConnection(GetConnectionString())
    '    Dim cmd As New SqlCommand("spCentros_ListadoPorUsuario", con)
    '    Dim rdr As SqlDataReader = Nothing
    '    Dim i As Integer

    '    cmd.CommandType = Data.CommandType.StoredProcedure
    '    cmd.Parameters.AddWithValue("@Empresa", 76011573)
    '    cmd.Parameters.AddWithValue("@Codigo", CodigoCentro)
    '    cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
    '    cmd.Parameters.AddWithValue("@Equipo", NombrePC)

    '    i = 0

    '    Try
    '        Try
    '            conn = New SqlCeConnection("Data Source=" + MyDB.Path + "\" + MyDB.Nombre + ";Password=" + MyDB.Clave)
    '            conn.Open()

    '            cmd = New SqlCeCommand(SQL_BuscarCentroPorCodigo(CodigoCentro), conn)
    '            rdr = cmd.ExecuteReader()

    '            While rdr.Read()
    '                ReDim Preserve Codigo(i)
    '                ReDim Preserve Nombre(i)

    '                Codigo(i) = rdr("CeCodigo")
    '                Nombre(i) = rdr("CeDescrip")

    '                i += 1
    '            End While

    '            'dispose data readers and commands
    '            rdr.Close()
    '            cmd.Dispose()
    '        Catch ex As Exception
    '            'capturamos, error y formateamos mensaje
    '            MsgBox("ERROR: " + ex.Message)
    '        End Try
    '    Finally
    '        'cerramos coneccion, al finalizar
    '        conn.Close()
    '    End Try

    '    nptos = i
    'End Sub


    Public Sub Cargar(ByVal CodigoCentro As String)
        listado_registros(CodigoCentro)
    End Sub


    'Public Sub BuscarCentroPorCodigo(ByVal CodigoCentro As String)
    '    'buscar_centros_por_codigo(CodigoCentro)
    'End Sub


    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property


End Class
