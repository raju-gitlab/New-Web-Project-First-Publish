using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WP.Tools.Utilities.EmailSender
{
    public class EmailSender
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EmailSender() {}
        /// <summary>
        /// Send Email TO Customer
        /// </summary>
        /// <param name="ToEmail"></param>
        /// <param name="MessegeBody"></param>
        /// <param name="MailSubject"></param>
        public int emailSender(string ToEmail ,string OrderId)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("rajubasakcoc10@gmail.com");
            mail.To.Add(ToEmail);
            mail.Subject = "Order Confirmation";

            mail.IsBodyHtml = true;
            string htmlBody;

            htmlBody = "Your Order is Confirmed Successfully With OrderId" + OrderId;
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("rajubasakcoc10@gmail.com", "5432167890r");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return 0;
        }
    }
}
