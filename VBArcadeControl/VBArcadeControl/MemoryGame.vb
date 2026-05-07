Imports Microsoft.VisualBasic.ApplicationServices

Public Class MemoryGame
    Private WithEvents memoryCOM As UARTController
    Public Sub New(memoryTarget As UARTController)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        memoryCOM = memoryTarget
    End Sub

    Private Sub memoryCOM_TargetHit(address As Byte, player As Byte) Handles memoryCOM.TargetHit
        If Me.InvokeRequired Then
            Me.Invoke(Sub() ReadmemoryTarget(address, player))
        Else
            ReadmemoryTarget(address, player)
        End If
    End Sub

    Private Sub memoryCOM_ParseFailed(reason As String) Handles memoryCOM.ParseFailed
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateParseFailedUI(reason))
        Else
            UpdateParseFailedUI(reason)
        End If
    End Sub
    Private Sub UpdateParseFailedUI(reason As String)
        'ResultLabel.Text = "Parse Failed: " & reason
    End Sub
    Private Sub memoryCOM_CommandAcknowledged(address As Byte) Handles memoryCOM.CommandAcknowledged
        If Me.InvokeRequired Then
            'Me.Invoke(Sub() ResultLabel.Text = "Command acknowledged by target " & (address \ 2).ToString())
        Else
            'ResultLabel.Text = "Command acknowledged by target " & address.ToString()
        End If
    End Sub

    Sub ReadmemoryTarget(address As Byte, player As Byte)
        Dim validPlayerTurn As Integer

        If PlayerTurnTextBox.Text = "1" Then
            validPlayerTurn = 1
        Else
            validPlayerTurn = 2
        End If

        If player = validPlayerTurn Then
            CheckMemoryHit(address \ 2)
        Else
            'ConstantReadTimer.Stop()
            'wrongTurnTarget = address
            'WrongPlayerTimer.Start()
        End If
        'MsgBox("We hit the blaster")
    End Sub

    Private _deck As New Stack

    Sub EnableMemoryTargets()
        PictureBox1.Enabled = True
        PictureBox2.Enabled = True
        PictureBox3.Enabled = True
        PictureBox4.Enabled = True
        PictureBox5.Enabled = True
        PictureBox6.Enabled = True
        PictureBox7.Enabled = True
        PictureBox8.Enabled = True
        PictureBox9.Enabled = True
        PictureBox10.Enabled = True
        PictureBox11.Enabled = True
        PictureBox12.Enabled = True
        PictureBox13.Enabled = True
        PictureBox14.Enabled = True
        PictureBox15.Enabled = True
        PictureBox16.Enabled = True
        PictureBox17.Enabled = True
        PictureBox18.Enabled = True
        PictureBox19.Enabled = True
        PictureBox20.Enabled = True
        PictureBox21.Enabled = True
        PictureBox22.Enabled = True
        PictureBox23.Enabled = True
        PictureBox24.Enabled = True
        PictureBox25.Enabled = True

        'memoryCOM.SendI2CEnable(0)
    End Sub

    Sub DisableMemoryTargets()
        PictureBox1.Enabled = False
        PictureBox2.Enabled = False
        PictureBox3.Enabled = False
        PictureBox4.Enabled = False
        PictureBox5.Enabled = False
        PictureBox6.Enabled = False
        PictureBox7.Enabled = False
        PictureBox8.Enabled = False
        PictureBox9.Enabled = False
        PictureBox10.Enabled = False
        PictureBox11.Enabled = False
        PictureBox12.Enabled = False
        PictureBox13.Enabled = False
        PictureBox14.Enabled = False
        PictureBox15.Enabled = False
        PictureBox16.Enabled = False
        PictureBox17.Enabled = False
        PictureBox18.Enabled = False
        PictureBox19.Enabled = False
        PictureBox20.Enabled = False
        PictureBox21.Enabled = False
        PictureBox22.Enabled = False
        PictureBox23.Enabled = False
        PictureBox24.Enabled = False
        PictureBox25.Enabled = False

        'memoryCOM.SendI2CDisable(0)
    End Sub

    Sub ResetGame()
        DisableMemoryTargets()
        'TurnsTextBox.Text = "0"
    End Sub

    Sub HideTargets()
        PictureBox1.Image = My.Resources.NoIcon
        PictureBox2.Image = My.Resources.NoIcon
        PictureBox3.Image = My.Resources.NoIcon
        PictureBox4.Image = My.Resources.NoIcon
        PictureBox5.Image = My.Resources.NoIcon
        PictureBox6.Image = My.Resources.NoIcon
        PictureBox7.Image = My.Resources.NoIcon
        PictureBox8.Image = My.Resources.NoIcon
        PictureBox9.Image = My.Resources.NoIcon
        PictureBox10.Image = My.Resources.NoIcon
        PictureBox11.Image = My.Resources.NoIcon
        PictureBox12.Image = My.Resources.NoIcon
        PictureBox13.Image = My.Resources.NoIcon
        PictureBox14.Image = My.Resources.NoIcon
        PictureBox15.Image = My.Resources.NoIcon
        PictureBox16.Image = My.Resources.NoIcon
        PictureBox17.Image = My.Resources.NoIcon
        PictureBox18.Image = My.Resources.NoIcon
        PictureBox19.Image = My.Resources.NoIcon
        PictureBox20.Image = My.Resources.NoIcon
        PictureBox21.Image = My.Resources.NoIcon
        PictureBox22.Image = My.Resources.NoIcon
        PictureBox23.Image = My.Resources.NoIcon
        PictureBox24.Image = My.Resources.NoIcon
        PictureBox25.Image = My.Resources.NoIcon
    End Sub

    Private Function GetRandomInRange(max As Integer, Optional min As Integer = 1)
        Randomize()
        Return System.Math.Floor(Rnd() * max) + min
    End Function

    Dim MemoryTargets(25) As Integer

    Sub GenerateTarget()
        For i = 1 To 25
            Dim OK As Boolean = False     ' OK becomes true when a unique number has been generated
            Do
                Dim num As Integer = GetRandomInRange(25)
                If MemoryTargets.Contains(num) Then
                    OK = False         ' we'll try again shortly
                Else
                    OK = True          ' this round is complete -- found a unique number
                    MemoryTargets(i) = num      ' add the generated number to the list
                End If
            Loop Until OK     ' in other words, loop until we've found a unique number
        Next

    End Sub

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
            Case 10
                PictureBox10.Image = TurnPictureBox.Image
            Case 11
                PictureBox11.Image = TurnPictureBox.Image
            Case 12
                PictureBox12.Image = TurnPictureBox.Image
            Case 13
                PictureBox13.Image = TurnPictureBox.Image
            Case 14
                PictureBox14.Image = TurnPictureBox.Image
            Case 15
                PictureBox15.Image = TurnPictureBox.Image
            Case 16
                PictureBox16.Image = TurnPictureBox.Image
            Case 17
                PictureBox17.Image = TurnPictureBox.Image
            Case 18
                PictureBox18.Image = TurnPictureBox.Image
            Case 19
                PictureBox19.Image = TurnPictureBox.Image
            Case 20
                PictureBox20.Image = TurnPictureBox.Image
            Case 21
                PictureBox21.Image = TurnPictureBox.Image
            Case 22
                PictureBox22.Image = TurnPictureBox.Image
            Case 23
                PictureBox23.Image = TurnPictureBox.Image
            Case 24
                PictureBox24.Image = TurnPictureBox.Image
            Case 25
                PictureBox25.Image = TurnPictureBox.Image
        End Select
    End Sub

    Sub DisplayMemoryTarget(Order As Integer)
        Dim display As Integer
        display = MemoryTargets(Order)
        PictureBoxPicker(display)
        TimerShort.Start()
    End Sub

    Sub CheckMemoryHit(target As Integer)
        TargetsHitTextBox.Text = CInt(TargetsHitTextBox.Text) + 1
        If MemoryTargets(CInt(TargetsHitTextBox.Text)) = target Then
            TimerThink.Stop()
            TargetsLeftTextBox.Text = CInt(TargetsLeftTextBox.Text) - 1
            PictureBoxPicker(target)
            If TargetsLeftTextBox.Text = "0" Then
                If TurnsTextBox.Text = 25 Then
                    DisableMemoryTargets()
                    MsgBox("YAY YOU WON")
                Else
                    DisableMemoryTargets()
                    TurnsTextBox.Text = CInt(TurnsTextBox.Text) + 1
                    TargetsLeftTextBox.Text = "0"
                    TargetsHitTextBox.Text = "0"
                    TimerRoundPass.Start()
                End If

            Else
                TimerThink.Start()
            End If
        Else
            MsgBox("HA! Player " + PlayerTurnTextBox.Text + " guessed incorrectly")
            TimerThink.Stop()
        End If
    End Sub


    'Event Handlers-----------------------------------------------------------------------------------------------------
    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        StartButton.Enabled = False
        'ResetGame()
        GenerateTarget()
        TurnsTextBox.Text = CInt(TurnsTextBox.Text) + 1
        TargetsLeftTextBox.Text = 0
        TimerShort.Start()
        'EnableMemoryTargets()
        StatusTextBox.Text = "Generating Pattern"
    End Sub

    Private Sub TimerShort_Tick(sender As Object, e As EventArgs) Handles TimerShort.Tick
        If TargetsLeftTextBox.Text = TurnsTextBox.Text Then
            TimerShort.Stop()
            TimerLong.Start()
            StatusTextBox.Text = "Remember the Pattern"
        Else
            TargetsLeftTextBox.Text = CInt(TargetsLeftTextBox.Text) + 1
            DisplayMemoryTarget(CInt(TargetsLeftTextBox.Text))
            StatusTextBox.Text = "Adding to Pattern"
        End If
    End Sub

    Private Sub TimerLong_Tick(sender As Object, e As EventArgs) Handles TimerLong.Tick
        TimerLong.Stop()
        HideTargets()
        EnableMemoryTargets()
        TimerThink.Start()
        StatusTextBox.Text = "Shoot the Pattern!"
    End Sub

    Private Sub TimerThink_Tick(sender As Object, e As EventArgs) Handles TimerThink.Tick
        MsgBox("HA! Player " + PlayerTurnTextBox.Text + " took too long")
        TimerThink.Stop()
        StatusTextBox.Text = "Ready (lost)"
    End Sub
    Private Sub TimerRoundPass_Tick(sender As Object, e As EventArgs) Handles TimerRoundPass.Tick
        HideTargets()

        If PlayerTurnTextBox.Text = "1" Then
            PlayerTurnTextBox.Text = "2"
            TurnPictureBox.Image = My.Resources.PIcon
        Else
            PlayerTurnTextBox.Text = "1"
            TurnPictureBox.Image = My.Resources.BIcon
        End If

        TimerShort.Start()
        TimerRoundPass.Stop()
        StatusTextBox.Text = "Passed Round " + TurnsTextBox.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click '
        DisableMemoryTargets()
        TimerLong.Stop()
        TimerThink.Stop()
        TurnsTextBox.Text = CInt(TurnsTextBox.Text) + 1
        TargetsLeftTextBox.Text = 0
        TimerShort.Start()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        CheckMemoryHit(1)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        CheckMemoryHit(2)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        CheckMemoryHit(3)
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        CheckMemoryHit(4)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        CheckMemoryHit(5)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        CheckMemoryHit(6)
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        CheckMemoryHit(7)
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        CheckMemoryHit(8)
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        CheckMemoryHit(9)
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        CheckMemoryHit(10)
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        CheckMemoryHit(11)
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        CheckMemoryHit(12)
    End Sub

    Private Sub PictureBox13_Click(sender As Object, e As EventArgs) Handles PictureBox13.Click
        CheckMemoryHit(13)
    End Sub

    Private Sub PictureBox14_Click(sender As Object, e As EventArgs) Handles PictureBox14.Click
        CheckMemoryHit(14)
    End Sub

    Private Sub PictureBox15_Click(sender As Object, e As EventArgs) Handles PictureBox15.Click
        CheckMemoryHit(15)
    End Sub

    Private Sub PictureBox16_Click(sender As Object, e As EventArgs) Handles PictureBox16.Click
        CheckMemoryHit(16)
    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click
        CheckMemoryHit(17)
    End Sub

    Private Sub PictureBox18_Click(sender As Object, e As EventArgs) Handles PictureBox18.Click
        CheckMemoryHit(18)
    End Sub

    Private Sub PictureBox19_Click(sender As Object, e As EventArgs) Handles PictureBox19.Click
        CheckMemoryHit(19)
    End Sub

    Private Sub PictureBox20_Click(sender As Object, e As EventArgs) Handles PictureBox20.Click
        CheckMemoryHit(20)
    End Sub

    Private Sub PictureBox21_Click(sender As Object, e As EventArgs) Handles PictureBox21.Click
        CheckMemoryHit(21)
    End Sub

    Private Sub PictureBox22_Click(sender As Object, e As EventArgs) Handles PictureBox22.Click
        CheckMemoryHit(22)
    End Sub

    Private Sub PictureBox23_Click(sender As Object, e As EventArgs) Handles PictureBox23.Click
        CheckMemoryHit(23)
    End Sub

    Private Sub PictureBox24_Click(sender As Object, e As EventArgs) Handles PictureBox24.Click
        CheckMemoryHit(24)
    End Sub

    Private Sub PictureBox25_Click(sender As Object, e As EventArgs) Handles PictureBox25.Click
        CheckMemoryHit(25)
    End Sub

    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click

    End Sub
End Class