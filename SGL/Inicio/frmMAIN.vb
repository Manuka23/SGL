Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.ComponentModel



Public Class frmMAIN


    <DllImport("user32")>
    Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function
    Public cierreforzado As Integer = 0
    Private ConsVersiones As String
    Private dataSetArbol As DataSet

    Private dvcread As frmLeerDispositivoV3

    Private Sub frmMAIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tmrLogin.Enabled = True

        tvMENU.Dock = DockStyle.Fill
        tvMENU.Scrollable = True
        CargarConfiguracionLocal()

        ''DESCRIPCION DE VERSION v1.2.3.4:
        ''
        ''  1 = indica un cambio importante, como de base de datos, de tecnologia (por ej, cuando se implementen las clases, modelo 3 capas)
        ''  2 = indica cambios en el sistema
        ''  3 = indica cambios en la base de datos
        ''  4 = indica subidas a produccion 
        ''
        '' partimos con la version v1.1.1.1, 28-11-2013
        ''

        lblActualizacion.Text = "v2.384.367.382" + vbCrLf + "Actualizado el 04-09-2023"
        VERSION_SGL_APP = 364
    End Sub

    Private Sub CerrarSesionUsuario()

        Me.SuspendLayout()
        Me.Text = "MANUKA SGL - Sistema Gestion de Ganado & Lechería"

        tvMENU.Nodes.Clear()

        txtDIIO.Text = ""
        pnlMenu.Visible = False
        'pnlMenu.Visible = False
        pnlMenu.Visible = False
        'pnlBarra.Visible = False
        lblTitCentro.Visible = False
        lblCentro.Visible = False
        lblTitDIIO.Visible = False
        txtDIIO.Visible = False
        btnBuscaDIIO.Visible = False
        btnActualizaciones.Visible = False
        btnPanelConsulta.Visible = False
        btnCerrarSesion.Visible = False
        btnTablero.Visible = False

        LimpiarDatosUsuario()

        tmrLogin.Enabled = True
        Me.ResumeLayout()
    End Sub


    Private Function VerificaCierre(ByVal desde As Integer) As Boolean
        VerificaCierre = False

        If frmLogin.Visible = True Then
            VerificaCierre = True
            Exit Function
        End If

        Dim MsgCierra1 As String = ""
        Dim MsgCierra2 As String = ""
        Dim MsgCierra3 As String = ""

        If desde = 1 Then
            MsgCierra1 = "¿DESEA SALIR DE LA APLICACION?"
            MsgCierra2 = "EXISTEN VENTANAS ACTIVAS," + vbCrLf + "¿DESEA SALIR DE TODAS FORMAS?"
            MsgCierra3 = "SALIR"
        End If
        If desde = 2 Then
            MsgCierra1 = "¿DESEA CERRAR LA SESIÓN?"
            MsgCierra2 = "EXISTEN VENTANAS ACTIVAS," + vbCrLf + "¿DESEA CERRAR LA SESIÓN DE TODAS FORMAS?"
            MsgCierra3 = "CERRAR SESIÓN"
        End If

        If MsgBox(MsgCierra1, MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgCierra3) <> vbYes Then
            Exit Function
        End If

        Dim frm As Form
        Dim ex_ As Boolean = False

        Dim ContFrm As Integer = 0

        For Each frm In Me.MdiChildren

            ex_ = True
            ContFrm = ContFrm + 1

        Next

        If ex_ = True Then
            If ContFrm > 1 Then
                If MsgBox(MsgCierra2, MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgCierra3) <> vbYes Then
                    Exit Function
                End If
            End If

            For Each frm In Me.MdiChildren
                frm.Close()
            Next
        End If

        VerificaCierre = True
    End Function


    Private Sub CrearNodosDelPadre(ByVal indicePadre As Integer, ByVal nodePadre As TreeNode, ByVal Idioma As Integer)
        Dim dataViewHijos As DataView

        ' Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        dataViewHijos = New DataView(dataSetArbol.Tables("TablaArbol"))

        dataViewHijos.RowFilter = dataSetArbol.Tables("TablaArbol").Columns("IdentificadorPadre").ColumnName + " = " + indicePadre.ToString()


        ' Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        For Each dataRowCurrent As DataRowView In dataViewHijos

            Dim nuevoNodo As New TreeNode
            If Idioma = 1 Then
                nuevoNodo.Text = dataRowCurrent("NombreNodo").ToString().Trim()
            Else
                nuevoNodo.Text = dataRowCurrent("NombreNodoIngles").ToString().Trim()
            End If

            nuevoNodo.Tag = dataRowCurrent("NombreNodo").ToString().Trim()

            ' si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
            ' del primer nivel que no dependen de otro nodo.
            If nodePadre Is Nothing Then
                tvMENU.Nodes.Add(nuevoNodo)
            Else
                ' se añade el nuevo nodo al nodo padre.
                nodePadre.Nodes.Add(nuevoNodo)
            End If

            ' Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
            CrearNodosDelPadre(Int32.Parse(dataRowCurrent("IdentificadorNodo").ToString()), nuevoNodo, Idioma)
        Next dataRowCurrent

    End Sub


    Private Sub CrearDataSet()
        Dim tablaArbol As DataTable

        dataSetArbol = New DataSet("DataSetArbol")

        tablaArbol = dataSetArbol.Tables.Add("TablaArbol")
        tablaArbol.Columns.Add("NombreNodo", GetType(String))
        tablaArbol.Columns.Add("IdentificadorNodo", GetType(Integer))
        tablaArbol.Columns.Add("IdentificadorPadre", GetType(Integer))
        tablaArbol.Columns.Add("NombreNodoIngles", GetType(String))


    End Sub


    Private Sub InsertarDataRow(ByVal column1 As String, ByVal column2 As Integer, ByVal column3 As Integer, ByVal menu_ingles As String)
        Dim nuevaFila As DataRow

        nuevaFila = dataSetArbol.Tables("TablaArbol").NewRow()

        nuevaFila("NombreNodo") = column1
        nuevaFila("IdentificadorNodo") = column2
        nuevaFila("IdentificadorPadre") = column3
        nuevaFila("NombreNodoIngles") = menu_ingles
        dataSetArbol.Tables("TablaArbol").Rows.Add(nuevaFila)
    End Sub

    'idioma = 1 -> Español / idioma = 2 -> Ingles
    Public Sub CargaMenuPrincipal(ByVal LoginUsuario As String, ByVal Idioma As Integer)
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMenuPerfil_Listado", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        Try
            con.Open()

            rdr = cmd.ExecuteReader()

            CrearDataSet()

            Try
                Dim cod_padre As Integer
                Dim cod_menu As Integer
                Dim nom_menu As String
                Dim nom_menu_ingles As String

                While rdr.Read()
                    cod_padre = rdr("NodoSecundario")
                    nom_menu = Trim(rdr("DesMnu"))
                    nom_menu_ingles = Trim(rdr("DesMnuIngles"))

                    cod_menu = rdr("CodMnu")

                    ''OCULTAMOS OPCION DE INGRESO PRODUCTOS DE CONCENTRADO PARA LOS USUARIOS NO AUTORIZADOS
                    If nom_menu = "PRODUCTOS DE CONCENTRADO" Then
                        If UsuarioAdminConcentrado <> 0 Then
                            InsertarDataRow(nom_menu, cod_menu, cod_padre, nom_menu_ingles)
                        End If
                    Else
                        InsertarDataRow(nom_menu, cod_menu, cod_padre, nom_menu_ingles)
                    End If

                End While

                tvMENU.Nodes.Clear()

                CrearNodosDelPadre(0, Nothing, Idioma)

                Dim tn As TreeNode
                For Each tn In tvMENU.Nodes
                    If tn.Tag.ToLower = "producción" Then
                        tvMENU.SelectedNode = tn
                        tvMENU.SelectedNode.Expand()
                        Exit For
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub ConsultaDIIO()
        If txtDIIO.Text.Trim = "" Then Exit Sub

        Dim ConsultaDIIO As New infodiios

        Cursor.Current = Cursors.WaitCursor

        ConsultaDIIO.MdiParent = Me
        ConsultaDIIO.lblDIIO.Text = txtDIIO.Text
        ConsultaDIIO.ConsultaDIIO(txtDIIO.Text)

        ConsultaDIIO.Show()

        Cursor.Current = Cursors.Default

        txtDIIO.Text = ""
    End Sub


    Private Sub tvMENU_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvMENU.DoubleClick
        If tvMENU.SelectedNode Is Nothing Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Select Case tvMENU.SelectedNode.Tag.ToUpper
            Case "CIERRE MENSUAL"
                frmCierresIngreso.MdiParent = Me
                frmCierresIngreso.Show()
                frmCierresIngreso.BringToFront()

            Case "CIERRE TEMPORADAS"
                frmCierresTemporada.MdiParent = Me
                frmCierresTemporada.Show()
                frmCierresTemporada.BringToFront()

            Case "CELOS" 'Or "HEAT"
                frmCelosPorCentros.MdiParent = Me
                frmCelosPorCentros.Show()
                frmCelosPorCentros.BringToFront()

            Case "AJUSTES DE STOCK"
                frmAjustes.MdiParent = Me
                frmAjustes.Show()
                frmAjustes.BringToFront()

            Case "INGRESO DE INSEMINACIONES" 'Or "INSEMINATIONS"
                frmCubiertasPorCentros.MdiParent = Me
                frmCubiertasPorCentros.Show()
                frmCubiertasPorCentros.BringToFront()

            Case "PLANILLA DE INSEMINACIONES"
                frmCubiertasPlanilla.MdiParent = Me
                frmCubiertasPlanilla.Show()
                frmCubiertasPlanilla.BringToFront()

            Case "PAGO DE INSEMINACIONES"
                frmPagoCubiertas.MdiParent = Me
                frmPagoCubiertas.Show()
                frmPagoCubiertas.BringToFront()

            Case "CONTROL LECHERO"
                frmControlLechero.MdiParent = Me
                frmControlLechero.Show()
                frmControlLechero.BringToFront()

            Case "REGISTRO CIDR"
                frmIATFPorCentros.MdiParent = Me
                frmIATFPorCentros.Show()
                frmIATFPorCentros.BringToFront()

            Case "TNR"
                frmTNR.MdiParent = Me
                frmTNR.Show()
                frmTNR.BringToFront()

            Case "DESECHOS"
                frmDesechosIngreso.MdiParent = Me
                frmDesechosIngreso.Show()
                frmDesechosIngreso.BringToFront()

            Case "PALPACIONES" ' Or "PALPATIONS"
                frmPalpaciones.MdiParent = Me
                frmPalpaciones.Show()
                frmPalpaciones.BringToFront()

            Case "MUERTES" ' Or "DEATHS"
                frmMuertes.MdiParent = Me
                frmMuertes.Show()
                frmMuertes.BringToFront()

            Case "SECADO DE LECHE" ' Or "MILK DRAY"
                frmSecados.MdiParent = Me
                frmSecados.Show()
                frmSecados.BringToFront()

            Case "REV. POST PARTO" ' Or "CHECK POST PART"
                frmRevPostPartos.MdiParent = Me
                frmRevPostPartos.Show()
                frmRevPostPartos.BringToFront()

            Case "PARTOS" ' & "PARTS"
                frmPartos.MdiParent = Me
                frmPartos.Show()
                frmPartos.BringToFront()

            Case "VENTAS" 'Or "SALES"
                frmVentas2.MdiParent = Me
                frmVentas2.Show()
                frmVentas2.BringToFront()

            Case "COMPRAS" 'Or "EXTERNAL BUY"
                frmCompras.MdiParent = Me
                frmCompras.Show()
                frmCompras.BringToFront()

            Case "PRENDA ANIMALES" 'Or "EXTERNAL BUY"
                frmPrendaAnimales.MdiParent = Me
                frmPrendaAnimales.Show()
                frmPrendaAnimales.BringToFront()

            Case "CALIDAD LECHE"
                frmCalidadLeche.MdiParent = Me
                frmCalidadLeche.Show()
                frmCalidadLeche.BringToFront()

            Case "TRASLADOS" 'Or "TRANSFERS"
                frmTraslados.MdiParent = Me
                frmTraslados.Show()
                frmTraslados.BringToFront()

            Case "MUESTREOS"
                FrmMuestreos.MdiParent = Me
                FrmMuestreos.Show()
                FrmMuestreos.BringToFront()

            Case "ESTANQUES"
                frmEstanques.MdiParent = Me
                frmEstanques.Show()
                frmEstanques.BringToFront()

            Case "VACUNAS"
                frmVacunasNuevaVacuna.MdiParent = Me
                frmVacunasNuevaVacuna.Show()
                frmVacunasNuevaVacuna.BringToFront()

            Case "COJERAS"
                FrmCojeras.MdiParent = Me
                FrmCojeras.Show()
                FrmCojeras.BringToFront()

            Case "MASTITIS"
                FrmMastitis.MdiParent = Me
                FrmMastitis.Show()
                FrmMastitis.BringToFront()

            Case "OTROS TRATAMIENTOS"
                frmOtrosTratamientos.MdiParent = Me
                frmOtrosTratamientos.Show()
                frmOtrosTratamientos.BringToFront()

            Case "PATOLOGIAS"
                frmPatologias.MdiParent = Me
                frmPatologias.Show()
                frmPatologias.BringToFront()

            Case "FARMACOS"
                frmFarmacos.MdiParent = Me
                frmFarmacos.Show()
                frmFarmacos.BringToFront()

            Case "RECUENTO CEL.SOMATICAS"
                FrmRecuentoCS.MdiParent = Me
                FrmRecuentoCS.Show()
                FrmRecuentoCS.BringToFront()

            Case "INGRESO DE PESO" 'Or "WEIGHT"
                FrmCrianza.MdiParent = Me
                FrmCrianza.Show()
                FrmCrianza.BringToFront()

            Case "INGRESO DIARIO" ' Or "DAILY INPUTS"
                frmIngresoDiario.MdiParent = Me
                frmIngresoDiario.Show()
                frmIngresoDiario.BringToFront()


            Case "   LECHE PLANTAS"
                FrmLecheClientes.MdiParent = Me
                FrmLecheClientes.Show()
                FrmLecheClientes.BringToFront()

            Case "INGRESO DE DIIOS" ' Or "NEW DIIOS"
                frmAdminDiios.MdiParent = Me
                frmAdminDiios.Show()
                frmAdminDiios.BringToFront()

            Case "CAMBIO DE DIIOS" ' Or "CHANGE DIIOS"
                frmCambioDeDiios.MdiParent = Me
                frmCambioDeDiios.Show()
                frmCambioDeDiios.BringToFront()

            Case "CAUSAS"
                frmCausas.MdiParent = Me
                frmCausas.Show()
                frmCausas.BringToFront()

            Case "DOSIS DE SEMEN"
                frmAdminDosis.MdiParent = Me
                frmAdminDosis.Show()
                frmAdminDosis.BringToFront()

            Case "INDUCCIONES"
                frmInducciones.MdiParent = Me
                frmInducciones.Show()
                frmInducciones.BringToFront()

            Case "TOROS" 'Or "BULLS"
                frmToros.MdiParent = Me
                frmToros.Show()
                frmToros.BringToFront()

            Case "INSEMINADORES"
                frmInseminadores.MdiParent = Me
                frmInseminadores.Show()
                frmInseminadores.BringToFront()

            Case "USUARIOS"
                frmUsuarios.MdiParent = Me
                frmUsuarios.Show()
                frmUsuarios.BringToFront()

            Case "PERFILES DE USUARIO"
                FrmPerfiles.MdiParent = Me
                FrmPerfiles.Show()
                FrmPerfiles.BringToFront()
            Case "VETERINARIOS"
                frmVeterinarios.MdiParent = Me
                frmVeterinarios.Show()
                frmVeterinarios.BringToFront()

            Case "MENUS"
                FrmMenu_principal.MdiParent = Me
                FrmMenu_principal.Show()
                FrmMenu_principal.BringToFront()

            Case "MENU PERFILES"
                frmMenu_perfiles.MdiParent = Me
                frmMenu_perfiles.Show()
                frmMenu_perfiles.BringToFront()

            Case "CAMBIOS DE CATEGORIAS"
                frmCambioDeCategoriaCargaMasiva.MdiParent = Me
                frmCambioDeCategoriaCargaMasiva.Show()
                frmCambioDeCategoriaCargaMasiva.BringToFront()

            Case "POTREROS"
                frmPotreros.MdiParent = Me
                frmPotreros.Show()
                frmPotreros.BringToFront()

            Case "ROTACION DE POTREROS" ' Or "GRAZING"
                frmRotacionPotrerosIngreso.MdiParent = Me
                frmRotacionPotrerosIngreso.Show()
                frmRotacionPotrerosIngreso.BringToFront()

            Case "RAZAS"
                frmRazas.MdiParent = Me
                frmRazas.Show()
                frmRazas.BringToFront()

            Case "PLANILLA SINCRONIZACION"
                frmSincronizacionLista.MdiParent = Me
                frmSincronizacionLista.Show()
                frmSincronizacionLista.BringToFront()

            Case "MEDICIONES DE PASTO"
                frmMedicionPastoIngreso.MdiParent = Me
                frmMedicionPastoIngreso.Show()
                frmMedicionPastoIngreso.BringToFront()

            Case "FERTILIDAD DE SUELO"
                frmFertilizante.MdiParent = Me
                frmFertilizante.Show()
                frmFertilizante.BringToFront()

            Case "VACUNACION"
                frmVacunas.MdiParent = Me
                frmVacunas.Show()
                frmVacunas.BringToFront()

            Case "PRODUCTOS DE CONCENTRADOS"
                frmProductosConcentrado.MdiParent = Me
                frmProductosConcentrado.Show()
                frmProductosConcentrado.BringToFront()

            Case "SOLICITUDES"
                frmExtSolicitudes.MdiParent = Me
                frmExtSolicitudes.Show()
                frmExtSolicitudes.BringToFront()

            Case "CAMBIO DE RAZAS"
                frmReportesCambioRazas.MdiParent = Me
                frmReportesCambioRazas.Show()
                frmReportesCambioRazas.BringToFront()
            Case "CAMBIO ESTADO PRODUCTIVO"

                frmCambioEsProductivo.MdiParent = Me
                frmCambioEsProductivo.Show()
                frmCambioEsProductivo.BringToFront()

            Case "MUESTRA LECHE"
                frmMuestraLecheResumen.MdiParent = Me
                frmMuestraLecheResumen.Show()
                frmMuestraLecheResumen.BringToFront()

            Case "CONTEO DE ANIMALES"
                frmConteoAnimales.MdiParent = Me
                frmConteoAnimales.Show()
                frmConteoAnimales.BringToFront()

            Case "REPORTE DE CONTEO"
                Cursor.Current = Cursors.WaitCursor
                frptConteoAnimales.Show()
                frptConteoAnimales.BringToFront()
            Case "TIPO DESECHOS"
                frmTipoDesechos.MdiParent = Me
                frmTipoDesechos.Show()
                frmTipoDesechos.BringToFront()
            Case "REPORTE PARTOS"
                Cursor.Current = Cursors.WaitCursor
                frptPartos.Show()
                frptPartos.BringToFront()

            Case "REPORTE PARTOS SAG"
                Cursor.Current = Cursors.WaitCursor
                frptPartosSAG.Show()
                frptPartosSAG.BringToFront()

            Case "REPORTE DETALLE PARTOS"
                Cursor.Current = Cursors.WaitCursor
                frptPartosDetalle.Show()
                frptPartosDetalle.BringToFront()

            Case "REPORTE PARTOS ELIMINADOS"
                Cursor.Current = Cursors.WaitCursor
                frptPartosEliminados.Show()
                frptPartosEliminados.BringToFront()

            Case "REPORTE NACIMIENTOS - ANALISIS DIIOS"
                Cursor.Current = Cursors.WaitCursor
                'frptPartosAnalisisDiiosold.Show()
                'frptPartosAnalisisDiiosold.BringToFront()
                frptPartosAnalisisDiios.FecIni = "2021-07-01"
                frptPartosAnalisisDiios.FecFin = "2021-07-29"
                frptPartosAnalisisDiios.CenCod = UsuarioCentroCodDefault
                frptPartosAnalisisDiios.EmpCod = Empresa
                frptPartosAnalisisDiios.Show()
                frptPartosAnalisisDiios.BringToFront()

            Case "INGRESO CONSUMO"
                frmLuzMenu.MdiParent = Me
                frmLuzMenu.Show()
                frmLuzMenu.BringToFront()

            Case "CARGA BI"
                frmCargaBI.MdiParent = Me
                frmCargaBI.Show()
                frmCargaBI.BringToFront()

            Case "CARGA BUDGET"
                frmCarga.MdiParent = Me
                frmCarga.Show()
                frmCarga.BringToFront()

            Case "MANTENCIÓN"
                frmMantencion.MdiParent = Me
                frmMantencion.Show()
                frmMantencion.BringToFront()

            Case "CONFECCION ENSILAJE"
                frmSilos.MdiParent = Me
                frmSilos.Show()
                frmSilos.BringToFront()

            Case "BALANCE FORRAJERO"
                frmBalanceForrajero.MdiParent = Me
                frmBalanceForrajero.Show()
                frmBalanceForrajero.BringToFront()

            Case "PABCO"
                frmSaludAnimal.MdiParent = Me
                frmSaludAnimal.Show()
                frmSaludAnimal.BringToFront()

            Case "MEDICAMENTOS"
                frmMedicamentos.MdiParent = Me
                frmMedicamentos.Show()
                frmMedicamentos.BringToFront()

            Case "BODEGA"
                frmBodega.MdiParent = Me
                frmBodega.Show()
                frmBodega.BringToFront()

            Case "CAMBIO DE CONTRASEÑA"
                frmUsuariosCambioContrasena.MdiParent = Me
                frmUsuariosCambioContrasena.Show()
                frmUsuariosCambioContrasena.BringToFront()

            Case "PRODUCTOS DE UREA"
                frmProductosUreaIngreso.MdiParent = Me
                frmProductosUreaIngreso.Show()
                frmProductosUreaIngreso.BringToFront()

            Case "CUENTAS CONTABLES"
                frmCuentasContables.MdiParent = Me
                frmCuentasContables.Show()
                frmCuentasContables.BringToFront()

            Case "TEST INMUNIDAD"
                frmGanadoInmunidad.MdiParent = Me
                frmGanadoInmunidad.Show()
                frmGanadoInmunidad.BringToFront()

            Case "VENTAS REQUERIMIENTOS"
                frmVentasRequerimiento.MdiParent = Me
                frmVentasRequerimiento.Show()
                frmVentasRequerimiento.BringToFront()

            Case "GENETICA"
                frmGenetica.MdiParent = Me
                frmGenetica.Show()
                frmGenetica.BringToFront()

        End Select

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub tmrLogin_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLogin.Tick
        tmrLogin.Enabled = False
        frmLogin.ShowDialog()
    End Sub


    Private Sub btnConsultaPanel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPanelConsulta.Click
        Cursor.Current = Cursors.WaitCursor

        frmConsultaGeneral.MdiParent = Me
        frmConsultaGeneral.Show()
        frmConsultaGeneral.BringToFront()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnBuscaDIIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaDIIO.Click
        ConsultaDIIO()
    End Sub


    Private Sub CargarConfiguracionLocal()
        Dim ini As Configuracion = New Configuracion(Directory.GetCurrentDirectory + "\config.ini")
        Dim Idioma As String = ini.ReadValue("GENERAL", "idioma")

        'si no existe la configuracion del idioma (o el archivo config.ini), creamos la clave
        If Idioma = "" Then
            ini.WriteValue("GENERAL", "idioma", "1")
            IdiomaSistema = 1                           'idioma español por defecto
        Else
            IdiomaSistema = Convert.ToInt32(Idioma)     'tomamos idioma de la configuracion
        End If
    End Sub


    Private Sub GrabarConfiguracionIdioma(ByVal Idioma As Integer)
        Dim ini As Configuracion = New Configuracion(Directory.GetCurrentDirectory + "\config.ini")

        ini.WriteValue("GENERAL", "idioma", Idioma.ToString)
        IdiomaSistema = Idioma                           'idioma español por defecto
    End Sub


    Private Sub txtDIIO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Control.ModifierKeys = Keys.Control Then
            If e.KeyCode = Keys.V Then
                txtDIIO.Text = Clipboard.GetText
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub txtDIIO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtDIIO.Text = txtDIIO.Text.Trim
            ConsultaDIIO()
            e.Handled = True
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CambiaTamañoPanel()

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CambiaTamañoPanel()
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CambiaTamañoPanel()
    End Sub


    Private Sub CambiaTamañoPanel()
        If lblHideShowMenu.Text = "<" Then
            lblHideShowMenu.Text = ">"

            pnlMenu.Width = 78
            lblHideShowMenu.Left = 50
            lblTituloMenu.Width = 70

            tvMENU.Visible = False
            tabGrupos.Visible = False
            lblActualizacion.Visible = False
            pnlBuscarGrupo.Visible = False
            Panel2.Visible = False
            lblTituloMenu.Text = "MENU"
        Else
            lblHideShowMenu.Text = "<"

            pnlMenu.Width = 198
            lblHideShowMenu.Left = 173
            lblTituloMenu.Width = 190

            tvMENU.Visible = True
            tabGrupos.Visible = True
            lblActualizacion.Visible = True
            pnlBuscarGrupo.Visible = True
            Panel2.Visible = True
            lblTituloMenu.Text = "MENU PRINCIPAL"
        End If
    End Sub

    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            lblHideShowMenu.ForeColor = Color.White
            lblHideShowMenu.Font = New Font(lblHideShowMenu.Font, FontStyle.Bold)
        End If
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            lblHideShowMenu.ForeColor = Color.LawnGreen
            lblHideShowMenu.Font = New Font(lblHideShowMenu.Font, FontStyle.Regular)
        End If
    End Sub




    Private Sub frmMAIN_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If cierreforzado = 1 Then

        Else
            If VerificaCierre(1) = False Then e.Cancel = True
        End If

    End Sub


    Private Sub frmMAIN_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Me.SuspendLayout()

        btnCerrarSesion.Left = Me.Width - btnCerrarSesion.Width - 20
        btnPanelConsulta.Left = Me.Width - btnCerrarSesion.Width - btnPanelConsulta.Width - 20

        btnTablero.Left = Me.Width - btnCerrarSesion.Width - btnPanelConsulta.Width - btnTablero.Width - 20
        btnActualizaciones.Left = Me.Width - btnCerrarSesion.Width - btnPanelConsulta.Width - btnTablero.Width - btnActualizaciones.Width - 20
        btnBuscaDIIO.Left = btnHerramientas.Left - btnBuscaDIIO.Width - 200
        txtDIIO.Left = btnBuscaDIIO.Left - txtDIIO.Width - 2
        lblTitDIIO.Left = txtDIIO.Left - lblTitDIIO.Width '- 5

        'LineShape3.X1 = -200
        'LineShape3.X2 = Me.Width
        'lblSeparador.Width = Me.Width
        Me.ResumeLayout()

        Me.Refresh()
    End Sub

    Private Sub btnVerGrupoDiio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerGrupoDiio.Click
        VerGrupoDiio()
    End Sub

    Private Sub txtDIIOGrupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIOGrupo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If ExisteDiioGrupo(txtDIIOGrupo.Text.Trim) Then
                If MsgBox("EL DIIO YA EXISTE EN EL GRUPO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "MANUKA") = vbOK Then
                End If
            Else
                AgregaDiioGrupo()
            End If
        End If
    End Sub


    Private Sub btnLeeBaston_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeeBaston.Click
        LeeBaston()

    End Sub


    Private Sub btnAgrupar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrupar.Click
        LimpiarDiioGrupo()
    End Sub


    Private Sub VerGrupoDiio()
        Dim Selecteditems As String = ""

        Select Case tabGrupos.SelectedIndex
            Case 0
                If lvGrupo1.Items.Count = 0 Then Exit Sub
                For i As Integer = 0 To lvGrupo1.Items.Count - 1
                    Selecteditems = Selecteditems & lvGrupo1.Items(i).SubItems(1).Text & ","
                Next

            Case 1
                If lvGrupo2.Items.Count = 0 Then Exit Sub
                For i As Integer = 0 To lvGrupo2.Items.Count - 1
                    Selecteditems = Selecteditems & lvGrupo2.Items(i).SubItems(1).Text & ","
                Next

            Case 2
                If lvGrupo3.Items.Count = 0 Then Exit Sub
                For i As Integer = 0 To lvGrupo3.Items.Count - 1
                    Selecteditems = Selecteditems & lvGrupo3.Items(i).SubItems(1).Text & ","
                Next
        End Select


        Selecteditems = Selecteditems.Substring(0, Selecteditems.Length - 1)

        Dim cd As New frmConsultaGeneralDIIOs

        cd.txtDIIOs.Text = Selecteditems
        cd.MdiParent = Me
        cd.Show()
        cd.BringToFront()

        cd.BuscarDatos()
    End Sub


    Private Function ExisteDiioGrupo(ByVal DIIO As Integer) As Boolean
        ExisteDiioGrupo = False

        Select Case tabGrupos.SelectedIndex
            Case 0
                For Each itm As ListViewItem In lvGrupo1.Items
                    If DIIO = itm.SubItems(1).Text Then Return True
                Next

            Case 1
                For Each itm As ListViewItem In lvGrupo2.Items
                    If DIIO = itm.SubItems(1).Text Then Return True
                Next

            Case 2
                For Each itm As ListViewItem In lvGrupo3.Items
                    If DIIO = itm.SubItems(1).Text Then Return True
                Next
        End Select
    End Function


    Private Sub AgregaDiioGrupo()
        If txtDIIOGrupo.Text.Trim = "" Then Exit Sub

        Dim num As Integer = 0

        Select Case tabGrupos.SelectedIndex
            Case 0
                num = lvGrupo1.Items.Count + 1
                Dim item As New ListViewItem(num.ToString)    'nro
                item.SubItems.Add(txtDIIOGrupo.Text.Trim)
                lvGrupo1.Items.Add(item)
                txtDIIOGrupo.Text = ""
                lvGrupo1.Items(lvGrupo1.Items.Count - 1).Selected = True
                lvGrupo1.EnsureVisible(lvGrupo1.Items.Count - 1)
            Case 1
                num = lvGrupo2.Items.Count + 1
                Dim item As New ListViewItem(num.ToString)    'nro
                item.SubItems.Add(txtDIIOGrupo.Text.Trim)
                lvGrupo2.Items.Add(item)
                txtDIIOGrupo.Text = ""
                lvGrupo2.Items(lvGrupo2.Items.Count - 1).Selected = True
                lvGrupo2.EnsureVisible(lvGrupo2.Items.Count - 1)

            Case 2
                num = lvGrupo3.Items.Count + 1
                Dim item As New ListViewItem(num.ToString)    'nro
                item.SubItems.Add(txtDIIOGrupo.Text.Trim)
                lvGrupo3.Items.Add(item)
                txtDIIOGrupo.Text = ""
                lvGrupo3.Items(lvGrupo3.Items.Count - 1).Selected = True
                lvGrupo3.EnsureVisible(lvGrupo3.Items.Count - 1)
        End Select
    End Sub

    Private Sub LimpiarDiioGrupo()
        Select Case tabGrupos.SelectedIndex
            Case 0
                lvGrupo1.Items.Clear()
            Case 1
                lvGrupo2.Items.Clear()
            Case 2
                lvGrupo3.Items.Clear()
        End Select
    End Sub

    Private Sub LeeBaston()
        frmBastonV2.Param1_CentroCod = CodigoCentroUsuario 'Centro Codigo Default
        frmBastonV2.Param2_CentroNom = NombreCentroUsuario 'Centro Nombre Default
        frmBastonV2.Param3_Formulario = "frmBusquedaMasiva"
        frmBastonV2.ShowDialog()

        If frmBastonV2.Procesa = True Then
            ProcesaBaston()
        End If

        frmBastonV2.Dispose()
        frmBastonV2 = Nothing
    End Sub
    Private Sub ProcesaBaston(Optional ByVal LimpiaDIIO As Boolean = False)
        Dim i As Integer = 0
        Dim diio_ As String = ""
        For i = 0 To frmBastonV2.lvBASTON.Items.Count - 1
            diio_ = frmBastonV2.lvBASTON.Items(i).SubItems(1).Text.Trim   'diio del baston
            Dim item As New ListViewItem((i + 1).ToString)    'nro
            item.SubItems.Add(diio_)
            Select Case tabGrupos.SelectedIndex
                Case 0
                    lvGrupo1.Items.Add(item)
                Case 1
                    lvGrupo2.Items.Add(item)
                Case 2
                    lvGrupo3.Items.Add(item)
            End Select
        Next
    End Sub

    Private Sub LeeBastonV3()
        dvcread = New frmLeerDispositivoV3 'frmBastonV2

        dvcread.ShowDialog()

        dvcread.Dispose()
        dvcread = Nothing
    End Sub


    Private Sub btnGrafico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTablero.Click
        Cursor.Current = Cursors.WaitCursor

        frmTableroGanado.MdiParent = Me
        frmTableroGanado.Show()
        frmTableroGanado.BringToFront()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub pboxEspaniol_Click(sender As Object, e As EventArgs) Handles pboxEspaniol.Click
        IdiomaSistema = 1   'español
        GrabarConfiguracionIdioma(IdiomaSistema)

        CargaMenuPrincipal(LoginUsuario, IdiomaSistema)

    End Sub

    Private Sub pboxIngles_Click(sender As Object, e As EventArgs) Handles pboxIngles.Click
        IdiomaSistema = 2   'ingles
        GrabarConfiguracionIdioma(IdiomaSistema)

        CargaMenuPrincipal(LoginUsuario, IdiomaSistema)
    End Sub

    Private Sub Actualizaciones_Click(sender As Object, e As EventArgs)
        frmActualizaciones.MdiParent = Me
        frmActualizaciones.Show()
        frmActualizaciones.BringToFront()
    End Sub

    Private Sub version_Tick(sender As Object, e As EventArgs) Handles version.Tick
        'If My.Computer.Network.IsAvailable = False Then
        '    version.Enabled = False
        '    If MsgBox("No tengo conexión a Internet", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Coneccion con internet") = MsgBoxResult.Ok Then
        '        Cursor.Current = Cursors.Default
        '    End If

        'End If
        'version.Enabled = False
        If ValidaUltimaVersion() = False Then
            If VerificaAviso() = False Then
                Dim msg As String
                msg = "Su versión de SGL no esta actualizada." & vbCrLf & "Favor, reingrese al sistema."
                Cursor.Current = Cursors.Default
                version.Enabled = False
                If MsgBox(msg, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Verificador Versión SGL") = MsgBoxResult.Ok Then
                    Cursor.Current = Cursors.Default
                    frmActualizaciones.Show()
                    frmActualizaciones.BringToFront()
                    frmActualizaciones.CerradoAutomatico()

                End If
            End If
        Else
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
    End Sub



    Private Sub frmMAIN_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub


    Private Sub btnCerrarSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarSesion.Click
        If VerificaCierre(2) = False Then Exit Sub
        CerrarSesionUsuario()
    End Sub

    Private Sub lblHideShowMenu_Click(sender As Object, e As EventArgs) Handles lblHideShowMenu.Click
        CambiaTamañoPanel()
    End Sub

    Private Sub btnPalpaciones_Click(sender As Object, e As EventArgs) Handles btnPalpaciones.Click
        frmPalpacionesIngreso.MdiParent = Me
        frmPalpacionesIngreso.Show()
        frmPalpacionesIngreso.BringToFront()
    End Sub

    Private Sub btnSecados_Click(sender As Object, e As EventArgs) Handles btnSecados.Click
        frmSecados.MdiParent = Me
        frmSecados.Show()
        frmSecados.BringToFront()
    End Sub

    Private Sub btnPartos_Click(sender As Object, e As EventArgs) Handles btnPartos.Click
        frmPartos.MdiParent = Me
        frmPartos.Show()
        frmPartos.BringToFront()
    End Sub

    Private Sub btnMuertes_Click(sender As Object, e As EventArgs) Handles btnMuertes.Click
        frmMuertes.MdiParent = Me
        frmMuertes.Show()
        frmMuertes.BringToFront()
    End Sub

    Private Sub btnTraslados_Click(sender As Object, e As EventArgs) Handles btnTraslados.Click
        frmTraslados.MdiParent = Me
        frmTraslados.Show()
        frmTraslados.BringToFront()
    End Sub

    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        frmVentas2.MdiParent = Me
        frmVentas2.Show()
        frmVentas2.BringToFront()
    End Sub
End Class





