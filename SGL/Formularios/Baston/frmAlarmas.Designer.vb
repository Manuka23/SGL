<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAlarmas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlarmas))
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoBaston = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPuertos = New System.Windows.Forms.ComboBox()
        Me.pnlMSG = New System.Windows.Forms.Panel()
        Me.lblMSG = New System.Windows.Forms.Label()
        Me.COMPort = New System.IO.Ports.SerialPort(Me.components)
        Me.lvALARMAS = New System.Windows.Forms.ListView()
        Me.columnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnArchivo = New System.Windows.Forms.Button()
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.tmrLEE = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrLIMPIA = New System.Windows.Forms.Timer(Me.components)
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblTotDiios = New System.Windows.Forms.Label()
        Me.lblTotErrores = New System.Windows.Forms.Label()
        Me.lblConErrores = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesaVal = New System.Windows.Forms.Label()
        Me.lblProcesaMax = New System.Windows.Forms.Label()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.pnlMSG.SuspendLayout()
        Me.pnlEstReprod.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnProcesar
        '
        Me.btnProcesar.Enabled = False
        Me.btnProcesar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(12, 539)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(95, 30)
        Me.btnProcesar.TabIndex = 131
        Me.btnProcesar.Text = "Finalizar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(251, 539)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 130
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "ORIGEN:"
        '
        'cboTipoBaston
        '
        Me.cboTipoBaston.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoBaston.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoBaston.FormattingEnabled = True
        Me.cboTipoBaston.Items.AddRange(New Object() {"BASTON GALLAGHER XR4", "BASTON AGRIDENT AWR300"})
        Me.cboTipoBaston.Location = New System.Drawing.Point(82, 53)
        Me.cboTipoBaston.Name = "cboTipoBaston"
        Me.cboTipoBaston.Size = New System.Drawing.Size(256, 26)
        Me.cboTipoBaston.TabIndex = 136
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "PUERTO:"
        '
        'cboPuertos
        '
        Me.cboPuertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuertos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPuertos.FormattingEnabled = True
        Me.cboPuertos.Location = New System.Drawing.Point(82, 85)
        Me.cboPuertos.Name = "cboPuertos"
        Me.cboPuertos.Size = New System.Drawing.Size(199, 26)
        Me.cboPuertos.TabIndex = 134
        '
        'pnlMSG
        '
        Me.pnlMSG.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlMSG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMSG.Controls.Add(Me.lblMSG)
        Me.pnlMSG.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.pnlMSG.Location = New System.Drawing.Point(12, 12)
        Me.pnlMSG.Name = "pnlMSG"
        Me.pnlMSG.Size = New System.Drawing.Size(326, 34)
        Me.pnlMSG.TabIndex = 133
        '
        'lblMSG
        '
        Me.lblMSG.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMSG.Location = New System.Drawing.Point(3, 6)
        Me.lblMSG.Name = "lblMSG"
        Me.lblMSG.Size = New System.Drawing.Size(304, 23)
        Me.lblMSG.TabIndex = 118
        Me.lblMSG.Text = "SELECCIONE PUERTO Y BASTON"
        Me.lblMSG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lvALARMAS
        '
        Me.lvALARMAS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader17, Me.columnHeader18, Me.columnHeader19})
        Me.lvALARMAS.FullRowSelect = True
        Me.lvALARMAS.GridLines = True
        Me.lvALARMAS.Location = New System.Drawing.Point(12, 150)
        Me.lvALARMAS.MultiSelect = False
        Me.lvALARMAS.Name = "lvALARMAS"
        Me.lvALARMAS.ShowGroups = False
        Me.lvALARMAS.Size = New System.Drawing.Size(326, 352)
        Me.lvALARMAS.TabIndex = 138
        Me.lvALARMAS.UseCompatibleStateImageBehavior = False
        Me.lvALARMAS.View = System.Windows.Forms.View.Details
        '
        'columnHeader17
        '
        Me.columnHeader17.Text = "N°"
        Me.columnHeader17.Width = 40
        '
        'columnHeader18
        '
        Me.columnHeader18.Text = "DIIO"
        Me.columnHeader18.Width = 120
        '
        'columnHeader19
        '
        Me.columnHeader19.Text = "Alarma"
        Me.columnHeader19.Width = 150
        '
        'btnArchivo
        '
        Me.btnArchivo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchivo.Image = CType(resources.GetObject("btnArchivo.Image"), System.Drawing.Image)
        Me.btnArchivo.Location = New System.Drawing.Point(287, 117)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(51, 27)
        Me.btnArchivo.TabIndex = 140
        Me.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'txtArchivo
        '
        Me.txtArchivo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtArchivo.Location = New System.Drawing.Point(82, 117)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(199, 26)
        Me.txtArchivo.TabIndex = 139
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 141
        Me.Label3.Text = "ALARMA:"
        '
        'tmrLEE
        '
        Me.tmrLEE.Interval = 1000
        '
        'tmrLIMPIA
        '
        Me.tmrLIMPIA.Interval = 1000
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lblTotDiios)
        Me.pnlEstReprod.Controls.Add(Me.lblTotErrores)
        Me.pnlEstReprod.Controls.Add(Me.lblConErrores)
        Me.pnlEstReprod.Controls.Add(Me.Label4)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(12, 508)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(326, 25)
        Me.pnlEstReprod.TabIndex = 142
        '
        'lblTotDiios
        '
        Me.lblTotDiios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDiios.Location = New System.Drawing.Point(123, 2)
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
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 21)
        Me.Label4.TabIndex = 44
        Me.Label4.Text = "TOTAL ALARMAS"
        '
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesaVal)
        Me.pnlProcesa.Controls.Add(Me.lblProcesaMax)
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(57, 254)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(233, 71)
        Me.pnlProcesa.TabIndex = 143
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
        'frmAlarmas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 578)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnArchivo)
        Me.Controls.Add(Me.txtArchivo)
        Me.Controls.Add(Me.lvALARMAS)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTipoBaston)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPuertos)
        Me.Controls.Add(Me.pnlMSG)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAlarmas"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alarmas Bastón"
        Me.pnlMSG.ResumeLayout(False)
        Me.pnlEstReprod.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoBaston As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPuertos As System.Windows.Forms.ComboBox
    Friend WithEvents pnlMSG As System.Windows.Forms.Panel
    Friend WithEvents lblMSG As System.Windows.Forms.Label
    Friend WithEvents COMPort As System.IO.Ports.SerialPort
    Private WithEvents lvALARMAS As ListView
    Private WithEvents columnHeader17 As ColumnHeader
    Private WithEvents columnHeader18 As ColumnHeader
    Private WithEvents columnHeader19 As ColumnHeader
    Friend WithEvents btnArchivo As Button
    Friend WithEvents txtArchivo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents OpenFDlg As OpenFileDialog
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents tmrLEE As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents tmrLIMPIA As Timer
    Friend WithEvents pnlEstReprod As Panel
    Friend WithEvents lblTotDiios As Label
    Friend WithEvents lblTotErrores As Label
    Friend WithEvents lblConErrores As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlProcesa As Panel
    Friend WithEvents lblProcesaVal As Label
    Friend WithEvents lblProcesaMax As Label
    Friend WithEvents lblProcesa As Label
    Friend WithEvents pbProcesa As ProgressBar
End Class
