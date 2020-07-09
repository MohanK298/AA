/*
 * Created by Ranorex
 * User: qa
 * Date: 7/6/2020
 * Time: 12:41 PM
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
    /// Description of validateReceivePayment.
    /// </summary>
    [TestModule("7C668657-1F31-46B6-B704-730C4DC1E09C", ModuleType.UserCode, 1)]
    public class validateReceivePayment : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateReceivePayment()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        Common cmn=new Common();
        BillingClient bclient=BillingClient.Instance;
        BillingFile file = BillingFile.Instance;
        FirmSettings frm=FirmSettings.Instance;
        BillingTE te = BillingTE.Instance;
        Bill bill = Bill.Instance;
        string[] methodItems={"Check","Cash","Credit Card Payment (APX)","ACH Payment (APX)","Credit Card (Manual)","Electronic","Other"};
        
        private void validate_ReceivePayment()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.imgReceivePayment.Click();
        	if(bill.ReceivePaymentForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Receive Payment Window Form is displayed successfully.");
        		Validate.AttributeContains(bill.ReceivePaymentForm.PnlBase.cmbxReceiptToInfo,"Text","1 - General (APX Enabled)","Receipt To Dropdown has the value 1 - General (APX Enabled) Selected");
        		Validate.AttributeContains(bill.ReceivePaymentForm.txtDateInfo,"UIAutomationValueValue",System.DateTime.Now.ToString("M/d/yyyy"));
        		//,"Today's Date is set to Default");
        		bill.ReceivePaymentForm.PnlBase.rdoFile.Click();
        		Report.Success("File Radio Button is selected successfully.");
        		bill.ReceivePaymentForm.btnSelectFile.Click();
        		
        		if(bill.FileSelectForm.SelfInfo.Exists(3000))
        		{
        			bill.FileSelectForm.btnQuickFindFile.Click();
        			
        			if(bill.FindFilesForm.SelfInfo.Exists(3000))
        			{
        				bill.FindFilesForm.searchTextInput.PressKeys(System.DateTime.Now.ToShortDateString());
        				
        				bill.FindFilesForm.btnOK.Click();
        			}
        			bill.FileSelectForm.listFirstFound.DoubleClick();
        		}
        		
        		
        		
        		bill.ReceivePaymentForm.cmbbxType.Click();
        		for(int i=0;i<methodItems.Length;i++)
        		{
        			bill.lstdpdwnType=methodItems[i];
        			Delay.Milliseconds(300);
        			Validate.Exists(bill.listDropdwn.SelfInfo,String.Format("Item {0} is present in the Type Dropdown as expected",methodItems[i]));
        			
        		}
        		bill.ReceivePaymentForm.cmbbxType.Click();
        		
        		
        		
        		
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
            validate_ReceivePayment();
        }
    }
}
