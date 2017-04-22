namespace ekaH_Windows.Profiles.UserControllers
{
    partial class FacultyDashboardUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.updateInfoTile = new MetroFramework.Controls.MetroTile();
            this.welcomeLabel = new MetroFramework.Controls.MetroLabel();
            this.courseTile = new MetroFramework.Controls.MetroTile();
            this.appointmentTile = new MetroFramework.Controls.MetroTile();
            this.goOnlineTile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // updateInfoTile
            // 
            this.updateInfoTile.ActiveControl = null;
            this.updateInfoTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateInfoTile.Location = new System.Drawing.Point(239, 69);
            this.updateInfoTile.Name = "updateInfoTile";
            this.updateInfoTile.Size = new System.Drawing.Size(223, 196);
            this.updateInfoTile.TabIndex = 0;
            this.updateInfoTile.Text = "Update your information";
            this.updateInfoTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.updateInfoTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.updateInfoTile.UseSelectable = true;
            this.updateInfoTile.Click += new System.EventHandler(this.updateInfoTile_Click);
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.welcomeLabel.Location = new System.Drawing.Point(3, 24);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(0, 0);
            this.welcomeLabel.TabIndex = 1;
            // 
            // courseTile
            // 
            this.courseTile.ActiveControl = null;
            this.courseTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.courseTile.Location = new System.Drawing.Point(3, 177);
            this.courseTile.Name = "courseTile";
            this.courseTile.Size = new System.Drawing.Size(214, 88);
            this.courseTile.TabIndex = 0;
            this.courseTile.Text = "Add/Drop course";
            this.courseTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.courseTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.courseTile.UseSelectable = true;
            this.courseTile.Click += new System.EventHandler(this.courseTile_Click);
            // 
            // appointmentTile
            // 
            this.appointmentTile.ActiveControl = null;
            this.appointmentTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.appointmentTile.Location = new System.Drawing.Point(3, 69);
            this.appointmentTile.Name = "appointmentTile";
            this.appointmentTile.Size = new System.Drawing.Size(214, 88);
            this.appointmentTile.TabIndex = 0;
            this.appointmentTile.Text = "Schedule appointments";
            this.appointmentTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.appointmentTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.appointmentTile.UseSelectable = true;
            // 
            // goOnlineTile
            // 
            this.goOnlineTile.ActiveControl = null;
            this.goOnlineTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goOnlineTile.Location = new System.Drawing.Point(3, 287);
            this.goOnlineTile.Name = "goOnlineTile";
            this.goOnlineTile.Size = new System.Drawing.Size(94, 81);
            this.goOnlineTile.TabIndex = 6;
            this.goOnlineTile.TileImage = global::ekaH_Windows.Properties.Resources.chat;
            this.goOnlineTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.goOnlineTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.goOnlineTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.goOnlineTile.UseSelectable = true;
            this.goOnlineTile.UseTileImage = true;
            this.goOnlineTile.Click += new System.EventHandler(this.goOnlineTile_Click);
            // 
            // FacultyDashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.goOnlineTile);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.appointmentTile);
            this.Controls.Add(this.courseTile);
            this.Controls.Add(this.updateInfoTile);
            this.Name = "FacultyDashboardUC";
            this.Size = new System.Drawing.Size(843, 557);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile updateInfoTile;
        private MetroFramework.Controls.MetroLabel welcomeLabel;
        private MetroFramework.Controls.MetroTile courseTile;
        private MetroFramework.Controls.MetroTile appointmentTile;
        private MetroFramework.Controls.MetroTile goOnlineTile;
    }
}
