Option Strict On
Option Explicit On
Imports System.ComponentModel
Imports System.IO.Ports

'Laser Arcade Project
'Andrew Keller
'Spring 2025
'https://github.com/AlexWheelock/Laser-Arcade-Project.git

Public Class ArcadeControlForm
    '######______Global Variables______######
    ''' <summary>
    ''' Instance of the LaserArcade class for the form
    ''' </summary>
    Public WithEvents laserArcade As New LaserArcade

    ''' <summary>
    ''' Stores the game time length in seconds.
    ''' </summary>
    Public gameTime As Integer

    ''' <summary>
    ''' Number of seconds left before end of game
    ''' </summary>
    Private gameCountdown As Integer

    ''' <summary>
    ''' True if a game is in progress
    ''' </summary>
    Private gameInProgress As Boolean

    ''' <summary>
    ''' Stores the points scored by player one.
    ''' </summary>
    Private playerOnePoints As Integer

    ''' <summary>
    ''' Stores the points scored by player two
    ''' </summary>
    Private playerTwoPoints As Integer

    ''' <summary>
    ''' stores any point overrides. If not in this array, points default to 1
    ''' 0,n is address. 1,n is point value
    ''' </summary>
    Public pointOverrides(,) As Integer


    '######______Subroutines______######

    ''' <summary>
    ''' If not currently connected to a serial device and the COM select is not open, update the available COM ports
    ''' </summary>
    Sub UpdateAvailableCOM()
        If Not laserArcade.Connected And Not COMPortComboBox.DroppedDown Then
            COMPortComboBox.Items.Clear()   'clear the Combobox items
            For Each sp As String In My.Computer.Ports.SerialPortNames 'add all available serial ports to the combo box
                COMPortComboBox.Items.Add(sp)
            Next
            COMPortComboBox.Text = laserArcade.COMPort 'set the combobox text to the current COM port
        End If
    End Sub

    ''' <summary>
    ''' If connect is true, sets the status strip to connected to..., connect/disconnect button to disconnect, lock COM port selection
    ''' If connect is false, sets the status strip to disconnected from, connect/disconnect button to connect, unlocks COM port selection
    ''' </summary>
    ''' <param name="connect"></param>
    Sub UpdateSerialControls(connect As Boolean)
        If connect Then
            SerialStatusLabel.Text = $"Connected to {laserArcade.COMPort}" 'set the status bar label
            ConnectDisconnectStatusStripMenuItem.Text = "Disconnect" 'set the connect/disconnect button to disconnect
            COMPortComboBox.Enabled = False 'disable COM port selection
            COMPortTimer.Enabled = False 'stop refreshing the available COM ports

            'cycle the timer to reset the count
            COMPortTimer.Stop()
            COMPortTimer.Start()
        Else
            ConnectDisconnectStatusStripMenuItem.Text = "Connect" 'set the connect/disconnect button to connect
            SerialStatusLabel.Text = $"Disconnected from {laserArcade.COMPort}" 'set the status bar label
            COMPortComboBox.Enabled = True 'enable COM port selection
            COMPortTimer.Start() 'starts the timer to periodically update the available COM ports
        End If
    End Sub

    ''' <summary>
    ''' Attempts to connect or disconnect from the laser arcade target master.
    ''' If currently disconnected, try connecting.
    ''' If currently connected, try disconnecting.
    ''' </summary>
    Sub ConnectDisconnectSerial()
        If laserArcade.Connected Then
            'Disconnect from serial device
            Try
                laserArcade.EndConnection() 'close the serial port

                'change the connect button text, serial status, and enable the COM selection
                UpdateSerialControls(False)

            Catch ex As Exception 'if failed to disconnect, alert user, change all controls back to 
                MsgBox($"Failed to disconnect from device on {laserArcade.COMPort}")
                UpdateSerialControls(True)

            End Try
        Else
            'connect to serial device
            If COMPortComboBox.Text.Contains("COM") Then 'verify a COM port is selected
                'set the serial port to the selected COM port
                laserArcade.COMPort = COMPortComboBox.Text

                'open the serial port and change the controls, notify user if failed
                Try
                    laserArcade.StartConnection()
                    UpdateSerialControls(True)
                Catch ex As Exception
                    MsgBox($"Failed to connect to device on {laserArcade.COMPort}")
                    UpdateSerialControls(False) 'set controls back to previous
                    Exit Sub 'skip the rest of the sub
                End Try

            End If
        End If
    End Sub

    ''' <summary>
    ''' Updates the GUI countdown label with the current remaining time
    ''' </summary>
    Private Sub UpdateCountdown()
        Dim minutes As Integer
        Dim seconds As Integer

        minutes = gameCountdown \ 60 'set minutes to the number of minutes remaining
        seconds = gameCountdown - (60 * minutes) 'set seconds to the remainder

        CountdownLabel.Text = $"{minutes}:{CStr(seconds).PadLeft(2, "0"c)}" 'display the countdown as a string
    End Sub


    '######_____Timer Event Handlers______######

    ''' <summary>
    ''' Refreshes available COM ports when not connected.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub COMPortTimer_Tick(sender As Object, e As EventArgs) Handles COMPortTimer.Tick
        If Not laserArcade.Connected Then
            'COM port is not connected, refresh available COM ports
            UpdateAvailableCOM()
        End If
    End Sub

    ''' <summary>
    ''' When the timer ticks, enable a random target.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TargetEnableTimer_Tick(sender As Object, e As EventArgs) Handles TargetEnableTimer.Tick
        laserArcade.EnableRandomTarget() 'enable a random target
    End Sub

    ''' <summary>
    ''' Occurs every 1000ms.
    ''' If a game is in progress, reduces the countdown and updates the labels.
    ''' If the countdown is 0, stop enabling targets, stop the game timer, and end the game
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        If gameInProgress Then
            gameCountdown -= 1 'decrease the game countdown by one
            UpdateCountdown() 'update the countdown label

            If gameCountdown = 0 Then 'if countdown is 0
                TargetEnableTimer.Stop() 'stop enabling targets
                GameTimer.Stop() 'stop counting down
                laserArcade.DisableTarget(0) 'disable all targets
                gameInProgress = False
                CountdownLabel.Text = "Game Over"
                StartStopGameButton.Text = "Start Game"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Updates the scores on the GUI
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ScoreUpdateTimer_Tick(sender As Object, e As EventArgs) Handles ScoreUpdateTimer.Tick
        PlayerTwoScoreLabel.Text = CStr(playerTwoPoints)
        PlayerOneScoreLabel.Text = CStr(playerOnePoints)
    End Sub

    '######_____LaserArcade Event Handlers______######

    ''' <summary>
    ''' Occurs when the laserArcade class raises the DeviceVerificationFailed event. 
    ''' Changes the labels and buttons back to a disconnected state and alerts the user
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub laserArcadeGame_DeviceVerificationFailed(message As String) Handles laserArcade.DeviceVerificationFailed
        UpdateSerialControls(False) 'update the labels and buttons
        MsgBox(message) 'alert the user
    End Sub

    ''' <summary>
    ''' Occurs when player one has scored on a target.
    ''' Adds the rewarded points to their score
    ''' </summary>
    ''' <param name="address"></param>
    Private Sub laserArcade_PlayerOneScore(address As Byte) Handles laserArcade.PlayerOneScore
        Dim addressInt As Integer = CInt(address)
        Dim pointsScored As Integer = 1 'default point value of 1

        For i = 0 To (pointOverrides.Length \ 2) - 1
            If addressInt = pointOverrides(0, i) Then 'if the I2C address of the hit target is in points overrides
                pointsScored = pointOverrides(1, i)
            End If
        Next
        playerOnePoints += pointsScored 'add the points scored to the player points

    End Sub

    ''' <summary>
    ''' Occurs when player two has scored on a target.
    ''' Adds the rewarded points to their score
    ''' </summary>
    ''' <param name="address"></param>
    Private Sub laserArcade_PlayerTwoScore(address As Byte) Handles laserArcade.PlayerTwoScore
        Dim addressInt As Integer = CInt(address)
        Dim pointsScored As Integer = 1 'default point value of 1

        For i = 0 To (pointOverrides.Length \ 2) - 1
            If addressInt = pointOverrides(0, i) Then 'if the I2C address of the target has a point override
                pointsScored = pointOverrides(1, i)
            End If
        Next
        playerTwoPoints += pointsScored 'add the points scored to the player points

    End Sub

    ''' <summary>
    ''' Occurs when the laserArcade class raises the DeviceVerificationFailed event. 
    ''' Changes the labels and buttons back to a disconnected state and alerts the user
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub laserArcade_UnexpectedDisconnect(message As String) Handles laserArcade.UnexpectedDisconnect
        UpdateSerialControls(False) 'update the labels and buttons
        MsgBox(message) 'alert the user
    End Sub

    '######_____Form Event Handlers______######

    ''' <summary>
    ''' Configures the defaults on the form when it loads.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ArcadeControlForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim defaultOverrides(1, 0) As Integer
        defaultOverrides(0, 0) = 0
        defaultOverrides(1, 0) = 0

        If Not laserArcade.Connected Then
            UpdateAvailableCOM() 'update the COM selection dropdown
            UpdateSerialControls(False) 'update the controls to reflect the current SerialPort COM port
        End If

        'set default configuration
        laserArcade.NumberOfTargets = 1 'single target
        laserArcade.TimedDisable = True 'targets turn off with timer
        gameTime = 60 '60 second gametime
        pointOverrides = defaultOverrides 'address 0x00 is worth 0 points
        laserArcade.TimedDisableMinimum = 5000 '5 second minimum target enable time
        laserArcade.TimedDisableMaximum = 10000 '10 second maximum target enable time
        TargetEnableTimer.Interval = 500 'target enabled every 500ms
        ConfigurationStatusStripLabel.Text = "Default Configuration"

        ScoreUpdateTimer.Start()
        COMPortTimer.Start()

    End Sub

    ''' <summary>
    ''' Handles when the connect/disconnect button is pressed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ConnectDisconnectStatusStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectDisconnectStatusStripMenuItem.Click
        If Not gameInProgress Then 'prevent changes in connection during game
            'connect or disconnect from the laser arcade
            ConnectDisconnectSerial()
        Else
            MsgBox("Connection cannot be changed with a game in progress.")
        End If
    End Sub

    ''' <summary>
    ''' When the serial icon in the status strip is clicked, open its dropdown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SerialStatusStripSplitButton_ButtonClick(sender As Object, e As EventArgs) Handles SerialStatusStripSplitButton.ButtonClick
        'show the dropdown when the button is pressed
        SerialStatusStripSplitButton.ShowDropDown()
    End Sub

    ''' <summary>
    ''' Handles when the selected COM Port has changed in the ComboBox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub COMPortComboBox_TextChanged(sender As Object, e As EventArgs) Handles COMPortComboBox.TextChanged
        'update the controls when the selected COM port changes
        UpdateSerialControls(False)
    End Sub

    ''' <summary>
    ''' Handles when the start/stop game button is pressed.
    ''' If the game is in progress, the game is stopped.
    ''' If the game is not in progress, the game is started.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub StartStopGameButton_Click(sender As Object, e As EventArgs) Handles StartStopGameButton.Click
        If gameInProgress Then
            'game is in progress, stop the game
            TargetEnableTimer.Stop() 'stop enabling targets
            GameTimer.Stop() 'stop the game timer
            laserArcade.DisableTarget(0) 'disable all targets
            gameInProgress = False 'mark that a game is no longer in progress
            CountdownLabel.Text = "Game Over" 'change the countdown text
            StartStopGameButton.Text = "Start Game" 'change the button back to start game
        Else
            'Game is not in progress
            If laserArcade.Connected And laserArcade.DeviceVerified Then
                'already connected to the target master board
                gameCountdown = gameTime 'reset the game countdown to the configured game time
                UpdateCountdown() 'update the countdown label

                'reset player points
                playerOnePoints = 0
                playerTwoPoints = 0
                PlayerOneScoreLabel.Text = "0"
                PlayerTwoScoreLabel.Text = "0"

                'start the game
                gameInProgress = True
                laserArcade.EnableRandomTarget() 'enable a target immediately
                GameTimer.Start() 'start the gametimer
                TargetEnableTimer.Start() 'start enabling other targets
                StartStopGameButton.Text = "Stop Game" 'change the button to stop game
            Else
                'not connected to the target master board, alert user
                MsgBox("Please connect to the Laser Arcade COM port.")
            End If
        End If
    End Sub

    ''' <summary>
    ''' Opens the configuration menu and disables this form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurationToolStripMenuItem.Click
        If gameInProgress Then
            MsgBox("Configuration cannot be changed with a game in progress.")
        Else
            ArcadeConfigurationForm.Show()
            Me.Enabled = False
        End If
    End Sub

    ''' <summary>
    ''' Reload the form to reset the defaults
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ResetTopMenuItem_Click(sender As Object, e As EventArgs) Handles ResetTopMenuItem.Click
        If gameInProgress Then
            MsgBox("Configuration cannot be changed with a game in progress.")
        Else
            ArcadeControlForm_Load(sender, e)
        End If
    End Sub

    ''' <summary>
    ''' Closes the form when the exit button is pressed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' When the form closes and a game is in progress, disable all targets before closing.
    ''' Ensures target system disconnects properly.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ArcadeControlForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If gameInProgress Then
            laserArcade.DisableTarget(0)
        End If
    End Sub

    ''' <summary>
    ''' Opens the About Form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
    End Sub
End Class
