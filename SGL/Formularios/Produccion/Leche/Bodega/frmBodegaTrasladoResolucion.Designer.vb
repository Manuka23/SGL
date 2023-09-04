<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBodegaTrasladoResolucion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBodegaTrasladoResolucion))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grpResolucion = New System.Windows.Forms.GroupBox()
        Me.btnRechazar = New System.Windows.Forms.Button()
        Me.btnConfirma = New System.Windows.Forms.Button()
        Me.grpObs = New System.Windows.Forms.GroupBox()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.lblInvId = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lvItemsTraslado = New System.Windows.Forms.ListView()
        Me.NroCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemCodCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemNomCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CantCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.UMCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ClaseCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemPrcUnitCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemPrcTotCol = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ItemNumReq = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.grpResolucion.SuspendLayout()
        Me.grpObs.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Panel1.Controls.Add(Me.lblTitulo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(897, 65)
        Me.Panel1.TabIndex = 0
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(4, 0)
        Me.lblTitulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(877, 50)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Bodega - Datos del Traslado"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grpResolucion)
        Me.Panel2.Controls.Add(Me.grpObs)
        Me.Panel2.Controls.Add(Me.lblInvId)
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 397)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(897, 79)
        Me.Panel2.TabIndex = 212
        '
        'grpResolucion
        '
        Me.grpResolucion.Controls.Add(Me.btnRechazar)
        Me.grpResolucion.Controls.Add(Me.btnConfirma)
        Me.grpResolucion.Location = New System.Drawing.Point(4, 5)
        Me.grpResolucion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpResolucion.Name = "grpResolucion"
        Me.grpResolucion.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpResolucion.Size = New System.Drawing.Size(281, 69)
        Me.grpResolucion.TabIndex = 223
        Me.grpResolucion.TabStop = False
        Me.grpResolucion.Text = "Resolución"
        '
        'btnRechazar
        '
        Me.btnRechazar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRechazar.Image = CType(resources.GetObject("btnRechazar.Image"), System.Drawing.Image)
        Me.btnRechazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRechazar.Location = New System.Drawing.Point(144, 23)
        Me.btnRechazar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRechazar.Name = "btnRechazar"
        Me.btnRechazar.Size = New System.Drawing.Size(124, 37)
        Me.btnRechazar.TabIndex = 221
        Me.btnRechazar.Text = "Rechazar"
        Me.btnRechazar.UseVisualStyleBackColor = True
        '
        'btnConfirma
        '
        Me.btnConfirma.Enabled = False
        Me.btnConfirma.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirma.Image = CType(resources.GetObject("btnConfirma.Image"), System.Drawing.Image)
        Me.btnConfirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirma.Location = New System.Drawing.Point(5, 23)
        Me.btnConfirma.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConfirma.Name = "btnConfirma"
        Me.btnConfirma.Size = New System.Drawing.Size(125, 37)
        Me.btnConfirma.TabIndex = 220
        Me.btnConfirma.Text = "Aceptar"
        Me.btnConfirma.UseVisualStyleBackColor = True
        '
        'grpObs
        '
        Me.grpObs.Controls.Add(Me.txtObs)
        Me.grpObs.Location = New System.Drawing.Point(293, 7)
        Me.grpObs.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpObs.Name = "grpObs"
        Me.grpObs.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpObs.Size = New System.Drawing.Size(447, 66)
        Me.grpObs.TabIndex = 222
        Me.grpObs.TabStop = False
        Me.grpObs.Text = "Observación"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(8, 21)
        Me.txtObs.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtObs.MaxLength = 50
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(429, 22)
        Me.txtObs.TabIndex = 222
        '
        'lblInvId
        '
        Me.lblInvId.AutoSize = True
        Me.lblInvId.Font = New System.Drawing.Font("Calibri", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInvId.Location = New System.Drawing.Point(841, 60)
        Me.lblInvId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInvId.Name = "lblInvId"
        Me.lblInvId.Size = New System.Drawing.Size(39, 14)
        Me.lblInvId.TabIndex = 220
        Me.lblInvId.Text = "Label1"
        Me.lblInvId.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(765, 20)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 37)
        Me.btnSalir.TabIndex = 217
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lvItemsTraslado
        '
        Me.lvItemsTraslado.AutoArrange = False
        Me.lvItemsTraslado.BackColor = System.Drawing.SystemColors.Window
        Me.lvItemsTraslado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NroCol, Me.ItemCodCol, Me.ItemNomCol, Me.CantCol, Me.UMCol, Me.ClaseCol, Me.ItemPrcUnitCol, Me.ItemPrcTotCol, Me.ItemNumReq})
        Me.lvItemsTraslado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvItemsTraslado.FullRowSelect = True
        Me.lvItemsTraslado.GridLines = True
        Me.lvItemsTraslado.HideSelection = False
        Me.lvItemsTraslado.Location = New System.Drawing.Point(0, 65)
        Me.lvItemsTraslado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvItemsTraslado.MultiSelect = False
        Me.lvItemsTraslado.Name = "lvItemsTraslado"
        Me.lvItemsTraslado.Size = New System.Drawing.Size(897, 332)
        Me.lvItemsTraslado.TabIndex = 213
        Me.lvItemsTraslado.UseCompatibleStateImageBehavior = False
        Me.lvItemsTraslado.View = System.Windows.Forms.View.Details
        '
        'NroCol
        '
        Me.NroCol.Text = "Nro"
        Me.NroCol.Width = 45
        '
        'ItemCodCol
        '
        Me.ItemCodCol.Text = "Codigo Prod."
        Me.ItemCodCol.Width = 0
        '
        'ItemNomCol
        '
        Me.ItemNomCol.Text = "Producto"
        Me.ItemNomCol.Width = 360
        '
        'CantCol
        '
        Me.CantCol.Text = "Cant"
        Me.CantCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CantCol.Width = 70
        '
        'UMCol
        '
        Me.UMCol.Text = "Unid. Med."
        Me.UMCol.Width = 0
        '
        'ClaseCol
        '
        Me.ClaseCol.Text = "Clase"
        Me.ClaseCol.Width = 100
        '
        'ItemPrcUnitCol
        '
        Me.ItemPrcUnitCol.Text = "Prc. Unit"
        Me.ItemPrcUnitCol.Width = 0
        '
        'ItemPrcTotCol
        '
        Me.ItemPrcTotCol.Text = "Prc. Tot."
        Me.ItemPrcTotCol.Width = 0
        '
        'ItemNumReq
        '
        Me.ItemNumReq.Text = "N° Requerimiento"
        Me.ItemNumReq.Width = 125
        '
        'frmBodegaTrasladoResolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 476)
        Me.Controls.Add(Me.lvItemsTraslado)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBodegaTrasladoResolucion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bodega - Resolución de Traslado"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.grpResolucion.ResumeLayout(False)
        Me.grpObs.ResumeLayout(False)
        Me.grpObs.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lvItemsTraslado As ListView
    Friend WithEvents NroCol As ColumnHeader
    Friend WithEvents ItemCodCol As ColumnHeader
    Friend WithEvents ItemNomCol As ColumnHeader
    Friend WithEvents CantCol As ColumnHeader
    Friend WithEvents UMCol As ColumnHeader
    Friend WithEvents ClaseCol As ColumnHeader
    Friend WithEvents ItemPrcUnitCol As ColumnHeader
    Friend WithEvents ItemPrcTotCol As ColumnHeader
    Friend WithEvents lblInvId As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents grpObs As GroupBox
    Friend WithEvents txtObs As TextBox
    Friend WithEvents grpResolucion As GroupBox
    Friend WithEvents btnRechazar As Button
    Friend WithEvents btnConfirma As Button
    Friend WithEvents ItemNumReq As ColumnHeader
End Class
