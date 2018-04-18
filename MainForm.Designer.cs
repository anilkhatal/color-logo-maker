namespace ColorLogoMaker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_btnGenerate = new System.Windows.Forms.Button();
            this.m_pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.m_progressBarProcess = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_textBoxSize = new System.Windows.Forms.TextBox();
            this.m_textBoxLogo = new System.Windows.Forms.TextBox();
            this.m_labelColor1 = new System.Windows.Forms.Label();
            this.m_labelColor2 = new System.Windows.Forms.Label();
            this.m_labelColor3 = new System.Windows.Forms.Label();
            this.m_labelColor4 = new System.Windows.Forms.Label();
            this.m_labelColor5 = new System.Windows.Forms.Label();
            this.m_labelColor6 = new System.Windows.Forms.Label();
            this.m_labelColor7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_labelColorBack = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_cmbFont = new ColorLogoMaker.CGFontCombo();
            this.m_colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_textBoxBlur = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_textBoxOpacity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_textBoxOffsetY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_textBoxOffsetX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_textBoxWidth = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_textBoxElevation = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_textBoxAzimuth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.m_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnGenerate
            // 
            this.m_btnGenerate.Location = new System.Drawing.Point(649, 502);
            this.m_btnGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_btnGenerate.Name = "m_btnGenerate";
            this.m_btnGenerate.Size = new System.Drawing.Size(171, 46);
            this.m_btnGenerate.TabIndex = 11;
            this.m_btnGenerate.Text = "Generate";
            this.m_btnGenerate.UseVisualStyleBackColor = true;
            this.m_btnGenerate.Click += new System.EventHandler(this.OnButtonGenerate);
            // 
            // m_pictureBoxPreview
            // 
            this.m_pictureBoxPreview.BackColor = System.Drawing.SystemColors.Control;
            this.m_pictureBoxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_pictureBoxPreview.Location = new System.Drawing.Point(13, 14);
            this.m_pictureBoxPreview.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_pictureBoxPreview.Name = "m_pictureBoxPreview";
            this.m_pictureBoxPreview.Size = new System.Drawing.Size(400, 582);
            this.m_pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_pictureBoxPreview.TabIndex = 1;
            this.m_pictureBoxPreview.TabStop = false;
            this.m_pictureBoxPreview.Click += new System.EventHandler(this.m_pictureBoxPreview_Click);
            // 
            // m_progressBarProcess
            // 
            this.m_progressBarProcess.ForeColor = System.Drawing.Color.Green;
            this.m_progressBarProcess.Location = new System.Drawing.Point(13, 575);
            this.m_progressBarProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_progressBarProcess.Name = "m_progressBarProcess";
            this.m_progressBarProcess.Size = new System.Drawing.Size(400, 28);
            this.m_progressBarProcess.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Size:";
            // 
            // m_textBoxSize
            // 
            this.m_textBoxSize.Location = new System.Drawing.Point(86, 51);
            this.m_textBoxSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_textBoxSize.Name = "m_textBoxSize";
            this.m_textBoxSize.Size = new System.Drawing.Size(135, 26);
            this.m_textBoxSize.TabIndex = 3;
            // 
            // m_textBoxLogo
            // 
            this.m_textBoxLogo.Location = new System.Drawing.Point(100, 21);
            this.m_textBoxLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_textBoxLogo.Name = "m_textBoxLogo";
            this.m_textBoxLogo.Size = new System.Drawing.Size(175, 26);
            this.m_textBoxLogo.TabIndex = 1;
            this.m_textBoxLogo.TextChanged += new System.EventHandler(this.m_textBoxLogo_TextChanged);
            // 
            // m_labelColor1
            // 
            this.m_labelColor1.AutoSize = true;
            this.m_labelColor1.BackColor = System.Drawing.Color.DodgerBlue;
            this.m_labelColor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelColor1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_labelColor1.Location = new System.Drawing.Point(8, 36);
            this.m_labelColor1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_labelColor1.Name = "m_labelColor1";
            this.m_labelColor1.Size = new System.Drawing.Size(39, 22);
            this.m_labelColor1.TabIndex = 12;
            this.m_labelColor1.Text = "       ";
            this.m_labelColor1.Click += new System.EventHandler(this.OnColor1Click);
            // 
            // m_labelColor2
            // 
            this.m_labelColor2.AutoSize = true;
            this.m_labelColor2.BackColor = System.Drawing.Color.Red;
            this.m_labelColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelColor2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_labelColor2.Location = new System.Drawing.Point(55, 36);
            this.m_labelColor2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_labelColor2.Name = "m_labelColor2";
            this.m_labelColor2.Size = new System.Drawing.Size(39, 22);
            this.m_labelColor2.TabIndex = 15;
            this.m_labelColor2.Text = "       ";
            this.m_labelColor2.Click += new System.EventHandler(this.OnColor2Click);
            // 
            // m_labelColor3
            // 
            this.m_labelColor3.AutoSize = true;
            this.m_labelColor3.BackColor = System.Drawing.Color.Gold;
            this.m_labelColor3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelColor3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_labelColor3.Location = new System.Drawing.Point(106, 36);
            this.m_labelColor3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_labelColor3.Name = "m_labelColor3";
            this.m_labelColor3.Size = new System.Drawing.Size(39, 22);
            this.m_labelColor3.TabIndex = 16;
            this.m_labelColor3.Text = "       ";
            this.m_labelColor3.Click += new System.EventHandler(this.OnColor3Click);
            // 
            // m_labelColor4
            // 
            this.m_labelColor4.AutoSize = true;
            this.m_labelColor4.BackColor = System.Drawing.Color.DodgerBlue;
            this.m_labelColor4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelColor4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_labelColor4.Location = new System.Drawing.Point(153, 36);
            this.m_labelColor4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_labelColor4.Name = "m_labelColor4";
            this.m_labelColor4.Size = new System.Drawing.Size(39, 22);
            this.m_labelColor4.TabIndex = 17;
            this.m_labelColor4.Text = "       ";
            this.m_labelColor4.Click += new System.EventHandler(this.OnColor4Click);
            // 
            // m_labelColor5
            // 
            this.m_labelColor5.AutoSize = true;
            this.m_labelColor5.BackColor = System.Drawing.Color.LawnGreen;
            this.m_labelColor5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelColor5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_labelColor5.Location = new System.Drawing.Point(200, 36);
            this.m_labelColor5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_labelColor5.Name = "m_labelColor5";
            this.m_labelColor5.Size = new System.Drawing.Size(39, 22);
            this.m_labelColor5.TabIndex = 18;
            this.m_labelColor5.Text = "       ";
            this.m_labelColor5.Click += new System.EventHandler(this.OnColor5Click);
            // 
            // m_labelColor6
            // 
            this.m_labelColor6.AutoSize = true;
            this.m_labelColor6.BackColor = System.Drawing.Color.Red;
            this.m_labelColor6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelColor6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_labelColor6.Location = new System.Drawing.Point(247, 36);
            this.m_labelColor6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_labelColor6.Name = "m_labelColor6";
            this.m_labelColor6.Size = new System.Drawing.Size(39, 22);
            this.m_labelColor6.TabIndex = 19;
            this.m_labelColor6.Text = "       ";
            this.m_labelColor6.Click += new System.EventHandler(this.OnColor6Click);
            // 
            // m_labelColor7
            // 
            this.m_labelColor7.AutoSize = true;
            this.m_labelColor7.BackColor = System.Drawing.Color.DarkOrchid;
            this.m_labelColor7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelColor7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_labelColor7.Location = new System.Drawing.Point(294, 36);
            this.m_labelColor7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_labelColor7.Name = "m_labelColor7";
            this.m_labelColor7.Size = new System.Drawing.Size(39, 22);
            this.m_labelColor7.TabIndex = 20;
            this.m_labelColor7.Text = "       ";
            this.m_labelColor7.Click += new System.EventHandler(this.OnColor7Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.m_labelColor1);
            this.groupBox1.Controls.Add(this.m_labelColor2);
            this.groupBox1.Controls.Add(this.m_labelColor3);
            this.groupBox1.Controls.Add(this.m_labelColor7);
            this.groupBox1.Controls.Add(this.m_labelColor4);
            this.groupBox1.Controls.Add(this.m_labelColor6);
            this.groupBox1.Controls.Add(this.m_labelColor5);
            this.groupBox1.Location = new System.Drawing.Point(441, 87);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(385, 63);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.m_labelColorBack);
            this.groupBox2.Controls.Add(this.m_textBoxLogo);
            this.groupBox2.Location = new System.Drawing.Point(441, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(385, 63);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logo";
            // 
            // m_labelColorBack
            // 
            this.m_labelColorBack.AutoSize = true;
            this.m_labelColorBack.BackColor = System.Drawing.Color.White;
            this.m_labelColorBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_labelColorBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_labelColorBack.Location = new System.Drawing.Point(300, 25);
            this.m_labelColorBack.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_labelColorBack.Name = "m_labelColorBack";
            this.m_labelColorBack.Size = new System.Drawing.Size(39, 22);
            this.m_labelColorBack.TabIndex = 13;
            this.m_labelColorBack.Text = "       ";
            this.m_labelColorBack.Click += new System.EventHandler(this.OnColorBkClick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.m_cmbFont);
            this.groupBox3.Controls.Add(this.m_textBoxSize);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(441, 160);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(387, 97);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Font";
            // 
            // m_cmbFont
            // 
            this.m_cmbFont.BackColor = System.Drawing.SystemColors.Window;
            this.m_cmbFont.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cmbFont.Location = new System.Drawing.Point(80, 13);
            this.m_cmbFont.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_cmbFont.Name = "m_cmbFont";
            this.m_cmbFont.Size = new System.Drawing.Size(315, 32);
            this.m_cmbFont.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_textBoxBlur);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.m_textBoxOpacity);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.m_textBoxOffsetY);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.m_textBoxOffsetX);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(441, 257);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox4.Size = new System.Drawing.Size(387, 112);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shadow";
            // 
            // m_textBoxBlur
            // 
            this.m_textBoxBlur.Location = new System.Drawing.Point(311, 63);
            this.m_textBoxBlur.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_textBoxBlur.Name = "m_textBoxBlur";
            this.m_textBoxBlur.Size = new System.Drawing.Size(62, 26);
            this.m_textBoxBlur.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Blur (pixels): ";
            // 
            // m_textBoxOpacity
            // 
            this.m_textBoxOpacity.Location = new System.Drawing.Point(311, 22);
            this.m_textBoxOpacity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_textBoxOpacity.Name = "m_textBoxOpacity";
            this.m_textBoxOpacity.Size = new System.Drawing.Size(62, 26);
            this.m_textBoxOpacity.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Opacity (%): ";
            // 
            // m_textBoxOffsetY
            // 
            this.m_textBoxOffsetY.Location = new System.Drawing.Point(150, 66);
            this.m_textBoxOffsetY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_textBoxOffsetY.Name = "m_textBoxOffsetY";
            this.m_textBoxOffsetY.Size = new System.Drawing.Size(62, 26);
            this.m_textBoxOffsetY.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Offset Y (pixels): ";
            // 
            // m_textBoxOffsetX
            // 
            this.m_textBoxOffsetX.Location = new System.Drawing.Point(150, 25);
            this.m_textBoxOffsetX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_textBoxOffsetX.Name = "m_textBoxOffsetX";
            this.m_textBoxOffsetX.Size = new System.Drawing.Size(62, 26);
            this.m_textBoxOffsetX.TabIndex = 4;
            this.m_textBoxOffsetX.TextChanged += new System.EventHandler(this.m_textBoxOffsetX_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Offset X (pixels): ";
            // 
            // m_textBoxWidth
            // 
            this.m_textBoxWidth.Location = new System.Drawing.Point(105, 65);
            this.m_textBoxWidth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_textBoxWidth.Name = "m_textBoxWidth";
            this.m_textBoxWidth.Size = new System.Drawing.Size(62, 26);
            this.m_textBoxWidth.TabIndex = 9;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_textBoxElevation);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.m_textBoxAzimuth);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.m_textBoxWidth);
            this.groupBox5.Location = new System.Drawing.Point(441, 390);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox5.Size = new System.Drawing.Size(387, 112);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Text Bump";
            // 
            // m_textBoxElevation
            // 
            this.m_textBoxElevation.Location = new System.Drawing.Point(279, 25);
            this.m_textBoxElevation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_textBoxElevation.Name = "m_textBoxElevation";
            this.m_textBoxElevation.Size = new System.Drawing.Size(62, 26);
            this.m_textBoxElevation.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 29);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Elevation: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Azimuth: ";
            // 
            // m_textBoxAzimuth
            // 
            this.m_textBoxAzimuth.Location = new System.Drawing.Point(105, 25);
            this.m_textBoxAzimuth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_textBoxAzimuth.Name = "m_textBoxAzimuth";
            this.m_textBoxAzimuth.Size = new System.Drawing.Size(62, 26);
            this.m_textBoxAzimuth.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Width: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 502);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 46);
            this.button1.TabIndex = 13;
            this.button1.Text = "Reset Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnResetSettings);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Location = new System.Drawing.Point(650, 557);
            this.m_btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(171, 46);
            this.m_btnSave.TabIndex = 12;
            this.m_btnSave.Text = "Save";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(70, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(43, 26);
            this.textBox1.TabIndex = 9;
            // 
            // m_saveFileDialog
            // 
            this.m_saveFileDialog.FileName = "logo";
            this.m_saveFileDialog.Filter = "Bitmap files|*.bmp|JPEG files|*.jpg|PNG files|*.png";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 617);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.m_progressBarProcess);
            this.Controls.Add(this.m_pictureBoxPreview);
            this.Controls.Add(this.m_btnGenerate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Color Logo Maker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureBoxPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_btnGenerate;
        private System.Windows.Forms.PictureBox m_pictureBoxPreview;
        private System.Windows.Forms.ProgressBar m_progressBarProcess;
        private CGFontCombo m_cmbFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_textBoxSize;
        private System.Windows.Forms.TextBox m_textBoxLogo;
        private System.Windows.Forms.Label m_labelColor1;
        private System.Windows.Forms.Label m_labelColor2;
        private System.Windows.Forms.Label m_labelColor3;
        private System.Windows.Forms.Label m_labelColor4;
        private System.Windows.Forms.Label m_labelColor5;
        private System.Windows.Forms.Label m_labelColor6;
        private System.Windows.Forms.Label m_labelColor7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label m_labelColorBack;
        private System.Windows.Forms.ColorDialog m_colorDialog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox m_textBoxOffsetY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_textBoxOffsetX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_textBoxBlur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_textBoxOpacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox m_textBoxWidth;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox m_textBoxAzimuth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox m_textBoxElevation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog m_saveFileDialog;
    }
}

