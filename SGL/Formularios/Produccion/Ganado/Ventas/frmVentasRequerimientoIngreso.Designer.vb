<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentasRequerimientoIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentasRequerimientoIngreso))
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbAlta = New System.Windows.Forms.RadioButton()
        Me.rbNormal = New System.Windows.Forms.RadioButton()
        Me.cboClientes = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Diios = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvVentaDiio = New System.Windows.Forms.ListView()
        Me.N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Diio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CatCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CatNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PreUnit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PreTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EstProd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EstRep = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecpp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiasParto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FecParto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Salud = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Salida = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Causa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodCausa = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodSalida = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Estado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lvAprobadores = New System.Windows.Forms.ListView()
        Me.RUT = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnLeeBaston = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblErrores = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblTotDiios = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Diios.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCentros
        '
        Me.cboCentros.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(6, 21)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(296, 26)
        Me.cboCentros.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(308, 54)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centros"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbAlta)
        Me.GroupBox2.Controls.Add(Me.rbNormal)
        Me.GroupBox2.Location = New System.Drawing.Point(326, 47)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(149, 54)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Prioridad"
        '
        'rbAlta
        '
        Me.rbAlta.AutoSize = True
        Me.rbAlta.Location = New System.Drawing.Point(87, 22)
        Me.rbAlta.Name = "rbAlta"
        Me.rbAlta.Size = New System.Drawing.Size(51, 20)
        Me.rbAlta.TabIndex = 1
        Me.rbAlta.TabStop = True
        Me.rbAlta.Text = "Alta"
        Me.rbAlta.UseVisualStyleBackColor = True
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.rbNormal.Location = New System.Drawing.Point(6, 22)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(72, 20)
        Me.rbNormal.TabIndex = 0
        Me.rbNormal.TabStop = True
        Me.rbNormal.Text = "Normal"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'cboClientes
        '
        Me.cboClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClientes.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClientes.FormattingEnabled = True
        Me.cboClientes.Location = New System.Drawing.Point(6, 21)
        Me.cboClientes.Name = "cboClientes"
        Me.cboClientes.Size = New System.Drawing.Size(375, 26)
        Me.cboClientes.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboClientes)
        Me.GroupBox3.Location = New System.Drawing.Point(754, 47)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(387, 54)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cliente (Opcional)"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(12, 124)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(1267, 65)
        Me.txtObservacion.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Observación (Min. 10 Caracteres)"
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(11, 4)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(1271, 29)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "REQUERIMIENTO DE VENTA DE GANADO"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1298, 41)
        Me.Panel1.TabIndex = 75
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtpFecha)
        Me.GroupBox4.Location = New System.Drawing.Point(1147, 47)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(136, 54)
        Me.GroupBox4.TabIndex = 76
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Fecha Venta"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(7, 21)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(117, 22)
        Me.dtpFecha.TabIndex = 77
        '
        'Diios
        '
        Me.Diios.Controls.Add(Me.TabPage1)
        Me.Diios.Controls.Add(Me.TabPage2)
        Me.Diios.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Diios.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Diios.Location = New System.Drawing.Point(12, 195)
        Me.Diios.Name = "Diios"
        Me.Diios.SelectedIndex = 0
        Me.Diios.Size = New System.Drawing.Size(1271, 244)
        Me.Diios.TabIndex = 77
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.lvVentaDiio)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1263, 213)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "DIIOS"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lvVentaDiio
        '
        Me.lvVentaDiio.AutoArrange = False
        Me.lvVentaDiio.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.N, Me.Diio, Me.CatCod, Me.CatNom, Me.PreUnit, Me.PreTotal, Me.EstProd, Me.EstRep, Me.Fecpp, Me.DiasParto, Me.FecParto, Me.Salud, Me.Salida, Me.Causa, Me.CodCausa, Me.CodSalida, Me.Estado})
        Me.lvVentaDiio.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvVentaDiio.FullRowSelect = True
        Me.lvVentaDiio.GridLines = True
        Me.lvVentaDiio.HideSelection = False
        Me.lvVentaDiio.Location = New System.Drawing.Point(3, 3)
        Me.lvVentaDiio.Name = "lvVentaDiio"
        Me.lvVentaDiio.Size = New System.Drawing.Size(1257, 207)
        Me.lvVentaDiio.TabIndex = 0
        Me.lvVentaDiio.UseCompatibleStateImageBehavior = False
        Me.lvVentaDiio.View = System.Windows.Forms.View.Details
        '
        'N
        '
        Me.N.Text = "N°"
        Me.N.Width = 37
        '
        'Diio
        '
        Me.Diio.Text = "Diio"
        Me.Diio.Width = 87
        '
        'CatCod
        '
        Me.CatCod.Text = "Cod. Categoria"
        Me.CatCod.Width = 0
        '
        'CatNom
        '
        Me.CatNom.Text = "Categoria"
        Me.CatNom.Width = 120
        '
        'PreUnit
        '
        Me.PreUnit.Text = "Precio Unitario"
        Me.PreUnit.Width = 115
        '
        'PreTotal
        '
        Me.PreTotal.Text = "Precio Total"
        Me.PreTotal.Width = 104
        '
        'EstProd
        '
        Me.EstProd.Text = "Est. Productivo"
        Me.EstProd.Width = 120
        '
        'EstRep
        '
        Me.EstRep.Text = "Est. Reproductivo"
        Me.EstRep.Width = 137
        '
        'Fecpp
        '
        Me.Fecpp.Text = "Fecha PP."
        Me.Fecpp.Width = 109
        '
        'DiasParto
        '
        Me.DiasParto.Text = "Dias Aprox. Parto"
        '
        'FecParto
        '
        Me.FecParto.Text = "Dias Parto"
        '
        'Salud
        '
        Me.Salud.Text = "Est. Salud"
        Me.Salud.Width = 92
        '
        'Salida
        '
        Me.Salida.Text = "Salida"
        '
        'Causa
        '
        Me.Causa.Text = "Causa"
        '
        'CodCausa
        '
        Me.CodCausa.Text = "Cod. Causa"
        Me.CodCausa.Width = 0
        '
        'CodSalida
        '
        Me.CodSalida.Text = "Cod. Salida"
        Me.CodSalida.Width = 0
        '
        'Estado
        '
        Me.Estado.Text = "Estado"
        Me.Estado.Width = 350
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lvAprobadores)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1263, 213)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Firmantes"
        '
        'lvAprobadores
        '
        Me.lvAprobadores.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.RUT, Me.Nombre})
        Me.lvAprobadores.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvAprobadores.GridLines = True
        Me.lvAprobadores.HideSelection = False
        Me.lvAprobadores.Location = New System.Drawing.Point(-1, 0)
        Me.lvAprobadores.Name = "lvAprobadores"
        Me.lvAprobadores.Size = New System.Drawing.Size(991, 213)
        Me.lvAprobadores.TabIndex = 0
        Me.lvAprobadores.UseCompatibleStateImageBehavior = False
        Me.lvAprobadores.View = System.Windows.Forms.View.Details
        '
        'RUT
        '
        Me.RUT.Text = "RUT"
        Me.RUT.Width = 103
        '
        'Nombre
        '
        Me.Nombre.Text = "Nombre"
        Me.Nombre.Width = 883
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(152, 483)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(180, 38)
        Me.Button1.TabIndex = 79
        Me.Button1.Text = "Asignar Tipo Causa"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(338, 483)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(108, 39)
        Me.btnGrabar.TabIndex = 80
        Me.btnGrabar.Text = "Finalizar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(1175, 484)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(104, 38)
        Me.btnCerrar.TabIndex = 81
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnLeeBaston
        '
        Me.btnLeeBaston.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeeBaston.Image = CType(resources.GetObject("btnLeeBaston.Image"), System.Drawing.Image)
        Me.btnLeeBaston.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLeeBaston.Location = New System.Drawing.Point(12, 483)
        Me.btnLeeBaston.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLeeBaston.Name = "btnLeeBaston"
        Me.btnLeeBaston.Size = New System.Drawing.Size(133, 37)
        Me.btnLeeBaston.TabIndex = 82
        Me.btnLeeBaston.Text = "   Lee Bastón"
        Me.btnLeeBaston.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLeeBaston.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(452, 483)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(118, 39)
        Me.btnEliminar.TabIndex = 83
        Me.btnEliminar.Text = "Quitar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblErrores)
        Me.pnlEstReprod.Controls.Add(Me.Label9)
        Me.pnlEstReprod.Controls.Add(Me.lblTotDiios)
        Me.pnlEstReprod.Controls.Add(Me.Label10)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(12, 442)
        Me.pnlEstReprod.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1267, 33)
        Me.pnlEstReprod.TabIndex = 223
        '
        'lblErrores
        '
        Me.lblErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrores.Location = New System.Drawing.Point(344, 2)
        Me.lblErrores.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblErrores.Name = "lblErrores"
        Me.lblErrores.Size = New System.Drawing.Size(64, 26)
        Me.lblErrores.TabIndex = 49
        Me.lblErrores.Text = "0"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(233, 2)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 26)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Errores"
        '
        'lblTotDiios
        '
        Me.lblTotDiios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDiios.Location = New System.Drawing.Point(168, 4)
        Me.lblTotDiios.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotDiios.Name = "lblTotDiios"
        Me.lblTotDiios.Size = New System.Drawing.Size(57, 26)
        Me.lblTotDiios.TabIndex = 1
        Me.lblTotDiios.Text = "0"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 2)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(247, 26)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Numero Registros"
        '
        'frmVentasRequerimientoIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1295, 530)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnLeeBaston)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Diios)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVentasRequerimientoIngreso"
        Me.Text = "REQUERIMIENTO VENTA"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Diios.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cboCentros As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rbAlta As RadioButton
    Friend WithEvents rbNormal As RadioButton
    Friend WithEvents cboClientes As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtObservacion As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Diios As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lvVentaDiio As ListView
    Friend WithEvents N As ColumnHeader
    Friend WithEvents Diio As ColumnHeader
    Friend WithEvents CatCod As ColumnHeader
    Friend WithEvents CatNom As ColumnHeader
    Friend WithEvents PreUnit As ColumnHeader
    Friend WithEvents PreTotal As ColumnHeader
    Friend WithEvents EstProd As ColumnHeader
    Friend WithEvents EstRep As ColumnHeader
    Friend WithEvents Fecpp As ColumnHeader
    Friend WithEvents Salud As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents Salida As ColumnHeader
    Friend WithEvents Causa As ColumnHeader
    Friend WithEvents btnGrabar As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents lvAprobadores As ListView
    Friend WithEvents RUT As ColumnHeader
    Friend WithEvents Nombre As ColumnHeader
    Friend WithEvents btnLeeBaston As Button
    Friend WithEvents CodCausa As ColumnHeader
    Friend WithEvents CodSalida As ColumnHeader
    Friend WithEvents Estado As ColumnHeader
    Friend WithEvents btnEliminar As Button
    Friend WithEvents pnlEstReprod As Panel
    Friend WithEvents lblErrores As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblTotDiios As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents DiasParto As ColumnHeader
    Friend WithEvents FecParto As ColumnHeader
End Class
