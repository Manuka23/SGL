<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeneticaIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneticaIngreso))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvlCargaGenetica = New System.Windows.Forms.ListView()
        Me.N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ABCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ABName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BreedCat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.BreedingWorth = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnBuscarExcel = New System.Windows.Forms.Button()
        Me.txtRutaExcel = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.btnIngresoManual = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(999, 44)
        Me.Panel1.TabIndex = 187
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(975, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "INGRESO GENÉTICA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvlCargaGenetica
        '
        Me.lvlCargaGenetica.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.N, Me.ABCode, Me.ABName, Me.BreedCat, Me.BreedingWorth})
        Me.lvlCargaGenetica.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlCargaGenetica.GridLines = True
        Me.lvlCargaGenetica.HideSelection = False
        Me.lvlCargaGenetica.Location = New System.Drawing.Point(12, 122)
        Me.lvlCargaGenetica.Name = "lvlCargaGenetica"
        Me.lvlCargaGenetica.Size = New System.Drawing.Size(975, 427)
        Me.lvlCargaGenetica.TabIndex = 188
        Me.lvlCargaGenetica.UseCompatibleStateImageBehavior = False
        Me.lvlCargaGenetica.View = System.Windows.Forms.View.Details
        '
        'N
        '
        Me.N.Text = "N°"
        Me.N.Width = 35
        '
        'ABCode
        '
        Me.ABCode.Text = "Código"
        Me.ABCode.Width = 115
        '
        'ABName
        '
        Me.ABName.Text = "Nombre"
        Me.ABName.Width = 220
        '
        'BreedCat
        '
        Me.BreedCat.Text = "Raza"
        Me.BreedCat.Width = 195
        '
        'BreedingWorth
        '
        Me.BreedingWorth.Text = "Valor Cría"
        Me.BreedingWorth.Width = 145
        '
        'btnBuscarExcel
        '
        Me.btnBuscarExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarExcel.Image = CType(resources.GetObject("btnBuscarExcel.Image"), System.Drawing.Image)
        Me.btnBuscarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarExcel.Location = New System.Drawing.Point(6, 21)
        Me.btnBuscarExcel.Name = "btnBuscarExcel"
        Me.btnBuscarExcel.Size = New System.Drawing.Size(165, 34)
        Me.btnBuscarExcel.TabIndex = 189
        Me.btnBuscarExcel.Text = "Buscar Excel"
        Me.btnBuscarExcel.UseVisualStyleBackColor = True
        '
        'txtRutaExcel
        '
        Me.txtRutaExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaExcel.Location = New System.Drawing.Point(177, 26)
        Me.txtRutaExcel.Name = "txtRutaExcel"
        Me.txtRutaExcel.Size = New System.Drawing.Size(542, 26)
        Me.txtRutaExcel.TabIndex = 190
        '
        'dtpFecha
        '
        Me.dtpFecha.CalendarFont = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(113, 26)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(116, 26)
        Me.dtpFecha.TabIndex = 191
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscarExcel)
        Me.GroupBox1.Controls.Add(Me.txtRutaExcel)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(725, 66)
        Me.GroupBox1.TabIndex = 192
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Excel"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtpFecha)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(743, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(244, 66)
        Me.GroupBox2.TabIndex = 193
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Fecha"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 18)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "Fecha Carga"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(881, 557)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(105, 38)
        Me.btnSalir.TabIndex = 194
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCargar.Location = New System.Drawing.Point(12, 557)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(108, 38)
        Me.btnCargar.TabIndex = 195
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'OpenFDlg
        '
        Me.OpenFDlg.FileName = "OpenFileDialog1"
        '
        'btnIngresoManual
        '
        Me.btnIngresoManual.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresoManual.Image = CType(resources.GetObject("btnIngresoManual.Image"), System.Drawing.Image)
        Me.btnIngresoManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresoManual.Location = New System.Drawing.Point(126, 557)
        Me.btnIngresoManual.Name = "btnIngresoManual"
        Me.btnIngresoManual.Size = New System.Drawing.Size(174, 38)
        Me.btnIngresoManual.TabIndex = 196
        Me.btnIngresoManual.Text = "Ingreso Manual"
        Me.btnIngresoManual.UseVisualStyleBackColor = True
        '
        'frmGeneticaIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 605)
        Me.Controls.Add(Me.btnIngresoManual)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvlCargaGenetica)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGeneticaIngreso"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents lvlCargaGenetica As ListView
    Friend WithEvents btnBuscarExcel As Button
    Friend WithEvents txtRutaExcel As TextBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnCargar As Button
    Friend WithEvents OpenFDlg As OpenFileDialog
    Friend WithEvents N As ColumnHeader
    Friend WithEvents ABCode As ColumnHeader
    Friend WithEvents ABName As ColumnHeader
    Friend WithEvents BreedCat As ColumnHeader
    Friend WithEvents BreedingWorth As ColumnHeader
    Friend WithEvents btnIngresoManual As Button
End Class
