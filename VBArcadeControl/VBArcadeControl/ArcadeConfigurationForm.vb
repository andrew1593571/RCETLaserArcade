Option Strict On
Option Explicit On
Option Compare Text
Imports System.ComponentModel
Imports System.Security

'Laser Arcade Project
'Andrew Keller
'Spring 2025
'https://github.com/AlexWheelock/Laser-Arcade-Project.git

Public Class ArcadeConfigurationForm

    '######______Global Variables______######

    ''' <summary>
    ''' Used to bypass textChanged events during form load
    ''' </summary>
    Private loaded As Boolean

    '######______Subroutines______######

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
                    'number did not convert to integer, warn user
                    MsgBox($"{numberInput} is not a number. Please enter a number.")
                    Return Nothing
                End Try
            End If
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Updates the Points Overrides list box entries to match the control form overrides array
    ''' </summary>
    Private Sub UpdatePointsListBox()
        PointsListBox.Items.Clear() 'clear the current items

        'for every item in the ArcadeControlForm.pointOverrides array, add it to the PointsListBox on this form
        For i = 0 To (ArcadeControlForm.pointOverrides.Length \ 2) - 1
            PointsListBox.Items.Add($"0x{Hex(ArcadeControlForm.pointOverrides(0, i)).PadLeft(2, "0"c)} - {ArcadeControlForm.pointOverrides(1, i)} Point(s)")
        Next
    End Sub

    ''' <summary>
    ''' Adds a points override to the ArcadeControlForm.pointsOverride array
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    '######_____Form Event Handlers______######

    ''' <summary>
    ''' Verifies that the I2C address entered is a valid Hex input.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' Verifies the entered game time is a valid number and modifies the current configuration
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GameTimeTextBox_TextChanged(sender As Object, e As EventArgs) Handles GameTimeTextBox.TextChanged
        If loaded Then
            If Not VerifyNumber(GameTimeTextBox) = Nothing Then 'if the entered time is a valid number
                ArcadeControlForm.gameTime = VerifyNumber(GameTimeTextBox) 'change the configuration
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Verifies the entered number of targets is valid for the laser arcade
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TargetNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles TargetNumberTextBox.TextChanged
        Dim targetNumber As Integer 'from 1 to 127

        If loaded Then
            If Not VerifyNumber(TargetNumberTextBox) = Nothing Then 'make sure the input is actually a number
                targetNumber = VerifyNumber(TargetNumberTextBox)

                If targetNumber > 0 And targetNumber <= 127 Then 'if the number of targets is from 1 to 127 
                    ArcadeControlForm.laserArcade.NumberOfTargets = targetNumber 'update the configuration
                    ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration" 'change the status to modified config
                Else
                    MsgBox("The Laser Arcade does not support less than 1 or more than 127 targets.")
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Sets all labels and controls of the configuration form to match the current configuration
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ArcadeConfigurationForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        UpdatePointsListBox() 'update the points overrides listbox
        GameTimeTextBox.Text = CStr(ArcadeControlForm.gameTime) 'set the gametime textbox to the current game time
        TargetNumberTextBox.Text = CStr(ArcadeControlForm.laserArcade.NumberOfTargets) 'sets the number of targets textbox to the current number of targets
        TargetEnableTextBox.Text = CStr(ArcadeControlForm.TargetEnableTimer.Interval) 'sets the TargetEnableTextBox to match the current interval

        'adjust the radio buttons according to current configuration
        If ArcadeControlForm.laserArcade.TimedDisable Then
            TargetAutoDisableRadioButton.Checked = True
            TargetRemainEnabledRadioButton.Checked = False
            AutoDisableGroupBox.Enabled = True 'enable the max and min inputs
        Else
            TargetAutoDisableRadioButton.Checked = False
            TargetRemainEnabledRadioButton.Checked = True
            AutoDisableGroupBox.Enabled = False 'disable the max and min inputs
        End If

        'set the max and min disable time inputs to match the current configuration
        AutoDisableMaximumTextBox.Text = CStr(ArcadeControlForm.laserArcade.TimedDisableMaximum)
        AutoDisableMinimumTextBox.Text = CStr(ArcadeControlForm.laserArcade.TimedDisableMinimum)

        loaded = True
    End Sub

    ''' <summary>
    ''' Removes a points override from the ArcadeControlForm.pointsOverride array.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RemovePointsButton_Click(sender As Object, e As EventArgs) Handles RemovePointsButton.Click
        If loaded Then
            Dim newLength As Integer = ArcadeControlForm.pointOverrides.Length \ 2 - 2
            Dim newOverrides(1, newLength) As Integer 'dim a new array one index shorter than before
            Dim offset As Integer = 0

            'move the modified data to the overrides array
            If PointsListBox.SelectedItem IsNot Nothing Then 'verify that an override has been selected

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
                'if an override has not been selected
                MsgBox("Please select an override to remove.")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Verifies the entered target enable interval is a valid number and updates the configuration
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TargetEnableTextBox_TextChanged(sender As Object, e As EventArgs) Handles TargetEnableTextBox.TextChanged
        If loaded Then
            If Not VerifyNumber(TargetEnableTextBox) = Nothing Then 'if the entered value is a valid number
                ArcadeControlForm.TargetEnableTimer.Interval = VerifyNumber(TargetEnableTextBox) 'update the configuration
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Verifies the entered disable minimum is a valid number and updates configuration
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AutoDisableMinimumTextBox_TextChanged(sender As Object, e As EventArgs) Handles AutoDisableMinimumTextBox.TextChanged
        If loaded Then
            If Not VerifyNumber(AutoDisableMinimumTextBox) = Nothing Then 'if the input is a valid number
                ArcadeControlForm.laserArcade.TimedDisableMinimum = VerifyNumber(AutoDisableMinimumTextBox) 'update configuration
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Verifies the entered disable maximum is a valid number and updates current configuration
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AutoDisableMaximumTextBox_TextChanged(sender As Object, e As EventArgs) Handles AutoDisableMaximumTextBox.TextChanged
        If loaded Then
            If Not VerifyNumber(AutoDisableMaximumTextBox) = Nothing Then 'if input is a valid number
                ArcadeControlForm.laserArcade.TimedDisableMaximum = VerifyNumber(AutoDisableMaximumTextBox) 'update configuration
                ArcadeControlForm.ConfigurationStatusStripLabel.Text = "Modified Configuration"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Updates configuration when the radio buttons are changed. Disables the min and max inputs if timed disable is false
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TargetAutoDisableRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles TargetAutoDisableRadioButton.CheckedChanged
        If loaded Then
            If TargetAutoDisableRadioButton.Checked Then
                ArcadeControlForm.laserArcade.TimedDisable = True
                AutoDisableGroupBox.Enabled = True 'enable the max and min inputs
            Else
                ArcadeControlForm.laserArcade.TimedDisable = False
                AutoDisableGroupBox.Enabled = False 'disable the max and min inputs
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
        'setup the SaveFileDialog to appear to the user
        SaveFileDialog.DefaultExt = ".config"
        SaveFileDialog.Title = "Save Configuration"
        SaveFileDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*"
        SaveFileDialog.FileName = $"LaserArcadeConfig_{DateTime.Today.Now.ToString("yyyy-MM-dd-hhmm")}.config"
        SaveFileDialog.InitialDirectory = "../"

        'if the user clicked OK in the SaveFileDialog
        If SaveFileDialog().ShowDialog = DialogResult.OK Then
            FileOpen(1, SaveFileDialog.FileName, OpenMode.Output) 'open the new file as an output
            Write(1, ArcadeControlForm.gameTime) 'add the game time to the file
            Write(1, ArcadeControlForm.laserArcade.NumberOfTargets) 'add the targets to the file
            Write(1, ArcadeControlForm.TargetEnableTimer.Interval) 'add the enable interval to file
            Write(1, ArcadeControlForm.laserArcade.TimedDisable) 'add if the timed disable is on or not
            Write(1, ArcadeControlForm.laserArcade.TimedDisableMinimum) 'add minimum enable time
            WriteLine(1, ArcadeControlForm.laserArcade.TimedDisableMaximum) 'add maximum enable time
            For i = 0 To (ArcadeControlForm.pointOverrides.Length \ 2) - 1 'add the points overrides on a new line for each
                Write(1, ArcadeControlForm.pointOverrides(0, i))
                WriteLine(1, ArcadeControlForm.pointOverrides(1, i))
            Next
            FileClose(1) 'close the file

            ArcadeControlForm.ConfigurationStatusStripLabel.Text = Split(SaveFileDialog.FileName, "\").Last 'change the configuration status label on the control form
        End If
    End Sub

    ''' <summary>
    ''' opens a previously saved configuration from file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OpenButton_Click(sender As Object, e As EventArgs) Handles OpenButton.Click
        Dim currentLine As String
        Dim addressQueue As New Queue(Of Integer)
        Dim pointQueue As New Queue(Of Integer)

        'setup the openfiledialog to be shown to the user
        OpenFileDialog.Title = "Open Configuration"
        OpenFileDialog.Filter = "Config files (*.config)|*.config|All files (*.*)|*.*"
        OpenFileDialog.InitialDirectory = "../"

        'if the user clicked okay in the dialog
        If OpenFileDialog.ShowDialog = DialogResult.OK Then
            FileOpen(1, OpenFileDialog.FileName, OpenMode.Input) 'open the file as an input
            Input(1, ArcadeControlForm.gameTime) 'read the gametime
            Input(1, ArcadeControlForm.laserArcade.NumberOfTargets) 'read the number of targets
            Input(1, ArcadeControlForm.TargetEnableTimer.Interval) 'read the enable interval
            Input(1, ArcadeControlForm.laserArcade.TimedDisable) 'read whether or not the targets auto-disable
            Input(1, ArcadeControlForm.laserArcade.TimedDisableMinimum) 'read the minimum enable time
            Input(1, ArcadeControlForm.laserArcade.TimedDisableMaximum) 'read the maximum enable time
            Do Until EOF(1) 'read any and all points overrides and put them in a queue
                currentLine = LineInput(1)
                addressQueue.Enqueue(CInt(Split(currentLine, ",")(0)))
                pointQueue.Enqueue(CInt(Split(currentLine, ",")(1)))
            Loop

            'create a new points override array
            Dim newPointOverride(1, addressQueue.Count - 1) As Integer

            'load the input points overrides into the array
            For i = 0 To addressQueue.Count - 1
                newPointOverride(0, i) = addressQueue.Dequeue
                newPointOverride(1, i) = pointQueue.Dequeue
            Next

            'set the current pointOverrides to the new overrides
            ArcadeControlForm.pointOverrides = newPointOverride
            loaded = False 'bypass textChanged events for the Configuration form
            ArcadeControlForm.ConfigurationStatusStripLabel.Text = Split(OpenFileDialog.FileName, "\").Last 'update the config status label

            FileClose(1) 'close the file
            ArcadeConfigurationForm_Load(sender, e) 'reload the configuration form
        End If
    End Sub

    ''' <summary>
    ''' Re-enables the ArcadeControlForm when this form closes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ArcadeConfigurationForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        ArcadeControlForm.Enabled = True
    End Sub
End Class