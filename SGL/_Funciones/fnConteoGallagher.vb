
Imports NDAgroComm
'Imports System.Xml.Linq
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Management
Imports System.IO
Imports System.IO.Ports
Imports System.Text.RegularExpressions
Public Class fnConteoGallagher
    Public MyReader As NDAgroComm.IEIDReaders
    Public contI As Integer = 1
    Dim repetidos As Integer = 0
    Public Sub ProcesarSesionesAgrident(ByVal Pantalla As String, ByVal com As String)
        Dim tabla As DataTable = New DataTable("datos")
        tabla = MyReader.GetSessions()

        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)
            Return
        End If
        Dim cont As Integer = 0

        If Pantalla = "Bastoneo" Then
            For Each row As DataRow In tabla.Rows
                Dim itm As New ListViewItem()
                itm.Checked = False
                itm.SubItems.Add(row("SessionName").ToString())
                itm.SubItems.Add("")
                itm.SubItems.Add(row("SessionCountAnimals").ToString())
                itm.SubItems.Add(row("SessionID").ToString())
                itm.SubItems.Add(cont)
                frmBastonV2Conteo.lvXRS_SESIONES.Items.Add(itm)

                cont = cont + 1
            Next
        Else
            For Each row As DataRow In tabla.Rows
                Dim itm As New ListViewItem()
                itm.Checked = False
                itm.SubItems.Add(row("SessionName").ToString())
                itm.SubItems.Add("")
                itm.SubItems.Add(row("SessionCountAnimals").ToString())
                itm.SubItems.Add(row("SessionID").ToString())
                itm.SubItems.Add(cont)
                frmBastonV2.lvXRS_SESIONES.Items.Add(itm)

                cont = cont + 1
            Next
        End If
        If Pantalla = "Conteo" Then
            Dim nom As String = frmBastonV2.lvXRS_SESIONES.Items(0).SubItems(1).Text
            Dim nom1 As String = frmBastonV2.lvXRS_SESIONES.Items(0).SubItems(4).Text

            MyReader = New NDAgroComm.EIDAgridentReader
            MyReader.ReadTimeOut = 800
            MyReader.ReceivedDataSleep = 160
            MyReader.EIDStartPosition = 7
            MyReader.EIDEndPosition = 0
            MyReader.HideEmptySessions = True

            MyReader.BeginDataTransfer(com, 9600)
            If (MyReader.GetResponseCode <> 200) Then
                MessageBox.Show(MyReader.GetResponseMessage)
                Return
            End If
            frmBastonV2.conexion = "Agrident"

            Dim num As Integer
            num = frmBastonV2.lvXRS_SESIONES.Items.Count.ToString 'Format(CDate(row("AnimalDate")), "yyyy-MM-dd"))
            For i = 0 To num - 1
                frmBastonV2.lvXRS_SESIONES.Items(i).SubItems(2).Text = Format(CDate(Fecha(frmBastonV2.lvXRS_SESIONES.Items(i).SubItems(1).Text, frmBastonV2.lvXRS_SESIONES.Items(i).SubItems(4).Text)), "yyyy-MM-dd")
            Next
        Else
            Dim nom As String = frmBastonV2Conteo.lvXRS_SESIONES.Items(0).SubItems(1).Text
            Dim nom1 As String = frmBastonV2Conteo.lvXRS_SESIONES.Items(0).SubItems(4).Text

            MyReader = New NDAgroComm.EIDAgridentReader
            MyReader.ReadTimeOut = 800
            MyReader.ReceivedDataSleep = 160
            MyReader.EIDStartPosition = 7
            MyReader.EIDEndPosition = 0
            MyReader.HideEmptySessions = True

            MyReader.BeginDataTransfer(com, 9600)
            If (MyReader.GetResponseCode <> 200) Then
                MessageBox.Show(MyReader.GetResponseMessage)
                Return
            End If
            frmBastonV2Conteo.conexion = "Agrident"

            Dim num As Integer
            num = frmBastonV2Conteo.lvXRS_SESIONES.Items.Count.ToString 'Format(CDate("AnimalDate"), "yyyy-MM-dd"))
            For i = 0 To num - 1
                frmBastonV2Conteo.lvXRS_SESIONES.Items(i).SubItems(2).Text = Format(CDate(Fecha(frmBastonV2Conteo.lvXRS_SESIONES.Items(i).SubItems(1).Text, frmBastonV2Conteo.lvXRS_SESIONES.Items(i).SubItems(4).Text)), "yyyy-MM-dd")
            Next
        End If

    End Sub
    Public Function Fecha(ByVal SesionNom As String, ByVal SesionID As String) As String
        Fecha = ""
        Dim tabla As DataTable = New DataTable("datos")
        tabla = MyReader.GetAnimals(SesionID, SesionNom)

        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)

        End If
        For Each row As DataRow In tabla.Rows
            If row("AnimalEID").ToString() <> "" Then

                Fecha = row("AnimalDate").ToString
                Exit For
            End If
        Next
        Return Fecha
    End Function
    Public Sub ProcesarSesionesGallagher(ByVal Pantalla As String)
        Dim tabla As DataTable = New DataTable("datos")
        tabla = MyReader.GetSessions()

        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)
            Return
        End If
        Dim cont As Integer = 0

        If Pantalla = "Bastoneo" Then
            For Each row As DataRow In tabla.Rows
                Dim itm As New ListViewItem()
                itm.Checked = False
                itm.SubItems.Add(row("SessionName").ToString())
                itm.SubItems.Add(Format(CDate(row("SessionDate")), "dd/MM/yyyy"))
                itm.SubItems.Add(row("SessionCountAnimals").ToString())
                itm.SubItems.Add(row("SessionID").ToString())
                itm.SubItems.Add(cont)
                frmBastonV2Conteo.lvXRS_SESIONES.Items.Add(itm)

                cont = cont + 1
            Next

        Else
            For Each row As DataRow In tabla.Rows
                Dim itm As New ListViewItem()
                itm.Checked = False
                itm.SubItems.Add(row("SessionName").ToString())
                itm.SubItems.Add(Format(CDate(row("SessionDate")), "dd/MM/yyyy"))
                itm.SubItems.Add(row("SessionCountAnimals").ToString())
                itm.SubItems.Add(row("SessionID").ToString())
                itm.SubItems.Add(cont)
                frmBastonV2.lvXRS_SESIONES.Items.Add(itm)
                cont = cont + 1
            Next

        End If


    End Sub
    Public Sub ProcesarDiiosAgrident(ByVal e As Integer, ByVal com As String, ByVal Pantalla As String)

        Dim id_sesion As String
        Dim NDiios As String
        Dim nbarra As Integer = 0
        Dim nom_sesion As String
        If Pantalla = "Bastoneo" Then
            If (frmBastonV2Conteo.lvXRS_SESIONES.CheckedItems.Count = 0) Then
                Return
            End If
            NDiios = frmBastonV2Conteo.lvXRS_SESIONES.Items(e).SubItems(3).Text
            id_sesion = frmBastonV2Conteo.lvXRS_SESIONES.Items(e).SubItems(4).Text
            nom_sesion = frmBastonV2Conteo.lvXRS_SESIONES.Items(e).SubItems(1).Text
        Else
            If (frmBastonV2.lvXRS_SESIONES.CheckedItems.Count = 0) Then
                Return
            End If
            NDiios = frmBastonV2.lvXRS_SESIONES.Items(e).SubItems(3).Text
            id_sesion = frmBastonV2.lvXRS_SESIONES.Items(e).SubItems(4).Text
            nom_sesion = frmBastonV2.lvXRS_SESIONES.Items(e).SubItems(1).Text
        End If


        Dim tabla As DataTable = New DataTable("datos")
        tabla = MyReader.GetAnimals(id_sesion, nom_sesion)

        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)
            Return
        End If

        Dim cont As Integer = 1

        If Pantalla = "Bastoneo" Then
            For Each row As DataRow In tabla.Rows
                If row("AnimalEID").ToString() <> "" Then
                    Dim itm As New ListViewItem(contI)
                    Dim rempl As String
                    rempl = row("AnimalEID").ToString.Replace("15200000", "")
                    rempl = rempl.ToString.Replace("1520000", "")
                    itm.SubItems.Add(rempl.TrimStart("0"))
                    itm.SubItems.Add(Format(CDate(row("AnimalDate")), "yyyy-MM-dd"))
                    itm.SubItems.Add(row("AnimalSession").ToString())

                    Dim num As Integer
                    num = frmBastonV2Conteo.lvXRS_DETALLE.Items.Count.ToString
                    For i = 0 To num - 1
                        If rempl.TrimStart("0") = frmBastonV2Conteo.lvXRS_DETALLE.Items(i).SubItems(1).Text Then
                            itm.SubItems.Add("Rep")
                            itm.BackColor = Color.Red
                            ' repetidos = repetidos + 1
                        End If
                    Next
                    If repetidos = 0 Then
                        itm.SubItems.Add("")
                    End If


                    itm.SubItems.Add("Electronico")
                    frmBastonV2Conteo.lvXRS_DETALLE.Items.Add(itm)

                    frmBastonV2Conteo.ActualizaBarraEstado(NDiios - cont)
                    cont = cont + 1
                    contI = contI + 1
                    nbarra = nbarra + 1

                End If
            Next
            repetidos = 0
            Dim nume As Integer
            nume = frmBastonV2Conteo.lvXRS_DETALLE.Items.Count.ToString
            For i = 0 To nume - 1
                If frmBastonV2Conteo.lvXRS_DETALLE.Items(i).BackColor = Color.Red Then
                    repetidos = repetidos + 1
                End If
            Next
            frmBastonV2Conteo.lblRepetidos.Text = repetidos
            frmBastonV2Conteo.FinalizaBarraEstado()
        Else
            For Each row As DataRow In tabla.Rows
                If row("AnimalEID").ToString() <> "" Then
                    Dim itm As New ListViewItem(contI)
                    Dim rempl As String
                    rempl = row("AnimalEID").ToString.Replace("15200000", "")
                    rempl = rempl.ToString.Replace("1520000", "")
                    itm.SubItems.Add(rempl.TrimStart("0"))
                    itm.SubItems.Add(Format(CDate(row("AnimalDate")), "yyyy-MM-dd"))
                    itm.SubItems.Add(row("AnimalSession").ToString())

                    Dim num As Integer
                    num = frmBastonV2.lvXRS_DETALLE.Items.Count.ToString
                    For i = 0 To num - 1
                        If rempl.TrimStart("0") = frmBastonV2.lvXRS_DETALLE.Items(i).SubItems(1).Text Then
                            itm.SubItems.Add("Rep")
                            itm.BackColor = Color.Red
                            'repetidos = repetidos + 1
                        End If
                    Next
                    If repetidos = 0 Then
                        itm.SubItems.Add("")
                    End If
                    itm.SubItems.Add("Electronico")
                    frmBastonV2.lvXRS_DETALLE.Items.Add(itm)

                    frmBastonV2.ActualizaBarraEstado(NDiios - cont)
                    cont = cont + 1
                    contI = contI + 1
                    nbarra = nbarra + 1
                End If
            Next
            repetidos = 0
            Dim nume As Integer
            nume = frmBastonV2.lvXRS_DETALLE.Items.Count.ToString
            For i = 0 To nume - 1
                If frmBastonV2.lvXRS_DETALLE.Items(i).BackColor = Color.Red Then
                    repetidos = repetidos + 1
                End If
            Next
            frmBastonV2.lblRepetidos.Text = repetidos
            frmBastonV2.FinalizaBarraEstado()
            '  MyReader.EndDataTransfer()
        End If


    End Sub
    Public Sub ProcesarDiiosGallagher(ByVal e As Integer, ByVal com As String, ByVal Pantalla As String)
        '  Dim repetidos As Integer
        Dim id_sesion As String
        Dim NDiios As String
        Dim nbarra As Integer = 0
        Dim nom_sesion As String
        If Pantalla = "Bastoneo" Then
            If (frmBastonV2Conteo.lvXRS_SESIONES.CheckedItems.Count = 0) Then
                Return
            End If
            NDiios = frmBastonV2Conteo.lvXRS_SESIONES.Items(e).SubItems(3).Text
            id_sesion = frmBastonV2Conteo.lvXRS_SESIONES.Items(e).SubItems(4).Text
            nom_sesion = frmBastonV2Conteo.lvXRS_SESIONES.Items(e).SubItems(1).Text
        Else
            If (frmBastonV2.lvXRS_SESIONES.CheckedItems.Count = 0) Then
                Return
            End If
            NDiios = frmBastonV2.lvXRS_SESIONES.Items(e).SubItems(3).Text
            id_sesion = frmBastonV2.lvXRS_SESIONES.Items(e).SubItems(4).Text
            nom_sesion = frmBastonV2.lvXRS_SESIONES.Items(e).SubItems(1).Text
        End If


        Dim tabla As DataTable = New DataTable("datos")
        tabla = MyReader.GetAnimals(id_sesion, nom_sesion)

        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)
            Return
        End If

        Dim cont As Integer = 1
        If Pantalla = "Bastoneo" Then
            For Each row As DataRow In tabla.Rows
                If row("AnimalEID").ToString() <> "" Then
                    Dim itm As New ListViewItem(cont)
                    itm.SubItems.Add(row("AnimalEID").ToString.TrimStart("0"))
                    itm.SubItems.Add(Format(CDate(row("AnimalDate")), "yyyy-MM-dd"))
                    itm.SubItems.Add(row("AnimalSession").ToString())

                    Dim num As Integer
                    num = frmBastonV2Conteo.lvXRS_DETALLE.Items.Count.ToString
                    For i = 0 To num - 1
                        If row("AnimalEID").TrimStart("0").ToString = frmBastonV2Conteo.lvXRS_DETALLE.Items(i).SubItems(1).Text Then
                            itm.SubItems.Add("Rep")
                            itm.BackColor = Color.Red
                            repetidos = repetidos + 1
                        End If
                    Next
                    If repetidos = 0 Then
                        itm.SubItems.Add("")
                    End If
                    itm.SubItems.Add("Electronico")
                    frmBastonV2Conteo.lvXRS_DETALLE.Items.Add(itm)

                    frmBastonV2Conteo.ActualizaBarraEstado(NDiios - cont)
                    cont = cont + 1
                    nbarra = nbarra + 1
                End If
            Next
            frmBastonV2Conteo.lblRepetidos.Text = repetidos
            frmBastonV2Conteo.FinalizaBarraEstado()
        Else
            For Each row As DataRow In tabla.Rows
                If row("AnimalEID").ToString() <> "" Then
                    Dim itm As New ListViewItem(cont)
                    itm.SubItems.Add(row("AnimalEID").ToString.TrimStart("0"))
                    itm.SubItems.Add(Format(CDate(row("AnimalDate")), "yyyy-MM-dd"))
                    itm.SubItems.Add(row("AnimalSession").ToString())

                    Dim num As Integer
                    num = frmBastonV2.lvXRS_DETALLE.Items.Count.ToString
                    For i = 0 To num - 1
                        If row("AnimalEID").TrimStart("0").ToString = frmBastonV2.lvXRS_DETALLE.Items(i).SubItems(1).Text Then
                            itm.SubItems.Add("Rep")
                            itm.BackColor = Color.Red
                            repetidos = repetidos + 1
                        End If
                    Next
                    If repetidos = 0 Then
                        itm.SubItems.Add("")
                    End If
                    itm.SubItems.Add("Electronico")
                    frmBastonV2.lvXRS_DETALLE.Items.Add(itm)

                    frmBastonV2.ActualizaBarraEstado(NDiios - cont)
                    cont = cont + 1
                    nbarra = nbarra + 1
                End If
            Next
            frmBastonV2.lblRepetidos.Text = repetidos
            frmBastonV2.FinalizaBarraEstado()
            '  MyReader.EndDataTransfer()
        End If
    End Sub

    Public Sub Coneccionxrs2(ByVal com As String)
        MyReader = New NDAgroComm.EIDTruTestReaderXRS2()


        MyReader.ReadTimeOut = 800
        MyReader.ReceivedDataSleep = 80
        MyReader.EIDStartPosition = 7
        MyReader.EIDEndPosition = 0
        MyReader.HideEmptySessions = True
        MyReader.BeginDataTransfer(com, 115200)

        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)
            Return
        End If
    End Sub
    Public Sub ConexionAgridentSesiones(ByVal com As String)
        MyReader = New NDAgroComm.EIDAgridentReader()

        MyReader.ReadTimeOut = 800
        MyReader.ReceivedDataSleep = 160
        MyReader.EIDStartPosition = 7
        MyReader.EIDEndPosition = 0
        MyReader.HideEmptySessions = True

        MyReader.BeginDataTransfer(com, 9600)
        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)
            Return
        End If
        frmBastonV2.conexion = "Agrident"
    End Sub
    Public Sub ConexionGallagherSesiones(ByVal com As String)
        MyReader = New NDAgroComm.EIDGallagherReader()

        MyReader.ReadTimeOut = 1300
        MyReader.ReceivedDataSleep = 300
        MyReader.EIDStartPosition = 7
        MyReader.EIDEndPosition = 0
        MyReader.HideEmptySessions = True

        MyReader.BeginDataTransfer(com, 115200)
        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)
            Return
        End If
        frmBastonV2.conexion = "Gallagher"
    End Sub
    Public Sub ConexionGallagherSesionesAlarma(ByVal com As String)
        MyReader = New NDAgroComm.EIDGallagherReader()
        'MyReader.Model = NDAgroComm.Models.Gallaguer_HR45
        MyReader.ReadTimeOut = 1300
        MyReader.ReceivedDataSleep = 300
        MyReader.EIDStartPosition = 7
        MyReader.EIDEndPosition = 0
        MyReader.HideEmptySessions = True

        MyReader.BeginDataTransfer(com, 115200)
        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)
            Return
        End If
        frmBastonV2.conexion = "Gallagher"
    End Sub
    Public Sub SubirAlarmas(ByVal lv As ListView)
        Dim i As Integer
        Dim datos_alarma As String = ""
        Dim n As Integer = lv.Items.Count
        frmAlarmas.pbProcesa.Maximum = n + 1
        frmAlarmas.pnlProcesa.Visible = True
        frmAlarmas.pnlProcesa.Refresh()
        frmAlarmas.lblProcesaMax.Text = n

        For Each item As ListViewItem In lv.Items
            datos_alarma = datos_alarma + "152 " + item.SubItems(1).Text.Trim().PadLeft(12, "0") + "," + item.SubItems(2).Text + "#"    '  IIf(Len(item.SubItems(1).Text) = 7, "152 0000", "152 00000") + item.SubItems(1).Text + "," + item.SubItems(2).Text + "#"
            'datos_alarma = datos_alarma + IIf(Len(item.SubItems(1).Text) = 7, "152 0000", "152 00000") + item.SubItems(1).Text + "," + item.SubItems(2).Text + "#"
            i = i + 1
            frmAlarmas.pbProcesa.Value = i
            frmAlarmas.lblProcesaVal.Text = i
        Next
        MyReader.UploadAlarms(datos_alarma)
        frmAlarmas.pbProcesa.Value = frmAlarmas.pbProcesa.Maximum
        If (MyReader.GetResponseCode <> 200) Then
            MessageBox.Show(MyReader.GetResponseMessage)
            Return
        End If
        frmAlarmas.pnlProcesa.Visible = False
        MessageBox.Show("--- ALARMAR SUBIDAS OK ---")
    End Sub
    Public Sub CerrarCom()
        MyReader.EndDataTransfer()
    End Sub

End Class
