using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Model
{
    class Worker
    {
        public static void printServerError(IWin32Window window)
        {
            MetroMessageBox.Show(window, "Server might be shut down right now!", "Server down!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
