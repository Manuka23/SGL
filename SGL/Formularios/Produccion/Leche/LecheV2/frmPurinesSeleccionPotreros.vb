


Imports System.Data.SqlClient



Public Class frmPurinesSeleccionPotreros
    Public Param1_CentroCodigo As String
    Public Param2_CentroNombre As String
    Public Param3_CentroIsShareMilker As Boolean
    'Public Param3_Fecha As Date
    'Public Param4_TipoResp As String
    'Public Param5_NomResp As String
    'Public Param6_TipoRiego As String
    'Public Param7_Rut As String
    'Public Param8_Nombre As String


    Private Sub ListadoPotreros()
        Cursor.Current = Cursors.WaitCursor

        Try
            Dim con As New SqlConnection(GetConnectionString())
            Dim cmd As New SqlCommand("spPotreros_Listado", con)
            Dim rdr As SqlDataReader = Nothing

            cmd.CommandType = Data.CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Empresa", Empresa)
            cmd.Parameters.AddWithValue("@Centro", Param1_CentroCodigo)
            cmd.Parameters.AddWithValue("@Tipo", 0)
            cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
            cmd.Parameters.AddWithValue("@Equipo", NombrePC)

            con.Open()
            rdr = cmd.ExecuteReader()

            lvPOTREROS.Items.Clear()

            While rdr.Read()
                Dim item As New ListViewItem("")    'primera columna, para ordenar los datos
                item.SubItems.Add(rdr("PotreroCod").ToString.Trim)
                item.SubItems.Add(rdr("PotreroSuperficie").ToString.Trim)
                lvPOTREROS.Items.Add(item)

                'i = i + 1
            End While

            rdr.Close()
            cmd.Dispose()
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try

        Cursor.Current = Cursors.WaitCursor
    End Sub


    Private Sub BuscarArchivoMapa() 'Optional ByVal CargarMapa As Boolean = False)
        lblErrNomArchivo.Visible = False
        lblErrNomArchivo.Text = "No se encuentra el mapa para el predio seleccionado (" + txtCentro.Text + ")"

        If General.MapFile(Param1_CentroCodigo, WebBrowser) = False Then
            lblErrNomArchivo.Visible = True
        End If
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub frmPurinesSeleccionPotreros_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        General.Proveedores.Cargar()
        WebBrowser.Dock = DockStyle.Fill

        txtCentro.Text = Param2_CentroNombre
        dtpFecha.Value = Now
        cboRealizadoPor.SelectedIndex = -1
        cboNombres.SelectedIndex = -1
        cboTiposRiego.SelectedIndex = -1

        ListadoPotreros()
        BuscarArchivoMapa()
    End Sub

    Private Sub btnSeleccionar_Click(sender As System.Object, e As System.EventArgs) Handles btnSeleccionar.Click
        If cboRealizadoPor.Text <> "SIN RIEGO" Then

            If lvPOTREROS.CheckedItems.Count = 0 Then
                If MsgBox("DEBE SELECCIONAR AL MENOS --- UN POTRERO ---", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If

            If cboRealizadoPor.SelectedIndex = -1 Then
                If MsgBox("DEBE SELECCIONAR --- REALIZADO POR ---", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If

            If cboNombres.SelectedIndex = -1 Then
                If MsgBox("DEBE SELECCIONAR EL --- NOMBRE ---", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If

            If cboTiposRiego.SelectedIndex = -1 Then
                If MsgBox("DEBE SELECCIONAR EL --- TIPO DE RIEGO ---", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Sub
            End If


            Dim pot, sup As String
            Dim rut As String

            For Each itm As ListViewItem In lvPOTREROS.Items
                If itm.Checked Then
                    pot = itm.SubItems(1).Text      '= pots + IIf(pots = "", "", ",") + itm.SubItems(1).Text
                    sup = itm.SubItems(2).Text      'sups + Convert.ToDouble(itm.SubItems(2).Text)

                    If cboRealizadoPor.Text.Contains("INTERNO") Then
                        If Not Param3_CentroIsShareMilker Then
                            rut = BuscaCodigoFuncionario(cboNombres.Text)
                        Else
                            rut = "0"
                        End If

                    Else
                        rut = BuscaCodigoContratista(cboNombres.Text)
                    End If

                    frmIngresoDiario.dgvRiegoPurines.Rows.Add("", Format(dtpFecha.Value, "dd-MM-yyyy"), cboRealizadoPor.Text, cboNombres.Text, cboTiposRiego.Text, "", pot, sup, rut, cboNombres.Text)
                End If
            Next
        Else

            frmIngresoDiario.dgvRiegoPurines.Rows.Add("", Format(dtpFecha.Value, "dd-MM-yyyy"), cboRealizadoPor.Text, "", "", "0", "", "0", "", "")

        End If

        'If pots = "" Then Exit Sub

        'frmIngresoDiario.PotrerosSeleccionados = pots
        'frmIngresoDiario.PotrerosHectareas = sups

        Me.Close()
    End Sub


    Private Sub lvPOTREROS_ItemCheck(sender As System.Object, e As System.Windows.Forms.ItemCheckEventArgs) Handles lvPOTREROS.ItemCheck
        'lvPOTREROS.Enabled = False

        'For Each itm As ListViewItem In lvPOTREROS.Items
        '    itm.Checked = False
        'Next

        'lvPOTREROS.Enabled = True
    End Sub


    Private Sub cboRealizadoPor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboRealizadoPor.SelectedIndexChanged
        If cboRealizadoPor.SelectedIndex = -1 Then Exit Sub

        If cboRealizadoPor.Text.Contains("SIN RIEGO") Then
            cboNombres.SelectedIndex = -1
            cboNombres.Enabled = False
            cboTiposRiego.SelectedIndex = -1
            cboTiposRiego.Enabled = False
            lvPOTREROS.Enabled = False
            Exit Sub
        Else
            cboNombres.SelectedIndex = -1
            cboNombres.Enabled = True
            cboTiposRiego.SelectedIndex = -1
            cboTiposRiego.Enabled = True
            lvPOTREROS.Enabled = True
        End If

        If cboRealizadoPor.Text.Contains("INTERNO") Then
            If Not Param3_CentroIsShareMilker Then
                CboLLenaFuncionarios(cboNombres)
            Else
                cboNombres.Items.Clear()
                cboNombres.Items.Add("SHAREMILKER")
                cboNombres.SelectedIndex = 0
            End If
        Else
            CboLLenaContratistas(cboNombres)
        End If
    End Sub



    Private Sub CboLLenaContratistas(ByVal cbo As ComboBox)
        If General.Proveedores.NroRegistros = 0 Then Exit Sub

        cbo.Items.Clear()
        Dim i As Integer

        For i = 0 To General.Proveedores.NroRegistros - 1
            If General.Proveedores.EsContratista(i) = "SI" And General.Proveedores.Categoria(i).Contains("AGRICOLA") Then
                ' posicionselected = i
                cbo.Items.Add(General.Proveedores.Nombre(i))
            End If
        Next

        'cboCentros.Text = NombreCentroUsuario
    End Sub


    Private Sub CboLLenaFuncionarios(ByVal cbo As ComboBox)
        General.funcionarios.Cargar(Param1_CentroCodigo)
        If General.funcionarios.NroRegistros = 0 Then Exit Sub

        cbo.Items.Clear()
        Dim i As Integer

        For i = 0 To General.funcionarios.NroRegistros - 1
            cbo.Items.Add(General.funcionarios.Nombre(i))
        Next

        'cboCentros.Text = NombreCentroUsuario
    End Sub


End Class