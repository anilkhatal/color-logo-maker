using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ColorLogoMaker
{
    class FastBitmap
    {
        internal Bitmap m_oBitmap;
        private BitmapData m_oBitmapData;

        public FastBitmap(Int32 nWidth, Int32 nHeight, PixelFormat pixelFormat)
        {
            m_oBitmap = new Bitmap(nWidth, nHeight, pixelFormat);
        }

        ~FastBitmap()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(Boolean bDisposing)
        {
            Unlock();
            if (bDisposing)
            {
                m_oBitmap.Dispose();
            }
        }

        private FastBitmap()
        {
        }

        public Object Clone()
        {
            FastBitmap fbClone = new FastBitmap();
            fbClone.m_oBitmap = (Bitmap)m_oBitmap.Clone();
            return fbClone;
        }

        public Int32 Width
        {
            get { return m_oBitmap.Width; }
        }

        public Int32 Height
        {
            get { return m_oBitmap.Height; }
        }

        public void Lock()
        {
            m_oBitmapData = m_oBitmap.LockBits(
                new Rectangle(0, 0, m_oBitmap.Width, m_oBitmap.Height),
                ImageLockMode.ReadWrite,
                m_oBitmap.PixelFormat
                );
        }

        unsafe public Color GetPixel(Int32 x, Int32 y)
        {
            if (m_oBitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                Byte* b = (Byte*)m_oBitmapData.Scan0 + (y * m_oBitmapData.Stride) + (x * 4);
                return Color.FromArgb(*(b + 3), *(b + 2), *(b + 1), *b);
            }
            if (m_oBitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                Byte* b = (Byte*)m_oBitmapData.Scan0 + (y * m_oBitmapData.Stride) + (x * 3);
                return Color.FromArgb(*(b + 2), *(b + 1), *b);
            }
            return Color.Empty;
        }

        unsafe public void SetPixel(Int32 x, Int32 y, Color c)
        {
            if (m_oBitmapData.PixelFormat == PixelFormat.Format32bppArgb)
            {
                Byte* b = (Byte*)m_oBitmapData.Scan0 + (y * m_oBitmapData.Stride) + (x * 4);
                *b = c.B;
                *(b + 1) = c.G;
                *(b + 2) = c.R;
                *(b + 3) = c.A;
            }
            if (m_oBitmapData.PixelFormat == PixelFormat.Format24bppRgb)
            {
                Byte* b = (Byte*)m_oBitmapData.Scan0 + (y * m_oBitmapData.Stride) + (x * 3);
                *b = c.B;
                *(b + 1) = c.G;
                *(b + 2) = c.R;
            }
        }

        public Byte GetIntensity(Int32 x, Int32 y)
        {
            Color c = GetPixel(x, y);
            return (Byte)((c.R * 0.30 + c.G * 0.59 + c.B * 0.11) + 0.5);
        }

        public void Unlock()
        {
            if (m_oBitmapData != null)
            {
                m_oBitmap.UnlockBits(m_oBitmapData);
                m_oBitmapData = null;
            }
        }

        public void Save(String strFileName, ImageFormat format)
        {
            m_oBitmap.Save(strFileName, format);
        }

        public void Save(String strFileName)
        {
            m_oBitmap.Save(strFileName);
        }

        public Bitmap GetBitmap()
        {
            return m_oBitmap;
        }
    }
}
