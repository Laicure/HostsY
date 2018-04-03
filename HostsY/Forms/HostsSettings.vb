﻿Public Class HostsSettings

	Private Sub HostsSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.Icon = My.Resources.art

		txtTargetIP.Text = SetTargetIP
		chMin.Checked = SetMin
		chSort.Checked = SetSort
		chTabs.Checked = SetTabs
		txLoopbacks.Text = String.Join(vbCrLf, SetLoopBlacks)
	End Sub

	Private Sub HostsSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		SetTargetIP = txtTargetIP.Text.Trim
		SetMin = chMin.Checked
		SetSort = chSort.Checked
		SetTabs = chTabs.Checked
		SetLoopBlacks = txLoopbacks.Lines.Distinct.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).ToArray
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

End Class