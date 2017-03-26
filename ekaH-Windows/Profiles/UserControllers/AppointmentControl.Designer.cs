namespace ekaH_Windows.Profiles.UserControllers
{
    partial class AppointmentControl
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
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.upcomingAppPanel = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.pendingAppPanel = new MetroFramework.Controls.MetroPanel();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.contentPanel = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(0, 20);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(214, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Upcoming Appointments";
            // 
            // upcomingAppPanel
            // 
            this.upcomingAppPanel.AutoScroll = true;
            this.upcomingAppPanel.HorizontalScrollbar = true;
            this.upcomingAppPanel.HorizontalScrollbarBarColor = true;
            this.upcomingAppPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.upcomingAppPanel.HorizontalScrollbarSize = 10;
            this.upcomingAppPanel.Location = new System.Drawing.Point(4, 53);
            this.upcomingAppPanel.Name = "upcomingAppPanel";
            this.upcomingAppPanel.Size = new System.Drawing.Size(283, 216);
            this.upcomingAppPanel.TabIndex = 3;
            this.upcomingAppPanel.VerticalScrollbar = true;
            this.upcomingAppPanel.VerticalScrollbarBarColor = true;
            this.upcomingAppPanel.VerticalScrollbarHighlightOnWheel = false;
            this.upcomingAppPanel.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(0, 306);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(195, 25);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Pending Appointments";
            // 
            // pendingAppPanel
            // 
            this.pendingAppPanel.AutoScroll = true;
            this.pendingAppPanel.HorizontalScrollbar = true;
            this.pendingAppPanel.HorizontalScrollbarBarColor = true;
            this.pendingAppPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.pendingAppPanel.HorizontalScrollbarSize = 10;
            this.pendingAppPanel.Location = new System.Drawing.Point(4, 334);
            this.pendingAppPanel.Name = "pendingAppPanel";
            this.pendingAppPanel.Size = new System.Drawing.Size(283, 216);
            this.pendingAppPanel.TabIndex = 3;
            this.pendingAppPanel.VerticalScrollbar = true;
            this.pendingAppPanel.VerticalScrollbarBarColor = true;
            this.pendingAppPanel.VerticalScrollbarHighlightOnWheel = false;
            this.pendingAppPanel.VerticalScrollbarSize = 10;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(4, 286);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(283, 10);
            this.materialDivider1.TabIndex = 4;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(294, 53);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(10, 499);
            this.materialDivider2.TabIndex = 5;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // contentPanel
            // 
            this.contentPanel.HorizontalScrollbarBarColor = true;
            this.contentPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.contentPanel.HorizontalScrollbarSize = 10;
            this.contentPanel.Location = new System.Drawing.Point(310, 3);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(533, 549);
            this.contentPanel.TabIndex = 6;
            this.contentPanel.VerticalScrollbarBarColor = true;
            this.contentPanel.VerticalScrollbarHighlightOnWheel = false;
            this.contentPanel.VerticalScrollbarSize = 10;
            // 
            // AppointmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.materialDivider2);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.pendingAppPanel);
            this.Controls.Add(this.upcomingAppPanel);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "AppointmentControl";
            this.Size = new System.Drawing.Size(843, 557);
            this.Load += new System.EventHandler(this.AppointmentControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel upcomingAppPanel;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroPanel pendingAppPanel;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private MetroFramework.Controls.MetroPanel contentPanel;
    }
}
