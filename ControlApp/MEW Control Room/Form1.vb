Imports Pegazux.Controls.GoogleMaps
Imports System
Imports System.IO.Ports
Imports System.IO.File
Imports System.Threading


Public Class frmMain

    Dim MyMode As Integer
    Public MyOldTel As Boolean
    Dim ReplyStr As String
    Dim GMapLoadCompleted As Boolean = False

    Dim Heading As Integer
    Dim CurrentLat As Double
    Dim CurrentLon As Double
    Dim Speed As Single
    Dim Pitch As Single
    Dim Roll As Single

    Dim TelemetryEnabled As Boolean
    Dim TemeteryRate As Integer = 0

    Dim LastTelemetryRec As New DateTime(2012, 1, 1)

    Structure wp
        Dim ID As Integer
        Dim Lat As Double
        Dim Lon As Double
        Dim Command As String
        Dim WaitTime As Integer
        Dim WpName As String
    End Structure
    Const MAXWAYPOINTS As Integer = 15
    Dim MyWps() As wp
    Dim ViewSelected As Integer = 0
    Dim TotalWps As Integer = -1
    Dim Connected As Boolean = False
    Dim MyDataTemp As String            'Holds Temp data of Telemetry
    Dim t As Thread

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        t.Abort()
        End
    End Sub


    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.MainFormState = Me.WindowState
        My.Settings.COMPort = cboPorts.Text
        My.Settings.AutoMapCheckedState = chkAutoCenter2.CheckState
        My.Settings.Save()
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        wbMap.Navigate(System.AppDomain.CurrentDomain.BaseDirectory & "Map\map.html")

        sPort.Encoding = System.Text.Encoding.Default
        sPort.ReadBufferSize = 32 * 1024
        t = New Thread(AddressOf Me.BackgroundProcess)
        t.SetApartmentState(ApartmentState.Unknown)
        t.Priority = ThreadPriority.Highest


        t.Start()

        CheckForIllegalCrossThreadCalls = False

        txtSerialData.CheckForIllegalCrossThreadCalls = False
        txtSerialInput.CheckForIllegalCrossThreadCalls = False
        Me.WindowState = My.Settings.MainFormState
        chkAutoCenter2.CheckState = My.Settings.AutoMapCheckedState

        'TO HIDE THE GOOGLE MAPS UI CONTROLS
        'Hides The MapType Control
        GMap.Map.Options.MapTypeControl = True

        'Hides the Navigation and Zoom controls
        GMap.Map.Options.NavigationControl = True

        'Hides the scale control
        GMap.Map.Options.ScaleControl = True

        'Sets the BackGround Color
        GMap.Map.Options.BackGroundColor = "#686868"

        GMap.Map.Options.Zoom = 1

        'TO LOAD THE MAP, WHITHOUT THIS, THE MAP DOESN'T WORK
        GMap.LoadMap()

        pMonitoring.Dock = DockStyle.Fill
        pMap.Dock = DockStyle.Fill
        pConfig.Dock = DockStyle.Fill

        wbMap.WebBrowserShortcutsEnabled = False
        wbMap.ScriptErrorsSuppressed = True

        cmbView.SelectedIndex = ViewSelected
        ChangeView()



        EnumPorts()


        DrawCompass(0)
        DrawPitch(0)
        DrawRoll(0)
        DrawSpeed(0)

    End Sub
    Private Sub cmbView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbView.SelectedIndexChanged
        'If ViewSelected = 1 And cmbView.SelectedIndex = 0 Then
        'ZoomAndPanMap()
        'End If
        ViewSelected = cmbView.SelectedIndex
        ChangeView()

    End Sub

    Sub DrawPolyLines()
        If GMapLoadCompleted = True Then
            'Dim StringBuilder As String
            'If TotalWps < 0 Then Exit Sub
            'StringBuilder = "javascript:flightPath.setMap();flightPlanCoordinates = ["
            'For I As Integer = 0 To TotalWps - 1
            'StringBuilder = StringBuilder & "new google.maps.LatLng(" & MyWps(I).Lat & "," & MyWps(I).Lon & "),"
            'Next
            'StringBuilder = StringBuilder & "new google.maps.LatLng(" & MyWps(TotalWps).Lat & "," & MyWps(TotalWps).Lon & ")]"
            'StringBuilder = StringBuilder & ";flightPath = new google.maps.Polyline({path: flightPlanCoordinates,strokeColor: '#FF0000',strokeOpacity: 1.0,strokeWeight: 2});flightPath.setMap(map);"
            'wbMap.Navigate(StringBuilder)
            If TotalWps = -1 Or TotalWps = 0 Then Exit Sub
            Dim Str As String
            Str = "javascript:flightPlanCoordinates=0;flightPath.setMap();"
            wbMap.Navigate(Str)

            'MsgBox(Str)
            For I As Integer = 0 To TotalWps - 1
                Str = "javascript:flightPlanCoordinates.push(new google.maps.LatLng(" & MyWps(I).Lat & "," & MyWps(I).Lon & ")); "
                wbMap.Navigate(Str)

                'MsgBox(Str)
            Next
            Str = "javascript:flightPlanCoordinates.push(new google.maps.LatLng(" & MyWps(TotalWps).Lat & "," & MyWps(TotalWps).Lon & "));"
            wbMap.Navigate(Str)

            Str = "javascript:flightPath = new google.maps.Polyline({path: flightPlanCoordinates,strokeColor: '#FF0000',strokeOpacity: 1.0,strokeWeight: 2});flightPath.setMap(map);"
            wbMap.Navigate(Str)

            'MsgBox(Str)
        End If
    End Sub
    Sub ZoomAndPanMap()

        If GMapLoadCompleted = True Then
            Dim StringBuilder As String
            StringBuilder = "javascript:var centerlatlng = new google.maps.LatLng(" & GMap.Map.GetCenter.Lat & "," & GMap.Map.GetCenter.Lng & ");map.setCenter(centerlatlng);void(0);"
            wbMap.Navigate(StringBuilder)

            MsgBox(StringBuilder)

            'StringBuilder = "javascript:map.setCenter(centerlatlng);void(0);"

            'wbMap.Navigate(StringBuilder)

            StringBuilder = "javascript:map.setZoom(" & GMap.Map.GetZoom & ");void(0);"

            wbMap.Navigate(StringBuilder)
        End If
    End Sub

    Sub ChangeView()
        Select Case ViewSelected

            Case 0                              'Monitoring
                pMonitoring.Visible = True
                pMap.Visible = False
                pConfig.Visible = False

                timTelRecShow.Enabled = True

                SaveViewToolStripMenuItem.Enabled = False
                SaveNavigationToolStripMenuItem.Enabled = False

                btnUploadWaypoints.Visible = False
                btnClearWaypoints.Visible = False
                btnSameViewinMap.Visible = False
                chkAutoCenter2.Visible = True
                btnTel.Visible = True
                btnTelemetry2.Visible = True

                DrawPolyLines()
            Case 1                          'Mission Planning
                pMonitoring.Visible = False
                pMap.Visible = True
                pConfig.Visible = False

                timTelRecShow.Enabled = False

                SaveViewToolStripMenuItem.Enabled = True
                SaveNavigationToolStripMenuItem.Enabled = True

                btnUploadWaypoints.Visible = True
                btnClearWaypoints.Visible = True
                btnSameViewinMap.Visible = True
                chkAutoCenter2.Visible = False
                btnTel.Visible = False

                btnTelemetry2.Visible = False

            Case 2                          'Configuration or Terminal
                pMonitoring.Visible = False
                pMap.Visible = False
                pConfig.Visible = True

                timTelRecShow.Enabled = False
                txtSerialData.SelectionStart = txtSerialData.Text.Length
                txtSerialData.ScrollToCaret()

                lblStatus.Text = ""
                SaveViewToolStripMenuItem.Enabled = False
                SaveNavigationToolStripMenuItem.Enabled = False

                btnUploadWaypoints.Visible = True
                btnClearWaypoints.Visible = True
                btnSameViewinMap.Visible = False
                chkAutoCenter2.Visible = False
                btnTel.Visible = False
                btnTelemetry2.Visible = False
        End Select
    End Sub
    Private Sub pMap_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pMap.SizeChanged
        GMap.Height = pMap.Height * 0.8
        'pWaypoints.Height = pMap.Height * 0.2
    End Sub

    Private Sub GMap_LoadCompleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GMap.LoadCompleted
        GMapLoadCompleted = True
    End Sub


    Private Sub GMap_MarkerAdded(ByVal sender As Object, ByVal e As Pegazux.Controls.GoogleMaps.GoogleMapsMarkerEventArgs) Handles GMap.MarkerAdded
        GeneratePolyLines()
    End Sub
    Private Sub GMap_Mousemove(ByVal sender As Object, ByVal e As Pegazux.Controls.GoogleMaps.GoogleMapsMouseEventsArgs) Handles GMap.Mousemove
        lblStatus.Text = "Mouse Position: " & e.LatLng.ToString
    End Sub
    Private Sub GMap_RightClick(ByVal sender As Object, ByVal e As Pegazux.Controls.GoogleMaps.GoogleMapsMouseEventsArgs) Handles GMap.RightClick
        AddWaypoint(e.LatLng.Lat, e.LatLng.Lng, "0", 0)
    End Sub
    Sub AddWaypoint(ByVal Lat As Double, ByVal Lon As Double, Optional ByVal Command As String = "", Optional ByVal WaitTime As Integer = 0, Optional ByVal GivWpName As String = "NoName")

        If TotalWps >= MAXWAYPOINTS - 1 Then MsgBox("Maximum Waypoints Reached", MsgBoxStyle.Information) : Exit Sub

        TotalWps += 1
        ReDim Preserve MyWps(TotalWps)

        MyWps(TotalWps).ID = TotalWps
        MyWps(TotalWps).Lat = Lat
        MyWps(TotalWps).Lon = Lon

        MyWps(TotalWps).Command = Command
        MyWps(TotalWps).WaitTime = WaitTime

        MyWps(TotalWps).WpName = GivWpName

        ' Add to Map
        Dim MyMarker As New Marker
        MyMarker.Options.Position = New LatLng(MyWps(TotalWps).Lat, MyWps(TotalWps).Lon)
        MyMarker.Options.Clickable = True
        MyMarker.Options.Draggable = False
        MyMarker.Options.Title = TotalWps

        GMap.Map.AddMarker(MyMarker)

        'Add to List
        Dim dgvRow As New DataGridViewRow
        Dim MyCell As DataGridViewCell

        MyCell = New DataGridViewTextBoxCell()
        MyCell.Value = TotalWps
        dgvRow.Cells.Add(MyCell)

        MyCell = New DataGridViewTextBoxCell()
        MyCell.Value = MyWps(TotalWps).Lat
        dgvRow.Cells.Add(MyCell)

        MyCell = New DataGridViewTextBoxCell()
        MyCell.Value = MyWps(TotalWps).Lon
        dgvRow.Cells.Add(MyCell)

        Dim MyCell2 = New DataGridViewComboBoxCell()
        MyCell2.Items.Add("")
        MyCell2.Items.Add(420)
        MyCell2.Items.Add(1)
        MyCell2.Items.Add(2)

        'MyCell2.Value = MyWps(TotalWps).Command
        'dgvRow.Cells.Add(MyCell2)



        MyCell = New DataGridViewTextBoxCell()
        MyCell.Value = MyWps(TotalWps).WaitTime
        'dgvRow.Cells.Add(MyCell)




        MyCell = New DataGridViewTextBoxCell()
        MyCell.Value = MyWps(TotalWps).WpName
        dgvRow.Cells.Add(MyCell)

        DataGridView1.Rows.Add(dgvRow)


    End Sub
    Sub ClearWaypoints()
        TotalWps = -1
        ReDim MyWps(0)
        DataGridView1.Rows.Clear()
        GMap.LoadMap()



    End Sub
    Private Sub GeneratePolyLines()

        If GMap.Map.Polylines.Count = 0 Then

            Dim t_polyline As New Polyline

            t_polyline.Options.StrokeColor = "#FF0000"
            t_polyline.Options.StrokeOpacity = 1
            t_polyline.Options.StrokeWeight = 0.8

            GMap.Map.AddPolyline(t_polyline)

        End If

        For i As Integer = 0 To GMap.Map.Markers.Count - 1

            If Not GMap.Map.Polylines(0).Options.Path Is Nothing Then

                If Not GMap.Map.Polylines(0).Options.Path.Contains(GMap.Map.Markers(i).Options.Position) Then

                    GMap.Map.Polylines(0).Extend(GMap.Map.Markers(i).Options.Position)

                End If

            Else

                GMap.Map.Polylines(0).Extend(GMap.Map.Markers(i).Options.Position)

            End If

        Next

    End Sub

    Private Sub btnClearWaypoints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearWaypoints.Click
        ClearWaypoints()
    End Sub

    Private Sub cboPorts_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPorts.GotFocus
        EnumPorts()
    End Sub

    Private Sub cboPorts_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPorts.TextChanged

        If cboPorts.Text <> "" Then sPort.PortName = cboPorts.Text
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub PrintNavigationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintNavigationToolStripMenuItem.Click
        'If ViewSelected = 1 Then
        cmbView.SelectedIndex = 1
        Me.GMap.Map.Print()
        'End If
    End Sub
    Private Sub LoadLastViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadLastViewToolStripMenuItem.Click
        cmbView.SelectedIndex = 1
        GMap.Map.Options.Center = My.Settings.GMapView
        GMap.Map.Options.Zoom = My.Settings.GMapZoom
    End Sub

    Private Sub SaveViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveViewToolStripMenuItem.Click
        My.Settings.GMapView = GMap.Map.GetCenter
        My.Settings.GMapZoom = GMap.Map.GetZoom
        My.Settings.Save()
    End Sub

    Private Sub btnUploadWaypoints_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadWaypoints.Click
        Dim I As Integer
        Dim MyLat As Double
        Dim MyLong As Double
        Dim TmpStr As String

        SendDataNewLine("")

        SendDataNewLine("clearwps")

        SendDataNewLine("")

        SendData("settotalwp " & TotalWps & vbNewLine)

        SendDataNewLine("")

        For I = 0 To TotalWps

            TmpStr = "setwp " & I & " " & MyWps(I).Lat & " " & MyWps(I).Lon & " " & MyWps(I).Command & " " & MyWps(I).WaitTime & " " & MyWps(I).WpName & vbNewLine
            SendDataNewLine("")
            SendDataNewLine(TmpStr)
            SendDataNewLine("")

        Next
        SendDataNewLine("setcurrentwp 0")

    End Sub


    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click


        If Connected = False Then
            sPort.Close()
            sPort.Open()

        Else
            sPort.Close()

        End If

    End Sub

    Private Sub BackgroundProcess()
        On Error Resume Next
        Do While True
            If sPort.IsOpen Then

                Dim MyData As String
                MyData = sPort.ReadLine()
                'If MyData <> "" Then
                txtSerialData.Text = txtSerialData.Text & MyData & vbNewLine
                If MyData.Length > 2 Then
                    Debug.Print(MyData)
                    If MyData.Contains("T<") Then DoTelemetry(MyData)
                End If



                'If sPort.IsOpen Then sPort.DiscardInBuffer()
                If MyData <> "" Then
                    txtSerialData.SelectionStart = txtSerialData.Text.Length
                    txtSerialData.ScrollToCaret()
                End If

            End If

        Loop
    End Sub

    Sub DoTelemetry(ByVal Data As String)

        LastTelemetryRec = DateTime.Now

        Dim Splits() As String
        Data = Data.Replace("T<", "")
        Data = Data.Replace(">", "")
        Splits = Data.Split(",")
        lblLatLong.Text = "Lat/Long: " & Splits(0) & ", " & Splits(1)

        CurrentLat = Splits(0)
        CurrentLon = Splits(1)

        lblBattery.Text = "Battery Voltage: " & Splits(2) & "V"
        lblWaterTemp.Text = "Water Temperature: " & Splits(3) & "'C"
        lblHullTemp.Text = "Hull Temperature: " & Splits(4) & "'C"
        lblCurrentHeading.Text = "Current Heading : " & Splits(5) & "'"


        Heading = Splits(5)



        lblRollPitch.Text = "Roll/Pitch : " & Splits(6) & " ', " & Splits(7) & "'"

        Roll = Splits(6)
        Pitch = Splits(7)

        Dim LeftMotorPer As Integer = (Splits(8) / 255) * 100
        Dim RightMotorPer As Integer = (Splits(9) / 255) * 100


        lblMotorSpeeds.Text = "Left/Right Motor: " & Splits(8) & " (" & LeftMotorPer & "%" & ")" & ", " & Splits(9) & " (" & RightMotorPer & "%" & ")"
        lblCurrentWaypoint.Text = "Current Waypoint: " & Splits(10)
        lblTargetHeading.Text = "Target Heading: " & Splits(11)
        lblSpeed.Text = "Speed: " & Splits(12) & " km/h"

        Speed = Splits(12)

        lblGPSCourse.Text = "GPS Course: " & Splits(13)
        lblPowerSavingMode.Text = "Power Saving Mode: " & Splits(14)

        lblMyMode.Text = "Current Mode: " & Splits(15)
        lblSolarPanelVolt.Text = "Solar Panel Voltage: " & Splits(16) & "V"

        MyMode = Splits(15)
        Select Case MyMode
            Case 0
                lblMyMode.Text += " (Manual Mode)"
            Case 1
                lblMyMode.Text += " (Auto Mode)"
            Case 2
                lblMyMode.Text += " (Hold Position Mode)"
            Case 3
                lblMyMode.Text += " (Return to Home Mode)"
        End Select




        DrawCompass(Heading)
        DrawSpeed(Speed)
        DrawPitch(Pitch * 30 * 2)
        DrawRoll(Roll * 30 * 2)


        ShowCurrentPos()
        ChangeMapHeadingImage()
    End Sub

    Sub ShowCurrentPos()
        Dim StringBuilder As String
        StringBuilder = "javascript:marker.setPosition(new google.maps.LatLng(" & CurrentLat & ", " & CurrentLon & "));"
        wbMap.Navigate(StringBuilder)

        If chkAutoCenter2.CheckState = CheckState.Checked Then
            StringBuilder = "javascript:var centerlatlng = new google.maps.LatLng(" & CurrentLat & "," & CurrentLon & ");"
            StringBuilder = StringBuilder & "map.setCenter(centerlatlng);"
            wbMap.Navigate(StringBuilder)
        End If

    End Sub

    Private Sub sPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles sPort.DataReceived
        Exit Sub

        Dim MyData As String
        MyData = sPort.ReadExisting()
        txtSerialData.Text = txtSerialData.Text & MyData

        sPort.DiscardInBuffer()
        txtSerialData.SelectionStart = txtSerialData.Text.Length
        txtSerialData.ScrollToCaret()
        If MyData.Contains("T<") Then

            Dim Splits() As String
            Splits = MyData.Split(vbNewLine)
            MyDataTemp += Splits(0)
            'MsgBox(MyDataTemp)
            MyDataTemp = ""

        End If


    End Sub


    Private Sub timConnectedShow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timConnectedShow.Tick
        If sPort.IsOpen = True Then
            Connected = True
            btnConnect.Checked = True
            statuslabelConnect.Text = "Connected"
            statuslabelConnect.Image = My.Resources.icon_accept
            cboPorts.Enabled = False
            chkManualControl.Enabled = True
        Else
            cboPorts.Enabled = True
            Connected = False
            btnConnect.Checked = False
            statuslabelConnect.Text = "Disconnected"
            statuslabelConnect.Image = My.Resources.icon_alert
            chkManualControl.Enabled = False
            chkManualControl.CheckState = CheckState.Unchecked
            ArrowKeysForm.Hide()
        End If
    End Sub

    Private Sub GMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GMap.Load

    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        cmbView.SelectedIndex = 1
        ClearWaypoints()
    End Sub

    Sub AddBoatMarker()
        Dim BoatMarker As Marker = New Marker
        BoatMarker.Options.Position.Lat = 1
        BoatMarker.Options.Position.Lng = 1
        BoatMarker.Options.Icon.Url = "c:/tickmark1.png"
        BoatMarker.Options.Icon.Size = New Pegazux.Controls.GoogleMaps.Size(26, 26)
        BoatMarker.Options.Title = "Boat Current Position: " & BoatMarker.Options.Position.ToString
        GMap.Map.AddMarker(BoatMarker)
    End Sub

    Sub EnumPorts()
        cboPorts.Items.Clear()
        ' Get a list of serial port names.
        Dim ports As String() = SerialPort.GetPortNames()

        Console.WriteLine("The following serial ports were found:")

        ' Display each port name to the console.
        Dim port As String
        For Each port In ports
            Console.WriteLine(port)
            cboPorts.Items.Add(port)
        Next port

        cboPorts.Text = My.Settings.COMPort
    End Sub



    Private Sub txtSerialInput_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerialInput.KeyPress
        Dim KeyAscii
        Dim Temp As Integer
        KeyAscii = Asc(e.KeyChar)
        If KeyAscii = 13 Then  'ENTER PRESSED
            SendDataNewLine(vbNewLine & txtSerialInput.Text & vbNewLine)
            txtSerialInput.Text = ""
        End If
    End Sub
    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Select Case e.ColumnIndex
            Case 0          'ID
                MyWps(e.RowIndex).ID = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            Case 1          'Latitude
                MyWps(e.RowIndex).Lat = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            Case 2          'Longitude
                MyWps(e.RowIndex).Lon = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            Case 3          'Command
                MyWps(e.RowIndex).Command = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            Case 4          'Wait Time
                MyWps(e.RowIndex).WaitTime = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            Case 5          'WP Name
                MyWps(e.RowIndex).WpName = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        End Select


    End Sub
    Sub CreateDelay()
        For Z As Integer = 1 To 100000000 : Next
    End Sub

    Sub SendDataNewLine(ByVal Give As String)
        On Error Resume Next
        If Connected = True Then
            sPort.Write(vbNewLine)
            sPort.Write(Give)
            sPort.Write(vbNewLine)
            CreateDelay()
        End If
    End Sub

    Sub SendData(ByVal Give As String)
        If Connected = True Then
            sPort.Write(Give)
            CreateDelay()
        End If
    End Sub

    Private Sub SaveNavigationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveNavigationToolStripMenuItem.Click
        Dim MyRandom As Integer = CInt(Rnd() * 100)
        SaveFileDialog1.ShowDialog()
        Dim MyFileName = SaveFileDialog1.FileName
        FileOpen(MyRandom, MyFileName, OpenMode.Output)

        PrintLine(MyRandom, GMap.Map.GetCenter.Lat & "," & GMap.Map.GetCenter.Lng & "," & GMap.Map.GetZoom)

        For i As Integer = 0 To TotalWps
            Print(MyRandom, MyWps(i).Lat & "," & MyWps(i).Lon & "," & MyWps(i).Command & "," & MyWps(i).WaitTime & "," & MyWps(i).WpName & vbNewLine)
        Next
        FileClose(MyRandom)

    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        On Error Resume Next
        cmbView.SelectedIndex = 1

        Dim MyRandom As Integer = CInt(Rnd() * 100)


        Dim ReadLine As String
        Dim Params() As String


        ClearWaypoints()
        OpenFileDialog1.ShowDialog()

        Dim MyFileName = OpenFileDialog1.FileName

        FileOpen(MyRandom, MyFileName, OpenMode.Input)

        ReadLine = LineInput(MyRandom)

        Params = ReadLine.Split(",")
        Dim Temp As New LatLng(Val(Params(0)), Val(Params(1)))

        GMap.Map.SetCenter(Temp)
        GMap.Map.SetZoom(Val(Params(2)))

        While Not EOF(MyRandom)
            ReadLine = LineInput(MyRandom)
            Params = ReadLine.Split(",")


            AddWaypoint(Params(0), Params(1), Params(2), Params(3), Params(4))
        End While


        FileClose(MyRandom)
    End Sub

    Private Sub AboutMEWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutMEWToolStripMenuItem.Click
        About.Show()
    End Sub


    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        pInstruments.Width = Me.Width / 2
        wbMap.Width = Me.Width / 2
    End Sub


    Private Sub lblBattery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub cmbView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbView.Click
    End Sub

    Sub ChangeMapHeadingImage()
        Dim StringBuilder As String
        Dim DirectionName As String

        If InRange(Heading, 0, 22.5) = True Then
            DirectionName = "N"
        ElseIf InRange(Heading, 22.5, 67.5) Then
            DirectionName = "NE"
        ElseIf InRange(Heading, 67.5, 112.5) Then
            DirectionName = "E"
        ElseIf InRange(Heading, 112.5, 157.5) Then
            DirectionName = "SE"
        ElseIf InRange(Heading, 157.5, 202.5) Then
            DirectionName = "S"

        ElseIf InRange(Heading, 202.5, 247.5) Then
            DirectionName = "SW"
        ElseIf InRange(Heading, 247.5, 292.5) Then
            DirectionName = "W"
        ElseIf InRange(Heading, 292.5, 337.5) Then
            DirectionName = "NW"
        ElseIf InRange(Heading, 337.5, 360) Then
            DirectionName = "N"
        End If


        StringBuilder = "javascript:marker.setIcon('markericons/" & DirectionName & ".png')"
        wbMap.Navigate(StringBuilder)
    End Sub

    Function InRange(ByVal Giv As Integer, ByVal A As Integer, ByVal B As Integer)
        If Giv >= A And Giv <= B Then
            InRange = True
        Else
            InRange = False
        End If
    End Function

    Sub DrawCompass(ByVal A As Integer)
        DrawCompass2(A)
        PicCompass.Image = CompassImage
    End Sub
    Sub DrawSpeed(ByVal A As Integer)
        DrawSpeed2(A)
        PicSpeed.Image = SpeedImage
    End Sub
    Sub DrawRoll(ByVal A As Integer)
        DrawRoll2(A)
        PicRoll.Image = RollImage
    End Sub
    Sub DrawPitch(ByVal A As Integer)
        DrawPitch2(A)
        PicPitch.Image = PitchImage
    End Sub


    
    Private Sub timTelRecShow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timTelRecShow.Tick

        'Dim ThisTimeDate As DateTime
        'Dim MyTimeSpace As TimeSpan
        'ThisTimeDate = DateTime.Now
        'MyTimeSpace = ThisTimeDate.Subtract(LastTelemetryRec)
        'lblStatus.Text = "Last Telemetry Recieved about " & Int(MyTimeSpace.TotalSeconds) & " seconds ago"
        ReplyStr = GetPrettyDate(LastTelemetryRec)
        If ReplyStr = "" Then
            lblStatus.Text = "No telemetry data received"
        Else
            lblStatus.Text = "Telemetry received " & GetPrettyDate(LastTelemetryRec)
        End If

    End Sub


    Function GetPrettyDate(ByVal d As DateTime) As String
        ' 1.
        ' Get time span elapsed since the date.
        Dim s As TimeSpan = DateTime.Now.Subtract(d)

        ' 2.
        ' Get total number of days elapsed.
        Dim dayDiff As Integer = CInt(s.TotalDays)

        ' 3.
        ' Get total number of seconds elapsed.
        Dim secDiff As Integer = CInt(s.TotalSeconds)

        ' 4.
        ' Don't allow out of range values.
        If dayDiff < 0 OrElse dayDiff >= 31 Then
            Return Nothing
        End If

        ' 5.
        ' Handle same-day times.
        If dayDiff = 0 Then
            ' A.
            ' Less than one minute ago.
            If secDiff < 60 Then
                MyOldTel = False
                Return "just now"

            End If
            ' B.
            ' Less than 2 minutes ago.
            If secDiff < 120 Then
                MyOldTel = True
                Return "1 minute ago"

            End If
            ' C.
            ' Less than one hour ago.
            If secDiff < 3600 Then
                MyOldTel = True
                Return String.Format("{0} minutes ago", Math.Floor(CDbl(secDiff) / 60))
            End If
            ' D.
            ' Less than 2 hours ago.
            If secDiff < 7200 Then
                MyOldTel = True
                Return "1 hour ago"
            End If
            ' E.
            ' Less than one day ago.
            If secDiff < 86400 Then
                MyOldTel = True
                Return String.Format("{0} hours ago", Math.Floor(CDbl(secDiff) / 3600))
            End If
        End If
        ' 6.
        ' Handle previous days.
        If dayDiff = 1 Then
            MyOldTel = True
            Return "yesterday"
        End If
        If dayDiff < 7 Then
            MyOldTel = True
            Return String.Format("{0} days ago", dayDiff)
        End If
        If dayDiff < 31 Then
            MyOldTel = True
            Return String.Format("{0} weeks ago", Math.Ceiling(CDbl(dayDiff) / 7))
        End If
        Return Nothing
    End Function

    
    Private Sub chkManualControl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManualControl.CheckedChanged
        If chkManualControl.CheckState = CheckState.Checked Then

            ArrowKeysForm.Show()
        ElseIf chkManualControl.CheckState = CheckState.Unchecked Then
            ArrowKeysForm.Hide()
        End If
    End Sub

    Private Sub GMap_Loading(ByVal sender As Object, ByVal e As System.EventArgs) Handles GMap.Loading
        GMapLoadCompleted = False
    End Sub

    Private Sub cboPorts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPorts.Click

    End Sub

    Private Sub btnSameViewinMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSameViewinMap.Click
        ZoomAndPanMap()
        cmbView.SelectedIndex = 0
        ChangeView()
    End Sub

    
    Private Sub timAlertBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timAlertBlink.Tick

        If Connected = True And ReplyStr <> "" And MyOldTel = True Then

            picAlert.Visible = Not picAlert.Visible
            If picAlert.Visible = True Then
                timAlertBlink.Interval = 600
            Else
                timAlertBlink.Interval = 250
            End If
        Else
            picAlert.Visible = False
        End If
    End Sub

    Private Sub picAlert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picAlert.Click
        ToolTip1.ToolTipTitle = "Alert"
        ToolTip1.Show("Telemetry data shown is outdated", Me)
    End Sub

    Private Sub picAlert_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles picAlert.MouseEnter
        ToolTip1.ToolTipTitle = "Alert"
        ToolTip1.Show("Telemetry data shown is outdated", Me)
    End Sub

    Private Sub picAlert_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles picAlert.MouseHover
        
    End Sub

    Private Sub QuaterOfASecondToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuaterOfASecondToolStripMenuItem.Click
        timTelemetry.Interval = 250
        timTelemetry.Enabled = True

        btnTel.Text = ("Telemetry Enabled")
        btnTelemetry2.Checked = True
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        SendDataNewLine("sendtel")
        timTelemetry.Enabled = False

        btnTel.Text = ("Telemetry")
        btnTelemetry2.Checked = False
    End Sub

    Private Sub timTelemetry_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timTelemetry.Tick
        SendDataNewLine("sendtel")
    End Sub

    Private Sub HalfASecondToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HalfASecondToolStripMenuItem.Click
        timTelemetry.Interval = 500
        timTelemetry.Enabled = True
        btnTel.Text = ("Telemetry Enabled")
        btnTelemetry2.Checked = True
    End Sub

  
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        timTelemetry.Interval = 1000
        timTelemetry.Enabled = True
        btnTel.Text = ("Telemetry Enabled")
        btnTelemetry2.Checked = True
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        timTelemetry.Interval = 5000
        timTelemetry.Enabled = True
        btnTel.Text = ("Telemetry Enabled")
        btnTelemetry2.Checked = True
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        timTelemetry.Interval = 10000
        timTelemetry.Enabled = True
        btnTel.Text = ("Telemetry Enabled")
        btnTelemetry2.Checked = True
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        timTelemetry.Interval = 60000
        timTelemetry.Enabled = True
        btnTel.Text = ("Telemetry Enabled")
        btnTelemetry2.Checked = True
    End Sub
End Class
