namespace ekaH_Windows.Profiles.UserControllers.Faculty
{
    partial class FacultyScheduleUC
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
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dayComboBox = new MetroFramework.Controls.MetroComboBox();
            this.startDatePicker = new MetroFramework.Controls.MetroDateTime();
            this.endDatePicker = new MetroFramework.Controls.MetroDateTime();
            this.submitBox = new System.Windows.Forms.PictureBox();
            this.addBox = new System.Windows.Forms.PictureBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.submitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBox)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(3, 18);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(233, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Schedule for the semester";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(3, 108);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(115, 25);
            this.metroLabel2.TabIndex = 0;
            this.metroLabel2.Text = "Starting Date";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(3, 227);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(186, 25);
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "Chose times and days";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(3, 151);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(84, 25);
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "End Date";
            this.metroLabel3.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // startTimePicker
            // 
            this.startTimePicker.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimePicker.CustomFormat = "hh:mm tt";
            this.startTimePicker.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(6, 322);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(117, 32);
            this.startTimePicker.TabIndex = 2;
            // 
            // endTimePicker
            // 
            this.endTimePicker.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTimePicker.CustomFormat = "hh:mm tt";
            this.endTimePicker.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(180, 322);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(117, 32);
            this.endTimePicker.TabIndex = 2;
            // 
            // dayComboBox
            // 
            this.dayComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dayComboBox.FontSize = MetroFramework.MetroComboBoxSize.Tall;
            this.dayComboBox.FormattingEnabled = true;
            this.dayComboBox.ItemHeight = 29;
            this.dayComboBox.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
            this.dayComboBox.Location = new System.Drawing.Point(6, 270);
            this.dayComboBox.Name = "dayComboBox";
            this.dayComboBox.PromptText = "Select a day";
            this.dayComboBox.Size = new System.Drawing.Size(174, 35);
            this.dayComboBox.TabIndex = 4;
            this.dayComboBox.UseSelectable = true;
            // 
            // startDatePicker
            // 
            this.startDatePicker.FontSize = MetroFramework.MetroDateTimeSize.Tall;
            this.startDatePicker.Location = new System.Drawing.Point(125, 98);
            this.startDatePicker.MinimumSize = new System.Drawing.Size(0, 35);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(200, 35);
            this.startDatePicker.TabIndex = 5;
            // 
            // endDatePicker
            // 
            this.endDatePicker.FontSize = MetroFramework.MetroDateTimeSize.Tall;
            this.endDatePicker.Location = new System.Drawing.Point(125, 141);
            this.endDatePicker.MinimumSize = new System.Drawing.Size(0, 35);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(200, 35);
            this.endDatePicker.TabIndex = 6;
            // 
            // submitBox
            // 
            this.submitBox.BackColor = System.Drawing.Color.Transparent;
            this.submitBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBox.Image = global::ekaH_Windows.Properties.Resources.done;
            this.submitBox.Location = new System.Drawing.Point(172, 404);
            this.submitBox.Name = "submitBox";
            this.submitBox.Size = new System.Drawing.Size(64, 64);
            this.submitBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.submitBox.TabIndex = 7;
            this.submitBox.TabStop = false;
            this.submitBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // addBox
            // 
            this.addBox.BackColor = System.Drawing.Color.Transparent;
            this.addBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addBox.Image = global::ekaH_Windows.Properties.Resources._1490601027_add2;
            this.addBox.Location = new System.Drawing.Point(86, 404);
            this.addBox.Name = "addBox";
            this.addBox.Size = new System.Drawing.Size(64, 64);
            this.addBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.addBox.TabIndex = 1;
            this.addBox.TabStop = false;
            this.addBox.Click += new System.EventHandler(this.addBox_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(170, 469);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(69, 25);
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "Submit";
            this.metroLabel5.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(94, 469);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(46, 25);
            this.metroLabel6.TabIndex = 0;
            this.metroLabel6.Text = "Add";
            this.metroLabel6.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(133, 326);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(34, 25);
            this.metroLabel7.TabIndex = 0;
            this.metroLabel7.Text = "TO";
            this.metroLabel7.Click += new System.EventHandler(this.metroLabel3_Click);
            // 
            // FacultyScheduleUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.submitBox);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.dayComboBox);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.addBox);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "FacultyScheduleUC";
            this.Size = new System.Drawing.Size(399, 556);
            this.UseStyleColors = true;
            ((System.ComponentModel.ISupportInitialize)(this.submitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.PictureBox addBox;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private MetroFramework.Controls.MetroComboBox dayComboBox;
        private MetroFramework.Controls.MetroDateTime startDatePicker;
        private MetroFramework.Controls.MetroDateTime endDatePicker;
        private System.Windows.Forms.PictureBox submitBox;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
    }
}
