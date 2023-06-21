using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarrantyQuery
{
    public partial class Main : MetroForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        short time = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            metroLabel3.Text = time.ToString();
            if(time == 5)
            {
                App app = new App();
                app.Show();
                timer1.Stop();
                this.Close();
            }
        }
    }
}
