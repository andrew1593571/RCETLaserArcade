<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArcadeControlForm
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
        Me.components = New System.ComponentModel.Container()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.SerialStatusStripSplitButton = New System.Windows.Forms.ToolStripSplitButton()
        Me.COMPortComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ConnectDisconnectStatusStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.COMPortTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TopMenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartGameButton = New System.Windows.Forms.Button()
        Me.TargetEnableTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip.SuspendLayout()
        Me.TopMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SerialStatusStripSplitButton, Me.SerialStatusLabel})
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
        Me.SerialStatusLabel.Size = New System.Drawing.Size(144, 17)
        Me.SerialStatusLabel.Text = "Disconnected from COM_"
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewGameToolStripMenuItem, Me.ConfigurationToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewGameToolStripMenuItem
        '
        Me.NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        Me.NewGameToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.NewGameToolStripMenuItem.Text = "&New Game"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.ConfigurationToolStripMenuItem.Text = "&Configuration"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
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
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'StartGameButton
        '
        Me.StartGameButton.Location = New System.Drawing.Point(424, 215)
        Me.StartGameButton.Name = "StartGameButton"
        Me.StartGameButton.Size = New System.Drawing.Size(75, 23)
        Me.StartGameButton.TabIndex = 2
        Me.StartGameButton.Text = "Start Game"
        Me.StartGameButton.UseVisualStyleBackColor = True
        '
        'TargetEnableTimer
        '
        Me.TargetEnableTimer.Interval = 500
        '
        'GameTimer
        '
        Me.GameTimer.Interval = 90000
        '
        'ArcadeControlForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.StartGameButton)
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
    Friend WithEvents NewGameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StartGameButton As Button
    Friend WithEvents TargetEnableTimer As Timer
    Friend WithEvents GameTimer As Timer
End Class
