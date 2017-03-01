namespace ekaH_Windows.Profiles.UserControllers
{
    partial class FacultyCourseUC
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("aaa");
            this.courseListView = new MetroFramework.Controls.MetroListView();
            this.colCourseNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCourseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSemester = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.addCourse = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // courseListView
            // 
            this.courseListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.courseListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.courseListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCourseNum,
            this.colCourseName,
            this.colYear,
            this.colSemester,
            this.colDescription});
            this.courseListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.courseListView.FullRowSelect = true;
            this.courseListView.GridLines = true;
            this.courseListView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.courseListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.courseListView.Location = new System.Drawing.Point(0, 84);
            this.courseListView.Name = "courseListView";
            this.courseListView.OwnerDraw = true;
            this.courseListView.Size = new System.Drawing.Size(901, 453);
            this.courseListView.TabIndex = 0;
            this.courseListView.UseCompatibleStateImageBehavior = false;
            this.courseListView.UseSelectable = true;
            this.courseListView.View = System.Windows.Forms.View.Details;
            // 
            // colCourseNum
            // 
            this.colCourseNum.Text = "Course Code";
            this.colCourseNum.Width = 150;
            // 
            // colCourseName
            // 
            this.colCourseName.Text = "Name";
            this.colCourseName.Width = 250;
            // 
            // colYear
            // 
            this.colYear.Text = "Year";
            // 
            // colSemester
            // 
            this.colSemester.Text = "Semester";
            this.colSemester.Width = 150;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 290;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(0, 47);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(293, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "There are all of the courses you are involved in";
            // 
            // addCourse
            // 
            this.addCourse.ActiveControl = null;
            this.addCourse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addCourse.AutoSize = true;
            this.addCourse.Location = new System.Drawing.Point(321, 19);
            this.addCourse.Name = "addCourse";
            this.addCourse.Size = new System.Drawing.Size(147, 47);
            this.addCourse.TabIndex = 2;
            this.addCourse.Text = "Add a course";
            this.addCourse.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.addCourse.UseSelectable = true;
            // 
            // FacultyCourseUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addCourse);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.courseListView);
            this.Name = "FacultyCourseUC";
            this.Size = new System.Drawing.Size(901, 537);
            this.Load += new System.EventHandler(this.ViewCourseUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroListView courseListView;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTile addCourse;
        private System.Windows.Forms.ColumnHeader colCourseNum;
        private System.Windows.Forms.ColumnHeader colCourseName;
        private System.Windows.Forms.ColumnHeader colYear;
        private System.Windows.Forms.ColumnHeader colSemester;
        private System.Windows.Forms.ColumnHeader colDescription;
    }
}
