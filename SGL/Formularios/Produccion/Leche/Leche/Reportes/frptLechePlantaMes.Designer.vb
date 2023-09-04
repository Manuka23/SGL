<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frptLechePlantaMes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frptLechePlantaMes))
        Me.rvLechePlantaMes = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvLechePlantaMes
        '
        Me.rvLechePlantaMes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvLechePlantaMes.Location = New System.Drawing.Point(0, 0)
        Me.rvLechePlantaMes.Name = "rvLechePlantaMes"
        Me.rvLechePlantaMes.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rvLechePlantaMes.ServerReport.ReportPath = "/Producción/Producción de Leche/Leche a Planta por Dia"
        Me.rvLechePlantaMes.ServerReport.ReportServerUrl = New System.Uri("http://srvreports/ReportServer", System.UriKind.Absolute)
        Me.rvLechePlantaMes.Size = New System.Drawing.Size(780, 499)
        Me.rvLechePlantaMes.TabIndex = 0
        '
        'frptLechePlantaMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 499)
        Me.Controls.Add(Me.rvLechePlantaMes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frptLechePlantaMes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Leche a Planta Mensual"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvLechePlantaMes As Microsoft.Reporting.WinForms.ReportViewer
End Class
