<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMuestraLecheIngresoManual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMuestraLecheIngresoManual))
        Me.grpRetiro = New System.Windows.Forms.GroupBox()
        Me.dgvCalidadLeche = New System.Windows.Forms.DataGridView()
        Me.Estanque = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroCod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Grasa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proteina = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Urea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Densidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Crioscopia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UFC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MSolida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PM = New System.Windows.Forms.RadioButton()
        Me.AM = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cboProveedores = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Externo = New System.Windows.Forms.RadioButton()
        Me.Interno = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Fecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboEstanques = New System.Windows.Forms.ComboBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.FechaRes = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.rbSala = New System.Windows.Forms.RadioButton()
        Me.rbCCalidad = New System.Windows.Forms.RadioButton()
        Me.grpRetiro.SuspendLayout()
        CType(Me.dgvCalidadLeche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRetiro
        '
        Me.grpRetiro.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grpRetiro.Controls.Add(Me.dgvCalidadLeche)
        Me.grpRetiro.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRetiro.Location = New System.Drawing.Point(7, 129)
        Me.grpRetiro.Name = "grpRetiro"
        Me.grpRetiro.Size = New System.Drawing.Size(750, 396)
        Me.grpRetiro.TabIndex = 263
        Me.grpRetiro.TabStop = False
        Me.grpRetiro.Text = "Ingreso Muestra Leche"
        '
        'dgvCalidadLeche
        '
        Me.dgvCalidadLeche.AllowDrop = True
        Me.dgvCalidadLeche.AllowUserToAddRows = False
        Me.dgvCalidadLeche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCalidadLeche.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Estanque, Me.CentroCod, Me.RCS, Me.Grasa, Me.Proteina, Me.Urea, Me.Densidad, Me.Crioscopia, Me.UFC, Me.MSolida})
        Me.dgvCalidadLeche.GridColor = System.Drawing.SystemColors.Control
        Me.dgvCalidadLeche.Location = New System.Drawing.Point(9, 19)
        Me.dgvCalidadLeche.Name = "dgvCalidadLeche"
        Me.dgvCalidadLeche.Size = New System.Drawing.Size(734, 371)
        Me.dgvCalidadLeche.TabIndex = 12
        '
        'Estanque
        '
        Me.Estanque.HeaderText = "Estanque"
        Me.Estanque.MaxInputLength = 12222
        Me.Estanque.Name = "Estanque"
        Me.Estanque.ReadOnly = True
        Me.Estanque.Width = 120
        '
        'CentroCod
        '
        Me.CentroCod.HeaderText = "Column1"
        Me.CentroCod.Name = "CentroCod"
        Me.CentroCod.ReadOnly = True
        Me.CentroCod.Visible = False
        Me.CentroCod.Width = 111
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
        Me.MSolida.Width = 80
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(670, 531)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 37)
        Me.Button1.TabIndex = 264
        Me.Button1.Text = "Cerrar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(7, 532)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(93, 37)
        Me.btnGrabar.TabIndex = 262
        Me.btnGrabar.Text = "   Finalizar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PM)
        Me.GroupBox2.Controls.Add(Me.AM)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(573, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(98, 57)
        Me.GroupBox2.TabIndex = 270
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Horario"
        '
        'PM
        '
        Me.PM.AutoSize = True
        Me.PM.Location = New System.Drawing.Point(54, 22)
        Me.PM.Name = "PM"
        Me.PM.Size = New System.Drawing.Size(41, 18)
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
        Me.AM.Size = New System.Drawing.Size(42, 18)
        Me.AM.TabIndex = 0
        Me.AM.TabStop = True
        Me.AM.Text = "AM"
        Me.AM.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboProveedores)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(188, 75)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(236, 48)
        Me.GroupBox4.TabIndex = 269
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
        Me.cboProveedores.Size = New System.Drawing.Size(224, 22)
        Me.cboProveedores.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Externo)
        Me.GroupBox3.Controls.Add(Me.Interno)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(7, 75)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(175, 48)
        Me.GroupBox3.TabIndex = 268
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Proveedor"
        '
        'Externo
        '
        Me.Externo.AutoSize = True
        Me.Externo.Location = New System.Drawing.Point(89, 21)
        Me.Externo.Name = "Externo"
        Me.Externo.Size = New System.Drawing.Size(65, 18)
        Me.Externo.TabIndex = 1
        Me.Externo.TabStop = True
        Me.Externo.Text = "Externo"
        Me.Externo.UseVisualStyleBackColor = True
        '
        'Interno
        '
        Me.Interno.AutoSize = True
        Me.Interno.Location = New System.Drawing.Point(18, 21)
        Me.Interno.Name = "Interno"
        Me.Interno.Size = New System.Drawing.Size(65, 18)
        Me.Interno.TabIndex = 0
        Me.Interno.TabStop = True
        Me.Interno.Text = "Interno"
        Me.Interno.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Fecha)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(249, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(156, 57)
        Me.GroupBox5.TabIndex = 267
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fecha Envio"
        '
        'Fecha
        '
        Me.Fecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha.Location = New System.Drawing.Point(22, 20)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(111, 26)
        Me.Fecha.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboEstanques)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(236, 57)
        Me.GroupBox1.TabIndex = 271
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estanque"
        '
        'cboEstanques
        '
        Me.cboEstanques.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstanques.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstanques.FormattingEnabled = True
        Me.cboEstanques.Location = New System.Drawing.Point(12, 19)
        Me.cboEstanques.Name = "cboEstanques"
        Me.cboEstanques.Size = New System.Drawing.Size(218, 23)
        Me.cboEstanques.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(430, 89)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(107, 30)
        Me.btnAgregar.TabIndex = 272
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.FechaRes)
        Me.GroupBox6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(411, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(156, 57)
        Me.GroupBox6.TabIndex = 273
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Fecha Resultado"
        '
        'FechaRes
        '
        Me.FechaRes.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FechaRes.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaRes.Location = New System.Drawing.Point(22, 20)
        Me.FechaRes.Name = "FechaRes"
        Me.FechaRes.Size = New System.Drawing.Size(111, 26)
        Me.FechaRes.TabIndex = 1
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rbSala)
        Me.GroupBox7.Controls.Add(Me.rbCCalidad)
        Me.GroupBox7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(543, 75)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(207, 51)
        Me.GroupBox7.TabIndex = 274
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Proveedor"
        '
        'rbSala
        '
        Me.rbSala.AutoSize = True
        Me.rbSala.Location = New System.Drawing.Point(111, 21)
        Me.rbSala.Name = "rbSala"
        Me.rbSala.Size = New System.Drawing.Size(49, 18)
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
        Me.rbCCalidad.Size = New System.Drawing.Size(79, 18)
        Me.rbCCalidad.TabIndex = 0
        Me.rbCCalidad.TabStop = True
        Me.rbCCalidad.Text = "C. Calidad"
        Me.rbCCalidad.UseVisualStyleBackColor = True
        '
        'frmMuestraLecheIngresoManual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 577)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grpRetiro)
        Me.Controls.Add(Me.btnGrabar)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMuestraLecheIngresoManual"
        Me.Text = "Muestra de Leche"
        Me.grpRetiro.ResumeLayout(False)
        CType(Me.dgvCalidadLeche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents grpRetiro As GroupBox
    Friend WithEvents dgvCalidadLeche As DataGridView
    Friend WithEvents btnGrabar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents PM As RadioButton
    Friend WithEvents AM As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cboProveedores As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Externo As RadioButton
    Friend WithEvents Interno As RadioButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Fecha As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboEstanques As ComboBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Estanque As DataGridViewTextBoxColumn
    Friend WithEvents CentroCod As DataGridViewTextBoxColumn
    Friend WithEvents RCS As DataGridViewTextBoxColumn
    Friend WithEvents Grasa As DataGridViewTextBoxColumn
    Friend WithEvents Proteina As DataGridViewTextBoxColumn
    Friend WithEvents Urea As DataGridViewTextBoxColumn
    Friend WithEvents Densidad As DataGridViewTextBoxColumn
    Friend WithEvents Crioscopia As DataGridViewTextBoxColumn
    Friend WithEvents UFC As DataGridViewTextBoxColumn
    Friend WithEvents MSolida As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents FechaRes As DateTimePicker
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents rbSala As RadioButton
    Friend WithEvents rbCCalidad As RadioButton
End Class
