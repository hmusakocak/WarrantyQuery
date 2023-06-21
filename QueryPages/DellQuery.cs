using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarrantyQuery.Functions;

namespace WarrantyQuery.QueryPages
{
    public partial class DellQuery : MetroForm
    {
        public DellQuery()
        {
            InitializeComponent();
        }

        private void DellQuery_Load(object sender, EventArgs e)
        {
            WaitSequence waitSequence = new WaitSequence();
            waitSequence.Show();

            try
            {
                var Dell = DellFunctions.DellInformation(App.serialnumber);
                metroTextBox1.Text = Dell.Model.ToString();
                metroTextBox4.Text = Dell.WarrantyEndDate.ToString();
                metroTextBox6.Text = Dell.ExpressServiceCode.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            waitSequence.Close();
        }
    }
}
