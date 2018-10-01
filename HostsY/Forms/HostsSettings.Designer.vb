<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HostsSettings
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
		Me.chSort = New System.Windows.Forms.CheckBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtTargetIP = New System.Windows.Forms.TextBox()
		Me.chTabs = New System.Windows.Forms.CheckBox()
		Me.LbAbout = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.LbStatus = New System.Windows.Forms.Label()
		Me.rtbLoopbacks = New System.Windows.Forms.RichTextBox()
		Me.numDomainPerLine = New System.Windows.Forms.NumericUpDown()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.chParseErrors = New System.Windows.Forms.CheckBox()
		Me.chPreview = New System.Windows.Forms.CheckBox()
		Me.chUseCache = New System.Windows.Forms.CheckBox()
		Me.tbCacheAge = New System.Windows.Forms.TrackBar()
		CType(Me.numDomainPerLine, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.tbCacheAge, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'chSort
		'
		Me.chSort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.chSort.Checked = True
		Me.chSort.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chSort.Cursor = System.Windows.Forms.Cursors.Hand
		Me.chSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chSort.Location = New System.Drawing.Point(1, 72)
		Me.chSort.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
		Me.chSort.Name = "chSort"
		Me.chSort.Size = New System.Drawing.Size(206, 17)
		Me.chSort.TabIndex = 21
		Me.chSort.TabStop = False
		Me.chSort.Text = "Sort Domains (ascending)"
		Me.chSort.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label4.ForeColor = System.Drawing.Color.Black
		Me.Label4.Location = New System.Drawing.Point(1, 17)
		Me.Label4.Margin = New System.Windows.Forms.Padding(1)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(103, 34)
		Me.Label4.TabIndex = 19
		Me.Label4.Text = "Target IP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Default: 0.0.0.0"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'txtTargetIP
		'
		Me.txtTargetIP.BackColor = System.Drawing.Color.White
		Me.txtTargetIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtTargetIP.ForeColor = System.Drawing.Color.Black
		Me.txtTargetIP.Location = New System.Drawing.Point(1, 50)
		Me.txtTargetIP.Margin = New System.Windows.Forms.Padding(0)
		Me.txtTargetIP.Name = "txtTargetIP"
		Me.txtTargetIP.Size = New System.Drawing.Size(103, 22)
		Me.txtTargetIP.TabIndex = 20
		Me.txtTargetIP.TabStop = False
		Me.txtTargetIP.Text = "0.0.0.0"
		Me.txtTargetIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'chTabs
		'
		Me.chTabs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.chTabs.Cursor = System.Windows.Forms.Cursors.Hand
		Me.chTabs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chTabs.Location = New System.Drawing.Point(1, 89)
		Me.chTabs.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
		Me.chTabs.Name = "chTabs"
		Me.chTabs.Size = New System.Drawing.Size(206, 17)
		Me.chTabs.TabIndex = 22
		Me.chTabs.TabStop = False
		Me.chTabs.Text = "Use Tabs instead of Whitespace"
		Me.chTabs.UseVisualStyleBackColor = True
		'
		'LbAbout
		'
		Me.LbAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbAbout.Cursor = System.Windows.Forms.Cursors.Hand
		Me.LbAbout.Dock = System.Windows.Forms.DockStyle.Top
		Me.LbAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbAbout.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LbAbout.ForeColor = System.Drawing.Color.DeepPink
		Me.LbAbout.Location = New System.Drawing.Point(1, 1)
		Me.LbAbout.Margin = New System.Windows.Forms.Padding(1)
		Me.LbAbout.Name = "LbAbout"
		Me.LbAbout.Size = New System.Drawing.Size(206, 17)
		Me.LbAbout.TabIndex = 25
		Me.LbAbout.Text = "GitLab"
		Me.LbAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label1
		'
		Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label1.ForeColor = System.Drawing.Color.Black
		Me.Label1.Location = New System.Drawing.Point(1, 175)
		Me.Label1.Margin = New System.Windows.Forms.Padding(1)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(206, 17)
		Me.Label1.TabIndex = 26
		Me.Label1.Text = "Loopback Whitelist"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'LbStatus
		'
		Me.LbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbStatus.Cursor = System.Windows.Forms.Cursors.Hand
		Me.LbStatus.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.LbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbStatus.ForeColor = System.Drawing.Color.Blue
		Me.LbStatus.Location = New System.Drawing.Point(1, 338)
		Me.LbStatus.Margin = New System.Windows.Forms.Padding(1)
		Me.LbStatus.Name = "LbStatus"
		Me.LbStatus.Size = New System.Drawing.Size(206, 25)
		Me.LbStatus.TabIndex = 28
		Me.LbStatus.Text = "Open system ""hosts"" folder"
		Me.LbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'rtbLoopbacks
		'
		Me.rtbLoopbacks.BackColor = System.Drawing.Color.White
		Me.rtbLoopbacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.rtbLoopbacks.DetectUrls = False
		Me.rtbLoopbacks.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.rtbLoopbacks.ForeColor = System.Drawing.Color.Black
		Me.rtbLoopbacks.Location = New System.Drawing.Point(1, 190)
		Me.rtbLoopbacks.Margin = New System.Windows.Forms.Padding(1)
		Me.rtbLoopbacks.Name = "rtbLoopbacks"
		Me.rtbLoopbacks.Size = New System.Drawing.Size(206, 148)
		Me.rtbLoopbacks.TabIndex = 29
		Me.rtbLoopbacks.Text = ""
		Me.rtbLoopbacks.WordWrap = False
		'
		'numDomainPerLine
		'
		Me.numDomainPerLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.numDomainPerLine.BackColor = System.Drawing.Color.White
		Me.numDomainPerLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.numDomainPerLine.ForeColor = System.Drawing.Color.Black
		Me.numDomainPerLine.Location = New System.Drawing.Point(103, 50)
		Me.numDomainPerLine.Margin = New System.Windows.Forms.Padding(0)
		Me.numDomainPerLine.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
		Me.numDomainPerLine.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
		Me.numDomainPerLine.Name = "numDomainPerLine"
		Me.numDomainPerLine.Size = New System.Drawing.Size(104, 22)
		Me.numDomainPerLine.TabIndex = 30
		Me.numDomainPerLine.TabStop = False
		Me.numDomainPerLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		Me.numDomainPerLine.Value = New Decimal(New Integer() {9, 0, 0, 0})
		'
		'Label2
		'
		Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label2.ForeColor = System.Drawing.Color.Black
		Me.Label2.Location = New System.Drawing.Point(103, 17)
		Me.Label2.Margin = New System.Windows.Forms.Padding(1)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(104, 34)
		Me.Label2.TabIndex = 31
		Me.Label2.Text = "Domain per Line"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'chParseErrors
		'
		Me.chParseErrors.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.chParseErrors.Checked = True
		Me.chParseErrors.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chParseErrors.Cursor = System.Windows.Forms.Cursors.Hand
		Me.chParseErrors.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chParseErrors.Location = New System.Drawing.Point(1, 106)
		Me.chParseErrors.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
		Me.chParseErrors.Name = "chParseErrors"
		Me.chParseErrors.Size = New System.Drawing.Size(206, 17)
		Me.chParseErrors.TabIndex = 32
		Me.chParseErrors.TabStop = False
		Me.chParseErrors.Text = "Show Parse Errors"
		Me.chParseErrors.UseVisualStyleBackColor = True
		'
		'chPreview
		'
		Me.chPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.chPreview.Cursor = System.Windows.Forms.Cursors.Hand
		Me.chPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chPreview.Location = New System.Drawing.Point(1, 123)
		Me.chPreview.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
		Me.chPreview.Name = "chPreview"
		Me.chPreview.Size = New System.Drawing.Size(206, 17)
		Me.chPreview.TabIndex = 33
		Me.chPreview.TabStop = False
		Me.chPreview.Text = "Ask for a Preview"
		Me.chPreview.UseVisualStyleBackColor = True
		'
		'chUseCache
		'
		Me.chUseCache.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.chUseCache.Checked = True
		Me.chUseCache.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chUseCache.Cursor = System.Windows.Forms.Cursors.Hand
		Me.chUseCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chUseCache.Location = New System.Drawing.Point(1, 140)
		Me.chUseCache.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
		Me.chUseCache.Name = "chUseCache"
		Me.chUseCache.Size = New System.Drawing.Size(206, 17)
		Me.chUseCache.TabIndex = 34
		Me.chUseCache.TabStop = False
		Me.chUseCache.Text = "Reuse cache (no expiry)"
		Me.chUseCache.UseVisualStyleBackColor = True
		'
		'tbCacheAge
		'
		Me.tbCacheAge.AutoSize = False
		Me.tbCacheAge.Location = New System.Drawing.Point(1, 157)
		Me.tbCacheAge.Margin = New System.Windows.Forms.Padding(0)
		Me.tbCacheAge.Maximum = 160
		Me.tbCacheAge.Name = "tbCacheAge"
		Me.tbCacheAge.Size = New System.Drawing.Size(206, 17)
		Me.tbCacheAge.TabIndex = 35
		Me.tbCacheAge.TabStop = False
		Me.tbCacheAge.TickStyle = System.Windows.Forms.TickStyle.None
		'
		'HostsSettings
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.ClientSize = New System.Drawing.Size(208, 364)
		Me.Controls.Add(Me.tbCacheAge)
		Me.Controls.Add(Me.chUseCache)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.chPreview)
		Me.Controls.Add(Me.chParseErrors)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.rtbLoopbacks)
		Me.Controls.Add(Me.LbStatus)
		Me.Controls.Add(Me.LbAbout)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.txtTargetIP)
		Me.Controls.Add(Me.chSort)
		Me.Controls.Add(Me.chTabs)
		Me.Controls.Add(Me.numDomainPerLine)
		Me.DoubleBuffered = True
		Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
		Me.ForeColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "HostsSettings"
		Me.Padding = New System.Windows.Forms.Padding(1)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "HostsY Settings"
		CType(Me.numDomainPerLine, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.tbCacheAge, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents chSort As CheckBox
	Friend WithEvents Label4 As Label
	Friend WithEvents txtTargetIP As TextBox
	Friend WithEvents chTabs As CheckBox
	Friend WithEvents LbAbout As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents LbStatus As Label
	Friend WithEvents rtbLoopbacks As RichTextBox
	Friend WithEvents numDomainPerLine As NumericUpDown
	Friend WithEvents Label2 As Label
	Friend WithEvents chParseErrors As System.Windows.Forms.CheckBox
	Friend WithEvents chPreview As System.Windows.Forms.CheckBox
	Friend WithEvents chUseCache As System.Windows.Forms.CheckBox
	Friend WithEvents tbCacheAge As System.Windows.Forms.TrackBar
End Class
