Public Class About
    Dim SoftVersion As String = "0.3 Alpha"
    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblVersion.Text = "Software Version: " & SoftVersion
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Hide()
    End Sub
End Class