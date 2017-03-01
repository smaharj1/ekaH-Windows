namespace ekaH_Windows.Profiles.UserControllers
{
    partial class DashboardUC
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
            this.SuspendLayout();
            // 
            // updateInfoTile
            // 
            this.updateInfoTile.ActiveControl = null;
            this.updateInfoTile.Location = new System.Drawing.Point(223, 69);
            this.updateInfoTile.Name = "updateInfoTile";
            this.updateInfoTile.Size = new System.Drawing.Size(192, 196);
            this.updateInfoTile.TabIndex = 0;
            this.updateInfoTile.Text = "Update your information";
            this.updateInfoTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.updateInfoTile.UseSelectable = true;
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
            this.courseTile.Location = new System.Drawing.Point(3, 177);
            this.courseTile.Name = "courseTile";
            this.courseTile.Size = new System.Drawing.Size(192, 88);
            this.courseTile.TabIndex = 0;
            this.courseTile.Text = "Add/Drop course";
            this.courseTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.courseTile.UseSelectable = true;
            // 
            // appointmentTile
            // 
            this.appointmentTile.ActiveControl = null;
            this.appointmentTile.Location = new System.Drawing.Point(3, 69);
            this.appointmentTile.Name = "appointmentTile";
            this.appointmentTile.Size = new System.Drawing.Size(192, 88);
            this.appointmentTile.TabIndex = 0;
            this.appointmentTile.Text = "Schedule appointments";
            this.appointmentTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.appointmentTile.UseSelectable = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.appointmentTile);
            this.Controls.Add(this.courseTile);
            this.Controls.Add(this.updateInfoTile);
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(843, 557);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile updateInfoTile;
        private MetroFramework.Controls.MetroLabel welcomeLabel;
        private MetroFramework.Controls.MetroTile courseTile;
        private MetroFramework.Controls.MetroTile appointmentTile;
    }
}
