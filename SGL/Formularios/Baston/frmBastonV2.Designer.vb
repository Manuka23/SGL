<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBastonV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBastonV2))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lvALLFLEX_XLS = New System.Windows.Forms.ListView()
        Me.LineaColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DIIOColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TipoLecColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RepColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TipDigitado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.lblMSG = New System.Windows.Forms.Label()
        Me.pnlMSG = New System.Windows.Forms.Panel()
        Me.lblCentro = New System.Windows.Forms.Label()
        Me.btnBastonLee = New System.Windows.Forms.Button()
        Me.cboPuertos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.COMPort = New System.IO.Ports.SerialPort(Me.components)
        Me.tmrLEE = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoBaston = New System.Windows.Forms.ComboBox()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblRepetidos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotDiios = New System.Windows.Forms.Label()
        Me.lblTotErrores = New System.Windows.Forms.Label()
        Me.lblConErrores = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lvXRS_SESIONES = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvXRS_DETALLE = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Digitado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Fecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnArchivo = New System.Windows.Forms.Button()
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.btnBastonLimpia = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnEliminaRepetidos = New System.Windows.Forms.Button()
        Me.tmrLIMPIA = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesaVal = New System.Windows.Forms.Label()
        Me.lblProcesaMax = New System.Windows.Forms.Label()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.lblProcesaFin = New System.Windows.Forms.Label()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.pnlMSG.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(320, 633)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 37)
        Me.btnSalir.TabIndex = 28
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnSalir, "Cerrar ventana")
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lvALLFLEX_XLS
        '
        Me.lvALLFLEX_XLS.AutoArrange = False
        Me.lvALLFLEX_XLS.BackColor = System.Drawing.SystemColors.Window
        Me.lvALLFLEX_XLS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LineaColumn, Me.DIIOColumn, Me.FechaColumn, Me.TipoLecColumn, Me.RepColumn, Me.TipDigitado})
        Me.lvALLFLEX_XLS.FullRowSelect = True
        Me.lvALLFLEX_XLS.GridLines = True
        Me.lvALLFLEX_XLS.HideSelection = False
        Me.lvALLFLEX_XLS.Location = New System.Drawing.Point(20, 160)
        Me.lvALLFLEX_XLS.Margin = New System.Windows.Forms.Padding(4)
        Me.lvALLFLEX_XLS.Name = "lvALLFLEX_XLS"
        Me.lvALLFLEX_XLS.Size = New System.Drawing.Size(415, 429)
        Me.lvALLFLEX_XLS.TabIndex = 65
        Me.lvALLFLEX_XLS.UseCompatibleStateImageBehavior = False
        Me.lvALLFLEX_XLS.View = System.Windows.Forms.View.Details
        '
        'LineaColumn
        '
        Me.LineaColumn.Text = "Nro"
        '
        'DIIOColumn
        '
        Me.DIIOColumn.Text = "DIIO"
        Me.DIIOColumn.Width = 150
        '
        'FechaColumn
        '
        Me.FechaColumn.Text = "Repetido"
        Me.FechaColumn.Width = 0
        '
        'TipoLecColumn
        '
        Me.TipoLecColumn.Text = "Tipo"
        '
        'RepColumn
        '
        Me.RepColumn.Text = "Repetido"
        '
        'TipDigitado
        '
        Me.TipDigitado.Text = "Digitado"
        '
        'btnProcesar
        '
        Me.btnProcesar.Enabled = False
        Me.btnProcesar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(201, 633)
        Me.btnProcesar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(116, 37)
        Me.btnProcesar.TabIndex = 117
        Me.btnProcesar.Text = "Procesar"
        Me.ToolTip1.SetToolTip(Me.btnProcesar, "Procesar datos del bastón")
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'lblMSG
        '
        Me.lblMSG.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMSG.Location = New System.Drawing.Point(4, 42)
        Me.lblMSG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMSG.Name = "lblMSG"
        Me.lblMSG.Size = New System.Drawing.Size(405, 27)
        Me.lblMSG.TabIndex = 118
        Me.lblMSG.Text = "SELECCIONE EL PUERTO PARA LECTURA"
        Me.lblMSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMSG
        '
        Me.pnlMSG.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlMSG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMSG.Controls.Add(Me.lblCentro)
        Me.pnlMSG.Controls.Add(Me.lblMSG)
        Me.pnlMSG.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.pnlMSG.Location = New System.Drawing.Point(16, 4)
        Me.pnlMSG.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlMSG.Name = "pnlMSG"
        Me.pnlMSG.Size = New System.Drawing.Size(415, 71)
        Me.pnlMSG.TabIndex = 119
        '
        'lblCentro
        '
        Me.lblCentro.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCentro.Location = New System.Drawing.Point(9, 6)
        Me.lblCentro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCentro.Name = "lblCentro"
        Me.lblCentro.Size = New System.Drawing.Size(405, 18)
        Me.lblCentro.TabIndex = 118
        Me.lblCentro.Text = "CENTRO"
        Me.lblCentro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBastonLee
        '
        Me.btnBastonLee.Enabled = False
        Me.btnBastonLee.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLee.Image = CType(resources.GetObject("btnBastonLee.Image"), System.Drawing.Image)
        Me.btnBastonLee.Location = New System.Drawing.Point(17, 633)
        Me.btnBastonLee.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBastonLee.Name = "btnBastonLee"
        Me.btnBastonLee.Size = New System.Drawing.Size(51, 37)
        Me.btnBastonLee.TabIndex = 121
        Me.ToolTip1.SetToolTip(Me.btnBastonLee, "LEER DATOS DEL BASTON")
        Me.btnBastonLee.UseVisualStyleBackColor = True
        '
        'cboPuertos
        '
        Me.cboPuertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuertos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPuertos.FormattingEnabled = True
        Me.cboPuertos.Location = New System.Drawing.Point(113, 121)
        Me.cboPuertos.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPuertos.Name = "cboPuertos"
        Me.cboPuertos.Size = New System.Drawing.Size(264, 31)
        Me.cboPuertos.TabIndex = 122
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 127)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 21)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "PUERTO:"
        '
        'COMPort
        '
        '
        'tmrLEE
        '
        Me.tmrLEE.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 87)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 21)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "ORIGEN:"
        '
        'cboTipoBaston
        '
        Me.cboTipoBaston.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoBaston.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoBaston.FormattingEnabled = True
        Me.cboTipoBaston.Items.AddRange(New Object() {"BASTON ALLFLEX", "BASTON XRS", "BASTON XRS2 (NUEVO)", "BASTON GALLAGHER XR4", "BASTON AGRIDENT AWR300", "PLANILLA EXCEL"})
        Me.cboTipoBaston.Location = New System.Drawing.Point(113, 81)
        Me.cboTipoBaston.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoBaston.Name = "cboTipoBaston"
        Me.cboTipoBaston.Size = New System.Drawing.Size(321, 31)
        Me.cboTipoBaston.TabIndex = 124
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblRepetidos)
        Me.pnlEstReprod.Controls.Add(Me.Label6)
        Me.pnlEstReprod.Controls.Add(Me.lblTotDiios)
        Me.pnlEstReprod.Controls.Add(Me.lblTotErrores)
        Me.pnlEstReprod.Controls.Add(Me.lblConErrores)
        Me.pnlEstReprod.Controls.Add(Me.Label3)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(19, 596)
        Me.pnlEstReprod.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(417, 30)
        Me.pnlEstReprod.TabIndex = 126
        '
        'lblRepetidos
        '
        Me.lblRepetidos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepetidos.Location = New System.Drawing.Point(344, 2)
        Me.lblRepetidos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRepetidos.Name = "lblRepetidos"
        Me.lblRepetidos.Size = New System.Drawing.Size(64, 26)
        Me.lblRepetidos.TabIndex = 49
        Me.lblRepetidos.Text = "0"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(240, 2)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 26)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "REPETIDOS"
        '
        'lblTotDiios
        '
        Me.lblTotDiios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDiios.Location = New System.Drawing.Point(115, 2)
        Me.lblTotDiios.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotDiios.Name = "lblTotDiios"
        Me.lblTotDiios.Size = New System.Drawing.Size(64, 26)
        Me.lblTotDiios.TabIndex = 1
        Me.lblTotDiios.Text = "0"
        '
        'lblTotErrores
        '
        Me.lblTotErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotErrores.Location = New System.Drawing.Point(1001, 2)
        Me.lblTotErrores.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotErrores.Name = "lblTotErrores"
        Me.lblTotErrores.Size = New System.Drawing.Size(116, 26)
        Me.lblTotErrores.TabIndex = 47
        Me.lblTotErrores.Text = "0"
        Me.lblTotErrores.Visible = False
        '
        'lblConErrores
        '
        Me.lblConErrores.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConErrores.Location = New System.Drawing.Point(888, 2)
        Me.lblConErrores.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblConErrores.Name = "lblConErrores"
        Me.lblConErrores.Size = New System.Drawing.Size(105, 26)
        Me.lblConErrores.TabIndex = 48
        Me.lblConErrores.Text = "Con Errores"
        Me.lblConErrores.Visible = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 2)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(152, 26)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "TOTAL DIIOs"
        '
        'lvXRS_SESIONES
        '
        Me.lvXRS_SESIONES.AutoArrange = False
        Me.lvXRS_SESIONES.BackColor = System.Drawing.SystemColors.Window
        Me.lvXRS_SESIONES.CheckBoxes = True
        Me.lvXRS_SESIONES.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader2, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader8, Me.ColumnHeader10})
        Me.lvXRS_SESIONES.FullRowSelect = True
        Me.lvXRS_SESIONES.GridLines = True
        Me.lvXRS_SESIONES.HideSelection = False
        Me.lvXRS_SESIONES.Location = New System.Drawing.Point(20, 160)
        Me.lvXRS_SESIONES.Margin = New System.Windows.Forms.Padding(4)
        Me.lvXRS_SESIONES.Name = "lvXRS_SESIONES"
        Me.lvXRS_SESIONES.Size = New System.Drawing.Size(415, 157)
        Me.lvXRS_SESIONES.TabIndex = 127
        Me.lvXRS_SESIONES.UseCompatibleStateImageBehavior = False
        Me.lvXRS_SESIONES.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = ""
        Me.ColumnHeader9.Width = 30
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Sesión"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Fecha"
        Me.ColumnHeader5.Width = 100
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "DIIOs"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Cache"
        Me.ColumnHeader8.Width = 0
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Posicion"
        Me.ColumnHeader10.Width = 0
        '
        'lvXRS_DETALLE
        '
        Me.lvXRS_DETALLE.AutoArrange = False
        Me.lvXRS_DETALLE.BackColor = System.Drawing.SystemColors.Window
        Me.lvXRS_DETALLE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader13, Me.Digitado, Me.Fecha})
        Me.lvXRS_DETALLE.FullRowSelect = True
        Me.lvXRS_DETALLE.GridLines = True
        Me.lvXRS_DETALLE.HideSelection = False
        Me.lvXRS_DETALLE.Location = New System.Drawing.Point(20, 338)
        Me.lvXRS_DETALLE.Margin = New System.Windows.Forms.Padding(4)
        Me.lvXRS_DETALLE.Name = "lvXRS_DETALLE"
        Me.lvXRS_DETALLE.Size = New System.Drawing.Size(415, 250)
        Me.lvXRS_DETALLE.TabIndex = 128
        Me.lvXRS_DETALLE.UseCompatibleStateImageBehavior = False
        Me.lvXRS_DETALLE.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nro"
        Me.ColumnHeader3.Width = 40
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "DIIO"
        Me.ColumnHeader4.Width = 70
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fecha"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Sesión"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Repetido"
        Me.ColumnHeader13.Width = 0
        '
        'Digitado
        '
        Me.Digitado.Text = "Digitado"
        Me.Digitado.Width = 100
        '
        'Fecha
        '
        Me.Fecha.Text = "Fecha"
        Me.Fecha.Width = 0
        '
        'btnArchivo
        '
        Me.btnArchivo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchivo.Image = CType(resources.GetObject("btnArchivo.Image"), System.Drawing.Image)
        Me.btnArchivo.Location = New System.Drawing.Point(387, 121)
        Me.btnArchivo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(49, 33)
        Me.btnArchivo.TabIndex = 130
        Me.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnArchivo, "Abrir archivo excel")
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'btnBastonLimpia
        '
        Me.btnBastonLimpia.Enabled = False
        Me.btnBastonLimpia.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLimpia.Image = CType(resources.GetObject("btnBastonLimpia.Image"), System.Drawing.Image)
        Me.btnBastonLimpia.Location = New System.Drawing.Point(68, 633)
        Me.btnBastonLimpia.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBastonLimpia.Name = "btnBastonLimpia"
        Me.btnBastonLimpia.Size = New System.Drawing.Size(51, 37)
        Me.btnBastonLimpia.TabIndex = 131
        Me.ToolTip1.SetToolTip(Me.btnBastonLimpia, "BORRAR MEMORIA DEL BASTÓN (COMPLETO)")
        Me.btnBastonLimpia.UseVisualStyleBackColor = True
        '
        'btnEliminaRepetidos
        '
        Me.btnEliminaRepetidos.Enabled = False
        Me.btnEliminaRepetidos.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminaRepetidos.Image = CType(resources.GetObject("btnEliminaRepetidos.Image"), System.Drawing.Image)
        Me.btnEliminaRepetidos.Location = New System.Drawing.Point(119, 633)
        Me.btnEliminaRepetidos.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminaRepetidos.Name = "btnEliminaRepetidos"
        Me.btnEliminaRepetidos.Size = New System.Drawing.Size(51, 37)
        Me.btnEliminaRepetidos.TabIndex = 133
        Me.ToolTip1.SetToolTip(Me.btnEliminaRepetidos, "ELIMINAR DIIOs REPETIDOS")
        Me.btnEliminaRepetidos.UseVisualStyleBackColor = True
        '
        'tmrLIMPIA
        '
        Me.tmrLIMPIA.Interval = 1000
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(137, 642)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Label4"
        Me.Label4.Visible = False
        '
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesaVal)
        Me.pnlProcesa.Controls.Add(Me.lblProcesaMax)
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(68, 415)
        Me.pnlProcesa.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(310, 87)
        Me.pnlProcesa.TabIndex = 241
        Me.pnlProcesa.Visible = False
        '
        'lblProcesaVal
        '
        Me.lblProcesaVal.AutoSize = True
        Me.lblProcesaVal.Location = New System.Drawing.Point(105, 9)
        Me.lblProcesaVal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProcesaVal.Name = "lblProcesaVal"
        Me.lblProcesaVal.Size = New System.Drawing.Size(85, 16)
        Me.lblProcesaVal.TabIndex = 71
        Me.lblProcesaVal.Text = "Exportando..."
        '
        'lblProcesaMax
        '
        Me.lblProcesaMax.AutoSize = True
        Me.lblProcesaMax.Location = New System.Drawing.Point(196, 64)
        Me.lblProcesaMax.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProcesaMax.Name = "lblProcesaMax"
        Me.lblProcesaMax.Size = New System.Drawing.Size(85, 16)
        Me.lblProcesaMax.TabIndex = 70
        Me.lblProcesaMax.Text = "Exportando..."
        '
        'lblProcesa
        '
        Me.lblProcesa.AutoSize = True
        Me.lblProcesa.Location = New System.Drawing.Point(12, 9)
        Me.lblProcesa.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProcesa.Name = "lblProcesa"
        Me.lblProcesa.Size = New System.Drawing.Size(85, 16)
        Me.lblProcesa.TabIndex = 69
        Me.lblProcesa.Text = "Exportando..."
        '
        'pbProcesa
        '
        Me.pbProcesa.Location = New System.Drawing.Point(16, 27)
        Me.pbProcesa.Margin = New System.Windows.Forms.Padding(4)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(273, 33)
        Me.pbProcesa.TabIndex = 68
        '
        'lblProcesaFin
        '
        Me.lblProcesaFin.AutoSize = True
        Me.lblProcesaFin.Location = New System.Drawing.Point(12, 673)
        Me.lblProcesaFin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProcesaFin.Name = "lblProcesaFin"
        Me.lblProcesaFin.Size = New System.Drawing.Size(85, 16)
        Me.lblProcesaFin.TabIndex = 232
        Me.lblProcesaFin.Text = "Exportando..."
        '
        'txtArchivo
        '
        Me.txtArchivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtArchivo.Location = New System.Drawing.Point(113, 121)
        Me.txtArchivo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(264, 30)
        Me.txtArchivo.TabIndex = 129
        '
        'frmBastonV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 733)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblProcesaFin)
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.lvXRS_SESIONES)
        Me.Controls.Add(Me.btnEliminaRepetidos)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnBastonLimpia)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTipoBaston)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPuertos)
        Me.Controls.Add(Me.btnBastonLee)
        Me.Controls.Add(Me.pnlMSG)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnArchivo)
        Me.Controls.Add(Me.txtArchivo)
        Me.Controls.Add(Me.lvXRS_DETALLE)
        Me.Controls.Add(Me.lvALLFLEX_XLS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmBastonV2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lectura de Baston"
        Me.pnlMSG.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lvALLFLEX_XLS As System.Windows.Forms.ListView
    Friend WithEvents LineaColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents DIIOColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents lblMSG As System.Windows.Forms.Label
    Friend WithEvents pnlMSG As System.Windows.Forms.Panel
    Friend WithEvents btnBastonLee As System.Windows.Forms.Button
    Friend WithEvents cboPuertos As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents COMPort As System.IO.Ports.SerialPort
    Friend WithEvents tmrLEE As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoBaston As System.Windows.Forms.ComboBox
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents lblTotDiios As System.Windows.Forms.Label
    Friend WithEvents lblTotErrores As System.Windows.Forms.Label
    Friend WithEvents lblConErrores As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lvXRS_SESIONES As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvXRS_DETALLE As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnArchivo As System.Windows.Forms.Button
    Friend WithEvents OpenFDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBastonLimpia As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tmrLIMPIA As System.Windows.Forms.Timer
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRepetidos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnEliminaRepetidos As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents FechaColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblCentro As Label
    Friend WithEvents TipoLecColumn As ColumnHeader
    Friend WithEvents RepColumn As ColumnHeader
    Friend WithEvents pnlProcesa As Panel
    Friend WithEvents lblProcesaVal As Label
    Friend WithEvents lblProcesaMax As Label
    Friend WithEvents lblProcesa As Label
    Friend WithEvents pbProcesa As ProgressBar
    Friend WithEvents lblProcesaFin As Label
    Friend WithEvents txtArchivo As TextBox
    Friend WithEvents TipDigitado As ColumnHeader
    Friend WithEvents Fecha As ColumnHeader
    Friend WithEvents Digitado As ColumnHeader
End Class
