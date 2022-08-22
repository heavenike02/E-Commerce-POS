namespace E_Commerce_POS
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ExitPictureBox = new System.Windows.Forms.PictureBox();
            this.PasswordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.ConfirmPassword = new MetroFramework.Controls.MetroTextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.NewPasswordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(66)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.TitleLabel);
            this.panel1.Controls.Add(this.ExitPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 58);
            this.panel1.TabIndex = 17;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.TitleLabel.Location = new System.Drawing.Point(12, 32);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(249, 26);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Change Your Password";
            // 
            // ExitPictureBox
            // 
            this.ExitPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ExitPictureBox.Image")));
            this.ExitPictureBox.Location = new System.Drawing.Point(405, 0);
            this.ExitPictureBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ExitPictureBox.Name = "ExitPictureBox";
            this.ExitPictureBox.Size = new System.Drawing.Size(51, 39);
            this.ExitPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ExitPictureBox.TabIndex = 1;
            this.ExitPictureBox.TabStop = false;
            this.ExitPictureBox.Click += new System.EventHandler(this.ExitPictureBox_Click);
            // 
            // PasswordTextBox
            // 
            // 
            // 
            // 
            this.PasswordTextBox.CustomButton.Image = null;
            this.PasswordTextBox.CustomButton.Location = new System.Drawing.Point(237, 2);
            this.PasswordTextBox.CustomButton.Name = "";
            this.PasswordTextBox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.PasswordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.PasswordTextBox.CustomButton.TabIndex = 1;
            this.PasswordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.PasswordTextBox.CustomButton.UseSelectable = true;
            this.PasswordTextBox.CustomButton.Visible = false;
            this.PasswordTextBox.DisplayIcon = true;
            this.PasswordTextBox.Icon = ((System.Drawing.Image)(resources.GetObject("PasswordTextBox.Icon")));
            this.PasswordTextBox.Lines = new string[0];
            this.PasswordTextBox.Location = new System.Drawing.Point(77, 150);
            this.PasswordTextBox.MaxLength = 32767;
            this.PasswordTextBox.Multiline = true;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.PromptText = "Current Password";
            this.PasswordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PasswordTextBox.SelectedText = "";
            this.PasswordTextBox.SelectionLength = 0;
            this.PasswordTextBox.SelectionStart = 0;
            this.PasswordTextBox.ShortcutsEnabled = true;
            this.PasswordTextBox.Size = new System.Drawing.Size(267, 32);
            this.PasswordTextBox.TabIndex = 23;
            this.PasswordTextBox.UseSelectable = true;
            this.PasswordTextBox.WaterMark = "Current Password";
            this.PasswordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.PasswordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLabel.ForeColor = System.Drawing.Color.Black;
            this.UsernameLabel.Location = new System.Drawing.Point(139, 121);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(152, 26);
            this.UsernameLabel.TabIndex = 26;
            this.UsernameLabel.Text = "Username";
            // 
            // ConfirmPassword
            // 
            // 
            // 
            // 
            this.ConfirmPassword.CustomButton.Image = null;
            this.ConfirmPassword.CustomButton.Location = new System.Drawing.Point(237, 2);
            this.ConfirmPassword.CustomButton.Name = "";
            this.ConfirmPassword.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.ConfirmPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ConfirmPassword.CustomButton.TabIndex = 1;
            this.ConfirmPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ConfirmPassword.CustomButton.UseSelectable = true;
            this.ConfirmPassword.CustomButton.Visible = false;
            this.ConfirmPassword.DisplayIcon = true;
            this.ConfirmPassword.Icon = ((System.Drawing.Image)(resources.GetObject("ConfirmPassword.Icon")));
            this.ConfirmPassword.Lines = new string[0];
            this.ConfirmPassword.Location = new System.Drawing.Point(79, 188);
            this.ConfirmPassword.MaxLength = 32767;
            this.ConfirmPassword.Multiline = true;
            this.ConfirmPassword.Name = "ConfirmPassword";
            this.ConfirmPassword.PasswordChar = '*';
            this.ConfirmPassword.PromptText = "Confirm Password";
            this.ConfirmPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ConfirmPassword.SelectedText = "";
            this.ConfirmPassword.SelectionLength = 0;
            this.ConfirmPassword.SelectionStart = 0;
            this.ConfirmPassword.ShortcutsEnabled = true;
            this.ConfirmPassword.Size = new System.Drawing.Size(267, 32);
            this.ConfirmPassword.TabIndex = 28;
            this.ConfirmPassword.UseSelectable = true;
            this.ConfirmPassword.Visible = false;
            this.ConfirmPassword.WaterMark = "Confirm Password";
            this.ConfirmPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ConfirmPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(66)))));
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.Font = new System.Drawing.Font("Garamond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ConfirmButton.Location = new System.Drawing.Point(349, 236);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(85, 27);
            this.ConfirmButton.TabIndex = 29;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            this.ConfirmButton.Visible = false;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(79, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // NextButton
            // 
            this.NextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(66)))));
            this.NextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextButton.Font = new System.Drawing.Font("Garamond", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.NextButton.Location = new System.Drawing.Point(349, 236);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(85, 27);
            this.NextButton.TabIndex = 31;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = false;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // NewPasswordTextBox
            // 
            // 
            // 
            // 
            this.NewPasswordTextBox.CustomButton.Image = null;
            this.NewPasswordTextBox.CustomButton.Location = new System.Drawing.Point(237, 2);
            this.NewPasswordTextBox.CustomButton.Name = "";
            this.NewPasswordTextBox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.NewPasswordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NewPasswordTextBox.CustomButton.TabIndex = 1;
            this.NewPasswordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NewPasswordTextBox.CustomButton.UseSelectable = true;
            this.NewPasswordTextBox.CustomButton.Visible = false;
            this.NewPasswordTextBox.DisplayIcon = true;
            this.NewPasswordTextBox.Icon = ((System.Drawing.Image)(resources.GetObject("NewPasswordTextBox.Icon")));
            this.NewPasswordTextBox.Lines = new string[0];
            this.NewPasswordTextBox.Location = new System.Drawing.Point(77, 150);
            this.NewPasswordTextBox.MaxLength = 32767;
            this.NewPasswordTextBox.Multiline = true;
            this.NewPasswordTextBox.Name = "NewPasswordTextBox";
            this.NewPasswordTextBox.PasswordChar = '*';
            this.NewPasswordTextBox.PromptText = "New Password";
            this.NewPasswordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NewPasswordTextBox.SelectedText = "";
            this.NewPasswordTextBox.SelectionLength = 0;
            this.NewPasswordTextBox.SelectionStart = 0;
            this.NewPasswordTextBox.ShortcutsEnabled = true;
            this.NewPasswordTextBox.Size = new System.Drawing.Size(267, 32);
            this.NewPasswordTextBox.TabIndex = 32;
            this.NewPasswordTextBox.UseSelectable = true;
            this.NewPasswordTextBox.Visible = false;
            this.NewPasswordTextBox.WaterMark = "New Password";
            this.NewPasswordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NewPasswordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 275);
            this.Controls.Add(this.NewPasswordTextBox);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ConfirmPassword);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Garamond", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePasswordForm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExitPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.PictureBox ExitPictureBox;
        private MetroFramework.Controls.MetroTextBox PasswordTextBox;
        private System.Windows.Forms.Label UsernameLabel;
        private MetroFramework.Controls.MetroTextBox ConfirmPassword;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NextButton;
        private MetroFramework.Controls.MetroTextBox NewPasswordTextBox;
    }
}