#Region "#Reference"
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports DevExpress.Pdf
' ...
#End Region ' #Reference

Namespace PdfProcessorGetImages
    Friend Class Program
        #Region "#Code"
        Shared Sub Main(ByVal args() As String)
            Dim processor As New PdfDocumentProcessor()
            processor.LoadDocument("..\\..\\Demo.pdf")

            Dim xCount As Integer = 8 ' The page rotation angle is 90 degrees.
            Dim yCount As Integer = 2
            Dim cardWidth As Double = 150.5 ' Measured in points (equals 2.09 inches).
            Dim cardHeight As Double = 442 ' Measured in points (equals 6.138 inches).
            Dim xMargin As Double = 122 ' Measured in points (equals 1.694 inches).
            Dim yMargin As Double = 77 ' Measured in points (equals 1.069 inches).
            Dim yCoord As Double = yMargin

            Dim y As Integer = 0
            Do While y < yCount
                Dim xCoord As Double = xMargin
                Dim x As Integer = 0
                Do While x < xCount
                    Dim area As New PdfDocumentArea(1, New PdfRectangle(xCoord, yCoord, xCoord + cardWidth, yCoord + cardHeight))
                    Dim bitmaps As IList(Of Bitmap) = processor.GetImages(area)
                    If bitmaps.Count <> 0 Then
                        bitmaps(0).Save(String.Format("{0}_{1}.bmp", x, y))
                        bitmaps(0).Dispose()
                    End If
                    Console.WriteLine(bitmaps.Count.ToString())
                    x += 1
                    xCoord += cardWidth
                Loop
                y += 1
                yCoord += cardHeight
            Loop
        End Sub
        #End Region ' #Code
    End Class
End Namespace
