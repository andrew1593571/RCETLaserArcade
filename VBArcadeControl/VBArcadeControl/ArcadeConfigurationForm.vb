Option Strict On
Option Explicit On
Option Compare Text
Imports System.ComponentModel
Imports System.Security

Public Class ArcadeConfigurationForm

    Private loaded As Boolean

    ''' <summary>
    ''' If the input textbox contains a number, the integer value is returned, else the user is warned and the last character in the string is removed.
    ''' </summary>
    ''' <param name="inputBox"></param>
    ''' <returns></returns>
    Private Function VerifyNumber(inputBox As TextBox) As Integer
        Dim numberInput As String
        Dim newValue As Integer

        numberInput = inputBox.Text.Replace(" ", "") 'remove spaces

        If Not numberInput = "" Then 'verify the contents are not blank
            If Not "0123456789".Contains(numberInput.Last) Then 'check that the last character entered is a number, remove it if not and warn user
                MsgBox($"{numberInput.Last} is not a number. Please enter a number.")
                numberInput = numberInput.Substring(0, numberInput.Length - 1)

                inputBox.Text = numberInput 'replace the current input text with the new text
                inputBox.Select(numberInput.Length, 0) 'move cursor back to end of input string
                Return Nothing

            Else 'input is a number
                Try
                    newValue = CInt(numberInput) 'convert to integer
                    Return newValue
                Catch ex As Exception
                    MsgBox($"{numberInput} is not a number. Please enter a number.")
                    Return Nothing
                End Try
            End If
        Else
            Return Nothing
        End If
    End Function

    Private Sub UpdatePointsListBox()
        PointsListBox.Items.Clear()

        For i = 0 To (ArcadeControlForm.pointOverrides.Length \ 2) - 1
            PointsListBox.Items.Add($"0x{Hex(ArcadeControlForm.pointOverrides(0, i)).PadLeft(2, "0"c)} - {ArcadeControlForm.pointOverrides(1, i)} Point(s)")
        Next
    End Sub

    Private Sub AddPointsButton_Click(sender As Object, e As EventArgs) Handles AddPointsButton.Click
        If loaded Then
            Dim newIndex As Integer = ArcadeControlForm.pointOverrides.Length \ 2
            Dim newOverrides(1, newIndex) As Integer 'dim a new array one index longer than before


            'move the entered data to the overrides
            If AddressTextBox.Text <> "" And ValueTextBox.Text <> "" Then
                'load current overrides into the new overrides
                For i = 0 To 1
                    For j = 0 To newIndex - 1
                        newOverrides(i, j) = ArcadeControlForm.pointOverrides(i, j)
                    Next
                Next

                'Add the new override to the array
                Try
                    newOverrides(0, newIndex) = Convert.ToInt32(AddressTextBox.Text, 16)
                    newOverrides(1, newIndex) = CInt(ValueTextBox.Text)

                    'load the newOverrides into the main overrides, clear the inputs
                    ArcadeControlForm.pointOverrides = newOverrides
                    AddressTextBox.Text = ""
                    ValueTextBox.Text = ""
                    ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
                Catch ex As Exception
                    MsgBox("I2C address or Points value are not formatted correctly.")
                End Try

                'update the listbox
                UpdatePointsListBox()
            Else
                MsgBox("Please enter an I2C address and Point value")
            End If
        End If
    End Sub

    Private Sub AddressTextBox_TextChanged(sender As Object, e As EventArgs) Handles AddressTextBox.TextChanged
        Dim hexInput As String

        hexInput = AddressTextBox.Text.Replace(" ", "") 'remove spaces
        hexInput = hexInput.ToUpper 'make the entire thing uppercase
        If Not hexInput = "" Then
            'if the input contains characters not used in hex, remove the last character and warn the user
            If Not "ABCDEF0123456789".Contains(hexInput.Last) Then
                MsgBox($"{hexInput.Last} is not used in Hex. Please enter a Hex value.")
                hexInput = hexInput.Substring(0, hexInput.Length - 1)
            End If

            'if the input hex is greater than one byte in length, remove the last character and warn the user
            If hexInput.Length > 2 Then
                MsgBox("The I2C address should not be greater than one byte.")
                hexInput = hexInput.Substring(0, hexInput.Length - 1)
            End If

            AddressTextBox.Text = hexInput 'replace the current input text with the new text
            AddressTextBox.Select(hexInput.Length, 0) 'move cursor back to end of input string
        End If
    End Sub

    Private Sub GameTimeTextBox_TextChanged(sender As Object, e As EventArgs) Handles GameTimeTextBox.TextChanged
        If loaded Then
            If Not VerifyNumber(GameTimeTextBox) = Nothing Then
                ArcadeControlForm.gameTime = VerifyNumber(GameTimeTextBox)
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            End If
        End If
    End Sub

    Private Sub TargetNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles TargetNumberTextBox.TextChanged
        If loaded Then
            If Not VerifyNumber(TargetNumberTextBox) = Nothing Then
                ArcadeControlForm.laserArcade.NumberOfTargets = VerifyNumber(TargetNumberTextBox)
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            End If
        End If
    End Sub

    Private Sub ArcadeConfigurationForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        UpdatePointsListBox()
        GameTimeTextBox.Text = CStr(ArcadeControlForm.gameTime)
        TargetNumberTextBox.Text = CStr(ArcadeControlForm.laserArcade.NumberOfTargets)
        TargetEnableTextBox.Text = CStr(ArcadeControlForm.TargetEnableTimer.Interval)

        If ArcadeControlForm.laserArcade.TimedDisable Then
            TargetAutoDisableRadioButton.Checked = True
            TargetRemainEnabledRadioButton.Checked = False
            AutoDisableGroupBox.Enabled = True
        Else
            TargetAutoDisableRadioButton.Checked = False
            TargetRemainEnabledRadioButton.Checked = True
            AutoDisableGroupBox.Enabled = False
        End If

        AutoDisableMaximumTextBox.Text = CStr(ArcadeControlForm.laserArcade.TimedDisableMaximum)
        AutoDisableMinimumTextBox.Text = CStr(ArcadeControlForm.laserArcade.TimedDisableMinimum)

        loaded = True
    End Sub

    Private Sub RemovePointsButton_Click(sender As Object, e As EventArgs) Handles RemovePointsButton.Click
        If loaded Then
            Dim newLength As Integer = ArcadeControlForm.pointOverrides.Length \ 2 - 2
            Dim newOverrides(1, newLength) As Integer 'dim a new array one index longer than before
            Dim offset As Integer = 0

            'move the entered data to the overrides
            If PointsListBox.SelectedItem IsNot Nothing Then

                'load current overrides into the new overrides, skipping selected index
                For i = 0 To 1
                    offset = 0
                    For j = 0 To newLength
                        If j >= PointsListBox.SelectedIndex Then
                            offset = 1
                        End If
                        newOverrides(i, j) = ArcadeControlForm.pointOverrides(i, j + offset)
                    Next
                Next

                'load the newOverrides into the main overrides
                ArcadeControlForm.pointOverrides = newOverrides

                'update the listbox
                UpdatePointsListBox()
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            Else
                MsgBox("Please select an override to delete")
            End If
        End If
    End Sub

    Private Sub TargetEnableTextBox_TextChanged(sender As Object, e As EventArgs) Handles TargetEnableTextBox.TextChanged
        If loaded Then
            If Not VerifyNumber(TargetEnableTextBox) = Nothing Then
                ArcadeControlForm.TargetEnableTimer.Interval = VerifyNumber(TargetEnableTextBox)
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            End If
        End If
    End Sub

    Private Sub AutoDisableMinimumTextBox_TextChanged(sender As Object, e As EventArgs) Handles AutoDisableMinimumTextBox.TextChanged
        If loaded Then
            If Not VerifyNumber(AutoDisableMinimumTextBox) = Nothing Then
                ArcadeControlForm.laserArcade.TimedDisableMinimum = VerifyNumber(AutoDisableMinimumTextBox)
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            End If
        End If
    End Sub

    Private Sub AutoDisableMaximumTextBox_TextChanged(sender As Object, e As EventArgs) Handles AutoDisableMaximumTextBox.TextChanged
        If loaded Then
            If Not VerifyNumber(AutoDisableMaximumTextBox) = Nothing Then
                ArcadeControlForm.laserArcade.TimedDisableMaximum = VerifyNumber(AutoDisableMaximumTextBox)
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            End If
        End If
    End Sub

    Private Sub TargetAutoDisableRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles TargetAutoDisableRadioButton.CheckedChanged
        If loaded Then
            If TargetAutoDisableRadioButton.Checked Then
                ArcadeControlForm.laserArcade.TimedDisable = True
                AutoDisableGroupBox.Enabled = True
            Else
                ArcadeControlForm.laserArcade.TimedDisable = False
                AutoDisableGroupBox.Enabled = False
            End If
            ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
        End If
    End Sub

    ''' <summary>
    ''' Saves the current configuration to file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        'default file path for save dialog
        SaveFileDialog.DefaultExt = ".config"
        SaveFileDialog.Title = "Save Configuration"
        SaveFileDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*"
        SaveFileDialog.FileName = $"LaserArcadeConfig_{DateTime.Today.Now.ToString("yyyy-MM-dd-hhmm")}.config"
        SaveFileDialog.InitialDirectory = "../"

        If SaveFileDialog().ShowDialog = DialogResult.OK Then
            FileOpen(1, SaveFileDialog.FileName, OpenMode.Output)
            Write(1, ArcadeControlForm.gameTime)
            Write(1, ArcadeControlForm.laserArcade.NumberOfTargets)
            Write(1, ArcadeControlForm.TargetEnableTimer.Interval)
            Write(1, ArcadeControlForm.laserArcade.TimedDisable)
            Write(1, ArcadeControlForm.laserArcade.TimedDisableMinimum)
            WriteLine(1, ArcadeControlForm.laserArcade.TimedDisableMaximum)
            For i = 0 To (ArcadeControlForm.pointOverrides.Length \ 2) - 1
                Write(1, ArcadeControlForm.pointOverrides(0, i))
                WriteLine(1, ArcadeControlForm.pointOverrides(1, i))
            Next
            FileClose(1)

            ArcadeControlForm.ConfigurationStatusStripLabel.Text = Split(SaveFileDialog.FileName, "\").Last
        End If
    End Sub

    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenButton.Click
        Dim currentLine As String
        Dim addressQueue As New Queue(Of Integer)
        Dim pointQueue As New Queue(Of Integer)

        OpenFileDialog.Title = "Open Configuration"
        OpenFileDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*"
        OpenFileDialog.InitialDirectory = "../"

        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            FileOpen(1, OpenFileDialog.FileName, OpenMode.Input)
            Input(1, ArcadeControlForm.gameTime)
            Input(1, ArcadeControlForm.laserArcade.NumberOfTargets)
            Input(1, ArcadeControlForm.TargetEnableTimer.Interval)
            Input(1, ArcadeControlForm.laserArcade.TimedDisable)
            Input(1, ArcadeControlForm.laserArcade.TimedDisableMinimum)
            Input(1, ArcadeControlForm.laserArcade.TimedDisableMaximum)
            Do Until EOF(1)
                currentLine = LineInput(1)
                addressQueue.Enqueue(CInt(Split(currentLine, ",")(0)))
                pointQueue.Enqueue(CInt(Split(currentLine, ",")(1)))
            Loop

            Dim newPointOverride(1, addressQueue.Count - 1) As Integer

            For i = 0 To addressQueue.Count - 1
                newPointOverride(0, i) = addressQueue.Dequeue
                newPointOverride(1, i) = pointQueue.Dequeue
            Next

            ArcadeControlForm.pointOverrides = newPointOverride
            loaded = False
            ArcadeControlForm.ConfigurationStatusStripLabel.Text = Split(OpenFileDialog.FileName, "\").Last

            FileClose(1)
            ArcadeConfigurationForm_Load(sender, e)
        End If
    End Sub

    Private Sub ArcadeConfigurationForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ArcadeControlForm.Enabled = True
    End Sub
End Class