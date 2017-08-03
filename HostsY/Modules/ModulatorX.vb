Module ModulatorX

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

#Region "DoubleBuffered Buff // Use Buff.DoubleBuff(<Control>)"

	Friend NotInheritable Class Buff

		Friend Shared Sub DoubleBuff(Contt As Control)
			Dim ConttType As Type = Contt.[GetType]()
			Dim propInfo As System.Reflection.PropertyInfo = ConttType.GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
			propInfo.SetValue(Contt, True, Nothing)
		End Sub

	End Class

#End Region

End Module