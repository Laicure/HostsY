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
		Me.panLists = New System.Windows.Forms.Panel()
		Me.rtbBlacks = New System.Windows.Forms.RichTextBox()
		Me.LbBlacks = New System.Windows.Forms.Label()
		Me.rtbWhites = New System.Windows.Forms.RichTextBox()
		Me.LbWhites = New System.Windows.Forms.Label()
		Me.rtbSources = New System.Windows.Forms.RichTextBox()
		Me.LbSource = New System.Windows.Forms.Label()
		Me.butGenerate = New System.Windows.Forms.Button()
		Me.rtbOuts = New System.Windows.Forms.RichTextBox()
		Me.rtbLogs = New System.Windows.Forms.RichTextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.LbSave = New System.Windows.Forms.Label()
		Me.bgGenerate = New System.ComponentModel.BackgroundWorker()
		Me.fdBrowse = New System.Windows.Forms.FolderBrowserDialog()
		Me.chPreview = New System.Windows.Forms.CheckBox()
		Me.LbSettings = New System.Windows.Forms.Label()
		Me.MainPan = New System.Windows.Forms.Panel()
		Me.panLists.SuspendLayout()
		Me.MainPan.SuspendLayout()
		Me.SuspendLayout()
		'
		'panLists
		'
		Me.panLists.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.panLists.Controls.Add(Me.rtbBlacks)
		Me.panLists.Controls.Add(Me.LbBlacks)
		Me.panLists.Controls.Add(Me.rtbWhites)
		Me.panLists.Controls.Add(Me.LbWhites)
		Me.panLists.Controls.Add(Me.rtbSources)
		Me.panLists.Controls.Add(Me.LbSource)
		Me.panLists.Dock = System.Windows.Forms.DockStyle.Left
		Me.panLists.Location = New System.Drawing.Point(1, 1)
		Me.panLists.Margin = New System.Windows.Forms.Padding(1)
		Me.panLists.Name = "panLists"
		Me.panLists.Size = New System.Drawing.Size(200, 434)
		Me.panLists.TabIndex = 0
		'
		'rtbBlacks
		'
		Me.rtbBlacks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rtbBlacks.BackColor = System.Drawing.Color.White
		Me.rtbBlacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.rtbBlacks.DetectUrls = False
		Me.rtbBlacks.ForeColor = System.Drawing.Color.Black
		Me.rtbBlacks.Location = New System.Drawing.Point(1, 304)
		Me.rtbBlacks.Margin = New System.Windows.Forms.Padding(1)
		Me.rtbBlacks.Name = "rtbBlacks"
		Me.rtbBlacks.Size = New System.Drawing.Size(196, 127)
		Me.rtbBlacks.TabIndex = 2
		Me.rtbBlacks.Text = ""
		Me.rtbBlacks.WordWrap = False
		'
		'LbBlacks
		'
		Me.LbBlacks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LbBlacks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbBlacks.Location = New System.Drawing.Point(1, 289)
		Me.LbBlacks.Margin = New System.Windows.Forms.Padding(1)
		Me.LbBlacks.Name = "LbBlacks"
		Me.LbBlacks.Size = New System.Drawing.Size(196, 13)
		Me.LbBlacks.TabIndex = 6
		Me.LbBlacks.Text = "Blacklist"
		'
		'rtbWhites
		'
		Me.rtbWhites.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rtbWhites.BackColor = System.Drawing.Color.White
		Me.rtbWhites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.rtbWhites.DetectUrls = False
		Me.rtbWhites.ForeColor = System.Drawing.Color.Black
		Me.rtbWhites.Location = New System.Drawing.Point(1, 160)
		Me.rtbWhites.Margin = New System.Windows.Forms.Padding(1)
		Me.rtbWhites.Name = "rtbWhites"
		Me.rtbWhites.Size = New System.Drawing.Size(196, 127)
		Me.rtbWhites.TabIndex = 1
		Me.rtbWhites.Text = ""
		Me.rtbWhites.WordWrap = False
		'
		'LbWhites
		'
		Me.LbWhites.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LbWhites.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbWhites.Location = New System.Drawing.Point(1, 145)
		Me.LbWhites.Margin = New System.Windows.Forms.Padding(1)
		Me.LbWhites.Name = "LbWhites"
		Me.LbWhites.Size = New System.Drawing.Size(196, 13)
		Me.LbWhites.TabIndex = 4
		Me.LbWhites.Text = "Whitelist"
		'
		'rtbSources
		'
		Me.rtbSources.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rtbSources.BackColor = System.Drawing.Color.White
		Me.rtbSources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.rtbSources.DetectUrls = False
		Me.rtbSources.ForeColor = System.Drawing.Color.Black
		Me.rtbSources.Location = New System.Drawing.Point(1, 16)
		Me.rtbSources.Margin = New System.Windows.Forms.Padding(1)
		Me.rtbSources.Name = "rtbSources"
		Me.rtbSources.Size = New System.Drawing.Size(196, 127)
		Me.rtbSources.TabIndex = 0
		Me.rtbSources.Text = ""
		Me.rtbSources.WordWrap = False
		'
		'LbSource
		'
		Me.LbSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LbSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbSource.Location = New System.Drawing.Point(1, 1)
		Me.LbSource.Margin = New System.Windows.Forms.Padding(1)
		Me.LbSource.Name = "LbSource"
		Me.LbSource.Size = New System.Drawing.Size(196, 13)
		Me.LbSource.TabIndex = 2
		Me.LbSource.Text = "Sources"
		'
		'butGenerate
		'
		Me.butGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.butGenerate.ForeColor = System.Drawing.Color.DarkGreen
		Me.butGenerate.Location = New System.Drawing.Point(1, 0)
		Me.butGenerate.Margin = New System.Windows.Forms.Padding(1)
		Me.butGenerate.Name = "butGenerate"
		Me.butGenerate.Size = New System.Drawing.Size(358, 25)
		Me.butGenerate.TabIndex = 3
		Me.butGenerate.Text = "Start Generation"
		Me.butGenerate.UseVisualStyleBackColor = True
		'
		'rtbOuts
		'
		Me.rtbOuts.BackColor = System.Drawing.Color.White
		Me.rtbOuts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.rtbOuts.DetectUrls = False
		Me.rtbOuts.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.rtbOuts.ForeColor = System.Drawing.Color.Black
		Me.rtbOuts.Location = New System.Drawing.Point(201, 415)
		Me.rtbOuts.Margin = New System.Windows.Forms.Padding(1)
		Me.rtbOuts.Name = "rtbOuts"
		Me.rtbOuts.ReadOnly = True
		Me.rtbOuts.Size = New System.Drawing.Size(422, 20)
		Me.rtbOuts.TabIndex = 5
		Me.rtbOuts.Text = ""
		Me.rtbOuts.WordWrap = False
		'
		'rtbLogs
		'
		Me.rtbLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rtbLogs.BackColor = System.Drawing.Color.White
		Me.rtbLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.rtbLogs.DetectUrls = False
		Me.rtbLogs.ForeColor = System.Drawing.Color.Black
		Me.rtbLogs.Location = New System.Drawing.Point(1, 26)
		Me.rtbLogs.Margin = New System.Windows.Forms.Padding(1)
		Me.rtbLogs.Name = "rtbLogs"
		Me.rtbLogs.ReadOnly = True
		Me.rtbLogs.Size = New System.Drawing.Size(419, 371)
		Me.rtbLogs.TabIndex = 4
		Me.rtbLogs.Text = ""
		Me.rtbLogs.WordWrap = False
		'
		'Label1
		'
		Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label1.Location = New System.Drawing.Point(0, 399)
		Me.Label1.Margin = New System.Windows.Forms.Padding(0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(95, 13)
		Me.Label1.TabIndex = 12
		Me.Label1.Text = "Output ⤵ Logs ⤴"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'LbSave
		'
		Me.LbSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.LbSave.AutoEllipsis = True
		Me.LbSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbSave.ForeColor = System.Drawing.Color.DarkGreen
		Me.LbSave.Location = New System.Drawing.Point(163, 399)
		Me.LbSave.Margin = New System.Windows.Forms.Padding(1)
		Me.LbSave.Name = "LbSave"
		Me.LbSave.Size = New System.Drawing.Size(257, 13)
		Me.LbSave.TabIndex = 13
		Me.LbSave.Text = "..."
		Me.LbSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'bgGenerate
		'
		Me.bgGenerate.WorkerSupportsCancellation = True
		'
		'fdBrowse
		'
		Me.fdBrowse.Description = "Select a folder for Export"
		'
		'chPreview
		'
		Me.chPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.chPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chPreview.Location = New System.Drawing.Point(96, 397)
		Me.chPreview.Margin = New System.Windows.Forms.Padding(1)
		Me.chPreview.Name = "chPreview"
		Me.chPreview.Size = New System.Drawing.Size(65, 17)
		Me.chPreview.TabIndex = 19
		Me.chPreview.TabStop = False
		Me.chPreview.Text = "Preview"
		Me.chPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.chPreview.UseVisualStyleBackColor = True
		'
		'LbSettings
		'
		Me.LbSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbSettings.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LbSettings.ForeColor = System.Drawing.Color.Crimson
		Me.LbSettings.Location = New System.Drawing.Point(360, 0)
		Me.LbSettings.Margin = New System.Windows.Forms.Padding(1)
		Me.LbSettings.Name = "LbSettings"
		Me.LbSettings.Size = New System.Drawing.Size(60, 25)
		Me.LbSettings.TabIndex = 21
		Me.LbSettings.Text = "Settings"
		Me.LbSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'MainPan
		'
		Me.MainPan.Controls.Add(Me.LbSettings)
		Me.MainPan.Controls.Add(Me.chPreview)
		Me.MainPan.Controls.Add(Me.Label1)
		Me.MainPan.Controls.Add(Me.LbSave)
		Me.MainPan.Controls.Add(Me.butGenerate)
		Me.MainPan.Controls.Add(Me.rtbLogs)
		Me.MainPan.Dock = System.Windows.Forms.DockStyle.Fill
		Me.MainPan.Location = New System.Drawing.Point(201, 1)
		Me.MainPan.Margin = New System.Windows.Forms.Padding(0)
		Me.MainPan.Name = "MainPan"
		Me.MainPan.Size = New System.Drawing.Size(422, 414)
		Me.MainPan.TabIndex = 20
		'
		'HostsMain
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.ClientSize = New System.Drawing.Size(624, 436)
		Me.Controls.Add(Me.MainPan)
		Me.Controls.Add(Me.rtbOuts)
		Me.Controls.Add(Me.panLists)
		Me.DoubleBuffered = True
		Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ForeColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.MaximumSize = New System.Drawing.Size(640, 475)
		Me.MinimumSize = New System.Drawing.Size(640, 475)
		Me.Name = "HostsMain"
		Me.Padding = New System.Windows.Forms.Padding(1)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "HostsY v<Version>"
		Me.panLists.ResumeLayout(False)
		Me.MainPan.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents panLists As System.Windows.Forms.Panel
	Friend WithEvents rtbBlacks As System.Windows.Forms.RichTextBox
	Friend WithEvents LbBlacks As System.Windows.Forms.Label
	Friend WithEvents rtbWhites As System.Windows.Forms.RichTextBox
	Friend WithEvents LbWhites As System.Windows.Forms.Label
	Friend WithEvents rtbSources As System.Windows.Forms.RichTextBox
	Friend WithEvents LbSource As System.Windows.Forms.Label
	Friend WithEvents butGenerate As System.Windows.Forms.Button
	Friend WithEvents rtbOuts As System.Windows.Forms.RichTextBox
	Friend WithEvents rtbLogs As System.Windows.Forms.RichTextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents LbSave As System.Windows.Forms.Label
	Friend WithEvents bgGenerate As System.ComponentModel.BackgroundWorker
	Friend WithEvents fdBrowse As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents chPreview As CheckBox
	Friend WithEvents MainPan As Panel
	Friend WithEvents LbSettings As Label
End Class
