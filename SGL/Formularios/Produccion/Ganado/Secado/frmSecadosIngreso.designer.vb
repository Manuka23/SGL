<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSecadosIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSecadosIngreso))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkVerEliminados = New System.Windows.Forms.CheckBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        'Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        'Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.lvDIIOS = New System.Windows.Forms.ListView()
        Me.colLin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDIIO = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEstProd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFPP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFProbSec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDiasRealSec = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDiasLac = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colEstado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuGanado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopiarDiio = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnBastonLee = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblTotSecados = New System.Windows.Forms.Label()
        Me.lblTotEliminados = New System.Windows.Forms.Label()
        Me.lblTotErrores = New System.Windows.Forms.Label()
        Me.lblConErrores = New System.Windows.Forms.Label()
        Me.lblEliminados = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.colEstReprod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuGanado.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkVerEliminados)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.txtObservs)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(956, 152)
        Me.GroupBox1.TabIndex = 72
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Secado"
        '
        'chkVerEliminados
        '
        Me.chkVerEliminados.Location = New System.Drawing.Point(708, 29)
        Me.chkVerEliminados.Name = "chkVerEliminados"
        Me.chkVerEliminados.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkVerEliminados.Size = New System.Drawing.Size(181, 23)
        Me.chkVerEliminados.TabIndex = 107
        Me.chkVerEliminados.Text = "Ver Eliminados"
        Me.chkVerEliminados.UseVisualStyleBackColor = True
        Me.chkVerEliminados.Visible = False
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(564, 26)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(116, 26)
        Me.dtpFecha.TabIndex = 102
        '
        'txtObservs
        '
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(123, 70)
        Me.txtObservs.MaxLength = 500
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(766, 68)
        Me.txtObservs.TabIndex = 105
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(15, 70)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 23)
        Me.Label17.TabIndex = 106
        Me.Label17.Text = "Observaciones"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(123, 26)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(283, 26)
        Me.cboCentros.TabIndex = 101
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(469, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 23)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Fecha Secado"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 19)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Centro"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(881, 591)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label10)
        'Me.Panel1.Controls.Add(Me.ShapeContainer2)
        Me.Panel1.Location = New System.Drawing.Point(-4, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(967, 41)
        Me.Panel1.TabIndex = 88
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(16, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(902, 29)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "INGRESO DE SECADOS"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ShapeContainer2
        '
        'Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        'Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        'Me.ShapeContainer2.Name = "ShapeContainer2"
        'Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2})
        'Me.ShapeContainer2.Size = New System.Drawing.Size(967, 41)
        'Me.ShapeContainer2.TabIndex = 1
        'Me.ShapeContainer2.TabStop = False
        ''
        ''LineShape2
        ''
        'Me.LineShape2.BorderColor = System.Drawing.Color.DodgerBlue
        'Me.LineShape2.BorderWidth = 7
        'Me.LineShape2.Name = "LineShape2"
        'Me.LineShape2.X1 = -5
        'Me.LineShape2.X2 = 1093
        'Me.LineShape2.Y1 = 39
        'Me.LineShape2.Y2 = 39
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(12, 205)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(956, 23)
        Me.Panel2.TabIndex = 90
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(674, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 19)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Tot. Hectareas :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(13, 1)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(121, 19)
        Me.Label61.TabIndex = 3
        Me.Label61.Text = "Nro. Animales :"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvDIIOS
        '
        Me.lvDIIOS.AutoArrange = False
        Me.lvDIIOS.BackColor = System.Drawing.SystemColors.Window
        Me.lvDIIOS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLin, Me.colDIIO, Me.colCategoria, Me.colEstProd, Me.colEstReprod, Me.colFPP, Me.colFProbSec, Me.colDiasRealSec, Me.colDiasLac, Me.colEstado})
        Me.lvDIIOS.ContextMenuStrip = Me.MenuGanado
        Me.lvDIIOS.FullRowSelect = True
        Me.lvDIIOS.GridLines = True
        Me.lvDIIOS.HideSelection = False
        Me.lvDIIOS.Location = New System.Drawing.Point(12, 232)
        Me.lvDIIOS.MultiSelect = False
        Me.lvDIIOS.Name = "lvDIIOS"
        Me.lvDIIOS.Size = New System.Drawing.Size(956, 321)
        Me.lvDIIOS.TabIndex = 89
        Me.lvDIIOS.UseCompatibleStateImageBehavior = False
        Me.lvDIIOS.View = System.Windows.Forms.View.Details
        '
        'colLin
        '
        Me.colLin.Text = "Nro"
        Me.colLin.Width = 40
        '
        'colDIIO
        '
        Me.colDIIO.Text = "DIIO"
        Me.colDIIO.Width = 80
        '
        'colCategoria
        '
        Me.colCategoria.Text = "Categoría"
        Me.colCategoria.Width = 120
        '
        'colEstProd
        '
        Me.colEstProd.Text = "Est. Productivo"
        Me.colEstProd.Width = 120
        '
        'colFPP
        '
        Me.colFPP.Text = "F.Prob.Parto"
        Me.colFPP.Width = 90
        '
        'colFProbSec
        '
        Me.colFProbSec.Text = "F.Prob.Secado"
        Me.colFProbSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colFProbSec.Width = 90
        '
        'colDiasRealSec
        '
        Me.colDiasRealSec.Text = "Días R. Sec."
        Me.colDiasRealSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colDiasRealSec.Width = 75
        '
        'colDiasLac
        '
        Me.colDiasLac.Text = "Días Lac."
        Me.colDiasLac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colDiasLac.Width = 70
        '
        'colEstado
        '
        Me.colEstado.Text = "Estado"
        Me.colEstado.Width = 190
        '
        'MenuGanado
        '
        Me.MenuGanado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVerDetalle, Me.ToolStripMenuItem1, Me.mnuCopiarDiio})
        Me.MenuGanado.Name = "MenuGanado"
        Me.MenuGanado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuGanado.Size = New System.Drawing.Size(219, 54)
        '
        'mnuVerDetalle
        '
        Me.mnuVerDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuVerDetalle.Name = "mnuVerDetalle"
        Me.mnuVerDetalle.Size = New System.Drawing.Size(218, 22)
        Me.mnuVerDetalle.Text = "Ver Detalle DIIO"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(215, 6)
        '
        'mnuCopiarDiio
        '
        Me.mnuCopiarDiio.Name = "mnuCopiarDiio"
        Me.mnuCopiarDiio.Size = New System.Drawing.Size(218, 22)
        Me.mnuCopiarDiio.Text = "Copiar DIIO al portapapeles"
        '
        'btnBastonLee
        '
        Me.btnBastonLee.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLee.Image = CType(resources.GetObject("btnBastonLee.Image"), System.Drawing.Image)
        Me.btnBastonLee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBastonLee.Location = New System.Drawing.Point(105, 591)
        Me.btnBastonLee.Name = "btnBastonLee"
        Me.btnBastonLee.Size = New System.Drawing.Size(92, 30)
        Me.btnBastonLee.TabIndex = 114
        Me.btnBastonLee.Text = "   Lee Bastón"
        Me.btnBastonLee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBastonLee.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 591)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 115
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Enabled = False
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(296, 591)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(87, 30)
        Me.btnFinalizar.TabIndex = 116
        Me.btnFinalizar.Text = "   Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(203, 591)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 117
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblTotSecados)
        Me.pnlEstReprod.Controls.Add(Me.lblTotEliminados)
        Me.pnlEstReprod.Controls.Add(Me.lblTotErrores)
        Me.pnlEstReprod.Controls.Add(Me.lblConErrores)
        Me.pnlEstReprod.Controls.Add(Me.lblEliminados)
        Me.pnlEstReprod.Controls.Add(Me.Label2)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(12, 560)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(956, 25)
        Me.pnlEstReprod.TabIndex = 118
        '
        'lblTotSecados
        '
        Me.lblTotSecados.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotSecados.Location = New System.Drawing.Point(125, 2)
        Me.lblTotSecados.Name = "lblTotSecados"
        Me.lblTotSecados.Size = New System.Drawing.Size(87, 21)
        Me.lblTotSecados.TabIndex = 1
        Me.lblTotSecados.Text = "0"
        '
        'lblTotEliminados
        '
        Me.lblTotEliminados.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotEliminados.Location = New System.Drawing.Point(428, 2)
        Me.lblTotEliminados.Name = "lblTotEliminados"
        Me.lblTotEliminados.Size = New System.Drawing.Size(87, 21)
        Me.lblTotEliminados.TabIndex = 45
        Me.lblTotEliminados.Text = "0"
        Me.lblTotEliminados.Visible = False
        '
        'lblTotErrores
        '
        Me.lblTotErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotErrores.Location = New System.Drawing.Point(751, 2)
        Me.lblTotErrores.Name = "lblTotErrores"
        Me.lblTotErrores.Size = New System.Drawing.Size(87, 21)
        Me.lblTotErrores.TabIndex = 47
        Me.lblTotErrores.Text = "0"
        Me.lblTotErrores.Visible = False
        '
        'lblConErrores
        '
        Me.lblConErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConErrores.Location = New System.Drawing.Point(666, 2)
        Me.lblConErrores.Name = "lblConErrores"
        Me.lblConErrores.Size = New System.Drawing.Size(79, 21)
        Me.lblConErrores.TabIndex = 48
        Me.lblConErrores.Text = "Con Errores"
        Me.lblConErrores.Visible = False
        '
        'lblEliminados
        '
        Me.lblEliminados.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEliminados.Location = New System.Drawing.Point(343, 2)
        Me.lblEliminados.Name = "lblEliminados"
        Me.lblEliminados.Size = New System.Drawing.Size(78, 21)
        Me.lblEliminados.TabIndex = 46
        Me.lblEliminados.Text = "Eliminados"
        Me.lblEliminados.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 21)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Total de Secados"
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(389, 591)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 119
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'colEstReprod
        '
        Me.colEstReprod.Text = "Est. Reproductivo"
        Me.colEstReprod.Width = 105
        '
        'frmSecadosIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 630)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnBastonLee)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lvDIIOS)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmSecadosIngreso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingreso de Secados"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.MenuGanado.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtObservs As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents lvDIIOS As System.Windows.Forms.ListView
    Friend WithEvents colLin As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDIIO As System.Windows.Forms.ColumnHeader
    Friend WithEvents colCategoria As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFPP As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFProbSec As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDiasRealSec As System.Windows.Forms.ColumnHeader
    Friend WithEvents colDiasLac As System.Windows.Forms.ColumnHeader
    Friend WithEvents colEstado As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnBastonLee As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents lblTotSecados As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTotEliminados As System.Windows.Forms.Label
    Friend WithEvents lblEliminados As System.Windows.Forms.Label
    Friend WithEvents lblTotErrores As System.Windows.Forms.Label
    Friend WithEvents lblConErrores As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents colEstProd As System.Windows.Forms.ColumnHeader
    Friend WithEvents chkVerEliminados As System.Windows.Forms.CheckBox
    Friend WithEvents MenuGanado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCopiarDiio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colEstReprod As ColumnHeader
End Class
