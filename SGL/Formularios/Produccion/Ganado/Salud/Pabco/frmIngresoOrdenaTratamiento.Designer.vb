<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIngresoOrdenaTratamiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoOrdenaTratamiento))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dias = New System.Windows.Forms.Label()
        Me.medicamento = New System.Windows.Forms.Label()
        Me.cantidad = New System.Windows.Forms.Label()
        Me.Centro = New System.Windows.Forms.Label()
        Me.Diio = New System.Windows.Forms.Label()
        Me.patologia = New System.Windows.Forms.Label()
        Me.Fecha = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFech = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(0, -4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 46)
        Me.Panel1.TabIndex = 174
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(-16, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(728, 29)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Ingreso Ordeña"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dias)
        Me.GroupBox2.Controls.Add(Me.medicamento)
        Me.GroupBox2.Controls.Add(Me.cantidad)
        Me.GroupBox2.Controls.Add(Me.Centro)
        Me.GroupBox2.Controls.Add(Me.Diio)
        Me.GroupBox2.Controls.Add(Me.patologia)
        Me.GroupBox2.Controls.Add(Me.Fecha)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(700, 230)
        Me.GroupBox2.TabIndex = 173
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Tratamiento"
        '
        'dias
        '
        Me.dias.AutoSize = True
        Me.dias.Location = New System.Drawing.Point(139, 196)
        Me.dias.Name = "dias"
        Me.dias.Size = New System.Drawing.Size(55, 18)
        Me.dias.TabIndex = 13
        Me.dias.Text = "Label15"
        '
        'medicamento
        '
        Me.medicamento.AutoSize = True
        Me.medicamento.Location = New System.Drawing.Point(121, 136)
        Me.medicamento.Name = "medicamento"
        Me.medicamento.Size = New System.Drawing.Size(55, 18)
        Me.medicamento.TabIndex = 12
        Me.medicamento.Text = "Label14"
        '
        'cantidad
        '
        Me.cantidad.AutoSize = True
        Me.cantidad.Location = New System.Drawing.Point(86, 166)
        Me.cantidad.Name = "cantidad"
        Me.cantidad.Size = New System.Drawing.Size(55, 18)
        Me.cantidad.TabIndex = 11
        Me.cantidad.Text = "Label13"
        '
        'Centro
        '
        Me.Centro.AutoSize = True
        Me.Centro.Location = New System.Drawing.Point(77, 50)
        Me.Centro.Name = "Centro"
        Me.Centro.Size = New System.Drawing.Size(55, 18)
        Me.Centro.TabIndex = 10
        Me.Centro.Text = "Label12"
        '
        'Diio
        '
        Me.Diio.AutoSize = True
        Me.Diio.Location = New System.Drawing.Point(60, 79)
        Me.Diio.Name = "Diio"
        Me.Diio.Size = New System.Drawing.Size(55, 18)
        Me.Diio.TabIndex = 9
        Me.Diio.Text = "Label10"
        '
        'patologia
        '
        Me.patologia.AutoSize = True
        Me.patologia.Location = New System.Drawing.Point(93, 108)
        Me.patologia.Name = "patologia"
        Me.patologia.Size = New System.Drawing.Size(48, 18)
        Me.patologia.TabIndex = 8
        Me.patologia.Text = "Label9"
        '
        'Fecha
        '
        Me.Fecha.AutoSize = True
        Me.Fecha.Location = New System.Drawing.Point(67, 22)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(48, 18)
        Me.Fecha.TabIndex = 7
        Me.Fecha.Text = "Label8"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 18)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Dias Tratamiento:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 18)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Cantidad:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 18)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Patologia:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 18)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Medicamento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Centro:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Diio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(625, 337)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 172
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
        Me.btnGrabar.Location = New System.Drawing.Point(8, 337)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 30)
        Me.btnGrabar.TabIndex = 171
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.Label8.Location = New System.Drawing.Point(12, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 18)
        Me.Label8.TabIndex = 175
        Me.Label8.Text = "Fecha Ingreso a ordeña:"
        '
        'dtpFech
        '
        Me.dtpFech.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.dtpFech.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFech.Location = New System.Drawing.Point(172, 290)
        Me.dtpFech.Name = "dtpFech"
        Me.dtpFech.Size = New System.Drawing.Size(87, 26)
        Me.dtpFech.TabIndex = 176
        Me.dtpFech.Value = New Date(2017, 10, 6, 15, 45, 48, 0)
        '
        'frmIngresoOrdenaTratamiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 376)
        Me.ControlBox = False
        Me.Controls.Add(Me.dtpFech)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIngresoOrdenaTratamiento"
        Me.Text = "Ingreso ordeña"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGrabar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dias As Label
    Friend WithEvents medicamento As Label
    Friend WithEvents cantidad As Label
    Friend WithEvents Centro As Label
    Friend WithEvents Diio As Label
    Friend WithEvents patologia As Label
    Friend WithEvents Fecha As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpFech As DateTimePicker
End Class
