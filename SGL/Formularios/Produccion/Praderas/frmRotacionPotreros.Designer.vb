<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRotacionPotreros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRotacionPotreros))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblConsumoActual = New System.Windows.Forms.Label()
        Me.lblConsumoOptimo = New System.Windows.Forms.Label()
        Me.lblTotHasDia = New System.Windows.Forms.Label()
        Me.lblTotHasCen = New System.Windows.Forms.Label()
        Me.lblTotalAnterior = New System.Windows.Forms.Label()
        Me.lblTotalCobertura = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblNroPotreros = New System.Windows.Forms.Label()
        Me.gboxIngMediciones = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvRP_Potreros = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.tabPASTO = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnMax2 = New System.Windows.Forms.Button()
        Me.btnMin2 = New System.Windows.Forms.Button()
        Me.btnMax1 = New System.Windows.Forms.Button()
        Me.btnMin1 = New System.Windows.Forms.Button()
        Me.chartRP_UltCobertura = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.chartDiasLibrexPotrero = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.WebBrowser = New System.Windows.Forms.WebBrowser()
        Me.lblErrNomArchivo = New System.Windows.Forms.Label()
        Me.panel = New System.Windows.Forms.GroupBox()
        Me.txtPostGrazing = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtPreGrazing = New System.Windows.Forms.TextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtCreciDiario = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtPFijo = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPEstacional = New System.Windows.Forms.TextBox()
        Me.PrintPreviewDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtRotacion = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtDiasAcum = New System.Windows.Forms.TextBox()
        Me.lblTotHasAcum = New System.Windows.Forms.Label()
        Me.lblRotacionActual = New System.Windows.Forms.Label()
        Me.grpTotPot = New System.Windows.Forms.GroupBox()
        Me.grpTotHas = New System.Windows.Forms.GroupBox()
        Me.grpTotHasDia = New System.Windows.Forms.GroupBox()
        Me.grpTotHasAcum = New System.Windows.Forms.GroupBox()
        Me.grpRotacionActual = New System.Windows.Forms.GroupBox()
        Me.grpConsumoActual = New System.Windows.Forms.GroupBox()
        Me.grpConsumoOptimo = New System.Windows.Forms.GroupBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.lblTotHasEfect = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnImprime = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Categoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Superficie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cobertura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiasLibres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pastoreo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ensilaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PastoreoAcum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gboxIngMediciones.SuspendLayout()
        CType(Me.dgvRP_Potreros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabPASTO.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.chartRP_UltCobertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartDiasLibrexPotrero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.panel.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.grpTotPot.SuspendLayout()
        Me.grpTotHas.SuspendLayout()
        Me.grpTotHasDia.SuspendLayout()
        Me.grpTotHasAcum.SuspendLayout()
        Me.grpRotacionActual.SuspendLayout()
        Me.grpConsumoActual.SuspendLayout()
        Me.grpConsumoOptimo.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblConsumoActual
        '
        Me.lblConsumoActual.BackColor = System.Drawing.Color.PowderBlue
        Me.lblConsumoActual.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsumoActual.Location = New System.Drawing.Point(6, 17)
        Me.lblConsumoActual.Name = "lblConsumoActual"
        Me.lblConsumoActual.Size = New System.Drawing.Size(103, 21)
        Me.lblConsumoActual.TabIndex = 61
        Me.lblConsumoActual.Text = "0"
        Me.lblConsumoActual.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblConsumoOptimo
        '
        Me.lblConsumoOptimo.BackColor = System.Drawing.SystemColors.Info
        Me.lblConsumoOptimo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsumoOptimo.Location = New System.Drawing.Point(6, 17)
        Me.lblConsumoOptimo.Name = "lblConsumoOptimo"
        Me.lblConsumoOptimo.Size = New System.Drawing.Size(103, 21)
        Me.lblConsumoOptimo.TabIndex = 59
        Me.lblConsumoOptimo.Text = "0"
        Me.lblConsumoOptimo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotHasDia
        '
        Me.lblTotHasDia.BackColor = System.Drawing.Color.White
        Me.lblTotHasDia.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotHasDia.Location = New System.Drawing.Point(6, 17)
        Me.lblTotHasDia.Name = "lblTotHasDia"
        Me.lblTotHasDia.Size = New System.Drawing.Size(76, 21)
        Me.lblTotHasDia.TabIndex = 57
        Me.lblTotHasDia.Text = "0"
        Me.lblTotHasDia.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotHasCen
        '
        Me.lblTotHasCen.BackColor = System.Drawing.Color.Transparent
        Me.lblTotHasCen.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotHasCen.Location = New System.Drawing.Point(6, 17)
        Me.lblTotHasCen.Name = "lblTotHasCen"
        Me.lblTotHasCen.Size = New System.Drawing.Size(54, 21)
        Me.lblTotHasCen.TabIndex = 55
        Me.lblTotHasCen.Text = "0"
        Me.lblTotHasCen.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotalAnterior
        '
        Me.lblTotalAnterior.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalAnterior.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAnterior.Location = New System.Drawing.Point(951, 615)
        Me.lblTotalAnterior.Name = "lblTotalAnterior"
        Me.lblTotalAnterior.Size = New System.Drawing.Size(50, 21)
        Me.lblTotalAnterior.TabIndex = 53
        Me.lblTotalAnterior.Text = "0"
        Me.lblTotalAnterior.Visible = False
        '
        'lblTotalCobertura
        '
        Me.lblTotalCobertura.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCobertura.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCobertura.Location = New System.Drawing.Point(834, 615)
        Me.lblTotalCobertura.Name = "lblTotalCobertura"
        Me.lblTotalCobertura.Size = New System.Drawing.Size(50, 21)
        Me.lblTotalCobertura.TabIndex = 51
        Me.lblTotalCobertura.Text = "0"
        Me.lblTotalCobertura.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(777, 615)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 21)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Cobertura Actual"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(890, 615)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 21)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Cobertura Anterior"
        Me.Label3.Visible = False
        '
        'lblNroPotreros
        '
        Me.lblNroPotreros.BackColor = System.Drawing.Color.Transparent
        Me.lblNroPotreros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroPotreros.Location = New System.Drawing.Point(6, 17)
        Me.lblNroPotreros.Name = "lblNroPotreros"
        Me.lblNroPotreros.Size = New System.Drawing.Size(54, 21)
        Me.lblNroPotreros.TabIndex = 49
        Me.lblNroPotreros.Text = "0"
        Me.lblNroPotreros.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'gboxIngMediciones
        '
        Me.gboxIngMediciones.Controls.Add(Me.Label12)
        Me.gboxIngMediciones.Controls.Add(Me.Label11)
        Me.gboxIngMediciones.Controls.Add(Me.Label10)
        Me.gboxIngMediciones.Controls.Add(Me.Label8)
        Me.gboxIngMediciones.Controls.Add(Me.Label1)
        Me.gboxIngMediciones.Controls.Add(Me.dgvRP_Potreros)
        Me.gboxIngMediciones.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxIngMediciones.Location = New System.Drawing.Point(3, 59)
        Me.gboxIngMediciones.Name = "gboxIngMediciones"
        Me.gboxIngMediciones.Size = New System.Drawing.Size(487, 499)
        Me.gboxIngMediciones.TabIndex = 226
        Me.gboxIngMediciones.TabStop = False
        Me.gboxIngMediciones.Text = "Ingreso Pastoreo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(216, 464)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 13)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Tipo Pasto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(63, 464)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Tipo Cultivo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(63, 464)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 68
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(171, 464)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 18)
        Me.Label8.TabIndex = 67
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Orange
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 464)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 18)
        Me.Label1.TabIndex = 66
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'dgvRP_Potreros
        '
        Me.dgvRP_Potreros.AllowUserToAddRows = False
        Me.dgvRP_Potreros.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvRP_Potreros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRP_Potreros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Categoria, Me.Superficie, Me.Cobertura, Me.DiasLibres, Me.Pastoreo, Me.Ensilaje, Me.PastoreoAcum, Me.Tipo, Me.Column1})
        Me.dgvRP_Potreros.Location = New System.Drawing.Point(6, 22)
        Me.dgvRP_Potreros.Name = "dgvRP_Potreros"
        Me.dgvRP_Potreros.RowHeadersVisible = False
        Me.dgvRP_Potreros.RowTemplate.Height = 20
        Me.dgvRP_Potreros.ShowEditingIcon = False
        Me.dgvRP_Potreros.Size = New System.Drawing.Size(477, 425)
        Me.dgvRP_Potreros.TabIndex = 15
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtpFecha)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(267, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(135, 57)
        Me.GroupBox5.TabIndex = 221
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(14, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(111, 26)
        Me.dtpFecha.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(258, 57)
        Me.GroupBox1.TabIndex = 220
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(8, 20)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(244, 26)
        Me.cboCentros.TabIndex = 0
        '
        'tabPASTO
        '
        Me.tabPASTO.Controls.Add(Me.TabPage1)
        Me.tabPASTO.Controls.Add(Me.TabPage2)
        Me.tabPASTO.Location = New System.Drawing.Point(492, 58)
        Me.tabPASTO.Name = "tabPASTO"
        Me.tabPASTO.SelectedIndex = 0
        Me.tabPASTO.Size = New System.Drawing.Size(734, 499)
        Me.tabPASTO.TabIndex = 232
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.btnMax2)
        Me.TabPage1.Controls.Add(Me.btnMin2)
        Me.TabPage1.Controls.Add(Me.btnMax1)
        Me.TabPage1.Controls.Add(Me.btnMin1)
        Me.TabPage1.Controls.Add(Me.chartRP_UltCobertura)
        Me.TabPage1.Controls.Add(Me.chartDiasLibrexPotrero)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(726, 473)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Gráficos Coberturas y Crecimiento"
        '
        'btnMax2
        '
        Me.btnMax2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnMax2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMax2.FlatAppearance.BorderSize = 0
        Me.btnMax2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMax2.Image = CType(resources.GetObject("btnMax2.Image"), System.Drawing.Image)
        Me.btnMax2.Location = New System.Drawing.Point(671, 251)
        Me.btnMax2.Name = "btnMax2"
        Me.btnMax2.Size = New System.Drawing.Size(33, 29)
        Me.btnMax2.TabIndex = 227
        Me.btnMax2.UseVisualStyleBackColor = False
        '
        'btnMin2
        '
        Me.btnMin2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnMin2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMin2.FlatAppearance.BorderSize = 0
        Me.btnMin2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin2.Image = CType(resources.GetObject("btnMin2.Image"), System.Drawing.Image)
        Me.btnMin2.Location = New System.Drawing.Point(671, 251)
        Me.btnMin2.Name = "btnMin2"
        Me.btnMin2.Size = New System.Drawing.Size(33, 29)
        Me.btnMin2.TabIndex = 228
        Me.btnMin2.UseVisualStyleBackColor = False
        '
        'btnMax1
        '
        Me.btnMax1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.btnMax1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMax1.FlatAppearance.BorderSize = 0
        Me.btnMax1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMax1.Image = CType(resources.GetObject("btnMax1.Image"), System.Drawing.Image)
        Me.btnMax1.Location = New System.Drawing.Point(671, 14)
        Me.btnMax1.Name = "btnMax1"
        Me.btnMax1.Size = New System.Drawing.Size(33, 29)
        Me.btnMax1.TabIndex = 225
        Me.btnMax1.UseVisualStyleBackColor = False
        '
        'btnMin1
        '
        Me.btnMin1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.btnMin1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMin1.FlatAppearance.BorderSize = 0
        Me.btnMin1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMin1.Image = CType(resources.GetObject("btnMin1.Image"), System.Drawing.Image)
        Me.btnMin1.Location = New System.Drawing.Point(671, 14)
        Me.btnMin1.Name = "btnMin1"
        Me.btnMin1.Size = New System.Drawing.Size(33, 29)
        Me.btnMin1.TabIndex = 226
        Me.btnMin1.UseVisualStyleBackColor = False
        '
        'chartRP_UltCobertura
        '
        Me.chartRP_UltCobertura.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.chartRP_UltCobertura.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.chartRP_UltCobertura.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(181, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.chartRP_UltCobertura.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.chartRP_UltCobertura.BorderlineWidth = 2
        Me.chartRP_UltCobertura.BorderSkin.BackColor = System.Drawing.Color.White
        Me.chartRP_UltCobertura.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea1.Area3DStyle.Inclination = 40
        ChartArea1.Area3DStyle.IsClustered = True
        ChartArea1.Area3DStyle.IsRightAngleAxes = False
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea1.Area3DStyle.Perspective = 9
        ChartArea1.Area3DStyle.Rotation = 25
        ChartArea1.Area3DStyle.WallWidth = 3
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Angle = -90
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.Title = "Coberturas por Potrero"
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.Title = "Kg DM / ha"
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.BackColor = System.Drawing.Color.OldLace
        ChartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea1.BackSecondaryColor = System.Drawing.Color.White
        ChartArea1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        ChartArea1.Name = "Default"
        ChartArea1.ShadowColor = System.Drawing.Color.Transparent
        Me.chartRP_UltCobertura.ChartAreas.Add(ChartArea1)
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Enabled = False
        Legend1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Default"
        Me.chartRP_UltCobertura.Legends.Add(Legend1)
        Me.chartRP_UltCobertura.Location = New System.Drawing.Point(9, 2)
        Me.chartRP_UltCobertura.Name = "chartRP_UltCobertura"
        Series1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Series1.ChartArea = "Default"
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Series1.CustomProperties = "MaxPixelPointWidth=8"
        Series1.Legend = "Default"
        Series1.LegendText = "Coberturas Potreros"
        Series1.MarkerSize = 4
        Series1.Name = "Series1"
        Series1.ShadowColor = System.Drawing.Color.Gray
        Series1.ShadowOffset = 1
        Series2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Series2.BorderWidth = 2
        Series2.ChartArea = "Default"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Color = System.Drawing.Color.Red
        Series2.Legend = "Default"
        Series2.LegendText = "Tarjet"
        Series2.MarkerSize = 9
        Series2.Name = "Series2"
        Series2.ShadowColor = System.Drawing.Color.Gray
        Series2.ShadowOffset = 2
        Me.chartRP_UltCobertura.Series.Add(Series1)
        Me.chartRP_UltCobertura.Series.Add(Series2)
        Me.chartRP_UltCobertura.Size = New System.Drawing.Size(717, 232)
        Me.chartRP_UltCobertura.TabIndex = 222
        Title1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title1.Name = "Title1"
        Title1.ShadowColor = System.Drawing.Color.Silver
        Title1.Text = "Última Cobertura de Pasto"
        Me.chartRP_UltCobertura.Titles.Add(Title1)
        '
        'chartDiasLibrexPotrero
        '
        Me.chartDiasLibrexPotrero.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.Text
        Me.chartDiasLibrexPotrero.BackColor = System.Drawing.Color.LightSteelBlue
        Me.chartDiasLibrexPotrero.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.chartDiasLibrexPotrero.BackImageTransparentColor = System.Drawing.Color.Transparent
        Me.chartDiasLibrexPotrero.BackSecondaryColor = System.Drawing.Color.White
        Me.chartDiasLibrexPotrero.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.chartDiasLibrexPotrero.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.chartDiasLibrexPotrero.BorderlineWidth = 2
        Me.chartDiasLibrexPotrero.BorderSkin.BackColor = System.Drawing.Color.White
        Me.chartDiasLibrexPotrero.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea2.Area3DStyle.Inclination = 50
        ChartArea2.Area3DStyle.IsClustered = True
        ChartArea2.Area3DStyle.IsRightAngleAxes = False
        ChartArea2.Area3DStyle.PointGapDepth = 900
        ChartArea2.Area3DStyle.Rotation = 162
        ChartArea2.Area3DStyle.WallWidth = 25
        ChartArea2.AxisX.Interval = 1.0R
        ChartArea2.AxisX.IsLabelAutoFit = False
        ChartArea2.AxisX.LabelStyle.Angle = -50
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisX.MajorTickMark.Enabled = False
        ChartArea2.AxisX.Title = "Potreros"
        ChartArea2.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea2.AxisX2.MajorGrid.Enabled = False
        ChartArea2.AxisX2.MajorTickMark.Enabled = False
        ChartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea2.AxisY.IsLabelAutoFit = False
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Green
        ChartArea2.AxisY.LineColor = System.Drawing.Color.Navy
        ChartArea2.AxisY.LineWidth = 2
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisY.MajorTickMark.Enabled = False
        ChartArea2.AxisY.Title = "Días Libres"
        ChartArea2.AxisY.TitleFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY.TitleForeColor = System.Drawing.Color.Navy
        ChartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[False]
        ChartArea2.AxisY2.IsLabelAutoFit = False
        ChartArea2.AxisY2.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.RoyalBlue
        ChartArea2.AxisY2.LineColor = System.Drawing.Color.RoyalBlue
        ChartArea2.AxisY2.LineWidth = 2
        ChartArea2.AxisY2.MajorGrid.Enabled = False
        ChartArea2.AxisY2.MajorTickMark.Enabled = False
        ChartArea2.AxisY2.TitleFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY2.TitleForeColor = System.Drawing.Color.RoyalBlue
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea2.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.Name = "Area1"
        ChartArea2.ShadowColor = System.Drawing.Color.Transparent
        Me.chartDiasLibrexPotrero.ChartAreas.Add(ChartArea2)
        Me.chartDiasLibrexPotrero.IsSoftShadows = False
        Legend2.Alignment = System.Drawing.StringAlignment.Center
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend2.Font = New System.Drawing.Font("Trebuchet MS", 8.0!, System.Drawing.FontStyle.Bold)
        Legend2.IsEquallySpacedItems = True
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Default"
        Me.chartDiasLibrexPotrero.Legends.Add(Legend2)
        Me.chartDiasLibrexPotrero.Location = New System.Drawing.Point(9, 237)
        Me.chartDiasLibrexPotrero.Name = "chartDiasLibrexPotrero"
        Series3.BorderWidth = 2
        Series3.ChartArea = "Area1"
        Series3.Color = System.Drawing.Color.LemonChiffon
        Series3.CustomProperties = "LabelStyle=Bottom"
        Series3.EmptyPointStyle.Color = System.Drawing.Color.Red
        Series3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series3.IsXValueIndexed = True
        Series3.Label = "#VAL{N0}"
        Series3.LabelForeColor = System.Drawing.Color.DarkBlue
        Series3.Legend = "Default"
        Series3.LegendText = "Días Libres"
        Series3.Name = "Series1"
        Series3.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Series3.ShadowOffset = 2
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
        Me.chartDiasLibrexPotrero.Series.Add(Series3)
        Me.chartDiasLibrexPotrero.Size = New System.Drawing.Size(717, 232)
        Me.chartDiasLibrexPotrero.TabIndex = 224
        Title2.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title2.Name = "Title1"
        Title2.ShadowColor = System.Drawing.Color.White
        Title2.Text = "Días Libres x Potrero"
        Me.chartDiasLibrexPotrero.Titles.Add(Title2)
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.WebBrowser)
        Me.TabPage2.Controls.Add(Me.lblErrNomArchivo)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(726, 473)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Mapa del Predio"
        '
        'WebBrowser
        '
        Me.WebBrowser.Location = New System.Drawing.Point(12, 11)
        Me.WebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser.Name = "WebBrowser"
        Me.WebBrowser.Size = New System.Drawing.Size(674, 113)
        Me.WebBrowser.TabIndex = 0
        '
        'lblErrNomArchivo
        '
        Me.lblErrNomArchivo.Font = New System.Drawing.Font("Calibri", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lblErrNomArchivo.Location = New System.Drawing.Point(0, 228)
        Me.lblErrNomArchivo.Name = "lblErrNomArchivo"
        Me.lblErrNomArchivo.Size = New System.Drawing.Size(716, 24)
        Me.lblErrNomArchivo.TabIndex = 2
        Me.lblErrNomArchivo.Text = "Para el predio seleccionado"
        Me.lblErrNomArchivo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'panel
        '
        Me.panel.Controls.Add(Me.txtPostGrazing)
        Me.panel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel.ForeColor = System.Drawing.Color.Black
        Me.panel.Location = New System.Drawing.Point(612, 3)
        Me.panel.Name = "panel"
        Me.panel.Size = New System.Drawing.Size(125, 43)
        Me.panel.TabIndex = 237
        Me.panel.TabStop = False
        Me.panel.Text = "Target Post-grazing"
        '
        'txtPostGrazing
        '
        Me.txtPostGrazing.BackColor = System.Drawing.Color.White
        Me.txtPostGrazing.Location = New System.Drawing.Point(12, 14)
        Me.txtPostGrazing.MaxLength = 5
        Me.txtPostGrazing.Name = "txtPostGrazing"
        Me.txtPostGrazing.Size = New System.Drawing.Size(64, 23)
        Me.txtPostGrazing.TabIndex = 1
        Me.txtPostGrazing.Text = "1500"
        Me.txtPostGrazing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox8.Controls.Add(Me.txtPreGrazing)
        Me.GroupBox8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Location = New System.Drawing.Point(492, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(120, 43)
        Me.GroupBox8.TabIndex = 236
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Target Pre-grazing"
        '
        'txtPreGrazing
        '
        Me.txtPreGrazing.BackColor = System.Drawing.Color.White
        Me.txtPreGrazing.Location = New System.Drawing.Point(13, 15)
        Me.txtPreGrazing.MaxLength = 5
        Me.txtPreGrazing.Name = "txtPreGrazing"
        Me.txtPreGrazing.Size = New System.Drawing.Size(56, 23)
        Me.txtPreGrazing.TabIndex = 0
        Me.txtPreGrazing.Text = "3000"
        Me.txtPreGrazing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtCreciDiario)
        Me.GroupBox6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Location = New System.Drawing.Point(941, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(88, 43)
        Me.GroupBox6.TabIndex = 235
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Crec. Diario"
        '
        'txtCreciDiario
        '
        Me.txtCreciDiario.BackColor = System.Drawing.SystemColors.Control
        Me.txtCreciDiario.Enabled = False
        Me.txtCreciDiario.Location = New System.Drawing.Point(12, 15)
        Me.txtCreciDiario.MaxLength = 3
        Me.txtCreciDiario.Name = "txtCreciDiario"
        Me.txtCreciDiario.Size = New System.Drawing.Size(66, 23)
        Me.txtCreciDiario.TabIndex = 1
        Me.txtCreciDiario.Text = "0"
        Me.txtCreciDiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtPFijo)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Location = New System.Drawing.Point(1132, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(89, 43)
        Me.GroupBox4.TabIndex = 234
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Param. Fijo"
        '
        'txtPFijo
        '
        Me.txtPFijo.BackColor = System.Drawing.SystemColors.Control
        Me.txtPFijo.Enabled = False
        Me.txtPFijo.Location = New System.Drawing.Point(11, 15)
        Me.txtPFijo.MaxLength = 3
        Me.txtPFijo.Name = "txtPFijo"
        Me.txtPFijo.Size = New System.Drawing.Size(73, 23)
        Me.txtPFijo.TabIndex = 1
        Me.txtPFijo.Text = "500"
        Me.txtPFijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPEstacional)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(1029, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(103, 43)
        Me.GroupBox2.TabIndex = 233
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Param. Estac."
        '
        'txtPEstacional
        '
        Me.txtPEstacional.BackColor = System.Drawing.SystemColors.Control
        Me.txtPEstacional.Enabled = False
        Me.txtPEstacional.Location = New System.Drawing.Point(11, 15)
        Me.txtPEstacional.MaxLength = 3
        Me.txtPEstacional.Name = "txtPEstacional"
        Me.txtPEstacional.Size = New System.Drawing.Size(67, 23)
        Me.txtPEstacional.TabIndex = 0
        Me.txtPEstacional.Text = "140"
        Me.txtPEstacional.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PrintPreviewDialog
        '
        Me.PrintPreviewDialog.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog.Enabled = True
        Me.PrintPreviewDialog.Icon = CType(resources.GetObject("PrintPreviewDialog.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog.Name = "PrintPreviewDialog"
        Me.PrintPreviewDialog.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtRotacion)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(745, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(98, 43)
        Me.GroupBox3.TabIndex = 236
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Rotación"
        '
        'txtRotacion
        '
        Me.txtRotacion.BackColor = System.Drawing.SystemColors.Info
        Me.txtRotacion.Location = New System.Drawing.Point(12, 15)
        Me.txtRotacion.MaxLength = 3
        Me.txtRotacion.Name = "txtRotacion"
        Me.txtRotacion.Size = New System.Drawing.Size(66, 23)
        Me.txtRotacion.TabIndex = 1
        Me.txtRotacion.Text = "75"
        Me.txtRotacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtDiasAcum)
        Me.GroupBox7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Black
        Me.GroupBox7.Location = New System.Drawing.Point(844, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(88, 43)
        Me.GroupBox7.TabIndex = 238
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Días Acum."
        '
        'txtDiasAcum
        '
        Me.txtDiasAcum.BackColor = System.Drawing.Color.PowderBlue
        Me.txtDiasAcum.Location = New System.Drawing.Point(12, 15)
        Me.txtDiasAcum.MaxLength = 3
        Me.txtDiasAcum.Name = "txtDiasAcum"
        Me.txtDiasAcum.Size = New System.Drawing.Size(66, 23)
        Me.txtDiasAcum.TabIndex = 1
        Me.txtDiasAcum.Text = "7"
        Me.txtDiasAcum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTotHasAcum
        '
        Me.lblTotHasAcum.BackColor = System.Drawing.Color.PowderBlue
        Me.lblTotHasAcum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotHasAcum.Location = New System.Drawing.Point(6, 17)
        Me.lblTotHasAcum.Name = "lblTotHasAcum"
        Me.lblTotHasAcum.Size = New System.Drawing.Size(117, 21)
        Me.lblTotHasAcum.TabIndex = 60
        Me.lblTotHasAcum.Text = "0"
        Me.lblTotHasAcum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblRotacionActual
        '
        Me.lblRotacionActual.BackColor = System.Drawing.Color.PowderBlue
        Me.lblRotacionActual.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRotacionActual.Location = New System.Drawing.Point(6, 17)
        Me.lblRotacionActual.Name = "lblRotacionActual"
        Me.lblRotacionActual.Size = New System.Drawing.Size(103, 21)
        Me.lblRotacionActual.TabIndex = 64
        Me.lblRotacionActual.Text = "0"
        Me.lblRotacionActual.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grpTotPot
        '
        Me.grpTotPot.Controls.Add(Me.lblNroPotreros)
        Me.grpTotPot.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTotPot.ForeColor = System.Drawing.Color.Black
        Me.grpTotPot.Location = New System.Drawing.Point(2, 564)
        Me.grpTotPot.Name = "grpTotPot"
        Me.grpTotPot.Size = New System.Drawing.Size(66, 43)
        Me.grpTotPot.TabIndex = 236
        Me.grpTotPot.TabStop = False
        Me.grpTotPot.Text = "Tot. Pot."
        '
        'grpTotHas
        '
        Me.grpTotHas.Controls.Add(Me.lblTotHasCen)
        Me.grpTotHas.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTotHas.ForeColor = System.Drawing.Color.Black
        Me.grpTotHas.Location = New System.Drawing.Point(74, 564)
        Me.grpTotHas.Name = "grpTotHas"
        Me.grpTotHas.Size = New System.Drawing.Size(66, 43)
        Me.grpTotHas.TabIndex = 237
        Me.grpTotHas.TabStop = False
        Me.grpTotHas.Text = "Tot. Has"
        '
        'grpTotHasDia
        '
        Me.grpTotHasDia.Controls.Add(Me.lblTotHasDia)
        Me.grpTotHasDia.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTotHasDia.ForeColor = System.Drawing.Color.Black
        Me.grpTotHasDia.Location = New System.Drawing.Point(267, 564)
        Me.grpTotHasDia.Name = "grpTotHasDia"
        Me.grpTotHasDia.Size = New System.Drawing.Size(91, 43)
        Me.grpTotHasDia.TabIndex = 238
        Me.grpTotHasDia.TabStop = False
        Me.grpTotHasDia.Text = "Tot. Has. Día"
        '
        'grpTotHasAcum
        '
        Me.grpTotHasAcum.Controls.Add(Me.lblTotHasAcum)
        Me.grpTotHasAcum.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTotHasAcum.ForeColor = System.Drawing.Color.Black
        Me.grpTotHasAcum.Location = New System.Drawing.Point(831, 563)
        Me.grpTotHasAcum.Name = "grpTotHasAcum"
        Me.grpTotHasAcum.Size = New System.Drawing.Size(129, 43)
        Me.grpTotHasAcum.TabIndex = 239
        Me.grpTotHasAcum.TabStop = False
        Me.grpTotHasAcum.Text = "Tot. Has. Días Acum."
        '
        'grpRotacionActual
        '
        Me.grpRotacionActual.Controls.Add(Me.lblRotacionActual)
        Me.grpRotacionActual.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRotacionActual.ForeColor = System.Drawing.Color.DarkGreen
        Me.grpRotacionActual.Location = New System.Drawing.Point(983, 563)
        Me.grpRotacionActual.Name = "grpRotacionActual"
        Me.grpRotacionActual.Size = New System.Drawing.Size(115, 43)
        Me.grpRotacionActual.TabIndex = 240
        Me.grpRotacionActual.TabStop = False
        Me.grpRotacionActual.Text = "Rotación Actual"
        '
        'grpConsumoActual
        '
        Me.grpConsumoActual.Controls.Add(Me.lblConsumoActual)
        Me.grpConsumoActual.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpConsumoActual.ForeColor = System.Drawing.Color.DarkGreen
        Me.grpConsumoActual.Location = New System.Drawing.Point(1101, 563)
        Me.grpConsumoActual.Name = "grpConsumoActual"
        Me.grpConsumoActual.Size = New System.Drawing.Size(115, 43)
        Me.grpConsumoActual.TabIndex = 241
        Me.grpConsumoActual.TabStop = False
        Me.grpConsumoActual.Text = "Cons. Diario Act."
        '
        'grpConsumoOptimo
        '
        Me.grpConsumoOptimo.Controls.Add(Me.lblConsumoOptimo)
        Me.grpConsumoOptimo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpConsumoOptimo.ForeColor = System.Drawing.Color.Black
        Me.grpConsumoOptimo.Location = New System.Drawing.Point(492, 563)
        Me.grpConsumoOptimo.Name = "grpConsumoOptimo"
        Me.grpConsumoOptimo.Size = New System.Drawing.Size(115, 43)
        Me.grpConsumoOptimo.TabIndex = 242
        Me.grpConsumoOptimo.TabStop = False
        Me.grpConsumoOptimo.Text = "Cons. Diario Opt."
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 100000
        Me.ToolTip1.AutoPopDelay = 1000000
        Me.ToolTip1.InitialDelay = 50
        Me.ToolTip1.ReshowDelay = 50
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.Color.Transparent
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(45, 646)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1133, 25)
        Me.pnlEstReprod.TabIndex = 243
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.lblTotHasEfect)
        Me.GroupBox9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.ForeColor = System.Drawing.Color.Black
        Me.GroupBox9.Location = New System.Drawing.Point(146, 564)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(104, 43)
        Me.GroupBox9.TabIndex = 244
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Tot. Has. Efec."
        '
        'lblTotHasEfect
        '
        Me.lblTotHasEfect.BackColor = System.Drawing.Color.Transparent
        Me.lblTotHasEfect.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotHasEfect.Location = New System.Drawing.Point(6, 17)
        Me.lblTotHasEfect.Name = "lblTotHasEfect"
        Me.lblTotHasEfect.Size = New System.Drawing.Size(92, 21)
        Me.lblTotHasEfect.TabIndex = 55
        Me.lblTotHasEfect.Text = "0"
        Me.lblTotHasEfect.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(96, 610)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 231
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnImprime
        '
        Me.btnImprime.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprime.Image = CType(resources.GetObject("btnImprime.Image"), System.Drawing.Image)
        Me.btnImprime.Location = New System.Drawing.Point(189, 610)
        Me.btnImprime.Name = "btnImprime"
        Me.btnImprime.Size = New System.Drawing.Size(87, 30)
        Me.btnImprime.TabIndex = 227
        Me.btnImprime.Text = "Imprime"
        Me.btnImprime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprime.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1135, 610)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 219
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(3, 610)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 30)
        Me.btnGrabar.TabIndex = 218
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'Categoria
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Categoria.DefaultCellStyle = DataGridViewCellStyle1
        Me.Categoria.HeaderText = "Potrero"
        Me.Categoria.Name = "Categoria"
        Me.Categoria.ReadOnly = True
        Me.Categoria.Width = 55
        '
        'Superficie
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.Superficie.DefaultCellStyle = DataGridViewCellStyle2
        Me.Superficie.HeaderText = "    Ha."
        Me.Superficie.Name = "Superficie"
        Me.Superficie.ReadOnly = True
        Me.Superficie.Width = 45
        '
        'Cobertura
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Cobertura.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cobertura.HeaderText = "Ultima Cobertura"
        Me.Cobertura.Name = "Cobertura"
        Me.Cobertura.ReadOnly = True
        Me.Cobertura.Width = 70
        '
        'DiasLibres
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.DiasLibres.DefaultCellStyle = DataGridViewCellStyle4
        Me.DiasLibres.HeaderText = "Días Libres"
        Me.DiasLibres.Name = "DiasLibres"
        Me.DiasLibres.ReadOnly = True
        Me.DiasLibres.Width = 50
        '
        'Pastoreo
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Pastoreo.DefaultCellStyle = DataGridViewCellStyle5
        Me.Pastoreo.HeaderText = "Pastoreo (Ha/Día)"
        Me.Pastoreo.Name = "Pastoreo"
        Me.Pastoreo.Width = 60
        '
        'Ensilaje
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Ensilaje.DefaultCellStyle = DataGridViewCellStyle6
        Me.Ensilaje.HeaderText = "Ensilaje (Ha/Día)"
        Me.Ensilaje.Name = "Ensilaje"
        Me.Ensilaje.Width = 60
        '
        'PastoreoAcum
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.PastoreoAcum.DefaultCellStyle = DataGridViewCellStyle7
        Me.PastoreoAcum.HeaderText = "Acum."
        Me.PastoreoAcum.Name = "PastoreoAcum"
        Me.PastoreoAcum.ReadOnly = True
        Me.PastoreoAcum.Width = 60
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "TipoPotrero"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Visible = False
        Me.Tipo.Width = 60
        '
        'Column1
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Format = "N2"
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column1.HeaderText = "Ultima Rotacion"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 75
        '
        'frmRotacionPotreros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 646)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.grpConsumoOptimo)
        Me.Controls.Add(Me.grpConsumoActual)
        Me.Controls.Add(Me.grpRotacionActual)
        Me.Controls.Add(Me.grpTotHasAcum)
        Me.Controls.Add(Me.grpTotHasDia)
        Me.Controls.Add(Me.grpTotHas)
        Me.Controls.Add(Me.grpTotPot)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.panel)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.tabPASTO)
        Me.Controls.Add(Me.lblTotalAnterior)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.lblTotalCobertura)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnImprime)
        Me.Controls.Add(Me.gboxIngMediciones)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRotacionPotreros"
        Me.Text = "ROTACION DE POTREROS"
        Me.gboxIngMediciones.ResumeLayout(False)
        Me.gboxIngMediciones.PerformLayout()
        CType(Me.dgvRP_Potreros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.tabPASTO.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.chartRP_UltCobertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartDiasLibrexPotrero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.panel.ResumeLayout(False)
        Me.panel.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.grpTotPot.ResumeLayout(False)
        Me.grpTotHas.ResumeLayout(False)
        Me.grpTotHasDia.ResumeLayout(False)
        Me.grpTotHasAcum.ResumeLayout(False)
        Me.grpRotacionActual.ResumeLayout(False)
        Me.grpConsumoActual.ResumeLayout(False)
        Me.grpConsumoOptimo.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblTotalAnterior As System.Windows.Forms.Label
    Friend WithEvents lblTotalCobertura As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblNroPotreros As System.Windows.Forms.Label
    Friend WithEvents btnImprime As System.Windows.Forms.Button
    Friend WithEvents gboxIngMediciones As System.Windows.Forms.GroupBox
    Friend WithEvents dgvRP_Potreros As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotHasDia As System.Windows.Forms.Label
    Friend WithEvents lblTotHasCen As System.Windows.Forms.Label
    Friend WithEvents tabPASTO As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnMax2 As System.Windows.Forms.Button
    Friend WithEvents btnMin2 As System.Windows.Forms.Button
    Friend WithEvents btnMax1 As System.Windows.Forms.Button
    Friend WithEvents btnMin1 As System.Windows.Forms.Button
    Private WithEvents chartRP_UltCobertura As System.Windows.Forms.DataVisualization.Charting.Chart
    Private WithEvents chartDiasLibrexPotrero As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents WebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents lblErrNomArchivo As System.Windows.Forms.Label
    Friend WithEvents panel As System.Windows.Forms.GroupBox
    Friend WithEvents txtPostGrazing As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPreGrazing As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCreciDiario As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPFijo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPEstacional As System.Windows.Forms.TextBox
    Friend WithEvents PrintPreviewDialog As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtRotacion As TextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents txtDiasAcum As TextBox
    Friend WithEvents lblConsumoActual As Label
    Friend WithEvents lblConsumoOptimo As Label
    Friend WithEvents lblTotHasAcum As Label
    Friend WithEvents lblRotacionActual As Label
    Friend WithEvents grpTotPot As GroupBox
    Friend WithEvents grpTotHas As GroupBox
    Friend WithEvents grpTotHasDia As GroupBox
    Friend WithEvents grpTotHasAcum As GroupBox
    Friend WithEvents grpRotacionActual As GroupBox
    Friend WithEvents grpConsumoActual As GroupBox
    Friend WithEvents grpConsumoOptimo As GroupBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pnlEstReprod As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents lblTotHasEfect As Label
    Friend WithEvents cboCentros As ComboBox
    Friend WithEvents Categoria As DataGridViewTextBoxColumn
    Friend WithEvents Superficie As DataGridViewTextBoxColumn
    Friend WithEvents Cobertura As DataGridViewTextBoxColumn
    Friend WithEvents DiasLibres As DataGridViewTextBoxColumn
    Friend WithEvents Pastoreo As DataGridViewTextBoxColumn
    Friend WithEvents Ensilaje As DataGridViewTextBoxColumn
    Friend WithEvents PastoreoAcum As DataGridViewTextBoxColumn
    Friend WithEvents Tipo As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
End Class
