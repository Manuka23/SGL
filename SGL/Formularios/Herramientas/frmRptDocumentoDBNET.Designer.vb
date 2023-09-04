

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptDocumentoDBNET
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
        Me.WebBrowser = New System.Windows.Forms.WebBrowser()
        Me.lblError2 = New System.Windows.Forms.Label()
        Me.lblError1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'WebBrowser
        '
        Me.WebBrowser.Location = New System.Drawing.Point(12, 12)
        Me.WebBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser.Name = "WebBrowser"
        Me.WebBrowser.Size = New System.Drawing.Size(693, 208)
        Me.WebBrowser.TabIndex = 2
        '
        'lblError2
        '
        Me.lblError2.Font = New System.Drawing.Font("Calibri", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError2.ForeColor = System.Drawing.Color.Red
        Me.lblError2.Location = New System.Drawing.Point(8, 269)
        Me.lblError2.Name = "lblError2"
        Me.lblError2.Size = New System.Drawing.Size(716, 24)
        Me.lblError2.TabIndex = 3
        Me.lblError2.Text = "DOCUMENTO ELECTRÓNICO N° 0"
        Me.lblError2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblError2.Visible = False
        '
        'lblError1
        '
        Me.lblError1.Font = New System.Drawing.Font("Calibri", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError1.ForeColor = System.Drawing.Color.Red
        Me.lblError1.Location = New System.Drawing.Point(8, 245)
        Me.lblError1.Name = "lblError1"
        Me.lblError1.Size = New System.Drawing.Size(716, 24)
        Me.lblError1.TabIndex = 4
        Me.lblError1.Text = "NO SE ENCUENTRA"
        Me.lblError1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblError1.Visible = False
        '
        'frmRptDocumentoDBNET
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 593)
        Me.Controls.Add(Me.WebBrowser)
        Me.Controls.Add(Me.lblError1)
        Me.Controls.Add(Me.lblError2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRptDocumentoDBNET"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documento Electrónico"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents lblError2 As System.Windows.Forms.Label
    Friend WithEvents lblError1 As System.Windows.Forms.Label
End Class
