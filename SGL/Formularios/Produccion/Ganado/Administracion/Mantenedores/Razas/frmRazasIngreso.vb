

Imports System.Data.SqlClient


Public Class frmRazasIngreso
    Public CodRaza As String

    Private Sub CboLlenaVS()
        cboVigente.Items.Clear()
        cboVigente.Items.Add("-Seleccionar-")
        cboVigente.Items.Add("SI")
        cboVigente.Items.Add("NO")
        cboVigente.SelectedIndex = 0

    End Sub


    Private Sub Cerrar()
        Cursor.Current = Cursors.WaitCursor
        'lvGanado.Items.Clear()
        Me.Close()
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Cerrar()
    End Sub


    Private Sub frmRazasIngreso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        If CodRaza <> "" Then
            txtCod.Text = CodRaza
            txtCod.Enabled = False
        Else
            CboLlenaVS()
        End If

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If CodRaza <> "" Then

            If MsgBox("¿ DESEA MODIFICAR LOS DATOS DE ESTA RAZA ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
            If ValidacionesMOD() = True Then

                GrabarRaza()
                Me.Close()
                Exit Sub
            Else
                MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
            End If

        End If

        If Validaciones() = True Then

                GrabarRaza()

                Me.Close()
        Else
            MsgBox("Debe completar todos los campos!!.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR")
        End If

    End Sub
    Private Sub GrabarRaza()
        Dim i As Integer = 0
        Dim n As Integer = 0
        Dim modif As Integer = 0
        If CodRaza <> "" Then
            modif = 1
        End If

        Cursor.Current = Cursors.WaitCursor
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spRazas_Grabar", con)
        Dim rdr As SqlDataReader = Nothing


        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)

        cmd.Parameters.AddWithValue("@mod", modif)
        cmd.Parameters.AddWithValue("@CodRaza", txtCod.Text)
        cmd.Parameters.AddWithValue("@NomRaza", txtNom.Text)
        cmd.Parameters.AddWithValue("@PesoRaza", txtPeso.Text)
        cmd.Parameters.AddWithValue("@Abrev", txtAbrev.Text)
        cmd.Parameters.AddWithValue("@Vigente", cboVigente.Text)

        '
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
                MsgBox("Raza ya existe", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
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
        Cursor.Current = Cursors.Default
    End Sub
    Private Function Validaciones() As Boolean
        Validaciones = False
        If txtCod.Text <> "" And txtNom.Text <> "" And
            cboVigente.SelectedIndex <> 0 And txtPeso.Text <> "" Then

            Validaciones = True
        Else
            Validaciones = False
        End If
    End Function
    Private Function ValidacionesMOD() As Boolean
        ValidacionesMOD = False
        If txtCod.Text <> "" And txtNom.Text <> "" And
            cboVigente.SelectedIndex <> 0 And txtPeso.Text <> "" Then

            ValidacionesMOD = True
        Else
            ValidacionesMOD = False
        End If
    End Function
End Class