<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecuentoCSImportacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRecuentoCSImportacion))
        Me.txtArchivo = New System.Windows.Forms.TextBox()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.pnlProcesa = New System.Windows.Forms.Panel()
        Me.lblProcesa = New System.Windows.Forms.Label()
        Me.pbProcesa = New System.Windows.Forms.ProgressBar()
        Me.lvRCS_Excel = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnArchivo = New System.Windows.Forms.Button()
        Me.OpenFDlg = New System.Windows.Forms.OpenFileDialog()
        Me.cboMesAñoExcel = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlEstReprod.SuspendLayout()
        Me.pnlProcesa.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtArchivo
        '
        Me.txtArchivo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtArchivo.Location = New System.Drawing.Point(11, 50)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(997, 27)
        Me.txtArchivo.TabIndex = 103
        Me.txtArchivo.Text = "[ SELECCIONE ARCHIVO A IMPORTAR ]"
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.Label1)
        Me.pnlEstReprod.Controls.Add(Me.Label2)
        Me.pnlEstReprod.Controls.Add(Me.Label34)
        Me.pnlEstReprod.Controls.Add(Me.Label47)
        Me.pnlEstReprod.Controls.Add(Me.Label48)
        Me.pnlEstReprod.Controls.Add(Me.Label51)
        Me.pnlEstReprod.Controls.Add(Me.Label85)
        Me.pnlEstReprod.Controls.Add(Me.Label86)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(11, 453)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1090, 25)
        Me.pnlEstReprod.TabIndex = 102
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(911, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "0"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(846, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 21)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "ERRORES"
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(595, 2)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(55, 21)
        Me.Label34.TabIndex = 43
        Me.Label34.Text = "0"
        '
        'Label47
        '
        Me.Label47.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(547, 2)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(48, 21)
        Me.Label47.TabIndex = 42
        Me.Label47.Text = "SECAS"
        '
        'Label48
        '
        Me.Label48.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(324, 2)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(55, 21)
        Me.Label48.TabIndex = 41
        Me.Label48.Text = "0"
        '
        'Label51
        '
        Me.Label51.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(247, 2)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(81, 21)
        Me.Label51.TabIndex = 40
        Me.Label51.Text = "PREÑADAS"
        '
        'Label85
        '
        Me.Label85.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.Location = New System.Drawing.Point(82, 2)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(87, 21)
        Me.Label85.TabIndex = 1
        Me.Label85.Text = "0"
        '
        'Label86
        '
        Me.Label86.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(4, 2)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(82, 21)
        Me.Label86.TabIndex = 0
        Me.Label86.Text = "REGISTROS"
        '
        'btnProcesar
        '
        Me.btnProcesar.Enabled = False
        Me.btnProcesar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Image = CType(resources.GetObject("btnProcesar.Image"), System.Drawing.Image)
        Me.btnProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProcesar.Location = New System.Drawing.Point(11, 484)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(87, 30)
        Me.btnProcesar.TabIndex = 101
        Me.btnProcesar.Text = "    Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(104, 484)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(87, 30)
        Me.Button6.TabIndex = 100
        Me.Button6.Text = "    Imprime"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'pnlProcesa
        '
        Me.pnlProcesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProcesa.Controls.Add(Me.lblProcesa)
        Me.pnlProcesa.Controls.Add(Me.pbProcesa)
        Me.pnlProcesa.Location = New System.Drawing.Point(239, 182)
        Me.pnlProcesa.Name = "pnlProcesa"
        Me.pnlProcesa.Size = New System.Drawing.Size(655, 53)
        Me.pnlProcesa.TabIndex = 98
        Me.pnlProcesa.Visible = False
        '
        'lblProcesa
        '
        Me.lblProcesa.AutoSize = True
        Me.lblProcesa.Location = New System.Drawing.Point(9, 9)
        Me.lblProcesa.Name = "lblProcesa"
        Me.lblProcesa.Size = New System.Drawing.Size(131, 13)
        Me.lblProcesa.TabIndex = 69
        Me.lblProcesa.Text = "Importando Resultados....."
        '
        'pbProcesa
        '
        Me.pbProcesa.Location = New System.Drawing.Point(12, 23)
        Me.pbProcesa.Name = "pbProcesa"
        Me.pbProcesa.Size = New System.Drawing.Size(625, 18)
        Me.pbProcesa.TabIndex = 68
        '
        'lvRCS_Excel
        '
        Me.lvRCS_Excel.AutoArrange = False
        Me.lvRCS_Excel.BackColor = System.Drawing.SystemColors.Window
        Me.lvRCS_Excel.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader0, Me.ColumnHeader7, Me.ColumnHeader1, Me.ColumnHeader10, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader13, Me.ColumnHeader4, Me.ColumnHeader11, Me.ColumnHeader14, Me.ColumnHeader12, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader5, Me.ColumnHeader15})
        Me.lvRCS_Excel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvRCS_Excel.FullRowSelect = True
        Me.lvRCS_Excel.GridLines = True
        Me.lvRCS_Excel.HideSelection = False
        Me.lvRCS_Excel.Location = New System.Drawing.Point(11, 108)
        Me.lvRCS_Excel.MultiSelect = False
        Me.lvRCS_Excel.Name = "lvRCS_Excel"
        Me.lvRCS_Excel.Size = New System.Drawing.Size(1089, 309)
        Me.lvRCS_Excel.TabIndex = 97
        Me.lvRCS_Excel.UseCompatibleStateImageBehavior = False
        Me.lvRCS_Excel.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Ordena"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = "Nro"
        Me.ColumnHeader0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader0.Width = 40
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "CodEmpresa"
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Empresa"
        Me.ColumnHeader1.Width = 119
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "CodCentro"
        Me.ColumnHeader10.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Centro"
        Me.ColumnHeader2.Width = 144
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fecha"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "CodVeterinario"
        Me.ColumnHeader13.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Veterinario"
        Me.ColumnHeader4.Width = 142
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Diio"
        Me.ColumnHeader11.Width = 80
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "CodCondicion"
        Me.ColumnHeader14.Width = 0
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Condición"
        Me.ColumnHeader12.Width = 95
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Resultado"
        Me.ColumnHeader8.Width = 72
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Categoria"
        Me.ColumnHeader9.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Validación"
        Me.ColumnHeader5.Width = 130
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Graba"
        Me.ColumnHeader15.Width = 80
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1127, 41)
        Me.Panel1.TabIndex = 99
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1059, 29)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Importación Recuento Celulas Somaticas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1014, 484)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 104
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnArchivo
        '
        Me.btnArchivo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchivo.Image = CType(resources.GetObject("btnArchivo.Image"), System.Drawing.Image)
        Me.btnArchivo.Location = New System.Drawing.Point(1014, 47)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(87, 30)
        Me.btnArchivo.TabIndex = 105
        Me.btnArchivo.Text = "Archivo"
        Me.btnArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnArchivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'OpenFDlg
        '
        Me.OpenFDlg.FileName = "OpenFDlg"
        '
        'cboMesAñoExcel
        '
        Me.cboMesAñoExcel.FormattingEnabled = True
        Me.cboMesAñoExcel.Items.AddRange(New Object() {"ABRIL 2012", "MARZO 2012", "FEBRERO 2012", "ENERO 2012"})
        Me.cboMesAñoExcel.Location = New System.Drawing.Point(11, 84)
        Me.cboMesAñoExcel.Name = "cboMesAñoExcel"
        Me.cboMesAñoExcel.Size = New System.Drawing.Size(121, 21)
        Me.cboMesAñoExcel.TabIndex = 106
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(138, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 18)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Mes del Archivo"
        '
        'FrmRecuentoCSImportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1127, 519)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboMesAñoExcel)
        Me.Controls.Add(Me.btnArchivo)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtArchivo)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnProcesar)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.pnlProcesa)
        Me.Controls.Add(Me.lvRCS_Excel)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmRecuentoCSImportacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importación Recuento Celulas Somaticas"
        Me.pnlEstReprod.ResumeLayout(False)
        Me.pnlProcesa.ResumeLayout(False)
        Me.pnlProcesa.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents pnlEstReprod As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents pnlProcesa As System.Windows.Forms.Panel
    Friend WithEvents lblProcesa As System.Windows.Forms.Label
    Friend WithEvents pbProcesa As System.Windows.Forms.ProgressBar
    Friend WithEvents lvRCS_Excel As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnArchivo As System.Windows.Forms.Button
    Friend WithEvents OpenFDlg As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cboMesAñoExcel As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
