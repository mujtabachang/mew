<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(262, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Multipurpose Enduring Watercraft"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(12, 27)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(138, 13)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Software Version: 0.3 Alpha"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(246, 153)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Programmed by:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ahmed Mujtaba [08 ES 22]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Project Members:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ahmed Mujtaba [08" & _
            " ES 22]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sara Qadeer [08 ES 01]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ahad Khan [08 ES 40]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Luna Talpur [08 ES 41]"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOk.Location = New System.Drawing.Point(306, 182)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(89, 30)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "&OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnOk
        Me.ClientSize = New System.Drawing.Size(407, 222)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
