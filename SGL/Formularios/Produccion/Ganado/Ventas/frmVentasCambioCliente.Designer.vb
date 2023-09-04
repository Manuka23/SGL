<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentasCambioCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentasCambioCliente))
        Me.txtNroVenta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtClienteNom = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboCambioCliente = New System.Windows.Forms.ComboBox()
        Me.bnCerrar = New System.Windows.Forms.Button()
        Me.btnCambiarCliente = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNroVenta
        '
        Me.txtNroVenta.Enabled = False
        Me.txtNroVenta.Location = New System.Drawing.Point(7, 21)
        Me.txtNroVenta.Name = "txtNroVenta"
        Me.txtNroVenta.Size = New System.Drawing.Size(119, 22)
        Me.txtNroVenta.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(721, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "VENTAS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1105, 41)
        Me.Panel1.TabIndex = 75
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNroVenta)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(140, 51)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Numero Venta"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtClienteNom)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(166, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(543, 51)
        Me.GroupBox2.TabIndex = 77
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cliente Actual"
        '
        'txtClienteNom
        '
        Me.txtClienteNom.Enabled = False
        Me.txtClienteNom.Location = New System.Drawing.Point(64, 21)
        Me.txtClienteNom.Name = "txtClienteNom"
        Me.txtClienteNom.Size = New System.Drawing.Size(464, 22)
        Me.txtClienteNom.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboCambioCliente)
        Me.GroupBox3.Location = New System.Drawing.Point(20, 109)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(689, 50)
        Me.GroupBox3.TabIndex = 79
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Seleccione Cliente"
        '
        'cboCambioCliente
        '
        Me.cboCambioCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCambioCliente.FormattingEnabled = True
        Me.cboCambioCliente.Location = New System.Drawing.Point(6, 21)
        Me.cboCambioCliente.Name = "cboCambioCliente"
        Me.cboCambioCliente.Size = New System.Drawing.Size(668, 24)
        Me.cboCambioCliente.TabIndex = 0
        '
        'bnCerrar
        '
        Me.bnCerrar.Image = CType(resources.GetObject("bnCerrar.Image"), System.Drawing.Image)
        Me.bnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bnCerrar.Location = New System.Drawing.Point(619, 165)
        Me.bnCerrar.Name = "bnCerrar"
        Me.bnCerrar.Size = New System.Drawing.Size(90, 31)
        Me.bnCerrar.TabIndex = 80
        Me.bnCerrar.Text = "Cerrar"
        Me.bnCerrar.UseVisualStyleBackColor = True
        '
        'btnCambiarCliente
        '
        Me.btnCambiarCliente.Image = CType(resources.GetObject("btnCambiarCliente.Image"), System.Drawing.Image)
        Me.btnCambiarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCambiarCliente.Location = New System.Drawing.Point(20, 165)
        Me.btnCambiarCliente.Name = "btnCambiarCliente"
        Me.btnCambiarCliente.Size = New System.Drawing.Size(151, 31)
        Me.btnCambiarCliente.TabIndex = 81
        Me.btnCambiarCliente.Text = "Cambiar Cliente"
        Me.btnCambiarCliente.UseVisualStyleBackColor = True
        '
        'frmVentasCambioCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 206)
        Me.Controls.Add(Me.btnCambiarCliente)
        Me.Controls.Add(Me.bnCerrar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVentasCambioCliente"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtNroVenta As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtClienteNom As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboCambioCliente As ComboBox
    Friend WithEvents bnCerrar As Button
    Friend WithEvents btnCambiarCliente As Button
End Class
