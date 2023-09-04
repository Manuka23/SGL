<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarDiios
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
        Me.lvBuscarDiios = New System.Windows.Forms.ListView()
        Me.GndCenCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Diio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndProNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndFecNac = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.NomRaza = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndEstado = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndEstadoProductivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndEstadoReproductivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DiasLactancia = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndUltFechaPriPartos = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndUltFechaParto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndUltPartoFormaParto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndActPartosNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndUltCubierta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndUltCubiertaNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndUltFechaCelo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CIDR = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CIDRFecha = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndUlFechaRevPP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GndUltRevPPCondicion = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnLeerBaston = New System.Windows.Forms.Button()
        Me.CenNom = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvBuscarDiios
        '
        Me.lvBuscarDiios.AutoArrange = False
        Me.lvBuscarDiios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvBuscarDiios.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.GndCenCod, Me.Diio, Me.GndProNom, Me.GndFecNac, Me.NomRaza, Me.GndEstado, Me.GndEstadoProductivo, Me.GndEstadoReproductivo, Me.DiasLactancia, Me.GndUltFechaPriPartos, Me.GndUltFechaParto, Me.GndUltPartoFormaParto, Me.GndActPartosNum, Me.GndUltCubierta, Me.GndUltCubiertaNum, Me.GndUltFechaCelo, Me.CIDR, Me.CIDRFecha, Me.GndUlFechaRevPP, Me.GndUltRevPPCondicion, Me.CenNom})
        Me.lvBuscarDiios.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvBuscarDiios.FullRowSelect = True
        Me.lvBuscarDiios.HideSelection = False
        Me.lvBuscarDiios.Location = New System.Drawing.Point(14, 46)
        Me.lvBuscarDiios.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.lvBuscarDiios.MultiSelect = False
        Me.lvBuscarDiios.Name = "lvBuscarDiios"
        Me.lvBuscarDiios.Size = New System.Drawing.Size(1358, 279)
        Me.lvBuscarDiios.TabIndex = 0
        Me.lvBuscarDiios.UseCompatibleStateImageBehavior = False
        Me.lvBuscarDiios.View = System.Windows.Forms.View.Details
        '
        'GndCenCod
        '
        Me.GndCenCod.Text = "Centro"
        '
        'Diio
        '
        Me.Diio.DisplayIndex = 2
        Me.Diio.Text = "Diio"
        '
        'GndProNom
        '
        Me.GndProNom.DisplayIndex = 3
        Me.GndProNom.Text = "Categoria"
        Me.GndProNom.Width = 71
        '
        'GndFecNac
        '
        Me.GndFecNac.DisplayIndex = 4
        Me.GndFecNac.Text = "Fecha Nacimiento"
        Me.GndFecNac.Width = 115
        '
        'NomRaza
        '
        Me.NomRaza.DisplayIndex = 5
        Me.NomRaza.Text = "Raza"
        '
        'GndEstado
        '
        Me.GndEstado.DisplayIndex = 6
        Me.GndEstado.Text = "Estado"
        '
        'GndEstadoProductivo
        '
        Me.GndEstadoProductivo.DisplayIndex = 7
        Me.GndEstadoProductivo.Text = "Estado Productivo"
        Me.GndEstadoProductivo.Width = 107
        '
        'GndEstadoReproductivo
        '
        Me.GndEstadoReproductivo.DisplayIndex = 8
        Me.GndEstadoReproductivo.Text = "Estado Reproductivo"
        Me.GndEstadoReproductivo.Width = 125
        '
        'DiasLactancia
        '
        Me.DiasLactancia.DisplayIndex = 9
        Me.DiasLactancia.Text = "Dias Lactancia"
        Me.DiasLactancia.Width = 95
        '
        'GndUltFechaPriPartos
        '
        Me.GndUltFechaPriPartos.DisplayIndex = 10
        Me.GndUltFechaPriPartos.Text = "Primer Parto"
        Me.GndUltFechaPriPartos.Width = 83
        '
        'GndUltFechaParto
        '
        Me.GndUltFechaParto.DisplayIndex = 11
        Me.GndUltFechaParto.Text = "Ult. Fec. Parto"
        Me.GndUltFechaParto.Width = 94
        '
        'GndUltPartoFormaParto
        '
        Me.GndUltPartoFormaParto.DisplayIndex = 12
        Me.GndUltPartoFormaParto.Text = "Tipo Parto"
        Me.GndUltPartoFormaParto.Width = 70
        '
        'GndActPartosNum
        '
        Me.GndActPartosNum.DisplayIndex = 13
        Me.GndActPartosNum.Text = "N° Partos"
        Me.GndActPartosNum.Width = 66
        '
        'GndUltCubierta
        '
        Me.GndUltCubierta.DisplayIndex = 14
        Me.GndUltCubierta.Text = "Fec. Ult. Cubierta"
        Me.GndUltCubierta.Width = 108
        '
        'GndUltCubiertaNum
        '
        Me.GndUltCubiertaNum.DisplayIndex = 15
        Me.GndUltCubiertaNum.Text = "N° Cubiertas"
        Me.GndUltCubiertaNum.Width = 82
        '
        'GndUltFechaCelo
        '
        Me.GndUltFechaCelo.DisplayIndex = 16
        Me.GndUltFechaCelo.Text = "Ult. Fec. Celo"
        Me.GndUltFechaCelo.Width = 87
        '
        'CIDR
        '
        Me.CIDR.DisplayIndex = 17
        Me.CIDR.Text = "CIDR"
        '
        'CIDRFecha
        '
        Me.CIDRFecha.DisplayIndex = 18
        Me.CIDRFecha.Text = "Fecha CIDR"
        Me.CIDRFecha.Width = 76
        '
        'GndUlFechaRevPP
        '
        Me.GndUlFechaRevPP.DisplayIndex = 19
        Me.GndUlFechaRevPP.Text = "Fec. Ult. RevPP"
        Me.GndUlFechaRevPP.Width = 92
        '
        'GndUltRevPPCondicion
        '
        Me.GndUltRevPPCondicion.DisplayIndex = 20
        Me.GndUltRevPPCondicion.Text = "Condicion RevPP"
        Me.GndUltRevPPCondicion.Width = 109
        '
        'btnLeerBaston
        '
        Me.btnLeerBaston.Location = New System.Drawing.Point(14, 329)
        Me.btnLeerBaston.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btnLeerBaston.Name = "btnLeerBaston"
        Me.btnLeerBaston.Size = New System.Drawing.Size(106, 28)
        Me.btnLeerBaston.TabIndex = 1
        Me.btnLeerBaston.Text = "Leer Baston"
        Me.btnLeerBaston.UseVisualStyleBackColor = True
        '
        'CenNom
        '
        Me.CenNom.DisplayIndex = 1
        Me.CenNom.Text = "Centro Nom."
        Me.CenNom.Width = 95
        '
        'frmBuscarDiios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1383, 366)
        Me.Controls.Add(Me.btnLeerBaston)
        Me.Controls.Add(Me.lvBuscarDiios)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmBuscarDiios"
        Me.Text = "Consulta Diios"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvBuscarDiios As ListView
    Friend WithEvents btnLeerBaston As Button
    Friend WithEvents GndCenCod As ColumnHeader
    Friend WithEvents Diio As ColumnHeader
    Friend WithEvents GndProNom As ColumnHeader
    Friend WithEvents GndFecNac As ColumnHeader
    Friend WithEvents NomRaza As ColumnHeader
    Friend WithEvents GndEstado As ColumnHeader
    Friend WithEvents GndEstadoProductivo As ColumnHeader
    Friend WithEvents GndEstadoReproductivo As ColumnHeader
    Friend WithEvents DiasLactancia As ColumnHeader
    Friend WithEvents GndUltFechaPriPartos As ColumnHeader
    Friend WithEvents GndUltFechaParto As ColumnHeader
    Friend WithEvents GndUltPartoFormaParto As ColumnHeader
    Friend WithEvents GndActPartosNum As ColumnHeader
    Friend WithEvents GndUltCubierta As ColumnHeader
    Friend WithEvents GndUltCubiertaNum As ColumnHeader
    Friend WithEvents GndUltFechaCelo As ColumnHeader
    Friend WithEvents CIDR As ColumnHeader
    Friend WithEvents CIDRFecha As ColumnHeader
    Friend WithEvents GndUlFechaRevPP As ColumnHeader
    Friend WithEvents GndUltRevPPCondicion As ColumnHeader
    Friend WithEvents CenNom As ColumnHeader
End Class
