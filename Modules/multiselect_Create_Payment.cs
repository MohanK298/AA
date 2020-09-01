/*
 * Created by Ranorex
 * User: qa
 * Date: 8/5/2020
 * Time: 3:08 PM
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
using SmokeTest.Repositories;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of multiselect_Create_Payment.
    /// </summary>
    [TestModule("BF31B1B0-3B36-4217-90E7-AF73F4708C65", ModuleType.UserCode, 1)]
    public class multiselect_Create_Payment : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public multiselect_Create_Payment()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        BillingClient bclient=BillingClient.Instance;
        BillingFile file = BillingFile.Instance;
        FirmSettings frm=FirmSettings.Instance;
        Bill bill = Bill.Instance;
        BillingTE te = BillingTE.Instance;
        People people=People.Instance;
        Outlook_AddIn outlook=Outlook_AddIn.Instance;
        
        Common cmn=new Common();
        
    	string fileName="File-PaymentReq_"+System.DateTime.Now.ToString();
        
    	string outlookPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\OUTLOOK.EXE";
    	int mailcount1,mailcount2=0;
    	private void OpenApp()
        {
        	Host.Local.RunApplication(outlookPath);
        	Delay.Seconds(5);
        	outlook.OutlookSplash.SelfInfo.WaitForNotExists(60000);
        	
        }
    	
    	
    	private void validateOutlookDraft()
    	{
    		OpenApp();
    		
    		if(outlook.Outlook.TreeItemGmailInfo.Exists(3000))
        	{
        		outlook.Outlook.TreeItemGmail.DoubleClick();
        	}
        	if(outlook.Outlook.MailFolders.DraftsInfo.Exists(3000))
        	{
        		outlook.Outlook.MailFolders.Drafts.Click();
        		Report.Success("Drafts Folders is opened successfully");
    		
    		
    	    }
    	}
    	
    	
    		
    		
    	
    	
    	private void create_PaymentReqeust()
    	{
    		int rowCount=0;
    		
    		int rndNumber=0;
    		Random rnd = new Random();
    		validateOutlookDraft();
    		mailcount1=cmn.getEmailCountFromSelectedFolder(outlook.Outlook.mailPanel);
    		outlook.Outlook.Self.Close();
    		//string clientName=clientid+"/"+matterid;
    		bill.MainForm.Self.Activate();
    		bill.MainForm.BILLING.Click();
    		bill.MainForm.btnBilling.Click();
    		//Report.Success("Sample-----"+clientName);
    		rowCount=cmn.GetTableRowCount(bill.MainForm.tblBilling,"Billing Table");
    		Report.Success("Total Row Count-----"+rowCount.ToString());
    		for(int i=0;i<3;i++)
    		{
    			rndNumber=rnd.Next(rowCount);
    		
    			
    		
    		bill.rowNo=(rndNumber).ToString();
    		Delay.Milliseconds(500);
    		Report.Success("Row Number Selected is -----"+rndNumber.ToString());
    		if(!bill.MainForm.cbRowSelect.Checked)
        	{
        		bill.MainForm.cbRowSelect.Click();
        		Delay.Seconds(1);
        		bill.MainForm.cbRowSelect.Click();
        		Delay.Seconds(1);
        		bill.MainForm.cbRowSelect.Click();
        	}
        	else
        	{
        		bill.MainForm.cbRowSelect.Click();
        		Delay.Seconds(1);
        		bill.MainForm.cbRowSelect.Click();
        	}
        	
    		}
    		
    		if(bill.MainForm.Toolbar.btnAddPaymentRequestInfo.Exists(10000))
    		{
    			Report.Success("Add Payment Request Button is seen as expected for Bill.");
    			bill.MainForm.Toolbar.btnAddPaymentRequest.Click();
    			Report.Success("Add Payment Request Button is clicked.");
    		}
    		else
    		{
    			Report.Failure("Add Payment Request Button is not seen as expected for Bill without Payment Request Set");
    		}
    		
    		if(bill.PromptForm.SelfInfo.Exists(15000))
 			{
 				Report.Success(String.Format("Prompt form displayed is: {0}",file.PromptForm.txtMessage.GetAttributeValue<String>("Text")));
 				bill.PromptForm.btnOk.Click();
 			}
    		
    		validateOutlookDraft();
    		mailcount2=cmn.getEmailCountFromSelectedFolder(outlook.Outlook.mailPanel);
    		outlook.Outlook.DraftsFirstMail.Click();
    		Keyboard.Press("{ControlKey down}{AKey}{ControlKey up}");
        	Keyboard.Press("{Delete}");
        	Report.Success("All Draft Mails deleted.");
    		outlook.Outlook.Self.Close();
    		Report.Info("Before Adding ~~"+mailcount1);
    		Report.Info("After Adding ~~"+mailcount2);
    		
    		if(mailcount2>=mailcount1)
    		{
    			Report.Success("Multi Select of Create Payment Request is successfull for "+(mailcount2-mailcount1).ToString()+" bills");
    		}
    		else
    		{
    			Report.Failure("Multi Select Create Payment Request cannot be processed");
    		}
    		
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
            cmn.ClosePrompt();
            create_PaymentReqeust();
            cmn.ClosePrompt();
        }
    }
}
