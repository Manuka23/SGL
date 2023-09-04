<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTratamientosLote
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTratamientosLote))
        Me.lvFARMACOS = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Diio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodPat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodMed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.pnlEstReprod = New System.Windows.Forms.Panel()
        Me.lbCentroCod = New System.Windows.Forms.Label()
        Me.lbCentroNom = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNLote = New System.Windows.Forms.Label()
        Me.lblLote = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnLiberarLeche = New System.Windows.Forms.Button()
        Me.btnCierreLote = New System.Windows.Forms.Button()
        Me.Estado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlEstReprod.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvFARMACOS
        '
        Me.lvFARMACOS.AutoArrange = False
        Me.lvFARMACOS.BackColor = System.Drawing.SystemColors.Window
        Me.lvFARMACOS.CheckBoxes = True
        Me.lvFARMACOS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader8, Me.Diio, Me.ColumnHeader1, Me.ColumnHeader7, Me.ColumnHeader9, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader10, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader5, Me.ColumnHeader6, Me.CodPat, Me.CodMed, Me.Estado})
        Me.lvFARMACOS.FullRowSelect = True
        Me.lvFARMACOS.GridLines = True
        Me.lvFARMACOS.HideSelection = False
        Me.lvFARMACOS.Location = New System.Drawing.Point(16, 70)
        Me.lvFARMACOS.Margin = New System.Windows.Forms.Padding(4)
        Me.lvFARMACOS.Name = "lvFARMACOS"
        Me.lvFARMACOS.Size = New System.Drawing.Size(1233, 541)
        Me.lvFARMACOS.TabIndex = 263
        Me.lvFARMACOS.UseCompatibleStateImageBehavior = False
        Me.lvFARMACOS.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "N°"
        Me.ColumnHeader4.Width = 40
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Fecha"
        Me.ColumnHeader8.Width = 80
        '
        'Diio
        '
        Me.Diio.Text = "Diio"
        Me.Diio.Width = 78
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Categoria"
        Me.ColumnHeader1.Width = 67
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Est. Productivo"
        Me.ColumnHeader7.Width = 80
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Est. Reproductivo"
        Me.ColumnHeader9.Width = 86
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Motivo Tratamiento"
        Me.ColumnHeader15.Width = 122
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "AD"
        Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader16.Width = 33
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "AI"
        Me.ColumnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader17.Width = 32
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "PD"
        Me.ColumnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader18.Width = 31
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "PI"
        Me.ColumnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader19.Width = 31
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Medicamento"
        Me.ColumnHeader20.Width = 106
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Dosis"
        Me.ColumnHeader21.Width = 94
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "AM"
        Me.ColumnHeader2.Width = 44
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "PM"
        Me.ColumnHeader3.Width = 45
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Duracion"
        Me.ColumnHeader22.Width = 107
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Retiro Ordeña"
        Me.ColumnHeader23.Width = 83
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Ingres. Ordeña"
        Me.ColumnHeader24.Width = 92
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Dias Trat."
        Me.ColumnHeader10.Width = 70
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Dias Caren, Leche"
        Me.ColumnHeader25.Width = 100
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Dias Caren. Carne"
        Me.ColumnHeader26.Width = 100
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Lib. Leche"
        Me.ColumnHeader27.Width = 100
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Lib. Carne"
        Me.ColumnHeader28.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Num"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Centro"
        Me.ColumnHeader6.Width = 0
        '
        'CodPat
        '
        Me.CodPat.Text = "Cod. Patologia"
        Me.CodPat.Width = 0
        '
        'CodMed
        '
        Me.CodMed.Text = "Cod. Medicamento"
        Me.CodMed.Width = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(148, 662)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(137, 46)
        Me.btnEliminar.TabIndex = 261
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'pnlEstReprod
        '
        Me.pnlEstReprod.BackColor = System.Drawing.SystemColors.Window
        Me.pnlEstReprod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstReprod.Controls.Add(Me.lbCentroCod)
        Me.pnlEstReprod.Controls.Add(Me.lbCentroNom)
        Me.pnlEstReprod.Controls.Add(Me.Label1)
        Me.pnlEstReprod.Controls.Add(Me.lblNLote)
        Me.pnlEstReprod.Controls.Add(Me.lblLote)
        Me.pnlEstReprod.Controls.Add(Me.Label10)
        Me.pnlEstReprod.Controls.Add(Me.Label9)
        Me.pnlEstReprod.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEstReprod.Location = New System.Drawing.Point(16, 619)
        Me.pnlEstReprod.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlEstReprod.Name = "pnlEstReprod"
        Me.pnlEstReprod.Size = New System.Drawing.Size(1233, 35)
        Me.pnlEstReprod.TabIndex = 258
        '
        'lbCentroCod
        '
        Me.lbCentroCod.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCentroCod.Location = New System.Drawing.Point(940, 2)
        Me.lbCentroCod.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCentroCod.Name = "lbCentroCod"
        Me.lbCentroCod.Size = New System.Drawing.Size(205, 31)
        Me.lbCentroCod.TabIndex = 55
        Me.lbCentroCod.Text = "0"
        Me.lbCentroCod.Visible = False
        '
        'lbCentroNom
        '
        Me.lbCentroNom.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCentroNom.Location = New System.Drawing.Point(599, 2)
        Me.lbCentroNom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbCentroNom.Name = "lbCentroNom"
        Me.lbCentroNom.Size = New System.Drawing.Size(502, 31)
        Me.lbCentroNom.TabIndex = 54
        Me.lbCentroNom.Text = "Centro"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(524, 2)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 31)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Centro :"
        '
        'lblNLote
        '
        Me.lblNLote.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNLote.Location = New System.Drawing.Point(371, 2)
        Me.lblNLote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNLote.Name = "lblNLote"
        Me.lblNLote.Size = New System.Drawing.Size(205, 31)
        Me.lblNLote.TabIndex = 52
        Me.lblNLote.Text = "0"
        '
        'lblLote
        '
        Me.lblLote.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLote.Location = New System.Drawing.Point(271, 2)
        Me.lblLote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLote.Name = "lblLote"
        Me.lblLote.Size = New System.Drawing.Size(143, 31)
        Me.lblLote.TabIndex = 51
        Me.lblLote.Text = "Nro. Lote :"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(141, 2)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(205, 31)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "0"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 2)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(143, 31)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Nro. Registros :"
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(16, 662)
        Me.btnExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(129, 46)
        Me.btnExcel.TabIndex = 257
        Me.btnExcel.Text = "A Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1128, 662)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(121, 46)
        Me.btnSalir.TabIndex = 254
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1271, 63)
        Me.Panel1.TabIndex = 252
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(33, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1217, 44)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Detalle Lote Tratamientos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(292, 662)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(133, 46)
        Me.btnModificar.TabIndex = 264
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnLiberarLeche
        '
        Me.btnLiberarLeche.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLiberarLeche.Image = CType(resources.GetObject("btnLiberarLeche.Image"), System.Drawing.Image)
        Me.btnLiberarLeche.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLiberarLeche.Location = New System.Drawing.Point(431, 661)
        Me.btnLiberarLeche.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLiberarLeche.Name = "btnLiberarLeche"
        Me.btnLiberarLeche.Size = New System.Drawing.Size(161, 46)
        Me.btnLiberarLeche.TabIndex = 265
        Me.btnLiberarLeche.Text = "Liberar Leche"
        Me.btnLiberarLeche.UseVisualStyleBackColor = True
        '
        'btnCierreLote
        '
        Me.btnCierreLote.Image = CType(resources.GetObject("btnCierreLote.Image"), System.Drawing.Image)
        Me.btnCierreLote.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCierreLote.Location = New System.Drawing.Point(597, 662)
        Me.btnCierreLote.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCierreLote.Name = "btnCierreLote"
        Me.btnCierreLote.Size = New System.Drawing.Size(192, 46)
        Me.btnCierreLote.TabIndex = 266
        Me.btnCierreLote.Text = "Cierre Seleccionados"
        Me.btnCierreLote.UseVisualStyleBackColor = True
        '
        'Estado
        '
        Me.Estado.Text = "Estado"
        '
        'frmTratamientosLote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1273, 747)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCierreLote)
        Me.Controls.Add(Me.btnLiberarLeche)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.pnlEstReprod)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lvFARMACOS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTratamientosLote"
        Me.ShowIcon = False
        Me.Text = "Detalle Lote"
        Me.pnlEstReprod.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvFARMACOS As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents Diio As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents ColumnHeader25 As ColumnHeader
    Friend WithEvents ColumnHeader26 As ColumnHeader
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents ColumnHeader28 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents btnEliminar As Button
    Friend WithEvents pnlEstReprod As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnExcel As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents btnModificar As Button
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents btnLiberarLeche As Button
    Friend WithEvents lblNLote As Label
    Friend WithEvents lblLote As Label
    Friend WithEvents CodPat As ColumnHeader
    Friend WithEvents CodMed As ColumnHeader
    Friend WithEvents btnCierreLote As Button
    Friend WithEvents lbCentroCod As Label
    Friend WithEvents lbCentroNom As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Estado As ColumnHeader
End Class
