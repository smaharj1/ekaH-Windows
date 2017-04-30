using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Model
{
    /// <summary>
    /// This is a general class which prints the server error.
    /// </summary>
    class Worker
    {
        /// <summary>
        /// This function prints the server's error message for the given window.
        /// </summary>
        /// <param name="a_window">It holds the window in which the error occured.</param>
        public static void printServerError(IWin32Window a_window)
        {
            MetroMessageBox.Show(a_window, "Server might be shut down right now!", "Server down!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
