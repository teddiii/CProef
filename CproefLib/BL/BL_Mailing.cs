using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CproefLib.BL
{
    /// <summary>
    /// For handling mailing messages
    /// </summary>
    public class BL_Mailing
    {
        /// <summary>
        /// Basic mailing with hard coded parameters
        /// </summary>
        public static void SendMail(string firstname, string lastname, string email, string username)
        {
            string subject = "Your credentials for Login in";
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Dear {firstname} {lastname}");
            message.AppendLine("");
            message.AppendLine("Here are your new credentials for the application. It's possible you automatically will be forwarded to your account page.");
            message.AppendLine($"User name: {username}");
            message.AppendLine("");
            message.AppendLine("Kind regard");
            message.AppendLine("Your administrator");

            var fromAddress = new MailAddress("aeneas_brutseart@live.be", "Cproef");
            var toAddress = new MailAddress(email, firstname + " " + lastname);
            const string fromPassword = "cproef";

            var smtp = new SmtpClient
            {
                Host = "smtp.live.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var Newmessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = message.ToString()
            })
            {
                smtp.Send(Newmessage);
            }
        }
    }
}
