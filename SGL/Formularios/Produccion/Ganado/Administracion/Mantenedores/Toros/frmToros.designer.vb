<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToros
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmToros))
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.pnlTotales = New System.Windows.Forms.Panel()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboVigente = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblOrdena = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboRazas = New System.Windows.Forms.ComboBox()
        Me.lvTOROS = New System.Windows.Forms.ListView()
        Me.N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Empresa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Codigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Raza = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Vigente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Sexadoo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.obs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.mnuVigente = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuToroVigente = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuToroQuitarVigente = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Sexado = New System.Windows.Forms.GroupBox()
        Me.cboSexado = New System.Windows.Forms.ComboBox()
        Me.ABCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlTotales.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.mnuVigente.SuspendLayout()
        Me.Sexado.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(985, 70)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 30)
        Me.btnBuscar.TabIndex = 56
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(198, 576)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 10
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(985, 576)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 27
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'pnlTotales
        '
        Me.pnlTotales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTotales.Controls.Add(Me.Label48)
        Me.pnlTotales.Controls.Add(Me.Label86)
        Me.pnlTotales.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTotales.Location = New System.Drawing.Point(12, 544)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.Size = New System.Drawing.Size(1060, 25)
        Me.pnlTotales.TabIndex = 62
        '
        'Label48
        '
        Me.Label48.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(143, 2)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(65, 21)
        Me.Label48.TabIndex = 41
        Me.Label48.Text = "0"
        '
        'Label86
        '
        Me.Label86.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(4, 2)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(140, 21)
        Me.Label86.TabIndex = 0
        Me.Label86.Text = "TOTAL TOROS"
        '
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(213, 269)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(655, 53)
        Me.pnlProcesa.TabIndex = 68
        Me.pnlProcesa.Visible = False
        '
        'lblProcesa
        '
        Me.lblProcesa.AutoSize = True
        Me.lblProcesa.Location = New System.Drawing.Point(9, 9)
        Me.lblProcesa.Name = "lblProcesa"
        Me.lblProcesa.Size = New System.Drawing.Size(91, 18)
        Me.lblProcesa.TabIndex = 69
        Me.lblProcesa.Text = "Exportando..."
        '
        'pbProcesa
        '
        Me.pbProcesa.Location = New System.Drawing.Point(12, 23)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(625, 18)
        Me.pbProcesa.TabIndex = 68
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboVigente)
        Me.GroupBox2.Location = New System.Drawing.Point(267, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(125, 50)
        Me.GroupBox2.TabIndex = 72
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vigente"
        '
        'cboVigente
        '
        Me.cboVigente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVigente.FormattingEnabled = True
        Me.cboVigente.Location = New System.Drawing.Point(9, 19)
        Me.cboVigente.Name = "cboVigente"
        Me.cboVigente.Size = New System.Drawing.Size(106, 26)
        Me.cboVigente.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-4, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1097, 41)
        Me.Panel1.TabIndex = 73
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1060, 29)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "TOROS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltro.Image = CType(resources.GetObject("btnLimpiarFiltro.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(932, 70)
        Me.btnLimpiarFiltro.Name = "btnLimpiarFiltro"
        Me.btnLimpiarFiltro.Size = New System.Drawing.Size(50, 30)
        Me.btnLimpiarFiltro.TabIndex = 76
        Me.btnLimpiarFiltro.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblOrdena)
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(12, 106)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1060, 23)
        Me.Panel2.TabIndex = 75
        '
        'lblOrdena
        '
        Me.lblOrdena.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrdena.ForeColor = System.Drawing.Color.White
        Me.lblOrdena.Location = New System.Drawing.Point(115, 1)
        Me.lblOrdena.Name = "lblOrdena"
        Me.lblOrdena.Size = New System.Drawing.Size(934, 19)
        Me.lblOrdena.TabIndex = 0
        Me.lblOrdena.Text = "Nombre"
        Me.lblOrdena.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(8, 1)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(121, 19)
        Me.Label61.TabIndex = 1
        Me.Label61.Text = "ORDENAR POR:"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboRazas)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 50)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(249, 50)
        Me.GroupBox3.TabIndex = 78
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Raza"
        '
        'cboRazas
        '
        Me.cboRazas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRazas.FormattingEnabled = True
        Me.cboRazas.Location = New System.Drawing.Point(8, 19)
        Me.cboRazas.Name = "cboRazas"
        Me.cboRazas.Size = New System.Drawing.Size(233, 26)
        Me.cboRazas.TabIndex = 0
        '
        'lvTOROS
        '
        Me.lvTOROS.AutoArrange = False
        Me.lvTOROS.BackColor = System.Drawing.SystemColors.Window
        Me.lvTOROS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.N, Me.Empresa, Me.Codigo, Me.ABCode, Me.Nombre, Me.Raza, Me.Vigente, Me.Sexadoo, Me.obs})
        Me.lvTOROS.ContextMenuStrip = Me.mnuVigente
        Me.lvTOROS.FullRowSelect = True
        Me.lvTOROS.GridLines = True
        Me.lvTOROS.HideSelection = False
        Me.lvTOROS.Location = New System.Drawing.Point(12, 135)
        Me.lvTOROS.MultiSelect = False
        Me.lvTOROS.Name = "lvTOROS"
        Me.lvTOROS.Size = New System.Drawing.Size(1060, 405)
        Me.lvTOROS.TabIndex = 82
        Me.lvTOROS.UseCompatibleStateImageBehavior = False
        Me.lvTOROS.View = System.Windows.Forms.View.Details
        '
        'N
        '
        Me.N.Text = "Nro"
        Me.N.Width = 40
        '
        'Empresa
        '
        Me.Empresa.Text = "Empresa"
        Me.Empresa.Width = 0
        '
        'Codigo
        '
        Me.Codigo.Text = "Código"
        Me.Codigo.Width = 95
        '
        'Nombre
        '
        Me.Nombre.Text = "Nombre"
        Me.Nombre.Width = 250
        '
        'Raza
        '
        Me.Raza.Text = "Raza"
        Me.Raza.Width = 180
        '
        'Vigente
        '
        Me.Vigente.Text = "Vigente"
        Me.Vigente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Vigente.Width = 70
        '
        'Sexadoo
        '
        Me.Sexadoo.Text = "Sexado"
        Me.Sexadoo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Sexadoo.Width = 70
        '
        'obs
        '
        Me.obs.Text = "Observación"
        Me.obs.Width = 290
        '
        'mnuVigente
        '
        Me.mnuVigente.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuVigente.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuToroVigente, Me.mnuToroQuitarVigente})
        Me.mnuVigente.Name = "mnuVigente"
        Me.mnuVigente.Size = New System.Drawing.Size(175, 52)
        '
        'mnuToroVigente
        '
        Me.mnuToroVigente.Name = "mnuToroVigente"
        Me.mnuToroVigente.Size = New System.Drawing.Size(174, 24)
        Me.mnuToroVigente.Text = "Vigente"
        '
        'mnuToroQuitarVigente
        '
        Me.mnuToroQuitarVigente.Name = "mnuToroQuitarVigente"
        Me.mnuToroQuitarVigente.Size = New System.Drawing.Size(174, 24)
        Me.mnuToroQuitarVigente.Text = "Quitar Vigente"
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 576)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 83
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(105, 576)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 85
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Sexado
        '
        Me.Sexado.Controls.Add(Me.cboSexado)
        Me.Sexado.Location = New System.Drawing.Point(398, 50)
        Me.Sexado.Name = "Sexado"
        Me.Sexado.Size = New System.Drawing.Size(125, 50)
        Me.Sexado.TabIndex = 86
        Me.Sexado.TabStop = False
        Me.Sexado.Text = "Sexado"
        '
        'cboSexado
        '
        Me.cboSexado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSexado.FormattingEnabled = True
        Me.cboSexado.Location = New System.Drawing.Point(9, 19)
        Me.cboSexado.Name = "cboSexado"
        Me.cboSexado.Size = New System.Drawing.Size(106, 26)
        Me.cboSexado.TabIndex = 1
        '
        'ABCode
        '
        Me.ABCode.Text = "BW Codigo"
        Me.ABCode.Width = 95
        '
        'frmToros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1090, 618)
        Me.ControlBox = False
        Me.Controls.Add(Me.Sexado)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlTotales)
        Me.Controls.Add(Me.lvTOROS)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmToros"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = " "
        Me.pnlTotales.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.mnuVigente.ResumeLayout(False)
        Me.Sexado.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents pnlTotales As System.Windows.Forms.Panel
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarFiltro As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblOrdena As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboRazas As System.Windows.Forms.ComboBox
    Friend WithEvents lvTOROS As System.Windows.Forms.ListView
    Friend WithEvents N As System.Windows.Forms.ColumnHeader
    Friend WithEvents Empresa As System.Windows.Forms.ColumnHeader
    Friend WithEvents Codigo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Vigente As System.Windows.Forms.ColumnHeader
    Friend WithEvents Nombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents obs As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Sexadoo As System.Windows.Forms.ColumnHeader
    Friend WithEvents Raza As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents cboVigente As System.Windows.Forms.ComboBox
    Friend WithEvents Sexado As System.Windows.Forms.GroupBox
    Friend WithEvents cboSexado As System.Windows.Forms.ComboBox
    Friend WithEvents mnuVigente As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuToroVigente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuToroQuitarVigente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ABCode As ColumnHeader
End Class
