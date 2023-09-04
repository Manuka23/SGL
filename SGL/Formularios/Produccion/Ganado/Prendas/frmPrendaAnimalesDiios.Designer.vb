<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrendaAnimalesDiios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrendaAnimalesDiios))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chklvCentros = New System.Windows.Forms.CheckedListBox()
        Me.pnlCentros = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chklvCategorias = New System.Windows.Forms.CheckedListBox()
        Me.pnlCategoria = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboBancos = New System.Windows.Forms.ComboBox()
        Me.SelectT = New System.Windows.Forms.CheckBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.total = New System.Windows.Forms.Label()
        Me.dgvCentros = New System.Windows.Forms.DataGridView()
        Me.Seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Nro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Centros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvCentros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chklvCentros)
        Me.GroupBox5.Controls.Add(Me.pnlCentros)
        Me.GroupBox5.Location = New System.Drawing.Point(258, 13)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(181, 104)
        Me.GroupBox5.TabIndex = 100
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Centros"
        '
        'chklvCentros
        '
        Me.chklvCentros.CheckOnClick = True
        Me.chklvCentros.FormattingEnabled = True
        Me.chklvCentros.Location = New System.Drawing.Point(6, 16)
        Me.chklvCentros.Name = "chklvCentros"
        Me.chklvCentros.Size = New System.Drawing.Size(166, 72)
        Me.chklvCentros.TabIndex = 0
        '
        'pnlCentros
        '
        Me.pnlCentros.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlCentros.Location = New System.Drawing.Point(6, 79)
        Me.pnlCentros.Name = "pnlCentros"
        Me.pnlCentros.Size = New System.Drawing.Size(166, 19)
        Me.pnlCentros.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chklvCategorias)
        Me.GroupBox1.Controls.Add(Me.pnlCategoria)
        Me.GroupBox1.Location = New System.Drawing.Point(445, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(149, 104)
        Me.GroupBox1.TabIndex = 102
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Categoria"
        '
        'chklvCategorias
        '
        Me.chklvCategorias.CheckOnClick = True
        Me.chklvCategorias.FormattingEnabled = True
        Me.chklvCategorias.Items.AddRange(New Object() {"(TODOS)", "TERNERAS", "TERNEROS", "TORETES", "TOROS", "VACAS", "VAQUILLAS"})
        Me.chklvCategorias.Location = New System.Drawing.Point(6, 16)
        Me.chklvCategorias.Name = "chklvCategorias"
        Me.chklvCategorias.Size = New System.Drawing.Size(136, 72)
        Me.chklvCategorias.TabIndex = 0
        '
        'pnlCategoria
        '
        Me.pnlCategoria.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlCategoria.Location = New System.Drawing.Point(6, 79)
        Me.pnlCategoria.Name = "pnlCategoria"
        Me.pnlCategoria.Size = New System.Drawing.Size(136, 19)
        Me.pnlCategoria.TabIndex = 4
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(614, 473)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 32)
        Me.btnSalir.TabIndex = 106
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(10, 472)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 32)
        Me.btnGrabar.TabIndex = 105
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboBancos)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(10, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(242, 61)
        Me.GroupBox2.TabIndex = 108
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Bancos"
        '
        'cboBancos
        '
        Me.cboBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBancos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBancos.FormattingEnabled = True
        Me.cboBancos.Location = New System.Drawing.Point(11, 22)
        Me.cboBancos.Name = "cboBancos"
        Me.cboBancos.Size = New System.Drawing.Size(220, 26)
        Me.cboBancos.TabIndex = 0
        '
        'SelectT
        '
        Me.SelectT.AutoSize = True
        Me.SelectT.Location = New System.Drawing.Point(10, 79)
        Me.SelectT.Name = "SelectT"
        Me.SelectT.Size = New System.Drawing.Size(124, 18)
        Me.SelectT.TabIndex = 110
        Me.SelectT.Text = "Seleccionar Todos"
        Me.SelectT.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(604, 29)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(97, 32)
        Me.btnBuscar.TabIndex = 111
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 447)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "TOTAL ANIMALES"
        '
        'total
        '
        Me.total.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.total.Location = New System.Drawing.Point(116, 447)
        Me.total.Name = "total"
        Me.total.Size = New System.Drawing.Size(85, 23)
        Me.total.TabIndex = 116
        Me.total.Text = "0"
        '
        'dgvCentros
        '
        Me.dgvCentros.AllowUserToAddRows = False
        Me.dgvCentros.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvCentros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCentros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccion, Me.Nro, Me.Centros, Me.Column1, Me.Column2, Me.Column3})
        Me.dgvCentros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCentros.Enabled = False
        Me.dgvCentros.Location = New System.Drawing.Point(3, 18)
        Me.dgvCentros.Name = "dgvCentros"
        Me.dgvCentros.RowHeadersVisible = False
        Me.dgvCentros.RowTemplate.Height = 20
        Me.dgvCentros.ShowEditingIcon = False
        Me.dgvCentros.Size = New System.Drawing.Size(685, 317)
        Me.dgvCentros.TabIndex = 109
        '
        'Seleccion
        '
        Me.Seleccion.HeaderText = "Selec"
        Me.Seleccion.Name = "Seleccion"
        Me.Seleccion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Seleccion.Width = 40
        '
        'Nro
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Nro.DefaultCellStyle = DataGridViewCellStyle1
        Me.Nro.HeaderText = "Nro"
        Me.Nro.Name = "Nro"
        Me.Nro.ReadOnly = True
        Me.Nro.Width = 60
        '
        'Centros
        '
        Me.Centros.HeaderText = "Codigo Centro"
        Me.Centros.Name = "Centros"
        Me.Centros.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "Nombre Centro"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'Column2
        '
        Me.Column2.HeaderText = "Diios"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 120
        '
        'Column3
        '
        Me.Column3.HeaderText = "Categoria"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(10, 100)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(154, 18)
        Me.CheckBox1.TabIndex = 117
        Me.CheckBox1.Text = "Ver Diios No Prendados"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(604, 67)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(97, 30)
        Me.btnLimpiarFiltros.TabIndex = 118
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvCentros)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 124)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(691, 338)
        Me.GroupBox3.TabIndex = 227
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Seleecion de Diio"
        '
        'frmPrendaAnimalesDiios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 517)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.total)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.SelectT)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrendaAnimalesDiios"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingreso por Diio"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvCentros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents chklvCentros As CheckedListBox
    Friend WithEvents pnlCentros As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chklvCategorias As CheckedListBox
    Friend WithEvents pnlCategoria As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGrabar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboBancos As ComboBox
    Friend WithEvents SelectT As CheckBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents total As Label
    Friend WithEvents dgvCentros As DataGridView
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents btnLimpiarFiltros As Button
    Friend WithEvents Seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents Nro As DataGridViewTextBoxColumn
    Friend WithEvents Centros As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As GroupBox
End Class
