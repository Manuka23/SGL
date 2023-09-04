<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductosUreaIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductosUreaIngreso))
        Me.txtProd = New System.Windows.Forms.TextBox()
        Me.lvInsumos = New System.Windows.Forms.ListView()
        Me.N = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.EmpresaCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProductoCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroTipo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FertNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ProductoNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CuentaCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CuentaNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nitrogeno = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Azufre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Potasio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fosforo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FertCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tipCentro = New System.Windows.Forms.ComboBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtProd
        '
        Me.txtProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProd.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProd.Location = New System.Drawing.Point(8, 21)
        Me.txtProd.Margin = New System.Windows.Forms.Padding(4)
        Me.txtProd.Name = "txtProd"
        Me.txtProd.Size = New System.Drawing.Size(215, 32)
        Me.txtProd.TabIndex = 228
        '
        'lvInsumos
        '
        Me.lvInsumos.AutoArrange = False
        Me.lvInsumos.BackColor = System.Drawing.SystemColors.Window
        Me.lvInsumos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.N, Me.EmpresaCod, Me.ProductoCod, Me.CentroTipo, Me.FertNom, Me.ProductoNom, Me.CuentaCod, Me.CuentaNom, Me.ItemCod, Me.ItemNom, Me.Nitrogeno, Me.Azufre, Me.Potasio, Me.Fosforo, Me.FertCod})
        Me.lvInsumos.FullRowSelect = True
        Me.lvInsumos.GridLines = True
        Me.lvInsumos.HideSelection = False
        Me.lvInsumos.Location = New System.Drawing.Point(4, 129)
        Me.lvInsumos.Margin = New System.Windows.Forms.Padding(4)
        Me.lvInsumos.MultiSelect = False
        Me.lvInsumos.Name = "lvInsumos"
        Me.lvInsumos.Size = New System.Drawing.Size(1329, 360)
        Me.lvInsumos.TabIndex = 216
        Me.lvInsumos.UseCompatibleStateImageBehavior = False
        Me.lvInsumos.View = System.Windows.Forms.View.Details
        '
        'N
        '
        Me.N.Text = "Nro"
        Me.N.Width = 34
        '
        'EmpresaCod
        '
        Me.EmpresaCod.Text = "EmpresaCod"
        Me.EmpresaCod.Width = 0
        '
        'ProductoCod
        '
        Me.ProductoCod.Text = "Cod. Producto"
        Me.ProductoCod.Width = 0
        '
        'CentroTipo
        '
        Me.CentroTipo.Text = "Tipo Centro"
        Me.CentroTipo.Width = 88
        '
        'FertNom
        '
        Me.FertNom.Text = "Fertilizante Tipo"
        Me.FertNom.Width = 130
        '
        'ProductoNom
        '
        Me.ProductoNom.Text = "Nombre Producto"
        Me.ProductoNom.Width = 170
        '
        'CuentaCod
        '
        Me.CuentaCod.Text = "Cod. Cuenta"
        Me.CuentaCod.Width = 0
        '
        'CuentaNom
        '
        Me.CuentaNom.Text = "Nombre Cuenta"
        Me.CuentaNom.Width = 110
        '
        'ItemCod
        '
        Me.ItemCod.Text = "Cod. Item G."
        Me.ItemCod.Width = 0
        '
        'ItemNom
        '
        Me.ItemNom.Text = "Item Gasto"
        Me.ItemNom.Width = 120
        '
        'Nitrogeno
        '
        Me.Nitrogeno.Text = "% Nitrogeno"
        Me.Nitrogeno.Width = 90
        '
        'Azufre
        '
        Me.Azufre.Text = "% Azufre"
        Me.Azufre.Width = 75
        '
        'Potasio
        '
        Me.Potasio.Text = "% Potasio"
        Me.Potasio.Width = 75
        '
        'Fosforo
        '
        Me.Fosforo.Text = "% Fosforo"
        Me.Fosforo.Width = 77
        '
        'FertCod
        '
        Me.FertCod.Text = "Cod. Fertilizante"
        Me.FertCod.Width = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblOrden)
        Me.Panel2.Controls.Add(Me.Label61)
        Me.Panel2.Location = New System.Drawing.Point(4, 169)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(918, 28)
        Me.Panel2.TabIndex = 220
        '
        'lblOrden
        '
        Me.lblOrden.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.ForeColor = System.Drawing.Color.White
        Me.lblOrden.Location = New System.Drawing.Point(153, 1)
        Me.lblOrden.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(908, 23)
        Me.lblOrden.TabIndex = 0
        Me.lblOrden.Text = "Centro -> Inicio Periodo"
        Me.lblOrden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label61
        '
        Me.Label61.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.White
        Me.Label61.Location = New System.Drawing.Point(11, 1)
        Me.Label61.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(161, 23)
        Me.Label61.TabIndex = 1
        Me.Label61.Text = "ORDENAR POR:"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-8, -5)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1368, 50)
        Me.Panel1.TabIndex = 215
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 14)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1320, 36)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Maestro Fertilización de Suelo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtProd)
        Me.GroupBox1.Location = New System.Drawing.Point(205, 53)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(232, 68)
        Me.GroupBox1.TabIndex = 229
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nombre Producto"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(1217, 70)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(116, 42)
        Me.btnBuscar.TabIndex = 227
        Me.btnBuscar.Text = "Buscar "
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(392, 494)
        Me.btnExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(117, 37)
        Me.btnExcel.TabIndex = 226
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.Image = CType(resources.GetObject("btnConfirmar.Image"), System.Drawing.Image)
        Me.btnConfirmar.Location = New System.Drawing.Point(5, 494)
        Me.btnConfirmar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(123, 37)
        Me.btnConfirmar.TabIndex = 223
        Me.btnConfirmar.Text = "Agregar"
        Me.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(268, 494)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(116, 37)
        Me.btnEliminar.TabIndex = 218
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1217, 494)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 37)
        Me.btnSalir.TabIndex = 217
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.SGL.My.Resources.Resources.add
        Me.Button1.Location = New System.Drawing.Point(136, 494)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 37)
        Me.Button1.TabIndex = 230
        Me.Button1.Text = "Actualizar"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tipCentro)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(4, 49)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(193, 70)
        Me.GroupBox2.TabIndex = 234
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo Centro"
        '
        'tipCentro
        '
        Me.tipCentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tipCentro.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipCentro.FormattingEnabled = True
        Me.tipCentro.Location = New System.Drawing.Point(8, 26)
        Me.tipCentro.Margin = New System.Windows.Forms.Padding(4)
        Me.tipCentro.Name = "tipCentro"
        Me.tipCentro.Size = New System.Drawing.Size(176, 31)
        Me.tipCentro.TabIndex = 0
        '
        'frmProductosUreaIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1358, 580)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.lvInsumos)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProductosUreaIngreso"
        Me.Text = "Productos Urea"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txtProd As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnConfirmar As Button
    Friend WithEvents lvInsumos As ListView
    Friend WithEvents N As ColumnHeader
    Friend WithEvents EmpresaCod As ColumnHeader
    Friend WithEvents ProductoCod As ColumnHeader
    Friend WithEvents ProductoNom As ColumnHeader
    Friend WithEvents CuentaCod As ColumnHeader
    Friend WithEvents CuentaNom As ColumnHeader
    Friend WithEvents ItemCod As ColumnHeader
    Friend WithEvents ItemNom As ColumnHeader
    Friend WithEvents CentroTipo As ColumnHeader
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblOrden As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Nitrogeno As ColumnHeader
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tipCentro As ComboBox
    Friend WithEvents FertCod As ColumnHeader
    Friend WithEvents FertNom As ColumnHeader
    Friend WithEvents Azufre As ColumnHeader
    Friend WithEvents Potasio As ColumnHeader
    Friend WithEvents Fosforo As ColumnHeader
End Class
