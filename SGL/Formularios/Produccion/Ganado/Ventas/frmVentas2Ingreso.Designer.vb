<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVentas2Ingreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentas2Ingreso))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboTiposDoc = New System.Windows.Forms.ComboBox()
        Me.txtEmpTransporte = New System.Windows.Forms.TextBox()
        Me.txtNomChofer = New System.Windows.Forms.TextBox()
        Me.txtRutChofer = New System.Windows.Forms.TextBox()
        Me.txtPatente2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtNroDoc = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPatente1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboClientes = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNroFMA = New System.Windows.Forms.TextBox()
        Me.lblNroGuia = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblTotErrores = New System.Windows.Forms.Label()
        Me.lblConErrores = New System.Windows.Forms.Label()
        Me.lblTotalVentas = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnBastonLee = New System.Windows.Forms.Button()
        Me.lblVenta = New System.Windows.Forms.ListView()
        Me.LinCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiioCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FecNacCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CategCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CategNomCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EstProdCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EstReprodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TipoVtaCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TipoVtaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CausalCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CausalVtaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EstadoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VeterCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NroCertifCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuGanado = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuVerDetalle = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopiarDiio = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.gbVBJefe = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblUsrVBJefe = New System.Windows.Forms.Label()
        Me.lblFecVBJefe = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbVBVeterinario = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblUsrVBVet = New System.Windows.Forms.Label()
        Me.lblFecVBVet = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gbVBSAG = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblUsrVBSAG = New System.Windows.Forms.Label()
        Me.lblFecVBSAG = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.lblMsgGuia = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboTipoCausa = New System.Windows.Forms.ComboBox()
        Me.cboTipoVenta = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnAgregarDiio = New System.Windows.Forms.Button()
        Me.txtDiioAgregar = New System.Windows.Forms.TextBox()
        Me.btnActulizar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblTipoVenta = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.MenuGanado.SuspendLayout()
        Me.gbVBJefe.SuspendLayout()
        Me.gbVBVeterinario.SuspendLayout()
        Me.gbVBSAG.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1385, 50)
        Me.Panel1.TabIndex = 123
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(13, 5)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(1357, 36)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "INGRESO DE VENTAS"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboTiposDoc)
        Me.GroupBox1.Controls.Add(Me.txtEmpTransporte)
        Me.GroupBox1.Controls.Add(Me.txtNomChofer)
        Me.GroupBox1.Controls.Add(Me.txtRutChofer)
        Me.GroupBox1.Controls.Add(Me.txtPatente2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtEstado)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtNroDoc)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtPatente1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cboClientes)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtNroFMA)
        Me.GroupBox1.Controls.Add(Me.lblNroGuia)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.txtObservs)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 59)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(1344, 188)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        '
        'cboTiposDoc
        '
        Me.cboTiposDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTiposDoc.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTiposDoc.FormattingEnabled = True
        Me.cboTiposDoc.Location = New System.Drawing.Point(917, 22)
        Me.cboTiposDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTiposDoc.Name = "cboTiposDoc"
        Me.cboTiposDoc.Size = New System.Drawing.Size(232, 31)
        Me.cboTiposDoc.TabIndex = 15
        '
        'txtEmpTransporte
        '
        Me.txtEmpTransporte.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmpTransporte.Location = New System.Drawing.Point(717, 143)
        Me.txtEmpTransporte.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEmpTransporte.MaxLength = 40
        Me.txtEmpTransporte.Name = "txtEmpTransporte"
        Me.txtEmpTransporte.Size = New System.Drawing.Size(246, 30)
        Me.txtEmpTransporte.TabIndex = 45
        '
        'txtNomChofer
        '
        Me.txtNomChofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomChofer.Location = New System.Drawing.Point(274, 143)
        Me.txtNomChofer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNomChofer.MaxLength = 30
        Me.txtNomChofer.Name = "txtNomChofer"
        Me.txtNomChofer.Size = New System.Drawing.Size(278, 30)
        Me.txtNomChofer.TabIndex = 40
        '
        'txtRutChofer
        '
        Me.txtRutChofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRutChofer.Location = New System.Drawing.Point(143, 143)
        Me.txtRutChofer.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRutChofer.MaxLength = 13
        Me.txtRutChofer.Name = "txtRutChofer"
        Me.txtRutChofer.Size = New System.Drawing.Size(123, 30)
        Me.txtRutChofer.TabIndex = 35
        '
        'txtPatente2
        '
        Me.txtPatente2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPatente2.Location = New System.Drawing.Point(1190, 139)
        Me.txtPatente2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPatente2.MaxLength = 8
        Me.txtPatente2.Name = "txtPatente2"
        Me.txtPatente2.Size = New System.Drawing.Size(140, 30)
        Me.txtPatente2.TabIndex = 55
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(822, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 23)
        Me.Label1.TabIndex = 139
        Me.Label1.Text = "Tipo Doc."
        '
        'txtEstado
        '
        Me.txtEstado.Enabled = False
        Me.txtEstado.Location = New System.Drawing.Point(1056, 104)
        Me.txtEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEstado.MaxLength = 20
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(274, 30)
        Me.txtEstado.TabIndex = 136
        '
        'Label21
        '
        Me.Label21.Enabled = False
        Me.Label21.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(971, 107)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 28)
        Me.Label21.TabIndex = 137
        Me.Label21.Text = "Estado"
        '
        'txtNroDoc
        '
        Me.txtNroDoc.Enabled = False
        Me.txtNroDoc.Location = New System.Drawing.Point(1205, 22)
        Me.txtNroDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroDoc.MaxLength = 10
        Me.txtNroDoc.Name = "txtNroDoc"
        Me.txtNroDoc.Size = New System.Drawing.Size(125, 30)
        Me.txtNroDoc.TabIndex = 20
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(1157, 25)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(40, 28)
        Me.Label20.TabIndex = 135
        Me.Label20.Text = "N°"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 146)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(156, 23)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Rut Chofer"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(560, 146)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(149, 23)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "Emp. Transporte"
        '
        'txtPatente1
        '
        Me.txtPatente1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPatente1.Location = New System.Drawing.Point(1056, 139)
        Me.txtPatente1.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPatente1.MaxLength = 8
        Me.txtPatente1.Name = "txtPatente1"
        Me.txtPatente1.Size = New System.Drawing.Size(126, 30)
        Me.txtPatente1.TabIndex = 50
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(971, 141)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 28)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "Patentes"
        '
        'cboClientes
        '
        Me.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClientes.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClientes.FormattingEnabled = True
        Me.cboClientes.Location = New System.Drawing.Point(143, 104)
        Me.cboClientes.Margin = New System.Windows.Forms.Padding(4)
        Me.cboClientes.Name = "cboClientes"
        Me.cboClientes.Size = New System.Drawing.Size(820, 31)
        Me.cboClientes.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 107)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 23)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "Cliente"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(405, 25)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 28)
        Me.Label14.TabIndex = 119
        Me.Label14.Text = "Fecha V°B°"
        '
        'txtNroFMA
        '
        Me.txtNroFMA.Location = New System.Drawing.Point(689, 23)
        Me.txtNroFMA.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroFMA.MaxLength = 9
        Me.txtNroFMA.Name = "txtNroFMA"
        Me.txtNroFMA.Size = New System.Drawing.Size(125, 30)
        Me.txtNroFMA.TabIndex = 10
        '
        'lblNroGuia
        '
        Me.lblNroGuia.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroGuia.Location = New System.Drawing.Point(628, 29)
        Me.lblNroGuia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNroGuia.Name = "lblNroGuia"
        Me.lblNroGuia.Size = New System.Drawing.Size(93, 28)
        Me.lblNroGuia.TabIndex = 109
        Me.lblNroGuia.Text = "FMA"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(472, 23)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(148, 30)
        Me.dtpFecha.TabIndex = 5
        '
        'txtObservs
        '
        Me.txtObservs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(143, 65)
        Me.txtObservs.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObservs.MaxLength = 500
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(1187, 31)
        Me.txtObservs.TabIndex = 25
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 69)
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
        Me.cboCentros.Location = New System.Drawing.Point(143, 26)
        Me.cboCentros.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(254, 31)
        Me.cboCentros.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 30)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 23)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Centro"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(283, 28)
        Me.Label6.TabIndex = 117
        Me.Label6.Text = "V°B° Jefe Producción"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblUsuario)
        Me.pnlEstReprod.Controls.Add(Me.lblTotErrores)
        Me.pnlEstReprod.Controls.Add(Me.lblConErrores)
        Me.pnlEstReprod.Controls.Add(Me.lblTotalVentas)
        Me.pnlEstReprod.Controls.Add(Me.Label12)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(13, 625)
        Me.pnlEstReprod.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1344, 30)
        Me.pnlEstReprod.TabIndex = 132
        '
        'lblTotErrores
        '
        Me.lblTotErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotErrores.Location = New System.Drawing.Point(404, 2)
        Me.lblTotErrores.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotErrores.Name = "lblTotErrores"
        Me.lblTotErrores.Size = New System.Drawing.Size(116, 26)
        Me.lblTotErrores.TabIndex = 45
        Me.lblTotErrores.Text = "0"
        Me.lblTotErrores.Visible = False
        '
        'lblConErrores
        '
        Me.lblConErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConErrores.Location = New System.Drawing.Point(303, 2)
        Me.lblConErrores.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblConErrores.Name = "lblConErrores"
        Me.lblConErrores.Size = New System.Drawing.Size(123, 26)
        Me.lblConErrores.TabIndex = 46
        Me.lblConErrores.Text = "Eliminados"
        Me.lblConErrores.Visible = False
        '
        'lblTotalVentas
        '
        Me.lblTotalVentas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalVentas.Location = New System.Drawing.Point(167, 2)
        Me.lblTotalVentas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalVentas.Name = "lblTotalVentas"
        Me.lblTotalVentas.Size = New System.Drawing.Size(116, 26)
        Me.lblTotalVentas.TabIndex = 1
        Me.lblTotalVentas.Text = "0"
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 2)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(163, 26)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "TOTAL GANADO"
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(392, 663)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(116, 37)
        Me.btnEliminar.TabIndex = 75
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(517, 663)
        Me.btnFinalizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(116, 37)
        Me.btnFinalizar.TabIndex = 80
        Me.btnFinalizar.Text = "  Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(13, 663)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(116, 37)
        Me.btnAgregar.TabIndex = 60
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnBastonLee
        '
        Me.btnBastonLee.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLee.Image = CType(resources.GetObject("btnBastonLee.Image"), System.Drawing.Image)
        Me.btnBastonLee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBastonLee.Location = New System.Drawing.Point(137, 663)
        Me.btnBastonLee.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBastonLee.Name = "btnBastonLee"
        Me.btnBastonLee.Size = New System.Drawing.Size(116, 37)
        Me.btnBastonLee.TabIndex = 65
        Me.btnBastonLee.Text = "   Lee Bastón"
        Me.btnBastonLee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBastonLee.UseVisualStyleBackColor = True
        '
        'lblVenta
        '
        Me.lblVenta.AutoArrange = False
        Me.lblVenta.BackColor = System.Drawing.SystemColors.Window
        Me.lblVenta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LinCol, Me.DiioCol, Me.FecNacCol, Me.CategCodCol, Me.CategNomCol, Me.EstProdCol, Me.EstReprodCol, Me.TipoVtaCodCol, Me.TipoVtaCol, Me.CausalCodCol, Me.CausalVtaCol, Me.EstadoCol, Me.VeterCol, Me.NroCertifCol})
        Me.lblVenta.ContextMenuStrip = Me.MenuGanado
        Me.lblVenta.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVenta.FullRowSelect = True
        Me.lblVenta.GridLines = True
        Me.lblVenta.HideSelection = False
        Me.lblVenta.Location = New System.Drawing.Point(14, 323)
        Me.lblVenta.Margin = New System.Windows.Forms.Padding(4)
        Me.lblVenta.Name = "lblVenta"
        Me.lblVenta.Size = New System.Drawing.Size(1343, 294)
        Me.lblVenta.TabIndex = 20
        Me.lblVenta.UseCompatibleStateImageBehavior = False
        Me.lblVenta.View = System.Windows.Forms.View.Details
        '
        'LinCol
        '
        Me.LinCol.Text = "Nro"
        Me.LinCol.Width = 40
        '
        'DiioCol
        '
        Me.DiioCol.Text = "DIIO"
        Me.DiioCol.Width = 80
        '
        'FecNacCol
        '
        Me.FecNacCol.Text = "Fecha Nac."
        Me.FecNacCol.Width = 0
        '
        'CategCodCol
        '
        Me.CategCodCol.Text = "Categ. Cód."
        Me.CategCodCol.Width = 76
        '
        'CategNomCol
        '
        Me.CategNomCol.Text = "Categoría"
        Me.CategNomCol.Width = 120
        '
        'EstProdCol
        '
        Me.EstProdCol.Text = "Est. Productivo"
        Me.EstProdCol.Width = 130
        '
        'EstReprodCol
        '
        Me.EstReprodCol.Text = "Est. Reproductivo"
        Me.EstReprodCol.Width = 130
        '
        'TipoVtaCodCol
        '
        Me.TipoVtaCodCol.Text = "cod tipo venta"
        Me.TipoVtaCodCol.Width = 0
        '
        'TipoVtaCol
        '
        Me.TipoVtaCol.Text = "Tipo Venta"
        Me.TipoVtaCol.Width = 180
        '
        'CausalCodCol
        '
        Me.CausalCodCol.Text = "cod causa"
        Me.CausalCodCol.Width = 0
        '
        'CausalVtaCol
        '
        Me.CausalVtaCol.Text = "Causal"
        Me.CausalVtaCol.Width = 200
        '
        'EstadoCol
        '
        Me.EstadoCol.Text = "Estado"
        Me.EstadoCol.Width = 250
        '
        'VeterCol
        '
        Me.VeterCol.Text = "Veterinario"
        Me.VeterCol.Width = 0
        '
        'NroCertifCol
        '
        Me.NroCertifCol.Text = "Nro Certificado"
        Me.NroCertifCol.Width = 0
        '
        'MenuGanado
        '
        Me.MenuGanado.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuGanado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuVerDetalle, Me.ToolStripMenuItem1, Me.mnuCopiarDiio})
        Me.MenuGanado.Name = "MenuGanado"
        Me.MenuGanado.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuGanado.Size = New System.Drawing.Size(265, 58)
        '
        'mnuVerDetalle
        '
        Me.mnuVerDetalle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mnuVerDetalle.Name = "mnuVerDetalle"
        Me.mnuVerDetalle.Size = New System.Drawing.Size(264, 24)
        Me.mnuVerDetalle.Text = "Ver Detalle DIIO"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(261, 6)
        '
        'mnuCopiarDiio
        '
        Me.mnuCopiarDiio.Name = "mnuCopiarDiio"
        Me.mnuCopiarDiio.Size = New System.Drawing.Size(264, 24)
        Me.mnuCopiarDiio.Text = "Copiar DIIO al portapapeles"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1241, 663)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 37)
        Me.btnSalir.TabIndex = 34
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'gbVBJefe
        '
        Me.gbVBJefe.Controls.Add(Me.Button1)
        Me.gbVBJefe.Controls.Add(Me.lblUsrVBJefe)
        Me.gbVBJefe.Controls.Add(Me.lblFecVBJefe)
        Me.gbVBJefe.Controls.Add(Me.Label4)
        Me.gbVBJefe.Controls.Add(Me.Label3)
        Me.gbVBJefe.Controls.Add(Me.Label6)
        Me.gbVBJefe.Location = New System.Drawing.Point(16, 507)
        Me.gbVBJefe.Margin = New System.Windows.Forms.Padding(4)
        Me.gbVBJefe.Name = "gbVBJefe"
        Me.gbVBJefe.Padding = New System.Windows.Forms.Padding(4)
        Me.gbVBJefe.Size = New System.Drawing.Size(303, 110)
        Me.gbVBJefe.TabIndex = 134
        Me.gbVBJefe.TabStop = False
        Me.gbVBJefe.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(64, 52)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 37)
        Me.Button1.TabIndex = 137
        Me.Button1.Text = "VISTO BUENO"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'lblUsrVBJefe
        '
        Me.lblUsrVBJefe.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsrVBJefe.Location = New System.Drawing.Point(96, 74)
        Me.lblUsrVBJefe.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsrVBJefe.Name = "lblUsrVBJefe"
        Me.lblUsrVBJefe.Size = New System.Drawing.Size(184, 21)
        Me.lblUsrVBJefe.TabIndex = 121
        Me.lblUsrVBJefe.Text = "JERSON"
        Me.lblUsrVBJefe.Visible = False
        '
        'lblFecVBJefe
        '
        Me.lblFecVBJefe.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecVBJefe.Location = New System.Drawing.Point(95, 48)
        Me.lblFecVBJefe.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecVBJefe.Name = "lblFecVBJefe"
        Me.lblFecVBJefe.Size = New System.Drawing.Size(200, 21)
        Me.lblFecVBJefe.TabIndex = 120
        Me.lblFecVBJefe.Text = "01-01-2012 15:30"
        Me.lblFecVBJefe.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 74)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 21)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Usuario:"
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 48)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 21)
        Me.Label3.TabIndex = 118
        Me.Label3.Text = "Fecha:"
        Me.Label3.Visible = False
        '
        'gbVBVeterinario
        '
        Me.gbVBVeterinario.Controls.Add(Me.Button2)
        Me.gbVBVeterinario.Controls.Add(Me.lblUsrVBVet)
        Me.gbVBVeterinario.Controls.Add(Me.lblFecVBVet)
        Me.gbVBVeterinario.Controls.Add(Me.Label16)
        Me.gbVBVeterinario.Controls.Add(Me.Label18)
        Me.gbVBVeterinario.Controls.Add(Me.Label19)
        Me.gbVBVeterinario.Location = New System.Drawing.Point(419, 507)
        Me.gbVBVeterinario.Margin = New System.Windows.Forms.Padding(4)
        Me.gbVBVeterinario.Name = "gbVBVeterinario"
        Me.gbVBVeterinario.Padding = New System.Windows.Forms.Padding(4)
        Me.gbVBVeterinario.Size = New System.Drawing.Size(303, 110)
        Me.gbVBVeterinario.TabIndex = 135
        Me.gbVBVeterinario.TabStop = False
        Me.gbVBVeterinario.Visible = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(65, 52)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(176, 37)
        Me.Button2.TabIndex = 138
        Me.Button2.Text = "VISTO BUENO"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'lblUsrVBVet
        '
        Me.lblUsrVBVet.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsrVBVet.Location = New System.Drawing.Point(96, 74)
        Me.lblUsrVBVet.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsrVBVet.Name = "lblUsrVBVet"
        Me.lblUsrVBVet.Size = New System.Drawing.Size(184, 21)
        Me.lblUsrVBVet.TabIndex = 121
        Me.lblUsrVBVet.Text = "JERSON"
        Me.lblUsrVBVet.Visible = False
        '
        'lblFecVBVet
        '
        Me.lblFecVBVet.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecVBVet.Location = New System.Drawing.Point(95, 48)
        Me.lblFecVBVet.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecVBVet.Name = "lblFecVBVet"
        Me.lblFecVBVet.Size = New System.Drawing.Size(200, 21)
        Me.lblFecVBVet.TabIndex = 120
        Me.lblFecVBVet.Text = "01-01-2012 15:30"
        Me.lblFecVBVet.Visible = False
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 74)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(83, 21)
        Me.Label16.TabIndex = 119
        Me.Label16.Text = "Usuario:"
        Me.Label16.Visible = False
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(11, 48)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 21)
        Me.Label18.TabIndex = 118
        Me.Label18.Text = "Fecha:"
        Me.Label18.Visible = False
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 15)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(283, 28)
        Me.Label19.TabIndex = 117
        Me.Label19.Text = "V°B° Veterinario"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'gbVBSAG
        '
        Me.gbVBSAG.Controls.Add(Me.Button3)
        Me.gbVBSAG.Controls.Add(Me.lblUsrVBSAG)
        Me.gbVBSAG.Controls.Add(Me.lblFecVBSAG)
        Me.gbVBSAG.Controls.Add(Me.Label22)
        Me.gbVBSAG.Controls.Add(Me.Label23)
        Me.gbVBSAG.Controls.Add(Me.Label24)
        Me.gbVBSAG.Location = New System.Drawing.Point(839, 507)
        Me.gbVBSAG.Margin = New System.Windows.Forms.Padding(4)
        Me.gbVBSAG.Name = "gbVBSAG"
        Me.gbVBSAG.Padding = New System.Windows.Forms.Padding(4)
        Me.gbVBSAG.Size = New System.Drawing.Size(303, 110)
        Me.gbVBSAG.TabIndex = 136
        Me.gbVBSAG.TabStop = False
        Me.gbVBSAG.Visible = False
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(67, 52)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(176, 37)
        Me.Button3.TabIndex = 139
        Me.Button3.Text = "VISTO BUENO"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'lblUsrVBSAG
        '
        Me.lblUsrVBSAG.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsrVBSAG.Location = New System.Drawing.Point(96, 74)
        Me.lblUsrVBSAG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsrVBSAG.Name = "lblUsrVBSAG"
        Me.lblUsrVBSAG.Size = New System.Drawing.Size(184, 21)
        Me.lblUsrVBSAG.TabIndex = 121
        Me.lblUsrVBSAG.Text = "JERSON"
        Me.lblUsrVBSAG.Visible = False
        '
        'lblFecVBSAG
        '
        Me.lblFecVBSAG.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecVBSAG.Location = New System.Drawing.Point(95, 48)
        Me.lblFecVBSAG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFecVBSAG.Name = "lblFecVBSAG"
        Me.lblFecVBSAG.Size = New System.Drawing.Size(200, 21)
        Me.lblFecVBSAG.TabIndex = 120
        Me.lblFecVBSAG.Text = "01-01-2012 15:30"
        Me.lblFecVBSAG.Visible = False
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 74)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(83, 21)
        Me.Label22.TabIndex = 119
        Me.Label22.Text = "Usuario:"
        Me.Label22.Visible = False
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(11, 48)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(84, 21)
        Me.Label23.TabIndex = 118
        Me.Label23.Text = "Fecha:"
        Me.Label23.Visible = False
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(12, 15)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(283, 28)
        Me.Label24.TabIndex = 117
        Me.Label24.Text = "V°B° SAG"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(641, 663)
        Me.btnExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(116, 37)
        Me.btnExcel.TabIndex = 85
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.Location = New System.Drawing.Point(765, 663)
        Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(116, 37)
        Me.btnImprimir.TabIndex = 90
        Me.btnImprimir.Text = "Imprime"
        Me.btnImprimir.UseVisualStyleBackColor = True
        Me.btnImprimir.Visible = False
        '
        'btnAsignar
        '
        Me.btnAsignar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignar.Image = CType(resources.GetObject("btnAsignar.Image"), System.Drawing.Image)
        Me.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAsignar.Location = New System.Drawing.Point(261, 663)
        Me.btnAsignar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(123, 37)
        Me.btnAsignar.TabIndex = 70
        Me.btnAsignar.Text = "    Asignar"
        Me.btnAsignar.UseVisualStyleBackColor = True
        '
        'lblMsgGuia
        '
        Me.lblMsgGuia.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgGuia.ForeColor = System.Drawing.Color.Maroon
        Me.lblMsgGuia.Location = New System.Drawing.Point(859, 703)
        Me.lblMsgGuia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMsgGuia.Name = "lblMsgGuia"
        Me.lblMsgGuia.Size = New System.Drawing.Size(498, 26)
        Me.lblMsgGuia.TabIndex = 140
        Me.lblMsgGuia.Text = "Generando Guia Electronica para su visualizacion... favor, espere un momento."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboTipoCausa)
        Me.GroupBox2.Controls.Add(Me.cboTipoVenta)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.btnAgregarDiio)
        Me.GroupBox2.Controls.Add(Me.txtDiioAgregar)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 254)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(934, 62)
        Me.GroupBox2.TabIndex = 141
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Agregar Diio"
        '
        'cboTipoCausa
        '
        Me.cboTipoCausa.FormattingEnabled = True
        Me.cboTipoCausa.Location = New System.Drawing.Point(623, 25)
        Me.cboTipoCausa.Name = "cboTipoCausa"
        Me.cboTipoCausa.Size = New System.Drawing.Size(212, 24)
        Me.cboTipoCausa.TabIndex = 110
        '
        'cboTipoVenta
        '
        Me.cboTipoVenta.FormattingEnabled = True
        Me.cboTipoVenta.Location = New System.Drawing.Point(320, 24)
        Me.cboTipoVenta.Name = "cboTipoVenta"
        Me.cboTipoVenta.Size = New System.Drawing.Size(228, 24)
        Me.cboTipoVenta.TabIndex = 109
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(566, 24)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 23)
        Me.Label11.TabIndex = 107
        Me.Label11.Text = "Causa"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(221, 24)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 23)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Tipo Venta"
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(8, 25)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(47, 23)
        Me.Label25.TabIndex = 105
        Me.Label25.Text = "Diio"
        '
        'btnAgregarDiio
        '
        Me.btnAgregarDiio.Image = CType(resources.GetObject("btnAgregarDiio.Image"), System.Drawing.Image)
        Me.btnAgregarDiio.Location = New System.Drawing.Point(860, 20)
        Me.btnAgregarDiio.Name = "btnAgregarDiio"
        Me.btnAgregarDiio.Size = New System.Drawing.Size(49, 34)
        Me.btnAgregarDiio.TabIndex = 2
        Me.btnAgregarDiio.UseVisualStyleBackColor = True
        '
        'txtDiioAgregar
        '
        Me.txtDiioAgregar.Location = New System.Drawing.Point(62, 27)
        Me.txtDiioAgregar.Name = "txtDiioAgregar"
        Me.txtDiioAgregar.Size = New System.Drawing.Size(152, 22)
        Me.txtDiioAgregar.TabIndex = 0
        '
        'btnActulizar
        '
        Me.btnActulizar.Image = CType(resources.GetObject("btnActulizar.Image"), System.Drawing.Image)
        Me.btnActulizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActulizar.Location = New System.Drawing.Point(888, 663)
        Me.btnActulizar.Name = "btnActulizar"
        Me.btnActulizar.Size = New System.Drawing.Size(161, 37)
        Me.btnActulizar.TabIndex = 142
        Me.btnActulizar.Text = "Actualizar Venta"
        Me.btnActulizar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblTipoVenta)
        Me.GroupBox3.Location = New System.Drawing.Point(953, 254)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(404, 62)
        Me.GroupBox3.TabIndex = 143
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Requerimiento de Venta"
        '
        'lblTipoVenta
        '
        Me.lblTipoVenta.AutoSize = True
        Me.lblTipoVenta.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoVenta.Location = New System.Drawing.Point(6, 20)
        Me.lblTipoVenta.MaximumSize = New System.Drawing.Size(400, 0)
        Me.lblTipoVenta.Name = "lblTipoVenta"
        Me.lblTipoVenta.Size = New System.Drawing.Size(55, 18)
        Me.lblTipoVenta.TabIndex = 0
        Me.lblTipoVenta.Text = "Label13"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUsuario.Location = New System.Drawing.Point(543, 4)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(65, 21)
        Me.lblUsuario.TabIndex = 144
        Me.lblUsuario.Text = "Label13"
        '
        'frmVentas2Ingreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1383, 740)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnActulizar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblMsgGuia)
        Me.Controls.Add(Me.btnAsignar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblVenta)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.btnBastonLee)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbVBSAG)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.gbVBVeterinario)
        Me.Controls.Add(Me.gbVBJefe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmVentas2Ingreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Ventas"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlEstReprod.ResumeLayout(False)
        Me.pnlEstReprod.PerformLayout()
        Me.MenuGanado.ResumeLayout(False)
        Me.gbVBJefe.ResumeLayout(False)
        Me.gbVBVeterinario.ResumeLayout(False)
        Me.gbVBSAG.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNroFMA As System.Windows.Forms.TextBox
    Friend WithEvents lblNroGuia As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtObservs As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents lblTotErrores As System.Windows.Forms.Label
    Friend WithEvents lblConErrores As System.Windows.Forms.Label
    Friend WithEvents lblTotalVentas As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBastonLee As System.Windows.Forms.Button
    Friend WithEvents lblVenta As System.Windows.Forms.ListView
    Friend WithEvents LinCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DiioCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents CategNomCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents EstReprodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents EstProdCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents gbVBJefe As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsrVBJefe As System.Windows.Forms.Label
    Friend WithEvents lblFecVBJefe As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbVBVeterinario As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsrVBVet As System.Windows.Forms.Label
    Friend WithEvents lblFecVBVet As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents gbVBSAG As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsrVBSAG As System.Windows.Forms.Label
    Friend WithEvents lblFecVBSAG As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents EstadoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents MenuGanado As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuVerDetalle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCopiarDiio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPatente1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboClientes As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNroDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CausalVtaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents CausalCodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents VeterCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents NroCertifCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents TipoVtaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents TipoVtaCodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboTiposDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPatente2 As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpTransporte As System.Windows.Forms.TextBox
    Friend WithEvents txtNomChofer As System.Windows.Forms.TextBox
    Friend WithEvents txtRutChofer As System.Windows.Forms.TextBox
    Friend WithEvents CategCodCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents FecNacCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblMsgGuia As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnAgregarDiio As Button
    Friend WithEvents txtDiioAgregar As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents cboTipoCausa As ComboBox
    Friend WithEvents cboTipoVenta As ComboBox
    Friend WithEvents btnActulizar As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblTipoVenta As Label
    Friend WithEvents lblUsuario As Label
End Class
