<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestTargetStatus
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
        Me.RecievedTargetData = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReadButton = New System.Windows.Forms.Button()
        Me.AddressTextBox = New System.Windows.Forms.TextBox()
        Me.WriteTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.WriteButton = New System.Windows.Forms.Button()
        Me.DecimalRadioButton = New System.Windows.Forms.RadioButton()
        Me.HexRadioButton = New System.Windows.Forms.RadioButton()
        Me.AsciiRadioButton = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.EnableButton = New System.Windows.Forms.Button()
        Me.DisableButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ResultLabel = New System.Windows.Forms.TextBox()
        Me.ColorChangeButton = New System.Windows.Forms.Button()
        Me.OverwriteButton = New System.Windows.Forms.Button()
        Me.OverwriteTextBox = New System.Windows.Forms.TextBox()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RecievedTargetData
        '
        Me.RecievedTargetData.Location = New System.Drawing.Point(587, 30)
        Me.RecievedTargetData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RecievedTargetData.Name = "RecievedTargetData"
        Me.RecievedTargetData.ReadOnly = True
        Me.RecievedTargetData.Size = New System.Drawing.Size(201, 22)
        Me.RecievedTargetData.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(584, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Raw Data"
        '
        'ReadButton
        '
        Me.ReadButton.Location = New System.Drawing.Point(12, 106)
        Me.ReadButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ReadButton.Name = "ReadButton"
        Me.ReadButton.Size = New System.Drawing.Size(80, 39)
        Me.ReadButton.TabIndex = 2
        Me.ReadButton.Text = "Read"
        Me.ReadButton.UseVisualStyleBackColor = True
        '
        'AddressTextBox
        '
        Me.AddressTextBox.Location = New System.Drawing.Point(12, 30)
        Me.AddressTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AddressTextBox.Name = "AddressTextBox"
        Me.AddressTextBox.Size = New System.Drawing.Size(160, 22)
        Me.AddressTextBox.TabIndex = 3
        Me.AddressTextBox.Text = "1"
        '
        'WriteTextBox
        '
        Me.WriteTextBox.Location = New System.Drawing.Point(12, 78)
        Me.WriteTextBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WriteTextBox.Name = "WriteTextBox"
        Me.WriteTextBox.Size = New System.Drawing.Size(160, 22)
        Me.WriteTextBox.TabIndex = 4
        Me.WriteTextBox.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Write"
        '
        'WriteButton
        '
        Me.WriteButton.Location = New System.Drawing.Point(95, 106)
        Me.WriteButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WriteButton.Name = "WriteButton"
        Me.WriteButton.Size = New System.Drawing.Size(77, 39)
        Me.WriteButton.TabIndex = 7
        Me.WriteButton.Text = "Write"
        Me.WriteButton.UseVisualStyleBackColor = True
        '
        'DecimalRadioButton
        '
        Me.DecimalRadioButton.AutoSize = True
        Me.DecimalRadioButton.Checked = True
        Me.DecimalRadioButton.Location = New System.Drawing.Point(5, 21)
        Me.DecimalRadioButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DecimalRadioButton.Name = "DecimalRadioButton"
        Me.DecimalRadioButton.Size = New System.Drawing.Size(95, 20)
        Me.DecimalRadioButton.TabIndex = 9
        Me.DecimalRadioButton.TabStop = True
        Me.DecimalRadioButton.Text = "JellyBeans"
        Me.DecimalRadioButton.UseVisualStyleBackColor = True
        '
        'HexRadioButton
        '
        Me.HexRadioButton.AutoSize = True
        Me.HexRadioButton.Location = New System.Drawing.Point(5, 47)
        Me.HexRadioButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HexRadioButton.Name = "HexRadioButton"
        Me.HexRadioButton.Size = New System.Drawing.Size(52, 20)
        Me.HexRadioButton.TabIndex = 10
        Me.HexRadioButton.Text = "Hex"
        Me.HexRadioButton.UseVisualStyleBackColor = True
        '
        'AsciiRadioButton
        '
        Me.AsciiRadioButton.AutoSize = True
        Me.AsciiRadioButton.Location = New System.Drawing.Point(5, 73)
        Me.AsciiRadioButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AsciiRadioButton.Name = "AsciiRadioButton"
        Me.AsciiRadioButton.Size = New System.Drawing.Size(57, 20)
        Me.AsciiRadioButton.TabIndex = 11
        Me.AsciiRadioButton.Text = "Ascii"
        Me.AsciiRadioButton.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DecimalRadioButton)
        Me.GroupBox1.Controls.Add(Me.AsciiRadioButton)
        Me.GroupBox1.Controls.Add(Me.HexRadioButton)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 318)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(157, 121)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Base Selector"
        '
        'EnableButton
        '
        Me.EnableButton.Location = New System.Drawing.Point(12, 151)
        Me.EnableButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EnableButton.Name = "EnableButton"
        Me.EnableButton.Size = New System.Drawing.Size(80, 84)
        Me.EnableButton.TabIndex = 13
        Me.EnableButton.Text = "Enable Target"
        Me.EnableButton.UseVisualStyleBackColor = True
        '
        'DisableButton
        '
        Me.DisableButton.Location = New System.Drawing.Point(93, 151)
        Me.DisableButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DisableButton.Name = "DisableButton"
        Me.DisableButton.Size = New System.Drawing.Size(79, 84)
        Me.DisableButton.TabIndex = 14
        Me.DisableButton.Text = "Disable Target"
        Me.DisableButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(583, 106)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Result Label"
        '
        'ResultLabel
        '
        Me.ResultLabel.Location = New System.Drawing.Point(588, 126)
        Me.ResultLabel.Margin = New System.Windows.Forms.Padding(4)
        Me.ResultLabel.Multiline = True
        Me.ResultLabel.Name = "ResultLabel"
        Me.ResultLabel.Size = New System.Drawing.Size(195, 85)
        Me.ResultLabel.TabIndex = 16
        '
        'ColorChangeButton
        '
        Me.ColorChangeButton.Location = New System.Drawing.Point(12, 240)
        Me.ColorChangeButton.Name = "ColorChangeButton"
        Me.ColorChangeButton.Size = New System.Drawing.Size(78, 73)
        Me.ColorChangeButton.TabIndex = 17
        Me.ColorChangeButton.Text = "Color Test"
        Me.ColorChangeButton.UseVisualStyleBackColor = True
        '
        'OverwriteButton
        '
        Me.OverwriteButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.OverwriteButton.Location = New System.Drawing.Point(93, 240)
        Me.OverwriteButton.Name = "OverwriteButton"
        Me.OverwriteButton.Size = New System.Drawing.Size(79, 73)
        Me.OverwriteButton.TabIndex = 18
        Me.OverwriteButton.Text = "Overwrite"
        Me.OverwriteButton.UseVisualStyleBackColor = True
        '
        'OverwriteTextBox
        '
        Me.OverwriteTextBox.Location = New System.Drawing.Point(174, 262)
        Me.OverwriteTextBox.Name = "OverwriteTextBox"
        Me.OverwriteTextBox.Size = New System.Drawing.Size(100, 22)
        Me.OverwriteTextBox.TabIndex = 19
        Me.OverwriteTextBox.Text = "1"
        '
        'ReturnButton
        '
        Me.ReturnButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReturnButton.Location = New System.Drawing.Point(691, 348)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(92, 90)
        Me.ReturnButton.TabIndex = 20
        Me.ReturnButton.Text = "Return to Game Menu"
        Me.ReturnButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(174, 240)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 16)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Player Overwrite"
        '
        'TestTargetStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ReturnButton)
        Me.Controls.Add(Me.OverwriteTextBox)
        Me.Controls.Add(Me.OverwriteButton)
        Me.Controls.Add(Me.ColorChangeButton)
        Me.Controls.Add(Me.ResultLabel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DisableButton)
        Me.Controls.Add(Me.EnableButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.WriteButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.WriteTextBox)
        Me.Controls.Add(Me.AddressTextBox)
        Me.Controls.Add(Me.ReadButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RecievedTargetData)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "TestTargetStatus"
        Me.Text = "TestTargetStatus"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RecievedTargetData As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ReadButton As Button
    Friend WithEvents AddressTextBox As TextBox
    Friend WithEvents WriteTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents WriteButton As Button
    Friend WithEvents DecimalRadioButton As RadioButton
    Friend WithEvents HexRadioButton As RadioButton
    Friend WithEvents AsciiRadioButton As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents EnableButton As Button
    Friend WithEvents DisableButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ResultLabel As TextBox
    Friend WithEvents ColorChangeButton As Button
    Friend WithEvents OverwriteButton As Button
    Friend WithEvents OverwriteTextBox As TextBox
    Friend WithEvents ReturnButton As Button
    Friend WithEvents Label5 As Label
End Class
