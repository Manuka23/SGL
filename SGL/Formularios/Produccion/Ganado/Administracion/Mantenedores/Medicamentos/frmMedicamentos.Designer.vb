<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMedicamentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMedicamentos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboVigente = New System.Windows.Forms.ComboBox()
        Me.pnlTotales = New System.Windows.Forms.Panel()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.lvFARMACOS = New System.Windows.Forms.ListView()
        Me.Num = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Nombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RegSag = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiasTrat = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RegLeche = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.RegCarne = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.VacLac = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Dosis = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Duracion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Obs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Vigente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CodMed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Preventivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cboPatologias = New System.Windows.Forms.ComboBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnLimpiarFiltro = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.CodGP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlTotales.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1463, 50)
        Me.Panel1.TabIndex = 168
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(21, 5)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(1413, 36)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "MEDICAMENTOS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboVigente)
        Me.GroupBox2.Location = New System.Drawing.Point(296, 58)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(167, 62)
        Me.GroupBox2.TabIndex = 167
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vigente"
        '
        'cboVigente
        '
        Me.cboVigente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVigente.FormattingEnabled = True
        Me.cboVigente.Location = New System.Drawing.Point(12, 23)
        Me.cboVigente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboVigente.Name = "cboVigente"
        Me.cboVigente.Size = New System.Drawing.Size(140, 24)
        Me.cboVigente.TabIndex = 1
        '
        'pnlTotales
        '
        Me.pnlTotales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlTotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTotales.Controls.Add(Me.Label48)
        Me.pnlTotales.Controls.Add(Me.Label86)
        Me.pnlTotales.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTotales.Location = New System.Drawing.Point(11, 666)
        Me.pnlTotales.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlTotales.Name = "pnlTotales"
        Me.pnlTotales.Size = New System.Drawing.Size(1413, 30)
        Me.pnlTotales.TabIndex = 165
        '
        'Label48
        '
        Me.Label48.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(212, 2)
        Me.Label48.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(87, 26)
        Me.Label48.TabIndex = 41
        Me.Label48.Text = "0"
        '
        'Label86
        '
        Me.Label86.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(5, 2)
        Me.Label86.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(215, 26)
        Me.Label86.TabIndex = 0
        Me.Label86.Text = "TOTAL MEDICAMENTOS"
        '
        'lvFARMACOS
        '
        Me.lvFARMACOS.AutoArrange = False
        Me.lvFARMACOS.BackColor = System.Drawing.SystemColors.Window
        Me.lvFARMACOS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Num, Me.Nombre, Me.RegSag, Me.DiasTrat, Me.RegLeche, Me.RegCarne, Me.VacLac, Me.Dosis, Me.Duracion, Me.Obs, Me.Vigente, Me.CodMed, Me.Preventivo, Me.CodGP})
        Me.lvFARMACOS.FullRowSelect = True
        Me.lvFARMACOS.GridLines = True
        Me.lvFARMACOS.HideSelection = False
        Me.lvFARMACOS.Location = New System.Drawing.Point(11, 124)
        Me.lvFARMACOS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.lvFARMACOS.MultiSelect = False
        Me.lvFARMACOS.Name = "lvFARMACOS"
        Me.lvFARMACOS.Size = New System.Drawing.Size(1412, 533)
        Me.lvFARMACOS.TabIndex = 171
        Me.lvFARMACOS.UseCompatibleStateImageBehavior = False
        Me.lvFARMACOS.View = System.Windows.Forms.View.Details
        '
        'Num
        '
        Me.Num.Text = "Nro"
        Me.Num.Width = 40
        '
        'Nombre
        '
        Me.Nombre.Text = "Nombre"
        Me.Nombre.Width = 122
        '
        'RegSag
        '
        Me.RegSag.Text = "Reg. SAG"
        Me.RegSag.Width = 78
        '
        'DiasTrat
        '
        Me.DiasTrat.Text = "Dias Trat."
        Me.DiasTrat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DiasTrat.Width = 70
        '
        'RegLeche
        '
        Me.RegLeche.Text = "Dias Resg. Lech."
        Me.RegLeche.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RegLeche.Width = 94
        '
        'RegCarne
        '
        Me.RegCarne.Text = "Dias Resg. Car."
        Me.RegCarne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.RegCarne.Width = 88
        '
        'VacLac
        '
        Me.VacLac.Text = "Uso Vacas Lact."
        Me.VacLac.Width = 96
        '
        'Dosis
        '
        Me.Dosis.Text = "Dosis"
        Me.Dosis.Width = 149
        '
        'Duracion
        '
        Me.Duracion.Text = "Duracion"
        Me.Duracion.Width = 153
        '
        'Obs
        '
        Me.Obs.Text = "Observación"
        Me.Obs.Width = 222
        '
        'Vigente
        '
        Me.Vigente.Text = "Vigente"
        Me.Vigente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CodMed
        '
        Me.CodMed.Text = "cod medicamento"
        Me.CodMed.Width = 0
        '
        'Preventivo
        '
        Me.Preventivo.Text = "Preventivo"
        Me.Preventivo.Width = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboPatologias)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 58)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(277, 62)
        Me.GroupBox3.TabIndex = 174
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Patología"
        '
        'cboPatologias
        '
        Me.cboPatologias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPatologias.FormattingEnabled = True
        Me.cboPatologias.Location = New System.Drawing.Point(16, 23)
        Me.cboPatologias.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboPatologias.Name = "cboPatologias"
        Me.cboPatologias.Size = New System.Drawing.Size(241, 24)
        Me.cboPatologias.TabIndex = 0
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(135, 705)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(116, 37)
        Me.btnEliminar.TabIndex = 173
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(11, 705)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(116, 37)
        Me.btnAgregar.TabIndex = 172
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnLimpiarFiltro
        '
        Me.btnLimpiarFiltro.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiarFiltro.Image = CType(resources.GetObject("btnLimpiarFiltro.Image"), System.Drawing.Image)
        Me.btnLimpiarFiltro.Location = New System.Drawing.Point(1237, 80)
        Me.btnLimpiarFiltro.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLimpiarFiltro.Name = "btnLimpiarFiltro"
        Me.btnLimpiarFiltro.Size = New System.Drawing.Size(67, 37)
        Me.btnLimpiarFiltro.TabIndex = 170
        Me.btnLimpiarFiltro.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(1313, 705)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(116, 37)
        Me.btnSalir.TabIndex = 163
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(1308, 80)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(116, 37)
        Me.btnBuscar.TabIndex = 164
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(259, 705)
        Me.btnExcel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(116, 37)
        Me.btnExcel.TabIndex = 162
        Me.btnExcel.Text = "a Excel"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'CodGP
        '
        Me.CodGP.Text = "Cod. Bodega"
        '
        'frmMedicamentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1441, 775)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnLimpiarFiltro)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.pnlTotales)
        Me.Controls.Add(Me.lvFARMACOS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMedicamentos"
        Me.Text = "Medicamentos"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlTotales.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnLimpiarFiltro As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cboVigente As ComboBox
    Friend WithEvents btnExcel As Button
    Friend WithEvents pnlTotales As Panel
    Friend WithEvents Label48 As Label
    Friend WithEvents Label86 As Label
    Friend WithEvents lvFARMACOS As ListView
    Friend WithEvents Num As ColumnHeader
    Friend WithEvents Nombre As ColumnHeader
    Friend WithEvents DiasTrat As ColumnHeader
    Friend WithEvents RegLeche As ColumnHeader
    Friend WithEvents Vigente As ColumnHeader
    Friend WithEvents Obs As ColumnHeader
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboPatologias As ComboBox
    Friend WithEvents RegSag As ColumnHeader
    Friend WithEvents RegCarne As ColumnHeader
    Friend WithEvents Dosis As ColumnHeader
    Friend WithEvents Duracion As ColumnHeader
    Friend WithEvents VacLac As ColumnHeader
    Friend WithEvents CodMed As ColumnHeader
    Friend WithEvents Preventivo As ColumnHeader
    Friend WithEvents CodGP As ColumnHeader
End Class
