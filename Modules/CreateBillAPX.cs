/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-09
 * Time: 2:34 PM
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
    
    [TestModule("A75A6BF1-13FB-4107-91FD-5FD4B6E934AF", ModuleType.UserCode, 1)]
    public class CreateBillAPX : ITestModule
    {
        Bill bill = Bill.Instance;
        BillingTE te = BillingTE.Instance;
        Files file = Files.Instance;
        TimeSheets timeEntry = TimeSheets.Instance;
        
        
        string _fileName = "";
        [TestVariable("29c375fa-529f-42bf-87f0-b2d575ccb580")]
        public string fileName
        {
        	get { return _fileName; }
        	set { _fileName = value; }
        }
        
        string _time = "";
        [TestVariable("1c252086-e706-47d9-b932-a6335b29b514")]
        public string time
        {
        	get { return _time; }
        	set { _time = value; }
        }
        
        public CreateBillAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform()
        {
        	bill.MainForm.btnBilling.Click();
        	bill.MainForm.ToolbarBill.Click();
        	bill.MainForm.SelectBill.Click();
        	bill.BillingDetailForm.SelectFile.Click();
        	timeEntry.FileSelectForm.btnQuickFind.Click();
        	timeEntry.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	timeEntry.FindFilesForm.btnOK.Click();
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
        	//bill.MainForm.FilesIndexForm.listFirstFound.Click(System.Windows.Forms.MouseButtons.Right);
        	//bill.AmicusAttorneyXWin.optionBill.Click();
        	//bill.PromptForm.btnYes.Click();
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Perform();
            //BillTest.Start();
        }
    }
}
