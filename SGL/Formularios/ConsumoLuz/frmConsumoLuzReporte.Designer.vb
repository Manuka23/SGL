<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsumoLuzReporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsumoLuzReporte))
        Me.lvReporte = New System.Windows.Forms.ListView()
        Me.CodCentro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Centro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Casa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Con = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Consumo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.gbYear = New System.Windows.Forms.GroupBox()
        Me.cbxYear = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxMes = New System.Windows.Forms.ComboBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.modificar = New System.Windows.Forms.Button()
        Me.gbYear.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvReporte
        '
        Me.lvReporte.AutoArrange = False
        Me.lvReporte.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CodCentro, Me.Centro, Me.Casa, Me.Con, Me.Consumo, Me.ColumnHeader1})
        Me.lvReporte.FullRowSelect = True
        Me.lvReporte.GridLines = True
        Me.lvReporte.Location = New System.Drawing.Point(12, 75)
        Me.lvReporte.Name = "lvReporte"
        Me.lvReporte.Size = New System.Drawing.Size(524, 346)
        Me.lvReporte.TabIndex = 0
        Me.lvReporte.UseCompatibleStateImageBehavior = False
        Me.lvReporte.View = System.Windows.Forms.View.Details
        '
        'CodCentro
        '
        Me.CodCentro.Text = "Cod Centro"
        Me.CodCentro.Width = 84
        '
        'Centro
        '
        Me.Centro.Text = "Centro"
        Me.Centro.Width = 147
        '
        'Casa
        '
        Me.Casa.Text = "Casa"
        Me.Casa.Width = 77
        '
        'Con
        '
        Me.Con.Text = "Consumo Acum. Kw"
        Me.Con.Width = 109
        '
        'Consumo
        '
        Me.Consumo.Text = "Consumo Kw"
        Me.Consumo.Width = 84
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Cod"
        Me.ColumnHeader1.Width = 0
        '
        'gbYear
        '
        Me.gbYear.Controls.Add(Me.cbxYear)
        Me.gbYear.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbYear.Location = New System.Drawing.Point(12, 12)
        Me.gbYear.Name = "gbYear"
        Me.gbYear.Size = New System.Drawing.Size(190, 57)
        Me.gbYear.TabIndex = 213
        Me.gbYear.TabStop = False
        Me.gbYear.Text = "Año"
        '
        'cbxYear
        '
        Me.cbxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxYear.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxYear.FormattingEnabled = True
        Me.cbxYear.Location = New System.Drawing.Point(11, 20)
        Me.cbxYear.Name = "cbxYear"
        Me.cbxYear.Size = New System.Drawing.Size(166, 26)
        Me.cbxYear.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxMes)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(224, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(190, 57)
        Me.GroupBox1.TabIndex = 214
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Mes"
        '
        'cbxMes
        '
        Me.cbxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMes.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMes.FormattingEnabled = True
        Me.cbxMes.Location = New System.Drawing.Point(11, 20)
        Me.cbxMes.Name = "cbxMes"
        Me.cbxMes.Size = New System.Drawing.Size(166, 26)
        Me.cbxMes.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SGL.My.Resources.Resources.door_out
        Me.btnSalir.Location = New System.Drawing.Point(451, 437)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 217
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.SGL.My.Resources.Resources.arrow_down
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(117, 437)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(143, 30)
        Me.Button1.TabIndex = 219
        Me.Button1.Text = "   Descargar respaldo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'modificar
        '
        Me.modificar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modificar.Image = Global.SGL.My.Resources.Resources.page_edit
        Me.modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.modificar.Location = New System.Drawing.Point(14, 437)
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(87, 30)
        Me.modificar.TabIndex = 218
        Me.modificar.Text = "   Modificar"
        Me.modificar.UseVisualStyleBackColor = True
        '
        'frmConsumoLuzReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 473)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.modificar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbYear)
        Me.Controls.Add(Me.lvReporte)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsumoLuzReporte"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consumo Luz Reporte"
        Me.gbYear.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvReporte As ListView
    Friend WithEvents Centro As ColumnHeader
    Friend WithEvents Casa As ColumnHeader
    Friend WithEvents Consumo As ColumnHeader
    Friend WithEvents gbYear As GroupBox
    Friend WithEvents cbxYear As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbxMes As ComboBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents CodCentro As ColumnHeader
    Friend WithEvents modificar As Button
    Friend WithEvents Con As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
