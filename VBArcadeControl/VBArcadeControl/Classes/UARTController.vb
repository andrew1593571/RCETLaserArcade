'→
'===============================
'UARTController Class
'
'This class is responsible ONLY for:
'  - Creating and configuring the SerialPort object
'  - Opening/closing the port
'  - Sending UART commands to the Laser Arcade system
'  - Receiving data and raising events
'
'This class does NOT contain game logic or score tracking.
'This class acts as a communication "driver" for the hardware
'===============================
Public Class UARTController

#Region "==============FIELDS/STATE==============="

    'Sets up Class-Level Serial Port Object
    Private serialPortJimmy As System.IO.Ports.SerialPort

    'Will be used to know what device is connected
    Public Enum ConnectedDeviceType
        None
        Master
        Slave
        Blaster
    End Enum

    'Internal command identifiers
    Private Enum UartCommand
        VerifyDevice        ' $V
        I2CWrite            ' $W
        I2CRead             ' $R
        ReadSettings        ' $S
        UpdatePlayerColor   ' $C
        CalibratePositions  ' $P
        UpdateLEDs          ' $L
        SetI2CSlaveAddress  ' $A
    End Enum

    'Creates a field to store the device type (None, Master, Slave, Blaster)
    Private _deviceType As ConnectedDeviceType = ConnectedDeviceType.None
    Public ReadOnly Property DeviceType As ConnectedDeviceType
        Get
            Return _deviceType
        End Get
    End Property

    'Flag to remember if the device has been verified
    Private _deviceVerified As Boolean = False
    Public ReadOnly Property DeviceVerified As Boolean
        Get
            Return _deviceVerified
        End Get
    End Property

    'Custom events
    Public Event DeviceVerificationFailed(reason As String)
    Public Event ConnectOpen()
    Public Event ConnectClose()

    'Invalid-command & invalid-address events
    Public Event UnsupportedCommand(commandName As String, device As ConnectedDeviceType)
    Public Event InvalidI2CAddress(address As Byte)

    'Track I2C address we last requested 
    Private _lastI2CReadAddress As Byte

    'ReadI2C parse result events
    Public Event I2CReadSuccess(address As Byte, data As Byte)    'Master success: $ R [data]
    Public Event I2CReadFailed(address As Byte, reason As Char)   'Unable ($U) or Failed ($F)
    Public Event I2CReadParseFailed(reason As String)             'Timeout or malformed

#End Region

#Region "==============CONSTRUCTOR==============="
    'This will run when someone creates a new UARTController
    'Instantiate the SerialPort object and set all default settings
    Public Sub New()
        serialPortJimmy = New IO.Ports.SerialPort()
        SetupSerialPort()
    End Sub

    'Config the serial port settings
    Sub SetupSerialPort()
        Me.serialPortJimmy.BaudRate = 2400
        Me.serialPortJimmy.DataBits = 8
        Me.serialPortJimmy.Parity = IO.Ports.Parity.None
        Me.serialPortJimmy.StopBits = IO.Ports.StopBits.One
    End Sub
#End Region

#Region "==============CONNECT METHODS==============="
    'Process:
    'Sets up the COMPORT name (ex. "COM3")
    'Opens the serial port
    'After open, sends the 'Device Verification command' "$V" PG.46
    'After send, wait for the response "$LA" (4 BYTES)
    'If the response Is valid → mark device As verified
    'If anything goes wrong → close port and raise DeviceVerificationFailed event

    Public Function Connect(portName As String) As Boolean
        'Reset states each time a connection is attempted
        _deviceVerified = False
        _deviceType = ConnectedDeviceType.None

        'Assure Serial Port exists and is configured
        If serialPortJimmy Is Nothing Then
            serialPortJimmy = New IO.Ports.SerialPort()
            SetupSerialPort()
        End If

        Try
            'If the serial port was open before, close it cleanly
            If serialPortJimmy.IsOpen Then
                serialPortJimmy.Close()
                RaiseEvent ConnectClose()
            End If

            'Set COM port name (e.g., "COM3")
            serialPortJimmy.PortName = portName

            'Set timeouts so we don't block forever during verification
            serialPortJimmy.ReadTimeout = 500   'ms – adjust as needed
            serialPortJimmy.WriteTimeout = 500  'ms – adjust as needed

            'Open the serial port
            serialPortJimmy.Open()
            RaiseEvent ConnectOpen()

            '====Send Device Verification: "$V====
            'This will transmit 2 bytes: "$" & "V"
            serialPortJimmy.Write("$V")

            '====Read 4-byte verification response====

            'Expected Bytes:
            '$ L A B  → Blaster
            '$ L A M  → Master
            '$ L A S  → Slave

            Dim response(3) As Byte
            Dim bytesRead As Integer = 0

            While bytesRead < 4
                Dim b As Integer

                Try
                    b = serialPortJimmy.ReadByte() 'blocks until byte or timeout
                Catch ex As TimeoutException
                    Exit While 'stop trying if we timed out
                End Try

                If b = -1 Then
                    Exit While 'no more data
                End If

                response(bytesRead) = CByte(b)
                bytesRead += 1
            End While

            'If we did not get exactly 4 bytes, verification failed
            If bytesRead <> 4 Then
                Throw New ApplicationException("Incomplete verification response.")
            End If

            'Check the header "$ L A"
            If response(0) <> Asc("$"c) OrElse
               response(1) <> Asc("L"c) OrElse
               response(2) <> Asc("A"c) Then

                Throw New ApplicationException("Invalid verification header.")
            End If

            'Determine device type based on 4th byte (B/M/S)
            Dim typeChar As Char = Chr(response(3))

            Select Case typeChar
                Case "B"c
                    _deviceType = ConnectedDeviceType.Blaster
                Case "M"c
                    _deviceType = ConnectedDeviceType.Master
                Case "S"c
                    _deviceType = ConnectedDeviceType.Slave
                Case Else
                    Throw New ApplicationException("Unknown device type character: " & typeChar)
            End Select

            'If we reach here, verification was successful
            _deviceVerified = True
            Return True

        Catch ex As Exception
            'Anything goes wrong → clean up and raise failure event
            _deviceVerified = False
            _deviceType = ConnectedDeviceType.None

            If serialPortJimmy IsNot Nothing AndAlso serialPortJimmy.IsOpen Then
                serialPortJimmy.Close()
                RaiseEvent ConnectClose()
            End If

            RaiseEvent DeviceVerificationFailed(ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region "==============ASSIGN DEVICE COMMANDS=============="
    'This block is responsible for retrieving a command
    'Then we return true if/only if the device can use the command

    'Return a readable command name ("$W")
    Private Function GetCommandName(cmd As UartCommand) As String
        Select Case cmd
            Case UartCommand.VerifyDevice : Return "$V"
            Case UartCommand.I2CWrite : Return "$W"
            Case UartCommand.I2CRead : Return "$R"
            Case UartCommand.ReadSettings : Return "$S"
            Case UartCommand.UpdatePlayerColor : Return "$C"
            Case UartCommand.CalibratePositions : Return "$P"
            Case UartCommand.UpdateLEDs : Return "$L"
            Case UartCommand.SetI2CSlaveAddress : Return "$A"
            Case Else : Return cmd.ToString()
        End Select
    End Function

    'Return True if the currently device is allowed to use the command
    Private Function DeviceSupportsCommand(cmd As UartCommand) As Boolean
        Select Case _deviceType

            Case ConnectedDeviceType.Master
                'Master only: I2C Write, I2C Read
                'All devices: Update Player Color
                Select Case cmd
                    Case UartCommand.VerifyDevice,
                         UartCommand.I2CWrite,
                         UartCommand.I2CRead,
                         UartCommand.UpdatePlayerColor
                        Return True
                End Select

            Case ConnectedDeviceType.Slave
                'Slave only: Calibrate Positions, Update LEDs
                'Slave + Blaster: Read Settings
                'All devices: Update Player Color
                'New Addition: Set I2C Slave Address
                Select Case cmd
                    Case UartCommand.VerifyDevice,
                         UartCommand.ReadSettings,
                         UartCommand.UpdatePlayerColor,
                         UartCommand.CalibratePositions,
                         UartCommand.UpdateLEDs,
                        UartCommand.SetI2CSlaveAddress
                        Return True
                End Select

            Case ConnectedDeviceType.Blaster
                'Slave + Blaster: Read Settings
                'All devices: Update Player Color
                Select Case cmd
                    Case UartCommand.VerifyDevice,
                         UartCommand.ReadSettings,
                         UartCommand.UpdatePlayerColor
                        Return True
                End Select

            Case ConnectedDeviceType.None
                'No device / not verified yet then nothing allowed
                Return False

        End Select

        Return False
    End Function
#End Region

#Region "==============GUARD FOR ALL COMMAND SEND METHODS=============="
    'This is acting as a prerequisite check before sending any command
    'It checks: 
    '  - Device is verified
    '  - Serial port is open
    '  - Device supports the command
    Private Function EnsureCanSend(cmd As UartCommand) As Boolean
        'Must be verified first
        If Not _deviceVerified Then
            RaiseEvent DeviceVerificationFailed(
                "Cannot send " & GetCommandName(cmd) & " – device not verified.")
            Return False
        End If

        'Serial port must be open
        If serialPortJimmy Is Nothing OrElse Not serialPortJimmy.IsOpen Then
            RaiseEvent DeviceVerificationFailed(
                "Cannot send " & GetCommandName(cmd) & " – serial port not open.")
            Return False
        End If

        'Device must support this command
        If Not DeviceSupportsCommand(cmd) Then
            RaiseEvent UnsupportedCommand(GetCommandName(cmd), _deviceType)
            Return False
        End If

        Return True
    End Function

    'Small helper to send UART packet
    Private Sub SendPacket(ParamArray bytes() As Byte)
        serialPortJimmy.Write(bytes, 0, bytes.Length)
    End Sub
#End Region

#Region "==============COMMAND SEND METHODS==============="

    '====MASTER: $W addr data====

    Public Sub SendI2CWrite(addr As Byte, data As Byte)
        'Address must be in 7-bit range
        If addr > 127 Then
            RaiseEvent InvalidI2CAddress(addr)
            Exit Sub
        End If

        'Check verification, port state, and device support
        If Not EnsureCanSend(UartCommand.I2CWrite) Then Exit Sub

        'Packet: "$W" + addr + data
        SendPacket(
            Asc("$"c),
            Asc("W"c),
            addr,
            data)
    End Sub


    '====MASTER: $R addr====

    Public Sub SendI2CRead(addr As Byte)
        If addr > 127 Then
            RaiseEvent InvalidI2CAddress(addr)
            Exit Sub
        End If

        If Not EnsureCanSend(UartCommand.I2CRead) Then Exit Sub

        'Remember the address we are requesting
        _lastI2CReadAddress = addr

    End Sub


    '====SLAVE/BLASTER: $S====
    'Only used for trouble shooting, not normally used in operation
    'Only in the calibration menu
    'Read current settings for troubleshooting

    'IMPORTANT:
    'THIS SECTION ONLY SENDS A READ SETTINGS COMMAND IT CURRENTLY
    'DOES NOT RECEIVE THE RESPONSE, TO MAKE THINGS EASIER,
    'DUMP THE DATA INTO CONFIG. DONT TRY TO PARSE DATA HERE

    Public Sub SendReadSettings()
        If Not EnsureCanSend(UartCommand.ReadSettings) Then Exit Sub

        'Packet: "$S"
        SendPacket(
            Asc("$"c),
            Asc("S"c))
    End Sub

    '====SLAVE ONLY: $P f hi lo====
    Public Sub SendCalibratePositions(flags As Byte, hi As Byte, lo As Byte)
        If Not EnsureCanSend(UartCommand.CalibratePositions) Then Exit Sub

        'Packet: "$P" + flags + hi + lo
        SendPacket(
            Asc("$"c),
            Asc("P"c),
            flags,
            hi,
            lo)
    End Sub


    '====SLAVE ONLY: $L n====
    Public Sub SendUpdateLEDs(ledCount As Byte)
        If Not EnsureCanSend(UartCommand.UpdateLEDs) Then Exit Sub

        'Packet: "$L" + ledCount
        SendPacket(
            Asc("$"c),
            Asc("L"c),
            ledCount)
    End Sub

    Public Sub SendI2CSlaveAddress(newAddress As Byte)
        'Address must be in 7-bit range
        If newAddress < 1 OrElse newAddress > 127 Then
            RaiseEvent InvalidI2CAddress(newAddress)
            Exit Sub
        End If

        'Check verification, port state, and device support
        If Not EnsureCanSend(UartCommand.SetI2CSlaveAddress) Then Exit Sub
        'Packet: "$A" + newAddress
        SendPacket(
            Asc("$"c),
            Asc("A"c),
            newAddress)
    End Sub

    '====ALL DEVICES: $C p G R B====
    Public Sub SendUpdatePlayerColor(player As Byte, g As Byte, r As Byte, b As Byte)
        If Not EnsureCanSend(UartCommand.UpdatePlayerColor) Then Exit Sub

        'Packet: "$C" + player + G + R + B
        SendPacket(
            Asc("$"c),
            Asc("C"c),
            player,
            g,
            r,
            b)
    End Sub
#End Region

#Region "==============DATA PARSING==============="

#End Region
End Class
