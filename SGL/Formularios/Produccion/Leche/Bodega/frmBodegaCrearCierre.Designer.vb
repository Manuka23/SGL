<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBodegaCrearCierre
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "", "", "", "", "", ""}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBodegaCrearCierre))
        Me.TabBodega = New System.Windows.Forms.TabControl()
        Me.TabPage0 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lvItemsMiBodega = New System.Windows.Forms.ListView()
        Me.LinCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Producto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UMed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SldoIni = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrxNoConIn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrxNoConOut = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrxConIn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrxConOut = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CURRCOST = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SALDOFINAL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrxContab = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrxNoContab = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PND1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PND2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PND3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Stock = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Clase = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvlMovimientos = New System.Windows.Forms.ListView()
        Me.N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PendienteRec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Guia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BodCodO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BodNomO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BodCodD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BodNomD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Clases = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboBodegas = New System.Windows.Forms.ComboBox()
        Me.grbEmpresa = New System.Windows.Forms.GroupBox()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gboxRangoFecha = New System.Windows.Forms.GroupBox()
        Me.txtAnio = New System.Windows.Forms.NumericUpDown()
        Me.txtMes = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtItemNom = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCrearCierre = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnImprimirCierre = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.TabBodega.SuspendLayout()
        Me.TabPage0.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grbEmpresa.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gboxRangoFecha.SuspendLayout()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabBodega
        '
        Me.TabBodega.Controls.Add(Me.TabPage0)
        Me.TabBodega.Controls.Add(Me.TabPage1)
        Me.TabBodega.Location = New System.Drawing.Point(19, 191)
        Me.TabBodega.Margin = New System.Windows.Forms.Padding(4)
        Me.TabBodega.Name = "TabBodega"
        Me.TabBodega.SelectedIndex = 0
        Me.TabBodega.Size = New System.Drawing.Size(1150, 465)
        Me.TabBodega.TabIndex = 235
        '
        'TabPage0
        '
        Me.TabPage0.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage0.Controls.Add(Me.GroupBox2)
        Me.TabPage0.Location = New System.Drawing.Point(4, 25)
        Me.TabPage0.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage0.Name = "TabPage0"
        Me.TabPage0.Size = New System.Drawing.Size(1142, 436)
        Me.TabPage0.TabIndex = 4
        Me.TabPage0.Text = "Mi Bodega"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox2.Controls.Add(Me.lvItemsMiBodega)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(11, 4)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(1134, 434)
        Me.GroupBox2.TabIndex = 203
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "BODEGA"
        '
        'lvItemsMiBodega
        '
        Me.lvItemsMiBodega.AutoArrange = False
        Me.lvItemsMiBodega.BackColor = System.Drawing.SystemColors.Window
        Me.lvItemsMiBodega.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LinCol, Me.Producto, Me.ItemCod, Me.UMed, Me.SldoIni, Me.TrxNoConIn, Me.TrxNoConOut, Me.TrxConIn, Me.TrxConOut, Me.CURRCOST, Me.SALDOFINAL, Me.TrxContab, Me.TrxNoContab, Me.PND1, Me.PND2, Me.PND3, Me.Stock, Me.Clase})
        Me.lvItemsMiBodega.FullRowSelect = True
        Me.lvItemsMiBodega.GridLines = True
        Me.lvItemsMiBodega.HideSelection = False
        Me.lvItemsMiBodega.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.lvItemsMiBodega.Location = New System.Drawing.Point(0, 28)
        Me.lvItemsMiBodega.Margin = New System.Windows.Forms.Padding(4)
        Me.lvItemsMiBodega.MultiSelect = False
        Me.lvItemsMiBodega.Name = "lvItemsMiBodega"
        Me.lvItemsMiBodega.Size = New System.Drawing.Size(1126, 395)
        Me.lvItemsMiBodega.TabIndex = 207
        Me.lvItemsMiBodega.UseCompatibleStateImageBehavior = False
        Me.lvItemsMiBodega.View = System.Windows.Forms.View.Details
        '
        'LinCol
        '
        Me.LinCol.Text = "Nro"
        Me.LinCol.Width = 45
        '
        'Producto
        '
        Me.Producto.Text = "Producto"
        Me.Producto.Width = 235
        '
        'ItemCod
        '
        Me.ItemCod.Text = "ItemCod"
        Me.ItemCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ItemCod.Width = 0
        '
        'UMed
        '
        Me.UMed.Text = "U. Medida"
        Me.UMed.Width = 59
        '
        'SldoIni
        '
        Me.SldoIni.Text = "Saldo Inicial"
        Me.SldoIni.Width = 114
        '
        'TrxNoConIn
        '
        Me.TrxNoConIn.Text = "Ingreso No Contabilizado"
        Me.TrxNoConIn.Width = 150
        '
        'TrxNoConOut
        '
        Me.TrxNoConOut.Text = "Salida No Contabilizada"
        Me.TrxNoConOut.Width = 150
        '
        'TrxConIn
        '
        Me.TrxConIn.Text = "Ingreso Contabilizado"
        Me.TrxConIn.Width = 150
        '
        'TrxConOut
        '
        Me.TrxConOut.Text = "Salida Contabilizada"
        Me.TrxConOut.Width = 150
        '
        'CURRCOST
        '
        Me.CURRCOST.Text = "Costo Actual"
        Me.CURRCOST.Width = 0
        '
        'SALDOFINAL
        '
        Me.SALDOFINAL.Text = "Saldo Final"
        Me.SALDOFINAL.Width = 90
        '
        'TrxContab
        '
        Me.TrxContab.Text = "Contabilizado"
        Me.TrxContab.Width = 0
        '
        'TrxNoContab
        '
        Me.TrxNoContab.Text = "No Contabilizado"
        Me.TrxNoContab.Width = 0
        '
        'PND1
        '
        Me.PND1.Text = "PND1"
        '
        'PND2
        '
        Me.PND2.Text = "PND2"
        '
        'PND3
        '
        Me.PND3.Text = "PND3"
        '
        'Stock
        '
        Me.Stock.Text = "Stock"
        Me.Stock.Width = 0
        '
        'Clase
        '
        Me.Clase.Text = "Clase"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lvlMovimientos)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1142, 436)
        Me.TabPage1.TabIndex = 5
        Me.TabPage1.Text = "Movimientos Pendientes"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvlMovimientos
        '
        Me.lvlMovimientos.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvlMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvlMovimientos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.N, Me.CodItem, Me.ItemNom, Me.PendienteRec, Me.Guia, Me.BodCodO, Me.BodNomO, Me.BodCodD, Me.BodNomD, Me.Fecha, Me.Clases})
        Me.lvlMovimientos.FullRowSelect = True
        Me.lvlMovimientos.GridLines = True
        Me.lvlMovimientos.HideSelection = False
        Me.lvlMovimientos.Location = New System.Drawing.Point(1, 3)
        Me.lvlMovimientos.Name = "lvlMovimientos"
        Me.lvlMovimientos.Size = New System.Drawing.Size(1119, 427)
        Me.lvlMovimientos.TabIndex = 0
        Me.lvlMovimientos.UseCompatibleStateImageBehavior = False
        Me.lvlMovimientos.View = System.Windows.Forms.View.Details
        '
        'N
        '
        Me.N.Text = "N°"
        Me.N.Width = 40
        '
        'CodItem
        '
        Me.CodItem.Text = "Item Cod."
        Me.CodItem.Width = 0
        '
        'ItemNom
        '
        Me.ItemNom.Text = "Item"
        Me.ItemNom.Width = 150
        '
        'PendienteRec
        '
        Me.PendienteRec.Text = "Pend. Recepción"
        Me.PendienteRec.Width = 100
        '
        'Guia
        '
        Me.Guia.Text = "Guia"
        '
        'BodCodO
        '
        Me.BodCodO.Text = "BodCodO"
        Me.BodCodO.Width = 0
        '
        'BodNomO
        '
        Me.BodNomO.Text = "Bodega Nom. Origen"
        Me.BodNomO.Width = 150
        '
        'BodCodD
        '
        Me.BodCodD.Text = "BodCodD"
        Me.BodCodD.Width = 0
        '
        'BodNomD
        '
        Me.BodNomD.Text = "Bodega Nom. Destino"
        Me.BodNomD.Width = 150
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.Width = 100
        '
        'Clases
        '
        Me.Clases.Text = "Clase"
        Me.Clases.Width = 100
        '
        'cboBodegas
        '
        Me.cboBodegas.BackColor = System.Drawing.SystemColors.Window
        Me.cboBodegas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBodegas.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBodegas.FormattingEnabled = True
        Me.cboBodegas.Location = New System.Drawing.Point(7, 24)
        Me.cboBodegas.Margin = New System.Windows.Forms.Padding(4)
        Me.cboBodegas.Name = "cboBodegas"
        Me.cboBodegas.Size = New System.Drawing.Size(250, 29)
        Me.cboBodegas.TabIndex = 211
        '
        'grbEmpresa
        '
        Me.grbEmpresa.Controls.Add(Me.cboEmpresa)
        Me.grbEmpresa.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.grbEmpresa.Location = New System.Drawing.Point(16, 60)
        Me.grbEmpresa.Margin = New System.Windows.Forms.Padding(4)
        Me.grbEmpresa.Name = "grbEmpresa"
        Me.grbEmpresa.Padding = New System.Windows.Forms.Padding(4)
        Me.grbEmpresa.Size = New System.Drawing.Size(312, 66)
        Me.grbEmpresa.TabIndex = 232
        Me.grbEmpresa.TabStop = False
        Me.grbEmpresa.Text = "Empresa"
        '
        'cboEmpresa
        '
        Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpresa.FormattingEnabled = True
        Me.cboEmpresa.Location = New System.Drawing.Point(16, 25)
        Me.cboEmpresa.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(287, 29)
        Me.cboEmpresa.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1184, 54)
        Me.Panel1.TabIndex = 233
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(-28, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1197, 36)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CIERRE MENSUAL BODEGA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'gboxRangoFecha
        '
        Me.gboxRangoFecha.Controls.Add(Me.txtAnio)
        Me.gboxRangoFecha.Controls.Add(Me.txtMes)
        Me.gboxRangoFecha.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxRangoFecha.Location = New System.Drawing.Point(606, 61)
        Me.gboxRangoFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.gboxRangoFecha.Name = "gboxRangoFecha"
        Me.gboxRangoFecha.Padding = New System.Windows.Forms.Padding(4)
        Me.gboxRangoFecha.Size = New System.Drawing.Size(203, 65)
        Me.gboxRangoFecha.TabIndex = 245
        Me.gboxRangoFecha.TabStop = False
        Me.gboxRangoFecha.Text = "Periodo"
        '
        'txtAnio
        '
        Me.txtAnio.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnio.Location = New System.Drawing.Point(105, 25)
        Me.txtAnio.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAnio.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.txtAnio.Minimum = New Decimal(New Integer() {2010, 0, 0, 0})
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.Size = New System.Drawing.Size(89, 28)
        Me.txtAnio.TabIndex = 1
        Me.txtAnio.Value = New Decimal(New Integer() {2012, 0, 0, 0})
        '
        'txtMes
        '
        Me.txtMes.Location = New System.Drawing.Point(8, 25)
        Me.txtMes.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMes.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.txtMes.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(89, 28)
        Me.txtMes.TabIndex = 0
        Me.txtMes.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(828, 77)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 36)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "Estado de Cierre: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Red
        Me.lblEstado.Location = New System.Drawing.Point(1030, 77)
        Me.lblEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(131, 36)
        Me.lblEstado.TabIndex = 248
        Me.lblEstado.Text = "Estado"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblEstado.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboBodegas)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(335, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 65)
        Me.GroupBox1.TabIndex = 249
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bodega"
        '
        'txtItemNom
        '
        Me.txtItemNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemNom.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemNom.Location = New System.Drawing.Point(8, 21)
        Me.txtItemNom.MaxLength = 20
        Me.txtItemNom.Name = "txtItemNom"
        Me.txtItemNom.Size = New System.Drawing.Size(213, 24)
        Me.txtItemNom.TabIndex = 251
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtItemNom)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(16, 133)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(227, 51)
        Me.GroupBox3.TabIndex = 252
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar Producto"
        Me.GroupBox3.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(1043, 154)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(122, 30)
        Me.btnBuscar.TabIndex = 250
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnCrearCierre
        '
        Me.btnCrearCierre.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearCierre.Image = CType(resources.GetObject("btnCrearCierre.Image"), System.Drawing.Image)
        Me.btnCrearCierre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCrearCierre.Location = New System.Drawing.Point(19, 660)
        Me.btnCrearCierre.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCrearCierre.Name = "btnCrearCierre"
        Me.btnCrearCierre.Size = New System.Drawing.Size(155, 42)
        Me.btnCrearCierre.TabIndex = 244
        Me.btnCrearCierre.Text = "Crear Cierre "
        Me.btnCrearCierre.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(306, 660)
        Me.btnExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(105, 42)
        Me.btnExcel.TabIndex = 243
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnImprimirCierre
        '
        Me.btnImprimirCierre.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirCierre.Image = CType(resources.GetObject("btnImprimirCierre.Image"), System.Drawing.Image)
        Me.btnImprimirCierre.Location = New System.Drawing.Point(182, 660)
        Me.btnImprimirCierre.Margin = New System.Windows.Forms.Padding(4)
        Me.btnImprimirCierre.Name = "btnImprimirCierre"
        Me.btnImprimirCierre.Size = New System.Drawing.Size(116, 42)
        Me.btnImprimirCierre.TabIndex = 239
        Me.btnImprimirCierre.Text = "Imprimir"
        Me.btnImprimirCierre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprimirCierre.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1049, 660)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 42)
        Me.btnSalir.TabIndex = 234
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(419, 660)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(173, 42)
        Me.btnEliminar.TabIndex = 253
        Me.btnEliminar.Text = "Eliminar Cierre"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'frmBodegaCrearCierre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 740)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gboxRangoFecha)
        Me.Controls.Add(Me.btnCrearCierre)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnImprimirCierre)
        Me.Controls.Add(Me.TabBodega)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.grbEmpresa)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBodegaCrearCierre"
        Me.Text = "Cierre Bodega"
        Me.TabBodega.ResumeLayout(False)
        Me.TabPage0.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.grbEmpresa.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gboxRangoFecha.ResumeLayout(False)
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCrearCierre As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnImprimirCierre As Button
    Friend WithEvents TabBodega As TabControl
    Friend WithEvents TabPage0 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboBodegas As ComboBox
    Friend WithEvents lvItemsMiBodega As ListView
    Friend WithEvents LinCol As ColumnHeader
    Friend WithEvents Producto As ColumnHeader
    Friend WithEvents ItemCod As ColumnHeader
    Friend WithEvents UMed As ColumnHeader
    Friend WithEvents btnSalir As Button
    Friend WithEvents grbEmpresa As GroupBox
    Friend WithEvents cboEmpresa As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Stock As ColumnHeader
    Friend WithEvents PND1 As ColumnHeader
    Friend WithEvents gboxRangoFecha As GroupBox
    Friend WithEvents txtAnio As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtItemNom As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents PND2 As ColumnHeader
    Friend WithEvents PND3 As ColumnHeader
    Friend WithEvents Clase As ColumnHeader
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lvlMovimientos As ListView
    Friend WithEvents N As ColumnHeader
    Friend WithEvents CodItem As ColumnHeader
    Friend WithEvents ItemNom As ColumnHeader
    Friend WithEvents PendienteRec As ColumnHeader
    Friend WithEvents Guia As ColumnHeader
    Friend WithEvents BodCodO As ColumnHeader
    Friend WithEvents BodNomO As ColumnHeader
    Friend WithEvents BodCodD As ColumnHeader
    Friend WithEvents BodNomD As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents Clases As ColumnHeader
    Friend WithEvents txtMes As NumericUpDown
    Friend WithEvents SldoIni As ColumnHeader
    Friend WithEvents TrxNoConIn As ColumnHeader
    Friend WithEvents TrxNoConOut As ColumnHeader
    Friend WithEvents TrxConIn As ColumnHeader
    Friend WithEvents TrxConOut As ColumnHeader
    Friend WithEvents CURRCOST As ColumnHeader
    Friend WithEvents SALDOFINAL As ColumnHeader
    Friend WithEvents TrxContab As ColumnHeader
    Friend WithEvents TrxNoContab As ColumnHeader
    Friend WithEvents btnEliminar As Button
End Class
