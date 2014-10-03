
Imports System
Imports System.IO
Imports System.Diagnostics.Process
Imports System.Threading
Imports System.Text
Imports System.Management

Public Class frmMain

    Dim TempExec As String = "__temp.bat"
    Dim TempTxt As String = "_temp.txt"

    Dim arrOpt(6) As String
    Dim ResultSetMode As Integer
    Dim global_path As String
    Dim editor As String
    Dim editor_param As String
    Dim max_result_count As Integer
    Dim max_history_count As Integer
    Dim DicBookmark As New ArrayList
    Dim appdata_path As String
    Dim hist_cmd_path As String

    Dim procExecGlobal = New Process()

    Public Sub KillAllChildProcess(ByVal pid As Integer)
        Dim selectQuery As SelectQuery = New SelectQuery("Win32_Process")
        Dim searcher As New ManagementObjectSearcher(selectQuery)

        For Each proc As ManagementObject In searcher.Get
            If proc("ParentProcessId") = pid Then
                Process.GetProcessById(proc("ProcessId")).Kill()
            End If
        Next
    End Sub

    Public Function GetChildProcessStr(ByVal pid As Integer) As String

        Dim selectQuery As SelectQuery = New SelectQuery("Win32_Process")
        Dim searcher As New ManagementObjectSearcher(selectQuery)
        Dim str As String = ""

        For Each proc As ManagementObject In searcher.Get
            If proc("ParentProcessId") = pid Then
                str = str + proc("Name") + " : " + proc("ProcessId").ToString + vbCrLf
            End If
        Next

        Return str
    End Function

    Public Sub WaitFileInUse(ByVal filename As String, ByVal ms_delay As Integer)
        While True
            Try
                Using TestForAccess As New IO.FileStream(filename, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.None) : End Using
                Exit While
            Catch ex As Exception
                ''do nothing just retry, ok la sleep awhile
                Thread.Sleep(ms_delay)
            End Try
        End While
    End Sub

    Public Sub ConfigBookmark(ByVal filename As String)
        Dim rconfig As System.IO.StreamReader
        Dim strConfig() As String
        Dim book() As String

        DicBookmark.Clear()

        rconfig = File.OpenText(filename)
        strConfig = rconfig.ReadToEnd().Split(vbCrLf)
        For i = 0 To strConfig.GetUpperBound(0)
            If strConfig(i).Trim.StartsWith("#") = False Then
                If strConfig(i).Trim.Split("@").Length = 3 Then
                    DicBookmark.Add(strConfig(i))
                End If
            End If

        Next
        rconfig.Close()

        cmbBookmark.Items.Clear()
        For Each bookmark In DicBookmark
            book = bookmark.trim.split("@")
            cmbBookmark.Items.Add(book(0))
        Next
    End Sub

    Public Sub ConfigFile(ByVal filename As String)

        Dim rconfig As System.IO.StreamReader
        Dim strConfig() As String
        Dim strElement() As String

        '' hardcode default value
        max_result_count = 5000
        max_history_count = 50

        rconfig = File.OpenText(filename)
        strConfig = rconfig.ReadToEnd().Split(vbCrLf)
        For i = 0 To strConfig.GetUpperBound(0)
            If strConfig(i).Trim.StartsWith("#") = False Then
                strElement = strConfig(i).Trim.Split("=")
                Select Case strElement(0)
                    Case "$BinPath"
                        global_path = strElement(1).Trim
                    Case "$Editor"
                        editor = strElement(1).Trim
                    Case "$EditorParam"
                        editor_param = strElement(1).Trim
                    Case "$MaxResultCount"
                        max_result_count = Convert.ToInt32(strElement(1).Trim)
                    Case "$MaxHistoryCount"
                        max_history_count = Convert.ToInt32(strElement(1).Trim)
                    Case Else

                End Select
            End If

        Next
        rconfig.Close()

    End Sub

    Public Sub ExecConsole()
        Dim proc = New Process()
        Dim cd As String

        cd = Environment.CurrentDirectory

        proc.StartInfo.FileName = "cmd.exe"
        proc.StartInfo.Arguments =
        proc.StartInfo.WorkingDirectory = txtRoot.Text.Trim()
        REM proc.StartInfo.UseShellExecute = False
        proc.Start()

    End Sub

    Public Sub ExecEditor(ByVal my_editor As String, ByVal my_param As String, ByVal strRoot As String)
        Dim proc = New Process()
        Dim cd As String

        cd = Environment.CurrentDirectory

        If my_editor.Trim.StartsWith(".") Then
            my_editor = cd + "/" + my_editor
        End If

        proc.StartInfo.FileName = my_editor
        proc.StartInfo.Arguments = my_param
        proc.StartInfo.WorkingDirectory = strRoot
        REM proc.StartInfo.UseShellExecute = False
        proc.Start()

    End Sub


    Private Sub butSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSearch.Click

        Dim args As ExecGlobalParam_Type = New ExecGlobalParam_Type()

        If bgwExecGlobal.IsBusy Then
            txtCmd.Text = " Search in progress. Please stop the search before new search."
            Return
        End If
        ResultSetMode = lstOption.SelectedIndex

        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        lblStatus.Text = "Searching in progress..."
        lblStatus.Visible = True
        lblStatus.Refresh()

        With args
            ._opt = arrOpt(lstOption.SelectedIndex)
            ._search = cmbSearch.Text.Trim
            ._root = txtRoot.Text
            ._dbpath = txtDbPath.Text
        End With

        '' keep journal of search text
        If cmbSearch.Items.Count > 0 Then
            If cmbSearch.Items.Item(0).ToString <> cmbSearch.Text Then
                cmbSearch.Items.Insert(0, cmbSearch.Text)
            End If
        Else ''first time
            cmbSearch.Items.Insert(0, cmbSearch.Text)
        End If

        If cmbSearch.Items.Count > max_history_count Then
            cmbSearch.Items.RemoveAt(max_history_count)
        End If

        bgwExecGlobal.RunWorkerAsync(args)


    End Sub



    Private Sub butRoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRoot.Click
        fbd.Description = "Please select your GTAGSROOT."
        fbd.ShowNewFolderButton = False
        If txtRoot.Text <> "" Then
            fbd.SelectedPath = txtRoot.Text
        End If
        If fbd.ShowDialog = DialogResult.OK Then
            txtRoot.Text = fbd.SelectedPath
        End If

    End Sub

    Private Sub butDbpath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDbpath.Click
        fbd.Description = "Please select your GTAGSDBPATH."
        fbd.ShowNewFolderButton = False
        If txtDbPath.Text <> "" Then
            fbd.SelectedPath = txtDbPath.Text
        End If
        If fbd.ShowDialog = DialogResult.OK Then
            txtDbPath.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub dgvResult_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResult.CellContentDoubleClick
        Dim strEditorParam As String

        Select Case ResultSetMode
            Case 0, 6
                If lstOption.SelectedIndex = ResultSetMode Then
                    lstOption.SelectedIndex = 1
                End If

                cmbSearch.Text = dgvResult.SelectedCells(0).Value.ToString
                butSearch_Click(sender, e)
            Case 1, 2, 3, 4
                strEditorParam = editor_param.Replace("%LN", dgvResult.SelectedCells(1).Value.ToString).Replace("%FN", dgvResult.SelectedCells(2).Value.ToString)
                REM MsgBox(editor + " " + strEditorParam)
                ExecEditor(editor, strEditorParam, txtRoot.Text)
            Case 5
                strEditorParam = editor_param.Replace("%LN", "").Replace("%FN", dgvResult.SelectedCells(0).Value.ToString)
                ExecEditor(editor, strEditorParam, txtRoot.Text)
            Case 7, 8
                If lstOption.SelectedIndex = ResultSetMode Then
                    lstOption.SelectedIndex = 3
                End If

                cmbSearch.Text = dgvResult.SelectedCells(0).Value.ToString
                butSearch_Click(sender, e)
            Case Else

        End Select
    End Sub


    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim file As System.IO.StreamWriter

        My.Settings.PrevGtagsDbPath = txtDbPath.Text
        My.Settings.PrevGtagsRoot = txtRoot.Text

        If System.IO.File.Exists(TempTxt) = True Then
            System.IO.File.Delete(TempTxt)
        End If

        If System.IO.File.Exists(TempExec) = True Then
            System.IO.File.Delete(TempExec)
        End If

        If cmbSearch.Items.Count <> 0 Then
            file = My.Computer.FileSystem.OpenTextFileWriter(hist_cmd_path, False)
            For Each item In cmbSearch.Items
                file.WriteLine(item.ToString)
            Next
            file.Close()
        End If

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim path As String
        Dim cd As String
        Dim my_pid As Integer = Process.GetCurrentProcess().Id
        Dim fileReader As System.IO.StreamReader
        REM Dim argv = System.Environment.GetCommandLineArgs()
        REM MsgBox(argv(0))

        lstOption.SelectedIndex = 0
        arrOpt = {"-c", "-x", "-rx", "-sx", "-gx", "-fn", "-ch", "-csh", "-cs"}
        ConfigFile("GlobalBrowse.ini")
        ConfigBookmark("Bookmark.ini")
        txtDbPath.Text = My.Settings.PrevGtagsDbPath
        txtRoot.Text = My.Settings.PrevGtagsRoot
        path = Environment.GetEnvironmentVariable("PATH")
        If global_path.StartsWith("./") Or global_path.StartsWith(".\") Then
            cd = Environment.CurrentDirectory
            global_path = cd + "\" + global_path.Replace(".\", "").Replace("./", "").Trim
        End If
        path = path + ";" + global_path
        Environment.SetEnvironmentVariable("PATH", path)

        TempExec = my_pid.ToString + TempExec
        TempTxt = my_pid.ToString + TempTxt

        ''create globalbrowse dir in %appdata% if not exist
        appdata_path = Environment.GetEnvironmentVariable("appdata") + "/globalbrowse"
        hist_cmd_path = appdata_path + "\history_cmd.txt"
        If (Not System.IO.Directory.Exists(appdata_path)) Then
            System.IO.Directory.CreateDirectory(appdata_path)
        Else
            ''check any cmd_history.txt, if yes, load up the cmbSearch.Item
            Dim myline As String
            fileReader = My.Computer.FileSystem.OpenTextFileReader(hist_cmd_path)
            
            Do
                myline = fileReader.ReadLine()
                If myline Is Nothing Then Exit Do
                If Trim(myline) IsNot "" Then
                    cmbSearch.Items.Add(myline)
                End If
            Loop
            fileReader.Close()

        End If


    End Sub



    Private Sub lstOption_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstOption.Click
        If lstOption.SelectedIndex = 0 Then
            butSearch_Click(sender, e)
        ElseIf cmbSearch.Text <> "" Then
            butSearch_Click(sender, e)
        End If
    End Sub


    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        cmbSearch.Text = ""
        lstOption.SelectedIndex = 0
    End Sub


    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        bgwExecGlobal.CancelAsync()
    End Sub

    Private Sub bgwExecGlobal_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwExecGlobal.DoWork

        Dim args As ExecGlobalParam_Type = e.Argument

        Environment.SetEnvironmentVariable("GTAGSROOT", args._root)
        Environment.SetEnvironmentVariable("GTAGSDBPATH", args._dbpath)
        Environment.SetEnvironmentVariable("MYCD", Environment.CurrentDirectory)

        REM MsgBox(Environment.GetEnvironmentVariable("MYCD"))

        Dim objWriter As New System.IO.StreamWriter(TempExec)
        Dim mystr As String
        Dim strcase As String

        If chkIgnoreCase.Checked Then
            strcase = "-i "
        Else
            strcase = ""
        End If

        If args._opt = "-fn" Then
            mystr = "grep -r " + strcase + args._search + " " + args._dbpath + "\source_list" + " > ""#MYCD#\".Replace("#", "%") + TempTxt + """" + vbCrLf
        ElseIf args._opt = "-ch" Then
            If File.Exists(args._dbpath + "\symbol_list") Then
                mystr = "grep " + strcase + args._search + " " + args._dbpath + "\symbol_list" + " > ""#MYCD#\".Replace("#", "%") + TempTxt + """" + vbCrLf
            Else
                mystr = global_path + "\global -c | " + global_path + "\grep " + strcase + args._search + " > ""#MYCD#\".Replace("#", "%") + TempTxt + """" + vbCrLf
            End If
        ElseIf args._opt = "-csh" Then
            mystr = global_path + "\global -cs | " + global_path + "\grep " + args._search + " > ""#MYCD#\".Replace("#", "%") + TempTxt + """" + vbCrLf
        Else
            mystr = global_path + "\global " + strcase + args._opt + " " + args._search + " > ""#MYCD#\".Replace("#", "%") + TempTxt + """" + vbCrLf

        End If

            objWriter.Write(mystr)
            objWriter.Close()

            REM MsgBox(Environment.CurrentDirectory + "\" + TempExec)

            Try
                With procExecGlobal
                    .StartInfo.FileName = Environment.CurrentDirectory + "\" + TempExec
                    .StartInfo.CreateNoWindow = True
                    .StartInfo.UseShellExecute = True
                .StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    .StartInfo.WorkingDirectory = args._root

                    .Start()

                    While .WaitForExit(500) <> True
                        If bgwExecGlobal.CancellationPending = True Then
                            KillAllChildProcess(.id)
                            If .HasExited = False Then
                                .Kill()
                            End If
                            e.Result = "killed"
                        End If
                    End While

                End With
            Catch ex As Exception
                MsgBox(procExecGlobal.StartInfo.FileName + ": (Exception)" + vbCrLf + ex.Message)
                e.Result = "error:" + ErrorToString()

            End Try

    End Sub


    Private Sub bgwExecGlobal_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwExecGlobal.RunWorkerCompleted

        ''Dim r As System.IO.StreamReader
        Dim strSet() As String
        Dim strTab() As String
        Dim strResult As String
        Dim strLast As New System.Text.StringBuilder()
        Dim iRecordCount As Integer
        Dim flagResultMax As Boolean = False
        Dim tmproot As String

        If lstOption.SelectedIndex = 5 Then
            ''grep
            txtCmd.Text = " grep -r " + cmbSearch.Text.Trim
        Else
            ''global
            If arrOpt(lstOption.SelectedIndex) = "-csh" Then
                txtCmd.Text = " global -cs | grep " + cmbSearch.Text.Trim
            Else
                txtCmd.Text = " global " + arrOpt(lstOption.SelectedIndex) + " " + cmbSearch.Text.Trim
            End If
        End If


        lblStatus.Text = "Populating Results......."
        lblStatus.Refresh()

        If procExecGlobal.HasExited = False Then
            procExecGlobal.kill()
        End If

        If e.Result <> "killed" And e.Result <> "error" Then

            WaitFileInUse(Environment.CurrentDirectory + "\" + TempTxt, 500)
            Dim objReader As New System.IO.StreamReader(Environment.CurrentDirectory + "\" + TempTxt)
            strResult = objReader.ReadToEnd
            objReader.Close()
            objReader.Dispose()
        ElseIf e.Result = "killed" Then
            txtCmd.Text = txtCmd.Text + " !!!Search Stop By User!!!"
            txtCmd.Refresh()
            strResult = ""
            lblStatus.Text = "Canceling Search......."
            lblStatus.Refresh()
            WaitFileInUse(Environment.CurrentDirectory + "\" + TempTxt, 500)
        Else
            strResult = e.Result
        End If


        dgvResult.Rows.Clear()

        If strResult <> "" Then

            strSet = strResult.Split(vbLf)
            iRecordCount = strSet.Length

            If iRecordCount > max_result_count Then
                txtCmd.Text = txtCmd.Text + " [ WARNING!! " + max_result_count.ToString + "/" + _
                    iRecordCount.ToString + " are shown only ] "
                txtCmd.Refresh()
                iRecordCount = max_result_count
                flagResultMax = True

            End If
            Select Case lstOption.SelectedIndex
                Case 0, 5, 6, 7, 8
                    dgvResult.ColumnCount = 1
                    For i = 0 To (iRecordCount - 1)
                        dgvResult.Rows.Add(strSet(i))
                    Next
                    ''Case 5
                    ''    dgvResult.ColumnCount = 2
                    ''   For i = 0 To strSet.GetUpperBound(0)
                    ''strTab = System.Text.RegularExpressions.Regex.Split(strSet(i).Trim, ":")
                    ''dgvResult.Rows.Add(strTab)
                    '' Next
                Case 1, 2, 3, 4
                    dgvResult.ColumnCount = 4
                    For i = 0 To strSet.GetUpperBound(0)
                        strTab = System.Text.RegularExpressions.Regex.Split(strSet(i).Trim, "[\s]+")
                        If strTab.Length >= 4 Then
                            strLast.Clear()
                            For j = 3 To strTab.GetUpperBound(0)
                                strLast.Append(strTab(j) + " ")
                            Next
                            REM MsgBox(InStr(strTab(2), ".."))
                            REM If InStr(strTab(2), "..") = 1 Then
                            REM MsgBox(strTab(2).Replace("..", ""))
                            REM End if
                            If InStr(txtRoot.Text, "\\view") = 1 Then
                                tmproot = txtRoot.Text.Replace("\", "/")
                                strTab(2) = strTab(2).Replace("..", "").Replace(tmproot, "")
                            End If
                            dgvResult.Rows.Add(strTab(0), strTab(1), strTab(2), strLast.ToString())
                        Else
                            dgvResult.Rows.Add(strTab)
                        End If

                    Next
                Case Else
            End Select
        End If

        lblStatus.Visible = False

        If flagResultMax = True Then
            MsgBox("Results Max is exceeded." + vbCrLf + "You may configure $MaxResultCount at the config file", MessageBoxIcon.Warning, "Result Max Exceed")
        End If

    End Sub

    Private Sub cmbBookmark_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBookmark.SelectedIndexChanged

        Dim booknote() As String
        For Each book As String In DicBookmark
            booknote = book.Trim.Split("@")
            If booknote(0) = cmbBookmark.Text Then
                txtRoot.Text = booknote(1)
                txtDbPath.Text = booknote(2)
                Exit For
            End If

        Next
    End Sub


    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click
        Process.Start("Bookmark.ini")
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        ConfigBookmark("Bookmark.ini")
    End Sub

    Private Sub cmbSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSearch.KeyDown
        If e.KeyCode = Keys.Return Then
            butSearch_Click(sender, e)
        End If
    End Sub

    Private Sub cmdConsole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConsole.Click
        ExecConsole()
    End Sub

    Private Sub dgvResult_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvResult.CellContentClick

    End Sub
End Class

Public Class ExecGlobalParam_Type
    Public _opt As String
    Public _search As String
    Public _root As String
    Public _dbpath As String
End Class

