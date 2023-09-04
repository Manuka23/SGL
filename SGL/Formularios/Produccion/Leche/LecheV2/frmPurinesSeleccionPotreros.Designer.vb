<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurinesSeleccionPotreros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurinesSeleccionPotreros))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "", "", "", "", "", ""}, -1)
        Me.WebBrowser = New System.Windows.Forms.WebBrowser()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.lvPOTREROS = New System.Windows.Forms.ListView()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grpCentro = New System.Windows.Forms.GroupBox()
        Me.txtCentro = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblErrNomArchivo = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboNombres = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboTiposRiego = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboRealizadoPor = New System.Windows.Forms.ComboBox()
        Me.grpFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.grpCentro.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.grpFecha.SuspendLayout()
        Me.SuspendLayout()
        '
        'WebBrowser
        '
        Me.WebBrowser.Location = New System.Drawing.Point(152, 83)
        Me.WebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser.Name = "WebBrowser"
        Me.WebBrowser.Size = New System.Drawing.Size(547, 366)
        Me.WebBrowser.TabIndex = 3
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1014, 594)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 212
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionar.Image = CType(resources.GetObject("btnSeleccionar.Image"), System.Drawing.Image)
        Me.btnSeleccionar.Location = New System.Drawing.Point(9, 594)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(102, 30)
        Me.btnSeleccionar.TabIndex = 211
        Me.btnSeleccionar.Text = "Confirmar"
        Me.btnSeleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'lvPOTREROS
        '
        Me.lvPOTREROS.AutoArrange = False
        Me.lvPOTREROS.BackColor = System.Drawing.SystemColors.Window
        Me.lvPOTREROS.CheckBoxes = True
        Me.lvPOTREROS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader0, Me.ColumnHeader1, Me.ColumnHeader5})
        Me.lvPOTREROS.FullRowSelect = True
        Me.lvPOTREROS.GridLines = True
        Me.lvPOTREROS.HideSelection = False
        ListViewItem1.StateImageIndex = 0
        Me.lvPOTREROS.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
        Me.lvPOTREROS.Location = New System.Drawing.Point(9, 65)
        Me.lvPOTREROS.MultiSelect = False
        Me.lvPOTREROS.Name = "lvPOTREROS"
        Me.lvPOTREROS.Size = New System.Drawing.Size(226, 523)
        Me.lvPOTREROS.TabIndex = 200
        Me.lvPOTREROS.UseCompatibleStateImageBehavior = False
        Me.lvPOTREROS.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.Text = ""
        Me.ColumnHeader0.Width = 25
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Potrero"
        Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Hectareas"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 100
        '
        'grpCentro
        '
        Me.grpCentro.Controls.Add(Me.txtCentro)
        Me.grpCentro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpCentro.Location = New System.Drawing.Point(9, 3)
        Me.grpCentro.Name = "grpCentro"
        Me.grpCentro.Size = New System.Drawing.Size(226, 54)
        Me.grpCentro.TabIndex = 213
        Me.grpCentro.TabStop = False
        Me.grpCentro.Text = "Centro"
        '
        'txtCentro
        '
        Me.txtCentro.Enabled = False
        Me.txtCentro.Location = New System.Drawing.Point(10, 21)
        Me.txtCentro.Name = "txtCentro"
        Me.txtCentro.Size = New System.Drawing.Size(203, 22)
        Me.txtCentro.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblErrNomArchivo)
        Me.Panel1.Controls.Add(Me.WebBrowser)
        Me.Panel1.Location = New System.Drawing.Point(241, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(860, 523)
        Me.Panel1.TabIndex = 214
        '
        'lblErrNomArchivo
        '
        Me.lblErrNomArchivo.BackColor = System.Drawing.Color.Transparent
        Me.lblErrNomArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrNomArchivo.Location = New System.Drawing.Point(3, 240)
        Me.lblErrNomArchivo.Name = "lblErrNomArchivo"
        Me.lblErrNomArchivo.Size = New System.Drawing.Size(852, 42)
        Me.lblErrNomArchivo.TabIndex = 4
        Me.lblErrNomArchivo.Text = "NO SE ENCUENTRA EL MAPA PARA EL PREDIO SELECCIONADO"
        Me.lblErrNomArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblErrNomArchivo.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboNombres)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(504, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 54)
        Me.GroupBox1.TabIndex = 215
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nombre"
        '
        'cboNombres
        '
        Me.cboNombres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNombres.FormattingEnabled = True
        Me.cboNombres.Location = New System.Drawing.Point(12, 19)
        Me.cboNombres.Name = "cboNombres"
        Me.cboNombres.Size = New System.Drawing.Size(394, 22)
        Me.cboNombres.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboTiposRiego)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(929, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(172, 54)
        Me.GroupBox2.TabIndex = 216
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tipo de Riego"
        '
        'cboTiposRiego
        '
        Me.cboTiposRiego.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTiposRiego.FormattingEnabled = True
        Me.cboTiposRiego.Items.AddRange(New Object() {"ASPERCIÓN O TUBO (Hr)", "CARRO (Lts)"})
        Me.cboTiposRiego.Location = New System.Drawing.Point(14, 18)
        Me.cboTiposRiego.Name = "cboTiposRiego"
        Me.cboTiposRiego.Size = New System.Drawing.Size(146, 22)
        Me.cboTiposRiego.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboRealizadoPor)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(348, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(150, 54)
        Me.GroupBox3.TabIndex = 217
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Realizado Por"
        '
        'cboRealizadoPor
        '
        Me.cboRealizadoPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRealizadoPor.FormattingEnabled = True
        Me.cboRealizadoPor.Items.AddRange(New Object() {"INTERNO", "CONTRATISTA", "SIN RIEGO"})
        Me.cboRealizadoPor.Location = New System.Drawing.Point(9, 19)
        Me.cboRealizadoPor.Name = "cboRealizadoPor"
        Me.cboRealizadoPor.Size = New System.Drawing.Size(128, 22)
        Me.cboRealizadoPor.TabIndex = 1
        '
        'grpFecha
        '
        Me.grpFecha.Controls.Add(Me.dtpFecha)
        Me.grpFecha.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFecha.Location = New System.Drawing.Point(241, 3)
        Me.grpFecha.Name = "grpFecha"
        Me.grpFecha.Size = New System.Drawing.Size(101, 54)
        Me.grpFecha.TabIndex = 218
        Me.grpFecha.TabStop = False
        Me.grpFecha.Text = "Fecha"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(10, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(79, 22)
        Me.dtpFecha.TabIndex = 1
        Me.dtpFecha.Value = New Date(2012, 10, 1, 0, 0, 0, 0)
        '
        'frmPurinesSeleccionPotreros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 632)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpFecha)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grpCentro)
        Me.Controls.Add(Me.lvPOTREROS)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPurinesSeleccionPotreros"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Riego de Purines - Selección de Potreros"
        Me.grpCentro.ResumeLayout(False)
        Me.grpCentro.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.grpFecha.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents lvPOTREROS As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents grpCentro As System.Windows.Forms.GroupBox
    Friend WithEvents txtCentro As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblErrNomArchivo As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboNombres As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboTiposRiego As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cboRealizadoPor As System.Windows.Forms.ComboBox
    Friend WithEvents grpFecha As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
End Class
