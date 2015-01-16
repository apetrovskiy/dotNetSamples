/*
 * Created by SharpDevelop.
 * User: alexa_000
 * Date: 1/16/2015
 * Time: 3:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net.Mail;

namespace testSendingMailWithAmpersands
{
    class Program
    {
        public static void Main(string[] args)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("172.28.8.141@netwrix.com");
            // var NewMail = new MailAddress("netwrix.r&d.spb.qc.at.msi@netwrix.com");
            // var NewMail = new MailAddress("netwrix.r&d.spb.qc.at.suite@netwrix.com");
            // var NewMail = new MailAddress("netwrix.rnd.spb.qc.at.msi@netwrix.com");
            var NewMail = new MailAddress("netwrix.rnd.spb.qc.at.suite@netwrix.com");
            mail.To.Add(NewMail);
            mail.Subject = "Autotest report. MSI Checker. 333";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            /*
            StreamReader reader = new StreamReader(path);
            mail.IsBodyHtml = true;
            mail.Body = reader.ReadToEnd();
            Attachment attach = new Attachment(path2);
            mail.Attachments.Add(attach);
            Attachment attach2 = new Attachment(path3);
            mail.Attachments.Add(attach2);
            */
            var client = new System.Net.Mail.SmtpClient();
            client.Port = 25;
            client.UseDefaultCredentials = false; 
            client.Host = "mail.netwrix.com";
            client.Send(mail);
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}