Public Class HostsMain
    Dim SourceL() As String = Nothing
    Dim WhiteL() As String = Nothing
    Dim BlackL() As String = Nothing
    Dim startExec As DateTime = Now

    Private Sub HostsMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "HostsY v" & My.Application.Info.Version.ToString
        Me.Icon = My.Resources.Hosts
    End Sub

    Private Sub butGenerate_Click(sender As Object, e As EventArgs) Handles butGenerate.Click
        If String.IsNullOrWhiteSpace(rtbSources.Text) Then
            Exit Sub
        End If

        If butGenerate.Text = "Cancel Generation" Then
            bgGenerate.CancelAsync()
            butGenerate.Text = "Start Generation"
            LbStatus.Text = "Canceling..."
            Exit Sub
        End If

        If bgGenerate.IsBusy And bgGenerate.CancellationPending Then
            MessageBox.Show("Cancellation in progress...", "Please wait!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        '### Confirm Generation
        'If MessageBox.Show("Are you sure to Generate?", "Confirm Generate!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
        '    Exit Sub
        'End If

        'deactivate controls
        rtbSources.ReadOnly = True
        rtbWhites.ReadOnly = True
        rtbBlacks.ReadOnly = True

        rtbSources.SelectionStart = 0
        rtbWhites.SelectionStart = 0
        rtbBlacks.SelectionStart = 0
        chSort.Enabled = False
        chTabs.Enabled = False
        txtTargetIP.ReadOnly = True
        LbSave.Cursor = Cursors.Default
        LbSave.Text = ""

        'reset content
        rtbLogs.Clear()
        rtbOuts.Text = "Generating..."
        LbStatus.Text = "Generating..."

        'set vars
        butGenerate.Text = "Cancel Generation"
        SourceL = rtbSources.Text.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        WhiteL = rtbWhites.Text.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        BlackL = rtbBlacks.Text.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        bgGenerate.RunWorkerAsync()
    End Sub

    Private Sub bgGenerate_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgGenerate.DoWork
        '### Retrieve all Source Data
        startExec = Now

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Generation Started!" & vbCrLf & rtbLogs.Text, MethodInvoker))
        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Validating Sources" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Download and Validate Source List
        LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources", MethodInvoker))
        Dim SourceList As HashSet(Of String) = New HashSet(Of String)(SourceL.Select(Function(x) x.Replace(vbTab, "").Trim).Where(Function(x) Uri.TryCreate(x, UriKind.Absolute, Nothing)))
        LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources [" & SourceList.Count & "]", MethodInvoker))
        rtbSources.Invoke(DirectCast(Sub() rtbSources.Text = String.Join(vbCrLf, SourceList), MethodInvoker))

        If SourceList.Count = 0 Then
            LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources", MethodInvoker))
            rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] No valid sources listed!" & vbCrLf & rtbLogs.Text, MethodInvoker))
            Exit Sub
        End If

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Validating Whitelist" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Validate whitelist
        LbWhites.Invoke(DirectCast(Sub() LbWhites.Text = "Whitelist", MethodInvoker))
        Dim WhiteList As HashSet(Of String) = New HashSet(Of String)(WhiteL.Select(Function(x) StrConv(System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, ""), " {2,}", " ").Trim, VbStrConv.Lowercase)).Where(Function(x) Uri.TryCreate("http://" & x, UriKind.Absolute, Nothing)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))
        LbWhites.Invoke(DirectCast(Sub() LbWhites.Text = "Whitelist [" & WhiteList.Count & "]", MethodInvoker))
        rtbWhites.Invoke(DirectCast(Sub() rtbWhites.Text = String.Join(vbCrLf, WhiteList), MethodInvoker))

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Validating Blacklist" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Validate and match blacklist
        LbBlacks.Invoke(DirectCast(Sub() LbBlacks.Text = "Blacklist", MethodInvoker))
        Dim BlackList As HashSet(Of String) = New HashSet(Of String)(BlackL.Select(Function(x) StrConv(System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, ""), " {2,}", " ").Trim, VbStrConv.Lowercase)).Where(Function(x) Uri.TryCreate("http://" & x, UriKind.Absolute, Nothing)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))
        LbBlacks.Invoke(DirectCast(Sub() LbBlacks.Text = "Blacklist [" & BlackList.Count & "]", MethodInvoker))
        rtbBlacks.Invoke(DirectCast(Sub() rtbBlacks.Text = String.Join(vbCrLf, BlackList), MethodInvoker))

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        'Source data Compile to one
        Dim UniString As String = Nothing
        Dim arrTemp() As String = SourceList.ToArray
        'SourceList.Clear()
        SourceList.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            If bgGenerate.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            Dim arstring As String = arrTemp(i)
            rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Reading " & arstring & "..." & vbCrLf & rtbLogs.Text, MethodInvoker))
            Using clie As New Net.WebClient
                Try
                    Dim readd As New IO.StreamReader(clie.OpenRead(arrTemp(i)))
                    Dim SourcedD As String = readd.ReadToEnd
                    UniString += SourcedD & vbCrLf
                Catch ex As Exception
                    rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Error Reading " & arstring & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & rtbLogs.Text, MethodInvoker))
                End Try
            End Using
        Next
        Erase arrTemp

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        '### if UniString empty
        If IsNothing(UniString) Then
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Nothing to Generate", MethodInvoker))
            Exit Sub
        End If

        '### Clean Source data
        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Cleaning Data" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Remove Comments
        Dim UniHash As HashSet(Of String) = New HashSet(Of String)(UniString.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, " "), " {2,}", " ").Trim).Where(Function(x) Not x.StartsWith("#")))

        'Remove IPs
        UniHash = New HashSet(Of String)(UniHash.Select(Function(x) IIf(System.Text.RegularExpressions.Regex.Match(x, "^((([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))|((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)))\ ").Success, Microsoft.VisualBasic.Right(x, Len(x) - (x.IndexOf(" ") + 1)), x).ToString))

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        'Remove Comment Suffix
        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Removing Suffixed Comments" & vbCrLf & rtbLogs.Text, MethodInvoker))
        arrTemp = UniHash.ToArray
        UniHash.Clear()
        UniHash.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            If bgGenerate.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            If arrTemp(i).Contains(" #") Then
                UniHash.Add(Microsoft.VisualBasic.Left(arrTemp(i), arrTemp(i).IndexOf(" #")).Trim)
            Else
                UniHash.Add(arrTemp(i).Trim)
            End If
        Next
        Erase arrTemp

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Merging Lists" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Remove Loopbacks
        UniHash = New HashSet(Of String)(UniHash.Select(Function(x) StrConv(x.Trim, VbStrConv.Lowercase)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))
        UniHash.TrimExcess()

        'remove blacklisted from whitelist
        WhiteList.ExceptWith(BlackList)
        WhiteList.TrimExcess()
        Dim WhiteCount As Integer = WhiteList.Where(Function(x) UniHash.Any(Function(y) y = x)).Count

        'remove whitelisted from unified list
        UniHash.ExceptWith(WhiteList)
        UniHash.TrimExcess()

        'remove already unified listed from blacklist
        BlackList.ExceptWith(UniHash)
        BlackList.TrimExcess()

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        '### Empty List check
        If String.IsNullOrWhiteSpace(String.Join(" ", UniHash)) Then
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Empty Parsed List", MethodInvoker))
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Sorting List" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Sort if enabled
        If chSort.Checked Then
            UniHash = New HashSet(Of String)(UniHash.OrderBy(Function(x) x))
        Else
            UniHash = New HashSet(Of String)(UniHash)
        End If

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Adding Target IP" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'finalize unified data (add target IP and comment/remove items from WhiteList)
        Dim uniCount As Integer = UniHash.Count
        Dim TargetIP As String = txtTargetIP.Text.Trim
        arrTemp = UniHash.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).ToArray
        UniHash.Clear()
        UniHash.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            If bgGenerate.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            UniHash.Add(TargetIP & IIf(chTabs.Checked, vbTab, " ").ToString & arrTemp(i))
        Next
        Erase arrTemp

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Finalizing Output" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Append Entry Count and etc~
        Dim FinalList As New List(Of String)
        FinalList.Add("# Entries: " & FormatNumber(uniCount, 0) & IIf(WhiteCount > 0, ", W: " & FormatNumber(WhiteCount, 0), "").ToString & IIf(BlackList.Count > 0, ", B: " & FormatNumber(BlackList.Count, 0), "").ToString)
        FinalList.Add("# As of " & Format(Now, "MM/dd/yyyy hh:mm:ss.ff tt"))
        FinalList.Add("# Generated using github.com/Laicure/HostsY")
        FinalList.Add("")
        FinalList.Add("# Sources [" & FormatNumber(SourceList.Count, 0) & "]")
        FinalList.AddRange(SourceList.Select(Function(x) "# " & x))
        FinalList.Add("")
        FinalList.Add("# Loopbacks")
        FinalList.Add("127.0.0.1" & IIf(chTabs.Checked, vbTab, " ").ToString & "localhost")
        FinalList.Add("::1" & IIf(chTabs.Checked, vbTab, " ").ToString & "localhost")
        FinalList.Add("")
        If BlackList.Count > 0 Then
            FinalList.Add("# Blacklist [" & FormatNumber(BlackList.Count, 0) & "]")
            FinalList.AddRange(BlackList.Select(Function(x) TargetIP & IIf(chTabs.Checked, vbTab, " ").ToString & x))
            FinalList.Add("")
        End If
        FinalList.Add("# Domains [" & IIf(WhiteCount > 0, FormatNumber(uniCount + WhiteCount, 0) & "-" & FormatNumber(WhiteCount, 0) & "=" & FormatNumber(uniCount, 0) & "]", FormatNumber(uniCount, 0) & "]").ToString)
        FinalList.AddRange(UniHash)

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Generating Preview" & vbCrLf & rtbLogs.Text, MethodInvoker))

        'Preview
        rtbOuts.Invoke(DirectCast(Sub() rtbOuts.Text = String.Join(vbCrLf, FinalList), MethodInvoker))
    End Sub

    Private Sub bgGenerate_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgGenerate.RunWorkerCompleted
        'reactivate controls
        'panLists.Enabled = True
        rtbSources.ReadOnly = False
        rtbWhites.ReadOnly = False
        rtbBlacks.ReadOnly = False

        chSort.Enabled = True
        chTabs.Enabled = True
        txtTargetIP.ReadOnly = False

        butGenerate.Text = "Start Generation"
        If e.Cancelled Then
            LbStatus.Text = "Cancelled! :D"
            rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Generation Cancelled!" & vbCrLf & rtbLogs.Text
            rtbOuts.Text = "Cancelled! :P"
        Else
            If LbStatus.Text = "Nothing to Generate" Then
                rtbOuts.Text = "No valid source to parse!"
            ElseIf LbStatus.Text = "Empty Parsed List" Then
                rtbOuts.Text = "Parsed List Empty!"
            Else
                LbStatus.Text = "Done Generating! :D"

                LbSave.Cursor = Cursors.Hand
                LbSave.Text = "Click here to Save to a Location"
            End If
            rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Generation Ended!" & vbCrLf & rtbLogs.Text
            rtbOuts.SelectionStart = 0
        End If
        rtbLogs.Text = "~ Took " & Microsoft.VisualBasic.Left(DateTime.Now.Subtract(startExec).ToString, 11) & vbCrLf & rtbLogs.Text

        Erase SourceL
        Erase WhiteL
        Erase BlackL
    End Sub

    Private Sub txtTargetIP_Leave(sender As Object, e As EventArgs) Handles txtTargetIP.Leave
        If System.Text.RegularExpressions.Regex.Match(txtTargetIP.Text.Trim, "^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$").Success Then
            txtTargetIP.Text = txtTargetIP.Text.Trim
        Else
            txtTargetIP.Text = "0.0.0.0"
        End If
    End Sub

    Private Sub rtbSources_KeyDown(sender As Object, e As KeyEventArgs) Handles rtbSources.KeyDown
        If Not rtbSources.ReadOnly And (e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V) Then
            e.SuppressKeyPress = True
            rtbSources.Paste(DataFormats.GetFormat(DataFormats.Text))
        End If
    End Sub

    Private Sub rtbWhites_KeyDown(sender As Object, e As KeyEventArgs) Handles rtbWhites.KeyDown
        If Not rtbWhites.ReadOnly And (e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V) Then
            e.SuppressKeyPress = True
            rtbWhites.Paste(DataFormats.GetFormat(DataFormats.Text))
        End If
    End Sub

    Private Sub rtbBlacks_KeyDown(sender As Object, e As KeyEventArgs) Handles rtbBlacks.KeyDown
        If Not rtbBlacks.ReadOnly And (e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V) Then
            e.SuppressKeyPress = True
            rtbBlacks.Paste(DataFormats.GetFormat(DataFormats.Text))
        End If
    End Sub

    Private Sub HostsMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Hide()
        If bgGenerate.IsBusy Then
            bgGenerate.CancelAsync()
        End If
    End Sub

    Private Sub LbSave_Click(sender As Object, e As EventArgs) Handles LbSave.Click
        If LbSave.Cursor = Cursors.Hand Then
            If fdBrowse.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim succ As Boolean = False
                Try
                    rtbOuts.SaveFile(fdBrowse.SelectedPath & "\hosts", RichTextBoxStreamType.PlainText)
                    succ = True
                Catch ex As Exception
                    rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Cannot Export!" & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & rtbLogs.Text
                End Try

                If succ Then
                    If My.Computer.FileSystem.FileExists(fdBrowse.SelectedPath & "\hosts") Then
                        Dim sizee As String = GetFileSize(My.Computer.FileSystem.GetFileInfo(fdBrowse.SelectedPath & "\hosts").Length)
                        LbSave.Text = "Click here to Save to a Location [" & sizee & "]"
                        rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Exported! @" & fdBrowse.SelectedPath & " (" & sizee & ")" & vbCrLf & rtbLogs.Text
                        'www.vbforfree.com/open-a-folderdirectory-and-selecthighlight-a-specific-file/
                        Process.Start("explorer", "/select, " & fdBrowse.SelectedPath & "\hosts")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub LbAbout_Click(sender As Object, e As EventArgs) Handles LbAbout.Click
        Process.Start("https://github.com/Laicure/HostsY")
    End Sub

End Class

