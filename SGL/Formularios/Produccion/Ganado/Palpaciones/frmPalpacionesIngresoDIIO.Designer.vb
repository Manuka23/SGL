<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPalpacionesIngresoDIIO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPalpacionesIngresoDIIO))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.cboVeterinarios = New System.Windows.Forms.ComboBox()
        Me.txtDIIO = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboFechasCub = New System.Windows.Forms.ComboBox()
        Me.lblFecProbParto = New System.Windows.Forms.Label()
        Me.lblNroCubiertas = New System.Windows.Forms.Label()
        Me.lblFecUltParto = New System.Windows.Forms.Label()
        Me.lblEstReproductivo = New System.Windows.Forms.Label()
        Me.lblEstProductivo = New System.Windows.Forms.Label()
        Me.lblCentro = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboToros = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cboTipoDesechos = New System.Windows.Forms.ComboBox()
        Me.cboEstProductivos = New System.Windows.Forms.ComboBox()
        Me.cboCondiciones = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtDiasGest = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lvGanado = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnFinalizar = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblFecProbPartoANterior = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(252, 57)
        Me.GroupBox1.TabIndex = 72
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Centro"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(12, 20)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(231, 26)
        Me.cboCentros.TabIndex = 0
        '
        'cboVeterinarios
        '
        Me.cboVeterinarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVeterinarios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboVeterinarios.FormattingEnabled = True
        Me.cboVeterinarios.Location = New System.Drawing.Point(11, 20)
        Me.cboVeterinarios.Name = "cboVeterinarios"
        Me.cboVeterinarios.Size = New System.Drawing.Size(240, 26)
        Me.cboVeterinarios.TabIndex = 1
        '
        'txtDIIO
        '
        Me.txtDIIO.Enabled = False
        Me.txtDIIO.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIIO.Location = New System.Drawing.Point(16, 21)
        Me.txtDIIO.MaxLength = 20
        Me.txtDIIO.Name = "txtDIIO"
        Me.txtDIIO.Size = New System.Drawing.Size(227, 31)
        Me.txtDIIO.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblFecProbPartoANterior)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.lblEstado)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cboFechasCub)
        Me.GroupBox2.Controls.Add(Me.lblNroCubiertas)
        Me.GroupBox2.Controls.Add(Me.lblFecUltParto)
        Me.GroupBox2.Controls.Add(Me.lblEstReproductivo)
        Me.GroupBox2.Controls.Add(Me.lblEstProductivo)
        Me.GroupBox2.Controls.Add(Me.lblCentro)
        Me.GroupBox2.Controls.Add(Me.lblCategoria)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.txtDIIO)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 66)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(624, 158)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DIIO"
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(466, 28)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(95, 14)
        Me.lblEstado.TabIndex = 101
        Me.lblEstado.Text = "---"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(328, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(111, 14)
        Me.Label11.TabIndex = 100
        Me.Label11.Text = "Estado"
        '
        'cboFechasCub
        '
        Me.cboFechasCub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFechasCub.Enabled = False
        Me.cboFechasCub.FormattingEnabled = True
        Me.cboFechasCub.Location = New System.Drawing.Point(465, 121)
        Me.cboFechasCub.Name = "cboFechasCub"
        Me.cboFechasCub.Size = New System.Drawing.Size(104, 26)
        Me.cboFechasCub.TabIndex = 4
        '
        'lblFecProbParto
        '
        Me.lblFecProbParto.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecProbParto.ForeColor = System.Drawing.Color.Maroon
        Me.lblFecProbParto.Location = New System.Drawing.Point(466, 94)
        Me.lblFecProbParto.Name = "lblFecProbParto"
        Me.lblFecProbParto.Size = New System.Drawing.Size(95, 14)
        Me.lblFecProbParto.TabIndex = 98
        Me.lblFecProbParto.Text = "---"
        '
        'lblNroCubiertas
        '
        Me.lblNroCubiertas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroCubiertas.Location = New System.Drawing.Point(466, 103)
        Me.lblNroCubiertas.Name = "lblNroCubiertas"
        Me.lblNroCubiertas.Size = New System.Drawing.Size(95, 14)
        Me.lblNroCubiertas.TabIndex = 97
        Me.lblNroCubiertas.Text = "---"
        '
        'lblFecUltParto
        '
        Me.lblFecUltParto.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecUltParto.Location = New System.Drawing.Point(466, 60)
        Me.lblFecUltParto.Name = "lblFecUltParto"
        Me.lblFecUltParto.Size = New System.Drawing.Size(95, 14)
        Me.lblFecUltParto.TabIndex = 95
        Me.lblFecUltParto.Text = "---"
        '
        'lblEstReproductivo
        '
        Me.lblEstReproductivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstReproductivo.Location = New System.Drawing.Point(134, 124)
        Me.lblEstReproductivo.Name = "lblEstReproductivo"
        Me.lblEstReproductivo.Size = New System.Drawing.Size(172, 14)
        Me.lblEstReproductivo.TabIndex = 94
        Me.lblEstReproductivo.Text = "---"
        '
        'lblEstProductivo
        '
        Me.lblEstProductivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstProductivo.Location = New System.Drawing.Point(134, 103)
        Me.lblEstProductivo.Name = "lblEstProductivo"
        Me.lblEstProductivo.Size = New System.Drawing.Size(172, 14)
        Me.lblEstProductivo.TabIndex = 93
        Me.lblEstProductivo.Text = "---"
        '
        'lblCentro
        '
        Me.lblCentro.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCentro.Location = New System.Drawing.Point(134, 81)
        Me.lblCentro.Name = "lblCentro"
        Me.lblCentro.Size = New System.Drawing.Size(172, 14)
        Me.lblCentro.TabIndex = 92
        Me.lblCentro.Text = "---"
        '
        'lblCategoria
        '
        Me.lblCategoria.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(134, 60)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(172, 14)
        Me.lblCategoria.TabIndex = 91
        Me.lblCategoria.Text = "---"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(328, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 14)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "Fecha Prob. Parto"
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(328, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(124, 14)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "N° Cubiertas"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(328, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 14)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Fecha Ult. Cubierta"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(328, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 14)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Fecha Ult. Parto"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 14)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Est. Reproductivo"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 14)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Est. Productivo"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 14)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Centro"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 14)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Categoría"
        '
        'btnBuscar
        '
        Me.btnBuscar.Enabled = False
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(249, 20)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(45, 32)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboToros)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.cboTipoDesechos)
        Me.GroupBox3.Controls.Add(Me.lblFecProbParto)
        Me.GroupBox3.Controls.Add(Me.cboEstProductivos)
        Me.GroupBox3.Controls.Add(Me.cboCondiciones)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtDiasGest)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 230)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(624, 126)
        Me.GroupBox3.TabIndex = 84
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Palpación"
        '
        'cboToros
        '
        Me.cboToros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToros.Enabled = False
        Me.cboToros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboToros.FormattingEnabled = True
        Me.cboToros.Location = New System.Drawing.Point(134, 55)
        Me.cboToros.Name = "cboToros"
        Me.cboToros.Size = New System.Drawing.Size(169, 26)
        Me.cboToros.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 22)
        Me.Label15.TabIndex = 97
        Me.Label15.Text = "Toro"
        '
        'cboTipoDesechos
        '
        Me.cboTipoDesechos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoDesechos.Enabled = False
        Me.cboTipoDesechos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoDesechos.FormattingEnabled = True
        Me.cboTipoDesechos.Location = New System.Drawing.Point(441, 55)
        Me.cboTipoDesechos.Name = "cboTipoDesechos"
        Me.cboTipoDesechos.Size = New System.Drawing.Size(169, 26)
        Me.cboTipoDesechos.TabIndex = 10
        '
        'cboEstProductivos
        '
        Me.cboEstProductivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstProductivos.Enabled = False
        Me.cboEstProductivos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstProductivos.FormattingEnabled = True
        Me.cboEstProductivos.Location = New System.Drawing.Point(441, 22)
        Me.cboEstProductivos.Name = "cboEstProductivos"
        Me.cboEstProductivos.Size = New System.Drawing.Size(169, 26)
        Me.cboEstProductivos.TabIndex = 9
        '
        'cboCondiciones
        '
        Me.cboCondiciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCondiciones.Enabled = False
        Me.cboCondiciones.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCondiciones.FormattingEnabled = True
        Me.cboCondiciones.Location = New System.Drawing.Point(134, 22)
        Me.cboCondiciones.Name = "cboCondiciones"
        Me.cboCondiciones.Size = New System.Drawing.Size(169, 26)
        Me.cboCondiciones.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 19)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "Resultado Palp."
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(328, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 22)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "Est. Productivo"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(328, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 22)
        Me.Label13.TabIndex = 92
        Me.Label13.Text = "Causa"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 14)
        Me.Label14.TabIndex = 91
        Me.Label14.Text = "Días Gestación"
        '
        'txtDiasGest
        '
        Me.txtDiasGest.Enabled = False
        Me.txtDiasGest.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasGest.Location = New System.Drawing.Point(134, 93)
        Me.txtDiasGest.MaxLength = 5
        Me.txtDiasGest.Name = "txtDiasGest"
        Me.txtDiasGest.Size = New System.Drawing.Size(54, 26)
        Me.txtDiasGest.TabIndex = 5
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(8, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(87, 26)
        Me.dtpFecha.TabIndex = 8
        '
        'btnGrabar
        '
        Me.btnGrabar.Enabled = False
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(12, 549)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 30)
        Me.btnGrabar.TabIndex = 12
        Me.btnGrabar.Text = "Agregar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(549, 549)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cboVeterinarios)
        Me.GroupBox4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(379, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(257, 57)
        Me.GroupBox4.TabIndex = 87
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Veterinario"
        '
        'lvGanado
        '
        Me.lvGanado.AutoArrange = False
        Me.lvGanado.BackColor = System.Drawing.SystemColors.Window
        Me.lvGanado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader0, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader11, Me.ColumnHeader7, Me.ColumnHeader12, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader5})
        Me.lvGanado.FullRowSelect = True
        Me.lvGanado.GridLines = True
        Me.lvGanado.HideSelection = False
        Me.lvGanado.Location = New System.Drawing.Point(12, 362)
        Me.lvGanado.MultiSelect = False
        Me.lvGanado.Name = "lvGanado"
        Me.lvGanado.Size = New System.Drawing.Size(624, 181)
        Me.lvGanado.TabIndex = 11
        Me.lvGanado.UseCompatibleStateImageBehavior = False
        Me.lvGanado.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Ordena"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.Width = 40
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Empresa"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Centro"
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DIIO"
        Me.ColumnHeader3.Width = 70
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Categoría"
        Me.ColumnHeader4.Width = 90
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Fecha Palp."
        Me.ColumnHeader11.Width = 75
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Hora"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Veterinario"
        Me.ColumnHeader12.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Est. Productivo"
        Me.ColumnHeader8.Width = 110
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Est Reproductivo"
        Me.ColumnHeader9.Width = 110
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Result. Palp."
        Me.ColumnHeader5.Width = 100
        '
        'btnFinalizar
        '
        Me.btnFinalizar.Enabled = False
        Me.btnFinalizar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinalizar.Image = CType(resources.GetObject("btnFinalizar.Image"), System.Drawing.Image)
        Me.btnFinalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFinalizar.Location = New System.Drawing.Point(198, 549)
        Me.btnFinalizar.Name = "btnFinalizar"
        Me.btnFinalizar.Size = New System.Drawing.Size(87, 30)
        Me.btnFinalizar.TabIndex = 13
        Me.btnFinalizar.Text = "Finalizar"
        Me.btnFinalizar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dtpFecha)
        Me.GroupBox5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(270, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(103, 57)
        Me.GroupBox5.TabIndex = 88
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Fecha"
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(105, 549)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 89
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblFecProbPartoANterior
        '
        Me.lblFecProbPartoANterior.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecProbPartoANterior.Location = New System.Drawing.Point(466, 81)
        Me.lblFecProbPartoANterior.Name = "lblFecProbPartoANterior"
        Me.lblFecProbPartoANterior.Size = New System.Drawing.Size(95, 14)
        Me.lblFecProbPartoANterior.TabIndex = 103
        Me.lblFecProbPartoANterior.Text = "---"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(328, 81)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(137, 14)
        Me.Label16.TabIndex = 102
        Me.Label16.Text = "Fecha Ult. Prob. Par"
        '
        'frmPalpacionesIngresoDIIO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 586)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnFinalizar)
        Me.Controls.Add(Me.lvGanado)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmPalpacionesIngresoDIIO"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ingreso de Palpaciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents cboVeterinarios As System.Windows.Forms.ComboBox
    Friend WithEvents txtDIIO As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblFecProbParto As System.Windows.Forms.Label
    Friend WithEvents lblNroCubiertas As System.Windows.Forms.Label
    Friend WithEvents lblFecUltParto As System.Windows.Forms.Label
    Friend WithEvents lblEstReproductivo As System.Windows.Forms.Label
    Friend WithEvents lblEstProductivo As System.Windows.Forms.Label
    Friend WithEvents lblCentro As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents cboEstProductivos As System.Windows.Forms.ComboBox
    Friend WithEvents cboCondiciones As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtDiasGest As System.Windows.Forms.TextBox
    Friend WithEvents cboToros As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cboTipoDesechos As System.Windows.Forms.ComboBox
    Friend WithEvents cboFechasCub As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lvGanado As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnFinalizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblFecProbPartoANterior As Label
    Friend WithEvents Label16 As Label
End Class
