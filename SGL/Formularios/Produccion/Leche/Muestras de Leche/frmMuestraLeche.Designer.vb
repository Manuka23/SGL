<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMuestraLeche
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMuestraLeche))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCentro = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblEstanque = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblNum = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDIIO = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Fecha = New System.Windows.Forms.DateTimePicker()
        Me.grpRetiro = New System.Windows.Forms.GroupBox()
        Me.dgvRetiroLeche = New System.Windows.Forms.DataGridView()
        Me.CodLector = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroCod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstanqueCod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.est = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fech = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedores = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Externo = New System.Windows.Forms.RadioButton()
        Me.Interno = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboProveedores = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PM = New System.Windows.Forms.RadioButton()
        Me.AM = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rbSala = New System.Windows.Forms.RadioButton()
        Me.rbCCalidad = New System.Windows.Forms.RadioButton()
        Me.rbtrojo = New System.Windows.Forms.RadioButton()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.rbtazul = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.grpRetiro.SuspendLayout()
        CType(Me.dgvRetiroLeche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCentro)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lblEstanque)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblNum)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDIIO)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 105)
        Me.GroupBox1.TabIndex = 194
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion lectura"
        '
        'lblCentro
        '
        Me.lblCentro.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCentro.Location = New System.Drawing.Point(77, 53)
        Me.lblCentro.Name = "lblCentro"
        Me.lblCentro.Size = New System.Drawing.Size(168, 24)
        Me.lblCentro.TabIndex = 59
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(20, 53)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(51, 24)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "Centro:"
        '
        'lblEstanque
        '
        Me.lblEstanque.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstanque.Location = New System.Drawing.Point(77, 75)
        Me.lblEstanque.Name = "lblEstanque"
        Me.lblEstanque.Size = New System.Drawing.Size(168, 24)
        Me.lblEstanque.TabIndex = 56
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 24)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Estanque:"
        '
        'lblNum
        '
        Me.lblNum.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblNum.Location = New System.Drawing.Point(361, 51)
        Me.lblNum.Name = "lblNum"
        Me.lblNum.Size = New System.Drawing.Size(46, 24)
        Me.lblNum.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(266, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 24)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Num. Estanque:"
        '
        'txtDIIO
        '
        Me.txtDIIO.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIIO.Location = New System.Drawing.Point(6, 22)
        Me.txtDIIO.MaxLength = 20
        Me.txtDIIO.Name = "txtDIIO"
        Me.txtDIIO.Size = New System.Drawing.Size(127, 28)
        Me.txtDIIO.TabIndex = 40
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Fecha)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(526, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(156, 57)
        Me.GroupBox5.TabIndex = 200
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fecha"
        '
        'Fecha
        '
        Me.Fecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha.Location = New System.Drawing.Point(22, 20)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(111, 30)
        Me.Fecha.TabIndex = 1
        '
        'grpRetiro
        '
        Me.grpRetiro.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grpRetiro.Controls.Add(Me.dgvRetiroLeche)
        Me.grpRetiro.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRetiro.Location = New System.Drawing.Point(6, 171)
        Me.grpRetiro.Name = "grpRetiro"
        Me.grpRetiro.Size = New System.Drawing.Size(780, 401)
        Me.grpRetiro.TabIndex = 202
        Me.grpRetiro.TabStop = False
        Me.grpRetiro.Text = "Muestras"
        '
        'dgvRetiroLeche
        '
        Me.dgvRetiroLeche.AllowDrop = True
        Me.dgvRetiroLeche.AllowUserToAddRows = False
        Me.dgvRetiroLeche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRetiroLeche.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodLector, Me.CentroCod, Me.EstanqueCod, Me.Column4, Me.cen, Me.est, Me.fech, Me.prov, Me.Proveedores, Me.Hor})
        Me.dgvRetiroLeche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRetiroLeche.GridColor = System.Drawing.SystemColors.Control
        Me.dgvRetiroLeche.Location = New System.Drawing.Point(3, 23)
        Me.dgvRetiroLeche.Name = "dgvRetiroLeche"
        Me.dgvRetiroLeche.RowHeadersWidth = 51
        Me.dgvRetiroLeche.Size = New System.Drawing.Size(774, 375)
        Me.dgvRetiroLeche.TabIndex = 12
        '
        'CodLector
        '
        Me.CodLector.HeaderText = "CodLector"
        Me.CodLector.MinimumWidth = 6
        Me.CodLector.Name = "CodLector"
        Me.CodLector.Visible = False
        Me.CodLector.Width = 125
        '
        'CentroCod
        '
        Me.CentroCod.FillWeight = 22.0!
        Me.CentroCod.HeaderText = "Cen"
        Me.CentroCod.MinimumWidth = 6
        Me.CentroCod.Name = "CentroCod"
        Me.CentroCod.ReadOnly = True
        Me.CentroCod.Visible = False
        Me.CentroCod.Width = 22
        '
        'EstanqueCod
        '
        Me.EstanqueCod.HeaderText = "Est"
        Me.EstanqueCod.MinimumWidth = 6
        Me.EstanqueCod.Name = "EstanqueCod"
        Me.EstanqueCod.ReadOnly = True
        Me.EstanqueCod.Visible = False
        Me.EstanqueCod.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "CodProveedor"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.Visible = False
        Me.Column4.Width = 125
        '
        'cen
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.cen.DefaultCellStyle = DataGridViewCellStyle1
        Me.cen.HeaderText = "Centro"
        Me.cen.MaxInputLength = 50
        Me.cen.MinimumWidth = 6
        Me.cen.Name = "cen"
        Me.cen.ReadOnly = True
        Me.cen.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cen.Width = 133
        '
        'est
        '
        DataGridViewCellStyle2.NullValue = Nothing
        Me.est.DefaultCellStyle = DataGridViewCellStyle2
        Me.est.HeaderText = "Estanque"
        Me.est.MaxInputLength = 100
        Me.est.MinimumWidth = 6
        Me.est.Name = "est"
        Me.est.ReadOnly = True
        Me.est.Width = 120
        '
        'fech
        '
        Me.fech.HeaderText = "Fecha"
        Me.fech.MaxInputLength = 70
        Me.fech.MinimumWidth = 6
        Me.fech.Name = "fech"
        Me.fech.ReadOnly = True
        Me.fech.Width = 90
        '
        'prov
        '
        Me.prov.HeaderText = "Proveedor"
        Me.prov.MinimumWidth = 6
        Me.prov.Name = "prov"
        Me.prov.ReadOnly = True
        Me.prov.Width = 125
        '
        'Proveedores
        '
        Me.Proveedores.HeaderText = "Proveedores"
        Me.Proveedores.MinimumWidth = 6
        Me.Proveedores.Name = "Proveedores"
        Me.Proveedores.ReadOnly = True
        Me.Proveedores.Width = 222
        '
        'Hor
        '
        Me.Hor.HeaderText = "Horario"
        Me.Hor.MinimumWidth = 6
        Me.Hor.Name = "Hor"
        Me.Hor.ReadOnly = True
        Me.Hor.Width = 65
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Externo)
        Me.GroupBox3.Controls.Add(Me.Interno)
        Me.GroupBox3.Location = New System.Drawing.Point(431, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(89, 105)
        Me.GroupBox3.TabIndex = 261
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Proveedor"
        '
        'Externo
        '
        Me.Externo.AutoSize = True
        Me.Externo.Location = New System.Drawing.Point(6, 74)
        Me.Externo.Name = "Externo"
        Me.Externo.Size = New System.Drawing.Size(77, 22)
        Me.Externo.TabIndex = 1
        Me.Externo.TabStop = True
        Me.Externo.Text = "Externo"
        Me.Externo.UseVisualStyleBackColor = True
        '
        'Interno
        '
        Me.Interno.AutoSize = True
        Me.Interno.Location = New System.Drawing.Point(6, 29)
        Me.Interno.Name = "Interno"
        Me.Interno.Size = New System.Drawing.Size(75, 22)
        Me.Interno.TabIndex = 0
        Me.Interno.TabStop = True
        Me.Interno.Text = "Interno"
        Me.Interno.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboProveedores)
        Me.GroupBox4.Location = New System.Drawing.Point(526, 60)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(260, 48)
        Me.GroupBox4.TabIndex = 264
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Proveedores"
        '
        'cboProveedores
        '
        Me.cboProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedores.Enabled = False
        Me.cboProveedores.FormattingEnabled = True
        Me.cboProveedores.Location = New System.Drawing.Point(6, 19)
        Me.cboProveedores.Name = "cboProveedores"
        Me.cboProveedores.Size = New System.Drawing.Size(248, 26)
        Me.cboProveedores.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PM)
        Me.GroupBox2.Controls.Add(Me.AM)
        Me.GroupBox2.Location = New System.Drawing.Point(688, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(98, 57)
        Me.GroupBox2.TabIndex = 265
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Horario"
        '
        'PM
        '
        Me.PM.AutoSize = True
        Me.PM.Location = New System.Drawing.Point(54, 22)
        Me.PM.Name = "PM"
        Me.PM.Size = New System.Drawing.Size(49, 22)
        Me.PM.TabIndex = 1
        Me.PM.TabStop = True
        Me.PM.Text = "PM"
        Me.PM.UseVisualStyleBackColor = True
        '
        'AM
        '
        Me.AM.AutoSize = True
        Me.AM.Location = New System.Drawing.Point(6, 22)
        Me.AM.Name = "AM"
        Me.AM.Size = New System.Drawing.Size(50, 22)
        Me.AM.TabIndex = 0
        Me.AM.TabStop = True
        Me.AM.Text = "AM"
        Me.AM.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(699, 577)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 32)
        Me.Button1.TabIndex = 199
        Me.Button1.Text = "Cerrar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(6, 579)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(87, 30)
        Me.btnFinalizar.TabIndex = 266
        Me.btnFinalizar.Text = "Grabar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rbSala)
        Me.GroupBox6.Controls.Add(Me.rbCCalidad)
        Me.GroupBox6.Location = New System.Drawing.Point(526, 114)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(260, 51)
        Me.GroupBox6.TabIndex = 267
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Proveedor"
        '
        'rbSala
        '
        Me.rbSala.AutoSize = True
        Me.rbSala.Location = New System.Drawing.Point(111, 21)
        Me.rbSala.Name = "rbSala"
        Me.rbSala.Size = New System.Drawing.Size(54, 22)
        Me.rbSala.TabIndex = 1
        Me.rbSala.TabStop = True
        Me.rbSala.Text = "Sala"
        Me.rbSala.UseVisualStyleBackColor = True
        '
        'rbCCalidad
        '
        Me.rbCCalidad.AutoSize = True
        Me.rbCCalidad.Location = New System.Drawing.Point(6, 21)
        Me.rbCCalidad.Name = "rbCCalidad"
        Me.rbCCalidad.Size = New System.Drawing.Size(90, 22)
        Me.rbCCalidad.TabIndex = 0
        Me.rbCCalidad.TabStop = True
        Me.rbCCalidad.Text = "C. Calidad"
        Me.rbCCalidad.UseVisualStyleBackColor = True
        '
        'rbtrojo
        '
        Me.rbtrojo.AutoSize = True
        Me.rbtrojo.Location = New System.Drawing.Point(6, 21)
        Me.rbtrojo.Name = "rbtrojo"
        Me.rbtrojo.Size = New System.Drawing.Size(91, 22)
        Me.rbtrojo.TabIndex = 0
        Me.rbtrojo.TabStop = True
        Me.rbtrojo.Text = "UFC(Rojo)"
        Me.rbtrojo.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rbtazul)
        Me.GroupBox7.Controls.Add(Me.rbtrojo)
        Me.GroupBox7.Location = New System.Drawing.Point(330, 114)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(190, 51)
        Me.GroupBox7.TabIndex = 269
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Tipo Muestra"
        '
        'rbtazul
        '
        Me.rbtazul.AutoSize = True
        Me.rbtazul.Location = New System.Drawing.Point(101, 21)
        Me.rbtazul.Name = "rbtazul"
        Me.rbtazul.Size = New System.Drawing.Size(89, 22)
        Me.rbtazul.TabIndex = 1
        Me.rbtazul.TabStop = True
        Me.rbtazul.Text = "RCS(Azul)"
        Me.rbtazul.UseVisualStyleBackColor = True
        '
        'frmMuestraLeche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 633)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.grpRetiro)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmMuestraLeche"
        Me.ShowInTaskbar = False
        Me.Text = "Lectura Etiquetas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.grpRetiro.ResumeLayout(False)
        CType(Me.dgvRetiroLeche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblCentro As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblEstanque As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblNum As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDIIO As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Fecha As DateTimePicker
    Friend WithEvents grpRetiro As GroupBox
    Friend WithEvents dgvRetiroLeche As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Externo As RadioButton
    Friend WithEvents Interno As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cboProveedores As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PM As RadioButton
    Friend WithEvents AM As RadioButton
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents CodLector As DataGridViewTextBoxColumn
    Friend WithEvents CentroCod As DataGridViewTextBoxColumn
    Friend WithEvents EstanqueCod As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents cen As DataGridViewTextBoxColumn
    Friend WithEvents est As DataGridViewTextBoxColumn
    Friend WithEvents fech As DataGridViewTextBoxColumn
    Friend WithEvents prov As DataGridViewTextBoxColumn
    Friend WithEvents Proveedores As DataGridViewTextBoxColumn
    Friend WithEvents Hor As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents rbSala As RadioButton
    Friend WithEvents rbCCalidad As RadioButton
    Friend WithEvents rbtrojo As RadioButton
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents rbtazul As RadioButton
End Class
