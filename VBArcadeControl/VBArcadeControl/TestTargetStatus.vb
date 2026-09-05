Imports System.IO.Ports
Imports System.Security.Cryptography

'Laser Arcade Project
'Angel Nava
'Spring 2026
Public Class TestTargetStatus
    Private WithEvents testCOM As UARTController
    Public Sub New(testTarget As UARTController)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        testCOM = testTarget
    End Sub

    Function ConvertToDecimal(value As String) As Decimal
        Dim result As Decimal

        If value = "" Then
            Return -2
        End If

        If DecimalRadioButton.Checked = True Then
            If IsNumeric(value) = True Then
                result = CDec(value)
            Else
                result = -1
            End If
        ElseIf HexRadioButton.Checked = True Then
            Dim hexVal As Integer
            Try
                hexVal = Convert.ToInt32(value, 16)
                result = hexVal
            Catch ex As Exception
                result = -3
            End Try
        ElseIf AsciiRadioButton.Checked = True Then
            Try
                result = Asc(value)
            Catch ex As Exception
                result = -4
            End Try
        Else
            result = CDec(value)
        End If

        Return result
    End Function

    Function DisplayNumber(number As String) As String
        Dim result As String
        Dim hexVal As String
        hexVal = Hex(number)

        If DecimalRadioButton.Checked = True Then
            result = number
        ElseIf HexRadioButton.Checked = True Then
            result = hexVal
        ElseIf AsciiRadioButton.Checked = True Then
            result = Chr(CDec(number))
        Else
            result = number
        End If

        Return result
    End Function


    '----------------------------------------------------------------------------------------------------
    Private Sub ReadButton_Click(sender As Object, e As EventArgs) Handles ReadButton.Click
        Dim writableAddress As Integer
        writableAddress = CInt(AddressTextBox.Text) * 2
        testCOM.SendI2CRead(CByte(writableAddress))
    End Sub

    Private Sub WriteButton_Click(sender As Object, e As EventArgs) Handles WriteButton.Click
        Dim writableAddress As Integer
        writableAddress = CInt(AddressTextBox.Text) * 2
        testCOM.SendI2CWrite(CByte(writableAddress), CByte(WriteTextBox.Text))
    End Sub

    Private Sub EnableButton_Click(sender As Object, e As EventArgs) Handles EnableButton.Click
        Dim writableAddress As Integer
        writableAddress = CInt(AddressTextBox.Text) * 2
        testCOM.SendI2CEnable(CByte(writableAddress))
    End Sub

    Private Sub DisableButton_Click(sender As Object, e As EventArgs) Handles DisableButton.Click
        Dim writableAddress As Integer
        writableAddress = CInt(AddressTextBox.Text) * 2
        testCOM.SendI2CDisable(CByte(writableAddress))
    End Sub



    ' Handles the TargetHit event raised by UARTController
    ' This fires on a background thread, so we MUST use Me.Invoke()
    Private Sub testCOM_TargetHit(address As Byte, player As Byte) Handles testCOM.TargetHit
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateTargetHitUI(address, player))
        Else
            UpdateTargetHitUI(address, player)
        End If
    End Sub

    ' Safe to touch UI controls here — always runs on the UI thread+
    Private Sub UpdateTargetHitUI(address As Byte, player As Byte)
        ResultLabel.Text = "Target " & (address \ 2).ToString() & " hit by Player " & player.ToString()
    End Sub


    ' Handles the ParseFailed event raised by UARTController
    Private Sub testCOM_ParseFailed(reason As String) Handles testCOM.ParseFailed
        If Me.InvokeRequired Then
            Me.Invoke(Sub() UpdateParseFailedUI(reason))
        Else
            UpdateParseFailedUI(reason)
        End If
    End Sub

    Private Sub UpdateParseFailedUI(reason As String)
        ResultLabel.Text = "Parse Failed: " & reason
    End Sub
    Private Sub testCOM_CommandAcknowledged(address As Byte) Handles testCOM.CommandAcknowledged
        If Me.InvokeRequired Then
            Me.Invoke(Sub() ResultLabel.Text = "Command acknowledged by target " & (address \ 2).ToString())
        Else
            ResultLabel.Text = "Command acknowledged by target " & address.ToString()
        End If
    End Sub

    Private Sub ColorChangeButton_Click(sender As Object, e As EventArgs) Handles ColorChangeButton.Click
        Dim writableAddress As Integer
        writableAddress = CInt(AddressTextBox.Text) * 2
        testCOM.SendI2CColorChange(CByte(writableAddress), 1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OverwriteButton.Click
        Dim writableAddress As Integer
        writableAddress = CInt(AddressTextBox.Text) * 2
        testCOM.SendI2COverwrite(CByte(writableAddress), CByte(CInt(OverwriteTextBox.Text)))
    End Sub

    Private Sub ReturnButton_Click(sender As Object, e As EventArgs) Handles ReturnButton.Click
        Dim GamePickerForm As New GamePicker(testCOM)

        GamePickerForm.Show()
        Me.Hide()
    End Sub
End Class