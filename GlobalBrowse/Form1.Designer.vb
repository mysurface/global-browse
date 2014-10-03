<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.dgvResult = New System.Windows.Forms.DataGridView()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdOpen = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBookmark = New System.Windows.Forms.ComboBox()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.bgwExecGlobal = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkIgnoreCase = New System.Windows.Forms.CheckBox()
        Me.butSearch = New System.Windows.Forms.Button()
        Me.cmbSearch = New System.Windows.Forms.ComboBox()
        Me.lstOption = New System.Windows.Forms.ListBox()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCmd = New System.Windows.Forms.TextBox()
        Me.txtRoot = New System.Windows.Forms.TextBox()
        Me.butDbpath = New System.Windows.Forms.Button()
        Me.txtDbPath = New System.Windows.Forms.TextBox()
        Me.butRoot = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmdConsole = New System.Windows.Forms.Button()
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(328, 151)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(165, 24)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "This is the status"
        Me.lblStatus.Visible = False
        '
        'dgvResult
        '
        Me.dgvResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResult.Location = New System.Drawing.Point(-7, 3)
        Me.dgvResult.Name = "dgvResult"
        Me.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResult.Size = New System.Drawing.Size(813, 324)
        Me.dgvResult.TabIndex = 0
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(299, 1)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdate.TabIndex = 3
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdOpen
        '
        Me.cmdOpen.Location = New System.Drawing.Point(218, 1)
        Me.cmdOpen.Name = "cmdOpen"
        Me.cmdOpen.Size = New System.Drawing.Size(75, 23)
        Me.cmdOpen.TabIndex = 2
        Me.cmdOpen.Text = "Open"
        Me.cmdOpen.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Bookmark:"
        '
        'cmbBookmark
        '
        Me.cmbBookmark.FormattingEnabled = True
        Me.cmbBookmark.Location = New System.Drawing.Point(67, 1)
        Me.cmbBookmark.Name = "cmbBookmark"
        Me.cmbBookmark.Size = New System.Drawing.Size(145, 21)
        Me.cmbBookmark.TabIndex = 0
        '
        'bgwExecGlobal
        '
        Me.bgwExecGlobal.WorkerSupportsCancellation = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.chkIgnoreCase)
        Me.Panel1.Controls.Add(Me.butSearch)
        Me.Panel1.Controls.Add(Me.cmbSearch)
        Me.Panel1.Controls.Add(Me.lstOption)
        Me.Panel1.Controls.Add(Me.cmdStop)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmdClear)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtCmd)
        Me.Panel1.Controls.Add(Me.txtRoot)
        Me.Panel1.Controls.Add(Me.butDbpath)
        Me.Panel1.Controls.Add(Me.txtDbPath)
        Me.Panel1.Controls.Add(Me.butRoot)
        Me.Panel1.Location = New System.Drawing.Point(5, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(813, 163)
        Me.Panel1.TabIndex = 1
        '
        'chkIgnoreCase
        '
        Me.chkIgnoreCase.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkIgnoreCase.AutoSize = True
        Me.chkIgnoreCase.Location = New System.Drawing.Point(218, 39)
        Me.chkIgnoreCase.Name = "chkIgnoreCase"
        Me.chkIgnoreCase.Size = New System.Drawing.Size(83, 17)
        Me.chkIgnoreCase.TabIndex = 15
        Me.chkIgnoreCase.Text = "Ignore Case"
        Me.chkIgnoreCase.UseVisualStyleBackColor = True
        '
        'butSearch
        '
        Me.butSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butSearch.Location = New System.Drawing.Point(726, 12)
        Me.butSearch.Name = "butSearch"
        Me.butSearch.Size = New System.Drawing.Size(75, 23)
        Me.butSearch.TabIndex = 3
        Me.butSearch.Text = "Search"
        Me.butSearch.UseVisualStyleBackColor = True
        '
        'cmbSearch
        '
        Me.cmbSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSearch.FormattingEnabled = True
        Me.cmbSearch.Location = New System.Drawing.Point(218, 12)
        Me.cmbSearch.Name = "cmbSearch"
        Me.cmbSearch.Size = New System.Drawing.Size(502, 21)
        Me.cmbSearch.TabIndex = 14
        '
        'lstOption
        '
        Me.lstOption.FormattingEnabled = True
        Me.lstOption.Items.AddRange(New Object() {"Keyword", "Definition", "Reference", "Symbol", "Grep", "Filename", "HotKey", "HotSymbol", "PrefixSymbol"})
        Me.lstOption.Location = New System.Drawing.Point(6, 12)
        Me.lstOption.Name = "lstOption"
        Me.lstOption.Size = New System.Drawing.Size(91, 134)
        Me.lstOption.TabIndex = 0
        '
        'cmdStop
        '
        Me.cmdStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdStop.Location = New System.Drawing.Point(726, 127)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(75, 23)
        Me.cmdStop.TabIndex = 13
        Me.cmdStop.Text = "STOP"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(153, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "SEARCH:"
        '
        'cmdClear
        '
        Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClear.Location = New System.Drawing.Point(758, 69)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(43, 50)
        Me.cmdClear.TabIndex = 12
        Me.cmdClear.Text = "Clear"
        Me.cmdClear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(129, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "GTAGSROOT:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(173, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "CMD:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(116, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "GTAGSDBPATH:"
        '
        'txtCmd
        '
        Me.txtCmd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCmd.BackColor = System.Drawing.SystemColors.MenuText
        Me.txtCmd.ForeColor = System.Drawing.Color.Chartreuse
        Me.txtCmd.Location = New System.Drawing.Point(213, 128)
        Me.txtCmd.Name = "txtCmd"
        Me.txtCmd.Size = New System.Drawing.Size(507, 20)
        Me.txtCmd.TabIndex = 10
        '
        'txtRoot
        '
        Me.txtRoot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRoot.Location = New System.Drawing.Point(213, 69)
        Me.txtRoot.Name = "txtRoot"
        Me.txtRoot.Size = New System.Drawing.Size(507, 20)
        Me.txtRoot.TabIndex = 6
        '
        'butDbpath
        '
        Me.butDbpath.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butDbpath.Location = New System.Drawing.Point(726, 98)
        Me.butDbpath.Name = "butDbpath"
        Me.butDbpath.Size = New System.Drawing.Size(26, 23)
        Me.butDbpath.TabIndex = 9
        Me.butDbpath.Text = "..."
        Me.butDbpath.UseVisualStyleBackColor = True
        '
        'txtDbPath
        '
        Me.txtDbPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDbPath.Location = New System.Drawing.Point(213, 97)
        Me.txtDbPath.Name = "txtDbPath"
        Me.txtDbPath.Size = New System.Drawing.Size(507, 20)
        Me.txtDbPath.TabIndex = 7
        '
        'butRoot
        '
        Me.butRoot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butRoot.Location = New System.Drawing.Point(726, 69)
        Me.butRoot.Name = "butRoot"
        Me.butRoot.Size = New System.Drawing.Size(26, 23)
        Me.butRoot.TabIndex = 8
        Me.butRoot.Text = "..."
        Me.butRoot.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblStatus)
        Me.Panel2.Controls.Add(Me.dgvResult)
        Me.Panel2.Location = New System.Drawing.Point(12, 169)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(806, 319)
        Me.Panel2.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.cmdConsole)
        Me.Panel3.Controls.Add(Me.cmdUpdate)
        Me.Panel3.Controls.Add(Me.cmdOpen)
        Me.Panel3.Controls.Add(Me.cmbBookmark)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(5, 495)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(813, 35)
        Me.Panel3.TabIndex = 3
        '
        'cmdConsole
        '
        Me.cmdConsole.Location = New System.Drawing.Point(735, 1)
        Me.cmdConsole.Name = "cmdConsole"
        Me.cmdConsole.Size = New System.Drawing.Size(75, 23)
        Me.cmdConsole.TabIndex = 4
        Me.cmdConsole.Text = "Console"
        Me.cmdConsole.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 534)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Surface Global Browse Version 2.0.2"
        CType(Me.dgvResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvResult As System.Windows.Forms.DataGridView
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents bgwExecGlobal As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmbBookmark As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents chkIgnoreCase As System.Windows.Forms.CheckBox
    Friend WithEvents cmbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCmd As System.Windows.Forms.TextBox
    Friend WithEvents butDbpath As System.Windows.Forms.Button
    Friend WithEvents butRoot As System.Windows.Forms.Button
    Friend WithEvents txtDbPath As System.Windows.Forms.TextBox
    Friend WithEvents txtRoot As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents butSearch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstOption As System.Windows.Forms.ListBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdConsole As System.Windows.Forms.Button

End Class
