using ekaH_Windows.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace ekaH_Windows.Profiles.Forms.Student
{
    public partial class CourseAdd : MetroFramework.Forms.MetroForm
    {
        private int tempX = 10;
        private int tempY = 10;

        public CourseAdd()
        {
            InitializeComponent();

        }

        public void courseTileClicked(object sender, EventArgs e)
        {
            MetroTile tile = (MetroTile)sender;
            Course c = (Course)tile.Tag;

            MessageBox.Show(c.CourseName);
        }

        private MetroTile makeTile(Course course, int x, int y)
        {
            MetroTile newTile = new MetroTile();
            string display = course.CourseName + "        " + course.Days + "        " + course.ProfessorID;
            newTile.Text = display;
            newTile.Location = new Point(x, y);
            newTile.Tag = course;
            newTile.Click += new EventHandler(courseTileClicked);
            newTile.Size = new Size(resultPanel.Width-20, 80);

            return newTile;

        }

        
        private void courseIDText_KeyDown(object sender, KeyEventArgs e)
        {
            //searchTextBox.Enabled = false;
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //courseIDText.Enabled = false;
        }

        // This is the search tile
        private void metroTile1_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            c.CourseName = "AI";
            c.Days = "TF";
            c.ProfessorID = "vmiller@ramapo.edu";
            MetroTile received = makeTile(c, tempX, tempY);
            resultPanel.Controls.Add(received);

            tempY += 90;
        }
    }
}
