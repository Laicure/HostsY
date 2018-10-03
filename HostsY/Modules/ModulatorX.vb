Module ModulatorX

#Region "Settings"

	Friend SetTargetIP As String = "0.0.0.0"
	Friend SetSort As Boolean = True
	Friend SetTabs As Boolean = False
	Friend SetParseErrors As Boolean = True
	Friend SetPreview As Boolean = False
	Friend SetUseCache As Boolean = True
	Friend SetDomainPerLine As Integer = 1
	Friend SetLoopBlacks() As String = {"0.0.0.0", "broadcasthost", "ip6-allhosts", "ip6-allnodes", "ip6-allrouters", "ip6-localhost", "ip6-localnet", "ip6-loopback", "ip6-mcastprefix", "local", "localhost", "localhost.localdomain"}

#End Region

#Region "File Size"

	Function GetFileSize(ByVal byteLength As Long) As String
		Dim sizer As String = Nothing
		If byteLength >= 1048576 And byteLength <= 1073741823 Then
			sizer = FormatNumber(byteLength / 1048576, 2).ToString & "MB"
		ElseIf byteLength >= 1024 And byteLength <= 1048575 Then
			sizer = FormatNumber(byteLength / 1024, 2) & "KB"
		Else
			sizer = FormatNumber(byteLength, 0) & "B"
		End If
		Return sizer
	End Function

#End Region

End Module