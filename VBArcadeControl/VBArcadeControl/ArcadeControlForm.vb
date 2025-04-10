Option Strict On
Option Explicit On
Imports System.IO.Ports

Public Class ArcadeControlForm

    '######______Serial COM Subroutines______######

    ''' <summary>
    ''' If not currently connected to a serial device and the COM select is not open, update the available COM ports
    ''' </summary>
    Sub UpdateAvailableCOM()
        If Not SerialPort.IsOpen And Not COMPortComboBox.DroppedDown Then
            COMPortComboBox.Items.Clear()
            For Each sp As String In My.Computer.Ports.SerialPortNames
                COMPortComboBox.Items.Add(sp)
            Next
            COMPortComboBox.Text = SerialPort.PortName
        End If
    End Sub

    ''' <summary>
    ''' If connect is true, sets the status strip to connected to..., connect/disconnect button to disconnect, lock COM port selection
    ''' If connect is false, sets the status strip to disconnected from, connect/disconnect button to connect, unlocks COM port selection
    ''' </summary>
    ''' <param name="connect"></param>
    Sub UpdateSerialControls(connect As Boolean)
        If connect Then
            SerialStatusLabel.Text = $"Connected to {SerialPort.PortName}" 'set the status bar label
            ConnectDisconnectStatusStripMenuItem.Text = "Disconnect" 'set the connect/disconnect button to disconnect
            COMPortComboBox.Enabled = False 'disable COM port selection
            COMPortTimer.Enabled = False

            'cycle the timer to reset the count
            COMPortTimer.Stop()
            COMPortTimer.Start()
        Else
            ConnectDisconnectStatusStripMenuItem.Text = "Connect" 'set the connect/disconnect button to connect
            SerialStatusLabel.Text = $"Disconnected from {SerialPort.PortName}" 'set the status bar label
            COMPortComboBox.Enabled = True 'enable COM port selection
            COMPortTimer.Start() 'starts the timer to periodically update the available COM ports
        End If
    End Sub

    Sub ConnectDisconnectSerial()
        Dim verification(1) As Byte 'the Laser Arcade verification command
        verification(0) = &H24 'handshake byte
        verification(1) = &H56 'command byte

        If SerialPort.IsOpen Then
            'Disconnect from serial device
            Try
                SerialPort.Close() 'close the serial port

                'change the connect button text, serial status, and enable the COM selection
                UpdateSerialControls(False)

            Catch ex As Exception 'if failed to disconnect, alert user, change all controls back to 
                MsgBox($"Failed to disconnect from device on {SerialPort.PortName}")
                UpdateSerialControls(True)

            End Try
        Else
            'connect to serial device
            If COMPortComboBox.Text.Contains("COM") Then 'verify a COM port is selected
                'set the serial port to the selected COM port
                SerialPort.PortName = COMPortComboBox.Text

                'open the serial port and change the controls, notify user if failed
                Try
                    SerialPort.Open()
                    UpdateSerialControls(True)
                Catch ex As Exception
                    MsgBox($"Failed to connect to device on {SerialPort.PortName}")
                    UpdateSerialControls(False) 'set controls back to previous
                    Exit Sub 'skip the rest of the sub
                End Try

                'send device verification command
                SerialPort.Write(verification, 0, 2)
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
        UpdateAvailableCOM() 'update the COM selection dropdown
        UpdateSerialControls(False) 'update the controls to reflect the current SerialPort COM port
    End Sub

    ''' <summary>
    ''' Handles both refreshing available COM ports when not connected and connection timeout when first connected.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub COMPortTimer_Tick(sender As Object, e As EventArgs) Handles COMPortTimer.Tick
        If SerialPort.IsOpen Then
            'Laser Arcade did not respond to device verification, disconnect and notify user
            Try
                SerialPort.Close() 'close the serial port

                'change the connect button text, serial status, and enable the COM selection
                UpdateSerialControls(False)

            Catch ex As Exception 'do nothing if errored
            End Try

            MsgBox("Device verification timed out. Please verify the COM port is correct.")

        Else
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
End Class
