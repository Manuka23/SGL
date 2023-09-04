<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDecomisosDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDecomisosDetalle))
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.lvDecomisosDIIOs = New System.Windows.Forms.ListView()
        Me.OrdenaColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LinColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiioColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CateCodColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CateNomColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaVtaColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CausaCodVtaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CausaNomVtaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblTotRegCausas = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.TotalCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiciembreCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.lvDecomisosCausas = New System.Windows.Forms.ListView()
        Me.OrdenaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LineaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CausaCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CausaNomCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblOrden2 = New System.Windows.Forms.Label()
        Me.lblCausaNom = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lvCausasRanking = New System.Windows.Forms.ListView()
        Me.OrdCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PosCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CauCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CauNomCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CantCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblAñoRanking = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboAño = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblTotRegDetDiios = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(6, 17)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(226, 23)
        Me.cboCentros.TabIndex = 117
        '
        'lvDecomisosDIIOs
        '
        Me.lvDecomisosDIIOs.AutoArrange = False
        Me.lvDecomisosDIIOs.BackColor = System.Drawing.SystemColors.Window
        Me.lvDecomisosDIIOs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OrdenaColumn, Me.LinColumn, Me.DiioColumn, Me.CateCodColumn, Me.CateNomColumn, Me.FechaVtaColumn, Me.CausaCodVtaCol, Me.CausaNomVtaCol})
        Me.lvDecomisosDIIOs.FullRowSelect = True
        Me.lvDecomisosDIIOs.GridLines = True
        Me.lvDecomisosDIIOs.HideSelection = False
        Me.lvDecomisosDIIOs.Location = New System.Drawing.Point(177, 378)
        Me.lvDecomisosDIIOs.MultiSelect = False
        Me.lvDecomisosDIIOs.Name = "lvDecomisosDIIOs"
        Me.lvDecomisosDIIOs.Size = New System.Drawing.Size(508, 136)
        Me.lvDecomisosDIIOs.TabIndex = 136
        Me.lvDecomisosDIIOs.UseCompatibleStateImageBehavior = False
        Me.lvDecomisosDIIOs.View = System.Windows.Forms.View.Details
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
        'DiioColumn
        '
        Me.DiioColumn.Text = "Diio"
        Me.DiioColumn.Width = 64
        '
        'CateCodColumn
        '
        Me.CateCodColumn.Text = "CateCod"
        Me.CateCodColumn.Width = 0
        '
        'CateNomColumn
        '
        Me.CateNomColumn.Text = "Categoria"
        Me.CateNomColumn.Width = 77
        '
        'FechaVtaColumn
        '
        Me.FechaVtaColumn.Text = "FechaVta"
        Me.FechaVtaColumn.Width = 71
        '
        'CausaCodVtaCol
        '
        Me.CausaCodVtaCol.Text = "CausaCodVta"
        Me.CausaCodVtaCol.Width = 0
        '
        'CausaNomVtaCol
        '
        Me.CausaNomVtaCol.Text = "Causa Vta."
        Me.CausaNomVtaCol.Width = 259
        '
        'lblTotRegCausas
        '
        Me.lblTotRegCausas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotRegCausas.Location = New System.Drawing.Point(135, 3)
        Me.lblTotRegCausas.Name = "lblTotRegCausas"
        Me.lblTotRegCausas.Size = New System.Drawing.Size(31, 21)
        Me.lblTotRegCausas.TabIndex = 1
        Me.lblTotRegCausas.Text = "0"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1114, 41)
        Me.Panel1.TabIndex = 133
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
        Me.Label3.Text = "Detalle Decomisos en Ventas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        'TotalCol
        '
        Me.TotalCol.Text = "Total"
        Me.TotalCol.Width = 78
        '
        'DiciembreCol
        '
        Me.DiciembreCol.Text = "Dic"
        Me.DiciembreCol.Width = 65
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(238, 50)
        Me.GroupBox1.TabIndex = 127
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
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
        'lvDecomisosCausas
        '
        Me.lvDecomisosCausas.AutoArrange = False
        Me.lvDecomisosCausas.BackColor = System.Drawing.SystemColors.Window
        Me.lvDecomisosCausas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OrdenaCol, Me.LineaCol, Me.CausaCodCol, Me.CausaNomCol, Me.EneroCol, Me.FebreroCol, Me.MarzoCol, Me.AbrilCol, Me.MayoCol, Me.JunioCol, Me.JulioCol, Me.AgostoCol, Me.SeptiembreCol, Me.OctubreCol, Me.NoviembreCol, Me.DiciembreCol, Me.TotalCol})
        Me.lvDecomisosCausas.FullRowSelect = True
        Me.lvDecomisosCausas.GridLines = True
        Me.lvDecomisosCausas.HideSelection = False
        Me.lvDecomisosCausas.Location = New System.Drawing.Point(11, 127)
        Me.lvDecomisosCausas.MultiSelect = False
        Me.lvDecomisosCausas.Name = "lvDecomisosCausas"
        Me.lvDecomisosCausas.Size = New System.Drawing.Size(1100, 181)
        Me.lvDecomisosCausas.TabIndex = 124
        Me.lvDecomisosCausas.UseCompatibleStateImageBehavior = False
        Me.lvDecomisosCausas.View = System.Windows.Forms.View.Details
        '
        'OrdenaCol
        '
        Me.OrdenaCol.Text = "Ordena"
        Me.OrdenaCol.Width = 0
        '
        'LineaCol
        '
        Me.LineaCol.Text = "Lin."
        Me.LineaCol.Width = 31
        '
        'CausaCodCol
        '
        Me.CausaCodCol.Text = "CausaCod"
        Me.CausaCodCol.Width = 0
        '
        'CausaNomCol
        '
        Me.CausaNomCol.Text = "Causa"
        Me.CausaNomCol.Width = 206
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
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(256, 255)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(655, 53)
        Me.pnlProcesa.TabIndex = 125
        Me.pnlProcesa.Visible = False
        '
        'pbProcesa
        '
        Me.pbProcesa.Location = New System.Drawing.Point(12, 25)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(625, 18)
        Me.pbProcesa.TabIndex = 68
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(8, 1)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(495, 19)
        Me.Label61.TabIndex = 1
        Me.Label61.Text = "DETALLE POR CAUSAS"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(11, 103)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1100, 23)
        Me.Panel2.TabIndex = 130
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Info
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblTotRegCausas)
        Me.pnlEstReprod.Controls.Add(Me.Label86)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(11, 308)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(155, 24)
        Me.pnlEstReprod.TabIndex = 123
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.Enabled = False
        Me.btnLimpiarFiltro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltro.Image = CType(resources.GetObject("btnLimpiarFiltro.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(831, 67)
        Me.btnLimpiarFiltro.Name = "btnLimpiarFiltro"
        Me.btnLimpiarFiltro.Size = New System.Drawing.Size(50, 30)
        Me.btnLimpiarFiltro.TabIndex = 131
        Me.btnLimpiarFiltro.UseVisualStyleBackColor = True
        '
        'btnImportar
        '
        Me.btnImportar.Enabled = False
        Me.btnImportar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportar.Location = New System.Drawing.Point(12, 393)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(87, 30)
        Me.btnImportar.TabIndex = 129
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(11, 357)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 128
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(991, 517)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(105, 30)
        Me.btnSalir.TabIndex = 121
        Me.btnSalir.Text = "Cerrar (Esc)"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Enabled = False
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(887, 67)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(98, 30)
        Me.btnLimpiarFiltros.TabIndex = 126
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(11, 465)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 30)
        Me.Button6.TabIndex = 120
        Me.Button6.Text = "Imprime"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(991, 67)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(102, 30)
        Me.btnBuscar.TabIndex = 122
        Me.btnBuscar.Text = "Consultar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Enabled = False
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(11, 429)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 119
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblOrden2)
        Me.Panel3.Controls.Add(Me.lblCausaNom)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Location = New System.Drawing.Point(177, 357)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(508, 23)
        Me.Panel3.TabIndex = 131
        '
        'lblOrden2
        '
        Me.lblOrden2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden2.ForeColor = System.Drawing.Color.White
        Me.lblOrden2.Location = New System.Drawing.Point(369, 0)
        Me.lblOrden2.Name = "lblOrden2"
        Me.lblOrden2.Size = New System.Drawing.Size(134, 19)
        Me.lblOrden2.TabIndex = 142
        Me.lblOrden2.Text = "Centro"
        Me.lblOrden2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCausaNom
        '
        Me.lblCausaNom.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCausaNom.ForeColor = System.Drawing.Color.White
        Me.lblCausaNom.Location = New System.Drawing.Point(171, -1)
        Me.lblCausaNom.Name = "lblCausaNom"
        Me.lblCausaNom.Size = New System.Drawing.Size(178, 19)
        Me.lblCausaNom.TabIndex = 0
        Me.lblCausaNom.Text = "Centro"
        Me.lblCausaNom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(8, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 19)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "CAUSA SELECCIONADA:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvCausasRanking
        '
        Me.lvCausasRanking.AutoArrange = False
        Me.lvCausasRanking.BackColor = System.Drawing.SystemColors.Window
        Me.lvCausasRanking.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OrdCol, Me.PosCol, Me.CauCodCol, Me.CauNomCol, Me.CantCol})
        Me.lvCausasRanking.FullRowSelect = True
        Me.lvCausasRanking.GridLines = True
        Me.lvCausasRanking.HideSelection = False
        Me.lvCausasRanking.Location = New System.Drawing.Point(701, 382)
        Me.lvCausasRanking.MultiSelect = False
        Me.lvCausasRanking.Name = "lvCausasRanking"
        Me.lvCausasRanking.Size = New System.Drawing.Size(290, 131)
        Me.lvCausasRanking.TabIndex = 139
        Me.lvCausasRanking.UseCompatibleStateImageBehavior = False
        Me.lvCausasRanking.View = System.Windows.Forms.View.Details
        '
        'OrdCol
        '
        Me.OrdCol.Text = "Ordena"
        Me.OrdCol.Width = 0
        '
        'PosCol
        '
        Me.PosCol.Text = "Posición"
        Me.PosCol.Width = 59
        '
        'CauCodCol
        '
        Me.CauCodCol.Text = "CausaCod"
        Me.CauCodCol.Width = 0
        '
        'CauNomCol
        '
        Me.CauNomCol.Text = "Causa"
        Me.CauNomCol.Width = 175
        '
        'CantCol
        '
        Me.CantCol.Text = "Cant."
        Me.CantCol.Width = 52
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lblAñoRanking)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Location = New System.Drawing.Point(701, 357)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(290, 23)
        Me.Panel4.TabIndex = 140
        '
        'lblAñoRanking
        '
        Me.lblAñoRanking.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAñoRanking.ForeColor = System.Drawing.Color.White
        Me.lblAñoRanking.Location = New System.Drawing.Point(127, 1)
        Me.lblAñoRanking.Name = "lblAñoRanking"
        Me.lblAñoRanking.Size = New System.Drawing.Size(70, 18)
        Me.lblAñoRanking.TabIndex = 2
        Me.lblAñoRanking.Text = "AÑO"
        Me.lblAñoRanking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(8, 1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 17)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "RANKING CAUSAS DECOMISOS"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboAño)
        Me.GroupBox2.Location = New System.Drawing.Point(301, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(138, 50)
        Me.GroupBox2.TabIndex = 141
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
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Info
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.lblTotRegDetDiios)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel5.Location = New System.Drawing.Point(177, 513)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(248, 24)
        Me.Panel5.TabIndex = 142
        '
        'lblTotRegDetDiios
        '
        Me.lblTotRegDetDiios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotRegDetDiios.Location = New System.Drawing.Point(135, 3)
        Me.lblTotRegDetDiios.Name = "lblTotRegDetDiios"
        Me.lblTotRegDetDiios.Size = New System.Drawing.Size(17, 21)
        Me.lblTotRegDetDiios.TabIndex = 1
        Me.lblTotRegDetDiios.Text = "0"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Total Registros:"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RichTextBox1.Cursor = System.Windows.Forms.Cursors.No
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.Color.DarkRed
        Me.RichTextBox1.Location = New System.Drawing.Point(172, 307)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(939, 31)
        Me.RichTextBox1.TabIndex = 143
        Me.RichTextBox1.Text = "Seleccione una Causa en la Parte Superior, para ver el detalle de DIIOs que fuero" & _
            "n Decomisados."
        '
        'FrmDecomisosDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1118, 549)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.lvCausasRanking)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.lvDecomisosDIIOs)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lvDecomisosCausas)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmDecomisosDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Decomisos"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents lvDecomisosDIIOs As System.Windows.Forms.ListView
    Friend WithEvents OrdenaColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents LinColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents DiioColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents CateCodColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents CateNomColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents FechaVtaColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents CausaCodVtaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CausaNomVtaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblTotRegCausas As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents TotalCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DiciembreCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnLimpiarFiltro As System.Windows.Forms.Button
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents lvDecomisosCausas As System.Windows.Forms.ListView
    Friend WithEvents OrdenaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents LineaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CausaCodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CausaNomCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents EneroCol As System.Windows.Forms.ColumnHeader
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
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents btnLimpiarFiltros As System.Windows.Forms.Button
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblCausaNom As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lvCausasRanking As System.Windows.Forms.ListView
    Friend WithEvents OrdCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents PosCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CauCodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CauNomCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CantCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblAñoRanking As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboAño As System.Windows.Forms.ComboBox
    Friend WithEvents lblOrden2 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblTotRegDetDiios As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
End Class
