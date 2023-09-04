<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMensajesOLD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMensajesOLD))
        Me.tmrOcultar = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvMENSAJES = New System.Windows.Forms.ListView()
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnMensajes = New System.Windows.Forms.Button()
        Me.btnMarcar = New System.Windows.Forms.Button()
        Me.btnOcultar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrOcultar
        '
        Me.tmrOcultar.Interval = 500000
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMarcar)
        Me.GroupBox1.Controls.Add(Me.chkTodos)
        Me.GroupBox1.Controls.Add(Me.btnOcultar)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.lvMENSAJES)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(908, 396)
        Me.GroupBox1.TabIndex = 131
        Me.GroupBox1.TabStop = False
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(15, 67)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(15, 14)
        Me.chkTodos.TabIndex = 135
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
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
        Me.Label3.Text = "MENSAJES PENDIENTES (0)"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvMENSAJES
        '
        Me.lvMENSAJES.AutoArrange = False
        Me.lvMENSAJES.BackColor = System.Drawing.SystemColors.Window
        Me.lvMENSAJES.CheckBoxes = True
        Me.lvMENSAJES.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader13, Me.ColumnHeader0, Me.ColumnHeader2, Me.ColumnHeader1, Me.ColumnHeader9, Me.ColumnHeader5, Me.ColumnHeader4, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader8})
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
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = ""
        Me.ColumnHeader13.Width = 25
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Empresa"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Centro"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Modulo"
        Me.ColumnHeader9.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Tipo"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Fecha"
        Me.ColumnHeader4.Width = 90
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Texto"
        Me.ColumnHeader3.Width = 510
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Valor"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Estado"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Equipo"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Usuario"
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Fecha Reg"
        Me.ColumnHeader12.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "codigo"
        Me.ColumnHeader8.Width = 0
        '
        'btnMensajes
        '
        Me.btnMensajes.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMensajes.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMensajes.ForeColor = System.Drawing.Color.White
        Me.btnMensajes.Location = New System.Drawing.Point(-1, -1)
        Me.btnMensajes.Name = "btnMensajes"
        Me.btnMensajes.Size = New System.Drawing.Size(273, 40)
        Me.btnMensajes.TabIndex = 132
        Me.btnMensajes.Text = "MENSAJES PENDIENTES (0)"
        Me.btnMensajes.UseVisualStyleBackColor = False
        Me.btnMensajes.Visible = False
        '
        'btnMarcar
        '
        Me.btnMarcar.Enabled = False
        Me.btnMarcar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcar.Image = CType(resources.GetObject("btnMarcar.Image"), System.Drawing.Image)
        Me.btnMarcar.Location = New System.Drawing.Point(8, 359)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(155, 30)
        Me.btnMarcar.TabIndex = 136
        Me.btnMarcar.Text = "Marcar como leídos"
        Me.btnMarcar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMarcar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMarcar.UseVisualStyleBackColor = True
        Me.btnMarcar.Visible = False
        '
        'btnOcultar
        '
        Me.btnOcultar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOcultar.Image = CType(resources.GetObject("btnOcultar.Image"), System.Drawing.Image)
        Me.btnOcultar.Location = New System.Drawing.Point(811, 359)
        Me.btnOcultar.Name = "btnOcultar"
        Me.btnOcultar.Size = New System.Drawing.Size(87, 30)
        Me.btnOcultar.TabIndex = 134
        Me.btnOcultar.Text = "Ocultar"
        Me.btnOcultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOcultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnOcultar.UseVisualStyleBackColor = True
        '
        'frmMensajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 406)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnMensajes)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMensajes"
        Me.Text = "Mensajes Pendientes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrOcultar As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOcultar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvMENSAJES As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btnMarcar As System.Windows.Forms.Button
    Friend WithEvents btnMensajes As System.Windows.Forms.Button
End Class
