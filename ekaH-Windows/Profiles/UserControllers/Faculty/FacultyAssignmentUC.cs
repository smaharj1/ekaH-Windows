using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ekaH_Windows.Model;
using System.IO;

namespace ekaH_Windows.Profiles.UserControllers.Faculty
{
    public partial class FacultyAssignmentUC : MetroFramework.Controls.MetroUserControl
    {
        private Color BUTTON_PRESSED = ColorTranslator.FromHtml("#E8B71A");
        private Color BUTTON_RELEASED = ColorTranslator.FromHtml("#F7EAC8");

        private List<Assignment> openAssignments;
        private Assignment currentAssgn;
        private Font preferredFont;
        private Color preferredForeColor;

        public FacultyAssignmentUC()
        {
            openAssignments = new List<Assignment>();
            InitializeComponent();

            preferredFont = assignmentRTB.Font;
            preferredForeColor = Color.Black;
        }

        /// <summary>
        /// Opens the assignment clicked by the professor and gives the details.
        /// </summary>
        /// <param name="assgn"></param>
        public void open(Assignment assgn)
        {
            /// Checks if the assignment was previously open to reduce the number of UC objects being formed.
            if (openAssignments.Contains(assgn))
            {
                int index = openAssignments.IndexOf(assgn);
                currentAssgn = openAssignments[index];

            }
            else
            {
                openAssignments.Add(assgn);
                currentAssgn = assgn;
            }

            updateView();
        }

        private void updateView()
        {
            projectName.Text = currentAssgn.projectTitle;
            
            // For now, just do the content.
            assignmentRTB.Text = currentAssgn.content;

        }

        private void editBox_Click(object sender, EventArgs e)
        {
            setButtonsVisibility(true);
        }

        private void setButtonsVisibility(bool given)
        {
            assignmentRTB.Enabled = given;
            saveBox.Visible = given;
            fontBox.Visible = given;
            fontPanel.Visible = given;
        }

        private void saveBox_Click(object sender, EventArgs e)
        {
            setButtonsVisibility(false);

            // Make put call to the database.
        }


        /// <summary>
        /// Shows the dialog to change the font.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Set the font
                setFont(fontDialog1.Font, preferredForeColor);
            }
        }

        private void fixFontUI(Font font, Color fore)
        {
            boldButton.BackColor = font.Bold ? BUTTON_PRESSED : BUTTON_RELEASED;
            italicButton.BackColor = font.Italic ? BUTTON_PRESSED : BUTTON_RELEASED;
            underlineButton.BackColor = font.Underline ? BUTTON_PRESSED : BUTTON_RELEASED;
            colorButton.BackColor = fore;
        }

        private void setFont(Font font, Color fore)
        {
            preferredFont = fontDialog1.Font;
            assignmentRTB.SelectionFont = preferredFont;

            preferredForeColor = fore;
            assignmentRTB.SelectionColor = fore;

            fixFontUI(preferredFont, preferredForeColor);
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();

            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                setFont(preferredFont, colorDialog1.Color);
            }
        }
    }
}
