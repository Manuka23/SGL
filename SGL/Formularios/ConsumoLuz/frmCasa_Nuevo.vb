Imports System.Data.SqlClient

Public Class frmCasa_Nuevo
    Private Sub frmCasa_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMAIN
        Me.Top = 135
        Me.Left = 25
        frmCasa.Enabled = False
        'tbxCasa.Text = frmCasa.lvCasas.SelectedItems.Item(0).SubItems(2).Text
        CbxLLenaCentros()
        CbxLLenaResponsable()
        CbxLLenaPoblacion()
        CbxLLenaRelacion()
        CbxLLenaClasificacion()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmCasa.Enabled = True
        Me.Close()
    End Sub


    Private Sub CbxLLenaCentros()
        If General.Centros.NroRegistros = 0 Then Exit Sub
        cbxCentros.Items.Clear()
        'cboCentros.Items.Add("(TODOS)")
        Dim i As Integer
        For i = 0 To General.Centros.NroRegistros - 1
            cbxCentros.Items.Add(General.Centros.Nombre(i))
        Next
    End Sub
    Private Sub CbxLLenaResponsable()
        cbxResponsable.Items.Clear()
        Empleados.Listado()
        cbxResponsable.Items.Add("")
        cbxResponsable.SelectedIndex = 0
        For i = 0 To Empleados.NroRegistros - 1
            cbxResponsable.Items.Add(Empleados.Nombre(i))
        Next
    End Sub

    Private Sub CbxLLenaPoblacion()
        cbxPoblacion.Items.Clear()
        Poblacion.Listado()
        For i = 0 To Poblacion.NroRegistros - 1
            cbxPoblacion.Items.Add(Poblacion.Nombre(i))
        Next
    End Sub
    Private Sub CbxLLenaClasificacion()
        cbxClasificacion.Items.Clear()
        Clasificacion.Listado()
        For i = 0 To Clasificacion.NroRegistros - 1
            cbxClasificacion.Items.Add(Clasificacion.Nombre(i))
        Next
    End Sub
    Private Sub CbxLLenaRelacion()
        cbxRelacion.Items.Clear()
        Relacion.Listado()
        For i = 0 To Relacion.NroRegistros - 1
            cbxRelacion.Items.Add(Relacion.Nombre(i))
        Next
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Cursor.Current = Cursors.WaitCursor
        If ValidacionesLocales() Then
            Dim Cent = General.Centros.Codigo(cbxCentros.SelectedIndex)
            Dim Resp = ""

            If cbxResponsable.SelectedIndex > 0 Then
                Resp = Empleados.Cod(cbxResponsable.SelectedIndex)
            End If
            Dim Pobl = Poblacion.Cod(cbxPoblacion.SelectedIndex)
            Dim Rela = Relacion.Cod(cbxRelacion.SelectedIndex)
            Dim Clas = Clasificacion.Cod(cbxClasificacion.SelectedIndex)
            If Guardar(Cent, tbxCasa.Text, tbxMedidor.Text, tbxSitio.Text, Resp, Pobl, Rela, Clas) Then
                frmCasa.Close()
                frmCasa.Show()
                Me.Close()
            End If
        End If
        Cursor.Current = Cursors.Default


    End Sub

    Private Function ValidacionesLocales() As Boolean
        ValidacionesLocales = False
        If String.IsNullOrWhiteSpace(tbxCasa.Text) Then
            If MsgBox("DEBE ESCRIBIR EL Nº DE CASA", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            tbxCasa.Focus()
            Exit Function
        End If
        If String.IsNullOrWhiteSpace(tbxSitio.Text) Then
            If MsgBox("DEBE ESCRIBIR EL Nº DE SITIO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            tbxSitio.Focus()
            Exit Function
        End If
        If String.IsNullOrWhiteSpace(tbxMedidor.Text) Then
            If MsgBox("DEBE ESCRIBIR EL Nº DE MEDIDOR", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            tbxMedidor.Focus()
            Exit Function
        End If
        If cbxCentros.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UN CENTRO", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cbxCentros.Focus()
            Exit Function
        End If
        If cbxRelacion.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UNA RELACION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cbxRelacion.Focus()
            Exit Function
        End If
        If cbxPoblacion.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UNA POBLACION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cbxPoblacion.Focus()
            Exit Function
        End If
        If cbxClasificacion.SelectedIndex = -1 Then
            If MsgBox("DEBE SELECCIONAR UNA CLASIFICACION", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
            End If
            cbxClasificacion.Focus()
            Exit Function
        End If


        ValidacionesLocales = True
    End Function

    Private Function Guardar(ByVal _CodCentro As String, ByVal _CodCasa As String, ByVal _CodMedidor As String, ByVal _CodSitio As String, ByVal _CodResponsable As String, ByVal _CodProblacion As String, ByVal _CodRelacion As String, ByVal _CodClasificacion As String)
        Guardar = False
        Dim FechaHoy = DateTime.Now
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("[spLuz_CasaAgregar]", con)
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@CasCod", _CodCasa)
        cmd.Parameters.AddWithValue("@CasSitio", _CodCasa)
        cmd.Parameters.AddWithValue("@CasCodMedidor", _CodMedidor)
        cmd.Parameters.AddWithValue("@CasCodResponsable", _CodResponsable)
        cmd.Parameters.AddWithValue("@CasCodCentro", _CodCentro)
        cmd.Parameters.AddWithValue("@CasCodClasificacion", _CodClasificacion)
        cmd.Parameters.AddWithValue("@CasCodPoblacion", _CodProblacion)
        cmd.Parameters.AddWithValue("@CasCodRelacion", _CodRelacion)
        cmd.Parameters.Add("@Text", SqlDbType.VarChar).Size = 500 : cmd.Parameters("@Text").Direction = ParameterDirection.Output

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            Guardar = True
            MsgBox(cmd.Parameters("@Text").Value, MsgBoxStyle.Information + MsgBoxStyle.OkOnly)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
    End Function

End Class