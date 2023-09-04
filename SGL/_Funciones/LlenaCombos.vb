
'''''
''
'' MODULO EXCLUSIVAMENTE PARA GUARDAR LAS FUNCIONES ENCARGADAS DE LLENAR LOS COMBOS CON DATOS
''
'''''



Module LlenaCombos



    Public Sub CboLLenaCentrosUsuario(ByVal cbo As ComboBox, Optional ByVal AgregarTodos As Boolean = False)
        cbo.Items.Clear()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub
        If AgregarTodos Then cbo.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cbo.Items.Add(General.CentrosUsuario.Nombre(i))
        Next
    End Sub


    Public Sub CboLLenaRazas(ByVal cbo As ComboBox, Optional ByVal AgregarTodos As Boolean = False)
        cbo.Items.Clear()
        If General.Razas.NroRegistros = 0 Then Exit Sub
        If AgregarTodos Then cbo.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.Razas.NroRegistros - 1
            cbo.Items.Add(General.Razas.Nombre(i))
        Next
    End Sub



    Public Sub CboLLenaPatologias(ByVal cbo As ComboBox, Optional ByVal AgregarTodos As Boolean = False)
        cbo.Items.Clear()
        If General.Patologias.NroRegistros = 0 Then Exit Sub

        Dim i As Integer

        For i = 0 To General.Patologias.NroRegistros - 1
            cbo.Items.Add(General.Patologias.Nombre(i))
        Next
    End Sub


    Public Sub CboLLenaTipoPotreros(ByVal cbo As ComboBox, Optional ByVal AgregarTodos As Boolean = False)
        cbo.Items.Clear()
        If General.TipoPotreros.NroRegistros = 0 Then Exit Sub
        If AgregarTodos Then cbo.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.TipoPotreros.NroRegistros - 1
            cbo.Items.Add(General.TipoPotreros.Nombre(i))
        Next
    End Sub





    Public Sub CboLLenaFarmacosPatologia(ByVal cbo As ComboBox, Optional ByVal AgregarTodos As Boolean = False)
        cbo.Items.Clear()
        If General.FarmacosPatologia.NroRegistros = 0 Then Exit Sub

        If AgregarTodos Then cbo.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.FarmacosPatologia.NroRegistros - 1
            cbo.Items.Add(General.FarmacosPatologia.Nombre(i) & " ( " & General.FarmacosPatologia.Glosa(i) & " ) ")
        Next
    End Sub


End Module
