Imports System.Reflection.Emit

Public Class LightningGameForm
    'Public UARTController As New UARTController
    'UARTController.sendupdateplayercolor(playernumber,g,r,b)

    Public Player1 As New Player()
    Public Player2 As New Player()
    Public Player3 As New Player()
    Public Player4 As New Player()

    Private Sub LightningGameForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Player1.playerNumber = 1
        Player2.playerNumber = 2
        Player3.playerNumber = 3
        Player4.playerNumber = 4

        Call CenterToScreen()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        P1TextBox.BackColor = Color.FromArgb(145, 145, 145)
        P2TextBox.BackColor = Color.FromArgb(145, 145, 145)
        P3TextBox.BackColor = Color.FromArgb(145, 145, 145)
        P4TextBox.BackColor = Color.FromArgb(145, 145, 145)

    End Sub

    'Private Sub Player1PictureBox_Click(sender As Object, e As EventArgs) Handles Player1PictureBox.Click
    '    Dim result As DialogResult = ColorDialog1.ShowDialog()
    '    Player1.red = ColorDialog1.Color.R
    '    Player1.green = ColorDialog1.Color.G
    '    Player1.blue = ColorDialog1.Color.B
    '    Player1PictureBox.BackColor = ColorDialog1.Color
    '    'UARTController.sendupdateplayercolor(Player1.playernumber,Player1.green,Player1.red,Player1.blue)
    'End Sub

    Private Sub Player2PictureBox_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = ColorDialog1.ShowDialog()
        Player2.red = ColorDialog1.Color.R
        Player2.green = ColorDialog1.Color.G
        Player2.blue = ColorDialog1.Color.B
        Player2PictureBox.BackColor = ColorDialog1.Color
        'UARTController.sendupdateplayercolor(Player1.playernumber,Player1.green,Player1.red,Player1.blue)
    End Sub

    Private Sub Player3PictureBox_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = ColorDialog1.ShowDialog()
        Player3.red = ColorDialog1.Color.R
        Player3.green = ColorDialog1.Color.G
        Player3.blue = ColorDialog1.Color.B
        Player3PictureBox.BackColor = ColorDialog1.Color
        'UARTController.sendupdateplayercolor(Player1.playernumber,Player1.green,Player1.red,Player1.blue)
    End Sub

    Private Sub Player4PictureBox_Click(sender As Object, e As EventArgs)
        Dim result As DialogResult = ColorDialog1.ShowDialog()
        Player4.red = ColorDialog1.Color.R
        Player4.green = ColorDialog1.Color.G
        Player4.blue = ColorDialog1.Color.B
        Player4PictureBox.BackColor = ColorDialog1.Color
        'UARTController.sendupdateplayercolor(Player1.playernumber,Player1.green,Player1.red,Player1.blue)
    End Sub

    Private Sub Player1PictureBox_Resize(sender As Object, e As EventArgs) Handles Player1PictureBox.Resize
        Dim offset1 As New Point(P1TextBox.Location.X * 1.206, Player1PictureBox.Height * 1.62345)
        Dim offset2 As New Point(P2TextBox.Location.X, Player2PictureBox.Height * 1.62345)
        Dim offset3 As New Point(P3TextBox.Location.X, Player3PictureBox.Height * 1.62345)
        Dim offset4 As New Point(P4TextBox.Location.X, Player4PictureBox.Height * 1.62345)
        P1TextBox.Location = offset1
        P2TextBox.Location = offset2
        P3TextBox.Location = offset3
        P4TextBox.Location = offset4

        P1TextBox.Width = (P1TextBox.Width * 0.05)
        P2TextBox.Width = (P2TextBox.Width * 0.05)
        P3TextBox.Width = (P3TextBox.Width * 0.05)
        P4TextBox.Width = (P4TextBox.Width * 0.05)

    End Sub

    Private Function SeperateColorFromARB(Value As String) As Double
        Dim num As String()
        num = Split(Value, ",")
        If num(0) = "" Then
            Return 0
        Else
            Dim Number As Double = CDbl(num(0))
            Return Number
        End If
    End Function

    Sub ChangePlayerColors()
        Dim hexCode1 As Byte = &H0
        Dim hexCode2 As Byte = &H0
        Dim hexCode3 As Byte = &H0
        Player1PictureBox.BackColor = System.Drawing.ColorTranslator.FromHtml(hexCode1 & hexCode2 & hexCode1)
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub Player4PictureBox_Click_1(sender As Object, e As EventArgs) Handles Player4PictureBox.Click

    End Sub
End Class