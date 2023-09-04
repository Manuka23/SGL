<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMuestraLecheResumen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMuestraLecheResumen))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "", "", "", "", "", ""}, -1)
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.lvRESUMEN1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.comu = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtLote = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboProveedores = New System.Windows.Forms.ComboBox()
        Me.btnEnvio = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnExcelCooprinsem = New System.Windows.Forms.Button()
        Me.pnlEstReprod.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(766, 593)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(99, 40)
        Me.btnEliminar.TabIndex = 247
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(787, 72)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(98, 40)
        Me.btnLimpiarFiltros.TabIndex = 244
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'lvRESUMEN1
        '
        Me.lvRESUMEN1.AutoArrange = False
        Me.lvRESUMEN1.BackColor = System.Drawing.SystemColors.Window
        Me.lvRESUMEN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvRESUMEN1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader34, Me.ColumnHeader1, Me.ColumnHeader2, Me.comu, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader4, Me.ColumnHeader7, Me.ColumnHeader6, Me.ColumnHeader11})
        Me.lvRESUMEN1.FullRowSelect = True
        Me.lvRESUMEN1.GridLines = True
        Me.lvRESUMEN1.HideSelection = False
        Me.lvRESUMEN1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvRESUMEN1.Location = New System.Drawing.Point(3, 126)
        Me.lvRESUMEN1.Name = "lvRESUMEN1"
        Me.lvRESUMEN1.Size = New System.Drawing.Size(973, 422)
        Me.lvRESUMEN1.TabIndex = 243
        Me.lvRESUMEN1.UseCompatibleStateImageBehavior = False
        Me.lvRESUMEN1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "N°"
        Me.ColumnHeader34.Width = 40
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Proveedor"
        Me.ColumnHeader1.Width = 149
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Lote Envio"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 120
        '
        'comu
        '
        Me.comu.Text = "Nro Muestras"
        Me.comu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.comu.Width = 92
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Estado"
        Me.ColumnHeader3.Width = 91
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Horario"
        Me.ColumnHeader5.Width = 66
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Usuario"
        Me.ColumnHeader4.Width = 94
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fecha Muestra"
        Me.ColumnHeader7.Width = 97
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Fecha Envio"
        Me.ColumnHeader6.Width = 113
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Fecha Result"
        Me.ColumnHeader11.Width = 106
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.Label10)
        Me.pnlEstReprod.Controls.Add(Me.Label9)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(3, 554)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(973, 31)
        Me.pnlEstReprod.TabIndex = 241
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(118, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(154, 27)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "0"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(3, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(107, 27)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Nro. Registros :"
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(667, 593)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(93, 40)
        Me.btnExcel.TabIndex = 240
        Me.btnExcel.Text = "A Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(889, 72)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 40)
        Me.btnBuscar.TabIndex = 239
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox6.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Label1)
        Me.GroupBox6.Location = New System.Drawing.Point(470, 58)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(277, 62)
        Me.GroupBox6.TabIndex = 238
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Rango de Fecha"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(49, 24)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(87, 26)
        Me.dtpFechaDesde.TabIndex = 56
        Me.dtpFechaDesde.Value = New Date(2017, 10, 6, 15, 45, 48, 0)
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(184, 24)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(87, 26)
        Me.dtpFechaHasta.TabIndex = 55
        Me.dtpFechaHasta.Value = New Date(2017, 10, 6, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(142, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 18)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(889, 593)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 40)
        Me.btnSalir.TabIndex = 237
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
        Me.btnAgregar.Location = New System.Drawing.Point(3, 593)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(120, 40)
        Me.btnAgregar.TabIndex = 236
        Me.btnAgregar.Text = "Leer Etiquetas"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-9, -4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1097, 55)
        Me.Panel1.TabIndex = 235
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(57, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(822, 39)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Muestras de Leche"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboEstado)
        Me.GroupBox1.Location = New System.Drawing.Point(189, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(134, 62)
        Me.GroupBox1.TabIndex = 249
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado"
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(6, 24)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(122, 26)
        Me.cboEstado.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLote)
        Me.GroupBox2.Location = New System.Drawing.Point(329, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(135, 62)
        Me.GroupBox2.TabIndex = 250
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Lote Envio"
        '
        'txtLote
        '
        Me.txtLote.Location = New System.Drawing.Point(13, 24)
        Me.txtLote.MaxLength = 20
        Me.txtLote.Name = "txtLote"
        Me.txtLote.Size = New System.Drawing.Size(103, 26)
        Me.txtLote.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboProveedores)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 57)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(180, 63)
        Me.GroupBox3.TabIndex = 265
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Proveedores"
        '
        'cboProveedores
        '
        Me.cboProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedores.FormattingEnabled = True
        Me.cboProveedores.Location = New System.Drawing.Point(6, 25)
        Me.cboProveedores.Name = "cboProveedores"
        Me.cboProveedores.Size = New System.Drawing.Size(168, 26)
        Me.cboProveedores.TabIndex = 1
        '
        'btnEnvio
        '
        Me.btnEnvio.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnvio.Image = CType(resources.GetObject("btnEnvio.Image"), System.Drawing.Image)
        Me.btnEnvio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEnvio.Location = New System.Drawing.Point(129, 593)
        Me.btnEnvio.Name = "btnEnvio"
        Me.btnEnvio.Size = New System.Drawing.Size(120, 40)
        Me.btnEnvio.TabIndex = 266
        Me.btnEnvio.Text = "Generar Envio"
        Me.btnEnvio.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(255, 593)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 40)
        Me.Button2.TabIndex = 267
        Me.Button2.Text = "   Finalizar Envio"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(381, 593)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 40)
        Me.Button1.TabIndex = 268
        Me.Button1.Text = "Ingreso Manual"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnExcelCooprinsem
        '
        Me.btnExcelCooprinsem.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcelCooprinsem.Image = CType(resources.GetObject("btnExcelCooprinsem.Image"), System.Drawing.Image)
        Me.btnExcelCooprinsem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelCooprinsem.Location = New System.Drawing.Point(524, 593)
        Me.btnExcelCooprinsem.Name = "btnExcelCooprinsem"
        Me.btnExcelCooprinsem.Size = New System.Drawing.Size(137, 40)
        Me.btnExcelCooprinsem.TabIndex = 269
        Me.btnExcelCooprinsem.Text = "     Excel Cooprinsem"
        Me.btnExcelCooprinsem.UseVisualStyleBackColor = True
        '
        'frmMuestraLecheResumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 638)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExcelCooprinsem)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnEnvio)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.lvRESUMEN1)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMuestraLecheResumen"
        Me.ShowInTaskbar = False
        Me.Text = "Muestra Leche"
        Me.pnlEstReprod.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnLimpiarFiltros As Button
    Friend WithEvents lvRESUMEN1 As ListView
    Friend WithEvents ColumnHeader34 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents comu As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents pnlEstReprod As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtLote As TextBox
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboProveedores As ComboBox
    Friend WithEvents btnEnvio As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents btnExcelCooprinsem As Button
End Class
