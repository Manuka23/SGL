<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPabcoDetalleTratamiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPabcoDetalleTratamiento))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblDiio = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblDias = New System.Windows.Forms.Label()
        Me.lblPatologia = New System.Windows.Forms.Label()
        Me.lblMedicamento = New System.Windows.Forms.Label()
        Me.lblDosis = New System.Windows.Forms.Label()
        Me.lblObs = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblFecTermino = New System.Windows.Forms.Label()
        Me.lblTermino = New System.Windows.Forms.Label()
        Me.lblUMedida = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 13)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(878, 55)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Detalle Tratamiento"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, -2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 79)
        Me.Panel1.TabIndex = 237
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(716, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Lote:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 24)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Diio:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(172, 24)
        Me.Label4.TabIndex = 239
        Me.Label4.Text = "Fecha Tratamiento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 24)
        Me.Label5.TabIndex = 240
        Me.Label5.Text = "Días Tratamiento:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 453)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 24)
        Me.Label6.TabIndex = 241
        Me.Label6.Text = "Observación:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 405)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 24)
        Me.Label7.TabIndex = 242
        Me.Label7.Text = "Dosis:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(614, 177)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 24)
        Me.Label8.TabIndex = 243
        Me.Label8.Text = "Usuario Regsitro:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 290)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(95, 24)
        Me.Label9.TabIndex = 244
        Me.Label9.Text = "Patología:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(15, 347)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 24)
        Me.Label10.TabIndex = 245
        Me.Label10.Text = "Medicamento:"
        '
        'lblLote
        '
        Me.lblLote.AutoSize = True
        Me.lblLote.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.Location = New System.Drawing.Point(788, 127)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(46, 24)
        Me.lblLote.TabIndex = 246
        Me.lblLote.Text = "Lote"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(788, 177)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(75, 24)
        Me.lblUsuario.TabIndex = 247
        Me.lblUsuario.Text = "Usuario"
        '
        'lblDiio
        '
        Me.lblDiio.AutoSize = True
        Me.lblDiio.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiio.Location = New System.Drawing.Point(71, 127)
        Me.lblDiio.Name = "lblDiio"
        Me.lblDiio.Size = New System.Drawing.Size(43, 24)
        Me.lblDiio.TabIndex = 248
        Me.lblDiio.Text = "Diio"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(202, 177)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(58, 24)
        Me.lblFecha.TabIndex = 249
        Me.lblFecha.Text = "Fecha"
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDias.Location = New System.Drawing.Point(204, 237)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(45, 24)
        Me.lblDias.TabIndex = 250
        Me.lblDias.Text = "Dias"
        '
        'lblPatologia
        '
        Me.lblPatologia.AutoSize = True
        Me.lblPatologia.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatologia.Location = New System.Drawing.Point(202, 290)
        Me.lblPatologia.Name = "lblPatologia"
        Me.lblPatologia.Size = New System.Drawing.Size(89, 24)
        Me.lblPatologia.TabIndex = 251
        Me.lblPatologia.Text = "patologia"
        '
        'lblMedicamento
        '
        Me.lblMedicamento.AutoSize = True
        Me.lblMedicamento.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedicamento.Location = New System.Drawing.Point(204, 347)
        Me.lblMedicamento.Name = "lblMedicamento"
        Me.lblMedicamento.Size = New System.Drawing.Size(126, 24)
        Me.lblMedicamento.TabIndex = 252
        Me.lblMedicamento.Text = "Medicamento"
        '
        'lblDosis
        '
        Me.lblDosis.AutoSize = True
        Me.lblDosis.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDosis.Location = New System.Drawing.Point(204, 405)
        Me.lblDosis.Name = "lblDosis"
        Me.lblDosis.Size = New System.Drawing.Size(53, 24)
        Me.lblDosis.TabIndex = 253
        Me.lblDosis.Text = "dosis"
        '
        'lblObs
        '
        Me.lblObs.AutoSize = True
        Me.lblObs.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObs.Location = New System.Drawing.Point(207, 453)
        Me.lblObs.Name = "lblObs"
        Me.lblObs.Size = New System.Drawing.Size(42, 24)
        Me.lblObs.TabIndex = 254
        Me.lblObs.Text = "Obs"
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(834, 469)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(102, 35)
        Me.btnCerrar.TabIndex = 255
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lblFecTermino
        '
        Me.lblFecTermino.AutoSize = True
        Me.lblFecTermino.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecTermino.Location = New System.Drawing.Point(631, 237)
        Me.lblFecTermino.Name = "lblFecTermino"
        Me.lblFecTermino.Size = New System.Drawing.Size(137, 24)
        Me.lblFecTermino.TabIndex = 256
        Me.lblFecTermino.Text = "Fecha Termino:"
        '
        'lblTermino
        '
        Me.lblTermino.AutoSize = True
        Me.lblTermino.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTermino.Location = New System.Drawing.Point(788, 237)
        Me.lblTermino.Name = "lblTermino"
        Me.lblTermino.Size = New System.Drawing.Size(78, 24)
        Me.lblTermino.TabIndex = 257
        Me.lblTermino.Text = "Termino"
        '
        'lblUMedida
        '
        Me.lblUMedida.AutoSize = True
        Me.lblUMedida.Location = New System.Drawing.Point(257, 411)
        Me.lblUMedida.Name = "lblUMedida"
        Me.lblUMedida.Size = New System.Drawing.Size(0, 17)
        Me.lblUMedida.TabIndex = 258
        '
        'frmPabcoDetalleTratamiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(948, 516)
        Me.Controls.Add(Me.lblUMedida)
        Me.Controls.Add(Me.lblTermino)
        Me.Controls.Add(Me.lblFecTermino)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.lblObs)
        Me.Controls.Add(Me.lblDosis)
        Me.Controls.Add(Me.lblMedicamento)
        Me.Controls.Add(Me.lblPatologia)
        Me.Controls.Add(Me.lblDias)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.lblDiio)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.lblLote)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPabcoDetalleTratamiento"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblLote As Label
    Friend WithEvents lblUsuario As Label
    Friend WithEvents lblDiio As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents lblDias As Label
    Friend WithEvents lblPatologia As Label
    Friend WithEvents lblMedicamento As Label
    Friend WithEvents lblDosis As Label
    Friend WithEvents lblObs As Label
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblFecTermino As Label
    Friend WithEvents lblTermino As Label
    Friend WithEvents lblUMedida As Label
End Class
