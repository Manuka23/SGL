<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalidadLecheIngreso3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalidadLecheIngreso3))
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.cboPlantas = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.quincenal = New System.Windows.Forms.RadioButton()
        Me.preliminar = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.grpRetiro = New System.Windows.Forms.GroupBox()
        Me.dgvCalidadLeche = New System.Windows.Forms.DataGridView()
        Me.Centro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroCod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Litros = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grasa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proteina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Urea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Densidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Crioscopia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UFC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MSolida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Control = New System.Windows.Forms.RadioButton()
        Me.Interna = New System.Windows.Forms.RadioButton()
        Me.Planta = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboProveedores = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.btnArchivo = New System.Windows.Forms.Button()
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpRetiro.SuspendLayout()
        CType(Me.dgvCalidadLeche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.cboPlantas)
        Me.GroupBox12.Location = New System.Drawing.Point(209, 12)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(196, 54)
        Me.GroupBox12.TabIndex = 258
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Plantas"
        '
        'cboPlantas
        '
        Me.cboPlantas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlantas.Enabled = False
        Me.cboPlantas.FormattingEnabled = True
        Me.cboPlantas.Location = New System.Drawing.Point(6, 19)
        Me.cboPlantas.Name = "cboPlantas"
        Me.cboPlantas.Size = New System.Drawing.Size(182, 21)
        Me.cboPlantas.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.quincenal)
        Me.GroupBox2.Controls.Add(Me.preliminar)
        Me.GroupBox2.Location = New System.Drawing.Point(411, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 54)
        Me.GroupBox2.TabIndex = 250
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Periodo"
        '
        'quincenal
        '
        Me.quincenal.AutoSize = True
        Me.quincenal.Location = New System.Drawing.Point(82, 21)
        Me.quincenal.Name = "quincenal"
        Me.quincenal.Size = New System.Drawing.Size(73, 17)
        Me.quincenal.TabIndex = 1
        Me.quincenal.TabStop = True
        Me.quincenal.Text = "Quincenal"
        Me.quincenal.UseVisualStyleBackColor = True
        '
        'preliminar
        '
        Me.preliminar.AutoSize = True
        Me.preliminar.Location = New System.Drawing.Point(6, 22)
        Me.preliminar.Name = "preliminar"
        Me.preliminar.Size = New System.Drawing.Size(70, 17)
        Me.preliminar.TabIndex = 0
        Me.preliminar.TabStop = True
        Me.preliminar.Text = "Preliminar"
        Me.preliminar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(103, 54)
        Me.GroupBox1.TabIndex = 249
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(6, 19)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(87, 20)
        Me.dtpFecha.TabIndex = 55
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(9, 535)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(93, 37)
        Me.btnGrabar.TabIndex = 253
        Me.btnGrabar.Text = "   Finalizar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'grpRetiro
        '
        Me.grpRetiro.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grpRetiro.Controls.Add(Me.dgvCalidadLeche)
        Me.grpRetiro.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRetiro.Location = New System.Drawing.Point(9, 133)
        Me.grpRetiro.Name = "grpRetiro"
        Me.grpRetiro.Size = New System.Drawing.Size(821, 396)
        Me.grpRetiro.TabIndex = 259
        Me.grpRetiro.TabStop = False
        Me.grpRetiro.Text = "Ingreso Calidad Leche"
        '
        'dgvCalidadLeche
        '
        Me.dgvCalidadLeche.AllowDrop = True
        Me.dgvCalidadLeche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCalidadLeche.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Centro, Me.CentroCod, Me.Litros, Me.RCS, Me.Grasa, Me.Proteina, Me.Urea, Me.Densidad, Me.Crioscopia, Me.UFC, Me.MSolida})
        Me.dgvCalidadLeche.Enabled = False
        Me.dgvCalidadLeche.GridColor = System.Drawing.SystemColors.Control
        Me.dgvCalidadLeche.Location = New System.Drawing.Point(9, 19)
        Me.dgvCalidadLeche.Name = "dgvCalidadLeche"
        Me.dgvCalidadLeche.Size = New System.Drawing.Size(804, 377)
        Me.dgvCalidadLeche.TabIndex = 12
        '
        'Centro
        '
        Me.Centro.HeaderText = "Centros"
        Me.Centro.MaxInputLength = 12222
        Me.Centro.Name = "Centro"
        Me.Centro.ReadOnly = True
        Me.Centro.Width = 120
        '
        'CentroCod
        '
        Me.CentroCod.HeaderText = "Column1"
        Me.CentroCod.Name = "CentroCod"
        Me.CentroCod.ReadOnly = True
        Me.CentroCod.Visible = False
        Me.CentroCod.Width = 111
        '
        'Litros
        '
        Me.Litros.HeaderText = "Litros"
        Me.Litros.Name = "Litros"
        Me.Litros.Width = 70
        '
        'RCS
        '
        Me.RCS.HeaderText = "RCS"
        Me.RCS.Name = "RCS"
        Me.RCS.Width = 70
        '
        'Grasa
        '
        Me.Grasa.HeaderText = "Grasa"
        Me.Grasa.Name = "Grasa"
        Me.Grasa.Width = 70
        '
        'Proteina
        '
        Me.Proteina.HeaderText = "Proteina"
        Me.Proteina.Name = "Proteina"
        Me.Proteina.Width = 70
        '
        'Urea
        '
        Me.Urea.HeaderText = "Urea"
        Me.Urea.Name = "Urea"
        Me.Urea.Width = 70
        '
        'Densidad
        '
        Me.Densidad.HeaderText = "Densidad "
        Me.Densidad.Name = "Densidad"
        Me.Densidad.Width = 70
        '
        'Crioscopia
        '
        Me.Crioscopia.HeaderText = "Crioscopia"
        Me.Crioscopia.Name = "Crioscopia"
        Me.Crioscopia.Width = 70
        '
        'UFC
        '
        Me.UFC.HeaderText = "UFC"
        Me.UFC.Name = "UFC"
        Me.UFC.Width = 70
        '
        'MSolida
        '
        Me.MSolida.HeaderText = "M. Solida"
        Me.MSolida.Name = "MSolida"
        Me.MSolida.ReadOnly = True
        Me.MSolida.Width = 80
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Control)
        Me.GroupBox3.Controls.Add(Me.Interna)
        Me.GroupBox3.Controls.Add(Me.Planta)
        Me.GroupBox3.Location = New System.Drawing.Point(118, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(84, 115)
        Me.GroupBox3.TabIndex = 260
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo Control"
        '
        'Control
        '
        Me.Control.AutoSize = True
        Me.Control.Location = New System.Drawing.Point(6, 86)
        Me.Control.Name = "Control"
        Me.Control.Size = New System.Drawing.Size(58, 17)
        Me.Control.TabIndex = 2
        Me.Control.TabStop = True
        Me.Control.Text = "Control"
        Me.Control.UseVisualStyleBackColor = True
        '
        'Interna
        '
        Me.Interna.AutoSize = True
        Me.Interna.Location = New System.Drawing.Point(6, 55)
        Me.Interna.Name = "Interna"
        Me.Interna.Size = New System.Drawing.Size(58, 17)
        Me.Interna.TabIndex = 1
        Me.Interna.TabStop = True
        Me.Interna.Text = "Interna"
        Me.Interna.UseVisualStyleBackColor = True
        '
        'Planta
        '
        Me.Planta.AutoSize = True
        Me.Planta.Location = New System.Drawing.Point(6, 22)
        Me.Planta.Name = "Planta"
        Me.Planta.Size = New System.Drawing.Size(55, 17)
        Me.Planta.TabIndex = 0
        Me.Planta.TabStop = True
        Me.Planta.Text = "Planta"
        Me.Planta.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(743, 535)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 37)
        Me.Button1.TabIndex = 261
        Me.Button1.Text = "Cerrar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(9, 77)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 40)
        Me.Button2.TabIndex = 262
        Me.Button2.Text = "Cargar Centros"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboProveedores)
        Me.GroupBox4.Location = New System.Drawing.Point(209, 73)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(196, 54)
        Me.GroupBox4.TabIndex = 263
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
        Me.cboProveedores.Size = New System.Drawing.Size(182, 21)
        Me.cboProveedores.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtArchivo)
        Me.GroupBox5.Controls.Add(Me.btnArchivo)
        Me.GroupBox5.Location = New System.Drawing.Point(411, 72)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(419, 55)
        Me.GroupBox5.TabIndex = 185
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Ingreso por Excel"
        '
        'txtArchivo
        '
        Me.txtArchivo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtArchivo.Location = New System.Drawing.Point(6, 22)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(312, 23)
        Me.txtArchivo.TabIndex = 104
        Me.txtArchivo.Text = "[ Archivo Seleccionado ]"
        '
        'btnArchivo
        '
        Me.btnArchivo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchivo.Image = CType(resources.GetObject("btnArchivo.Image"), System.Drawing.Image)
        Me.btnArchivo.Location = New System.Drawing.Point(324, 19)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(87, 30)
        Me.btnArchivo.TabIndex = 105
        Me.btnArchivo.Text = "Archivo"
        Me.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'OpenFDlg
        '
        Me.OpenFDlg.FileName = "OpenFileDialog1"
        '
        'CalidadLecheIngreso3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 579)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox12)
        Me.Controls.Add(Me.grpRetiro)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CalidadLecheIngreso3"
        Me.ShowInTaskbar = False
        Me.Text = "Calidad Leche"
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.grpRetiro.ResumeLayout(False)
        CType(Me.dgvCalidadLeche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents cboPlantas As ComboBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents quincenal As RadioButton
    Friend WithEvents preliminar As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents grpRetiro As GroupBox
    Friend WithEvents dgvCalidadLeche As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Control As RadioButton
    Friend WithEvents Interna As RadioButton
    Friend WithEvents Planta As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cboProveedores As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtArchivo As TextBox
    Friend WithEvents btnArchivo As Button
    Friend WithEvents Centro As DataGridViewTextBoxColumn
    Friend WithEvents CentroCod As DataGridViewTextBoxColumn
    Friend WithEvents Litros As DataGridViewTextBoxColumn
    Friend WithEvents RCS As DataGridViewTextBoxColumn
    Friend WithEvents Grasa As DataGridViewTextBoxColumn
    Friend WithEvents Proteina As DataGridViewTextBoxColumn
    Friend WithEvents Urea As DataGridViewTextBoxColumn
    Friend WithEvents Densidad As DataGridViewTextBoxColumn
    Friend WithEvents Crioscopia As DataGridViewTextBoxColumn
    Friend WithEvents UFC As DataGridViewTextBoxColumn
    Friend WithEvents MSolida As DataGridViewTextBoxColumn
    Friend WithEvents OpenFDlg As OpenFileDialog
End Class
