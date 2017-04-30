namespace ekaH_Windows.Profiles.Forms
{
    partial class DiscussionForm
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
            this.discussionRTF = new System.Windows.Forms.RichTextBox();
            this.textBox = new MetroFramework.Controls.MetroTextBox();
            this.sendTile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // discussionRTF
            // 
            this.discussionRTF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(234)))), ((int)(((byte)(200)))));
            this.discussionRTF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.discussionRTF.Enabled = false;
            this.discussionRTF.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discussionRTF.Location = new System.Drawing.Point(23, 64);
            this.discussionRTF.Name = "discussionRTF";
            this.discussionRTF.Size = new System.Drawing.Size(695, 534);
            this.discussionRTF.TabIndex = 0;
            this.discussionRTF.Text = "";
            // 
            // textBox
            // 
            // 
            // 
            // 
            this.textBox.CustomButton.Image = null;
            this.textBox.CustomButton.Location = new System.Drawing.Point(512, 1);
            this.textBox.CustomButton.Name = "";
            this.textBox.CustomButton.Size = new System.Drawing.Size(59, 59);
            this.textBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox.CustomButton.TabIndex = 1;
            this.textBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox.CustomButton.UseSelectable = true;
            this.textBox.CustomButton.Visible = false;
            this.textBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox.Lines = new string[0];
            this.textBox.Location = new System.Drawing.Point(24, 605);
            this.textBox.MaxLength = 32767;
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.PasswordChar = '\0';
            this.textBox.PromptText = "Write here";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox.SelectedText = "";
            this.textBox.SelectionLength = 0;
            this.textBox.SelectionStart = 0;
            this.textBox.ShortcutsEnabled = true;
            this.textBox.Size = new System.Drawing.Size(572, 61);
            this.textBox.TabIndex = 1;
            this.textBox.UseSelectable = true;
            this.textBox.WaterMark = "Write here";
            this.textBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // sendTile
            // 
            this.sendTile.ActiveControl = null;
            this.sendTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendTile.Location = new System.Drawing.Point(602, 605);
            this.sendTile.Name = "sendTile";
            this.sendTile.Size = new System.Drawing.Size(116, 61);
            this.sendTile.TabIndex = 2;
            this.sendTile.Text = "Send";
            this.sendTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.sendTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.sendTile.UseSelectable = true;
            this.sendTile.Click += new System.EventHandler(this.SendTile_Click);
            // 
            // DiscussionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 676);
            this.Controls.Add(this.sendTile);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.discussionRTF);
            this.Name = "DiscussionForm";
            this.Text = "Discussion for assignment";
            this.Load += new System.EventHandler(this.DiscussionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox discussionRTF;
        private MetroFramework.Controls.MetroTextBox textBox;
        private MetroFramework.Controls.MetroTile sendTile;
    }
}