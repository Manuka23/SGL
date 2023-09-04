<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMAIN
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMAIN))
        Me.tmrLogin = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnVentas = New System.Windows.Forms.Button()
        Me.btnMuertes = New System.Windows.Forms.Button()
        Me.btnTraslados = New System.Windows.Forms.Button()
        Me.btnPartos = New System.Windows.Forms.Button()
        Me.btnSecados = New System.Windows.Forms.Button()
        Me.btnPalpaciones = New System.Windows.Forms.Button()
        Me.pboxIngles = New System.Windows.Forms.PictureBox()
        Me.pboxEspaniol = New System.Windows.Forms.PictureBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.version = New System.Windows.Forms.Timer(Me.components)
        Me.pnlBarra = New System.Windows.Forms.Panel()
        Me.lblSeparador = New System.Windows.Forms.Label()
        Me.btnActualizaciones = New System.Windows.Forms.Button()
        Me.btnTablero = New System.Windows.Forms.Button()
        Me.btnBuscaDIIO = New System.Windows.Forms.Button()
        Me.txtDIIO = New System.Windows.Forms.TextBox()
        Me.lblTitDIIO = New System.Windows.Forms.Label()
        Me.btnPanelConsulta = New System.Windows.Forms.Button()
        Me.btnHerramientas = New System.Windows.Forms.Button()
        Me.btnCerrarSesion = New System.Windows.Forms.Button()
        Me.lblCentro = New System.Windows.Forms.Label()
        Me.lblTitCentro = New System.Windows.Forms.Label()
        Me.pnlMenu = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnVerGrupoDiio = New System.Windows.Forms.Button()
        Me.btnAgrupar = New System.Windows.Forms.Button()
        Me.btnLeeBaston = New System.Windows.Forms.Button()
        Me.txtDIIOGrupo = New System.Windows.Forms.TextBox()
        Me.pnlBuscarGrupo = New System.Windows.Forms.Panel()
        Me.tabGrupos = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.lvGrupo1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.lvGrupo2 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.lvGrupo3 = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblActualizacion = New System.Windows.Forms.Label()
        Me.lblHideShowMenu = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblTituloMenu = New System.Windows.Forms.Label()
        Me.tvMENU = New System.Windows.Forms.TreeView()
        CType(Me.pboxIngles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pboxEspaniol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarra.SuspendLayout()
        Me.pnlMenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlBuscarGrupo.SuspendLayout()
        Me.tabGrupos.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrLogin
        '
        '
        'btnVentas
        '
        Me.btnVentas.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVentas.Image = CType(resources.GetObject("btnVentas.Image"), System.Drawing.Image)
        Me.btnVentas.Location = New System.Drawing.Point(3, 366)
        Me.btnVentas.Name = "btnVentas"
        Me.btnVentas.Size = New System.Drawing.Size(69, 61)
        Me.btnVentas.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.btnVentas, "Ventas")
        Me.btnVentas.UseVisualStyleBackColor = True
        '
        'btnMuertes
        '
        Me.btnMuertes.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMuertes.Image = CType(resources.GetObject("btnMuertes.Image"), System.Drawing.Image)
        Me.btnMuertes.Location = New System.Drawing.Point(3, 232)
        Me.btnMuertes.Name = "btnMuertes"
        Me.btnMuertes.Size = New System.Drawing.Size(69, 61)
        Me.btnMuertes.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.btnMuertes, "Muertes")
        Me.btnMuertes.UseVisualStyleBackColor = True
        '
        'btnTraslados
        '
        Me.btnTraslados.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTraslados.Image = CType(resources.GetObject("btnTraslados.Image"), System.Drawing.Image)
        Me.btnTraslados.Location = New System.Drawing.Point(3, 299)
        Me.btnTraslados.Name = "btnTraslados"
        Me.btnTraslados.Size = New System.Drawing.Size(69, 61)
        Me.btnTraslados.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnTraslados, "Traslados")
        Me.btnTraslados.UseVisualStyleBackColor = True
        '
        'btnPartos
        '
        Me.btnPartos.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPartos.Image = CType(resources.GetObject("btnPartos.Image"), System.Drawing.Image)
        Me.btnPartos.Location = New System.Drawing.Point(3, 165)
        Me.btnPartos.Name = "btnPartos"
        Me.btnPartos.Size = New System.Drawing.Size(69, 61)
        Me.btnPartos.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnPartos, "Partos")
        Me.btnPartos.UseVisualStyleBackColor = True
        '
        'btnSecados
        '
        Me.btnSecados.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSecados.Image = CType(resources.GetObject("btnSecados.Image"), System.Drawing.Image)
        Me.btnSecados.Location = New System.Drawing.Point(3, 98)
        Me.btnSecados.Name = "btnSecados"
        Me.btnSecados.Size = New System.Drawing.Size(69, 61)
        Me.btnSecados.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnSecados, "Secado")
        Me.btnSecados.UseVisualStyleBackColor = True
        '
        'btnPalpaciones
        '
        Me.btnPalpaciones.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPalpaciones.Image = CType(resources.GetObject("btnPalpaciones.Image"), System.Drawing.Image)
        Me.btnPalpaciones.Location = New System.Drawing.Point(3, 31)
        Me.btnPalpaciones.Name = "btnPalpaciones"
        Me.btnPalpaciones.Size = New System.Drawing.Size(69, 61)
        Me.btnPalpaciones.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnPalpaciones, "Palpaciones")
        Me.btnPalpaciones.UseVisualStyleBackColor = True
        '
        'pboxIngles
        '
        Me.pboxIngles.BackColor = System.Drawing.Color.Transparent
        Me.pboxIngles.Image = CType(resources.GetObject("pboxIngles.Image"), System.Drawing.Image)
        Me.pboxIngles.Location = New System.Drawing.Point(172, 0)
        Me.pboxIngles.Name = "pboxIngles"
        Me.pboxIngles.Size = New System.Drawing.Size(28, 21)
        Me.pboxIngles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxIngles.TabIndex = 45
        Me.pboxIngles.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pboxIngles, "English")
        '
        'pboxEspaniol
        '
        Me.pboxEspaniol.BackColor = System.Drawing.Color.Transparent
        Me.pboxEspaniol.Image = CType(resources.GetObject("pboxEspaniol.Image"), System.Drawing.Image)
        Me.pboxEspaniol.Location = New System.Drawing.Point(142, 0)
        Me.pboxEspaniol.Name = "pboxEspaniol"
        Me.pboxEspaniol.Size = New System.Drawing.Size(28, 21)
        Me.pboxEspaniol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pboxEspaniol.TabIndex = 44
        Me.pboxEspaniol.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pboxEspaniol, "Español")
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'version
        '
        Me.version.Interval = 1000000
        '
        'pnlBarra
        '
        Me.pnlBarra.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlBarra.Controls.Add(Me.lblSeparador)
        Me.pnlBarra.Controls.Add(Me.btnActualizaciones)
        Me.pnlBarra.Controls.Add(Me.btnTablero)
        Me.pnlBarra.Controls.Add(Me.btnBuscaDIIO)
        Me.pnlBarra.Controls.Add(Me.txtDIIO)
        Me.pnlBarra.Controls.Add(Me.lblTitDIIO)
        Me.pnlBarra.Controls.Add(Me.btnPanelConsulta)
        Me.pnlBarra.Controls.Add(Me.btnHerramientas)
        Me.pnlBarra.Controls.Add(Me.btnCerrarSesion)
        Me.pnlBarra.Controls.Add(Me.lblCentro)
        Me.pnlBarra.Controls.Add(Me.lblTitCentro)
        Me.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBarra.Location = New System.Drawing.Point(0, 0)
        Me.pnlBarra.Name = "pnlBarra"
        Me.pnlBarra.Size = New System.Drawing.Size(1116, 33)
        Me.pnlBarra.TabIndex = 19
        '
        'lblSeparador
        '
        Me.lblSeparador.AccessibleRole = System.Windows.Forms.AccessibleRole.Client
        Me.lblSeparador.BackColor = System.Drawing.Color.SteelBlue
        Me.lblSeparador.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSeparador.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblSeparador.Location = New System.Drawing.Point(0, 29)
        Me.lblSeparador.Name = "lblSeparador"
        Me.lblSeparador.Size = New System.Drawing.Size(1116, 4)
        Me.lblSeparador.TabIndex = 43
        '
        'btnActualizaciones
        '
        Me.btnActualizaciones.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizaciones.Image = Global.SGL.My.Resources.Resources.arrow_down
        Me.btnActualizaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizaciones.Location = New System.Drawing.Point(654, 1)
        Me.btnActualizaciones.Name = "btnActualizaciones"
        Me.btnActualizaciones.Size = New System.Drawing.Size(118, 28)
        Me.btnActualizaciones.TabIndex = 42
        Me.btnActualizaciones.Text = "Actualizaciones"
        Me.btnActualizaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizaciones.UseVisualStyleBackColor = True
        Me.btnActualizaciones.Visible = False
        '
        'btnTablero
        '
        Me.btnTablero.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTablero.Image = CType(resources.GetObject("btnTablero.Image"), System.Drawing.Image)
        Me.btnTablero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTablero.Location = New System.Drawing.Point(921, 1)
        Me.btnTablero.Name = "btnTablero"
        Me.btnTablero.Size = New System.Drawing.Size(118, 28)
        Me.btnTablero.TabIndex = 41
        Me.btnTablero.Text = "Tablero Control"
        Me.btnTablero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTablero.UseVisualStyleBackColor = True
        Me.btnTablero.Visible = False
        '
        'btnBuscaDIIO
        '
        Me.btnBuscaDIIO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaDIIO.Image = CType(resources.GetObject("btnBuscaDIIO.Image"), System.Drawing.Image)
        Me.btnBuscaDIIO.Location = New System.Drawing.Point(639, 1)
        Me.btnBuscaDIIO.Name = "btnBuscaDIIO"
        Me.btnBuscaDIIO.Size = New System.Drawing.Size(36, 28)
        Me.btnBuscaDIIO.TabIndex = 40
        Me.btnBuscaDIIO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscaDIIO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscaDIIO.UseVisualStyleBackColor = True
        Me.btnBuscaDIIO.Visible = False
        '
        'txtDIIO
        '
        Me.txtDIIO.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIIO.Location = New System.Drawing.Point(525, 3)
        Me.txtDIIO.MaxLength = 20
        Me.txtDIIO.Name = "txtDIIO"
        Me.txtDIIO.Size = New System.Drawing.Size(112, 24)
        Me.txtDIIO.TabIndex = 39
        Me.txtDIIO.Visible = False
        '
        'lblTitDIIO
        '
        Me.lblTitDIIO.BackColor = System.Drawing.Color.Transparent
        Me.lblTitDIIO.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitDIIO.ForeColor = System.Drawing.Color.White
        Me.lblTitDIIO.Location = New System.Drawing.Point(484, 5)
        Me.lblTitDIIO.Name = "lblTitDIIO"
        Me.lblTitDIIO.Size = New System.Drawing.Size(45, 19)
        Me.lblTitDIIO.TabIndex = 38
        Me.lblTitDIIO.Text = "DIIO:"
        Me.lblTitDIIO.Visible = False
        '
        'btnPanelConsulta
        '
        Me.btnPanelConsulta.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPanelConsulta.Image = CType(resources.GetObject("btnPanelConsulta.Image"), System.Drawing.Image)
        Me.btnPanelConsulta.Location = New System.Drawing.Point(760, 1)
        Me.btnPanelConsulta.Name = "btnPanelConsulta"
        Me.btnPanelConsulta.Size = New System.Drawing.Size(118, 28)
        Me.btnPanelConsulta.TabIndex = 30
        Me.btnPanelConsulta.Text = "Panel Consulta"
        Me.btnPanelConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPanelConsulta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPanelConsulta.UseVisualStyleBackColor = True
        Me.btnPanelConsulta.Visible = False
        '
        'btnHerramientas
        '
        Me.btnHerramientas.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHerramientas.Image = CType(resources.GetObject("btnHerramientas.Image"), System.Drawing.Image)
        Me.btnHerramientas.Location = New System.Drawing.Point(684, 1)
        Me.btnHerramientas.Name = "btnHerramientas"
        Me.btnHerramientas.Size = New System.Drawing.Size(118, 28)
        Me.btnHerramientas.TabIndex = 31
        Me.btnHerramientas.Text = "Herramientas"
        Me.btnHerramientas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHerramientas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnHerramientas.UseVisualStyleBackColor = True
        Me.btnHerramientas.Visible = False
        '
        'btnCerrarSesion
        '
        Me.btnCerrarSesion.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarSesion.Image = CType(resources.GetObject("btnCerrarSesion.Image"), System.Drawing.Image)
        Me.btnCerrarSesion.Location = New System.Drawing.Point(811, 1)
        Me.btnCerrarSesion.Name = "btnCerrarSesion"
        Me.btnCerrarSesion.Size = New System.Drawing.Size(118, 28)
        Me.btnCerrarSesion.TabIndex = 29
        Me.btnCerrarSesion.Text = "Cerrar Sesión"
        Me.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCerrarSesion.UseVisualStyleBackColor = True
        Me.btnCerrarSesion.Visible = False
        '
        'lblCentro
        '
        Me.lblCentro.BackColor = System.Drawing.Color.Transparent
        Me.lblCentro.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCentro.ForeColor = System.Drawing.Color.White
        Me.lblCentro.Location = New System.Drawing.Point(96, 3)
        Me.lblCentro.Name = "lblCentro"
        Me.lblCentro.Size = New System.Drawing.Size(476, 21)
        Me.lblCentro.TabIndex = 18
        Me.lblCentro.Text = "[NO ASIGNADO]"
        Me.lblCentro.Visible = False
        '
        'lblTitCentro
        '
        Me.lblTitCentro.BackColor = System.Drawing.Color.Transparent
        Me.lblTitCentro.Font = New System.Drawing.Font("Calibri", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCentro.ForeColor = System.Drawing.Color.White
        Me.lblTitCentro.Location = New System.Drawing.Point(10, 3)
        Me.lblTitCentro.Name = "lblTitCentro"
        Me.lblTitCentro.Size = New System.Drawing.Size(81, 21)
        Me.lblTitCentro.TabIndex = 17
        Me.lblTitCentro.Text = "CENTRO:"
        Me.lblTitCentro.Visible = False
        '
        'pnlMenu
        '
        Me.pnlMenu.BackColor = System.Drawing.Color.MidnightBlue
        Me.pnlMenu.Controls.Add(Me.tvMENU)
        Me.pnlMenu.Controls.Add(Me.Panel2)
        Me.pnlMenu.Controls.Add(Me.pnlBuscarGrupo)
        Me.pnlMenu.Controls.Add(Me.Panel3)
        Me.pnlMenu.Controls.Add(Me.Label2)
        Me.pnlMenu.Controls.Add(Me.btnVentas)
        Me.pnlMenu.Controls.Add(Me.Panel4)
        Me.pnlMenu.Controls.Add(Me.btnTraslados)
        Me.pnlMenu.Controls.Add(Me.btnMuertes)
        Me.pnlMenu.Controls.Add(Me.btnPalpaciones)
        Me.pnlMenu.Controls.Add(Me.btnSecados)
        Me.pnlMenu.Controls.Add(Me.btnPartos)
        Me.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlMenu.Location = New System.Drawing.Point(0, 33)
        Me.pnlMenu.Name = "pnlMenu"
        Me.pnlMenu.Size = New System.Drawing.Size(200, 599)
        Me.pnlMenu.TabIndex = 21
        Me.pnlMenu.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel2.Controls.Add(Me.btnVerGrupoDiio)
        Me.Panel2.Controls.Add(Me.btnAgrupar)
        Me.Panel2.Controls.Add(Me.btnLeeBaston)
        Me.Panel2.Controls.Add(Me.txtDIIOGrupo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 341)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 32)
        Me.Panel2.TabIndex = 12
        '
        'btnVerGrupoDiio
        '
        Me.btnVerGrupoDiio.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerGrupoDiio.Image = CType(resources.GetObject("btnVerGrupoDiio.Image"), System.Drawing.Image)
        Me.btnVerGrupoDiio.Location = New System.Drawing.Point(103, 3)
        Me.btnVerGrupoDiio.Name = "btnVerGrupoDiio"
        Me.btnVerGrupoDiio.Size = New System.Drawing.Size(32, 27)
        Me.btnVerGrupoDiio.TabIndex = 15
        Me.btnVerGrupoDiio.UseVisualStyleBackColor = True
        '
        'btnAgrupar
        '
        Me.btnAgrupar.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgrupar.Image = CType(resources.GetObject("btnAgrupar.Image"), System.Drawing.Image)
        Me.btnAgrupar.Location = New System.Drawing.Point(164, 3)
        Me.btnAgrupar.Name = "btnAgrupar"
        Me.btnAgrupar.Size = New System.Drawing.Size(32, 27)
        Me.btnAgrupar.TabIndex = 14
        Me.btnAgrupar.UseVisualStyleBackColor = True
        '
        'btnLeeBaston
        '
        Me.btnLeeBaston.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeeBaston.Image = CType(resources.GetObject("btnLeeBaston.Image"), System.Drawing.Image)
        Me.btnLeeBaston.Location = New System.Drawing.Point(133, 3)
        Me.btnLeeBaston.Name = "btnLeeBaston"
        Me.btnLeeBaston.Size = New System.Drawing.Size(33, 27)
        Me.btnLeeBaston.TabIndex = 13
        Me.btnLeeBaston.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLeeBaston.UseVisualStyleBackColor = True
        '
        'txtDIIOGrupo
        '
        Me.txtDIIOGrupo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDIIOGrupo.Location = New System.Drawing.Point(5, 4)
        Me.txtDIIOGrupo.MaxLength = 20
        Me.txtDIIOGrupo.Name = "txtDIIOGrupo"
        Me.txtDIIOGrupo.Size = New System.Drawing.Size(92, 23)
        Me.txtDIIOGrupo.TabIndex = 10
        '
        'pnlBuscarGrupo
        '
        Me.pnlBuscarGrupo.BackColor = System.Drawing.Color.SlateGray
        Me.pnlBuscarGrupo.Controls.Add(Me.tabGrupos)
        Me.pnlBuscarGrupo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBuscarGrupo.Location = New System.Drawing.Point(0, 373)
        Me.pnlBuscarGrupo.Name = "pnlBuscarGrupo"
        Me.pnlBuscarGrupo.Size = New System.Drawing.Size(200, 184)
        Me.pnlBuscarGrupo.TabIndex = 11
        '
        'tabGrupos
        '
        Me.tabGrupos.AllowDrop = True
        Me.tabGrupos.Controls.Add(Me.TabPage3)
        Me.tabGrupos.Controls.Add(Me.TabPage4)
        Me.tabGrupos.Controls.Add(Me.TabPage5)
        Me.tabGrupos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrupos.Location = New System.Drawing.Point(0, 0)
        Me.tabGrupos.Name = "tabGrupos"
        Me.tabGrupos.SelectedIndex = 0
        Me.tabGrupos.Size = New System.Drawing.Size(200, 184)
        Me.tabGrupos.TabIndex = 9
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.lvGrupo1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(192, 158)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "Grupo 1"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'lvGrupo1
        '
        Me.lvGrupo1.AutoArrange = False
        Me.lvGrupo1.BackColor = System.Drawing.SystemColors.Window
        Me.lvGrupo1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvGrupo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvGrupo1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvGrupo1.FullRowSelect = True
        Me.lvGrupo1.GridLines = True
        Me.lvGrupo1.HideSelection = False
        Me.lvGrupo1.Location = New System.Drawing.Point(3, 3)
        Me.lvGrupo1.MultiSelect = False
        Me.lvGrupo1.Name = "lvGrupo1"
        Me.lvGrupo1.Size = New System.Drawing.Size(186, 152)
        Me.lvGrupo1.TabIndex = 136
        Me.lvGrupo1.UseCompatibleStateImageBehavior = False
        Me.lvGrupo1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nro."
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 40
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "DIIO"
        Me.ColumnHeader4.Width = 120
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.lvGrupo2)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(192, 158)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "Grupo 2"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'lvGrupo2
        '
        Me.lvGrupo2.AutoArrange = False
        Me.lvGrupo2.BackColor = System.Drawing.SystemColors.Window
        Me.lvGrupo2.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvGrupo2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvGrupo2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvGrupo2.FullRowSelect = True
        Me.lvGrupo2.GridLines = True
        Me.lvGrupo2.HideSelection = False
        Me.lvGrupo2.Location = New System.Drawing.Point(3, 3)
        Me.lvGrupo2.MultiSelect = False
        Me.lvGrupo2.Name = "lvGrupo2"
        Me.lvGrupo2.Size = New System.Drawing.Size(186, 152)
        Me.lvGrupo2.TabIndex = 135
        Me.lvGrupo2.UseCompatibleStateImageBehavior = False
        Me.lvGrupo2.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nro."
        Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "DIIO"
        Me.ColumnHeader2.Width = 120
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.lvGrupo3)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(192, 158)
        Me.TabPage5.TabIndex = 2
        Me.TabPage5.Text = "Grupo 3"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'lvGrupo3
        '
        Me.lvGrupo3.AutoArrange = False
        Me.lvGrupo3.BackColor = System.Drawing.SystemColors.Window
        Me.lvGrupo3.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader13})
        Me.lvGrupo3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvGrupo3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvGrupo3.FullRowSelect = True
        Me.lvGrupo3.GridLines = True
        Me.lvGrupo3.HideSelection = False
        Me.lvGrupo3.Location = New System.Drawing.Point(3, 3)
        Me.lvGrupo3.MultiSelect = False
        Me.lvGrupo3.Name = "lvGrupo3"
        Me.lvGrupo3.Size = New System.Drawing.Size(186, 152)
        Me.lvGrupo3.TabIndex = 134
        Me.lvGrupo3.UseCompatibleStateImageBehavior = False
        Me.lvGrupo3.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Nro."
        Me.ColumnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader17.Width = 40
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "DIIO"
        Me.ColumnHeader13.Width = 120
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel3.Controls.Add(Me.lblActualizacion)
        Me.Panel3.Controls.Add(Me.lblHideShowMenu)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 557)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 42)
        Me.Panel3.TabIndex = 8
        '
        'lblActualizacion
        '
        Me.lblActualizacion.BackColor = System.Drawing.Color.Transparent
        Me.lblActualizacion.Font = New System.Drawing.Font("Calibri", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActualizacion.ForeColor = System.Drawing.Color.White
        Me.lblActualizacion.Location = New System.Drawing.Point(0, 5)
        Me.lblActualizacion.Name = "lblActualizacion"
        Me.lblActualizacion.Size = New System.Drawing.Size(174, 33)
        Me.lblActualizacion.TabIndex = 40
        Me.lblActualizacion.Text = "Actualizado el 31-12-2014"
        Me.lblActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHideShowMenu
        '
        Me.lblHideShowMenu.Font = New System.Drawing.Font("Kristen ITC", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHideShowMenu.ForeColor = System.Drawing.Color.LawnGreen
        Me.lblHideShowMenu.Location = New System.Drawing.Point(173, 4)
        Me.lblHideShowMenu.Name = "lblHideShowMenu"
        Me.lblHideShowMenu.Size = New System.Drawing.Size(26, 37)
        Me.lblHideShowMenu.TabIndex = 41
        Me.lblHideShowMenu.Text = "<"
        Me.lblHideShowMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 4)
        Me.Label2.TabIndex = 3
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel4.Controls.Add(Me.pboxIngles)
        Me.Panel4.Controls.Add(Me.pboxEspaniol)
        Me.Panel4.Controls.Add(Me.lblTituloMenu)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 24)
        Me.Panel4.TabIndex = 2
        '
        'lblTituloMenu
        '
        Me.lblTituloMenu.BackColor = System.Drawing.Color.Transparent
        Me.lblTituloMenu.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloMenu.ForeColor = System.Drawing.Color.White
        Me.lblTituloMenu.Location = New System.Drawing.Point(5, 0)
        Me.lblTituloMenu.Name = "lblTituloMenu"
        Me.lblTituloMenu.Size = New System.Drawing.Size(190, 19)
        Me.lblTituloMenu.TabIndex = 35
        Me.lblTituloMenu.Text = "MENU PRINCIPAL"
        Me.lblTituloMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tvMENU
        '
        Me.tvMENU.BackColor = System.Drawing.SystemColors.Control
        Me.tvMENU.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvMENU.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvMENU.ForeColor = System.Drawing.Color.Navy
        Me.tvMENU.FullRowSelect = True
        Me.tvMENU.Location = New System.Drawing.Point(78, 36)
        Me.tvMENU.Name = "tvMENU"
        Me.tvMENU.Size = New System.Drawing.Size(98, 299)
        Me.tvMENU.TabIndex = 13
        '
        'frmMAIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1116, 632)
        Me.Controls.Add(Me.pnlMenu)
        Me.Controls.Add(Me.pnlBarra)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMAIN"
        Me.Text = "MANUKA SGL - Sistema Gestion de Ganado & Lechería"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pboxIngles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pboxEspaniol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarra.ResumeLayout(False)
        Me.pnlBarra.PerformLayout()
        Me.pnlMenu.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlBuscarGrupo.ResumeLayout(False)
        Me.tabGrupos.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tmrLogin As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon

    Friend WithEvents version As Timer
    Friend WithEvents pnlBarra As Panel
    Friend WithEvents lblSeparador As Label
    Friend WithEvents btnActualizaciones As Button
    Friend WithEvents btnTablero As Button
    Friend WithEvents btnBuscaDIIO As Button
    Friend WithEvents txtDIIO As TextBox
    Friend WithEvents lblTitDIIO As Label
    Friend WithEvents btnPanelConsulta As Button
    Friend WithEvents btnHerramientas As Button
    Friend WithEvents btnCerrarSesion As Button
    Friend WithEvents lblCentro As Label
    Friend WithEvents lblTitCentro As Label
    Friend WithEvents btnVentas As Button
    Friend WithEvents btnMuertes As Button
    Friend WithEvents btnTraslados As Button
    Friend WithEvents btnPartos As Button
    Friend WithEvents btnSecados As Button
    Friend WithEvents btnPalpaciones As Button
    Friend WithEvents pnlMenu As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents pboxIngles As PictureBox
    Friend WithEvents pboxEspaniol As PictureBox
    Friend WithEvents lblTituloMenu As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnVerGrupoDiio As Button
    Friend WithEvents btnAgrupar As Button
    Friend WithEvents btnLeeBaston As Button
    Friend WithEvents txtDIIOGrupo As TextBox
    Friend WithEvents pnlBuscarGrupo As Panel
    Friend WithEvents tabGrupos As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents lvGrupo1 As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents lvGrupo2 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents lvGrupo3 As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblActualizacion As Label
    Friend WithEvents lblHideShowMenu As Label
    Friend WithEvents tvMENU As TreeView
End Class
