namespace ekaH_Windows.Profiles
{
    partial class FacultyProfile
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.contentPanel = new MetroFramework.Controls.MetroPanel();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.dashboardTab = new MetroFramework.Controls.MetroTabPage();
            this.coursesTab = new MetroFramework.Controls.MetroTabPage();
            this.appointmentTab = new MetroFramework.Controls.MetroTabPage();
            this.onlineChatTab = new MetroFramework.Controls.MetroTabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(187, 23);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(774, 151);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.contentPanel.HorizontalScrollbarBarColor = true;
            this.contentPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.contentPanel.HorizontalScrollbarSize = 10;
            this.contentPanel.Location = new System.Drawing.Point(23, 273);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(941, 399);
            this.contentPanel.TabIndex = 2;
            this.contentPanel.VerticalScrollbarBarColor = true;
            this.contentPanel.VerticalScrollbarHighlightOnWheel = false;
            this.contentPanel.VerticalScrollbarSize = 10;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.dashboardTab);
            this.tabControl.Controls.Add(this.coursesTab);
            this.tabControl.Controls.Add(this.appointmentTab);
            this.tabControl.Controls.Add(this.onlineChatTab);
            this.tabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.tabControl.ItemSize = new System.Drawing.Size(150, 34);
            this.tabControl.Location = new System.Drawing.Point(26, 203);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(641, 53);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 3;
            this.tabControl.UseSelectable = true;
            this.tabControl.Click += new System.EventHandler(this.tabControl_Click);
            // 
            // dashboardTab
            // 
            this.dashboardTab.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardTab.HorizontalScrollbarBarColor = true;
            this.dashboardTab.HorizontalScrollbarHighlightOnWheel = false;
            this.dashboardTab.HorizontalScrollbarSize = 10;
            this.dashboardTab.Location = new System.Drawing.Point(4, 38);
            this.dashboardTab.Name = "dashboardTab";
            this.dashboardTab.Size = new System.Drawing.Size(633, 11);
            this.dashboardTab.TabIndex = 0;
            this.dashboardTab.Text = "Dashboard";
            this.dashboardTab.VerticalScrollbarBarColor = true;
            this.dashboardTab.VerticalScrollbarHighlightOnWheel = false;
            this.dashboardTab.VerticalScrollbarSize = 10;
            this.dashboardTab.Click += new System.EventHandler(this.dashboardControl_Click);
            // 
            // coursesTab
            // 
            this.coursesTab.HorizontalScrollbarBarColor = true;
            this.coursesTab.HorizontalScrollbarHighlightOnWheel = false;
            this.coursesTab.HorizontalScrollbarSize = 10;
            this.coursesTab.Location = new System.Drawing.Point(4, 38);
            this.coursesTab.Name = "coursesTab";
            this.coursesTab.Size = new System.Drawing.Size(649, 11);
            this.coursesTab.TabIndex = 1;
            this.coursesTab.Text = "Courses";
            this.coursesTab.VerticalScrollbarBarColor = true;
            this.coursesTab.VerticalScrollbarHighlightOnWheel = false;
            this.coursesTab.VerticalScrollbarSize = 6;
            this.coursesTab.Click += new System.EventHandler(this.coursesControl_Click);
            // 
            // appointmentTab
            // 
            this.appointmentTab.HorizontalScrollbarBarColor = true;
            this.appointmentTab.HorizontalScrollbarHighlightOnWheel = false;
            this.appointmentTab.HorizontalScrollbarSize = 10;
            this.appointmentTab.Location = new System.Drawing.Point(4, 38);
            this.appointmentTab.Name = "appointmentTab";
            this.appointmentTab.Size = new System.Drawing.Size(649, 11);
            this.appointmentTab.TabIndex = 2;
            this.appointmentTab.Text = "Appointments";
            this.appointmentTab.VerticalScrollbarBarColor = true;
            this.appointmentTab.VerticalScrollbarHighlightOnWheel = false;
            this.appointmentTab.VerticalScrollbarSize = 6;
            // 
            // onlineChatTab
            // 
            this.onlineChatTab.HorizontalScrollbarBarColor = true;
            this.onlineChatTab.HorizontalScrollbarHighlightOnWheel = false;
            this.onlineChatTab.HorizontalScrollbarSize = 10;
            this.onlineChatTab.Location = new System.Drawing.Point(4, 38);
            this.onlineChatTab.Name = "onlineChatTab";
            this.onlineChatTab.Size = new System.Drawing.Size(649, 11);
            this.onlineChatTab.TabIndex = 3;
            this.onlineChatTab.Text = "Go Online";
            this.onlineChatTab.VerticalScrollbarBarColor = true;
            this.onlineChatTab.VerticalScrollbarHighlightOnWheel = false;
            this.onlineChatTab.VerticalScrollbarSize = 6;
            // 
            // FacultyProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 692);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.metroPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FacultyProfile";
            this.Padding = new System.Windows.Forms.Padding(23, 60, 23, 20);
            this.Text = "Faculty Portal";
            this.Load += new System.EventHandler(this.FacultyProfile_Load);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel contentPanel;
        private MetroFramework.Controls.MetroTabControl tabControl;
        private MetroFramework.Controls.MetroTabPage dashboardTab;
        private MetroFramework.Controls.MetroTabPage coursesTab;
        private MetroFramework.Controls.MetroTabPage appointmentTab;
        private MetroFramework.Controls.MetroTabPage onlineChatTab;
    }
}