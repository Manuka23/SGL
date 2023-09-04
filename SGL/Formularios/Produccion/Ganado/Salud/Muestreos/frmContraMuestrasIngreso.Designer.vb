<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContraMuestrasIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContraMuestrasIngreso))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboTiposMuestras = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaResult = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboResultadoMuestra = New System.Windows.Forms.ComboBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(297, 122)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 134
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboTiposMuestras)
        Me.GroupBox1.Location = New System.Drawing.Point(129, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(258, 50)
        Me.GroupBox1.TabIndex = 133
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Muestra"
        '
        'cboTiposMuestras
        '
        Me.cboTiposMuestras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTiposMuestras.FormattingEnabled = True
        Me.cboTiposMuestras.Items.AddRange(New Object() {"TUBERCULOSIS", "LEUCOSIS", "BRUCELOSIS"})
        Me.cboTiposMuestras.Location = New System.Drawing.Point(13, 19)
        Me.cboTiposMuestras.Name = "cboTiposMuestras"
        Me.cboTiposMuestras.Size = New System.Drawing.Size(234, 21)
        Me.cboTiposMuestras.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtpFechaResult)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(115, 50)
        Me.GroupBox4.TabIndex = 132
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fecha Resultado"
        '
        'dtpFechaResult
        '
        Me.dtpFechaResult.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaResult.Location = New System.Drawing.Point(15, 19)
        Me.dtpFechaResult.Name = "dtpFechaResult"
        Me.dtpFechaResult.Size = New System.Drawing.Size(87, 20)
        Me.dtpFechaResult.TabIndex = 54
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboResultadoMuestra)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(379, 50)
        Me.GroupBox2.TabIndex = 135
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Resultado Muestra"
        '
        'cboResultadoMuestra
        '
        Me.cboResultadoMuestra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResultadoMuestra.FormattingEnabled = True
        Me.cboResultadoMuestra.Items.AddRange(New Object() {"POSITIVO", "NEGATIVO"})
        Me.cboResultadoMuestra.Location = New System.Drawing.Point(13, 19)
        Me.cboResultadoMuestra.Name = "cboResultadoMuestra"
        Me.cboResultadoMuestra.Size = New System.Drawing.Size(355, 21)
        Me.cboResultadoMuestra.TabIndex = 0
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(8, 122)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 30)
        Me.btnGrabar.TabIndex = 136
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'frmContraMuestrasIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 159)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContraMuestrasIngreso"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Contra Muestra"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTiposMuestras As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaResult As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboResultadoMuestra As System.Windows.Forms.ComboBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
End Class
