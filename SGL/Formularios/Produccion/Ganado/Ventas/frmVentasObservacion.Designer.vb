<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentasObservacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentasObservacion))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbDesaparecido = New System.Windows.Forms.RadioButton()
        Me.rdbMuerto = New System.Windows.Forms.RadioButton()
        Me.rdbVivo = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 90)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(275, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingresar Observación de Eliminación (10 caracteres min.)"
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(8, 0)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(582, 24)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "OBSERVACION"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 33)
        Me.Panel1.TabIndex = 77
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(9, 105)
        Me.txtObservacion.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(570, 62)
        Me.txtObservacion.TabIndex = 78
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(9, 171)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(86, 30)
        Me.btnEliminar.TabIndex = 79
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(494, 171)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 30)
        Me.btnCancelar.TabIndex = 80
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbDesaparecido)
        Me.GroupBox1.Controls.Add(Me.rdbMuerto)
        Me.GroupBox1.Controls.Add(Me.rdbVivo)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 40)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(258, 41)
        Me.GroupBox1.TabIndex = 81
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado Del Animal"
        '
        'rdbDesaparecido
        '
        Me.rdbDesaparecido.AutoSize = True
        Me.rdbDesaparecido.Location = New System.Drawing.Point(169, 20)
        Me.rdbDesaparecido.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rdbDesaparecido.Name = "rdbDesaparecido"
        Me.rdbDesaparecido.Size = New System.Drawing.Size(91, 17)
        Me.rdbDesaparecido.TabIndex = 2
        Me.rdbDesaparecido.TabStop = True
        Me.rdbDesaparecido.Text = "Desaparecido"
        Me.rdbDesaparecido.UseVisualStyleBackColor = True
        '
        'rdbMuerto
        '
        Me.rdbMuerto.AutoSize = True
        Me.rdbMuerto.Location = New System.Drawing.Point(84, 20)
        Me.rdbMuerto.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rdbMuerto.Name = "rdbMuerto"
        Me.rdbMuerto.Size = New System.Drawing.Size(58, 17)
        Me.rdbMuerto.TabIndex = 1
        Me.rdbMuerto.TabStop = True
        Me.rdbMuerto.Text = "Muerto"
        Me.rdbMuerto.UseVisualStyleBackColor = True
        '
        'rdbVivo
        '
        Me.rdbVivo.AutoSize = True
        Me.rdbVivo.Location = New System.Drawing.Point(4, 20)
        Me.rdbVivo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.rdbVivo.Name = "rdbVivo"
        Me.rdbVivo.Size = New System.Drawing.Size(46, 17)
        Me.rdbVivo.TabIndex = 0
        Me.rdbVivo.TabStop = True
        Me.rdbVivo.Text = "Vivo"
        Me.rdbVivo.UseVisualStyleBackColor = True
        '
        'frmVentasObservacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 212)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmVentasObservacion"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdbDesaparecido As RadioButton
    Friend WithEvents rdbMuerto As RadioButton
    Friend WithEvents rdbVivo As RadioButton
End Class
