<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlLecheroDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlLecheroDetalle))
        Me.lvControlLecheroDetalle = New System.Windows.Forms.ListView()
        Me.N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaControl = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Diio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Categoría = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RCS = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Grasa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Proteína = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaPP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaNac = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvControlLecheroDetalle
        '
        Me.lvControlLecheroDetalle.AutoArrange = False
        Me.lvControlLecheroDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvControlLecheroDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.N, Me.CentroNom, Me.FechaControl, Me.Diio, Me.Categoría, Me.RCS, Me.Grasa, Me.Proteína, Me.FechaPP, Me.FechaNac})
        Me.lvControlLecheroDetalle.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvControlLecheroDetalle.FullRowSelect = True
        Me.lvControlLecheroDetalle.GridLines = True
        Me.lvControlLecheroDetalle.HideSelection = False
        Me.lvControlLecheroDetalle.Location = New System.Drawing.Point(13, 57)
        Me.lvControlLecheroDetalle.Name = "lvControlLecheroDetalle"
        Me.lvControlLecheroDetalle.Size = New System.Drawing.Size(1250, 494)
        Me.lvControlLecheroDetalle.TabIndex = 0
        Me.lvControlLecheroDetalle.UseCompatibleStateImageBehavior = False
        Me.lvControlLecheroDetalle.View = System.Windows.Forms.View.Details
        '
        'N
        '
        Me.N.Text = "N°"
        Me.N.Width = 37
        '
        'CentroNom
        '
        Me.CentroNom.Text = "Centro"
        Me.CentroNom.Width = 217
        '
        'FechaControl
        '
        Me.FechaControl.Text = "Fecha Control"
        Me.FechaControl.Width = 158
        '
        'Diio
        '
        Me.Diio.Text = "Diio"
        Me.Diio.Width = 115
        '
        'Categoría
        '
        Me.Categoría.Text = "Categoria"
        Me.Categoría.Width = 112
        '
        'RCS
        '
        Me.RCS.Text = "RCS"
        Me.RCS.Width = 83
        '
        'Grasa
        '
        Me.Grasa.Text = "%Grasa"
        Me.Grasa.Width = 57
        '
        'Proteína
        '
        Me.Proteína.Text = "%proteina"
        Me.Proteína.Width = 76
        '
        'FechaPP
        '
        Me.FechaPP.Text = "Fec Post Parto"
        Me.FechaPP.Width = 111
        '
        'FechaNac
        '
        Me.FechaNac.Text = "Fecha Nacimiento"
        Me.FechaNac.Width = 137
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1325, 51)
        Me.Panel1.TabIndex = 233
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1301, 36)
        Me.Label3.TabIndex = 234
        Me.Label3.Text = "Detalle Control Lechero"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1176, 557)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 37)
        Me.btnSalir.TabIndex = 234
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmControlLecheroDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1275, 606)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lvControlLecheroDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmControlLecheroDetalle"
        Me.ShowInTaskbar = False
        Me.Text = "DETALLE CONTROL LECHERO"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvControlLecheroDetalle As ListView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents N As ColumnHeader
    Friend WithEvents CentroNom As ColumnHeader
    Friend WithEvents FechaControl As ColumnHeader
    Friend WithEvents Diio As ColumnHeader
    Friend WithEvents Categoría As ColumnHeader
    Friend WithEvents RCS As ColumnHeader
    Friend WithEvents Grasa As ColumnHeader
    Friend WithEvents Proteína As ColumnHeader
    Friend WithEvents FechaPP As ColumnHeader
    Friend WithEvents FechaNac As ColumnHeader
End Class
