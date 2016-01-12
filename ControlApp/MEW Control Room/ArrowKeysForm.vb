Public Class ArrowKeysForm

    Dim mainTimerInterval As Integer = 200

    Dim UpPressed As Boolean
    Dim DownPressed As Boolean
    Dim RightPressed As Boolean
    Dim LeftPressed As Boolean

    Private Sub ArrowKeysForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmMain.chkManualControl.CheckState = CheckState.Unchecked
    End Sub

    Private Sub picMain_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles picMain.GotFocus
        Me.Focus()
    End Sub

    Private Sub ArrowKeysForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyData = Keys.Up Then
            picUp.Visible = True
            UpPressed = True
        End If
        If e.KeyData = Keys.Down Then
            picDown.Visible = True
            DownPressed = True
        End If
        If e.KeyData = Keys.Right Then
            picRight.Visible = True
            RightPressed = True
        End If
        If e.KeyData = Keys.Left Then
            picLeft.Visible = True
            LeftPressed = True
        End If
    End Sub


    Private Sub ArrowKeysForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyData = Keys.Up Then
            picUp.Visible = False
            UpPressed = False
        End If
        If e.KeyData = Keys.Down Then
            picDown.Visible = False
            DownPressed = False
        End If
        If e.KeyData = Keys.Right Then
            picRight.Visible = False
            RightPressed = False
        End If
        If e.KeyData = Keys.Left Then
            picLeft.Visible = False
            LeftPressed = False
        End If
    End Sub

    Private Sub ArrowKeysForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        picUp.Visible = False
        picDown.Visible = False
        picRight.Visible = False
        picLeft.Visible = False
        timMain.Interval = mainTimerInterval
        timMain.Enabled = True
    End Sub

    Private Sub timMain_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timMain.Tick
        If UpPressed = True Then
            frmMain.SendDataNewLine("goup")
        ElseIf RightPressed = True Then
            frmMain.SendDataNewLine("goright")
        ElseIf LeftPressed = True Then
            frmMain.SendDataNewLine("goleft")
        End If
    End Sub
End Class