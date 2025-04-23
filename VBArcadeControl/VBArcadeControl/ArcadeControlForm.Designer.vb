<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ArcadeControlForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.SerialStatusStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.COMPortComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ConnectDisconnectStatusStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ConfigurationStatusStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.COMPortTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetTopMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileTopMenuSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartStopGameButton = New System.Windows.Forms.Button()
        Me.TargetEnableTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.CountdownLabel = New System.Windows.Forms.Label()
        Me.PlayerOneLabel = New System.Windows.Forms.Label()
        Me.PlayerTwoLabel = New System.Windows.Forms.Label()
        Me.PlayerTwoScoreLabel = New System.Windows.Forms.Label()
        Me.PlayerOneScoreLabel = New System.Windows.Forms.Label()
        Me.ScoreUpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip.SuspendLayout()
        Me.TopMenuStrip.SuspendLayout()
        Me.TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SerialStatusStripSplitButton, Me.SerialStatusLabel, Me.ConfigurationStatusStripLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip.TabIndex = 0
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'SerialStatusStripSplitButton
        '
        Me.SerialStatusStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SerialStatusStripSplitButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.COMPortComboBox, Me.ConnectDisconnectStatusStripMenuItem})
        Me.SerialStatusStripSplitButton.Image = Global.VBArcadeControl.My.Resources.Resources.serial_port
        Me.SerialStatusStripSplitButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SerialStatusStripSplitButton.Name = "SerialStatusStripSplitButton"
        Me.SerialStatusStripSplitButton.Size = New System.Drawing.Size(32, 20)
        Me.SerialStatusStripSplitButton.Text = "ToolStripSplitButton1"
        '
        'COMPortComboBox
        '
        Me.COMPortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.COMPortComboBox.Name = "COMPortComboBox"
        Me.COMPortComboBox.Size = New System.Drawing.Size(121, 23)
        '
        'ConnectDisconnectStatusStripMenuItem
        '
        Me.ConnectDisconnectStatusStripMenuItem.Name = "ConnectDisconnectStatusStripMenuItem"
        Me.ConnectDisconnectStatusStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ConnectDisconnectStatusStripMenuItem.Text = "Connect"
        '
        'SerialStatusLabel
        '
        Me.SerialStatusLabel.Name = "SerialStatusLabel"
        Me.SerialStatusLabel.Size = New System.Drawing.Size(631, 17)
        Me.SerialStatusLabel.Spring = True
        Me.SerialStatusLabel.Text = "Disconnected from COM_"
        Me.SerialStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConfigurationStatusStripLabel
        '
        Me.ConfigurationStatusStripLabel.AutoToolTip = True
        Me.ConfigurationStatusStripLabel.Name = "ConfigurationStatusStripLabel"
        Me.ConfigurationStatusStripLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ConfigurationStatusStripLabel.Size = New System.Drawing.Size(122, 17)
        Me.ConfigurationStatusStripLabel.Text = "Default Configuration"
        Me.ConfigurationStatusStripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'COMPortTimer
        '
        Me.COMPortTimer.Interval = 8000
        '
        'TopMenuStrip
        '
        Me.TopMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.TopMenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.TopMenuStrip.Name = "TopMenuStrip"
        Me.TopMenuStrip.Size = New System.Drawing.Size(800, 24)
        Me.TopMenuStrip.TabIndex = 1
        Me.TopMenuStrip.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationToolStripMenuItem, Me.ResetTopMenuItem, Me.FileTopMenuSeparator, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.ConfigurationToolStripMenuItem.Text = "&Change Configuration"
        '
        'ResetTopMenuItem
        '
        Me.ResetTopMenuItem.Name = "ResetTopMenuItem"
        Me.ResetTopMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.ResetTopMenuItem.Text = "&Reset to Default Configuration"
        '
        'FileTopMenuSeparator
        '
        Me.FileTopMenuSeparator.Name = "FileTopMenuSeparator"
        Me.FileTopMenuSeparator.Size = New System.Drawing.Size(231, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(234, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'StartStopGameButton
        '
        Me.StartStopGameButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.StartStopGameButton.Location = New System.Drawing.Point(269, 320)
        Me.StartStopGameButton.Name = "StartStopGameButton"
        Me.StartStopGameButton.Padding = New System.Windows.Forms.Padding(20)
        Me.StartStopGameButton.Size = New System.Drawing.Size(260, 75)
        Me.StartStopGameButton.TabIndex = 2
        Me.StartStopGameButton.Text = "Start Game"
        Me.StartStopGameButton.UseVisualStyleBackColor = True
        '
        'TargetEnableTimer
        '
        Me.TargetEnableTimer.Interval = 500
        '
        'GameTimer
        '
        Me.GameTimer.Interval = 1000
        '
        'TitleLabel
        '
        Me.TitleLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(269, 0)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(260, 59)
        Me.TitleLabel.TabIndex = 3
        Me.TitleLabel.Text = "Laser Arcade"
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel.ColumnCount = 3
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33112!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33445!))
        Me.TableLayoutPanel.Controls.Add(Me.TitleLabel, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.CountdownLabel, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.PlayerOneLabel, 0, 1)
        Me.TableLayoutPanel.Controls.Add(Me.PlayerTwoLabel, 2, 1)
        Me.TableLayoutPanel.Controls.Add(Me.StartStopGameButton, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.PlayerTwoScoreLabel, 2, 2)
        Me.TableLayoutPanel.Controls.Add(Me.PlayerOneScoreLabel, 0, 2)
        Me.TableLayoutPanel.Location = New System.Drawing.Point(0, 27)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 4
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(800, 398)
        Me.TableLayoutPanel.TabIndex = 4
        '
        'CountdownLabel
        '
        Me.CountdownLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CountdownLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountdownLabel.Location = New System.Drawing.Point(269, 59)
        Me.CountdownLabel.Name = "CountdownLabel"
        Me.CountdownLabel.Size = New System.Drawing.Size(260, 159)
        Me.CountdownLabel.TabIndex = 4
        Me.CountdownLabel.Text = "0:00"
        Me.CountdownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlayerOneLabel
        '
        Me.PlayerOneLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayerOneLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerOneLabel.Location = New System.Drawing.Point(3, 59)
        Me.PlayerOneLabel.Name = "PlayerOneLabel"
        Me.PlayerOneLabel.Size = New System.Drawing.Size(260, 159)
        Me.PlayerOneLabel.TabIndex = 5
        Me.PlayerOneLabel.Text = "Player One"
        Me.PlayerOneLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PlayerTwoLabel
        '
        Me.PlayerTwoLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayerTwoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerTwoLabel.Location = New System.Drawing.Point(535, 59)
        Me.PlayerTwoLabel.Name = "PlayerTwoLabel"
        Me.PlayerTwoLabel.Size = New System.Drawing.Size(262, 159)
        Me.PlayerTwoLabel.TabIndex = 6
        Me.PlayerTwoLabel.Text = "Player Two"
        Me.PlayerTwoLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'PlayerTwoScoreLabel
        '
        Me.PlayerTwoScoreLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayerTwoScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerTwoScoreLabel.Location = New System.Drawing.Point(535, 218)
        Me.PlayerTwoScoreLabel.Name = "PlayerTwoScoreLabel"
        Me.PlayerTwoScoreLabel.Size = New System.Drawing.Size(262, 99)
        Me.PlayerTwoScoreLabel.TabIndex = 7
        Me.PlayerTwoScoreLabel.Text = "0"
        Me.PlayerTwoScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PlayerOneScoreLabel
        '
        Me.PlayerOneScoreLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayerOneScoreLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerOneScoreLabel.Location = New System.Drawing.Point(3, 218)
        Me.PlayerOneScoreLabel.Name = "PlayerOneScoreLabel"
        Me.PlayerOneScoreLabel.Size = New System.Drawing.Size(260, 99)
        Me.PlayerOneScoreLabel.TabIndex = 8
        Me.PlayerOneScoreLabel.Text = "0"
        Me.PlayerOneScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ScoreUpdateTimer
        '
        '
        'ArcadeControlForm
        '
        Me.AcceptButton = Me.StartStopGameButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.TopMenuStrip)
        Me.MainMenuStrip = Me.TopMenuStrip
        Me.Name = "ArcadeControlForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RCET Laser Arcade"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.TopMenuStrip.ResumeLayout(False)
        Me.TopMenuStrip.PerformLayout()
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents SerialStatusStripSplitButton As ToolStripSplitButton
    Friend WithEvents COMPortComboBox As ToolStripComboBox
    Friend WithEvents SerialStatusLabel As ToolStripStatusLabel
    Friend WithEvents COMPortTimer As Timer
    Friend WithEvents ConnectDisconnectStatusStripMenuItem As ToolStripMenuItem
    Friend WithEvents TopMenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartStopGameButton As Button
    Friend WithEvents TargetEnableTimer As Timer
    Friend WithEvents GameTimer As Timer
    Friend WithEvents ConfigurationStatusStripLabel As ToolStripStatusLabel
    Friend WithEvents ResetTopMenuItem As ToolStripMenuItem
    Friend WithEvents FileTopMenuSeparator As ToolStripSeparator
    Friend WithEvents TitleLabel As Label
    Friend WithEvents TableLayoutPanel As TableLayoutPanel
    Friend WithEvents CountdownLabel As Label
    Friend WithEvents PlayerOneLabel As Label
    Friend WithEvents PlayerTwoLabel As Label
    Friend WithEvents PlayerTwoScoreLabel As Label
    Friend WithEvents PlayerOneScoreLabel As Label
    Friend WithEvents ScoreUpdateTimer As Timer
End Class
