<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRazas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRazas))
        Me.mnuVigente = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuInsemVigente = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsemQuitarVigente = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuInsemExterno = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInsemQuitarExterno = New System.Windows.Forms.ToolStripMenuItem()
        Me.LvlRazas = New System.Windows.Forms.ListView()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NOMBRE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.modificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.mnuVigente.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuVigente
        '
        Me.mnuVigente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInsemVigente, Me.mnuInsemQuitarVigente, Me.ToolStripMenuItem1, Me.mnuInsemExterno, Me.mnuInsemQuitarExterno})
        Me.mnuVigente.Name = "mnuVigente"
        Me.mnuVigente.Size = New System.Drawing.Size(151, 98)
        '
        'mnuInsemVigente
        '
        Me.mnuInsemVigente.Name = "mnuInsemVigente"
        Me.mnuInsemVigente.Size = New System.Drawing.Size(150, 22)
        Me.mnuInsemVigente.Text = "Vigente"
        '
        'mnuInsemQuitarVigente
        '
        Me.mnuInsemQuitarVigente.Name = "mnuInsemQuitarVigente"
        Me.mnuInsemQuitarVigente.Size = New System.Drawing.Size(150, 22)
        Me.mnuInsemQuitarVigente.Text = "Quitar Vigente"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(147, 6)
        '
        'mnuInsemExterno
        '
        Me.mnuInsemExterno.Name = "mnuInsemExterno"
        Me.mnuInsemExterno.Size = New System.Drawing.Size(150, 22)
        Me.mnuInsemExterno.Text = "Externo"
        '
        'mnuInsemQuitarExterno
        '
        Me.mnuInsemQuitarExterno.Name = "mnuInsemQuitarExterno"
        Me.mnuInsemQuitarExterno.Size = New System.Drawing.Size(150, 22)
        Me.mnuInsemQuitarExterno.Text = "Quitar Externo"
        '
        'LvlRazas
        '
        Me.LvlRazas.AutoArrange = False
        Me.LvlRazas.BackColor = System.Drawing.SystemColors.Window
        Me.LvlRazas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.ColumnHeader2, Me.NOMBRE, Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.LvlRazas.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvlRazas.FullRowSelect = True
        Me.LvlRazas.GridLines = True
        Me.LvlRazas.HideSelection = False
        Me.LvlRazas.Location = New System.Drawing.Point(12, 67)
        Me.LvlRazas.MultiSelect = False
        Me.LvlRazas.Name = "LvlRazas"
        Me.LvlRazas.Size = New System.Drawing.Size(543, 348)
        Me.LvlRazas.TabIndex = 143
        Me.LvlRazas.UseCompatibleStateImageBehavior = False
        Me.LvlRazas.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Codigo"
        Me.ColumnHeader2.Width = 52
        '
        'NOMBRE
        '
        Me.NOMBRE.Text = "Nombre Raza"
        Me.NOMBRE.Width = 215
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Vigente"
        Me.ColumnHeader1.Width = 66
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Peso Cria"
        Me.ColumnHeader3.Width = 71
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Abrev."
        Me.ColumnHeader4.Width = 58
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(565, 61)
        Me.Panel1.TabIndex = 147
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(53, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(432, 31)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "RAZAS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(291, 421)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(97, 30)
        Me.btnFinalizar.TabIndex = 146
        Me.btnFinalizar.Text = "  Activar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(198, 421)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 145
        Me.btnEliminar.Text = "Desactivar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'modificar
        '
        Me.modificar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modificar.Image = CType(resources.GetObject("modificar.Image"), System.Drawing.Image)
        Me.modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.modificar.Location = New System.Drawing.Point(105, 421)
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(87, 30)
        Me.modificar.TabIndex = 144
        Me.modificar.Text = "  Modificar"
        Me.modificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 421)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 142
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(468, 421)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 140
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmRazas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.modificar)
        Me.Controls.Add(Me.LvlRazas)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnSalir)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRazas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " Mantenedor Razas"
        Me.mnuVigente.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents mnuVigente As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuInsemVigente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInsemQuitarVigente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuInsemExterno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInsemQuitarExterno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents modificar As Button
    Friend WithEvents LvlRazas As ListView
    Friend WithEvents ColumnHeader0 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents NOMBRE As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
End Class
