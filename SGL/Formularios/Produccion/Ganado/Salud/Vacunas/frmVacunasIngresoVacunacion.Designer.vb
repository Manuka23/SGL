<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmVacunasIngresoVacunacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVacunasIngresoVacunacion))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Fecha = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lvArticulos = New System.Windows.Forms.ListView()
        Me.LineCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SeasonCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DateCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvGanado = New System.Windows.Forms.ListView()
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblSala = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblEstReproductivo = New System.Windows.Forms.Label()
        Me.lblEstProductivo = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblFecNacimiento = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblRaza = New System.Windows.Forms.Label()
        Me.lblSexo = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDIIO = New System.Windows.Forms.TextBox()
        Me.Consultar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.btnBastonLee = New System.Windows.Forms.Button()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblErrores = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotDiios = New System.Windows.Forms.Label()
        Me.lblTotErrores = New System.Windows.Forms.Label()
        Me.lblConErrores = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Fecha)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(170, 60)
        Me.GroupBox5.TabIndex = 193
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fecha"
        '
        'Fecha
        '
        Me.Fecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha.Location = New System.Drawing.Point(29, 20)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(111, 26)
        Me.Fecha.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lvArticulos)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(549, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(406, 259)
        Me.GroupBox4.TabIndex = 202
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Vacunas disponibles"
        '
        'lvArticulos
        '
        Me.lvArticulos.AutoArrange = False
        Me.lvArticulos.BackColor = System.Drawing.SystemColors.Window
        Me.lvArticulos.CheckBoxes = True
        Me.lvArticulos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LineCol, Me.SeasonCol, Me.DateCol, Me.ColumnHeader8, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader15})
        Me.lvArticulos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvArticulos.FullRowSelect = True
        Me.lvArticulos.GridLines = True
        Me.lvArticulos.HideSelection = False
        Me.lvArticulos.Location = New System.Drawing.Point(3, 18)
        Me.lvArticulos.Name = "lvArticulos"
        Me.lvArticulos.Size = New System.Drawing.Size(400, 238)
        Me.lvArticulos.TabIndex = 193
        Me.lvArticulos.UseCompatibleStateImageBehavior = False
        Me.lvArticulos.View = System.Windows.Forms.View.Details
        '
        'LineCol
        '
        Me.LineCol.Text = ""
        Me.LineCol.Width = 30
        '
        'SeasonCol
        '
        Me.SeasonCol.Text = "Cod. Vacuna"
        Me.SeasonCol.Width = 103
        '
        'DateCol
        '
        Me.DateCol.Text = "Nom. Vacuna"
        Me.DateCol.Width = 204
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Stock"
        Me.ColumnHeader8.Width = 59
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Bodega"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "ItemGasto"
        Me.ColumnHeader11.Width = 0
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Cuenta"
        Me.ColumnHeader15.Width = 0
        '
        'lvGanado
        '
        Me.lvGanado.AutoArrange = False
        Me.lvGanado.BackColor = System.Drawing.SystemColors.Window
        Me.lvGanado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader9, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader2, Me.ColumnHeader7, Me.ColumnHeader6, Me.ColumnHeader5, Me.ColumnHeader1})
        Me.lvGanado.FullRowSelect = True
        Me.lvGanado.GridLines = True
        Me.lvGanado.HideSelection = False
        Me.lvGanado.Location = New System.Drawing.Point(6, 267)
        Me.lvGanado.Name = "lvGanado"
        Me.lvGanado.Size = New System.Drawing.Size(946, 277)
        Me.lvGanado.TabIndex = 201
        Me.lvGanado.UseCompatibleStateImageBehavior = False
        Me.lvGanado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Nro"
        Me.ColumnHeader12.Width = 42
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Centro"
        Me.ColumnHeader3.Width = 140
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "DIIO"
        Me.ColumnHeader4.Width = 105
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Categoria"
        Me.ColumnHeader9.Width = 77
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Est. Productivo"
        Me.ColumnHeader13.Width = 109
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Est. reproductivo"
        Me.ColumnHeader14.Width = 117
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Estado"
        Me.ColumnHeader2.Width = 105
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Observacion"
        Me.ColumnHeader7.Width = 249
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Fecha"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "codCentro"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "codCat"
        Me.ColumnHeader1.Width = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(197, 550)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(93, 32)
        Me.btnEliminar.TabIndex = 200
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(6, 550)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(87, 32)
        Me.btnFinalizar.TabIndex = 198
        Me.btnFinalizar.Text = "Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(868, 550)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 32)
        Me.Button1.TabIndex = 199
        Me.Button1.Text = "Cerrar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(416, 149)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(115, 35)
        Me.btnGrabar.TabIndex = 197
        Me.btnGrabar.Text = "Agregar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblEstado)
        Me.GroupBox1.Controls.Add(Me.lblCategoria)
        Me.GroupBox1.Controls.Add(Me.btnGrabar)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.lblSala)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblEstReproductivo)
        Me.GroupBox1.Controls.Add(Me.lblEstProductivo)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.lblFecNacimiento)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblRaza)
        Me.GroupBox1.Controls.Add(Me.lblSexo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDIIO)
        Me.GroupBox1.Controls.Add(Me.Consultar)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(537, 193)
        Me.GroupBox1.TabIndex = 194
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingreso por Diio"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(90, 100)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(134, 24)
        Me.lblEstado.TabIndex = 60
        '
        'lblCategoria
        '
        Me.lblCategoria.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(90, 54)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(134, 24)
        Me.lblCategoria.TabIndex = 59
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 100)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 24)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Estado"
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 54)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 24)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "Categoria"
        '
        'lblSala
        '
        Me.lblSala.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSala.Location = New System.Drawing.Point(90, 76)
        Me.lblSala.Name = "lblSala"
        Me.lblSala.Size = New System.Drawing.Size(134, 24)
        Me.lblSala.TabIndex = 56
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 76)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 24)
        Me.Label13.TabIndex = 54
        Me.Label13.Text = "Centro"
        '
        'lblEstReproductivo
        '
        Me.lblEstReproductivo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstReproductivo.Location = New System.Drawing.Point(327, 122)
        Me.lblEstReproductivo.Name = "lblEstReproductivo"
        Me.lblEstReproductivo.Size = New System.Drawing.Size(115, 24)
        Me.lblEstReproductivo.TabIndex = 52
        '
        'lblEstProductivo
        '
        Me.lblEstProductivo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstProductivo.Location = New System.Drawing.Point(106, 124)
        Me.lblEstProductivo.Name = "lblEstProductivo"
        Me.lblEstProductivo.Size = New System.Drawing.Size(115, 24)
        Me.lblEstProductivo.TabIndex = 51
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(227, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 24)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Est. Reproductivo"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 123)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 24)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Est. Productivo"
        '
        'lblFecNacimiento
        '
        Me.lblFecNacimiento.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblFecNacimiento.Location = New System.Drawing.Point(322, 75)
        Me.lblFecNacimiento.Name = "lblFecNacimiento"
        Me.lblFecNacimiento.Size = New System.Drawing.Size(138, 24)
        Me.lblFecNacimiento.TabIndex = 48
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(227, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 24)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Fec. Nacimiento"
        '
        'lblRaza
        '
        Me.lblRaza.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblRaza.Location = New System.Drawing.Point(322, 53)
        Me.lblRaza.Name = "lblRaza"
        Me.lblRaza.Size = New System.Drawing.Size(138, 24)
        Me.lblRaza.TabIndex = 44
        '
        'lblSexo
        '
        Me.lblSexo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.lblSexo.Location = New System.Drawing.Point(322, 99)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.Size(138, 24)
        Me.lblSexo.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(227, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 24)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Raza"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(227, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Sexo"
        '
        'txtDIIO
        '
        Me.txtDIIO.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIIO.Location = New System.Drawing.Point(6, 22)
        Me.txtDIIO.MaxLength = 20
        Me.txtDIIO.Name = "txtDIIO"
        Me.txtDIIO.Size = New System.Drawing.Size(112, 24)
        Me.txtDIIO.TabIndex = 40
        '
        'Consultar
        '
        Me.Consultar.Location = New System.Drawing.Point(136, 19)
        Me.Consultar.Name = "Consultar"
        Me.Consultar.Size = New System.Drawing.Size(85, 29)
        Me.Consultar.TabIndex = 0
        Me.Consultar.Text = "Consultar"
        Me.Consultar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboCentros)
        Me.GroupBox2.Location = New System.Drawing.Point(351, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 60)
        Me.GroupBox2.TabIndex = 203
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(6, 20)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(180, 22)
        Me.cboCentros.TabIndex = 0
        '
        'OpenFDlg
        '
        Me.OpenFDlg.FileName = "OpenFileDialog1"
        '
        'btnBastonLee
        '
        Me.btnBastonLee.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLee.Image = CType(resources.GetObject("btnBastonLee.Image"), System.Drawing.Image)
        Me.btnBastonLee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBastonLee.Location = New System.Drawing.Point(99, 550)
        Me.btnBastonLee.Name = "btnBastonLee"
        Me.btnBastonLee.Size = New System.Drawing.Size(92, 32)
        Me.btnBastonLee.TabIndex = 204
        Me.btnBastonLee.Text = "   Lee Bastón"
        Me.btnBastonLee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBastonLee.UseVisualStyleBackColor = True
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblErrores)
        Me.pnlEstReprod.Controls.Add(Me.Label6)
        Me.pnlEstReprod.Controls.Add(Me.lblTotDiios)
        Me.pnlEstReprod.Controls.Add(Me.lblTotErrores)
        Me.pnlEstReprod.Controls.Add(Me.lblConErrores)
        Me.pnlEstReprod.Controls.Add(Me.Label3)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(446, 552)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(319, 25)
        Me.pnlEstReprod.TabIndex = 216
        '
        'lblErrores
        '
        Me.lblErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrores.Location = New System.Drawing.Point(258, 2)
        Me.lblErrores.Name = "lblErrores"
        Me.lblErrores.Size = New System.Drawing.Size(48, 21)
        Me.lblErrores.TabIndex = 49
        Me.lblErrores.Text = "0"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(180, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 21)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Errores"
        '
        'lblTotDiios
        '
        Me.lblTotDiios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDiios.Location = New System.Drawing.Point(126, 3)
        Me.lblTotDiios.Name = "lblTotDiios"
        Me.lblTotDiios.Size = New System.Drawing.Size(48, 21)
        Me.lblTotDiios.TabIndex = 1
        Me.lblTotDiios.Text = "0"
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
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(185, 21)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Numero Registros"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(296, 549)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 32)
        Me.Button2.TabIndex = 217
        Me.Button2.Text = "Eliminar Errores"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmVacunasIngresoVacunacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 589)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnBastonLee)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.lvGanado)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVacunasIngresoVacunacion"
        Me.ShowInTaskbar = False
        Me.Text = "Registro de Vacunación "
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Fecha As DateTimePicker
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lvGanado As ListView
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnFinalizar As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnGrabar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents lblCategoria As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblSala As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblEstProductivo As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblFecNacimiento As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblRaza As Label
    Friend WithEvents lblSexo As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtDIIO As TextBox
    Friend WithEvents Consultar As Button
    Friend WithEvents lblEstReproductivo As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboCentros As ComboBox
    Friend WithEvents lvArticulos As ListView
    Friend WithEvents LineCol As ColumnHeader
    Friend WithEvents SeasonCol As ColumnHeader
    Friend WithEvents DateCol As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents OpenFDlg As OpenFileDialog
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents btnBastonLee As Button
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents pnlEstReprod As Panel
    Friend WithEvents lblErrores As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTotDiios As Label
    Friend WithEvents lblTotErrores As Label
    Friend WithEvents lblConErrores As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
End Class
