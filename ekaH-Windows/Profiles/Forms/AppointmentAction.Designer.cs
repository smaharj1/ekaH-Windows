namespace ekaH_Windows.Profiles.Forms
{
    partial class AppointmentAction
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.professorLabel = new MetroFramework.Controls.MetroLabel();
            this.attendeeLabel = new MetroFramework.Controls.MetroLabel();
            this.startTimeLabel = new MetroFramework.Controls.MetroLabel();
            this.endTimeLabel = new MetroFramework.Controls.MetroLabel();
            this.approveTile = new MetroFramework.Controls.MetroTile();
            this.deleteTile = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(24, 81);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(96, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Professor: ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(24, 119);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(88, 25);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Attendee:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(23, 160);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(95, 25);
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "Start Time:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(24, 204);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(89, 25);
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "End Time:";
            // 
            // professorLabel
            // 
            this.professorLabel.AutoSize = true;
            this.professorLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.professorLabel.Location = new System.Drawing.Point(126, 81);
            this.professorLabel.Name = "professorLabel";
            this.professorLabel.Size = new System.Drawing.Size(93, 25);
            this.professorLabel.TabIndex = 0;
            this.professorLabel.Text = "Not Found";
            // 
            // attendeeLabel
            // 
            this.attendeeLabel.AutoSize = true;
            this.attendeeLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.attendeeLabel.Location = new System.Drawing.Point(126, 119);
            this.attendeeLabel.Name = "attendeeLabel";
            this.attendeeLabel.Size = new System.Drawing.Size(93, 25);
            this.attendeeLabel.TabIndex = 0;
            this.attendeeLabel.Text = "Not Found";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.startTimeLabel.Location = new System.Drawing.Point(126, 160);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(93, 25);
            this.startTimeLabel.TabIndex = 0;
            this.startTimeLabel.Text = "Not Found";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.endTimeLabel.Location = new System.Drawing.Point(126, 204);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(93, 25);
            this.endTimeLabel.TabIndex = 0;
            this.endTimeLabel.Text = "Not Found";
            // 
            // approveTile
            // 
            this.approveTile.ActiveControl = null;
            this.approveTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.approveTile.Location = new System.Drawing.Point(24, 267);
            this.approveTile.Name = "approveTile";
            this.approveTile.Size = new System.Drawing.Size(127, 39);
            this.approveTile.TabIndex = 1;
            this.approveTile.Text = "Approve";
            this.approveTile.UseSelectable = true;
            this.approveTile.Click += new System.EventHandler(this.ApproveTile_Click);
            // 
            // deleteTile
            // 
            this.deleteTile.ActiveControl = null;
            this.deleteTile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteTile.Location = new System.Drawing.Point(168, 267);
            this.deleteTile.Name = "deleteTile";
            this.deleteTile.Size = new System.Drawing.Size(127, 39);
            this.deleteTile.TabIndex = 1;
            this.deleteTile.Text = "Delete";
            this.deleteTile.UseSelectable = true;
            this.deleteTile.Click += new System.EventHandler(this.DeleteTile_Click);
            // 
            // AppointmentAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 343);
            this.Controls.Add(this.deleteTile);
            this.Controls.Add(this.approveTile);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.endTimeLabel);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.attendeeLabel);
            this.Controls.Add(this.professorLabel);
            this.Controls.Add(this.metroLabel1);
            this.Name = "AppointmentAction";
            this.Text = "Appointment Detail";
            this.Load += new System.EventHandler(this.AppointmentAction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel professorLabel;
        private MetroFramework.Controls.MetroLabel attendeeLabel;
        private MetroFramework.Controls.MetroLabel startTimeLabel;
        private MetroFramework.Controls.MetroLabel endTimeLabel;
        private MetroFramework.Controls.MetroTile approveTile;
        private MetroFramework.Controls.MetroTile deleteTile;
    }
}