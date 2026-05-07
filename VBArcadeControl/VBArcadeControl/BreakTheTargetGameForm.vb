Imports System.Net.Sockets

Public Class BreakTheTargetGameForm
    Private WithEvents BreakTheTargetsCOM As UARTController
    Private WithEvents BreakTheTargetsSound As GameSounds
    Public Sub New(BreakTheTargetsTarget As UARTController)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        BreakTheTargetsCOM = BreakTheTargetsTarget
    End Sub
    Public Sub New(BreakTheTargetsSounds As GameSounds)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        BreakTheTargetsSound = BreakTheTargetsSounds
    End Sub

    'When Target gets hit, Read Targets
    Private Sub BreakTheTargetsCOM_TargetHit(address As Byte, player As Byte) Handles BreakTheTargetsCOM.TargetHit
        If player > 0 Then
            If Me.InvokeRequired Then
                Me.Invoke(Sub() MakeBreakTheTargetHit(address, player))
            Else
                MakeBreakTheTargetHit(address, player)
            End If
        End If
    End Sub

    Private Sub BreakTheTargetsCOM_ParseFailed(reason As String) Handles BreakTheTargetsCOM.ParseFailed
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateParseFailedUI(reason))
        Else
            UpdateParseFailedUI(reason)
        End If
    End Sub

    Dim GameState As Boolean

    Private Sub UpdateParseFailedUI(reason As String)
        ConstantReadTimer.Stop()
        If GameState = True Then
            ShootOutTimer.Start()
        End If

        BreakTheTargetsCOM.SendI2CRead(CInt(TargetTextBox.Text) * 2)
    End Sub

    Sub MakeBreakTheTargetHit(target As Integer, Player As Integer)
        ConstantReadTimer.Stop()
        ShootOutTimer.Stop()
        BreakTheTargetsSound.HitSound()

        Dim points As Integer
        points = CInt(PointsTextBox.Text) + 1
        PointsTextBox.Text = points

        If ShootOutTimer.Interval > 900 Then
            ShootOutTimer.Interval = ShootOutTimer.Interval - 100
        End If
        HideTargets()
        TargetLightUp()
    End Sub

    Sub TargetLightUp()
        Dim currentTarget As Integer
        currentTarget = GetRandomInRange(25, 1)
        PictureBoxPicker(currentTarget)
        BreakTheTargetsCOM.SendI2CEnable(currentTarget * 2)
        TargetTextBox.Text = currentTarget
        ConstantReadTimer.Start()
        ShootOutTimer.Start()
    End Sub


    'Picks the Picturebox based on number
    Sub PictureBoxPicker(pictureBox As Integer)
        Select Case pictureBox
            Case 1
                PictureBox1.Image = My.Resources.Target
            Case 2
                PictureBox2.Image = My.Resources.Target
            Case 3
                PictureBox3.Image = My.Resources.Target
            Case 4
                PictureBox4.Image = My.Resources.Target
            Case 5
                PictureBox5.Image = My.Resources.Target
            Case 6
                PictureBox6.Image = My.Resources.Target
            Case 7
                PictureBox7.Image = My.Resources.Target
            Case 8
                PictureBox8.Image = My.Resources.Target
            Case 9
                PictureBox9.Image = My.Resources.Target
            Case 10
                PictureBox10.Image = My.Resources.Target
            Case 11
                PictureBox11.Image = My.Resources.Target
            Case 12
                PictureBox12.Image = My.Resources.Target
            Case 13
                PictureBox13.Image = My.Resources.Target
            Case 14
                PictureBox14.Image = My.Resources.Target
            Case 15
                PictureBox15.Image = My.Resources.Target
            Case 16
                PictureBox16.Image = My.Resources.Target
            Case 17
                PictureBox17.Image = My.Resources.Target
            Case 18
                PictureBox18.Image = My.Resources.Target
            Case 19
                PictureBox19.Image = My.Resources.Target
            Case 20
                PictureBox20.Image = My.Resources.Target
            Case 21
                PictureBox21.Image = My.Resources.Target
            Case 22
                PictureBox22.Image = My.Resources.Target
            Case 23
                PictureBox23.Image = My.Resources.Target
            Case 24
                PictureBox24.Image = My.Resources.Target
            Case 25
                PictureBox25.Image = My.Resources.Target
        End Select
    End Sub

    Sub HideTargets()
        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        PictureBox5.Image = Nothing
        PictureBox6.Image = Nothing
        PictureBox7.Image = Nothing
        PictureBox8.Image = Nothing
        PictureBox9.Image = Nothing
        PictureBox10.Image = Nothing
        PictureBox11.Image = Nothing
        PictureBox12.Image = Nothing
        PictureBox13.Image = Nothing
        PictureBox14.Image = Nothing
        PictureBox15.Image = Nothing
        PictureBox16.Image = Nothing
        PictureBox17.Image = Nothing
        PictureBox18.Image = Nothing
        PictureBox19.Image = Nothing
        PictureBox20.Image = Nothing
        PictureBox21.Image = Nothing
        PictureBox22.Image = Nothing
        PictureBox23.Image = Nothing
        PictureBox24.Image = Nothing
        PictureBox25.Image = Nothing
    End Sub

    Sub Reset()
        'BreakTheTargetsCOM.SendI2CDisable(0)
        GameState = False
        ConstantReadTimer.Stop()
        ShootOutTimer.Stop()
        HideTargets()
        TargetTextBox.Text = "0"
        PointsTextBox.Text = "0"
        TurnPictureBox.Image = My.Resources.GIcon
        ShootOutTimer.Interval = 5000
    End Sub


    '-------------------------------------------------------------------------------------------------

    Dim fontMult As Double = 1
    Dim OGfont As Double = 12
    Private Sub BreakTheTargetGameForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        fontMult = (12 / 818)
        Me.WindowState = 2
    End Sub
    Private Sub BreakTheTargetsGame_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim newfont As Double
        newfont = Me.Width * fontMult
        PlayerTurnTextBox.Font = New Font("Microsoft Sans Serif", newfont)
        PointsTextBox.Font = New Font("Microsoft Sans Serif", newfont)
        TargetTextBox.Font = New Font("Microsoft Sans Serif", newfont)
        Label1.Font = New Font("Microsoft Sans Serif", newfont)
        Label2.Font = New Font("Microsoft Sans Serif", newfont)
        Label3.Font = New Font("Microsoft Sans Serif", newfont)
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        BreakTheTargetsSound.StartGameSound()
        Reset()
        GameState = True
        TargetLightUp()
        StartButton.Enabled = False
        ShootOutTimer.Enabled = False
    End Sub
    Private Function GetRandomInRange(max As Integer, Optional min As Integer = 1)
        Randomize()
        Return System.Math.Floor(Rnd() * max) + min
    End Function

    Private Sub ConstantReadTimer_Tick(sender As Object, e As EventArgs) Handles ConstantReadTimer.Tick
        BreakTheTargetsCOM.SendI2CRead(CInt(TargetTextBox.Text) * 2)
    End Sub

    Private Sub ShootOutTimer_Tick(sender As Object, e As EventArgs) Handles ShootOutTimer.Tick
        ShootOutTimer.Stop()
        ConstantReadTimer.Stop()
        TurnPictureBox.Image = My.Resources.GIconLose
        BreakTheTargetsSound.LoseSound()
        BreakTheTargetsCOM.SendI2CDisable(0)
        GameState = False
        MsgBox("you lose")
        StartButton.Enabled = True
        ShootOutTimer.Enabled = False
    End Sub

    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Dim GamePickerForm As New GamePicker(BreakTheTargetsCOM)

        GamePickerForm.Show()
        Me.Hide()
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        Reset()
    End Sub
End Class