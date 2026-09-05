<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LightningGameForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LightningGameForm))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Player1PictureBox = New System.Windows.Forms.PictureBox()
        Me.P1TextBox = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.P4TextBox = New System.Windows.Forms.TextBox()
        Me.Player4PictureBox = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.P3TextBox = New System.Windows.Forms.TextBox()
        Me.Player3PictureBox = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.P2TextBox = New System.Windows.Forms.TextBox()
        Me.Player2PictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.Player1PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.Player4PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Player3PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Player2PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(3, 365)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(185, 58)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "START"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StopButton
        '
        Me.StopButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StopButton.Location = New System.Drawing.Point(385, 365)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(185, 58)
        Me.StopButton.TabIndex = 14
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.Location = New System.Drawing.Point(576, 365)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(188, 58)
        Me.ExitButton.TabIndex = 15
        Me.ExitButton.Text = "E&xit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'Player1PictureBox
        '
        Me.Player1PictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Player1PictureBox.Image = CType(resources.GetObject("Player1PictureBox.Image"), System.Drawing.Image)
        Me.Player1PictureBox.Location = New System.Drawing.Point(6, 21)
        Me.Player1PictureBox.Name = "Player1PictureBox"
        Me.Player1PictureBox.Size = New System.Drawing.Size(173, 329)
        Me.Player1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player1PictureBox.TabIndex = 0
        Me.Player1PictureBox.TabStop = False
        '
        'P1TextBox
        '
        Me.P1TextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.P1TextBox.BackColor = System.Drawing.Color.Gray
        Me.P1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.P1TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.P1TextBox.Location = New System.Drawing.Point(84, 223)
        Me.P1TextBox.Name = "P1TextBox"
        Me.P1TextBox.ReadOnly = True
        Me.P1TextBox.Size = New System.Drawing.Size(17, 23)
        Me.P1TextBox.TabIndex = 17
        Me.P1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ExitButton, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.StopButton, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBox2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(767, 426)
        Me.TableLayoutPanel1.TabIndex = 19
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!)
        Me.TextBox1.Location = New System.Drawing.Point(194, 365)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(185, 53)
        Me.TextBox1.TabIndex = 20
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.P4TextBox)
        Me.GroupBox4.Controls.Add(Me.Player4PictureBox)
        Me.GroupBox4.Location = New System.Drawing.Point(576, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(188, 356)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        '
        'P4TextBox
        '
        Me.P4TextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.P4TextBox.BackColor = System.Drawing.Color.Gray
        Me.P4TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.P4TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.P4TextBox.Location = New System.Drawing.Point(125, 223)
        Me.P4TextBox.Name = "P4TextBox"
        Me.P4TextBox.ReadOnly = True
        Me.P4TextBox.Size = New System.Drawing.Size(17, 23)
        Me.P4TextBox.TabIndex = 17
        Me.P4TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Player4PictureBox
        '
        Me.Player4PictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Player4PictureBox.Image = Global.VBArcadeControl.My.Resources.Resources.UIPlayer4
        Me.Player4PictureBox.Location = New System.Drawing.Point(6, 21)
        Me.Player4PictureBox.Name = "Player4PictureBox"
        Me.Player4PictureBox.Size = New System.Drawing.Size(176, 329)
        Me.Player4PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player4PictureBox.TabIndex = 0
        Me.Player4PictureBox.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.P1TextBox)
        Me.GroupBox1.Controls.Add(Me.Player1PictureBox)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 356)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.P3TextBox)
        Me.GroupBox3.Controls.Add(Me.Player3PictureBox)
        Me.GroupBox3.Location = New System.Drawing.Point(385, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(185, 356)
        Me.GroupBox3.TabIndex = 21
        Me.GroupBox3.TabStop = False
        '
        'P3TextBox
        '
        Me.P3TextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.P3TextBox.BackColor = System.Drawing.Color.Gray
        Me.P3TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.P3TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.P3TextBox.Location = New System.Drawing.Point(93, 223)
        Me.P3TextBox.Name = "P3TextBox"
        Me.P3TextBox.ReadOnly = True
        Me.P3TextBox.Size = New System.Drawing.Size(17, 23)
        Me.P3TextBox.TabIndex = 17
        Me.P3TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Player3PictureBox
        '
        Me.Player3PictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Player3PictureBox.Image = Global.VBArcadeControl.My.Resources.Resources.UIPlayer3
        Me.Player3PictureBox.Location = New System.Drawing.Point(6, 21)
        Me.Player3PictureBox.Name = "Player3PictureBox"
        Me.Player3PictureBox.Size = New System.Drawing.Size(173, 329)
        Me.Player3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player3PictureBox.TabIndex = 0
        Me.Player3PictureBox.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.P2TextBox)
        Me.GroupBox2.Controls.Add(Me.Player2PictureBox)
        Me.GroupBox2.Location = New System.Drawing.Point(194, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(185, 356)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'P2TextBox
        '
        Me.P2TextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.P2TextBox.BackColor = System.Drawing.Color.Gray
        Me.P2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.P2TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.P2TextBox.Location = New System.Drawing.Point(89, 223)
        Me.P2TextBox.Name = "P2TextBox"
        Me.P2TextBox.ReadOnly = True
        Me.P2TextBox.Size = New System.Drawing.Size(17, 23)
        Me.P2TextBox.TabIndex = 17
        Me.P2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Player2PictureBox
        '
        Me.Player2PictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Player2PictureBox.Image = Global.VBArcadeControl.My.Resources.Resources.UIPlayer2
        Me.Player2PictureBox.Location = New System.Drawing.Point(6, 21)
        Me.Player2PictureBox.Name = "Player2PictureBox"
        Me.Player2PictureBox.Size = New System.Drawing.Size(173, 329)
        Me.Player2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Player2PictureBox.TabIndex = 0
        Me.Player2PictureBox.TabStop = False
        '
        'LightningGameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 481)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "LightningGameForm"
        Me.Text = "LightningGameForm"
        CType(Me.Player1PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.Player4PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Player3PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Player2PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents StopButton As Button
    Friend WithEvents ExitButton As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Player1PictureBox As PictureBox
    Friend WithEvents P1TextBox As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents P2TextBox As TextBox
    Friend WithEvents Player2PictureBox As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents P3TextBox As TextBox
    Friend WithEvents Player3PictureBox As PictureBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents P4TextBox As TextBox
    Friend WithEvents Player4PictureBox As PictureBox
    Friend WithEvents TextBox1 As TextBox
End Class
