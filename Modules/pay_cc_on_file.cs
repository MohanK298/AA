/*
 * Created by Ranorex
 * User: qa
 * Date: 7/6/2020
 * Time: 4:54 PM
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

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of pay_cc_on_file.
    /// </summary>
    [TestModule("F5CB1B5C-B389-4EE8-A48F-D3E9DB454264", ModuleType.UserCode, 1)]
    public class pay_cc_on_file : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public pay_cc_on_file()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        Common cmn=new Common();
        BillingClient bclient=BillingClient.Instance;
        BillingFile file = BillingFile.Instance;
        FirmSettings frm=FirmSettings.Instance;
        BillingTE te = BillingTE.Instance;
        Bill bill = Bill.Instance;
        People people = People.Instance;
        string txtmsg="The amount on Credit Card Payment (APX) and ACH Payment (APX) must be positive.";
        string paymsg="A charge for $1.00 will now be run on the Visa card ending in 4747 belonging to Client PortalUser1."+Environment.NewLine+Environment.NewLine+"Do you want to proceed?";
        string payDone="Payment Processed"+Environment.NewLine+Environment.NewLine+"Successful credit card transaction for $1.00.";
        string fileName="Ranorex_General_Retainment_"+System.DateTime.Now.ToString();
        private void payCC()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.imgReceivePayment.Click();
        	if(bill.ReceivePaymentForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Receive Payment Window Form is displayed successfully.");
        		
        		bill.ReceivePaymentForm.PnlBase.rdoFile.Click();
        		Report.Success("File Radio Button is selected successfully.");
        		bill.ReceivePaymentForm.btnSelectFile.Click();
        		
        		if(bill.FileSelectForm.SelfInfo.Exists(3000))
        		{
        			bill.FileSelectForm.btnQuickFindFile.Click();
        			
        			if(bill.FindFilesForm.SelfInfo.Exists(3000))
        			{
        				bill.FindFilesForm.searchTextInput.PressKeys(fileName);
        				
        				bill.FindFilesForm.btnOK.Click();
        			}
        			Delay.Milliseconds(1300);
        			bill.FileSelectForm.listFirstFound.DoubleClick();
        		}

//				if(bill.PeopleSelectForm.SelfInfo.Exists(3000))
//				{
//					bill.PeopleSelectForm.listFirstFound.DoubleClick();
//					Report.Success("First Client Selected selected successfully.");
//				}
//        		
        		bill.ReceivePaymentForm.cmbbxType.Click();
        		bill.lstdpdwnType="Credit Card Payment (APX)";
        		Delay.Milliseconds(300);
        		bill.listDropdwn.Self.Click();
        		
        		cmn.PrintTableData(bill.ReceivePaymentForm.PnlBase.tblRecvPayment,"Receive Payment Table");
        		
        		bill.ReceivePaymentForm.btnPayNow.Click();
        		
        	   if(bill.PromptForm.SelfInfo.Exists(3000))
               {
                   	
               	Validate.AttributeContains(bill.PromptForm.txtMsgPromptInfo,"Text",txtmsg,String.Format("Prompt Message {0} is displayed successfully",txtmsg));
               	people.PromptForm.btnYes.Click();
						                   	
               }
        	}
//				cmn.SelectItemFromTableSingleClick(bill.ReceivePaymentForm.PnlBase.tblRecvPayment,"Details","Receive Payment Table");
//        		}
//        		
//        		if(bill.TrustARBillDistributionForm.SelfInfo.Exists(3000))
//        		{
//        			Report.Success("Payment Distribution form is displayed successfully ");
//        			cmn.PrintTableData(bill.TrustARBillDistributionForm.tblBillDistribution,"Payment Distribution Table");
//        			bill.TrustARBillDistributionForm.Toolbar1.btnOK.Click();
//        			
//        			
//        		}
        		
        		bill.ReceivePaymentForm.txtAmount.PressKeys("1.00");
        		Report.Success("$1.00 added to the Amount Field");
 				bill.ReceivePaymentForm.btnPayNow.Click();
				if(bill.PromptForm.SelfInfo.Exists(3000))
               {
                   	
               	Validate.AttributeContains(bill.PromptForm.txtMsgPromptInfo,"Text",paymsg,String.Format("Prompt Message {0} is displayed successfully",paymsg));
               	people.PromptForm.btnYes.Click();
						                   	
               }   		

				if(bill.PromptForm.SelfInfo.Exists(10000))
               {
                   	
               	Validate.AttributeContains(bill.PromptForm.txtMsgPromptInfo,"Text",payDone,String.Format("Prompt Message {0} is displayed successfully",payDone));
               	bill.PromptForm.btnOk.Click();
						                   	
               }  				

 				
        	}        	   
        
        
        private void AddFile()
    	{
    		bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	
        	
        	
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.btnNewFile.Click();
        	
        	if(file.PromptForm.SelfInfo.Exists(3000))
        	   {
        	   	file.PromptForm.btnNo.Click();
        	   }
        	
        	//Type the file name and other variables
        	file.NewFileForm.txtFileName.TextValue = fileName;
        	file.NewFileForm.btnAddContact.Click();

        	file.PeopleSelectForm.listFirstValue.Click();
        	file.PeopleSelectForm.btnAddToRight.Click();
        	file.PeopleSelectForm.btnOK.Click();
        	
        	
        	file.NewFileForm.btnSaveOpen.Click();
        	
        	
        	
        	
        	file.FileDetailForm.btnSaveClose.Click();
        	Report.Success("File Created successfully.");
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
            AddFile();
            payCC();
        }
    }
}
