Imports System.Text.RegularExpressions

Public Class HostsMain
	Dim SourceL() As String = Nothing
	Dim WhiteL() As String = Nothing
	Dim BlackL() As String = Nothing
	Dim Loopbacks As String = Nothing
	Dim startExec As DateTime = DateTime.UtcNow
	Dim errCount As Long = 0
	Dim preview As Boolean = False
	Friend sourceCacheList As New List(Of sourceCache)

	Friend Generated As String = Nothing

#Region "Auto"

	Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
		If Not Me.IsHandleCreated Then
			Me.CreateHandle()
			If Environment.GetCommandLineArgs.LongLength > 1 AndAlso Environment.CommandLine.Contains("-auto") Then
				value = False
				Autoo()
			Else
				value = True
			End If
		End If
		MyBase.SetVisibleCore(value)
	End Sub

	Private Sub Autoo()
		Dim argg As String = Replace(Environment.CommandLine, Environment.GetCommandLineArgs(0), "").Trim
		Dim dataSource As String = Application.StartupPath & "\Data"
		Dim tabb As Boolean = argg.Contains("-tab")
		Dim sortt As Boolean = argg.Contains("-sort")
		Dim logger As Boolean = argg.Contains("-logs")
		Dim zipp As Boolean = argg.Contains("-zip")
		Dim dpl As Boolean = Regex.Match(argg, "(\-dpl)([2-9])").Success

		'Check Directory
		If Not My.Computer.FileSystem.DirectoryExists(dataSource) Then My.Computer.FileSystem.CreateDirectory(dataSource)

		'Check sources
		If Not My.Computer.FileSystem.FileExists(dataSource & "\source.txt") Then My.Computer.FileSystem.WriteAllText(dataSource & "\source.txt", "", False)

		'Check whitelist
		If Not My.Computer.FileSystem.FileExists(dataSource & "\white.txt") Then My.Computer.FileSystem.WriteAllText(dataSource & "\white.txt", "", False)

		'Check blacklist
		If Not My.Computer.FileSystem.FileExists(dataSource & "\black.txt") Then My.Computer.FileSystem.WriteAllText(dataSource & "\black.txt", "", False)

		'Check Loopbacks
		If Not My.Computer.FileSystem.FileExists(dataSource & "\loopback.txt") Then My.Computer.FileSystem.WriteAllText(dataSource & "\loopback.txt", String.Join(vbCrLf, SetLoopBlacks), False)

		'########################## Start ##########################
		SourceL = My.Computer.FileSystem.ReadAllText(dataSource & "\source.txt").Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
		WhiteL = My.Computer.FileSystem.ReadAllText(dataSource & "\white.txt").Replace(" ", "").Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
		BlackL = My.Computer.FileSystem.ReadAllText(dataSource & "\black.txt").Replace(" ", "").Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
		Loopbacks = String.Join("|", My.Computer.FileSystem.ReadAllText(dataSource & "\loopback.txt").Replace(" ", "").Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries).ToArray.Select(Of String)(Function(x) "\b^" & Regex.Escape(x) & "$"))

		startExec = DateTime.UtcNow
		'Init Logging
		Dim Logg As String = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Generation Started!"
		Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Validating Sources" & vbCrLf & Logg

		'Validate Sources
		Dim SourceList As HashSet(Of String) = New HashSet(Of String)(SourceL.Select(Function(x) x.Replace(vbTab, "").Trim).Where(Function(x) Uri.TryCreate(x, UriKind.Absolute, Nothing)))
		'Exit if Source is empty
		If SourceList.Count = 0 Then
			Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] No valid sources listed!" & vbCrLf & Logg
			Environment.Exit(3)
			Exit Sub
		End If

		Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Validating Whitelist" & vbCrLf & Logg
		'Validate whitelist
		Dim WhiteList As HashSet(Of String) = New HashSet(Of String)(WhiteL.Where(Function(x) Not Regex.Match(x, Loopbacks, RegexOptions.IgnoreCase).Success))

		Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Validating Blacklist" & vbCrLf & Logg
		'Validate and match blacklist
		Dim BlackList As HashSet(Of String) = New HashSet(Of String)(BlackL.Select(Function(x) New Uri("http://" & x).DnsSafeHost).Where(Function(x) Not Regex.Match(x, Loopbacks, RegexOptions.IgnoreCase).Success))

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
			Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Reading " & arstring & "..." & vbCrLf & Logg
			Dim suc As Boolean = False
			Using clie As New Net.WebClient
				Try
					Dim readd As New IO.StreamReader(clie.OpenRead(arstring))
					Dim SourcedD As String = readd.ReadToEnd
					UniString = Nothing
					UniString += SourcedD & vbCrLf
					suc = True
				Catch ex As Exception
					Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Error Reading " & arstring & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & Logg
					errCount += 1
				End Try
			End Using
			If suc Then
				'### Clean Source data
				Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Cleaning Source... (+Retrieving Domain Count)" & vbCrLf & Logg

				'Remove Comments
				Dim SourceHash As HashSet(Of String) = New HashSet(Of String)(UniString.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) Regex.Replace(Replace(x, vbTab, " "), " {2,}", " ").Trim).Where(Function(x) Not x.StartsWith("#")).Where(Function(x) Not String.IsNullOrWhiteSpace(x)))
				'Remove Target IPs
				SourceHash = New HashSet(Of String)(SourceHash.Select(Function(x) IIf(Regex.Match(x, "^((([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))|((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)))\ ").Success, Microsoft.VisualBasic.Right(x, Len(x) - (x.IndexOf(" ") + 1)), x).ToString))
				'remove ip domains
				SourceHash = New HashSet(Of String)(SourceHash.Where(Function(x) Not Regex.Match(x, "(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))|((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))").Success))
				'Remove Comment Suffix
				Dim arrTempX() As String = SourceHash.ToArray
				SourceHash.Clear()
				SourceHash.TrimExcess()
				For y As Integer = 0 To arrTempX.Count - 1
					Dim urx As Uri = Nothing
					Dim urxError As Boolean = False
					Dim arrStr As String = arrTempX(y)

					'check domain validity
					If arrStr.Contains(" #") Then
						Try
							urx = New Uri("http://" & Microsoft.VisualBasic.Left(arrStr, arrStr.IndexOf(" #")).Trim)
						Catch ex As Exception
							urxError = True
						End Try
					Else
						Try
							urx = New Uri("http://" & arrStr.Trim)
						Catch ex As Exception
							urxError = True
						End Try
					End If
					If Not urxError Then
						Dim SafeHost As String = urx.DnsSafeHost
						If Not String.IsNullOrWhiteSpace(SafeHost) Then SourceHash.Add(SafeHost)
					Else
						Logg = "~ [" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Parse Error: " & arrStr & vbCrLf & Logg
						errCount += 1
					End If
				Next
				Erase arrTempX
				'Remove Loopbacks
				SourceHash = New HashSet(Of String)(SourceHash.Select(Function(x) StrConv(x.Trim, VbStrConv.Lowercase)).Where(Function(x) Not Regex.Match(x, Loopbacks, RegexOptions.IgnoreCase).Success))

				'show count
				totalDoms += SourceHash.LongCount
				Dim domCount As String = SourceHash.LongCount.ToString("#,0")
				Logg = Replace(Logg, "(+Retrieving Domain Count)", "Got " & domCount & " domains!")
				If Not SourceHash.Count = 0 Then
					If sortt Then SourceHash = New HashSet(Of String)(SourceHash.OrderBy(Function(x) x))
					SourceList.Add("[" & domCount & "] " & arstring)
					UniHash.UnionWith(SourceHash)
				End If
			End If
		Next
		Erase arrTemp

		'### if UniHash empty
		If UniHash.LongCount = 0 Then
			Logg = "Nothing to Generate!" & vbCrLf & Logg
			Environment.Exit(1)
			Exit Sub
		End If

		Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Merging Lists" & vbCrLf & Logg

		'remove blacklisted from whitelist
		WhiteList.ExceptWith(BlackList)
		WhiteList.TrimExcess()

		'remove whitelisted from unified list
		UniHash.ExceptWith(WhiteList)
		'whitelist regex
		If String.Join(" ", WhiteList).Contains("*") Then
			Dim asteWhite As HashSet(Of String) = New HashSet(Of String)(WhiteList.Where(Function(x) x.Contains("*")).Select(Function(x) "(^" & Regex.Escape(x).Replace("\*", ".+?") & "$)"))
			Dim whiteRegex As String = String.Join("|", asteWhite)
			Dim uniWhite As HashSet(Of String) = New HashSet(Of String)(UniHash.Where(Function(x) Not Regex.Match(x, whiteRegex, RegexOptions.IgnoreCase).Success))
			UniHash.Clear()
			UniHash.TrimExcess()
			UniHash = New HashSet(Of String)(uniWhite.Where(Function(x) Not String.IsNullOrWhiteSpace(x)))
		End If
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

		Dim tabSpace As String = IIf(tabb, vbTab, " ").ToString

		Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Adding Target IP" & vbCrLf & Logg

		'finalize unified data (add target IP and comment/remove items from WhiteList)
		Dim uniCount As Integer = UniHash.Count
		Dim TargetIP As String = "0.0.0.0"
		arrTemp = UniHash.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).ToArray
		UniHash.Clear()
		UniHash.TrimExcess()
		Dim arrTempCount As Integer = arrTemp.Count - 1
		If dpl Then
			Dim dplNum As Integer = CInt(Regex.Replace(argg, "^.+?(\-dpl)([2-9]).+?$", "$2"))
			Dim artemp As String = ""
			For i As Integer = 0 To arrTempCount
				artemp = artemp & " " & arrTemp(i)
				If (i + 1) Mod dplNum = 0 Then
					UniHash.Add(TargetIP & tabSpace & artemp.Trim)
					artemp = ""
				ElseIf i = arrTempCount Then
					UniHash.Add(TargetIP & tabSpace & artemp.Trim)
					artemp = ""
				End If
			Next
		Else
			For i As Integer = 0 To arrTempCount
				UniHash.Add(TargetIP & tabSpace & arrTemp(i))
			Next
		End If
		Erase arrTemp

		Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Finalizing Output" & vbCrLf & Logg
		'Append Entry Count and etc~
		Dim FinalList As New List(Of String)

		With FinalList
			.Add("# Entries: " & uniCount.ToString("#,0"))
			.Add("# As of " & DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss.ff UTC", Globalization.CultureInfo.InvariantCulture))
			.Add("# Generated using github.com/Laicure/HostsY")
			.Add("")
			.Add("# Sources [" & SourceList.Count.ToString("#,0") & " @ " & totalDoms.ToString("#,0") & "]")
			.AddRange(SourceList.Select(Function(x) "# " & x))
			.Add("")
			.Add("# Loopbacks")
			.Add("127.0.0.1" & tabSpace & "localhost")
			.Add("::1" & tabSpace & "localhost")
			.Add("")
			If BlackList.Count > 0 Then
				.Add("# Blacklist [" & BlackList.Count.ToString("#,0") & "]")
				.AddRange(BlackList.Select(Function(x) TargetIP & tabSpace & x))
				.Add("")
			End If
			.Add("#" & IIf(sortt, " Sorted ", " ").ToString & "Domains")
			.AddRange(UniHash)
			.Add("")
			.Add("# End")
			.Add("")
		End With

		'Save; needs admin privileges
		Try
			My.Computer.FileSystem.WriteAllText("C:\Windows\System32\drivers\etc\hosts", String.Join(vbCrLf, FinalList), False)
			'final Logs
			Dim sizee As String = GetFileSize(My.Computer.FileSystem.GetFileInfo("C:\Windows\System32\drivers\etc\hosts").Length)
			Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Exported! @" & "C:\Windows\System32\drivers\etc\hosts" & " (" & sizee & ")" & vbCrLf & Logg
		Catch ex As Exception
			Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Cannot Export!" & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & IIf(ex.Message.Contains("denied"), "> Run this app as admin!", "").ToString & vbCrLf & Logg
		End Try

		'-zip?
		If zipp Then
			Dim selPathhosts As String = dataSource & "\hosts_" & DateTime.UtcNow.ToString("yyyyMMddHHmmssffff", Globalization.CultureInfo.InvariantCulture) & ".zip"
			Try
				Dim tempoPath As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp\hostz"
				If Not My.Computer.FileSystem.DirectoryExists(tempoPath) Then
					My.Computer.FileSystem.CreateDirectory(tempoPath)
				End If
				My.Computer.FileSystem.WriteAllText(tempoPath & "\hosts", String.Join(vbCrLf, FinalList), False)
				IO.Compression.ZipFile.CreateFromDirectory(tempoPath, selPathhosts, IO.Compression.CompressionLevel.Optimal, False)

				Dim sizee As String = GetFileSize(My.Computer.FileSystem.GetFileInfo(selPathhosts).Length)
				Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Exported! @" & dataSource & " (" & sizee & ")" & vbCrLf & Logg
			Catch ex As Exception
				Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Cannot Export!" & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & IIf(ex.Message.Contains("denied"), "> Run this app as admin!", "").ToString & vbCrLf & Logg
			End Try
		End If

		If errCount > 0 Then Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Error Count: " & errCount.ToString("#,0") & vbCrLf & Logg
		Logg = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Generation Ended!" & vbCrLf & Logg

		If logger Then My.Computer.FileSystem.WriteAllText(dataSource & "\logs.txt", Logg, False)

		Environment.Exit(0)
	End Sub

#End Region

	Private Sub HostsMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.Text = "HostsY v" & My.Application.Info.Version.ToString
		Me.Icon = My.Resources.art
	End Sub

	Private Sub LbGenerate_Click(sender As Object, e As EventArgs) Handles LbGenerate.Click
		If String.IsNullOrWhiteSpace(txSources.Text) Then Exit Sub

		If LbGenerate.Text = "Cancel Generation" Then
			bgGenerate.CancelAsync()
			LbGenerate.Text = "Generate Hosts File"
			Exit Sub
		End If

		If bgGenerate.IsBusy And bgGenerate.CancellationPending Then
			MessageBox.Show("Cancellation in progress...", "Please wait!", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Exit Sub
		End If

		'preview?
		If SetPreview Then
			If HostsPreview.Visible Then HostsPreview.Close()
			Dim PreviewResult As Integer = MessageBox.Show("Do you want to show the host file preview?" & vbCrLf & vbCrLf & "Not recommended for large hosts files!", "Preview?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
			If PreviewResult = DialogResult.Yes Then
				preview = True
			ElseIf PreviewResult = DialogResult.No Then
				preview = False
				LbPreview.Visible = False
			Else
				Exit Sub
			End If
		End If

		'deactivate controls
		txSources.ReadOnly = True
		txWhites.ReadOnly = True
		txBlacks.ReadOnly = True

		LbSave.Cursor = Cursors.Default
		LbSave.Text = "..."
		LbSettings.Enabled = False

		'reset content
		txLogs.Clear()
		LbSource.Text = "Sources"
		LbWhites.Text = "Whitelist"
		LbBlacks.Text = "Blacklist"

		'set vars
		errCount = 0
		Loopbacks = String.Join("|", SetLoopBlacks.Select(Of String)(Function(x) "\b^" & Regex.Escape(x) & "$"))
		Generated = Nothing

		LbGenerate.Text = "Cancel Generation"
		SourceL = txSources.Text.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
		WhiteL = txWhites.Text.Replace(" ", "").Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
		BlackL = txBlacks.Text.Replace(" ", "").Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries)
		bgGenerate.RunWorkerAsync()
	End Sub

	Private Sub BgGenerate_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgGenerate.DoWork
		'### Retrieve all Source Data
		startExec = DateTime.UtcNow

		txLogs.Invoke(DirectCast(
					   Sub()
						   txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Generation Started!"
						   txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Validating Sources" & vbCrLf & txLogs.Text
					   End Sub, MethodInvoker))
		'Download and Validate Source List
		Dim SourceList As HashSet(Of String) = New HashSet(Of String)(SourceL.Select(Function(x) x.Replace(vbTab, "").Trim).Where(Function(x) Uri.TryCreate(x, UriKind.Absolute, Nothing)))
		LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources [" & SourceList.Count & "]", MethodInvoker))
		txSources.Invoke(DirectCast(Sub() txSources.Text = String.Join(vbCrLf, SourceList), MethodInvoker))

		If SourceList.Count = 0 Then
			LbSource.Invoke(DirectCast(Sub() LbSource.Text = "Sources", MethodInvoker))
			txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] No valid sources listed!" & vbCrLf & txLogs.Text, MethodInvoker))
			Exit Sub
		End If

		If bgGenerate.CancellationPending Then
			e.Cancel = True
			Exit Sub
		End If

		txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Validating Whitelist" & vbCrLf & txLogs.Text, MethodInvoker))
		'Validate whitelist
		Dim WhiteList As HashSet(Of String) = New HashSet(Of String)(WhiteL.Where(Function(x) Not Regex.Match(x, Loopbacks, RegexOptions.IgnoreCase).Success))
		LbWhites.Invoke(DirectCast(Sub() LbWhites.Text = "Whitelist [" & WhiteList.Count & "]", MethodInvoker))
		txWhites.Invoke(DirectCast(Sub() txWhites.Text = String.Join(vbCrLf, WhiteList), MethodInvoker))

		If bgGenerate.CancellationPending Then
			e.Cancel = True
			Exit Sub
		End If

		txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Validating Blacklist" & vbCrLf & txLogs.Text, MethodInvoker))
		'Validate and match blacklist
		Dim BlackList As HashSet(Of String) = New HashSet(Of String)(BlackL.Select(Function(x) New Uri("http://" & x).DnsSafeHost).Where(Function(x) Not Regex.Match(x, Loopbacks, RegexOptions.IgnoreCase).Success))
		LbBlacks.Invoke(DirectCast(Sub() LbBlacks.Text = "Blacklist [" & BlackList.Count & "]", MethodInvoker))
		txBlacks.Invoke(DirectCast(Sub() txBlacks.Text = String.Join(vbCrLf, BlackList), MethodInvoker))

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
			'use cache instead of reading again
			If SetUseCache AndAlso sourceCacheList.Any(Function(x) x.URL = arstring) Then
				txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Reading saved cache of " & arstring & "..." & vbCrLf & txLogs.Text, MethodInvoker))

				Dim SourceHash As New HashSet(Of String)(sourceCacheList.Where(Function(x) x.URL = arstring).Select(Function(x) x.Domains).FirstOrDefault.Split({vbCr, vbLf, vbCrLf}, StringSplitOptions.RemoveEmptyEntries))

				'show count
				totalDoms += SourceHash.LongCount
				Dim domCount As String = SourceHash.LongCount.ToString("#,0")
				txLogs.Invoke(DirectCast(Sub() txLogs.Text = Replace(txLogs.Text, "(+Retrieving Domain Count)", "Got " & domCount & " domains!"), MethodInvoker))
				If Not SourceHash.Count = 0 Then
					If SetSort Then SourceHash = New HashSet(Of String)(SourceHash.OrderBy(Function(x) x))
					SourceList.Add("[" & domCount & "] " & arstring)
					UniHash.UnionWith(SourceHash)
				End If
			Else
				txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Reading " & arstring & "..." & vbCrLf & txLogs.Text, MethodInvoker))
				Dim suc As Boolean = False
				Using clie As New Net.WebClient
					Try
						Dim readd As New IO.StreamReader(clie.OpenRead(arstring))
						Dim SourcedD As String = readd.ReadToEnd
						UniString = Nothing
						UniString += SourcedD & vbCrLf
						suc = True
					Catch ex As Exception
						txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Error Reading " & arstring & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & txLogs.Text, MethodInvoker))
						errCount += 1
					End Try
				End Using
				If suc Then
					'### Clean Source data
					txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Cleaning Source... (+Retrieving Domain Count)" & vbCrLf & txLogs.Text, MethodInvoker))

					'Remove Comments
					Dim SourceHash As HashSet(Of String) = New HashSet(Of String)(UniString.Split({vbCrLf, vbCr, vbLf}, StringSplitOptions.RemoveEmptyEntries).Select(Function(x) Regex.Replace(Replace(x, vbTab, " "), " {2,}", " ").Trim).Where(Function(x) Not x.StartsWith("#")).Where(Function(x) Not String.IsNullOrWhiteSpace(x)))
					'Remove Target IPs
					SourceHash = New HashSet(Of String)(SourceHash.Select(Function(x) IIf(Regex.Match(x, "^((([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))|((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)))\ ").Success, Microsoft.VisualBasic.Right(x, Len(x) - (x.IndexOf(" ") + 1)), x).ToString))
					'remove ip domains
					SourceHash = New HashSet(Of String)(SourceHash.Where(Function(x) Not Regex.Match(x, "(([0-9a-fA-F]{1,4}:){7,7}[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,7}:|([0-9a-fA-F]{1,4}:){1,6}:[0-9a-fA-F]{1,4}|([0-9a-fA-F]{1,4}:){1,5}(:[0-9a-fA-F]{1,4}){1,2}|([0-9a-fA-F]{1,4}:){1,4}(:[0-9a-fA-F]{1,4}){1,3}|([0-9a-fA-F]{1,4}:){1,3}(:[0-9a-fA-F]{1,4}){1,4}|([0-9a-fA-F]{1,4}:){1,2}(:[0-9a-fA-F]{1,4}){1,5}|[0-9a-fA-F]{1,4}:((:[0-9a-fA-F]{1,4}){1,6})|:((:[0-9a-fA-F]{1,4}){1,7}|:)|fe80:(:[0-9a-fA-F]{0,4}){0,4}%[0-9a-zA-Z]{1,}|::(ffff(:0{1,4}){0,1}:){0,1}((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])|([0-9a-fA-F]{1,4}:){1,4}:((25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9])\.){3,3}(25[0-5]|(2[0-4]|1{0,1}[0-9]){0,1}[0-9]))|((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))").Success))
					'Remove Comment Suffix
					Dim arrTempX() As String = SourceHash.ToArray
					SourceHash.Clear()
					SourceHash.TrimExcess()
					For y As Integer = 0 To arrTempX.Count - 1
						If bgGenerate.CancellationPending Then
							e.Cancel = True
							Exit Sub
						End If

						'check domain validity
						Dim urx As Uri = Nothing
						Dim urxError As Boolean = False
						Dim arrStr As String = arrTempX(y)
						If arrStr.Contains(" #") Then
							Try
								urx = New Uri("http://" & Microsoft.VisualBasic.Left(arrStr, arrStr.IndexOf(" #")).Trim)
							Catch ex As Exception
								urxError = True
							End Try
						Else
							Try
								urx = New Uri("http://" & arrStr.Trim)
							Catch ex As Exception
								urxError = True
							End Try
						End If
						If Not urxError Then
							Dim SafeHost As String = urx.DnsSafeHost
							If Not String.IsNullOrWhiteSpace(SafeHost) Then SourceHash.Add(SafeHost)
						Else
							If SetParseErrors Then txLogs.Invoke(DirectCast(Sub() txLogs.Text = "~ [" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Parse Error: " & arrStr & vbCrLf & txLogs.Text, MethodInvoker))
							errCount += 1
						End If
					Next
					Erase arrTempX
					'Remove Loopbacks
					SourceHash = New HashSet(Of String)(SourceHash.Select(Function(x) StrConv(x.Trim, VbStrConv.Lowercase)).Where(Function(x) Not Regex.Match(x, Loopbacks, RegexOptions.IgnoreCase).Success))

					'save to cache
					If sourceCacheList.Any(Function(x) x.URL = arstring) Then sourceCacheList.RemoveAll(Function(x) x.URL = arstring)
					sourceCacheList.Add(New sourceCache With {.URL = arstring, .Domains = String.Join(vbCrLf, SourceHash)})

					'show count
					totalDoms += SourceHash.LongCount
					Dim domCount As String = SourceHash.LongCount.ToString("#,0")
					txLogs.Invoke(DirectCast(Sub() txLogs.Text = Replace(txLogs.Text, "(+Retrieving Domain Count)", "Got " & domCount & " domains!"), MethodInvoker))
					If Not SourceHash.Count = 0 Then
						If SetSort Then SourceHash = New HashSet(Of String)(SourceHash.OrderBy(Function(x) x))
						SourceList.Add("[" & domCount & "] " & arstring)
						UniHash.UnionWith(SourceHash)
					End If
				End If
			End If
		Next
		Erase arrTemp

		'### if UniHash empty
		If bgGenerate.CancellationPending Then
			e.Cancel = True
			Exit Sub
		End If

		txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Merging Lists" & vbCrLf & txLogs.Text, MethodInvoker))

		'remove blacklisted from whitelist
		With WhiteList
			.ExceptWith(BlackList)
			.TrimExcess()
		End With

		'remove whitelisted from unified list
		UniHash.ExceptWith(WhiteList.Where(Function(x) Not x.Contains("*")))
		'whitelist regex
		If String.Join(" ", WhiteList).Contains("*") Then
			Dim asteWhite As HashSet(Of String) = New HashSet(Of String)(WhiteList.Where(Function(x) x.Contains("*")).Select(Function(x) "(^" & Regex.Escape(x).Replace("\*", ".+?") & "$)"))
			Dim whiteRegex As String = String.Join("|", asteWhite)
			Dim uniWhite As HashSet(Of String) = New HashSet(Of String)(UniHash.Where(Function(x) Not Regex.Match(x, whiteRegex, RegexOptions.IgnoreCase).Success))
			UniHash.Clear()
			UniHash.TrimExcess()
			UniHash = New HashSet(Of String)(uniWhite.Where(Function(x) Not String.IsNullOrWhiteSpace(x)))
		End If
		UniHash.TrimExcess()

		'remove already unified listed from blacklist
		With BlackList
			.ExceptWith(UniHash)
			.TrimExcess()
		End With

		'### Empty List check
		If bgGenerate.CancellationPending Then
			e.Cancel = True
			Exit Sub
		End If

		Dim tabSpace As String = IIf(SetTabs, vbTab, " ").ToString

		txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] " & "Adding Target IP" & vbCrLf & txLogs.Text, MethodInvoker))
		'finalize unified data (add target IP and comment/remove items from WhiteList)
		Dim uniCount As Integer = UniHash.Count
		Dim TargetIP As String = SetTargetIP
		arrTemp = UniHash.Where(Function(x) Not String.IsNullOrWhiteSpace(x)).ToArray
		UniHash.Clear()
		UniHash.TrimExcess()
		Dim arrTempCount As Integer = arrTemp.Count - 1
		If SetDomainPerLine > 1 Then
			Dim artemp As String = ""
			For i As Integer = 0 To arrTempCount
				If bgGenerate.CancellationPending Then
					e.Cancel = True
					Exit Sub
				End If
				artemp = artemp & " " & arrTemp(i)
				If (i + 1) Mod SetDomainPerLine = 0 Then
					UniHash.Add(TargetIP & tabSpace & artemp.Trim)
					artemp = ""
				ElseIf i = arrTempCount Then
					UniHash.Add(TargetIP & tabSpace & artemp.Trim)
					artemp = ""
				End If
			Next
		Else
			For i As Integer = 0 To arrTempCount
				If bgGenerate.CancellationPending Then
					e.Cancel = True
					Exit Sub
				End If

				UniHash.Add(TargetIP & tabSpace & arrTemp(i))
			Next
		End If
		Erase arrTemp

		If bgGenerate.CancellationPending Then
			e.Cancel = True
			Exit Sub
		End If

		txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Finalizing Output" & vbCrLf & txLogs.Text, MethodInvoker))
		'Append Entry Count and etc~
		Dim FinalList As New List(Of String)

		With FinalList
			.Add("# Entries: " & uniCount.ToString("#,0"))
			.Add("# As of " & DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss.ff UTC", Globalization.CultureInfo.InvariantCulture))
			.Add("# Generated using github.com/Laicure/HostsY")
			.Add("")
			.Add("# Sources [" & SourceList.Count.ToString("#,0") & " @ " & totalDoms.ToString("#,0") & "]")
			.AddRange(SourceList.Select(Function(x) "# " & x))
			.Add("")
			.Add("# Loopbacks")
			.Add("127.0.0.1" & tabSpace & "localhost")
			.Add("::1" & tabSpace & "localhost")
			.Add("")
			If BlackList.Count > 0 Then
				.Add("# Blacklist [" & BlackList.Count.ToString("#,0") & "]")
				.AddRange(BlackList.Select(Function(x) TargetIP & tabSpace & x))
				.Add("")
			End If
			.Add("#" & IIf(SetSort, " Sorted ", " ").ToString & "Domains")
			.AddRange(UniHash)
			.Add("")
			.Add("# End")
			.Add("")
		End With

		If bgGenerate.CancellationPending Then
			e.Cancel = True
			Exit Sub
		End If

		If errCount > 0 Then txLogs.Invoke(DirectCast(Sub() txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Error Count: " & errCount.ToString("#,0") & vbCrLf & txLogs.Text, MethodInvoker))

		Generated = String.Join(vbCrLf, FinalList)
	End Sub

	Private Sub BgGenerate_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgGenerate.RunWorkerCompleted
		If preview Then
			txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff", Globalization.CultureInfo.InvariantCulture) & "] Generating Preview" & vbCrLf & txLogs.Text
			LbPreview.Visible = True
			'Preview
			If Not HostsPreview.Visible Then HostsPreview.Show(Me)
		End If

		'reactivate controls
		txSources.ReadOnly = False
		txWhites.ReadOnly = False
		txBlacks.ReadOnly = False

		LbSettings.Enabled = True

		LbGenerate.Text = "Generate Hosts File"
		If e.Cancelled Then
			txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Generation Cancelled!" & vbCrLf & txLogs.Text
		Else
			If IsNothing(Generated) Then
				MessageBox.Show("No valid source to parse!", "Nothing!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			Else
				LbSave.Cursor = Cursors.Hand
				LbSave.Text = "Click here to Save to a Location"
			End If
			txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Generation Ended!" & vbCrLf & txLogs.Text
		End If
		txLogs.Text = "~ Took " & Microsoft.VisualBasic.Left(DateTime.UtcNow.Subtract(startExec).ToString, 11) & vbCrLf & txLogs.Text

		Erase SourceL
		Erase WhiteL
		Erase BlackL
	End Sub

	Private Sub LbPreview_Click(sender As Object, e As EventArgs) Handles LbPreview.Click
		If Not HostsPreview.Visible Then HostsPreview.Show(Me)
	End Sub

	Private Sub HostsMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		Me.Hide()
		If bgGenerate.IsBusy Then bgGenerate.CancelAsync()
	End Sub

	Private Sub LbSave_MouseDown(sender As Object, e As MouseEventArgs) Handles LbSave.MouseDown
		If e.Button = System.Windows.Forms.MouseButtons.Left Then
			If LbSave.Cursor = Cursors.Hand Then
				If fdBrowse.ShowDialog = System.Windows.Forms.DialogResult.OK Then
					Dim selPathhosts As String = fdBrowse.SelectedPath & "\hosts"
					Dim succ As Boolean = False
					Try
						My.Computer.FileSystem.WriteAllText(selPathhosts, Generated, False, System.Text.Encoding.Default)
						succ = True
					Catch ex As Exception
						txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Cannot Export!" & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & IIf(ex.Message.Contains("denied"), "> Run this app as admin!", "").ToString & vbCrLf & txLogs.Text
					End Try

					If succ Then
						If My.Computer.FileSystem.FileExists(selPathhosts) Then
							Dim sizee As String = GetFileSize(My.Computer.FileSystem.GetFileInfo(selPathhosts).Length)
							LbSave.Text = "Click here to Save to a Location [" & sizee & "]"
							txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Exported! @" & fdBrowse.SelectedPath & " (" & sizee & ")" & vbCrLf & txLogs.Text
							'www.vbforfree.com/open-a-folderdirectory-and-selecthighlight-a-specific-file/
							Process.Start("explorer", "/select, " & selPathhosts)
						End If
					End If
				End If
			End If
		ElseIf e.Button = System.Windows.Forms.MouseButtons.Right Then
			If LbSave.Cursor = Cursors.Hand Then
				Dim syshostsPath As String = "C:\WINDOWS\system32\drivers\etc\hosts"
				If MessageBox.Show(IIf(My.Computer.FileSystem.FileExists(syshostsPath), "Active hosts file detected!" & vbCrLf & "Are you sure to replace your active hosts file?", "No active hosts file detected!" & vbCrLf & "Are you sure to add a hosts file to your system?").ToString & vbCrLf & vbCrLf & "DNSCache must be disabled whenever using a large hosts file (~35k+ Entries) or else, your system will be crippled to no internet at all (for about an hour+)!", "Confirm Replace!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.No Then Exit Sub

				Dim succ As Boolean = False
				Try
					My.Computer.FileSystem.WriteAllText(syshostsPath, Generated, False, System.Text.Encoding.Default)
					succ = True
				Catch ex As Exception
					txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Cannot Export!" & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & IIf(ex.Message.Contains("denied"), "> Run this app as admin!", "").ToString & vbCrLf & txLogs.Text
				End Try

				If succ Then
					If My.Computer.FileSystem.FileExists(syshostsPath) Then
						Dim sizee As String = GetFileSize(My.Computer.FileSystem.GetFileInfo(syshostsPath).Length)
						LbSave.Text = "Click here to Save to a Location [" & sizee & "]"
						txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Exported! @C:\WINDOWS\system32\drivers\etc (" & sizee & ")" & vbCrLf & txLogs.Text

						'www.vbforfree.com/open-a-folderdirectory-and-selecthighlight-a-specific-file/
						If My.Computer.FileSystem.FileExists(syshostsPath) Then Process.Start("explorer", "/select, C:\WINDOWS\system32\drivers\etc\hosts")
					End If
				End If
			End If
		ElseIf e.Button = System.Windows.Forms.MouseButtons.Middle Then
			If LbSave.Cursor = Cursors.Hand Then
				If fdBrowse.ShowDialog = System.Windows.Forms.DialogResult.OK Then
					Dim selPathhosts As String = fdBrowse.SelectedPath & "\hosts_" & DateTime.UtcNow.ToString("yyyyMMddHHmmssffff", Globalization.CultureInfo.InvariantCulture) & ".zip"
					Dim succ As Boolean = False
					Try
						Dim tempoPath As String = "C:\Users\" & Environment.UserName & "\AppData\Local\Temp\hostz"
						If Not My.Computer.FileSystem.DirectoryExists(tempoPath) Then My.Computer.FileSystem.CreateDirectory(tempoPath)
						My.Computer.FileSystem.WriteAllText(tempoPath & "\hosts", Generated, False, System.Text.Encoding.Default)
						IO.Compression.ZipFile.CreateFromDirectory(tempoPath, selPathhosts, IO.Compression.CompressionLevel.Optimal, False)
						succ = True
					Catch ex As Exception
						txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Cannot Export!" & vbCrLf & "> (" & ex.Source & ") " & ex.Message & vbCrLf & IIf(ex.Message.Contains("denied"), "> Run this app as admin!", "").ToString & vbCrLf & txLogs.Text
					End Try

					If succ Then
						If My.Computer.FileSystem.FileExists(selPathhosts) Then
							Dim sizee As String = GetFileSize(My.Computer.FileSystem.GetFileInfo(selPathhosts).Length)
							LbSave.Text = "Click here to Save to a Location [" & sizee & "]"
							txLogs.Text = "[" & DateTime.UtcNow.ToString("HH:mm:ss.ff UTC MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture) & "] Exported! @" & fdBrowse.SelectedPath & " (" & sizee & ")" & vbCrLf & txLogs.Text
							'www.vbforfree.com/open-a-folderdirectory-and-selecthighlight-a-specific-file/
							Process.Start("explorer", "/select, " & selPathhosts)
						End If
					End If
				End If
			End If
		End If
	End Sub

	Private Sub LbSettings_Click(sender As Object, e As EventArgs) Handles LbSettings.Click
		HostsSettings.ShowDialog(Me)
	End Sub

End Class

Friend Class sourceCache
	Friend Property URL As String
	Friend Property Domains As String
End Class