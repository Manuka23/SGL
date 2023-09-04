<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptConsultaGeneral
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.spGanado_ConsultaGeneral2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MANUKA_PROD_DataSet = New SGL.MANUKA_PROD_DataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.spGanado_ConsultaGeneral2TableAdapter = New SGL.MANUKA_PROD_DataSetTableAdapters.spGanado_ConsultaGeneral2TableAdapter()
        CType(Me.spGanado_ConsultaGeneral2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MANUKA_PROD_DataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spGanado_ConsultaGeneral2BindingSource
        '
        Me.spGanado_ConsultaGeneral2BindingSource.DataMember = "spGanado_ConsultaGeneral2"
        Me.spGanado_ConsultaGeneral2BindingSource.DataSource = Me.MANUKA_PROD_DataSet
        '
        'MANUKA_PROD_DataSet
        '
        Me.MANUKA_PROD_DataSet.DataSetName = "MANUKA_PROD_DataSet"
        Me.MANUKA_PROD_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.spGanado_ConsultaGeneral2BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SGL.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(869, 313)
        Me.ReportViewer1.TabIndex = 0
        '
        'spGanado_ConsultaGeneral2TableAdapter
        '
        Me.spGanado_ConsultaGeneral2TableAdapter.ClearBeforeFill = True
        '
        'frmRptConsultaGeneral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(869, 313)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRptConsultaGeneral"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Informe Consulta General"
        CType(Me.spGanado_ConsultaGeneral2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MANUKA_PROD_DataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents spGanado_ConsultaGeneral2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MANUKA_PROD_DataSet As SGL.MANUKA_PROD_DataSet
    Friend WithEvents spGanado_ConsultaGeneral2TableAdapter As SGL.MANUKA_PROD_DataSetTableAdapters.spGanado_ConsultaGeneral2TableAdapter

End Class
