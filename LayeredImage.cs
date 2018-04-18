using System;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ColorLogoMaker
{
    class LayeredImage
    {
        Int32 m_nWidth, m_nHeight;
        Bitmap m_bmpChecker;
        Layers m_arLayers;

        public LayeredImage(Int32 nWidth, Int32 nHeight)
        {
            m_nWidth = nWidth;
            m_nHeight = nHeight;
            m_arLayers = new Layers(this);

            // checker board brush

            m_bmpChecker = new Bitmap(32, 32, PixelFormat.Format24bppRgb);
            Color crDarkGray = Color.FromArgb(102, 102, 102);
            Color crLightGray = Color.FromArgb(153, 153, 153);
            for (Int32 i = 0; i < 32; i++)
            {
                for (Int32 j = 0; j < 32; j++)
                {
                    if ((i < 16 && j < 16) || (i >= 16 && j >= 16))
                        m_bmpChecker.SetPixel(j, i, crLightGray);
                    else
                        m_bmpChecker.SetPixel(j, i, crDarkGray);
                }
            }

            // background layer

            Layer layerBack = m_arLayers.Add();
            Graphics g = Graphics.FromImage(layerBack.m_bmpImage.m_oBitmap);
            TextureBrush brush = new TextureBrush(m_bmpChecker);
            g.FillRectangle(brush, 0, 0, m_nWidth, m_nHeight);
            brush.Dispose();
            g.Dispose();
        }

        public Int32 Width
        {
            get { return m_nWidth; }
        }

        public Int32 Height
        {
            get { return m_nHeight; }
        }

        public Layers Layers
        {
            get { return m_arLayers; }
        }

        internal FastBitmap Flatten(Color crBack)
        {
            // create a bitmap for result image

            FastBitmap bmpFinal = new FastBitmap(m_nWidth, m_nHeight, PixelFormat.Format24bppRgb);

            // lock all bitmaps
            bmpFinal.Lock();
            for (Int32 i = 0; i < m_arLayers.Count; i++)
            {
                Layer layer = m_arLayers[i];
                layer.m_bmpImage.Lock();
                if (layer.Mask != null)
                    layer.Mask.Lock();
            }

            // calculate colors of flattened image
            // 1. take offsetx, offsety into consideration
            // 2. calculate alpha of color (alpha, opacity, mask)
            // 3. mix colors of current layer and layer below

            for (Int32 y = 0; y < m_nHeight; y++)
            {
                for (Int32 x = 0; x < m_nWidth; x++)
                {
                    Color c0 = m_arLayers[0].m_bmpImage.GetPixel(x, y);
                    for (Int32 i = 1; i < m_arLayers.Count; i++)
                    {
                        Layer layer = m_arLayers[i];
                        Color c1 = Color.Transparent;
                        if (x >= layer.OffsetX &&
                            x <= layer.OffsetX + layer.m_bmpImage.Width - 1 &&
                            y >= layer.OffsetY &&
                            y <= layer.OffsetY + layer.m_bmpImage.Height - 1)
                        {
                            c1 = layer.m_bmpImage.GetPixel(x - layer.OffsetX, y - layer.OffsetY);
                        }
                        if (c1.A == 255 && layer.Opacity == 1.0 &&
                            layer.Mask == null)
                        {
                            c0 = c1;
                        }
                        else
                        {
                            Double tr, tg, tb, a;
                            a = (c1.A / 255.0) * layer.Opacity;
                            if (layer.Mask != null)
                            {
                                a *= layer.Mask.GetIntensity(x, y) / 255.0;
                            }
                            tr = c1.R * a + c0.R * (1.0 - a);
                            tg = c1.G * a + c0.G * (1.0 - a);
                            tb = c1.B * a + c0.B * (1.0 - a);
                            tr = Math.Round(tr);
                            tg = Math.Round(tg);

                            if (i == 4) // shadow layer
                            {
                                tb = Math.Round(tb);
                                tr = Math.Min(tr, crBack.R);
                                tg = Math.Min(tg, crBack.G);
                                tb = Math.Min(tb, crBack.B);
                            }
                            else
                            {
                                tr = Math.Min(tr, 255);
                                tg = Math.Min(tg, 255);
                                tb = Math.Min(tb, 255);
                            }

                            c0 = Color.FromArgb((Byte)tr, (Byte)tg, (Byte)tb);
                        }
                    }
                    bmpFinal.SetPixel(x, y, c0);
                }
            }

            // unlock all bitmaps
            for (Int32 i = 0; i < m_arLayers.Count; i++)
            {
                Layer layer = m_arLayers[i];
                layer.m_bmpImage.Unlock();
                if (layer.Mask != null)
                    layer.Mask.Unlock();
            }

            bmpFinal.Unlock();

            return bmpFinal;
        }
    }
}
