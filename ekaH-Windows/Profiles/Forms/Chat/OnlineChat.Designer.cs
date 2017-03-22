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
            this.clientBox = new System.Windows.Forms.TextBox();
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
            this.clientBox.Location = new System.Drawing.Point(24, 75);
            this.clientBox.Name = "clientBox";
            this.clientBox.Size = new System.Drawing.Size(224, 20);
            this.clientBox.TabIndex = 2;
            this.clientBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed_Enter);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView userListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox clientBox;
    }
}