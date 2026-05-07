Public Class GamePicker

    Private WithEvents gameCOM As UARTController
    Private WithEvents gameSound As GameSounds
    Public Sub New(game As UARTController)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gameCOM = game
    End Sub

    Public Sub New(gameSounds As GameSounds)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        gameSound = gameSounds
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim testTargetForm As New TestTargetStatus(gameCOM)
        testTargetForm.Show()
        Me.Hide()

    End Sub

    Private Sub TicTacToeButton_Click(sender As Object, e As EventArgs) Handles TicTacToeButton.Click
        Dim ticTacToeTargetForm As New TicTacToeGame(gameCOM)
        ticTacToeTargetForm.Show()
        Me.Hide()
    End Sub

    Private Sub MemoryButton_Click(sender As Object, e As EventArgs) Handles MemoryButton.Click
        Dim memoryTargetForm As New MemoryGame(gameCOM)
        memoryTargetForm.Show()
        Me.Hide()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub PictureBoxBreakTheTargets_Click(sender As Object, e As EventArgs) Handles PictureBoxBreakTheTargets.Click
        gameSound.SelectGameSound(1)
        Dim BreakTheTargetForm As New BreakTheTargetGameForm(gameCOM)
        BreakTheTargetForm.Show()
        Me.Hide()
    End Sub

    Private Sub GamePicker_Load(sender As Object, e As EventArgs) Handles Me.Load
        gameCOM.SendI2CDisable(0)
    End Sub
End Class