using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarrantyQuery.Functions;
using WarrantyQuery.QueryPages;

namespace WarrantyQuery
{
    public partial class App : MetroForm
    {
        public App()
        {
            InitializeComponent();
        }

        private void App_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public static string serialnumber;

        private void metroLink1_Click(object sender, EventArgs e)
        {
            HowtoFindSerial howtoFindSerial = new HowtoFindSerial();
            howtoFindSerial.Show();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            serialnumber = metroTextBox1.Text;
            AsusQuery asusQuery = new AsusQuery();
            asusQuery.Show();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            serialnumber = metroTextBox1.Text;
            LenovoQuery lenovoQuery = new LenovoQuery();
            lenovoQuery.Show();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            serialnumber = metroTextBox1.Text; 
            HpQuery hpquery = new HpQuery();
            hpquery.Show();
        }

        string globalcode;
        private void metroTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                var code = Verification.Generate();
                MailInfrastructure mailInfrastructure = new MailInfrastructure(metroTextBox2.Text, code);
                mailInfrastructure.SendMail();
                globalcode = code;
            }
        }

        private void App_Load(object sender, EventArgs e)
        {
            metroTile1.Enabled = true;
            metroTile2.Enabled = true;
            metroTile3.Enabled = true;
        }

        private void metroTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool a = Verification.CodeControl(metroTextBox3.Text,globalcode);

                metroTile1.Enabled = metroTile2.Enabled = metroTile3.Enabled = metroTile4.Enabled = metroTile5.Enabled = a;

                string msg = a ? "Unlocked" : "Locked";

                MessageBox.Show(msg);
            }
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            serialnumber = metroTextBox1.Text;
            DellQuery dellQuery = new DellQuery();
            dellQuery.Show();
        }
    }
}
