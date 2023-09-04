<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBodega
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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "", "", "", "", "", ""}, -1)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBodega))
        Me.grpCentro = New System.Windows.Forms.GroupBox()
        Me.cboBodegas = New System.Windows.Forms.ComboBox()
        Me.grpFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mnuBodega = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuBodActualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tabFormulario = New System.Windows.Forms.TabControl()
        Me.TabPage0 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lvItemsMiBodega = New System.Windows.Forms.ListView()
        Me.LinCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItmNomCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItmStkCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItmCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItmCtaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItmUMCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItmNroDecCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItmClaseCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItmCostActCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItmConsumo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lvBODHISTORIAL = New System.Windows.Forms.ListView()
        Me.colMovLin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovHora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovTipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovEmpCodO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovEmpNomO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovBodCodO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovBodNomO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovEmpCodD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovEmpNomD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovBodCodD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovBodNomD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovItemCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovItemNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovItemCant = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovNroGuia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMovDOCNMBR = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lvPendRecepcion = New System.Windows.Forms.ListView()
        Me.colLin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColHora = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colBodCodO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colBodNomO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colBodCodD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colBodNomD = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCantItems = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colNroGuia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUsuCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUsuObs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colPDFNomSuite = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUsuResol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSistema = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lvRechazados = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUsuRechObs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colUsuRechazo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEmpresaCodO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtItemNom = New System.Windows.Forms.TextBox()
        Me.chkClaseTrl = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboTipoMov = New System.Windows.Forms.ComboBox()
        Me.grpTipoMov = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnTraslado = New System.Windows.Forms.Button()
        Me.btnConsumo = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnGuiaTraslado = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.grpCentro.SuspendLayout()
        Me.grpFecha.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.mnuBodega.SuspendLayout()
        Me.tabFormulario.SuspendLayout()
        Me.TabPage0.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grpTipoMov.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpCentro
        '
        Me.grpCentro.Controls.Add(Me.cboBodegas)
        Me.grpCentro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCentro.Location = New System.Drawing.Point(167, 50)
        Me.grpCentro.Name = "grpCentro"
        Me.grpCentro.Size = New System.Drawing.Size(253, 54)
        Me.grpCentro.TabIndex = 185
        Me.grpCentro.TabStop = False
        Me.grpCentro.Text = "Bodega"
        '
        'cboBodegas
        '
        Me.cboBodegas.BackColor = System.Drawing.SystemColors.Window
        Me.cboBodegas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBodegas.FormattingEnabled = True
        Me.cboBodegas.Location = New System.Drawing.Point(6, 19)
        Me.cboBodegas.Name = "cboBodegas"
        Me.cboBodegas.Size = New System.Drawing.Size(241, 26)
        Me.cboBodegas.TabIndex = 211
        '
        'grpFecha
        '
        Me.grpFecha.Controls.Add(Me.dtpFechaDesde)
        Me.grpFecha.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFecha.Location = New System.Drawing.Point(12, 108)
        Me.grpFecha.Name = "grpFecha"
        Me.grpFecha.Size = New System.Drawing.Size(130, 54)
        Me.grpFecha.TabIndex = 184
        Me.grpFecha.TabStop = False
        Me.grpFecha.Text = "Fecha Desde"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Enabled = False
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(6, 21)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(118, 26)
        Me.dtpFechaDesde.TabIndex = 1
        Me.dtpFechaDesde.Value = New Date(2012, 10, 1, 0, 0, 0, 0)
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1035, 44)
        Me.Panel1.TabIndex = 186
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1003, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "BODEGA MATERIALES "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mnuBodega
        '
        Me.mnuBodega.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuBodega.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBodActualizar})
        Me.mnuBodega.Name = "mnuPotreros"
        Me.mnuBodega.Size = New System.Drawing.Size(145, 28)
        '
        'mnuBodActualizar
        '
        Me.mnuBodActualizar.Name = "mnuBodActualizar"
        Me.mnuBodActualizar.Size = New System.Drawing.Size(144, 24)
        Me.mnuBodActualizar.Text = "Actualizar"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100000
        Me.ToolTip1.AutoPopDelay = 1000000
        Me.ToolTip1.InitialDelay = 50
        Me.ToolTip1.ReshowDelay = 50
        '
        'tabFormulario
        '
        Me.tabFormulario.Controls.Add(Me.TabPage0)
        Me.tabFormulario.Controls.Add(Me.TabPage1)
        Me.tabFormulario.Controls.Add(Me.TabPage2)
        Me.tabFormulario.Controls.Add(Me.TabPage3)
        Me.tabFormulario.Location = New System.Drawing.Point(12, 177)
        Me.tabFormulario.Name = "tabFormulario"
        Me.tabFormulario.SelectedIndex = 0
        Me.tabFormulario.Size = New System.Drawing.Size(1014, 442)
        Me.tabFormulario.TabIndex = 206
        '
        'TabPage0
        '
        Me.TabPage0.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage0.Controls.Add(Me.GroupBox2)
        Me.TabPage0.Location = New System.Drawing.Point(4, 26)
        Me.TabPage0.Name = "TabPage0"
        Me.TabPage0.Size = New System.Drawing.Size(1006, 412)
        Me.TabPage0.TabIndex = 4
        Me.TabPage0.Text = "Mi Bodega"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox2.Controls.Add(Me.lvItemsMiBodega)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(991, 411)
        Me.GroupBox2.TabIndex = 203
        Me.GroupBox2.TabStop = False
        '
        'lvItemsMiBodega
        '
        Me.lvItemsMiBodega.AutoArrange = False
        Me.lvItemsMiBodega.BackColor = System.Drawing.SystemColors.Window
        Me.lvItemsMiBodega.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LinCol, Me.ItmNomCol, Me.ItmStkCol, Me.ItmCodCol, Me.ItmCtaCol, Me.ItmUMCol, Me.ItmNroDecCol, Me.ItmClaseCol, Me.ItmCostActCol, Me.ItmConsumo})
        Me.lvItemsMiBodega.ContextMenuStrip = Me.mnuBodega
        Me.lvItemsMiBodega.FullRowSelect = True
        Me.lvItemsMiBodega.GridLines = True
        Me.lvItemsMiBodega.HideSelection = False
        Me.lvItemsMiBodega.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem2})
        Me.lvItemsMiBodega.Location = New System.Drawing.Point(6, 22)
        Me.lvItemsMiBodega.MultiSelect = False
        Me.lvItemsMiBodega.Name = "lvItemsMiBodega"
        Me.lvItemsMiBodega.Size = New System.Drawing.Size(975, 388)
        Me.lvItemsMiBodega.TabIndex = 207
        Me.lvItemsMiBodega.UseCompatibleStateImageBehavior = False
        Me.lvItemsMiBodega.View = System.Windows.Forms.View.Details
        '
        'LinCol
        '
        Me.LinCol.Text = "Nro"
        Me.LinCol.Width = 45
        '
        'ItmNomCol
        '
        Me.ItmNomCol.Text = "Producto"
        Me.ItmNomCol.Width = 500
        '
        'ItmStkCol
        '
        Me.ItmStkCol.Text = "Stock Actual"
        Me.ItmStkCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ItmStkCol.Width = 100
        '
        'ItmCodCol
        '
        Me.ItmCodCol.Text = "Codigo Prod."
        Me.ItmCodCol.Width = 0
        '
        'ItmCtaCol
        '
        Me.ItmCtaCol.Text = "Cuenta"
        Me.ItmCtaCol.Width = 0
        '
        'ItmUMCol
        '
        Me.ItmUMCol.Text = "Unid. Medida"
        Me.ItmUMCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ItmUMCol.Width = 130
        '
        'ItmNroDecCol
        '
        Me.ItmNroDecCol.Text = "Nro. Decimales"
        Me.ItmNroDecCol.Width = 0
        '
        'ItmClaseCol
        '
        Me.ItmClaseCol.Text = "Clase"
        Me.ItmClaseCol.Width = 100
        '
        'ItmCostActCol
        '
        Me.ItmCostActCol.Text = "Costo Actual"
        Me.ItmCostActCol.Width = 0
        '
        'ItmConsumo
        '
        Me.ItmConsumo.Text = "Consumo?"
        Me.ItmConsumo.Width = 91
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(5, 33)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1258, 515)
        Me.TabPage1.TabIndex = 5
        Me.TabPage1.Text = "Movimientos"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox1.Controls.Add(Me.lvBODHISTORIAL)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(991, 410)
        Me.GroupBox1.TabIndex = 204
        Me.GroupBox1.TabStop = False
        '
        'lvBODHISTORIAL
        '
        Me.lvBODHISTORIAL.AutoArrange = False
        Me.lvBODHISTORIAL.BackColor = System.Drawing.SystemColors.Window
        Me.lvBODHISTORIAL.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colMovLin, Me.colMovFecha, Me.colMovHora, Me.colMovTipo, Me.colMovEmpCodO, Me.colMovEmpNomO, Me.colMovBodCodO, Me.colMovBodNomO, Me.colMovEmpCodD, Me.colMovEmpNomD, Me.colMovBodCodD, Me.colMovBodNomD, Me.colMovItemCod, Me.colMovItemNom, Me.colMovItemCant, Me.colMovNroGuia, Me.colMovDOCNMBR})
        Me.lvBODHISTORIAL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvBODHISTORIAL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBODHISTORIAL.FullRowSelect = True
        Me.lvBODHISTORIAL.GridLines = True
        Me.lvBODHISTORIAL.HideSelection = False
        Me.lvBODHISTORIAL.Location = New System.Drawing.Point(3, 23)
        Me.lvBODHISTORIAL.MultiSelect = False
        Me.lvBODHISTORIAL.Name = "lvBODHISTORIAL"
        Me.lvBODHISTORIAL.Size = New System.Drawing.Size(985, 384)
        Me.lvBODHISTORIAL.TabIndex = 211
        Me.lvBODHISTORIAL.UseCompatibleStateImageBehavior = False
        Me.lvBODHISTORIAL.View = System.Windows.Forms.View.Details
        '
        'colMovLin
        '
        Me.colMovLin.Text = "Nro"
        Me.colMovLin.Width = 40
        '
        'colMovFecha
        '
        Me.colMovFecha.Text = "Fecha"
        Me.colMovFecha.Width = 89
        '
        'colMovHora
        '
        Me.colMovHora.Text = "Hora"
        Me.colMovHora.Width = 70
        '
        'colMovTipo
        '
        Me.colMovTipo.Text = "Tipo"
        Me.colMovTipo.Width = 110
        '
        'colMovEmpCodO
        '
        Me.colMovEmpCodO.Text = "EmpCodOri"
        Me.colMovEmpCodO.Width = 0
        '
        'colMovEmpNomO
        '
        Me.colMovEmpNomO.Text = "Empresa O."
        Me.colMovEmpNomO.Width = 0
        '
        'colMovBodCodO
        '
        Me.colMovBodCodO.Text = "BodCodO"
        Me.colMovBodCodO.Width = 0
        '
        'colMovBodNomO
        '
        Me.colMovBodNomO.Text = "Bodega O."
        Me.colMovBodNomO.Width = 150
        '
        'colMovEmpCodD
        '
        Me.colMovEmpCodD.Text = "EmpCodD"
        Me.colMovEmpCodD.Width = 0
        '
        'colMovEmpNomD
        '
        Me.colMovEmpNomD.Text = "Empresa D."
        Me.colMovEmpNomD.Width = 0
        '
        'colMovBodCodD
        '
        Me.colMovBodCodD.Text = "Dest. Codigo"
        Me.colMovBodCodD.Width = 0
        '
        'colMovBodNomD
        '
        Me.colMovBodNomD.Text = "Bodega D."
        Me.colMovBodNomD.Width = 150
        '
        'colMovItemCod
        '
        Me.colMovItemCod.Text = "Prod. Codigo"
        Me.colMovItemCod.Width = 0
        '
        'colMovItemNom
        '
        Me.colMovItemNom.Text = "Producto"
        Me.colMovItemNom.Width = 200
        '
        'colMovItemCant
        '
        Me.colMovItemCant.Text = "Cantidad"
        Me.colMovItemCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'colMovNroGuia
        '
        Me.colMovNroGuia.Text = "N° Guía"
        Me.colMovNroGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colMovNroGuia.Width = 70
        '
        'colMovDOCNMBR
        '
        Me.colMovDOCNMBR.Text = "ID GP"
        Me.colMovDOCNMBR.Width = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Location = New System.Drawing.Point(5, 33)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1258, 515)
        Me.TabPage2.TabIndex = 6
        Me.TabPage2.Text = "Pend. Recepcion"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox5.Controls.Add(Me.lvPendRecepcion)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(991, 409)
        Me.GroupBox5.TabIndex = 205
        Me.GroupBox5.TabStop = False
        '
        'lvPendRecepcion
        '
        Me.lvPendRecepcion.AutoArrange = False
        Me.lvPendRecepcion.BackColor = System.Drawing.SystemColors.Window
        Me.lvPendRecepcion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLin, Me.colFecha, Me.ColHora, Me.colBodCodO, Me.colBodNomO, Me.colBodCodD, Me.colBodNomD, Me.colCantItems, Me.colNroGuia, Me.colID, Me.colUsuCod, Me.colUsuObs, Me.colPDFNomSuite, Me.colUsuResol, Me.colSistema})
        Me.lvPendRecepcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvPendRecepcion.FullRowSelect = True
        Me.lvPendRecepcion.GridLines = True
        Me.lvPendRecepcion.HideSelection = False
        Me.lvPendRecepcion.Location = New System.Drawing.Point(3, 23)
        Me.lvPendRecepcion.MultiSelect = False
        Me.lvPendRecepcion.Name = "lvPendRecepcion"
        Me.lvPendRecepcion.Size = New System.Drawing.Size(985, 383)
        Me.lvPendRecepcion.TabIndex = 211
        Me.lvPendRecepcion.UseCompatibleStateImageBehavior = False
        Me.lvPendRecepcion.View = System.Windows.Forms.View.Details
        '
        'colLin
        '
        Me.colLin.Text = "Nro"
        Me.colLin.Width = 40
        '
        'colFecha
        '
        Me.colFecha.Text = "Fecha"
        Me.colFecha.Width = 89
        '
        'ColHora
        '
        Me.ColHora.Text = "Hora"
        Me.ColHora.Width = 70
        '
        'colBodCodO
        '
        Me.colBodCodO.Text = "Bod. Cód. O."
        Me.colBodCodO.Width = 0
        '
        'colBodNomO
        '
        Me.colBodNomO.Text = "Bodega Origen"
        Me.colBodNomO.Width = 260
        '
        'colBodCodD
        '
        Me.colBodCodD.Text = "Bod. Cód. D."
        Me.colBodCodD.Width = 0
        '
        'colBodNomD
        '
        Me.colBodNomD.Text = "Bodega Destino"
        Me.colBodNomD.Width = 260
        '
        'colCantItems
        '
        Me.colCantItems.Text = "Cant. Ítem"
        Me.colCantItems.Width = 70
        '
        'colNroGuia
        '
        Me.colNroGuia.Text = "Nro. Guía"
        Me.colNroGuia.Width = 70
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 0
        '
        'colUsuCod
        '
        Me.colUsuCod.Text = "Usuario"
        Me.colUsuCod.Width = 0
        '
        'colUsuObs
        '
        Me.colUsuObs.Text = "Observación"
        Me.colUsuObs.Width = 250
        '
        'colPDFNomSuite
        '
        Me.colPDFNomSuite.Text = "PDF"
        Me.colPDFNomSuite.Width = 0
        '
        'colUsuResol
        '
        Me.colUsuResol.Text = "Usu.Resol."
        Me.colUsuResol.Width = 0
        '
        'colSistema
        '
        Me.colSistema.Text = "Sistema"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox7)
        Me.TabPage3.Location = New System.Drawing.Point(5, 33)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1258, 515)
        Me.TabPage3.TabIndex = 7
        Me.TabPage3.Text = "Rechazados"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBox7.Controls.Add(Me.lvRechazados)
        Me.GroupBox7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(991, 409)
        Me.GroupBox7.TabIndex = 206
        Me.GroupBox7.TabStop = False
        '
        'lvRechazados
        '
        Me.lvRechazados.AutoArrange = False
        Me.lvRechazados.BackColor = System.Drawing.SystemColors.Window
        Me.lvRechazados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader11, Me.ColumnHeader18, Me.ColumnHeader21, Me.ColumnHeader24, Me.colUsuRechObs, Me.colUsuRechazo, Me.colEmpresaCodO})
        Me.lvRechazados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvRechazados.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRechazados.FullRowSelect = True
        Me.lvRechazados.GridLines = True
        Me.lvRechazados.HideSelection = False
        Me.lvRechazados.Location = New System.Drawing.Point(3, 23)
        Me.lvRechazados.MultiSelect = False
        Me.lvRechazados.Name = "lvRechazados"
        Me.lvRechazados.Size = New System.Drawing.Size(985, 383)
        Me.lvRechazados.TabIndex = 211
        Me.lvRechazados.UseCompatibleStateImageBehavior = False
        Me.lvRechazados.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nro"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fecha"
        Me.ColumnHeader2.Width = 89
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fecha Rech."
        Me.ColumnHeader3.Width = 130
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Bod. Cód. O."
        Me.ColumnHeader4.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Bodega Origen"
        Me.ColumnHeader5.Width = 210
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Bod. Cód. D."
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Bodega Destino"
        Me.ColumnHeader7.Width = 210
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Cant. Ítem"
        Me.ColumnHeader8.Width = 70
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Nro. Guía"
        Me.ColumnHeader9.Width = 70
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "ID"
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Usuario"
        Me.ColumnHeader18.Width = 0
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Observación"
        Me.ColumnHeader21.Width = 0
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "PDF"
        Me.ColumnHeader24.Width = 0
        '
        'colUsuRechObs
        '
        Me.colUsuRechObs.Text = "Rechazo Obs."
        Me.colUsuRechObs.Width = 150
        '
        'colUsuRechazo
        '
        Me.colUsuRechazo.Text = "Usuario Rechazo"
        Me.colUsuRechazo.Width = 150
        '
        'colEmpresaCodO
        '
        Me.colEmpresaCodO.Text = "EmpresaCodO"
        Me.colEmpresaCodO.Width = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtItemNom)
        Me.GroupBox3.Controls.Add(Me.chkClaseTrl)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(494, 108)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(344, 54)
        Me.GroupBox3.TabIndex = 207
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar Producto"
        '
        'txtItemNom
        '
        Me.txtItemNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemNom.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemNom.Location = New System.Drawing.Point(6, 20)
        Me.txtItemNom.MaxLength = 20
        Me.txtItemNom.Name = "txtItemNom"
        Me.txtItemNom.Size = New System.Drawing.Size(177, 24)
        Me.txtItemNom.TabIndex = 0
        '
        'chkClaseTrl
        '
        Me.chkClaseTrl.AutoSize = True
        Me.chkClaseTrl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClaseTrl.Location = New System.Drawing.Point(208, 21)
        Me.chkClaseTrl.Name = "chkClaseTrl"
        Me.chkClaseTrl.Size = New System.Drawing.Size(123, 22)
        Me.chkClaseTrl.TabIndex = 222
        Me.chkClaseTrl.Text = "Clase Traslados"
        Me.chkClaseTrl.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(173, 108)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(130, 54)
        Me.GroupBox4.TabIndex = 208
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fecha Hasta"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Enabled = False
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(6, 21)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(118, 26)
        Me.dtpFechaHasta.TabIndex = 1
        Me.dtpFechaHasta.Value = New Date(2012, 10, 1, 0, 0, 0, 0)
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.DisplayIndex = 0
        Me.ColumnHeader10.Text = "Nro"
        Me.ColumnHeader10.Width = 45
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.DisplayIndex = 1
        Me.ColumnHeader12.Text = "Producto"
        Me.ColumnHeader12.Width = 360
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.DisplayIndex = 2
        Me.ColumnHeader13.Text = "Cant"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader13.Width = 70
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.DisplayIndex = 3
        Me.ColumnHeader14.Text = "Codigo Prod."
        Me.ColumnHeader14.Width = 0
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.DisplayIndex = 4
        Me.ColumnHeader15.Text = "Cuenta"
        Me.ColumnHeader15.Width = 0
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.DisplayIndex = 5
        Me.ColumnHeader16.Text = "Item Gasto"
        Me.ColumnHeader16.Width = 0
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.DisplayIndex = 6
        Me.ColumnHeader17.Text = "Grabado"
        Me.ColumnHeader17.Width = 0
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.DisplayIndex = 7
        Me.ColumnHeader19.Text = "Cuenta"
        Me.ColumnHeader19.Width = 220
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.DisplayIndex = 8
        Me.ColumnHeader20.Text = "Item Gasto"
        Me.ColumnHeader20.Width = 220
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.DisplayIndex = 9
        Me.ColumnHeader22.Text = "Unid. Med."
        Me.ColumnHeader22.Width = 0
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.DisplayIndex = 10
        Me.ColumnHeader23.Text = "Stock"
        Me.ColumnHeader23.Width = 0
        '
        'cboTipoMov
        '
        Me.cboTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMov.FormattingEnabled = True
        Me.cboTipoMov.Location = New System.Drawing.Point(6, 20)
        Me.cboTipoMov.Name = "cboTipoMov"
        Me.cboTipoMov.Size = New System.Drawing.Size(121, 26)
        Me.cboTipoMov.TabIndex = 204
        '
        'grpTipoMov
        '
        Me.grpTipoMov.Controls.Add(Me.cboTipoMov)
        Me.grpTipoMov.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTipoMov.Location = New System.Drawing.Point(332, 108)
        Me.grpTipoMov.Name = "grpTipoMov"
        Me.grpTipoMov.Size = New System.Drawing.Size(140, 54)
        Me.grpTipoMov.TabIndex = 209
        Me.grpTipoMov.TabStop = False
        Me.grpTipoMov.Text = "Tipo Movimiento"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.cboEmpresa)
        Me.GroupBox6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(149, 54)
        Me.GroupBox6.TabIndex = 212
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Empresa"
        '
        'cboEmpresa
        '
        Me.cboEmpresa.BackColor = System.Drawing.SystemColors.Window
        Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa.FormattingEnabled = True
        Me.cboEmpresa.Location = New System.Drawing.Point(6, 19)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(124, 26)
        Me.cboEmpresa.TabIndex = 211
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(932, 132)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 30)
        Me.btnBuscar.TabIndex = 209
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(676, 626)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(125, 34)
        Me.Button4.TabIndex = 232
        Me.Button4.Text = "Articulos Cierre"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(807, 626)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(122, 34)
        Me.Button3.TabIndex = 231
        Me.Button3.Text = "Cierre Bodega"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnTraslado
        '
        Me.btnTraslado.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTraslado.Image = CType(resources.GetObject("btnTraslado.Image"), System.Drawing.Image)
        Me.btnTraslado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTraslado.Location = New System.Drawing.Point(138, 626)
        Me.btnTraslado.Name = "btnTraslado"
        Me.btnTraslado.Size = New System.Drawing.Size(104, 34)
        Me.btnTraslado.TabIndex = 229
        Me.btnTraslado.Text = "Traslado"
        Me.btnTraslado.UseVisualStyleBackColor = True
        '
        'btnConsumo
        '
        Me.btnConsumo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsumo.Image = CType(resources.GetObject("btnConsumo.Image"), System.Drawing.Image)
        Me.btnConsumo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsumo.Location = New System.Drawing.Point(18, 626)
        Me.btnConsumo.Name = "btnConsumo"
        Me.btnConsumo.Size = New System.Drawing.Size(104, 34)
        Me.btnConsumo.TabIndex = 228
        Me.btnConsumo.Text = "Consumo"
        Me.btnConsumo.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(388, 626)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(104, 34)
        Me.btnExcel.TabIndex = 226
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnGuiaTraslado
        '
        Me.btnGuiaTraslado.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuiaTraslado.Image = CType(resources.GetObject("btnGuiaTraslado.Image"), System.Drawing.Image)
        Me.btnGuiaTraslado.Location = New System.Drawing.Point(262, 626)
        Me.btnGuiaTraslado.Name = "btnGuiaTraslado"
        Me.btnGuiaTraslado.Size = New System.Drawing.Size(104, 34)
        Me.btnGuiaTraslado.TabIndex = 221
        Me.btnGuiaTraslado.Text = "Imprimir"
        Me.btnGuiaTraslado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGuiaTraslado.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(935, 626)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 34)
        Me.btnSalir.TabIndex = 188
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmBodega
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 664)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.grpTipoMov)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnTraslado)
        Me.Controls.Add(Me.btnConsumo)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnGuiaTraslado)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.tabFormulario)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.grpFecha)
        Me.Controls.Add(Me.grpCentro)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBodega"
        Me.Text = "Bodega"
        Me.grpCentro.ResumeLayout(False)
        Me.grpFecha.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.mnuBodega.ResumeLayout(False)
        Me.tabFormulario.ResumeLayout(False)
        Me.TabPage0.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.grpTipoMov.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpCentro As GroupBox
    Friend WithEvents grpFecha As GroupBox
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents mnuBodega As ContextMenuStrip
    Friend WithEvents mnuBodActualizar As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents tabFormulario As TabControl
    Friend WithEvents TabPage0 As TabPage
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboBodegas As ComboBox
    Friend WithEvents lvItemsMiBodega As ListView
    Friend WithEvents LinCol As ColumnHeader
    Friend WithEvents ItmNomCol As ColumnHeader
    Friend WithEvents ItmStkCol As ColumnHeader
    Friend WithEvents ItmCodCol As ColumnHeader
    Friend WithEvents ItmCtaCol As ColumnHeader
    Friend WithEvents ItmUMCol As ColumnHeader
    Friend WithEvents ItmNroDecCol As ColumnHeader
    Friend WithEvents ItmClaseCol As ColumnHeader
    Friend WithEvents ItmCostActCol As ColumnHeader
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lvBODHISTORIAL As ListView
    Friend WithEvents colMovLin As ColumnHeader
    Friend WithEvents colMovHora As ColumnHeader
    Friend WithEvents colMovTipo As ColumnHeader
    Friend WithEvents colMovItemNom As ColumnHeader
    Friend WithEvents colMovItemCant As ColumnHeader
    Friend WithEvents colMovNroGuia As ColumnHeader
    Friend WithEvents colMovBodNomD As ColumnHeader
    Friend WithEvents colMovBodCodD As ColumnHeader
    Friend WithEvents colMovItemCod As ColumnHeader
    Friend WithEvents colMovDOCNMBR As ColumnHeader
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtItemNom As TextBox
    Friend WithEvents colMovFecha As ColumnHeader
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnGuiaTraslado As Button
    Friend WithEvents chkClaseTrl As CheckBox
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnConsumo As Button
    Friend WithEvents btnTraslado As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents cboTipoMov As ComboBox
    Friend WithEvents grpTipoMov As GroupBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents lvPendRecepcion As ListView
    Friend WithEvents colLin As ColumnHeader
    Friend WithEvents colFecha As ColumnHeader
    Friend WithEvents ColHora As ColumnHeader
    Friend WithEvents colBodCodO As ColumnHeader
    Friend WithEvents colBodNomO As ColumnHeader
    Friend WithEvents colBodCodD As ColumnHeader
    Friend WithEvents colBodNomD As ColumnHeader
    Friend WithEvents colCantItems As ColumnHeader
    Friend WithEvents colNroGuia As ColumnHeader
    Friend WithEvents colID As ColumnHeader
    Friend WithEvents colUsuCod As ColumnHeader
    Friend WithEvents colUsuObs As ColumnHeader
    Friend WithEvents colPDFNomSuite As ColumnHeader
    Friend WithEvents colUsuResol As ColumnHeader
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents cboEmpresa As ComboBox
    Friend WithEvents colMovEmpCodO As ColumnHeader
    Friend WithEvents colMovEmpNomO As ColumnHeader
    Friend WithEvents colMovBodCodO As ColumnHeader
    Friend WithEvents colMovBodNomO As ColumnHeader
    Friend WithEvents colMovEmpCodD As ColumnHeader
    Friend WithEvents colMovEmpNomD As ColumnHeader
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents lvRechazados As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents colUsuRechObs As ColumnHeader
    Friend WithEvents colUsuRechazo As ColumnHeader
    Friend WithEvents colEmpresaCodO As ColumnHeader
    Friend WithEvents colSistema As ColumnHeader
    Friend WithEvents ItmConsumo As ColumnHeader
End Class
