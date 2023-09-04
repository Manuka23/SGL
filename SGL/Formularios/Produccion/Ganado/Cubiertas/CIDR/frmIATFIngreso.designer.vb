<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIATFIngreso
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIATFIngreso))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.gboxDIIO = New System.Windows.Forms.GroupBox()
        Me.lblNroCelos = New System.Windows.Forms.Label()
        Me.lblFechaUltCelo = New System.Windows.Forms.Label()
        Me.lblNroPartos = New System.Windows.Forms.Label()
        Me.lblDiasLac = New System.Windows.Forms.Label()
        Me.lblEstReproductivo = New System.Windows.Forms.Label()
        Me.lblEstProductivo = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDIIO = New System.Windows.Forms.TextBox()
        Me.btnBuscarDIIO = New System.Windows.Forms.Button()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.gboxFecha = New System.Windows.Forms.GroupBox()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblTotErrores = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotCelos = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lvDIIOS = New System.Windows.Forms.ListView()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnBastonLee = New System.Windows.Forms.Button()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.gboxObservs = New System.Windows.Forms.GroupBox()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.MenuGanado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopiarDiio = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.gboxDIIO.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gboxFecha.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.gboxObservs.SuspendLayout()
        Me.MenuGanado.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(671, 485)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.Location = New System.Drawing.Point(682, 27)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(38, 30)
        Me.btnGrabar.TabIndex = 10
        Me.btnGrabar.UseVisualStyleBackColor = True
        Me.btnGrabar.Visible = False
        '
        'gboxDIIO
        '
        Me.gboxDIIO.Controls.Add(Me.lblNroCelos)
        Me.gboxDIIO.Controls.Add(Me.lblFechaUltCelo)
        Me.gboxDIIO.Controls.Add(Me.lblNroPartos)
        Me.gboxDIIO.Controls.Add(Me.lblDiasLac)
        Me.gboxDIIO.Controls.Add(Me.lblEstReproductivo)
        Me.gboxDIIO.Controls.Add(Me.lblEstProductivo)
        Me.gboxDIIO.Controls.Add(Me.lblCategoria)
        Me.gboxDIIO.Controls.Add(Me.Label5)
        Me.gboxDIIO.Controls.Add(Me.Label4)
        Me.gboxDIIO.Controls.Add(Me.Label2)
        Me.gboxDIIO.Controls.Add(Me.txtDIIO)
        Me.gboxDIIO.Controls.Add(Me.btnGrabar)
        Me.gboxDIIO.Controls.Add(Me.btnBuscarDIIO)
        Me.gboxDIIO.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxDIIO.Location = New System.Drawing.Point(12, 144)
        Me.gboxDIIO.Name = "gboxDIIO"
        Me.gboxDIIO.Size = New System.Drawing.Size(746, 67)
        Me.gboxDIIO.TabIndex = 91
        Me.gboxDIIO.TabStop = False
        Me.gboxDIIO.Text = "DIIO"
        '
        'lblNroCelos
        '
        Me.lblNroCelos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroCelos.Location = New System.Drawing.Point(708, 73)
        Me.lblNroCelos.Name = "lblNroCelos"
        Me.lblNroCelos.Size = New System.Drawing.Size(172, 25)
        Me.lblNroCelos.TabIndex = 101
        Me.lblNroCelos.Text = "---"
        '
        'lblFechaUltCelo
        '
        Me.lblFechaUltCelo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltCelo.Location = New System.Drawing.Point(504, 73)
        Me.lblFechaUltCelo.Name = "lblFechaUltCelo"
        Me.lblFechaUltCelo.Size = New System.Drawing.Size(172, 25)
        Me.lblFechaUltCelo.TabIndex = 100
        Me.lblFechaUltCelo.Text = "---"
        '
        'lblNroPartos
        '
        Me.lblNroPartos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroPartos.Location = New System.Drawing.Point(382, 73)
        Me.lblNroPartos.Name = "lblNroPartos"
        Me.lblNroPartos.Size = New System.Drawing.Size(172, 25)
        Me.lblNroPartos.TabIndex = 99
        Me.lblNroPartos.Text = "---"
        '
        'lblDiasLac
        '
        Me.lblDiasLac.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasLac.Location = New System.Drawing.Point(178, 73)
        Me.lblDiasLac.Name = "lblDiasLac"
        Me.lblDiasLac.Size = New System.Drawing.Size(172, 25)
        Me.lblDiasLac.TabIndex = 98
        Me.lblDiasLac.Text = "---"
        '
        'lblEstReproductivo
        '
        Me.lblEstReproductivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstReproductivo.Location = New System.Drawing.Point(504, 34)
        Me.lblEstReproductivo.Name = "lblEstReproductivo"
        Me.lblEstReproductivo.Size = New System.Drawing.Size(172, 25)
        Me.lblEstReproductivo.TabIndex = 94
        Me.lblEstReproductivo.Text = "---"
        '
        'lblEstProductivo
        '
        Me.lblEstProductivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstProductivo.Location = New System.Drawing.Point(329, 34)
        Me.lblEstProductivo.Name = "lblEstProductivo"
        Me.lblEstProductivo.Size = New System.Drawing.Size(172, 25)
        Me.lblEstProductivo.TabIndex = 93
        Me.lblEstProductivo.Text = "---"
        '
        'lblCategoria
        '
        Me.lblCategoria.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(185, 34)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(142, 25)
        Me.lblCategoria.TabIndex = 91
        Me.lblCategoria.Text = "---"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(501, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 22)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Est. Reproductivo"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(331, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 22)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Est. Productivo"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(185, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 22)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Categoría"
        '
        'txtDIIO
        '
        Me.txtDIIO.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIIO.Location = New System.Drawing.Point(11, 30)
        Me.txtDIIO.MaxLength = 20
        Me.txtDIIO.Name = "txtDIIO"
        Me.txtDIIO.Size = New System.Drawing.Size(113, 27)
        Me.txtDIIO.TabIndex = 2
        '
        'btnBuscarDIIO
        '
        Me.btnBuscarDIIO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarDIIO.Image = CType(resources.GetObject("btnBuscarDIIO.Image"), System.Drawing.Image)
        Me.btnBuscarDIIO.Location = New System.Drawing.Point(130, 30)
        Me.btnBuscarDIIO.Name = "btnBuscarDIIO"
        Me.btnBuscarDIIO.Size = New System.Drawing.Size(32, 27)
        Me.btnBuscarDIIO.TabIndex = 97
        Me.btnBuscarDIIO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarDIIO.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(13, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(109, 26)
        Me.dtpFecha.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(309, 57)
        Me.GroupBox1.TabIndex = 90
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(11, 20)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(282, 26)
        Me.cboCentros.TabIndex = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(105, 487)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'gboxFecha
        '
        Me.gboxFecha.Controls.Add(Me.dtpFecha)
        Me.gboxFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxFecha.Location = New System.Drawing.Point(327, 8)
        Me.gboxFecha.Name = "gboxFecha"
        Me.gboxFecha.Size = New System.Drawing.Size(134, 57)
        Me.gboxFecha.TabIndex = 98
        Me.gboxFecha.TabStop = False
        Me.gboxFecha.Text = "Fecha"
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblTotErrores)
        Me.pnlEstReprod.Controls.Add(Me.Label6)
        Me.pnlEstReprod.Controls.Add(Me.lblTotCelos)
        Me.pnlEstReprod.Controls.Add(Me.Label1)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(12, 456)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(746, 25)
        Me.pnlEstReprod.TabIndex = 120
        '
        'lblTotErrores
        '
        Me.lblTotErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotErrores.Location = New System.Drawing.Point(551, 2)
        Me.lblTotErrores.Name = "lblTotErrores"
        Me.lblTotErrores.Size = New System.Drawing.Size(87, 21)
        Me.lblTotErrores.TabIndex = 45
        Me.lblTotErrores.Text = "0"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(461, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 21)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "Con Errores"
        '
        'lblTotCelos
        '
        Me.lblTotCelos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotCelos.Location = New System.Drawing.Point(101, 2)
        Me.lblTotCelos.Name = "lblTotCelos"
        Me.lblTotCelos.Size = New System.Drawing.Size(87, 21)
        Me.lblTotCelos.TabIndex = 1
        Me.lblTotCelos.Text = "0"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 21)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Total Celos"
        '
        'lvDIIOS
        '
        Me.lvDIIOS.AutoArrange = False
        Me.lvDIIOS.BackColor = System.Drawing.SystemColors.Window
        Me.lvDIIOS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader11, Me.ColumnHeader8, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader4})
        Me.lvDIIOS.FullRowSelect = True
        Me.lvDIIOS.GridLines = True
        Me.lvDIIOS.HideSelection = False
        Me.lvDIIOS.Location = New System.Drawing.Point(12, 217)
        Me.lvDIIOS.Name = "lvDIIOS"
        Me.lvDIIOS.Size = New System.Drawing.Size(746, 233)
        Me.lvDIIOS.TabIndex = 119
        Me.lvDIIOS.UseCompatibleStateImageBehavior = False
        Me.lvDIIOS.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.Width = 40
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "DIIO"
        Me.ColumnHeader1.Width = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Categoría"
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Est. Productivo"
        Me.ColumnHeader11.Width = 145
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Est. Reproductivo"
        Me.ColumnHeader8.Width = 145
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Resultado"
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Fec CIDR"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Fec. 1a Cbta."
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Días P. Cbta."
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Días CIDR"
        '
        'btnBastonLee
        '
        Me.btnBastonLee.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLee.Image = CType(resources.GetObject("btnBastonLee.Image"), System.Drawing.Image)
        Me.btnBastonLee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBastonLee.Location = New System.Drawing.Point(198, 487)
        Me.btnBastonLee.Name = "btnBastonLee"
        Me.btnBastonLee.Size = New System.Drawing.Size(92, 30)
        Me.btnBastonLee.TabIndex = 121
        Me.btnBastonLee.Text = "   Lee Bastón"
        Me.btnBastonLee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBastonLee.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(12, 487)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(87, 30)
        Me.btnFinalizar.TabIndex = 122
        Me.btnFinalizar.Text = "   Validar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'gboxObservs
        '
        Me.gboxObservs.Controls.Add(Me.txtObservs)
        Me.gboxObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxObservs.Location = New System.Drawing.Point(12, 65)
        Me.gboxObservs.Name = "gboxObservs"
        Me.gboxObservs.Size = New System.Drawing.Size(746, 78)
        Me.gboxObservs.TabIndex = 123
        Me.gboxObservs.TabStop = False
        Me.gboxObservs.Text = "Observación para el grupo de DIIOs"
        '
        'txtObservs
        '
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(13, 23)
        Me.txtObservs.MaxLength = 500
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(719, 43)
        Me.txtObservs.TabIndex = 4
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
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(296, 487)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(87, 30)
        Me.btnExcel.TabIndex = 125
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(671, 35)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 30)
        Me.btnBuscar.TabIndex = 127
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        Me.btnBuscar.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(389, 487)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 32)
        Me.Button2.TabIndex = 218
        Me.Button2.Text = "Eliminar Errores"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmIATFIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 527)
        Me.ContextMenuStrip = Me.MenuGanado
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lvDIIOS)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.gboxObservs)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnBastonLee)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.gboxFecha)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.gboxDIIO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmIATFIngreso"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingreso de CIDR"
        Me.gboxDIIO.ResumeLayout(False)
        Me.gboxDIIO.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gboxFecha.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.gboxObservs.ResumeLayout(False)
        Me.gboxObservs.PerformLayout()
        Me.MenuGanado.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents gboxDIIO As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstReproductivo As System.Windows.Forms.Label
    Friend WithEvents lblEstProductivo As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDIIO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscarDIIO As System.Windows.Forms.Button
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents gboxFecha As System.Windows.Forms.GroupBox
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents lblTotErrores As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotCelos As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lvDIIOS As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnBastonLee As System.Windows.Forms.Button
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents gboxObservs As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservs As System.Windows.Forms.TextBox
    Friend WithEvents MenuGanado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCopiarDiio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblNroPartos As System.Windows.Forms.Label
    Friend WithEvents lblDiasLac As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblNroCelos As System.Windows.Forms.Label
    Friend WithEvents lblFechaUltCelo As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As Button
End Class
