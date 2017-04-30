namespace ekaH_Windows.Profiles.Forms
{
    partial class UpdateInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateInfo));
            this.updateInfoPanel = new MetroFramework.Controls.MetroPanel();
            this.infoLabel = new MetroFramework.Controls.MetroLabel();
            this.trackBar = new MetroFramework.Controls.MetroTrackBar();
            this.submitButton = new MetroFramework.Controls.MetroTile();
            this.previousIcon = new System.Windows.Forms.PictureBox();
            this.nextIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.previousIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // updateInfoPanel
            // 
            this.updateInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateInfoPanel.BackColor = System.Drawing.Color.Red;
            this.updateInfoPanel.HorizontalScrollbarBarColor = true;
            this.updateInfoPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.updateInfoPanel.HorizontalScrollbarSize = 10;
            this.updateInfoPanel.Location = new System.Drawing.Point(86, 153);
            this.updateInfoPanel.Name = "updateInfoPanel";
            this.updateInfoPanel.Size = new System.Drawing.Size(387, 484);
            this.updateInfoPanel.TabIndex = 0;
            this.updateInfoPanel.VerticalScrollbarBarColor = true;
            this.updateInfoPanel.VerticalScrollbarHighlightOnWheel = false;
            this.updateInfoPanel.VerticalScrollbarSize = 10;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.infoLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.infoLabel.Location = new System.Drawing.Point(86, 64);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(179, 25);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "Tell us about yourself";
            // 
            // trackBar
            // 
            this.trackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar.BackColor = System.Drawing.Color.Transparent;
            this.trackBar.Enabled = false;
            this.trackBar.Location = new System.Drawing.Point(86, 113);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(387, 23);
            this.trackBar.TabIndex = 2;
            this.trackBar.Text = "metroTrackBar1";
            // 
            // submitButton
            // 
            this.submitButton.ActiveControl = null;
            this.submitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.submitButton.Location = new System.Drawing.Point(144, 663);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(277, 53);
            this.submitButton.TabIndex = 6;
            this.submitButton.Text = "Submit";
            this.submitButton.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.submitButton.UseSelectable = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // previousIcon
            // 
            this.previousIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.previousIcon.Image = global::ekaH_Windows.Properties.Resources.previousIcon;
            this.previousIcon.Location = new System.Drawing.Point(23, 361);
            this.previousIcon.Name = "previousIcon";
            this.previousIcon.Size = new System.Drawing.Size(49, 50);
            this.previousIcon.TabIndex = 5;
            this.previousIcon.TabStop = false;
            this.previousIcon.Click += new System.EventHandler(this.PreviousIcon_Click);
            // 
            // nextIcon
            // 
            this.nextIcon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nextIcon.Image = ((System.Drawing.Image)(resources.GetObject("nextIcon.Image")));
            this.nextIcon.Location = new System.Drawing.Point(487, 361);
            this.nextIcon.Name = "nextIcon";
            this.nextIcon.Size = new System.Drawing.Size(51, 50);
            this.nextIcon.TabIndex = 4;
            this.nextIcon.TabStop = false;
            this.nextIcon.Click += new System.EventHandler(this.NextIcon_Click);
            // 
            // UpdateInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 739);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.previousIcon);
            this.Controls.Add(this.nextIcon);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.updateInfoPanel);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.Name = "UpdateInfo";
            this.Text = "Update your information";
            ((System.ComponentModel.ISupportInitialize)(this.previousIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel updateInfoPanel;
        private MetroFramework.Controls.MetroLabel infoLabel;
        private MetroFramework.Controls.MetroTrackBar trackBar;
        private System.Windows.Forms.PictureBox nextIcon;
        private System.Windows.Forms.PictureBox previousIcon;
        private MetroFramework.Controls.MetroTile submitButton;
    }
}