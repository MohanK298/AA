/*
 * Created by Qiao
 * User: Administrator
 * Date: 10/24/2018
 * Time: 5:36 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using System.Net.Mail;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of CheckEmailFromClient.
    /// </summary>
    [TestModule("8952C28B-41C4-43F6-BE9E-4BE6ECED5954", ModuleType.UserCode, 1)]
    public class CheckEmailFromClient : ITestModule
    {   
    	Communications te = Communications.Instance;
    	Duration customWaitTime = new Duration(3000);
    	
    /*	string _fromEmail = "qchenabacus@gmail.com";
    	[TestVariable("65300df3-b400-4e9f-9a3c-aa7fd1c0eb3e")]
    	public string fromEmail
    	{
    		get { return _fromEmail; }
    		set { _fromEmail = value; }
    	}
    	
    	string _fromEmailPassword = "Bluejays2018!";
    	[TestVariable("e3dd021f-84ea-4137-9825-37ba7657b155")]
    	public string fromEmailPassword
    	{
    		get { return _fromEmailPassword; }
    		set { _fromEmailPassword = value; }
    	}
    	
    	string _toEmail = "qchenabacus@outlook.com";
    	[TestVariable("712e1ca9-c3d3-4361-ae6e-519b445e1646")]
    	public string toEmail
    	{
    		get { return _toEmail; }
    		set { _toEmail = value; }
    	}
    	
    	string _emailSubject = "Test Email from Ranorex";
    	[TestVariable("fb8d7390-fd10-44fe-b158-bf7d37c7fc46")]
    	public string emailSubject
    	{
    		get { return _emailSubject; }
    		set { _emailSubject = value; }
    	}
    	
    	string _time = System.DateTime.Now.ToString();
    	[TestVariable("288e38ea-4aa5-4851-bf53-a818daa1d7ad")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
   	}
   	*/
    	
    	/// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CheckEmailFromClient()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        public void SendEmailFromAAtoClient()
        {
        	te.MainForm.btnCommunications.Click();
        	te.MainForm.newItemDropDownInfo.WaitForAttributeContains(customWaitTime, "Visible", true);
//        	te.MainForm.newItemDropDown.Click();
			te.MainForm.newItemDropDown.Select();
			Delay.Seconds(2);
			te.AmicusAttorneyXWin.MenuPopupInfo.WaitForAttributeContains(customWaitTime, "Visible", true);
//			Delay.Seconds(2);
        	te.MainForm.newEmail.Select();
//        	Delay.Seconds(5);
//        	Validate.Exists(te.NewEmailForm.BasePath);
//        	te.NewEmailForm.SelfInfo.WaitForAttributeContains(customWaitTime, "Visible", true);
        }
        
        public void SendEmailFromClientToAA()
        {
        	var emailSendTime = System.DateTime.Now;
        	NewHeadlessEmail("qchenabacus@gmail.com", "Bluejays2018!", "qchenabacus@outlook.com", "Ranoex Test Email from G to OL" + emailSendTime, "Just a test email using c sharp");
 	
        	te.MainForm.btnCommunications.Click();
        	te.MainForm.btnSyncNowInfo.WaitForAttributeContains(customWaitTime, "Visible", true);
        	Delay.Seconds(60);
        	te.MainForm.btnSyncNow.Click();
        	Delay.Seconds(customWaitTime);
        	Validate.AttributeContains(te.MainForm.EmailOnTopOfTheList.subjectInfo, "UIAutomationValueValue", "Ranoex Test Email from G to OL" + emailSendTime);
        	
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
                        
//            SmokeTest.Modules.SendMailModule sendMail = new SendMailModule();
//            NewHeadlessEmail("qchenabacus@gmail.com", "Bluejays2018!", "qchenabacus@outlook.com", "Test Email from G to OL", "Just a test email using c sharp");
            
//            SendEmailFromAAtoClient();
            SendEmailFromClientToAA();
        }
        
        void NewHeadlessEmail(string fromEmail, string password, string toAddress, string subject, string body)
        {
        	//In order to use Gmail account to send, need to set the Gmail account has less secure access enabled,refer to Google Official doc.
            using (System.Net.Mail.MailMessage myMail = new System.Net.Mail.MailMessage())
            {
                myMail.From = new MailAddress(fromEmail);
                myMail.To.Add(toAddress);
                myMail.Subject = subject;
                myMail.IsBodyHtml = true;
                myMail.Body = body;

                using (System.Net.Mail.SmtpClient s = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    s.DeliveryMethod = SmtpDeliveryMethod.Network;
                    s.UseDefaultCredentials = false;
                    s.Credentials = new System.Net.NetworkCredential(myMail.From.ToString(), password);
                    s.EnableSsl = true;
                    s.Send(myMail);
                }
            }
        }
        
    }
}
