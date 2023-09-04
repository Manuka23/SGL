<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFertilizante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFertilizante))
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.lvFertilizado = New System.Windows.Forms.ListView()
        Me.N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EmpresaCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Centro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotalPotreros = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TotPotrerosAplicado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Hectareas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.HectareasApl = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TipoUso = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FertCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fertilizante = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FerTotalAplicado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodGP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaReg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UsuCreador = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(7, 21)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(250, 26)
        Me.cboCentros.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1478, 44)
        Me.Panel1.TabIndex = 186
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1453, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Fertilizados"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(265, 56)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(283, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(380, 56)
        Me.GroupBox2.TabIndex = 187
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(259, 21)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(115, 26)
        Me.dtpFechaHasta.TabIndex = 188
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Desde"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(70, 21)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(119, 26)
        Me.dtpFechaDesde.TabIndex = 0
        '
        'lvFertilizado
        '
        Me.lvFertilizado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.N, Me.EmpresaCod, Me.CentroCod, Me.Centro, Me.Fecha, Me.TotalPotreros, Me.TotPotrerosAplicado, Me.Hectareas, Me.HectareasApl, Me.TipoUso, Me.FertCod, Me.Fertilizante, Me.FerTotalAplicado, Me.CodGP, Me.FechaReg, Me.UsuCreador})
        Me.lvFertilizado.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvFertilizado.FullRowSelect = True
        Me.lvFertilizado.GridLines = True
        Me.lvFertilizado.HideSelection = False
        Me.lvFertilizado.Location = New System.Drawing.Point(12, 112)
        Me.lvFertilizado.Name = "lvFertilizado"
        Me.lvFertilizado.Size = New System.Drawing.Size(1453, 394)
        Me.lvFertilizado.TabIndex = 191
        Me.lvFertilizado.UseCompatibleStateImageBehavior = False
        Me.lvFertilizado.View = System.Windows.Forms.View.Details
        '
        'N
        '
        Me.N.Text = "N°"
        Me.N.Width = 35
        '
        'EmpresaCod
        '
        Me.EmpresaCod.Text = "EmpresaCod"
        Me.EmpresaCod.Width = 0
        '
        'CentroCod
        '
        Me.CentroCod.Text = "Centro Cod."
        Me.CentroCod.Width = 0
        '
        'Centro
        '
        Me.Centro.Text = "Centro"
        Me.Centro.Width = 160
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Fecha.Width = 80
        '
        'TotalPotreros
        '
        Me.TotalPotreros.Text = "Tot. Potreros"
        Me.TotalPotreros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TotalPotreros.Width = 80
        '
        'TotPotrerosAplicado
        '
        Me.TotPotrerosAplicado.Text = "Pot Apl."
        Me.TotPotrerosAplicado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Hectareas
        '
        Me.Hectareas.Text = "Ha Total"
        Me.Hectareas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'HectareasApl
        '
        Me.HectareasApl.Text = "Ha Apl."
        Me.HectareasApl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TipoUso
        '
        Me.TipoUso.Text = "Tipo Uso"
        Me.TipoUso.Width = 115
        '
        'FertCod
        '
        Me.FertCod.Text = "FertCod"
        Me.FertCod.Width = 0
        '
        'Fertilizante
        '
        Me.Fertilizante.Text = "Fertilizante"
        Me.Fertilizante.Width = 150
        '
        'FerTotalAplicado
        '
        Me.FerTotalAplicado.Text = "Fert. Tot. Aplicado"
        Me.FerTotalAplicado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.FerTotalAplicado.Width = 125
        '
        'CodGP
        '
        Me.CodGP.Text = "N. Doc. GP"
        Me.CodGP.Width = 120
        '
        'FechaReg
        '
        Me.FechaReg.Text = "Fecha Reg."
        Me.FechaReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.FechaReg.Width = 115
        '
        'UsuCreador
        '
        Me.UsuCreador.Text = "Usuario Creador"
        Me.UsuCreador.Width = 120
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 512)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(119, 42)
        Me.btnAgregar.TabIndex = 190
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(1358, 511)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(107, 42)
        Me.btnCerrar.TabIndex = 189
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(1358, 56)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(107, 41)
        Me.btnBuscar.TabIndex = 188
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'frmFertilizante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1477, 565)
        Me.Controls.Add(Me.lvFertilizado)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFertilizante"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboCentros As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents lvFertilizado As ListView
    Friend WithEvents N As ColumnHeader
    Friend WithEvents EmpresaCod As ColumnHeader
    Friend WithEvents CentroCod As ColumnHeader
    Friend WithEvents Centro As ColumnHeader
    Friend WithEvents Fertilizante As ColumnHeader
    Friend WithEvents FerTotalAplicado As ColumnHeader
    Friend WithEvents TotalPotreros As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents FechaReg As ColumnHeader
    Friend WithEvents CodGP As ColumnHeader
    Friend WithEvents UsuCreador As ColumnHeader
    Friend WithEvents TipoUso As ColumnHeader
    Friend WithEvents FertCod As ColumnHeader
    Friend WithEvents TotPotrerosAplicado As ColumnHeader
    Friend WithEvents Hectareas As ColumnHeader
    Friend WithEvents HectareasApl As ColumnHeader
End Class
