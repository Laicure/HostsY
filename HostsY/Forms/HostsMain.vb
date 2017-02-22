Public Class HostsMain
    Dim SourceL() As String = Nothing
    Dim WhiteL() As String = Nothing
    Dim BlackL() As String = Nothing
    Dim startExec As DateTime = Now

    Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
        If Not Me.IsHandleCreated Then
            Me.CreateHandle()
            If Environment.GetCommandLineArgs.LongLength > 1 AndAlso Environment.CommandLine.Contains("-auto") Then
                value = False
                autoo()
            Else
                value = True
            End If
        End If
        MyBase.SetVisibleCore(value)
    End Sub

    Private Sub autoo()
        Dim argg As String = Trim(Replace(Environment.CommandLine, Environment.GetCommandLineArgs(0), ""))
        Dim dataSource As String = Application.StartupPath & "\Data"
        Dim tabb As Boolean = argg.Contains("-tab")
        Dim sortt As Boolean = argg.Contains("-sort")
        Dim logger As Boolean = argg.Contains("-logs")

        'Check Directory
        If Not My.Computer.FileSystem.DirectoryExists(dataSource) Then
            My.Computer.FileSystem.CreateDirectory(dataSource)
            Environment.Exit(3)
            Exit Sub
        End If

        'Check sources
        If Not My.Computer.FileSystem.FileExists(dataSource & "\sources.txt") Then
            My.Computer.FileSystem.WriteAllText(dataSource & "\sources.txt", "", False)
            Environment.Exit(2)
            Exit Sub
        End If

        'Check whitelist
        'If argg.Contains("-white") Then
        If Not My.Computer.FileSystem.FileExists(dataSource & "\white.txt") Then
            My.Computer.FileSystem.WriteAllText(dataSource & "\white.txt", "", False)
        End If
        'End If

        'Check blacklist
        'If argg.Contains("-black") Then
        If Not My.Computer.FileSystem.FileExists(dataSource & "\black.txt") Then
            My.Computer.FileSystem.WriteAllText(dataSource & "\black.txt", "", False)
        End If
        'End If

        '########################## Start ##########################
        SourceL = My.Computer.FileSystem.ReadAllText(dataSource & "\sources.txt").Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        WhiteL = My.Computer.FileSystem.ReadAllText(dataSource & "\white.txt").Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        BlackL = My.Computer.FileSystem.ReadAllText(dataSource & "\black.txt").Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)

        startExec = Now
        'Init Logging
        Dim Logg As String = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Generation Started!"
        Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Validating Sources" & vbCrLf & Logg

        'Validate Sources
        Dim SourceList As HashSet(Of String) = New HashSet(Of String)(SourceL.Select(Function(x) x.Replace(vbTab, "").Trim).Where(Function(x) Uri.TryCreate(x, UriKind.Absolute, Nothing)))
        'Exit if Source is empty
        If SourceList.Count = 0 Then
            Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] No valid sources listed!" & vbCrLf & Logg
            Environment.Exit(3)
            Exit Sub
        End If

        Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Validating Whitelist" & vbCrLf & Logg
        'Validate whitelist
        Dim WhiteList As HashSet(Of String) = New HashSet(Of String)(WhiteL.Select(Function(x) StrConv(System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, ""), " {2,}", " ").Trim, VbStrConv.Lowercase)).Where(Function(x) Uri.TryCreate("http://" & x, UriKind.Absolute, Nothing)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))

        Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Validating Blacklist" & vbCrLf & Logg
        'Validate and match blacklist
        Dim BlackList As HashSet(Of String) = New HashSet(Of String)(BlackL.Select(Function(x) StrConv(System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, ""), " {2,}", " ").Trim, VbStrConv.Lowercase)).Where(Function(x) Uri.TryCreate("http://" & x, UriKind.Absolute, Nothing)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))

        'Major Hashset
        Dim UniHash As New HashSet(Of String)

        'Source data Compile to one
        Dim UniString As String = Nothing
        Dim totalDoms As Long = 0
        Dim arrTemp() As String = SourceList.ToArray
        SourceList.Clear()
        SourceList.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            Dim arstring As String = arrTemp(i)
            Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Reading " & arstring & "..." & vbCrLf & Logg
            Dim suc As Boolean = False
            Using clie As New Net.WebClient
                Try
                    Dim readd As New IO.StreamReader(clie.OpenRead(arrTemp(i)))
                    Dim SourcedD As String = readd.ReadToEnd
                    UniString = Nothing
                    UniString += SourcedD & vbCrLf
                    suc = True
                Catch ex As Exception
                    Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Error Reading " & arstring & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & Logg
                End Try

                If suc Then
                    '### Clean Source data
                    Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Cleaning Source... (+Retrieving Domain Count)" & vbCrLf & Logg

                    'Remove Comments
                    Dim SourceHash As HashSet(Of String) = New HashSet(Of String)(UniString.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, " "), " {2,}", " ").Trim).Where(Function(x) Not x.StartsWith("#")))
                    'Remove IPs
                    SourceHash = New HashSet(Of String)(SourceHash.Select(Function(x) IIf(System.Text.RegularExpressions.Regex.Match(x, "^((([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))|((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)))\ ").Success, Microsoft.VisualBasic.Right(x, Len(x) - (x.IndexOf(" ") + 1)), x).ToString))
                    'Remove Comment Suffix
                    Dim arrTempX() As String = SourceHash.ToArray
                    SourceHash.Clear()
                    SourceHash.TrimExcess()
                    For y As Integer = 0 To arrTempX.Count - 1
                        Dim urx As Uri = Nothing
                        If arrTempX(y).Contains(" #") Then
                            urx = New Uri("http://" & Microsoft.VisualBasic.Left(arrTempX(y), arrTempX(y).IndexOf(" #")).Trim)
                        Else
                            urx = New Uri("http://" & arrTempX(y).Trim)
                        End If
                        Dim SafeHost As String = urx.DnsSafeHost
                        If Not String.IsNullOrWhiteSpace(SafeHost) Then
                            SourceHash.Add(urx.DnsSafeHost)
                        End If
                    Next
                    Erase arrTempX
                    'Remove Loopbacks
                    SourceHash = New HashSet(Of String)(SourceHash.Select(Function(x) StrConv(x.Trim, VbStrConv.Lowercase)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))

                    'show count
                    totalDoms += SourceHash.LongCount
                    Dim domCount As String = FormatNumber(SourceHash.LongCount, 0)
                    Logg = Replace(Logg, "(+Retrieving Domain Count)", "Got " & domCount & " domains!")
                    If Not SourceHash.Count = 0 Then
                        If sortt Then
                            SourceHash = New HashSet(Of String)(SourceHash.OrderBy(Function(x) x))
                        End If
                        UniHash.Add("# ~Source @" & i + 1)
                        UniHash.UnionWith(SourceHash)
                        SourceList.Add("[" & domCount & "] @" & i + 1 & ", " & arrTemp(i))
                    End If
                End If
            End Using
        Next
        Erase arrTemp

        '### if UniHash empty
        If UniHash.LongCount = 0 Then
            Logg = "Nothing to Generate!" & vbCrLf & Logg
            Environment.Exit(1)
            Exit Sub
        End If

        Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Merging Lists" & vbCrLf & Logg

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

        '### Empty List check
        If UniHash.LongCount = 0 Then
            Logg = "Empty Parsed List!" & vbCrLf & Logg
            Environment.Exit(1)
            Exit Sub
        End If

        Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Adding Target IP" & vbCrLf & Logg

        'finalize unified data (add target IP and comment/remove items from WhiteList)
        Dim uniCount As Integer = UniHash.Where(Function(x) Not x.StartsWith("# ~")).Count
        Dim TargetIP As String = txtTargetIP.Text.Trim
        arrTemp = UniHash.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).ToArray
        UniHash.Clear()
        UniHash.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            UniHash.Add(IIf(Not arrTemp(i).StartsWith("# ~"), TargetIP & IIf(tabb, vbTab, " ").ToString & arrTemp(i), arrTemp(i)).ToString)
        Next
        Erase arrTemp

        Logg = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Finalizing Output" & vbCrLf & Logg
        'Append Entry Count and etc~
        Dim FinalList As New List(Of String)
        With FinalList
            .Add("# Entries: " & FormatNumber(uniCount, 0) & IIf(WhiteCount > 0, ", W: " & FormatNumber(WhiteCount, 0), "").ToString & IIf(BlackList.Count > 0, ", B: " & FormatNumber(BlackList.Count, 0), "").ToString)
            .Add("# As of " & Format(Date.UtcNow, "MM/dd/yyyy hh:mm:ss.ff tt UTC"))
            .Add("# Generated using github.com/Laicure/HostsY")
            .Add("")
            .Add("# Sources [" & FormatNumber(SourceList.Count, 0) & " @ " & FormatNumber(totalDoms, 0) & "]")
            .AddRange(SourceList.Select(Function(x) "# " & x))
            .Add("")
            .Add("# Loopbacks")
            .Add("127.0.0.1" & IIf(tabb, vbTab, " ").ToString & "localhost")
            .Add("::1" & IIf(tabb, vbTab, " ").ToString & "localhost")
            .Add("")
            If BlackList.Count > 0 Then
                .Add("# Blacklist [" & FormatNumber(BlackList.Count, 0) & "]")
                .AddRange(BlackList.Select(Function(x) TargetIP & IIf(tabb, vbTab, " ").ToString & x))
                .Add("")
            End If
            .Add("#" & IIf(sortt, " Sorted ", " ").ToString & "Domains [" & IIf(WhiteCount > 0, FormatNumber(uniCount + WhiteCount, 0) & "-" & FormatNumber(WhiteCount, 0) & "=" & FormatNumber(uniCount, 0) & "]", FormatNumber(uniCount, 0) & "]").ToString)
            .AddRange(UniHash)
            .Add("")
            .Add("# End")
        End With

        'Save; needs admin privileges
        Try
            My.Computer.FileSystem.WriteAllText("C:\Windows\System32\drivers\etc\hosts", String.Join(vbCrLf, FinalList), False)
            'final Logs
            Dim sizee As String = GetFileSize(My.Computer.FileSystem.GetFileInfo("C:\Windows\System32\drivers\etc\hosts").Length)
            Logg = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Exported! @" & "C:\Windows\System32\drivers\etc\hosts" & " (" & sizee & ")" & vbCrLf & Logg
        Catch ex As Exception
            Logg = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Cannot Export!" & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & IIf(ex.Message.Contains("denied"), "> Run this app as admin!", "").ToString & vbCrLf & Logg
        End Try

        Logg = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Generation Ended!" & vbCrLf & Logg

        If logger Then
            'save logs
            My.Computer.FileSystem.WriteAllText(dataSource & "\logs.txt", Logg, False)
        End If

        Environment.Exit(0)
    End Sub

    Private Sub HostsMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "HostsY v" & My.Application.Info.Version.ToString
        Me.Icon = My.Resources.Hosts

        Buff.DoubleBuff(rtbOuts)
        Buff.DoubleBuff(rtbBlacks)
        Buff.DoubleBuff(rtbLogs)
        Buff.DoubleBuff(rtbSources)
        Buff.DoubleBuff(rtbWhites)
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
        tipper.SetToolTip(LbSave, Nothing)

        'reset content
        rtbLogs.Clear()
        rtbOuts.Text = "Generating..."
        LbStatus.Text = "Generating..."
        LbSource.Text = "Sources"
        LbWhites.Text = "Whitelist"
        LbBlacks.Text = "Blacklist"

        'set vars
        butGenerate.Text = "Cancel Generation"
        LbReset.Enabled = False
        SourceL = rtbSources.Text.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        WhiteL = rtbWhites.Text.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        BlackL = rtbBlacks.Text.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
        bgGenerate.RunWorkerAsync()
    End Sub

    Private Sub bgGenerate_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgGenerate.DoWork
        '### Retrieve all Source Data
        startExec = Now

        rtbLogs.Invoke(DirectCast(
                       Sub()
                           rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Generation Started!"
                           rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Validating Sources" & vbCrLf & rtbLogs.Text
                       End Sub, MethodInvoker))
        'Download and Validate Source List
        Dim SourceList As HashSet(Of String) = New HashSet(Of String)(SourceL.Select(Function(x) x.Replace(vbTab, "").Trim).Where(Function(x) Uri.TryCreate(x, UriKind.Absolute, Nothing)))
        LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources [" & SourceList.Count & "]", MethodInvoker))
        rtbSources.Invoke(DirectCast(Sub() rtbSources.Text = String.Join(vbCrLf, SourceList), MethodInvoker))

        If SourceList.Count = 0 Then
            LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources", MethodInvoker))
            rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] No valid sources listed!" & vbCrLf & rtbLogs.Text, MethodInvoker))
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Empty Parsed List", MethodInvoker))
            Exit Sub
        End If

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Validating Whitelist" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Validate whitelist
        Dim WhiteList As HashSet(Of String) = New HashSet(Of String)(WhiteL.Select(Function(x) StrConv(System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, ""), " {2,}", " ").Trim, VbStrConv.Lowercase)).Where(Function(x) Uri.TryCreate("http://" & x, UriKind.Absolute, Nothing)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))
        LbWhites.Invoke(DirectCast(Sub() LbWhites.Text = "Whitelist [" & WhiteList.Count & "]", MethodInvoker))
        rtbWhites.Invoke(DirectCast(Sub() rtbWhites.Text = String.Join(vbCrLf, WhiteList), MethodInvoker))

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Validating Blacklist" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Validate and match blacklist
        Dim BlackList As HashSet(Of String) = New HashSet(Of String)(BlackL.Select(Function(x) StrConv(System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, ""), " {2,}", " ").Trim, VbStrConv.Lowercase)).Where(Function(x) Uri.TryCreate("http://" & x, UriKind.Absolute, Nothing)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))
        LbBlacks.Invoke(DirectCast(Sub() LbBlacks.Text = "Blacklist [" & BlackList.Count & "]", MethodInvoker))
        rtbBlacks.Invoke(DirectCast(Sub() rtbBlacks.Text = String.Join(vbCrLf, BlackList), MethodInvoker))

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        'Major Hashset
        Dim UniHash As New HashSet(Of String)

        'Source data Compile to one
        Dim UniString As String = Nothing
        Dim totalDoms As Long = 0
        Dim arrTemp() As String = SourceList.ToArray
        SourceList.Clear()
        SourceList.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            If bgGenerate.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            Dim arstring As String = arrTemp(i)
            rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Reading " & arstring & "..." & vbCrLf & rtbLogs.Text, MethodInvoker))
            Dim suc As Boolean = False
            Using clie As New Net.WebClient
                Try
                    Dim readd As New IO.StreamReader(clie.OpenRead(arrTemp(i)))
                    Dim SourcedD As String = readd.ReadToEnd
                    UniString = Nothing
                    UniString += SourcedD & vbCrLf
                    suc = True
                Catch ex As Exception
                    rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Error Reading " & arstring & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & rtbLogs.Text, MethodInvoker))
                End Try

                If suc Then
                    '### Clean Source data
                    rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Cleaning Source... (+Retrieving Domain Count)" & vbCrLf & rtbLogs.Text, MethodInvoker))

                    'Remove Comments
                    Dim SourceHash As HashSet(Of String) = New HashSet(Of String)(UniString.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) System.Text.RegularExpressions.Regex.Replace(Replace(x, vbTab, " "), " {2,}", " ").Trim).Where(Function(x) Not x.StartsWith("#")))
                    'Remove IPs
                    SourceHash = New HashSet(Of String)(SourceHash.Select(Function(x) IIf(System.Text.RegularExpressions.Regex.Match(x, "^((([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))|((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)))\ ").Success, Microsoft.VisualBasic.Right(x, Len(x) - (x.IndexOf(" ") + 1)), x).ToString))
                    'Remove Comment Suffix
                    Dim arrTempX() As String = SourceHash.ToArray
                    SourceHash.Clear()
                    SourceHash.TrimExcess()
                    For y As Integer = 0 To arrTempX.Count - 1
                        If bgGenerate.CancellationPending Then
                            e.Cancel = True
                            Exit Sub
                        End If

                        Dim urx As Uri = Nothing
                        If arrTempX(y).Contains(" #") Then
                            urx = New Uri("http://" & Microsoft.VisualBasic.Left(arrTempX(y), arrTempX(y).IndexOf(" #")).Trim)
                        Else
                            urx = New Uri("http://" & arrTempX(y).Trim)
                        End If
                        Dim SafeHost As String = urx.DnsSafeHost
                        If Not String.IsNullOrWhiteSpace(SafeHost) Then
                            SourceHash.Add(urx.DnsSafeHost)
                        End If
                    Next
                    Erase arrTempX
                    'Remove Loopbacks
                    SourceHash = New HashSet(Of String)(SourceHash.Select(Function(x) StrConv(x.Trim, VbStrConv.Lowercase)).Where(Function(x) Not System.Text.RegularExpressions.Regex.Match(x, "\b^localhost$|\b^local$|\b^localhost\.localdomain$|\b^broadcasthost$").Success))

                    'show count
                    totalDoms += SourceHash.LongCount
                    Dim domCount As String = FormatNumber(SourceHash.LongCount, 0)
                    rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = Replace(rtbLogs.Text, "(+Retrieving Domain Count)", "Got " & domCount & " domains!"), MethodInvoker))
                    If Not SourceHash.Count = 0 Then
                        If chSort.Checked Then
                            SourceHash = New HashSet(Of String)(SourceHash.OrderBy(Function(x) x))
                        End If
                        UniHash.Add("# ~Source @" & i + 1)
                        UniHash.UnionWith(SourceHash)
                        SourceList.Add("[" & domCount & "] @" & i + 1 & ", " & arrTemp(i))
                    End If
                End If
            End Using
        Next
        Erase arrTemp

        '### if UniHash empty
        If UniHash.LongCount = 0 Then
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Nothing to Generate", MethodInvoker))
            Exit Sub
        End If

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Merging Lists" & vbCrLf & rtbLogs.Text, MethodInvoker))

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

        '### Empty List check
        If UniHash.LongCount = 0 Then
            LbStatus.Invoke(DirectCast(Sub() LbStatus.Text = "Empty Parsed List", MethodInvoker))
            Exit Sub
        End If

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Adding Target IP" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'finalize unified data (add target IP and comment/remove items from WhiteList)
        Dim uniCount As Integer = UniHash.Where(Function(x) Not x.StartsWith("# ~")).Count
        Dim TargetIP As String = txtTargetIP.Text.Trim
        arrTemp = UniHash.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).ToArray
        UniHash.Clear()
        UniHash.TrimExcess()
        For i As Integer = 0 To arrTemp.Count - 1
            If bgGenerate.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            UniHash.Add(IIf(Not arrTemp(i).StartsWith("# ~"), TargetIP & IIf(chTabs.Checked, vbTab, " ").ToString & arrTemp(i), arrTemp(i)).ToString)
        Next
        Erase arrTemp

        If bgGenerate.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If

        rtbLogs.Invoke(DirectCast(Sub() rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt") & "] Finalizing Output" & vbCrLf & rtbLogs.Text, MethodInvoker))
        'Append Entry Count and etc~
        Dim FinalList As New List(Of String)
        With FinalList
            .Add("# Entries: " & FormatNumber(uniCount, 0) & IIf(WhiteCount > 0, ", W: " & FormatNumber(WhiteCount, 0), "").ToString & IIf(BlackList.Count > 0, ", B: " & FormatNumber(BlackList.Count, 0), "").ToString)
            .Add("# As of " & Format(Date.UtcNow, "MM/dd/yyyy hh:mm:ss.ff tt UTC"))
            .Add("# Generated using github.com/Laicure/HostsY")
            .Add("")
            .Add("# Sources [" & FormatNumber(SourceList.Count, 0) & " @ " & FormatNumber(totalDoms, 0) & "]")
            .AddRange(SourceList.Select(Function(x) "# " & x))
            .Add("")
            .Add("# Loopbacks")
            .Add("127.0.0.1" & IIf(chTabs.Checked, vbTab, " ").ToString & "localhost")
            .Add("::1" & IIf(chTabs.Checked, vbTab, " ").ToString & "localhost")
            .Add("")
            If BlackList.Count > 0 Then
                .Add("# Blacklist [" & FormatNumber(BlackList.Count, 0) & "]")
                .AddRange(BlackList.Select(Function(x) TargetIP & IIf(chTabs.Checked, vbTab, " ").ToString & x))
                .Add("")
            End If
            .Add("#" & IIf(chSort.Checked, " Sorted ", " ").ToString & "Domains [" & IIf(WhiteCount > 0, FormatNumber(uniCount + WhiteCount, 0) & "-" & FormatNumber(WhiteCount, 0) & "=" & FormatNumber(uniCount, 0) & "]", FormatNumber(uniCount, 0) & "]").ToString)
            .AddRange(UniHash)
            .Add("")
            .Add("# End")
        End With

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
                tipper.SetToolTip(LbSave, "Right-click to save to C:\WINDOWS\system32\drivers\etc")
            End If
            rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Generation Ended!" & vbCrLf & rtbLogs.Text
            rtbOuts.SelectionStart = 0
        End If
        rtbLogs.Text = "~ Took " & Microsoft.VisualBasic.Left(DateTime.Now.Subtract(startExec).ToString, 11) & vbCrLf & rtbLogs.Text
        LbReset.Enabled = True

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

    Private Sub LbAbout_Click(sender As Object, e As EventArgs) Handles LbAbout.Click
        Process.Start("https://github.com/Laicure/HostsY")
    End Sub

    Private Sub LbSave_MouseDown(sender As Object, e As MouseEventArgs) Handles LbSave.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If LbSave.Cursor = Cursors.Hand Then
                If fdBrowse.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim succ As Boolean = False
                    Try
                        rtbOuts.SaveFile(fdBrowse.SelectedPath & "\hosts", RichTextBoxStreamType.PlainText)
                        succ = True
                    Catch ex As Exception
                        rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Cannot Export!" & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & IIf(ex.Message.Contains("denied"), "> Run this app as admin!", "").ToString & vbCrLf & rtbLogs.Text
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
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            If LbSave.Cursor = Cursors.Hand Then
                If (MessageBox.Show(IIf(My.Computer.FileSystem.FileExists("C:\WINDOWS\system32\drivers\etc\hosts"), "Active hosts file detected!" & vbCrLf & "Are you sure to replace your active hosts file?", "No active hosts file detected!" & vbCrLf & "Are you sure to add a hosts file to your system?").ToString & vbCrLf & vbCrLf & "DNSCache must be disabled whenever using a large hosts file (~35k+ Entries) or else, your system will be crippled to no internet at all (for about an hour+)!", "Confirm Replace!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If

                Dim succ As Boolean = False
                Try
                    rtbOuts.SaveFile("C:\WINDOWS\system32\drivers\etc\hosts", RichTextBoxStreamType.PlainText)
                    succ = True
                Catch ex As Exception
                    rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Cannot Export!" & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & IIf(ex.Message.Contains("denied"), "> Run this app as admin!", "").ToString & vbCrLf & rtbLogs.Text
                End Try

                If succ Then
                    If My.Computer.FileSystem.FileExists("C:\WINDOWS\system32\drivers\etc\hosts") Then
                        Dim sizee As String = GetFileSize(My.Computer.FileSystem.GetFileInfo("C:\WINDOWS\system32\drivers\etc\hosts").Length)
                        LbSave.Text = "Click here to Save to a Location [" & sizee & "]"
                        rtbLogs.Text = "[" & Format(Now, "hh:mm:ss.ff tt MM/dd/yyyy") & "] Exported! @C:\WINDOWS\system32\drivers\etc (" & sizee & ")" & vbCrLf & rtbLogs.Text

                        'www.vbforfree.com/open-a-folderdirectory-and-selecthighlight-a-specific-file/
                        If My.Computer.FileSystem.FileExists("C:\WINDOWS\system32\drivers\etc\hosts") Then
                            Process.Start("explorer", "/select, C:\WINDOWS\system32\drivers\etc\hosts")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub LbStatus_MouseDown(sender As Object, e As MouseEventArgs) Handles LbStatus.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If My.Computer.FileSystem.FileExists("C:\WINDOWS\system32\drivers\etc\hosts") Then
                Process.Start("explorer", "/select, C:\WINDOWS\system32\drivers\etc\hosts")
            Else
                Process.Start("C:\WINDOWS\system32\drivers\etc")
            End If
        End If
    End Sub

    Private Sub LbReset_Click(sender As Object, e As EventArgs) Handles LbReset.Click
        Application.Restart()
    End Sub
End Class