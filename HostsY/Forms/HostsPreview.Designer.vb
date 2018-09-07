<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HostsPreview
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
		Me.txPreview = New System.Windows.Forms.TextBox()
		Me.SuspendLayout()
		'
		'txPreview
		'
		Me.txPreview.BackColor = System.Drawing.Color.White
		Me.txPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.txPreview.Dock = System.Windows.Forms.DockStyle.Fill
		Me.txPreview.ForeColor = System.Drawing.Color.Black
		Me.txPreview.Location = New System.Drawing.Point(1, 1)
		Me.txPreview.Margin = New System.Windows.Forms.Padding(0)
		Me.txPreview.MaxLength = 2147483647
		Me.txPreview.Multiline = True
		Me.txPreview.Name = "txPreview"
		Me.txPreview.ReadOnly = True
		Me.txPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txPreview.Size = New System.Drawing.Size(382, 259)
		Me.txPreview.TabIndex = 2
		Me.txPreview.TabStop = False
		Me.txPreview.WordWrap = False
		'
		'HostsPreview
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.White
		Me.ClientSize = New System.Drawing.Size(384, 261)
		Me.Controls.Add(Me.txPreview)
		Me.DoubleBuffered = True
		Me.Font = New System.Drawing.Font("Segoe UI", 8.25!)
		Me.ForeColor = System.Drawing.Color.Black
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Name = "HostsPreview"
		Me.Padding = New System.Windows.Forms.Padding(1)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "hosts file preview"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents txPreview As System.Windows.Forms.TextBox
End Class
