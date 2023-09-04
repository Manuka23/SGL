<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmIngresoTratamientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoTratamientos))
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.gbCuartos = New System.Windows.Forms.GroupBox()
        Me.chkPI = New System.Windows.Forms.CheckBox()
        Me.chkPD = New System.Windows.Forms.CheckBox()
        Me.chkAI = New System.Windows.Forms.CheckBox()
        Me.chkAD = New System.Windows.Forms.CheckBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblTratCodigo = New System.Windows.Forms.Label()
        Me.lblUltimaOtrosTrat = New System.Windows.Forms.Label()
        Me.lblNroOtrosTrat = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblUltimaMastitis = New System.Windows.Forms.Label()
        Me.lblNroMastitis = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblEstReproductivo = New System.Windows.Forms.Label()
        Me.lblEstProductivo = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDIIO = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.tabPASTO = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lvDetalle = New System.Windows.Forms.ListView()
        Me.NroLinCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CentroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiioCold = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Catcol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.producCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ReproducCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Estadocol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodCentroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodCategoriaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PatCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PatologiaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodMedCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MedicamentoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiasTratCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FecIniCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FecTercol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AICol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ADCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PICol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PDCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LibLecheCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LibCarneCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ResgLecheCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ResgCarneCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ObsCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Dosis = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UMedida = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Cojas = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MedGP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.msje = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.hrs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Veces = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.lblPreventivo = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblDosisSugerida = New System.Windows.Forms.Label()
        Me.chbcojera = New System.Windows.Forms.CheckBox()
        Me.lblDiasResgCarne = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblFechaLiberacionCarne = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDiasTrat = New System.Windows.Forms.TextBox()
        Me.lblDiasResg = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFechaTermino = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboPatologias = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Medicamentos = New System.Windows.Forms.ComboBox()
        Me.lblFechaLiberacion = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.grpHorario = New System.Windows.Forms.GroupBox()
        Me.rbtnPM = New System.Windows.Forms.RadioButton()
        Me.rbtnAM = New System.Windows.Forms.RadioButton()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnBastonLee = New System.Windows.Forms.Button()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblErrores = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotDiios = New System.Windows.Forms.Label()
        Me.lblTotErrores = New System.Windows.Forms.Label()
        Me.lblConErrores = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.cboUniMedida = New System.Windows.Forms.ComboBox()
        Me.cboCantidades = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboCantidadVeces = New System.Windows.Forms.ComboBox()
        Me.cboHra = New System.Windows.Forms.ComboBox()
        Me.FechaCentroOri = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.gbCuartos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tabPASTO.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.grpHorario.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.txtObservs)
        Me.GroupBox6.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(606, 295)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(362, 67)
        Me.GroupBox6.TabIndex = 146
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "OBSERVACIÓN"
        '
        'txtObservs
        '
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(9, 25)
        Me.txtObservs.MaxLength = 500
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(347, 42)
        Me.txtObservs.TabIndex = 10
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtpFecha)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(9, 8)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(176, 57)
        Me.GroupBox5.TabIndex = 145
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fecha de Ingreso"
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(26, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(111, 30)
        Me.dtpFecha.TabIndex = 1
        '
        'gbCuartos
        '
        Me.gbCuartos.Controls.Add(Me.chkPI)
        Me.gbCuartos.Controls.Add(Me.chkPD)
        Me.gbCuartos.Controls.Add(Me.chkAI)
        Me.gbCuartos.Controls.Add(Me.chkAD)
        Me.gbCuartos.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCuartos.Location = New System.Drawing.Point(606, 164)
        Me.gbCuartos.Name = "gbCuartos"
        Me.gbCuartos.Size = New System.Drawing.Size(146, 125)
        Me.gbCuartos.TabIndex = 144
        Me.gbCuartos.TabStop = False
        Me.gbCuartos.Text = "CUARTOS/MIEMBRO"
        '
        'chkPI
        '
        Me.chkPI.AutoSize = True
        Me.chkPI.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPI.Location = New System.Drawing.Point(25, 75)
        Me.chkPI.Name = "chkPI"
        Me.chkPI.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPI.Size = New System.Drawing.Size(47, 28)
        Me.chkPI.TabIndex = 9
        Me.chkPI.Text = "PI"
        Me.chkPI.UseVisualStyleBackColor = True
        '
        'chkPD
        '
        Me.chkPD.AutoSize = True
        Me.chkPD.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPD.Location = New System.Drawing.Point(84, 73)
        Me.chkPD.Name = "chkPD"
        Me.chkPD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkPD.Size = New System.Drawing.Size(54, 28)
        Me.chkPD.TabIndex = 8
        Me.chkPD.Text = "PD"
        Me.chkPD.UseVisualStyleBackColor = True
        '
        'chkAI
        '
        Me.chkAI.AutoSize = True
        Me.chkAI.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAI.Location = New System.Drawing.Point(24, 25)
        Me.chkAI.Name = "chkAI"
        Me.chkAI.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkAI.Size = New System.Drawing.Size(49, 28)
        Me.chkAI.TabIndex = 7
        Me.chkAI.Text = "AI"
        Me.chkAI.UseVisualStyleBackColor = True
        '
        'chkAD
        '
        Me.chkAD.AutoSize = True
        Me.chkAD.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAD.Location = New System.Drawing.Point(83, 25)
        Me.chkAD.Name = "chkAD"
        Me.chkAD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkAD.Size = New System.Drawing.Size(56, 28)
        Me.chkAD.TabIndex = 6
        Me.chkAD.Text = "AD"
        Me.chkAD.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkAD.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(917, 669)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 140
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblTratCodigo)
        Me.GroupBox2.Controls.Add(Me.lblUltimaOtrosTrat)
        Me.GroupBox2.Controls.Add(Me.lblNroOtrosTrat)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblEstado)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblUltimaMastitis)
        Me.GroupBox2.Controls.Add(Me.lblNroMastitis)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblEstReproductivo)
        Me.GroupBox2.Controls.Add(Me.lblEstProductivo)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.lblCategoria)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtDIIO)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(324, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(676, 152)
        Me.GroupBox2.TabIndex = 142
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DIIO"
        '
        'lblTratCodigo
        '
        Me.lblTratCodigo.AutoSize = True
        Me.lblTratCodigo.Location = New System.Drawing.Point(261, 31)
        Me.lblTratCodigo.Name = "lblTratCodigo"
        Me.lblTratCodigo.Size = New System.Drawing.Size(74, 17)
        Me.lblTratCodigo.TabIndex = 118
        Me.lblTratCodigo.Text = "Codigo Lote"
        '
        'lblUltimaOtrosTrat
        '
        Me.lblUltimaOtrosTrat.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaOtrosTrat.Location = New System.Drawing.Point(486, 124)
        Me.lblUltimaOtrosTrat.Name = "lblUltimaOtrosTrat"
        Me.lblUltimaOtrosTrat.Size = New System.Drawing.Size(152, 25)
        Me.lblUltimaOtrosTrat.TabIndex = 117
        Me.lblUltimaOtrosTrat.Text = "---"
        '
        'lblNroOtrosTrat
        '
        Me.lblNroOtrosTrat.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroOtrosTrat.Location = New System.Drawing.Point(486, 79)
        Me.lblNroOtrosTrat.Name = "lblNroOtrosTrat"
        Me.lblNroOtrosTrat.Size = New System.Drawing.Size(143, 25)
        Me.lblNroOtrosTrat.TabIndex = 116
        Me.lblNroOtrosTrat.Text = "---"
        Me.lblNroOtrosTrat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(486, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 20)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Ultimo Tratamiento"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(486, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 20)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Nro.  Tratamientos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(323, 130)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(108, 25)
        Me.lblEstado.TabIndex = 113
        Me.lblEstado.Text = "---"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(323, 109)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 20)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "Estado"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUltimaMastitis
        '
        Me.lblUltimaMastitis.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimaMastitis.Location = New System.Drawing.Point(177, 130)
        Me.lblUltimaMastitis.Name = "lblUltimaMastitis"
        Me.lblUltimaMastitis.Size = New System.Drawing.Size(116, 25)
        Me.lblUltimaMastitis.TabIndex = 111
        Me.lblUltimaMastitis.Text = "---"
        '
        'lblNroMastitis
        '
        Me.lblNroMastitis.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroMastitis.Location = New System.Drawing.Point(8, 126)
        Me.lblNroMastitis.Name = "lblNroMastitis"
        Me.lblNroMastitis.Size = New System.Drawing.Size(112, 25)
        Me.lblNroMastitis.TabIndex = 110
        Me.lblNroMastitis.Text = "---"
        Me.lblNroMastitis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(168, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 20)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "Ultima Mastitis"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 109)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 20)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "Nro. Mastitis"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstReproductivo
        '
        Me.lblEstReproductivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstReproductivo.Location = New System.Drawing.Point(323, 85)
        Me.lblEstReproductivo.Name = "lblEstReproductivo"
        Me.lblEstReproductivo.Size = New System.Drawing.Size(172, 25)
        Me.lblEstReproductivo.TabIndex = 94
        Me.lblEstReproductivo.Text = "---"
        '
        'lblEstProductivo
        '
        Me.lblEstProductivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstProductivo.Location = New System.Drawing.Point(177, 82)
        Me.lblEstProductivo.Name = "lblEstProductivo"
        Me.lblEstProductivo.Size = New System.Drawing.Size(154, 25)
        Me.lblEstProductivo.TabIndex = 93
        Me.lblEstProductivo.Text = "---"
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(203, 24)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(45, 32)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblCategoria
        '
        Me.lblCategoria.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(8, 82)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(154, 25)
        Me.lblCategoria.TabIndex = 91
        Me.lblCategoria.Text = "---"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(323, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 22)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Est. Reproductivo"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(168, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 22)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Est. Productivo"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 22)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Categoría"
        '
        'txtDIIO
        '
        Me.txtDIIO.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIIO.Location = New System.Drawing.Point(11, 25)
        Me.txtDIIO.MaxLength = 20
        Me.txtDIIO.Name = "txtDIIO"
        Me.txtDIIO.Size = New System.Drawing.Size(185, 36)
        Me.txtDIIO.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 71)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(309, 48)
        Me.GroupBox1.TabIndex = 141
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.CausesValidation = False
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(11, 16)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(282, 31)
        Me.cboCentros.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(9, 403)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(991, 260)
        Me.GroupBox7.TabIndex = 149
        Me.GroupBox7.TabStop = False
        '
        'tabPASTO
        '
        Me.tabPASTO.Controls.Add(Me.TabPage1)
        Me.tabPASTO.Location = New System.Drawing.Point(9, 388)
        Me.tabPASTO.Name = "tabPASTO"
        Me.tabPASTO.SelectedIndex = 0
        Me.tabPASTO.Size = New System.Drawing.Size(977, 275)
        Me.tabPASTO.TabIndex = 213
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.lvDetalle)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(969, 245)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle"
        '
        'lvDetalle
        '
        Me.lvDetalle.AutoArrange = False
        Me.lvDetalle.BackColor = System.Drawing.SystemColors.Window
        Me.lvDetalle.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NroLinCol, Me.CentroCol, Me.DiioCold, Me.Catcol, Me.producCol, Me.ReproducCol, Me.Estadocol, Me.FechaCol, Me.CodCentroCol, Me.CodCategoriaCol, Me.PatCodCol, Me.PatologiaCol, Me.CodMedCol, Me.MedicamentoCol, Me.DiasTratCol, Me.FecIniCol, Me.FecTercol, Me.AICol, Me.ADCol, Me.PICol, Me.PDCol, Me.LibLecheCol, Me.LibCarneCol, Me.ResgLecheCol, Me.ResgCarneCol, Me.ObsCol, Me.Dosis, Me.UMedida, Me.Cojas, Me.MedGP, Me.msje, Me.hrs, Me.Veces, Me.FechaCentroOri})
        Me.lvDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDetalle.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvDetalle.FullRowSelect = True
        Me.lvDetalle.GridLines = True
        Me.lvDetalle.HideSelection = False
        Me.lvDetalle.Location = New System.Drawing.Point(3, 3)
        Me.lvDetalle.MultiSelect = False
        Me.lvDetalle.Name = "lvDetalle"
        Me.lvDetalle.Size = New System.Drawing.Size(963, 239)
        Me.lvDetalle.TabIndex = 137
        Me.lvDetalle.UseCompatibleStateImageBehavior = False
        Me.lvDetalle.View = System.Windows.Forms.View.Details
        '
        'NroLinCol
        '
        Me.NroLinCol.Text = "Nro"
        Me.NroLinCol.Width = 40
        '
        'CentroCol
        '
        Me.CentroCol.Text = "Centro"
        Me.CentroCol.Width = 143
        '
        'DiioCold
        '
        Me.DiioCold.Text = "Diio"
        Me.DiioCold.Width = 70
        '
        'Catcol
        '
        Me.Catcol.Text = "Categoria"
        Me.Catcol.Width = 73
        '
        'producCol
        '
        Me.producCol.Text = "Est. Produc."
        Me.producCol.Width = 79
        '
        'ReproducCol
        '
        Me.ReproducCol.Text = "Est. Reproduc."
        Me.ReproducCol.Width = 97
        '
        'Estadocol
        '
        Me.Estadocol.Text = "Estado"
        Me.Estadocol.Width = 64
        '
        'FechaCol
        '
        Me.FechaCol.Text = "Fecha"
        Me.FechaCol.Width = 75
        '
        'CodCentroCol
        '
        Me.CodCentroCol.Text = "CodCentro"
        Me.CodCentroCol.Width = 0
        '
        'CodCategoriaCol
        '
        Me.CodCategoriaCol.Text = "CodCategoria"
        Me.CodCategoriaCol.Width = 0
        '
        'PatCodCol
        '
        Me.PatCodCol.Text = "CodPatologia"
        Me.PatCodCol.Width = 0
        '
        'PatologiaCol
        '
        Me.PatologiaCol.Text = "Patologia"
        Me.PatologiaCol.Width = 117
        '
        'CodMedCol
        '
        Me.CodMedCol.Text = "CodMed"
        Me.CodMedCol.Width = 0
        '
        'MedicamentoCol
        '
        Me.MedicamentoCol.Text = "Medicamento"
        Me.MedicamentoCol.Width = 133
        '
        'DiasTratCol
        '
        Me.DiasTratCol.Text = "Dias trat."
        Me.DiasTratCol.Width = 67
        '
        'FecIniCol
        '
        Me.FecIniCol.Text = "Fec. Inicio"
        Me.FecIniCol.Width = 75
        '
        'FecTercol
        '
        Me.FecTercol.Text = "Fec. termino"
        Me.FecTercol.Width = 75
        '
        'AICol
        '
        Me.AICol.Text = "AI"
        Me.AICol.Width = 30
        '
        'ADCol
        '
        Me.ADCol.Text = "AD"
        Me.ADCol.Width = 30
        '
        'PICol
        '
        Me.PICol.Text = "PI"
        Me.PICol.Width = 30
        '
        'PDCol
        '
        Me.PDCol.Text = "PD"
        Me.PDCol.Width = 30
        '
        'LibLecheCol
        '
        Me.LibLecheCol.Text = "Liber. Leche"
        Me.LibLecheCol.Width = 75
        '
        'LibCarneCol
        '
        Me.LibCarneCol.Text = "Liber. Carne"
        Me.LibCarneCol.Width = 78
        '
        'ResgLecheCol
        '
        Me.ResgLecheCol.Text = "Resg. Leche"
        Me.ResgLecheCol.Width = 0
        '
        'ResgCarneCol
        '
        Me.ResgCarneCol.Text = "Resg. Carne"
        Me.ResgCarneCol.Width = 0
        '
        'ObsCol
        '
        Me.ObsCol.Text = "Obs"
        Me.ObsCol.Width = 302
        '
        'Dosis
        '
        Me.Dosis.Text = "Dosis"
        Me.Dosis.Width = 30
        '
        'UMedida
        '
        Me.UMedida.Text = "Uni. Medida"
        '
        'Cojas
        '
        Me.Cojas.Text = "Cojera"
        '
        'MedGP
        '
        Me.MedGP.Text = "Medicamento Cod. GP"
        Me.MedGP.Width = 0
        '
        'msje
        '
        Me.msje.Text = "Med. Mensaje"
        Me.msje.Width = 140
        '
        'hrs
        '
        Me.hrs.Text = "Horas"
        '
        'Veces
        '
        Me.Veces.Text = "Veces por Horas"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.lblPreventivo)
        Me.GroupBox8.Controls.Add(Me.Label22)
        Me.GroupBox8.Controls.Add(Me.lblDosisSugerida)
        Me.GroupBox8.Controls.Add(Me.chbcojera)
        Me.GroupBox8.Controls.Add(Me.lblDiasResgCarne)
        Me.GroupBox8.Controls.Add(Me.Label14)
        Me.GroupBox8.Controls.Add(Me.lblFechaLiberacionCarne)
        Me.GroupBox8.Controls.Add(Me.Label17)
        Me.GroupBox8.Controls.Add(Me.txtDiasTrat)
        Me.GroupBox8.Controls.Add(Me.lblDiasResg)
        Me.GroupBox8.Controls.Add(Me.Label19)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.lblFechaTermino)
        Me.GroupBox8.Controls.Add(Me.Label11)
        Me.GroupBox8.Controls.Add(Me.dtpFechaInicio)
        Me.GroupBox8.Controls.Add(Me.Label12)
        Me.GroupBox8.Controls.Add(Me.cboPatologias)
        Me.GroupBox8.Controls.Add(Me.Label16)
        Me.GroupBox8.Controls.Add(Me.Medicamentos)
        Me.GroupBox8.Controls.Add(Me.lblFechaLiberacion)
        Me.GroupBox8.Controls.Add(Me.Label18)
        Me.GroupBox8.Controls.Add(Me.Label20)
        Me.GroupBox8.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(9, 164)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(591, 213)
        Me.GroupBox8.TabIndex = 148
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "TRATAMIENTO"
        '
        'lblPreventivo
        '
        Me.lblPreventivo.AutoSize = True
        Me.lblPreventivo.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreventivo.ForeColor = System.Drawing.Color.Red
        Me.lblPreventivo.Location = New System.Drawing.Point(8, 134)
        Me.lblPreventivo.Name = "lblPreventivo"
        Me.lblPreventivo.Size = New System.Drawing.Size(208, 21)
        Me.lblPreventivo.TabIndex = 220
        Me.lblPreventivo.Text = "TRATAMIENTO PREVENTIVO"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(8, 160)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(111, 21)
        Me.Label22.TabIndex = 219
        Me.Label22.Text = "Trat. Sugerido:"
        '
        'lblDosisSugerida
        '
        Me.lblDosisSugerida.AutoSize = True
        Me.lblDosisSugerida.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDosisSugerida.Location = New System.Drawing.Point(98, 162)
        Me.lblDosisSugerida.Name = "lblDosisSugerida"
        Me.lblDosisSugerida.Size = New System.Drawing.Size(98, 18)
        Me.lblDosisSugerida.TabIndex = 218
        Me.lblDosisSugerida.Text = "Dosis Sugerida"
        '
        'chbcojera
        '
        Me.chbcojera.AutoSize = True
        Me.chbcojera.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbcojera.Location = New System.Drawing.Point(6, 184)
        Me.chbcojera.Name = "chbcojera"
        Me.chbcojera.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chbcojera.Size = New System.Drawing.Size(159, 28)
        Me.chbcojera.TabIndex = 217
        Me.chbcojera.Text = "Produce Cojera"
        Me.chbcojera.UseVisualStyleBackColor = True
        Me.chbcojera.Visible = False
        '
        'lblDiasResgCarne
        '
        Me.lblDiasResgCarne.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiasResgCarne.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasResgCarne.Location = New System.Drawing.Point(375, 156)
        Me.lblDiasResgCarne.Name = "lblDiasResgCarne"
        Me.lblDiasResgCarne.Size = New System.Drawing.Size(66, 26)
        Me.lblDiasResgCarne.TabIndex = 146
        Me.lblDiasResgCarne.Text = "---"
        Me.lblDiasResgCarne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(372, 131)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 26)
        Me.Label14.TabIndex = 145
        Me.Label14.Text = "Resg. Carne"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFechaLiberacionCarne
        '
        Me.lblFechaLiberacionCarne.BackColor = System.Drawing.SystemColors.Control
        Me.lblFechaLiberacionCarne.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaLiberacionCarne.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaLiberacionCarne.Location = New System.Drawing.Point(463, 156)
        Me.lblFechaLiberacionCarne.Name = "lblFechaLiberacionCarne"
        Me.lblFechaLiberacionCarne.Size = New System.Drawing.Size(111, 26)
        Me.lblFechaLiberacionCarne.TabIndex = 144
        Me.lblFechaLiberacionCarne.Text = "---"
        Me.lblFechaLiberacionCarne.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(462, 131)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(114, 26)
        Me.Label17.TabIndex = 143
        Me.Label17.Text = "Fecha Liberación"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiasTrat
        '
        Me.txtDiasTrat.Enabled = False
        Me.txtDiasTrat.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasTrat.Location = New System.Drawing.Point(146, 99)
        Me.txtDiasTrat.MaxLength = 2
        Me.txtDiasTrat.Name = "txtDiasTrat"
        Me.txtDiasTrat.Size = New System.Drawing.Size(66, 30)
        Me.txtDiasTrat.TabIndex = 141
        Me.txtDiasTrat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDiasResg
        '
        Me.lblDiasResg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiasResg.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiasResg.Location = New System.Drawing.Point(375, 99)
        Me.lblDiasResg.Name = "lblDiasResg"
        Me.lblDiasResg.Size = New System.Drawing.Size(66, 26)
        Me.lblDiasResg.TabIndex = 142
        Me.lblDiasResg.Text = "---"
        Me.lblDiasResg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(372, 74)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 26)
        Me.Label19.TabIndex = 141
        Me.Label19.Text = "Resg. Leche"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(143, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 26)
        Me.Label8.TabIndex = 139
        Me.Label8.Text = "Dias Trat."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFechaTermino
        '
        Me.lblFechaTermino.BackColor = System.Drawing.SystemColors.Control
        Me.lblFechaTermino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaTermino.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaTermino.Location = New System.Drawing.Point(239, 99)
        Me.lblFechaTermino.Name = "lblFechaTermino"
        Me.lblFechaTermino.Size = New System.Drawing.Size(111, 26)
        Me.lblFechaTermino.TabIndex = 138
        Me.lblFechaTermino.Text = "---"
        Me.lblFechaTermino.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblFechaTermino.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(236, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 26)
        Me.Label11.TabIndex = 136
        Me.Label11.Text = "Fecha Termino"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(11, 99)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(111, 30)
        Me.dtpFechaInicio.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(114, 26)
        Me.Label12.TabIndex = 134
        Me.Label12.Text = "Patología"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPatologias
        '
        Me.cboPatologias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPatologias.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPatologias.FormattingEnabled = True
        Me.cboPatologias.Location = New System.Drawing.Point(11, 43)
        Me.cboPatologias.Name = "cboPatologias"
        Me.cboPatologias.Size = New System.Drawing.Size(219, 31)
        Me.cboPatologias.TabIndex = 133
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(245, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(114, 26)
        Me.Label16.TabIndex = 132
        Me.Label16.Text = "Medicamento"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Medicamentos
        '
        Me.Medicamentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Medicamentos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Medicamentos.FormattingEnabled = True
        Me.Medicamentos.Location = New System.Drawing.Point(248, 43)
        Me.Medicamentos.Name = "Medicamentos"
        Me.Medicamentos.Size = New System.Drawing.Size(337, 31)
        Me.Medicamentos.TabIndex = 4
        '
        'lblFechaLiberacion
        '
        Me.lblFechaLiberacion.BackColor = System.Drawing.SystemColors.Control
        Me.lblFechaLiberacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaLiberacion.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaLiberacion.Location = New System.Drawing.Point(463, 99)
        Me.lblFechaLiberacion.Name = "lblFechaLiberacion"
        Me.lblFechaLiberacion.Size = New System.Drawing.Size(111, 26)
        Me.lblFechaLiberacion.TabIndex = 130
        Me.lblFechaLiberacion.Text = "---"
        Me.lblFechaLiberacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(462, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(114, 26)
        Me.Label18.TabIndex = 129
        Me.Label18.Text = "Fecha Liberación"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 74)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(114, 26)
        Me.Label20.TabIndex = 127
        Me.Label20.Text = "Fecha Inicio"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnActualizar
        '
        Me.btnActualizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
        Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizar.Location = New System.Drawing.Point(131, 669)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(203, 30)
        Me.btnActualizar.TabIndex = 138
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'grpHorario
        '
        Me.grpHorario.Controls.Add(Me.rbtnPM)
        Me.grpHorario.Controls.Add(Me.rbtnAM)
        Me.grpHorario.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpHorario.Location = New System.Drawing.Point(193, 11)
        Me.grpHorario.Name = "grpHorario"
        Me.grpHorario.Size = New System.Drawing.Size(125, 54)
        Me.grpHorario.TabIndex = 215
        Me.grpHorario.TabStop = False
        Me.grpHorario.Text = "Horario"
        '
        'rbtnPM
        '
        Me.rbtnPM.AutoSize = True
        Me.rbtnPM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtnPM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnPM.ForeColor = System.Drawing.Color.Black
        Me.rbtnPM.Location = New System.Drawing.Point(57, 21)
        Me.rbtnPM.Name = "rbtnPM"
        Me.rbtnPM.Size = New System.Drawing.Size(55, 25)
        Me.rbtnPM.TabIndex = 4
        Me.rbtnPM.TabStop = True
        Me.rbtnPM.Text = "PM"
        Me.rbtnPM.UseVisualStyleBackColor = True
        '
        'rbtnAM
        '
        Me.rbtnAM.AutoSize = True
        Me.rbtnAM.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbtnAM.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAM.ForeColor = System.Drawing.Color.Black
        Me.rbtnAM.Location = New System.Drawing.Point(10, 21)
        Me.rbtnAM.Name = "rbtnAM"
        Me.rbtnAM.Size = New System.Drawing.Size(56, 25)
        Me.rbtnAM.TabIndex = 3
        Me.rbtnAM.TabStop = True
        Me.rbtnAM.Text = "AM"
        Me.rbtnAM.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(9, 669)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(116, 30)
        Me.btnAgregar.TabIndex = 214
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(131, 669)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(97, 30)
        Me.btnGrabar.TabIndex = 213
        Me.btnGrabar.Text = "Finalizar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(606, 295)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(394, 85)
        Me.GroupBox3.TabIndex = 146
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "OBSERVACIÓN"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(9, 25)
        Me.TextBox1.MaxLength = 500
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(379, 54)
        Me.TextBox1.TabIndex = 10
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(340, 669)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(107, 30)
        Me.btnEliminar.TabIndex = 217
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnBastonLee
        '
        Me.btnBastonLee.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLee.Image = CType(resources.GetObject("btnBastonLee.Image"), System.Drawing.Image)
        Me.btnBastonLee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBastonLee.Location = New System.Drawing.Point(234, 669)
        Me.btnBastonLee.Name = "btnBastonLee"
        Me.btnBastonLee.Size = New System.Drawing.Size(100, 29)
        Me.btnBastonLee.TabIndex = 218
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
        Me.pnlEstReprod.Controls.Add(Me.Label7)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(588, 672)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(319, 25)
        Me.pnlEstReprod.TabIndex = 219
        '
        'lblErrores
        '
        Me.lblErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrores.Location = New System.Drawing.Point(266, 2)
        Me.lblErrores.Name = "lblErrores"
        Me.lblErrores.Size = New System.Drawing.Size(48, 21)
        Me.lblErrores.TabIndex = 49
        Me.lblErrores.Text = "0"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(194, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 21)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "Errores"
        '
        'lblTotDiios
        '
        Me.lblTotDiios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDiios.Location = New System.Drawing.Point(149, 3)
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
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(185, 21)
        Me.Label7.TabIndex = 44
        Me.Label7.Text = "Numero Registros"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(453, 669)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 30)
        Me.Button2.TabIndex = 220
        Me.Button2.Text = "Eliminar Errores"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.cboUniMedida)
        Me.GroupBox9.Controls.Add(Me.cboCantidades)
        Me.GroupBox9.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox9.Location = New System.Drawing.Point(758, 164)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(242, 43)
        Me.GroupBox9.TabIndex = 221
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Dosis"
        '
        'cboUniMedida
        '
        Me.cboUniMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUniMedida.FormattingEnabled = True
        Me.cboUniMedida.Location = New System.Drawing.Point(127, 17)
        Me.cboUniMedida.Name = "cboUniMedida"
        Me.cboUniMedida.Size = New System.Drawing.Size(94, 25)
        Me.cboUniMedida.TabIndex = 1
        '
        'cboCantidades
        '
        Me.cboCantidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCantidades.FormattingEnabled = True
        Me.cboCantidades.Location = New System.Drawing.Point(16, 17)
        Me.cboCantidades.Name = "cboCantidades"
        Me.cboCantidades.Size = New System.Drawing.Size(86, 25)
        Me.cboCantidades.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.cboCantidadVeces)
        Me.GroupBox4.Controls.Add(Me.cboHra)
        Me.GroupBox4.Location = New System.Drawing.Point(758, 212)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(241, 77)
        Me.GroupBox4.TabIndex = 222
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Duración"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(124, 25)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 17)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Veces"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(13, 25)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 17)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Horas"
        '
        'cboCantidadVeces
        '
        Me.cboCantidadVeces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCantidadVeces.FormattingEnabled = True
        Me.cboCantidadVeces.Location = New System.Drawing.Point(127, 46)
        Me.cboCantidadVeces.Name = "cboCantidadVeces"
        Me.cboCantidadVeces.Size = New System.Drawing.Size(94, 25)
        Me.cboCantidadVeces.TabIndex = 2
        '
        'cboHra
        '
        Me.cboHra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHra.FormattingEnabled = True
        Me.cboHra.Location = New System.Drawing.Point(16, 46)
        Me.cboHra.Name = "cboHra"
        Me.cboHra.Size = New System.Drawing.Size(86, 25)
        Me.cboHra.TabIndex = 2
        '
        'FechaCentroOri
        '
        Me.FechaCentroOri.Text = "Fecha Centro Origen"
        Me.FechaCentroOri.Width = 100
        '
        'frmIngresoTratamientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 708)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.tabPASTO)
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.grpHorario)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.gbCuartos)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBastonLee)
        Me.Controls.Add(Me.btnActualizar)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIngresoTratamientos"
        Me.Text = "Ingreso Tratamiento"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.gbCuartos.ResumeLayout(False)
        Me.gbCuartos.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.tabPASTO.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.grpHorario.ResumeLayout(False)
        Me.grpHorario.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.pnlEstReprod.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtObservs As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents gbCuartos As GroupBox
    Friend WithEvents chkPI As CheckBox
    Friend WithEvents chkPD As CheckBox
    Friend WithEvents chkAI As CheckBox
    Friend WithEvents chkAD As CheckBox
    Friend WithEvents btnSalir As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblEstado As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblUltimaMastitis As Label
    Friend WithEvents lblNroMastitis As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblEstReproductivo As Label
    Friend WithEvents lblEstProductivo As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lblCategoria As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDIIO As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboCentros As ComboBox
    Friend WithEvents lblUltimaOtrosTrat As Label
    Friend WithEvents lblNroOtrosTrat As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents txtDiasTrat As TextBox
    Friend WithEvents lblDiasResg As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblFechaTermino As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpFechaInicio As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents cboPatologias As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Medicamentos As ComboBox
    Friend WithEvents lblFechaLiberacion As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnGrabar As Button
    Friend WithEvents lblDiasResgCarne As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblFechaLiberacionCarne As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents tabPASTO As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents lvDetalle As ListView
    Friend WithEvents NroLinCol As ColumnHeader
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnBastonLee As Button
    Friend WithEvents CentroCol As ColumnHeader
    Friend WithEvents DiioCold As ColumnHeader
    Friend WithEvents Catcol As ColumnHeader
    Friend WithEvents producCol As ColumnHeader
    Friend WithEvents ReproducCol As ColumnHeader
    Friend WithEvents Estadocol As ColumnHeader
    Friend WithEvents FechaCol As ColumnHeader
    Friend WithEvents CodCentroCol As ColumnHeader
    Friend WithEvents CodCategoriaCol As ColumnHeader
    Friend WithEvents PatCodCol As ColumnHeader
    Friend WithEvents PatologiaCol As ColumnHeader
    Friend WithEvents CodMedCol As ColumnHeader
    Friend WithEvents MedicamentoCol As ColumnHeader
    Friend WithEvents DiasTratCol As ColumnHeader
    Friend WithEvents FecIniCol As ColumnHeader
    Friend WithEvents FecTercol As ColumnHeader
    Friend WithEvents ObsCol As ColumnHeader
    Friend WithEvents AICol As ColumnHeader
    Friend WithEvents ADCol As ColumnHeader
    Friend WithEvents PICol As ColumnHeader
    Friend WithEvents PDCol As ColumnHeader
    Friend WithEvents LibLecheCol As ColumnHeader
    Friend WithEvents LibCarneCol As ColumnHeader
    Friend WithEvents ResgLecheCol As ColumnHeader
    Friend WithEvents ResgCarneCol As ColumnHeader
    Friend WithEvents pnlEstReprod As Panel
    Friend WithEvents lblErrores As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTotDiios As Label
    Friend WithEvents lblTotErrores As Label
    Friend WithEvents lblConErrores As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents grpHorario As GroupBox
    Friend WithEvents rbtnPM As RadioButton
    Friend WithEvents rbtnAM As RadioButton
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents Dosis As ColumnHeader
    Friend WithEvents chbcojera As CheckBox
    Friend WithEvents Cojas As ColumnHeader
    Friend WithEvents MedGP As ColumnHeader
    Friend WithEvents msje As ColumnHeader
    Friend WithEvents btnActualizar As Button
    Friend WithEvents lblTratCodigo As Label
    Friend WithEvents cboUniMedida As ComboBox
    Friend WithEvents cboCantidades As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cboCantidadVeces As ComboBox
    Friend WithEvents cboHra As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents UMedida As ColumnHeader
    Friend WithEvents lblDosisSugerida As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents hrs As ColumnHeader
    Friend WithEvents Veces As ColumnHeader
    Friend WithEvents lblPreventivo As Label
    Friend WithEvents FechaCentroOri As ColumnHeader
End Class
