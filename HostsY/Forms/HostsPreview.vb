Public Class HostsPreview

	Private Sub HostsPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim gene As String = HostsMain.Generated
		If Not String.IsNullOrEmpty(HostsMain.Generated) Then
			txPreview.Text = gene
			Me.Activate()
		End If
	End Sub

End Class