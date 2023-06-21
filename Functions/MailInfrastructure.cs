using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using EASendMail;

namespace WarrantyQuery.Functions
{
    public class MailInfrastructure
    {
        string email;
        string verification_code;

        public MailInfrastructure(string _mail, string _verificationcode)
        {
            email = _mail;
            verification_code = _verificationcode;
        }

        public void SendMail()
        {
            SmtpMail oMail = new SmtpMail("TryIt");

            oMail.From = "Warranty App Verification";
            oMail.To = email;

            oMail.Subject = "Verification Code";

            oMail.TextBody = verification_code;

            SmtpServer oServer = new SmtpServer("smtp.gmail.com");

            oServer.User = "warrantyquery@gmail.com";

            oServer.Password = "hpwxymaokcycvsar";


            oServer.Port = 465;

            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
            oSmtp.SendMail(oServer, oMail);

        }
    }
}
