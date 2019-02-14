<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HostsMain
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.LbSource = New System.Windows.Forms.Label()
		Me.bgGenerate = New System.ComponentModel.BackgroundWorker()
		Me.fdBrowse = New System.Windows.Forms.FolderBrowserDialog()
		Me.LbSettings = New System.Windows.Forms.Label()
		Me.txWhites = New System.Windows.Forms.TextBox()
		Me.LbBlacks = New System.Windows.Forms.Label()
		Me.txSources = New System.Windows.Forms.TextBox()
		Me.LbWhites = New System.Windows.Forms.Label()
		Me.txBlacks = New System.Windows.Forms.TextBox()
		Me.LbSave = New System.Windows.Forms.Label()
		Me.txLogs = New System.Windows.Forms.TextBox()
		Me.LbGenerate = New System.Windows.Forms.Label()
		Me.LbPreview = New System.Windows.Forms.Label()
		Me.tipper = New System.Windows.Forms.ToolTip(Me.components)
		Me.lbAdblocked = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'LbSource
		'
		Me.LbSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbSource.Location = New System.Drawing.Point(1, 1)
		Me.LbSource.Margin = New System.Windows.Forms.Padding(0)
		Me.LbSource.Name = "LbSource"
		Me.LbSource.Size = New System.Drawing.Size(196, 15)
		Me.LbSource.TabIndex = 7
		Me.LbSource.Text = "Sources"
		'
		'bgGenerate
		'
		Me.bgGenerate.WorkerSupportsCancellation = True
		'
		'fdBrowse
		'
		Me.fdBrowse.Description = "Select a folder for Export"
		'
		'LbSettings
		'
		Me.LbSettings.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LbSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbSettings.Cursor = System.Windows.Forms.Cursors.Hand
		Me.LbSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LbSettings.ForeColor = System.Drawing.Color.Crimson
		Me.LbSettings.Location = New System.Drawing.Point(433, 1)
		Me.LbSettings.Margin = New System.Windows.Forms.Padding(0)
		Me.LbSettings.Name = "LbSettings"
		Me.LbSettings.Size = New System.Drawing.Size(100, 25)
		Me.LbSettings.TabIndex = 10
		Me.LbSettings.Text = "Settings"
		Me.LbSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'txWhites
		'
		Me.txWhites.BackColor = System.Drawing.Color.White
		Me.txWhites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txWhites.ForeColor = System.Drawing.Color.Black
		Me.txWhites.Location = New System.Drawing.Point(1, 159)
		Me.txWhites.Margin = New System.Windows.Forms.Padding(0)
		Me.txWhites.MaxLength = 2147483647
		Me.txWhites.Multiline = True
		Me.txWhites.Name = "txWhites"
		Me.txWhites.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txWhites.Size = New System.Drawing.Size(196, 131)
		Me.txWhites.TabIndex = 2
		Me.txWhites.TabStop = False
		Me.txWhites.WordWrap = False
		'
		'LbBlacks
		'
		Me.LbBlacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbBlacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbBlacks.Location = New System.Drawing.Point(1, 289)
		Me.LbBlacks.Margin = New System.Windows.Forms.Padding(0)
		Me.LbBlacks.Name = "LbBlacks"
		Me.LbBlacks.Size = New System.Drawing.Size(196, 15)
		Me.LbBlacks.TabIndex = 9
		Me.LbBlacks.Text = "Blacklist"
		'
		'txSources
		'
		Me.txSources.BackColor = System.Drawing.Color.White
		Me.txSources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txSources.ForeColor = System.Drawing.Color.Black
		Me.txSources.Location = New System.Drawing.Point(1, 15)
		Me.txSources.Margin = New System.Windows.Forms.Padding(0)
		Me.txSources.MaxLength = 2147483647
		Me.txSources.Multiline = True
		Me.txSources.Name = "txSources"
		Me.txSources.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txSources.Size = New System.Drawing.Size(196, 131)
		Me.txSources.TabIndex = 1
		Me.txSources.TabStop = False
		Me.txSources.WordWrap = False
		'
		'LbWhites
		'
		Me.LbWhites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbWhites.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbWhites.Location = New System.Drawing.Point(1, 145)
		Me.LbWhites.Margin = New System.Windows.Forms.Padding(0)
		Me.LbWhites.Name = "LbWhites"
		Me.LbWhites.Size = New System.Drawing.Size(196, 15)
		Me.LbWhites.TabIndex = 8
		Me.LbWhites.Text = "Whitelist"
		'
		'txBlacks
		'
		Me.txBlacks.BackColor = System.Drawing.Color.White
		Me.txBlacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txBlacks.ForeColor = System.Drawing.Color.Black
		Me.txBlacks.Location = New System.Drawing.Point(1, 303)
		Me.txBlacks.Margin = New System.Windows.Forms.Padding(0)
		Me.txBlacks.MaxLength = 2147483647
		Me.txBlacks.Multiline = True
		Me.txBlacks.Name = "txBlacks"
		Me.txBlacks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txBlacks.Size = New System.Drawing.Size(196, 131)
		Me.txBlacks.TabIndex = 3
		Me.txBlacks.TabStop = False
		Me.txBlacks.WordWrap = False
		'
		'LbSave
		'
		Me.LbSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LbSave.AutoEllipsis = True
		Me.LbSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbSave.ForeColor = System.Drawing.Color.DarkGreen
		Me.LbSave.Location = New System.Drawing.Point(196, 420)
		Me.LbSave.Margin = New System.Windows.Forms.Padding(0)
		Me.LbSave.Name = "LbSave"
		Me.LbSave.Size = New System.Drawing.Size(337, 15)
		Me.LbSave.TabIndex = 12
		Me.LbSave.Text = "..."
		Me.LbSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.tipper.SetToolTip(Me.LbSave, "Left-click: Save to specified location" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Right-click: Replace active system hosts " & _
		"file" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Middle-click: Save to specified location (zipped)")
		'
		'txLogs
		'
		Me.txLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txLogs.BackColor = System.Drawing.Color.White
		Me.txLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txLogs.ForeColor = System.Drawing.Color.Black
		Me.txLogs.Location = New System.Drawing.Point(196, 25)
		Me.txLogs.Margin = New System.Windows.Forms.Padding(0)
		Me.txLogs.Multiline = True
		Me.txLogs.Name = "txLogs"
		Me.txLogs.ReadOnly = True
		Me.txLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txLogs.ShortcutsEnabled = False
		Me.txLogs.Size = New System.Drawing.Size(337, 396)
		Me.txLogs.TabIndex = 5
		Me.txLogs.TabStop = False
		Me.txLogs.WordWrap = False
		'
		'LbGenerate
		'
		Me.LbGenerate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LbGenerate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbGenerate.Cursor = System.Windows.Forms.Cursors.Hand
		Me.LbGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbGenerate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LbGenerate.ForeColor = System.Drawing.Color.Green
		Me.LbGenerate.Location = New System.Drawing.Point(196, 1)
		Me.LbGenerate.Margin = New System.Windows.Forms.Padding(0)
		Me.LbGenerate.Name = "LbGenerate"
		Me.LbGenerate.Size = New System.Drawing.Size(238, 25)
		Me.LbGenerate.TabIndex = 13
		Me.LbGenerate.Text = "Generate Hosts File"
		Me.LbGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'LbPreview
		'
		Me.LbPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.LbPreview.AutoEllipsis = True
		Me.LbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbPreview.Cursor = System.Windows.Forms.Cursors.Hand
		Me.LbPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbPreview.ForeColor = System.Drawing.Color.Blue
		Me.LbPreview.Location = New System.Drawing.Point(196, 420)
		Me.LbPreview.Margin = New System.Windows.Forms.Padding(0)
		Me.LbPreview.Name = "LbPreview"
		Me.LbPreview.Size = New System.Drawing.Size(50, 15)
		Me.LbPreview.TabIndex = 14
		Me.LbPreview.Text = "Preview"
		Me.LbPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.tipper.SetToolTip(Me.LbPreview, "Show a preview of the generated hosts file (7777 characters)")
		Me.LbPreview.Visible = False
		'
		'tipper
		'
		Me.tipper.BackColor = System.Drawing.Color.White
		Me.tipper.ForeColor = System.Drawing.Color.Black
		Me.tipper.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		Me.tipper.ToolTipTitle = "HostsY"
		Me.tipper.UseAnimation = False
		Me.tipper.UseFading = False
		'
		'lbAdblocked
		'
		Me.lbAdblocked.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.lbAdblocked.AutoEllipsis = True
		Me.lbAdblocked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.lbAdblocked.Cursor = System.Windows.Forms.Cursors.Hand
		Me.lbAdblocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.lbAdblocked.ForeColor = System.Drawing.Color.Green
		Me.lbAdblocked.Location = New System.Drawing.Point(245, 420)
		Me.lbAdblocked.Margin = New System.Windows.Forms.Padding(0)
		Me.lbAdblocked.Name = "lbAdblocked"
		Me.lbAdblocked.Size = New System.Drawing.Size(75, 15)
		Me.lbAdblocked.TabIndex = 15
		Me.lbAdblocked.Text = "AdBlocked"
		Me.lbAdblocked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.tipper.SetToolTip(Me.lbAdblocked, "Save an Adblock-syntaxed domain names")
		Me.lbAdblocked.Visible = False
		'
		'HostsMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.ClientSize = New System.Drawing.Size(534, 436)
		Me.Controls.Add(Me.lbAdblocked)
		Me.Controls.Add(Me.LbPreview)
		Me.Controls.Add(Me.LbGenerate)
		Me.Controls.Add(Me.LbSave)
		Me.Controls.Add(Me.LbSettings)
		Me.Controls.Add(Me.txLogs)
		Me.Controls.Add(Me.LbBlacks)
		Me.Controls.Add(Me.txBlacks)
		Me.Controls.Add(Me.LbWhites)
		Me.Controls.Add(Me.LbSource)
		Me.Controls.Add(Me.txSources)
		Me.Controls.Add(Me.txWhites)
		Me.DoubleBuffered = True
		Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ForeColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(550, 475)
		Me.MinimumSize = New System.Drawing.Size(550, 475)
		Me.Name = "HostsMain"
		Me.Padding = New System.Windows.Forms.Padding(1)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "HostsY"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents LbSource As System.Windows.Forms.Label
	Friend WithEvents bgGenerate As System.ComponentModel.BackgroundWorker
	Friend WithEvents fdBrowse As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents LbSettings As Label
	Private WithEvents txWhites As System.Windows.Forms.TextBox
	Friend WithEvents LbBlacks As System.Windows.Forms.Label
	Private WithEvents txSources As System.Windows.Forms.TextBox
	Friend WithEvents LbWhites As System.Windows.Forms.Label
	Private WithEvents txBlacks As System.Windows.Forms.TextBox
	Friend WithEvents LbSave As System.Windows.Forms.Label
	Private WithEvents txLogs As System.Windows.Forms.TextBox
	Friend WithEvents LbGenerate As System.Windows.Forms.Label
	Friend WithEvents LbPreview As System.Windows.Forms.Label
	Friend WithEvents tipper As System.Windows.Forms.ToolTip
	Friend WithEvents lbAdblocked As System.Windows.Forms.Label
End Class
