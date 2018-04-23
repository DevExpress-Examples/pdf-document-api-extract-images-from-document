#region #Reference
using System;
using System.Collections.Generic;
using System.Drawing;
using DevExpress.Pdf;
// ...
#endregion #Reference

namespace PdfProcessorGetImages {
    class Program {
        #region #Code
        static void Main(string[] args) {
            PdfDocumentProcessor processor = new PdfDocumentProcessor();
            processor.LoadDocument(@"..\\..\\Demo.pdf");

            int xCount = 8; 
            int yCount = 2;
            double cardWidth = 150.5; // Measured in points (equals 2.09 inches).
            double cardHeight = 442; // Measured in points (equals 6.138 inches).
            double xMargin = 122; // Measured in points (equals 1.694 inches).
            double yMargin = 77; // Measured in points (equals 1.069 inches).
            double yCoord = yMargin;

            for (int y = 0; y < yCount; y++, yCoord += cardHeight) {
                double xCoord = xMargin;
                for (int x = 0; x < xCount; x++, xCoord += cardWidth) {
                    PdfDocumentArea area = new PdfDocumentArea(1,
                        new PdfRectangle(xCoord, yCoord, xCoord + cardWidth, yCoord + cardHeight));
                    IList<Bitmap> bitmaps = processor.GetImages(area);
                    if (bitmaps.Count != 0) {
                        bitmaps[0].Save(String.Format(@"{0}_{1}.bmp", x, y));
                        bitmaps[0].Dispose();
                    }
                    Console.WriteLine(bitmaps.Count.ToString());
                }
            }
        }
        #endregion #Code
    }
}
