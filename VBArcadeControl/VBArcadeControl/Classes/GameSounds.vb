Public Class GameSounds

    Public Shared Sub HitSound()
        Dim RNG As Integer
        Dim RNG2 As Integer
        Randomize()
        RNG = System.Math.Floor(Rnd() * 100) + 0
        Randomize()
        RNG2 = System.Math.Floor(Rnd() * 100) + 0
        If RNG > 20 Then
            Try
                My.Computer.Audio.Play(My.Resources.SmashParry, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 10 Then
            If RNG2 > 50 Then
                Try
                    My.Computer.Audio.Play(My.Resources.FamilyFuedBell, AudioPlayMode.Background)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                Try
                    My.Computer.Audio.Play(My.Resources.CupParry, AudioPlayMode.Background)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        ElseIf RNG > 5 Then
            If RNG2 > 50 Then
                Try
                    My.Computer.Audio.Play(My.Resources.bomb_explode, AudioPlayMode.Background)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                Try
                    My.Computer.Audio.Play(My.Resources.Lego_Break_Fall_Apart, AudioPlayMode.Background)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Else
            If RNG2 > 60 Then
                Try
                    My.Computer.Audio.Play(My.Resources.TableBroken, AudioPlayMode.Background)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf RNG2 > 30 Then
                Try
                    My.Computer.Audio.Play(My.Resources.main90L, AudioPlayMode.Background)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                Try
                    My.Computer.Audio.Play(My.Resources.Wilhelm, AudioPlayMode.Background)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Public Shared Sub WinSound()
        Dim RNG As Integer
        Randomize()
        RNG = System.Math.Floor(Rnd() * 100) + 1
        If RNG > 20 Then
            Try
                My.Computer.Audio.Play(My.Resources.Chest_Item, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 15 Then
            Try
                My.Computer.Audio.Play(My.Resources.main74L, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 10 Then
            Try
                My.Computer.Audio.Play(My.Resources.PizzaTaunt, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 5 Then
            Try
                My.Computer.Audio.Play(My.Resources.SonicAdventure2LevelClear, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                My.Computer.Audio.Play(My.Resources.FDD, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Shared Sub LoseSound()
        Dim RNG As Integer
        Randomize()
        RNG = System.Math.Floor(Rnd() * 100) + 1
        If RNG > 30 Then
            Try
                My.Computer.Audio.Play(My.Resources.AwDangIt, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 25 Then
            Try
                My.Computer.Audio.Play(My.Resources.Miss, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 20 Then
            Try
                My.Computer.Audio.Play(My.Resources.Sad_Trumpet, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 15 Then
            Try
                My.Computer.Audio.Play(My.Resources.MegaManDies, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 10 Then
            Try
                My.Computer.Audio.Play(My.Resources.GoodDaySir, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 5 Then
            Try
                My.Computer.Audio.Play(My.Resources.MarioKartFNFDeath, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                My.Computer.Audio.Play(My.Resources.SadFahhhh, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Shared Sub ConfirmSound()
        Dim RNG As Integer
        Randomize()
        RNG = System.Math.Floor(Rnd() * 100) + 1
        If RNG > 75 Then
            Try
                My.Computer.Audio.Play(My.Resources.CSConfirm, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 50 Then
            Try
                My.Computer.Audio.Play(My.Resources.ConfirmMenu, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf RNG > 25 Then
            Try
                My.Computer.Audio.Play(My.Resources.WarpedAye, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                My.Computer.Audio.Play(My.Resources.main76L, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Shared Sub StartGameSound()
        Dim RNG As Integer
        Randomize()
        RNG = System.Math.Floor(Rnd() * 100) + 1
        If RNG > 50 Then
            Try
                My.Computer.Audio.Play(My.Resources.Start, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                My.Computer.Audio.Play(My.Resources.GoSmash, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Shared Sub SelectGameSound(Game As Integer)
        If Game = 1 Then
            Try
                My.Computer.Audio.Play(My.Resources.Announcer_Break_the_Targets, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                My.Computer.Audio.Play(My.Resources.main76L, AudioPlayMode.Background)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Public Shared Sub ConnectSound()
        Try
            My.Computer.Audio.Play(My.Resources.Connected, AudioPlayMode.Background)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
