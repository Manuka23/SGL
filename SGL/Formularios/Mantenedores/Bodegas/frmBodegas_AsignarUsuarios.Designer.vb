<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBodegas_AsignarUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBodegas_AsignarUsuarios))
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.TxtCentros = New System.Windows.Forms.TextBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SelectT = New System.Windows.Forms.CheckBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
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
        Me.btnDefault = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltros = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(264, 61)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(110, 18)
        Me.CheckBox2.TabIndex = 228
        Me.CheckBox2.Text = "Solo asignados"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'TxtCentros
        '
        Me.TxtCentros.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCentros.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCentros.Location = New System.Drawing.Point(6, 16)
        Me.TxtCentros.Name = "TxtCentros"
        Me.TxtCentros.Size = New System.Drawing.Size(150, 27)
        Me.TxtCentros.TabIndex = 226
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(264, 37)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(120, 18)
        Me.CheckBox1.TabIndex = 223
        Me.CheckBox1.Text = "Quitar asignados"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'SelectT
        '
        Me.SelectT.AutoSize = True
        Me.SelectT.Enabled = False
        Me.SelectT.Location = New System.Drawing.Point(264, 13)
        Me.SelectT.Name = "SelectT"
        Me.SelectT.Size = New System.Drawing.Size(93, 18)
        Me.SelectT.TabIndex = 222
        Me.SelectT.Text = "Selec. Todos"
        Me.SelectT.UseVisualStyleBackColor = True
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(385, 16)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(150, 27)
        Me.txtUsuario.TabIndex = 221
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LvUsuarios)
        Me.GroupBox1.Controls.Add(Me.lvCentros)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 78)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(726, 331)
        Me.GroupBox1.TabIndex = 218
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Asignacion de Bodegas"
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
        Me.LvUsuarios.Location = New System.Drawing.Point(382, 27)
        Me.LvUsuarios.Name = "LvUsuarios"
        Me.LvUsuarios.Size = New System.Drawing.Size(335, 297)
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
        Me.lvCentros.Location = New System.Drawing.Point(6, 27)
        Me.lvCentros.Name = "lvCentros"
        Me.lvCentros.Size = New System.Drawing.Size(350, 297)
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
        Me.ColumnHeader5.Text = "Cod. Bodega"
        Me.ColumnHeader5.Width = 74
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nom. Bodega"
        Me.ColumnHeader1.Width = 119
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Bod.. Defect"
        Me.ColumnHeader8.Width = 71
        '
        'btnDefault
        '
        Me.btnDefault.Enabled = False
        Me.btnDefault.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDefault.Image = CType(resources.GetObject("btnDefault.Image"), System.Drawing.Image)
        Me.btnDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDefault.Location = New System.Drawing.Point(99, 415)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.Size = New System.Drawing.Size(130, 34)
        Me.btnDefault.TabIndex = 230
        Me.btnDefault.Text = "Bodega Default"
        Me.btnDefault.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(235, 415)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(113, 34)
        Me.btnEliminar.TabIndex = 229
        Me.btnEliminar.Text = "Remover Asig."
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(645, 417)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 32)
        Me.Button3.TabIndex = 227
        Me.Button3.Text = "Cerrar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(162, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 40)
        Me.Button1.TabIndex = 225
        Me.Button1.Text = "Buscar Bodegas"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(6, 415)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 34)
        Me.btnGrabar.TabIndex = 224
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltros
        '
        Me.btnLimpiarFiltros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltros.Image = CType(resources.GetObject("btnLimpiarFiltros.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiarFiltros.Location = New System.Drawing.Point(634, 16)
        Me.btnLimpiarFiltros.Name = "btnLimpiarFiltros"
        Me.btnLimpiarFiltros.Size = New System.Drawing.Size(98, 32)
        Me.btnLimpiarFiltros.TabIndex = 220
        Me.btnLimpiarFiltros.Text = "Borra Filtros"
        Me.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiarFiltros.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(541, 14)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 42)
        Me.btnBuscar.TabIndex = 219
        Me.btnBuscar.Text = "Buscar   Usuario"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'frmBodegas_AsignarUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 454)
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
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBodegas_AsignarUsuarios"
        Me.ShowInTaskbar = False
        Me.Text = "Asignacion de Bodegas"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnDefault As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Button3 As Button
    Friend WithEvents TxtCentros As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents btnGrabar As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents SelectT As CheckBox
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents btnLimpiarFiltros As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LvUsuarios As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents lvCentros As ListView
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
End Class
