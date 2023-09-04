<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmActualizaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActualizaciones))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnOcultar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvMENSAJES = New System.Windows.Forms.ListView()
        Me.N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Informacion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tmrOcultar = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnOcultar)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.lvMENSAJES)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(908, 396)
        Me.GroupBox1.TabIndex = 132
        Me.GroupBox1.TabStop = False
        '
        'btnOcultar
        '
        Me.btnOcultar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOcultar.Image = CType(resources.GetObject("btnOcultar.Image"), System.Drawing.Image)
        Me.btnOcultar.Location = New System.Drawing.Point(811, 360)
        Me.btnOcultar.Name = "btnOcultar"
        Me.btnOcultar.Size = New System.Drawing.Size(87, 30)
        Me.btnOcultar.TabIndex = 134
        Me.btnOcultar.Text = "Ocultar"
        Me.btnOcultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOcultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOcultar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Maroon
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(9, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(889, 41)
        Me.Panel1.TabIndex = 132
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(881, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Ultimas Actualizaciones"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvMENSAJES
        '
        Me.lvMENSAJES.AutoArrange = False
        Me.lvMENSAJES.BackColor = System.Drawing.SystemColors.Window
        Me.lvMENSAJES.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.N, Me.Fecha, Me.ColumnHeader2, Me.Informacion})
        Me.lvMENSAJES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvMENSAJES.FullRowSelect = True
        Me.lvMENSAJES.GridLines = True
        Me.lvMENSAJES.HideSelection = False
        Me.lvMENSAJES.Location = New System.Drawing.Point(9, 60)
        Me.lvMENSAJES.MultiSelect = False
        Me.lvMENSAJES.Name = "lvMENSAJES"
        Me.lvMENSAJES.Size = New System.Drawing.Size(889, 293)
        Me.lvMENSAJES.TabIndex = 131
        Me.lvMENSAJES.UseCompatibleStateImageBehavior = False
        Me.lvMENSAJES.View = System.Windows.Forms.View.Details
        '
        'N
        '
        Me.N.Text = "N°"
        Me.N.Width = 37
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.Width = 88
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Modulo"
        Me.ColumnHeader2.Width = 90
        '
        'Informacion
        '
        Me.Informacion.Text = "Informacion"
        Me.Informacion.Width = 760
        '
        'tmrOcultar
        '
        Me.tmrOcultar.Interval = 5000
        '
        'frmActualizaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActualizaciones"
        Me.ShowInTaskbar = False
        Me.Text = "Actualizaciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnOcultar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents lvMENSAJES As ListView
    Friend WithEvents N As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents Informacion As ColumnHeader
    Friend WithEvents tmrOcultar As Timer
    Friend WithEvents ColumnHeader2 As ColumnHeader
End Class
