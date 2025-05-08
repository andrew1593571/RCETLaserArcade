Option Strict On
Option Explicit On

'Laser Arcade Project
'Andrew Keller
'Spring 2025
'https://github.com/AlexWheelock/Laser-Arcade-Project.git

Public Class AboutForm
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.Close()
    End Sub

    Private Sub GithubLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GithubLinkLabel.LinkClicked
        Dim githubAddress As String = "https://github.com/AlexWheelock/Laser-Arcade-Project.git"

        Process.Start(githubAddress)
    End Sub
End Class