using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using WP.Tools.Utilities.File_Reader;

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
        public static int GenericEmail(string ToEmail ,string OrderId , string EmailSubject)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("rajubasakcoc10@gmail.com");
                mail.To.Add(ToEmail);
                mail.Subject = EmailSubject;
                mail.IsBodyHtml = true;
                string htmlBody;
                htmlBody = StreamReader.ReadTextFile("ForgetPasswordText");
                mail.Body = htmlBody;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("rajubasakcoc10@gmail.com", "5432167890r");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception ("Error",ex);
            }
        }

        public static int SendForgetPasswordEmail(string ToEmail, string EmailSubject , string VerificationCode)
        {
            MailMessage mail;//= new MailMessage();
            mail = new MailMessage();
            string SenderEmail = null;
            SmtpClient SmtpServer;//= new SmtpClient("smtp.gmail.com");
            SenderEmail = ConfigurationManager.AppSettings["EmailSenderEmail"].ToString();
            string SenderEmailPassword = ConfigurationManager.AppSettings["EmailSenderPassword"].ToString();
            //string Port = ConfigurationManager.AppSettings["EmailSenderPassword"].ToString();
            SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SMTPAddress"].ToString());
            SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"].ToString());
            mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailSenderEmail"].ToString());
            mail.To.Add(new MailAddress(ToEmail));
            SmtpServer.Credentials = new NetworkCredential(SenderEmail, SenderEmailPassword);
            SmtpServer.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"].ToString());
            mail.IsBodyHtml = true;
            string htmlBody;
            switch(EmailSubject)
            {
                case "ForgetEmail": mail.Subject = "Forget Password"; break;
                case "ChangePasswordSuccessfully": mail.Subject = "Password Changed Successfully."; break;
                case "NewLoginRemainder": mail.Subject = "new Device Login"; break;
                case "NewRegistration": mail.Subject = "New Registration"; break;
                default: mail.Subject = "Please Verify Your Email Address"; break;
            }
            var TextMsg = string.Empty;
            var FilePath = string.Empty;
            if(EmailSubject == "ForgetEmail")
            {
                htmlBody = StreamReader.ReadTextFile("ForgetPasswordText").ToString();
                mail.Body = htmlBody;
            }
            else if(EmailSubject == "ChangePasswordSuccessfully")
            {
                htmlBody = StreamReader.ReadTextFile("");
                mail.Body = htmlBody;
            }
            else if(EmailSubject == "NewLoginRemainder")
            {
                htmlBody = StreamReader.ReadTextFile("");
                mail.Body = htmlBody;
            }
            else if(EmailSubject == "NewRegistration")
            {
                htmlBody = StreamReader.ReadTextFile("");
                mail.Body = htmlBody;
            }
            else
            {
                htmlBody = StreamReader.ReadTextFile("");
                mail.Body = htmlBody;
            }
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

        public static int BookingConfirmationEmail(string ToEmail, string EmailSubject, string VerificationCode)
        {
            try
            {
                MailMessage mail;//= new MailMessage();
                mail = new MailMessage();
                string SenderEmail = null;
                SmtpClient SmtpServer;//= new SmtpClient("smtp.gmail.com");
                SenderEmail = ConfigurationManager.AppSettings["EmailSenderEmail"].ToString();
                string SenderEmailPassword = ConfigurationManager.AppSettings["EmailSenderPassword"].ToString();
                //string Port = ConfigurationManager.AppSettings["EmailSenderPassword"].ToString();
                SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["SMTPAddress"].ToString());
                SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"].ToString());
                mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailSenderEmail"].ToString());
                mail.To.Add(new MailAddress(ToEmail));
                SmtpServer.Credentials = new NetworkCredential(SenderEmail, SenderEmailPassword);
                SmtpServer.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"].ToString());
                mail.Subject = "Password Changed Successfully";

                mail.IsBodyHtml = true;
                string htmlBody;

                htmlBody = "You Want To change Your password For your" + ToEmail + "Account" + "Please reset your password by clicking <a href= \"http://localhost:54248/api/ChangePassword?VerificationCode=" + VerificationCode + "&Email=" + ToEmail + "\">Click Here</a>";
                mail.Body = htmlBody;

                SmtpServer.Send(mail);
                return 0;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
