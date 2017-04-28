Public Class Frm
    Private IsClick As Boolean
    Private IsCount As Boolean
    Private SelectedLocate As Point
    Private Time As Integer
    Private StrKill As String
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Dim Flag%
        Flag = MsgBox("do you want to exit?", vbYesNo + vbQuestion, "")
        If vbYes = Flag Then
            End
        Else
            LblShow.Focus()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormBorderStyle = FormBorderStyle.None
        IsClick = False
        Dim s As String = InputBox("please input the process name", "", "POWERPNT.EXE")
        StrKill = "taskkill /f /im " & s
        LblShow.Focus()
    End Sub
    Private Sub Mouse_Down(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        IsClick = True
        SelectedLocate = New Point(e.X, e.Y)
    End Sub
    Private Sub Mouse_Move(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If (True = IsClick) Then
            Me.Location = PointToScreen(New Point(e.X, e.Y)) - SelectedLocate
        End If
    End Sub
    Private Sub Mouse_Up(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        IsClick = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Time = Val(InputBox("Please Input The time (second)", "Time", "300"))
        Timer1.Enabled = True
        LblShow.Focus()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Time = Time - 1
        LblShow.Text = Str(Time)
        If (Time <= 0) Then
            Timer1.Enabled = False
            MsgBox("Time is up!", MsgBoxStyle.Critical + vbOKOnly + MsgBoxStyle.SystemModal, "")
            Shell(StrKill)
        End If

    End Sub
End Class
