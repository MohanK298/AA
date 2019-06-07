/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-09
 * Time: 3:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Recordings;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of ReceivePaymentAPX.
    /// </summary>
    [TestModule("34E2AC87-AE6F-49AF-83E8-42379B3886E3", ModuleType.UserCode, 1)]
    public class ReceivePaymentAPX : ITestModule
    {
        Bill bill = Bill.Instance;
        BillingTE te = BillingTE.Instance;
        TimeSheets timeEntry = TimeSheets.Instance;
        
        string _fileName = "";
        [TestVariable("c9bc84f7-c461-459d-a2ff-536e4eaa1f2d")]
        public string fileName
        {
        	get { return _fileName; }
        	set { _fileName = value; }
        }
        
        string _time = "";
        [TestVariable("fd8a3a65-136c-4778-ab96-c3a759a01655")]
        public string time
        {
        	get { return _time; }
        	set { _time = value; }
        }
        
        public ReceivePaymentAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform()
        {
        	bill.MainForm.btnBilling.Click();
        	bill.MainForm.ToolbarBill.Click();
        	bill.MainForm.ReceivePayment.Click();
        	bill.ReceivePaymentForm.SelectFile.Click();
        	//te.FileSelectForm.listFirstFound.DoubleClick();
        	timeEntry.FileSelectForm.btnQuickFind.Click();
        	timeEntry.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	timeEntry.FindFilesForm.btnOK.Click();
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	//Validate.Exists(bill.ReceivePaymentForm.ccNumberInfo);
        	//Report.Success("CC added from Contact is Validated");
        	bill.ReceivePaymentForm.DropdownSelection.Click();
        	bill.ListItem.selectCCapx.Click();
        	bill.ReceivePaymentForm.enterAmount.PressKeys("2.30");
        	bill.ReceivePaymentForm.PayNow.Click();
        	Validate.Exists(bill.PromptForm.AmountTxtInfo);
        	bill.PromptForm.btnYes1.Click();
        	Delay.Seconds(3);
        	if(bill.PromptForm.ConfirmationInfo.Exists())
        	{
        		bill.PromptForm.btnOk.Click();
        	}
        	else
        	{
        		Report.Info("Generating confirmation by more than 3sec");
        	}
        	Delay.Milliseconds(300);
        	
            	
        	
        	
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Perform();
        }
    }
}
