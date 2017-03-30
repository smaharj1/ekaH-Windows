using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekaH_Windows.Model
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();

            executeGet();
        }

        private void executeGet()
        {
            HttpClient client = NetworkClient.getInstance().getHttpClient();
            string uri = "ekah/course/CRS-F2016amruth180MR";

            try
            {
                var resp = client.GetAsync(uri).Result;

                if (resp.IsSuccessStatusCode)
                {
                    Course c = resp.Content.ReadAsAsync<Course>().Result;
                }
            }
            catch(Exception ex)
            {
                Console.Write("");
            }
        }
    }
}
