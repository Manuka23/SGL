﻿

Imports System.Data.SqlClient



Public Class Temporadas

    Public Codigo As Integer()
    Public Nombre As String()
    Public Vigente As Boolean()
    Public FechaIni As Date()
    Public FechaFin As Date()


    Private nregs As Integer


    Private Sub listado_registros()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTemporadas_Listado", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        i = 0

        ReDim Preserve Codigo(i)
        ReDim Preserve Nombre(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    ReDim Preserve Codigo(i)
                    ReDim Preserve Nombre(i)
                    ReDim Preserve Vigente(i)
                    ReDim Preserve FechaIni(i)
                    ReDim Preserve FechaFin(i)

                    Codigo(i) = rdr("TempPeriodo")
                    Nombre(i) = "TEMPORADA " + rdr("TempPeriodo").ToString.Trim
                    Vigente(i) = rdr("TempPeriodo")
                    FechaIni(i) = rdr("TempFechaIni")
                    FechaFin(i) = rdr("TempFechaFin")

                    If Vigente(i) = True Then
                        TemporadaVigente = Codigo(i)
                        TemporadaFechaIni = FechaIni(i)
                        TemporadaFechaFin = FechaFin(i)
                    End If

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


    Public Sub Cargar()
        listado_registros()
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
