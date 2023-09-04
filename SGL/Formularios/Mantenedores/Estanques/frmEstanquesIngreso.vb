Imports System.Data.SqlClient
Public Class frmEstanquesIngreso
    Public modificador As Integer = 0
    Public CodigoEstanque As String = ""
    Private Sub frmEstanquesIngreso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        CboLLenaCentros()
        CboLlenaVS()
        cboCentros.SelectedIndex = 0
        cboVigente.SelectedIndex = 0
    End Sub
    Private Sub CboLLenaCentros()
        If General.CentrosUsuario.NroRegistros = 0 Then Exit Sub

        cboCentros.Items.Clear()
        cboCentros.Items.Add("---Elegir Centro---")

        Dim i As Integer

        For i = 0 To General.CentrosUsuario.NroRegistros - 1
            cboCentros.Items.Add(General.CentrosUsuario.Nombre(i))
        Next


        'cboCentros.SelectedIndex = -1
    End Sub
    Private Sub CboLlenaVS()
        cboVigente.Items.Clear()
        cboVigente.Items.Add("-Seleccionar-")
        cboVigente.Items.Add("SI")
        cboVigente.Items.Add("NO")

    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click

        If Validaciones() = True Then

            If GrabarEstanque() = True Then
                Me.Close()
            End If

        Else
            MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
        End If
    End Sub
    Private Function GrabarEstanque() As Boolean
        Dim i As Integer = 0
        Dim n As Integer = 0
        GrabarEstanque = False
        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spEstanques_Grabar", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@CodigoEstanque", CodigoEstanque)
        cmd.Parameters.AddWithValue("@mod", modificador)
        cmd.Parameters.AddWithValue("@NumEstanque", txtNum.Text)
        cmd.Parameters.AddWithValue("@NomEstanque", txtNom.Text)
        cmd.Parameters.AddWithValue("@CapacidadEstanque", txtCapacidad.Text)
        cmd.Parameters.AddWithValue("@Marca", txtMarca.Text)
        cmd.Parameters.AddWithValue("@CodCentro", General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1))
        cmd.Parameters.AddWithValue("@Vigente", cboVigente.Text)

        Dim centro As String = General.CentrosUsuario.Codigo(cboCentros.SelectedIndex - 1)
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@Duplicado", SqlDbType.Int) : cmd.Parameters("@Duplicado").Direction = ParameterDirection.Output

        Try
            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Dim dup As Integer = cmd.Parameters("@Duplicado").Value

            If dup = "1" Then
                MsgBox("Estanque ya existe", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
                GrabarEstanque = False
                Exit Function
            End If

            ''verificamos error con un valor igual a -1
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
            Else
                MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try
        GrabarEstanque = True
        Cursor.Current = Cursors.Default
    End Function
    Private Function Validaciones() As Boolean
        Validaciones = False
        If txtNom.Text <> "" And txtNum.Text <> "" And txtMarca.Text <> "" And
            cboVigente.SelectedIndex <> 0 And txtCapacidad.Text <> "" And cboCentros.Text <> "---Elegir Centro---" Then

            Validaciones = True
        Else
            Validaciones = False
        End If
    End Function

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class