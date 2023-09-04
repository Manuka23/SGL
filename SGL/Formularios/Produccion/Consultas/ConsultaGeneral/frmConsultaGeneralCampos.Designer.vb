<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaGeneralCampos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaGeneralCampos))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnPerfil = New System.Windows.Forms.Button()
        Me.cboPerfilesColumnas = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnEliminarPerfil = New System.Windows.Forms.Button()
        Me.btnAgregarPerfil = New System.Windows.Forms.Button()
        Me.txtNombrePerfil = New System.Windows.Forms.TextBox()
        Me.lvCOLUMNAS = New System.Windows.Forms.ListView()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCOLPERFILES = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnEC = New System.Windows.Forms.Button()
        Me.btnAC = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(707, 385)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnSalir, "Cerrar ventana")
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnPerfil
        '
        Me.btnPerfil.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPerfil.Image = CType(resources.GetObject("btnPerfil.Image"), System.Drawing.Image)
        Me.btnPerfil.Location = New System.Drawing.Point(291, 24)
        Me.btnPerfil.Name = "btnPerfil"
        Me.btnPerfil.Size = New System.Drawing.Size(32, 28)
        Me.btnPerfil.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnPerfil, "Nuevo Perfil")
        Me.btnPerfil.UseVisualStyleBackColor = True
        '
        'cboPerfilesColumnas
        '
        Me.cboPerfilesColumnas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPerfilesColumnas.Enabled = False
        Me.cboPerfilesColumnas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPerfilesColumnas.FormattingEnabled = True
        Me.cboPerfilesColumnas.Location = New System.Drawing.Point(15, 25)
        Me.cboPerfilesColumnas.Name = "cboPerfilesColumnas"
        Me.cboPerfilesColumnas.Size = New System.Drawing.Size(269, 26)
        Me.cboPerfilesColumnas.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPerfilesColumnas)
        Me.GroupBox1.Controls.Add(Me.btnEliminarPerfil)
        Me.GroupBox1.Controls.Add(Me.btnAgregarPerfil)
        Me.GroupBox1.Controls.Add(Me.txtNombrePerfil)
        Me.GroupBox1.Controls.Add(Me.btnPerfil)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(397, 66)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Perfil de columna"
        '
        'btnEliminarPerfil
        '
        Me.btnEliminarPerfil.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarPerfil.Image = CType(resources.GetObject("btnEliminarPerfil.Image"), System.Drawing.Image)
        Me.btnEliminarPerfil.Location = New System.Drawing.Point(355, 24)
        Me.btnEliminarPerfil.Name = "btnEliminarPerfil"
        Me.btnEliminarPerfil.Size = New System.Drawing.Size(32, 28)
        Me.btnEliminarPerfil.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnEliminarPerfil, "Eliminar Perfil")
        Me.btnEliminarPerfil.UseVisualStyleBackColor = True
        '
        'btnAgregarPerfil
        '
        Me.btnAgregarPerfil.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarPerfil.Image = CType(resources.GetObject("btnAgregarPerfil.Image"), System.Drawing.Image)
        Me.btnAgregarPerfil.Location = New System.Drawing.Point(323, 24)
        Me.btnAgregarPerfil.Name = "btnAgregarPerfil"
        Me.btnAgregarPerfil.Size = New System.Drawing.Size(32, 28)
        Me.btnAgregarPerfil.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnAgregarPerfil, "Grabar Perfil")
        Me.btnAgregarPerfil.UseVisualStyleBackColor = True
        '
        'txtNombrePerfil
        '
        Me.txtNombrePerfil.Enabled = False
        Me.txtNombrePerfil.Location = New System.Drawing.Point(15, 25)
        Me.txtNombrePerfil.Name = "txtNombrePerfil"
        Me.txtNombrePerfil.Size = New System.Drawing.Size(269, 26)
        Me.txtNombrePerfil.TabIndex = 1
        '
        'lvCOLUMNAS
        '
        Me.lvCOLUMNAS.AllowColumnReorder = True
        Me.lvCOLUMNAS.AllowDrop = True
        Me.lvCOLUMNAS.AutoArrange = False
        Me.lvCOLUMNAS.BackColor = System.Drawing.SystemColors.Window
        Me.lvCOLUMNAS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.ColumnHeader3, Me.ColumnHeader5})
        Me.lvCOLUMNAS.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCOLUMNAS.FullRowSelect = True
        Me.lvCOLUMNAS.GridLines = True
        Me.lvCOLUMNAS.HideSelection = False
        Me.lvCOLUMNAS.LabelWrap = False
        Me.lvCOLUMNAS.Location = New System.Drawing.Point(415, 22)
        Me.lvCOLUMNAS.MultiSelect = False
        Me.lvCOLUMNAS.Name = "lvCOLUMNAS"
        Me.lvCOLUMNAS.Size = New System.Drawing.Size(379, 355)
        Me.lvCOLUMNAS.TabIndex = 6
        Me.lvCOLUMNAS.UseCompatibleStateImageBehavior = False
        Me.lvCOLUMNAS.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.Width = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Columna"
        Me.ColumnHeader3.Width = 300
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Ancho"
        Me.ColumnHeader5.Width = 0
        '
        'lvCOLPERFILES
        '
        Me.lvCOLPERFILES.AllowColumnReorder = True
        Me.lvCOLPERFILES.AllowDrop = True
        Me.lvCOLPERFILES.AutoArrange = False
        Me.lvCOLPERFILES.BackColor = System.Drawing.SystemColors.Window
        Me.lvCOLPERFILES.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader4})
        Me.lvCOLPERFILES.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCOLPERFILES.FullRowSelect = True
        Me.lvCOLPERFILES.GridLines = True
        Me.lvCOLPERFILES.HideSelection = False
        Me.lvCOLPERFILES.LabelWrap = False
        Me.lvCOLPERFILES.Location = New System.Drawing.Point(12, 84)
        Me.lvCOLPERFILES.MultiSelect = False
        Me.lvCOLPERFILES.Name = "lvCOLPERFILES"
        Me.lvCOLPERFILES.Size = New System.Drawing.Size(397, 293)
        Me.lvCOLPERFILES.TabIndex = 5
        Me.lvCOLPERFILES.UseCompatibleStateImageBehavior = False
        Me.lvCOLPERFILES.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nro"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Columna"
        Me.ColumnHeader2.Width = 320
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Ancho"
        Me.ColumnHeader4.Width = 0
        '
        'btnEC
        '
        Me.btnEC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEC.Image = CType(resources.GetObject("btnEC.Image"), System.Drawing.Image)
        Me.btnEC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEC.Location = New System.Drawing.Point(12, 385)
        Me.btnEC.Name = "btnEC"
        Me.btnEC.Size = New System.Drawing.Size(137, 30)
        Me.btnEC.TabIndex = 98
        Me.btnEC.Text = "   Eliminar Columna"
        Me.ToolTip1.SetToolTip(Me.btnEC, "Eliminar columna del perfil")
        Me.btnEC.UseVisualStyleBackColor = True
        '
        'btnAC
        '
        Me.btnAC.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAC.Image = CType(resources.GetObject("btnAC.Image"), System.Drawing.Image)
        Me.btnAC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAC.Location = New System.Drawing.Point(415, 385)
        Me.btnAC.Name = "btnAC"
        Me.btnAC.Size = New System.Drawing.Size(138, 30)
        Me.btnAC.TabIndex = 99
        Me.btnAC.Text = "   Agregar Columna"
        Me.ToolTip1.SetToolTip(Me.btnAC, "Agregar columna al perfil")
        Me.btnAC.UseVisualStyleBackColor = True
        '
        'frmConsultaGeneralCampos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(806, 424)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAC)
        Me.Controls.Add(Me.btnEC)
        Me.Controls.Add(Me.lvCOLPERFILES)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvCOLUMNAS)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaGeneralCampos"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de Campos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnPerfil As System.Windows.Forms.Button
    Friend WithEvents cboPerfilesColumnas As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lvCOLUMNAS As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtNombrePerfil As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregarPerfil As System.Windows.Forms.Button
    Friend WithEvents btnEliminarPerfil As System.Windows.Forms.Button
    Friend WithEvents lvCOLPERFILES As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnEC As System.Windows.Forms.Button
    Friend WithEvents btnAC As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
