<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HostsSettings
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
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

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.chSort = New System.Windows.Forms.CheckBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.chMin = New System.Windows.Forms.CheckBox()
		Me.txtTargetIP = New System.Windows.Forms.TextBox()
		Me.chTabs = New System.Windows.Forms.CheckBox()
		Me.LbAbout = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.LbStatus = New System.Windows.Forms.Label()
		Me.rtbLoopbacks = New System.Windows.Forms.RichTextBox()
		Me.SuspendLayout()
		'
		'chSort
		'
		Me.chSort.Checked = True
		Me.chSort.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chSort.Cursor = System.Windows.Forms.Cursors.Hand
		Me.chSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chSort.Location = New System.Drawing.Point(104, 40)
		Me.chSort.Margin = New System.Windows.Forms.Padding(1)
		Me.chSort.Name = "chSort"
		Me.chSort.Size = New System.Drawing.Size(78, 17)
		Me.chSort.TabIndex = 21
		Me.chSort.TabStop = False
		Me.chSort.Text = "Sort (asc)"
		Me.chSort.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label4.Location = New System.Drawing.Point(2, 21)
		Me.Label4.Margin = New System.Windows.Forms.Padding(1)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(100, 34)
		Me.Label4.TabIndex = 19
		Me.Label4.Text = "Target IP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Default: 0.0.0.0"
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'chMin
		'
		Me.chMin.Checked = True
		Me.chMin.CheckState = System.Windows.Forms.CheckState.Checked
		Me.chMin.Cursor = System.Windows.Forms.Cursors.Hand
		Me.chMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chMin.Location = New System.Drawing.Point(104, 21)
		Me.chMin.Margin = New System.Windows.Forms.Padding(1)
		Me.chMin.Name = "chMin"
		Me.chMin.Size = New System.Drawing.Size(78, 17)
		Me.chMin.TabIndex = 24
		Me.chMin.TabStop = False
		Me.chMin.Text = "Minimal"
		Me.chMin.UseVisualStyleBackColor = True
		'
		'txtTargetIP
		'
		Me.txtTargetIP.BackColor = System.Drawing.Color.White
		Me.txtTargetIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txtTargetIP.ForeColor = System.Drawing.Color.Black
		Me.txtTargetIP.Location = New System.Drawing.Point(2, 54)
		Me.txtTargetIP.Margin = New System.Windows.Forms.Padding(1)
		Me.txtTargetIP.Name = "txtTargetIP"
		Me.txtTargetIP.Size = New System.Drawing.Size(100, 22)
		Me.txtTargetIP.TabIndex = 20
		Me.txtTargetIP.TabStop = False
		Me.txtTargetIP.Text = "0.0.0.0"
		Me.txtTargetIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
		'
		'chTabs
		'
		Me.chTabs.Cursor = System.Windows.Forms.Cursors.Hand
		Me.chTabs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.chTabs.Location = New System.Drawing.Point(104, 59)
		Me.chTabs.Margin = New System.Windows.Forms.Padding(1)
		Me.chTabs.Name = "chTabs"
		Me.chTabs.Size = New System.Drawing.Size(78, 17)
		Me.chTabs.TabIndex = 22
		Me.chTabs.TabStop = False
		Me.chTabs.Text = "Tabs"
		Me.chTabs.UseVisualStyleBackColor = True
		'
		'LbAbout
		'
		Me.LbAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbAbout.Cursor = System.Windows.Forms.Cursors.Hand
		Me.LbAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbAbout.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LbAbout.ForeColor = System.Drawing.Color.DeepPink
		Me.LbAbout.Location = New System.Drawing.Point(2, 2)
		Me.LbAbout.Margin = New System.Windows.Forms.Padding(1)
		Me.LbAbout.Name = "LbAbout"
		Me.LbAbout.Size = New System.Drawing.Size(180, 17)
		Me.LbAbout.TabIndex = 25
		Me.LbAbout.Text = "Github"
		Me.LbAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label1
		'
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label1.Location = New System.Drawing.Point(2, 78)
		Me.Label1.Margin = New System.Windows.Forms.Padding(1)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(180, 17)
		Me.Label1.TabIndex = 26
		Me.Label1.Text = "Loopback Whitelist"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'LbStatus
		'
		Me.LbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.LbStatus.Cursor = System.Windows.Forms.Cursors.Hand
		Me.LbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.LbStatus.ForeColor = System.Drawing.Color.Blue
		Me.LbStatus.Location = New System.Drawing.Point(2, 211)
		Me.LbStatus.Margin = New System.Windows.Forms.Padding(1)
		Me.LbStatus.Name = "LbStatus"
		Me.LbStatus.Size = New System.Drawing.Size(180, 25)
		Me.LbStatus.TabIndex = 28
		Me.LbStatus.Text = "Open system ""hosts"" folder"
		Me.LbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'rtbLoopbacks
		'
		Me.rtbLoopbacks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.rtbLoopbacks.BackColor = System.Drawing.Color.White
		Me.rtbLoopbacks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.rtbLoopbacks.DetectUrls = False
		Me.rtbLoopbacks.ForeColor = System.Drawing.Color.Black
		Me.rtbLoopbacks.Location = New System.Drawing.Point(2, 93)
		Me.rtbLoopbacks.Margin = New System.Windows.Forms.Padding(1)
		Me.rtbLoopbacks.Name = "rtbLoopbacks"
		Me.rtbLoopbacks.Size = New System.Drawing.Size(180, 116)
		Me.rtbLoopbacks.TabIndex = 29
		Me.rtbLoopbacks.Text = ""
		Me.rtbLoopbacks.WordWrap = False
		'
		'HostsSettings
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.ClientSize = New System.Drawing.Size(184, 238)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.rtbLoopbacks)
		Me.Controls.Add(Me.LbStatus)
		Me.Controls.Add(Me.LbAbout)
		Me.Controls.Add(Me.chSort)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.chMin)
		Me.Controls.Add(Me.txtTargetIP)
		Me.Controls.Add(Me.chTabs)
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
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents chSort As CheckBox
	Friend WithEvents Label4 As Label
	Friend WithEvents chMin As CheckBox
	Friend WithEvents txtTargetIP As TextBox
	Friend WithEvents chTabs As CheckBox
	Friend WithEvents LbAbout As Label
	Friend WithEvents Label1 As Label
	Friend WithEvents LbStatus As Label
	Friend WithEvents rtbLoopbacks As RichTextBox
End Class
