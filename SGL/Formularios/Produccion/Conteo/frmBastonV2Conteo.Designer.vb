<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmBastonV2Conteo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBastonV2Conteo))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lvALLFLEX_XLS = New System.Windows.Forms.ListView()
        Me.NroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DIIOCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SesionCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RepetidoCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.lblMSG = New System.Windows.Forms.Label()
        Me.pnlMSG = New System.Windows.Forms.Panel()
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
        Me.LineCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SeasonCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DateCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.AreteCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CacheCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.PosicionCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lvXRS_DETALLE = New System.Windows.Forms.ListView()
        Me.LinCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiioXRSCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FechaXRSCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SessionXRSCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RepetXRSCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Digitado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnArchivo = New System.Windows.Forms.Button()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnEliminaRepetidos = New System.Windows.Forms.Button()
        Me.tmrLIMPIA = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesaVal = New System.Windows.Forms.Label()
        Me.lblProcesaMax = New System.Windows.Forms.Label()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.lblProcesaFin = New System.Windows.Forms.Label()
        Me.btnEliminaDiio = New System.Windows.Forms.Button()
        Me.pnlMSG.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(237, 580)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
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
        Me.lvALLFLEX_XLS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NroCol, Me.DIIOCol, Me.FechaCol, Me.SesionCol, Me.RepetidoCol})
        Me.lvALLFLEX_XLS.FullRowSelect = True
        Me.lvALLFLEX_XLS.GridLines = True
        Me.lvALLFLEX_XLS.HideSelection = False
        Me.lvALLFLEX_XLS.Location = New System.Drawing.Point(12, 195)
        Me.lvALLFLEX_XLS.Name = "lvALLFLEX_XLS"
        Me.lvALLFLEX_XLS.Size = New System.Drawing.Size(312, 349)
        Me.lvALLFLEX_XLS.TabIndex = 65
        Me.lvALLFLEX_XLS.UseCompatibleStateImageBehavior = False
        Me.lvALLFLEX_XLS.View = System.Windows.Forms.View.Details
        '
        'NroCol
        '
        Me.NroCol.Text = "Nro"
        '
        'DIIOCol
        '
        Me.DIIOCol.Text = "DIIO"
        Me.DIIOCol.Width = 80
        '
        'FechaCol
        '
        Me.FechaCol.Text = "Fecha"
        '
        'SesionCol
        '
        Me.SesionCol.Width = 0
        '
        'RepetidoCol
        '
        Me.RepetidoCol.Text = "Repetido"
        Me.RepetidoCol.Width = 50
        '
        'btnProcesar
        '
        Me.btnProcesar.Enabled = False
        Me.btnProcesar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(148, 580)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(87, 30)
        Me.btnProcesar.TabIndex = 117
        Me.btnProcesar.Text = "Procesar"
        Me.ToolTip1.SetToolTip(Me.btnProcesar, "Procesar datos del bastón")
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'lblMSG
        '
        Me.lblMSG.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMSG.Location = New System.Drawing.Point(3, 6)
        Me.lblMSG.Name = "lblMSG"
        Me.lblMSG.Size = New System.Drawing.Size(304, 23)
        Me.lblMSG.TabIndex = 118
        Me.lblMSG.Text = "SELECCIONE EL PUERTO PARA LECTURA"
        Me.lblMSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlMSG
        '
        Me.pnlMSG.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlMSG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMSG.Controls.Add(Me.lblMSG)
        Me.pnlMSG.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.pnlMSG.Location = New System.Drawing.Point(12, 12)
        Me.pnlMSG.Name = "pnlMSG"
        Me.pnlMSG.Size = New System.Drawing.Size(312, 34)
        Me.pnlMSG.TabIndex = 119
        '
        'btnBastonLee
        '
        Me.btnBastonLee.Enabled = False
        Me.btnBastonLee.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLee.Image = CType(resources.GetObject("btnBastonLee.Image"), System.Drawing.Image)
        Me.btnBastonLee.Location = New System.Drawing.Point(10, 580)
        Me.btnBastonLee.Name = "btnBastonLee"
        Me.btnBastonLee.Size = New System.Drawing.Size(38, 30)
        Me.btnBastonLee.TabIndex = 121
        Me.ToolTip1.SetToolTip(Me.btnBastonLee, "LEER DATOS DEL BASTON")
        Me.btnBastonLee.UseVisualStyleBackColor = True
        '
        'cboPuertos
        '
        Me.cboPuertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuertos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPuertos.FormattingEnabled = True
        Me.cboPuertos.Location = New System.Drawing.Point(82, 157)
        Me.cboPuertos.Name = "cboPuertos"
        Me.cboPuertos.Size = New System.Drawing.Size(199, 26)
        Me.cboPuertos.TabIndex = 122
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 162)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
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
        Me.Label1.Location = New System.Drawing.Point(13, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "ORIGEN:"
        '
        'cboTipoBaston
        '
        Me.cboTipoBaston.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoBaston.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoBaston.FormattingEnabled = True
        Me.cboTipoBaston.Items.AddRange(New Object() {"BASTON ALLFLEX", "BASTON XRS", "BASTON XRS2 (NUEVO)", "BASTON GALLAGHER XR4", "BASTON AGRIDENT AWR300", "PLANILLA EXCEL"})
        Me.cboTipoBaston.Location = New System.Drawing.Point(82, 125)
        Me.cboTipoBaston.Name = "cboTipoBaston"
        Me.cboTipoBaston.Size = New System.Drawing.Size(242, 26)
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
        Me.pnlEstReprod.Location = New System.Drawing.Point(11, 550)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(313, 25)
        Me.pnlEstReprod.TabIndex = 126
        '
        'lblRepetidos
        '
        Me.lblRepetidos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepetidos.Location = New System.Drawing.Point(254, 2)
        Me.lblRepetidos.Name = "lblRepetidos"
        Me.lblRepetidos.Size = New System.Drawing.Size(48, 21)
        Me.lblRepetidos.TabIndex = 49
        Me.lblRepetidos.Text = "0"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(195, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 21)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "REPETID"
        '
        'lblTotDiios
        '
        Me.lblTotDiios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDiios.Location = New System.Drawing.Point(88, 2)
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
        Me.Label3.Size = New System.Drawing.Size(114, 21)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "TOTAL DIIOs"
        '
        'lvXRS_SESIONES
        '
        Me.lvXRS_SESIONES.AutoArrange = False
        Me.lvXRS_SESIONES.BackColor = System.Drawing.SystemColors.Window
        Me.lvXRS_SESIONES.CheckBoxes = True
        Me.lvXRS_SESIONES.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LineCol, Me.SeasonCol, Me.DateCol, Me.AreteCol, Me.CacheCol, Me.PosicionCol})
        Me.lvXRS_SESIONES.FullRowSelect = True
        Me.lvXRS_SESIONES.GridLines = True
        Me.lvXRS_SESIONES.HideSelection = False
        Me.lvXRS_SESIONES.Location = New System.Drawing.Point(12, 196)
        Me.lvXRS_SESIONES.Name = "lvXRS_SESIONES"
        Me.lvXRS_SESIONES.Size = New System.Drawing.Size(312, 138)
        Me.lvXRS_SESIONES.TabIndex = 127
        Me.lvXRS_SESIONES.UseCompatibleStateImageBehavior = False
        Me.lvXRS_SESIONES.View = System.Windows.Forms.View.Details
        '
        'LineCol
        '
        Me.LineCol.Text = ""
        Me.LineCol.Width = 30
        '
        'SeasonCol
        '
        Me.SeasonCol.Text = "Sesión"
        Me.SeasonCol.Width = 80
        '
        'DateCol
        '
        Me.DateCol.Text = "Fecha"
        Me.DateCol.Width = 100
        '
        'AreteCol
        '
        Me.AreteCol.Text = "DIIOs"
        Me.AreteCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CacheCol
        '
        Me.CacheCol.Text = "Cache"
        Me.CacheCol.Width = 0
        '
        'PosicionCol
        '
        Me.PosicionCol.Text = "Posicion"
        Me.PosicionCol.Width = 0
        '
        'lvXRS_DETALLE
        '
        Me.lvXRS_DETALLE.AutoArrange = False
        Me.lvXRS_DETALLE.BackColor = System.Drawing.SystemColors.Window
        Me.lvXRS_DETALLE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.LinCol, Me.DiioXRSCol, Me.FechaXRSCol, Me.SessionXRSCol, Me.RepetXRSCol, Me.Digitado})
        Me.lvXRS_DETALLE.FullRowSelect = True
        Me.lvXRS_DETALLE.GridLines = True
        Me.lvXRS_DETALLE.HideSelection = False
        Me.lvXRS_DETALLE.Location = New System.Drawing.Point(12, 350)
        Me.lvXRS_DETALLE.Name = "lvXRS_DETALLE"
        Me.lvXRS_DETALLE.Size = New System.Drawing.Size(312, 194)
        Me.lvXRS_DETALLE.TabIndex = 128
        Me.lvXRS_DETALLE.UseCompatibleStateImageBehavior = False
        Me.lvXRS_DETALLE.View = System.Windows.Forms.View.Details
        '
        'LinCol
        '
        Me.LinCol.Text = "Nro"
        Me.LinCol.Width = 40
        '
        'DiioXRSCol
        '
        Me.DiioXRSCol.Text = "DIIO"
        Me.DiioXRSCol.Width = 70
        '
        'FechaXRSCol
        '
        Me.FechaXRSCol.Text = "Fecha"
        Me.FechaXRSCol.Width = 100
        '
        'SessionXRSCol
        '
        Me.SessionXRSCol.Text = "Sesión"
        Me.SessionXRSCol.Width = 70
        '
        'RepetXRSCol
        '
        Me.RepetXRSCol.Text = "Repetido"
        Me.RepetXRSCol.Width = 0
        '
        'Digitado
        '
        Me.Digitado.Text = "Digitado"
        '
        'btnArchivo
        '
        Me.btnArchivo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchivo.Image = CType(resources.GetObject("btnArchivo.Image"), System.Drawing.Image)
        Me.btnArchivo.Location = New System.Drawing.Point(287, 157)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(37, 27)
        Me.btnArchivo.TabIndex = 130
        Me.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnArchivo, "Abrir archivo excel")
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'txtArchivo
        '
        Me.txtArchivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtArchivo.Location = New System.Drawing.Point(82, 157)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(199, 26)
        Me.txtArchivo.TabIndex = 129
        '
        'btnEliminaRepetidos
        '
        Me.btnEliminaRepetidos.Enabled = False
        Me.btnEliminaRepetidos.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminaRepetidos.Image = CType(resources.GetObject("btnEliminaRepetidos.Image"), System.Drawing.Image)
        Me.btnEliminaRepetidos.Location = New System.Drawing.Point(86, 580)
        Me.btnEliminaRepetidos.Name = "btnEliminaRepetidos"
        Me.btnEliminaRepetidos.Size = New System.Drawing.Size(38, 30)
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
        Me.Label4.Location = New System.Drawing.Point(100, 588)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
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
        Me.pnlProcesa.Location = New System.Drawing.Point(50, 379)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(233, 71)
        Me.pnlProcesa.TabIndex = 135
        Me.pnlProcesa.Visible = False
        '
        'lblProcesaVal
        '
        Me.lblProcesaVal.AutoSize = True
        Me.lblProcesaVal.Location = New System.Drawing.Point(76, 7)
        Me.lblProcesaVal.Name = "lblProcesaVal"
        Me.lblProcesaVal.Size = New System.Drawing.Size(70, 13)
        Me.lblProcesaVal.TabIndex = 71
        Me.lblProcesaVal.Text = "Exportando..."
        '
        'lblProcesaMax
        '
        Me.lblProcesaMax.AutoSize = True
        Me.lblProcesaMax.Location = New System.Drawing.Point(147, 52)
        Me.lblProcesaMax.Name = "lblProcesaMax"
        Me.lblProcesaMax.Size = New System.Drawing.Size(70, 13)
        Me.lblProcesaMax.TabIndex = 70
        Me.lblProcesaMax.Text = "Exportando..."
        '
        'lblProcesa
        '
        Me.lblProcesa.AutoSize = True
        Me.lblProcesa.Location = New System.Drawing.Point(9, 7)
        Me.lblProcesa.Name = "lblProcesa"
        Me.lblProcesa.Size = New System.Drawing.Size(70, 13)
        Me.lblProcesa.TabIndex = 69
        Me.lblProcesa.Text = "Exportando..."
        '
        'pbProcesa
        '
        Me.pbProcesa.Location = New System.Drawing.Point(12, 22)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(205, 27)
        Me.pbProcesa.TabIndex = 68
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboCentros)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(314, 57)
        Me.GroupBox2.TabIndex = 228
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Centro de Gestión"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(6, 25)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(301, 26)
        Me.cboCentros.TabIndex = 1
        '
        'lblProcesaFin
        '
        Me.lblProcesaFin.AutoSize = True
        Me.lblProcesaFin.Location = New System.Drawing.Point(13, 613)
        Me.lblProcesaFin.Name = "lblProcesaFin"
        Me.lblProcesaFin.Size = New System.Drawing.Size(70, 13)
        Me.lblProcesaFin.TabIndex = 72
        Me.lblProcesaFin.Text = "Exportando..."
        '
        'btnEliminaDiio
        '
        Me.btnEliminaDiio.Enabled = False
        Me.btnEliminaDiio.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminaDiio.Image = CType(resources.GetObject("btnEliminaDiio.Image"), System.Drawing.Image)
        Me.btnEliminaDiio.Location = New System.Drawing.Point(50, 580)
        Me.btnEliminaDiio.Name = "btnEliminaDiio"
        Me.btnEliminaDiio.Size = New System.Drawing.Size(35, 30)
        Me.btnEliminaDiio.TabIndex = 229
        Me.btnEliminaDiio.UseVisualStyleBackColor = True
        Me.btnEliminaDiio.Visible = False
        '
        'frmBastonV2Conteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(332, 630)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminaDiio)
        Me.Controls.Add(Me.lblProcesaFin)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.lvXRS_SESIONES)
        Me.Controls.Add(Me.btnEliminaRepetidos)
        Me.Controls.Add(Me.Label4)
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
        Me.Name = "frmBastonV2Conteo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lectura de Baston"
        Me.pnlMSG.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lvALLFLEX_XLS As System.Windows.Forms.ListView
    Friend WithEvents NroCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DIIOCol As System.Windows.Forms.ColumnHeader
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
    Friend WithEvents SeasonCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvXRS_DETALLE As System.Windows.Forms.ListView
    Friend WithEvents LinCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DiioXRSCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents DateCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents AreteCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents FechaXRSCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnArchivo As System.Windows.Forms.Button
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents OpenFDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tmrLIMPIA As System.Windows.Forms.Timer
    Friend WithEvents LineCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents SessionXRSCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRepetidos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnEliminaRepetidos As System.Windows.Forms.Button
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents CacheCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents PosicionCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents RepetidoCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents RepetXRSCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents FechaCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents SesionCol As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboCentros As ComboBox
    Friend WithEvents lblProcesaMax As Label
    Friend WithEvents lblProcesaVal As Label
    Friend WithEvents lblProcesaFin As Label
    Friend WithEvents btnEliminaDiio As Button
    Friend WithEvents Digitado As ColumnHeader
End Class
