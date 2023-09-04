Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Public Class frmMuestraLeche
    Private Proveedor As String = ""
    Private Horario As String = ""
    Dim TipoMuestra As String
    Dim fnMuestraLechePndResultado As New fnMuestraLechePndResultado
    Dim muestreo As String
    Private CodEstanque As String
    Private CodCentro As String
    Private Const RET_COL_CLIENTECOD = 15
    Private Sub frmMuestraLeche_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Fecha.Value = DateTime.Now
        General.Proveedores.Cargar()
        cbollenaProveedores()
        ' ConsultaEstanque()
        DetalleMuestra()
        rbtazul.Checked = True
        rbCCalidad.Checked = True
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rbCCalidad.CheckedChanged
        If rbCCalidad.Checked = True Then
            muestreo = "C. Calidad"
        End If
    End Sub

    Private Sub rbSala_CheckedChanged(sender As Object, e As EventArgs) Handles rbSala.CheckedChanged
        If rbSala.Checked = True Then
            muestreo = "Sala"
        End If
    End Sub
    Public Sub DetalleMuestra()
        'lista_usuarios.Clear()
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_ListaPndEnvio", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure
        dgvRetiroLeche.SuspendLayout()

        Dim i As Integer = 0
        Dim ea As Integer = 0
        Dim vret As Integer = 0
        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    Dim prove As String
                    If rdr("ProvCodMuestreo") = 1 Then
                        prove = "Interno"
                    Else
                        prove = "Externo"
                    End If
                    dgvRetiroLeche.Rows.Add(rdr("CodBarraMuestra"), rdr("CentroCod"), rdr("EstanqueCod"), rdr("ProvCodMuestreo"), rdr("Centro"), rdr("Estanque"), Format(rdr("FechaMuestra"), "yyyy-mm-dd"), prove, rdr("ProvNomMuestreo"), rdr("MuestraHorario"))

                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

        dgvRetiroLeche.ResumeLayout()
    End Sub
    Private Sub cbollenaProveedores()
        If General.Proveedores.NroRegistros = 0 Then Exit Sub

        cboProveedores.Items.Clear()

        Dim i As Integer

        For i = 0 To General.Proveedores.NroRegistros - 1
            If General.Proveedores.Codigo(i) = "823926006" Then
                cboProveedores.Items.Add(General.Proveedores.Nombre(i))
            End If
        Next
        cboProveedores.Text = -1
    End Sub
    Public Sub llenaGrilla()
        dgvRetiroLeche.SuspendLayout()

        dgvRetiroLeche.Rows.Add(txtDIIO.Text, CodCentro, CodEstanque, General.Proveedores.Codigo(cboProveedores.SelectedIndex), lblCentro.Text, lblEstanque.Text, Fecha.Value, Proveedor, General.Proveedores.Nombre(cboProveedores.SelectedIndex), Horario)
        dgvRetiroLeche.ResumeLayout()
    End Sub
    Private Sub txtDIIO_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDIIO.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If Horario = "" Or Proveedor = "" Then
                MsgBox("RELLENE DEMAS CAMPOS ANTES DE LEER ETIQUETAS", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                'txtDIIO.Text = ""
                txtDIIO.Focus()
                Exit Sub
            End If
            For i = 0 To dgvRetiroLeche.Rows.Count - 1
                If dgvRetiroLeche.Rows(i).Cells(0).Value = txtDIIO.Text Then
                    MsgBox("CODIGO YA INGRESADO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                    Exit Sub
                End If
            Next

            If ValidaCampos() = True Then
                If ConsultaEstanque() = True Then
                    llenaGrilla()
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                Else
                    txtDIIO.Text = ""
                    txtDIIO.Focus()
                    Exit Sub
                End If

            End If
            bloquear()
        End If
    End Sub
    Public Sub bloquear()
        Interno.Enabled = False
        Externo.Enabled = False
        AM.Enabled = False
        PM.Enabled = False
        cboProveedores.Enabled = False
        Fecha.Enabled = False
        rbtazul.Enabled = False
        rbtrojo.Enabled = False
    End Sub
    Private Function ValidaCampos() As Boolean
        ValidaCampos = False
        If Proveedor = "" Or Horario = "" Then
            ValidaCampos = False
        End If
        ValidaCampos = True
    End Function
    Private Sub Interno_CheckedChanged(sender As Object, e As EventArgs) Handles Interno.CheckedChanged
        If Interno.Checked = True Then
            Proveedor = Interno.Text
            cboProveedores.SelectedIndex = 0
            cboProveedores.Enabled = False
        End If
    End Sub

    Private Sub Externo_CheckedChanged(sender As Object, e As EventArgs) Handles Externo.CheckedChanged
        If Externo.Checked = True Then
            Proveedor = Externo.Text
            cboProveedores.Enabled = False

        End If
    End Sub
    Private Sub preliminar_CheckedChanged(sender As Object, e As EventArgs) Handles AM.CheckedChanged
        If AM.Checked = True Then
            Horario = AM.Text
        End If
    End Sub

    Private Sub quincenal_CheckedChanged(sender As Object, e As EventArgs) Handles PM.CheckedChanged
        If PM.Checked = True Then
            Horario = PM.Text
        End If
    End Sub
    Public Function ConsultaEstanque() As Boolean
        ConsultaEstanque = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spEstanques_ConsultaEstanque", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)

        cmd.Parameters.AddWithValue("@LectorCod", txtDIIO.Text)
        cmd.Parameters.AddWithValue("@MuesFecha", Fecha.Value)
        cmd.Parameters.AddWithValue("@TipoMuestra", TipoMuestra)
        cmd.Parameters.AddWithValue("@MuesCodProveedores", General.Proveedores.Codigo(cboProveedores.SelectedIndex))
        cmd.Parameters.AddWithValue("@MuesHorario", Horario)

        cmd.Parameters.AddWithValue("@Usuario", LoginUsuario)
        cmd.Parameters.AddWithValue("@Equipo", NombrePC)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output

        Try
            con.Open()
            Dim Result As Integer = cmd.ExecuteNonQuery()

            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            rdr = cmd.ExecuteReader()
            Try
                While rdr.Read()

                    CodCentro = rdr("centrocod").ToString.Trim()
                    CodEstanque = rdr("estanquecod").ToString.Trim()
                    lblCentro.Text = rdr("centronombre").ToString.Trim()
                    lblEstanque.Text = rdr("nombre").ToString.Trim()
                    lblNum.Text = rdr("numero").ToString.Trim()
                End While
                If vret <> 0 Then
                    If MsgBox(mret, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION") = vbOK Then
                    End If
                    ConsultaEstanque = False
                    Exit Function
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        ConsultaEstanque = True
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


    Private Sub GrabarMuestraLeche()
        Dim NomProvee As String = General.Proveedores.Nombre(cboProveedores.SelectedIndex)
        Dim CodProvee As String = General.Proveedores.Codigo(cboProveedores.SelectedIndex)
        fnMuestraLechePndResultado.GrabarPndEnvio(dgvRetiroLeche, NomProvee, CodProvee, Horario, Fecha.Value, muestreo, TipoMuestra)
    End Sub

    Private Sub btnFinalizar_Click_1(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If MsgBox("¿ DESEA GRABAR MUESTRAS DE LECHE PARA ENVIO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        If dgvRetiroLeche.RowCount = 0 Then
            If MsgBox("NESESITA INGRESAR DATOS EN LA TABLA PARA PODER FINALIZAR", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                Exit Sub
            End If
        End If

        If ValidaDatos() = True Then
            If MsgBox("DATOS GRABADOS --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                GrabarMuestraLeche()
                Me.Close()
            End If
        End If

    End Sub
    Private Function ValidaDatos() As Boolean
        ValidaDatos = False


        ValidaDatos = True
    End Function

    Private Sub dgvRetiroLeche_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvRetiroLeche.RowsRemoved
        'dgvRetiroLeche.SelectedRows.Item(e)

        ' dgvRetiroLeche.Rows(i).Cells(0).Value
        If dgvRetiroLeche.RowCount = 0 Then
            Interno.Enabled = True
            Externo.Enabled = True
            AM.Enabled = True
            PM.Enabled = True
            cboProveedores.Enabled = True
            Fecha.Enabled = True
        End If
    End Sub

    Private Sub txtDIIO_TextChanged(sender As Object, e As EventArgs) Handles txtDIIO.TextChanged

    End Sub

    Private Sub rbtrojo_CheckedChanged(sender As Object, e As EventArgs) Handles rbtrojo.CheckedChanged
        If rbtrojo.Checked = True Then
            TipoMuestra = "UFC(Rojo)"
        End If
    End Sub
    Private Sub rbtazul_CheckedChanged_1(sender As Object, e As EventArgs) Handles rbtazul.CheckedChanged
        If rbtazul.Checked = True Then
            TipoMuestra = "RCS(Azul)"
        End If
    End Sub
End Class