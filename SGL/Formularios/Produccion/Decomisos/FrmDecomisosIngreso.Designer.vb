<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDecomisosIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDecomisosIngreso))
        Me.CentroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.CentroCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaVtaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NroLinCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DecomisoCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.EstadoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label61 = New System.Windows.Forms.Label()
        Me.EmpresaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.OrdenaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvDecomisos = New System.Windows.Forms.ListView()
        Me.DiioCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FecDecomisoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CategCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CategoNomCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Decomiso = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CategoriaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cboCauDecomisos = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pbReLoadCausas = New System.Windows.Forms.PictureBox()
        Me.txtDIIO = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAsociarRespaldo = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.lvArchivosAsoc = New System.Windows.Forms.ListView()
        Me.OrderCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EmpCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LinCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodFileCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NomFileCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblArchivosAsociados = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.pbReLoadCausas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'CentroCol
        '
        Me.CentroCol.Text = "Centro"
        Me.CentroCol.Width = 143
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtpFecha)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(103, 57)
        Me.GroupBox5.TabIndex = 111
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(10, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(87, 20)
        Me.dtpFecha.TabIndex = 8
        '
        'CentroCodCol
        '
        Me.CentroCodCol.Text = "Centro Cod."
        Me.CentroCodCol.Width = 0
        '
        'FechaVtaCol
        '
        Me.FechaVtaCol.Text = "Fecha Vta."
        Me.FechaVtaCol.Width = 90
        '
        'NroLinCol
        '
        Me.NroLinCol.Text = "Nro"
        Me.NroLinCol.Width = 30
        '
        'DecomisoCodCol
        '
        Me.DecomisoCodCol.Text = "Dec. Cod."
        Me.DecomisoCodCol.Width = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Location = New System.Drawing.Point(-1, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 10)
        Me.Panel1.TabIndex = 119
        '
        'EstadoCol
        '
        Me.EstadoCol.Text = "Estado"
        Me.EstadoCol.Width = 73
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(-1, -1)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(875, 39)
        Me.Label61.TabIndex = 1
        Me.Label61.Text = "Ingreso Decomisos en Ventas"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EmpresaCol
        '
        Me.EmpresaCol.Text = "Empresa"
        Me.EmpresaCol.Width = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(879, 49)
        Me.Panel2.TabIndex = 118
        '
        'OrdenaCol
        '
        Me.OrdenaCol.Text = "Ordena"
        Me.OrdenaCol.Width = 0
        '
        'lvDecomisos
        '
        Me.lvDecomisos.AutoArrange = False
        Me.lvDecomisos.BackColor = System.Drawing.SystemColors.Window
        Me.lvDecomisos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OrdenaCol, Me.EmpresaCol, Me.NroLinCol, Me.DiioCol, Me.FecDecomisoCol, Me.CentroCodCol, Me.CentroCol, Me.CategCodCol, Me.CategoNomCol, Me.FechaVtaCol, Me.DecomisoCodCol, Me.Decomiso, Me.CategoriaCol, Me.EstadoCol})
        Me.lvDecomisos.FullRowSelect = True
        Me.lvDecomisos.GridLines = True
        Me.lvDecomisos.HideSelection = False
        Me.lvDecomisos.Location = New System.Drawing.Point(5, 119)
        Me.lvDecomisos.MultiSelect = False
        Me.lvDecomisos.Name = "lvDecomisos"
        Me.lvDecomisos.Size = New System.Drawing.Size(864, 199)
        Me.lvDecomisos.TabIndex = 117
        Me.lvDecomisos.UseCompatibleStateImageBehavior = False
        Me.lvDecomisos.View = System.Windows.Forms.View.Details
        '
        'DiioCol
        '
        Me.DiioCol.Text = "Diio"
        Me.DiioCol.Width = 73
        '
        'FecDecomisoCol
        '
        Me.FecDecomisoCol.Text = "Fecha Dec."
        Me.FecDecomisoCol.Width = 92
        '
        'CategCodCol
        '
        Me.CategCodCol.Text = "Categ. Cod."
        Me.CategCodCol.Width = 0
        '
        'CategoNomCol
        '
        Me.CategoNomCol.Text = "Categoria"
        Me.CategoNomCol.Width = 70
        '
        'Decomiso
        '
        Me.Decomiso.Text = "Decomiso"
        Me.Decomiso.Width = 171
        '
        'CategoriaCol
        '
        Me.CategoriaCol.Text = "Categoria Dec."
        Me.CategoriaCol.Width = 118
        '
        'cboCauDecomisos
        '
        Me.cboCauDecomisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCauDecomisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCauDecomisos.FormattingEnabled = True
        Me.cboCauDecomisos.Location = New System.Drawing.Point(6, 21)
        Me.cboCauDecomisos.Name = "cboCauDecomisos"
        Me.cboCauDecomisos.Size = New System.Drawing.Size(274, 23)
        Me.cboCauDecomisos.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboCauDecomisos)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(161, 58)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(286, 57)
        Me.GroupBox3.TabIndex = 112
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Causa Decomiso"
        '
        'pbReLoadCausas
        '
        Me.pbReLoadCausas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbReLoadCausas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbReLoadCausas.Location = New System.Drawing.Point(844, 354)
        Me.pbReLoadCausas.Name = "pbReLoadCausas"
        Me.pbReLoadCausas.Size = New System.Drawing.Size(25, 21)
        Me.pbReLoadCausas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbReLoadCausas.TabIndex = 1
        Me.pbReLoadCausas.TabStop = False
        '
        'txtDIIO
        '
        Me.txtDIIO.BackColor = System.Drawing.SystemColors.Window
        Me.txtDIIO.CausesValidation = False
        Me.txtDIIO.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIIO.Location = New System.Drawing.Point(6, 18)
        Me.txtDIIO.MaxLength = 20
        Me.txtDIIO.Name = "txtDIIO"
        Me.txtDIIO.Size = New System.Drawing.Size(149, 26)
        Me.txtDIIO.TabIndex = 100
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDIIO)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(505, 58)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(161, 57)
        Me.GroupBox2.TabIndex = 113
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Diio"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(782, 324)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 120
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(109, 324)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 116
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAsociarRespaldo
        '
        Me.btnAsociarRespaldo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsociarRespaldo.Image = CType(resources.GetObject("btnAsociarRespaldo.Image"), System.Drawing.Image)
        Me.btnAsociarRespaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsociarRespaldo.Location = New System.Drawing.Point(202, 324)
        Me.btnAsociarRespaldo.Name = "btnAsociarRespaldo"
        Me.btnAsociarRespaldo.Size = New System.Drawing.Size(146, 30)
        Me.btnAsociarRespaldo.TabIndex = 115
        Me.btnAsociarRespaldo.Text = "Asociar Respaldo"
        Me.btnAsociarRespaldo.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(16, 324)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 30)
        Me.btnGrabar.TabIndex = 114
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'lvArchivosAsoc
        '
        Me.lvArchivosAsoc.AutoArrange = False
        Me.lvArchivosAsoc.BackColor = System.Drawing.SystemColors.Window
        Me.lvArchivosAsoc.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.OrderCol, Me.EmpCol, Me.LinCol, Me.CodFileCol, Me.NomFileCol})
        Me.lvArchivosAsoc.FullRowSelect = True
        Me.lvArchivosAsoc.GridLines = True
        Me.lvArchivosAsoc.HideSelection = False
        Me.lvArchivosAsoc.Location = New System.Drawing.Point(5, 378)
        Me.lvArchivosAsoc.MultiSelect = False
        Me.lvArchivosAsoc.Name = "lvArchivosAsoc"
        Me.lvArchivosAsoc.Size = New System.Drawing.Size(864, 144)
        Me.lvArchivosAsoc.TabIndex = 121
        Me.lvArchivosAsoc.UseCompatibleStateImageBehavior = False
        Me.lvArchivosAsoc.View = System.Windows.Forms.View.Details
        '
        'OrderCol
        '
        Me.OrderCol.Text = "Ordena"
        Me.OrderCol.Width = 0
        '
        'EmpCol
        '
        Me.EmpCol.Text = "Empresa"
        Me.EmpCol.Width = 0
        '
        'LinCol
        '
        Me.LinCol.Text = "Nro"
        Me.LinCol.Width = 30
        '
        'CodFileCol
        '
        Me.CodFileCol.Text = "Codigo"
        Me.CodFileCol.Width = 73
        '
        'NomFileCol
        '
        Me.NomFileCol.Text = "Nombre Archivo"
        Me.NomFileCol.Width = 584
        '
        'lblArchivosAsociados
        '
        Me.lblArchivosAsociados.AutoSize = True
        Me.lblArchivosAsociados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArchivosAsociados.ForeColor = System.Drawing.Color.Red
        Me.lblArchivosAsociados.Location = New System.Drawing.Point(158, 359)
        Me.lblArchivosAsociados.Name = "lblArchivosAsociados"
        Me.lblArchivosAsociados.Size = New System.Drawing.Size(55, 16)
        Me.lblArchivosAsociados.TabIndex = 122
        Me.lblArchivosAsociados.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(2, 359)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 16)
        Me.Label1.TabIndex = 123
        Me.Label1.Text = "Archivos Asociados: "
        '
        'FrmDecomisosIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 524)
        Me.ControlBox = False
        Me.Controls.Add(Me.pbReLoadCausas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblArchivosAsociados)
        Me.Controls.Add(Me.lvArchivosAsoc)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lvDecomisos)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnAsociarRespaldo)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmDecomisosIngreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Decomisos por Animal"
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.pbReLoadCausas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CentroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents CentroCodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents FechaVtaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents NroLinCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DecomisoCodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents EstadoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents EmpresaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents OrdenaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvDecomisos As System.Windows.Forms.ListView
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAsociarRespaldo As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents cboCauDecomisos As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDIIO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Decomiso As System.Windows.Forms.ColumnHeader
    Friend WithEvents CategoriaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DiioCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CategCodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CategoNomCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents FecDecomisoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents pbReLoadCausas As System.Windows.Forms.PictureBox
    Friend WithEvents lvArchivosAsoc As System.Windows.Forms.ListView
    Friend WithEvents OrderCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents EmpCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents LinCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CodFileCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents NomFileCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblArchivosAsociados As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
