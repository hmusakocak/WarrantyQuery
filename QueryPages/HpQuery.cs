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
    public partial class HpQuery : MetroForm
    {
        public HpQuery()
        {
            InitializeComponent();
        }

        private void HpQuery_Load(object sender, EventArgs e)
        {
            WaitSequence waitSequence = new WaitSequence();
            waitSequence.Show();

            try
            {
                var HP = HPFunctions.HPInformation(App.serialnumber);
                metroTextBox1.Text = HP.Model.ToString();
                metroTextBox5.Text = HP.Status.ToString();
                metroTextBox3.Text = HP.WarranyStartDate.ToString();
                metroTextBox4.Text = HP.WarrantyEndDate.ToString();
                metroTextBox2.Text = HP.WarrantyType.ToString();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            waitSequence.Close();
        }
    }
}
