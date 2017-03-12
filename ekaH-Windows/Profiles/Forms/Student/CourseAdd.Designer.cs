namespace ekaH_Windows.Profiles.Forms.Student
{
    partial class CourseAdd
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
            this.courseIDText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.searchTextBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.searchTile = new MetroFramework.Controls.MetroTile();
            this.resultPanel = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // courseIDText
            // 
            this.courseIDText.Depth = 0;
            this.courseIDText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseIDText.Hint = "Course ID";
            this.courseIDText.Location = new System.Drawing.Point(23, 146);
            this.courseIDText.MouseState = MaterialSkin.MouseState.HOVER;
            this.courseIDText.Name = "courseIDText";
            this.courseIDText.PasswordChar = '\0';
            this.courseIDText.SelectedText = "";
            this.courseIDText.SelectionLength = 0;
            this.courseIDText.SelectionStart = 0;
            this.courseIDText.Size = new System.Drawing.Size(386, 23);
            this.courseIDText.TabIndex = 0;
            this.courseIDText.UseSystemPasswordChar = false;
            this.courseIDText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.courseIDText_KeyDown);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Depth = 0;
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Hint = "Search by name";
            this.searchTextBox.Location = new System.Drawing.Point(23, 280);
            this.searchTextBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.PasswordChar = '\0';
            this.searchTextBox.SelectedText = "";
            this.searchTextBox.SelectionLength = 0;
            this.searchTextBox.SelectionStart = 0;
            this.searchTextBox.Size = new System.Drawing.Size(386, 23);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.UseSystemPasswordChar = false;
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(357, 104);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(10, 467);
            this.materialDivider1.TabIndex = 3;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(133, 217);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(28, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "OR";
            // 
            // searchTile
            // 
            this.searchTile.ActiveControl = null;
            this.searchTile.Location = new System.Drawing.Point(23, 377);
            this.searchTile.Name = "searchTile";
            this.searchTile.Size = new System.Drawing.Size(283, 68);
            this.searchTile.TabIndex = 2;
            this.searchTile.Text = "Go!";
            this.searchTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.searchTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.searchTile.UseSelectable = true;
            this.searchTile.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // resultPanel
            // 
            this.resultPanel.AutoScroll = true;
            this.resultPanel.HorizontalScrollbar = true;
            this.resultPanel.HorizontalScrollbarBarColor = true;
            this.resultPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.resultPanel.HorizontalScrollbarSize = 10;
            this.resultPanel.Location = new System.Drawing.Point(373, 104);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Padding = new System.Windows.Forms.Padding(10);
            this.resultPanel.Size = new System.Drawing.Size(618, 467);
            this.resultPanel.TabIndex = 4;
            this.resultPanel.VerticalScrollbar = true;
            this.resultPanel.VerticalScrollbarBarColor = true;
            this.resultPanel.VerticalScrollbarHighlightOnWheel = true;
            this.resultPanel.VerticalScrollbarSize = 20;
            // 
            // CourseAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 581);
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.searchTile);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.courseIDText);
            this.Name = "CourseAdd";
            this.Resizable = false;
            this.Text = "Add a course";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField courseIDText;
        private MaterialSkin.Controls.MaterialSingleLineTextField searchTextBox;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile searchTile;
        private MetroFramework.Controls.MetroPanel resultPanel;
    }
}