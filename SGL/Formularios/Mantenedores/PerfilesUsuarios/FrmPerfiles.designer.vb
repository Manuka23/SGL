<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPerfiles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPerfiles))
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ColumnHeader0 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.modificar = New System.Windows.Forms.Button()
        Me.NOMBRE = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lv_lista_perfiles = New System.Windows.Forms.ListView()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MANUKA_PROD_DataSet = New SGL.MANUKA_PROD_DataSet()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.MANUKAPRODDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel1.SuspendLayout()
        CType(Me.MANUKA_PROD_DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MANUKAPRODDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(196, 415)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(87, 30)
        Me.btnEliminar.TabIndex = 137
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(245, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(432, 31)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "PERFILES"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ColumnHeader0
        '
        Me.ColumnHeader0.DisplayIndex = 0
        Me.ColumnHeader0.Text = "Cod Pefil"
        Me.ColumnHeader0.Width = 80
        '
        'modificar
        '
        Me.modificar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.modificar.Image = CType(resources.GetObject("modificar.Image"), System.Drawing.Image)
        Me.modificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.modificar.Location = New System.Drawing.Point(105, 415)
        Me.modificar.Name = "modificar"
        Me.modificar.Size = New System.Drawing.Size(87, 30)
        Me.modificar.TabIndex = 136
        Me.modificar.Text = "Modificar"
        Me.modificar.UseVisualStyleBackColor = True
        '
        'NOMBRE
        '
        Me.NOMBRE.DisplayIndex = 1
        Me.NOMBRE.Text = "NOMBRE"
        Me.NOMBRE.Width = 0
        '
        'lv_lista_perfiles
        '
        Me.lv_lista_perfiles.AutoArrange = False
        Me.lv_lista_perfiles.BackColor = System.Drawing.SystemColors.Window
        Me.lv_lista_perfiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.NOMBRE, Me.ColumnHeader0, Me.ColumnHeader5})
        Me.lv_lista_perfiles.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv_lista_perfiles.FullRowSelect = True
        Me.lv_lista_perfiles.GridLines = True
        Me.lv_lista_perfiles.HideSelection = False
        Me.lv_lista_perfiles.Location = New System.Drawing.Point(12, 58)
        Me.lv_lista_perfiles.MultiSelect = False
        Me.lv_lista_perfiles.Name = "lv_lista_perfiles"
        Me.lv_lista_perfiles.Size = New System.Drawing.Size(524, 348)
        Me.lv_lista_perfiles.TabIndex = 135
        Me.lv_lista_perfiles.UseCompatibleStateImageBehavior = False
        Me.lv_lista_perfiles.View = System.Windows.Forms.View.Details
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(12, 415)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(87, 30)
        Me.btnAgregar.TabIndex = 134
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-202, -6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(970, 61)
        Me.Panel1.TabIndex = 132
        '
        'MANUKA_PROD_DataSet
        '
        Me.MANUKA_PROD_DataSet.DataSetName = "MANUKA_PROD_DataSet"
        Me.MANUKA_PROD_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(449, 412)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 30)
        Me.btnSalir.TabIndex = 131
        Me.btnSalir.Text = "Cerrar"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'MANUKAPRODDataSetBindingSource
        '
        Me.MANUKAPRODDataSetBindingSource.DataSource = Me.MANUKA_PROD_DataSet
        Me.MANUKAPRODDataSetBindingSource.Position = 0
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Nombre Perfil"
        Me.ColumnHeader5.Width = 360
        '
        'FrmPerfiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(567, 466)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.modificar)
        Me.Controls.Add(Me.lv_lista_perfiles)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Name = "FrmPerfiles"
        Me.Text = "Perfiles"
        Me.Panel1.ResumeLayout(False)
        CType(Me.MANUKA_PROD_DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MANUKAPRODDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents modificar As System.Windows.Forms.Button
    Friend WithEvents NOMBRE As System.Windows.Forms.ColumnHeader
    Friend WithEvents lv_lista_perfiles As System.Windows.Forms.ListView
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MANUKA_PROD_DataSet As SGL.MANUKA_PROD_DataSet
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents MANUKAPRODDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
End Class
