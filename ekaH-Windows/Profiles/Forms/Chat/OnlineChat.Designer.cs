namespace ekaH_Windows.Profiles.Forms
{
    partial class OnlineChat
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
            this.userListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientBox = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // userListView
            // 
            this.userListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.userListView.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.userListView.FullRowSelect = true;
            this.userListView.Location = new System.Drawing.Point(23, 147);
            this.userListView.Name = "userListView";
            this.userListView.Size = new System.Drawing.Size(346, 419);
            this.userListView.TabIndex = 1;
            this.userListView.UseCompatibleStateImageBehavior = false;
            this.userListView.View = System.Windows.Forms.View.Tile;
            this.userListView.DoubleClick += new System.EventHandler(this.ListDoubleClicked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = -2;
            // 
            // clientBox
            // 
            // 
            // 
            // 
            this.clientBox.CustomButton.Image = null;
            this.clientBox.CustomButton.Location = new System.Drawing.Point(228, 1);
            this.clientBox.CustomButton.Name = "";
            this.clientBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.clientBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.clientBox.CustomButton.TabIndex = 1;
            this.clientBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.clientBox.CustomButton.UseSelectable = true;
            this.clientBox.CustomButton.Visible = false;
            this.clientBox.Lines = new string[0];
            this.clientBox.Location = new System.Drawing.Point(23, 79);
            this.clientBox.MaxLength = 32767;
            this.clientBox.Name = "clientBox";
            this.clientBox.PasswordChar = '\0';
            this.clientBox.PromptText = "Search";
            this.clientBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.clientBox.SelectedText = "";
            this.clientBox.SelectionLength = 0;
            this.clientBox.SelectionStart = 0;
            this.clientBox.ShortcutsEnabled = true;
            this.clientBox.Size = new System.Drawing.Size(250, 23);
            this.clientBox.TabIndex = 2;
            this.clientBox.UseSelectable = true;
            this.clientBox.WaterMark = "Search";
            this.clientBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.clientBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // OnlineChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 589);
            this.Controls.Add(this.clientBox);
            this.Controls.Add(this.userListView);
            this.Name = "OnlineChat";
            this.Text = "People online right now...";
            this.Load += new System.EventHandler(this.OnlineChat_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView userListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private MetroFramework.Controls.MetroTextBox clientBox;
    }
}