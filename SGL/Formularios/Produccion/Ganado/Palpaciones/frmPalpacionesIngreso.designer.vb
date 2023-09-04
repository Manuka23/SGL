<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPalpacionesIngreso
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPalpacionesIngreso))
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.cboVeterinarios = New System.Windows.Forms.ComboBox()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblRepetidos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSecaPrn = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.lblPreñadas = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.lblDudosa = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.lblAnestro = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.lvPALPACIONES = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuGanado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopiarDiio = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboCondiciones = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.MenuGanado.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(985, 70)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 30)
        Me.btnBuscar.TabIndex = 56
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(384, 576)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 30)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Imprime"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(291, 576)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(87, 30)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "   a Bastón"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(477, 575)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(87, 30)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "a Pdf"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(198, 576)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 10
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox6.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Location = New System.Drawing.Point(387, 52)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(277, 50)
        Me.GroupBox6.TabIndex = 16
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Rango de Fecha"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(181, 20)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(87, 22)
        Me.dtpFechaHasta.TabIndex = 55
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(53, 20)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(87, 22)
        Me.dtpFechaDesde.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(985, 576)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 27
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.cboVeterinarios)
        Me.GroupBox11.Location = New System.Drawing.Point(198, 52)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(184, 50)
        Me.GroupBox11.TabIndex = 61
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Veterinario"
        '
        'cboVeterinarios
        '
        Me.cboVeterinarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVeterinarios.FormattingEnabled = True
        Me.cboVeterinarios.Location = New System.Drawing.Point(12, 19)
        Me.cboVeterinarios.Name = "cboVeterinarios"
        Me.cboVeterinarios.Size = New System.Drawing.Size(163, 22)
        Me.cboVeterinarios.TabIndex = 0
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblRepetidos)
        Me.pnlEstReprod.Controls.Add(Me.Label6)
        Me.pnlEstReprod.Controls.Add(Me.Label85)
        Me.pnlEstReprod.Controls.Add(Me.Label4)
        Me.pnlEstReprod.Controls.Add(Me.lblSecaPrn)
        Me.pnlEstReprod.Controls.Add(Me.Label47)
        Me.pnlEstReprod.Controls.Add(Me.lblPreñadas)
        Me.pnlEstReprod.Controls.Add(Me.Label51)
        Me.pnlEstReprod.Controls.Add(Me.Label52)
        Me.pnlEstReprod.Controls.Add(Me.Label53)
        Me.pnlEstReprod.Controls.Add(Me.lblDudosa)
        Me.pnlEstReprod.Controls.Add(Me.Label55)
        Me.pnlEstReprod.Controls.Add(Me.lblAnestro)
        Me.pnlEstReprod.Controls.Add(Me.Label60)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(12, 544)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1060, 25)
        Me.pnlEstReprod.TabIndex = 62
        '
        'lblRepetidos
        '
        Me.lblRepetidos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepetidos.Location = New System.Drawing.Point(299, 2)
        Me.lblRepetidos.Name = "lblRepetidos"
        Me.lblRepetidos.Size = New System.Drawing.Size(43, 21)
        Me.lblRepetidos.TabIndex = 46
        Me.lblRepetidos.Text = "0"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(222, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 21)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "REPETIDOS"
        '
        'Label85
        '
        Me.Label85.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.Location = New System.Drawing.Point(137, 2)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(74, 21)
        Me.Label85.TabIndex = 1
        Me.Label85.Text = "0"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(151, 21)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "TOTAL PALPACIONES"
        '
        'lblSecaPrn
        '
        Me.lblSecaPrn.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSecaPrn.Location = New System.Drawing.Point(596, 2)
        Me.lblSecaPrn.Name = "lblSecaPrn"
        Me.lblSecaPrn.Size = New System.Drawing.Size(55, 21)
        Me.lblSecaPrn.TabIndex = 43
        Me.lblSecaPrn.Text = "0"
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(524, 2)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(69, 21)
        Me.Label47.TabIndex = 42
        Me.Label47.Text = "SECA PRN"
        '
        'lblPreñadas
        '
        Me.lblPreñadas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreñadas.Location = New System.Drawing.Point(443, 2)
        Me.lblPreñadas.Name = "lblPreñadas"
        Me.lblPreñadas.Size = New System.Drawing.Size(55, 21)
        Me.lblPreñadas.TabIndex = 41
        Me.lblPreñadas.Text = "0"
        '
        'Label51
        '
        Me.Label51.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(373, 2)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(71, 21)
        Me.Label51.TabIndex = 40
        Me.Label51.Text = "PREÑADA"
        '
        'Label52
        '
        Me.Label52.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(994, 2)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(55, 21)
        Me.Label52.TabIndex = 39
        Me.Label52.Text = "0"
        '
        'Label53
        '
        Me.Label53.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(943, 2)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(54, 21)
        Me.Label53.TabIndex = 38
        Me.Label53.Text = "OTROS"
        '
        'lblDudosa
        '
        Me.lblDudosa.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDudosa.Location = New System.Drawing.Point(740, 2)
        Me.lblDudosa.Name = "lblDudosa"
        Me.lblDudosa.Size = New System.Drawing.Size(55, 21)
        Me.lblDudosa.TabIndex = 37
        Me.lblDudosa.Text = "0"
        '
        'Label55
        '
        Me.Label55.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(675, 2)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(63, 21)
        Me.Label55.TabIndex = 36
        Me.Label55.Text = "DUDOSA"
        '
        'lblAnestro
        '
        Me.lblAnestro.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnestro.Location = New System.Drawing.Point(880, 2)
        Me.lblAnestro.Name = "lblAnestro"
        Me.lblAnestro.Size = New System.Drawing.Size(55, 21)
        Me.lblAnestro.TabIndex = 31
        Me.lblAnestro.Text = "0"
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.Window
        Me.Label60.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(815, 2)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(81, 21)
        Me.Label60.TabIndex = 30
        Me.Label60.Text = "ANESTRO"
        '
        'lvPALPACIONES
        '
        Me.lvPALPACIONES.AutoArrange = False
        Me.lvPALPACIONES.BackColor = System.Drawing.SystemColors.Window
        Me.lvPALPACIONES.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader0, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader5, Me.ColumnHeader7, Me.ColumnHeader10})
        Me.lvPALPACIONES.FullRowSelect = True
        Me.lvPALPACIONES.GridLines = True
        Me.lvPALPACIONES.HideSelection = False
        Me.lvPALPACIONES.Location = New System.Drawing.Point(12, 133)
        Me.lvPALPACIONES.MultiSelect = False
        Me.lvPALPACIONES.Name = "lvPALPACIONES"
        Me.lvPALPACIONES.Size = New System.Drawing.Size(1060, 405)
        Me.lvPALPACIONES.TabIndex = 64
        Me.lvPALPACIONES.UseCompatibleStateImageBehavior = False
        Me.lvPALPACIONES.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Ordena"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Empresa"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Centro"
        Me.ColumnHeader2.Width = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DIIO"
        Me.ColumnHeader3.Width = 70
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Categoría"
        Me.ColumnHeader4.Width = 90
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Fecha Palp."
        Me.ColumnHeader11.Width = 100
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Veterinario"
        Me.ColumnHeader12.Width = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Est. Productivo"
        Me.ColumnHeader8.Width = 105
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Est Reproductivo"
        Me.ColumnHeader9.Width = 105
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Condición"
        Me.ColumnHeader5.Width = 90
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "D. Gest."
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Toro"
        Me.ColumnHeader10.Width = 110
        '
        'MenuGanado
        '
        Me.MenuGanado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVerDetalle, Me.ToolStripMenuItem1, Me.mnuCopiarDiio})
        Me.MenuGanado.Name = "MenuGanado"
        Me.MenuGanado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuGanado.Size = New System.Drawing.Size(219, 54)
        '
        'mnuVerDetalle
        '
        Me.mnuVerDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuVerDetalle.Name = "mnuVerDetalle"
        Me.mnuVerDetalle.Size = New System.Drawing.Size(218, 22)
        Me.mnuVerDetalle.Text = "Ver Detalle DIIO"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(215, 6)
        '
        'mnuCopiarDiio
        '
        Me.mnuCopiarDiio.Name = "mnuCopiarDiio"
        Me.mnuCopiarDiio.Size = New System.Drawing.Size(218, 22)
        Me.mnuCopiarDiio.Text = "Copiar DIIO al portapapeles"
        '
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(213, 269)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(655, 53)
        Me.pnlProcesa.TabIndex = 68
        Me.pnlProcesa.Visible = False
        '
        'lblProcesa
        '
        Me.lblProcesa.AutoSize = True
        Me.lblProcesa.Location = New System.Drawing.Point(9, 9)
        Me.lblProcesa.Name = "lblProcesa"
        Me.lblProcesa.Size = New System.Drawing.Size(77, 14)
        Me.lblProcesa.TabIndex = 69
        Me.lblProcesa.Text = "Exportando..."
        '
        'pbProcesa
        '
        Me.pbProcesa.Location = New System.Drawing.Point(12, 23)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(625, 18)
        Me.pbProcesa.TabIndex = 68
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(884, 70)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(98, 30)
        Me.btnLimpiarFiltros.TabIndex = 69
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 50)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(12, 19)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(157, 22)
        Me.cboCentros.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 576)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 71
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboCondiciones)
        Me.GroupBox2.Location = New System.Drawing.Point(670, 52)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 50)
        Me.GroupBox2.TabIndex = 72
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Condiciones"
        '
        'cboCondiciones
        '
        Me.cboCondiciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondiciones.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondiciones.FormattingEnabled = True
        Me.cboCondiciones.Location = New System.Drawing.Point(6, 15)
        Me.cboCondiciones.Name = "cboCondiciones"
        Me.cboCondiciones.Size = New System.Drawing.Size(143, 26)
        Me.cboCondiciones.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-4, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1097, 41)
        Me.Panel1.TabIndex = 73
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1060, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "PALPACIONES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnImportar
        '
        Me.btnImportar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportar.Location = New System.Drawing.Point(105, 576)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(87, 30)
        Me.btnImportar.TabIndex = 74
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltro.Image = CType(resources.GetObject("btnLimpiarFiltro.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(831, 70)
        Me.btnLimpiarFiltro.Name = "btnLimpiarFiltro"
        Me.btnLimpiarFiltro.Size = New System.Drawing.Size(50, 30)
        Me.btnLimpiarFiltro.TabIndex = 76
        Me.ToolTip1.SetToolTip(Me.btnLimpiarFiltro, "LIMPIAR ORDEN DE DATOS")
        Me.btnLimpiarFiltro.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblOrden)
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(12, 106)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1060, 23)
        Me.Panel2.TabIndex = 75
        '
        'lblOrden
        '
        Me.lblOrden.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.ForeColor = System.Drawing.Color.White
        Me.lblOrden.Location = New System.Drawing.Point(115, 1)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(934, 19)
        Me.lblOrden.TabIndex = 0
        Me.lblOrden.Text = "Centro -> DIIO"
        Me.lblOrden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(8, 1)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(121, 19)
        Me.Label61.TabIndex = 1
        Me.Label61.Text = "ORDENAR POR:"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'OpenFDlg
        '
        Me.OpenFDlg.FileName = "OpenFileDialog1"
        '
        'frmPalpacionesIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 612)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.lvPALPACIONES)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPalpacionesIngreso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Palpaciones"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.MenuGanado.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents cboVeterinarios As System.Windows.Forms.ComboBox
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents lblSecaPrn As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents lblPreñadas As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents lblDudosa As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents lblAnestro As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents lvPALPACIONES As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnLimpiarFiltro As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRepetidos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MenuGanado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCopiarDiio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboCondiciones As ComboBox
End Class
