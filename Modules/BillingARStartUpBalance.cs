/*
 * Created By Qiao
 * User: Administrator
 * Date: 2019-01-31
 * Time: 11:51 AM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of BillingARStartUpBalance.
    /// </summary>
    [TestModule("02C27F7D-E366-40BE-9E39-14C1122CCABD", ModuleType.UserCode, 1)]
    public class BillingARStartUpBalance : ITestModule
    {
    	Bill bill = Bill.Instance;
    	Duration customWaitTime = new Duration(3000);
    	
    	
    	string _fileName = "Billing";
    	[TestVariable("a086d807-0187-460b-a7be-174287ee86fc")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public BillingARStartUpBalance()
        {
            // Do not delete - a parameterless constructor is required!
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
            Perform();
        }
        
        public void Perform()
        {
        	bill.MainForm.BILLING.Click();
//        	bill.MainForm.Actions.Select();
			bill.MainForm.Office.Click();
        	bill.MainForm.txtStartUpInfo.WaitForExists(customWaitTime*10);
        	bill.MainForm.startUpOpen.Press();
        	bill.ListItem.ListItemAccountsReceivable.Click();
        	
        	bill.FileSelectForm.SelfInfo.WaitForExists(customWaitTime);
        	bill.FileSelectForm.btnQuickFindFile.Click();
        	bill.FindFilesForm.SelfInfo.WaitForExists(customWaitTime);
        	bill.FindFilesForm.searchTextInput.PressKeys(fileName);
        	bill.FindFilesForm.btnOK.Click();
        	bill.FileSelectForm.listFirstFound.DoubleClick();
        	
        	//Get current AR balance on the File
        	bill.ARStartupBalanceForm.SelfInfo.WaitForExists(customWaitTime);
        	bill.ARStartupBalanceForm.PnlBase.linkToFile.Click();
        	bill.FileDetailForm.SelfInfo.WaitForExists(customWaitTime);
        	String selectedFileName = bill.FileDetailForm.fileTitle.GetAttributeValue<String>("Text");
        	Double initialARFees = Convert.ToDouble(bill.FileDetailForm.feesAR.GetAttributeValue<String>("Text"));
        	Double initialARExpenses = Convert.ToDouble(bill.FileDetailForm.expensesAR.GetAttributeValue<String>("Text"));
        	bill.FileDetailForm.saveClose.Click();
        	
        	//Add Startup AR
        	bill.ARStartupBalanceForm.Self.Activate();
        	bill.ARStartupBalanceForm.PnlBase.txtInvoiceNumber.PressKeys(System.DateTime.Now.Millisecond.ToString());
        	bill.ARStartupBalanceForm.PnlBase.txtFees.PressKeys("3.20");
        	bill.ARStartupBalanceForm.PnlBase.txtExpenses.PressKeys("3.4");
        	bill.ARStartupBalanceForm.btnSaveClose.Click();
        	bill.ARStartupBalanceForm.SelfInfo.WaitForNotExists(customWaitTime);
        	
        	//Verify AR balance
        	bill.MainForm.Files.Click();
        	bill.MainForm.FilesIndexForm.quickFindMagnifier.Click();
        	bill.FindFilesForm.fileNameInput.PressKeys(selectedFileName);
        	bill.FindFilesForm.btnOK.Click();
        	Double finalTotalAR = Convert.ToDouble(bill.MainForm.FilesIndexForm.totalAR.GetAttributeValue<String>("UIAutomationValueValue"));
        	Report.Log(ReportLevel.Info, "AR balance on file " + selectedFileName+ " is now $" + (3.2+3.4+initialARExpenses+initialARFees).ToString());
        	Validate.Equals(finalTotalAR, (3.2+3.4+initialARExpenses+initialARFees));
        }
    }
}
