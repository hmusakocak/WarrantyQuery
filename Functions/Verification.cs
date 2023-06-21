using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WarrantyQuery.Functions
{
    public class Verification
    {
        public static string Generate()
        {
            string key = "";
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                var digit = rand.Next(0, 9);
                key = key + digit;
            }
            return key;
        }

        public static bool CodeControl(string _entry,string code)
        {

            if (_entry == code)
            {
                return true;
            }
            else 
            {
                return false; 
            }
        }
    }
}
