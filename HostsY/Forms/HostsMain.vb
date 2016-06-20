Public Class HostsMain
    Dim SourceL() As String = Nothing
    Dim WhiteL() As String = Nothing
    Dim BlackL() As String = Nothing
    Dim startExec As DateTime = CDate("11/13/1988 11:59:59 PM")

    Private Sub HostsMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "HostsY v" & My.Application.Info.Version.ToString
        Me.Icon = My.Resources.Hosts
    End Sub

    Private Sub butGenerate_Click(sender As Object, e As EventArgs) Handles butGenerate.Click
        If butGenerate.Text = "Cancel Generation" Then
            bgGenerate.CancelAsync()
            butGenerate.Text = "Start Generation"
            Exit Sub
        End If

        If bgGenerate.IsBusy And bgGenerate.CancellationPending Then
            MessageBox.Show("Cancellation in progress...", "Please wait!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        '### Confirm Generation
        If MessageBox.Show("Are you sure to Generate?", "Confirm Generate!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        'deactivate controls
        panLists.Enabled = False
        rtbSources.SelectionStart = 0
        rtbWhites.SelectionStart = 0
        rtbBlacks.SelectionStart = 0
        chSort.Enabled = False
        chTabs.Enabled = False
        txtTargetIP.Enabled = False
        LbSave.Cursor = Cursors.Default
        LbSave.Text = ""

        'reset content
        rtbLogs.Clear()
        rtbOuts.Text = "Generating..."

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
        LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Preparing List...", MethodInvoker))
        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt MM/dd/yyyy") & "] Generation Started!" & vbCrLf & rtbLogs.Text, MethodInvoker))

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Validating Sources" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Download and Validate Source List
        LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources", MethodInvoker))
        Dim SourceList As HashSet(Of String) = New HashSet(Of String)(SourceL.Select(Function(x) x.Replace(vbTab, "").Trim).Where(Function(x) Uri.TryCreate(x, UriKind.Absolute, Nothing)))
        LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources [" & SourceList.Count & "]", MethodInvoker))
        rtbSources.Invoke(DirectCast(Sub() rtbSources.Text = String.Join(vbCrLf, SourceList), MethodInvoker))

        If SourceList.Count = 0 Then
            LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources", MethodInvoker))
            rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] No valid sources listed!" & vbCrLf & rtbLogs.Text, MethodInvoker))
            Exit Sub
        End If

        If bgGenerate.CancellationPending Then
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cancelling...", MethodInvoker))
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Validating Whitelist" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Validate whitelist
        LbWhites.Invoke(DirectCast(Sub() LbWhites.Text = "Whitelist", MethodInvoker))
        Dim WhiteList As HashSet(Of String) = New HashSet(Of String)(WhiteL.Select(Function(x) StrConv(System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, ""), " {2,}", " ").Trim, VbStrConv.Lowercase)).Where(Function(x) Uri.TryCreate("http://" & x, UriKind.Absolute, Nothing)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))
        LbWhites.Invoke(DirectCast(Sub() LbWhites.Text = "Whitelist [" & WhiteList.Count & "]", MethodInvoker))
        rtbWhites.Invoke(DirectCast(Sub() rtbWhites.Text = String.Join(vbCrLf, WhiteList), MethodInvoker))

        If bgGenerate.CancellationPending Then
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cancelling...", MethodInvoker))
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Validating Blacklist" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Validate and match blacklist
        LbBlacks.Invoke(DirectCast(Sub() LbBlacks.Text = "Blacklist", MethodInvoker))
        Dim BlackList As HashSet(Of String) = New HashSet(Of String)(BlackL.Select(Function(x) StrConv(System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, ""), " {2,}", " ").Trim, VbStrConv.Lowercase)).Where(Function(x) Uri.TryCreate("http://" & x, UriKind.Absolute, Nothing)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))
        LbBlacks.Invoke(DirectCast(Sub() LbBlacks.Text = "Blacklist [" & BlackList.Count & "]", MethodInvoker))
        rtbBlacks.Invoke(DirectCast(Sub() rtbBlacks.Text = String.Join(vbCrLf, BlackList), MethodInvoker))

        If bgGenerate.CancellationPending Then
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cancelling...", MethodInvoker))
            e.Cancel = True
            Exit Sub
        End If

        LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Compiling List...", MethodInvoker))
        'Source data Compile to one
        Dim UniString As String = Nothing
        Dim arrTemp() As String = SourceList.ToArray
        'SourceList.Clear()
        SourceList.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            If bgGenerate.CancellationPending Then
                LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cancelling...", MethodInvoker))
                e.Cancel = True
                Exit Sub
            End If

            Dim arstring As String = arrTemp(i)
            rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Reading " & arstring & "..." & vbCrLf & rtbLogs.Text, MethodInvoker))
            Using clie As New Net.WebClient
                Dim readd As New IO.StreamReader(clie.OpenRead(arrTemp(i)))
                Dim SourcedD As String = readd.ReadToEnd
                UniString += SourcedD & vbCrLf
            End Using
        Next
        Erase arrTemp

        '### Clean Source data
        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Cleaning Data" & vbCrLf & rtbLogs.Text, MethodInvoker))
        LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cleaning Data...", MethodInvoker))
        'Remove Comments
        Dim UniHash As HashSet(Of String) = New HashSet(Of String)(UniString.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, " "), " {2,}", " ").Trim).Where(Function(x) Not x.StartsWith("#")))

        'Remove IPs
        UniHash = New HashSet(Of String)(UniHash.Select(Function(x) IIf(System.Text.RegularExpressions.Regex.Match(x, "^((([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))|((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)))\ ").Success, Microsoft.VisualBasic.Right(x, Len(x) - (x.IndexOf(" ") + 1)), x).ToString))

        If bgGenerate.CancellationPending Then
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cancelling...", MethodInvoker))
            e.Cancel = True
            Exit Sub
        End If

        'Remove Comment Suffix
        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Removing Suffixed Comments" & vbCrLf & rtbLogs.Text, MethodInvoker))
        arrTemp = UniHash.ToArray
        UniHash.Clear()
        UniHash.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            If bgGenerate.CancellationPending Then
                LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cancelling...", MethodInvoker))
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

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Merging Lists" & vbCrLf & rtbLogs.Text, MethodInvoker))
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
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cancelling...", MethodInvoker))
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Sorting Lists" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Sort if enabled
        If chSort.Checked Then
            UniHash = New HashSet(Of String)(UniHash.OrderBy(Function(x) x))
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Sorting Data...", MethodInvoker))
        Else
            UniHash = New HashSet(Of String)(UniHash)
        End If

        If bgGenerate.CancellationPending Then
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cancelling...", MethodInvoker))
            e.Cancel = True
            Exit Sub
        End If

        LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Finalizing Data...", MethodInvoker))
        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Adding Target IP" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'finalize unified data (add target IP and comment/remove items from WhiteList)
        Dim uniCount As Integer = UniHash.Count
        Dim TargetIP As String = txtTargetIP.Text.Trim
        arrTemp = UniHash.ToArray
        UniHash.Clear()
        UniHash.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            If bgGenerate.CancellationPending Then
                LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Cancelling...", MethodInvoker))
                e.Cancel = True
                Exit Sub
            End If

            UniHash.Add(TargetIP & IIf(chTabs.Checked, vbTab, " ").ToString & arrTemp(i))
        Next
        Erase arrTemp

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Appending Loopbacks, Blacklist and everything.." & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Append Entry Count and etc~
        Dim FinalList As New List(Of String)
        FinalList.Add("# Entries: " & FormatNumber(uniCount, 0) & IIf(WhiteCount > 0, ", W-ed: " & FormatNumber(WhiteCount, 0), "").ToString & IIf(BlackList.Count > 0, ", B-ed: " & FormatNumber(BlackList.Count, 0), "").ToString)
        FinalList.Add("# As of " & Format(Now, "MM/dd/yyyy hh:mm:ss tt"))
        FinalList.Add("# Simplified version of github.com/Laicure/HostsX")
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
        FinalList.Add("# Domains [" & FormatNumber(uniCount, 0) & "]")
        FinalList.AddRange(UniHash)

        LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Generating Preview...", MethodInvoker))
        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt") & "] Generating Preview" & vbCrLf & rtbLogs.Text, MethodInvoker))

        'Preview
        rtbOuts.Invoke(DirectCast(Sub() rtbOuts.Text = String.Join(vbCrLf, FinalList), MethodInvoker))
    End Sub

    Private Sub bgGenerate_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgGenerate.RunWorkerCompleted
        'reactivate controls
        panLists.Enabled = True
        chSort.Enabled = True
        chTabs.Enabled = True
        txtTargetIP.Enabled = True
        rtbOuts.SelectionStart = 0

        butGenerate.Text = "Start Generation"
        If e.Cancelled Then
            LbStatus.Text = "Cancelled! :D"
            rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt MM/dd/yyyy") & "] Generation Cancelled!" & vbCrLf & rtbLogs.Text
        Else
            LbStatus.Text = "Done Generating! :D"
            rtbLogs.Text = "[" & Format(Now, "hh:mm:ss tt MM/dd/yyyy") & "] Generation Ended!" & vbCrLf & rtbLogs.Text

            LbSave.Cursor = Cursors.Hand
            LbSave.Text = "Click here to Save to Desktop"
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
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            e.SuppressKeyPress = True
            rtbSources.Paste(DataFormats.GetFormat(DataFormats.Text))
            rtbSources.SelectionStart = 0
        End If
    End Sub

    Private Sub rtbWhites_KeyDown(sender As Object, e As KeyEventArgs) Handles rtbWhites.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            e.SuppressKeyPress = True
            rtbWhites.Paste(DataFormats.GetFormat(DataFormats.Text))
            rtbWhites.SelectionStart = 0
        End If
    End Sub

    Private Sub rtbBlacks_KeyDown(sender As Object, e As KeyEventArgs) Handles rtbBlacks.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then
            e.SuppressKeyPress = True
            rtbBlacks.Paste(DataFormats.GetFormat(DataFormats.Text))
            rtbBlacks.SelectionStart = 0
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
            If My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\Desktop\hosts") Then
                If MessageBox.Show("Previously saved hosts file found!" & vbCrLf & "Do you still want to save?", "Confirm Overwrite!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Try
                        My.Computer.FileSystem.DeleteFile("C:\Users\" & Environment.UserName & "\Desktop\hosts", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
                    Catch ex As Exception
                        MessageBox.Show(Err.Description, Err.Source, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End Try
                Else
                    Exit Sub
                End If
            End If

            'save to user's Desktop
            rtbOuts.SaveFile("C:\Users\" & Environment.UserName & "\Desktop\hosts", RichTextBoxStreamType.PlainText)
            If My.Computer.FileSystem.FileExists("C:\Users\" & Environment.UserName & "\Desktop\hosts") Then
                LbSave.Text = "Click here to Save to Desktop [" & GetFileSize(My.Computer.FileSystem.GetFileInfo("C:\Users\" & Environment.UserName & "\Desktop\hosts").Length) & "]"
                'www.vbforfree.com/open-a-folderdirectory-and-selecthighlight-a-specific-file/
                Process.Start("explorer", "/select, C:\Users\" & Environment.UserName & "\Desktop\hosts")
            End If
        End If
    End Sub

    Private Sub LbAbout_Click(sender As Object, e As EventArgs) Handles LbAbout.Click
        Process.Start("https://github.com/Laicure/HostsY")
    End Sub
End Class

