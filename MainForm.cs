//
// Written by Igor Tolmachev, IT Samples
//        mailto:support@itsamples.com
//
// Copyright (c) 2009.
//
// This code may be used in compiled form in any way you desire. This
// file may be redistributed unmodified by any means PROVIDING it is 
// not sold for profit without the authors written consent, and 
// providing that this notice and the authors name and all copyright 
// notices remains intact. If the source code in this file is used in 
// any  commercial application then a statement along the lines of 
// "Portions copyright (c) Igor Tolmachev, 2009" must be included in 
// the startup banner, "About" box or printed documentation. An email 
// letting me know that you are using it would be nice as well. That's 
// not much to ask considering the amount of work that went into this.
//
// This file is provided "as is" with no expressed or implied warranty.
// The author accepts no liability for any damage/loss of business that
// this product may cause.
//
// Expect bugs!
// 
// Please use and enjoy, and let me know of any bugs/mods/improvements 
// that you have found/implemented and I will fix/incorporate them into 
// this file. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Microsoft.Win32;

namespace ColorLogoMaker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private SystemMenu m_SystemMenu = null;
        private const int m_AboutID = 0x100;

        private void OnButtonGenerate(object sender, EventArgs e)
        {

            String strFontSize = m_textBoxSize.Text.Trim();
            if (strFontSize == null || strFontSize.Length < 1)
            {
                MessageBox.Show("Please select Font Size between 10 and 100", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxSize.Focus();
                return;
            }

            Int32 nSize = Convert.ToInt32(strFontSize);
            if (nSize < 10 || nSize > 100)
            {
                MessageBox.Show("Please select Font Size between 10 and 100", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxSize.Focus();
                return;
            }


            Int32 nSelectedItem = m_cmbFont.SelectedIndex;
            if (nSelectedItem == -1)
            {
                MessageBox.Show("Please select Font Name", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_cmbFont.Focus();
                return;
            }

            String strFontName = m_cmbFont.SelectedFontFamily.Name;
            if (strFontName == null || strFontName.Length < 1)
            {
                MessageBox.Show("Please select Font Name", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_cmbFont.Focus();
                return;
            }

            Int32 nOffsetX = 4;
            String strOffsetX = m_textBoxOffsetX.Text.Trim();
            if (strOffsetX == null || strOffsetX.Length < 1)
            {
                MessageBox.Show("Please select Shadow OffsetX between -10 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxOffsetX.Focus();
                return;
            }
            else
            {
                nOffsetX = Convert.ToInt32(strOffsetX);
                if (nOffsetX < -10 || nOffsetX > 10)
                {
                    MessageBox.Show("Please select Shadow OffsetX between -10 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxOffsetX.Focus();
                    return;
                }
            }
            
            Int32 nOffsetY = 4;
            String strOffsetY = m_textBoxOffsetY.Text.Trim();
            if (strOffsetY == null || strOffsetY.Length < 1)
            {
                MessageBox.Show("Please select Shadow OffsetX between -10 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxOffsetY.Focus();
                return;
            }
            else
            {
                nOffsetY = Convert.ToInt32(strOffsetY);
                if (nOffsetY < -10 || nOffsetY > 10)
                {
                    MessageBox.Show("Please select Shadow OffsetY between -10 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxOffsetY.Focus();
                    return;
                }
            }

            Int32 nOpacity = 50;
            String strOpacity = m_textBoxOpacity.Text.Trim();
            if (strOpacity == null || strOpacity.Length < 1)
            {
                MessageBox.Show("Please select Shadow Opacity between 0 and 100%", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxOpacity.Focus();
                return;
            }
            else
            {
                nOpacity = Convert.ToInt32(strOpacity);
                if (nOpacity < 0 || nOpacity > 100)
                {
                    MessageBox.Show("Please select Shadow Opacity between 0 and 100%", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxOpacity.Focus();
                    return;
                }
            }
            if (nOpacity > 99)
                nOpacity = 99;

            Int32 nBlur = 4;
            String strBlur = m_textBoxBlur.Text.Trim();
            if (strBlur == null || strBlur.Length < 1)
            {
                MessageBox.Show("Please select Shadow Blur between 0 and 50", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxBlur.Focus();
                return;
            }
            else
            {
                nBlur = Convert.ToInt32(strBlur);
                if (nBlur < 0 || nBlur > 50)
                {
                    MessageBox.Show("Please select Shadow Blur between 0 and 50", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxBlur.Focus();
                    return;
                }
            }

            Int32 nAzimuth = 135;
            String strAzimuth = m_textBoxAzimuth.Text.Trim();
            if (strAzimuth == null || strAzimuth.Length < 1)
            {
                MessageBox.Show("Please select Text Bump Azimuth between 0 and 360 degreeses", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxAzimuth.Focus();
                return;
            }
            else
            {
                nAzimuth = Convert.ToInt32(strAzimuth);
                if (nAzimuth < 0 || nAzimuth > 360)
                {
                    MessageBox.Show("Please select Text Bump Azimuth between 0 and 360 degreeses", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxAzimuth.Focus();
                    return;
                }
            }

            Int32 nElevation = 45;
            String strElevation = m_textBoxElevation.Text.Trim();
            if (strElevation == null || strElevation.Length < 1)
            {
                MessageBox.Show("Please select Text Bump Elevation between 0 and 100", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxElevation.Focus();
                return;
            }
            else
            {
                nElevation = Convert.ToInt32(strElevation);
                if (nElevation < 0 || nElevation > 100)
                {
                    MessageBox.Show("Please select Text Bump Elevation between 0 and 100", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxElevation.Focus();
                    return;
                }
            }

            Int32 nWidth = 3;
            String strWidth = m_textBoxWidth.Text.Trim();
            if (strWidth == null || strWidth.Length < 1)
            {
                MessageBox.Show("Please select Text Bump Bevel Width between 1 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxWidth.Focus();
                return;
            }
            else
            {
                nWidth = Convert.ToInt32(strWidth);
                if (nWidth < 1 || nWidth > 100)
                {
                    MessageBox.Show("Please select Text Bump Bevel Width between 1 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxWidth.Focus();
                    return;
                }
            }

            m_progressBarProcess.Maximum = 10;
            m_progressBarProcess.Minimum = 0;
            m_progressBarProcess.Step = 1;
            m_progressBarProcess.Value = 0;

            Font oFont;
            try
            {
                oFont = new Font(strFontName, nSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            String strLogo = m_textBoxLogo.Text.Trim();
            if (strLogo == null || strLogo.Length < 1)
            {
                MessageBox.Show("Please select Logo Text", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxLogo.Focus();
                return;
            }

            Color[] colors = new Color[7];
            colors[0] = m_labelColor1.BackColor;
            colors[1] = m_labelColor2.BackColor;
            colors[2] = m_labelColor3.BackColor;
            colors[3] = m_labelColor4.BackColor;
            colors[4] = m_labelColor5.BackColor;
            colors[5] = m_labelColor6.BackColor;
            colors[6] = m_labelColor7.BackColor;
            

            // measure string

            Bitmap bmpTest = new Bitmap(10, 10, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmpTest);

            float nUnderscoreWidth = g.MeasureString(" __ ", oFont).Width;

            float nTotalWidth = 0;
            float nMaxHeight = 0;
            float[] nCharWidths = new float[strLogo.Length];
            float[] nCharOffsets = new float[strLogo.Length];
            for (int i = 0; i < strLogo.Length; i++)
            {
                SizeF fsCharWidth = g.MeasureString(String.Concat(" _", strLogo[i].ToString(), "_ "), oFont);
                float nCharWidth = fsCharWidth.Width - nUnderscoreWidth;

                if (nMaxHeight < fsCharWidth.Height)
                    nMaxHeight = fsCharWidth.Height;

                nCharWidths[i] = nCharWidth;
                nTotalWidth += nCharWidth;
            }
            
            IntPtr hdc = g.GetHdc();

            IntPtr oldFont = Gdi.SelectObject(hdc, oFont.ToHfont());

            Gdi.SelectObject(hdc, oldFont);

            g.ReleaseHdc(hdc);

            g.Dispose();
            bmpTest.Dispose();

            System.Threading.Thread.Sleep(1);
            m_progressBarProcess.PerformStep();

            LayeredImage image = new LayeredImage((int)nTotalWidth + 2* Math.Abs(nOffsetX), (int)nMaxHeight + Math.Abs(nOffsetY));
            m_progressBarProcess.PerformStep(); 

            Layer layerText = image.Layers.Add();
            layerText.Clear(Color.Black);

            float nCharOffset = (float)Math.Abs(nOffsetX);

            for (int i = 0; i < strLogo.Length; i++)
            {
                layerText.DrawText((int)nCharOffset, 0, strLogo[i].ToString(), oFont, new SolidBrush(Color.White));
                nCharOffset += nCharWidths[i];
            }
            
            m_progressBarProcess.PerformStep();

            Layer layerBlurText = image.Layers.Copy(layerText);
            layerBlurText.Blur(nBlur, nBlur);
            m_progressBarProcess.PerformStep(); 

            Layer layerShadowBackground = image.Layers.Add();
            layerShadowBackground.Clear(m_labelColorBack.BackColor);

            m_progressBarProcess.PerformStep();

            Layer layerShadow = image.Layers.Copy(layerBlurText);
            layerShadow.Invert();
            layerShadow.Opacity = (double)nOpacity / 100.0;
            layerShadow.OffsetX += nOffsetX;
            layerShadow.OffsetY += nOffsetY;

            nCharOffset = (float)Math.Abs(nOffsetX);
            Int32 nColorIndex = 0;
            
            m_progressBarProcess.PerformStep();

            Layer layerFinal = image.Layers.Add();
            
            m_progressBarProcess.PerformStep();

            for (Int32 i = 0; i < strLogo.Length; i++)
            {
                Color color = colors[nColorIndex];
                nColorIndex++;
                if (nColorIndex >= colors.Length)
                    nColorIndex = 0;

                SolidBrush brush = new SolidBrush(color);
                layerFinal.FillRectangle((int)nCharOffset, 0, (int)nCharWidths[i], (int)nMaxHeight, brush);
                nCharOffset += nCharWidths[i];
            }

            m_progressBarProcess.PerformStep();

            layerFinal.BumpMap(layerBlurText, nAzimuth, nElevation, nWidth, false);
            m_progressBarProcess.PerformStep();

            layerFinal.Mask = (FastBitmap)layerText.Bitmap.Clone();
            m_progressBarProcess.PerformStep();

            FastBitmap result = image.Flatten(m_labelColorBack.BackColor);
            m_pictureBoxPreview.Image = result.GetBitmap();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            Rectangle rcScreen = SystemInformation.WorkingArea;

            // center screen
            Int32 nNormalLeft = (rcScreen.Width - this.Size.Width) / 2;
            Int32 nNormalTop = (rcScreen.Height - this.Size.Height) / 2;
            Int32 nTextSize = 68;
            String strFontFace = "Book Antiqua";
            String strTextLogo = "CSI";
            Int32 nOffsetX = 4;
            Int32 nOffsetY = 4;
            Int32 nOpacity = 50;
            Int32 nBlur = 4;
            Int32 nAzimuth = 135;
            Int32 nElevation = 45;
            Int32 nWidth = 3;

            Color crBack = Color.White;
            Color crChar1 = Color.DodgerBlue;
            Color crChar2 = Color.Red;
            Color crChar3 = Color.Gold;
            Color crChar4 = Color.DodgerBlue;
            Color crChar5 = Color.LawnGreen;
            Color crChar6 = Color.Red;
            Color crChar7 = Color.DarkOrchid;
            Color crChar8 = Color.LimeGreen;

            // attempt to read options from the registry
            RegistryKey hKey = Registry.CurrentUser.OpenSubKey(@"Software\ITSoftware\ColorLogoMaker");
            if (hKey != null)
            {
                nNormalLeft = (int)hKey.GetValue("Left", this.Left);
                nNormalTop = (int)hKey.GetValue("Top", this.Top);
                nTextSize = (int)hKey.GetValue("TextSize", 68);
                strTextLogo = (String)hKey.GetValue("TextLogo", "CSI");
                strFontFace = (String)hKey.GetValue("FontFace", "Book Antiqua");
                nOffsetX = (int)hKey.GetValue("ShadowOffsetX", 4);
                nOffsetY = (int)hKey.GetValue("ShadowOffsetY", 4);
                nOpacity = (int)hKey.GetValue("ShadowOpacity", 50);
                nBlur = (int)hKey.GetValue("ShadowBlur", 4);
                nAzimuth = (int)hKey.GetValue("BumpAzimuth", 135);
                nElevation = (int)hKey.GetValue("BumpElevation", 45);
                nWidth = (int)hKey.GetValue("BumpWidth", 3);
                crBack = Color.FromArgb((int)hKey.GetValue("BackColor", Color.White.ToArgb()));
                crChar1 = Color.FromArgb((int)hKey.GetValue("Char1Color", Color.DodgerBlue.ToArgb()));
                crChar2 = Color.FromArgb((int)hKey.GetValue("Char2Color", Color.Red.ToArgb()));
                crChar3 = Color.FromArgb((int)hKey.GetValue("Char3Color", Color.Gold.ToArgb()));
                crChar4 = Color.FromArgb((int)hKey.GetValue("Char4Color", Color.DodgerBlue.ToArgb()));
                crChar5 = Color.FromArgb((int)hKey.GetValue("Char5Color", Color.LawnGreen.ToArgb()));
                crChar6 = Color.FromArgb((int)hKey.GetValue("Char6Color", Color.Red.ToArgb()));
                crChar7 = Color.FromArgb((int)hKey.GetValue("Char7Color", Color.DarkOrchid.ToArgb()));

                hKey.Close();
            }

            this.Location = new Point(nNormalLeft, nNormalTop);

            int nIndex = m_cmbFont.FindString(strFontFace);
            if (nIndex != -1)
                m_cmbFont.SelectedIndex = nIndex;

            m_textBoxSize.Text = nTextSize.ToString();
            m_textBoxLogo.Text = strTextLogo;
            m_textBoxOffsetX.Text = nOffsetX.ToString();
            m_textBoxOffsetY.Text = nOffsetY.ToString();
            m_textBoxOpacity.Text = nOpacity.ToString();
            m_textBoxBlur.Text = nBlur.ToString();
            m_textBoxAzimuth.Text = nAzimuth.ToString();
            m_textBoxElevation.Text = nElevation.ToString();
            m_textBoxWidth.Text = nWidth.ToString();
            m_labelColorBack.BackColor = crBack;
            m_labelColor1.BackColor = crChar1;
            m_labelColor2.BackColor = crChar2;
            m_labelColor3.BackColor = crChar3;
            m_labelColor4.BackColor = crChar4;
            m_labelColor5.BackColor = crChar5;
            m_labelColor6.BackColor = crChar6;
            m_labelColor7.BackColor = crChar7;
            
            
            try
            {
                m_SystemMenu = SystemMenu.FromForm(this);
                m_SystemMenu.AppendSeparator();
                m_SystemMenu.AppendMenu(m_AboutID, "About Color Logo Maker...");
            }
            catch (NoSystemMenuException /* err */ )
            {
                // Do some error handling
            }
        }

        protected override void WndProc (ref Message msg)
        {
            if (msg.Msg == (int)WindowMessages.wmSysCommand)
            {
                switch (msg.WParam.ToInt32())
                {
                    case m_AboutID:
                    {
                        AboutForm af = new AboutForm();
                        af.ShowDialog();
                    }
                    break;
                }
            }

            // Call base class function
            base.WndProc(ref msg);
        }

        private void OnClosing(object sender, FormClosingEventArgs e)
        {

            Int32 nNormalLeft = this.Location.X;
            Int32 nNormalTop = this.Location.Y;

            String strTextSize = m_textBoxSize.Text.Trim();
            if (strTextSize == null || strTextSize.Length < 1)
                strTextSize = "68";
            Int32 nTextSize = Convert.ToInt32(strTextSize);

            String strTextLogo = m_textBoxLogo.Text;
            if (strTextLogo == null || strTextLogo.Length < 1)
                strTextLogo = "CSI";

            String strFontFace = m_cmbFont.SelectedFontFamily.Name;
            if (strFontFace == null || strFontFace.Length < 1)
                strFontFace = "Book Antiqua";

            String strOffsetX = m_textBoxOffsetX.Text.Trim();
            if (strOffsetX == null || strOffsetX.Length < 1)
                strOffsetX = "4";
            Int32 nOffsetX = Convert.ToInt32(strOffsetX);

            String strOffsetY = m_textBoxOffsetY.Text.Trim();
            if (strOffsetY == null || strOffsetY.Length < 1)
                strOffsetY = "4";
            Int32 nOffsetY = Convert.ToInt32(strOffsetY);

            String strOpacity = m_textBoxOpacity.Text.Trim();
            if (strOpacity == null || strOpacity.Length < 1)
                strOpacity = "50";
            Int32 nOpacity = Convert.ToInt32(strOpacity);

            String strBlur = m_textBoxBlur.Text.Trim();
            if (strBlur == null || strBlur.Length < 1)
                strBlur = "4";
            Int32 nBlur = Convert.ToInt32(strBlur);

            String strAzimuth = m_textBoxAzimuth.Text.Trim();
            if (strAzimuth == null || strAzimuth.Length < 1)
                strAzimuth = "135";
            Int32 nAzimuth = Convert.ToInt32(strAzimuth);

            String strElevation = m_textBoxElevation.Text.Trim();
            if (strElevation == null || strElevation.Length < 1)
                strElevation = "45";
            Int32 nElevation = Convert.ToInt32(strElevation);

            String strWidth = m_textBoxWidth.Text.Trim();
            if (strWidth == null || strWidth.Length < 1)
                strWidth = "3";
            Int32 nWidth = Convert.ToInt32(strWidth);

            Color crBack = m_labelColorBack.BackColor;
            Color crChar1 = m_labelColor1.BackColor;
            Color crChar2 = m_labelColor2.BackColor;
            Color crChar3 = m_labelColor3.BackColor;
            Color crChar4 = m_labelColor4.BackColor;
            Color crChar5 = m_labelColor5.BackColor;
            Color crChar6 = m_labelColor6.BackColor;
            Color crChar7 = m_labelColor7.BackColor;

            // save options here
            RegistryKey hKey = Registry.CurrentUser.CreateSubKey(@"Software\ITSoftware\ColorLogoMaker");
            if (hKey != null)
            {
                hKey.SetValue("Left", nNormalLeft);
                hKey.SetValue("Top", nNormalTop);
                hKey.SetValue("TextSize", nTextSize);
                hKey.SetValue("TextLogo", strTextLogo);
                hKey.SetValue("FontFace", strFontFace);
                hKey.SetValue("ShadowOffsetX", nOffsetX);
                hKey.SetValue("ShadowOffsetY", nOffsetY);
                hKey.SetValue("ShadowOpacity", nOpacity);
                hKey.SetValue("ShadowBlur", nBlur);
                hKey.SetValue("BumpAzimuth", nAzimuth);
                hKey.SetValue("BumpElevation", nElevation);
                hKey.SetValue("BumpWidth", nWidth);
                hKey.SetValue("BackColor", crBack.ToArgb());
                hKey.SetValue("Char1Color", crChar1.ToArgb());
                hKey.SetValue("Char2Color", crChar2.ToArgb());
                hKey.SetValue("Char3Color", crChar3.ToArgb());
                hKey.SetValue("Char4Color", crChar4.ToArgb());
                hKey.SetValue("Char5Color", crChar5.ToArgb());
                hKey.SetValue("Char6Color", crChar6.ToArgb());
                hKey.SetValue("Char7Color", crChar7.ToArgb());
                
                hKey.Close();
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (m_pictureBoxPreview.Image == null)
            {
                MessageBox.Show("The Logo image is not created", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (m_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                String strFile = m_saveFileDialog.FileName;
                if (m_saveFileDialog.FilterIndex == 1)
                    m_pictureBoxPreview.Image.Save(strFile, ImageFormat.Bmp);
                else if (m_saveFileDialog.FilterIndex == 2)
                    m_pictureBoxPreview.Image.Save(strFile, ImageFormat.Jpeg);
                else if (m_saveFileDialog.FilterIndex == 3)
                    m_pictureBoxPreview.Image.Save(strFile, ImageFormat.Png);
            }
        }

        private void OnColor1Click(object sender, EventArgs e)
        {
            m_colorDialog.FullOpen = true;
            m_colorDialog.Color = m_labelColor1.BackColor;
            if (m_colorDialog.ShowDialog() == DialogResult.OK)
                m_labelColor1.BackColor = m_colorDialog.Color;
        }

        private void OnColor2Click(object sender, EventArgs e)
        {
            m_colorDialog.FullOpen = true;
            m_colorDialog.Color = m_labelColor2.BackColor;
            if (m_colorDialog.ShowDialog() == DialogResult.OK)
                m_labelColor2.BackColor = m_colorDialog.Color;
        }

        private void OnColor3Click(object sender, EventArgs e)
        {
            m_colorDialog.FullOpen = true;
            m_colorDialog.Color = m_labelColor3.BackColor;
            if (m_colorDialog.ShowDialog() == DialogResult.OK)
                m_labelColor3.BackColor = m_colorDialog.Color;
        }

        private void OnColor4Click(object sender, EventArgs e)
        {
            m_colorDialog.FullOpen = true;
            m_colorDialog.Color = m_labelColor4.BackColor;
            if (m_colorDialog.ShowDialog() == DialogResult.OK)
                m_labelColor4.BackColor = m_colorDialog.Color;
        }

        private void OnColor5Click(object sender, EventArgs e)
        {
            m_colorDialog.FullOpen = true;
            m_colorDialog.Color = m_labelColor5.BackColor;
            if (m_colorDialog.ShowDialog() == DialogResult.OK)
                m_labelColor5.BackColor = m_colorDialog.Color;
        }

        private void OnColor6Click(object sender, EventArgs e)
        {
            m_colorDialog.FullOpen = true;
            m_colorDialog.Color = m_labelColor6.BackColor;
            if (m_colorDialog.ShowDialog() == DialogResult.OK)
                m_labelColor6.BackColor = m_colorDialog.Color;
        }

        private void OnColor7Click(object sender, EventArgs e)
        {
            m_colorDialog.FullOpen = true;
            m_colorDialog.Color = m_labelColor7.BackColor;
            if (m_colorDialog.ShowDialog() == DialogResult.OK)
                m_labelColor7.BackColor = m_colorDialog.Color;
        }

        private void OnColorBkClick(object sender, EventArgs e)
        {
            m_colorDialog.FullOpen = true;
            m_colorDialog.Color = m_labelColorBack.BackColor;
            if(m_colorDialog.ShowDialog() == DialogResult.OK)
                m_labelColorBack.BackColor = m_colorDialog.Color;
        }

        private void OnResetSettings(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reset all settings?", "Color Logo Maker", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int nIndex = m_cmbFont.FindString("Catull");
                if (nIndex == -1)
                    nIndex = m_cmbFont.FindString("calibri");
                if (nIndex != -1)
                    m_cmbFont.SelectedIndex = nIndex;

                m_textBoxSize.Text = "68";
                m_textBoxLogo.Text = "CSI";
                m_textBoxOffsetX.Text = "4";
                m_textBoxOffsetY.Text = "4";
                m_textBoxOpacity.Text = "50";
                m_textBoxBlur.Text = "4";
                m_textBoxAzimuth.Text = "135";
                m_textBoxElevation.Text = "45";
                m_textBoxWidth.Text = "3";

                m_labelColorBack.BackColor = Color.Gold;
                m_labelColor1.BackColor = Color.DodgerBlue;
                m_labelColor2.BackColor = Color.Red;
                m_labelColor3.BackColor = Color.LimeGreen;
                m_labelColor4.BackColor = Color.DodgerBlue;
                m_labelColor5.BackColor = Color.LawnGreen;
                m_labelColor6.BackColor = Color.Red;
                m_labelColor7.BackColor = Color.DarkOrchid;
                      
                    }

        }

        private void m_textBoxLogo_TextChanged(object sender, EventArgs e)
        {

            String strFontSize = m_textBoxSize.Text.Trim();
            if (strFontSize == null || strFontSize.Length < 1)
            {
                MessageBox.Show("Please select Font Size between 10 and 100", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxSize.Focus();
                return;
            }

            Int32 nSize = Convert.ToInt32(strFontSize);
            if (nSize < 10 || nSize > 100)
            {
                MessageBox.Show("Please select Font Size between 10 and 100", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxSize.Focus();
                return;
            }


            Int32 nSelectedItem = m_cmbFont.SelectedIndex;
            if (nSelectedItem == -1)
            {
                MessageBox.Show("Please select Font Name", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_cmbFont.Focus();
                return;
            }

            String strFontName = m_cmbFont.SelectedFontFamily.Name;
            if (strFontName == null || strFontName.Length < 1)
            {
                MessageBox.Show("Please select Font Name", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_cmbFont.Focus();
                return;
            }

            Int32 nOffsetX = 4;
            String strOffsetX = m_textBoxOffsetX.Text.Trim();
            if (strOffsetX == null || strOffsetX.Length < 1)
            {
                MessageBox.Show("Please select Shadow OffsetX between -10 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxOffsetX.Focus();
                return;
            }
            else
            {
                nOffsetX = Convert.ToInt32(strOffsetX);
                if (nOffsetX < -10 || nOffsetX > 10)
                {
                    MessageBox.Show("Please select Shadow OffsetX between -10 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxOffsetX.Focus();
                    return;
                }
            }

            Int32 nOffsetY = 4;
            String strOffsetY = m_textBoxOffsetY.Text.Trim();
            if (strOffsetY == null || strOffsetY.Length < 1)
            {
                MessageBox.Show("Please select Shadow OffsetX between -10 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxOffsetY.Focus();
                return;
            }
            else
            {
                nOffsetY = Convert.ToInt32(strOffsetY);
                if (nOffsetY < -10 || nOffsetY > 10)
                {
                    MessageBox.Show("Please select Shadow OffsetY between -10 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxOffsetY.Focus();
                    return;
                }
            }

            Int32 nOpacity = 50;
            String strOpacity = m_textBoxOpacity.Text.Trim();
            if (strOpacity == null || strOpacity.Length < 1)
            {
                MessageBox.Show("Please select Shadow Opacity between 0 and 100%", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxOpacity.Focus();
                return;
            }
            else
            {
                nOpacity = Convert.ToInt32(strOpacity);
                if (nOpacity < 0 || nOpacity > 100)
                {
                    MessageBox.Show("Please select Shadow Opacity between 0 and 100%", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxOpacity.Focus();
                    return;
                }
            }
            if (nOpacity > 99)
                nOpacity = 99;

            Int32 nBlur = 4;
            String strBlur = m_textBoxBlur.Text.Trim();
            if (strBlur == null || strBlur.Length < 1)
            {
                MessageBox.Show("Please select Shadow Blur between 0 and 50", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxBlur.Focus();
                return;
            }
            else
            {
                nBlur = Convert.ToInt32(strBlur);
                if (nBlur < 0 || nBlur > 50)
                {
                    MessageBox.Show("Please select Shadow Blur between 0 and 50", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxBlur.Focus();
                    return;
                }
            }

            Int32 nAzimuth = 135;
            String strAzimuth = m_textBoxAzimuth.Text.Trim();
            if (strAzimuth == null || strAzimuth.Length < 1)
            {
                MessageBox.Show("Please select Text Bump Azimuth between 0 and 360 degreeses", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxAzimuth.Focus();
                return;
            }
            else
            {
                nAzimuth = Convert.ToInt32(strAzimuth);
                if (nAzimuth < 0 || nAzimuth > 360)
                {
                    MessageBox.Show("Please select Text Bump Azimuth between 0 and 360 degreeses", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxAzimuth.Focus();
                    return;
                }
            }

            Int32 nElevation = 45;
            String strElevation = m_textBoxElevation.Text.Trim();
            if (strElevation == null || strElevation.Length < 1)
            {
                MessageBox.Show("Please select Text Bump Elevation between 0 and 100", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxElevation.Focus();
                return;
            }
            else
            {
                nElevation = Convert.ToInt32(strElevation);
                if (nElevation < 0 || nElevation > 100)
                {
                    MessageBox.Show("Please select Text Bump Elevation between 0 and 100", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxElevation.Focus();
                    return;
                }
            }

            Int32 nWidth = 3;
            String strWidth = m_textBoxWidth.Text.Trim();
            if (strWidth == null || strWidth.Length < 1)
            {
                MessageBox.Show("Please select Text Bump Bevel Width between 1 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxWidth.Focus();
                return;
            }
            else
            {
                nWidth = Convert.ToInt32(strWidth);
                if (nWidth < 1 || nWidth > 100)
                {
                    MessageBox.Show("Please select Text Bump Bevel Width between 1 and 10", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_textBoxWidth.Focus();
                    return;
                }
            }

            m_progressBarProcess.Maximum = 10;
            m_progressBarProcess.Minimum = 0;
            m_progressBarProcess.Step = 1;
            m_progressBarProcess.Value = 0;

            Font oFont;
            try
            {
                oFont = new Font(strFontName, nSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


            String strLogo = m_textBoxLogo.Text.Trim();
            if (strLogo == null || strLogo.Length < 1)
            {
                MessageBox.Show("Please select Logo Text", "Color Logo Maker", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_textBoxLogo.Focus();
                return;
            }

            Color[] colors = new Color[7];
            colors[0] = m_labelColor1.BackColor;
            colors[1] = m_labelColor2.BackColor;
            colors[2] = m_labelColor3.BackColor;
            colors[3] = m_labelColor4.BackColor;
            colors[4] = m_labelColor5.BackColor;
            colors[5] = m_labelColor6.BackColor;
            colors[6] = m_labelColor7.BackColor;
           

            // measure string

            Bitmap bmpTest = new Bitmap(10, 10, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmpTest);

            float nUnderscoreWidth = g.MeasureString(" __ ", oFont).Width;

            float nTotalWidth = 0;
            float nMaxHeight = 0;
            float[] nCharWidths = new float[strLogo.Length];
            float[] nCharOffsets = new float[strLogo.Length];
            for (int i = 0; i < strLogo.Length; i++)
            {
                SizeF fsCharWidth = g.MeasureString(String.Concat(" _", strLogo[i].ToString(), "_ "), oFont);
                float nCharWidth = fsCharWidth.Width - nUnderscoreWidth;

                if (nMaxHeight < fsCharWidth.Height)
                    nMaxHeight = fsCharWidth.Height;

                nCharWidths[i] = nCharWidth;
                nTotalWidth += nCharWidth;
            }

            IntPtr hdc = g.GetHdc();

            IntPtr oldFont = Gdi.SelectObject(hdc, oFont.ToHfont());

            Gdi.SelectObject(hdc, oldFont);

            g.ReleaseHdc(hdc);

            g.Dispose();
            bmpTest.Dispose();

            System.Threading.Thread.Sleep(1);
            m_progressBarProcess.PerformStep();

            LayeredImage image = new LayeredImage((int)nTotalWidth + 2 * Math.Abs(nOffsetX), (int)nMaxHeight + Math.Abs(nOffsetY));
            m_progressBarProcess.PerformStep();

            Layer layerText = image.Layers.Add();
            layerText.Clear(Color.Black);

            float nCharOffset = (float)Math.Abs(nOffsetX);

            for (int i = 0; i < strLogo.Length; i++)
            {
                layerText.DrawText((int)nCharOffset, 0, strLogo[i].ToString(), oFont, new SolidBrush(Color.White));
                nCharOffset += nCharWidths[i];
            }

            m_progressBarProcess.PerformStep();

            Layer layerBlurText = image.Layers.Copy(layerText);
            layerBlurText.Blur(nBlur, nBlur);
            m_progressBarProcess.PerformStep();

            Layer layerShadowBackground = image.Layers.Add();
            layerShadowBackground.Clear(m_labelColorBack.BackColor);

            m_progressBarProcess.PerformStep();

            Layer layerShadow = image.Layers.Copy(layerBlurText);
            layerShadow.Invert();
            layerShadow.Opacity = (double)nOpacity / 100.0;
            layerShadow.OffsetX += nOffsetX;
            layerShadow.OffsetY += nOffsetY;

            nCharOffset = (float)Math.Abs(nOffsetX);
            Int32 nColorIndex = 0;

            m_progressBarProcess.PerformStep();

            Layer layerFinal = image.Layers.Add();

            m_progressBarProcess.PerformStep();

            for (Int32 i = 0; i < strLogo.Length; i++)
            {
                Color color = colors[nColorIndex];
                nColorIndex++;
                if (nColorIndex >= colors.Length)
                    nColorIndex = 0;

                SolidBrush brush = new SolidBrush(color);
                layerFinal.FillRectangle((int)nCharOffset, 0, (int)nCharWidths[i], (int)nMaxHeight, brush);
                nCharOffset += nCharWidths[i];
            }

            m_progressBarProcess.PerformStep();

            layerFinal.BumpMap(layerBlurText, nAzimuth, nElevation, nWidth, false);
            m_progressBarProcess.PerformStep();

            layerFinal.Mask = (FastBitmap)layerText.Bitmap.Clone();
            m_progressBarProcess.PerformStep();

            FastBitmap result = image.Flatten(m_labelColorBack.BackColor);
            m_pictureBoxPreview.Image = result.GetBitmap();
        }

        private void m_pictureBoxPreview_Click(object sender, EventArgs e)
        {

        }

        private void m_textBoxOffsetX_TextChanged(object sender, EventArgs e)
        {

        }
    }
}