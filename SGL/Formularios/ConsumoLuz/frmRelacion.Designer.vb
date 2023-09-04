<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRelacion
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
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.modificar = New System.Windows.Forms.Button()
        Me.lvRelacion = New System.Windows.Forms.ListView()
        Me.Cod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = Global.SGL.My.Resources.Resources.delete
        Me.btnEliminar.Location = New System.Drawing.Point(198, 420)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 147
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'modificar
        '
        Me.modificar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modificar.Image = Global.SGL.My.Resources.Resources.page_edit
        Me.modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.modificar.Location = New System.Drawing.Point(105, 420)
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(87, 30)
        Me.modificar.TabIndex = 146
        Me.modificar.Text = "Modificar"
        Me.modificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.modificar.UseVisualStyleBackColor = True
        '
        'lvRelacion
        '
        Me.lvRelacion.AutoArrange = False
        Me.lvRelacion.BackColor = System.Drawing.SystemColors.Window
        Me.lvRelacion.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Cod, Me.Nom})
        Me.lvRelacion.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRelacion.FullRowSelect = True
        Me.lvRelacion.GridLines = True
        Me.lvRelacion.HideSelection = False
        Me.lvRelacion.Location = New System.Drawing.Point(12, 63)
        Me.lvRelacion.MultiSelect = False
        Me.lvRelacion.Name = "lvRelacion"
        Me.lvRelacion.Size = New System.Drawing.Size(524, 348)
        Me.lvRelacion.TabIndex = 144
        Me.lvRelacion.UseCompatibleStateImageBehavior = False
        Me.lvRelacion.View = System.Windows.Forms.View.Details
        '
        'Cod
        '
        Me.Cod.Text = "Codigo"
        '
        'Nom
        '
        Me.Nom.Text = "Descripcion"
        Me.Nom.Width = 332
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-127, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(970, 61)
        Me.Panel1.TabIndex = 143
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(182, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(432, 31)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Relacion con la Empresa"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SGL.My.Resources.Resources.door_out
        Me.btnSalir.Location = New System.Drawing.Point(449, 420)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 142
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.SGL.My.Resources.Resources.add
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 420)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 145
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'frmRelacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 460)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.modificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lvRelacion)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRelacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Relacion con la Empresa"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnEliminar As Button
    Friend WithEvents modificar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents lvRelacion As ListView
    Friend WithEvents Cod As ColumnHeader
    Friend WithEvents Nom As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSalir As Button
End Class
