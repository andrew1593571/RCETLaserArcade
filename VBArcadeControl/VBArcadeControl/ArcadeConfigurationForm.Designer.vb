<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArcadeConfigurationForm
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
        Me.GameTimeGroupBox = New System.Windows.Forms.GroupBox()
        Me.GameTimeSecondsLabel = New System.Windows.Forms.Label()
        Me.GameTimeTextBox = New System.Windows.Forms.TextBox()
        Me.TargetEnableGroupBox = New System.Windows.Forms.GroupBox()
        Me.TargetEnableSecondsLabel = New System.Windows.Forms.Label()
        Me.TargetEnableTextBox = New System.Windows.Forms.TextBox()
        Me.TargetModeGroupBox = New System.Windows.Forms.GroupBox()
        Me.TargetRemainEnabledRadioButton = New System.Windows.Forms.RadioButton()
        Me.TargetAutoDisableRadioButton = New System.Windows.Forms.RadioButton()
        Me.AutoDisableGroupBox = New System.Windows.Forms.GroupBox()
        Me.AutoDisableMaximumLabel = New System.Windows.Forms.Label()
        Me.AutoDisableMaxSecondsLabel = New System.Windows.Forms.Label()
        Me.AutoDisableMaximumTextBox = New System.Windows.Forms.TextBox()
        Me.AutoDisableMinimumLabel = New System.Windows.Forms.Label()
        Me.AutoDisableMinSecondsLabel = New System.Windows.Forms.Label()
        Me.AutoDisableMinimumTextBox = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.OpenButton = New System.Windows.Forms.Button()
        Me.PointsGroupBox = New System.Windows.Forms.GroupBox()
        Me.ValueTextBox = New System.Windows.Forms.TextBox()
        Me.ValueLabel = New System.Windows.Forms.Label()
        Me.AddressTextBox = New System.Windows.Forms.TextBox()
        Me.AddressLabel = New System.Windows.Forms.Label()
        Me.AddPointsButton = New System.Windows.Forms.Button()
        Me.RemovePointsButton = New System.Windows.Forms.Button()
        Me.PointsListBox = New System.Windows.Forms.ListBox()
        Me.TargetPointsLabel = New System.Windows.Forms.Label()
        Me.TargetsGroupBox = New System.Windows.Forms.GroupBox()
        Me.TargetNumberLabel = New System.Windows.Forms.Label()
        Me.TargetNumberTextBox = New System.Windows.Forms.TextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GameTimeGroupBox.SuspendLayout()
        Me.TargetEnableGroupBox.SuspendLayout()
        Me.TargetModeGroupBox.SuspendLayout()
        Me.AutoDisableGroupBox.SuspendLayout()
        Me.PointsGroupBox.SuspendLayout()
        Me.TargetsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GameTimeGroupBox
        '
        Me.GameTimeGroupBox.Controls.Add(Me.GameTimeSecondsLabel)
        Me.GameTimeGroupBox.Controls.Add(Me.GameTimeTextBox)
        Me.GameTimeGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.GameTimeGroupBox.Name = "GameTimeGroupBox"
        Me.GameTimeGroupBox.Size = New System.Drawing.Size(180, 52)
        Me.GameTimeGroupBox.TabIndex = 0
        Me.GameTimeGroupBox.TabStop = False
        Me.GameTimeGroupBox.Text = "Game Time"
        Me.ToolTip.SetToolTip(Me.GameTimeGroupBox, "Length of game in seconds")
        '
        'GameTimeSecondsLabel
        '
        Me.GameTimeSecondsLabel.AutoSize = True
        Me.GameTimeSecondsLabel.Location = New System.Drawing.Point(112, 22)
        Me.GameTimeSecondsLabel.Name = "GameTimeSecondsLabel"
        Me.GameTimeSecondsLabel.Size = New System.Drawing.Size(49, 13)
        Me.GameTimeSecondsLabel.TabIndex = 2
        Me.GameTimeSecondsLabel.Text = "Seconds"
        Me.ToolTip.SetToolTip(Me.GameTimeSecondsLabel, "Length of game in seconds")
        '
        'GameTimeTextBox
        '
        Me.GameTimeTextBox.Location = New System.Drawing.Point(6, 19)
        Me.GameTimeTextBox.Name = "GameTimeTextBox"
        Me.GameTimeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.GameTimeTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.GameTimeTextBox, "Length of game in seconds")
        '
        'TargetEnableGroupBox
        '
        Me.TargetEnableGroupBox.Controls.Add(Me.TargetEnableSecondsLabel)
        Me.TargetEnableGroupBox.Controls.Add(Me.TargetEnableTextBox)
        Me.TargetEnableGroupBox.Location = New System.Drawing.Point(12, 128)
        Me.TargetEnableGroupBox.Name = "TargetEnableGroupBox"
        Me.TargetEnableGroupBox.Size = New System.Drawing.Size(180, 52)
        Me.TargetEnableGroupBox.TabIndex = 1
        Me.TargetEnableGroupBox.TabStop = False
        Me.TargetEnableGroupBox.Text = "Target Enabled Every"
        Me.ToolTip.SetToolTip(Me.TargetEnableGroupBox, "A new target will be enabled every X milliseconds (Maximum of 8 targets at a time" &
        ").")
        '
        'TargetEnableSecondsLabel
        '
        Me.TargetEnableSecondsLabel.AutoSize = True
        Me.TargetEnableSecondsLabel.Location = New System.Drawing.Point(112, 22)
        Me.TargetEnableSecondsLabel.Name = "TargetEnableSecondsLabel"
        Me.TargetEnableSecondsLabel.Size = New System.Drawing.Size(64, 13)
        Me.TargetEnableSecondsLabel.TabIndex = 2
        Me.TargetEnableSecondsLabel.Text = "Milliseconds"
        Me.ToolTip.SetToolTip(Me.TargetEnableSecondsLabel, "A new target will be enabled every X milliseconds (Maximum of 8 targets at a time" &
        ").")
        '
        'TargetEnableTextBox
        '
        Me.TargetEnableTextBox.Location = New System.Drawing.Point(6, 19)
        Me.TargetEnableTextBox.Name = "TargetEnableTextBox"
        Me.TargetEnableTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TargetEnableTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.TargetEnableTextBox, "A new target will be enabled every X milliseconds (Maximum of 8 targets at a time" &
        ").")
        '
        'TargetModeGroupBox
        '
        Me.TargetModeGroupBox.Controls.Add(Me.TargetRemainEnabledRadioButton)
        Me.TargetModeGroupBox.Controls.Add(Me.TargetAutoDisableRadioButton)
        Me.TargetModeGroupBox.Location = New System.Drawing.Point(12, 186)
        Me.TargetModeGroupBox.Name = "TargetModeGroupBox"
        Me.TargetModeGroupBox.Size = New System.Drawing.Size(180, 69)
        Me.TargetModeGroupBox.TabIndex = 2
        Me.TargetModeGroupBox.TabStop = False
        Me.TargetModeGroupBox.Text = "Target Mode"
        '
        'TargetRemainEnabledRadioButton
        '
        Me.TargetRemainEnabledRadioButton.AutoSize = True
        Me.TargetRemainEnabledRadioButton.Location = New System.Drawing.Point(6, 42)
        Me.TargetRemainEnabledRadioButton.Name = "TargetRemainEnabledRadioButton"
        Me.TargetRemainEnabledRadioButton.Size = New System.Drawing.Size(143, 17)
        Me.TargetRemainEnabledRadioButton.TabIndex = 4
        Me.TargetRemainEnabledRadioButton.TabStop = True
        Me.TargetRemainEnabledRadioButton.Text = "Remain Enabled Until Hit"
        Me.ToolTip.SetToolTip(Me.TargetRemainEnabledRadioButton, "Targets will remain enabled until hit by a player.")
        Me.TargetRemainEnabledRadioButton.UseVisualStyleBackColor = True
        '
        'TargetAutoDisableRadioButton
        '
        Me.TargetAutoDisableRadioButton.AutoSize = True
        Me.TargetAutoDisableRadioButton.Checked = True
        Me.TargetAutoDisableRadioButton.Location = New System.Drawing.Point(6, 19)
        Me.TargetAutoDisableRadioButton.Name = "TargetAutoDisableRadioButton"
        Me.TargetAutoDisableRadioButton.Size = New System.Drawing.Size(125, 17)
        Me.TargetAutoDisableRadioButton.TabIndex = 3
        Me.TargetAutoDisableRadioButton.TabStop = True
        Me.TargetAutoDisableRadioButton.Text = "Automatically Disable"
        Me.ToolTip.SetToolTip(Me.TargetAutoDisableRadioButton, "Targets will disable at a random time interval between the minimum and maximum")
        Me.TargetAutoDisableRadioButton.UseVisualStyleBackColor = True
        '
        'AutoDisableGroupBox
        '
        Me.AutoDisableGroupBox.Controls.Add(Me.AutoDisableMaximumLabel)
        Me.AutoDisableGroupBox.Controls.Add(Me.AutoDisableMaxSecondsLabel)
        Me.AutoDisableGroupBox.Controls.Add(Me.AutoDisableMaximumTextBox)
        Me.AutoDisableGroupBox.Controls.Add(Me.AutoDisableMinimumLabel)
        Me.AutoDisableGroupBox.Controls.Add(Me.AutoDisableMinSecondsLabel)
        Me.AutoDisableGroupBox.Controls.Add(Me.AutoDisableMinimumTextBox)
        Me.AutoDisableGroupBox.Location = New System.Drawing.Point(12, 261)
        Me.AutoDisableGroupBox.Name = "AutoDisableGroupBox"
        Me.AutoDisableGroupBox.Size = New System.Drawing.Size(180, 100)
        Me.AutoDisableGroupBox.TabIndex = 3
        Me.AutoDisableGroupBox.TabStop = False
        Me.AutoDisableGroupBox.Text = "Automatic Target Disable Time"
        '
        'AutoDisableMaximumLabel
        '
        Me.AutoDisableMaximumLabel.AutoSize = True
        Me.AutoDisableMaximumLabel.Location = New System.Drawing.Point(6, 55)
        Me.AutoDisableMaximumLabel.Name = "AutoDisableMaximumLabel"
        Me.AutoDisableMaximumLabel.Size = New System.Drawing.Size(51, 13)
        Me.AutoDisableMaximumLabel.TabIndex = 5
        Me.AutoDisableMaximumLabel.Text = "Maximum"
        '
        'AutoDisableMaxSecondsLabel
        '
        Me.AutoDisableMaxSecondsLabel.AutoSize = True
        Me.AutoDisableMaxSecondsLabel.Location = New System.Drawing.Point(112, 74)
        Me.AutoDisableMaxSecondsLabel.Name = "AutoDisableMaxSecondsLabel"
        Me.AutoDisableMaxSecondsLabel.Size = New System.Drawing.Size(64, 13)
        Me.AutoDisableMaxSecondsLabel.TabIndex = 7
        Me.AutoDisableMaxSecondsLabel.Text = "Milliseconds"
        '
        'AutoDisableMaximumTextBox
        '
        Me.AutoDisableMaximumTextBox.Location = New System.Drawing.Point(6, 71)
        Me.AutoDisableMaximumTextBox.Name = "AutoDisableMaximumTextBox"
        Me.AutoDisableMaximumTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AutoDisableMaximumTextBox.TabIndex = 6
        Me.ToolTip.SetToolTip(Me.AutoDisableMaximumTextBox, "The maximum length of time a target will remain enabled")
        '
        'AutoDisableMinimumLabel
        '
        Me.AutoDisableMinimumLabel.AutoSize = True
        Me.AutoDisableMinimumLabel.Location = New System.Drawing.Point(6, 16)
        Me.AutoDisableMinimumLabel.Name = "AutoDisableMinimumLabel"
        Me.AutoDisableMinimumLabel.Size = New System.Drawing.Size(48, 13)
        Me.AutoDisableMinimumLabel.TabIndex = 3
        Me.AutoDisableMinimumLabel.Text = "Minimum"
        '
        'AutoDisableMinSecondsLabel
        '
        Me.AutoDisableMinSecondsLabel.AutoSize = True
        Me.AutoDisableMinSecondsLabel.Location = New System.Drawing.Point(112, 35)
        Me.AutoDisableMinSecondsLabel.Name = "AutoDisableMinSecondsLabel"
        Me.AutoDisableMinSecondsLabel.Size = New System.Drawing.Size(64, 13)
        Me.AutoDisableMinSecondsLabel.TabIndex = 4
        Me.AutoDisableMinSecondsLabel.Text = "Milliseconds"
        '
        'AutoDisableMinimumTextBox
        '
        Me.AutoDisableMinimumTextBox.Location = New System.Drawing.Point(6, 32)
        Me.AutoDisableMinimumTextBox.Name = "AutoDisableMinimumTextBox"
        Me.AutoDisableMinimumTextBox.Size = New System.Drawing.Size(100, 20)
        Me.AutoDisableMinimumTextBox.TabIndex = 3
        Me.ToolTip.SetToolTip(Me.AutoDisableMinimumTextBox, "The minimum length of time a target will remain enabled")
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        '
        'SaveButton
        '
        Me.SaveButton.Location = New System.Drawing.Point(293, 322)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(85, 39)
        Me.SaveButton.TabIndex = 4
        Me.SaveButton.Text = "&Save to File"
        Me.ToolTip.SetToolTip(Me.SaveButton, "Save the current configuration to file.")
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'OpenButton
        '
        Me.OpenButton.Location = New System.Drawing.Point(198, 322)
        Me.OpenButton.Name = "OpenButton"
        Me.OpenButton.Size = New System.Drawing.Size(85, 39)
        Me.OpenButton.TabIndex = 5
        Me.OpenButton.Text = "&Open File"
        Me.ToolTip.SetToolTip(Me.OpenButton, "Open a configuration from file")
        Me.OpenButton.UseVisualStyleBackColor = True
        '
        'PointsGroupBox
        '
        Me.PointsGroupBox.Controls.Add(Me.ValueTextBox)
        Me.PointsGroupBox.Controls.Add(Me.ValueLabel)
        Me.PointsGroupBox.Controls.Add(Me.AddressTextBox)
        Me.PointsGroupBox.Controls.Add(Me.AddressLabel)
        Me.PointsGroupBox.Controls.Add(Me.AddPointsButton)
        Me.PointsGroupBox.Controls.Add(Me.RemovePointsButton)
        Me.PointsGroupBox.Controls.Add(Me.PointsListBox)
        Me.PointsGroupBox.Controls.Add(Me.TargetPointsLabel)
        Me.PointsGroupBox.Location = New System.Drawing.Point(198, 12)
        Me.PointsGroupBox.Name = "PointsGroupBox"
        Me.PointsGroupBox.Size = New System.Drawing.Size(180, 304)
        Me.PointsGroupBox.TabIndex = 6
        Me.PointsGroupBox.TabStop = False
        Me.PointsGroupBox.Text = "Target Points"
        '
        'ValueTextBox
        '
        Me.ValueTextBox.Location = New System.Drawing.Point(94, 275)
        Me.ValueTextBox.Name = "ValueTextBox"
        Me.ValueTextBox.Size = New System.Drawing.Size(80, 20)
        Me.ValueTextBox.TabIndex = 11
        Me.ToolTip.SetToolTip(Me.ValueTextBox, "Number of points to associate with entered address")
        '
        'ValueLabel
        '
        Me.ValueLabel.AutoSize = True
        Me.ValueLabel.Location = New System.Drawing.Point(94, 259)
        Me.ValueLabel.Name = "ValueLabel"
        Me.ValueLabel.Size = New System.Drawing.Size(61, 13)
        Me.ValueLabel.TabIndex = 10
        Me.ValueLabel.Text = "Point Value"
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Location = New System.Drawing.Point(6, 275)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(80, 20)
        Me.AddressTextBox.TabIndex = 9
        Me.ToolTip.SetToolTip(Me.AddressTextBox, "7-bit I2C Address of points override. Include 8th bit as 0.")
        '
        'AddressLabel
        '
        Me.AddressLabel.AutoSize = True
        Me.AddressLabel.Location = New System.Drawing.Point(6, 259)
        Me.AddressLabel.Name = "AddressLabel"
        Me.AddressLabel.Size = New System.Drawing.Size(64, 13)
        Me.AddressLabel.TabIndex = 8
        Me.AddressLabel.Text = "I2C Address"
        '
        'AddPointsButton
        '
        Me.AddPointsButton.Location = New System.Drawing.Point(6, 217)
        Me.AddPointsButton.Name = "AddPointsButton"
        Me.AddPointsButton.Size = New System.Drawing.Size(80, 39)
        Me.AddPointsButton.TabIndex = 7
        Me.AddPointsButton.Text = "Add Below"
        Me.ToolTip.SetToolTip(Me.AddPointsButton, "Adds the below point override")
        Me.AddPointsButton.UseVisualStyleBackColor = True
        '
        'RemovePointsButton
        '
        Me.RemovePointsButton.Location = New System.Drawing.Point(94, 217)
        Me.RemovePointsButton.Name = "RemovePointsButton"
        Me.RemovePointsButton.Size = New System.Drawing.Size(80, 39)
        Me.RemovePointsButton.TabIndex = 7
        Me.RemovePointsButton.Text = "Remove Selected"
        Me.ToolTip.SetToolTip(Me.RemovePointsButton, "Removes the above selected point override")
        Me.RemovePointsButton.UseVisualStyleBackColor = True
        '
        'PointsListBox
        '
        Me.PointsListBox.FormattingEnabled = True
        Me.PointsListBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PointsListBox.Location = New System.Drawing.Point(6, 51)
        Me.PointsListBox.Name = "PointsListBox"
        Me.PointsListBox.Size = New System.Drawing.Size(168, 160)
        Me.PointsListBox.TabIndex = 7
        Me.ToolTip.SetToolTip(Me.PointsListBox, "All current point overrides")
        '
        'TargetPointsLabel
        '
        Me.TargetPointsLabel.Location = New System.Drawing.Point(6, 16)
        Me.TargetPointsLabel.Name = "TargetPointsLabel"
        Me.TargetPointsLabel.Size = New System.Drawing.Size(168, 32)
        Me.TargetPointsLabel.TabIndex = 4
        Me.TargetPointsLabel.Text = "Unless listed below, all targets are worth 1 point."
        Me.TargetPointsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TargetsGroupBox
        '
        Me.TargetsGroupBox.Controls.Add(Me.TargetNumberLabel)
        Me.TargetsGroupBox.Controls.Add(Me.TargetNumberTextBox)
        Me.TargetsGroupBox.Location = New System.Drawing.Point(12, 70)
        Me.TargetsGroupBox.Name = "TargetsGroupBox"
        Me.TargetsGroupBox.Size = New System.Drawing.Size(180, 52)
        Me.TargetsGroupBox.TabIndex = 7
        Me.TargetsGroupBox.TabStop = False
        Me.TargetsGroupBox.Text = "Number of Targets"
        Me.ToolTip.SetToolTip(Me.TargetsGroupBox, "Number of total targets. Minimum is 1. Maximum is 127.")
        '
        'TargetNumberLabel
        '
        Me.TargetNumberLabel.AutoSize = True
        Me.TargetNumberLabel.Location = New System.Drawing.Point(112, 22)
        Me.TargetNumberLabel.Name = "TargetNumberLabel"
        Me.TargetNumberLabel.Size = New System.Drawing.Size(43, 13)
        Me.TargetNumberLabel.TabIndex = 2
        Me.TargetNumberLabel.Text = "Targets"
        Me.ToolTip.SetToolTip(Me.TargetNumberLabel, "Number of total targets. Minimum is 1. Maximum is 127.")
        '
        'TargetNumberTextBox
        '
        Me.TargetNumberTextBox.Location = New System.Drawing.Point(6, 19)
        Me.TargetNumberTextBox.Name = "TargetNumberTextBox"
        Me.TargetNumberTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TargetNumberTextBox.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.TargetNumberTextBox, "Number of total targets. Minimum is 1. Maximum is 127.")
        '
        'ArcadeConfigurationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 371)
        Me.Controls.Add(Me.TargetsGroupBox)
        Me.Controls.Add(Me.PointsGroupBox)
        Me.Controls.Add(Me.OpenButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.AutoDisableGroupBox)
        Me.Controls.Add(Me.TargetModeGroupBox)
        Me.Controls.Add(Me.TargetEnableGroupBox)
        Me.Controls.Add(Me.GameTimeGroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ArcadeConfigurationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laser Arcade Configuration"
        Me.GameTimeGroupBox.ResumeLayout(False)
        Me.GameTimeGroupBox.PerformLayout()
        Me.TargetEnableGroupBox.ResumeLayout(False)
        Me.TargetEnableGroupBox.PerformLayout()
        Me.TargetModeGroupBox.ResumeLayout(False)
        Me.TargetModeGroupBox.PerformLayout()
        Me.AutoDisableGroupBox.ResumeLayout(False)
        Me.AutoDisableGroupBox.PerformLayout()
        Me.PointsGroupBox.ResumeLayout(False)
        Me.PointsGroupBox.PerformLayout()
        Me.TargetsGroupBox.ResumeLayout(False)
        Me.TargetsGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GameTimeGroupBox As GroupBox
    Friend WithEvents GameTimeSecondsLabel As Label
    Friend WithEvents GameTimeTextBox As TextBox
    Friend WithEvents TargetEnableGroupBox As GroupBox
    Friend WithEvents TargetEnableSecondsLabel As Label
    Friend WithEvents TargetEnableTextBox As TextBox
    Friend WithEvents TargetModeGroupBox As GroupBox
    Friend WithEvents TargetAutoDisableRadioButton As RadioButton
    Friend WithEvents TargetRemainEnabledRadioButton As RadioButton
    Friend WithEvents AutoDisableGroupBox As GroupBox
    Friend WithEvents AutoDisableMinimumLabel As Label
    Friend WithEvents AutoDisableMinSecondsLabel As Label
    Friend WithEvents AutoDisableMinimumTextBox As TextBox
    Friend WithEvents AutoDisableMaximumLabel As Label
    Friend WithEvents AutoDisableMaxSecondsLabel As Label
    Friend WithEvents AutoDisableMaximumTextBox As TextBox
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents SaveButton As Button
    Friend WithEvents OpenButton As Button
    Friend WithEvents PointsGroupBox As GroupBox
    Friend WithEvents PointsListBox As ListBox
    Friend WithEvents TargetPointsLabel As Label
    Friend WithEvents AddPointsButton As Button
    Friend WithEvents RemovePointsButton As Button
    Friend WithEvents ValueTextBox As TextBox
    Friend WithEvents ValueLabel As Label
    Friend WithEvents AddressTextBox As TextBox
    Friend WithEvents AddressLabel As Label
    Friend WithEvents TargetsGroupBox As GroupBox
    Friend WithEvents TargetNumberLabel As Label
    Friend WithEvents TargetNumberTextBox As TextBox
    Friend WithEvents ToolTip As ToolTip
End Class
