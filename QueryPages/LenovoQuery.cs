using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarrantyQuery.Functions;

namespace WarrantyQuery.QueryPages
{
    public partial class LenovoQuery : MetroForm
    {
        public LenovoQuery()
        {
            InitializeComponent();
        }

        private async void LenovoQuery_Load(object sender, EventArgs e)
        {
            var Lenovo = await LenovoFunctions.LenovoPOST(App.serialnumber);
            metroTextBox10.Text = Lenovo.data.currentWarranty.name.ToString();
            metroTextBox9.Text = Lenovo.data.currentWarranty.level.ToString();
            metroTextBox8.Text = Lenovo.data.currentWarranty.startDate.ToString();
            metroTextBox7.Text = Lenovo.data.currentWarranty.endDate.ToString();
            metroTextBox6.Text = Lenovo.data.machineInfo.productName.ToString();
        }
        short time=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time == 3)
            {
                metroProgressSpinner1.Visible = false;
            }
        }
    }
}
