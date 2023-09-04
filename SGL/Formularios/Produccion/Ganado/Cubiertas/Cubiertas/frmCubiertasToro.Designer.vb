<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCubiertasToros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCubiertasToros))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.chkIATF = New System.Windows.Forms.CheckBox()
        Me.txtNroDosis = New System.Windows.Forms.TextBox()
        Me.cboInseminadores = New System.Windows.Forms.ComboBox()
        Me.cboToros = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 21)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "Inseminador"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(11, 58)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 21)
        Me.Label15.TabIndex = 110
        Me.Label15.Text = "Toro"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(11, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 21)
        Me.Label16.TabIndex = 111
        Me.Label16.Text = "Dosis"
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(8, 139)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(82, 30)
        Me.btnGrabar.TabIndex = 132
        Me.btnGrabar.Text = "  Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(239, 139)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 134
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'chkIATF
        '
        Me.chkIATF.AutoSize = True
        Me.chkIATF.Location = New System.Drawing.Point(249, 94)
        Me.chkIATF.Name = "chkIATF"
        Me.chkIATF.Size = New System.Drawing.Size(56, 22)
        Me.chkIATF.TabIndex = 138
        Me.chkIATF.Text = "CIDR"
        Me.chkIATF.UseVisualStyleBackColor = True
        Me.chkIATF.Visible = False
        '
        'txtNroDosis
        '
        Me.txtNroDosis.Enabled = False
        Me.txtNroDosis.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroDosis.Location = New System.Drawing.Point(102, 90)
        Me.txtNroDosis.MaxLength = 2
        Me.txtNroDosis.Name = "txtNroDosis"
        Me.txtNroDosis.Size = New System.Drawing.Size(34, 26)
        Me.txtNroDosis.TabIndex = 137
        Me.txtNroDosis.Text = "1"
        Me.txtNroDosis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboInseminadores
        '
        Me.cboInseminadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInseminadores.FormattingEnabled = True
        Me.cboInseminadores.Location = New System.Drawing.Point(102, 25)
        Me.cboInseminadores.Name = "cboInseminadores"
        Me.cboInseminadores.Size = New System.Drawing.Size(200, 26)
        Me.cboInseminadores.TabIndex = 135
        '
        'cboToros
        '
        Me.cboToros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToros.FormattingEnabled = True
        Me.cboToros.Location = New System.Drawing.Point(102, 58)
        Me.cboToros.Name = "cboToros"
        Me.cboToros.Size = New System.Drawing.Size(200, 26)
        Me.cboToros.TabIndex = 136
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboInseminadores)
        Me.GroupBox5.Controls.Add(Me.chkIATF)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.txtNroDosis)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.cboToros)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(318, 130)
        Me.GroupBox5.TabIndex = 139
        Me.GroupBox5.TabStop = False
        '
        'FrmCubiertasToros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 177)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCubiertasToros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio Datos Inseminación"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents chkIATF As System.Windows.Forms.CheckBox
    Friend WithEvents txtNroDosis As System.Windows.Forms.TextBox
    Friend WithEvents cboInseminadores As System.Windows.Forms.ComboBox
    Friend WithEvents cboToros As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
End Class
