<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptConsultaCelos
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
        Me.spGanado_ConsultaGeneral3BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MANUKA_PROD_DSConsultaCelos = New SGL.MANUKA_PROD_DSConsultaCelos()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.spGanado_ConsultaGeneral3TableAdapter = New SGL.MANUKA_PROD_DSConsultaCelosTableAdapters.spGanado_ConsultaGeneral3TableAdapter()
        CType(Me.spGanado_ConsultaGeneral3BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MANUKA_PROD_DSConsultaCelos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'spGanado_ConsultaGeneral3BindingSource
        '
        Me.spGanado_ConsultaGeneral3BindingSource.DataMember = "spGanado_ConsultaGeneral3"
        Me.spGanado_ConsultaGeneral3BindingSource.DataSource = Me.MANUKA_PROD_DSConsultaCelos
        '
        'MANUKA_PROD_DSConsultaCelos
        '
        Me.MANUKA_PROD_DSConsultaCelos.DataSetName = "MANUKA_PROD_DSConsultaCelos"
        Me.MANUKA_PROD_DSConsultaCelos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.spGanado_ConsultaGeneral3BindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SGL.rptConsultaCelos.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(642, 386)
        Me.ReportViewer1.TabIndex = 1
        '
        'spGanado_ConsultaGeneral3TableAdapter
        '
        Me.spGanado_ConsultaGeneral3TableAdapter.ClearBeforeFill = True
        '
        'frmRptConsultaCelos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 386)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRptConsultaCelos"
        Me.Text = "Informe Consulta Celos"
        CType(Me.spGanado_ConsultaGeneral3BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MANUKA_PROD_DSConsultaCelos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents spGanado_ConsultaGeneral3BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MANUKA_PROD_DSConsultaCelos As SGL.MANUKA_PROD_DSConsultaCelos
    Friend WithEvents spGanado_ConsultaGeneral3TableAdapter As SGL.MANUKA_PROD_DSConsultaCelosTableAdapters.spGanado_ConsultaGeneral3TableAdapter
End Class
