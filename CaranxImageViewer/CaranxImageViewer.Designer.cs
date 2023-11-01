namespace CaranxImageViewer
{
    partial class CaranxImageViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaranxImageViewer));
            this.buttonLoadImages = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.imageNumberInfo = new System.Windows.Forms.TextBox();
            this.imagePointDataText = new System.Windows.Forms.TextBox();
            this.imageNameText = new System.Windows.Forms.TextBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadImages
            // 
            this.buttonLoadImages.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonLoadImages.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLoadImages.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLoadImages.Location = new System.Drawing.Point(12, 533);
            this.buttonLoadImages.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLoadImages.Name = "buttonLoadImages";
            this.buttonLoadImages.Size = new System.Drawing.Size(261, 37);
            this.buttonLoadImages.TabIndex = 0;
            this.buttonLoadImages.Text = "Load images";
            this.buttonLoadImages.UseVisualStyleBackColor = false;
            this.buttonLoadImages.Click += new System.EventHandler(this.buttonLoadImages_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(936, 466);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(952, 8);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 568);
            this.vScrollBar1.TabIndex = 2;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // imageNumberInfo
            // 
            this.imageNumberInfo.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageNumberInfo.Location = new System.Drawing.Point(12, 484);
            this.imageNumberInfo.Margin = new System.Windows.Forms.Padding(0);
            this.imageNumberInfo.Name = "imageNumberInfo";
            this.imageNumberInfo.Size = new System.Drawing.Size(261, 22);
            this.imageNumberInfo.TabIndex = 3;
            // 
            // imagePointDataText
            // 
            this.imagePointDataText.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.imagePointDataText.Location = new System.Drawing.Point(669, 515);
            this.imagePointDataText.Multiline = true;
            this.imagePointDataText.Name = "imagePointDataText";
            this.imagePointDataText.Size = new System.Drawing.Size(280, 105);
            this.imagePointDataText.TabIndex = 5;
            // 
            // imageNameText
            // 
            this.imageNameText.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.imageNameText.Location = new System.Drawing.Point(325, 484);
            this.imageNameText.Name = "imageNameText";
            this.imageNameText.Size = new System.Drawing.Size(624, 22);
            this.imageNameText.TabIndex = 6;
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.exportButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exportButton.Location = new System.Drawing.Point(13, 578);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(262, 37);
            this.exportButton.TabIndex = 7;
            this.exportButton.Text = "Export landmarks";
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoTextBox.Location = new System.Drawing.Point(325, 515);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.Size = new System.Drawing.Size(280, 105);
            this.infoTextBox.TabIndex = 8;
            // 
            // CaranxImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(982, 631);
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.imageNameText);
            this.Controls.Add(this.imagePointDataText);
            this.Controls.Add(this.imageNumberInfo);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonLoadImages);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CaranxImageViewer";
            this.Text = "CaranxImageViewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadImages;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.TextBox imageNumberInfo;
        private System.Windows.Forms.TextBox imagePointDataText;
        private System.Windows.Forms.TextBox imageNameText;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.TextBox infoTextBox;
    }
}

