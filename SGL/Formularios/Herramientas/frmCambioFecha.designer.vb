<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioFecha
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambioFecha))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.gboxFecha = New System.Windows.Forms.GroupBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.gboxObservs = New System.Windows.Forms.GroupBox()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.MenuGanado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopiarDiio = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.gboxFecha.SuspendLayout()
        Me.gboxObservs.SuspendLayout()
        Me.MenuGanado.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(671, 149)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(13, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(109, 26)
        Me.dtpFecha.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(309, 57)
        Me.GroupBox1.TabIndex = 90
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(11, 20)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(282, 26)
        Me.cboCentros.TabIndex = 1
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(105, 151)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        Me.btnEliminar.Visible = False
        '
        'gboxFecha
        '
        Me.gboxFecha.Controls.Add(Me.dtpFecha)
        Me.gboxFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxFecha.Location = New System.Drawing.Point(327, 8)
        Me.gboxFecha.Name = "gboxFecha"
        Me.gboxFecha.Size = New System.Drawing.Size(134, 57)
        Me.gboxFecha.TabIndex = 98
        Me.gboxFecha.TabStop = False
        Me.gboxFecha.Text = "Fecha"
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(12, 151)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 30)
        Me.btnGrabar.TabIndex = 4
        Me.btnGrabar.Text = "   Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'gboxObservs
        '
        Me.gboxObservs.Controls.Add(Me.txtObservs)
        Me.gboxObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxObservs.Location = New System.Drawing.Point(12, 65)
        Me.gboxObservs.Name = "gboxObservs"
        Me.gboxObservs.Size = New System.Drawing.Size(746, 78)
        Me.gboxObservs.TabIndex = 123
        Me.gboxObservs.TabStop = False
        Me.gboxObservs.Text = "Observación para el grupo de DIIOs"
        '
        'txtObservs
        '
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(13, 23)
        Me.txtObservs.MaxLength = 500
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(719, 43)
        Me.txtObservs.TabIndex = 3
        '
        'MenuGanado
        '
        Me.MenuGanado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVerDetalle, Me.ToolStripMenuItem1, Me.mnuCopiarDiio})
        Me.MenuGanado.Name = "MenuGanado"
        Me.MenuGanado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuGanado.Size = New System.Drawing.Size(219, 54)
        '
        'mnuVerDetalle
        '
        Me.mnuVerDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuVerDetalle.Name = "mnuVerDetalle"
        Me.mnuVerDetalle.Size = New System.Drawing.Size(218, 22)
        Me.mnuVerDetalle.Text = "Ver Detalle DIIO"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(215, 6)
        '
        'mnuCopiarDiio
        '
        Me.mnuCopiarDiio.Name = "mnuCopiarDiio"
        Me.mnuCopiarDiio.Size = New System.Drawing.Size(218, 22)
        Me.mnuCopiarDiio.Text = "Copiar DIIO al portapapeles"
        '
        'frmCambioFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 192)
        Me.ContextMenuStrip = Me.MenuGanado
        Me.ControlBox = False
        Me.Controls.Add(Me.gboxObservs)
        Me.Controls.Add(Me.gboxFecha)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCambioFecha"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modificación Cubierta"
        Me.GroupBox1.ResumeLayout(False)
        Me.gboxFecha.ResumeLayout(False)
        Me.gboxObservs.ResumeLayout(False)
        Me.gboxObservs.PerformLayout()
        Me.MenuGanado.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents gboxFecha As System.Windows.Forms.GroupBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents gboxObservs As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservs As System.Windows.Forms.TextBox
    Friend WithEvents MenuGanado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCopiarDiio As System.Windows.Forms.ToolStripMenuItem
End Class
