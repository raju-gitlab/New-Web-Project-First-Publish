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
        //public EmailSender() {}
        /// <summary>
        /// Send Email TO Customer
        /// </summary>
        /// <param name="ToEmail"></param>
        /// <param name="MessegeBody"></param>
        /// <param name="MailSubject"></param>
        public static int GenericEmail(string ToEmail ,string OrderId , string EmailSubject,string HTMLBody)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("rajubasakcoc10@gmail.com");
            mail.To.Add(ToEmail);
            mail.Subject = EmailSubject;
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = HTMLBody;
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("rajubasakcoc10@gmail.com", "5432167890r");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return 0;
        }

        public static int SendForgetPasswordEmail(string ToEmail, string EmailSubject , string VerificationCode)
        {                
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("rajubasakcoc10@gmail.com");
            mail.To.Add(ToEmail);
            mail.Subject = EmailSubject;
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = "You Want To change Your password For your" + ToEmail + "Account" + "Please reset your password by clicking <a href= \"http://localhost:54248/api/ChangePassword?VerificationCode=" + VerificationCode + "&Email=" + ToEmail + "\">Click Here</a>";
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("rajubasakcoc10@gmail.com", "5432167890r");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return 0;
        }

        public static int NewUser(string ToEmail, string UserName, string EmailSubject, string HTMLBody)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("rajubasakcoc10@gmail.com");
            mail.To.Add(ToEmail);
            mail.Subject = EmailSubject;
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = HTMLBody;
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("rajubasakcoc10@gmail.com", "5432167890r");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return 0;
        }
        public static int SendNotificationEmail(DateTimeOffset Date , string Email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("rajubasakcoc10@gmail.com");
            mail.To.Add(Email);
            mail.Subject = "Password Changed Successfully";

            mail.IsBodyHtml = true;
            string htmlBody;

            htmlBody = "Your Account " + Email + "  Password is Successfully Changed At" + Date;
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("rajubasakcoc10@gmail.com", "5432167890r");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return 0;
        }
    }
}
