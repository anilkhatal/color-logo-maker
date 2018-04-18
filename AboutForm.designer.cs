namespace ColorLogoMaker
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelHome = new System.Windows.Forms.LinkLabel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(154, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Copyright © 2009-2012  Igor Tolmachev";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(154, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Makes it easy to create a beatiful logo";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(154, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Color Logo Maker v 1.0.2";
            // 
            // linkLabelHome
            // 
            this.linkLabelHome.ActiveLinkColor = System.Drawing.Color.DarkSlateBlue;
            this.linkLabelHome.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.linkLabelHome.Location = new System.Drawing.Point(154, 104);
            this.linkLabelHome.Name = "linkLabelHome";
            this.linkLabelHome.Size = new System.Drawing.Size(163, 16);
            this.linkLabelHome.TabIndex = 1;
            this.linkLabelHome.TabStop = true;
            this.linkLabelHome.Text = "http://www.itsamples.com";
            this.linkLabelHome.Click += new System.EventHandler(this.OnHome);
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::ColorLogoMaker.Properties.Resources.ColorLogoMaker;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(128, 128);
            this.pictureBox.TabIndex = 21;
            this.pictureBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(154, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(220, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "for any Web Site with a few clicks";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(3, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(369, 2);
            this.label6.TabIndex = 7;
            // 
            // m_buttonOK
            // 
            this.m_buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonOK.Location = new System.Drawing.Point(281, 161);
            this.m_buttonOK.Name = "m_buttonOK";
            this.m_buttonOK.Size = new System.Drawing.Size(86, 27);
            this.m_buttonOK.TabIndex = 22;
            this.m_buttonOK.Text = "OK";
            this.m_buttonOK.UseVisualStyleBackColor = true;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 196);
            this.ControlBox = false;
            this.Controls.Add(this.m_buttonOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabelHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AboutForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Color Logo Maker";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelHome;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button m_buttonOK;
    }
}