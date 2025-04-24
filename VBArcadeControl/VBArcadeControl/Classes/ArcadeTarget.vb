Option Strict On
Option Explicit On

'Laser Arcade Project
'Andrew Keller
'Spring 2025
'https://github.com/AlexWheelock/Laser-Arcade-Project.git

Public Class ArcadeTarget

    '######______Class Properties and variables______######

    ''' <summary>
    ''' Stores the TargetSlot byte for the target
    ''' </summary>
    Private _targetSlot As Byte
    Public ReadOnly Property TargetSlot() As Byte
        Get
            Return _targetSlot
        End Get
    End Property

    Private _ready As Boolean
    ''' <summary>
    ''' Set high the first time the address is set for the target
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ReadyToEnable As Boolean
        Get
            Return _ready
        End Get
    End Property

    ''' <summary>
    ''' Stores whether or not a target is currently enabled
    ''' </summary>
    Private _enabled As Boolean
    Public Property Enabled() As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
        End Set
    End Property

    ''' <summary>
    ''' stores the i2C address of the target slot
    ''' </summary>
    Private _i2CAddress As Byte
    Public ReadOnly Property I2CAddress() As Byte
        Get
            Return _i2CAddress
        End Get
    End Property

    '######______Subroutines and Functions______######

    ''' <summary>
    ''' creates the target with a unique target slot
    ''' </summary>
    ''' <param name="slot"></param>
    Sub New(slot As Integer)

        'convert the slot number integer into a bit in the Target_Slot byte
        Select Case slot
            Case 1
                _targetSlot = &B_10000000
            Case 2
                _targetSlot = &B_01000000
            Case 3
                _targetSlot = &B_00100000
            Case 4
                _targetSlot = &B_00010000
            Case 5
                _targetSlot = &B_00001000
            Case 6
                _targetSlot = &B_00000100
            Case 7
                _targetSlot = &B_00000010
            Case 8
                _targetSlot = &B_00000001
        End Select

        _enabled = False
    End Sub

    ''' <summary>
    ''' changes the address of the slot to a new address represented by an integer
    ''' </summary>
    ''' <param name="newAddress"></param>
    ''' <returns></returns>
    Public Function ChangeAddress(newAddress As Integer) As Byte()
        Dim _command(3) As Byte
        _command(0) = &H24
        _command(1) = &H41
        _command(2) = _targetSlot
        _command(3) = CByte(newAddress * 2) 'multiply by two to shift the address left by one bit

        _ready = True

        Return _command
    End Function

    ''' <summary>
    ''' Returns a 3 byte array that commands the master to enable the set target slot
    ''' </summary>
    ''' <returns></returns>
    Public Function EnableTarget() As Byte()
        Dim _enableCommand(2) As Byte
        _enableCommand(0) = &H24 'handshake byte
        _enableCommand(1) = &H45 'enable command byte
        _enableCommand(2) = _targetSlot 'TargetSlot byte

        _enabled = True 'once the enable command is sent, set the target to enabled
        Return _enableCommand
    End Function

    ''' <summary>
    ''' Returns a 3 byte array that commands the master to disable the set target slot
    ''' </summary>
    ''' <returns></returns>
    Public Function DisableTarget() As Byte()
        Dim _disableCommand(2) As Byte
        _disableCommand(0) = &H24 'handshake byte
        _disableCommand(1) = &H44 'disable command byte
        _disableCommand(2) = _targetSlot 'target slog byte

        _enabled = False 'once the disable command is sent, set the target to disabled
        Return _disableCommand
    End Function
End Class
