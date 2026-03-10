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

    End Sub

    Private Sub Player1PictureBox_Click(sender As Object, e As EventArgs) Handles Player1PictureBox.Click
        Dim result As DialogResult = ColorDialog1.ShowDialog()
        Player1.red = ColorDialog1.Color.R
        Player1.green = ColorDialog1.Color.G
        Player1.blue = ColorDialog1.Color.B
        Player1PictureBox.BackColor = ColorDialog1.Color
        'UARTController.sendupdateplayercolor(Player1.playernumber,Player1.green,Player1.red,Player1.blue)
    End Sub

    Private Sub Player2PictureBox_Click(sender As Object, e As EventArgs) Handles Player2PictureBox.Click
        Dim result As DialogResult = ColorDialog1.ShowDialog()
        Player2.red = ColorDialog1.Color.R
        Player2.green = ColorDialog1.Color.G
        Player2.blue = ColorDialog1.Color.B
        Player2PictureBox.BackColor = ColorDialog1.Color
        'UARTController.sendupdateplayercolor(Player1.playernumber,Player1.green,Player1.red,Player1.blue)
    End Sub

    Private Sub Player3PictureBox_Click(sender As Object, e As EventArgs) Handles Player3PictureBox.Click
        Dim result As DialogResult = ColorDialog1.ShowDialog()
        Player3.red = ColorDialog1.Color.R
        Player3.green = ColorDialog1.Color.G
        Player3.blue = ColorDialog1.Color.B
        Player3PictureBox.BackColor = ColorDialog1.Color
        'UARTController.sendupdateplayercolor(Player1.playernumber,Player1.green,Player1.red,Player1.blue)
    End Sub

    'Private Sub Player1PictureBox_Click(sender As Object, e As EventArgs) Handles Player1PictureBox.Click
    '    Dim result As DialogResult = ColorDialog1.ShowDialog()
    '    Player1.red = ColorDialog1.Color.R
    '    Player1.green = ColorDialog1.Color.G
    '    Player1.blue = ColorDialog1.Color.B
    '    Player1PictureBox.BackColor = ColorDialog1.Color
    '    'UARTController.sendupdateplayercolor(Player1.playernumber,Player1.green,Player1.red,Player1.blue)
    'End Sub

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
End Class