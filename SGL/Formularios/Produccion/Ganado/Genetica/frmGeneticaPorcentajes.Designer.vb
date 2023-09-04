<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneticaPorcentajes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneticaPorcentajes))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBisabuelo = New System.Windows.Forms.Label()
        Me.lblAbuelo = New System.Windows.Forms.Label()
        Me.lblPadre = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtAbuelo = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtBisabuelo = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtPadre = New System.Windows.Forms.TextBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblPorBis = New System.Windows.Forms.Label()
        Me.lblPorAb = New System.Windows.Forms.Label()
        Me.lblPorPa = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtPorcentAbuelo = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtPercentBisabuelo = New System.Windows.Forms.TextBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtPorcentPadre = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(11, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(675, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "INGRESO PORCENTAJE GENÉTICA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(702, 44)
        Me.Panel1.TabIndex = 189
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblBisabuelo)
        Me.GroupBox1.Controls.Add(Me.lblAbuelo)
        Me.GroupBox1.Controls.Add(Me.lblPadre)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(668, 145)
        Me.GroupBox1.TabIndex = 190
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Porcentaje Ascendencia Actual"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(554, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 35)
        Me.Label4.TabIndex = 196
        Me.Label4.Text = "Padre"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(268, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 35)
        Me.Label2.TabIndex = 195
        Me.Label2.Text = "Padre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 35)
        Me.Label1.TabIndex = 194
        Me.Label1.Text = "Padre"
        '
        'lblBisabuelo
        '
        Me.lblBisabuelo.AutoSize = True
        Me.lblBisabuelo.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBisabuelo.Location = New System.Drawing.Point(533, 33)
        Me.lblBisabuelo.Name = "lblBisabuelo"
        Me.lblBisabuelo.Size = New System.Drawing.Size(129, 35)
        Me.lblBisabuelo.TabIndex = 193
        Me.lblBisabuelo.Text = "Bisabuelo"
        '
        'lblAbuelo
        '
        Me.lblAbuelo.AutoSize = True
        Me.lblAbuelo.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbuelo.Location = New System.Drawing.Point(263, 33)
        Me.lblAbuelo.Name = "lblAbuelo"
        Me.lblAbuelo.Size = New System.Drawing.Size(98, 35)
        Me.lblAbuelo.TabIndex = 192
        Me.lblAbuelo.Text = "Abuelo"
        '
        'lblPadre
        '
        Me.lblPadre.AutoSize = True
        Me.lblPadre.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPadre.Location = New System.Drawing.Point(6, 33)
        Me.lblPadre.Name = "lblPadre"
        Me.lblPadre.Size = New System.Drawing.Size(82, 35)
        Me.lblPadre.TabIndex = 191
        Me.lblPadre.Text = "Padre"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(668, 92)
        Me.GroupBox2.TabIndex = 191
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Ingrese Nuevo Porcentaje"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtAbuelo)
        Me.GroupBox4.Location = New System.Drawing.Point(236, 30)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(202, 52)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Abuelo"
        '
        'txtAbuelo
        '
        Me.txtAbuelo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbuelo.Location = New System.Drawing.Point(6, 20)
        Me.txtAbuelo.Name = "txtAbuelo"
        Me.txtAbuelo.Size = New System.Drawing.Size(190, 26)
        Me.txtAbuelo.TabIndex = 1
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtBisabuelo)
        Me.GroupBox5.Location = New System.Drawing.Point(460, 30)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(202, 52)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Bisabuelo"
        '
        'txtBisabuelo
        '
        Me.txtBisabuelo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBisabuelo.Location = New System.Drawing.Point(6, 20)
        Me.txtBisabuelo.Name = "txtBisabuelo"
        Me.txtBisabuelo.Size = New System.Drawing.Size(190, 26)
        Me.txtBisabuelo.TabIndex = 2
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtPadre)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(202, 52)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Padre"
        '
        'txtPadre
        '
        Me.txtPadre.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPadre.Location = New System.Drawing.Point(0, 20)
        Me.txtPadre.Name = "txtPadre"
        Me.txtPadre.Size = New System.Drawing.Size(196, 26)
        Me.txtPadre.TabIndex = 0
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(19, 298)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(109, 37)
        Me.btnGrabar.TabIndex = 192
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(579, 298)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(109, 37)
        Me.btnCerrar.TabIndex = 193
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lblPorBis)
        Me.GroupBox6.Controls.Add(Me.lblPorAb)
        Me.GroupBox6.Controls.Add(Me.lblPorPa)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(12, 49)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(676, 145)
        Me.GroupBox6.TabIndex = 190
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Porcentaje Ascendencia Actual"
        '
        'lblPorBis
        '
        Me.lblPorBis.AutoSize = True
        Me.lblPorBis.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorBis.Location = New System.Drawing.Point(569, 68)
        Me.lblPorBis.Name = "lblPorBis"
        Me.lblPorBis.Size = New System.Drawing.Size(29, 35)
        Me.lblPorBis.TabIndex = 196
        Me.lblPorBis.Text = "0"
        '
        'lblPorAb
        '
        Me.lblPorAb.AutoSize = True
        Me.lblPorAb.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorAb.Location = New System.Drawing.Point(287, 68)
        Me.lblPorAb.Name = "lblPorAb"
        Me.lblPorAb.Size = New System.Drawing.Size(29, 35)
        Me.lblPorAb.TabIndex = 195
        Me.lblPorAb.Text = "0"
        '
        'lblPorPa
        '
        Me.lblPorPa.AutoSize = True
        Me.lblPorPa.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorPa.Location = New System.Drawing.Point(22, 68)
        Me.lblPorPa.Name = "lblPorPa"
        Me.lblPorPa.Size = New System.Drawing.Size(29, 35)
        Me.lblPorPa.TabIndex = 194
        Me.lblPorPa.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(536, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 35)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "Bisabuelo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(263, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 35)
        Me.Label9.TabIndex = 192
        Me.Label9.Text = "Abuelo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 35)
        Me.Label10.TabIndex = 191
        Me.Label10.Text = "Padre"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.GroupBox8)
        Me.GroupBox7.Controls.Add(Me.GroupBox9)
        Me.GroupBox7.Controls.Add(Me.GroupBox10)
        Me.GroupBox7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(12, 200)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(676, 92)
        Me.GroupBox7.TabIndex = 191
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Ingrese Nuevo Porcentaje"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.txtPorcentAbuelo)
        Me.GroupBox8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(236, 30)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(202, 52)
        Me.GroupBox8.TabIndex = 1
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Abuelo"
        '
        'txtPorcentAbuelo
        '
        Me.txtPorcentAbuelo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentAbuelo.Location = New System.Drawing.Point(6, 20)
        Me.txtPorcentAbuelo.Name = "txtPorcentAbuelo"
        Me.txtPorcentAbuelo.Size = New System.Drawing.Size(190, 26)
        Me.txtPorcentAbuelo.TabIndex = 1
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.txtPercentBisabuelo)
        Me.GroupBox9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(460, 30)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(202, 52)
        Me.GroupBox9.TabIndex = 1
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Bisabuelo"
        '
        'txtPercentBisabuelo
        '
        Me.txtPercentBisabuelo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPercentBisabuelo.Location = New System.Drawing.Point(6, 20)
        Me.txtPercentBisabuelo.Name = "txtPercentBisabuelo"
        Me.txtPercentBisabuelo.Size = New System.Drawing.Size(190, 26)
        Me.txtPercentBisabuelo.TabIndex = 2
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtPorcentPadre)
        Me.GroupBox10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox10.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(202, 52)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Padre"
        '
        'txtPorcentPadre
        '
        Me.txtPorcentPadre.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentPadre.Location = New System.Drawing.Point(6, 20)
        Me.txtPorcentPadre.Name = "txtPorcentPadre"
        Me.txtPorcentPadre.Size = New System.Drawing.Size(190, 26)
        Me.txtPorcentPadre.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(20, 298)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 37)
        Me.Button1.TabIndex = 192
        Me.Button1.Text = "Grabar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(580, 298)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(109, 37)
        Me.Button2.TabIndex = 193
        Me.Button2.Text = "Cerrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmGeneticaPorcentajes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 345)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGeneticaPorcentajes"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblBisabuelo As Label
    Friend WithEvents lblAbuelo As Label
    Friend WithEvents lblPadre As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtAbuelo As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtBisabuelo As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtPadre As TextBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents lblPorBis As Label
    Friend WithEvents lblPorAb As Label
    Friend WithEvents lblPorPa As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents txtPorcentAbuelo As TextBox
    Friend WithEvents txtPercentBisabuelo As TextBox
    Friend WithEvents txtPorcentPadre As TextBox
End Class
