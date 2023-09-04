

Imports System.Data.SqlClient



Public Class frmContraMuestras

    'Public Param0_ModoIngreso As Integer           '1 = nuevo  /  2 = consulta partos
    Public Param1_CodigoCentro As String
    Public Param2_NombreCentro As String
    Public Param3_FechaMuestreo As DateTime
    Public Param4_TipoMuestreo As Integer
    Public Param5_DIIO As Integer
    ''
    Public Param6_TBC As Boolean
    Public Param7_LEU As Boolean
    Public Param8_BRU As Boolean



    Private Function Muestreo(ByVal muestreo_ As Integer) As String
        Muestreo = ""

        Select Case muestreo_
            Case 1
                Muestreo = "TUBERCULOSIS"
            Case 2
                Muestreo = "LEUCOSIS"
            Case 3
                Muestreo = "BRUCELOSIS"
        End Select
    End Function


    Private Function VerificaResultadoMuestreo(ByVal result_ As Integer) As String
        VerificaResultadoMuestreo = ""

        If result_ = 1 Then
            VerificaResultadoMuestreo = "POSITIVO"
        End If

        If result_ = 2 Then
            VerificaResultadoMuestreo = "NEGATIVO"
        End If

    End Function



    Public Sub BuscarDetalle()
        'If cboCentros.Text.Trim = "" Then Exit Sub

        Cursor.Current = Cursors.WaitCursor

        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestreos_ListadoContraMuestras", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure


        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_CodigoCentro)
        cmd.Parameters.AddWithValue("@Fecha", Param3_FechaMuestreo)
        cmd.Parameters.AddWithValue("@TipoMuestreo", Param4_TipoMuestreo)
        cmd.Parameters.AddWithValue("@DIIO", Param5_DIIO)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        lvCONTRAMUESTRAS.BeginUpdate()
        lvCONTRAMUESTRAS.Items.Clear()

        lblCont.Text = "0"

        Dim i As Integer = 0
        Dim crias As Integer = 0
        Dim hembras As Integer = 0
        Dim sexadas As Integer = 0
        Dim tot_crias As Integer = 0
        Dim tot_hembras As Integer = 0
        Dim tot_sexadas As Integer = 0
        Dim tot_err As Integer = 0
        Dim save_diio As String = ""
        Dim pos_ As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()

                    Dim item As New ListViewItem((i + 1).ToString.Trim)    'primera columna, para ordenar los datos
                    ''
                    item.SubItems.Add(Format(rdr("FechaContraMuestra"), "dd-MM-yyyy"))
                    item.SubItems.Add(Muestreo(rdr("ContraMuestra")))
                    item.SubItems.Add(VerificaResultadoMuestreo(rdr("ResultadoContraMuestra").ToString.Trim))
                    ''
                    lvCONTRAMUESTRAS.Items.Add(item)
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        lvCONTRAMUESTRAS.EndUpdate()

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        With frmContraMuestrasIngreso
            .Param1_CodigoCentro = Param1_CodigoCentro
            .Param2_NombreCentro = Param2_NombreCentro
            .Param3_FechaMuestreo = Param3_FechaMuestreo
            .Param4_TipoMuestreo = Param4_TipoMuestreo
            .Param5_DIIO = Param5_DIIO

            .cboTiposMuestras.Items.Clear()

            If Param6_TBC = True Then .cboTiposMuestras.Items.Add("TUBERCULOSIS")
            If Param7_LEU = True Then .cboTiposMuestras.Items.Add("LEUCOSIS")
            If Param8_BRU = True Then .cboTiposMuestras.Items.Add("BRUCELOSIS")

            .ShowDialog()
        End With
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Private Sub frmContraMuestras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height + 50) / 2)
        Me.Left = Me.Left + (frmMAIN.pnlMenu.Width / 2)

        txtDIIO.Text = Param5_DIIO

        BuscarDetalle()
    End Sub

End Class