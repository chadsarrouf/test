Public Class Race
    Dim amount_start As Double
    Dim amount_left As Double
    Dim bet As Double
    Dim round As Integer = 1
    Dim standings As New List(Of Integer)
    Dim winner_id As New Integer
    Dim s1 As Integer = 0 'speed for racer 1
    Dim s2 As Integer = 0
    Dim s3 As Integer = 0
    Dim s4 As Integer = 0
    Dim s5 As Integer = 0
    Dim f1 As Boolean = False 'if racer 1 is finished race
    Dim f2 As Boolean = False
    Dim f3 As Boolean = False
    Dim f4 As Boolean = False
    Dim f5 As Boolean = False

    Private Sub RestartGame()
        TextBox1.Text = 0
        TextBox2.Text = 0
        round = 1
        Label2.Text = round.ToString
        Dim amount As String
        Do
            amount = InputBox("Enter a starting amount", "Starting Capital")
        Loop Until IsNumeric(amount)

        TextBox1.Text = amount
        amount_start = CType(amount, Double)
        TextBox2.Text = amount
        amount_left = amount_start
    End Sub

    Private Sub RestartRace()
        f1 = False
        f2 = False
        f3 = False
        f4 = False
        f5 = False
        bet = 0
        standings.Clear()
        PictureBox1.Location = New Point(125, PictureBox1.Location.Y)
        PictureBox2.Location = New Point(175, PictureBox2.Location.Y)
        PictureBox3.Location = New Point(135, PictureBox3.Location.Y)
        PictureBox4.Location = New Point(125, PictureBox4.Location.Y)
        PictureBox5.Location = New Point(155, PictureBox5.Location.Y)
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        round += 1
        Label2.Text = round.ToString
        GroupBox1.Enabled = True
        TextBox3.Enabled = True
        TextBox3.Text = Nothing

    End Sub

    Private Sub DetermineStandings()
        Randomize()
        s1 = CInt(Math.Ceiling(Rnd() * 5) + 2)
        s2 = CInt(Math.Ceiling(Rnd() * 5) + 2)
        s3 = CInt(Math.Ceiling(Rnd() * 5) + 2)
        s4 = CInt(Math.Ceiling(Rnd() * 5) + 2)
        s5 = CInt(Math.Ceiling(Rnd() * 5) + 2)

        If s1 = s2 Or s1 = s3 Or s1 = s4 Or s1 = s5 Or s2 = s3 Or s2 = s4 Or s2 = s5 Or s3 = s4 Or s3 = s5 Or s4 = s5 Then
            DetermineStandings()
        Else
            standings.Add(s1)
            standings.Add(s2)
            standings.Add(s3)
            standings.Add(s4)
            standings.Add(s5)

            standings.Sort()

            Dim rank As Integer = 5
            For Each s In standings
                Select Case s
                    Case s1
                        Label8.Text = "Position: " + rank.ToString
                        If rank = 1 Then
                            winner_id = 1
                        End If
                    Case s2
                        Label9.Text = "Position: " + rank.ToString
                        If rank = 1 Then
                            winner_id = 2
                        End If
                    Case s3
                        Label10.Text = "Position: " + rank.ToString
                        If rank = 1 Then
                            winner_id = 3
                        End If
                    Case s4
                        Label11.Text = "Position: " + rank.ToString
                        If rank = 1 Then
                            winner_id = 4
                        End If
                    Case s5
                        Label12.Text = "Position: " + rank.ToString
                        If rank = 1 Then
                            winner_id = 5
                        End If
                End Select
                rank -= 1
            Next
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'start race
        bet = CType(TextBox3.Text, Double)
        amount_left = amount_left - bet
        TextBox2.Text = amount_left.ToString
        TextBox3.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        GroupBox1.Enabled = False
        DetermineStandings()
        Timer1.Enabled = True
        Timer2.Enabled = True
        Timer3.Enabled = True
        Timer4.Enabled = True
        Timer5.Enabled = True
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If Double.TryParse(TextBox3.Text, bet) Then
            If bet > amount_left And bet > 0 Then
                MsgBox("Please bet an amount you actually have.", MsgBoxStyle.OkOnly, "Input Error")
                TextBox3.Text = Nothing
                Button1.Enabled = False
            Else
                Button1.Enabled = True
            End If
        Else
            TextBox3.Text = Nothing
        End If
    End Sub

    Private Sub Race_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RestartGame()
    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs) Handles Timer1.Tick, Timer2.Tick, Timer3.Tick, Timer4.Tick, Timer5.Tick

        Dim timer As New Timer

        timer = CType(sender, Timer)

        Select Case timer.Tag
            Case 1
                If f1 Then
                    timer.Enabled = False
                    Label8.Visible = True
                Else
                    PictureBox1.Location = New Point(PictureBox1.Location.X + s1, PictureBox1.Location.Y)
                    If PictureBox1.Location.X >= 650 Then
                        f1 = True
                    End If
                End If
            Case 2
                If f2 Then
                    timer.Enabled = False
                    Label9.Visible = True
                Else
                    PictureBox2.Location = New Point(PictureBox2.Location.X + s2, PictureBox2.Location.Y)
                    If PictureBox2.Location.X >= 650 Then
                        f2 = True
                    End If
                End If
            Case 3
                If f3 Then
                    timer.Enabled = False
                    Label10.Visible = True
                Else
                    PictureBox3.Location = New Point(PictureBox3.Location.X + s3, PictureBox3.Location.Y)
                    If PictureBox3.Location.X >= 650 Then
                        f3 = True
                    End If
                End If
            Case 4
                If f4 Then
                    timer.Enabled = False
                    Label11.Visible = True
                Else
                    PictureBox4.Location = New Point(PictureBox4.Location.X + s4, PictureBox4.Location.Y)
                    If PictureBox4.Location.X >= 650 Then
                        f4 = True
                    End If
                End If
            Case 5
                If f5 Then
                    timer.Enabled = False
                    Label12.Visible = True
                Else
                    PictureBox5.Location = New Point(PictureBox5.Location.X + s5, PictureBox5.Location.Y)
                    If PictureBox5.Location.X >= 650 Then
                        f5 = True
                    End If
                End If
        End Select

        If Timer1.Enabled = False And Timer2.Enabled = False And Timer3.Enabled = False And Timer4.Enabled = False And Timer5.Enabled = False Then
            CleanUp()
        End If
    End Sub

    Private Sub CleanUp()
        For Each radio As RadioButton In GroupBox1.Controls
            If radio.Checked Then
                If radio.Tag = winner_id.ToString Then
                    amount_left = amount_left + (2 * bet)
                    TextBox2.Text = amount_left.ToString
                    MsgBox("1st place! Not bad.", MsgBoxStyle.OkOnly, "You won")
                Else
                    MsgBox("Tough cookie. Better luck next time.", MsgBoxStyle.OkOnly, "You lost")
                End If
            End If
        Next
        If amount_left = 0 Or round = 12 Then
            Dim profit As Double = amount_left - amount_start
            If profit > 0 Then
                MsgBox("Game over. You made " + profit.ToString + "$. Nice!", MsgBoxStyle.OkOnly, "Game Over")
            Else
                MsgBox("Game over. You lost " + profit.ToString + "$. Better luck next time.", MsgBoxStyle.OkOnly, "Game Over")
            End If

            Dim entry = MsgBox("Play Again?", MsgBoxStyle.YesNo, "Continue")
            If entry = MsgBoxResult.Yes Then
                RestartGame()
            Else
                MsgBox("Goodbye!", MsgBoxStyle.OkOnly, "Thanks for playing")
                Me.Close()
            End If
        End If
        RestartRace()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
