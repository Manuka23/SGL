Imports System.Data.SqlClient
Imports System.Threading
Public Class frmIngresoOrdenaTratamiento
    Public CodTratamiento As String
    Public Lote As String
    Dim Lieracion As Date
    Private Sub frmIngresoOrdenaTratamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        ConsultaGndVacunado()
        'dtpFech.Value = Lieracion
    End Sub

    Public Sub ConsultaGndVacunado()


        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_IngresoOrdena", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Cod", CodTratamiento)
        cmd.Parameters.AddWithValue("@lote", Lote)

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Fecha.Text = rdr("TratFecha")
                    Centro.Text = rdr("CentroNom")
                    Diio.Text = rdr("TratDiio")
                    patologia.Text = rdr("NomPatologia")
                    medicamento.Text = rdr("MedNombre")
                    cantidad.Text = rdr("TratDosis")
                    dias.Text = rdr("TratDuracionTrat")
                    Lieracion = rdr("FechaLeche")
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


    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim fecha As Date = dtpFech.Value
        If Lieracion > fecha Then
            If MsgBox("La fecha de ingreso a ordeña no puede ser menor a la fecha de liberacion de leche", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                dtpFech.Value = Lieracion
                Exit Sub
            End If

        End If

        If GrabarPabco() = True Then
            Me.Close()
            frmListadoTratamientos.btnBuscar.PerformClick()
        End If
    End Sub
    Private Function GrabarPabco() As Boolean
        GrabarPabco = False
        Dim i As Integer = 0
        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spTratamientos_CambiarIngreso", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Cod", CodTratamiento)
        cmd.Parameters.AddWithValue("@Fecha", dtpFech.Value)

        cmd.Parameters.AddWithValue("@lote", Lote)
        cmd.Parameters.AddWithValue("@TratEquipo", NombrePC)
        cmd.Parameters.AddWithValue("@TratUsuario", LoginUsuario)
        '
        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            If vret = -1 Then
                Cursor.Current = Cursors.Default

                If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                End If
                Exit Function
            End If
            MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
        Finally
            con.Close()
        End Try

        GrabarPabco = True
        Cursor.Current = Cursors.Default
    End Function


End Class