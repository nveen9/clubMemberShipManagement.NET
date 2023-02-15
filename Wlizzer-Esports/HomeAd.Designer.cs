
namespace Wlizzer_Esports
{
    partial class HomeAd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeAd));
            this.pnlHome = new System.Windows.Forms.Panel();
            this.pictureBoxNotification = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogOut = new System.Windows.Forms.PictureBox();
            this.pictureBoxSettings = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHome
            // 
            this.pnlHome.Controls.Add(this.pictureBoxNotification);
            this.pnlHome.Controls.Add(this.pictureBoxLogOut);
            this.pnlHome.Controls.Add(this.pictureBoxSettings);
            this.pnlHome.Location = new System.Drawing.Point(63, 122);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(785, 294);
            this.pnlHome.TabIndex = 2;
            // 
            // pictureBoxNotification
            // 
            this.pictureBoxNotification.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxNotification.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNotification.Image")));
            this.pictureBoxNotification.Location = new System.Drawing.Point(32, 25);
            this.pictureBoxNotification.Name = "pictureBoxNotification";
            this.pictureBoxNotification.Size = new System.Drawing.Size(213, 244);
            this.pictureBoxNotification.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNotification.TabIndex = 59;
            this.pictureBoxNotification.TabStop = false;
            this.pictureBoxNotification.Click += new System.EventHandler(this.pictureBoxNotification_Click);
            // 
            // pictureBoxLogOut
            // 
            this.pictureBoxLogOut.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxLogOut.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogOut.Image")));
            this.pictureBoxLogOut.Location = new System.Drawing.Point(538, 25);
            this.pictureBoxLogOut.Name = "pictureBoxLogOut";
            this.pictureBoxLogOut.Size = new System.Drawing.Size(213, 244);
            this.pictureBoxLogOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogOut.TabIndex = 58;
            this.pictureBoxLogOut.TabStop = false;
            this.pictureBoxLogOut.Click += new System.EventHandler(this.pictureBoxLogOut_Click);
            // 
            // pictureBoxSettings
            // 
            this.pictureBoxSettings.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSettings.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSettings.Image")));
            this.pictureBoxSettings.Location = new System.Drawing.Point(288, 25);
            this.pictureBoxSettings.Name = "pictureBoxSettings";
            this.pictureBoxSettings.Size = new System.Drawing.Size(213, 244);
            this.pictureBoxSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSettings.TabIndex = 53;
            this.pictureBoxSettings.TabStop = false;
            this.pictureBoxSettings.Click += new System.EventHandler(this.pictureBoxSettings_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DimGray;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Gold;
            this.btnExit.Location = new System.Drawing.Point(883, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(37, 36);
            this.btnExit.TabIndex = 50;
            this.btnExit.Text = "✖";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // HomeAd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(932, 534);
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HomeAd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomeAd";
            this.Load += new System.EventHandler(this.HomeAd_Load);
            this.pnlHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.PictureBox pictureBoxLogOut;
        private System.Windows.Forms.PictureBox pictureBoxSettings;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBoxNotification;
    }
}