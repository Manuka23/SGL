<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptTraslado
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
        Me.rvTraslados = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rvTraslados
        '
        Me.rvTraslados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rvTraslados.LocalReport.ReportEmbeddedResource = "SGL.rptTraslado.rdlc"
        Me.rvTraslados.Location = New System.Drawing.Point(0, 0)
        Me.rvTraslados.Name = "rvTraslados"
        Me.rvTraslados.Size = New System.Drawing.Size(744, 509)
        Me.rvTraslados.TabIndex = 0
        '
        'frmRptTraslado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 509)
        Me.Controls.Add(Me.rvTraslados)
        Me.MinimizeBox = False
        Me.Name = "frmRptTraslado"
        Me.Text = "Guía Despacho Traslado"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rvTraslados As Microsoft.Reporting.WinForms.ReportViewer
End Class
