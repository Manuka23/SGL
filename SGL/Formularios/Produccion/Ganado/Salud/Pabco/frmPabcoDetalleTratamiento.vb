Imports System.Data.SqlClient


Public Class frmPabcoDetalleTratamiento
    Public DIIO As String
    Private Sub frmPabcoDetalleTratamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Left = ((frmMAIN.DisplayRectangle.Width - Me.Width - frmMAIN.pnlMenu.Width) / 2)
        Me.Top = ((frmMAIN.DisplayRectangle.Height - Me.Height - frmMAIN.pnlBarra.Height - 20) / 2)

        ConsultaTratamiento(DIIO)
    End Sub
    Public Sub ConsultaTratamiento(ByVal Diio As String)
        Dim con As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("spPabcoTratamiento_Detalle", con)
        Dim rdr As SqlDataReader = Nothing

        cmd.CommandType = Data.CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@Diio", Diio)

        Dim i As Integer = 0
        Dim vret As Integer = 0

        Try
            con.Open()
            rdr = cmd.ExecuteReader()

            Try
                While rdr.Read()
                    i = i + 1

                    lblDiio.Text = rdr("TratDiio")
                    lblFecha.Text = Format(rdr("TratFecha"), "dd/MM/yyyy")
                    lblDias.Text = rdr("TratDiasTratamiento")
                    lblPatologia.Text = rdr("NomPatologia")
                    lblMedicamento.Text = rdr("MedNombre")
                    lblDosis.Text = rdr("TratDosis")

                    If IsDBNull(rdr("TratUMedida")) Then
                        lblUMedida.Text = ""
                    Else
                        lblUMedida.Text = rdr("TratUMedida")
                    End If


                    lblObs.Text = rdr("TratObservacion")
                    lblLote.Text = rdr("TratLotes")
                    lblUsuario.Text = rdr("TratUsuario")
                    lblTermino.Text = Format(rdr("FechaTermino"), "dd/MM/yyyy")

                End While
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class