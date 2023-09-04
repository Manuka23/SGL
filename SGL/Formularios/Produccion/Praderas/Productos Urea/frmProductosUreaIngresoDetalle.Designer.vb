<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductosUreaIngresoDetalle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductosUreaIngresoDetalle))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtLimiteConsumo = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblItemGasto2 = New System.Windows.Forms.Label()
        Me.txtCodPresupuesto2 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtNomCuenta2 = New System.Windows.Forms.Label()
        Me.txtCodCuenta2 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtFosforo = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtPotasio = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAzufre = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoUso = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tipCentro = New System.Windows.Forms.ComboBox()
        Me.txtItemGasto = New System.Windows.Forms.Label()
        Me.txtNomCuenta = New System.Windows.Forms.Label()
        Me.txtNomProducto = New System.Windows.Forms.Label()
        Me.txtCodPresupuesto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodCuenta = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodProducto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNitro = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(1, -4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(578, 59)
        Me.Panel1.TabIndex = 129
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(27, 15)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(536, 41)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "DETALLE PRODUCTO"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(16, 712)
        Me.btnFinalizar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(132, 43)
        Me.btnFinalizar.TabIndex = 128
        Me.btnFinalizar.Text = "   Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(432, 712)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(132, 43)
        Me.Button3.TabIndex = 127
        Me.Button3.Text = "Cerrar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtLimiteConsumo)
        Me.GroupBox5.Controls.Add(Me.Label20)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.lblItemGasto2)
        Me.GroupBox5.Controls.Add(Me.txtCodPresupuesto2)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.txtNomCuenta2)
        Me.GroupBox5.Controls.Add(Me.txtCodCuenta2)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.txtFosforo)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.txtPotasio)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.txtAzufre)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.cboTipoUso)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.tipCentro)
        Me.GroupBox5.Controls.Add(Me.txtItemGasto)
        Me.GroupBox5.Controls.Add(Me.txtNomCuenta)
        Me.GroupBox5.Controls.Add(Me.txtNomProducto)
        Me.GroupBox5.Controls.Add(Me.txtCodPresupuesto)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.txtCodCuenta)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.txtCodProducto)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.txtNitro)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(16, 63)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox5.Size = New System.Drawing.Size(548, 641)
        Me.GroupBox5.TabIndex = 126
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Parámetros"
        '
        'txtLimiteConsumo
        '
        Me.txtLimiteConsumo.Location = New System.Drawing.Point(134, 265)
        Me.txtLimiteConsumo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtLimiteConsumo.Name = "txtLimiteConsumo"
        Me.txtLimiteConsumo.Size = New System.Drawing.Size(197, 27)
        Me.txtLimiteConsumo.TabIndex = 44
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 269)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 21)
        Me.Label20.TabIndex = 43
        Me.Label20.Text = "Limite Consumo:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 516)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(419, 21)
        Me.Label17.TabIndex = 42
        Me.Label17.Text = "pasado el valor ""Limite Consumo"" en ""Otros Fertilizantes"""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 495)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(488, 21)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Cuenta 2 e Item Gasto 2 se usan para registrar el consumo luego de"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblItemGasto2
        '
        Me.lblItemGasto2.AutoSize = True
        Me.lblItemGasto2.Location = New System.Drawing.Point(339, 363)
        Me.lblItemGasto2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemGasto2.Name = "lblItemGasto2"
        Me.lblItemGasto2.Size = New System.Drawing.Size(25, 21)
        Me.lblItemGasto2.TabIndex = 40
        Me.lblItemGasto2.Text = "---"
        '
        'txtCodPresupuesto2
        '
        Me.txtCodPresupuesto2.Location = New System.Drawing.Point(134, 359)
        Me.txtCodPresupuesto2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodPresupuesto2.Name = "txtCodPresupuesto2"
        Me.txtCodPresupuesto2.Size = New System.Drawing.Size(197, 27)
        Me.txtCodPresupuesto2.TabIndex = 39
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 363)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(105, 21)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Item Gasto 2:"
        '
        'txtNomCuenta2
        '
        Me.txtNomCuenta2.AutoSize = True
        Me.txtNomCuenta2.Location = New System.Drawing.Point(339, 318)
        Me.txtNomCuenta2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtNomCuenta2.Name = "txtNomCuenta2"
        Me.txtNomCuenta2.Size = New System.Drawing.Size(25, 21)
        Me.txtNomCuenta2.TabIndex = 37
        Me.txtNomCuenta2.Text = "---"
        '
        'txtCodCuenta2
        '
        Me.txtCodCuenta2.Location = New System.Drawing.Point(134, 314)
        Me.txtCodCuenta2.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodCuenta2.Name = "txtCodCuenta2"
        Me.txtCodCuenta2.Size = New System.Drawing.Size(197, 27)
        Me.txtCodCuenta2.TabIndex = 36
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(8, 318)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 21)
        Me.Label16.TabIndex = 35
        Me.Label16.Text = "Cuenta 2:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(471, 446)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 24)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "%"
        '
        'txtFosforo
        '
        Me.txtFosforo.Location = New System.Drawing.Point(409, 443)
        Me.txtFosforo.Name = "txtFosforo"
        Me.txtFosforo.Size = New System.Drawing.Size(56, 27)
        Me.txtFosforo.TabIndex = 33
        Me.txtFosforo.Text = "0"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(309, 449)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 21)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "Fosforo(P%)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(471, 409)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 24)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "%"
        '
        'txtPotasio
        '
        Me.txtPotasio.Location = New System.Drawing.Point(408, 406)
        Me.txtPotasio.Name = "txtPotasio"
        Me.txtPotasio.Size = New System.Drawing.Size(56, 27)
        Me.txtPotasio.TabIndex = 30
        Me.txtPotasio.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(309, 409)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 21)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Potasio(K%)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(199, 451)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 24)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "%"
        '
        'txtAzufre
        '
        Me.txtAzufre.Location = New System.Drawing.Point(134, 446)
        Me.txtAzufre.Name = "txtAzufre"
        Me.txtAzufre.Size = New System.Drawing.Size(56, 27)
        Me.txtAzufre.TabIndex = 27
        Me.txtAzufre.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 449)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 21)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Azufre(S%)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 217)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 21)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Tipo Uso:"
        '
        'cboTipoUso
        '
        Me.cboTipoUso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoUso.FormattingEnabled = True
        Me.cboTipoUso.Location = New System.Drawing.Point(134, 214)
        Me.cboTipoUso.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoUso.Name = "cboTipoUso"
        Me.cboTipoUso.Size = New System.Drawing.Size(197, 27)
        Me.cboTipoUso.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(199, 409)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 24)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 172)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 21)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Centro Tipo:"
        '
        'tipCentro
        '
        Me.tipCentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tipCentro.FormattingEnabled = True
        Me.tipCentro.Location = New System.Drawing.Point(134, 169)
        Me.tipCentro.Margin = New System.Windows.Forms.Padding(4)
        Me.tipCentro.Name = "tipCentro"
        Me.tipCentro.Size = New System.Drawing.Size(197, 27)
        Me.tipCentro.TabIndex = 19
        '
        'txtItemGasto
        '
        Me.txtItemGasto.AutoSize = True
        Me.txtItemGasto.Location = New System.Drawing.Point(339, 121)
        Me.txtItemGasto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtItemGasto.Name = "txtItemGasto"
        Me.txtItemGasto.Size = New System.Drawing.Size(25, 21)
        Me.txtItemGasto.TabIndex = 18
        Me.txtItemGasto.Text = "---"
        '
        'txtNomCuenta
        '
        Me.txtNomCuenta.AutoSize = True
        Me.txtNomCuenta.Location = New System.Drawing.Point(339, 79)
        Me.txtNomCuenta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtNomCuenta.Name = "txtNomCuenta"
        Me.txtNomCuenta.Size = New System.Drawing.Size(25, 21)
        Me.txtNomCuenta.TabIndex = 17
        Me.txtNomCuenta.Text = "---"
        '
        'txtNomProducto
        '
        Me.txtNomProducto.AutoSize = True
        Me.txtNomProducto.Location = New System.Drawing.Point(339, 40)
        Me.txtNomProducto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtNomProducto.Name = "txtNomProducto"
        Me.txtNomProducto.Size = New System.Drawing.Size(25, 21)
        Me.txtNomProducto.TabIndex = 16
        Me.txtNomProducto.Text = "---"
        '
        'txtCodPresupuesto
        '
        Me.txtCodPresupuesto.Location = New System.Drawing.Point(134, 117)
        Me.txtCodPresupuesto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodPresupuesto.Name = "txtCodPresupuesto"
        Me.txtCodPresupuesto.Size = New System.Drawing.Size(197, 27)
        Me.txtCodPresupuesto.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 121)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 21)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Item Gasto:"
        '
        'txtCodCuenta
        '
        Me.txtCodCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodCuenta.Location = New System.Drawing.Point(134, 76)
        Me.txtCodCuenta.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodCuenta.Name = "txtCodCuenta"
        Me.txtCodCuenta.Size = New System.Drawing.Size(197, 27)
        Me.txtCodCuenta.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 76)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 21)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Cuenta:"
        '
        'txtCodProducto
        '
        Me.txtCodProducto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodProducto.Location = New System.Drawing.Point(134, 34)
        Me.txtCodProducto.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodProducto.Name = "txtCodProducto"
        Me.txtCodProducto.Size = New System.Drawing.Size(197, 27)
        Me.txtCodProducto.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 34)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 21)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Producto:"
        '
        'txtNitro
        '
        Me.txtNitro.Location = New System.Drawing.Point(134, 406)
        Me.txtNitro.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNitro.Name = "txtNitro"
        Me.txtNitro.Size = New System.Drawing.Size(56, 27)
        Me.txtNitro.TabIndex = 4
        Me.txtNitro.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 409)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nitrogeno(N%):"
        '
        'frmProductosUreaIngresoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 815)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductosUreaIngresoDetalle"
        Me.Text = "Producto Urea Detalle"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtItemGasto As Label
    Friend WithEvents txtNomCuenta As Label
    Friend WithEvents txtNomProducto As Label
    Friend WithEvents txtCodPresupuesto As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCodCuenta As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCodProducto As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNitro As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents tipCentro As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cboTipoUso As ComboBox
    Friend WithEvents txtAzufre As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtFosforo As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtPotasio As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblItemGasto2 As Label
    Friend WithEvents txtCodPresupuesto2 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtNomCuenta2 As Label
    Friend WithEvents txtCodCuenta2 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtLimiteConsumo As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label17 As Label
End Class
