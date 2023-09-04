Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Imports System.Data.SqlClient
Public Class frmSilosConfeccionInterna
    Dim cen As Integer = 0
    Dim Rendimiento As Double
    Private fnGrabarSilos As New fnGrabarSilos
    Private Sub frmSilosConfeccionInterna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLLenaCentros()
        cboBolo.Items.Clear()
        cboCentros.Text = CentroPorDefecto()
        General.Potreros.Cargar(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        CboLLenaPotreros()
        cen = 1

        General.TipoBolo.Cargar(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))

        CboLLenaBolos()
        If PerfilUsuario <> 999 Then
            valorbolo.Enabled = False
            valorbolo.Text = "0"
            total.Text = "0"
        End If
    End Sub


    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next

        'cboCentros.SelectedIndex = 0
    End Sub
    Private Sub CboLLenaPotreros()
        If General.Potreros.NroRegistros = 0 Then
            cboPotrero.Items.Clear()
            cboPotrero.Items.Add("Sin Informar")
            cboPotrero.SelectedIndex = 0
            Exit Sub
        End If

        cboPotrero.Items.Clear()
        cboPotrero.Items.Add("Sin Informar")

        Dim i As Integer

        For i = 0 To General.Potreros.NroRegistros - 1
            cboPotrero.Items.Add(General.Potreros.Nombre(i))
        Next

        cboPotrero.SelectedIndex = 0
    End Sub
    Private Sub CboLLenaBolos()
        cboBolo.Items.Clear()
        If General.TipoBolo.NroRegistros = 0 Then Exit Sub

        Dim i As Integer

        For i = 0 To General.TipoBolo.NroRegistros - 1
            cboBolo.Items.Add(General.TipoBolo.Nombre(i))
        Next

        cboBolo.SelectedIndex = 0
    End Sub

    Private Sub cboCentros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCentros.SelectedIndexChanged

        General.Potreros.Cargar(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))

        CboLLenaPotreros()

        General.TipoBolo.Cargar(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        CboLLenaBolos()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPotrero.SelectedIndexChanged
        If cen = 1 Then
            If cboPotrero.SelectedIndex <> 0 Then
                lblPotrero.Text = General.Potreros.Superficie(cboPotrero.SelectedIndex - 1)
                Hectareas.Text = lblPotrero.Text
            Else
                lblPotrero.Text = 0
            End If
        End If
        Reiniciar()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        frmSilos.btnBuscar.PerformClick()
    End Sub


    Private Sub Hectareas_LostFocus(sender As Object, e As EventArgs) Handles Hectareas.LostFocus
        If Cant.Text <> "" And Hectareas.Text <> "" Then
            Rendimiento = Cant.Text / Hectareas.Text
            Rendimi.Text = Format(Rendimiento, "##,##0.00")
        End If
        If lblPotrero.Text <> 0 Then
            Dim hect As Double = Hectareas.Text
            Dim pot As Double = lblPotrero.Text
            If hect > pot Then
                MsgBox("La cantidad de hectareas no puede ser superior a las hectareas del potrero", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Hectareas.Text = lblPotrero.Text
            End If
        End If

    End Sub
    Private Sub Cant_LostFocus(sender As Object, e As EventArgs) Handles Cant.LostFocus
        If Cant.Text <> "" And Hectareas.Text <> "" Then
            Rendimiento = Cant.Text / Hectareas.Text
            Rendimi.Text = Format(Rendimiento, "##,##0.00")
        End If
        If PerfilUsuario = 999 Then

            If Cant.Text <> "" And valorbolo.Text <> "" And Cant.Text <> "0" And valorbolo.Text <> "0" Then
                total.Text = Format(Cant.Text * valorbolo.Text, "#,#")
            End If

        End If
    End Sub
    Private Sub valorbolo_TextChanged(sender As Object, e As EventArgs) Handles valorbolo.TextChanged
        If Cant.Text <> "" And valorbolo.Text <> "" And Cant.Text <> "0" And valorbolo.Text <> "0" Then
            total.Text = Format(Cant.Text * valorbolo.Text, "#,#")
        End If

    End Sub

    Private Sub valorbolo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles valorbolo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            valorbolo.Text = valorbolo.Text.Trim
            e.Handled = True
            agregar()
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) And (UCase(e.KeyChar) <> ",") Then
            e.Handled = True
        End If
    End Sub
    Private Sub Cant_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cant.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Cant.Text = Cant.Text.Trim
            e.Handled = True
            Hectareas.Focus()
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        End If
    End Sub
    Private Sub total_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles total.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            total.Text = total.Text.Trim
            e.Handled = True
        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) And (UCase(e.KeyChar) <> ",") Then
            e.Handled = True
        End If
    End Sub
    Private Sub Hectareas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Hectareas.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Hectareas.Text = Hectareas.Text.Trim
            e.Handled = True
            If consultaEnsilaje() = True Then
                agregar()
            End If

        End If

        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And (Asc(e.KeyChar) <> 8) And (UCase(e.KeyChar) <> ",") Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If consultaEnsilaje() = True Then
            agregar()
        End If

    End Sub
    Private Function consultaEnsilaje() As Boolean
        consultaEnsilaje = True
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPraderas_ConsultaEnsilaje", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
        cmd.Parameters.AddWithValue("@Centro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        If cboPotrero.SelectedIndex = 0 Then
            cmd.Parameters.AddWithValue("@Potrero", "Sin Informar")
        Else
            cmd.Parameters.AddWithValue("@Potrero", General.Potreros.Codigo(cboPotrero.SelectedIndex - 1))
        End If

        cmd.Parameters.AddWithValue("@CodEnsilaje", General.TipoBolo.Codigo(cboBolo.SelectedIndex))

        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value


            ''verificamos error con un valor igual a -1
            If vret = 2 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    consultaEnsilaje = False
                End If
            Else
                consultaEnsilaje = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        Cursor.Current = Cursors.Default
    End Function

    Private Sub agregar()

        If Cant.Text = "" Or Hectareas.Text = "" Or valorbolo.Text = "" Then
            MsgBox("Debe ingresar todos los datos", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If Cant.Text = "0" Or Hectareas.Text = "0" Then
            MsgBox("No puede ingresar datos 0 ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        For i = 0 To lvBolos.Items.Count - 1
            If cboPotrero.Text = "Sin Informar" Then
                If cboPotrero.Text = "Sin Informar" And lvBolos.Items(i).SubItems(2).Text = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex) And lvBolos.Items(i).SubItems(9).Text = General.TipoBolo.Codigo(cboBolo.SelectedIndex) Then
                    If MsgBox("NO PUEDE INGRESAR 2 VECES EL MISMO POTRERO CON LOS MISMOS DATOS ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        Exit Sub
                    End If
                End If
            Else
                If lvBolos.Items(i).SubItems(3).Text = General.Potreros.Codigo(cboPotrero.SelectedIndex - 1) And lvBolos.Items(i).SubItems(2).Text = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex) And lvBolos.Items(i).SubItems(9).Text = General.TipoBolo.Codigo(cboBolo.SelectedIndex) Then
                    If MsgBox("NO PUEDE INGRESAR 2 VECES EL MISMO POTRERO CON LOS MISMOS DATOS ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                        Exit Sub
                    End If
                End If
            End If

        Next
        dtpFecha.Enabled = False

        llenadoLv()
        Reiniciar()

    End Sub
    Private Sub Reiniciar()
        Cant.Text = ""
        ' Hectareas.Text = ""
        Rendimi.Text = ""
        ' valorbolo.Text = ""
        total.Text = "0"
        'lblPotrero.Text = 0
    End Sub
    Private Sub llenadoLv()

        Dim valorxbolo As Integer
        valorxbolo = valorbolo.Text
        Dim itm As New ListViewItem((lvBolos.Items.Count + 1).ToString)
        itm.SubItems.Add(General.CentrosUsuario.Nombre(cboCentros.SelectedIndex))
        itm.SubItems.Add(General.CentrosUsuario.Codigo(cboCentros.SelectedIndex))
        If cboPotrero.SelectedIndex = 0 Then
            itm.SubItems.Add("Sin Informar")
        Else
            itm.SubItems.Add(General.Potreros.Codigo(cboPotrero.SelectedIndex - 1))
        End If

        itm.SubItems.Add(Cant.Text)
        itm.SubItems.Add(Hectareas.Text)
        itm.SubItems.Add(Rendimi.Text)
        If valorxbolo = 0 Then
            itm.SubItems.Add("0")
        Else
            itm.SubItems.Add(Format(valorxbolo, "#,#"))
        End If
        If total.Text = "0" Then
            itm.SubItems.Add("0")
        Else
            itm.SubItems.Add(total.Text)
        End If
        itm.SubItems.Add(General.TipoBolo.Codigo(cboBolo.SelectedIndex))
        itm.SubItems.Add(General.TipoBolo.Nombre(cboBolo.SelectedIndex))
        itm.SubItems.Add(General.TipoBolo.UniMedida(cboBolo.SelectedIndex))
        itm.SubItems.Add(lblPotrero.Text)
        lvBolos.Items.Add(itm)
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If lvBolos.Items.Count.ToString = 0 Then
            If MsgBox("DEBE INGRESAR AL MENOS 1 REGISTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                Exit Sub
            End If
        End If
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        GrabarSilos()
        lvBolos.Items.Clear()
        Me.Close()
        frmSilos.btnBuscar.PerformClick()

    End Sub
    Private Function GrabarSilos() As Boolean
        If fnGrabarSilos.GrabaSilos(lvBolos, dtpFecha.Value) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿ DESEA ELIMINAR EL REGISTRO SELECCIONADO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        For Each it As ListViewItem In lvBolos.SelectedItems
            lvBolos.Items.Remove(it)
            If lvBolos.Items.Count = 0 Then
                dtpFecha.Enabled = True
            End If

        Next

    End Sub

    Private Sub cboBolo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBolo.SelectedIndexChanged
        lblMedida.Text = General.TipoBolo.UniMedida(cboBolo.SelectedIndex)
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged

    End Sub

    Private Sub lvBolos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvBolos.SelectedIndexChanged

    End Sub
End Class