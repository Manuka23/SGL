Imports System.Data.SqlClient



Public Class Menu_perfiles
    Public op As String
    Public CodPerf As String()
    Public NomPerf As String()
    Public DesMnu As String()
    Public CodMnu As String()
    Public Graba As String()
    Public Modifica As String()
    Public Elimina As String()
    Public FecCre As Date
    Public ResCre As String()
    Public order As String()
    Public campos As String()

    Private nregs As Integer

    Public Sub Menu_perfiles()
        ' este es un constructor que he creado para cargar los nombres de campos en un array campos() para depues hacer mi order by
        ReDim Preserve campos(0)
        ReDim Preserve campos(1)
        ReDim Preserve campos(2)
        ReDim Preserve campos(3)
        ReDim Preserve campos(4)
        ReDim Preserve campos(5)
        'ReDim Preserve campos(5)
        campos(0) = "CodPerf"
        campos(1) = "CodPerf"
        campos(2) = "NomPerf"
        campos(3) = "CodMnu"
        campos(4) = "DesMnu"
        campos(5) = "Graba"
        'campos(6) = "Modifica"
        'campos(7) = "Elimina"
        ' campos(6) = "FecCre"
    End Sub


    Public Sub carga_combo_menus()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_MenuPerfiles", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        Dim opcion As String = "si"
        'Dim codmenu As Integer = Nothing
        'Dim desmnu As String = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@op", opcion)
        cmd.Parameters.AddWithValue("@CodPerf", "")
        cmd.Parameters.AddWithValue("@NomPerf", "")
        cmd.Parameters.AddWithValue("@CodMnu", "")
        cmd.Parameters.AddWithValue("@DesMnu", "")
        cmd.Parameters.AddWithValue("@Graba", "")
        cmd.Parameters.AddWithValue("@Modifica", "")
        cmd.Parameters.AddWithValue("@Elimina", "")
        cmd.Parameters.AddWithValue("@FecCre", "")
        cmd.Parameters.AddWithValue("@ResCre", "")
        cmd.Parameters.AddWithValue("@order", "")


        i = 0

        ReDim Preserve CodPerf(i)
        ReDim Preserve NomPerf(i)
        ReDim Preserve DesMnu(i)
        ReDim Preserve CodMnu(i)
        ReDim Preserve Graba(i)
        ReDim Preserve Modifica(i)
        ReDim Preserve Elimina(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                CodPerf(i) = 0
                DesMnu(i) = "-Ninguno-"
                CodMnu(i) = 0
                'NodoSecundario(i) = 0
                'NodoTercero(i) = 0
                i += 1
                While rdr.Read()
                    ReDim Preserve CodPerf(i)
                    ReDim Preserve NomPerf(i)
                    ReDim Preserve DesMnu(i)
                    ReDim Preserve CodMnu(i)
                    ' ReDim Preserve NodoSecundario(i)
                    ' ReDim Preserve NodoTercero(i)


                    CodPerf(i) = rdr("CodPerf").ToString.Trim
                    NomPerf(i) = rdr("nomPerf").ToString.Trim
                    DesMnu(i) = rdr("DesMnu").ToString.Trim
                    CodMnu(i) = rdr("CodMnu").ToString.Trim
                    'NodoSecundario(i) = rdr("NodoSecundario").ToString.Trim
                    'NodoTercero(i) = rdr("NodoTercero").ToString.Trim

                    'MsgBox(Nombre(i))

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
    Private Sub listado_registros(ByVal paramorder As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_MenuPerfiles", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        If paramorder = "" Then
            paramorder = "CodPerf"
        Else
            paramorder = campos(paramorder)
        End If

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@op", "se")
        cmd.Parameters.AddWithValue("@CodPerf", "")
        cmd.Parameters.AddWithValue("@NomPerf", "")
        cmd.Parameters.AddWithValue("@CodMnu", "")
        cmd.Parameters.AddWithValue("@DesMnu", "")
        cmd.Parameters.AddWithValue("@Graba", "")
        cmd.Parameters.AddWithValue("@Modifica", "")
        cmd.Parameters.AddWithValue("@Elimina", "")
        cmd.Parameters.AddWithValue("@FecCre", "")
        cmd.Parameters.AddWithValue("@ResCre", "")
        cmd.Parameters.AddWithValue("@order", paramorder)


        i = 0

        ReDim Preserve CodPerf(i)
        ReDim Preserve NomPerf(i)
        ReDim Preserve CodMnu(i)
        ReDim Preserve DesMnu(i)

        'ReDim Preserve NodoSecundario(i)
        'ReDim Preserve NodoTercero(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()
            'MsgBox("lista")
            Try

                While rdr.Read()
                    ReDim Preserve CodPerf(i)
                    ReDim Preserve NomPerf(i)
                    ReDim Preserve CodMnu(i)
                    ReDim Preserve DesMnu(i)

                    'ReDim Preserve NodoSecundario(i)
                    'ReDim Preserve NodoTercero(i)


                    CodPerf(i) = rdr("CodPerf").ToString.Trim
                    NomPerf(i) = rdr("NomPerf").ToString.Trim
                    CodMnu(i) = rdr("CodMnu").ToString.Trim
                    DesMnu(i) = rdr("DesMnu").ToString.Trim

                    ' NodoSecundario(i) = rdr("NodoSecundario").ToString.Trim
                    ' NodoTercero(i) = rdr("NodoTercero").ToString.Trim

                    'MsgBox(Nombre(i))

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
        'MsgBox(i)
    End Sub
    Public Sub Cargar(ByVal orden As String)
        'Dim orden As String = ""
        If orden = "" Then
            orden = 1
        End If

        listado_registros(orden)
    End Sub


    'Public Sub BuscarVeterinarioPorCodigo(ByVal CodigoCentro As String)
    '    'buscar_centros_por_codigo(CodigoCentro)
    'End Sub


    Public ReadOnly Property NroRegistros() As Integer
        Get
            Return nregs
        End Get
    End Property

End Class


