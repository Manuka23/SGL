﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminDiiosAsignacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdminDiiosAsignacion))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboTiposFallas = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTiposAsign = New System.Windows.Forms.ComboBox()
        Me.cboResponsables = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCentros = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDiioAntiguo = New System.Windows.Forms.TextBox()
        Me.txtObservs = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDiioNuevo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboTiposFallas)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboTiposAsign)
        Me.GroupBox1.Controls.Add(Me.cboResponsables)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboCentros)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDiioAntiguo)
        Me.GroupBox1.Controls.Add(Me.txtObservs)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtDiioNuevo)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 265)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        '
        'cboTiposFallas
        '
        Me.cboTiposFallas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTiposFallas.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTiposFallas.FormattingEnabled = True
        Me.cboTiposFallas.Location = New System.Drawing.Point(456, 100)
        Me.cboTiposFallas.Name = "cboTiposFallas"
        Me.cboTiposFallas.Size = New System.Drawing.Size(167, 26)
        Me.cboTiposFallas.TabIndex = 107
        Me.cboTiposFallas.Visible = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(369, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 19)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Tipo Falla"
        Me.Label4.Visible = False
        '
        'cboTiposAsign
        '
        Me.cboTiposAsign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTiposAsign.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTiposAsign.FormattingEnabled = True
        Me.cboTiposAsign.Location = New System.Drawing.Point(119, 100)
        Me.cboTiposAsign.Name = "cboTiposAsign"
        Me.cboTiposAsign.Size = New System.Drawing.Size(167, 26)
        Me.cboTiposAsign.TabIndex = 105
        '
        'cboResponsables
        '
        Me.cboResponsables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResponsables.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboResponsables.FormattingEnabled = True
        Me.cboResponsables.Location = New System.Drawing.Point(119, 60)
        Me.cboResponsables.Name = "cboResponsables"
        Me.cboResponsables.Size = New System.Drawing.Size(282, 26)
        Me.cboResponsables.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 19)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Responsable"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 19)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Tipo Asignación"
        '
        'cboCentros
        '
        Me.cboCentros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCentros.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCentros.FormattingEnabled = True
        Me.cboCentros.Location = New System.Drawing.Point(119, 21)
        Me.cboCentros.Name = "cboCentros"
        Me.cboCentros.Size = New System.Drawing.Size(282, 26)
        Me.cboCentros.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(415, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 23)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "Fecha Asignación"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(536, 21)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(87, 26)
        Me.dtpFecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 19)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Centro"
        '
        'txtDiioAntiguo
        '
        Me.txtDiioAntiguo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiioAntiguo.Location = New System.Drawing.Point(456, 140)
        Me.txtDiioAntiguo.MaxLength = 20
        Me.txtDiioAntiguo.Name = "txtDiioAntiguo"
        Me.txtDiioAntiguo.Size = New System.Drawing.Size(90, 26)
        Me.txtDiioAntiguo.TabIndex = 2
        Me.txtDiioAntiguo.Visible = False
        '
        'txtObservs
        '
        Me.txtObservs.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservs.Location = New System.Drawing.Point(119, 181)
        Me.txtObservs.MaxLength = 500
        Me.txtObservs.Multiline = True
        Me.txtObservs.Name = "txtObservs"
        Me.txtObservs.Size = New System.Drawing.Size(504, 68)
        Me.txtObservs.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(11, 143)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(77, 23)
        Me.Label16.TabIndex = 96
        Me.Label16.Text = "Diio Nuevo"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(11, 184)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 23)
        Me.Label17.TabIndex = 98
        Me.Label17.Text = "Observaciones"
        '
        'txtDiioNuevo
        '
        Me.txtDiioNuevo.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiioNuevo.Location = New System.Drawing.Point(119, 140)
        Me.txtDiioNuevo.MaxLength = 20
        Me.txtDiioNuevo.Name = "txtDiioNuevo"
        Me.txtDiioNuevo.Size = New System.Drawing.Size(90, 26)
        Me.txtDiioNuevo.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(369, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 23)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "Diio Antiguo"
        Me.Label11.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(562, 283)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 105
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(12, 283)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(87, 30)
        Me.btnGrabar.TabIndex = 104
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'frmAdminDiiosAsignacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 322)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGrabar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmAdminDiiosAsignacion"
        Me.Text = "Asignación de Diios"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboResponsables As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCentros As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDiioAntiguo As System.Windows.Forms.TextBox
    Friend WithEvents txtObservs As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtDiioNuevo As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents cboTiposAsign As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTiposFallas As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
