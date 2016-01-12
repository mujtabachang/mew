Imports System.Drawing.Drawing2D

Module Instruments
    Public CompassImage As Image
    Public RollImage As Image
    Public PitchImage As Image
    Public SpeedImage As Image

    Sub DrawCompass2(ByVal GivHeading As Integer)

        'frmMain.PicCompass.Image = Nothing
        CompassImage = Nothing


        Dim image As New Bitmap(240, 230)
        Dim g As Graphics = Graphics.FromImage(image)
        g.SmoothingMode = SmoothingMode.AntiAlias

        'Dim g As Graphics = PicCompass.CreateGraphics()

        ' Create Rectangle To Limit brush area.
        Dim rect As New Rectangle(0, 0, 230, 300)

        ' Create Brush
        Dim linearBrush As New LinearGradientBrush( _
            rect, _
            Color.FromArgb(0, 0, 0), _
            Color.FromArgb(120, 120, 255), _
            225)

        ' Draw Outer Rim to screen.
        g.FillEllipse(linearBrush, 20, 20, 200, 200)

        linearBrush.LinearColors = New Color() {Color.FromArgb(120, 120, 225), _
            Color.FromArgb(0, 0, 0)}

        ' Draw Inner Rim to screen.
        g.FillEllipse(linearBrush, 30, 30, 180, 180)

        linearBrush.LinearColors = New Color() {Color.FromArgb(0, 0, 0), _
    Color.FromArgb(120, 120, 255)}

        ' Draw face to screen.
        g.FillEllipse(linearBrush, 33, 33, 174, 174)

        ' Create Brush
        Dim numeralBrush As New SolidBrush(Color.White)
        Dim numeralBrush2 As New SolidBrush(Color.Wheat)

        ' Create Font
        Dim textFont As New Font("Arial Bold", 10.0F)

        'g.DrawEllipse( New Pen(Color.White, 1), 40, 40, 160, 160 )
        'g.DrawEllipse( New Pen(Color.White, 1), 60, 60, 120, 120 )

        ' Draw Numerals
        g.DrawString("0", textFont, numeralBrush, 113, 40)
        g.DrawString("N", textFont, numeralBrush2, 113, 25)


        g.DrawString("270", textFont, numeralBrush, 40, 110)
        g.DrawString("W", textFont, numeralBrush2, 20, 110)

        g.DrawString("180", textFont, numeralBrush, 103, 180)
        g.DrawString("S", textFont, numeralBrush2, 110, 200)

        g.DrawString("90", textFont, numeralBrush, 182, 110)
        g.DrawString("E", textFont, numeralBrush2, 200, 110)

        'g.DrawString("2", textFont, numeralBrush, 173, 75)
        'g.DrawString("1", textFont, numeralBrush, 150, 50)

        numeralBrush = New SolidBrush(Color.White)
        textFont = New Font("Tahoma", 10.0F)

        g.DrawString("Compass: " & GivHeading, textFont, numeralBrush, 70, 0)



        g.TranslateTransform(120, 120, MatrixOrder.Append)


        Dim hourBrush As New SolidBrush(Color.Red)

        Dim hourBrush2 As New SolidBrush(Color.White)



        Dim hourAngle As Single = GivHeading * Math.PI / 180
        '2.0 * Math.PI * (hour1) / 12.0

        Dim hourAngle2 As Single = hourAngle + (180 * Math.PI / 180)

        ' Draw Hour Hand
        Dim gpHour As New GraphicsPath()
        Dim HourArrow As Point() = { _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle))), _
          New Point(Convert.ToInt32(-5 * Math.Cos(hourAngle)), _
                     Convert.ToInt32(-5 * Math.Sin(hourAngle))), _
          New Point(Convert.ToInt32(5 * Math.Cos(hourAngle)), _
                     Convert.ToInt32(5 * Math.Sin(hourAngle))), _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle)))}

        gpHour.AddPolygon(HourArrow)
        g.FillPath(hourBrush, gpHour)
        g.FillEllipse(hourBrush, -5, -5, 10, 10)



        Dim gpHour2 As New GraphicsPath()
        Dim HourArrow2 As Point() = { _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle2)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle2))), _
          New Point(Convert.ToInt32(-5 * Math.Cos(hourAngle2)), _
                     Convert.ToInt32(-5 * Math.Sin(hourAngle2))), _
          New Point(Convert.ToInt32(5 * Math.Cos(hourAngle2)), _
                     Convert.ToInt32(5 * Math.Sin(hourAngle2))), _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle2)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle2)))}

        gpHour2.AddPolygon(HourArrow2)
        g.FillPath(hourBrush2, gpHour2)
        g.FillEllipse(hourBrush2, -5, -5, 10, 10)

        'frmMain.PicCompass.Image = image
        CompassImage = image

    End Sub
   
    Sub DrawRoll2(ByVal GivRoll As Integer)      'Roll goes from -90 to +90

        'frmMain.PicRoll.Image = Nothing

        RollImage = Nothing

        Dim GivRoll2 = GivRoll




        Dim image As New Bitmap(240, 230)
        Dim g As Graphics = Graphics.FromImage(image)
        g.SmoothingMode = SmoothingMode.AntiAlias
        'Dim g As Graphics = PicCompass.CreateGraphics()

        ' Create Rectangle To Limit brush area.
        Dim rect As New Rectangle(0, 0, 230, 300)

        ' Create Brush
        Dim linearBrush As New LinearGradientBrush( _
            rect, _
            Color.FromArgb(0, 0, 0), _
            Color.FromArgb(120, 120, 255), _
            225)

        ' Draw Outer Rim to screen.
        g.FillEllipse(linearBrush, 20, 20, 200, 200)

        linearBrush.LinearColors = New Color() {Color.FromArgb(120, 120, 225), _
            Color.FromArgb(0, 0, 0)}

        ' Draw Inner Rim to screen.
        g.FillEllipse(linearBrush, 30, 30, 180, 180)

        linearBrush.LinearColors = New Color() {Color.FromArgb(0, 0, 0), _
    Color.FromArgb(120, 120, 255)}

        ' Draw face to screen.
        g.FillEllipse(linearBrush, 33, 33, 174, 174)

        ' Create Brush
        Dim numeralBrush As New SolidBrush(Color.White)

        ' Create Font
        Dim textFont As New Font("Arial Bold", 10.0F)

        'g.DrawEllipse( New Pen(Color.White, 1), 40, 40, 160, 160 )
        'g.DrawEllipse( New Pen(Color.White, 1), 60, 60, 120, 120 )

        ' Draw Numerals
        'g.DrawString("0", textFont, numeralBrush, 113, 40)
        'g.DrawString("11", textFont, numeralBrush, 75, 50)
        'g.DrawString("10", textFont, numeralBrush, 47, 75)
        g.DrawString("0", textFont, numeralBrush, 40, 110)
        'g.DrawString("8", textFont, numeralBrush, 52, 145)
        'g.DrawString("7", textFont, numeralBrush, 75, 170)
        'g.DrawString("0", textFont, numeralBrush, 103, 180)
        'g.DrawString("5", textFont, numeralBrush, 150, 170)
        'g.DrawString("4", textFont, numeralBrush, 173, 145)
        g.DrawString("0", textFont, numeralBrush, 182, 110)
        'g.DrawString("2", textFont, numeralBrush, 173, 75)
        'g.DrawString("1", textFont, numeralBrush, 150, 50)

        numeralBrush = New SolidBrush(Color.White)
        textFont = New Font("Tahoma", 10.0F)

        g.DrawString("Roll: " & GivRoll, textFont, numeralBrush, 85, 0)



        g.TranslateTransform(120, 120, MatrixOrder.Append)


        Dim hourBrush As New SolidBrush(Color.White)

        Dim hourBrush2 As New SolidBrush(Color.White)

        Dim hourAngle As Single
        Dim hourAngle2 As Single
        If GivRoll > 0 Then


            hourAngle = GivRoll * Math.PI / 180
            hourAngle = hourAngle + (90 * Math.PI / 180)
            '2.0 * Math.PI * (hour1) / 12.0

            hourAngle2 = hourAngle + (180 * Math.PI / 180)
        Else

            hourAngle = GivRoll * Math.PI / 180
            hourAngle = hourAngle + (90 * Math.PI / 180)
            '2.0 * Math.PI * (hour1) / 12.0

            hourAngle2 = hourAngle + (180 * Math.PI / 180)

        End If

        ' Draw Hour Hand
        Dim gpHour As New GraphicsPath()
        Dim HourArrow As Point() = { _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle))), _
          New Point(Convert.ToInt32(-5 * Math.Cos(hourAngle)), _
                     Convert.ToInt32(-5 * Math.Sin(hourAngle))), _
          New Point(Convert.ToInt32(5 * Math.Cos(hourAngle)), _
                     Convert.ToInt32(5 * Math.Sin(hourAngle))), _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle)))}

        gpHour.AddPolygon(HourArrow)
        g.FillPath(hourBrush, gpHour)
        g.FillEllipse(hourBrush, -5, -5, 10, 10)



        Dim gpHour2 As New GraphicsPath()
        Dim HourArrow2 As Point() = { _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle2)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle2))), _
          New Point(Convert.ToInt32(-5 * Math.Cos(hourAngle2)), _
                     Convert.ToInt32(-5 * Math.Sin(hourAngle2))), _
          New Point(Convert.ToInt32(5 * Math.Cos(hourAngle2)), _
                     Convert.ToInt32(5 * Math.Sin(hourAngle2))), _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle2)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle2)))}

        gpHour2.AddPolygon(HourArrow2)
        g.FillPath(hourBrush2, gpHour2)
        g.FillEllipse(hourBrush2, -5, -5, 10, 10)

        'frmMain.PicRoll.Image = image

        RollImage = image

    End Sub


    Sub DrawPitch2(ByVal GivPitch As Integer)      'Pitch goes from -90 to +90

        'frmMain.PicPitch.Image = Nothing

        PitchImage = Nothing

        Dim GivPitch2 = GivPitch




        Dim image As New Bitmap(240, 230)
        Dim g As Graphics = Graphics.FromImage(image)
        g.SmoothingMode = SmoothingMode.AntiAlias
        'Dim g As Graphics = PicCompass.CreateGraphics()

        ' Create Rectangle To Limit brush area.
        Dim rect As New Rectangle(0, 0, 230, 300)

        ' Create Brush
        Dim linearBrush As New LinearGradientBrush( _
            rect, _
            Color.FromArgb(0, 0, 0), _
            Color.FromArgb(120, 120, 255), _
            225)

        ' Draw Outer Rim to screen.
        g.FillEllipse(linearBrush, 20, 20, 200, 200)

        linearBrush.LinearColors = New Color() {Color.FromArgb(120, 120, 225), _
            Color.FromArgb(0, 0, 0)}

        ' Draw Inner Rim to screen.
        g.FillEllipse(linearBrush, 30, 30, 180, 180)

        linearBrush.LinearColors = New Color() {Color.FromArgb(0, 0, 0), _
    Color.FromArgb(120, 120, 255)}

        ' Draw face to screen.
        g.FillEllipse(linearBrush, 33, 33, 174, 174)

        ' Create Brush
        Dim numeralBrush As New SolidBrush(Color.White)



        ' Create Font
        Dim textFont As New Font("Arial Bold", 10.0F)

        'g.DrawEllipse( New Pen(Color.White, 1), 40, 40, 160, 160 )
        'g.DrawEllipse( New Pen(Color.White, 1), 60, 60, 120, 120 )

        ' Draw Numerals
        'g.DrawString("0", textFont, numeralBrush, 113, 40)
        'g.DrawString("11", textFont, numeralBrush, 75, 50)
        'g.DrawString("10", textFont, numeralBrush, 47, 75)
        g.DrawString("0", textFont, numeralBrush, 40, 110)
        'g.DrawString("8", textFont, numeralBrush, 52, 145)
        'g.DrawString("7", textFont, numeralBrush, 75, 170)
        'g.DrawString("0", textFont, numeralBrush, 103, 180)
        'g.DrawString("5", textFont, numeralBrush, 150, 170)
        'g.DrawString("4", textFont, numeralBrush, 173, 145)
        g.DrawString("0", textFont, numeralBrush, 182, 110)
        'g.DrawString("2", textFont, numeralBrush, 173, 75)
        'g.DrawString("1", textFont, numeralBrush, 150, 50)

        numeralBrush = New SolidBrush(Color.White)
        textFont = New Font("Tahoma", 10.0F)

        g.DrawString("Pitch: " & GivPitch, textFont, numeralBrush, 85, 0)



        g.TranslateTransform(120, 120, MatrixOrder.Append)


        Dim hourBrush As New SolidBrush(Color.White)

        Dim hourBrush2 As New SolidBrush(Color.White)

        Dim hourAngle As Single
        Dim hourAngle2 As Single
        If GivPitch > 0 Then


            hourAngle = GivPitch * Math.PI / 180
            hourAngle = hourAngle + (90 * Math.PI / 180)
            '2.0 * Math.PI * (hour1) / 12.0

            hourAngle2 = hourAngle + (180 * Math.PI / 180)
        Else

            hourAngle = GivPitch * Math.PI / 180
            hourAngle = hourAngle + (90 * Math.PI / 180)
            '2.0 * Math.PI * (hour1) / 12.0

            hourAngle2 = hourAngle + (180 * Math.PI / 180)

        End If

        ' Draw Hour Hand
        Dim gpHour As New GraphicsPath()
        Dim HourArrow As Point() = { _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle))), _
          New Point(Convert.ToInt32(-5 * Math.Cos(hourAngle)), _
                     Convert.ToInt32(-5 * Math.Sin(hourAngle))), _
          New Point(Convert.ToInt32(5 * Math.Cos(hourAngle)), _
                     Convert.ToInt32(5 * Math.Sin(hourAngle))), _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle)))}

        gpHour.AddPolygon(HourArrow)
        g.FillPath(hourBrush, gpHour)
        g.FillEllipse(hourBrush, -5, -5, 10, 10)



        Dim gpHour2 As New GraphicsPath()
        Dim HourArrow2 As Point() = { _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle2)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle2))), _
          New Point(Convert.ToInt32(-5 * Math.Cos(hourAngle2)), _
                     Convert.ToInt32(-5 * Math.Sin(hourAngle2))), _
          New Point(Convert.ToInt32(5 * Math.Cos(hourAngle2)), _
                     Convert.ToInt32(5 * Math.Sin(hourAngle2))), _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle2)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle2)))}

        gpHour2.AddPolygon(HourArrow2)
        g.FillPath(hourBrush2, gpHour2)
        g.FillEllipse(hourBrush2, -5, -5, 10, 10)

        'frmMain.PicPitch.Image = image

        PitchImage = image

    End Sub



    Sub DrawSpeed2(ByVal GivSpeed As Integer)      'Speed goes from 0 to 12

        'frmMain.PicSpeed.Image = Nothing
        SpeedImage = Nothing
        Dim GivSpeed2 = GivSpeed




        Dim image As New Bitmap(240, 230)
        Dim g As Graphics = Graphics.FromImage(image)
        g.SmoothingMode = SmoothingMode.AntiAlias
        'Dim g As Graphics = PicCompass.CreateGraphics()

        ' Create Rectangle To Limit brush area.
        Dim rect As New Rectangle(0, 0, 230, 300)

        ' Create Brush
        Dim linearBrush As New LinearGradientBrush( _
            rect, _
            Color.FromArgb(0, 0, 0), _
            Color.FromArgb(120, 120, 255), _
            225)

        ' Draw Outer Rim to screen.
        g.FillEllipse(linearBrush, 20, 20, 200, 200)

        linearBrush.LinearColors = New Color() {Color.FromArgb(120, 120, 225), _
            Color.FromArgb(0, 0, 0)}

        ' Draw Inner Rim to screen.
        g.FillEllipse(linearBrush, 30, 30, 180, 180)

        linearBrush.LinearColors = New Color() {Color.FromArgb(0, 0, 0), _
    Color.FromArgb(120, 120, 255)}

        ' Draw face to screen.
        g.FillEllipse(linearBrush, 33, 33, 174, 174)

        ' Create Brush
        Dim numeralBrush As New SolidBrush(Color.White)

        ' Create Font
        Dim textFont As New Font("Arial Bold", 10.0F)

        'g.DrawEllipse( New Pen(Color.White, 1), 40, 40, 160, 160 )
        'g.DrawEllipse( New Pen(Color.White, 1), 60, 60, 120, 120 )

        '' Draw Numerals
        g.DrawString("0", textFont, numeralBrush, 109, 40)
        g.DrawString("22", textFont, numeralBrush, 75, 50)
        g.DrawString("20", textFont, numeralBrush, 47, 75)
        g.DrawString("18", textFont, numeralBrush, 43, 110)
        g.DrawString("16", textFont, numeralBrush, 52, 145)
        g.DrawString("14", textFont, numeralBrush, 75, 170)
        g.DrawString("12", textFont, numeralBrush, 113, 180)
        g.DrawString("10", textFont, numeralBrush, 150, 170)
        g.DrawString("8", textFont, numeralBrush, 173, 145)
        g.DrawString("6", textFont, numeralBrush, 182, 110)
        g.DrawString("4", textFont, numeralBrush, 173, 75)
        g.DrawString("2", textFont, numeralBrush, 150, 50)

        numeralBrush = New SolidBrush(Color.White)
        textFont = New Font("Tahoma", 10.0F)

        g.DrawString("Speed: " & GivSpeed2, textFont, numeralBrush, 85, 0)



        g.TranslateTransform(120, 120, MatrixOrder.Append)


        Dim hourBrush As New SolidBrush(Color.White)

        Dim hourBrush2 As New SolidBrush(Color.White)

        Dim hourAngle As Single
        Dim hourAngle2 As Single



        hourAngle = GivSpeed * Math.PI / 12
        'hourAngle = hourAngle + (90 * Math.PI / 180) / 12
        '2.0 * Math.PI * (hour1) / 12.0

        'hourAngle2 = hourAngle + (180 * Math.PI / 180)




        ' Draw Hour Hand
        Dim gpHour As New GraphicsPath()
        Dim HourArrow As Point() = { _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle))), _
          New Point(Convert.ToInt32(-5 * Math.Cos(hourAngle)), _
                     Convert.ToInt32(-5 * Math.Sin(hourAngle))), _
          New Point(Convert.ToInt32(5 * Math.Cos(hourAngle)), _
                     Convert.ToInt32(5 * Math.Sin(hourAngle))), _
          New Point(Convert.ToInt32(40 * Math.Sin(hourAngle)), _
                     Convert.ToInt32(-40 * Math.Cos(hourAngle)))}

        gpHour.AddPolygon(HourArrow)
        g.FillPath(hourBrush, gpHour)
        g.FillEllipse(hourBrush, -5, -5, 10, 10)





        'frmMain.PicSpeed.Image = image
        SpeedImage = image

    End Sub
End Module
