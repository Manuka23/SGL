<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPartosIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPartosIngreso))
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblAbortos = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblMuertos = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTotMachos = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTotSexadas = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotPartos = New System.Windows.Forms.Label()
        Me.lblTotCrias = New System.Windows.Forms.Label()
        Me.lblTotHembras = New System.Windows.Forms.Label()
        Me.lblEliminados = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnBastonLee = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.lvPARTOS = New System.Windows.Forms.ListView()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuGanado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuDetalleParto = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuVerDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCopiarDiio = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboTipoParto = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkVerEliminados = New System.Windows.Forms.CheckBox()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.pnlEstReprod.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuGanado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(140, 727)
        Me.btnExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(116, 37)
        Me.btnExcel.TabIndex = 130
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblAbortos)
        Me.pnlEstReprod.Controls.Add(Me.Label15)
        Me.pnlEstReprod.Controls.Add(Me.lblMuertos)
        Me.pnlEstReprod.Controls.Add(Me.Label14)
        Me.pnlEstReprod.Controls.Add(Me.lblTotMachos)
        Me.pnlEstReprod.Controls.Add(Me.Label12)
        Me.pnlEstReprod.Controls.Add(Me.Label9)
        Me.pnlEstReprod.Controls.Add(Me.lblTotSexadas)
        Me.pnlEstReprod.Controls.Add(Me.Label7)
        Me.pnlEstReprod.Controls.Add(Me.lblTotPartos)
        Me.pnlEstReprod.Controls.Add(Me.lblTotCrias)
        Me.pnlEstReprod.Controls.Add(Me.lblTotHembras)
        Me.pnlEstReprod.Controls.Add(Me.lblEliminados)
        Me.pnlEstReprod.Controls.Add(Me.Label2)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(16, 689)
        Me.pnlEstReprod.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1415, 30)
        Me.pnlEstReprod.TabIndex = 129
        '
        'lblAbortos
        '
        Me.lblAbortos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbortos.ForeColor = System.Drawing.Color.Red
        Me.lblAbortos.Location = New System.Drawing.Point(1103, 2)
        Me.lblAbortos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAbortos.Name = "lblAbortos"
        Me.lblAbortos.Size = New System.Drawing.Size(76, 26)
        Me.lblAbortos.TabIndex = 57
        Me.lblAbortos.Text = "0"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(1019, 2)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 26)
        Me.Label15.TabIndex = 58
        Me.Label15.Text = "Abortos"
        '
        'lblMuertos
        '
        Me.lblMuertos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMuertos.ForeColor = System.Drawing.Color.Red
        Me.lblMuertos.Location = New System.Drawing.Point(920, 2)
        Me.lblMuertos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMuertos.Name = "lblMuertos"
        Me.lblMuertos.Size = New System.Drawing.Size(76, 26)
        Me.lblMuertos.TabIndex = 55
        Me.lblMuertos.Text = "0"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(820, 2)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 26)
        Me.Label14.TabIndex = 56
        Me.Label14.Text = "T. Muertos"
        '
        'lblTotMachos
        '
        Me.lblTotMachos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotMachos.ForeColor = System.Drawing.Color.Blue
        Me.lblTotMachos.Location = New System.Drawing.Point(732, 2)
        Me.lblTotMachos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotMachos.Name = "lblTotMachos"
        Me.lblTotMachos.Size = New System.Drawing.Size(76, 26)
        Me.lblTotMachos.TabIndex = 53
        Me.lblTotMachos.Text = "0"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(652, 2)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 26)
        Me.Label12.TabIndex = 54
        Me.Label12.Text = "Machos"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(469, 2)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 26)
        Me.Label9.TabIndex = 52
        Me.Label9.Text = "Hembras"
        '
        'lblTotSexadas
        '
        Me.lblTotSexadas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotSexadas.Location = New System.Drawing.Point(1325, 2)
        Me.lblTotSexadas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotSexadas.Name = "lblTotSexadas"
        Me.lblTotSexadas.Size = New System.Drawing.Size(79, 26)
        Me.lblTotSexadas.TabIndex = 49
        Me.lblTotSexadas.Text = "0"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1248, 2)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 26)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Sexadas"
        '
        'lblTotPartos
        '
        Me.lblTotPartos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotPartos.Location = New System.Drawing.Point(145, 6)
        Me.lblTotPartos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotPartos.Name = "lblTotPartos"
        Me.lblTotPartos.Size = New System.Drawing.Size(83, 18)
        Me.lblTotPartos.TabIndex = 1
        Me.lblTotPartos.Text = "0"
        '
        'lblTotCrias
        '
        Me.lblTotCrias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotCrias.ForeColor = System.Drawing.Color.Blue
        Me.lblTotCrias.Location = New System.Drawing.Point(331, 6)
        Me.lblTotCrias.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotCrias.Name = "lblTotCrias"
        Me.lblTotCrias.Size = New System.Drawing.Size(76, 18)
        Me.lblTotCrias.TabIndex = 45
        Me.lblTotCrias.Text = "0"
        '
        'lblTotHembras
        '
        Me.lblTotHembras.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotHembras.ForeColor = System.Drawing.Color.Blue
        Me.lblTotHembras.Location = New System.Drawing.Point(559, 2)
        Me.lblTotHembras.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotHembras.Name = "lblTotHembras"
        Me.lblTotHembras.Size = New System.Drawing.Size(75, 26)
        Me.lblTotHembras.TabIndex = 47
        Me.lblTotHembras.Text = "0"
        '
        'lblEliminados
        '
        Me.lblEliminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEliminados.ForeColor = System.Drawing.Color.Blue
        Me.lblEliminados.Location = New System.Drawing.Point(232, 6)
        Me.lblEliminados.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEliminados.Name = "lblEliminados"
        Me.lblEliminados.Size = New System.Drawing.Size(97, 18)
        Me.lblEliminados.TabIndex = 46
        Me.lblEliminados.Text = "Total Crías"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 18)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "TOTAL PARTOS"
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(264, 727)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(116, 37)
        Me.btnEliminar.TabIndex = 128
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Enabled = False
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(388, 727)
        Me.btnFinalizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(116, 37)
        Me.btnFinalizar.TabIndex = 127
        Me.btnFinalizar.Text = "   Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        Me.btnFinalizar.Visible = False
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(16, 727)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(116, 37)
        Me.btnAgregar.TabIndex = 126
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnBastonLee
        '
        Me.btnBastonLee.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLee.Image = CType(resources.GetObject("btnBastonLee.Image"), System.Drawing.Image)
        Me.btnBastonLee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBastonLee.Location = New System.Drawing.Point(512, 727)
        Me.btnBastonLee.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBastonLee.Name = "btnBastonLee"
        Me.btnBastonLee.Size = New System.Drawing.Size(123, 37)
        Me.btnBastonLee.TabIndex = 125
        Me.btnBastonLee.Text = "   Lee Bastón"
        Me.btnBastonLee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBastonLee.UseVisualStyleBackColor = True
        Me.btnBastonLee.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(16, 146)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1202, 28)
        Me.Panel2.TabIndex = 124
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(956, 1)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tot. Hectareas :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(520, 1)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(161, 23)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Preñadas :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(19, 1)
        Me.Label61.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(161, 23)
        Me.Label61.TabIndex = 3
        Me.Label61.Text = "Nro. Animales :"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lvPARTOS
        '
        Me.lvPARTOS.AutoArrange = False
        Me.lvPARTOS.BackColor = System.Drawing.SystemColors.Window
        Me.lvPARTOS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.ColumnHeader7, Me.ColumnHeader15, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader4, Me.ColumnHeader11, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader3, Me.ColumnHeader10, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader17, Me.ColumnHeader16, Me.ColumnHeader18})
        Me.lvPARTOS.ContextMenuStrip = Me.MenuGanado
        Me.lvPARTOS.FullRowSelect = True
        Me.lvPARTOS.GridLines = True
        Me.lvPARTOS.HideSelection = False
        Me.lvPARTOS.Location = New System.Drawing.Point(16, 144)
        Me.lvPARTOS.Margin = New System.Windows.Forms.Padding(4)
        Me.lvPARTOS.MultiSelect = False
        Me.lvPARTOS.Name = "lvPARTOS"
        Me.lvPARTOS.Size = New System.Drawing.Size(1415, 537)
        Me.lvPARTOS.TabIndex = 123
        Me.lvPARTOS.UseCompatibleStateImageBehavior = False
        Me.lvPARTOS.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.Width = 40
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Empresa"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Centro"
        Me.ColumnHeader15.Width = 77
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "DIIO"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Categoría"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Est. Productivo (Anterior)"
        Me.ColumnHeader4.Width = 150
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Fecha Parto"
        Me.ColumnHeader11.Width = 90
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Crías"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader8.Width = 55
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Hembras"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader9.Width = 55
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Sexadas"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 55
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Tipo Parto"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DIIO Cria 1"
        Me.ColumnHeader3.Width = 70
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Sexo Cria 1"
        Me.ColumnHeader10.Width = 75
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "DIIO Cria 2"
        Me.ColumnHeader12.Width = 70
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Sexo Cria 2"
        Me.ColumnHeader13.Width = 75
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "centro"
        Me.ColumnHeader14.Width = 0
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "1° Traslado"
        Me.ColumnHeader17.Width = 100
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Usuario"
        Me.ColumnHeader16.Width = 100
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Fecha Reg"
        Me.ColumnHeader18.Width = 100
        '
        'MenuGanado
        '
        Me.MenuGanado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuGanado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDetalleParto, Me.ToolStripSeparator1, Me.mnuVerDetalle, Me.mnuCopiarDiio})
        Me.MenuGanado.Name = "MenuGanado"
        Me.MenuGanado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuGanado.Size = New System.Drawing.Size(265, 82)
        '
        'mnuDetalleParto
        '
        Me.mnuDetalleParto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuDetalleParto.Name = "mnuDetalleParto"
        Me.mnuDetalleParto.Size = New System.Drawing.Size(264, 24)
        Me.mnuDetalleParto.Text = "Ver Detalle Parto"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(261, 6)
        '
        'mnuVerDetalle
        '
        Me.mnuVerDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnuVerDetalle.Name = "mnuVerDetalle"
        Me.mnuVerDetalle.Size = New System.Drawing.Size(264, 24)
        Me.mnuVerDetalle.Text = "Ver Detalle DIIO"
        '
        'mnuCopiarDiio
        '
        Me.mnuCopiarDiio.Name = "mnuCopiarDiio"
        Me.mnuCopiarDiio.Size = New System.Drawing.Size(264, 24)
        Me.mnuCopiarDiio.Text = "Copiar DIIO al portapapeles"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1521, 50)
        Me.Panel1.TabIndex = 122
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(21, 5)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(1416, 36)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "DETALLE DE PARTOS"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1316, 727)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 37)
        Me.btnSalir.TabIndex = 120
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboTipoParto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.dtpFechaHasta)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.txtObservs)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 58)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1416, 81)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de Partos"
        '
        'cboTipoParto
        '
        Me.cboTipoParto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoParto.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoParto.FormattingEnabled = True
        Me.cboTipoParto.Items.AddRange(New Object() {"(TODOS)", "NORMAL", "ABORTO", "T. MUERTO", "ASISTIDO", "INDUCIDO"})
        Me.cboTipoParto.Location = New System.Drawing.Point(1003, 32)
        Me.cboTipoParto.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoParto.Name = "cboTipoParto"
        Me.cboTipoParto.Size = New System.Drawing.Size(165, 31)
        Me.cboTipoParto.TabIndex = 127
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(909, 38)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 128
        Me.Label6.Text = "Tipo Parto"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(1283, 30)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(116, 37)
        Me.btnBuscar.TabIndex = 126
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(717, 34)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(153, 30)
        Me.dtpFechaHasta.TabIndex = 107
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(613, 38)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(119, 28)
        Me.Label8.TabIndex = 108
        Me.Label8.Text = "Fecha Hasta"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(451, 34)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(153, 30)
        Me.dtpFecha.TabIndex = 102
        '
        'txtObservs
        '
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(164, 86)
        Me.txtObservs.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObservs.MaxLength = 500
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(1020, 83)
        Me.txtObservs.TabIndex = 105
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(20, 86)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(139, 28)
        Me.Label17.TabIndex = 106
        Me.Label17.Text = "Observaciones"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(100, 32)
        Me.cboCentros.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(217, 31)
        Me.cboCentros.TabIndex = 101
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(332, 38)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 28)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Fecha Desde"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 38)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 23)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Centro"
        '
        'chkVerEliminados
        '
        Me.chkVerEliminados.Location = New System.Drawing.Point(809, 736)
        Me.chkVerEliminados.Margin = New System.Windows.Forms.Padding(4)
        Me.chkVerEliminados.Name = "chkVerEliminados"
        Me.chkVerEliminados.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkVerEliminados.Size = New System.Drawing.Size(165, 28)
        Me.chkVerEliminados.TabIndex = 107
        Me.chkVerEliminados.Text = "Ver Eliminados"
        Me.chkVerEliminados.UseVisualStyleBackColor = True
        Me.chkVerEliminados.Visible = False
        '
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(228, 303)
        Me.pnlProcesa.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(970, 65)
        Me.pnlProcesa.TabIndex = 131
        Me.pnlProcesa.Visible = False
        '
        'lblProcesa
        '
        Me.lblProcesa.AutoSize = True
        Me.lblProcesa.Location = New System.Drawing.Point(12, 11)
        Me.lblProcesa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProcesa.Name = "lblProcesa"
        Me.lblProcesa.Size = New System.Drawing.Size(85, 16)
        Me.lblProcesa.TabIndex = 69
        Me.lblProcesa.Text = "Exportando..."
        '
        'pbProcesa
        '
        Me.pbProcesa.Location = New System.Drawing.Point(16, 28)
        Me.pbProcesa.Margin = New System.Windows.Forms.Padding(4)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(940, 22)
        Me.pbProcesa.TabIndex = 68
        '
        'frmPartosIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1448, 801)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.lvPARTOS)
        Me.Controls.Add(Me.chkVerEliminados)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnBastonLee)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "frmPartosIngreso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Deatalle de Partos"
        Me.pnlEstReprod.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.MenuGanado.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents lblTotPartos As System.Windows.Forms.Label
    Friend WithEvents lblTotCrias As System.Windows.Forms.Label
    Friend WithEvents lblTotHembras As System.Windows.Forms.Label
    Friend WithEvents lblEliminados As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBastonLee As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents lvPARTOS As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkVerEliminados As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservs As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotSexadas As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents MenuGanado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCopiarDiio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDetalleParto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblAbortos As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblMuertos As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblTotMachos As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboTipoParto As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
End Class
