Option Strict On
Option Explicit On

'Andrew Keller
'RCET3371
'Spring 2025
'Game Of War
'https://github.com/andrew1593571/RCET3371.git

Public Class AboutForm
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.Close()
    End Sub

    Private Sub GithubLinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles GithubLinkLabel.LinkClicked
        Dim githubAddress As String = "https://github.com/AlexWheelock/Laser-Arcade-Project.git"

        Process.Start(githubAddress)
    End Sub
End Class