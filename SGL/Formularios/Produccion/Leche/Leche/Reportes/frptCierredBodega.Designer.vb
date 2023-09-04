<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frptCierredBodega
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frptCierredBodega))
        Me.rptTarja = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        Me.rptTarja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptTarja.Location = New System.Drawing.Point(0, 0)
        Me.rptTarja.Name = "rptTarja"
        Me.rptTarja.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rptTarja.ServerReport.ReportPath = "/Administración y Finanzas/Inventario/Inventario - Cierre Bodega"
        Me.rptTarja.ServerReport.ReportServerUrl = New System.Uri("http://srvreports/reportserver", System.UriKind.Absolute)
        Me.rptTarja.Size = New System.Drawing.Size(767, 412)
        Me.rptTarja.TabIndex = 0
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 412)
        Me.Controls.Add(Me.rptTarja)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frptCierredBodega"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.Text = "Cierre de Bodega"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents rptTarja As Microsoft.Reporting.WinForms.ReportViewer
End Class
