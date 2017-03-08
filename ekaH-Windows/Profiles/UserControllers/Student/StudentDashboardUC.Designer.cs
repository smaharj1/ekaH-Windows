﻿namespace ekaH_Windows.Profiles.UserControllers.Student
{
    partial class StudentDashboardUC
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
            this.appointmentTile = new MetroFramework.Controls.MetroTile();
            this.enrollCourseTile = new MetroFramework.Controls.MetroTile();
            this.updateInfoTile = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.submitAssignmentTile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // appointmentTile
            // 
            this.appointmentTile.ActiveControl = null;
            this.appointmentTile.Location = new System.Drawing.Point(25, 82);
            this.appointmentTile.Name = "appointmentTile";
            this.appointmentTile.Size = new System.Drawing.Size(218, 81);
            this.appointmentTile.TabIndex = 1;
            this.appointmentTile.Text = "Schedule appointments";
            this.appointmentTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.appointmentTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.appointmentTile.UseSelectable = true;
            // 
            // enrollCourseTile
            // 
            this.enrollCourseTile.ActiveControl = null;
            this.enrollCourseTile.Location = new System.Drawing.Point(25, 190);
            this.enrollCourseTile.Name = "enrollCourseTile";
            this.enrollCourseTile.Size = new System.Drawing.Size(218, 81);
            this.enrollCourseTile.TabIndex = 2;
            this.enrollCourseTile.Text = "Enroll to course";
            this.enrollCourseTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.enrollCourseTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.enrollCourseTile.UseSelectable = true;
            // 
            // updateInfoTile
            // 
            this.updateInfoTile.ActiveControl = null;
            this.updateInfoTile.Location = new System.Drawing.Point(269, 82);
            this.updateInfoTile.Name = "updateInfoTile";
            this.updateInfoTile.Size = new System.Drawing.Size(228, 189);
            this.updateInfoTile.TabIndex = 3;
            this.updateInfoTile.Text = "Update your information";
            this.updateInfoTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.updateInfoTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.updateInfoTile.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(25, 27);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(304, 25);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Do your important tasks in one step!";
            // 
            // submitAssignmentTile
            // 
            this.submitAssignmentTile.ActiveControl = null;
            this.submitAssignmentTile.Location = new System.Drawing.Point(25, 299);
            this.submitAssignmentTile.Name = "submitAssignmentTile";
            this.submitAssignmentTile.Size = new System.Drawing.Size(218, 81);
            this.submitAssignmentTile.TabIndex = 2;
            this.submitAssignmentTile.Text = "Submit Assignment";
            this.submitAssignmentTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.submitAssignmentTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.submitAssignmentTile.UseSelectable = true;
            // 
            // StudentDashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.appointmentTile);
            this.Controls.Add(this.submitAssignmentTile);
            this.Controls.Add(this.enrollCourseTile);
            this.Controls.Add(this.updateInfoTile);
            this.Name = "StudentDashboardUC";
            this.Size = new System.Drawing.Size(843, 557);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile appointmentTile;
        private MetroFramework.Controls.MetroTile enrollCourseTile;
        private MetroFramework.Controls.MetroTile updateInfoTile;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile submitAssignmentTile;
    }
}