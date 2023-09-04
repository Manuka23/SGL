<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCasa
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
        Me.lvCasas = New System.Windows.Forms.ListView()
        Me.Casa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Sitio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Medidor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodCentro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Centro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodResponsdable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Responsable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Clasificacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Poblacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Relacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodCalsificacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodPoblacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodRelacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = Global.SGL.My.Resources.Resources.delete
        Me.btnEliminar.Location = New System.Drawing.Point(197, 519)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 136
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
        Me.modificar.Location = New System.Drawing.Point(104, 519)
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(87, 30)
        Me.modificar.TabIndex = 135
        Me.modificar.Text = "Modificar"
        Me.modificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.modificar.UseVisualStyleBackColor = True
        '
        'lvCasas
        '
        Me.lvCasas.AutoArrange = False
        Me.lvCasas.BackColor = System.Drawing.SystemColors.Window
        Me.lvCasas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Casa, Me.Sitio, Me.Medidor, Me.CodCentro, Me.Centro, Me.CodResponsdable, Me.Responsable, Me.Clasificacion, Me.Poblacion, Me.Relacion, Me.CodCalsificacion, Me.CodPoblacion, Me.CodRelacion})
        Me.lvCasas.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCasas.FullRowSelect = True
        Me.lvCasas.GridLines = True
        Me.lvCasas.HideSelection = False
        Me.lvCasas.Location = New System.Drawing.Point(11, 86)
        Me.lvCasas.MultiSelect = False
        Me.lvCasas.Name = "lvCasas"
        Me.lvCasas.Size = New System.Drawing.Size(861, 427)
        Me.lvCasas.TabIndex = 134
        Me.lvCasas.UseCompatibleStateImageBehavior = False
        Me.lvCasas.View = System.Windows.Forms.View.Details
        '
        'Casa
        '
        Me.Casa.Text = "Casa"
        Me.Casa.Width = 50
        '
        'Sitio
        '
        Me.Sitio.Text = "Sitio"
        Me.Sitio.Width = 50
        '
        'Medidor
        '
        Me.Medidor.Text = "Cod medidor"
        Me.Medidor.Width = 86
        '
        'CodCentro
        '
        Me.CodCentro.Text = "Cod centro"
        Me.CodCentro.Width = 1
        '
        'Centro
        '
        Me.Centro.Text = "Centro"
        Me.Centro.Width = 120
        '
        'CodResponsdable
        '
        Me.CodResponsdable.Text = "Cod responsable"
        Me.CodResponsdable.Width = 1
        '
        'Responsable
        '
        Me.Responsable.Text = "Responsable"
        Me.Responsable.Width = 120
        '
        'Clasificacion
        '
        Me.Clasificacion.Text = "Clasificacion"
        Me.Clasificacion.Width = 120
        '
        'Poblacion
        '
        Me.Poblacion.Text = "Poblacion"
        Me.Poblacion.Width = 120
        '
        'Relacion
        '
        Me.Relacion.Text = "Relacion"
        Me.Relacion.Width = 120
        '
        'CodCalsificacion
        '
        Me.CodCalsificacion.Text = "Cod clasificacion"
        Me.CodCalsificacion.Width = 1
        '
        'CodPoblacion
        '
        Me.CodPoblacion.Text = "Cod problacion"
        Me.CodPoblacion.Width = 1
        '
        'CodRelacion
        '
        Me.CodRelacion.Text = "Cod relacion"
        Me.CodRelacion.Width = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.SGL.My.Resources.Resources.add
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(11, 519)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 133
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1072, 70)
        Me.Panel1.TabIndex = 132
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(203, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(432, 31)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Casas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SGL.My.Resources.Resources.door_out
        Me.btnSalir.Location = New System.Drawing.Point(785, 519)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 131
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmCasa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 555)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.modificar)
        Me.Controls.Add(Me.lvCasas)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCasa"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Casas"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnEliminar As Button
    Friend WithEvents modificar As Button
    Friend WithEvents lvCasas As ListView
    Friend WithEvents Casa As ColumnHeader
    Friend WithEvents Sitio As ColumnHeader
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents Medidor As ColumnHeader
    Friend WithEvents Centro As ColumnHeader
    Friend WithEvents Clasificacion As ColumnHeader
    Friend WithEvents Poblacion As ColumnHeader
    Friend WithEvents Relacion As ColumnHeader
    Friend WithEvents Responsable As ColumnHeader
    Friend WithEvents CodCentro As ColumnHeader
    Friend WithEvents CodResponsdable As ColumnHeader
    Friend WithEvents CodCalsificacion As ColumnHeader
    Friend WithEvents CodPoblacion As ColumnHeader
    Friend WithEvents CodRelacion As ColumnHeader
End Class
