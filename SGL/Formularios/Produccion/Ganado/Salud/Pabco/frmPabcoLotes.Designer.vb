<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPabcoLotes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPabcoLotes))
        Me.lvLoteo = New System.Windows.Forms.ListView()
        Me.N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Lote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TratFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodPat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Patologia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodMed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Medicamento = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NDiios = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Estado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ResLeche = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ResCarne = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCierreLote = New System.Windows.Forms.Button()
        Me.btnLiberarLote = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvLoteo
        '
        Me.lvLoteo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.N, Me.CentroCod, Me.CentroNom, Me.Lote, Me.TratFecha, Me.CodPat, Me.Patologia, Me.CodMed, Me.Medicamento, Me.NDiios, Me.Estado, Me.ResLeche, Me.ResCarne})
        Me.lvLoteo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvLoteo.FullRowSelect = True
        Me.lvLoteo.GridLines = True
        Me.lvLoteo.HideSelection = False
        Me.lvLoteo.Location = New System.Drawing.Point(16, 113)
        Me.lvLoteo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.lvLoteo.MultiSelect = False
        Me.lvLoteo.Name = "lvLoteo"
        Me.lvLoteo.Size = New System.Drawing.Size(912, 335)
        Me.lvLoteo.TabIndex = 0
        Me.lvLoteo.UseCompatibleStateImageBehavior = False
        Me.lvLoteo.View = System.Windows.Forms.View.Details
        '
        'N
        '
        Me.N.Text = "N°"
        Me.N.Width = 33
        '
        'CentroCod
        '
        Me.CentroCod.Text = "Centro Cod."
        Me.CentroCod.Width = 0
        '
        'CentroNom
        '
        Me.CentroNom.Text = "Centro"
        Me.CentroNom.Width = 150
        '
        'Lote
        '
        Me.Lote.Text = "N° Lote"
        Me.Lote.Width = 89
        '
        'TratFecha
        '
        Me.TratFecha.Text = "Fecha Trat."
        Me.TratFecha.Width = 108
        '
        'CodPat
        '
        Me.CodPat.Text = "Cod. Patología"
        Me.CodPat.Width = 0
        '
        'Patologia
        '
        Me.Patologia.Text = "Patologia"
        Me.Patologia.Width = 179
        '
        'CodMed
        '
        Me.CodMed.Text = "Cod. Medicamento"
        Me.CodMed.Width = 0
        '
        'Medicamento
        '
        Me.Medicamento.Text = "Medicamento"
        Me.Medicamento.Width = 186
        '
        'NDiios
        '
        Me.NDiios.Text = "N° Diios"
        Me.NDiios.Width = 40
        '
        'Estado
        '
        Me.Estado.Text = "Estado"
        Me.Estado.Width = 75
        '
        'ResLeche
        '
        Me.ResLeche.Text = "Resg. Leche Fec."
        Me.ResLeche.Width = 100
        '
        'ResCarne
        '
        Me.ResCarne.Text = "Resg. Carne Fec"
        Me.ResCarne.Width = 100
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 54)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(245, 55)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(6, 20)
        Me.cboCentros.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(229, 26)
        Me.cboCentros.TabIndex = 0
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(55, 19)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(118, 26)
        Me.dtpFechaDesde.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpFechaDesde)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(267, 55)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox2.Size = New System.Drawing.Size(367, 54)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha"
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(238, 19)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(123, 26)
        Me.dtpFechaHasta.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(191, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Hasta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Desde"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(23, 4)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(903, 36)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Loteo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(2, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(953, 50)
        Me.Panel1.TabIndex = 237
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(827, 68)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(102, 36)
        Me.btnBuscar.TabIndex = 238
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(832, 452)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(96, 32)
        Me.btnCerrar.TabIndex = 239
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCierreLote
        '
        Me.btnCierreLote.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCierreLote.Image = CType(resources.GetObject("btnCierreLote.Image"), System.Drawing.Image)
        Me.btnCierreLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCierreLote.Location = New System.Drawing.Point(16, 455)
        Me.btnCierreLote.Name = "btnCierreLote"
        Me.btnCierreLote.Size = New System.Drawing.Size(146, 27)
        Me.btnCierreLote.TabIndex = 240
        Me.btnCierreLote.Text = "Crear Cierre Lote"
        Me.btnCierreLote.UseVisualStyleBackColor = True
        '
        'btnLiberarLote
        '
        Me.btnLiberarLote.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiberarLote.Image = CType(resources.GetObject("btnLiberarLote.Image"), System.Drawing.Image)
        Me.btnLiberarLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLiberarLote.Location = New System.Drawing.Point(168, 455)
        Me.btnLiberarLote.Name = "btnLiberarLote"
        Me.btnLiberarLote.Size = New System.Drawing.Size(191, 27)
        Me.btnLiberarLote.TabIndex = 241
        Me.btnLiberarLote.Text = "Liberar Leche Por Lote"
        Me.btnLiberarLote.UseVisualStyleBackColor = True
        '
        'frmPabcoLotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 489)
        Me.Controls.Add(Me.btnLiberarLote)
        Me.Controls.Add(Me.btnCierreLote)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvLoteo)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPabcoLotes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvLoteo As ListView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboCentros As ComboBox
    Friend WithEvents dtpFechaDesde As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpFechaHasta As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents N As ColumnHeader
    Friend WithEvents CentroCod As ColumnHeader
    Friend WithEvents CentroNom As ColumnHeader
    Friend WithEvents TratFecha As ColumnHeader
    Friend WithEvents Patologia As ColumnHeader
    Friend WithEvents Medicamento As ColumnHeader
    Friend WithEvents NDiios As ColumnHeader
    Friend WithEvents Lote As ColumnHeader
    Friend WithEvents Estado As ColumnHeader
    Friend WithEvents btnCierreLote As Button
    Friend WithEvents CodPat As ColumnHeader
    Friend WithEvents CodMed As ColumnHeader
    Friend WithEvents btnLiberarLote As Button
    Friend WithEvents ResLeche As ColumnHeader
    Friend WithEvents ResCarne As ColumnHeader
End Class
