using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace ColorLogoMaker
{
    class Layer
    {
        internal FastBitmap m_bmpImage;
        private FastBitmap m_bmpMask;
        public Double m_nOpacity;
        private Int32 m_nOffsetX, m_nOffsetY;

        public Layer(Int32 nWidth, Int32 nHeight)
        {
            m_bmpImage = new FastBitmap(nWidth, nHeight, PixelFormat.Format32bppArgb);
            Clear(Color.Transparent);
            m_nOpacity = 1.0;
        }

        public Double Opacity
        {
            get { return m_nOpacity; }
            set { m_nOpacity = value; }
        }

        public FastBitmap Bitmap
        {
            get { return m_bmpImage; }
        }

        public FastBitmap Mask
        {
            get { return m_bmpMask; }
            set { m_bmpMask = value; }
        }

        public Int32 OffsetX
        {
            get { return m_nOffsetX; }
            set { m_nOffsetX = value; }
        }

        public Int32 OffsetY
        {
            get { return m_nOffsetY; }
            set { m_nOffsetY = value; }
        }

        public Object Clone()
        {
            Layer layerClone = new Layer(m_bmpImage.Width, m_bmpImage.Height);
            layerClone.m_bmpImage = (FastBitmap)m_bmpImage.Clone();
            return layerClone;
        }

        public void Clear(Color c)
        {
            m_bmpImage.Lock();
            for (Int32 y = 0; y < m_bmpImage.Height; y++)
                for (Int32 x = 0; x < m_bmpImage.Width; x++)
                    m_bmpImage.SetPixel(x, y, c);
            m_bmpImage.Unlock();
        }

        public void DrawText(Int32 x, Int32 y, String strText, Font font,
            Brush brush)
        {
            Graphics g = Graphics.FromImage(m_bmpImage.m_oBitmap);
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.DrawString(strText, font, brush, x, y, StringFormat.GenericTypographic);
            g.Dispose();
        }

        public void FillRectangle(Int32 x, Int32 y, Int32 nWidth,
            Int32 nHeight, Brush brush)
        {
            Graphics g = Graphics.FromImage(m_bmpImage.m_oBitmap);
            g.FillRectangle(brush, x, y, nWidth, nHeight);
            g.Dispose();
        }

        public Color GetPixel(Int32 x, Int32 y)
        {
            return m_bmpImage.GetPixel(x, y);
        }

        public void Invert()
        {
            m_bmpImage.Lock();
            for (Int32 y = 0; y < m_bmpImage.Height; y++)
            {
                for (Int32 x = 0; x < m_bmpImage.Width; x++)
                {
                    Color c = m_bmpImage.GetPixel(x, y);
                    m_bmpImage.SetPixel(x, y, Color.FromArgb(c.A,
                        255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            m_bmpImage.Unlock();
        }

        private Single Gauss(Single x, Single nMiddle, Single nWidth)
        {
            if (nWidth == 0)
                return 1F;

            Double t = -(1.0 / nWidth) * ((nMiddle - x) * (nMiddle - x));

            return (Single)Math.Pow(Math.E, t);
        }

        public void Blur(Int32 nHorz, Int32 nVert)
        {
            Single nWeightSum;
            Single[] nWeights;

            FastBitmap bmpBlur = (FastBitmap)m_bmpImage.Clone();

            m_bmpImage.Lock();
            bmpBlur.Lock();

            // horizontal blur

            nWeights = new Single[nHorz * 2 + 1];
            for (Int32 i = 0; i < nHorz * 2 + 1; i++)
            {
                Single y = Gauss(-nHorz + i, 0, nHorz);
                nWeights[i] = y;
            }

            for (Int32 row = 0; row < m_bmpImage.Height; row++)
            {
                for (Int32 col = 0; col < m_bmpImage.Width; col++)
                {
                    Double r = 0;
                    Double g = 0;
                    Double b = 0;
                    nWeightSum = 0;
                    for (Int32 i = 0; i < nHorz * 2 + 1; i++)
                    {
                        Int32 x = col - nHorz + i;
                        if (x < 0)
                        {
                            i += -x;
                            x = 0;
                        }
                        if (x > m_bmpImage.Width - 1)
                            break;
                        Color c = m_bmpImage.GetPixel(x, row);
                        r += c.R * nWeights[i];
                        g += c.G * nWeights[i];
                        b += c.B * nWeights[i];
                        nWeightSum += nWeights[i];
                    }
                    r /= nWeightSum;
                    g /= nWeightSum;
                    b /= nWeightSum;
                    Byte br = (Byte)Math.Round(r);
                    Byte bg = (Byte)Math.Round(g);
                    Byte bb = (Byte)Math.Round(b);
                    if (br > 255) br = 255;
                    if (bg > 255) bg = 255;
                    if (bb > 255) bb = 255;
                    bmpBlur.SetPixel(col, row, Color.FromArgb(br, bg, bb));
                }
            }

            // vertical blur

            nWeights = new Single[nVert * 2 + 1];
            for (Int32 i = 0; i < nVert * 2 + 1; i++)
            {
                Single y = Gauss(-nVert + i, 0, nVert);
                nWeights[i] = y;
            }

            for (Int32 col = 0; col < m_bmpImage.Width; col++)
            {
                for (Int32 row = 0; row < m_bmpImage.Height; row++)
                {
                    Double r = 0;
                    Double g = 0;
                    Double b = 0;
                    nWeightSum = 0;
                    for (Int32 i = 0; i < nVert * 2 + 1; i++)
                    {
                        Int32 y = row - nVert + i;
                        if (y < 0)
                        {
                            i += -y;
                            y = 0;
                        }
                        if (y > m_bmpImage.Height - 1)
                            break;
                        Color c = bmpBlur.GetPixel(col, y);
                        r += c.R * nWeights[i];
                        g += c.G * nWeights[i];
                        b += c.B * nWeights[i];
                        nWeightSum += nWeights[i];
                    }
                    r /= nWeightSum;
                    g /= nWeightSum;
                    b /= nWeightSum;
                    Byte br = (Byte)Math.Round(r);
                    Byte bg = (Byte)Math.Round(g);
                    Byte bb = (Byte)Math.Round(b);
                    if (br > 255) br = 255;
                    if (bg > 255) bg = 255;
                    if (bb > 255) bb = 255;
                    m_bmpImage.SetPixel(col, row, Color.FromArgb(br, bg, bb));
                }
            }

            bmpBlur.Dispose();		// will unlock
            m_bmpImage.Unlock();
        }

        private Byte GetBumpMapPixel(FastBitmap bmp, Int32 x, Int32 y)
        {
            // create a single number from R, G and B values at point (x, y)
            // if point (x, y) lays outside the bitmap, GetBumpMapPixel()
            // returns the closest pixel within the bitmap

            if (x < 0)
                x = 0;
            if (x > m_bmpImage.Width - 1)
                x = m_bmpImage.Width - 1;

            if (y < 0)
                y = 0;
            if (y > m_bmpImage.Height - 1)
                y = m_bmpImage.Height - 1;

            return bmp.GetIntensity(x, y);
        }

        public void BumpMap(Layer layerMap, Int32 nAzimuth, Int32 nElevation, Int32 nBevelWidth, Boolean bLightAlways)
        {
            layerMap.m_bmpImage.Lock();
            m_bmpImage.Lock();

            for (Int32 row = 0; row < m_bmpImage.Height; row++)
            {
                for (Int32 col = 0; col < m_bmpImage.Width; col++)
                {
                    // calculate normal for point (col, row)
                    // this is an approximation of the derivative

                    Byte[] x = new Byte[6];

                    x[0] = GetBumpMapPixel(layerMap.m_bmpImage, col - 1, row - 1);
                    x[1] = GetBumpMapPixel(layerMap.m_bmpImage, col - 1, row - 0);
                    x[2] = GetBumpMapPixel(layerMap.m_bmpImage, col - 1, row + 1);
                    x[3] = GetBumpMapPixel(layerMap.m_bmpImage, col + 1, row - 1);
                    x[4] = GetBumpMapPixel(layerMap.m_bmpImage, col + 1, row - 0);
                    x[5] = GetBumpMapPixel(layerMap.m_bmpImage, col + 1, row + 1);

                    Single nNormalX = x[0] + x[1] + x[2] - x[3] - x[4] - x[5];

                    x[0] = GetBumpMapPixel(layerMap.m_bmpImage, col - 1, row + 1);
                    x[1] = GetBumpMapPixel(layerMap.m_bmpImage, col - 0, row + 1);
                    x[2] = GetBumpMapPixel(layerMap.m_bmpImage, col + 1, row + 1);
                    x[3] = GetBumpMapPixel(layerMap.m_bmpImage, col - 1, row - 1);
                    x[4] = GetBumpMapPixel(layerMap.m_bmpImage, col - 0, row - 1);
                    x[5] = GetBumpMapPixel(layerMap.m_bmpImage, col + 1, row - 1);

                    Single nNormalY = x[0] + x[1] + x[2] - x[3] - x[4] - x[5];

                    Single nNormalZ = (6F * 255F) / nBevelWidth;

                    Single nLength = (Single)Math.Sqrt(
                        nNormalX * nNormalX +
                        nNormalY * nNormalY +
                        nNormalZ * nNormalZ);

                    if (nLength != 0)
                    {
                        nNormalX /= nLength;
                        nNormalY /= nLength;
                        nNormalZ /= nLength;
                    }

                    // convert to radians

                    Double nAzimuthRadian = nAzimuth / 180.0 * Math.PI;
                    Double nElevationRadian = nElevation / 180.0 * Math.PI;

                    // light vector -- this is the location of the light
                    // source but it also serves as the direction with
                    // origin <0, 0, 0>
                    // the formulas to calculate x, y and z are those to
                    // rotate a point in 3D space
                    // if lightzalways1 is true, nLightZ is set to 1
                    // because we want full color intensity for that pixel;
                    // if we set nLightZ to (Single)Math.Sin(nElevationRadian),
                    // which is the correct way to calculate nLightZ, the
                    // color is more dark, but when we ignore nLightZ, the
                    // light source is straight above the pixel and
                    // therefore sin(nElevationRadian) is always 1

                    Single nLightX = (Single)(Math.Cos(nAzimuthRadian) *
                        Math.Cos(nElevationRadian));
                    Single nLightY = (Single)(Math.Sin(nAzimuthRadian) *
                        Math.Cos(nElevationRadian));
                    Single nLightZ = 1F;
                    if (!bLightAlways)
                        nLightZ = (Single)Math.Sin(nElevationRadian);

                    // the normal and light vector are unit vectors, so
                    // taking the dot product of these two yields the
                    // cosine of the angle between them

                    Single nCosLightNormal = 0;
                    nCosLightNormal += nNormalX * nLightX;
                    nCosLightNormal += nNormalY * nLightY;
                    nCosLightNormal += nNormalZ * nLightZ;

                    // get pixel (col, row) of this layer, calculate color
                    // and set pixel back with new color

                    Color c = m_bmpImage.GetPixel(col, row);
                    Single r = c.R;
                    Single g = c.G;
                    Single b = c.B;
                    r *= nCosLightNormal;
                    g *= nCosLightNormal;
                    b *= nCosLightNormal;
                    Byte red = (Byte)Math.Min(Math.Round(r), 255);
                    Byte green = (Byte)Math.Min(Math.Round(g), 255);
                    Byte blue = (Byte)Math.Min(Math.Round(b), 255);
                    m_bmpImage.SetPixel(col, row, Color.FromArgb(red, green, blue));
                }
            }

            m_bmpImage.Unlock();
            layerMap.m_bmpImage.Unlock();
        }
    }
}
