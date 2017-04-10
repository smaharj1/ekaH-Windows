namespace ekaH_Windows.Profiles.Forms
{
    partial class CourseDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.assignmentList = new System.Windows.Forms.ListView();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.courseDetailPanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.panel1.Controls.Add(this.metroTile1);
            this.panel1.Controls.Add(this.assignmentList);
            this.panel1.Controls.Add(this.metroLabel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 712);
            this.panel1.TabIndex = 0;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.BackColor = System.Drawing.Color.White;
            this.metroTile1.Location = new System.Drawing.Point(17, 561);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(281, 48);
            this.metroTile1.TabIndex = 2;
            this.metroTile1.Text = "Add an assignment";
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.UseCustomBackColor = true;
            this.metroTile1.UseCustomForeColor = true;
            this.metroTile1.UseSelectable = true;
            // 
            // assignmentList
            // 
            this.assignmentList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.assignmentList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(171)))), ((int)(((byte)(227)))));
            this.assignmentList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.assignmentList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.assignmentList.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.assignmentList.ForeColor = System.Drawing.Color.White;
            this.assignmentList.FullRowSelect = true;
            this.assignmentList.HoverSelection = true;
            this.assignmentList.Location = new System.Drawing.Point(17, 75);
            this.assignmentList.MultiSelect = false;
            this.assignmentList.Name = "assignmentList";
            this.assignmentList.Size = new System.Drawing.Size(281, 480);
            this.assignmentList.TabIndex = 1;
            this.assignmentList.TileSize = new System.Drawing.Size(280, 54);
            this.assignmentList.UseCompatibleStateImageBehavior = false;
            this.assignmentList.View = System.Windows.Forms.View.Tile;
            this.assignmentList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.assignmentList_Click);
            this.assignmentList.MouseHover += new System.EventHandler(this.assignmentList_OnMouseHover);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.ForeColor = System.Drawing.Color.White;
            this.metroLabel1.Location = new System.Drawing.Point(96, 15);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(114, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Assignments";
            this.metroLabel1.UseCustomBackColor = true;
            this.metroLabel1.UseCustomForeColor = true;
            // 
            // courseDetailPanel
            // 
            this.courseDetailPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.courseDetailPanel.Location = new System.Drawing.Point(340, 60);
            this.courseDetailPanel.Name = "courseDetailPanel";
            this.courseDetailPanel.Size = new System.Drawing.Size(867, 712);
            this.courseDetailPanel.TabIndex = 1;
            // 
            // CourseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 792);
            this.Controls.Add(this.courseDetailPanel);
            this.Controls.Add(this.panel1);
            this.Name = "CourseDetail";
            this.Text = "CourseDetail";
            this.Load += new System.EventHandler(this.CourseDetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ListView assignmentList;
        private MetroFramework.Controls.MetroTile metroTile1;
        private System.Windows.Forms.Panel courseDetailPanel;
    }
}