namespace ekaH_Windows.Profiles.Forms.Chat
{
    partial class SingleChat
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
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.messageTextBox = new MetroFramework.Controls.MetroTextBox();
            this.sendButton = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // messageBox
            // 
            this.messageBox.AutoWordSelection = true;
            this.messageBox.BackColor = System.Drawing.Color.White;
            this.messageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageBox.Location = new System.Drawing.Point(34, 71);
            this.messageBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.messageBox.Name = "messageBox";
            this.messageBox.ReadOnly = true;
            this.messageBox.Size = new System.Drawing.Size(477, 535);
            this.messageBox.TabIndex = 1000;
            this.messageBox.Text = "";
            // 
            // messageTextBox
            // 
            // 
            // 
            // 
            this.messageTextBox.CustomButton.Image = null;
            this.messageTextBox.CustomButton.Location = new System.Drawing.Point(319, 2);
            this.messageTextBox.CustomButton.Name = "";
            this.messageTextBox.CustomButton.Size = new System.Drawing.Size(57, 57);
            this.messageTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.messageTextBox.CustomButton.TabIndex = 1;
            this.messageTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.messageTextBox.CustomButton.UseSelectable = true;
            this.messageTextBox.CustomButton.Visible = false;
            this.messageTextBox.Lines = new string[0];
            this.messageTextBox.Location = new System.Drawing.Point(34, 615);
            this.messageTextBox.MaxLength = 32767;
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.PasswordChar = '\0';
            this.messageTextBox.PromptText = "Write your message here...";
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.messageTextBox.SelectedText = "";
            this.messageTextBox.SelectionLength = 0;
            this.messageTextBox.SelectionStart = 0;
            this.messageTextBox.ShortcutsEnabled = true;
            this.messageTextBox.Size = new System.Drawing.Size(379, 62);
            this.messageTextBox.TabIndex = 0;
            this.messageTextBox.UseSelectable = true;
            this.messageTextBox.WaterMark = "Write your message here...";
            this.messageTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.messageTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // sendButton
            // 
            this.sendButton.ActiveControl = null;
            this.sendButton.Location = new System.Drawing.Point(419, 614);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(92, 63);
            this.sendButton.TabIndex = 1001;
            this.sendButton.Text = "Send";
            this.sendButton.UseSelectable = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // SingleChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(545, 712);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.messageBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SingleChat";
            this.Padding = new System.Windows.Forms.Padding(30, 97, 30, 32);
            this.Text = "Chat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox messageBox;
        private MetroFramework.Controls.MetroTextBox messageTextBox;
        private MetroFramework.Controls.MetroTile sendButton;
    }
}