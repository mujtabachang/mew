<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArrowKeysForm
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
        Me.components = New System.ComponentModel.Container
        Me.timMain = New System.Windows.Forms.Timer(Me.components)
        Me.picUp = New System.Windows.Forms.PictureBox
        Me.picDown = New System.Windows.Forms.PictureBox
        Me.picRight = New System.Windows.Forms.PictureBox
        Me.picLeft = New System.Windows.Forms.PictureBox
        Me.picMain = New System.Windows.Forms.PictureBox
        CType(Me.picUp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLeft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'timMain
        '
        Me.timMain.Interval = 250
        '
        'picUp
        '
        Me.picUp.Image = Global.MEW_Control_Station.My.Resources.Resources.UpPressed
        Me.picUp.Location = New System.Drawing.Point(50, 11)
        Me.picUp.Name = "picUp"
        Me.picUp.Size = New System.Drawing.Size(49, 43)
        Me.picUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picUp.TabIndex = 1
        Me.picUp.TabStop = False
        '
        'picDown
        '
        Me.picDown.Image = Global.MEW_Control_Station.My.Resources.Resources.DownPressed
        Me.picDown.Location = New System.Drawing.Point(53, 54)
        Me.picDown.Name = "picDown"
        Me.picDown.Size = New System.Drawing.Size(43, 44)
        Me.picDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picDown.TabIndex = 3
        Me.picDown.TabStop = False
        '
        'picRight
        '
        Me.picRight.Image = Global.MEW_Control_Station.My.Resources.Resources.RightPressed
        Me.picRight.Location = New System.Drawing.Point(95, 51)
        Me.picRight.Name = "picRight"
        Me.picRight.Size = New System.Drawing.Size(43, 49)
        Me.picRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picRight.TabIndex = 4
        Me.picRight.TabStop = False
        '
        'picLeft
        '
        Me.picLeft.Image = Global.MEW_Control_Station.My.Resources.Resources.LeftPressed
        Me.picLeft.Location = New System.Drawing.Point(8, 53)
        Me.picLeft.Name = "picLeft"
        Me.picLeft.Size = New System.Drawing.Size(45, 45)
        Me.picLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picLeft.TabIndex = 2
        Me.picLeft.TabStop = False
        '
        'picMain
        '
        Me.picMain.Image = Global.MEW_Control_Station.My.Resources.Resources.ArrowKeysSmall
        Me.picMain.Location = New System.Drawing.Point(0, 0)
        Me.picMain.Name = "picMain"
        Me.picMain.Size = New System.Drawing.Size(150, 112)
        Me.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picMain.TabIndex = 0
        Me.picMain.TabStop = False
        '
        'ArrowKeysForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(148, 110)
        Me.Controls.Add(Me.picUp)
        Me.Controls.Add(Me.picDown)
        Me.Controls.Add(Me.picRight)
        Me.Controls.Add(Me.picLeft)
        Me.Controls.Add(Me.picMain)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.MEW_Control_Station.My.MySettings.Default, "ArrowKeysLocation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = Global.MEW_Control_Station.My.MySettings.Default.ArrowKeysLocation
        Me.Name = "ArrowKeysForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Control Keys"
        Me.TopMost = True
        CType(Me.picUp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLeft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents picMain As System.Windows.Forms.PictureBox
    Friend WithEvents picUp As System.Windows.Forms.PictureBox
    Friend WithEvents picLeft As System.Windows.Forms.PictureBox
    Friend WithEvents picDown As System.Windows.Forms.PictureBox
    Friend WithEvents picRight As System.Windows.Forms.PictureBox
    Friend WithEvents timMain As System.Windows.Forms.Timer
End Class
