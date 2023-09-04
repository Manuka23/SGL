<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIngresoFertilizante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoFertilizante))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnImprime = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtPFijo = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvAU_POTREROS = New System.Windows.Forms.DataGridView()
        Me.Seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Categoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Superficie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AcumPer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CantHa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaUl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gboxIngMediciones = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblTotHasAcum = New System.Windows.Forms.Label()
        Me.txtDosisxHa = New System.Windows.Forms.TextBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtUreaAsignada = New System.Windows.Forms.TextBox()
        Me.panel = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblNroPotreros = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotalHectareas = New System.Windows.Forms.Label()
        Me.lblTotalHectareasAplicadas = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblNroPotrerosAplicados = New System.Windows.Forms.Label()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.txtUreaAplicada = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblNroConsumo = New System.Windows.Forms.Label()
        Me.PrintPreviewDialog = New System.Windows.Forms.PrintPreviewDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSaldoUrea = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.WebBrowser = New System.Windows.Forms.WebBrowser()
        Me.lblErrNomArchivo = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnMax1 = New System.Windows.Forms.Button()
        Me.btnMin1 = New System.Windows.Forms.Button()
        Me.chartUreaAcumuladaMes = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnMax2 = New System.Windows.Forms.Button()
        Me.btnMin2 = New System.Windows.Forms.Button()
        Me.chartUreaAcumuladaTemporada = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tabPASTO = New System.Windows.Forms.TabControl()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblUrea = New System.Windows.Forms.Label()
        Me.cboProductos = New System.Windows.Forms.ComboBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.cboTipoUso = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvAU_POTREROS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxIngMediciones.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.panel.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.chartUreaAcumuladaMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chartUreaAcumuladaTemporada, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPASTO.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(6, 615)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 30)
        Me.btnGrabar.TabIndex = 221
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1043, 615)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 222
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnImprime
        '
        Me.btnImprime.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprime.Image = CType(resources.GetObject("btnImprime.Image"), System.Drawing.Image)
        Me.btnImprime.Location = New System.Drawing.Point(99, 615)
        Me.btnImprime.Name = "btnImprime"
        Me.btnImprime.Size = New System.Drawing.Size(87, 30)
        Me.btnImprime.TabIndex = 230
        Me.btnImprime.Text = "Imprime"
        Me.btnImprime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnImprime.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(501, 624)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 21)
        Me.Label1.TabIndex = 234
        Me.Label1.Text = "0"
        Me.Label1.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(192, 615)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 235
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(332, 624)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 21)
        Me.Label4.TabIndex = 236
        Me.Label4.Text = "suma cob (cob x ha)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label4.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(757, 624)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 21)
        Me.Label6.TabIndex = 237
        Me.Label6.Text = "0"
        Me.Label6.Visible = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(610, 624)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 21)
        Me.Label5.TabIndex = 238
        Me.Label5.Text = "suma ha (cob > 0)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label5.Visible = False
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(11, 20)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(191, 31)
        Me.cboCentros.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 57)
        Me.GroupBox1.TabIndex = 223
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(6, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(111, 30)
        Me.dtpFecha.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtpFecha)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(221, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(125, 57)
        Me.GroupBox5.TabIndex = 224
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fecha"
        '
        'txtPFijo
        '
        Me.txtPFijo.Enabled = False
        Me.txtPFijo.Location = New System.Drawing.Point(18, 20)
        Me.txtPFijo.MaxLength = 3
        Me.txtPFijo.Name = "txtPFijo"
        Me.txtPFijo.Size = New System.Drawing.Size(100, 30)
        Me.txtPFijo.TabIndex = 1
        Me.txtPFijo.Text = "500"
        Me.txtPFijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtPFijo)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox4.Location = New System.Drawing.Point(1208, 126)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(133, 57)
        Me.GroupBox4.TabIndex = 227
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Param. Fijo"
        Me.GroupBox4.Visible = False
        '
        'dgvAU_POTREROS
        '
        Me.dgvAU_POTREROS.AllowUserToAddRows = False
        Me.dgvAU_POTREROS.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvAU_POTREROS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAU_POTREROS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccion, Me.Categoria, Me.Superficie, Me.MI, Me.AcumPer, Me.CantHa, Me.MF, Me.Column1, Me.FechaUl})
        Me.dgvAU_POTREROS.Enabled = False
        Me.dgvAU_POTREROS.Location = New System.Drawing.Point(11, 25)
        Me.dgvAU_POTREROS.Name = "dgvAU_POTREROS"
        Me.dgvAU_POTREROS.RowHeadersVisible = False
        Me.dgvAU_POTREROS.RowHeadersWidth = 51
        Me.dgvAU_POTREROS.RowTemplate.Height = 20
        Me.dgvAU_POTREROS.ShowEditingIcon = False
        Me.dgvAU_POTREROS.Size = New System.Drawing.Size(360, 430)
        Me.dgvAU_POTREROS.TabIndex = 15
        '
        'Seleccion
        '
        Me.Seleccion.Frozen = True
        Me.Seleccion.HeaderText = "Selec"
        Me.Seleccion.MinimumWidth = 6
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Seleccion.Width = 40
        '
        'Categoria
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Categoria.DefaultCellStyle = DataGridViewCellStyle1
        Me.Categoria.HeaderText = "Pot"
        Me.Categoria.MinimumWidth = 6
        Me.Categoria.Name = "Categoria"
        Me.Categoria.ReadOnly = True
        Me.Categoria.Width = 50
        '
        'Superficie
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Superficie.DefaultCellStyle = DataGridViewCellStyle2
        Me.Superficie.HeaderText = "Ha."
        Me.Superficie.MinimumWidth = 6
        Me.Superficie.Name = "Superficie"
        Me.Superficie.ReadOnly = True
        Me.Superficie.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Superficie.Width = 50
        '
        'MI
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MI.DefaultCellStyle = DataGridViewCellStyle3
        Me.MI.HeaderText = "Acc Mes"
        Me.MI.MaxInputLength = 7
        Me.MI.MinimumWidth = 6
        Me.MI.Name = "MI"
        Me.MI.ReadOnly = True
        Me.MI.Width = 50
        '
        'AcumPer
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AcumPer.DefaultCellStyle = DataGridViewCellStyle4
        Me.AcumPer.HeaderText = "Acc Temp"
        Me.AcumPer.MaxInputLength = 7
        Me.AcumPer.MinimumWidth = 6
        Me.AcumPer.Name = "AcumPer"
        Me.AcumPer.ReadOnly = True
        Me.AcumPer.Width = 55
        '
        'CantHa
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CantHa.DefaultCellStyle = DataGridViewCellStyle5
        Me.CantHa.HeaderText = "Dosis Ha"
        Me.CantHa.MinimumWidth = 6
        Me.CantHa.Name = "CantHa"
        Me.CantHa.Width = 50
        '
        'MF
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.MF.DefaultCellStyle = DataGridViewCellStyle6
        Me.MF.HeaderText = "Cant Tot"
        Me.MF.MaxInputLength = 5
        Me.MF.MinimumWidth = 6
        Me.MF.Name = "MF"
        Me.MF.Width = 50
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.MaxInputLength = 2
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 6
        '
        'FechaUl
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        Me.FechaUl.DefaultCellStyle = DataGridViewCellStyle7
        Me.FechaUl.HeaderText = "Ult. Ingr."
        Me.FechaUl.MinimumWidth = 6
        Me.FechaUl.Name = "FechaUl"
        Me.FechaUl.ReadOnly = True
        Me.FechaUl.Width = 70
        '
        'gboxIngMediciones
        '
        Me.gboxIngMediciones.Controls.Add(Me.Label14)
        Me.gboxIngMediciones.Controls.Add(Me.Label13)
        Me.gboxIngMediciones.Controls.Add(Me.Label12)
        Me.gboxIngMediciones.Controls.Add(Me.Label11)
        Me.gboxIngMediciones.Controls.Add(Me.Label10)
        Me.gboxIngMediciones.Controls.Add(Me.Label8)
        Me.gboxIngMediciones.Controls.Add(Me.lblTotHasAcum)
        Me.gboxIngMediciones.Controls.Add(Me.dgvAU_POTREROS)
        Me.gboxIngMediciones.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxIngMediciones.Location = New System.Drawing.Point(6, 83)
        Me.gboxIngMediciones.Name = "gboxIngMediciones"
        Me.gboxIngMediciones.Size = New System.Drawing.Size(377, 499)
        Me.gboxIngMediciones.TabIndex = 228
        Me.gboxIngMediciones.TabStop = False
        Me.gboxIngMediciones.Text = "Seleccion de Potreros"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(288, 471)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 18)
        Me.Label14.TabIndex = 67
        Me.Label14.Text = "Tiene Purin"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.LightBlue
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(245, 471)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(39, 18)
        Me.Label13.TabIndex = 66
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(169, 471)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 18)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Tipo Pasto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(42, 471)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 18)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Otro Tipo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(55, 471)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 18)
        Me.Label10.TabIndex = 63
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(128, 471)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 18)
        Me.Label8.TabIndex = 62
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTotHasAcum
        '
        Me.lblTotHasAcum.BackColor = System.Drawing.Color.Orange
        Me.lblTotHasAcum.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotHasAcum.Location = New System.Drawing.Point(10, 471)
        Me.lblTotHasAcum.Name = "lblTotHasAcum"
        Me.lblTotHasAcum.Size = New System.Drawing.Size(31, 18)
        Me.lblTotHasAcum.TabIndex = 61
        Me.lblTotHasAcum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDosisxHa
        '
        Me.txtDosisxHa.Location = New System.Drawing.Point(16, 20)
        Me.txtDosisxHa.MaxLength = 5
        Me.txtDosisxHa.Name = "txtDosisxHa"
        Me.txtDosisxHa.Size = New System.Drawing.Size(79, 30)
        Me.txtDosisxHa.TabIndex = 0
        Me.txtDosisxHa.Text = "0"
        Me.txtDosisxHa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox8.Controls.Add(Me.txtDosisxHa)
        Me.GroupBox8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox8.Location = New System.Drawing.Point(785, 12)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(109, 57)
        Me.GroupBox8.TabIndex = 232
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Dosis x Ha."
        '
        'txtUreaAsignada
        '
        Me.txtUreaAsignada.Location = New System.Drawing.Point(16, 20)
        Me.txtUreaAsignada.MaxLength = 5
        Me.txtUreaAsignada.Name = "txtUreaAsignada"
        Me.txtUreaAsignada.Size = New System.Drawing.Size(87, 30)
        Me.txtUreaAsignada.TabIndex = 1
        Me.txtUreaAsignada.Text = "0"
        Me.txtUreaAsignada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'panel
        '
        Me.panel.Controls.Add(Me.txtUreaAsignada)
        Me.panel.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel.ForeColor = System.Drawing.Color.Navy
        Me.panel.Location = New System.Drawing.Point(1191, 233)
        Me.panel.Name = "panel"
        Me.panel.Size = New System.Drawing.Size(120, 57)
        Me.panel.TabIndex = 233
        Me.panel.TabStop = False
        Me.panel.Text = "Urea Asignada"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 21)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Tot.Potreros :"
        '
        'lblNroPotreros
        '
        Me.lblNroPotreros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroPotreros.Location = New System.Drawing.Point(104, 2)
        Me.lblNroPotreros.Name = "lblNroPotreros"
        Me.lblNroPotreros.Size = New System.Drawing.Size(39, 21)
        Me.lblNroPotreros.TabIndex = 49
        Me.lblNroPotreros.Text = "0"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(574, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 21)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Tot. Hectareas Aplicadas :"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(153, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 21)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Tot.Hectareas :"
        '
        'lblTotalHectareas
        '
        Me.lblTotalHectareas.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalHectareas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHectareas.Location = New System.Drawing.Point(260, 2)
        Me.lblTotalHectareas.Name = "lblTotalHectareas"
        Me.lblTotalHectareas.Size = New System.Drawing.Size(50, 21)
        Me.lblTotalHectareas.TabIndex = 51
        Me.lblTotalHectareas.Text = "0"
        '
        'lblTotalHectareasAplicadas
        '
        Me.lblTotalHectareasAplicadas.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalHectareasAplicadas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHectareasAplicadas.Location = New System.Drawing.Point(758, 2)
        Me.lblTotalHectareasAplicadas.Name = "lblTotalHectareasAplicadas"
        Me.lblTotalHectareasAplicadas.Size = New System.Drawing.Size(67, 21)
        Me.lblTotalHectareasAplicadas.TabIndex = 53
        Me.lblTotalHectareasAplicadas.Text = "0"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(344, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(163, 21)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Tot.Potreros Aplicados :"
        '
        'lblNroPotrerosAplicados
        '
        Me.lblNroPotrerosAplicados.BackColor = System.Drawing.Color.Transparent
        Me.lblNroPotrerosAplicados.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroPotrerosAplicados.Location = New System.Drawing.Point(510, 2)
        Me.lblNroPotrerosAplicados.Name = "lblNroPotrerosAplicados"
        Me.lblNroPotrerosAplicados.Size = New System.Drawing.Size(50, 21)
        Me.lblNroPotrerosAplicados.TabIndex = 56
        Me.lblNroPotrerosAplicados.Text = "0"
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblNroPotrerosAplicados)
        Me.pnlEstReprod.Controls.Add(Me.Label7)
        Me.pnlEstReprod.Controls.Add(Me.lblTotalHectareasAplicadas)
        Me.pnlEstReprod.Controls.Add(Me.lblTotalHectareas)
        Me.pnlEstReprod.Controls.Add(Me.Label2)
        Me.pnlEstReprod.Controls.Add(Me.Label3)
        Me.pnlEstReprod.Controls.Add(Me.lblNroPotreros)
        Me.pnlEstReprod.Controls.Add(Me.Label9)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(6, 584)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1124, 25)
        Me.pnlEstReprod.TabIndex = 225
        '
        'txtUreaAplicada
        '
        Me.txtUreaAplicada.ForeColor = System.Drawing.Color.Red
        Me.txtUreaAplicada.Location = New System.Drawing.Point(11, 21)
        Me.txtUreaAplicada.MaxLength = 5
        Me.txtUreaAplicada.Name = "txtUreaAplicada"
        Me.txtUreaAplicada.ReadOnly = True
        Me.txtUreaAplicada.Size = New System.Drawing.Size(96, 30)
        Me.txtUreaAplicada.TabIndex = 1
        Me.txtUreaAplicada.Text = "0"
        Me.txtUreaAplicada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblNroConsumo)
        Me.GroupBox3.Controls.Add(Me.txtUreaAplicada)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Red
        Me.GroupBox3.Location = New System.Drawing.Point(900, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(139, 57)
        Me.GroupBox3.TabIndex = 234
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Total Aplicado"
        '
        'lblNroConsumo
        '
        Me.lblNroConsumo.Location = New System.Drawing.Point(249, 26)
        Me.lblNroConsumo.Name = "lblNroConsumo"
        Me.lblNroConsumo.Size = New System.Drawing.Size(90, 18)
        Me.lblNroConsumo.TabIndex = 223
        Me.lblNroConsumo.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSaldoUrea)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(1013, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(123, 57)
        Me.GroupBox2.TabIndex = 239
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stock Actual"
        '
        'txtSaldoUrea
        '
        Me.txtSaldoUrea.ForeColor = System.Drawing.Color.Red
        Me.txtSaldoUrea.Location = New System.Drawing.Point(6, 20)
        Me.txtSaldoUrea.MaxLength = 5
        Me.txtSaldoUrea.Name = "txtSaldoUrea"
        Me.txtSaldoUrea.ReadOnly = True
        Me.txtSaldoUrea.Size = New System.Drawing.Size(111, 30)
        Me.txtSaldoUrea.TabIndex = 1
        Me.txtSaldoUrea.Text = "0"
        Me.txtSaldoUrea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.WebBrowser)
        Me.TabPage2.Controls.Add(Me.lblErrNomArchivo)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(732, 465)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Mapa del Predio"
        '
        'WebBrowser
        '
        Me.WebBrowser.Location = New System.Drawing.Point(12, 11)
        Me.WebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser.Name = "WebBrowser"
        Me.WebBrowser.Size = New System.Drawing.Size(696, 113)
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
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.btnMax1)
        Me.TabPage1.Controls.Add(Me.btnMin1)
        Me.TabPage1.Controls.Add(Me.chartUreaAcumuladaMes)
        Me.TabPage1.Controls.Add(Me.btnMax2)
        Me.TabPage1.Controls.Add(Me.btnMin2)
        Me.TabPage1.Controls.Add(Me.chartUreaAcumuladaTemporada)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(732, 465)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Graficos Entrega de Urea"
        '
        'btnMax1
        '
        Me.btnMax1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.btnMax1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMax1.FlatAppearance.BorderSize = 0
        Me.btnMax1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMax1.Image = CType(resources.GetObject("btnMax1.Image"), System.Drawing.Image)
        Me.btnMax1.Location = New System.Drawing.Point(682, 16)
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
        Me.btnMin1.Location = New System.Drawing.Point(682, 16)
        Me.btnMin1.Name = "btnMin1"
        Me.btnMin1.Size = New System.Drawing.Size(33, 29)
        Me.btnMin1.TabIndex = 226
        Me.btnMin1.UseVisualStyleBackColor = False
        '
        'chartUreaAcumuladaMes
        '
        Me.chartUreaAcumuladaMes.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.chartUreaAcumuladaMes.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.chartUreaAcumuladaMes.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.chartUreaAcumuladaMes.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.chartUreaAcumuladaMes.BorderlineWidth = 2
        Me.chartUreaAcumuladaMes.BorderSkin.BackColor = System.Drawing.Color.White
        Me.chartUreaAcumuladaMes.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea1.Area3DStyle.Inclination = 50
        ChartArea1.Area3DStyle.IsClustered = True
        ChartArea1.Area3DStyle.IsRightAngleAxes = False
        ChartArea1.Area3DStyle.PointGapDepth = 900
        ChartArea1.Area3DStyle.Rotation = 162
        ChartArea1.Area3DStyle.WallWidth = 25
        ChartArea1.AxisX.Interval = 1.0R
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelStyle.Angle = -50
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MajorTickMark.Enabled = False
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX2.MajorGrid.Enabled = False
        ChartArea1.AxisX2.MajorTickMark.Enabled = False
        ChartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.0!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Green
        ChartArea1.AxisY.LineColor = System.Drawing.Color.Green
        ChartArea1.AxisY.LineWidth = 2
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.MajorTickMark.Enabled = False
        ChartArea1.AxisY.Title = "Kg / Ha"
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.TitleForeColor = System.Drawing.Color.Green
        ChartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea1.AxisY2.IsLabelAutoFit = False
        ChartArea1.AxisY2.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.RoyalBlue
        ChartArea1.AxisY2.LineColor = System.Drawing.Color.RoyalBlue
        ChartArea1.AxisY2.LineWidth = 2
        ChartArea1.AxisY2.MajorGrid.Enabled = False
        ChartArea1.AxisY2.MajorTickMark.Enabled = False
        ChartArea1.AxisY2.Title = "Acum / Ha"
        ChartArea1.AxisY2.TitleFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY2.TitleForeColor = System.Drawing.Color.RoyalBlue
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea1.BackSecondaryColor = System.Drawing.Color.White
        ChartArea1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.Name = "Area1"
        ChartArea1.ShadowColor = System.Drawing.Color.White
        Me.chartUreaAcumuladaMes.ChartAreas.Add(ChartArea1)
        Me.chartUreaAcumuladaMes.Location = New System.Drawing.Point(3, 2)
        Me.chartUreaAcumuladaMes.Name = "chartUreaAcumuladaMes"
        Series1.BorderWidth = 2
        Series1.ChartArea = "Area1"
        Series1.Color = System.Drawing.Color.Green
        Series1.EmptyPointStyle.Color = System.Drawing.Color.Red
        Series1.IsXValueIndexed = True
        Series1.LegendText = "Urea"
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series1.Name = "Series1"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Date]
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
        Me.chartUreaAcumuladaMes.Series.Add(Series1)
        Me.chartUreaAcumuladaMes.Size = New System.Drawing.Size(733, 232)
        Me.chartUreaAcumuladaMes.TabIndex = 229
        Title1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title1.Name = "Title1"
        Title1.Text = "Acumulado Mes"
        Me.chartUreaAcumuladaMes.Titles.Add(Title1)
        '
        'btnMax2
        '
        Me.btnMax2.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.btnMax2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnMax2.FlatAppearance.BorderSize = 0
        Me.btnMax2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMax2.Image = CType(resources.GetObject("btnMax2.Image"), System.Drawing.Image)
        Me.btnMax2.Location = New System.Drawing.Point(682, 251)
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
        Me.btnMin2.Location = New System.Drawing.Point(682, 251)
        Me.btnMin2.Name = "btnMin2"
        Me.btnMin2.Size = New System.Drawing.Size(33, 29)
        Me.btnMin2.TabIndex = 228
        Me.btnMin2.UseVisualStyleBackColor = False
        '
        'chartUreaAcumuladaTemporada
        '
        Me.chartUreaAcumuladaTemporada.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chartUreaAcumuladaTemporada.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.chartUreaAcumuladaTemporada.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.chartUreaAcumuladaTemporada.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.chartUreaAcumuladaTemporada.BorderlineWidth = 2
        Me.chartUreaAcumuladaTemporada.BorderSkin.BackColor = System.Drawing.Color.White
        Me.chartUreaAcumuladaTemporada.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
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
        ChartArea2.AxisX.TitleFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisX2.MajorGrid.Enabled = False
        ChartArea2.AxisX2.MajorTickMark.Enabled = False
        ChartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea2.AxisY.IsLabelAutoFit = False
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.0!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Green
        ChartArea2.AxisY.LineColor = System.Drawing.Color.Green
        ChartArea2.AxisY.LineWidth = 2
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisY.MajorTickMark.Enabled = False
        ChartArea2.AxisY.Title = "Kg / Ha"
        ChartArea2.AxisY.TitleFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY.TitleForeColor = System.Drawing.Color.Green
        ChartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea2.AxisY2.IsLabelAutoFit = False
        ChartArea2.AxisY2.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.RoyalBlue
        ChartArea2.AxisY2.LineColor = System.Drawing.Color.RoyalBlue
        ChartArea2.AxisY2.LineWidth = 2
        ChartArea2.AxisY2.MajorGrid.Enabled = False
        ChartArea2.AxisY2.MajorTickMark.Enabled = False
        ChartArea2.AxisY2.Title = "Acum / Ha"
        ChartArea2.AxisY2.TitleFont = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY2.TitleForeColor = System.Drawing.Color.RoyalBlue
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea2.BackSecondaryColor = System.Drawing.Color.White
        ChartArea2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.Name = "Area1"
        ChartArea2.ShadowColor = System.Drawing.Color.White
        Me.chartUreaAcumuladaTemporada.ChartAreas.Add(ChartArea2)
        Me.chartUreaAcumuladaTemporada.Location = New System.Drawing.Point(3, 237)
        Me.chartUreaAcumuladaTemporada.Name = "chartUreaAcumuladaTemporada"
        Series2.BorderWidth = 2
        Series2.ChartArea = "Area1"
        Series2.Color = System.Drawing.Color.SteelBlue
        Series2.EmptyPointStyle.Color = System.Drawing.Color.Red
        Series2.IsXValueIndexed = True
        Series2.LegendText = "Urea"
        Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series2.Name = "Series1"
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Date]
        Series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[Double]
        Me.chartUreaAcumuladaTemporada.Series.Add(Series2)
        Me.chartUreaAcumuladaTemporada.Size = New System.Drawing.Size(733, 232)
        Me.chartUreaAcumuladaTemporada.TabIndex = 224
        Title2.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title2.Name = "Title1"
        Title2.Text = "Acumulado Temporada"
        Me.chartUreaAcumuladaTemporada.Titles.Add(Title2)
        '
        'tabPASTO
        '
        Me.tabPASTO.Controls.Add(Me.TabPage1)
        Me.tabPASTO.Controls.Add(Me.TabPage2)
        Me.tabPASTO.Location = New System.Drawing.Point(390, 87)
        Me.tabPASTO.Name = "tabPASTO"
        Me.tabPASTO.SelectedIndex = 0
        Me.tabPASTO.Size = New System.Drawing.Size(740, 495)
        Me.tabPASTO.TabIndex = 231
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lblUrea)
        Me.GroupBox6.Controls.Add(Me.cboProductos)
        Me.GroupBox6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(529, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(250, 57)
        Me.GroupBox6.TabIndex = 240
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Insumo"
        '
        'lblUrea
        '
        Me.lblUrea.AutoSize = True
        Me.lblUrea.Location = New System.Drawing.Point(13, 24)
        Me.lblUrea.Name = "lblUrea"
        Me.lblUrea.Size = New System.Drawing.Size(0, 23)
        Me.lblUrea.TabIndex = 66
        '
        'cboProductos
        '
        Me.cboProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProductos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProductos.FormattingEnabled = True
        Me.cboProductos.Location = New System.Drawing.Point(11, 20)
        Me.cboProductos.Name = "cboProductos"
        Me.cboProductos.Size = New System.Drawing.Size(233, 31)
        Me.cboProductos.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.cboTipoUso)
        Me.GroupBox7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(352, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(171, 57)
        Me.GroupBox7.TabIndex = 241
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Tipo Uso"
        '
        'cboTipoUso
        '
        Me.cboTipoUso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoUso.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoUso.FormattingEnabled = True
        Me.cboTipoUso.Location = New System.Drawing.Point(11, 20)
        Me.cboTipoUso.Name = "cboTipoUso"
        Me.cboTipoUso.Size = New System.Drawing.Size(151, 31)
        Me.cboTipoUso.TabIndex = 0
        '
        'frmIngresoFertilizante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1147, 655)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.panel)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.tabPASTO)
        Me.Controls.Add(Me.btnImprime)
        Me.Controls.Add(Me.gboxIngMediciones)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIngresoFertilizante"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fertilidad de Suelos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvAU_POTREROS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxIngMediciones.ResumeLayout(False)
        Me.gboxIngMediciones.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.panel.ResumeLayout(False)
        Me.panel.PerformLayout()
        Me.pnlEstReprod.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.chartUreaAcumuladaMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chartUreaAcumuladaTemporada, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPASTO.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnImprime As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPFijo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAU_POTREROS As System.Windows.Forms.DataGridView
    Friend WithEvents gboxIngMediciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtDosisxHa As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUreaAsignada As System.Windows.Forms.TextBox
    Friend WithEvents panel As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblNroPotreros As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotalHectareas As System.Windows.Forms.Label
    Friend WithEvents lblTotalHectareasAplicadas As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNroPotrerosAplicados As System.Windows.Forms.Label
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents txtUreaAplicada As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PrintPreviewDialog As PrintPreviewDialog
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtSaldoUrea As TextBox
    Friend WithEvents lblNroConsumo As Label
    Friend WithEvents lblTotHasAcum As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents WebBrowser As WebBrowser
    Friend WithEvents lblErrNomArchivo As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents btnMax1 As Button
    Friend WithEvents btnMin1 As Button
    Private WithEvents chartUreaAcumuladaMes As DataVisualization.Charting.Chart
    Friend WithEvents btnMax2 As Button
    Friend WithEvents btnMin2 As Button
    Private WithEvents chartUreaAcumuladaTemporada As DataVisualization.Charting.Chart
    Friend WithEvents tabPASTO As TabControl
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents cboProductos As ComboBox
    Friend WithEvents lblUrea As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents cboTipoUso As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents Categoria As DataGridViewTextBoxColumn
    Friend WithEvents Superficie As DataGridViewTextBoxColumn
    Friend WithEvents MI As DataGridViewTextBoxColumn
    Friend WithEvents AcumPer As DataGridViewTextBoxColumn
    Friend WithEvents CantHa As DataGridViewTextBoxColumn
    Friend WithEvents MF As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents FechaUl As DataGridViewTextBoxColumn
End Class
