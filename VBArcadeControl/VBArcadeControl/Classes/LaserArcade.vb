Option Explicit On
Option Strict On
Imports System.IO.Ports

'Laser Arcade Project
'Andrew Keller
'Spring 2025
'https://github.com/AlexWheelock/Laser-Arcade-Project.git

Public Class LaserArcade

    '######______Event Declarations______######

    ''' <summary>
    ''' Raised when the connected COM device fails to verify as the laser arcade master device
    ''' </summary>
    ''' <param name="message"></param>
    Public Event DeviceVerificationFailed(ByVal message As String)

    ''' <summary>
    ''' raised when player one scores on a target. The address is the I2C address associated with the score
    ''' </summary>
    ''' <param name="address"></param>
    Public Event PlayerOneScore(ByVal address As Byte)

    ''' <summary>
    ''' raised when player two scores on a target. The address is the I2C address associated with the score
    ''' </summary>
    ''' <param name="address"></param>
    Public Event PlayerTwoScore(ByVal address As Byte)

    '######______Object With Events Declarations______######

    Private WithEvents arcadePort As New SerialPort
    Private WithEvents verificationTimer As New Timer
    Private WithEvents connectionTimeoutTimer As New Timer

    '######______Class Properties and variables______######

    Private _targets(7) As ArcadeTarget
    Private _disableTimers(7) As Timer

    ''' <summary>
    ''' returns the open or closed status of the arcadePort serial connection
    ''' </summary>
    Public ReadOnly Property Connected() As Boolean
        Get
            Return arcadePort.IsOpen
        End Get
    End Property

    ''' <summary>
    ''' get or set the current COM port for the arcade
    ''' </summary>
    ''' <returns></returns>
    Public Property COMPort() As String
        Get
            Return arcadePort.PortName
        End Get
        Set(value As String)
            If Not arcadePort.IsOpen Then
                arcadePort.PortName = value
            End If
        End Set
    End Property

    Private _targetTimedDisable As Boolean
    ''' <summary>
    ''' If true, the targets will be disabled after a random amount of time in the disable range.
    ''' </summary>
    ''' <returns></returns>
    Public Property TimedDisable() As Boolean
        Get
            Return _targetTimedDisable
        End Get
        Set(ByVal value As Boolean)
            _targetTimedDisable = value
        End Set
    End Property

    Private _disableTimeMinimum As Integer
    ''' <summary>
    ''' The minimum amount of time a target will remain enabled unless hit by a player in ms.
    ''' </summary>
    ''' <returns></returns>
    Public Property TimedDisableMinimum() As Integer
        Get
            Return _disableTimeMinimum
        End Get
        Set(ByVal value As Integer)
            _disableTimeMinimum = value
        End Set
    End Property

    Private _disableTimeMaximum As Integer
    ''' <summary>
    ''' The maximum amount of time a target will remain enabled in ms.
    ''' </summary>
    ''' <returns></returns>
    Public Property TimedDisableMaximum() As Integer
        Get
            Return _disableTimeMaximum
        End Get
        Set(ByVal value As Integer)
            _disableTimeMaximum = value
        End Set
    End Property

    ''' <summary>
    ''' If the device was verified as the master of the laser arcade, _verified is true
    ''' </summary>
    Private _verified As Boolean
    Public ReadOnly Property DeviceVerified() As Boolean
        Get
            Return _verified
        End Get
    End Property

    ''' <summary>
    ''' stores the number of I2C targets. Addresses start at 0x01.
    ''' </summary>
    Private _numberOfTargets As Integer
    Public Property NumberOfTargets() As Integer
        Get
            Return _numberOfTargets
        End Get
        Set(ByVal value As Integer)
            _numberOfTargets = value
        End Set
    End Property

    '######______Subroutines and Functions______######

    ''' <summary>
    ''' Configures the Laser Arcade class defaults for each instance.
    ''' </summary>
    Sub New()
        'set the COM port Baudrate to 9600 with 8 bits and no parity
        arcadePort.BaudRate = 9600
        arcadePort.DataBits = 8
        arcadePort.Parity = Parity.None

        'sets default timer intervals
        verificationTimer.Interval = 500
        connectionTimeoutTimer.Interval = 10000

        'set the disableTime from 5 to 10 seconds as default
        _disableTimeMaximum = 10000
        _disableTimeMinimum = 5000

        'initialize all targets and respective disable timers
        For i = 0 To 7
            _targets(i) = New ArcadeTarget(i + 1)
            _disableTimers(i) = New Timer
            AddHandler _disableTimers(i).Tick, AddressOf DisableTimer_Tick
        Next
    End Sub

    ''' <summary>
    ''' returns a random number between the max and min
    ''' </summary>
    ''' <param name="max"></param>
    ''' <param name="min"></param>
    ''' <returns></returns>
    Private Function GetRandomNumberBetween(max As Integer, min As Integer) As Integer
        Dim value As Integer

        Randomize(Date.Now.Millisecond)

        value = CInt(Int(Rnd() * ((max - min) + 1))) + min 'finds the difference between max and min, finds a random number in that range, adds min

        Return value
    End Function

    ''' <summary>
    ''' requests verification from the connected device that it is the laser arcade master board
    ''' </summary>
    Private Sub RequestVerification()
        Dim verification(1) As Byte 'the Laser Arcade verification command
        verification(0) = &H24 'handshake byte
        verification(1) = &H56 'command byte

        If arcadePort.IsOpen Then
            arcadePort.Write(verification, 0, 2) 'send the verification request
        End If
    End Sub

    ''' <summary>
    ''' opens the Laser arcade serial port connection and starts the device verification process
    ''' </summary>
    Public Sub StartConnection()
        If Not arcadePort.IsOpen Then 'if the serial port is not already open
            arcadePort.Open() 'open the port
            RequestVerification() 'request verification

            verificationTimer.Start() 'start a timer for the verification
            connectionTimeoutTimer.Start() 'start a connection timeout
        End If
    End Sub

    ''' <summary>
    ''' closes the serial port if it is open
    ''' </summary>
    Public Sub EndConnection()
        If arcadePort.IsOpen Then
            connectionTimeoutTimer.Stop() 'stop the timeout timer
            verificationTimer.Stop() 'stop the verification timer
            arcadePort.Close() 'close the serial port
        End If
    End Sub

    ''' <summary>
    ''' Enables specified target slot. 0 will enable all slots.
    ''' </summary>
    ''' <param name="slot"></param>
    Public Sub EnableTarget(slot As Integer)
        Select Case slot
            Case 0 'enable all targets
                For i = 0 To 7
                    If _targets(i).ReadyToEnable And arcadePort.IsOpen Then
                        arcadePort.Write(_targets(i).EnableTarget(), 0, 3)
                        _disableTimers(i).Interval = GetRandomNumberBetween(_disableTimeMaximum, _disableTimeMinimum)
                        If _targetTimedDisable Then
                            _disableTimers(i).Start()
                        End If
                    End If
                Next
            Case 1 'enable slot 1
                arcadePort.Write(_targets(0).EnableTarget(), 0, 3)
                _disableTimers(0).Interval = GetRandomNumberBetween(_disableTimeMaximum, _disableTimeMinimum)
                If _targetTimedDisable Then
                    _disableTimers(0).Start()
                End If
            Case 2 'enable slot 2
                arcadePort.Write(_targets(1).EnableTarget(), 0, 3)
                _disableTimers(1).Interval = GetRandomNumberBetween(_disableTimeMaximum, _disableTimeMinimum)
                If _targetTimedDisable Then
                    _disableTimers(1).Start()
                End If
            Case 3 'enable slot 3
                arcadePort.Write(_targets(2).EnableTarget(), 0, 3)
                _disableTimers(2).Interval = GetRandomNumberBetween(_disableTimeMaximum, _disableTimeMinimum)
                If _targetTimedDisable Then
                    _disableTimers(2).Start()
                End If
            Case 4 'enable slot 4
                arcadePort.Write(_targets(3).EnableTarget(), 0, 3)
                _disableTimers(3).Interval = GetRandomNumberBetween(_disableTimeMaximum, _disableTimeMinimum)
                If _targetTimedDisable Then
                    _disableTimers(3).Start()
                End If
            Case 5 'enable slot 5
                arcadePort.Write(_targets(4).EnableTarget(), 0, 3)
                _disableTimers(4).Interval = GetRandomNumberBetween(_disableTimeMaximum, _disableTimeMinimum)
                If _targetTimedDisable Then
                    _disableTimers(4).Start()
                End If
            Case 6 'enable slot 6
                arcadePort.Write(_targets(5).EnableTarget(), 0, 3)
                _disableTimers(5).Interval = GetRandomNumberBetween(_disableTimeMaximum, _disableTimeMinimum)
                If _targetTimedDisable Then
                    _disableTimers(5).Start()
                End If
            Case 7 'enable slot 7
                arcadePort.Write(_targets(6).EnableTarget(), 0, 3)
                _disableTimers(6).Interval = GetRandomNumberBetween(_disableTimeMaximum, _disableTimeMinimum)
                If _targetTimedDisable Then
                    _disableTimers(6).Start()
                End If
            Case 8 'enable slot 8
                arcadePort.Write(_targets(7).EnableTarget(), 0, 3)
                _disableTimers(7).Interval = GetRandomNumberBetween(_disableTimeMaximum, _disableTimeMinimum)
                If _targetTimedDisable Then
                    _disableTimers(7).Start()
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Disables specified target slot. 0 will Disable all slots.
    ''' </summary>
    ''' <param name="slot"></param>
    Public Sub DisableTarget(slot As Integer)
        Dim disableAllCommand(1) As Byte
        disableAllCommand(0) = &H24
        disableAllCommand(1) = &H43

        Select Case slot
            Case 0 'enable all targets
                arcadePort.Write(disableAllCommand, 0, 2)
                For i = 0 To 7
                    If _targets(i).ReadyToEnable And arcadePort.IsOpen Then
                        _disableTimers(i).Stop()
                    End If
                    _targets(i).Enabled = False
                Next
            Case 1 'enable slot 1
                arcadePort.Write(_targets(0).DisableTarget(), 0, 3)
                _disableTimers(0).Stop()
            Case 2 'enable slot 2
                arcadePort.Write(_targets(1).DisableTarget(), 0, 3)
                _disableTimers(1).Stop()
            Case 3 'enable slot 3
                arcadePort.Write(_targets(2).DisableTarget(), 0, 3)
                _disableTimers(2).Stop()
            Case 4 'enable slot 4
                arcadePort.Write(_targets(3).DisableTarget(), 0, 3)
                _disableTimers(3).Stop()
            Case 5 'enable slot 5
                arcadePort.Write(_targets(4).DisableTarget(), 0, 3)
                _disableTimers(4).Stop()
            Case 6 'enable slot 6
                arcadePort.Write(_targets(5).DisableTarget(), 0, 3)
                _disableTimers(5).Stop()
            Case 7 'enable slot 7
                arcadePort.Write(_targets(6).DisableTarget(), 0, 3)
                _disableTimers(6).Stop()
            Case 8 'enable slot 8
                arcadePort.Write(_targets(7).DisableTarget(), 0, 3)
                _disableTimers(7).Stop()
        End Select
    End Sub

    ''' <summary>
    ''' sets the address for and enables a random target
    ''' </summary>
    Sub EnableRandomTarget()
        Dim targetSlots As Integer

        'only use up to 7 target slots
        If _numberOfTargets < 8 Then
            targetSlots = _numberOfTargets - 1 'if the number of targets is less than 7, use that many slots
        Else
            targetSlots = 7
        End If

        If arcadePort.IsOpen Then
            For i = 0 To targetSlots
                If Not _targets(i).Enabled Then 'only attempt changing the address if the target is not enabled
                    arcadePort.Write(_targets(i).ChangeAddress(GetRandomNumberBetween(_numberOfTargets, 1)), 0, 4) 'change the target address
                    EnableTarget(i + 1) 'enable the target
                    Exit Sub
                End If
            Next
        End If
    End Sub

    '######_____Event Handlers______######

    ''' <summary>
    ''' When serial data is received, if the device is verified, handle the data. If the device is not verified, check for the verification
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SerialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles arcadePort.DataReceived
        Dim bytesToRead As Integer = arcadePort.BytesToRead
        Dim readBytes(bytesToRead - 1) As Byte

        If _verified Then
            If bytesToRead < 3 Then
                Exit Sub 'skip everything if the device is verified and there are not enough bytes to read
            End If
            'read three bytes at a time
            arcadePort.Read(readBytes, 0, 3)

            'based on the scoring player, raise the associated event
            Select Case readBytes(2)
                Case &H_01
                    RaiseEvent PlayerOneScore(readBytes(1))
                Case &H_02
                    RaiseEvent PlayerTwoScore(readBytes(1))
            End Select

            'if a hit target is in one of the target slots, set the target to disabled (slave automatically disabled it)
            For i = 0 To 7
                If _targets(i).I2CAddress = readBytes(1) Then
                    _targets(i).Enabled = False
                End If
            Next

        Else
            'if the device has not yet been verified, read the entire buffer and look for verification
            arcadePort.Read(readBytes, 0, bytesToRead)
            For i = 0 To bytesToRead - 1 'for every byte in the read
                If readBytes(i) = &H24 And i + 2 <= bytesToRead - 1 Then 'if the byte is a $ and there are two more bytes remaining to check
                    If readBytes(i + 1) = &H4C And readBytes(i + 2) = &H41 Then
                        _verified = True 'if the device verification is received, set _verified to True and exit the sub
                        Exit Sub
                    End If
                End If
            Next

            RequestVerification() 'if it was not verified again, request verification
        End If
    End Sub

    ''' <summary>
    ''' sends the RequestVerification command every 500ms when the verificationTimer is enabled. If device is verified, disable the timer
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub verificationTimer_Tick(sender As Object, e As EventArgs) Handles verificationTimer.Tick
        If _verified Then
            verificationTimer.Stop() 'if the master board COM has been verified, stop the verification timer.
        Else
            RequestVerification() 'send the request verification command
        End If
    End Sub

    ''' <summary>
    ''' If the device verification times out, raise the verification failed event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub connectionTimeoutTimer_Tick(sender As Object, e As EventArgs) Handles connectionTimeoutTimer.Tick
        If _verified Then
            connectionTimeoutTimer.Stop() 'if the master board COM was verified, stop the timeout
        Else
            EndConnection() 'end the connection, incorrect device
            RaiseEvent DeviceVerificationFailed("Device verification timed out. Please check the COM port.") 'raise the DeviceVerificationFailed event
        End If
    End Sub

    ''' <summary>
    ''' Disables a target when its disableTimer goes off.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DisableTimer_Tick(sender As Object, e As EventArgs)
        For i = 0 To 7 'scan through each target/timer
            If _disableTimers(i) Is sender Then 'if the current scan timer sent the tick
                DisableTarget(i + 1) 'disable the current scan timer
                Exit Sub
            End If
        Next
    End Sub
End Class
