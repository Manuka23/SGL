Imports System.Data.SqlClient
Imports System.IO


Public Class frmMuestraLecheEnvio
    Dim datosConsolidados As String
    Dim PathArchivo As String
    Public CodEnvio As String
    Dim TipoMuestra As String
    Private FileBcoChileOK As Integer = 0
    Dim fnMuestraLechePndResultado As New fnMuestraLechePndResultado
    Dim OrdenarColumnasLV As New ListViewOrdenarColumnas

    Private Sub lvRESUMEN1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvGanado.ColumnClick
        OrdenarColumnasLV.OrdenarColumnas(lvGanado, e)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Public Function ConsultarPndEnvio() As Boolean
        ConsultarPndEnvio = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_ConsultaPndEnvio", con)
        Dim rdr As SqlDataReader = Nothing
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandTimeout = 60 ' 5 minutos
        cmd.Parameters.AddWithValue("@TipoMuestra", TipoMuestra)
        cmd.Parameters.AddWithValue("@CodLector", txtLector.Text)

        cmd.Parameters.Add("@RetValor", SqlDbType.Int) : cmd.Parameters("@RetValor").Direction = ParameterDirection.Output
        cmd.Parameters.Add("@RetMensage", SqlDbType.VarChar).Size = 255 : cmd.Parameters("@RetMensage").Direction = ParameterDirection.Output
        Try

            con.Open()

            Dim Result As Integer = cmd.ExecuteNonQuery()
            rdr = cmd.ExecuteReader()
            Dim i As Integer = 0
            Dim vret As Integer = cmd.Parameters("@RetValor").Value
            Dim mret As String = cmd.Parameters("@RetMensage").Value
            Try
                lvGanado.BeginUpdate()
                While rdr.Read()
                    i = i + 1

                    Dim item As New ListViewItem((lvGanado.Items.Count + 1).ToString.Trim)    'primera columna, para ordenar los datos
                    item.SubItems.Add(rdr("CentroNom").trim.ToString)
                    item.SubItems.Add(rdr("EstanqueNom").trim.ToString)
                    item.SubItems.Add(rdr("FechaMuestra"))
                    item.SubItems.Add("Externo")
                    item.SubItems.Add(rdr("ProvNomMuestreo").trim.ToString)
                    item.SubItems.Add(rdr("MuestraHorario").trim.ToString)
                    item.SubItems.Add(rdr("CodBarraMuestra").trim.ToString)
                    item.SubItems.Add(rdr("EstanqueCod").trim.ToString)
                    item.SubItems.Add(rdr("TipoMuestra").trim.ToString)
                    lvGanado.Items.Add(item)
                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            ConsultarPndEnvio = True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "MANUKA SGL - Error sql")
        Finally
            con.Close()
        End Try
        lvGanado.EndUpdate()
    End Function

    Private Sub frmMuestraLecheEnvio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
    End Sub
    Private Sub txtLector_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLector.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            For i = 0 To lvGanado.Items.Count - 1
                If lvGanado.Items(i).SubItems(7).Text.Trim = txtLector.Text And lvGanado.Items(i).SubItems(9).Text.Trim = TipoMuestra Then
                    MsgBox("CODIGO YA INGRESADO", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    txtLector.Text = ""
                    txtLector.Focus()
                    Exit Sub
                End If
            Next
            ConsultarPndEnvio()
            txtLector.Text = ""
            txtLector.Focus()
            If lvGanado.Items.Count > 0 Then
                rbrcs.Enabled = False
                rbufc.Enabled = False
            Else
                rbrcs.Enabled = True
                rbufc.Enabled = True
            End If


        End If
    End Sub

    Private Sub btnFinalizar_Click(sender As Object, e As EventArgs) Handles btnFinalizar.Click
        If lvGanado.Items.Count = 0 Then
            MsgBox("PARA GRABAR ENVIO TIENE QUE INGRESAR LECTURAS ", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "ADVERTENCIA")
            Exit Sub
        Else
            fnMuestraLechePndResultado.Grabar(lvGanado)
            DatosTxt()
            txtLector.Text = ""
            lvGanado.Items.Clear()
        End If

    End Sub

    Private Sub txtLector_TextChanged(sender As Object, e As EventArgs) Handles txtLector.TextChanged

    End Sub


    Private Sub DatosTxt()
        ''AQUI SE GENERA LOS DATOS QUE SERAN ENVIADOS AL TXT
        Cursor.Current = Cursors.WaitCursor

        PathArchivo = ""
        PathArchivo = "C:\APPS\Nominas Generadas\" & CodEnvio & ".txt" ' Se determina el nombre del archivo con la fecha actual

        GeneraArchivoTXT()

        If MsgBox("¿ DESEA ENVIAR TXT POR CORREO ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "CONFIRMACION") = MsgBoxResult.Yes Then
            Dim Outl As Object
            Outl = CreateObject("Outlook.Application")
            If Outl IsNot Nothing Then
                Dim omsg As Object
                Dim archivo As String = CodEnvio
                omsg = Outl.CreateItem(0)
                omsg.To = "yusuf@hotmail.com"
                omsg.bcc = "yusuf@gmail.com"
                omsg.subject = "Hello"
                omsg.body = "godmorning"
                omsg.Attachments.Add("C:\APPS\Nominas Generadas\" & archivo & ".txt")
                'set message properties here...'
                omsg.Display(True) 'will display message to user
            End If
        Else
            Exit Sub
        End If
        ''--------------------------------------------------------------------------------------
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub BtnTxt_Click(sender As Object, e As EventArgs) Handles BtnTxt.Click
        DatosTxt()
    End Sub
    Private Sub GeneraArchivoTXT()
        For i = 0 To lvGanado.Items.Count - 1
            datosConsolidados = datosConsolidados + lvGanado.Items(i).SubItems(7).Text.Trim + vbNewLine
        Next
        Dim strStreamW As Stream = Nothing
        Dim strStreamWriter As StreamWriter = Nothing
        Try

            If Directory.Exists("C:\APPS\Nominas Generadas") = False Then ' si no existe la carpeta se crea
                Directory.CreateDirectory("C:\APPS\Nominas Generadas")
            End If
            'verificamos si existe el archivo. Como es la primera vez, no deberia existir. Si existe, se debe borrar
            If Not File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.OpenOrCreate, FileAccess.Write) 'Lo creamos y se abre
            Else
                File.Delete(PathArchivo) ' lo borramos y lo volvemos a generar.
                strStreamW = File.Open(PathArchivo, FileMode.OpenOrCreate, FileAccess.Write)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default) ' tipo de codificacion para escritura
            strStreamWriter.WriteLine(datosConsolidados)
            '
            MsgBox("Archivo generado con exito." & vbCrLf & "Ruta de acceso: " & vbCrLf & PathArchivo, MsgBoxStyle.Information)
            FileBcoChileOK = 1
            Shell("explorer.exe root = C:\APPS\Nominas Generadas", vbNormalFocus)
            strStreamWriter.Close() ' cerramos
        Catch ex As Exception
            MsgBox("Error al Guardar la informacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, System.Windows.Forms.Application.ProductName)
            strStreamWriter.Close() ' cerramos
        End Try
        btnImprime.Enabled = True
    End Sub

    Private Sub EnviarCorreo()
        Dim Outl As Object
        Outl = CreateObject("Outlook.Application")
        If Outl IsNot Nothing Then
            Dim omsg As Object
            Dim archivo As String = CodEnvio
            omsg = Outl.CreateItem(0)
            omsg.To = "yusuf@hotmail.com"
            omsg.bcc = "yusuf@gmail.com"
            omsg.subject = "Hello"
            omsg.body = "godmorning"
            omsg.Attachments.Add("C:\APPS\Nominas Generadas\" & archivo & ".txt")
            'set message properties here...'
            omsg.Display(True) 'will display message to user
        End If
    End Sub

    Private Sub btnImprime_Click(sender As Object, e As EventArgs) Handles btnImprime.Click
        frmMuestraLechePrint.impresion(lvGanado, CodEnvio)
        frmMuestraLechePrint.Show()
        frmMuestraLechePrint.BringToFront()
    End Sub

    Private Sub rbrcs_CheckedChanged(sender As Object, e As EventArgs) Handles rbrcs.CheckedChanged
        If rbrcs.Checked Then
            TipoMuestra = "RCS(Azul)"
        End If
    End Sub

    Private Sub rbufc_CheckedChanged(sender As Object, e As EventArgs) Handles rbufc.CheckedChanged
        If rbufc.Checked Then
            TipoMuestra = "UFC(Rojo)"
        End If
    End Sub
End Class