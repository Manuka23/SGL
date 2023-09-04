<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMuestraLecheResultado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMuestraLecheResultado))
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.btnArchivo = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grpRetiro = New System.Windows.Forms.GroupBox()
        Me.lvGanado = New System.Windows.Forms.ListView()
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblMuestras = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.grpRetiro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtArchivo
        '
        Me.txtArchivo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtArchivo.Location = New System.Drawing.Point(6, 20)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(286, 23)
        Me.txtArchivo.TabIndex = 104
        Me.txtArchivo.Text = "[ Archivo Seleccionado ]"
        '
        'btnArchivo
        '
        Me.btnArchivo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchivo.Image = CType(resources.GetObject("btnArchivo.Image"), System.Drawing.Image)
        Me.btnArchivo.Location = New System.Drawing.Point(298, 16)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(87, 30)
        Me.btnArchivo.TabIndex = 105
        Me.btnArchivo.Text = "Archivo"
        Me.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(783, 523)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 37)
        Me.Button1.TabIndex = 271
        Me.Button1.Text = "Cerrar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grpRetiro
        '
        Me.grpRetiro.BackColor = System.Drawing.SystemColors.ControlLight
        Me.grpRetiro.Controls.Add(Me.lvGanado)
        Me.grpRetiro.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRetiro.Location = New System.Drawing.Point(5, 113)
        Me.grpRetiro.Name = "grpRetiro"
        Me.grpRetiro.Size = New System.Drawing.Size(868, 407)
        Me.grpRetiro.TabIndex = 269
        Me.grpRetiro.TabStop = False
        Me.grpRetiro.Text = "Resultado Muestras"
        '
        'lvGanado
        '
        Me.lvGanado.AutoArrange = False
        Me.lvGanado.BackColor = System.Drawing.SystemColors.Window
        Me.lvGanado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader6, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader9, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader2, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader5, Me.ColumnHeader8})
        Me.lvGanado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvGanado.FullRowSelect = True
        Me.lvGanado.GridLines = True
        Me.lvGanado.HideSelection = False
        Me.lvGanado.Location = New System.Drawing.Point(3, 19)
        Me.lvGanado.Name = "lvGanado"
        Me.lvGanado.Size = New System.Drawing.Size(862, 385)
        Me.lvGanado.TabIndex = 273
        Me.lvGanado.UseCompatibleStateImageBehavior = False
        Me.lvGanado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Nro"
        Me.ColumnHeader12.Width = 35
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Centro"
        Me.ColumnHeader6.Width = 104
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Codigo Barra"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 121
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "RCS"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 54
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Grasa"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 56
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Proteina"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Urea"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader14.Width = 53
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Densidad"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 62
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Crioscopia"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader7.Width = 68
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "UFC"
        Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader1.Width = 46
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "M.Solida"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 63
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Observacion"
        Me.ColumnHeader8.Width = 153
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(5, 523)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(93, 37)
        Me.btnGrabar.TabIndex = 267
        Me.btnGrabar.Text = "   Finalizar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtArchivo)
        Me.GroupBox1.Controls.Add(Me.btnArchivo)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblLote)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lblEstado)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblMuestras)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 105)
        Me.GroupBox1.TabIndex = 272
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informacion Muestras "
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblFecha.Location = New System.Drawing.Point(266, 78)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(86, 24)
        Me.lblFecha.TabIndex = 61
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(223, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 19)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Fecha:"
        '
        'lblLote
        '
        Me.lblLote.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.Location = New System.Drawing.Point(73, 53)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(97, 24)
        Me.lblLote.TabIndex = 59
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 53)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 24)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "N° Lote:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(73, 77)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(92, 24)
        Me.lblEstado.TabIndex = 56
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(22, 77)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(48, 24)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Estado:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblMuestras
        '
        Me.lblMuestras.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblMuestras.Location = New System.Drawing.Point(266, 53)
        Me.lblMuestras.Name = "lblMuestras"
        Me.lblMuestras.Size = New System.Drawing.Size(86, 24)
        Me.lblMuestras.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(171, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 24)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Num. Muestras:"
        '
        'OpenFDlg
        '
        Me.OpenFDlg.FileName = "OpenFileDialog1"
        '
        'frmMuestraLecheResultado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 566)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.grpRetiro)
        Me.Controls.Add(Me.btnGrabar)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMuestraLecheResultado"
        Me.ShowInTaskbar = False
        Me.Text = "Envio Resultado"
        Me.grpRetiro.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtArchivo As TextBox
    Friend WithEvents btnArchivo As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents grpRetiro As GroupBox
    Friend WithEvents btnGrabar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblLote As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblEstado As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblMuestras As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents OpenFDlg As OpenFileDialog
    Friend WithEvents lvGanado As ListView
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
End Class
