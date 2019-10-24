/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-22
 * Time: 11:33 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using Microsoft.Exchange.WebServices.Data;
using System.Configuration;
namespace SmokeTest
{
    /// <summary>
    /// Description of createApptWithEmailAlert.
    /// </summary>
    [TestModule("4BE38324-EAC6-4D99-A2B1-718844EEAD53", ModuleType.UserCode, 1)]
    public class createApptWithEmailAlert : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public createApptWithEmailAlert()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        private void ConnectToExchangeServer()
        {
        	ExchangeService ex=null;
        	ex=new ExchangeService(ExchangeVersion.Exchange2013);
        	ex.Credentials=new WebCredentials("MMargasagayam","Toronto2019!!!!","abacuscorp");
        	ex.TraceEnabled=true;
        	ex.EnableScpLookup = true;
        	//ex.Url=new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
        	
        	ex.AutodiscoverUrl("mmargasagayam@abacusnext.com",SslRedirectionCallback);
        	ex.AutodiscoverUrl("mmargasagayam@abacusnext.com",SslRedirectionCallback);
//        	TimeSpan ts = new TimeSpan(0, -1, 0, 0);  
//            System.DateTime date = System.DateTime.Now.Add(ts);  
//            SearchFilter.IsGreaterThanOrEqualTo filter = new SearchFilter.IsGreaterThanOrEqualTo(ItemSchema.DateTimeReceived, date);  
//  
            if (ex != null)   
            {  
                FindItemsResults < Item > results = ex.FindItems(WellKnownFolderName.Inbox, new ItemView(15));  
  
                foreach(Item item in results)   
                {  
  
                    EmailMessage message = EmailMessage.Bind(ex, item.Id);  
                  //  ListViewItem listitem = new ListViewItem(new[]   
                //    {  
                 //       message.DateTimeReceived.ToString(), message.From.Name.ToString() + "(" + message.From.Address.ToString() + ")", message.Subject, ((message.HasAttachments) ? "Yes" : "No"), message.Id.ToString()  
                  //  });  
                  Report.Info(message.Body.Text);
                  Report.Info(message.From.Id.ToString());
                  Report.Info(message.Subject.ToString());
                }  
                if (results.Items.Count <= 0)   
                {  
                     Report.Info("No Messages found!!");  
  
                }  
            }  
  
        	
        }
         bool SslRedirectionCallback(string serviceUrl)
        {
            // Return true if the URL is an HTTPS URL.
            return serviceUrl.ToLower().StartsWith("https:");
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
             ConnectToExchangeServer();
        }
    }
}
