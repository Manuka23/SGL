
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows.Forms

Public Class frmMuestraLechePrint


    Private Sub frmMuestraLechePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)
        'PrintForm1.PrintAction = Printing.PrintAction.PrintToPrinter
        'PrintForm1.Print()

        imprimir()
    End Sub
    Private Sub imprimir()
        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.ClientAreaOnly)
    End Sub
    Public Sub impresion(ByVal ListView As ListView, ByVal Folio As String)
        For i = 0 To ListView.Items.Count - 1
            Dim item As New ListViewItem(i + 1)    'primera columna, para ordenar los datos
            item.SubItems.Add(ListView.Items(i).SubItems(1).Text)
            item.SubItems.Add(ListView.Items(i).SubItems(2).Text)
            item.SubItems.Add(ListView.Items(i).SubItems(6).Text)
            item.SubItems.Add(ListView.Items(i).SubItems(4).Text)
            item.SubItems.Add(ListView.Items(i).SubItems(5).Text)
            lvGanado.Items.Add(item)
        Next
        ConsultaLoteEnvio(Folio)
    End Sub
    Public Function ConsultaLoteEnvio(ByVal Folio As String) As Boolean
        ConsultaLoteEnvio = False
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spMuestraLeche_ConsultaResultados", con)
        Dim rdr As SqlDataReader = Nothing
        Dim Existe As Boolean = False
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Empresa", Empresa)
        cmd.Parameters.AddWithValue("@LectorCod", Folio)
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
            Dim i As Integer = 0
            lvGanado.BeginUpdate()
            Try
                While rdr.Read()
                    lblCant.Text = rdr("NroMuestras").ToString.Trim()
                    lblUsuario.Text = rdr("UsuarioEnvioReal").ToString.Trim()
                    lblFecha.Text = Date.Parse(rdr("FechaEnvioReal"))
                    txtFolio.Text = rdr("LoteEnvio").ToString.Trim()
                End While
                lvGanado.EndUpdate()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
        ConsultaLoteEnvio = True
    End Function


End Class
