<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBodegaIngresoTraslado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBodegaIngresoTraslado))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtStock = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboEmpresaInCompania = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chbInterCompania = New System.Windows.Forms.CheckBox()
        Me.lblCostoActual = New System.Windows.Forms.Label()
        Me.lblUnidMed = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cboBodegaDestino = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboItems = New System.Windows.Forms.ComboBox()
        Me.lblCentro = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lvItemsTraslado = New System.Windows.Forms.ListView()
        Me.NroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemNomCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CantCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UMCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GrabadoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemStockCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DestinoCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DestinoNomCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClaseCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemPrcUnitCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemPrcTotCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grpFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtStock)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(584, 57)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(191, 70)
        Me.GroupBox3.TabIndex = 120
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Stock Actual"
        '
        'txtStock
        '
        Me.txtStock.Enabled = False
        Me.txtStock.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtStock.Location = New System.Drawing.Point(21, 25)
        Me.txtStock.Margin = New System.Windows.Forms.Padding(4)
        Me.txtStock.Name = "txtStock"
        Me.txtStock.Size = New System.Drawing.Size(147, 32)
        Me.txtStock.TabIndex = 114
        Me.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboEmpresaInCompania)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.chbInterCompania)
        Me.GroupBox2.Controls.Add(Me.lblCostoActual)
        Me.GroupBox2.Controls.Add(Me.lblUnidMed)
        Me.GroupBox2.Controls.Add(Me.btnAgregar)
        Me.GroupBox2.Controls.Add(Me.cboBodegaDestino)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtObservs)
        Me.GroupBox2.Controls.Add(Me.txtCantidad)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 134)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(975, 166)
        Me.GroupBox2.TabIndex = 118
        Me.GroupBox2.TabStop = False
        '
        'cboEmpresaInCompania
        '
        Me.cboEmpresaInCompania.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresaInCompania.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpresaInCompania.FormattingEnabled = True
        Me.cboEmpresaInCompania.Location = New System.Drawing.Point(143, 22)
        Me.cboEmpresaInCompania.Margin = New System.Windows.Forms.Padding(4)
        Me.cboEmpresaInCompania.Name = "cboEmpresaInCompania"
        Me.cboEmpresaInCompania.Size = New System.Drawing.Size(270, 31)
        Me.cboEmpresaInCompania.TabIndex = 217
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 24)
        Me.Label2.TabIndex = 216
        Me.Label2.Text = "Empresa"
        '
        'chbInterCompania
        '
        Me.chbInterCompania.AutoSize = True
        Me.chbInterCompania.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbInterCompania.Location = New System.Drawing.Point(424, 23)
        Me.chbInterCompania.Name = "chbInterCompania"
        Me.chbInterCompania.Size = New System.Drawing.Size(340, 28)
        Me.chbInterCompania.TabIndex = 215
        Me.chbInterCompania.Text = "Realizar Movimiento Inter-Comapñia"
        Me.chbInterCompania.UseVisualStyleBackColor = True
        '
        'lblCostoActual
        '
        Me.lblCostoActual.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoActual.Location = New System.Drawing.Point(571, 71)
        Me.lblCostoActual.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoActual.Name = "lblCostoActual"
        Me.lblCostoActual.Size = New System.Drawing.Size(215, 27)
        Me.lblCostoActual.TabIndex = 108
        Me.lblCostoActual.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblUnidMed
        '
        Me.lblUnidMed.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidMed.Location = New System.Drawing.Point(276, 130)
        Me.lblUnidMed.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnidMed.Name = "lblUnidMed"
        Me.lblUnidMed.Size = New System.Drawing.Size(185, 27)
        Me.lblUnidMed.TabIndex = 107
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(788, 116)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(157, 42)
        Me.btnAgregar.TabIndex = 214
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'cboBodegaDestino
        '
        Me.cboBodegaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBodegaDestino.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBodegaDestino.FormattingEnabled = True
        Me.cboBodegaDestino.Location = New System.Drawing.Point(143, 75)
        Me.cboBodegaDestino.Margin = New System.Windows.Forms.Padding(4)
        Me.cboBodegaDestino.Name = "cboBodegaDestino"
        Me.cboBodegaDestino.Size = New System.Drawing.Size(420, 31)
        Me.cboBodegaDestino.TabIndex = 106
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 75)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 27)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Destino"
        '
        'txtObservs
        '
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(143, 167)
        Me.txtObservs.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObservs.MaxLength = 250
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(603, 104)
        Me.txtObservs.TabIndex = 3
        '
        'txtCantidad
        '
        Me.txtCantidad.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(143, 126)
        Me.txtCantidad.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantidad.MaxLength = 8
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(125, 32)
        Me.txtCantidad.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 167)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 27)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "Observación"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 130)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 27)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Cantidad"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboItems)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(11, 57)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(565, 70)
        Me.GroupBox1.TabIndex = 117
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Producto"
        '
        'cboItems
        '
        Me.cboItems.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItems.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItems.FormattingEnabled = True
        Me.cboItems.Location = New System.Drawing.Point(20, 25)
        Me.cboItems.Margin = New System.Windows.Forms.Padding(4)
        Me.cboItems.Name = "cboItems"
        Me.cboItems.Size = New System.Drawing.Size(531, 31)
        Me.cboItems.TabIndex = 212
        Me.cboItems.Text = "-- ELEGIR PRODUCTO --"
        '
        'lblCentro
        '
        Me.lblCentro.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCentro.Location = New System.Drawing.Point(101, 53)
        Me.lblCentro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCentro.Name = "lblCentro"
        Me.lblCentro.Size = New System.Drawing.Size(900, 28)
        Me.lblCentro.TabIndex = 116
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGreen
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(-3, -1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1004, 50)
        Me.Panel1.TabIndex = 114
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(4, 12)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(1000, 36)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "INGRESO DE TRASLADO"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Enabled = False
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(11, 664)
        Me.btnFinalizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(125, 37)
        Me.btnFinalizar.TabIndex = 119
        Me.btnFinalizar.Text = "Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(874, 664)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 37)
        Me.btnSalir.TabIndex = 115
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lvItemsTraslado
        '
        Me.lvItemsTraslado.AutoArrange = False
        Me.lvItemsTraslado.BackColor = System.Drawing.SystemColors.Window
        Me.lvItemsTraslado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NroCol, Me.ItemCodCol, Me.ItemNomCol, Me.CantCol, Me.UMCol, Me.GrabadoCol, Me.ItemStockCol, Me.DestinoCodCol, Me.DestinoNomCol, Me.ClaseCol, Me.ItemPrcUnitCol, Me.ItemPrcTotCol})
        Me.lvItemsTraslado.FullRowSelect = True
        Me.lvItemsTraslado.GridLines = True
        Me.lvItemsTraslado.HideSelection = False
        Me.lvItemsTraslado.Location = New System.Drawing.Point(11, 332)
        Me.lvItemsTraslado.Margin = New System.Windows.Forms.Padding(4)
        Me.lvItemsTraslado.MultiSelect = False
        Me.lvItemsTraslado.Name = "lvItemsTraslado"
        Me.lvItemsTraslado.Size = New System.Drawing.Size(975, 322)
        Me.lvItemsTraslado.TabIndex = 210
        Me.lvItemsTraslado.UseCompatibleStateImageBehavior = False
        Me.lvItemsTraslado.View = System.Windows.Forms.View.Details
        '
        'NroCol
        '
        Me.NroCol.Text = "Nro"
        Me.NroCol.Width = 45
        '
        'ItemCodCol
        '
        Me.ItemCodCol.Text = "Codigo Prod."
        Me.ItemCodCol.Width = 0
        '
        'ItemNomCol
        '
        Me.ItemNomCol.Text = "Producto"
        Me.ItemNomCol.Width = 360
        '
        'CantCol
        '
        Me.CantCol.Text = "Cant"
        Me.CantCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CantCol.Width = 70
        '
        'UMCol
        '
        Me.UMCol.Text = "Unid. Med."
        Me.UMCol.Width = 0
        '
        'GrabadoCol
        '
        Me.GrabadoCol.Text = "Grabado"
        Me.GrabadoCol.Width = 0
        '
        'ItemStockCol
        '
        Me.ItemStockCol.Text = "Stock"
        Me.ItemStockCol.Width = 0
        '
        'DestinoCodCol
        '
        Me.DestinoCodCol.Text = "Cod Destino"
        Me.DestinoCodCol.Width = 0
        '
        'DestinoNomCol
        '
        Me.DestinoNomCol.Text = "Destino"
        Me.DestinoNomCol.Width = 190
        '
        'ClaseCol
        '
        Me.ClaseCol.Text = "Clase"
        Me.ClaseCol.Width = 0
        '
        'ItemPrcUnitCol
        '
        Me.ItemPrcUnitCol.Text = "Prc. Unit"
        Me.ItemPrcUnitCol.Width = 0
        '
        'ItemPrcTotCol
        '
        Me.ItemPrcTotCol.Text = "Prc. Tot."
        Me.ItemPrcTotCol.Width = 0
        '
        'grpFecha
        '
        Me.grpFecha.Controls.Add(Me.dtpFecha)
        Me.grpFecha.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFecha.Location = New System.Drawing.Point(783, 57)
        Me.grpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.grpFecha.Name = "grpFecha"
        Me.grpFecha.Padding = New System.Windows.Forms.Padding(4)
        Me.grpFecha.Size = New System.Drawing.Size(173, 70)
        Me.grpFecha.TabIndex = 215
        Me.grpFecha.TabStop = False
        Me.grpFecha.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(8, 26)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(156, 26)
        Me.dtpFecha.TabIndex = 1
        Me.dtpFecha.Value = New Date(2012, 10, 1, 0, 0, 0, 0)
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(144, 664)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(124, 37)
        Me.btnEliminar.TabIndex = 216
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'frmBodegaIngresoTraslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 746)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.grpFecha)
        Me.Controls.Add(Me.lvItemsTraslado)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblCentro)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBodegaIngresoTraslado"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso Traslado"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.grpFecha.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtStock As TextBox
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblCostoActual As Label
    Friend WithEvents lblUnidMed As Label
    Friend WithEvents cboBodegaDestino As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtObservs As TextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblCentro As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents lvItemsTraslado As ListView
    Friend WithEvents NroCol As ColumnHeader
    Friend WithEvents ItemCodCol As ColumnHeader
    Friend WithEvents ItemNomCol As ColumnHeader
    Friend WithEvents CantCol As ColumnHeader
    Friend WithEvents UMCol As ColumnHeader
    Friend WithEvents GrabadoCol As ColumnHeader
    Friend WithEvents ItemStockCol As ColumnHeader
    Friend WithEvents DestinoCodCol As ColumnHeader
    Friend WithEvents DestinoNomCol As ColumnHeader
    Friend WithEvents ClaseCol As ColumnHeader
    Friend WithEvents ItemPrcUnitCol As ColumnHeader
    Friend WithEvents ItemPrcTotCol As ColumnHeader
    Friend WithEvents grpFecha As GroupBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents btnAgregar As Button
    Friend WithEvents cboItems As ComboBox
    Friend WithEvents btnEliminar As Button
    Friend WithEvents chbInterCompania As CheckBox
    Friend WithEvents cboEmpresaInCompania As ComboBox
    Friend WithEvents Label2 As Label
End Class
