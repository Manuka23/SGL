<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmResumenes
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
        Me.ManukA_PROD_DataSet1 = New SGL.MANUKA_PROD_DataSet()
        Me.tabPASTO = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvRetiroLeche = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ManukA_PROD_DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPASTO.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvRetiroLeche, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ManukA_PROD_DataSet1
        '
        Me.ManukA_PROD_DataSet1.DataSetName = "MANUKA_PROD_DataSet"
        Me.ManukA_PROD_DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tabPASTO
        '
        Me.tabPASTO.Controls.Add(Me.TabPage1)
        Me.tabPASTO.Location = New System.Drawing.Point(27, 31)
        Me.tabPASTO.Name = "tabPASTO"
        Me.tabPASTO.SelectedIndex = 0
        Me.tabPASTO.Size = New System.Drawing.Size(1341, 302)
        Me.tabPASTO.TabIndex = 214
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.dgvRetiroLeche)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1333, 276)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Detalle"
        '
        'dgvRetiroLeche
        '
        Me.dgvRetiroLeche.AllowDrop = True
        Me.dgvRetiroLeche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRetiroLeche.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column19, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column13, Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18})
        Me.dgvRetiroLeche.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRetiroLeche.GridColor = System.Drawing.SystemColors.Control
        Me.dgvRetiroLeche.Location = New System.Drawing.Point(3, 3)
        Me.dgvRetiroLeche.Name = "dgvRetiroLeche"
        Me.dgvRetiroLeche.Size = New System.Drawing.Size(1327, 270)
        Me.dgvRetiroLeche.TabIndex = 13
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cod"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column19
        '
        Me.Column19.HeaderText = "Dato"
        Me.Column19.Name = "Column19"
        Me.Column19.Width = 150
        '
        'Column2
        '
        Me.Column2.HeaderText = "Jul-18"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 65
        '
        'Column3
        '
        Me.Column3.HeaderText = "Ago-18"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 65
        '
        'Column4
        '
        Me.Column4.HeaderText = "sep-18"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 65
        '
        'Column5
        '
        Me.Column5.HeaderText = "Oct-18"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 65
        '
        'Column6
        '
        Me.Column6.HeaderText = "Nov-18"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 65
        '
        'Column7
        '
        Me.Column7.HeaderText = "Dic-18"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 65
        '
        'Column8
        '
        Me.Column8.HeaderText = "Ene-19"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 65
        '
        'Column9
        '
        Me.Column9.HeaderText = "Feb-19"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 65
        '
        'Column10
        '
        Me.Column10.HeaderText = "Mar-19"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 65
        '
        'Column11
        '
        Me.Column11.HeaderText = "Abr-19"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 65
        '
        'Column12
        '
        Me.Column12.HeaderText = "May-19"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 65
        '
        'Column13
        '
        Me.Column13.HeaderText = "Jun-19"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Width = 65
        '
        'Column14
        '
        Me.Column14.HeaderText = "Jul-19"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        Me.Column14.Width = 65
        '
        'Column15
        '
        Me.Column15.HeaderText = "Ago-19"
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Width = 65
        '
        'Column16
        '
        Me.Column16.HeaderText = "Sep-19"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 65
        '
        'Column17
        '
        Me.Column17.HeaderText = "Total 18-19"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 85
        '
        'Column18
        '
        Me.Column18.HeaderText = "TotalPeriodo"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Width = 75
        '
        'frmResumenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1477, 695)
        Me.ControlBox = False
        Me.Controls.Add(Me.tabPASTO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResumenes"
        Me.ShowInTaskbar = False
        Me.Text = "Resumen Produccion"
        CType(Me.ManukA_PROD_DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPASTO.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvRetiroLeche, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ManukA_PROD_DataSet1 As MANUKA_PROD_DataSet
    Friend WithEvents tabPASTO As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvRetiroLeche As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
End Class
