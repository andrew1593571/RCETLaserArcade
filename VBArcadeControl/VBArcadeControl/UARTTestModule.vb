Module UARTTestModule
    'This is a simple test module to demonstrate the UARTController class, can be removed/deleted.
    'To use:
    'Go to Project -> VBArcadeControl Properties -> Application -> Startup Form and set it to "UARTTestModule"
    'Deselect "Enable application framework"
    'Run the project and output will be shown in the console terminal
    'It's used to verify that the UART Controller class is working as expected
    Sub Main()
        Console.WriteLine("UART Test Module Starting...")

        Dim uart As New UARTController()

        AddHandler uart.ConnectOpen,
            Sub() Console.WriteLine("EVENT → Port Opened")

        AddHandler uart.ConnectClose,
            Sub() Console.WriteLine("EVENT → Port Closed")

        AddHandler uart.DeviceVerificationFailed,
            Sub(reason As String) Console.WriteLine("EVENT → Verification FAILED: " & reason)

        Console.WriteLine("Calling Connect(""COM5"")...")
        Dim ok As Boolean = uart.Connect("COM5")

        Console.WriteLine("RESULT:")
        Console.WriteLine("  Connect() returned: " & ok)
        Console.WriteLine("  DeviceVerified: " & uart.DeviceVerified)
        Console.WriteLine("  DeviceType: " & uart.DeviceType.ToString())

        Console.WriteLine()
        Console.WriteLine("Press ENTER to exit.")
        Console.ReadLine()
    End Sub

End Module


