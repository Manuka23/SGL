

Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class frmFuncionarios

    Public Param1_Centro As String
    Public Param2_Fecha As DateTime
    Public Param3_Horario As Integer


    Private Sub FrmFuncionarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        frmIngresoDiario.Enabled = False
        dtpFecha.Value = Param2_Fecha
        Me.MdiParent = frmMAIN
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2) + 8

        BuscaFuncionarios()

        'General.centrospayroll.Cargar()

        Dim Detalles As New DataTable("CENTROSPAYROLL")
        Detalles.Columns.Add("codigo")
        Detalles.Columns.Add("descrip")

        For i = 0 To General.Centros.NroRegistros - 1
            Detalles.Rows.Add(General.Centros.Codigo(i), General.Centros.Nombre(i))
        Next

        Dim cbcentros As New DataGridViewComboBoxColumn
        cbcentros.Width = "200"
        cbcentros.DisplayMember = "descrip"
        cbcentros.ValueMember = "codigo"
        cbcentros.DataSource = Detalles
        cbcentros.HeaderText = "Centro de Destino"
        cbcentros.DisplayIndex = 2

        Me.dgvFncionarios.Columns.Add(cbcentros)
    End Sub
    Private Sub cambiarfecha()

    End Sub
    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        Param2_Fecha = dtpFecha.Value
    End Sub
    Private Sub BuscaFuncionarios()
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmd As New SqlCommand("spAsistencia_BuscarFuncionarios", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@Centro", Param1_Centro)
        cmd.Parameters.AddWithValue("@Fecha", Param2_Fecha)
        cmd.Parameters.AddWithValue("@Horario", Param3_Horario)
        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        con.Open()
        rdr = cmd.ExecuteReader()

        Dim i As Integer = 0

        dgvFncionarios.Rows.Clear()

        While rdr.Read()
            dgvFncionarios.Rows.Add(rdr("Rut"), rdr("Nombre"))
            i = i + 1
        End While

        rdr.Close()
        cmd.Dispose()
        con.Close()
    End Sub


    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmIngresoDiario.Enabled = True
        Me.Close()
    End Sub


    Private Function GrabarTraslado() As Boolean
        GrabarTraslado = False

        'Dim opcion As String = "i"
        Dim con As New SqlConnection(GetConnectionStringRRHH())
        Dim cmdI As New SqlCommand("spFuncionarios_Traslado", con)
        Dim rdrI As SqlDataReader = Nothing
        Dim SRVTRANS As SqlTransaction = Nothing
        ''
        Dim RUTFNC As String
        Dim NOMFNC As String
        ''
        Dim Result As Integer
        Dim vret As Integer
        Dim mret As String
        Dim HayError As Boolean = False

        'CONECTAMOS Y CREAMOS NUESRA TRANSACCION, PARA GRABAR REGISTROS DE LECHE
        Try
            con.Open()
            cmdI.CommandType = Data.CommandType.StoredProcedure
            SRVTRANS = con.BeginTransaction(Data.IsolationLevel.ReadUncommitted)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
            Cursor.Current = Cursors.Default
            Exit Function
        End Try
        For i = 0 To dgvFncionarios.Rows.Count - 2
            If Not dgvFncionarios.Rows(i).Cells(2).Value Is Nothing Then
                If dgvFncionarios.Rows(i).Cells(2).Value <> "" Then
                    RUTFNC = dgvFncionarios.Rows(i).Cells(0).Value.ToString.Trim
                    NOMFNC = dgvFncionarios.Rows(i).Cells(1).Value.ToString.Trim

                    cmdI.Parameters.Clear()
                    cmdI.Parameters.AddWithValue("@Rut", RUTFNC)
                    cmdI.Parameters.AddWithValue("@CentDestino", dgvFncionarios.Rows(i).Cells(2).Value)
                    cmdI.Parameters.AddWithValue("@Fecha", dtpFecha.Value)
                    cmdI.Parameters.AddWithValue("@Equipo", NombrePC)
                    cmdI.Parameters.AddWithValue("@Usuario", LoginUsuario)
                    '
                    cmdI.Parameters.Add("@RetValor", SqlDbType.Int) : cmdI.Parameters("@RetValor").Direction = ParameterDirection.Output
                    cmdI.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmdI.Parameters("@RetMensage").Direction = ParameterDirection.Output


                    Try
                        cmdI.Transaction = SRVTRANS
                        Result = cmdI.ExecuteNonQuery()

                        vret = cmdI.Parameters("@RetValor").Value
                        mret = cmdI.Parameters("@RetMensage").Value

                        If vret <> 0 Then
                            If MsgBox("FUNCIONARIO: " + NOMFNC + vbCrLf + vbCrLf + mret, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                            End If

                            HayError = True
                            Exit For
                        End If



                    Catch ex As Exception

                        HayError = True
                        MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "ERROR DE SISTEMA")
                        Exit For
                    End Try

                End If

            End If

        Next

        If HayError = False Then
            SRVTRANS.Commit()
            GrabarTraslado = True
        Else
            SRVTRANS.Rollback()
            GrabarTraslado = False
        End If

        con.Close()
        Cursor.Current = Cursors.Default

    End Function


    Private Sub btnSalir_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        frmIngresoDiario.Enabled = True
        Me.Close()
    End Sub


    Private Sub btnFinalizar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalizar.Click
        If GrabarTraslado() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                frmIngresoDiario.Enabled = True
                frmIngresoDiario.BuscarAsistenciaFuncionarios(IIf(frmIngresoDiario.rbtnAM.Checked = True, "AM", "PM"))
                Me.Close()
            End If
        End If
    End Sub


End Class