<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeerDispositivoV3
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeerDispositivoV3))
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lblRepetidos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotDiios = New System.Windows.Forms.Label()
        Me.lblTotErrores = New System.Windows.Forms.Label()
        Me.lblConErrores = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnGallaguerHR4 = New System.Windows.Forms.Button()
        Me.btnTruTestXRS = New System.Windows.Forms.Button()
        Me.btnAllflexXR320 = New System.Windows.Forms.Button()
        Me.btnSesionesSGL = New System.Windows.Forms.Button()
        Me.cboPuertos = New System.Windows.Forms.ComboBox()
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
        Me.btnEliminaRepetidos = New System.Windows.Forms.Button()
        Me.btnBastonLimpia = New System.Windows.Forms.Button()
        Me.btnBastonLee = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.COMPort = New System.IO.Ports.SerialPort(Me.components)
        Me.pnlEstReprod.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.pnlEstReprod.Location = New System.Drawing.Point(7, 457)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(435, 25)
        Me.pnlEstReprod.TabIndex = 128
        '
        'lblRepetidos
        '
        Me.lblRepetidos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepetidos.Location = New System.Drawing.Point(298, 2)
        Me.lblRepetidos.Name = "lblRepetidos"
        Me.lblRepetidos.Size = New System.Drawing.Size(48, 21)
        Me.lblRepetidos.TabIndex = 49
        Me.lblRepetidos.Text = "0"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(220, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 21)
        Me.Label6.TabIndex = 50
        Me.Label6.Text = "REPETIDOS"
        '
        'lblTotDiios
        '
        Me.lblTotDiios.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotDiios.Location = New System.Drawing.Point(93, 2)
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
        Me.Label3.Location = New System.Drawing.Point(10, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 21)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "TOTAL DIIOs"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(355, 487)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 127
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnExcel)
        Me.Panel1.Controls.Add(Me.btnGallaguerHR4)
        Me.Panel1.Controls.Add(Me.btnTruTestXRS)
        Me.Panel1.Controls.Add(Me.btnAllflexXR320)
        Me.Panel1.Controls.Add(Me.btnSesionesSGL)
        Me.Panel1.Location = New System.Drawing.Point(7, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(111, 411)
        Me.Panel1.TabIndex = 129
        '
        'btnExcel
        '
        Me.btnExcel.Enabled = False
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcel.Location = New System.Drawing.Point(3, 327)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(100, 75)
        Me.btnExcel.TabIndex = 134
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnGallaguerHR4
        '
        Me.btnGallaguerHR4.Font = New System.Drawing.Font("Calibri", 8.2!)
        Me.btnGallaguerHR4.Image = CType(resources.GetObject("btnGallaguerHR4.Image"), System.Drawing.Image)
        Me.btnGallaguerHR4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnGallaguerHR4.Location = New System.Drawing.Point(3, 246)
        Me.btnGallaguerHR4.Name = "btnGallaguerHR4"
        Me.btnGallaguerHR4.Size = New System.Drawing.Size(100, 75)
        Me.btnGallaguerHR4.TabIndex = 133
        Me.btnGallaguerHR4.Text = "Gallagher HR4-5"
        Me.btnGallaguerHR4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGallaguerHR4.UseVisualStyleBackColor = True
        '
        'btnTruTestXRS
        '
        Me.btnTruTestXRS.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTruTestXRS.Image = CType(resources.GetObject("btnTruTestXRS.Image"), System.Drawing.Image)
        Me.btnTruTestXRS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTruTestXRS.Location = New System.Drawing.Point(3, 165)
        Me.btnTruTestXRS.Name = "btnTruTestXRS"
        Me.btnTruTestXRS.Size = New System.Drawing.Size(100, 75)
        Me.btnTruTestXRS.TabIndex = 132
        Me.btnTruTestXRS.Text = "Tru-Test XRS"
        Me.btnTruTestXRS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTruTestXRS.UseVisualStyleBackColor = True
        '
        'btnAllflexXR320
        '
        Me.btnAllflexXR320.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllflexXR320.Image = CType(resources.GetObject("btnAllflexXR320.Image"), System.Drawing.Image)
        Me.btnAllflexXR320.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAllflexXR320.Location = New System.Drawing.Point(3, 84)
        Me.btnAllflexXR320.Name = "btnAllflexXR320"
        Me.btnAllflexXR320.Size = New System.Drawing.Size(100, 75)
        Me.btnAllflexXR320.TabIndex = 131
        Me.btnAllflexXR320.Text = "Allflex XR320"
        Me.btnAllflexXR320.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAllflexXR320.UseVisualStyleBackColor = True
        '
        'btnSesionesSGL
        '
        Me.btnSesionesSGL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSesionesSGL.Image = CType(resources.GetObject("btnSesionesSGL.Image"), System.Drawing.Image)
        Me.btnSesionesSGL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSesionesSGL.Location = New System.Drawing.Point(3, 3)
        Me.btnSesionesSGL.Name = "btnSesionesSGL"
        Me.btnSesionesSGL.Size = New System.Drawing.Size(100, 75)
        Me.btnSesionesSGL.TabIndex = 130
        Me.btnSesionesSGL.Text = "Sesiones SGL"
        Me.btnSesionesSGL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSesionesSGL.UseVisualStyleBackColor = True
        '
        'cboPuertos
        '
        Me.cboPuertos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPuertos.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPuertos.FormattingEnabled = True
        Me.cboPuertos.Location = New System.Drawing.Point(7, 425)
        Me.cboPuertos.Name = "cboPuertos"
        Me.cboPuertos.Size = New System.Drawing.Size(111, 26)
        Me.cboPuertos.TabIndex = 130
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
        Me.lvXRS_SESIONES.Location = New System.Drawing.Point(130, 8)
        Me.lvXRS_SESIONES.Name = "lvXRS_SESIONES"
        Me.lvXRS_SESIONES.Size = New System.Drawing.Size(312, 139)
        Me.lvXRS_SESIONES.TabIndex = 131
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
        Me.lvXRS_DETALLE.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader13})
        Me.lvXRS_DETALLE.FullRowSelect = True
        Me.lvXRS_DETALLE.GridLines = True
        Me.lvXRS_DETALLE.HideSelection = False
        Me.lvXRS_DETALLE.Location = New System.Drawing.Point(130, 153)
        Me.lvXRS_DETALLE.Name = "lvXRS_DETALLE"
        Me.lvXRS_DETALLE.Size = New System.Drawing.Size(312, 298)
        Me.lvXRS_DETALLE.TabIndex = 132
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
        'btnEliminaRepetidos
        '
        Me.btnEliminaRepetidos.Enabled = False
        Me.btnEliminaRepetidos.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminaRepetidos.Image = CType(resources.GetObject("btnEliminaRepetidos.Image"), System.Drawing.Image)
        Me.btnEliminaRepetidos.Location = New System.Drawing.Point(95, 487)
        Me.btnEliminaRepetidos.Name = "btnEliminaRepetidos"
        Me.btnEliminaRepetidos.Size = New System.Drawing.Size(38, 30)
        Me.btnEliminaRepetidos.TabIndex = 137
        Me.btnEliminaRepetidos.UseVisualStyleBackColor = True
        '
        'btnBastonLimpia
        '
        Me.btnBastonLimpia.Enabled = False
        Me.btnBastonLimpia.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLimpia.Image = CType(resources.GetObject("btnBastonLimpia.Image"), System.Drawing.Image)
        Me.btnBastonLimpia.Location = New System.Drawing.Point(51, 487)
        Me.btnBastonLimpia.Name = "btnBastonLimpia"
        Me.btnBastonLimpia.Size = New System.Drawing.Size(38, 30)
        Me.btnBastonLimpia.TabIndex = 136
        Me.btnBastonLimpia.UseVisualStyleBackColor = True
        '
        'btnBastonLee
        '
        Me.btnBastonLee.Enabled = False
        Me.btnBastonLee.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBastonLee.Image = CType(resources.GetObject("btnBastonLee.Image"), System.Drawing.Image)
        Me.btnBastonLee.Location = New System.Drawing.Point(7, 487)
        Me.btnBastonLee.Name = "btnBastonLee"
        Me.btnBastonLee.Size = New System.Drawing.Size(38, 30)
        Me.btnBastonLee.TabIndex = 135
        Me.btnBastonLee.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Enabled = False
        Me.btnProcesar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.Location = New System.Drawing.Point(262, 487)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(87, 30)
        Me.btnProcesar.TabIndex = 134
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'frmLeerDispositivoV3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(451, 523)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminaRepetidos)
        Me.Controls.Add(Me.btnBastonLimpia)
        Me.Controls.Add(Me.btnBastonLee)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.lvXRS_DETALLE)
        Me.Controls.Add(Me.lvXRS_SESIONES)
        Me.Controls.Add(Me.cboPuertos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLeerDispositivoV3"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lectura de Dispositivo"
        Me.pnlEstReprod.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents lblRepetidos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotDiios As System.Windows.Forms.Label
    Friend WithEvents lblTotErrores As System.Windows.Forms.Label
    Friend WithEvents lblConErrores As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnGallaguerHR4 As System.Windows.Forms.Button
    Friend WithEvents btnTruTestXRS As System.Windows.Forms.Button
    Friend WithEvents btnAllflexXR320 As System.Windows.Forms.Button
    Friend WithEvents btnSesionesSGL As System.Windows.Forms.Button
    Friend WithEvents cboPuertos As System.Windows.Forms.ComboBox
    Friend WithEvents lvXRS_SESIONES As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvXRS_DETALLE As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnEliminaRepetidos As System.Windows.Forms.Button
    Friend WithEvents btnBastonLimpia As System.Windows.Forms.Button
    Friend WithEvents btnBastonLee As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents COMPort As System.IO.Ports.SerialPort
End Class
