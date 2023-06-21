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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.DevTools.V109.Audits;
using WarrantyQuery.Functions;

namespace WarrantyQuery.QueryPages
{
    public partial class AsusQuery : MetroForm
    {
        public AsusQuery()
        {
            InitializeComponent();
        }

        private void AsusQuery_Load(object sender, EventArgs e)
        {
            WaitSequence waitSequence = new WaitSequence();
            waitSequence.Show();

            try
            {
                var Asus = AsusFunctions.AsusInformation(App.serialnumber);
                metroTextBox1.Text = Asus.Model.ToString().Substring(Asus.Model.ToString().IndexOf(":")+2);
                metroTextBox2.Text = Asus.Distributor.ToString().Substring(Asus.Distributor.ToString().IndexOf("::")+2);
                metroTextBox3.Text = Asus.WarranyStartDate.ToString().Substring(Asus.WarranyStartDate.ToString().IndexOf("::") + 2);
                metroTextBox4.Text = Asus.WarrantyEndDate.ToString().Substring(Asus.WarrantyEndDate.ToString().IndexOf("::") + 2);
                metroTextBox5.Text = Asus.WarrantyExtension.ToString().Substring(Asus.WarrantyExtension.ToString().IndexOf(":")+1);                               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            waitSequence.Close();

        }
    }
}
