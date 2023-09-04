<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSilos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSilos))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lvBolos = New System.Windows.Forms.ListView()
        Me.NroLinCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ValBolo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotBolos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuGanado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.lvRESUMEN1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cboBolo = New System.Windows.Forms.ComboBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnAnular = New System.Windows.Forms.Button()
        Me.grpStock = New System.Windows.Forms.GroupBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtObservsEstado = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbtnNoConforme = New System.Windows.Forms.RadioButton()
        Me.rbtnConforme = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboEstados = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox4.SuspendLayout()
        Me.MenuGanado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.grpStock.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lvBolos)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(7, 357)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(1350, 246)
        Me.GroupBox4.TabIndex = 248
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalles"
        '
        'lvBolos
        '
        Me.lvBolos.AutoArrange = False
        Me.lvBolos.BackColor = System.Drawing.SystemColors.Window
        Me.lvBolos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NroLinCol, Me.ColumnHeader4, Me.ColumnHeader10, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader11, Me.ColumnHeader18, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ValBolo, Me.TotBolos, Me.ColumnHeader19, Me.ColumnHeader8, Me.ColumnHeader30})
        Me.lvBolos.ContextMenuStrip = Me.MenuGanado
        Me.lvBolos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvBolos.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBolos.FullRowSelect = True
        Me.lvBolos.GridLines = True
        Me.lvBolos.HideSelection = False
        Me.lvBolos.Location = New System.Drawing.Point(4, 24)
        Me.lvBolos.Margin = New System.Windows.Forms.Padding(4)
        Me.lvBolos.MultiSelect = False
        Me.lvBolos.Name = "lvBolos"
        Me.lvBolos.Size = New System.Drawing.Size(1342, 218)
        Me.lvBolos.TabIndex = 133
        Me.lvBolos.UseCompatibleStateImageBehavior = False
        Me.lvBolos.View = System.Windows.Forms.View.Details
        '
        'NroLinCol
        '
        Me.NroLinCol.Text = "Nro"
        Me.NroLinCol.Width = 35
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Centro"
        Me.ColumnHeader4.Width = 164
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Centro Cod"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Tipo Ensilaje"
        Me.ColumnHeader25.Width = 222
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Medida"
        Me.ColumnHeader26.Width = 76
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Potrero"
        Me.ColumnHeader11.Width = 69
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Ha. Potrero"
        Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader18.Width = 84
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Cant."
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader12.Width = 70
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Has"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader13.Width = 74
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Rendimiento"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader14.Width = 92
        '
        'ValBolo
        '
        Me.ValBolo.Text = "$ Bolo"
        Me.ValBolo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ValBolo.Width = 81
        '
        'TotBolos
        '
        Me.TotBolos.Text = "Total"
        Me.TotBolos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TotBolos.Width = 93
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "CodItem"
        Me.ColumnHeader19.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Fecha"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "GP Num."
        Me.ColumnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader30.Width = 94
        '
        'MenuGanado
        '
        Me.MenuGanado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuGanado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEliminar})
        Me.MenuGanado.Name = "MenuGanado"
        Me.MenuGanado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuGanado.Size = New System.Drawing.Size(199, 28)
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuEliminar.Name = "mnuEliminar"
        Me.mnuEliminar.Size = New System.Drawing.Size(198, 24)
        Me.mnuEliminar.Text = "Eliminar Registro"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1371, 49)
        Me.Panel1.TabIndex = 246
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 9)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1344, 37)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Confección de Ensilaje"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(1086, 76)
        Me.btnLimpiarFiltros.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(115, 46)
        Me.btnLimpiarFiltros.TabIndex = 245
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'lvRESUMEN1
        '
        Me.lvRESUMEN1.AutoArrange = False
        Me.lvRESUMEN1.BackColor = System.Drawing.SystemColors.Window
        Me.lvRESUMEN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvRESUMEN1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader34, Me.ColumnHeader3, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader9, Me.ColumnHeader5, Me.ColumnHeader7, Me.ColumnHeader6, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader17, Me.ColumnHeader20, Me.ColumnHeader27, Me.ColumnHeader15, Me.ColumnHeader28, Me.ColumnHeader29, Me.ColumnHeader16})
        Me.lvRESUMEN1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRESUMEN1.FullRowSelect = True
        Me.lvRESUMEN1.GridLines = True
        Me.lvRESUMEN1.HideSelection = False
        Me.lvRESUMEN1.Location = New System.Drawing.Point(11, 135)
        Me.lvRESUMEN1.Margin = New System.Windows.Forms.Padding(4)
        Me.lvRESUMEN1.MultiSelect = False
        Me.lvRESUMEN1.Name = "lvRESUMEN1"
        Me.lvRESUMEN1.Size = New System.Drawing.Size(1346, 214)
        Me.lvRESUMEN1.TabIndex = 244
        Me.lvRESUMEN1.UseCompatibleStateImageBehavior = False
        Me.lvRESUMEN1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "N°"
        Me.ColumnHeader34.Width = 43
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fecha"
        Me.ColumnHeader3.Width = 77
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Centro"
        Me.ColumnHeader1.Width = 127
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "CentroCod"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Tip. Ensilaje"
        Me.ColumnHeader23.Width = 210
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "UM"
        Me.ColumnHeader24.Width = 0
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Cant. Pot."
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 68
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cant. Bolos"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 75
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Ha. Util."
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Rend."
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 57
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Usuario"
        Me.ColumnHeader21.Width = 0
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Equipo"
        Me.ColumnHeader22.Width = 0
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "CodItem"
        Me.ColumnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader17.Width = 0
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "ValorBolo"
        Me.ColumnHeader20.Width = 0
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Total"
        Me.ColumnHeader27.Width = 0
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Estado"
        Me.ColumnHeader15.Width = 130
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "GP Num"
        Me.ColumnHeader28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader28.Width = 0
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Usuario"
        Me.ColumnHeader29.Width = 84
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Fecha Reg."
        Me.ColumnHeader16.Width = 134
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboCentros)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(229, 71)
        Me.GroupBox5.TabIndex = 243
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(8, 27)
        Me.cboCentros.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(213, 29)
        Me.cboCentros.TabIndex = 0
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(182, 618)
        Me.btnExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(108, 46)
        Me.btnExcel.TabIndex = 242
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(1204, 76)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(112, 46)
        Me.btnBuscar.TabIndex = 241
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox6.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(502, 58)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox6.Size = New System.Drawing.Size(369, 71)
        Me.GroupBox6.TabIndex = 240
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Rango de Fecha"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(69, 27)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(115, 27)
        Me.dtpFechaDesde.TabIndex = 56
        Me.dtpFechaDesde.Value = New Date(2017, 10, 6, 15, 45, 48, 0)
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(245, 27)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(115, 27)
        Me.dtpFechaHasta.TabIndex = 55
        Me.dtpFechaHasta.Value = New Date(2017, 10, 6, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(185, 31)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1237, 614)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 46)
        Me.btnSalir.TabIndex = 239
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(11, 618)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(163, 46)
        Me.btnAgregar.TabIndex = 238
        Me.btnAgregar.Text = "Agregar Ensilaje"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.cboBolo)
        Me.GroupBox9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(249, 58)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox9.Size = New System.Drawing.Size(245, 70)
        Me.GroupBox9.TabIndex = 252
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Tipo Ensilaje"
        '
        'cboBolo
        '
        Me.cboBolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBolo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBolo.FormattingEnabled = True
        Me.cboBolo.Location = New System.Drawing.Point(16, 23)
        Me.cboBolo.Margin = New System.Windows.Forms.Padding(4)
        Me.cboBolo.Name = "cboBolo"
        Me.cboBolo.Size = New System.Drawing.Size(221, 27)
        Me.cboBolo.TabIndex = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(298, 618)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(125, 46)
        Me.btnEliminar.TabIndex = 253
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'BtnAnular
        '
        Me.BtnAnular.Enabled = False
        Me.BtnAnular.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAnular.Image = CType(resources.GetObject("BtnAnular.Image"), System.Drawing.Image)
        Me.BtnAnular.Location = New System.Drawing.Point(431, 618)
        Me.BtnAnular.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAnular.Name = "BtnAnular"
        Me.BtnAnular.Size = New System.Drawing.Size(125, 46)
        Me.BtnAnular.TabIndex = 254
        Me.BtnAnular.Text = "Anular"
        Me.BtnAnular.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAnular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAnular.UseVisualStyleBackColor = True
        '
        'grpStock
        '
        Me.grpStock.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grpStock.Controls.Add(Me.Label50)
        Me.grpStock.Controls.Add(Me.txtObservsEstado)
        Me.grpStock.Controls.Add(Me.Label4)
        Me.grpStock.Controls.Add(Me.rbtnNoConforme)
        Me.grpStock.Controls.Add(Me.rbtnConforme)
        Me.grpStock.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpStock.Location = New System.Drawing.Point(696, 611)
        Me.grpStock.Margin = New System.Windows.Forms.Padding(4)
        Me.grpStock.Name = "grpStock"
        Me.grpStock.Padding = New System.Windows.Forms.Padding(4)
        Me.grpStock.Size = New System.Drawing.Size(523, 63)
        Me.grpStock.TabIndex = 255
        Me.grpStock.TabStop = False
        Me.grpStock.Text = "Confirmacion silos"
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Red
        Me.Label50.Location = New System.Drawing.Point(8, 20)
        Me.Label50.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(416, 43)
        Me.Label50.TabIndex = 203
        Me.Label50.Text = " Los registros PND. CONFIRMACION serán confirmados a las 00:00 del mismo día de i" &
    "ngreso"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtObservsEstado
        '
        Me.txtObservsEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservsEstado.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservsEstado.Location = New System.Drawing.Point(820, 180)
        Me.txtObservsEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObservsEstado.MaxLength = 100
        Me.txtObservsEstado.Multiline = True
        Me.txtObservsEstado.Name = "txtObservsEstado"
        Me.txtObservsEstado.Size = New System.Drawing.Size(437, 54)
        Me.txtObservsEstado.TabIndex = 202
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(816, 161)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 26)
        Me.Label4.TabIndex = 200
        Me.Label4.Text = "Observación"
        '
        'rbtnNoConforme
        '
        Me.rbtnNoConforme.AutoSize = True
        Me.rbtnNoConforme.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtnNoConforme.Location = New System.Drawing.Point(652, 206)
        Me.rbtnNoConforme.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnNoConforme.Name = "rbtnNoConforme"
        Me.rbtnNoConforme.Size = New System.Drawing.Size(125, 25)
        Me.rbtnNoConforme.TabIndex = 201
        Me.rbtnNoConforme.Text = "No Conforme"
        Me.rbtnNoConforme.UseVisualStyleBackColor = True
        '
        'rbtnConforme
        '
        Me.rbtnConforme.AutoSize = True
        Me.rbtnConforme.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtnConforme.Checked = True
        Me.rbtnConforme.Location = New System.Drawing.Point(677, 175)
        Me.rbtnConforme.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnConforme.Name = "rbtnConforme"
        Me.rbtnConforme.Size = New System.Drawing.Size(101, 25)
        Me.rbtnConforme.TabIndex = 200
        Me.rbtnConforme.TabStop = True
        Me.rbtnConforme.Text = "Conforme"
        Me.rbtnConforme.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboEstados)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(879, 57)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(202, 70)
        Me.GroupBox1.TabIndex = 256
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado"
        '
        'cboEstados
        '
        Me.cboEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstados.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstados.FormattingEnabled = True
        Me.cboEstados.Items.AddRange(New Object() {"(TODOS)", "PND. CONFIRMACION", "CONFIRMADO", "ANULADO"})
        Me.cboEstados.Location = New System.Drawing.Point(16, 23)
        Me.cboEstados.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEstados.Name = "cboEstados"
        Me.cboEstados.Size = New System.Drawing.Size(178, 27)
        Me.cboEstados.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(563, 618)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(126, 46)
        Me.btnCancelar.TabIndex = 257
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmSilos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 697)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpStock)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnAnular)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.lvRESUMEN1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAgregar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSilos"
        Me.Text = "Ensilaje"
        Me.GroupBox4.ResumeLayout(False)
        Me.MenuGanado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.grpStock.ResumeLayout(False)
        Me.grpStock.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnLimpiarFiltros As Button
    Friend WithEvents lvRESUMEN1 As ListView
    Friend WithEvents ColumnHeader34 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cboCentros As ComboBox
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents cboBolo As ComboBox
    Friend WithEvents lvBolos As ListView
    Friend WithEvents NroLinCol As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ValBolo As ColumnHeader
    Friend WithEvents TotBolos As ColumnHeader
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader25 As ColumnHeader
    Friend WithEvents ColumnHeader26 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents btnEliminar As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents MenuGanado As ContextMenuStrip
    Friend WithEvents mnuEliminar As ToolStripMenuItem
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents BtnAnular As Button
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader28 As ColumnHeader
    Friend WithEvents ColumnHeader29 As ColumnHeader
    Friend WithEvents ColumnHeader30 As ColumnHeader
    Friend WithEvents grpStock As GroupBox
    Friend WithEvents Label50 As Label
    Friend WithEvents txtObservsEstado As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents rbtnNoConforme As RadioButton
    Friend WithEvents rbtnConforme As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboEstados As ComboBox
    Friend WithEvents btnCancelar As Button
End Class
