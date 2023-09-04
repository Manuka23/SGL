<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frptConteoAnimales
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
        Me.rvConteoAnimales = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvConteoAnimales
        '
        Me.rvConteoAnimales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvConteoAnimales.Location = New System.Drawing.Point(0, 0)
        Me.rvConteoAnimales.Name = "rvConteoAnimales"
        Me.rvConteoAnimales.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rvConteoAnimales.ServerReport.ReportPath = "/Producción/ConteoSemanal/Conteo Semanal de animales"
        Me.rvConteoAnimales.ServerReport.ReportServerUrl = New System.Uri("http://srvreports/ReportServer", System.UriKind.Absolute)
        Me.rvConteoAnimales.Size = New System.Drawing.Size(731, 446)
        Me.rvConteoAnimales.TabIndex = 1
        '
        'frptConteoAnimales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 446)
        Me.Controls.Add(Me.rvConteoAnimales)
        Me.Name = "frptConteoAnimales"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Reporte Conteo de Animales"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvConteoAnimales As Microsoft.Reporting.WinForms.ReportViewer
End Class
