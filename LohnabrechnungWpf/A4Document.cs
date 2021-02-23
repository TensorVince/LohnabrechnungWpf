using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace LohnabrechnungWpf
{
    class A4Document
    {
        private PdfDocument m_Document;
        private PdfPage m_Page;
        private XGraphics m_XGobj;

        public A4Document()
        {
            m_Document = new PdfDocument();
            m_Page = new PdfPage(m_Document);
            m_Page.Size = PdfSharp.PageSize.A4;
            m_XGobj = XGraphics.FromPdfPage(m_Page);
        }

        /// <summary>
        /// Rechnet Centimeter in Pixel-Koordinaten um, damit man 
        /// Objekte leichter auf dem Din-A4 Blatt positionieren kann.
        /// </summary>
        /// <param name="xCM">Der X-Wert in Centimetern</param>
        /// <param name="yCM">Der Y-Wert in Centimetern</param>
        /// <returns></returns>
        private Point GetMetricPositionAsPixelPoint(double xCM, double yCM)
        {
            double x = (m_Page.Width.Point / m_Page.Width.Centimeter) * xCM;
            double y = (m_Page.Height.Point / m_Page.Height.Centimeter) * yCM;

            //x = (m_Page.Width.Centimeter / m_Page.Width.Point) * xCM;
            //y = (m_Page.Height.Centimeter / m_Page.Height.Point) * yCM;

            Point retPoint = new Point(x, y);
            return retPoint;
        }

        private void PositionLayoutRectangle(XRect layoutRectangle, Enums.E_VerticalBoundingBoxAlignment verticalAlignment = Enums.E_VerticalBoundingBoxAlignment.Top, Enums.E_HorizontalBoundingBoxAlignment horizontalAlignment = Enums.E_HorizontalBoundingBoxAlignment.Left)
        {
            
        }


        public void AddText(string myText, double x, double y, double size = 30.0, string fontFamily = "Courier New")
        {
            XFont font = new XFont(fontFamily, size);
            Point recalculatedXY = GetMetricPositionAsPixelPoint(x, y);
            XRect layoutRectangle = new XRect(recalculatedXY.X, recalculatedXY.Y, m_Page.Width, m_Page.Height);
            m_XGobj.DrawString(myText, font, XBrushes.Black, recalculatedXY.X, recalculatedXY.Y);
            //m_XGobj.DrawString(myText, font, XBrushes.Black, layoutRectangle);
        }

        public void SaveFile(string savePath, bool viewFileAfterSave)
        {
            m_Document.AddPage(m_Page);
            m_Document.Save(savePath);

            if (viewFileAfterSave)
                Process.Start(savePath);
        }
    }
}
