<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecuentoCSDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecuentoCSDetalle))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.lblCodEstanque = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblNomEstanque = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvRCS = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CantCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EneCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FebCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MarCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AbrCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MayCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JunCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JulCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AgoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SepCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OctCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NovCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DicCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblAño = New System.Windows.Forms.Label()
        Me.lblMesNom = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCodEstanque
        '
        Me.lblCodEstanque.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodEstanque.ForeColor = System.Drawing.Color.White
        Me.lblCodEstanque.Location = New System.Drawing.Point(888, 14)
        Me.lblCodEstanque.Name = "lblCodEstanque"
        Me.lblCodEstanque.Size = New System.Drawing.Size(89, 20)
        Me.lblCodEstanque.TabIndex = 2
        Me.lblCodEstanque.Text = "Codigo"
        Me.lblCodEstanque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.lblCodEstanque)
        Me.Panel1.Controls.Add(Me.lblNomEstanque)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(990, 41)
        Me.Panel1.TabIndex = 111
        '
        'lblNomEstanque
        '
        Me.lblNomEstanque.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomEstanque.ForeColor = System.Drawing.Color.White
        Me.lblNomEstanque.Location = New System.Drawing.Point(540, 5)
        Me.lblNomEstanque.Name = "lblNomEstanque"
        Me.lblNomEstanque.Size = New System.Drawing.Size(248, 26)
        Me.lblNomEstanque.TabIndex = 2
        Me.lblNomEstanque.Text = "Nombre del Estanque"
        Me.lblNomEstanque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(139, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(437, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Detalle Recuento Celulas Somaticas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvRCS
        '
        Me.lvRCS.AutoArrange = False
        Me.lvRCS.BackColor = System.Drawing.SystemColors.Window
        Me.lvRCS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader1, Me.DiaCol, Me.CantCol, Me.EneCol, Me.FebCol, Me.MarCol, Me.AbrCol, Me.MayCol, Me.JunCol, Me.JulCol, Me.AgoCol, Me.SepCol, Me.OctCol, Me.NovCol, Me.DicCol})
        Me.lvRCS.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRCS.FullRowSelect = True
        Me.lvRCS.GridLines = True
        Me.lvRCS.HideSelection = False
        Me.lvRCS.Location = New System.Drawing.Point(12, 78)
        Me.lvRCS.MultiSelect = False
        Me.lvRCS.Name = "lvRCS"
        Me.lvRCS.Size = New System.Drawing.Size(115, 497)
        Me.lvRCS.TabIndex = 105
        Me.lvRCS.UseCompatibleStateImageBehavior = False
        Me.lvRCS.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Ordena"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Empresa"
        Me.ColumnHeader1.Width = 0
        '
        'DiaCol
        '
        Me.DiaCol.Text = "Dia"
        Me.DiaCol.Width = 33
        '
        'CantCol
        '
        Me.CantCol.Text = "Cant."
        '
        'EneCol
        '
        Me.EneCol.Text = "Ene"
        Me.EneCol.Width = 0
        '
        'FebCol
        '
        Me.FebCol.Text = "Feb"
        Me.FebCol.Width = 0
        '
        'MarCol
        '
        Me.MarCol.Text = "Mar"
        Me.MarCol.Width = 0
        '
        'AbrCol
        '
        Me.AbrCol.Text = "Abr"
        Me.AbrCol.Width = 0
        '
        'MayCol
        '
        Me.MayCol.Text = "Mayo"
        Me.MayCol.Width = 0
        '
        'JunCol
        '
        Me.JunCol.Text = "Jun"
        Me.JunCol.Width = 0
        '
        'JulCol
        '
        Me.JulCol.Text = "Jul"
        Me.JulCol.Width = 0
        '
        'AgoCol
        '
        Me.AgoCol.Text = "Ago"
        Me.AgoCol.Width = 0
        '
        'SepCol
        '
        Me.SepCol.Text = "Sep"
        Me.SepCol.Width = 0
        '
        'OctCol
        '
        Me.OctCol.Text = "Oct"
        Me.OctCol.Width = 0
        '
        'NovCol
        '
        Me.NovCol.Text = "Nov"
        Me.NovCol.Width = 0
        '
        'DicCol
        '
        Me.DicCol.Text = "Dic"
        Me.DicCol.Width = 0
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(892, 581)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 101
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
        Me.Button6.Location = New System.Drawing.Point(108, 581)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 30)
        Me.Button6.TabIndex = 99
        Me.Button6.Text = "Imprime"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(15, 581)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 96
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel3.Controls.Add(Me.lblAño)
        Me.Panel3.Controls.Add(Me.lblMesNom)
        Me.Panel3.Location = New System.Drawing.Point(12, 46)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(964, 24)
        Me.Panel3.TabIndex = 120
        '
        'lblAño
        '
        Me.lblAño.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAño.ForeColor = System.Drawing.Color.White
        Me.lblAño.Location = New System.Drawing.Point(509, -4)
        Me.lblAño.Name = "lblAño"
        Me.lblAño.Size = New System.Drawing.Size(54, 33)
        Me.lblAño.TabIndex = 117
        Me.lblAño.Text = "Año"
        Me.lblAño.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMesNom
        '
        Me.lblMesNom.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMesNom.ForeColor = System.Drawing.Color.White
        Me.lblMesNom.Location = New System.Drawing.Point(385, -6)
        Me.lblMesNom.Name = "lblMesNom"
        Me.lblMesNom.Size = New System.Drawing.Size(74, 33)
        Me.lblMesNom.TabIndex = 118
        Me.lblMesNom.Text = "Mes"
        Me.lblMesNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Chart1.BorderlineColor = System.Drawing.Color.Navy
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart1.BorderlineWidth = 3
        Me.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea1.Area3DStyle.Inclination = 15
        ChartArea1.Area3DStyle.IsClustered = True
        ChartArea1.Area3DStyle.IsRightAngleAxes = False
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea1.Area3DStyle.Perspective = 10
        ChartArea1.Area3DStyle.Rotation = 10
        ChartArea1.Area3DStyle.WallWidth = 0
        ChartArea1.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea1.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisX.LabelStyle.Format = "0"
        ChartArea1.AxisX.LabelStyle.Interval = 0.0R
        ChartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MaximumAutoSize = 100.0!
        ChartArea1.AxisY.LabelAutoFitMaxFontSize = 8
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY.LabelStyle.Format = "0"
        ChartArea1.AxisY.LabelStyle.Interval = 0.0R
        ChartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.BackColor = System.Drawing.Color.OldLace
        ChartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea1.BackSecondaryColor = System.Drawing.Color.White
        ChartArea1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.CursorX.AutoScroll = False
        ChartArea1.CursorX.IntervalOffset = 1.0R
        ChartArea1.CursorX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days
        ChartArea1.Name = "Default"
        ChartArea1.ShadowColor = System.Drawing.Color.Transparent
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Enabled = False
        Legend1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Default"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(133, 78)
        Me.Chart1.Name = "Chart1"
        Series1.BorderColor = System.Drawing.Color.Red
        Series1.BorderWidth = 3
        Series1.ChartArea = "Default"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Series1.EmptyPointStyle.Color = System.Drawing.Color.White
        Series1.IsValueShownAsLabel = True
        Series1.Legend = "Default"
        Series1.MarkerBorderWidth = 2
        Series1.MarkerSize = 2
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series1.Name = "Series1"
        Series1.SmartLabelStyle.CalloutLineWidth = 5
        Series1.YValuesPerPoint = 2
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(843, 247)
        Me.Chart1.TabIndex = 122
        Title1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Bold)
        Title1.ForeColor = System.Drawing.Color.Maroon
        Title1.Name = "Title1"
        Title1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Title1.ShadowOffset = 3
        Title1.Text = "Recuento Diario de Celulas Somatica"
        Me.Chart1.Titles.Add(Title1)
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Chart2.BackSecondaryColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Chart2.BorderlineColor = System.Drawing.Color.ForestGreen
        Me.Chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart2.BorderlineWidth = 5
        Me.Chart2.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea2.Area3DStyle.Inclination = 15
        ChartArea2.Area3DStyle.IsClustered = True
        ChartArea2.Area3DStyle.IsRightAngleAxes = False
        ChartArea2.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea2.Area3DStyle.Perspective = 10
        ChartArea2.Area3DStyle.Rotation = 10
        ChartArea2.Area3DStyle.WallWidth = 0
        ChartArea2.AxisX.LabelAutoFitMaxFontSize = 8
        ChartArea2.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisX.LabelStyle.Format = "0"
        ChartArea2.AxisX.LabelStyle.Interval = 0.0R
        ChartArea2.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisX.MaximumAutoSize = 100.0!
        ChartArea2.AxisY.LabelAutoFitMaxFontSize = 8
        ChartArea2.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea2.AxisY.LabelStyle.Format = "0"
        ChartArea2.AxisY.LabelStyle.Interval = 0.0R
        ChartArea2.AxisY.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.BackColor = System.Drawing.Color.OldLace
        ChartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        ChartArea2.BackSecondaryColor = System.Drawing.Color.White
        ChartArea2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea2.CursorX.AutoScroll = False
        ChartArea2.CursorX.IntervalOffset = 1.0R
        ChartArea2.CursorX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days
        ChartArea2.Name = "Default"
        ChartArea2.ShadowColor = System.Drawing.Color.Transparent
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend2.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend2.IsTextAutoFit = False
        Legend2.Name = "Default"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(133, 331)
        Me.Chart2.Name = "Chart2"
        Series2.BorderColor = System.Drawing.Color.Red
        Series2.BorderWidth = 3
        Series2.ChartArea = "Default"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Series2.EmptyPointStyle.Color = System.Drawing.Color.White
        Series2.IsValueShownAsLabel = True
        Series2.Legend = "Default"
        Series2.MarkerBorderWidth = 2
        Series2.MarkerSize = 2
        Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series2.Name = "Series1"
        Series2.SmartLabelStyle.CalloutLineWidth = 5
        Series2.YValuesPerPoint = 2
        Series3.BorderColor = System.Drawing.Color.White
        Series3.BorderWidth = 2
        Series3.ChartArea = "Default"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series3.Color = System.Drawing.Color.Red
        Series3.Legend = "Default"
        Series3.MarkerSize = 7
        Series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle
        Series3.Name = "Series2"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Series.Add(Series3)
        Me.Chart2.Size = New System.Drawing.Size(843, 244)
        Me.Chart2.TabIndex = 123
        Title2.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Bold)
        Title2.ForeColor = System.Drawing.Color.Maroon
        Title2.Name = "Title1"
        Title2.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Title2.ShadowOffset = 3
        Title2.Text = "Comparación Mensual Recuento de Célula Somática"
        Me.Chart2.Titles.Add(Title2)
        '
        'FrmRecuentoCSDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 614)
        Me.ControlBox = False
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.lvRCS)
        Me.Name = "FrmRecuentoCSDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Recuento Celulas Somaticas"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvRCS As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents DiaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblCodEstanque As System.Windows.Forms.Label
    Friend WithEvents EneCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents FebCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents MarCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents AbrCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents MayCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents JunCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents JulCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents AgoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents SepCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents OctCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents NovCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DicCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblAño As System.Windows.Forms.Label
    Friend WithEvents lblMesNom As System.Windows.Forms.Label
    Friend WithEvents CantCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblNomEstanque As System.Windows.Forms.Label
    Private WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Private WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
