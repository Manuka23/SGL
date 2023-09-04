<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCojeras
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title4 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea5 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title5 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCojeras))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblPreventivos = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblResguardo = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEnTratamiento = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalCasos = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.lvGanado = New System.Windows.Forms.ListView()
        Me.NroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EmpresaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodCenCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NroCasosCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EnTratamientoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EnResguardoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TratPreventivosCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ObsCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ChartCasosMensual = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ChartCasosMasDe3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabDatos = New System.Windows.Forms.TabPage()
        Me.TabCojas = New System.Windows.Forms.TabPage()
        Me.ChartCojasMensual = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ChartCojasCentro = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabCasos = New System.Windows.Forms.TabPage()
        Me.TabOtros = New System.Windows.Forms.TabPage()
        Me.ChartCojasPorTipo = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnGrafico = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.ChartCasosMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartCasosMasDe3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.TabCojas.SuspendLayout()
        CType(Me.ChartCojasMensual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartCojasCentro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCasos.SuspendLayout()
        Me.TabOtros.SuspendLayout()
        CType(Me.ChartCojasPorTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(994, 41)
        Me.Panel1.TabIndex = 154
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(967, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Registro de Cojeras"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblOrden)
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(14, 103)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(969, 23)
        Me.Panel2.TabIndex = 152
        '
        'lblOrden
        '
        Me.lblOrden.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.ForeColor = System.Drawing.Color.White
        Me.lblOrden.Location = New System.Drawing.Point(115, 1)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(821, 19)
        Me.lblOrden.TabIndex = 0
        Me.lblOrden.Text = "Centro"
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
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblPreventivos)
        Me.pnlEstReprod.Controls.Add(Me.Label9)
        Me.pnlEstReprod.Controls.Add(Me.Label7)
        Me.pnlEstReprod.Controls.Add(Me.lblResguardo)
        Me.pnlEstReprod.Controls.Add(Me.Label5)
        Me.pnlEstReprod.Controls.Add(Me.lblEnTratamiento)
        Me.pnlEstReprod.Controls.Add(Me.Label4)
        Me.pnlEstReprod.Controls.Add(Me.lblTotalCasos)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(14, 541)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(965, 25)
        Me.pnlEstReprod.TabIndex = 146
        '
        'lblPreventivos
        '
        Me.lblPreventivos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreventivos.Location = New System.Drawing.Point(868, 0)
        Me.lblPreventivos.Name = "lblPreventivos"
        Me.lblPreventivos.Size = New System.Drawing.Size(32, 21)
        Me.lblPreventivos.TabIndex = 52
        Me.lblPreventivos.Text = "0"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(753, 1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 21)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Preventivos :"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(485, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 21)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "En Resguardo :"
        '
        'lblResguardo
        '
        Me.lblResguardo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResguardo.Location = New System.Drawing.Point(600, 0)
        Me.lblResguardo.Name = "lblResguardo"
        Me.lblResguardo.Size = New System.Drawing.Size(32, 21)
        Me.lblResguardo.TabIndex = 49
        Me.lblResguardo.Text = "0"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(221, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 21)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "En Tratamiento :"
        '
        'lblEnTratamiento
        '
        Me.lblEnTratamiento.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnTratamiento.Location = New System.Drawing.Point(354, -1)
        Me.lblEnTratamiento.Name = "lblEnTratamiento"
        Me.lblEnTratamiento.Size = New System.Drawing.Size(32, 21)
        Me.lblEnTratamiento.TabIndex = 45
        Me.lblEnTratamiento.Text = "0"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 21)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "Casos :"
        '
        'lblTotalCasos
        '
        Me.lblTotalCasos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCasos.Location = New System.Drawing.Point(77, -1)
        Me.lblTotalCasos.Name = "lblTotalCasos"
        Me.lblTotalCasos.Size = New System.Drawing.Size(32, 21)
        Me.lblTotalCasos.TabIndex = 1
        Me.lblTotalCasos.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(208, 50)
        Me.GroupBox1.TabIndex = 150
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(12, 19)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(182, 21)
        Me.cboCentros.TabIndex = 0
        '
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(26, 186)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(480, 53)
        Me.pnlProcesa.TabIndex = 148
        Me.pnlProcesa.Visible = False
        '
        'lblProcesa
        '
        Me.lblProcesa.AutoSize = True
        Me.lblProcesa.Location = New System.Drawing.Point(9, 9)
        Me.lblProcesa.Name = "lblProcesa"
        Me.lblProcesa.Size = New System.Drawing.Size(70, 13)
        Me.lblProcesa.TabIndex = 69
        Me.lblProcesa.Text = "Exportando..."
        '
        'pbProcesa
        '
        Me.pbProcesa.Location = New System.Drawing.Point(12, 23)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(444, 18)
        Me.pbProcesa.TabIndex = 68
        '
        'lvGanado
        '
        Me.lvGanado.AutoArrange = False
        Me.lvGanado.BackColor = System.Drawing.SystemColors.Window
        Me.lvGanado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NroCol, Me.EmpresaCol, Me.CodCenCol, Me.CentroCol, Me.NroCasosCol, Me.EnTratamientoCol, Me.EnResguardoCol, Me.TratPreventivosCol, Me.ObsCol})
        Me.lvGanado.FullRowSelect = True
        Me.lvGanado.GridLines = True
        Me.lvGanado.HideSelection = False
        Me.lvGanado.Location = New System.Drawing.Point(6, 9)
        Me.lvGanado.MultiSelect = False
        Me.lvGanado.Name = "lvGanado"
        Me.lvGanado.Size = New System.Drawing.Size(949, 369)
        Me.lvGanado.TabIndex = 147
        Me.lvGanado.UseCompatibleStateImageBehavior = False
        Me.lvGanado.View = System.Windows.Forms.View.Details
        '
        'NroCol
        '
        Me.NroCol.Text = "Nro"
        Me.NroCol.Width = 45
        '
        'EmpresaCol
        '
        Me.EmpresaCol.Text = "Empresa"
        Me.EmpresaCol.Width = 0
        '
        'CodCenCol
        '
        Me.CodCenCol.Text = "Cod Centro"
        Me.CodCenCol.Width = 0
        '
        'CentroCol
        '
        Me.CentroCol.Text = "Centro"
        Me.CentroCol.Width = 176
        '
        'NroCasosCol
        '
        Me.NroCasosCol.Text = "Nro. Casos"
        Me.NroCasosCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.NroCasosCol.Width = 75
        '
        'EnTratamientoCol
        '
        Me.EnTratamientoCol.Text = "En Tratamiento"
        Me.EnTratamientoCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EnTratamientoCol.Width = 84
        '
        'EnResguardoCol
        '
        Me.EnResguardoCol.Text = "En Resguardo"
        Me.EnResguardoCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.EnResguardoCol.Width = 86
        '
        'TratPreventivosCol
        '
        Me.TratPreventivosCol.Text = "Trat. Preventivos"
        Me.TratPreventivosCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TratPreventivosCol.Width = 100
        '
        'ObsCol
        '
        Me.ObsCol.Text = "Observacion"
        Me.ObsCol.Width = 358
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox6.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Location = New System.Drawing.Point(227, 47)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(277, 50)
        Me.GroupBox6.TabIndex = 143
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Rango de Fecha"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(181, 20)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaHasta.TabIndex = 55
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(53, 20)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaDesde.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde"
        '
        'ChartCasosMensual
        '
        Me.ChartCasosMensual.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ChartCasosMensual.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.ChartCasosMensual.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.ChartCasosMensual.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ChartCasosMensual.BorderlineWidth = 2
        Me.ChartCasosMensual.BorderSkin.PageColor = System.Drawing.SystemColors.Control
        Me.ChartCasosMensual.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea1.Area3DStyle.Inclination = 50
        ChartArea1.Area3DStyle.IsClustered = True
        ChartArea1.Area3DStyle.IsRightAngleAxes = False
        ChartArea1.Area3DStyle.PointGapDepth = 900
        ChartArea1.Area3DStyle.Rotation = 162
        ChartArea1.Area3DStyle.WallWidth = 25
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea1.AxisX.LabelStyle.Angle = -45
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MajorGrid.Enabled = False
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MajorTickMark.Enabled = False
        ChartArea1.AxisX2.IsLabelAutoFit = False
        ChartArea1.AxisX2.MajorGrid.Enabled = False
        ChartArea1.AxisX2.MajorTickMark.Enabled = False
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.LabelAutoFitMaxFontSize = 8
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.MajorGrid.Enabled = False
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.MajorTickMark.Enabled = False
        ChartArea1.AxisY2.IsLabelAutoFit = False
        ChartArea1.AxisY2.MajorGrid.Enabled = False
        ChartArea1.AxisY2.MajorTickMark.Enabled = False
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea1.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea1.BorderColor = System.Drawing.Color.Gray
        ChartArea1.Name = "Area1"
        ChartArea1.ShadowColor = System.Drawing.Color.Transparent
        Me.ChartCasosMensual.ChartAreas.Add(ChartArea1)
        Me.ChartCasosMensual.IsSoftShadows = False
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Font = New System.Drawing.Font("Trebuchet MS", 8.0!, System.Drawing.FontStyle.Bold)
        Legend1.IsEquallySpacedItems = True
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Default"
        Me.ChartCasosMensual.Legends.Add(Legend1)
        Me.ChartCasosMensual.Location = New System.Drawing.Point(6, 6)
        Me.ChartCasosMensual.Name = "ChartCasosMensual"
        Series1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Series1.ChartArea = "Area1"
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series1.CustomProperties = "CollectedLabel=Other, MinimumRelativePieSize=20, DoughnutRadius=25, DrawingStyle=" &
    "Cylinder, PointWidth=0.6, PieDrawingStyle=Concave, LabelStyle=Top, MaxPixelPoint" &
    "Width=100"
        Series1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.Label = "#VAL{N0}"
        Series1.Legend = "Default"
        Series1.LegendText = "Cojas"
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series1.Name = "SerieCojas"
        Series1.SmartLabelStyle.Enabled = False
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64
        Series2.ChartArea = "Area1"
        Series2.Color = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(240, Byte), Integer))
        Series2.CustomProperties = "DrawingStyle=Cylinder, EmptyPointValue=Zero, PointWidth=0.6"
        Series2.Label = "#VAL{N0}"
        Series2.Legend = "Default"
        Series2.LegendText = "Preventivos"
        Series2.Name = "SeriePreventivos"
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64
        Me.ChartCasosMensual.Series.Add(Series1)
        Me.ChartCasosMensual.Series.Add(Series2)
        Me.ChartCasosMensual.Size = New System.Drawing.Size(949, 207)
        Me.ChartCasosMensual.TabIndex = 159
        Title1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Bold)
        Title1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title1.Name = "Title1"
        Title1.ShadowOffset = 2
        Title1.Text = "CASOS X MES"
        Title1.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Emboss
        Me.ChartCasosMensual.Titles.Add(Title1)
        '
        'ChartCasosMasDe3
        '
        Me.ChartCasosMasDe3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChartCasosMasDe3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.ChartCasosMasDe3.BorderlineColor = System.Drawing.Color.Green
        Me.ChartCasosMasDe3.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ChartCasosMasDe3.BorderlineWidth = 2
        Me.ChartCasosMasDe3.BorderSkin.PageColor = System.Drawing.SystemColors.Control
        Me.ChartCasosMasDe3.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea2.Area3DStyle.Inclination = 50
        ChartArea2.Area3DStyle.IsClustered = True
        ChartArea2.Area3DStyle.IsRightAngleAxes = False
        ChartArea2.Area3DStyle.PointGapDepth = 900
        ChartArea2.Area3DStyle.Rotation = 162
        ChartArea2.Area3DStyle.WallWidth = 25
        ChartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea2.AxisX.IsLabelAutoFit = False
        ChartArea2.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisX.MajorGrid.Enabled = False
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisX.MajorTickMark.Enabled = False
        ChartArea2.AxisX2.MajorGrid.Enabled = False
        ChartArea2.AxisX2.MajorTickMark.Enabled = False
        ChartArea2.AxisY.IsLabelAutoFit = False
        ChartArea2.AxisY.LabelAutoFitMaxFontSize = 8
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisY.MajorGrid.Enabled = False
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisY.MajorTickMark.Enabled = False
        ChartArea2.AxisY2.MajorGrid.Enabled = False
        ChartArea2.AxisY2.MajorTickMark.Enabled = False
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea2.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea2.BorderColor = System.Drawing.Color.Gray
        ChartArea2.Name = "Area1"
        ChartArea2.ShadowColor = System.Drawing.Color.Transparent
        Me.ChartCasosMasDe3.ChartAreas.Add(ChartArea2)
        Me.ChartCasosMasDe3.IsSoftShadows = False
        Legend2.Alignment = System.Drawing.StringAlignment.Center
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend2.Enabled = False
        Legend2.Font = New System.Drawing.Font("Trebuchet MS", 8.0!, System.Drawing.FontStyle.Bold)
        Legend2.IsEquallySpacedItems = True
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Default"
        Me.ChartCasosMasDe3.Legends.Add(Legend2)
        Me.ChartCasosMasDe3.Location = New System.Drawing.Point(8, 219)
        Me.ChartCasosMasDe3.Name = "ChartCasosMasDe3"
        Series3.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Series3.ChartArea = "Area1"
        Series3.Color = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(240, Byte), Integer))
        Series3.CustomProperties = "CollectedLabel=Other, MinimumRelativePieSize=20, DoughnutRadius=25, DrawingStyle=" &
    "Cylinder, PointWidth=0.6, PieDrawingStyle=Concave, MaxPixelPointWidth=100"
        Series3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series3.Label = "#VAL{N0}"
        Series3.Legend = "Default"
        Series3.LegendText = "Casos"
        Series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series3.Name = "SerieCasos"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64
        Series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64
        Me.ChartCasosMasDe3.Series.Add(Series3)
        Me.ChartCasosMasDe3.Size = New System.Drawing.Size(947, 164)
        Me.ChartCasosMasDe3.TabIndex = 160
        Title2.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Bold)
        Title2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title2.Name = "Title1"
        Title2.ShadowOffset = 2
        Title2.Text = "MAS DE 3 COJERAS EN EL PERIODO"
        Title2.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow
        Me.ChartCasosMasDe3.Titles.Add(Title2)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabDatos)
        Me.TabControl1.Controls.Add(Me.TabCojas)
        Me.TabControl1.Controls.Add(Me.TabCasos)
        Me.TabControl1.Controls.Add(Me.TabOtros)
        Me.TabControl1.Location = New System.Drawing.Point(14, 130)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(969, 410)
        Me.TabControl1.TabIndex = 161
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.lvGanado)
        Me.TabDatos.Controls.Add(Me.pnlProcesa)
        Me.TabDatos.Location = New System.Drawing.Point(4, 22)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDatos.Size = New System.Drawing.Size(961, 384)
        Me.TabDatos.TabIndex = 2
        Me.TabDatos.Text = "Datos"
        Me.TabDatos.UseVisualStyleBackColor = True
        '
        'TabCojas
        '
        Me.TabCojas.BackColor = System.Drawing.Color.Transparent
        Me.TabCojas.Controls.Add(Me.ChartCojasMensual)
        Me.TabCojas.Controls.Add(Me.ChartCojasCentro)
        Me.TabCojas.Location = New System.Drawing.Point(4, 22)
        Me.TabCojas.Name = "TabCojas"
        Me.TabCojas.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCojas.Size = New System.Drawing.Size(961, 384)
        Me.TabCojas.TabIndex = 0
        Me.TabCojas.Text = "Cojas x Animal"
        '
        'ChartCojasMensual
        '
        Me.ChartCojasMensual.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChartCojasMensual.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.ChartCojasMensual.BorderlineColor = System.Drawing.Color.Green
        Me.ChartCojasMensual.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ChartCojasMensual.BorderlineWidth = 2
        Me.ChartCojasMensual.BorderSkin.PageColor = System.Drawing.SystemColors.Control
        Me.ChartCojasMensual.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea3.Area3DStyle.Inclination = 50
        ChartArea3.Area3DStyle.IsClustered = True
        ChartArea3.Area3DStyle.IsRightAngleAxes = False
        ChartArea3.Area3DStyle.PointGapDepth = 900
        ChartArea3.Area3DStyle.Rotation = 162
        ChartArea3.Area3DStyle.WallWidth = 25
        ChartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea3.AxisX.IsLabelAutoFit = False
        ChartArea3.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea3.AxisX.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea3.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea3.AxisX.MajorGrid.Enabled = False
        ChartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea3.AxisX.MajorTickMark.Enabled = False
        ChartArea3.AxisX2.MajorGrid.Enabled = False
        ChartArea3.AxisX2.MajorTickMark.Enabled = False
        ChartArea3.AxisY.IsLabelAutoFit = False
        ChartArea3.AxisY.LabelAutoFitMaxFontSize = 8
        ChartArea3.AxisY.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea3.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea3.AxisY.MajorGrid.Enabled = False
        ChartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea3.AxisY.MajorTickMark.Enabled = False
        ChartArea3.AxisY2.MajorGrid.Enabled = False
        ChartArea3.AxisY2.MajorTickMark.Enabled = False
        ChartArea3.BackColor = System.Drawing.Color.Transparent
        ChartArea3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea3.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea3.BorderColor = System.Drawing.Color.Gray
        ChartArea3.Name = "Area1"
        ChartArea3.ShadowColor = System.Drawing.Color.Transparent
        Me.ChartCojasMensual.ChartAreas.Add(ChartArea3)
        Me.ChartCojasMensual.IsSoftShadows = False
        Legend3.Alignment = System.Drawing.StringAlignment.Center
        Legend3.BackColor = System.Drawing.Color.Transparent
        Legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend3.Enabled = False
        Legend3.Font = New System.Drawing.Font("Trebuchet MS", 8.0!, System.Drawing.FontStyle.Bold)
        Legend3.IsEquallySpacedItems = True
        Legend3.IsTextAutoFit = False
        Legend3.Name = "Default"
        Me.ChartCojasMensual.Legends.Add(Legend3)
        Me.ChartCojasMensual.Location = New System.Drawing.Point(6, 6)
        Me.ChartCojasMensual.Name = "ChartCojasMensual"
        Series4.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Series4.ChartArea = "Area1"
        Series4.Color = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(240, Byte), Integer))
        Series4.CustomProperties = "CollectedLabel=Other, MinimumRelativePieSize=20, DoughnutRadius=25, DrawingStyle=" &
    "Cylinder, PointWidth=0.6, PieDrawingStyle=Concave, MaxPixelPointWidth=100"
        Series4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series4.Label = "#VAL{N0}"
        Series4.Legend = "Default"
        Series4.LegendText = "Casos"
        Series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series4.Name = "SerieCojasMes"
        Series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64
        Series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64
        Me.ChartCojasMensual.Series.Add(Series4)
        Me.ChartCojasMensual.Size = New System.Drawing.Size(949, 163)
        Me.ChartCojasMensual.TabIndex = 163
        Title3.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Bold)
        Title3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title3.Name = "Title1"
        Title3.ShadowOffset = 2
        Title3.Text = "COJAS X MES"
        Title3.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow
        Me.ChartCojasMensual.Titles.Add(Title3)
        '
        'ChartCojasCentro
        '
        Me.ChartCojasCentro.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ChartCojasCentro.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.ChartCojasCentro.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.ChartCojasCentro.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ChartCojasCentro.BorderlineWidth = 2
        Me.ChartCojasCentro.BorderSkin.PageColor = System.Drawing.SystemColors.Control
        Me.ChartCojasCentro.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea4.Area3DStyle.Inclination = 50
        ChartArea4.Area3DStyle.IsClustered = True
        ChartArea4.Area3DStyle.IsRightAngleAxes = False
        ChartArea4.Area3DStyle.PointGapDepth = 900
        ChartArea4.Area3DStyle.Rotation = 162
        ChartArea4.Area3DStyle.WallWidth = 25
        ChartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea4.AxisX.IsLabelAutoFit = False
        ChartArea4.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea4.AxisX.LabelStyle.Angle = -90
        ChartArea4.AxisX.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea4.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea4.AxisX.MajorGrid.Enabled = False
        ChartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea4.AxisX.MajorTickMark.Enabled = False
        ChartArea4.AxisX.MaximumAutoSize = 100.0!
        ChartArea4.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes
        ChartArea4.AxisX2.MajorGrid.Enabled = False
        ChartArea4.AxisX2.MajorTickMark.Enabled = False
        ChartArea4.AxisY.IsLabelAutoFit = False
        ChartArea4.AxisY.LabelAutoFitMaxFontSize = 8
        ChartArea4.AxisY.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea4.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea4.AxisY.MajorGrid.Enabled = False
        ChartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea4.AxisY.MajorTickMark.Enabled = False
        ChartArea4.AxisY2.MajorGrid.Enabled = False
        ChartArea4.AxisY2.MajorTickMark.Enabled = False
        ChartArea4.BackColor = System.Drawing.Color.Transparent
        ChartArea4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea4.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea4.BorderColor = System.Drawing.Color.Gray
        ChartArea4.Name = "Area1"
        ChartArea4.ShadowColor = System.Drawing.Color.Transparent
        Me.ChartCojasCentro.ChartAreas.Add(ChartArea4)
        Me.ChartCojasCentro.IsSoftShadows = False
        Me.ChartCojasCentro.Location = New System.Drawing.Point(3, 166)
        Me.ChartCojasCentro.Name = "ChartCojasCentro"
        Series5.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Series5.ChartArea = "Area1"
        Series5.Color = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Series5.CustomProperties = "CollectedLabel=Other, MinimumRelativePieSize=20, DoughnutRadius=25, DrawingStyle=" &
    "Cylinder, PointWidth=0.6, PieDrawingStyle=Concave, LabelStyle=Top, MaxPixelPoint" &
    "Width=100"
        Series5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series5.Label = "#VAL{N0}"
        Series5.LegendText = "Cojas"
        Series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series5.Name = "SerieCojasPorCentro"
        Series5.SmartLabelStyle.Enabled = False
        Series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.[String]
        Series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64
        Me.ChartCojasCentro.Series.Add(Series5)
        Me.ChartCojasCentro.Size = New System.Drawing.Size(952, 215)
        Me.ChartCojasCentro.TabIndex = 162
        Title4.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Bold)
        Title4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title4.Name = "Title1"
        Title4.ShadowOffset = 2
        Title4.Text = "COJAS X CENTRO"
        Title4.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Emboss
        Me.ChartCojasCentro.Titles.Add(Title4)
        '
        'TabCasos
        '
        Me.TabCasos.BackColor = System.Drawing.Color.Transparent
        Me.TabCasos.Controls.Add(Me.ChartCasosMensual)
        Me.TabCasos.Controls.Add(Me.ChartCasosMasDe3)
        Me.TabCasos.Location = New System.Drawing.Point(4, 22)
        Me.TabCasos.Name = "TabCasos"
        Me.TabCasos.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCasos.Size = New System.Drawing.Size(961, 384)
        Me.TabCasos.TabIndex = 1
        Me.TabCasos.Text = "Casos"
        '
        'TabOtros
        '
        Me.TabOtros.BackColor = System.Drawing.Color.Transparent
        Me.TabOtros.Controls.Add(Me.ChartCojasPorTipo)
        Me.TabOtros.Location = New System.Drawing.Point(4, 22)
        Me.TabOtros.Name = "TabOtros"
        Me.TabOtros.Padding = New System.Windows.Forms.Padding(3)
        Me.TabOtros.Size = New System.Drawing.Size(961, 384)
        Me.TabOtros.TabIndex = 3
        Me.TabOtros.Text = "Otros"
        '
        'ChartCojasPorTipo
        '
        Me.ChartCojasPorTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ChartCojasPorTipo.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.ChartCojasPorTipo.BorderlineColor = System.Drawing.Color.Green
        Me.ChartCojasPorTipo.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ChartCojasPorTipo.BorderlineWidth = 2
        Me.ChartCojasPorTipo.BorderSkin.PageColor = System.Drawing.SystemColors.Control
        Me.ChartCojasPorTipo.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea5.Area3DStyle.Inclination = 50
        ChartArea5.Area3DStyle.IsClustered = True
        ChartArea5.Area3DStyle.IsRightAngleAxes = False
        ChartArea5.Area3DStyle.PointGapDepth = 900
        ChartArea5.Area3DStyle.Rotation = 162
        ChartArea5.Area3DStyle.WallWidth = 25
        ChartArea5.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea5.AxisX.IsLabelAutoFit = False
        ChartArea5.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea5.AxisX.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea5.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea5.AxisX.MajorGrid.Enabled = False
        ChartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea5.AxisX.MajorTickMark.Enabled = False
        ChartArea5.AxisX2.MajorGrid.Enabled = False
        ChartArea5.AxisX2.MajorTickMark.Enabled = False
        ChartArea5.AxisY.IsLabelAutoFit = False
        ChartArea5.AxisY.LabelAutoFitMaxFontSize = 8
        ChartArea5.AxisY.LabelStyle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea5.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea5.AxisY.MajorGrid.Enabled = False
        ChartArea5.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea5.AxisY.MajorTickMark.Enabled = False
        ChartArea5.AxisY2.MajorGrid.Enabled = False
        ChartArea5.AxisY2.MajorTickMark.Enabled = False
        ChartArea5.BackColor = System.Drawing.Color.Transparent
        ChartArea5.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea5.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea5.BorderColor = System.Drawing.Color.Gray
        ChartArea5.Name = "Area1"
        ChartArea5.ShadowColor = System.Drawing.Color.Transparent
        Me.ChartCojasPorTipo.ChartAreas.Add(ChartArea5)
        Me.ChartCojasPorTipo.IsSoftShadows = False
        Legend4.BackColor = System.Drawing.Color.Transparent
        Legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left
        Legend4.Font = New System.Drawing.Font("Calibri", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Legend4.IsEquallySpacedItems = True
        Legend4.IsTextAutoFit = False
        Legend4.Name = "Default"
        Me.ChartCojasPorTipo.Legends.Add(Legend4)
        Me.ChartCojasPorTipo.Location = New System.Drawing.Point(198, 31)
        Me.ChartCojasPorTipo.Name = "ChartCojasPorTipo"
        Series6.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Series6.ChartArea = "Area1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
        Series6.Color = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(240, Byte), Integer))
        Series6.CustomProperties = "CollectedLabel=Other, MinimumRelativePieSize=20, DoughnutRadius=25, DrawingStyle=" &
    "Cylinder, PointWidth=0.6, PieDrawingStyle=SoftEdge, PieLabelStyle=Outside, MaxPi" &
    "xelPointWidth=100"
        Series6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series6.Label = "#PERCENT{P1}"
        Series6.Legend = "Default"
        Series6.LegendText = "#AXISLABEL"
        Series6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series6.Name = "SerieCojasPorTipo"
        Series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64
        Me.ChartCojasPorTipo.Series.Add(Series6)
        Me.ChartCojasPorTipo.Size = New System.Drawing.Size(566, 336)
        Me.ChartCojasPorTipo.TabIndex = 165
        Title5.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Bold)
        Title5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Title5.Name = "Title1"
        Title5.ShadowOffset = 2
        Title5.Text = "COJAS X TIPOS"
        Title5.TextStyle = System.Windows.Forms.DataVisualization.Charting.TextStyle.Shadow
        Me.ChartCojasPorTipo.Titles.Add(Title5)
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(14, 573)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 156
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnGrafico
        '
        Me.btnGrafico.Enabled = False
        Me.btnGrafico.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrafico.Image = CType(resources.GetObject("btnGrafico.Image"), System.Drawing.Image)
        Me.btnGrafico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrafico.Location = New System.Drawing.Point(293, 573)
        Me.btnGrafico.Name = "btnGrafico"
        Me.btnGrafico.Size = New System.Drawing.Size(87, 30)
        Me.btnGrafico.TabIndex = 155
        Me.btnGrafico.Text = "Graficos"
        Me.btnGrafico.UseVisualStyleBackColor = True
        Me.btnGrafico.Visible = False
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltro.Image = CType(resources.GetObject("btnLimpiarFiltro.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(732, 61)
        Me.btnLimpiarFiltro.Name = "btnLimpiarFiltro"
        Me.btnLimpiarFiltro.Size = New System.Drawing.Size(50, 30)
        Me.btnLimpiarFiltro.TabIndex = 153
        Me.btnLimpiarFiltro.UseVisualStyleBackColor = True
        Me.btnLimpiarFiltro.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(892, 573)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 144
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(200, 573)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 30)
        Me.Button6.TabIndex = 142
        Me.Button6.Text = "Imprime"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(886, 61)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 30)
        Me.btnBuscar.TabIndex = 145
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(107, 573)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 141
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(785, 61)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(98, 30)
        Me.btnLimpiarFiltros.TabIndex = 149
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        Me.btnLimpiarFiltros.Visible = False
        '
        'FrmCojeras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 613)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnGrafico)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.GroupBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCojeras"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Registro de Cojeras"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.ChartCasosMensual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartCasosMasDe3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabDatos.ResumeLayout(False)
        Me.TabCojas.ResumeLayout(False)
        CType(Me.ChartCojasMensual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartCojasCentro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCasos.ResumeLayout(False)
        Me.TabOtros.ResumeLayout(False)
        CType(Me.ChartCojasPorTipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnGrafico As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarFiltro As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEnTratamiento As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCasos As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents lvGanado As System.Windows.Forms.ListView
    Friend WithEvents NroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents EmpresaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CodCenCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CentroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents NroCasosCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents EnTratamientoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EnResguardoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblResguardo As System.Windows.Forms.Label
    Friend WithEvents TratPreventivosCol As System.Windows.Forms.ColumnHeader
    Private WithEvents ChartCasosMensual As System.Windows.Forms.DataVisualization.Charting.Chart
    Private WithEvents ChartCasosMasDe3 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lblPreventivos As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabCojas As System.Windows.Forms.TabPage
    Private WithEvents ChartCojasCentro As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TabCasos As System.Windows.Forms.TabPage
    Friend WithEvents TabDatos As System.Windows.Forms.TabPage
    Private WithEvents ChartCojasMensual As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TabOtros As System.Windows.Forms.TabPage
    Private WithEvents ChartCojasPorTipo As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ObsCol As System.Windows.Forms.ColumnHeader
End Class
