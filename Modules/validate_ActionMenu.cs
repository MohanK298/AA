/*
 * Created by Ranorex
 * User: qa
 * Date: 8/6/2020
 * Time: 4:26 PM
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
    /// Description of validate_ActionMenu.
    /// </summary>
    [TestModule("24A03A9A-2620-48D3-AE65-7C64539B6C9F", ModuleType.UserCode, 1)]
    public class validate_ActionMenu : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_ActionMenu()
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
        
        private void Validate_Action_Menu_Billing()
    	{
    		int rowCount=0;
    		int j=1;
    		int rndNumber=0;
    		Random rnd = new Random();
    		rowCount=cmn.GetTableRowCount(bill.MainForm.tblBilling,"Billing Table");
    		Report.Success("Total Row Count-----"+rowCount.ToString());
    		
    		while(j<2)
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
    		if(bill.MainForm.Toolbar.btnRemovePaymentRequestInfo.Exists(10000))
    		{
    			j++;
    			bill.MainForm.Actions.Click();
    			Validate.AttributeContains(bill.MainForm.ResendPaymentRequestInfo,"Enabled","True","Resend Payment Request Enabled for Existing APX Payment Request");
    			bill.MainForm.Actions.Click();
    			bill.MainForm.cbRowSelect.Click();
    			break;                           
  			}
        		bill.MainForm.cbRowSelect.Click();
    		}
    		j=1;
    		while(j<2)
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
    		if(bill.MainForm.Toolbar.btnAddPaymentRequestInfo.Exists(10000))
    		{
    			j++;
    			bill.MainForm.Actions.Click();
    			Validate.AttributeContains(bill.MainForm.ResendPaymentRequestInfo,"Enabled","False","Resend Payment Request disabled for New APX Payment Request");
    			bill.MainForm.Actions.Click();
    			bill.MainForm.cbRowSelect.Click();
    			break;                           
  			}
        		bill.MainForm.cbRowSelect.Click();
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
            Validate_Action_Menu_Billing();
        }
    }
}
