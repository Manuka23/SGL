<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptPlanillaCubiertas
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.MNKPROD_DS_PlanillaCubiertas = New SGL.MNKPROD_DS_PlanillaCubiertas()
        Me.spCubiertas_PlanillaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.spCubiertas_PlanillaTableAdapter = New SGL.MNKPROD_DS_PlanillaCubiertasTableAdapters.spCubiertas_PlanillaTableAdapter()
        CType(Me.MNKPROD_DS_PlanillaCubiertas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spCubiertas_PlanillaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DSPlanillaCubiertas"
        ReportDataSource1.Value = Me.spCubiertas_PlanillaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "SGL.rptPlanillaCubiertas.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(520, 325)
        Me.ReportViewer1.TabIndex = 0
        '
        'MNKPROD_DS_PlanillaCubiertas
        '
        Me.MNKPROD_DS_PlanillaCubiertas.DataSetName = "MNKPROD_DS_PlanillaCubiertas"
        Me.MNKPROD_DS_PlanillaCubiertas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'spCubiertas_PlanillaBindingSource
        '
        Me.spCubiertas_PlanillaBindingSource.DataMember = "spCubiertas_Planilla"
        Me.spCubiertas_PlanillaBindingSource.DataSource = Me.MNKPROD_DS_PlanillaCubiertas
        '
        'spCubiertas_PlanillaTableAdapter
        '
        Me.spCubiertas_PlanillaTableAdapter.ClearBeforeFill = True
        '
        'frmRptPlanillaCubiertas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 325)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmRptPlanillaCubiertas"
        Me.Text = "Informe Planilla Cubiertas"
        CType(Me.MNKPROD_DS_PlanillaCubiertas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spCubiertas_PlanillaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents spCubiertas_PlanillaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MNKPROD_DS_PlanillaCubiertas As SGL.MNKPROD_DS_PlanillaCubiertas
    Friend WithEvents spCubiertas_PlanillaTableAdapter As SGL.MNKPROD_DS_PlanillaCubiertasTableAdapters.spCubiertas_PlanillaTableAdapter
End Class
