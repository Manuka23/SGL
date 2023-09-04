Imports System.Data.SqlClient



Public Class Menu_principal
    Public op As String
    Public CodMnu As String()
    Public DesMnu As String()
    Public DesMnuIngles As String()
    Public NodoPrimario As String()
    Public NodoSecundario As String()
    Public NodoTercero As String()
    Public FecCre As String()
    Public ResCre As String()
    Public order As String()
    Public campos As String()

    Private nregs As Integer

    Public Sub menu_principal()
        ' este es un constructor que he creado para cargar los nombres de campos en un array campos() para depues hacer mi order by
        ReDim Preserve campos(0)
        ReDim Preserve campos(1)
        ReDim Preserve campos(2)
        ReDim Preserve campos(3)
        ReDim Preserve campos(4)
        ReDim Preserve campos(5)
        ReDim Preserve campos(6)

        campos(0) = "CodMnu"
        campos(1) = "CodMnu"
        campos(2) = "DesMnu"
        campos(3) = "DesMnuIngles"
        campos(4) = "NodoPrimario"
        campos(5) = "NodoSecundario"
        campos(6) = "NodoTercero"
        ' campos(6) = "FecCre"
    End Sub


    Public Sub carga_combo_segundario()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("sp_MPROD_Menu", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
        Dim opcion As String = "si"
        'Dim codmenu As Integer = Nothing
        'Dim desmnu As String = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@op", opcion)
        cmd.Parameters.AddWithValue("@CodMnu", "")
        cmd.Parameters.AddWithValue("@DesMnu", "")
        cmd.Parameters.AddWithValue("@DesMnuIngles", "")
        cmd.Parameters.AddWithValue("@NodoPrimario", "")
        cmd.Parameters.AddWithValue("@NodoSecundario", "")
        cmd.Parameters.AddWithValue("@NodoTercero", "")
        cmd.Parameters.AddWithValue("@FecCre", "")
        cmd.Parameters.AddWithValue("@ResCre", "")
        cmd.Parameters.AddWithValue("@order", "")


        i = 0

        ReDim Preserve CodMnu(i)
        ReDim Preserve DesMnu(i)
        ReDim Preserve DesMnuIngles(i)
        ReDim Preserve NodoPrimario(i)
        ReDim Preserve NodoSecundario(i)
        ReDim Preserve NodoTercero(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                CodMnu(i) = 0
                DesMnu(i) = "-Ninguno-"
                DesMnuIngles(i) = "-Ninguno-"
                NodoPrimario(i) = 0
                NodoSecundario(i) = 0
                NodoTercero(i) = 0
                i += 1
                While rdr.Read()
                    ReDim Preserve CodMnu(i)
                    ReDim Preserve DesMnu(i)
                    ReDim Preserve DesMnuIngles(i)
                    ReDim Preserve NodoPrimario(i)
                    ReDim Preserve NodoSecundario(i)
                    ReDim Preserve NodoTercero(i)


                    CodMnu(i) = rdr("CodMnu").ToString.Trim
                    DesMnu(i) = rdr("DesMnu").ToString.Trim
                    DesMnuIngles(i) = rdr("DesMnuIngles").ToString.Trim
                    NodoPrimario(i) = rdr("NodoPrimario").ToString.Trim
                    NodoSecundario(i) = rdr("NodoSecundario").ToString.Trim
                    NodoTercero(i) = rdr("NodoTercero").ToString.Trim

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
        Dim cmd As New SqlCommand("sp_MPROD_Menu", con)
        Dim rdr As SqlDataReader = Nothing
        Dim i As Integer
                If paramorder = "" Then
            paramorder = "CodMnu"
        Else
            paramorder = campos(paramorder)
        End If


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@op", "se")
        cmd.Parameters.AddWithValue("@CodMnu", "")
        cmd.Parameters.AddWithValue("@DesMnu", "")
        cmd.Parameters.AddWithValue("@DesMnuIngles", "")
        cmd.Parameters.AddWithValue("@NodoPrimario", "")
        cmd.Parameters.AddWithValue("@NodoSecundario", "")
        cmd.Parameters.AddWithValue("@NodoTercero", "")
        cmd.Parameters.AddWithValue("@FecCre", "")
        cmd.Parameters.AddWithValue("@ResCre", "")
        cmd.Parameters.AddWithValue("@order", paramorder)


        i = 0

        ReDim Preserve CodMnu(i)
        ReDim Preserve DesMnu(i)
        ReDim Preserve DesMnuIngles(i)
        ReDim Preserve NodoPrimario(i)
        ReDim Preserve NodoSecundario(i)
        ReDim Preserve NodoTercero(i)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try

                While rdr.Read()
                    ReDim Preserve CodMnu(i)
                    ReDim Preserve DesMnu(i)
                    ReDim Preserve DesMnuIngles(i)
                    ReDim Preserve NodoPrimario(i)
                    ReDim Preserve NodoSecundario(i)
                    ReDim Preserve NodoTercero(i)

                    ' Codigo(i) = rdr("UsuCod").ToString.Trim
                    ' Nombre(i) = rdr("UsuNom").ToString.Trim

                    CodMnu(i) = rdr("CodMnu").ToString.Trim
                    DesMnu(i) = rdr("DesMnu").ToString.Trim
                    DesMnuIngles(i) = rdr("DesMnuIngles").ToString.Trim
                    NodoPrimario(i) = rdr("NodoPrimario").ToString.Trim
                    NodoSecundario(i) = rdr("NodoSecundario").ToString.Trim
                    NodoTercero(i) = rdr("NodoTercero").ToString.Trim

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

