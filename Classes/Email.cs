using Azure.Communication.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlbumMedia.Classes
{
    internal class Email
    {
        public Email(string recipient = null, string subject = null, string htmlContent = null) 
        {
            Subject = subject;
            HtmlContent = htmlContent;
            Recipient = recipient;
        }

        private EmailClient Client;
        private string Sender = Properties.Settings.Default.EMAIL_ADDRESS;
        public string Subject;
        public string HtmlContent;
        public string Recipient;


        /// <summary>
        /// connects to the API
        /// </summary>
        private void Connect()
        {
            Client = new EmailClient(Properties.Settings.Default.EMAIL_CONNECTION_STRING);
        }

        /// <summary>
        /// sends the email
        /// </summary>
        public async void Send()
        {
            Connect();

            await Client.SendAsync(Azure.WaitUntil.Completed, Sender, Recipient, Subject, HtmlContent);
        }
    }
}
