Imports System.Data.SqlClient
Public Class frmMuestraLecheIngresoManual
    Private Proveedor As String = ""
    Private Horario As String = ""
    Private Const RC = 2
    Private Const Gras = 3
    Private Const Protein = 4
    Private Const Ure = 5
    Private Const Den = 6
    Private Const Crios = 7
    Private Const UF = 8
    Private Const Solid = 9
    Private CodEstanque As String
    Dim muestreo As String
    Private fnMuestraManual As New fnMuestraManual

    Private Sub frmMuestraLecheIngresoManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.CentrosUsuarioEstanque.Cargar()
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        Fecha.Value = DateTime.Now
        General.Proveedores.Cargar()
        cbollenaProveedores()
        CboLlenaEstanques()
        cboProveedores.SelectedIndex = 0
        AM.Checked = True
        Interno.Checked = True
        rbCCalidad.Checked = True
    End Sub
    Private Sub dgvPOTREROS_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCalidadLeche.EditingControlShowing

        Dim col As Integer = dgvCalidadLeche.CurrentCell.ColumnIndex

        ' If col = CantidadHa Or col = ValoxBolo Then

        AddHandler CType(e.Control, TextBox).KeyPress, AddressOf ValidaTxtRetiro
        '  End If

    End Sub
    Private Sub ValidaTxtRetiro(ByVal sendere As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim columna As Integer = dgvCalidadLeche.CurrentCell.ColumnIndex

        '  If columna = ValoxBolo Then ' 2a 9
        If Not Char.IsNumber(e.KeyChar) And (e.KeyChar = ChrW(Keys.Back)) = False And Not (e.KeyChar = ",") Then
            e.KeyChar = Chr(0)
        End If
        ' End If


    End Sub
    Private Sub dgvCalidadLeche_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCalidadLeche.CellValueChanged
        Dim n As Integer = dgvCalidadLeche.RowCount
        For i = 0 To dgvCalidadLeche.Rows.Count - 1
            For x = 0 To n - 1

                Dim r As String = dgvCalidadLeche.Rows(i).Cells(2).Value
                If r = "" Then
                    dgvCalidadLeche.Rows(i).Cells(2).Value = 0
                End If
                Dim g As String = dgvCalidadLeche.Rows(i).Cells(3).Value
                If g = "" Then
                    dgvCalidadLeche.Rows(i).Cells(3).Value = 0
                End If
                Dim p As String = dgvCalidadLeche.Rows(i).Cells(4).Value
                If p = "" Then
                    dgvCalidadLeche.Rows(i).Cells(4).Value = 0
                End If
                Dim ur As String = dgvCalidadLeche.Rows(i).Cells(5).Value
                If ur = "" Then
                    dgvCalidadLeche.Rows(i).Cells(5).Value = 0
                End If
                Dim de As String = dgvCalidadLeche.Rows(i).Cells(6).Value
                If de = "" Then
                    dgvCalidadLeche.Rows(i).Cells(6).Value = 0
                End If
                Dim cr As String = dgvCalidadLeche.Rows(i).Cells(7).Value
                If cr = "" Then
                    dgvCalidadLeche.Rows(i).Cells(7).Value = 0
                End If
                Dim u As String = dgvCalidadLeche.Rows(i).Cells(8).Value
                If u = "" Then
                    dgvCalidadLeche.Rows(i).Cells(8).Value = 0
                End If
                Dim s As String = dgvCalidadLeche.Rows(i).Cells(9).Value
                If s = "" Then
                    dgvCalidadLeche.Rows(i).Cells(9).Value = 0
                End If

                Dim Grasa As Double = dgvCalidadLeche.Rows(i).Cells(3).Value
                Dim Proteina As Double = dgvCalidadLeche.Rows(i).Cells(4).Value
                Dim Msolida As Double = Grasa + Proteina
                dgvCalidadLeche.Rows(i).Cells(9).Value = Msolida

            Next
        Next
    End Sub


    Private Sub CboLlenaEstanques(Optional ByVal centroNomCbo As Boolean = False)
        If General.CentrosUsuarioEstanque.NroRegistros = 0 Then Exit Sub

        cboEstanques.Items.Clear()
        'cboEstanques.Items.Add("(TODOS)")

        Dim i As Integer

        For i = 0 To General.CentrosUsuarioEstanque.NroRegistros - 1
            If General.CentrosUsuarioEstanque.CentroTipo(i) = "SALA" And General.CentrosUsuarioEstanque.CentroVig(i) = "SI" And General.CentrosUsuarioEstanque.EstanqueCOD(i) <> "" Then
                cboEstanques.Items.Add(General.CentrosUsuarioEstanque.EstanqueNOM(i))
            End If
        Next
        cboEstanques.SelectedIndex = 0
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
            cboProveedores.SelectedIndex = 1
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
    Private Sub dgvRetiroLeche_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvCalidadLeche.RowsRemoved
        If dgvCalidadLeche.RowCount = 0 Then
            Interno.Enabled = True
            Externo.Enabled = True
            AM.Enabled = True
            PM.Enabled = True
            cboProveedores.Enabled = True
            Fecha.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        For i = 0 To dgvCalidadLeche.Rows.Count - 1

            If dgvCalidadLeche.Rows(i).Cells(1).Value = General.CentrosUsuarioEstanque.EstanqueCOD(cboEstanques.SelectedIndex) Then
                MsgBox("ESTANQUE YA INGRESADO ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
                Exit Sub
            End If
        Next
        dgvCalidadLeche.Rows.Add(General.CentrosUsuarioEstanque.EstanqueNOM(cboEstanques.SelectedIndex), General.CentrosUsuarioEstanque.EstanqueCOD(cboEstanques.SelectedIndex), 0, 0, 0, 0, 0, 0, 0, 0)
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If dgvCalidadLeche.Rows.Count = 0 Then
            MsgBox("DEBE INGRESAR ALGUN DATO EN LA TABLA ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ERROR DE VALIDACION")
            Exit Sub
        End If
        If MsgBox("¿ DESEA GRABAR LA INFORMACIÓN ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        'fnMuestraManual.DtExcelCrear()
        'For i = 0 To dgvCalidadLeche.Rows.Count - 1
        '    Dim RCS As Integer = dgvCalidadLeche.Rows(i).Cells(2).Value
        '    Dim Grasa As Double = dgvCalidadLeche.Rows(i).Cells(3).Value
        '    Dim Proteina As Double = dgvCalidadLeche.Rows(i).Cells(4).Value
        '    Dim Urea As Double = dgvCalidadLeche.Rows(i).Cells(5).Value
        '    Dim Densidad As Double = dgvCalidadLeche.Rows(i).Cells(6).Value
        '    Dim Crioscopia As Double = dgvCalidadLeche.Rows(i).Cells(7).Value
        '    Dim UFS As Double = dgvCalidadLeche.Rows(i).Cells(8).Value
        '    Dim MSolida As Double = dgvCalidadLeche.Rows(i).Cells(9).Value

        '    fnMuestraManual.DtExcel(i + 1, dgvCalidadLeche.Rows(i).Cells(1).Value, dgvCalidadLeche.Rows(i).Cells(0).Value, RCS, Grasa, Proteina, Proteina, Urea, Densidad, UFS, MSolida)
        'Next

        'Dim NomProvee As String = General.Proveedores.Nombre(cboProveedores.SelectedIndex)
        'Dim CodProvee As String = General.Proveedores.Codigo(cboProveedores.SelectedIndex)

        'If GrabarMuestraManual(NomProvee, CodProvee) = True Then
        '    MsgBox("Datos Grabados --- OK ---", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        '    Me.Close()
        'End If
        'fnMuestraManual.VaciaDatatable()


        GrabarMuestraLeche()
        Me.Close()
    End Sub
    Private Sub GrabarMuestraLeche()
        Dim NomProvee As String = General.Proveedores.Nombre(cboProveedores.SelectedIndex)
        Dim CodProvee As String = General.Proveedores.Codigo(cboProveedores.SelectedIndex)
        fnMuestraManual.GrabarMuestraManual(dgvCalidadLeche, NomProvee, CodProvee, Horario, Fecha.Value, FechaRes.Value, muestreo)
    End Sub

    Private Sub GroupBox7_Enter(sender As Object, e As EventArgs) Handles GroupBox7.Enter

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
End Class