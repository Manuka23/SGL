<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsumoLuz_Ingreso
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsumoLuz_Ingreso))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxCentros = New System.Windows.Forms.ComboBox()
        Me.gboxKw = New System.Windows.Forms.GroupBox()
        Me.numKw = New System.Windows.Forms.NumericUpDown()
        Me.fbdArchivo = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbxCasa = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.ChartConsumo = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnArchivo = New System.Windows.Forms.Button()
        Me.pbImagen = New System.Windows.Forms.PictureBox()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.gboxKw.SuspendLayout()
        CType(Me.numKw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ChartConsumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxCentros)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(21, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(190, 57)
        Me.GroupBox1.TabIndex = 212
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cbxCentros
        '
        Me.cbxCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCentros.FormattingEnabled = True
        Me.cbxCentros.Location = New System.Drawing.Point(11, 20)
        Me.cbxCentros.Name = "cbxCentros"
        Me.cbxCentros.Size = New System.Drawing.Size(166, 26)
        Me.cbxCentros.TabIndex = 0
        '
        'gboxKw
        '
        Me.gboxKw.Controls.Add(Me.numKw)
        Me.gboxKw.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxKw.Location = New System.Drawing.Point(21, 181)
        Me.gboxKw.Name = "gboxKw"
        Me.gboxKw.Size = New System.Drawing.Size(190, 57)
        Me.gboxKw.TabIndex = 213
        Me.gboxKw.TabStop = False
        Me.gboxKw.Text = "kW"
        '
        'numKw
        '
        Me.numKw.Location = New System.Drawing.Point(34, 19)
        Me.numKw.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numKw.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numKw.Name = "numKw"
        Me.numKw.Size = New System.Drawing.Size(119, 26)
        Me.numKw.TabIndex = 0
        Me.numKw.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbxCasa)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(21, 93)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(190, 57)
        Me.GroupBox3.TabIndex = 213
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Casa"
        '
        'cbxCasa
        '
        Me.cbxCasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCasa.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCasa.FormattingEnabled = True
        Me.cbxCasa.Location = New System.Drawing.Point(11, 20)
        Me.cbxCasa.Name = "cbxCasa"
        Me.cbxCasa.Size = New System.Drawing.Size(171, 26)
        Me.cbxCasa.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnArchivo)
        Me.GroupBox4.Controls.Add(Me.pbImagen)
        Me.GroupBox4.Location = New System.Drawing.Point(252, 17)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(415, 307)
        Me.GroupBox4.TabIndex = 218
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Imagen"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblPeriodo)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 267)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(195, 57)
        Me.GroupBox2.TabIndex = 219
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periodo medicion"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Location = New System.Drawing.Point(8, 25)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(44, 18)
        Me.lblPeriodo.TabIndex = 0
        Me.lblPeriodo.Text = "Fecha"
        '
        'ChartConsumo
        '
        Me.ChartConsumo.BackColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ChartConsumo.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.ChartConsumo.BorderlineColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.ChartConsumo.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ChartConsumo.BorderlineWidth = 2
        Me.ChartConsumo.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss
        ChartArea1.Name = "ChartArea1"
        Me.ChartConsumo.ChartAreas.Add(ChartArea1)
        Me.ChartConsumo.IsSoftShadows = False
        Legend1.Name = "Legend1"
        Me.ChartConsumo.Legends.Add(Legend1)
        Me.ChartConsumo.Location = New System.Drawing.Point(21, 330)
        Me.ChartConsumo.Name = "ChartConsumo"
        Series1.ChartArea = "ChartArea1"
        Series1.LabelForeColor = System.Drawing.Color.DarkRed
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartConsumo.Series.Add(Series1)
        Me.ChartConsumo.Size = New System.Drawing.Size(646, 197)
        Me.ChartConsumo.TabIndex = 220
        Me.ChartConsumo.Text = "ChartConsumo"
        Title1.Name = "Title1"
        Me.ChartConsumo.Titles.Add(Title1)
        '
        'btnArchivo
        '
        Me.btnArchivo.Image = Global.SGL.My.Resources.Resources.folder_image
        Me.btnArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnArchivo.Location = New System.Drawing.Point(124, 16)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(156, 31)
        Me.btnArchivo.TabIndex = 0
        Me.btnArchivo.Text = "Seleccione Archivo"
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'pbImagen
        '
        Me.pbImagen.Location = New System.Drawing.Point(6, 57)
        Me.pbImagen.Name = "pbImagen"
        Me.pbImagen.Size = New System.Drawing.Size(403, 240)
        Me.pbImagen.TabIndex = 215
        Me.pbImagen.TabStop = False
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = Global.SGL.My.Resources.Resources.disk
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(12, 533)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 30)
        Me.btnGrabar.TabIndex = 217
        Me.btnGrabar.Text = "   Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SGL.My.Resources.Resources.door_out
        Me.btnSalir.Location = New System.Drawing.Point(605, 533)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 216
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmConsumoLuz_Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 575)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChartConsumo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.gboxKw)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsumoLuz_Ingreso"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingreso de Consumo de Luz"
        Me.GroupBox1.ResumeLayout(False)
        Me.gboxKw.ResumeLayout(False)
        CType(Me.numKw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ChartConsumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbxCentros As ComboBox
    Friend WithEvents gboxKw As GroupBox
    Friend WithEvents numKw As NumericUpDown
    Friend WithEvents btnArchivo As Button
    Friend WithEvents fbdArchivo As FolderBrowserDialog
    Friend WithEvents pbImagen As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbxCasa As ComboBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnGrabar As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents ChartConsumo As DataVisualization.Charting.Chart
End Class
