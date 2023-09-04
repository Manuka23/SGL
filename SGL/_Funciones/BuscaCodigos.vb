



Module BuscaCodigos


    Public Function BuscaCodigoTipoDocumento(ByVal text As String) As Integer
        BuscaCodigoTipoDocumento = 0

        Dim i As Integer
        Dim cod As Integer

        For i = 0 To General.TipoDocumentos.Nombre.Length - 1
            If General.TipoDocumentos.Nombre(i).Trim = text Then
                cod = General.TipoDocumentos.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoTipoDocumento = cod
    End Function



    Public Function BuscaCodigoTipoGuiaTraslado(ByVal text As String) As Integer
        BuscaCodigoTipoGuiaTraslado = 0

        Dim i As Integer
        Dim cod As Integer

        For i = 0 To General.TipoGuiasTraslados.Nombre.Length - 1
            If General.TipoGuiasTraslados.Nombre(i).Trim = text Then
                cod = General.TipoGuiasTraslados.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoTipoGuiaTraslado = cod
    End Function


    Public Function BuscaCodigoCategoria(ByVal text As String) As String
        BuscaCodigoCategoria = ""

        Dim i As Integer
        Dim cod As String = ""

        For i = 0 To General.Categorias.Nombre.Length - 1
            If General.Categorias.Nombre(i).Trim = text Then
                cod = General.Categorias.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoCategoria = cod
    End Function


    Public Function BuscaCodigoEstadoProductivo(ByVal text As String) As Integer
        BuscaCodigoEstadoProductivo = 0

        Dim i As Integer
        Dim cod As Integer = 0

        For i = 0 To General.EstProductivos.Nombre.Length - 1
            If General.EstProductivos.Nombre(i).Trim = text Then
                cod = General.EstProductivos.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoEstadoProductivo = cod
    End Function


    Public Function BuscaCodigoEstadoReproductivo(ByVal text As String) As Integer
        BuscaCodigoEstadoReproductivo = 0

        Dim i As Integer
        Dim cod As Integer = 0

        For i = 0 To General.EstReproductivos.Nombre.Length - 1
            If General.EstReproductivos.Nombre(i).Trim = text Then
                cod = General.EstReproductivos.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoEstadoReproductivo = cod
    End Function


    Public Function BuscaCodigoRaza(ByVal text As String) As Integer
        BuscaCodigoRaza = 0

        Dim i As Integer
        Dim cod As Integer = 0

        For i = 0 To General.Razas.Nombre.Length - 1
            If General.Razas.Nombre(i).Trim = text Then
                cod = General.Razas.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoRaza = cod
    End Function


    Public Function BuscaCodigoFuncionario(ByVal text As String) As String
        BuscaCodigoFuncionario = 0

        Dim i As Integer
        Dim cod As String = 0

        For i = 0 To General.funcionarios.Nombre.Length - 1
            If General.funcionarios.Nombre(i).Trim = text Then
                cod = General.funcionarios.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoFuncionario = cod
    End Function

    Public Function BuscaCodigoContratista(ByVal text As String) As String
        BuscaCodigoContratista = 0

        Dim i As Integer
        Dim cod As String = 0

        For i = 0 To General.Proveedores.Nombre.Length - 1
            If General.Proveedores.Nombre(i).Trim = text Then
                cod = General.Proveedores.Codigo(i)
                Exit For
            End If
        Next

        BuscaCodigoContratista = cod
    End Function
End Module
