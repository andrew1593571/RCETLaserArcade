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
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.StatusStrip.SuspendLayout()
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
        'ArcadeControlForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.StatusStrip)
        Me.Name = "ArcadeControlForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RCET Laser Arcade"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents SerialStatusStripSplitButton As ToolStripSplitButton
    Friend WithEvents COMPortComboBox As ToolStripComboBox
    Friend WithEvents SerialStatusLabel As ToolStripStatusLabel
    Friend WithEvents COMPortTimer As Timer
    Friend WithEvents ConnectDisconnectStatusStripMenuItem As ToolStripMenuItem
    Friend WithEvents SerialPort As IO.Ports.SerialPort
End Class
