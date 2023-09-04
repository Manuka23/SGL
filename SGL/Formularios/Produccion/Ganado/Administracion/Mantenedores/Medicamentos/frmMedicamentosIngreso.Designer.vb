<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMedicamentosIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicamentosIngreso))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboUMedida = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblItemCodigo = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtItemCodigo = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.estado = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtleche = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcarne = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDiasduracion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtduracion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdosis = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtsag = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(886, 530)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 37)
        Me.btnSalir.TabIndex = 93
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(13, 530)
        Me.btnGrabar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(116, 37)
        Me.btnGrabar.TabIndex = 92
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboUMedida)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lblItemCodigo)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtItemCodigo)
        Me.GroupBox2.Controls.Add(Me.ComboBox2)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.ComboBox1)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.estado)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtleche)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtcarne)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtDiasduracion)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtduracion)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtdosis)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtnombre)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtsag)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtObservs)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(13, 58)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(989, 464)
        Me.GroupBox2.TabIndex = 94
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Medicamento"
        '
        'cboUMedida
        '
        Me.cboUMedida.FormattingEnabled = True
        Me.cboUMedida.Location = New System.Drawing.Point(150, 264)
        Me.cboUMedida.Margin = New System.Windows.Forms.Padding(4)
        Me.cboUMedida.Name = "cboUMedida"
        Me.cboUMedida.Size = New System.Drawing.Size(128, 31)
        Me.cboUMedida.TabIndex = 132
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(33, 272)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(104, 23)
        Me.Label14.TabIndex = 131
        Me.Label14.Text = "Un. Medida:"
        '
        'lblItemCodigo
        '
        Me.lblItemCodigo.AutoSize = True
        Me.lblItemCodigo.Location = New System.Drawing.Point(411, 69)
        Me.lblItemCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemCodigo.Name = "lblItemCodigo"
        Me.lblItemCodigo.Size = New System.Drawing.Size(28, 23)
        Me.lblItemCodigo.TabIndex = 130
        Me.lblItemCodigo.Text = "---"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(28, 73)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 23)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Item Codigo:"
        '
        'txtItemCodigo
        '
        Me.txtItemCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemCodigo.Location = New System.Drawing.Point(151, 66)
        Me.txtItemCodigo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtItemCodigo.Name = "txtItemCodigo"
        Me.txtItemCodigo.Size = New System.Drawing.Size(141, 30)
        Me.txtItemCodigo.TabIndex = 128
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(150, 219)
        Me.ComboBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(128, 31)
        Me.ComboBox2.TabIndex = 127
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(38, 227)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 23)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "Preventivo:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(613, 224)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(128, 31)
        Me.ComboBox1.TabIndex = 125
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(443, 232)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(153, 23)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "Vacas en lactancia:"
        '
        'estado
        '
        Me.estado.FormattingEnabled = True
        Me.estado.Location = New System.Drawing.Point(150, 180)
        Me.estado.Margin = New System.Windows.Forms.Padding(4)
        Me.estado.Name = "estado"
        Me.estado.Size = New System.Drawing.Size(128, 31)
        Me.estado.TabIndex = 123
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(64, 188)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 23)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "Vigente:"
        '
        'txtleche
        '
        Me.txtleche.Location = New System.Drawing.Point(613, 110)
        Me.txtleche.Margin = New System.Windows.Forms.Padding(4)
        Me.txtleche.Name = "txtleche"
        Me.txtleche.Size = New System.Drawing.Size(60, 30)
        Me.txtleche.TabIndex = 121
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(451, 117)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(145, 23)
        Me.Label5.TabIndex = 120
        Me.Label5.Text = "Resguardo Leche:"
        '
        'txtcarne
        '
        Me.txtcarne.Location = New System.Drawing.Point(613, 148)
        Me.txtcarne.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcarne.Name = "txtcarne"
        Me.txtcarne.Size = New System.Drawing.Size(60, 30)
        Me.txtcarne.TabIndex = 119
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(451, 155)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 23)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Resguardo Carne:"
        '
        'txtDiasduracion
        '
        Me.txtDiasduracion.Location = New System.Drawing.Point(613, 186)
        Me.txtDiasduracion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDiasduracion.Name = "txtDiasduracion"
        Me.txtDiasduracion.Size = New System.Drawing.Size(60, 30)
        Me.txtDiasduracion.TabIndex = 117
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(475, 193)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 23)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "Dias Duracion:"
        '
        'txtduracion
        '
        Me.txtduracion.Location = New System.Drawing.Point(613, 29)
        Me.txtduracion.Margin = New System.Windows.Forms.Padding(4)
        Me.txtduracion.Name = "txtduracion"
        Me.txtduracion.Size = New System.Drawing.Size(236, 30)
        Me.txtduracion.TabIndex = 115
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(411, 32)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(186, 23)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Duracion Tratamiento :"
        '
        'txtdosis
        '
        Me.txtdosis.Location = New System.Drawing.Point(150, 142)
        Me.txtdosis.Margin = New System.Windows.Forms.Padding(4)
        Me.txtdosis.Name = "txtdosis"
        Me.txtdosis.Size = New System.Drawing.Size(236, 30)
        Me.txtdosis.TabIndex = 113
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(79, 149)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 23)
        Me.Label7.TabIndex = 112
        Me.Label7.Text = "Dosis:"
        '
        'txtnombre
        '
        Me.txtnombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnombre.Location = New System.Drawing.Point(150, 104)
        Me.txtnombre.Margin = New System.Windows.Forms.Padding(4)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(235, 30)
        Me.txtnombre.TabIndex = 111
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(58, 111)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 23)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "Nombre:"
        '
        'txtsag
        '
        Me.txtsag.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsag.Location = New System.Drawing.Point(151, 28)
        Me.txtsag.Margin = New System.Windows.Forms.Padding(4)
        Me.txtsag.Name = "txtsag"
        Me.txtsag.Size = New System.Drawing.Size(141, 30)
        Me.txtsag.TabIndex = 109
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(63, 32)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 23)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Reg Sag:"
        '
        'txtObservs
        '
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(16, 388)
        Me.txtObservs.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObservs.MaxLength = 500
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(960, 68)
        Me.txtObservs.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 329)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(155, 27)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Observacion"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(-3, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1029, 50)
        Me.Panel1.TabIndex = 170
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(21, 5)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(971, 36)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Crear Medicamento"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmMedicamentosIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 605)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMedicamentosIngreso"
        Me.Text = "Ingreso Medicamentos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGrabar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtObservs As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtdosis As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtnombre As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtsag As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtleche As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtcarne As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDiasduracion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtduracion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents estado As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents lblItemCodigo As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtItemCodigo As TextBox
    Friend WithEvents cboUMedida As ComboBox
    Friend WithEvents Label14 As Label
End Class
