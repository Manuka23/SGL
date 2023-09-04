<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConteoAnimales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConteoAnimales))
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "", "", "", "", "", ""}, -1)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.lvRESUMEN1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtDIIO = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lvDetalle = New System.Windows.Forms.ListView()
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LvHistorial = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-5, -4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1106, 40)
        Me.Panel1.TabIndex = 230
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(9, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(894, 30)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Administración de Conteo Animales"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(716, 56)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(98, 37)
        Me.btnLimpiarFiltros.TabIndex = 228
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'lvRESUMEN1
        '
        Me.lvRESUMEN1.AutoArrange = False
        Me.lvRESUMEN1.BackColor = System.Drawing.SystemColors.Window
        Me.lvRESUMEN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvRESUMEN1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader34, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader9, Me.ColumnHeader5, Me.ColumnHeader7, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader3})
        Me.lvRESUMEN1.Enabled = False
        Me.lvRESUMEN1.FullRowSelect = True
        Me.lvRESUMEN1.GridLines = True
        Me.lvRESUMEN1.HideSelection = False
        Me.lvRESUMEN1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem3})
        Me.lvRESUMEN1.Location = New System.Drawing.Point(4, 106)
        Me.lvRESUMEN1.MultiSelect = False
        Me.lvRESUMEN1.Name = "lvRESUMEN1"
        Me.lvRESUMEN1.Size = New System.Drawing.Size(902, 192)
        Me.lvRESUMEN1.TabIndex = 227
        Me.lvRESUMEN1.UseCompatibleStateImageBehavior = False
        Me.lvRESUMEN1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "N°"
        Me.ColumnHeader34.Width = 61
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Centro"
        Me.ColumnHeader1.Width = 122
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fecha"
        Me.ColumnHeader2.Width = 122
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Bastoneadas"
        Me.ColumnHeader9.Width = 91
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Faltantes"
        Me.ColumnHeader5.Width = 90
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Stock"
        Me.ColumnHeader7.Width = 119
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Observaciones"
        Me.ColumnHeader6.Width = 175
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "CodCentro"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Usuario"
        Me.ColumnHeader3.Width = 117
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboCentros)
        Me.GroupBox5.Location = New System.Drawing.Point(4, 42)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(192, 58)
        Me.GroupBox5.TabIndex = 226
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(6, 22)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(180, 22)
        Me.cboCentros.TabIndex = 0
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(276, 585)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(79, 37)
        Me.btnExcel.TabIndex = 224
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(818, 56)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 37)
        Me.btnBuscar.TabIndex = 223
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox6.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Location = New System.Drawing.Point(202, 42)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(277, 58)
        Me.GroupBox6.TabIndex = 222
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Rango de Fecha"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(52, 22)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(87, 22)
        Me.dtpFechaDesde.TabIndex = 56
        Me.dtpFechaDesde.Value = New Date(2017, 10, 6, 15, 45, 48, 0)
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(184, 22)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(87, 22)
        Me.dtpFechaHasta.TabIndex = 55
        Me.dtpFechaHasta.Value = New Date(2017, 10, 6, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(139, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(819, 585)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 37)
        Me.btnSalir.TabIndex = 220
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
        Me.btnAgregar.Location = New System.Drawing.Point(4, 585)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(130, 37)
        Me.btnAgregar.TabIndex = 219
        Me.btnAgregar.Text = "Agregar Registro"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDIIO)
        Me.GroupBox2.Location = New System.Drawing.Point(485, 42)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(126, 59)
        Me.GroupBox2.TabIndex = 231
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DIIO en Conteo"
        '
        'txtDIIO
        '
        Me.txtDIIO.Location = New System.Drawing.Point(6, 22)
        Me.txtDIIO.MaxLength = 20
        Me.txtDIIO.Name = "txtDIIO"
        Me.txtDIIO.Size = New System.Drawing.Size(114, 22)
        Me.txtDIIO.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lvDetalle)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(4, 304)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(448, 240)
        Me.GroupBox4.TabIndex = 234
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Diferencias"
        '
        'lvDetalle
        '
        Me.lvDetalle.AutoArrange = False
        Me.lvDetalle.BackColor = System.Drawing.SystemColors.Window
        Me.lvDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader16})
        Me.lvDetalle.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDetalle.FullRowSelect = True
        Me.lvDetalle.GridLines = True
        Me.lvDetalle.HideSelection = False
        Me.lvDetalle.Location = New System.Drawing.Point(6, 25)
        Me.lvDetalle.MultiSelect = False
        Me.lvDetalle.Name = "lvDetalle"
        Me.lvDetalle.Size = New System.Drawing.Size(432, 207)
        Me.lvDetalle.TabIndex = 228
        Me.lvDetalle.UseCompatibleStateImageBehavior = False
        Me.lvDetalle.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Nro"
        Me.ColumnHeader14.Width = 36
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Diio"
        Me.ColumnHeader15.Width = 90
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Est. Productivo"
        Me.ColumnHeader12.Width = 100
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Est. Reproductivo"
        Me.ColumnHeader13.Width = 92
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Estado"
        Me.ColumnHeader16.Width = 107
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LvHistorial)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(458, 304)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(448, 240)
        Me.GroupBox1.TabIndex = 235
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Diferencias en Conteos Ult. Mes"
        '
        'LvHistorial
        '
        Me.LvHistorial.AutoArrange = False
        Me.LvHistorial.BackColor = System.Drawing.SystemColors.Window
        Me.LvHistorial.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19})
        Me.LvHistorial.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvHistorial.FullRowSelect = True
        Me.LvHistorial.GridLines = True
        Me.LvHistorial.HideSelection = False
        Me.LvHistorial.Location = New System.Drawing.Point(6, 25)
        Me.LvHistorial.MultiSelect = False
        Me.LvHistorial.Name = "LvHistorial"
        Me.LvHistorial.Size = New System.Drawing.Size(432, 207)
        Me.LvHistorial.TabIndex = 228
        Me.LvHistorial.UseCompatibleStateImageBehavior = False
        Me.LvHistorial.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Nro"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Diio"
        Me.ColumnHeader10.Width = 100
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Cont1"
        Me.ColumnHeader11.Width = 70
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "cont2"
        Me.ColumnHeader17.Width = 70
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Cont3"
        Me.ColumnHeader18.Width = 70
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Cont4"
        Me.ColumnHeader19.Width = 70
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.Label4)
        Me.pnlEstReprod.Controls.Add(Me.Label5)
        Me.pnlEstReprod.Controls.Add(Me.Label10)
        Me.pnlEstReprod.Controls.Add(Me.Label9)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(4, 550)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(902, 29)
        Me.pnlEstReprod.TabIndex = 236
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(331, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 25)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "0"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(209, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 25)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Nro. Diferencias"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(116, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 25)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "0"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 25)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Nro. Registros"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(140, 585)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 37)
        Me.Button1.TabIndex = 237
        Me.Button1.Text = "Dias Bastoneo"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(361, 585)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(130, 37)
        Me.Button2.TabIndex = 239
        Me.Button2.Text = "Subir Alarmas"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmConteoAnimales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 628)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.lvRESUMEN1)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAgregar)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConteoAnimales"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conteo Reportes"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnLimpiarFiltros As Button
    Friend WithEvents lvRESUMEN1 As ListView
    Friend WithEvents ColumnHeader34 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
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
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtDIIO As TextBox
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lvDetalle As ListView
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LvHistorial As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents pnlEstReprod As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
