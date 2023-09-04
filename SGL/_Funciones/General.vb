

'Imports Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Imports System.IO
Imports System.Text


Module General

    Public VERSION_SGL_APP As Integer = 0
    Private VERSION_SGL_SQL As Integer = 0
    Public MSTRUsuarios As New MSTR_Usuarios
    Public DTUsuarioCentrosFrmQRY As DataTable = Nothing
    Public DTUsuarioPermisosFrmQRY As DataTable = Nothing
    Public UsuarioCentroCodDefault As Integer = 0
    Public UsuarioCentroNomDefault As String = ""

    Public MSTRProductosUrea As New MSTR_ProductosUrea

    Public MSTRCuentasContables As New MSTR_CuentasContables
    Public MSTRInvProductos As New MSTR_INVProductos
    Public MSTRInvBodegas As New MSTR_INVBodegas
    Public MSTRUsuariosBodegas As New MSTR_UsuariosBodegas
    Public MSTRPatologias As New MSTR_Patologias

    Public ClasesContables As New ClasesContables
    Public CuentasContablesMan As New CuentasContables
    Public CuentasItemGasto As New CuentasItemGasto
    Public ItemsGastoContables As New ItemsGastoContables
    Public StockBodega As New StockBodega
    Public StockBodegaTrl As New StockBodegaTrl
    Public Clientes As New Clientes
    Public Categorias As New Categorias
    Public CategoriasFecha As New CategoriasFecha
    Public CategoriasVacas As New CategoriasVacas
    Public Solidos As New TiposSolidos
    Public Bancos As New Bancos
    Public TipoCentros As New TipoCentros
    Public Centros As New CentrosTodos
    Public CentrosUsuario As New Centros
    Public TrlsGnd_ListadoCentros As New TrasladosGanado_ListadoCentros
    Public TrlsGnd_ListadoCentrosRecepcion As New TrasladosGanado_ListadoCentrosRecepcion
    Public TipoUrea As New TipoUrea
    Public Empresas As New Empresas
    Public TRL_EmpresasIntComp As New TRLEmpresasIntComp 'Empresas Traslados Inter-Compañia
    Public CategoriasBalance As New CategoriasBalance
    Public CentrosUsuarioSalas As New CentrosSalas
    Public Medicamentos As New Medicamentos
    Public Potreros As New PotrerosPorCentro
    Public TiposControlLechero As New ControlLechero
    Public Plantas As New Plantascbo
    Public CentrosUsuario2 As New Centros2
    Public Veterinarios As New Veterinarios
    Public Condiciones As New Condiciones
    Public Toros As New Toros
    Public TorosInseminaciones As New TorosInseminaciones
    Public Razas As New Razas
    Public TipoBolo As New TipoBolo
    Public EstProductivos As New EstadosProductivos
    Public EstReproductivos As New EstadosReproductivos
    Public EstTraslados As New EstadosTraslados
    Public TipoDesechos As New TipoDesechos
    Public Proveedores As New Proveedores
    Public Recepcionadores As New Recepcionadores
    Public TipoDocumentos As New TipoDocumentos
    Public TipoAsignDiios As New TipoAsignacionesDiios
    Public TipoFallasDiios As New TipoFallasDiios
    Public Inseminadores As New Inseminadores
    Public CausasMuertes As New Causas
    Public CausasVentas As New CausasVentas
    Public TipoTraslados As New TipoTraslados
    Public TipoMovimientos As New TipoMovimientos
    Public TipoMovsAjuste As New TipoMovsAjuste
    Public Patologias As New Patologias
    Public FarmacosPatologia As New FarmacosPatologia
    Public Farmacos As New FarmacosMastitis
    Public FarmacosCojas As New FarmacosCojas
    Public TipoCojeras As New TipoCojeras
    Public CondicionesRevPP As New CondicionesRevPP
    Public Temporadas As New Temporadas
    Public RCSListadoAños As New RCS_ListadoAños
    Public TiposAjusteEntrada As New TiposAjusteEntrada
    Public TiposAjusteSalida As New TiposAjusteSalida
    Public EstadosAjuste As New EstadosAjuste
    Public TiposVentas As New TiposVentas
    Public TipoGuiasTraslados As New TipoGuiasTraslados
    Public TipoDocumentosVentas As New TipoDocumentosVentas
    ''
    Public TipoPotreros As New TipoPotreros
    ''
    Public ItemGastos As New GPItemGastos
    Public CuentasContables As New GPCuentasContables
    Public BodegasGP As New GPBodegas
    'Public BodegasUsuariosGP As New GPBodegasUsuario
    Public ClientPlanta As New ClientesPlanta
    ''
    ''
    ''
    Public CGPerfiles As New CGPerfiles
    '
    Public CentrosUsuarioEstanque As New CentrosEstanques
    Public CausasDecomisos As New CausasDecomisos

    Public Usuarios_ivs As New Usuarios_ivs
    Public Perfiles As New perfiles
    Public menu_principal As New Menu_principal
    Public menu_perfiles As New Menu_perfiles
    Public funcionarios As New Funcionarios
    Public nomenclaturas As New nomenclaturas
    Public centrospayroll As New CentrosPayroll
    Public MotivosHorasExtras As New MotivoHorasExtras
    Public Usuario_Permisos As New UsuarioPermisos

    Public TemporadaVigente As Integer      'estos datos se llenan al cargar las temporadas en el login
    Public TemporadaFechaIni As Date
    Public TemporadaFechaFin As Date

    Public TipoBaston As String = ""
    Public COMBaston As String = ""
    Public Empresa As Integer = 0 '76011573
    Public NombrePC As String = SystemInformation.ComputerName '"EQUIPO_DEV"

    Public var_ As Integer

    Public SaveSN() As TreeView

    Public IdiomaSistema As Integer = 1         '1=español / 2=ingles   (NUEVO AGREGADO 22-SEP-2016 - JERSON)

    Public LoginUsuario As String
    Public PerfilUsuario As Integer             '1=visitante, 2=admin sala, 3=jefe prod, 4=gerencia tec, 5 admin sistema
    Public NombrePerfilUsuario As String
    'Public FiltraCentrosUsuario As Integer
    Public UsuarioCierraXLS As Integer
    Public UsuarioEliminaCierre As Integer
    Public UsuarioConfirmaAjuste As Integer
    Public ModificarDiasBaston As Integer
    Public EliminarDiiosBastoneo As Integer
    Public EliminaParto As String
    Public UsuarioAdminConcentrado As Integer

    Public CodigoCentroUsuario As Integer
    Public NombreCentroUsuario As String

    Public CentrosUsuarioCod() As String
    Public CentrosUsuarioNom() As String


    Public SRV_Servidor As String = "127.0.0.1"  '127.0.0.1  - SRVSQL2
    Public LOGIN_CONEXION As String = ""
    Private SRV_Puerto As String = "1433"
    Private SRV_BD As String = "MANUKA_PROD"
    Private SRV_Usuiario As String = "mnk_prod"     'mnk_prod
    Private SRV_Clave As String = "mnkmnk"

    Public MyFileConfig As String = Directory.GetCurrentDirectory() + "\SGL_User.config"

    Public SuiteElectronica As New eSuite
    Public MovGnd As New MovGanado

    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" _
                                        Alias "GetPrivateProfileStringW" (ByVal lpApplicationName As String,
                                        ByVal lpKeyName As String, ByVal lpDefault As String,
                                        ByVal lpReturnedString As String, ByVal nSize As Int32,
                                        ByVal lpFileName As String) As Int32
    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" _
                                        Alias "WritePrivateProfileStringW" (ByVal lpApplicationName As String,
                                        ByVal lpKeyName As String, ByVal lpString As String,
                                        ByVal lpFileName As String) As Int32
    Public Function ReadFileUser(ByVal FileName As String, ByVal Section As String, ByVal ParamName As String, Optional ByVal ParamDefault As String = "") As String

        Dim ParamVal As String
        Dim LenParamVal As Long

        ParamVal = Space$(1024)
        LenParamVal = GetPrivateProfileString(Section, ParamName, ParamDefault, ParamVal, Len(ParamVal), FileName)

        ReadFileUser = Left$(ParamVal, LenParamVal)
    End Function

    Public Sub WriteFileUser(ByVal FileName As String, ByVal Section As String, ByVal ParamName As String, ByVal ParamVal As String)
        Dim Result As Integer
        Result = WritePrivateProfileString(Section, ParamName, ParamVal, FileName)
    End Sub

    Public Sub LimpiarDatosUsuario()
        LoginUsuario = ""
        PerfilUsuario = 0
        NombrePerfilUsuario = ""
        CodigoCentroUsuario = 0
        NombreCentroUsuario = ""

        ReDim CentrosUsuarioCod(0)
        ReDim CentrosUsuarioNom(0)
    End Sub

    Public Function DiasHabiles(ByVal centro As String, ByVal tconteo As String) As Integer
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spBaston_CierreConteoDiasLectura", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Centro", centro)
        cmd.Parameters.AddWithValue("@TipoConteo", tconteo)

        Dim dias As Integer
        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    dias = rdr("DiasHabiles").ToString.Trim
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
SalirProc:
        DiasHabiles = dias
    End Function
    Public Function GetConnectionString() As String
        GetConnectionString = "Data Source=" + SRV_Servidor + "," + SRV_Puerto +
                                    ";Persist Security Info=True;" +
                                    "Initial Catalog=" + SRV_BD +
                                    ";User ID=" + SRV_Usuiario +
                                    ";Password=" + SRV_Clave
    End Function

    'Public Function GetConnectionStringBI() As String

    '    GetConnectionStringBI = "Data Source= MNK-OSO-DB01" +
    '                                ";Persist Security Info=True;" +
    '                                "Initial Catalog=MANUKA_BI" +
    '                                ";User ID=manukabi" +
    '                                ";Password=surpointmnk18"
    'End Function

    Public Function GetConnectionStringBI() As String

        GetConnectionStringBI = "Data Source=192.168.50.28" +
                                    ";Persist Security Info=True;" +
                                    "Initial Catalog=MANUKA_BI" +
                                    ";User ID=manukabi" +
                                    ";Password=BI2018"
    End Function

    Public Function GetConnectionStringFIN() As String
        Dim bd As String = "MANUKA_FIN" 'IIf(SRV_Servidor <> "SRVMNK", "MANUKA_FIN_NEW", "MANUKA_FIN")
        Dim usr As String = "mnk_prod"
        Dim pwd As String = "mnkmnk"
        GetConnectionStringFIN = "Data Source=" + SRV_Servidor + "," + SRV_Puerto + _
                                    ";Persist Security Info=True;" + _
                                    "Initial Catalog=" + bd + _
                                    ";User ID=" + usr + _
                                    ";Password=" + pwd
    End Function


    Public Function GetConnectionStringRRHH() As String
        Dim bd As String = "MANUKA_RRHH"
        Dim usr As String = "manuka_rrhh"
        Dim pwd As String = "manuka"
        GetConnectionStringRRHH = "Data Source=" + SRV_Servidor + "," + SRV_Puerto +
                                    ";Persist Security Info=True;" +
                                    "Initial Catalog=" + bd +
                                    ";User ID=" + usr +
                                    ";Password=" + pwd
    End Function
    Public Function GetConnectionStringSAMM() As String
        Dim bd As String = "SAMM"
        Dim usr As String = "admin_samm"
        Dim pwd As String = "M4nuk4S4WW"
        GetConnectionStringSAMM = "Data Source=" + SRV_Servidor + "," + SRV_Puerto +
                                    ";Persist Security Info=True;" +
                                    "Initial Catalog=" + bd +
                                    ";User ID=" + usr +
                                    ";Password=" + pwd
    End Function

    Public Function GetConnectionStringTOROM() As String
        Dim bd As String = "TOROM"
        Dim usr As String = "SGL_READ"
        Dim pwd As String = "$GLM4n5k4"
        GetConnectionStringTOROM = "Data Source=192.168.50.220" +
                                    ";Persist Security Info=True;" +
                                    "Initial Catalog=" + bd +
                                    ";User ID=" + usr +
                                    ";Password=" + pwd
    End Function

    Public Function GetConnectionStringRIMU() As String
        Dim bd As String = "RIMU"
        Dim usr As String = "SGL_READ"
        Dim pwd As String = "$GLM4n5k4"
        GetConnectionStringRIMU = "Data Source=192.168.50.220" +
                                    ";Persist Security Info=True;" +
                                    "Initial Catalog=" + bd +
                                    ";User ID=" + usr +
                                    ";Password=" + pwd
    End Function


    Public Function VerificaServidorSQL(ByVal SRV_Servidor As String, _
                                       ByVal SRV_Puerto As String, _
                                       ByVal SRV_BD As String, _
                                       ByVal SRV_Usuiario As String, _
                                       ByVal SRV_Clave As String) As String

        VerificaServidorSQL = ""
        Dim srvconn As SqlConnection = Nothing

        Try
            Try
                srvconn = New SqlConnection("Data Source=" + SRV_Servidor + "," + SRV_Puerto + _
                                            ";Persist Security Info=True;" + _
                                            "Initial Catalog=" + SRV_BD + _
                                            ";User ID=" + SRV_Usuiario + _
                                            ";Password=" + SRV_Clave)
                srvconn.Open()
                VerificaServidorSQL = "OK"

            Catch ex As Exception
                'capturamos, error y formateamos mensaje
                VerificaServidorSQL = ex.Message
            End Try
        Finally
            'cerramos coneccion, al finalizar
            srvconn.Close()
        End Try
    End Function

    Public Function CentroPorDefecto() As String
        CentroPorDefecto = ""

        If Not frmMAIN.lblCentro.Text.Contains("NO ASIGNADO") Then
            CentroPorDefecto = frmMAIN.lblCentro.Text
        End If
    End Function

    Public Function FormateaRUT(ByVal rut As String, ByVal dv As String) As String
        FormateaRUT = ""

        Dim srut As String = rut.ToString.Trim
        Dim lrut As Integer = srut.Length
        Dim ret As String = ""

        If lrut < 7 Then
            FormateaRUT = srut
            Exit Function
        End If

        If lrut = 7 Then
            ret = srut.Substring(0, 1) + "." + srut.Substring(1, 3) + "." + srut.Substring(4, 3) + "-" + dv
        Else
            ret = srut.Substring(0, 2) + "." + srut.Substring(2, 3) + "." + srut.Substring(5, 3) + "-" + dv
        End If

        FormateaRUT = ret
    End Function


    Public Function FormateaRUTGP(ByVal rut As String) As String
        FormateaRUTGP = ""

        Dim srut As String = rut.ToString.Trim
        Dim lrut As Integer = srut.Length
        Dim ret As String = ""

        If lrut < 8 Or rut.Contains(".") Or rut.Contains("-") Then
            FormateaRUTGP = srut
            Exit Function
        End If

        If lrut = 8 Then
            ret = srut.Substring(0, 1) + "." + srut.Substring(1, 3) + "." + srut.Substring(4, 3) + "-" + srut.Substring(7, 1)
        Else
            ret = srut.Substring(0, 2) + "." + srut.Substring(2, 3) + "." + srut.Substring(5, 3) + "-" + srut.Substring(8, 1)
        End If

        FormateaRUTGP = ret
    End Function
    Public Function FormateaRUTGPGuion(ByVal rut As String) As String
        FormateaRUTGPGuion = ""

        Dim srut As String = rut.ToString.Trim
        Dim lrut As Integer = srut.Length
        Dim ret As String = ""

        If lrut < 8 Or rut.Contains(".") Or rut.Contains("-") Then
            FormateaRUTGPGuion = srut
            Exit Function
        End If

        If lrut = 8 Then
            ret = srut.Substring(0, 1) + srut.Substring(1, 3) + srut.Substring(4, 3) + "-" + srut.Substring(7, 1)
        Else
            ret = srut.Substring(0, 2) + srut.Substring(2, 3) + srut.Substring(5, 3) + "-" + srut.Substring(8, 1)
        End If

        FormateaRUTGPGuion = ret
    End Function


    Public Function Encripta(ByVal Tira, ByVal Func, ByVal TiraEnc) As String
        Dim A(40), B(40), C(11)

        Encripta = ""

        A(1) = "J"
        A(2) = "1"
        A(3) = "0"
        A(4) = "H"
        A(5) = "7"
        A(6) = "X"
        A(7) = "E"
        A(8) = "V"
        A(9) = "5"
        A(10) = "3"
        A(11) = "("
        A(12) = "B"
        A(13) = "A"
        A(14) = "D"
        A(15) = "G"
        A(16) = "I"
        A(17) = "K"
        A(18) = "L"
        A(19) = "2"
        A(20) = "8"
        A(21) = "F"
        A(22) = "M"
        A(23) = "6"
        A(24) = "N"
        A(25) = "P"
        A(26) = "O"
        A(27) = "9"
        A(28) = "4"
        A(29) = "T"
        A(30) = "Q"
        A(31) = "Z"
        A(32) = "R"
        A(33) = "S"
        A(34) = "U"
        A(35) = "W"
        A(36) = "Y"
        A(37) = "C"
        A(38) = "Ñ"
        B(1) = "0"
        B(2) = "1"
        B(3) = "2"
        B(4) = "3"
        B(5) = "4"
        B(6) = "5"
        B(7) = "6"
        B(8) = "7"
        B(9) = "8"
        B(10) = "9"
        B(11) = "A"
        B(12) = "B"
        B(13) = "C"
        B(14) = "D"
        B(15) = "E"
        B(16) = "F"
        B(17) = "G"
        B(18) = "H"
        B(19) = "I"
        B(20) = "J"
        B(21) = "K"
        B(22) = "L"
        B(23) = "M"
        B(24) = "N"
        B(25) = "Ñ"
        B(26) = "O"
        B(27) = "P"
        B(28) = "Q"
        B(29) = "R"
        B(30) = "S"
        B(31) = "T"
        B(32) = "U"
        B(33) = "V"
        B(34) = "W"
        B(35) = "X"
        B(36) = "Y"
        B(37) = "Z"
        B(38) = "("

        C(1) = Mid(Tira, 1, 1)
        C(2) = Mid(Tira, 2, 1)
        C(3) = Mid(Tira, 3, 1)
        C(4) = Mid(Tira, 4, 1)
        C(5) = Mid(Tira, 5, 1)
        C(6) = Mid(Tira, 6, 1)
        C(7) = Mid(Tira, 7, 1)
        C(8) = Mid(Tira, 8, 1)
        C(9) = Mid(Tira, 9, 1)
        C(10) = Mid(Tira, 10, 1)

        Dim Ok, I, J As Integer
        Dim Letra As String
        Dim LetraE As String

        If Func = "E" Then
            ' ENCRIPTAR
            TiraEnc = ""
            I = 1
            Do While I <= 10
                Letra = C(I)
                Ok = 0
                J = 1
                LetraE = ""
                Do While Ok = 0
                    If Letra = B(J) Then
                        LetraE = A(J)
                        Ok = 1
                    Else
                        J = J + 1
                        If J = 39 Then
                            Ok = 1
                        End If
                    End If
                Loop
                If LetraE = "" Then
                    LetraE = Letra
                End If
                TiraEnc = TiraEnc & LetraE
                I = I + 1
            Loop
        Else
            '	DESENCRIPTAR
            TiraEnc = ""
            I = 1
            Do While I <= 10
                Letra = C(I)
                LetraE = " "
                Ok = 0
                J = 1
                LetraE = " "
                Do While Ok = 0
                    If Letra = A(J) Then
                        LetraE = B(J)
                        Ok = 1
                    Else
                        J = J + 1
                        If J = 39 Then
                            Ok = 1
                        End If
                    End If
                Loop
                If LetraE = "" Then
                    LetraE = Letra
                End If
                TiraEnc = TiraEnc & LetraE ' & ""
                I = I + 1
            Loop

        End If
        TiraEnc = TiraEnc & Space(10)
        TiraEnc = Mid(TiraEnc, 1, 10)

        Encripta = TiraEnc
    End Function




    Public Function CalcPorcentaje(ByVal Cnt As Integer, ByVal CntTotal As Integer) As String
        Dim RsPercent As String
        If CntTotal = 0 Then
            RsPercent = "0.0%"
            Return RsPercent
            Exit Function
        End If
        RsPercent = CDbl(Cnt / CntTotal).ToString("0.0%")
        Return RsPercent
    End Function



    Public Function FechaCorrecta(ByVal fec_ As String) As Boolean
        Dim fec2_ As DateTime

        FechaCorrecta = False

        Try
            fec2_ = Date.Parse(fec_)
        Catch ex As Exception
            Exit Function
        End Try

        If IsDBNull(fec2_) <> True And Format(fec2_, "dd-MM-yyyy") <> "01-01-1753" And Format(fec2_, "dd-MM-yyyy") <> "01-01-1900" Then
            FechaCorrecta = True
        End If
    End Function


    Public Function HoraCorrecta(ByVal hr_ As String) As Boolean
        Dim hr2_ As TimeSpan

        HoraCorrecta = False

        If hr_.Trim.Length <> 5 Then Exit Function

        Try
            hr2_ = TimeSpan.Parse(hr_)
        Catch ex As Exception
            Exit Function
        End Try

        If IsDBNull(hr2_) <> True Then
            HoraCorrecta = True
        End If
    End Function


    Public Sub ExportToExcel(ByVal grilla As ListView, ByVal Totales(,) As String, Optional ByVal linedat As String = "")
        Dim lin, col As Integer
        Dim columns As String = ""

        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'volcamos titulos del listview
        For col = 2 To grilla.Columns.Count - 1
            'If grilla.Columns(col).Width > 0 Then
            columns = columns + grilla.Columns(col).Text + vbTab
            'End If
        Next
        '..........................................................................

        linedat = columns + vbCrLf + linedat + vbCrLf

        '..........................................................................
        'volcamos detalle del listview
        'For lin = 0 To grilla.Items.Count - 1
        '    For col = 1 To grilla.Columns.Count - 1
        '        If grilla.Columns(col).Width > 0 Then
        '            linedat = linedat + grilla.Items(lin).SubItems(col).Text.ToString.Trim + vbTab
        '        End If
        '    Next

        '    linedat = linedat + vbCrLf
        'Next
        '..........................................................................

        'linedat = linedat + vbCrLf

        '..........................................................................
        'volcamos los totales
        For lin = 0 To Totales.GetUpperBound(0)
            linedat = linedat + Totales(lin, 0) + vbTab + vbTab + Totales(lin, 1) + vbCrLf
        Next
        '...................................................... ....................


        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO enDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub ExportToExcelGrillaConsultaGeneral(ByVal grilla As ListView, ByVal Totales(,) As String)
        Dim lin, col As Integer
        Dim columns As String = ""
        'Dim linedat As String = ""
        Dim linedat As New StringBuilder

        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'volcamos titulos del listview
        For col = 1 To grilla.Columns.Count - 1
            If grilla.Columns(col).Width > 0 Then
                columns = columns + grilla.Columns(col).Text + vbTab
            End If
        Next
        '..........................................................................

        linedat.Append(columns + vbCrLf) '+ linedat + vbCrLf

        '..........................................................................
        'volcamos detalle del listview
        For lin = 0 To grilla.Items.Count - 1
            For col = 1 To grilla.Columns.Count - 1
                If grilla.Columns(col).Width > 0 Then
                    linedat.Append(grilla.Items(lin).SubItems(col).Text.ToString.Trim.Replace(vbCrLf, " ") + vbTab)
                End If

                'linedat.Append(grilla.Items(lin).SubItems(col).Text.ToString.Trim.Replace(vbCrLf, " ") + vbTab)
            Next

            linedat.Append(vbCrLf) '= linedat + vbCrLf
        Next
        '..........................................................................

        linedat.Append(vbCrLf)
        'linedat = linedat + vbCrLf

        '..........................................................................
        'volcamos los totales
        For lin = 0 To Totales.GetUpperBound(0)
            linedat.Append(Totales(lin, 0) + vbTab + vbTab + Totales(lin, 1) + vbCrLf)
            'linedat = linedat + Totales(lin, 0) + vbTab + vbTab + Totales(lin, 1) + vbCrLf
        Next
        '..........................................................................


        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ExportToExcelGrillaEmpresas(ByVal grilla As ListView)
        Dim lin As Integer
        Dim columns As String = ""
        Dim linedat As New StringBuilder
        Dim diio, cat, estproduc, estrepro, raz, fechnac, peso, nrpar, primerpar, ultpar, ultcubi, torocub, faprobpart, padre, madre As String

        Cursor.Current = Cursors.WaitCursor

        linedat.Append("DIIO" + vbTab + "CATEGORIA" + vbTab + "EST. PRODUCTIVO" + vbTab + "EST. REPRODUCTIVO" + vbTab + "RAZA" + vbTab + "FECHA. NAC." + vbTab + "PESO" + vbTab + "NRO. PARTOS" + vbTab + "F. 1er PARTO" + vbTab + "F. ULT. PARTO" + vbTab + "F. UTL. CBTA." + vbTab + "TORO ULT. CBTA" + vbTab + "F. PROB. PARTO" + vbTab + "PADRE" + vbTab + "MADRE" + vbCrLf) '+ linedat + vbCrLf

        '..........................................................................
        '1,2,7,8,4,3,65,19,14,15,20,22,17,23,24
        For lin = 0 To grilla.Items.Count - 1
            diio = grilla.Items(lin).SubItems(3).Text
            cat = grilla.Items(lin).SubItems(4).Text
            estproduc = grilla.Items(lin).SubItems(9).Text
            estrepro = grilla.Items(lin).SubItems(10).Text
            raz = grilla.Items(lin).SubItems(6).Text
            fechnac = grilla.Items(lin).SubItems(5).Text
            peso = grilla.Items(lin).SubItems(65).Text
            nrpar = grilla.Items(lin).SubItems(21).Text
            primerpar = grilla.Items(lin).SubItems(16).Text
            ultpar = grilla.Items(lin).SubItems(17).Text
            ultcubi = grilla.Items(lin).SubItems(22).Text
            torocub = grilla.Items(lin).SubItems(24).Text
            faprobpart = grilla.Items(lin).SubItems(19).Text
            padre = grilla.Items(lin).SubItems(25).Text
            madre = grilla.Items(lin).SubItems(26).Text


            linedat.Append(diio + vbTab + cat + vbTab + estproduc + vbTab + estrepro + vbTab + raz + vbTab + fechnac + vbTab + peso + vbTab + nrpar + vbTab + primerpar + vbTab + ultpar + vbTab + ultcubi + vbTab + torocub + vbTab + faprobpart + vbTab + padre + vbTab + madre + vbCrLf)
        Next
        '..........................................................................


        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub
    Public Sub ExportToExcelAlarma(ByVal grilla As ListView, ByVal alert As String)
        Dim lin As Integer
        Dim columns As String = ""
        Dim linedat As New StringBuilder
        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'volcamos titulos del listview
        'For col = 1 To grilla.Columns.Count - 1

        '    columns = columns + grilla.Columns(col).Text + vbTab

        'Next
        '..........................................................................

        ' linedat.Append(columns + vbCrLf)

        '..........................................................................
        'volcamos detalle del listview
        For lin = 0 To grilla.Items.Count - 1
            linedat.Append(grilla.Items(lin).SubItems(32).Text.ToString.Trim.Replace(vbCrLf, " ") + vbTab)
            linedat.Append(alert)

            linedat.Append(vbCrLf)
        Next
        '..........................................................................

        linedat.Append(vbCrLf)



        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Public Sub ExportToExcelGrilla(ByVal grilla As ListView, ByVal Totales(,) As String)
        Dim lin, col As Integer
        Dim columns As String = ""
        'Dim linedat As String = ""
        Dim linedat As New StringBuilder

        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'volcamos titulos del listview
        For col = 1 To grilla.Columns.Count - 1
            'If grilla.Columns(col).Width > 0 Then
            columns = columns + grilla.Columns(col).Text + vbTab
            'End If
        Next
        '..........................................................................

        linedat.Append(columns + vbCrLf) '+ linedat + vbCrLf

        '..........................................................................
        'volcamos detalle del listview
        For lin = 0 To grilla.Items.Count - 1
            For col = 1 To grilla.Columns.Count - 1
                linedat.Append(grilla.Items(lin).SubItems(col).Text.ToString.Trim.Replace(vbCrLf, " ") + vbTab)
            Next

            linedat.Append(vbCrLf) '= linedat + vbCrLf
        Next
        '..........................................................................

        linedat.Append(vbCrLf)
        'linedat = linedat + vbCrLf

        '..........................................................................
        'volcamos los totales
        For lin = 0 To Totales.GetUpperBound(0)
            linedat.Append(Totales(lin, 0) + vbTab + vbTab + Totales(lin, 1) + vbCrLf)
            'linedat = linedat + Totales(lin, 0) + vbTab + vbTab + Totales(lin, 1) + vbCrLf
        Next
        '..........................................................................


        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub ExportToExcelGrillaAlarmas(ByVal grilla As ListView, ByVal ColumnaDIIO As Integer)
        Dim lin, col As Integer
        'Dim columns As String = ""
        'Dim linedat As String = ""
        Dim linedat As New StringBuilder
        Dim colmsg As Integer = 0

        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'buscamos columna mensaje, la siguiente columna visible despues del DIIO (columna 3)
        For col = 1 To grilla.Columns.Count - 1

            If grilla.Columns(col).DisplayIndex = (ColumnaDIIO + 1) And grilla.Columns(col).Width > 0 Then
                colmsg = col
                Exit For
            End If

        Next
        '..........................................................................

        Dim diio As String
        Dim mensaje As String = ""

        '..........................................................................
        'volcamos columna diio formateado y columna mensaje
        For lin = 0 To grilla.Items.Count - 1
            diio = grilla.Items(lin).SubItems(3).Text.Trim
            mensaje = ""
            If colmsg > 0 Then mensaje = grilla.Items(lin).SubItems(colmsg).Text.Trim

            Dim new_diio = diio.PadLeft(12, "0")

            linedat.Append("152 " + new_diio + vbTab + mensaje + vbCrLf)
            'linedat.Append("152 00000" + diio + vbTab + mensaje + vbCrLf)
        Next
        '..........................................................................

        'linedat.Append(vbCrLf)

        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub ExportToExcelGrillaSIPEC(ByVal grilla As ListView)
        Dim lin As Integer
        Dim columns As String = ""
        Dim linedat As New StringBuilder
        Dim diio, raza, sexo, fec_nac, categ As String

        Cursor.Current = Cursors.WaitCursor


        'agregamos linea de encabezado (titulos)
        linedat.Append("NUMERO_DIIO" + vbTab + "RAZA" + vbTab + "SEXO" + vbTab + "FECHA_NACIMIENTO" + vbTab + "CATEGORIA" + vbCrLf) '+ linedat + vbCrLf

        '..........................................................................
        'volcamos detalle del listview
        For lin = 0 To grilla.Items.Count - 1
            diio = grilla.Items(lin).SubItems(3).Text
            raza = grilla.Items(lin).SubItems(56).Text
            sexo = grilla.Items(lin).SubItems(57).Text.Substring(0, 1)
            fec_nac = grilla.Items(lin).SubItems(5).Text
            categ = grilla.Items(lin).SubItems(4).Text

            linedat.Append(diio + vbTab + raza + vbTab + sexo + vbTab + fec_nac + vbTab + categ + vbCrLf)
        Next
        '..........................................................................


        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub ExportToExcelGrillaCamposVisible(ByVal grilla As ListView, ByVal Totales(,) As String)
        Dim lin, col As Integer
        Dim columns As String = ""
        'Dim linedat As String = ""
        Dim linedat As New StringBuilder

        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'volcamos titulos del listview
        For col = 1 To grilla.Columns.Count - 1
            If grilla.Columns(col).Width > 0 Then
                columns = columns + grilla.Columns(col).Text + vbTab
            End If
        Next
        '..........................................................................

        linedat.Append(columns + vbCrLf) '+ linedat + vbCrLf

        '..........................................................................
        'volcamos detalle del listview
        For lin = 0 To grilla.Items.Count - 1
            For col = 1 To grilla.Columns.Count - 1
                If grilla.Columns(col).Width > 0 Then
                    linedat.Append(grilla.Items(lin).SubItems(col).Text.ToString.Trim + vbTab)
                End If
            Next

            linedat.Append(vbCrLf) '= linedat + vbCrLf
        Next
        '..........................................................................

        linedat.Append(vbCrLf)
        'linedat = linedat + vbCrLf

        '..........................................................................
        'volcamos los totales
        For lin = 0 To Totales.GetUpperBound(0)
            linedat.Append(Totales(lin, 0) + vbTab + vbTab + Totales(lin, 1) + vbCrLf)
            'linedat = linedat + Totales(lin, 0) + vbTab + vbTab + Totales(lin, 1) + vbCrLf
        Next
        '..........................................................................


        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    Public Sub ExportToExcelGrillaCierre(ByVal grilla As ListView, ByVal Totales(,) As String, ByRef linedat As String, ByVal tipo As String)
        Dim lin, col As Integer
        Dim columns As String = ""
        ' Dim linedat As String = ""

        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'volcamos titulos del listview
        For col = 0 To grilla.Columns.Count - 1
            'If grilla.Columns(col).Width > 0 Then
            columns = columns + grilla.Columns(col).Text + vbTab
            'End If
        Next
        '..........................................................................

        linedat = linedat + columns + vbCrLf '+ linedat + vbCrLf

        '..........................................................................
        'volcamos detalle del listview
        For lin = 0 To grilla.Items.Count - 1
            For col = 0 To grilla.Columns.Count - 1
                'If grilla.Columns(col).Width > 0 Then
                linedat = linedat + grilla.Items(lin).SubItems(col).Text.ToString.Trim + vbTab
                'End If
            Next

            linedat = linedat + vbCrLf
        Next
        '..........................................................................

        linedat = linedat + vbCrLf

        '..........................................................................
        'volcamos los totales
        For lin = 0 To Totales.GetUpperBound(0)
            linedat = linedat + Totales(lin, 0) + vbTab + Totales(lin, 1) + vbTab + Totales(lin, 2) + vbTab + Totales(lin, 3) + vbTab + Totales(lin, 4) + vbTab + Totales(lin, 5) + vbTab + Totales(lin, 6) + vbTab + Totales(lin, 7) + vbTab + Totales(lin, 8) + vbTab + Totales(lin, 9) + vbTab + Totales(lin, 10) + vbTab + Totales(lin, 11) + vbTab + Totales(lin, 12) + vbTab + Totales(lin, 13) + vbTab + Totales(lin, 14) + vbTab + Totales(lin, 15) + vbCrLf
        Next
        '..........................................................................
        If tipo = 2 Then
            ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
            ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

            Try
                Dim MyTempFile As String = System.IO.Path.GetTempFileName()
                Dim MemStream As MemoryStream = New MemoryStream()
                Dim sw As StreamWriter = New StreamWriter(MemStream)
                Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

                sw.WriteLine(linedat)
                sw.Flush()

                MemStream.WriteTo(dumpFile)

                dumpFile.Close()
                sw.Close()
                MemStream.Close()

                Process.Start("Excel.exe", MyTempFile)
                'MsgBox("DUMP OK !!")


            Catch ex As Exception
                MsgBox("DUMP ERROR !!")
            End Try

        End If

        Cursor.Current = Cursors.Default

    End Sub



    Public Function BuscarDiio(ByVal CodigoDIIO As String) As Boolean
        BuscarDiio = False
        If CodigoDIIO.Trim = "" Then Exit Function

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spGanado_ConsultaDIIO", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@CodigoDIIO", CodigoDIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                Existe = True
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        BuscarDiio = Existe
    End Function



    Public Function ObtenerFechaServidor() As DateTime
        ObtenerFechaServidor = Nothing

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spSistema_FechaServidor", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                ObtenerFechaServidor = rdr("FechaServidor")
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Function
    Public Function Manuales(ByVal CenNom As String, ByVal WB As WebBrowser) As Boolean
        Cursor.Current = Cursors.WaitCursor
        Manuales = False
        Try
            Dim path_ As String = "\\fileserver\IT Manuales Sistemas"
            Dim files1_ As List(Of String) = IO.Directory.GetFiles(path_).ToList
            Dim file_ As String = ""

            For Each itm In files1_
                Dim pos As Integer
                Try
                    pos = InStr(1, itm, ".pdf")
                Catch ex As Exception
                    pos = 0
                End Try
                If pos <> 0 Then
                    Dim strFileName As String = itm
                    If strFileName.Contains(CenNom) Then
                        file_ = itm
                        Exit For
                    End If
                End If
            Next

            If IO.File.Exists(file_) Then
                WB.Visible = True
                WB.Navigate(file_)
                Manuales = True
            Else
                WB.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Function
    Public Function MapFile(ByVal CenCod As String, ByVal WB As WebBrowser) As Boolean
        Cursor.Current = Cursors.WaitCursor
        MapFile = False
        Try
            Dim path_ As String = "\\fileserver\planos"
            Dim pathLen As Integer = Len(path_)
            Dim files1_ As List(Of String) = IO.Directory.GetFiles(path_).ToList
            Dim file_ As String = ""

            For Each itm In files1_
                Dim pos As Integer
                Try
                    pos = InStr(1, itm, ".pdf")
                Catch ex As Exception
                    pos = 0
                End Try
                If pos <> 0 Then
                    Dim strFileName As String = itm.Substring(pathLen + 1, 7) 'pos - pathLen
                    If strFileName.ToUpper.Equals(CenCod.Trim.ToUpper) Then
                        file_ = itm
                        Exit For
                    End If
                End If
            Next

            If IO.File.Exists(file_) Then
                WB.Visible = True
                WB.Navigate(file_)
                MapFile = True
            Else
                WB.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Function
    Public Function ValidaUltimaVersion() As Boolean
        ValidaUltimaVersion = True
        VERSION_SGL_SQL = 0
        BuscaUltimaVersion()
        If My.Computer.Network.IsAvailable Then
            If VERSION_SGL_SQL <> VERSION_SGL_APP Then
                ValidaUltimaVersion = False
            End If
        Else
            MsgBox("Computador desconectado de la red de datos, por lo que no podra usar los sistemas ni internet. Informe a TI.")
        End If

    End Function
    Public Function VerificaAviso() As Boolean
        VerificaAviso = False
        Cursor.Current = Cursors.WaitCursor

            Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spVersionesSGLVerificar", con)
        Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Version", VERSION_SGL_APP)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
            cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

            Try
                con.Open()
                Dim Result As Integer = cmd.ExecuteNonQuery()
                Dim vret As Integer = cmd.Parameters("@RetValor").Value
                Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret = 2 Then
                VerificaAviso = False
                Exit Function
            End If
        Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            VerificaAviso = False
        Finally
                con.Close()
            End Try
        VerificaAviso = True
        Cursor.Current = Cursors.Default
    End Function
    Private Sub BuscaUltimaVersion()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spVersionesSGL", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@Version", VERSION_SGL_APP)

            con.Open()
            rdr = cmd.ExecuteReader()

            While rdr.Read()
                VERSION_SGL_SQL = rdr("IdVersion")
            End While

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor

    End Sub

    Public Sub ExportToExcelGrillaDiio(ByVal grilla As ListView, ByVal alert As String)
        Dim lin As Integer
        Dim columns As String = ""
        Dim linedat As New StringBuilder
        Cursor.Current = Cursors.WaitCursor

        '..........................................................................
        'volcamos titulos del listview

        '..........................................................................
        'volcamos detalle del listview
        For lin = 0 To grilla.Items.Count - 1

            If Len(grilla.Items(lin).SubItems(3).Text.ToString) = 8 Then
                linedat.Append("152 0000" + grilla.Items(lin).SubItems(3).Text.ToString.Trim.Replace(vbCrLf, " ") + vbTab)
            Else
                linedat.Append("152 00000" + grilla.Items(lin).SubItems(3).Text.ToString.Trim.Replace(vbCrLf, " ") + vbTab)
            End If

            'linedat.Append(grilla.Items(lin).SubItems(3).Text.ToString.Trim.Replace(vbCrLf, " ") + vbTab)
            linedat.Append(alert)

            linedat.Append(vbCrLf)
        Next
        '..........................................................................

        linedat.Append(vbCrLf)



        ''UNA VEZ OBTENIDO LA CADENA CON TODA LA INFORMACION DEL LISTVIEW
        ''LO VOLCAMOS A UN ARCHIVO DE TEXTO PARA LUEGO ABRIRLO DESDE EXCEL

        Try
            Dim MyTempFile As String = System.IO.Path.GetTempFileName()
            Dim MemStream As MemoryStream = New MemoryStream()
            Dim sw As StreamWriter = New StreamWriter(MemStream)
            Dim dumpFile As FileStream = New FileStream(MyTempFile, FileMode.Create, FileAccess.ReadWrite)

            sw.WriteLine(linedat)
            sw.Flush()

            MemStream.WriteTo(dumpFile)

            dumpFile.Close()
            sw.Close()
            MemStream.Close()

            Process.Start("Excel.exe", MyTempFile)
            'MsgBox("DUMP OK !!")

        Catch ex As Exception
            MsgBox("DUMP ERROR !!")
        End Try

        Cursor.Current = Cursors.Default
    End Sub


End Module
