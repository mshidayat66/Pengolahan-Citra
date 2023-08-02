Imports System.Drawing.Imaging

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim originalImage As Bitmap = DirectCast(PictureBox1.Image, Bitmap)
        Dim colorSplitImage As Bitmap = SplitColorVerticallyWithBrightness(originalImage, 50)

        PictureBox2.Image = colorSplitImage
    End Sub

    Private Function SplitColorVerticallyWithBrightness(image As Bitmap, brightnessValue As Integer) As Bitmap
        Dim width As Integer = image.Width
        Dim height As Integer = image.Height
        Dim resultImage As New Bitmap(width, height)

        For x As Integer = 0 To width - 1
            For y As Integer = 0 To height - 1
                Dim pixel As Color = image.GetPixel(x, y)
                Dim red As Integer = 0
                Dim green As Integer = 0
                Dim blue As Integer = 0
                Dim position As Integer = x * 5 / width

                Select Case position
                    Case 0
                        red = Math.Min(255, pixel.R + brightnessValue)
                    Case 1
                        green = Math.Min(255, pixel.G + brightnessValue)
                    Case 2
                        blue = Math.Min(255, pixel.B + brightnessValue)
                    Case 3
                        red = Math.Min(255, pixel.R + brightnessValue)
                        green = Math.Min(255, pixel.G + brightnessValue)
                    Case 4
                        Dim gray As Integer = CInt(pixel.R * 0.3 + pixel.G * 0.59 + pixel.B * 0.11)
                        red = gray
                        green = gray
                        blue = gray
                End Select

                Dim newPixel As Color = Color.FromArgb(red, green, blue)

                resultImage.SetPixel(x, y, newPixel)
            Next
        Next

        Return resultImage
    End Function
End Class