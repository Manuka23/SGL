﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frptCierreMensualGanado
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
        Me.rptCierreGanado = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rptCierreGanado
        '
        Me.rptCierreGanado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCierreGanado.Location = New System.Drawing.Point(0, 0)
        Me.rptCierreGanado.Name = "rptCierreGanado"
        Me.rptCierreGanado.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rptCierreGanado.ServerReport.ReportPath = "/Producción/Cierre Mensual Ganado/Cierre Mensual (EEGG)"
        Me.rptCierreGanado.ServerReport.ReportServerUrl = New System.Uri("http://srvreports/ReportServer/", System.UriKind.Absolute)
        Me.rptCierreGanado.Size = New System.Drawing.Size(718, 381)
        Me.rptCierreGanado.TabIndex = 0
        '
        'frptCierreMensualGanado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 381)
        Me.Controls.Add(Me.rptCierreGanado)
        Me.Name = "frptCierreMensualGanado"
        Me.Text = "frptCierreMensualGanado"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptCierreGanado As Microsoft.Reporting.WinForms.ReportViewer
End Class
