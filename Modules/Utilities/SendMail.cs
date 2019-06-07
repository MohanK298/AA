/*
 * Created by Ranorex
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Net.Mail;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Use this module at any position of your test suite to get informed about test runs by email. 
    /// This is especially useful for overnight test executions on runtime machines.
    /// </summary>
    [TestModule("EEE7C8D8-D950-40EF-B24A-1A9A87C0DA21", ModuleType.UserCode, 1)]
    public class SendMailModule : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendMailModule()
        {
            // Do not delete - a parameterless constructor is required!
        }

        #region Variables

        string _to = "";
        
        [TestVariable("D089186D-7919-4023-8165-B68F9151C6A7")]
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
        
        string _from = "";
        
        [TestVariable("BDB3FC8C-1E51-448F-9049-AEF0B247DBDB")]
        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        string _subject = "Ranorex Module Report";

        [TestVariable("398FF772-C15C-4b91-954B-34CC636DEDC9")]
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        
        string _serverHostName = "";
        
        [TestVariable("0EE4CB1E-D738-4DE8-B122-92B3CCE6F70C")]
        public string ServerHostname
        {
            get { return _serverHostName; }
            set { _serverHostName = value; }
        }
        
        string _serverPort = "587";
        
        [TestVariable("4C6A889D-BACE-4AE1-9EEF-40EA26775574")]
        public string ServerPort
        {
            get { return _serverPort; }
            set { _serverPort = value; }
        }
        
        string _message = "Default Value";
        
        [TestVariable("D49672F4-3021-4460-96DA-2EC11AE318A8")]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        #endregion
        
        void ITestModule.Run()
        {
            SendMail();
        }

        void SendMail()
        {
            try
            {
                MailMessage mail = new MailMessage(From, To, Subject, Message);
                
                SmtpClient smtp = new SmtpClient(ServerHostname, int.Parse(ServerPort));
                smtp.Send(mail);
                
                Report.Success("Email has been sent to '" + To + "'.");
            }
            catch(Exception ex)
            {
                Report.Failure("Mail Error: " + ex.ToString());
            }
        }
    }
}
