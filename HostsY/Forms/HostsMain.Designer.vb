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
		Me.panLists = New System.Windows.Forms.Panel()
		Me.rtbBlacks = New System.Windows.Forms.RichTextBox()
		Me.LbBlacks = New System.Windows.Forms.Label()
		Me.rtbWhites = New System.Windows.Forms.RichTextBox()
		Me.LbWhites = New System.Windows.Forms.Label()
		Me.rtbSources = New System.Windows.Forms.RichTextBox()
		Me.LbSource = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtTargetIP = New System.Windows.Forms.TextBox()
		Me.butGenerate = New System.Windows.Forms.Button()
		Me.rtbOuts = New System.Windows.Forms.RichTextBox()
		Me.rtbLogs = New System.Windows.Forms.RichTextBox()
		Me.chSort = New System.Windows.Forms.CheckBox()
		Me.chTabs = New System.Windows.Forms.CheckBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.LbSave = New System.Windows.Forms.Label()
		Me.bgGenerate = New System.ComponentModel.BackgroundWorker()
		Me.LbStatus = New System.Windows.Forms.Label()
		Me.LbAbout = New System.Windows.Forms.Label()
		Me.fdBrowse = New System.Windows.Forms.FolderBrowserDialog()
		Me.tipper = New System.Windows.Forms.ToolTip(Me.components)
		Me.LbReset = New System.Windows.Forms.Label()
		Me.chAdblock = New System.Windows.Forms.CheckBox()
		Me.chMin = New System.Windows.Forms.CheckBox()
		Me.chPreview = New System.Windows.Forms.CheckBox()
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
		'Label4
		'
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label4.Location = New System.Drawing.Point(153, 0)
		Me.Label4.Margin = New System.Windows.Forms.Padding(1)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(100, 28)
		Me.Label4.TabIndex = 3
		Me.Label4.Text = "Target IP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Default: 0.0.0.0"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'txtTargetIP
		'
		Me.txtTargetIP.BackColor = System.Drawing.Color.White
		Me.txtTargetIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtTargetIP.ForeColor = System.Drawing.Color.Black
		Me.txtTargetIP.Location = New System.Drawing.Point(153, 29)
		Me.txtTargetIP.Margin = New System.Windows.Forms.Padding(1)
		Me.txtTargetIP.Name = "txtTargetIP"
		Me.txtTargetIP.Size = New System.Drawing.Size(100, 22)
		Me.txtTargetIP.TabIndex = 4
		Me.txtTargetIP.TabStop = False
		Me.txtTargetIP.Text = "0.0.0.0"
		Me.txtTargetIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.tipper.SetToolTip(Me.txtTargetIP, "Set Target IP for domains and blacklist")
		'
		'butGenerate
		'
		Me.butGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.butGenerate.ForeColor = System.Drawing.Color.DarkGreen
		Me.butGenerate.Location = New System.Drawing.Point(254, 0)
		Me.butGenerate.Margin = New System.Windows.Forms.Padding(1)
		Me.butGenerate.Name = "butGenerate"
		Me.butGenerate.Size = New System.Drawing.Size(166, 28)
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
		Me.rtbLogs.Location = New System.Drawing.Point(1, 53)
		Me.rtbLogs.Margin = New System.Windows.Forms.Padding(1)
		Me.rtbLogs.Name = "rtbLogs"
		Me.rtbLogs.ReadOnly = True
		Me.rtbLogs.Size = New System.Drawing.Size(419, 344)
		Me.rtbLogs.TabIndex = 4
		Me.rtbLogs.Text = ""
		Me.rtbLogs.WordWrap = False
		'
		'chSort
		'
		Me.chSort.Checked = True
		Me.chSort.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chSort.Location = New System.Drawing.Point(1, 18)
		Me.chSort.Margin = New System.Windows.Forms.Padding(1)
		Me.chSort.Name = "chSort"
		Me.chSort.Size = New System.Drawing.Size(75, 17)
		Me.chSort.TabIndex = 9
		Me.chSort.TabStop = False
		Me.chSort.Text = "Sort (asc)"
		Me.tipper.SetToolTip(Me.chSort, "Sort domains by Ascending order")
		Me.chSort.UseVisualStyleBackColor = True
		'
		'chTabs
		'
		Me.chTabs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chTabs.Location = New System.Drawing.Point(1, 34)
		Me.chTabs.Margin = New System.Windows.Forms.Padding(1)
		Me.chTabs.Name = "chTabs"
		Me.chTabs.Size = New System.Drawing.Size(75, 17)
		Me.chTabs.TabIndex = 11
		Me.chTabs.TabStop = False
		Me.chTabs.Text = "Tabs"
		Me.tipper.SetToolTip(Me.chTabs, "Use Tab between Target IP and Domain")
		Me.chTabs.UseVisualStyleBackColor = True
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
		Me.tipper.SetToolTip(Me.LbSave, "Left-Click: Save to a specified folder" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Right-Click: Overwrite system hosts file " &
		"(might need admin privileges)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Middle-Click: Generate zip file to a specified fo" &
		"lder")
		'
		'bgGenerate
		'
		Me.bgGenerate.WorkerSupportsCancellation = True
		'
		'LbStatus
		'
		Me.LbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbStatus.ForeColor = System.Drawing.Color.Blue
		Me.LbStatus.Location = New System.Drawing.Point(254, 29)
		Me.LbStatus.Margin = New System.Windows.Forms.Padding(1)
		Me.LbStatus.Name = "LbStatus"
		Me.LbStatus.Size = New System.Drawing.Size(166, 22)
		Me.LbStatus.TabIndex = 14
		Me.LbStatus.Text = "Open system ""hosts"" folder"
		Me.LbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.tipper.SetToolTip(Me.LbStatus, "Opens ""C:\WINDOWS\system32\drivers\etc"" folder")
		'
		'LbAbout
		'
		Me.LbAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbAbout.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LbAbout.ForeColor = System.Drawing.Color.DeepPink
		Me.LbAbout.Location = New System.Drawing.Point(1, 0)
		Me.LbAbout.Margin = New System.Windows.Forms.Padding(1)
		Me.LbAbout.Name = "LbAbout"
		Me.LbAbout.Size = New System.Drawing.Size(75, 17)
		Me.LbAbout.TabIndex = 15
		Me.LbAbout.Text = "Github"
		Me.LbAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.tipper.SetToolTip(Me.LbAbout, "Visit https://github.com/Laicure/HostsY")
		'
		'fdBrowse
		'
		Me.fdBrowse.Description = "Select a folder for Export"
		'
		'tipper
		'
		Me.tipper.AutoPopDelay = 5000
		Me.tipper.InitialDelay = 250
		Me.tipper.ReshowDelay = 100
		Me.tipper.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
		Me.tipper.ToolTipTitle = "HostsY"
		Me.tipper.UseAnimation = False
		Me.tipper.UseFading = False
		'
		'LbReset
		'
		Me.LbReset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbReset.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LbReset.ForeColor = System.Drawing.Color.DarkMagenta
		Me.LbReset.Location = New System.Drawing.Point(77, 0)
		Me.LbReset.Margin = New System.Windows.Forms.Padding(1)
		Me.LbReset.Name = "LbReset"
		Me.LbReset.Size = New System.Drawing.Size(75, 17)
		Me.LbReset.TabIndex = 16
		Me.LbReset.Text = "Reset All"
		Me.LbReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.tipper.SetToolTip(Me.LbReset, "Resets the app")
		'
		'chAdblock
		'
		Me.chAdblock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chAdblock.ForeColor = System.Drawing.Color.Red
		Me.chAdblock.Location = New System.Drawing.Point(77, 34)
		Me.chAdblock.Margin = New System.Windows.Forms.Padding(1)
		Me.chAdblock.Name = "chAdblock"
		Me.chAdblock.Size = New System.Drawing.Size(75, 17)
		Me.chAdblock.TabIndex = 17
		Me.chAdblock.TabStop = False
		Me.chAdblock.Text = "Adblock"
		Me.tipper.SetToolTip(Me.chAdblock, "[Experimental]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Create an Adblock syntaxed hosts file instead of the standard sys" &
		"tem hosts file")
		Me.chAdblock.UseVisualStyleBackColor = True
		'
		'chMin
		'
		Me.chMin.Checked = True
		Me.chMin.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chMin.Location = New System.Drawing.Point(77, 18)
		Me.chMin.Margin = New System.Windows.Forms.Padding(1)
		Me.chMin.Name = "chMin"
		Me.chMin.Size = New System.Drawing.Size(75, 17)
		Me.chMin.TabIndex = 18
		Me.chMin.TabStop = False
		Me.chMin.Text = "Minimal"
		Me.tipper.SetToolTip(Me.chMin, "Only the Entry Count, Generation Time, and Sources comments are included at the t" &
		"op")
		Me.chMin.UseVisualStyleBackColor = True
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
		Me.tipper.SetToolTip(Me.chPreview, "Show actual generated hosts file below")
		Me.chPreview.UseVisualStyleBackColor = True
		'
		'MainPan
		'
		Me.MainPan.Controls.Add(Me.chPreview)
		Me.MainPan.Controls.Add(Me.Label1)
		Me.MainPan.Controls.Add(Me.LbSave)
		Me.MainPan.Controls.Add(Me.chSort)
		Me.MainPan.Controls.Add(Me.Label4)
		Me.MainPan.Controls.Add(Me.chMin)
		Me.MainPan.Controls.Add(Me.txtTargetIP)
		Me.MainPan.Controls.Add(Me.chAdblock)
		Me.MainPan.Controls.Add(Me.butGenerate)
		Me.MainPan.Controls.Add(Me.LbReset)
		Me.MainPan.Controls.Add(Me.rtbLogs)
		Me.MainPan.Controls.Add(Me.LbAbout)
		Me.MainPan.Controls.Add(Me.chTabs)
		Me.MainPan.Controls.Add(Me.LbStatus)
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
		Me.MainPan.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents panLists As System.Windows.Forms.Panel
	Friend WithEvents rtbBlacks As System.Windows.Forms.RichTextBox
	Friend WithEvents LbBlacks As System.Windows.Forms.Label
	Friend WithEvents rtbWhites As System.Windows.Forms.RichTextBox
	Friend WithEvents LbWhites As System.Windows.Forms.Label
	Friend WithEvents rtbSources As System.Windows.Forms.RichTextBox
	Friend WithEvents LbSource As System.Windows.Forms.Label
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents txtTargetIP As System.Windows.Forms.TextBox
	Friend WithEvents butGenerate As System.Windows.Forms.Button
	Friend WithEvents rtbOuts As System.Windows.Forms.RichTextBox
	Friend WithEvents rtbLogs As System.Windows.Forms.RichTextBox
	Friend WithEvents chSort As System.Windows.Forms.CheckBox
	Friend WithEvents chTabs As System.Windows.Forms.CheckBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents LbSave As System.Windows.Forms.Label
	Friend WithEvents bgGenerate As System.ComponentModel.BackgroundWorker
	Friend WithEvents LbStatus As System.Windows.Forms.Label
	Friend WithEvents LbAbout As System.Windows.Forms.Label
	Friend WithEvents fdBrowse As System.Windows.Forms.FolderBrowserDialog
	Friend WithEvents tipper As System.Windows.Forms.ToolTip
	Friend WithEvents LbReset As System.Windows.Forms.Label
	Friend WithEvents chAdblock As System.Windows.Forms.CheckBox
	Friend WithEvents chMin As System.Windows.Forms.CheckBox
	Friend WithEvents chPreview As CheckBox
	Friend WithEvents MainPan As Panel
End Class
