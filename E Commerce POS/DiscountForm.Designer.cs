namespace E_Commerce_POS
{
    partial class DiscountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscountForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TotalPriceTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DiscountAmountTextBox = new System.Windows.Forms.TextBox();
            this.DIscountPercentTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(43)))), ((int)(((byte)(66)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 47);
            this.panel1.TabIndex = 16;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(598, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(51, 42);
            this.ExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ExitButton.TabIndex = 2;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Garamond", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Discount";
            // 
            // TotalPriceTextBox
            // 
            this.TotalPriceTextBox.Location = new System.Drawing.Point(162, 73);
            this.TotalPriceTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.TotalPriceTextBox.Name = "TotalPriceTextBox";
            this.TotalPriceTextBox.Size = new System.Drawing.Size(413, 25);
            this.TotalPriceTextBox.TabIndex = 47;
            this.TotalPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 18);
            this.label7.TabIndex = 46;
            this.label7.Text = "Discount (%):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 18);
            this.label6.TabIndex = 45;
            this.label6.Text = "Discount Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 43;
            this.label3.Text = "Total Price:";
            // 
            // DiscountAmountTextBox
            // 
            this.DiscountAmountTextBox.Location = new System.Drawing.Point(162, 145);
            this.DiscountAmountTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.DiscountAmountTextBox.Name = "DiscountAmountTextBox";
            this.DiscountAmountTextBox.Size = new System.Drawing.Size(413, 25);
            this.DiscountAmountTextBox.TabIndex = 52;
            this.DiscountAmountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DIscountPercentTextBox
            // 
            this.DIscountPercentTextBox.Location = new System.Drawing.Point(162, 109);
            this.DIscountPercentTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.DIscountPercentTextBox.Name = "DIscountPercentTextBox";
            this.DIscountPercentTextBox.Size = new System.Drawing.Size(413, 25);
            this.DIscountPercentTextBox.TabIndex = 53;
            this.DIscountPercentTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DIscountPercentTextBox.TextChanged += new System.EventHandler(this.DIscountPercentTextBox_TextChanged);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDLabel.Location = new System.Drawing.Point(20, 193);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(21, 18);
            this.IDLabel.TabIndex = 54;
            this.IDLabel.Text = "Id";
            this.IDLabel.Visible = false;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ConfirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConfirmButton.Image = ((System.Drawing.Image)(resources.GetObject("ConfirmButton.Image")));
            this.ConfirmButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ConfirmButton.Location = new System.Drawing.Point(580, 131);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(69, 90);
            this.ConfirmButton.TabIndex = 55;
            this.ConfirmButton.Text = "Save";
            this.ConfirmButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // DiscountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 220);
            this.ControlBox = false;
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.DIscountPercentTextBox);
            this.Controls.Add(this.DiscountAmountTextBox);
            this.Controls.Add(this.TotalPriceTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DiscountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Discount";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ExitButton;
        public System.Windows.Forms.TextBox TotalPriceTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox DiscountAmountTextBox;
        public System.Windows.Forms.TextBox DIscountPercentTextBox;
        public System.Windows.Forms.Button ConfirmButton;
        public System.Windows.Forms.Label IDLabel;
    }
}