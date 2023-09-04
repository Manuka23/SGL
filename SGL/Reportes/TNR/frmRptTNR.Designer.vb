<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptTNR
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.MNKPROD_DS_TNR = New SGL.MNKPROD_DS_TNR()
        Me.spGanado_TNRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.spGanado_TNRTableAdapter = New SGL.MNKPROD_DS_TNRTableAdapters.spGanado_TNRTableAdapter()
        CType(Me.MNKPROD_DS_TNR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spGanado_TNRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DS_TNR"
        ReportDataSource2.Value = Me.spGanado_TNRBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SGL.rptTNR.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(583, 365)
        Me.ReportViewer1.TabIndex = 0
        '
        'MNKPROD_DS_TNR
        '
        Me.MNKPROD_DS_TNR.DataSetName = "MNKPROD_DS_TNR"
        Me.MNKPROD_DS_TNR.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'spGanado_TNRBindingSource
        '
        Me.spGanado_TNRBindingSource.DataMember = "spGanado_TNR"
        Me.spGanado_TNRBindingSource.DataSource = Me.MNKPROD_DS_TNR
        '
        'spGanado_TNRTableAdapter
        '
        Me.spGanado_TNRTableAdapter.ClearBeforeFill = True
        '
        'frmRptTNR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 365)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRptTNR"
        Me.Text = "Informe TNR"
        CType(Me.MNKPROD_DS_TNR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spGanado_TNRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents spGanado_TNRBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MNKPROD_DS_TNR As SGL.MNKPROD_DS_TNR
    Friend WithEvents spGanado_TNRTableAdapter As SGL.MNKPROD_DS_TNRTableAdapters.spGanado_TNRTableAdapter
End Class
