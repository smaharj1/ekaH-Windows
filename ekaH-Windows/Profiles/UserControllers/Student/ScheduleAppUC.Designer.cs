namespace ekaH_Windows.Profiles.UserControllers.Student
{
    partial class ScheduleAppUC
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
            this.resultPanel = new System.Windows.Forms.Panel();
            this.infoPanel = new MetroFramework.Controls.MetroPanel();
            this.daysTextBox = new System.Windows.Forms.TextBox();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.emailTextBox = new MetroFramework.Controls.MetroLabel();
            this.searchBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultPanel
            // 
            this.resultPanel.AutoScroll = true;
            this.resultPanel.BackColor = System.Drawing.Color.Transparent;
            this.resultPanel.Location = new System.Drawing.Point(3, 219);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(460, 318);
            this.resultPanel.TabIndex = 2;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.daysTextBox);
            this.infoPanel.Controls.Add(this.materialDivider1);
            this.infoPanel.Controls.Add(this.emailTextBox);
            this.infoPanel.HorizontalScrollbarBarColor = true;
            this.infoPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.infoPanel.HorizontalScrollbarSize = 10;
            this.infoPanel.Location = new System.Drawing.Point(0, 93);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(463, 100);
            this.infoPanel.TabIndex = 3;
            this.infoPanel.VerticalScrollbarBarColor = true;
            this.infoPanel.VerticalScrollbarHighlightOnWheel = false;
            this.infoPanel.VerticalScrollbarSize = 10;
            this.infoPanel.Visible = false;
            // 
            // daysTextBox
            // 
            this.daysTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(234)))), ((int)(((byte)(200)))));
            this.daysTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.daysTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.daysTextBox.Enabled = false;
            this.daysTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daysTextBox.Location = new System.Drawing.Point(227, 0);
            this.daysTextBox.Multiline = true;
            this.daysTextBox.Name = "daysTextBox";
            this.daysTextBox.Size = new System.Drawing.Size(236, 100);
            this.daysTextBox.TabIndex = 4;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(211, 0);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(10, 100);
            this.materialDivider1.TabIndex = 3;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // emailTextBox
            // 
            this.emailTextBox.AutoSize = true;
            this.emailTextBox.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.emailTextBox.Location = new System.Drawing.Point(3, 37);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(45, 19);
            this.emailTextBox.TabIndex = 2;
            this.emailTextBox.Text = "Email";
            // 
            // searchBox
            // 
            // 
            // 
            // 
            this.searchBox.CustomButton.Image = null;
            this.searchBox.CustomButton.Location = new System.Drawing.Point(252, 1);
            this.searchBox.CustomButton.Name = "";
            this.searchBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.searchBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.searchBox.CustomButton.TabIndex = 1;
            this.searchBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.searchBox.CustomButton.UseSelectable = true;
            this.searchBox.CustomButton.Visible = false;
            this.searchBox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.searchBox.Lines = new string[0];
            this.searchBox.Location = new System.Drawing.Point(0, 56);
            this.searchBox.MaxLength = 32767;
            this.searchBox.Name = "searchBox";
            this.searchBox.PasswordChar = '\0';
            this.searchBox.PromptText = "Professor\'s email";
            this.searchBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchBox.SelectedText = "";
            this.searchBox.SelectionLength = 0;
            this.searchBox.SelectionStart = 0;
            this.searchBox.ShortcutsEnabled = true;
            this.searchBox.Size = new System.Drawing.Size(274, 23);
            this.searchBox.TabIndex = 0;
            this.searchBox.UseSelectable = true;
            this.searchBox.WaterMark = "Professor\'s email";
            this.searchBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.searchBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_EnterPressed);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(0, 13);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(215, 25);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Schedule an appointment";
            // 
            // ScheduleAppUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.resultPanel);
            this.Name = "ScheduleAppUC";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(484, 547);
            this.Load += new System.EventHandler(this.ScheduleAppUC_Load);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel resultPanel;
        private MetroFramework.Controls.MetroPanel infoPanel;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MetroFramework.Controls.MetroLabel emailTextBox;
        private System.Windows.Forms.TextBox daysTextBox;
        private MetroFramework.Controls.MetroTextBox searchBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}
