<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPabcoLiberarLeche
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPabcoLiberarLeche))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.lblLiberacionLeche = New System.Windows.Forms.Label()
        Me.lblCarne = New System.Windows.Forms.Label()
        Me.lblPatologia = New System.Windows.Forms.Label()
        Me.lblMedicamento = New System.Windows.Forms.Label()
        Me.lblDiioLote = New System.Windows.Forms.Label()
        Me.lblDiio = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaCierre = New System.Windows.Forms.DateTimePicker()
        Me.lblFecLeche = New System.Windows.Forms.Label()
        Me.lblFecCarne = New System.Windows.Forms.Label()
        Me.lblNomPatologia = New System.Windows.Forms.Label()
        Me.lblNomMedicamento = New System.Windows.Forms.Label()
        Me.lblCentro = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.lblCodPat = New System.Windows.Forms.Label()
        Me.lblCodMed = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(645, 38)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Liberar Leche"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, -2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(672, 50)
        Me.Panel1.TabIndex = 239
        '
        'lblLote
        '
        Me.lblLote.AutoSize = True
        Me.lblLote.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.Location = New System.Drawing.Point(9, 60)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(79, 37)
        Me.lblLote.TabIndex = 240
        Me.lblLote.Text = "Lote:"
        '
        'lblLiberacionLeche
        '
        Me.lblLiberacionLeche.AutoSize = True
        Me.lblLiberacionLeche.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLiberacionLeche.Location = New System.Drawing.Point(12, 190)
        Me.lblLiberacionLeche.Name = "lblLiberacionLeche"
        Me.lblLiberacionLeche.Size = New System.Drawing.Size(116, 24)
        Me.lblLiberacionLeche.TabIndex = 241
        Me.lblLiberacionLeche.Text = "Fecha Leche:"
        '
        'lblCarne
        '
        Me.lblCarne.AutoSize = True
        Me.lblCarne.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarne.Location = New System.Drawing.Point(333, 190)
        Me.lblCarne.Name = "lblCarne"
        Me.lblCarne.Size = New System.Drawing.Size(118, 24)
        Me.lblCarne.TabIndex = 242
        Me.lblCarne.Text = "Fecha Carne:"
        '
        'lblPatologia
        '
        Me.lblPatologia.AutoSize = True
        Me.lblPatologia.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatologia.Location = New System.Drawing.Point(12, 242)
        Me.lblPatologia.Name = "lblPatologia"
        Me.lblPatologia.Size = New System.Drawing.Size(95, 24)
        Me.lblPatologia.TabIndex = 243
        Me.lblPatologia.Text = "Patología:"
        '
        'lblMedicamento
        '
        Me.lblMedicamento.AutoSize = True
        Me.lblMedicamento.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedicamento.Location = New System.Drawing.Point(333, 242)
        Me.lblMedicamento.Name = "lblMedicamento"
        Me.lblMedicamento.Size = New System.Drawing.Size(132, 24)
        Me.lblMedicamento.TabIndex = 244
        Me.lblMedicamento.Text = "Medicamento:"
        '
        'lblDiioLote
        '
        Me.lblDiioLote.AutoSize = True
        Me.lblDiioLote.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiioLote.Location = New System.Drawing.Point(94, 60)
        Me.lblDiioLote.Name = "lblDiioLote"
        Me.lblDiioLote.Size = New System.Drawing.Size(119, 37)
        Me.lblDiioLote.TabIndex = 247
        Me.lblDiioLote.Text = "Numero"
        '
        'lblDiio
        '
        Me.lblDiio.AutoSize = True
        Me.lblDiio.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiio.Location = New System.Drawing.Point(9, 60)
        Me.lblDiio.Name = "lblDiio"
        Me.lblDiio.Size = New System.Drawing.Size(74, 37)
        Me.lblDiio.TabIndex = 248
        Me.lblDiio.Text = "Diio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 37)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = "Centro:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 321)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(207, 24)
        Me.Label2.TabIndex = 250
        Me.Label2.Text = "Fecha Ingreso a Ordeña"
        '
        'dtpFechaCierre
        '
        Me.dtpFechaCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaCierre.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCierre.Location = New System.Drawing.Point(239, 317)
        Me.dtpFechaCierre.Name = "dtpFechaCierre"
        Me.dtpFechaCierre.Size = New System.Drawing.Size(140, 24)
        Me.dtpFechaCierre.TabIndex = 251
        '
        'lblFecLeche
        '
        Me.lblFecLeche.AutoSize = True
        Me.lblFecLeche.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecLeche.Location = New System.Drawing.Point(134, 190)
        Me.lblFecLeche.Name = "lblFecLeche"
        Me.lblFecLeche.Size = New System.Drawing.Size(0, 24)
        Me.lblFecLeche.TabIndex = 252
        '
        'lblFecCarne
        '
        Me.lblFecCarne.AutoSize = True
        Me.lblFecCarne.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecCarne.Location = New System.Drawing.Point(465, 190)
        Me.lblFecCarne.Name = "lblFecCarne"
        Me.lblFecCarne.Size = New System.Drawing.Size(0, 30)
        Me.lblFecCarne.TabIndex = 253
        '
        'lblNomPatologia
        '
        Me.lblNomPatologia.AutoSize = True
        Me.lblNomPatologia.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomPatologia.Location = New System.Drawing.Point(134, 242)
        Me.lblNomPatologia.Name = "lblNomPatologia"
        Me.lblNomPatologia.Size = New System.Drawing.Size(88, 24)
        Me.lblNomPatologia.TabIndex = 254
        Me.lblNomPatologia.Text = "Patologia"
        '
        'lblNomMedicamento
        '
        Me.lblNomMedicamento.AutoSize = True
        Me.lblNomMedicamento.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomMedicamento.Location = New System.Drawing.Point(471, 242)
        Me.lblNomMedicamento.Name = "lblNomMedicamento"
        Me.lblNomMedicamento.Size = New System.Drawing.Size(126, 24)
        Me.lblNomMedicamento.TabIndex = 255
        Me.lblNomMedicamento.Text = "Medicamento"
        '
        'lblCentro
        '
        Me.lblCentro.AutoSize = True
        Me.lblCentro.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCentro.Location = New System.Drawing.Point(131, 120)
        Me.lblCentro.Name = "lblCentro"
        Me.lblCentro.Size = New System.Drawing.Size(100, 37)
        Me.lblCentro.TabIndex = 256
        Me.lblCentro.Text = "Centro"
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(530, 378)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(128, 41)
        Me.btnCerrar.TabIndex = 246
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(12, 378)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(128, 41)
        Me.btnGrabar.TabIndex = 245
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'lblCodPat
        '
        Me.lblCodPat.AutoSize = True
        Me.lblCodPat.Location = New System.Drawing.Point(135, 266)
        Me.lblCodPat.Name = "lblCodPat"
        Me.lblCodPat.Size = New System.Drawing.Size(51, 17)
        Me.lblCodPat.TabIndex = 257
        Me.lblCodPat.Text = "Label4"
        Me.lblCodPat.Visible = False
        '
        'lblCodMed
        '
        Me.lblCodMed.AutoSize = True
        Me.lblCodMed.Location = New System.Drawing.Point(473, 266)
        Me.lblCodMed.Name = "lblCodMed"
        Me.lblCodMed.Size = New System.Drawing.Size(51, 17)
        Me.lblCodMed.TabIndex = 258
        Me.lblCodMed.Text = "Label4"
        Me.lblCodMed.Visible = False
        '
        'frmPabcoLiberarLeche
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 432)
        Me.Controls.Add(Me.lblCodMed)
        Me.Controls.Add(Me.lblCodPat)
        Me.Controls.Add(Me.lblCentro)
        Me.Controls.Add(Me.lblNomMedicamento)
        Me.Controls.Add(Me.lblNomPatologia)
        Me.Controls.Add(Me.lblFecCarne)
        Me.Controls.Add(Me.lblFecLeche)
        Me.Controls.Add(Me.dtpFechaCierre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblDiio)
        Me.Controls.Add(Me.lblDiioLote)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.lblMedicamento)
        Me.Controls.Add(Me.lblPatologia)
        Me.Controls.Add(Me.lblCarne)
        Me.Controls.Add(Me.lblLiberacionLeche)
        Me.Controls.Add(Me.lblLote)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPabcoLiberarLeche"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblLote As Label
    Friend WithEvents lblLiberacionLeche As Label
    Friend WithEvents lblCarne As Label
    Friend WithEvents lblPatologia As Label
    Friend WithEvents lblMedicamento As Label
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lblDiioLote As Label
    Friend WithEvents lblDiio As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpFechaCierre As DateTimePicker
    Friend WithEvents lblFecLeche As Label
    Friend WithEvents lblFecCarne As Label
    Friend WithEvents lblNomPatologia As Label
    Friend WithEvents lblNomMedicamento As Label
    Friend WithEvents lblCentro As Label
    Friend WithEvents lblCodPat As Label
    Friend WithEvents lblCodMed As Label
End Class
