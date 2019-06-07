/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-15
 * Time: 11:24 AM
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
    /// Description of BillAPX.
    /// </summary>
    [TestModule("98102884-C14D-4992-A4B4-8B6D8D89B5A7", ModuleType.UserCode, 1)]
    public class BillAPX : ITestModule
    {
        Bill bill = Bill.Instance;
        BillingTE te = BillingTE.Instance;
        
        string _fileName = "";
    	[TestVariable("DDE10115-729E-4144-AAC6-425EAF372517")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("6193B8F1-1EEA-4693-866C-25439B548AA0")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
        
        public BillAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform()
        {
        	PopupWatcher unpostedContinue = new PopupWatcher();
        	unpostedContinue.WatchAndClick(bill.PromptForm, bill.PromptForm.btnYesInfo);
        	unpostedContinue.Start();
        	
        	bill.MainForm.btnBilling.Click();
        	bill.MainForm.ToolbarBill.Click();
        	bill.MainForm.SelectBill.Click();
        	bill.BillingDetailForm.SelectFile.Click();        	
        	te.FileSelectForm.btnQuickFind.Click();
        	te.FindFilesForm.txtFindContact.TextValue = fileName + time;
        	te.FindFilesForm.btnOK.Click();
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	Validate.Exists(bill.BillingDetailForm.BillValueInfo);
        	bill.BillingDetailForm.btnSendtoFinal.Click();
        	bill.BillingDetailForm.btnPrintPost.Click();
        	bill.InvoiceEmailForm.Checkbox.Click();
        	bill.InvoiceEmailForm.btnProceed.Click();
        	Delay.Milliseconds(500);
        	bill.OutputPromptForm.btnOk.Click();
        	if(bill.PromptForm.btnOk1Info.Exists())
        	{
        		bill.PromptForm.btnOk1.Click();
        	}
        	bill.ReportViewerForm.btnClose.Click();
        	bill.BillingDetailForm.btnClose.Click();
        	unpostedContinue.Stop();
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
