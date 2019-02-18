Public Class HostsPreview

	Private Sub HostsPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.Icon = My.Resources.art

		Dim gene As String = HostsMain.Generated
		If Not String.IsNullOrEmpty(HostsMain.Generated) Then
			txPreview.Text = gene.Substring(0, 7777) & vbCrLf & vbCrLf & "<Preview End>"
			Me.Activate()
		End If
	End Sub

End Class