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

        public void AddText(string myText, double x, double y, double size = 30.0, string fontFamily = "Courier New")
        {
            XFont font = new XFont(fontFamily, size);
            XRect boundingBox = new XRect(x, y, m_Page.Width, m_Page.Height);
            m_XGobj.DrawString(myText, font, XBrushes.Black, x, y);
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
