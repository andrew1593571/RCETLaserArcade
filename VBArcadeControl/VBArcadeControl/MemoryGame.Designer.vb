<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MemoryGame
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
        Me.StartButton = New System.Windows.Forms.Button()
        Me.Reset = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.TimerShort = New System.Windows.Forms.Timer(Me.components)
        Me.TimerLong = New System.Windows.Forms.Timer(Me.components)
        Me.TimerThink = New System.Windows.Forms.Timer(Me.components)
        Me.TurnsTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox21 = New System.Windows.Forms.PictureBox()
        Me.PictureBox22 = New System.Windows.Forms.PictureBox()
        Me.PictureBox23 = New System.Windows.Forms.PictureBox()
        Me.PictureBox24 = New System.Windows.Forms.PictureBox()
        Me.PictureBox25 = New System.Windows.Forms.PictureBox()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.PictureBox19 = New System.Windows.Forms.PictureBox()
        Me.PictureBox20 = New System.Windows.Forms.PictureBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TargetsLeftTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TargetsHitTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TimerRoundPass = New System.Windows.Forms.Timer(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StatusTextBox = New System.Windows.Forms.TextBox()
        Me.TurnPictureBox = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PlayerTurnTextBox = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TurnPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(12, 361)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(80, 80)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start Game"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'Reset
        '
        Me.Reset.Location = New System.Drawing.Point(93, 361)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(80, 80)
        Me.Reset.TabIndex = 1
        Me.Reset.Text = "Reset"
        Me.Reset.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(278, 327)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ReturnButton
        '
        Me.ReturnButton.Location = New System.Drawing.Point(278, 356)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(80, 80)
        Me.ReturnButton.TabIndex = 3
        Me.ReturnButton.Text = "Return to Game Menu"
        Me.ReturnButton.UseVisualStyleBackColor = True
        '
        'TimerShort
        '
        Me.TimerShort.Interval = 500
        '
        'TimerLong
        '
        Me.TimerLong.Interval = 2500
        '
        'TimerThink
        '
        Me.TimerThink.Interval = 10000
        '
        'TurnsTextBox
        '
        Me.TurnsTextBox.Location = New System.Drawing.Point(12, 41)
        Me.TurnsTextBox.Name = "TurnsTextBox"
        Me.TurnsTextBox.ReadOnly = True
        Me.TurnsTextBox.Size = New System.Drawing.Size(89, 22)
        Me.TurnsTextBox.TabIndex = 29
        Me.TurnsTextBox.Text = "0"
        '
        'PictureBox21
        '
        Me.PictureBox21.Enabled = False
        Me.PictureBox21.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox21.Location = New System.Drawing.Point(364, 356)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox21.TabIndex = 28
        Me.PictureBox21.TabStop = False
        '
        'PictureBox22
        '
        Me.PictureBox22.Enabled = False
        Me.PictureBox22.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox22.Location = New System.Drawing.Point(450, 356)
        Me.PictureBox22.Name = "PictureBox22"
        Me.PictureBox22.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox22.TabIndex = 27
        Me.PictureBox22.TabStop = False
        '
        'PictureBox23
        '
        Me.PictureBox23.Enabled = False
        Me.PictureBox23.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox23.Location = New System.Drawing.Point(536, 356)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox23.TabIndex = 26
        Me.PictureBox23.TabStop = False
        '
        'PictureBox24
        '
        Me.PictureBox24.Enabled = False
        Me.PictureBox24.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox24.Location = New System.Drawing.Point(622, 356)
        Me.PictureBox24.Name = "PictureBox24"
        Me.PictureBox24.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox24.TabIndex = 25
        Me.PictureBox24.TabStop = False
        '
        'PictureBox25
        '
        Me.PictureBox25.Enabled = False
        Me.PictureBox25.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox25.Location = New System.Drawing.Point(708, 356)
        Me.PictureBox25.Name = "PictureBox25"
        Me.PictureBox25.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox25.TabIndex = 24
        Me.PictureBox25.TabStop = False
        '
        'PictureBox16
        '
        Me.PictureBox16.Enabled = False
        Me.PictureBox16.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox16.Location = New System.Drawing.Point(364, 270)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox16.TabIndex = 23
        Me.PictureBox16.TabStop = False
        '
        'PictureBox17
        '
        Me.PictureBox17.Enabled = False
        Me.PictureBox17.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox17.Location = New System.Drawing.Point(450, 270)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox17.TabIndex = 22
        Me.PictureBox17.TabStop = False
        '
        'PictureBox18
        '
        Me.PictureBox18.Enabled = False
        Me.PictureBox18.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox18.Location = New System.Drawing.Point(536, 270)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox18.TabIndex = 21
        Me.PictureBox18.TabStop = False
        '
        'PictureBox19
        '
        Me.PictureBox19.Enabled = False
        Me.PictureBox19.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox19.Location = New System.Drawing.Point(622, 270)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox19.TabIndex = 20
        Me.PictureBox19.TabStop = False
        '
        'PictureBox20
        '
        Me.PictureBox20.Enabled = False
        Me.PictureBox20.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox20.Location = New System.Drawing.Point(708, 270)
        Me.PictureBox20.Name = "PictureBox20"
        Me.PictureBox20.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox20.TabIndex = 19
        Me.PictureBox20.TabStop = False
        '
        'PictureBox11
        '
        Me.PictureBox11.Enabled = False
        Me.PictureBox11.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox11.Location = New System.Drawing.Point(364, 184)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox11.TabIndex = 18
        Me.PictureBox11.TabStop = False
        '
        'PictureBox12
        '
        Me.PictureBox12.Enabled = False
        Me.PictureBox12.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox12.Location = New System.Drawing.Point(450, 184)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox12.TabIndex = 17
        Me.PictureBox12.TabStop = False
        '
        'PictureBox13
        '
        Me.PictureBox13.Enabled = False
        Me.PictureBox13.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox13.Location = New System.Drawing.Point(536, 184)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox13.TabIndex = 16
        Me.PictureBox13.TabStop = False
        '
        'PictureBox14
        '
        Me.PictureBox14.Enabled = False
        Me.PictureBox14.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox14.Location = New System.Drawing.Point(622, 184)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox14.TabIndex = 15
        Me.PictureBox14.TabStop = False
        '
        'PictureBox15
        '
        Me.PictureBox15.Enabled = False
        Me.PictureBox15.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox15.Location = New System.Drawing.Point(708, 184)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox15.TabIndex = 14
        Me.PictureBox15.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Enabled = False
        Me.PictureBox6.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox6.Location = New System.Drawing.Point(364, 98)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 13
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Enabled = False
        Me.PictureBox7.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox7.Location = New System.Drawing.Point(450, 98)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 12
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Enabled = False
        Me.PictureBox8.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox8.Location = New System.Drawing.Point(536, 98)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 11
        Me.PictureBox8.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Enabled = False
        Me.PictureBox9.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox9.Location = New System.Drawing.Point(622, 98)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox9.TabIndex = 10
        Me.PictureBox9.TabStop = False
        '
        'PictureBox10
        '
        Me.PictureBox10.Enabled = False
        Me.PictureBox10.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox10.Location = New System.Drawing.Point(708, 98)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox10.TabIndex = 9
        Me.PictureBox10.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Enabled = False
        Me.PictureBox5.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox5.Location = New System.Drawing.Point(708, 12)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 8
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Enabled = False
        Me.PictureBox4.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox4.Location = New System.Drawing.Point(622, 12)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 7
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Enabled = False
        Me.PictureBox3.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox3.Location = New System.Drawing.Point(536, 12)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 6
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Enabled = False
        Me.PictureBox2.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox2.Location = New System.Drawing.Point(450, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Enabled = False
        Me.PictureBox1.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox1.Location = New System.Drawing.Point(364, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'TargetsLeftTextBox
        '
        Me.TargetsLeftTextBox.Location = New System.Drawing.Point(12, 98)
        Me.TargetsLeftTextBox.Name = "TargetsLeftTextBox"
        Me.TargetsLeftTextBox.ReadOnly = True
        Me.TargetsLeftTextBox.Size = New System.Drawing.Size(89, 22)
        Me.TargetsLeftTextBox.TabIndex = 30
        Me.TargetsLeftTextBox.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Turns"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Targets Left"
        '
        'TargetsHitTextBox
        '
        Me.TargetsHitTextBox.Location = New System.Drawing.Point(12, 156)
        Me.TargetsHitTextBox.Name = "TargetsHitTextBox"
        Me.TargetsHitTextBox.ReadOnly = True
        Me.TargetsHitTextBox.Size = New System.Drawing.Size(89, 22)
        Me.TargetsHitTextBox.TabIndex = 33
        Me.TargetsHitTextBox.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 16)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Targets Hit"
        '
        'TimerRoundPass
        '
        Me.TimerRoundPass.Interval = 2500
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Status"
        '
        'StatusTextBox
        '
        Me.StatusTextBox.Location = New System.Drawing.Point(12, 211)
        Me.StatusTextBox.Name = "StatusTextBox"
        Me.StatusTextBox.ReadOnly = True
        Me.StatusTextBox.Size = New System.Drawing.Size(161, 22)
        Me.StatusTextBox.TabIndex = 37
        Me.StatusTextBox.Text = "Ready"
        '
        'TurnPictureBox
        '
        Me.TurnPictureBox.Image = Global.VBArcadeControl.My.Resources.Resources.BIcon
        Me.TurnPictureBox.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.TurnPictureBox.Location = New System.Drawing.Point(17, 270)
        Me.TurnPictureBox.Name = "TurnPictureBox"
        Me.TurnPictureBox.Size = New System.Drawing.Size(58, 58)
        Me.TurnPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TurnPictureBox.TabIndex = 40
        Me.TurnPictureBox.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 242)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 16)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Player"
        '
        'PlayerTurnTextBox
        '
        Me.PlayerTurnTextBox.Location = New System.Drawing.Point(55, 242)
        Me.PlayerTurnTextBox.Name = "PlayerTurnTextBox"
        Me.PlayerTurnTextBox.ReadOnly = True
        Me.PlayerTurnTextBox.Size = New System.Drawing.Size(33, 22)
        Me.PlayerTurnTextBox.TabIndex = 38
        Me.PlayerTurnTextBox.Text = "1"
        '
        'MemoryGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TurnPictureBox)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PlayerTurnTextBox)
        Me.Controls.Add(Me.StatusTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TargetsHitTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TargetsLeftTextBox)
        Me.Controls.Add(Me.TurnsTextBox)
        Me.Controls.Add(Me.PictureBox21)
        Me.Controls.Add(Me.PictureBox22)
        Me.Controls.Add(Me.PictureBox23)
        Me.Controls.Add(Me.PictureBox24)
        Me.Controls.Add(Me.PictureBox25)
        Me.Controls.Add(Me.PictureBox16)
        Me.Controls.Add(Me.PictureBox17)
        Me.Controls.Add(Me.PictureBox18)
        Me.Controls.Add(Me.PictureBox19)
        Me.Controls.Add(Me.PictureBox20)
        Me.Controls.Add(Me.PictureBox11)
        Me.Controls.Add(Me.PictureBox12)
        Me.Controls.Add(Me.PictureBox13)
        Me.Controls.Add(Me.PictureBox14)
        Me.Controls.Add(Me.PictureBox15)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox10)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReturnButton)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Reset)
        Me.Controls.Add(Me.StartButton)
        Me.Name = "MemoryGame"
        Me.Text = "MemoryGame"
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TurnPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StartButton As Button
    Friend WithEvents Reset As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ReturnButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents PictureBox10 As PictureBox
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents PictureBox12 As PictureBox
    Friend WithEvents PictureBox13 As PictureBox
    Friend WithEvents PictureBox14 As PictureBox
    Friend WithEvents PictureBox15 As PictureBox
    Friend WithEvents PictureBox16 As PictureBox
    Friend WithEvents PictureBox17 As PictureBox
    Friend WithEvents PictureBox18 As PictureBox
    Friend WithEvents PictureBox19 As PictureBox
    Friend WithEvents PictureBox20 As PictureBox
    Friend WithEvents PictureBox21 As PictureBox
    Friend WithEvents PictureBox22 As PictureBox
    Friend WithEvents PictureBox23 As PictureBox
    Friend WithEvents PictureBox24 As PictureBox
    Friend WithEvents PictureBox25 As PictureBox
    Friend WithEvents TimerShort As Timer
    Friend WithEvents TimerLong As Timer
    Friend WithEvents TimerThink As Timer
    Friend WithEvents TurnsTextBox As TextBox
    Friend WithEvents TargetsLeftTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TargetsHitTextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TimerRoundPass As Timer
    Friend WithEvents Label4 As Label
    Friend WithEvents StatusTextBox As TextBox
    Friend WithEvents TurnPictureBox As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents PlayerTurnTextBox As TextBox
End Class
