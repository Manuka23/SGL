<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDecomisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDecomisos))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.lvDecomisos = New System.Windows.Forms.ListView()
        Me.OrdenaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LineaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.TotalCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblTotReg = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboAño = New System.Windows.Forms.ComboBox()
        Me.lvDecomisosCateg = New System.Windows.Forms.ListView()
        Me.OrdenaColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LinColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CateCodColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CateNomColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EneColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FebColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MarColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AbrColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MayColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JunColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.JulColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AgoColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SepColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.OctColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NovColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DicColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotalColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnVerDetalle = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(15, 118)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1100, 23)
        Me.Panel2.TabIndex = 110
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(8, 1)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(344, 19)
        Me.Label61.TabIndex = 1
        Me.Label61.Text = "DETALLE POR CENTRO"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(238, 50)
        Me.GroupBox1.TabIndex = 107
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(14, 19)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(218, 23)
        Me.cboCentros.TabIndex = 117
        '
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(259, 364)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(655, 53)
        Me.pnlProcesa.TabIndex = 105
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
        Me.pbProcesa.Location = New System.Drawing.Point(12, 25)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(625, 18)
        Me.pbProcesa.TabIndex = 68
        '
        'lvDecomisos
        '
        Me.lvDecomisos.AutoArrange = False
        Me.lvDecomisos.BackColor = System.Drawing.SystemColors.Window
        Me.lvDecomisos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OrdenaCol, Me.LineaCol, Me.CentroCodCol, Me.CentroCol, Me.EneroCol, Me.FebreroCol, Me.MarzoCol, Me.AbrilCol, Me.MayoCol, Me.JunioCol, Me.JulioCol, Me.AgostoCol, Me.SeptiembreCol, Me.OctubreCol, Me.NoviembreCol, Me.DiciembreCol, Me.TotalCol})
        Me.lvDecomisos.FullRowSelect = True
        Me.lvDecomisos.GridLines = True
        Me.lvDecomisos.HideSelection = False
        Me.lvDecomisos.Location = New System.Drawing.Point(15, 142)
        Me.lvDecomisos.MultiSelect = False
        Me.lvDecomisos.Name = "lvDecomisos"
        Me.lvDecomisos.Size = New System.Drawing.Size(1100, 250)
        Me.lvDecomisos.TabIndex = 104
        Me.lvDecomisos.UseCompatibleStateImageBehavior = False
        Me.lvDecomisos.View = System.Windows.Forms.View.Details
        '
        'OrdenaCol
        '
        Me.OrdenaCol.Text = "Ordena"
        Me.OrdenaCol.Width = 0
        '
        'LineaCol
        '
        Me.LineaCol.Text = "Lin."
        Me.LineaCol.Width = 39
        '
        'CentroCodCol
        '
        Me.CentroCodCol.Text = "CenCod"
        Me.CentroCodCol.Width = 0
        '
        'CentroCol
        '
        Me.CentroCol.Text = "Centro"
        Me.CentroCol.Width = 206
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
        'TotalCol
        '
        Me.TotalCol.Text = "Total"
        Me.TotalCol.Width = 71
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Info
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblTotReg)
        Me.pnlEstReprod.Controls.Add(Me.Label86)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(15, 392)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1100, 24)
        Me.pnlEstReprod.TabIndex = 103
        '
        'lblTotReg
        '
        Me.lblTotReg.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotReg.Location = New System.Drawing.Point(135, 3)
        Me.lblTotReg.Name = "lblTotReg"
        Me.lblTotReg.Size = New System.Drawing.Size(31, 21)
        Me.lblTotReg.TabIndex = 1
        Me.lblTotReg.Text = "0"
        '
        'Label86
        '
        Me.Label86.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(3, 3)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(126, 21)
        Me.Label86.TabIndex = 0
        Me.Label86.Text = "Total Registros:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1114, 41)
        Me.Panel1.TabIndex = 115
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
        Me.Label3.Text = "Decomisos en Ventas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox6.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Enabled = False
        Me.GroupBox6.Location = New System.Drawing.Point(290, 48)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(277, 50)
        Me.GroupBox6.TabIndex = 116
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Hasta"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Desde"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboAño)
        Me.GroupBox2.Location = New System.Drawing.Point(572, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(138, 50)
        Me.GroupBox2.TabIndex = 117
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Año"
        '
        'cboAño
        '
        Me.cboAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cboAño.FormattingEnabled = True
        Me.cboAño.Items.AddRange(New Object() {"2012", "2011"})
        Me.cboAño.Location = New System.Drawing.Point(6, 20)
        Me.cboAño.Name = "cboAño"
        Me.cboAño.Size = New System.Drawing.Size(121, 23)
        Me.cboAño.TabIndex = 0
        '
        'lvDecomisosCateg
        '
        Me.lvDecomisosCateg.AutoArrange = False
        Me.lvDecomisosCateg.BackColor = System.Drawing.SystemColors.Window
        Me.lvDecomisosCateg.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OrdenaColumn, Me.LinColumn, Me.CateCodColumn, Me.CateNomColumn, Me.EneColumn, Me.FebColumn, Me.MarColumn, Me.AbrColumn, Me.MayColumn, Me.JunColumn, Me.JulColumn, Me.AgoColumn, Me.SepColumn, Me.OctColumn, Me.NovColumn, Me.DicColumn, Me.TotalColumn})
        Me.lvDecomisosCateg.FullRowSelect = True
        Me.lvDecomisosCateg.GridLines = True
        Me.lvDecomisosCateg.HideSelection = False
        Me.lvDecomisosCateg.Location = New System.Drawing.Point(12, 459)
        Me.lvDecomisosCateg.MultiSelect = False
        Me.lvDecomisosCateg.Name = "lvDecomisosCateg"
        Me.lvDecomisosCateg.Size = New System.Drawing.Size(1103, 128)
        Me.lvDecomisosCateg.TabIndex = 118
        Me.lvDecomisosCateg.UseCompatibleStateImageBehavior = False
        Me.lvDecomisosCateg.View = System.Windows.Forms.View.Details
        '
        'OrdenaColumn
        '
        Me.OrdenaColumn.Text = "Ordena"
        Me.OrdenaColumn.Width = 0
        '
        'LinColumn
        '
        Me.LinColumn.Text = "Lin."
        Me.LinColumn.Width = 31
        '
        'CateCodColumn
        '
        Me.CateCodColumn.Text = "CateCod"
        Me.CateCodColumn.Width = 64
        '
        'CateNomColumn
        '
        Me.CateNomColumn.Text = "CateNom"
        Me.CateNomColumn.Width = 142
        '
        'EneColumn
        '
        Me.EneColumn.Text = "Ene"
        Me.EneColumn.Width = 65
        '
        'FebColumn
        '
        Me.FebColumn.Text = "Feb"
        Me.FebColumn.Width = 65
        '
        'MarColumn
        '
        Me.MarColumn.Text = "Mar"
        Me.MarColumn.Width = 65
        '
        'AbrColumn
        '
        Me.AbrColumn.Text = "Abr"
        Me.AbrColumn.Width = 65
        '
        'MayColumn
        '
        Me.MayColumn.Text = "May"
        Me.MayColumn.Width = 65
        '
        'JunColumn
        '
        Me.JunColumn.Text = "Jun"
        Me.JunColumn.Width = 65
        '
        'JulColumn
        '
        Me.JulColumn.Text = "Jul"
        Me.JulColumn.Width = 65
        '
        'AgoColumn
        '
        Me.AgoColumn.Text = "Ago"
        Me.AgoColumn.Width = 65
        '
        'SepColumn
        '
        Me.SepColumn.Text = "Sep"
        Me.SepColumn.Width = 65
        '
        'OctColumn
        '
        Me.OctColumn.Text = "Oct"
        Me.OctColumn.Width = 65
        '
        'NovColumn
        '
        Me.NovColumn.Text = "Nov"
        Me.NovColumn.Width = 65
        '
        'DicColumn
        '
        Me.DicColumn.Text = "Dic"
        Me.DicColumn.Width = 65
        '
        'TotalColumn
        '
        Me.TotalColumn.Text = "Total"
        Me.TotalColumn.Width = 78
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.Enabled = False
        Me.btnLimpiarFiltro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltro.Image = CType(resources.GetObject("btnLimpiarFiltro.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(835, 58)
        Me.btnLimpiarFiltro.Name = "btnLimpiarFiltro"
        Me.btnLimpiarFiltro.Size = New System.Drawing.Size(50, 30)
        Me.btnLimpiarFiltro.TabIndex = 111
        Me.btnLimpiarFiltro.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Enabled = False
        Me.btnImportar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportar.Location = New System.Drawing.Point(105, 619)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(87, 30)
        Me.btnImportar.TabIndex = 109
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 619)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 108
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Enabled = False
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(888, 58)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(98, 30)
        Me.btnLimpiarFiltros.TabIndex = 106
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1018, 620)
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
        Me.Button6.Enabled = False
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(291, 619)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 30)
        Me.Button6.TabIndex = 100
        Me.Button6.Text = "Imprime"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(990, 58)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(100, 30)
        Me.btnBuscar.TabIndex = 102
        Me.btnBuscar.Text = "Consultar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Enabled = False
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(198, 619)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 99
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnVerDetalle
        '
        Me.btnVerDetalle.BackColor = System.Drawing.Color.SteelBlue
        Me.btnVerDetalle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerDetalle.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnVerDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVerDetalle.Location = New System.Drawing.Point(399, 620)
        Me.btnVerDetalle.Name = "btnVerDetalle"
        Me.btnVerDetalle.Size = New System.Drawing.Size(110, 29)
        Me.btnVerDetalle.TabIndex = 119
        Me.btnVerDetalle.Text = "Ver Detalle"
        Me.btnVerDetalle.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New System.Drawing.Point(12, 435)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1100, 23)
        Me.Panel3.TabIndex = 111
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(8, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(344, 19)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "DETALLE POR CATEGORIA DEL ANIMAL"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmDecomisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1117, 650)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnVerDetalle)
        Me.Controls.Add(Me.lvDecomisosCateg)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.lvDecomisos)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmDecomisos"
        Me.Text = "Decomisos"
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.pnlEstReprod.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLimpiarFiltro As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents lvDecomisos As System.Windows.Forms.ListView
    Friend WithEvents OrdenaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CentroCodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents LineaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CentroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents EneroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents lblTotReg As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FebreroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents MarzoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents AbrilCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents MayoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents JunioCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents JulioCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents AgostoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents SeptiembreCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents OctubreCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents NoviembreCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DiciembreCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents TotalCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents lvDecomisosCateg As System.Windows.Forms.ListView
    Friend WithEvents OrdenaColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents LinColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents CateCodColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents CateNomColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents EneColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents FebColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents MarColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents AbrColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents MayColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents JunColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents JulColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents AgoColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents SepColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents OctColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents NovColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents DicColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents TotalColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnVerDetalle As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
