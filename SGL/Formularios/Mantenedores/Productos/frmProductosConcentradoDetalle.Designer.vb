<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductosConcentradoDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductosConcentradoDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CboBi = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tipCentro = New System.Windows.Forms.ComboBox()
        Me.txtItemGasto = New System.Windows.Forms.Label()
        Me.txtNomCuenta = New System.Windows.Forms.Label()
        Me.txtNomProducto = New System.Windows.Forms.Label()
        Me.txtCodPresupuesto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodCuenta = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodProducto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(1, -1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(624, 59)
        Me.Panel1.TabIndex = 133
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(27, 15)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(551, 41)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "INGRESO PRODUCTO"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cboEstado)
        Me.GroupBox5.Controls.Add(Me.lblEstado)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.txtKilos)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.CboBi)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.tipCentro)
        Me.GroupBox5.Controls.Add(Me.txtItemGasto)
        Me.GroupBox5.Controls.Add(Me.txtNomCuenta)
        Me.GroupBox5.Controls.Add(Me.txtNomProducto)
        Me.GroupBox5.Controls.Add(Me.txtCodPresupuesto)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.txtCodCuenta)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.txtCodProducto)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(16, 65)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(580, 363)
        Me.GroupBox5.TabIndex = 130
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Parámetros"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(269, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 21)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Kilos De Materia Seca"
        '
        'txtKilos
        '
        Me.txtKilos.Location = New System.Drawing.Point(124, 162)
        Me.txtKilos.Margin = New System.Windows.Forms.Padding(4)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(128, 27)
        Me.txtKilos.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 168)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 21)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "KgMS:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 268)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 21)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Usar en BI:"
        '
        'CboBi
        '
        Me.CboBi.FormattingEnabled = True
        Me.CboBi.Location = New System.Drawing.Point(124, 268)
        Me.CboBi.Margin = New System.Windows.Forms.Padding(4)
        Me.CboBi.Name = "CboBi"
        Me.CboBi.Size = New System.Drawing.Size(128, 27)
        Me.CboBi.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 216)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 21)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Centro Tipo:"
        '
        'tipCentro
        '
        Me.tipCentro.FormattingEnabled = True
        Me.tipCentro.Location = New System.Drawing.Point(124, 213)
        Me.tipCentro.Margin = New System.Windows.Forms.Padding(4)
        Me.tipCentro.Name = "tipCentro"
        Me.tipCentro.Size = New System.Drawing.Size(128, 27)
        Me.tipCentro.TabIndex = 19
        '
        'txtItemGasto
        '
        Me.txtItemGasto.AutoSize = True
        Me.txtItemGasto.Location = New System.Drawing.Point(269, 121)
        Me.txtItemGasto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtItemGasto.Name = "txtItemGasto"
        Me.txtItemGasto.Size = New System.Drawing.Size(25, 21)
        Me.txtItemGasto.TabIndex = 18
        Me.txtItemGasto.Text = "---"
        '
        'txtNomCuenta
        '
        Me.txtNomCuenta.AutoSize = True
        Me.txtNomCuenta.Location = New System.Drawing.Point(269, 80)
        Me.txtNomCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtNomCuenta.Name = "txtNomCuenta"
        Me.txtNomCuenta.Size = New System.Drawing.Size(25, 21)
        Me.txtNomCuenta.TabIndex = 17
        Me.txtNomCuenta.Text = "---"
        '
        'txtNomProducto
        '
        Me.txtNomProducto.AutoSize = True
        Me.txtNomProducto.Location = New System.Drawing.Point(269, 38)
        Me.txtNomProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtNomProducto.Name = "txtNomProducto"
        Me.txtNomProducto.Size = New System.Drawing.Size(25, 21)
        Me.txtNomProducto.TabIndex = 16
        Me.txtNomProducto.Text = "---"
        '
        'txtCodPresupuesto
        '
        Me.txtCodPresupuesto.Location = New System.Drawing.Point(124, 117)
        Me.txtCodPresupuesto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodPresupuesto.Name = "txtCodPresupuesto"
        Me.txtCodPresupuesto.Size = New System.Drawing.Size(128, 27)
        Me.txtCodPresupuesto.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 121)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 21)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Item Gasto:"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuenta.Location = New System.Drawing.Point(124, 76)
        Me.txtCodCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Size = New System.Drawing.Size(128, 27)
        Me.txtCodCuenta.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 76)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 21)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Cuenta:"
        '
        'txtCodProducto
        '
        Me.txtCodProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodProducto.Location = New System.Drawing.Point(124, 34)
        Me.txtCodProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodProducto.Name = "txtCodProducto"
        Me.txtCodProducto.Size = New System.Drawing.Size(128, 27)
        Me.txtCodProducto.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 34)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 21)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Producto:"
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(16, 436)
        Me.btnFinalizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(146, 43)
        Me.btnFinalizar.TabIndex = 132
        Me.btnFinalizar.Text = "   Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(464, 436)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(132, 43)
        Me.Button3.TabIndex = 131
        Me.Button3.Text = "Cerrar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(8, 322)
        Me.lblEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(62, 21)
        Me.lblEstado.TabIndex = 26
        Me.lblEstado.Text = "Estado:"
        '
        'cboEstado
        '
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(124, 319)
        Me.cboEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(128, 27)
        Me.cboEstado.TabIndex = 27
        '
        'frmProductosConcentradoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 514)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductosConcentradoDetalle"
        Me.Text = "Productos Concetrado"
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
    Friend WithEvents Label8 As Label
    Friend WithEvents tipCentro As ComboBox
    Friend WithEvents txtItemGasto As Label
    Friend WithEvents txtNomCuenta As Label
    Friend WithEvents txtNomProducto As Label
    Friend WithEvents txtCodPresupuesto As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCodCuenta As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCodProducto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CboBi As ComboBox
    Friend WithEvents txtKilos As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents lblEstado As Label
End Class
