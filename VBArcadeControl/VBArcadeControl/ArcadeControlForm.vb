Option Strict On
Option Explicit On
Imports System.IO.Ports

Public Class ArcadeControlForm
    '######______Global Variables______######
    ''' <summary>
    ''' Instance of the LaserArcade class
    ''' </summary>
    Public WithEvents laserArcade As New LaserArcade

    ''' <summary>
    ''' Stores the game time length in seconds.
    ''' </summary>
    Public gameTime As Integer

    ''' <summary>
    ''' True if a game is in progress
    ''' </summary>
    Private gameInProgress As Boolean

    ''' <summary>
    ''' stores any point overrides. If not in this array, points default to 1
    ''' 0,n is address. 1,n is point value
    ''' </summary>
    Public pointOverrides(,) As Integer

    '######______Serial COM Subroutines______######

    ''' <summary>
    ''' If not currently connected to a serial device and the COM select is not open, update the available COM ports
    ''' </summary>
    Sub UpdateAvailableCOM()
        If Not laserArcade.Connected And Not COMPortComboBox.DroppedDown Then
            COMPortComboBox.Items.Clear()
            For Each sp As String In My.Computer.Ports.SerialPortNames
                COMPortComboBox.Items.Add(sp)
            Next
            COMPortComboBox.Text = laserArcade.COMPort
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
            COMPortTimer.Enabled = False

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


    '######_____Event Handlers______######

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

    End Sub

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

    Private Sub ConnectDisconnectStatusStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectDisconnectStatusStripMenuItem.Click
        'connect or disconnect from the laser arcade
        ConnectDisconnectSerial()
    End Sub

    Private Sub SerialStatusStripSplitButton_ButtonClick(sender As Object, e As EventArgs) Handles SerialStatusStripSplitButton.ButtonClick
        'show the dropdown when the button is pressed
        SerialStatusStripSplitButton.ShowDropDown()
    End Sub

    Private Sub COMPortComboBox_TextChanged(sender As Object, e As EventArgs) Handles COMPortComboBox.TextChanged
        'update the controls when the selected COM port changes
        UpdateSerialControls(False)
    End Sub

    Private Sub laserArcadeGame_DeviceVerificationFailed(message As String) Handles laserArcade.DeviceVerificationFailed
        UpdateSerialControls(False)
        MsgBox(message)
    End Sub

    Private Sub StartGameButton_Click(sender As Object, e As EventArgs) Handles StartGameButton.Click
        laserArcade.EnableRandomTarget()
        GameTimer.Start()
        TargetEnableTimer.Start()
    End Sub

    Private Sub TargetEnableTimer_Tick(sender As Object, e As EventArgs) Handles TargetEnableTimer.Tick
        laserArcade.EnableRandomTarget()
    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        TargetEnableTimer.Stop()
        GameTimer.Stop()
        laserArcade.DisableTarget(0)
        MsgBox("Game Over")
    End Sub

    ''' <summary>
    ''' Opens the configuration menu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ConfigurationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurationToolStripMenuItem.Click
        ArcadeConfigurationForm.Show()
    End Sub

    ''' <summary>
    ''' Reload the form to reset the defaults
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ResetTopMenuItem_Click(sender As Object, e As EventArgs) Handles ResetTopMenuItem.Click
        ArcadeControlForm_Load(sender, e)
    End Sub
End Class
