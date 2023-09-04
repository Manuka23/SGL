<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLuzMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLuzMenu))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxMes = New System.Windows.Forms.ComboBox()
        Me.gbYear = New System.Windows.Forms.GroupBox()
        Me.cbxYear = New System.Windows.Forms.ComboBox()
        Me.lvReporte = New System.Windows.Forms.ListView()
        Me.CodCentro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Centro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Casa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Con = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Consumo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbxCentros = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.gbxMantenedores = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.gbYear.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbxMantenedores.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxMes)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(404, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(190, 57)
        Me.GroupBox1.TabIndex = 217
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
        'gbYear
        '
        Me.gbYear.Controls.Add(Me.cbxYear)
        Me.gbYear.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbYear.Location = New System.Drawing.Point(208, 12)
        Me.gbYear.Name = "gbYear"
        Me.gbYear.Size = New System.Drawing.Size(190, 57)
        Me.gbYear.TabIndex = 216
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
        'lvReporte
        '
        Me.lvReporte.AutoArrange = False
        Me.lvReporte.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CodCentro, Me.Centro, Me.Casa, Me.Con, Me.Consumo})
        Me.lvReporte.FullRowSelect = True
        Me.lvReporte.GridLines = True
        Me.lvReporte.Location = New System.Drawing.Point(12, 82)
        Me.lvReporte.Name = "lvReporte"
        Me.lvReporte.Size = New System.Drawing.Size(582, 299)
        Me.lvReporte.TabIndex = 215
        Me.lvReporte.UseCompatibleStateImageBehavior = False
        Me.lvReporte.View = System.Windows.Forms.View.Details
        '
        'CodCentro
        '
        Me.CodCentro.Text = "Cod Centro"
        Me.CodCentro.Width = 83
        '
        'Centro
        '
        Me.Centro.Text = "Centro"
        Me.Centro.Width = 206
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
        Me.Consumo.Width = 100
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.SGL.My.Resources.Resources.door_out
        Me.btnSalir.Location = New System.Drawing.Point(507, 458)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 218
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbxCentros)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(190, 57)
        Me.GroupBox2.TabIndex = 219
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Centro"
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(161, 60)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 220
        Me.Button1.Text = "Parametros"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(153, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 23)
        Me.Button2.TabIndex = 221
        Me.Button2.Text = "Clasificacion sitios"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(267, 27)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 23)
        Me.Button3.TabIndex = 222
        Me.Button3.Text = "Poblacion/barrio"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(13, 26)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(134, 23)
        Me.Button4.TabIndex = 223
        Me.Button4.Text = "Relacion con la empresa"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(61, 60)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(94, 23)
        Me.Button5.TabIndex = 225
        Me.Button5.Text = "Editar Consumo"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(242, 60)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 226
        Me.Button6.Text = "Casas"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'gbxMantenedores
        '
        Me.gbxMantenedores.Controls.Add(Me.Button2)
        Me.gbxMantenedores.Controls.Add(Me.Button6)
        Me.gbxMantenedores.Controls.Add(Me.Button1)
        Me.gbxMantenedores.Controls.Add(Me.Button5)
        Me.gbxMantenedores.Controls.Add(Me.Button3)
        Me.gbxMantenedores.Controls.Add(Me.Button4)
        Me.gbxMantenedores.Location = New System.Drawing.Point(115, 387)
        Me.gbxMantenedores.Name = "gbxMantenedores"
        Me.gbxMantenedores.Size = New System.Drawing.Size(376, 101)
        Me.gbxMantenedores.TabIndex = 227
        Me.gbxMantenedores.TabStop = False
        Me.gbxMantenedores.Text = "Mantenedores"
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.SGL.My.Resources.Resources.add
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 458)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 224
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'frmLuzMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606, 495)
        Me.Controls.Add(Me.gbxMantenedores)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbYear)
        Me.Controls.Add(Me.lvReporte)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLuzMenu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consumo de Luz"
        Me.GroupBox1.ResumeLayout(False)
        Me.gbYear.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.gbxMantenedores.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbxMes As ComboBox
    Friend WithEvents gbYear As GroupBox
    Friend WithEvents cbxYear As ComboBox
    Friend WithEvents lvReporte As ListView
    Friend WithEvents CodCentro As ColumnHeader
    Friend WithEvents Centro As ColumnHeader
    Friend WithEvents Casa As ColumnHeader
    Friend WithEvents Con As ColumnHeader
    Friend WithEvents Consumo As ColumnHeader
    Friend WithEvents btnSalir As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbxCentros As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents gbxMantenedores As GroupBox
End Class
