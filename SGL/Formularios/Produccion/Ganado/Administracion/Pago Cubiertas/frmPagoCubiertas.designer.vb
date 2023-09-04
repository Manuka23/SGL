<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPagoCubiertas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPagoCubiertas))
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.cboInseminadores = New System.Windows.Forms.ComboBox()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.lvGanado = New System.Windows.Forms.ListView()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkVerBlancos = New System.Windows.Forms.CheckBox()
        Me.chkVerResumen = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboToros = New System.Windows.Forms.ComboBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox11.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(1038, 70)
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
        Me.Button6.Location = New System.Drawing.Point(105, 576)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 30)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Imprime"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(12, 576)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 10
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1038, 576)
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
        Me.GroupBox11.Controls.Add(Me.cboInseminadores)
        Me.GroupBox11.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(248, 50)
        Me.GroupBox11.TabIndex = 61
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Inseminador"
        '
        'cboInseminadores
        '
        Me.cboInseminadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInseminadores.FormattingEnabled = True
        Me.cboInseminadores.Location = New System.Drawing.Point(12, 19)
        Me.cboInseminadores.Name = "cboInseminadores"
        Me.cboInseminadores.Size = New System.Drawing.Size(228, 22)
        Me.cboInseminadores.TabIndex = 0
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.Label4)
        Me.pnlEstReprod.Controls.Add(Me.Label59)
        Me.pnlEstReprod.Controls.Add(Me.Label60)
        Me.pnlEstReprod.Controls.Add(Me.Label85)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(12, 544)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1113, 25)
        Me.pnlEstReprod.TabIndex = 62
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(131, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 21)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "CANTIDAD REGISTROS"
        '
        'Label59
        '
        Me.Label59.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(878, 2)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(55, 21)
        Me.Label59.TabIndex = 31
        Me.Label59.Text = "0"
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.SystemColors.Window
        Me.Label60.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(709, 2)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(183, 21)
        Me.Label60.TabIndex = 30
        Me.Label60.Text = "TOTAL INSEMINACIONES"
        '
        'Label85
        '
        Me.Label85.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.Location = New System.Drawing.Point(282, 2)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(87, 21)
        Me.Label85.TabIndex = 1
        Me.Label85.Text = "0"
        '
        'lvGanado
        '
        Me.lvGanado.AllowColumnReorder = True
        Me.lvGanado.AutoArrange = False
        Me.lvGanado.BackColor = System.Drawing.SystemColors.Window
        Me.lvGanado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.ColumnHeader2, Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader5, Me.ColumnHeader7})
        Me.lvGanado.FullRowSelect = True
        Me.lvGanado.GridLines = True
        Me.lvGanado.HideSelection = False
        Me.lvGanado.Location = New System.Drawing.Point(12, 133)
        Me.lvGanado.MultiSelect = False
        Me.lvGanado.Name = "lvGanado"
        Me.lvGanado.Size = New System.Drawing.Size(1113, 405)
        Me.lvGanado.TabIndex = 64
        Me.lvGanado.UseCompatibleStateImageBehavior = False
        Me.lvGanado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Inseminador"
        Me.ColumnHeader2.Width = 320
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Centro"
        Me.ColumnHeader1.Width = 230
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Fecha Ins."
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DIIO"
        Me.ColumnHeader3.Width = 90
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Toro"
        Me.ColumnHeader6.Width = 170
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cantidad"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Estado. Animal"
        Me.ColumnHeader7.Width = 135
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Location = New System.Drawing.Point(266, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(173, 50)
        Me.GroupBox1.TabIndex = 70
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(6, 19)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(156, 22)
        Me.cboCentros.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-4, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1327, 41)
        Me.Panel1.TabIndex = 73
        '
        'chkVerBlancos
        '
        Me.chkVerBlancos.AutoSize = True
        Me.chkVerBlancos.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkVerBlancos.Location = New System.Drawing.Point(857, 588)
        Me.chkVerBlancos.Name = "chkVerBlancos"
        Me.chkVerBlancos.Size = New System.Drawing.Size(89, 18)
        Me.chkVerBlancos.TabIndex = 78
        Me.chkVerBlancos.Text = "Ver Blancos"
        Me.chkVerBlancos.UseVisualStyleBackColor = True
        Me.chkVerBlancos.Visible = False
        '
        'chkVerResumen
        '
        Me.chkVerResumen.AutoSize = True
        Me.chkVerResumen.ForeColor = System.Drawing.SystemColors.WindowText
        Me.chkVerResumen.Location = New System.Drawing.Point(878, 82)
        Me.chkVerResumen.Name = "chkVerResumen"
        Me.chkVerResumen.Size = New System.Drawing.Size(97, 18)
        Me.chkVerResumen.TabIndex = 79
        Me.chkVerResumen.Text = "Ver Resumen"
        Me.chkVerResumen.UseVisualStyleBackColor = True
        Me.chkVerResumen.Visible = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1113, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "PAGO DE INSEMINACIONES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltro.Image = CType(resources.GetObject("btnLimpiarFiltro.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(982, 70)
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
        Me.Panel2.Size = New System.Drawing.Size(1113, 23)
        Me.Panel2.TabIndex = 75
        '
        'lblOrden
        '
        Me.lblOrden.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.ForeColor = System.Drawing.Color.White
        Me.lblOrden.Location = New System.Drawing.Point(115, 1)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(993, 19)
        Me.lblOrden.TabIndex = 0
        Me.lblOrden.Text = "Inseminador -> Centro -> Fecha Ins. -> DIIO"
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboToros)
        Me.GroupBox3.Location = New System.Drawing.Point(445, 50)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(144, 50)
        Me.GroupBox3.TabIndex = 77
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Toro"
        '
        'cboToros
        '
        Me.cboToros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToros.FormattingEnabled = True
        Me.cboToros.Location = New System.Drawing.Point(6, 19)
        Me.cboToros.Name = "cboToros"
        Me.cboToros.Size = New System.Drawing.Size(130, 22)
        Me.cboToros.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox6.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Location = New System.Drawing.Point(595, 50)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(277, 50)
        Me.GroupBox6.TabIndex = 144
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
        'frmPagoCubiertas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1139, 612)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkVerBlancos)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.chkVerResumen)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.lvGanado)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPagoCubiertas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pago Cubiertas"
        Me.GroupBox11.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents cboInseminadores As System.Windows.Forms.ComboBox
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents lvGanado As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarFiltro As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents OpenFDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboToros As System.Windows.Forms.ComboBox
    Friend WithEvents chkVerBlancos As System.Windows.Forms.CheckBox
    Friend WithEvents chkVerResumen As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
End Class
