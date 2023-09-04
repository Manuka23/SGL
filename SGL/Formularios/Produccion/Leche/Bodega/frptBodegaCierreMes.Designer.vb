<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frptBodegaCierreMes
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
        Me.wbSSRSBodegaCierreMes = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'wbSSRSBodegaCierreMes
        '
        Me.wbSSRSBodegaCierreMes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbSSRSBodegaCierreMes.Location = New System.Drawing.Point(0, 0)
        Me.wbSSRSBodegaCierreMes.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbSSRSBodegaCierreMes.Name = "wbSSRSBodegaCierreMes"
        Me.wbSSRSBodegaCierreMes.Size = New System.Drawing.Size(1195, 657)
        Me.wbSSRSBodegaCierreMes.TabIndex = 0
        Me.wbSSRSBodegaCierreMes.Url = New System.Uri("", System.UriKind.Relative)
        '
        'frptBodegaCierreMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 657)
        Me.Controls.Add(Me.wbSSRSBodegaCierreMes)
        Me.Name = "frptBodegaCierreMes"
        Me.Text = "frptBodegaCierreMes"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents wbSSRSBodegaCierreMes As WebBrowser
End Class
