<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignacionCentrosUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignacionCentrosUsuarios))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LvUsuarios = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvCentros = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.SelectT = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.TxtCentros = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnDefault = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LvUsuarios)
        Me.GroupBox1.Controls.Add(Me.lvCentros)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(726, 307)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Asignacion de Centros"
        '
        'LvUsuarios
        '
        Me.LvUsuarios.AutoArrange = False
        Me.LvUsuarios.BackColor = System.Drawing.SystemColors.Window
        Me.LvUsuarios.CheckBoxes = True
        Me.LvUsuarios.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.LvUsuarios.FullRowSelect = True
        Me.LvUsuarios.GridLines = True
        Me.LvUsuarios.HideSelection = False
        Me.LvUsuarios.Location = New System.Drawing.Point(382, 25)
        Me.LvUsuarios.Name = "LvUsuarios"
        Me.LvUsuarios.Size = New System.Drawing.Size(335, 276)
        Me.LvUsuarios.TabIndex = 129
        Me.LvUsuarios.UseCompatibleStateImageBehavior = False
        Me.LvUsuarios.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 32
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Nro"
        Me.ColumnHeader4.Width = 44
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Cod. Usuario"
        Me.ColumnHeader6.Width = 105
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Nom. Usuario"
        Me.ColumnHeader7.Width = 150
        '
        'lvCentros
        '
        Me.lvCentros.AutoArrange = False
        Me.lvCentros.BackColor = System.Drawing.SystemColors.Window
        Me.lvCentros.CheckBoxes = True
        Me.lvCentros.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader1, Me.ColumnHeader8})
        Me.lvCentros.Enabled = False
        Me.lvCentros.FullRowSelect = True
        Me.lvCentros.GridLines = True
        Me.lvCentros.HideSelection = False
        Me.lvCentros.Location = New System.Drawing.Point(6, 25)
        Me.lvCentros.Name = "lvCentros"
        Me.lvCentros.Size = New System.Drawing.Size(350, 276)
        Me.lvCentros.TabIndex = 128
        Me.lvCentros.UseCompatibleStateImageBehavior = False
        Me.lvCentros.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = ""
        Me.ColumnHeader9.Width = 32
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Nro"
        Me.ColumnHeader2.Width = 44
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Cod. Centro"
        Me.ColumnHeader5.Width = 93
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nom. Centro"
        Me.ColumnHeader1.Width = 119
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Cent. Defect"
        Me.ColumnHeader8.Width = 71
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(540, 12)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 39)
        Me.btnBuscar.TabIndex = 142
        Me.btnBuscar.Text = "Buscar   Usuario"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(633, 14)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(98, 30)
        Me.btnLimpiarFiltros.TabIndex = 206
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(384, 14)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(150, 27)
        Me.txtUsuario.TabIndex = 207
        '
        'SelectT
        '
        Me.SelectT.AutoSize = True
        Me.SelectT.Enabled = False
        Me.SelectT.Location = New System.Drawing.Point(263, 11)
        Me.SelectT.Name = "SelectT"
        Me.SelectT.Size = New System.Drawing.Size(115, 17)
        Me.SelectT.TabIndex = 209
        Me.SelectT.Text = "Seleccionar Todos"
        Me.SelectT.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(263, 33)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(105, 17)
        Me.CheckBox1.TabIndex = 210
        Me.CheckBox1.Text = "Quitar asignados"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(5, 384)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 32)
        Me.btnGrabar.TabIndex = 211
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'TxtCentros
        '
        Me.TxtCentros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCentros.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCentros.Location = New System.Drawing.Point(5, 14)
        Me.TxtCentros.Name = "TxtCentros"
        Me.TxtCentros.Size = New System.Drawing.Size(150, 27)
        Me.TxtCentros.TabIndex = 213
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(161, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 37)
        Me.Button1.TabIndex = 212
        Me.Button1.Text = "Buscar Centro"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(644, 386)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 30)
        Me.Button3.TabIndex = 214
        Me.Button3.Text = "Cerrar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(263, 56)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(98, 17)
        Me.CheckBox2.TabIndex = 215
        Me.CheckBox2.Text = "Solo asignados"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(225, 384)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(117, 32)
        Me.btnEliminar.TabIndex = 216
        Me.btnEliminar.Text = "Remover centro"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnDefault
        '
        Me.btnDefault.Enabled = False
        Me.btnDefault.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDefault.Image = CType(resources.GetObject("btnDefault.Image"), System.Drawing.Image)
        Me.btnDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDefault.Location = New System.Drawing.Point(98, 384)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.Size = New System.Drawing.Size(121, 32)
        Me.btnDefault.TabIndex = 217
        Me.btnDefault.Text = "Centro Default"
        Me.btnDefault.UseVisualStyleBackColor = True
        '
        'frmAsignacionCentrosUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 422)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnDefault)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TxtCentros)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.SelectT)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.btnLimpiarFiltros)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAsignacionCentrosUsuarios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Asignacion de Centros"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnLimpiarFiltros As Button
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents lvCentros As ListView
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents LvUsuarios As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents SelectT As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents TxtCentros As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnDefault As Button
End Class
