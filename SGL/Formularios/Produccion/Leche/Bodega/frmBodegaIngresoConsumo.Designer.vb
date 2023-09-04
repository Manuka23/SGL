<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBodegaIngresoConsumo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBodegaIngresoConsumo))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboItemsStk = New System.Windows.Forms.ComboBox()
        Me.lblCentro = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblCostoActual = New System.Windows.Forms.Label()
        Me.lblUnidMed = New System.Windows.Forms.Label()
        Me.cboCuentas = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboItemsGasto = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.lvItemsConsumo = New System.Windows.Forms.ListView()
        Me.colNroLin = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductoNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductoCant = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductoCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCuentaCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItemGastoCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colGrabado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colCuentaNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colItemGastoNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductoUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProductoStk = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.grpFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grpFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboItemsStk)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 57)
        Me.GroupBox1.TabIndex = 105
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto"
        '
        'cboItemsStk
        '
        Me.cboItemsStk.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemsStk.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemsStk.FormattingEnabled = True
        Me.cboItemsStk.Location = New System.Drawing.Point(10, 20)
        Me.cboItemsStk.Name = "cboItemsStk"
        Me.cboItemsStk.Size = New System.Drawing.Size(399, 26)
        Me.cboItemsStk.TabIndex = 211
        Me.cboItemsStk.Text = "-- ELEGIR PRODUCTO --"
        '
        'lblCentro
        '
        Me.lblCentro.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCentro.Location = New System.Drawing.Point(76, 44)
        Me.lblCentro.Name = "lblCentro"
        Me.lblCentro.Size = New System.Drawing.Size(675, 23)
        Me.lblCentro.TabIndex = 103
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(645, 540)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 102
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(841, 41)
        Me.Panel1.TabIndex = 100
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(0, 9)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(739, 29)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "INGRESO DE CONSUMO"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblCostoActual)
        Me.GroupBox2.Controls.Add(Me.lblUnidMed)
        Me.GroupBox2.Controls.Add(Me.cboCuentas)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtObservs)
        Me.GroupBox2.Controls.Add(Me.txtCantidad)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.cboItemsGasto)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(576, 124)
        Me.GroupBox2.TabIndex = 111
        Me.GroupBox2.TabStop = False
        '
        'lblCostoActual
        '
        Me.lblCostoActual.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoActual.Location = New System.Drawing.Point(399, 88)
        Me.lblCostoActual.Name = "lblCostoActual"
        Me.lblCostoActual.Size = New System.Drawing.Size(161, 22)
        Me.lblCostoActual.TabIndex = 108
        Me.lblCostoActual.Text = "[COSTO ACTUAL]"
        Me.lblCostoActual.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblUnidMed
        '
        Me.lblUnidMed.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidMed.Location = New System.Drawing.Point(208, 88)
        Me.lblUnidMed.Name = "lblUnidMed"
        Me.lblUnidMed.Size = New System.Drawing.Size(139, 22)
        Me.lblUnidMed.TabIndex = 107
        '
        'cboCuentas
        '
        Me.cboCuentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCuentas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuentas.FormattingEnabled = True
        Me.cboCuentas.Location = New System.Drawing.Point(107, 20)
        Me.cboCuentas.Name = "cboCuentas"
        Me.cboCuentas.Size = New System.Drawing.Size(316, 26)
        Me.cboCuentas.TabIndex = 106
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 22)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Cuenta"
        '
        'txtObservs
        '
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(107, 136)
        Me.txtObservs.MaxLength = 250
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(453, 85)
        Me.txtObservs.TabIndex = 3
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(107, 84)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(95, 27)
        Me.txtCantidad.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 22)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Observación"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 22)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Cantidad"
        '
        'cboItemsGasto
        '
        Me.cboItemsGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemsGasto.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboItemsGasto.FormattingEnabled = True
        Me.cboItemsGasto.Location = New System.Drawing.Point(107, 52)
        Me.cboItemsGasto.Name = "cboItemsGasto"
        Me.cboItemsGasto.Size = New System.Drawing.Size(453, 26)
        Me.cboItemsGasto.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 22)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Item Gasto"
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(7, 540)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(102, 30)
        Me.btnFinalizar.TabIndex = 112
        Me.btnFinalizar.Text = "Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtStock)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(441, 47)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(143, 57)
        Me.GroupBox3.TabIndex = 113
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Stock Actual"
        '
        'txtStock
        '
        Me.txtStock.Enabled = False
        Me.txtStock.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtStock.Location = New System.Drawing.Point(16, 20)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(111, 27)
        Me.txtStock.TabIndex = 114
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lvItemsConsumo
        '
        Me.lvItemsConsumo.AutoArrange = False
        Me.lvItemsConsumo.BackColor = System.Drawing.SystemColors.Window
        Me.lvItemsConsumo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNroLin, Me.colProductoNom, Me.colProductoCant, Me.colProductoCod, Me.colCuentaCod, Me.colItemGastoCod, Me.colGrabado, Me.colCuentaNom, Me.colItemGastoNom, Me.colProductoUM, Me.colProductoStk, Me.ColumnHeader1})
        Me.lvItemsConsumo.FullRowSelect = True
        Me.lvItemsConsumo.GridLines = True
        Me.lvItemsConsumo.HideSelection = False
        Me.lvItemsConsumo.Location = New System.Drawing.Point(7, 240)
        Me.lvItemsConsumo.MultiSelect = False
        Me.lvItemsConsumo.Name = "lvItemsConsumo"
        Me.lvItemsConsumo.Size = New System.Drawing.Size(725, 294)
        Me.lvItemsConsumo.TabIndex = 210
        Me.lvItemsConsumo.UseCompatibleStateImageBehavior = False
        Me.lvItemsConsumo.View = System.Windows.Forms.View.Details
        '
        'colNroLin
        '
        Me.colNroLin.Text = "Nro"
        Me.colNroLin.Width = 45
        '
        'colProductoNom
        '
        Me.colProductoNom.Text = "Producto"
        Me.colProductoNom.Width = 247
        '
        'colProductoCant
        '
        Me.colProductoCant.Text = "Cant"
        Me.colProductoCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.colProductoCant.Width = 70
        '
        'colProductoCod
        '
        Me.colProductoCod.Text = "Codigo Prod."
        Me.colProductoCod.Width = 0
        '
        'colCuentaCod
        '
        Me.colCuentaCod.Text = "Cuenta Cód."
        Me.colCuentaCod.Width = 0
        '
        'colItemGastoCod
        '
        Me.colItemGastoCod.Text = "Item Gasto Cód."
        Me.colItemGastoCod.Width = 0
        '
        'colGrabado
        '
        Me.colGrabado.Text = "Grabado"
        Me.colGrabado.Width = 0
        '
        'colCuentaNom
        '
        Me.colCuentaNom.Text = "Cuenta"
        Me.colCuentaNom.Width = 169
        '
        'colItemGastoNom
        '
        Me.colItemGastoNom.Text = "Item Gasto"
        Me.colItemGastoNom.Width = 190
        '
        'colProductoUM
        '
        Me.colProductoUM.Text = "Unid. Med."
        Me.colProductoUM.Width = 0
        '
        'colProductoStk
        '
        Me.colProductoStk.Text = "Stock"
        Me.colProductoStk.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(590, 158)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(130, 34)
        Me.btnAgregar.TabIndex = 211
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'grpFecha
        '
        Me.grpFecha.Controls.Add(Me.dtpFecha)
        Me.grpFecha.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFecha.Location = New System.Drawing.Point(590, 47)
        Me.grpFecha.Name = "grpFecha"
        Me.grpFecha.Size = New System.Drawing.Size(130, 57)
        Me.grpFecha.TabIndex = 212
        Me.grpFecha.TabStop = False
        Me.grpFecha.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(6, 21)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(118, 22)
        Me.dtpFecha.TabIndex = 1
        Me.dtpFecha.Value = New Date(2012, 10, 1, 0, 0, 0, 0)
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(115, 540)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(93, 30)
        Me.btnEliminar.TabIndex = 213
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'frmBodegaIngresoConsumo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 574)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.grpFecha)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lvItemsConsumo)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblCentro)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBodegaIngresoConsumo"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Consumo"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grpFecha.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCentro As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtObservs As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboItemsGasto As System.Windows.Forms.ComboBox
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboCuentas As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtStock As System.Windows.Forms.TextBox
    Friend WithEvents lblUnidMed As System.Windows.Forms.Label
    Friend WithEvents lblCostoActual As System.Windows.Forms.Label
    Friend WithEvents lvItemsConsumo As ListView
    Friend WithEvents colNroLin As ColumnHeader
    Friend WithEvents colProductoNom As ColumnHeader
    Friend WithEvents colProductoCant As ColumnHeader
    Friend WithEvents colProductoCod As ColumnHeader
    Friend WithEvents colCuentaCod As ColumnHeader
    Friend WithEvents colItemGastoCod As ColumnHeader
    Friend WithEvents colGrabado As ColumnHeader
    Friend WithEvents colCuentaNom As ColumnHeader
    Friend WithEvents colItemGastoNom As ColumnHeader
    Friend WithEvents colProductoUM As ColumnHeader
    Friend WithEvents colProductoStk As ColumnHeader
    Friend WithEvents cboItemsStk As ComboBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents grpFecha As GroupBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents btnEliminar As Button
    Friend WithEvents ColumnHeader1 As ColumnHeader
End Class
