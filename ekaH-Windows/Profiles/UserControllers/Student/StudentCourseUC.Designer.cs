namespace ekaH_Windows.Profiles.UserControllers.Student
{
    partial class StudentCourseUC
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
            this.courseListView = new MetroFramework.Controls.MetroListView();
            this.colCourseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSemester = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.days = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.endTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addCourse = new MetroFramework.Controls.MetroTile();
            this.dropCourse = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(0, 47);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(293, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "There are all of the courses you are involved in";
            // 
            // courseListView
            // 
            this.courseListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.courseListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.courseListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.courseListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.courseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCourseName,
            this.colYear,
            this.colSemester,
            this.days,
            this.startTime,
            this.endTime});
            this.courseListView.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.courseListView.FullRowSelect = true;
            this.courseListView.GridLines = true;
            this.courseListView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.courseListView.Location = new System.Drawing.Point(1, 84);
            this.courseListView.MultiSelect = false;
            this.courseListView.Name = "courseListView";
            this.courseListView.OwnerDraw = true;
            this.courseListView.Size = new System.Drawing.Size(768, 453);
            this.courseListView.TabIndex = 2;
            this.courseListView.UseCompatibleStateImageBehavior = false;
            this.courseListView.UseSelectable = true;
            this.courseListView.View = System.Windows.Forms.View.Details;
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
            // days
            // 
            this.days.Text = "Days";
            this.days.Width = 100;
            // 
            // startTime
            // 
            this.startTime.Text = "Start";
            this.startTime.Width = 100;
            // 
            // endTime
            // 
            this.endTime.Text = "End";
            this.endTime.Width = 100;
            // 
            // addCourse
            // 
            this.addCourse.ActiveControl = null;
            this.addCourse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addCourse.AutoSize = true;
            this.addCourse.Location = new System.Drawing.Point(310, 19);
            this.addCourse.Name = "addCourse";
            this.addCourse.Size = new System.Drawing.Size(147, 47);
            this.addCourse.TabIndex = 4;
            this.addCourse.Text = "Add a course";
            this.addCourse.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.addCourse.UseSelectable = true;
            // 
            // dropCourse
            // 
            this.dropCourse.ActiveControl = null;
            this.dropCourse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dropCourse.AutoSize = true;
            this.dropCourse.Location = new System.Drawing.Point(483, 19);
            this.dropCourse.Name = "dropCourse";
            this.dropCourse.Size = new System.Drawing.Size(147, 47);
            this.dropCourse.TabIndex = 4;
            this.dropCourse.Text = "Drop a course";
            this.dropCourse.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.dropCourse.UseSelectable = true;
            // 
            // StudentCourseUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dropCourse);
            this.Controls.Add(this.addCourse);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.courseListView);
            this.Name = "StudentCourseUC";
            this.Size = new System.Drawing.Size(901, 537);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroListView courseListView;
        private System.Windows.Forms.ColumnHeader colCourseName;
        private System.Windows.Forms.ColumnHeader colYear;
        private System.Windows.Forms.ColumnHeader colSemester;
        private System.Windows.Forms.ColumnHeader days;
        private System.Windows.Forms.ColumnHeader startTime;
        private System.Windows.Forms.ColumnHeader endTime;
        private MetroFramework.Controls.MetroTile addCourse;
        private MetroFramework.Controls.MetroTile dropCourse;
    }
}
