<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMuestraLecheEnvio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMuestraLecheEnvio))
        Me.grpRetiro = New System.Windows.Forms.GroupBox()
        Me.lvGanado = New System.Windows.Forms.ListView()
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TipoMues = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtLector = New System.Windows.Forms.TextBox()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.BtnTxt = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnImprime = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbufc = New System.Windows.Forms.RadioButton()
        Me.rbrcs = New System.Windows.Forms.RadioButton()
        Me.grpRetiro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRetiro
        '
        Me.grpRetiro.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grpRetiro.Controls.Add(Me.lvGanado)
        Me.grpRetiro.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRetiro.Location = New System.Drawing.Point(6, 64)
        Me.grpRetiro.Name = "grpRetiro"
        Me.grpRetiro.Size = New System.Drawing.Size(759, 411)
        Me.grpRetiro.TabIndex = 270
        Me.grpRetiro.TabStop = False
        Me.grpRetiro.Text = "Muestras"
        '
        'lvGanado
        '
        Me.lvGanado.AutoArrange = False
        Me.lvGanado.BackColor = System.Drawing.SystemColors.Window
        Me.lvGanado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader9, Me.ColumnHeader14, Me.ColumnHeader2, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader5, Me.TipoMues})
        Me.lvGanado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvGanado.FullRowSelect = True
        Me.lvGanado.GridLines = True
        Me.lvGanado.HideSelection = False
        Me.lvGanado.Location = New System.Drawing.Point(3, 23)
        Me.lvGanado.Name = "lvGanado"
        Me.lvGanado.Size = New System.Drawing.Size(753, 385)
        Me.lvGanado.TabIndex = 202
        Me.lvGanado.UseCompatibleStateImageBehavior = False
        Me.lvGanado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Nro"
        Me.ColumnHeader12.Width = 35
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Centro"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Estanque"
        Me.ColumnHeader4.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Fecha"
        Me.ColumnHeader9.Width = 94
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Proveedor"
        Me.ColumnHeader14.Width = 97
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Proveedores"
        Me.ColumnHeader2.Width = 137
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Horario"
        Me.ColumnHeader7.Width = 55
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "CodLector"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "CodEstanque"
        Me.ColumnHeader5.Width = 0
        '
        'TipoMues
        '
        Me.TipoMues.Text = "Tipo Muestra"
        Me.TipoMues.Width = 113
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtLector)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(147, 55)
        Me.GroupBox1.TabIndex = 266
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lectura Pendientes"
        '
        'txtLector
        '
        Me.txtLector.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLector.Location = New System.Drawing.Point(6, 21)
        Me.txtLector.MaxLength = 20
        Me.txtLector.Name = "txtLector"
        Me.txtLector.Size = New System.Drawing.Size(127, 28)
        Me.txtLector.TabIndex = 40
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(6, 481)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(87, 32)
        Me.btnFinalizar.TabIndex = 272
        Me.btnFinalizar.Text = "Grabar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'BtnTxt
        '
        Me.BtnTxt.Enabled = False
        Me.BtnTxt.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTxt.Image = Global.SGL.My.Resources.Resources.page_edit
        Me.BtnTxt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTxt.Location = New System.Drawing.Point(210, 481)
        Me.BtnTxt.Name = "BtnTxt"
        Me.BtnTxt.Size = New System.Drawing.Size(114, 32)
        Me.BtnTxt.TabIndex = 271
        Me.BtnTxt.Text = "    Gen. Lote Envio"
        Me.BtnTxt.UseVisualStyleBackColor = True
        Me.BtnTxt.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(675, 481)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 32)
        Me.Button1.TabIndex = 268
        Me.Button1.Text = "Cerrar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnImprime
        '
        Me.btnImprime.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprime.Image = CType(resources.GetObject("btnImprime.Image"), System.Drawing.Image)
        Me.btnImprime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprime.Location = New System.Drawing.Point(99, 481)
        Me.btnImprime.Name = "btnImprime"
        Me.btnImprime.Size = New System.Drawing.Size(105, 32)
        Me.btnImprime.TabIndex = 274
        Me.btnImprime.Text = "Imprime"
        Me.btnImprime.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbufc)
        Me.GroupBox2.Controls.Add(Me.rbrcs)
        Me.GroupBox2.Location = New System.Drawing.Point(176, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(196, 55)
        Me.GroupBox2.TabIndex = 275
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Muestra"
        '
        'rbufc
        '
        Me.rbufc.AutoSize = True
        Me.rbufc.Location = New System.Drawing.Point(100, 24)
        Me.rbufc.Name = "rbufc"
        Me.rbufc.Size = New System.Drawing.Size(91, 22)
        Me.rbufc.TabIndex = 1
        Me.rbufc.TabStop = True
        Me.rbufc.Text = "UFC(Rojo)"
        Me.rbufc.UseVisualStyleBackColor = True
        '
        'rbrcs
        '
        Me.rbrcs.AutoSize = True
        Me.rbrcs.Location = New System.Drawing.Point(6, 24)
        Me.rbrcs.Name = "rbrcs"
        Me.rbrcs.Size = New System.Drawing.Size(89, 22)
        Me.rbrcs.TabIndex = 0
        Me.rbrcs.TabStop = True
        Me.rbrcs.Text = "RCS(Azul)"
        Me.rbrcs.UseVisualStyleBackColor = True
        '
        'frmMuestraLecheEnvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 518)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnImprime)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.BtnTxt)
        Me.Controls.Add(Me.grpRetiro)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMuestraLecheEnvio"
        Me.ShowInTaskbar = False
        Me.Text = "Generar Envio"
        Me.grpRetiro.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpRetiro As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtLector As TextBox
    Friend WithEvents BtnTxt As Button
    Friend WithEvents lvGanado As ListView
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents btnImprime As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbufc As RadioButton
    Friend WithEvents rbrcs As RadioButton
    Friend WithEvents TipoMues As ColumnHeader
End Class
