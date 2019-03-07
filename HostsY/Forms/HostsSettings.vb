Public Class HostsSettings

	Private Sub HostsSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.Icon = My.Resources.art

		txtTargetIP.Text = SetTargetIP
		chSort.Checked = SetSort
		chTabs.Checked = SetTabs
		chUseCache.Checked = SetUseCache
		chParseErrors.Checked = SetParseErrors
		numDomainPerLine.Value = SetDomainPerLine
		txLoopbacks.Text = String.Join(vbCrLf, SetLoopBlacks)

		lbVersion.Text = "Build Date: " & My.Computer.FileSystem.GetFileInfo(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName).LastWriteTimeUtc.ToString("yyyy-MM-dd HH:mm:ss") & " UTC"
	End Sub

	Private Sub HostsSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		SetTargetIP = txtTargetIP.Text.Trim
		SetSort = chSort.Checked
		SetTabs = chTabs.Checked
		SetParseErrors = chParseErrors.Checked
		SetUseCache = chUseCache.Checked
		SetDomainPerLine = CInt(numDomainPerLine.Value)
		If Not String.IsNullOrWhiteSpace(txLoopbacks.Text) Then
			SetLoopBlacks = txLoopbacks.Lines.Distinct.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).ToArray
		Else
			SetLoopBlacks = {"0.0.0.0", "broadcasthost", "ip6-allhosts", "ip6-allnodes", "ip6-allrouters", "ip6-localhost", "ip6-localnet", "ip6-loopback", "ip6-mcastprefix", "local", "localhost", "localhost.localdomain"}
		End If
	End Sub

	Private Sub LbAbout_Click(sender As Object, e As EventArgs) Handles LbAbout.Click
		Process.Start("https://github.com/Laicure/HostsY")
	End Sub

	Private Sub TxtTargetIP_Leave(sender As Object, e As EventArgs) Handles txtTargetIP.Leave
		If System.Text.RegularExpressions.Regex.Match(txtTargetIP.Text.Trim, "^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$").Success Then
			txtTargetIP.Text = txtTargetIP.Text.Trim
		Else
			txtTargetIP.Text = "0.0.0.0"
		End If
	End Sub

	Private Sub LbStatus_MouseDown(sender As Object, e As MouseEventArgs) Handles LbStatus.MouseDown
		If e.Button = System.Windows.Forms.MouseButtons.Left Then
			If My.Computer.FileSystem.FileExists("C:\WINDOWS\system32\drivers\etc\hosts") Then
				Process.Start("explorer", "/select, C:\WINDOWS\system32\drivers\etc\hosts")
			Else
				Process.Start("C:\WINDOWS\system32\drivers\etc")
			End If
		End If
	End Sub

	Private Sub chUseCache_Click(sender As Object, e As EventArgs) Handles chUseCache.Click
		If Not chUseCache.Checked Then
			If MessageBox.Show("Disabling cache will clear all saved cached domains per URL." & vbCrLf & "Proceed?", "Confirm Cache Off!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes Then
				With HostsMain
					.sourceCacheList.Clear()
					.sourceCacheList.TrimExcess()
				End With
				chUseCache.Checked = False
			Else
				chUseCache.Checked = True
			End If
		End If
	End Sub

	Private Sub txLoopbacks_KeyDown(sender As Object, e As KeyEventArgs) Handles txLoopbacks.KeyDown
		If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.A Then
			e.SuppressKeyPress = True
			txLoopbacks.SelectAll()
		End If
	End Sub

	Private Sub lbParameters_Click(sender As Object, e As EventArgs) Handles lbParameters.Click
		MessageBox.Show("Required:" & vbCrLf _
						& "-auto" & vbCrLf _
						& "> Initializes Auto Generate State" & vbCrLf _
						& "> Directly replaces the hosts file in C:\Windows\System32\drivers\etc" & vbCrLf _
						& "> Requires a ""Data"" folder beside the app" & vbCrLf _
						& ">> Required: source.txt for the host sources" & vbCrLf _
						& ">> Optional: black.txt for domain blacklist" & vbCrLf _
						& ">> Optional: white.txt for domain whitelist" & vbCrLf _
						& ">> Optional: loopback.txt for domain loopbacks" & vbCrLf & vbCrLf _
						& "Optional:" & vbCrLf _
						& "-sort" & vbCrLf _
						& "> Sorts the Domains (ascending; source-wise)" & vbCrLf _
						& "-tab" & vbCrLf _
						& "> Uses tab instead of spaces between Target IP and Domain Name" & vbCrLf _
						& "-logs" & vbCrLf _
						& "> Generate generation logs; auto-generates a logs.txt inside the Data folder" & vbCrLf _
						& "-dpl<n>" & vbCrLf _
						& "> Indicates that it will generate <2~9> number of domains per line (e.g. -dpl4) to reduce the file size" & vbCrLf _
						& "-zip" & vbCrLf _
						& "> Generates a zipped hosts file inside the Data folder", "Parameters", MessageBoxButtons.OK, MessageBoxIcon.Information)
	End Sub

End Class