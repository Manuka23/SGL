<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSilosModificar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSilosModificar))
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cboBolo = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.gboxIngMediciones = New System.Windows.Forms.GroupBox()
        Me.dgvPOTREROS = New System.Windows.Forms.DataGridView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Cemtro = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Item = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Fech = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Valor = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Potrero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Centro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Medida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rendimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.va = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CentroCod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ensilaj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.gboxIngMediciones.SuspendLayout()
        CType(Me.dgvPOTREROS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.cboBolo)
        Me.GroupBox9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(971, 54)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(245, 57)
        Me.GroupBox9.TabIndex = 257
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Tipo Ensilaje"
        Me.GroupBox9.Visible = False
        '
        'cboBolo
        '
        Me.cboBolo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBolo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBolo.FormattingEnabled = True
        Me.cboBolo.Location = New System.Drawing.Point(12, 19)
        Me.cboBolo.Name = "cboBolo"
        Me.cboBolo.Size = New System.Drawing.Size(215, 23)
        Me.cboBolo.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboCentros)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(728, 52)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(237, 58)
        Me.GroupBox5.TabIndex = 255
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Centro"
        Me.GroupBox5.Visible = False
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(6, 22)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(214, 23)
        Me.cboCentros.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(1363, 65)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 37)
        Me.btnBuscar.TabIndex = 254
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        Me.btnBuscar.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(1222, 53)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(109, 58)
        Me.GroupBox6.TabIndex = 253
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Fecha"
        Me.GroupBox6.Visible = False
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(6, 19)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(87, 23)
        Me.dtpFechaDesde.TabIndex = 56
        Me.dtpFechaDesde.Value = New Date(2017, 10, 6, 15, 45, 48, 0)
        '
        'gboxIngMediciones
        '
        Me.gboxIngMediciones.Controls.Add(Me.dgvPOTREROS)
        Me.gboxIngMediciones.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxIngMediciones.Location = New System.Drawing.Point(8, 145)
        Me.gboxIngMediciones.Name = "gboxIngMediciones"
        Me.gboxIngMediciones.Size = New System.Drawing.Size(758, 448)
        Me.gboxIngMediciones.TabIndex = 258
        Me.gboxIngMediciones.TabStop = False
        Me.gboxIngMediciones.Text = "Seleccion de Potreros"
        '
        'dgvPOTREROS
        '
        Me.dgvPOTREROS.AllowUserToAddRows = False
        Me.dgvPOTREROS.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgvPOTREROS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPOTREROS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Potrero, Me.Centro, Me.Column1, Me.Medida, Me.Cant, Me.Ha, Me.Rendimiento, Me.va, Me.Total, Me.CentroCod, Me.Ensilaj, Me.Column2})
        Me.dgvPOTREROS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPOTREROS.Location = New System.Drawing.Point(3, 18)
        Me.dgvPOTREROS.Name = "dgvPOTREROS"
        Me.dgvPOTREROS.RowHeadersVisible = False
        Me.dgvPOTREROS.RowTemplate.Height = 20
        Me.dgvPOTREROS.ShowEditingIcon = False
        Me.dgvPOTREROS.Size = New System.Drawing.Size(752, 427)
        Me.dgvPOTREROS.TabIndex = 15
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(656, 596)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(110, 30)
        Me.btnSalir.TabIndex = 261
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = Global.SGL.My.Resources.Resources.disk
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(8, 599)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(107, 30)
        Me.btnFinalizar.TabIndex = 259
        Me.btnFinalizar.Text = "Grabar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(80, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(601, 30)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ingreso Valor Bolos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-4, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(783, 46)
        Me.Panel1.TabIndex = 263

        '
        'Cemtro
        '
        Me.Cemtro.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cemtro.Location = New System.Drawing.Point(103, 18)
        Me.Cemtro.Name = "Cemtro"
        Me.Cemtro.Size = New System.Drawing.Size(232, 21)
        Me.Cemtro.TabIndex = 264
        Me.Cemtro.Text = "---"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 21)
        Me.Label9.TabIndex = 265
        Me.Label9.Text = "Centro:"
        '
        'Item
        '
        Me.Item.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Item.Location = New System.Drawing.Point(103, 39)
        Me.Item.Name = "Item"
        Me.Item.Size = New System.Drawing.Size(232, 21)
        Me.Item.TabIndex = 266
        Me.Item.Text = "---"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 21)
        Me.Label2.TabIndex = 267
        Me.Label2.Text = "Tipo Ensilaje:"
        '
        'Fech
        '
        Me.Fech.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fech.Location = New System.Drawing.Point(103, 60)
        Me.Fech.Name = "Fech"
        Me.Fech.Size = New System.Drawing.Size(232, 21)
        Me.Fech.TabIndex = 268
        Me.Fech.Text = "---"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 21)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "Fecha:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Fech)
        Me.GroupBox1.Controls.Add(Me.Cemtro)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Item)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(340, 87)
        Me.GroupBox1.TabIndex = 270
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Ensilaje"
        '
        'Valor
        '
        Me.Valor.Location = New System.Drawing.Point(6, 24)
        Me.Valor.Name = "Valor"
        Me.Valor.Size = New System.Drawing.Size(100, 22)
        Me.Valor.TabIndex = 271
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Valor)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(354, 52)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 60)
        Me.GroupBox2.TabIndex = 272
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Valor Bolo"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.SGL.My.Resources.Resources.arrow_down
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(126, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 30)
        Me.Button1.TabIndex = 272
        Me.Button1.Text = "Replicar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Potrero
        '
        Me.Potrero.Frozen = True
        Me.Potrero.HeaderText = "Potrero"
        Me.Potrero.Name = "Potrero"
        Me.Potrero.ReadOnly = True
        Me.Potrero.Width = 55
        '
        'Centro
        '
        Me.Centro.Frozen = True
        Me.Centro.HeaderText = "Centro"
        Me.Centro.Name = "Centro"
        Me.Centro.ReadOnly = True
        Me.Centro.Width = 120
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "Tip. Ensilaje"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 140
        '
        'Medida
        '
        Me.Medida.Frozen = True
        Me.Medida.HeaderText = "Med."
        Me.Medida.Name = "Medida"
        Me.Medida.ReadOnly = True
        Me.Medida.Width = 70
        '
        'Cant
        '
        Me.Cant.HeaderText = "Cant. Bolos"
        Me.Cant.Name = "Cant"
        Me.Cant.Width = 60
        '
        'Ha
        '
        Me.Ha.HeaderText = "Ha"
        Me.Ha.Name = "Ha"
        Me.Ha.ReadOnly = True
        Me.Ha.Width = 50
        '
        'Rendimiento
        '
        Me.Rendimiento.HeaderText = "Rend"
        Me.Rendimiento.Name = "Rendimiento"
        Me.Rendimiento.ReadOnly = True
        Me.Rendimiento.Width = 60
        '
        'va
        '
        Me.va.HeaderText = "Valor Bolo"
        Me.va.Name = "va"
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        '
        'CentroCod
        '
        Me.CentroCod.HeaderText = "CentroCod"
        Me.CentroCod.Name = "CentroCod"
        Me.CentroCod.ReadOnly = True
        Me.CentroCod.Visible = False
        Me.CentroCod.Width = 5
        '
        'Ensilaj
        '
        Me.Ensilaj.HeaderText = "EnsilajeCod"
        Me.Ensilaj.Name = "Ensilaj"
        Me.Ensilaj.ReadOnly = True
        Me.Ensilaj.Visible = False
        Me.Ensilaj.Width = 5
        '
        'Column2
        '
        Me.Column2.HeaderText = "Fecha"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        Me.Column2.Width = 5
        '
        'frmSilosModificar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 634)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.gboxIngMediciones)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSilosModificar"
        Me.Text = "Modificar Ensilajes"
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.gboxIngMediciones.ResumeLayout(False)
        CType(Me.dgvPOTREROS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents cboBolo As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cboCentros As ComboBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents gboxIngMediciones As GroupBox
    Friend WithEvents dgvPOTREROS As DataGridView
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Cemtro As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Item As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Fech As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Valor As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Potrero As DataGridViewTextBoxColumn
    Friend WithEvents Centro As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Medida As DataGridViewTextBoxColumn
    Friend WithEvents Cant As DataGridViewTextBoxColumn
    Friend WithEvents Ha As DataGridViewTextBoxColumn
    Friend WithEvents Rendimiento As DataGridViewTextBoxColumn
    Friend WithEvents va As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
    Friend WithEvents CentroCod As DataGridViewTextBoxColumn
    Friend WithEvents Ensilaj As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
End Class
