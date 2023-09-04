<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRecuentoCS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecuentoCS))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblSobre300 = New System.Windows.Forms.Label()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.lvRCS = New System.Windows.Forms.ListView()
        Me.OrdenaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodEstanqueCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LineaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EstanqueCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EneroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FebreroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MarzoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AbrilCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MayoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JunioCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JulioCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AgostoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SeptiembreCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OctubreCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NoviembreCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiciembreCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblMenosDe300 = New System.Windows.Forms.Label()
        Me.lblTotReg = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboEstanques = New System.Windows.Forms.ComboBox()
        Me.Año = New System.Windows.Forms.GroupBox()
        Me.cboAñoRCS = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPosY = New System.Windows.Forms.Label()
        Me.lblPosX = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Año.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.Enabled = False
        Me.btnLimpiarFiltro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltro.Image = CType(resources.GetObject("btnLimpiarFiltro.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(835, 69)
        Me.btnLimpiarFiltro.Name = "btnLimpiarFiltro"
        Me.btnLimpiarFiltro.Size = New System.Drawing.Size(50, 30)
        Me.btnLimpiarFiltro.TabIndex = 95
        Me.btnLimpiarFiltro.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblSobre300)
        Me.Panel2.Controls.Add(Me.lblOrden)
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(16, 105)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1117, 23)
        Me.Panel2.TabIndex = 94
        '
        'lblSobre300
        '
        Me.lblSobre300.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSobre300.Location = New System.Drawing.Point(299, 2)
        Me.lblSobre300.Name = "lblSobre300"
        Me.lblSobre300.Size = New System.Drawing.Size(580, 21)
        Me.lblSobre300.TabIndex = 40
        Me.lblSobre300.Text = "Sobre 300.000 --> ALTO  Grado de Infección. Fondo oscuro 2 veces al día."
        '
        'lblOrden
        '
        Me.lblOrden.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.ForeColor = System.Drawing.Color.White
        Me.lblOrden.Location = New System.Drawing.Point(115, 1)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(934, 19)
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
        'btnImportar
        '
        Me.btnImportar.Enabled = False
        Me.btnImportar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportar.Location = New System.Drawing.Point(105, 596)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(87, 30)
        Me.btnImportar.TabIndex = 93
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1143, 41)
        Me.Panel1.TabIndex = 92
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
        Me.Label3.Text = "RECUENTO CELULAS SOMATICAS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 596)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 90
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(238, 50)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(12, 19)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(214, 22)
        Me.cboCentros.TabIndex = 0
        '
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(220, 217)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(655, 53)
        Me.pnlProcesa.TabIndex = 87
        Me.pnlProcesa.Visible = False
        '
        'lblProcesa
        '
        Me.lblProcesa.AutoSize = True
        Me.lblProcesa.Location = New System.Drawing.Point(9, 9)
        Me.lblProcesa.Name = "lblProcesa"
        Me.lblProcesa.Size = New System.Drawing.Size(75, 13)
        Me.lblProcesa.TabIndex = 69
        Me.lblProcesa.Text = "Consultando..."
        '
        'pbProcesa
        '
        Me.pbProcesa.Location = New System.Drawing.Point(12, 23)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(625, 18)
        Me.pbProcesa.TabIndex = 68
        '
        'lvRCS
        '
        Me.lvRCS.AutoArrange = False
        Me.lvRCS.BackColor = System.Drawing.SystemColors.Window
        Me.lvRCS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OrdenaCol, Me.CodEstanqueCol, Me.LineaCol, Me.CentroCol, Me.EstanqueCol, Me.EneroCol, Me.FebreroCol, Me.MarzoCol, Me.AbrilCol, Me.MayoCol, Me.JunioCol, Me.JulioCol, Me.AgostoCol, Me.SeptiembreCol, Me.OctubreCol, Me.NoviembreCol, Me.DiciembreCol, Me.CentroCodCol})
        Me.lvRCS.FullRowSelect = True
        Me.lvRCS.GridLines = True
        Me.lvRCS.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvRCS.HideSelection = False
        Me.lvRCS.Location = New System.Drawing.Point(12, 132)
        Me.lvRCS.MultiSelect = False
        Me.lvRCS.Name = "lvRCS"
        Me.lvRCS.Size = New System.Drawing.Size(1121, 192)
        Me.lvRCS.TabIndex = 86
        Me.lvRCS.UseCompatibleStateImageBehavior = False
        Me.lvRCS.View = System.Windows.Forms.View.Details
        '
        'OrdenaCol
        '
        Me.OrdenaCol.Text = "Ordena"
        Me.OrdenaCol.Width = 0
        '
        'CodEstanqueCol
        '
        Me.CodEstanqueCol.Text = "CodEstanque"
        Me.CodEstanqueCol.Width = 0
        '
        'LineaCol
        '
        Me.LineaCol.Text = "Lin."
        Me.LineaCol.Width = 31
        '
        'CentroCol
        '
        Me.CentroCol.Text = "Centro"
        Me.CentroCol.Width = 150
        '
        'EstanqueCol
        '
        Me.EstanqueCol.Text = "Estanque Centro"
        Me.EstanqueCol.Width = 157
        '
        'EneroCol
        '
        Me.EneroCol.Text = "Ene"
        Me.EneroCol.Width = 65
        '
        'FebreroCol
        '
        Me.FebreroCol.Text = "Feb"
        Me.FebreroCol.Width = 65
        '
        'MarzoCol
        '
        Me.MarzoCol.Text = "Mar"
        Me.MarzoCol.Width = 65
        '
        'AbrilCol
        '
        Me.AbrilCol.Text = "Abr"
        Me.AbrilCol.Width = 65
        '
        'MayoCol
        '
        Me.MayoCol.Text = "May"
        Me.MayoCol.Width = 65
        '
        'JunioCol
        '
        Me.JunioCol.Text = "Jun"
        Me.JunioCol.Width = 65
        '
        'JulioCol
        '
        Me.JulioCol.Text = "Jul"
        Me.JulioCol.Width = 65
        '
        'AgostoCol
        '
        Me.AgostoCol.Text = "Ago"
        Me.AgostoCol.Width = 65
        '
        'SeptiembreCol
        '
        Me.SeptiembreCol.Text = "Sep"
        Me.SeptiembreCol.Width = 65
        '
        'OctubreCol
        '
        Me.OctubreCol.Text = "Oct"
        Me.OctubreCol.Width = 65
        '
        'NoviembreCol
        '
        Me.NoviembreCol.Text = "Nov"
        Me.NoviembreCol.Width = 65
        '
        'DiciembreCol
        '
        Me.DiciembreCol.Text = "Dic"
        Me.DiciembreCol.Width = 65
        '
        'CentroCodCol
        '
        Me.CentroCodCol.Text = "CenCod"
        Me.CentroCodCol.Width = 0
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Enabled = False
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(888, 69)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(98, 30)
        Me.btnLimpiarFiltros.TabIndex = 88
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1021, 594)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(105, 30)
        Me.btnSalir.TabIndex = 82
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(291, 596)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 30)
        Me.Button6.TabIndex = 80
        Me.Button6.Text = "Imprime"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(990, 69)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(97, 30)
        Me.btnBuscar.TabIndex = 83
        Me.btnBuscar.Text = "Consultar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(198, 596)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 77
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblMenosDe300)
        Me.pnlEstReprod.Controls.Add(Me.lblTotReg)
        Me.pnlEstReprod.Controls.Add(Me.Label86)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(11, 325)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1122, 26)
        Me.pnlEstReprod.TabIndex = 85
        '
        'lblMenosDe300
        '
        Me.lblMenosDe300.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMenosDe300.Location = New System.Drawing.Point(303, 4)
        Me.lblMenosDe300.Name = "lblMenosDe300"
        Me.lblMenosDe300.Size = New System.Drawing.Size(580, 21)
        Me.lblMenosDe300.TabIndex = 42
        Me.lblMenosDe300.Text = "Sobre 250.000 --> Grado de Infección Media. Fondo oscuro 1 veces al día en busque" &
    "da MC."
        '
        'lblTotReg
        '
        Me.lblTotReg.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotReg.Location = New System.Drawing.Point(119, -1)
        Me.lblTotReg.Name = "lblTotReg"
        Me.lblTotReg.Size = New System.Drawing.Size(31, 21)
        Me.lblTotReg.TabIndex = 1
        Me.lblTotReg.Text = "0"
        '
        'Label86
        '
        Me.Label86.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(3, -1)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(126, 21)
        Me.Label86.TabIndex = 0
        Me.Label86.Text = "Total Registros:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboEstanques)
        Me.GroupBox3.Location = New System.Drawing.Point(248, 51)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(236, 50)
        Me.GroupBox3.TabIndex = 97
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Estanque"
        '
        'cboEstanques
        '
        Me.cboEstanques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstanques.Enabled = False
        Me.cboEstanques.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.cboEstanques.FormattingEnabled = True
        Me.cboEstanques.Location = New System.Drawing.Point(12, 19)
        Me.cboEstanques.Name = "cboEstanques"
        Me.cboEstanques.Size = New System.Drawing.Size(218, 22)
        Me.cboEstanques.TabIndex = 0
        '
        'Año
        '
        Me.Año.Controls.Add(Me.cboAñoRCS)
        Me.Año.Location = New System.Drawing.Point(508, 54)
        Me.Año.Name = "Año"
        Me.Año.Size = New System.Drawing.Size(122, 50)
        Me.Año.TabIndex = 98
        Me.Año.TabStop = False
        Me.Año.Text = "Año"
        '
        'cboAñoRCS
        '
        Me.cboAñoRCS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAñoRCS.Font = New System.Drawing.Font("Calibri", 9.0!)
        Me.cboAñoRCS.FormattingEnabled = True
        Me.cboAñoRCS.Location = New System.Drawing.Point(12, 19)
        Me.cboAñoRCS.Name = "cboAñoRCS"
        Me.cboAñoRCS.Size = New System.Drawing.Size(100, 22)
        Me.cboAñoRCS.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "X:"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.lblMes)
        Me.GroupBox11.Controls.Add(Me.Label4)
        Me.GroupBox11.Controls.Add(Me.lblPosY)
        Me.GroupBox11.Controls.Add(Me.lblPosX)
        Me.GroupBox11.Controls.Add(Me.Label2)
        Me.GroupBox11.Controls.Add(Me.Label1)
        Me.GroupBox11.Location = New System.Drawing.Point(508, 594)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(191, 43)
        Me.GroupBox11.TabIndex = 96
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Posición Cursor Mouse"
        '
        'lblMes
        '
        Me.lblMes.AutoSize = True
        Me.lblMes.Location = New System.Drawing.Point(138, 19)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(13, 13)
        Me.lblMes.TabIndex = 104
        Me.lblMes.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(102, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "MES:"
        '
        'lblPosY
        '
        Me.lblPosY.AutoSize = True
        Me.lblPosY.Location = New System.Drawing.Point(75, 19)
        Me.lblPosY.Name = "lblPosY"
        Me.lblPosY.Size = New System.Drawing.Size(13, 13)
        Me.lblPosY.TabIndex = 102
        Me.lblPosY.Text = "0"
        '
        'lblPosX
        '
        Me.lblPosX.AutoSize = True
        Me.lblPosX.Location = New System.Drawing.Point(28, 19)
        Me.lblPosX.Name = "lblPosX"
        Me.lblPosX.Size = New System.Drawing.Size(13, 13)
        Me.lblPosX.TabIndex = 101
        Me.lblPosX.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(58, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Y:"
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.Chart2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Chart2.BackSecondaryColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Chart2.BorderlineColor = System.Drawing.Color.ForestGreen
        Me.Chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart2.BorderlineWidth = 3
        Me.Chart2.BorderSkin.PageColor = System.Drawing.SystemColors.Control
        Me.Chart2.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
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
        ChartArea1.AxisX.LabelStyle.Interval = 0R
        ChartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        ChartArea1.AxisX.MaximumAutoSize = 100.0!
        ChartArea1.AxisY.LabelAutoFitMaxFontSize = 8
        ChartArea1.AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        ChartArea1.AxisY.LabelStyle.Format = "0"
        ChartArea1.AxisY.LabelStyle.Interval = 0R
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
        Me.Chart2.ChartAreas.Add(ChartArea1)
        Legend1.Alignment = System.Drawing.StringAlignment.Center
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold)
        Legend1.IsTextAutoFit = False
        Legend1.Name = "Default"
        Me.Chart2.Legends.Add(Legend1)
        Me.Chart2.Location = New System.Drawing.Point(105, 354)
        Me.Chart2.Name = "Chart2"
        Series1.BorderColor = System.Drawing.Color.Red
        Series1.BorderWidth = 3
        Series1.ChartArea = "Default"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Series1.EmptyPointStyle.Color = System.Drawing.Color.White
        Series1.IsValueShownAsLabel = True
        Series1.Legend = "Default"
        Series1.MarkerBorderWidth = 2
        Series1.MarkerSize = 2
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series1.Name = "Series1"
        Series1.SmartLabelStyle.CalloutLineWidth = 5
        Series1.YValuesPerPoint = 2
        Series2.BorderColor = System.Drawing.Color.White
        Series2.BorderWidth = 2
        Series2.ChartArea = "Default"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Color = System.Drawing.Color.Red
        Series2.Legend = "Default"
        Series2.MarkerSize = 7
        Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle
        Series2.Name = "Series2"
        Me.Chart2.Series.Add(Series1)
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(944, 237)
        Me.Chart2.TabIndex = 124
        Title1.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Bold)
        Title1.ForeColor = System.Drawing.Color.Maroon
        Title1.Name = "Title1"
        Title1.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Title1.ShadowOffset = 3
        Me.Chart2.Titles.Add(Title1)
        '
        'FrmRecuentoCS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 636)
        Me.ControlBox = False
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.Año)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox11)
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.lvRCS)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmRecuentoCS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Recuento de Célula Somática"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.pnlEstReprod.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Año.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLimpiarFiltro As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents lvRCS As System.Windows.Forms.ListView
    Friend WithEvents LineaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CodEstanqueCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CentroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents EneroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents FebreroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents MarzoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents AbrilCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents MayoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents JunioCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents JulioCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents lblMenosDe300 As System.Windows.Forms.Label
    Friend WithEvents lblSobre300 As System.Windows.Forms.Label
    Friend WithEvents lblTotReg As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents AgostoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents SeptiembreCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents OctubreCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents NoviembreCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DiciembreCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents EstanqueCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboEstanques As System.Windows.Forms.ComboBox
    Friend WithEvents Año As System.Windows.Forms.GroupBox
    Friend WithEvents cboAñoRCS As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPosY As System.Windows.Forms.Label
    Friend WithEvents lblPosX As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblMes As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OrdenaCol As System.Windows.Forms.ColumnHeader
    Private WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents CentroCodCol As System.Windows.Forms.ColumnHeader
End Class
