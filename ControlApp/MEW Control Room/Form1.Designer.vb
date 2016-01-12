<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim Map1 As Pegazux.Controls.GoogleMaps.Map = New Pegazux.Controls.GoogleMaps.Map
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GMap = New Pegazux.Controls.GoogleMaps.GoogleMapsControl
        Me.pMap = New System.Windows.Forms.Panel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.wp_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.wp_lat = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.wp_lon = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WaypointName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pMonitoring = New System.Windows.Forms.Panel
        Me.pInstruments = New System.Windows.Forms.Panel
        Me.picAlert = New System.Windows.Forms.PictureBox
        Me.chkManualControl = New System.Windows.Forms.CheckBox
        Me.lblGPSCourse = New System.Windows.Forms.Label
        Me.lblMyMode = New System.Windows.Forms.Label
        Me.PicSpeed = New System.Windows.Forms.PictureBox
        Me.PicPitch = New System.Windows.Forms.PictureBox
        Me.PicRoll = New System.Windows.Forms.PictureBox
        Me.PicCompass = New System.Windows.Forms.PictureBox
        Me.lblRollPitch = New System.Windows.Forms.Label
        Me.lblDistanceCovered = New System.Windows.Forms.Label
        Me.lblWaterTemp = New System.Windows.Forms.Label
        Me.lblHullTemp = New System.Windows.Forms.Label
        Me.lblRemainingPower = New System.Windows.Forms.Label
        Me.lblSolarPanelVolt = New System.Windows.Forms.Label
        Me.lblMotorSpeeds = New System.Windows.Forms.Label
        Me.lblLatLong = New System.Windows.Forms.Label
        Me.lblSpeed = New System.Windows.Forms.Label
        Me.lblCurrentWaypoint = New System.Windows.Forms.Label
        Me.lblTargetHeading = New System.Windows.Forms.Label
        Me.lblCurrentHeading = New System.Windows.Forms.Label
        Me.lblPowerSavingMode = New System.Windows.Forms.Label
        Me.lblBattery = New System.Windows.Forms.Label
        Me.wbMap = New System.Windows.Forms.WebBrowser
        Me.pConfig = New System.Windows.Forms.Panel
        Me.txtSerialData = New System.Windows.Forms.TextBox
        Me.txtSerialInput = New System.Windows.Forms.TextBox
        Me.sPort = New System.IO.Ports.SerialPort(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MissionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadLastViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveNavigationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintNavigationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutMEWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.timConnectedShow = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.timTelRecShow = New System.Windows.Forms.Timer(Me.components)
        Me.timAlertBlink = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.timTelemetry = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.statuslabelConnect = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.cmbView = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.cboPorts = New System.Windows.Forms.ToolStripComboBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.btnConnect = New System.Windows.Forms.ToolStripButton
        Me.btnClearWaypoints = New System.Windows.Forms.ToolStripButton
        Me.btnUploadWaypoints = New System.Windows.Forms.ToolStripButton
        Me.btnSameViewinMap = New System.Windows.Forms.ToolStripButton
        Me.chkAutoCenter2 = New System.Windows.Forms.ToolStripButton
        Me.btnTelemetry2 = New System.Windows.Forms.ToolStripButton
        Me.btnTel = New System.Windows.Forms.ToolStripDropDownButton
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.QuaterOfASecondToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HalfASecondToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem
        Me.pMap.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pMonitoring.SuspendLayout()
        Me.pInstruments.SuspendLayout()
        CType(Me.picAlert, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPitch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicRoll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicCompass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pConfig.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GMap
        '
        Me.GMap.BackColor = System.Drawing.Color.White
        Me.GMap.Dock = System.Windows.Forms.DockStyle.Top
        Me.GMap.Location = New System.Drawing.Point(0, 0)
        Map1.AddMarkerOnClick = False
        Map1.Bounds = Nothing
        Map1.CenterMapOnClick = False
        Map1.Parent = Me.GMap
        Map1.UseMarkerClusterer = False
        Me.GMap.Map = Map1
        Me.GMap.Name = "GMap"
        Me.GMap.Size = New System.Drawing.Size(721, 538)
        Me.GMap.TabIndex = 5
        '
        'pMap
        '
        Me.pMap.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pMap.Controls.Add(Me.DataGridView1)
        Me.pMap.Controls.Add(Me.GMap)
        Me.pMap.Location = New System.Drawing.Point(928, 284)
        Me.pMap.Name = "pMap"
        Me.pMap.Size = New System.Drawing.Size(721, 585)
        Me.pMap.TabIndex = 5
        Me.pMap.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.wp_id, Me.wp_lat, Me.wp_lon, Me.WaypointName})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataGridView1.GridColor = System.Drawing.Color.Gainsboro
        Me.DataGridView1.Location = New System.Drawing.Point(0, 445)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Size = New System.Drawing.Size(721, 140)
        Me.DataGridView1.TabIndex = 0
        '
        'wp_id
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        Me.wp_id.DefaultCellStyle = DataGridViewCellStyle1
        Me.wp_id.HeaderText = "Waypoint ID"
        Me.wp_id.Name = "wp_id"
        Me.wp_id.ReadOnly = True
        '
        'wp_lat
        '
        Me.wp_lat.HeaderText = "Latitude"
        Me.wp_lat.Name = "wp_lat"
        '
        'wp_lon
        '
        Me.wp_lon.HeaderText = "Longitude"
        Me.wp_lon.Name = "wp_lon"
        '
        'WaypointName
        '
        Me.WaypointName.HeaderText = "Name"
        Me.WaypointName.Name = "WaypointName"
        '
        'pMonitoring
        '
        Me.pMonitoring.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pMonitoring.Controls.Add(Me.pInstruments)
        Me.pMonitoring.Controls.Add(Me.wbMap)
        Me.pMonitoring.Location = New System.Drawing.Point(12, 52)
        Me.pMonitoring.Name = "pMonitoring"
        Me.pMonitoring.Size = New System.Drawing.Size(873, 640)
        Me.pMonitoring.TabIndex = 7
        '
        'pInstruments
        '
        Me.pInstruments.Controls.Add(Me.picAlert)
        Me.pInstruments.Controls.Add(Me.chkManualControl)
        Me.pInstruments.Controls.Add(Me.lblGPSCourse)
        Me.pInstruments.Controls.Add(Me.lblMyMode)
        Me.pInstruments.Controls.Add(Me.PicSpeed)
        Me.pInstruments.Controls.Add(Me.PicPitch)
        Me.pInstruments.Controls.Add(Me.PicRoll)
        Me.pInstruments.Controls.Add(Me.PicCompass)
        Me.pInstruments.Controls.Add(Me.lblRollPitch)
        Me.pInstruments.Controls.Add(Me.lblDistanceCovered)
        Me.pInstruments.Controls.Add(Me.lblWaterTemp)
        Me.pInstruments.Controls.Add(Me.lblHullTemp)
        Me.pInstruments.Controls.Add(Me.lblRemainingPower)
        Me.pInstruments.Controls.Add(Me.lblSolarPanelVolt)
        Me.pInstruments.Controls.Add(Me.lblMotorSpeeds)
        Me.pInstruments.Controls.Add(Me.lblLatLong)
        Me.pInstruments.Controls.Add(Me.lblSpeed)
        Me.pInstruments.Controls.Add(Me.lblCurrentWaypoint)
        Me.pInstruments.Controls.Add(Me.lblTargetHeading)
        Me.pInstruments.Controls.Add(Me.lblCurrentHeading)
        Me.pInstruments.Controls.Add(Me.lblPowerSavingMode)
        Me.pInstruments.Controls.Add(Me.lblBattery)
        Me.pInstruments.Dock = System.Windows.Forms.DockStyle.Right
        Me.pInstruments.Location = New System.Drawing.Point(269, 0)
        Me.pInstruments.Name = "pInstruments"
        Me.pInstruments.Size = New System.Drawing.Size(602, 638)
        Me.pInstruments.TabIndex = 39
        '
        'picAlert
        '
        Me.picAlert.Image = CType(resources.GetObject("picAlert.Image"), System.Drawing.Image)
        Me.picAlert.Location = New System.Drawing.Point(428, 611)
        Me.picAlert.Name = "picAlert"
        Me.picAlert.Size = New System.Drawing.Size(16, 16)
        Me.picAlert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picAlert.TabIndex = 63
        Me.picAlert.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picAlert, "Telemetry is outdated")
        Me.picAlert.Visible = False
        '
        'chkManualControl
        '
        Me.chkManualControl.Image = Global.MEW_Control_Station.My.Resources.Resources.joystick
        Me.chkManualControl.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkManualControl.Location = New System.Drawing.Point(284, 612)
        Me.chkManualControl.Name = "chkManualControl"
        Me.chkManualControl.Size = New System.Drawing.Size(113, 18)
        Me.chkManualControl.TabIndex = 62
        Me.chkManualControl.Text = "Manual Control"
        Me.chkManualControl.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkManualControl.UseVisualStyleBackColor = True
        '
        'lblGPSCourse
        '
        Me.lblGPSCourse.AutoSize = True
        Me.lblGPSCourse.ForeColor = System.Drawing.Color.White
        Me.lblGPSCourse.Location = New System.Drawing.Point(24, 541)
        Me.lblGPSCourse.Name = "lblGPSCourse"
        Me.lblGPSCourse.Size = New System.Drawing.Size(70, 13)
        Me.lblGPSCourse.TabIndex = 61
        Me.lblGPSCourse.Text = "GPS Course: "
        '
        'lblMyMode
        '
        Me.lblMyMode.AutoSize = True
        Me.lblMyMode.ForeColor = System.Drawing.Color.White
        Me.lblMyMode.Location = New System.Drawing.Point(24, 554)
        Me.lblMyMode.Name = "lblMyMode"
        Me.lblMyMode.Size = New System.Drawing.Size(77, 13)
        Me.lblMyMode.TabIndex = 60
        Me.lblMyMode.Text = "Current Mode:"
        '
        'PicSpeed
        '
        Me.PicSpeed.Location = New System.Drawing.Point(243, 11)
        Me.PicSpeed.Name = "PicSpeed"
        Me.PicSpeed.Size = New System.Drawing.Size(222, 230)
        Me.PicSpeed.TabIndex = 58
        Me.PicSpeed.TabStop = False
        '
        'PicPitch
        '
        Me.PicPitch.Location = New System.Drawing.Point(15, 247)
        Me.PicPitch.Name = "PicPitch"
        Me.PicPitch.Size = New System.Drawing.Size(222, 230)
        Me.PicPitch.TabIndex = 57
        Me.PicPitch.TabStop = False
        '
        'PicRoll
        '
        Me.PicRoll.Location = New System.Drawing.Point(243, 247)
        Me.PicRoll.Name = "PicRoll"
        Me.PicRoll.Size = New System.Drawing.Size(222, 230)
        Me.PicRoll.TabIndex = 56
        Me.PicRoll.TabStop = False
        '
        'PicCompass
        '
        Me.PicCompass.Location = New System.Drawing.Point(15, 11)
        Me.PicCompass.Name = "PicCompass"
        Me.PicCompass.Size = New System.Drawing.Size(222, 230)
        Me.PicCompass.TabIndex = 55
        Me.PicCompass.TabStop = False
        '
        'lblRollPitch
        '
        Me.lblRollPitch.AutoSize = True
        Me.lblRollPitch.ForeColor = System.Drawing.Color.White
        Me.lblRollPitch.Location = New System.Drawing.Point(24, 528)
        Me.lblRollPitch.Name = "lblRollPitch"
        Me.lblRollPitch.Size = New System.Drawing.Size(78, 13)
        Me.lblRollPitch.TabIndex = 54
        Me.lblRollPitch.Text = "Roll and Pitch: "
        '
        'lblDistanceCovered
        '
        Me.lblDistanceCovered.AutoSize = True
        Me.lblDistanceCovered.ForeColor = System.Drawing.Color.Gray
        Me.lblDistanceCovered.Location = New System.Drawing.Point(24, 602)
        Me.lblDistanceCovered.Name = "lblDistanceCovered"
        Me.lblDistanceCovered.Size = New System.Drawing.Size(119, 13)
        Me.lblDistanceCovered.TabIndex = 53
        Me.lblDistanceCovered.Text = "Distance Covered: 46m"
        Me.lblDistanceCovered.Visible = False
        '
        'lblWaterTemp
        '
        Me.lblWaterTemp.AutoSize = True
        Me.lblWaterTemp.ForeColor = System.Drawing.Color.White
        Me.lblWaterTemp.Location = New System.Drawing.Point(24, 515)
        Me.lblWaterTemp.Name = "lblWaterTemp"
        Me.lblWaterTemp.Size = New System.Drawing.Size(109, 13)
        Me.lblWaterTemp.TabIndex = 52
        Me.lblWaterTemp.Text = "Water Temperature: "
        '
        'lblHullTemp
        '
        Me.lblHullTemp.AutoSize = True
        Me.lblHullTemp.ForeColor = System.Drawing.Color.White
        Me.lblHullTemp.Location = New System.Drawing.Point(24, 502)
        Me.lblHullTemp.Name = "lblHullTemp"
        Me.lblHullTemp.Size = New System.Drawing.Size(96, 13)
        Me.lblHullTemp.TabIndex = 51
        Me.lblHullTemp.Text = "Hull Temperature: "
        '
        'lblRemainingPower
        '
        Me.lblRemainingPower.AutoSize = True
        Me.lblRemainingPower.ForeColor = System.Drawing.Color.Gray
        Me.lblRemainingPower.Location = New System.Drawing.Point(24, 589)
        Me.lblRemainingPower.Name = "lblRemainingPower"
        Me.lblRemainingPower.Size = New System.Drawing.Size(185, 13)
        Me.lblRemainingPower.TabIndex = 50
        Me.lblRemainingPower.Text = "Remaining Power to Last for: 5 hours"
        Me.lblRemainingPower.Visible = False
        '
        'lblSolarPanelVolt
        '
        Me.lblSolarPanelVolt.AutoSize = True
        Me.lblSolarPanelVolt.ForeColor = System.Drawing.Color.White
        Me.lblSolarPanelVolt.Location = New System.Drawing.Point(283, 500)
        Me.lblSolarPanelVolt.Name = "lblSolarPanelVolt"
        Me.lblSolarPanelVolt.Size = New System.Drawing.Size(103, 13)
        Me.lblSolarPanelVolt.TabIndex = 49
        Me.lblSolarPanelVolt.Text = "Solar Panel Voltage:"
        '
        'lblMotorSpeeds
        '
        Me.lblMotorSpeeds.AutoSize = True
        Me.lblMotorSpeeds.ForeColor = System.Drawing.Color.White
        Me.lblMotorSpeeds.Location = New System.Drawing.Point(24, 489)
        Me.lblMotorSpeeds.Name = "lblMotorSpeeds"
        Me.lblMotorSpeeds.Size = New System.Drawing.Size(77, 13)
        Me.lblMotorSpeeds.TabIndex = 48
        Me.lblMotorSpeeds.Text = "Motor Speeds:"
        '
        'lblLatLong
        '
        Me.lblLatLong.AutoSize = True
        Me.lblLatLong.ForeColor = System.Drawing.Color.White
        Me.lblLatLong.Location = New System.Drawing.Point(283, 565)
        Me.lblLatLong.Name = "lblLatLong"
        Me.lblLatLong.Size = New System.Drawing.Size(56, 13)
        Me.lblLatLong.TabIndex = 45
        Me.lblLatLong.Text = "Lat/Long: "
        '
        'lblSpeed
        '
        Me.lblSpeed.AutoSize = True
        Me.lblSpeed.ForeColor = System.Drawing.Color.White
        Me.lblSpeed.Location = New System.Drawing.Point(283, 552)
        Me.lblSpeed.Name = "lblSpeed"
        Me.lblSpeed.Size = New System.Drawing.Size(44, 13)
        Me.lblSpeed.TabIndex = 44
        Me.lblSpeed.Text = "Speed: "
        '
        'lblCurrentWaypoint
        '
        Me.lblCurrentWaypoint.AutoSize = True
        Me.lblCurrentWaypoint.ForeColor = System.Drawing.Color.White
        Me.lblCurrentWaypoint.Location = New System.Drawing.Point(283, 539)
        Me.lblCurrentWaypoint.Name = "lblCurrentWaypoint"
        Me.lblCurrentWaypoint.Size = New System.Drawing.Size(100, 13)
        Me.lblCurrentWaypoint.TabIndex = 43
        Me.lblCurrentWaypoint.Text = "Current Waypoint: "
        '
        'lblTargetHeading
        '
        Me.lblTargetHeading.AutoSize = True
        Me.lblTargetHeading.ForeColor = System.Drawing.Color.White
        Me.lblTargetHeading.Location = New System.Drawing.Point(283, 526)
        Me.lblTargetHeading.Name = "lblTargetHeading"
        Me.lblTargetHeading.Size = New System.Drawing.Size(88, 13)
        Me.lblTargetHeading.TabIndex = 42
        Me.lblTargetHeading.Text = "Target Heading: "
        '
        'lblCurrentHeading
        '
        Me.lblCurrentHeading.AutoSize = True
        Me.lblCurrentHeading.ForeColor = System.Drawing.Color.White
        Me.lblCurrentHeading.Location = New System.Drawing.Point(283, 513)
        Me.lblCurrentHeading.Name = "lblCurrentHeading"
        Me.lblCurrentHeading.Size = New System.Drawing.Size(90, 13)
        Me.lblCurrentHeading.TabIndex = 41
        Me.lblCurrentHeading.Text = "Current Heading:"
        '
        'lblPowerSavingMode
        '
        Me.lblPowerSavingMode.AutoSize = True
        Me.lblPowerSavingMode.ForeColor = System.Drawing.Color.White
        Me.lblPowerSavingMode.Location = New System.Drawing.Point(283, 578)
        Me.lblPowerSavingMode.Name = "lblPowerSavingMode"
        Me.lblPowerSavingMode.Size = New System.Drawing.Size(105, 13)
        Me.lblPowerSavingMode.TabIndex = 40
        Me.lblPowerSavingMode.Text = "Power Saving Mode:"
        '
        'lblBattery
        '
        Me.lblBattery.AutoSize = True
        Me.lblBattery.ForeColor = System.Drawing.Color.White
        Me.lblBattery.Location = New System.Drawing.Point(283, 487)
        Me.lblBattery.Name = "lblBattery"
        Me.lblBattery.Size = New System.Drawing.Size(89, 13)
        Me.lblBattery.TabIndex = 39
        Me.lblBattery.Text = "Battery Voltage: "
        '
        'wbMap
        '
        Me.wbMap.AllowWebBrowserDrop = False
        Me.wbMap.Dock = System.Windows.Forms.DockStyle.Left
        Me.wbMap.Location = New System.Drawing.Point(0, 0)
        Me.wbMap.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbMap.Name = "wbMap"
        Me.wbMap.Size = New System.Drawing.Size(247, 638)
        Me.wbMap.TabIndex = 35
        Me.wbMap.Url = New System.Uri("", System.UriKind.Relative)
        '
        'pConfig
        '
        Me.pConfig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pConfig.Controls.Add(Me.txtSerialData)
        Me.pConfig.Controls.Add(Me.txtSerialInput)
        Me.pConfig.Location = New System.Drawing.Point(845, 605)
        Me.pConfig.Name = "pConfig"
        Me.pConfig.Size = New System.Drawing.Size(119, 116)
        Me.pConfig.TabIndex = 8
        Me.pConfig.Visible = False
        '
        'txtSerialData
        '
        Me.txtSerialData.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtSerialData.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialData.Location = New System.Drawing.Point(0, 0)
        Me.txtSerialData.Multiline = True
        Me.txtSerialData.Name = "txtSerialData"
        Me.txtSerialData.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSerialData.Size = New System.Drawing.Size(115, 620)
        Me.txtSerialData.TabIndex = 9
        '
        'txtSerialInput
        '
        Me.txtSerialInput.AcceptsReturn = True
        Me.txtSerialInput.AutoCompleteCustomSource.AddRange(New String() {"reset", "setid", "getid", "setwp", "heartbeat", "settotalwp", "setcurrentwp", "getcurrentwp", "clearwps", "printwps", "setmode", "getmode", "calcdistance", "calcbearing", "getgps", "targets", "cls", "feventreachwp", "debugmodecompass", "debugmodegps", "debugmodesteering", "debugmodetel", "getwpradius", "setwpradius"})
        Me.txtSerialInput.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtSerialInput.Location = New System.Drawing.Point(0, 91)
        Me.txtSerialInput.Name = "txtSerialInput"
        Me.txtSerialInput.Size = New System.Drawing.Size(115, 21)
        Me.txtSerialInput.TabIndex = 10
        '
        'sPort
        '
        Me.sPort.BaudRate = 115200
        Me.sPort.DiscardNull = True
        Me.sPort.ReadBufferSize = 1024
        Me.sPort.WriteBufferSize = 51200
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MissionToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MissionToolStripMenuItem
        '
        Me.MissionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadLastViewToolStripMenuItem, Me.SaveViewToolStripMenuItem, Me.ToolStripMenuItem3, Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveNavigationToolStripMenuItem, Me.ToolStripMenuItem2, Me.PrintNavigationToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.MissionToolStripMenuItem.Name = "MissionToolStripMenuItem"
        Me.MissionToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.MissionToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.MissionToolStripMenuItem.Text = "&File"
        '
        'LoadLastViewToolStripMenuItem
        '
        Me.LoadLastViewToolStripMenuItem.Image = Global.MEW_Control_Station.My.Resources.Resources.action_refresh
        Me.LoadLastViewToolStripMenuItem.Name = "LoadLastViewToolStripMenuItem"
        Me.LoadLastViewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.LoadLastViewToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.LoadLastViewToolStripMenuItem.Text = "Load View"
        '
        'SaveViewToolStripMenuItem
        '
        Me.SaveViewToolStripMenuItem.Image = Global.MEW_Control_Station.My.Resources.Resources.action_refresh_blue
        Me.SaveViewToolStripMenuItem.Name = "SaveViewToolStripMenuItem"
        Me.SaveViewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveViewToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.SaveViewToolStripMenuItem.Text = "Save View"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(235, 6)
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = Global.MEW_Control_Station.My.Resources.Resources.box
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.NewToolStripMenuItem.Text = "&New Navigation"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Image = Global.MEW_Control_Station.My.Resources.Resources.folder_images
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.OpenToolStripMenuItem.Text = "&Open Saved Navigation"
        '
        'SaveNavigationToolStripMenuItem
        '
        Me.SaveNavigationToolStripMenuItem.Image = Global.MEW_Control_Station.My.Resources.Resources.action_save
        Me.SaveNavigationToolStripMenuItem.Name = "SaveNavigationToolStripMenuItem"
        Me.SaveNavigationToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveNavigationToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.SaveNavigationToolStripMenuItem.Text = "&Save Navigation"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(235, 6)
        '
        'PrintNavigationToolStripMenuItem
        '
        Me.PrintNavigationToolStripMenuItem.Image = Global.MEW_Control_Station.My.Resources.Resources.action_print
        Me.PrintNavigationToolStripMenuItem.Name = "PrintNavigationToolStripMenuItem"
        Me.PrintNavigationToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintNavigationToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.PrintNavigationToolStripMenuItem.Text = "&Print Navigation"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(235, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(238, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMEWToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutMEWToolStripMenuItem
        '
        Me.AboutMEWToolStripMenuItem.Name = "AboutMEWToolStripMenuItem"
        Me.AboutMEWToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.AboutMEWToolStripMenuItem.Text = "About MEW"
        '
        'timConnectedShow
        '
        Me.timConnectedShow.Enabled = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "MEW Files|*.mew"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "MEW Files|*.mew"
        '
        'timTelRecShow
        '
        '
        'timAlertBlink
        '
        Me.timAlertBlink.Enabled = True
        Me.timAlertBlink.Interval = 250
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 0
        Me.ToolTip1.InitialDelay = 0
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ShowAlways = True
        '
        'timTelemetry
        '
        Me.timTelemetry.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MEW_Control_Station.My.Resources.Resources.TOOLBAR
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.statuslabelConnect})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 724)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1028, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = False
        Me.lblStatus.BackgroundImage = Global.MEW_Control_Station.My.Resources.Resources.TOOLBAR
        Me.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.lblStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Top
        Me.lblStatus.ForeColor = System.Drawing.Color.Silver
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(800, 17)
        Me.lblStatus.Text = "Status"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'statuslabelConnect
        '
        Me.statuslabelConnect.ForeColor = System.Drawing.Color.Silver
        Me.statuslabelConnect.Image = Global.MEW_Control_Station.My.Resources.Resources.icon_alert
        Me.statuslabelConnect.Name = "statuslabelConnect"
        Me.statuslabelConnect.Size = New System.Drawing.Size(87, 17)
        Me.statuslabelConnect.Text = "Disconnected"
        Me.statuslabelConnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ToolStrip1.BackgroundImage = Global.MEW_Control_Station.My.Resources.Resources.MENUBAR
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.cmbView, Me.ToolStripSeparator1, Me.cboPorts, Me.ToolStripLabel2, Me.btnConnect, Me.btnClearWaypoints, Me.btnUploadWaypoints, Me.btnSameViewinMap, Me.chkAutoCenter2, Me.btnTelemetry2, Me.btnTel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1028, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(54, 22)
        Me.ToolStripLabel1.Text = "Main View"
        '
        'cmbView
        '
        Me.cmbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbView.Items.AddRange(New Object() {"Monitoring", "Navigation", "Configuration"})
        Me.cmbView.Name = "cmbView"
        Me.cmbView.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cboPorts
        '
        Me.cboPorts.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.cboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPorts.Name = "cboPorts"
        Me.cboPorts.Size = New System.Drawing.Size(75, 25)
        Me.cboPorts.Text = Global.MEW_Control_Station.My.MySettings.Default.COMPort
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(88, 22)
        Me.ToolStripLabel2.Text = "Connection Port:"
        '
        'btnConnect
        '
        Me.btnConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnConnect.ForeColor = System.Drawing.Color.White
        Me.btnConnect.Image = Global.MEW_Control_Station.My.Resources.Resources.icon_link
        Me.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(67, 22)
        Me.btnConnect.Text = "Connect"
        '
        'btnClearWaypoints
        '
        Me.btnClearWaypoints.ForeColor = System.Drawing.Color.White
        Me.btnClearWaypoints.Image = Global.MEW_Control_Station.My.Resources.Resources.action_stop
        Me.btnClearWaypoints.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClearWaypoints.Name = "btnClearWaypoints"
        Me.btnClearWaypoints.Size = New System.Drawing.Size(106, 22)
        Me.btnClearWaypoints.Text = "Clear Waypoints"
        '
        'btnUploadWaypoints
        '
        Me.btnUploadWaypoints.ForeColor = System.Drawing.Color.White
        Me.btnUploadWaypoints.Image = Global.MEW_Control_Station.My.Resources.Resources.icon_package_get
        Me.btnUploadWaypoints.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUploadWaypoints.Name = "btnUploadWaypoints"
        Me.btnUploadWaypoints.Size = New System.Drawing.Size(114, 22)
        Me.btnUploadWaypoints.Text = "Upload Waypoints"
        '
        'btnSameViewinMap
        '
        Me.btnSameViewinMap.Image = Global.MEW_Control_Station.My.Resources.Resources.map_go
        Me.btnSameViewinMap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSameViewinMap.Name = "btnSameViewinMap"
        Me.btnSameViewinMap.Size = New System.Drawing.Size(114, 22)
        Me.btnSameViewinMap.Text = "Same View at Map"
        '
        'chkAutoCenter2
        '
        Me.chkAutoCenter2.CheckOnClick = True
        Me.chkAutoCenter2.Image = Global.MEW_Control_Station.My.Resources.Resources.World_link
        Me.chkAutoCenter2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.chkAutoCenter2.Name = "chkAutoCenter2"
        Me.chkAutoCenter2.Size = New System.Drawing.Size(86, 22)
        Me.chkAutoCenter2.Text = "Auto Center"
        '
        'btnTelemetry2
        '
        Me.btnTelemetry2.Image = Global.MEW_Control_Station.My.Resources.Resources.transmit_blue
        Me.btnTelemetry2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTelemetry2.Name = "btnTelemetry2"
        Me.btnTelemetry2.Size = New System.Drawing.Size(75, 22)
        Me.btnTelemetry2.Text = "Telemetry"
        '
        'btnTel
        '
        Me.btnTel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.btnTel.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4, Me.QuaterOfASecondToolStripMenuItem, Me.HalfASecondToolStripMenuItem, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8})
        Me.btnTel.Image = CType(resources.GetObject("btnTel.Image"), System.Drawing.Image)
        Me.btnTel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnTel.Name = "btnTel"
        Me.btnTel.Size = New System.Drawing.Size(13, 22)
        Me.btnTel.Text = "Telemetry"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem4.Text = "Once"
        '
        'QuaterOfASecondToolStripMenuItem
        '
        Me.QuaterOfASecondToolStripMenuItem.Name = "QuaterOfASecondToolStripMenuItem"
        Me.QuaterOfASecondToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.QuaterOfASecondToolStripMenuItem.Text = "Quater of a second"
        '
        'HalfASecondToolStripMenuItem
        '
        Me.HalfASecondToolStripMenuItem.Name = "HalfASecondToolStripMenuItem"
        Me.HalfASecondToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.HalfASecondToolStripMenuItem.Text = "Half a second"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem5.Text = "1 second"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem6.Text = "5 seconds"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem7.Text = "10 seconds"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(178, 22)
        Me.ToolStripMenuItem8.Text = "1 minute"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.pMap)
        Me.Controls.Add(Me.pConfig)
        Me.Controls.Add(Me.pMonitoring)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("Location", Global.MEW_Control_Station.My.MySettings.Default, "MainFormLocation", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Location = Global.MEW_Control_Station.My.MySettings.Default.MainFormLocation
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Multipurpose Enduring Watercraft Control Station"
        Me.pMap.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pMonitoring.ResumeLayout(False)
        Me.pInstruments.ResumeLayout(False)
        Me.pInstruments.PerformLayout()
        CType(Me.picAlert, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPitch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicRoll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicCompass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pConfig.ResumeLayout(False)
        Me.pConfig.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents pMap As System.Windows.Forms.Panel
    Friend WithEvents GMap As Pegazux.Controls.GoogleMaps.GoogleMapsControl
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cmbView As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboPorts As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents btnConnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents pMonitoring As System.Windows.Forms.Panel
    Friend WithEvents pConfig As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents AxGENavigationControlCoClass1 As AxGEPlugin.AxGENavigationControlCoClass
    Friend WithEvents btnClearWaypoints As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUploadWaypoints As System.Windows.Forms.ToolStripButton
    Friend WithEvents sPort As System.IO.Ports.SerialPort
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MissionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintNavigationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveNavigationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutMEWToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadLastViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timConnectedShow As System.Windows.Forms.Timer
    Friend WithEvents statuslabelConnect As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtSerialInput As System.Windows.Forms.TextBox
    Friend WithEvents txtSerialData As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents wbMap As System.Windows.Forms.WebBrowser
    Friend WithEvents pInstruments As System.Windows.Forms.Panel
    Friend WithEvents lblRollPitch As System.Windows.Forms.Label
    Friend WithEvents lblDistanceCovered As System.Windows.Forms.Label
    Friend WithEvents lblWaterTemp As System.Windows.Forms.Label
    Friend WithEvents lblHullTemp As System.Windows.Forms.Label
    Friend WithEvents lblRemainingPower As System.Windows.Forms.Label
    Friend WithEvents lblSolarPanelVolt As System.Windows.Forms.Label
    Friend WithEvents lblMotorSpeeds As System.Windows.Forms.Label
    Friend WithEvents lblLatLong As System.Windows.Forms.Label
    Friend WithEvents lblSpeed As System.Windows.Forms.Label
    Friend WithEvents lblCurrentWaypoint As System.Windows.Forms.Label
    Friend WithEvents lblTargetHeading As System.Windows.Forms.Label
    Friend WithEvents lblCurrentHeading As System.Windows.Forms.Label
    Friend WithEvents lblPowerSavingMode As System.Windows.Forms.Label
    Friend WithEvents lblBattery As System.Windows.Forms.Label
    Friend WithEvents PicSpeed As System.Windows.Forms.PictureBox
    Friend WithEvents PicPitch As System.Windows.Forms.PictureBox
    Friend WithEvents PicRoll As System.Windows.Forms.PictureBox
    Friend WithEvents PicCompass As System.Windows.Forms.PictureBox
    Friend WithEvents wp_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wp_lat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents wp_lon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WaypointName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents timTelRecShow As System.Windows.Forms.Timer
    Friend WithEvents lblMyMode As System.Windows.Forms.Label
    Friend WithEvents lblGPSCourse As System.Windows.Forms.Label
    Friend WithEvents chkManualControl As System.Windows.Forms.CheckBox
    Friend WithEvents btnSameViewinMap As System.Windows.Forms.ToolStripButton
    Friend WithEvents chkAutoCenter2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents picAlert As System.Windows.Forms.PictureBox
    Friend WithEvents timAlertBlink As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnTel As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timTelemetry As System.Windows.Forms.Timer
    Friend WithEvents QuaterOfASecondToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HalfASecondToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnTelemetry2 As System.Windows.Forms.ToolStripButton

End Class
