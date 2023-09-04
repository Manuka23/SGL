<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiasBastoneo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiasBastoneo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.tipConteo = New System.Windows.Forms.ComboBox()
        Me.tipCentro = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.diastxt = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lista_usuarios = New System.Windows.Forms.ListView()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NOMBRE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(630, 48)
        Me.Panel1.TabIndex = 128
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(48, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(430, 33)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Modificacion Dias de Bastoneos"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Enabled = False
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(12, 339)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(93, 35)
        Me.btnFinalizar.TabIndex = 127
        Me.btnFinalizar.Text = "   Actualizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(431, 339)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(114, 35)
        Me.Button3.TabIndex = 126
        Me.Button3.Text = "Cerrar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.tipConteo)
        Me.GroupBox5.Controls.Add(Me.tipCentro)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.diastxt)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(533, 95)
        Me.GroupBox5.TabIndex = 125
        Me.GroupBox5.TabStop = False
        '
        'tipConteo
        '
        Me.tipConteo.FormattingEnabled = True
        Me.tipConteo.Location = New System.Drawing.Point(117, 62)
        Me.tipConteo.Name = "tipConteo"
        Me.tipConteo.Size = New System.Drawing.Size(98, 23)
        Me.tipConteo.TabIndex = 15
        '
        'tipCentro
        '
        Me.tipCentro.FormattingEnabled = True
        Me.tipCentro.Location = New System.Drawing.Point(118, 13)
        Me.tipCentro.Name = "tipCentro"
        Me.tipCentro.Size = New System.Drawing.Size(97, 23)
        Me.tipCentro.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 15)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Tipo Conteo"
        '
        'diastxt
        '
        Me.diastxt.Location = New System.Drawing.Point(321, 13)
        Me.diastxt.Name = "diastxt"
        Me.diastxt.Size = New System.Drawing.Size(173, 23)
        Me.diastxt.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Centro Tipo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(239, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dias habiles"
        '
        'lista_usuarios
        '
        Me.lista_usuarios.AutoArrange = False
        Me.lista_usuarios.BackColor = System.Drawing.SystemColors.Window
        Me.lista_usuarios.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.ColumnHeader2, Me.NOMBRE, Me.ColumnHeader1})
        Me.lista_usuarios.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lista_usuarios.FullRowSelect = True
        Me.lista_usuarios.GridLines = True
        Me.lista_usuarios.HideSelection = False
        Me.lista_usuarios.Location = New System.Drawing.Point(12, 156)
        Me.lista_usuarios.MultiSelect = False
        Me.lista_usuarios.Name = "lista_usuarios"
        Me.lista_usuarios.Size = New System.Drawing.Size(533, 177)
        Me.lista_usuarios.TabIndex = 137
        Me.lista_usuarios.UseCompatibleStateImageBehavior = False
        Me.lista_usuarios.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Tipo Centro"
        Me.ColumnHeader2.Width = 120
        '
        'NOMBRE
        '
        Me.NOMBRE.Text = "Tipo Conteo"
        Me.NOMBRE.Width = 200
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Dias Habiles"
        Me.ColumnHeader1.Width = 90
        '
        'frmDiasBastoneo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 383)
        Me.ControlBox = False
        Me.Controls.Add(Me.lista_usuarios)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox5)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiasBastoneo"
        Me.ShowInTaskbar = False
        Me.Text = "Dias Bastoneo"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label10 As Label

    Friend WithEvents btnFinalizar As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents tipConteo As ComboBox
    Friend WithEvents tipCentro As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents diastxt As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lista_usuarios As ListView
    Friend WithEvents ColumnHeader0 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents NOMBRE As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
