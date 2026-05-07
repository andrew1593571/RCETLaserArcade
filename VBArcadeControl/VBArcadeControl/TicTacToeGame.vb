Imports System.Net

Public Class TicTacToeGame
    Private WithEvents ticTacToeCOM As UARTController
    Private WithEvents ticTacToeSound As GameSounds
    Public Sub New(ticTacToeTarget As UARTController)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ticTacToeCOM = ticTacToeTarget
    End Sub
    Public Sub New(ticTacToeSounds As GameSounds)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        ticTacToeSound = ticTacToeSounds
    End Sub

    'Target Arrays
    Dim TicTacToeTargets(9) As Byte

    'When Target gets hit, Read Targets
    Private Sub ticTacToeCOM_TargetHit(address As Byte, player As Byte) Handles ticTacToeCOM.TargetHit
        If player > 0 Then
            If Me.InvokeRequired Then
                Me.Invoke(Sub() ReadTicTacToeTarget(address, player))
            Else
                ReadTicTacToeTarget(address, player)
            End If
        End If
    End Sub

    'Picks the Picturebox based on number
    Sub PictureBoxPicker(pictureBox As Integer)
        Select Case pictureBox
            Case 1
                PictureBox1.Image = TurnPictureBox.Image
            Case 2
                PictureBox2.Image = TurnPictureBox.Image
            Case 3
                PictureBox3.Image = TurnPictureBox.Image
            Case 4
                PictureBox4.Image = TurnPictureBox.Image
            Case 5
                PictureBox5.Image = TurnPictureBox.Image
            Case 6
                PictureBox6.Image = TurnPictureBox.Image
            Case 7
                PictureBox7.Image = TurnPictureBox.Image
            Case 8
                PictureBox8.Image = TurnPictureBox.Image
            Case 9
                PictureBox9.Image = TurnPictureBox.Image
        End Select
    End Sub

    Function Convert123To789(address As Integer)
        Dim actualTarget
        Select Case address
            Case 1
                actualTarget = 7
            Case 2
                actualTarget = 8
            Case 3
                actualTarget = 9
            Case 4
                actualTarget = 12
            Case 5
                actualTarget = 13
            Case 6
                actualTarget = 14
            Case 7
                actualTarget = 17
            Case 8
                actualTarget = 18
            Case 9
                actualTarget = 19
            Case Else
                actualTarget = 0
        End Select

        Return actualTarget
    End Function

    Sub ReadTicTacToeTarget(address As Byte, player As Byte)
        Dim validPlayerTurn As Integer
        Dim actualTarget As Integer
        Select Case address
            Case 14
                actualTarget = 1
            Case 16
                actualTarget = 2
            Case 18
                actualTarget = 3
            Case 24
                actualTarget = 4
            Case 26
                actualTarget = 5
            Case 28
                actualTarget = 6
            Case 34
                actualTarget = 7
            Case 36
                actualTarget = 8
            Case 38
                actualTarget = 9
        End Select


        'Sets Valid Player based on whos turn it is
        If PlayerTurnTextBox.Text = "1" Then
            validPlayerTurn = 1
        Else
            validPlayerTurn = 2
        End If

        'Checks if target was hit by appropriate player
        If player = validPlayerTurn Then
            MakeTicTacToeHit(actualTarget)                         'Marks target as hit.
        Else
            ConstantReadTimer.Stop()                                'Stops reading to prevent errors
            wrongTurnTarget = address                               'Determines which target to re-enable
            WrongPlayerTimer.Start()                                'Starts Timer to re-enable target and reintroduce reading
        End If

    End Sub

    'Marks Target as Hit
    Sub MakeTicTacToeHit(target As Integer)
        ConstantReadTimer.Stop()
        ticTacToeCOM.SendI2COverwrite(Convert123To789(target) * 2, CInt(PlayerTurnTextBox.Text))
        lightTarget = target                               'Determines which target to re-enable

        TicTacToeTargets(target) = CInt(PlayerTurnTextBox.Text)     'Sees which player shot the target
        ticTacToeCOM.SendI2CDisable(Convert123To789(target) * 2)                     'Disables Target

        ticTacToeSound.HitSound()
        PictureBoxPicker(target)                                    'Determines which picturebox to update with which player

        Dim preCount As Integer
        Dim postCount As Integer
        preCount = CInt(TurnsPassedTextBox.Text)                    'Checks Current Turn Number
        postCount = Counter(preCount)                               'Increments by 1
        TurnsPassedTextBox.Text = postCount                         'Updates Turn Number in UI
        LightUpTimer.Start()
        WinCheck()                                                  'Checks if win condition was met
    End Sub

    Sub ClickTarget(target As Integer)
        'ticTacToeCOM.SendI2COverwrite(CByte(Convert123To789(target) * 2), CByte(CInt(PlayerTurnTextBox.Text)))
        ticTacToeCOM.SendI2CDisable(Convert123To789(target) * 2)
        MakeTicTacToeHit(target)

    End Sub

    Dim wrongTurnTarget As Integer
    Dim lightTarget As Integer

    Sub Reset()
        PictureBox1.Image = My.Resources.NoIcon
        PictureBox2.Image = My.Resources.NoIcon
        PictureBox3.Image = My.Resources.NoIcon
        PictureBox4.Image = My.Resources.NoIcon
        PictureBox5.Image = My.Resources.NoIcon
        PictureBox6.Image = My.Resources.NoIcon
        PictureBox7.Image = My.Resources.NoIcon
        PictureBox8.Image = My.Resources.NoIcon
        PictureBox9.Image = My.Resources.NoIcon

        PictureBox1.Enabled = False
        PictureBox2.Enabled = False
        PictureBox3.Enabled = False
        PictureBox4.Enabled = False
        PictureBox5.Enabled = False
        PictureBox6.Enabled = False
        PictureBox7.Enabled = False
        PictureBox8.Enabled = False
        PictureBox9.Enabled = False

        TicTacToeTargets(0) = 0
        TicTacToeTargets(1) = 0
        TicTacToeTargets(2) = 0
        TicTacToeTargets(3) = 0
        TicTacToeTargets(4) = 0
        TicTacToeTargets(5) = 0
        TicTacToeTargets(6) = 0
        TicTacToeTargets(7) = 0
        TicTacToeTargets(8) = 0
        TicTacToeTargets(9) = 0

        ResetButton.Enabled = False
        StartButton.Enabled = True

        PlayerTurnTextBox.Text = "1"
        TurnsPassedTextBox.Text = "0"
        TurnPictureBox.Image = My.Resources.GIcon
        WinnerPictureBox.Image = My.Resources.NoIcon

    End Sub
    Function Counter(currentCount As Integer) As Integer
        If currentCount > 8 Then
            currentCount = 1
        Else
            currentCount = currentCount + 1
        End If

        If PlayerTurnTextBox.Text = "1" Then
            PlayerTurnTextBox.Text = "2"
            TurnPictureBox.Image = My.Resources.AIcon
        Else
            PlayerTurnTextBox.Text = "1"
            TurnPictureBox.Image = My.Resources.GIcon
        End If

        Return currentCount
    End Function


    Sub WinCheck()
        'Player 1 Win Conditions
        If TicTacToeTargets(1) = 1 And TicTacToeTargets(2) = 1 And TicTacToeTargets(3) = 1 Then
            WinnerPictureBox.Image = My.Resources.GIcon
            ticTacToeSound.WinSound()
            EndGame(1)
        End If
        If TicTacToeTargets(4) = 1 And TicTacToeTargets(5) = 1 And TicTacToeTargets(6) = 1 Then
            WinnerPictureBox.Image = My.Resources.GIcon
            ticTacToeSound.WinSound()
            EndGame(1)
        End If
        If TicTacToeTargets(7) = 1 And TicTacToeTargets(8) = 1 And TicTacToeTargets(9) = 1 Then
            WinnerPictureBox.Image = My.Resources.GIcon
            ticTacToeSound.WinSound()
            EndGame(1)
        End If
        If TicTacToeTargets(1) = 1 And TicTacToeTargets(4) = 1 And TicTacToeTargets(7) = 1 Then
            WinnerPictureBox.Image = My.Resources.GIcon
            ticTacToeSound.WinSound()
            EndGame(1)
        End If
        If TicTacToeTargets(2) = 1 And TicTacToeTargets(5) = 1 And TicTacToeTargets(8) = 1 Then
            WinnerPictureBox.Image = My.Resources.GIcon '???
            ticTacToeSound.WinSound()
            EndGame(1)
        End If
        If TicTacToeTargets(3) = 1 And TicTacToeTargets(6) = 1 And TicTacToeTargets(9) = 1 Then
            WinnerPictureBox.Image = My.Resources.GIcon
            ticTacToeSound.WinSound()
            EndGame(1)
        End If
        If TicTacToeTargets(1) = 1 And TicTacToeTargets(5) = 1 And TicTacToeTargets(9) = 1 Then
            WinnerPictureBox.Image = My.Resources.GIcon
            ticTacToeSound.WinSound()
            EndGame(1)
        End If
        If TicTacToeTargets(3) = 1 And TicTacToeTargets(5) = 1 And TicTacToeTargets(7) = 1 Then
            WinnerPictureBox.Image = My.Resources.GIcon
            ticTacToeSound.WinSound()
            EndGame(1)
        End If

        'player 2
        If TicTacToeTargets(1) = 2 And TicTacToeTargets(2) = 2 And TicTacToeTargets(3) = 2 Then
            WinnerPictureBox.Image = My.Resources.AIcon
            ticTacToeSound.WinSound()
            EndGame(2)
        End If
        If TicTacToeTargets(4) = 2 And TicTacToeTargets(5) = 2 And TicTacToeTargets(6) = 2 Then
            WinnerPictureBox.Image = My.Resources.AIcon
            ticTacToeSound.WinSound()
            EndGame(2)
        End If
        If TicTacToeTargets(7) = 2 And TicTacToeTargets(8) = 2 And TicTacToeTargets(9) = 2 Then
            WinnerPictureBox.Image = My.Resources.AIcon
            ticTacToeSound.WinSound()
            EndGame(2)
        End If
        If TicTacToeTargets(1) = 2 And TicTacToeTargets(4) = 2 And TicTacToeTargets(7) = 2 Then
            WinnerPictureBox.Image = My.Resources.AIcon
            ticTacToeSound.WinSound()
            EndGame(2)
        End If
        If TicTacToeTargets(2) = 2 And TicTacToeTargets(5) = 2 And TicTacToeTargets(8) = 2 Then
            WinnerPictureBox.Image = My.Resources.AIcon
            ticTacToeSound.WinSound()
            EndGame(2)
        End If
        If TicTacToeTargets(3) = 2 And TicTacToeTargets(6) = 2 And TicTacToeTargets(9) = 2 Then
            WinnerPictureBox.Image = My.Resources.AIcon
            ticTacToeSound.WinSound()
            EndGame(2)
        End If
        If TicTacToeTargets(1) = 2 And TicTacToeTargets(5) = 2 And TicTacToeTargets(9) = 2 Then
            WinnerPictureBox.Image = My.Resources.AIcon
            ticTacToeSound.WinSound()
            EndGame(2)
        End If
        If TicTacToeTargets(3) = 2 And TicTacToeTargets(5) = 2 And TicTacToeTargets(7) = 2 Then
            WinnerPictureBox.Image = My.Resources.AIcon
            ticTacToeSound.WinSound()
            EndGame(2)
        End If

        If CInt(TurnsPassedTextBox.Text) = 9 Then
            If TicTacToeTargets(0) = 0 Then
                EndGame(0)
            End If

        End If
    End Sub

    Sub EndGame(Player As Integer)
        ConstantReadTimer.Stop()
        PictureBox1.Enabled = False
        PictureBox2.Enabled = False
        PictureBox3.Enabled = False
        PictureBox4.Enabled = False
        PictureBox5.Enabled = False
        PictureBox6.Enabled = False
        PictureBox7.Enabled = False
        PictureBox8.Enabled = False
        PictureBox9.Enabled = False
        StartButton.Enabled = True
        ResetButton.Enabled = False

        If PlayerTurnTextBox.Text = "1" Then
            TurnPictureBox.Image = My.Resources.GIconLose
        Else
            TurnPictureBox.Image = My.Resources.AIconLose
        End If

        TicTacToeTargets(0) = 1                         '???

        If Player = 1 Then
            'ticTacToeCOM.SendI2COverwrite(0, 1)
            MsgBox("P1 Wins")
        ElseIf Player = 2 Then
            'ticTacToeCOM.SendI2COverwrite(0, 2)
            MsgBox("P2 Wins")
        Else
            MsgBox("Draw")

        End If
    End Sub

    Function SkipReadTarget(Target As Integer)
        Dim Skip As Boolean = False

        If TicTacToeTargets(Target) > 0 Then
            Skip = True
        End If

        Return Skip
    End Function

    '--------------------------------------------------------------
    'Event Handlers
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        ticTacToeCOM.SendI2CEnable(0)
        ConstantReadTimer.Start()
        Reset()
        PictureBox1.Enabled = True
        PictureBox2.Enabled = True
        PictureBox3.Enabled = True
        PictureBox4.Enabled = True
        PictureBox5.Enabled = True
        PictureBox6.Enabled = True
        PictureBox7.Enabled = True
        PictureBox8.Enabled = True
        PictureBox9.Enabled = True

        StartButton.Enabled = False
        ResetButton.Enabled = True
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        'MakeTicTacToeHit(1)
        ClickTarget(1)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        'MakeTicTacToeHit(2)
        ClickTarget(2)
        'PictureBox2.Enabled = False
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        'MakeTicTacToeHit(3)
        ClickTarget(3)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        'MakeTicTacToeHit(4)
        ClickTarget(4)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        'MakeTicTacToeHit(5)
        ClickTarget(5)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'MakeTicTacToeHit(6)
        ClickTarget(6)
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        'MakeTicTacToeHit(7)
        ClickTarget(7)
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        'MakeTicTacToeHit(8)
        ClickTarget(8)
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        'MakeTicTacToeHit(9)
        ClickTarget(9)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        ConstantReadTimer.Stop()
        ticTacToeCOM.SendI2CDisable(0)
        Reset()
    End Sub

    Dim timercounts As Integer = 0
    Private Sub ConstantReadTimer_Tick(sender As Object, e As EventArgs) Handles ConstantReadTimer.Tick
        Dim exitLoop As Boolean = False

        Do Until exitLoop = True
            timercounts = timercounts + 1
            Select Case timercounts
                Case 1
                    If SkipReadTarget(1) = False Then
                        exitLoop = True
                    End If
                Case 2
                    If SkipReadTarget(2) = False Then
                        exitLoop = True
                    End If
                Case 3
                    If SkipReadTarget(3) = False Then
                        exitLoop = True
                    End If
                Case 4
                    If SkipReadTarget(4) = False Then
                        exitLoop = True
                    End If
                Case 5
                    If SkipReadTarget(5) = False Then
                        exitLoop = True
                    End If
                Case 6
                    If SkipReadTarget(6) = False Then
                        exitLoop = True
                    End If
                Case 7
                    If SkipReadTarget(7) = False Then
                        exitLoop = True
                    End If
                Case 8
                    If SkipReadTarget(8) = False Then
                        exitLoop = True
                    End If
                Case 9
                    If SkipReadTarget(9) = True Then
                        timercounts = 0
                    Else
                        exitLoop = True
                    End If
            End Select
        Loop

        TimerTestRadioButton.Checked = True

        ticTacToeCOM.SendI2CRead(Convert123To789(timercounts) * 2)

        If timercounts = 9 Then
            timercounts = 0
        End If

        'Select Case timercounts
        ' Case 1
        ' ticTacToeCOM.SendI2CRead(14)
        ' TimerTestRadioButton.Checked = False
        ' Case 2
        ' ticTacToeCOM.SendI2CRead(16)
        ' TimerTestRadioButton.Checked = True
        ' Case 3
        ' ticTacToeCOM.SendI2CRead(18)
        ' TimerTestRadioButton.Checked = False
        ' Case 4
        ' ticTacToeCOM.SendI2CRead(24)
        ' TimerTestRadioButton.Checked = True
        ' Case 5
        ' ticTacToeCOM.SendI2CRead(26)
        ' TimerTestRadioButton.Checked = False
        ' Case 6
        ' ticTacToeCOM.SendI2CRead(28)
        ' TimerTestRadioButton.Checked = True
        ' Case 7
        ' ticTacToeCOM.SendI2CRead(34)
        ' TimerTestRadioButton.Checked = False
        ' Case 8
        ' ticTacToeCOM.SendI2CRead(36)
        ' TimerTestRadioButton.Checked = True
        ' Case 9
        ' ticTacToeCOM.SendI2CRead(38)
        ' TimerTestRadioButton.Checked = False
        ' timercounts = 0
        ' End Select
    End Sub

    Private Sub WrongPlayerTimer_Tick(sender As Object, e As EventArgs) Handles WrongPlayerTimer.Tick
        ticTacToeCOM.SendI2CEnable(wrongTurnTarget)
        WrongPlayerTimer.Stop()
        ConstantReadTimer.Start()
    End Sub

    Private Sub LightUpTimer_Tick(sender As Object, e As EventArgs) Handles LightUpTimer.Tick
        ticTacToeCOM.SendI2CColorChange(Convert123To789(lightTarget) * 2, 1)
        LightUpTimer.Stop()
        ConstantReadTimer.Start()
    End Sub
    Private Sub TicTacToeGame_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim newfont As Double
        newfont = Me.Width * fontMult
        PlayerTurnTextBox.Font = New Font("Microsoft Sans Serif", newfont)
        TurnsPassedTextBox.Font = New Font("Microsoft Sans Serif", newfont)
        Label1.Font = New Font("Microsoft Sans Serif", newfont)
        Label2.Font = New Font("Microsoft Sans Serif", newfont)
        Label3.Font = New Font("Microsoft Sans Serif", newfont)
    End Sub

    Dim fontMult As Double = 1
    Dim OGfont As Double = 12
    Private Sub TicTacToeGame_Load(sender As Object, e As EventArgs) Handles Me.Load
        fontMult = (12 / 818)
        Me.WindowState = 2
    End Sub

    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Dim GamePickerForm As New GamePicker(ticTacToeCOM)

        GamePickerForm.Show()
        Me.Hide()
    End Sub
End Class