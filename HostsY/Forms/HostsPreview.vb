Public Class HostsPreview

	Private Sub HostsPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim gene As String = HostsMain.Generated
		If Not String.IsNullOrEmpty(HostsMain.Generated) Then
			txPreview.Text = gene
			Me.Activate()
		End If
	End Sub

	Private Sub txPreview_KeyDown(sender As Object, e As KeyEventArgs) Handles txPreview.KeyDown
		If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.A Then
			e.SuppressKeyPress = True
			txPreview.SelectAll()
		End If
	End Sub

End Class