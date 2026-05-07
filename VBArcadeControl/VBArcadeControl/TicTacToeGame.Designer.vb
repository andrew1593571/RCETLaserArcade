<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TicTacToeGame
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
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.ReturnButton = New System.Windows.Forms.Button()
        Me.PlayerTurnTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TurnsPassedTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ConstantReadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TimerTestRadioButton = New System.Windows.Forms.RadioButton()
        Me.WrongPlayerTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.ControlsGroupBox = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TurnPictureBox = New System.Windows.Forms.PictureBox()
        Me.WinnerPictureBox = New System.Windows.Forms.PictureBox()
        Me.LightUpTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.ControlsGroupBox.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.TurnPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WinnerPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartButton.Location = New System.Drawing.Point(3, 314)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(90, 90)
        Me.StartButton.TabIndex = 0
        Me.StartButton.Text = "Start Game"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ResetButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetButton.Location = New System.Drawing.Point(99, 314)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(90, 90)
        Me.ResetButton.TabIndex = 1
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'ReturnButton
        '
        Me.ReturnButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReturnButton.Location = New System.Drawing.Point(195, 314)
        Me.ReturnButton.Name = "ReturnButton"
        Me.ReturnButton.Size = New System.Drawing.Size(92, 90)
        Me.ReturnButton.TabIndex = 2
        Me.ReturnButton.Text = "Return to Game Menu"
        Me.ReturnButton.UseVisualStyleBackColor = True
        '
        'PlayerTurnTextBox
        '
        Me.PlayerTurnTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PlayerTurnTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PlayerTurnTextBox.Location = New System.Drawing.Point(3, 90)
        Me.PlayerTurnTextBox.Name = "PlayerTurnTextBox"
        Me.PlayerTurnTextBox.ReadOnly = True
        Me.PlayerTurnTextBox.Size = New System.Drawing.Size(90, 30)
        Me.PlayerTurnTextBox.TabIndex = 12
        Me.PlayerTurnTextBox.Text = "1"
        Me.PlayerTurnTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 33)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Player:"
        '
        'TurnsPassedTextBox
        '
        Me.TurnsPassedTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TurnsPassedTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TurnsPassedTextBox.Location = New System.Drawing.Point(99, 3)
        Me.TurnsPassedTextBox.Name = "TurnsPassedTextBox"
        Me.TurnsPassedTextBox.ReadOnly = True
        Me.TurnsPassedTextBox.Size = New System.Drawing.Size(90, 30)
        Me.TurnsPassedTextBox.TabIndex = 15
        Me.TurnsPassedTextBox.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 50)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Turns Passed:"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(195, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 40)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Winner"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ConstantReadTimer
        '
        '
        'TimerTestRadioButton
        '
        Me.TimerTestRadioButton.AutoSize = True
        Me.TimerTestRadioButton.Location = New System.Drawing.Point(331, 431)
        Me.TimerTestRadioButton.Name = "TimerTestRadioButton"
        Me.TimerTestRadioButton.Size = New System.Drawing.Size(93, 20)
        Me.TimerTestRadioButton.TabIndex = 19
        Me.TimerTestRadioButton.TabStop = True
        Me.TimerTestRadioButton.Text = "Timer Test"
        Me.TimerTestRadioButton.UseVisualStyleBackColor = True
        Me.TimerTestRadioButton.Visible = False
        '
        'WrongPlayerTimer
        '
        Me.WrongPlayerTimer.Interval = 500
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox5, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox6, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox7, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox8, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox9, 2, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(304, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(474, 414)
        Me.TableLayoutPanel1.TabIndex = 22
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Enabled = False
        Me.PictureBox1.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox1.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(152, 132)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Enabled = False
        Me.PictureBox2.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox2.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox2.Location = New System.Drawing.Point(161, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(152, 132)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 4
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Enabled = False
        Me.PictureBox3.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox3.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox3.Location = New System.Drawing.Point(319, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(152, 132)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 5
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox4.Enabled = False
        Me.PictureBox4.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox4.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox4.Location = New System.Drawing.Point(3, 141)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(152, 132)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 6
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox5.Enabled = False
        Me.PictureBox5.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox5.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox5.Location = New System.Drawing.Point(161, 141)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(152, 132)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 7
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox6.Enabled = False
        Me.PictureBox6.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox6.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox6.Location = New System.Drawing.Point(319, 141)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(152, 132)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 8
        Me.PictureBox6.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox7.Enabled = False
        Me.PictureBox7.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox7.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox7.Location = New System.Drawing.Point(3, 279)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(152, 132)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox7.TabIndex = 9
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.Enabled = False
        Me.PictureBox8.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox8.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox8.Location = New System.Drawing.Point(161, 279)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(152, 132)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox8.TabIndex = 10
        Me.PictureBox8.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox9.Enabled = False
        Me.PictureBox9.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox9.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.PictureBox9.Location = New System.Drawing.Point(319, 279)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(152, 132)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox9.TabIndex = 21
        Me.PictureBox9.TabStop = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.63223!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.36777!))
        Me.TableLayoutPanel4.Controls.Add(Me.ControlsGroupBox, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel1, 1, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(7, 5)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(781, 420)
        Me.TableLayoutPanel4.TabIndex = 25
        '
        'ControlsGroupBox
        '
        Me.ControlsGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ControlsGroupBox.Controls.Add(Me.TableLayoutPanel2)
        Me.ControlsGroupBox.Location = New System.Drawing.Point(3, 3)
        Me.ControlsGroupBox.Name = "ControlsGroupBox"
        Me.ControlsGroupBox.Size = New System.Drawing.Size(295, 414)
        Me.ControlsGroupBox.TabIndex = 26
        Me.ControlsGroupBox.TabStop = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel2.Controls.Add(Me.TurnsPassedTextBox, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TurnPictureBox, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.WinnerPictureBox, 2, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.PlayerTurnTextBox, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.StartButton, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.ResetButton, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.ReturnButton, 2, 5)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(2, 4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.36334!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.61093!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.86174!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.93891!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.22508!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(290, 407)
        Me.TableLayoutPanel2.TabIndex = 23
        '
        'TurnPictureBox
        '
        Me.TurnPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TurnPictureBox.Image = Global.VBArcadeControl.My.Resources.Resources.GIcon
        Me.TurnPictureBox.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.TurnPictureBox.Location = New System.Drawing.Point(3, 130)
        Me.TurnPictureBox.Name = "TurnPictureBox"
        Me.TurnPictureBox.Size = New System.Drawing.Size(90, 84)
        Me.TurnPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.TurnPictureBox.TabIndex = 14
        Me.TurnPictureBox.TabStop = False
        '
        'WinnerPictureBox
        '
        Me.WinnerPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WinnerPictureBox.Image = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.WinnerPictureBox.InitialImage = Global.VBArcadeControl.My.Resources.Resources.NoIcon
        Me.WinnerPictureBox.Location = New System.Drawing.Point(195, 130)
        Me.WinnerPictureBox.Name = "WinnerPictureBox"
        Me.WinnerPictureBox.Size = New System.Drawing.Size(92, 84)
        Me.WinnerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.WinnerPictureBox.TabIndex = 17
        Me.WinnerPictureBox.TabStop = False
        '
        'LightUpTimer
        '
        '
        'TicTacToeGame
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TimerTestRadioButton)
        Me.Controls.Add(Me.TableLayoutPanel4)
        Me.Name = "TicTacToeGame"
        Me.Text = "TicTacToeGame"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ControlsGroupBox.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.TurnPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WinnerPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StartButton As Button
    Friend WithEvents ResetButton As Button
    Friend WithEvents ReturnButton As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PlayerTurnTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TurnPictureBox As PictureBox
    Friend WithEvents TurnsPassedTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents WinnerPictureBox As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ConstantReadTimer As Timer
    Friend WithEvents TimerTestRadioButton As RadioButton
    Friend WithEvents WrongPlayerTimer As Timer
    Friend WithEvents PictureBox9 As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents ControlsGroupBox As GroupBox
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents LightUpTimer As Timer
End Class
