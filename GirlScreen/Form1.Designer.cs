namespace GirlScreen
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemChangePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLockScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::GirlScreen.Properties.Resources.tumblr_nxe3lt4ywj1ukq93to1_1280;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 262);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFullScreen,
            this.menuItemChangePicture,
            this.menuItemSetPassword,
            this.menuItemLockScreen,
            this.menuItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(177, 114);
            // 
            // menuItemFullScreen
            // 
            this.menuItemFullScreen.Name = "menuItemFullScreen";
            this.menuItemFullScreen.Size = new System.Drawing.Size(176, 22);
            this.menuItemFullScreen.Text = "全螢幕 (Alt+Enter)";
            this.menuItemFullScreen.Click += new System.EventHandler(this.menuItemFullScreen_Click);
            // 
            // menuItemChangePicture
            // 
            this.menuItemChangePicture.Name = "menuItemChangePicture";
            this.menuItemChangePicture.Size = new System.Drawing.Size(176, 22);
            this.menuItemChangePicture.Text = "更換圖片";
            this.menuItemChangePicture.Click += new System.EventHandler(this.menuItemChangePicture_Click);
            // 
            // menuItemSetPassword
            // 
            this.menuItemSetPassword.Name = "menuItemSetPassword";
            this.menuItemSetPassword.Size = new System.Drawing.Size(176, 22);
            this.menuItemSetPassword.Text = "設定密碼";
            this.menuItemSetPassword.Click += new System.EventHandler(this.menuItemSetPassword_Click);
            // 
            // menuItemLockScreen
            // 
            this.menuItemLockScreen.Name = "menuItemLockScreen";
            this.menuItemLockScreen.Size = new System.Drawing.Size(176, 22);
            this.menuItemLockScreen.Text = "鎖定電腦";
            this.menuItemLockScreen.Click += new System.EventHandler(this.menuItemLockScreen_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(176, 22);
            this.menuItemExit.Text = "結束";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "圖片檔案|*.png;*.jpg;*.gif;*.bmp;*.jpeg";
            this.openFileDialog1.Title = "選擇圖片";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(0, 12);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '●';
            this.textBoxPassword.Size = new System.Drawing.Size(284, 22);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.Visible = false;
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(-2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(51, 12);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Password:";
            this.labelStatus.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "GirlScreen";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemFullScreen;
        private System.Windows.Forms.ToolStripMenuItem menuItemChangePicture;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuItemLockScreen;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetPassword;
    }
}

