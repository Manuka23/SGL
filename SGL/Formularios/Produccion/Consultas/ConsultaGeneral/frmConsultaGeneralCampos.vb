

Imports System.Data.SqlClient



Public Class frmConsultaGeneralCampos


    Private Sub CboLLenaPerfiles()
        If General.CGPerfiles.NroRegistros = 0 Then Exit Sub

        cboPerfilesColumnas.Items.Clear()

        'cboPerfilesColumnas.Items.Add("(OTROS)")

        Dim i As Integer

        For i = 0 To General.CGPerfiles.NroRegistros - 1
            cboPerfilesColumnas.Items.Add(General.CGPerfiles.Nombre(i))
        Next
    End Sub


    Private Function BuscaCodigoPerfil(ByVal perf_text As String) As Integer
        BuscaCodigoPerfil = 0

        Dim i As Integer
        Dim cod As Integer

        For i = 0 To General.CGPerfiles.Nombre.Length - 1

            If Not General.CGPerfiles.Nombre(i) Is Nothing Then
                If General.CGPerfiles.Nombre(i).Trim = perf_text Then
                    cod = General.CGPerfiles.Codigo(i)
                    Exit For
                End If
            End If
        Next

        BuscaCodigoPerfil = cod
    End Function


    Private Function GrabarPerfilColumnas() As Boolean
        GrabarPerfilColumnas = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCGPerfiles_Grabar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        Dim arrcols As String = ""
        Dim arranchos As String = ""
        Dim i As Integer

        ''
        For i = 0 To lvCOLPERFILES.Items.Count - 1
            arrcols = arrcols + lvCOLPERFILES.Items(i).SubItems(1).Text + ","
            arranchos = arranchos + lvCOLPERFILES.Items(i).SubItems(2).Text + ","
        Next
        ''
        'arrcols = arrcols.Substring(0, arrcols.Length - 1)
        'MsgBox(arrcols)
        Dim codperf_ As Integer = 0
        If cboPerfilesColumnas.Visible = True Then codperf_ = BuscaCodigoPerfil(cboPerfilesColumnas.Text)
        ''
        cmd.Parameters.AddWithValue("@Perfil", codperf_)
        cmd.Parameters.AddWithValue("@NombrePerfil", txtNombrePerfil.Text.Trim)
        cmd.Parameters.AddWithValue("@ArrayColumnas", arrcols)
        cmd.Parameters.AddWithValue("@ArrayAnchos", arranchos)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            GrabarPerfilColumnas = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function


    Private Function EliminarPerfil() As Boolean
        EliminarPerfil = False

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCGPerfiles_Eliminar", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Perfil", BuscaCodigoPerfil(cboPerfilesColumnas.Text))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value

            If vret > 0 Then
                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If

            EliminarPerfil = True

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        End Try
    End Function




    Private Sub Cerrar()
        General.CGPerfiles.Cargar()
        frmConsultaGeneral.CboLLenaPerfiles()
        frmConsultaGeneral.Enabled = True
        Me.Close()
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub



    Private Sub frmConsultaGeneralCampos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Me.KeyPreview = True

        CboLLenaPerfiles()
        LlenaCampos()

        If General.CGPerfiles.NroRegistros = 0 Then
            NuevoPerfil()
        Else
            SeleccionarPerfil()
            cboPerfilesColumnas.SelectedIndex = 0
        End If
    End Sub


    Private Sub NuevoPerfil()
        cboPerfilesColumnas.Enabled = False
        cboPerfilesColumnas.Visible = False
        txtNombrePerfil.Enabled = True
        'btnAgregarPerfil.Enabled = True
        'btnEliminarPerfil.Enabled = False
        txtNombrePerfil.Text = ""

        lvCOLPERFILES.Items.Clear()

        btnPerfil.Enabled = False
    End Sub


    Private Sub SeleccionarPerfil()
        txtNombrePerfil.Enabled = False
        cboPerfilesColumnas.Enabled = True
        cboPerfilesColumnas.Visible = True
        btnPerfil.Enabled = True

        'cboPerfilesColumnas.SelectedIndex = 0
    End Sub


    Private Sub CancelarNuevoPerfil()
        cboPerfilesColumnas.Enabled = True
        cboPerfilesColumnas.Visible = True
        txtNombrePerfil.Enabled = False
        'btnAgregarPerfil.Enabled = True
        'btnEliminarPerfil.Enabled = False

        'lvCOLPERFILES.Items.Clear()

        btnPerfil.Enabled = True

        cboPerfilesColumnas.SelectedIndex = 0
    End Sub


    Private Sub LlenaCampos()
        Dim i As Integer = 0
        Dim items As New List(Of ListViewItem)

        For i = 0 To UBound(frmConsultaGeneral.PColNombres) 'frmConsultaGeneral.lvGanado.Columns.Count - 1

            Dim lvitem As New ListViewItem(i.ToString)

            lvitem.SubItems.Add(frmConsultaGeneral.PColNombres(i)) '.lvGanado.Columns(i).Text)
            lvitem.SubItems.Add(frmConsultaGeneral.PColAnchos(i)) '.lvGanado.Columns(i).Width.ToString)

            items.Add(lvitem)

        Next


        'Dim items As New List(Of ListViewItem)


        'Dim item As New ListViewItem("1") : item.SubItems.Add("Empresa") : items.Add(item)
        'Dim item1 As New ListViewItem("2") : item1.SubItems.Add("Centro") : items.Add(item1)
        'Dim item2 As New ListViewItem("3") : item2.SubItems.Add("DIIO") : items.Add(item2)
        'Dim item3 As New ListViewItem("4") : item3.SubItems.Add("Categoria") : items.Add(item3)
        'Dim item4 As New ListViewItem("5") : item4.SubItems.Add("Fecha Nac.") : items.Add(item4)
        'Dim item5 As New ListViewItem("6") : item5.SubItems.Add("Raza") : items.Add(item5)
        'Dim item6 As New ListViewItem("7") : item6.SubItems.Add("Estado") : items.Add(item6)
        'Dim item7 As New ListViewItem("8") : item7.SubItems.Add("F. Estado") : items.Add(item7)
        'Dim item8 As New ListViewItem("9") : item8.SubItems.Add("Est. Productivo") : items.Add(item8)
        'Dim item9 As New ListViewItem("10") : item9.SubItems.Add("Est. Reproductivo") : items.Add(item9)
        'Dim item10 As New ListViewItem("11") : item10.SubItems.Add("Dias Lac.") : items.Add(item10)
        'Dim item11 As New ListViewItem("12") : item11.SubItems.Add("Fecha Sec.") : items.Add(item11)
        'Dim item12 As New ListViewItem("13") : item12.SubItems.Add("Prod. Cod.") : items.Add(item12)
        'Dim item13 As New ListViewItem("14") : item13.SubItems.Add("F. Pri. Parto") : items.Add(item13)
        'Dim item14 As New ListViewItem("15") : item14.SubItems.Add("F. Ult. Parto") : items.Add(item14)
        'Dim item15 As New ListViewItem("16") : item15.SubItems.Add("F. Prob. Parto") : items.Add(item15)
        'Dim item16 As New ListViewItem("17") : item16.SubItems.Add("Nro. Partos") : items.Add(item16)
        'Dim item17 As New ListViewItem("18") : item17.SubItems.Add("F. Ult. Cub.") : items.Add(item17)
        'Dim item18 As New ListViewItem("19") : item18.SubItems.Add("Nro. Cubtas.") : items.Add(item18)
        'Dim item19 As New ListViewItem("20") : item19.SubItems.Add("Toro") : items.Add(item19)
        'Dim item20 As New ListViewItem("21") : item20.SubItems.Add("Padre") : items.Add(item20)
        'Dim item21 As New ListViewItem("22") : item21.SubItems.Add("Madre") : items.Add(item21)
        ''Dim item22 As New ListViewItem("23") : item.SubItems.Add("Empresa") : items.Add(item)
        ''Dim item23 As New ListViewItem("24") : item.SubItems.Add("Empresa") : items.Add(item)



        lvCOLUMNAS.Items.AddRange(items.ToArray())
    End Sub



    Private Sub lvCOLUMNAS_DoubleClick(sender As Object, e As System.EventArgs) Handles lvCOLUMNAS.DoubleClick
        AgregarColumnaPerfil()
    End Sub



    Private Sub btnAC_Click(sender As System.Object, e As System.EventArgs) Handles btnAC.Click
        AgregarColumnaPErfil()
    End Sub



    Private Sub AgregarColumnaPerfil()
        If lvCOLUMNAS.SelectedItems.Count = 0 Then Exit Sub

        Dim nomcol_ As String = lvCOLUMNAS.SelectedItems(0).SubItems(1).Text
        Dim anchocol_ As String = lvCOLUMNAS.SelectedItems(0).SubItems(2).Text
        Dim i As Integer = 0
        Dim existe_ As Boolean = False

        For i = 0 To lvCOLPERFILES.Items.Count - 1
            If lvCOLPERFILES.Items(i).SubItems(1).Text = nomcol_ Then
                existe_ = True
                Exit For
            End If
        Next

        If existe_ Then
            MsgBox("LA COLUMNA (" + nomcol_ + ") YA EXISTE", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If

        Dim num_ As Integer = lvCOLPERFILES.Items.Count + 1
        Dim item As New ListViewItem(num_)

        item.SubItems.Add(nomcol_)
        item.SubItems.Add(anchocol_)
        lvCOLPERFILES.Items.Add(item)
    End Sub


    Private Sub btnEC_Click(sender As System.Object, e As System.EventArgs) Handles btnEC.Click
        EliminarColumnaPerfil()
    End Sub


    Private Sub EliminarColumnaPerfil()

        If lvCOLPERFILES.SelectedItems.Count = 0 Then Exit Sub

        'If MsgBox("¿ ELIMINAR COLUMNA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
        '    Exit Sub
        'End If

        lvCOLPERFILES.SelectedItems(0).Remove()

    End Sub

    Private Sub EliminarPerfilExistente()

        If cboPerfilesColumnas.Items.Count = 0 Then Exit Sub

        If MsgBox("¿ DESEA ELIMINAR EL PERFIL SELECCIONADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If EliminarPerfil() = True Then
            cboPerfilesColumnas.Items.Remove(cboPerfilesColumnas.Text)

            lvCOLPERFILES.Items.Clear()

            If cboPerfilesColumnas.Items.Count = 0 Then

            Else
                cboPerfilesColumnas.SelectedIndex = 0
            End If

        End If




    End Sub


    Private Sub btnPerfil_Click(sender As System.Object, e As System.EventArgs) Handles btnPerfil.Click
        If cboPerfilesColumnas.Visible = True Then
            NuevoPerfil()
        Else
            SeleccionarPerfil()
        End If

    End Sub


    Private Sub btnEliminarPerfil_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarPerfil.Click
        'si el combo con los perfiles de columnas es visible, entonces procedemos
        'a eliminar el perfil
        '
        'si el control visible es el ingreso de un perfil nuevo, entonces
        'cancelamos el ingreso, y dejamos visible el combo con los perfiles
        '
        If cboPerfilesColumnas.Visible = True Then
            EliminarPerfilExistente()
        Else
            CancelarNuevoPerfil()
        End If
    End Sub


    Private Sub btnAgregarPerfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarPerfil.Click
        If cboPerfilesColumnas.Visible = False And txtNombrePerfil.Text.Trim = "" Then Exit Sub

        If GrabarPerfilColumnas() = True Then
            MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Question + MsgBoxStyle.OkOnly)

            General.CGPerfiles.Cargar()
            CboLLenaPerfiles()

            If General.CGPerfiles.NroRegistros = 0 Then
                NuevoPerfil()
            Else
                SeleccionarPerfil()
                cboPerfilesColumnas.SelectedIndex = cboPerfilesColumnas.Items.Count - 1
            End If
        End If
    End Sub


    Private Sub cboPerfilesColumnas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPerfilesColumnas.SelectedIndexChanged
        BuscarColumnasPerfil()
    End Sub


    Private Sub BuscarColumnasPerfil()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spCGPerfiles_BuscarColumnas", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Codigo", General.CGPerfiles.Codigo(cboPerfilesColumnas.SelectedIndex))
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvCOLPERFILES.BeginUpdate()
        lvCOLPERFILES.Items.Clear()

        Dim i As Integer = 0
        'Dim madre_, estado_, fcub_, fpp_, fsec_ As String
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim item As New ListViewItem(rdr("PColPosicion").ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("PColNombreColumna").ToString.Trim)
                    item.SubItems.Add(rdr("PColAncho").ToString.Trim)

                    lvCOLPERFILES.Items.Add(item)

                    i = i + 1
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
        lvCOLPERFILES.EndUpdate()

    End Sub


End Class